using System.ComponentModel.DataAnnotations;

namespace SecureJwtApi.Models;

public class RegisterModel
{
    [Required]
    [StringLength(64, MinimumLength = 3)]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username may only contain letters, numbers, and underscores.")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(128, MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(128, MinimumLength = 2)]
    public string FullName { get; set; } = string.Empty;

    [StringLength(32)]
    [RegularExpression(@"^[0-9\-]+$", ErrorMessage = "Financial account may only contain digits and hyphens.")]
    public string? FinancialAccount { get; set; }
}
