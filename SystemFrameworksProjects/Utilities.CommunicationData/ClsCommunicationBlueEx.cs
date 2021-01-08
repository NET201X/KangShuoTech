using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace KangShuoTech.Utilities.CommunicationData
{
    internal class ClsCommunicationBlueEx
    {
        public string m_data = "";
        private string m_OS = "XP";
     
        public const int WM_CONNECTMSG = 0x467;
        public const int WM_DEVICEMSG = 0x466;

        public event TransMessageHandle DataExchange;

        public ClsCommunicationBlueEx(string os)
        {
            this.m_data = "";
            this.m_OS = os;
        }

        [DllImport("BuletoothMaster.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Init();
        [DllImport("BuletoothMaster.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern int Query(ref byte data, int len);
        [DllImport("BuletoothMaster.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern int Send(ref byte name, ref byte data, int len);
        [DllImport("BuletoothMaster.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern int Recv(ref byte name, ref byte data, int len);
        [DllImport("BuletoothMaster.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DisConnect(ref byte name);
        [DllImport("BuletoothMaster.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool UnInit();

        public string GetDeviceName(ref byte[] buffName)
        {
            if (Query(ref buffName[0], 15) == -1)
            {
                return "";
            }

            return System.Text.Encoding.Default.GetString(buffName);
        }

        public int RecvData(ref byte[] buffName, ref byte[] data, int len)
        {
            int totalcount=0;
            int recvcount = 1;
            byte[] tmpData = new byte[255];
            while (recvcount > 0 && totalcount < len)
            {
                recvcount = Recv(ref buffName[0], ref tmpData[0], len);
                if (recvcount > 0)
                {
                    Array.Copy(tmpData,0,data,totalcount,recvcount);
                }
                totalcount = totalcount + recvcount;
            }

            return totalcount;
        }

        public int SendData(ref byte[] buffName, byte[] command)
        {
            return Send(ref buffName[0], ref command[0], command.Length);
        }

        public int Disconnect(ref byte[] buffName)
        {
            bool dis = DisConnect(ref buffName[0]);

            if (dis)
            {
                return 0;
            }

            return -1;
        }

        public void WriteDataLog()
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

        public bool StartHardListen()
        {
            return true;
        }

        public bool StopHardListen()
        {
            UnInit();
            return true;
        }

        public bool StopSoftListen()
        {
            return true;
        }

        public int SetTimeOut(int time)
        {
            return 0;
        }

        public bool StartDeviceListen()
        {
            return Init();
        }
    }
}
