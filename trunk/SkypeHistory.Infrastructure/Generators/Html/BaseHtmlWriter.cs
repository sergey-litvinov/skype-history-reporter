using System.IO;
using SkypeHistory.Entities.Reports;

namespace SkypeHistory.Infrastructure.Generators.Html
{
    public class BaseHtmlWriter
    {
        protected TextWriter GetWriter(ReportContext context)
        {
            return ((StreamReportContext)context).Writer;
        }
    }
}