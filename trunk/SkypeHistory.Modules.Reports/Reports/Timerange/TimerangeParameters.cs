using System;

using SkypeHistory.Entities.Reports;

namespace SkypeHistory.Modules.MonthReport
{
	public class TimerangeParameters : ReportParameters
	{
		public DateTime From { get; set; }

		public DateTime To { get; set; }

		/// <summary>
		/// Time in seconds to split chat into different conversation
		/// </summary>
		public int SplitTime { get; set; }
	}
}