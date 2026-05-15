using System.ComponentModel.DataAnnotations;

namespace SecureTaskManager.Models;

public class RegisterViewModel
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$")]
    public string Password { get; set; } = string.Empty;
}