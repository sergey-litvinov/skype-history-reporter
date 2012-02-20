using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SkypeHistory.Interfaces;

namespace SkypeHistory.Shell.Views
{
	public partial class GenerationForm : Form
    {
        public GenerationForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.Address_Book;
        }

        private void GenerationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

		public void Setup(int count)
		{
			pbProgess.Value = 0;
			pbProgess.Maximum = count;
		}

		public bool NextStep(string state)
		{
			if (pbProgess.Value >= pbProgess.Maximum)
			{
				return false;
			}

			pbProgess.Value++;
			if (!string.IsNullOrEmpty(state))
			{
				lbState.Text = state;
			}

			return true;
		}
    }
}
