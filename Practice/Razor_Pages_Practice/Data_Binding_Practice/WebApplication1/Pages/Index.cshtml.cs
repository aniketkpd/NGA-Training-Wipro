using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public string? Name { get; set; } = "Aniket";
        
        [BindProperty]
        public string ? Email { get; set; }

        public string? Message { get; set; }


        // This method is called when the page is accessed via a GET request/ when user visits the page for the first time
        public void OnGet()
        {
            Email = "myemail@example.com";
        }

        // this method is called when user submits the form
        public void OnPost() 
        {
            Message = $"Hello {Name}, your email is {Email}";
        }
    }
}
