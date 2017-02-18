using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FAO.DAL.Entities
{
    public class Companyfield
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public Int16 FieldId { get; set; }

        [StringLength(25)]
        public string TableName { get; set; }

        [StringLength(25)]
        public string FieldName { get; set; }

        [StringLength(25)]
        public string DefaultName { get; set; }

        public Int16 Type { get; set; }

        [StringLength(1)]
        public string Sortable { get; set; }

        [StringLength(1)]
        public string Searchable { get; set; }

        [StringLength(1)]
        public string Customizable { get; set; }

        [StringLength(1)]
        public string Subtotalable { get; set; }

        [StringLength(1)]
        public string Replaceable { get; set; }

        public Int16 MaxWidth { get; set; }

        public List<Selection> Selections { get; set; }

        public Company Company { get; set; }
    }
}
