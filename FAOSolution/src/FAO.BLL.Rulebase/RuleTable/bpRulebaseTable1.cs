using System;
using System.Collections.Generic;
using System.Text;
using FAO.BLL.BusinessTypes;

namespace FAO.BLL.Rulebase
{

    class bpRulebaseTable1
    {
        // Constants needed for placed in service date ranges.
        const int D_PRE_010180 = 1;
        const int D_PRE_123180 = 2;
        const int D_010180_123180 = 3;
        const int D_010181_123181 = 4;
        const int D_010181_123182 = 5;
        const int D_010182_123182 = 6;
        const int D_010183_123185 = 7;
        const int D_010183_050885 = 8;
        const int D_010183_123186 = 9;
        const int D_050985_123185 = 10;
        const int D_010186_123186 = 11;
        const int D_080186_123186 = 12;
        const int D_010187_123187 = 13;
        const int D_010187_123188 = 14;
        const int D_010188_123188 = 15;
        const int D_010188_123189 = 16;
        const int D_010188_AFTER = 17;
        const int D_010189_123189 = 18;
        const int D_010190_123190 = 19;
        const int D_010190_AFTER = 20;
        const int D_010191_AFTER = 21;
        const int D_010190_093090 = 22;
        const int D_100190_063092 = 23;
        const int D_010188_093090 = 24;
        const int D_070192_AFTER = 25;

        // Constants needed for estimated life values or ranges.
        const int L_0 = 1;
        const int L_3 = 3;
        const int L_5PLUS = 5;
        const int L_7PLUS = 7;
        const int L_15 = 15;
        const int L_15PLUS = 16;
        const int L_18 = 18;
        const int L_19 = 19;
        const int L_35 = 35;
        const int L_45 = 45;
        const int L_1_2 = 71;
        const int L_3_4 = 72;
        const int L_5_6 = 73;
        const int L_ALL = 74;


       public  bpRulebaseTable1() { }

       public  uint                tableNumber() 
                                  { return 1; }

        public ulong               buildSourceCode( short propType,
                                              DateTime pisDate,
                                              short deprMethod,
                                              short estLife,
                                              short itcOption)
       {
           ulong key, firstKey;
           uint value;

           value = encodeDeprMethod(deprMethod);
           firstKey = (ulong)value * 100;           // Start 4 digit key
           key = (ulong)value * 100000000L;         // Start 10 digit key

           value = encodePropType(propType);
           firstKey += (ulong)value;                // Finish 4 digit key
           key += (ulong)value * 1000000L;

           key += (ulong)encodePisDate((uint)firstKey, pisDate) * 10000L;
           key += (ulong)encodeITCOption(itcOption) * 100L;
           key += (ulong)encodeEstLife((uint)firstKey, pisDate, estLife);

           _handleEnergyBillITCOptions(ref key, pisDate, itcOption);

           return key;
       }

       public  bool        isObjectOk()
                                  { return true; }

