using System;

namespace WithoutDIP
{
    // Low Level Code | Details | Methods to achieve the goal
    class EmailService
    {
        public void Send(string message)
        {
            Console.WriteLine("Email sent: " + message);
        }
    }



    // High Level Code | Bussiness Logic | Goal
    class Notification
    {
        EmailService _email = new EmailService();

        public void Notify()
        {
            _email.Send("Hello from Notification");
        }
    }




    class ProgramWithoutDIP
    {
        static void Main(string[] args)
        {
            Notification notification = new Notification();
            notification.Notify();

            Console.ReadLine();
        }
    }
}