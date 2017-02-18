using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.BLL.CalcEngine.Interfaces
{
    public interface IBACalcEngine
    {
        IBACalcLookUp CalcLookUp { get; set; }

        bool CalculateProjection(IBADeprScheduleItem pObjSch, ref IBAPeriodDeprItem pdItem, out List<IBAPeriodDetailDeprInfo> objPDItems);
        bool CalculateMonthlyProjection(IBADeprScheduleItem pObjSch, ref IBAPeriodDeprItem pdItem, DateTime startDate, DateTime endDate, out List<IBAPeriodDetailDeprInfo> objPDItems);
        bool CalculateFASDeprToDate(IBADeprScheduleItem objSch, DateTime dtEndDate, out List<IBAPeriodDeprItem> objPDItems);
        IBAPeriodDetailDeprInfo CalculateDepreciation(IBADeprScheduleItem pObjSch, ref IBAPeriodDeprItem pdItem, DateTime dtRunDate);
        IBAPeriodDetailDeprInfo CalculateDisposal(IBADeprScheduleItem pObjSch, ref IBAPeriodDeprItem pdItem);

 //       double CalculateBonus168KAmount(IBADeprScheduleItem pObjSch);
        double CalculateFullCostBasis(IBADeprScheduleItem pObjSch);
        bool ComputeITCRecap(IBADeprScheduleItem schedule, DateTime RunDate, out double TablePct, out double Recap, out double AddBack);
        bool ComputeFullCostBasis(IBADeprScheduleItem schedule, bool ForMidQtr, out bool InLastQtr, out double Basis);
    }
}
