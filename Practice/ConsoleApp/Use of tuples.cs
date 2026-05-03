// tuple
using System;

namespace practice

{ 

    class use_of_tuples
    {
        static (int area, int perimeter) rectangle(int length, int breadth)
        {
            int area = length * breadth;
            int perimeter = 2 * (length + breadth);

            return (area, perimeter);
        }


        static void Main()
        {
            var mytuple = rectangle(5, 5);
            Console.WriteLine(mytuple);

            Console.WriteLine(mytuple.area);
            Console.WriteLine(mytuple.perimeter);
        }
    }

}