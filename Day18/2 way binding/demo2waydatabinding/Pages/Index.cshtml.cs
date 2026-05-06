using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace demo2waydatabinding.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string StudentName { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            Message = $"Hello {StudentName}, welcome to Razor Pages!";
        }
    }
}
