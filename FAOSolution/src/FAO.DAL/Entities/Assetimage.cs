using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DAL.Entities
{
    public class Assetimage
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int AssetId { get; set; }
        public Int16 ImageId { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        public Asset Asset { get; set; }
    }
}
