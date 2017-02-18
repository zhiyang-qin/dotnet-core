using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FAO.BLL.BusinessTypes;
using FAO.BLL.Calendar.Interfaces;

namespace FAO.BLL.CalcEngine.Interfaces
{
    public interface IBADeprScheduleItem
    {
        short PropertyType { get; set; }
        double AcquisitionValue { get; set; }
        double ADSLife { get; set; }

        BkTypeEnum BookType { get; set; }

        bool Bonus911Flag { get; set; }
        double Stored168KAmount { get; set; }


        double Section179 { get; set; }
        double Section179A { get; set; }
        DateTime PlacedInServiceDate { get; set; }
        DateTime DispDate { get; set; }
        DateTime DeemStartDate { get; set; }
        DateTime DeemEndDate { get; set; }
        double DeprLife { get; set; }
        short DeprPercent { get; set; }
        string DeprMethod { get; set; }
        string AvgConvention { get; set; }
        IBACalendar Calendar { get; set; }
        double AdjustedCost { get; }
        double PostUsageDeduction { get; }
        double SalvageDeduction { get; set; }
        double Bonus911Amount { get; set; }
        short Bonus911Percent { get; set; }
        short ZoneCode { get; set; }
        double BasisAdjustment { get; set; }
        double ElectricCar { get; set; }
        double ITCBasisReduction { get; set; }
        bool BonusFlag { get; set; }
        double BonusAmount { get; set; }
        DateTime LastCalcDate { get; set; }
        bool isMidQtrUsedDefault { get; set; }
        bool isMidQtr { get; set; }
        double ITCAmount { get; set; }
        double ITCReduce { get; set; }
        double ReplacementValueBasis { get; set; }

        bool VintageAccountFlag { get; }
        bool LowIncomeHousingFlag { get; }
        bool PublicUtilityFlag { get; }
        bool PersonalPropertyFlag { get; }

        string AutoTruckLimit { get; set; } // example "3160, 5100, 3050, 1875" for four years
        LUXURYLIMIT_TYPE GetLuxuryFlag { get; set; }
        bool UseACEHandling { get; }
        
        bool BuildAllPDItems { get; set; }
        bool GetBusinessUse(DateTime fyEnd, ref double dBusinessUsePct, ref double dInvestmentUsePct);
        bool AddBusinessUseEntry(DateTime fyBegin, double dBusinessUsePct, double dInvestmentUsePct);
        void GetPeriodDeprMgr();
        void ReleaseDeprMethod();
        void ReleaseAvgConvention();

        decimal ACEBasis { get; set; }
        double ACELife { get; }
        bool UsedOutsideTheUS { get; set; }
        double CalculateBonus911Amount { get; }
        double CalculateITCBasisReductionFactor();
        double CalculateITCBasisReductionAmount(bool AceSwitch);
       
        AssetImportCodeEnum ImportCode{ get; set; }
        AssetITCTypeEnum ITCCode{ get; set; }
        AssetDeprAdjustmentConventionEnum ApplyAdjustment { get; set; }

        IBADeprTable GetCustomDepreciationTable { get; }
        void CopyPercentsToArray(ref double[] retVal);
        void CopyPercentsFromArray(double[] inVal);
    }
}
