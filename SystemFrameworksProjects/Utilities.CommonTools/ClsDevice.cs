namespace KangShuoTech.Utilities.CommonTools
{
    using System;
    using System.Collections.Generic;

    public class ClsDevice
    {
        private string Address;
        private string DevType;
        private string FriendName;
        public int m_EatFlag = -1;
        public bool m_HasValue = false;
        public List<BCResult> m_result = new List<BCResult>();
        public byte[] m_spvalue = new byte[0xfa0];
        private string Name;
        private string Value1;
        private string Value2;
        private string Value3;
        private string Value4;
        private string Value5;
        private string Value6;
        private string Value7;
        private string Value8;
        private string Value9;

        public ClsDevice()
        {
            this.DeviceValue1 = "0";
            this.DeviceValue2 = "0";
            this.DeviceValue3 = "0";
            this.DeviceValue4 = "0";
            this.DeviceValue5 = "0";
            this.DeviceValue6 = "0";
            this.DeviceValue7 = "0";
            this.DeviceValue8 = "0";
            this.DeviceValue9 = "0";
            this.m_result.Clear();
        }

        public BCResult GetJianKangZaiXianResult(int typeindex, int code)
        {
            BCResult result = new BCResult();
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            int num = 0;
            switch (typeindex)
            {
                case 0x12:
                    str = "亚硝酸盐";
                    str2 = "NIT";
                    num = 7;
                    switch (code)
                    {
                        case 0:
                            str3 = "阴性";
                            str4 = "阴性";
                            str5 = "－";
                            goto Label_07A6;

                        case 1:
                            str3 = "阳性";
                            str4 = "阳性";
                            str5 = "0.12mg/dl";
                            goto Label_07A6;
                    }
                    break;

                case 0x13:
                    str = "白细胞";
                    str2 = "LEU";
                    num = 8;
                    switch (code)
                    {
                        case 0:
                            str3 = "－";
                            str4 = "－";
                            str5 = "－";
                            goto Label_07A6;

                        case 1:
                            str3 = "+－";
                            str4 = "15/ul";
                            str5 = "15/ul";
                            goto Label_07A6;

                        case 2:
                            str3 = "1+";
                            str4 = "70/ul";
                            str5 = "70/ul";
                            goto Label_07A6;

                        case 3:
                            str3 = "2+";
                            str4 = "125/ul";
                            str5 = "125/ul";
                            goto Label_07A6;

                        case 4:
                            str3 = "3+";
                            str4 = "500/ul";
                            str5 = "500/ul";
                            goto Label_07A6;
                    }
                    break;

                case 20:
                    str = "尿胆原";
                    str2 = "URO";
                    num = 0;
                    switch (code)
                    {
                        case 0:
                            str3 = "3.2umol/L";
                            str4 = "3.2umol/L";
                            str5 = "3.2umol/L";
                            goto Label_07A6;

                        case 1:
                            str3 = "16umol/L";
                            str4 = "16umol/L";
                            str5 = "16umol/L";
                            goto Label_07A6;

                        case 2:
                            str3 = "33umol/L";
                            str4 = "33umol/L";
                            str5 = "33umol/Ll";
                            goto Label_07A6;

                        case 3:
                            str3 = "66umol/L";
                            str4 = "66umol/L";
                            str5 = "66umol/L";
                            goto Label_07A6;

                        case 4:
                            str3 = ">=131umol/l";
                            str4 = ">=131umol/l";
                            str5 = ">=131umol/l";
                            goto Label_07A6;
                    }
                    break;

                case 0x15:
                    str = "蛋白质";
                    str2 = "PRO";
                    num = 5;
                    switch (code)
                    {
                        case 0:
                            str3 = "阴性";
                            str4 = "阴性";
                            str5 = "0mg/dl";
                            goto Label_07A6;

                        case 1:
                            str3 = "+－";
                            str4 = "0.15g/L";
                            str5 = "15mg/dl";
                            goto Label_07A6;

                        case 2:
                            str3 = "1+";
                            str4 = "0.3g/L";
                            str5 = "30mg/dl";
                            goto Label_07A6;

                        case 3:
                            str3 = "2+";
                            str4 = "1g/L";
                            str5 = "100mg/dl";
                            goto Label_07A6;

                        case 4:
                            str3 = "3+";
                            str4 = ">=3g/L";
                            str5 = "300mg/dl";
                            goto Label_07A6;
                    }
                    break;

                case 0x16:
                    str = "潜血";
                    str2 = "BLD";
                    num = 1;
                    switch (code)
                    {
                        case 0:
                            str3 = "阴性";
                            str4 = "阴性";
                            str5 = "－";
                            goto Label_07A6;

                        case 1:
                            str3 = "+－";
                            str4 = "10/ul";
                            str5 = "0.03mg/dl";
                            goto Label_07A6;

                        case 2:
                            str3 = "1+";
                            str4 = "25/ul";
                            str5 = "0.08mg/dl";
                            goto Label_07A6;

                        case 3:
                            str3 = "2+";
                            str4 = "80/ul";
                            str5 = "0.15mg/dl";
                            goto Label_07A6;

                        case 4:
                            str3 = "3+";
                            str4 = "200/ul";
                            str5 = "0.75mg/dl";
                            goto Label_07A6;
                    }
                    break;

                case 0x17:
                    str = "酮体";
                    str2 = "KET";
                    num = 3;
                    switch (code)
                    {
                        case 0:
                            str3 = "阴性";
                            str4 = "阴性";
                            str5 = "0mg/dl";
                            goto Label_07A6;

                        case 1:
                            str3 = "+－";
                            str4 = "0.5umol/L";
                            str5 = "0mg/dl";
                            goto Label_07A6;

                        case 2:
                            str3 = "1+";
                            str4 = "1.5umol/L";
                            str5 = "15mg/dl";
                            goto Label_07A6;

                        case 3:
                            str3 = "2+";
                            str4 = "3.9umol/L";
                            str5 = "40mg/dl";
                            goto Label_07A6;

                        case 4:
                            str3 = "3+";
                            str4 = ">=7.8umol/l";
                            str5 = "80mg/dl";
                            goto Label_07A6;
                    }
                    break;

                case 0x18:
                    str = "胆红素";
                    str2 = "BIL";
                    num = 2;
                    switch (code)
                    {
                        case 0:
                            str3 = "阴性";
                            str4 = "阴性";
                            str5 = "0mg/dl";
                            goto Label_07A6;

                        case 1:
                            str3 = "1+";
                            str4 = "1+";
                            str5 = "1mg/dl";
                            goto Label_07A6;

                        case 2:
                            str3 = "2+";
                            str4 = "2+";
                            str5 = "3mg/dl";
                            goto Label_07A6;

                        case 3:
                            str3 = "3+";
                            str4 = "3+";
                            str5 = "6mg/dl";
                            goto Label_07A6;
                    }
                    break;

                case 0x19:
                    str = "葡萄糖";
                    str2 = "GLU";
                    num = 4;
                    switch (code)
                    {
                        case 0:
                            str3 = "阴性";
                            str4 = "阴性";
                            str5 = "0mg/dl";
                            goto Label_07A6;

                        case 1:
                            str3 = "+－";
                            str4 = "5.5mmol/L";
                            str5 = "50mg/dl";
                            goto Label_07A6;

                        case 2:
                            str3 = "1+";
                            str4 = "14mmol/L";
                            str5 = "100mg/dl";
                            goto Label_07A6;

                        case 3:
                            str3 = "2+";
                            str4 = "28mmol/l";
                            str5 = "250mg/dl";
                            goto Label_07A6;

                        case 4:
                            str3 = "3+";
                            str4 = ">=55mmol/l";
                            str5 = "500mg/dl";
                            goto Label_07A6;
                    }
                    break;

                case 0x1a:
                    str = "维生素C";
                    str2 = "VC";
                    num = 10;
                    switch (code)
                    {
                        case 0:
                            str3 = "阴性";
                            str4 = "阴性";
                            str5 = "0mg/dl";
                            goto Label_07A6;

                        case 1:
                            str3 = "0.6mmol/L";
                            str4 = "0.6mmol/L";
                            str5 = "10mg/dl";
                            goto Label_07A6;

                        case 2:
                            str3 = "1.4mmol/L";
                            str4 = "1.4mmol/L";
                            str5 = "25mg/dl";
                            goto Label_07A6;

                        case 3:
                            str3 = "2.8mmol/l";
                            str4 = "2.8mmol/l";
                            str5 = "50mg/dl";
                            goto Label_07A6;

                        case 4:
                            str3 = "5.0mmol/l";
                            str4 = "5.0mmol/l";
                            str5 = "100mg/dl";
                            goto Label_07A6;
                    }
                    break;

                case 0x1b:
                    str = "PH值";
                    str2 = "PH";
                    num = 6;
                    switch (code)
                    {
                        case 0:
                            str3 = "5";
                            str4 = "5";
                            str5 = "5";
                            goto Label_07A6;

                        case 1:
                            str3 = "5.5";
                            str4 = "5.5";
                            str5 = "5.5";
                            goto Label_07A6;

                        case 2:
                            str3 = "6";
                            str4 = "6";
                            str5 = "6";
                            goto Label_07A6;

                        case 3:
                            str3 = "6.5";
                            str4 = "6.5";
                            str5 = "6.5";
                            goto Label_07A6;

                        case 4:
                            str3 = "7";
                            str4 = "7";
                            str5 = "7";
                            goto Label_07A6;

                        case 5:
                            str3 = "7.5";
                            str4 = "7.5";
                            str5 = "7.5";
                            goto Label_07A6;

                        case 6:
                            str3 = "8";
                            str4 = "8";
                            str5 = "8";
                            goto Label_07A6;

                        case 7:
                            str3 = "8.5";
                            str4 = "8.5";
                            str5 = "8.5";
                            goto Label_07A6;

                        case 8:
                            str3 = ">=9";
                            str4 = ">=9";
                            str5 = ">=9";
                            goto Label_07A6;
                    }
                    break;

                case 0x1c:
                    str = "比重";
                    str2 = "SG";
                    num = 9;
                    switch (code)
                    {
                        case 0:
                            str3 = "<＝1.005";
                            str4 = "<＝1.005";
                            str5 = "<＝1.005";
                            goto Label_07A6;

                        case 1:
                            str3 = "1.010";
                            str4 = "1.010";
                            str5 = "1.010";
                            goto Label_07A6;

                        case 2:
                            str3 = "1.015";
                            str4 = "1.015";
                            str5 = "1.015";
                            goto Label_07A6;

                        case 3:
                            str3 = "1.020";
                            str4 = "1.020";
                            str5 = "1.020";
                            goto Label_07A6;

                        case 4:
                            str3 = "1.025";
                            str4 = "1.025";
                            str5 = "1.025";
                            goto Label_07A6;

                        case 5:
                            str3 = ">＝1.030";
                            str4 = ">＝1.030";
                            str5 = ">＝1.030";
                            goto Label_07A6;
                    }
                    break;
            }
        Label_07A6:
            result.friendName = str;
            result.engshort = str2;
            result.standard = str3;
            result.internation = str4;
            result.tradition = str5;
            result.index = num;
            return result;
        }

        public BCResult GetResult(int index, int code)
        {
            BCResult result = new BCResult();
            string str = "其它";
            string str2 = "ELSE";
            string str3 = "0";
            string str4 = "0";
            string str5 = "0";
            decimal num = 0M;
            decimal num2 = 0M;
            switch (index)
            {
                case 1:
                    str = "尿胆原";
                    str2 = "URO";
                    switch (code)
                    {
                        case 0:
                            str3 = "Norm";
                            str4 = "3.3umol/L";
                            str5 = "0.2mg/dl";
                            num = 3.3M;
                            num2 = 0.2M;
                            goto Label_0823;

                        case 1:
                            str3 = "+";
                            str4 = "33umol/L";
                            str5 = "2mg/dl";
                            num = 33M;
                            num2 = 2M;
                            goto Label_0823;

                        case 2:
                            str3 = "2+";
                            str4 = "66umol/L";
                            str5 = "4mg/dl";
                            num = 66M;
                            num2 = 4M;
                            goto Label_0823;

                        case 3:
                            str3 = ">＝3+";
                            str4 = "131umol/l";
                            str5 = "8mg/dl";
                            num = 131M;
                            num2 = 8M;
                            goto Label_0823;
                    }
                    break;

                case 2:
                    str = "潜血";
                    str2 = "BLD";
                    switch (code)
                    {
                        case 0:
                            str3 = "－";
                            str4 = "－";
                            str5 = "－";
                            num = 0M;
                            num2 = 0M;
                            goto Label_0823;

                        case 1:
                            str3 = "+－";
                            str4 = "10/ul";
                            str5 = "0.03mg/dl";
                            num = 10M;
                            num2 = 0.03M;
                            goto Label_0823;

                        case 2:
                            str3 = "+";
                            str4 = "25/ul";
                            str5 = "0.08mg/dl";
                            num = 25M;
                            num2 = 0.08M;
                            goto Label_0823;

                        case 3:
                            str3 = "2+";
                            str4 = "50/ul";
                            str5 = "0.15mg/dl";
                            num = 50M;
                            num2 = 0.15M;
                            goto Label_0823;

                        case 4:
                            str3 = "3+";
                            str4 = "250/ul";
                            str5 = "0.75mg/dl";
                            num = 250M;
                            num2 = 0.75M;
                            goto Label_0823;
                    }
                    break;

                case 3:
                    str = "胆红素";
                    str2 = "BIL";
                    switch (code)
                    {
                        case 0:
                            str3 = "－";
                            str4 = "0umol/L";
                            str5 = "0mg/dl";
                            goto Label_0823;

                        case 1:
                            str3 = "+";
                            str4 = "17umol/L";
                            str5 = "1mg/dl";
                            goto Label_0823;

                        case 2:
                            str3 = "2+";
                            str4 = "50umol/L";
                            str5 = "3mg/dl";
                            goto Label_0823;

                        case 3:
                            str3 = "3+";
                            str4 = "100umol/l";
                            str5 = "6mg/dl";
                            goto Label_0823;
                    }
                    break;

                case 4:
                    str = "酮体";
                    str2 = "KET";
                    switch (code)
                    {
                        case 0:
                            str3 = "－";
                            str4 = "0umol/L";
                            str5 = "0mg/dl";
                            num = 0M;
                            num2 = 0M;
                            goto Label_0823;

                        case 1:
                            str3 = "+";
                            str4 = "1.5umol/L";
                            str5 = "15mg/dl";
                            num = 1.5M;
                            num2 = 15M;
                            goto Label_0823;

                        case 2:
                            str3 = "2+";
                            str4 = "4.0umol/L";
                            str5 = "40mg/dl";
                            num = 4.0M;
                            num2 = 40M;
                            goto Label_0823;

                        case 3:
                            str3 = "3+";
                            str4 = "8.0umol/l";
                            str5 = "80mg/dl";
                            num = 8.0M;
                            num2 = 80M;
                            goto Label_0823;
                    }
                    break;

                case 5:
                    str = "葡萄糖";
                    str2 = "GLU";
                    switch (code)
                    {
                        case 0:
                            str3 = "－";
                            str4 = "0mmol/L";
                            str5 = "0mg/dl";
                            goto Label_0823;

                        case 1:
                            str3 = "+－";
                            str4 = "2.8mmol/L";
                            str5 = "50mg/dl";
                            goto Label_0823;

                        case 2:
                            str3 = "+";
                            str4 = "5.5mmol/L";
                            str5 = "100mg/dl";
                            goto Label_0823;

                        case 3:
                            str3 = "2+";
                            str4 = "14mmol/l";
                            str5 = "250mg/dl";
                            goto Label_0823;

                        case 4:
                            str3 = "3+";
                            str4 = "28mmol/l";
                            str5 = "500mg/dl";
                            goto Label_0823;

                        case 5:
                            str3 = "4+";
                            str4 = "55mmol/l";
                            str5 = "1000mg/dl";
                            goto Label_0823;
                    }
                    break;

                case 6:
                    str = "蛋白质";
                    str2 = "PRO";
                    switch (code)
                    {
                        case 0:
                            str3 = "－";
                            str4 = "0g/L";
                            str5 = "0mg/dl";
                            goto Label_0823;

                        case 1:
                            str3 = "+－";
                            str4 = "0.15g/L";
                            str5 = "15mg/dl";
                            goto Label_0823;

                        case 2:
                            str3 = "+";
                            str4 = "0.3g/L";
                            str5 = "30mg/dl";
                            goto Label_0823;

                        case 3:
                            str3 = "2+";
                            str4 = "1g/L";
                            str5 = "100mg/dl";
                            goto Label_0823;

                        case 4:
                            str3 = ">＝3+";
                            str4 = "3g/L";
                            str5 = "300mg/dl";
                            goto Label_0823;
                    }
                    break;

                case 7:
                    str = "PH值";
                    str2 = "PH";
                    switch (code)
                    {
                        case 0:
                            str3 = "5";
                            str4 = "5";
                            str5 = "5";
                            goto Label_0823;

                        case 1:
                            str3 = "6";
                            str4 = "6";
                            str5 = "6";
                            goto Label_0823;

                        case 2:
                            str3 = "7";
                            str4 = "7";
                            str5 = "7";
                            goto Label_0823;

                        case 3:
                            str3 = "8";
                            str4 = "8";
                            str5 = "8";
                            goto Label_0823;

                        case 4:
                            str3 = "9";
                            str4 = "9";
                            str5 = "9";
                            goto Label_0823;
                    }
                    break;

                case 8:
                    str = "亚硝酸盐";
                    str2 = "NIT";
                    switch (code)
                    {
                        case 0:
                            str3 = "－";
                            str4 = "－";
                            str5 = "－";
                            goto Label_0823;

                        case 1:
                            str3 = "+";
                            str4 = "18umol/L";
                            str5 = "0.12mg/dl";
                            goto Label_0823;
                    }
                    break;

                case 9:
                    str = "白细胞";
                    str2 = "LEU";
                    switch (code)
                    {
                        case 0:
                            str3 = "－";
                            str4 = "－";
                            str5 = "－";
                            goto Label_0823;

                        case 1:
                            str3 = "+－";
                            str4 = "15/ul";
                            str5 = "15/ul";
                            goto Label_0823;

                        case 2:
                            str3 = "+";
                            str4 = "70/ul";
                            str5 = "70/ul";
                            goto Label_0823;

                        case 3:
                            str3 = "2+";
                            str4 = "125/ul";
                            str5 = "125/ul";
                            goto Label_0823;

                        case 4:
                            str3 = "3+";
                            str4 = "500/ul";
                            str5 = "500/ul";
                            goto Label_0823;
                    }
                    break;

                case 10:
                    str = "比重";
                    str2 = "SG";
                    switch (code)
                    {
                        case 0:
                            str3 = "<＝1.005";
                            str4 = "<＝1.005";
                            str5 = "<＝1.005";
                            goto Label_0823;

                        case 1:
                            str3 = "1.010";
                            str4 = "1.010";
                            str5 = "1.010";
                            goto Label_0823;

                        case 2:
                            str3 = "1.015";
                            str4 = "1.015";
                            str5 = "1.015";
                            goto Label_0823;

                        case 3:
                            str3 = "1.020";
                            str4 = "1.020";
                            str5 = "1.020";
                            goto Label_0823;

                        case 4:
                            str3 = "1.025";
                            str4 = "1.025";
                            str5 = "1.025";
                            goto Label_0823;

                        case 5:
                            str3 = ">＝1.030";
                            str4 = ">＝1.030";
                            str5 = ">＝1.030";
                            goto Label_0823;
                    }
                    break;

                case 11:
                    str = "维生素C";
                    str2 = "VC";
                    switch (code)
                    {
                        case 0:
                            str3 = "－";
                            str4 = "0mmol/L";
                            str5 = "0mg/dl";
                            goto Label_0823;

                        case 1:
                            str3 = "+－";
                            str4 = "0.6mmol/L";
                            str5 = "10mg/dl";
                            goto Label_0823;

                        case 2:
                            str3 = "+";
                            str4 = "1.4mmol/L";
                            str5 = "25mg/dl";
                            goto Label_0823;

                        case 3:
                            str3 = "2+";
                            str4 = "2.8mmol/l";
                            str5 = "50mg/dl";
                            goto Label_0823;

                        case 4:
                            str3 = "3+";
                            str4 = "5.6mmol/l";
                            str5 = "100mg/dl";
                            goto Label_0823;
                    }
                    break;
            }
        Label_0823:
            result.friendName = str;
            result.engshort = str2;
            result.standard = str3;
            result.internation = str4;
            result.tradition = str5;
            result.index = index;
            return result;
        }

        public bool GetResultList(byte[] buffer)
        {
            int num;
            if (buffer.Length < 40)
            {
                return false;
            }
            if (this.m_result == null)
            {
                return false;
            }
            byte[] buffer2 = new byte[0x16];
            for (num = 0; num < 0x16; num++)
            {
                buffer2[num] = (byte) buffer.GetValue((int) (15 + num));
            }
            for (num = 0; num < 0x16; num += 2)
            {
                this.m_result.Add(this.GetResult(Convert.ToInt16(buffer2[num]), Convert.ToInt16(buffer2[num + 1])));
            }
            return true;
        }

        public string GetValueByIndex(int index)
        {
            for (int i = 0; i < this.m_result.Count; i++)
            {
                if (this.m_result[i].index == index)
                {
                    return this.m_result[i].standard;
                }
            }
            return "";
        }

        public string DeviceAddress
        {
            get
            {
                return this.Address;
            }
            set
            {
                this.Address = value;
            }
        }

        public string DeviceFriendName
        {
            get
            {
                return this.FriendName;
            }
            set
            {
                this.FriendName = value;
            }
        }

        public string DeviceName
        {
            get
            {
                return this.Name;
            }
            set
            {
                this.Name = value;
            }
        }

        public string DeviceType
        {
            get
            {
                return this.DevType;
            }
            set
            {
                this.DevType = value;
            }
        }

        public string DeviceValue1
        {
            get
            {
                return this.Value1;
            }
            set
            {
                this.Value1 = value;
            }
        }

        public string DeviceValue2
        {
            get
            {
                return this.Value2;
            }
            set
            {
                this.Value2 = value;
            }
        }

        public string DeviceValue3
        {
            get
            {
                return this.Value3;
            }
            set
            {
                this.Value3 = value;
            }
        }

        public string DeviceValue4
        {
            get
            {
                return this.Value4;
            }
            set
            {
                this.Value4 = value;
            }
        }

        public string DeviceValue5
        {
            get
            {
                return this.Value5;
            }
            set
            {
                this.Value5 = value;
            }
        }

        public string DeviceValue6
        {
            get
            {
                return this.Value6;
            }
            set
            {
                this.Value6 = value;
            }
        }

        public string DeviceValue7
        {
            get
            {
                return this.Value7;
            }
            set
            {
                this.Value7 = value;
            }
        }

        public string DeviceValue8
        {
            get
            {
                return this.Value8;
            }
            set
            {
                this.Value8 = value;
            }
        }

        public string DeviceValue9
        {
            get
            {
                return this.Value9;
            }
            set
            {
                this.Value9 = value;
            }
        }
    }
}

