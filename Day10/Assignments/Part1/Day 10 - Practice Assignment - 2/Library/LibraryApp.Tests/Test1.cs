using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp;

namespace LibraryApp.Tests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void AddBook_Test()
        {
            var lib = new Library();
            var book = new Book { Title = "C#", Author = "MS", ISBN = "123" };

            lib.AddBook(book);

            Assert.AreEqual(1, lib.Books.Count);
        }

        [TestMethod]
        public void RegisterBorrower_Test()
        {
            var lib = new Library();
            var borrower = new Borrower { Name = "Aniket", LibraryCardNumber = "001" };

            lib.RegisterBorrower(borrower);

            Assert.AreEqual(1, lib.Borrowers.Count);
        }

        [TestMethod]
        public void BorrowBook_Test()
        {
            var lib = new Library();

            var book = new Book { Title = "C#", Author = "MS", ISBN = "123" };
            var borrower = new Borrower { Name = "Aniket", LibraryCardNumber = "001" };

            lib.AddBook(book);
            lib.RegisterBorrower(borrower);

            lib.BorrowBook("123", "001");

            Assert.IsTrue(book.IsBorrowed);
            Assert.AreEqual(1, borrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void ReturnBook_Test()
        {
            var lib = new Library();

            var book = new Book { Title = "C#", Author = "MS", ISBN = "123" };
            var borrower = new Borrower { Name = "Aniket", LibraryCardNumber = "001" };

            lib.AddBook(book);
            lib.RegisterBorrower(borrower);

            lib.BorrowBook("123", "001");
            lib.ReturnBook("123", "001");

            Assert.IsFalse(book.IsBorrowed);
            Assert.AreEqual(0, borrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void ViewBooks_Test()
        {
            var lib = new Library();

            lib.AddBook(new Book { Title = "C#", Author = "MS", ISBN = "123" });

            var books = lib.ViewBooks();

            Assert.AreEqual(1, books.Count);
        }
    }
}