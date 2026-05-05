using Microsoft.AspNetCore.Mvc;

namespace MVCAssignment2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
