using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

using SkypeHistory.Entities.Reports;
using SkypeHistory.Interfaces;
using SkypeHistory.Interfaces.Generators;
using SkypeHistory.Modules.MonthReport;

namespace SkypeHistory.Shell.Views.Reports
{
	public partial class TimeRangeReportUserControl : UserControl
	{
		private IReportGenerationManager reportManager;

		private IChatRepository chatRepository;

		private IReportGenerator[] timerangeReports;

		public TimeRangeReportUserControl()
		{
			InitializeComponent();
			dtpTimeRangeFrom.Value = DateTime.Today.AddDays(-7);
			dtpTimeRangeTo.Value = DateTime.Now;
		}

		public void InitReport(IReportGenerationManager reportManager)
		{
			this.reportManager = reportManager;
		}

		private void bGenerate_Click(object sender, EventArgs e)
		{
			//var chatgs = chatRepository.GetCalls(DateTime.Now.AddMonths(-2), DateTime.Now);

			//if (this.cblReports.CheckedItems.Count == 0)
			//{
			//    MessageBox.Show("You should at least one report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//    return;
			//}
			this.bGenerate.Enabled = false;

			IReportGenerator[] selectedReports = timerangeReports;

			this.reportManager.Setup(selectedReports.Length - 1);

			var context = new ReportGenerationContext
			{
				StartGeneration = (c) => this.GenerateReport(c.ReportFileName, selectedReports),
				EndGeneration = () => { this.bGenerate.Enabled = true; }
			};

			this.reportManager.StartGeneration(context);

		}

		private void GenerateReport(string fileName, IEnumerable<IReportGenerator> selectedReports)
		{
			string reportBody = this.GenerateReportBody(selectedReports);
			string htmlTemplate = this.reportManager.ReadHtmlTemplate();
			htmlTemplate = htmlTemplate.Replace("{{ReportBody}}", reportBody);
			htmlTemplate = htmlTemplate.Replace("{{Now}}", DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss"));
			File.WriteAllText(fileName, htmlTemplate, Encoding.UTF8);
		}

		private string GenerateReportBody(IEnumerable<IReportGenerator> reports)
		{
			var stream = new MemoryStream();
			using (var writer = new StreamWriter(stream))
			{
				writer.AutoFlush = true;
				var context = new ReportContext();
				context.Parameters.Add(
					TimerangeReport.TimeRangeParametersKey,
					new TimerangeParameters()
						{
							From = this.dtpTimeRangeFrom.Value,
							To = this.dtpTimeRangeTo.Value,
							SplitTime = cbSplitTimeEnabled.Checked ? (int)nudIntervalNewChat.Value : int.MaxValue
						});

				context.Writer = writer;
				foreach (IReportGenerator reportGenerator in reports)
				{
					this.reportManager.NextStep(reportGenerator.Name);
					reportGenerator.Generate(context);
				}
				writer.Flush();
			}
			return Encoding.UTF8.GetString(stream.GetBuffer());
		}

		private void TimeRangeReportUserControl_Load(object sender, EventArgs e)
		{
			if (!this.DesignMode)
			{
				chatRepository = ServiceLocator.Current.GetInstance<IChatRepository>();
				timerangeReports = ServiceLocator.Current.GetAllInstances<ITimerangeReport>().OfType<IReportGenerator>().ToArray();
			}
		}

		private void cbSplitTimeEnabled_CheckedChanged(object sender, EventArgs e)
		{
			nudIntervalNewChat.Enabled = cbSplitTimeEnabled.Checked;
		}
	}
}
