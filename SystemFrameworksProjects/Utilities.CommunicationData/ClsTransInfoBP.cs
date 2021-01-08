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

    public class ClsTransInfoBP
    {
        public static string age = "25";
        public static string height = "170";
        public static int m_BFHour = 0;
        public static int m_BFMinu = 0;



        private ClsCommunication m_communicationBP;

        private volatile ClsQCTDevice m_DeviceBP;

        private Thread m_bp;

        public static volatile bool ReadMode = false;
        public StringBuilder sb = new StringBuilder(12);
        public static string sex = "0";


        public event TransMessageHandle SendMsg;

        public ClsTransInfoBP(string portType)
        {
            if (this.m_communicationBP != null)
            {
                this.m_communicationBP.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
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
            this.m_bp = new Thread(new ThreadStart(this.ThreadExectueBP));
            this.m_bp.Name = "MY THREAD:ClsTransInfo.ThreadExectueBP线程";
            this.m_bp.Priority = ThreadPriority.AboveNormal;
            this.m_bp.Start();

            return true;
        }

        private void m_communication_DataExchange(string msg)
        {
            Trace.WriteLine("=====Data====  " + msg);
        }

        /// <summary>
        /// 血压计
        /// </summary>
        public void ThreadExectueBP()
        {
            string str = "";
        Label_0000:

            this.m_communicationBP = null;
            str = GetClsCommunicationBP(ConfigurationManager.AppSettings["CHITBP"], 9600, ConfigurationManager.AppSettings["TFDeviceName"]);

            if (str == "")
            {
                this.m_DeviceBP = null;
                Thread.Sleep(200);
                goto Label_0000;
            }

            try
            {
                //this.m_communicationBM = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                if (this.m_communicationBP != null)
                {
                    this.m_communicationBP.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                this.m_DeviceBP = ClsDeviceFactory.CreateDevice(this.m_communicationBP, str, sex, age, height, m_BFHour, m_BFMinu);

                if (this.m_DeviceBP != null)
                {
                    if (ReadMode)
                    {
                        ClsResult.ResultFlag = false;
                        Thread.Sleep(1000);
                        this.SendMsg("CONNECT" + str);

                        this.m_communicationBP.StartDeviceListen();

                        if (this.m_DeviceBP.ExecQuery())
                        {
                            if (ClsResult.ResultFlag == true)
                            {
                                this.m_DeviceBP.ExecClose();

                                this.m_communicationBP.WriteDataLog();
                                this.SendMsg("TRANSEND");
                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            this.m_communicationBP.WriteDataLog();
                            this.SendMsg("ERROR");
                        }
                    }
                    else
                    {
                        this.m_DeviceBP.ExecClose();
                    }
                }
                else
                {
                    this.SendMsg("UNKNOWN" + str);
                }

                if (this.m_DeviceBP != null)
                {
                    if (ClsResult.ResultFlag == true)
                    {
                        Thread.Sleep(this.m_DeviceBP.m_delay);
                    }
                }
                else
                {
                    Thread.Sleep(3000);
                }

                this.m_communicationBP.Disconnect();
                this.m_communicationBP.StopHardListen();

                if (ClsResult.ResultFlag == true)
                {
                    Thread.Sleep(1000);
                }

                goto Label_0000;
            }
            catch (Exception ex)
            {
                goto Label_0000;
            }
        }

        public string GetClsCommunicationBP(string com, int baudRate, string deviceName)
        {
            try
            {
                this.m_communicationBP = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                return deviceName;
            }
            catch (Exception e)
            {
                this.m_communicationBP = null;
            }

            return "";
        }
    }
}

