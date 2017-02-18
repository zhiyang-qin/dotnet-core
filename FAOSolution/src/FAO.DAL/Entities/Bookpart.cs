using System;

namespace FAO.DAL.Entities
{
    public class Bookpart
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int AssetId { get; set; }
        public Int16 SequenceId { get; set; }
        public Int16 BookId { get; set; }
        public DateTime PlaceServ { get; set; }

        public Partialinfo Partialinfo { get; set; }

    }
}
