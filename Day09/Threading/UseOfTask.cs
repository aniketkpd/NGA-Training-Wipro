using System;
using System.Threading;
using static System.Reflection.Metadata.BlobBuilder;

namespace Day9.Threading
{
    class UseOfTask
    {
        static void myMethod()
        {
            Console.WriteLine("Hello from Task + myMethod");
        }

        public static void Main(string[] args)
        {
            //Task task = Task.Run(() =>
            //{
            //    Console.WriteLine("Task is running...");
            //});


            //Task t1 = Task.Run(myMethod);

            //Console.WriteLine("Main thread continues...");



            //Task that resturn a value
            //Task<int> → returns int
            //task.Result → blocks until result is ready

            Task <int> t2 = Task.Run(() =>
                { 
                    Thread.Sleep(5000);
                    return 6;
                }
            );
            Console.WriteLine(t2.Result);
            Console.WriteLine("Main thread continues...");
        }
    }
}
