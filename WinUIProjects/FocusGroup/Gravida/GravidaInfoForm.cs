
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

namespace FocusGroup.Gravida
{
    public class GravidaInfoForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<WomenGravidaBaseInfoModel> bindingManager;
        private IContainer components;
        private WomenGravidaBaseInfoModel GravidaInfo;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label33;
        private TextBox tbCardNum;
        private Panel panel3;
        private Label label18;
        private Label label20;
        private TextBox tbAftTown;
        private TextBox tbAftVillage;
        private Panel panel2;
        private Label label7;
        private Label label11;
        private TextBox tbCurTown;
        private TextBox tbCurVillage;
        private Label label4;
        private Label label16;
        private Label label5;
        private TextBox tbAge;
        private ComboBox cbKnowlage;
        private ComboBox cbProfession;
        private Label label19;
        private TextBox tbIDCARD;
        private Label label8;
        private Label label9;
        private TextBox tbCurAdrPhone;
        private Label label2;
        private TextBox tbNation;
        private Label label10;
        private Panel panel4;
        private Label label13;
        private Label label12;
        private TextBox tbHukoTown;
        private TextBox tbHukoVillage;
        private Label label6;
        private Label label21;
        private TextBox tbAftAddPhone;
        private TextBox tbJobUnit;
        private Label label14;
        private Label label22;
        private TextBox tbJobUnitPhone;
        private Label label15;
        private Panel panel5;
        private ComboBox cbHbJob;
        private Label label29;
        private TextBox tbHusbandJobPhone;
        private Label label28;
        private TextBox tbHusbandJobUnit;
        private Label label27;
        private TextBox tbHusbandNation;
        private Label label26;
        private TextBox tbKnowlageLev;
        private Label label25;
        private TextBox tbHusbandAges;
        private Label label24;
        private Label label23;
        private TextBox tbHusbandName;
        private Label label30;
        private TextBox tbCreateUnit;
        private Label label31;
        private Label label32;
        private TextBox tbCreatedDate;
        private TextBox tbCreateUnitPhone;
        private TextBox tbName;
        private Label label3;
        private TextBox tbAfterAddr;
        private TextBox tbBirthday;
        private Label label1;
        private ComboBox cbLiveStatus;
        private Label label17;
        private TextBox tbHusbandPhone;
        private TextBox tbAddr;
        public GravidaForm par_From;

        public GravidaInfoForm()
        {
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.EveryThingIsOk = false;
            this.InitCombox();
        }

