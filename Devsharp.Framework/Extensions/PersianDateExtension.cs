using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Devsharp.Framwork.Extensions
{
    public static class PersianDateExtension
    {
        public static string ToPersian(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            try
            {
             return persianCalendar.GetYear(dateTime) + "/" + persianCalendar.GetMonth(dateTime) + "/" + persianCalendar.GetDayOfMonth(dateTime);

            }
            catch(Exception ex)
            {
                return "";
            }

        }
    }
}
