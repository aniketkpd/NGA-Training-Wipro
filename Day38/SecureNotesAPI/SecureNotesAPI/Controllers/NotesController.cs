using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureNotesAPI.Data;
using SecureNotesAPI.DTOs;
using SecureNotesAPI.Models;
using System.Security.Claims;
using System.Linq;

namespace SecureNotesAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/notes")]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(NoteDto dto)
        {
            var note = new Note
            {
                Title = dto.Title,
                Content = dto.Content
            };

            _context.Notes.Add(note);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Note added successfully.",
                noteId = note.Id
            });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Notes.ToList());
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, NoteDto dto)
        {
            var note = _context.Notes.Find(id);

            if (note == null)
                return NotFound();

            note.Title = dto.Title;
            note.Content = dto.Content;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var note = _context.Notes.Find(id);

            if (note == null)
                return NotFound();

            _context.Notes.Remove(note);

            _context.SaveChanges();

            return Ok();
        }
    }
}