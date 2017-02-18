using FAO.DAL.Entities;
using FAO.DtoMapper.Dtos;

namespace FAO.DtoMapper.Mappers
{
    public class CompanybookMapper : IMapper<Companybook, CompanybookDto>
    {
        public static CompanybookDto EntityMapToDto(Companybook entity)
        {
            return new CompanybookDto
            {
                TenantId = entity.TenantId,
                CompanyId = entity.CompanyId,
                BookId = entity.BookId,
                Title = entity.Title
            };
        }

        public CompanybookDto MapToDto(Companybook entity)
        {
            return new CompanybookDto
            {
                TenantId = entity.TenantId,
                CompanyId = entity.CompanyId,
                BookId = entity.BookId,
                Title = entity.Title
            };
        }

        public Companybook MapToEntity(CompanybookDto dto)
        {
            return new Companybook
            {
                TenantId = dto.TenantId,
                CompanyId = dto.CompanyId,
                BookId = dto.BookId,
                Title = dto.Title
            };
        }
    }
}
