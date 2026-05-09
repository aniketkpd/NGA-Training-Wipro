using BookStoreADOApp.DAL;
using BookStoreADOApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreADOApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDAL _dal;

        public BookController(BookDAL dal)
        {
            _dal = dal;
        }

        public IActionResult Index()
        {
            var books = _dal.GetAllBooks();
            return View(books);
        }

        public IActionResult DataSetView()
        {
            var dataSet = _dal.GetBooksDataSet();
            return View(dataSet.Tables["Books"]);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            NormalizeBook(book);

            if (!ModelState.IsValid)
            {
                return View(book);
            }

            try
            {
                _dal.AddBook(book);
                TempData["Message"] = "Book added successfully.";
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Unable to add the book. Check the database connection and try again.");
                return View(book);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = _dal.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            NormalizeBook(book);

            if (!ModelState.IsValid)
            {
                return View(book);
            }

            try
            {
                _dal.UpdateBook(book);
                TempData["Message"] = "Book updated successfully.";
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Unable to update the book. Check the database connection and try again.");
                return View(book);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _dal.DeleteBook(id);
                TempData["Message"] = "Book deleted successfully.";
            }
            catch
            {
                TempData["Error"] = "Unable to delete the book. Check the database connection and try again.";
            }

            return RedirectToAction("Index");
        }

        private static void NormalizeBook(Book book)
        {
            book.Title = book.Title?.Trim() ?? string.Empty;
            book.AuthorName = book.AuthorName?.Trim() ?? string.Empty;
        }
    }
}
