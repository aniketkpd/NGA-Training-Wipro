
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;

public class StudentModelsController : Controller
{
    private readonly AppDbContext _context;

    public StudentModelsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: STUDENTMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.StudentModels.ToListAsync());
    }

    // GET: STUDENTMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentmodel = await _context.StudentModels
            .FirstOrDefaultAsync(m => m.Id == id);
        if (studentmodel == null)
        {
            return NotFound();
        }

        return View(studentmodel);
    }

    // GET: STUDENTMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: STUDENTMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Age")] StudentModel studentmodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(studentmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(studentmodel);
    }

    // GET: STUDENTMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentmodel = await _context.StudentModels.FindAsync(id);
        if (studentmodel == null)
        {
            return NotFound();
        }
        return View(studentmodel);
    }

    // POST: STUDENTMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Age")] StudentModel studentmodel)
    {
        if (id != studentmodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(studentmodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(studentmodel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(studentmodel);
    }

    // GET: STUDENTMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentmodel = await _context.StudentModels
            .FirstOrDefaultAsync(m => m.Id == id);
        if (studentmodel == null)
        {
            return NotFound();
        }

        return View(studentmodel);
    }

    // POST: STUDENTMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var studentmodel = await _context.StudentModels.FindAsync(id);
        if (studentmodel != null)
        {
            _context.StudentModels.Remove(studentmodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentModelExists(int? id)
    {
        return _context.StudentModels.Any(e => e.Id == id);
    }
}
