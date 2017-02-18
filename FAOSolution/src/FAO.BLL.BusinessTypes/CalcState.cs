using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class CalcState
    {
        public enum CalcStateEnum
        {
            None = 0, NoMidQuarter, MidQuarterUsed,
            UnknownState // internal use only.
        };

        private CalcStateEnum _type;

        public CalcState()
        { 
            Type = (CalcStateEnum.None); 
        }

        public CalcState(BusinessTypes.CalcState obj)
        { 
            copyFrom(obj); 
        }

        public CalcState(CalcStateEnum aValue)
        { 
            Type = (aValue); 
        }

        #region Operator Overloading

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(BusinessTypes.CalcState left, BusinessTypes.CalcState right)
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

            return left.Type == right.Type;
        }

        /// <summary>
        /// OverLoading != operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are not the same</returns>
        public static bool operator !=(BusinessTypes.CalcState left, BusinessTypes.CalcState right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (BusinessTypes.CalcState)o;
        }
        public override int GetHashCode()
        {
            return (int)Type;
        }

        #endregion


        public CalcStateEnum Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }


        public void copyFrom(BusinessTypes.CalcState obj)
        { 
            Type = (obj.Type); 
        }

        public virtual bool isObjectOk()
        { 
            return true; 
        }

        public virtual void defaults()
        { 
            Type = (CalcStateEnum.None); 
        }

    }
}
