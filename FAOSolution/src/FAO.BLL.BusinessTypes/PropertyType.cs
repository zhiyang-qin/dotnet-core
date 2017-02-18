using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.BusinessTypes
{
    public class PropertyType
    {
        #region Private Variables

        private PropertyTypeEnum _type;

        #endregion


        #region Constructors

        public PropertyType()
        {
            Type = PropertyTypeEnum.PersonalGeneral;
        }

        public PropertyType(PropertyTypeEnum newType)
        {
            Type = newType;
        }

        public PropertyType(PropertyType obj)
        {
            copyFrom(obj);
        }

        #endregion


        #region Operator Overload

        public override bool Equals(object o)
        {
            return this == (PropertyType)o;
        }

        public override int GetHashCode()
        {
            return (int)Type;
        }

        public static bool operator ==(PropertyType left, PropertyType right)
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

        public static bool operator !=(PropertyType left, PropertyType right)
        {
            return !(left == right);
        }

        public static implicit operator PropertyTypeEnum(PropertyType bpPropType)
        {
            return bpPropType.Type;
        }

        public static implicit operator PropertyType(PropertyTypeEnum propType)
        {
            PropertyType bpPropType = new PropertyType(propType);
            return bpPropType;
        }

        #endregion

        #region Public Methods

        public void copyFrom(PropertyType pInfo)
        {
            Type = (pInfo.Type);
        }

        public virtual void defaults()
        {
            Type = PropertyTypeEnum.PersonalGeneral;
        }

        public virtual bool isObjectOk()
        {
            if (_type <= PropertyTypeEnum.PropMin || _type >= PropertyTypeEnum.PropMax)
                return false;
            else
                return true;
        }

        #endregion


        #region Public Properties

        public PropertyTypeEnum Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion
    }
}
