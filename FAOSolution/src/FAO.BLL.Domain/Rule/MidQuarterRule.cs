using FAO.BLL.BusinessTypes;
using FAO.BLL.Rulebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.Domain.Rule
{
    public class MidQuarterRule
    {
        public enum RuleResult
        {
            Valid = 0,
            RuleBaseFailure,
            Invalid
        };

        public RuleResult IsApplicable(PropertyTypeEnum propType, DeprMethodTypeEnum deprMethod)
        {
            IbpRuleBase rb = new bpRuleBase();
            ErrorCode errorCode;

            rb.AllowMidQuarter((short)(propType), (short)(deprMethod), true, out errorCode);

            switch ((RuleBase_ErrorCodeEnum)errorCode)
            {
                case RuleBase_ErrorCodeEnum.rulebase_Valid:
                    return RuleResult.Valid;
                case RuleBase_ErrorCodeEnum.rulebase_Invalid:
                    return RuleResult.Invalid;
                case RuleBase_ErrorCodeEnum.rulebase_RuleBaseFailure:
                    return RuleResult.RuleBaseFailure;
            }
            return RuleResult.RuleBaseFailure;
        }

    }
}
