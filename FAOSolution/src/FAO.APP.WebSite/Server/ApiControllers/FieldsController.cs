using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FAO.Services.Interfaces;
using FAO.DtoMapper.Dtos;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FAO.WebSite.Controllers
{
    [Route("api/{tenantid}/Companies/{companyid}/[controller]")]
    public class FieldsController : Controller
    {
        public ICompanyfieldService _companyfieldService;

        public FieldsController(ICompanyfieldService companyfieldService)
        {
            this._companyfieldService = companyfieldService;
        }

        [HttpGet]
        public IEnumerable<CompanyfieldDto> GetAll(Guid tenantid, Guid companyid)
        {
            IEnumerable<CompanyfieldDto> companyfieldList = _companyfieldService.GetAllCompanyfields(tenantid, companyid);
            return companyfieldList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
