using System;

namespace WithISP
{
    public interface IPrinter
    {
        void Print();
    }

    public interface IScanner
    {
        void Scan();
    }

    public interface IFax
    {
        void Fax();
    }

    public class SimplePrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing document...");
        }
    }

    public class MultiFunctionPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Printing document...");
        }

        public void Scan()
        {
            Console.WriteLine("Scanning document...");
        }

        public void Fax()
        {
            Console.WriteLine("Faxing document...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = new SimplePrinter();
            printer.Print();

            Console.WriteLine();

            MultiFunctionPrinter mfp = new MultiFunctionPrinter();
            mfp.Print();
            mfp.Scan();
            mfp.Fax();

            Console.ReadLine();
        }
    }
}