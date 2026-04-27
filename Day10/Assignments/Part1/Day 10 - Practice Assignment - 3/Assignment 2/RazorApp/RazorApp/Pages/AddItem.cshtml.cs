using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class AddItemModel : PageModel
{
    [BindProperty]
    public string NewItem { get; set; }

    public IActionResult OnPost()
    {
        if (!string.IsNullOrEmpty(NewItem))
        {
            IndexModel.ItemStore.Add(NewItem);
        }

        return RedirectToPage("Index");
    }
}