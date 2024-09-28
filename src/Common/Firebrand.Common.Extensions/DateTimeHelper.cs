using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebrand.Common.Extensions
{
    public static class DateTimeHelper
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = DateTime.UnixEpoch;
            return dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}
