using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FAO.BLL.CalcEngine.Interfaces;
using FAO.BLL.Calendar.Interfaces;

namespace FAO.BLL.CalcEngine
{
    public class PeriodDeprItem : IBAPeriodDeprItem
    {
        private DateTime m_dtStartDate;
        private DateTime m_dtEndDate;
        private short m_iFYNum;
        private short m_iTotalPeriodWeights;

        private decimal m_curBeginYearAccum;
        private decimal m_curEndDateBeginYearAccum;
        private decimal m_curBeginYTDExpense;
        private decimal m_curDeprAmount;
        private decimal m_curAdjustAmount;
        private decimal m_curSection179Change;
        private decimal m_EndDateDeferredAccum;
        private decimal m_EndDateYTDDeferred;
        private decimal m_calcOverride;
        private decimal m_PersUseAccum;
        private decimal m_PersUseYTD;

        private double m_RemainingLife;
        private double m_PersonalUseAmount;
        private PERIODDEPRITEM_ENTRYTYPE m_eEntryType;
        private string m_sCalcFlags;

        public double m_dDeprAmountMarks;
        public double m_dAdjustAmountMarks;
        public double m_dYTDDeferredMarks;
        public double m_dYTDPersUseMarks;
        public double m_dPersUseMarks;
        public short m_iCountToLeft;
        public short m_iCountToRight;
        public short m_iYearWeight;

        public PeriodDeprItem()
        {
            Clear();
        }

        public DateTime StartDate
        {
            get
            {
                return m_dtStartDate;
            }
            set
            {
                m_dtStartDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return m_dtEndDate;
            }
            set
            {
                m_dtEndDate = value;
            }
        }

        public short FYNum
        {
            get
            {
                return m_iFYNum;
            }
            set
            {
                m_iFYNum = value;
            }
        }

        public short TotalPeriodWeights
        {
            get
            {
                return m_iTotalPeriodWeights;
            }
            set
            {
                m_iTotalPeriodWeights = value;
            }
        }

        public decimal BeginYearAccum
        {
            get
            {
                return m_curBeginYearAccum;
            }
            set
            {
                m_curBeginYearAccum = value;
            }
        }

        public decimal BeginYTDExpense
        {
            get
            {
                return m_curBeginYTDExpense;
            }
            set
            {
                m_curBeginYTDExpense = value;
            }
        }

        public decimal DeprAmount
        {
            get
            {
                return m_curDeprAmount;
            }
            set
            {
                m_curDeprAmount = value;
            }
        }

        public decimal AdjustAmount
        {
            get
            {
                return m_curAdjustAmount;
            }
            set
            {
                m_curAdjustAmount = value;
            }
        }

        public decimal Section179Change
        {
            get
            {
                return m_curSection179Change;
            }
            set
            {
                m_curSection179Change = value;
            }
        }

        public PERIODDEPRITEM_ENTRYTYPE EntryType
        {
            get
            {
                return m_eEntryType;
            }
            set
            {
                m_eEntryType = value;
            }
        }

        public double PeriodExpense
        {
            get
            {
                double dTmp;

                dTmp = (double)((m_curDeprAmount) + (m_curAdjustAmount) + (m_curSection179Change));

                return dTmp;
            }
        }

        public double BeginPeriodAccum
        {
            get
            {
                double dTmp;

                dTmp = (double)((m_curBeginYearAccum) + (m_curBeginYTDExpense));

                return dTmp;
            }

        }

        public double EndPeriodAccum
        {
            get
            {
                double dTmp;
                dTmp = (double)((m_curBeginYearAccum) + (m_curBeginYTDExpense)
                     + (m_curDeprAmount) + (m_curAdjustAmount)
                     + (m_curSection179Change));
                return dTmp;
            }

        }

        public double YTDExpense
        {
            get
            {
                double dTmp;

                dTmp = (double)((m_curBeginYTDExpense) + (m_curDeprAmount)
                     + (m_curAdjustAmount) + (m_curSection179Change));
                return dTmp;
            }

        }

        public double EndDateYTDExpense
        {
            get
            {
                double dTmp;

                dTmp = (double)((m_curBeginYearAccum) + (m_curBeginYTDExpense)
                     + (m_curDeprAmount) + (m_curAdjustAmount)
                     + (m_curSection179Change) - (m_curEndDateBeginYearAccum));
                return dTmp;
            }
        }

        public decimal CalcOverride
        {
            get
            {
                return m_calcOverride;
            }
            set
            {
                m_calcOverride = value;
            }
        }

        public string CalcFlags
        {
            get
            {
                return m_sCalcFlags;
            }
            set
            {
                m_sCalcFlags = value;
            }
        }

        public decimal EndDateBeginYearAccum
        {
            get
            {
                return m_curEndDateBeginYearAccum;
            }
            set
            {
                m_curEndDateBeginYearAccum = value;
            }
        }

        public bool Clear()
        {
 	        m_dtStartDate = DateTime.MinValue; 
	        m_dtEndDate = DateTime.MinValue; 
	        m_iFYNum = 0; 
	        m_iTotalPeriodWeights = 0; 
	        m_curBeginYearAccum = 0; 
	        m_curEndDateBeginYearAccum = 0; 
	        m_curBeginYTDExpense = 0; 
	        m_curDeprAmount = 0; 
	        m_curAdjustAmount = 0; 
	        m_curSection179Change = 0; 
	        m_EndDateDeferredAccum = 0;
	        m_EndDateYTDDeferred = 0;
	        m_calcOverride = 0;
	        m_PersUseAccum = 0;
	        m_PersUseYTD = 0;
	        m_RemainingLife = 0;
            m_eEntryType = PERIODDEPRITEM_ENTRYTYPE.PERIODDEPRITEM_NORMAL; 
	        m_sCalcFlags = String.Empty;
	        m_PersonalUseAmount = 0;
	        m_dDeprAmountMarks = 0;
	        m_dAdjustAmountMarks = 0;
	        m_dYTDDeferredMarks = 0;
	        m_dYTDPersUseMarks = 0;
	        m_dPersUseMarks = 0;
	        m_iCountToLeft = 0;
	        m_iCountToRight = 0;
	        m_iYearWeight = 0;
            return true;
        }

        public decimal EndDateDeferredAccum
        {
            get
            {
                return m_EndDateDeferredAccum;
            }
            set
            {
                m_EndDateDeferredAccum = value;
            }
        }

        public decimal EndDateYTDDeferred
        {
            get
            {
                return m_EndDateYTDDeferred;
            }
            set
            {
                m_EndDateYTDDeferred = value;
            }
        }

