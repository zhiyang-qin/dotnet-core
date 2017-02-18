using System;
using System.Collections.Generic;
using FAO.DtoMapper.Dtos;
using FAO.Repositories;
using FAO.Services.Interfaces;
using FAO.BLL.Domain.Rule;
using FAO.BLL.BusinessTypes;
using System.Linq;

namespace FAO.Services
{
    public class RuleService : IRuleService
    {
        private IUnitOfWork _unitOfWork;

        public RuleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public List<RuleItemDto> GetPropertyTypeList()
        {
            PropertyTypeRule propTypeRule = new PropertyTypeRule();
            List<PropertyTypeCode> list = propTypeRule.BuildValidList();

            List<RuleItemDto> itemList = list.Select(propCode => new RuleItemDto { Id = (int)propCode.Type, Name = propCode.shortName(), Value = propCode.longName() }).ToList();

            return itemList;
        }

        public List<RuleItemDto> GetDeprMethodList(string propTypeName, DateTime pisDate)
        {
            PropertyTypeEnum propType = PropertyTypeCode.translateShortNameToType(propTypeName);

            DeprMethodRule deprMethodRule = new DeprMethodRule();
            DeprPctRule deprPctRule = new DeprPctRule();

            List<DeprMethodCode> deprMethodList = deprMethodRule.BuildValidList(propType, pisDate);

            List<RuleItemDto> itemList = new List<RuleItemDto>();

            foreach (DeprMethodCode deprMethod in deprMethodList)
            {
                if (deprMethod.Percentage > 0)
                {
                    itemList.Add(new RuleItemDto { Id = (int)deprMethod.Type, Name = deprMethod.shortName() + deprMethod.Percentage, Value = deprMethod.longName() });
                }
                else
                {
                    itemList.Add(new RuleItemDto { Id = (int)deprMethod.Type, Name = deprMethod.shortName(), Value = deprMethod.longName() });
                }
            }

            return itemList;
        }

        public List<RuleItemDto> GetEstLifeList(string propTypeName, DateTime pisDate, string deprMethodName)
        {
            PropertyTypeEnum propType = PropertyTypeCode.translateShortNameToType(propTypeName);
            DeprMethodCode deprMethodCode = DeprMethodCode.translateDeprNameToCode(deprMethodName);

            EstLifeRule estLifeRule = new EstLifeRule();
            List<YrsMosDate> estLifeList = estLifeRule.BuildValidList(propType, pisDate, deprMethodCode.Type, deprMethodCode.Percentage);

            List<RuleItemDto> itemList = new List<RuleItemDto>();
            foreach (YrsMosDate estLife in estLifeList)
            {
                string text = String.Format("{0,-2:00} yrs {1,-2:00} mos", estLife.Years, estLife.Months);
                itemList.Add(new RuleItemDto() { Name = text, Value = text });
            }

            return itemList;
        }
    }
}
