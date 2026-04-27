using System;
using System.Collections.Generic;
using System.Text;

namespace Day8
{
    internal class UseOfAnonymousFunction_LambdaMethod
    {
        delegate void mydel();

        static void Main()
        {
            mydel d = delegate ()
            {
                Console.WriteLine("This is an anonymous method");
            };

            d();

            mydel lambda = () => Console.WriteLine("This is a lambda expression");
            lambda();
        }
    }
}
