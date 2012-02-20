using System;
using System.Diagnostics;

namespace SkypeHistory.Entities
{
	[DebuggerDisplay("{Host_Identity} - {Start}")]
	public class Call
	{
		public long Id { get; set; }
		public string Host_Identity { get; set; }
		public DateTime Start { get; set; }
		public TimeSpan Duration { get; set; }
	}
}