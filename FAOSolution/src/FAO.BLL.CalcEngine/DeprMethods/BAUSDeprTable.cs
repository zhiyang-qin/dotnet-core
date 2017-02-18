using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using FAO.BLL.CalcEngine.Interfaces;

namespace FAO.BLL.CalcEngine
{
    class BAUSDeprTable : IBADeprTable
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct US_TABLE_HEADER_STUFF
        {
            //[FieldOffset(0)]
            public short months;
            //[FieldOffset(2)]
            public short years;
            //[FieldOffset(4)]
            public int divisor;
            //[FieldOffset(8)]
            public int byteoffset;
            //[FieldOffset(12)]
            public short table_id;
        }

        public byte[] TableData;
        public US_TABLE_HEADER_STUFF TableHeader = new US_TABLE_HEADER_STUFF();

        public short YearCount
        {
            get
            {
                return TableHeader.years;
            }
        }

        public short PeriodCount
        {
            get
            {
                return TableHeader.months;
            }
        }

        public bool Percent(long year, long period, out double pct)
        {
            long offset;

            pct = 0;
	        if (TableData == null)
		        throw new Exception ("Depr Table not initialized.");
	
	        if ( year < 1 || year > TableHeader.years || period < 1 || period > TableHeader.months )
		        return false;

	        offset = TableHeader.years * (period - 1) + (year - 1);
	        offset = offset * sizeof(short);
            //Byte[] pctByte = new Byte[2];
            //Array.Copy(TableData, offset, pctByte, 0, 2);
            uint pctint = BitConverter.ToUInt16(TableData, (int)offset);
            pct = (double)(pctint) / TableHeader.divisor;
	        return true;
        }

        public bool LoadTable(byte[] tbl, short id)
        {
            short tableCount;
            short i;

            tableCount = tbl[0];
            int size = Marshal.SizeOf(TableHeader);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(tbl, 2, ptr, size);
            TableHeader = (US_TABLE_HEADER_STUFF)Marshal.PtrToStructure(ptr, typeof(US_TABLE_HEADER_STUFF));

            TableData = new byte[tbl.Length - TableHeader.byteoffset];
            for (i = 0; i < tableCount; i++)
            {
                if (TableHeader.table_id == id)
                {
                    Marshal.FreeHGlobal(ptr);
                    ptr = Marshal.AllocHGlobal(tbl.Length - TableHeader.byteoffset);
                    Marshal.Copy(tbl, TableHeader.byteoffset, ptr, tbl.Length - TableHeader.byteoffset);
                    TableData = new byte[tbl.Length - TableHeader.byteoffset];
                    Marshal.Copy(ptr, TableData, 0, tbl.Length - TableHeader.byteoffset);
                    Marshal.FreeHGlobal(ptr);
                    return true;
                }
                Marshal.Copy(tbl, 2 + size * (i + 1), ptr, size);
                TableHeader = (US_TABLE_HEADER_STUFF)Marshal.PtrToStructure(ptr, typeof(US_TABLE_HEADER_STUFF));
            }
            Marshal.FreeHGlobal(ptr);
            return false;
        }
    }
}
