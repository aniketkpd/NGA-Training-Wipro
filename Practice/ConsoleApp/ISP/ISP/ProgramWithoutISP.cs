using System;

namespace WithoutISP
{
    public interface IDevice
    {
        void Print();
        void Scan();
        void Fax();
    }

    public class SimplePrinter : IDevice
    {
        public void Print()
        {
            Console.WriteLine("Printing document...");
        }

        public void Scan()
        {
            throw new NotImplementedException("Scan not supported");
        }

        public void Fax()
        {
            throw new NotImplementedException("Fax not supported");
        }
    }

    class ProgramWithoutISP
    {
        static void Main(string[] args)
        {
            IDevice printer = new SimplePrinter();

            printer.Print();

            try
            {
                printer.Scan(); // runtime problem
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}