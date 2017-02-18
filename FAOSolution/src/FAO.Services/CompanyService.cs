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
    public class CompanyService : ICompanyService
    {
        private IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(Guid tenantid)
        {
            IEnumerable<Company> companyList = _unitOfWork.CompanyRepository.GetMany(company=>company.TenantId == tenantid);
            IEnumerable<CompanyDto> companyDtoList = companyList.Select(company => CompanyMapper.EntityMapToDto(company)); // .ToList();
            return companyDtoList;
        }

}
}
