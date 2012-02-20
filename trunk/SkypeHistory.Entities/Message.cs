using System;
using System.Diagnostics;

namespace SkypeHistory.Entities
{
    [DebuggerDisplay("{Author} - {Text}")]
	public class Message
	{
    	public string ChatName { get; set; }

    	public string Text { get; set; }

	    public string Author { get; set; }

	    public DateTime Timestamp { get; set; }

    	public long ConversationId { get; set; }
	}
}