using FAO.BLL.BusinessTypes;
using FAO.BLL.Rulebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.Domain.Rule
{
    public class ADSLifeRule
    {
        public enum RuleResult
        {
            Valid = 0,
            RuleBaseFailure,
            Invalid
        };

        public YrsMosDate GetDefaultADSLife(PropertyTypeEnum propType, DateTime pisDate, DeprMethodTypeEnum deprMethod, int deprPct, YrsMosDate estLife)
        {
            // set to 0 years, 0 months by default.
            YrsMosDate classLife = new YrsMosDate(0, 0);

            // if automobile, always use 5 years.
            if (propType == PropertyTypeEnum.Automobile || propType == PropertyTypeEnum.LtTrucksAndVans)
                classLife = new YrsMosDate(5, 0);
            else
                if ((propType == PropertyTypeEnum.RealConservation ||
                  propType == PropertyTypeEnum.RealEnergy ||
                  propType == PropertyTypeEnum.RealFarms ||
                  propType == PropertyTypeEnum.RealGeneral ||
                  propType == PropertyTypeEnum.RealListed) &&
                 (deprMethod == DeprMethodTypeEnum.MacrsFormula) &&
                 (deprPct == 100) &&
                 (estLife.Years == 5))
            {
                classLife = new YrsMosDate(9, 0);
            }
            else
                    if ((propType == PropertyTypeEnum.RealConservation ||
                  propType == PropertyTypeEnum.RealEnergy ||
                  propType == PropertyTypeEnum.RealFarms ||
                  propType == PropertyTypeEnum.RealGeneral ||
                  propType == PropertyTypeEnum.RealListed) &&
                 (deprMethod == DeprMethodTypeEnum.AdsSlMacrs) &&
                 (estLife.Years == 9))
            {
                classLife = new YrsMosDate(9, 0);
            }
            else
                 if (propType == PropertyTypeEnum.VintageAccount ||
                 propType == PropertyTypeEnum.Amortizable)
                classLife = new YrsMosDate(0, 0);
            else
                  if ((propType == PropertyTypeEnum.RealGeneral ||
                  propType == PropertyTypeEnum.PersonalGeneral) &&
                  deprMethod == DeprMethodTypeEnum.MacrsFormula &&
                  deprPct == 100 &&
                  estLife.Years == 25)
                classLife = new YrsMosDate(50, 0);
            else
                 if (propType == PropertyTypeEnum.RealGeneral ||
                 propType == PropertyTypeEnum.RealListed ||
                 propType == PropertyTypeEnum.RealConservation ||
                 propType == PropertyTypeEnum.RealEnergy ||
                 propType == PropertyTypeEnum.RealFarms ||
                 propType == PropertyTypeEnum.RealLowIncomeHousing)
            {
                if ((deprMethod == DeprMethodTypeEnum.MACRSIndianReservation) && ((deprPct == 150) || (deprPct == 200)))
                    classLife = new YrsMosDate(10, 0);
                else if ((deprMethod == DeprMethodTypeEnum.MacrsFormula && deprPct == 100 && estLife.Years == 15) ||
                          (deprMethod == DeprMethodTypeEnum.MacrsFormula30 && deprPct == 100 && estLife.Years == 15) ||
                          (deprMethod == DeprMethodTypeEnum.MACRSIndianReservation && deprPct == 100 && estLife.Years == 9) ||
                          (deprMethod == DeprMethodTypeEnum.MACRSIndianReservation30 && deprPct == 100 && estLife.Years == 9) ||
                          (deprMethod == DeprMethodTypeEnum.AdsSlMacrs && deprPct == 0 && estLife.Years == 39) ||
                          (deprMethod == DeprMethodTypeEnum.AdsSlMacrs30 && deprPct == 0 && estLife.Years == 39))
                    classLife = new YrsMosDate(39, 0);
                else
                    classLife = new YrsMosDate(40, 0);
            }
            else
                 if (propType == PropertyTypeEnum.PersonalGeneral)
            {
                if (deprMethod == DeprMethodTypeEnum.StraightLine)
                    classLife = new YrsMosDate(0, 0);
                else
                if (deprMethod == DeprMethodTypeEnum.AcrsTable)
                    classLife = new YrsMosDate(11, 0);
                else
                    classLife = new YrsMosDate(10, 0);
            }
            else
                 if (propType == PropertyTypeEnum.PersonalListed)
            {
                if (deprMethod == DeprMethodTypeEnum.AcrsTable)
                    classLife = new YrsMosDate(11, 0);
                else
                    classLife = new YrsMosDate(10, 0);
            }

            return classLife;
        }

    }
}
