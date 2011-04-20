using System;
using System.Diagnostics;

namespace SkypeHistory.Entities
{
    [DebuggerDisplay("{Id} - {Topic} - {FriendlyName}")]
	public class Chat
	{
		public string Topic { get; set; }

	    public string FriendlyName { get; set; }

	    public long Id { get; set; }

        public string Posters { get; set; }

        public string Adder { get; set; }

        public byte[] Picture { get; set; }

        public DateTime LastChange { get; set; }

        public string ActiveMembers { get; set; }

        public string Participants { get; set; }

        public string Name { get; set; }

        public string DisplayName
        {
            get
            {
                if (!string.IsNullOrEmpty(Topic))
                    return Topic;
                return FriendlyName;
            }
        }

        public string UsefullName
        {
            get { return string.Format("{0:dd-MM-yy hh:mm}: {1}", LastChange, DisplayName); }
        }
	}
}