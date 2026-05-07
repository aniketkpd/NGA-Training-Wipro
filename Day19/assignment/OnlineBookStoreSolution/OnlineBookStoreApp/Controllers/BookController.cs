using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreApp.Services;

namespace OnlineBookStoreApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository repository;

        public BookController(BookRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.GetAllBooks());
        }

        public IActionResult Details(int id)
        {
            var book = repository.GetBookById(id);

            return View(book);
        }
    }
}