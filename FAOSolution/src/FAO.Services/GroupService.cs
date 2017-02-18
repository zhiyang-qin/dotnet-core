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
    public class GroupService : IGroupService
    {
        private IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<GroupDto> GetAllGroups(Guid tenantid, Guid companyid)
        {
            IEnumerable<Group> groupList = _unitOfWork.GroupRepository.GetMany(Group=>Group.TenantId == tenantid && Group.CompanyId == companyid);
            IEnumerable<GroupDto> groupDtoList = groupList.Select(group => GroupMapper.EntityMapToDto(group));
            return groupDtoList;
        }

}
}
