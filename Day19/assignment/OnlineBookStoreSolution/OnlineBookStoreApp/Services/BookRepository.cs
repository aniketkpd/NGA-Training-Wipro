using OnlineBookStoreApp.Models;

namespace OnlineBookStoreApp.Services
{
    public class BookRepository
    {
        public List<Book> books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "ASP.NET Core",
                Author = "James",
                ISBN = "1234567890123",
                Price = 999
            },

            new Book
            {
                Id = 2,
                Title = "C# Programming",
                Author = "Robert",
                ISBN = "9876543210123",
                Price = 799
            }
        };

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}