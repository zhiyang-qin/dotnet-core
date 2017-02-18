using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class AdjConvention
    {
        public enum AdjConvType
        {
            None = 1,
            Immediate = 2,
            Postrecovery = 3,
            Unknown    // Internal use only
        };

        public static int countOfConventions()
        {
            return (3);
        }

        public static bool getNextConvention(out AdjConvType type_, ref int key_)
        {
            if (key_ < 0)
            {
                // a new enumeration
                key_ = 0;
            }

            // make sure there are still books left to enumerate
            if (key_ >= countOfConventions())
            {
                type_ = AdjConvType.Unknown;
                return false;
            }


            type_ = (AdjConvType)Enum.GetValues(typeof(AdjConvType)).GetValue(key_);

            key_++;

            return true;
        }


        private AdjConvType _type;

        public AdjConvention() 
        { 
            defaults(); 
        }

        public AdjConvention(AdjConvType newType)
        { 
            Type = (newType); 
        }

        public AdjConvention(AdjConvention obj)
        { 
            copyFrom(obj); 
        }

        #region Operator Overloading

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(AdjConvention left, AdjConvention right)
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

        /// <summary>
        /// OverLoading != operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are not the same</returns>
        public static bool operator !=(AdjConvention left, AdjConvention right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (AdjConvention)o;
        }
        public override int GetHashCode()
        {
            return (int)Type;
        }

        #endregion

        public void copyFrom(AdjConvention obj)
        { 
            Type = (obj.Type); 
        }

        public AdjConvType Type 
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            } 
        }

        public virtual void defaults()
        { 
            Type = (AdjConvType.None); 
        }

        public virtual bool isObjectOk()
        { 
            return true; 
        }


    }
}
