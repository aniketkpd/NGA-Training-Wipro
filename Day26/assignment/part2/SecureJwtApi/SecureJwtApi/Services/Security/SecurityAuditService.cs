using SecureJwtApi.Data;
using SecureJwtApi.Data.Entities;

namespace SecureJwtApi.Services.Security;

public sealed class SecurityAuditService : ISecurityAuditService
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<SecurityAuditService> _logger;

    public SecurityAuditService(ApplicationDbContext db, ILogger<SecurityAuditService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task LogAsync(string eventType, bool success, string? username, HttpContext httpContext, string? details = null)
    {
        var ip = httpContext.Connection.RemoteIpAddress?.ToString();
        var entry = new SecurityAuditLog
        {
            EventType = eventType,
            Username = username,
            IpAddress = ip,
            Success = success,
            Details = SanitizeDetails(details),
            TimestampUtc = DateTime.UtcNow
        };

        _db.SecurityAuditLogs.Add(entry);
        await _db.SaveChangesAsync();

        _logger.LogInformation(
            "Audit {EventType} user={Username} success={Success} ip={Ip}",
            eventType,
            username ?? "(anonymous)",
            success,
            ip);
    }

    private static string? SanitizeDetails(string? details)
    {
        if (string.IsNullOrWhiteSpace(details))
            return null;

        if (details.Length > 500)
            return details[..500];

        return details;
    }
}
