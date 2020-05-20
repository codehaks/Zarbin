using System;
using System.Globalization;

namespace Portal.Common.Helpers
{
    public static class PersianDateHelper
    {
        private static readonly PersianCalendar PersianCalendar = new PersianCalendar();

        public static bool DateInRange(DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck >= startDate && dateToCheck < endDate;
        }

        public static string GetPersianDate(DateTime? dateTime)
        {
            try
            {
                if (dateTime.HasValue && DateInRange(dateTime.Value, DateTime.MinValue, DateTime.MaxValue))
                {
                    var perDate = PersianCalendar.GetYear(dateTime.Value) % 100 + "/" +
                                  PersianCalendar.GetMonth(dateTime.Value) + "/" +
                                  PersianCalendar.GetDayOfMonth(dateTime.Value);
                    return perDate;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return string.Empty;
        }

        public static string GetPersianDateTime(DateTime dateTime)
        {
            try
            {
                var timeOfDay = dateTime.ToString("HH:mm");
                var perDate = PersianCalendar.GetYear(dateTime) % 100 + "/" +
                              PersianCalendar.GetMonth(dateTime) + "/" +
                              PersianCalendar.GetDayOfMonth(dateTime) + ' ' +
                              timeOfDay;
                return perDate;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static DateTime GetGeorgianDate(string persianDate)
        {
            var dateInfo = persianDate.Split('/');
            if (dateInfo.Length != 3)
            {
                throw new Exception("رشته قابل تبدیل به تاریخ نمی باشد");
            }
            var year = Convert.ToInt32(dateInfo[0]);
            var month = Convert.ToInt32(dateInfo[1]);
            var day = Convert.ToInt32(dateInfo[2]);

            var geDate = PersianCalendar.ToDateTime(year, month, day, 12, 0, 0, 0);
            return geDate;
        }

        public static string GetPersianFullYearDate(DateTime dateTime)
        {
            var dayOfWeek = PersianCalendar.GetDayOfWeek(dateTime).ToString();
            var perDate = PersianCalendar.GetYear(dateTime) + "/" +
                          PersianCalendar.GetMonth(dateTime) + "/" +
                          PersianCalendar.GetDayOfMonth(dateTime);
            return perDate;
        }

        public static string GetPersianDayOfWeek(DateTime dateTime)
        {
            var d = (int)PersianCalendar.GetDayOfWeek(dateTime);

            var dayStr = "";

            switch (d)
            {
                case 6:
                    dayStr = "شنبه";
                    break;

                case 0:
                    dayStr = "یکشنبه";
                    break;

                case 1:
                    dayStr = "دوشنبه";
                    break;

                case 2:
                    dayStr = "سه شنبه";
                    break;

                case 3:
                    dayStr = "چهارشنبه";
                    break;

                case 4:
                    dayStr = "پنجشنبه";
                    break;

                case 5:
                    dayStr = "جمعه";
                    break;

                default:
                    break;
            }
            return dayStr;
        }

        public static string GetFullPersianDate(DateTime datetime)
        {
            var fullPerDate = "";
            var dayOfWeek = GetPersianDayOfWeek(datetime);
            var date = GetPersianDate(datetime);
            //string timeOfDay = datetime.ToString("HH:mm");
            fullPerDate = dayOfWeek + " - " + date; //+ " - " + timeOfDay;

            return fullPerDate;
        }

        public static string GetFullPersianDateTime(DateTime datetime)
        {
            var fullPerDate = "";
            var dayOfWeek = GetPersianDayOfWeek(datetime);
            var date = GetPersianDate(datetime);
            var timeOfDay = datetime.ToString("HH:mm");
            fullPerDate = dayOfWeek + " - " + date + " - " + timeOfDay;

            return fullPerDate;
        }
    }
}