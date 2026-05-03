//How delegates work

using System;

namespace practice
{ 
    class delegatesinCsharp
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