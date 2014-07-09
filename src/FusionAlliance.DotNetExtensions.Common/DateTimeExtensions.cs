using System;

namespace FusionAlliance.DotNetExtensions.Common
{
    /// <summary>
    ///     Extension methods for the <see cref="DateTime" /> type.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Converts the DateTime to a string in the form of yyyy-MM-dd.
        /// </summary>
        /// <returns>
        ///     The DateTime as a string in the form of yyyy-MM-dd.
        /// </returns>
        public static string ToUrlFriendlyDate(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        /// <summary>
        ///     Computes the date corresponding to the first day of the month (no time component).
        /// </summary>
        /// <returns>
        ///     The date corresponding to the first day of the month (no time component).
        /// </returns>
        public static DateTime DateOfFirstDayInMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        /// <summary>
        ///     Computes the date corresponding to the last day of the month (no time component).
        /// </summary>
        /// <returns>
        ///     The date corresponding to the last day of the month (no time component).
        /// </returns>
        public static DateTime DateOfLastDayInMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
        }

        /// <summary>
        ///     Computes the total number of seconds since the beginning of the Unix Epoch.
        /// </summary>
        /// <returns>
        ///     The total number of seconds since the beginning of the Unix Epoch. May be negative.
        /// </returns>
        public static long ToEpoch(this DateTime dateTime)
        {
            var timeDiff = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return (long) timeDiff.TotalSeconds;
        }

        /// <summary>
        ///     Computes a new DateTime that is updated with the specified month. Will bound, as needed.
        /// </summary>
        /// <returns>
        ///     A new DateTime that is updated with the specified month, bounded as needed.
        /// </returns>
        public static DateTime SetMonthSafe(this DateTime current, Month month)
        {
            month = month > Month.December
                ? Month.December
                : month < Month.January ? Month.January : month;

            var monthAsInt = (int) month;
            var day = GetBoundedDay(current.Year, monthAsInt, current.Day);
            return new DateTime(current.Year, monthAsInt, day, current.Hour, current.Minute,
                current.Second);
        }

        /// <summary>
        ///     Bounds the specified day so that it is valid for the specified month and year.
        /// </summary>
        /// <returns>
        ///     The specified day, bounded as necessary to be valid for the specified month and year.
        /// </returns>
        public static int GetBoundedDay(int year, int month, int day)
        {
            var maxDaysInMonth = DateTime.DaysInMonth(year, month);
            return day > maxDaysInMonth
                ? maxDaysInMonth
                : day < DateTimeConstants.FirstDayInMonth ? DateTimeConstants.FirstDayInMonth : day;
        }

        /// <summary>
        ///     Computes a new DateTime that is updated with the specified day. Will bound, as needed.
        /// </summary>
        /// <returns>
        ///     A new DateTime that is updated with the specified day, bounded as needed.
        /// </returns>
        public static DateTime SetDaySafe(this DateTime current, int day)
        {
            day = GetBoundedDay(current.Year, current.Month, day);
            return new DateTime(current.Year, current.Month, day, current.Hour, current.Minute,
                current.Second);
        }

        /// <summary>
        ///     Computes a new DateTime that is updated with the specified year. Will bound, as needed.
        /// </summary>
        /// <returns>
        ///     A new DateTime that is updated with the specified year, bounded as needed.
        /// </returns>
        public static DateTime SetYearSafe(this DateTime current, int year)
        {
            year = Math.Max(DateTime.MinValue.Year, year);
            var day = GetBoundedDay(year, current.Month, current.Day);
            return new DateTime(year, current.Month, day, current.Hour, current.Minute,
                current.Second);
        }

        /// <summary>
        ///     Computes a new DateTime that is updated with the specified hour. Will bound, as needed.
        /// </summary>
        /// <returns>
        ///     A new DateTime that is updated with the specified hour, bounded as needed.
        /// </returns>
        public static DateTime SetHourSafe(this DateTime current, int hour)
        {
            hour = hour > DateTimeConstants.MaxHourOn24HourClock
                ? DateTimeConstants.MaxHourOn24HourClock
                : hour < DateTimeConstants.MinHour ? DateTimeConstants.MinHour : hour;
            return new DateTime(current.Year, current.Month, current.Day, hour, current.Minute,
                current.Second);
        }

