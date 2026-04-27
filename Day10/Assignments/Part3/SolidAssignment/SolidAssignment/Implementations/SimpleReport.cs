using System;

namespace SolidAssignment
{
    public class SimpleReport : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Printing Report");
        }
    }
}