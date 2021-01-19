using ConfigManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.Utilities.CommunicationData;
using NotifyWindow = TestNotifyWindow.NotifyWindow;
using KangShuo.Properties;
using System.Linq;

namespace KangShuo
{
    public class PadForm : Form
    {
        private RecordsBaseInfoModel baseInfo;
        private BluetoothOper bt_oper;
        public static int BU_FirstInsert;
        private ClsTransInfo clsTrans;
        private IContainer components;
        public static string comPort;
        public static bool ComVisiable = false;
        private USB ezUSB = new USB();
        public static string formalOrTest = "formal";
        private Guid g_bt;
        public static string idNo = "";
        private string input = "";
        private bool m_IsLogIn;
        private CModulesManager modulesMgr;
        public static string netStatus = "0";
        public static string orgid;
        private Panel panel;
        private Panel panel_parent;
        private SerialPort port1 = new SerialPort();
        //public static string PrinterPNPDeviceID = ConfigurationManager.AppSettings["PrinterPNPDeviceID"];
        public AbsReadIDCardNo readCard;
        private Panel panelloadModule;
        private PictureBox lblQuit;
        private PictureBox LoginPictureBox;
        private Label lblWelcome;
        private Panel panelWelcome;
        private const int WM_COPYDATA = 0x4a;
        private SerialPort serialPort1;
        public Process QCATFProcess;
        public Process CHITBPProcess;
        public Process CHITBGProcess;
        public Process CHITBMProcess;
        public Process CHITBTProcess;
        private Label lblDoctor;
        private Button btnModifyPass;
        private Label label3;
        public Process EMPUIProcess;

        // 取得屏幕分辨率的宽高
        private int SW = Screen.PrimaryScreen.Bounds.Width;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnECGcode;
        private Button btnDefault;
        private Button btnBackData;
        private int SH = Screen.PrimaryScreen.Bounds.Height;

        public PadForm()
        {
            this.InitializeComponent();
            this.LoginPictureBox.Focus();
            this.LoadBackgroundImg();
            base.StartPosition = FormStartPosition.CenterScreen;

            string versionNo = ConfigHelper.GetSetNode("versionNo");
            if (!string.IsNullOrEmpty(versionNo)) this.label3.Text = versionNo;

           
            //LoginPictureBox.Left = SW - 200;
            //lblQuit.Left = SW - 100;
            //btnBackData.Top = SH - 58;
            //btnDefault.Top = SH - 58;
            //btnECGcode.Top = SH - 58;
            //btnModifyPass.Top = SH - 58;
        }
        
