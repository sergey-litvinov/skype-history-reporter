using SkypeHistory.Entities.Reports;

namespace SkypeHistory.Interfaces.Generators
{
    public interface ITableWriter : IWriter
    {
        void WriteHeader(ReportContext context, params string[] data);
        void WriteBody(ReportContext context, params string[] data);
        void WriteFooter(ReportContext context, params string[] data);
    }
}