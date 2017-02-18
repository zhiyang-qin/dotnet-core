using FAO.DAL.Entities;
using FAO.DtoMapper.Dtos;

namespace FAO.DtoMapper.Mappers
{
    public class CompanyfieldMapper : IMapper<Companyfield, CompanyfieldDto>
    {
        public static CompanyfieldDto EntityMapToDto(Companyfield entity)
        {
            return new CompanyfieldDto
            {
                TenantId = entity.TenantId,
                CompanyId = entity.CompanyId,
                FieldId = entity.FieldId,
                DefaultName = entity.DefaultName
            };
        }

        public CompanyfieldDto MapToDto(Companyfield entity)
        {
            return new CompanyfieldDto
            {
                TenantId = entity.TenantId,
                CompanyId = entity.CompanyId,
                FieldId = entity.FieldId,
                DefaultName = entity.DefaultName
            };
        }

        public Companyfield MapToEntity(CompanyfieldDto dto)
        {
            return new Companyfield
            {
                TenantId = dto.TenantId,
                CompanyId = dto.CompanyId,
                FieldId = dto.FieldId,
                DefaultName = dto.DefaultName
            };
        }
    }
}