        private void callTheModule(CModule module)
        {
            if (this.baseInfo != null && !new RecordsBaseInfoBLL().Exists(this.baseInfo.IDCardNo))
            {
                MessageBox.Show("当前人员不存在，或许已被删除,系统将返回登录页面！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.DoLogout();
            }
            else
            {
                this.WriteComPort(module.LcdOrder);

                try
                {
                    if (module.UCMainItems != null)
                    {
                        if (!this.panel_parent.Controls.Contains(module.UCMainItems))
                        {
                            module.UCMainItems.Dock = DockStyle.Fill;
                            this.panel_parent.Controls.Add(module.UCMainItems);
                        }
                        module.SetModuleIDCardNo(idNo);
                        this.panel_parent.Controls.SetChildIndex(module.UCMainItems, 0);
                        module.UCMainItems.Show();
                        this.modulesMgr.Lev2Status = true;
                        this.panel_parent.Visible = true;
                    }

                    Form loadForm = module.LoadForm;

                    if (loadForm != null)
                    {
                        module.SetLoadFormIDCardNo(idNo);
                        loadForm.ShowDialog();
                    }
                    Controler moduleControler = module.ModuleControler;
                    if (moduleControler != null)
                    {
                        moduleControler.IParentFrm.IShowDialog();
                    }

                    Button[] btn = this.modulesMgr.ArryModules;

                    if (module.ImgName == "档案信息")
                    {
                        btn[0].BackgroundImage = Resources.btndangan01;
                        btn[1].BackgroundImage = Resources.btnrenqun00;
                        btn[2].BackgroundImage = Resources.btnyiliaofuwu00;
                        btn[3].BackgroundImage = Resources.btnchaxun00;
                        btn[4].BackgroundImage = Resources.btnshujutongbu0;
                        btn[5].BackgroundImage = Resources.btnpaizhao00;
                        btn[6].BackgroundImage = Resources.btnzhizhidangan00;
                    }
                    else if (module.ImgName == "随访人群")
                    {
                        btn[0].BackgroundImage = Resources.btndangan00;
                        btn[1].BackgroundImage = Resources.btnrenqun01;
                        btn[2].BackgroundImage = Resources.btnyiliaofuwu00;
                        btn[3].BackgroundImage = Resources.btnchaxun00;
                        btn[4].BackgroundImage = Resources.btnshujutongbu0;
                        btn[5].BackgroundImage = Resources.btnpaizhao00;
                        btn[6].BackgroundImage = Resources.btnzhizhidangan00;
                    }
                    else if (module.ImgName == "医疗服务")
                    {
                        btn[0].BackgroundImage = Resources.btndangan00;
                        btn[1].BackgroundImage = Resources.btnrenqun00;
                        btn[2].BackgroundImage = Resources.btnyiliaofuwu01;
                        btn[3].BackgroundImage = Resources.btnchaxun00;
                        btn[4].BackgroundImage = Resources.btnshujutongbu0;
                        btn[5].BackgroundImage = Resources.btnpaizhao00;
                        btn[6].BackgroundImage = Resources.btnzhizhidangan00;
                    }
                    else if (module.ImgName == "综合查询")
                    {
                        btn[0].BackgroundImage = Resources.btndangan00;
                        btn[1].BackgroundImage = Resources.btnrenqun00;
                        btn[2].BackgroundImage = Resources.btnyiliaofuwu00;
                        btn[3].BackgroundImage = Resources.btnchaxun01;
                        btn[4].BackgroundImage = Resources.btnshujutongbu0;
                        btn[5].BackgroundImage = Resources.btnpaizhao00;
                        btn[6].BackgroundImage = Resources.btnzhizhidangan00;
                    }
                    else if (module.ImgName == "数据同步")
                    {
                        btn[0].BackgroundImage = Resources.btndangan00;
                        btn[1].BackgroundImage = Resources.btnrenqun00;
                        btn[2].BackgroundImage = Resources.btnyiliaofuwu00;
                        btn[3].BackgroundImage = Resources.btnchaxun00;
                        btn[4].BackgroundImage = Resources.btnshujutongbu01;
                        btn[5].BackgroundImage = Resources.btnpaizhao00;
                        btn[6].BackgroundImage = Resources.btnzhizhidangan00;
                    }
                    else if (module.ImgName == "拍取照片")
                    {
                        btn[0].BackgroundImage = Resources.btndangan00;
                        btn[1].BackgroundImage = Resources.btnrenqun00;
                        btn[2].BackgroundImage = Resources.btnyiliaofuwu00;
                        btn[3].BackgroundImage = Resources.btnchaxun00;
                        btn[4].BackgroundImage = Resources.btnshujutongbu0;
                        btn[5].BackgroundImage = Resources.btnpaizhao01;
                        btn[6].BackgroundImage = Resources.btnzhizhidangan00;
                    }
                    else if (module.ImgName == "纸质档案")
                    {
                        btn[0].BackgroundImage = Resources.btndangan00;
                        btn[1].BackgroundImage = Resources.btnrenqun00;
                        btn[2].BackgroundImage = Resources.btnyiliaofuwu00;
                        btn[3].BackgroundImage = Resources.btnchaxun00;
                        btn[4].BackgroundImage = Resources.btnshujutongbu0;
                        btn[5].BackgroundImage = Resources.btnpaizhao00;
                        btn[6].BackgroundImage = Resources.btnzhizhidangan01;
                    }
                }
                catch (Exception exception)
                {
                    LogHelper.LogError(exception);
                }
            }
        }

        private void ClosePort()
        {
            if (ComVisiable)
            {
                try
                {
                    this.port1.DiscardOutBuffer();
                    this.port1.DiscardInBuffer();
                    this.port1.Close();
                    ComVisiable = false;
                }
                catch (Exception exception)
                {
                    ErrorLog.WriterLog(string.Format("关闭LED串口失败:{0}\r\n{1}", comPort, exception.Message));
                    LogHelper.LogError(exception);

                    new MessageForm(string.Format("关闭LED串口失败:{0}\r\n{1}", comPort, exception.Message)) { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                }
            }
        }

        private void clsTrans_SendMsg(string msg)
        {
            if (!this.m_IsLogIn)
            {
                if (msg.Contains("TRANSEND") || (msg == "ERROR"))
                {
                    new MessageForm("非会员用户测量数据无效") { StartPosition = FormStartPosition.CenterScreen }.ShowDialog();
                    Thread.Sleep(500);
                }
            }
            else
            {
                IntPtr hWnd = FindWindow(null, "ShowBT");
                if (hWnd == IntPtr.Zero)
                {
                    new Process { StartInfo = { FileName = Application.StartupPath + @"\ShowBt.exe" } }.Start();
                    Thread.Sleep(500);
                }
                bool flag1 = msg == "UNKNOWN";
                if (msg.Contains("CONNECT"))
                {
                    this.g_bt = Guid.NewGuid();
                    ClsMsgWindow.SendString("ShowBT", 1, this.g_bt.ToString() + ":" + msg);
                    this.WriteComPort(string.Format("{0} reading", msg.Substring(msg.Length - 2, 2)));
                }
                if (msg == "ERROR")
                {
                    ClsMsgWindow.SendString("ShowBT", 1, this.g_bt.ToString() + ":ERROR" + msg);
                }
                if ((msg == "TRANSEND") && ClsResult.ResultFlag)
                {
                    ClsMsgWindow.SendString("ShowBT", 1, this.g_bt.ToString() + ":TRANSEND" + TranslateClsResult.TranslateToStr());
                    if (IsWindowVisible(hWnd))
                    {
                        this.WriteComPort(string.Format("{0} successed", ClsResult.DeviceName.Substring(4, 2)));
                    }
                    ClsMsgWindow.SendDeviceInfo(ClsResult.DeviceName + ";BT");
                }
            }
        }

        private void clsTrans_SendMsgNt(string msg)
        {
            if (!this.m_IsLogIn)
            {
                if (msg.Contains("TRANSEND") || (msg == "ERROR"))
                {
                    new MessageForm("非会员用户测量数据无效") { StartPosition = FormStartPosition.CenterScreen }.ShowDialog();
                    Thread.Sleep(500);
                }
            }
            else
            {
                bool flag1 = msg == "UNKNOWN";
                if (msg.Contains("CONNECT"))
                {
                    this.g_bt = Guid.NewGuid();
                    this.WriteComPort(string.Format("{0} reading", msg.Substring(msg.Length - 2, 2)));
                }
                if (msg == "ERROR")
                {
                    base.Invoke(new Action<string, string>(this.run_notify_window), new object[] { ClsResult.DeviceName, "接收数据失败!" });
                }
                if ((msg == "TRANSEND") && ClsResult.ResultFlag)
                {
                    string str = !(ClsResult.DeviceName == "QCTBE") ? TranslateClsResult.TranslateToStr() : "(查看)";
                    ClsMsgWindow.SendDeviceInfo(ClsResult.DeviceName + ";BT");
                    base.Invoke(new Action<string, string>(this.run_notify_window), new object[] { TranslateClsResult.GetDeviceCName(ClsResult.DeviceName), str });
                    this.notify_save();
                    this.WriteComPort(string.Format("{0} successed", ClsResult.DeviceName.Substring(3, 2)));
                }
            }
        }

        private void ControlTextRefresh(Control ctr, string text)
        {
            Action<Control, string> method = new Action<Control, string>(this.ControlTextRefresh);
            if (ctr.InvokeRequired)
            {
                ctr.Invoke(method, new object[] { ctr, text });
            }
            else
            {
                ctr.Text = text;
            }
        }

        private void ControlVisibleRefresh(Control ctr, bool visible)
        {
            Action<Control, bool> method = new Action<Control, bool>(this.ControlVisibleRefresh);
            if (ctr.InvokeRequired)
            {
                ctr.Invoke(method, new object[] { ctr, visible });
            }
            else
            {
                ctr.Visible = visible;
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == 0x4a)
            {
                switch (m.WParam.ToInt32())
                {
                    case 1:
                        this.TranslateMsg(ClsMsgWindow.GetMsgStr(m));
                        return;

                    case 2:
                        this.WriteComPort(ClsMsgWindow.GetMsgStr(m));
                        return;

                    case 3:
                        ClsMsgWindow.GetMsgStr(m);
                        ClsMsgWindow.SendString("打印条码", 3, printerStatus.ToString());
                        ClsMsgWindow.SendDeviceInfo("lbPrinterTimes;LbPrinter");
                        return;

                    case 4:
                        {
                            string[] strArray = ClsMsgWindow.GetMsgStr(m).Split(new char[] { '\n' });
                            ReadIdentifyEventArgs e = new ReadIdentifyEventArgs
                            {
                                Idcard = strArray[0].Trim(),
                                Addr = strArray[1].Trim(),
                                Nation = strArray[2].Trim(),
                                Minority = strArray[3].Trim(),
                                Birthday = DateTime.Parse(strArray[4].Trim()),
                                Sex = strArray[5].Trim(),
                                Name = strArray[6].Trim()
                            };
                            this.readCardEvent(null, e);
                            return;
                        }
                }
            }
            else
            {
                base.DefWndProc(ref m);
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

        private void DoLogout()
        {
            if (this.m_IsLogIn)
            {
                this.baseInfo = null;
                this.ModuleCancelClick(null, null);
                this.LoginPictureBox.Visible = true;
                this.LoginPictureBox.Enabled = true;
               
                this.m_IsLogIn = false;
                this.lblWelcome.Text = "";
                //this.baseInfo.IDCardNo = "";
                idNo = "";

                if (ConfigHelper.GetNode("IdCard") == "True")
                {
                    this.readCard.StartRead();
                    ClsToolTip.WriteLog("idCard timer is running");
                }

                ClsToolTip.WriteLog("user do logout success");
                BU_FirstInsert = 0;
                Thread.Sleep(100);

                if ((this.bt_oper != null) && (this.bt_oper.currentStatus == BluePeiduiStatus.Open))
                {
                    this.bt_oper.Close();
                }

                this.WriteComPort("User exit");
            }
        }

        [DllImport("User32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        private void GetDepAndOrgName()
        {
            bool flag = false;
            if (this.baseInfo.VillageID.HasValue && (this.baseInfo.VillageID.Value.ToString().Length == 12))
            {
                flag = true;
            }
            if (string.IsNullOrEmpty(this.baseInfo.TownName) && this.baseInfo.TownID.HasValue)
            {
                List<RecordsTownModel> modelList = new RecordsTownBLL().GetModelList(flag ? string.Format(" CODE = '{0}' ", this.baseInfo.TownID) : string.Format(" ID = {0} ", this.baseInfo.TownID));
                if (modelList.Count > 0)
                {
                    this.baseInfo.TownName = modelList[0].Name;
                }
            }
            if (string.IsNullOrEmpty(this.baseInfo.VillageName) && this.baseInfo.VillageID.HasValue)
            {
                List<RecordsVillageModel> list2 = new RecordsVillageBLL().GetModelList(flag ? string.Format(" CODE = '{0}' ", this.baseInfo.VillageID) : string.Format(" ID = {0} ", this.baseInfo.VillageID));
                if (list2.Count > 0)
                {
                    this.baseInfo.VillageName = list2[0].Name;
                }
            }
            if (string.IsNullOrEmpty(this.baseInfo.CreateUnitName))
            {
                SysOrgVillangModle model = new SysOrgVillangBLL().GetModel(this.baseInfo.OrgVillageID.ToString());
                if (model != null)
                {
                    this.baseInfo.CreateUnitName = model.Name;
                }
            }
            if (string.IsNullOrEmpty(this.baseInfo.CreateMenName))
            {
                SysUserModel sys_user = new SysUserBLL().GetModel(this.baseInfo.CreateBy ?? "");
                if (sys_user != null)
                {
                    this.baseInfo.CreateMenName = sys_user.UserName;
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PadForm));
            this.panel = new System.Windows.Forms.Panel();
            this.panelloadModule = new System.Windows.Forms.Panel();
            this.panel_parent = new System.Windows.Forms.Panel();
            this.panelWelcome = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnECGcode = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnBackData = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblQuit = new System.Windows.Forms.PictureBox();
            this.LoginPictureBox = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblDoctor = new System.Windows.Forms.Label();
            this.btnModifyPass = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.panel_parent.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Controls.Add(this.panelloadModule);
            this.panel.Controls.Add(this.panel_parent);
            this.panel.Location = new System.Drawing.Point(0, 137);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1600, 700);
            this.panel.TabIndex = 74;
            // 
            // panelloadModule
            // 
            this.panelloadModule.BackColor = System.Drawing.Color.Transparent;
            this.panelloadModule.Location = new System.Drawing.Point(1, 17);
            this.panelloadModule.Name = "panelloadModule";
            this.panelloadModule.Size = new System.Drawing.Size(346, 690);
            this.panelloadModule.TabIndex = 71;
            // 
            // panel_parent
            // 
            this.panel_parent.BackColor = System.Drawing.Color.Transparent;
            this.panel_parent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_parent.Controls.Add(this.panelWelcome);
            this.panel_parent.ForeColor = System.Drawing.Color.Transparent;
            this.panel_parent.Location = new System.Drawing.Point(366, 1);
            this.panel_parent.Name = "panel_parent";
            this.panel_parent.Size = new System.Drawing.Size(1351, 670);
            this.panel_parent.TabIndex = 73;
            // 
            // panelWelcome
            // 
            this.panelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.panelWelcome.BackgroundImage = global::KangShuo.Properties.Resources.morenbeijing;
            this.panelWelcome.ForeColor = System.Drawing.Color.Black;
            this.panelWelcome.Location = new System.Drawing.Point(0, 18);
            this.panelWelcome.Name = "panelWelcome";
            this.panelWelcome.Size = new System.Drawing.Size(1093, 539);
            this.panelWelcome.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnECGcode);
            this.flowLayoutPanel1.Controls.Add(this.btnDefault);
            this.flowLayoutPanel1.Controls.Add(this.btnBackData);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1020, 845);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(384, 50);
            this.flowLayoutPanel1.TabIndex = 111;
            // 
            // btnECGcode
            // 
            this.btnECGcode.BackColor = System.Drawing.Color.Transparent;
            this.btnECGcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnECGcode.Location = new System.Drawing.Point(3, 3);
            this.btnECGcode.Name = "btnECGcode";
            this.btnECGcode.Size = new System.Drawing.Size(122, 44);
            this.btnECGcode.TabIndex = 106;
            this.btnECGcode.Text = "二维码打印";
            this.btnECGcode.UseVisualStyleBackColor = false;
            // 
            // btnDefault
            // 
            this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefault.Location = new System.Drawing.Point(131, 3);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(122, 44);
            this.btnDefault.TabIndex = 109;
            this.btnDefault.Text = "系统设置";
            this.btnDefault.UseVisualStyleBackColor = true;
            // 
            // btnBackData
            // 
            this.btnBackData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackData.Location = new System.Drawing.Point(259, 3);
            this.btnBackData.Name = "btnBackData";
            this.btnBackData.Size = new System.Drawing.Size(122, 44);
            this.btnBackData.TabIndex = 100;
            this.btnBackData.Text = "数据备份";
            this.btnBackData.UseVisualStyleBackColor = true;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(1239, 100);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(68, 27);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "您好";
            this.lblWelcome.Visible = false;
            // 
            // lblQuit
            // 
            this.lblQuit.BackColor = System.Drawing.Color.Transparent;
            this.lblQuit.BackgroundImage = global::KangShuo.Properties.Resources.btntuichu;
            this.lblQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblQuit.Location = new System.Drawing.Point(1482, 85);
            this.lblQuit.Name = "lblQuit";
            this.lblQuit.Size = new System.Drawing.Size(97, 46);
            this.lblQuit.TabIndex = 73;
            this.lblQuit.TabStop = false;
            this.lblQuit.Click += new System.EventHandler(this.lblQuit_Click);
            // 
            // LoginPictureBox
            // 
            this.LoginPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoginPictureBox.BackgroundImage = global::KangShuo.Properties.Resources.btndenglu;
            this.LoginPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginPictureBox.Location = new System.Drawing.Point(1377, 85);
            this.LoginPictureBox.Name = "LoginPictureBox";
            this.LoginPictureBox.Size = new System.Drawing.Size(97, 46);
            this.LoginPictureBox.TabIndex = 88;
            this.LoginPictureBox.TabStop = false;
            this.LoginPictureBox.Click += new System.EventHandler(this.LoginPictureBox_Click);
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctor.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoctor.ForeColor = System.Drawing.Color.White;
            this.lblDoctor.Location = new System.Drawing.Point(1039, 100);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(96, 27);
            this.lblDoctor.TabIndex = 97;
            this.lblDoctor.Text = "医生：";
            // 
            // btnModifyPass
            // 
            this.btnModifyPass.BackColor = System.Drawing.Color.Transparent;
            this.btnModifyPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModifyPass.BackgroundImage")));
            this.btnModifyPass.Location = new System.Drawing.Point(419, 807);
            this.btnModifyPass.Name = "btnModifyPass";
            this.btnModifyPass.Size = new System.Drawing.Size(121, 44);
            this.btnModifyPass.TabIndex = 105;
            this.btnModifyPass.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 15.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(678, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 108;
            this.label3.Text = "山东德州";
            // 
            // PadForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::KangShuo.Properties.Resources.Main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1600, 750);
            this.Controls.Add(this.btnModifyPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.LoginPictureBox);
            this.Controls.Add(this.lblQuit);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "PadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "硕康智能体检系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MainFormForm_HelpRequested);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFormForm_KeyUp);
            this.panel.ResumeLayout(false);
            this.panel_parent.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.OpenSerialPort();

            //if (formalOrTest == "formal")
            //{
            //    this.lbWhat.Text = "演示版 ";
            //}
            //else
            //{
            //    this.lbWhat.Text = "正式版 ";
            //}

            //if (orgid.Contains("370112"))
            //{
            //    this.lbWhat.Text = "本产品为：" + this.lbWhat.Text;
            //    this.lbWhat.ForeColor = Color.Red;
            //}

            //this.lbWhat.Location = new Point(0x400 - (this.lbWhat.Width + 10), this.lbWhat.Location.Y);

            //启动数据备份进程
            Process ps = new Process();
            ps.StartInfo.FileName = "BackDates.exe";
            ps.Start();

            this.modulesMgr = new CModulesManager(new Action<CModule>(this.callTheModule), new EventHandler(this.ModuleCancelClick), this.panelloadModule.Height, this.panelloadModule.Width);

            if (this.modulesMgr.Count > 0)
            {
                this.panelloadModule.Controls.AddRange((Control[])this.modulesMgr.ArryModules);
            }

            this.clsTrans = new ClsTransInfo("COM");
            ClsTransInfo.ReadMode = true;
            ConfigHelper.GetNode("IdCardType");
            string pValue = "no";

            if (!ConfigHelper.GetNode("BtAutoSave", ref pValue))
            {
                ConfigHelper.WriteNode("BtAutoSave", "no");
            }

            if (pValue == "yes")
            {
                this.clsTrans.SendMsg += new TransMessageHandle(this.clsTrans_SendMsgNt);
            }
            else
            {
                this.clsTrans.SendMsg += new TransMessageHandle(this.clsTrans_SendMsg);
            }

            //this.clsTrans.InitListener();

            if ((ConfigHelper.GetNode("IdCard") == "True") && this.readCard.IsOk)
            {
                this.readCard.readCardEvent = (ReadCardEventHandler)Delegate.Combine(this.readCard.readCardEvent, new ReadCardEventHandler(this.readCardEvent));
                this.readCard.StartRead();
            }

            //this.axShockwaveFlash1.Movie = Application.StartupPath + @"\startup.swf";

            string doctor = ConfigHelper.GetNode("doctorName");
            this.ControlTextRefresh(this.lblDoctor, lblDoctor.Text + doctor);
            this.WriteComPort("open");
            string input = ConfigHelper.GetNode("inputPassWord").ToString();
            if (input.ToLower() == "true")
            {
                this.btnModifyPass.Visible = true;
            }
            else
            {
                this.btnModifyPass.Visible = false;
            }
        }
        
        private void MainFormForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.readCard.StopRead();
            try
            {
                int num;
                if (!this.readCard.CloseCard(out num))
                {
                    LogHelper.LogInfo("关闭读卡器失败:" + num);
                }
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
            }
            ShowTaskBar();
            this.WriteComPort("appExit");
            this.ClosePort();
            ClsMsgWindow.SendString("ShowBT", 1, "close");
            this.ezUSB.RemoveUSBEventWatcher();
            if (FindWindow(null, "居民健康档案打印") != IntPtr.Zero)
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName == "NewPrint")
                    {
                        process.Kill();
                    }
                }
            }
            LogHelper.LogInfo("exe quit........");
        }

        private void MainFormForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Version version = new Version(Application.ProductVersion);
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string str = !string.IsNullOrEmpty(ProVersion) ? ProVersion : ConfigHelper.GetNode("ProVersion");
            MessageBox.Show("软件版本:" + formalOrTest + str + "\r\nProductVersion:" + version.ToString() + "\r\n 程序集版本:" + executingAssembly.FullName, "帮助", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void MainFormForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.m_IsLogIn)
            {
                Keys keyCode = e.KeyCode;
                if (keyCode != Keys.F18)
                {
                    if (keyCode != Keys.F24)
                    {
                        return;
                    }
                }
                else
                {
                    this.picLogo_Click(null, null);
                    return;
                }
                this.lblQuit_Click(null, null);
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.F13:
                    case Keys.F19:
                        this.modulesMgr.FnButtonCall(e.KeyCode);
                        return;

                    case Keys.F14:
                    case Keys.F15:
                    case Keys.F20:
                    case Keys.F21:
                        if (!this.modulesMgr.Lev2Status)
                        {
                            this.modulesMgr.FnButtonCall(e.KeyCode);
                            return;
                        }
                        return;

                    case Keys.F16:
                        this.WriteComPort("Set Configer");
                        //TODO
                        //new ConfigurationForm { StartPosition = FormStartPosition.CenterScreen }.ShowDialog();
                        return;

                    case Keys.F17:
                        break;

                    case Keys.F18:
                        this.picLogo_Click(null, null);
                        return;

                    case Keys.F22:
                        this.WriteComPort("Help");
                        if (File.Exists(Application.StartupPath + @"\使用说明书.chm"))
                        {
                            Process.Start(Application.StartupPath + @"\使用说明书.chm");
                            return;
                        }
                        return;

                    case Keys.F23:
                        if (this.modulesMgr.Lev2Status)
                        {
                            this.ModuleCancelClick(null, null);
                            return;
                        }
                        this.lblQuit_Click(null, null);
                        return;

                    case Keys.F24:
                        this.lblQuit_Click(null, null);
                        return;

                    default:
                        return;
                }
            }
        }

        private void lblQuit_Click(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Contains("BackDates"))
                {
                    MessageBox.Show("数据库备份尚未完成，请勿关闭程序！");
                    return;
                }
            }

            if (this.m_IsLogIn)
            {
                this.DoLogout();

                if (QCATFProcess != null)
                {
                    QCATFProcess.Kill();
                }

                if (CHITBPProcess != null)
                {
                    CHITBPProcess.Kill();
                }

                if (CHITBGProcess != null)
                {
                    CHITBGProcess.Kill();
                }

                if (CHITBMProcess != null)
                {
                    CHITBMProcess.Kill();
                }

                if (EMPUIProcess != null)
                {
                    EMPUIProcess.Kill();
                }

                if (CHITBTProcess != null)
                {
                    CHITBTProcess.Kill();
                }

                ResetButton();
            }
            else
            {
                //启动数据备份进程
                Process ps = new Process();
                ps.StartInfo.FileName = "BackDates.exe";
                ps.Start();
                base.Close();
            }
        }

        /// <summary>
        /// 蓝牙启动
        /// </summary>
        private void StartBT()
        {
            #region 取setting中的蓝牙设置

            string fileName = Environment.CurrentDirectory + @"\setting.xml";

            if (!File.Exists(fileName)) return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            XmlElement xmlRoot = xmlDoc.DocumentElement;
            XmlNodeList nodeList = xmlDoc.SelectNodes("//Bluetooth");

            // 判断setting中是否有蓝牙设置，没有则启动全部蓝牙
            if (nodeList == null || nodeList.Count < 5)
            {
                CHITBPProcess = new Process { StartInfo = { FileName = @"BTCHITBP\BTCHITBP.exe", Arguments = idNo } };//血压计
                CHITBPProcess.Start();

                CHITBGProcess = new Process { StartInfo = { FileName = @"BTCHITBG\BTCHITBG.exe", Arguments = idNo } };//血糖
                CHITBGProcess.Start();

                QCATFProcess = new Process { StartInfo = { FileName = @"BTQCATF\BTQCATF.exe", Arguments = idNo } };//额温计
                QCATFProcess.Start();

                CHITBMProcess = new Process { StartInfo = { FileName = @"BTCHITBM\BTCHITBM.exe", Arguments = idNo } };//电子秤
                CHITBMProcess.Start();

                EMPUIProcess = new Process { StartInfo = { FileName = @"BTEMPUI\BTEMPUI.exe", Arguments = idNo } };//尿剂
                EMPUIProcess.Start();

                if (File.Exists(Application.StartupPath + "\\BTQCTBT\\BTQCTBT.exe"))
                {
                    CHITBTProcess = new Process { StartInfo = { FileName = @"BTQCTBT\BTQCTBT.exe", Arguments = idNo } };
                    CHITBTProcess.Start();
                }
            }
            else
            {
                foreach (XmlNode node in nodeList)
                {
                    if (node.SelectSingleNode("IsStartUp").InnerText.ToUpper() == "Y")
                    {
                        switch (node.SelectSingleNode("Function").InnerText)
                        {
                            case "BTCHITBP":
                                CHITBPProcess = new Process { StartInfo = { FileName = @"BTCHITBP\BTCHITBP.exe", Arguments = idNo } };
                                CHITBPProcess.Start();
                                break;
                            case "BTCHITBG":
                                CHITBGProcess = new Process { StartInfo = { FileName = @"BTCHITBG\BTCHITBG.exe", Arguments = idNo } };
                                CHITBGProcess.Start();
                                break;
                            case "BTQCATF":
                                QCATFProcess = new Process { StartInfo = { FileName = @"BTQCATF\BTQCATF.exe", Arguments = idNo } };
                                QCATFProcess.Start();
                                break;
                            case "BTCHITBM":
                                CHITBMProcess = new Process { StartInfo = { FileName = @"BTCHITBM\BTCHITBM.exe", Arguments = idNo } };
                                CHITBMProcess.Start();
                                break;
                            case "BTEMPUI":
                                EMPUIProcess = new Process { StartInfo = { FileName = @"BTEMPUI\BTEMPUI.exe", Arguments = idNo } };
                                EMPUIProcess.Start();
                                break;
                        }

                        if (File.Exists(Application.StartupPath + "\\BTQCTBT\\BTQCTBT.exe"))
                        {
                            CHITBTProcess = new Process { StartInfo = { FileName = @"BTQCTBT\BTQCTBT.exe", Arguments = idNo } };
                            CHITBTProcess.Start();
                        }
                    }
                }
            }

            #endregion
        }

        private void ResetButton()
        {
            Button[] btn = this.modulesMgr.ArryModules;

            btn[0].BackgroundImage = Resources.btndangan00;
            btn[1].BackgroundImage = Resources.btnrenqun00;
            btn[2].BackgroundImage = Resources.btnyiliaofuwu00;
            btn[3].BackgroundImage = Resources.btnchaxun00;
            btn[4].BackgroundImage = Resources.btnshujutongbu0;
            btn[5].BackgroundImage = Resources.btnpaizhao00;
            btn[6].BackgroundImage = Resources.btnzhizhidangan00;
        }

        private void LoadBackgroundImg()
        {
            string path = Application.StartupPath + @"\ModuleManger.xml";
            if (File.Exists(path))
            {
                XmlDocument document = new XmlDocument();
                document.Load(path);
                foreach (XmlNode node in document.DocumentElement["ControlSet"].ChildNodes)
                {
                    XmlNode node2 = node.SelectSingleNode("Text");
                    XmlNode node3 = node.SelectSingleNode("LocationX");
                    XmlNode node4 = node.SelectSingleNode("LocationY");
                    XmlNode node5 = node.SelectSingleNode("Width");
                    XmlNode node6 = node.SelectSingleNode("Height");
                    XmlNode node7 = node.SelectSingleNode("BackGroundImage");
                    Control control = base.Controls[node.Attributes["category"].Value];

                    if (control != null)
                    {
                        control.Text = node2.InnerText;
                        control.Location = new Point(int.Parse(node3.InnerText), int.Parse(node4.InnerText));
                        control.Size = new Size(int.Parse(node5.InnerText), int.Parse(node6.InnerText));

                        if ((!string.IsNullOrEmpty(node7.InnerText) && File.Exists(node7.InnerText)) && (node.Attributes["category"].Value != "picLogo"))
                        {
                            control.BackgroundImage = Image.FromFile(node7.InnerText);
                            control.BackgroundImageLayout = ImageLayout.None;
                        }
                    }
                }
            }
        }

        private void ModuleCancelClick(object sender, EventArgs e)
        {
            this.panel_parent.Controls.SetChildIndex(this.panelWelcome, 0);
            this.panelWelcome.Show();
            this.modulesMgr.Lev2Status = false;
            this.panel_parent.Visible = false;
        }

        private void notify_save()
        {
            DeviceInfoModel devInfo = new DeviceInfoModel
            {
                IDCardNo = idNo
            };

            devInfo.UpdateData = DateTime.Now.ToString();
            bool flag = TranslateClsResult.TranslateToModel(devInfo, this.baseInfo);
            DeviceInfoBLL deviceinfo2 = new DeviceInfoBLL();

            if (!flag)
            {
                if ((devInfo.FirstName == "QCTBU") && (devInfo.DeviceType == "33"))
                {
                    if (BU_FirstInsert != 0)
                    {
                        string str;
                        new DeviceInfoBLL().Update(TranslateClsResult.GetTableColumn(devInfo, devInfo.ChildTypeBu, out str), str, BU_FirstInsert);
                    }
                    else
                    {
                        BU_FirstInsert = deviceinfo2.Add(devInfo);
                    }
                }
                else if (deviceinfo2.Add(devInfo) != 0)
                {
                    TranslateClsResult.set_tj_content(devInfo);
                }
            }
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            LoginAfter(new IDCardNoInputForm
            {
                StartPosition = FormStartPosition.CenterParent
            });
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.m_IsLogIn)
            {
                switch (keyData)
                {
                    case Keys.S:
                    case Keys.T:
                    case Keys.E:
                        {
                            PadForm form = this;
                            string str = form.input + keyData.ToString();
                            form.input = str;
                            break;
                        }
                    case Keys.Enter:
                        if (this.input == "SET")
                        {
                            new FrmConfig { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                        }
                        this.input = "";
                        break;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void readCardEvent(object sender, ReadIdentifyEventArgs e)
        {
            int num;
            if (e.ReadResult != 0)
            {
                return;
            }

            if (e.Idcard != null)
            {
                if (e.Idcard.Length != Encoding.Default.GetByteCount(e.Idcard))
                {
                    e.Idcard = new ConvertDBCAndSBC().SBCToDBC(e.Idcard);
                }

                idNo = e.Idcard;
                this.baseInfo = new RecordsBaseInfoBLL().GetModel(e.Idcard);
                bool flag = false;
                if (this.baseInfo == null)
                {
                    this.baseInfo = new RecordsBaseInfoModel();
                    this.baseInfo.IDCardNo = e.Idcard;
                    flag = true;
                    goto Label_0173;
                }
                if (((this.baseInfo.HouseHoldAddress == e.Addr) && (this.baseInfo.Nation == e.Nation)) && (this.baseInfo.Minority == e.Minority))
                {
                    DateTime? bIRTHDAY = this.baseInfo.Birthday;
                    DateTime birthday = e.Birthday;
                    if (((!bIRTHDAY.HasValue ? 0 : ((bIRTHDAY.GetValueOrDefault() == birthday) ? 1 : 0)) != 0) && (this.baseInfo.Sex == e.Sex))
                    {
                        num = (this.baseInfo.CustomerName == e.Name) ? 1 : 0;
                        goto Label_0158;
                    }
                }

                num = 0;
                Label_0158:
                if ((num == 0) && (MessageBox.Show("当前身份证的信息和以前保存的信息不一致，是否替换？", "输入不一致", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                {
                    flag = true;
                }
                Label_0173:
                if (flag)
                {
                    this.baseInfo.HouseHoldAddress = e.Addr;
                    this.baseInfo.Nation = e.Nation;
                    this.baseInfo.Minority = e.Minority;
                    this.baseInfo.Birthday = new DateTime?(e.Birthday);
                    this.baseInfo.Sex = e.Sex;
                    this.baseInfo.CustomerName = e.Name;
                }
                this.m_IsLogIn = true;
                this.readCard.StopRead();
                this.SaveLoginInfo();

                // 蓝牙根据setting设定启动
                StartBT();
            }
        }

        private void run_notify_window(string tile, string content)
        {
            NotifyWindow window = new NotifyWindow(tile, content);
            window.SetDimensions(300, 200);
            window.Notify();
        }

        private void SaveLoginInfo()
        {
            this.ControlVisibleRefresh(this.LoginPictureBox, false);
            this.ControlVisibleRefresh(this.lblWelcome, true);
            this.ControlVisibleRefresh(this.panel_parent, false);
            

            this.ControlTextRefresh(this.lblWelcome, ClsToolTip.Welcome + this.baseInfo.CustomerName);
            ResetButton();
            //lblWelcome.BringToFront();
            RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
            if (!this.baseInfo.Birthday.HasValue)
            {
                DateTime? birthdayFromIDCardNo = GlbTools.GetBirthdayFromIDCardNo(this.baseInfo.IDCardNo);
                if (birthdayFromIDCardNo.HasValue)
                {
                    this.baseInfo.Birthday = new DateTime?(birthdayFromIDCardNo.Value);
                }
            }
            if (this.baseInfo.Birthday.HasValue)
            {
                int num = DateTime.Today.Year - this.baseInfo.Birthday.Value.Year;
                string str = (num < 0x41) ? ((num > 6) ? "1" : "2") : "4";
                if (string.IsNullOrEmpty(this.baseInfo.PopulationType))
                {
                    this.baseInfo.PopulationType = str;
                }
                else
                {
                    if (this.baseInfo.PopulationType == "1" || this.baseInfo.PopulationType == "2")
                    {
                        this.baseInfo.PopulationType = str;
                    }
                    else
                    {
                        if (str == "1" && this.baseInfo.PopulationType.Contains("2"))// 儿童疾病，儿童转一般人群
                        {
                            this.baseInfo.PopulationType = this.baseInfo.PopulationType.Replace("2", "");
                        }
                        if (str != "1")//拼接人群分类
                        {
                            this.baseInfo.PopulationType += "," + str;
                        }

                        // 去重排序
                        string[] populationType = this.baseInfo.PopulationType.TrimStart(',').TrimEnd(',').Split(',').Distinct().ToArray();
                        Array.Sort(populationType);
                        this.baseInfo.PopulationType = string.Join(",", populationType);
                    }
                }
            }
            if (!string.IsNullOrEmpty(this.baseInfo.ID.ToString()) && this.baseInfo.ID != 0)
            {
                IsFirstLogIn = false;
                this.baseInfo.IsUpdate = "Y";
                this.baseInfo.LastUpdateBy = ConfigHelper.GetNode("doctor");
                this.baseInfo.LastUpdateDate = new DateTime?(DateTime.Today);
                this.GetDepAndOrgName();
                archive_baseinfo.Update(this.baseInfo);
            }
            else
            {
                IsFirstLogIn = true;
                string pValue = "";
                this.baseInfo.IsUpdate = "Y";
                if (ConfigHelper.GetNode("archiveid", ref pValue))
                {
                    this.baseInfo.RecordID = pValue;
                    if (pValue.Length == 12)
                    {
                        this.baseInfo.ProvinceID = new decimal?(decimal.Parse(pValue.Substring(0, 2)));
                        this.baseInfo.CityID = new decimal?(decimal.Parse(pValue.Substring(0, 4)));
                        this.baseInfo.DistrictID = new decimal?(decimal.Parse(pValue.Substring(0, 6)));
                        this.baseInfo.TownID = new decimal?(decimal.Parse(pValue.Substring(0, 9)));
                        this.baseInfo.VillageID = new decimal?(decimal.Parse(pValue.Substring(0, 12)));
                    }
                }
                else
                {
                    this.baseInfo.RecordID = "000000000000";
                }
                string str3 = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";
                if (ConfigHelper.GetNode("orgCode", ref str5))
                {
                    this.baseInfo.OrgProvinceID = new decimal?(decimal.Parse(str5.Substring(0, 2)));
                    this.baseInfo.OrgCityID = new decimal?(decimal.Parse(str5.Substring(0, 4)));
                    this.baseInfo.OrgDistrictID = new decimal?(decimal.Parse(str5.Substring(0, 6)));
                    this.baseInfo.CreateUnit = new decimal?(decimal.Parse(str5));
                    if (str5.Length >= 9)
                    {
                        this.baseInfo.OrgTownID = new decimal?(decimal.Parse(str5.Substring(0, 9)));
                    }
                    if (str5.Length == 12)
                    {
                        this.baseInfo.OrgVillageID = new decimal?(decimal.Parse(str5.Substring(0, 12)));
                    }
                }
                if (ConfigHelper.GetNode("orgName", ref str6))
                {
                    this.baseInfo.CreateUnitName = str6;
                }
                if (ConfigHelper.GetNode("TownName", ref str3))
                {
                    this.baseInfo.TownName = str3;
                }
                if (ConfigHelper.GetNode("VillageName", ref str4))
                {
                    this.baseInfo.VillageName = str4;
                }
                string str7 = "";
                if (ConfigHelper.GetNode("doctor", ref str7))
                {
                    this.baseInfo.CreateBy = str7.ToString();
                    this.baseInfo.LastUpdateBy = str7.ToString();
                }
                string node = ConfigHelper.GetNode("doctorName");
                this.baseInfo.CreateMenName = node;
                this.baseInfo.Doctor = node;
                this.baseInfo.CreateDate = new DateTime?(DateTime.Today);
                this.baseInfo.ContactName = "";
                if (archive_baseinfo.Add(this.baseInfo) <= 0)
                {
                    MessageBox.Show("个人信息表新增失败", "新增个人信息", MessageBoxButtons.OK);
                }
                else
                {
                    this.baseInfo = archive_baseinfo.GetModel(idNo);
                }
            }
            //if (printerStatus == PrinterStatus.ON)
            //{
            //    ClsMsgWindow.SendDeviceInfo("lbPrinterTimes;LbPrinter");
            //    BarCodeDayBLL barcode_day = new BarCodeDayBLL();
            //    List<BarCodeDayModel> modelList = barcode_day.GetModelList(string.Format(" IDCardNo = '{0}' AND date(CreatedDate) = '{1}' ", this.baseInfo.IDCardNo, DateTime.Today.ToString("yyyy-MM-dd")));
            //    if (modelList.Count == 0)
            //    {
            //        BarCodeDayModel model = new BarCodeDayModel
            //        {
            //            IDCardNo = this.baseInfo.IDCardNo,
            //            CreateDate = new DateTime?(DateTime.Now)
            //        };
            //        this.barcodeText = barcode_day.Add(model).ToString("0000");
            //    }
            //    else
            //    {
            //        this.barcodeText = modelList[0].ID.ToString("0000");
            //    }
            //    this.printBarcode.Print();
            //}
        }
        
        private void setControlEnable(Control ctr, bool via)
        {
            Action<Control, bool> method = new Action<Control, bool>(this.setControlEnable);
            if (ctr.InvokeRequired)
            {
                ctr.Invoke(method, new object[] { ctr, via });
            }
            else
            {
                ctr.Enabled = false;
            }
        }
        
        public static void ShowTaskBar()
        {
            ShowWindow(FindWindow("Shell_TrayWnd", null), 5);
        }

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr handle, int cmdShow);

        private void TranslateMsg(string msg)
        {
            string[] strArray = msg.Split(new char[] { ':' });
            if ((strArray.Length == 2) && ((this.g_bt.ToString() == strArray[0]) || (strArray[0] == "FromCom")))
            {
                DeviceInfoModel devInfo = new DeviceInfoModel
                {
                    IDCardNo = idNo
                };

                devInfo.UpdateData = DateTime.Now.ToString();

                if (strArray[1] == "ok")
                {
                    bool flag = TranslateClsResult.TranslateToModel(devInfo, this.baseInfo);
                    DeviceInfoBLL deviceinfo2 = new DeviceInfoBLL();

                    if (!flag)
                    {
                        if ((devInfo.FirstName == "QCTBU") && (devInfo.DeviceType == "33"))
                        {
                            if (BU_FirstInsert != 0)
                            {
                                string str;
                                new DeviceInfoBLL().Update(TranslateClsResult.GetTableColumn(devInfo, devInfo.ChildTypeBu, out str), str, BU_FirstInsert);
                            }
                            else
                            {
                                BU_FirstInsert = deviceinfo2.Add(devInfo);
                            }
                        }
                        else if (deviceinfo2.Add(devInfo) != 0)
                        {
                            TranslateClsResult.set_tj_content(devInfo);
                        }
                    }
                }
                else
                {
                    this.WriteComPort("Abandon");
                }
            }
        }

        private void WriteComPort(string str)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(":" + str + "?");
            try
            {
                if (ComVisiable && this.port1.IsOpen)
                {
                    this.port1.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                throw;
            }
        }
        
        public static bool IsFirstLogIn { get; set; }

        public static PrinterStatus printerStatus { get; set; }

        public static string ProVersion { get; set; }

        public static string SoftVersion { get; set; }
        
        private void LoginPictureBox_Click(object sender, EventArgs e)
        {
            LoginAfter(new IDCardNoInputForm
            {
                StartPosition = FormStartPosition.CenterParent
            });
        }
                
        //心电图二维码
        private void btnECGcode_Click(object sender, EventArgs e)
        {
            Assembly sampleAssembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + @"\" + "QRcodePrint.exe");

            if (sampleAssembly != null)
            {
                Form loadForm = (Form)sampleAssembly.CreateInstance("QRcodePrint.ECGcode");
                PropertyInfo property = loadForm.GetType().GetProperty("IDCardNo", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (property != null)
                {
                    property.SetValue(loadForm, idNo, null);
                }

                loadForm.ShowDialog();
            }
        }
        
        private void LoginAfter(IDCardNoInputForm card)
        {
            if (!this.m_IsLogIn)
            {
                this.readCard.StopRead();
                this.WriteComPort("NC Login");

                if (card.ShowDialog() == DialogResult.OK)
                {
                    this.baseInfo = card.inputIdCardInfo;
                    idNo = this.baseInfo.IDCardNo;
                    bool flag1 = netStatus == "1";
                    this.m_IsLogIn = true;
                    this.LoginPictureBox.Visible = false;
                    this.panelWelcome.Visible = false;
                   
                    this.SaveLoginInfo();
                    this.WriteComPort("Read shs");
                    ConfigHelper.WriteNode("IDCardNo", idNo);

                    // 蓝牙根据setting设定启动
                    StartBT();

                    //CHITBTProcess = new Process { StartInfo = { FileName = @"BTQCTBT\BTQCTBT.exe", Arguments = idNo } };
                    //CHITBTProcess.Start();
                }
                else
                {
                    this.readCard.StartRead();
                    this.WriteComPort("User exit");
                }
            }
        }

        /// <summary>
        /// 指纹登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfingerLogin_Click(object sender, EventArgs e)
        {
            this.readCard.StopRead();
            this.WriteComPort("NC Login");

            FingerPrint.MainWindow loadForm = new FingerPrint.MainWindow();

            if (loadForm.ShowDialog() == DialogResult.OK)
            {
                LoginAfter(new IDCardNoInputForm
                {
                    StartPosition = FormStartPosition.CenterParent
                    ,
                    IDCardNo = loadForm.IDCardNo
                });
            }
            else
            {
                this.readCard.StartRead();
                this.WriteComPort("User exit");
            }
        }

        private void btnBackData_Click(object sender, EventArgs e)
        {
            FrmBackData back = new FrmBackData();
            back.ShowDialog();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            FingerPrint.MainWindow loadForm = new FingerPrint.MainWindow() { IDCardNo = this.baseInfo.IDCardNo, WindowType = "SAVE" };

            if (loadForm.CheckCanAdd())
            {
                loadForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("已经录入指纹，请勿重复录入");
            }
        }

        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void btnDefault_Click(object sender, EventArgs e)
        {
            Assembly sampleAssembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + @"\" + "SystemSet.exe");

            if (sampleAssembly != null)
            {
                Form loadForm = (Form)sampleAssembly.CreateInstance("SystemSet.SystemSetForm");

                loadForm.ShowDialog();
            }
        }
    }
}


