using System;

namespace SolidAssignment
{
    public class AdvancedReport : IPrintable, IExportable
    {
        public void Print()
        {
            Console.WriteLine("Printing Advanced Report");
        }

        public void Export()
        {
            Console.WriteLine("Exporting Report");
        }
    }
}