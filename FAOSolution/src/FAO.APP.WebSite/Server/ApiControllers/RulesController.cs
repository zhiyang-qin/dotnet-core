using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FAO.Services;
using FAO.Services.Interfaces;
using FAO.DtoMapper.Dtos;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FAO.WebSite.Controllers
{
    [Route("api/Rules/[action]")]
    public class RulesController : Controller
    {
        private IRuleService _ruleService;

        public RulesController(IRuleService ruleService)
        {
            this._ruleService = ruleService;
        }

        [HttpGet]
        public IEnumerable<RuleItemDto> PropTypes()
        {
            IEnumerable<RuleItemDto> propTypeList = _ruleService.GetPropertyTypeList();
            return propTypeList;
        }

        [HttpGet]
        public IEnumerable<RuleItemDto> DeprMethods([FromQuery]string propertyType, [FromQuery]DateTime pisDate)
        {
            if (propertyType == null)
                return null;

            IEnumerable<RuleItemDto> depeMethodList = _ruleService.GetDeprMethodList(propertyType, pisDate);
            return depeMethodList;
        }

        [HttpGet]
        public IEnumerable<RuleItemDto> EstLifes([FromQuery]string propertyType, [FromQuery]DateTime pisDate, [FromQuery]string deprMethod)
        {
            if (propertyType == null || deprMethod == null)
                return null;

            IEnumerable<RuleItemDto> estLifeList = _ruleService.GetEstLifeList(propertyType, pisDate, deprMethod);
            return estLifeList;
        }

    }
}
