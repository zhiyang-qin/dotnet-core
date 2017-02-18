using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DtoMapper.Dtos
{
    public class CompanybookDto
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public short BookId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

    }
}
