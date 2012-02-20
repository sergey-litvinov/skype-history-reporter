using System;
using System.Collections.Generic;
using System.Data.Common;

using SkypeHistory.Entities;
using SkypeHistory.Infrastructure;
using SkypeHistory.Interfaces;

namespace SkypeHistory.DB.Sqlite
{
	internal class SqliteCallRepository : BaseSqliteRepository,  ICallRepository
	{
		public IEnumerable<Call> GetAll()
		{
			var calls = ExecuteReaderItems<Call>("SELECT * FROM Calls", Fill);
			return calls;
		}

		public IEnumerable<Call> GetCalls(DateTime @from, DateTime to)
		{
			var query = string.Format("SELECT * FROM Calls WHERE begin_timestamp >= {0} AND (begin_timestamp+duration) <= {1}", DateUtils.ConvertToLinuxStamp(from), DateUtils.ConvertToLinuxStamp(to));
			var calls = ExecuteReaderItems<Call>(query, Fill);
			return calls;			
		}


		public IEnumerable<Member> GetCallMembers(Call call)
		{
			var members = ExecuteReaderItems<Member>("SELECT * FROM CallMembers WHERE call_db_id = @callid",
                                                     (reader, member) =>
                                                         {
                                                            member.Name = reader.GetObject<string>("identity");
                                                         	member.DisplayName = reader.GetObject<string>("dispname");
                                                         },
													 new[] { CreateParameter("@callid", call.Id) });
            return members;
		}
		private void Fill(DbDataReader reader, Call call)
		{
			call.Start = DateUtils.ConvertFromLinuxStamp(reader.GetValueObject<long>("begin_timestamp"));
			call.Duration = TimeSpan.FromSeconds(reader.GetValueObject<long>("duration"));
			call.Host_Identity = reader.GetObject<string>("host_identity");
			call.Id = reader.GetValueObject<long>("id");
		}
	}
}