using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.BLL.CalcEngine.Interfaces
{
    public interface IBAACEInformation
    {
        bool UseACEHandling { get; }
        decimal ACEBasis { get; set; }
        double ACELife { get; set; }
    }
}
