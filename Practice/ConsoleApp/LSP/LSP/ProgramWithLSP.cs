using System;

namespace WithLSP
{
    public abstract class Shape
    {
        public abstract int GetArea();
    }

    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override int GetArea()
        {
            return Width * Height;
        }
    }

    public class Square : Shape
    {
        public int Side { get; set; }

        public override int GetArea()
        {
            return Side * Side;
        }
    }

    class ProgramWithLSP
    {
        static void Main(string[] args)
        {
            Shape rect = new Rectangle { Width = 5, Height = 10 };
            Shape square = new Square { Side = 5 };

            Console.WriteLine("Rectangle area: " + rect.GetArea());
            Console.WriteLine("Square area: " + square.GetArea());

            Console.ReadLine();
        }
    }
}