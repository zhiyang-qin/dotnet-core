using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FAO.Services;
using FAO.Services.Interfaces;
using FAO.DtoMapper.Dtos;
using FAO.BLL.BusinessTypes.Common;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FAO.WebSite.Controllers
{
    [Route("api/Calcs/[action]")]
    public class CalcsController : Controller
    {
        private ICalculationService _calculationService;

        public CalcsController(ICalculationService calculationService)
        {
            this._calculationService = calculationService;
        }


/** Sample Request
Content-Type: application/json
JSON:  
{
  "PropertyType": "P",
  "PlaceInServiceDate": "2010-01-01",
  "AcquiredValue": 10000.0,
  "DepreciateMethod": "SL",
  "DepreciatePercent": 0,
  "EstimatedLife": 10,
  "Section179": 0.0,
  "ITCAmount": 0.0,
  "ITCReduce": 0.0,
  "SalvageDeduction": 0.0,
  "Bonus911Percent": 0,
  "Convention": null,
  "RunDate": "2015-12-31",
  "MPStartDate": "0001-01-01T00:00:00",
  "MPEndDate": "0001-01-01T00:00:00"
}
*/
        [HttpPost]
        public PeriodDeprItemDto Depreciate([FromQuery]DateTime runDate, [FromBody]DepreciableBookDto deprBook)
        {
            if (!runDate.IsValid())
                runDate = DateTime.Now;

            var periodDeprItemDto = _calculationService.CalculateDepreciation(deprBook, runDate);

            return periodDeprItemDto;
        }

        [HttpPost]
        public List<PeriodDeprItemDto> Project([FromBody]DepreciableBookDto deprBook)
        {
            var periodDeprItemDto = _calculationService.CalculateProjection(deprBook);

            return periodDeprItemDto;
        }

        [HttpPost]
        public List<PeriodDeprItemDto> MonthlyProject([FromQuery]DateTime startDate, [FromQuery]DateTime endDate, [FromBody]DepreciableBookDto deprBook)
        {
            if (!startDate.IsValid())
                startDate = DateTime.Now;

            if (!endDate.IsValid())
                endDate = startDate.AddDays(365);

            var periodDeprItemDto = _calculationService.CalculateMonthlyProjection(deprBook, startDate, endDate);

            return periodDeprItemDto;
        }

    }
}
