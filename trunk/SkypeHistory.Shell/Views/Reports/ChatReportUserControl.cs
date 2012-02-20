using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Practices.ServiceLocation;

using SkypeHistory.Entities;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Interfaces;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Shell.Views.Reports
{
	public partial class ChatReportUserControl : UserControl
	{
		#region Constants and Fields

		private readonly Dictionary<string, Member> contacts = new Dictionary<string, Member>();

		private IChatRepository chatRepository;

		private IEnumerable<Chat> chats;

		private IReportGenerationManager reportManager;

		private List<IChatReportGenerator> reports;

		#endregion

		#region Constructors and Destructors

		public ChatReportUserControl()
		{
			this.InitializeComponent();
		}

		#endregion

		#region Public Methods

		public void InitReport(IReportGenerationManager reportManager)
		{
			this.reportManager = reportManager;
			this.reports = ServiceLocator.Current.GetAllInstances<IChatReportGenerator>().ToList();
			this.cblReports.Items.Clear();
			foreach (var reportGenerator in this.reports)
			{
				this.cblReports.Items.Add(reportGenerator.Name, true);
			}

			try
			{
				this.chats = this.chatRepository.GetAll();
			}
			catch (Exception ex)
			{
				if (ex.Message == "Unable to open the database file")
				{
					MessageBox.Show(
						"Unable to open skype data. Perhaps Skype is running. It should be closed.",
						"Warning",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
				else
				{
					UIUtils.ShowException(ex, true);
				}
				Application.Exit();
			}
			this.cbChats.Items.AddRange(this.chats.OrderByDescending(c => c.LastChange).ToArray());
			if (this.cbChats.Items.Count != 0)
			{
				this.cbChats.SelectedIndex = 0;
			}
		}

		#endregion

		#region Methods

		private void ChatReportUserControl_Load(object sender, EventArgs e)
		{
			if (!this.DesignMode)
			{
				this.chatRepository = ServiceLocator.Current.GetInstance<IChatRepository>();
			}
		}

		private void GenerateReport(string fileName, IEnumerable<IReportGenerator> selectedReports)
		{
			string reportBody = this.GenerateReportBody(selectedReports);
			string htmlTemplate = this.reportManager.ReadHtmlTemplate();
			htmlTemplate = htmlTemplate.Replace("{{ReportBody}}", reportBody);
			htmlTemplate = htmlTemplate.Replace("{{Now}}", DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss"));
			File.WriteAllText(fileName, htmlTemplate, Encoding.UTF8);
		}

		private string GenerateReportBody(IEnumerable<IReportGenerator> reports)
		{
			var stream = new MemoryStream();
			using (var writer = new StreamWriter(stream))
			{
				writer.AutoFlush = true;
				var context = new ReportContext();
				context.Writer = writer;
				foreach (IReportGenerator reportGenerator in reports)
				{
					this.reportManager.NextStep(reportGenerator.Name);
					reportGenerator.Generate(context);
				}
				writer.Flush();
			}
			return Encoding.UTF8.GetString(stream.GetBuffer());
		}

		private void bGenerate_Click(object sender, EventArgs e)
		{
			if (this.cblReports.CheckedItems.Count == 0)
			{
				MessageBox.Show("You should at least one report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			this.bGenerate.Enabled = false;

			IReportGenerator[] selectedReports =
				this.reports.Where(rep => this.cblReports.CheckedItems.OfType<string>().Any(n => rep.Name == n)).ToArray();

			this.reportManager.Setup(selectedReports.Length - 1);

			var context = new ReportGenerationContext
				{
					StartGeneration = (c) => this.GenerateReport(c.ReportFileName, selectedReports),
					EndGeneration = () => { this.bGenerate.Enabled = true; }
				};

			this.reportManager.StartGeneration(context);
		}

		private void cbChats_SelectedIndexChanged(object sender, EventArgs e)
		{
			var chat = this.cbChats.SelectedItem as Chat;
			if (chat == null)
			{
				return;
			}
			IEnumerable<Member> participants = this.chatRepository.GetAlltimeChatMembers(chat);
			this.lbParticipants.Items.Clear();
			this.lbParticipants.Items.AddRange(participants.OrderBy(m => m.DisplayName).ToArray());
			if (string.IsNullOrEmpty(chat.Adder))
			{
				this.lblAdder.Text = "";
			}
			else
			{
				if (!this.contacts.ContainsKey(chat.Adder))
				{
					Member member = this.chatRepository.GetMember(chat.Adder);
					this.contacts.Add(chat.Adder, member);
				}
				this.lblAdder.Text = this.contacts[chat.Adder].DisplayName;
			}

			this.lblLastActivity.Text = chat.LastChange.ToString();
			if (this.pbPicture.Image != null)
			{
				this.pbPicture.Image.Dispose();
				this.pbPicture.Image = null;
			}
			if (chat.Picture != null && chat.Picture.Length != 0)
			{
				byte[] data = chat.Picture.Skip(4).Take(chat.Picture.Length - 8).ToArray();
				using (var memoryStream = new MemoryStream(data))
				{
					try
					{
						Image img = Image.FromStream(memoryStream);
						this.pbPicture.Image = img;
					}
					catch (Exception ex)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
				}
			}
			ServiceLocator.Current.GetInstance<IProfileHolder>().SelectedChat = chat;
		}

		#endregion
	}
}