        public decimal EndDatePersonalUseAccum
        {
            get
            {
                return m_PersUseAccum;
            }
            set
            {
                m_PersUseAccum = value;
            }
        }

        public decimal EndDateYTDPersonalUse
        {
            get
            {
                return m_PersUseYTD;
            }
            set
            {
                m_PersUseYTD = value;
            }
        }

        public double RemainingLife
        {
            get
            {
                return m_RemainingLife;
            }
            set
            {
                m_RemainingLife = value;
            }
        }

        public double PersonalUseAmount
        {
            get
            {
                return m_PersonalUseAmount;
            }
            set
            {
                m_PersonalUseAmount = value;
            }
        }

        public bool Clone(out IBAPeriodDeprItem pVal)
        {
            pVal = null;
            string sTmp;
            PeriodDeprItem obj;

            obj = new PeriodDeprItem();
            pVal = (IBAPeriodDeprItem)obj;

            obj.m_dDeprAmountMarks = m_dDeprAmountMarks;
            obj.m_dAdjustAmountMarks = m_dAdjustAmountMarks;
            obj.m_dYTDDeferredMarks = m_dYTDDeferredMarks;
            obj.m_dYTDPersUseMarks = m_dYTDPersUseMarks;
            obj.m_dPersUseMarks = m_dPersUseMarks;
            obj.m_iCountToLeft = m_iCountToLeft;
            obj.m_iCountToRight = m_iCountToRight;
            obj.m_iYearWeight = m_iYearWeight;

            pVal.TotalPeriodWeights = TotalPeriodWeights;
            pVal.StartDate = StartDate;
            pVal.EndDate = EndDate;

            pVal.BeginYearAccum = BeginYearAccum;
            pVal.EndDateBeginYearAccum = EndDateBeginYearAccum;
            pVal.EntryType = EntryType;
            pVal.CalcFlags = CalcFlags;
            pVal.FYNum = FYNum;

            pVal.DeprAmount = DeprAmount;
            pVal.AdjustAmount = AdjustAmount;
            pVal.BeginYTDExpense = BeginYTDExpense;

            pVal.EndDateDeferredAccum = EndDateDeferredAccum;
            pVal.EndDateYTDDeferred = EndDateYTDDeferred;

            pVal.EndDatePersonalUseAccum = EndDatePersonalUseAccum;
            pVal.EndDateYTDPersonalUse = EndDateYTDPersonalUse;
            pVal.PersonalUseAmount = PersonalUseAmount;

            return true;
        }

