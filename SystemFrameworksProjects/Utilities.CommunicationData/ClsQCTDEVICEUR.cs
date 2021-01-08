namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;

    internal class ClsQCTDEVICEUR : ClsQCTDevice
    {
        public ClsQCTDEVICEUR(ClsCommunication comm)
        {
            base.m_Comm = comm;
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
            base.ResultData = new byte[0x31];
            base.m_Comm.SetTimeOut(0x2710);
            Thread.Sleep(500);
            base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(500);
            int num = base.m_Comm.Recv(ref this.ResultData, 0x31);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            if (num != 0x31)
            {
                return false;
            }
            ClsResult.DeviceName = "QCTUI";
            ClsResult.DeviceFriendName = "尿液分析";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            this.GetResultList(base.ResultData);
            ClsResult.ResultFlag = true;
            return true;
        }

        public BCResult GetAiKangResult(int index, int code)
        {
            BCResult result = new BCResult();
            string str = "其它";
            string str2 = "ELSE";
            string str3 = "0";
            string str4 = "0";
            string str5 = "0";
            switch (index)
            {
                case 1:
                    str = "尿胆原";
                    str2 = "URO";
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "3.3umol/L";
                            str5 = "0.2mg/dl";
                            goto Label_07EF;

                        case 1:
                            str3 = "+-";
                            str4 = "17umol/l";
                            str5 = "1mg/dl";
                            goto Label_07EF;

                        case 2:
                            str3 = "1+";
                            str4 = "33umol/L";
                            str5 = "2mg/dl";
                            goto Label_07EF;

                        case 3:
                            str3 = "2+";
                            str4 = "66umol/L";
                            str5 = "4mg/dl";
                            goto Label_07EF;

                        case 4:
                            str3 = "3+";
                            str4 = "131umol/l";
                            str5 = "8mg/dl";
                            goto Label_07EF;
                    }
                    break;

                case 2:
                    str = "潜血";
                    str2 = "BLD";
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_07EF;

                        case 1:
                            str3 = "+-";
                            str4 = "10/ul";
                            str5 = "0.03mg/dl";
                            goto Label_07EF;

                        case 2:
                            str3 = "1+";
                            str4 = "25/ul";
                            str5 = "0.08mg/dl";
                            goto Label_07EF;

                        case 3:
                            str3 = "2+";
                            str4 = "50/ul";
                            str5 = "0.15mg/dl";
                            goto Label_07EF;

                        case 4:
                            str3 = "3+";
                            str4 = "250/ul";
                            str5 = "0.75mg/dl";
                            goto Label_07EF;
                    }
                    break;

                case 3:
                    str = "胆红素";
                    str2 = "BIL";
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "0umol/L";
                            str5 = "0mg/dl";
                            goto Label_07EF;

                        case 1:
                            str3 = "1+";
                            str4 = "17umol/L";
                            str5 = "1mg/dl";
                            goto Label_07EF;

                        case 2:
                            str3 = "2+";
                            str4 = "50umol/L";
                            str5 = "3mg/dl";
                            goto Label_07EF;

                        case 3:
                            str3 = "3+";
                            str4 = "100umol/l";
                            str5 = "6mg/dl";
                            goto Label_07EF;
                    }
                    break;

                case 4:
                    str = "酮体";
                    str2 = "KET";
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "0umol/L";
                            str5 = "0mg/dl";
                            goto Label_07EF;

                        case 1:
                            str3 = "+-";
                            str4 = "0.5umol/l";
                            str5 = "5mg/dl";
                            goto Label_07EF;

                        case 2:
                            str3 = "1+";
                            str4 = "1.5umol/L";
                            str5 = "15mg/dl";
                            goto Label_07EF;

                        case 3:
                            str3 = "2+";
                            str4 = "4.0umol/L";
                            str5 = "40mg/dl";
                            goto Label_07EF;

                        case 4:
                            str3 = "3+";
                            str4 = "8.0umol/l";
                            str5 = "80mg/dl";
                            goto Label_07EF;
                    }
                    break;

                case 5:
                    str = "葡萄糖";
                    str2 = "GLU";
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "0mmol/L";
                            str5 = "0mg/dl";
                            goto Label_07EF;

                        case 1:
                            str3 = "+-";
                            str4 = "2.8mmol/L";
                            str5 = "50mg/dl";
                            goto Label_07EF;

                        case 2:
                            str3 = "1+";
                            str4 = "5.5mmol/L";
                            str5 = "100mg/dl";
                            goto Label_07EF;

                        case 3:
                            str3 = "2+";
                            str4 = "14mmol/l";
                            str5 = "250mg/dl";
                            goto Label_07EF;

                        case 4:
                            str3 = "3+";
                            str4 = "28mmol/l";
                            str5 = "500mg/dl";
                            goto Label_07EF;

                        case 5:
                            str3 = "4+";
                            str4 = "55mmol/l";
                            str5 = "1000mg/dl";
                            goto Label_07EF;
                    }
                    break;

                case 6:
                    str = "蛋白质";
                    str2 = "PRO";
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "0g/L";
                            str5 = "0mg/dl";
                            goto Label_07EF;

                        case 1:
                            str3 = "+-";
                            str4 = "0.15g/L";
                            str5 = "15mg/dl";
                            goto Label_07EF;

                        case 2:
                            str3 = "1+";
                            str4 = "0.3g/L";
                            str5 = "30mg/dl";
                            goto Label_07EF;

                        case 3:
                            str3 = "2+";
                            str4 = "1g/L";
                            str5 = "100mg/dl";
                            goto Label_07EF;

                        case 4:
                            str3 = "3+";
                            str4 = "3g/L";
                            str5 = "300mg/dl";
                            goto Label_07EF;
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
                            goto Label_07EF;

                        case 1:
                            str3 = "5.5";
                            str4 = "5.5";
                            str5 = "5.5";
                            goto Label_07EF;

                        case 2:
                            str3 = "6";
                            str4 = "6";
                            str5 = "6";
                            goto Label_07EF;

                        case 3:
                            str3 = "6.5";
                            str4 = "6.5";
                            str5 = "6.5";
                            goto Label_07EF;

                        case 4:
                            str3 = "7";
                            str4 = "7";
                            str5 = "7";
                            goto Label_07EF;

                        case 5:
                            str3 = "7.5";
                            str4 = "7.5";
                            str5 = "7.5";
                            goto Label_07EF;

                        case 6:
                            str3 = "8";
                            str4 = "8";
                            str5 = "8";
                            goto Label_07EF;

                        case 7:
                            str3 = "8.5";
                            str4 = "8.5";
                            str5 = "8.5";
                            goto Label_07EF;

                        case 8:
                            str3 = "9";
                            str4 = "9";
                            str5 = "9";
                            goto Label_07EF;
                    }
                    break;

                case 8:
                    str = "亚硝酸盐";
                    str2 = "NIT";
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_07EF;

                        case 1:
                            str3 = "1+";
                            str4 = "18umol/L";
                            str5 = "0.12mg/dl";
                            goto Label_07EF;
                    }
                    break;

                case 9:
                    str = "白细胞";
                    str2 = "LEU";
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_07EF;

                        case 1:
                            str3 = "+-";
                            str4 = "15/ul";
                            str5 = "15/ul";
                            goto Label_07EF;

                        case 2:
                            str3 = "1+";
                            str4 = "70/ul";
                            str5 = "70/ul";
                            goto Label_07EF;

                        case 3:
                            str3 = "2+";
                            str4 = "125/ul";
                            str5 = "125/ul";
                            goto Label_07EF;

                        case 4:
                            str3 = "3+";
                            str4 = "500/ul";
                            str5 = "500/ul";
                            goto Label_07EF;
                    }
                    break;

                case 10:
                    str = "比重";
                    str2 = "SG";
                    switch (code)
                    {
                        case 0:
                            str3 = "1.000";
                            str4 = "1.000";
                            str5 = "1.000";
                            goto Label_07EF;

                        case 1:
                            str3 = "1.005";
                            str4 = "1.005";
                            str5 = "1.005";
                            goto Label_07EF;

                        case 2:
                            str3 = "1.010";
                            str4 = "1.010";
                            str5 = "1.010";
                            goto Label_07EF;

                        case 3:
                            str3 = "1.015";
                            str4 = "1.015";
                            str5 = "1.015";
                            goto Label_07EF;

                        case 4:
                            str3 = "1.020";
                            str4 = "1.020";
                            str5 = "1.020";
                            goto Label_07EF;

                        case 5:
                            str3 = "1.025";
                            str4 = "1.025";
                            str5 = "1.025";
                            goto Label_07EF;

                        case 6:
                            str3 = "1.030";
                            str4 = "1.030";
                            str5 = "1.030";
                            goto Label_07EF;
                    }
                    break;

                case 11:
                    str = "维生素C";
                    str2 = "VC";
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "0mmol/L";
                            str5 = "0mg/dl";
                            goto Label_07EF;

                        case 1:
                            str3 = "1+";
                            str4 = "1.4mmol/L";
                            str5 = "25mg/dl";
                            goto Label_07EF;

                        case 2:
                            str3 = "2+";
                            str4 = "2.8mmol/l";
                            str5 = "50mg/dl";
                            goto Label_07EF;

                        case 3:
                            str3 = "3+";
                            str4 = "5.6mmol/l";
                            str5 = "100mg/dl";
                            goto Label_07EF;
                    }
                    break;
            }
        Label_07EF:
            result.friendName = str;
            result.engshort = str2;
            result.standard = str3;
            result.internation = str4;
            result.tradition = str5;
            return result;
        }

        private bool GetResultList(byte[] buffer)
        {
            if (buffer.Length < 40)
            {
                return false;
            }
            ClsResult.DeviceValue.QCTUI.BarCode = Convert.ToInt32(buffer[3].ToString("X2") + buffer[4].ToString("X2"), 0x10).ToString();
            byte[] buffer2 = new byte[0x16];
            for (int i = 0; i < 0x16; i++)
            {
                buffer2[i] = (byte) buffer.GetValue((int) (15 + i));
            }
            for (int j = 0; j < 0x16; j += 2)
            {
                BCResult aiKangResult = this.GetAiKangResult(Convert.ToInt16(buffer2[j]), Convert.ToInt16(buffer2[j + 1]));
                switch (aiKangResult.engshort)
                {
                    case "URO":
                        ClsResult.DeviceValue.QCTUI.URO_NiaoDanYuan = aiKangResult.standard;
                        break;

                    case "BLD":
                        ClsResult.DeviceValue.QCTUI.BLD_QianXue = aiKangResult.standard;
                        break;

                    case "BIL":
                        ClsResult.DeviceValue.QCTUI.BIL_DanHongSu = aiKangResult.standard;
                        break;

                    case "KET":
                        ClsResult.DeviceValue.QCTUI.KET_TongTi = aiKangResult.standard;
                        break;

                    case "LEU":
                        ClsResult.DeviceValue.QCTUI.LEU_BaiXiBao = aiKangResult.standard;
                        break;

                    case "GLU":
                        ClsResult.DeviceValue.QCTUI.GLU_PuTaoTang = aiKangResult.standard;
                        break;

                    case "PRO":
                        ClsResult.DeviceValue.QCTUI.PRO_DanBaiZhi = aiKangResult.standard;
                        break;

                    case "PH":
                        ClsResult.DeviceValue.QCTUI.PH = aiKangResult.standard;
                        break;

                    case "NIT":
                        ClsResult.DeviceValue.QCTUI.NIT_XiaoSuanYan = aiKangResult.standard;
                        break;

                    case "SG":
                        ClsResult.DeviceValue.QCTUI.SG_BiZhong = aiKangResult.standard;
                        break;

                    case "VC":
                        ClsResult.DeviceValue.QCTUI.VC = aiKangResult.standard;
                        break;
                }
            }
            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x42, 0x34, 4, 0, 2, 5, 11 };
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
                return new byte[] { 0x42, 0x34, 4, 0, 2, 2, 8 };
            }
        }
    }
}

