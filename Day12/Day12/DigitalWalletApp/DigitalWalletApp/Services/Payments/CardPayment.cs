using DigitalWalletApp.Interfaces;

namespace DigitalWalletApp.Services.Payments
{
    public class CardPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Card");
        }
    }
}