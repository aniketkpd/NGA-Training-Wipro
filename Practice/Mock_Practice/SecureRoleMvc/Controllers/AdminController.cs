using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureRoleMvc.Models;

namespace SecureRoleMvc.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController(
    UserManager<IdentityUser> userManager,
    IDataProtectionProvider dataProtectionProvider) : Controller
{
    public async Task<IActionResult> Dashboard()
    {
        var protector = dataProtectionProvider.CreateProtector("AdminDashboard.UserIds");
        var users = new List<AdminUserViewModel>();

        foreach (var user in userManager.Users.OrderBy(user => user.UserName))
        {
            var roles = await userManager.GetRolesAsync(user);
            users.Add(new AdminUserViewModel
            {
                UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                Roles = string.Join(", ", roles),
                ProtectedUserId = protector.Protect(user.Id)
            });
        }

        return View(users);
    }
}
