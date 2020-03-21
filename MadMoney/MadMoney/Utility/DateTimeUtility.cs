using System;
using System.Collections.Generic;
using System.Text;

namespace MadMoney.Utility
{
    public static class DateTimeUtility
    {
        public static DateTime TruncateToMonthYear(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
            // Interested to try what happens when set the day-of-month to zero
        }

        public static bool IsSameMonthYear(DateTime date1, DateTime date2)
        {
            return (date1.Year == date2.Year) && (date1.Month == date2.Month);
        }

    }
}
