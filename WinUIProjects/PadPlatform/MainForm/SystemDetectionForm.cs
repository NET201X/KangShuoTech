using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using Utilities.BlueToothTools.MsBluetooth;

namespace KangShuo
{
    using NetFwTypeLib;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Management;
    using System.Net;
    using System.Net.Mail;
    using System.Net.NetworkInformation;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Timers;
    using System.Windows.Forms;

    public class SystemDetectionForm : Form
    {
        private Button btnHardware;
        private Button btnJumpBt;
        private Button btnNetPass;
        private Button btnNetwork;
        private Button btnPassCard;
        private Button btnRetryCard;
        private Button btnSetUp;
        private Button btnSkip;
        private Button btnUpdate;
        public AbsReadIDCardNo ck;
        private IContainer components;
        private Label lbCTV;
        private bool m_hasnewversion;
        private string m_IdCard;
        private int m_lastday;
        private int m_lastmonth;
        public double m_lastversion = 1.0;
        private int m_lastyear;
        private int m_step;
        public static string m_verion;
        private ProgressBar prgbarCard;
        private ProgressBar progressHard;
        private ProgressBar progressNet;
        private ProgressBar progressNewversion;
        private System.Timers.Timer t_update;
        private int t_upSeconds = 10;
        private Label label1;
        private System.Windows.Forms.Timer timer1;

        // 取得屏幕分辨率的宽高
        private int SW = Screen.PrimaryScreen.Bounds.Width;
        private Label label3;
        private Label lbCheckVersion;
        private Label lblCheckingNetwork;
        private Label lblCheckingHardware;
        private Label lbCard;
        private Label lblNewVersion;
        private Label lblNetworkOk;
        private Label lblHardwareOk;
        private int SH = Screen.PrimaryScreen.Bounds.Height;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemDetectionForm()
        {
            this.InitializeComponent();
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.timer1.Start();
            this.m_IdCard = ConfigHelper.GetNode("IdCardType");
            this.ck = new ReadIdentifyCardEx(ConfigHelper.GetNode("IdCardType"));
            //this.btnQuit.Visible = true;

            this.ClientSize = new Size(SW, SH);

        }

        /// <summary>
        /// 蓝牙设备重试事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHardware_Click(object sender, EventArgs e)
        {
            //this.timer1.Start();
        }

        /// <summary>
        /// 蓝牙设备跳过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJumpBt_Click(object sender, EventArgs e)
        {
            //this.progressHard.Value = 100;
            ////this.lblHardwareOk.Text = "跳过";
            //this.m_step = 1;
            //this.timer1.Start();
        }

        /// <summary>
        /// 网络连接跳过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNetPass_Click(object sender, EventArgs e)
        {
            //this.progressNet.Value = 100;
            ////this.lblNetworkOk.Text = "跳过";
            //this.m_step = 2;
            //this.timer1.Start();
        }

        /// <summary>
        /// 网络连接重试事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNetwork_Click(object sender, EventArgs e)
        {
            this.progressNet.Value = 0;
            this.timer1.Start();
        }

        /// <summary>
        /// 身份证读卡器检测跳过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPassCard_Click(object sender, EventArgs e)
        {
            this.prgbarCard.Value = 100;
            //this.lbCard.Text = "跳过";
            this.m_step = 4;
            this.timer1.Start();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 身份证读卡器检测重试事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetryCard_Click(object sender, EventArgs e)
        {
            this.prgbarCard.Value = 0;
            this.ck.FreeIdCard();
            this.ck = null;
            GC.Collect();
            this.ck = new ReadIdentifyCardEx(this.m_IdCard);
            this.CheckCard();
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetUp_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();

            ConfigurationForm up = new ConfigurationForm
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (up.ShowDialog() == DialogResult.OK)
            {
                this.m_step = 0;
            }

            this.timer1.Start();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            this.t_update.Stop();
            base.DialogResult = DialogResult.OK;
        }

        //private void btnUnReg_Click(object sender, EventArgs e)
        //{

        //}

        /// <summary>
        /// 升级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.t_update.Stop();
            this.StartProcess();
        }

