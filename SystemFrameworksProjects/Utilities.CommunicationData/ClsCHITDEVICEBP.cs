namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// 血压
    /// </summary>
    internal class ClsCHITDEVICEBP : ClsQCTDevice
    {
        public ClsCHITDEVICEBP(ClsCommunication comm)
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
            base.ResultData = new byte[8];
            base.m_Comm.SetTimeOut(5000);
            base.m_Comm.Send(this.CommandRead);
            
            int num = base.m_Comm.Recv(ref this.ResultData, 8);
            Thread.Sleep(200);
            Thread.Sleep(200);

            if (num != 8)
            {
                return false;
            }

            //for (int i = 0; i < 8; i++)
            //{
            //    Console.Write(string.Format("{0:X} ", ResultData[i]) + " ");

            //    if (i == 7)
            //    {
            //        Console.WriteLine("");
            //    }
            //}

            while ((ResultData[0] == 4 || ResultData[0] == 6))
            {
                Thread.Sleep(2000);
                base.m_Comm.Send(this.CommandRead);
            
                num = base.m_Comm.Recv(ref this.ResultData, 8);

                //for (int i = 0; i < 8; i++)
                //{
                //    Console.Write(string.Format("{0:X} ", ResultData[i]) + " ");

                //    if (i == 7)
                //    {
                //        Console.WriteLine("");
                //    }
                //}
            }

            ClsResult.DeviceName = "CHITBP";
            ClsResult.DeviceFriendName = "血压";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();

            string str = base.ResultData[4].ToString();
            string str2 = base.ResultData[5].ToString();
            string str3 = base.ResultData[6].ToString();

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
                return new byte[] { byte.Parse("04", NumberStyles.HexNumber), byte.Parse("FF", NumberStyles.HexNumber), byte.Parse("A6", NumberStyles.HexNumber), byte.Parse("A9", NumberStyles.HexNumber) };
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
                return new byte[] { 0x04, 0xFF, 0xA0, 0xA3 };
            }
        }
    }
}

