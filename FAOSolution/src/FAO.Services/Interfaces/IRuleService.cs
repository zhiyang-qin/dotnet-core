using System;
using FAO.DtoMapper.Dtos;
using System.Collections.Generic;

namespace FAO.Services.Interfaces
{
    public interface IRuleService
    {
        List<RuleItemDto> GetPropertyTypeList();
        List<RuleItemDto> GetDeprMethodList(string propTypeName, DateTime pisDate);
        List<RuleItemDto> GetEstLifeList(string propTypeName, DateTime pisDate, string deprMethodName);

    }
}
