using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class Book
{
    public int BookId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public int AuthorId { get; set; }

    public Author? Author { get; set; }

    public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
}
