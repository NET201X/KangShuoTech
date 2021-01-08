using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.Kids
{
    using KangShuoTech.Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Data;

    public class KidsInfoForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<KidsBaseInfoModel> bindingManager;
        private IContainer components;
        private List<InputRangeStr> inputrange_str;
        private Panel panel1;
        private Label lbName;
        private MaskedTextBox mtbMother;
        private MaskedTextBox mtbFather;
        private Label label8;
        private Label label1;
        private Panel panel3;
        private MaskedTextBox mtbFatherIDCARD;
        private RadioButton rdf_15;
        private RadioButton rdf_18;
        private Label label13;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbCardNum;
        private Label label2;
        private Label label4;
        private Panel panel2;
        private MaskedTextBox mtbMotherIdCard;
        private RadioButton rd15;
        private RadioButton rd18;
        private Label label5;
        private TextBox tbName;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label14;
        private TextBox tbParentsOr;
        private Label label15;
        private TextBox tbFatherName;
        private Label label16;
        private TextBox tbFatherAges;
        private Label label17;
        private TextBox tbFatherWorkUnit;
        private Label label18;
        private TextBox tbFatherPhone;
        private Label label20;
        private TextBox tbMotherName;
        private Label label21;
        private TextBox tbMotherAges;
        private Label label22;
        private TextBox tbMotherWorkUnit;
        private Label label23;
        private TextBox tbMotherPhone;
        private Label label24;
        private TextBox tbGurdianName;
        private Label label25;
        private TextBox tbGurdianAges;
        private Label label26;
        private TextBox tbGurdianWorkUnit;
        private Label label27;
        private TextBox tbGurdianPhone;
        private Label label28;
        private TextBox tbAddr;
        private Label label3;
        private MaskedTextBox mtbMailNo;
        private Label label6;
        private TextBox tbCreatUnit;
        private Label label19;
        private TextBox tbUnitPhone;
        private Label label7;
        private TextBox tbTuoyou;
        private Label label9;
        private TextBox tbTuouyouPhone;
        private DateTimePicker dtpCreatedDate;
        private ToolTip toolTip1;
        private Label label29;
        private TextBox tbChildCard;
        private Button btnOk;
        private Button btnCancel;
        private List<InputRangeDec> inputRanges;
        private DateTimePicker tbBirthday;
        private ComboBox cmbSex;
        private Panel panel4;
        private RadioButton rdChild5;
        private RadioButton rdChild4;
        private RadioButton rdChild3;
        private RadioButton rdChild2;
        private RadioButton rdChild1;
        private bool isLink = false;

        public KidsInfoForm()
        {
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();
            this.InitEveryOne();
            this.tableLayoutPanel1.ResumeLayout();
            this.EveryThingIsOk = false;
        }
        public KidsInfoForm(RecordsBaseInfoModel p_model)
        {
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();
            this.InitEveryOne();
            this.tableLayoutPanel1.ResumeLayout();
            this.Model = p_model;
            this.btnOk.Visible = true;
            this.btnCancel.Visible = true;
            this.panel4.Visible = true;
            this.rd18.Enabled = false;
            this.rd15.Enabled = false;
            isLink = true;
            this.EveryThingIsOk = false;
        }
        public ChildFormStatus CheckErrorInput()
        {
            bool flag = false;
            if ((this.mtbMailNo.Text != "") && !this.mtbMailNo.MaskCompleted)
            {
                flag = true;
                this.mtbMailNo.BackColor = Color.Salmon;
            }
            bool flag2 = false;
            if ((this.mtbFather.Text != "") && !this.mtbFather.MaskCompleted)
            {
                flag2 = true;
                this.mtbFather.BackColor = Color.Salmon;
            }
            bool flag3 = false;
            if ((this.mtbMother.Text != "") && !this.mtbMother.MaskCompleted)
            {
                flag3 = true;
                this.mtbMother.BackColor = Color.Salmon;
            }
            bool flag4 = false;
            if ((this.mtbMotherIdCard.Text != "") && !this.mtbMotherIdCard.MaskCompleted)
            {
                flag4 = true;
                this.mtbMotherIdCard.BackColor = Color.Salmon;
            }
            ChildFormStatus status = (((this.bindingManager.ErrorInput || flag) || (flag2 || flag3)) || flag4) ? ChildFormStatus.HasErrorInput : ChildFormStatus.NoErrorInput;
            if (status == ChildFormStatus.HasErrorInput)
            {
                this.SaveDataInfo = this.bindingManager.WhatsUp;
            }
            return status;
        }

        private bool CompareSrcData()
        {
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmChildInfo_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void InitEveryOne()
        {
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("Fatherage", 200M, false));
            this.inputRanges.Add(new InputRangeDec("Motherage", 200M, false));
            this.inputRanges.Add(new InputRangeDec("GuarderAge", 200M, false));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("PostalCode", 6));
            this.inputrange_str.Add(new InputRangeStr("MotherIdcard", 0x12));
            this.inputrange_str.Add(new InputRangeStr("FatherID", 0x12));
            this.inputrange_str.Add(new InputRangeStr("MotherID", 0x12));
            this.inputrange_str.Add(new InputRangeStr("Guardstatus", 0x3e8));
            this.inputrange_str.Add(new InputRangeStr("CreateUnit", 200));
            InputRangeStr item = new InputRangeStr("CreateUnitPhone", 15) {
                Whatsup = "(建档单位)格式为:区号-座机号码，或手机号码\r\n"
            };
            this.inputrange_str.Add(item);
            this.inputrange_str.Add(new InputRangeStr("Childcare", 200));
            InputRangeStr str2 = new InputRangeStr("ChildcarePhone", 15) {
                Whatsup = "(托幼机构)格式为:区号-座机号码，或手机号码\r\n"
            };
            this.inputrange_str.Add(str2);
            this.inputrange_str.Add(new InputRangeStr("CardNum", 30));
            this.toolTip1.SetToolTip(this.tbTuouyouPhone, "固定电话格式为:区号-座机号码，或手机号码");
            this.toolTip1.SetToolTip(this.tbUnitPhone, "固定电话格式为:区号-座机号码，或手机号码");
        }

        public void InitEveryThing()
        {
            if (!isLink)
            {
                this.ChildInfo = new KidsBaseInfoBLL().GetModel(this.Model.IDCardNo);
                this.tbChildCard.Text = this.Model.IDCardNo;
                this.tbName.Text = this.Model.CustomerName;
                this.cmbSex.SelectedIndex = int.Parse(this.Model.Sex) - 1;
                if (this.Model.Birthday.HasValue)
                {
                    this.tbBirthday.Text = this.Model.Birthday.Value.ToShortDateString();
                }
                this.tbName.Enabled = false;
                this.tbBirthday.Enabled = false;
                this.tbMotherName.ReadOnly = false;
                this.tbMotherAges.ReadOnly = false;
                this.cmbSex.Enabled = false;
            }
            else
            {
                rdChild1.Checked = true;
                this.tbChildCard.Text = this.Model.IDCardNo + "C01";
                this.cmbSex.SelectedIndex = 0;
                this.tbMotherName.ReadOnly = true;
                this.tbMotherAges.ReadOnly = true;
                this.tbName.Enabled = true;
                this.tbBirthday.Enabled = true;
                this.mtbMotherIdCard.ReadOnly = true;
                this.cmbSex.Enabled = true;
            }
            if (this.ChildInfo == null)
            {
                this.ChildInfo = new KidsBaseInfoModel();
                this.ChildInfo.IDCardNo = this.Model.IDCardNo;
                this.ChildInfo.RecordID = this.Model.RecordID;
                this.ChildInfo.CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.ChildInfo.CreateUnit = ConfigHelper.GetNode("orgCode");
                this.ChildInfo.CreatedDate = new DateTime?(DateTime.Today);
                this.ChildInfo.Sex = this.Model.Sex;
                if (this.Model.Birthday.HasValue)
                {
                    this.ChildInfo.Birthday = new DateTime?(this.Model.Birthday.Value);
                }
                this.dtpCreatedDate.Enabled = true;
            }
            else
            {
                this.ChildInfo.LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.ChildInfo.LastUpdateDate = new DateTime?(DateTime.Today);
                this.dtpCreatedDate.Enabled = true;
                if (this.ChildInfo.OccurrenceTime.HasValue)
                {
                    this.dtpCreatedDate.Value = this.ChildInfo.OccurrenceTime.Value;
                }
            }
            if (isLink)
            {
                this.ChildInfo.MotherIdcard = this.Model.IDCardNo;
                this.ChildInfo.MotherName = this.Model.CustomerName;
                this.ChildInfo.Addr = this.Model.Address;
                string Unit = "";
                ConfigHelper.GetNode("orgCode", ref Unit);
                this.ChildInfo.CreateUnit = Unit;
                int num = DateTime.Today.Year - this.Model.Birthday.Value.Year;
                this.ChildInfo.MotherAge = num;
            }
            this.srcData = GlbTools.DeepCopy(this.ChildInfo);
            this.bindingManager = new SimpleBindingManager<KidsBaseInfoModel>(this.inputRanges, this.inputrange_str, this.ChildInfo);
            this.bindingManager.SimpleBinding(this.tbCardNum, "CardNum", false);
            this.bindingManager.SimpleBinding(this.tbParentsOr, "Guardstatus", false);
            this.bindingManager.SimpleBinding(this.tbFatherName, "FatherName", false);
            this.bindingManager.SimpleBinding(this.tbFatherAges, "Fatherage", true);
            this.bindingManager.SimpleBinding(this.tbFatherWorkUnit, "FatherUnit", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbFatherPhone, "FatherPhone", false);
            this.bindingManager.SimpleBinding(this.tbMotherName, "MotherName", false);
            this.bindingManager.SimpleBinding(this.tbMotherAges, "Motherage", true);
            this.bindingManager.SimpleBinding(this.tbMotherWorkUnit, "MotherUnit", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbMotherPhone, "MotherPhone", false);
            this.bindingManager.SimpleBinding(this.tbGurdianName, "GuarderName", false);
            this.bindingManager.SimpleBinding(this.tbGurdianAges, "GuarderAge", true);
            this.bindingManager.SimpleBinding(this.tbGurdianWorkUnit, "GuarderUnit", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbGurdianPhone, "GuarderPhone", false);
            if (string.IsNullOrEmpty(this.ChildInfo.Addr))
            {
                this.ChildInfo.Addr = this.Model.HouseHoldAddress;
            }
            this.bindingManager.SimpleBindingPhoneNum(this.tbAddr, "Addr", false);
            if (!string.IsNullOrEmpty(this.ChildInfo.MotherIdcard) && (this.ChildInfo.MotherIdcard.Length == 15))
            {
                this.rd15.Checked = true;
            }
            this.bindingManager.SimpleBinding(this.mtbMotherIdCard, "MotherIdcard", false);
            this.bindingManager.SimpleBinding(this.mtbMailNo, "PostalCode", false);
            this.bindingManager.SimpleBinding(this.tbCreatUnit, "CreateUnit", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbUnitPhone, "CreateUnitPhone", false);
            this.bindingManager.SimpleBinding(this.tbTuoyou, "Childcare", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbTuouyouPhone, "ChildcarePhone", false);
            this.EveryThingIsOk = true;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbName = new System.Windows.Forms.Label();
            this.mtbMother = new System.Windows.Forms.MaskedTextBox();
            this.mtbFather = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mtbFatherIDCARD = new System.Windows.Forms.MaskedTextBox();
            this.rdf_15 = new System.Windows.Forms.RadioButton();
            this.rdf_18 = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbCardNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mtbMotherIdCard = new System.Windows.Forms.MaskedTextBox();
            this.rd15 = new System.Windows.Forms.RadioButton();
            this.rd18 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbParentsOr = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbFatherName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbFatherAges = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbFatherWorkUnit = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbFatherPhone = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbMotherName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbMotherAges = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbMotherWorkUnit = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbMotherPhone = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbGurdianName = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbGurdianAges = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbGurdianWorkUnit = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbGurdianPhone = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbMailNo = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCreatUnit = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbUnitPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTuoyou = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTuouyouPhone = new System.Windows.Forms.TextBox();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.tbChildCard = new System.Windows.Forms.TextBox();
            this.tbBirthday = new System.Windows.Forms.DateTimePicker();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdChild5 = new System.Windows.Forms.RadioButton();
            this.rdChild4 = new System.Windows.Forms.RadioButton();
            this.rdChild3 = new System.Windows.Forms.RadioButton();
            this.rdChild2 = new System.Windows.Forms.RadioButton();
            this.rdChild1 = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.mtbMother);
            this.panel1.Controls.Add(this.mtbFather);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(82, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1372, 504);
            this.panel1.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(72, 503);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 20);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "姓名:";
            this.lbName.Visible = false;
            // 
            // mtbMother
            // 
            this.mtbMother.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbMother.Location = new System.Drawing.Point(117, 570);
            this.mtbMother.Mask = "00-00-00-000-000-00000";
            this.mtbMother.Name = "mtbMother";
            this.mtbMother.Size = new System.Drawing.Size(173, 30);
            this.mtbMother.TabIndex = 5;
            this.mtbMother.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbMother.Visible = false;
            // 
            // mtbFather
            // 
            this.mtbFather.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbFather.Location = new System.Drawing.Point(413, 569);
            this.mtbFather.Mask = "00-00-00-000-000-00000";
            this.mtbFather.Name = "mtbFather";
            this.mtbFather.Size = new System.Drawing.Size(173, 30);
            this.mtbFather.TabIndex = 6;
            this.mtbFather.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbFather.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(887, 511);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "父亲档案编号:";
            this.label8.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1167, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "父亲身份证号:";
            this.label1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mtbFatherIDCARD);
            this.panel3.Controls.Add(this.rdf_15);
            this.panel3.Controls.Add(this.rdf_18);
            this.panel3.Location = new System.Drawing.Point(690, 565);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 30);
            this.panel3.TabIndex = 7;
            this.panel3.Visible = false;
            // 
            // mtbFatherIDCARD
            // 
            this.mtbFatherIDCARD.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mtbFatherIDCARD.Location = new System.Drawing.Point(121, 4);
            this.mtbFatherIDCARD.Mask = "000000-00000000-000A";
            this.mtbFatherIDCARD.Name = "mtbFatherIDCARD";
            this.mtbFatherIDCARD.Size = new System.Drawing.Size(203, 30);
            this.mtbFatherIDCARD.TabIndex = 2;
            this.mtbFatherIDCARD.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // rdf_15
            // 
            this.rdf_15.AutoSize = true;
            this.rdf_15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdf_15.Location = new System.Drawing.Point(62, 6);
            this.rdf_15.Name = "rdf_15";
            this.rdf_15.Size = new System.Drawing.Size(67, 24);
            this.rdf_15.TabIndex = 1;
            this.rdf_15.Text = "15位";
            this.rdf_15.UseVisualStyleBackColor = true;
            // 
            // rdf_18
            // 
            this.rdf_18.AutoSize = true;
            this.rdf_18.Checked = true;
            this.rdf_18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdf_18.Location = new System.Drawing.Point(3, 6);
            this.rdf_18.Name = "rdf_18";
            this.rdf_18.Size = new System.Drawing.Size(67, 24);
            this.rdf_18.TabIndex = 0;
            this.rdf_18.TabStop = true;
            this.rdf_18.Text = "18位";
            this.rdf_18.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(606, 516);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "母亲档案编号:";
            this.label13.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.Controls.Add(this.tbCardNum, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label14, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbParentsOr, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbFatherName, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label16, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbFatherAges, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label17, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbFatherWorkUnit, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbFatherPhone, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label20, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbMotherName, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label21, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbMotherAges, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.label22, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbMotherWorkUnit, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.label23, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.tbMotherPhone, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label24, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbGurdianName, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label25, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbGurdianAges, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.label26, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbGurdianWorkUnit, 5, 8);
            this.tableLayoutPanel1.Controls.Add(this.label27, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tbGurdianPhone, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label28, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.tbAddr, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.mtbMailNo, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.tbCreatUnit, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.label19, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.tbUnitPhone, 4, 12);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.tbTuoyou, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.label9, 3, 13);
            this.tableLayoutPanel1.Controls.Add(this.tbTuouyouPhone, 4, 13);
            this.tableLayoutPanel1.Controls.Add(this.dtpCreatedDate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label29, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbChildCard, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbBirthday, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbSex, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(32, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1302, 497);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbCardNum
            // 
            this.tbCardNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCardNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCardNum.Font = new System.Drawing.Font("宋体", 15F);
            this.tbCardNum.ForeColor = System.Drawing.Color.Black;
            this.tbCardNum.Location = new System.Drawing.Point(183, 3);
            this.tbCardNum.MaxLength = 18;
            this.tbCardNum.Name = "tbCardNum";
            this.tbCardNum.Size = new System.Drawing.Size(184, 30);
            this.tbCardNum.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(78, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 181;
            this.label2.Text = "卡    号:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(38, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 112;
            this.label4.Text = "母亲身份证号:";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.mtbMotherIdCard);
            this.panel2.Controls.Add(this.rd15);
            this.panel2.Controls.Add(this.rd18);
            this.panel2.Location = new System.Drawing.Point(180, 34);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 33);
            this.panel2.TabIndex = 3;
            // 
            // mtbMotherIdCard
            // 
            this.mtbMotherIdCard.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mtbMotherIdCard.Location = new System.Drawing.Point(167, 2);
            this.mtbMotherIdCard.Mask = "000000-00000000-000A";
            this.mtbMotherIdCard.Name = "mtbMotherIdCard";
            this.mtbMotherIdCard.Size = new System.Drawing.Size(203, 30);
            this.mtbMotherIdCard.TabIndex = 2;
            this.mtbMotherIdCard.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // rd15
            // 
            this.rd15.AutoSize = true;
            this.rd15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rd15.Location = new System.Drawing.Point(91, 6);
            this.rd15.Name = "rd15";
            this.rd15.Size = new System.Drawing.Size(67, 24);
            this.rd15.TabIndex = 1;
            this.rd15.Text = "15位";
            this.rd15.UseVisualStyleBackColor = true;
            // 
            // rd18
            // 
            this.rd18.AutoSize = true;
            this.rd18.Checked = true;
            this.rd18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rd18.Location = new System.Drawing.Point(4, 6);
            this.rd18.Name = "rd18";
            this.rd18.Size = new System.Drawing.Size(67, 24);
            this.rd18.TabIndex = 0;
            this.rd18.TabStop = true;
            this.rd18.Text = "18位";
            this.rd18.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(78, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 183;
            this.label5.Text = "儿童姓名:";
            // 
            // tbName
            // 
            this.tbName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.Font = new System.Drawing.Font("宋体", 15F);
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(183, 70);
            this.tbName.MaxLength = 15;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(184, 30);
            this.tbName.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(511, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 185;
            this.label10.Text = "性    别:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(944, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 187;
            this.label11.Text = "出生日期:";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(78, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 189;
            this.label12.Text = "建档时间:";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(461, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 33);
            this.label14.TabIndex = 191;
            this.label14.Text = "父母或监护人情况:";
            // 
            // tbParentsOr
            // 
            this.tbParentsOr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbParentsOr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbParentsOr, 3);
            this.tbParentsOr.ForeColor = System.Drawing.Color.Black;
            this.tbParentsOr.Location = new System.Drawing.Point(616, 104);
            this.tbParentsOr.MaxLength = 15;
            this.tbParentsOr.Name = "tbParentsOr";
            this.tbParentsOr.Size = new System.Drawing.Size(515, 30);
            this.tbParentsOr.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(78, 141);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 20);
            this.label15.TabIndex = 193;
            this.label15.Text = "父亲姓名:";
            // 
            // tbFatherName
            // 
            this.tbFatherName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbFatherName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFatherName.Font = new System.Drawing.Font("宋体", 15F);
            this.tbFatherName.ForeColor = System.Drawing.Color.Black;
            this.tbFatherName.Location = new System.Drawing.Point(183, 137);
            this.tbFatherName.MaxLength = 15;
            this.tbFatherName.Name = "tbFatherName";
            this.tbFatherName.Size = new System.Drawing.Size(184, 30);
            this.tbFatherName.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(511, 141);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 195;
            this.label16.Text = "年    龄:";
            // 
            // tbFatherAges
            // 
            this.tbFatherAges.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbFatherAges.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFatherAges.ForeColor = System.Drawing.Color.Black;
            this.tbFatherAges.Location = new System.Drawing.Point(616, 137);
            this.tbFatherAges.MaxLength = 3;
            this.tbFatherAges.Name = "tbFatherAges";
            this.tbFatherAges.Size = new System.Drawing.Size(184, 30);
            this.tbFatherAges.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(944, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 20);
            this.label17.TabIndex = 197;
            this.label17.Text = "工作单位:";
            // 
            // tbFatherWorkUnit
            // 
            this.tbFatherWorkUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbFatherWorkUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFatherWorkUnit.ForeColor = System.Drawing.Color.Black;
            this.tbFatherWorkUnit.Location = new System.Drawing.Point(1049, 137);
            this.tbFatherWorkUnit.MaxLength = 15;
            this.tbFatherWorkUnit.Name = "tbFatherWorkUnit";
            this.tbFatherWorkUnit.Size = new System.Drawing.Size(184, 30);
            this.tbFatherWorkUnit.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(78, 175);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 20);
            this.label18.TabIndex = 199;
            this.label18.Text = "联系电话:";
            // 
            // tbFatherPhone
            // 
            this.tbFatherPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbFatherPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFatherPhone.Font = new System.Drawing.Font("宋体", 15F);
            this.tbFatherPhone.ForeColor = System.Drawing.Color.Black;
            this.tbFatherPhone.Location = new System.Drawing.Point(183, 172);
            this.tbFatherPhone.MaxLength = 15;
            this.tbFatherPhone.Name = "tbFatherPhone";
            this.tbFatherPhone.Size = new System.Drawing.Size(184, 30);
            this.tbFatherPhone.TabIndex = 12;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(78, 206);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 20);
            this.label20.TabIndex = 201;
            this.label20.Text = "母亲姓名:";
            // 
            // tbMotherName
            // 
            this.tbMotherName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMotherName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMotherName.Font = new System.Drawing.Font("宋体", 15F);
            this.tbMotherName.ForeColor = System.Drawing.Color.Black;
            this.tbMotherName.Location = new System.Drawing.Point(183, 204);
            this.tbMotherName.MaxLength = 15;
            this.tbMotherName.Name = "tbMotherName";
            this.tbMotherName.Size = new System.Drawing.Size(184, 30);
            this.tbMotherName.TabIndex = 13;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(511, 206);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 20);
            this.label21.TabIndex = 203;
            this.label21.Text = "年    龄:";
            // 
            // tbMotherAges
            // 
            this.tbMotherAges.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMotherAges.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMotherAges.ForeColor = System.Drawing.Color.Black;
            this.tbMotherAges.Location = new System.Drawing.Point(616, 204);
            this.tbMotherAges.MaxLength = 3;
            this.tbMotherAges.Name = "tbMotherAges";
            this.tbMotherAges.Size = new System.Drawing.Size(184, 30);
            this.tbMotherAges.TabIndex = 14;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(944, 206);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 20);
            this.label22.TabIndex = 205;
            this.label22.Text = "工作单位:";
            // 
            // tbMotherWorkUnit
            // 
            this.tbMotherWorkUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMotherWorkUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMotherWorkUnit.ForeColor = System.Drawing.Color.Black;
            this.tbMotherWorkUnit.Location = new System.Drawing.Point(1049, 204);
            this.tbMotherWorkUnit.MaxLength = 15;
            this.tbMotherWorkUnit.Name = "tbMotherWorkUnit";
            this.tbMotherWorkUnit.Size = new System.Drawing.Size(184, 30);
            this.tbMotherWorkUnit.TabIndex = 15;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(78, 240);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 20);
            this.label23.TabIndex = 207;
            this.label23.Text = "联系电话:";
            // 
            // tbMotherPhone
            // 
            this.tbMotherPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMotherPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMotherPhone.Font = new System.Drawing.Font("宋体", 15F);
            this.tbMotherPhone.ForeColor = System.Drawing.Color.Black;
            this.tbMotherPhone.Location = new System.Drawing.Point(183, 235);
            this.tbMotherPhone.MaxLength = 15;
            this.tbMotherPhone.Name = "tbMotherPhone";
            this.tbMotherPhone.Size = new System.Drawing.Size(184, 30);
            this.tbMotherPhone.TabIndex = 16;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(58, 278);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(119, 20);
            this.label24.TabIndex = 209;
            this.label24.Text = "监护人姓名:";
            // 
            // tbGurdianName
            // 
            this.tbGurdianName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbGurdianName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGurdianName.Font = new System.Drawing.Font("宋体", 15F);
            this.tbGurdianName.ForeColor = System.Drawing.Color.Black;
            this.tbGurdianName.Location = new System.Drawing.Point(183, 273);
            this.tbGurdianName.MaxLength = 15;
            this.tbGurdianName.Name = "tbGurdianName";
            this.tbGurdianName.Size = new System.Drawing.Size(184, 30);
            this.tbGurdianName.TabIndex = 17;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(511, 278);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(99, 20);
            this.label25.TabIndex = 211;
            this.label25.Text = "年    龄:";
            // 
            // tbGurdianAges
            // 
            this.tbGurdianAges.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbGurdianAges.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGurdianAges.ForeColor = System.Drawing.Color.Black;
            this.tbGurdianAges.Location = new System.Drawing.Point(616, 273);
            this.tbGurdianAges.MaxLength = 3;
            this.tbGurdianAges.Name = "tbGurdianAges";
            this.tbGurdianAges.Size = new System.Drawing.Size(184, 30);
            this.tbGurdianAges.TabIndex = 18;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(944, 278);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(99, 20);
            this.label26.TabIndex = 213;
            this.label26.Text = "工作单位:";
            // 
            // tbGurdianWorkUnit
            // 
            this.tbGurdianWorkUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbGurdianWorkUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGurdianWorkUnit.ForeColor = System.Drawing.Color.Black;
            this.tbGurdianWorkUnit.Location = new System.Drawing.Point(1049, 273);
            this.tbGurdianWorkUnit.MaxLength = 15;
            this.tbGurdianWorkUnit.Name = "tbGurdianWorkUnit";
            this.tbGurdianWorkUnit.Size = new System.Drawing.Size(184, 30);
            this.tbGurdianWorkUnit.TabIndex = 19;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(78, 314);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(99, 20);
            this.label27.TabIndex = 215;
            this.label27.Text = "联系电话:";
            // 
            // tbGurdianPhone
            // 
            this.tbGurdianPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbGurdianPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGurdianPhone.Font = new System.Drawing.Font("宋体", 15F);
            this.tbGurdianPhone.ForeColor = System.Drawing.Color.Black;
            this.tbGurdianPhone.Location = new System.Drawing.Point(183, 310);
            this.tbGurdianPhone.MaxLength = 15;
            this.tbGurdianPhone.Name = "tbGurdianPhone";
            this.tbGurdianPhone.Size = new System.Drawing.Size(184, 30);
            this.tbGurdianPhone.TabIndex = 20;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(78, 350);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(99, 20);
            this.label28.TabIndex = 217;
            this.label28.Text = "住    址:";
            // 
            // tbAddr
            // 
            this.tbAddr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAddr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbAddr, 2);
            this.tbAddr.Font = new System.Drawing.Font("宋体", 15F);
            this.tbAddr.ForeColor = System.Drawing.Color.Black;
            this.tbAddr.Location = new System.Drawing.Point(183, 345);
            this.tbAddr.MaxLength = 20;
            this.tbAddr.Name = "tbAddr";
            this.tbAddr.Size = new System.Drawing.Size(321, 30);
            this.tbAddr.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(78, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 101;
            this.label3.Text = "邮政编码:";
            // 
            // mtbMailNo
            // 
            this.mtbMailNo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbMailNo.Font = new System.Drawing.Font("宋体", 15F);
            this.mtbMailNo.Location = new System.Drawing.Point(183, 382);
            this.mtbMailNo.Mask = "000000";
            this.mtbMailNo.Name = "mtbMailNo";
            this.mtbMailNo.Size = new System.Drawing.Size(218, 30);
            this.mtbMailNo.TabIndex = 22;
            this.mtbMailNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(78, 429);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 134;
            this.label6.Text = "建档单位:";
            // 
            // tbCreatUnit
            // 
            this.tbCreatUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCreatUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCreatUnit.Font = new System.Drawing.Font("宋体", 15F);
            this.tbCreatUnit.ForeColor = System.Drawing.Color.Black;
            this.tbCreatUnit.Location = new System.Drawing.Point(183, 424);
            this.tbCreatUnit.MaxLength = 30;
            this.tbCreatUnit.Name = "tbCreatUnit";
            this.tbCreatUnit.Size = new System.Drawing.Size(184, 30);
            this.tbCreatUnit.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(724, 429);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(139, 20);
            this.label19.TabIndex = 111;
            this.label19.Text = "建档单位电话:";
            // 
            // tbUnitPhone
            // 
            this.tbUnitPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbUnitPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbUnitPhone.ForeColor = System.Drawing.Color.Black;
            this.tbUnitPhone.Location = new System.Drawing.Point(869, 424);
            this.tbUnitPhone.MaxLength = 15;
            this.tbUnitPhone.Name = "tbUnitPhone";
            this.tbUnitPhone.Size = new System.Drawing.Size(130, 30);
            this.tbUnitPhone.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(78, 468);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 129;
            this.label7.Text = "托幼机构:";
            // 
            // tbTuoyou
            // 
            this.tbTuoyou.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbTuoyou.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTuoyou.Font = new System.Drawing.Font("宋体", 15F);
            this.tbTuoyou.ForeColor = System.Drawing.Color.Black;
            this.tbTuoyou.Location = new System.Drawing.Point(183, 463);
            this.tbTuoyou.MaxLength = 15;
            this.tbTuoyou.Name = "tbTuoyou";
            this.tbTuoyou.Size = new System.Drawing.Size(184, 30);
            this.tbTuoyou.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(724, 468);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 130;
            this.label9.Text = "托幼机构电话:";
            // 
            // tbTuouyouPhone
            // 
            this.tbTuouyouPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbTuouyouPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTuouyouPhone.ForeColor = System.Drawing.Color.Black;
            this.tbTuouyouPhone.Location = new System.Drawing.Point(869, 463);
            this.tbTuouyouPhone.MaxLength = 15;
            this.tbTuouyouPhone.Name = "tbTuouyouPhone";
            this.tbTuouyouPhone.Size = new System.Drawing.Size(130, 30);
            this.tbTuouyouPhone.TabIndex = 26;
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.Font = new System.Drawing.Font("宋体", 15F);
            this.dtpCreatedDate.Location = new System.Drawing.Point(183, 104);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(184, 30);
            this.dtpCreatedDate.TabIndex = 7;
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(471, 7);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(139, 20);
            this.label29.TabIndex = 221;
            this.label29.Text = "儿童身份证号:";
            // 
            // tbChildCard
            // 
            this.tbChildCard.Location = new System.Drawing.Point(616, 3);
            this.tbChildCard.Name = "tbChildCard";
            this.tbChildCard.Size = new System.Drawing.Size(186, 30);
            this.tbChildCard.TabIndex = 1;
            // 
            // tbBirthday
            // 
            this.tbBirthday.Location = new System.Drawing.Point(1049, 70);
            this.tbBirthday.Name = "tbBirthday";
            this.tbBirthday.Size = new System.Drawing.Size(187, 30);
            this.tbBirthday.TabIndex = 6;
            // 
            // cmbSex
            // 
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cmbSex.Location = new System.Drawing.Point(616, 70);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(186, 28);
            this.cmbSex.TabIndex = 5;
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.rdChild5);
            this.panel4.Controls.Add(this.rdChild4);
            this.panel4.Controls.Add(this.rdChild3);
            this.panel4.Controls.Add(this.rdChild2);
            this.panel4.Controls.Add(this.rdChild1);
            this.panel4.Location = new System.Drawing.Point(869, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(405, 28);
            this.panel4.TabIndex = 2;
            this.panel4.Visible = false;
            // 
            // rdChild5
            // 
            this.rdChild5.AutoSize = true;
            this.rdChild5.Location = new System.Drawing.Point(319, 2);
            this.rdChild5.Name = "rdChild5";
            this.rdChild5.Size = new System.Drawing.Size(67, 24);
            this.rdChild5.TabIndex = 4;
            this.rdChild5.TabStop = true;
            this.rdChild5.Text = "五胎";
            this.rdChild5.UseVisualStyleBackColor = true;
            this.rdChild5.CheckedChanged += new System.EventHandler(this.rdChild5_CheckedChanged);
            // 
            // rdChild4
            // 
            this.rdChild4.AutoSize = true;
            this.rdChild4.Location = new System.Drawing.Point(239, 2);
            this.rdChild4.Name = "rdChild4";
            this.rdChild4.Size = new System.Drawing.Size(67, 24);
            this.rdChild4.TabIndex = 3;
            this.rdChild4.TabStop = true;
            this.rdChild4.Text = "四胎";
            this.rdChild4.UseVisualStyleBackColor = true;
            this.rdChild4.CheckedChanged += new System.EventHandler(this.rdChild4_CheckedChanged);
            // 
            // rdChild3
            // 
            this.rdChild3.AutoSize = true;
            this.rdChild3.Location = new System.Drawing.Point(157, 2);
            this.rdChild3.Name = "rdChild3";
            this.rdChild3.Size = new System.Drawing.Size(67, 24);
            this.rdChild3.TabIndex = 2;
            this.rdChild3.TabStop = true;
            this.rdChild3.Text = "三胎";
            this.rdChild3.UseVisualStyleBackColor = true;
            this.rdChild3.CheckedChanged += new System.EventHandler(this.rdChild3_CheckedChanged);
            // 
            // rdChild2
            // 
            this.rdChild2.AutoSize = true;
            this.rdChild2.Location = new System.Drawing.Point(80, 2);
            this.rdChild2.Name = "rdChild2";
            this.rdChild2.Size = new System.Drawing.Size(67, 24);
            this.rdChild2.TabIndex = 1;
            this.rdChild2.TabStop = true;
            this.rdChild2.Text = "二胎";
            this.rdChild2.UseVisualStyleBackColor = true;
            this.rdChild2.CheckedChanged += new System.EventHandler(this.rdChild2_CheckedChanged);
            // 
            // rdChild1
            // 
            this.rdChild1.AutoSize = true;
            this.rdChild1.Location = new System.Drawing.Point(3, 2);
            this.rdChild1.Name = "rdChild1";
            this.rdChild1.Size = new System.Drawing.Size(67, 24);
            this.rdChild1.TabIndex = 0;
            this.rdChild1.TabStop = true;
            this.rdChild1.Text = "一胎";
            this.rdChild1.UseVisualStyleBackColor = true;
            this.rdChild1.CheckedChanged += new System.EventHandler(this.rdChild1_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 15F);
            this.btnOk.Location = new System.Drawing.Point(1126, 603);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 42);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "完成";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 15F);
            this.btnCancel.Location = new System.Drawing.Point(1256, 603);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 42);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // KidsInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "KidsInfoForm";
            this.Text = "KidsInfoForm";
            this.Load += new System.EventHandler(this.FrmChildInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        private void rd15_CheckedChanged(object sender, EventArgs e)
        {
            this.mtbMotherIdCard.Mask = "000000-000000-000";
        }

        private void rd18_CheckedChanged(object sender, EventArgs e)
        {
            this.mtbMotherIdCard.Mask = "000000-00000000-000A";
        }

        private void rdf_15_CheckedChanged(object sender, EventArgs e)
        {
            this.mtbFatherIDCARD.Mask = "000000-000000-000";
        }

        private void rdf_18_CheckedChanged(object sender, EventArgs e)
        {
            this.mtbFatherIDCARD.Mask = "000000-00000000-000A";
        }

        private void SaveFamilyInfo()
        {
            RecordsFamilyInfoBLL recordsFamilyInfoBLL = new RecordsFamilyInfoBLL();
            RecordsFamilyInfoModel familyInfo = recordsFamilyInfoBLL.GetModel(this.Model.IDCardNo);
            if (familyInfo == null)
            {
                RecordsFamilyInfoModel archive_family_info = new RecordsFamilyInfoModel
                {
                    RecordID = this.Model.RecordID,
                    IDCardNo = this.Model.IDCardNo,
                    ToiletType = "1",
                    HouseType = "1",
                    LiveStatus = "1",
                    CreatedDate = new DateTime?(DateTime.Today),
                    FamilyRecordID = this.Model.IDCardNo,
                    CreateBy = ConfigHelper.GetNode("doctor"),
                    CreateUnit = ConfigHelper.GetNode("orgCode"),
                    CustomerName = this.Model.CustomerName
                };
                familyInfo = archive_family_info;
                recordsFamilyInfoBLL.Add(familyInfo);

                RecordsBaseInfoBLL recordsBaseInfoBLL = new RecordsBaseInfoBLL();
                this.Model.FamilyIDCardNo = this.Model.IDCardNo;
                this.Model.HouseRelation = "1";
                recordsBaseInfoBLL.Update(this.Model);
            }
          

        }
        private bool SaveLoginInfo(RecordsBaseInfoModel baseInfo)
        {
            RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();

            baseInfo.Birthday = this.tbBirthday.Value;
            if (string.IsNullOrEmpty(baseInfo.RecordID))
            {

                string pValue = "";
                baseInfo.IsUpdate = "Y";
                if (ConfigHelper.GetNode("archiveid", ref pValue))
                {
                    baseInfo.RecordID = pValue;
                    if (pValue.Length == 12)
                    {
                        baseInfo.ProvinceID = new decimal?(decimal.Parse(pValue.Substring(0, 2)));
                        baseInfo.CityID = new decimal?(decimal.Parse(pValue.Substring(0, 4)));
                        baseInfo.DistrictID = new decimal?(decimal.Parse(pValue.Substring(0, 6)));
                        baseInfo.TownID = new decimal?(decimal.Parse(pValue.Substring(0, 9)));
                        baseInfo.VillageID = new decimal?(decimal.Parse(pValue.Substring(0, 12)));
                    }
                }
                else
                {
                    baseInfo.RecordID = "000000000000";
                }
                string str3 = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";
                if (ConfigHelper.GetNode("orgCode", ref str5))
                {
                    baseInfo.OrgProvinceID = new decimal?(decimal.Parse(str5.Substring(0, 2)));
                    baseInfo.OrgCityID = new decimal?(decimal.Parse(str5.Substring(0, 4)));
                    baseInfo.OrgDistrictID = new decimal?(decimal.Parse(str5.Substring(0, 6)));
                    baseInfo.CreateUnit = new decimal?(decimal.Parse(str5));
                    if (str5.Length >= 9)
                    {
                        baseInfo.OrgTownID = new decimal?(decimal.Parse(str5.Substring(0, 9)));
                    }
                    if (str5.Length == 12)
                    {
                        baseInfo.OrgVillageID = new decimal?(decimal.Parse(str5.Substring(0, 12)));
                    }
                }
                if (ConfigHelper.GetNode("orgName", ref str6))
                {
                    baseInfo.CreateUnitName = str6;
                }
                if (ConfigHelper.GetNode("TownName", ref str3))
                {
                    baseInfo.TownName = str3;
                }
                if (ConfigHelper.GetNode("VillageName", ref str4))
                {
                    baseInfo.VillageName = str4;
                }
                string str7 = "";
                if (ConfigHelper.GetNode("doctor", ref str7))
                {
                    baseInfo.CreateBy = str7.ToString();
                    baseInfo.LastUpdateBy = str7.ToString();
                }
                string node = this.Model.Doctor;
                baseInfo.CreateMenName = node;
                baseInfo.Doctor = node;
                baseInfo.CreateDate = new DateTime?(DateTime.Today);
                baseInfo.ContactName = "";
                if (archive_baseinfo.Add(baseInfo) <= 0)
                {
                    MessageBox.Show("个人信息表新增失败", "新增个人信息", MessageBoxButtons.OK);
                    return false;
                }
            }
            this.ChildInfo.RecordID = baseInfo.RecordID;
            return true;
        }
        /// <summary>
        /// 身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        public bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 18位身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        private bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 15位身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        private bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }
        public bool SaveModelToDB()
        {
            if (GlbTools.IsChanged(this.srcData, this.ChildInfo, new string[0]))
            {
                KidsBaseInfoBLL child_baseinfo = new KidsBaseInfoBLL();

                if (this.tbChildCard.Text.ToString() != this.Model.IDCardNo)
                {
                      RecordsBaseInfoModel ChildBaseMode = new RecordsBaseInfoBLL().GetModel(this.tbChildCard.Text.ToString());
                      if (ChildBaseMode != null)
                      {
                          MessageBox.Show("新增儿童身份证已存在！");
                          return false;
                      }
                      else
                      {
                          if (!CheckIDCard(tbChildCard.Text.Trim()))
                          {
                              MessageBox.Show("身份证格式不正确！");
                              return false;
                          }
                      }
                      new RecordsBaseInfoBLL().UpdateIDCard(this.Model.IDCardNo,this.tbChildCard.Text.ToString()); 
                }

                if (child_baseinfo.Exists(this.ChildInfo.ID))
                {
                    child_baseinfo.Update(this.ChildInfo);
                }
                else
                {
                    child_baseinfo.Add(this.ChildInfo);

                }
            }
            return true;
        }

        public void UpdataToModel()
        {
            this.ChildInfo.OccurrenceTime = new DateTime?(this.dtpCreatedDate.Value.Date);
            this.ChildInfo.IDCardNo = this.tbChildCard.Text.ToString();
        }

        private KidsBaseInfoModel ChildInfo { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public object srcData { get; set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            KidsBaseInfoBLL child_baseinfo = new KidsBaseInfoBLL();
            string ss = this.Model.IDCardNo + "C";
            if (this.tbName.Text == "")
            {
                MessageBox.Show("请输入儿童姓名！");
                return;
            }
            if (this.tbChildCard.Text.ToString().Contains(ss) && this.tbChildCard.Text.ToString().Length > this.Model.IDCardNo.Length + 1)
            {
                RecordsBaseInfoModel ChildBaseMode = new RecordsBaseInfoBLL().GetModel(this.tbChildCard.Text.ToString());
                if (ChildBaseMode == null)
                {
                    RecordsBaseInfoModel ChildBaseMode2 = new RecordsBaseInfoModel
                    {
                        IDCardNo = tbChildCard.Text,
                        PopulationType = "2",
                        Address = tbAddr.Text,
                        HouseHoldAddress = tbAddr.Text,
                        CustomerName = tbName.Text,
                        Birthday =tbBirthday.Value,
                        CreateUnit = decimal.Parse(tbCreatUnit.Text),
                        FamilyIDCardNo=this.Model.IDCardNo
                    };
                    if (this.cmbSex.Text == "男")
                    {
                        ChildBaseMode2.Sex = "1";
                        ChildBaseMode2.HouseRelation = "7";
                    }
                    else if (this.cmbSex.Text == "女")
                    {
                        ChildBaseMode2.Sex = "2";
                        ChildBaseMode2.HouseRelation = "8";
                    }
                    else
                    {
                        ChildBaseMode2.Sex = "3";
                    }
                    if (SaveLoginInfo(ChildBaseMode2))
                    {
                        this.ChildInfo.OccurrenceTime = new DateTime?(this.dtpCreatedDate.Value.Date);
                        this.ChildInfo.IDCardNo = this.tbChildCard.Text.ToString();
                        this.ChildInfo.Birthday=this.tbBirthday.Value;
                        if (this.cmbSex.Text == "男")
                        {
                            this.ChildInfo.Sex = "1";
                        }
                        else if (this.cmbSex.Text == "女")
                        {
                            this.ChildInfo.Sex = "2";
                        }
                        else
                        {
                            this.ChildInfo.Sex = "3";
                        }
                        int count=child_baseinfo.Add(this.ChildInfo);
                        if (count > 0)
                        {
                            MessageBox.Show("保存成功！");
                            base.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("保存失败！");
                        }
                    }
                    SaveFamilyInfo();
                }
                else
                {
                    MessageBox.Show("儿童已存在！");
                }
            }
            else
            {
                MessageBox.Show("儿童身份证输入错误！");
            }
        }

        private void rdChild1_CheckedChanged(object sender, EventArgs e)
        {
            this.tbChildCard.Text = this.Model.IDCardNo + "C01";
        }

        private void rdChild2_CheckedChanged(object sender, EventArgs e)
        {
            this.tbChildCard.Text = this.Model.IDCardNo + "C02";
        }

        private void rdChild3_CheckedChanged(object sender, EventArgs e)
        {
            this.tbChildCard.Text = this.Model.IDCardNo + "C03";
        }

        private void rdChild4_CheckedChanged(object sender, EventArgs e)
        {
            this.tbChildCard.Text = this.Model.IDCardNo + "C04";
        }

        private void rdChild5_CheckedChanged(object sender, EventArgs e)
        {
            this.tbChildCard.Text = this.Model.IDCardNo + "C05";
        }
    }
}

