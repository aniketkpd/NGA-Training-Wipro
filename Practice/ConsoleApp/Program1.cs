//How delegates work

using System;

namespace practice
{ 
    class Program1
    {
        //Delegate here - before main and outside main
        delegate void mydel();

        public static void Main()
        {
            mydel d = () => Console.WriteLine("Method1");
            d();
        }
    }
}