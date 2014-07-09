using System;
using System.Linq;

namespace FusionAlliance.DotNetExtensions.Common
{
    /// <summary>
    ///     Extension methods for the <see cref="Uri" /> type.
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        ///     Gets the originalUri minus the query string. If originalUri has no query string then the originalUri is returned.
        /// </summary>
        public static Uri GetBaseUri(this Uri originalUri)
        {
            var queryDelimiterIndex = originalUri.AbsoluteUri.IndexOf("?", StringComparison.Ordinal);
            return queryDelimiterIndex < 0
                ? originalUri
                : new Uri(originalUri.AbsoluteUri.Substring(0, queryDelimiterIndex));
        }

        /// <summary>
        ///     Gets the query portion of the uri without the leading question mark.
        /// </summary>
        public static string QueryWithoutLeadingQuestionMark(this Uri uri)
        {
            const int indexToSkipQueryDelimiter = 1;
            return uri.Query.Length > 1 ? uri.Query.Substring(indexToSkipQueryDelimiter) : string.Empty;
        }

        /// <summary>
        ///     Gets the portion of the uri remaining after skipping to the specified segment.
        /// </summary>
        /// <param name="uri">The object of the operation. Internal use only.</param>
        /// <param name="startingSegmentNumber">The first segment to include in the response (0-based).</param>
        public static string GetPathFragment(this Uri uri, int startingSegmentNumber)
        {
            var fragment = string.Join("", uri.Segments, startingSegmentNumber,
                uri.Segments.Count() - startingSegmentNumber);
            return fragment;
        }
    }
}