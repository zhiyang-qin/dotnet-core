using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.BLL.Calendar
{
    public static class DateTimeHelper
    {
        public static DateTime GetEndOfMonth(int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month, 1);
            dt.AddMonths(1).AddDays(-1);
            return dt;
        }

        public static DateTime GetEndOfMonth(int Year, int Month)
        {
            return new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
        }

        public static DateTime GetEndOfMonth(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
        }

        public static DateTime GetNearDayOfWeek(DateTime dtmDate, ECALENDARCYCLE_DATEOFWEEK ePdDayWeekEnum)
        {
	        int iDayDiff = ((short)(ePdDayWeekEnum) - DateTimeHelper.Weekday (dtmDate));
            DateTime retDate;

	        if (Math.Abs(iDayDiff) < 4)
		        retDate = dtmDate.AddDays(+ iDayDiff);
	        else if (iDayDiff > 0)
		        retDate = dtmDate.AddDays(- (7 - iDayDiff));
	        else
		        retDate = dtmDate.AddDays(+ (7 + iDayDiff));

	        return retDate;
        }

        public static bool IsValid(DateTime dt)
        {
            if (dt >= new DateTime(1920, 1, 1))
                return true;
            else
                return false;
        }

        public static short Weekday(DateTime dt)
        {
            switch (dt.DayOfWeek)
            {
                case   DayOfWeek.Sunday:
                    return (short)ECALENDARCYCLE_DATEOFWEEK.DATEOFWEEK_SUNDAY;
                case DayOfWeek.Monday:
                    return (short)ECALENDARCYCLE_DATEOFWEEK.DATEOFWEEK_MONDAY;
                case DayOfWeek.Tuesday:
                    return (short)ECALENDARCYCLE_DATEOFWEEK.DATEOFWEEK_TUESDAY;
                case DayOfWeek.Wednesday:
                    return (short)ECALENDARCYCLE_DATEOFWEEK.DATEOFWEEK_WEDNESDAY;
                case DayOfWeek.Thursday:
                    return (short)ECALENDARCYCLE_DATEOFWEEK.DATEOFWEEK_THURSDAY;
                case DayOfWeek.Friday:
                    return (short)ECALENDARCYCLE_DATEOFWEEK.DATEOFWEEK_FRIDAY;
                case DayOfWeek.Saturday:
                    return (short)ECALENDARCYCLE_DATEOFWEEK.DATEOFWEEK_SATURDAY;
                default:
                    return (short)ECALENDARCYCLE_DATEOFWEEK.DATEOFWEEK_SUNDAY;
            }
        }
    }
}
