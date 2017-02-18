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
    public class GroupsController : Controller
    {
        public IGroupService _GroupService;

        public GroupsController(IGroupService GroupService)
        {
            this._GroupService = GroupService;
        }

        [HttpGet]
        public IEnumerable<GroupDto> GetAll(Guid tenantid, Guid companyid)
        {
            IEnumerable<GroupDto> groupList = _GroupService.GetAllGroups(tenantid, companyid);
            return groupList;
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
