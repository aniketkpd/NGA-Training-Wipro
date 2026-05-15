using System.ComponentModel.DataAnnotations;

namespace SecureTaskManager.Models;

public class AppUser
{
    public int Id { get; set; }

    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public string Role { get; set; } = "User";

    public bool CanEditTask { get; set; }
}