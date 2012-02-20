using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.ServiceLocation;
using SkypeHistory.Entities;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Interfaces;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Shell.Views
{
	public partial class MainForm : Form, IReportGenerationManager
	{
        private readonly GenerationForm generationForm = new GenerationForm();

		private ReportGenerationContext currentGenerationContext;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
            Icon = Properties.Resources.Address_Book;
			chatReportControl.InitReport(this);
			timeRangeReportUserControl1.InitReport(this);
		}


	    private void ReportWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
	    {
	    	generationForm.NextStep(e.UserState.ToString());
	    	Application.DoEvents();
	    }

        private void ReportWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
			if (currentGenerationContext != null && currentGenerationContext.EndGeneration != null)
			{
				currentGenerationContext.EndGeneration();
			}

			generationForm.Hide();
			Process.Start(currentGenerationContext.ReportFileName);
        }

		private void ReportWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			if (currentGenerationContext != null && currentGenerationContext.StartGeneration != null)
			{
				currentGenerationContext.StartGeneration(currentGenerationContext);
			}
		}

		public void StartGeneration(ReportGenerationContext context)
		{
			if (reportWorker.IsBusy)
			{
				return;
			}

			var fileName = OpenFileSelection();
			if (!string.IsNullOrEmpty(fileName))
			{
				context.ReportFileName = fileName;
				generationForm.Show();
				currentGenerationContext = context;
				reportWorker.RunWorkerAsync();
			}
			else
			{
				if (context.EndGeneration != null)
				{
					context.EndGeneration();
				}
			}

		}

		public void Setup(int count)
		{
			generationForm.Setup(count);
		}

		public void NextStep(string state)
		{
			reportWorker.ReportProgress(0, state);
		}

		public string ReadHtmlTemplate()
		{
			using (var stream =
				Assembly.GetExecutingAssembly().GetManifestResourceStream("SkypeHistory.Shell.Template.Report.htm"))
			{
				using (var streamReader = new StreamReader(stream))
				{
					return streamReader.ReadToEnd();
				}
			}
		}

		public string OpenFileSelection()
		{
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			return saveFileDialog1.FileName;
		}
	}
}
