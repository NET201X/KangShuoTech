namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;

    internal class ClsQCTDeviceHEM : ClsQCTDevice
    {
        public ClsQCTDeviceHEM(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 10000;
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
            base.ResultData = new byte[5];
            base.m_Comm.SetTimeOut(0x2710);

            if (base.m_Comm.Recv(ref this.ResultData, 5) != 5)
            {
                return false;
            }

            base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(500);
            base.ResultData = new byte[0x12];
            int num = base.m_Comm.Recv(ref this.ResultData, 0x12);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            if (num != 0x12)
            {
                return false;
            }
            ClsResult.DeviceName = "QCTBP";
            ClsResult.DeviceFriendName = "血压";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            ClsResult.DeviceValue.QCTBP.GaoYa = base.ResultData[12].ToString();
            ClsResult.DeviceValue.QCTBP.DiYa = base.ResultData[13].ToString();
            ClsResult.DeviceValue.QCTBP.XinLv = base.ResultData[14].ToString();
            ClsResult.ResultFlag = true;
            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x54, 0x4f, 0x4b, 0xff, 0xff };
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
                return new byte[] { 0x47, 0x4d, 0x44, 0, 0, 0, 0 };
            }
        }
    }
}

