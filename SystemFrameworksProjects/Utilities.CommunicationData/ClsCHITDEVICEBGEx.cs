using System;
using System.Globalization;
using System.Threading;

namespace KangShuoTech.Utilities.CommunicationData
{
    /// <summary>
    /// 血糖
    /// </summary>
    internal class ClsCHITDEVICEBGEx : ClsQCTDeviceEx
    {
        public ClsCHITDEVICEBGEx(ClsCommunicationBlueEx comm)
        {
            base.m_Comm = comm;
            base.m_delay = 5000;
        }

        public override bool ExecClose(ref byte[] buffName)
        {
            Thread.Sleep(200);
            base.m_Comm.SendData(ref buffName, this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.SendData(ref buffName, this.CommandClose);
            return true;
        }

        public override bool ExecQuery(ref byte[] buffName)
        {
            base.ResultData = new byte[8];
            base.m_Comm.SetTimeOut(5000);
            //base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(500);

            int num = base.m_Comm.RecvData(ref buffName, ref this.ResultData, 8);
            //Trace.WriteLine("发送两次关机指令");
            //Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);
            //Thread.Sleep(200);
            //base.m_Comm.Send(this.CommandClose);

            if (num < 8)
            {
                return false;
            }

            while (ResultData[6] != 136)
            {
                Thread.Sleep(200);
                num = base.m_Comm.RecvData(ref buffName, ref this.ResultData, 8);

                if (num < 8)
                {
                    return false;
                }
            }

            //if (ResultData[6] != 136)
            //{
            //    num = base.m_Comm.RecvData(ref this.ResultData, 8);
            //}

            string str4 = ResultData[4].ToString("X");
            string str5 = ResultData[5].ToString("X");
            string str = str4 + str5;

            int bloodSuger = Convert.ToInt32(str, 16);
            decimal dBloodSuger = bloodSuger / 18.0M;

            ClsResult.DeviceName = "QCTBG";
            ClsResult.DeviceFriendName = "血糖";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            ClsResult.DeviceValue.QCTBG.XueTang = dBloodSuger.ToString("0.0");
            ClsResult.ResultFlag = true;

            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                //return new byte[] { byte.Parse("04", NumberStyles.HexNumber), byte.Parse("FF", NumberStyles.HexNumber), byte.Parse("A6", NumberStyles.HexNumber), byte.Parse("A9", NumberStyles.HexNumber) };
                return null;
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
