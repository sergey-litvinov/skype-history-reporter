using System;
using System.Diagnostics;

namespace SkypeHistory.Entities
{
    [DebuggerDisplay("{Id} - {DisplayName}")]
    public class Member
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public string DisplayName { get; set; }

        public long Id { get; set; }
    }
}