using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class ITC
    {
        //Fix for defect 4221
        private double _pct;
        private double _amt;
        private double _reduce;
        private ItcType _type;


        public ITC() :
            this(ItcType.None, 0.0, 0.0, 0.0)
        {
        }

        public ITC(ItcType itctype, double amt, double pct, double rdc)
        {
            Type = ( itctype );
            if ( Type == ItcType.None )
                 clearValues();
            else
            {
                 Percentage = ( pct );
                 Amount = (amt);
                 Reduction = (rdc);
            }
        }

        public ITC(ITC itcObject)
        {
            CopyFrom(itcObject);
        }

        public override bool Equals(object o)
        {
            return o.ToString() == this.ToString();
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public static bool operator ==(ITC left, ITC right)
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

            return true;
        }

        public static bool operator !=(ITC left, ITC right)
        {
            return !(left == right);
        }

        public void CopyFrom(ITC itcObject)
        {
            Type = (itcObject.Type);
            Amount = (itcObject.Amount);
            Percentage = (itcObject.Percentage);
            Reduction = (itcObject.Reduction);
        }

        public double Percentage
        {
            get { return _pct; }
            set { _pct = value; }
        }


        public ItcType Type
        {
            get { return _type; }
            set 
            { 
                _type = value;
                if (value == ItcType.None)
                    clearValues();
            }
        }

        public double Amount
        {
            get
            {
                {
                    return _amt;
                }
            }
            set
            {
                {
                    _amt = value;
                    return;
                }
                
            }
        }

        public double Reduction
        {
            get
            {
                {
                    return _reduce;
                }
            }
            set
            {
                {
                    _reduce = value;
                    return;
                }
            }
        }

        public bool isAmountOverLimit(DateTime pisDate, PropertyType propType, DeprMethod deprMethod)
        {
            if (Amount == 0.0)
                return false;

            double limit = amountLimit(pisDate, propType, deprMethod);
            if (limit != -1.0 && Amount > limit)
                return true;
            else
                return false;
        }

        public bool isPercentageOverLimit(DateTime pisDate)
        {
            if (Percentage > percentageLimit(pisDate))
                return true;
            else
                return false;
        }

        public double getBasisReductionPct(DateTime pisDate)
        {
            DateTime firstDate = new DateTime(1982, 12, 31);
            DateTime secondDate = new DateTime(1985, 12, 31);

            if (pisDate <= firstDate)
                switch (Type)
                {
                    case ItcType.Rehab30Year:
                    case ItcType.Rehab40Year:
                        return 1.0;
                    default:
                        return 0.0;
                }
            else
                if (pisDate <= secondDate)
                    switch (Type)
                    {
                        case ItcType.Rehab30Year:
                        case ItcType.Rehab40Year:
                        case ItcType.NonCertHistoricRehab:
                            return 1.0;
                        case ItcType.NewPropReducedCredit:
                        case ItcType.UsedPropReducedCredit:
                            return 0.0;
                        default:
                            return 0.5;
                    }
                else
                    switch (Type)
                    {
                        case ItcType.NewPropFullCredit:
                        case ItcType.UsedPropFullCredit:
                        case ItcType.Rehab30Year:
                        case ItcType.Rehab40Year:
                        case ItcType.NonCertHistoricRehab:
                        case ItcType.QualifiedProgressExp:
                            return 1.0;
                        default:
                            return 0.5;
                    }
        }

        public virtual void Defaults()
        {
            Type = ItcType.None;
            clearValues();
        }


        public virtual bool IsObjectOk()
        {
            return true;
        }

        public static double percentageLimit(DateTime pisDate)
        {
                                        
    if ( pisDate < (new DateTime(2006, 1,1 )) ) 
		return 0.4; 

	return 0.3; 
        }

        public static double amountLimit(DateTime pisDate, PropertyType propType, DeprMethod deprMethod)
        {
    double limit = 0.0;

    if (propType.Type !=PropertyTypeEnum.Automobile && propType.Type != PropertyTypeEnum.LtTrucksAndVans)
         return -1.0;
         
    if ( isAMethodWithALimit( deprMethod ) == false )
         return -1.0;
         
                                        
    if ( pisDate < new DateTime(1984, 6,19 ) )
         limit = -1.0;
    else
    if ( pisDate <= new DateTime(1984 , 12,31) )
         limit = 1000.0;
    else
    if ( pisDate <= new DateTime(1985, 4,2 ) )
         limit = 1000.0;
    else         
    if ( pisDate <= new DateTime(1986, 12,31 ) )
         limit = 675.0;
    else
    if ( pisDate >= new DateTime(1992, 1,1 ) )
         limit = 0.0;
         
    return limit;         
        }

        private void clearValues()
        {
            Percentage = (0.0);
            Amount = (0.0);
            Reduction = (0.0);
        }

        private static bool isAMethodWithALimit(DeprMethod deprMethod)
        {
    switch( deprMethod.Type )
         {
         case DeprMethodTypeEnum.MacrsFormula:
         case DeprMethodTypeEnum.MacrsTable:
         case DeprMethodTypeEnum.AdsSlMacrs:
         case DeprMethodTypeEnum.AcrsTable:
         case DeprMethodTypeEnum.StraightLineAltAcrsFormula:
         case DeprMethodTypeEnum.StraightLineAltAcrsTable:
              return true;
              
         default:
              return false;
         }
        }

    }
}
