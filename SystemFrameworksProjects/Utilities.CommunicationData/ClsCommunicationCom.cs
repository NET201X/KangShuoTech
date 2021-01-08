namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.IO.Ports;
    using System.Threading;
    using System.Windows.Forms;

    internal class ClsCommunicationCom : ClsCommunication
    {
        private ClsCommunicationCom communicationCom;
        private bool m_ConnectFlag;
        private string m_DevName = "";
        private string m_os = "";
        private string m_portName = "";
        private SerialPort m_SerialPort = new SerialPort();
        private string str;

        public override event TransMessageHandle DataExchange;

        public ClsCommunicationCom(string os, string port, int baudRate)
        {
            this.m_os = os;
            this.m_portName = port;
            this.m_SerialPort.PortName = port;
            this.m_SerialPort.BaudRate = baudRate;
            this.m_SerialPort.ReadTimeout = 5000;

            if (this.m_SerialPort.IsOpen)
            {
                this.m_SerialPort.Close();
            }

            this.m_SerialPort.Open();
        }

        public override int Disconnect()
        {
            this.m_SerialPort.DiscardInBuffer();
            this.m_SerialPort.DiscardOutBuffer();
            this.m_ConnectFlag = false;
            return 0;
        }

        public override string GetDeviceName()
        {
            if (this.m_ConnectFlag)
            {
                return this.m_DevName;
            }

            return "";
        }

        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!this.m_ConnectFlag)
            {
                if (this.m_SerialPort.IsOpen)
                {
                    this.m_DevName = this.m_SerialPort.ReadExisting();
                }

                //byte[] ResultData = new byte[19];
                //int len = 19;
                //int offset = 0;
                //int num2 = this.m_SerialPort.Read(ResultData, offset, len - offset);

                if (this.m_DevName != "")
                {
                    if (this.m_DevName.ToCharArray()[0] != '\f')
                    {
                        if (this.m_DevName.StartsWith("CHIT"))
                        {
                            MessageBox.Show(this.m_DevName);
                            this.m_ConnectFlag = true;
                        }
                    }
                    else
                    {
                        this.m_SerialPort.DiscardInBuffer();
                    }
                }
            }
        }

        public override int Recv(ref byte[] data, int len)
        {
            try
            {
                int offset = 0;

                while (offset < len)
                {
                    int num2 = this.m_SerialPort.Read(data, offset, len - offset);
                    switch (num2)
                    {
                        case -1:
                        case 0:
                            return -100;
                    }
                    offset += num2;
                }
                return offset;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public override int Send(byte[] command)
        {
            try
            {
                this.m_SerialPort.Write(command, 0, command.Length);
                this.m_SerialPort.Write(command, 0, command.Length);
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        public override int SetTimeOut(int time)
        {
            return 0;
        }

        public override bool StartDeviceListen()
        {
            if (this.m_SerialPort.PortName != "")
            {
                //if (this.m_SerialPort.IsOpen)
                //{
                //    MessageBox.Show("致命错误,串口被占用!");
                //    return false;
                //}

                if (!m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.Open();
                }

                this.m_SerialPort.ReadTimeout = 0x2710;
                this.m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
            }
            return true;
        }

        public override bool StartHardListen()
        {
            return true;
        }

        public override bool StopHardListen()
        {
            try
            {
                if (this.m_SerialPort.IsOpen)
                {
                    this.m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
                    this.m_SerialPort.Close();

                    return true;
                }
            }
            catch (Exception)
            {
            }

            return false;
        }

        public override bool StopSoftListen()
        {
            return true;
        }

        public override void WriteDataLog()
        {

        }
    }
}

