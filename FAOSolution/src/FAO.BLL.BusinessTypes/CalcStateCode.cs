using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class CalcStateCode : CalcState
    {
        private bool _stable;

        public CalcStateCode(char shortName)
        {
            defaults();
            if (isValidName(shortName) == false)
            {
                _stable = false;
                Type = (CalcStateEnum.UnknownState);
            }
            else
                Type = (translateShortNameToType(shortName));
        }

        public CalcStateCode(string shortName)
        {
            defaults();

            if (shortName == null || shortName == string.Empty)
            {
                _stable = false;
                Type = (CalcStateEnum.UnknownState);
            }
            else
            {
                if (isValidName(shortName[0]) == false)
                {
                    _stable = false;
                    Type = (CalcStateEnum.UnknownState);
                }
                else
                    Type = (translateShortNameToType(shortName[0]));

            }
        }


        public CalcStateCode(CalcStateCode obj)
        {
            copyFrom(obj);
        }

        public CalcStateCode(BusinessTypes.CalcState obj)
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
        public static bool operator ==(CalcStateCode left, CalcStateCode right)
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
        public static bool operator !=(CalcStateCode left, CalcStateCode right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (CalcStateCode)o;
        }
        public override int GetHashCode()
        {
            return (int)Type;
        }

        #endregion

        public void copyFrom(CalcStateCode obj)
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

        public static CalcStateEnum translateType(char shortName)
        {
            return translateShortNameToType(shortName);
        }


        public virtual bool isObjectOk()
        {
            if (base.isObjectOk() == false)
                return false;
            return _stable;
        }
        public static bool isValidName(char name)
        {
            if (translateShortNameToType(name) == CalcStateEnum.UnknownState)
                return false;
            return true;
        }

        private static CalcStateEnum translateShortNameToType(char shortName)
        {
            switch (shortName)
            {
                case ' ':
                case '\0':
                case 'A':
                    return CalcStateEnum.None;
                case 'B':
                    return CalcStateEnum.NoMidQuarter;
                case 'C':
                    return CalcStateEnum.MidQuarterUsed;
                default:
                    return CalcStateEnum.UnknownState;
            }
        }

        private static char translateTypeToShortName(CalcStateEnum type)
        {
            switch (type)
            {
                case CalcStateEnum.None:
                    return 'A';
                case CalcStateEnum.NoMidQuarter:
                    return 'B';
                case CalcStateEnum.MidQuarterUsed:
                    return 'C';
                default:
                    return '\0';
            }
        }

        private static string translateTypeToLongName(CalcStateEnum type)
        {
            switch (type)
            {
                case CalcStateEnum.None:
                    return "None";
                case CalcStateEnum.MidQuarterUsed:
                    return "MidQuarter";
                case CalcStateEnum.NoMidQuarter:
                    return "No MidQuarter";
                default:
                    return null;
            }
        }


    }
}
