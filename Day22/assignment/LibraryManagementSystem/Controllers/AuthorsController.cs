using LibraryManagementSystem.Data;
using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(LibraryContext context, ILogger<AuthorsController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorReadDto>>> GetAuthors(CancellationToken cancellationToken)
    {
        var authors = await context.Authors
            .AsNoTracking()
            .OrderBy(author => author.Name)
            .Select(author => new AuthorReadDto(author.AuthorId, author.Name, author.Bio))
            .ToListAsync(cancellationToken);

        return Ok(authors);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AuthorReadDto>> GetAuthor(int id, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .AsNoTracking()
            .Where(author => author.AuthorId == id)
            .Select(author => new AuthorReadDto(author.AuthorId, author.Name, author.Bio))
            .SingleOrDefaultAsync(cancellationToken);

        return author is null ? NotFound() : Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorReadDto>> CreateAuthor(AuthorCreateDto dto, CancellationToken cancellationToken)
    {
        var author = new Author { Name = dto.Name.Trim(), Bio = dto.Bio?.Trim() };

        try
        {
            context.Authors.Add(author);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "Unable to create author {AuthorName}", dto.Name);
            return Problem("The author could not be saved.");
        }

        var result = new AuthorReadDto(author.AuthorId, author.Name, author.Bio);
        return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAuthor(int id, AuthorUpdateDto dto, CancellationToken cancellationToken)
    {
        var author = await context.Authors.FindAsync([id], cancellationToken);
        if (author is null)
        {
            return NotFound();
        }

        author.Name = dto.Name.Trim();
        author.Bio = dto.Bio?.Trim();

        try
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "Unable to update author {AuthorId}", id);
            return Problem("The author could not be updated.");
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthor(int id, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .Include(author => author.Books)
            .SingleOrDefaultAsync(author => author.AuthorId == id, cancellationToken);

        if (author is null)
        {
            return NotFound();
        }

        if (author.Books.Count > 0)
        {
            return Conflict("Authors with books cannot be deleted. Reassign or delete the books first.");
        }

        context.Authors.Remove(author);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}
