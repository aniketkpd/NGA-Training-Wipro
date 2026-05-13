using LibraryManagementSystem.Data;
using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController(LibraryContext context, ILogger<GenresController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreReadDto>>> GetGenres(CancellationToken cancellationToken)
    {
        var genres = await context.Genres
            .AsNoTracking()
            .OrderBy(genre => genre.Name)
            .Select(genre => new GenreReadDto(genre.GenreId, genre.Name))
            .ToListAsync(cancellationToken);

        return Ok(genres);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GenreReadDto>> GetGenre(int id, CancellationToken cancellationToken)
    {
        var genre = await context.Genres
            .AsNoTracking()
            .Where(genre => genre.GenreId == id)
            .Select(genre => new GenreReadDto(genre.GenreId, genre.Name))
            .SingleOrDefaultAsync(cancellationToken);

        return genre is null ? NotFound() : Ok(genre);
    }

    [HttpPost]
    public async Task<ActionResult<GenreReadDto>> CreateGenre(GenreCreateDto dto, CancellationToken cancellationToken)
    {
        var genre = new Genre { Name = dto.Name.Trim() };

        try
        {
            context.Genres.Add(genre);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "Unable to create genre {GenreName}", dto.Name);
            return Problem("The genre could not be saved. Make sure the name is unique.");
        }

        var result = new GenreReadDto(genre.GenreId, genre.Name);
        return CreatedAtAction(nameof(GetGenre), new { id = genre.GenreId }, result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateGenre(int id, GenreUpdateDto dto, CancellationToken cancellationToken)
    {
        var genre = await context.Genres.FindAsync([id], cancellationToken);
        if (genre is null)
        {
            return NotFound();
        }

        genre.Name = dto.Name.Trim();

        try
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "Unable to update genre {GenreId}", id);
            return Problem("The genre could not be updated. Make sure the name is unique.");
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteGenre(int id, CancellationToken cancellationToken)
    {
        var genre = await context.Genres.FindAsync([id], cancellationToken);
        if (genre is null)
        {
            return NotFound();
        }

        context.Genres.Remove(genre);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}