        /// <summary>
        /// 检测身份证读卡器
        /// </summary>
        private void CheckCard()
        {
            this.lbCard.ForeColor = Color.Black;
            this.lbCard.Visible = true;
            this.lbCard.Text = "检测中";
            this.prgbarCard.Value = 25;
            Cursor.Current = Cursors.WaitCursor;

            if (!string.IsNullOrEmpty(this.m_IdCard))
            {
                int num;

                if (true)
                {
                    this.prgbarCard.Value = 100;
                    this.lbCard.Text = "通过";
                    this.m_step++;
                    this.timer1.Start();
                }
                else
                {
                    this.lbCard.ForeColor = Color.Red;
                    this.lbCard.Text = "失败:" + num;
                    this.btnRetryCard.Visible = true;
                    this.btnPassCard.Visible = true;
                }
            }

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 检测是否有最新版本
        /// </summary>
        private void CheckConfigItem()
        {
            //this.GetLocalVersion();
            //PadForm.formalOrTest = ConfigHelper.GetNode("vversion");

            //if ((ConfigHelper.GetNode("useLCD") == "1") && !string.IsNullOrEmpty(ConfigHelper.GetNode("comPort")))
            //{
            //    PadForm.ComVisiable = true;
            //}

            this.m_step++;
            this.timer1.Start();
        }

        private bool CheckHAArea()
        {
            string pValue = "";
            string villageName = "";
            string orgCode = "";
            string orgName = "";
            string doctor = "";
            string doctorName = "";
            string str7 = "";

            if (!ConfigHelper.GetNode("orgCode", ref orgCode))
            {
                ConfigHelper.GetNode("VillageHB", ref orgCode);
            }

            if (!ConfigHelper.GetNode("orgName", ref orgName))
            {
                ConfigHelper.GetNode("VillageHB_NAME", ref orgName);
            }

            ConfigHelper.GetNode("TownName", ref pValue);
            ConfigHelper.GetNode("VillageName", ref villageName);
            ConfigHelper.GetNode("doctor", ref doctor);
            ConfigHelper.GetNode("doctorName", ref doctorName);
            ConfigHelper.GetNode("archiveid", ref str7);

            LocationSelectionForm aex = new LocationSelectionForm
            {
                areaOrg = { OrgCode = orgCode, OrgName = orgName, VillageName = villageName, TownName = pValue, doctor = doctor, doctorName = doctorName, archiveid = str7 },
                StartPosition = FormStartPosition.CenterScreen
            };

            if (aex.ShowDialog() == DialogResult.OK)
            {
                //pictureBox1.BackgroundImage = global::KangShuo.Properties.Resources._2秒;
                pValue = aex.areaOrg.TownName;
                orgCode = aex.areaOrg.OrgCode;
                orgName = aex.areaOrg.OrgName;
                villageName = aex.areaOrg.VillageName;
                doctor = aex.areaOrg.doctor;
                doctorName = aex.areaOrg.doctorName;
                string archiveid = aex.areaOrg.archiveid;

                if (!string.IsNullOrEmpty(pValue))
                {
                    ConfigHelper.WriteNode("TownName", pValue);
                }

                if (!string.IsNullOrEmpty(villageName))
                {
                    ConfigHelper.WriteNode("VillageName", villageName);
                }

                if (!string.IsNullOrEmpty(orgCode))
                {
                    ConfigHelper.WriteNode("orgCode", orgCode);
                }

                if (!string.IsNullOrEmpty(orgName))
                {
                    ConfigHelper.WriteNode("orgName", orgName);
                }

                if (!string.IsNullOrEmpty(doctor))
                {
                    ConfigHelper.WriteNode("doctor", doctor);
                }

                if (!string.IsNullOrEmpty(doctorName))
                {
                    ConfigHelper.WriteNode("doctorName", doctorName);
                }

                if (!string.IsNullOrEmpty(archiveid))
                {
                    ConfigHelper.WriteNode("archiveid", archiveid);
                }
            }

            return true;
        }

        /// <summary>
        /// 检测蓝牙设备
        /// </summary>
        /// <returns></returns>
        private bool CheckHardWare()
        {
            this.lblHardwareOk.Visible = true;
            this.lblHardwareOk.Text = "检测中";
            this.progressHard.Value = 25;
            Thread.Sleep(1000);

            try
            {
                if (NativeMethods.GetRadioHandlesCount() > 0)
                {
                    this.progressHard.Value = 100;
                    this.lblHardwareOk.Text = "通过";
                    this.m_step++;
                    this.timer1.Start();
                }
                else
                {
                    this.progressHard.Value = 0;
                    this.lblHardwareOk.ForeColor = Color.Red;
                    this.lblHardwareOk.Text = "未通过";
                    this.btnHardware.Visible = true;
                }
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                new MessageForm("当前蓝牙设备异常！请重置蓝牙蓝牙适配器") { StartPosition = FormStartPosition.CenterScreen }.ShowDialog();
                Environment.Exit(0);
            }

            this.GetPrinterStatus();

            return true;
        }

        private bool CheckIsUpdate()
        {
            return true;
        }

        private bool CheckNet()
        {
            this.lblNetworkOk.ForeColor = Color.Black;
            this.lblNetworkOk.Visible = true;
            this.lblNetworkOk.Text = "检测中";
            this.progressNet.Value = 25;
            Thread.Sleep(1000);
            if (this.GetServerInfo() != "false")
            {
                this.progressNet.Value = 100;
                this.lblNetworkOk.Text = "通过";
                PadForm.netStatus = "1";
                this.m_step++;
                this.timer1.Start();
            }
            else
            {
                this.progressNet.Value = 0;
                this.lblNetworkOk.ForeColor = Color.Red;
                this.lblNetworkOk.Text = "无网络连接";
                this.btnNetwork.Visible = true;
                this.btnNetPass.Visible = true;
            }

            this.progressNet.Value = 100;
            this.lblNetworkOk.Text = "通过";
            PadForm.netStatus = "1";
            this.m_step++;
            this.timer1.Start();
            return true;
        }

        private bool CheckNewVersion()
        {
            return true;
        }

        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                //case 0x595:
                //    this.prgbarCard.Value = 100;
                //    this.lbCard.Text = "通过";
                //    this.m_step++;
                //    this.timer1.Start();
                //    return;

                //case 0x596:
                //    this.lbCard.ForeColor = Color.Red;
                //    this.lbCard.Text = "失败";
                //    this.btnRetryCard.Visible = true;
                //    this.btnPassCard.Visible = true;
                //    return;
            }
            base.DefWndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Download(string ftp, string username, string password, string filePath, string fileName)
        {
            try
            {
                FileStream stream = new FileStream(filePath + @"\" + fileName, FileMode.Create);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftp + "/" + fileName));
                request.Method = "RETR";
                request.UseBinary = true;
                request.KeepAlive = false;
                request.Credentials = new NetworkCredential(username, password);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                long contentLength = response.ContentLength;
                int count = 0x800;
                byte[] buffer = new byte[count];
                for (int i = responseStream.Read(buffer, 0, count); i > 0; i = responseStream.Read(buffer, 0, count))
                {
                    stream.Write(buffer, 0, i);
                }
                responseStream.Close();
                stream.Close();
                response.Close();
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
            }
            GC.Collect();
        }

        private void FrmDiagnostics_Load(object sender, EventArgs e)
        {
        }

        public string[] Getdevice()
        {
            new StringBuilder();
            List<string> list = new List<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");
            foreach (ManagementObject obj2 in searcher.Get())
            {
                try
                {
                    if (Convert.ToString(obj2["Name"]).ToUpper().IndexOf("CH340") >= 0)
                    {
                        Convert.ToString(obj2["Name"]);
                        foreach (Capture capture in new Regex(@"\((.*)\)").Matches(Convert.ToString(obj2["Name"])))
                        {
                            string item = Regex.Replace(capture.Value, @"\(|\)", "");
                            if (item.IndexOf("COM") >= 0)
                            {
                                list.Add(item);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    LogHelper.LogError(exception);
                }
            }
            string[] strArray = (list.Count != 0) ? list.ToArray() : new string[0];
            searcher.Dispose();
            return strArray;
        }

        public string[] GetFileList(string ftp, string username, string password)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftp));
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(username, password);
                request.Method = "NLST";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                for (string str = reader.ReadLine(); str != null; str = reader.ReadLine())
                {
                    builder.Append(str);
                    builder.Append("\n");
                }
                builder.Remove(builder.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return builder.ToString().Split(new char[] { '\n' });
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        /// <summary>
        /// 取得当前版本号
        /// </summary>
        private void GetLocalVersion()
        {
            using (StreamReader reader = new StreamReader(Application.StartupPath + @"\versioninfo.txt"))
            {
                string str = "";

                while (!reader.EndOfStream)
                {
                    str = reader.ReadLine();
                }

                if (!string.IsNullOrEmpty(str))
                {
                    PadForm.SoftVersion = str;
                }
            }
        }

        /// <summary>
        /// 取得打印机状态
        /// </summary>
        private void GetPrinterStatus()
        {
            bool flag = false;
            ManagementObjectCollection instances = new ManagementClass("Win32_PnPEntity").GetInstances();

            try
            {
                foreach (ManagementObject obj2 in instances)
                {
                    if (obj2["Caption"].ToString().Contains("POS/Pad Printers"))
                    {
                        flag = true;
                        //PadForm.PrinterPNPDeviceID = (obj2.Properties["PNPDeviceID"].Value == null) ? "NULL \r\n" : obj2.Properties["PNPDeviceID"].Value.ToString();
                        object obj3 = obj2["ConfigManagerErrorCode"];

                        if ((obj3 == null) || !(obj3.ToString() != "0"))
                        {
                            goto Label_00FF;
                        }

                        PadForm.printerStatus = PrinterStatus.ER;

                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                PadForm.printerStatus = PrinterStatus.OFF;
                ErrorLog.WriterLog("获取打印机状态错误:" + exception.Message + "\r\n" + exception.StackTrace);
                LogHelper.LogError(exception);
            }
        Label_00FF:
            if (!flag)
            {
                PadForm.printerStatus = PrinterStatus.OFF;
            }
            else
            {
                PadForm.printerStatus = PrinterStatus.ON;
            }
        }

        private string GetServerInfo()
        {
            string str = "";
            ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
            string str2 = "";
            Ping ping = new Ping();
            try
            {
                if (ping.Send("www.baidu.com").Status == IPStatus.Success)
                {
                    new Thread(new ThreadStart(this.SendBugMail)) { IsBackground = true }.Start();
                    return "true";
                }
            }
            catch (Exception exception)
            {
                str2 = "false";
                LogHelper.LogInfo("ping www.baidu.com");
                LogHelper.LogError(exception);
            }
            foreach (ManagementObject obj2 in instances)
            {
                if (Convert.ToBoolean(obj2["ipEnabled"]))
                {
                    obj2["Caption"].ToString();
                    string[] strArray = obj2["DefaultIPGateway"] as string[];
                    if (strArray != null)
                    {
                        str = strArray[0];
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(str))
            {
                str2 = "false";
            }
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                str2 = "false";
            }
            try
            {
                if (!string.IsNullOrEmpty(str) && (ping.Send(str).Status != IPStatus.Success))
                {
                    str2 = "false";
                }
            }
            catch (Exception exception2)
            {
                str2 = "false";
                LogHelper.LogError(exception2);
            }
            return str2;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemDetectionForm));
            this.btnNetwork = new System.Windows.Forms.Button();
            this.btnHardware = new System.Windows.Forms.Button();
            this.progressHard = new System.Windows.Forms.ProgressBar();
            this.progressNet = new System.Windows.Forms.ProgressBar();
            this.progressNewversion = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSetUp = new System.Windows.Forms.Button();
            this.lbCTV = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnPassCard = new System.Windows.Forms.Button();
            this.btnRetryCard = new System.Windows.Forms.Button();
            this.prgbarCard = new System.Windows.Forms.ProgressBar();
            this.btnNetPass = new System.Windows.Forms.Button();
            this.btnJumpBt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCheckVersion = new System.Windows.Forms.Label();
            this.lblCheckingNetwork = new System.Windows.Forms.Label();
            this.lblCheckingHardware = new System.Windows.Forms.Label();
            this.lbCard = new System.Windows.Forms.Label();
            this.lblNewVersion = new System.Windows.Forms.Label();
            this.lblNetworkOk = new System.Windows.Forms.Label();
            this.lblHardwareOk = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNetwork
            // 
            this.btnNetwork.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNetwork.Location = new System.Drawing.Point(847, 288);
            this.btnNetwork.Name = "btnNetwork";
            this.btnNetwork.Size = new System.Drawing.Size(75, 26);
            this.btnNetwork.TabIndex = 30;
            this.btnNetwork.Text = "重 试";
            this.btnNetwork.UseVisualStyleBackColor = true;
            this.btnNetwork.Visible = false;
            this.btnNetwork.Click += new System.EventHandler(this.btnNetwork_Click);
            // 
            // btnHardware
            // 
            this.btnHardware.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHardware.Location = new System.Drawing.Point(847, 244);
            this.btnHardware.Name = "btnHardware";
            this.btnHardware.Size = new System.Drawing.Size(75, 26);
            this.btnHardware.TabIndex = 29;
            this.btnHardware.Text = "重 试";
            this.btnHardware.UseVisualStyleBackColor = true;
            this.btnHardware.Visible = false;
            this.btnHardware.Click += new System.EventHandler(this.btnHardware_Click);
            // 
            // progressHard
            // 
            this.progressHard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressHard.Location = new System.Drawing.Point(532, 243);
            this.progressHard.Name = "progressHard";
            this.progressHard.Size = new System.Drawing.Size(210, 21);
            this.progressHard.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressHard.TabIndex = 27;
            // 
            // progressNet
            // 
            this.progressNet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressNet.Location = new System.Drawing.Point(532, 287);
            this.progressNet.Name = "progressNet";
            this.progressNet.Size = new System.Drawing.Size(210, 21);
            this.progressNet.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressNet.TabIndex = 35;
            // 
            // progressNewversion
            // 
            this.progressNewversion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressNewversion.Location = new System.Drawing.Point(532, 377);
            this.progressNewversion.Name = "progressNewversion";
            this.progressNewversion.Size = new System.Drawing.Size(210, 21);
            this.progressNewversion.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressNewversion.TabIndex = 36;
            this.progressNewversion.Visible = false;
            // 
            // btnSetUp
            // 
            this.btnSetUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetUp.Location = new System.Drawing.Point(1006, 695);
            this.btnSetUp.Name = "btnSetUp";
            this.btnSetUp.Size = new System.Drawing.Size(85, 55);
            this.btnSetUp.TabIndex = 39;
            this.btnSetUp.Text = "配 置";
            this.btnSetUp.UseVisualStyleBackColor = true;
            this.btnSetUp.Visible = false;
            this.btnSetUp.Click += new System.EventHandler(this.btnSetUp_Click);
            // 
            // lbCTV
            // 
            this.lbCTV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCTV.AutoSize = true;
            this.lbCTV.BackColor = System.Drawing.Color.Transparent;
            this.lbCTV.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCTV.Location = new System.Drawing.Point(12, 747);
            this.lbCTV.Name = "lbCTV";
            this.lbCTV.Size = new System.Drawing.Size(164, 21);
            this.lbCTV.TabIndex = 40;
            this.lbCTV.Text = "              ";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.Location = new System.Drawing.Point(847, 374);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 26);
            this.btnUpdate.TabIndex = 41;
            this.btnUpdate.Text = "升 级";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSkip.Location = new System.Drawing.Point(928, 374);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 26);
            this.btnSkip.TabIndex = 42;
            this.btnSkip.Text = "跳 过";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Visible = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnPassCard
            // 
            this.btnPassCard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPassCard.Location = new System.Drawing.Point(928, 330);
            this.btnPassCard.Name = "btnPassCard";
            this.btnPassCard.Size = new System.Drawing.Size(75, 26);
            this.btnPassCard.TabIndex = 47;
            this.btnPassCard.Text = "跳 过";
            this.btnPassCard.UseVisualStyleBackColor = true;
            this.btnPassCard.Visible = false;
            this.btnPassCard.Click += new System.EventHandler(this.btnPassCard_Click);
            // 
            // btnRetryCard
            // 
            this.btnRetryCard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRetryCard.Location = new System.Drawing.Point(847, 330);
            this.btnRetryCard.Name = "btnRetryCard";
            this.btnRetryCard.Size = new System.Drawing.Size(75, 26);
            this.btnRetryCard.TabIndex = 46;
            this.btnRetryCard.Text = "重 试";
            this.btnRetryCard.UseVisualStyleBackColor = true;
            this.btnRetryCard.Visible = false;
            this.btnRetryCard.Click += new System.EventHandler(this.btnRetryCard_Click);
            // 
            // prgbarCard
            // 
            this.prgbarCard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.prgbarCard.Location = new System.Drawing.Point(532, 333);
            this.prgbarCard.Name = "prgbarCard";
            this.prgbarCard.Size = new System.Drawing.Size(210, 21);
            this.prgbarCard.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgbarCard.TabIndex = 45;
            // 
            // btnNetPass
            // 
            this.btnNetPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNetPass.Location = new System.Drawing.Point(928, 288);
            this.btnNetPass.Name = "btnNetPass";
            this.btnNetPass.Size = new System.Drawing.Size(75, 26);
            this.btnNetPass.TabIndex = 48;
            this.btnNetPass.Text = "跳 过";
            this.btnNetPass.UseVisualStyleBackColor = true;
            this.btnNetPass.Visible = false;
            this.btnNetPass.Click += new System.EventHandler(this.btnNetPass_Click);
            // 
            // btnJumpBt
            // 
            this.btnJumpBt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnJumpBt.Location = new System.Drawing.Point(928, 244);
            this.btnJumpBt.Name = "btnJumpBt";
            this.btnJumpBt.Size = new System.Drawing.Size(75, 26);
            this.btnJumpBt.TabIndex = 49;
            this.btnJumpBt.Text = "跳 过";
            this.btnJumpBt.UseVisualStyleBackColor = true;
            this.btnJumpBt.Visible = false;
            this.btnJumpBt.Click += new System.EventHandler(this.btnJumpBt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(319, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 75);
            this.label1.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(348, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 92;
            this.label3.Text = "身份证读卡器检测";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCheckVersion
            // 
            this.lbCheckVersion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbCheckVersion.AutoSize = true;
            this.lbCheckVersion.BackColor = System.Drawing.Color.Transparent;
            this.lbCheckVersion.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCheckVersion.Location = new System.Drawing.Point(348, 373);
            this.lbCheckVersion.Name = "lbCheckVersion";
            this.lbCheckVersion.Size = new System.Drawing.Size(164, 25);
            this.lbCheckVersion.TabIndex = 91;
            this.lbCheckVersion.Text = "检测是否有新版本";
            this.lbCheckVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCheckVersion.Visible = false;
            // 
            // lblCheckingNetwork
            // 
            this.lblCheckingNetwork.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCheckingNetwork.AutoSize = true;
            this.lblCheckingNetwork.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckingNetwork.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckingNetwork.Location = new System.Drawing.Point(386, 283);
            this.lblCheckingNetwork.Name = "lblCheckingNetwork";
            this.lblCheckingNetwork.Size = new System.Drawing.Size(126, 25);
            this.lblCheckingNetwork.TabIndex = 90;
            this.lblCheckingNetwork.Text = "网络连接检测";
            this.lblCheckingNetwork.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCheckingHardware
            // 
            this.lblCheckingHardware.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCheckingHardware.AutoSize = true;
            this.lblCheckingHardware.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckingHardware.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckingHardware.Location = new System.Drawing.Point(386, 241);
            this.lblCheckingHardware.Name = "lblCheckingHardware";
            this.lblCheckingHardware.Size = new System.Drawing.Size(126, 25);
            this.lblCheckingHardware.TabIndex = 89;
            this.lblCheckingHardware.Text = "蓝牙设备检测";
            this.lblCheckingHardware.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCard
            // 
            this.lbCard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbCard.AutoSize = true;
            this.lbCard.BackColor = System.Drawing.Color.Transparent;
            this.lbCard.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCard.Location = new System.Drawing.Point(759, 329);
            this.lbCard.Name = "lbCard";
            this.lbCard.Size = new System.Drawing.Size(69, 25);
            this.lbCard.TabIndex = 96;
            this.lbCard.Text = "检测中";
            this.lbCard.Visible = false;
            // 
            // lblNewVersion
            // 
            this.lblNewVersion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNewVersion.AutoSize = true;
            this.lblNewVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblNewVersion.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNewVersion.Location = new System.Drawing.Point(759, 373);
            this.lblNewVersion.Name = "lblNewVersion";
            this.lblNewVersion.Size = new System.Drawing.Size(69, 25);
            this.lblNewVersion.TabIndex = 95;
            this.lblNewVersion.Text = "检测中";
            this.lblNewVersion.Visible = false;
            // 
            // lblNetworkOk
            // 
            this.lblNetworkOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNetworkOk.AutoSize = true;
            this.lblNetworkOk.BackColor = System.Drawing.Color.Transparent;
            this.lblNetworkOk.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNetworkOk.Location = new System.Drawing.Point(759, 287);
            this.lblNetworkOk.Name = "lblNetworkOk";
            this.lblNetworkOk.Size = new System.Drawing.Size(69, 25);
            this.lblNetworkOk.TabIndex = 94;
            this.lblNetworkOk.Text = "检测中";
            this.lblNetworkOk.Visible = false;
            // 
            // lblHardwareOk
            // 
            this.lblHardwareOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHardwareOk.AutoSize = true;
            this.lblHardwareOk.BackColor = System.Drawing.Color.Transparent;
            this.lblHardwareOk.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHardwareOk.ForeColor = System.Drawing.Color.Black;
            this.lblHardwareOk.Location = new System.Drawing.Point(759, 243);
            this.lblHardwareOk.Name = "lblHardwareOk";
            this.lblHardwareOk.Size = new System.Drawing.Size(69, 25);
            this.lblHardwareOk.TabIndex = 93;
            this.lblHardwareOk.Text = "检测中";
            this.lblHardwareOk.Visible = false;
            // 
            // SystemDetectionForm
            // 
            this.BackgroundImage = global::KangShuo.Properties.Resources.loginbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 741);
            this.Controls.Add(this.lbCard);
            this.Controls.Add(this.lblNewVersion);
            this.Controls.Add(this.lblNetworkOk);
            this.Controls.Add(this.lblHardwareOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCheckVersion);
            this.Controls.Add(this.lblCheckingNetwork);
            this.Controls.Add(this.lblCheckingHardware);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnJumpBt);
            this.Controls.Add(this.btnNetPass);
            this.Controls.Add(this.btnPassCard);
            this.Controls.Add(this.btnRetryCard);
            this.Controls.Add(this.prgbarCard);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lbCTV);
            this.Controls.Add(this.btnSetUp);
            this.Controls.Add(this.progressNewversion);
            this.Controls.Add(this.progressNet);
            this.Controls.Add(this.btnNetwork);
            this.Controls.Add(this.btnHardware);
            this.Controls.Add(this.progressHard);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SystemDetectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "硕康智能体检系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDiagnostics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
        }

        private void LoadLastUpdateDate()
        {
            ErrorLog.WriterLog("开始进行远程升级");
            string executablePath = Application.ExecutablePath;
            int num = executablePath.LastIndexOf(@"\");
            string str2 = executablePath.Substring(0, num + 1);
            if (!System.IO.File.Exists(str2 + "versioninfo.txt"))
            {
                ErrorLog.WriterLog("未找到本地版本文件versioninfo.txt");
                StreamWriter writer = new StreamWriter(new FileStream(str2 + "versioninfo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.Default);
                writer.Write("0\r\n");
                writer.Write("0\r\n");
                writer.Write("0\r\n");
                writer.Write("1\r\n");
                writer.Flush();
                writer.Close();
            }
            else
            {
                StreamReader reader = new StreamReader(str2 + "versioninfo.txt");
                if (!reader.EndOfStream)
                {
                    string str3 = reader.ReadLine();
                    if (str3 != "")
                    {
                        this.m_lastyear = Convert.ToInt32(str3);
                    }
                }
                if (!reader.EndOfStream)
                {
                    string str4 = reader.ReadLine();
                    if (str4 != "")
                    {
                        this.m_lastmonth = Convert.ToInt32(str4);
                    }
                }
                if (!reader.EndOfStream)
                {
                    string str5 = reader.ReadLine();
                    if (str5 != "")
                    {
                        this.m_lastday = Convert.ToInt32(str5);
                    }
                }
                if (!reader.EndOfStream)
                {
                    string str6 = reader.ReadLine();
                    m_verion = str6;
                    ErrorLog.WriterLog("本地版本号为:" + str6);
                    if (str6 != "")
                    {
                        this.m_lastversion = Convert.ToDouble(str6);
                        if (!double.TryParse(str6, out this.m_lastversion))
                        {
                            MessageBox.Show("本地版本号错误：" + str6, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }
                }
                reader.Close();
            }
            if (!Directory.Exists(str2 + "update"))
            {
                ErrorLog.WriterLog("CreateDirectory update");
                Directory.CreateDirectory(str2 + "update");
            }
            string str7 = this.readerFtp("ftp://" + DataSender.m_FtpIP, DataSender.m_FtpUser, DataSender.m_FtpPass);
            if ((str7 != "error") && (str7.Length >= 12))
            {
                double num2;
                string s = str7.Substring(7, str7.Length - 11);
                if (!double.TryParse(s, out num2))
                {
                    MessageBox.Show("远程版本号错误：" + s, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                ErrorLog.WriterLog("远程版本号为:" + s);
                if ((num2 - this.m_lastversion) > 1E-05)
                {
                    //this.lbCheckVersion.Text = "检测到新版本:" + num2;
                    this.btnUpdate.Visible = true;
                    this.btnSkip.Visible = true;
                    this.m_hasnewversion = true;
                    this.m_lastversion = num2;
                    if (!Directory.Exists(Application.StartupPath + @"\update"))
                    {
                        Directory.CreateDirectory(Application.StartupPath + @"\update");
                    }
                    foreach (string str9 in this.GetFileList("ftp://" + DataSender.m_FtpIP, DataSender.m_FtpUser, DataSender.m_FtpPass))
                    {
                        if (str9.StartsWith("vPadUpdate"))
                        {
                            ErrorLog.WriterLog("正在下载:" + str9 + "\r\n");
                            this.Download("ftp://" + DataSender.m_FtpIP, DataSender.m_FtpUser, DataSender.m_FtpPass, str2 + "update", str9);
                            GC.Collect();
                        }
                    }
                    if (System.IO.File.Exists(Application.StartupPath + @"\update\vPadUpdate.exe"))
                    {
                        System.IO.File.Copy(Application.StartupPath + @"\update\vPadUpdate.exe", Application.StartupPath + @"\PadUpdate.exe", true);
                        GC.Collect();
                        System.IO.File.Delete(Application.StartupPath + @"\update\vPadUpdate.exe");
                    }
                }
                else
                {
                    //this.lblNewVersion.Text = "无新版本,目前已是最新版";
                    //this.lblNewVersion.Refresh();
                }
            }
            else
            {
                try
                {
                    this.setFirewallAndDns();
                }
                catch (Exception exception)
                {
                    LogHelper.LogError(exception);
                }
                //this.lblNewVersion.Text = "远程更新服务暂时不可用,下次程序启动更新";
                //this.lblNewVersion.Refresh();
            }
            Thread.Sleep(0x7d0);
        }

        private string readerFtp(string ftp, string username, string password)
        {
            string str = "no files";
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftp));
                request.UsePassive = false;
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(username, password);
                request.Method = "NLST";
                StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.GetEncoding("gb2312"));
                for (string str2 = reader.ReadLine(); str2 != null; str2 = reader.ReadLine())
                {
                    if (str2.EndsWith(".txt") && str2.StartsWith("version"))
                    {
                        string str3 = str2;
                        reader.Close();
                        return str3;
                    }
                }
                reader.Close();
                return str;
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                return "error";
            }
        }

        private void SendBugMail()
        {
            SystemErrorLogBLL report = new SystemErrorLogBLL();
            report.CheckTable("SYS_ERROR_LOG");
            List<SystemErrorLogModel> modelList = report.GetModelList(" SENDED = '0' ");
            if (modelList.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("组织机构:" + ConfigHelper.GetNode("orgName") + " 编号:" + ConfigHelper.GetNode("orgCode") + "\r\n");
                LogHelper.LogInfo("发送错误日志：" + modelList.Count);

                foreach (SystemErrorLogModel report2 in modelList)
                {
                    builder.Append((report2.CreateDate.ToString()) + ":\r\n");
                    builder.Append("Info:\r\n  " + report2.LogData + "\r\n");
                    builder.Append("Message:\r\n  " + report2.Message + "\r\n");
                    builder.Append("StackTrace:\r\n  " + report2.StackTrace + "\r\n");
                    builder.Append("TargetSite:\r\n  " + report2.TargetSite + "\r\n");
                    builder.Append("-----------------------------------------------------------------------------s\r\n ");
                    report2.SendEd = "1";
                }
                MailAddress address = new MailAddress("qinchengtech@163.com", "PAD_" + ConfigHelper.GetNode("orgName"));
                MailMessage message = new MailMessage
                {
                    Subject = "错误报告",
                    From = address
                };
                string str = "menglingwei@qinchengkeji.com";
                string displayName = "menglingwei";
                message.To.Add(new MailAddress(str, displayName));
                message.Body = builder.ToString();
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                new SmtpClient { Host = "smtp.163.com ", UseDefaultCredentials = false, 
                    Credentials = new NetworkCredential("qinchengtech", "qincheng850706"), 
                    DeliveryMethod = SmtpDeliveryMethod.Network }.Send(message);
                foreach (SystemErrorLogModel report3 in modelList)
                {
                    report.Update(report3);
                }
            }
        }

        private void SetControlText(Control ctr, string text)
        {
            Action<Control, string> method = new Action<Control, string>(this.SetControlText);

            if (ctr.InvokeRequired)
            {
                ctr.Invoke(method, new object[] { ctr, text });
            }
            else
            {
                ctr.Text = text;
            }
        }

        private void setFirewallAndDns()
        {
            INetFwMgr mgr = (INetFwMgr)Activator.CreateInstance(System.Type.GetTypeFromProgID("HNetCfg.FwMgr"));
            INetFwAuthorizedApplication app = (INetFwAuthorizedApplication)Activator.CreateInstance(System.Type.GetTypeFromProgID("HNetCfg.FwAuthorizedApplication"));
            app.Name = "公共卫生采集系统";
            app.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
            app.IpVersion = NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;
            app.ProcessImageFileName = Application.ExecutablePath;
            app.Enabled = true;
            INetFwAuthorizedApplication application2 = (INetFwAuthorizedApplication)Activator.CreateInstance(System.Type.GetTypeFromProgID("HNetCfg.FwAuthorizedApplication"));
            application2.Name = "公共卫生采集系统升级程序";
            application2.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
            application2.IpVersion = NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;
            application2.ProcessImageFileName = Application.StartupPath + @"\KioskUpdate.exe";
            application2.Enabled = true;
            mgr.LocalPolicy.CurrentProfile.AuthorizedApplications.Add(app);
            mgr.LocalPolicy.CurrentProfile.AuthorizedApplications.Add(application2);
            LogHelper.LogInfo("重新添加当前网络状态下的防火墙策略");
            foreach (ManagementObject obj2 in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                if ((bool)obj2["IPEnabled"])
                {
                    ManagementBaseObject methodParameters = obj2.GetMethodParameters("SetDNSServerSearchOrder");
                    methodParameters["DNSServerSearchOrder"] = new string[] { "114.114.114.114", "114.114.115.115" };
                    obj2.InvokeMethod("SetDNSServerSearchOrder", methodParameters, null);
                    break;
                }
            }
            LogHelper.LogInfo("重新设置当前网络状态下的dns服务器");
        }

        private void SetLabel2Text(string txt)
        {
            //Action<string> method = new Action<string>(this.SetLabel2Text);
            //if (this.lblNewVersion.InvokeRequired)
            //{
            //    this.lblNewVersion.Invoke(method, new object[] { txt });
            //}
            //else
            //{
            //    this.lblNewVersion.Visible = true;
            //    this.lblNewVersion.Text = txt;
            //}
        }

        private void StartProcess()
        {
            if (new RecordsBaseInfoBLL().GetRecordCount(" and IsUpdate = 'Y' ") > 0)
            {
                MessageBox.Show("检测到未上传的数据，请先进行数据上传然后再进行软件的升级!", "升级", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                new Process { StartInfo = { FileName = Application.StartupPath + @"\PadUpdate.exe", Arguments = "softUpdate " + this.m_lastversion.ToString() } }.Start();
                base.DialogResult = DialogResult.Cancel;
            }
        }

        private void t_update_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.SetControlText(this.btnSkip, string.Format("跳过({0})", this.t_upSeconds));
            if (this.t_upSeconds == 0)
            {
                this.t_update.Stop();
                this.t_update.Dispose();
                this.btnSkip_Click(null, null);
            }
            this.t_upSeconds--;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            switch (this.m_step)
            {
                case 0:
                    try
                    {
                        if (string.IsNullOrEmpty(ConfigHelper.GetNode("fsset")))
                        {
                            ConfigHelper.WriteNode("fsset", "11111110");
                        }
                        //GlbTools.CheckDB();
                    }
                    catch (Exception exception)
                    {
                        LogHelper.LogError(exception);
                        MessageBox.Show(exception.Message);
                    }
                    this.CheckHAArea();
                    this.CheckHardWare();
                    return;

                case 1:
                    this.CheckNet();
                    return;
                case 2:
                    this.CheckConfigItem();
                    return;
                case 3:
                    this.CheckCard();
                    return;
                case 4:
                    base.DialogResult = DialogResult.OK;
                    return;
            }
        }
    }
}

