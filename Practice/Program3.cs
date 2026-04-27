//events
using System;
namespace
{
    class Program3
    {
        //Delegate here - before main and outside main
        delegate void mydel();

        static event mydel myevent;



        static void method1()
        {
            Console.WriteLine("method1");
        }
        static void method2()
        {
            Console.WriteLine("method2");
        }
        static void method3()
        {
            Console.WriteLine("method3");
        }


        static void Main()
        {
            myevent += method1;
            myevent += method2;
            myevent += method3;

            myevent?.Invoke();

        }
    }

}