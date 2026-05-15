using System.Security.Cryptography;
using System.Text;
using SecureJwtApi.Data.Entities;

namespace SecureJwtApi.Services.Security;

public sealed class HmacIntegrityService : IHmacIntegrityService
{
    private readonly byte[] _key;

    public HmacIntegrityService(IConfiguration configuration)
    {
        var keyBase64 = configuration["DataProtection:HmacKeyBase64"];
        if (string.IsNullOrWhiteSpace(keyBase64))
        {
            var devKey = configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("Configure Jwt:Key or DataProtection:HmacKeyBase64.");
            _key = SHA256.HashData(Encoding.UTF8.GetBytes("HMAC-" + devKey));
        }
        else
        {
            _key = Convert.FromBase64String(keyBase64);
        }
    }

    public string ComputeHmac(string username, string? emailPlain, string? fullNamePlain, string? financialPlain)
    {
        var canonical = BuildCanonical(username, emailPlain, fullNamePlain, financialPlain);
        var hash = HMACSHA256.HashData(_key, Encoding.UTF8.GetBytes(canonical));
        return Convert.ToBase64String(hash);
    }

    public bool VerifyIntegrity(ApplicationUser user, string? emailPlain, string? fullNamePlain, string? financialPlain)
    {
        if (string.IsNullOrEmpty(user.DataIntegrityHmac))
            return false;

        var expected = ComputeHmac(user.Username, emailPlain, fullNamePlain, financialPlain);
        var actualBytes = Convert.FromBase64String(user.DataIntegrityHmac);
        var expectedBytes = Convert.FromBase64String(expected);
        return CryptographicOperations.FixedTimeEquals(actualBytes, expectedBytes);
    }

    private static string BuildCanonical(string username, string? email, string? fullName, string? financial) =>
        $"{username}|{email ?? ""}|{fullName ?? ""}|{financial ?? ""}";
}
