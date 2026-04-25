using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecureAuthDemo
{
    class Program
    {
        static string filePath = "C:\\Users\\Aniket\\source\\repos\\NGA Training Wipro\\Day10\\user.txt";

        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }




        static void Register()
        {
            Console.Write("Enter password to register: ");
            string? password = Console.ReadLine();

            string hashed = HashPassword(password);

            File.WriteAllText(filePath, hashed);

            Console.WriteLine("Password stored securely (hashed).");
        }




        static void Login()
        {

            Console.Write("Enter password to login: ");
            string? input = Console.ReadLine();

            string storedHash = File.ReadAllText(filePath);
            string inputHash = HashPassword(input);

            if (storedHash == inputHash)
            {
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Login failed");
            }
        }






        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choose option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        Login();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}