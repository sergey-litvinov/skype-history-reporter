using System;

namespace SkypeHistory.Infrastructure
{
    public static class DateUtils
    {
        public static DateTime ConvertFromLinuxStamp(long timestamp)
        {
            DateTime baseTime = new DateTime(1970, 1, 1);
            return baseTime.AddSeconds(timestamp);
        }

        public static DateTime GetMonth(DateTime timestamp)
        {
            return new DateTime(timestamp.Year, timestamp.Month, 1);
        }
    }
}