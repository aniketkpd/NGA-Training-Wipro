using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecureJwtApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecureJwtApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        AppUser? user = null;

        if (model.Username == "admin" &&
            model.Password == "Admin@123")
        {
            user = new AppUser
            {
                Username = "admin",
                Role = "Admin"
            };
        }
        else if (model.Username == "user" &&
                 model.Password == "User@123")
        {
            user = new AppUser
            {
                Username = "user",
                Role = "User"
            };
        }

        if (user == null)
            return Unauthorized("Invalid credentials");

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),

            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!));

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],

            audience: _configuration["Jwt:Audience"],

            claims: claims,

            expires: DateTime.Now.AddMinutes(15),

            signingCredentials: creds
        );

        return Ok(new
        {
            token = new JwtSecurityTokenHandler()
                .WriteToken(token)
        });
    }
}