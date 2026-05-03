//How threads works

using System;
using System.Threading;

class WorkingWithThreads
{
    static void PrintNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("*");
            Thread.Sleep(1000); // pause for 0.5 sec
        }
    }

    static void Main()
    {
        Thread t1 = new Thread(PrintNumbers);
        t1.Start();
        //t1.Join();

        Console.WriteLine("Main thread running...");
    }
}
