using CRUD_via_Scaffold_Code_First.Data;
using Microsoft.EntityFrameworkCore;
using CRUD_via_Scaffold_Code_First.Models;

namespace CRUD_via_Scaffold_Code_First.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CollegeModel> Students { get; set; }
    }
}
