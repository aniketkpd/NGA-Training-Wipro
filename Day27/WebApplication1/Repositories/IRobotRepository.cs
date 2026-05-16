using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IRobotRepository
    {
        Task<IEnumerable<RobotModel>> GetAllAsync();

        Task<RobotModel?> GetByIdAsync(int id);

        Task AddAsync(RobotModel robot);

        Task UpdateAsync(RobotModel robot);

        Task DeleteAsync(int id);
    }
}