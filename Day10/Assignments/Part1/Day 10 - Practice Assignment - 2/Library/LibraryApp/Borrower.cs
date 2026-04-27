using System.Collections.Generic;

namespace LibraryApp
{
    public class Borrower
    {
        public string Name { get; set; }
        public string LibraryCardNumber { get; set; }

        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            BorrowedBooks.Remove(book);
        }
    }
}