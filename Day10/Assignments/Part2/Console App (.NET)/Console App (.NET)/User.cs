using System;
using System.Security.Cryptography;
using System.Text;

public class User
{
    public string Username { get; set; }
    public string HashedPassword { get; set; }

    // Register user
    public static User Register(string username, string password)
    {
        try
        {
            string hashed = HashPassword(password);
            return new User
            {
                Username = username,
                HashedPassword = hashed
            };
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message);
            throw;
        }
    }

    // Authenticate user
    public bool Authenticate(string password)
    {
        try
        {
            string hashed = HashPassword(password);
            return hashed == HashedPassword;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message);
            return false;
        }
    }

    // SHA-256 hashing
    public static string HashPassword(string password)
    {
        using (SHA256 sha = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}