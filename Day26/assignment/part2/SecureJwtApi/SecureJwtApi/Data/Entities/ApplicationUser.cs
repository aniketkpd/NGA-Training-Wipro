namespace SecureJwtApi.Data.Entities;

/// <summary>
/// User record. Passwords are stored as BCrypt hashes only.
/// PII and financial fields are AES-encrypted at the application layer (column-level encryption).
/// </summary>
public class ApplicationUser
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Role { get; set; } = "User";

    public string? EmailEncrypted { get; set; }

    public string? FullNameEncrypted { get; set; }

    public string? FinancialAccountEncrypted { get; set; }

    /// <summary>HMAC over canonical sensitive fields for integrity verification.</summary>
    public string? DataIntegrityHmac { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public bool IsActive { get; set; } = true;
}
