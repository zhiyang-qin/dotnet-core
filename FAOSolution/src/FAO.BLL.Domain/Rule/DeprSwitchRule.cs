using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FAO.BLL.BusinessTypes.DeprSwitch;

namespace FAO.BLL.Domain.Rule
{
    public class DeprSwitchRule
    {
        public enum RuleResult
        {
            Valid = 1,
            Invalid,
            RuleBaseFailure
        };

        public DeprSwitchType GetDefaultDeprSwitch(DeprMethodTypeEnum deprMethod)
        {
            DeprSwitchType type = DeprSwitchType.DontSwitch;

            switch (deprMethod)
            {
                case DeprMethodTypeEnum.DeclBalSwitch:
                case DeprMethodTypeEnum.DeclBalHalfYearSwitch:
                case DeprMethodTypeEnum.DeclBalModHalfYearSwitch:
                    type = DeprSwitchType.SwitchWhenOptimal;
                    break;
                default:
                    type = DeprSwitchType.DontSwitch;
                    break;
            }
            return type;
        }

        static RuleResult IsApplicable(DeprMethodTypeEnum deprMethod)
        {
            switch (deprMethod)
            {
                case DeprMethodTypeEnum.DeclBalSwitch:
                case DeprMethodTypeEnum.DeclBalHalfYearSwitch:
                case DeprMethodTypeEnum.DeclBalModHalfYearSwitch:
                    return RuleResult.Valid;
            }
            return RuleResult.Invalid;
        }

    }
}
