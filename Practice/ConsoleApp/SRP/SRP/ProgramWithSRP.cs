using System;

namespace WithSRP
{
    public class Invoice
    {
        public int Amount { get; set; }

        public void CalculateTotal()
        {
            Console.WriteLine("Calculating total: " + Amount);
        }
    }

    public class InvoicePrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing invoice...");
        }
    }

    public class InvoiceRepository
    {
        public void Save()
        {
            Console.WriteLine("Saving to database...");
        }
    }

    class ProgramWithSRP
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice { Amount = 100 };
            invoice.CalculateTotal();

            InvoicePrinter printer = new InvoicePrinter();
            printer.Print();

            InvoiceRepository repo = new InvoiceRepository();
            repo.Save();

            Console.ReadLine();
        }
    }
}