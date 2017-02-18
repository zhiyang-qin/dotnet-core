using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.DAL.Entities
{
    public class Field
    {
        public int FieldId { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
    }
}
