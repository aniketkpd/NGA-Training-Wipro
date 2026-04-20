using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    class UseOfTuples
    {
        static (double area, double perimeter) CalculateRectangle(double length, double breadth)
        {
            double area = length * breadth;
            double perimeter = 2 * (length + breadth);
            return (area, perimeter); // returning a tuple
        }


        public static void Main()
        {
            Console.WriteLine("tuple is " + CalculateRectangle(5,5));
            var result = CalculateRectangle(5, 5);
            Console.WriteLine($"Area: {result.area}, Perimeter: {result.perimeter}");
        }
    }  
}
