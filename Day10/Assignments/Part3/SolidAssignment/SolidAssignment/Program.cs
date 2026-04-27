using System;

namespace SolidAssignment
{
    class Program
    {
        static void Main()
        {
            // DIP + OCP
            IReportFormatter formatter = new PdfFormatter();
            var service = new ReportService(formatter);
            service.Process();

            // LSP
            Report report = new SalesReport();
            Console.WriteLine(report.GetContent());

            // ISP
            IPrintable simple = new SimpleReport();
            simple.Print();
        }
    }
}