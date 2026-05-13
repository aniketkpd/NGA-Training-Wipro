using LibraryManagementSystem.DatabaseFirst;
using LibraryManagementSystem.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

[ApiController]
[Route("api/database-first/books")]
public class DatabaseFirstBooksController(ExistingLibraryContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookReadDto>>> GetBooks(CancellationToken cancellationToken)
    {
        var books = await context.Books
            .AsNoTracking()
            .Include(book => book.Author)
            .Include(book => book.Genres)
            .AsSplitQuery()
            .OrderBy(book => book.Title)
            .ToListAsync(cancellationToken);

        return Ok(books.Select(book => new BookReadDto(
            book.BookId,
            book.Title,
            new AuthorReadDto(book.Author.AuthorId, book.Author.Name, book.Author.Bio),
            book.Genres
                .OrderBy(genre => genre.Name)
                .Select(genre => new GenreReadDto(genre.GenreId, genre.Name))
                .ToList())));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookReadDto>> GetBook(int id, CancellationToken cancellationToken)
    {
        var book = await context.Books
            .AsNoTracking()
            .Include(book => book.Author)
            .Include(book => book.Genres)
            .AsSplitQuery()
            .SingleOrDefaultAsync(book => book.BookId == id, cancellationToken);

        if (book is null)
        {
            return NotFound();
        }

        return Ok(new BookReadDto(
            book.BookId,
            book.Title,
            new AuthorReadDto(book.Author.AuthorId, book.Author.Name, book.Author.Bio),
            book.Genres
                .OrderBy(genre => genre.Name)
                .Select(genre => new GenreReadDto(genre.GenreId, genre.Name))
                .ToList()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(BookCreateDto dto, CancellationToken cancellationToken)
    {
        var authorExists = await context.Authors.AnyAsync(author => author.AuthorId == dto.AuthorId, cancellationToken);
        if (!authorExists)
        {
            return BadRequest($"Author {dto.AuthorId} does not exist.");
        }

        var genres = await context.Genres
            .Where(genre => dto.GenreIds.Contains(genre.GenreId))
            .ToListAsync(cancellationToken);

        var missingGenres = FindMissingGenres(dto.GenreIds, genres);
        if (missingGenres is not null)
        {
            return missingGenres;
        }

        var book = new ExistingBook
        {
            Title = dto.Title.Trim(),
            AuthorId = dto.AuthorId,
            Genres = genres
        };

        context.Books.Add(book);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, null);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBook(int id, BookUpdateDto dto, CancellationToken cancellationToken)
    {
        var book = await context.Books
            .Include(book => book.Genres)
            .SingleOrDefaultAsync(book => book.BookId == id, cancellationToken);

        if (book is null)
        {
            return NotFound();
        }

        var authorExists = await context.Authors.AnyAsync(author => author.AuthorId == dto.AuthorId, cancellationToken);
        if (!authorExists)
        {
            return BadRequest($"Author {dto.AuthorId} does not exist.");
        }

        var genres = await context.Genres
            .Where(genre => dto.GenreIds.Contains(genre.GenreId))
            .ToListAsync(cancellationToken);

        var missingGenres = FindMissingGenres(dto.GenreIds, genres);
        if (missingGenres is not null)
        {
            return missingGenres;
        }

        book.Title = dto.Title.Trim();
        book.AuthorId = dto.AuthorId;
        book.Genres.Clear();
        foreach (var genre in genres)
        {
            book.Genres.Add(genre);
        }

        await context.SaveChangesAsync(cancellationToken);
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

    private BadRequestObjectResult? FindMissingGenres(IReadOnlyCollection<int> requestedGenreIds, List<ExistingGenre> genres)
    {
        var missingGenreIds = requestedGenreIds.Distinct().Except(genres.Select(genre => genre.GenreId)).ToList();
        return missingGenreIds.Count == 0
            ? null
            : BadRequest($"Genres not found: {string.Join(", ", missingGenreIds)}.");
    }
}
