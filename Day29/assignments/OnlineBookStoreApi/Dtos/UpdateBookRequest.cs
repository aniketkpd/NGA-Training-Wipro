using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApi.Dtos;

public sealed class UpdateBookRequest
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public required string Title { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "AuthorId must be a valid positive number.")]
    public int AuthorId { get; set; }

    [Range(1000, 2100)]
    public int PublicationYear { get; set; }
}
