using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Arendelle.Safety.OCSOCalls.Core.Interfaces;

namespace Arendelle.Safety.OCSOCalls.Core.Extensions
{
    public static class CallExtensions
    {
        public static int ZoneAsNumeric(this ICall Call)
        {
            var strZone = Regex.Replace(Call.Zone, @"[A-Z]*", @"");
            var iZone = 0;
            var bZone = int.TryParse(strZone, out iZone);
            return iZone;
        }

        public static DateTime EntryAsTimestamp(this ICall Call)
        {
            return DateTime.Parse(Call.Entry);
        }

        public static TimeSpan TimeActive(this ICall Call)
        {
            // This will change - we will also need to create a TODO for Sunshine Date Time Law
            var tzCurrent = TimeZoneInfo.FindSystemTimeZoneById(@"Eastern Standard Time");
            var dtCurrent = DateTime.UtcNow;

            var dtLocal = TimeZoneInfo.ConvertTimeFromUtc(dtCurrent, tzCurrent);
            var dtCall = Call.EntryAsTimestamp();

            var tsDifference = dtLocal.Subtract(dtCall);
            return tsDifference;
        }
    }
}
