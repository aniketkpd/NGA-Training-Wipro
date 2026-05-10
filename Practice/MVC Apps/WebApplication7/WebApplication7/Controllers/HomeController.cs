using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication7.Filters; // Import the namespace for the custom action filter
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {

        //[MyActionFilter]
        //[MyAuthorizationFilter]
        //[MyResultFilter]
        public IActionResult Index()
        {
            Console.WriteLine("Inside Index Action");
            return Content("Welcome To Home Page");
        }

        [MyExceptionFilter]
        public IActionResult Privacy()
        {
            int x = 0;
            int y = 10 / x;
            return Content(y.ToString());
        }



        [MyResourceFilter]
        public IActionResult Greet()
        {
            Console.WriteLine("Inside Greet Action");
            return Content("Hello, welcome to the Greet action!");
        }
    }
}
