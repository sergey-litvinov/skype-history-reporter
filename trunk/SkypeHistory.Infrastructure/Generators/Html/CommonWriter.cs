using System;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Infrastructure.Generators.Html
{
    public class CommonWriter : BaseHtmlWriter, ICommonWriter
    {
        public void WriteTitle(ReportContext context, string header)
        {
            GetWriter(context).WriteLine("<h2>{0}</h2>", header);
        }
    }
}