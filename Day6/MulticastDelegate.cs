using System;
using System.Collections.Generic;
using System.Text;



namespace Day6
{
    class MulticastDelegate
    {
        delegate void mydel();

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

        public static void Main(string[] args)
        {
            mydel d = method1;
            d += method2;
            d += method3;
            d();
        }


    }
       


}          



