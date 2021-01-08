namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    internal class ClsQCTDEVICEBG : ClsQCTDevice
    {
        public ClsQCTDEVICEBG(ClsCommunication comm)
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
            base.ResultData = new byte[15];
            base.m_Comm.SetTimeOut(0x1388);
            base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(500);
            int num = base.m_Comm.Recv(ref this.ResultData, 15);
            Trace.WriteLine("发送两次关机指令");
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            if (num < 15)
            {
                return false;
            }
            double num2 = Convert.ToDouble(base.ResultData[12]) / 10.0;
            ClsResult.DeviceName = "QCTBG";
            ClsResult.DeviceFriendName = "血糖";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            ClsResult.DeviceValue.QCTBG.XueTang = num2.ToString();
            ClsResult.ResultFlag = true;
            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x53, 0x4e, 6, 0, 2, 11, 0, 0, 0x13 };
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
                return new byte[] { 0x53, 0x4e, 6, 0, 2, 4, 0, 0, 12 };
            }
        }
    }
}

