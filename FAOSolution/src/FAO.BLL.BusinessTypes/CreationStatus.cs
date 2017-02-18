using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class CreationStatus
    {
        public enum CreationStatusEnum { OriginalWindowsFAS=1,
                               OriginalPCFAS,
                               OriginalDosFAS,
                               Unknown // internal use only 
                             };

        private CreationStatusEnum _type;

        public CreationStatus() : 
            this(CreationStatusEnum.OriginalWindowsFAS)
        {
        }

        public CreationStatus(CreationStatusEnum type)
        {
            _type = type;
        }
        
        public CreationStatus(BusinessTypes.CreationStatus obj)
        {
            copyFrom(obj);
        }

        public static bool operator ==(BusinessTypes.CreationStatus left, BusinessTypes.CreationStatus right)
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

            return left.Type == right.Type;
        }

        public static bool operator !=(BusinessTypes.CreationStatus left, BusinessTypes.CreationStatus right)
        {
            return !(left == right);
        }

        public void copyFrom(BusinessTypes.CreationStatus obj)
        {
            Type = obj.Type;
        }

        public CreationStatusEnum Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public virtual void defaults()
        {
            Type = CreationStatusEnum.OriginalWindowsFAS;
        }

        public virtual bool isObjectOk()
        {
            if (_type < CreationStatusEnum.OriginalWindowsFAS || _type >= CreationStatusEnum.Unknown)
                return false;
            else
                return true;
        }

    }
}
