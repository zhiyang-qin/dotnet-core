using System;
using System.ComponentModel.DataAnnotations;

namespace FAO.DtoMapper.Dtos
{
    public class DepreciableBookDto
    {
        public string PropertyType { get; set; }
        public DateTime PlaceInServiceDate { get; set; }
        public double AcquiredValue { get; set; }
        public string DepreciateMethod { get; set; }
        public short DepreciatePercent { get; set; }
        public int EstimatedLife { get; set; }
        public double Section179 { get; set; }
        public double ITCAmount { get; set; }
        public double ITCReduce { get; set; }
        public double SalvageDeduction { get; set; }
        public short Bonus911Percent { get; set; }
        public string Convention { get; set; }
        public DateTime RunDate { get; set; }
        public DateTime MPStartDate { get; set; }
        public DateTime MPEndDate { get; set; }
    }

}
