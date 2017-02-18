using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class DeprSwitch
    {
        public enum DeprSwitchType
        {
            SwitchWhenOptimal = 1,
            DontSwitch,
            UnknownSwitch, // internal use only.
            MidQuarterSwitch
        };

        private DeprSwitchType _switch;


        public DeprSwitch()
        { Type = DeprSwitchType.DontSwitch; }

        public DeprSwitch(DeprSwitchType newvalue)
        {
            Type = (newvalue);
        }

        public DeprSwitch(DeprSwitch obj)
        { copyFrom(obj); }

        //public LRbpDeprSwitch      operator=(LRCbpDeprSwitch obj);

        //public bool                operator==(LRCbpDeprSwitch obj)
        //                          { return (type() == obj.type()); }

        //public bool                operator!=(LRCbpDeprSwitch obj)
        //                          { return !operator==(obj); }
        #region Operator Overloading

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(DeprSwitch left, DeprSwitch right)
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
        public static bool operator !=(DeprSwitch left, DeprSwitch right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (DeprSwitch)o;
        }
        public override int GetHashCode()
        {
            return (int)Type;
        }

        #endregion

        public void copyFrom(DeprSwitch obj)
        {
            Type = (obj.Type);
        }

        public DeprSwitchType Type
        {
            get
            {
                return _switch;
            }
            set
            {
                _switch = value;
            }
        }


        public virtual void defaults()
        {
            Type = (DeprSwitchType.DontSwitch);
        }

        public virtual bool isObjectOk()
        {
            return true;
        }

    }
}
