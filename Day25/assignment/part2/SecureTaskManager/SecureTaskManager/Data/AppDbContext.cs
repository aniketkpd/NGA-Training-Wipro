using Microsoft.EntityFrameworkCore;
using SecureTaskManager.Models;

namespace SecureTaskManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> Users => Set<AppUser>();

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}