      private   uint      encodeDeprMethod( short deprMethod )
    {
    switch( (DeprMethodTypeEnum)(deprMethod) )
         {
		 case DeprMethodTypeEnum.MacrsFormula:
         case DeprMethodTypeEnum.MacrsFormula30:
              return 1;
         case DeprMethodTypeEnum.MACRSIndianReservation:
         case DeprMethodTypeEnum.MACRSIndianReservation30:
         case DeprMethodTypeEnum.MacrsTable:
              return 2;
         case DeprMethodTypeEnum.AdsSlMacrs:
         case DeprMethodTypeEnum.AdsSlMacrs30:
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
         default:
              return 0;
         }
    }
       private  uint      encodePropType( short propType )
    {
        switch ((PropertyTypeEnum)(propType))
         {
         case PropertyTypeEnum.Automobile:
         case PropertyTypeEnum.PersonalGeneral:
         case PropertyTypeEnum.PersonalListed:
         case PropertyTypeEnum.VintageAccount:
         case PropertyTypeEnum.Amortizable:
         case PropertyTypeEnum.Depreciable:
         case PropertyTypeEnum.LtTrucksAndVans:
              return 1;

         case PropertyTypeEnum.RealConservation:
         case PropertyTypeEnum.RealEnergy:
         case PropertyTypeEnum.RealFarms:
         case PropertyTypeEnum.RealLowIncomeHousing:
         case PropertyTypeEnum.RealGeneral:
         case PropertyTypeEnum.RealListed:
         case PropertyTypeEnum.NonDepreciable:
              return 2;

         default:
              return 0;
         }
    }
       private uint encodePisDate(uint key, DateTime pisDate)
       {
           uint date_code = 0;
           DateTime julianPisDate = pisDate.Date;

           // Depending upon the key and valid date range, assign a code for
           // the current date value.
           switch (key)
           {
               case 1701:      /* SL,SD,SH,SF,RV-PERSONAL */
               case 1702:      /* SL,SD,SH,SF,RV-REAL */
               case 2002:      /* cc-REAL */
               case 2001:      /* cc-PERSONAL */
               case 1501:      /* OC-PERSONAL */
               case 1502:      /* OC-REAL */

                   if (julianPisDate < new DateTime(1980,1, 1 ))
                       date_code = D_PRE_010180;
                   else
                       if (julianPisDate <= new DateTime(1980,12, 31 ))
                           date_code = D_010180_123180;
                       else
                           if (julianPisDate <= new DateTime(1982,12, 31 ))
                               date_code = D_010181_123182;
                           else
                               if (julianPisDate <= new DateTime(1985,12, 31 ))
                                   date_code = D_010183_123185;
                               else
                                   if (julianPisDate <= new DateTime(1986,12, 31 ))
                                       date_code = D_010186_123186;
                                   else
                                       if (julianPisDate <= new DateTime(1987,12, 31 ))
                                           date_code = D_010187_123187;
                                       else
                                           if (julianPisDate <= new DateTime(1990,9, 30 ))
                                               date_code = D_010188_093090;
                                           else
                                               if (julianPisDate <= new DateTime(1992,6, 30 ))
                                                   date_code = D_100190_063092;
                                               else
                                                   date_code = D_070192_AFTER;
                   break;

               case 1901:      /* YD,YH,YS-PERSONAL */
               case 1902:      /* YD,YH,YS-REAL */
               case 1601:      /* NO-PERSONAL */
               case 1602:      /* NO-REAL */
               case 1001:      /* DB,DH,DD-PERSONAL */
               case 1002:      /* DB,DH,DD-REAL */

                   if (julianPisDate < new DateTime(1980,1, 1 ))
                       date_code = D_PRE_010180;
                   else
                       if (julianPisDate <= new DateTime(1980,12, 31 ))
                           date_code = D_010180_123180;
                       else
                           if (julianPisDate <= new DateTime(1982,12, 31 ))
                               date_code = D_010181_123182;
                           else
                               if (julianPisDate <= new DateTime(1985,12, 31 ))
                                   date_code = D_010183_123185;
                               else
                                   if (julianPisDate <= new DateTime(1986,12, 31 ))
                                       date_code = D_010186_123186;
                                   else
                                       if (julianPisDate <= new DateTime(1987,12, 31 ))
                                           date_code = D_010187_123187;
                                       else
                                           if (julianPisDate <= new DateTime(1990,9, 30 ))
                                               date_code = D_010188_093090;
                                           else
                                               if (julianPisDate <= new DateTime(1992,6, 30 ))
                                                   date_code = D_100190_063092;
                                               else
                                                   date_code = D_070192_AFTER;
                   break;

               case 602:      /* SA,ST-REAL */

                   if (julianPisDate <= new DateTime(1981,12, 31 ))
                       date_code = D_010181_123181;
                   else
                       if (julianPisDate <= new DateTime(1982,12, 31 ))
                           date_code = D_010182_123182;
                       else
                           if (julianPisDate <= new DateTime(1985,12, 31 ))
                               date_code = D_010183_123185;
                           else
                               if (julianPisDate <= new DateTime(1986,12, 31 ))
                                   date_code = D_010186_123186;
                               else
                                   if (julianPisDate <= new DateTime(1987,12, 31 ))
                                       date_code = D_010187_123187;
                                   else
                                       date_code = D_010188_AFTER;
                   break;

               case 601:      /* SA,ST-PERSONAL */

                   if (julianPisDate <= new DateTime(1981,12, 31 ))
                       date_code = D_010181_123181;
                   else
                       if (julianPisDate <= new DateTime(1982,12, 31 ))
                           date_code = D_010182_123182;
                       else
                           if (julianPisDate <= new DateTime(1985,12, 31 ))
                               date_code = D_010183_123185;
                           else
                               if (julianPisDate <= new DateTime(1986,12, 31 ))
                                   date_code = D_010186_123186;
                               else
                                   if (julianPisDate <= new DateTime(1987,12, 31 ))
                                       date_code = D_010187_123187;
                                   else
                                       date_code = D_010188_AFTER;
                   break;


               case 201:      /* MT-PERSONAL */
               case 202:      /* MT-REAL */
               case 101:      /* MF-PERSONAL */
               case 102:      /* MF-REAL */
               case 301:      /* AD-PERSONAL */
               case 302:      /* AD_REAL */

                   if (julianPisDate <= new DateTime(1986, 12, 31))
                       date_code = D_080186_123186;
                   else
                       if (julianPisDate <= new DateTime(1987,12, 31 ))
                           date_code = D_010187_123187;
                       else
                           if (julianPisDate <= new DateTime(1989,12, 31 ))
                               date_code = D_010188_123189;
                           else
                               if (julianPisDate <= new DateTime(1990,9, 30 ))
                                   date_code = D_010190_093090;
                               else
                                   if (julianPisDate <= new DateTime(1992,6, 30 ))
                                       date_code = D_100190_063092;
                                   else
                                       date_code = D_070192_AFTER;
                   break;


               case 402:      /* AT-REAL */

                   if (julianPisDate <= new DateTime(1982,12, 31 ))
                       date_code = D_010181_123182;
                   else
                       if (julianPisDate <= new DateTime(1985,5, 8 ))
                           date_code = D_010183_050885;
                       else
                           if (julianPisDate <= new DateTime(1985,12, 31 ))
                               date_code = D_050985_123185;
                           else
                               if (julianPisDate <= new DateTime(1986,12, 31 ))
                                   date_code = D_010186_123186;
                               else
                                   if (julianPisDate <= new DateTime(1987,12, 31 ))
                                       date_code = D_010187_123187;
                                   else
                                       date_code = D_010188_AFTER;
                   break;

               case 401:      /* AT-PERSONAL */

                   if (julianPisDate <= new DateTime(1981,12, 31 ))
                       date_code = D_010181_123181;
                   else
                       if (julianPisDate <= new DateTime(1982,12, 31 ))
                           date_code = D_010182_123182;
                       else
                           if (julianPisDate <= new DateTime(1985,12, 31 ))
                               date_code = D_010183_123185;
                           else
                               if (julianPisDate <= new DateTime(1986,12, 31 ))
                                   date_code = D_010186_123186;
                               else
                                   if (julianPisDate <= new DateTime(1987,12, 31 ))
                                       date_code = D_010187_123187;
                                   else
                                       date_code = D_010188_AFTER;
                   break;
           }

           return date_code;
       }
       private  uint      encodeITCOption( short itc )
    {
        switch ((bpITCTypeEnum)(itc))
         {
         case bpITCTypeEnum.NewPropFullCredit:
              return 1;
         case bpITCTypeEnum.NewPropReducedCredit:
              return 2;
         case bpITCTypeEnum.UsedPropFullCredit:
              return 3;
         case bpITCTypeEnum.UsedPropReducedCredit:
              return 4;
         case bpITCTypeEnum.Rehab30Year:
              return 5;
         case bpITCTypeEnum.Rehab40Year:
              return 6;
         case bpITCTypeEnum.CertHistoricRehab:
              return 7;
         case bpITCTypeEnum.NonCertHistoricRehab:
              return 8;
         case bpITCTypeEnum.Biomass:
              return 9;
         case bpITCTypeEnum.IntercityBuses:
              return 10;
         case bpITCTypeEnum.HydroelectricGenerating:
              return 11;
         case bpITCTypeEnum.OceanThermal:
              return 12;
         case bpITCTypeEnum.SolarEnergy:
              return 13;
         case bpITCTypeEnum.Wind:
              return 14;
         case bpITCTypeEnum.GeoThermal:
              return 15;
         case bpITCTypeEnum.NoITC:
              return 16;
         case bpITCTypeEnum.CertHistoricTransition:
              return 17;
         case bpITCTypeEnum.QualifiedProgressExp:
              return 18;
         case bpITCTypeEnum.Reforestation:
              return 19;
         case bpITCTypeEnum.SolarEnergyProperty:
              return 20;
         case bpITCTypeEnum.OtherEnergyProperty:
              return 21;
         case bpITCTypeEnum.FuelCellProperty:
              return 22;
         case bpITCTypeEnum.MicroturbineProperty:
              return 23;
         case bpITCTypeEnum.AdvancedCoalProject:
              return 24;
         case bpITCTypeEnum.GasificationProject:
              return 25;
		 case bpITCTypeEnum.HeatPowerSystem:
			  return 26;
		 case bpITCTypeEnum.SmallWindEnergy:
			  return 27;
		 case bpITCTypeEnum.GeothermalHeatPump:
			  return 28;
		 case bpITCTypeEnum.AdvancedEnergyProject:
			  return 29;
         default:
              return 0;
         }
    }
       private uint encodeEstLife(uint key, DateTime pisDate, short estLife)
       {
           int life_code = 0;

           int years = estLife / 100;

           DateTime julianPisDate = pisDate.Date;

           // Then, depending upon the key and valid date range, assign a code for
           // the current estimated life value.
           switch (key)
           {
               case 2002:      /* cc-REAL */
               case 2001:      /* cc-PERSONAL */
               case 1701:      /* SL,SD,SH,SF,RV-PERSONAL */
               case 1702:      /* SL,SD,SH,SF,RV-REAL */

                   if (years <= 2)
                       life_code = L_1_2;
                   else
                       if (years <= 4)
                           life_code = L_3_4;
                       else
                           if (julianPisDate <= new DateTime(1980,12, 31 ))
                           {
                               if (years <= 6)
                                   life_code = L_5_6;
                               else
                                   life_code = L_7PLUS;
                           }
                           else
                               life_code = L_5PLUS;
                   break;


               case 1901:      /* YD,YH,YS-PERSONAL */
               case 1902:      /* YD,YH,YS-REAL */
               case 1001:      /* DB,DH,DD-PERSONAL */
               case 1002:      /* DB,DH,DD-REAL */

                   if (years <= 4)
                       life_code = L_3_4;
                   else
                       if (julianPisDate <= new DateTime(1980,12, 31 ))
                       {
                           if (years <= 6)
                               life_code = L_5_6;
                           else
                               life_code = L_7PLUS;
                       }
                       else
                           life_code = L_5PLUS;
                   break;


               case 602:      /* SA-REAL */
               case 402:      /* AT-REAL */

                   life_code = L_ALL;
                   break;


               case 601:      /* SA-PERSONAL */

                   if (years <= 4)
                       life_code = L_3_4;
                   else
                       life_code = L_5PLUS;
                   break;


               case 1501:      /* OC-PERSONAL */
               case 1502:      /* OC-REAL */

                   if (years <= 2)
                       life_code = L_1_2;
                   else
                       if (years <= 4)
                           life_code = L_3_4;
                       else
                           if (julianPisDate < new DateTime(1981,1, 1 ))
                           {
                               if (years <= 6)
                                   life_code = L_5_6;
                               else
                                   life_code = L_7PLUS;
                           }
                           else
                               life_code = L_5PLUS;
                   break;

               case 1601:      /* NO-PERSONAL */
               case 1602:      /* NO-REAL */

                   life_code = L_0;
                   break;

               case 202:      /* MT-REAL */
               case 102:      /* MF-REAL */

                   life_code = L_7PLUS;
                   break;

               case 201:      /* MT-PERSONAL */
               case 101:      /* MF-PERSONAL */
               case 401:      /* AT-PERSONAL */

                   if (years == 3)
                       life_code = L_3;
                   else
                       life_code = L_5PLUS;
                   break;

               case 301:      /* AD-PERSONAL */

                   if (years <= 2)
                       life_code = L_1_2;
                   else
                       if (years <= 4)
                           life_code = L_3_4;
                       else
                           life_code = L_5PLUS;
                   break;


               case 302:      /* AD_REAL */

                   life_code = L_15PLUS;
                   break;
           }

           return (uint) life_code;
       }

