using System;

namespace FusionAlliance.DotNetExtensions.Common
{
    public static class TimeSpanExtensions
    {
        public static DateTime Ago(this TimeSpan value)
        {
            return DateTime.UtcNow - value;
        }

        public static DateTime FromNow(this TimeSpan value)
        {
            return DateTime.Now + value;
        }
    }
}