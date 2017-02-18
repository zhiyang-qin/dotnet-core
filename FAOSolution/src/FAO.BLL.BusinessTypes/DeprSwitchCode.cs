using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class DeprSwitchCode : DeprSwitch
    {
        private bool _stable;

        public DeprSwitchCode(char name)
        {
            _stable = true;
            if (isValidName(name))
                Type = (translateShortNameToType(name));
            else
            {
                _stable = false;
                Type = (DeprSwitchType.UnknownSwitch);
            }
        }

        public DeprSwitchCode(string name)
        {
            _stable = true;

            if (name == null || name == string.Empty)
            {
                _stable = false;
                Type = (DeprSwitchType.UnknownSwitch);
            }
            else
            {
                if (isValidName(name[0]))
                    Type = (translateShortNameToType(name[0]));
                else
                {
                    _stable = false;
                    Type = (DeprSwitchType.UnknownSwitch);
                }
            }
        }

        public DeprSwitchCode(DeprSwitch obj)
            : base(obj)
        {
            _stable = true;
        }

        public DeprSwitchCode(DeprSwitchCode obj)
        {
            copyFrom(obj);
        }

        //public LRbpDeprSwitchCode  operator=(LRCbpDeprSwitchCode obj);

        //public bool                operator==(LRCbpDeprSwitchCode obj)
        //                          { return inherited::operator==(obj); }

        //public bool                operator!=(LRCbpDeprSwitchCode obj)
        //                          { return !operator==(obj); }
        #region Operator Overloading

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(DeprSwitchCode left, DeprSwitchCode right)
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
        public static bool operator !=(DeprSwitchCode left, DeprSwitchCode right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (DeprSwitchCode)o;
        }
        public override int GetHashCode()
        {
            return (int)Type;
        }

        #endregion

        public void copyFrom(DeprSwitchCode obj)
        {
            base.copyFrom(obj);
            _stable = obj._stable;
        }
        public char shortName()
        {
            return translateTypeToShortName(Type);
        }

        public string longName()
        {
            return translateTypeToLongName(Type);
        }

        public static DeprSwitchType translateType(char shortName)
        {
            return translateShortNameToType(shortName);
        }

        public static bool isValidName(char name)
        {
            if (translateShortNameToType(name) == DeprSwitchType.UnknownSwitch)
                return false;
            return true;
        }
        public override bool isObjectOk()
        {
            if (base.isObjectOk() == false)
                return false;
            return _stable;
        }

        private static DeprSwitchType translateShortNameToType(char shortName)
        {
            switch (shortName)
            {
                case 'M':
                    return DeprSwitchType.MidQuarterSwitch;
                case 'S':
                    return DeprSwitchType.SwitchWhenOptimal;
                case 'N':
                    return DeprSwitchType.DontSwitch;
                default:
                    return DeprSwitchType.UnknownSwitch;
            }
        }
        private static char translateTypeToShortName(DeprSwitchType newType)
        {
            switch (newType)
            {
                case DeprSwitchType.MidQuarterSwitch:
                    return 'M';
                case DeprSwitchType.SwitchWhenOptimal:
                    return 'S';
                case DeprSwitchType.DontSwitch:
                    return 'N';
                default:
                    return '\0';
            }
        }
        private static string translateTypeToLongName(DeprSwitchType newtype)
        {
            switch (newtype)
            {
                case DeprSwitchType.SwitchWhenOptimal:
                    return "Switch";
                case DeprSwitchType.DontSwitch:
                    return "No Switch";
                default:
                    return (string)null;
            }
        }

    }
}
