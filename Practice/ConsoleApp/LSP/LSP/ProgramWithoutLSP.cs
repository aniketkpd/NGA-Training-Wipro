using System;

namespace WithoutLSP
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override int Height
        {
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
    }

    class ProgramWithoutLSP
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Square();

            rect.Width = 5;
            rect.Height = 10;

            Console.WriteLine("Expected area: 50");
            Console.WriteLine("Actual area: " + rect.GetArea());

            Console.ReadLine();
        }
    }
}