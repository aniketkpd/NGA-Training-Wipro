using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureTaskManager.Data;

namespace SecureTaskManager.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult TaskList()
    {
        return View(_context.Tasks.ToList());
    }

    [Authorize(Policy = "CanEditTask")]
    public IActionResult EditTask()
    {
        return Content("Task Editing Allowed");
    }
}