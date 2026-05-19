using CRUD_via_Scaffold_DbFirst.Models;

namespace CRUD_via_Scaffold_DbFirst.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int? id);

        Task AddAsync(Student student);

        Task UpdateAsync(Student student);

        Task DeleteAsync(int? id);

        bool StudentExists(int? id);
    }
}