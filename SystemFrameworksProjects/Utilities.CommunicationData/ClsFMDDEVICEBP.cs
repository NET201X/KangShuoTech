namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Globalization;
    using System.Threading;

    internal class ClsFMDDEVICEBP : ClsQCTDevice
    {
        public ClsFMDDEVICEBP(ClsCommunication comm)
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
            base.ResultData = new byte[8];
            base.m_Comm.SetTimeOut(0x2710);
            base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(500);
            int num = base.m_Comm.Recv(ref this.ResultData, 8);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            if (num != 8)
            {
                return false;
            }
            ClsResult.DeviceName = "FMDBP";
            ClsResult.DeviceFriendName = "血压";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            string str = Conversions.GetUShortIntegerFromPacket(base.ResultData, 5, true).ToString();
            string str2 = Conversions.GetUShortIntegerFromPacketEx(base.ResultData, 6, false).ToString();
            string str3 = Conversions.GetUShortIntegerFromPacketEx(base.ResultData, 7, false).ToString();
            ClsResult.DeviceValue.FMDBP.GaoYa = str;
            ClsResult.DeviceValue.FMDBP.DiYa = str2;
            ClsResult.DeviceValue.FMDBP.XinLv = str3;
            ClsResult.ResultFlag = true;
            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { byte.Parse("04", NumberStyles.HexNumber), byte.Parse("FF", NumberStyles.HexNumber), byte.Parse("A6", NumberStyles.HexNumber), byte.Parse("A9", NumberStyles.HexNumber) };
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
                return new byte[] { byte.Parse("04", NumberStyles.HexNumber), byte.Parse("FF", NumberStyles.HexNumber), byte.Parse("A0", NumberStyles.HexNumber), byte.Parse("A3", NumberStyles.HexNumber) };
            }
        }
    }
}

