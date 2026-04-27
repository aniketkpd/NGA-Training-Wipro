// Pattern Matching

using System;

namespace practice
{



    class Program8
    {



        static void Main()
        {

            Object obj = "hello";


            if (obj is string)
            {
                Console.WriteLine($"{obj} is a string");
            }
            if (obj is int)
            {
                Console.WriteLine($"{obj} is a int");
            }
            if (obj is bool)
            {
                Console.WriteLine($"{obj} is a bool");
            }

            // Console.WriteLine(1 is int);
            // Console.WriteLine(2.22F is float);
            // Console.WriteLine(3.3333D is double);
            // Console.WriteLine("hello" is string);
            // Console.WriteLine('a' is char);




        }
    }

}