using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAssignment1.Models;

namespace RazorAssignment1.Pages.Products;

public class DetailsModel : PageModel
{
    public Product? Product { get; set; }

    public void OnGet(int id)
    {
        Product = ProductStore.Products.FirstOrDefault(product => product.ProductID == id);
    }
}
