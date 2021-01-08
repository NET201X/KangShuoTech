namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;
    using System.Globalization;

    internal class ClsQCTDEVICETF : ClsQCTDevice
    {
        public ClsQCTDEVICETF(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 5000;
        }

        public override bool ExecClose()
        {
            //Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);
            //Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);

            return true;
        }

        public override bool ExecQuery()
        {
            base.ResultData = new byte[8];
            base.m_Comm.SetTimeOut(0x2710);

            base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(200);
            int num = base.m_Comm.Recv(ref this.ResultData, 8);

            base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(200);
            num = base.m_Comm.Recv(ref this.ResultData, 8);

            if (num != 8)
            {
                return false;
            }

            if (ResultData[4] == 85 || ResultData[4] == 0)
            {
                ClsResult.ResultFlag = false;
                return true;
            }

            
            //Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);

            ClsResult.DeviceName = "QCTTF";
            ClsResult.DeviceFriendName = "体温";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();

            string str1 = ResultData[4].ToString("X");
            string str2 = ResultData[5].ToString("X");

            if (str2.Length == 1)
            {
                str2 = "0" + str2;
            }

            string str = str1 + str2;

            int tiwen = Convert.ToInt32(str, 16);

            str = tiwen.ToString().Substring(0, 3).Insert(2, ".");

            ClsResult.DeviceValue.QCTTF.TiWen = str;
            ClsResult.ResultFlag = true;

            Thread.Sleep(500);
            base.m_Comm.Send(this.CommandClose);

            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0xFE, 0x6A, 0x72, 0x5B, 0x04, 0x00, 0x00, 0x3B };
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
                return new byte[] { 0xFE, 0x6A, 0x72, 0x5B, 0x03, 0x00, 0x00, 0x3A };
            }
        }
    }
}

