using System;

namespace FusionAlliance.DotNetExtensions.Common
{
    /// <summary>
    ///     Extension methods for the decimal type.
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        ///     Converts the value to an integer.
        /// </summary>
        public static int ToInt(this decimal d)
        {
            return Convert.ToInt32(d);
        }

        /// <summary>
        ///     Converts the value to a long.
        /// </summary>
        public static long ToLong(this decimal d)
        {
            return (long) d;
        }
    }
}