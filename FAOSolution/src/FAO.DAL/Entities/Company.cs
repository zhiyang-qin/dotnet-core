using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FAO.DAL.Entities
{
    public class Company
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string LongName { get; set; }

        public DateTime BusnStart { get; set; }

        public string InitAsstNo { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(25)]
        public string Country { get; set; }

        [StringLength(25)]
        public string State { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [StringLength(15)]
        public string Zip { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(25)]
        public string Fax { get; set; }

        [StringLength(1024)]
        public string Note { get; set; }


        public List<Companybook> Companybooks { get; set; }
        public List<Companyfield> Companyfields { get; set; }
        public List<Group> Groups { get; set; }

        public Tenant Tenant { get; set; }
    }
}
