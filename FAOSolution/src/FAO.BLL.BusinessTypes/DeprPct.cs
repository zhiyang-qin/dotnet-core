using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.BLL.BusinessTypes
{
    public class DeprPct
    {
        private int _pct;

        public DeprPct()
        {
        }

        public DeprPct(int pct)
        {
            Percentage = pct;
        }

        public int Percentage
        {
            get { return _pct; }
            set { _pct = value; }
        }

        public static bool operator ==(DeprPct left, DeprPct right)
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

            return (left.Percentage == right.Percentage);
        }

        public static bool operator !=(DeprPct left, DeprPct right)
        {
            return !(left == right);
        }


        public static implicit operator int(DeprPct deprPct)
        {
            return deprPct.Percentage;
        }

        public static implicit operator DeprPct(int pct)
        {
            DeprPct deprPct = new DeprPct(pct);
            return deprPct;
        }

        public override bool Equals(object obj)
        {
            DeprPct that = obj as DeprPct;
            return this == that;
        }

        public override int GetHashCode()
        {
            return (int)0;
        }
        public void copyFrom(DeprPct deptPct)
        {
            this.Percentage = deptPct.Percentage;
        }

    }
}
