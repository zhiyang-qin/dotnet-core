using FAO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAO.DtoMapper.Dtos;
using FAO.Repositories;
using FAO.DAL.Entities;
using FAO.DtoMapper.Mappers;

namespace FAO.Services
{
    public class TenantService : ITenantService
    {
        private IUnitOfWork _unitOfWork;

        public TenantService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<TenantDto> GetAllTenants()
        {
            IEnumerable<Tenant> tenantList = _unitOfWork.TenantRepository.GetAll();
            IEnumerable<TenantDto> tenantDtoList = tenantList.Select(tenent => TenantMapper.EntityMapToDto(tenent)); // .ToList();
            return tenantDtoList;
        }

        public TenantDto AddTenant(TenantDto tenant)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTenant(Guid tenantId)
        {
            throw new NotImplementedException();
        }

        public TenantDto GetTenant(Guid tenantId)
        {
            throw new NotImplementedException();
        }

        public bool SaveTenant(TenantDto tenant)
        {
            throw new NotImplementedException();
        }
    }
}
