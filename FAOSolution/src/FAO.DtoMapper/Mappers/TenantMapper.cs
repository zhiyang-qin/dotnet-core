using FAO.DAL.Entities;
using FAO.DtoMapper.Dtos;

namespace FAO.DtoMapper.Mappers
{
    public class TenantMapper : IMapper<Tenant, TenantDto>
    {

        public static TenantDto EntityMapToDto(Tenant entity)
        {
            return new TenantDto
            {
                TenantId = entity.TenantId,
                Name = entity.Name,
                IsActive = entity.IsActive

            };
        }

        public TenantDto MapToDto(Tenant entity)
        {
            return new TenantDto
            {
                TenantId = entity.TenantId,
                Name = entity.Name,
                IsActive = entity.IsActive
                
            };
        }

        public Tenant DtoMapToEntity(TenantDto dto)
        {
            return new Tenant
            {
                TenantId = dto.TenantId,
                Name = dto.Name,
                IsActive = dto.IsActive
            };
        }
    }
}
