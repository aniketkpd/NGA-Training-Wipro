//single cast and multicast Delegates
using System;
namespace practice
{

    class Program2
    {
        //Delegate here - before main and outside main
        delegate void mydel();

        public static void method1()
        {
            Console.WriteLine("method1");
        }
        public static void method2()
        {
            Console.WriteLine("method2");
        }
        public static void method3()
        {
            Console.WriteLine("method3");
        }


        public static void Main()
        {
            //Single cast
            // mydel d = method1;
            // d();

            //multicast
            mydel d = method1;
            d += method2;
            d += method3;
            d();

        }
    }
}
