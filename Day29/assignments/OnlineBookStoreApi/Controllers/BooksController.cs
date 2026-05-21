using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreApi.Data;
using OnlineBookStoreApi.Dtos;
using OnlineBookStoreApi.Models;

namespace OnlineBookStoreApi.Controllers;

[ApiController]
[Route("api/books")]
[Produces("application/json")]
public sealed class BooksController(BookStoreRepository repository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return Ok(repository.GetBooks());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Book> GetBook(int id)
    {
        var book = repository.GetBook(id);
        return book is null
            ? NotFound(new { message = $"Book with ID {id} was not found." })
            : Ok(book);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Book> CreateBook(CreateBookRequest request)
    {
        var book = repository.AddBook(request);
        if (book is null)
        {
            return BadRequest(new { message = $"Author with ID {request.AuthorId} does not exist." });
        }

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Book> UpdateBook(int id, UpdateBookRequest request)
    {
        if (repository.GetBook(id) is null)
        {
            return NotFound(new { message = $"Book with ID {id} was not found." });
        }

        var book = repository.UpdateBook(id, request);
        return book is null
            ? BadRequest(new { message = $"Author with ID {request.AuthorId} does not exist." })
            : Ok(book);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteBook(int id)
    {
        return repository.DeleteBook(id)
            ? NoContent()
            : NotFound(new { message = $"Book with ID {id} was not found." });
    }
}
