namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// 血压
    /// </summary>
    internal class ClsCHITDEVICEBPEx : ClsQCTDeviceEx
    {
        public ClsCHITDEVICEBPEx(ClsCommunicationBlueEx comm)
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
            base.m_Comm.SetTimeOut(1000);
            //Thread.Sleep(20000);

            //base.m_Comm.Send(this.CommandRead);
            //Thread.Sleep(500);

            int num = base.m_Comm.RecvData(ref buffName, ref this.ResultData, 2);
            Thread.Sleep(200);
            //Thread.Sleep(200);
            for (int i = 0; i < 2; i++)
                {
                    string value = string.Format("{0:X} ", ResultData[i]);
                    Console.Write(value);
                }
            Console.Write("\n-------\n");
            if (num <0)
            {
                return false;
            }
            bool hasResult = false;
            while (num>0)
            {
                
                if (!hasResult)
                {
                    num = base.m_Comm.RecvData(ref buffName, ref this.ResultData, 2);
                    for (int i = 0; i < 2; i++)
                    {
                        string value = string.Format("{0:X} ", ResultData[i]);
                        Console.Write(value);
                       
                    }
                    //Console.Write("\n=============\n");
                    if (num != 2)
                    {
                        return false;
                    }
 
                }

                if (ResultData[0] == 0x04 && ResultData[1] == 0xFF)
                {  
                    base.m_Comm.SendData(ref buffName,this.CommandRead);
                }

                if (ResultData[0] == 0x08 && ResultData[1] == 0xFF )
                {
                    byte[] tmpbyte = new byte[6];
                    num = base.m_Comm.RecvData(ref buffName, ref tmpbyte, 6);
                    for (int i = 0; i < 6; i++)
                    {
                        string value = string.Format("{0:X} ", tmpbyte[i]);
                        Console.Write(value);
                    }
                    Console.Write("\n!!!!!!!!!!\n");
                    if (num != 6)
                    {
                        return false;
                    }
                    else
                    {
                        Array.Copy(tmpbyte, 0,ResultData, 2,  6);
                        break;
                    }
                }
               
                Thread.Sleep(200);
                Thread.Sleep(200);
            }

            for (int i = 0; i < 8; i++)
            {
                string value = string.Format("{0:X} ", ResultData[i]);
                Console.Write(value);
            }

            Thread.Sleep(200);
            base.m_Comm.SendData(ref buffName, this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.SendData(ref buffName, this.CommandClose);

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

