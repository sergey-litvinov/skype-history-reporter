using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using SkypeHistory.Entities;
using SkypeHistory.Infrastructure;
using SkypeHistory.Interfaces;
using Chat = SkypeHistory.Entities.Chat;
using Message = SkypeHistory.Entities.Message;

namespace SkypeHistory.DB.Sqlite
{
	internal class SqliteChatRepository : BaseSqliteRepository, IChatRepository
	{
		public IEnumerable<Chat> GetAll()
		{
		    return ExecuteReaderItems<Chat>("SELECT * FROM Chats", Fill);
		}

        public IEnumerable<Member> GetCurrentChatMembers(Chat chat)
        {
            var members = ExecuteReaderItems<Member>("SELECT * FROM ChatMembers Where chatname = @name",
                                                     (reader, member) =>
                                                         {
                                                             member.Name = reader.GetObject<string>("identity");
                                                         },
                                                     new[] {CreateParameter("@name", chat.Name)});
            members = LoadMembers(members.Select(m => m.Name));
            return members;
        }

	    public IEnumerable<Member> GetAlltimeChatMembers(Chat chat)
	    {
            IEnumerable<string> participants = new List<string>();
	        participants = participants.Union(chat.Participants.Split(' '));
            participants = participants.Union(chat.ActiveMembers.Split(' '));
            participants = participants.Union(chat.Posters.Split(' '));
            var members = LoadMembers(participants);
	        return members;
	    }

	    public Member GetMember(string skypeName)
	    {
	        return LoadMembers(new[] {skypeName}).FirstOrDefault();
	    }


        public IEnumerable<Message> GetMessages(Chat chat)
        {
            var query = string.Format("SELECT * FROM Messages WHERE chatname = '{0}'", chat.Name);
        	return ExecuteReaderItems<Message>(query, Fill);
        }

		private IEnumerable<Member> LoadMembers(IEnumerable<string> participants)
        {
            var plainMembers = String.Join(",", participants.Select(s => string.Format("'{0}'", s)).ToArray());
            var query = string.Format("SELECT * FROM Contacts WHERE skypename in ({0})", plainMembers);
            var result = ExecuteReaderItems<Member>(query,
                                              (reader, member) =>
                                                  {
                                                      member.Id = reader.GetValueObject<long>("id");
                                                      member.Name = reader.GetObject<string>("skypename");
                                                      member.FullName = reader.GetObject<string>("fullname");
                                                      member.DisplayName = reader.GetObject<string>("displayname");
                                                  });
            if (!result.Any())
            {
                // try to load from Accounts table if requested member is account owner
                query = string.Format("SELECT * FROM Accounts WHERE skypename in ({0})", plainMembers);
                result = ExecuteReaderItems<Member>(query,
                                              (reader, member) =>
                                              {
                                                  member.Id = reader.GetValueObject<long>("id");
                                                  member.Name = reader.GetObject<string>("skypename");
                                                  member.FullName = reader.GetObject<string>("fullname");
                                                  member.DisplayName = reader.GetObject<string>("fullname");
                                              });
            }
	        return result;
        }

		public IEnumerable<Chat> GetChats(DateTime @from, DateTime to)
		{
			var query = string.Format("SELECT * FROM Chats WHERE timestamp >= {0} AND timestamp <= {1}", DateUtils.ConvertToLinuxStamp(from), DateUtils.ConvertToLinuxStamp(to));
			var chats = ExecuteReaderItems<Chat>(query,
											   this.Fill).ToList();
			return chats;
		}

		public IEnumerable<Message> GetMessages(DateTime from, DateTime to)
		{
			var query = string.Format("SELECT * FROM Messages WHERE timestamp >= {0} AND timestamp <= {1}", DateUtils.ConvertToLinuxStamp(from), DateUtils.ConvertToLinuxStamp(to));
			return ExecuteReaderItems<Message>(query, Fill);
		}

		public Chat GetChat(string chatname)
		{
			var chats = ExecuteReaderItems<Chat>("SELECT * FROM Chats WHERE name = @name",			
											   this.Fill,
											   new[] { CreateParameter("@name", chatname) }).ToList();
			return chats.FirstOrDefault();
		}

		private void Fill(DbDataReader reader, Chat chat)
		{
			chat.Name = reader.GetObject<string>("name") ?? "";
			chat.Id = reader.GetValueObject<long>("id");
			chat.Topic =
				reader.GetObject<string>("topic") ?? "";
			chat.FriendlyName =
				reader.GetObject<string>("friendlyname") ?? "";
			chat.Posters =
				reader.GetObject<string>("posters") ?? "";
			chat.Participants =
				reader.GetObject<string>("participants") ?? "";
			chat.Adder = reader.GetObject<string>("adder");
			chat.Picture = reader.GetObject<byte[]>("picture");
			chat.ActiveMembers =
				reader.GetObject<string>(
					"activemembers") ?? "";
			var timestamp =
				reader.GetValueObject<long>(
					"last_change");
			chat.LastChange = DateUtils.ConvertFromLinuxStamp(timestamp);
		}

		private void Fill(DbDataReader reader, Message message)
		{
			message.ConversationId = reader.GetValueObject<long>("convo_id");
			message.ChatName = reader.GetObject<string>("chatname");
			message.Text = reader.GetObject<string>("body_xml");
			message.Author = reader.GetObject<string>("author");
			var stamp = reader.GetValueObject<long>("timestamp");

			message.Timestamp = DateUtils.ConvertFromLinuxStamp(stamp);
		}

	}
}