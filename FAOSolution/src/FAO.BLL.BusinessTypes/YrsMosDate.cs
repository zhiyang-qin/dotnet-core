using FAO.BLL.BusinessTypes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.BusinessTypes
{
    public class YrsMosDate
    {
        #region Static Methods

        public static YrsMosDate StringToYrsMosDate(string str)
        {
            string value = String.Empty;
            if (String.IsNullOrEmpty(str))
            {
                return null;
            }

            string[] stNum;
            string[] seperator = { "yrs", "mos" };
            if (!str.Contains("yrs"))
                return null;
            stNum = str.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < stNum.Length; i++)
            {
                stNum[i] = stNum[i].Trim();
                if (stNum[i].Length == 1)
                    stNum[i] = "0" + stNum[i];
                value += stNum[i];
            }

            if (StringExt.IsNumeric(value))
            {
                YrsMosDate estLife = new YrsMosDate().SetYrsMosDate(value);
                return estLife;
            }
            return null;

        }

        #endregion Static Methods


        #region Member Variables
        private uint m_years;
        private uint m_months;
        #endregion

        #region Properties
        public uint Years
        {
            get
            {
                return m_years;
            }
            set
            {
                m_years = value;
            }
        }
        public uint Months
        {
            get
            {
                return m_months;
            }
            set
            {
                m_months = value;
            }
        }
        #endregion

        public YrsMosDate SetYrsMosDate(string yrsMosDate)
        {
            // Force an invalid date setting to start out with.
            Years = 1000;
            Months = 1000;

            if (yrsMosDate == null)
            {
                defaults();
                return this;
            }

            if (yrsMosDate.Length == 0)
            {
                defaults();
                return this;
            }

            // if date is 2 chars or less, assume a yy format.
            if (yrsMosDate.Length <= 2)
            {
                Years = Convert.ToUInt32(yrsMosDate);
                Months = 0;
            }
            else
                // If date is exactly 3 characters in length, assume a yym format.
                if (yrsMosDate.Length == 3)
            {
                string yrs = yrsMosDate.Substring(0, 2);
                Years = Convert.ToUInt32(yrs);
                string mos = yrsMosDate.Substring(2, 1);
                Months = Convert.ToUInt32(mos);
            }
            else
                    // If date is exactly 4 characters in length, assume a yymm format.
                    if (yrsMosDate.Length == 4)
            {
                string yrs = yrsMosDate.Substring(0, 2);
                uint totMonths = 0;
                totMonths = Convert.ToUInt32(yrs) * 12;
                string mos = yrsMosDate.Substring(2, 2);
                totMonths += Convert.ToUInt32(mos);
                setFromMonths(totMonths);
            }
            return this;
        }

        #region Public Functions
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="yrsMosDate">String of format yy or yym or yymm</param>
        public YrsMosDate(string yrsMosDate)
        {
            // Force an invalid date setting to start out with.
            Years = 1000;
            Months = 1000;

            if (yrsMosDate == null)
            {
                defaults();
                return;
            }

            if (yrsMosDate.Length == 0)
            {
                defaults();
                return;
            }

            string tmp = yrsMosDate;
            if (tmp.Length < 4)
            {
                tmp = tmp.PadLeft(4, '0');
            }
            tmp = tmp.Substring(0, 2);
            try
            {
                Years = Convert.ToUInt32(tmp);
            }
            catch
            {
                Years = 0;
            }
            tmp = yrsMosDate;
            if (tmp.Length < 4)
            {
                tmp = tmp.PadLeft(4, '0');
            }

            tmp = tmp.Substring(2, 2);
            try
            {
                Months = Convert.ToUInt32(tmp);
            }
            catch
            {
                Months = 0;
            }
            if (Months > 11)
            {
                Years += Months / 12;
                Months = Months % 12;
            }
        }
        /// <summary>
        /// Constructor sets value to 0 years 0 months
        /// </summary>
        public YrsMosDate()
        {
            defaults();//set to 0/0
        }
        /// <summary>
        /// Constructor sets value to yrs and mos
        /// </summary>
        /// <param name="yrs">number of years</param>
        /// <param name="mos">number of months</param>
        public YrsMosDate(uint yrs, uint mos)
        {
            Years = yrs;
            Months = mos;
            if (Months > 11)
            {
                Years += Months / 12;
                Months = Months % 12;
            }
        }

        public YrsMosDate(YrsMosDate dateObject)
        {

            this.Years = dateObject.Years;
            this.Months = dateObject.Months;


        }
        /// <summary>
        /// equality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(YrsMosDate left, YrsMosDate right)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            return (left.getAsMonths() == right.getAsMonths());
        }
        /// <summary>
        /// inequality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(YrsMosDate left, YrsMosDate right)
        {
            return !(left == right);
        }
        /// <summary>
        /// less than operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(YrsMosDate left, YrsMosDate right)
        {
            return (left.getAsMonths() < right.getAsMonths());
        }
        /// <summary>
        /// greater than or equal operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(YrsMosDate left, YrsMosDate right)
        {
            return !(left < right);
        }
        /// <summary>
        /// greater than operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(YrsMosDate left, YrsMosDate right)
        {
            return (left.getAsMonths() > right.getAsMonths());
        }
        /// <summary>
        /// less than or equal operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(YrsMosDate left, YrsMosDate right)
        {
            return !(left > right);
        }
        /// <summary>
        /// Copies values from another bpYrsMosDate object
        /// </summary>
        /// <param name="right"></param>
        public void copyFrom(YrsMosDate right)
        {
            Years = right.Years;
            Months = right.Months;
        }
        /// <summary>
        /// Sets the object's value from a number of months
        /// </summary>
        /// <param name="newMonths"></param>
        public void setFromMonths(uint newMonths)
        {
            if (newMonths <= 11)
            {
                Months = newMonths;
                Years = 0;
            }
            else
            {
                Years = newMonths / 12;
                Months = newMonths % 12;
            }
        }
        /// <summary>
        /// returns the object's value as a number of months
        /// </summary>
        /// <returns></returns>
        public uint getAsMonths()
        {
            return (Years * 12) + Months;
        }
        /// <summary>
        /// Sets the object's value to 0 yrs 0 months
        /// </summary>
        public void defaults()
        {
            Years = 0;
            Months = 0;
        }
        /// <summary>
        /// Checks if the object has a valid value (<100 years)
        /// </summary>
        /// <returns></returns>
        public bool isValid()
        {
            if (Years <= 99 && Months <= 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if the object has a valid value
        /// </summary>
        /// <returns></returns>
        public bool isObjectOk()
        {
            return isValid();
        }
        #endregion

    }
}
