namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    internal class ClsQCTDEVICEBC : ClsQCTDevice
    {
        private string AllBuffer = "";

        public ClsQCTDEVICEBC(ClsCommunication comm)
        {
            base.m_Comm = comm;
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
            int num = 0;
            base.m_Comm.SetTimeOut(0x7530);
            base.m_Comm.Send(this.CommandReadStart);
            Thread.Sleep(500);
            do
            {
                num++;
                base.ResultData = new byte[15];
                if (base.m_Comm.Recv(ref this.ResultData, 15) > 14)
                {
                    string str = "";
                    foreach (byte num2 in base.ResultData)
                    {
                        string str2 = num2.ToString("X2");
                        str = str + str2 + " ";
                    }
                    ClsQCTDEVICEBC adevicebc = this;
                    string str3 = adevicebc.AllBuffer + str;
                    adevicebc.AllBuffer = str3;
                    if ((base.ResultData[13] == 13) && (base.ResultData[14] == 10))
                    {
                        break;
                    }
                }
                Thread.Sleep(0x3e8);
            }
            while (num < 3);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(200);
            base.m_Comm.Send(this.CommandClose);
            if ((this.AllBuffer == "") || (base.ResultData.Length <= 14))
            {
                return false;
            }
            ClsResult.DeviceName = "QCTBC";
            ClsResult.DeviceFriendName = "综合数据采集仪";
            ClsResult.DeviceAddress = "";
            ClsResult.DeviceValue = new valueItem();
            ClsResult.m_UnitList = new List<TYPEANDVALUE>();
            ClsResult.m_UnitList.Clear();
            ClsResult.DeviceValue.QCTBC.AllData = this.AllBuffer;
            ClsResult.DeviceValue.QCTBC.BarCode = base.ResultData[5].ToString() + base.ResultData[6].ToString() + base.ResultData[7].ToString() + base.ResultData[8].ToString();
            byte num3 = base.ResultData[9];
            TYPEANDVALUE item = new TYPEANDVALUE();
            switch (num3)
            {
                case 1:
                    ClsResult.DeviceValue.QCTBC.DataType = "幽门螺杆菌";
                    ClsResult.DeviceValue.QCTBC.ChildType = "幽门螺杆菌";
                    ClsResult.DeviceValue.QCTBC.HP_YouMen = Encoding.ASCII.GetString(base.ResultData, 10, 3).Replace('\0', ' ').Trim();
                    item.ChildType = "幽门螺杆菌";
                    item.Value = Encoding.ASCII.GetString(base.ResultData, 10, 3).Replace('\0', ' ').Trim();
                    ClsResult.m_UnitList.Add(item);
                    break;

                case 2:
                {
                    ClsResult.DeviceValue.QCTBC.DataType = "三围";
                    ClsResult.DeviceValue.QCTBC.ChildType = "三围";
                    string str4 = Convert.ToInt16(base.ResultData[10]).ToString();
                    ClsResult.DeviceValue.QCTBC.Xiongwei = str4;
                    string str5 = Convert.ToInt16(base.ResultData[11]).ToString();
                    ClsResult.DeviceValue.QCTBC.Yaowei = str5;
                    string str6 = Convert.ToInt16(base.ResultData[12]).ToString();
                    ClsResult.DeviceValue.QCTBC.Tunwei = str6;
                    item.ChildType = "胸围";
                    item.Value = ClsResult.DeviceValue.QCTBC.Xiongwei;
                    ClsResult.m_UnitList.Add(item);
                    item.ChildType = "腰围";
                    item.Value = ClsResult.DeviceValue.QCTBC.Yaowei;
                    ClsResult.m_UnitList.Add(item);
                    item.ChildType = "臀围";
                    item.Value = ClsResult.DeviceValue.QCTBC.Tunwei;
                    ClsResult.m_UnitList.Add(item);
                    break;
                }
                case 3:
                    ClsResult.DeviceValue.QCTBC.DataType = "身高";
                    ClsResult.DeviceValue.QCTBC.ChildType = "身高";
                    ClsResult.DeviceValue.QCTBC.Height = Convert.ToString(base.ResultData[12]).ToString();
                    item.ChildType = "身高";
                    item.Value = Convert.ToInt16(base.ResultData[12]).ToString();
                    ClsResult.m_UnitList.Add(item);
                    break;

                default:
                    ClsResult.DeviceValue.QCTBC.DataType = "err";
                    break;
            }
            ClsResult.ResultFlag = true;
            return true;
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x6f, 0x6b };
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
                return new byte[] { 0x4d };
            }
        }

        public byte[] CommandReadStart
        {
            get
            {
                return new byte[] { 0x73, 0x65, 110, 100 };
            }
        }
    }
}

