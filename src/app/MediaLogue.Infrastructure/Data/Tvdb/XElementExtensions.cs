using System;
using System.Globalization;
using System.Xml.Linq;

namespace MediaLogue.Infrastructure.Data.Tvdb
{
    public static class XElementExtensions
    {
        public static int? ElementAsInt(this XElement parent, string element)
        {
            int result;
            var value = parent.ElementAsString(element);
            if (value != null && int.TryParse(value, out result))
            {
                return result;
            }

            return null;
        }

        public static string ElementAsString(this XElement parent, string element, bool trim = false)
        {
            var child = parent.Element(element);
            return trim ? child.Value.Trim() : child.Value;
        }

        public static DateTime? ElementFromEpochToDateTime(this XElement parent, string element)
        {
            var epoch = ElementAsInt(parent, element);
            if (epoch.HasValue)
            {
                return epoch.Value.ToDateTime();
            }

            return null;
        }

        public static DateTime? ElementAsDateTime(this XElement parent, string element)
        {
            DateTime result;
            var value = parent.ElementAsString(element);
            if (value != null && DateTime.TryParse(value, out result))
            {
                return result;
            }

            return null;
        }

        public static TimeSpan? ElementAsTimeSpan(this XElement parent, string element)
        {
            DateTime result;
            var value = parent.ElementAsString(element);
            if (value != null && DateTime.TryParse(value, out result))
            {
                return result.TimeOfDay;
            }

            return null;
        }

        public static TEnum? ElementAsEnum<TEnum>(this XElement parent, string element) where TEnum : struct
        {
            TEnum result;
            var value = ElementAsString(parent, element);
            if (value != null && Enum.TryParse(value, out result))
            {
                return result;
            }

            return null;
        }

        public static double? ElementAsDouble(this XElement parent, string element)
        {
            double result;
            var value = parent.ElementAsString(element);
            if (value != null && double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }

            return null;
        }
    }
}