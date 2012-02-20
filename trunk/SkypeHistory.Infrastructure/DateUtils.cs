using System;

namespace SkypeHistory.Infrastructure
{
    public static class DateUtils
    {
		private static DateTime baseTime = new DateTime(1970, 1, 1);

		public static DateTime ConvertFromLinuxStamp(long timestamp)
        {
            return baseTime.AddSeconds(timestamp);
        }

		public static long ConvertToLinuxStamp(DateTime value)
		{
			return (int)(value - baseTime).TotalSeconds;
		}

        public static DateTime GetMonth(DateTime timestamp)
        {
            return new DateTime(timestamp.Year, timestamp.Month, 1);
        }
    }
}