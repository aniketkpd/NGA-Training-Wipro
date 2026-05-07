namespace OnlineBookStoreApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string CustomerName { get; set; }

        public double TotalAmount { get; set; }
    }
}