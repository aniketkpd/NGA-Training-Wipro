using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SecureTaskManager.Data;
using SecureTaskManager.Models;
using System.Security.Claims;

namespace SecureTaskManager.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = new AppUser
        {
            Username = model.Username,
            Email = model.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
            //Role = "User",
            Role = "Admin",
            CanEditTask = true
        };

        _context.Users.Add(user);

        _context.SaveChanges();

        return RedirectToAction("Login");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = _context.Users
            .FirstOrDefault(x => x.Username == model.Username);

        if (user == null)
        {
            ModelState.AddModelError("", "Invalid credentials");
            return View(model);
        }

        bool isValid =
            BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);

        if (!isValid)
        {
            ModelState.AddModelError("", "Invalid credentials");
            return View(model);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("CanEditTask", user.CanEditTask.ToString().ToLower())
        };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        return RedirectToAction("TaskList", "User");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login");
    }

    public IActionResult AccessDenied()
    {
        return Content("Access Denied");
    }
}