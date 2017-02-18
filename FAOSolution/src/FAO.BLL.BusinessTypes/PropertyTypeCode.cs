using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.BusinessTypes
{
    public class PropertyTypeCode : PropertyType
    {
        #region Nested Struct

        struct PROPCODE
        {
            public PropertyType type;
            public string code;
            public string name;
        }

        #endregion


        #region Static Variables

        static PROPCODE[] codes = new PROPCODE[] {
                            new PROPCODE(){ type = PropertyTypeEnum.PersonalGeneral, code = "P", name = "Personal, General"},
                            new PROPCODE(){ type = PropertyTypeEnum.Automobile, code = "A", name = "Automobile"},
                            new PROPCODE(){ type = PropertyTypeEnum.LtTrucksAndVans, code = "T", name = "Lt Trucks and Vans"},
                            new PROPCODE(){ type = PropertyTypeEnum.PersonalListed, code = "Q", name = "Personal, listed"},
                            new PROPCODE(){ type = PropertyTypeEnum.RealGeneral, code = "R", name = "Real, General"},
                            new PROPCODE(){ type = PropertyTypeEnum.RealListed, code = "S", name = "Real, Listed"},
                            new PROPCODE(){ type = PropertyTypeEnum.RealConservation, code = "C", name = "Real, Conservation"},
                            new PROPCODE(){ type = PropertyTypeEnum.RealEnergy, code = "E", name = "Real, Energy"},
                            new PROPCODE(){ type = PropertyTypeEnum.RealFarms, code = "F", name = "Real, Farms"},
                            new PROPCODE(){ type = PropertyTypeEnum.RealLowIncomeHousing, code = "H", name = "Real, Low-income housing"},
                            new PROPCODE(){ type = PropertyTypeEnum.Amortizable, code = "Z", name = "Amortizable"},
                            new PROPCODE(){ type = PropertyTypeEnum.VintageAccount, code = "V", name = "Vintage"},
                            new PROPCODE(){ type = PropertyTypeEnum.Depreciable, code = "D", name = "Depreciable"},
                            new PROPCODE(){ type = PropertyTypeEnum.NonDepreciable, code = "N", name = "Non-Depreciable"},
                            new PROPCODE(){ type = PropertyTypeEnum.Unknown, code = "\0", name = null}
                            };

        static PROPCODE[] gasbcodes = new PROPCODE[] {
                            new PROPCODE(){ type = PropertyTypeEnum.Depreciable, code = "D", name = "Depreciable"},
                            new PROPCODE(){ type = PropertyTypeEnum.NonDepreciable, code = "N", name = "Non-Depreciable"},
                            new PROPCODE(){ type = PropertyTypeEnum.Unknown, code = "\0", name = null}
                            };

        #endregion


        #region Public Static Methods

        public static bool isValidShortName(string name)
        {
            if (translateShortNameToType(name) == PropertyTypeEnum.Unknown)
                return false;
            else
                return true;
        }

        public static bool isValidLongName(string name)
        {
            if (translateLongNameToType(name) == PropertyTypeEnum.Unknown)
                return false;
            else
                return true;
        }

        public static PropertyType translateShortNameToType(string shortName)
        {
            bool isGASB = false;

            if (isGASB)
            {
                foreach (PROPCODE code in gasbcodes)
                {
                    if (code.code == shortName)
                        return code.type;
                }
            }
            else
            {
                foreach (PROPCODE code in codes)
                {
                    if (string.Compare(code.code, shortName, true) == 0)
                        return code.type;
                }
            }

            return PropertyTypeEnum.Unknown;
        }

        #endregion


        #region Protected Static Methods

        protected static PropertyType translateLongNameToType(string longName)
        {
            foreach (PROPCODE code in codes)
            {
                if (code.name == longName)
                    return code.type;
            }

            return PropertyTypeEnum.Unknown;
        }

        protected static string translateTypeToShortName(PropertyTypeEnum type)
        {
            foreach (PROPCODE code in codes)
            {
                if (code.type == type)
                    return code.code;
            }
            return "\0";
        }

        protected static string translateTypeToLongName(PropertyTypeEnum type)
        {
            foreach (PROPCODE code in codes)
            {
                if (code.type == type)
                    return code.name;
            }
            return null;
        }

        #endregion



        #region Private Variables

        private bool _stable;

        #endregion


        #region Constructors

        public PropertyTypeCode()
        {
            _stable = true;
            defaults();
        }

        public PropertyTypeCode(PropertyType obj)
            : base(obj)
        {
            _stable = true;
        }

        public PropertyTypeCode(PropertyTypeCode obj)
        {
            copyFrom(obj);
        }

        public PropertyTypeCode(string name)
        {
            _stable = true;
            if (isValidShortName(name))
                Type = (translateShortNameToType(name));
            else
                _stable = false;
        }

        #endregion

        #region Operator Overload

        public override bool Equals(object o)
        {
            return this == (PropertyTypeCode)o;
        }

        public override int GetHashCode()
        {
            return (int)Type;
        }

        public static bool operator ==(PropertyTypeCode left, PropertyTypeCode right)
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

            return (PropertyType)left == (PropertyType)right;
        }

        public static bool operator !=(PropertyTypeCode left, PropertyTypeCode right)
        {
            return !((PropertyType)left == (PropertyType)right);
        }

        public static bool operator <(PropertyTypeCode left, PropertyTypeCode right)
        {
            return left.Type < right.Type;
        }

        public static bool operator >(PropertyTypeCode left, PropertyTypeCode right)
        {
            return !(left < right);
        }

        #endregion

        #region Public Methods

        public void copyFrom(PropertyTypeCode obj)
        {
            base.copyFrom(obj);
            _stable = obj._stable; ;
        }

        public string shortName()
        {
            return translateTypeToShortName(Type);
        }

        public string longName()
        {
            return translateTypeToLongName(Type);
        }

        public virtual bool isObjectOk()
        {
            if (base.isObjectOk() == false)
                return false;

            return _stable;
        }

        #endregion
    }
}
