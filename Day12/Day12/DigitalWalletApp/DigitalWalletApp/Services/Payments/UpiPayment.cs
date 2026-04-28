using DigitalWalletApp.Interfaces;

namespace DigitalWalletApp.Services.Payments
{
    public class UpiPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using UPI");
        }
    }
}