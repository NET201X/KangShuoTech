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

    public class ClsTransInfo
    {
        public static string age = "25";
        public static string height = "170";
        public static int m_BFHour = 0;
        public static int m_BFMinu = 0;
        
        

        private ClsCommunication m_communicationBM;
        private ClsCommunication m_communicationBG;
        private ClsCommunication m_communicationBP;
        private ClsCommunication m_communicationHEM;
        private ClsCommunication m_communicationUI;
        private ClsCommunication m_communicationTF;
        private ClsCommunication m_communicationBT;
        private ClsCommunication m_communication;

        private volatile ClsQCTDevice m_DeviceBM;
        private volatile ClsQCTDevice m_DeviceBG;
        private volatile ClsQCTDevice m_DeviceBP;
        private volatile ClsQCTDevice m_DeviceHEM;
        private volatile ClsQCTDevice m_DeviceUI;
        private volatile ClsQCTDevice m_DeviceTF;
        private volatile ClsQCTDevice m_DeviceBT;
        private volatile ClsQCTDevice m_Device;

        private Thread m_bm;
        private Thread m_bg;
        private Thread m_bp;
        private Thread m_hem;
        private Thread m_ui;
        private Thread m_tf;
        private Thread m_td;
        private Thread m_bt;

        public static volatile bool ReadMode = false;
        public StringBuilder sb = new StringBuilder(12);
        public static string sex = "0";
       // 


        public event TransMessageHandle SendMsg;

        public ClsTransInfo(string portType)
        {
            if (portType.ToUpper() == "BLUE")
            {
                this.m_communicationHEM = new ClsCommunicationBlue(this.GetOs());
            }
            else if (portType.ToUpper().StartsWith("COM"))
            {
                this.m_communicationHEM = new ClsCommunicationBlue(this.GetOs());

                if (this.m_communicationBM != null)
                {
                    this.m_communicationBM.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                if (this.m_communicationBG != null)
                {
                    this.m_communicationBG.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                if (this.m_communicationBP != null)
                {
                    this.m_communicationBP.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                if (this.m_communicationHEM != null)
                {
                    this.m_communicationHEM.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                if (this.m_communicationUI != null)
                {
                    this.m_communicationUI.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                if (this.m_communication != null)
                {
                    this.m_communication.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                if (this.m_communicationBT != null)
                {
                    this.m_communicationBT.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }
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
            //if ((this.m_communicationHEM == null) || !this.m_communicationHEM.StartDeviceListen())
            //{
            //    return false;
            //}

            //this.m_hem = new Thread(new ThreadStart(this.ThreadExectueHEM));
            //this.m_hem.Name = "MY THREAD:ClsTransInfo.ThreadExectueHEM线程";
            //this.m_hem.Priority = ThreadPriority.Highest;
            //this.m_hem.Start();

            //this.m_td = new Thread(new ThreadStart(this.ThreadExectue));
            //this.m_td.Name = "MY THREAD:ClsTransInfo.ThreadExectue线程";
            //this.m_td.Priority = ThreadPriority.AboveNormal;
            //this.m_td.Start();

            //this.m_tf = new Thread(new ThreadStart(this.ThreadExectueTF));
            //this.m_tf.Name = "MY THREAD:ClsTransInfo.ThreadExectueTF线程";
            //this.m_tf.Priority = ThreadPriority.AboveNormal;
            //this.m_tf.Start();

            //this.m_bm = new Thread(new ThreadStart(this.ThreadExectueBM));
            //this.m_bm.Name = "MY THREAD:ClsTransInfo.ThreadExectueBM线程";
            //this.m_bm.Priority = ThreadPriority.AboveNormal;
            //this.m_bm.Start();

            //this.m_bg = new Thread(new ThreadStart(this.ThreadExectueBG));
            //this.m_bg.Name = "MY THREAD:ClsTransInfo.ThreadExectueBG线程";
            //this.m_bg.Priority = ThreadPriority.AboveNormal;
            //this.m_bg.Start();

            //this.m_bp = new Thread(new ThreadStart(this.ThreadExectueBP));
            //this.m_bp.Name = "MY THREAD:ClsTransInfo.ThreadExectueBP线程";
            //this.m_bp.Priority = ThreadPriority.AboveNormal;
            //this.m_bp.Start();

            //this.m_ui = new Thread(new ThreadStart(this.ThreadExectueUI));
            //this.m_ui.Name = "MY THREAD:ClsTransInfo.ThreadExectueUI线程";
            //this.m_ui.Priority = ThreadPriority.AboveNormal;
            //this.m_ui.Start();

            this.m_bt = new Thread(new ThreadStart(this.ThreadExectueBT));
            this.m_bt.Name = "MY THREAD:ClsTransInfo.ThreadExectueBT线程";
            this.m_bt.Priority = ThreadPriority.AboveNormal;
            this.m_bt.Start();

            return true;
        }

        public bool InitBTListener()
        {
            try
            {
                if ((this.m_communicationHEM == null) || !this.m_communicationHEM.StartDeviceListen())
                {
                    return false;
                }

                this.m_hem = new Thread(new ThreadStart(this.ThreadExectueHEM));
                this.m_hem.Name = "MY THREAD:ClsTransInfo.ThreadExectueHEM线程";
                this.m_hem.Priority = ThreadPriority.AboveNormal;
                this.m_hem.Start();

                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            return false;
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
            str = GetClsCommunicationBM(ConfigurationManager.AppSettings["CHITBM"], 9600, "CHITBM");

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
                                this.m_DeviceBM.ExecClose();

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
                }
                else
                {
                    this.SendMsg("UNKNOWN" + str);
                }

                if (this.m_DeviceBM != null)
                {
                    if (ClsResult.ResultFlag == true)
                    {
                        Thread.Sleep(this.m_DeviceBM.m_delay);
                    }
                }
                else
                {
                    Thread.Sleep(3000);
                }

                this.m_communicationBM.Disconnect();
                this.m_communicationBM.StopHardListen();

                if (ClsResult.ResultFlag == true)
                {
                    Thread.Sleep(10000);
                }

                goto Label_0000;
            }
            catch (Exception ex)
            {
                goto Label_0000;
            }
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
                    Thread.Sleep(50000);
                }

                goto Label_0000;
            }
            catch (Exception ex)
            {
                goto Label_0000;
            }
        }

        /// <summary>
        /// 血压计
        /// </summary>
        public void ThreadExectueBP()
        {
            string str = "";
        Label_0000:

            this.m_communicationBP = null;
            str = GetClsCommunicationBP(ConfigurationManager.AppSettings["CHITBP"], 9600, "CHITBP");

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

        /// <summary>
        /// 血氧仪
        /// </summary>
        public void ThreadExectueBT()
        {
            string str = "";
        Label_0000:

            this.m_communicationBT = null;
            str = GetClsCommunicationBT(ConfigurationManager.AppSettings["QCTBT"], 9600, "QCTBT");

            if (str == "")
            {
                this.m_DeviceBP = null;
                Thread.Sleep(200);
                goto Label_0000;
            }

            try
            {
                if (this.m_communicationBT != null)
                {
                    this.m_communicationBT.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                this.m_DeviceBT = ClsDeviceFactory.CreateDevice(this.m_communicationBT, str, sex, age, height, m_BFHour, m_BFMinu);

                if (this.m_DeviceBT != null)
                {
                    if (ReadMode)
                    {
                        ClsResult.ResultFlag = false;
                        Thread.Sleep(1000);
                        this.SendMsg("CONNECT" + str);

                        this.m_communicationBT.StartDeviceListen();

                        if (this.m_DeviceBT.ExecQuery())
                        {
                            if (ClsResult.ResultFlag == true)
                            {
                                this.m_DeviceBT.ExecClose();

                                this.m_communicationBT.WriteDataLog();
                                this.SendMsg("TRANSEND");
                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            this.m_communicationBT.WriteDataLog();
                            this.SendMsg("ERROR");
                        }
                    }
                    else
                    {
                        this.m_DeviceBT.ExecClose();
                    }
                }
                else
                {
                    this.SendMsg("UNKNOWN" + str);
                }

                if (this.m_DeviceBT != null)
                {
                    if (ClsResult.ResultFlag == true)
                    {
                        Thread.Sleep(this.m_DeviceBT.m_delay);
                    }
                }
                else
                {
                    Thread.Sleep(3000);
                }

                this.m_communicationBT.Disconnect();
                this.m_communicationBT.StopHardListen();

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

        /// <summary>
        /// 欧姆龙血压计
        /// </summary>
        public void ThreadExectueHEM()
        {
            string str;
        Label_0000:
            str = this.m_communicationHEM.GetDeviceName();

            if (str == "")
            {
                this.m_DeviceHEM = null;
                Thread.Sleep(200);
                goto Label_0000;
            }

            try
            {
                this.m_DeviceHEM = ClsDeviceFactory.CreateDevice(this.m_communicationHEM, str, sex, age, height, m_BFHour, m_BFMinu);

                if (this.m_DeviceHEM != null)
                {
                    if (ReadMode)
                    {
                        ClsResult.ResultFlag = false;
                        Thread.Sleep(0x3e8);
                        this.SendMsg("CONNECT" + str);
                        if (this.m_DeviceHEM.ExecQuery())
                        {
                            if (!str.StartsWith("BF") || (ClsResult.DeviceMsg != "参数设置已经完成,请进行测量."))
                            {
                                this.m_DeviceHEM.ExecClose();
                            }
                            this.m_communicationHEM.WriteDataLog();
                            this.SendMsg("TRANSEND");
                            Thread.Sleep(500);
                        }
                        else
                        {
                            this.m_communicationHEM.WriteDataLog();
                            this.SendMsg("ERROR");
                        }
                    }
                    else
                    {
                        this.m_DeviceHEM.ExecClose();
                    }
                }
                else
                {
                    this.SendMsg("UNKNOWN" + str);
                }
                if (this.m_DeviceHEM != null)
                {
                    Thread.Sleep(this.m_DeviceHEM.m_delay);
                }
                else
                {
                    Thread.Sleep(0xbb8);
                }
                this.m_communicationHEM.Disconnect();
                Thread.Sleep(0x3e8);
                goto Label_0000;
            }
            catch (Exception)
            {
                goto Label_0000;
            }
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

        /// <summary>
        /// 体温
        /// </summary>
        public void ThreadExectueTF()
        {
            string str = "";
        Label_0000:

            this.m_communicationTF = null;
            str = GetClsCommunicationTF(ConfigurationManager.AppSettings["ALKTF"], 9600, "ALKTF");

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

        public void ThreadExectue()
        {
            string str = "";
        Label_0000:

            this.m_communication = null;
            str = GetClsCommunication(ConfigurationManager.AppSettings["CHITBP"], 9600, "CHITBP");

            if (str == "")
            {
                str = GetClsCommunication(ConfigurationManager.AppSettings["CHITBM"], 4800, "CHITBM");
            }

            if (str == "")
            {
                str = GetClsCommunication(ConfigurationManager.AppSettings["CHITBG"], 9600, "CHITBG");
            }

            //if (str == "")
            //{
            //    str = GetClsCommunication(ConfigurationManager.AppSettings["EMPUI"], 9600, "EMPUI");
            //}

            if (str == "")
            {
                this.m_Device = null;
                Thread.Sleep(200);
                goto Label_0000;
            }

            try
            {
                //this.m_communicationBM = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                if (this.m_communication != null)
                {
                    this.m_communication.DataExchange += new TransMessageHandle(this.m_communication_DataExchange);
                }

                this.m_Device = ClsDeviceFactory.CreateDevice(this.m_communication, str, sex, age, height, m_BFHour, m_BFMinu);

                if (this.m_Device != null)
                {
                    if (ReadMode)
                    {
                        ClsResult.ResultFlag = false;
                        Thread.Sleep(1000);
                        this.SendMsg("CONNECT" + str);

                        this.m_communication.StartDeviceListen();

                        if (this.m_Device.ExecQuery())
                        {
                            if (ClsResult.ResultFlag == true)
                            {
                                this.m_Device.ExecClose();

                                this.m_communication.WriteDataLog();
                                this.SendMsg("TRANSEND");
                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            this.m_communication.WriteDataLog();
                            this.SendMsg("ERROR");
                        }
                    }
                    else
                    {
                        this.m_Device.ExecClose();
                    }
                }
                else
                {
                    this.SendMsg("UNKNOWN" + str);
                }

                if (this.m_Device != null)
                {
                    if (ClsResult.ResultFlag == true)
                    {
                        Thread.Sleep(this.m_Device.m_delay);
                    }
                }
                else
                {
                    Thread.Sleep(3000);
                }

                this.m_communication.Disconnect();
                this.m_communication.StopHardListen();

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

        //public string GetDeviceName()
        //{
        //    BluetoothRadio BuleRadio = BluetoothRadio.PrimaryRadio;
        //    BuleRadio.Mode = RadioMode.Connectable;
        //    BluetoothDeviceInfo[] Devices = Blueclient.DiscoverDevices();

        //    foreach (BluetoothDeviceInfo device in Devices)
        //    {
        //        switch (device.DeviceName)
        //        {
        //            case "EMP-Ui":
        //                return "EMPUI";
        //            case "CHITBG":
        //                return "CHITBG";
        //            case "CHITBP":
        //                return "CHITBP";
        //            case "Fmd Human Scale":
        //                return "CHITBM";
        //            default:
        //                return "";
        //        }
        //    }

        //    return "";
        //}

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

        public string GetClsCommunicationBT(string com, int baudRate, string deviceName)
        {
            try
            {
                this.m_communicationBT = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                return deviceName;
            }
            catch (Exception e)
            {
                this.m_communicationBT = null;
            }

            return "";
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

        public string GetClsCommunication(string com, int baudRate, string deviceName)
        {
            try
            {
                this.m_communication = new ClsCommunicationCom(this.GetOs(), com, baudRate);

                return deviceName;
            }
            catch (Exception e)
            {
                this.m_communication = null;
            }

            return "";
        }
    }
}

