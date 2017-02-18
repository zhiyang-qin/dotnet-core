using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable5
    {

        public bpRulebaseTable5() { }

        public uint tableNumber() { return 5; }

        public ulong buildSourceCode(short propType, DateTime pisDate,
                                         short deprMethod,
                                         uint ddbPct)
        {
            ulong key = 0L;

            key += (ulong)_encodePropType(propType) * 1000000L;

            key += (ulong)_encodePisDate(pisDate) * 10000L;

            key += (ulong)_encodeDeprMethod(deprMethod) * 100L;

            key += (ulong)_encodeDdbPct(ddbPct);

            _handle94Exception(ref key, pisDate);

            _handleMF100Exception(ref key, pisDate);

            _handleJOBSAct2004Exception(ref key, pisDate);

            //GSD 2011.1
            _handleDefaultEstLifeForSF(ref key, pisDate);

            _specialHandlingFor2013HR8(ref key, pisDate);

            return key;
        }


        public bool isObjectOk() { return true; }

uint _encodePropType( short propType )
    {
            switch ((PropertyTypeEnum)propType)
         {
         case PropertyTypeEnum.Automobile:
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
         case PropertyTypeEnum.LtTrucksAndVans:
              return 14;
	     default:
              return 0;
         }
    }

/*--------------------------------------------------------------------------*/

uint _encodePisDate(DateTime pisDate)
    {
        uint date_code;

    // Now add the datecode into the key.
    if ( pisDate.Date < new DateTime(1981, 1,1 ) )
         date_code = 1;
    else
    if ( pisDate.Date <= new DateTime(1984, 3,15 ) )
         date_code = 2;
    else
    if ( pisDate.Date <= new DateTime(1984, 6,18 ) )
         date_code = 3;
    else
    if ( pisDate.Date <= new DateTime(1985, 5,8 ) )
         date_code = 4;
    else
    if ( pisDate.Date <= new DateTime(1986, 7,31 ) )
         date_code = 5;
    else
    if ( pisDate.Date <= new DateTime(1986, 12,31 ) )
         date_code = 6;
    else
    if ( pisDate.Date <= new DateTime(1993, 12,31 ) )
         date_code = 7;
    else
    if ( pisDate.Date <= new DateTime(1996, 6,12 ) )
         date_code = 9;
    else
    if ( pisDate.Date <= new DateTime(1998, 12,31 ) )
         date_code = 10;
    else
    if ( pisDate.Date <= new DateTime(2012, 12,31 ) )
         date_code = 11;
    else
         date_code = 12;

    return date_code;
    }

/*--------------------------------------------------------------------------*/

uint _encodeDeprMethod( short deprMethod )
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
         case DeprMethodTypeEnum.MACRSIndianReservation30:
              return 21;

         case DeprMethodTypeEnum.MacrsFormula30:
              return 22;
         case DeprMethodTypeEnum.AdsSlMacrs30:
              return 23;
         case DeprMethodTypeEnum.StraightLineFullMonth30:
              return 24;
         default:
              return 0;
         }
    }

/*--------------------------------------------------------------------------*/

uint _encodeDdbPct( uint ddbPct )
    {
    switch( ddbPct )
         {
         case 125:
              return 1;
         case 150:
              return 2;
         case 175:
              return 3;
         case 200:
              return 4;
         case 100:
              return 5;
         default:
              return 0;
         }
    }

/*--------------------------------------------------------------------------*/

void _handle94Exception( ref ulong key,DateTime pisDate )
    {
    if ( pisDate.Date >  new DateTime(1993, 05,12 ) )    
        {
        if ( //key ==  6070202L ||   //  MACRS Table   Real Property, Conservation
             //key ==  7070202L ||   //  MACRS Table   Real Property, Energy
             //key ==  8070202L ||   //  MACRS Table   Real Property, Farms
             //key ==  9070202L ||   //  MACRS Table   Real Property, General
             //key == 10070202L ||   //  MACRS Table   Real Property, Listed
             key ==  6070105L ||   //  MACRS Formula Real Property, Conservation
             key ==  6070205L ||   //  MACRS Table   Real Property, Conservation
             key ==  7070105L ||   //  MACRS Formula Real Property, Energy
             key ==  7070205L ||   //  MACRS Table   Real Property, Energy
             key ==  8070105L ||   //  MACRS Formula Real Property, Farms
             key ==  8070205L ||   //  MACRS Table   Real Property, Farms
             key ==  9070105L ||   //  MACRS Formula Real Property, General
             key ==  9070205L ||   //  MACRS Table   Real Property, General
             key == 10070105L ||   //  MACRS Formula Real Property, Listed
             key == 10070205L )    //  MACRS Table   Real Property, Listed

             key += 10000L;
        } 

    }

