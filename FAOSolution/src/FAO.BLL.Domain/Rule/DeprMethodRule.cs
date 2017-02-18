using FAO.BLL.BusinessTypes;
using FAO.BLL.Rulebase;
using System;
using System.Collections.Generic;

namespace FAO.BLL.Domain.Rule
{
    public class DeprMethodRule
    {
        public enum RuleResult
        {
            Valid = 1,
            Invalid,
            RuleBaseFailure,
            WarnNotNormallyUsed,
            WarnAfter1986,
            WarnNotUnderMACRS,
            InvalModAcrsBeforeAug11986,
            MethSameAsTax,
            MethSameAsTaxMI,
            Warn30LeaseholdImprove,
            WarnOnlyNYLZAllowForNonReal,
            WarnOnlyNYLZAllowForReal,
            WarnOnlyNYLZAllowAfter2006,
            UnknownMethod
        };

        //public List<DeprMethodCode> BuildValidList(string propTypeName, DateTime pisDate)
        //{
        //    PropertyTypeEnum propType = PropertyTypeCode.translateShortNameToType(propTypeName);

        //    return BuildValidList(propType, pisDate);
        //}

        public List<DeprMethodCode> BuildValidList(PropertyTypeEnum propType, DateTime pisDate)
        {
            List<DeprMethodCode> deprMethodCodeList = new List<DeprMethodCode>();
            IbpRuleBase rb = new bpRuleBase();
            List<int> ei = new List<int>();
            bool isShortYr = false;

            rb.BuildDeprMethodList((short)(propType), (pisDate), isShortYr, out ei);

            if (ei == null || ei.Count == 0)
                return null;

            DeprPctRule deprPctRule = new DeprPctRule();

            for (int posi = 0; posi < ei.Count; posi++)
            {
                DeprMethod aType = new DeprMethod((DeprMethodTypeEnum)ei[posi]);

                List<DeprPct> pctList = deprPctRule.BuildValidList(propType, pisDate, aType.Type);
                if (pctList != null && pctList.Count > 0)
                {
                    foreach (DeprPct deprPct in pctList)
                    {
                        deprMethodCodeList.Add(new DeprMethodCode(aType) { Percentage = deprPct.Percentage });
                    }
                }
                else
                {
                    deprMethodCodeList.Add(new DeprMethodCode(aType));
                }

            }

            return deprMethodCodeList;
        }

        public RuleResult IsValid(PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum deprMethod)
        {
            ErrorCode errorCode;
            bool isShortYr = false;
            IbpRuleBase rb = new bpRuleBase();

            rb.ValidateDeprMethod((short)propType, pisDate, (short)deprMethod, isShortYr, out errorCode);

            switch ((RuleBase_ErrorCodeEnum)errorCode)
            {
                case RuleBase_ErrorCodeEnum.rulebase_ValidateCustomMethodExists:
                    return RuleResult.Valid;
                case RuleBase_ErrorCodeEnum.rulebase_Invalid:
                    return RuleResult.Invalid;
                case RuleBase_ErrorCodeEnum.rulebase_WarnAfter1986:
                    return RuleResult.WarnAfter1986;
                case RuleBase_ErrorCodeEnum.rulebase_WarnNotUnderMACRS:
                    return RuleResult.WarnNotUnderMACRS;
                case RuleBase_ErrorCodeEnum.rulebase_WarnNotNormallyUsed:
                    return RuleResult.WarnNotNormallyUsed;
                case RuleBase_ErrorCodeEnum.rulebase_InvalModAcrsBeforeAug11986:
                    return RuleResult.InvalModAcrsBeforeAug11986;
                case RuleBase_ErrorCodeEnum.rulebase_RuleBaseFailure:
                    return RuleResult.RuleBaseFailure;
                case RuleBase_ErrorCodeEnum.rulebase_MethSameAsTax:
                    return RuleResult.MethSameAsTax;
                case RuleBase_ErrorCodeEnum.rulebase_MethSameAsTaxMI:
                    return RuleResult.MethSameAsTaxMI;
                case RuleBase_ErrorCodeEnum.rulebase_Warn30LeaseholdImprove:
                    return RuleResult.Warn30LeaseholdImprove;
                case RuleBase_ErrorCodeEnum.rulebase_WarnOnlyNYLZAllowForNonReal:
                    return RuleResult.WarnOnlyNYLZAllowForNonReal;
                case RuleBase_ErrorCodeEnum.rulebase_WarnOnlyNYLZAllowForReal:
                    return RuleResult.WarnOnlyNYLZAllowForReal;
                case RuleBase_ErrorCodeEnum.rulebase_WarnOnlyNYLZAllowAfter2006:
                    return RuleResult.WarnOnlyNYLZAllowAfter2006;
                case RuleBase_ErrorCodeEnum.rulebase_Valid:
                    return RuleResult.Valid;
            }
            return RuleResult.RuleBaseFailure;
        }

        public DeprMethodTypeEnum GetDefaultDeprMethod(PropertyTypeEnum propType, DateTime pisDate)
        {
            ErrorCode errorCode;
            short DeprMethod = -1;
            IbpRuleBase rb = new bpRuleBase();

            rb.GetDefaultDeprMethod((short)propType, pisDate, out DeprMethod, out errorCode);

            return (DeprMethodTypeEnum)DeprMethod;
        }

    }
}
