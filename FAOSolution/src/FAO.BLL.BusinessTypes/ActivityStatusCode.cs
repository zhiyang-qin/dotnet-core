using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class ActivityStatusCode : ActivityStatus
    {
        private bool _stable;

        public ActivityStatusCode(char shortName)
        {
            defaults();
            if (isValidName(shortName) == false)
                _stable = false;
            else
                Value = (translateShortNameToType(shortName));
        }

        public ActivityStatusCode(ActivityStatusCode obj)
        { 
            copyFrom(obj); 
        }

        public ActivityStatusCode(ActivityStatus obj)
            : base(obj)
        { 
            _stable = true; 
        }

        #region Operator Overloading

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(ActivityStatusCode left, ActivityStatusCode right)
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

            return left.Value == right.Value;
        }

        /// <summary>
        /// OverLoading != operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are not the same</returns>
        public static bool operator !=(ActivityStatusCode left, ActivityStatusCode right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (ActivityStatusCode)o;
        }
        public override int GetHashCode()
        {
            return (int)Value;
        }

        #endregion


        public void copyFrom(ActivityStatusCode obj)
        {
            base.copyFrom( obj );
            _stable = obj._stable;
        }

        public char shortName()
        { 
            return translateTypeToShortName(Value); 
        }

        public string longName()
        { 
            return translateTypeToLongName(Value); 
        }

        public override bool isObjectOk()
        {
            if (base.isObjectOk() == false)
                return false;
            return _stable;
        }


        private string translateTypeToLongName(ActivityType type)
        {
            switch (type)
            {
                case ActivityType.Inactive:
                    return "Inactive";
                case ActivityType.Disposed:
                    return "Disposed";
                case ActivityType.WholeTransferDisposed:
                    return "Whole Transfer Disposed";
                case ActivityType.PartiallyDisposed:
                    return "Partially Disposed";
                case ActivityType.WholeTransfer:
                    return "Whole Transfer";
                case ActivityType.PartialTransferWithinCmp:
                    return "Partial Transfer within Company";
                case ActivityType.PartialTransferOutsideCmp:
                    return "Partial Transfer outside Company";
                case ActivityType.PartialTransferDisposed:
                    return "Partial Transfer Disposed";
                case ActivityType.ADIImport:
                    return "ADI Import";
                case ActivityType.Active:
                default:
                    return "Active";
            }
        }
    }
}
