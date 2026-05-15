namespace SecureJwtApi.Models;

public class AuditLogDto
{
    public string EventType { get; set; } = string.Empty;

    public string? Username { get; set; }

    public bool Success { get; set; }

    public DateTime TimestampUtc { get; set; }
}
