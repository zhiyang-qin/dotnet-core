using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using FAO.BLL.Calendar.Interfaces;
using FAO.BLL.CalcEngine.Interfaces;

namespace FAO.BLL.CalcEngine
{
    class AltMACRSTable : IBADeprMethod, IBADeprTableSupport, IBASwitchDepr
    {
        public static byte[] m_altMacrsTable;
        public static int m_altMacrsTableCount;

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

        private int m_iSwitchYearNum;
        private bool m_bSwitchRequired;
        private bool m_bIsShortYear;
        private IBADeprMethod m_pObjSwitchMethod;
        private string m_parentFlags;
        private IBADeprTable m_Table;

        public AltMACRSTable()
        {
            string tmp = @"SFACalcEngine.DeprMethods.altMACRPCTS.TBL";
            try
            {
                Assembly a = Assembly.GetEntryAssembly();
                string[] resources = a.GetManifestResourceNames();

                System.IO.Stream s = a.GetManifestResourceStream(tmp);
                var memoryStream = new MemoryStream();
                s.CopyTo(memoryStream);
                m_altMacrsTable = memoryStream.ToArray();
            }
            catch (Exception e)
            {
                string t = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                //string s = AppDomain.CurrentDomain.BaseDirectory;
                //s = e.Message;
            } 
            m_altMacrsTableCount = m_altMacrsTable[0];

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

            m_iSwitchYearNum = 0;
            m_bSwitchRequired = true;
            m_bIsShortYear = false;
            m_pObjSwitchMethod = null;
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
                return m_dPriorAccum;
            }
            set
            {
                m_dPriorAccum = value;
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
                return m_dDBPercent;
            }
            set
            {
                m_dDBPercent = value;
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
            tmp = schedule.AvgConvention;
            if (tmp == "HY" || tmp == "MM" || tmp == "FM" || tmp == "MQ")
                tmp += "mb";
            pVal = tmp;
            return true;
        }

        public string BaseShortName
        {
            get { return "MT"; }
        }

        public string BaseLongName
        {
            get { return "MACRS Table"; }
        }

        public IBADeprTable DeprTable
        {
            get { return null; }
            set { }
        }

        public bool DeferShortYearAmount { get { return false; } }
        public bool ShortYearForcesFormula { get { return false; } }
        public bool ShortYearSwitchToEndOfLife { get { return false; } }
        public bool IsCustomTableMethod { get { return false; } }

        public bool SwitchRequired
        {
            get
            {
                m_bSwitchRequired = true;
                return m_bSwitchRequired;
            }
            set
            {
                m_bSwitchRequired = true;
            }
        }

        public short SwitchYearNum
        {
            get
            {
                return (short)m_iSwitchYearNum;
            }
            set
            {
                m_iSwitchYearNum = value;
            }
        }

        public bool IsShortYear
        {
            get
            {
                return m_bIsShortYear;
            }
            set
            {
                m_bIsShortYear = value;
            }
        }

        public IBADeprMethod SwitchMethod
        {
            get
            {
                IBADeprMethod pVal = m_pObjSwitchMethod as IBADeprMethod;

                if (pVal == null)
                    return null;

                pVal.AdjustedCost = (m_dAdjustedCost);
                pVal.PostUsageDeduction = (m_dPostUsedDeduction);
                pVal.SalvageDeduction = (m_dSalvageDeduction);
                pVal.PriorAccum = (m_dPriorAccum);
                pVal.Life = (m_dLife);
                pVal.YearElapsed = (m_dYearElapsed);
                pVal.DeemedStartDate = (m_dtDeemedStartDate);
                pVal.DeemedEndDate = (m_dtDeemedEndDate);
                pVal.YearNum = (m_iYearNum);
                pVal.DBPercent = (m_dDBPercent);
                pVal.FiscalYearFraction = (m_dFiscalYearFraction);
                return pVal;
            }
            set
            {
                string parentFlags;
                string flags;

                m_pObjSwitchMethod = value;
                if (value == null)
                    return;
                parentFlags = ParentFlags;
                flags = SwitchFlag;
                parentFlags += flags;

                m_pObjSwitchMethod.ParentFlags = (parentFlags);
            }
        }

        public bool CheckForSwitch
        {
            get
            {
                if (m_bIsShortYear)
                    return true;
                else if (m_iSwitchYearNum <= m_iYearNum)
                    return true;
                else
                    return false;
            }
        }

        public string SwitchMethodName
        {
            get
            {
                return "MF";

            }
            set
            {
                throw new NotImplementedException();
            }
        }

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

