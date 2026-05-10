using Microsoft.AspNetCore.Mvc;
using FilterDemo.Filters;

namespace FilterDemo.Controllers
{
    [MyActionFilter]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("Inside Action");

            return Content("Home Page Opened");
        }
    }
}