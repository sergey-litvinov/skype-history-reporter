namespace SkypeHistory.Shell.Views
{
    partial class GenerationForm
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
            this.pbProgess = new System.Windows.Forms.ProgressBar();
            this.lbState = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbProgess
            // 
            this.pbProgess.Location = new System.Drawing.Point(12, 24);
            this.pbProgess.Name = "pbProgess";
            this.pbProgess.Size = new System.Drawing.Size(282, 23);
            this.pbProgess.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 13);
            label1.TabIndex = 1;
            label1.Text = "Processing:";
            // 
            // lbState
            // 
            this.lbState.Location = new System.Drawing.Point(80, 5);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(214, 15);
            this.lbState.TabIndex = 2;
            // 
            // GenerationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 59);
            this.Controls.Add(this.lbState);
            this.Controls.Add(label1);
            this.Controls.Add(this.pbProgess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report is generating...";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GenerationForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbProgess;
        private System.Windows.Forms.Label lbState;
    }
}