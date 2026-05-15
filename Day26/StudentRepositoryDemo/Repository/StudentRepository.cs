using StudentRepositoryDemo.Data;
using StudentRepositoryDemo.Models;

namespace StudentRepositoryDemo.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _context.Students.ToList();
    }

    public Student? GetStudentById(int id)
    {
        return _context.Students.Find(id);
    }

    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
    }

    public void UpdateStudent(Student student)
    {
        _context.Students.Update(student);
    }

    public void DeleteStudent(int id)
    {
        var student = _context.Students.Find(id);

        if (student != null)
        {
            _context.Students.Remove(student);
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
