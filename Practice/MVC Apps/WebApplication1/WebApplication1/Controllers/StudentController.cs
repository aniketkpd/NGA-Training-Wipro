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
                Age = 0
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Index(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                // Process the valid student data (e.g., save to database)
                ViewBag.Message = $"Student Name: {student.Name} with age : {student.Age} has been submitted successfully.";
                return View(student);
            }
            else
            {
                // If the model is invalid, return the view with validation errors
                return View(student);
            }
        }



    }
}
