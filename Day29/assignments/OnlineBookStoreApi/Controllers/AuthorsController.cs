using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreApi.Data;
using OnlineBookStoreApi.Dtos;
using OnlineBookStoreApi.Models;

namespace OnlineBookStoreApi.Controllers;

[ApiController]
[Route("api/authors")]
[Produces("application/json")]
public sealed class AuthorsController(BookStoreRepository repository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Author>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Author>> GetAuthors()
    {
        return Ok(repository.GetAuthors());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Author> GetAuthor(int id)
    {
        var author = repository.GetAuthor(id);
        return author is null
            ? NotFound(new { message = $"Author with ID {id} was not found." })
            : Ok(author);
    }

    [HttpGet("{authorId:int}/books")]
    [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<Book>> GetBooksByAuthor(int authorId)
    {
        var books = repository.GetBooksByAuthor(authorId);
        return books is null
            ? NotFound(new { message = $"Author with ID {authorId} was not found." })
            : Ok(books);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Author), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Author> CreateAuthor(CreateAuthorRequest request)
    {
        var author = repository.AddAuthor(request);
        return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Author> UpdateAuthor(int id, UpdateAuthorRequest request)
    {
        var author = repository.UpdateAuthor(id, request);
        return author is null
            ? NotFound(new { message = $"Author with ID {id} was not found." })
            : Ok(author);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteAuthor(int id)
    {
        return repository.DeleteAuthor(id)
            ? NoContent()
            : NotFound(new { message = $"Author with ID {id} was not found." });
    }
}
