using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable8
    {
     public    bpRulebaseTable8() { }

      public   uint                tableNumber() 
                                  { return 8; }

       public  ulong               buildSourceCode( short propType,
                                              DateTime pisDate,
                                              short deprMethod,
                                              short estLife)
      {
          ulong key = 0L;

          key += (ulong)encodePropType(propType) * 1000000L;

          key += (ulong)encodePisDate(pisDate, propType) * 10000; //GSD 2011.1

          key += (ulong)encodeDeprMethod(deprMethod) * 100L;

          key += (ulong)encodeEstLife(estLife);

          return key;
      }

      public   virtual bool        isObjectOk()
                                  { return true; }

       private  uint      encodePropType( short propType )
    {
    switch( (PropertyTypeEnum)(propType) )
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
         case PropertyTypeEnum.RealConservation: // "C"
              return 6;
         case PropertyTypeEnum.RealEnergy: // "E"
              return 7;
         case PropertyTypeEnum.RealFarms: // "F"
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
       private  uint      encodePisDate( DateTime pisDate, short propType ) //GSD 2011.1
    {
    DateTime julianPisDate = pisDate.Date;
    PropertyTypeEnum pType = (PropertyTypeEnum)(propType); //GSD 2011.1


    if (julianPisDate <= new DateTime(1980,12, 31 ))
         return 1;
    else
        if (julianPisDate <= new DateTime(1986,7, 31 ))
         return 2;
    else
            if (julianPisDate <= new DateTime(1986,12, 31 ))
         return 3;
	
	//GSD 2015.1 - extend through 2014
	//GSD 2011.1
    // KL 2016.1
    if ( (pType == PropertyTypeEnum.RealConservation || 
		  pType == PropertyTypeEnum.RealEnergy || 
		  pType == PropertyTypeEnum.RealFarms ) &&
        (new DateTime(2010,1, 1 ) <= julianPisDate && julianPisDate <= new DateTime(2999, 12, 31)))
	         return 5;
    else
         return 4;
    }

        private uint      encodeDeprMethod( short deprMethod )
    {
        switch ((DeprMethodTypeEnum)(deprMethod))
         {
         case DeprMethodTypeEnum.MacrsFormula: //"MF"
         case DeprMethodTypeEnum.MacrsFormula30: //"MA"
              return 1;
         case DeprMethodTypeEnum.MacrsTable: //"MT"
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
         case DeprMethodTypeEnum.MACRSIndianReservation: //"MI"
         case DeprMethodTypeEnum.MACRSIndianReservation30: //"MR"
              return 21;
         default:
              return 0;
         }
    }
        private uint encodeEstLife(short estLife)
        {
            if (estLife / 100 < 6)
                return 1;
            else
                return 2;
        }

    }
}
