using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SimpleJWTApp.Controllers
{
    public class DemoController : Controller
    {
        //here we can add some endpoints to test the JWT authentication
        //Login API to generate JWT token
        //secure API endpoint that requires JWT authentication

        private readonly IConfiguration _configuration;
        public DemoController(IConfiguration configuration) //injecting configuration to access JWT settings
        {
            _configuration = configuration;
        }


        //Login Api to generate JWT token
        [HttpPost("login")]
        public IActionResult Login()
        {
            //here we can define key, credentials and other JWT settings    
            var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JwtKey"]));

            var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
            //hmacsha256 is a hashing algorithm used to sign the JWT token, ensuring its integrity and authenticity.

            var token = new JwtSecurityToken(
                claims: new[]
                {
                new Claim("name", "Aniket")
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwtToken);
        }


        //Secure API endpoint that requires JWT authentication
        // this API will only be accessible if the request includes a valid JWT token in the Authorization header. If the token is valid, the user will be authenticated and can access the protected resource. If the token is missing or invalid, the request will be denied with an appropriate HTTP status code (e.g., 401 Unauthorized).
        [Authorize]
        [HttpGet("data")]
        public IActionResult GetData()
        {
            return Ok("This is a protected data, only acessible once Tokens are verified !!!");
        }

    }
}