        public ChildFormStatus CheckErrorInput()
        {
            if (this.bindingManager.ErrorInput)
            {
                return ChildFormStatus.HasErrorInput;
            }
            return ChildFormStatus.NoErrorInput;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmGravidaInfo_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void InitCombox()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("文盲", "1"),
                new ItemDictonaryModel<string>("小学", "2"),
                new ItemDictonaryModel<string>("初中", "3"),
                new ItemDictonaryModel<string>("高中", "4"),
                new ItemDictonaryModel<string>("中专", "5"),
                new ItemDictonaryModel<string>("大专", "6"),
                new ItemDictonaryModel<string>("本科", "7"),
                new ItemDictonaryModel<string>("硕士", "8"),
                new ItemDictonaryModel<string>("博士", "9"),
                new ItemDictonaryModel<string>("其他", "10")
            };
            this.cbKnowlage.DisplayMember = "DISPLAYMEMBER";
            this.cbKnowlage.ValueMember = "VALUEMEMBER";
            this.cbKnowlage.DataSource = list;
            List<ItemDictonaryModel<string>> list2 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("工人", "1"),
                new ItemDictonaryModel<string>("农民", "2"),
                new ItemDictonaryModel<string>("教师", "3"),
                new ItemDictonaryModel<string>("公务员", "4"),
                new ItemDictonaryModel<string>("自由职业者", "5"),
                new ItemDictonaryModel<string>("个体户", "6"),
                new ItemDictonaryModel<string>("军人", "7"),
                new ItemDictonaryModel<string>("医生", "8"),
                new ItemDictonaryModel<string>("无业", "9"),
                new ItemDictonaryModel<string>("其他", "10")
            };
            this.cbProfession.DisplayMember = "DISPLAYMEMBER";
            this.cbProfession.ValueMember = "VALUEMEMBER";
            this.cbProfession.DataSource = list2;
            List<ItemDictonaryModel<string>> list3 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("工人", "1"),
                new ItemDictonaryModel<string>("农民", "2"),
                new ItemDictonaryModel<string>("教师", "3"),
                new ItemDictonaryModel<string>("公务员", "4"),
                new ItemDictonaryModel<string>("自由职业者", "5"),
                new ItemDictonaryModel<string>("个体户", "6"),
                new ItemDictonaryModel<string>("军人", "7"),
                new ItemDictonaryModel<string>("医生", "8"),
                new ItemDictonaryModel<string>("无业", "9"),
                new ItemDictonaryModel<string>("其他", "10")
            };
            this.cbHbJob.DisplayMember = "DISPLAYMEMBER";
            this.cbHbJob.ValueMember = "VALUEMEMBER";
            this.cbHbJob.DataSource = list3;
            List<ItemDictonaryModel<string>> list4 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("本地户籍常住", "1"),
                new ItemDictonaryModel<string>("本地户籍不常住", "2"),
                new ItemDictonaryModel<string>("外地户籍常住", "3"),
                new ItemDictonaryModel<string>("其他", "4")
            };
            this.cbLiveStatus.DisplayMember = "DISPLAYMEMBER";
            this.cbLiveStatus.ValueMember = "VALUEMEMBER";
            this.cbLiveStatus.DataSource = list4;
            this.inputRanges = new List<InputRangeDec>();
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("Address", 200));
            this.inputrange_str.Add(new InputRangeStr("Phone", 15));
            this.inputrange_str.Add(new InputRangeStr("HealthResot", 100));
            this.inputrange_str.Add(new InputRangeStr("TownName", 100));
            this.inputrange_str.Add(new InputRangeStr("VillageName", 50));
            this.inputrange_str.Add(new InputRangeStr("PwPhone", 15));
            this.inputrange_str.Add(new InputRangeStr("HusbandName", 30));
            this.inputrange_str.Add(new InputRangeStr("HusbandPhone", 15));
            this.inputrange_str.Add(new InputRangeStr("HouseholdTown", 100));
            this.inputrange_str.Add(new InputRangeStr("HouseholdVillage", 100));
            this.inputrange_str.Add(new InputRangeStr("AddrTown", 100));
            this.inputrange_str.Add(new InputRangeStr("AddrVillage", 100));
            this.inputrange_str.Add(new InputRangeStr("AddrPhone", 15));
            this.inputrange_str.Add(new InputRangeStr("WorkUnit", 100));
            this.inputrange_str.Add(new InputRangeStr("UnitPhone", 15));
            this.inputrange_str.Add(new InputRangeStr("HusbandCulture", 30));
            this.inputrange_str.Add(new InputRangeStr("HusbandNation", 30));
            this.inputrange_str.Add(new InputRangeStr("HusbandUnit", 100));
            this.inputrange_str.Add(new InputRangeStr("HbUnitPhone", 15));
            this.inputrange_str.Add(new InputRangeStr("CardNum", 10));
            this.inputrange_str.Add(new InputRangeStr("CreatePhone", 15));
            this.inputrange_str.Add(new InputRangeStr("CardNum", 30));
            this.inputRanges.Add(new InputRangeDec("HusbandAge", 100M, false));
        }

        public void InitEveryThing()
        {
            this.GravidaInfo = new WomenGravidaBaseInfoBLL().GetModel(this.Model.IDCardNo);
            if (this.GravidaInfo == null)
            {
                WomenGravidaBaseInfoModel womenGravidaBaseInfoBLL = new WomenGravidaBaseInfoModel {
                    IDCardNo = this.Model.IDCardNo
                };
                this.GravidaInfo = womenGravidaBaseInfoBLL;
                this.GravidaInfo.RecordID = this.Model.RecordID;
                this.GravidaInfo.CreateUnit = new decimal?(ConfigHelper.GetNodeDec("orgCode"));
                this.GravidaInfo.CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.GravidaInfo.CreatedDate = new DateTime?(DateTime.Today);
                this.GravidaInfo.Living = this.Model.LiveType;
            }
            else
            {
                this.GravidaInfo.LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.GravidaInfo.LastUpdateDate = new DateTime?(DateTime.Today);
            }
            this.par_From.GravidaInfo = this.GravidaInfo;
            this.GravidaInfo.Birthday = this.Model.Birthday;
            this.GravidaInfo.Age = new decimal?(DateTime.Today.Year - this.GravidaInfo.Birthday.Value.Year);
            this.GravidaInfo.Address = this.Model.Address;
            this.GravidaInfo.Nation = this.Model.Nation;
            this.GravidaInfo.Name = this.Model.CustomerName;
            if (string.IsNullOrEmpty(this.GravidaInfo.Phone))
            {
                this.GravidaInfo.Phone = this.Model.Phone;
            }
            if (string.IsNullOrEmpty(this.GravidaInfo.WorkUnit))
            {
                this.GravidaInfo.WorkUnit = this.Model.WorkUnit;
            }
            if (!this.GravidaInfo.CreatedDate.HasValue)
            {
                this.GravidaInfo.CreatedDate = new DateTime?(DateTime.Today);
            }
            this.srcData = GlbTools.DeepCopy(this.GravidaInfo);
            this.bindingManager = new SimpleBindingManager<WomenGravidaBaseInfoModel>(this.inputRanges, this.inputrange_str, this.GravidaInfo);
            this.tbIDCARD.Text = this.GravidaInfo.IDCardNo;
            this.bindingManager.SimpleBinding(this.tbCardNum, "CardNum", false);
            this.tbName.Text = this.GravidaInfo.Name;
            this.tbAge.Text = this.GravidaInfo.Age.ToString();
            this.bindingManager.SimpleBinding(this.cbKnowlage, "Culture");
            this.bindingManager.SimpleBinding(this.cbProfession, "Job");
            this.bindingManager.SimpleBinding(this.tbAddr, "Address", false);
            if (this.GravidaInfo.Nation == "1")
            {
                this.tbNation.Text = "汉族";
            }
            else
            {
                this.tbNation.Text = this.Model.Minority;
            }
            this.GravidaInfo.Nation = !(this.Model.Nation == "1") ? (!this.Model.Minority.Contains("回") ? "3" : "2") : "1";
            this.tbBirthday.Text = this.GravidaInfo.Birthday.Value.ToShortDateString();
            this.bindingManager.SimpleBinding(this.cbLiveStatus, "Living");
            this.bindingManager.SimpleBinding(this.tbAftTown, "TownName", false);
            this.bindingManager.SimpleBinding(this.tbAftVillage, "VillageName", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbAftAddPhone, "PwPhone", false);
            this.bindingManager.SimpleBinding(this.tbHusbandName, "HusbandName", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbHusbandPhone, "HusbandPhone", false);
            this.bindingManager.SimpleBinding(this.tbHukoTown, "HouseholdTown", false);
            this.bindingManager.SimpleBinding(this.tbHukoVillage, "HouseholdVillage", false);
            this.bindingManager.SimpleBinding(this.tbCurTown, "AddrTown", false);
            this.bindingManager.SimpleBinding(this.tbCurVillage, "AddrVillage", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbCurAdrPhone, "AddrPhone", false);
            this.bindingManager.SimpleBinding(this.tbJobUnit, "WorkUnit", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbJobUnitPhone, "UnitPhone", false);
            this.bindingManager.SimpleBinding(this.tbHusbandAges, "HusbandAge", true);
            this.bindingManager.SimpleBinding(this.tbKnowlageLev, "HusbandCulture", false);
            this.bindingManager.SimpleBinding(this.tbHusbandNation, "HusbandNation", false);
            this.bindingManager.SimpleBinding(this.tbHusbandJobUnit, "HusbandUnit", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbHusbandJobPhone, "HbUnitPhone", false);
            this.bindingManager.SimpleBinding(this.cbHbJob, "HusbandJob");
            this.bindingManager.SimpleBindingPhoneNum(this.tbCreateUnitPhone, "CreatePhone", false);

            if (this.GravidaInfo.CreateDate != null && this.GravidaInfo.CreateDate.Value.ToString() != "")
            {
                this.tbCreatedDate.Text = this.GravidaInfo.CreateDate.Value.ToShortDateString();
            }
            else
            {
                this.tbCreatedDate.Text = DateTime.Now.ToString();
            }
            this.EveryThingIsOk = true;
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label33 = new System.Windows.Forms.Label();
            this.tbCardNum = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbAftTown = new System.Windows.Forms.TextBox();
            this.tbAftVillage = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbCurTown = new System.Windows.Forms.TextBox();
            this.tbCurVillage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.cbKnowlage = new System.Windows.Forms.ComboBox();
            this.cbProfession = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbIDCARD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCurAdrPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbHukoTown = new System.Windows.Forms.TextBox();
            this.tbHukoVillage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tbAftAddPhone = new System.Windows.Forms.TextBox();
            this.tbJobUnit = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbJobUnitPhone = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbHbJob = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tbHusbandJobPhone = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbHusbandJobUnit = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbHusbandNation = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbKnowlageLev = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbHusbandAges = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tbHusbandName = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbCreateUnit = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbCreatedDate = new System.Windows.Forms.TextBox();
            this.tbCreateUnitPhone = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAfterAddr = new System.Windows.Forms.TextBox();
            this.tbBirthday = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLiveStatus = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbHusbandPhone = new System.Windows.Forms.TextBox();
            this.tbAddr = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.tbAfterAddr);
            this.panel1.Controls.Add(this.tbBirthday);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbLiveStatus);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.tbHusbandPhone);
            this.panel1.Controls.Add(this.tbAddr);
            this.panel1.Location = new System.Drawing.Point(21, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 474);
            this.panel1.TabIndex = 0;
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
            this.tableLayoutPanel1.Controls.Add(this.label33, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbCardNum, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbAge, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbKnowlage, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbProfession, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label19, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbIDCARD, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbCurAdrPhone, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbNation, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label21, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbAftAddPhone, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbJobUnit, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label22, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbJobUnitPhone, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label30, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbCreateUnit, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label31, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.label32, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbCreatedDate, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbCreateUnitPhone, 5, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(56, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1375, 389);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(545, 9);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 20);
            this.label33.TabIndex = 150;
            this.label33.Text = "卡    号:";
            // 
            // tbCardNum
            // 
            this.tbCardNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCardNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCardNum.Font = new System.Drawing.Font("宋体", 15F);
            this.tbCardNum.ForeColor = System.Drawing.Color.Black;
            this.tbCardNum.Location = new System.Drawing.Point(650, 4);
            this.tbCardNum.MaxLength = 15;
            this.tbCardNum.Name = "tbCardNum";
            this.tbCardNum.Size = new System.Drawing.Size(173, 30);
            this.tbCardNum.TabIndex = 1;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 3);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.tbAftTown);
            this.panel3.Controls.Add(this.tbAftVillage);
            this.panel3.Location = new System.Drawing.Point(190, 142);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(633, 39);
            this.panel3.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(641, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 20);
            this.label18.TabIndex = 155;
            this.label18.Text = "村(号)";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(215, 12);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(129, 20);
            this.label20.TabIndex = 153;
            this.label20.Text = "乡、镇(街道)";
            // 
            // tbAftTown
            // 
            this.tbAftTown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAftTown.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbAftTown.Font = new System.Drawing.Font("宋体", 15F);
            this.tbAftTown.ForeColor = System.Drawing.Color.Black;
            this.tbAftTown.Location = new System.Drawing.Point(3, 8);
            this.tbAftTown.MaxLength = 15;
            this.tbAftTown.Name = "tbAftTown";
            this.tbAftTown.Size = new System.Drawing.Size(197, 30);
            this.tbAftTown.TabIndex = 0;
            // 
            // tbAftVillage
            // 
            this.tbAftVillage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAftVillage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbAftVillage.Font = new System.Drawing.Font("宋体", 15F);
            this.tbAftVillage.ForeColor = System.Drawing.Color.Black;
            this.tbAftVillage.Location = new System.Drawing.Point(346, 4);
            this.tbAftVillage.MaxLength = 15;
            this.tbAftVillage.Name = "tbAftVillage";
            this.tbAftVillage.Size = new System.Drawing.Size(283, 30);
            this.tbAftVillage.TabIndex = 1;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.tbCurTown);
            this.panel2.Controls.Add(this.tbCurVillage);
            this.panel2.Location = new System.Drawing.Point(190, 107);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(632, 35);
            this.panel2.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(640, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 155;
            this.label7.Text = "村(号)";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(216, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 153;
            this.label11.Text = "乡、镇(街道)";
            // 
            // tbCurTown
            // 
            this.tbCurTown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCurTown.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCurTown.Font = new System.Drawing.Font("宋体", 15F);
            this.tbCurTown.ForeColor = System.Drawing.Color.Black;
            this.tbCurTown.Location = new System.Drawing.Point(3, 5);
            this.tbCurTown.MaxLength = 15;
            this.tbCurTown.Name = "tbCurTown";
            this.tbCurTown.Size = new System.Drawing.Size(197, 30);
            this.tbCurTown.TabIndex = 0;
            // 
            // tbCurVillage
            // 
            this.tbCurVillage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCurVillage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCurVillage.Font = new System.Drawing.Font("宋体", 15F);
            this.tbCurVillage.ForeColor = System.Drawing.Color.Black;
            this.tbCurVillage.Location = new System.Drawing.Point(346, 4);
            this.tbCurVillage.MaxLength = 15;
            this.tbCurVillage.Name = "tbCurVillage";
            this.tbCurVillage.Size = new System.Drawing.Size(283, 30);
            this.tbCurVillage.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(88, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 112;
            this.label4.Text = "年    龄:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(545, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 111;
            this.label16.Text = "文化程度:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(1002, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 133;
            this.label5.Text = "职    业:";
            // 
            // tbAge
            // 
            this.tbAge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAge.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbAge.Font = new System.Drawing.Font("宋体", 15F);
            this.tbAge.ForeColor = System.Drawing.Color.Black;
            this.tbAge.Location = new System.Drawing.Point(193, 41);
            this.tbAge.MaxLength = 2;
            this.tbAge.Name = "tbAge";
            this.tbAge.ReadOnly = true;
            this.tbAge.Size = new System.Drawing.Size(197, 30);
            this.tbAge.TabIndex = 3;
            // 
            // cbKnowlage
            // 
            this.cbKnowlage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbKnowlage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKnowlage.Font = new System.Drawing.Font("宋体", 15F);
            this.cbKnowlage.FormattingEnabled = true;
            this.cbKnowlage.Location = new System.Drawing.Point(650, 41);
            this.cbKnowlage.Name = "cbKnowlage";
            this.cbKnowlage.Size = new System.Drawing.Size(173, 28);
            this.cbKnowlage.TabIndex = 4;
            // 
            // cbProfession
            // 
            this.cbProfession.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbProfession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfession.Font = new System.Drawing.Font("宋体", 15F);
            this.cbProfession.FormattingEnabled = true;
            this.cbProfession.Location = new System.Drawing.Point(1107, 41);
            this.cbProfession.Name = "cbProfession";
            this.cbProfession.Size = new System.Drawing.Size(208, 28);
            this.cbProfession.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(1002, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 20);
            this.label19.TabIndex = 111;
            this.label19.Text = "民    族:";
            // 
            // tbIDCARD
            // 
            this.tbIDCARD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbIDCARD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbIDCARD.Font = new System.Drawing.Font("宋体", 15F);
            this.tbIDCARD.ForeColor = System.Drawing.Color.Black;
            this.tbIDCARD.Location = new System.Drawing.Point(193, 4);
            this.tbIDCARD.MaxLength = 18;
            this.tbIDCARD.Name = "tbIDCARD";
            this.tbIDCARD.ReadOnly = true;
            this.tbIDCARD.Size = new System.Drawing.Size(197, 30);
            this.tbIDCARD.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(88, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 129;
            this.label8.Text = "身份证号:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(1002, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 130;
            this.label9.Text = "电    话:";
            // 
            // tbCurAdrPhone
            // 
            this.tbCurAdrPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCurAdrPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCurAdrPhone.Font = new System.Drawing.Font("宋体", 15F);
            this.tbCurAdrPhone.ForeColor = System.Drawing.Color.Black;
            this.tbCurAdrPhone.Location = new System.Drawing.Point(1107, 110);
            this.tbCurAdrPhone.MaxLength = 15;
            this.tbCurAdrPhone.Name = "tbCurAdrPhone";
            this.tbCurAdrPhone.Size = new System.Drawing.Size(208, 30);
            this.tbCurAdrPhone.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(68, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 138;
            this.label2.Text = "产后修养地:";
            // 
            // tbNation
            // 
            this.tbNation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbNation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNation.Font = new System.Drawing.Font("宋体", 15F);
            this.tbNation.ForeColor = System.Drawing.Color.Black;
            this.tbNation.Location = new System.Drawing.Point(1107, 72);
            this.tbNation.MaxLength = 15;
            this.tbNation.Name = "tbNation";
            this.tbNation.ReadOnly = true;
            this.tbNation.Size = new System.Drawing.Size(208, 30);
            this.tbNation.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(68, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 20);
            this.label10.TabIndex = 151;
            this.label10.Text = "户口所在地:";
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 3);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.tbHukoTown);
            this.panel4.Controls.Add(this.tbHukoVillage);
            this.panel4.Location = new System.Drawing.Point(190, 67);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(632, 40);
            this.panel4.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(641, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 20);
            this.label13.TabIndex = 155;
            this.label13.Text = "号(村)";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(215, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 20);
            this.label12.TabIndex = 153;
            this.label12.Text = "乡、镇(街道)";
            // 
            // tbHukoTown
            // 
            this.tbHukoTown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHukoTown.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHukoTown.Font = new System.Drawing.Font("宋体", 15F);
            this.tbHukoTown.ForeColor = System.Drawing.Color.Black;
            this.tbHukoTown.Location = new System.Drawing.Point(3, 9);
            this.tbHukoTown.MaxLength = 15;
            this.tbHukoTown.Name = "tbHukoTown";
            this.tbHukoTown.Size = new System.Drawing.Size(197, 30);
            this.tbHukoTown.TabIndex = 142;
            // 
            // tbHukoVillage
            // 
            this.tbHukoVillage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHukoVillage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHukoVillage.Font = new System.Drawing.Font("宋体", 15F);
            this.tbHukoVillage.ForeColor = System.Drawing.Color.Black;
            this.tbHukoVillage.Location = new System.Drawing.Point(346, 8);
            this.tbHukoVillage.MaxLength = 15;
            this.tbHukoVillage.Name = "tbHukoVillage";
            this.tbHukoVillage.Size = new System.Drawing.Size(283, 30);
            this.tbHukoVillage.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(88, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 134;
            this.label6.Text = "现 住 址:";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(1002, 151);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 20);
            this.label21.TabIndex = 155;
            this.label21.Text = "电    话:";
            // 
            // tbAftAddPhone
            // 
            this.tbAftAddPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAftAddPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbAftAddPhone.Font = new System.Drawing.Font("宋体", 15F);
            this.tbAftAddPhone.ForeColor = System.Drawing.Color.Black;
            this.tbAftAddPhone.Location = new System.Drawing.Point(1107, 146);
            this.tbAftAddPhone.MaxLength = 15;
            this.tbAftAddPhone.Name = "tbAftAddPhone";
            this.tbAftAddPhone.Size = new System.Drawing.Size(208, 30);
            this.tbAftAddPhone.TabIndex = 11;
            // 
            // tbJobUnit
            // 
            this.tbJobUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbJobUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbJobUnit.Font = new System.Drawing.Font("宋体", 15F);
            this.tbJobUnit.ForeColor = System.Drawing.Color.Black;
            this.tbJobUnit.Location = new System.Drawing.Point(193, 186);
            this.tbJobUnit.MaxLength = 15;
            this.tbJobUnit.Name = "tbJobUnit";
            this.tbJobUnit.Size = new System.Drawing.Size(197, 30);
            this.tbJobUnit.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(88, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 20);
            this.label14.TabIndex = 157;
            this.label14.Text = "工作单位:";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(545, 191);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 20);
            this.label22.TabIndex = 158;
            this.label22.Text = "电    话:";
            // 
            // tbJobUnitPhone
            // 
            this.tbJobUnitPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbJobUnitPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbJobUnitPhone.Font = new System.Drawing.Font("宋体", 15F);
            this.tbJobUnitPhone.ForeColor = System.Drawing.Color.Black;
            this.tbJobUnitPhone.Location = new System.Drawing.Point(650, 186);
            this.tbJobUnitPhone.MaxLength = 15;
            this.tbJobUnitPhone.Name = "tbJobUnitPhone";
            this.tbJobUnitPhone.Size = new System.Drawing.Size(173, 30);
            this.tbJobUnitPhone.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(62, 262);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.tableLayoutPanel1.SetRowSpan(this.label15, 2);
            this.label15.Size = new System.Drawing.Size(128, 18);
            this.label15.TabIndex = 146;
            this.label15.Text = "丈夫信息:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel5, 5);
            this.panel5.Controls.Add(this.cbHbJob);
            this.panel5.Controls.Add(this.label29);
            this.panel5.Controls.Add(this.tbHusbandJobPhone);
            this.panel5.Controls.Add(this.label28);
            this.panel5.Controls.Add(this.tbHusbandJobUnit);
            this.panel5.Controls.Add(this.label27);
            this.panel5.Controls.Add(this.tbHusbandNation);
            this.panel5.Controls.Add(this.label26);
            this.panel5.Controls.Add(this.tbKnowlageLev);
            this.panel5.Controls.Add(this.label25);
            this.panel5.Controls.Add(this.tbHusbandAges);
            this.panel5.Controls.Add(this.label24);
            this.panel5.Controls.Add(this.label23);
            this.panel5.Controls.Add(this.tbHusbandName);
            this.panel5.Location = new System.Drawing.Point(190, 221);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.tableLayoutPanel1.SetRowSpan(this.panel5, 2);
            this.panel5.Size = new System.Drawing.Size(874, 100);
            this.panel5.TabIndex = 14;
            // 
            // cbHbJob
            // 
            this.cbHbJob.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbHbJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHbJob.Font = new System.Drawing.Font("宋体", 15F);
            this.cbHbJob.FormattingEnabled = true;
            this.cbHbJob.Location = new System.Drawing.Point(686, 60);
            this.cbHbJob.Name = "cbHbJob";
            this.cbHbJob.Size = new System.Drawing.Size(173, 28);
            this.cbHbJob.TabIndex = 11;
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(619, 65);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 20);
            this.label29.TabIndex = 10;
            this.label29.Text = "职业:";
            // 
            // tbHusbandJobPhone
            // 
            this.tbHusbandJobPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandJobPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandJobPhone.Font = new System.Drawing.Font("宋体", 15F);
            this.tbHusbandJobPhone.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandJobPhone.Location = new System.Drawing.Point(394, 60);
            this.tbHusbandJobPhone.MaxLength = 15;
            this.tbHusbandJobPhone.Name = "tbHusbandJobPhone";
            this.tbHusbandJobPhone.Size = new System.Drawing.Size(173, 30);
            this.tbHusbandJobPhone.TabIndex = 9;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(325, 67);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(59, 20);
            this.label28.TabIndex = 8;
            this.label28.Text = "电话:";
            // 
            // tbHusbandJobUnit
            // 
            this.tbHusbandJobUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandJobUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandJobUnit.Font = new System.Drawing.Font("宋体", 15F);
            this.tbHusbandJobUnit.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandJobUnit.Location = new System.Drawing.Point(118, 60);
            this.tbHusbandJobUnit.MaxLength = 15;
            this.tbHusbandJobUnit.Name = "tbHusbandJobUnit";
            this.tbHusbandJobUnit.Size = new System.Drawing.Size(173, 30);
            this.tbHusbandJobUnit.TabIndex = 7;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(15, 67);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(99, 20);
            this.label27.TabIndex = 6;
            this.label27.Text = "工作单位:";
            // 
            // tbHusbandNation
            // 
            this.tbHusbandNation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandNation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandNation.Font = new System.Drawing.Font("宋体", 15F);
            this.tbHusbandNation.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandNation.Location = new System.Drawing.Point(762, 14);
            this.tbHusbandNation.MaxLength = 15;
            this.tbHusbandNation.Name = "tbHusbandNation";
            this.tbHusbandNation.Size = new System.Drawing.Size(99, 30);
            this.tbHusbandNation.TabIndex = 5;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(695, 20);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 20);
            this.label26.TabIndex = 4;
            this.label26.Text = "民族:";
            // 
            // tbKnowlageLev
            // 
            this.tbKnowlageLev.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbKnowlageLev.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbKnowlageLev.Font = new System.Drawing.Font("宋体", 15F);
            this.tbKnowlageLev.ForeColor = System.Drawing.Color.Black;
            this.tbKnowlageLev.Location = new System.Drawing.Point(570, 14);
            this.tbKnowlageLev.MaxLength = 15;
            this.tbKnowlageLev.Name = "tbKnowlageLev";
            this.tbKnowlageLev.Size = new System.Drawing.Size(99, 30);
            this.tbKnowlageLev.TabIndex = 3;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(465, 20);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(99, 20);
            this.label25.TabIndex = 2;
            this.label25.Text = "文化程度:";
            // 
            // tbHusbandAges
            // 
            this.tbHusbandAges.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandAges.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandAges.Font = new System.Drawing.Font("宋体", 15F);
            this.tbHusbandAges.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandAges.Location = new System.Drawing.Point(338, 14);
            this.tbHusbandAges.MaxLength = 3;
            this.tbHusbandAges.Name = "tbHusbandAges";
            this.tbHusbandAges.Size = new System.Drawing.Size(99, 30);
            this.tbHusbandAges.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(275, 20);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 20);
            this.label24.TabIndex = 160;
            this.label24.Text = "年龄:";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(10, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 20);
            this.label23.TabIndex = 159;
            this.label23.Text = "姓名:";
            // 
            // tbHusbandName
            // 
            this.tbHusbandName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandName.Font = new System.Drawing.Font("宋体", 15F);
            this.tbHusbandName.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandName.Location = new System.Drawing.Point(74, 14);
            this.tbHusbandName.MaxLength = 15;
            this.tbHusbandName.Name = "tbHusbandName";
            this.tbHusbandName.Size = new System.Drawing.Size(173, 30);
            this.tbHusbandName.TabIndex = 0;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(88, 345);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(99, 20);
            this.label30.TabIndex = 161;
            this.label30.Text = "建档单位:";
            this.label30.Visible = false;
            // 
            // tbCreateUnit
            // 
            this.tbCreateUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCreateUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCreateUnit.Font = new System.Drawing.Font("宋体", 15F);
            this.tbCreateUnit.ForeColor = System.Drawing.Color.Black;
            this.tbCreateUnit.Location = new System.Drawing.Point(193, 340);
            this.tbCreateUnit.MaxLength = 18;
            this.tbCreateUnit.Name = "tbCreateUnit";
            this.tbCreateUnit.ReadOnly = true;
            this.tbCreateUnit.Size = new System.Drawing.Size(173, 30);
            this.tbCreateUnit.TabIndex = 15;
            this.tbCreateUnit.Visible = false;
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(545, 345);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(99, 20);
            this.label31.TabIndex = 163;
            this.label31.Text = "建档时间:";
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(1002, 345);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(99, 20);
            this.label32.TabIndex = 164;
            this.label32.Text = "电    话:";
            // 
            // tbCreatedDate
            // 
            this.tbCreatedDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCreatedDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCreatedDate.Font = new System.Drawing.Font("宋体", 15F);
            this.tbCreatedDate.ForeColor = System.Drawing.Color.Black;
            this.tbCreatedDate.Location = new System.Drawing.Point(650, 340);
            this.tbCreatedDate.MaxLength = 15;
            this.tbCreatedDate.Name = "tbCreatedDate";
            this.tbCreatedDate.ReadOnly = true;
            this.tbCreatedDate.Size = new System.Drawing.Size(173, 30);
            this.tbCreatedDate.TabIndex = 16;
            // 
            // tbCreateUnitPhone
            // 
            this.tbCreateUnitPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCreateUnitPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCreateUnitPhone.Font = new System.Drawing.Font("宋体", 15F);
            this.tbCreateUnitPhone.ForeColor = System.Drawing.Color.Black;
            this.tbCreateUnitPhone.Location = new System.Drawing.Point(1107, 340);
            this.tbCreateUnitPhone.MaxLength = 15;
            this.tbCreateUnitPhone.Name = "tbCreateUnitPhone";
            this.tbCreateUnitPhone.Size = new System.Drawing.Size(173, 30);
            this.tbCreateUnitPhone.TabIndex = 17;
            // 
            // tbName
            // 
            this.tbName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.Font = new System.Drawing.Font("宋体", 15F);
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(1107, 4);
            this.tbName.MaxLength = 18;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(208, 30);
            this.tbName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(1002, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 101;
            this.label3.Text = "孕妇姓名:";
            // 
            // tbAfterAddr
            // 
            this.tbAfterAddr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAfterAddr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbAfterAddr.ForeColor = System.Drawing.Color.Black;
            this.tbAfterAddr.Location = new System.Drawing.Point(537, 474);
            this.tbAfterAddr.MaxLength = 15;
            this.tbAfterAddr.Name = "tbAfterAddr";
            this.tbAfterAddr.Size = new System.Drawing.Size(173, 23);
            this.tbAfterAddr.TabIndex = 4;
            this.tbAfterAddr.Visible = false;
            // 
            // tbBirthday
            // 
            this.tbBirthday.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbBirthday.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBirthday.ForeColor = System.Drawing.Color.Black;
            this.tbBirthday.Location = new System.Drawing.Point(346, 474);
            this.tbBirthday.MaxLength = 15;
            this.tbBirthday.Name = "tbBirthday";
            this.tbBirthday.Size = new System.Drawing.Size(173, 23);
            this.tbBirthday.TabIndex = 3;
            this.tbBirthday.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(795, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 151;
            this.label1.Text = "居住状态:";
            this.label1.Visible = false;
            // 
            // cbLiveStatus
            // 
            this.cbLiveStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbLiveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiveStatus.Font = new System.Drawing.Font("宋体", 15F);
            this.cbLiveStatus.FormattingEnabled = true;
            this.cbLiveStatus.Location = new System.Drawing.Point(902, 424);
            this.cbLiveStatus.Name = "cbLiveStatus";
            this.cbLiveStatus.Size = new System.Drawing.Size(173, 28);
            this.cbLiveStatus.TabIndex = 1;
            this.cbLiveStatus.Visible = false;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(1107, 430);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 20);
            this.label17.TabIndex = 156;
            this.label17.Text = "丈夫电话:";
            this.label17.Visible = false;
            // 
            // tbHusbandPhone
            // 
            this.tbHusbandPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandPhone.Font = new System.Drawing.Font("宋体", 15F);
            this.tbHusbandPhone.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandPhone.Location = new System.Drawing.Point(1220, 420);
            this.tbHusbandPhone.MaxLength = 15;
            this.tbHusbandPhone.Name = "tbHusbandPhone";
            this.tbHusbandPhone.Size = new System.Drawing.Size(173, 30);
            this.tbHusbandPhone.TabIndex = 2;
            this.tbHusbandPhone.Visible = false;
            // 
            // tbAddr
            // 
            this.tbAddr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAddr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbAddr.ForeColor = System.Drawing.Color.Black;
            this.tbAddr.Location = new System.Drawing.Point(716, 474);
            this.tbAddr.MaxLength = 15;
            this.tbAddr.Name = "tbAddr";
            this.tbAddr.Size = new System.Drawing.Size(173, 23);
            this.tbAddr.TabIndex = 5;
            this.tbAddr.Visible = false;
            // 
            // GravidaInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Name = "GravidaInfoForm";
            this.Text = "GravidaInfoForm";
            this.Load += new System.EventHandler(this.FrmGravidaInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            if (GlbTools.IsChanged(this.srcData, this.GravidaInfo, new string[0]))
            {
                WomenGravidaBaseInfoBLL womenGravidaBaseInfoBLL = new WomenGravidaBaseInfoBLL();
                if (this.GravidaInfo.LastUpdateDate.HasValue)
                {
                    womenGravidaBaseInfoBLL.Update(this.GravidaInfo);
                }
                else
                {
                    womenGravidaBaseInfoBLL.Add(this.GravidaInfo);
                }
            }
            return true;
        }

        public void UpdataToModel()
        {
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public object srcData { get; set; }
    }
}

