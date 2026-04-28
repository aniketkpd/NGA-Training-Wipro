using System;
using Microsoft.Data.SqlClient;

namespace CompanyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                new SqlCommand("IF DB_ID('CompanyDB') IS NULL CREATE DATABASE CompanyDB", conn).ExecuteNonQuery();

                conn.ChangeDatabase("CompanyDB");

                string createTable = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employees' AND xtype='U')
                    CREATE TABLE Employees
                    (
                        Id INT PRIMARY KEY,
                        Name VARCHAR(50),
                        Age INT,
                        City VARCHAR(50)
                    )";
                new SqlCommand(createTable, conn).ExecuteNonQuery();

                string insertData = @"
                    IF NOT EXISTS (SELECT 1 FROM Employees)
                    BEGIN
                        INSERT INTO Employees (Id, Name, Age, City) VALUES (1, 'Amit Sharma', 25, 'Delhi');
                        INSERT INTO Employees (Id, Name, Age, City) VALUES (2, 'Neha Verma', 22, 'Mumbai');
                        INSERT INTO Employees (Id, Name, Age, City) VALUES (3, 'Rahul Singh', 28, 'Bangalore');
                        INSERT INTO Employees (Id, Name, Age, City) VALUES (4, 'Priya Mehta', 24, 'Pune');
                        INSERT INTO Employees (Id, Name, Age, City) VALUES (5, 'Karan Gupta', 21, 'Chennai');
                    END";
                new SqlCommand(insertData, conn).ExecuteNonQuery();

                string query = "SELECT * FROM Employees WHERE Age > 23";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Employees with Age > 23:\n");

                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}, City: {reader["City"]}");
                    }
                }

                conn.Close();
            }

            Console.ReadLine();
        }
    }
}