        public bool Split2ways(DateTime rightStart, IBACalendar pObjCalendar, DateTime PISDate, DateTime DeemedEndDate, ref IBAPeriodDeprItem left, ref IBAPeriodDeprItem right)
        {
            bool hr;
            DateTime periodStart;
            DateTime periodEnd;
            DateTime rightStartDate;
            IBAFiscalYear pObjIFY;
            IBACalcPeriod pObjPeriod;
            PeriodDeprItem leftobj;
            PeriodDeprItem rightobj;
            IBAPeriodDeprItem pObjLeft;
            IBAPeriodDeprItem pObjRight;
            short iLeftWeight;
            short iPDWeight;
            short iAnnualWeight;
            short iFYNum;
            decimal cyDeprAmount;
            decimal cyAdjustAmount;
            decimal cyTmp1 = 0;
            decimal cyTmp2 = 0;
            decimal cyTmp3 = 0;
            double dTmp1 = 0;
            double dTmp2 = 0;
            double dTmp3 = 0;
            double dRemLife;
            PERIODDEPRITEM_ENTRYTYPE ePDType;
            string sTmp;

            if (rightStart <= new DateTime(1920, 1, 1))
                return false;

            //if ( left != null )
            //    left = null;
            //(left) = null;

            //if ( right != null )
            //    right = null;
            //(right) = null;

            //
            // Get the source period start and end dates.
            //
            periodStart = StartDate;
            periodEnd = EndDate;
            //
            // Make sure that the date passed in is valid.
            //
            if (rightStart < periodStart || rightStart > periodEnd)
                return false;

            decimal cyZero = 0;
            //
            // Now we need to check for the first exception for this routine.  This exception is that we are splitting the 
            // depr record that goes from the last year to the year 3000.
            //
            if (periodEnd >= new DateTime(2999, 12, 31))
            {
                //
                // Since we are in the last PD item and it goes to the year 3000, we need to split the node
                // into two parts.
                //
                Clone(out pObjLeft);
                Clone(out pObjRight);
                pObjCalendar.GetFiscalYear(rightStart, out pObjIFY);
                pObjIFY.GetPeriod(rightStart, out pObjPeriod);
                rightStartDate = pObjPeriod.PeriodStart;
                pObjLeft.EndDate = rightStartDate.AddDays(-1);
                pObjRight.StartDate = rightStartDate;

                left = pObjLeft;
                right = pObjRight;
                return true;
            }
            //
            //
            // Now get the first period, so that we can check for the second exception for this routine.
            //
            pObjCalendar.GetFiscalYear(periodStart, out pObjIFY);
            pObjIFY.GetPeriod(rightStart, out pObjPeriod);
            rightStartDate = pObjPeriod.PeriodStart;

            //
            // Now check for the only exception.  If the date is in the first period, then there is no left portion.
            // Return everything in the right portion.
            //
            //	if ( rightStartDate == periodStart )
            // KENT		-- I think the condition should be   fix NFaus-00116
            if (rightStartDate <= periodStart)
            {
                // KENT Start  -- fix MS MC-00026
                leftobj = new PeriodDeprItem();
                pObjLeft = (IBAPeriodDeprItem)leftobj;

                cyTmp1 = 0;
                pObjLeft.StartDate = DateTime.MinValue;
                pObjLeft.EndDate = DateTime.MinValue;
                pObjLeft.FYNum = 0;
                pObjLeft.RemainingLife = 0;
                pObjLeft.TotalPeriodWeights = 0;
                pObjLeft.BeginYearAccum = cyTmp1;
                pObjLeft.BeginYTDExpense = cyTmp1;
                pObjLeft.DeprAmount = cyTmp1;
                pObjLeft.AdjustAmount = cyTmp1;
                pObjLeft.PersonalUseAmount = 0;
                pObjLeft.EndDateBeginYearAccum = cyTmp1;
                pObjLeft.EndDateDeferredAccum = cyTmp1;
                pObjLeft.EndDateYTDDeferred = cyTmp1;
                pObjLeft.EndDatePersonalUseAccum = cyTmp1;
                pObjLeft.EndDateYTDPersonalUse = cyTmp1;
                left = pObjLeft;
                //		left = null;
                // KENT End
                right = new PeriodDeprItem();
                return true;
            }
            //
            // We are now ready to create and populate the two new period depr items.  First we will create the items.
            //
            leftobj = new PeriodDeprItem();
            pObjLeft = (IBAPeriodDeprItem)leftobj;
            rightobj = new PeriodDeprItem();
            pObjRight = (IBAPeriodDeprItem)rightobj;


            //
            // Now get the PeriodWeights for the left and right parts.  Also set up the period dates.
            //
            pObjIFY.GetPeriodWeights(periodStart, rightStartDate.AddDays(-1), out iLeftWeight);
            iPDWeight = TotalPeriodWeights;
            pObjIFY.GetTotalAnnualPeriodWeights(out iAnnualWeight);
            dRemLife = RemainingLife;
            pObjRight.RemainingLife = dRemLife;
            pObjLeft.RemainingLife = (dRemLife + ((double)(iPDWeight - iLeftWeight)) / iAnnualWeight);
            pObjLeft.TotalPeriodWeights = iLeftWeight;
            pObjRight.TotalPeriodWeights = (short)(iPDWeight - iLeftWeight);
            pObjLeft.StartDate = periodStart;
            pObjLeft.EndDate = rightStartDate.AddDays(-1);
            pObjRight.StartDate = rightStartDate;
            pObjRight.EndDate = periodEnd;


            // KENT if the RemainingLife for the periodStart is already 0 
            // then the pObjLeft.put_RemainingLife(dRemLife + (double(iPDWeight - iLeftWeight)) / iAnnualWeight)) 
            // will add some life to the pObjLeft this will make nbv report wrong. 
            if (periodStart > DeemedEndDate)
                pObjLeft.RemainingLife = 0;

            //
            // We need to determine the marks values now.
            //
            if (m_iCountToLeft == 0 && m_iCountToRight == 0 && m_iYearWeight == 0)
            {
                decimal cyYTDDeferred, cyYTDPersUse;
                double dPersUseAmount;
                DateTime YearStart;
                DateTime YearEnd;
                IBAFiscalYear pObjFY;

                cyDeprAmount = DeprAmount;
                cyAdjustAmount = AdjustAmount;
                cyYTDDeferred = EndDateYTDDeferred;
                cyYTDPersUse = EndDateYTDPersonalUse;
                dPersUseAmount = PersonalUseAmount;


                //
                // Now determine the year weight
                //
                pObjCalendar.GetFiscalYear(rightStart, out pObjFY);
                YearStart = pObjFY.YRStartDate;
                YearEnd = pObjFY.YREndDate;

                if (PISDate > DateTime.MinValue && YearStart < PISDate && PISDate <= YearEnd)
                {
                    if (periodStart < PISDate)
                        YearStart = PISDate;
                    else if (YearStart < periodStart && periodStart < YearEnd)
                        YearStart = periodStart;
                }

                if (DeemedEndDate > DateTime.MinValue && YearEnd > DeemedEndDate && DeemedEndDate >= YearStart)
                    YearEnd = DeemedEndDate;

                pObjFY.GetPeriodWeights(YearStart, YearEnd, out m_iYearWeight);


                //
                // Now we can compute the marks for each splitable member.
                //
                m_dDeprAmountMarks = ComputeMarksForYear(m_iYearWeight, (double)cyDeprAmount, rightStartDate);
                //		m_dAdjustAmountMarks = ComputeMarksForYear (m_iYearWeight, cyAdjustAmount, rightStartDate);
                m_dYTDDeferredMarks = ComputeMarksForYear(m_iYearWeight, (double)cyYTDDeferred, rightStartDate);
                m_dYTDPersUseMarks = ComputeMarksForYear(m_iYearWeight, (double)cyYTDPersUse, rightStartDate);
                m_dPersUseMarks = ComputeMarksForYear(m_iYearWeight, dPersUseAmount, rightStartDate);

            }
            //
            // Now we need to set up some internal variables.
            //
            leftobj.m_iCountToLeft = m_iCountToLeft;
            leftobj.m_iCountToRight = (short)(m_iCountToRight + iPDWeight - iLeftWeight);
            leftobj.m_iYearWeight = m_iYearWeight;

            rightobj.m_iCountToLeft = (short)(m_iCountToLeft + iLeftWeight);
            rightobj.m_iCountToRight = m_iCountToRight;
            rightobj.m_iYearWeight = m_iYearWeight;

            //
            // Now copy over the five marks values to both destination records.
            //
            leftobj.m_dDeprAmountMarks = m_dDeprAmountMarks;
            //	leftobj.m_dAdjustAmountMarks = m_dAdjustAmountMarks;
            leftobj.m_dYTDDeferredMarks = m_dYTDDeferredMarks;
            leftobj.m_dYTDPersUseMarks = m_dYTDPersUseMarks;
            leftobj.m_dPersUseMarks = m_dPersUseMarks;

            rightobj.m_dDeprAmountMarks = m_dDeprAmountMarks;
            //	rightobj.m_dAdjustAmountMarks = m_dAdjustAmountMarks;
            rightobj.m_dYTDDeferredMarks = m_dYTDDeferredMarks;
            rightobj.m_dYTDPersUseMarks = m_dYTDPersUseMarks;
            rightobj.m_dPersUseMarks = m_dPersUseMarks;


            //
            // Now transfer those parts that do not change.
            //
            cyTmp1 = BeginYearAccum;
            pObjLeft.BeginYearAccum = cyTmp1;
            pObjLeft.EndDateBeginYearAccum = cyTmp1;
            pObjRight.BeginYearAccum = cyTmp1;
            pObjRight.EndDateBeginYearAccum = cyTmp1;
            cyAdjustAmount = AdjustAmount;   //SAI: Adjustment is always given to Left one
            pObjLeft.AdjustAmount = cyAdjustAmount;
            pObjRight.AdjustAmount = cyZero; //end of Adjustment fix
            ePDType = EntryType;
            pObjLeft.EntryType = ePDType;
            pObjRight.EntryType = ePDType;
            sTmp = CalcFlags;
            pObjLeft.CalcFlags = sTmp;
            pObjRight.CalcFlags = sTmp; //we need to remove 'a' from right
            iFYNum = FYNum;
            pObjLeft.FYNum = iFYNum;
            pObjRight.FYNum = iFYNum;


            //
            // Now start allocating the depr numbers to the left and right portions.
            //
            cyDeprAmount = DeprAmount;
            ComputeCurrencyFraction(m_dDeprAmountMarks, cyDeprAmount, iLeftWeight, iPDWeight, rightStart, ref cyDeprAmount, ref cyTmp1);
            pObjLeft.DeprAmount = cyDeprAmount;
            pObjRight.DeprAmount = cyTmp1;
            //	get_AdjustAmount(&cyTmp1)) ||
            //	ComputeCurrencyFraction(m_dAdjustAmountMarks, cyTmp1, iLeftWeight, iPDWeight, rightStart, &cyTmp1, &cyTmp2)) ||
            //	pObjLeft.put_AdjustAmount = cyTmp1;
            //	pObjRight.put_AdjustAmount(cyTmp2)) ||
            cyTmp1 = BeginYTDExpense;
            pObjLeft.BeginYTDExpense = cyTmp1;


            //
            // The YTD values must be handled a little differently.  The right pd item is the
            // Left plus the depr amount for the left.
            //
            cyTmp2 = cyTmp1 + cyDeprAmount + cyAdjustAmount;
            pObjRight.BeginYTDExpense = cyTmp2;


            //
            // The deferred depreciation is not follow the normal Accum/YTD pattern.  The accum is
            // the amount that has been deferred up to this period.  The YTD is the amount deferred
            // in this period.  We are now going to handle the deferred amounts.
            //
            cyTmp1 = EndDateDeferredAccum;
            cyTmp2 = EndDateYTDDeferred;
            ComputeCurrencyFraction(m_dYTDDeferredMarks, cyTmp2, iLeftWeight, iPDWeight, rightStart, ref cyTmp2, ref cyTmp3);
            pObjLeft.EndDateDeferredAccum = cyTmp1;
            pObjLeft.EndDateYTDDeferred = cyTmp2;

            cyTmp2 = cyTmp2 + cyTmp1;
            pObjRight.EndDateDeferredAccum = cyTmp2;
            pObjRight.EndDateYTDDeferred = cyTmp3;

            //
            // The personal use amounts also do not follow the normal Accum/YTD pattern.  
            // The accum is the amount that has been disallowed up to this period.  The YTD 
            // is the amount disallowed in this period.  We are now going to handle the personal 
            // use amounts.
            //
            cyTmp1 = EndDatePersonalUseAccum;
            cyTmp2 = EndDateYTDPersonalUse;
            dTmp1 = PersonalUseAmount;
            ComputeYTDCurrencyFraction(m_dYTDPersUseMarks, cyTmp2, iLeftWeight, iPDWeight, rightStart, ref cyTmp2, ref cyTmp3);
            ComputeDoubleFraction(m_dPersUseMarks, dTmp1, iLeftWeight, iPDWeight, rightStart, ref dTmp2, ref dTmp3);
            pObjLeft.EndDatePersonalUseAccum = cyTmp1;
            pObjLeft.EndDateYTDPersonalUse = cyTmp2;
            pObjLeft.PersonalUseAmount = dTmp2;
            pObjRight.EndDatePersonalUseAccum = cyTmp1;
            pObjRight.EndDateYTDPersonalUse = cyTmp3;
            pObjRight.PersonalUseAmount = dTmp3;


            //
            // Yes, we are done.  Therefore make the output variables contain the valid pointers;
            //

            left = pObjLeft;
            right = pObjRight;
            return true;
        }

