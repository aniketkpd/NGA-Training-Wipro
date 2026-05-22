using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace SmartInventoryAPI_RoutingDemo.Controllers
{
    // this controller will help us in demonstrating conventional outing in ASP.NET Core. It will have two action methods: Index and Reports.
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Welcome to Smart Inventory API Routing Demo!"); // This line returns a simple string message as the response content when the Index action is accessed.
        }

        //reports action method to demonstrate routing
        public IActionResult Reports()
        {
            return Content("This is the Reports page of Smart Inventory API Routing Demo!"); // This line returns a simple string message as the response content when the Reports action is accessed.
        }
    }
}