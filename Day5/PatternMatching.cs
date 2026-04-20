//Scenario for implemeting Pattern matching with Switch statement:
//Step 1: We will take input from the user and check if it is an integer, a double, or a string.
//Step 2: We will use a switch statement to match the input against different patterns and execute
//different code based on the pattern that matches.
//Step 3: We will also use pattern matching with tuples to deconstruct them and extract values.
//Step 4: Showing output of pattern matching with properties to check if an object has certain


namespace day5
{


    public class PatternMatching
    {
        public static void Main()
        {


            //Use of is in pattern matching - 1
            //object obj = "Hello, World!";
            //if(obj is string str)
            //{
            //    Console.WriteLine($"The string is: {str}");
            //}
            //else
            //{
            //    Console.WriteLine("The object is not a string.");
            //}









            //Use of is pattern matching - 2
            Console.WriteLine("Enter a value:");
            string? input = Console.ReadLine();



            object? value = int.TryParse(input, out int i) ? i :
                           double.TryParse(input, out double d) ? d :
                           input;

            //Using switch
            //switch (value)
            //{
            //    case int x:
            //        Console.WriteLine($"The input is an integer: {x}");
            //        break;

            //    case double y:
            //        Console.WriteLine($"The input is a double: {y}");
            //        break;

            //    case string s:
            //        Console.WriteLine($"The input is a string: {s}");
            //        break;

            //    default:
            //        Console.WriteLine("The input is of an unknown type.");
            //        break;
            //}


            //Using if-else
            if (value is int x)
            {
                Console.WriteLine($"The input is an integer: {x}");
            }
            else if (value is double y)
            {
                Console.WriteLine($"The input is a double: {y}");
            }
            else if (value is string s)
            {
                Console.WriteLine($"The input is a string: {s}");
            }
        }
    }
}