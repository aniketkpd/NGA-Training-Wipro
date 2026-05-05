namespace RazorAssignment1.Models;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Category> Categories { get; set; } = new();
}
