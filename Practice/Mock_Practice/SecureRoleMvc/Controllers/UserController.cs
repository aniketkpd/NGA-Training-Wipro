using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SecureRoleMvc.Controllers;

[Authorize(Roles = "User")]
public class UserController(UserManager<IdentityUser> userManager) : Controller
{
    public async Task<IActionResult> Profile()
    {
        var user = await userManager.GetUserAsync(User);
        ViewData["UserName"] = user?.UserName ?? User.Identity?.Name ?? "User";

        return View();
    }
}
