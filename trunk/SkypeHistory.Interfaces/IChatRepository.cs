using System;
using System.Collections.Generic;

using SkypeHistory.Entities;

namespace SkypeHistory.Interfaces
{
	public interface IChatRepository
	{
		IEnumerable<Chat> GetAll();
		IEnumerable<Chat> GetChats(DateTime from, DateTime to);
		IEnumerable<Member> GetCurrentChatMembers(Chat chat);
		IEnumerable<Member> GetAlltimeChatMembers(Chat chat);
		Member GetMember(string skypeName);
		IEnumerable<Message> GetMessages(Chat chat);
		IEnumerable<Message> GetMessages(DateTime from, DateTime to);
		Chat GetChat(string name);
	}
}