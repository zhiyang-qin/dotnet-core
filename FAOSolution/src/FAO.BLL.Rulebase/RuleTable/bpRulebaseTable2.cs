using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable2
    {
       public  bpRulebaseTable2() { }

      public   uint                tableNumber() 
                                  { return 2; }

      public   ulong               buildSourceCode( short propType,
                                              DateTime pisDate)
      {
          ulong key = 0L;

          key += (ulong)encodePropType(propType) * 100L;

          key += (ulong)encodePisDate(pisDate);

          return key;
      }

       public  bool                isObjectOk()
                                  { return true; }

       private  uint      encodePropType( short propType )
    {
        switch ((PropertyTypeEnum)(propType))
         {
         case PropertyTypeEnum.PersonalGeneral:
              return 1;
         case PropertyTypeEnum.PersonalListed:
              return 2;
         case PropertyTypeEnum.Automobile:
              return 3;
         case PropertyTypeEnum.Amortizable:
              return 4;
         case PropertyTypeEnum.RealGeneral:
              return 5;
         case PropertyTypeEnum.RealLowIncomeHousing:
              return 6;
         case PropertyTypeEnum.RealFarms:
              return 7;
         case PropertyTypeEnum.RealEnergy:
              return 8;
         case PropertyTypeEnum.RealConservation:
              return 9;
         case PropertyTypeEnum.RealListed:
              return 10;
         case PropertyTypeEnum.VintageAccount:
              return 11;
         case PropertyTypeEnum.Depreciable:
			  return 12;
         case PropertyTypeEnum.NonDepreciable:
			  return 13;
         case PropertyTypeEnum.LtTrucksAndVans:
              return 14;
         default:
              return 0;
         }
    }
       private uint encodePisDate(DateTime pisDate)
       {
           uint date_code;
           DateTime julianPisDate = pisDate.Date;

           if (julianPisDate < new DateTime(1981,1, 1 ))
               date_code = 1;
           else
               if (julianPisDate <= new DateTime(1984,6, 18 ))
                   date_code = 2;
               else
                   if (julianPisDate <= new DateTime(1986,12, 31 ))
                       date_code = 3;
                   else
                       if (julianPisDate <= new DateTime(2002,12, 31 ))
                           date_code = 4;
                       else
                           date_code = 5;

           return date_code;
       }
    }
}
