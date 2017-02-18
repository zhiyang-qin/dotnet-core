using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class CreationStatusCode : CreationStatus
    {

        public static bool isValidName(char code)
        {
            if (translateShortNameToType(code) == CreationStatusEnum.Unknown)
                return false;
            else
                return true;
        }

        public static CreationStatusEnum translateShortNameToType(char shortName)
        {
            switch (shortName)
            {
                case 'A':
                    return CreationStatusEnum.OriginalWindowsFAS;
                case 'B':
                    return CreationStatusEnum.OriginalPCFAS;
                case 'C':
                    return CreationStatusEnum.OriginalDosFAS;
                default:
                    return CreationStatusEnum.Unknown;
            }
        }

        private static char translateTypeToShortName(CreationStatusEnum type)
        {
            switch (type)
            {
                case CreationStatusEnum.OriginalWindowsFAS:
                    return 'A';
                case CreationStatusEnum.OriginalPCFAS:
                    return 'B';
                case CreationStatusEnum.OriginalDosFAS:
                    return 'C';
                default:
                    return '\0';
            }
        }
        private static string translateTypeToLongName(CreationStatusEnum type)
        {
            switch (type)
            {
                case CreationStatusEnum.OriginalWindowsFAS:
                    return "Original/Windows/FAS1000/FAS2000";
                case CreationStatusEnum.OriginalPCFAS:
                    return "Original/PCFAS";
                case CreationStatusEnum.OriginalDosFAS:
                    return "Original/DOS/FAS1000/FAS2000";
                default:
                    return null;
            }
        }


        private bool _stable;

        public CreationStatusCode()
        {
            defaults();
        }

        public CreationStatusCode(char shortName)
        {
            defaults();
            if (isValidName(shortName) == false)
            {
                Type = (CreationStatusEnum.Unknown);
                _stable = false;
            }
            else
                Type = (translateShortNameToType(shortName));
        }

        public CreationStatusCode(BusinessTypes.CreationStatus obj)
            : base(obj)
        {
            _stable = true;
        }

        public CreationStatusCode(CreationStatusCode obj)
        {
            copyFrom(obj);
        }

        public static bool operator ==(CreationStatusCode left, CreationStatusCode right)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            return (BusinessTypes.CreationStatus)left == (BusinessTypes.CreationStatus)right;
        }

        public static bool operator !=(CreationStatusCode left, CreationStatusCode right)
        {
            return !(left == right);
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

    }
}
