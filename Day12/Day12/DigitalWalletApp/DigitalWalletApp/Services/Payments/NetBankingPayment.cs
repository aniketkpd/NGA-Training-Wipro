using DigitalWalletApp.Interfaces;

namespace DigitalWalletApp.Services.Payments
{
    public class NetBankingPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Net Banking");
        }
    }
}