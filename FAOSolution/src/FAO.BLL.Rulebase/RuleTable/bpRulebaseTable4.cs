using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable4
    {

        public bpRulebaseTable4() { }

        public uint tableNumber() { return 4; }

        public ulong buildSourceCode(short propType, DateTime pisDate)
        {
            ulong key = 0L;

            key += (ulong)encodePropType(propType) * 100L;

            key += (ulong)encodePisDate(pisDate);

            specialHandlingFor2013HR8(ref key, pisDate, propType); 
            
            return key;
        }


        public bool isObjectOk() { return true; }

        private uint encodePropType(short propType)
        {
            switch ((PropertyTypeEnum)propType)
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


        private uint encodePisDate(DateTime pisDate)
        {
            uint date_code;

            if (pisDate.Date < new DateTime(1980, 1, 1))
                date_code = 1;
            else
                if (pisDate.Date <= new DateTime(1980, 12, 31))
                    date_code = 2;
                else
                    if (pisDate.Date <= new DateTime(1984, 6, 18))
                        date_code = 3;
                    else
                        if (pisDate.Date <= new DateTime(1986, 7, 31))
                            date_code = 4;
                        else
                            if (pisDate.Date <= new DateTime(1986, 12, 31))
                                date_code = 5;
                            else
                                if (pisDate.Date <= new DateTime(1993, 12, 31))
                                    date_code = 6;
                                else
                                    if (pisDate.Date <= new DateTime(1996, 6, 12))
                                        date_code = 7;
                                    else
                                        if (pisDate.Date <= new DateTime(2001, 9, 10))
                                            date_code = 8;
                                        else
                                            if (pisDate.Date <= new DateTime(2004, 12, 31))
                                                date_code = 9;
                                            else
                                                if (pisDate.Date <= new DateTime(2006, 12, 31))
                                                    date_code = 10;
                                                else
                                                    if (pisDate.Date <= new DateTime(2009, 12, 31))	// update mr, mi to 12/31/2009
                                                        date_code = 11;
                                                    else
                                                        if (pisDate.Date <= new DateTime(2011, 12, 31))	//GSD 2011.1
                                                            date_code = 15;
                                                        else
                                                            if (pisDate.Date <= new DateTime(2012, 12, 31))
                                                                date_code = 12;
                                                            else
                                                                if (pisDate.Date <= new DateTime(2019, 12, 31))     //GSD_2016.1
                                                                    date_code = 13;
                                                                else
                                                                    date_code = 14;
            return date_code;
        }

        void specialHandlingFor2013HR8(ref ulong key, DateTime pisDate, short propType)
        {
            // update ma, aa from 2017-2020, should just be ma, aa for for rscef
            if (((PropertyTypeEnum)(propType)) == PropertyTypeEnum.RealConservation ||
                ((PropertyTypeEnum)(propType)) == PropertyTypeEnum.RealEnergy ||
                ((PropertyTypeEnum)(propType)) == PropertyTypeEnum.RealFarms ||
                ((PropertyTypeEnum)(propType)) == PropertyTypeEnum.RealGeneral ||
                ((PropertyTypeEnum)(propType)) == PropertyTypeEnum.RealListed)
            {
                if (pisDate >= new DateTime(2017, 1, 1) && pisDate <= new DateTime(2019, 12, 31))       //GSD_2016.1    
                {
                    key = key + 3;
                }

                if (pisDate >= new DateTime(2020, 1, 1) && pisDate <= new DateTime(2020, 12, 31))       //GSD_2016.1    
                {
                    key = key + 2;
                }
            }

            // update ma, aa, sb to 1/1/2017 - 12/31/2019 for pqat
            if (((PropertyTypeEnum)(propType)) == PropertyTypeEnum.Automobile ||
                ((PropertyTypeEnum)(propType)) == PropertyTypeEnum.LtTrucksAndVans ||
                ((PropertyTypeEnum)(propType)) == PropertyTypeEnum.PersonalGeneral ||
                ((PropertyTypeEnum)(propType)) == PropertyTypeEnum.PersonalListed)
            {
                if (pisDate >= new DateTime(2017, 1, 1) && pisDate <= new DateTime(2019, 12, 31))       //GSD_2016.1    
                {
                    key = key + 3;
                }
            }

        }



    }

}
