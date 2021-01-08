
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.Utilities.Common;
using System.IO;
using System.Drawing;
using System.Configuration;

namespace FocusGroup.Gravida
{
    public class AfterKidBirthVisitForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<WomenGravidaPostpartumModel> bindingManager;
        private IContainer components;
        private SingleItemT<WomenGravidaPostpartumModel> elu;
        private SingleItemT<WomenGravidaPostpartumModel> fenlei;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private SingleItemT<WomenGravidaPostpartumModel> rufang;
        private SingleItemT<WomenGravidaPostpartumModel> shangkou;
        private ManyCheckboxs<WomenGravidaPostpartumModel> zhidao;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private TextBox tbFenlEx;
        private RadioButton rdFenlHave;
        private RadioButton rdFenlNo;
        private Panel panel5;
        private TextBox tbShkEx;
        private RadioButton rdShKHave;
        private RadioButton rdShKNo;
        private Panel panel4;
        private TextBox tbZigEx;
        private RadioButton rdZigHave;
        private RadioButton rdZigNo;
        private Panel panel3;
        private TextBox tbEluEx;
        private RadioButton rdEluHave;
        private RadioButton rdEluNo;
        private Label label10;
        private Panel panel21;
        private Button btnTemp;
        private Label label81;
        private TextBox tbTemp;
        private Label label4;
        private TextBox tbNormalHealth;
        private Label label13;
        private Label label80;
        private Label label8;
        private FlowLayoutPanel flowLayoutPanel2;
        private CheckBox ckGuides1;
        private CheckBox ckGuides2;
        private CheckBox ckGuides3;
        private CheckBox ckGuides4;
        private CheckBox ckGuides5;
        private CheckBox ckGuides6;
        private TextBox tbGuidesOth;
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
        private Label label28;
        private TextBox tbNormalPhysic;
        private Label label29;
        private Panel panel6;
        private Button btnHype;
        private Label label3;
        private TextBox tbHype;
        private Label label15;
        private Panel panel33;
        private TextBox tbRufEx;
        private RadioButton rdRufHave;
        private RadioButton rdRufNo;
        private Label label11;
        private Label label1;
        private Label label2;
        private TextBox tbOther;
        private Label label33;
        private Label label5;
        private DateTimePicker dtpVisitDate;
        private Label lbName;
        private Label label6;
        private DateTimePicker dtDeliveryDate;
        private Label label7;
        private DateTimePicker dtLeaveHospitalDate;
        private Label label95;
        private TextBox txtReferralContacts;
        private Label label96;
        private TextBox txtReferralContactsTel;
        private Label label97;
        private Panel panel36;
        private RadioButton rdwdw;
        private RadioButton rddw;
        private Label label9;
        private PictureBox picSignJs;
        private SingleItemT<WomenGravidaPostpartumModel> zigong;
        private int HW_eOk = 0;
        private LinkLabel lkJs;
        private Panel panel7;
        private LinkLabel lkYs;
        private Label label12;
        private string SignS = "";
        private PictureBox picSignYs1;//本人或家属确认签字
        private string SignDoc = "";//医生签字
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Gravida/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Gravida//"; //签名保存路径

        public AfterKidBirthVisitForm()
        {
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();
            this.InitEveryControl();
            this.EveryThingIsOk = false;
            this.tableLayoutPanel1.ResumeLayout();
        }

