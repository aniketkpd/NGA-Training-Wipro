using AdvancedLibraryManagementSystem.Data;
using AdvancedLibraryManagementSystem.Models;
using AdvancedLibraryManagementSystem.Repositories.Interfaces;
using AdvancedLibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvancedLibraryManagementSystem.Controllers;

public class LibraryController(
    IBookRepository bookRepository,
    IAuthorRepository authorRepository,
    IGenreRepository genreRepository,
    LibraryDbContext dbContext,
    ILogger<LibraryController> logger) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var vm = new LibraryDashboardVm
        {
            Authors = await authorRepository.GetAllAsync(orderBy: q => q.OrderBy(a => a.Name)),
            Genres = await genreRepository.GetAllAsync(orderBy: q => q.OrderBy(g => g.Name))
        };
        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> Books([FromQuery] BookQueryParams queryParams)
    {
        var result = await bookRepository.GetPagedBooksAsync(queryParams);
        var payload = result.Items.Select(b => new
        {
            b.Id,
            b.Title,
            b.Isbn,
            b.PublishedYear,
            AuthorName = b.Author?.Name ?? "Unknown",
            Genres = b.BookGenres.Select(bg => bg.Genre!.Name).ToList()
        });

        return Json(new
        {
            items = payload,
            result.TotalCount,
            result.CurrentPage,
            result.PageSize,
            result.TotalPages
        });
    }

    [HttpGet]
    public async Task<IActionResult> Book(int id)
    {
        var book = await bookRepository.GetBookDetailsAsync(id);
        if (book is null)
        {
            return NotFound(new { message = "Book not found." });
        }

        return Json(new
        {
            book.Id,
            book.Title,
            book.Isbn,
            book.PublishedYear,
            book.AuthorId,
            GenreIds = book.BookGenres.Select(bg => bg.GenreId).ToList()
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] BookRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid book data.", errors = ModelState });
        }

        try
        {
            var entity = new Book
            {
                Title = request.Title.Trim(),
                Isbn = request.Isbn?.Trim(),
                PublishedYear = request.PublishedYear,
                AuthorId = request.AuthorId,
                BookGenres = request.GenreIds.Distinct().Select(gid => new BookGenre { GenreId = gid }).ToList()
            };

            await bookRepository.AddAsync(entity);
            return Ok(new { message = "Book created successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while creating book.");
            return StatusCode(500, new { message = "Unable to create book right now." });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook([FromBody] BookRequestDto request)
    {
        if (!request.Id.HasValue)
        {
            return BadRequest(new { message = "Book id is required." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid book data.", errors = ModelState });
        }

        try
        {
            var existing = await dbContext.Books
                .Include(b => b.BookGenres)
                .FirstOrDefaultAsync(b => b.Id == request.Id.Value);

            if (existing is null)
            {
                return NotFound(new { message = "Book not found." });
            }

            existing.Title = request.Title.Trim();
            existing.Isbn = request.Isbn?.Trim();
            existing.PublishedYear = request.PublishedYear;
            existing.AuthorId = request.AuthorId;

            dbContext.BookGenres.RemoveRange(existing.BookGenres);
            existing.BookGenres = request.GenreIds.Distinct().Select(gid => new BookGenre
            {
                BookId = existing.Id,
                GenreId = gid
            }).ToList();

            await dbContext.SaveChangesAsync();
            return Ok(new { message = "Book updated successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while updating book.");
            return StatusCode(500, new { message = "Unable to update book right now." });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBook(int id)
    {
        try
        {
            await bookRepository.DeleteAsync(id);
            return Ok(new { message = "Book deleted successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while deleting book.");
            return StatusCode(500, new { message = "Unable to delete book right now." });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest(new { message = "Author name is required." });
        }

        try
        {
            await authorRepository.AddAsync(new Author { Name = name.Trim() });
            return Ok(new { message = "Author added successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while creating author.");
            return StatusCode(500, new { message = "Unable to add author." });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Authors()
    {
        var authors = await authorRepository.GetAllAsync(orderBy: q => q.OrderBy(a => a.Name));
        return Json(authors.Select(a => new { a.Id, a.Name, a.Bio }));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAuthor([FromBody] Author request)
    {
        if (request.Id <= 0 || string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest(new { message = "Valid author data is required." });
        }

        try
        {
            var existing = await authorRepository.GetByIdAsync(request.Id);
            if (existing is null)
            {
                return NotFound(new { message = "Author not found." });
            }

            existing.Name = request.Name.Trim();
            existing.Bio = request.Bio;
            await authorRepository.UpdateAsync(existing);
            return Ok(new { message = "Author updated successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while updating author.");
            return StatusCode(500, new { message = "Unable to update author." });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        try
        {
            await authorRepository.DeleteAsync(id);
            return Ok(new { message = "Author deleted successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while deleting author.");
            return StatusCode(500, new { message = "Unable to delete author." });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest(new { message = "Genre name is required." });
        }

        try
        {
            await genreRepository.AddAsync(new Genre { Name = name.Trim() });
            return Ok(new { message = "Genre added successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while creating genre.");
            return StatusCode(500, new { message = "Unable to add genre." });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Genres()
    {
        var genres = await genreRepository.GetAllAsync(orderBy: q => q.OrderBy(g => g.Name));
        return Json(genres.Select(g => new { g.Id, g.Name }));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGenre([FromBody] Genre request)
    {
        if (request.Id <= 0 || string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest(new { message = "Valid genre data is required." });
        }

        try
        {
            var existing = await genreRepository.GetByIdAsync(request.Id);
            if (existing is null)
            {
                return NotFound(new { message = "Genre not found." });
            }

            existing.Name = request.Name.Trim();
            await genreRepository.UpdateAsync(existing);
            return Ok(new { message = "Genre updated successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while updating genre.");
            return StatusCode(500, new { message = "Unable to update genre." });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        try
        {
            await genreRepository.DeleteAsync(id);
            return Ok(new { message = "Genre deleted successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while deleting genre.");
            return StatusCode(500, new { message = "Unable to delete genre." });
        }
    }
}
