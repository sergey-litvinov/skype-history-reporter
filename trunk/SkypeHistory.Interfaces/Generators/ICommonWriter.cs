using SkypeHistory.Entities.Reports;

namespace SkypeHistory.Interfaces.Generators
{
	public interface ICommonWriter : IWriter
	{
		void WriteTitle(ReportContext context, string header);
		void WriteDelimiter(ReportContext context);

		string NewLine { get; }
	}
}