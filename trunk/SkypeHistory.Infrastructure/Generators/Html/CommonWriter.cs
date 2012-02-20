using System;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Infrastructure.Generators.Html
{
    public class CommonWriter : BaseHtmlWriter, ICommonWriter
    {
		public string NewLine
		{
			get
			{
				return "<br/>";
			}
		}

		public void WriteTitle(ReportContext context, string header)
        {
			context.Writer.WriteLine("<h2>{0}</h2>", header);
        }

    	public void WriteDelimiter(ReportContext context)
    	{
			context.Writer.WriteLine("<hr align='left' width='100%'/>");
    	}
    }
}