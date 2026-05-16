using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories;

public class RobotModelController : Controller
{
    private readonly IRobotRepository _repository;

    public RobotModelController(IRobotRepository repository)
    {
        _repository = repository;
    }

    // GET: ROBOTMODELS
    public async Task<IActionResult> Index()
    {
        return View(await _repository.GetAllAsync());
    }

    // GET: ROBOTMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var robotmodel = await _repository.GetByIdAsync(id.Value);

        if (robotmodel == null)
        {
            return NotFound();
        }

        return View(robotmodel);
    }

    // GET: ROBOTMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ROBOTMODELS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Type")] RobotModel robotmodel)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddAsync(robotmodel);
            return RedirectToAction(nameof(Index));
        }

        return View(robotmodel);
    }

    // GET: ROBOTMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var robotmodel = await _repository.GetByIdAsync(id.Value);

        if (robotmodel == null)
        {
            return NotFound();
        }

        return View(robotmodel);
    }

    // POST: ROBOTMODELS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Type")] RobotModel robotmodel)
    {
        if (id != robotmodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _repository.UpdateAsync(robotmodel);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(robotmodel);
    }

    // GET: ROBOTMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var robotmodel = await _repository.GetByIdAsync(id.Value);

        if (robotmodel == null)
        {
            return NotFound();
        }

        return View(robotmodel);
    }

    // POST: ROBOTMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id != null)
        {
            await _repository.DeleteAsync(id.Value);
        }

        return RedirectToAction(nameof(Index));
    }
}