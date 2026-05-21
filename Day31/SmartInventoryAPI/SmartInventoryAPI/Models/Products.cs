namespace SmartInventoryAPI.Models
{
    public class Products
    {
        //this is a product model with default properties

        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
