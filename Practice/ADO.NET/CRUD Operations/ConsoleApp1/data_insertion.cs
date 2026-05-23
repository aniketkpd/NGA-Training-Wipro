using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsoleApp1
{
    class data_insertion
    {
        public static void Main(string[] args)
        {
            string cs = "Server=localhost\\SQLEXPRESS;Database=adodotnet;Trusted_Connection=True; TrustServerCertificate=True;";
            SqlConnection conn = new SqlConnection(cs);

            conn.Open();

            Console.WriteLine("Connection opened successfully!");

            // Insert data into Employees table
            string insertQuery = "INSERT INTO Employees (Id, Name, Age) VALUES (1, 'John Doe', 30)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.ExecuteNonQuery();


            
            Console.WriteLine("Data inserted successfully!");

            conn.Close();

        }
    }
}
