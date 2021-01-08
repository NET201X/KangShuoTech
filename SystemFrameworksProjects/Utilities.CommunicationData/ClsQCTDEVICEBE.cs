namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// 单导心电
    /// </summary>
    internal class ClsQCTDEVICEBE : ClsQCTDevice
    {
        private string AllBuffer = "";

        public ClsQCTDEVICEBE(ClsCommunication comm)
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
            int num = 0;
            string str = "";
            base.m_Comm.SetTimeOut(200);
            base.ResultData = new byte[0x66];
            base.m_Comm.Send(this.CommandReadStart);
            Thread.Sleep(500);
            base.m_Comm.Recv(ref this.ResultData, 14);
            base.m_Comm.Recv(ref this.ResultData, 0x66);
            do
            {
                base.ResultData = new byte[0x66];
                Array.Clear(base.ResultData, 0, 0x66);
                base.m_Comm.Send(this.CommandRead);
                Thread.Sleep(100);
                int num2 = base.m_Comm.Recv(ref this.ResultData, 0x66);
                if (num2 > 0x65)
                {
                    foreach (byte num3 in base.ResultData)
                    {
                        string str2 = num3.ToString("X2");
                        str = str + str2 + " ";
                    }
                    string str3 = str.Substring(6, 300);
                    ClsQCTDEVICEBE adevicebe = this;
                    string str4 = adevicebe.AllBuffer + str3;
                    adevicebe.AllBuffer = str4;
                    str = "";
                }
                else if (num2 > 0x5b)
                {
                    foreach (byte num4 in base.ResultData)
                    {
                        string str5 = num4.ToString("X2");
                        str = str + str5 + " ";
                    }
                    int index = str.IndexOf("00");
                    if (index > 6)
                    {
                        string message = str.Substring(6, index - 6);
                        Trace.WriteLine(message);
                        ClsQCTDEVICEBE adevicebe2 = this;
                        string str7 = adevicebe2.AllBuffer + message;
                        adevicebe2.AllBuffer = str7;
                    }
                    str = "";
                }
                num++;
            }
            while (num < 120);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            if (!(this.AllBuffer != ""))
            {
                return false;
            }
            ClsResult.DeviceName = "QCTBE";
            ClsResult.DeviceFriendName = "单导心电";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            ClsResult.DeviceValue.QCTBE.pointValue = this.AllBuffer;
            ClsResult.ResultFlag = true;
            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x4f };
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
                return new byte[] { 0x4d };
            }
        }

        public byte[] CommandReadAgain
        {
            get
            {
                return new byte[] { 0x4e };
            }
        }

        public byte[] CommandReadStart
        {
            get
            {
                return new byte[] { 0x41 };
            }
        }
    }
}

