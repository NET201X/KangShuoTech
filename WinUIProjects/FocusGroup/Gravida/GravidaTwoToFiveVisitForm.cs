using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.Gravida
{
    using CommonControl;
    using KangShuoTech.Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Windows.Forms;
    using System.IO;
    using System.Drawing;
    using System.Configuration;

    public class GravidaTwoToFiveVisitForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<WomenGravidaTwoToFiveVisitModel> bindingManager;
        private IContainer components;
        private SingleItemT<WomenGravidaTwoToFiveVisitModel> fenlei;
        private string followTimes;
        private List<LoneCheckbox> Guides;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private ManyCheckboxs<WomenGravidaTwoToFiveVisitModel> zhidao;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private DateTimePicker dtpVisitDate;
        private Label label10;
        private Panel panel21;
        private Label label81;
        private TextBox tbWeek;
        private Label label4;
        private TextBox tbTalk;
        private Label label24;
        private Label label11;
        private Label label15;
        private Label label29;
        private Label label33;
        private Label label13;
        private Label label80;
        private Label label9;
        private Panel panel5;
        private Button btnWeight;
        private Label label31;
        private TextBox tbWeight;
        private Label label28;
        private Panel panel3;
        private Label label6;
        private TextBox tbTaixinl;
        private Label label7;
        private TextBox tbTaiwei;
        private Label label5;
        private Label label2;
        private Label label1;
        private TextBox tbFuwei;
        private Label label17;
        private TextBox tbGongdi;
        private Label label14;
        private Panel panel2;
        private Button btnHype;
        private Label label3;
        private TextBox tbHype;
        private Panel panel33;
        private Label label91;
        private TextBox tbHB;
        private TextBox tbNiaoDb;
        private TextBox tbAssistCheckOth;
        private Panel panel4;
        private TextBox tbFenleiEx;
        private RadioButton rdTypeHave;
        private RadioButton rdTypeNo;
        private Label label8;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox tbGuideOth;
        private Panel panel20;
        private RadioButton rdZhuanzhenHave;
        private RadioButton rdZhuanzhenNo;
        private Label label67;
        private TextBox tbZhuanzhenResult;
        private Label label68;
        private TextBox tbZhuanzhenKs;
        private DateTimePicker dtpNext;
        private Label label78;
        private Label label79;
        private TextBox tbDoctorMark;
        private Button btnSelectHB;
        private Label lbName;
        private Label lbTimes;
        private Label label16;
        private ComboBox cbSFFS;
        private Label label18;
        private TextBox tbCQJCJG;
        private Panel panel6;
        private CheckBox ckXQJC4;
        private CheckBox ckXQJC3;
        private CheckBox ckXQJC2;
        private CheckBox ckXQJC1;
        private Panel panel7;
        private RadioButton rdCheckNo;
        private RadioButton rdCheckYes;
        private Label label19;
        private Label label95;
        private TextBox txtReferralContacts;
        private Label label96;
        private TextBox txtReferralContactsTel;
        private Label label97;
        private Panel panel36;
        private RadioButton rdwdw;
        private RadioButton rddw;
        private JustSingleItem<WomenGravidaTwoToFiveVisitModel> zhuanzhen;
        private PictureBox picSignJm;
        private ManyCheckboxs<WomenGravidaTwoToFiveVisitModel> xueqing;
        private int HW_eOk = 0;
        private LinkLabel lkJm;
        private Label label20;
        private Panel panel8;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label12;//签名保存路径
        private string SignS = "";//本人或家属签名
        private string SignDoc = "";//随访医生签名
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Gravida/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Gravida//"; //签名保存路径

        public GravidaTwoToFiveVisitForm(string times)
        {
            this.InitializeComponent();
            this.followTimes = times;
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();
            this.InitEveryControl();
            this.EveryThingIsOk = false;
            this.tableLayoutPanel1.ResumeLayout();
        }

        private void AddCheckbox(string[] items)
        {
            if (items != null)
            {
                foreach (string str in items)
                {
                    CheckBox box = new CheckBox {
                        Anchor = AnchorStyles.Bottom,
                        AutoSize = true,
                        Text = str
                    };
                    this.flowLayoutPanel2.Controls.Add(box);
                    if (str == "其他")
                    {
                        this.Guides.Add(new LoneCheckbox(box, this.tbGuideOth));
                    }
                    else
                    {
                        this.Guides.Add(new LoneCheckbox(box));
                    }
                }
                this.flowLayoutPanel2.Controls.SetChildIndex(this.tbGuideOth, this.flowLayoutPanel2.Controls.Count - 1);
            }
        }

        private void btnHype_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "20") {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.Grv2to5Flo.HBloodPressure = new decimal?(int.Parse(select.m_Result.value1));
                this.Grv2to5Flo.LBloodPressure = new decimal?(int.Parse(select.m_Result.value2));
                this.tbHype.Text = string.Format("{0}/{1}", this.Grv2to5Flo.HBloodPressure.Value, this.Grv2to5Flo.LBloodPressure.Value);
            }
        }

        private void btnSelectHB_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "52") {
                ItemTypeName = "血红蛋白",
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tbHB.Text = select.m_Result.value1;
            }
        }

        private void btnWeight_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "22") {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tbWeight.Text = select.m_Result.value1;
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            bool flag = false;
            if (this.dtpNext.Value.Date < this.dtpVisitDate.Value.Date)
            {
                flag = true;
                this.SaveDataInfo = "下次随访日期小于随访日期!";
            }
            if (this.tbWeek.Text == "")
            {
                this.SaveDataInfo="孕周不能为空";
                flag = true;
            }
            if ((!this.fenlei.ErrorInput && !this.zhidao.ErrorInput) && (!this.bindingManager.ErrorInput && !flag))
            {
                return ChildFormStatus.NoErrorInput;
            }
            return ChildFormStatus.HasErrorInput;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmGrvTwoFive_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(SignPath))
            {
                Directory.CreateDirectory(SignPath);
            }
          
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void InitEveryControl()
        {
            this.Guides = new List<LoneCheckbox>();
            string[] items = null;
            if (this.followTimes == "2")
            {
                items = new string[] { "生活方式", "营养", "心理", "运动", "其他" };
            }
            if (this.followTimes == "3")
            {
                items = new string[] { "生活方式", "营养", "心理", "运动", "自我监护", "母乳喂养", "其他" };
            }
            if (this.followTimes == "4")
            {
                items = new string[] { "生活方式", "营养", "心理", "运动", "自我监测", "分娩准备", "母乳喂养", "其他" };
            }
            if (this.followTimes == "5")
            {
                items = new string[] { "生活方式", "营养", "心理", "运动", "自我监测", "分娩准备", "母乳喂养", "其他" };
            }
            this.AddCheckbox(items);
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("PregancyWeeks", 70M, false));
            this.inputRanges.Add(new InputRangeDec("UteruslowHeight", 100M));
            this.inputRanges.Add(new InputRangeDec("AbdominalCirumference", 200M));
            this.inputRanges.Add(new InputRangeDec("FHR", 200M, false));
            this.inputRanges.Add(new InputRangeDec("HB", 100M));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("ChiefComPlaint", 200));
            this.inputrange_str.Add(new InputRangeStr("FetusPosition", 100));
            this.inputrange_str.Add(new InputRangeStr("AssistantExam", 200));
            this.inputrange_str.Add(new InputRangeStr("ClassificationEx", 200));
            this.inputrange_str.Add(new InputRangeStr("Advisinther", 200));
            this.inputrange_str.Add(new InputRangeStr("ReferralReason", 500));
            this.inputrange_str.Add(new InputRangeStr("ReferralOrg", 80));
            this.inputrange_str.Add(new InputRangeStr("ClassificationEx", 200));
            this.inputrange_str.Add(new InputRangeStr("PRO", 10));
            if (this.followTimes == "2")
            {
                this.panel6.Visible = true;
            }
            else
            {
                this.panel6.Visible = false;
            }
        }

        public void InitEveryThing()
        {
            List<WomenGravidaTwoToFiveVisitModel> modelList = new WomenGravidaTwoToFiveVisitBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND Times = {1}", this.Model.IDCardNo, this.followTimes));
            if (modelList.Count > 0)
            {
                this.Grv2to5Flo = modelList[0];
            }
            if (this.Grv2to5Flo == null)
            {
                this.Grv2to5Flo = new WomenGravidaTwoToFiveVisitModel();
                this.Grv2to5Flo.IDCardNo = this.Model.IDCardNo;
                this.Grv2to5Flo.RecordID = this.Model.RecordID;
                this.Grv2to5Flo.CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.Grv2to5Flo.CreatedDate = new DateTime?(DateTime.Today);
                this.Grv2to5Flo.FollowupDate = new DateTime?(DateTime.Today);
                this.Grv2to5Flo.Times = decimal.Parse(this.followTimes);
            }
            else
            {
                this.Grv2to5Flo.LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.Grv2to5Flo.LastUpdateDate = new DateTime?(DateTime.Today);
            }
            this.bindingManager = new SimpleBindingManager<WomenGravidaTwoToFiveVisitModel>(this.inputRanges, this.inputrange_str, this.Grv2to5Flo);
            if (string.IsNullOrEmpty(this.Grv2to5Flo.FollowUpDoctor))
            {
                this.Grv2to5Flo.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
            }
            if (!this.Grv2to5Flo.Weight.HasValue)
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                if (devData.HasValue)
                {
                    this.Grv2to5Flo.Weight = new decimal?(decimal.Parse(devData.value1));
                }
            }
            if (!this.Grv2to5Flo.HBloodPressure.HasValue)
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20", "血压");
                if (_result2.HasValue)
                {
                    this.Grv2to5Flo.HBloodPressure = new decimal?(int.Parse(_result2.value1));
                    this.Grv2to5Flo.LBloodPressure = new decimal?(int.Parse(_result2.value2));
                }
            }
            if (!this.Grv2to5Flo.HB.HasValue)
            {
                stru_result _result3 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "52", "血红蛋白");
                if (_result3.HasValue)
                {
                    this.Grv2to5Flo.HB = new decimal?(decimal.Parse(_result3.value1));
                }
            }
            this.srcData = GlbTools.DeepCopy(this.Grv2to5Flo);
            this.lbTimes.Text = string.Format("第{0}次产前随访", this.followTimes);
            this.lbName.Text = string.Format("姓名: {0}", this.Model.CustomerName);
            if (this.Grv2to5Flo.FollowupDate.HasValue)
            {
                this.dtpVisitDate.Value = this.Grv2to5Flo.FollowupDate.Value;
            }
            this.bindingManager.SimpleBinding(this.tbWeight, "Weight", true);
            if (this.Grv2to5Flo.HBloodPressure.HasValue && this.Grv2to5Flo.LBloodPressure.HasValue)
            {
                this.tbHype.Text = string.Format("{0}/{1}", this.Grv2to5Flo.HBloodPressure.Value, this.Grv2to5Flo.LBloodPressure.Value);
            }
            this.bindingManager.SimpleBinding(this.tbNiaoDb, "PRO", false);
            this.bindingManager.SimpleBinding(this.tbWeek, "PregancyWeeks", true);
            this.bindingManager.SimpleBinding(this.tbTalk, "ChiefComPlaint", false);
            this.bindingManager.SimpleBinding(this.tbGongdi, "UteruslowHeight", true);
            this.bindingManager.SimpleBinding(this.tbFuwei, "AbdominalCirumference", true);
            this.bindingManager.SimpleBinding(this.tbTaiwei, "FetusPosition", false);
            this.bindingManager.SimpleBinding(this.tbTaixinl, "FHR", true);
            this.bindingManager.SimpleBinding(this.tbHB, "HB", true);
            this.bindingManager.SimpleBinding(this.tbAssistCheckOth, "AssistantExam", false);
            this.bindingManager.SimpleBinding(this.tbCQJCJG, "PrenatalOrg", false);
            SingleItemT<WomenGravidaTwoToFiveVisitModel> mt = new SingleItemT<WomenGravidaTwoToFiveVisitModel>(this.Grv2to5Flo) {
                Name = "分类",
                Usual = this.rdTypeNo,
                Unusual = this.rdTypeHave,
                Info = this.tbFenleiEx,
                MaxBytesCount = 200
            };
            this.fenlei = mt;
            this.fenlei.BindProperty("Classification", "ClassificationEx");
            this.zhidao = new ManyCheckboxs<WomenGravidaTwoToFiveVisitModel>(this.Grv2to5Flo, 200);
            for (int i = 0; i < this.Guides.Count; i++)
            {
                this.zhidao.AddCk(this.Guides[i]);
            }
            this.zhidao.BindingProperty("Advising", "AdvisingOther");
            JustSingleItem<WomenGravidaTwoToFiveVisitModel> item = new JustSingleItem<WomenGravidaTwoToFiveVisitModel>(this.Grv2to5Flo) {
                R1 = this.rdZhuanzhenNo,
                R2 = this.rdZhuanzhenHave
            };
            this.zhuanzhen = item;
            this.zhuanzhen.statusChanged = (Action<string>) Delegate.Combine(this.zhuanzhen.statusChanged, new Action<string>(this.JustZhuanzhenChanged));
            this.zhuanzhen.BindProperty("Referral");
            this.bindingManager.SimpleBinding(this.tbZhuanzhenResult, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenKs, "ReferralOrg", false);

            if (this.Grv2to5Flo.NextFollowupDate.HasValue)
            {
                this.dtpNext.Value = this.Grv2to5Flo.NextFollowupDate.Value;
            }

            this.bindingManager.SimpleBinding(this.tbDoctorMark, "FollowUpDoctor", false);
            this.bindingManager.SimpleBinding(this.txtReferralContacts, "ReferralContacts", false);
            this.bindingManager.SimpleBinding(this.txtReferralContactsTel, "ReferralContactsTel", false);
            if (this.Grv2to5Flo.ReferralResult == "1")
            {
                this.rddw.Checked = true;
            }
            else if (this.Grv2to5Flo.ReferralResult == "2")
            {
                this.rdwdw.Checked = true;
            }
            if (!string.IsNullOrEmpty(this.Grv2to5Flo.FollowupWay))
            {
                this.cbSFFS.SelectedIndex =int.Parse(this.Grv2to5Flo.FollowupWay.ToString())-1;
            }

            if (this.Grv2to5Flo.FreeSerumCheck == "1")
            {
                this.rdCheckYes.Checked = true;
            }
            else if (this.Grv2to5Flo.FreeSerumCheck == "2")
            {
                this.rdCheckNo.Checked = true;
            }
            xueqing = new ManyCheckboxs<WomenGravidaTwoToFiveVisitModel>(this.Grv2to5Flo);
            xueqing.AddCk(new CheckBox[]{this.ckXQJC1,this.ckXQJC2,this.ckXQJC3});
            xueqing.AddCk(this.ckXQJC4,true);
            xueqing.BindingProperty("SerumCheckResult", "");

            //签名初始化
            this.SignS = string.Format("{0}{1}_{2}.png", SignPath, Model.IDCardNo, "PrenatalS_" + this.followTimes);
            if (File.Exists(SignS))
            {
                Image imgeb = Image.FromFile(this.SignS);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSignJm.Image = bmp;
                picSignJm.Show();
                imgeb.Dispose();
                this.lkJm.Enabled = true;
                picSignJm.BackColor = Color.White;
            }
            this.SignDoc = string.Format("{0}{1}_{2}_Doc.png", SignPath, Model.IDCardNo, "PrenatalS_" + this.followTimes);
            if (File.Exists(SignDoc))
            {
                Image imgeb = Image.FromFile(this.SignDoc);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSignYs.Image = bmp;
                picSignYs.Show();
                imgeb.Dispose();
                this.lkYs.Enabled = true;
                picSignYs.BackColor = Color.White;
            }
           
            this.EveryThingIsOk = true;
        }

        private void IniPenSignByContrl(AxHWPenSignLib.AxHWPenSign axHWPenSign)
        {
            const UInt32 intColor = 0xC8F8DE;
            axHWPenSign.HWSetBkColor(intColor);
            axHWPenSign.HWSetCtlFrame(2, 0x000000);
            axHWPenSign.HWSetExtWndHandle(this.Handle.ToInt32());
            axHWPenSign.HWSetPenWidth(1);
        }
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpVisitDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTalk = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnWeight = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTaixinl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTaiwei = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFuwei = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbGongdi = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHype = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHype = new System.Windows.Forms.TextBox();
            this.panel33 = new System.Windows.Forms.Panel();
            this.label91 = new System.Windows.Forms.Label();
            this.tbHB = new System.Windows.Forms.TextBox();
            this.btnSelectHB = new System.Windows.Forms.Button();
            this.tbNiaoDb = new System.Windows.Forms.TextBox();
            this.tbAssistCheckOth = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbFenleiEx = new System.Windows.Forms.TextBox();
            this.rdTypeHave = new System.Windows.Forms.RadioButton();
            this.rdTypeNo = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tbGuideOth = new System.Windows.Forms.TextBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.rdZhuanzhenHave = new System.Windows.Forms.RadioButton();
            this.rdZhuanzhenNo = new System.Windows.Forms.RadioButton();
            this.label67 = new System.Windows.Forms.Label();
            this.tbZhuanzhenResult = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.tbDoctorMark = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label81 = new System.Windows.Forms.Label();
            this.tbWeek = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbSFFS = new System.Windows.Forms.ComboBox();
            this.tbCQJCJG = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdCheckNo = new System.Windows.Forms.RadioButton();
            this.rdCheckYes = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ckXQJC1 = new System.Windows.Forms.CheckBox();
            this.ckXQJC4 = new System.Windows.Forms.CheckBox();
            this.ckXQJC2 = new System.Windows.Forms.CheckBox();
            this.ckXQJC3 = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.txtReferralContacts = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.txtReferralContactsTel = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.panel36 = new System.Windows.Forms.Panel();
            this.rdwdw = new System.Windows.Forms.RadioButton();
            this.rddw = new System.Windows.Forms.RadioButton();
            this.tbZhuanzhenKs = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lkJm = new System.Windows.Forms.LinkLabel();
            this.picSignJm = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbTimes = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJm)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.lbTimes);
            this.panel1.Location = new System.Drawing.Point(59, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1383, 678);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.9005F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.46872F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.50054F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.76103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.9005F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.46872F));
            this.tableLayoutPanel1.Controls.Add(this.dtpVisitDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbTalk, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label24, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label29, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label33, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label28, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel33, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.tbNiaoDb, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbAssistCheckOth, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel20, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.label67, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenResult, 3, 14);
            this.tableLayoutPanel1.Controls.Add(this.label68, 4, 14);
            this.tableLayoutPanel1.Controls.Add(this.dtpNext, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.label78, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.label79, 2, 16);
            this.tableLayoutPanel1.Controls.Add(this.tbDoctorMark, 3, 16);
            this.tableLayoutPanel1.Controls.Add(this.label80, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel21, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label16, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbSFFS, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbCQJCJG, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.label95, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.txtReferralContacts, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.label96, 2, 15);
            this.tableLayoutPanel1.Controls.Add(this.txtReferralContactsTel, 3, 15);
            this.tableLayoutPanel1.Controls.Add(this.label97, 4, 15);
            this.tableLayoutPanel1.Controls.Add(this.panel36, 5, 15);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenKs, 5, 14);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.label18, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(48, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 18;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1288, 633);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtpVisitDate
            // 
            this.dtpVisitDate.Location = new System.Drawing.Point(182, 3);
            this.dtpVisitDate.Name = "dtpVisitDate";
            this.dtpVisitDate.Size = new System.Drawing.Size(196, 30);
            this.dtpVisitDate.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F);
            this.label10.Location = new System.Drawing.Point(77, 481);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 181;
            this.label10.Text = "转    诊:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(3, 56);
            this.label4.Name = "label4";
            this.tableLayoutPanel1.SetRowSpan(this.label4, 2);
            this.label4.Size = new System.Drawing.Size(173, 20);
            this.label4.TabIndex = 112;
            this.label4.Text = "主    诉:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbTalk
            // 
            this.tbTalk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbTalk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbTalk, 5);
            this.tbTalk.ForeColor = System.Drawing.Color.Black;
            this.tbTalk.Location = new System.Drawing.Point(182, 45);
            this.tbTalk.MaxLength = 200;
            this.tbTalk.Multiline = true;
            this.tbTalk.Name = "tbTalk";
            this.tableLayoutPanel1.SetRowSpan(this.tbTalk, 2);
            this.tbTalk.Size = new System.Drawing.Size(793, 42);
            this.tbTalk.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F);
            this.label24.Location = new System.Drawing.Point(3, 336);
            this.label24.Name = "label24";
            this.tableLayoutPanel1.SetRowSpan(this.label24, 2);
            this.label24.Size = new System.Drawing.Size(173, 20);
            this.label24.TabIndex = 135;
            this.label24.Text = "其他辅助检查*:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F);
            this.label11.Location = new System.Drawing.Point(77, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 147;
            this.label11.Text = "尿 蛋 白:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F);
            this.label15.Location = new System.Drawing.Point(77, 255);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 20);
            this.label15.TabIndex = 146;
            this.label15.Text = "血红蛋白:";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 15F);
            this.label29.Location = new System.Drawing.Point(77, 213);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(99, 20);
            this.label29.TabIndex = 162;
            this.label29.Text = "血    压:";
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F);
            this.label33.Location = new System.Drawing.Point(77, 380);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 20);
            this.label33.TabIndex = 164;
            this.label33.Text = "分    类:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F);
            this.label13.Location = new System.Drawing.Point(77, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 100;
            this.label13.Text = "随访日期:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F);
            this.label9.Location = new System.Drawing.Point(77, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 153;
            this.label9.Text = "体    重:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btnWeight);
            this.panel5.Controls.Add(this.label31);
            this.panel5.Controls.Add(this.tbWeight);
            this.panel5.Location = new System.Drawing.Point(179, 90);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(250, 40);
            this.panel5.TabIndex = 3;
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(112, 4);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(44, 26);
            this.btnWeight.TabIndex = 147;
            this.btnWeight.Text = ".....";
            this.btnWeight.UseVisualStyleBackColor = true;
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 15F);
            this.label31.Location = new System.Drawing.Point(178, 8);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 20);
            this.label31.TabIndex = 145;
            this.label31.Text = "㎏";
            // 
            // tbWeight
            // 
            this.tbWeight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWeight.ForeColor = System.Drawing.Color.Black;
            this.tbWeight.Location = new System.Drawing.Point(7, 2);
            this.tbWeight.MaxLength = 6;
            this.tbWeight.Multiline = true;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.ReadOnly = true;
            this.tbWeight.Size = new System.Drawing.Size(97, 30);
            this.tbWeight.TabIndex = 111;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 15F);
            this.label28.Location = new System.Drawing.Point(3, 156);
            this.label28.Name = "label28";
            this.tableLayoutPanel1.SetRowSpan(this.label28, 2);
            this.label28.Size = new System.Drawing.Size(173, 20);
            this.label28.TabIndex = 161;
            this.label28.Text = "产科检查:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.tbTaixinl);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.tbTaiwei);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.tbFuwei);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.tbGongdi);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(179, 130);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(1109, 73);
            this.panel3.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F);
            this.label6.Location = new System.Drawing.Point(560, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 157;
            this.label6.Text = "次/分钟";
            // 
            // tbTaixinl
            // 
            this.tbTaixinl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbTaixinl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTaixinl.ForeColor = System.Drawing.Color.Black;
            this.tbTaixinl.Location = new System.Drawing.Point(122, 40);
            this.tbTaixinl.MaxLength = 3;
            this.tbTaixinl.Name = "tbTaixinl";
            this.tbTaixinl.Size = new System.Drawing.Size(91, 30);
            this.tbTaixinl.TabIndex = 156;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F);
            this.label7.Location = new System.Drawing.Point(346, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 155;
            this.label7.Text = "胎 心 率:";
            // 
            // tbTaiwei
            // 
            this.tbTaiwei.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbTaiwei.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTaiwei.ForeColor = System.Drawing.Color.Black;
            this.tbTaiwei.Location = new System.Drawing.Point(454, 6);
            this.tbTaiwei.MaxLength = 15;
            this.tbTaiwei.Name = "tbTaiwei";
            this.tbTaiwei.Size = new System.Drawing.Size(91, 30);
            this.tbTaiwei.TabIndex = 153;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F);
            this.label5.Location = new System.Drawing.Point(9, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 152;
            this.label5.Text = "胎    位:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(560, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 151;
            this.label2.Text = "㎝";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(224, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 150;
            this.label1.Text = "㎝";
            // 
            // tbFuwei
            // 
            this.tbFuwei.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbFuwei.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFuwei.ForeColor = System.Drawing.Color.Black;
            this.tbFuwei.Location = new System.Drawing.Point(122, 5);
            this.tbFuwei.MaxLength = 3;
            this.tbFuwei.Name = "tbFuwei";
            this.tbFuwei.Size = new System.Drawing.Size(91, 30);
            this.tbFuwei.TabIndex = 145;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F);
            this.label17.Location = new System.Drawing.Point(346, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 20);
            this.label17.TabIndex = 144;
            this.label17.Text = "腹    围:";
            // 
            // tbGongdi
            // 
            this.tbGongdi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbGongdi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGongdi.ForeColor = System.Drawing.Color.Black;
            this.tbGongdi.Location = new System.Drawing.Point(454, 39);
            this.tbGongdi.MaxLength = 3;
            this.tbGongdi.Name = "tbGongdi";
            this.tbGongdi.Size = new System.Drawing.Size(91, 30);
            this.tbGongdi.TabIndex = 143;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F);
            this.label14.Location = new System.Drawing.Point(9, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 20);
            this.label14.TabIndex = 129;
            this.label14.Text = "宫底高度:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.btnHype);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbHype);
            this.panel2.Location = new System.Drawing.Point(179, 203);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 41);
            this.panel2.TabIndex = 5;
            // 
            // btnHype
            // 
            this.btnHype.Location = new System.Drawing.Point(151, 6);
            this.btnHype.Name = "btnHype";
            this.btnHype.Size = new System.Drawing.Size(56, 32);
            this.btnHype.TabIndex = 146;
            this.btnHype.Text = ".....";
            this.btnHype.UseVisualStyleBackColor = true;
            this.btnHype.Click += new System.EventHandler(this.btnHype_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(223, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 145;
            this.label3.Text = "mmHg";
            // 
            // tbHype
            // 
            this.tbHype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbHype.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHype.ForeColor = System.Drawing.Color.Black;
            this.tbHype.Location = new System.Drawing.Point(3, 3);
            this.tbHype.Multiline = true;
            this.tbHype.Name = "tbHype";
            this.tbHype.ReadOnly = true;
            this.tbHype.Size = new System.Drawing.Size(141, 35);
            this.tbHype.TabIndex = 111;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.label91);
            this.panel33.Controls.Add(this.tbHB);
            this.panel33.Controls.Add(this.btnSelectHB);
            this.panel33.Location = new System.Drawing.Point(179, 244);
            this.panel33.Margin = new System.Windows.Forms.Padding(0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(224, 43);
            this.panel33.TabIndex = 6;
            // 
            // label91
            // 
            this.label91.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("宋体", 15F);
            this.label91.Location = new System.Drawing.Point(158, 13);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(39, 20);
            this.label91.TabIndex = 169;
            this.label91.Text = "g/L";
            // 
            // tbHB
            // 
            this.tbHB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHB.ForeColor = System.Drawing.Color.Black;
            this.tbHB.Location = new System.Drawing.Point(4, 3);
            this.tbHB.MaxLength = 3;
            this.tbHB.Multiline = true;
            this.tbHB.Name = "tbHB";
            this.tbHB.Size = new System.Drawing.Size(98, 37);
            this.tbHB.TabIndex = 168;
            // 
            // btnSelectHB
            // 
            this.btnSelectHB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectHB.Location = new System.Drawing.Point(110, 8);
            this.btnSelectHB.Name = "btnSelectHB";
            this.btnSelectHB.Size = new System.Drawing.Size(40, 28);
            this.btnSelectHB.TabIndex = 8;
            this.btnSelectHB.Text = "...";
            this.btnSelectHB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectHB.UseVisualStyleBackColor = true;
            this.btnSelectHB.Click += new System.EventHandler(this.btnSelectHB_Click);
            // 
            // tbNiaoDb
            // 
            this.tbNiaoDb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNiaoDb.ForeColor = System.Drawing.Color.Black;
            this.tbNiaoDb.Location = new System.Drawing.Point(182, 290);
            this.tbNiaoDb.MaxLength = 20;
            this.tbNiaoDb.Multiline = true;
            this.tbNiaoDb.Name = "tbNiaoDb";
            this.tbNiaoDb.Size = new System.Drawing.Size(174, 29);
            this.tbNiaoDb.TabIndex = 9;
            // 
            // tbAssistCheckOth
            // 
            this.tbAssistCheckOth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAssistCheckOth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbAssistCheckOth, 5);
            this.tbAssistCheckOth.ForeColor = System.Drawing.Color.Black;
            this.tbAssistCheckOth.Location = new System.Drawing.Point(182, 325);
            this.tbAssistCheckOth.MaxLength = 200;
            this.tbAssistCheckOth.Multiline = true;
            this.tbAssistCheckOth.Name = "tbAssistCheckOth";
            this.tableLayoutPanel1.SetRowSpan(this.tbAssistCheckOth, 2);
            this.tbAssistCheckOth.Size = new System.Drawing.Size(793, 43);
            this.tbAssistCheckOth.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 5);
            this.panel4.Controls.Add(this.tbFenleiEx);
            this.panel4.Controls.Add(this.rdTypeHave);
            this.panel4.Controls.Add(this.rdTypeNo);
            this.panel4.Location = new System.Drawing.Point(179, 371);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1109, 38);
            this.panel4.TabIndex = 12;
            // 
            // tbFenleiEx
            // 
            this.tbFenleiEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFenleiEx.ForeColor = System.Drawing.Color.Black;
            this.tbFenleiEx.Location = new System.Drawing.Point(187, 2);
            this.tbFenleiEx.MaxLength = 20;
            this.tbFenleiEx.Multiline = true;
            this.tbFenleiEx.Name = "tbFenleiEx";
            this.tbFenleiEx.ReadOnly = true;
            this.tbFenleiEx.Size = new System.Drawing.Size(609, 34);
            this.tbFenleiEx.TabIndex = 111;
            // 
            // rdTypeHave
            // 
            this.rdTypeHave.AutoSize = true;
            this.rdTypeHave.Location = new System.Drawing.Point(110, 6);
            this.rdTypeHave.Name = "rdTypeHave";
            this.rdTypeHave.Size = new System.Drawing.Size(67, 24);
            this.rdTypeHave.TabIndex = 110;
            this.rdTypeHave.TabStop = true;
            this.rdTypeHave.Text = "异常";
            this.rdTypeHave.UseVisualStyleBackColor = true;
            // 
            // rdTypeNo
            // 
            this.rdTypeNo.AutoSize = true;
            this.rdTypeNo.Location = new System.Drawing.Point(7, 6);
            this.rdTypeNo.Name = "rdTypeNo";
            this.rdTypeNo.Size = new System.Drawing.Size(107, 24);
            this.rdTypeNo.TabIndex = 109;
            this.rdTypeNo.TabStop = true;
            this.rdTypeNo.Text = "未见异常";
            this.rdTypeNo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F);
            this.label8.Location = new System.Drawing.Point(3, 424);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 20);
            this.label8.TabIndex = 179;
            this.label8.Text = "指    导:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 5);
            this.flowLayoutPanel2.Controls.Add(this.tbGuideOth);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(179, 409);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(799, 60);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // tbGuideOth
            // 
            this.tbGuideOth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGuideOth.ForeColor = System.Drawing.Color.Black;
            this.tbGuideOth.Location = new System.Drawing.Point(3, 3);
            this.tbGuideOth.MaxLength = 200;
            this.tbGuideOth.Multiline = true;
            this.tbGuideOth.Name = "tbGuideOth";
            this.tbGuideOth.ReadOnly = true;
            this.tbGuideOth.Size = new System.Drawing.Size(793, 41);
            this.tbGuideOth.TabIndex = 107;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.rdZhuanzhenHave);
            this.panel20.Controls.Add(this.rdZhuanzhenNo);
            this.panel20.Location = new System.Drawing.Point(182, 475);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(174, 32);
            this.panel20.TabIndex = 14;
            // 
            // rdZhuanzhenHave
            // 
            this.rdZhuanzhenHave.AutoSize = true;
            this.rdZhuanzhenHave.Location = new System.Drawing.Point(91, 3);
            this.rdZhuanzhenHave.Name = "rdZhuanzhenHave";
            this.rdZhuanzhenHave.Size = new System.Drawing.Size(47, 24);
            this.rdZhuanzhenHave.TabIndex = 150;
            this.rdZhuanzhenHave.TabStop = true;
            this.rdZhuanzhenHave.Text = "有";
            this.rdZhuanzhenHave.UseVisualStyleBackColor = true;
            // 
            // rdZhuanzhenNo
            // 
            this.rdZhuanzhenNo.AutoSize = true;
            this.rdZhuanzhenNo.Location = new System.Drawing.Point(4, 3);
            this.rdZhuanzhenNo.Name = "rdZhuanzhenNo";
            this.rdZhuanzhenNo.Size = new System.Drawing.Size(47, 24);
            this.rdZhuanzhenNo.TabIndex = 149;
            this.rdZhuanzhenNo.TabStop = true;
            this.rdZhuanzhenNo.Text = "无";
            this.rdZhuanzhenNo.UseVisualStyleBackColor = true;
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("宋体", 15F);
            this.label67.Location = new System.Drawing.Point(526, 481);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(99, 20);
            this.label67.TabIndex = 184;
            this.label67.Text = "原    因:";
            // 
            // tbZhuanzhenResult
            // 
            this.tbZhuanzhenResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenResult.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenResult.Location = new System.Drawing.Point(631, 475);
            this.tbZhuanzhenResult.MaxLength = 20;
            this.tbZhuanzhenResult.Multiline = true;
            this.tbZhuanzhenResult.Name = "tbZhuanzhenResult";
            this.tbZhuanzhenResult.ReadOnly = true;
            this.tbZhuanzhenResult.Size = new System.Drawing.Size(159, 32);
            this.tbZhuanzhenResult.TabIndex = 15;
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("宋体", 15F);
            this.label68.Location = new System.Drawing.Point(913, 481);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(119, 20);
            this.label68.TabIndex = 186;
            this.label68.Text = "机构及科室:";
            // 
            // dtpNext
            // 
            this.dtpNext.Location = new System.Drawing.Point(182, 555);
            this.dtpNext.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(196, 30);
            this.dtpNext.TabIndex = 17;
            // 
            // label78
            // 
            this.label78.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("宋体", 15F);
            this.label78.Location = new System.Drawing.Point(37, 556);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(139, 20);
            this.label78.TabIndex = 188;
            this.label78.Text = "下次随访日期:";
            // 
            // label79
            // 
            this.label79.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("宋体", 15F);
            this.label79.Location = new System.Drawing.Point(486, 556);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(139, 20);
            this.label79.TabIndex = 190;
            this.label79.Text = "随访医生签名:";
            this.label79.Visible = false;
            // 
            // tbDoctorMark
            // 
            this.tbDoctorMark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDoctorMark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDoctorMark.ForeColor = System.Drawing.Color.Black;
            this.tbDoctorMark.Location = new System.Drawing.Point(631, 558);
            this.tbDoctorMark.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tbDoctorMark.MaxLength = 20;
            this.tbDoctorMark.Multiline = true;
            this.tbDoctorMark.Name = "tbDoctorMark";
            this.tbDoctorMark.Size = new System.Drawing.Size(159, 23);
            this.tbDoctorMark.TabIndex = 18;
            this.tbDoctorMark.Visible = false;
            // 
            // label80
            // 
            this.label80.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("宋体", 15F);
            this.label80.Location = new System.Drawing.Point(933, 11);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(99, 20);
            this.label80.TabIndex = 167;
            this.label80.Text = "填表孕周:";
            // 
            // panel21
            // 
            this.panel21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel21.Controls.Add(this.label81);
            this.panel21.Controls.Add(this.tbWeek);
            this.panel21.Location = new System.Drawing.Point(1035, 0);
            this.panel21.Margin = new System.Windows.Forms.Padding(0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(253, 42);
            this.panel21.TabIndex = 1;
            // 
            // label81
            // 
            this.label81.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("宋体", 15F);
            this.label81.Location = new System.Drawing.Point(220, 14);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(29, 20);
            this.label81.TabIndex = 145;
            this.label81.Text = "周";
            // 
            // tbWeek
            // 
            this.tbWeek.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbWeek.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWeek.ForeColor = System.Drawing.Color.Black;
            this.tbWeek.Location = new System.Drawing.Point(41, 7);
            this.tbWeek.MaxLength = 2;
            this.tbWeek.Multiline = true;
            this.tbWeek.Name = "tbWeek";
            this.tbWeek.Size = new System.Drawing.Size(140, 30);
            this.tbWeek.TabIndex = 111;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F);
            this.label16.Location = new System.Drawing.Point(526, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 191;
            this.label16.Text = "随访方式:";
            // 
            // cbSFFS
            // 
            this.cbSFFS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSFFS.FormattingEnabled = true;
            this.cbSFFS.Items.AddRange(new object[] {
            "门诊",
            "家庭",
            "电话"});
            this.cbSFFS.Location = new System.Drawing.Point(631, 3);
            this.cbSFFS.Name = "cbSFFS";
            this.cbSFFS.Size = new System.Drawing.Size(159, 28);
            this.cbSFFS.TabIndex = 192;
            // 
            // tbCQJCJG
            // 
            this.tbCQJCJG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCQJCJG.ForeColor = System.Drawing.Color.Black;
            this.tbCQJCJG.Location = new System.Drawing.Point(631, 93);
            this.tbCQJCJG.Name = "tbCQJCJG";
            this.tbCQJCJG.Size = new System.Drawing.Size(159, 30);
            this.tbCQJCJG.TabIndex = 194;
            // 
            // panel6
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 3);
            this.panel6.Controls.Add(this.rdCheckNo);
            this.panel6.Controls.Add(this.rdCheckYes);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label19);
            this.panel6.Location = new System.Drawing.Point(631, 206);
            this.panel6.Name = "panel6";
            this.tableLayoutPanel1.SetRowSpan(this.panel6, 3);
            this.panel6.Size = new System.Drawing.Size(644, 86);
            this.panel6.TabIndex = 195;
            // 
            // rdCheckNo
            // 
            this.rdCheckNo.AutoSize = true;
            this.rdCheckNo.Location = new System.Drawing.Point(311, 4);
            this.rdCheckNo.Name = "rdCheckNo";
            this.rdCheckNo.Size = new System.Drawing.Size(47, 24);
            this.rdCheckNo.TabIndex = 150;
            this.rdCheckNo.TabStop = true;
            this.rdCheckNo.Text = "否";
            this.rdCheckNo.UseVisualStyleBackColor = true;
            this.rdCheckNo.CheckedChanged += new System.EventHandler(this.rdCheckNo_CheckedChanged);
            // 
            // rdCheckYes
            // 
            this.rdCheckYes.AutoSize = true;
            this.rdCheckYes.Location = new System.Drawing.Point(226, 3);
            this.rdCheckYes.Name = "rdCheckYes";
            this.rdCheckYes.Size = new System.Drawing.Size(47, 24);
            this.rdCheckYes.TabIndex = 149;
            this.rdCheckYes.TabStop = true;
            this.rdCheckYes.Text = "是";
            this.rdCheckYes.UseVisualStyleBackColor = true;
            this.rdCheckYes.CheckedChanged += new System.EventHandler(this.rdCheckYes_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ckXQJC1);
            this.panel7.Controls.Add(this.ckXQJC4);
            this.panel7.Controls.Add(this.ckXQJC2);
            this.panel7.Controls.Add(this.ckXQJC3);
            this.panel7.Enabled = false;
            this.panel7.Location = new System.Drawing.Point(18, 38);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(623, 45);
            this.panel7.TabIndex = 15;
            // 
            // ckXQJC1
            // 
            this.ckXQJC1.AutoSize = true;
            this.ckXQJC1.Location = new System.Drawing.Point(4, 5);
            this.ckXQJC1.Name = "ckXQJC1";
            this.ckXQJC1.Size = new System.Drawing.Size(128, 24);
            this.ckXQJC1.TabIndex = 16;
            this.ckXQJC1.Text = "唐氏综合征";
            this.ckXQJC1.UseVisualStyleBackColor = true;
            // 
            // ckXQJC4
            // 
            this.ckXQJC4.AutoSize = true;
            this.ckXQJC4.Location = new System.Drawing.Point(556, 5);
            this.ckXQJC4.Name = "ckXQJC4";
            this.ckXQJC4.Size = new System.Drawing.Size(48, 24);
            this.ckXQJC4.TabIndex = 19;
            this.ckXQJC4.Text = "无";
            this.ckXQJC4.UseVisualStyleBackColor = true;
            // 
            // ckXQJC2
            // 
            this.ckXQJC2.AutoSize = true;
            this.ckXQJC2.Location = new System.Drawing.Point(149, 5);
            this.ckXQJC2.Name = "ckXQJC2";
            this.ckXQJC2.Size = new System.Drawing.Size(178, 24);
            this.ckXQJC2.TabIndex = 17;
            this.ckXQJC2.Text = "爱德华氏综合征 ";
            this.ckXQJC2.UseVisualStyleBackColor = true;
            // 
            // ckXQJC3
            // 
            this.ckXQJC3.AutoSize = true;
            this.ckXQJC3.Location = new System.Drawing.Point(340, 5);
            this.ckXQJC3.Name = "ckXQJC3";
            this.ckXQJC3.Size = new System.Drawing.Size(198, 24);
            this.ckXQJC3.TabIndex = 18;
            this.ckXQJC3.Text = "开放型神经管缺陷 ";
            this.ckXQJC3.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(199, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "免费血清学产前筛查:";
            // 
            // label95
            // 
            this.label95.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(97, 517);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(79, 20);
            this.label95.TabIndex = 196;
            this.label95.Text = "联系人:";
            // 
            // txtReferralContacts
            // 
            this.txtReferralContacts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReferralContacts.ForeColor = System.Drawing.Color.Black;
            this.txtReferralContacts.Location = new System.Drawing.Point(182, 513);
            this.txtReferralContacts.MaxLength = 20;
            this.txtReferralContacts.Name = "txtReferralContacts";
            this.txtReferralContacts.ReadOnly = true;
            this.txtReferralContacts.Size = new System.Drawing.Size(194, 30);
            this.txtReferralContacts.TabIndex = 197;
            // 
            // label96
            // 
            this.label96.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label96.AutoSize = true;
            this.label96.Font = new System.Drawing.Font("宋体", 15F);
            this.label96.Location = new System.Drawing.Point(526, 517);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(99, 20);
            this.label96.TabIndex = 198;
            this.label96.Text = "联系电话:";
            // 
            // txtReferralContactsTel
            // 
            this.txtReferralContactsTel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReferralContactsTel.ForeColor = System.Drawing.Color.Black;
            this.txtReferralContactsTel.Location = new System.Drawing.Point(631, 513);
            this.txtReferralContactsTel.MaxLength = 20;
            this.txtReferralContactsTel.Name = "txtReferralContactsTel";
            this.txtReferralContactsTel.ReadOnly = true;
            this.txtReferralContactsTel.Size = new System.Drawing.Size(159, 30);
            this.txtReferralContactsTel.TabIndex = 199;
            // 
            // label97
            // 
            this.label97.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(973, 517);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(59, 20);
            this.label97.TabIndex = 200;
            this.label97.Text = "结果:";
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.rdwdw);
            this.panel36.Controls.Add(this.rddw);
            this.panel36.Location = new System.Drawing.Point(1038, 513);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(234, 29);
            this.panel36.TabIndex = 201;
            // 
            // rdwdw
            // 
            this.rdwdw.AutoSize = true;
            this.rdwdw.Location = new System.Drawing.Point(114, 5);
            this.rdwdw.Name = "rdwdw";
            this.rdwdw.Size = new System.Drawing.Size(87, 24);
            this.rdwdw.TabIndex = 151;
            this.rdwdw.TabStop = true;
            this.rdwdw.Text = "未到位";
            this.rdwdw.UseVisualStyleBackColor = true;
            // 
            // rddw
            // 
            this.rddw.AutoSize = true;
            this.rddw.Location = new System.Drawing.Point(4, 5);
            this.rddw.Name = "rddw";
            this.rddw.Size = new System.Drawing.Size(67, 24);
            this.rddw.TabIndex = 150;
            this.rddw.TabStop = true;
            this.rddw.Text = "到位";
            this.rddw.UseVisualStyleBackColor = true;
            // 
            // tbZhuanzhenKs
            // 
            this.tbZhuanzhenKs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenKs.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenKs.Location = new System.Drawing.Point(1038, 475);
            this.tbZhuanzhenKs.MaxLength = 20;
            this.tbZhuanzhenKs.Multiline = true;
            this.tbZhuanzhenKs.Name = "tbZhuanzhenKs";
            this.tbZhuanzhenKs.ReadOnly = true;
            this.tbZhuanzhenKs.Size = new System.Drawing.Size(173, 32);
            this.tbZhuanzhenKs.TabIndex = 16;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel8, 6);
            this.panel8.Controls.Add(this.lkYs);
            this.panel8.Controls.Add(this.picSignYs);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.lkJm);
            this.panel8.Controls.Add(this.picSignJm);
            this.panel8.Controls.Add(this.label20);
            this.panel8.Location = new System.Drawing.Point(0, 588);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1288, 45);
            this.panel8.TabIndex = 202;
            // 
            // lkYs
            // 
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(391, 15);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 207;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(185, 2);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(182, 43);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 205;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 20);
            this.label12.TabIndex = 208;
            this.label12.Text = "随访医生签名:";
            // 
            // lkJm
            // 
            this.lkJm.AutoSize = true;
            this.lkJm.Location = new System.Drawing.Point(815, 15);
            this.lkJm.Name = "lkJm";
            this.lkJm.Size = new System.Drawing.Size(89, 20);
            this.lkJm.TabIndex = 203;
            this.lkJm.TabStop = true;
            this.lkJm.Text = "重置签名";
            this.lkJm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // picSignJm
            // 
            this.picSignJm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJm.Location = new System.Drawing.Point(633, 3);
            this.picSignJm.Name = "picSignJm";
            this.picSignJm.Size = new System.Drawing.Size(157, 39);
            this.picSignJm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJm.TabIndex = 0;
            this.picSignJm.TabStop = false;
            this.picSignJm.Click += new System.EventHandler(this.picSignJm_Click);
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(529, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 20);
            this.label20.TabIndex = 204;
            this.label20.Text = "居民签名:";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(446, 100);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(179, 20);
            this.label18.TabIndex = 193;
            this.label18.Text = "产前检查机构名称:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(178, 12);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 20);
            this.lbName.TabIndex = 173;
            this.lbName.Text = "姓名:";
            // 
            // lbTimes
            // 
            this.lbTimes.AutoSize = true;
            this.lbTimes.Location = new System.Drawing.Point(62, 12);
            this.lbTimes.Name = "lbTimes";
            this.lbTimes.Size = new System.Drawing.Size(119, 20);
            this.lbTimes.TabIndex = 174;
            this.lbTimes.Text = "第几次随访?";
            // 
            // GravidaTwoToFiveVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "GravidaTwoToFiveVisitForm";
            this.Text = "a";
            this.Load += new System.EventHandler(this.FrmGrvTwoFive_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel33.ResumeLayout(false);
            this.panel33.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJm)).EndInit();
            this.ResumeLayout(false);

        }

        private void JustZhuanzhenChanged(string haf)
        {
            if (haf == "1")
            {
                this.tbZhuanzhenKs.Clear();
                this.tbZhuanzhenKs.ReadOnly = true;
                this.tbZhuanzhenResult.Clear();
                this.tbZhuanzhenResult.ReadOnly = true;
                this.txtReferralContacts.Clear();
                this.txtReferralContactsTel.Clear();
                this.txtReferralContacts.ReadOnly = true;
                this.txtReferralContactsTel.ReadOnly = true;
                this.panel36.Enabled = false;
                this.rdwdw.Checked = false;
                this.rddw.Checked = false;
            }
            if (haf == "2")
            {
                this.tbZhuanzhenKs.ReadOnly = false;
                this.tbZhuanzhenResult.ReadOnly = false;
                this.txtReferralContacts.ReadOnly = false;
                this.txtReferralContactsTel.ReadOnly = false;
                this.panel36.Enabled = true;
            }
        }

        public void NotisfyChildStatus()
        {
        }

        private void rdZhuanzhenHave_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdZhuanzhenHave.Checked)
            {
                this.tbZhuanzhenKs.ReadOnly = false;
                this.tbZhuanzhenResult.ReadOnly = false;
            }
        }

        private void rdZhuanzhenNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdZhuanzhenNo.Checked)
            {
                this.tbZhuanzhenResult.Text = "";
                this.tbZhuanzhenKs.Text = "";
                this.tbZhuanzhenResult.ReadOnly = true;
                this.tbZhuanzhenKs.ReadOnly = true;
            }
        }

        public bool SaveModelToDB()
        {
            if (GlbTools.IsChanged(this.srcData, this.Grv2to5Flo, new string[] { "VisitDate", "NextfollowupDate", "HB" }))
            {
               
                WomenGravidaTwoToFiveVisitBLL womenGravidaTwoToFiveVisitBLL = new WomenGravidaTwoToFiveVisitBLL();
                if (womenGravidaTwoToFiveVisitBLL.Exists(this.Grv2to5Flo.ID))
                {
                    womenGravidaTwoToFiveVisitBLL.Update(this.Grv2to5Flo);
                }
                else
                {
                    womenGravidaTwoToFiveVisitBLL.Add(this.Grv2to5Flo);
                }
            }
            return true;
        }

        public void UpdataToModel()
        {
            this.Grv2to5Flo.FollowupDate = new DateTime?(this.dtpVisitDate.Value.Date);
            this.Grv2to5Flo.NextFollowupDate = new DateTime?(this.dtpNext.Value.Date);
            if (this.cbSFFS.SelectedIndex != -1)
            {
                this.Grv2to5Flo.FollowupWay = Convert.ToString(this.cbSFFS.SelectedIndex + 1);
            }
            if (this.rdCheckYes.Checked)
            {
                this.Grv2to5Flo.FreeSerumCheck = "1";
            }
            else if (this.rdCheckNo.Checked)
            {
                this.Grv2to5Flo.FreeSerumCheck = "2";
            }
            if (this.rddw.Checked)
            {
                this.Grv2to5Flo.ReferralResult = "1";
            }
            else if (this.rdwdw.Checked)
            {
                this.Grv2to5Flo.ReferralResult = "2";
            }
        }

        public bool EveryThingIsOk { get; set; }

        private WomenGravidaTwoToFiveVisitModel Grv2to5Flo { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public object srcData { get; set; }

        private void rdCheckYes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdCheckYes.Checked)
            {
                this.panel7.Enabled = true;
            }
        }

        private void rdCheckNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdCheckNo.Checked)
            {
                this.panel7.Enabled = false;
                this.ckXQJC1.Checked = false;
                this.ckXQJC2.Checked = false;
                this.ckXQJC3.Checked = false;
                this.ckXQJC4.Checked = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_PrenatalS_" + this.followTimes, picSignJm);
        }

        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_PrenatalS_" + this.followTimes + "_Doc", picSignYs);
        }

        private void picSignJm_Click(object sender, EventArgs e)
        {
            Sign("_PrenatalS_" + this.followTimes , picSignJm);
        }

        private void picSignYs_Click(object sender, EventArgs e)
        {
            Sign("_PrenatalS_" + this.followTimes + "_Doc", picSignYs);
        }

        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();
            if (!Directory.Exists(SignPath))
            {
                Directory.CreateDirectory(SignPath);
            }
            loadForm.IDCardNo = Model.IDCardNo;
            loadForm.SignPath = SignPath;
            loadForm.SignName = DaySign;
            if (loadForm.ShowDialog() == DialogResult.OK)
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                }
                string path = string.Format("{0}{1}{2}.png", SignPath, Model.IDCardNo, DaySign);
                Image imgeb = Image.FromFile(path);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picture.Image = bmp;
                imgeb.Dispose();
                picture.BackColor = Color.White;
                ////保存签名
                //if (!File.Exists(path) && File.Exists(this.BaseSelPath))
                //{
                //    File.Copy(this.BaseSelPath, strSelfpath, true);
                //}
            }
        }

        private void Clear(string DaySign, PictureBox picture)
        {
            try
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                    string path = SignPath + Model.IDCardNo + DaySign + ".png";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    picture.BackColor = Color.FromArgb(222, 248, 200);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

