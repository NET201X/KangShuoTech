using System;
using System.Threading;

namespace KangShuoTech.Utilities.CommunicationData
{
    /// <summary>
    /// 尿液分析
    /// </summary>
    internal class ClsEMPDEVICEUI : ClsQCTDevice
    {
        public ClsEMPDEVICEUI(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 20000;
        }

        public override bool ExecClose()
        {
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);

            return true;
        }

        public override bool ExecQuery()
        {
            base.ResultData = new byte[19];
            base.m_Comm.SetTimeOut(10000);
            //Thread.Sleep(500);
            base.m_Comm.Send(this.CommandRead);
            
            //int num = 0;
            int num = base.m_Comm.Recv(ref this.ResultData, 19);
            //Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);
            //Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);

            //if (num < 19 || ResultData[6] == 255)
            //{
            //    ClsResult.ResultFlag = false;
            //    return true;
            //}
            if (num < 19 || ResultData[0] != 147 || ResultData[1] != 142 || ResultData[2] != 16 ||
                 ResultData[3] != 0 || ResultData[4] != 8 || ResultData[5] != 4 || ResultData[6] == 255 || ResultData[18] == 16)
            {
                ClsResult.ResultFlag = false;
                return true;
            }

            ClsResult.DeviceName = "QCTUI";
            ClsResult.DeviceFriendName = "尿液分析";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();

            this.GetResultList(base.ResultData);

            ClsResult.ResultFlag = true;
            return true;
        }

        private BCResult GetResult(string code, int value)
        {
            BCResult result = new BCResult();

            string str = "其它";
            string str2 = "ELSE";
            string str3 = "0";
            string str4 = "0";
            string str5 = "0";

            switch (code)
            {
                case "UBG":
                    str = "尿胆原";
                    str2 = "UBG";
                    switch (value)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "3.2umol/L";
                            str5 = "0.2mg/dl";
                            goto Label_0741;

                        case 1:
                            str3 = "+1";
                            str4 = "32umol/L";
                            str5 = "2mg/dl";
                            goto Label_0741;

                        case 2:
                            str3 = "+2";
                            str4 = "64umol/L";
                            str5 = "4mg/dl";
                            goto Label_0741;

                        case 3:
                            str3 = "+3";
                            str4 = "128umol/l";
                            str5 = "8mg/dl";
                            goto Label_0741;
                    }
                    break;

                case "BLD":
                    str = "潜血";
                    str2 = "BLD";
                    switch (value)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_0741;

                        case 1:
                            str3 = "+-";
                            str4 = "微量(溶血)";
                            str5 = "微量(溶血)";
                            goto Label_0741;

                        case 2:
                            str3 = "+1";
                            str4 = "25cells/ul";
                            str5 = "25cells/ul";
                            goto Label_0741;

                        case 3:
                            str3 = "+2";
                            str4 = "80cells/ul";
                            str5 = "80cells/ul";
                            goto Label_0741;

                        case 4:
                            str3 = "+3";
                            str4 = "200cells/ul";
                            str5 = "200cells/ul";
                            goto Label_0741;
                    }
                    break;

                case "BIL":
                    str = "胆红素";
                    str2 = "BIL";
                    switch (value)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_0741;

                        case 1:
                            str3 = "+1";
                            str4 = "17umol/L";
                            str5 = "1mg/dl";
                            goto Label_0741;

                        case 2:
                            str3 = "+2";
                            str4 = "50umol/L";
                            str5 = "3mg/dl";
                            goto Label_0741;

