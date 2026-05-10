using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

class Order
{
    public int OrderId;
    public string ProductName;
    public double Price;
}

class Customer
{
    public int CustomerId;
    public string Name;
}

class Scenario1
{
    static void Main()
    {
        // Collections

        // store all orders placed
        List<Order> orders = new List<Order>();

        // map customer ID to customer details 
        Dictionary<int, Customer> customers = new Dictionary<int, Customer>();

        //store unique product categories
        HashSet<string> categories = new HashSet<string>();

        //order processing(FIFO)
        Queue<Order> orderQueue = new Queue<Order>();

        //track order status history(LIFO)
        Stack<string> statusHistory = new Stack<string>();

        // Add Customers
        customers[1] = new Customer 
        { 
            CustomerId = 1,
            Name = "Aniket"
        };

        customers[2] = new Customer
        {
            CustomerId = 2,
            Name = "Rahul"
        };




        // Add Orders
        Order o1 = new Order 
        { 
            OrderId = 101,
            ProductName = "Laptop",
            Price = 50000
        };
        
        
        Order o2 = new Order 
        { 
            OrderId = 102, 
            ProductName = "Phone", 
            Price = 20000 
        };

        orders.Add(o1);
        orders.Add(o2);

        
        // Add Categories
        categories.Add("Electronics");
        categories.Add("Electronics"); // duplicate ignored
        categories.Add("Mobiles");

        
        // Add to Queue
        orderQueue.Enqueue(o1);
        orderQueue.Enqueue(o2);

        
        // Process Orders (FIFO)
        Console.WriteLine("Processing Orders:");
        while (orderQueue.Count > 0)
        {
            var order = orderQueue.Dequeue();
            Console.WriteLine($"Processing Order ID: {order.OrderId}");

            statusHistory.Push($"Order {order.OrderId} Processed");
        }

        
        // Show Status History (LIFO)
        Console.WriteLine("\nOrder Status History:");
        foreach (var status in statusHistory)
        {
            Console.WriteLine(status);
        }

        
        
        // Remove Order
        orders.Remove(o1);

        
        
        
        
        // Display Remaining Orders
        Console.WriteLine("\nRemaining Orders:");
        foreach (var order in orders)
        {
            Console.WriteLine($"Order ID: {order.OrderId}");
        }

        
        
        
        // Display Unique Categories
        Console.WriteLine("\nCategories:");
        foreach (var c in categories)
        {
            Console.WriteLine(c);
        }
    }
}