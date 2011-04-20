using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.ServiceLocation;
using SkypeHistory.Entities;
using SkypeHistory.Interfaces;

namespace SkypeHistory.Shell.Views
{
    public partial class ProfileSelector : Form
    {
        public ProfileSelector()
        {
            InitializeComponent();
        }

        private void ProfileSelector_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Address_Book;
            var skypeService = ServiceLocator.Current.GetInstance<ISkypeService>();
            cbProfiles.Items.Clear();
            cbProfiles.Items.AddRange(skypeService.GetProfiles());
            if (cbProfiles.Items.Count != 0)
            {
                cbProfiles.SelectedIndex = 0;
            }
        }

        public SkypeProfile CurrentProfile
        {
            get { return cbProfiles.SelectedItem as SkypeProfile; }
        }

        private void cbProfiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
