using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEmoRazorpages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        //GET binding 
        [BindProperty(SupportsGet = true)]
        
        public string ? SearchName { get; set; }
        //This will be displayed on cshtml file

        //POST binding 
        [BindProperty]
        public string ? Name { get; set; }



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        //GET handler
        public void OnGet() // page lifecycle method it handles GET request 
        {
            //runs on page load 
        }
        //POST Handler  
        public void OnPost() //return type can also be of IActionresult type
        {
            //runs on form submit
        }

    }
}
