using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable14
    {
       public  bpRulebaseTable14() { }

       public  uint                tableNumber() 
                                  { return 14; }

       public  ulong               buildSourceCode( short propType,
                                              DateTime pisDate,
                                              short deprMethod,
                                              uint ddbPct,
                                              short estLife)
       {
           ulong key = 0L;

           key += (ulong)encodePropType(propType) * 100000000L;

           key += (ulong)encodePisDate(pisDate) * 1000000L;

           key += (ulong)encodeDeprMethod(deprMethod) * 10000L;

           key += (ulong)encodeDdbPct(ddbPct) * 100L; ;

           key += (ulong)encodeEstLife(estLife);

           return key;
       }

       public  bool        isObjectOk() 
                                  { return true; }

       private  uint                encodePropType( short propType )
    {
        switch ((PropertyTypeEnum)(propType))
         {
         case PropertyTypeEnum.PersonalGeneral:
         case PropertyTypeEnum.PersonalListed:
         case PropertyTypeEnum.VintageAccount:
         case PropertyTypeEnum.Amortizable:
         case PropertyTypeEnum.Depreciable:
              return 1;
         case PropertyTypeEnum.RealConservation:
         case PropertyTypeEnum.RealEnergy:
         case PropertyTypeEnum.RealFarms:
         case PropertyTypeEnum.RealLowIncomeHousing:
         case PropertyTypeEnum.RealGeneral:
         case PropertyTypeEnum.RealListed:
         case PropertyTypeEnum.NonDepreciable:
              return 2;
         case PropertyTypeEnum.Automobile:
         case PropertyTypeEnum.LtTrucksAndVans:
              return 3;
         default:
              return 0;
         }
    }
       private uint encodePisDate(DateTime pisDate)
       {
           DateTime testDate1 = new DateTime(1987,1, 1 );
           DateTime testDate2 = new DateTime(1999,1, 1 );

           if (pisDate < testDate1)
               return 1;
           else
               if ((pisDate >= testDate1) && (pisDate < testDate2))
                   return 2;
               else
                   return 3;
       }

       private  uint                encodeDeprMethod( short deprMethod )
    {
        switch ((DeprMethodTypeEnum)(deprMethod))
         {
         case DeprMethodTypeEnum.StraightLine:
              return 1;
         case DeprMethodTypeEnum.StraightLineFullMonth:
         case DeprMethodTypeEnum.StraightLineFullMonth30:
              return 2;
         case DeprMethodTypeEnum.StraightLineHalfYear:
              return 3;
         case DeprMethodTypeEnum.StraightLineModHalfYear:
              return 4;
         case DeprMethodTypeEnum.StraightLineAltAcrsFormula:
              return 5;
         case DeprMethodTypeEnum.StraightLineAltAcrsTable:
              return 6;
         case DeprMethodTypeEnum.AcrsTable:
              return 7;
         case DeprMethodTypeEnum.MacrsFormula:
              return 8;
         case DeprMethodTypeEnum.MacrsTable:
              return 9;
         case DeprMethodTypeEnum.AdsSlMacrs:
         case DeprMethodTypeEnum.AdsSlMacrs30:
              return 10;
         case DeprMethodTypeEnum.DeclBalModHalfYear:
         case DeprMethodTypeEnum.DeclBalModHalfYearSwitch:
              return 11;
         case DeprMethodTypeEnum.DeclBal:
         case DeprMethodTypeEnum.DeclBalSwitch:
              return 12;
         case DeprMethodTypeEnum.DeclBalHalfYear:
         case DeprMethodTypeEnum.DeclBalHalfYearSwitch:
              return 13;
         case DeprMethodTypeEnum.SumOfTheYearsDigits:
              return 14;
         case DeprMethodTypeEnum.SumOfTheYearsDigitsHalfYear:
              return 15;
         case DeprMethodTypeEnum.SumOfTheYearsDigitsModHalfYear:
              return 16;
         case DeprMethodTypeEnum.RemValueOverRemLife:
              return 17;
         case DeprMethodTypeEnum.OwnDepreciationCalculation:
              return 18;
         case DeprMethodTypeEnum.DoNotDepreciate:
              return 19;
         case DeprMethodTypeEnum.CustomMethod:
              return 20;
         case DeprMethodTypeEnum.RepeatTheTaxBookMethod:
              return 21;
         case DeprMethodTypeEnum.MACRSIndianReservation:
         case DeprMethodTypeEnum.MACRSIndianReservation30:
              return 22;

         case DeprMethodTypeEnum.MacrsFormula30:
              return 23;

         default:
              return 0;
         }
    }
       private uint encodeDdbPct(uint ddbPct)
       {
           switch (ddbPct)
           {
               case 150:
                   return 1;
               case 200:
                   return 2;
               case 125:
                   return 3;
               case 175:
                   return 4;
               case 100:
                   return 5;
               default:
                   return 0;
           }
       }
       private uint encodeEstLife(short estLife)
       {
           switch (estLife / 100)
           {
               case 3:
                   return 2;
               case 5:
                   return 3;
               case 7:
                   return 4;
               case 10:
                   return 5;
               case 15:
                   return 6;
               case 20:
                   return 7;
               // 97.1 Tax Update -- added for new 25-year property  MJB  12/3/96
               case 25:
                   return 8;
               default:
                   return 1;
           }
       }

    }
}
