using FAO.DAL.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DtoMapper.Dtos
{
    public class TenantDto
    {
        public TenantDto()
        {
        }

        public TenantDto(Tenant tenant)
        {
        }

        public Guid TenantId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
