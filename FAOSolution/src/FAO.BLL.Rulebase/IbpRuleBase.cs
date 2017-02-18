using FAO.BLL.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    public interface IbpRuleBase
    {
        bool BuildPropTypeList(out List<int> list);

        bool BuildITCList(DateTime PlaceInService, short DeprMethod, out List<int> list);
        bool ValidateITC(short PropType, DateTime PlaceInService, short DeprMethod, short EstimatedLife, short ITCType, out ErrorCode errorCode);
        bool GetDefaultITCPercent(short PropType, DateTime PlaceInService, short DeprMethod, short EstimatedLife, short ITCOption, ref double ITCPct, out ErrorCode errorCode);
        
        bool BuildDeprMethodList(short PropType, DateTime PlaceInService, bool IsShortYear, out List<int> list);
        bool ValidateDeprMethod(short PropType, DateTime PlaceInService, short DeprMethod, bool IsShortYear, out ErrorCode errorCode);
        bool GetDefaultDeprMethod(short sPropType, DateTime PlaceInService, out short sDeprMethod, out ErrorCode errorCode);

        bool BuildDeprPercentList(short PropType, DateTime PlaceInService, short DeprMethod, out List<int> list);
        
        bool BuildEstimatedLifeList(short PropType, DateTime PlaceInService, short DeprMethod, int Pct, out List<int> list);
        bool ValidateEstimatedLife(short PropType, DateTime PlaceInService, short sDeprMethod, int Pct, short EstLife, out ErrorCode errorCode);
        bool GetDefaultEstimatedLife(short PropType, DateTime PlaceInService, short sDeprMethod, int Pct, ref short EstLife, out ErrorCode errorCode);
        bool GetDefaultADSLife(short PropType, short DeprMethod, int Pct, short EstLife, ref short ADSLife, out ErrorCode errorCode);
        bool GetBonusApplicability(short PropType, DateTime PlaceInService, short DeprMethod, short EstLife, out ErrorCode errorCode);
        bool GetS179Applicability(short PropType, DateTime PlaceInService, short DeprMethod, short EstLife, double Limit, out ErrorCode errorCode);
        bool ValidateBusinessUse(short DeprMethod, int Pct, out ErrorCode errorCode);
        bool ValidatePlaceInService(short PropType, DateTime PlaceInService, DateTime StartOfBusiness, out ErrorCode errorCode);
        bool AllowMidQuarter(short PropType, short DeprMethod, bool hasBeginningDate, out ErrorCode errorCode);
        //bool ForceBookDefaults(IbpDepreciableAsset asset, out ErrorCode errorCode);


        //bool IsForceDefaultsAvailable(IbpDepreciableAsset asset, out ErrorCode errorCode);
        //bool ForceDefaultsForInternalBook(IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook, out ErrorCode errorCode);
        //bool ForceDefaultsForStateBook(IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook, out ErrorCode errorCode);
        //bool ForceDefaultsForAMTBook(IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook, out ErrorCode errorCode);
        //bool ForceDefaultsForACEBook(IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset AMTBook, IbpDepreciableBookAsset destBook, out ErrorCode errorCode);

        //bool GetSection179Limit(PropertyTypeEnum propType, IbpDepreciableBookAsset book, DateTime date, out double value);

        
        
        
        
        
    }
}
