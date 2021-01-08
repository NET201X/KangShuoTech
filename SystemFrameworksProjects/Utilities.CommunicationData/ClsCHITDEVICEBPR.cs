namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// 血压
    /// </summary>
    internal class ClsCHITDEVICEBPR : ClsQCTDevice
    {
        public ClsCHITDEVICEBPR(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 5000;
        }

        public override bool ExecClose()
        {
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            
            return true;
        }

        public override bool ExecQuery()
        {
            base.ResultData = new byte[9];
            base.m_Comm.SetTimeOut(5000);
            base.m_Comm.Send(this.CommandRead);
            
            int num = base.m_Comm.Recv(ref this.ResultData, 9);
            Thread.Sleep(200);
            Thread.Sleep(200);

            if (num != 9)
            {
                return false;
            }

            while ((ResultData[2] == 1 || ResultData[2] == 2))
            {
                Thread.Sleep(2000);
                base.m_Comm.Send(this.CommandRead);
            
                num = base.m_Comm.Recv(ref this.ResultData, 9);

                if (num != 9)
                {
                    return false;
                }
            }

            ClsResult.DeviceName = "CHITBP";
            ClsResult.DeviceFriendName = "血压";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();

            string str = base.ResultData[4].ToString();
            string str2 = base.ResultData[6].ToString();
            string str3 = base.ResultData[7].ToString();

            ClsResult.DeviceValue.CHITBP.GaoYa = str;                                                                                                                                                                                   
            ClsResult.DeviceValue.CHITBP.DiYa = str2;
            ClsResult.DeviceValue.CHITBP.XinLv = str3;
            ClsResult.ResultFlag = true;
            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0xCC, 0x80, 0x04, 0xFE };
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
                return new byte[] { 0xCC, 0x80, 0x01, 0xFE };
            }
        }
    }
}

