using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkypeHistory.Shell.Views
{
    public partial class GenerationForm : Form
    {
        public GenerationForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.Address_Book;
        }

        public string State
        {
            get { return lbState.Text; }
            set { lbState.Text = value; }
        }

        public int Value
        {
            get { return pbProgess.Value; }
            set { pbProgess.Value = value; }
        }

        public int Count
        {
            get { return pbProgess.Maximum; }
            set { pbProgess.Maximum = value; }
        }

        private void GenerationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
    }
}