        private void btnHype_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "20") {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.GrvPostpartum.HBbloodPressure = new decimal?(int.Parse(select.m_Result.value1));
                this.GrvPostpartum.LBloodPressure = new decimal?(int.Parse(select.m_Result.value2));
                this.tbHype.Text = string.Format("{0}/{1}", this.GrvPostpartum.HBbloodPressure.Value, this.GrvPostpartum.LBloodPressure.Value);
            }
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "40") {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tbTemp.Text = select.m_Result.value1;
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
            if (((!this.bindingManager.ErrorInput && !this.rufang.ErrorInput) && (!this.elu.ErrorInput && !this.zigong.ErrorInput)) && ((!this.shangkou.ErrorInput && !this.fenlei.ErrorInput) && !this.zhidao.ErrorInput&&!flag))
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

        private void FrmAftChildBirth_Load(object sender, EventArgs e)
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
            this.inputRanges = new List<InputRangeDec>();
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("HealthCondition", 200));
            this.inputrange_str.Add(new InputRangeStr("Mentalcondition", 200));
            this.inputrange_str.Add(new InputRangeStr("BreastEx", 200));
            this.inputrange_str.Add(new InputRangeStr("LochiaEx", 200));
            this.inputrange_str.Add(new InputRangeStr("UterusEx", 200));
            this.inputrange_str.Add(new InputRangeStr("WoundEx", 200));
            this.inputrange_str.Add(new InputRangeStr("Other", 500));
            this.inputrange_str.Add(new InputRangeStr("ClassificationEx", 200));
            this.inputrange_str.Add(new InputRangeStr("Advisinther", 200));
            this.inputrange_str.Add(new InputRangeStr("ReferralReason", 200));
            this.inputrange_str.Add(new InputRangeStr("ReferralOrg", 80));
        }

        public void InitEveryThing()
        {
            this.GrvPostpartum = new WomenGravidaPostpartumBLL().GetModel(this.Model.IDCardNo);
            if (this.GrvPostpartum == null)
            {
                this.GrvPostpartum = new WomenGravidaPostpartumModel();
                this.GrvPostpartum.IDCardNo = this.Model.IDCardNo;
                this.GrvPostpartum.RecordID = this.Model.RecordID;
                this.GrvPostpartum.CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.GrvPostpartum.CreatedDate = new DateTime?(DateTime.Today);
                this.GrvPostpartum.FollowupDate = new DateTime?(DateTime.Today);
            }
            else
            {
                this.GrvPostpartum.LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.GrvPostpartum.LastUpdateDate = new DateTime?(DateTime.Today);
            }
            this.bindingManager = new SimpleBindingManager<WomenGravidaPostpartumModel>(this.inputRanges, this.inputrange_str, this.GrvPostpartum);
            if (string.IsNullOrEmpty(this.GrvPostpartum.FollowupDoctor))
            {
                this.GrvPostpartum.FollowupDoctor = ConfigHelper.GetNode("doctorName");
            }
            if (!this.GrvPostpartum.Tem.HasValue)
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "40");
                if (devData.HasValue)
                {
                    this.GrvPostpartum.Tem = new decimal?(decimal.Parse(devData.value1));
                }
            }
            if (!this.GrvPostpartum.HBbloodPressure.HasValue)
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20");
                if (_result2.HasValue)
                {
                    this.GrvPostpartum.HBbloodPressure = new decimal?(int.Parse(_result2.value1));
                    this.GrvPostpartum.LBloodPressure = new decimal?(int.Parse(_result2.value2));
                }
            }
            this.srcData = GlbTools.DeepCopy(this.GrvPostpartum);
            this.lbName.Text = string.Format("姓名: {0}", this.Model.CustomerName);
            if (this.GrvPostpartum.FollowupDate.HasValue)
            {
                this.dtpVisitDate.Value = this.GrvPostpartum.FollowupDate.Value;
            }
            this.bindingManager.SimpleBinding(this.tbNormalHealth, "HealthCondition", false);
            this.bindingManager.SimpleBinding(this.tbNormalPhysic, "Mentalcondition", false);
            this.bindingManager.SimpleBinding(this.tbTemp, "Tem", true);
            if (this.GrvPostpartum.HBbloodPressure.HasValue && this.GrvPostpartum.LBloodPressure.HasValue)
            {
                this.tbHype.Text = string.Format("{0}/{1}", this.GrvPostpartum.HBbloodPressure.Value, this.GrvPostpartum.LBloodPressure.Value);
            }
            SingleItemT<WomenGravidaPostpartumModel> mt = new SingleItemT<WomenGravidaPostpartumModel>(this.GrvPostpartum) {
                Name = "乳房",
                Usual = this.rdRufNo,
                Unusual = this.rdRufHave,
                Info = this.tbRufEx,
                MaxBytesCount = 200
            };
            this.rufang = mt;
            this.rufang.BindProperty("Breast", "BreastEx");
            SingleItemT<WomenGravidaPostpartumModel> mt2 = new SingleItemT<WomenGravidaPostpartumModel>(this.GrvPostpartum) {
                Name = "恶露",
                Usual = this.rdEluNo,
                Unusual = this.rdEluHave,
                Info = this.tbEluEx,
                MaxBytesCount = 200
            };
            this.elu = mt2;
            this.elu.BindProperty("Lochia", "LochiaEx");
            SingleItemT<WomenGravidaPostpartumModel> mt3 = new SingleItemT<WomenGravidaPostpartumModel>(this.GrvPostpartum) {
                Name = "子宫",
                Usual = this.rdZigNo,
                Unusual = this.rdZigHave,
                Info = this.tbZigEx,
                MaxBytesCount = 200
            };
            this.zigong = mt3;
            this.zigong.BindProperty("Uterus", "UterusEx");
            SingleItemT<WomenGravidaPostpartumModel> mt4 = new SingleItemT<WomenGravidaPostpartumModel>(this.GrvPostpartum) {
                Name = "伤口",
                Usual = this.rdShKNo,
                Unusual = this.rdShKHave,
                Info = this.tbShkEx,
                MaxBytesCount = 200
            };
            this.shangkou = mt4;
            this.shangkou.BindProperty("Wound", "WoundEx");
            this.bindingManager.SimpleBinding(this.tbOther, "Other", false);
            SingleItemT<WomenGravidaPostpartumModel> mt5 = new SingleItemT<WomenGravidaPostpartumModel>(this.GrvPostpartum) {
                Name = "分类",
                Usual = this.rdFenlNo,
                Unusual = this.rdFenlHave,
                Info = this.tbFenlEx,
                MaxBytesCount = 200
            };
            this.fenlei = mt5;
            this.fenlei.BindProperty("Classification", "ClassificationEx");
            this.zhidao = new ManyCheckboxs<WomenGravidaPostpartumModel>(this.GrvPostpartum, 200);
            this.zhidao.AddCk(new LoneCheckbox(this.ckGuides1));
            this.zhidao.AddCk(new LoneCheckbox(this.ckGuides2));
            this.zhidao.AddCk(new LoneCheckbox(this.ckGuides3));
            this.zhidao.AddCk(new LoneCheckbox(this.ckGuides4));
            this.zhidao.AddCk(new LoneCheckbox(this.ckGuides5));
            this.zhidao.AddCk(new LoneCheckbox(this.ckGuides6, this.tbGuidesOth));
            this.zhidao.BindingProperty("Advising", "AdvisingOther");
            if (!string.IsNullOrEmpty(this.GrvPostpartum.Referral))
            {
                if (this.GrvPostpartum.Referral == "1")
                {
                    this.rdZhuanzhenNo.Checked = true;
                }
                else
                {
                    this.rdZhuanzhenHave.Checked = true;
                }
            }
            else
            {
                this.rdZhuanzhenNo.Checked = true;
            }
            this.bindingManager.SimpleBinding(this.tbZhuanzhenResult, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenKs, "ReferralOrg", false);
            
            if (this.GrvPostpartum.NextFollowupDate.HasValue)
            {
                this.dtpNext.Value = this.GrvPostpartum.NextFollowupDate.Value;
            }

            this.bindingManager.SimpleBinding(this.tbDoctorMark, "FollowupDoctor", false);
            this.bindingManager.SimpleBinding(this.txtReferralContacts, "ReferralContacts", false);
            this.bindingManager.SimpleBinding(this.txtReferralContactsTel, "ReferralContactsTel", false);
            if (this.GrvPostpartum.ReferralResult == "1")
            {
                this.rddw.Checked = true;
            }
            else if (this.GrvPostpartum.ReferralResult == "2")
            {
                this.rdwdw.Checked = true;
            }
            if (this.GrvPostpartum.DeliveryDate.HasValue)
            {
                this.dtDeliveryDate.Value = this.GrvPostpartum.DeliveryDate.Value;
            }
            if (this.GrvPostpartum.LeaveHospitalDate.HasValue)
            {
                this.dtLeaveHospitalDate.Value = this.GrvPostpartum.LeaveHospitalDate.Value;
            }
            //签名初始化
            this.SignS = string.Format("{0}{1}_{2}.png", SignPath, Model.IDCardNo, "PostpartumS");
            if (File.Exists(this.SignS))
            {
                Image imgeb = Image.FromFile(SignS);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSignJs.Image = bmp;
                picSignJs.Show();
                imgeb.Dispose();
                this.lkJs.Enabled = true;
                picSignJs.BackColor = Color.White;
            }
            this.SignDoc = string.Format("{0}{1}_{2}_Doc.png", SignPath, Model.IDCardNo, "PostpartumS");
            if (File.Exists(this.SignDoc))
            {
                Image imgeb = Image.FromFile(SignDoc);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSignYs1.Image = bmp;
                picSignYs1.Show();
                imgeb.Dispose();
                this.lkYs.Enabled = true;
                picSignYs1.BackColor = Color.White;
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbFenlEx = new System.Windows.Forms.TextBox();
            this.rdFenlHave = new System.Windows.Forms.RadioButton();
            this.rdFenlNo = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbShkEx = new System.Windows.Forms.TextBox();
            this.rdShKHave = new System.Windows.Forms.RadioButton();
            this.rdShKNo = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbZigEx = new System.Windows.Forms.TextBox();
            this.rdZigHave = new System.Windows.Forms.RadioButton();
            this.rdZigNo = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbEluEx = new System.Windows.Forms.TextBox();
            this.rdEluHave = new System.Windows.Forms.RadioButton();
            this.rdEluNo = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNormalHealth = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.ckGuides1 = new System.Windows.Forms.CheckBox();
            this.ckGuides2 = new System.Windows.Forms.CheckBox();
            this.ckGuides3 = new System.Windows.Forms.CheckBox();
            this.ckGuides4 = new System.Windows.Forms.CheckBox();
            this.ckGuides5 = new System.Windows.Forms.CheckBox();
            this.ckGuides6 = new System.Windows.Forms.CheckBox();
            this.tbGuidesOth = new System.Windows.Forms.TextBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.rdZhuanzhenHave = new System.Windows.Forms.RadioButton();
            this.rdZhuanzhenNo = new System.Windows.Forms.RadioButton();
            this.label67 = new System.Windows.Forms.Label();
            this.tbZhuanzhenResult = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.tbZhuanzhenKs = new System.Windows.Forms.TextBox();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.tbDoctorMark = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbNormalPhysic = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnHype = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHype = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.tbRufEx = new System.Windows.Forms.TextBox();
            this.rdRufHave = new System.Windows.Forms.RadioButton();
            this.rdRufNo = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOther = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpVisitDate = new System.Windows.Forms.DateTimePicker();
            this.label80 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.btnTemp = new System.Windows.Forms.Button();
            this.label81 = new System.Windows.Forms.Label();
            this.tbTemp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtLeaveHospitalDate = new System.Windows.Forms.DateTimePicker();
            this.label95 = new System.Windows.Forms.Label();
            this.txtReferralContacts = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.txtReferralContactsTel = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.panel36 = new System.Windows.Forms.Panel();
            this.rdwdw = new System.Windows.Forms.RadioButton();
            this.rddw = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.picSignYs1 = new System.Windows.Forms.PictureBox();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.lkJs = new System.Windows.Forms.LinkLabel();
            this.picSignJs = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Location = new System.Drawing.Point(48, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1450, 672);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.82608F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.36449F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.82608F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.36449F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0985F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.52034F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbNormalHealth, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.panel20, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.label67, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenResult, 3, 14);
            this.tableLayoutPanel1.Controls.Add(this.label68, 4, 14);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenKs, 5, 14);
            this.tableLayoutPanel1.Controls.Add(this.dtpNext, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.label78, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.label79, 2, 16);
            this.tableLayoutPanel1.Controls.Add(this.tbDoctorMark, 3, 16);
            this.tableLayoutPanel1.Controls.Add(this.label28, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbNormalPhysic, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label29, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel33, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tbOther, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.label33, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.dtpVisitDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label80, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel21, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtDeliveryDate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtLeaveHospitalDate, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label95, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.txtReferralContacts, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.label96, 2, 15);
            this.tableLayoutPanel1.Controls.Add(this.txtReferralContactsTel, 3, 15);
            this.tableLayoutPanel1.Controls.Add(this.label97, 4, 15);
            this.tableLayoutPanel1.Controls.Add(this.panel36, 5, 15);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 17);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(46, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 18;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1355, 641);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 5);
            this.panel2.Controls.Add(this.tbFenlEx);
            this.panel2.Controls.Add(this.rdFenlHave);
            this.panel2.Controls.Add(this.rdFenlNo);
            this.panel2.Location = new System.Drawing.Point(187, 384);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 40);
            this.panel2.TabIndex = 10;
            // 
            // tbFenlEx
            // 
            this.tbFenlEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFenlEx.ForeColor = System.Drawing.Color.Black;
            this.tbFenlEx.Location = new System.Drawing.Point(185, 4);
            this.tbFenlEx.MaxLength = 100;
            this.tbFenlEx.Multiline = true;
            this.tbFenlEx.Name = "tbFenlEx";
            this.tbFenlEx.ReadOnly = true;
            this.tbFenlEx.Size = new System.Drawing.Size(609, 33);
            this.tbFenlEx.TabIndex = 114;
            // 
            // rdFenlHave
            // 
            this.rdFenlHave.AutoSize = true;
            this.rdFenlHave.Location = new System.Drawing.Point(108, 6);
            this.rdFenlHave.Name = "rdFenlHave";
            this.rdFenlHave.Size = new System.Drawing.Size(67, 24);
            this.rdFenlHave.TabIndex = 113;
            this.rdFenlHave.TabStop = true;
            this.rdFenlHave.Text = "异常";
            this.rdFenlHave.UseVisualStyleBackColor = true;
            // 
            // rdFenlNo
            // 
            this.rdFenlNo.AutoSize = true;
            this.rdFenlNo.Location = new System.Drawing.Point(5, 6);
            this.rdFenlNo.Name = "rdFenlNo";
            this.rdFenlNo.Size = new System.Drawing.Size(107, 24);
            this.rdFenlNo.TabIndex = 112;
            this.rdFenlNo.TabStop = true;
            this.rdFenlNo.Text = "未见异常";
            this.rdFenlNo.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel5, 5);
            this.panel5.Controls.Add(this.tbShkEx);
            this.panel5.Controls.Add(this.rdShKHave);
            this.panel5.Controls.Add(this.rdShKNo);
            this.panel5.Location = new System.Drawing.Point(187, 296);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(799, 39);
            this.panel5.TabIndex = 8;
            // 
            // tbShkEx
            // 
            this.tbShkEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbShkEx.ForeColor = System.Drawing.Color.Black;
            this.tbShkEx.Location = new System.Drawing.Point(185, 4);
            this.tbShkEx.MaxLength = 100;
            this.tbShkEx.Multiline = true;
            this.tbShkEx.Name = "tbShkEx";
            this.tbShkEx.ReadOnly = true;
            this.tbShkEx.Size = new System.Drawing.Size(609, 28);
            this.tbShkEx.TabIndex = 114;
            // 
            // rdShKHave
            // 
            this.rdShKHave.AutoSize = true;
            this.rdShKHave.Location = new System.Drawing.Point(108, 6);
            this.rdShKHave.Name = "rdShKHave";
            this.rdShKHave.Size = new System.Drawing.Size(67, 24);
            this.rdShKHave.TabIndex = 113;
            this.rdShKHave.TabStop = true;
            this.rdShKHave.Text = "异常";
            this.rdShKHave.UseVisualStyleBackColor = true;
            // 
            // rdShKNo
            // 
            this.rdShKNo.AutoSize = true;
            this.rdShKNo.Location = new System.Drawing.Point(5, 6);
            this.rdShKNo.Name = "rdShKNo";
            this.rdShKNo.Size = new System.Drawing.Size(107, 24);
            this.rdShKNo.TabIndex = 112;
            this.rdShKNo.TabStop = true;
            this.rdShKNo.Text = "未见异常";
            this.rdShKNo.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 5);
            this.panel4.Controls.Add(this.tbZigEx);
            this.panel4.Controls.Add(this.rdZigHave);
            this.panel4.Controls.Add(this.rdZigNo);
            this.panel4.Location = new System.Drawing.Point(187, 258);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(799, 38);
            this.panel4.TabIndex = 7;
            // 
            // tbZigEx
            // 
            this.tbZigEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZigEx.ForeColor = System.Drawing.Color.Black;
            this.tbZigEx.Location = new System.Drawing.Point(185, 4);
            this.tbZigEx.MaxLength = 100;
            this.tbZigEx.Multiline = true;
            this.tbZigEx.Name = "tbZigEx";
            this.tbZigEx.ReadOnly = true;
            this.tbZigEx.Size = new System.Drawing.Size(609, 28);
            this.tbZigEx.TabIndex = 114;
            // 
            // rdZigHave
            // 
            this.rdZigHave.AutoSize = true;
            this.rdZigHave.Location = new System.Drawing.Point(108, 6);
            this.rdZigHave.Name = "rdZigHave";
            this.rdZigHave.Size = new System.Drawing.Size(67, 24);
            this.rdZigHave.TabIndex = 113;
            this.rdZigHave.TabStop = true;
            this.rdZigHave.Text = "异常";
            this.rdZigHave.UseVisualStyleBackColor = true;
            // 
            // rdZigNo
            // 
            this.rdZigNo.AutoSize = true;
            this.rdZigNo.Location = new System.Drawing.Point(5, 6);
            this.rdZigNo.Name = "rdZigNo";
            this.rdZigNo.Size = new System.Drawing.Size(107, 24);
            this.rdZigNo.TabIndex = 112;
            this.rdZigNo.TabStop = true;
            this.rdZigNo.Text = "未见异常";
            this.rdZigNo.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 5);
            this.panel3.Controls.Add(this.tbEluEx);
            this.panel3.Controls.Add(this.rdEluHave);
            this.panel3.Controls.Add(this.rdEluNo);
            this.panel3.Location = new System.Drawing.Point(187, 221);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(799, 37);
            this.panel3.TabIndex = 6;
            // 
            // tbEluEx
            // 
            this.tbEluEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbEluEx.ForeColor = System.Drawing.Color.Black;
            this.tbEluEx.Location = new System.Drawing.Point(185, 4);
            this.tbEluEx.MaxLength = 100;
            this.tbEluEx.Multiline = true;
            this.tbEluEx.Name = "tbEluEx";
            this.tbEluEx.ReadOnly = true;
            this.tbEluEx.Size = new System.Drawing.Size(609, 28);
            this.tbEluEx.TabIndex = 114;
            // 
            // rdEluHave
            // 
            this.rdEluHave.AutoSize = true;
            this.rdEluHave.Location = new System.Drawing.Point(108, 6);
            this.rdEluHave.Name = "rdEluHave";
            this.rdEluHave.Size = new System.Drawing.Size(67, 24);
            this.rdEluHave.TabIndex = 113;
            this.rdEluHave.TabStop = true;
            this.rdEluHave.Text = "异常";
            this.rdEluHave.UseVisualStyleBackColor = true;
            // 
            // rdEluNo
            // 
            this.rdEluNo.AutoSize = true;
            this.rdEluNo.Location = new System.Drawing.Point(5, 6);
            this.rdEluNo.Name = "rdEluNo";
            this.rdEluNo.Size = new System.Drawing.Size(107, 24);
            this.rdEluNo.TabIndex = 112;
            this.rdEluNo.TabStop = true;
            this.rdEluNo.Text = "未见异常";
            this.rdEluNo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F);
            this.label10.Location = new System.Drawing.Point(85, 471);
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
            this.label4.Location = new System.Drawing.Point(3, 54);
            this.label4.Name = "label4";
            this.tableLayoutPanel1.SetRowSpan(this.label4, 2);
            this.label4.Size = new System.Drawing.Size(181, 20);
            this.label4.TabIndex = 112;
            this.label4.Text = "一般健康状况:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbNormalHealth
            // 
            this.tbNormalHealth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbNormalHealth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbNormalHealth, 5);
            this.tbNormalHealth.ForeColor = System.Drawing.Color.Black;
            this.tbNormalHealth.Location = new System.Drawing.Point(190, 41);
            this.tbNormalHealth.MaxLength = 200;
            this.tbNormalHealth.Multiline = true;
            this.tbNormalHealth.Name = "tbNormalHealth";
            this.tableLayoutPanel1.SetRowSpan(this.tbNormalHealth, 2);
            this.tbNormalHealth.Size = new System.Drawing.Size(793, 46);
            this.tbNormalHealth.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F);
            this.label13.Location = new System.Drawing.Point(85, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 100;
            this.label13.Text = "随访日期:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F);
            this.label8.Location = new System.Drawing.Point(3, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 20);
            this.label8.TabIndex = 179;
            this.label8.Text = "指    导:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 5);
            this.flowLayoutPanel2.Controls.Add(this.ckGuides1);
            this.flowLayoutPanel2.Controls.Add(this.ckGuides2);
            this.flowLayoutPanel2.Controls.Add(this.ckGuides3);
            this.flowLayoutPanel2.Controls.Add(this.ckGuides4);
            this.flowLayoutPanel2.Controls.Add(this.ckGuides5);
            this.flowLayoutPanel2.Controls.Add(this.ckGuides6);
            this.flowLayoutPanel2.Controls.Add(this.tbGuidesOth);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(187, 424);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1050, 38);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // ckGuides1
            // 
            this.ckGuides1.AutoSize = true;
            this.ckGuides1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ckGuides1.Location = new System.Drawing.Point(3, 7);
            this.ckGuides1.Name = "ckGuides1";
            this.ckGuides1.Size = new System.Drawing.Size(108, 24);
            this.ckGuides1.TabIndex = 0;
            this.ckGuides1.Text = "个人卫生";
            this.ckGuides1.UseVisualStyleBackColor = true;
            // 
            // ckGuides2
            // 
            this.ckGuides2.AutoSize = true;
            this.ckGuides2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ckGuides2.Location = new System.Drawing.Point(117, 7);
            this.ckGuides2.Name = "ckGuides2";
            this.ckGuides2.Size = new System.Drawing.Size(68, 24);
            this.ckGuides2.TabIndex = 1;
            this.ckGuides2.Text = "心理";
            this.ckGuides2.UseVisualStyleBackColor = true;
            // 
            // ckGuides3
            // 
            this.ckGuides3.AutoSize = true;
            this.ckGuides3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ckGuides3.Location = new System.Drawing.Point(191, 7);
            this.ckGuides3.Name = "ckGuides3";
            this.ckGuides3.Size = new System.Drawing.Size(68, 24);
            this.ckGuides3.TabIndex = 2;
            this.ckGuides3.Text = "营养";
            this.ckGuides3.UseVisualStyleBackColor = true;
            // 
            // ckGuides4
            // 
            this.ckGuides4.AutoSize = true;
            this.ckGuides4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ckGuides4.Location = new System.Drawing.Point(265, 7);
            this.ckGuides4.Name = "ckGuides4";
            this.ckGuides4.Size = new System.Drawing.Size(108, 24);
            this.ckGuides4.TabIndex = 3;
            this.ckGuides4.Text = "母乳喂养";
            this.ckGuides4.UseVisualStyleBackColor = true;
            // 
            // ckGuides5
            // 
            this.ckGuides5.AutoSize = true;
            this.ckGuides5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ckGuides5.Location = new System.Drawing.Point(379, 7);
            this.ckGuides5.Name = "ckGuides5";
            this.ckGuides5.Size = new System.Drawing.Size(188, 24);
            this.ckGuides5.TabIndex = 4;
            this.ckGuides5.Text = "新生儿护理与喂养";
            this.ckGuides5.UseVisualStyleBackColor = true;
            // 
            // ckGuides6
            // 
            this.ckGuides6.AutoSize = true;
            this.ckGuides6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ckGuides6.Location = new System.Drawing.Point(573, 7);
            this.ckGuides6.Name = "ckGuides6";
            this.ckGuides6.Size = new System.Drawing.Size(68, 24);
            this.ckGuides6.TabIndex = 5;
            this.ckGuides6.Text = "其他";
            this.ckGuides6.UseVisualStyleBackColor = true;
            // 
            // tbGuidesOth
            // 
            this.tbGuidesOth.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbGuidesOth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGuidesOth.ForeColor = System.Drawing.Color.Black;
            this.tbGuidesOth.Location = new System.Drawing.Point(647, 3);
            this.tbGuidesOth.MaxLength = 20;
            this.tbGuidesOth.Multiline = true;
            this.tbGuidesOth.Name = "tbGuidesOth";
            this.tbGuidesOth.ReadOnly = true;
            this.tbGuidesOth.Size = new System.Drawing.Size(221, 28);
            this.tbGuidesOth.TabIndex = 186;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.rdZhuanzhenHave);
            this.panel20.Controls.Add(this.rdZhuanzhenNo);
            this.panel20.Location = new System.Drawing.Point(190, 465);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(173, 33);
            this.panel20.TabIndex = 12;
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
            this.rdZhuanzhenHave.CheckedChanged += new System.EventHandler(this.rdZhuanzhenHave_CheckedChanged);
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
            this.rdZhuanzhenNo.CheckedChanged += new System.EventHandler(this.rdZhuanzhenNo_CheckedChanged);
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("宋体", 15F);
            this.label67.Location = new System.Drawing.Point(534, 471);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(99, 20);
            this.label67.TabIndex = 184;
            this.label67.Text = "原    因:";
            // 
            // tbZhuanzhenResult
            // 
            this.tbZhuanzhenResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenResult.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenResult.Location = new System.Drawing.Point(639, 465);
            this.tbZhuanzhenResult.MaxLength = 20;
            this.tbZhuanzhenResult.Multiline = true;
            this.tbZhuanzhenResult.Name = "tbZhuanzhenResult";
            this.tbZhuanzhenResult.Size = new System.Drawing.Size(173, 28);
            this.tbZhuanzhenResult.TabIndex = 13;
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("宋体", 15F);
            this.label68.Location = new System.Drawing.Point(939, 471);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(119, 20);
            this.label68.TabIndex = 186;
            this.label68.Text = "机构及科室:";
            // 
            // tbZhuanzhenKs
            // 
            this.tbZhuanzhenKs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenKs.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenKs.Location = new System.Drawing.Point(1064, 465);
            this.tbZhuanzhenKs.MaxLength = 20;
            this.tbZhuanzhenKs.Multiline = true;
            this.tbZhuanzhenKs.Name = "tbZhuanzhenKs";
            this.tbZhuanzhenKs.Size = new System.Drawing.Size(173, 28);
            this.tbZhuanzhenKs.TabIndex = 14;
            // 
            // dtpNext
            // 
            this.dtpNext.Location = new System.Drawing.Point(190, 549);
            this.dtpNext.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(195, 30);
            this.dtpNext.TabIndex = 15;
            // 
            // label78
            // 
            this.label78.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("宋体", 15F);
            this.label78.Location = new System.Drawing.Point(45, 551);
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
            this.label79.Location = new System.Drawing.Point(494, 551);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(139, 20);
            this.label79.TabIndex = 190;
            this.label79.Text = "随访医生签名:";
            this.label79.Visible = false;
            // 
            // tbDoctorMark
            // 
            this.tbDoctorMark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDoctorMark.ForeColor = System.Drawing.Color.Black;
            this.tbDoctorMark.Location = new System.Drawing.Point(639, 549);
            this.tbDoctorMark.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tbDoctorMark.MaxLength = 20;
            this.tbDoctorMark.Multiline = true;
            this.tbDoctorMark.Name = "tbDoctorMark";
            this.tbDoctorMark.Size = new System.Drawing.Size(173, 28);
            this.tbDoctorMark.TabIndex = 16;
            this.tbDoctorMark.Visible = false;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 15F);
            this.label28.Location = new System.Drawing.Point(3, 110);
            this.label28.Name = "label28";
            this.tableLayoutPanel1.SetRowSpan(this.label28, 2);
            this.label28.Size = new System.Drawing.Size(181, 20);
            this.label28.TabIndex = 161;
            this.label28.Text = "一般心理状况:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbNormalPhysic
            // 
            this.tbNormalPhysic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbNormalPhysic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbNormalPhysic, 5);
            this.tbNormalPhysic.ForeColor = System.Drawing.Color.Black;
            this.tbNormalPhysic.Location = new System.Drawing.Point(190, 93);
            this.tbNormalPhysic.MaxLength = 200;
            this.tbNormalPhysic.Multiline = true;
            this.tbNormalPhysic.Name = "tbNormalPhysic";
            this.tableLayoutPanel1.SetRowSpan(this.tbNormalPhysic, 2);
            this.tbNormalPhysic.Size = new System.Drawing.Size(793, 54);
            this.tbNormalPhysic.TabIndex = 3;
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 15F);
            this.label29.Location = new System.Drawing.Point(85, 156);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(99, 20);
            this.label29.TabIndex = 162;
            this.label29.Text = "血    压:";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 2);
            this.panel6.Controls.Add(this.btnHype);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.tbHype);
            this.panel6.Location = new System.Drawing.Point(187, 150);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(449, 33);
            this.panel6.TabIndex = 4;
            // 
            // btnHype
            // 
            this.btnHype.Location = new System.Drawing.Point(176, 2);
            this.btnHype.Name = "btnHype";
            this.btnHype.Size = new System.Drawing.Size(44, 27);
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
            this.label3.Location = new System.Drawing.Point(234, 7);
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
            this.tbHype.Location = new System.Drawing.Point(3, 0);
            this.tbHype.Multiline = true;
            this.tbHype.Name = "tbHype";
            this.tbHype.ReadOnly = true;
            this.tbHype.Size = new System.Drawing.Size(141, 28);
            this.tbHype.TabIndex = 111;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F);
            this.label15.Location = new System.Drawing.Point(85, 192);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 20);
            this.label15.TabIndex = 146;
            this.label15.Text = "乳    房:";
            // 
            // panel33
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel33, 5);
            this.panel33.Controls.Add(this.tbRufEx);
            this.panel33.Controls.Add(this.rdRufHave);
            this.panel33.Controls.Add(this.rdRufNo);
            this.panel33.Location = new System.Drawing.Point(187, 183);
            this.panel33.Margin = new System.Windows.Forms.Padding(0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(799, 35);
            this.panel33.TabIndex = 5;
            // 
            // tbRufEx
            // 
            this.tbRufEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbRufEx.ForeColor = System.Drawing.Color.Black;
            this.tbRufEx.Location = new System.Drawing.Point(185, 4);
            this.tbRufEx.MaxLength = 100;
            this.tbRufEx.Multiline = true;
            this.tbRufEx.Name = "tbRufEx";
            this.tbRufEx.ReadOnly = true;
            this.tbRufEx.Size = new System.Drawing.Size(609, 28);
            this.tbRufEx.TabIndex = 114;
            // 
            // rdRufHave
            // 
            this.rdRufHave.AutoSize = true;
            this.rdRufHave.Location = new System.Drawing.Point(108, 6);
            this.rdRufHave.Name = "rdRufHave";
            this.rdRufHave.Size = new System.Drawing.Size(67, 24);
            this.rdRufHave.TabIndex = 113;
            this.rdRufHave.TabStop = true;
            this.rdRufHave.Text = "异常";
            this.rdRufHave.UseVisualStyleBackColor = true;
            // 
            // rdRufNo
            // 
            this.rdRufNo.AutoSize = true;
            this.rdRufNo.Location = new System.Drawing.Point(5, 6);
            this.rdRufNo.Name = "rdRufNo";
            this.rdRufNo.Size = new System.Drawing.Size(107, 24);
            this.rdRufNo.TabIndex = 112;
            this.rdRufNo.TabStop = true;
            this.rdRufNo.Text = "未见异常";
            this.rdRufNo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F);
            this.label11.Location = new System.Drawing.Point(85, 229);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 147;
            this.label11.Text = "恶    露:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(85, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 193;
            this.label1.Text = "子    宫:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(85, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 194;
            this.label2.Text = "伤    口:";
            // 
            // tbOther
            // 
            this.tbOther.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbOther, 5);
            this.tbOther.ForeColor = System.Drawing.Color.Black;
            this.tbOther.Location = new System.Drawing.Point(190, 338);
            this.tbOther.MaxLength = 200;
            this.tbOther.Multiline = true;
            this.tbOther.Name = "tbOther";
            this.tableLayoutPanel1.SetRowSpan(this.tbOther, 2);
            this.tbOther.Size = new System.Drawing.Size(793, 43);
            this.tbOther.TabIndex = 9;
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F);
            this.label33.Location = new System.Drawing.Point(3, 349);
            this.label33.Name = "label33";
            this.tableLayoutPanel1.SetRowSpan(this.label33, 2);
            this.label33.Size = new System.Drawing.Size(181, 20);
            this.label33.TabIndex = 164;
            this.label33.Text = "其    他:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F);
            this.label5.Location = new System.Drawing.Point(85, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 195;
            this.label5.Text = "分    类:";
            // 
            // dtpVisitDate
            // 
            this.dtpVisitDate.Location = new System.Drawing.Point(190, 3);
            this.dtpVisitDate.Name = "dtpVisitDate";
            this.dtpVisitDate.Size = new System.Drawing.Size(182, 30);
            this.dtpVisitDate.TabIndex = 0;
            // 
            // label80
            // 
            this.label80.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label80.Location = new System.Drawing.Point(825, 159);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(70, 14);
            this.label80.TabIndex = 167;
            this.label80.Text = "体    温:";
            // 
            // panel21
            // 
            this.panel21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel21, 2);
            this.panel21.Controls.Add(this.btnTemp);
            this.panel21.Controls.Add(this.label81);
            this.panel21.Controls.Add(this.tbTemp);
            this.panel21.Location = new System.Drawing.Point(898, 150);
            this.panel21.Margin = new System.Windows.Forms.Padding(0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(457, 33);
            this.panel21.TabIndex = 1;
            // 
            // btnTemp
            // 
            this.btnTemp.Location = new System.Drawing.Point(105, 3);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(44, 27);
            this.btnTemp.TabIndex = 147;
            this.btnTemp.Text = ".....";
            this.btnTemp.UseVisualStyleBackColor = true;
            this.btnTemp.Click += new System.EventHandler(this.btnTemp_Click);
            // 
            // label81
            // 
            this.label81.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("宋体", 15F);
            this.label81.Location = new System.Drawing.Point(160, 8);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(29, 20);
            this.label81.TabIndex = 145;
            this.label81.Text = "℃";
            // 
            // tbTemp
            // 
            this.tbTemp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbTemp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTemp.ForeColor = System.Drawing.Color.Black;
            this.tbTemp.Location = new System.Drawing.Point(3, 3);
            this.tbTemp.MaxLength = 5;
            this.tbTemp.Multiline = true;
            this.tbTemp.Name = "tbTemp";
            this.tbTemp.Size = new System.Drawing.Size(89, 27);
            this.tbTemp.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F);
            this.label6.Location = new System.Drawing.Point(534, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 196;
            this.label6.Text = "分娩日期:";
            // 
            // dtDeliveryDate
            // 
            this.dtDeliveryDate.Location = new System.Drawing.Point(639, 3);
            this.dtDeliveryDate.Name = "dtDeliveryDate";
            this.dtDeliveryDate.Size = new System.Drawing.Size(189, 30);
            this.dtDeliveryDate.TabIndex = 197;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F);
            this.label7.Location = new System.Drawing.Point(959, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 198;
            this.label7.Text = "出院日期:";
            // 
            // dtLeaveHospitalDate
            // 
            this.dtLeaveHospitalDate.Location = new System.Drawing.Point(1064, 3);
            this.dtLeaveHospitalDate.Name = "dtLeaveHospitalDate";
            this.dtLeaveHospitalDate.Size = new System.Drawing.Size(188, 30);
            this.dtLeaveHospitalDate.TabIndex = 199;
            // 
            // label95
            // 
            this.label95.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(105, 510);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(79, 20);
            this.label95.TabIndex = 200;
            this.label95.Text = "联系人:";
            // 
            // txtReferralContacts
            // 
            this.txtReferralContacts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReferralContacts.ForeColor = System.Drawing.Color.Black;
            this.txtReferralContacts.Location = new System.Drawing.Point(190, 504);
            this.txtReferralContacts.MaxLength = 20;
            this.txtReferralContacts.Name = "txtReferralContacts";
            this.txtReferralContacts.ReadOnly = true;
            this.txtReferralContacts.Size = new System.Drawing.Size(173, 30);
            this.txtReferralContacts.TabIndex = 201;
            // 
            // label96
            // 
            this.label96.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label96.AutoSize = true;
            this.label96.Font = new System.Drawing.Font("宋体", 15F);
            this.label96.Location = new System.Drawing.Point(534, 510);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(99, 20);
            this.label96.TabIndex = 202;
            this.label96.Text = "联系电话:";
            // 
            // txtReferralContactsTel
            // 
            this.txtReferralContactsTel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReferralContactsTel.ForeColor = System.Drawing.Color.Black;
            this.txtReferralContactsTel.Location = new System.Drawing.Point(639, 504);
            this.txtReferralContactsTel.MaxLength = 20;
            this.txtReferralContactsTel.Name = "txtReferralContactsTel";
            this.txtReferralContactsTel.ReadOnly = true;
            this.txtReferralContactsTel.Size = new System.Drawing.Size(159, 30);
            this.txtReferralContactsTel.TabIndex = 203;
            // 
            // label97
            // 
            this.label97.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(999, 510);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(59, 20);
            this.label97.TabIndex = 204;
            this.label97.Text = "结果:";
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.rdwdw);
            this.panel36.Controls.Add(this.rddw);
            this.panel36.Location = new System.Drawing.Point(1064, 504);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(205, 32);
            this.panel36.TabIndex = 205;
            // 
            // rdwdw
            // 
            this.rdwdw.AutoSize = true;
            this.rdwdw.Location = new System.Drawing.Point(90, 5);
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
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel7, 6);
            this.panel7.Controls.Add(this.picSignYs1);
            this.panel7.Controls.Add(this.lkYs);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.lkJs);
            this.panel7.Controls.Add(this.picSignJs);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(0, 583);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1355, 58);
            this.panel7.TabIndex = 206;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // picSignYs1
            // 
            this.picSignYs1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs1.Location = new System.Drawing.Point(192, 7);
            this.picSignYs1.Name = "picSignYs1";
            this.picSignYs1.Size = new System.Drawing.Size(203, 50);
            this.picSignYs1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs1.TabIndex = 211;
            this.picSignYs1.TabStop = false;
            this.picSignYs1.Click += new System.EventHandler(this.picSignYs1_Click);
            // 
            // lkYs
            // 
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(413, 17);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 209;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 20);
            this.label12.TabIndex = 210;
            this.label12.Text = "随访医生签名:";
            // 
            // lkJs
            // 
            this.lkJs.AutoSize = true;
            this.lkJs.Location = new System.Drawing.Point(958, 17);
            this.lkJs.Name = "lkJs";
            this.lkJs.Size = new System.Drawing.Size(89, 20);
            this.lkJs.TabIndex = 174;
            this.lkJs.TabStop = true;
            this.lkJs.Text = "重置签名";
            this.lkJs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // picSignJs
            // 
            this.picSignJs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJs.Location = new System.Drawing.Point(732, 7);
            this.picSignJs.Name = "picSignJs";
            this.picSignJs.Size = new System.Drawing.Size(203, 50);
            this.picSignJs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJs.TabIndex = 0;
            this.picSignJs.TabStop = false;
            this.picSignJs.Click += new System.EventHandler(this.picSignJs_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(577, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 20);
            this.label9.TabIndex = 206;
            this.label9.Text = "居民/家属签名:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(52, 5);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 20);
            this.lbName.TabIndex = 173;
            this.lbName.Text = "姓名:";
            // 
            // AfterKidBirthVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "AfterKidBirthVisitForm";
            this.Text = "AfterKidBirthVisitForm";
            this.Load += new System.EventHandler(this.FrmAftChildBirth_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel33.ResumeLayout(false);
            this.panel33.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).EndInit();
            this.ResumeLayout(false);

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
                this.txtReferralContacts.ReadOnly = false;
                this.txtReferralContactsTel.ReadOnly = false;
                this.panel36.Enabled = true;
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
                this.txtReferralContacts.Clear();
                this.txtReferralContactsTel.Clear();
                this.txtReferralContacts.ReadOnly = true;
                this.txtReferralContactsTel.ReadOnly = true;
                this.panel36.Enabled = false;
                this.rdwdw.Checked = false;
                this.rddw.Checked = false;
            }
        }

        public bool SaveModelToDB()
        {
            if (GlbTools.IsChanged(this.srcData, this.GrvPostpartum, new string[] { "Referral", "NextfollowupDate", "VisitDate" }))
            {
               
                WomenGravidaPostpartumBLL gravida_postpartum = new WomenGravidaPostpartumBLL();
                if (gravida_postpartum.Exists(this.GrvPostpartum.ID))
                {
                    gravida_postpartum.Update(this.GrvPostpartum);
                }
                else
                {
                    gravida_postpartum.Add(this.GrvPostpartum);
                }
            }
            return true;
        }

        public void UpdataToModel()
        {
            if (this.rdZhuanzhenNo.Checked)
            {
                this.GrvPostpartum.Referral = "1";
            }
            if (this.rdZhuanzhenHave.Checked)
            {
                this.GrvPostpartum.Referral = "2";
            }
            if (this.rddw.Checked)
            {
                this.GrvPostpartum.ReferralResult = "1";
            }
            else if (this.rdwdw.Checked)
            {
                this.GrvPostpartum.ReferralResult = "2";
            }
            this.GrvPostpartum.FollowupDate = new DateTime?(this.dtpVisitDate.Value.Date);
            this.GrvPostpartum.NextFollowupDate = new DateTime?(this.dtpNext.Value.Date);
            this.GrvPostpartum.DeliveryDate = new DateTime?(this.dtDeliveryDate.Value.Date);
            this.GrvPostpartum.LeaveHospitalDate = new DateTime?(this.dtLeaveHospitalDate.Value.Date);
        }

        public bool EveryThingIsOk { get; set; }

        private WomenGravidaPostpartumModel GrvPostpartum { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public object srcData { get; set; }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_PostpartumS", picSignJs);
        }


        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_PostpartumS_Doc", picSignYs1);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

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
        private void picSignYs1_Click(object sender, EventArgs e)
        {
            Sign("_PostpartumS_Doc", picSignYs1);
        }

        private void picSignJs_Click(object sender, EventArgs e)
        {
            Sign("_PostpartumS", picSignJs);
        }
    }
}

