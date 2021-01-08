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

    public class ClsTransInfoBM
    {
        public static string age = "25";
        public static string height = "170";
        public static int m_BFHour = 0;
        public static int m_BFMinu = 0;



        private ClsCommunication m_communicationBM;
        private ClsCommunication m_communicationBM_N; // 新体重称

        private volatile ClsQCTDevice m_DeviceBM;
        private volatile ClsQCTDevice m_DeviceBM_N; // 新体重称

        private Thread m_bm;
        private Thread m_bm_n; // 新体重称

        public static volatile bool ReadMode = false;
        public StringBuilder sb = new StringBuilder(12);
        public static string sex = "0";


        public event TransMessageHandle SendMsg;

        public ClsTransInfoBM(string portType)
        {
            if (this.m_communicationBM != null)
            {
                this.m_communicationBM.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
            }

            if (this.m_communicationBM_N != null)
            {
                this.m_communicationBM_N.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
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
            this.m_bm = new Thread(new ThreadStart(this.ThreadExectueBM));
            this.m_bm.Name = "MY THREAD:ClsTransInfo.ThreadExectueBM线程";
            this.m_bm.Priority = ThreadPriority.AboveNormal;
            this.m_bm.Start();

            return true;
        }

        public bool InitListener(string pBTType)
        {
            switch (pBTType)
            {
                // 体重
                case "BM":
                    this.m_bm = new Thread(new ThreadStart(this.ThreadExectueBM));
                    this.m_bm.Name = "MY THREAD:ClsTransInfo.ThreadExectueBM线程";
                    this.m_bm.Priority = ThreadPriority.AboveNormal;
                    this.m_bm.Start();
                    break;
                // 体重_新
                case "BM_N":
                    this.m_bm_n = new Thread(new ThreadStart(this.ThreadExectueBM_N));
                    this.m_bm_n.Name = "MY THREAD:ClsTransInfo.ThreadExectueBM_N线程";
                    this.m_bm_n.Priority = ThreadPriority.AboveNormal;
                    this.m_bm_n.Start();
                    break;
            }

            return true;
        }

        private void m_communication_DataExchange(string msg)
        {
            Trace.WriteLine("=====Data====  " + msg);
        }

        /// <summary>
        /// 电子称
        /// </summary>
        public void ThreadExectueBM()
        {
            string str = "";
        Label_0000:

            this.m_communicationBM = null;
            str = GetClsCommunicationBM(ConfigurationManager.AppSettings["CHITBM"], 4800, ConfigurationManager.AppSettings["TFDeviceName"]);
            bool getResult = false;
            if (str == "")
            {
                this.m_DeviceBM = null;
                Thread.Sleep(200);
                goto Label_0000;
            }

            try
            {
                //this.m_communicationBM = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                if (this.m_communicationBM != null)
                {
                    this.m_communicationBM.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                this.m_DeviceBM = ClsDeviceFactory.CreateDevice(this.m_communicationBM, str, sex, age, height, m_BFHour, m_BFMinu);

                if (this.m_DeviceBM != null)
                {
                    if (ReadMode)
                    {
                        ClsResult.ResultFlag = false;
                        Thread.Sleep(1000);
                        this.SendMsg("CONNECT" + str);

                        this.m_communicationBM.StartDeviceListen();

                        if (this.m_DeviceBM.ExecQuery())
                        {
                            //if (!str.StartsWith("QCTBF") || (ClsResult.DeviceMsg != "参数设置已经完成,请进行测量."))
                            //{
                            if (ClsResult.ResultFlag == true)
                            {
                                getResult = true;
                                //this.m_DeviceBM.ExecClose();

                                this.m_communicationBM.WriteDataLog();
                                this.SendMsg("TRANSEND");
                                Thread.Sleep(500);
                            }
                            //}

                        }
                        else
                        {
                            this.m_communicationBM.WriteDataLog();
                            this.SendMsg("ERROR");
                        }
                    }
                    else
                    {
                        this.m_DeviceBM.ExecClose();
                    }

                    if (ClsResult.ResultFlag == true)
                    {
                        Thread.Sleep(this.m_DeviceBM.m_delay);
                    }
                }
                else
                {
                    this.SendMsg("UNKNOWN" + str);
                    Thread.Sleep(1000);
                }

                this.m_communicationBM.Disconnect();
                this.m_communicationBM.StopHardListen();

                if (ClsResult.ResultFlag == true)
                {
                    Thread.Sleep(500);
                }

                goto Label_0000;
            }
            catch (Exception ex)
            {
                goto Label_0000;
            }
        }

        /// <summary>
        /// 电子称-新
        /// </summary>
        public void ThreadExectueBM_N()
        {
            string str = "";
        Label_0000:

            this.m_communicationBM_N = null;

            str = GetClsCommunicationBM_N(ConfigurationManager.AppSettings["CHITBM"], 115200, "CHITBM_N");
            bool getResult = false;

            if (str == "")
            {
                WritelogInfo("1.str=''");
                this.m_DeviceBM_N = null;

                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(200);
                goto Label_0000;
            }

            try
            {
                if (this.m_communicationBM_N != null)
                {
                    this.m_communicationBM_N.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                if (this.m_DeviceBM_N == null)
                {
                    this.m_DeviceBM_N = ClsDeviceFactory.CreateDevice(this.m_communicationBM_N, str, sex, age, height, m_BFHour, m_BFMinu);
                }

                if (this.m_DeviceBM_N != null)
                {
                    if (ReadMode)
                    {
                        ClsResult.ResultFlag = false;
                        //this.SendMsg("CONNECT" + str);

                        this.m_communicationBM_N.StartDeviceListen();

                        if (this.m_DeviceBM_N.ExecQuery())
                        {
                            if (ClsResult.ResultFlag == true)
                            {
                                WritelogInfo("2.ResultFlag == true");
                                getResult = true;

                                this.m_communicationBM_N.WriteDataLog();
                                this.SendMsg("TRANSEND");
                                WritelogInfo("TRANSEND:" + ClsResult.DeviceValue.QCTBM.TiZhong);
                                //Thread.Sleep(500);
                                System.Windows.Forms.Application.DoEvents();
                            }

                        }
                        else
                        {
                            WritelogInfo("3.m_DeviceBM_N.ExecQuery()=false");
                            this.m_communicationBM_N.WriteDataLog();
                            this.SendMsg("ERROR");

                            //Thread.Sleep(500);
                            System.Windows.Forms.Application.DoEvents();

                            this.m_DeviceBM_N.ExecClose();
                        }
                    }

                    if (ClsResult.ResultFlag == true)
                    {
                        WritelogInfo("4.this.m_DeviceBM_N.m_delay");
                        Thread.Sleep(this.m_DeviceBM_N.m_delay);
                    }
                }
                else
                {
                    Thread.Sleep(200);

                    WritelogInfo("5.this.m_DeviceBM_N =null");
                }

                this.m_communicationBM_N.Disconnect();
                this.m_communicationBM_N.StopHardListen();
                System.Windows.Forms.Application.DoEvents();

                goto Label_0000;
            }
            catch (Exception ex)
            {
                WritelogInfo("99." + ex.Message + ex.StackTrace);
                goto Label_0000;
            }
        }

        public string GetClsCommunicationBM(string com, int baudRate, string deviceName)
        {
            try
            {
                this.m_communicationBM = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                return deviceName;
            }
            catch (Exception e)
            {
                this.m_communicationBM = null;
            }

            return "";
        }

        public string GetClsCommunicationBM_N(string com, int baudRate, string deviceName)
        {
            try
            {
                this.m_communicationBM_N = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                return deviceName;
            }
            catch (Exception e)
            {
                //WritelogInfo("99.2." + e.Message);
                this.m_communicationBM_N = null;
            }

            return "";
        }

        private void WritelogInfo(string msg)
        {
            return;

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Log";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string logPath = AppDomain.CurrentDomain.BaseDirectory + "Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            try
            {
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine("消息：" + msg);
                    sw.WriteLine("时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.WriteLine("**************************************************");
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (IOException e)
            {
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine("异常：" + e.Message);
                    sw.WriteLine("时间：" + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
                    sw.WriteLine("**************************************************");
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}

