using System;
using System.Collections.Generic;
using System.Text;
using MadMoney.Utility;

namespace MadMoney.View
{
    public class ViewData
    {
        // When the app starts, set the currently displayed month
        // Discard partial data, set the DateTime to be the first of the month.
        // Day-of-the month has no meaning, so best to have it be the same
        // for all of them.
        public ViewData()
        {
            CurrentlyDisplayedMonthYear = DateTimeUtility.TruncateToMonthYear(DateTime.Today);
        }

        public DateTime CurrentlyDisplayedMonthYear { get; set; }

    }
}
