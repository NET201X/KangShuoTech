namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.IO.Ports;

    internal class ClsQCTDeviceComBG
    {
        private string m_ResultStr = "";
        private SerialPort m_SerialPort;

        public ClsQCTDeviceComBG(string com)
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
                        this.m_SerialPort.Write(this.CommandRead, 0, 1);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.m_ResultStr = this.m_ResultStr + this.m_SerialPort.ReadExisting();
            if (this.m_ResultStr.Contains("END"))
            {
                this.m_SerialPort.Write(this.CommandDelete, 0, 1);
                this.m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                this.m_ResultStr = this.m_ResultStr.Substring(0, this.m_ResultStr.IndexOf("END"));
                this.m_ResultStr = this.m_ResultStr.Trim();
                int num = this.m_ResultStr.LastIndexOf(" ");
                if ((num >= 0) && (num < (this.m_ResultStr.Length - 1)))
                {
                    double result = 0.0;
                    this.m_ResultStr = this.m_ResultStr.Substring(num + 1, (this.m_ResultStr.Length - num) - 1);
                    //if (ClsStaticFunc.isNumberic(this.m_ResultStr, out result))
                    //{
                    //    double num3 = result / 18.0;
                    //    ClsResult.DeviceName = "QCTBG";
                    //    ClsResult.DeviceFriendName = "血糖";
                    //    ClsResult.DeviceAddress = "";
                    //    ClsResult.DeviceValue = new valueItem();
                    //    ClsResult.DeviceValue.QCTBG.XueTang = num3.ToString("0.00");
                    //    ClsResult.DeviceValue.QCTBG.XueTang = ClsResult.DeviceValue.QCTBG.XueTang.Substring(0, ClsResult.DeviceValue.QCTBG.XueTang.Length - 1);
                    //    ClsResult.ResultFlag = true;
                    //}
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
                return new byte[] { 0x53, 0x4e, 6, 0, 2, 11, 0, 0, 0x13 };
            }
        }

        public byte[] CommandDelete
        {
            get
            {
                return new byte[] { 0x7f };
            }
        }

        public byte[] CommandRead
        {
            get
            {
                return new byte[] { 0x13 };
            }
        }
    }
}

