using System.ComponentModel.DataAnnotations;

namespace AdvancedLibraryManagementSystem.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Isbn { get; set; }

    [Range(1450, 3000)]
    public int PublishedYear { get; set; }

    public int AuthorId { get; set; }
    public Author? Author { get; set; }

    public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
}
