using System;
using System.Collections.Generic;
using System.Text;

namespace NETCore.Extensions
{
    public static class LongExtensions
    {
        /// <summary>
        /// timestamp parse to datetime
        /// </summary>
        /// <param name="timeStamp">time stamp value</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timeStamp)
        {
            DateTime dateTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return dateTimeStart.AddSeconds(timeStamp);
        }
    }
}
