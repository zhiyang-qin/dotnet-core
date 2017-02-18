using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    public class ITCCode : ITC
    {
        #region Nested Struct
        struct ITCCODE
        {
            public ItcType type;
            public char code;
        }

        #endregion


        #region Static Variables

        static ITCCODE[] codes = new ITCCODE[] { 
	                       new ITCCODE() { type = ItcType.None, code = 'X' },
                           new ITCCODE() { type = ItcType.NewPropFullCredit,       code = 'A' },
                           new ITCCODE() { type = ItcType.NewPropReducedCredit,    code = 'B' },
                           new ITCCODE() { type = ItcType.UsedPropFullCredit,      code = 'C' },
                           new ITCCODE() { type = ItcType.UsedPropReducedCredit,   code = 'D' },
                           new ITCCODE() { type = ItcType.Rehab30Year,             code = 'E' },
                           new ITCCODE() { type = ItcType.Rehab40Year,             code = 'F' },
                           new ITCCODE() { type = ItcType.CertHistoricRehab,       code = 'G' },
                           new ITCCODE() { type = ItcType.NonCertHistoricRehab,    code = 'H' },
                           new ITCCODE() { type = ItcType.Biomass,                 code = 'I' },
                           new ITCCODE() { type = ItcType.IntercityBuses,          code = 'J' },
                           new ITCCODE() { type = ItcType.HydroelectricGenerating, code = 'K' },
                           new ITCCODE() { type = ItcType.OceanThermal,            code = 'L' },
                           new ITCCODE() { type = ItcType.SolarEnergy,             code = 'M' },
                           new ITCCODE() { type = ItcType.Wind,                    code = 'N' },
                           new ITCCODE() { type = ItcType.GeoThermal,              code = 'O' },
                           new ITCCODE() { type = ItcType.CertHistoricTransition,  code = 'P' },
                           new ITCCODE() { type = ItcType.QualifiedProgressExp,    code = 'Q' },
                           new ITCCODE() { type = ItcType.Reforestation,           code = 'R' },
                           new ITCCODE() { type = ItcType.SolarEnergyProperty,     code = 'S' },
                           new ITCCODE() { type = ItcType.OtherEnergyProperty,     code = 'T' },
                           new ITCCODE() { type = ItcType.FuelCellProperty,        code = 'U' },
                           new ITCCODE() { type = ItcType.MicroturbineProperty,    code = 'V' },
                           new ITCCODE() { type = ItcType.AdvancedCoalProject,     code = 'W' },
                           new ITCCODE() { type = ItcType.GasificationProject,     code = 'Y' },
						   new ITCCODE() { type = ItcType.HeatPowerSystem,         code = '1' },
						   new ITCCODE() { type = ItcType.SmallWindEnergy,         code = '2' },
						   new ITCCODE() { type = ItcType.GeothermalHeatPump,      code = '3' },
						   new ITCCODE() { type = ItcType.AdvancedEnergyProject,   code = '4' },
                           new ITCCODE() { type = ItcType.Unknown,                 code = '\0' }
        };

        #endregion

        private bool _stable;

        public ITCCode()
        {
            _stable = true;
            Defaults();
        }

        public ITCCode(char shortName)
            : this(shortName, 0.0, 0.0)
        {
        }

        public ITCCode(char shortName, double amt, double pct)
        {
            _stable = true;
            Defaults();

            if (isValidShortName(shortName) == false)
            {
                _stable = false;
                Type = ItcType.Unknown;
            }
            else
            {
                Type = (translateShortNameToType(shortName));
                Amount = (amt);
                Percentage = (pct);
            }
        }


        public ITCCode(ITCCode itcCodeObject)
        {
            CopyFrom(itcCodeObject);
        }

        public ITCCode(ITC itcObject)
        {
            _stable = true;
            CopyFrom(itcObject);
        }

        //         LRbpITCCode         operator=(LRCbpITCCode obj);

        //public bool                operator<(LRCbpITCCode obj)
        //                          { return ( type() < obj.type() ); }

        //public bool                operator==(LRCbpITCCode obj)
        //                          { return inherited::operator==(obj); }

        //public bool                operator!=(LRCbpITCCode obj)
        //                          { return !operator==(obj); }

        public void                copyFrom( ITCCode obj )
    {
    base.CopyFrom( obj );
    _stable = obj._stable;
    }


        public char                shortName()
                                  { return translateTypeToShortName( Type ); }

        public string              longName()
                                  { return ""; }

        public bool                isObjectOk()
    {
    if ( base.IsObjectOk() == false )
         return false;
    return _stable;
    }

        public static bool         isValidShortName( char shortName )
    {
        if (translateShortNameToType(shortName) == ItcType.Unknown)
         return false;
    else
         return true;
    }                  


        public static ItcType      translateShortNameToType( char shortName )
    {
    int i=0;
    while (codes[i].code != '\0')
         if ( codes[i].code == shortName )
              return codes[i].type;
         else
              ++i;
    return ItcType.Unknown;
    }          

        private static char         translateTypeToShortName( ItcType type )
    {
    int i=0;
    while (codes[i].code != '\0')
         if ( codes[i].type == type )
              return codes[i].code;
         else
              ++i;
    return '\0';
    }          

    }
}
