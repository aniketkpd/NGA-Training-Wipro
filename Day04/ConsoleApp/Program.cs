//Scenario 1: E - Commerce Order Management System
//User Story
//As a backend developer, I want to manage customer orders efficiently so that I can process, track, and optimize order workflows in an online store.

//Problem Statement
//Design a system to handle customer orders using appropriate collection types.

//Requirements
//Use List < Order > to store all orders placed
//Use Dictionary<int, Customer> to map customer ID to customer details
//Use HashSet<string> to store unique product categories
//Use Queue<Order> for order processing (FIFO)
//Use Stack<string> to track order status history (LIFO)

//Expected Outcome
//Add, update, and remove orders
//Process orders in sequence
//Track order status changes
//Ensure unique product categories





class Customer
{
    public string name;
    public int phone_number;


    public Customer(string name, int phone_number)
    {
        this.name = name;
        this.phone_number = phone_number;
    }
}



class Order
{
    public int order_id;
    public int customer_id;
    public string product;
    public string category;


    public Order(int order_id, int customer_id, string product, string category)
    {
        this.order_id = order_id;
        this.customer_id = customer_id;
        this.product = product;
        this.category = category;
    }
}



public class Program
{
    public static void Main(string[] args)
    {


        //Creating collections
        List<Order> orders = new List<Order>();
        Dictionary<int, Customer> customer = new Dictionary<int, Customer>();
        HashSet<string> categories = new HashSet<string>();
        Queue<Order> orderQueue = new Queue<Order>();
        Stack<string> statusHistory = new Stack<string>();



        //Adding data to dictionary-customer
        customer.Add(101, new Customer("phill", 1234));
        customer.Add(102, new Customer("tom", 5678));
        customer.Add(103, new Customer("mike", 9101));



        //Adding data to List-order
        orders.Add(new Order(1, 101, "ASUS", "Laptop"));
        orders.Add(new Order(2, 102, "iPhone", "Mobile"));
        orders.Add(new Order(3, 103, "Samsung", "Mobile"));




        // Updating order
        orders[1].product = "iPhone 15";

        // Removing order
        orders.RemoveAll(o => o.order_id == 3);



        //Adding data to Queue-orderQueue and HashSet-categories
        foreach (var order in orders)
        {
            orderQueue.Enqueue(order);
            categories.Add(order.category);
        }


        // Show unique categories
        Console.WriteLine("Unique Categories:");
        foreach (var cat in categories)
        {
            Console.WriteLine(cat);
        }
        Console.WriteLine();


        //Processing orders
        while (orderQueue.Count > 0)
        {
            Order current = orderQueue.Dequeue();

            Console.WriteLine("Processing Order ID: " + current.order_id);

            // Get customer details
            Customer c = customer[current.customer_id];
            Console.WriteLine("Customer: " + c.name);

            // Push status
            statusHistory.Push($"Order Placed for OrderID: {current.order_id}");
            statusHistory.Push($"Order Packed for OrderID: {current.order_id}");
            statusHistory.Push($"Order Shipped for OrderID: {current.order_id}");

            // Latest status
            Console.WriteLine("Latest Status: " + statusHistory.Peek());

            // Full history
            Console.WriteLine("Status History:");
            while (statusHistory.Count > 0)
            {
                Console.WriteLine(statusHistory.Pop());
            }

            Console.WriteLine();
        }
    }
}