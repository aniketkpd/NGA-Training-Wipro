using System.ComponentModel.DataAnnotations;

namespace AdvancedLibraryManagementSystem.ViewModels;

public class BookRequestDto
{
    public int? Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Isbn { get; set; }

    [Range(1450, 3000)]
    public int PublishedYear { get; set; }

    [Range(1, int.MaxValue)]
    public int AuthorId { get; set; }

    public List<int> GenreIds { get; set; } = [];
}