        public string SwitchFlag
        {
            get
            {
                return "f";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool GetCurrentMethod(string flags, out IBADeprMethod pVal)
        {
            pVal = null;
            string switchFlag;
            IBASwitchDepr swIface;
            bool hr;

            if (flags == null)
                return false;

            switchFlag = SwitchFlag;

            if (flags.Contains(switchFlag))
            {
                if (m_pObjSwitchMethod == null)
                    throw new Exception("Flags indicate that a switch is needed, but the switch interface is not initialized.");

                //
                // Now set up the method that we are switching to.
                //
                m_pObjSwitchMethod.AdjustedCost = (m_dAdjustedCost);
                m_pObjSwitchMethod.PostUsageDeduction = (m_dPostUsedDeduction);
                m_pObjSwitchMethod.SalvageDeduction = (m_dSalvageDeduction);
                m_pObjSwitchMethod.PriorAccum = (m_dPriorAccum);
                m_pObjSwitchMethod.Life = (m_dLife);
                m_pObjSwitchMethod.YearElapsed = (m_dYearElapsed);
                m_pObjSwitchMethod.DeemedStartDate = (m_dtDeemedStartDate);
                m_pObjSwitchMethod.DeemedEndDate = (m_dtDeemedEndDate);
                m_pObjSwitchMethod.YearNum = (m_iYearNum);
                m_pObjSwitchMethod.DBPercent = (m_dDBPercent);
                m_pObjSwitchMethod.FiscalYearFraction = (m_dFiscalYearFraction);

                swIface = m_pObjSwitchMethod as IBASwitchDepr;
                if (swIface == null)
                {
                    pVal = m_pObjSwitchMethod as IBADeprMethod;
                    return true;
                }
                return swIface.GetCurrentMethod(flags, out pVal);
            }
            else
            {
                pVal = this as IBADeprMethod;
                return true;
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

        public short FindSwitchYearNumber(IBADeprScheduleItem schedule, IBAAvgConvention convention)
        {
            DateTime dtPISDate;
            DateTime dtDeemedEnd;
            DateTime dtYrStart;
            DateTime dtYrEnd;
            short iFYNum;
            short iStartYearNum;
            IBAFiscalYear pObjFY;
            bool bShortYear;
            IBACalendar Calendar;

            dtPISDate = schedule.PlacedInServiceDate;
            Calendar = schedule.Calendar;
            dtDeemedEnd = convention.DeemedEndDate;
            Calendar.GetFiscalYear(dtPISDate, out pObjFY);
            iStartYearNum = pObjFY.FYNum;
            dtYrStart = pObjFY.YRStartDate;
            dtYrEnd = pObjFY.YREndDate;

            do
            {
                bShortYear = pObjFY.IsShortYear;
                iFYNum = pObjFY.FYNum;
                if (bShortYear)
                {
                    return (short)(iFYNum - iStartYearNum + 1);
                }
                else
                {
                    pObjFY = null;
                    Calendar.GetFiscalYear(dtYrEnd.AddDays(+1), out pObjFY);
                    dtYrStart = pObjFY.YRStartDate;
                    dtYrEnd = pObjFY.YREndDate;
                }
            } while (!bShortYear && dtYrStart <= dtDeemedEnd);

            return 32767;
        }

        public bool Initialize(IBADeprScheduleItem schedule, IBAAvgConvention convention)
        {
            BAUSDeprTable obj;
            IBACalendar Calendar;
            IBAFiscalYear FY;
            string AvgConvention;
            short deprPercent;
            long tablePeriodCount;
            DateTime PlacedInServiceDate;
            double deprLife;
            double adjCost;
            double PostUse;
            double Salvage;

            // life id pairs are a life in years (year only) followed by the table id.
            LIFEIDTABLE[] MM100 = new LIFEIDTABLE[] { new LIFEIDTABLE(27, 1), new LIFEIDTABLE(31, 2), new LIFEIDTABLE(39, 3), new LIFEIDTABLE(40, 179) };
            LIFEIDTABLE[] HY100 = new LIFEIDTABLE[]{
		        new LIFEIDTABLE( 30, 101), new LIFEIDTABLE( 36, 102), new LIFEIDTABLE( 42, 103), new LIFEIDTABLE( 48, 104), new LIFEIDTABLE( 60, 105), new LIFEIDTABLE( 72, 106), new LIFEIDTABLE( 78, 107), 
		        new LIFEIDTABLE( 84, 108), new LIFEIDTABLE( 90, 109), new LIFEIDTABLE( 96, 110), new LIFEIDTABLE(102, 111), new LIFEIDTABLE(108, 112), new LIFEIDTABLE(114, 113), new LIFEIDTABLE(120, 114), 
		        new LIFEIDTABLE(126, 115), new LIFEIDTABLE(132, 116), new LIFEIDTABLE(138, 117), new LIFEIDTABLE(144, 118), new LIFEIDTABLE(150, 119), new LIFEIDTABLE(156, 120), new LIFEIDTABLE(162, 121), 
		        new LIFEIDTABLE(168, 122), new LIFEIDTABLE(180, 123), new LIFEIDTABLE(192, 124), new LIFEIDTABLE(198, 125), new LIFEIDTABLE(204, 126), new LIFEIDTABLE(216, 127), new LIFEIDTABLE(228, 128), 
		        new LIFEIDTABLE(240, 129), new LIFEIDTABLE(264, 130), new LIFEIDTABLE(288, 131), new LIFEIDTABLE(300, 132), new LIFEIDTABLE(318, 133), new LIFEIDTABLE(336, 134), new LIFEIDTABLE(360, 135), 
		        new LIFEIDTABLE(420, 136), new LIFEIDTABLE(480, 137), new LIFEIDTABLE(540, 138), new LIFEIDTABLE(600, 139) };

            LIFEIDTABLE[] MQ100 = new LIFEIDTABLE[]{
		        new LIFEIDTABLE( 30, 140), new LIFEIDTABLE( 36, 141), new LIFEIDTABLE( 42, 142), new LIFEIDTABLE( 48, 143), new LIFEIDTABLE( 60, 144), new LIFEIDTABLE( 72, 145), new LIFEIDTABLE( 78, 146), 
		        new LIFEIDTABLE( 84, 147), new LIFEIDTABLE( 90, 148), new LIFEIDTABLE( 96, 149), new LIFEIDTABLE(102, 150), new LIFEIDTABLE(108, 151), new LIFEIDTABLE(114, 152), new LIFEIDTABLE(120, 153), 
		        new LIFEIDTABLE(126, 154), new LIFEIDTABLE(132, 155), new LIFEIDTABLE(138, 156), new LIFEIDTABLE(144, 157), new LIFEIDTABLE(150, 158), new LIFEIDTABLE(156, 159), new LIFEIDTABLE(162, 160), 
		        new LIFEIDTABLE(168, 161), new LIFEIDTABLE(180, 162), new LIFEIDTABLE(192, 163), new LIFEIDTABLE(198, 164), new LIFEIDTABLE(204, 165), new LIFEIDTABLE(216, 166), new LIFEIDTABLE(228, 167), 
		        new LIFEIDTABLE(240, 168), new LIFEIDTABLE(264, 169), new LIFEIDTABLE(288, 170), new LIFEIDTABLE(300, 171), new LIFEIDTABLE(318, 172), new LIFEIDTABLE(336, 173), new LIFEIDTABLE(360, 174), 
		        new LIFEIDTABLE(420, 175), new LIFEIDTABLE(480, 176), new LIFEIDTABLE(540, 177), new LIFEIDTABLE(600, 178) };

            if (schedule == null)
                return false;

            m_Table = null;
            deprPercent = schedule.DeprPercent;
            deprLife = schedule.DeprLife;
            Salvage = schedule.SalvageDeduction;
            adjCost = schedule.AdjustedCost;
            PostUse = schedule.PostUsageDeduction;
            PlacedInServiceDate = schedule.PlacedInServiceDate;
            AvgConvention = schedule.AvgConvention;

            DBPercent = deprPercent;
            YearElapsed = 0;
            Life = deprLife;
            SalvageDeduction = Salvage;
            AdjustedCost = adjCost;
            PostUsageDeduction = PostUse;

            m_tableId = 0;
            int len = AvgConvention.Length;
	        string tmp = AvgConvention;
	        if ( tmp == AvgConvention )
		        m_tableId = FindID((short)(deprLife + 0.01), MM100, 4);

	        if ( string.Compare(AvgConvention, "MM") == 0 || string.Compare(AvgConvention, "MMM") == 0 )
	        {
		        m_tableId = FindID((short)(deprLife + 0.01), MM100, 4);
	        }
	        else if ( string.Compare(AvgConvention, "HY") == 0 )
	        {
		        m_tableId = FindID((short)((deprLife * 12)+0.01), HY100, 39);
	        }
	        else if ( string.Compare(AvgConvention, "MQ") == 0 )
	        {
		        m_tableId = FindID((short)((deprLife * 12)+0.01), MQ100, 39);
	        }

            if ( m_tableId == 0 )
            {
                throw new Exception("Invalid table information");
            }
	        //
	        // Load the table interface 
	        //
            obj = new BAUSDeprTable();
            m_Table = (IBADeprTable)obj;

	        //
	        // Load the appropriate table into the interface
	        //
	        obj.LoadTable(m_altMacrsTable, m_tableId);
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
		        if ( tablePeriodCount == 4 )
		        {
			        m_sPlacedInServicePeriod = convention.DetermineTablePeriod;
		        }
		        else if ( tablePeriodCount == 12 && deprPercent == 100 && 
				         (string.Compare(AvgConvention, "MM") == 0 || string.Compare(AvgConvention, "MMM") == 0) )
		        {
			        DateTime yearEnd;
                    int monthCount;

			        Calendar = schedule.Calendar;
			        Calendar.GetFiscalYear(PlacedInServiceDate, out FY);
                    yearEnd = FY.YREndDate;

                    if (yearEnd.Day < 8)
			        {
				        // If the day is less than 8, then we need to "TRUE" it up to the proper month
                        yearEnd = yearEnd.AddDays(-yearEnd.Day);
			        }
                    if (PlacedInServiceDate.Year < yearEnd.Year)
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
                    throw new Exception("Invalid MACRS table definition.");
		        }
	        }
	        m_iSwitchYearNum = FindSwitchYearNumber(schedule, convention);
	        //
	        // All done
	        // 
	        if ( m_pObjSwitchMethod != null)
            {
                m_pObjSwitchMethod.Initialize(schedule, convention);
		        m_pObjSwitchMethod.SalvageDeduction = 0;
            }

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
