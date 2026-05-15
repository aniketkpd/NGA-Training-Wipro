using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecureJwtApi.Models;
using SecureJwtApi.Services;
using SecureJwtApi.Services.Security;

namespace SecureJwtApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly ISecurityAuditService _audit;
    private readonly IConfiguration _configuration;

    public AuthController(UserService userService, ISecurityAuditService audit, IConfiguration configuration)
    {
        _userService = userService;
        _audit = audit;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var (success, error) = await _userService.RegisterAsync(model, HttpContext);
        if (!success)
            return Conflict(new { message = error });

        return Ok(new { message = "Registration successful. Please log in." });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var user = await _userService.ValidateLoginAsync(model.Username, model.Password);
        if (user is null)
        {
            await _audit.LogAsync("Login", false, model.Username, HttpContext, "Invalid credentials");
            return Unauthorized(new { message = "Invalid credentials" });
        }

        var token = CreateJwt(user);
        await _audit.LogAsync("Login", true, user.Username, HttpContext, "JWT issued");

        return Ok(new { token });
    }

    private string CreateJwt(Data.Entities.ApplicationUser user)
    {
        var jwt = _configuration.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiryMinutes = int.TryParse(jwt["ExpiryMinutes"], out var m) ? m : 15;

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
