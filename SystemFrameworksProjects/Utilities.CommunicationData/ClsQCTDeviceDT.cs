namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;

    internal class ClsQCTDeviceDT : ClsQCTDevice
    {
        public ClsQCTDeviceDT(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 0x1388;
        }

        public override bool ExecClose()
        {
            Thread.Sleep(300);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(300);
            base.m_Comm.Send(this.CommandClose);
            return true;
        }

        public override bool ExecQuery()
        {
            base.ResultData = new byte[20];
            string str = "";
            string str2 = "";
            base.m_Comm.SetTimeOut(0x2710);
            Thread.Sleep(0x2710);
            base.m_Comm.Recv(ref this.ResultData, 20);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            if (!(str != ""))
            {
                return false;
            }
            ClsResult.DeviceName = "QCTBT";
            ClsResult.DeviceFriendName = "血氧";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            ClsResult.DeviceValue.QCTBT.XueYang = str;
            ClsResult.DeviceValue.QCTBT.MaiLv = str2;
            ClsResult.ResultFlag = true;
            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x7d, 0x81, 0xa2 };
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
                return new byte[] { 0x7d, 0x81, 0xa1 };
            }
        }
    }
}

