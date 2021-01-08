namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Text;

    internal class ClsQCTDeviceYueHaoBG
    {
        private List<byte> m_DataList = new List<byte>();
        private string m_ResultStr = "";
        private SerialPort m_SerialPort;

        public ClsQCTDeviceYueHaoBG(string com)
        {
            try
            {
                this.m_SerialPort = new SerialPort(com, 0x2580);
                this.m_SerialPort.ReadTimeout = 0xbb8;
                this.m_SerialPort.WriteTimeout = 0xbb8;
                if (!this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.Open();
                    if (this.m_SerialPort.IsOpen)
                    {
                        this.m_SerialPort.Write(this.CommandQuery, 0, this.CommandQuery.Length);
                        byte[] bytes = new byte[12];
                        for (int i = 0; i < 12; i++)
                        {
                            bytes[i] = (byte) this.m_SerialPort.ReadByte();
                        }
                        if (Encoding.Default.GetString(bytes).Contains("YUYUE"))
                        {
                            this.m_SerialPort.DiscardInBuffer();
                            this.m_SerialPort.Close();
                            this.m_SerialPort.Open();
                            this.m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                            this.m_SerialPort.Write(this.CommandRead, 0, this.CommandRead.Length);
                        }
                    }
                }
            }
            catch (Exception)
            {
                this.m_SerialPort.Close();
                this.m_SerialPort.Dispose();
            }
        }

        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.m_SerialPort.BytesToRead > 0)
            {
                for (int i = 0; i < this.m_SerialPort.BytesToRead; i++)
                {
                    this.m_DataList.Add((byte) this.m_SerialPort.ReadByte());
                }
                int indexOfEE = -1;
                for (int j = 0; j < this.m_DataList.Count; j++)
                {
                    if (this.m_DataList[j] == 0xee)
                    {
                        indexOfEE = j;
                        break;
                    }
                }
                if (((indexOfEE > 0) && (this.m_DataList.Count > (indexOfEE + 1))) && (this.m_DataList[indexOfEE + 1] == 0xee))
                {
                    byte[] array = new byte[this.m_DataList.Count];
                    this.m_DataList.CopyTo(array);
                    this.m_SerialPort.DiscardInBuffer();
                    this.m_SerialPort.Close();
                    this.ParseResult(array, indexOfEE);
                }
            }
        }

        private void ParseResult(byte[] resultData, int IndexOfEE)
        {
            if (IndexOfEE >= 0x1b)
            {
                string str = string.Format("20{0}-{1}-{2} {3}:{4}:00", new object[] { resultData[IndexOfEE - 0x15].ToString(), resultData[IndexOfEE - 0x13].ToString(), resultData[IndexOfEE - 0x11].ToString(), resultData[IndexOfEE - 15].ToString(), resultData[IndexOfEE - 13].ToString() });
                double num = Math.Round((double) (((double) ((resultData[IndexOfEE - 10] * 0x100) + resultData[IndexOfEE - 11])) / 18.0), 1);
                if (num > 0.0)
                {
                    ClsResult.DeviceName = "QCTBG";
                    ClsResult.DeviceFriendName = "血糖";
                    ClsResult.DeviceAddress = "";
                    ClsResult.DeviceValue = new valueItem();
                    ClsResult.DeviceValue.QCTBG.Time = str;
                    ClsResult.DeviceValue.QCTBG.XueTang = num.ToString("0.00");
                    ClsResult.DeviceValue.QCTBG.XueTang = ClsResult.DeviceValue.QCTBG.XueTang.Substring(0, ClsResult.DeviceValue.QCTBG.XueTang.Length - 1);
                    ClsResult.ResultFlag = true;
                }
            }
        }

        public void StopRead()
        {
            try
            {
                if ((this.m_SerialPort != null) && this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                    this.m_SerialPort.Close();
                }
            }
            catch (Exception)
            {
                if (this.m_SerialPort != null)
                {
                    if (this.m_SerialPort.IsOpen)
                    {
                        this.m_SerialPort.Close();
                    }
                    this.m_SerialPort.Dispose();
                }
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

        public byte[] CommandQuery
        {
            get
            {
                return new byte[] { 1, 2, 0x53, 0x45, 0x41, 0x52, 0x43, 0x48, 0x2b, 0x30, 1, 3 };
            }
        }

        public byte[] CommandRead
        {
            get
            {
                return new byte[] { 1, 2, 0x53, 0x45, 0x4e, 0x44, 0x4d, 0x4d, 0x2b, 0x4e, 1, 3 };
            }
        }
    }
}

