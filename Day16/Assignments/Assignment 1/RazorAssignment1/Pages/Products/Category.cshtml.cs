using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAssignment1.Models;

namespace RazorAssignment1.Pages.Products;

public class CategoryModel : PageModel
{
    public string CategoryName { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new();

    public void OnGet(string categoryName)
    {
        CategoryName = categoryName;
        Products = ProductStore.Products
            .Where(product => product.Categories.Any(category => category.Name == categoryName))
            .ToList();
    }
}
