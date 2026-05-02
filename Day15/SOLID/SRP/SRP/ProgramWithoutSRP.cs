using System;

namespace WithoutSRP
{
    public class Invoice
    {
        public int Amount { get; set; }


        
        // Task 1
        public void CalculateTotal()
        {
            Console.WriteLine("Calculating total: " + Amount);
        }





        // Task 2
        public void PrintInvoice()
        {
            Console.WriteLine("Printing invoice...");
        }

    
        
        
        // Task 3
        public void SaveToDatabase()
        {
            Console.WriteLine("Saving to database...");
        }
    }









    class ProgramWithoutSRP
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice 
            { 
                Amount = 100 
            };

            invoice.CalculateTotal();
            invoice.PrintInvoice();
            invoice.SaveToDatabase();

            Console.ReadLine();
        }
    }
}