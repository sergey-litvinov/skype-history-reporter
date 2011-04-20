using System;
using SkypeHistory.Entities;
using SkypeHistory.Interfaces;

namespace SkypeHistory.Infrastructure
{
    public class ProfileHolder : IProfileHolder
    {
        public SkypeProfile Current { get; set; }

        public Entities.Chat SelectedChat { get; set; }
    }
}