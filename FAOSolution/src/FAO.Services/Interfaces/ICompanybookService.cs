using FAO.DtoMapper.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.Services.Interfaces
{
    public interface ICompanybookService
    {
        IEnumerable<CompanybookDto> GetAllCompanybooks(Guid tenantid, Guid companyid);
    }
}
