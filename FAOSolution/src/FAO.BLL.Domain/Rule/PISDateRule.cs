using FAO.BLL.BusinessTypes;
using FAO.BLL.Rulebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.Domain.Rule
{
    public class PISDateRule
    {
        public enum RuleResult
        {
            Valid,
            RuleBaseFailure,
            InvalDateValue,
            LowIncHousingInvalBefore1981,
            ListedPropInvalBeforeJune191984,
            LowIncHousingInvalAfter1986,
            AutoPropInvalBeforeJune191984,
            DateInvalBeforeStartBusiness,
            DateInvalBefore1920,
            DateInvalAfter2999,
            LtTrucksAndVansPropInvalBefore2003
        };

        public RuleResult IsValid(PropertyTypeEnum propType, DateTime pisDate, DateTime startOfBusinessDate)
        {
            ErrorCode errorCode;
            bool isShortYr = false;
            IbpRuleBase rb = new bpRuleBase();

            rb.ValidatePlaceInService((short)(propType), pisDate, startOfBusinessDate, out errorCode);

            switch ((RuleBase_ErrorCodeEnum)errorCode)
            {
                case RuleBase_ErrorCodeEnum.rulebase_Valid:
                    return RuleResult.Valid;
                case RuleBase_ErrorCodeEnum.rulebase_RuleBaseFailure:
                    return RuleResult.RuleBaseFailure;
                case RuleBase_ErrorCodeEnum.rulebase_InvalDateValue:
                    return RuleResult.InvalDateValue;
                case RuleBase_ErrorCodeEnum.rulebase_LowIncHousingInvalBefore1981:
                    return RuleResult.LowIncHousingInvalBefore1981;
                case RuleBase_ErrorCodeEnum.rulebase_ListedPropInvalBeforeJune191984:
                    return RuleResult.ListedPropInvalBeforeJune191984;
                case RuleBase_ErrorCodeEnum.rulebase_LowIncHousingInvalAfter1986:
                    return RuleResult.LowIncHousingInvalAfter1986;
                case RuleBase_ErrorCodeEnum.rulebase_AutoPropInvalBeforeJune191984:
                    return RuleResult.AutoPropInvalBeforeJune191984;
                case RuleBase_ErrorCodeEnum.rulebase_DateInvalBeforeStartBusiness:
                    return RuleResult.DateInvalBeforeStartBusiness;
                case RuleBase_ErrorCodeEnum.rulebase_DateInvalBefore1920:
                    return RuleResult.DateInvalBefore1920;
                case RuleBase_ErrorCodeEnum.rulebase_DateInvalAfter2999:
                    return RuleResult.DateInvalAfter2999;
                case RuleBase_ErrorCodeEnum.rulebase_LtTrucksAndVansPropInvalBefore2003:
                    return RuleResult.LtTrucksAndVansPropInvalBefore2003;
            }
            return RuleResult.RuleBaseFailure;
        }

    }
}
