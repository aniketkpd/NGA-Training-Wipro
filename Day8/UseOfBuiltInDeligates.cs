using System;
using System.Collections.Generic;
using System.Text;


//Func<T, return Type> - return a value
//Action<T> - doesnt return
//Predicate<T> - returns a boolean value



namespace Day8
{
    internal class UseOfBuiltInDeligates
    {
        public static void Main(string[] args)
        {

            //Func delegate

            ////Example 1 (no input, returns int)

            //Func<int> num = () => 5;
            //Console.WriteLine(num()); // Output: 5



            ////Example 2 (takes input, returns int)
            //Func<int, int> num2 = (x) => x * 2;
            //Console.WriteLine(num2(4)); // Output: 8


            ////Example 3 (takes 2 input, returns int)
            //Func<int, int, int> sum = (x, y) => x + y;
            //Console.WriteLine(sum(4, 5)); // Output: 9




            //Action delegate

            ////Example 1 (no input)
            //Action sayHello = () => Console.WriteLine("Action with no input");
            //sayHello();

            ////Example 2 (takes input)
            //Action<string> greet = (name) => Console.WriteLine($"Hello, {name}!");
            //greet("Alice");


            ////Example 3 (takes 2 input)
            //Action<string, int> printInfo = (name, age) => Console.WriteLine($"Name: {name}, Age: {age}");
            //printInfo("Bob", 30);




            //Predicate delegate

            Predicate<int> isEven = (x) => x % 2 == 0;
            Console.WriteLine(isEven(4)); // Output: True
            Console.WriteLine(isEven(5)); // Output: False



        }




    }
}
