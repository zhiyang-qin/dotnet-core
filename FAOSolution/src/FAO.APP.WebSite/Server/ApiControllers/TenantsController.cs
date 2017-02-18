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
    [Route("api/Tenants")]
    public class TenantsController : Controller
    {
        private ITenantService _tenantService;

        public TenantsController(ITenantService tenantService)
        {
            this._tenantService = tenantService;
        }

        [HttpGet]
        public IEnumerable<TenantDto> GetAll()
        {
            IEnumerable<TenantDto> tenantList = _tenantService.GetAllTenants();
            return tenantList;
        }

        [HttpGet("{tenantid}")]
        public IActionResult GetByTenantId(Guid tenantid)
        {
            var item = _tenantService.GetTenant(tenantid);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]TenantDto tenant)
        {
            if (tenant == null)
            {
                return BadRequest();
            }

            _tenantService.AddTenant(tenant);

            return new ObjectResult(tenant);
        }

        [HttpPut("{tenantid}")]
        public IActionResult Update(Guid tenantid, [FromBody]TenantDto tenant)
        {
            if (tenant == null)
            {
                return BadRequest();
            }
            var item = _tenantService.GetTenant(tenantid);

            if (item == null)
            {
                return NotFound();
            }

            _tenantService.SaveTenant(tenant);

            return new NoContentResult();
        }

        [HttpDelete("{tenantid}")]
        public IActionResult Delete(Guid tenantid)
        {
            if (_tenantService.DeleteTenant(tenantid))
            {
                return NotFound();
            }

            return new NoContentResult();
        }
    }
}
