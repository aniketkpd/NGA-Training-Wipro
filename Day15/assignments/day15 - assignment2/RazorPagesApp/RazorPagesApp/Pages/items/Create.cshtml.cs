using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages.Items;

public class CreateModel : PageModel
{
    [BindProperty]
    public string NewItem { get; set; }

    public IActionResult OnPost()
    {
        if (!string.IsNullOrEmpty(NewItem))
        {
            ItemStore.Items.Add(NewItem);
        }

        return RedirectToPage("/Items/Index");
    }
}