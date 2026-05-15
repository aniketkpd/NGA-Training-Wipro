using System.Security.Cryptography;
using System.Text;

namespace SecureJwtApi.Services.Security;

public sealed class EncryptionService : IEncryptionService
{
    private readonly byte[] _key;

    public EncryptionService(IConfiguration configuration)
    {
        var keyBase64 = configuration["DataProtection:EncryptionKeyBase64"];
        if (string.IsNullOrWhiteSpace(keyBase64))
        {
            var devKey = configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("Configure Jwt:Key or DataProtection:EncryptionKeyBase64.");
            _key = SHA256.HashData(Encoding.UTF8.GetBytes(devKey));
        }
        else
        {
            _key = Convert.FromBase64String(keyBase64);
            if (_key.Length != 32)
                throw new InvalidOperationException("Encryption key must be 32 bytes (256-bit), Base64-encoded.");
        }
    }

    public string Encrypt(string plainText)
    {
        var nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
        RandomNumberGenerator.Fill(nonce);

        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        var cipherBytes = new byte[plainBytes.Length];
        var tag = new byte[AesGcm.TagByteSizes.MaxSize];

        using var aes = new AesGcm(_key, AesGcm.TagByteSizes.MaxSize);
        aes.Encrypt(nonce, plainBytes, cipherBytes, tag);

        var payload = new byte[nonce.Length + tag.Length + cipherBytes.Length];
        Buffer.BlockCopy(nonce, 0, payload, 0, nonce.Length);
        Buffer.BlockCopy(tag, 0, payload, nonce.Length, tag.Length);
        Buffer.BlockCopy(cipherBytes, 0, payload, nonce.Length + tag.Length, cipherBytes.Length);

        return Convert.ToBase64String(payload);
    }

    public string Decrypt(string cipherText)
    {
        var payload = Convert.FromBase64String(cipherText);
        var nonceSize = AesGcm.NonceByteSizes.MaxSize;
        var tagSize = AesGcm.TagByteSizes.MaxSize;

        var nonce = payload.AsSpan(0, nonceSize);
        var tag = payload.AsSpan(nonceSize, tagSize);
        var cipherBytes = payload.AsSpan(nonceSize + tagSize);

        var plainBytes = new byte[cipherBytes.Length];
        using var aes = new AesGcm(_key, tagSize);
        aes.Decrypt(nonce, cipherBytes, tag, plainBytes);

        return Encoding.UTF8.GetString(plainBytes);
    }
}
