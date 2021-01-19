
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;

namespace KangShuo
{
    public class LoginForm : Form
    {
        private System.Timers.Timer autoTimer;
        private SimpleBindingManager<AreaOrg> bindingManager;
        private Button btnCancel;
        private Button btnLogin;
        private CheckBox ckAutolog;
        private IContainer components;
        private string ftp;
        private bool goClose;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lbLogInfo;
        private LinkLabel linkLatestVersion;
        private LinkLabel linkSetup;
        private bool m_hasnewversion;
        private int m_lastday;
        private int m_lastmonth;
        public double m_lastversion = 1.0;
        private int m_lastyear;
        public static string m_verion;
        private MaskedTextBox mtbArchiveID;
        private MaskedTextBox mtbHBDep;
        private Panel panel1;
        private PictureBox picBT;
        private PictureBox picNetWork;
        private PictureBox picReadCard;
        private string pwd;
        private int seconds = 5;
        private TextBox tbID;
        private TextBox tbName;
        private TextBox tbTownName;
        private TextBox tbVillageHB_NAME;
        private TextBox tbVillageName;
        private string user;

        public LoginForm()
        {
            this.InitializeComponent();
            this.areaOrg = new AreaOrg();
            this.inputRanges = new List<InputRangeDec>();
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("DepHB", "^[0-9]*$"));
            this.inputrange_str.Add(new InputRangeStr("CityHB", "^[0-9]*$"));
            this.inputrange_str.Add(new InputRangeStr("CountyHB", "^[0-9]*$"));
            this.inputrange_str.Add(new InputRangeStr("TownHB", "^[0-9]*$"));
            this.inputrange_str.Add(new InputRangeStr("VillageName", 0x20));
            this.inputrange_str.Add(new InputRangeStr("TownName", 0x20));
            this.inputrange_str.Add(new InputRangeStr("doctor", "^[0-9]*$"));
            this.inputrange_str.Add(new InputRangeStr("doctorName", 0x20));
        }

