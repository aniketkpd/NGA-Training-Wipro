using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class RobotRepository : IRobotRepository
    {
        private readonly AppDbContext _context;

        public RobotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RobotModel>> GetAllAsync()
        {
            return await _context.Robots.ToListAsync();
        }

        public async Task<RobotModel?> GetByIdAsync(int id)
        {
            return await _context.Robots.FindAsync(id);
        }

        public async Task AddAsync(RobotModel robot)
        {
            await _context.Robots.AddAsync(robot);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RobotModel robot)
        {
            _context.Robots.Update(robot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var robot = await _context.Robots.FindAsync(id);

            if (robot != null)
            {
                _context.Robots.Remove(robot);
                await _context.SaveChangesAsync();
            }
        }
    }
}