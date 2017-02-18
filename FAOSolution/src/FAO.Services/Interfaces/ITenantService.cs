using System;
using FAO.DtoMapper.Dtos;
using System.Collections.Generic;

namespace FAO.Services.Interfaces
{
    public interface ITenantService
    {
        IEnumerable<TenantDto> GetAllTenants();
        TenantDto GetTenant(Guid tenantId);
        TenantDto AddTenant(TenantDto tenant);
        bool SaveTenant(TenantDto tenant);
        bool DeleteTenant(Guid tenantId);
    }
}
