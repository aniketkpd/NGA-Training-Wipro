using System;
using System.Collections.Generic;
using System.Text;


//publisher-subscriber model

namespace Day6
{
    class Publisher
    {
        public event Action Notify;

        public void Trigger()
        {
            Notify?.Invoke();
        }
    }

    class Subscriber
    {
        public void React()
        {
            Console.WriteLine("Received!");
        }
    }



    class Model2
    {
        public static void Main()
        {

            Publisher p = new Publisher();
            Subscriber s = new Subscriber();

            p.Notify += s.React; // subscribe

            p.Trigger(); // notify all
        }
    }
}