        private void autoTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.seconds == 0)
            {
                this.btnLogin_Click(null, null);
            }
            else
            {
                this.lbLogInfo.Text = string.Format("{0}秒后自动登录......", this.seconds);
            }
            this.seconds--;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.autoTimer != null)
            {
                this.autoTimer.Stop();
            }
            this.goClose = true;
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.autoTimer != null)
            {
                this.autoTimer.Stop();
            }
            if (!this.bindingManager.ErrorInput)
            {
                if (!this.mtbArchiveID.MaskCompleted)
                {
                    MessageBox.Show("行政区域编号输入不正确！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!this.mtbHBDep.MaskCompleted)
                {
                    MessageBox.Show("所属组织机构编号输入不正确！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrEmpty(this.tbID.Text.Trim()))
                {
                    MessageBox.Show("医生ID不能为空！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrEmpty(this.tbName.Text.Trim()))
                {
                    MessageBox.Show("医生姓名不能为空！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.goClose = true;
                    new Process { StartInfo = { FileName = Application.StartupPath + @"\KangShuoTech.exe" } }.Start();
                    base.Close();
                }
            }
        }

        private void ckAutolog_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckAutolog.Checked)
            {
                this.tbName.ReadOnly = true;
                this.tbID.ReadOnly = true;
            }
            else
            {
                this.tbName.ReadOnly = false;
                this.tbID.ReadOnly = false;
                this.autoTimer.Stop();
            }
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
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(ftp + "/" + fileName));
                request.Method = "RETR";
                request.UseBinary = true;
                request.KeepAlive = false;
                request.Credentials = new NetworkCredential(username, password);
                FtpWebResponse response = (FtpWebResponse) request.GetResponse();
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
        }

        private void EnvironmentCheck()
        {
            this.GetLocalVersion();
            if (!this.InitReadCard())
            {
                //this.picReadCard.Image = new Image();
            }
            if (!this.GetServerInfo())
            {
                
                //this.picNetWork.ImageLocation = @"../Resources/";
            }
            this.GetNewVersion();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.goClose)
            {
                e.Cancel = true;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.areaOrg.VillageHB = ConfigHelper.GetNode("VillageHB");
            this.areaOrg.OrgName = ConfigHelper.GetNode("VillageHB_NAME");
            this.areaOrg.TownName = ConfigHelper.GetNode("TownName");
            this.areaOrg.VillageName = ConfigHelper.GetNode("VillageName");
            this.areaOrg.doctor = ConfigHelper.GetNode("doctor");
            this.areaOrg.doctorName = ConfigHelper.GetNode("doctorName");
            this.areaOrg.archiveid = ConfigHelper.GetNode("archiveid");
            this.bindingManager = new SimpleBindingManager<AreaOrg>(this.inputRanges, this.inputrange_str, this.areaOrg);
            this.bindingManager.SimpleBinding(this.tbTownName, "TownName", false);
            this.bindingManager.SimpleBinding(this.tbVillageName, "VillageName", false);
            this.bindingManager.SimpleBinding(this.tbVillageHB_NAME, "VillageHB_NAME", false);
            this.bindingManager.SimpleBinding(this.mtbHBDep, "VillageHB", false);
            this.bindingManager.SimpleBinding(this.tbID, "doctor", false);
            this.bindingManager.SimpleBinding(this.tbName, "doctorName", false);
            this.bindingManager.SimpleBinding(this.mtbArchiveID, "archiveid", false);
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string str = "0";
            if (configuration.AppSettings.Settings["AutoLogin"] == null)
            {
                configuration.AppSettings.Settings.Add("AutoLogin", str);
                configuration.Save();
            }
            else
            {
                str = configuration.AppSettings.Settings["AutoLogin"].Value;
            }
            string node = ConfigHelper.GetNode("doctorName");
            string str3 = ConfigHelper.GetNode("doctor");
            if (((str == "1") && (node != "")) && (str3 != ""))
            {
                this.ckAutolog.Checked = true;
                this.autoTimer = new System.Timers.Timer(1000.0);
                this.autoTimer.Elapsed += new ElapsedEventHandler(this.autoTimer_Elapsed);
                this.autoTimer.Start();
            }
        }

        [DllImport("RdCard.dll")]
        public static extern int GetAddr(byte[] addbyte);
        [DllImport("RdCard.dll")]
        public static extern int GetBirth(byte[] birthbyte);
        public string[] GetFileList(string ftp, string username, string password)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(ftp));
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
                MessageBox.Show(exception.Message);
                LogHelper.LogError(exception);
                return null;
            }
        }

        [DllImport("RdCard.dll")]
        public static extern int GetFolk(byte[] folkbyte);
        [DllImport("RdCard.dll")]
        public static extern int GetIDNum(byte[] buffer);
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
                    LoginForm login = this;
                    string str2 = login.Text + "v" + str;
                    login.Text = str2;
                }
            }
        }

        [DllImport("RdCard.dll")]
        public static extern int GetName(byte[] namebyte);
        [DllImport("RdCard.dll")]
        public static extern int GetNewAddr(byte[] newAddr);
        private void GetNewVersion()
        {
            GlbTools.GetFtpServer(ConfigHelper.GetNode("versionID"), out this.ftp, out this.user, out this.pwd);
            if (((this.ftp != "") && (this.user != "")) && (this.pwd != ""))
            {
                if (!System.IO.File.Exists(Application.StartupPath + @"\versioninfo.txt"))
                {
                    StreamWriter writer = new StreamWriter(new FileStream(Application.StartupPath + @"\versioninfo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.Default);
                    writer.Write("0\r\n");
                    writer.Write("0\r\n");
                    writer.Write("0\r\n");
                    writer.Write("1\r\n");
                    writer.Flush();
                    writer.Close();
                }
                else
                {
                    StreamReader reader = new StreamReader(Application.StartupPath + @"\versioninfo.txt");
                    if (!reader.EndOfStream)
                    {
                        string str = reader.ReadLine();
                        if (str != "")
                        {
                            this.m_lastyear = Convert.ToInt32(str);
                        }
                    }
                    if (!reader.EndOfStream)
                    {
                        string str2 = reader.ReadLine();
                        if (str2 != "")
                        {
                            this.m_lastmonth = Convert.ToInt32(str2);
                        }
                    }
                    if (!reader.EndOfStream)
                    {
                        string str3 = reader.ReadLine();
                        if (str3 != "")
                        {
                            this.m_lastday = Convert.ToInt32(str3);
                        }
                    }
                    if (!reader.EndOfStream)
                    {
                        string str4 = reader.ReadLine();
                        m_verion = str4;
                        if (str4 != "")
                        {
                            this.m_lastversion = Convert.ToDouble(str4);
                        }
                    }
                    reader.Close();
                }
                string str5 = this.readerFtp("ftp://" + this.ftp, this.user, this.pwd);
                if ((str5 != "error") && (str5.Length >= 12))
                {
                    double num = Convert.ToDouble(str5.Substring(7, str5.Length - 11));
                    if ((num - this.m_lastversion) > 1E-05)
                    {
                        this.linkLatestVersion.Visible = true;
                        this.m_lastversion = num;
                    }
                }
            }
        }

        private bool GetServerInfo()
        {
            bool flag = true;
            string str = "";
            foreach (ManagementObject obj2 in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
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
                flag = false;
            }
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                flag = false;
            }
            Ping ping = new Ping();
            try
            {
                if (ping.Send(str).Status != IPStatus.Success)
                {
                    flag = false;
                }
            }
            catch (Exception exception)
            {
                flag = false;
                LogHelper.LogError(exception);
            }
            return flag;
        }

        [DllImport("RdCard.dll")]
        public static extern int GetSex(byte[] sexbyte);
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtbHBDep = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbVillageHB_NAME = new System.Windows.Forms.TextBox();
            this.tbVillageName = new System.Windows.Forms.TextBox();
            this.linkSetup = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTownName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbArchiveID = new System.Windows.Forms.MaskedTextBox();
            this.lbLogInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckAutolog = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLatestVersion = new System.Windows.Forms.LinkLabel();
            this.picReadCard = new System.Windows.Forms.PictureBox();
            this.picBT = new System.Windows.Forms.PictureBox();
            this.picNetWork = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReadCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNetWork)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(172, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(43, 112);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 33);
            this.btnLogin.TabIndex = 20;
            this.btnLogin.Text = "登 录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtbHBDep);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbVillageHB_NAME);
            this.groupBox1.Controls.Add(this.tbVillageName);
            this.groupBox1.Controls.Add(this.linkSetup);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbTownName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mtbArchiveID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 218);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "行政区域和组织机构信息";
            // 
            // mtbHBDep
            // 
            this.mtbHBDep.Location = new System.Drawing.Point(124, 148);
            this.mtbHBDep.Mask = "00-00-00-000-000";
            this.mtbHBDep.Name = "mtbHBDep";
            this.mtbHBDep.Size = new System.Drawing.Size(152, 23);
            this.mtbHBDep.TabIndex = 102;
            this.mtbHBDep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(19, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 14);
            this.label11.TabIndex = 101;
            this.label11.Text = "组织机构编号:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(19, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 14);
            this.label10.TabIndex = 100;
            this.label10.Text = "所属组织机构:";
            // 
            // tbVillageHB_NAME
            // 
            this.tbVillageHB_NAME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbVillageHB_NAME.Location = new System.Drawing.Point(124, 118);
            this.tbVillageHB_NAME.Name = "tbVillageHB_NAME";
            this.tbVillageHB_NAME.Size = new System.Drawing.Size(152, 23);
            this.tbVillageHB_NAME.TabIndex = 99;
            // 
            // tbVillageName
            // 
            this.tbVillageName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbVillageName.Location = new System.Drawing.Point(124, 88);
            this.tbVillageName.Name = "tbVillageName";
            this.tbVillageName.Size = new System.Drawing.Size(152, 23);
            this.tbVillageName.TabIndex = 98;
            // 
            // linkSetup
            // 
            this.linkSetup.AutoSize = true;
            this.linkSetup.Location = new System.Drawing.Point(227, 187);
            this.linkSetup.Name = "linkSetup";
            this.linkSetup.Size = new System.Drawing.Size(49, 14);
            this.linkSetup.TabIndex = 21;
            this.linkSetup.TabStop = true;
            this.linkSetup.Text = "其他..";
            this.linkSetup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSetup_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(5, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 14);
            this.label4.TabIndex = 96;
            this.label4.Text = "村(居委会)名称:";
            // 
            // tbTownName
            // 
            this.tbTownName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTownName.Location = new System.Drawing.Point(124, 58);
            this.tbTownName.Name = "tbTownName";
            this.tbTownName.Size = new System.Drawing.Size(152, 23);
            this.tbTownName.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(5, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 14);
            this.label5.TabIndex = 95;
            this.label5.Text = "乡镇(街道)名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(5, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 14);
            this.label3.TabIndex = 94;
            this.label3.Text = "所属行政区编码:";
            // 
            // mtbArchiveID
            // 
            this.mtbArchiveID.Location = new System.Drawing.Point(124, 28);
            this.mtbArchiveID.Mask = "00-00-00-000-000";
            this.mtbArchiveID.Name = "mtbArchiveID";
            this.mtbArchiveID.Size = new System.Drawing.Size(152, 23);
            this.mtbArchiveID.TabIndex = 93;
            this.mtbArchiveID.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbLogInfo
            // 
            this.lbLogInfo.Location = new System.Drawing.Point(93, 5);
            this.lbLogInfo.Name = "lbLogInfo";
            this.lbLogInfo.Size = new System.Drawing.Size(181, 22);
            this.lbLogInfo.TabIndex = 25;
            this.lbLogInfo.Text = "..";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckAutolog);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbID);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnLogin);
            this.groupBox2.Controls.Add(this.tbName);
            this.groupBox2.Location = new System.Drawing.Point(302, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 218);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // ckAutolog
            // 
            this.ckAutolog.AutoSize = true;
            this.ckAutolog.Enabled = false;
            this.ckAutolog.Location = new System.Drawing.Point(173, 194);
            this.ckAutolog.Name = "ckAutolog";
            this.ckAutolog.Size = new System.Drawing.Size(82, 18);
            this.ckAutolog.TabIndex = 28;
            this.ckAutolog.Text = "自动登录";
            this.ckAutolog.UseVisualStyleBackColor = true;
            this.ckAutolog.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "用户ID:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(76, 61);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(171, 23);
            this.tbID.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "用户名:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(76, 32);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(171, 23);
            this.tbName.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbLogInfo);
            this.panel1.Controls.Add(this.picReadCard);
            this.panel1.Controls.Add(this.linkLatestVersion);
            this.panel1.Controls.Add(this.picBT);
            this.panel1.Controls.Add(this.picNetWork);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 30);
            this.panel1.TabIndex = 27;
            // 
            // linkLatestVersion
            // 
            this.linkLatestVersion.AutoSize = true;
            this.linkLatestVersion.Location = new System.Drawing.Point(458, 7);
            this.linkLatestVersion.Name = "linkLatestVersion";
            this.linkLatestVersion.Size = new System.Drawing.Size(112, 14);
            this.linkLatestVersion.TabIndex = 29;
            this.linkLatestVersion.TabStop = true;
            this.linkLatestVersion.Text = "升级至最新版本!";
            this.linkLatestVersion.Visible = false;
            this.linkLatestVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLatestVersion_LinkClicked);
            // 
            // picReadCard
            // 
            this.picReadCard.Image = ((System.Drawing.Image)(resources.GetObject("picReadCard.Image")));
            this.picReadCard.Location = new System.Drawing.Point(63, 3);
            this.picReadCard.Name = "picReadCard";
            this.picReadCard.Size = new System.Drawing.Size(24, 24);
            this.picReadCard.TabIndex = 30;
            this.picReadCard.TabStop = false;
            // 
            // picBT
            // 
            this.picBT.Image = ((System.Drawing.Image)(resources.GetObject("picBT.Image")));
            this.picBT.Location = new System.Drawing.Point(33, 3);
            this.picBT.Name = "picBT";
            this.picBT.Size = new System.Drawing.Size(24, 24);
            this.picBT.TabIndex = 28;
            this.picBT.TabStop = false;
            // 
            // picNetWork
            // 
            this.picNetWork.Image = global::KangShuo.Properties.Resources.net_on;
            this.picNetWork.Location = new System.Drawing.Point(3, 3);
            this.picNetWork.Name = "picNetWork";
            this.picNetWork.Size = new System.Drawing.Size(24, 24);
            this.picNetWork.TabIndex = 27;
            this.picNetWork.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 270);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.Text = "基本公共卫生服务平台 v2.13";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReadCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNetWork)).EndInit();
            this.ResumeLayout(false);

        }

        private bool InitReadCard()
        {
            bool flag = false;
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string str = "1";
            if (configuration.AppSettings.Settings["idCardType"] == null)
            {
                configuration.AppSettings.Settings.Add("idCardType", str);
                configuration.Save();
            }
            else
            {
                str = configuration.AppSettings.Settings["idCardType"].Value;
            }
            if (str == "1")
            {
                flag = this.InitShsIdCard();
            }
            if (str == "2")
            {
                flag = this.InitXzxIdCard();
            }
            return flag;
        }

        public bool InitShsIdCard()
        {
            byte abuf = 0x41;
            int num2 = 0;
            int num3 = 0x226b;
            int num4 = 0x2702;
            bool flag = false;
            if (UCommand1(ref abuf, ref num2, ref num3, ref num4) == 0xf2db)
            {
                flag = true;
            }
            return flag;
        }

        public bool InitXzxIdCard()
        {
            bool flag = false;
            if (Syn_FindReader() > 0x3e8)
            {
                flag = true;
            }
            return flag;
        }

        private void linkLatestVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.autoTimer != null)
            {
                this.autoTimer.Stop();
            }
            foreach (string str in this.GetFileList("ftp://" + this.ftp, this.user, this.pwd))
            {
                if (!str.StartsWith("version") && !str.StartsWith("config"))
                {
                    this.Download("ftp://" + this.ftp, this.user, this.pwd, Application.StartupPath + @"\update", str);
                }
            }
            System.IO.File.Delete(Application.StartupPath + @"\versioninfo.txt");
            StreamWriter writer = new StreamWriter(new FileStream(Application.StartupPath + @"\versioninfo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.Default);
            writer.Write("0\r\n");
            writer.Write("0\r\n");
            writer.Write("0\r\n");
            writer.Write(this.m_lastversion.ToString() + "\r\n");
            writer.Flush();
            writer.Close();
            this.m_hasnewversion = true;
            m_verion = this.m_lastversion.ToString();
            if (this.m_hasnewversion)
            {
                this.StartProcess();
            }
        }

        private void linkSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.autoTimer != null)
            {
                this.autoTimer.Stop();
            }

            new ConfigurationForm().ShowDialog();
        }

        private string readerFtp(string ftp, string username, string password)
        {
            string str = "no files";
            try
            {
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(ftp));
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

        private void StartProcess()
        {
            string executablePath = Application.ExecutablePath;
            int num = executablePath.LastIndexOf(@"\");
            string str2 = executablePath.Substring(0, num + 1);
            Thread.Sleep(300);
            Process.Start(str2 + "RemoteUpdate.exe");
        }

        [DllImport("SynIDCardAPI.dll")]
        public static extern int Syn_FindReader();
        [DllImport("SynIDCardAPI.dll")]
        public static extern int Syn_GetSAMID(int iPort, ref byte pucSAMID, int iIfOpen);
        [DllImport("SynIDCardAPI.dll")]
        public static extern int Syn_GetSAMStatus(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll")]
        public static extern int Syn_OpenPort(int port);
        [DllImport("SynIDCardAPI.dll")]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);
        [DllImport("SynIDCardAPI.dll")]
        public static extern int Syn_SelectIDCard(int iport, ref byte pucSN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll")]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);
        [DllImport("SynIDCardAPI.dll")]
        public static extern int Syn_StartFindIDCard(int iport, ref byte pucIIN, int iIfOpen);
        [DllImport("RdCard.dll")]
        public static extern int UCommand1(ref byte abuf, ref int parg0, ref int parg1, ref int parg2);

        public AreaOrg areaOrg { get; set; }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct IDCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x20)]
            public string Name;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=6)]
            public string Sex;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=20)]
            public string Nation;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x12)]
            public string Born;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x48)]
            public string Address;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x26)]
            public string IDCardNo;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x20)]
            public string GrantDept;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x12)]
            public string UserLifeBegin;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x12)]
            public string UserLifeEnd;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x26)]
            public string reserved;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0xff)]
            public string PhotoFileName;
        }
    }
}

