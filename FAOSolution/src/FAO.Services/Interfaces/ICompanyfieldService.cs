using FAO.DtoMapper.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.Services.Interfaces
{
    public interface ICompanyfieldService
    {
        IEnumerable<CompanyfieldDto> GetAllCompanyfields(Guid tenantid, Guid companyid);
    }
}
