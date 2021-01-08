namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;

    internal class ClsQCTDEVICEBH : ClsQCTDevice
    {
        public ClsQCTDEVICEBH(ClsCommunication comm)
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
                base.ResultData = new byte[4];
                base.m_Comm.SetTimeOut(0x2710);
                base.m_Comm.Send(this.CommandRead);
                Thread.Sleep(500);
                int num = base.m_Comm.Recv(ref this.ResultData, 4);
                Thread.Sleep(200);
                base.m_Comm.Send(this.CommandClose);
                Thread.Sleep(200);
                base.m_Comm.Send(this.CommandClose);
                if (num != 4)
                {
                    return false;
                }
                string[] strArray = new string[5];
                strArray[0] = (base.ResultData[0] - 0x30).ToString();
                strArray[1] = (base.ResultData[1] - 0x30).ToString();
                string[] strArray2 = strArray;
                int index = 2;
                strArray2[index] = (base.ResultData[2] - 0x30).ToString();
                strArray[3] = ".";
                string[] strArray3 = strArray;
                int num4 = 4;
                strArray3[num4] = (base.ResultData[3] - 0x30).ToString();
                double num5 = Convert.ToDouble(string.Concat(strArray));
                ClsResult.DeviceName = "QCTBH";
                ClsResult.DeviceFriendName = "身高";
                ClsResult.DeviceAddress = "";
                ClsResult.DeviceValue = new valueItem();
                ClsResult.DeviceValue.QCTBH.ShenGao = num5.ToString();
                ClsResult.ResultFlag = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x43 };
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
                return new byte[] { 0x48 };
            }
        }
    }
}

