using System;
using System.Globalization;

namespace Fanap.Plus.Product_Management.Helpers
{
    public static class DateHelper
    {
        public static string ConvertToPersian(DateTime gregorianDate)
        {
            var persianCalendar = new PersianCalendar();
            return $"{persianCalendar.GetYear(gregorianDate)}/{persianCalendar.GetMonth(gregorianDate)}/{persianCalendar.GetDayOfMonth(gregorianDate)}";
        }
        public static DateTime ConvertToGregorian(string persianDate)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            string[] parts = persianDate.Split('/');
            return persianCalendar.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), 0, 0, 0, 0);
        }

    }
}