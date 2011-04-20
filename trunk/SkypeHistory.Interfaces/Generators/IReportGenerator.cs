using SkypeHistory.Entities.Reports;

namespace SkypeHistory.Interfaces.Generators
{
    public interface IReportGenerator
    {
        string Name { get; }
        void Generate(ReportContext context);
    }
}