using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using SkypeHistory.Entities;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Interfaces;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Infrastructure.Generators
{
    public abstract class MessageReportGenerator : IReportGenerator
    {
        [Dependency]
        public IChatRepository ChatRepository { get; set; }

        [Dependency]
        public IProfileHolder ProfileHolder { get; set; }

        [Dependency]
        public ICacheService CacheService { get; set; }

        public abstract string Name { get; }

        public abstract void Generate(ReportContext context);

        protected IEnumerable<Entities.Message> GetMessages()
        {
            string key = "GetMessages" + ProfileHolder.SelectedChat.Name;
            return CacheService.Get(key, () => ChatRepository.GetMessages(ProfileHolder.SelectedChat));            
        }

        protected Entities.Member GetMember(string skypeName)
        {
            var memberKey = "Member" + skypeName;
            var member = CacheService.Get(memberKey, () => ChatRepository.GetMember(skypeName));
			if (member == null)
			{
				return new Member()
				       	{
				       		DisplayName = skypeName,
				       		FullName = skypeName,
				       		Name = skypeName,
				       		Id = -1
				       	};
			}
        	return member;
        }

    }
}