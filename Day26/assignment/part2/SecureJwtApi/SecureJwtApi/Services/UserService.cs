using Microsoft.EntityFrameworkCore;
using SecureJwtApi.Data;
using SecureJwtApi.Data.Entities;
using SecureJwtApi.Models;
using SecureJwtApi.Services.Security;

namespace SecureJwtApi.Services;

public class UserService
{
    private readonly ApplicationDbContext _db;
    private readonly IPasswordHasherService _passwordHasher;
    private readonly IEncryptionService _encryption;
    private readonly IHmacIntegrityService _hmac;
    private readonly ISecurityAuditService _audit;

    public UserService(
        ApplicationDbContext db,
        IPasswordHasherService passwordHasher,
        IEncryptionService encryption,
        IHmacIntegrityService hmac,
        ISecurityAuditService audit)
    {
        _db = db;
        _passwordHasher = passwordHasher;
        _encryption = encryption;
        _hmac = hmac;
        _audit = audit;
    }

    public async Task<(bool Success, string? Error)> RegisterAsync(RegisterModel model, HttpContext httpContext)
    {
        if (await _db.Users.AnyAsync(u => u.Username == model.Username))
        {
            await _audit.LogAsync("Register", false, model.Username, httpContext, "Username already exists");
            return (false, "Username already exists");
        }

        var user = new ApplicationUser
        {
            Username = model.Username,
            PasswordHash = _passwordHasher.HashPassword(model.Password),
            Role = "User",
            EmailEncrypted = _encryption.Encrypt(model.Email),
            FullNameEncrypted = _encryption.Encrypt(model.FullName),
            FinancialAccountEncrypted = string.IsNullOrWhiteSpace(model.FinancialAccount)
                ? null
                : _encryption.Encrypt(model.FinancialAccount),
            CreatedAtUtc = DateTime.UtcNow,
            IsActive = true
        };

        user.DataIntegrityHmac = _hmac.ComputeHmac(user.Username, model.Email, model.FullName, model.FinancialAccount);

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        await _audit.LogAsync("Register", true, user.Username, httpContext, "User registered");

        return (true, null);
    }

    public async Task<ApplicationUser?> ValidateLoginAsync(string username, string password)
    {
        var user = await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);

        if (user is null || !_passwordHasher.VerifyPassword(password, user.PasswordHash))
            return null;

        return user;
    }

    public async Task<UserProfileDto?> GetProfileAsync(string username)
    {
        var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
        if (user is null)
            return null;

        var email = user.EmailEncrypted is null ? null : _encryption.Decrypt(user.EmailEncrypted);
        var fullName = user.FullNameEncrypted is null ? null : _encryption.Decrypt(user.FullNameEncrypted);
        var financial = user.FinancialAccountEncrypted is null
            ? null
            : _encryption.Decrypt(user.FinancialAccountEncrypted);

        return new UserProfileDto
        {
            Username = user.Username,
            Role = user.Role,
            Email = email,
            FullName = fullName,
            FinancialAccountMasked = MaskFinancial(financial),
            IntegrityValid = _hmac.VerifyIntegrity(user, email, fullName, financial)
        };
    }

    public async Task<IReadOnlyList<UserSummaryDto>> ListUsersForAdminAsync()
    {
        return await _db.Users
            .AsNoTracking()
            .OrderBy(u => u.Username)
            .Select(u => new UserSummaryDto
            {
                Id = u.Id,
                Username = u.Username,
                Role = u.Role,
                IsActive = u.IsActive,
                CreatedAtUtc = u.CreatedAtUtc
            })
            .ToListAsync();
    }

    public async Task<IReadOnlyList<AuditLogDto>> GetRecentAuditLogsAsync(int take = 50)
    {
        return await _db.SecurityAuditLogs
            .AsNoTracking()
            .OrderByDescending(l => l.TimestampUtc)
            .Take(take)
            .Select(l => new AuditLogDto
            {
                EventType = l.EventType,
                Username = l.Username,
                Success = l.Success,
                TimestampUtc = l.TimestampUtc
            })
            .ToListAsync();
    }

    private static string? MaskFinancial(string? account)
    {
        if (string.IsNullOrEmpty(account) || account.Length <= 4)
            return "****";

        return new string('*', account.Length - 4) + account[^4..];
    }
}
