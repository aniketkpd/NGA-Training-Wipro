using System.IO;

namespace SolidAssignment
{
    public class ReportSaver
    {
        public void Save(string content)
        {
            File.WriteAllText("report.txt", content);
        }
    }
}