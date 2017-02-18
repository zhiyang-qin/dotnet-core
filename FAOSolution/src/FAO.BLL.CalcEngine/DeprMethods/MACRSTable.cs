using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using FAO.BLL.Calendar;
using FAO.BLL.CalcEngine.Interfaces;
using FAO.BLL.Calendar.Interfaces;

namespace FAO.BLL.CalcEngine
{
    public class LIFEIDTABLE
    {
        public LIFEIDTABLE(short life, short id)
        {
            this.m_life = life;
            this.m_id = id;
        }

        public short life { get { return m_life; } }
        public short id { get { return m_id; } }
        short m_life;
        short m_id;
    }


    class MACRSTable : IBADeprMethod, IBADeprTableSupport, IBASwitchDepr
    {
        public static byte[] m_macrsTable;
        public static byte[] m_apolloMacrsTable;
        public static int m_macrsTableCount;
        public static int m_apolloMacrsTableCount;

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

        private double m_dAnuualRate;
        private int m_iSwitchYearNum;
        private bool m_bSwitchRequired;
        private bool m_bIsShortYear;
        private long m_lPeriod;
        private IBADeprMethod m_pObjSwitchMethod;
        private string m_parentFlags;
        private IBADeprTable m_Table;

        public MACRSTable()
        {
            string tmp = @"SFACalcEngine.DeprMethods.macrpcts.tbl";
            //string tmp = @"C:\GitSrc\sfa-daas\daas\CalcEngine\SFACalcEngine\DeprMethods\macrpcts.tbl";
            //string tmp = @"..\SFACalcEngine\DeprMethods\macrpcts.tbl";
            try
            {
                Assembly a = Assembly.GetEntryAssembly();
                string[] resources = a.GetManifestResourceNames();

                System.IO.Stream s = a.GetManifestResourceStream(tmp);
                var memoryStream = new MemoryStream();
                s.CopyTo(memoryStream);
                m_macrsTable = memoryStream.ToArray();
            }
            catch (Exception e)
            {
                string t = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                //string s = AppDomain.CurrentDomain.BaseDirectory;
                //s = e.Message;
            }
            m_macrsTableCount = m_macrsTable[0];

            //tmp = @"C:\GitSrc\sfa-daas\daas\CalcEngine\SFACalcEngine\DeprMethods\macrs2.tbl";
            tmp = @"SFACalcEngine.DeprMethods.macrs2.tbl";
            try
            {
                Assembly a = Assembly.GetEntryAssembly();
                string[] resources = a.GetManifestResourceNames();

                System.IO.Stream s = a.GetManifestResourceStream(tmp);
                var memoryStream = new MemoryStream();
                s.CopyTo(memoryStream);
                m_apolloMacrsTable = memoryStream.ToArray();
            }
            catch (Exception e)
            {
                string t = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                //string s = AppDomain.CurrentDomain.BaseDirectory;
                //s = e.Message;
            }
            //m_apolloMacrsTable = File.ReadAllBytes(tmp);
            m_apolloMacrsTableCount = m_apolloMacrsTable[0];

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

            m_dAnuualRate = 0;
            m_iSwitchYearNum = 0;
            m_bSwitchRequired = true;
            m_bIsShortYear = false;
            m_pObjSwitchMethod = null;
            m_lPeriod = 0;
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

	        dtPISDate = schedule.PlacedInServiceDate ;
	        Calendar = schedule.Calendar;
	        dtDeemedEnd = convention.DeemedEndDate;
	        Calendar.GetFiscalYear(dtPISDate, out pObjFY) ;
	        iStartYearNum = pObjFY.FYNum;
	        dtYrStart = pObjFY.YRStartDate;
	        dtYrEnd = pObjFY.YREndDate;
	
	        do
	        {
		        bShortYear = pObjFY.IsShortYear;
                iFYNum = pObjFY.FYNum;
		        if ( bShortYear )
		        {
			        return (short)(iFYNum - iStartYearNum + 1);
		        }
		        else
		        {
                    pObjFY = null;
                    Calendar.GetFiscalYear(dtYrEnd.AddDays( + 1), out pObjFY);
			        dtYrStart = pObjFY.YRStartDate;
			        dtYrEnd = pObjFY.YREndDate;
		        }
	        } while ( !bShortYear && dtYrStart <= dtDeemedEnd );
	
	        return 32767;
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
            bool hr;
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
            LIFEIDTABLE[] HY200 = new LIFEIDTABLE[]
                { new LIFEIDTABLE(3, 1), new LIFEIDTABLE(5, 2), new LIFEIDTABLE (7,  3), new LIFEIDTABLE (10,  4), new LIFEIDTABLE (15, 101), new LIFEIDTABLE (20, 102)};
            LIFEIDTABLE[] MQ200 = new LIFEIDTABLE[]
                { new LIFEIDTABLE(3, 5), new LIFEIDTABLE(5, 8), new LIFEIDTABLE(7, 11), new LIFEIDTABLE(10, 13), new LIFEIDTABLE(15, 103), new LIFEIDTABLE(16, 104)};
            LIFEIDTABLE[] MM100 = new LIFEIDTABLE[] 
                { new LIFEIDTABLE(27, 29), new LIFEIDTABLE(31, 30), new LIFEIDTABLE(39, 31)};
            LIFEIDTABLE[] HY150 = new LIFEIDTABLE[] {
                new LIFEIDTABLE( 30, 105), new LIFEIDTABLE( 36,  19), new LIFEIDTABLE( 42, 106), new LIFEIDTABLE( 48,  20), new LIFEIDTABLE( 60,  21), new LIFEIDTABLE( 72,  22), new LIFEIDTABLE( 78, 107), 
                new LIFEIDTABLE( 84,  23), new LIFEIDTABLE( 90, 108), new LIFEIDTABLE( 96, 109), new LIFEIDTABLE(102, 110), new LIFEIDTABLE(108, 111), new LIFEIDTABLE(114, 112), new LIFEIDTABLE(120,  24), 
                new LIFEIDTABLE(126, 113), new LIFEIDTABLE(132, 114), new LIFEIDTABLE(138, 115), new LIFEIDTABLE(144,  25), new LIFEIDTABLE(150, 116), new LIFEIDTABLE(156, 117), new LIFEIDTABLE(162, 118), 
                new LIFEIDTABLE(168, 119), new LIFEIDTABLE(180,  26), new LIFEIDTABLE(192, 120), new LIFEIDTABLE(198, 121), new LIFEIDTABLE(204, 122), new LIFEIDTABLE(216, 123), new LIFEIDTABLE(228, 124), 
                new LIFEIDTABLE(240,  27), new LIFEIDTABLE(264, 125), new LIFEIDTABLE(288, 126), new LIFEIDTABLE(300, 127), new LIFEIDTABLE(318, 128), new LIFEIDTABLE(336, 129), new LIFEIDTABLE(360, 130), 
                new LIFEIDTABLE(420, 131), new LIFEIDTABLE(480,  28), new LIFEIDTABLE(540, 132), new LIFEIDTABLE(600, 133) };
    
            LIFEIDTABLE[] MQ150 = new LIFEIDTABLE[] {
                new LIFEIDTABLE( 30, 134), new LIFEIDTABLE( 36,   6), new LIFEIDTABLE( 42, 135), new LIFEIDTABLE( 48,   7), new LIFEIDTABLE( 60,   9), new LIFEIDTABLE( 72,  10), new LIFEIDTABLE( 78, 136), 
                new LIFEIDTABLE( 84,  12), new LIFEIDTABLE( 90, 137), new LIFEIDTABLE( 96, 138), new LIFEIDTABLE(102, 139), new LIFEIDTABLE(108, 140), new LIFEIDTABLE(114, 141), new LIFEIDTABLE(120,  14), 
                new LIFEIDTABLE(126, 142), new LIFEIDTABLE(132, 143), new LIFEIDTABLE(138, 144), new LIFEIDTABLE(144,  15), new LIFEIDTABLE(150, 145), new LIFEIDTABLE(156, 146), new LIFEIDTABLE(162, 147), 
                new LIFEIDTABLE(168, 148), new LIFEIDTABLE(180,  16), new LIFEIDTABLE(192, 149), new LIFEIDTABLE(198, 150), new LIFEIDTABLE(204, 151), new LIFEIDTABLE(216, 152), new LIFEIDTABLE(228, 153), 
                new LIFEIDTABLE(240,  17), new LIFEIDTABLE(264, 154), new LIFEIDTABLE(288, 155), new LIFEIDTABLE(300, 156), new LIFEIDTABLE(318, 157), new LIFEIDTABLE(336, 158), new LIFEIDTABLE(360, 159), 
                new LIFEIDTABLE(420, 160), new LIFEIDTABLE(480,  18), new LIFEIDTABLE(540, 161), new LIFEIDTABLE(600, 162) };

	        if ( schedule == null )
		        return false;

	        m_Table = null;
            deprPercent = schedule.DeprPercent;
            deprLife = schedule.DeprLife;
            Salvage = schedule.SalvageDeduction;
            adjCost = schedule.AdjustedCost;
            PostUse= schedule.PostUsageDeduction ;
	        PlacedInServiceDate = schedule.PlacedInServiceDate;
	        AvgConvention = schedule.AvgConvention;

            DBPercent = deprPercent;
	        YearElapsed = 0;
            Life = deprLife;
            SalvageDeduction = Salvage;
            AdjustedCost = adjCost;
            PostUsageDeduction = PostUse;

	        //
	        // Now we need to determine the ACRS table number and load the table into the system.
	        //
            m_tableId = 0;

            if ( deprPercent == 200 )
            {
                if ( string.Compare(AvgConvention, "MQ") != 0 )  // is not mid quarter
                {
                    m_tableId = FindID((short)(deprLife + 0.01), HY200, 6);
                }
                else
                    m_tableId = FindID((short)(deprLife + 0.01), MQ200, 6);
            }
            else if ( deprPercent == 150 )
            {
                if ( string.Compare(AvgConvention, "MQ") != 0 )  // is not mid quarter
                {
                    m_tableId = FindID((short)(deprLife * 12 + 0.01), HY150, 39);
                }
                else
                    m_tableId = FindID((short)(deprLife * 12 + 0.01), MQ150, 39);
            }
	        else if ( deprPercent == 100 )
	        {
		        if ( string.Compare(AvgConvention, "MM") == 0 || string.Compare(AvgConvention, "MMM") == 0 )
			        m_tableId = FindID((short)(deprLife + 0.01), MM100, 3);
	        }

            if ( m_tableId == 0 )
            {
		        return true;
            }
	        //
	        // Load the table interface 
	        //
            //if ( FAILED(hr = CComObject<CBAUSDeprTable>::CreateInstance(&obj)) ||
            //     FAILED(hr = obj->QueryInterface(IID_IBADeprTable, (void**)&m_Table)) )
            //{
            //    delete obj;
            //    return hr;
            //}
            obj = new BAUSDeprTable();
            m_Table = (IBADeprTable)obj;
	        //
	        // Load the appropriate table into the interface
	        //
	        if ( m_tableId < 100 )
	        {
		        obj.LoadTable(m_macrsTable, m_tableId);
		        tablePeriodCount = m_Table.PeriodCount;
	        }
	        else
	        {
		        obj.LoadTable(m_apolloMacrsTable, m_tableId);
		        tablePeriodCount = m_Table.PeriodCount;
	        }
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
			        yearEnd= FY.YREndDate;
				
			        if ( yearEnd.Day < 8 )
			        {
				        // If the day is less than 8, then we need to "TRUE" it up to the proper month
				        yearEnd = yearEnd.AddDays( - yearEnd.Day);
				        if (PlacedInServiceDate > yearEnd)		// KENT
					        PlacedInServiceDate = yearEnd;
			        }
			        if ( PlacedInServiceDate.Year < yearEnd.Year)
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

            if (m_pObjSwitchMethod != null)
            {
                m_pObjSwitchMethod.Initialize(schedule, convention);
                m_pObjSwitchMethod.SalvageDeduction = 0;
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
