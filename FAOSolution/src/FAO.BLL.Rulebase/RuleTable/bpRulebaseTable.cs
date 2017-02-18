using System;
using System.Collections.Generic;
using System.Text;

namespace FAO.BLL.Rulebase
{
    class bpRulebaseTable
    {
        private uint _tableNum;

        //private ulong _data_sourcecode;
        //private uint _data_tableno;
        //private uint _data_targetcode;

        public bpRulebaseTable(uint tableNum)
        {
            _tableNum = tableNum;
        }

        public uint tableNumber()
        { return _tableNum; }

        public void tableNumber(uint tableNum)
        { _tableNum = tableNum; }

        public bool fetchTargetCode(ulong sourceCode, out uint pTargetCode)
        {
            try
            {
                int targetcode = rbGetTargetCode(tableNumber(), sourceCode);
                if (targetcode == -1)
                {
                    pTargetCode = 0;
                    return false;
                }
                pTargetCode = (uint)targetcode;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                pTargetCode = 0;
                return true;
            }

            return true;
        }


        int rbGetTargetCode(uint table, ulong sourcecode)
        {
            Dictionary<ulong, int> rPtr;
            ulong rSize;
            //ulong i;

            switch (table)
            {
                case 1:
                    rSize = RuleList1._vectorSize1;
                    rPtr = RuleList1._vector1;
                    break;
                case 2:
                    rSize = RuleList2._vectorSize2;
                    rPtr = RuleList2._vector2;
                    break;
                case 3:
                    rSize = RuleList3._vectorSize3;
                    rPtr = RuleList3._vector3;
                    break;
                case 4:
                    rSize = RuleList4._vectorSize4;
                    rPtr = RuleList4._vector4;
                    break;
                case 5:
                    rSize = RuleList5._vectorSize5;
                    rPtr = RuleList5._vector5;
                    break;
                case 6:
                    rSize = RuleList6._vectorSize6;
                    rPtr = RuleList6._vector6;
                    break;
                case 7:
                    rSize = RuleList7._vectorSize7;
                    rPtr = RuleList7._vector7;
                    break;
                case 8:
                    rSize = RuleList8._vectorSize8;
                    rPtr = RuleList8._vector8;
                    break;
                case 9:
                    rSize = RuleList9._vectorSize9;
                    rPtr = RuleList9._vector9;
                    break;
                case 10:
                    rSize = RuleList10._vectorSize10;
                    rPtr = RuleList10._vector10;
                    break;
                case 11:
                    rSize = RuleList11._vectorSize11;
                    rPtr = RuleList11._vector11;
                    break;
                case 12:
                    rSize = RuleList12._vectorSize12;
                    rPtr = RuleList12._vector12;
                    break;
                case 13:
                    rSize = RuleList13._vectorSize13;
                    rPtr = RuleList13._vector13;
                    break;
                case 14:
                    rSize = RuleList14._vectorSize14;
                    rPtr = RuleList14._vector14;
                    break;
                case 15:
                    rSize = RuleList15._vectorSize15;
                    rPtr = RuleList15._vector15;
                    break;
                default:
                    return -1;
            }

            // Rip through vector looking for source code.
            //i = 0L;
            int targetcode;
            rPtr.TryGetValue(sourcecode, out targetcode);

            if (targetcode > 0)
                return targetcode;

            return -1;
        }


    }
}
