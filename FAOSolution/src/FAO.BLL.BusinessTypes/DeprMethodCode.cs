using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FAO.BLL.BusinessTypes
{
    public class DeprMethodCode : DeprMethod
    {
        struct DMTHCODE
        {
            public DeprMethodTypeEnum type;
            public string code;
            public string name;
        };

        static DMTHCODE[] codes = new DMTHCODE[]{
                            new DMTHCODE(){ type = DeprMethodTypeEnum.MacrsFormula, code = "MF", name = "MACRS formula"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.MacrsTable, code = "MT", name = "MACRS table"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.AdsSlMacrs, code = "AD", name = "ADS str-line MACRS"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.AcrsTable, code = "AT", name = "ACRS table"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.StraightLineAltAcrsFormula, code = "SA", name = "Str-line alt ACRS"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.StraightLineAltAcrsTable, code = "ST", name = "Str-line alt ACRS table"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.StraightLineModHalfYear, code = "SD", name = "Str-line mod. half yr"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.StraightLine, code = "SL", name = "Straight line"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.StraightLineFullMonth, code = "SF", name = "Str-line full mth"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.StraightLineHalfYear, code = "SH", name = "Str-line half yr"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.DeclBalSwitch, code = "DB", name = "D-Balance (swt)"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.DeclBalModHalfYearSwitch, code = "DD", name = "D-bal mod/h-yr (swt)"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.DeclBalHalfYearSwitch, code = "DH", name = "D-bal h-yr (swt)"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.DeclBal, code = "DC", name = "D-Balance (no swt)"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.DeclBalModHalfYear, code = "DE", name = "D-bal mod/h-yr (no swt)"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.DeclBalHalfYear, code = "DI", name = "D-bal h-yr (no swt)"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.SumOfTheYearsDigitsHalfYear, code = "YH", name = "Sum yrs digits half yr"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.SumOfTheYearsDigitsModHalfYear, code = "YD", name = "Sum yr digit mod h yr"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.SumOfTheYearsDigits, code = "YS", name = "Sum of years digits"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.RemValueOverRemLife, code = "RV", name = "Rem value/rem life"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.OwnDepreciationCalculation, code = "OC", name = "Own depreciation calc"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.DoNotDepreciate, code = "NO", name = "Do not depreciate"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.CustomMethod, code = "cc", name = ""},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.MACRSIndianReservation, code = "MI", name = "MACRS Indian Reservation"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.MacrsFormula30, code = "MA", name = "MACRS formula +168"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.AdsSlMacrs30, code = "AA", name = "ADS str-line MACRS+168"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.MACRSIndianReservation30, code = "MR", name = "MACRS Indian Rsrv +168"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.StraightLineFullMonth30, code = "SB", name = "Str-line full mth +168"},
 // Canadian BEGIN !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
							new DMTHCODE(){ type = DeprMethodTypeEnum.CdnDeclBal, code = "DM", name = "Decl Bal mid mth"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.CdnDeclBalFullMonth, code = "DL", name = "Decl Bal full mth"},
                            new DMTHCODE(){ type = DeprMethodTypeEnum.CdnDeclBalHalfYear, code = "DY", name = "Decl Bal half yr"},
// Canadian END ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
							new DMTHCODE(){ type = DeprMethodTypeEnum.UnknownDeprMethod, code = null}
                          };



        public static bool isValidShortName(string name)
        {
            if (translateShortNameToType(name) == DeprMethodTypeEnum.UnknownDeprMethod)
                return false;
            else
                return true;
        }

        public static bool isValidPredefinedShortName(string name)
        {
            if (name == null || name.Length == 0)
                return false;

            DeprMethodTypeEnum c = translateShortNameToType(name);
            if (c == DeprMethodTypeEnum.UnknownDeprMethod || c == DeprMethodTypeEnum.CustomMethod)
                return false;

            return true;
        }


        public static DeprMethodTypeEnum translateShortNameToType(string shortName)
        {
            if (shortName == null || shortName.Length == 0)
                return DeprMethodTypeEnum.DoNotDepreciate;

            foreach (DMTHCODE code in codes)
            {
                if (code.type != DeprMethodTypeEnum.CustomMethod && string.Compare(code.code, shortName, true) == 0)
                    return code.type;
            }

            return DeprMethodTypeEnum.CustomMethod;
        }


        public static string translateTypeToShortName(DeprMethodTypeEnum newType)
        {
            foreach (DMTHCODE code in codes)
            {
                if (code.type == newType)
                    return code.code;
            }

            return null;
        }

        protected static string translateTypeToLongName(DeprMethodTypeEnum type)
        {
            foreach (DMTHCODE code in codes)
            {
                if (code.type == type)
                    return code.name;
            }
            return null;
        }

        public static DeprMethodCode translateDeprNameToCode(string deprName)
        {
            if (!String.IsNullOrEmpty(deprName))
            {
                string meth = string.Empty;
                int nPct = 0;

                if (deprName.Length > 2)
                {
                    Regex AlphaNumericPattern = new Regex(("[^0-9]"));
                    if (!AlphaNumericPattern.IsMatch(deprName.Substring(2)))
                    {
                        nPct = Convert.ToInt32(deprName.Substring(2));
                    }

                    meth = deprName.Substring(0, 2);
                }
                else
                {
                    meth = deprName;
                }

                return new DeprMethodCode(meth) { Percentage = nPct };
            }

            return null;
        }

        private bool _stable;


        public DeprMethodCode()
        {
            _stable = true;
            defaults();
        }

        public DeprMethodCode(string shortName)
        {
            _stable = true;
            if (isValidShortName(shortName))
            {
                Type = (translateShortNameToType(shortName));
            }
            else
                _stable = false;
        }

        public DeprMethodCode(DeprMethod obj)
            : base(obj)
        {
            _stable = true;
        }

        public DeprMethodCode(DeprMethodCode obj)
        {
            copyFrom(obj);
        }

        #region Operator Overloading

        /// <summary>
        /// OverLoading < operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if left value is less than the right value</returns>
        public static bool operator <(DeprMethodCode left, DeprMethodCode right)
        {
            return left.Type < right.Type;
        }

        /// <summary>
        /// OverLoading > operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if left value is less than the right value</returns>
        public static bool operator >(DeprMethodCode left, DeprMethodCode right)
        {
            return !(left < right);
        }

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(DeprMethodCode left, DeprMethodCode right)
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
        public static bool operator !=(DeprMethodCode left, DeprMethodCode right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (DeprMethodCode)o;
        }
        public override int GetHashCode()
        {
            return (int)Type;
        }

        #endregion

        public void copyFrom(DeprMethodCode obj)
        {
            //inherited::copyFrom( obj ); 
            _stable = obj._stable;
        }
        public string shortName()
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


    }
}
