using FAO.BLL.CalcEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.BLL.CalcEngine
{
    class CustomDeprMethod : IBADeprMethod, IBADeprTableSupport
    {
        private double m_dAdjustedCost;
        private double m_dPostUsedDeduction;
        private double m_dSalvageDeduction;
        private double m_dPriorAccum;
        private double m_dYearElapsed;
        private double m_dLife;
        private double m_dFiscalYearFraction;
        private DateTime m_dtDeemedStartDate;
        private DateTime m_dtDeemedEndDate;
        private short m_iYearNum;
        private short m_sPlacedInServicePeriod;

        private string m_parentFlags;
        private IBADeprTable m_Table;

        public CustomDeprMethod()
        {
            m_dAdjustedCost = 0;
            m_dPostUsedDeduction = 0;
            m_dSalvageDeduction = 0;
            m_dPriorAccum = 0;
            m_dYearElapsed = 0;
            m_dLife = 0;
            m_dFiscalYearFraction = 0;
            m_dtDeemedStartDate = DateTime.MinValue;
            m_dtDeemedEndDate = DateTime.MinValue;
            m_iYearNum = 0;
            m_parentFlags = "";
        }

        public double AdjustedCost
        {
            get
            {
                return m_dAdjustedCost;
            }
            set
            {
                m_dAdjustedCost = value;
            }
        }

        public double PostUsageDeduction
        {
            get
            {
                return m_dPostUsedDeduction;
            }
            set
            {
                m_dPostUsedDeduction = value;
            }
        }

        public double SalvageDeduction
        {
            get
            {
                return m_dSalvageDeduction;
            }
            set
            {
                m_dSalvageDeduction = value;
            }
        }

        public double PriorAccum
        {
            get
            {
                return 0;
            }
            set
            {
                m_dPriorAccum = 0;
            }
        }

        public double YearElapsed
        {
            get
            {
                return m_dYearElapsed;
            }
            set
            {
                m_dYearElapsed = value;
            }
        }

        public short YearNum
        {
            get
            {
                return m_iYearNum;
            }
            set
            {
                m_iYearNum = value;
            }
        }

        public bool IsFiscalYearBased
        {
            get { return false; }
        }

        public double Life
        {
            get
            {
                return m_dLife;
            }
            set
            {
                m_dLife = value;
            }
        }

        public double DBPercent
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public double FiscalYearFraction
        {
            get
            {
                return m_dFiscalYearFraction;
            }
            set
            {
                m_dFiscalYearFraction = value;
            }
        }

        public DateTime DeemedStartDate
        {
            get
            {
                return m_dtDeemedStartDate;
            }
            set
            {
                m_dtDeemedStartDate = value;
            }
        }

        public DateTime DeemedEndDate
        {
            get
            {
                return m_dtDeemedEndDate;
            }
            set
            {
                m_dtDeemedEndDate = value;
            }
        }

        public double CalculateAnnualDepr()
        {
            short TableYears;
            long Year;
            double Pct;
            double dBasis;
            bool hr = true;

            if (m_Table == null)
                throw new Exception("Depr Method not initialized.");

            TableYears = m_Table.YearCount;

            if (m_iYearNum < 1)
                Year = 1;
            else if (m_iYearNum > TableYears)
                Year = TableYears;
            else
                Year = m_iYearNum;

            if (!(hr = m_Table.Percent(Year, m_sPlacedInServicePeriod, out Pct)))
                return 0;

            if (Pct < 0.000001 && Year == TableYears)
            {
                if (!(hr = m_Table.Percent(Year - 1, m_sPlacedInServicePeriod, out Pct)))
                    return 0;
            }
            dBasis = Basis;

            return dBasis * Pct;
        }

        public double Basis
        {
            get
            {
                return m_dAdjustedCost - m_dPostUsedDeduction - m_dSalvageDeduction;
            }
        }

        public double RemainingDeprAmt
        {
            get
            {
                double remainingDeprAmt;
                remainingDeprAmt = m_dAdjustedCost - m_dPostUsedDeduction - m_dPriorAccum - m_dSalvageDeduction;
                return remainingDeprAmt;
            }
        }

        public bool GetAvgConvention(IBADeprScheduleItem schedule, ref string pVal)
        {
            return false;
        }

        public string BaseShortName
        {
            get { return "~~custom~~"; }
        }

        public string BaseLongName
        {
            get { return "Custom Table"; }
        }

        public IBADeprTable DeprTable
        {
            get { return m_Table; }
            set { m_Table = value; }
        }

        public bool DeferShortYearAmount { get { return true; } }
        public bool ShortYearForcesFormula { get { return false; } }
        public bool ShortYearSwitchToEndOfLife { get { return false; } }
        public bool IsCustomTableMethod { get { return false; } }

        public string ParentFlags
        {
            get
            {
                return m_parentFlags;
            }
            set
            {
                m_parentFlags = value;
            }
        }

        public bool Initialize(IBADeprScheduleItem schedule, IBAAvgConvention convention)
        {
            short deprPercent;
            long tablePeriodCount;
            DateTime PlacedInServiceDate;
            double deprLife;
            double adjCost;
            double PostUse;
            double Salvage;

            if (schedule == null)
                return false;

            m_Table = null;
            deprPercent = schedule.DeprPercent;
            deprLife = schedule.DeprLife;
            Salvage = schedule.SalvageDeduction;
            adjCost = schedule.AdjustedCost;
            PostUse = schedule.PostUsageDeduction;
            PlacedInServiceDate = schedule.PlacedInServiceDate;
            m_Table = schedule.GetCustomDepreciationTable;

            DBPercent = deprPercent;
            YearElapsed = 0;
            Life = deprLife;
            SalvageDeduction = Salvage;
            AdjustedCost = adjCost;
            PostUsageDeduction = PostUse;

            //
            // Load the appropriate table into the interface
            //
            tablePeriodCount = m_Table.PeriodCount;
            //
            // Now we need to determine the period that the asset was placed in service.
            // This will be used to look up the appropriate information in the table.
            //
            if (tablePeriodCount == 1)
            {
                m_sPlacedInServicePeriod = 1;
            }
            else
            {
                throw new Exception("Invalid ACRS table definition.");
            }
            //
            // All done
            //
            return true;
        }

        public DISPOSALOVERRIDETYPE DisposalOverride
        {
            get { return DISPOSALOVERRIDETYPE.disposaloverride_Normal; }
        }

        public bool UseFirstYearFactor
        {
            get { return false; }
        }

        public bool InPostRecovery
        {
            get
            {
                long TableYears;
                double Pct;

                if (m_Table == null)
                    throw new Exception("Depr Method not initialized.");

                TableYears = m_Table.YearCount;

                if (m_iYearNum > TableYears)
                    return true;
                else if (!m_Table.Percent(m_iYearNum, m_sPlacedInServicePeriod, out Pct))
                    return true;
                else if (Pct < 0.000001 && m_iYearNum == TableYears)
                    return true;
                else
                    return false;
            }
        }

        public double TotalDepreciationAllowed
        {
            get
            {
                double basis;

                basis = Basis;

                return basis;
            }
        }
    }
}
