using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DAL.Entities
{
    public class Assetevent
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int AssetId { get; set; }
        public Int16 EventId { get; set; }

        public DateTime EventDate { get; set; }

        [StringLength(100)]
        public string OriginalValue { get; set; }

        [StringLength(100)]
        public string NewValue { get; set; }

        public Asset Asset { get; set; }
    }
}
