using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookStoreApp.Models;
using OnlineBookStoreApp.Services;

namespace OnlineBookStoreApp.Pages.Books
{
    public class AddBookModel : PageModel
    {
        private readonly BookRepository repository;

        public AddBookModel(BookRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                repository.AddBook(Book);

                return RedirectToPage("/Books/AddBook");
            }

            return Page();
        }
    }
}