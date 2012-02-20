using System;

namespace SkypeHistory.Interfaces
{
	public class ReportGenerationContext
	{
		public string ReportFileName { get; set; }

		public Action<ReportGenerationContext> StartGeneration { get; set; }
		public Action EndGeneration { get; set; }
	}

	public interface IReportGenerationManager
	{
		void StartGeneration(ReportGenerationContext context);
		void Setup(int count);
		void NextStep(string state);

		string ReadHtmlTemplate();
		string OpenFileSelection();
	}
}