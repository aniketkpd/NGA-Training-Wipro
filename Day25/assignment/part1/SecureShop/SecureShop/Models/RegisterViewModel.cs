using System.ComponentModel.DataAnnotations;

namespace SecureShop.Models;

public class RegisterViewModel
{
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Password must contain uppercase, number and special character.")]
    public string Password { get; set; } = string.Empty;
}