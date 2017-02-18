using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class GainLoss
    {
        public enum GainLossType
        {
            TakeGainLoss = 1,
            DontTakeGainLoss,
            DeferGainLoss,
            Unknown
        };

        private double _amount;
        private DateTime _deferDate;
        private GainLossType _type;

        public GainLoss(GainLoss obj)
        {
            copyFrom(obj);
        }

        public GainLoss()
        {
            defaults();
            Type = (GainLossType.DontTakeGainLoss);
        }

        public GainLoss(GainLossType aType)
        {
            defaults();
            Type = (aType);
        }

        #region Operator Overloading

        /// <summary>
        /// OverLoading < operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if left value is less than the right value</returns>
        public static bool operator <(GainLoss left, GainLoss right)
        {
            return left.Amount < right.Amount;
        }

        /// <summary>
        /// OverLoading > operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if left value is less than the right value</returns>
        public static bool operator >(GainLoss left, GainLoss right)
        {
            return left.Amount > right.Amount;
        }

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(GainLoss left, GainLoss right)
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

            if(left.Type == right.Type && left.Type != GainLossType.DeferGainLoss)
                return true;
            if (left.Type != right.Type)
                return false;
            if (left.DeferDate == right.DeferDate)
                return true;
            return false;
        }

        /// <summary>
        /// OverLoading != operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are not the same</returns>
        public static bool operator !=(GainLoss left, GainLoss right)
        {
            return !(left == right);
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (GainLoss)o;
        }
        public override int GetHashCode()
        {
            return (int)Type;
        }

        #endregion

        public void copyFrom(GainLoss obj)
        {
            Type = (obj.Type);
            Amount = (obj.Amount);
            DeferDate = (obj.DeferDate);
        }

        public double Amount
        {
            get
            {
                    return _amount;
            }
            set
            {
                    _amount = value;
                    return;
            }
        }


        public GainLossType Type
        {
            get
            {
                {
                    return _type;
                }
            } 
            set
            {
                {
                    _type = value;
                    return;
                }
            }
        }

        public DateTime DeferDate
        {
            get
            {
                {
                    return _deferDate;
                }
            }
            set
            {
                {
                    _deferDate = value;
                    return;
                }
            }
        }



        public virtual void defaults()
        {
            Type = (GainLossType.DontTakeGainLoss);
            Amount = (0.0);
            DeferDate = DateTime.MinValue;
        }

        public virtual bool isObjectOk()
        {
            if (Type == GainLossType.Unknown)
                return false;
            return true;
        }

        public char shortName()
        { 
            return translateValueToShortName(Type); 
        }

        public static bool isValidName(char name)
        {
            if (translateShortNameToValue(name) != GainLossType.Unknown)
                return true;
            else
                return false;
        }


        protected static GainLossType translateShortNameToValue(char name)
        {
            switch (name)
            {
                case 'D':
                    return GainLossType.DeferGainLoss;
                case 'Y':
                    return GainLossType.TakeGainLoss;
                case 'N':
                    return GainLossType.DontTakeGainLoss;
            }

            return GainLossType.Unknown;
        }

        protected static char translateValueToShortName(GainLossType value)
        {
            switch (value)
            {
                case GainLossType.DeferGainLoss:
                    return 'D';
                case GainLossType.TakeGainLoss:
                    return 'Y';
                case GainLossType.DontTakeGainLoss:
                    return 'N';
            }

            return '\0';
        }

    }
}
