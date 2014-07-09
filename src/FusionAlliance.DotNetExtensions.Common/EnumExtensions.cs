using System;
using System.Collections.Generic;
using System.Linq;

namespace FusionAlliance.DotNetExtensions.Common
{
    /// <summary>
    ///     Extension methods for enums.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///     Gets the custom attributes of the specified type.
        /// </summary>
        /// <typeparam name="T">The specified custom attribute type</typeparam>
        /// <param name="enumValue">Internal use only.</param>
        /// <returns>The custom attributes of the specified type.</returns>
        public static IEnumerable<T> GetCustomAttributes<T>(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof (T), false);
            return attributes.Cast<T>();
        }
    }
}