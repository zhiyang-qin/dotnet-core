using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DAL.Entities
{
    public class Companybook
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public short BookId { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        public bool IsOpen { get; set; }
        public short FiscalYearEnd { get; set; }

        public Company Company { get; set; }
    }
}
