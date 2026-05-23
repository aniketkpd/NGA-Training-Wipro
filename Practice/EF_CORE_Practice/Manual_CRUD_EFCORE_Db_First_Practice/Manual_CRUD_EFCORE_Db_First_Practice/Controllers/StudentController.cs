using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manual_CRUD_EFCORE_Db_First_Practice.Models;

namespace Manual_CRUD_EFCORE_Db_First_Practice.Controllers;



public class StudentController : Controller
{

    //Dependency Injection
    private readonly MyStudentDbContext _context;
    public StudentController(MyStudentDbContext context)
    {
        _context = context;
    }






    //READ all records from table and show it to user
    public IActionResult Index()
    {
        var data = _context.Students.ToList();
        return View(data);
    }



    // CREATE
    [HttpPost]
    public IActionResult Create(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }



    //DELETE
    public IActionResult Delete(int id)
    {
        var data = _context.Students.Find(id);

        if (data != null)
        { 
            _context.Students.Remove(data);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }


    //Update
    [HttpPost]
    public IActionResult Update(Student student)
    {
        _context.Students.Update(student);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }



    //Edit
    public IActionResult Edit(int id)
    {
        var data = _context.Students.Find(id);
        return View(data);
    }




}

