namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;

    internal class ClsQCTDEVICEBW : ClsQCTDevice
    {
        public ClsQCTDEVICEBW(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 0x3e8;
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
            ClsResult.DeviceName = "QCTBM";
            ClsResult.DeviceFriendName = "体重";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            string str = Conversions.GetUShortIntegerFromPacket(base.ResultData, 5, true).ToString();
            string str2 = str.Insert(str.Length - 1, ".");
            ClsResult.DeviceValue.QCTBM.TiZhong = str2;
            ClsResult.ResultFlag = true;
            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0xff, 0, 0, 0, 80, 0, 0, 0xaf };
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
                return new byte[] { 0xff, 0, 0, 0, 90, 1, 0, 0xa4 };
            }
        }
    }
}