        public bool Split3ways(DateTime middleStart, DateTime rightStart, IBACalendar pObjCalendar, DateTime PISDate, DateTime DeemedEndDate, ref IBAPeriodDeprItem left, ref IBAPeriodDeprItem middle, ref IBAPeriodDeprItem right)
        {
            bool hr;
            DateTime periodStart;
            DateTime periodEnd;
            DateTime rightStartDate;
            DateTime middleStartDate;
            IBAFiscalYear pObjIFY;
            IBACalcPeriod pObjPeriod;
            PeriodDeprItem leftobj;
            PeriodDeprItem middleobj;
            PeriodDeprItem rightobj;
            IBAPeriodDeprItem pObjLeft;
            IBAPeriodDeprItem pObjMiddle;
            IBAPeriodDeprItem pObjRight;
            short iLeftWeight;
            short iMiddleWeight;
            short iPDWeight;
            short iFYNum;
            decimal cyDeprAmount;
            decimal cyAdjustAmount;
            decimal cyTmp1 = 0;
            decimal cyTmp2 = 0;
            decimal cyTmp3 = 0;
            decimal cyTmpMiddle = 0;
            decimal cyTmpMiddle1 = 0;
            double dTmp1 = 0;
            double dTmp2 = 0;
            double dTmp3 = 0;
            double dTmpMiddle = 0;
            PERIODDEPRITEM_ENTRYTYPE ePDType;
            string sTmp;

            if (left == null || right == null || middle == null)
                return false;
            if (rightStart <= DateTime.MinValue || middleStart <= DateTime.MinValue)
                return false;

            //if ( left != null )
            //    (left).Release();
            //(left) = null;

            //if ( right != null )
            //    (right).Release();
            //(right) = null;

            //if ( middle != null )
            //    (middle).Release();
            //(middle) = null;

            //
            // Get the source period start and end dates.
            //
            periodStart = StartDate;
            periodEnd = EndDate;

            //
            // Make sure that the date passed in is valid.
            //
            if (rightStart < periodStart || rightStart > periodEnd || middleStart >= rightStart || middleStart <= periodStart)
                return false;

            decimal cyZero = 0;
            //
            // Now we need to check for the first exception for this routine.  This exception is that we are splitting the 
            // depr record that goes from the last year to the year 3000.
            //
            if (periodEnd >= new DateTime(2999, 12, 31))
            {
                IBAPeriodDeprItem tempItem = new PeriodDeprItem();

                //
                // Since we are in the last PD item and it goes to the year 3000, we need to split the node
                // into multiple parts.
                //
                Split2ways(middleStart, pObjCalendar, PISDate, DeemedEndDate, ref left, ref  tempItem);


                if (tempItem != null)
                {
                    middle = null;
                    right = null;
                }
                return tempItem.Split2ways(rightStart, pObjCalendar, PISDate, DeemedEndDate, ref middle, ref right);
            }
            //
            //
            // Now get the first period, so that we can check for the second exception for this routine.
            //
            pObjCalendar.GetFiscalYear(periodStart, out pObjIFY);
            pObjIFY.GetPeriod(rightStart, out pObjPeriod);
            rightStartDate = pObjPeriod.PeriodStart;

            //
            // Now check for the exception.  If the right date is in the first period, then there 
            // is no left or middle portions.  Return everything in the right portion.
            //
            if (rightStartDate == periodStart)
            {
                left = null;
                middle = null;
                right = new PeriodDeprItem();
                return true;
            }
            //
            // Now check for the exception.  If the middle date is in the first period, then there 
            // is no left portion.  Perform a simple two way split.
            //
            pObjPeriod = null;
            pObjIFY.GetPeriod(middleStart, out pObjPeriod);
            middleStartDate = pObjPeriod.PeriodStart;

            if (middleStartDate <= periodStart)
            {
                left = null;
                return Split2ways(rightStart, pObjCalendar, PISDate, DeemedEndDate, ref middle, ref right);
            }

            //
            // We are now ready to create and populate the two new period depr items.  First we will create the items.
            //
            leftobj = new PeriodDeprItem();
            pObjLeft = (IBAPeriodDeprItem)leftobj;
            middleobj = new PeriodDeprItem();
            pObjMiddle = (IBAPeriodDeprItem)middleobj;
            rightobj = new PeriodDeprItem();
            pObjRight = (IBAPeriodDeprItem)rightobj;

            //
            // Now get the PeriodWeights for the left and right parts.  Also set up the period dates.
            //
            pObjIFY.GetPeriodWeights(periodStart, middleStartDate.AddDays(-1), out iLeftWeight);
            pObjIFY.GetPeriodWeights(middleStartDate, rightStartDate.AddDays(-1), out iMiddleWeight);
            iPDWeight = TotalPeriodWeights;
            pObjLeft.TotalPeriodWeights = iLeftWeight;
            pObjMiddle.TotalPeriodWeights = iMiddleWeight;
            pObjRight.TotalPeriodWeights = (short)(iPDWeight - iLeftWeight - iMiddleWeight);
            pObjLeft.StartDate = periodStart;
            pObjLeft.EndDate = middleStartDate.AddDays(-1);
            pObjMiddle.StartDate = middleStartDate;
            pObjMiddle.EndDate = rightStartDate.AddDays(-1);
            pObjRight.StartDate = rightStartDate;
            pObjRight.EndDate = periodEnd;


            //
            // We need to determine the marks values now.
            //
            if (m_iCountToLeft == 0 && m_iCountToRight == 0 && m_iYearWeight == 0)
            {
                decimal cyYTDDeferred, cyYTDPersUse;
                double dPersUseAmount;
                DateTime YearStart;
                DateTime YearEnd;
                IBAFiscalYear pObjFY;

                cyDeprAmount = DeprAmount;
                cyAdjustAmount = AdjustAmount;
                cyYTDDeferred = EndDateYTDDeferred;
                cyYTDPersUse = EndDateYTDPersonalUse;
                dPersUseAmount = PersonalUseAmount;


                //
                // Now determine the year weight
                //
                pObjCalendar.GetFiscalYear(rightStart, out pObjFY);
                YearStart = pObjFY.YRStartDate;
                YearEnd = pObjFY.YREndDate;

                if (PISDate > DateTime.MinValue && YearStart < PISDate && PISDate <= YearEnd)
                {
                    if (periodStart < PISDate)
                        YearStart = PISDate;
                    else if (YearStart < periodStart && periodStart < YearEnd)
                        YearStart = periodStart;
                }

                if (DeemedEndDate > DateTime.MinValue && YearEnd > DeemedEndDate && DeemedEndDate > YearStart)
                    YearEnd = DeemedEndDate;

                pObjFY.GetPeriodWeights(YearStart, YearEnd, out m_iYearWeight);

                //
                // Now we can compute the marks for each splitable member.
                //
                m_dDeprAmountMarks = ComputeMarksForYear(m_iYearWeight, (double)(cyDeprAmount), rightStartDate);
                //		m_dAdjustAmountMarks = ComputeMarksForYear (m_iYearWeight, (double)(cyAdjustAmount), rightStartDate);
                m_dYTDDeferredMarks = ComputeMarksForYear(m_iYearWeight, (double)(cyYTDDeferred), rightStartDate);
                m_dYTDPersUseMarks = ComputeMarksForYear(m_iYearWeight, (double)(cyYTDPersUse), rightStartDate);
                m_dPersUseMarks = ComputeMarksForYear(m_iYearWeight, dPersUseAmount, rightStartDate);

            }
            //
            // Now we need to set up some internal variables.
            //
            leftobj.m_iCountToLeft = m_iCountToLeft;
            leftobj.m_iCountToRight = (short)(m_iCountToRight + iPDWeight - iLeftWeight);
            leftobj.m_iYearWeight = m_iYearWeight;

            middleobj.m_iCountToLeft = (short)(m_iCountToLeft + iLeftWeight);
            middleobj.m_iCountToRight = (short)(m_iCountToRight + iPDWeight - iLeftWeight - iMiddleWeight);
            middleobj.m_iYearWeight = m_iYearWeight;

            rightobj.m_iCountToLeft = (short)(m_iCountToLeft + iLeftWeight + iMiddleWeight);
            rightobj.m_iCountToRight = m_iCountToRight;
            rightobj.m_iYearWeight = m_iYearWeight;

            //
            // Now copy over the five marks values to all three destination records.
            //
            leftobj.m_dDeprAmountMarks = m_dDeprAmountMarks;
            //	leftobj.m_dAdjustAmountMarks = m_dAdjustAmountMarks;
            leftobj.m_dYTDDeferredMarks = m_dYTDDeferredMarks;
            leftobj.m_dYTDPersUseMarks = m_dYTDPersUseMarks;
            leftobj.m_dPersUseMarks = m_dPersUseMarks;

            middleobj.m_dDeprAmountMarks = m_dDeprAmountMarks;
            //	middleobj.m_dAdjustAmountMarks = m_dAdjustAmountMarks;
            middleobj.m_dYTDDeferredMarks = m_dYTDDeferredMarks;
            middleobj.m_dYTDPersUseMarks = m_dYTDPersUseMarks;
            middleobj.m_dPersUseMarks = m_dPersUseMarks;

            rightobj.m_dDeprAmountMarks = m_dDeprAmountMarks;
            //	rightobj.m_dAdjustAmountMarks = m_dAdjustAmountMarks;
            rightobj.m_dYTDDeferredMarks = m_dYTDDeferredMarks;
            rightobj.m_dYTDPersUseMarks = m_dYTDPersUseMarks;
            rightobj.m_dPersUseMarks = m_dPersUseMarks;

            //
            // Now transfer those parts that do not change.
            //
            cyTmp1 = BeginYearAccum;
            pObjLeft.BeginYearAccum = cyTmp1;
            pObjLeft.EndDateBeginYearAccum = cyTmp1;
            pObjMiddle.BeginYearAccum = cyTmp1;
            pObjMiddle.EndDateBeginYearAccum = cyTmp1;
            pObjRight.BeginYearAccum = cyTmp1;
            pObjRight.EndDateBeginYearAccum = cyTmp1;
            cyAdjustAmount = AdjustAmount;   //SAI: Adjustment is always given to Left one
            pObjLeft.AdjustAmount = cyAdjustAmount;
            pObjMiddle.AdjustAmount = cyZero;
            pObjRight.AdjustAmount = cyZero; //end of Adjustment fix
            ePDType = EntryType;
            pObjLeft.EntryType = ePDType;
            pObjMiddle.EntryType = ePDType;
            pObjRight.EntryType = ePDType;
            sTmp = CalcFlags;
            pObjLeft.CalcFlags = sTmp;
            pObjMiddle.CalcFlags = sTmp;
            pObjRight.CalcFlags = sTmp;
            iFYNum = FYNum;
            pObjLeft.FYNum = iFYNum;
            pObjMiddle.FYNum = iFYNum;
            pObjRight.FYNum = iFYNum;


            //
            // Now start allocating the depr numbers to the left and right portions.
            //
            cyDeprAmount = DeprAmount;
            Compute3wayCurrencyFraction(m_dDeprAmountMarks, cyDeprAmount, iLeftWeight, iMiddleWeight, iPDWeight, middleStartDate, rightStart, ref cyDeprAmount, ref cyTmpMiddle1, ref cyTmp1);
            pObjLeft.DeprAmount = cyDeprAmount;
            pObjMiddle.DeprAmount = cyTmpMiddle1;
            pObjRight.DeprAmount = cyTmp1;
            //		  get_AdjustAmount(&cyTmp1)) ||
            //		  Compute3wayCurrencyFraction(m_dAdjustAmountMarks, cyTmp1, iLeftWeight, iMiddleWeight, iPDWeight, middleStartDate, rightStart, &cyTmp1, &cyTmpMiddle, &cyTmp2)) ||
            //		  pObjLeft.put_AdjustAmount = cyTmp1;
            //		  pObjMiddle.put_AdjustAmount(cyTmpMiddle)) ||
            //		  pObjRight.put_AdjustAmount(cyTmp2)) ||
            cyTmp1 = BeginYTDExpense;
            pObjLeft.BeginYTDExpense = cyTmp1;

            //
            // The YTD values must be handled a little differently.  The middle pd item is the
            // Left plus the depr amount for the left.
            //
            cyTmp2 = cyTmp1 + cyDeprAmount + cyAdjustAmount;
            pObjMiddle.BeginYTDExpense = cyTmp2;

            //
            // The YTD values must be handled a little differently.  The right pd item is the
            // Left plus the depr amount for the left and middle.
            //
            cyTmp2 = cyTmp1 + cyDeprAmount + cyAdjustAmount + cyTmpMiddle1;
            pObjRight.BeginYTDExpense = cyTmp2;


            //
            // The deferred depreciation does not follow the normal Accum/YTD pattern.  The accum is
            // the amount that has been deferred up to this period.  The YTD is the amount deferred
            // in this period.  We are now going to handle the deferred amounts.
            //
            cyTmp1 = EndDateDeferredAccum;
            cyTmp2 = EndDateYTDDeferred;
            Compute3wayCurrencyFraction(m_dYTDDeferredMarks, cyTmp2, iLeftWeight, iMiddleWeight, iPDWeight, middleStartDate, rightStart, ref cyTmp2, ref cyTmpMiddle, ref cyTmp3);
            pObjLeft.EndDateDeferredAccum = cyTmp1;
            pObjLeft.EndDateYTDDeferred = cyTmp2;

            cyTmp2 = cyTmp1 + cyTmp2;
            pObjMiddle.EndDateDeferredAccum = cyTmp2;
            pObjMiddle.EndDateYTDDeferred = cyTmpMiddle;

            cyTmp2 = cyTmp1 + cyTmp2 + cyTmpMiddle;
            pObjRight.EndDateDeferredAccum = cyTmp2;
            pObjRight.EndDateYTDDeferred = cyTmp3;

            //
            // The personal use amounts also do not follow the normal Accum/YTD pattern.  
            // The accum is the amount that has been disallowed up to this period.  The YTD 
            // is the amount disallowed in this period.  We are now going to handle the personal 
            // use amounts.
            //
            cyTmp1 = EndDatePersonalUseAccum;
            cyTmp2 = EndDateYTDPersonalUse;
            dTmp1 = PersonalUseAmount;
            Compute3wayYTDCurrencyFraction(m_dYTDPersUseMarks, cyTmp2, iLeftWeight, iMiddleWeight, iPDWeight, middleStartDate, rightStart, ref cyTmp2, ref cyTmpMiddle, ref cyTmp3);
            Compute3wayDoubleFraction(m_dPersUseMarks, dTmp1, iLeftWeight, iMiddleWeight, iPDWeight, middleStartDate, rightStart, ref dTmp2, ref dTmpMiddle, ref dTmp3);
            pObjLeft.EndDatePersonalUseAccum = cyTmp1;
            pObjLeft.EndDateYTDPersonalUse = cyTmp2;
            pObjLeft.PersonalUseAmount = dTmp2;
            pObjMiddle.EndDatePersonalUseAccum = cyTmp1;
            pObjMiddle.EndDateYTDPersonalUse = cyTmpMiddle;
            pObjMiddle.PersonalUseAmount = dTmpMiddle;
            pObjRight.EndDatePersonalUseAccum = cyTmp1;
            pObjRight.EndDateYTDPersonalUse = cyTmp3;
            pObjRight.PersonalUseAmount = dTmp3;


            //
            // Yes, we are done.  Therefore make the output variables contain the valid pointers;
            //

            left = pObjLeft;
            middle = pObjMiddle;
            right = pObjRight;
            return true;
        }


