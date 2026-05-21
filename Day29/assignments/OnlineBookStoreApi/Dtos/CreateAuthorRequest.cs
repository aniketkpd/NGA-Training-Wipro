using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApi.Dtos;

public sealed class CreateAuthorRequest
{
    [Required]
    [StringLength(120, MinimumLength = 2)]
    public required string Name { get; set; }

    [StringLength(500)]
    public string? Bio { get; set; }
}
