namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.IO.Ports;
    using System.Text;

    internal class ClsQCTDeviceComAKBG
    {
        private string m_ResultStr = "";
        private SerialPort m_SerialPort;

        public ClsQCTDeviceComAKBG(string com)
        {
            try
            {
                this.m_SerialPort = new SerialPort(com, 0x2580);
                if (!this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.Open();
                    this.m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                    if (this.m_SerialPort.IsOpen)
                    {
                        this.m_SerialPort.Write(this.CommandRead, 0, 11);
                        this.m_SerialPort.Write(this.CommandRead, 0, 11);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bool flag = false;
            int length = -1;
            string s = this.m_SerialPort.ReadExisting();
            Encoding.Default.GetBytes(s);
            this.m_ResultStr = this.m_ResultStr + s;
            byte[] bytes = Encoding.Default.GetBytes(this.m_ResultStr);
            if ((bytes != null) && (bytes.Length >= 2))
            {
                for (int i = 0; i < (bytes.Length - 1); i++)
                {
                    if ((bytes[i] == 30) && (bytes[i + 1] == 6))
                    {
                        flag = true;
                        while (this.m_SerialPort.BytesToRead > 0)
                        {
                            Encoding.Default.GetBytes(this.m_SerialPort.ReadExisting());
                        }
                        this.m_SerialPort.DiscardInBuffer();
                        length = i;
                        break;
                    }
                }
                if (flag)
                {
                    this.m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                    this.m_ResultStr = this.m_ResultStr.Substring(0, length);
                    string[] strArray = this.m_ResultStr.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (strArray.Length > 7)
                    {
                        double result = 0.0;
                        this.m_ResultStr = strArray[strArray.Length - 5];
                        //if (ClsStaticFunc.isNumberic(this.m_ResultStr, out result))
                        //{
                        //    double num4 = result / 18.0;
                        //    ClsResult.DeviceName = "QCTBG";
                        //    ClsResult.DeviceFriendName = "血糖";
                        //    ClsResult.DeviceAddress = "";
                        //    ClsResult.DeviceValue = new valueItem();
                        //    ClsResult.DeviceValue.QCTBG.XueTang = num4.ToString("0.0");
                        //    ClsResult.ResultFlag = true;
                        //}
                    }
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

        public byte[] CommandClose
        {
            get
            {
                return new byte[] { 0x26, 0x44, 0x48, 0x20, 6, 0x34, 0x31, 0x33, 0x34, 0x30, 13 };
            }
        }

        public byte[] CommandDelete
        {
            get
            {
                byte[] buffer = new byte[11];
                buffer[0] = 0x26;
                buffer[0] = 0x44;
                buffer[0] = 0x4a;
                buffer[0] = 0x20;
                buffer[0] = 6;
                buffer[0] = 0x34;
                buffer[0] = 0x39;
                buffer[0] = 0x35;
                buffer[0] = 0x33;
                buffer[0] = 0x33;
                buffer[0] = 13;
                return buffer;
            }
        }

        public byte[] CommandRead
        {
            get
            {
                return new byte[] { 0x26, 0x45, 90, 0x20, 6, 0x34, 0x39, 0x34, 0x34, 0x31, 13 };
            }
        }
    }
}