        double ComputeMarksForYear(short YearWeight, double value, DateTime RHSDate)
        {
            double Trunc;
            double Rounding_Variance;
            double Raw_Distr, Distr_Mark = 0.0;
            double Marks_Available = 0.0;
            double Marks_Taken = 0.0;
            double MonthlyPart = 0.0;
            double intpart = 0.0;
            double g_dblScaledRoundingFactor = 100.0;

            // truncate monthly depreciation

            MonthlyPart = value / (double)YearWeight;

            intpart = MonthlyPart * g_dblScaledRoundingFactor;
            intpart = (long)intpart;
            //modf((MonthlyPart * g_dblScaledRoundingFactor),&intpart);
            Trunc = intpart / g_dblScaledRoundingFactor;

            // determine the rounding variance
            Rounding_Variance = MonthlyPart - Trunc;

            // raw distribution amount is equal to the variance multiplied by the
            // number of months in the year
            Raw_Distr = (double)(Rounding_Variance * YearWeight);

            // real distribution amount is the raw distribution amount rounded to
            // the nearest 100th
            //Raw_Distr = Raw_Distr;

            // Calculate the distribution mark
            // The distribution mark lets us know when to take the rounding variance.  For example,
            // If the Distribution Mark = 4, then we must take an extra penny every
            // 4 months.

            // distribution mark is equal to the months in the year divided
            // by the real distribution amount
            if (Math.Abs(Raw_Distr) > 0)
                Distr_Mark = (double)(YearWeight / (Raw_Distr * g_dblScaledRoundingFactor));

            return Distr_Mark;
        }

