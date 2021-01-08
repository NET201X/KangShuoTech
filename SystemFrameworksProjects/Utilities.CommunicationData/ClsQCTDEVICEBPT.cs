namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;

    internal class ClsQCTDEVICEBPT : ClsQCTDevice
    {
        public ClsQCTDEVICEBPT(ClsCommunication comm)
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
            try
            {
                TimeSpan span;
                bool flag = false;
                bool flag2 = false;
                base.ResultData = new byte[7];
                byte[] data = new byte[3];
                base.m_Comm.SetTimeOut(0x3e8);
                ClsResult.DeviceName = "QCTBPT";
                ClsResult.DeviceFriendName = "血压血氧一体机";
                ClsResult.DeviceAddress = "";
                ClsResult.DeviceValue = new valueItem();
                ClsResult.DeviceValue.QCTBPT.GaoYa = "0";
                ClsResult.DeviceValue.QCTBPT.DiYa = "0";
                ClsResult.DeviceValue.QCTBPT.XinLv = "0";
                ClsResult.DeviceValue.QCTBPT.XueYang = "0";
                ClsResult.DeviceValue.QCTBPT.MaiLv = "0";
                base.m_Comm.Send(this.CommandRead);
                Thread.Sleep(500);
                if (base.m_Comm.Recv(ref this.ResultData, 7) == 7)
                {
                    string str = Conversions.GetUShortIntegerFromPacket(base.ResultData, 2, true).ToString();
                    ClsResult.DeviceValue.QCTBPT.GaoYa = str;
                    string str2 = Conversions.GetUShortIntegerFromPacketEx(base.ResultData, 4, false).ToString();
                    ClsResult.DeviceValue.QCTBPT.DiYa = str2;
                    string str3 = Conversions.GetUShortIntegerFromPacketEx(base.ResultData, 5, false).ToString();
                    ClsResult.DeviceValue.QCTBPT.XinLv = str3;
                    ClsResult.ResultFlag = true;
                    flag = true;
                }
                if (flag)
                {
                    return true;
                }
                base.m_Comm.Send(this.CommandReadBT);
                Thread.Sleep(500);
                if (base.m_Comm.Recv(ref this.ResultData, 7) != 7)
                {
                    return false;
                }
                ulong num2 = 0L;
                ulong num3 = 0L;
                ulong num4 = 0L;
                DateTime now = DateTime.Now;
                do
                {
                    if (((base.m_Comm.Recv(ref data, 3) == 3) && (data[0] == 0x20)) && (data[1] != 0))
                    {
                        num2 += data[1];
                        num3 += data[2];
                        num4 += (ulong) 1L;
                    }
                    span = (TimeSpan) (DateTime.Now - now);
                }
                while (span.TotalSeconds < 30.0);
                if (num4 > 0L)
                {
                    ClsResult.DeviceValue.QCTBPT.XueYang = (num2 / num4).ToString();
                    ClsResult.DeviceValue.QCTBPT.MaiLv = (num3 / num4).ToString();
                    ClsResult.ResultFlag = true;
                    flag2 = true;
                }
                return (flag || flag2);
            }
            catch (Exception)
            {
            }
            finally
            {
                Thread.Sleep(200);
                base.m_Comm.Send(this.CommandClose);
                Thread.Sleep(200);
                base.m_Comm.Send(this.CommandClose);
            }
            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x31 };
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
                return new byte[] { 0x30 };
            }
        }

        public byte[] CommandReadBT
        {
            get
            {
                return new byte[] { 0x40 };
            }
        }
    }
}

