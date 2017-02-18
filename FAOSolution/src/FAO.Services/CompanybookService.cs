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
    public class CompanybookService : ICompanybookService
    {
        private IUnitOfWork _unitOfWork;

        public CompanybookService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<CompanybookDto> GetAllCompanybooks(Guid tenantid, Guid companyid)
        {
            IEnumerable<Companybook> companybookList = _unitOfWork.CompanybookRepository.GetMany(companybook=>companybook.TenantId == tenantid && companybook.CompanyId == companyid);
            IEnumerable<CompanybookDto> companybookDtoList = companybookList.Select(companybook => CompanybookMapper.EntityMapToDto(companybook));
            return companybookDtoList;
        }

}
}
