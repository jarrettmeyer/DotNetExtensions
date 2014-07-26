using System;

namespace FusionAlliance.DotNetExtensions.Common
{
    public static class DoubleExtensions
    {
        public static TimeSpan Days(this double value)
        {
            return TimeSpan.FromDays(value);
        }

        public static TimeSpan Hours(this double value)
        {
            return TimeSpan.FromHours(value);
        }

        public static TimeSpan Milliseconds(this double value)
        {
            return TimeSpan.FromMilliseconds(value);
        }

        public static TimeSpan Minutes(this double value)
        {
            return TimeSpan.FromMinutes(value);
        }

        public static TimeSpan Seconds(this double value)
        {
            return TimeSpan.FromSeconds(value);
        }
    }
}
