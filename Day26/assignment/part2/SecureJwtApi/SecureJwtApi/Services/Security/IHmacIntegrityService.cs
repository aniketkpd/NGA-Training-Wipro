using SecureJwtApi.Data.Entities;

namespace SecureJwtApi.Services.Security;

public interface IHmacIntegrityService
{
    string ComputeHmac(string username, string? emailPlain, string? fullNamePlain, string? financialPlain);

    bool VerifyIntegrity(ApplicationUser user, string? emailPlain, string? fullNamePlain, string? financialPlain);
}
