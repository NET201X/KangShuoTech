using System;
using System.Threading;

namespace KangShuoTech.Utilities.CommunicationData
{
    /// <summary>
    /// 体重
    /// </summary>
    internal class ClsCHITDEVICEBM : ClsQCTDevice
    {
        public ClsCHITDEVICEBM(ClsCommunication comm)
        {
            base.m_Comm = comm;
            base.m_delay = 5000;
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
            base.ResultData = new byte[16];
            base.m_Comm.SetTimeOut(0x2710);
            //base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(500);
            int num = base.m_Comm.Recv(ref this.ResultData, 16);
            Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);

            if (num < 16)
            {
                return false;
            }

            string str4 = ResultData[4].ToString("X");
            string str5 = ResultData[5].ToString("X");

            if (str5.Length == 1)
            {
                str5 = "0" + str5;
            }
            string str = str4 + str5;

            int weight = Convert.ToInt32(str, 16);
            decimal dWeight = weight * 0.1M;

            //string str = Conversions.GetUShortIntegerFromPacket(base.ResultData, 5, true).ToString();
            //string str2 = str.Insert(str.Length - 1, ".");

            ClsResult.DeviceName = "QCTBM";
            ClsResult.DeviceFriendName = "体重";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            ClsResult.DeviceValue.QCTBM.TiZhong = dWeight.ToString("0.0");
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
