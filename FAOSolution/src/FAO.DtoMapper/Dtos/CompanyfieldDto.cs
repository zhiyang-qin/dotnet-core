using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DtoMapper.Dtos
{
    public class CompanyfieldDto
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public short FieldId { get; set; }

        [Required]
        [StringLength(50)]
        public string DefaultName { get; set; }

    }
}
