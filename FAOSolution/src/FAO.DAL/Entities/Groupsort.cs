using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DAL.Entities
{
    public class Groupsort
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int GroupId { get; set; }
        public int SortId { get; set; }

        [Required]
        public Int16 FieldId { get; set; }
        public Int16 DirectionId { get; set; }

        public Group Group { get; set; }
    }
}
