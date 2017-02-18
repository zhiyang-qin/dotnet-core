using System;
using System.Collections.Generic;

namespace FAO.DAL.Entities
{
    public class Group
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }

        public List<Groupcriteria> Groupcriterias { get; set; }
        public List<Groupsort> Groupsorts { get; set; }

        public Company Company { get; set; }
    }
}
