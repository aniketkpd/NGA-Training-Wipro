using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            StudentModel model = new StudentModel
            { 
                Name = "John Doe",
                Age = 20    
            };



            return View(model);
        }



        [HttpPost]
        public IActionResult Index(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the data here
                ViewBag.Message =  $"Name:{model.Name}, Age: {model.Age} is submitted to server.";
            }

            return View(model);
        }
    

    }
}
