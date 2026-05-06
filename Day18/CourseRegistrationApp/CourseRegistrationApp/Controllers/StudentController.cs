using CourseRegistrationApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationApp.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Message = "Student registered successfully!";
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}