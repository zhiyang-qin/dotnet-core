using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable6
    {
       public  bpRulebaseTable6() { }

       public  uint                tableNumber() 
                                  { return 6; }

       public  ulong               buildSourceCode( DateTime pisDate,
                                              short deprMethod)
       {
           ulong key = 0L;

           key += (ulong)encodeDeprMethod(deprMethod) * 100L;

           key += (ulong)encodePisDate(pisDate);

           _handleEnergyBillITCOptions(ref key, pisDate, deprMethod);
           return key;
       }

       public  virtual bool        isObjectOk()
                                  { return true; }

       private  uint      encodeDeprMethod( short deprMethod )
    {
        switch ((DeprMethodTypeEnum)(deprMethod))
         {
         case DeprMethodTypeEnum.MacrsFormula: //MF
         case DeprMethodTypeEnum.MacrsFormula30://MA Liberty 
              return 1;
         case DeprMethodTypeEnum.MacrsTable://MT
              return 2;
         case DeprMethodTypeEnum.AdsSlMacrs://AD
         case DeprMethodTypeEnum.AdsSlMacrs30://AA //
              return 3;
         case DeprMethodTypeEnum.AcrsTable:
              return 4;
         case DeprMethodTypeEnum.StraightLineAltAcrsFormula:
         case DeprMethodTypeEnum.StraightLineAltAcrsTable:
              return 6;
         case DeprMethodTypeEnum.DeclBal:
         case DeprMethodTypeEnum.DeclBalHalfYear:
         case DeprMethodTypeEnum.DeclBalModHalfYear:
         case DeprMethodTypeEnum.DeclBalSwitch:
         case DeprMethodTypeEnum.DeclBalHalfYearSwitch:
         case DeprMethodTypeEnum.DeclBalModHalfYearSwitch:
              return 10;
         case DeprMethodTypeEnum.OwnDepreciationCalculation:
              return 15;
         case DeprMethodTypeEnum.DoNotDepreciate:
              return 16;
         case DeprMethodTypeEnum.StraightLine:
         case DeprMethodTypeEnum.StraightLineFullMonth:
         case DeprMethodTypeEnum.StraightLineFullMonth30:
         case DeprMethodTypeEnum.StraightLineHalfYear:
         case DeprMethodTypeEnum.StraightLineModHalfYear:
         case DeprMethodTypeEnum.RemValueOverRemLife:
              return 17;
         case DeprMethodTypeEnum.SumOfTheYearsDigits:
         case DeprMethodTypeEnum.SumOfTheYearsDigitsHalfYear:
         case DeprMethodTypeEnum.SumOfTheYearsDigitsModHalfYear:
              return 19;
         case DeprMethodTypeEnum.CustomMethod:
              return 20;
         case DeprMethodTypeEnum.MACRSIndianReservation://MI
         case DeprMethodTypeEnum.MACRSIndianReservation30: //MR Liberty 
              return 21;
         default:
              return 0;
         }
    }
       private uint encodePisDate(DateTime pisDate)
       {
           DateTime julianPisDate = pisDate.Date;

           if (julianPisDate < new DateTime(1980, 1, 1))
               return 1;
           else
               if (julianPisDate <= new DateTime(1980, 12, 31))
                   return 2;
               else
                   if (julianPisDate <= new DateTime(1981, 12, 31))
                       return 3;
                   else
                       if (julianPisDate <= new DateTime(1982, 12, 31))
                           return 4;
                       else
                           if (julianPisDate <= new DateTime(1985, 12, 31))
                               return 5;
                           else
                               if (julianPisDate <= new DateTime(1986, 7, 31))
                                   return 6;
                               else
                                   if (julianPisDate <= new DateTime(1986, 12, 31))
                                       return 7;
                                   else
                                       if (julianPisDate <= new DateTime(1987, 12, 31))
                                           return 8;
                                       else
                                           if (julianPisDate <= new DateTime(1989, 12, 31))
                                               return 9;
                                           else
                                               if (julianPisDate <= new DateTime(1990, 9, 30))
                                                   return 10;
                                               else
                                                   if (julianPisDate <= new DateTime(1992, 6, 30))
                                                       return 11;
                                                   else
                                                       if (julianPisDate <= new DateTime(1993, 12, 31))//Indian Reservation Band 
                                                           return 17;
                                                       else
                                                           if (julianPisDate <= new DateTime(2001, 9, 10))//Liberty Zone band
                                                               return 16;
                                                           else
                                                               if (julianPisDate <= new DateTime(2005, 8, 7))
                                                                   return 12;
                                                               else
                                                                   if (julianPisDate <= new DateTime(2005, 12, 31))
                                                                       return 13;
                                                                   else
                                                                       if (julianPisDate <= new DateTime(2016, 12, 31))
                                                                           return 14;
                                                                       else
                                                                           if (julianPisDate <= new DateTime(2023, 12, 31))
                                                                               return 18;
                                                                           else 
                                                                               return 15;
       }
		private void      _handleEnergyBillITCOptions(ref ulong key, DateTime pisDate, short deprMethod)
{
    DateTime julianPisDate = pisDate.Date;

	// ACQ, EFP is not valid after 1/1/2006
    switch ((DeprMethodTypeEnum)(deprMethod))
    {
         case DeprMethodTypeEnum.MacrsFormula: //MF
         case DeprMethodTypeEnum.MacrsFormula30://MA Liberty 
         case DeprMethodTypeEnum.MacrsTable://MT
         case DeprMethodTypeEnum.AdsSlMacrs://AD
         case DeprMethodTypeEnum.AdsSlMacrs30://AA //
         case DeprMethodTypeEnum.AcrsTable: // AT
         case DeprMethodTypeEnum.StraightLineAltAcrsFormula: // SA
         case DeprMethodTypeEnum.StraightLineAltAcrsTable: // ST
         case DeprMethodTypeEnum.MACRSIndianReservation://MI
         case DeprMethodTypeEnum.MACRSIndianReservation30: //MR Liberty 
		 case DeprMethodTypeEnum.OwnDepreciationCalculation: // OC
             if (new DateTime(2008, 10, 3) <= julianPisDate && julianPisDate <= new DateTime(2009,2, 17 ))
			{
				key += 10;
			}
             else if (new DateTime(2009, 2, 18) <= julianPisDate && julianPisDate <= new DateTime(2015,8, 17 ))
			{
				key += 11;
			}
             else if (new DateTime(2015, 8, 18) <= julianPisDate && julianPisDate <= new DateTime(2016,12, 31 ))
			{
				key += 10;
			}
			break;
		 default:
			break;
	}
}

    }
}
