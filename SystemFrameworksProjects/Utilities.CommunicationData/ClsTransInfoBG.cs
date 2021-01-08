using System.Configuration;

namespace KangShuoTech.Utilities.CommunicationData
{
    
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.IO.Ports;

    public class ClsTransInfoBG
    {
        public static string age = "25";
        public static string height = "170";
        public static int m_BFHour = 0;
        public static int m_BFMinu = 0;
        
        

        private ClsCommunication m_communicationBG;

        private volatile ClsQCTDevice m_DeviceBG;

        private Thread m_bg;

        public static volatile bool ReadMode = false;
        public StringBuilder sb = new StringBuilder(12);
        public static string sex = "0";
        

        public event TransMessageHandle SendMsg;

        public ClsTransInfoBG(string portType)
        {
            if (this.m_communicationBG != null)
            {
                this.m_communicationBG.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
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

        public bool InitListener()
        {
            this.m_bg = new Thread(new ThreadStart(this.ThreadExectueBG));
            this.m_bg.Name = "MY THREAD:ClsTransInfo.ThreadExectueBG线程";
            this.m_bg.Priority = ThreadPriority.AboveNormal;
            this.m_bg.Start();

            return true;
        }

        private void m_communication_DataExchange(string msg)
        {
            Trace.WriteLine("=====Data====  " + msg);
        }

        /// <summary>
        /// 血糖仪
        /// </summary>
        public void ThreadExectueBG()
        {
            string str = "";
        Label_0000:

            this.m_communicationBG = null;
            str = GetClsCommunicationBG(ConfigurationManager.AppSettings["CHITBG"], 9600, "CHITBG");

            if (str == "")
            {
                this.m_DeviceBG = null;
                Thread.Sleep(200);
                goto Label_0000;
            }

            try
            {
                //this.m_communicationBM = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                if (this.m_communicationBG != null)
                {
                    this.m_communicationBG.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                this.m_DeviceBG = ClsDeviceFactory.CreateDevice(this.m_communicationBG, str, sex, age, height, m_BFHour, m_BFMinu);

                if (this.m_DeviceBG != null)
                {
                    if (ReadMode)
                    {
                        ClsResult.ResultFlag = false;
                        Thread.Sleep(1000);
                        this.SendMsg("CONNECT" + str);

                        this.m_communicationBG.StartDeviceListen();

                        if (this.m_DeviceBG.ExecQuery())
                        {
                            if (ClsResult.ResultFlag == true)
                            {
                                this.m_DeviceBG.ExecClose();

                                this.m_communicationBG.WriteDataLog();
                                this.SendMsg("TRANSEND");
                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            this.m_communicationBG.WriteDataLog();
                            this.SendMsg("ERROR");
                        }
                    }
                    else
                    {
                        this.m_DeviceBG.ExecClose();
                    }
                }
                else
                {
                    this.SendMsg("UNKNOWN" + str);
                }

                if (this.m_DeviceBG != null)
                {
                    if (ClsResult.ResultFlag == true)
                    {
                        Thread.Sleep(this.m_DeviceBG.m_delay);
                    }
                }
                else
                {
                    Thread.Sleep(3000);
                }

                this.m_communicationBG.Disconnect();
                this.m_communicationBG.StopHardListen();

                if (ClsResult.ResultFlag == true)
                {
                    Thread.Sleep(5000);
                }

                goto Label_0000;
            }
            catch (Exception ex)
            {
                goto Label_0000;
            }
        }


        public string GetClsCommunicationBG(string com, int baudRate, string deviceName)
        {
            try
            {
                this.m_communicationBG = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                return deviceName;
            }
            catch (Exception e)
            {
                this.m_communicationBG = null;
            }

            return "";
        }
    }
}

