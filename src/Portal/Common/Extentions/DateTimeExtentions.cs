using Portal.Common.Helpers;
using System;

namespace Portal.Common.Extentions
{
    public static class DateTimeExtentions
    {
        public static string ToPersianDate(this DateTime dateTime)
        {
            return PersianDateHelper.GetPersianDate(dateTime);
        }

        public static string ToPersianDateTime(this DateTime dateTime)
        {
            return PersianDateHelper.GetPersianDateTime(dateTime);
        }

        public static string ToFullPersianDateTime(this DateTime dateTime)
        {
            return PersianDateHelper.GetFullPersianDateTime(dateTime);
        }

        public static string ToFullPersianDate(this DateTime dateTime)
        {
            return PersianDateHelper.GetFullPersianDate(dateTime);
        }

        public static bool InRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return PersianDateHelper.DateInRange(dateToCheck, startDate, endDate);
        }
    }
}