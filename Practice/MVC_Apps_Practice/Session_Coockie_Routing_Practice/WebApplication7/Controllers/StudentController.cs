using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{

    //Attribute routing && Routing Constraints

    //[Route("mypage")]
    public class StudentController : Controller
    {

        //[Route("std/{name:int}")]
        public IActionResult greet(string name)
        {
            return Content($"Hello {name}");
        }
    }
}
