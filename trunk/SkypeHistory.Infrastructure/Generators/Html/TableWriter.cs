using System;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Infrastructure.Generators.Html
{
    public class TableWriter : BaseHtmlWriter, ITableWriter
    {
        public void WriteHeader(ReportContext context, params string[] data)
        {
            var writer = GetWriter(context);
            writer.WriteLine("<table>");
            writer.Write("<tr>");
            foreach (var item in data)
            {
                writer.Write("<th>{0}</th>", item);
            }
            writer.WriteLine("</tr>");
        }

        public void WriteBody(ReportContext context, params string[] data)
        {
            if (data.Length == 0)
                return;
            var writer = GetWriter(context);
            writer.Write("<tr>");
            foreach (var item in data)
            {
                writer.Write("<td>{0}</td>", item);
            }
            writer.WriteLine("</tr>");
        }

        public void WriteFooter(ReportContext context, params string[] data)
        {
            var writer = GetWriter(context);
            writer.Write("</table>");            
        }
    }
}