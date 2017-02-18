using FAO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAO.DtoMapper.Dtos;
using FAO.Repositories;
using FAO.DAL.Entities;
using FAO.DtoMapper.Mappers;
using FAO.BLL.CalcEngine.Interfaces;
using FAO.BLL.CalcEngine;
using FAO.BLL.BusinessTypes;

namespace FAO.Services
{
    public class CalculationService : ICalculationService
    {
        IBACalcEngine _calcEngine;

        public CalculationService(IBACalcEngine calcEngine)
        {
            _calcEngine = calcEngine;
        }

        public PeriodDeprItemDto CalculateDepreciation(DepreciableBookDto deprBook, DateTime runDate)
        {
            IBAPeriodDeprItem pdItem = GetPeriodDeprItem();
            IBADeprScheduleItem deprScheduleItem = transformDepreciableBookDtoToDeprScheduleItem(deprBook);

            IBAPeriodDetailDeprInfo periodDetails = _calcEngine.CalculateDepreciation(deprScheduleItem, ref pdItem, runDate);

            return transformPeriodDeprItemToDto(periodDetails);
        }

        public List<PeriodDeprItemDto> CalculateProjection(DepreciableBookDto deprBook)
        {
            IBAPeriodDeprItem pdItem = GetPeriodDeprItem();
            IBADeprScheduleItem deprScheduleItem = transformDepreciableBookDtoToDeprScheduleItem(deprBook);
            List<IBAPeriodDetailDeprInfo> objPDItems = null;

            bool isCalculateProjectionSuccess = _calcEngine.CalculateProjection(deprScheduleItem, ref pdItem, out objPDItems);

            if (isCalculateProjectionSuccess)
            {
                return objPDItems.Select(item => transformPeriodDeprItemToDto(item)).ToList();
            }

            return null;
        }

        public List<PeriodDeprItemDto> CalculateMonthlyProjection(DepreciableBookDto deprBook, DateTime startDate, DateTime endDate)
        {
            IBAPeriodDeprItem pdItem = GetPeriodDeprItem();
            IBADeprScheduleItem deprScheduleItem = transformDepreciableBookDtoToDeprScheduleItem(deprBook);
            List<IBAPeriodDetailDeprInfo> objPDItems = null;

            bool isCalculateProjectionSuccess = _calcEngine.CalculateMonthlyProjection(deprScheduleItem, ref pdItem, startDate, endDate, out objPDItems);

            if (isCalculateProjectionSuccess)
            {
                return objPDItems.Select(item => transformPeriodDeprItemToDto(item)).ToList();
            }

            return null;
        }

        private IBADeprScheduleItem transformDepreciableBookDtoToDeprScheduleItem(DepreciableBookDto deprBook)
        {
            IBADeprScheduleItem deprScheduleItem = GetDeprScheduleItem();

            deprScheduleItem.PropertyType = (short)PropertyTypeCode.translateShortNameToType(deprBook.PropertyType).Type;
            deprScheduleItem.PlacedInServiceDate = deprBook.PlaceInServiceDate;
            deprScheduleItem.AcquisitionValue = deprBook.AcquiredValue;
            deprScheduleItem.DeprMethod = deprBook.DepreciateMethod;
            deprScheduleItem.DeprPercent = deprBook.DepreciatePercent;
            deprScheduleItem.DeprLife = deprBook.EstimatedLife;

            return deprScheduleItem;
        }

        private PeriodDeprItemDto transformPeriodDeprItemToDto(IBAPeriodDetailDeprInfo periodDetails)
        {
            return new PeriodDeprItemDto {
                FiscalYearStartDate = periodDetails.FiscalYearStartDate,
                FiscalYearEndDate = periodDetails.FiscalYearEndDate,
                FiscalYearBeginAccum = periodDetails.FiscalYearBeginAccum,
                FiscalYearEndAccum = periodDetails.FiscalYearEndAccum,
                FiscalYearDeprAmount = periodDetails.FiscalYearDeprAmount,

                PeriodStartDate = periodDetails.PeriodStartDate,
                PeriodEndDate = periodDetails.PeriodEndDate,

                PeriodBeginAccum = periodDetails.PeriodBeginAccum,
                PeriodEndAccum = periodDetails.PeriodEndAccum,
                PeriodDeprAmount = periodDetails.PeriodDeprAmount,

                CalcFlags = periodDetails.CalcFlags,
                AdjustmentAmt = periodDetails.AdjustmentAmt,
            };
        }

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

    }
}
