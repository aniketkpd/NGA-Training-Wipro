using System;

namespace WithOCP
{
    public interface IPayment
    {
        void Pay();
    }

    public class CreditCardPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Paid using Credit Card");
        }
    }

    public class PayPalPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Paid using PayPal");
        }
    }

    public class UpiPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Paid using UPI");
        }
    }

    public class PaymentProcessor
    {
        public void Process(IPayment payment)
        {
            payment.Pay();
        }
    }

    class ProgramWithOCP
    {
        static void Main(string[] args)
        {
            PaymentProcessor processor = new PaymentProcessor();

            processor.Process(new CreditCardPayment());
            processor.Process(new PayPalPayment());
            processor.Process(new UpiPayment()); // new added without modifying old code

            Console.ReadLine();
        }
    }
}