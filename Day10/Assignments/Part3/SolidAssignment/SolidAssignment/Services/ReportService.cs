namespace SolidAssignment
{
    public class ReportService
    {
        private readonly IReportFormatter _formatter;

        public ReportService(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Process()
        {
            var generator = new ReportGenerator();
            var saver = new ReportSaver();

            string data = generator.GenerateReport();
            string formatted = _formatter.Format(data);

            saver.Save(formatted);
        }
    }
}