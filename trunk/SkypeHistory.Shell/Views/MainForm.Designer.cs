namespace SkypeHistory.Shell.Views
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.reportWorker = new System.ComponentModel.BackgroundWorker();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.tcReports = new System.Windows.Forms.TabControl();
			this.tpChatReport = new System.Windows.Forms.TabPage();
			this.tbTimeRange = new System.Windows.Forms.TabPage();
			this.chatReportControl = new SkypeHistory.Shell.Views.Reports.ChatReportUserControl();
			this.timeRangeReportUserControl1 = new SkypeHistory.Shell.Views.Reports.TimeRangeReportUserControl();
			this.tcReports.SuspendLayout();
			this.tpChatReport.SuspendLayout();
			this.tbTimeRange.SuspendLayout();
			this.SuspendLayout();
			// 
			// reportWorker
			// 
			this.reportWorker.WorkerReportsProgress = true;
			this.reportWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReportWorkerDoWork);
			this.reportWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ReportWorkerProgressChanged);
			this.reportWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ReportWorkerRunWorkerCompleted);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "htm";
			this.saveFileDialog1.FileName = "Report";
			this.saveFileDialog1.Filter = "Html|*.htm";
			// 
			// tcReports
			// 
			this.tcReports.Controls.Add(this.tpChatReport);
			this.tcReports.Controls.Add(this.tbTimeRange);
			this.tcReports.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcReports.Location = new System.Drawing.Point(0, 0);
			this.tcReports.Name = "tcReports";
			this.tcReports.SelectedIndex = 0;
			this.tcReports.Size = new System.Drawing.Size(672, 499);
			this.tcReports.TabIndex = 9;
			// 
			// tpChatReport
			// 
			this.tpChatReport.Controls.Add(this.chatReportControl);
			this.tpChatReport.Location = new System.Drawing.Point(4, 22);
			this.tpChatReport.Name = "tpChatReport";
			this.tpChatReport.Padding = new System.Windows.Forms.Padding(3);
			this.tpChatReport.Size = new System.Drawing.Size(664, 473);
			this.tpChatReport.TabIndex = 0;
			this.tpChatReport.Text = "Chat report";
			this.tpChatReport.UseVisualStyleBackColor = true;
			// 
			// tbTimeRange
			// 
			this.tbTimeRange.Controls.Add(this.timeRangeReportUserControl1);
			this.tbTimeRange.Location = new System.Drawing.Point(4, 22);
			this.tbTimeRange.Name = "tbTimeRange";
			this.tbTimeRange.Padding = new System.Windows.Forms.Padding(3);
			this.tbTimeRange.Size = new System.Drawing.Size(664, 473);
			this.tbTimeRange.TabIndex = 1;
			this.tbTimeRange.Text = "Timerange report";
			this.tbTimeRange.UseVisualStyleBackColor = true;
			// 
			// chatReportControl
			// 
			this.chatReportControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chatReportControl.Location = new System.Drawing.Point(3, 3);
			this.chatReportControl.Name = "chatReportControl";
			this.chatReportControl.Size = new System.Drawing.Size(658, 467);
			this.chatReportControl.TabIndex = 0;
			// 
			// timeRangeReportUserControl1
			// 
			this.timeRangeReportUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.timeRangeReportUserControl1.Location = new System.Drawing.Point(3, 3);
			this.timeRangeReportUserControl1.Name = "timeRangeReportUserControl1";
			this.timeRangeReportUserControl1.Size = new System.Drawing.Size(658, 467);
			this.timeRangeReportUserControl1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(672, 499);
			this.Controls.Add(this.tcReports);
			this.MinimumSize = new System.Drawing.Size(500, 400);
			this.Name = "MainForm";
			this.Text = "Skype History Reporter";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tcReports.ResumeLayout(false);
			this.tpChatReport.ResumeLayout(false);
			this.tbTimeRange.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.ComponentModel.BackgroundWorker reportWorker;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.TabControl tcReports;
		private System.Windows.Forms.TabPage tpChatReport;
		private System.Windows.Forms.TabPage tbTimeRange;
		private Reports.ChatReportUserControl chatReportControl;
		private Reports.TimeRangeReportUserControl timeRangeReportUserControl1;
	}
}