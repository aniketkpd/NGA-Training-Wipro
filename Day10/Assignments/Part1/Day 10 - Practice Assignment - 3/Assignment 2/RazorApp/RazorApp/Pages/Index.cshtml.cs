using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class IndexModel : PageModel
{
    public static List<string> ItemStore = new List<string>();

    public List<string> Items { get; set; }

    public void OnGet()
    {
        Items = ItemStore;
    }
}