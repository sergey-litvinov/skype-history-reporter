namespace SkypeHistory.Shell.Views.Reports
{
	partial class TimeRangeReportUserControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Label Label6;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.GroupBox groupBox1;
			this.cbSplitTimeEnabled = new System.Windows.Forms.CheckBox();
			this.nudIntervalNewChat = new System.Windows.Forms.NumericUpDown();
			this.dtpTimeRangeTo = new System.Windows.Forms.DateTimePicker();
			this.dtpTimeRangeFrom = new System.Windows.Forms.DateTimePicker();
			this.bGenerate = new System.Windows.Forms.Button();
			Label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudIntervalNewChat)).BeginInit();
			this.SuspendLayout();
			// 
			// Label6
			// 
			Label6.AutoSize = true;
			Label6.Location = new System.Drawing.Point(193, 7);
			Label6.Name = "Label6";
			Label6.Size = new System.Drawing.Size(20, 13);
			Label6.TabIndex = 5;
			Label6.Text = "To";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(3, 7);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(30, 13);
			label5.TabIndex = 4;
			label5.Text = "From";
			// 
			// groupBox1
			// 
			groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			groupBox1.Controls.Add(this.cbSplitTimeEnabled);
			groupBox1.Controls.Add(this.nudIntervalNewChat);
			groupBox1.Location = new System.Drawing.Point(6, 29);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(625, 459);
			groupBox1.TabIndex = 14;
			groupBox1.TabStop = false;
			groupBox1.Text = "Reports parameters";
			// 
			// cbSplitTimeEnabled
			// 
			this.cbSplitTimeEnabled.Checked = true;
			this.cbSplitTimeEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSplitTimeEnabled.Location = new System.Drawing.Point(6, 22);
			this.cbSplitTimeEnabled.Name = "cbSplitTimeEnabled";
			this.cbSplitTimeEnabled.Size = new System.Drawing.Size(415, 31);
			this.cbSplitTimeEnabled.TabIndex = 18;
			this.cbSplitTimeEnabled.Text = "Split chats based on time in seconds to determine that this is a new conversation" +
    "";
			this.cbSplitTimeEnabled.UseVisualStyleBackColor = true;
			this.cbSplitTimeEnabled.CheckedChanged += new System.EventHandler(this.cbSplitTimeEnabled_CheckedChanged);
			// 
			// nudIntervalNewChat
			// 
			this.nudIntervalNewChat.Location = new System.Drawing.Point(427, 28);
			this.nudIntervalNewChat.Maximum = new decimal(new int[] {
            2592000,
            0,
            0,
            0});
			this.nudIntervalNewChat.Name = "nudIntervalNewChat";
			this.nudIntervalNewChat.Size = new System.Drawing.Size(82, 20);
			this.nudIntervalNewChat.TabIndex = 17;
			this.nudIntervalNewChat.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
			// 
			// dtpTimeRangeTo
			// 
			this.dtpTimeRangeTo.CustomFormat = "MM/dd/yyyy hh:mm tt";
			this.dtpTimeRangeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeRangeTo.Location = new System.Drawing.Point(219, 2);
			this.dtpTimeRangeTo.Name = "dtpTimeRangeTo";
			this.dtpTimeRangeTo.Size = new System.Drawing.Size(148, 20);
			this.dtpTimeRangeTo.TabIndex = 2;
			// 
			// dtpTimeRangeFrom
			// 
			this.dtpTimeRangeFrom.CustomFormat = "MM/dd/yyyy hh:mm tt";
			this.dtpTimeRangeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeRangeFrom.Location = new System.Drawing.Point(39, 3);
			this.dtpTimeRangeFrom.Name = "dtpTimeRangeFrom";
			this.dtpTimeRangeFrom.Size = new System.Drawing.Size(148, 20);
			this.dtpTimeRangeFrom.TabIndex = 1;
			// 
			// bGenerate
			// 
			this.bGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bGenerate.Location = new System.Drawing.Point(522, 4);
			this.bGenerate.Name = "bGenerate";
			this.bGenerate.Size = new System.Drawing.Size(109, 23);
			this.bGenerate.TabIndex = 3;
			this.bGenerate.Text = "Generate Report";
			this.bGenerate.UseVisualStyleBackColor = true;
			this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
			// 
			// TimeRangeReportUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(groupBox1);
			this.Controls.Add(this.bGenerate);
			this.Controls.Add(this.dtpTimeRangeTo);
			this.Controls.Add(Label6);
			this.Controls.Add(label5);
			this.Controls.Add(this.dtpTimeRangeFrom);
			this.Name = "TimeRangeReportUserControl";
			this.Size = new System.Drawing.Size(634, 498);
			this.Load += new System.EventHandler(this.TimeRangeReportUserControl_Load);
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudIntervalNewChat)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtpTimeRangeTo;
		private System.Windows.Forms.DateTimePicker dtpTimeRangeFrom;
		private System.Windows.Forms.Button bGenerate;
		private System.Windows.Forms.NumericUpDown nudIntervalNewChat;
		private System.Windows.Forms.CheckBox cbSplitTimeEnabled;

	}
}
