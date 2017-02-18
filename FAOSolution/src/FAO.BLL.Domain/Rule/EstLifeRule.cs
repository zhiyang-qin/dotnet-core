using FAO.BLL.BusinessTypes;
using FAO.BLL.Rulebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.Domain.Rule
{
    public class EstLifeRule
    {
        public enum RuleResult
        {
            Valid,
            Invalid,
            WarnNotUsualRecoveryPeriod,
            WarnNotUsualUnlTransProp,
            RuleBaseFailure,
            AMTNotSameAsTax,
            AMTNotSameAsTaxNotMI,
            WarnNotUsualRecoveryPd,
            WarnNotOver20Years,
            WarnAANotOver20Years,
            WarnOnlyNYLZAllowForRMF100EST0500
        };

        public List<YrsMosDate> BuildValidList(PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum method, int pct)
        {
            List<YrsMosDate> estLifeList = new List<YrsMosDate>();
            IbpRuleBase rb = new bpRuleBase();
            List<int> ei = new List<int>();

            rb.BuildEstimatedLifeList((short)propType, pisDate, (short)method, (int)pct, out ei);

            if (ei == null || ei.Count == 0)
                return null;

            for (int posi = 0; posi < ei.Count; posi++)
            {
                estLifeList.Add(new YrsMosDate((uint)ei[posi]/100, (uint)ei[posi]%100));
            }

            return estLifeList;
        }

        public RuleResult IsValid(BookTypeEnum book, PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum deprMethod, int deprPct, YrsMosDate estLife)
        {
            ErrorCode errorCode;
            IbpRuleBase rb = new bpRuleBase();

            rb.ValidateEstimatedLife((short)(propType), pisDate, (short)(deprMethod), (int)deprPct, (short)(estLife.Years * 100 + estLife.Months), out errorCode);

            switch ((RuleBase_ErrorCodeEnum)errorCode)
            {
                case RuleBase_ErrorCodeEnum.rulebase_Valid:
                    return RuleResult.Valid;
                case RuleBase_ErrorCodeEnum.rulebase_Invalid:
                    return RuleResult.Invalid;
                case RuleBase_ErrorCodeEnum.rulebase_WarnNotUsualRecoveryPd:
                    return RuleResult.WarnNotUsualRecoveryPd;
                case RuleBase_ErrorCodeEnum.rulebase_WarnNotUsualRecoveryPeriod:
                    return RuleResult.WarnNotUsualRecoveryPeriod;
                case RuleBase_ErrorCodeEnum.rulebase_WarnNotUsualUnlTransProp:
                    return RuleResult.WarnNotUsualUnlTransProp;
                case RuleBase_ErrorCodeEnum.rulebase_WarnNotOver20Years:
                    return RuleResult.WarnNotOver20Years;
                case RuleBase_ErrorCodeEnum.rulebase_WarnAANotOver20Years:
                    return RuleResult.WarnAANotOver20Years;
                case RuleBase_ErrorCodeEnum.rulebase_WarnOnlyNYLZAllowForRMF100EST0500:
                    return RuleResult.WarnOnlyNYLZAllowForRMF100EST0500;
                case RuleBase_ErrorCodeEnum.rulebase_RuleBaseFailure:
                    return RuleResult.RuleBaseFailure;
            }
            // section 179 does not apply.
            return RuleResult.Invalid;
        }

        public YrsMosDate GetDefaultEstLife(PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum deprMethod, int deprPct)
        {
            ErrorCode errorCode;
            short estLife = -1;
            IbpRuleBase rb = new bpRuleBase();

            rb.GetDefaultEstimatedLife((short)propType, pisDate, (short)deprMethod, (int)deprPct, ref estLife, out errorCode);

            if (errorCode == (short)RuleBase_ErrorCodeEnum.rulebase_Valid)
            {
                return new YrsMosDate((uint)(estLife / 100), (uint)(estLife % 100));
            }
            return null;
        }

    }
}
