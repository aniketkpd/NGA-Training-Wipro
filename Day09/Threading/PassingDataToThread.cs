using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Day9.Threading
{
    internal class PassingDataToThread
    {
        static void Message(object? msg)
        {
            Console.WriteLine(msg);
            Thread.Sleep(1000);
        }



        public static void Main(string[] args)
        {
            //Passing message to thread
            //Thread t1 = new Thread(Message);
            //t1.Start("Hello from Thread");


            //Lamda Expression
            //Thread t2 = new Thread(
            //     () => {
            //         Thread.Sleep(3000);
            //         Console.WriteLine("Hello from Thread using Lamda Expression");
            //     }
            //    );

            //t2.Start();


            Thread t3 = new Thread(
             (object? mymsg) => {
                 Thread.Sleep(3000);
                 Console.WriteLine(mymsg);
             }
            );

            t3.Start("Hello From Thread");

            Console.WriteLine("Main is executing");
        }
    }
}
