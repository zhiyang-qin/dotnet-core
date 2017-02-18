using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.BLL.BusinessTypes
{
    #region Asset Level

    public enum AssetActivityTypeEnum
    {
        acInvalidActivityCode,
        acActive = 1,                                       // 'A'
        acInactive,                                     // 'I'
        acDisposed,                                     // 'D'
        acWholeTransferDisposed,                        // 'F'
        acPartiallyDisposed,                            // 'J'
        acWholeTransfer,                                // 'K'
        acPartialTransferWithinCmp,                     // 'L'
        acPartialTransferOutsideCmp,                    // 'M'
        acPartialTransferDisposed,                      // 'N'
        acADIImport                                     // 'X'
    };

    public enum AssetCreationCodeEnum
    {
        ccUnknownCreationCode,
        ccOriginalAsset,                                // "O"
        ccDisposedPartOfPartialDisposal,                // "D"
        ccRemainingPartOfPartialDisposal,               // "E"
        ccTransferredPartOfPartialTransfer,             // "P"
        ccTransferredPartOfPartialTransferConsDisposed, // "Q"
        ccRemainingPartOfPartialTransfer,               // "R"
        ccRemainingPartOfPartialTransferConsDisposed,   // "S"
        ccWholeTransfer,                                // "T"
        ccDisposedPartOfPartialTransfer,                // "U"
        ccDisposedPartOfPartialTransferAnotherCompany,  // "V"
        ccWholeTransferConsideredDisposed,              // "W"
    };


    public enum AssetImportCodeEnum
    {
        icNoCode,
        icOriginal,
        icPCFasImport,
        icDosFasImport,
        icPeachFasImport,
        icInvalidCode
    };

    public enum AssetITCTypeEnum
    {
        itcNoITC,
        itcNewPropFullCredit,
        itcNewPropReducedCredit,
        itcUsedPropFullCredit,
        itcUsedPropReducedCredit,
        itcRehab30Year,
        itcRehab40Year,
        itcCertHistoricRehab,
        itcNonCertHistoricRehab,
        itcBiomass,
        itcIntercityBuses,
        itcHydroelectricGenerating,
        itcOceanThermal,
        itcSolarEnergy,
        itcWind,
        itcGeoThermal,
        itcCertHistoricTransition,
        itcQualifiedProgressExp,
        itcReforestation,
        itcSolarEnergyProperty,
        itcOtherEnergyProperty,
        itcFuelCellProperty,
        itcMicroturbineProperty,
        itcAdvancedCoalProject,
        itcGasificationProject,
        itcUnknownITCType                               // internal use only
    };

    public enum bpITCTypeEnum
    {
        NoITC = 0,
        NewPropFullCredit,
        NewPropReducedCredit,
        UsedPropFullCredit,
        UsedPropReducedCredit,
        Rehab30Year,
        Rehab40Year,
        CertHistoricRehab,
        NonCertHistoricRehab,
        Biomass,
        IntercityBuses,
        HydroelectricGenerating,
        OceanThermal,
        SolarEnergy,
        Wind,
        GeoThermal,
        CertHistoricTransition,
        QualifiedProgressExp,
        Reforestation,
        SolarEnergyProperty,
        OtherEnergyProperty,
        FuelCellProperty,
        MicroturbineProperty,
        AdvancedCoalProject,
        GasificationProject,
        HeatPowerSystem,
        SmallWindEnergy,
        GeothermalHeatPump,
        AdvancedEnergyProject,
        UnknownITCType // internal use only
    };

    public enum ItcType
    {
        None = 0,
        NewPropFullCredit,
        NewPropReducedCredit,
        UsedPropFullCredit,
        UsedPropReducedCredit,
        Rehab30Year,
        Rehab40Year,
        CertHistoricRehab,
        NonCertHistoricRehab,
        Biomass,
        IntercityBuses,
        HydroelectricGenerating,
        OceanThermal,
        SolarEnergy,
        Wind,
        GeoThermal,
        CertHistoricTransition,
        QualifiedProgressExp,
        Reforestation,
        SolarEnergyProperty,
        OtherEnergyProperty,
        FuelCellProperty,
        MicroturbineProperty,
        AdvancedCoalProject,
        GasificationProject,
        HeatPowerSystem,
        SmallWindEnergy,
        GeothermalHeatPump,
        AdvancedEnergyProject,
        Unknown // internal use only 
    };


    public enum AssetDeprAdjustmentConventionEnum
    {
        dacInvalidAdjustment,
        dacNoAdjustment,
        dacImmediate,
        dacPostrecovery
    };

    #endregion


    #region Book Level

    public enum PropertyTypeEnum
    {
        PropMin = 0,            //Internal Use Only
        PersonalGeneral = 1,
        Automobile,
        PersonalListed,
        RealGeneral,
        RealListed,
        RealConservation,
        RealEnergy,
        RealFarms,
        RealLowIncomeHousing,
        Amortizable,
        VintageAccount,
        Depreciable,
        NonDepreciable,
        LtTrucksAndVans,
        PropMax,
        Unknown             //Internal Use Only 
    };

    public enum DeprMethodTypeEnum
    {
        InvalidDeprMethod = 0,
        MacrsFormula = 1,
        MacrsTable,
        AdsSlMacrs,
        AcrsTable,
        StraightLineAltAcrsFormula,
        StraightLineAltAcrsTable,
        StraightLine,
        StraightLineFullMonth,
        StraightLineHalfYear,
        StraightLineModHalfYear,
        DeclBal,
        DeclBalHalfYear,
        DeclBalModHalfYear,
        DeclBalSwitch,
        DeclBalHalfYearSwitch,
        DeclBalModHalfYearSwitch,
        SumOfTheYearsDigits,
        SumOfTheYearsDigitsHalfYear,
        SumOfTheYearsDigitsModHalfYear,
        RemValueOverRemLife,
        OwnDepreciationCalculation,
        DoNotDepreciate,
        RepeatTheTaxBookMethod,
        CustomMethod,
        MACRSIndianReservation,
        MacrsFormula30,
        AdsSlMacrs30,
        MACRSIndianReservation30,
        StraightLineFullMonth30,

        // Canadian BEGIN !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        CdnDeclBal,
        CdnDeclBalFullMonth,
        CdnDeclBalHalfYear,
        UnknownDeprMethod = 33  // internal use only.
        // Canadian END ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    };



	public enum BkTypeEnum
	{
        bpblBookTaxBook,
        bpblBookInternalBook,
        bpblBookStateBook,
        bpblBookAMTBook,
        bpblBookEandPBook,
        bpblBookACEBook,
        bpblBookUserBook
	} ;

    public enum BookTypeEnum
    {
        TaxBook = 0,
        InternalBook = 1,
        StateBook = 2,
        AMTBook = 3,
        EandPBook = 4,
        ACEBook = 5,
        UserBook = 6,
    }

    #endregion


    #region Rulebase

    public enum RuleBase_ErrorCodeEnum
    {
        rulebase_Valid,
        rulebase_RuleBaseFailure,
        rulebase_WarnBindingAgreement,
        rulebase_WarnBindRealProperty,
        rulebase_WarnRealProperty,
        rulebase_InvalBefore1978,
        rulebase_InvalBeforeOct11978,
        rulebase_InvalBefore1980,
        rulebase_InvalBefore1983,
        rulebase_InvalBefore1987,
        rulebase_InvalAfterSep1990,
        rulebase_InvalAfter1985,
        rulebase_InvalAfter1987,
        rulebase_InvalMethods,
        rulebase_InvalAfter1986,
        rulebase_InvalBefore1982,
        rulebase_InvalUnknownITCOption,
        rulebase_Applies,
        rulebase_DoesNotApply,
        rulebase_AppliesDontAllowEntry,
        rulebase_Invalid,
        rulebase_ValidateCustomMethodExists,
        rulebase_WarnNotNormallyUsed,
        rulebase_WarnAfter1986,
        rulebase_InvalModAcrsBeforeAug11986,
        rulebase_WarnNotUsualRecoveryPeriod,
        rulebase_WarnNotUsualUnlTransProp,
        rulebase_GetLifeFromCustomMethod,
        rulebase_InvalDateValue,
        rulebase_LowIncHousingInvalBefore1981,
        rulebase_ListedPropInvalBeforeJune191984,
        rulebase_LowIncHousingInvalAfter1986,
        rulebase_AutoPropInvalBeforeJune191984,
        rulebase_DateInvalBeforeStartBusiness,
        rulebase_DateInvalBefore1920,
        rulebase_DateInvalAfter2999,
        rulebase_MethSameAsTax,
        rulebase_MethSameAsTaxMI,
        rulebase_AMTNotSameAsTax,
        rulebase_AMTNotSameAsTaxNotMI,
        rulebase_WarnNotUsualRecoveryPd,
        rulebase_WarnNotOver20Years,
        rulebase_WarnNotUnderMACRS,
        rulebase_Warn30LeaseholdImprove,
        rulebase_WarnAANotOver20Years,
        rulebase_WarnOnlyNYLZAllowForNonReal,
        rulebase_WarnOnlyNYLZAllowForReal,
        rulebase_WarnOnlyNYLZAllowAfter2006,
        rulebase_WarnOnlyNYLZAllowForRMF100EST0500,
        rulebase_LtTrucksAndVansPropInvalBefore2003,
        rulebase_UnknownMethod
    };


    public enum ErrorCode
    {
        Valid,
        RuleBaseFailure,
        WarnBindingAgreement,
        WarnBindRealProperty,
        WarnRealProperty,
        InvalBefore1978,
        InvalBeforeOct11978,
        InvalBefore1980,
        InvalBefore1983,
        InvalBefore1987,
        InvalAfterSep1990,
        InvalAfter1985,
        InvalAfter1987,
        InvalMethods,
        InvalAfter1986,
        InvalBefore1982,
        InvalUnknownITCOption,
        Applies,
        DoesNotApply,
        AppliesDontAllowEntry,
        Invalid,
        ValidateCustomMethodExists,
        WarnNotNormallyUsed,
        WarnAfter1986,
        InvalModAcrsBeforeAug11986,
        WarnNotUsualRecoveryPeriod,
        WarnNotUsualUnlTransProp,
        GetLifeFromCustomMethod,
        InvalDateValue,
        LowIncHousingInvalBefore1981,
        ListedPropInvalBeforeJune191984,
        LowIncHousingInvalAfter1986,
        AutoPropInvalBeforeJune191984,
        DateInvalBeforeStartBusiness,
        DateInvalBefore1920,
        DateInvalAfter2999,
        MethSameAsTax,
        MethSameAsTaxMI,
        AMTNotSameAsTax,
        AMTNotSameAsTaxNotMI,
        WarnNotUsualRecoveryPd,
        WarnNotOver20Years,
        WarnNotUnderMACRS,
        Warn30LeaseholdImprove,
        WarnAANotOver20Years,
        WarnOnlyNYLZAllowForNonReal,
        WarnOnlyNYLZAllowForReal,
        WarnOnlyNYLZAllowAfter2006,
        WarnOnlyNYLZAllowForRMF100EST0500,
        LtTrucksAndVansPropInvalBefore2003,
        UnknownMethod
    };

    #endregion

}
