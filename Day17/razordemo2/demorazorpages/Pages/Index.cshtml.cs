using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace demorazorpages.Pages
{
    public class IndexModel : PageModel
    {

        public string ?Message { get; set; }

        [BindProperty]
        public string? Name { get; set; }

        [BindProperty]
        public string? Email { get; set; } = null;

        //get handler method, it will be called when the page is requested with a GET method
        public void OnGet() //page lifecycle method, it will be called when the page is requested with a GET method
        {
            // here we write bussiness logic for the page, for example we can get data from database and pass it to the view

            Message = "Hello, from aniket";
            // if entered string is empty
            if(Name != null)
            {
                Console.WriteLine($"Name cant be empty");
                return;
            }
        }


        //post handler method, it will be called when the page is requested with a POST method, for example when a form is submitted
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            Console.WriteLine($"Saved: {Name} {Email}");
            return Page();
        }
    }
}