        bool ComputeYTDCurrencyFraction(double Distr_Mark, decimal value, short numerator, short denominator, DateTime RHSDate, ref decimal outValue, ref decimal Remainder)
        {
            double dValue;
            double leftValue;

            if (outValue == null || Remainder == null)
                return false;

            dValue = (double)(value);
            if (dValue == 0)
            {
                outValue = value;
                Remainder = value;
                return true;
            }
            leftValue = ComputeDoubleYTDSplitWithMarks(Distr_Mark, dValue, numerator, denominator, RHSDate);
            outValue = (decimal)leftValue;
            Remainder = value;
            return true;
        }

        double ComputeDoubleYTDSplitWithMarks(double Distr_Mark, double value, short numerator, short denominator, DateTime RHSDate)
        {
            double Trunc;
            double Marks_Available = 0.0, Marks_Taken = 0.0;
            double MonthlyPart = 0.0;
            double intpart;
            IBAFiscalYear pObjFY;
            double g_dblScaledRoundingFactor = 100;

            if (m_iYearWeight == 0 || Distr_Mark == 0)
            {
                return (value * numerator / denominator);
            }

            Marks_Taken = (long)((numerator + m_iCountToLeft) / Distr_Mark + 0.501);

            // truncate monthly depreciation
            if (denominator < m_iYearWeight)
            {
                MonthlyPart = (value - Marks_Taken / g_dblScaledRoundingFactor) / (denominator + m_iCountToLeft);
            }
            else
                MonthlyPart = value / (denominator + m_iCountToLeft);

            intpart = MonthlyPart * g_dblScaledRoundingFactor;
            intpart = (long)intpart;
            //modf((MonthlyPart * g_dblScaledRoundingFactor),&intpart);
            Trunc = intpart / g_dblScaledRoundingFactor;

            return Trunc * (numerator + m_iCountToLeft) + Marks_Taken / g_dblScaledRoundingFactor;
        }

