namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO.Ports;
    using System.Text;
    using System.Threading;

    internal class ClsQCTDeviceComBU : ClsQCTDevice
    {
        private string m_ResultStr;
        private SerialPort m_SerialPort;

        public ClsQCTDeviceComBU(string com)
        {
            this.m_ResultStr = "";
            try
            {
                this.m_SerialPort = new SerialPort(com, 0x2580);
                if (!this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.Open();
                    this.m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                }
            }
            catch (Exception)
            {
            }
        }

        public ClsQCTDeviceComBU(ClsCommunication comm)
        {
            this.m_ResultStr = "";
            base.m_Comm = comm;
            base.m_delay = 0xbb8;
        }

        public override bool ExecClose()
        {
            Thread.Sleep(0xbb8);
            base.m_Comm.Send(this.CommandClose);
            return true;
        }

        public override bool ExecQuery()
        {
            int num;
            base.ResultData = new byte[5];
            base.m_Comm.SetTimeOut(0x1388);
            Thread.Sleep(0x7d0);
            base.m_Comm.Send(this.CommandRead);
            Thread.Sleep(500);
            do
            {
                num = base.m_Comm.Recv(ref this.ResultData, 5);
                ClsQCTDeviceComBU mbu = this;
                string str = mbu.m_ResultStr + Encoding.ASCII.GetString(base.ResultData);
                mbu.m_ResultStr = str;
                Trace.WriteLine("================" + this.m_ResultStr);
            }
            while (!this.m_ResultStr.Contains("\"                         \"") && (num > 0));
            if (!this.m_ResultStr.Contains("\"                         \""))
            {
                return false;
            }
            string[] subItem = this.GetSubItem(this.m_ResultStr);
            if (subItem != null)
            {
                ClsResult.DeviceName = "QCTCOMBU";
                ClsResult.DeviceFriendName = "血生化";
                ClsResult.DeviceAddress = "";
                ClsResult.m_UnitList = new List<TYPEANDVALUE>();
                ClsResult.m_UnitList.Clear();
                ClsResult.DeviceValue = new valueItem();
                ClsResult.DeviceValue.QCTBU.XueTang = "";
                ClsResult.DeviceValue.QCTBU.DanGuChun = "";
                ClsResult.DeviceValue.QCTBU.GanYouSanZhi = "";
                ClsResult.DeviceValue.QCTBU.GaoMiDu = "";
                ClsResult.DeviceValue.QCTBU.XueTongTi = "";
                ClsResult.DeviceValue.QCTBU.DiMiDu = "";
                ClsResult.DeviceValue.QCTBU.XueTongTi = "";
                foreach (string str2 in subItem)
                {
                    this.GetValueFromCode(str2);
                }
                ClsResult.ResultFlag = true;
            }
            return true;
        }

        private string getItems(string strval, string code)
        {
            int index = strval.IndexOf(code);
            int num2 = -1;
            if (index > 0)
            {
                num2 = strval.IndexOf("\"", index) + 1;
            }
            if ((index > 0) && (num2 > 0))
            {
                return strval.Substring(index, (num2 - index) - 1);
            }
            return "";
        }

        private string[] GetSubItem(string items)
        {
            List<string> list = new List<string>();
            string[] strArray = null;
            list.Add(this.getItems(items, "CHOL   "));
            list.Add(this.getItems(items, "GLUCOSE"));
            list.Add(this.getItems(items, "HDL CHOL"));
            list.Add(this.getItems(items, "CALC LDL"));
            list.Add(this.getItems(items, "TRIG"));
            list.Add(this.getItems(items, "KETONE"));
            list.Add(this.getItems(items, "CREAT"));
            list.RemoveAll(x => x == "");
            if (list.Count > 0)
            {
                strArray = list.ToArray();
            }
            return strArray;
        }

        private void GetValueFromCode(string code)
        {
            TYPEANDVALUE item = new TYPEANDVALUE();
            string str = code.Substring(0, code.IndexOf(":")).Trim();
            string str2 = code.Substring(code.IndexOf(":") + 1, (code.Length - code.IndexOf(":")) - 1);
            if (str2.Contains("mmol"))
            {
                string str3 = str2.Trim();
                if (str3.StartsWith("<") || str3.StartsWith(">"))
                {
                    str3 = str3.Substring(1, str3.Length - 1);
                }
                string str4 = str3.Substring(0, str3.IndexOf("mmol")).Trim();
                switch (str)
                {
                    case "CHOL":
                        ClsResult.DeviceValue.QCTBU.DanGuChun = str4;
                        item.ChildType = "总胆固醇";
                        item.Value = str4;
                        ClsResult.m_UnitList.Add(item);
                        ClsResult.DeviceValue.QCTBU.ChildType = item.ChildType;
                        return;

                    case "GLUCOSE":
                        ClsResult.DeviceValue.QCTBU.XueTang = str4;
                        item.ChildType = "血糖";
                        item.Value = str4;
                        ClsResult.m_UnitList.Add(item);
                        ClsResult.DeviceValue.QCTBU.ChildType = item.ChildType;
                        return;

                    case "HDL CHOL":
                        ClsResult.DeviceValue.QCTBU.GaoMiDu = str4;
                        item.ChildType = "高密度脂蛋白";
                        item.Value = str4;
                        ClsResult.m_UnitList.Add(item);
                        ClsResult.DeviceValue.QCTBU.ChildType = item.ChildType;
                        return;

                    case "CALC LDL":
                        ClsResult.DeviceValue.QCTBU.DiMiDu = str4;
                        item.ChildType = "低密度脂蛋白";
                        item.Value = str4;
                        ClsResult.m_UnitList.Add(item);
                        ClsResult.DeviceValue.QCTBU.ChildType = item.ChildType;
                        return;

                    case "TRIG":
                        ClsResult.DeviceValue.QCTBU.GanYouSanZhi = str4;
                        item.ChildType = "甘油三酯";
                        item.Value = str4;
                        ClsResult.m_UnitList.Add(item);
                        ClsResult.DeviceValue.QCTBU.ChildType = item.ChildType;
                        return;

                    case "KETONE":
                        ClsResult.DeviceValue.QCTBU.XueTongTi = str4;
                        item.ChildType = "血酮体";
                        item.Value = str4;
                        ClsResult.m_UnitList.Add(item);
                        ClsResult.DeviceValue.QCTBU.ChildType = item.ChildType;
                        return;

                    case "CREAT":
                        ClsResult.DeviceValue.QCTBU.JiGan = str4;
                        item.ChildType = "肌酐";
                        item.Value = str4;
                        ClsResult.DeviceValue.QCTBU.ChildType = item.ChildType;
                        return;
                }
            }
        }

        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.m_ResultStr = this.m_ResultStr + this.m_SerialPort.ReadExisting();
            if (this.m_ResultStr.Contains("\"                         \""))
            {
                this.m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                string[] subItem = this.GetSubItem(this.m_ResultStr);
                if (subItem != null)
                {
                    ClsResult.DeviceName = "QCTCOMBU";
                    ClsResult.DeviceFriendName = "血生化";
                    ClsResult.DeviceAddress = "";
                    ClsResult.m_UnitList = new List<TYPEANDVALUE>();
                    ClsResult.m_UnitList.Clear();
                    ClsResult.DeviceValue = new valueItem();
                    ClsResult.DeviceValue.QCTBU.XueTang = "";
                    ClsResult.DeviceValue.QCTBU.DanGuChun = "";
                    ClsResult.DeviceValue.QCTBU.GanYouSanZhi = "";
                    ClsResult.DeviceValue.QCTBU.GaoMiDu = "";
                    ClsResult.DeviceValue.QCTBU.XueTongTi = "";
                    ClsResult.DeviceValue.QCTBU.DiMiDu = "";
                    ClsResult.DeviceValue.QCTBU.XueTongTi = "";
                    foreach (string str in subItem)
                    {
                        this.GetValueFromCode(str);
                    }
                    ClsResult.ResultFlag = true;
                }
            }
        }

        public void StopRead()
        {
            try
            {
                if (this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                    this.m_SerialPort.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x43, 0x4c, 0x4f, 0x53, 0x45 };
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
                return new byte[] { 0x53, 0x45, 0x4e, 0x44 };
            }
        }
    }
}

