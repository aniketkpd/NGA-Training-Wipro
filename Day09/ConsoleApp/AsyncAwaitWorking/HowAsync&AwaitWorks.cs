using System;
using System.Threading.Tasks;

namespace Day9.AsyncAwaitWorking
{
    class HowAsync_AwaitWorks
    {
        //public static void Main()
        //{
        //synchronous code
        //Console.WriteLine("A");
        //Console.WriteLine("B");
        //Console.WriteLine("C");




        //add a slow operation
        //program is doing nothing while waiting

        //Console.WriteLine("Start");
        ////Program completely stops here for 5 seconds, system becomes unresponsive, user cannot interact with it, and it cannot perform any other tasks during this time.
        //Thread.Sleep(5000); 
        //Console.WriteLine("End");

        //}




        public static async Task Main()
        {
            Console.WriteLine("Start");
            //Program can perform other tasks while waiting for the slow operation to complete, and it remains responsive to user interactions.
            await Task.Delay(5000); //pause here for 5 seconds, but dont bloack whole program
            Console.WriteLine("End");
        }
    }
}
