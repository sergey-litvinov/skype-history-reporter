using System;
using System.Collections.Generic;

using SkypeHistory.Entities;

namespace SkypeHistory.Interfaces
{
	public interface ICallRepository
	{
		IEnumerable<Call> GetAll();
		IEnumerable<Call> GetCalls(DateTime from, DateTime to);
		IEnumerable<Member> GetCallMembers(Call call);
	}
}