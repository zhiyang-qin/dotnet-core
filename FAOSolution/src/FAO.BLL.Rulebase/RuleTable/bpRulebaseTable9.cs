using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable9
    {
       public  bpRulebaseTable9() { }

       public  uint                tableNumber() 
                                  { return 9; }

        public ulong               buildSourceCode( short propType,
                                              short deprMethod,
                                              bool hasBeginningDate)
       {
           ulong key = 0L;

           key += (ulong)encodePropType(propType) * 10000L;

           key += (ulong)encodeDeprMethod(deprMethod) * 100L;

           key += (ulong)encodeBegDate(hasBeginningDate);

           return key;
       }


       public  virtual bool        isObjectOk()
                                  { return true; }

        private uint      encodePropType( short propType )
    {
        switch ((PropertyTypeEnum)(propType))
         {
         case PropertyTypeEnum.Automobile:
         case PropertyTypeEnum.PersonalGeneral:
         case PropertyTypeEnum.PersonalListed:
         case PropertyTypeEnum.Depreciable:
         case PropertyTypeEnum.LtTrucksAndVans:
              return 1;
         default:
              return 2;
         }
    }
        private uint      encodeDeprMethod( short deprMethod )
    {
        switch ((DeprMethodTypeEnum)(deprMethod))
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
        private uint encodeBegDate(bool hasBeginningDate)
        {
            // Check for a VALID date.  If valid, return a 1 else return a 2.
            // To make an INVALID date, set the beginning date to 0,0,0 upon
            // creation of "beginningDate".  This will be interpreted as an invalid
            // date.  Any other invalid date value (like 100 days in a month) is
            // also acceptable.
            if (hasBeginningDate)
                return 1;
            else
                return 2;
        }
    }
}
