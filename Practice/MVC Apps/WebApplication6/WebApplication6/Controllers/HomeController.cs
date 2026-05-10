using Microsoft.AspNetCore.Mvc;
using FilterDemo.Filters;
namespace FilterDemo.Controllers
{
    [MyAuthorizationFilter]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Welcome To Home Page");
        }
    }
}
