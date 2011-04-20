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
	public partial class MainForm : Form
	{
	    private IEnumerable<Chat> chats;
	    private IChatRepository chatRepository = ServiceLocator.Current.GetInstance<IChatRepository>(); 
        private Dictionary<string, Member> contacts = new Dictionary<string, Member>();

        private GenerationForm generationForm = new GenerationForm();
	    private List<IReportGenerator> reports;
	    private string fileName = string.Empty;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
            Icon = Properties.Resources.Address_Book;
            reports = ServiceLocator.Current.GetAllInstances<IReportGenerator>().ToList();
            cblReports.Items.Clear();
		    foreach (IReportGenerator reportGenerator in reports)
		    {
		        cblReports.Items.Add(reportGenerator.Name, true);
		    }

		    try
		    {
                chats = chatRepository.GetAll();
		    }
		    catch (Exception ex)
		    {
		        if (ex.Message == "Unable to open the database file")
		        {
		            MessageBox.Show("Unable to open skype data. Perhaps Skype is running. It should be closed.", "Warning",
		                            MessageBoxButtons.OK, MessageBoxIcon.Error);
		        }
		        else
		        {
					StringBuilder builder = new StringBuilder();
					while (ex != null)
					{
						builder.AppendLine(ex.ToString());
						ex = ex.InnerException;
						if (ex != null)
							builder.Append("Inner error:");
					}
					MessageBox.Show("Error happens." + builder.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
		        }
                Application.Exit();
		    }
            cbChats.Items.AddRange(chats.OrderByDescending(c => c.LastChange).ToArray());
            if (cbChats.Items.Count != 0)
            {
                cbChats.SelectedIndex = 0;
            }
		}

        private void cbChats_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chat = cbChats.SelectedItem as Chat;
            if (chat == null)
            {
                return;
            }
            var participants = chatRepository.GetAlltimeChatMembers(chat);
            lbParticipants.Items.Clear();
            lbParticipants.Items.AddRange(participants.OrderBy(m => m.DisplayName).ToArray());
            if (string.IsNullOrEmpty(chat.Adder))
                lblAdder.Text = "";
            else
            {
                if (!contacts.ContainsKey(chat.Adder))
                {
                    var member = chatRepository.GetMember(chat.Adder);
                    contacts.Add(chat.Adder, member);
                }
                lblAdder.Text = contacts[chat.Adder].DisplayName;
            }

            lblLastActivity.Text = chat.LastChange.ToString();
            if (pbPicture.Image != null)
            {
                pbPicture.Image.Dispose();
                pbPicture.Image = null;
            }
            if (chat.Picture != null && chat.Picture.Length != 0)
            {
                var data = chat.Picture.Skip(4).Take(chat.Picture.Length - 8).ToArray();
                using (var memoryStream = new MemoryStream(data))
                {
                    try
                    {
                        Image img = Image.FromStream(memoryStream);
                        pbPicture.Image = img;
                    }
                    catch (Exception ex)
                    {
                        if (Debugger.IsAttached)
                            Debugger.Break();
                    }
                }
            }
            ServiceLocator.Current.GetInstance<IProfileHolder>().SelectedChat = chat;
        }

        private void bGenerate_Click(object sender, EventArgs e)
        {
            if (cblReports.CheckedItems.Count == 0)
            {
                MessageBox.Show("You should at least one report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            fileName = saveFileDialog1.FileName;
            var selectedReports =
                reports.Where(rep => cblReports.CheckedItems.OfType<string>().Any(n => rep.Name == n)).ToArray();
            generationForm.Count = reports.Count();
            generationForm.Value = 0;
            generationForm.State = string.Empty;
            generationForm.Show();
            bGenerate.Enabled = false;
            reportWorker.RunWorkerAsync(selectedReports);
        }

        private string ReadHtmlReport()
        {
            using (var stream =
                Assembly.GetExecutingAssembly().GetManifestResourceStream("SkypeHistory.Shell.Report.Report.htm"))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        private void reportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var reports = e.Argument as IEnumerable<IReportGenerator>;
            string reportBody = GenerateReportBody(reports);
            var htmlTemplate = ReadHtmlReport();
            htmlTemplate = htmlTemplate.Replace("{{ReportBody}}", reportBody);
            htmlTemplate = htmlTemplate.Replace("{{Now}}", DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss"));                
            File.WriteAllText(fileName, htmlTemplate, Encoding.UTF8);
        }

	    private string GenerateReportBody(IEnumerable<IReportGenerator> reports)
	    {
	        MemoryStream stream = new MemoryStream();
	        StreamWriter writer = new StreamWriter(stream);
	        writer.AutoFlush = true;
	        StreamReportContext context = new StreamReportContext();
	        context.Writer = writer;
	        int i = 0;
	        foreach (var reportGenerator in reports)
	        {
	            reportWorker.ReportProgress(i, reportGenerator.Name);
	            reportGenerator.Generate(context);
	            i++;
	        }
	        writer.Flush();
	        stream.Position = 0;
	        byte[] data = new byte[stream.Length];
	        stream.Read(data, 0, data.Length);
	        return Encoding.UTF8.GetString(data);
	    }

	    private void reportWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            generationForm.Value = e.ProgressPercentage;
            generationForm.State = e.UserState.ToString();
            Application.DoEvents();
        }

        private void reportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            generationForm.Hide();
            bGenerate.Enabled = true;
            Process.Start(fileName);
        }

	}
}
