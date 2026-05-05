namespace RazorAssignment1.Models;

public static class ProductStore
{
    private static int nextProductId = 3;
    private static int nextCategoryId = 4;

    public static List<Product> Products { get; } = new()
    {
        new Product
        {
            ProductID = 1,
            Name = "Notebook",
            Description = "A ruled notebook for class notes.",
            Categories = new List<Category>
            {
                new Category { CategoryID = 1, Name = "Stationery" },
                new Category { CategoryID = 2, Name = "School" }
            }
        },
        new Product
        {
            ProductID = 2,
            Name = "Water Bottle",
            Description = "A simple reusable bottle.",
            Categories = new List<Category>
            {
                new Category { CategoryID = 3, Name = "Daily Use" }
            }
        }
    };

    public static void Add(Product product)
    {
        product.ProductID = nextProductId++;

        product.Categories = product.Categories
            .Where(category => !string.IsNullOrWhiteSpace(category.Name))
            .ToList();

        foreach (var category in product.Categories)
        {
            category.CategoryID = nextCategoryId++;
        }

        Products.Add(product);
    }
}
