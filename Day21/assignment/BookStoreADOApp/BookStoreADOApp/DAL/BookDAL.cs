using System.Data;
using BookStoreADOApp.Models;
using Microsoft.Data.SqlClient;

namespace BookStoreADOApp.DAL
{
    public class BookDAL
    {
        private readonly string _connectionString;

        public BookDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("DefaultConnection is missing from appsettings.json.");
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Title, AuthorName, Price FROM Books ORDER BY Id";
                using SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = reader["Title"].ToString() ?? string.Empty,
                        AuthorName = reader["AuthorName"].ToString() ?? string.Empty,
                        Price = Convert.ToDecimal(reader["Price"])
                    });
                }
            }

            return books;
        }

        public void AddBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using SqlCommand cmd = new SqlCommand("sp_AddBook", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = book.Title;
                cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar, 100).Value = book.AuthorName;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = book.Price;
                cmd.Parameters["@Price"].Precision = 10;
                cmd.Parameters["@Price"].Scale = 2;

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public Book? GetBookById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Title, AuthorName, Price FROM Books WHERE Id=@Id";
                using SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                con.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Book
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = reader["Title"].ToString() ?? string.Empty,
                        AuthorName = reader["AuthorName"].ToString() ?? string.Empty,
                        Price = Convert.ToDecimal(reader["Price"])
                    };
                }
            }

            return null;
        }

        public void UpdateBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using SqlCommand cmd = new SqlCommand("sp_UpdateBook", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = book.Id;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = book.Title;
                cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar, 100).Value = book.AuthorName;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = book.Price;
                cmd.Parameters["@Price"].Precision = 10;
                cmd.Parameters["@Price"].Scale = 2;

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBook(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using SqlCommand cmd = new SqlCommand("sp_DeleteBook", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public DataSet GetBooksDataSet()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Title, AuthorName, Price FROM Books ORDER BY Id";
                using SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Books");

                return ds;
            }
        }

        public void UpdateBooksDataSet(DataSet dataSet)
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            using SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id, Title, AuthorName, Price FROM Books", con);

            adapter.InsertCommand = new SqlCommand("sp_AddBook", con);
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter.InsertCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 100, "Title");
            adapter.InsertCommand.Parameters.Add("@AuthorName", SqlDbType.NVarChar, 100, "AuthorName");
            adapter.InsertCommand.Parameters.Add("@Price", SqlDbType.Decimal, 0, "Price").Precision = 10;
            adapter.InsertCommand.Parameters["@Price"].Scale = 2;

            adapter.UpdateCommand = new SqlCommand("sp_UpdateBook", con);
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            adapter.UpdateCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 100, "Title");
            adapter.UpdateCommand.Parameters.Add("@AuthorName", SqlDbType.NVarChar, 100, "AuthorName");
            adapter.UpdateCommand.Parameters.Add("@Price", SqlDbType.Decimal, 0, "Price").Precision = 10;
            adapter.UpdateCommand.Parameters["@Price"].Scale = 2;

            adapter.DeleteCommand = new SqlCommand("sp_DeleteBook", con);
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id").SourceVersion = DataRowVersion.Original;

            adapter.Update(dataSet, "Books");
        }
    }
}
