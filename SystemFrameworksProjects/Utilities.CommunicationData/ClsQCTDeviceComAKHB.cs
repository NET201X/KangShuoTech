namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;

    internal class ClsQCTDeviceComAKHB
    {
        private string m_ResultStr = "";
        private SerialPort m_SerialPort;

        public ClsQCTDeviceComAKHB(string com)
        {
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

        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.m_ResultStr = this.m_ResultStr + this.m_SerialPort.ReadExisting();
            if ((this.m_ResultStr.Contains("HB") && this.m_ResultStr.Contains("HCT")) && this.m_ResultStr.Contains("\r\n\r\n\r\n"))
            {
                this.m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                ClsResult.DeviceName = "QCTHB";
                ClsResult.DeviceFriendName = "血红蛋白";
                ClsResult.DeviceAddress = "";
                ClsResult.m_UnitList = new List<TYPEANDVALUE>();
                ClsResult.m_UnitList.Clear();
                ClsResult.DeviceValue = new valueItem();
                string[] strArray = this.m_ResultStr.Substring(this.m_ResultStr.IndexOf("HB"), 12).Split(new char[] { ':' });
                string[] strArray2 = this.m_ResultStr.Substring(this.m_ResultStr.IndexOf("HCT")).Split(new char[] { ':' });
                if ((strArray != null) && (strArray.Length > 1))
                {
                    ClsResult.DeviceValue.QCTHB.HB = strArray[1].Replace("g/dL", "").Trim();
                }
                if ((strArray2 != null) && (strArray2.Length > 1))
                {
                    ClsResult.DeviceValue.QCTHB.HTC = strArray2[1].Trim();
                }
                ClsResult.ResultFlag = true;
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
    }
}

