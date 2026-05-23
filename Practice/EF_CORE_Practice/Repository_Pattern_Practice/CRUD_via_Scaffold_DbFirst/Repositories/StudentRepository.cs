using CRUD_via_Scaffold_DbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_via_Scaffold_DbFirst.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyCollegeDbContext _context;

        public StudentRepository(MyCollegeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int? id)
        {
            return await _context.Students
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public bool StudentExists(int? id)
        {
            return _context.Students.Any(x => x.Id == id);
        }
    }
}