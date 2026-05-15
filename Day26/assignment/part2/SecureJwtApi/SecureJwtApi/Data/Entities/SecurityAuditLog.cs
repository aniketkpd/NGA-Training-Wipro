namespace SecureJwtApi.Data.Entities;

public class SecurityAuditLog
{
    public long Id { get; set; }

    public string EventType { get; set; } = string.Empty;

    public string? Username { get; set; }

    public string? IpAddress { get; set; }

    public bool Success { get; set; }

    /// <summary>Non-sensitive audit detail only (never passwords or decrypted PII).</summary>
    public string? Details { get; set; }

    public DateTime TimestampUtc { get; set; }
}
