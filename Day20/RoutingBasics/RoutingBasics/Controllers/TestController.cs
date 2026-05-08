using Microsoft.AspNetCore.Mvc;
using System;
namespace RoutingBasics.Controllers
{
    public class TestController : Controller
    {
        public IActionResult greet()
        {

            //This can send message directly to the browswer without the need for a view.
            return Content("Hello Cosmos!");
        }



        public IActionResult greetwithname(string name)
        {

            //Search here https://localhost:7264/Test/greetwithname?name=aniketkpd
            return Content($"Hello {name}!");
        }



        //This is attribute routing. We can specify the route directly on the action method.
        //Search here https://localhost:7264/SayHello
        [Route("SayHello")]
        public IActionResult SayHello()
        {
            return Content("Hello from attribute routing!");
        }



        // Attribute Route with Parameter
        //Search here https://localhost:7264/Welcome/John
        [Route("Welcome/{name}")]
        public IActionResult Welcome(string name)
        {
            return Content($"Welcome, {name}!");
        }



        //Routing Constraint - int
        [Route("Product/{id:int}")]
        public IActionResult ShowProduct(int id)
        {
            return Content($"Product ID: {id}");
        }


    }
}
