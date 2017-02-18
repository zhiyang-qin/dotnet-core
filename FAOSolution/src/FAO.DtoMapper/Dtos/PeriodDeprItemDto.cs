using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DtoMapper.Dtos
{
    public class PeriodDeprItemDto
    {
        public DateTime FiscalYearStartDate { get; set; }
        public DateTime FiscalYearEndDate { get; set; }

        public decimal FiscalYearBeginAccum { get; set; }
        public decimal FiscalYearEndAccum { get; set; }
        public decimal FiscalYearDeprAmount { get; set; }

        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }

        public decimal PeriodBeginAccum { get; set; }   // refer to the fiscal year start date
        public decimal PeriodEndAccum { get; set; }
        public decimal PeriodDeprAmount { get; set; }
        public string CalcFlags { get; set; }

        public decimal AdjustmentAmt { get; set; }
    }
}
