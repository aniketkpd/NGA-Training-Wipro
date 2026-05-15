using Microsoft.EntityFrameworkCore;
using SecureJwtApi.Data.Entities;
using SecureJwtApi.Services.Security;

namespace SecureJwtApi.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasherService>();
        var encryption = scope.ServiceProvider.GetRequiredService<IEncryptionService>();
        var hmac = scope.ServiceProvider.GetRequiredService<IHmacIntegrityService>();

        await db.Database.MigrateAsync();

        if (await db.Users.AnyAsync())
            return;

        await SeedUserAsync(db, passwordHasher, encryption, hmac,
            "admin", "Admin@123", "Admin",
            "admin@secureapi.local", "System Administrator", "****-****-****-1001");

        await SeedUserAsync(db, passwordHasher, encryption, hmac,
            "user", "User@123", "User",
            "user@secureapi.local", "Standard User", "****-****-****-2002");
    }

    private static async Task SeedUserAsync(
        ApplicationDbContext db,
        IPasswordHasherService passwordHasher,
        IEncryptionService encryption,
        IHmacIntegrityService hmac,
        string username,
        string password,
        string role,
        string email,
        string fullName,
        string financial)
    {
        var user = new ApplicationUser
        {
            Username = username,
            PasswordHash = passwordHasher.HashPassword(password),
            Role = role,
            EmailEncrypted = encryption.Encrypt(email),
            FullNameEncrypted = encryption.Encrypt(fullName),
            FinancialAccountEncrypted = encryption.Encrypt(financial),
            CreatedAtUtc = DateTime.UtcNow,
            IsActive = true
        };

        user.DataIntegrityHmac = hmac.ComputeHmac(username, email, fullName, financial);
        db.Users.Add(user);
        await db.SaveChangesAsync();
    }
}
