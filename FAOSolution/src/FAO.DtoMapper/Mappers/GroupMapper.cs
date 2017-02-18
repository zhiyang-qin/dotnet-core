using FAO.DAL.Entities;
using FAO.DtoMapper.Dtos;

namespace FAO.DtoMapper.Mappers
{
    public class GroupMapper : IMapper<Group, GroupDto>
    {
        public static GroupDto EntityMapToDto(Group entity)
        {
            return new GroupDto
            {
                TenantId = entity.TenantId,
                CompanyId = entity.CompanyId,
                GroupId = entity.GroupId,
                Name = entity.Name
            };
        }

        public GroupDto MapToDto(Group entity)
        {
            return new GroupDto
            {
                TenantId = entity.TenantId,
                CompanyId = entity.CompanyId,
                GroupId = entity.GroupId,
                Name = entity.Name
            };
        }

        public Group MapToEntity(GroupDto dto)
        {
            return new Group
            {
                TenantId = dto.TenantId,
                CompanyId = dto.CompanyId,
                GroupId = dto.GroupId,
                Name = dto.Name
            };
        }
    }
}
