using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    public IActionResult ManageTasks()
    {
        return View();
    }
}