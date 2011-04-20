using System.IO;

namespace SkypeHistory.Entities.Reports
{
    public abstract class ReportContext
    {
        
    }

    public class StreamReportContext : ReportContext
    {
        public StreamWriter Writer { get; set; }
    }
}