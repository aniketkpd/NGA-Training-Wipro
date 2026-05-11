using Microsoft.Data.SqlClient;
using System;



class table_show_data
{
    public static void Main(string[] args)
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=adodotnet;Trusted_Connection=True; TrustServerCertificate=True;";

        using SqlConnection con = new SqlConnection(connectionString);

        con.Open();

        string query = "SELECT * FROM Employees";

        SqlCommand cmd = new SqlCommand(query, con);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                "Id: " + reader["Id"] +
                ", Name: " + reader["Name"] +
                ", Age: " + reader["Age"]);
        }

        reader.Close();

        con.Close();
    }
}