        bool ComputeCurrencyFraction(double Distr_Mark, decimal value, short numerator, short denominator, DateTime RHSDate, ref decimal outValue, ref decimal Remainder)
        {
            double dValue;
            double leftValue;

            if (outValue == null || Remainder == null)
                return false;

            dValue = (double)(value);
            if (dValue == 0)
            {
                outValue = value;
                Remainder = value;
                return true;
            }
            leftValue = ComputeDoubleSplitWithMarks(Distr_Mark, dValue, numerator, denominator, RHSDate);
            outValue = (decimal)leftValue;
            Remainder = (decimal)(dValue - leftValue);
            return true;
        }

        double ComputeDoubleSplitWithMarks(double Distr_Mark, double value, short numerator, short denominator, DateTime RHSDate)
        {
            double Trunc;
            double Marks_Available = 0.0, Marks_Taken = 0.0;
            double MonthlyPart = 0.0;
            double intpart;
            IBAFiscalYear pObjFY;
            double g_dblScaledRoundingFactor = 100;

            if (m_iYearWeight == 0 || Distr_Mark == 0)
            {
                return (value * numerator / denominator);
            }

            Marks_Taken = (long)((numerator + m_iCountToLeft) / Distr_Mark + 0.501) -
                           (long)((m_iCountToLeft) / Distr_Mark + 0.501);

            // truncate monthly depreciation
            if (denominator > 0)
            {
                if (denominator < m_iYearWeight)
                {
                    MonthlyPart = (value - Marks_Taken / g_dblScaledRoundingFactor) / denominator;
                }
                else
                    MonthlyPart = value / denominator;
            }
            else
            {
                MonthlyPart = value / m_iYearWeight;
            }

            intpart = MonthlyPart * g_dblScaledRoundingFactor;
            intpart = (long)intpart;
            //modf((MonthlyPart * g_dblScaledRoundingFactor),&intpart);
            Trunc = intpart / g_dblScaledRoundingFactor;

            return Trunc * numerator + Marks_Taken / g_dblScaledRoundingFactor;
        }

        bool ComputeDoubleFraction(double Distr_Mark, double value, short numerator, short denominator, DateTime RHSDate, ref double outValue, ref double Remainder)
        {
            double dValue;
            double leftValue;

            if (outValue == null || Remainder == null)
                return false;

            dValue = value;
            if (dValue == 0)
            {
                outValue = value;
                Remainder = value;
                return true;
            }
            leftValue = ComputeDoubleSplitWithMarks(Distr_Mark, dValue, numerator, denominator, RHSDate);
            outValue = leftValue;
            Remainder = dValue - leftValue;
            return true;
        }

        bool Compute3wayCurrencyFraction(double Distr_Mark, decimal value, short numerator, short middleNumerator, short denominator, DateTime middleDate, DateTime RHSDate, ref decimal leftValue, ref decimal middleValue, ref decimal rightValue)
        {
            double dValue;
            double leftVal = 0;
            double midVal = 0;
            double rightVal = 0;
            bool hr;

            if (leftValue == null || middleValue == null || rightValue == null)
                return false;

            dValue = (double)value;
            hr = Compute3waySplitWithMarks(Distr_Mark, dValue, numerator, middleNumerator, denominator, middleDate, RHSDate, ref leftVal, ref midVal, ref rightVal);
            leftValue = (decimal)leftVal;
            middleValue = (decimal)midVal;
            rightValue = (decimal)rightVal;
            return hr;
        }

