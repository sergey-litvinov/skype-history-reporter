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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.GroupBox gbReports;
            this.cbChats = new System.Windows.Forms.ComboBox();
            this.lbParticipants = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbChatInfo = new System.Windows.Forms.GroupBox();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.lblLastActivity = new System.Windows.Forms.Label();
            this.lblAdder = new System.Windows.Forms.Label();
            this.bGenerate = new System.Windows.Forms.Button();
            this.reportWorker = new System.ComponentModel.BackgroundWorker();
            this.cblReports = new System.Windows.Forms.CheckedListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            gbReports = new System.Windows.Forms.GroupBox();
            this.gbChatInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            gbReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 13);
            label1.TabIndex = 0;
            label1.Text = "Select Chat";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(8, 22);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 13);
            label3.TabIndex = 4;
            label3.Text = "Adder:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 61);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(67, 13);
            label4.TabIndex = 6;
            label4.Text = "Last Activity:";
            // 
            // cbChats
            // 
            this.cbChats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbChats.DisplayMember = "UsefullName";
            this.cbChats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChats.FormattingEnabled = true;
            this.cbChats.Location = new System.Drawing.Point(80, 6);
            this.cbChats.Name = "cbChats";
            this.cbChats.Size = new System.Drawing.Size(261, 21);
            this.cbChats.TabIndex = 1;
            this.cbChats.SelectedIndexChanged += new System.EventHandler(this.cbChats_SelectedIndexChanged);
            // 
            // lbParticipants
            // 
            this.lbParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbParticipants.DisplayMember = "DisplayName";
            this.lbParticipants.FormattingEnabled = true;
            this.lbParticipants.Location = new System.Drawing.Point(9, 106);
            this.lbParticipants.Name = "lbParticipants";
            this.lbParticipants.Size = new System.Drawing.Size(430, 238);
            this.lbParticipants.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Participants";
            // 
            // gbChatInfo
            // 
            this.gbChatInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChatInfo.Controls.Add(this.pbPicture);
            this.gbChatInfo.Controls.Add(this.lblLastActivity);
            this.gbChatInfo.Controls.Add(label4);
            this.gbChatInfo.Controls.Add(this.lblAdder);
            this.gbChatInfo.Controls.Add(label3);
            this.gbChatInfo.Controls.Add(this.lbParticipants);
            this.gbChatInfo.Controls.Add(this.label2);
            this.gbChatInfo.Location = new System.Drawing.Point(15, 33);
            this.gbChatInfo.Name = "gbChatInfo";
            this.gbChatInfo.Size = new System.Drawing.Size(445, 349);
            this.gbChatInfo.TabIndex = 4;
            this.gbChatInfo.TabStop = false;
            this.gbChatInfo.Text = "Chat Info";
            // 
            // pbPicture
            // 
            this.pbPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPicture.Location = new System.Drawing.Point(351, 8);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(88, 96);
            this.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPicture.TabIndex = 8;
            this.pbPicture.TabStop = false;
            // 
            // lblLastActivity
            // 
            this.lblLastActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastActivity.Location = new System.Drawing.Point(76, 51);
            this.lblLastActivity.Name = "lblLastActivity";
            this.lblLastActivity.Size = new System.Drawing.Size(237, 35);
            this.lblLastActivity.TabIndex = 7;
            this.lblLastActivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdder
            // 
            this.lblAdder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdder.Location = new System.Drawing.Point(76, 10);
            this.lblAdder.Name = "lblAdder";
            this.lblAdder.Size = new System.Drawing.Size(237, 35);
            this.lblAdder.TabIndex = 5;
            this.lblAdder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bGenerate
            // 
            this.bGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bGenerate.Location = new System.Drawing.Point(351, 6);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(109, 23);
            this.bGenerate.TabIndex = 5;
            this.bGenerate.Text = "Generate Report";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // reportWorker
            // 
            this.reportWorker.WorkerReportsProgress = true;
            this.reportWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.reportWorker_DoWork);
            this.reportWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.reportWorker_ProgressChanged);
            this.reportWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.reportWorker_RunWorkerCompleted);
            // 
            // gbReports
            // 
            gbReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            gbReports.Controls.Add(this.cblReports);
            gbReports.Location = new System.Drawing.Point(466, 7);
            gbReports.Name = "gbReports";
            gbReports.Size = new System.Drawing.Size(144, 375);
            gbReports.TabIndex = 8;
            gbReports.TabStop = false;
            gbReports.Text = "Selected Reports:";
            // 
            // cblReports
            // 
            this.cblReports.CheckOnClick = true;
            this.cblReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cblReports.FormattingEnabled = true;
            this.cblReports.Location = new System.Drawing.Point(3, 16);
            this.cblReports.Name = "cblReports";
            this.cblReports.Size = new System.Drawing.Size(138, 356);
            this.cblReports.TabIndex = 7;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "htm";
            this.saveFileDialog1.FileName = "Report";
            this.saveFileDialog1.Filter = "Html|*.htm";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 394);
            this.Controls.Add(gbReports);
            this.Controls.Add(this.bGenerate);
            this.Controls.Add(this.gbChatInfo);
            this.Controls.Add(this.cbChats);
            this.Controls.Add(label1);
            this.Name = "MainForm";
            this.Text = "Skype History Reporter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbChatInfo.ResumeLayout(false);
            this.gbChatInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            gbReports.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.ComboBox cbChats;
        private System.Windows.Forms.ListBox lbParticipants;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbChatInfo;
        private System.Windows.Forms.Label lblLastActivity;
        private System.Windows.Forms.Label lblAdder;
        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.Button bGenerate;
        private System.ComponentModel.BackgroundWorker reportWorker;
        private System.Windows.Forms.CheckedListBox cblReports;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	}
}