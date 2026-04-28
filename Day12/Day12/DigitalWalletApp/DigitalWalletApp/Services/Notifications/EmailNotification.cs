using DigitalWalletApp.Interfaces;

namespace DigitalWalletApp.Services.Notifications
{
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }
}