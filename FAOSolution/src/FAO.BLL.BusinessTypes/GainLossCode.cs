using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class GainLossCode : GainLoss
    {
        public GainLossCode(GainLoss obj)
            : base(obj)
        { }

        public GainLossCode(GainLossCode obj)
        { copyFrom(obj); }

        public GainLossCode(char shortName)
        {
            defaults();
            if (isValidName(shortName) == false)
                Type = (GainLossType.Unknown);
            else
                Type = (translateShortNameToValue(shortName));
        }


        public void copyFrom(GainLossCode obj)
        { base.copyFrom(obj); }

        //public LRbpGainLossCode    operator=(LRCbpGainLossCode obj);
        //public bool                operator==(LRCbpGainLossCode obj)
        //                          { return inherited::operator==(obj); }

        //public bool                operator!=(LRCbpGainLossCode obj)
        //                          { return inherited::operator!=(obj); }
        #region Operator Overloading

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(GainLossCode left, GainLossCode right)
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
        public static bool operator !=(GainLossCode left, GainLossCode right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (GainLossCode)o;
        }
        public override int GetHashCode()
        {
            return (int)Type;
        }

        #endregion

        public string longName()
        { 
            return translateValueToLongName(Type); 
        }

        public static GainLossType value(char name)
        { 
            return translateShortNameToValue(name); 
        }


        public override bool isObjectOk()
        { 
            return base.isObjectOk(); 
        }

        private static string translateValueToLongName(GainLossType value)
        {
            switch (value)
            {
                case GainLossType.TakeGainLoss:
                    return "Take gain/(loss)";
                case GainLossType.DontTakeGainLoss:
                    return "Don't take gain/(loss)";
                case GainLossType.DeferGainLoss:
                    return "Defer gain/(loss)";
            }

            return (string)null;
        }

    }
}
