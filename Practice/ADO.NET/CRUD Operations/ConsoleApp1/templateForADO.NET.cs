// A general template to connect to a SQL Server database using ADO.NET in C#.
using System;
using Microsoft.Data.SqlClient;


public class templateOfAdoNet
{
    public static void Main(string[] args)
    {
        // adding connection string to connect to the database
        string constring = "Server=localhost\\SQLEXPRESS;Database=NFSDB;Trusted_Connection=True; TrustServerCertificate=True;";




        // creating a connection to the database
        SqlConnection con = new SqlConnection(constring);



        try
        {
            // opening the connection
            con.Open();
            Console.WriteLine("Connection opened successfully!");
            // your database operations go here
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            // closing the connection
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
                Console.WriteLine("Connection closed.");
            }
        }
    }
}