using System;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Infrastructure.Generators.Html
{
    public class TableWriter : BaseHtmlWriter, ITableWriter
    {
        public void WriteHeader(ReportContext context, params string[] data)
        {
			context.Writer.WriteLine("<table>");
			context.Writer.Write("<tr>");
            foreach (var item in data)
            {
				context.Writer.Write("<th>{0}</th>", item);
            }
			context.Writer.WriteLine("</tr>");
        }

        public void WriteBody(ReportContext context, params string[] data)
        {
            if (data.Length == 0)
                return;
			context.Writer.Write("<tr>");
            foreach (var item in data)
            {
				if (item == "0")
				{
					context.Writer.Write("<td class='inactive'>{0}</td>", item);					
				}
				else
				{
					context.Writer.Write("<td>{0}</td>", item);					
				}
            }
			context.Writer.WriteLine("</tr>");
        }

        public void WriteFooter(ReportContext context, params string[] data)
        {
            context.Writer.Write("</table>");            
        }
    }
}