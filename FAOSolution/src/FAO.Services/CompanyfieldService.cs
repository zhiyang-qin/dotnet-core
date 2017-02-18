using FAO.DAL.Entities;
using FAO.DtoMapper.Dtos;
using FAO.DtoMapper.Mappers;
using FAO.Repositories;
using FAO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.Services
{
    public class CompanyfieldService : ICompanyfieldService
    {
        private IUnitOfWork _unitOfWork;

        public CompanyfieldService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<CompanyfieldDto> GetAllCompanyfields(Guid tenantid, Guid companyid)
        {
            IEnumerable<Companyfield> companyfieldList = _unitOfWork.CompanyfieldRepository.GetMany(companyfield=>companyfield.TenantId == tenantid && companyfield.CompanyId == companyid);
            IEnumerable<CompanyfieldDto> companyfieldDtoList = companyfieldList.Select(companyfield => CompanyfieldMapper.EntityMapToDto(companyfield));
            return companyfieldDtoList;
        }

}
}
