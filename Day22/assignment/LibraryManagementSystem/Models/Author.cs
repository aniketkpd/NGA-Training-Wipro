using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class Author
{
    public int AuthorId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Bio { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
