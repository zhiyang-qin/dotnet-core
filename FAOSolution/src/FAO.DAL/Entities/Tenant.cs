using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FAO.DAL.Entities
{
    public class Tenant
    {
        public Guid TenantId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public List<Company> Companies { get; set; }
    }
}
