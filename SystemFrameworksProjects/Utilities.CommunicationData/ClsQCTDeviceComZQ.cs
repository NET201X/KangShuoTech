namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Management;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    internal class ClsQCTDeviceComZQ
    {
        private string m_ResultStr = "";
        private SerialPort m_SerialPort;

        private static string GetZQcom()
        {
            new StringBuilder();
            new List<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");
            foreach (ManagementObject obj2 in searcher.Get())
            {
                try
                {
                    if (Convert.ToString(obj2["Name"]).ToUpper().IndexOf("COM") >= 0)
                    {
                        string str2 = Convert.ToString(obj2["Name"]);
                        if (str2.ToUpper().Contains("(COM") && str2.ToUpper().Contains("ZQ"))
                        {
                            foreach (Capture capture in new Regex(@"\((.*)\)").Matches(Convert.ToString(obj2["Name"])))
                            {
                                string str3 = Regex.Replace(capture.Value, @"\(|\)", "");
                                if (str3.IndexOf("COM") >= 0)
                                {
                                    return str3;
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    //ClsToolTip.WriteLog("Common 类" + exception.Message);
                }
            }
            searcher.Dispose();
            return "";
        }

        private static int indexOf(byte[] data, byte[] b)
        {
            for (int i = 0; i < ((data.Length - b.Length) + 1); i++)
            {
                bool flag = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (data[i + j] != b[j])
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    return i;
                }
            }
            return -1;
        }

        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.m_ResultStr = this.m_ResultStr + this.m_SerialPort.ReadExisting();
            byte[] bytes = Encoding.Default.GetBytes(this.m_ResultStr);
            byte[] b = new byte[] { 0x73, 0x74, 0x6d };
            byte[] buffer3 = new byte[] { 0x65, 0x74, 0x6d };
            int num = indexOf(bytes, b);
            int num2 = indexOf(bytes, buffer3);
            if (((num2 > num) && (num > 0)) && (num2 > 0))
            {
                ClsResult.DeviceValue = new valueItem();
                for (int i = num + 3; i < num2; i++)
                {
                    string str = this.ParseResult(bytes[i]);
                    ClsResult.DeviceValue.QCTZQ.result = ClsResult.DeviceValue.QCTZQ.result + str + ",";
                }
                if (num2 == (num + 3))
                {
                    ClsResult.DeviceValue.QCTZQ.result = "结果为窦性心律,";
                }
                if (ClsResult.DeviceValue.QCTZQ.result.Length > 0)
                {
                    ClsResult.DeviceName = "QCTZQ";
                    ClsResult.DeviceFriendName = "心电";
                    ClsResult.DeviceAddress = "";
                    ClsResult.ResultFlag = true;
                }
                this.StopRead();
            }
        }

        private string ParseResult(uint code)
        {
            string str = "无法判断";
            if (code == 12)
            {
                str = "无法确定的心电轴";
            }
            if (code == 13)
            {
                str = "轻微电轴左偏";
            }
            if (code == 14)
            {
                str = "心电轴右偏";
            }
            if (code == 15)
            {
                str = "明显的心电轴右偏";
            }
            if (code == 0x10)
            {
                str = "心电轴左偏";
            }
            if (code == 0x11)
            {
                str = "明显的心电轴";
            }
            if (code == 0x12)
            {
                str = "无法确定的心电轴";
            }
            if ((code >= 20) && (code <= 0x1b))
            {
                str = "怀疑心室肥大";
            }
            if ((code >= 0x1c) && (code <= 0x1f))
            {
                str = "怀疑心房肥大";
            }
            if ((code >= 0x20) && (code <= 0x2f))
            {
                str = "怀疑WPW综合症";
            }
            if (((code >= 0x3b) && (code <= 0x3d)) || (code == 0x43))
            {
                str = "T波改变";
            }
            if ((code >= 0x47) && (code <= 0x4f))
            {
                str = "不能确定的心电异常";
            }
            if (code == 110)
            {
                str = "窦性心率";
            }
            if ((code == 0x6f) || (code == 0x70))
            {
                str = "窦性心率过缓";
            }
            if (code == 0x71)
            {
                str = "窦性心率不齐";
            }
            if ((code >= 0x72) && (code <= 0x81))
            {
                str = "不能确定的心率不齐";
            }
            if ((code >= 130) && (code <= 0x8d))
            {
                str = "怀疑逸搏";
            }
            if ((code >= 0x8e) && (code <= 150))
            {
                str = "怀疑早搏";
            }
            if ((code >= 0x97) && (code <= 0x9a))
            {
                str = "非典型心电图";
            }
            if ((code >= 0x9b) && (code <= 0x9e))
            {
                str = "正常范围心电图";
            }
            return str;
        }

        public bool startRead()
        {
            try
            {
                string zQcom = GetZQcom();
                if (zQcom == "")
                {
                    MessageBox.Show("未找到设备,请确认设备驱动安装正常!");
                    return false;
                }
                this.StopRead();
                this.m_SerialPort = new SerialPort(zQcom, 0x1c200);
                if (!this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.Open();
                    this.m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                    if (this.m_SerialPort.IsOpen)
                    {
                        this.m_SerialPort.Write(this.CommandRead, 0, 6);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("串口打开失败!请检查设备连接是否正常。");
                this.StopRead();
                return false;
            }
            return true;
        }

        public void StopRead()
        {
            try
            {
                if (this.m_SerialPort != null)
                {
                    if (this.m_SerialPort.IsOpen)
                    {
                        this.m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                        this.m_SerialPort.Close();
                    }
                    this.m_SerialPort.Dispose();
                }
            }
            catch (Exception)
            {
            }
        }

        private byte[] CommandRead
        {
            get
            {
                return new byte[] { 0xfe, 0x87, 0x5d, 2, 3, 0xf2 };
            }
        }
    }
}

