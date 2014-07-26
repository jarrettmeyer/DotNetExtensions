using System.Collections.Generic;
using System.Linq;

namespace FusionAlliance.DotNetExtensions.Common.Collections
{
    public static class CollectionExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            return !collection.Any();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || collection.IsEmpty();
        }
    }
}
