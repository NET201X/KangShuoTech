namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Timers;

    internal class ClsQCTDeviceComAKBU
    {
        private int m_lastCount;
        private int m_recvCount;
        private string m_ResultStr = "";
        private SerialPort m_SerialPort;
        private bool m_SingleFlag;
        private Timer timer;

        public ClsQCTDeviceComAKBU(string com)
        {
            try
            {
                this.m_recvCount = 0;
                this.m_lastCount = 0;
                this.m_SerialPort = new SerialPort(com, 0x2580);
                this.timer = new Timer(5000.0);
                this.timer.Elapsed += new ElapsedEventHandler(this.m_timer_Tick);
                this.timer.Start();
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

        private string[] GetSubItem(string items)
        {
            List<string> list = new List<string>();
            string[] strArray = items.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] strArray2 = null;
            foreach (string str in strArray)
            {
                if (str.Contains(":"))
                {
                    list.Add(str);
                }
            }
            if (list.Count > 0)
            {
                strArray2 = list.ToArray();
            }
            return strArray2;
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
                if (!str4.Contains("NA"))
                {
                    switch (str)
                    {
                        case "CHOL":
                            ClsResult.DeviceValue.QCTBU.DanGuChun = str4;
                            item.ChildType = "总胆固醇";
                            item.Value = str4;
                            ClsResult.m_UnitList.Add(item);
                            return;

                        case "GLUCOSE":
                            ClsResult.DeviceValue.QCTBU.XueTang = str4;
                            item.ChildType = "血糖";
                            item.Value = str4;
                            ClsResult.m_UnitList.Add(item);
                            return;

                        case "HDL":
                            ClsResult.DeviceValue.QCTBU.GaoMiDu = str4;
                            item.ChildType = "高密度脂蛋白";
                            item.Value = str4;
                            ClsResult.m_UnitList.Add(item);
                            return;

                        case "LDL":
                            ClsResult.DeviceValue.QCTBU.DiMiDu = str4;
                            item.ChildType = "低密度脂蛋白";
                            item.Value = str4;
                            ClsResult.m_UnitList.Add(item);
                            return;

                        case "TRIG":
                            ClsResult.DeviceValue.QCTBU.GanYouSanZhi = str4;
                            item.ChildType = "甘油三酯";
                            item.Value = str4;
                            ClsResult.m_UnitList.Add(item);
                            return;

                        case "KETONE":
                            ClsResult.DeviceValue.QCTBU.XueTongTi = str4;
                            item.ChildType = "血酮体";
                            item.Value = str4;
                            ClsResult.m_UnitList.Add(item);
                            return;

                        case "CREAT":
                            ClsResult.DeviceValue.QCTBU.JiGan = str4;
                            item.ChildType = "肌酐";
                            item.Value = str4;
                            return;
                    }
                }
            }
        }

        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.m_ResultStr = this.m_ResultStr + this.m_SerialPort.ReadExisting();
            this.m_recvCount++;
            if (this.m_ResultStr.Contains("\r\n\r\n\r\n"))
            {
                int startIndex = this.m_ResultStr.LastIndexOf("ID");
                int num2 = this.m_ResultStr.LastIndexOf("\r\n\r\n\r\n");
                if (((startIndex >= 0) && (num2 >= 0)) && ((num2 - startIndex) >= 50))
                {
                    this.m_ResultStr = this.m_ResultStr.Substring(startIndex, num2 - startIndex);
                    string[] subItem = this.GetSubItem(this.m_ResultStr);
                    if (subItem != null)
                    {
                        ClsResult.DeviceName = "QCTAKBU";
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
                        this.m_SingleFlag = true;
                    }
                }
            }
        }

        private void m_timer_Tick(object sender, EventArgs e)
        {
            if (this.m_recvCount != 0)
            {
                if (this.m_recvCount != this.m_lastCount)
                {
                    this.m_lastCount = this.m_recvCount;
                }
                else
                {
                    this.timer.Stop();
                    ClsResult.ResultFlag = true;
                }
            }
        }

        public void StopRead()
        {
            try
            {
                this.timer.Stop();
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
    }
}

