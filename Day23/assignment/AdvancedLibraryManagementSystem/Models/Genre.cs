using System.ComponentModel.DataAnnotations;

namespace AdvancedLibraryManagementSystem.Models;

public class Genre
{
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Name { get; set; } = string.Empty;

    public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
}
