using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FAO.DAL.Entities
{
    public class Partialinfo
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public int AssetId { get; set; }
        public Int16 SequenceId { get; set; }

        [StringLength(1)]
        public string ActivityCd { get; set; }

        [StringLength(1)]
        public string CreationCd { get; set; }

        public DateTime DisposalDate { get; set; }

        [StringLength(1)]
        public string DisposalMethod { get; set; }

        [StringLength(80)]
        public string DispDescription { get; set; }
        public float DispPctIn { get; set; }
        public float DispPctOut { get; set; }
        public decimal CashProceeds { get; set; }
        public decimal NonCashProceeds { get; set; }
        public decimal ExpenseOfSale { get; set; }


        public List<Bookpart> Bookparts { get; set; }

        public Asset Asset { get; set; }

    }
}
