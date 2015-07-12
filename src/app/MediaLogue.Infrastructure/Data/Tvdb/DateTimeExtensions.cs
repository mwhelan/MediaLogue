using System;
using System.Collections.Generic;

namespace MediaLogue.Infrastructure.Data.Tvdb
{
    /// <summary>
    /// Provides Date and Time extension methods.
    /// </summary>
    public static class DateTimeExtensions
    {
        public static DateTime ToDateTime(this int unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime).ToLocalTime();
        }
    }
    public static class StringExtensions
    {
        public static IReadOnlyCollection<string> SplitByPipe(this string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return null;

            return raw.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}