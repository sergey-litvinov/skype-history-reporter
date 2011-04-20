using System.Collections.Generic;
using SkypeHistory.Entities;

namespace SkypeHistory.Interfaces
{
	public interface ISkypeService
	{
		SkypeProfile[] GetProfiles();
	}

	public interface IChatRepository
	{
		IEnumerable<Chat> GetAll();
	    IEnumerable<Member> GetCurrentChatMembers(Chat chat);
        IEnumerable<Member> GetAlltimeChatMembers(Chat chat);
	    Member GetMember(string skypeName);
	    IEnumerable<Message> GetMessages(Chat chat);
	}
}