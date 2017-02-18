using System;
using System.Collections.Generic;
using System.Text;

using FAO.BLL.BusinessTypes;

namespace FAO.BLL.Rulebase
{
    public class bpRuleBase : IbpRuleBase
    {
        public bpRuleBase()
        {

        }

        public bool BuildPropTypeList(out List<int> list)
        {
            list = null;
            List<int> ei = new List<int>();
            list = ei;

            for (int i = 1; i <= 14; ++i)
            {
                ei.Add(i);
            }

            return true;
        }

        public bool BuildITCList(DateTime PlaceInService, short DeprMethod, out List<int> list)
        {
            // Create a object for Rulebase #6.
            bpRulebaseTable6 rule = new bpRulebaseTable6();

            // Ask the rulebase for the source code.
            ulong sourceCode = rule.buildSourceCode(PlaceInService, DeprMethod);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            uint targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
            {
                createITCList(targetCode, out list);
                return true;
            }

            list = null;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool ValidateITC(short PropType, DateTime PlaceInService, short DeprMethod, short EstimatedLife, short ITCType, out ErrorCode errorCode)
        {
            errorCode = ErrorCode.Valid;

            // If itc type is NONE, return a true.  This type is ALWAYS true.
            if ((bpITCTypeEnum)(ITCType) == bpITCTypeEnum.NoITC)
            {
                errorCode = ErrorCode.Valid;
                return true;
            }

            // If itc type is UNKNOWN, return a Invalid code.
            if ((bpITCTypeEnum)(ITCType) == bpITCTypeEnum.UnknownITCType)
            {
                errorCode = ErrorCode.InvalUnknownITCOption;
                return true;
            }

            bpRulebaseTable1 table = new bpRulebaseTable1();
            bpRulebaseTable rulebase = new bpRulebaseTable(table.tableNumber());

            // Build the source code from the data.
            ulong sourceCode = table.buildSourceCode(PropType,
                                                      PlaceInService,
                                                      DeprMethod,
                                                      EstimatedLife,
                                                      ITCType);

            // Fetch the target code from the rulebase.
            uint targetCode = 0;
            if (rulebase.fetchTargetCode(sourceCode, out targetCode))
            {
                switch (targetCode)
                {
                    case 1:
                    case 2:
                    case 4:
                    case 6:
                    case 9:
                    case 10:
                    case 12:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 34:
                    case 35:
                    case 36:
                    case 37:

                    case 61:
                    case 62:
                    case 63:
                    case 64:
                        errorCode = ErrorCode.Valid;
                        return true;

                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 11:
                    case 13:
                    case 19:
                        // errorCode = ErrorCode.WarnBindingAgreement;
                        return true;

                    case 20:
                    case 21:
                    case 23:
                    case 25:
                    case 28:
                    case 29:
                    case 31:
                    case 33:
                        errorCode = ErrorCode.WarnRealProperty;
                        return true;

                    case 22:
                    case 24:
                    case 26:
                    case 27:
                    case 30:
                    case 32:
                    case 38:
                        // errorCode = ErrorCode.WarnBindRealProperty;
                        return true;

                    case 50:
                        errorCode = ErrorCode.InvalBefore1978;
                        return true;

                    case 51:
                        errorCode = ErrorCode.InvalBeforeOct11978;
                        return true;

                    case 52:
                        errorCode = ErrorCode.InvalBefore1980;
                        return true;

                    case 53:
                        errorCode = ErrorCode.InvalBefore1983;
                        return true;

                    case 54:
                        errorCode = ErrorCode.InvalBefore1987;
                        return true;

                    case 55:
                        errorCode = ErrorCode.InvalAfterSep1990;
                        return true;

                    case 56:
                        errorCode = ErrorCode.InvalAfter1985;
                        return true;

                    case 57:
                        errorCode = ErrorCode.InvalAfter1987;
                        return true;

                    case 58:
                        errorCode = ErrorCode.InvalMethods;
                        return true;

                    case 59:
                        errorCode = ErrorCode.InvalAfter1986;
                        return true;

                    case 60:
                        errorCode = ErrorCode.InvalBefore1982;
                        return true;
                }
            }

            errorCode = ErrorCode.RuleBaseFailure;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool GetDefaultITCPercent(short PropType, DateTime PlaceInService, short DeprMethod, short EstimatedLife, short ITCOption, ref double ITCPct, out ErrorCode errorCode)
        {
            errorCode = ErrorCode.Valid;
            ITCPct = 0;

            // If itc type is NONE, return a true.  This type has already taken care of setting
            // its percentage and amount.
            if ((bpITCTypeEnum)(ITCOption) == bpITCTypeEnum.NoITC)
                return true;

            bpRulebaseTable1 table = new bpRulebaseTable1();
            bpRulebaseTable rulebase = new bpRulebaseTable(table.tableNumber());

            // Build the source code from the data.
            ulong sourceCode = table.buildSourceCode(PropType,
                                                      PlaceInService,
                                                      DeprMethod,
                                                      EstimatedLife,
                                                      ITCOption);

            // Fetch the target code from the rulebase.
            uint targetCode = 0;
            if (rulebase.fetchTargetCode(sourceCode, out targetCode))
            {
                switch (targetCode)
                {
                    case 1: ITCPct = 0.0; break;
                    case 2: ITCPct = 0.033; break;
                    case 3: ITCPct = 0.039; break;
                    case 4: ITCPct = 0.04; break;
                    case 5: ITCPct = 0.0495; break;
                    case 6: ITCPct = 0.06; break;
                    case 7: ITCPct = 0.06; break;
                    case 8: ITCPct = 0.065; break;
                    case 9: ITCPct = 0.0667; break;
                    case 10: ITCPct = 0.08; break;
                    case 11: ITCPct = 0.0825; break;
                    case 12: ITCPct = 0.1; break;
                    case 13: ITCPct = 0.1; break;
                    case 14: ITCPct = 0.11; break;
                    case 15: ITCPct = 0.12; break;
                    case 16: ITCPct = 0.15; break;
                    case 17: ITCPct = 0.2; break;
                    case 18: ITCPct = 0.25; break;
                    case 19: ITCPct = 0.0; break;
                    case 20: ITCPct = 0.0; break;
                    case 21: ITCPct = 0.033; break;
                    case 22: ITCPct = 0.039; break;
                    case 23: ITCPct = 0.04; break;
                    case 24: ITCPct = 0.0495; break;
                    case 25: ITCPct = 0.06; break;
                    case 26: ITCPct = 0.06; break;
                    case 27: ITCPct = 0.065; break;
                    case 28: ITCPct = 0.0667; break;
                    case 29: ITCPct = 0.08; break;
                    case 30: ITCPct = 0.0825; break;
                    case 31: ITCPct = 0.1; break;
                    case 32: ITCPct = 0.1; break;
                    case 33: ITCPct = 0.11; break;
                    case 34: ITCPct = 0.12; break;
                    case 35: ITCPct = 0.15; break;
                    case 36: ITCPct = 0.2; break;
                    case 37: ITCPct = 0.25; break;
                    case 38: ITCPct = 0.0; break;

                    case 61: ITCPct = 0.1; break;
                    case 62:
                        if (PlaceInService >= (new DateTime(2008, 10, 3)) && ITCOption == 23)
                            ITCPct = 0.3;
                        else
                            ITCPct = 0.15;
                        break;
                    case 63:
                        if (PlaceInService >= (new DateTime(2008, 10, 3)) && ITCOption == 24)
                            ITCPct = 0.3;
                        else
                            ITCPct = 0.2;
                        break;
                    case 64: ITCPct = 0.3; break;

                    default: ITCPct = -1.0; break;
                }

                return true;
            }
            else
            {
                errorCode = ErrorCode.Invalid;
                return false;
            }
        }


        public bool BuildDeprMethodList(short PropType, DateTime PlaceInService, bool IsShortYear, out List<int> list)
        {
            // Create a object for Rulebase #4.
            bpRulebaseTable4 rule = new bpRulebaseTable4();

            // Ask the rulebase for the source code.
            ulong sourceCode = rule.buildSourceCode(PropType, PlaceInService);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            uint targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
            {
                createDeprMethodList(targetCode, IsShortYear, out list);
                return true;
            }

            list = null;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool ValidateDeprMethod(short PropType, DateTime PlaceInService, short DeprMethod, bool IsShortYear, out ErrorCode errorCode)
        {
            List<int> ei;
            long count;

            errorCode = ErrorCode.Valid;

            // is custom method?
            if ((DeprMethodTypeEnum)(DeprMethod) == DeprMethodTypeEnum.CustomMethod)
            {
                //
                // Set this return as the default for custom methods to tell the
                // caller to verify that the custom method exists in the current
                // company.  If another error pops up, this default will be overridden
                //
                errorCode = ErrorCode.ValidateCustomMethodExists;
            }

            // build the list of valid methods.  if not in list, then an error.
            if (BuildDeprMethodList(PropType, PlaceInService, IsShortYear, out ei) == true && ei != null)
            {
                bool state = false;
                int type;
                int posi;

                count = ei.Count;
                for (posi = 0; posi < count; posi++)
                {
                    type = ei[posi];
                    {
                        if (type == DeprMethod)
                        {
                            state = true;
                        }
                    }
                }
                ei.Clear();

                if (state == false)
                {
                    errorCode = ErrorCode.Invalid;
                    return false;
                }
            }

            bpRulebaseTable3 table = new bpRulebaseTable3();
            bpRulebaseTable rulebase = new bpRulebaseTable(table.tableNumber());

            // Build the source code from the data.
            ulong sourceCode = table.buildSourceCode(PropType, PlaceInService, DeprMethod);

            // Fetch the target code from the rulebase.  If there is one return true.  If
            // not, return a false.
            uint targetCode = 0;
            if (rulebase.fetchTargetCode(sourceCode, out targetCode))
            {
                switch (targetCode)
                {
                    case 2:
                    case 12:
                        {
                            errorCode = ErrorCode.WarnNotNormallyUsed;
                            return true;
                        }
                    case 4:
                        errorCode = ErrorCode.WarnAfter1986;
                        return true;
                    case 5:
                        errorCode = ErrorCode.InvalModAcrsBeforeAug11986;
                        return true;
                    case 6:
                        errorCode = ErrorCode.WarnNotUnderMACRS;
                        return true;
                    case 14:
                        errorCode = ErrorCode.MethSameAsTax;
                        return true;
                    case 15:
                        errorCode = ErrorCode.MethSameAsTaxMI;
                        return true;
                    case 16:
                        errorCode = ErrorCode.Warn30LeaseholdImprove;
                        return true;
                    case 17:
                        errorCode = ErrorCode.WarnOnlyNYLZAllowForNonReal;
                        return true;
                    case 18:
                        errorCode = ErrorCode.WarnOnlyNYLZAllowForReal;
                        return true;
                    case 19:
                        errorCode = ErrorCode.WarnOnlyNYLZAllowAfter2006;
                        return true;
                    default:
                        return true;
                }
            }

            errorCode = ErrorCode.RuleBaseFailure;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool GetDefaultDeprMethod(short sPropType, DateTime PlaceInService, out short sDeprMethod, out ErrorCode errorCode)
        {
            PropertyTypeEnum PropType = (PropertyTypeEnum)sPropType;
            DeprMethodTypeEnum DeprMethod;
            DateTime pisDate = (PlaceInService);

            errorCode = ErrorCode.Valid;

            if (PropType == PropertyTypeEnum.VintageAccount)
                DeprMethod = DeprMethodTypeEnum.StraightLineModHalfYear;
            else
                if (PropType == PropertyTypeEnum.RealLowIncomeHousing)
                    DeprMethod = DeprMethodTypeEnum.AcrsTable;
                else
                    if (PropType == PropertyTypeEnum.Amortizable)
                        DeprMethod = DeprMethodTypeEnum.StraightLine;
                    else
                        if (PropType == PropertyTypeEnum.NonDepreciable)
                            DeprMethod = DeprMethodTypeEnum.DoNotDepreciate;
                        else
                        {
                            if (pisDate < new DateTime(1981, 1, 1))
                                DeprMethod = DeprMethodTypeEnum.StraightLine;
                            else
                                if (pisDate < new DateTime(1987, 1, 1))
                                    DeprMethod = DeprMethodTypeEnum.AcrsTable;
                                else
                                    if (pisDate <= new DateTime(2001, 9, 10))
                                        DeprMethod = DeprMethodTypeEnum.MacrsFormula;
                                    else
                                        if (pisDate <= new DateTime(2004, 12, 31))
                                        {
                                            if (PropType == PropertyTypeEnum.Automobile ||
                                                 PropType == PropertyTypeEnum.LtTrucksAndVans ||
                                                 PropType == PropertyTypeEnum.PersonalGeneral ||
                                                 PropType == PropertyTypeEnum.PersonalListed)
                                                DeprMethod = DeprMethodTypeEnum.MacrsFormula30;
                                            else
                                                DeprMethod = DeprMethodTypeEnum.MacrsFormula;
                                        }
                                        else
                                        {
                                            //GSD 2011.1 - extend this out to 2012
                                            // KL 2016.1
                                            //GSD_2016.1 - extend this out thru 2019
                                            if ((new DateTime(2008, 1, 1) <= pisDate && pisDate <= new DateTime(2019, 12, 31)) &&
                                                    (PropType == PropertyTypeEnum.Automobile ||
                                                        PropType == PropertyTypeEnum.LtTrucksAndVans ||
                                                        PropType == PropertyTypeEnum.PersonalGeneral ||
                                                        PropType == PropertyTypeEnum.PersonalListed))
                                            {
                                                DeprMethod = DeprMethodTypeEnum.MacrsFormula30;
                                            }
                                            else
                                            {
                                                DeprMethod = DeprMethodTypeEnum.MacrsFormula;
                                            }
                                        }

                        }
            sDeprMethod = (short)DeprMethod;
            return true;
        }

        public bool BuildDeprPercentList(short PropType, DateTime PlaceInService, short DeprMethod, out List<int> list)
        {
            switch ((DeprMethodTypeEnum)DeprMethod)
            {
                case DeprMethodTypeEnum.MacrsTable:
                case DeprMethodTypeEnum.MacrsFormula:
                case DeprMethodTypeEnum.MACRSIndianReservation:
                case DeprMethodTypeEnum.DeclBal:
                case DeprMethodTypeEnum.DeclBalHalfYear:
                case DeprMethodTypeEnum.DeclBalModHalfYear:
                case DeprMethodTypeEnum.DeclBalSwitch:
                case DeprMethodTypeEnum.DeclBalHalfYearSwitch:
                case DeprMethodTypeEnum.DeclBalModHalfYearSwitch:
                case DeprMethodTypeEnum.MacrsFormula30:
                case DeprMethodTypeEnum.MACRSIndianReservation30:
                    break;
                default:
                    list = null;
                    return false;
            }

            // Create a object for Rulebase #4.
            bpRulebaseTable10 rule = new bpRulebaseTable10();

            // Ask the rulebase for the source code.
            ulong sourceCode = rule.buildSourceCode(PropType, DeprMethod, PlaceInService);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            uint targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
            {
                createDeprPercentList(targetCode, out list);
                return true;
            }
            list = null;

            return false;
        }

        public bool BuildEstimatedLifeList(short PropType, DateTime PlaceInService, short DeprMethod, int Pct, out List<int> list)
        {
            // Create a object for Rulebase #5.
            bpRulebaseTable5 rule = new bpRulebaseTable5();

            // Ask the rulebase for the source code.
            ulong sourceCode = rule.buildSourceCode(PropType, PlaceInService, DeprMethod, (uint)Pct);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            uint targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
            {
                createEstimatedLifeList(targetCode, out list);
                if (list == null)
                {
                    return false;
                }
                return true;
            }
            list = null;

            return false;
        }

        public bool ValidateEstimatedLife(short PropType, DateTime PlaceInService, short sDeprMethod, int Pct, short EstLife, out ErrorCode errorCode)
        {
            DeprMethodTypeEnum DeprMethod = (DeprMethodTypeEnum)sDeprMethod;
            List<int> list = null;
            long count;

            errorCode = ErrorCode.Valid;

            // Any life from 0 to 99 years is valid for RV.
            if (DeprMethod == DeprMethodTypeEnum.RemValueOverRemLife)
                return true;

            // If life is zero and method is not NO, then life is ALWAYS invalid.
            if (EstLife == 0 && DeprMethod != DeprMethodTypeEnum.DoNotDepreciate)
            {
                errorCode = ErrorCode.Invalid;
                return false;
            }

            // build the list of valid estimated lives.  if not in list, then an error.

            if (BuildEstimatedLifeList((PropertyTypeEnum)PropType, PlaceInService, DeprMethod, Pct, out list) == true &&
                list != null)
            {
                bool state = false;
                int life;
                int posi;
                count = list.Count;
                for (posi = 0; state == false && posi < count; posi++)
                {
                    life = list[posi];
                    {
                        if (life == EstLife)
                        {
                            state = true;
                        }
                    }
                }
                list.Clear();
                if (state == false)
                {
                    errorCode = ErrorCode.Invalid;
                    return false;
                }
            }

            bpRulebaseTable5 table = new bpRulebaseTable5();
            bpRulebaseTable rulebase = new bpRulebaseTable(table.tableNumber());

            // Build the source code from the data.
            ulong sourceCode = table.buildSourceCode(PropType, PlaceInService, (short)DeprMethod, (uint)Pct);

            // Fetch the target code from the rulebase.  If there is one return true.  If
            // not, return a false.
            uint targetCode = 0;
            if (rulebase.fetchTargetCode(sourceCode, out targetCode))
            {
                switch (targetCode)
                {
                    case 2:
                        if (EstLife != 1500)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        break;
                    case 3:
                        if (EstLife != 1800)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        break;
                    case 4:
                        if (EstLife != 1900)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        break;
                    case 5:
                        if (EstLife != 300)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        break;
                    case 7:
                        if (EstLife != 1500)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        break;
                    case 8:
                        if (EstLife != 1800)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        break;
                    case 9:
                        if (EstLife != 1900)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        break;
                    // commented out case 10 error message to help fix jchud-00081
                    // note that this is an incorrect message anyway --
                    // it refers to real property and target code 10 is
                    // only for automobiles   MJB  7/21/98
                    //            case 10:
                    //                if ( EstLife != 500 )
                    //                {
                    //                    errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                    //                    return true;
                    //                }
                    //                break;
                    case 14:
                        if (getAsMonths(EstLife) < 12)
                        {
                            errorCode = ErrorCode.Invalid;
                            return true;
                        }
                        else
                            if (EstLife != 4000)
                            {
                                errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                                return true;
                            }
                        break;
                    case 15:
                        if (getAsMonths(EstLife) < 12 || EstLife > 3911)
                        {
                            errorCode = ErrorCode.Invalid;
                            return true;
                        }
                        break;
                    case 61:
                    case 39:
                    case 16:
                        if (EstLife < 300)
                        {
                            errorCode = ErrorCode.Invalid;
                            return true;
                        }
                        break;
                    case 19:
                        if (getAsMonths(EstLife) < 12 || EstLife > 6000)
                        {
                            errorCode = ErrorCode.Invalid;
                            return true;
                        }
                        break;
                    case 20:
                        if (EstLife == 2706)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        break;
                    case 43:
                    case 21:
                        if (getAsMonths(EstLife) < 6)
                        {
                            errorCode = ErrorCode.Invalid;
                            return true;
                        }
                        break;
                    case 25:
                        if (EstLife == 2706)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        else
                            if (EstLife == 3106)
                            {
                                if (PlaceInService > (new DateTime(1993, 12, 31)))
                                {
                                    errorCode = ErrorCode.WarnNotUsualRecoveryPd;
                                    return true;
                                }
                            }
                        break;

                    case 13:
                    case 58:
                    case 36:
                    case 106:
                        if (getAsMonths(EstLife) < 12)
                        {
                            errorCode = ErrorCode.Invalid;
                            return true;
                        }
                        break;
                    case 63:
                    case 64:
                    case 65:
                    case 66:
                    case 67:
                    case 68:
                    case 69:
                        if (getAsMonths(EstLife) < 1)
                        {
                            errorCode = ErrorCode.Invalid;
                            return true;
                        }
                        break;
                    case 71:
                        if (EstLife == 2706)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        else
                            if (EstLife == 3106)
                            {
                                if (PlaceInService > (new DateTime(1993, 12, 31)))
                                {
                                    errorCode = ErrorCode.WarnNotUsualRecoveryPd;
                                    return true;
                                }
                            }
                        break;

                    case 78:
                        if (EstLife == 2706)
                        {
                            errorCode = ErrorCode.WarnNotUsualRecoveryPeriod;
                            return true;
                        }
                        else
                            if (EstLife == 3106)
                            {
                                errorCode = ErrorCode.WarnNotUsualUnlTransProp;
                                return true;
                            }
                        break;
                    case 84:
                    case 85:
                        if (EstLife == 3106)
                        {
                            if (PlaceInService > (new DateTime(1993, 12, 31)))
                            {
                                errorCode = ErrorCode.WarnNotUsualRecoveryPd;
                                return true;
                            }
                        }
                        break;
                    //Qinz: For MA150 of P,Q,R,S,C,E,F
                    //      For AA, SB of P,Q
                    //      For SB of A
                    case 95:
                    case 97:
                    case 98:
                        if (EstLife > 2000)
                        {
                            errorCode = ErrorCode.WarnNotOver20Years;
                            return false;
                        }
                        break;
                    //Qinz: For AA of P,Q
                    case 96:
                        if (EstLife > 2000)
                        {
                            errorCode = ErrorCode.WarnAANotOver20Years;
                            return false;
                        }
                        break;
                    case 100:
                    case 102:
                        if (EstLife == 500)
                        {
                            errorCode = ErrorCode.WarnOnlyNYLZAllowForRMF100EST0500;
                            return true;
                        }
                        else if (EstLife == 3106)
                        {
                            if (PlaceInService > (new DateTime(1993, 12, 31)))
                            {
                                errorCode = ErrorCode.WarnNotUsualRecoveryPd;
                                return true;
                            }
                        }
                        break;
                }

                errorCode = ErrorCode.Valid;
                return true;
            }
            errorCode = ErrorCode.RuleBaseFailure;
            return false;
        }


        public bool GetDefaultEstimatedLife(short PropType, DateTime PlaceInService, short sDeprMethod, int Pct, ref short EstLife, out ErrorCode errorCode)
        {
            DeprMethodTypeEnum DeprMethod = (DeprMethodTypeEnum)sDeprMethod;

            bpRulebaseTable5 table = new bpRulebaseTable5();
            bpRulebaseTable rulebase = new bpRulebaseTable(table.tableNumber());

            // Build the source code from the data.
            ulong sourceCode = table.buildSourceCode(PropType, PlaceInService, (short)DeprMethod, (uint)Pct);

            // Fetch the target code from the rulebase.  If there is one return true.  If
            // not, return a false.
            uint targetCode = 0;
            if (rulebase.fetchTargetCode(sourceCode, out targetCode))
            {
                switch (targetCode)
                {
                    case 5:
                    case 98:
                    case 106:
                        EstLife = 300;
                        break;

                    case 1:
                    case 6:
                    case 10:
                    case 92:
                    case 58:
                    case 61:
                    case 62:
                    case 63:
                    case 69:
                    case 80:
                    case 97:
                    case 101:
                        EstLife = 500;
                        break;


                    case 70:
                    case 43:
                    case 81:
                    case 87:
                    case 88:
                        EstLife = 1500;
                        break;


                    case 25:
                    case 71:
                    case 84:
                    case 85:
                    case 100:
                    case 102:
                    case 105:
                    case 108:
                        EstLife = 3900;
                        break;

                    case 11:
                    case 21:
                    case 83:
                    //Qinz: For MA150 of P,Q,R,S,C,E,F
                    case 95:
                        EstLife = 1500;
                        break;

                    case 13:
                    case 15:
                    case 16:
                    case 17:
                    case 65:
                    case 66:
                    case 82:
                    case 90:
                    case 96:
                    case 99:
                        EstLife = 700;
                        break;

                    case 22:
                    case 86:
                        EstLife = 1000;
                        break;

                    case 2:
                    case 7:
                    case 23:
                        EstLife = 1500;
                        break;

                    case 3:
                    case 8:
                        EstLife = 1800;
                        break;

                    case 4:
                    case 9:
                        EstLife = 1900;
                        break;

                    case 12:
                    case 20:
                        EstLife = 3106;
                        break;

                    case 14:
                    case 36:
                    case 39:
                    case 40:
                    case 64:
                    case 67:
                    case 68:
                    case 91:
                        EstLife = 4000;
                        break;

                    case 18:
                        EstLife = 0;
                        break;

                    // 97.1 Tax Update -- Added default for 25-yr property
                    // MJB 11/25/96
                    case 24:
                    case 89:
                        EstLife = 2500;
                        break;
                    case 72:
                    case 104:
                        EstLife = 2200;
                        break;
                    case 73:
                        EstLife = 1200;
                        break;
                    case 74:
                        EstLife = 600;
                        break;
                    case 75:
                        EstLife = 400;
                        break;
                    case 76:
                        EstLife = 400;
                        break;
                    case 77:
                        EstLife = 300;
                        break;
                    case 78:
                    case 93:
                    case 94:
                    case 103:
                    case 107:
                        EstLife = 3900;
                        break;

                    default:
                        // If depr method is a custom code, get the custom life
                        // and set it...
                        if (DeprMethod == DeprMethodTypeEnum.CustomMethod)
                        {
                            EstLife = 9900;
                            errorCode = ErrorCode.GetLifeFromCustomMethod;
                            return true;
                        }
                        break;
                }
                errorCode = ErrorCode.Valid;
                return true;
            }
            errorCode = ErrorCode.RuleBaseFailure;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool GetDefaultADSLife(short PropType, short DeprMethod, int Pct, short EstLife, ref short ADSLife, out ErrorCode errorCode)
        {
            short ads = 0;
            PropertyTypeEnum propType = (PropertyTypeEnum)(PropType);
            DeprMethodTypeEnum method = (DeprMethodTypeEnum)(DeprMethod);

            // if automobile, always use 5 years.
            if (propType == PropertyTypeEnum.Automobile || propType == PropertyTypeEnum.LtTrucksAndVans)
                ads = 500; //classLife( bpYrsMosDate( 5,0 ) );
            else
                if ((propType == PropertyTypeEnum.RealConservation ||
                      propType == PropertyTypeEnum.RealEnergy ||
                      propType == PropertyTypeEnum.RealFarms ||
                      propType == PropertyTypeEnum.RealGeneral ||
                      propType == PropertyTypeEnum.RealListed) &&
                     (method == DeprMethodTypeEnum.MacrsFormula) &&
                     (Pct == 100) &&
                     (EstLife / 100 == 5))
                {
                    ads = 900;
                }
                else
                    if ((propType == PropertyTypeEnum.RealConservation ||
                          propType == PropertyTypeEnum.RealEnergy ||
                          propType == PropertyTypeEnum.RealFarms ||
                          propType == PropertyTypeEnum.RealGeneral ||
                          propType == PropertyTypeEnum.RealListed) &&
                         (method == DeprMethodTypeEnum.AdsSlMacrs) &&
                         (EstLife / 100 == 9))
                    {
                        ads = 900;
                    }
                    else
                        if (propType == PropertyTypeEnum.VintageAccount ||
                             propType == PropertyTypeEnum.Amortizable)
                            ads = 0; //classLife( bpYrsMosDate( 0,0 ) );
                        else
                            if ((propType == PropertyTypeEnum.RealGeneral ||
                                  propType == PropertyTypeEnum.PersonalGeneral) &&
                                  method == DeprMethodTypeEnum.MacrsFormula &&
                                  Pct == 100 &&
                                  EstLife / 100 == 25)
                                ads = 5000; //classLife( bpYrsMosDate( 50,0 ) );
                            else
                                if (propType == PropertyTypeEnum.RealGeneral ||
                                     propType == PropertyTypeEnum.RealListed ||
                                     propType == PropertyTypeEnum.RealConservation ||
                                     propType == PropertyTypeEnum.RealEnergy ||
                                     propType == PropertyTypeEnum.RealFarms ||
                                     propType == PropertyTypeEnum.RealLowIncomeHousing)
                                {
                                    // QinZ: Tax Update 2005.1 ( JOBS Act )
                                    if (EstLife / 100 == 9 || EstLife / 100 == 15)
                                        ads = 3900; //classLife( bpYrsMosDate( 39,0 ) );
                                    else
                                        ads = 4000; //classLife( bpYrsMosDate( 40,0 ) );
                                }
                                else
                                    if (propType == PropertyTypeEnum.PersonalGeneral)
                                    {
                                        if (method == DeprMethodTypeEnum.StraightLine)
                                            ads = 0; //classLife( bpYrsMosDate( 0,0 ) );
                                        else
                                            if (method == DeprMethodTypeEnum.AcrsTable)
                                                ads = 1100; //classLife( bpYrsMosDate( 11,0 ) );
                                            else
                                                ads = 1000; //classLife( bpYrsMosDate( 10,0 ) );
                                    }
                                    else
                                        if (propType == PropertyTypeEnum.PersonalListed)
                                        {
                                            if (method == DeprMethodTypeEnum.AcrsTable)
                                                ads = 1100; //classLife( bpYrsMosDate( 11,0 ) );
                                            else
                                                ads = 1000; //classLife( bpYrsMosDate( 10,0 ) );
                                        }

            ADSLife = ads;
            errorCode = ErrorCode.Valid;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool GetBonusApplicability(short PropType, DateTime PlaceInService, short DeprMethod, short EstLife, out ErrorCode errorCode)
        {
            // If the depreciation method is 'Do Not Depreciate', this method should
            // always return DoesNotApply.
            if ((DeprMethodTypeEnum)DeprMethod == DeprMethodTypeEnum.DoNotDepreciate)
            {
                errorCode = ErrorCode.DoesNotApply;
                return false;
            }

            PropertyTypeEnum propType = (PropertyTypeEnum)(PropType);
            DeprMethodTypeEnum method = (DeprMethodTypeEnum)(DeprMethod);

            //Assets PIS before 1/1/2003 = behavior stays the same as above
            //Assets PIS between 1/1/2003 and 12/31/2006 = Methods SF & SB, Property
            //Types:  P & Q with any life Then Sec 179/Bon field is enabled and
            //treated as Sec 179 (vs bonus)  
            //Assets PIS after 12/31/2006 = Methods SF & SB, Property Types:  Any
            //property type,  Any life  Then Sec 179/Bon field is not enabled 
            if ((PlaceInService >= (new DateTime(2003, 1, 1))) &&
                 (method == DeprMethodTypeEnum.StraightLineFullMonth || method == DeprMethodTypeEnum.StraightLineFullMonth30))
            {
                //GSD 2011.1 extend P, Q for SF, SB through 2011
                //GSD 1/11/13 HR 8
                if (PlaceInService > (new DateTime(2013, 12, 31)))
                {
                    errorCode = ErrorCode.AppliesDontAllowEntry;
                }
                else if ((propType == PropertyTypeEnum.PersonalGeneral || propType == PropertyTypeEnum.PersonalListed))
                {
                    errorCode = ErrorCode.DoesNotApply;
                }
                else
                {
                    errorCode = ErrorCode.AppliesDontAllowEntry;
                }

                return true;
            }

            bpRulebaseTable8 table = new bpRulebaseTable8();
            bpRulebaseTable rulebase = new bpRulebaseTable(table.tableNumber());

            // Build the source code from the data.
            ulong sourceCode = table.buildSourceCode(PropType,
                                                      PlaceInService,
                                                      DeprMethod,
                                                      EstLife);

            // Fetch the target code from the rulebase.
            uint targetCode = 0;
            if (rulebase.fetchTargetCode(sourceCode, out targetCode))
            {
                switch (targetCode)
                {
                    // Bonus applies.
                    case 1:
                        errorCode = ErrorCode.Applies;
                        return true;
                    case 2:
                        errorCode = ErrorCode.AppliesDontAllowEntry;
                        return true;
                }
            }

            // Bonus does not apply.
            errorCode = ErrorCode.DoesNotApply;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool GetS179Applicability(short PropType, DateTime PlaceInService, short DeprMethod, short EstLife, double Limit, out ErrorCode errorCode)
        {
            // If the depreciation method is 'Do Not Depreciate', this method should
            // always return AppliesDontAllowEntry.
            if ((DeprMethodTypeEnum)DeprMethod == DeprMethodTypeEnum.DoNotDepreciate)
            {
                errorCode = ErrorCode.AppliesDontAllowEntry;
                return false;
            }

            PropertyTypeEnum propType = (PropertyTypeEnum)(PropType);
            DeprMethodTypeEnum method = (DeprMethodTypeEnum)(DeprMethod);

            //Tax Update 2009.1: relaxing the R&S applicability rules for 179
            if (propType == PropertyTypeEnum.RealGeneral ||  //R
                propType == PropertyTypeEnum.RealListed)     //S
            {
                errorCode = ErrorCode.Applies;
                return true;
            }

            //GSD 2011.1
            //GSD 2015.1 extend thru 2014
            // KL 2016.1
            if ((PlaceInService >= (new DateTime(2010, 1, 1)) && PlaceInService <= (new DateTime(2999, 12, 31))) &&
                (propType == PropertyTypeEnum.RealConservation ||
                 propType == PropertyTypeEnum.RealEnergy ||
                 propType == PropertyTypeEnum.RealFarms))
            {
                errorCode = ErrorCode.Applies;
                return true;
            }

            //Assets PIS before 1/1/2003 = behavior stays the same as above
            //Assets PIS between 1/1/2003 and 12/31/2006 = Methods SF & SB, Property
            //Types:  P & Q with any life Then Sec 179/Bon field is enabled and
            //treated as Sec 179 (vs bonus)  
            //Assets PIS after 12/31/2006 = Methods SF & SB, Property Types:  Any
            //property type,  Any life  Then Sec 179/Bon field is not enabled 

            if ((PlaceInService >= (new DateTime(2003, 1, 1))) &&
                 (method == DeprMethodTypeEnum.StraightLineFullMonth || method == DeprMethodTypeEnum.StraightLineFullMonth30))
            {
                //GSD 11/8/11 Defect 5454 - updated the date here
                //GSD 1/11/13 HR 8
                if (PlaceInService > (new DateTime(2013, 12, 31)))
                {
                    errorCode = ErrorCode.DoesNotApply;
                }
                else if ((propType == PropertyTypeEnum.PersonalGeneral || propType == PropertyTypeEnum.PersonalListed))
                {
                    errorCode = ErrorCode.Applies;
                }
                else
                {
                    errorCode = ErrorCode.DoesNotApply;
                }

                return true;
            }

            bpRulebaseTable8 table = new bpRulebaseTable8();
            bpRulebaseTable rulebase = new bpRulebaseTable(table.tableNumber());

            // Build the source code from the data.
            ulong sourceCode = table.buildSourceCode(PropType,
                                                      PlaceInService,
                                                      DeprMethod,
                                                      EstLife);

            // Fetch the target code from the rulebase.
            uint targetCode = 0;
            if (rulebase.fetchTargetCode(sourceCode, out targetCode))
            {
                switch (targetCode)
                {
                    // Section 179 applies.
                    case 3:
                        // if the limit is zero, s179 still applies, but don't allow entry.
                        if (Limit == 0.0)
                        {
                            errorCode = ErrorCode.AppliesDontAllowEntry;
                            return true;
                        }
                        errorCode = ErrorCode.Applies;
                        return true;

                    case 4:
                        errorCode = ErrorCode.AppliesDontAllowEntry;
                        return true;
                }
            }

            // section 179 does not apply.
            errorCode = ErrorCode.DoesNotApply;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool ValidateBusinessUse(short DeprMethod, int Pct, out ErrorCode errorCode)
        {
            bpRulebaseTable7 table = new bpRulebaseTable7();
            bpRulebaseTable rulebase = new bpRulebaseTable(table.tableNumber());

            errorCode = ErrorCode.Valid;

            // Build the source code from the data.
            ulong sourceCode = table.buildSourceCode(DeprMethod, (uint)Pct);

            // Fetch the target code from the rulebase.  If there is one and it's
            // not values 2 or 3, return a true.  Otherwise return a false.
            uint targetCode = 0;
            if (rulebase.fetchTargetCode(sourceCode, out targetCode))
                if (targetCode != 2 && targetCode != 3)
                    return true;

            errorCode = ErrorCode.Invalid;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool ValidatePlaceInService(short PropType, DateTime PlaceInService, DateTime StartOfBusiness, out ErrorCode errorCode)
        {
            if (PlaceInService <= DateTime.MinValue)
            {
                errorCode = ErrorCode.InvalDateValue;
                return false;
            }

            // See if date is prior to start of business date.
            if (PlaceInService < StartOfBusiness)
            {
                errorCode = ErrorCode.DateInvalBeforeStartBusiness;
                return false;
            }

            // See if date is prior to 1920.  Nobody has assets we care about back then.
            if (PlaceInService < (new DateTime(1920, 1, 1)))
            {
                errorCode = ErrorCode.DateInvalBefore1920;
                return false;
            }

            //// See if date is after 2999. Too far to care.
            if (PlaceInService > (new DateTime(2999, 12, 31)))
            {
                errorCode = ErrorCode.DateInvalAfter2999;
                return false;
            }

            // Create a object for Rulebase #2.
            bpRulebaseTable2 rule = new bpRulebaseTable2();

            // Ask the rulebase for the source code.
            ulong sourceCode = rule.buildSourceCode(PropType, PlaceInService);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            uint targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
            {
                switch (targetCode)
                {
                    case 1:
                        errorCode = ErrorCode.Valid;
                        return true;
                    case 2:
                        errorCode = ErrorCode.LowIncHousingInvalBefore1981;
                        return false;
                    case 3:
                        errorCode = ErrorCode.ListedPropInvalBeforeJune191984;
                        return false;
                    case 4:
                        errorCode = ErrorCode.LowIncHousingInvalAfter1986;
                        return false;
                    case 5:
                        errorCode = ErrorCode.AutoPropInvalBeforeJune191984;
                        return false;
                    case 6:
                        errorCode = ErrorCode.LtTrucksAndVansPropInvalBefore2003;
                        return false;
                }
            }

            errorCode = ErrorCode.RuleBaseFailure;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool AllowMidQuarter(short PropType, short DeprMethod, bool hasBeginningDate, out ErrorCode errorCode)
        {
            bpRulebaseTable9 table = new bpRulebaseTable9();
            bpRulebaseTable rulebase = new bpRulebaseTable(table.tableNumber());

            // Build the source code from the data.
            ulong sourceCode = table.buildSourceCode(PropType, DeprMethod, hasBeginningDate);

            // Fetch the target code from the rulebase.
            uint targetCode = 0;
            errorCode = ErrorCode.RuleBaseFailure;

            if (rulebase.fetchTargetCode(sourceCode, out targetCode))
            {
                if (targetCode == 2)
                    errorCode = ErrorCode.Valid;
                else
                    errorCode = ErrorCode.Invalid;
            }

            return (errorCode == ErrorCode.Valid) ? true : false;
        }

        /*
        //  -------------------------------------------------------------------------
        public bool ForceBookDefaults(IbpDepreciableAsset asset, out ErrorCode errorCode)
        {
            bool hasTax = false;
            bool hasInternal = false;
            bool hasState = false;
            bool hasAMT = false;
            bool hasACE = false;
            bool hasUserBook = false;

            IbpDepreciableAssetExtension ext = null;
            object disp = null;

            // make sure book defaults can be done at all.
            if (IsForceDefaultsAvailable(asset, out errorCode) != true || errorCode != ErrorCode.Valid)
                return false;

            hasTax = asset.get_HasOpenBookOfType(bpBookTypeEnum.TaxBook);
            hasInternal = asset.get_HasOpenBookOfType(bpBookTypeEnum.InternalBook);
            hasState = asset.get_HasOpenBookOfType(bpBookTypeEnum.StateBook);
            hasAMT = asset.get_HasOpenBookOfType(bpBookTypeEnum.AMTBook);
            hasACE = asset.get_HasOpenBookOfType(bpBookTypeEnum.ACEBook);
            hasUserBook = asset.get_HasOpenBookOfType(bpBookTypeEnum.UserBook);

            ext = asset.LastAssetExtension as IbpDepreciableAssetExtension;

            if (ext == null)
            {
                return false;
            }

            // if tax is open, default all open books from tax.
            if (hasTax)
            {
                IbpEnumDispatch ei = null;
                IbpDepreciableBookAsset taxBook = null;
                object ba1 = null;
                int count;

                // Get the tax book info.
                ei = ext.get_BookListOfType(bpBookTypeEnum.TaxBook) as IbpEnumDispatch;
                if (ei != null)
                {
                    ei.Reset();

                    ei.Next(1, out disp, out count);
                    if (disp != null && count > 0)
                    {
                        taxBook = disp as IbpDepreciableBookAsset;

                        ei.Next(1, out ba1, out count);
                        if (ba1 != null && count > 0)
                        {
                            //
                            // We have multiple Tax books, what do we do???
                            //
                        }
                    }

                }
                ei.RemoveAll();
                COMSupport.RELEASE(ei);


                // Default the State book.
                ei = ext.get_BookListOfType(bpBookTypeEnum.StateBook) as IbpEnumDispatch;
                if (ei != null)
                {
                    IbpDepreciableBookAsset Book = null;
                    ei.Reset();

                    do
                    {
                        ei.Next(1, out disp, out count);
                        if (disp != null && count > 0)
                        {
                            Book = disp as IbpDepreciableBookAsset;
                            ForceDefaultsForStateBook(asset, taxBook, Book, out errorCode);
                            COMSupport.RELEASE(Book);
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                }
                ei.RemoveAll();
                COMSupport.RELEASE(ei);

                IbpDepreciableBookAsset firstAMT = null;
                // Default the AMT book.
                ei = ext.get_BookListOfType(bpBookTypeEnum.AMTBook) as IbpEnumDispatch;
                if (ei != null)
                {
                    IbpDepreciableBookAsset Book = null;
                    ei.Reset();
                    do
                    {
                        ei.Next(1, out disp, out count);
                        if (disp != null && count > 0)
                        {
                            Book = disp as IbpDepreciableBookAsset;

                            if (firstAMT == null)
                            {
                                firstAMT = Book;
                            }
                            ForceDefaultsForAMTBook(asset, taxBook, Book, out errorCode);
                            COMSupport.RELEASE(Book);
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                }
                ei.RemoveAll();
                COMSupport.RELEASE(ei);

                // Default the ACE book.  Note that we need to AMT book to be open to
                // properly default the ACE book.
                if (firstAMT != null)
                {
                    ei = ext.get_BookListOfType(bpBookTypeEnum.ACEBook) as IbpEnumDispatch;
                    if (ei != null)
                    {
                        IbpDepreciableBookAsset Book = null;
                        ei.Reset();
                        do
                        {
                            ei.Next(1, out disp, out count);
                            if (disp != null && count > 0)
                            {
                                Book = disp as IbpDepreciableBookAsset;
                                ForceDefaultsForACEBook(asset, taxBook, firstAMT, Book, out errorCode);
                                COMSupport.RELEASE(Book);
                            }
                            else
                            {
                                break;
                            }
                        } while (true);

                    }
                    ei.RemoveAll();
                    COMSupport.RELEASE(ei);
                    COMSupport.RELEASE(firstAMT);
                }

                // Default the Internal book.
                if (hasInternal)
                {
                    DoEmulatedBooks(asset, ext, taxBook, bpBookTypeEnum.InternalBook);
                }

                // Default the User Book books.
                if (hasUserBook)
                {
                    DoEmulatedBooks(asset, ext, taxBook, bpBookTypeEnum.UserBook);
                }
                COMSupport.RELEASE(taxBook);
            }
            else
            {
                // if internal is open (and tax is closed), default books user1 and user2 from
                // internal.  default no other books.
                if (hasInternal)
                {
                    IbpDepreciableBookAsset internalBook = null;
                    object ba1 = null;
                    IbpEnumDispatch ei = null;
                    int count;

                    // Get the internal book info.
                    ei = ext.get_BookListOfType(bpBookTypeEnum.InternalBook) as IbpEnumDispatch;
                    if (ei != null)
                    {
                        ei.Reset();
                        ei.Next(1, out disp, out count);
                        if (disp != null && count > 0)
                        {
                            internalBook = disp as IbpDepreciableBookAsset;

                            ei.Next(1, out ba1, out count);
                            if (ba1 != null && count > 0)
                            {
                                COMSupport.RELEASE(ba1);
                                //
                                // We have multiple Internal books, what do we do???
                                //
                            }
                        }

                    }
                    ei.RemoveAll();
                    COMSupport.RELEASE(ei);

                    // Default the User Books.
                    ei = ext.get_BookListOfType(bpBookTypeEnum.UserBook) as IbpEnumDispatch;
                    if (ei != null)
                    {
                        IbpDepreciableBookAsset Book = null;
                        ei.Reset();
                        do
                        {
                            ei.Next(1, out disp, out count);
                            if (disp != null && count > 0)
                            {
                                Book = disp as IbpDepreciableBookAsset;
                                ForceDefaultsForInternalBook(asset, internalBook, Book, out errorCode);
                                COMSupport.RELEASE(Book);
                            }
                            else
                            {
                                break;
                            }
                        } while (true);

                    }
                    ei.RemoveAll();
                    COMSupport.RELEASE(ei);

                    COMSupport.RELEASE(internalBook);
                }
                else
                {
                    COMSupport.RELEASE(ext);
                    return false;
                }
            }
            // Return indicator of successful book defaulting.
            COMSupport.RELEASE(ext);

            return true;
        }

        //  -------------------------------------------------------------------------
        public bool IsForceDefaultsAvailable(IbpDepreciableAsset asset, out ErrorCode errorCode)
        {
            bool hasTax = false;
            bool hasInternal = false;
            bool hasState = false;
            bool hasAMT = false;
            bool hasACE = false;
            bool hasUserBook = false;

            bestAssetActivityTypeEnum ActivityCode;
            IbpDepreciableAssetExtension ext = null;
            object disp = null;

            errorCode = ErrorCode.Invalid;

            ext = asset.LastAssetExtension as IbpDepreciableAssetExtension;

            if (ext == null)
            {
                return false;
            }

            ActivityCode = ext.ActivityCode;

            hasTax = asset.get_HasOpenBookOfType(bpBookTypeEnum.TaxBook);
            hasInternal = asset.get_HasOpenBookOfType(bpBookTypeEnum.InternalBook);
            hasState = asset.get_HasOpenBookOfType(bpBookTypeEnum.StateBook);
            hasAMT = asset.get_HasOpenBookOfType(bpBookTypeEnum.AMTBook);
            hasACE = asset.get_HasOpenBookOfType(bpBookTypeEnum.ACEBook);
            hasUserBook = asset.get_HasOpenBookOfType(bpBookTypeEnum.UserBook);

            if (ActivityCode == bestAssetActivityTypeEnum.acActive && (hasTax || hasInternal || hasState || hasAMT || hasACE || hasUserBook))
            {
                // if tax is open, are any other books open?
                if (hasTax && !hasInternal && !hasState && !hasAMT && !hasACE && !hasUserBook)
                {
                    errorCode = ErrorCode.Invalid;
                }
                else if (!hasTax && hasInternal && !hasUserBook)
                {
                    errorCode = ErrorCode.Invalid;
                }
                else if (hasTax)
                {
                    DateTime PISDate = DateTime.MinValue;

                    IbpEnumDispatch ei = null;
                    IbpDepreciableBookAsset ba = null;
                    int count;

                    ei = ext.get_BookListOfType(bpBookTypeEnum.TaxBook) as IbpEnumDispatch;
                    if (ei != null)
                    {
                        ei.Reset();
                        ei.Next(1, out disp, out count);
                        if (disp != null && count > 0)
                        {
                            ba = disp as IbpDepreciableBookAsset;

                            PISDate = ba.PlacedInService;
                            COMSupport.RELEASE(ba);
                        }

                        ei.Next(1, out disp, out count);
                        if (disp != null && count > 0)
                        {

                            //
                            // We have multiple Tax books, what do we do???
                            //
                        }

                        ei.RemoveAll();
                        COMSupport.RELEASE(ei);
                    }
                    // if tax is open, is the tax placed in service date valid?
                    if (PISDate > DateTime.MinValue)
                    {
                        errorCode = ErrorCode.Valid;
                    }
                }
                else
                {
                    DateTime PISDate = DateTime.MinValue;

                    IbpEnumDispatch ei = null;
                    IbpDepreciableBookAsset ba = null;
                    int count;

                    ei = ext.get_BookListOfType(bpBookTypeEnum.InternalBook) as IbpEnumDispatch;
                    if (ei != null)
                    {
                        ei.Reset();
                        ei.Next(1, out disp, out count);

                        if (disp != null && count > 0)
                        {
                            ba = disp as IbpDepreciableBookAsset;
                            PISDate = ba.PlacedInService;
                            COMSupport.RELEASE(ba);
                        }

                        ei.Next(1, out disp, out count);
                        if (disp != null && count > 0)
                        {
                            //
                            // We have multiple Internal books, what do we do???
                            //
                        }
                        ei.RemoveAll();
                        COMSupport.RELEASE(ei);
                    }
                    // if Internal is open, is the Internal placed in service date valid?
                    if (PISDate > DateTime.MinValue)
                    {
                        errorCode = ErrorCode.Valid;
                    }
                }
            }

            COMSupport.RELEASE(ext);

            return (errorCode == ErrorCode.Valid) ? true : false;
        }

        //  -------------------------------------------------------------------------
        public bool ForceDefaultsForInternalBook(IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook, out ErrorCode errorCode)
        {
            // Fetch the target code that tells us how to default.
            uint tCode = 0;
            ErrorCode tmpError;
            short estLife;
            bestAssetDeprMethodTypeEnum meth;
            DateTime PlacedInService;
            bestAssetPropertyTypeEnum propType;

            errorCode = ErrorCode.RuleBaseFailure;

            {
                ulong sourceCode = 0;
                short pct;
                short classLife;
                short bonus911pct;

                propType = core.PropType;
                meth = sourceBook.DeprMethod;
                pct = sourceBook.DeprPercent;
                estLife = sourceBook.EstimatedLife;
                bonus911pct = sourceBook.Bonus911Percent;
                classLife = core.ADSLife;

                buildSourceCode12((short)propType, (short)meth, (uint)pct, estLife, classLife, ref sourceCode, ref tCode);

            }

            // Pre-initialize the book with the source book. We will overwrite selected information
            // as need be.
            destBook.copyFrom(sourceBook);

            // Clear out the depreciation percentage and switch state.  They are not to be copied.
            destBook.DeprPercent = (0);
            destBook.DeprSwitch = (bestAssetDeprSwitchTypeEnum.dsDontSwitch);

            // The target code is a two-part code.  Handle the first part now.
            _handlePart1Internal(tCode, core, sourceBook, destBook);

            estLife = destBook.EstimatedLife;
            meth = destBook.DeprMethod;
            PlacedInService = destBook.PlacedInService;

            // see if s179/bonus should be copied over.
            GetBonusApplicability((short)propType, PlacedInService, (short)meth, estLife, out tmpError);
            destBook.IsBonus = (tmpError == ErrorCode.Applies || tmpError == ErrorCode.AppliesDontAllowEntry);

            {
                bool srcBonus, dstBonus;
                double value;

                srcBonus = sourceBook.IsBonus;
                dstBonus = destBook.IsBonus;
                if (srcBonus == dstBonus)
                {
                    if (dstBonus)
                    {
                        value = sourceBook.BonusAmount;
                        destBook.BonusAmount = (value);
                    }
                    else
                    {
                        value = sourceBook.S179Amount;
                        destBook.S179Amount = (value);
                    }
                }
                else
                {
                    destBook.BonusAmount = (0);
                    destBook.S179Amount = (0);
                }
            }

            //destBook.section179BcdoCd('N');
            //destBook.section179BcdoAmt(0.0);

            // Now, handle the second part.
            _handlePart2Internal(tCode, sourceBook, destBook);

            errorCode = ErrorCode.Valid;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool ForceDefaultsForStateBook(IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook, out ErrorCode errorCode)
        {
            // State book defaults are simple.  Copy over all of the information
            // from the source book.
            errorCode = ErrorCode.Valid;

            // Pre-initialize the book with the source book. We will overwrite selected information
            // as need be.
            destBook.copyFrom(sourceBook);

            // Perform special handling of business use.
            handleBusinessUseLogic(sourceBook, destBook);

            // Perform special handling of beg depr.
            destBook.handleBegDeprLogic(sourceBook);

            _handlePct168k(sourceBook, destBook);

            return true;
        }

        //  -------------------------------------------------------------------------
        public bool ForceDefaultsForAMTBook(IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook, out ErrorCode errorCode)
        {
            // Fetch the target code that tells us how to default.
            uint tCode = 0;
            short estLife;
            bestAssetDeprMethodTypeEnum meth;
            DateTime PlacedInService;
            bestAssetPropertyTypeEnum propType;
            ErrorCode tmpError;

            errorCode = ErrorCode.RuleBaseFailure;
            // Fetch the target code that tells us how to default.
            {
                ulong sourceCode = 0;
                short pct;

                propType = core.PropType;
                meth = sourceBook.DeprMethod;
                pct = sourceBook.DeprPercent;
                estLife = sourceBook.EstimatedLife;
                PlacedInService = sourceBook.PlacedInService;

                buildSourceCode14((short)propType, PlacedInService, (short)meth, (uint)pct, estLife, ref sourceCode, ref tCode);
            }

            // Pre-initialize the book with the source book. We will overwrite selected information
            // as need be.
            destBook.copyFrom(sourceBook);


            // Clear out the depreciation percentage and switch state.  They are not to be copied.
            destBook.DeprPercent = (0);
            destBook.DeprSwitch = (bestAssetDeprSwitchTypeEnum.dsDontSwitch);

            // The target code is a two-part code.  Handle the first part now.
            _handlePart1AMT(tCode, core, sourceBook, destBook);

            // see if s179/bonus should be copied over.
            GetBonusApplicability((short)propType, PlacedInService, (short)meth, estLife, out tmpError);

            //GSD 2011.1
            //GSD 12/16/10 - if we're RSCEF, and the source book says bonus is on (isS179 = F) with 0.0 amount,
            //then ignore the bonus applicability and just make sure that the isS179 flag stays the same as the source book
            bool srcBonusCheck;
            double valueCheck;
            srcBonusCheck = sourceBook.IsBonus;
            valueCheck = sourceBook.BonusAmount;
            if ((propType == (bestAssetPropertyTypeEnum)PropertyTypeEnum.RealConservation ||
                  propType == (bestAssetPropertyTypeEnum)PropertyTypeEnum.RealEnergy ||
                  propType == (bestAssetPropertyTypeEnum)PropertyTypeEnum.RealFarms ||
                  propType == (bestAssetPropertyTypeEnum)PropertyTypeEnum.RealGeneral ||
                  propType == (bestAssetPropertyTypeEnum)PropertyTypeEnum.RealListed) && srcBonusCheck == true &&
                  valueCheck == 0.0)
            {
                destBook.IsBonus = (srcBonusCheck);
            }
            else
            {
                destBook.IsBonus = (tmpError == ErrorCode.Applies || tmpError == ErrorCode.AppliesDontAllowEntry);
            }

            {
                bool srcBonus, dstBonus;
                double value;

                srcBonus = sourceBook.IsBonus;
                dstBonus = destBook.IsBonus;
                if (srcBonus == dstBonus)
                {
                    if (dstBonus)
                    {
                        value = sourceBook.BonusAmount;
                        destBook.BonusAmount = (value);
                    }
                    else
                    {
                        value = sourceBook.S179Amount;
                        destBook.S179Amount = (value);
                    }
                }
                else
                {
                    destBook.BonusAmount = (0);
                    destBook.S179Amount = (0);
                }
            }

            //destBook.section179BcdoCd('N');
            //destBook.section179BcdoAmt(0.0);

            // Now, handle the second part.
            _handlePart2AMT(sourceBook, destBook);
            errorCode = ErrorCode.Valid;

            _handlePct168k(sourceBook, destBook);

            return true;
        }

        //  -------------------------------------------------------------------------
        public bool ForceDefaultsForACEBook(IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset AMTBook, IbpDepreciableBookAsset destBook, out ErrorCode errorCode)
        {
            // Fetch the target code that tells us how to default.
            uint ACECode = 0;
            uint AMTCode = 0;
            ErrorCode tmpError;
            short estLife;
            bestAssetDeprMethodTypeEnum meth;
            DateTime PlacedInService;
            bestAssetPropertyTypeEnum propType;

            errorCode = ErrorCode.RuleBaseFailure;

            // Fetch the target code that tells us how to default.
            {
                ulong sourceCode = 0;
                short pct;
                short classLife;
                DateTime fyEnd;

                propType = core.PropType;
                meth = sourceBook.DeprMethod;
                pct = sourceBook.DeprPercent;
                estLife = sourceBook.EstimatedLife;
                classLife = core.ADSLife;
                PlacedInService = sourceBook.PlacedInService;
                fyEnd = destBook.get_FiscalYearEnd(new DateTime(1989, 12, 1));

                buildSourceCode13(fyEnd, (short)propType, PlacedInService, (short)meth, (short)pct, estLife, ref sourceCode, ref ACECode);
                buildSourceCode14((short)propType, PlacedInService, (short)meth, (uint)pct, estLife, ref sourceCode, ref AMTCode);
            }

            {
                bpBookTypeEnum bookType = AMTBook.BookType;

                if (bookType != bpBookTypeEnum.AMTBook)
                {
                    errorCode = ErrorCode.Invalid;
                    return false;
                }
            }

            // ACE no longer applies after 12/31/1993, so force book to defaults.  Then
            // just copy over the acquired value and placed in service date info from
            // the source book.

            //HP 95 TAX UPDATE
            if (PlacedInService > new DateTime(1993, 12, 31))
            {
                //         defaults();
                //HP         placedInService( sourceBook.placedInService() );
                //HP         acquiredValue( sourceBook.acquiredValue() );
                //HP         return true;
            }

            // Pre-initialize the book with the source book. We will overwrite selected information
            // as need be.
            destBook.copyFrom(sourceBook);

            // Clear out the depreciation percentage and switch state.  They are not to be copied.
            destBook.DeprPercent = (0);
            destBook.DeprSwitch = (bestAssetDeprSwitchTypeEnum.dsDontSwitch);

            //HP 95 TAX UPDATE
            if (PlacedInService > (new DateTime(1993, 12, 31)))
            {
                bpBookTypeEnum bookTypeToEmulate;

                _handlePart1ACE_LikeAMT(AMTCode, core, sourceBook, destBook);
                bookTypeToEmulate = destBook.BookTypeToEmulate;

                if (bookTypeToEmulate != bpBookTypeEnum.AMTBook)
                {
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmDoNotDepreciate);
                    destBook.DeprPercent = (0);
                }
            }
            else
                // The target code is a two-part code.  Handle the first part now.
                _handlePart1ACE(ACECode, core, sourceBook, AMTBook, destBook);

            // see if s179/bonus should be copied over.
            GetBonusApplicability((short)propType, PlacedInService, (short)meth, estLife, out tmpError);
            destBook.IsBonus = (tmpError == ErrorCode.Applies || tmpError == ErrorCode.AppliesDontAllowEntry);

            {
                bool srcBonus, dstBonus;
                double value;

                srcBonus = sourceBook.IsBonus;
                dstBonus = destBook.IsBonus;
                if (srcBonus == dstBonus)
                {
                    if (dstBonus)
                    {
                        value = sourceBook.BonusAmount;
                        destBook.BonusAmount = (value);
                    }
                    else
                    {
                        value = sourceBook.S179Amount;
                        destBook.S179Amount = (value);
                    }
                }
                else
                {
                    destBook.BonusAmount = (0);
                    destBook.S179Amount = (0);
                }
            }

            //destBook.section179BcdoCd('N');
            //destBook.section179BcdoAmt(0.0);

            // Now, handle the second part.
            _handlePart2AMT(sourceBook, destBook);
            errorCode = ErrorCode.Valid;

            _handlePct168k(sourceBook, destBook);

            return true;
        }

        //  -------------------------------------------------------------------------
        static bool isDateAfterTaxableYear(DateTime date, short year, IbpDepreciableBookAsset book)
        {
            DateTime fyEnd;

            fyEnd = (new DateTime(year, 12, 24));
            fyEnd = book.get_FiscalYearEnd(fyEnd);
            return (date > fyEnd);
        }

        //  -------------------------------------------------------------------------
        public bool GetSection179Limit(PropertyTypeEnum propType, IbpDepreciableBookAsset book, DateTime date, out double value)
        {
            value = 0;

            if (propType == PropertyTypeEnum.Automobile || propType == PropertyTypeEnum.LtTrucksAndVans)
            {
                // The limits for each date range are time dependent and need to be
                // updated each fiscal year (tax update time).

                if (propType == PropertyTypeEnum.Automobile ||
                      date <= (new DateTime(2002, 12, 31)))
                {
                    if (date < (new DateTime(1984, 6, 19)))
                        value = 0.0;
                    else
                        if (date <= (new DateTime(1984, 12, 31)))
                            value = 4000.0;
                        else
                            if (date <= (new DateTime(1985, 4, 2)))
                                value = 4100.0;
                            else
                                if (date <= (new DateTime(1986, 12, 31)))
                                    value = 3200.0;
                                else
                                    if (date <= (new DateTime(1988, 12, 31)))
                                        value = 2560.0;
                                    else
                                        if (date <= (new DateTime(1991, 12, 31)))
                                            value = 2660.0;
                                        else
                                            if (date <= (new DateTime(1992, 12, 31)))
                                                value = 2760.0;
                                            else
                                                if (date <= (new DateTime(1993, 12, 31)))  // RWH - 95.1 Tax Changes
                                                    value = 2860.0;
                                                else
                                                    if (date <= (new DateTime(1994, 12, 31)))  // RWH - 95.1 Tax Changes
                                                        value = 2960.0;
                                                    else
                                                        if (date <= (new DateTime(1996, 12, 31)))  // RWH - 95.1 Tax Changes
                                                            value = 3060.0;                                 // RWH - 95.1 Tax Changes
                                                        else
                                                            if (date <= (new DateTime(1998, 12, 31)))  // MJB - 99.1 Tax Changes
                                                                value = 3160.0;
                                                            else
                                                                if (date <= (new DateTime(2003, 12, 31)))  // MJB - 99.1 Tax Changes
                                                                    value = 3060.0;
                                                                else
                                                                    value = 2960.0;
                }
                else // new property type: LtTrucksAndVans
                {
                    if (date <= (new DateTime(2003, 12, 31)))
                        value = 3360.0;
                    else // after 12/31/2003
                        value = 3260.0;
                }

                bestAssetDeprMethodTypeEnum meth;

                meth = book.DeprMethod;

                if (meth == bestAssetDeprMethodTypeEnum.dmAdsSlMacrs30 ||
                     meth == bestAssetDeprMethodTypeEnum.dmStraightLineFullMonth30 ||
                     meth == bestAssetDeprMethodTypeEnum.dmMacrsFormula30 ||
                     meth == bestAssetDeprMethodTypeEnum.dmMACRSIndianReservation30)
                {
                    //if pisdate is between May 6,2003 and Dec 31 2005,  add 7650.00, otherwise add 4600 to the standard limit.
                    value += (date > (new DateTime(2003, 5, 5)) && date <= (new DateTime(2004, 12, 31))) ? 7650.0 : 4600.0;
                }
                return true;
            }
            else
            {
                if (date > (new DateTime(1992, 12, 31)))
                {
                    if (isDateAfterTaxableYear(date, 2007, book))
                        value = 25000.0;
                    else if (isDateAfterTaxableYear(date, 2004, book))
                        value = 105000.0;
                    else if (isDateAfterTaxableYear(date, 2003, book))
                        value = 102000.0;
                    else if (isDateAfterTaxableYear(date, 2002, book))
                        value = 100000.0;
                    else if (isDateAfterTaxableYear(date, 2000, book))
                        value = 24000.0;
                    else if (isDateAfterTaxableYear(date, 1999, book))
                        value = 20000.0;
                    else if (isDateAfterTaxableYear(date, 1998, book))
                        value = 19000.0;
                    else if (isDateAfterTaxableYear(date, 1997, book))
                        value = 18500.0;
                    else if (isDateAfterTaxableYear(date, 1996, book))
                        value = 18000.0;
                    else if (isDateAfterTaxableYear(date, 1992, book))
                        value = 17500.0;
                }

                if (value == 0)
                {
                    if (date < (new DateTime(1987, 1, 1)))
                        value = 5000.0;
                    else
                        value = 10000.0;
                }

                value += _getExtraS179Amount(book, date);

                return true;
            }
        }

        double _getExtraS179Amount(IbpDepreciableBookAsset book, DateTime date)
        {
            double value = 0.0;
            bestAssetDeprMethodTypeEnum meth;

            meth = book.DeprMethod;


            if (meth == bestAssetDeprMethodTypeEnum.dmMacrsFormula ||
                 meth == bestAssetDeprMethodTypeEnum.dmMacrsTable ||
                 meth == bestAssetDeprMethodTypeEnum.dmMACRSIndianReservation ||
                 meth == bestAssetDeprMethodTypeEnum.dmMacrsFormula30 ||
                 meth == bestAssetDeprMethodTypeEnum.dmMACRSIndianReservation30)
            {
                if (date > (new DateTime(1992, 12, 31)))
                {
                    if (isDateAfterTaxableYear(date, 2006, book)) // start MJB 97.1 Tax Update
                        value = 20000.0;
                    else if (isDateAfterTaxableYear(date, 2000, book))
                        value = 35000.0;
                    else if (isDateAfterTaxableYear(date, 1992, book))
                        value = 20000.0;
                }
            }
            else
            {
                value = 0.0;
            }
            return value;
        }

        */

        //IbpOleBasicRuleBase

        public bool BuildITCList(DateTime PlaceInService, DeprMethodTypeEnum DeprMethod, out List<int> list)
        {
            return BuildITCList(PlaceInService, (short)DeprMethod, out list);
        }

        //  -------------------------------------------------------------------------
        public bool ValidateITC(PropertyTypeEnum PropType, DateTime PlaceInService, DeprMethodTypeEnum DeprMethod, short EstimatedLife, bpITCTypeEnum ITCType, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;
            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = ValidateITC((short)PropType, PlaceInService, (short)DeprMethod, (short)EstimatedLife, (short)ITCType, out retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool GetDefaultITCPercent(PropertyTypeEnum PropType, DateTime PlaceInService, DeprMethodTypeEnum DeprMethod, short EstimatedLife, bpITCTypeEnum ITCOption, ref double ITCPct, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;
            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = GetDefaultITCPercent((short)PropType, PlaceInService, (short)DeprMethod, (short)EstimatedLife, (short)ITCOption, ref ITCPct, out  retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        public bool BuildDeprMethodList(PropertyTypeEnum PropType, DateTime PlaceInService, bool IsShortYear, out List<int> list)
        {
            return BuildDeprMethodList((short)PropType, PlaceInService, IsShortYear, out list);
        }

        //  -------------------------------------------------------------------------
        public bool ValidateDeprMethod(PropertyTypeEnum PropType, DateTime PlaceInService, DeprMethodTypeEnum DeprMethod, bool IsShortYear, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;

            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = ValidateDeprMethod((short)PropType, PlaceInService, (short)DeprMethod, IsShortYear, out  retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool GetDefaultDeprMethod(PropertyTypeEnum PropType, DateTime PlaceInService, ref DeprMethodTypeEnum DeprMethod, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;
            short sDeprMethod;

            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            DeprMethod = DeprMethodTypeEnum.InvalidDeprMethod;

            if (!(hr = GetDefaultDeprMethod((short)PropType, PlaceInService, out sDeprMethod, out  retVal)))
            {
                return hr;
            }
            DeprMethod = (DeprMethodTypeEnum)sDeprMethod;
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        public bool BuildDeprPercentList(PropertyTypeEnum PropType, DateTime PlaceInService, DeprMethodTypeEnum DeprMethod, out List<int> list)
        {
            return BuildDeprPercentList((short)PropType, PlaceInService, (short)DeprMethod, out list);
        }

        public bool BuildEstimatedLifeList(PropertyTypeEnum PropType, DateTime PlaceInService, DeprMethodTypeEnum DeprMethod, int Pct, out List<int> list)
        {
            return BuildEstimatedLifeList((short)PropType, PlaceInService, (short)DeprMethod, Pct, out list);
        }

        //  -------------------------------------------------------------------------
        public bool ValidateEstimatedLife(PropertyTypeEnum PropType, DateTime PlaceInService, DeprMethodTypeEnum DeprMethod, int Pct, short EstLife, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;

            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = ValidateEstimatedLife((short)PropType, PlaceInService, (short)DeprMethod, Pct, EstLife, out  retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool GetDefaultEstimatedLife(PropertyTypeEnum PropType, DateTime PlaceInService, DeprMethodTypeEnum DeprMethod, int Pct, ref short EstLife, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;

            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = GetDefaultEstimatedLife((short)PropType, PlaceInService, (short)DeprMethod, Pct, ref EstLife, out  retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool GetDefaultADSLife(PropertyTypeEnum PropType, DeprMethodTypeEnum DeprMethod, int Pct, short EstLife, ref short ADSLife, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;

            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = GetDefaultADSLife((short)PropType, (short)DeprMethod, Pct, EstLife, ref ADSLife, out  retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool GetBonusApplicability(PropertyTypeEnum PropType, DateTime PlaceInService, DeprMethodTypeEnum DeprMethod, short EstLife, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;

            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = GetBonusApplicability((short)PropType, PlaceInService, (short)DeprMethod, EstLife, out  retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool GetS179Applicability(PropertyTypeEnum PropType, DateTime PlaceInService, DeprMethodTypeEnum DeprMethod, short EstLife, double Limit, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;

            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = GetS179Applicability((short)PropType, PlaceInService, (short)DeprMethod, EstLife, Limit, out  retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool ValidateBusinessUse(DeprMethodTypeEnum DeprMethod, int Pct, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;

            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = ValidateBusinessUse((short)DeprMethod, Pct, out  retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool ValidatePlaceInService(PropertyTypeEnum PropType, DateTime PlaceInService, DateTime StartOfBusiness, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr;

            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = ValidatePlaceInService((short)PropType, PlaceInService, StartOfBusiness, out  retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool AllowMidQuarter(PropertyTypeEnum PropType, DeprMethodTypeEnum DeprMethod, bool hasBeginningDate, out RuleBase_ErrorCodeEnum errorCode)
        {
            ErrorCode retVal;
            bool hr = true;

            errorCode = RuleBase_ErrorCodeEnum.rulebase_Valid;

            if (!(hr = AllowMidQuarter((short)PropType, (short)DeprMethod, hasBeginningDate, out  retVal)))
            {
                return hr;
            }
            errorCode = (RuleBase_ErrorCodeEnum)retVal;
            return true;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode1(short PropType, DateTime PlaceInService, short DeprMethod, short EstLife, short itcOption, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #1.
            bpRulebaseTable1 rule = new bpRulebaseTable1();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, PlaceInService, DeprMethod, EstLife, itcOption);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode2(short PropType, DateTime PlaceInService, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #2.
            bpRulebaseTable2 rule = new bpRulebaseTable2();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, PlaceInService);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode3(short PropType, DateTime PlaceInService, short DeprMethod, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #3.
            bpRulebaseTable3 rule = new bpRulebaseTable3();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, PlaceInService, DeprMethod);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode4(short PropType, DateTime PlaceInService, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #4.
            bpRulebaseTable4 rule = new bpRulebaseTable4();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, PlaceInService);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode5(short PropType, DateTime PlaceInService, short DeprMethod, uint ddbPct, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #2.
            bpRulebaseTable5 rule = new bpRulebaseTable5();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, PlaceInService, DeprMethod, ddbPct);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode6(DateTime PlaceInService, short DeprMethod, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #6.
            bpRulebaseTable6 rule = new bpRulebaseTable6();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PlaceInService, DeprMethod);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode7(short DeprMethod, uint busUsePct, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #7.
            bpRulebaseTable7 rule = new bpRulebaseTable7();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(DeprMethod, busUsePct);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode8(short PropType, DateTime PlaceInService, short DeprMethod, short EstLife, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #8.
            bpRulebaseTable8 rule = new bpRulebaseTable8();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, PlaceInService, DeprMethod, EstLife);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode9(short PropType, short DeprMethod, bool hasBeginningDate, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #9.
            bpRulebaseTable9 rule = new bpRulebaseTable9();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, DeprMethod, hasBeginningDate);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode10(short PropType, short DeprMethod, DateTime PlaceInService, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #10.
            bpRulebaseTable10 rule = new bpRulebaseTable10();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, DeprMethod, PlaceInService);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode11(short DeprMethod, uint ddbPct, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #11.
            bpRulebaseTable11 rule = new bpRulebaseTable11();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(DeprMethod, ddbPct);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode12(short PropType, short DeprMethod, uint ddbPct, short EstLife, short classLife, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #12.
            bpRulebaseTable12 rule = new bpRulebaseTable12();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, DeprMethod, ddbPct, EstLife, classLife);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode13(DateTime fyEnd120189, short PropType, DateTime PlaceInService, short DeprMethod, short deprPct, short EstLife, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #13.
            bpRulebaseTable13 rule = new bpRulebaseTable13();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(fyEnd120189, PropType, PlaceInService, DeprMethod, deprPct, EstLife);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode14(short PropType, DateTime PlaceInService, short DeprMethod, uint ddbPct, short EstLife, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #14.
            bpRulebaseTable14 rule = new bpRulebaseTable14();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, PlaceInService, DeprMethod, ddbPct, EstLife);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        public bool buildSourceCode15(short PropType, DateTime PlaceInService, short DeprMethod, uint ddbPct, short EstLife, ref ulong sourceCode, ref uint targetCode)
        {
            // Create a object for Rulebase #15.
            bpRulebaseTable15 rule = new bpRulebaseTable15();

            // Ask the rulebase for the source code.
            sourceCode = rule.buildSourceCode(PropType, PlaceInService, DeprMethod, ddbPct, EstLife);

            // Create the rulebase database object for the specific rulebase table.
            bpRulebaseTable table = new bpRulebaseTable(rule.tableNumber());

            // Attempt to fetch the target code from the rulebase.
            targetCode = 0;
            if (table.fetchTargetCode(sourceCode, out targetCode))
                return true;
            return false;
        }

        //  -------------------------------------------------------------------------
        void createITCList(uint targetCode, out List<int> list)
        {
            List<int> ei;
            //if ( list == null )
            //{
            //    return ;
            //}
            list = null;
            ei = new List<int>();
            list = ei;

            for (int i = 1; i <= 29; ++i)
            {
                bool ok = false;

                switch (targetCode)
                {
                    case 0:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 1:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                            case 9:
                            case 12:
                            case 13:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 2:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 12:
                            case 13:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 3:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 12:
                            case 13:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 4:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 5:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 6:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 9:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 7:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 9:
                            case 13:
                            case 14:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 8:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 12:
                            case 13:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 9:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 10:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 9:
                            case 12:
                            case 13:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 11:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 9:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 12:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 13:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 9:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 14:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 15:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 16:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 17:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 18:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 13:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 19:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 7:
                            case 8:
                            case 13:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;

                    // Case 1 Variations for StraightLineAltAcrsFormula, StraightLineAltAcrsTable:
                    case 20:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                            case 9:
                            case 12:
                            case 13:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 21:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                            case 9:
                            case 12:
                            case 13:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 22://G,I,L,M,N,O,S,T,U,V,X,Y,Z
                        switch (i)
                        {
                            /*case 1: case 3: case 5: case 6:*/
                            case 7:
                            case 9:
                            case 12:
                            case 13:
                            case 15: /*case 16: case 17:*/ /*case 18:*/
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 23:
                        switch (i)
                        {
                            /*case 1: case 3: case 5: case 6:*/
                            case 7:
                            case 9:
                            case 12:
                            case 13:
                            case 15: /*case 16: case 17:*/ /*case 18:*/
                            /*case 20:*/
                            case 21:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;

                    // Case 12 Variantions for Except StraightLineAltAcrsFormula, StraightLineAltAcrsTable, AdsSlMacrs, AdsSlMacrs30:
                    case 24://A,C,Q,R,X
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 25://A,C,Q,R,W,X,Y
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 17:
                            case 18:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 26://S,T,U,V,W,X,Y
                        switch (i)
                        {
                            /*case 1: case 3:*/
                            /*case 17:*/
                            /*case 18:*/
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 27:
                        switch (i)
                        {
                            /*case 1: case 3:*/
                            /*case 17:*/
                            /*case 18:*/
                            /*case 20:*/
                            case 21:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;

                    // Case 17 Variations for AdsSlMacrs, AdsSlMacrs30:
                    case 28:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 29:
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 16:
                            case 17:
                            case 18:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 30://G,H,S,T,U,V,W,X,Y = 26 with G&H
                        switch (i)
                        {
                            /*case 1: case 3: case 5: case 6:*/
                            case 7:
                            case 8:
                            /*case 16: case 17:*/
                            /*case 18:*/
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 31:// = 27 with G&H
                        switch (i)
                        {
                            /*case 1: case 3: case 5: case 6:*/
                            case 7:
                            case 8:
                            /*case 16: case 17:*/
                            /*case 18:*/
                            /*case 20:*/
                            case 21:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 32://A,C,G,H,Q,R,X = 24 with G & H
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 7:
                            case 8:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 33://A,C,G,H,Q,R,W,X,Y = 25 with G&H
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 7:
                            case 8:
                            case 17:
                            case 18:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 34:// 8 with G & H
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 7:
                            case 8:
                            case 12:
                            case 13:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 35:// 10 with G & H
                        switch (i)
                        {
                            case 1:
                            case 3:
                            case 7:
                            case 8:
                            case 9:
                            case 12:
                            case 13:
                            case 15:
                            case 17:
                            case 18:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 36:
                        switch (i)
                        {
                            /*case 1: case 3: case 5: case 6:*/
                            case 7:
                            case 8:
                            /*case 16: case 17:*/
                            /*case 18:*/
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 19:
                            case 26:
                            case 27:
                            case 28:
                                ok = true;
                                break;
                        }
                        break;
                    case 37:
                        switch (i)
                        {
                            /*case 1: case 3:*/
                            /*case 17:*/
                            /*case 18:*/
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 19:
                            case 26:
                            case 27:
                            case 28:
                                ok = true;
                                break;
                        }
                        break;
                    case 38:
                        switch (i)
                        {
                            /*case 1: case 3: case 5: case 6:*/
                            case 7:
                            case 9:
                            case 12:
                            case 13:
                            case 15: /*case 16: case 17:*/ /*case 18:*/
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 19:
                            case 26:
                            case 27:
                            case 28:
                                ok = true;
                                break;
                        }
                        break;
                    case 39:
                        switch (i)
                        {
                            /*case 1: case 3: case 5: case 6:*/
                            case 7:
                            case 8:
                            /*case 16: case 17:*/
                            /*case 18:*/
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 19:
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                                ok = true;
                                break;
                        }
                        break;
                    case 40:
                        switch (i)
                        {
                            /*case 1: case 3:*/
                            /*case 17:*/
                            /*case 18:*/
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 19:
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                                ok = true;
                                break;
                        }
                        break;
                    case 41:
                        switch (i)
                        {
                            /*case 1: case 3: case 5: case 6:*/
                            case 7:
                            case 9:
                            case 12:
                            case 13:
                            case 15: /*case 16: case 17:*/ /*case 18:*/
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 19:
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                                ok = true;
                                break;
                        }
                        break;

                    case 42:
                        switch (i)
                        {
                            /*case 1: case 3: case 5: case 6:*/
                            case 7:
                            case 9:
                            case 12:
                            case 13:
                            case 15: /*case 16: case 17:*/ /*case 18:*/
                            case 20:
                            case 21:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 43:
                        switch (i)
                        {
                            /*case 1: case 3:*/
                            /*case 17:*/
                            /*case 18:*/
                            case 20:
                            case 21:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                    case 44:// = 27 with G&H
                        switch (i)
                        {
                            /*case 1: case 3: case 5: case 6:*/
                            case 7:
                            case 8:
                            /*case 16: case 17:*/
                            /*case 18:*/
                            case 20:
                            case 21:
                            case 24:
                            case 25:
                            case 19:
                                ok = true;
                                break;
                        }
                        break;
                }

                if (ok)
                {
                    ei.Add((int)translateITCIdToType(i));
                }
            }
        }



        //  -------------------------------------------------------------------------
        bpITCTypeEnum translateITCIdToType(int id)
        {
            switch (id)
            {
                case 1:
                    return bpITCTypeEnum.NewPropFullCredit;
                case 2:
                    return bpITCTypeEnum.NewPropReducedCredit;
                case 3:
                    return bpITCTypeEnum.UsedPropFullCredit;
                case 4:
                    return bpITCTypeEnum.UsedPropReducedCredit;
                case 5:
                    return bpITCTypeEnum.Rehab30Year;
                case 6:
                    return bpITCTypeEnum.Rehab40Year;
                case 7:
                    return bpITCTypeEnum.CertHistoricRehab;
                case 8:
                    return bpITCTypeEnum.NonCertHistoricRehab;
                case 9:
                    return bpITCTypeEnum.Biomass;
                case 10:
                    return bpITCTypeEnum.IntercityBuses;
                case 11:
                    return bpITCTypeEnum.HydroelectricGenerating;
                case 12:
                    return bpITCTypeEnum.OceanThermal;
                case 13:
                    return bpITCTypeEnum.SolarEnergy;
                case 14:
                    return bpITCTypeEnum.Wind;
                case 15:
                    return bpITCTypeEnum.GeoThermal;
                case 16:
                    return bpITCTypeEnum.CertHistoricTransition;
                case 17:
                    return bpITCTypeEnum.QualifiedProgressExp;
                case 18:
                    return bpITCTypeEnum.Reforestation;
                case 19:
                    return bpITCTypeEnum.NoITC;

                case 20:
                    return bpITCTypeEnum.SolarEnergyProperty;
                case 21:
                    return bpITCTypeEnum.OtherEnergyProperty;
                case 22:
                    return bpITCTypeEnum.FuelCellProperty;
                case 23:
                    return bpITCTypeEnum.MicroturbineProperty;
                case 24:
                    return bpITCTypeEnum.AdvancedCoalProject;
                case 25:
                    return bpITCTypeEnum.GasificationProject;
                case 26:
                    return bpITCTypeEnum.HeatPowerSystem;
                case 27:
                    return bpITCTypeEnum.SmallWindEnergy;
                case 28:
                    return bpITCTypeEnum.GeothermalHeatPump;
                case 29:
                    return bpITCTypeEnum.AdvancedEnergyProject;

            }

            return bpITCTypeEnum.NoITC;
        }

        private void createDeprMethodList(uint targetCode, bool IsShortYear, out List<int> list)
        {
            //CComPtr<IbpblEnumInteger> ei;
            short[] listOrder = { 0, 25, 26, 27, 28, 1, 2, 3, 23, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 24 };

            // is fiscal year for pis date within a short year?
            bool allowMacrsTable = true;
            if (IsShortYear)
                // yep. so we disallow Macrs Table (MT) from use.
                allowMacrsTable = false;

            list = new List<int>();

            foreach (int i in listOrder)
            {
                // see if macrs table should be skipped here.
                if (allowMacrsTable == false)
                    if (translateIdToDeprMethodType(i) == DeprMethodTypeEnum.MacrsTable)
                        continue;

                bool found = false;
                switch (targetCode)
                {
                    case 1:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 2:
                        switch (i)
                        {
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 3:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 4:
                        switch (i)
                        {
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 5:
                        switch (i)
                        {
                            case 7:
                            case 8:
                            case 10:
                            case 12:
                            case 13:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 21:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 6:
                        switch (i)
                        {
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 20:
                            case 21:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 7:
                        switch (i)
                        {
                            case 4:
                            case 5:
                            case 6:
                            case 8:
                            case 20:
                            case 22:
                                found = true;
                                break;
                        }
                        break;
                    case 8:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 9:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 10:
                        switch (i)
                        {
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 11:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 12:
                        switch (i)
                        {
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 20:
                            case 22:
                                found = true;
                                break;
                        }
                        break;
                    case 13:
                    case 14:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 15:
                        switch (i)
                        {
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 24:
                                found = true;
                                break;
                        }
                        break;
                    case 16:
                        switch (i)
                        {
                            case 22:
                                found = true;
                                break;
                        }
                        break;
                    // QinZ: For 4 New 30% Depr Method
                    case 17:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 26:
                            case 27:
                            case 28:
                                found = true;
                                break;
                        }
                        break;

                    //GSD - 2011.1 take out MR/MI/SB
                    case 18:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 24:
                            case 25:
                            case 26:
                                found = true;
                                break;
                        }
                        break;

                    //GSD 2011.1
                    case 19:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 24:
                            case 25:
                            case 26:
                            case 28:
                                found = true;
                                break;
                        }
                        break;

                    //GSD 2011.1
                    case 20:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 26:
                            case 27:
                                found = true;
                                break;
                        }
                        break;
                }

                if (found)
                {
                    list.Add((int)translateIdToDeprMethodType(i));
                }
            }
        }

        //  -------------------------------------------------------------------------
        private DeprMethodTypeEnum translateIdToDeprMethodType(int id)
        {
            switch (id)
            {
                case 1:
                    return DeprMethodTypeEnum.MacrsFormula;
                case 2:
                    return DeprMethodTypeEnum.MacrsTable;
                case 3:
                    return DeprMethodTypeEnum.AdsSlMacrs;
                case 4:
                    return DeprMethodTypeEnum.AcrsTable;
                case 5:
                    return DeprMethodTypeEnum.StraightLineAltAcrsFormula;
                case 6:
                    return DeprMethodTypeEnum.StraightLineAltAcrsTable;
                case 7:
                    return DeprMethodTypeEnum.StraightLineModHalfYear;
                case 8:
                    return DeprMethodTypeEnum.StraightLine;
                case 9:
                    return DeprMethodTypeEnum.StraightLineFullMonth;
                case 10:
                    return DeprMethodTypeEnum.StraightLineHalfYear;
                case 11:
                    return DeprMethodTypeEnum.DeclBal;
                case 12:
                    return DeprMethodTypeEnum.DeclBalModHalfYear;
                case 13:
                    return DeprMethodTypeEnum.DeclBalHalfYear;
                case 14:
                    return DeprMethodTypeEnum.DeclBalSwitch;
                case 15:
                    return DeprMethodTypeEnum.DeclBalModHalfYearSwitch;
                case 16:
                    return DeprMethodTypeEnum.DeclBalHalfYearSwitch;
                case 17:
                    return DeprMethodTypeEnum.SumOfTheYearsDigitsHalfYear;
                case 18:
                    return DeprMethodTypeEnum.SumOfTheYearsDigitsModHalfYear;
                case 19:
                    return DeprMethodTypeEnum.SumOfTheYearsDigits;
                case 20:
                    return DeprMethodTypeEnum.RemValueOverRemLife;
                case 21:
                    return DeprMethodTypeEnum.OwnDepreciationCalculation;
                case 22:
                    return DeprMethodTypeEnum.DoNotDepreciate;
                case 23:
                    return DeprMethodTypeEnum.MACRSIndianReservation;
                case 24:
                    return DeprMethodTypeEnum.CustomMethod;

                // QinZ: Added four new Depr Methods
                case 25:
                    return DeprMethodTypeEnum.MacrsFormula30;
                case 26:
                    return DeprMethodTypeEnum.AdsSlMacrs30;
                case 27:
                    return DeprMethodTypeEnum.MACRSIndianReservation30;
                case 28:
                    return DeprMethodTypeEnum.StraightLineFullMonth30;
            }

            return DeprMethodTypeEnum.DoNotDepreciate;
        }


        private void createDeprPercentList(uint targetCode, out List<int> list)
        {
            int[,] ids = {
             { 125, 150, 175, 200, 0  , 0},
             { 150, 200,   0,   0, 0  , 0},
             { 100, 150, 200,   0, 0  , 0},
             { 125, 150, 175, 200, 0  , 0},  // QinZ: for new GASB property type
                    };

            list = new List<int>();

            uint index = 0;
            switch (targetCode)
            {
                case 1:
                    index = 0;
                    break;
                case 2:
                    index = 1;
                    break;
                case 4:
                    index = 2;
                    break;
                case 8:
                    index = 3;
                    break;
            }

            for (int i = 0; ids[index, i] != 0; ++i)
                list.Add(ids[index, i]);
        }



        private void createEstimatedLifeList(uint targetCode, out List<int> list)
        {
            list = new List<int>();

            switch (targetCode)
            {
                case 1:
                    list.Add(300);
                    list.Add(500);
                    list.Add(1000);
                    list.Add(1500);
                    break;
                case 2:
                    list.Add(1500);
                    break;
                case 3:
                    list.Add(1500);
                    list.Add(1800);
                    break;
                case 4:
                    list.Add(1500);
                    list.Add(1800);
                    list.Add(1900);
                    break;
                case 5:
                    list.Add(300);
                    break;
                case 6:
                    list.Add(300);
                    list.Add(500);
                    list.Add(1000);
                    list.Add(1200);
                    list.Add(1500);
                    list.Add(2500);
                    list.Add(3500);
                    list.Add(4500);
                    break;
                case 7:
                    list.Add(1500);
                    list.Add(3500);
                    list.Add(4500);
                    break;
                case 8:
                    list.Add(1500);
                    list.Add(1800);
                    list.Add(3500);
                    list.Add(4500);
                    break;
                case 9:
                    list.Add(1500);
                    list.Add(1800);
                    list.Add(1900);
                    list.Add(3500);
                    list.Add(4500);
                    break;
                case 10:
                    list.Add(500);
                    break;
                case 11:
                    list.Add(300);
                    list.Add(500);
                    list.Add(700);
                    list.Add(1000);
                    list.Add(1500);
                    list.Add(2000);
                    break;
                case 12:
                    list.Add(700);
                    list.Add(1000);
                    list.Add(1500);
                    list.Add(2000);
                    list.Add(2706);
                    list.Add(3106);
                    break;
                case 15:
                    list.Add(300);
                    list.Add(500);
                    list.Add(700);
                    list.Add(1000);
                    break;
                case 20:
                    list.Add(2706);
                    list.Add(3106);
                    break;
                case 22:
                    list.Add(700);
                    list.Add(1000);
                    break;
                case 23:
                    list.Add(1500);
                    list.Add(2000);
                    break;
                // 97.1 Tax Update -- Added 25 yr property  MJB  11/23/96
                case 24:
                    list.Add(300);
                    list.Add(500);
                    list.Add(700);
                    list.Add(1000);
                    list.Add(1500);
                    list.Add(2000);
                    list.Add(2500);
                    break;
                case 25:
                    list.Add(2500);
                    list.Add(2706);
                    list.Add(3106);
                    list.Add(3900);
                    break;
                // end 97.1 Tax Update modifications  MJB  11/23/96
                case 70:
                    list.Add(700);
                    list.Add(1000);
                    list.Add(1500);
                    list.Add(2000);
                    break;
                case 71:
                    list.Add(2706);
                    list.Add(3106);
                    list.Add(3900);
                    break;
                case 72:
                    list.Add(2200);
                    break;
                case 73:
                    list.Add(900);
                    list.Add(1200);
                    break;
                case 74:
                    list.Add(400);
                    list.Add(600);
                    break;
                case 75:
                    list.Add(200);
                    list.Add(300);
                    list.Add(400);
                    list.Add(600);
                    list.Add(900);
                    list.Add(1200);
                    break;
                case 76:
                    list.Add(200);
                    list.Add(300);
                    list.Add(400);
                    list.Add(600);
                    break;
                case 77:
                    list.Add(300);
                    break;
                case 78:
                    list.Add(2706);
                    list.Add(3106);
                    list.Add(3900);
                    break;
                case 80:
                    list.Add(500);
                    break;
                case 81:
                    list.Add(300);
                    list.Add(500);
                    list.Add(700);
                    list.Add(1000);
                    list.Add(1500);
                    list.Add(2000);
                    break;
                case 82:
                    list.Add(300);
                    list.Add(500);
                    list.Add(700);
                    list.Add(1000);
                    break;
                case 84:
                    list.Add(2706);
                    list.Add(3106);
                    list.Add(3900);
                    break;
                case 85:
                    list.Add(2500);
                    list.Add(2706);
                    list.Add(3106);
                    list.Add(3900);
                    break;
                case 86:
                case 99:
                    list.Add(700);
                    list.Add(1000);
                    break;
                case 88:
                    list.Add(700);
                    list.Add(1000);
                    list.Add(1500);
                    list.Add(2000);
                    break;
                case 89:
                    list.Add(300);
                    list.Add(500);
                    list.Add(700);
                    list.Add(1000);
                    list.Add(1500);
                    list.Add(2000);
                    list.Add(2500);
                    break;
                // added case 92 to fix jchud-00081  MJB 7/21/98
                case 92:
                    list.Add(300);
                    list.Add(500);
                    break;

                // QinZ: 3/14/2002 for R -- MA100 
                case 93:
                    list.Add(1500);
                    list.Add(2500);
                    list.Add(3900);
                    break;

                // QinZ: 3/14/2002 for S,C,E,F -- MA100 
                case 94:
                    list.Add(1500); 
                    list.Add(3900);
                    break;

                case 100:
                    list.Add(500);
                    list.Add(2500);
                    list.Add(2706);
                    list.Add(3106);
                    list.Add(3900);
                    break;

                // added case 101 to in Tax update 2004.1 for T 
                case 101:
                    list.Add(300);
                    list.Add(400);
                    list.Add(500);
                    break;

                // added cases to in Tax update 2005.1 for JOBS Act
                case 102:
                    list.Add(500);
                    list.Add(1500);
                    list.Add(2500);
                    list.Add(2706);
                    list.Add(3106);
                    list.Add(3900);
                    break;

                case 103:
                    list.Add(1500);
                    list.Add(2500);
                    list.Add(3900);
                    break;

                case 104:
                    list.Add(900);
                    list.Add(2200);
                    break;

                case 105:
                    list.Add(1500);
                    list.Add(2500);
                    list.Add(2706);
                    list.Add(3106);
                    list.Add(3900);
                    break;

                case 107:
                    list.Add(1500);
                    list.Add(2500);
                    list.Add(2706);
                    list.Add(3900);
                    break;

                // QinZ: 1/1/2012 - 12/31/2012 for S,C,E,F -- MF100 
                case 108:
                    list.Add(1500);
                    list.Add(2706);
                    list.Add(3106);
                    list.Add(3900);
                    break;

                default:
                    list = null;
                    break;
            }
        }

        //  -------------------------------------------------------------------------
        short getAsMonths(short life)
        {
            return (short)(life / 100 * 12 + life % 100);
        }

        /*
        void _handlePart1Internal(uint tCode, IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook)
        {
            short classLife;
            short estLife;
            bestAssetDeprSwitchTypeEnum deprSwitch;
            short pct;
            bestAssetDeprMethodTypeEnum meth;
            bestAssetDeprMethodTypeEnum destMeth;
            PropertyTypeEnum propType;
            bestAssetPropertyTypeEnum baPropType;

            DateTime PISDate;
            bestAssetDeprMethodTypeEnum defaultMethod;
            string defMethString = null;
            string newMethString = null;

            baPropType = core.PropType;
            propType = (PropertyTypeEnum)baPropType;

            classLife = core.ADSLife;
            estLife = sourceBook.EstimatedLife;
            deprSwitch = sourceBook.DeprSwitch;
            pct = sourceBook.DeprPercent;
            meth = sourceBook.DeprMethod;
            newMethString = sourceBook.CustomDeprMethodString;
            PISDate = sourceBook.PlacedInService;
            defaultMethod = destBook.DefaultMethod;

            // Get the first part of the code.
            tCode /= 100;

            // Based on the code, perform an action.
            switch (tCode)
            {
                case 1:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, 300, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 2:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, 700, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 3:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, 1000, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 4:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, 1100, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 5:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, 1706, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 6:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, 2100, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 7:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, 2200, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 8:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, 5000, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 9:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, 4000, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 10:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, estLife, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 11:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLineHalfYear, destBook, newMethString, defMethString);
                    _setLifeInternal(classLife, estLife, destBook);
                    destBook.DeprPercent = (0);
                    break;
                case 12:
                    _setMethod(propType, PISDate, defaultMethod, meth, destBook, newMethString, defMethString);
                    destMeth = destBook.DeprMethod;
                    if (destMeth == meth)
                    {
                        destBook.DeprPercent = (pct);
                        destBook.DeprSwitch = (deprSwitch);
                    }
                    destBook.EstimatedLife = (estLife);
                    break;
                case 13:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    destBook.EstimatedLife = (classLife);
                    destBook.DeprPercent = (0);
                    break;
                case 14:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLine, destBook, newMethString, defMethString);
                    destBook.EstimatedLife = (estLife);
                    destBook.DeprPercent = (0);
                    break;
                case 15:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLineFullMonth, destBook, newMethString, defMethString);
                    destBook.EstimatedLife = (classLife);
                    destBook.DeprPercent = (0);
                    break;
                case 16:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLineFullMonth, destBook, newMethString, defMethString);
                    destBook.EstimatedLife = (estLife);
                    destBook.DeprPercent = (0);
                    break;
                case 17:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLineHalfYear, destBook, newMethString, defMethString);
                    destBook.EstimatedLife = (classLife);
                    destBook.DeprPercent = (0);
                    break;
                case 18:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLineHalfYear, destBook, newMethString, defMethString);
                    destBook.EstimatedLife = (estLife);
                    destBook.DeprPercent = (0);
                    break;
                case 19:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLineModHalfYear, destBook, newMethString, defMethString);
                    destBook.EstimatedLife = (classLife);
                    destBook.DeprPercent = (0);
                    break;
                case 20:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLineModHalfYear, destBook, newMethString, defMethString);
                    destBook.EstimatedLife = (estLife);
                    destBook.DeprPercent = (0);
                    break;
                case 34:
                    _setMethod(propType, PISDate, defaultMethod, bestAssetDeprMethodTypeEnum.dmStraightLineAltAcrsTable, destBook, newMethString, defMethString);
                    destBook.EstimatedLife = (4500);
                    destBook.DeprPercent = (0);
                    break;
                case 40:
                    if (meth == bestAssetDeprMethodTypeEnum.dmCustomMethod)
                    {
                        string newMeth;

                        newMeth = sourceBook.CustomDeprMethodString;
                        destBook.CustomDeprMethodString = (newMeth);
                    }
                    else
                        destBook.DeprMethod = (meth);
                    destBook.EstimatedLife = (estLife);
                    destBook.DeprSwitch = (deprSwitch);
                    destBook.DeprPercent = (pct);
                    break;
            }
        }

        //  -------------------------------------------------------------------------
        void _handlePart2Internal(uint tCode, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook)
        {
            // Perform special handling of business use.
            handleBusinessUseLogic(sourceBook, destBook);

            switch (tCode % 100)
            {
                case 1:
                    // Clear out any depreciation transferred from the copyFrom() earlier.
                    destBook.resetDeprToZero();
                    break;

                case 2:
                    // Assume that all information from source book was already transferred
                    // in the caller using the copyFrom() method.
                    destBook.handleBegDeprLogic(sourceBook);
                    break;
            }
        }

        //  -------------------------------------------------------------------------
        void _setLifeInternal(short classLife, short newLife, IbpDepreciableBookAsset destBook)
        {
            // Use class life if available.  If not, use passed life.
            if (classLife != 0)
            {
                destBook.EstimatedLife = (classLife);
            }
            else
            {
                destBook.EstimatedLife = (newLife);
            }
        }

        //  -------------------------------------------------------------------------
        void _setMethod(PropertyTypeEnum propType, DateTime PlaceInService, bestAssetDeprMethodTypeEnum defaultMethod, bestAssetDeprMethodTypeEnum newMethod, IbpDepreciableBookAsset destBook, string newMethString, string defMethString)
        {
            bpBookTypeEnum type;
            bool IsShortYear;
            ErrorCode errorCode;

            type = destBook.BookType;
            IsShortYear = destBook.FirstYearIsShortYear;

            ValidateDeprMethod((short)type, (short)propType, PlaceInService, (short)defaultMethod, IsShortYear, out errorCode);

            switch (errorCode)
            {
                // If any problem, use the passed method.
                case ErrorCode.RuleBaseFailure:
                case ErrorCode.InvalModAcrsBeforeAug11986:
                case ErrorCode.UnknownMethod:
                    if (newMethod == bestAssetDeprMethodTypeEnum.dmCustomMethod)
                    {
                        destBook.CustomDeprMethodString = (newMethString);
                    }
                    else
                        destBook.DeprMethod = (newMethod);
                    break;
                // If no problem, use the default method.
                default:
                    if (defaultMethod == bestAssetDeprMethodTypeEnum.dmCustomMethod)
                    {
                        destBook.CustomDeprMethodString = (defMethString);
                    }
                    else
                        destBook.DeprMethod = (defaultMethod);
                    break;
            }
        }

        //  -------------------------------------------------------------------------
        void handleBusinessUseLogic(IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook)
        {
            bool is100pct;
            bool isSimilar;

            // Ensure that if the source book had business use, that we can
            // keep it.  We do this by comparing company book information and seeing
            // if they are date compatible.  If not, clear out any business use.
            is100pct = destBook.is100PctBusinessUse;
            if (is100pct == false)
            {
                isSimilar = destBook.get_IsSimilarWithDates(sourceBook);
                if (isSimilar == false)
                {
                    destBook.force100PctBusinessUse();
                }
            }
        }

        //  -------------------------------------------------------------------------
        void DoEmulatedBooks(IbpDepreciableAsset asset, IbpDepreciableAssetExtension ext, IbpDepreciableBookAsset taxBook, bpBookTypeEnum bookType)
        {
            IbpEnumDispatch ei = null;
            int count;
            short bookId;
            ErrorCode errorCode;
            IbpDepreciableBookAsset emuBook = null;
            object disp = null;

            ei = ext.get_BookListOfType(bookType) as IbpEnumDispatch;
            if (ei != null)
            {
                IbpDepreciableBookAsset Book = null;
                ei.Reset();
                do
                {
                    ei.Next(1, out disp, out count);
                    if (disp != null && count > 0)
                    {
                        Book = disp as IbpDepreciableBookAsset;
                        short bookToEmulate = Book.BookIdToEmulate;
                        bookId = Book.BookID;
                        if (bookToEmulate < 0 || bookId < 0)
                        {
                            COMSupport.RELEASE(Book);
                            continue;
                        }

                        bool emulateok = false;
                        if (bookToEmulate == 0)
                        {
                            emuBook = Book;
                            bookToEmulate = bookId;
                        }
                        else
                        {
                            emuBook = ext.get_BookByID(bookToEmulate) as IbpDepreciableBookAsset;
                            if (emuBook != null)
                            {
                                bool isOpen;
                                isOpen = emuBook.IsOpen;
                                emulateok = isOpen;
                            }
                        }

                        if (bookToEmulate == bookId || emulateok == false)
                        {
                            bestAssetDeprMethodTypeEnum taxMethod;
                            bestAssetDeprMethodTypeEnum defaultMethod;

                            ForceDefaultsForInternalBook(asset, taxBook, Book, out errorCode);
                            taxMethod = taxBook.DeprMethod;
                            if (taxMethod != bestAssetDeprMethodTypeEnum.dmDoNotDepreciate)
                            {
                                defaultMethod = Book.DefaultMethod;
                                //
                                // NEED CODE HERE TO GET CUSTOM DEFAULT DEPR METHOD STRING
                                //
                                Book.DeprMethod = (defaultMethod);
                                switch (defaultMethod)
                                {
                                    case bestAssetDeprMethodTypeEnum.dmDeclBal:
                                    case bestAssetDeprMethodTypeEnum.dmDeclBalHalfYear:
                                    case bestAssetDeprMethodTypeEnum.dmDeclBalModHalfYear:
                                    case bestAssetDeprMethodTypeEnum.dmDeclBalSwitch:
                                    case bestAssetDeprMethodTypeEnum.dmDeclBalHalfYearSwitch:
                                    case bestAssetDeprMethodTypeEnum.dmDeclBalModHalfYearSwitch:
                                    case bestAssetDeprMethodTypeEnum.dmMacrsFormula:
                                    case bestAssetDeprMethodTypeEnum.dmMacrsTable:
                                        Book.DeprPercent = (200);
                                        break;
                                    default:
                                        Book.DeprPercent = (0);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            short bookID;
                            bookID = Book.BookID;
                            Book.copyFrom(emuBook);
                            Book.BookType = (bookType);
                            Book.BookID = (bookID);
                            Book.resetDeprToZero();
                        }

                        _handlePct168k(taxBook, Book);

                        COMSupport.RELEASE(Book);
                        COMSupport.RELEASE(emuBook);
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }

        }

        //  -------------------------------------------------------------------------
        void _handlePart1AMT(uint tCode, IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook)
        {
            short classLife;
            short estLife;
            bestAssetDeprSwitchTypeEnum deprSwitch;
            short pct;
            bestAssetDeprMethodTypeEnum meth;
            bestAssetPropertyTypeEnum propType;
            DateTime PISDate;
            bestAssetDeprMethodTypeEnum defaultMethod;

            propType = core.PropType;
            classLife = core.ADSLife;
            estLife = sourceBook.EstimatedLife;
            deprSwitch = sourceBook.DeprSwitch;
            pct = sourceBook.DeprPercent;
            meth = sourceBook.DeprMethod;
            PISDate = sourceBook.PlacedInService;
            defaultMethod = destBook.DefaultMethod;

            // Get the first part of the code.
            tCode /= 100;

            // Based on the code, perform an action.
            switch (tCode)
            {
                case 26:
                case 1:
                    if (meth == bestAssetDeprMethodTypeEnum.dmCustomMethod)
                    {
                        string newMeth;

                        newMeth = sourceBook.CustomDeprMethodString;
                        destBook.CustomDeprMethodString = (newMeth);
                    }
                    else
                        destBook.DeprMethod = (meth);
                    destBook.EstimatedLife = (estLife);
                    destBook.DeprPercent = (pct);
                    destBook.DeprSwitch = (deprSwitch);
                    break;
                case 2:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    destBook.EstimatedLife = (estLife);
                    break;
                case 3:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 1200, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 4:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmStraightLineAltAcrsTable);
                    destBook.EstimatedLife = (estLife);
                    break;
                case 5:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmStraightLine);
                    destBook.EstimatedLife = (estLife);
                    break;
                case 6:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmStraightLineHalfYear);
                    destBook.EstimatedLife = (estLife);
                    break;
                case 7:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmStraightLineModHalfYear);
                    destBook.EstimatedLife = (estLife);
                    break;
                case 8:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    destBook.EstimatedLife = (4000);
                    break;
                case 9:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 300, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 10:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 700, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 11:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 1000, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 12:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 1706, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 13:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 2200, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 14:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 5000, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 15:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, classLife, destBook);  //  changed to match bookamt.cpp
                    destBook.DeprPercent = (150);
                    break;
                case 16:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    destBook.EstimatedLife = (estLife);
                    destBook.DeprPercent = (150);
                    break;
                case 17:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, 700, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 18:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, 1000, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 19:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, 1706, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 20:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, 2200, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 21:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, 5000, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 22:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 23:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmDeclBal);
                    _setLifeInternal(classLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 24:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmDeclBalHalfYear);
                    _setLifeInternal(classLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 25:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmDeclBalModHalfYear);
                    _setLifeInternal(classLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 27:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(estLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;

                // 97.1 Tax Update -- added for new 25-year property  MJB 12/3/96
                case 29:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    _setLifeInternal(classLife, 5000, destBook);
                    break;
                case 30:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(estLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 31:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula30);
                    _setLifeInternal(estLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
            }

        }


        //  -------------------------------------------------------------------------
        void _handlePart2AMT(IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook)
        {
            // Perform special handling of business use.
            handleBusinessUseLogic(sourceBook, destBook);

            // Clear out any depreciation transferred from the copyFrom() earlier.
            destBook.resetDeprToZero();
        }

        //  -------------------------------------------------------------------------
        void _handlePart1ACE(uint tCode, IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset AMTBook, IbpDepreciableBookAsset destBook)
        {
            short classLife;
            short estLife;
            bestAssetDeprSwitchTypeEnum deprSwitch;
            short pct;
            bestAssetDeprMethodTypeEnum meth;
            bestAssetPropertyTypeEnum propType;
            DateTime PISDate;
            bestAssetDeprMethodTypeEnum defaultMethod;
            bestAssetDeprMethodTypeEnum AMTMeth;
            short AMTLife;

            propType = core.PropType;
            classLife = core.ADSLife;
            estLife = sourceBook.EstimatedLife;
            deprSwitch = sourceBook.DeprSwitch;
            pct = sourceBook.DeprPercent;
            meth = sourceBook.DeprMethod;
            PISDate = sourceBook.PlacedInService;
            defaultMethod = destBook.DefaultMethod;
            AMTMeth = AMTBook.DeprMethod;
            AMTLife = AMTBook.EstimatedLife;

            // Get the first part of the code.
            tCode /= 100;

            // Setup special booleans to speed testing of target codes.
            bool validClassLife = classLife > 0;
            bool validTaxLife = estLife > 0;
            bool isAMTMethodAD = (AMTMeth == bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);

            // Based on the code, perform an action.
            switch (tCode)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmRemValueOverRemLife);
                    if (validClassLife)
                        destBook.EstimatedLife = (classLife);
                    else if (isAMTMethodAD ||
                            AMTMeth == bestAssetDeprMethodTypeEnum.dmStraightLineAltAcrsFormula ||
                            AMTMeth == bestAssetDeprMethodTypeEnum.dmStraightLineAltAcrsTable)
                        destBook.EstimatedLife = (AMTLife);
                    else
                    {
                        if (tCode == 1)
                            destBook.EstimatedLife = (300);
                        else if (tCode == 2)
                            destBook.EstimatedLife = (1100);
                        else if (tCode == 3)
                            destBook.EstimatedLife = (2100);
                        else if (tCode == 4)
                            destBook.EstimatedLife = (4000);
                    }
                    break;

                case 5:
                case 6:
                case 7:
                case 8:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmRemValueOverRemLife);
                    if (validClassLife)
                        destBook.EstimatedLife = (classLife);
                    else if (isAMTMethodAD)
                        destBook.EstimatedLife = (AMTLife);
                    else if (validTaxLife)
                        destBook.EstimatedLife = (estLife);
                    else
                    {
                        if (tCode == 5)
                            destBook.EstimatedLife = (300);
                        else if (tCode == 6)
                            destBook.EstimatedLife = (1100);
                        else if (tCode == 7)
                            destBook.EstimatedLife = (2100);
                        else if (tCode == 8)
                            destBook.EstimatedLife = (4000);
                    }
                    break;

                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    if (validClassLife)
                        destBook.EstimatedLife = (classLife);
                    else if (isAMTMethodAD)
                        destBook.EstimatedLife = (AMTLife);
                    else if (validTaxLife)
                        destBook.EstimatedLife = (estLife);
                    else
                    {
                        if (tCode == 9)
                            destBook.EstimatedLife = (300);
                        else if (tCode == 10)
                            destBook.EstimatedLife = (700);
                        else if (tCode == 11)
                            destBook.EstimatedLife = (1000);
                        else if (tCode == 12)
                            destBook.EstimatedLife = (1706);
                        else if (tCode == 13)
                            destBook.EstimatedLife = (2200);
                        else if (tCode == 14)
                            destBook.EstimatedLife = (5000);
                    }
                    break;

                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    destBook.DeprPercent = (150);
                    if (validClassLife)
                        destBook.EstimatedLife = (classLife);
                    else
                    {
                        if (tCode == 15)
                            destBook.EstimatedLife = (300);
                        else if (tCode == 16)
                            destBook.EstimatedLife = (700);
                        else if (tCode == 17)
                            destBook.EstimatedLife = (1000);
                        else if (tCode == 18)
                            destBook.EstimatedLife = (1706);
                        else if (tCode == 19)
                            destBook.EstimatedLife = (2200);
                        else if (tCode == 20)
                            destBook.EstimatedLife = (5000);
                    }
                    break;

                case 21:
                    if (meth == bestAssetDeprMethodTypeEnum.dmCustomMethod)
                    {
                        string newMeth;

                        newMeth = sourceBook.CustomDeprMethodString;
                        destBook.CustomDeprMethodString = (newMeth);
                    }
                    else
                        destBook.DeprMethod = (meth);
                    destBook.DeprPercent = (pct);
                    destBook.DeprSwitch = (deprSwitch);
                    destBook.EstimatedLife = (estLife);
                    break;

                case 22:
                case 24:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmRemValueOverRemLife);
                    destBook.EstimatedLife = (4000);
                    break;

                case 23:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    destBook.EstimatedLife = (4000);
                    break;

                case 25:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmRemValueOverRemLife);
                    if (validClassLife)
                        destBook.EstimatedLife = (classLife);
                    else if (isAMTMethodAD)
                        destBook.EstimatedLife = (AMTLife);
                    else
                        destBook.EstimatedLife = (estLife);
                    break;

                case 26:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    if (validClassLife)
                        destBook.EstimatedLife = (classLife);
                    else if (isAMTMethodAD)
                        destBook.EstimatedLife = (AMTLife);
                    else
                        destBook.EstimatedLife = (estLife);
                    break;

                case 27:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    destBook.DeprPercent = (150);
                    if (validClassLife)
                        destBook.EstimatedLife = (classLife);
                    else
                        destBook.EstimatedLife = (estLife);
                    break;

                case 28:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    destBook.EstimatedLife = (estLife);
                    break;

                // 97.1 Tax Update -- added for new 25-year property  MJB 12/3/96
                case 29:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    if (validClassLife)
                        destBook.EstimatedLife = (classLife);
                    else
                        destBook.EstimatedLife = (estLife);
                    break;
            }
        }

        //  -------------------------------------------------------------------------
        void _handlePart1ACE_LikeAMT(uint tCode, IbpDepreciableAsset core, IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook)
        {
            short classLife;
            short estLife;
            bestAssetDeprSwitchTypeEnum deprSwitch;
            short pct;
            bestAssetDeprMethodTypeEnum meth;
            bestAssetPropertyTypeEnum propType;
            DateTime PISDate;
            bestAssetDeprMethodTypeEnum defaultMethod;

            propType = core.PropType;
            classLife = core.ADSLife;
            estLife = sourceBook.EstimatedLife;
            deprSwitch = sourceBook.DeprSwitch;
            pct = sourceBook.DeprPercent;
            meth = sourceBook.DeprMethod;
            PISDate = sourceBook.PlacedInService;
            defaultMethod = destBook.DefaultMethod;

            // Get the first part of the code.
            tCode /= 100;

            // Based on the code, perform an action.
            switch (tCode)
            {
                case 26:
                case 1:
                    if (meth == bestAssetDeprMethodTypeEnum.dmCustomMethod)
                    {
                        string newMeth;

                        newMeth = sourceBook.CustomDeprMethodString;
                        destBook.CustomDeprMethodString = (newMeth);
                    }
                    else
                        destBook.DeprMethod = (meth);
                    destBook.EstimatedLife = (estLife);
                    destBook.DeprPercent = (pct);
                    destBook.DeprSwitch = (deprSwitch);
                    break;
                case 2:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    destBook.EstimatedLife = (estLife);
                    break;
                case 3:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 1200, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 4:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmStraightLineAltAcrsTable);
                    destBook.EstimatedLife = (estLife);
                    break;
                case 5:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmStraightLine);
                    destBook.EstimatedLife = (estLife);
                    break;
                case 6:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmStraightLineHalfYear);
                    destBook.EstimatedLife = (estLife);
                    break;
                case 7:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmStraightLineModHalfYear);
                    destBook.EstimatedLife = (estLife);
                    break;
                case 8:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    destBook.EstimatedLife = (4000);
                    break;
                case 9:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 300, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 10:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 700, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 11:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 1000, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 12:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 1706, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 13:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 2200, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 14:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, 5000, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 15:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(classLife, classLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 16:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    destBook.EstimatedLife = (estLife);
                    destBook.DeprPercent = (150);
                    break;
                case 17:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, 700, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 18:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, 1000, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 19:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, 1706, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 20:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, 2200, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 21:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, 5000, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 22:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsTable);
                    _setLifeInternal(classLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 23:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmDeclBal);
                    _setLifeInternal(classLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 24:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmDeclBalHalfYear);
                    _setLifeInternal(classLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 25:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmDeclBalModHalfYear);
                    _setLifeInternal(classLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 27:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(estLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                // 97.1 Tax Update -- added for new 25-year property  MJB 12/3/96
                case 29:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmAdsSlMacrs);
                    _setLifeInternal(classLife, 5000, destBook);
                    break;
                case 30:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula);
                    _setLifeInternal(estLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
                case 31:
                    destBook.DeprMethod = (bestAssetDeprMethodTypeEnum.dmMacrsFormula30);
                    _setLifeInternal(estLife, estLife, destBook);
                    destBook.DeprPercent = (150);
                    break;
            }
        }


        void _handlePct168k(IbpDepreciableBookAsset sourceBook, IbpDepreciableBookAsset destBook)
        {
            short bonus911pct;
            bestAssetDeprMethodTypeEnum meth;

            bonus911pct = sourceBook.Bonus911Percent;
            meth = destBook.DeprMethod;

            if (meth == bestAssetDeprMethodTypeEnum.dmMacrsFormula30 ||
                 meth == bestAssetDeprMethodTypeEnum.dmAdsSlMacrs30 ||
                 meth == bestAssetDeprMethodTypeEnum.dmMACRSIndianReservation30 ||
                 meth == bestAssetDeprMethodTypeEnum.dmStraightLineFullMonth30)
            {
                destBook.Bonus911Percent = (bonus911pct);
            }
            else
            {
                destBook.Bonus911Percent = (0);
            }
        }

        */
    }
}
