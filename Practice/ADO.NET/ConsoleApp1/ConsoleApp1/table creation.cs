// Creating table using ADO.NET in C#


using System;
using Microsoft.Data.SqlClient;




namespace ConsoleApp1
{
    class table_creation
    {
        static void Main(string[] args)
        {
            // creatig connection string to connect to the database
            string constring = "Server=localhost\\SQLEXPRESS;Database=adodotnet;Trusted_Connection=True; TrustServerCertificate=True;";


            // creating a connection to the database
            SqlConnection con = new SqlConnection(constring);


            // opening the connection
            con.Open();
            Console.WriteLine("Connection opened successfully!");

            //Execute your database operations here

            // creating a table in the database
            string createTableQuery = "CREATE TABLE Employees (Id INT PRIMARY KEY, Name NVARCHAR(50), Age INT)";


            // creating a SqlCommand object to execute the query
            SqlCommand createTableCmd = new SqlCommand(createTableQuery, con);


            // executing the query
            createTableCmd.ExecuteNonQuery();
            Console.WriteLine("Table created successfully!");


            con.Close();
            Console.WriteLine("Connection closed successfully!");
        }
    }
}