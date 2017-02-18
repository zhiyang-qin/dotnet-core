using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable15
    {
      public   bpRulebaseTable15() { }

     public    uint                tableNumber() 
                                  { return 15; }

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

      public   bool                isObjectOk() 
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
           DateTime testDate = new DateTime(1972,7, 30 );

           if (pisDate < testDate)
               return 1;
           else
               return 2;
       }

       private  uint                encodeDeprMethod( short deprMethod )
    {
    switch( (DeprMethodTypeEnum)(deprMethod) )
         {
         case DeprMethodTypeEnum.StraightLine:
              return 1;
         case DeprMethodTypeEnum.StraightLineFullMonth:
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
         default:
              return 0;
         }
    }
       private uint encodeDdbPct(uint ddbPct)
       {
           switch (ddbPct)
           {
               case 100:
                   return 1;
               case 125:
                   return 2;
               case 150:
                   return 3;
               case 175:
                   return 4;
               case 200:
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
                   return 1;
               case 5:
                   return 2;
               case 7:
                   return 3;
               case 10:
                   return 4;
               case 15:
                   return 5;
               case 18:
                   return 6;
               case 19:
                   return 7;
               case 20:
                   return 8;
               case 27:
                   if (estLife % 100 == 6)
                       return 9;
                   else
                       return 11;
               case 31:
                   if (estLife % 100 == 6)
                       return 10;
                   else
                       return 11;
               default:
                   return 11;
           }
       }
    }
}
