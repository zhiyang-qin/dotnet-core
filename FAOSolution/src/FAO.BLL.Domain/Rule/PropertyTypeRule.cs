using System.Collections.Generic;
using FAO.BLL.BusinessTypes;
using FAO.BLL.Rulebase;

namespace FAO.BLL.Domain.Rule
{
    public class PropertyTypeRule
    {
        public enum RuleResult
        {
            Valid = 1,
            Invalid,
            RuleBaseFailure,
        };

        public List<PropertyTypeCode> BuildValidList()
        {
            List<PropertyTypeCode> propTypeCodeList = new List<PropertyTypeCode>();
            IbpRuleBase rb = new bpRuleBase();
            List<int> ei = new List<int>();

            rb.BuildPropTypeList(out ei);

            if (ei == null || ei.Count == 0)
                return null;

            for (int posi = 0; posi < ei.Count; posi++)
            {
                PropertyType aType = new PropertyType((PropertyTypeEnum)ei[posi]);
                propTypeCodeList.Add(new PropertyTypeCode(aType));
            }

            return propTypeCodeList;
        }

        public RuleResult IsValid(PropertyTypeEnum propType)
        {
            return RuleResult.Valid;
        }

        public PropertyTypeEnum GetDefaultPropertyType()
        {
            return PropertyTypeEnum.PersonalGeneral;
        }

    }
}
