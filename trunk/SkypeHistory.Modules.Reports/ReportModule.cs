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
            Container.RegisterType<IReportGenerator, TotalReport>("Total");
		    Container.RegisterType<IReportGenerator, MonthReport>("Month");
            Container.RegisterType<IReportGenerator, DailyReport>("Daily");
		    Container.RegisterType<IReportGenerator, HourlyReport>("Hourly");
		    Container.RegisterType<IReportGenerator, DayOfWeekReport>("DayOfWeek");
            Container.RegisterType<IReportGenerator, TopWordsReport>("TopWords");
        }
	}
}