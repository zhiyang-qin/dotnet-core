using FAO.BLL.BusinessTypes;
using FAO.BLL.Rulebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.Domain.Rule
{
    public class DeprPctRule
    {
        public enum RuleResult
        {
            Valid = 1,
            Invalid,
            RuleBaseFailure
        };


        public List<DeprPct> BuildValidList(PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum deprMethod)
        {
            List<DeprPct> deprPctList = new List<DeprPct>();
            IbpRuleBase rb = new bpRuleBase();
            List<int> ei = new List<int>();

            rb.BuildDeprPercentList((short)(propType), (pisDate), (short)deprMethod, out ei);

            if (ei == null || ei.Count == 0)
                return null;

            for (int posi = 0; posi < ei.Count; posi++)
            {
                deprPctList.Add(new DeprPct(ei[posi]));
            }

            return deprPctList;
        }

        public RuleResult IsValid(BookTypeEnum book, PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum deprMethod, int percentage)
        {
            ErrorCode errorCode;
            bool isShortYr = false;
            IbpRuleBase rb = new bpRuleBase();

            switch (deprMethod)
            {
                case DeprMethodTypeEnum.MacrsFormula:
                case DeprMethodTypeEnum.MacrsTable:
                case DeprMethodTypeEnum.MACRSIndianReservation:
                case DeprMethodTypeEnum.DeclBal:
                case DeprMethodTypeEnum.DeclBalHalfYear:
                case DeprMethodTypeEnum.DeclBalModHalfYear:
                case DeprMethodTypeEnum.DeclBalSwitch:
                case DeprMethodTypeEnum.DeclBalHalfYearSwitch:
                case DeprMethodTypeEnum.DeclBalModHalfYearSwitch:
                case DeprMethodTypeEnum.MacrsFormula30:
                case DeprMethodTypeEnum.MACRSIndianReservation30:
                    // Build list of percentages.
                    List<DeprPct> aList = BuildValidList(propType, pisDate, deprMethod);
                    if (aList != null)
                    {
                        // iterate across all percentages, looking for the one
                        // that matches the one we have.  If found, then valid.
                        // if no matches, then invalid.
                        foreach (DeprPct item in aList)
                        {
                            if (item.Percentage == percentage)
                                return RuleResult.Valid;
                        }
                    }
                    break;

                // Canadian BEGIN !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                // The percentage must be in the range [1, 100].
                case DeprMethodTypeEnum.CdnDeclBal:
                case DeprMethodTypeEnum.CdnDeclBalHalfYear:
                case DeprMethodTypeEnum.CdnDeclBalFullMonth:
                    if ((1 <= percentage) && (percentage <= 100))
                    {
                        return RuleResult.Valid;
                    }
                    break;
                // Canadian END ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            }
            return RuleResult.Invalid;
        }

        public static RuleResult IsApplicable(DeprMethodTypeEnum deprMethod)
        {
            switch (deprMethod)
            {
                case DeprMethodTypeEnum.MacrsFormula:
                case DeprMethodTypeEnum.MacrsTable:
                case DeprMethodTypeEnum.MACRSIndianReservation:
                case DeprMethodTypeEnum.DeclBal:
                case DeprMethodTypeEnum.DeclBalHalfYear:
                case DeprMethodTypeEnum.DeclBalModHalfYear:
                case DeprMethodTypeEnum.DeclBalSwitch:
                case DeprMethodTypeEnum.DeclBalHalfYearSwitch:
                case DeprMethodTypeEnum.DeclBalModHalfYearSwitch:
                case DeprMethodTypeEnum.MacrsFormula30:
                case DeprMethodTypeEnum.MACRSIndianReservation30:
                // Canadian BEGIN !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                case DeprMethodTypeEnum.CdnDeclBal:
                case DeprMethodTypeEnum.CdnDeclBalHalfYear:
                case DeprMethodTypeEnum.CdnDeclBalFullMonth:
                // Canadian END ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    return RuleResult.Valid;
            }

            return RuleResult.Invalid;
        }

        public int GetDefaultDeprPct(PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum deprMethod)
        {
            int percentage = 0;

            switch (deprMethod)
            {
                case DeprMethodTypeEnum.MacrsFormula:
                case DeprMethodTypeEnum.MacrsTable:
                case DeprMethodTypeEnum.MACRSIndianReservation:
                    switch (propType)
                    {
                        case PropertyTypeEnum.RealGeneral:
                        case PropertyTypeEnum.RealListed:
                        case PropertyTypeEnum.RealConservation:
                        case PropertyTypeEnum.RealEnergy:
                        case PropertyTypeEnum.RealFarms:
                        case PropertyTypeEnum.RealLowIncomeHousing:
                            percentage = 100;
                            return percentage;
                        default:
                            percentage = 200;
                            return percentage;
                    }
                case DeprMethodTypeEnum.DeclBal:
                case DeprMethodTypeEnum.DeclBalHalfYear:
                case DeprMethodTypeEnum.DeclBalModHalfYear:
                case DeprMethodTypeEnum.DeclBalSwitch:
                case DeprMethodTypeEnum.DeclBalHalfYearSwitch:
                case DeprMethodTypeEnum.DeclBalModHalfYearSwitch:
                    percentage = 200;
                    return percentage;
                case DeprMethodTypeEnum.MacrsFormula30:
                case DeprMethodTypeEnum.MACRSIndianReservation30:
                    percentage = 200;
                    return percentage;

                // Canadian BEGIN !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                case DeprMethodTypeEnum.CdnDeclBal:
                case DeprMethodTypeEnum.CdnDeclBalHalfYear:
                case DeprMethodTypeEnum.CdnDeclBalFullMonth:
                    percentage = 30;
                    return percentage;
                // Canadian END ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            }

            return percentage;
        }

    }
}
