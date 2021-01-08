namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;

    internal class ClsQCTDEVICEBU : ClsQCTDevice
    {
        public ClsQCTDEVICEBU(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 0xbb8;
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
            ClsResult.DeviceFriendName = "";
            ClsResult.DeviceValue.QCTBU.ChildType = "";
            ClsResult.ResultFlag = false;
            base.ResultData = new byte[0x35];
            base.m_Comm.SetTimeOut(0x2710);
            base.m_Comm.Recv(ref this.ResultData, 0x35);
            int num = 0;
            if (base.ResultData[0] == 0xa7)
            {
                num = 0;
            }
            else if (base.ResultData[0] == 0xb8)
            {
                num = 1;
            }
            byte typeindex = base.ResultData[0x1f - num];
            byte[] buffer = new byte[] { base.ResultData[0x1b - num], base.ResultData[0x1c - num], base.ResultData[0x1d - num], base.ResultData[30 - num] };
            if (typeindex < 0x12)
            {
                double num4 = (((((buffer[0] - 0x30) * 1000.0) + ((buffer[1] - 0x30) * 100.0)) + ((buffer[2] - 0x30) * 10.0)) + (buffer[3] - 0x30)) / 100.0;
                ClsResult.DeviceName = "QCTBU";
                ClsResult.DeviceFriendName = "血液";
                ClsResult.DeviceAddress = "";
                ClsResult.ResultFlag = true;
                ClsResult.DeviceValue = new valueItem();
                switch (typeindex)
                {
                    case 14:
                        ClsResult.DeviceValue.QCTBU.ChildType = "胆固醇";
                        ClsResult.DeviceValue.QCTBU.DanGuChun = num4.ToString("0.00");
                        break;

                    case 15:
                        ClsResult.DeviceValue.QCTBU.ChildType = "甘油三酯";
                        ClsResult.DeviceValue.QCTBU.GanYouSanZhi = num4.ToString("0.00");
                        break;

                    case 0x10:
                        ClsResult.DeviceValue.QCTBU.ChildType = "高密度脂蛋白";
                        ClsResult.DeviceValue.QCTBU.GaoMiDu = num4.ToString("0.00");
                        break;

                    case 0x11:
                        ClsResult.DeviceValue.QCTBU.ChildType = "血酮体";
                        ClsResult.DeviceValue.QCTBU.XueTongTi = num4.ToString("0.00");
                        break;

                    case 8:
                        ClsResult.DeviceValue.QCTBU.ChildType = "血糖";
                        ClsResult.DeviceValue.QCTBU.XueTang = num4.ToString("0.00");
                        break;
                }
            }
            else
            {
                ClsResult.DeviceValue = new valueItem();
                ClsResult.DeviceValue.QCTBU.URO_NiaoDanYuan = "";
                ClsResult.DeviceValue.QCTBU.BLD_QianXue = "";
                ClsResult.DeviceValue.QCTBU.BIL_DanHongSu = "";
                ClsResult.DeviceValue.QCTBU.KET_TongTi = "";
                ClsResult.DeviceValue.QCTBU.LEU_BaiXiBao = "";
                ClsResult.DeviceValue.QCTBU.GLU_PuTaoTang = "";
                ClsResult.DeviceValue.QCTBU.PRO_DanBaiZhi = "";
                ClsResult.DeviceValue.QCTBU.PH = "";
                ClsResult.DeviceValue.QCTBU.NIT_XiaoSuanYan = "";
                ClsResult.DeviceValue.QCTBU.SG_BiZhong = "";
                ClsResult.DeviceValue.QCTBU.VC = "";
                BCResult result = this.GetResult(typeindex, buffer[0]);
                for (int i = 0; i < 11; i++)
                {
                    if (i == result.index)
                    {
                        switch (result.engshort)
                        {
                            case "URO":
                                ClsResult.DeviceValue.QCTBU.ChildType = "尿胆原";
                                ClsResult.DeviceValue.QCTBU.URO_NiaoDanYuan = result.standard;
                                break;

                            case "BLD":
                                ClsResult.DeviceValue.QCTBU.ChildType = "潜 血";
                                ClsResult.DeviceValue.QCTBU.BLD_QianXue = result.standard;
                                break;

                            case "BIL":
                                ClsResult.DeviceValue.QCTBU.ChildType = "胆红素";
                                ClsResult.DeviceValue.QCTBU.BIL_DanHongSu = result.standard;
                                break;

                            case "KET":
                                ClsResult.DeviceValue.QCTBU.ChildType = "尿酮体";
                                ClsResult.DeviceValue.QCTBU.KET_TongTi = result.standard;
                                break;

                            case "LEU":
                                ClsResult.DeviceValue.QCTBU.ChildType = "白细胞";
                                ClsResult.DeviceValue.QCTBU.LEU_BaiXiBao = result.standard;
                                break;

                            case "GLU":
                                ClsResult.DeviceValue.QCTBU.ChildType = "葡萄糖";
                                ClsResult.DeviceValue.QCTBU.GLU_PuTaoTang = result.standard;
                                break;

                            case "PRO":
                                ClsResult.DeviceValue.QCTBU.ChildType = "蛋白质";
                                ClsResult.DeviceValue.QCTBU.PRO_DanBaiZhi = result.standard;
                                break;

                            case "PH":
                                ClsResult.DeviceValue.QCTBU.ChildType = "PH值";
                                ClsResult.DeviceValue.QCTBU.PH = result.standard;
                                break;

                            case "NIT":
                                ClsResult.DeviceValue.QCTBU.ChildType = "亚硝酸盐";
                                ClsResult.DeviceValue.QCTBU.NIT_XiaoSuanYan = result.standard;
                                break;

                            case "SG":
                                ClsResult.DeviceValue.QCTBU.ChildType = "比重";
                                ClsResult.DeviceValue.QCTBU.SG_BiZhong = result.standard;
                                break;

                            case "VC":
                                ClsResult.DeviceValue.QCTBU.ChildType = "维生素C";
                                ClsResult.DeviceValue.QCTBU.VC = result.standard;
                                break;
                        }
                        break;
                    }
                }
                ClsResult.DeviceName = "QCTBU";
                ClsResult.DeviceFriendName = "尿液";
                ClsResult.DeviceAddress = "";
                ClsResult.ResultFlag = true;
            }
            ClsResult.ResultFlag = ClsResult.DeviceValue.QCTBU.ChildType != "";
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            return ClsResult.ResultFlag;
        }

        private BCResult GetResult(int typeindex, int code)
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
                    num = 8;
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_07F9;

                        case 1:
                            str3 = "1+";
                            str4 = "1+";
                            str5 = "0.12mg/dl";
                            goto Label_07F9;
                    }
                    break;

                case 0x13:
                    str = "白细胞";
                    str2 = "LEU";
                    num = 4;
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_07F9;

                        case 1:
                            str3 = "+-";
                            str4 = "15/ul";
                            str5 = "15/ul";
                            goto Label_07F9;

                        case 2:
                            str3 = "1+";
                            str4 = "70/ul";
                            str5 = "70/ul";
                            goto Label_07F9;

                        case 3:
                            str3 = "2+";
                            str4 = "125/ul";
                            str5 = "125/ul";
                            goto Label_07F9;

                        case 4:
                            str3 = "3+";
                            str4 = "500/ul";
                            str5 = "500/ul";
                            goto Label_07F9;
                    }
                    break;

                case 20:
                    str = "尿胆原";
                    str2 = "URO";
                    num = 0;
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "3.2umol/L";
                            str5 = "3.2umol/L";
                            goto Label_07F9;

                        case 1:
                            str3 = "+-";
                            str4 = "16umol/L";
                            str5 = "16umol/L";
                            goto Label_07F9;

                        case 2:
                            str3 = "1+";
                            str4 = "33umol/L";
                            str5 = "33umol/Ll";
                            goto Label_07F9;

                        case 3:
                            str3 = "2+";
                            str4 = "66umol/L";
                            str5 = "66umol/L";
                            goto Label_07F9;

                        case 4:
                            str3 = "3+";
                            str4 = "131umol/l";
                            str5 = "131umol/l";
                            goto Label_07F9;
                    }
                    break;

                case 0x15:
                    str = "蛋白质";
                    str2 = "PRO";
                    num = 6;
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "0mg/dl";
                            goto Label_07F9;

                        case 1:
                            str3 = "+-";
                            str4 = "0.15g/L";
                            str5 = "15mg/dl";
                            goto Label_07F9;

                        case 2:
                            str3 = "1+";
                            str4 = "0.3g/L";
                            str5 = "30mg/dl";
                            goto Label_07F9;

                        case 3:
                            str3 = "2+";
                            str4 = "1g/L";
                            str5 = "100mg/dl";
                            goto Label_07F9;

                        case 4:
                            str3 = "3+";
                            str4 = "3g/L";
                            str5 = "300mg/dl";
                            goto Label_07F9;
                    }
                    break;

                case 0x16:
                    str = "潜血";
                    str2 = "BLD";
                    num = 1;
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "-";
                            goto Label_07F9;

                        case 1:
                            str3 = "+-";
                            str4 = "10/ul";
                            str5 = "0.03mg/dl";
                            goto Label_07F9;

                        case 2:
                            str3 = "1+";
                            str4 = "25/ul";
                            str5 = "0.08mg/dl";
                            goto Label_07F9;

                        case 3:
                            str3 = "2+";
                            str4 = "80/ul";
                            str5 = "0.15mg/dl";
                            goto Label_07F9;

                        case 4:
                            str3 = "3+";
                            str4 = "200/ul";
                            str5 = "0.75mg/dl";
                            goto Label_07F9;
                    }
                    break;

                case 0x17:
                    str = "酮体";
                    str2 = "KET";
                    num = 3;
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "0mg/dl";
                            goto Label_07F9;

                        case 1:
                            str3 = "+-";
                            str4 = "0.5umol/L";
                            str5 = "0mg/dl";
                            goto Label_07F9;

                        case 2:
                            str3 = "1+";
                            str4 = "1.5umol/L";
                            str5 = "15mg/dl";
                            goto Label_07F9;

                        case 3:
                            str3 = "2+";
                            str4 = "3.9umol/L";
                            str5 = "40mg/dl";
                            goto Label_07F9;

                        case 4:
                            str3 = "3+";
                            str4 = "7.8umol/l";
                            str5 = "80mg/dl";
                            goto Label_07F9;
                    }
                    break;

                case 0x18:
                    str = "胆红素";
                    str2 = "BIL";
                    num = 2;
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "0mg/dl";
                            goto Label_07F9;

                        case 1:
                            str3 = "1+";
                            str4 = "1+";
                            str5 = "1mg/dl";
                            goto Label_07F9;

                        case 2:
                            str3 = "2+";
                            str4 = "2+";
                            str5 = "3mg/dl";
                            goto Label_07F9;

                        case 3:
                            str3 = "3+";
                            str4 = "3+";
                            str5 = "6mg/dl";
                            goto Label_07F9;
                    }
                    break;

                case 0x19:
                    str = "葡萄糖";
                    str2 = "GLU";
                    num = 5;
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "0mg/dl";
                            goto Label_07F9;

                        case 1:
                            str3 = "+-";
                            str4 = "5.5mmol/L";
                            str5 = "50mg/dl";
                            goto Label_07F9;

                        case 2:
                            str3 = "1+";
                            str4 = "14mmol/L";
                            str5 = "100mg/dl";
                            goto Label_07F9;

                        case 3:
                            str3 = "2+";
                            str4 = "28mmol/l";
                            str5 = "250mg/dl";
                            goto Label_07F9;

                        case 4:
                            str3 = "3+";
                            str4 = "55mmol/l";
                            str5 = "500mg/dl";
                            goto Label_07F9;
                    }
                    break;

                case 0x1a:
                    str = "维生素C";
                    str2 = "VC";
                    num = 10;
                    switch (code)
                    {
                        case 0:
                            str3 = "-";
                            str4 = "-";
                            str5 = "0mg/dl";
                            goto Label_07F9;

                        case 1:
                            str3 = "+-";
                            str4 = "0.6mmol/L";
                            str5 = "10mg/dl";
                            goto Label_07F9;

                        case 2:
                            str3 = "1+";
                            str4 = "1.4mmol/L";
                            str5 = "25mg/dl";
                            goto Label_07F9;

                        case 3:
                            str3 = "2+";
                            str4 = "2.8mmol/l";
                            str5 = "50mg/dl";
                            goto Label_07F9;

                        case 4:
                            str3 = "3+";
                            str4 = "5.0mmol/l";
                            str5 = "100mg/dl";
                            goto Label_07F9;
                    }
                    break;

                case 0x1b:
                    str = "PH值";
                    str2 = "PH";
                    num = 7;
                    switch (code)
                    {
                        case 0:
                            str3 = "5";
                            str4 = "5";
                            str5 = "5";
                            goto Label_07F9;

                        case 1:
                            str3 = "5.5";
                            str4 = "5.5";
                            str5 = "5.5";
                            goto Label_07F9;

                        case 2:
                            str3 = "6";
                            str4 = "6";
                            str5 = "6";
                            goto Label_07F9;

                        case 3:
                            str3 = "6.5";
                            str4 = "6.5";
                            str5 = "6.5";
                            goto Label_07F9;

                        case 4:
                            str3 = "7";
                            str4 = "7";
                            str5 = "7";
                            goto Label_07F9;

                        case 5:
                            str3 = "7.5";
                            str4 = "7.5";
                            str5 = "7.5";
                            goto Label_07F9;

                        case 6:
                            str3 = "8";
                            str4 = "8";
                            str5 = "8";
                            goto Label_07F9;

                        case 7:
                            str3 = "8.5";
                            str4 = "8.5";
                            str5 = "8.5";
                            goto Label_07F9;

                        case 8:
                            str3 = "9";
                            str4 = "9";
                            str5 = "9";
                            goto Label_07F9;
                    }
                    break;

                case 0x1c:
                    str = "比重";
                    str2 = "SG";
                    num = 9;
                    switch (code)
                    {
                        case 0:
                            str3 = "1.005";
                            str4 = "1.005";
                            str5 = "1.005";
                            goto Label_07F9;

                        case 1:
                            str3 = "1.010";
                            str4 = "1.010";
                            str5 = "1.010";
                            goto Label_07F9;

                        case 2:
                            str3 = "1.015";
                            str4 = "1.015";
                            str5 = "1.015";
                            goto Label_07F9;

                        case 3:
                            str3 = "1.020";
                            str4 = "1.020";
                            str5 = "1.020";
                            goto Label_07F9;

                        case 4:
                            str3 = "1.025";
                            str4 = "1.025";
                            str5 = "1.025";
                            goto Label_07F9;

                        case 5:
                            str3 = "1.030";
                            str4 = "1.030";
                            str5 = "1.030";
                            goto Label_07F9;
                    }
                    break;
            }
        Label_07F9:
            result.friendName = str;
            result.engshort = str2;
            result.standard = str3;
            result.internation = str4;
            result.tradition = str5;
            result.index = num;
            return result;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x6f, 0x6b };
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
                return new byte[1];
            }
        }
    }
}

