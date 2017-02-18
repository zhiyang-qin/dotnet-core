using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DtoMapper.Dtos
{
    public class AssetDto
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int AssetId { get; set; }

        [Required]
        [StringLength(50)]
        public string PropType { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }

    }
}