        /// <summary>
        ///     Computes a new DateTime that is updated with the specified minute. Will bound, as needed.
        /// </summary>
        /// <returns>
        ///     A new DateTime that is updated with the specified minute, bounded as needed.
        /// </returns>
        public static DateTime SetMinuteSafe(this DateTime current, int minute)
        {
            minute = minute > DateTimeConstants.MaxMinuteOnClock
                ? DateTimeConstants.MaxMinuteOnClock
                : minute < DateTimeConstants.MinMinute ? DateTimeConstants.MinMinute : minute;
            return new DateTime(current.Year, current.Month, current.Day, current.Hour, minute,
                current.Second);
        }

        /// <summary>
        ///     Computes a new DateTime that is updated with the specified second. Will bound, as needed.
        /// </summary>
        /// <returns>
        ///     A new DateTime that is updated with the specified second, bounded as needed.
        /// </returns>
        public static DateTime SetSecondSafe(this DateTime current, int second)
        {
            second = second > DateTimeConstants.MaxSecondOnClock
                ? DateTimeConstants.MaxSecondOnClock
                : second < DateTimeConstants.MinSecond ? DateTimeConstants.MinSecond : second;
            return new DateTime(current.Year, current.Month, current.Day, current.Hour, current.Minute,
                second);
        }

        /// <summary>
        ///     Computes the hour for a 12-hour clock.
        /// </summary>
        /// <returns>The hour, constrained to a 12-hour clock.</returns>
        public static int GetHourFor12HourClock(this DateTime current)
        {
            if (current.Hour == 0)
            {
                return DateTimeConstants.MaxHourOn12HourClock;
            }
            if (current.Hour > DateTimeConstants.MaxHourOn12HourClock)
            {
                return current.Hour - DateTimeConstants.MaxHourOn12HourClock;
            }

            return current.Hour;
        }

        /// <summary>
        ///     Determines whether the current DateTime is AM or PM.
        /// </summary>
        /// <returns>An appropriate <see cref="TimeAmPm" /> value, based on the provided DateTime.</returns>
        public static TimeAmPm GetTimeAmPm(this DateTime current)
        {
            return current.Hour >= DateTimeConstants.MaxHourOn12HourClock
                ? TimeAmPm.Pm
                : TimeAmPm.Am;
        }

        /// <summary>
        ///     Computes a new DateTime based on the current DateTime and the specified <see cref="TimeAmPm" /> value.
        /// </summary>
        /// <returns>
        ///     A DateTime, adjusted for the specified <see cref="TimeAmPm" /> value.
        /// </returns>
        public static DateTime AdjustHour(this DateTime current, TimeAmPm timeAmPm)
        {
            if (current.Hour == DateTimeConstants.MinHour)
            {
                return timeAmPm == TimeAmPm.Pm
                    ? current.SetHourSafe(current.Hour + DateTimeConstants.MaxHourOn12HourClock)
                    : current;
            }
            if (current.Hour < DateTimeConstants.MaxHourOn12HourClock && timeAmPm == TimeAmPm.Pm)
            {
                return current.SetHourSafe(current.Hour + DateTimeConstants.MaxHourOn12HourClock);
            }
            if (current.Hour > DateTimeConstants.MaxHourOn12HourClock && timeAmPm == TimeAmPm.Am)
            {
                return current.SetHourSafe(current.Hour - DateTimeConstants.MaxHourOn12HourClock);
            }
            if (current.Hour == DateTimeConstants.MaxHourOn12HourClock)
            {
                if (timeAmPm == TimeAmPm.Am)
                {
                    return current.SetHourSafe(DateTimeConstants.MinHour);
                }
            }

            return current;
        }
    }
}