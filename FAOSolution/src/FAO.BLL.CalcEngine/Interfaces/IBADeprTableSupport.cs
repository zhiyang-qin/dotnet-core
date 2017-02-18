﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.BLL.CalcEngine.Interfaces
{
    public interface IBADeprTable
    {
        short YearCount { get; }
        short PeriodCount { get; }
        bool Percent(long year, long period, out double pct);
    }

    public interface IBADeprTableSupport
    {
        IBADeprTable DeprTable { get; set; }
        bool DeferShortYearAmount { get; }
        bool ShortYearForcesFormula { get; }
        bool ShortYearSwitchToEndOfLife { get; }
        bool IsCustomTableMethod { get; }
        bool InPostRecovery { get; }
    }
}
