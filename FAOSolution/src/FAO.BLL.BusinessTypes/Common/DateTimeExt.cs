using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.BusinessTypes.Common
{
    public static class DateTimeExt
    {
        public static bool IsValid(this DateTime dt)
        {
            if (dt == null)
                return false;

            if (dt == DateTime.MinValue)
                return false;

            //fixes problem with dates passed over COM interface which
            //have minimum of 1899, not DateTime.MinValue
            if (dt.Year < 1920)
                return false;

            return true;
        }

        public static void ForceInvalid(this DateTime dt)
        {
            //sets to the Jan 1, 0001
            dt = new DateTime(1, 1, 1);
        }

    }
}
