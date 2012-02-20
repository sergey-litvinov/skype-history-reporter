using SkypeHistory.Entities.Reports;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Infrastructure.Generators
{
	public abstract class TimerangeReportGenerator : IReportGenerator
	{
		public abstract string Name { get; }

		public abstract void Generate(ReportContext context);
	}
}