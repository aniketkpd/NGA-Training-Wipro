using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Day10
{
    class ScenarioOnHashing_v2
    {
        static string filePath = @"users.txt";



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
            try
            {
                Console.Write("Enter username to register: ");
                string username = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Username cannot be empty.");
                    return;
                }

                if (File.Exists(filePath))
                {
                    string[] users = File.ReadAllLines(filePath);

                    foreach (string user in users)
                    {
                        string[] parts = user.Split('|');

                        if (parts.Length == 3 && parts[0] == username)
                        {
                            Console.WriteLine("Username already exists. Please choose another username.");
                            return;
                        }
                    }
                }

                Console.Write("Enter password to register: ");
                string password = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Password cannot be empty.");
                    return;
                }

                Console.Write("Enter role (Admin/User): ");
                string role = Console.ReadLine() ?? "";

                if (role != "Admin" && role != "User")
                {
                    Console.WriteLine("Invalid role. Please enter Admin or User.");
                    return;
                }

                string hashed = HashPassword(password);
                string userRecord = username + "|" + role + "|" + hashed;

                File.AppendAllText(filePath, userRecord + Environment.NewLine);
                Console.WriteLine("User registered successfully with hashed password.");
            }
            catch
            {
                Console.WriteLine("Something went wrong while registering.");
            }
        }









        static void Login()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No users registered yet. Please register first.");
                    return;
                }

                Console.Write("Enter username to login: ");
                string username = Console.ReadLine() ?? "";

                Console.Write("Enter password to login: ");
                string input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Username and password are required.");
                    return;
                }

                string inputHash = HashPassword(input);
                string[] users = File.ReadAllLines(filePath);

                foreach (string user in users)
                {
                    string[] parts = user.Split('|');

                    if (parts.Length == 3 && parts[0] == username && parts[2] == inputHash)
                    {
                        string role = parts[1];

                        Console.WriteLine("Login successful");
                        ShowRoleBasedAccess(role);
                        return;
                    }
                }

                Console.WriteLine("Login failed. Invalid username or password.");
            }
            catch
            {
                Console.WriteLine("Something went wrong while logging in.");
            }
        }

        static void ShowRoleBasedAccess(string role)
        {
            if (role == "Admin")
            {
                Console.WriteLine("Admin Access Granted");
                Console.WriteLine("1. Manage users");
                Console.WriteLine("2. View reports");
                Console.WriteLine("3. Change system settings");
            }
            else if (role == "User")
            {
                Console.WriteLine("User Access Granted");
                Console.WriteLine("1. View profile");
                Console.WriteLine("2. Update password");
            }
            else
            {
                Console.WriteLine("Access denied. Unknown role.");
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

                string choice = Console.ReadLine() ?? "";

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
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                        break;
                }
            }
        }
    }
}
