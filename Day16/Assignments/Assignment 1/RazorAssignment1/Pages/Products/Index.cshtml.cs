using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAssignment1.Models;

namespace RazorAssignment1.Pages.Products;

public class IndexModel : PageModel
{
    public List<Product> Products { get; set; } = new();

    // BindProperty fills this Product object from the form fields.
    [BindProperty]
    public Product Product { get; set; } = new()
    {
        Categories = new List<Category>
        {
            new Category(),
            new Category()
        }
    };

    public void OnGet()
    {
        Products = ProductStore.Products;
    }

    public IActionResult OnPost()
    {
        ProductStore.Add(Product);
        return RedirectToPage();
    }
}
