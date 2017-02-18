using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DAL.Entities
{
    public class Groupcriteria
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int GroupId { get; set; }
        public int CriteriaId { get; set; }

        [Required]
        public Int16 FieldId { get; set; }

        public Int16 OperatorId { get; set; }

        [StringLength(255)]
        public string OperandOne { get; set; }

        [StringLength(255)]
        public string OperandTwo { get; set; }

        public Group Group { get; set; }
    }
}
