using System;
using OrderApp.Services;

namespace OrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the publisher
            OrderProcessor processor = new OrderProcessor();

            // Create the subscribers
            EmailService emailService = new EmailService();
            SMSService smsService = new SMSService();
            LoggerService loggerService = new LoggerService();

            // Subscribe methods to the event (Multicast)
            processor.OnOrderPlaced += emailService.SendEmail;
            processor.OnOrderPlaced += smsService.SendSMS;
            processor.OnOrderPlaced += loggerService.LogOrder;

            // Create a new order
            Order myOrder = new Order
            {
                OrderId = 101,
                CustomerName = "Test User",
                Amount = 500.0
            };

            // Process the order (this triggers the notifications)
            processor.Process(myOrder);
        }
    }
}