using System.ComponentModel.DataAnnotations;

namespace AdvancedLibraryManagementSystem.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    [StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Bio { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
