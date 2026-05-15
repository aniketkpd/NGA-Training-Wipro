using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureJwtApi.Controllers;

/// <summary>Security assessment checklist endpoints (SDLC / penetration-test documentation).</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SecurityController : ControllerBase
{
    [HttpGet("assessment-checklist")]
    [AllowAnonymous]
    public IActionResult AssessmentChecklist() =>
        Ok(new
        {
            sdlcPhases = new[] { "Design", "Development", "Testing", "Deployment" },
            assessments = new[]
            {
                "SQL Injection — mitigated via Entity Framework Core (parameterized queries only)",
                "XSS — JSON API + security headers + input validation",
                "CSRF — JWT bearer tokens (no cookie session); use antiforgery for cookie-based forms",
                "Password storage — BCrypt hashing (work factor 12)",
                "Data at rest — AES-256-GCM column encryption for PII/financial fields",
                "Data in transit — TLS for HTTPS; SQL connection Encrypt=True",
                "Integrity — HMAC-SHA256 over sensitive user fields",
                "Access control — JWT + role-based authorization (Admin/User)",
                "Auditing — SecurityAuditLogs table for login/register/admin events",
                "Secrets — connection strings via User Secrets / Key Vault (not hardcoded in source)"
            },
            staticAnalysis = "Microsoft.CodeAnalysis.NetAnalyzers enabled in csproj",
            recommendedPenTests = new[]
            {
                "Attempt SQL injection on login/register (should fail)",
                "Access /api/admin/* without Admin role (should return 403)",
                "Replay expired JWT (should return 401)",
                "Verify database connection uses Encrypt=True"
            }
        });

    [HttpGet("secure-status")]
    [Authorize]
    public IActionResult SecureStatus() =>
        Ok(new { message = "Authenticated. Use /api/users/profile for encrypted user data." });
}