        bool Compute3waySplitWithMarks(double Distr_Mark, double value, short numerator, short middleNumerator, short denominator, DateTime middleStart, DateTime RHSDate, ref double left, ref double middle, ref double right)
        {
            double Trunc;
            double Marks_Available = 0.0, Marks_Left = 0, Marks_Middle = 0, Marks_Taken = 0;
            double MonthlyPart = 0.0;
            double intpart;
            IBAFiscalYear pObjFY;
            double g_dblScaledRoundingFactor = 100;

            if (left == null || middle == null || right == null)
                return false;
            // KENT	if ( numerator == 0 || middleNumerator == 0 || numerator + middleNumerator >= denominator )
            // fix RM Gr-00191
            if (middleNumerator == 0 || numerator + middleNumerator >= denominator)
                return false;

            left = 0;
            middle = 0;
            right = 0;
            if (value == 0)
                return true;

            if (m_iYearWeight == 0 || Distr_Mark == 0)
            {
                left = (value * numerator / denominator);
                middle = (value * middleNumerator / denominator);
                right = value - (left) - (middle);
                return true;
            }

            Marks_Taken = (long)((numerator + m_iCountToLeft) / Distr_Mark + 0.501) -
                           (long)((m_iCountToLeft) / Distr_Mark + 0.501);

            // truncate monthly depreciation
            if (denominator > 0)
            {
                if (denominator < m_iYearWeight)
                {
                    MonthlyPart = (value - Marks_Taken / g_dblScaledRoundingFactor) / denominator;
                }
                else
                    MonthlyPart = value / denominator;
            }
            else
            {
                MonthlyPart = value / m_iYearWeight;
            }


            //	// truncate monthly depreciation
            //
            //	MonthlyPart = value / denominator;
            intpart = MonthlyPart * g_dblScaledRoundingFactor;
            intpart = (long)intpart;
            //modf((MonthlyPart * g_dblScaledRoundingFactor),&intpart);
            Trunc = intpart / g_dblScaledRoundingFactor;

            Marks_Left = (long)((numerator + m_iCountToLeft) / Distr_Mark + 0.501) -
                           (long)((m_iCountToLeft) / Distr_Mark + 0.501);

            Marks_Middle = (long)((numerator + middleNumerator + m_iCountToLeft) / Distr_Mark + 0.501) -
                           (long)((m_iCountToLeft + numerator) / Distr_Mark + 0.501);

            if (Marks_Left < 0.0)
                Marks_Left = 0.0;
            if (Marks_Middle < 0.0)
                Marks_Middle = 0.0;


            left = Trunc * numerator + Marks_Left / g_dblScaledRoundingFactor;
            middle = Trunc * middleNumerator + Marks_Middle / g_dblScaledRoundingFactor;
            right = value - (left) - (middle);
            return true;
        }

        bool Compute3wayYTDCurrencyFraction(double Distr_Mark, decimal value, short numerator, short middleNumerator, short denominator, DateTime middleDate, DateTime RHSDate, ref decimal leftValue, ref decimal middleValue, ref decimal rightValue)
        {
            double dValue;
            double leftVal = 0;
            double midVal = 0;
            double rightVal = 0;
            bool hr;

            if (leftValue == null || middleValue == null || rightValue == null)
                return false;

            dValue = (double)value;
            hr = Compute3wayYTDSplitWithMarks(Distr_Mark, dValue, numerator, middleNumerator, denominator, middleDate, RHSDate, ref leftVal, ref midVal, ref rightVal);
            leftValue = (decimal)leftVal;
            middleValue = (decimal)midVal;
            rightValue = (decimal)rightVal;
            return hr;
        }

        bool Compute3wayYTDSplitWithMarks(double Distr_Mark, double value, short numerator, short middleNumerator, short denominator, DateTime middleStart, DateTime RHSDate, ref double left, ref double middle, ref double right)
        {
            double Trunc;
            double Marks_Available = 0.0, Marks_Left = 0, Marks_Middle = 0, Marks_Taken = 0;
            double MonthlyPart = 0.0;
            double intpart;
            IBAFiscalYear pObjFY;
            double g_dblScaledRoundingFactor = 100;

            if (left == null || middle == null || right == null)
                return false;
            // KENT	if ( numerator == 0 || middleNumerator == 0 || numerator + middleNumerator >= denominator )
            // fix RM Gr-00191
            if (middleNumerator == 0 || numerator + middleNumerator >= denominator)
                return false;

            left = 0;
            middle = 0;
            right = 0;
            if (value == 0)
                return true;

            if (m_iYearWeight == 0 || Distr_Mark == 0)
            {
                left = (double)(value * numerator / denominator);
                middle = (double)(value * middleNumerator / denominator) + left;
                right = value;
                return true;
            }

            Marks_Taken = (long)((numerator + m_iCountToLeft) / Distr_Mark + 0.501);

            // truncate monthly depreciation
            if (denominator < m_iYearWeight)
            {
                MonthlyPart = (value - Marks_Taken / g_dblScaledRoundingFactor) / (denominator + m_iCountToLeft);
            }
            else
                MonthlyPart = value / (denominator + m_iCountToLeft);



            //	// truncate monthly depreciation
            //
            //	MonthlyPart = value / denominator;
            intpart = MonthlyPart * g_dblScaledRoundingFactor;
            intpart = (long)intpart;
            //modf((MonthlyPart * g_dblScaledRoundingFactor),&intpart);
            Trunc = intpart / g_dblScaledRoundingFactor;

            Marks_Left = (long)((numerator + m_iCountToLeft) / Distr_Mark + 0.501);

            Marks_Middle = (long)((numerator + middleNumerator + m_iCountToLeft) / Distr_Mark + 0.501);

            if (Marks_Left < 0.0)
                Marks_Left = 0.0;
            if (Marks_Middle < 0.0)
                Marks_Middle = 0.0;


            left = Trunc * (numerator + m_iCountToLeft) + Marks_Left / g_dblScaledRoundingFactor;
            middle = Trunc * (middleNumerator + numerator + m_iCountToLeft) + Marks_Middle / g_dblScaledRoundingFactor;
            right = value;
            return true;
        }

        bool Compute3wayDoubleFraction(double Distr_Mark, double value, short numerator, short middleNumerator, short denominator, DateTime middleDate, DateTime RHSDate, ref double leftValue, ref double middleValue, ref double rightValue)
        {
            bool hr = false;

            if (leftValue == null || middleValue == null || rightValue == null)
                return false;

            hr = Compute3waySplitWithMarks(Distr_Mark, value, numerator, middleNumerator, denominator, middleDate, RHSDate, ref leftValue, ref middleValue, ref rightValue);
            return hr;
        }
    }
}
