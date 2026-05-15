using System.ComponentModel.DataAnnotations;

namespace SecureJwtApi.Models;

public class LoginModel
{
    [Required]
    [StringLength(64, MinimumLength = 3)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(128, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;
}
