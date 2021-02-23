using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace KangShuo
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Timers;
    using System.IO;
    using System.Configuration;

    internal class ReadIdentifyCardEx : AbsReadIDCardNo
    {
        private int hModule;
        private int readCount;
        private Timer timerReadCard;
        private int usbPort;
        string PhotoPath = ConfigurationManager.AppSettings["PhotoPath"] == null ? System.Environment.CurrentDirectory + "\\photo" : ConfigurationManager.AppSettings["PhotoPath"].ToString();

        public ReadIdentifyCardEx(string cardtype)
        {
            base.idCardType = cardtype;
            this.timerReadCard = new Timer();
            this.timerReadCard.Interval = 2000;
            this.timerReadCard.Enabled = false;
            base.IsOk = false;
        }

        public override bool CloseCard(out int p_ret)
        {
            int num = 0;
            bool flag = false;
            if (base.idCardType == "1")
            {
                flag = this.CloseShsCard(out num);
            }
            else if (base.idCardType == "2")
            {
                flag = true;
            }
            else if (base.idCardType == "3")
            {
                flag = true;
            }

            p_ret = num;
            return flag;
        }

        public override bool CloseShsCard(out int p_ret)
        {
            byte abuf = 0x42;
            int num2 = 0;
            int num3 = 0x226b;
            int num4 = 0x2702;
            bool flag = false;
            this.StopRead();
            UCommand1 command = (UCommand1)DLLWrapper.GetFunctionAddress(this.hModule, "UCommand1", typeof(UCommand1));
            if ((p_ret = command(ref abuf, ref num2, ref num3, ref num4)) == 0xf2db)
            {
                flag = true;
            }
            this.FreeIdCard();
            this.hModule = -1;
            return flag;
        }

        public override void FreeIdCard()
        {
            DLLWrapper.FreeLibrary(this.hModule);
        }

        public override bool InitReadCard(out int p_ret)
        {
            bool flag = false;
            p_ret = 0;
            if (base.idCardType == "1")
            {
                flag = this.InitShsIdCard(out p_ret);
            }
            if (base.idCardType == "2")
            {
                flag = this.InitXzxIdCard();
            }
            if (base.idCardType == "3")
            {
                int num = 0;
                flag = InitmtxIDCard();
            }
            base.IsOk = flag;
            return flag;
        }

        public bool InitShsIdCard(out int p_ret)
        {
            byte abuf = 0x41;
            int num2 = 0;
            int num3 = 0x226b;
            int num4 = 0x2702;
            bool flag = false;
            this.hModule = DLLWrapper.LoadLibrary("RdCard.dll");
            if (this.hModule == 0)
            {
                p_ret = -99;
                base.IsOk = false;
                return false;
            }
            try
            {
                UCommand1 command = (UCommand1)DLLWrapper.GetFunctionAddress(this.hModule, "UCommand1", typeof(UCommand1));
                if ((p_ret = command(ref abuf, ref num2, ref num3, ref num4)) != 0xf2db)
                {
                    return flag;
                }
                this.timerReadCard.Elapsed += new ElapsedEventHandler(this.timerReadCard_Elapsed);
                byte[] sn = new byte[0x40];
                if (((GetSAMIDToStr)DLLWrapper.GetFunctionAddress(this.hModule, "GetSAMIDToStr", typeof(GetSAMIDToStr)))(sn) == 1)
                {
                    base.RdCardSN = Encoding.Default.GetString(sn).Trim();
                }
                flag = true;
            }
            catch (Exception exception)
            {
                p_ret = -99;
                flag = false;
                ErrorLog.WriterLog("身份证初始化错误:" + exception.Message);
                LogHelper.LogError(exception);
            }
            return flag;
        }

        public bool InitXzxIdCard()
        {
            bool flag = false;
            //this.usbPort = Syn_StartFindIDCard();
            this.usbPort = 1;
            if (this.usbPort > 0)
            {
                this.timerReadCard.Elapsed += new ElapsedEventHandler(this.timerReadCard_Elapsed);
                this.timerReadCard.Start();
                flag = true;
            }
            return flag;
        }

        public void shsIdCard()
        {
            byte abuf = 0x43;
            int num2 = 0;
            int num3 = 0x226b;
            int num4 = 0x2702;
            ReadIdentifyEventArgs e = new ReadIdentifyEventArgs();
            UCommand1 command = (UCommand1)DLLWrapper.GetFunctionAddress(this.hModule, "UCommand1", typeof(UCommand1));
            int num5 = command(ref abuf, ref num2, ref num3, ref num4);
            if (num5 == 0xf2db)
            {
                new RecordsBaseInfoModel();
                byte num6 = 0x44;
                int num7 = command(ref num6, ref num2, ref num3, ref num4);
                if (num7 == 0xf2db)
                {
                    string str9;
                    byte[] buffer = new byte[0x24];
                    ((GetIDNum)DLLWrapper.GetFunctionAddress(this.hModule, "GetIDNum", typeof(GetIDNum)))(buffer);
                    string str = Encoding.Default.GetString(buffer).Trim(new char[1]).Trim();
                    DateTime today = DateTime.Today;
                    string str2 = "";
                    byte[] namebyte = new byte[30];
                    ((GetName)DLLWrapper.GetFunctionAddress(this.hModule, "GetName", typeof(GetName)))(namebyte);
                    string str3 = Encoding.Default.GetString(namebyte).Trim(new char[1]).Trim().TrimEnd(new char[1]);
                    byte[] sexbyte = new byte[2];
                    ((GetSex)DLLWrapper.GetFunctionAddress(this.hModule, "GetSexGB", typeof(GetSex)))(sexbyte);
                    string str4 = Encoding.Default.GetString(sexbyte).Trim(new char[1]).Trim();
                    string str5 = !(str4 == "男") ? (!(str4 == "女") ? "0" : "2") : "1";
                    byte[] addbyte = new byte[70];
                    ((GetAddr)DLLWrapper.GetFunctionAddress(this.hModule, "GetAddr", typeof(GetAddr)))(addbyte);
                    string str6 = Encoding.Default.GetString(addbyte).Trim(new char[1]).Trim().TrimEnd(new char[1]);
                    byte[] birthbyte = new byte[0x10];
                    ((GetBirth)DLLWrapper.GetFunctionAddress(this.hModule, "GetBirth", typeof(GetBirth)))(birthbyte);
                    string str7 = Encoding.GetEncoding("gb2312").GetString(birthbyte).Trim(new char[1]).Trim();
                    bool flag = true;
                    if (!DateTime.TryParse(str7.Trim().Insert(4, "-").Insert(7, "-").Trim(), out today))
                    {
                        flag = false;
                    }
                    byte[] folkbyte = new byte[0x10];
                    ((GetFolk)DLLWrapper.GetFunctionAddress(this.hModule, "GetFolkGB", typeof(GetFolk)))(folkbyte);
                    string str8 = Encoding.Default.GetString(folkbyte).ToString().Trim(new char[1]).Trim().TrimEnd(new char[1]);
                    if (str8 == "汉族")
                    {
                        str9 = "1";
                    }
                    else
                    {
                        str2 = str8;
                        str9 = "2";
                    }
                    byte[] newAddr = new byte[70];
                    ((GetNewAddr)DLLWrapper.GetFunctionAddress(this.hModule, "GetNewAddr", typeof(GetNewAddr)))(newAddr);
                    Encoding.Default.GetString(newAddr).Trim(new char[1]).Trim();
                    e.Name = str3.Trim();
                    e.Idcard = str;
                    e.Addr = str6.Trim();
                    e.Birthday = today;
                    e.Nation = str9.Trim();
                    e.Sex = str5;
                    e.Minority = str2.Trim();
                    e.ReadResult = 0;
                    if (string.IsNullOrEmpty(e.Idcard))
                    {
                        e.ErrorInfo = "读取身份证号码为空!";
                        e.ReadResult = -4;
                    }
                    if (string.IsNullOrEmpty(e.Name))
                    {
                        ReadIdentifyEventArgs args2 = e;
                        string str10 = args2.ErrorInfo + "读取身份证姓名为空!";
                        args2.ErrorInfo = str10;
                        e.ReadResult = -4;
                    }
                    if (!flag)
                    {
                        ReadIdentifyEventArgs args3 = e;
                        string str11 = args3.ErrorInfo + "获取身份证生日失败!";
                        args3.ErrorInfo = str11;
                        e.ReadResult = -4;
                    }
                    if (string.IsNullOrEmpty(e.Nation))
                    {
                        ReadIdentifyEventArgs args4 = e;
                        string str12 = args4.ErrorInfo + "获取身份证民族失败!";
                        args4.ErrorInfo = str12;
                        e.ReadResult = -4;
                    }
                    if (string.IsNullOrEmpty(e.Sex))
                    {
                        ReadIdentifyEventArgs args5 = e;
                        string str13 = args5.ErrorInfo + "获取身份证性别失败!";
                        args5.ErrorInfo = str13;
                        e.ReadResult = -4;
                    }
                    if (e.ReadResult == 0)
                    {
                        this.StopRead();
                    }
                }
                else
                {
                    this.timerReadCard.Enabled = false;
                    e.ReadResult = -2;
                    if (this.readCount > 50)
                    {
                        e.ReadResult = -1;
                        e.ErrorInfo = "身份证信息读取错误，关闭程序重新读取:" + num7;
                        this.readCount = 0;
                    }
                    this.readCount++;
                    this.timerReadCard.Enabled = true;
                }
                if (base.readCardEvent == null)
                {
                    throw new Exception("readCardEvent 为NULL");
                }
                base.readCardEvent(this, e);
            }
            else
            {
                e.ReadResult = -3;
                e.ErrorInfo = "卡验证失败:" + num5;
            }
        }

        public bool InitmtxIDCard()
        {
            bool flag = false;
            this.usbPort = 1;
            if (this.usbPort > 0)
            {
                this.timerReadCard.Elapsed += new ElapsedEventHandler(this.timerReadCard_Elapsed);
                //this.timerReadCard.Start();
                flag = true;
            }
            return flag;
        }

        public override void StartRead()
        {
            this.timerReadCard.Enabled = true;
        }

        public override void StopRead()
        {
            this.timerReadCard.Enabled = false;
        }


        [DllImport(@"Card\SynIDCardAPI.dll")]
        public static extern int Syn_GetSAMID(int iPort, ref byte pucSAMID, int iIfOpen);
        [DllImport(@"Card\SynIDCardAPI.dll")]
        public static extern int Syn_GetSAMStatus(int iPort, int iIfOpen);
        [DllImport(@"Card\SynIDCardAPI.dll")]
        public static extern int Syn_OpenPort(int port);
        [DllImport(@"Card\SynIDCardAPI.dll")]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);
        [DllImport(@"Card\SynIDCardAPI.dll")]
        public static extern int Syn_SelectIDCard(int iport, ref byte pucSN, int iIfOpen);
        [DllImport(@"Card\SynIDCardAPI.dll")]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);
        [DllImport(@"Card\SynIDCardAPI.dll", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetNationType(int iType);
        [DllImport(@"Card\SynIDCardAPI.dll")]
        public static extern int Syn_StartFindIDCard(int iport, ref byte pucIIN, int iIfOpen);
        private void timerReadCard_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (base.idCardType == "1")
            {
                this.xzxIdCard();
            }
            if (base.idCardType == "2")
            {
                this.xzxIdCard();
            }
            if (base.idCardType == "3")
            {
                this.mtxIDCard();
            }
        }
        bool isRunType3 = false;
        public void mtxIDCard()
        {
            if (isRunType3)
            {
                return;
            }

            isRunType3 = true;

            Int16 st;
            int icdev = 0;
            string result = null;
            ReadIdentifyEventArgs e = new ReadIdentifyEventArgs();

            try
            {
                int port = 0;//COM1
                int baud = 115200;

                icdev = ReadCardUtility.device_open(port, baud);
                if ((int)icdev > 0)
                {
                    //读取身份证信息*/
                    byte[] message = new byte[1024];

                    string bmpPath = @"D:\QCSoft\ZP.bmp";

                    byte[] photoPath = Encoding.Default.GetBytes(bmpPath);

                    st = ReadCardUtility.IDCard_ReadCard_Extra(icdev, photoPath, message);

                    result = Encoding.Default.GetString(message).TrimEnd('\0');

                    /* string bmpPath = @"D:\ZP.bmp";
                     byte[] photoPath = Encoding.Default.GetBytes(bmpPath);
                     st = mtx_32dll.IDCard_ReadCard_Extra(icdev, photoPath, message);
                     */

                    if (st == 0)
                    {
                        int i;
                        string name = "";
                        string iDCardNo = "";
                        string sex = "";
                        string address = "";
                        string str7 = "";
                        string nation = "";
                        DateTime today = DateTime.Today;

                        for (i = 0; i < 6; i++)
                        {
                            byte[] info = new byte[1024];
                            string infodata = null;
                            st = ReadCardUtility.IDCard_GetCardInfo(icdev, i, info);
                            infodata = Encoding.Default.GetString(info).TrimEnd('\0');

                            if (i == 0)
                            {
                                name = infodata;
                                continue;
                            }

                            if (i == 1)
                            {
                                sex = infodata == "男" ? "1" : "2";
                                continue;
                            }

                            if (i == 2)
                            {
                                if (infodata == "汉")
                                {
                                    str7 = "1";
                                }
                                else
                                {
                                    str7 = "2";
                                    nation = infodata.IndexOf("族") == -1 ? infodata + "族" : infodata;
                                }
                                continue;
                            }

                            if (i == 3)
                            {
                                today = DateTime.ParseExact(infodata, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture); ;
                                continue;
                            }
                            if (i == 4)
                            {
                                address = infodata;
                                continue;
                            }

                            if (i == 5)
                            {
                                iDCardNo = infodata;
                                continue;
                            }
                        }

                        e.Name = name;
                        e.Idcard = iDCardNo;
                        e.Addr = address;
                        e.Birthday = today;
                        e.Nation = str7;
                        e.Sex = sex;
                        e.Minority = nation;
                        e.ReadResult = 0;

                        if (!Directory.Exists(PhotoPath)) Directory.CreateDirectory(PhotoPath);

                        string strNewPhoto = PhotoPath + "\\" + iDCardNo + ".Jpeg";
                        File.Copy(bmpPath, strNewPhoto, true);

                        this.StopRead();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            if (icdev > 0)
            {
                ReadCardUtility.device_close(icdev);
            }

            isRunType3 = false;

            if (base.readCardEvent == null)
            {
                throw new Exception("readCardEvent 为NULL");
            }

            base.readCardEvent(this, e);
        }

        public void xzxIdCard()
        {
            byte[] buffer = new byte[4];
            byte[] buffer2 = new byte[8];
            IDCardData pIDCardData = new IDCardData();
            bool flag = false;
            string str = "";
            int num = Syn_OpenPort(this.usbPort);
            ReadIdentifyEventArgs e = new ReadIdentifyEventArgs();
            if (num == 0)
            {
                if (num == 0)
                {
                    Syn_StartFindIDCard(this.usbPort, ref buffer[0], 0);
                    Syn_SelectIDCard(this.usbPort, ref buffer2[0], 0);
                    //Syn_SetNationType(2);
                    num = Syn_ReadMsg(this.usbPort, 0, ref pIDCardData);
                    if (num == 0)
                    {
                        DateTime time2;
                        string str7;
                        new RecordsBaseInfoModel();
                        DateTime today = DateTime.Today;
                        string nation = "";
                        PadForm.idNo = pIDCardData.IDCardNo.Trim();
                        string name = pIDCardData.Name.Trim();
                        string iDCardNo = pIDCardData.IDCardNo.Trim();
                        string sex = pIDCardData.Sex.Trim();
                        string address = pIDCardData.Address.Trim();

                        if ((pIDCardData.Born.Length == 8) && DateTime.TryParse(pIDCardData.Born.Substring(0, 4) + "-" + pIDCardData.Born.Substring(4, 2) + "-" + pIDCardData.Born.Substring(6, 2), out time2))
                        {
                            today = time2;
                        }

                        if (pIDCardData.Nation == "汉族")
                        {
                            str7 = "1";
                        }
                        else
                        {
                            str7 = "2";
                            nation = GetNation(pIDCardData.Nation);
                        }

                        this.StopRead();
                        e.Name = name;
                        e.Idcard = iDCardNo;
                        e.Addr = address;
                        e.Birthday = today;
                        e.Nation = str7;
                        e.Sex = sex;
                        e.Minority = nation;
                        e.ReadResult = 0;
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            else
            {
                str = "身份证读卡器端口打开失败:";
            }
            if ((str != "") || !flag)
            {
                if (str != "")
                {
                    e.ReadResult = -1;
                    e.ErrorInfo = str + num;
                }
            }
            else
            {
                this.StopRead();
            }
            if (base.readCardEvent == null)
            {
                throw new Exception("readCardEvent 为NULL");
            }
            base.readCardEvent(this, e);
        }

        public string GetNation(string code)
        {
            string nationName = "";
            switch (code)
            {
                case "01":
                    nationName = "汉族";
                    break;
                case "02":
                    nationName = "蒙古族";
                    break;
                case "03":
                    nationName = "回族";
                    break;
                case "04":
                    nationName = "藏族";
                    break;
                case "05":
                    nationName = "维吾尔族";
                    break;
                case "06":
                    nationName = "苗族";
                    break;
                case "07":
                    nationName = "彝族";
                    break;
                case "08":
                    nationName = "壮族";
                    break;
                case "09":
                    nationName = "布依族";
                    break;
                case "10":
                    nationName = "朝鲜族";
                    break;
                case "11":
                    nationName = "满族";
                    break;
                case "12":
                    nationName = "侗族";
                    break;
                case "13":
                    nationName = "瑶族";
                    break;
                case "14":
                    nationName = "白族";
                    break;
                case "15":
                    nationName = "土家族";
                    break;
                case "16":
                    nationName = "哈尼族";
                    break;
                case "17":
                    nationName = "哈萨克族";
                    break;
                case "18":
                    nationName = "傣族";
                    break;
                case "19":
                    nationName = "黎族";
                    break;
                case "20":
                    nationName = "僳僳族";
                    break;
                case "21":
                    nationName = "佤族";
                    break;
                case "22":
                    nationName = "畲族";
                    break;
                case "23":
                    nationName = "高山族";
                    break;
                case "24":
                    nationName = "拉祜族";
                    break;
                case "25":
                    nationName = "水族";
                    break;
                case "26":
                    nationName = "东乡族";
                    break;
                case "27":
                    nationName = "纳西族";
                    break;
                case "28":
                    nationName = "景颇族";
                    break;
                case "29":
                    nationName = "柯尔克孜族";
                    break;
                case "30":
                    nationName = "土族";
                    break;
                case "31":
                    nationName = "达斡尔族";
                    break;
                case "32":
                    nationName = "仫佬族";
                    break;
                case "33":
                    nationName = "羌族";
                    break;
                case "34":
                    nationName = "布朗族";
                    break;
                case "35":
                    nationName = "撒拉族";
                    break;
                case "36":
                    nationName = "毛南族";
                    break;
                case "37":
                    nationName = "仡佬族";
                    break;
                case "38":
                    nationName = "锡伯族";
                    break;
                case "39":
                    nationName = "阿昌族";
                    break;
                case "40":
                    nationName = "普米族";
                    break;
                case "41":
                    nationName = "塔吉克族";
                    break;
                case "42":
                    nationName = "怒族";
                    break;
                case "43":
                    nationName = "乌孜别克族";
                    break;
                case "44":
                    nationName = "俄罗斯族";
                    break;
                case "45":
                    nationName = "鄂温克族";
                    break;
                case "46":
                    nationName = "崩龙族";
                    break;
                case "47":
                    nationName = "保安族";
                    break;
                case "48":
                    nationName = "裕固族";
                    break;
                case "49":
                    nationName = "京族";
                    break;
                case "50":
                    nationName = "塔塔尔族";
                    break;
                case "51":
                    nationName = "独龙族";
                    break;
                case "52":
                    nationName = "鄂伦春族";
                    break;
                case "53":
                    nationName = "赫哲族";
                    break;
                case "54":
                    nationName = "门巴族";
                    break;
                case "55":
                    nationName = "珞巴族";
                    break;
                case "56":
                    nationName = "基诺族";
                    break;
                case "57":
                    nationName = "其他";
                    break;
                case "58":
                    nationName = "外国血统";
                    break;
                default:
                    nationName = "汉族";
                    break;
            }

            return nationName;
        }

        public delegate int GetAddr(byte[] addbyte);

        public delegate int GetBirth(byte[] birthbyte);

        public delegate int GetFolk(byte[] folkbyte);

        public delegate int GetIDNum(byte[] buffer);

        public delegate int GetName(byte[] namebyte);

        public delegate int GetNewAddr(byte[] newAddr);

        public delegate int GetSAMIDToStr(byte[] sn);

        public delegate int GetSex(byte[] sexbyte);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct IDCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            /// <summary> 
            /// 姓名 
            /// </summary> 
            public string Name; //姓名 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            /// <summary> 
            /// 性别 
            /// </summary> 
            public string Sex; //性别 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            /// <summary> 
            /// 民族 
            /// </summary> 
            public string Nation; //民族
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            /// <summary> 
            /// 出生日期 
            /// </summary> 
            public string Born; //出生日期 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)]
            /// <summary> 
            /// 家庭地址 
            /// </summary> 
            public string Address; //住址 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            /// <summary> 
            /// 身份证号 
            /// </summary> 
            public string IDCardNo; //身份证号 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            /// <summary> 
            /// 发证机关 
            /// </summary> 
            public string GrantDept; //发证机关 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            /// <summary> 
            /// 有效开始日期 
            /// </summary> 
            public string UserLifeBegin; // 有效开始日期 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            /// <summary> 
            /// 有效截止日期 
            /// </summary> 
            public string UserLifeEnd; // 有效截止日期 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            /// <summary> 
            ///保留 
            /// </summary> 
            public string reserved; // 保留 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            /// <summary> 
            /// 头像照片路径 
            /// </summary> 
            public string PhotoFileName; // 照片路径 
        }

        public delegate int UCommand1(ref byte abuf, ref int parg0, ref int parg1, ref int parg2);
    }
}

