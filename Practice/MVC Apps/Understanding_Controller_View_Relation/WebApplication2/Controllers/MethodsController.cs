using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class MethodsController : Controller
    {
        // Concept : every method points to a view with the same name as the method
        public IActionResult Method1() { return View(); }
        public IActionResult Method2() { return View(); }
        public IActionResult Method3() { return View(); }


        //this will return the view of method 5 when method 4 is called and vice versa
        public IActionResult Method4() { return View("Method5"); }
        public IActionResult Method5() { return View("Method4"); }
    }
}
