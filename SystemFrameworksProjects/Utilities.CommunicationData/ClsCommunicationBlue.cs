namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    internal class ClsCommunicationBlue : ClsCommunication
    {
        public string m_data = "";
        private string m_OS = "XP";
        private bool m_slaveMode;
        public const int WM_CONNECTMSG = 0x467;
        public const int WM_DEVICEMSG = 0x466;

        public override event TransMessageHandle DataExchange;

        public ClsCommunicationBlue(string os)
        {
            this.m_data = "";
            this.m_OS = os;
        }

        public override int Disconnect()
        {
            DisConnect();
            return 0;
        }

        [DllImport("BlueToothCom.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        private static extern void DisConnect();
        [DllImport("BlueToothCom.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        private static extern int GetConnectState();
        public override string GetDeviceName()
        {
            string str2;

            if (GetConnectState() <= 0)
            {
                return "";
            }

            byte[] bytes = new byte[10];
            bytes[9] = 0;

            for (int i = 0; i < 9; i++)
            {
                bytes[i] = (byte) GetName(i);
            }

            string str = Encoding.Default.GetString(bytes);
            if (str.StartsWith("QCTBPT"))
            {
                str2 = "QCTBPT";
                this.m_slaveMode = false;
                return str2;
            }
            str2 = str.Substring(0, 6);
            this.m_slaveMode = false;
            return str2;
        }

        [DllImport("BlueToothCom.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        private static extern int GetName(int index);
        public override int Recv(ref byte[] data, int len)
        {
            return RecvData(ref data[0], len);
        }

        [DllImport("BlueToothCom.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        private static extern int RecvData(ref byte data, int len);
        public override int Send(byte[] command)
        {
            return SendCommand(ref command[0], command.Length);
        }

        [DllImport("BlueToothCom.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        private static extern int SendCommand(ref byte command, int commandlen);
        [DllImport("BlueToothCom.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        private static extern void SetRecvTimeOut(int timeout);
        public override int SetTimeOut(int time)
        {
            SetRecvTimeOut(time);
            return 0;
        }

        public override bool StartDeviceListen()
        {
            return (StartListen() == 0x103);
        }

        public override bool StartHardListen()
        {
            return true;
        }

        [DllImport("BlueToothCom.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        private static extern int StartListen();
        public override bool StopHardListen()
        {
            StopListen();
            return true;
        }

        [DllImport("BlueToothCom.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        private static extern int StopListen();
        public override bool StopSoftListen()
        {
            return true;
        }

        public override void WriteDataLog()
        {
            string path = Application.StartupPath + @"\DataLog.txt";
            this.m_data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss  ") + this.m_data + "\r\n";
            this.m_data = this.m_data + "\r\n===========================================\r\n";
            try
            {
                FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                if (stream.Length > 0x249f0L)
                {
                    stream.Close();
                    File.Delete(path);
                    stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    stream.Flush();
                    stream.Close();
                }
                stream.Close();
                StreamWriter writer = File.AppendText(path);
                writer.Write(this.m_data);
                writer.Flush();
                writer.Close();
                this.m_data = "";
            }
            catch (Exception)
            {
            }
        }
    }
}

