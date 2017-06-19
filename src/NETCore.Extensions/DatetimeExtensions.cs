using System;
using System.Collections.Generic;
using System.Text;

namespace NETCore.Extensions
{
    public static class DatetimeExtensions
    {
        /// <summary>
        /// get time stamp
        /// </summary>
        /// <param name="time">需要转换时间</param>
        /// <returns></returns>
        public static long TimeStamp(this DateTime time)
        {
            TimeSpan ts = time.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }
    }
}
