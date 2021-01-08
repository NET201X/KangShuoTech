using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KangShuoTech.Utilities.CommunicationData
{
    public class ClsTransInfoEx
    {
        private ClsCommunicationBlueEx m_communication;

        private volatile ClsQCTDeviceEx m_Device;

        private Thread m_td;

        public event TransMessageHandle SendMsg;

        public static volatile bool ReadMode = false;

        public ClsTransInfoEx(string portType)
        {
            if (portType.ToUpper() == "BLUE")
            {
                m_communication = new ClsCommunicationBlueEx(GetOs());

            }
        }

        private string GetOs()
        {
            Version version = Environment.OSVersion.Version;

            if ((version.Major == 5) && (version.Minor == 1))
            {
                return "XP";
            }

            if ((version.Major == 6) && (version.Minor == 0))
            {
                return "VISTA";
            }

            if ((version.Major == 6) && (version.Minor == 1))
            {
                return "WIN7";
            }

            if ((version.Major == 5) && (version.Minor == 0))
            {
                return "WIN2000";
            }

            return "NONE";
        }

        void m_communication_DataExchange(string msg)
        {
            //发送原始数据字节流
            //SendMsg("BYTEDATA:" + msg);
            System.Diagnostics.Trace.WriteLine("=====Data====  " + msg);
        }

        public bool InitListener()
        {
            if (m_communication != null)
            {
                if (m_communication.StartDeviceListen())
                {
                    m_td = new Thread(ThreadExectue);
                    m_td.Name = "MY THREAD:ClsTransInfo.ThreadExectue线程";
                    //m_td.IsBackground = true;
                    m_td.Priority = ThreadPriority.AboveNormal;
                    m_td.Start();
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        public void ThreadExectue()
        {
            string str;
        Label_0000:

            byte[] buffName = new byte[15];
            str = this.m_communication.GetDeviceName(ref buffName).Replace("\0", "");

            if (str == "")
            {
                this.m_Device = null;
                Thread.Sleep(200);
                goto Label_0000;
            }

            try
            {
                this.m_Device = ClsDeviceFactoryEx.CreateDevice(this.m_communication, str);
                
                if (this.m_Device != null)
                {
                    if (ReadMode)
                    {
                        ClsResult.ResultFlag = false;
                        Thread.Sleep(0x3e8);
                        this.SendMsg("CONNECT" + str);

                        if (this.m_Device.ExecQuery(ref buffName))
                        {
                            this.m_communication.WriteDataLog();
                            this.SendMsg("TRANSEND");
                            Thread.Sleep(500);
                        }
                        else
                        {
                            this.m_Device.ExecClose(ref buffName);
                            this.m_communication.WriteDataLog();
                            this.SendMsg("ERROR");
                        }
                    }
                    else
                    {
                        this.m_Device.ExecClose(ref buffName);
                    }
                }
                else
                {
                    this.SendMsg("UNKNOWN" + str);
                }

                Console.WriteLine("\r\n===========disconnect");
                this.m_communication.Disconnect(ref buffName);

                if (this.m_Device != null)
                {
                    Thread.Sleep(this.m_Device.m_delay);
                }
                else
                {
                    Thread.Sleep(0xbb8);
                }
                
                Thread.Sleep(0x3e8);
                goto Label_0000;
            }
            catch (Exception)
            {
                goto Label_0000;
            }
        }
    }
}
