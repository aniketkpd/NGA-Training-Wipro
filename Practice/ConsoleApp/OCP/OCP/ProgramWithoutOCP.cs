using System;

namespace WithoutOCP
{
    public class PaymentProcessor
    {
        public void Pay(string paymentType)
        {
            if (paymentType == "CreditCard")
            {
                Console.WriteLine("Paid using Credit Card");
            }
            else if (paymentType == "PayPal")
            {
                Console.WriteLine("Paid using PayPal");
            }
        }
    }

    class ProgramWithoutOCP
    {
        static void Main(string[] args)
        {
            PaymentProcessor processor = new PaymentProcessor();
            processor.Pay("CreditCard");
            processor.Pay("PayPal");

            Console.ReadLine();
        }
    }
}