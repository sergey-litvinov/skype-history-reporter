using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Practices.Unity;

using SkypeHistory.Entities;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Interfaces;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Modules.MonthReport
{
	public class TimerangeReport : ITimerangeReport
	{
		#region Constants and Fields

		public const string TimeRangeParametersKey = "TimerangeReport";

		#endregion

		#region Public Properties

		[Dependency]
		public ICacheService CacheService { get; set; }

		[Dependency]
		public ICallRepository CallRepository { get; set; }

		[Dependency]
		public IChatRepository ChatRepository { get; set; }

		[Dependency]
		public ICommonWriter CommonWriter { get; set; }

		public string Name
		{
			get
			{
				return "Time range report";
			}
		}

		[Dependency]
		public IProfileHolder ProfileHolder { get; set; }

		[Dependency]
		public ITableWriter TableWriter { get; set; }

		#endregion

		#region Public Methods

		public void Generate(ReportContext context)
		{
			if (!context.Parameters.ContainsKey(TimeRangeParametersKey))
			{
				throw new ArgumentException("There is no parameter with name " + TimeRangeParametersKey);
			}

			var param = context.Parameters[TimeRangeParametersKey] as TimerangeParameters;
			var timeline = new SortedDictionary<DateTime, Timerecord>(new DateTimeComparer());
			int totalConversations = 0;
			int totalMessageCount = 0;
			int totalMyMessages = 0;			

			IEnumerable<Call> calls = this.CallRepository.GetCalls(param.From, param.To);
			IEnumerable<Message> messages = this.ChatRepository.GetMessages(param.From, param.To);

			foreach (Call call in calls)
			{
				timeline.Add(
					call.Start, new Timerecord { Call = call, BeginTimestamp = call.Start, EndTimestamp = call.Start + call.Duration });
			}
			var messageGroups = messages.GroupBy(m => m.ChatName);
			foreach (var group in messageGroups)
			{
				var chat = ChatRepository.GetChat(group.Key);
				List<Message> chatMessages = messages.Where(m => m.ChatName == chat.Name).ToList();
				// when is someone birthday, text will be null
				if (chatMessages.Count == 0 || (chatMessages.Count == 1 && chatMessages[0].Text == null))
				{
					continue;
				}

				Message prevMessage = chatMessages.First();
				DateTime timestamp = prevMessage.Timestamp;
				int messageCount = 0;

				foreach (Message message in chatMessages)
				{
					messageCount++;
					if (message.Timestamp > timestamp.AddSeconds(param.SplitTime))
					{
						timeline.Add(
							timestamp,
							new Timerecord
								{ Chat = chat, MessagesCount = messageCount, BeginTimestamp = timestamp, EndTimestamp = prevMessage.Timestamp });
						timestamp = message.Timestamp;
						messageCount = 0;
						totalConversations++;
					}
					prevMessage = message;
					totalMessageCount++;
					if (message.Author == ProfileHolder.Current.Name)
					{
						totalMyMessages++;
					}
				}
				if (messageCount != 0)
				{
					timeline.Add(
						timestamp,
						new Timerecord { Chat = chat, MessagesCount = messageCount, BeginTimestamp = timestamp, EndTimestamp = prevMessage.Timestamp });
					totalConversations++;
				}
			}
			this.CommonWriter.WriteTitle(
				context, string.Format("Skype total information activity report from {0} to {1}", param.From, param.To));
			this.TableWriter.WriteHeader(context, "", "Count");
			this.TableWriter.WriteBody(context, "Calls", calls.Count().ToString());
			this.TableWriter.WriteBody(context, "Chats conversations", totalConversations.ToString());
			this.TableWriter.WriteBody(context, "Total Messages ", totalMessageCount.ToString());
			this.TableWriter.WriteBody(context, "My Messages ", totalMyMessages.ToString());
			this.TableWriter.WriteFooter(context);

			foreach (var keyValue in timeline)
			{
				Timerecord record = keyValue.Value;
				bool isChat = record.Call == null;
				this.CommonWriter.WriteTitle(
					context, string.Format("{0} at {1}", isChat ? "Conversation" : "Call", record.BeginTimestamp));

				this.CommonWriter.WriteDelimiter(context);

				this.TableWriter.WriteHeader(context, "Name", "Value");
				this.TableWriter.WriteBody(context, "Started", record.BeginTimestamp.ToString());
				this.TableWriter.WriteBody(context, "Ended", record.EndTimestamp.ToString());
				this.TableWriter.WriteBody(context, "Duration", (record.EndTimestamp - record.BeginTimestamp).ToString());
				// show members of call\chat
				IEnumerable<Member> members;
				if (isChat)
				{
					this.TableWriter.WriteBody(context, "Display name", record.Chat.DisplayName);
					this.TableWriter.WriteBody(context, "Total messages", record.MessagesCount.ToString());
					members = this.ChatRepository.GetCurrentChatMembers(record.Chat);
				}
				else
				{
					members = this.CallRepository.GetCallMembers(record.Call);
				}
				string[] membersPlain = members.OrderBy(m => m.DisplayName).Select(m => m.DisplayName).Distinct().ToArray();
				this.TableWriter.WriteBody(context, "Members", string.Join(this.CommonWriter.NewLine, membersPlain));

				this.TableWriter.WriteFooter(context);
			}
		}

		#endregion

		private class Timerecord
		{
			#region Public Properties

			public DateTime BeginTimestamp { get; set; }

			public Call Call { get; set; }

			public Chat Chat { get; set; }

			public DateTime EndTimestamp { get; set; }

			public int MessagesCount { get; set; }

			#endregion
		}

		/// <summary>
		/// If values will be equal, comparer returns -1. To prevent exceptions for events in the same moment
		/// </summary>
		private class DateTimeComparer : IComparer<DateTime>
		{
			public int Compare(DateTime x, DateTime y)
			{
				if (x == y)
				{
					return -1;
				}
				return x.CompareTo(y);
			}
		}
	}
}