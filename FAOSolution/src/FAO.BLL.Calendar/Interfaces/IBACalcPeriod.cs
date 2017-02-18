using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.BLL.Calendar.Interfaces
{
    public interface IBACalcPeriod
    {

        DateTime PeriodStart { get; set; }
        DateTime PeriodEnd { get; set; }
        short PeriodNum { get; set; }
        short Weight { get; set; }
        bool IsIdle { get; set; }
    }
}