// Handle the exception of MF100 with est life is 5 yr 00 mon only available between 9/11/2001 and 12/31/2006
void _handleMF100Exception( ref ulong key,DateTime pisDate )
    {
    if ( pisDate.Date >  new DateTime(2006, 12,31 ) || 
		 pisDate.Date <  new DateTime(2001,  9,11 )  )    
        {
        if ( key ==  6110105L ||
			 key ==  7110105L ||
			 key ==  8110105L ||
			 key ==  9110105L ||
			 key == 10110105L )    //  MACRS Table   Real Property

             key += 10000L;
        } 

    if ( pisDate.Date > new DateTime(2011,  12,31) ) //&& pisDate.Date < new DateTime(2013, 1,1 )  )    
        {
        if ( key ==  6120105L ||
			 key ==  7120105L ||
			 key ==  8120105L ||
			 key ==  9120105L ||
			 key == 10120105L )    //  MACRS Table   Real Property

             key += 20000L;
        } 

    }

// Handle the exception of MF100 with est life is 15 yr 00 mon only available between 10/22/2001 and 12/31/2005
void _handleJOBSAct2004Exception( ref ulong key,DateTime pisDate )
{
	//FM 02/02/2006: extend this rule 1 more year per Kim and Mary
    if ( pisDate.Date >  new DateTime(2004, 10,22 ) && 
		 pisDate.Date <  new DateTime( 2009 ,1,1 )  )    
    {
        if ( (key ==  6110105L || key ==  7110105L || key ==  8110105L || key ==  9110105L || key == 10110105L) ||
			 (key ==  6112205L || key ==  7112205L || key ==  8112205L || key ==  9112205L || key == 10112205L) || 
			 (key ==  6112105L || key ==  7112105L || key ==  8112105L || key ==  9112105L || key == 10112105L) ||

			 (key ==  6120105L || key ==  7120105L || key ==  8120105L || key ==  9120105L || key == 10120105L) ||
			 (key ==  6122205L || key ==  7122205L || key ==  8122205L || key ==  9122205L || key == 10122205L) ||
			 (key ==  6122105L || key ==  7122105L || key ==  8122105L || key ==  9122105L || key == 10122105L) )

             key += 100000L;

		if ( pisDate.Date >= new DateTime(2008, 1,1 ) && pisDate.Date < new DateTime(2009, 1,1 ) )
		{
			// for those whith code = 102, because not include the 5 yrs. we need another code 105
			if ( (key ==  6210105L || key ==  7210105L || key ==  8210105L || key ==  9210105L || key == 10210105L) ||
				 (key ==  6220105L || key ==  7220105L || key ==  8220105L || key ==  9220105L || key == 10220105L) )
	             key += 100000L;
		}

    } 
	//GSD 2011.1 - updated date range
	// 2009.1 tax update
    if ( pisDate.Date >=  new DateTime(2009, 1,1 ) && pisDate.Date <  new DateTime(2011, 1,1 )  ) 
	{

		if (key ==  6112105L || key ==  7112105L || key ==  8112105L || key ==  9112105L || key == 10112105L)
			key += 100000L;
		if (key ==  6112205L || key ==  7112205L || key ==  8112205L || key ==  9112205L || key == 10112205L) 
			key += 100000L;
		if (key ==  6120105L || key ==  7120105L || key ==  8120105L || key ==  9120105L || key == 10120105L)
			key += 200000L;
	}
	// 2011.1 tax update
    if ( pisDate.Date >=  new DateTime(2011,  1,1) && pisDate.Date <  new DateTime(2012, 1,1 )  ) 
	{

		if (key ==  6112105L || key ==  7112105L || key ==  8112105L || key ==  9112105L || key == 10112105L)
			key += 100000L;
		if (key ==  6112205L || key ==  7112205L || key ==  8112205L || key ==  9112205L || key == 10112205L) 
			key += 100000L;
		if (key ==  6120105L || key ==  7120105L || key ==  8120105L || key ==  9120105L || key == 10120105L)
			key += 200000L;
	}
	// for personal property
    if ( pisDate.Date >=  new DateTime(2013, 1,1 ) ) 
	{
		if (key == 2122205L || key == 2122204L || key == 2122203L || key == 2122202L || key == 2122201L ||
			key == 3122205L || key == 3122204L || key == 3122203L || key == 3122202L || key == 3122201L ||
			key == 2122400L || key == 2122300L || key == 3122400L || key == 3122300 )
			key -= 10000L;
	}
	// for real property
    if ( pisDate.Date >=  new DateTime(2013, 1,1 ) && pisDate.Date <=  new DateTime(2013, 12,31 )) 
	{
		if (key ==  6122205L || key ==  6122204L || key ==  6122203L || key ==  6122202L || key ==  6122201L ||
			key ==  7122205L || key ==  7122204L || key ==  7122203L || key ==  7122202L || key ==  7122201L ||
			key ==  8122205L || key ==  8122204L || key ==  8122203L || key ==  8122202L || key ==  8122201L ||
			key ==  9122205L || key ==  9122204L || key ==  9122203L || key ==  9122202L || key ==  9122201L ||
			key == 10122205L || key == 10122204L || key == 10122203L || key == 10122202L || key == 10122201L ||
			key ==  6122300L ||	key ==  7122300L ||	key ==  8122300L ||	key ==  9122300L ||	key == 10122300L ||
			key ==  6122400L ||	key ==  7122400L ||	key ==  8122400L ||	key ==  9122400L ||	key == 10122400L )
			key -=  10000L;
	}
	// for defect 5503
	if (pisDate.Date >=  new DateTime(2005, 8,28 ) && pisDate.Date <=  new DateTime(2011, 12,31 ))
	{
		if (key ==  6212205L || key ==  7212205L || key ==  8212205L || key ==  9212205L || key == 10212205L) 
			key += 100000L;
	}
}
//GSD 2011.1
void _handleDefaultEstLifeForSF( ref ulong key, DateTime pisDate )
{

    //GSD 11/13/12 - Defect 6000, extend out indefinitely the default for SF to 3 yrs
    if (pisDate.Date >= new DateTime(2010, 1, 1) )
    //if (pisDate.Date >= new DateTime(2010, 1, 1) && pisDate.Date <= new DateTime(2011, 12, 31)) 
	{
//KENT fix defect 4294
//can't use 2112400 for 2110900 and 3112400 for 3110900, their target code is 98
//and will lead to *EstLife = 300 in CbpRuleBase.GetDefaultEstimatedLife which is correct
//but *errorCode = WarnNotOver20Years in CbpRuleBase.ValidateEstimatedLife which is wrong
//we want the case 98 in CbpRuleBase.GetDefaultEstimatedLife
//and case 13 in CbpRuleBase.ValidateEstimatedLife
//then we need another target code -- change the date code from 11 to 99
		if (key ==  2110900L) 
			key = 2990900L;
		if (key ==  3110900L)
			key = 3990900L;


        //GSD 11/13/12 - add in dates post 2012 for SF
        if (key == 2120900L)
            key = 2990900L;
        if (key == 3120900L)
            key = 3990900L;
	}
}

