using System;
using System.Linq;
using Microsoft.Practices.Unity;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Infrastructure.Generators;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Modules.MonthReport
{
	public class TotalReport : MessageReportGenerator
	{
        [Dependency]
        public ITableWriter TableWriter { get; set; }

        [Dependency]
        public ICommonWriter CommonWriter { get; set; }

        public override string Name
        {
            get { return "Total messages report"; }
        }

	    public override void Generate(ReportContext context)
	    {
	        var groups =
	            GetMessages().GroupBy(i => i.Author).Select(group => new Tuple<string, int>(group.Key, group.Count())).
	                OrderByDescending(i => i.Item2);
            CommonWriter.WriteTitle(context, "Report by total message count");
            TableWriter.WriteHeader(context, "Author","Message count");
	        foreach (var item in groups)
	        {
	            var member = GetMember(item.Item1);
				if (member == null) continue;
	            TableWriter.WriteBody(context, member.DisplayName, item.Item2.ToString());
	        }
            TableWriter.WriteFooter(context);
	    }
	}
}