using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nCroner.Core.Tools
{
    public static class DateUtils
    {
        public static DateTime GetDateByTimeZone(string timeZone)
        {
            return GetDateByTimeZone(DateTime.UtcNow, timeZone);
        }

        public static DateTime GetDateByTimeZone(DateTime time, string timeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(time.ToUniversalTime(),
                TimeZoneInfo.FindSystemTimeZoneById(timeZone));
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static DateTime ByTimeZone(this DateTime time, string timeZone)
        {
            return string.IsNullOrWhiteSpace(timeZone)
                ? time
                : GetDateByTimeZone(time, timeZone);
        }
    }
}