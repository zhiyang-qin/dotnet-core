using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class ActivityStatus
    {
        public enum ActivityType
        {
            Active = 1,               // 'A'
            Inactive,               // 'I'
            Disposed,               // 'D'
            WholeTransferDisposed,  // 'F'
            PartiallyDisposed,      // 'J'
            WholeTransfer,          // 'K'
            PartialTransferWithinCmp,  // 'L'
            PartialTransferOutsideCmp, // 'M'
            PartialTransferDisposed,   // 'N'
            ADIImport                  // 'X'
        };

        public static bool isValidName(char code)
        {
            switch (code)
            {
                case 'A':
                case 'D':
                case 'I':
                case 'F':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'X':
                    return true;
                default:
                    return false;
            }
        }

        public static ActivityType translateShortNameToType(char shortName)
        {
            switch (shortName)
            {
                case 'I':
                    return ActivityType.Inactive;
                case 'D':
                    return ActivityType.Disposed;
                case 'F':
                    return ActivityType.WholeTransferDisposed;
                case 'J':
                    return ActivityType.PartiallyDisposed;
                case 'K':
                    return ActivityType.WholeTransfer;
                case 'L':
                    return ActivityType.PartialTransferWithinCmp;
                case 'M':
                    return ActivityType.PartialTransferOutsideCmp;
                case 'N':
                    return ActivityType.PartialTransferDisposed;
                case 'X':
                    return ActivityType.ADIImport;
                case 'A':
                default:
                    return ActivityType.Active;
            }
        }

        #region Private Variables
        
        private ActivityType _value;

        #endregion


        #region Constructors
        
        public ActivityStatus(ActivityStatus obj)
        {
            copyFrom(obj);
        }

        public ActivityStatus()
        {
            Value = (ActivityType.Active);
        }

        public ActivityStatus(ActivityType aValue)
        {
            Value = (aValue);
        }

        #endregion


        #region Operator Overloading

        /// <summary>
        /// OverLoading == operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are the same</returns>
        public static bool operator ==(ActivityStatus left, ActivityStatus right)
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

            return left.Value == right.Value;
        }

        /// <summary>
        /// OverLoading != operator
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="right">Right value</param>
        /// <returns>return true if values are not the same</returns>
        public static bool operator !=(ActivityStatus left, ActivityStatus right)
        {
            return !(left == right);
        }

        public static implicit operator ActivityType(ActivityStatus activityStatus)
        {
            return activityStatus.Value;
        }

        public static implicit operator ActivityStatus(ActivityType activityType)
        {
            ActivityStatus activityStatus = new ActivityStatus(activityType);
            return activityStatus;
        }

        //Always override GetHashCode(),Equals when overloading ==
        public override bool Equals(object o)
        {
            return this == (ActivityStatus)o;
        }
        public override int GetHashCode()
        {
            return (int)Value;
        } 

        #endregion

        #region Public Properties
        
        public ActivityType Value
        {
            get 
            {
                return _value;
            }
            set 
            {
                _value = value; 
            }
        }

        #endregion


        #region Public Methods

        public void copyFrom(ActivityStatus obj)
        { 
            Value = (obj.Value); 
        }

        public virtual bool isObjectOk()
        { 
            return true; 
        }

        public virtual void defaults()
        { 
            Value = (ActivityType.Active); 
        }

        #endregion


        #region Protected Methods
        
        protected char translateTypeToShortName(ActivityType type)
        {
            switch (type)
            {
                case ActivityType.Inactive:
                    return 'I';
                case ActivityType.Disposed:
                    return 'D';
                case ActivityType.WholeTransferDisposed:
                    return 'F';
                case ActivityType.PartiallyDisposed:
                    return 'J';
                case ActivityType.WholeTransfer:
                    return 'K';
                case ActivityType.PartialTransferWithinCmp:
                    return 'L';
                case ActivityType.PartialTransferOutsideCmp:
                    return 'M';
                case ActivityType.PartialTransferDisposed:
                    return 'N';
                case ActivityType.ADIImport:
                    return 'X';
                case ActivityType.Active:
                default:
                    return 'A';
            }
        }

        #endregion


    }
}
