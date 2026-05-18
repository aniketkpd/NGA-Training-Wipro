using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


         


        [HttpGet] 
        public JsonResult GetStudentById(int id)
        {
            List<Student> students = new List<Student>()
            {
                new Student { Id = 1, Name = "Aniket", Course = "BCA", Age = 21 },
                new Student { Id = 2, Name = "Rahul", Course = "MCA", Age = 23 },
                new Student { Id = 3, Name = "Priya", Course = "B.Tech", Age = 22 }
            };

            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return Json(null);
            }

            return Json(student);
        }
    }
}
