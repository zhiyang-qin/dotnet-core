using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable10
    {

        public bpRulebaseTable10() { }

        public uint tableNumber() { return 10; }

        public ulong buildSourceCode(short propType, short deprMethod, DateTime pisDate)
        {
            ulong key = 0L;

            key += (ulong)encodeDeprMethod(deprMethod) * 10000L;

            key += (ulong)encodePropType(propType) * 100L;

            key += (ulong)encodePisDate(pisDate);


            return key;
        }


        public bool isObjectOk() { return true; }


uint encodeDeprMethod( short deprMethod )
    {
    switch( (DeprMethodTypeEnum) (deprMethod) )
         {
         case DeprMethodTypeEnum.MacrsFormula:
              return 1;
         case DeprMethodTypeEnum.MacrsTable:
              return 2;
         case DeprMethodTypeEnum.AdsSlMacrs:
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
              return 21;
         case DeprMethodTypeEnum.MacrsFormula30:
              return 22;
         case DeprMethodTypeEnum.MACRSIndianReservation30:
              return 23;
         default:
              return 0;
         }
    }

/*--------------------------------------------------------------------------*/


uint encodePropType( short propType )
    {
    switch( (PropertyTypeEnum) (propType) )
         {
//         case PropertyTypeEnum.Automobile:
         case PropertyTypeEnum.PersonalGeneral:
//         case PropertyTypeEnum.PersonalListed:
         case PropertyTypeEnum.VintageAccount:
         case PropertyTypeEnum.Amortizable:
              return 1;

         case PropertyTypeEnum.RealConservation:
         case PropertyTypeEnum.RealEnergy:
         case PropertyTypeEnum.RealFarms:
         case PropertyTypeEnum.RealLowIncomeHousing:
         case PropertyTypeEnum.RealGeneral:
         case PropertyTypeEnum.RealListed:
              return 2;

         case PropertyTypeEnum.Automobile:
         case PropertyTypeEnum.LtTrucksAndVans:
         case PropertyTypeEnum.PersonalListed:
              return 3;

         case PropertyTypeEnum.Depreciable:
         case PropertyTypeEnum.NonDepreciable:
              return 4;

		 default:
              return 0;
         }
    }

/*--------------------------------------------------------------------------*/

uint encodePisDate(DateTime pisDate)
    {
    uint date_code;

    if (pisDate.Date < new DateTime(1996,6, 13 ))
         date_code = 1;
    else
         date_code = 2;

    return date_code;
    }


    }

}
