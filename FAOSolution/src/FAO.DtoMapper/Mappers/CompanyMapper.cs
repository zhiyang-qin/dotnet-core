using FAO.DAL.Entities;
using FAO.DtoMapper.Dtos;

namespace FAO.DtoMapper.Mappers
{
    public class CompanyMapper : IMapper<Company, CompanyDto>
    {
        public static CompanyDto EntityMapToDto(Company entity)
        {
            return new CompanyDto
            {
                TenantId = entity.TenantId,
                CompanyId = entity.CompanyId,
                LongName = entity.LongName
            };
        }

        public CompanyDto MapToDto(Company entity)
        {
            return new CompanyDto
            {
                TenantId = entity.TenantId,
                CompanyId = entity.CompanyId,
                LongName = entity.LongName
            };
        }

        public Company MapToEntity(CompanyDto dto)
        {
            return new Company
            {
                TenantId = dto.TenantId,
                CompanyId = dto.CompanyId,
                LongName = dto.LongName
            };
        }
    }
}
