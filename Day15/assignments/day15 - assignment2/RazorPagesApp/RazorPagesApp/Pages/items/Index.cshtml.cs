using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages.Items;

public class IndexModel : PageModel
{
    public List<string> Items { get; set; }

    public void OnGet()
    {
        Items = ItemStore.Items;
    }
}