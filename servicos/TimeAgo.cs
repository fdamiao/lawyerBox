using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.servicos
{
    public static class TimeAgo
    {
        public static string TimeAgos( DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result =  string.Format("{0} secundos ", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("A {0} minutos ", timeSpan.Minutes) :
                    "about a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("A {0} horas ", timeSpan.Hours) :
                    "Cerca  de algumas horas atraz";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("A  {0} dias ", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("A {0} Meses ", timeSpan.Days / 30) :
                    "about a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("A {0} anos", timeSpan.Days / 365) :
                    "about a year ago";
            }

            return result;
        }
       
    }
}
