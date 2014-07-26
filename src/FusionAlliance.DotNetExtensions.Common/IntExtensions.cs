using System;

namespace FusionAlliance.DotNetExtensions.Common
{
    /// <summary>
    ///     Extension methods for the <see cref="int" /> type.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        ///     Returns the number of days as a time span.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Number of days</returns>
        public static TimeSpan Days(this int value)
        {
            return TimeSpan.FromDays(value);
        }

        /// <summary>
        ///     Computes the value, bounded by the specified min and max.
        /// </summary>
        /// <param name="value">
        ///     The value. Internal use only.
        /// </param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <returns>
        ///     <paramref name="value" />, bounded by the specified <paramref name="min" /> and <paramref name="max" />.
        /// </returns>
        public static int GetBoundedValue(this int value, int min, int max)
        {
            var boundedValue = Math.Min(Math.Max(value, min), max);
            return boundedValue;
        }

        /// <summary>
        ///     Computes the value, bounded by the specified min.
        /// </summary>
        /// <param name="value">
        ///     The value. May be null. Internal use only.
        /// </param>
        /// <param name="defaultValue">The default value, if <paramref name="value" /> is null.</param>
        /// <param name="min">The min value.</param>
        /// <returns>
        ///     <paramref name="value" /> (or <paramref name="defaultValue" /> if <paramref name="value" /> is null), bounded by
        ///     the specified <paramref name="min" />.
        /// </returns>
        public static int GetBoundedValue(this int? value, int defaultValue, int min)
        {
            var valToBound = value ?? defaultValue;
            var boundedValue = Math.Max(valToBound, min);
            return boundedValue;
        }

        /// <summary>
        ///     Computes the value, bounded by the specified min and max.
        /// </summary>
        /// <param name="value">
        ///     The value. May be null. Internal use only.
        /// </param>
        /// <param name="defaultValue">The default value, if <paramref name="value" /> is null.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value</param>
        /// <returns>
        ///     <paramref name="value" /> (or <paramref name="defaultValue" /> if <paramref name="value" /> is null), bounded by
        ///     the specified <paramref name="min" /> and <paramref name="max" />.
        /// </returns>
        public static int GetBoundedValue(this int? value, int defaultValue, int min, int max)
        {
            var valToBound = value ?? defaultValue;
            var boundedValue = GetBoundedValue(valToBound, min, max);
            return boundedValue;
        }

        /// <summary>
        ///     Computes the value, bounded by the specified min.
        /// </summary>
        /// <param name="value">
        ///     The value. May be null. Internal use only.
        /// </param>
        /// <param name="min">The min value.</param>
        /// <returns>
        ///     <paramref name="value" />, bounded by the specified <paramref name="min" />. Will be null if
        ///     <paramref name="value" /> is null.
        /// </returns>
        public static int? GetBoundedOptionalValue(this int? value, int min)
        {
            return value == null ? (int?) null : GetBoundedValue(value, value.Value, min);
        }

        /// <summary>
        ///     Computes the value, bounded by the specified min and max.
        /// </summary>
        /// <param name="value">
        ///     The value. May be null. Internal use only.
        /// </param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <returns>
        ///     <paramref name="value" />, bounded by the specified <paramref name="min" /> and <paramref name="max" />. Will be
        ///     null if <paramref name="value" /> is null.
        /// </returns>
        public static int? GetBoundedOptionalValue(this int? value, int min, int max)
        {
            return value == null ? (int?) null : GetBoundedValue(value.Value, min, max);
        }

        /// <summary>
        ///     Returns the number of hours as a time span.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Number of hours</returns>
        public static TimeSpan Hours(this int value)
        {
            return TimeSpan.FromHours(value);
        }

        /// <summary>
        ///     Returns the number of milliseconds as a time span.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Number of days</returns>
        public static TimeSpan Milliseconds(this int value)
        {
            return TimeSpan.FromMilliseconds(value);
        }

        /// <summary>
        ///     Returns the number of minutes as a time span.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Number of days</returns>
        public static TimeSpan Minutes(this int value)
        {
            return TimeSpan.FromMinutes(value);
        }

        /// <summary>
        ///     Returns the number of seconds as a time span.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Number of days</returns>
        public static TimeSpan Seconds(this int value)
        {
            return TimeSpan.FromSeconds(value);
        }
    }
}