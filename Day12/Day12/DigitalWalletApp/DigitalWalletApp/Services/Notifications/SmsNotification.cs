using DigitalWalletApp.Interfaces;

namespace DigitalWalletApp.Services.Notifications
{
    public class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }
}