using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index page opened");

            return Content("Home Page");
        }

        public IActionResult About()
        {
            _logger.LogWarning("About page opened");

            return Content("About Page");
        }

        public IActionResult ErrorDemo()
        {
            _logger.LogError("Fake error generated");

            return Content("Error Logged");
        }
    }
}


// /Home/Index
// /Home/About
// /Home/ErrorDemo