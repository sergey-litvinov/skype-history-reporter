namespace SkypeHistory.Shell.Views.Reports
{
	partial class ChatReportUserControl
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
			System.Windows.Forms.GroupBox gbReports;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label2;
			this.cblReports = new System.Windows.Forms.CheckedListBox();
			this.cbChats = new System.Windows.Forms.ComboBox();
			this.bGenerate = new System.Windows.Forms.Button();
			this.gbChatInfo = new System.Windows.Forms.GroupBox();
			this.pbPicture = new System.Windows.Forms.PictureBox();
			this.lblLastActivity = new System.Windows.Forms.Label();
			this.lblAdder = new System.Windows.Forms.Label();
			this.lbParticipants = new System.Windows.Forms.ListBox();
			gbReports = new System.Windows.Forms.GroupBox();
			label1 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			gbReports.SuspendLayout();
			this.gbChatInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// gbReports
			// 
			gbReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			gbReports.Controls.Add(this.cblReports);
			gbReports.Location = new System.Drawing.Point(517, 11);
			gbReports.Name = "gbReports";
			gbReports.Size = new System.Drawing.Size(144, 462);
			gbReports.TabIndex = 9;
			gbReports.TabStop = false;
			gbReports.Text = "Selected SubReports:";
			// 
			// cblReports
			// 
			this.cblReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cblReports.CheckOnClick = true;
			this.cblReports.FormattingEnabled = true;
			this.cblReports.Location = new System.Drawing.Point(3, 16);
			this.cblReports.Name = "cblReports";
			this.cblReports.Size = new System.Drawing.Size(138, 439);
			this.cblReports.TabIndex = 7;
			// 
			// cbChats
			// 
			this.cbChats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbChats.DisplayMember = "UsefullName";
			this.cbChats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbChats.FormattingEnabled = true;
			this.cbChats.Location = new System.Drawing.Point(67, 14);
			this.cbChats.Name = "cbChats";
			this.cbChats.Size = new System.Drawing.Size(311, 21);
			this.cbChats.TabIndex = 9;
			this.cbChats.SelectedIndexChanged += new System.EventHandler(this.cbChats_SelectedIndexChanged);
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(6, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(62, 13);
			label1.TabIndex = 8;
			label1.Text = "Select Chat";
			// 
			// bGenerate
			// 
			this.bGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bGenerate.Location = new System.Drawing.Point(393, 14);
			this.bGenerate.Name = "bGenerate";
			this.bGenerate.Size = new System.Drawing.Size(109, 23);
			this.bGenerate.TabIndex = 11;
			this.bGenerate.Text = "Generate Report";
			this.bGenerate.UseVisualStyleBackColor = true;
			this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
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
			this.gbChatInfo.Controls.Add(label2);
			this.gbChatInfo.Location = new System.Drawing.Point(9, 41);
			this.gbChatInfo.Name = "gbChatInfo";
			this.gbChatInfo.Size = new System.Drawing.Size(502, 432);
			this.gbChatInfo.TabIndex = 10;
			this.gbChatInfo.TabStop = false;
			this.gbChatInfo.Text = "Chat Info";
			// 
			// pbPicture
			// 
			this.pbPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbPicture.Location = new System.Drawing.Point(408, 8);
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
			this.lblLastActivity.Size = new System.Drawing.Size(294, 35);
			this.lblLastActivity.TabIndex = 7;
			this.lblLastActivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// lblAdder
			// 
			this.lblAdder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAdder.Location = new System.Drawing.Point(76, 10);
			this.lblAdder.Name = "lblAdder";
			this.lblAdder.Size = new System.Drawing.Size(294, 35);
			this.lblAdder.TabIndex = 5;
			this.lblAdder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// lbParticipants
			// 
			this.lbParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbParticipants.DisplayMember = "DisplayName";
			this.lbParticipants.FormattingEnabled = true;
			this.lbParticipants.Location = new System.Drawing.Point(9, 109);
			this.lbParticipants.Name = "lbParticipants";
			this.lbParticipants.Size = new System.Drawing.Size(487, 316);
			this.lbParticipants.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(6, 89);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(65, 13);
			label2.TabIndex = 3;
			label2.Text = "Participants:";
			// 
			// ChatReportUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cbChats);
			this.Controls.Add(gbReports);
			this.Controls.Add(label1);
			this.Controls.Add(this.gbChatInfo);
			this.Controls.Add(this.bGenerate);
			this.Name = "ChatReportUserControl";
			this.Size = new System.Drawing.Size(664, 473);
			this.Load += new System.EventHandler(this.ChatReportUserControl_Load);
			gbReports.ResumeLayout(false);
			this.gbChatInfo.ResumeLayout(false);
			this.gbChatInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox cblReports;
		private System.Windows.Forms.ComboBox cbChats;
		private System.Windows.Forms.Button bGenerate;
		private System.Windows.Forms.GroupBox gbChatInfo;
		private System.Windows.Forms.PictureBox pbPicture;
		private System.Windows.Forms.Label lblLastActivity;
		private System.Windows.Forms.Label lblAdder;
		private System.Windows.Forms.ListBox lbParticipants;
	}
}
