namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;

    internal class ClsQCTDEVICEBP : ClsQCTDevice
    {
        public ClsQCTDEVICEBP(ClsCommunication comm)
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
            base.ResultData = new byte[7];
            base.m_Comm.SetTimeOut(0x2710);
            base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(500);
            int num = base.m_Comm.Recv(ref this.ResultData, 7);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            if (num != 7)
            {
                return false;
            }
            ClsResult.DeviceName = "QCTBP";
            ClsResult.DeviceFriendName = "血压";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            string str = Conversions.GetUShortIntegerFromPacket(base.ResultData, 2, true).ToString();
            ClsResult.DeviceValue.QCTBP.GaoYa = str;
            string str2 = Conversions.GetUShortIntegerFromPacketEx(base.ResultData, 4, false).ToString();
            ClsResult.DeviceValue.QCTBP.DiYa = str2;
            string str3 = Conversions.GetUShortIntegerFromPacketEx(base.ResultData, 5, false).ToString();
            ClsResult.DeviceValue.QCTBP.XinLv = str3;
            ClsResult.ResultFlag = true;
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
    }
}

