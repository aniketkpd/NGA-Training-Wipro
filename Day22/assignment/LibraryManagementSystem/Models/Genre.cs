using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class Genre
{
    public int GenreId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
}
