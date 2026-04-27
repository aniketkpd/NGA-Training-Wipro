using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Register User");
            var user = User.Register("aniket", "1234");

            Logger.Log("User registered");

            Console.WriteLine("Login Attempt...");
            bool success = user.Authenticate("1234");

            if (success)
            {
                Logger.Log("Login successful");
                Console.WriteLine("Login Success");
            }
            else
            {
                Logger.Log("Login failed");
                Console.WriteLine("Login Failed");
            }

            // Encryption Demo
            string secret = "Sensitive Data";
            string encrypted = EncryptionHelper.Encrypt(secret);
            string decrypted = EncryptionHelper.Decrypt(encrypted);

            Console.WriteLine($"Encrypted: {encrypted}");
            Console.WriteLine($"Decrypted: {decrypted}");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message);
            Console.WriteLine("Error occurred");
        }
    }
}