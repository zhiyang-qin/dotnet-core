using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FAO.BLL.Calendar;
using System.IO;
using System.Reflection;
using FAO.BLL.CalcEngine.Interfaces;
using FAO.BLL.Calendar.Interfaces;

namespace FAO.BLL.CalcEngine
{
    class AltACRSTable : IBADeprMethod, IBADeprTableSupport
    {
        public static byte[] m_acrsTable;
        public static int m_acrsTableCount;
        
        private double m_dAdjustedCost;
        private double m_dPostUsedDeduction;
        private double m_dSalvageDeduction;
        private double m_dPriorAccum;
        private double m_dYearElapsed;
        private double m_dLife;
        private double m_dDBPercent;
        private double m_dFiscalYearFraction;
        private DateTime m_dtDeemedStartDate;
        private DateTime m_dtDeemedEndDate;
        private short m_iYearNum;
        private short m_sPlacedInServicePeriod;
        private short m_tableId;

        private string m_parentFlags;
        private IBADeprTable m_Table;
        private DISPOSALOVERRIDETYPE m_disposalOverride;
        private bool m_bUseFirstYearFactor;

        public AltACRSTable()
        {
            string tmp = @"SFACalcEngine.DeprMethods.acrspcts.tbl";
            try
            {
                Assembly a = Assembly.GetEntryAssembly();
                string[] resources = a.GetManifestResourceNames();

                System.IO.Stream s = a.GetManifestResourceStream(tmp);
                var memoryStream = new MemoryStream();
                s.CopyTo(memoryStream);
                m_acrsTable = memoryStream.ToArray();
            }
            catch (Exception e)
            {
                string t = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                //string s = AppDomain.CurrentDomain.BaseDirectory;
                //s = e.Message;
            } 
            m_acrsTableCount = m_acrsTable[0];
            
            m_dAdjustedCost = 0;
            m_dPostUsedDeduction = 0;
            m_dSalvageDeduction = 0;
            m_dPriorAccum = 0;
            m_dYearElapsed = 0;
            m_dLife = 0;
            m_dDBPercent = 0;
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
                return 0;
            }
            set
            {
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
                return m_dAdjustedCost - m_dPostUsedDeduction;
            }
        }

        public double RemainingDeprAmt
        {
            get
            {
                double remainingDeprAmt;
                remainingDeprAmt = m_dAdjustedCost - m_dPostUsedDeduction - m_dPriorAccum;
                return remainingDeprAmt;
            }
        }

        public bool GetAvgConvention(IBADeprScheduleItem schedule, ref string pVal)
        {
            string tmp;
            DateTime PlacedInServiceDate;
            double deprLife;
            bool LowIncomeHousing;
            bool PersonalProperty;
            bool PublicUtility;

            deprLife = schedule.DeprLife;
            LowIncomeHousing = schedule.LowIncomeHousingFlag;
            PersonalProperty = schedule.PersonalPropertyFlag;
            PublicUtility = schedule.PublicUtilityFlag;
            PlacedInServiceDate = schedule.PlacedInServiceDate;

            if (PersonalProperty || PublicUtility)
                tmp = "HYmb";
            else if (LowIncomeHousing)
                tmp = "FMmb";
            else if (deprLife < 17 || ((int)(deprLife + 0.01) == 18 && PlacedInServiceDate < new DateTime(1984,6,23)) ||
                     ((int)(deprLife + 0.01) > 19 && (int)(deprLife + 0.01) <= 35 && PlacedInServiceDate < new DateTime(1984,6,23)) ||
                     (deprLife > 35.01 && PlacedInServiceDate < new DateTime(1984,6,23)) )
                tmp = "FMmb";
            else
                tmp = "MMmb";

            pVal = tmp;
            return true;
        }

        public string BaseShortName
        {
            get { return "AST"; }
        }

