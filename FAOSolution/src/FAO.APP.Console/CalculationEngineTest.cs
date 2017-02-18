using FAO.BLL.BusinessTypes;
using FAO.BLL.CalcEngine;
using FAO.BLL.CalcEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.ConsoleApp
{
    public class CalculationEngineTest
    {
        CalcEngine _calcEngine = new CalcEngine();

        public CalculationEngineTest()
        {
        }

        public void CalculateBonus168KAmountTest()
        {
            IBADeprScheduleItem schedule = GetDeprScheduleItem();
            double calculateBonus168KAmount = _calcEngine.CalculateBonus168KAmount(schedule);
        }

        public void CalculateDepreciationTest()
        {
            IBAPeriodDeprItem pdItem = GetPeriodDeprItem();
            IBAPeriodDetailDeprInfo periodDetails = _calcEngine.CalculateDepreciation(GetDeprScheduleItem(), ref pdItem, DateTime.Now);
        }

        public void CalculateFullCostBasisAmountTest()
        {
            double fullCostBasisAmount = _calcEngine.CalculateFullCostBasis(GetDeprScheduleItem());
        }

        public void CalculateProjectionTest()
        {
            List<IBAPeriodDetailDeprInfo> objPDItems = null;
            IBAPeriodDeprItem pdItem = GetPeriodDeprItem();
            bool isCalculateProjectionSuccess = _calcEngine.CalculateProjection(GetDeprScheduleItem(), ref pdItem, out objPDItems);
        }

        public void CalculateMonthlyProjectionTest()
        {
            List<IBAPeriodDetailDeprInfo> objPDItems = null;
            IBAPeriodDeprItem pdItem = GetPeriodDeprItem();
            bool isMonthlyProjCalculated = _calcEngine.CalculateMonthlyProjection(GetDeprScheduleItem(), ref pdItem, DateTime.Now, DateTime.Now.AddDays(365), out objPDItems);
        }


        #region "Supporting Functions"

        private IBADeprScheduleItem GetDeprScheduleItem()
        {
            IBADeprScheduleItem Schedule = new BAFASDeprScheduleItem();
            Schedule.PropertyType = 1;
            Schedule.BookType = BkTypeEnum.bpblBookTaxBook;
            Schedule.DispDate = DateTime.MinValue;

            Schedule.AcquisitionValue = Convert.ToDouble(10000);
            Schedule.PlacedInServiceDate = Convert.ToDateTime("2000-01-01");
            Schedule.DeprLife = 5;
            Schedule.DeprMethod = "SL";
            Schedule.DeprPercent = 0;
            Schedule.Section179 = Convert.ToDouble(0);
            Schedule.SalvageDeduction = Convert.ToDouble(0);
            Schedule.ITCAmount = Convert.ToDouble(0);
            Schedule.ITCReduce = Convert.ToDouble(0);
            Schedule.Bonus911Percent = 0;
            Schedule.AvgConvention = "NON";
            return Schedule;
        }

        private IBAPeriodDeprItem GetPeriodDeprItem()
        {
            IBAPeriodDeprItem pdItem = new PeriodDeprItem();
            return pdItem;
        }

        #endregion
    }
}
