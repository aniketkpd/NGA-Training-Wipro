using LibraryManagementSystem.DatabaseFirst;
using LibraryManagementSystem.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

[ApiController]
[Route("api/database-first/authors")]
public class DatabaseFirstAuthorsController(ExistingLibraryContext context) : ControllerBase
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

    [HttpPost]
    public async Task<ActionResult<AuthorReadDto>> CreateAuthor(AuthorCreateDto dto, CancellationToken cancellationToken)
    {
        var author = new ExistingAuthor { Name = dto.Name.Trim(), Bio = dto.Bio?.Trim() };

        context.Authors.Add(author);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetAuthors), new AuthorReadDto(author.AuthorId, author.Name, author.Bio));
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
        await context.SaveChangesAsync(cancellationToken);

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
            return Conflict("Authors with books cannot be deleted.");
        }

        context.Authors.Remove(author);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}
