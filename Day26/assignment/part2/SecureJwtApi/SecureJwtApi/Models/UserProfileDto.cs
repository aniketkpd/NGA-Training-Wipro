namespace SecureJwtApi.Models;

public class UserProfileDto
{
    public string Username { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public string? FinancialAccountMasked { get; set; }

    public bool IntegrityValid { get; set; }
}
