using Microsoft.AspNetCore.Mvc;
using StudentRepositoryDemo.Models;
using StudentRepositoryDemo.Repository;

namespace StudentRepositoryDemo.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepository _repository;

    public StudentController(IStudentRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var students = _repository.GetAllStudents();
        return View(students);
    }

    public IActionResult Details(int id)
    {
        var student = _repository.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            _repository.AddStudent(student);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    public IActionResult Edit(int id)
    {
        var student = _repository.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Student student)
    {
        if (id != student.StudentId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _repository.UpdateStudent(student);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    public IActionResult Delete(int id)
    {
        var student = _repository.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repository.DeleteStudent(id);
        _repository.Save();
        return RedirectToAction(nameof(Index));
    }
}
