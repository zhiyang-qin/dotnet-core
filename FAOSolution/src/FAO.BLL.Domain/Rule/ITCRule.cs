using FAO.BLL.BusinessTypes;
using FAO.BLL.Rulebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.Domain.Rule
{
    public class ITCRule
    {
        public enum RuleResult
        {
            Valid = 0,
            RuleBaseFailure,
            WarnBindingAgreement,
            WarnBindRealProperty,
            WarnRealProperty,
            InvalBefore1978,
            InvalBeforeOct11978,
            InvalBefore1980,
            InvalBefore1983,
            InvalBefore1987,
            InvalAfterSep1990,
            InvalAfter1985,
            InvalAfter1987,
            InvalMethods,
            InvalAfter1986,
            InvalBefore1982,
            InvalUnknownITCOption
        };

        public List<ITCCode> BuildValidList(PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum depMethod, int deprPct)
        {
            List<ITCCode> itcList = new List<ITCCode>();
            IbpRuleBase rb = new bpRuleBase();
            List<int> ei = new List<int>();

            rb.BuildITCList(pisDate, Convert.ToInt16(depMethod), out ei);

            if (ei == null || ei.Count == 0)
                return null;

            for (int posi = 0; posi < ei.Count; posi++)
            {
                ITCCode aCode = new ITCCode();
                aCode.Type = (ItcType)(ei[posi]);
                itcList.Add(new ITCCode(aCode));
            }

            return itcList;
        }

        public RuleResult IsValid(PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum deprMethod, int deprPct, YrsMosDate estLife, ItcType itcType)
        {
            ErrorCode errorCode;
            IbpRuleBase rb = new bpRuleBase();

            rb.ValidateITC((short)propType, pisDate, (short)deprMethod,
                (short)(estLife.Years * 100 + estLife.Months), (short)itcType, out errorCode);

            return (RuleResult)errorCode;
        }

        public double GetDefaultITCPct(PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum deprMethod, int deprPct, YrsMosDate estLife, ItcType itcType)
        {
            ErrorCode errorCode;
            double percentage = 0.0;
            IbpRuleBase rb = new bpRuleBase();

            rb.GetDefaultITCPercent((short)propType, (pisDate), (short)deprMethod, (short)(estLife.Years * 100 + estLife.Months), (short)itcType, ref percentage, out errorCode);

            if (errorCode == (short)RuleResult.Valid)
            {
                return percentage;
            }
            return 0.0;
        }

    }
}
