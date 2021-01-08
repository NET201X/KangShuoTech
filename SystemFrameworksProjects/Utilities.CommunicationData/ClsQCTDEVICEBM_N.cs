namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;
    using System.IO;

    internal class ClsQCTDEVICEBM_N : ClsQCTDevice
    {
        public ClsQCTDEVICEBM_N(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 200;
        }

        public override bool ExecClose()
        {
            //Thread.Sleep(100);
            base.m_Comm.Send(this.CommandClose);

            return true;
        }

        public override bool ExecQuery()
        {
            base.ResultData = new byte[9];
            base.m_Comm.SetTimeOut(30000);

            int num = base.m_Comm.Recv(ref this.ResultData, 9);

            if (num != 9)
            {
                return false;
            }

            string strFlag = base.ResultData[0].ToString() + base.ResultData[8].ToString();
            //9码：A5 07 01 00 DB 00 00 DD FF
            // A5 包头 07 长度 01 特征 00 DB 数据
            //A5 FF
            if (!strFlag.Equals("165255"))
            {
                return false;
            }

            int c8 = ResultData[1] ^ ResultData[2] ^ ResultData[3] ^ ResultData[4] ^ ResultData[5] ^ ResultData[6];

            if (!(c8 == ResultData[7]))
            {
                return false;
            }

            ExecClose();

            string str = (Convert.ToInt32((base.ResultData[3] << 8) + base.ResultData[4]) / 10.0).ToString(".0");

            ClsResult.DeviceName = "QCTBM";
            ClsResult.DeviceFriendName = "体重";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            ClsResult.DeviceValue.QCTBM.TiZhong = str;
            ClsResult.ResultFlag = true;

            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x5A, 0x00, 0xFF };
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
                byte[] buffer = new byte[1];
                buffer.Initialize();
                return buffer;
            }
        }
    }
}

