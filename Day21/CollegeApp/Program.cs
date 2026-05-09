using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        //string conString = @"Server=localhost\SQLEXPRESS;Database=NFSDB;Trusted_Connection=True;TrustServerCertificate=True";
        string conString = @"Server=localhost\SQLEXPRESS;Database=NFSDB;Trusted_Connection=True;TrustServerCertificate=True;";
        SqlConnection con = new SqlConnection(conString);

        con.Open();
        Console.WriteLine("Connected to database");

        // Perform database operations here

        //Insert a new student record
        string query = "INSERT INTO Students(Name,Age) VALUES(@name,@age)";

        SqlCommand cmd = new SqlCommand(query, con);


        Console.WriteLine();

        Console.Write("Enter name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());



        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@age", age);

        cmd.ExecuteNonQuery();



        Console.Write("Data inserted, enter to retrive names: ");
        Console.ReadLine();



        // Retrieve and display all student records
        query = "SELECT * FROM Students";

        cmd = new SqlCommand(query, con);

        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            Console.WriteLine(dr["Name"]);
        }
        dr.Close();





        Console.Write("Data retrived, enter to delete data from table: ");
        Console.ReadLine();

        query = "TRUNCATE TABLE Students";
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Data deleted from table");










        con.Close();
        Console.WriteLine("Connection closed.");

        Console.ReadLine();
    }
}