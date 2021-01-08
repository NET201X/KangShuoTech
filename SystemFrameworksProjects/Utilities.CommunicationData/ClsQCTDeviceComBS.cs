namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.IO.Ports;
    using System.Threading;

    public class ClsQCTDeviceComBS
    {
        private string m_comNum = "";
        private int m_RecordNum;
        private string m_ResultStr = "";
        private SerialPort m_SerialPort;
        private Thread m_td;
        private bool m_TmpFlag;

        public ClsQCTDeviceComBS(string com)
        {
            try
            {
                ClsResult.DeviceValue = new valueItem();
                this.m_TmpFlag = false;
                this.m_comNum = com;
                this.m_td = new Thread(new ThreadStart(this.OpenCom));
                this.m_td.Name = "串口交互线程";
                this.m_td.IsBackground = true;
                this.m_td.Start();
            }
            catch (Exception)
            {
            }
        }

        private bool GetHand()
        {
            try
            {
                if ((this.m_SerialPort == null) || !this.m_SerialPort.IsOpen)
                {
                    return false;
                }
                this.m_SerialPort.Write(this.CommandQuery, 0, this.CommandQuery.Length);
                Thread.Sleep(300);
                byte[] buffer = new byte[4];
                for (int i = 0; i < 4; i++)
                {
                    buffer[i] = (byte) this.m_SerialPort.ReadByte();
                }
                return ((((buffer[0] == 0x55) && (buffer[1] == 170)) && (buffer[2] == 1)) && (buffer[3] == 0));
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void OpenCom()
        {
            try
            {
                this.m_SerialPort = new SerialPort(this.m_comNum, 0x9600);
                this.m_SerialPort.WriteTimeout = 0xbb8;
                this.m_SerialPort.ReadTimeout = 0xbb8;
                if (!this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.Open();
                    if (this.m_SerialPort.IsOpen)
                    {
                        int num = 0;
                        bool hand = false;
                        while (!hand && (num < 5))
                        {
                            hand = this.GetHand();
                            if (hand)
                            {
                                break;
                            }
                            num++;
                            if (this.m_SerialPort.IsOpen)
                            {
                                this.m_SerialPort.Close();
                            }
                            Thread.Sleep(500);
                            this.m_SerialPort = new SerialPort(this.m_comNum, 0x9600);
                            this.m_SerialPort.WriteTimeout = 0xbb8;
                            this.m_SerialPort.ReadTimeout = 0xbb8;
                            this.m_SerialPort.Open();
                        }
                        if (!hand)
                        {
                            return;
                        }
                        this.m_SerialPort.Write(this.CommandGetNum, 0, this.CommandGetNum.Length);
                        byte[] buffer = new byte[9];
                        for (int i = 0; i < 9; i++)
                        {
                            buffer[i] = (byte) this.m_SerialPort.ReadByte();
                        }
                        if (((buffer[0] != 0x55) || (buffer[1] != 170)) || (buffer[2] != 2))
                        {
                            return;
                        }
                        this.m_RecordNum = (buffer[3] * 0x100) + buffer[4];
                        ClsResult.DeviceValue.QCTBS.DataValue = new QCTBS_BYTES[this.m_RecordNum];
                        for (int j = 0; j < this.m_RecordNum; j++)
                        {
                            byte[] buffer5 = new byte[] { 0x55, 170, 3, 0, 0 };
                            buffer5[3] = (byte) ((j + 1) / 0x100);
                            buffer5[4] = (byte) ((j + 1) % 0x100);
                            byte[] buffer2 = buffer5;
                            this.m_SerialPort.Write(buffer2, 0, buffer2.Length);
                            byte[] buffer3 = new byte[0x11];
                            for (int k = 0; k < 0x11; k++)
                            {
                                buffer3[k] = (byte) this.m_SerialPort.ReadByte();
                            }
                            string str = "20" + buffer3[3].ToString("X2") + buffer3[4].ToString("X2") + buffer3[5].ToString("X2") + buffer3[6].ToString("X2") + buffer3[7].ToString("X2") + buffer3[8].ToString("X2");
                            ClsResult.DeviceValue.QCTBS.DataValue[j].DataTime = str;
                            ClsResult.DeviceValue.QCTBS.DataValue[j].Intv = buffer3[9];
                            int num5 = (buffer3[11] * 0x100) + buffer3[12];
                            ClsResult.DeviceValue.QCTBS.DataValue[j].Values = new byte[num5];
                            byte[] buffer6 = new byte[] { 0x55, 170, 4, 0, 0 };
                            buffer6[3] = (byte) ((j + 1) / 0x100);
                            buffer6[4] = (byte) ((j + 1) % 0x100);
                            byte[] buffer4 = buffer6;
                            this.m_SerialPort.Write(buffer4, 0, buffer4.Length);
                            for (int m = 0; m < 3; m++)
                            {
                                this.m_SerialPort.ReadByte();
                            }
                            for (int n = 0; n < num5; n++)
                            {
                                ClsResult.DeviceValue.QCTBS.DataValue[j].Values[n] = (byte) this.m_SerialPort.ReadByte();
                                this.m_TmpFlag = true;
                            }
                            for (int num8 = 0; num8 < 4; num8++)
                            {
                                this.m_SerialPort.ReadByte();
                            }
                            Thread.Sleep(500);
                        }
                    }
                    if (this.m_TmpFlag)
                    {
                        ClsResult.DeviceName = "QCTBS";
                        ClsResult.DeviceFriendName = "睡眠监护仪";
                        ClsResult.DeviceAddress = "";
                        ClsResult.ResultFlag = true;
                    }
                }
            }
            catch (Exception)
            {
                if (this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.Close();
                }
            }
            finally
            {
                if (this.m_SerialPort != null)
                {
                    if (this.m_SerialPort.IsOpen)
                    {
                        this.m_SerialPort.Close();
                    }
                    this.m_SerialPort.Dispose();
                    this.m_SerialPort = null;
                }
            }
        }

        public void StopRead()
        {
            try
            {
                if ((this.m_td != null) && this.m_td.IsAlive)
                {
                    this.m_td.Abort();
                }
                if ((this.m_SerialPort != null) && this.m_SerialPort.IsOpen)
                {
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
                byte[] buffer = new byte[3];
                buffer[0] = 0x55;
                buffer[0] = 170;
                buffer[0] = 0xfd;
                return buffer;
            }
        }

        public byte[] CommandDeleteQuery
        {
            get
            {
                byte[] buffer = new byte[3];
                buffer[0] = 0x55;
                buffer[0] = 170;
                buffer[0] = 0xfc;
                return buffer;
            }
        }

        public byte[] CommandGetNum
        {
            get
            {
                return new byte[] { 0x55, 170, 2 };
            }
        }

        public byte[] CommandQuery
        {
            get
            {
                return new byte[] { 0x55, 170, 1 };
            }
        }

        public byte[] CommandReadData
        {
            get
            {
                return new byte[] { 0x55, 170, 4, 0, 0 };
            }
        }

        public byte[] CommandReadHead
        {
            get
            {
                return new byte[] { 0x55, 170, 3, 0, 0 };
            }
        }
    }
}

