using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserRegistrationApp.Models;

namespace UserRegistrationApp.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegistration User { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Registration Successful!";
            }
        }
    }
}