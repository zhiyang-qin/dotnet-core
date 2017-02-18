using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class DisposalMethod
    {
        public enum DisposalTypeEnum
        {
            Sale = 1,
            Abandonment,
            LikeKindExchange_Pre_Mar_2000,
            TaxableExchange,
            InvoluntaryConversion_Pre_Mar_2000,
            Transfer,
            Casualty,
            Other,
            Unknown, // internal use only
            LikeKindExchange_Post_Feb_2000,
            InvoluntaryConversion_Post_Feb_2000
        };

        private DisposalTypeEnum _type;

        public DisposalMethod()
        {
            _type = DisposalTypeEnum.Sale;
        }

        public DisposalMethod(DisposalMethod obj)
        {
            copyFrom(obj);
        }

        public DisposalMethod(DisposalTypeEnum method)
        {
            _type = method;
        }


        public void copyFrom(DisposalMethod obj)
        { Type = (obj.Type); }

        public DisposalTypeEnum Type
        { 
            get
            {
                    return _type;
            }
            set
            {
                    _type = value;
                    return ;
            }
        }

        public virtual void defaults()
        { Type = (DisposalTypeEnum.Sale); }

        public virtual bool isObjectOk()
        { return true; }

        public static bool isValidName(char name)
        {
            if (translateShortNameToType(name) == DisposalTypeEnum.Unknown)
                return false;
            else
                return true;
        }

        public static DisposalTypeEnum translateShortNameToType(char shortName)
        {
            switch (shortName)
            {
                case 'S':
                    return DisposalTypeEnum.Sale;
                case 'A':
                    return DisposalTypeEnum.Abandonment;
                case 'L':
                    return DisposalTypeEnum.LikeKindExchange_Pre_Mar_2000;
                case 'E':
                    return DisposalTypeEnum.TaxableExchange;
                case 'I':
                    return DisposalTypeEnum.InvoluntaryConversion_Pre_Mar_2000;
                case 'T':
                    return DisposalTypeEnum.Transfer;
                case 'C':
                    return DisposalTypeEnum.Casualty;
                case 'R':
                    return DisposalTypeEnum.Other;
                case 'K':
                    return DisposalTypeEnum.LikeKindExchange_Post_Feb_2000;
                case 'V':
                    return DisposalTypeEnum.InvoluntaryConversion_Post_Feb_2000;
                default:
                    return DisposalTypeEnum.Unknown;
            }
        }



        protected static char translateTypeToShortName(DisposalTypeEnum type)
        {
            switch (type)
            {
                case DisposalTypeEnum.Sale:
                    return 'S';
                case DisposalTypeEnum.Abandonment:
                    return 'A';
                case DisposalTypeEnum.LikeKindExchange_Pre_Mar_2000:
                    return 'L';
                case DisposalTypeEnum.LikeKindExchange_Post_Feb_2000:
                    return 'K';
                case DisposalTypeEnum.TaxableExchange:
                    return 'E';
                case DisposalTypeEnum.InvoluntaryConversion_Pre_Mar_2000:
                    return 'I';
                case DisposalTypeEnum.InvoluntaryConversion_Post_Feb_2000:
                    return 'V';
                case DisposalTypeEnum.Transfer:
                    return 'T';
                case DisposalTypeEnum.Casualty:
                    return 'C';
                case DisposalTypeEnum.Other:
                    return 'R';
                default:
                    return '\0';
            }
        }



    }
}
