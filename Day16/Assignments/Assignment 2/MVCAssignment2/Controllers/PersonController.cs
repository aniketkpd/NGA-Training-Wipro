using Microsoft.AspNetCore.Mvc;
using MVCAssignment2.Models;

namespace MVCAssignment2.Controllers;

public class PersonController : Controller
{
    public IActionResult Create()
    {
        return View(new Person());
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        return View("Result", person);
    }
}
