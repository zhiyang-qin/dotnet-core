using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.BusinessTypes
{
    public class DeprMethod
    {
        public static int countOfMethods()
        {
            return (((int)DeprMethodTypeEnum.UnknownDeprMethod) - 1);
        }

        public static bool getNextMethod(out DeprMethodTypeEnum type_, ref int key_)
        {
            if (key_ < 0)
            {
                // a new enumeration
                key_ = 0;
            }

            // make sure there are still books left to enumerate
            if (key_ >= countOfMethods())
            {
                type_ = DeprMethodTypeEnum.UnknownDeprMethod;
                return false;
            }


            type_ = (DeprMethodTypeEnum)Enum.GetValues(typeof(DeprMethodTypeEnum)).GetValue(key_);

            key_++;

            return true;
        }


        private DeprMethodTypeEnum _type;
        private int _pct;

        public DeprMethod()
        {
            _pct = 0;
            Type = DeprMethodTypeEnum.StraightLine;
        }

        public DeprMethod(DeprMethodTypeEnum newType)
        {
            _pct = 0;
            Type = newType;
        }

        public DeprMethod(DeprMethod obj)
        {
            _pct = 0;
            copyFrom(obj);
        }

        public DeprMethodTypeEnum Type
        {
            get { return _type; }
            set
            {
                _type = value;

                if (_type != DeprMethodTypeEnum.DeclBal &&
                     _type != DeprMethodTypeEnum.DeclBalHalfYear &&
                     _type != DeprMethodTypeEnum.DeclBalModHalfYear &&
                     _type != DeprMethodTypeEnum.DeclBalSwitch &&
                     _type != DeprMethodTypeEnum.DeclBalHalfYearSwitch &&
                     _type != DeprMethodTypeEnum.DeclBalModHalfYearSwitch &&
                     _type != DeprMethodTypeEnum.MacrsFormula &&
                     _type != DeprMethodTypeEnum.MacrsFormula30 &&
                     _type != DeprMethodTypeEnum.MacrsTable &&
                     _type != DeprMethodTypeEnum.MACRSIndianReservation &&
                     _type != DeprMethodTypeEnum.MACRSIndianReservation30)
                    _pct = 0;

            }
        }

        public int Percentage
        {
            get { return _pct; }
            set
            {
                if (_type == DeprMethodTypeEnum.DeclBal ||
                     _type == DeprMethodTypeEnum.DeclBalHalfYear ||
                     _type == DeprMethodTypeEnum.DeclBalModHalfYear ||
                     _type == DeprMethodTypeEnum.DeclBalSwitch ||
                     _type == DeprMethodTypeEnum.DeclBalHalfYearSwitch ||
                     _type == DeprMethodTypeEnum.DeclBalModHalfYearSwitch ||
                     _type == DeprMethodTypeEnum.MacrsFormula ||
                     _type == DeprMethodTypeEnum.MacrsFormula30 ||
                     _type == DeprMethodTypeEnum.MacrsTable ||
                     _type == DeprMethodTypeEnum.MACRSIndianReservation ||
                     _type == DeprMethodTypeEnum.MACRSIndianReservation30)
                    _pct = value;

            }
        }

        /// <summary>
        /// Creates a DeprMethodTypeEnum value from DeprMethod object,
        /// </summary>
        /// <param name="DeprMethod">The DeprMethod object.</param>
        /// <returns>Returns DeprMethodTypeEnum</returns>
        public static implicit operator DeprMethodTypeEnum(DeprMethod DeprMethod)
        {
            return DeprMethod.Type;
        }

        /// <summary>
        /// Creates DeprMethod object from DeprMethodTypeEnum.
        /// </summary>
        /// <param name="DeprMethodTypeEnum"> DeprMethodTypeEnum </param>
        /// <returns>Returns new DeprMethod object.</returns>
        public static implicit operator DeprMethod(DeprMethodTypeEnum DeprMethodTypeEnum)
        {
            DeprMethod deprMethod = new DeprMethod(DeprMethodTypeEnum);
            return deprMethod;
        }

        public override bool Equals(object obj)
        {
            DeprMethod that = obj as DeprMethod;
            return this == that;
        }

        public override int GetHashCode()
        {
            return (int)0;
        }

        public static bool operator ==(DeprMethod left, DeprMethod right)
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

            if (left.Type != right.Type)
                return false;

            if (left.Percentage != right.Percentage)
                return false;

            return true;

        }

        public static bool operator !=(DeprMethod left, DeprMethod right)
        {
            return !(left == right);
        }


        public void copyFrom(DeprMethod obj)
        {
            Type = obj.Type;
            Percentage = obj.Percentage;

        }

        public virtual void defaults()
        {
            _type = DeprMethodTypeEnum.StraightLine;
        }

        public virtual bool isObjectOk()
        {
            return true;
        }

    }
}
