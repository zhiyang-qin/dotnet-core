using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.CalcEngine
{
    public static class CurrencyHelper
    {
        public static void DoubleToCurrency(double inValue, out decimal outValue)
        {
            outValue = (decimal)inValue;
        }

        public static double FormatCurrency(double value)
        {
            return value;
        }
        public static double CurrencyToDouble(decimal currency)
        {
            return (double)currency;
        }
    }
}
