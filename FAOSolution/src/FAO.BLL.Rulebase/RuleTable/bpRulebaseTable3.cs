using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable3
    {
       public  bpRulebaseTable3() { }

       public  uint                tableNumber() 
                                  { return 3; }

       public  ulong               buildSourceCode( short propType,
                                              DateTime pisDate,
                                              short deprMethod)
       {
           ulong key = 0L;

           key += (ulong)encodePropType(propType) * 10000L;

           key += (ulong)encodePisDate(pisDate) * 100L;

           key += (ulong)encodeDeprMethod(deprMethod);

           specialHandling(ref key, pisDate, propType);

           specialHandlingFor2013HR8(ref key, pisDate, propType);

           return key;
       }

       public  bool                isObjectOk()
                                  { return true; }

       private  uint      encodePropType( short propType )
    {
        switch ((PropertyTypeEnum)(propType))
         {
         case PropertyTypeEnum.Automobile:
         case PropertyTypeEnum.LtTrucksAndVans:
              return 1;
         case PropertyTypeEnum.PersonalGeneral:
              return 2;
         case PropertyTypeEnum.PersonalListed:
              return 3;
         case PropertyTypeEnum.VintageAccount:
              return 4;
         case PropertyTypeEnum.Amortizable:
              return 5;
         case PropertyTypeEnum.RealConservation:
              return 6;
         case PropertyTypeEnum.RealEnergy:
              return 7;
         case PropertyTypeEnum.RealFarms:
              return 8;
         case PropertyTypeEnum.RealGeneral:
              return 9;
         case PropertyTypeEnum.RealListed:
              return 10;
         case PropertyTypeEnum.RealLowIncomeHousing:
              return 11;
         case PropertyTypeEnum.Depreciable:
			  return 12;
         case PropertyTypeEnum.NonDepreciable:
			  return 13;
         default:
              return 0;
         }
    }
       private uint encodeDeprMethod(short deprMethod)
    {
        switch ((DeprMethodTypeEnum)(deprMethod))
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
         case DeprMethodTypeEnum.AdsSlMacrs30:
              return 23;
         case DeprMethodTypeEnum.MACRSIndianReservation30:
              return 24;
         case DeprMethodTypeEnum.StraightLineFullMonth30:
              return 25;
         default:
              return 0;
         }
    }
       private uint encodePisDate(DateTime pisDate)
       {
           uint date_code;
           DateTime julianPisDate = pisDate.Date;

           if (julianPisDate < new DateTime(1980,1, 1 ))
               date_code = 1;
           else
               if (julianPisDate <= new DateTime(1980,12, 31 ))
                   date_code = 2;
               else
                   if (julianPisDate <= new DateTime(1984,6, 18 ))
                       date_code = 3;
                   else
                       if (julianPisDate <= new DateTime(1986,7, 31 ))
                           date_code = 4;
                       else
                           if (julianPisDate <= new DateTime(1986,12, 31 ))
                               date_code = 5;
                           else
                               if (julianPisDate <= new DateTime(1993,12, 31 ))
                                   date_code = 6;
                               else
                                   if (julianPisDate <= new DateTime(1998,12, 31 ))
                                       date_code = 7;
                                   else
                                       if (julianPisDate <= new DateTime(2001,9, 10 ))
                                           date_code = 8;
                                       else
                                           if (julianPisDate <= new DateTime(2004,12, 31 ))
                                               date_code = 9;
                                           else
                                               if (julianPisDate <= new DateTime(2005,8, 27 ))
                                                   date_code = 10;
                                               else
                                                   if (julianPisDate <= new DateTime(2011,12, 31 )) //GSD 2011.1
                                                       date_code = 11;
                                                   else
                                                       if (julianPisDate <= new DateTime(2012,12, 31 ))
                                                           date_code = 12;
                                                       else
                                                           date_code = 13;
           return date_code;
       }
		private void	   specialHandling(ref ulong key, DateTime pisDate, short propType)
{
    DateTime julianPisDate = pisDate.Date;

	if( ((PropertyTypeEnum)(propType)) == PropertyTypeEnum.RealConservation ||
		((PropertyTypeEnum)(propType)) == PropertyTypeEnum.RealEnergy ||
		((PropertyTypeEnum)(propType)) == PropertyTypeEnum.RealFarms ||
		((PropertyTypeEnum)(propType)) == PropertyTypeEnum.RealGeneral ||
		((PropertyTypeEnum)(propType)) == PropertyTypeEnum.RealListed )
	{
        if (julianPisDate >= new DateTime(2013, 1, 1) && julianPisDate <= new DateTime(2013,12, 31 ))
		{
			key -= 100L;
		}
	}
}
        private void specialHandlingFor2013HR8(ref ulong key, DateTime pisDate, short propType)
        {
            DateTime julianPisDate = pisDate.Date;

            // when day code is 13 that is after 2012
            //GSD_2016.1 - have to move SB to its own because it no longer has the same dates
            if (key == 11321 || key == 21321 || key == 31321 ||		// MI
                key == 11324 || key == 21324 || key == 31324)		// MR
            {
                // for 2013 the MI, MR and SB become available then need a different day code
                if (julianPisDate >= new DateTime(2013, 1, 1) && julianPisDate <= new DateTime(2016, 12, 31))   // GSD_2016.1
                {
                    key = key + 1000;
                }
            }

            //GSD_2016.1 - have to move SB to its own because it no longer has the same dates
            if (key == 11325 || key == 21325 || key == 31325)		// SB
            {
                // for 2013 the SB become available then need a different day code
                if (julianPisDate >= new DateTime(2013, 1, 1) && julianPisDate <= new DateTime(2019, 12, 31))   // GSD_2016.1
                {
                    key = key + 1000;
                }
            }

            if (key == 61221 || key == 71221 || key == 81221 || key == 91221 || key == 101221)		// MI
            {
                key = key - 100;
            }

            if (key == 61321 || key == 71321 || key == 81321 || key == 91321 || key == 101321)	    // MI
            {
                key = key - 200;
            }

            if (key == 61324 || key == 71324 || key == 81324 || key == 91324 || key == 101324)		// MR
            {
                key = key - 100;
            }

            if (key == 61322 || key == 71322 || key == 81322 || key == 91322 || key == 101322 ||		// AA
                key == 61323 || key == 71323 || key == 81323 || key == 91323 || key == 101323)		// MA
            {
                // for 2013 the MI, MR and SB become available then need a different day code
                if (julianPisDate >= new DateTime(2014, 1, 1) && julianPisDate <= new DateTime(2020, 12, 31))   //GSD_2016.1
                {
                    key = key + 2000;
                }
            }
        }
   }
}
