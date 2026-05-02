using System;

namespace WithDIP
{
    //Abstraction | Interface | Contract
    public interface IMessageService
    {
        void Send(string message);
    }





    // Low Level Code | Details | Methods to achieve the goal
    public class EmailService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine("Email sent: " + message);
        }
    }





    //  Low Level Code | Details | Methods to achieve the goal
    public class SmsService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS sent: " + message);
        }
    }






    // High Level Code | Bussiness Logic | Goal
    public class Notification
    {
        private IMessageService _service;

        public Notification(IMessageService service)
        {
            _service = service;
        }

        public void Notify()
        {
            _service.Send("Hello from Notification");
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            IMessageService email = new EmailService();
            Notification notification1 = new Notification(email);
            notification1.Notify();

            IMessageService sms = new SmsService();
            Notification notification2 = new Notification(sms);
            notification2.Notify();

            Console.ReadLine();
        }
    }
}