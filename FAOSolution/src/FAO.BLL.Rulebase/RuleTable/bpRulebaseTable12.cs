using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable12
    {
      public   bpRulebaseTable12() { }

      public   uint                tableNumber() 
                                  { return 12; }

       public  ulong               buildSourceCode( short propType,
                                              short deprMethod,
                                              uint ddbPct,
                                              short estLife,
                                              short classLife)
      {
          ulong key = 0L;

          key += (ulong)encodePropType(propType) * 1000000L;

          key += (ulong)encodeDeprMethod(deprMethod) * 10000L;

          key += (ulong)encodeDdbPct(ddbPct) * 1000L;

          key += (ulong)encodeEstLife(estLife) * 10L;

          key += (ulong)encodeClassLife(classLife);

          return key;
      }


      public   virtual bool        isObjectOk()
                                  { return true; }

       private  uint                encodePropType( short propType )
    {
        switch ((PropertyTypeEnum)(propType))
         {
         case PropertyTypeEnum.PersonalGeneral:
         case PropertyTypeEnum.PersonalListed:
         case PropertyTypeEnum.Depreciable:
              return 1;

         case PropertyTypeEnum.RealGeneral:
         case PropertyTypeEnum.RealEnergy:
         case PropertyTypeEnum.RealFarms:
         case PropertyTypeEnum.RealConservation:
         case PropertyTypeEnum.RealListed:
         case PropertyTypeEnum.NonDepreciable:
              return 2;

         case PropertyTypeEnum.Automobile:
         case PropertyTypeEnum.LtTrucksAndVans:
              return 3;

         case PropertyTypeEnum.RealLowIncomeHousing:
              return 4;

         case PropertyTypeEnum.VintageAccount:
              return 5;

         case PropertyTypeEnum.Amortizable:
              return 6;

         default:
              return 0;
         }
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
         case DeprMethodTypeEnum.MACRSIndianReservation:
         case DeprMethodTypeEnum.MacrsFormula:
         case DeprMethodTypeEnum.MACRSIndianReservation30:
         case DeprMethodTypeEnum.MacrsFormula30:
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
         default:
              return 0;
         }
    }
       private uint encodeDdbPct(uint ddbPct)
       {
           switch (ddbPct)
           {
               case 150:
                   return 2;
               case 200:
                   return 3;
               case 125:
                   return 4;
               case 175:
                   return 5;
               case 100:
                   return 6;
               default:
                   return 1;
           }
       }
       private uint encodeEstLife(short estLife)
       {
           switch (estLife / 100)
           {
               case 2:
               case 3:
                   return 1;
               case 5:
                   return 2;
               case 4:
               case 7:
                   return 3;
               case 6:
               case 10:
                   return 4;
               case 9:
               case 15:
                   return 5;
               case 18:
                   return 6;
               case 19:
                   return 7;
               case 12:
               case 20:
                   return 8;
               case 27:
                   if (estLife % 100 == 6)
                       return 9;
                   else
                       return 12;
               case 31:
                   if (estLife % 100 == 6)
                       return 10;
                   else
                       return 12;

               default:
                   return 12;
           }
       }
       private uint encodeClassLife(short classLife)
       {
           // If class life exists and is valid, return a '1'.  If not, return
           // a '2'.
           if (classLife != 0 && classLife % 100 >= 0 && classLife % 100 < 13 &&
                classLife / 100 > 0 && classLife / 100 < 100)
               return 1;
           else
               return 2;
       }
    }
}
