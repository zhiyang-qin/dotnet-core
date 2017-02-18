using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class AdjConventionCode : AdjConvention
    {
        private bool _stable;

        public AdjConventionCode(AdjConvention obj)
            : base(obj)
        {
            _stable = true;
        }

        public AdjConventionCode(AdjConventionCode obj)
        { copyFrom(obj); }

        public AdjConventionCode(char name)
        {
            _stable = true;
            if (isValidName(name))
                Type = (translateShortNameToType(name));
            else
                _stable = false;
        }

        #region Operator Overloading

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(AdjConventionCode left, AdjConventionCode right)
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
        public static bool operator !=(AdjConventionCode left, AdjConventionCode right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (AdjConventionCode)o;
        }
        public override int GetHashCode()
        {
            return (int)Type;
        }

        #endregion

        public void copyFrom(AdjConventionCode obj)
        {
            base.copyFrom( obj );
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

        public override bool isObjectOk()
        {
            if (base.isObjectOk() == false)
                return false;

            return _stable;
        }

        public static bool isValidName(char name)
        {
            switch (name)
            {
                case 'N':
                case 'I':
                case 'P':
                    return true;
            }

            return false;
        }

        protected AdjConvType translateShortNameToType(char shortName)
        {
            switch (shortName)
            {
                case 'N':
                    return AdjConvType.None;
                case 'I':
                    return AdjConvType.Immediate;
                case 'P':
                    return AdjConvType.Postrecovery;
            }

            return AdjConvType.Unknown;
        }
        protected char translateTypeToShortName(AdjConvType newType)
        {
            switch (newType)
            {
                case AdjConvType.None:
                    return 'N';
                case AdjConvType.Immediate:
                    return 'I';
                case AdjConvType.Postrecovery:
                    return 'P';
            }
            return '\0';
        }
        protected string translateTypeToLongName(AdjConvType newType)
        {
            switch (newType)
            {
                case AdjConvType.None:
                    return "None";
                case AdjConvType.Immediate:
                    return "Immediate";
                case AdjConvType.Postrecovery:
                    return "Postrecov.";
            }

            return null;
        }

    }
}
