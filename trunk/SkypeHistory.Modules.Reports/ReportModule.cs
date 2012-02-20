using System;
using Microsoft.Practices.Unity;
using SkypeHistory.Interfaces;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Modules.MonthReport
{
	public class ReportModule : BaseModule
	{
		public override void Run()
		{
			Container.RegisterType<IChatReportGenerator, TotalReport>("Total");
			Container.RegisterType<IChatReportGenerator, MonthReport>("Month");
			Container.RegisterType<IChatReportGenerator, DailyReport>("Daily");
			Container.RegisterType<IChatReportGenerator, HourlyReport>("Hourly");
			Container.RegisterType<IChatReportGenerator, DayOfWeekReport>("DayOfWeek");
			Container.RegisterType<IChatReportGenerator, TopWordsReport>("TopWords");

			Container.RegisterType<ITimerangeReport, TimerangeReport>("Timerange");
		}
	}
}