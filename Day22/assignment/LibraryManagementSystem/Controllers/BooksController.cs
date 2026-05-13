using LibraryManagementSystem.Data;
using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(LibraryContext context, ILogger<BooksController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookReadDto>>> GetBooks(CancellationToken cancellationToken)
    {
        var books = await context.Books
            .AsNoTracking()
            .Include(book => book.Author)
            .Include(book => book.BookGenres)
            .ThenInclude(bookGenre => bookGenre.Genre)
            .AsSplitQuery()
            .OrderBy(book => book.Title)
            .ToListAsync(cancellationToken);

        return Ok(books.Select(ToReadDto));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookReadDto>> GetBook(int id, CancellationToken cancellationToken)
    {
        var book = await context.Books
            .AsNoTracking()
            .Include(book => book.Author)
            .Include(book => book.BookGenres)
            .ThenInclude(bookGenre => bookGenre.Genre)
            .AsSplitQuery()
            .SingleOrDefaultAsync(book => book.BookId == id, cancellationToken);

        return book is null ? NotFound() : Ok(ToReadDto(book));
    }

    [HttpPost]
    public async Task<ActionResult<BookReadDto>> CreateBook(BookCreateDto dto, CancellationToken cancellationToken)
    {
        var validation = await ValidateReferences(dto.AuthorId, dto.GenreIds, cancellationToken);
        if (validation is not null)
        {
            return validation;
        }

        var book = new Book
        {
            Title = dto.Title.Trim(),
            AuthorId = dto.AuthorId,
            BookGenres = dto.GenreIds.Distinct().Select(genreId => new BookGenre { GenreId = genreId }).ToList()
        };

        try
        {
            context.Books.Add(book);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "Unable to create book {BookTitle}", dto.Title);
            return Problem("The book could not be saved.");
        }

        var createdBook = await LoadBook(book.BookId, cancellationToken);
        return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, ToReadDto(createdBook!));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBook(int id, BookUpdateDto dto, CancellationToken cancellationToken)
    {
        var validation = await ValidateReferences(dto.AuthorId, dto.GenreIds, cancellationToken);
        if (validation is not null)
        {
            return validation;
        }

        var book = await context.Books
            .Include(book => book.BookGenres)
            .SingleOrDefaultAsync(book => book.BookId == id, cancellationToken);

        if (book is null)
        {
            return NotFound();
        }

        book.Title = dto.Title.Trim();
        book.AuthorId = dto.AuthorId;
        book.BookGenres.Clear();
        foreach (var genreId in dto.GenreIds.Distinct())
        {
            book.BookGenres.Add(new BookGenre { BookId = id, GenreId = genreId });
        }

        try
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "Unable to update book {BookId}", id);
            return Problem("The book could not be updated.");
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBook(int id, CancellationToken cancellationToken)
    {
        var book = await context.Books.FindAsync([id], cancellationToken);
        if (book is null)
        {
            return NotFound();
        }

        context.Books.Remove(book);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpGet("with-author-and-genres")]
    public async Task<ActionResult<IEnumerable<BookReadDto>>> GetBooksWithAuthorAndGenres(CancellationToken cancellationToken)
    {
        var books = await context.Books
            .AsNoTracking()
            .Include(book => book.Author)
            .Include(book => book.BookGenres)
            .ThenInclude(bookGenre => bookGenre.Genre)
            .AsSplitQuery()
            .OrderBy(book => book.Title)
            .ToListAsync(cancellationToken);

        return Ok(books.Select(ToReadDto));
    }

    private async Task<Book?> LoadBook(int id, CancellationToken cancellationToken)
    {
        return await context.Books
            .AsNoTracking()
            .Include(book => book.Author)
            .Include(book => book.BookGenres)
            .ThenInclude(bookGenre => bookGenre.Genre)
            .AsSplitQuery()
            .SingleOrDefaultAsync(book => book.BookId == id, cancellationToken);
    }

    private async Task<ActionResult?> ValidateReferences(
        int authorId,
        IReadOnlyCollection<int> genreIds,
        CancellationToken cancellationToken)
    {
        if (!await context.Authors.AnyAsync(author => author.AuthorId == authorId, cancellationToken))
        {
            return BadRequest($"Author {authorId} does not exist.");
        }

        var requestedGenreIds = genreIds.Distinct().ToList();
        var existingGenreIds = await context.Genres
            .Where(genre => requestedGenreIds.Contains(genre.GenreId))
            .Select(genre => genre.GenreId)
            .ToListAsync(cancellationToken);

        var missingGenreIds = requestedGenreIds.Except(existingGenreIds).ToList();
        return missingGenreIds.Count == 0
            ? null
            : BadRequest($"Genres not found: {string.Join(", ", missingGenreIds)}.");
    }

    private static BookReadDto ToReadDto(Book book)
    {
        return new BookReadDto(
            book.BookId,
            book.Title,
            book.Author is null ? null : new AuthorReadDto(book.Author.AuthorId, book.Author.Name, book.Author.Bio),
            book.BookGenres
                .Where(bookGenre => bookGenre.Genre is not null)
                .OrderBy(bookGenre => bookGenre.Genre!.Name)
                .Select(bookGenre => new GenreReadDto(bookGenre.Genre!.GenreId, bookGenre.Genre.Name))
                .ToList());
    }
}
