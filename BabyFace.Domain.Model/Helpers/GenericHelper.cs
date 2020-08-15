using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyFace.Domain.Model.Helpers
{
    public static class GenericHelper
    {
        public static DateTime DateTimeFormate(DateTime date)
        {
            
            return new DateTime(date.Year, date.Month, date.Day,
                     date.Hour, date.Minute, date.Second, 1);

        }
    }
}
