namespace SolidAssignment
{
    public class ExcelFormatter : IReportFormatter
    {
        public string Format(string data)
        {
            return "Excel Format: " + data;
        }
    }
}