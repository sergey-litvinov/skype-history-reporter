using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SkypeHistory.Entities;
using SkypeHistory.Interfaces;

namespace SkypeHistory.Infrastructure
{
	public class SkypeService : ISkypeService
	{
		public bool IsSkypeRunning()
		{
			return Process.GetProcessesByName("skype").Length != 0;
		}

		public SkypeProfile[] GetProfiles()
		{
			string[] ignoredFolders = new []{"Content", "My Skype Received Files", "Pictures", "shared_"};

			var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var path = Path.Combine(appData, "skype");
			var dirInfo = new DirectoryInfo(path);
			if (!dirInfo.Exists)
			{
				return new SkypeProfile[0];
			}
			var profiles = dirInfo.
				GetDirectories().
				Where(d => !ignoredFolders.
					Any(id => d.Name.StartsWith(id)))
                .Where(d => !d.Name.Contains("#"))
				.ToList();
		    return profiles.
		        OrderBy(p => p.Name).
		        Select(p => new SkypeProfile()
		                        {
		                            Location = p.FullName,
		                            Name = p.Name
		                        }).ToArray();
		}

	}
}