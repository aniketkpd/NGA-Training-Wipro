using System;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography; //gives you SHA256
using System.Text;                  //used to convert text into bytes

namespace Day10
{
    class UseOfHash256
    {

        // This method takes a password string and returns a hashed string.
        public static string HashPassword(string password)
        {
            using (SHA256 sha1 = SHA256.Create())       //Creates a SHA-256 hashing object
            {

                // Converts the password string into bytes because SHA256 works on bytes, not text
                var bytes = Encoding.UTF8.GetBytes(password);

                //Applies SHA-256 algorithm returns a hashed byte array
                var hash = sha1.ComputeHash(bytes);

                //Converts hash into a readable string (Base64 format)
                return Convert.ToBase64String(hash);
            }
        }


        public static void Main(string[] args)
        {
            string Hashvalue = HashPassword("password123");
            Console.WriteLine(Hashvalue);
        }
    }
}



/*
SHA - 256(Secure Hash Algorithm 256 - bit) is a cryptographic function that turns any input (text, file, password) into a fixed-size 256-bit hash.

Key features
Fixed length → always 256 bits (32 bytes)
One-way → you can’t get the original input back
Deterministic → same input → same output
Avalanche effect → small change → completely different hash

*/