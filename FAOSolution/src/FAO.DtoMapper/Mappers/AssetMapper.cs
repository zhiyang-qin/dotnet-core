using FAO.DAL.Entities;
using FAO.DtoMapper.Dtos;

namespace FAO.DtoMapper.Mappers
{
    public class AssetMapper : IMapper<Asset, AssetDto>
    {
        public static AssetDto EntityMapToDto(Asset entity)
        {
            return new AssetDto
            {
                TenantId = entity.TenantId,
                CompanyId = entity.CompanyId,
                AssetId = entity.AssetId,
                PropType = entity.PropType,
                Description = entity.Description,
                Location = entity.Location,
                Department = entity.Department,
            };
        }

        public AssetDto MapToDto(Asset entity)
        {
            return new AssetDto
            {
                TenantId = entity.TenantId,
                CompanyId = entity.CompanyId,
                AssetId = entity.AssetId,
                PropType = entity.PropType,
                Description = entity.Description,
                Location = entity.Location,
                Department = entity.Department,
            };
        }

        public Asset MapToEntity(AssetDto dto)
        {
            return new Asset
            {
                TenantId = dto.TenantId,
                CompanyId = dto.CompanyId,
                AssetId = dto.AssetId,
                PropType = dto.PropType,
                Description = dto.Description,
                Location = dto.Location,
                Department = dto.Department
            };
        }
    }
}
