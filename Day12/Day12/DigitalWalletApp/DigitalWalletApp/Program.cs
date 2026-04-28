using DigitalWalletApp.Interfaces;
using DigitalWalletApp.Services;
using DigitalWalletApp.Services.Payments;
using DigitalWalletApp.Services.Notifications;

namespace DigitalWalletApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IPayment payment = new UpiPayment();
            INotification notification = new EmailNotification();

            WalletService wallet = new WalletService(payment, notification);

            wallet.MakePayment(1000);

            Console.ReadLine();
        }
    }
}