void _specialHandlingFor2013HR8(ref ulong key, DateTime pisDate)
{
    //ULONG julianPisDate = DATETojday(pisDate);
    // update ma, aa, sb to 12/31/2013 for rscef
    if (key == 1122102L || key == 2122102L || key == 3122102L || key == 14122102L ||  //P MR MI 150
        key == 1122104L || key == 2122104L || key == 3122104L || key == 14122104L ||  //P MR MI 200
        key == 1122105L || key == 2122105L || key == 3122105L || key == 14122105L)   //P MR MI 100
    {
        if (pisDate >= new DateTime(2013, 1, 1) && pisDate <= new DateTime(2999, 12, 31))   // KL 2016.1
        {
            key = key - 10000L;
        }
    }
    if (key == 6122102L || key == 7122102L || key == 8122102L || key == 9122102L || key == 10122102L || //R MR MI 150
        key == 6122104L || key == 7122104L || key == 8122104L || key == 9122104L || key == 10122104L)  //R MR MI 200
    {
        if (pisDate >= new DateTime(2013, 1, 1) && pisDate <= new DateTime(2999, 12, 31))   // KL 2016.1
        {
            key = key - 10000L;
        }
    }
    if (key == 6112105L || key == 7112105L || key == 8112105L || key == 9112105L || key == 10112105L)
    {
        if (pisDate >= new DateTime(2012, 1, 1) && pisDate <= new DateTime(2012, 12, 31))
        {
            key += 100000L;
        }
    }
    if (key == 6122105L || key == 7122105L || key == 8122105L || key == 9122105L || key == 10122105L)  //R MR MI 100
    {
        if (pisDate >= new DateTime(2013, 1, 1) && pisDate <= new DateTime(2999, 12, 31))   // KL 2016.1
        {
            key = key + 100000L - 10000L;
        }
    }
    if (pisDate >= new DateTime(2014, 1, 1) && pisDate <= new DateTime(2999, 12, 31)) //R MA AA     // KL 2016.1
    {
        if (key == 6122205L || key == 6122204L || key == 6122203L || key == 6122202L || key == 6122201L ||
            key == 7122205L || key == 7122204L || key == 7122203L || key == 7122202L || key == 7122201L ||
            key == 8122205L || key == 8122204L || key == 8122203L || key == 8122202L || key == 8122201L ||
            key == 9122205L || key == 9122204L || key == 9122203L || key == 9122202L || key == 9122201L ||
            key == 10122205L || key == 10122204L || key == 10122203L || key == 10122202L || key == 10122201L ||
            key == 6122300L || key == 7122300L || key == 8122300L || key == 9122300L || key == 10122300L)
            key -= 10000L;
    }
}


    }

}
