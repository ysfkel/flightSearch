using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1
{
    public class DateHelpers
    {
        public static DateTime GetDate(long time)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(time);
            DateTime dateTime = dateTimeOffset.UtcDateTime;
            return dateTime;
        }


        public static string GetTime(DateTime date)
        {
            return date.ToString("h:mm tt");
        }

        public static string GetDayOfWeekString(DateTime date)
        {
            return date.DayOfWeek.ToString();
        }

        public static int GetDayOfWeekNumber(DateTime date)
        {
            return (int)date.DayOfWeek;
        }
    }
}