using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class StudentController : Controller
    {

        // Private field for dependency injection
        private readonly AppDbContext _context;


        // Constructor dependency injection
        public StudentController(AppDbContext context)
        {
            _context = context;
        }








        // Read the data from Student table
        public IActionResult Index()
        {
            var data = _context.Student.ToList();
            return View(data);
        }




        // Create a new student

        [HttpPost]
        public IActionResult Create(StudentModel st)
        {

            // adding a new student
            _context.Student.Add(st);

            // save the changes
            _context.SaveChanges();

            return RedirectToAction("Index");
        }





        //Update the student

        [HttpPost]
        public IActionResult Update(StudentModel st)
        {
            // updating the student
            _context.Student.Update(st);

            // save the changes
            _context.SaveChanges();


            return RedirectToAction("Index");
        }




        // Delete the student
        public IActionResult Delete(int id)
        {


            var data = _context.Student.Find(id);

            if (data != null)
            {
                // deleting the student
                _context.Student.Remove(data);

                // save the changes
                _context.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var data = _context.Student.Find(id);

            return View(data);
        }









    }
}
