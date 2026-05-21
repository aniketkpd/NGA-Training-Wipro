using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogApi.Data;
using MovieCatalogApi.Models;

namespace MovieCatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DirectorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirectors()
        {
            return await _context.Directors.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Director>> CreateDirector(Director director)
        {
            _context.Directors.Add(director);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDirectors), new { id = director.Id }, director);
        }

        [HttpGet("{directorId}/movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByDirector(int directorId)
        {
            var directorExists = await _context.Directors.AnyAsync(d => d.Id == directorId);

            if (!directorExists)
                return NotFound("Director not found");

            var movies = await _context.Movies
                .Where(m => m.DirectorId == directorId)
                .ToListAsync();

            return movies;
        }
    }
}