
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_via_Scaffold_Code_First.Models;
using CRUD_via_Scaffold_Code_First.Data;

public class CollegeModelController : Controller
{
    private readonly AppDbContext _context;

    public CollegeModelController(AppDbContext context)
    {
        _context = context;
    }

    // GET: COLLEGEMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Students.ToListAsync());
    }

    // GET: COLLEGEMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var collegemodel = await _context.Students
            .FirstOrDefaultAsync(m => m.Id == id);
        if (collegemodel == null)
        {
            return NotFound();
        }

        return View(collegemodel);
    }

    // GET: COLLEGEMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: COLLEGEMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Age,Address")] CollegeModel collegemodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(collegemodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(collegemodel);
    }

    // GET: COLLEGEMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var collegemodel = await _context.Students.FindAsync(id);
        if (collegemodel == null)
        {
            return NotFound();
        }
        return View(collegemodel);
    }

    // POST: COLLEGEMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Age,Address")] CollegeModel collegemodel)
    {
        if (id != collegemodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(collegemodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeModelExists(collegemodel.Id))
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
        return View(collegemodel);
    }

    // GET: COLLEGEMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var collegemodel = await _context.Students
            .FirstOrDefaultAsync(m => m.Id == id);
        if (collegemodel == null)
        {
            return NotFound();
        }

        return View(collegemodel);
    }

    // POST: COLLEGEMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var collegemodel = await _context.Students.FindAsync(id);
        if (collegemodel != null)
        {
            _context.Students.Remove(collegemodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CollegeModelExists(int? id)
    {
        return _context.Students.Any(e => e.Id == id);
    }
}
