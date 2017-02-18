using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class DisposalMethodCode : DisposalMethod
    {
        private bool _stable;

        public DisposalMethodCode()
        { _stable = true; defaults(); }

        public DisposalMethodCode(DisposalMethodCode obj)
        {
            copyFrom(obj);
        }

        public DisposalMethodCode(DisposalMethod obj)
            : base(obj)
        { _stable = true; }

        public DisposalMethodCode(char shortName)
        {
            defaults();
            if (isValidName(shortName) == false)
            {
                Type = (DisposalTypeEnum.Unknown);
                _stable = false;
            }
            else
                Type = (translateShortNameToType(shortName));
        }

        //public LRbpDisposalMethodCode operator=(LRCbpDisposalMethodCode obj);

        public void copyFrom(DisposalMethodCode obj)
        {
            //inherited::copyFrom( object );
            base.copyFrom(obj);
            _stable = obj._stable;
        }

        public char shortName()
        { 
            return translateTypeToShortName(Type); 
        }

        public string longName()
        { 
            return translateTypeToLongName(Type); 
        }

        public override bool isObjectOk()
        {
            if (base.isObjectOk() == false)
                return false;
            return _stable;
        }

        private static string translateTypeToLongName(DisposalTypeEnum type)
        {
            switch (type)
            {
                case DisposalTypeEnum.Sale:
                    return "Sale";

                case DisposalTypeEnum.Abandonment:
                    return "Abandonment";

                case DisposalTypeEnum.LikeKindExchange_Pre_Mar_2000:
                    return "Like-Kind Exchange: Pre-1/3/2000";

                case DisposalTypeEnum.TaxableExchange:
                    return "Taxable Exchange";

                case DisposalTypeEnum.InvoluntaryConversion_Pre_Mar_2000:
                    return "Involuntary Conversion: Pre-1/3/2000";

                case DisposalTypeEnum.Transfer:
                    return "Transfer";

                case DisposalTypeEnum.Casualty:
                    return "Casualty";

                case DisposalTypeEnum.Other:
                    return "Other Disposal";

                case DisposalTypeEnum.LikeKindExchange_Post_Feb_2000:
                    return "Like-Kind Exchange: Post-1/2/2000";

                case DisposalTypeEnum.InvoluntaryConversion_Post_Feb_2000:
                    return "Involuntary Conversion: Post-1/2/2000";

                default:
                    return null;
            }
        }

    }
}
