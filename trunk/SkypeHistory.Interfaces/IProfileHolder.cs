using SkypeHistory.Entities;

namespace SkypeHistory.Interfaces
{
    public interface IProfileHolder
    {
        SkypeProfile Current { get; set; }

        Chat SelectedChat { get; set; }
    }
}