		private void	   _handleEnergyBillITCOptions(ref ulong key, DateTime pisDate, short itc)
{
    DateTime julianPisDate = pisDate.Date;

	// ACQ, EFP is not valid after 1/1/2006
    if ((bpITCTypeEnum)(itc) == bpITCTypeEnum.NewPropFullCredit ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.UsedPropFullCredit ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.Rehab30Year ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.Rehab40Year ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.CertHistoricTransition ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.QualifiedProgressExp)
	{
        if (julianPisDate >= new DateTime(2006,1, 1 ))
		{
			key = (ulong)10000000000L;         // Start 10 digit key
			key += (ulong)encodeITCOption( itc ) * 100L;

			key += 1L;
		}
	}

    if ((bpITCTypeEnum)(itc) == bpITCTypeEnum.Reforestation ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.SolarEnergyProperty ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.OtherEnergyProperty ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.FuelCellProperty ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.MicroturbineProperty ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.AdvancedCoalProject ||
         (bpITCTypeEnum)(itc) == bpITCTypeEnum.GasificationProject)
	{
		key = (ulong)10000000000L;         // Start 10 digit key
		key += (ulong)encodeITCOption( itc ) * 100L;

        if (julianPisDate < new DateTime(2005,8, 8 ))
		{
			key += 1L;
		}
		else
            if (julianPisDate < new DateTime(2006,1, 1 ))
		{
			key += 2L;
		}
		else
                if (julianPisDate < new DateTime(2008,1, 1 ))
		{
			key += 3L;
		}
		else 
		{
			key += 4L;
		}
	}
	if(	(bpITCTypeEnum)(itc) == bpITCTypeEnum.HeatPowerSystem ||
        (bpITCTypeEnum)(itc) == bpITCTypeEnum.SmallWindEnergy ||
        (bpITCTypeEnum)(itc) == bpITCTypeEnum.GeothermalHeatPump)
	{
		key = (ulong)10000000000L;         // Start 10 digit key
		key += (ulong)encodeITCOption( itc ) * 100L;
        if (new DateTime(2008, 10, 3) <= julianPisDate && julianPisDate <= new DateTime(2016,12, 31 ))
		{
			key += 5L;
		}
		else
		{
			key += 4L;
		}

	}

    if ((bpITCTypeEnum)(itc) == bpITCTypeEnum.FuelCellProperty ||
        (bpITCTypeEnum)(itc) == bpITCTypeEnum.MicroturbineProperty)
	{
        if (new DateTime(2008, 1, 1) <= julianPisDate && julianPisDate <= new DateTime(2016,12, 31 ))
		{
			key -= 1L;
		}

	}

    if ((bpITCTypeEnum)(itc) == bpITCTypeEnum.SolarEnergyProperty)
	{
        if (new DateTime(2024,1, 1 ) <= julianPisDate)
		{
			key -= 3L;
		}

	}

	// 2009.1.1 new itc code - AdvancedEnergyProject
	if(	((bpITCTypeEnum)(itc)) == bpITCTypeEnum.AdvancedEnergyProject )
	{
		key = (ulong)10000000000L;         // Start 10 digit key
		key += (ulong)encodeITCOption( itc ) * 100L;
        if (new DateTime(2009, 2, 18) <= julianPisDate && julianPisDate <= new DateTime(2015,8, 17 ))
		{
			key += 5L;
		}
		else
		{
			key += 4L;
		}

	}
        }
    }
}
