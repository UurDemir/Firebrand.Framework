using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebrand.Common.Extensions;

/// <summary>
/// Provides helper methods for DateTime operations.
/// </summary>
public static class DateTimeHelper
{
    /// <summary>
    /// Converts a Unix timestamp to a local DateTime.
    /// </summary>
    /// <param name="unixTimeStamp">The Unix timestamp, which is the number of seconds that have elapsed since 1970-01-01T00:00:00Z (UTC).</param>
    /// <returns>A DateTime object that represents the local time equivalent of the Unix timestamp.</returns>
    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        DateTime dateTime = DateTime.UnixEpoch;
        return dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
    }
}
