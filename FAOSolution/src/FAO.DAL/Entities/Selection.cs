using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DAL.Entities
{
    public class Selection
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int FieldId { get; set; }
        public int SelectionId { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Value { get; set; }

        public Companyfield Companyfield { get; set; }

    }
}
