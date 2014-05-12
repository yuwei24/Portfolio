using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Common
{
    public class DateHelper
    {
        public static DateTime GetAsOfDate()
        {
            DateTime now = DateTime.Now.Date;
            DateTime asOfDate = DateTime.Now.Date;

            if (now.DayOfWeek == DayOfWeek.Monday)
                asOfDate = now.AddDays(-3);
            else if (now.DayOfWeek == DayOfWeek.Sunday)
                asOfDate = now.AddDays(-2);
            else
                asOfDate = now.AddDays(-1);

            return asOfDate;
        }
    }
}
