using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FeedbackPortal.Models;

namespace FeedbackPortal.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Feedback UserFeedback { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Message = "Feedback submitted successfully!";
        }
    }
}