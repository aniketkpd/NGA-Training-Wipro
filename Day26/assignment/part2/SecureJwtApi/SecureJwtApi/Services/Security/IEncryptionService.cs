namespace SecureJwtApi.Services.Security;

/// <summary>Application-level column encryption (AES-256-GCM) for sensitive fields at rest.</summary>
public interface IEncryptionService
{
    string Encrypt(string plainText);

    string Decrypt(string cipherText);
}
