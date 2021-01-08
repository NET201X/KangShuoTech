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

    public class ClsTransInfoTF
    {
        public static string age = "25";
        public static string height = "170";
        public static int m_BFHour = 0;
        public static int m_BFMinu = 0;



        private ClsCommunication m_communicationTF;

        private volatile ClsQCTDevice m_DeviceTF;

        private Thread m_bm;

        public static volatile bool ReadMode = false;
        public StringBuilder sb = new StringBuilder(12);
        public static string sex = "0";


        public event TransMessageHandle SendMsg;

        public ClsTransInfoTF(string portType)
        {
            if (this.m_communicationTF != null)
            {
                this.m_communicationTF.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
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
            this.m_bm = new Thread(new ThreadStart(this.ThreadExectueTF));
            this.m_bm.Name = "MY THREAD:ClsTransInfo.ThreadExectueBM线程";
            this.m_bm.Priority = ThreadPriority.AboveNormal;
            this.m_bm.Start();

            return true;
        }

        private void m_communication_DataExchange(string msg)
        {
            Trace.WriteLine("=====Data====  " + msg);
        }

        /// <summary>
        /// 体温
        /// </summary>
        public void ThreadExectueTF()
        {
            string str = "";
        Label_0000:

            this.m_communicationTF = null;
            str = GetClsCommunicationTF(ConfigurationManager.AppSettings["QCATF"], 9600, ConfigurationManager.AppSettings["TFDeviceName"]);

            if (str == "")
            {
                this.m_DeviceTF = null;
                Thread.Sleep(200);
                goto Label_0000;
            }

            try
            {
                if (this.m_communicationTF != null)
                {
                    this.m_communicationTF.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                this.m_DeviceTF = ClsDeviceFactory.CreateDevice(this.m_communicationTF, str, sex, age, height, m_BFHour, m_BFMinu);

                if (this.m_DeviceTF != null)
                {
                    if (ReadMode)
                    {
                        ClsResult.ResultFlag = false;
                        Thread.Sleep(1000);
                        this.SendMsg("CONNECT" + str);

                        this.m_communicationTF.StartDeviceListen();

                        if (this.m_DeviceTF.ExecQuery())
                        {
                            if (ClsResult.ResultFlag == true)
                            {
                                this.m_DeviceTF.ExecClose();

                                this.m_communicationTF.WriteDataLog();
                                this.SendMsg("TRANSEND");
                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            this.m_communicationTF.WriteDataLog();
                            this.SendMsg("ERROR");
                        }
                    }
                    else
                    {
                        this.m_DeviceTF.ExecClose();
                    }
                }
                else
                {
                    this.SendMsg("UNKNOWN" + str);
                }

                if (this.m_DeviceTF != null)
                {
                    if (ClsResult.ResultFlag == true)
                    {
                        Thread.Sleep(this.m_DeviceTF.m_delay);
                    }
                }
                else
                {
                    Thread.Sleep(3000);
                }

                this.m_communicationTF.Disconnect();
                this.m_communicationTF.StopHardListen();

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

        public string GetClsCommunicationTF(string com, int baudRate, string deviceName)
        {
            try
            {
                this.m_communicationTF = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                return deviceName;
            }
            catch (Exception e)
            {
                this.m_communicationTF = null;
            }

            return "";
        }
    }
}

