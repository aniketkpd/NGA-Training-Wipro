using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CustomerFeedbackApp.Models;

namespace CustomerFeedbackApp.Pages
{
    public class FeedbackModel : PageModel
    {
        [BindProperty]
        public Feedback UserFeedback { get; set; }

        public static List<Feedback> FeedbackList = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            FeedbackList.Add(UserFeedback);
            return RedirectToPage("ViewFeedback");
        }
    }
}