using DigitalWalletApp.Interfaces;

namespace DigitalWalletApp.Services
{
    public class WalletService
    {
        private readonly IPayment _payment;
        private readonly INotification _notification;

        //Constructor
        public WalletService(IPayment payment, INotification notification)
        {
            _payment = payment;
            _notification = notification;
        }

        public void MakePayment(decimal amount)
        {
            _payment.Pay(amount);
            _notification.Send($"Payment of {amount} successful");
        }
    }
}