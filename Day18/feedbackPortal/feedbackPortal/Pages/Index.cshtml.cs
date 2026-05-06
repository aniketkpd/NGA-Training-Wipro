using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace feedbackPortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // one-way data binding
        public string EmployeeName { get; set; } = "Aniket";

        // two-way data binding
        [BindProperty]
        [Required(ErrorMessage = "feedback is required...!!!")]
        public string? Feedback { get; set; }

        public string? Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            Message = "Thank you for your feedback ..!!";
        }
    }
}