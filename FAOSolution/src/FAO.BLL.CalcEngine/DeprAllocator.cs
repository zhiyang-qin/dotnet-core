using FAO.BLL.CalcEngine.Interfaces;
using FAO.BLL.Calendar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.BLL.CalcEngine
{
    public class DeprAllocator
    {
        IBACalendar m_pObjCalendar;
        List<IBAPeriodDeprItem> m_pObjList;
        DateTime m_dtPISDate;
        DateTime m_dtDeemedEndDate;
        DateTime m_dtDisposalDate;

        public DateTime PlacedInService
        {
            get { return m_dtPISDate; }
            set { m_dtPISDate = value; }
        }

        public DateTime DeemedEndDate
        {
            get { return m_dtDeemedEndDate; }
            set { m_dtDeemedEndDate = value; }
        }

        public DateTime DisposalDate
        {
            get { return m_dtDisposalDate; }
            set { m_dtDisposalDate = value; }
        }

        public IBACalendar Calendar
        {
            set { m_pObjCalendar = value; }
        }

        public List<IBAPeriodDeprItem> PeriodDeprItemList
        {
            get { return m_pObjList; }
            set { m_pObjList = value; }
        }

        public bool SplitPDItem(IBAPeriodDeprItem source, DateTime rightDate, out IBAPeriodDeprItem left, out IBAPeriodDeprItem right)
        {
            left = new PeriodDeprItem();
            right = new PeriodDeprItem();
	        if ( source == null )
		        return false;
            return source.Split2ways(rightDate, m_pObjCalendar, m_dtPISDate, m_dtDeemedEndDate, ref left, ref right);
            //return true;
        }

        public bool SplitPDItem3ways(IBAPeriodDeprItem source, DateTime middleStart, DateTime rightStart, out IBAPeriodDeprItem left, out IBAPeriodDeprItem middle, out IBAPeriodDeprItem right)
        {
            left = new PeriodDeprItem();
            right = new PeriodDeprItem();
            middle = new PeriodDeprItem();

            if (source == null)
		        return false;
            return source.Split3ways(middleStart, rightStart, m_pObjCalendar, m_dtPISDate, m_dtDeemedEndDate, ref left, ref middle, ref right);
            //return true;
        }
    }
}
