namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;

    internal class ClsALKDEVICETF : ClsQCTDevice
    {
        public ClsALKDEVICETF(ClsCommunication comm)
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
            base.ResultData = new byte[13];
            base.m_Comm.SetTimeOut(1000);
            //base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(500);
            int num = base.m_Comm.Recv(ref this.ResultData, 13);
            //int num = base.m_Comm.Recv(ref this.ResultData, 7);
            //int num = 0;
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);

            if (num != 13)
            {
                return false;
            }

            ClsResult.DeviceName = "QCTTF";
            ClsResult.DeviceFriendName = "体温";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();

            //string str = Conversions.GetUShortIntegerFromPacket(base.ResultData, 5, true).ToString();
            //string str2 = str.Insert(str.Length - 1, ".");

            string str4 = ResultData[9].ToString();
            string str5 = ResultData[10].ToString();

            if (str4 == "255" || str4 == "224" || str4 == "240")
            {
                return false;
            }

            if (str5.Length==1)
            {
                str5 = "0";
                //string str = str4 + "." + str5;
            }
            else if(str5.Length==2)
            {
                str5 = str5.Substring(0, 1);
                //string str = str4 + "." + str5;
            }


            string str = str4 + "." + str5;

            //string str1 = ResultData[3].ToString("X");
            //string str2 = ResultData[4].ToString("X");

            //string str = str1 + str2;

            //int tiwen = Convert.ToInt32(str, 16);

            //str = tiwen.ToString().Insert(2, ".");

            ClsResult.DeviceValue.QCTTF.TiWen = str;
            ClsResult.ResultFlag = true;

            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0xFF, 02, 0xFA };
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
                return new byte[] { 0xFF, 01, 0xFA };
            }
        }
    }
}

