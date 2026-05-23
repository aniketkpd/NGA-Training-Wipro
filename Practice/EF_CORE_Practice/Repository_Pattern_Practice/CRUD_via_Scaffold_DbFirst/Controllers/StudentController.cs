
using CRUD_via_Scaffold_DbFirst.Models;
using CRUD_via_Scaffold_DbFirst.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class StudentController : Controller
{
    //private readonly MyCollegeDbContext _context;
    private readonly IStudentRepository _repository;

    //public StudentController(MyCollegeDbContext context)
    //{
    //    _context = context;
    //}

    public StudentController(IStudentRepository repository)
    {
        _repository = repository;
    }

    // GET: STUDENTS
    public async Task<IActionResult> Index()    
    {
        //return View(await _context.Students.ToListAsync());
        return View(await _repository.GetAllAsync());
    }

    // GET: STUDENTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        //var student = await _context.Students
        //    .FirstOrDefaultAsync(m => m.Id == id);

        var student = await _repository.GetByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // GET: STUDENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: STUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Age,Address")] Student student)
    {
        if (ModelState.IsValid)
        {
            //_context.Add(student);
            //await _context.SaveChangesAsync();
            await _repository.AddAsync(student);
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }

    // GET: STUDENTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        //var student = await _context.Students.FindAsync(id);
        var student = await _repository.GetByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // POST: STUDENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Age,Address")] Student student)
    {
        if (id != student.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                //_context.Update(student);
                //await _context.SaveChangesAsync();
                await _repository.UpdateAsync(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.Id))
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
        return View(student);
    }

    // GET: STUDENTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        //var student = await _context.Students
        //    .FirstOrDefaultAsync(m => m.Id == id);
        var student = await _repository.GetByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // POST: STUDENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        //var student = await _context.Students.FindAsync(id);
        //if (student != null)
        //{
        //    _context.Students.Remove(student);
        //}

        //await _context.SaveChangesAsync();

        await _repository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private bool StudentExists(int? id)
    {
        //return _context.Students.Any(e => e.Id == id);
        return _repository.StudentExists(id);
    }
}
