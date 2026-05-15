namespace SecureJwtApi.Services.Security;

public interface ISecurityAuditService
{
    Task LogAsync(string eventType, bool success, string? username, HttpContext httpContext, string? details = null);
}
