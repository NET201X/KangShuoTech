using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace PadPlatform
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Timers;

    public class ReadIdentifyCard : AbsReadIDCardNo
    {
        private int readCount;
        private Timer timerReadCard;
        private int usbPort;

        public ReadIdentifyCard(string cardtype)
        {
            base.idCardType = cardtype;
            this.timerReadCard = new Timer();
            this.timerReadCard.Interval = 2000;
            this.timerReadCard.Enabled = false;
            base.IsOk = false;
        }

        public override bool CloseCard(out int p_ret)
        {
            throw new NotImplementedException();
        }

        public override bool CloseShsCard(out int p_ret)
        {
            byte abuf = 0x42;
            int num2 = 0;
            int num3 = 0x226b;
            int num4 = 0x2702;
            bool flag = false;
            if ((p_ret = UCommand1(ref abuf, ref num2, ref num3, ref num4)) == 0xf2db)
            {
                flag = true;
                this.timerReadCard.Elapsed += new ElapsedEventHandler(this.timerReadCard_Elapsed);
            }
            return flag;
        }

        public override void FreeIdCard()
        {
        }

        [DllImport("RdCard.dll")]
        public static extern int GetAddr(byte[] addbyte);
        [DllImport("RdCard.dll")]
        public static extern int GetBirth(byte[] birthbyte);
        [DllImport("RdCard.dll")]
        public static extern int GetFolk(byte[] folkbyte);
        [DllImport("RdCard.dll")]
        public static extern int GetIDNum(byte[] buffer);
        [DllImport("RdCard.dll")]
        public static extern int GetName(byte[] namebyte);
        [DllImport("RdCard.dll")]
        public static extern int GetNewAddr(byte[] newAddr);
        [DllImport("RdCard.dll")]
        public static extern int GetSex(byte[] sexbyte);
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
            if ((p_ret = UCommand1(ref abuf, ref num2, ref num3, ref num4)) == 0xf2db)
            {
                this.timerReadCard.Elapsed += new ElapsedEventHandler(this.timerReadCard_Elapsed);
                flag = true;
            }
            return flag;
        }

        public bool InitXzxIdCard()
        {
            bool flag = false;
            this.usbPort = Syn_FindReader();
            if (this.usbPort > 0x3e8)
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
            int num5 = UCommand1(ref abuf, ref num2, ref num3, ref num4);
            if (num5 == 0xf2db)
            {
                new RecordsBaseInfoModel();
                byte num6 = 0x44;
                int num7 = UCommand1(ref num6, ref num2, ref num3, ref num4);
                if (num7 == 0xf2db)
                {
                    string str8;
                    byte[] buffer = new byte[0x24];
                    GetIDNum(buffer);
                    string str = Encoding.Default.GetString(buffer);
                    DateTime today = DateTime.Today;
                    string str2 = "";
                    byte[] namebyte = new byte[30];
                    GetName(namebyte);
                    string str3 = Encoding.Default.GetString(namebyte).TrimEnd(new char[1]);
                    byte[] sexbyte = new byte[2];
                    GetSex(sexbyte);
                    string str4 = Encoding.Default.GetString(sexbyte).Trim();
                    string str5 = !(str4 == "男") ? (!(str4 == "女") ? "0" : "2") : "1";
                    byte[] addbyte = new byte[70];
                    GetAddr(addbyte);
                    string str6 = Encoding.Default.GetString(addbyte).Trim().TrimEnd(new char[1]);
                    byte[] birthbyte = new byte[0x10];
                    GetBirth(birthbyte);
                    DateTime.TryParse(Encoding.Default.GetString(birthbyte).Trim(), out today);
                    byte[] folkbyte = new byte[30];
                    GetFolk(folkbyte);
                    string str7 = Encoding.Default.GetString(folkbyte).ToString().TrimEnd(new char[1]);
                    if (str7 == "汉族")
                    {
                        str8 = "1";
                    }
                    else
                    {
                        str2 = str7;
                        str8 = "2";
                    }
                    byte[] newAddr = new byte[70];
                    GetNewAddr(newAddr);
                    Encoding.Default.GetString(newAddr).Trim();
                    e.Name = str3;
                    e.Idcard = str;
                    e.Addr = str6;
                    e.Birthday = today;
                    e.Nation = str8;
                    e.Sex = str5;
                    e.Minority = str2;
                    e.ReadResult = 0;
                    this.StopRead();
                }
                else
                {
                    this.timerReadCard.Enabled = false;
                    ErrorLog.WriterLog(num7.ToString());
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
                e.ReadResult = -2;
                e.ErrorInfo = "卡验证失败:" + num5;
                if (base.readCardEvent != null)
                {
                    base.readCardEvent(this, e);
                }
            }
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
        public static extern int Syn_FindReader();
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
                this.shsIdCard();
            }
            if (base.idCardType == "2")
            {
                this.xzxIdCard();
            }
        }

        [DllImport("RdCard.dll")]
        public static extern int UCommand1(ref byte abuf, ref int parg0, ref int parg1, ref int parg2);
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
                    Syn_SetNationType(2);
                    num = Syn_ReadMsg(this.usbPort, 0, ref pIDCardData);
                    if (num == 0)
                    {
                        DateTime time2;
                        string str7;
                        new RecordsBaseInfoModel();
                        DateTime today = DateTime.Today;
                        string nation = "";
                        PadForm.idNo = pIDCardData.IDCardNo;
                        string name = pIDCardData.Name;
                        string iDCardNo = pIDCardData.IDCardNo;
                        string sex = pIDCardData.Sex;
                        string address = pIDCardData.Address;
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
                            nation = pIDCardData.Nation;
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

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IDCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string Name;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            public string Sex;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Nation;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x12)]
            public string Born;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x48)]
            public string Address;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x26)]
            public string IDCardNo;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string GrantDept;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x12)]
            public string UserLifeBegin;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x12)]
            public string UserLifeEnd;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x26)]
            public string reserved;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0xff)]
            public string PhotoFileName;
        }
    }
}

