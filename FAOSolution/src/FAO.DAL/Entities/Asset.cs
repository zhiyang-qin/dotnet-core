using System;
using System.Collections.Generic;

namespace FAO.DAL.Entities
{
    public class Asset
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int AssetId { get; set; }
        public string PropType { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }

        public List<Assetevent> Assetevents { get; set; }
        public List<Assetimage> Assetimages { get; set; }
        public List<Partialinfo> Partialinfos { get; set; }

        public Company Company { get; set; }
    }
}
