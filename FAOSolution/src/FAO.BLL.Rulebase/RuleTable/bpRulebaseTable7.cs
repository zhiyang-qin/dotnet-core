using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable7
    {
       public  bpRulebaseTable7() { }

       public  uint                tableNumber() 
                                  { return 7; }

       public  ulong               buildSourceCode( short deprMethod,
                                              uint ddbPct)
       {
           ulong key = 0L;

           key += (ulong)encodeBusUsePct(ddbPct) * 100L;

           key += (ulong)encodeDeprMethod(deprMethod);

           return key;
       }

       public  virtual bool        isObjectOk()
                                  { return true; }

      private   uint      encodeDeprMethod( short deprMethod )
    {
    switch( (DeprMethodTypeEnum)(deprMethod) )
         {
         case DeprMethodTypeEnum.MacrsFormula:
         case DeprMethodTypeEnum.MacrsFormula30:
              return 1;
         case DeprMethodTypeEnum.MacrsTable:
              return 2;
         case DeprMethodTypeEnum.AdsSlMacrs:
         case DeprMethodTypeEnum.AdsSlMacrs30:
              return 3;
         case DeprMethodTypeEnum.AcrsTable:
              return 4;
         case DeprMethodTypeEnum.StraightLineAltAcrsFormula:
              return 5;
         case DeprMethodTypeEnum.StraightLineAltAcrsTable:
              return 6;
         case DeprMethodTypeEnum.StraightLineModHalfYear:
              return 7;
         case DeprMethodTypeEnum.StraightLine:
              return 8;
         case DeprMethodTypeEnum.StraightLineFullMonth:
         case DeprMethodTypeEnum.StraightLineFullMonth30:
              return 9;
         case DeprMethodTypeEnum.StraightLineHalfYear:
              return 10;
         case DeprMethodTypeEnum.DeclBal:
         case DeprMethodTypeEnum.DeclBalSwitch:
              return 11;
         case DeprMethodTypeEnum.DeclBalModHalfYear:
         case DeprMethodTypeEnum.DeclBalModHalfYearSwitch:
              return 12;
         case DeprMethodTypeEnum.DeclBalHalfYear:
         case DeprMethodTypeEnum.DeclBalHalfYearSwitch:
              return 13;
         case DeprMethodTypeEnum.SumOfTheYearsDigitsHalfYear:
              return 14;
         case DeprMethodTypeEnum.SumOfTheYearsDigitsModHalfYear:
              return 15;
         case DeprMethodTypeEnum.SumOfTheYearsDigits:
              return 16;
         case DeprMethodTypeEnum.RemValueOverRemLife:
              return 17;
         case DeprMethodTypeEnum.OwnDepreciationCalculation:
              return 18;
         case DeprMethodTypeEnum.DoNotDepreciate:
              return 19;
         case DeprMethodTypeEnum.CustomMethod:
              return 20;
         case DeprMethodTypeEnum.MACRSIndianReservation:
         case DeprMethodTypeEnum.MACRSIndianReservation30:
              return 21;
         default:
              return 0;
         }
    }
      private uint encodeBusUsePct(uint busUsePct)
      {
          if (busUsePct <= 50)
              return 1;
          else
              return 2;
      }
    }
}
