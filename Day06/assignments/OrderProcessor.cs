using System;

namespace OrderApp
{
    // Delegate definition
    public delegate void OrderPlacedHandler(Order order);

    public class OrderProcessor
    {
        // Event definition
        public event OrderPlacedHandler OnOrderPlaced;

        public void Process(Order order)
        {
            Console.WriteLine($"Order Placed: {order.OrderId}");

            // Trigger the event to notify all subscribers
            OnOrderPlaced?.Invoke(order);
        }
    }
}