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
    class ACRSTable : IBADeprMethod, IBADeprTableSupport
    {
        public static byte[] m_acrsTable;
        public static byte[] m_acrsNonUSTable;
        public static int m_acrsTableCount;
        public static int m_acrsNonUSTableCount; 
        
        private double m_dAdjustedCost;
        private double m_dPostUsedDeduction;
        private double m_dPriorAccum;
        private double m_dYearElapsed;
        private double m_dLife;
        private double m_dFiscalYearFraction;
        private DateTime m_dtDeemedStartDate;
        private DateTime m_dtDeemedEndDate;
        private short m_iYearNum;
        private short m_sPlacedInServicePeriod;
        private short m_tableId;

        private string m_parentFlags;
        private IBADeprTable m_Table;
        private DISPOSALOVERRIDETYPE m_disposalOverride;

        public ACRSTable()
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

            tmp = @"SFACalcEngine.DeprMethods.acrnonus.TBL";
            try
            {
                Assembly a = Assembly.GetEntryAssembly();
                string[] resources = a.GetManifestResourceNames();

                System.IO.Stream s = a.GetManifestResourceStream(tmp);
                var memoryStream = new MemoryStream();
                s.CopyTo(memoryStream);
                m_acrsNonUSTable = memoryStream.ToArray();
            }
            catch (Exception e)
            {
                string t = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                //string s = AppDomain.CurrentDomain.BaseDirectory;
                //s = e.Message;
            }
            m_acrsNonUSTableCount = m_acrsNonUSTable[0]; 
            
            m_dAdjustedCost = 0;
            m_dPostUsedDeduction = 0;
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
            bool hr = false;

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
   
	        if ( PersonalProperty || PublicUtility )
		        tmp = "HYmb";
	        else if (deprLife < 17 || ((int)(deprLife + 0.01) == 18 && PlacedInServiceDate < new DateTime(1984, 6, 23)))
		        tmp = "FMmb";
	        else
		        tmp = "MMmb";

	        pVal = tmp;
	        return true;
        }

        public string BaseShortName
        {
            get { return "AT"; }
        }

        public string BaseLongName
        {
            get { return "ACRS Table"; }
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
            string AvgConvention;
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

            LIFEIDTABLE[] ATLives = new LIFEIDTABLE[] 
                {new LIFEIDTABLE(3, 1), new LIFEIDTABLE(5, 2), new LIFEIDTABLE(10, 3), new LIFEIDTABLE(15, 5), new LIFEIDTABLE(18, 7), new LIFEIDTABLE(19, 8)};

            LIFEIDTABLE[] HY100 = new LIFEIDTABLE[] {
		        new LIFEIDTABLE( 30, 104), new LIFEIDTABLE( 36, 105), new LIFEIDTABLE( 42, 106), new LIFEIDTABLE( 48, 107), new LIFEIDTABLE( 60, 108), new LIFEIDTABLE( 72, 109), new LIFEIDTABLE( 78, 110), 
		        new LIFEIDTABLE( 84, 111), new LIFEIDTABLE( 90, 112), new LIFEIDTABLE( 96, 113), new LIFEIDTABLE(102, 114), new LIFEIDTABLE(108, 115), new LIFEIDTABLE(114, 116), new LIFEIDTABLE(120, 117), 
		        new LIFEIDTABLE(126, 118), new LIFEIDTABLE(132, 119), new LIFEIDTABLE(138, 120), new LIFEIDTABLE(144, 121), new LIFEIDTABLE(150, 122), new LIFEIDTABLE(156, 123), new LIFEIDTABLE(162, 124), 
		        new LIFEIDTABLE(168, 125), new LIFEIDTABLE(180, 126), new LIFEIDTABLE(192, 127), new LIFEIDTABLE(198, 128), new LIFEIDTABLE(204, 129), new LIFEIDTABLE(216, 130), new LIFEIDTABLE(228, 131), 
		        new LIFEIDTABLE(240, 132), new LIFEIDTABLE(264, 133), new LIFEIDTABLE(300, 134), new LIFEIDTABLE(318, 135), new LIFEIDTABLE(336, 136), new LIFEIDTABLE(360, 137), new LIFEIDTABLE(420, 138), 
		        new LIFEIDTABLE(540, 139), new LIFEIDTABLE(600, 140) };

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

	        if ( OutsideUS )
	        {
		        if ( LowIncomeHousing )
		        {
			        if ( PlacedInServiceDate > new DateTime(1985,8,5) && PlacedInServiceDate < new DateTime(1987,1,1) )
			        {
				        m_tableId = 102;
			        }
		        }
		        if ( (int)(deprLife) == 35 && string.Compare(AvgConvention, "MM") == 0 &&  deprPercent == 150 )
		        {
		            if ( PlacedInServiceDate < new DateTime(1984,6,23) )
			        {
				        m_tableId = 141;
			        }
		            else if ( PlacedInServiceDate > new DateTime(1984,6,22) && PlacedInServiceDate < new DateTime(1985,5,9) )
			        {
				        m_tableId = 103;
			        }
			        else if ( PlacedInServiceDate > new DateTime(1985,8,5) && PlacedInServiceDate < new DateTime(1987,1,1) )
			        {
				        m_tableId = 101;
			        }
		        }
		        else if ( string.Compare(AvgConvention, "HY") == 0 )
		        {
			        m_tableId = FindID((short)((deprLife * 12)+0.01), HY100, 39);
		        }
	        }
	        else
	        {
		        if ( LowIncomeHousing )
		        {
			        if ( PlacedInServiceDate < new DateTime(1985,5,9) )
			        {
				        m_tableId = 9;
			        }
			        else
				        m_tableId = 10;
		        }
		        else if ( (int)(deprLife) == 15 && (PersonalProperty || PublicUtility) )
		        {
			        m_disposalOverride = DISPOSALOVERRIDETYPE.disposaloverride_NoneInYear;
			        m_tableId = 4;
		        }
		        else if ( (int)(deprLife) == 18 && PlacedInServiceDate < new DateTime(1984, 6,23) )
		        {
			        m_tableId = 6;
		        }
		        else
			        m_tableId = FindID((short)(deprLife), ATLives, 6);

	        }

	        //
	        // We could not find the table number, so return with error.
	        //
	        if ( m_tableId == 0 )
		        throw new Exception("Unable to determine ACRS Table Number.");

            if ( (PersonalProperty || PublicUtility) )
            {
		        m_disposalOverride = DISPOSALOVERRIDETYPE.disposaloverride_NoneInYear;
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
		        obj.LoadTable(m_acrsTable, m_tableId);
		        tablePeriodCount = m_Table.PeriodCount;
	        }
	        else
	        {
		        obj.LoadTable(m_acrsNonUSTable, m_tableId);
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
			        if ( monthCount < 1 )
				        monthCount = 1;
			        m_sPlacedInServicePeriod = (short)(13 - monthCount);
		        }
		        else
		        {
			        throw new Exception("Invalid ACRS table definition.");
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
