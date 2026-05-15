using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureJwtApi.Services;
using SecureJwtApi.Services.Security;

namespace SecureJwtApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
[Produces("application/json")]
public class AdminController : ControllerBase
{
    private readonly UserService _userService;
    private readonly ISecurityAuditService _audit;

    public AdminController(UserService userService, ISecurityAuditService audit)
    {
        _userService = userService;
        _audit = audit;
    }

    [HttpGet("users")]
    public async Task<IActionResult> ListUsers()
    {
        await _audit.LogAsync("AdminListUsers", true, User.Identity?.Name, HttpContext);
        var users = await _userService.ListUsersForAdminAsync();
        return Ok(users);
    }

    [HttpGet("audit-logs")]
    public async Task<IActionResult> AuditLogs([FromQuery] int take = 50)
    {
        take = Math.Clamp(take, 1, 200);
        var logs = await _userService.GetRecentAuditLogsAsync(take);
        return Ok(logs);
    }

    [HttpGet("access-check")]
    public IActionResult AccessCheck() =>
        Ok(new { message = "Admin RBAC access granted." });
}