                        case 3:
                            str3 = "+3";
                            str4 = "100umol/l";
                            str5 = "6mg/dl";
                            goto Label_0741;
                    }
                    break;

                case "KET":
                    str = "酮体";
                    str2 = "KET";
                    switch (value)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_0741;

                        case 1:
                            str3 = "+-";
                            str4 = "0.5mmol/L";
                            str5 = "5mg/dl";
                            goto Label_0741;

                        case 2:
                            str3 = "+1";
                            str4 = "1.5mmol/L";
                            str5 = "15mg/dl";
                            goto Label_0741;

                        case 3:
                            str3 = "+2";
                            str4 = "4.0mmol/l";
                            str5 = "40mg/dl";
                            goto Label_0741;

                        case 4:
                            str3 = "+3";
                            str4 = "8.0mmol/l";
                            str5 = "80mg/dl";
                            goto Label_0741;

                        case 5:
                            str3 = "+4";
                            str4 = "16.0mmol/l";
                            str5 = "160mg/dl";
                            goto Label_0741;
                    }
                    break;

                case "GLU":
                    str = "葡萄糖";
                    str2 = "GLU";
                    switch (value)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_0741;

                        case 1:
                            str3 = "+-";
                            str4 = "5mmol/L";
                            str5 = "100mg/dl";
                            goto Label_0741;

                        case 2:
                            str3 = "+1";
                            str4 = "15mmol/L";
                            str5 = "250mg/dl";
                            goto Label_0741;

                        case 3:
                            str3 = "+2";
                            str4 = "30mmol/l";
                            str5 = "500mg/dl";
                            goto Label_0741;

                        case 4:
                            str3 = "+3";
                            str4 = "60mmol/l";
                            str5 = "1000mg/dl";
                            goto Label_0741;

                        case 5:
                            str3 = "+4";
                            str4 = "110mmol/l";
                            str5 = ">2000mg/dl";
                            goto Label_0741;
                    }
                    break;

                case "PRO":
                    str = "蛋白质";
                    str2 = "PRO";

                    switch (value)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_0741;

                        case 1:
                            str3 = "+-";
                            str4 = "微量";
                            str5 = "微量";
                            goto Label_0741;

                        case 2:
                            str3 = "+1";
                            str4 = "0.3g/L";
                            str5 = "30mg/dl";
                            goto Label_0741;

                        case 3:
                            str3 = "+2";
                            str4 = "1g/L";
                            str5 = "100mg/dl";
                            goto Label_0741;

                        case 4:
                            str3 = "+3";
                            str4 = "3g/L";
                            str5 = "300mg/dl";
                            goto Label_0741;
                        case 5:
                            str3 = "+4";
                            str4 = ">20.0g/L";
                            str5 = ">2000mg/dl";
                            goto Label_0741;
                    }

                    break;

                case "PH":
                    str = "PH值";
                    str2 = "PH";
                    switch (value)
                    {
                        case 0:
                            str3 = "5.0";
                            str4 = "5.0";
                            str5 = "5.0";
                            goto Label_0741;

                        case 1:
                            str3 = "6.0";
                            str4 = "6.0";
                            str5 = "6.0";
                            goto Label_0741;

                        case 2:
                            str3 = "6.5";
                            str4 = "6.5";
                            str5 = "6.5";
                            goto Label_0741;

                        case 3:
                            str3 = "7.0";
                            str4 = "7.0";
                            str5 = "7.0";
                            goto Label_0741;

                        case 4:
                            str3 = "7.5";
                            str4 = "7.5";
                            str5 = "7.5";
                            goto Label_0741;

                        case 5:
                            str3 = "8.0";
                            str4 = "8.0";
                            str5 = "8.0";
                            goto Label_0741;

                        case 6:
                            str3 = "8.5";
                            str4 = "8.5";
                            str5 = "8.5";
                            goto Label_0741;
                    }
                    break;

                case "NIT":
                    str = "亚硝酸盐";
                    str2 = "NIT";
                    switch (value)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_0741;

                        case 1:
                            str3 = "+";
                            str4 = "+";
                            str5 = "+";
                            goto Label_0741;
                    }
                    break;

                case "LEU":
                    str = "白细胞";
                    str2 = "LEU";
                    switch (value)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_0741;

                        case 1:
                            str3 = "+-";
                            str4 = "15/ul";
                            str5 = "15/ul";
                            goto Label_0741;

                        case 2:
                            str3 = "+1";
                            str4 = "70/ul";
                            str5 = "70/ul";
                            goto Label_0741;

                        case 3:
                            str3 = "+2";
                            str4 = "125/ul";
                            str5 = "125/ul";
                            goto Label_0741;

                        case 4:
                            str3 = "+3";
                            str4 = "500/ul";
                            str5 = "500/ul";
                            goto Label_0741;
                    }
                    break;

                case "SG":
                    str = "比重";
                    str2 = "SG";
                    switch (value)
                    {
                        case 0:
                            str3 = "1.000";
                            str4 = "1.000";
                            str5 = "1.000";
                            goto Label_0741;

                        case 1:
                            str3 = "1.005";
                            str4 = "1.005";
                            str5 = "1.005";
                            goto Label_0741;

                        case 2:
                            str3 = "1.010";
                            str4 = "1.010";
                            str5 = "1.010";
                            goto Label_0741;

                        case 3:
                            str3 = "1.015";
                            str4 = "1.015";
                            str5 = "1.015";
                            goto Label_0741;

                        case 4:
                            str3 = "1.020";
                            str4 = "1.020";
                            str5 = "1.020";
                            goto Label_0741;

                        case 5:
                            str3 = "1.025";
                            str4 = "1.025";
                            str5 = "1.025";
                            goto Label_0741;

                        case 6:
                            str3 = "1.030";
                            str4 = "1.030";
                            str5 = "1.030";
                            goto Label_0741;
                    }
                    break;

                case "VC":
                    str = "维生素C";
                    str2 = "VC";
                    switch (value)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_0741;

                        case 1:
                            str3 = "+-";
                            str4 = "0.6mmol/L";
                            str5 = "0.6mmol/L";
                            goto Label_0741;

                        case 2:
                            str3 = "+1";
                            str4 = "1.4mmol/L";
                            str5 = "1.4mmol/L";
                            goto Label_0741;

                        case 3:
                            str3 = "+2";
                            str4 = "2.8mmol/l";
                            str5 = "2.8mmol/l";
                            goto Label_0741;

                        case 4:
                            str3 = "+3";
                            str4 = "5.6mmol/l";
                            str5 = "5.6mmol/l";
                            goto Label_0741;
                    }
                    break;
            }
        Label_0741:
            result.friendName = str;
            result.engshort = str2;
            result.standard = str3;
            result.internation = str4;
            result.tradition = str5;
            return result;
        }

        private bool GetResultList(byte[] buffer)
        {
            if (buffer.Length < 19)
            {
                return false;
            }

            byte[] buffer2 = new byte[12];

            for (int i = 0; i < 12; i++)
            {
                buffer2[i] = (byte)buffer.GetValue((int)(6 + i));
            }

            string[] str = new string[6];

            for (int j = 0; j < 12; j += 2)
            {
                str[j / 2] = int.Parse(Convert.ToString(buffer2[j], 2)).ToString("00000000") + int.Parse(Convert.ToString(buffer2[j + 1], 2)).ToString("00000000");
            }

            //白细胞
            string strValue = str[3].Substring(2, 3);
            int value = Convert.ToInt32(strValue, 2);
            BCResult result = this.GetResult("LEU", value);
            ClsResult.DeviceValue.QCTUI.LEU_BaiXiBao = result.standard;

            //潜血
            strValue = str[4].Substring(1, 3);
            value = Convert.ToInt32(strValue, 2);
            result = this.GetResult("BLD", value);
            ClsResult.DeviceValue.QCTUI.BLD_QianXue = result.standard;

            //PH
            strValue = str[4].Substring(4, 3);
            value = Convert.ToInt32(strValue, 2);
            result = this.GetResult("PH", value);
            ClsResult.DeviceValue.QCTUI.PH = result.standard;

            //蛋白质
            strValue = str[4].Substring(7, 3);
            value = Convert.ToInt32(strValue, 2);
            result = this.GetResult("PRO", value);
            ClsResult.DeviceValue.QCTUI.PRO_DanBaiZhi = result.standard;

            //UBG尿胆原
            strValue = str[4].Substring(10, 3);
            value = Convert.ToInt32(strValue, 2);
            result = this.GetResult("UBG", value);
            ClsResult.DeviceValue.QCTUI.URO_NiaoDanYuan = result.standard;

            //NIT亚硝酸盐
            strValue = str[4].Substring(13, 3);
            value = Convert.ToInt32(strValue, 2);
            result = this.GetResult("NIT", value);
            ClsResult.DeviceValue.QCTUI.NIT_XiaoSuanYan = result.standard;

            //PF

            //VC维生素C
            strValue = str[5].Substring(1, 3);
            value = Convert.ToInt32(strValue, 2);
            result = this.GetResult("VC", value);
            ClsResult.DeviceValue.QCTUI.VC = result.standard;

            //GLU葡萄糖
            strValue = str[5].Substring(4, 3);
            value = Convert.ToInt32(strValue, 2);
            result = this.GetResult("GLU", value);
            ClsResult.DeviceValue.QCTUI.GLU_PuTaoTang = result.standard;

            //BIL胆红素
            strValue = str[5].Substring(7, 3);
            value = Convert.ToInt32(strValue, 2);
            result = this.GetResult("BIL", value);
            ClsResult.DeviceValue.QCTUI.BIL_DanHongSu = result.standard;

            //KET酮体
            strValue = str[5].Substring(10, 3);
            value = Convert.ToInt32(strValue, 2);
            result = this.GetResult("KET", value);
            ClsResult.DeviceValue.QCTUI.KET_TongTi = result.standard;

            //SG比重
            strValue = str[5].Substring(13, 3);
            value = Convert.ToInt32(strValue, 2);
            result = this.GetResult("SG", value);
            ClsResult.DeviceValue.QCTUI.SG_BiZhong = result.standard;

            switch (result.engshort)
            {
                case "URO":
                    ClsResult.DeviceValue.QCTUI.URO_NiaoDanYuan = result.standard;
                    break;

                case "BLD":
                    ClsResult.DeviceValue.QCTUI.BLD_QianXue = result.standard;
                    break;

                case "BIL":
                    ClsResult.DeviceValue.QCTUI.BIL_DanHongSu = result.standard;
                    break;

                case "KET":
                    ClsResult.DeviceValue.QCTUI.KET_TongTi = result.standard;
                    break;

                case "LEU":
                    ClsResult.DeviceValue.QCTUI.LEU_BaiXiBao = result.standard;
                    break;

                case "GLU":
                    ClsResult.DeviceValue.QCTUI.GLU_PuTaoTang = result.standard;
                    break;

                case "PRO":
                    ClsResult.DeviceValue.QCTUI.PRO_DanBaiZhi = result.standard;
                    break;

                case "PH":
                    ClsResult.DeviceValue.QCTUI.PH = result.standard;
                    break;

                case "NIT":
                    ClsResult.DeviceValue.QCTUI.NIT_XiaoSuanYan = result.standard;
                    break;

                case "SG":
                    ClsResult.DeviceValue.QCTUI.SG_BiZhong = result.standard;
                    break;

                case "VC":
                    ClsResult.DeviceValue.QCTUI.VC = result.standard;
                    break;
            }

            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x93, 0x8e, 0x06, 0x00, 0x08, 0x06, 0x00, 0x00, 0x14 };
            }
        }

        public override byte[] CommandQuery
        {
            get
            {
                byte[] buffer = new byte[1];
                buffer.Initialize();
                return buffer;
            }
        }

        public override byte[] CommandRead
        {
            get
            {
                return new byte[] { 0x93, 0x8e, 0x04, 0x00, 0x08, 0x04, 0x10 };
            }
        }
    }
}
