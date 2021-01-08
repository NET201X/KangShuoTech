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

    public class ClsTransInfoUI
    {
        public static string age = "25";
        public static string height = "170";
        public static int m_BFHour = 0;
        public static int m_BFMinu = 0;
        
        

        private ClsCommunication m_communicationUI;

        private volatile ClsQCTDevice m_DeviceUI;

        private Thread m_ui;

        public static volatile bool ReadMode = false;
        public StringBuilder sb = new StringBuilder(12);
        public static string sex = "0";
        

        public event TransMessageHandle SendMsg;

        public ClsTransInfoUI(string portType)
        {
            if (this.m_communicationUI != null)
            {
                this.m_communicationUI.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
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


            this.m_ui = new Thread(new ThreadStart(this.ThreadExectueUI));
            this.m_ui.Name = "MY THREAD:ClsTransInfo.ThreadExectueUI线程";
            this.m_ui.Priority = ThreadPriority.AboveNormal;
            this.m_ui.Start();

            return true;
        }

        private void m_communication_DataExchange(string msg)
        {
            Trace.WriteLine("=====Data====  " + msg);
        }

        /// <summary>
        /// 尿机
        /// </summary>
        public void ThreadExectueUI()
        {
            string str = "";
        Label_0000:

            this.m_communicationUI = null;
            str = GetClsCommunicationUI(ConfigurationManager.AppSettings["EMPUI"], 9600, "EMPUI");

            if (str == "")
            {
                this.m_DeviceUI = null;
                Thread.Sleep(200);
                goto Label_0000;
            }

            try
            {
                if (this.m_communicationUI != null)
                {
                    this.m_communicationUI.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                this.m_DeviceUI = ClsDeviceFactory.CreateDevice(this.m_communicationUI, str, sex, age, height, m_BFHour, m_BFMinu);

                if (this.m_DeviceUI != null)
                {
                    if (ReadMode)
                    {
                        ClsResult.ResultFlag = false;
                        Thread.Sleep(1000);
                        this.SendMsg("CONNECT" + str);

                        this.m_communicationUI.StartDeviceListen();

                        if (this.m_DeviceUI.ExecQuery())
                        {
                            if (ClsResult.ResultFlag == true)
                            {
                                this.m_DeviceUI.ExecClose();

                                this.m_communicationUI.WriteDataLog();
                                this.SendMsg("TRANSEND");
                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            this.m_communicationUI.WriteDataLog();
                            this.SendMsg("ERROR");
                        }
                    }
                    else
                    {
                        this.m_DeviceUI.ExecClose();
                    }
                }
                else
                {
                    this.SendMsg("UNKNOWN" + str);
                }

                if (this.m_DeviceUI != null)
                {
                    if (ClsResult.ResultFlag == true)
                    {
                        Thread.Sleep(this.m_DeviceUI.m_delay);
                    }
                }
                else
                {
                    Thread.Sleep(3000);
                }

                this.m_communicationUI.Disconnect();
                this.m_communicationUI.StopHardListen();

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

        public string GetClsCommunicationUI(string com, int baudRate, string deviceName)
        {
            try
            {
                this.m_communicationUI = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                return deviceName;
            }
            catch (Exception e)
            {
                this.m_communicationUI = null;
            }

            return "";
        }
    }
}

