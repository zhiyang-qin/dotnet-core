using FAO.BLL.BusinessTypes;
using FAO.BLL.Rulebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.Domain.Rule
{
    public class BusinessUseValueRule
    {
        public bool IsValid(DeprMethodTypeEnum deprMethod, int percentage)
        {
            IbpRuleBase rb = new bpRuleBase();
            ErrorCode errorCode;

            rb.ValidateBusinessUse((short)(deprMethod), (int)percentage, out errorCode);

            return errorCode == (short)RuleBase_ErrorCodeEnum.rulebase_Valid;
        }


    }
}
