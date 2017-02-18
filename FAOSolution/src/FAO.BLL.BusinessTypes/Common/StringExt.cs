using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.BusinessTypes.Common
{
    public static class StringExt
    {
        public static bool IsNumeric(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }
            int number;
            if (Int32.TryParse(value, out number))
            {
                if (number < 0)
                {
                    return false;
                }
                //Some business rule
                if (number < 10000)
                {
                    return true;
                }
                return false;

            }
            return false;
        }

    }
}
