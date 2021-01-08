namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.IO.Ports;

    internal class ClsQCTDeviceComBP
    {
        private string m_ResultStr = "";
        private SerialPort m_SerialPort;

        public ClsQCTDeviceComBP(string com)
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
                        this.m_SerialPort.Write(this.CommandRead, 0, 2);
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
            string[] strArray = this.m_ResultStr.Split(new char[] { '^' });

            if ((strArray.Length == 4) && (strArray[2].Length > 12))
            {
                this.m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                string message = strArray[2].Substring(0, 3);
                string str2 = strArray[2].Substring(6, 3);
                string str3 = strArray[2].Substring(9, 3);

                //if ((ClsStaticFunc.isNumberic(message) && ClsStaticFunc.isNumberic(str2)) && ClsStaticFunc.isNumberic(str3))
                //{
                //    ClsResult.DeviceName = "QCTBP";
                //    ClsResult.DeviceFriendName = "血压";
                //    ClsResult.DeviceAddress = "";
                //    ClsResult.DeviceValue = new valueItem();
                //    ClsResult.DeviceValue.QCTBP.GaoYa = Convert.ToInt32(message).ToString();
                //    ClsResult.DeviceValue.QCTBP.DiYa = Convert.ToInt32(str2).ToString();
                //    ClsResult.DeviceValue.QCTBP.XinLv = Convert.ToInt32(str3).ToString();
                //    ClsResult.ResultFlag = true;
                //}
            }
        }

        public void StopRead()
        {
            try
            {
                if (this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.Write(this.CommandClose, 0, 1);
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
                return new byte[] { 13 };
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
                return new byte[] { 12, 12 };
            }
        }
    }
}

