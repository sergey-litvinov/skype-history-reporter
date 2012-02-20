using SkypeHistory.Entities;

namespace SkypeHistory.Interfaces
{
	public interface ISkypeService
	{
		SkypeProfile[] GetProfiles();
	}
}