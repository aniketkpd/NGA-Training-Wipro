using System;

namespace WithoutSRP
{
    public class Invoice
    {
        public int Amount { get; set; }

        public void CalculateTotal()
        {
            Console.WriteLine("Calculating total: " + Amount);
        }

        public void PrintInvoice()
        {
            Console.WriteLine("Printing invoice...");
        }

        public void SaveToDatabase()
        {
            Console.WriteLine("Saving to database...");
        }
    }

    class ProgramWithoutSRP
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice { Amount = 100 };

            invoice.CalculateTotal();
            invoice.PrintInvoice();
            invoice.SaveToDatabase();

            Console.ReadLine();
        }
    }
}