using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class DisposalConvention
    {
        public enum DispConvType
        {
            FullMonth = 1,
            Midmonth,
            HalfYearACRS,
            HalfYearMACRSPreACRS,
            ModifiedHalfYear,
            Unknown            // Not documented. Internal use only.
        };

        private DispConvType _type;

        public DisposalConvention()
        { 
            Type = (DispConvType.FullMonth); 
        }

        public DisposalConvention(DisposalConvention obj)
        { 
            copyFrom(obj); 
        }

        public DisposalConvention(DispConvType conv)
        { 
            Type = (conv); 
        }

        //public LRbpDisposalConvention operator=( LRCbpDisposalConvention obj );

        //public bool                operator==(LRCbpDisposalConvention obj)
        //                          { return (type()==obj.type()) ? true : false; }

        //public bool                operator!=(LRCbpDisposalConvention obj)
        //                          { return !operator==(obj); }
        #region Operator Overloading

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(DisposalConvention left, DisposalConvention right)
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
        public static bool operator !=(DisposalConvention left, DisposalConvention right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (DisposalConvention)o;
        }
        public override int GetHashCode()
        {
            return (int)Type;
        }

        #endregion

        public void copyFrom(DisposalConvention obj)
        { 
            Type = (obj.Type); 
        }

        public DispConvType Type
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

        public virtual void defaults()
        { 
            Type = (DispConvType.FullMonth); 
        }

        public virtual bool isObjectOk()
        { 
            return ((Type == DispConvType.Unknown) ? false : true); 
        }

    }
}
