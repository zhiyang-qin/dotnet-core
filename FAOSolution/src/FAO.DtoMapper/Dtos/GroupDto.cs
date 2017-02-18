using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DtoMapper.Dtos
{
    public class GroupDto
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int GroupId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

    }
}
