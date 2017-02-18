using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable13
    {
       public  bpRulebaseTable13()      { }

       public  uint                tableNumber() 
                                  { return 13; }

       public  ulong               buildSourceCode( DateTime fyEnd120189,
                                              short propType,
                                              DateTime pisDate,
                                              short deprMethod,
                                              short deprPct,
                                              short estLife)
       {
           ulong key = 0L;

           key += (ulong)encodePropType(propType) * 100000000L;

           key += (ulong)encodePlacedInService(fyEnd120189, pisDate) * 1000000L;

           key += (ulong)encodeDeprMethod(deprMethod) * 10000L;

           key += (ulong)encodeDdbPct((uint)deprPct) * 100L;

           key += (ulong)encodeEstLife(estLife);

           return key;
       }

        public virtual bool        isObjectOk()
                                  { return true; }

       private  uint      encodePropType( short propType )
    {
    switch( (PropertyTypeEnum)propType )
         {
         case PropertyTypeEnum.PersonalGeneral:
         case PropertyTypeEnum.PersonalListed:
         case PropertyTypeEnum.VintageAccount:
         case PropertyTypeEnum.Amortizable:
         case PropertyTypeEnum.Depreciable:
              return 1;

         case PropertyTypeEnum.RealGeneral:
         case PropertyTypeEnum.RealEnergy:
         case PropertyTypeEnum.RealFarms:
         case PropertyTypeEnum.RealConservation:
         case PropertyTypeEnum.RealListed:
         case PropertyTypeEnum.RealLowIncomeHousing:
         case PropertyTypeEnum.NonDepreciable:
              return 2;

         case PropertyTypeEnum.Automobile:
         case PropertyTypeEnum.LtTrucksAndVans:
              return 3;

         default:
              return 0;
         }
    }
       private  uint      encodeDeprMethod( short deprMethod )
    {
        switch ((DeprMethodTypeEnum)deprMethod)
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
                   return 1;
               case 5:
                   return 2;
               case 7:
                   return 3;
               case 10:
                   return 4;
               case 15:
                   return 5;
               case 20:
                   return 6;
               // 97.1 Tax Update -- added for 25-year property MJB  12/3/96
               case 25:
                   return 7; ;
               default:
                   return 10;
           }
       }
       private uint encodePlacedInService(DateTime fyEnd120189, DateTime pisDate)
       {
           if (pisDate < fyEnd120189)
               return 0;
           else
               return 1;
       }

    }
}