        public string BaseLongName
        {
            get { return "Alternate ACRS Table"; }
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

        static short FindID(short life, LIFEIDTABLE[] tbl, short count)
        {
            short i;

            for (i = 0; i < count; i++)
            {
                if (tbl[i].life == life)
                {
                    return tbl[i].id;
                }
            }
            return 0;
        }

        public bool Initialize(IBADeprScheduleItem schedule, IBAAvgConvention convention)
        {
            BAUSDeprTable obj;
            IBACalendar Calendar;
            IBAFiscalYear FY;
            short deprPercent;
            long tablePeriodCount;
            DateTime PlacedInServiceDate;
            double deprLife;
            double adjCost;
            double PostUse;
            double Salvage;
            bool LowIncomeHousing;
            bool PersonalProperty;
            bool PublicUtility;
            bool OutsideUS;

            LIFEIDTABLE[] ATSLlih = new LIFEIDTABLE[] {new LIFEIDTABLE(15, 11), new LIFEIDTABLE(35, 15), new LIFEIDTABLE(45, 16)};
            LIFEIDTABLE[] ATSLPers = new LIFEIDTABLE[] { 
                new LIFEIDTABLE( 3, 17 ), new LIFEIDTABLE( 5, 18 ), new LIFEIDTABLE( 10, 19 ), new LIFEIDTABLE( 12, 20 ), 
                new LIFEIDTABLE( 15, 21 ), new LIFEIDTABLE( 25, 22 ), new LIFEIDTABLE( 35, 23 ), new LIFEIDTABLE( 45, 24 ) };

            if (schedule == null)
                return false;

            m_Table = null;
            deprPercent = schedule.DeprPercent;
            deprLife = schedule.DeprLife;
            Salvage = schedule.SalvageDeduction;
            adjCost = schedule.AdjustedCost;
            PostUse = schedule.PostUsageDeduction;
            PlacedInServiceDate = schedule.PlacedInServiceDate;
            LowIncomeHousing = schedule.LowIncomeHousingFlag;
            PersonalProperty = schedule.PersonalPropertyFlag;
            PublicUtility = schedule.PublicUtilityFlag;
            OutsideUS = schedule.UsedOutsideTheUS;

            DBPercent = deprPercent;
            YearElapsed = 0;
            Life = deprLife;
            SalvageDeduction = Salvage;
            AdjustedCost = adjCost;
            PostUsageDeduction = PostUse;

            m_tableId = 0;
            m_disposalOverride = DISPOSALOVERRIDETYPE.disposaloverride_Normal;
            m_bUseFirstYearFactor = false;

            //RDBJ	if ( OutsideUS )
            //RDBJ	{
            //RDBJ		// Currently we are not supporting outside the US so return an error
            //RDBJ		return Error("Property predominantly outside the US is currently not supported.");
            //RDBJ	}
            //RDBJ	else
	        {
                if ( LowIncomeHousing )
                {
                    if ( (int)(deprLife + 0.01) == 35 && PlacedInServiceDate > new DateTime(1985,5,8) )
                    {
                        m_tableId = 14;
                    }
                    else
                        m_tableId = FindID ((short)(deprLife + 0.01), ATSLlih, 3);
                }
                else if ( (PersonalProperty || PublicUtility) )
                {
                    m_tableId = FindID ((short)(deprLife + 0.01), ATSLPers, 8);
			        m_disposalOverride = DISPOSALOVERRIDETYPE.disposaloverride_NoneInYear;
			        m_bUseFirstYearFactor = true;
                }
                else if ( (int)(deprLife + 0.01) == 18 )
                {
                    if ( PlacedInServiceDate < new DateTime(1984,6,23) )
                    {
                        m_tableId = 26;
                    }
                    else
                        m_tableId = 27;
                }
                else if ( (int)(deprLife + 0.01) == 19 )
                {
                    m_tableId = 28;
                }
                else if ( (int)(deprLife + 0.01) == 35 )
                {
                    if ( PlacedInServiceDate > new DateTime(1985,5,8) )
                    {
                        m_tableId = 29;
                    }
                    else if ( PlacedInServiceDate > new DateTime(1984,6,22) )
                    {
                        m_tableId = 30;
                    }
                    else
                        m_tableId = 15;
                }
                else if ( (int)(deprLife + 0.01) == 45 )
                {
                    if ( PlacedInServiceDate > new DateTime(1984,6,22) )
                    {
                        m_tableId = 31;
                    }
                    else
                        m_tableId = 16;
                }
                else if ( (int)(deprLife + 0.01) == 15 )
                {
                    m_tableId = 25;
                }

		        //
		        // We could not find the table number, so return with error.
		        //
		        if ( m_tableId == 0 )
			        throw new Exception("Unable to determine ACRS Table Number.");
	        }

            obj = new BAUSDeprTable();
            m_Table = (IBADeprTable)obj;
	        //
	        // Load the appropriate table into the interface
	        //
	        obj.LoadTable(m_acrsTable, m_tableId);
	        tablePeriodCount = m_Table.PeriodCount;
	        //
	        // Now we need to determine the period that the asset was placed in service.
	        // This will be used to look up the appropriate information in the table.
	        //
	        if ( tablePeriodCount == 1 )
	        {
		        m_sPlacedInServicePeriod = 1;
	        }
	        else
	        {
		        if ( tablePeriodCount == 12 )
		        {
			        DateTime yearEnd;
			        int monthCount;

			        Calendar = schedule.Calendar;
			        Calendar.GetFiscalYear(PlacedInServiceDate, out FY);
			        yearEnd = FY.YREndDate;
			        if ( yearEnd.Day < 8 )
			        {
				        // If the day is less than 8, then we need to "TRUE" it up to the proper month
				        yearEnd = yearEnd.AddDays (- yearEnd.Day);
			        }
			        if ( PlacedInServiceDate.Year < yearEnd.Year )
			        {
				        monthCount = yearEnd.Month - PlacedInServiceDate.Month + 13;
			        }
			        else
			        {
				        monthCount = yearEnd.Month - PlacedInServiceDate.Month + 1;
			        }
			        if ( monthCount > 12 )
				        monthCount = 12;
			        m_sPlacedInServicePeriod = (short)(13 - monthCount);
		        }
		        else
		        {
                    throw new Exception("Invalid Alternate ACRS table definition.");
		        }
	        }
	        //
	        // All done
	        //
            return true;
        }

        public DISPOSALOVERRIDETYPE DisposalOverride
        {
            get { return m_disposalOverride; }
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
