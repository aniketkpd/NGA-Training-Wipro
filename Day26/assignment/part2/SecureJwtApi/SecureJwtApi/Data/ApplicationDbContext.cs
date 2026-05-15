using Microsoft.EntityFrameworkCore;
using SecureJwtApi.Data.Entities;

namespace SecureJwtApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();

    public DbSet<SecurityAuditLog> SecurityAuditLogs => Set<SecurityAuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasIndex(u => u.Username).IsUnique();
            entity.Property(u => u.Username).HasMaxLength(64).IsRequired();
            entity.Property(u => u.PasswordHash).HasMaxLength(256).IsRequired();
            entity.Property(u => u.Role).HasMaxLength(32).IsRequired();
            entity.Property(u => u.EmailEncrypted).HasMaxLength(512);
            entity.Property(u => u.FullNameEncrypted).HasMaxLength(512);
            entity.Property(u => u.FinancialAccountEncrypted).HasMaxLength(512);
            entity.Property(u => u.DataIntegrityHmac).HasMaxLength(128);
        });

        modelBuilder.Entity<SecurityAuditLog>(entity =>
        {
            entity.Property(l => l.EventType).HasMaxLength(64).IsRequired();
            entity.Property(l => l.Username).HasMaxLength(64);
            entity.Property(l => l.IpAddress).HasMaxLength(45);
            entity.Property(l => l.Details).HasMaxLength(500);
            entity.HasIndex(l => l.TimestampUtc);
        });
    }
}
