using System;
using Microsoft.Data.SqlClient;

class Test
{
    static void Main()
    {
        string cs = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

        using (SqlConnection conn = new SqlConnection(cs))
        {
            conn.Open();
            Console.WriteLine("Connected!");
        }
    }
}