using System;
using System.Globalization;

namespace TeamSL.Infrastructure.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ParseExactDate(this string str, string format)
        {
            return DateTime.ParseExact(str, format, CultureInfo.InvariantCulture);
        }
    }
}
