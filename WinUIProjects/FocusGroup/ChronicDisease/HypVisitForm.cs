
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.Utilities.Common;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using AxHWPenSignLib;
using System.Configuration;

namespace FocusGroup.ChronicDisease
{
    public class HypVisitForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private IContainer components;
        private DateTimePicker dtpVisit;
        private GroupBox groupBox1;
        private List<InputRangeStr> inputrange_str;
        private Label label1;
        private Label label15;
        private Label label37;
        private Label label38;
        private Label label43;
        private Panel panel1;
        private RadioButton radFamily;
        private RadioButton radMZ;
        private RadioButton radPhone;
        private TextBox tbDoctor;
        private List<YongYaoQKUserControl> yongyaos;
        private List<YongYaoQKUserControlYC> yongyaoyc;
        private Label label40;
        private Label label39;
        private CheckBox checkBox7;
        private CheckBox ckbgxb;
        private CheckBox ckbncz;
        private CheckBox checkBox2;
        private CheckBox checkBox6;
        private Panel panel6;
        private Panel panel4;
        private ManyCheckboxs<ChronicHypertensionVisitModel> zhengzhuang;
        private string visitdate;
        private Panel panel3;
        private GroupBox groupBox3;
        private ComboBox cbNextMeasures;
        private Label label49;
        private Button btnNoDrink;
        private Button btnNoSmoke;
        private ComboBox cbxSportMinTarget;
        private ComboBox cbxSportCountTarget;
        private ComboBox cbxSportMin;
        private ComboBox cbxSportCount;
        private TextBox tbAidExam;
        private Label label12;
        private TextBox tbdorctview;
        private TextBox tbBlfyxx;
        private Label label20;
        private ComboBox cbxBlfy;
        private ComboBox cbxFyycx;
        private Label label19;
        private Label label13;
        private Label label14;
        private ComboBox cbxYanTarget;
        private Label label35;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label27;
        private TextBox tbDrinkTarget;
        private Label label28;
        private Label label25;
        private TextBox tbSmokeCountTarget;
        private Label label26;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label21;
        private ComboBox cbxZyxw;
        private ComboBox cbxXltz;
        private ComboBox cbxYan;
        private Label label11;
        private Label label10;
        private Label label6;
        private Label label7;
        private TextBox tbDrink;
        private Label label8;
        private TextBox tbSomkeCount;
        private Label label9;
        private GroupBox groupBox6;
        private TextBox tbJgkb;
        private Label label47;
        private TextBox tbZzyy;
        private Label label48;
        private Panel panel5;
        private RadioButton rdzzno;
        private RadioButton rdzzyes;
        private DateTimePicker dtpNext;
        private LinkLabel linkLabel1;
        private Label label41;
        private Label label361;
        private GroupBox groupBox5;
        private YongYaoQKUserControl yongYaoQK4;
        private YongYaoQKUserControl yongYaoQK3;
        private YongYaoQKUserControl yongYaoQK2;
        private YongYaoQKUserControl yongYaoQK1;
        private YongYaoQKUserControlYC yongYaoYC4;
        private YongYaoQKUserControlYC yongYaoYC3;
        private YongYaoQKUserControlYC yongYaoYC2;
        private YongYaoQKUserControlYC yongYaoYC1;
        private GroupBox groupBox2;
        private Label label36;
        private Label label58;
        private Label label53;
        private Button btnNextBMI;
        private Button btnBMI;
        private Button btnWeightNext;
        private Label label17;
        private Label label45;
        private Label label16;
        private Label label44;
        private Button btnWeight;
        private TextBox tbWeight;
        private TextBox tbTzzsTarget;
        private Label label3;
        private Label label34;
        private TextBox tbWeightTarget;
        private Label label33;
        private Button btnXueya;
        private TextBox tbXinlv;
        private Label label32;
        private TextBox tbHight;
        private TextBox tbTzzs;
        private Label label18;
        private Label label4;
        private TextBox tbOther;
        private Label label5;
        private TextBox tbXueya;
        private Label label2;
        private GroupBox groupBox4;
        private Panel panel2;
        private CheckBox ckGroup10;
        private CheckBox ckGroup9;
        private CheckBox ckGroup8;
        private CheckBox ckGroup7;
        private CheckBox ckGroup6;
        private CheckBox ckGroup5;
        private CheckBox ckGroup4;
        private CheckBox ckGroup3;
        private CheckBox ckGroup2;
        private CheckBox ckGroup1;
        private TextBox tbZzOther;
        private GroupBox groupBox7;
        private YongYaoQKUserControl yongYaoTZ3;
        private YongYaoQKUserControl yongYaoTZ2;
        private YongYaoQKUserControl yongYaoTZ1;
        private YongYaoQKUserControlYC yongYaoYCTZ3;
        private YongYaoQKUserControlYC yongYaoYCTZ2;
        private YongYaoQKUserControlYC yongYaoYCTZ1;
        private Label label51;
        private TextBox txtReferralContacts;
        private Label label50;
        private Label label54;
        private TextBox tbRemark;
        private Label label52;
        private RadioButton rdwdw;
        private RadioButton rddw;
        private ChronicDiadetesVisitBLL dia_oper = new ChronicDiadetesVisitBLL();
        private LinkLabel lkJm;
        private PictureBox picSignJm;
        private List<YongYaoQKUserControl> yongyaotz;
        private List<YongYaoQKUserControlYC> yongyaoYCtz;
        private string SignS = "";
        private string SignDoc = ""; //医生签名
        private Panel panel7;
        private ComboBox cbVisitType;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label42;
        private GroupBox groupBox9;
        private GroupBox groupBox10;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/HypVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "HypVisit//"; //签名保存路径
        RequireBLL requireBLL = new RequireBLL();
        RecordsGeneralConditionBLL generalConditionBll = new RecordsGeneralConditionBLL();
        RecordsLifeStyleBLL lifeStyleBll = new RecordsLifeStyleBLL();
        ChronicHypertensionVisitBLL hypertensionVisitBll = new ChronicHypertensionVisitBLL();
        ChronicDrugConditionBLL drugConditionBll = new ChronicDrugConditionBLL();
        DataSet dsRequire = new DataSet();

        public HypVisitForm()
        {
            this.InitializeComponent();
            this.yongyaos = new List<YongYaoQKUserControl> { this.yongYaoQK1, this.yongYaoQK2, this.yongYaoQK3, this.yongYaoQK4 };
            this.yongyaotz = new List<YongYaoQKUserControl> { this.yongYaoTZ1, this.yongYaoTZ2, this.yongYaoTZ3 };
            this.yongyaoyc = new List<YongYaoQKUserControlYC> { this.yongYaoYC1, this.yongYaoYC2, this.yongYaoYC3, yongYaoYC4 };
            this.yongyaoYCtz = new List<YongYaoQKUserControlYC> { this.yongYaoYCTZ1, this.yongYaoYCTZ2, this.yongYaoYCTZ3 };

            yongYaoQK1.cbxFyycx = this.cbxFyycx;
            yongYaoQK2.cbxFyycx = this.cbxFyycx;
            yongYaoQK3.cbxFyycx = this.cbxFyycx;
            yongYaoQK4.cbxFyycx = this.cbxFyycx;
            yongYaoTZ1.cbxFyycx = this.cbxFyycx;
            yongYaoTZ2.cbxFyycx = this.cbxFyycx;
            yongYaoTZ3.cbxFyycx = this.cbxFyycx;

            yongYaoYC1.cbxFyycx = this.cbxFyycx;
            yongYaoYC2.cbxFyycx = this.cbxFyycx;
            yongYaoYC3.cbxFyycx = this.cbxFyycx;
            yongYaoYC4.cbxFyycx = this.cbxFyycx;
            yongYaoYCTZ1.cbxFyycx = this.cbxFyycx;
            yongYaoYCTZ2.cbxFyycx = this.cbxFyycx;
            yongYaoYCTZ3.cbxFyycx = this.cbxFyycx;

            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("CustomerName", 30));
            this.inputrange_str.Add(new InputRangeStr("FollowUpDoctor", 30));
            this.inputrange_str.Add(new InputRangeStr("Symptom", 30));
            this.inputrange_str.Add(new InputRangeStr("ReferralOrg", 30));
            this.inputrange_str.Add(new InputRangeStr("PhysicalSympToMother", 200));
            this.EveryThingIsOk = false;

            dsRequire = requireBLL.GetList("TabName = '高血压随访' AND Comment = '高血压随访信息' ");
        }
        
        private void InitializeComponent()
        {
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpVisit = new System.Windows.Forms.DateTimePicker();
            this.label43 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radMZ = new System.Windows.Forms.RadioButton();
            this.radPhone = new System.Windows.Forms.RadioButton();
            this.radFamily = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.ckbncz = new System.Windows.Forms.CheckBox();
            this.ckbgxb = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.yongYaoYC4 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoYC3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoYC2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoYC1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.yongYaoYCTZ3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoYCTZ2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoYCTZ1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.yongYaoTZ3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYaoTZ2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYaoTZ1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbSmokeCountTarget = new System.Windows.Forms.TextBox();
            this.cbVisitType = new System.Windows.Forms.ComboBox();
            this.cbNextMeasures = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.btnNoDrink = new System.Windows.Forms.Button();
            this.btnNoSmoke = new System.Windows.Forms.Button();
            this.cbxSportMinTarget = new System.Windows.Forms.ComboBox();
            this.cbxSportCountTarget = new System.Windows.Forms.ComboBox();
            this.cbxSportMin = new System.Windows.Forms.ComboBox();
            this.cbxSportCount = new System.Windows.Forms.ComboBox();
            this.tbAidExam = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbdorctview = new System.Windows.Forms.TextBox();
            this.tbBlfyxx = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbxBlfy = new System.Windows.Forms.ComboBox();
            this.cbxFyycx = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxYanTarget = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tbDrinkTarget = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cbxZyxw = new System.Windows.Forms.ComboBox();
            this.cbxXltz = new System.Windows.Forms.ComboBox();
            this.cbxYan = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDrink = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSomkeCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rddw = new System.Windows.Forms.RadioButton();
            this.rdwdw = new System.Windows.Forms.RadioButton();
            this.lkJm = new System.Windows.Forms.LinkLabel();
            this.picSignJm = new System.Windows.Forms.PictureBox();
            this.label54 = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.txtReferralContacts = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.tbJgkb = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.tbZzyy = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdzzno = new System.Windows.Forms.RadioButton();
            this.rdzzyes = new System.Windows.Forms.RadioButton();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label41 = new System.Windows.Forms.Label();
            this.label361 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.yongYaoQK4 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYaoQK3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYaoQK2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYaoQK1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbTzzsTarget = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.btnNextBMI = new System.Windows.Forms.Button();
            this.btnBMI = new System.Windows.Forms.Button();
            this.btnWeightNext = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.btnWeight = new System.Windows.Forms.Button();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tbWeightTarget = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.btnXueya = new System.Windows.Forms.Button();
            this.tbXinlv = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tbHight = new System.Windows.Forms.TextBox();
            this.tbTzzs = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOther = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbXueya = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckGroup10 = new System.Windows.Forms.CheckBox();
            this.ckGroup9 = new System.Windows.Forms.CheckBox();
            this.ckGroup8 = new System.Windows.Forms.CheckBox();
            this.ckGroup7 = new System.Windows.Forms.CheckBox();
            this.ckGroup6 = new System.Windows.Forms.CheckBox();
            this.ckGroup5 = new System.Windows.Forms.CheckBox();
            this.ckGroup4 = new System.Windows.Forms.CheckBox();
            this.ckGroup3 = new System.Windows.Forms.CheckBox();
            this.ckGroup2 = new System.Windows.Forms.CheckBox();
            this.ckGroup1 = new System.Windows.Forms.CheckBox();
            this.tbZzOther = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJm)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(218, 6);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(65, 12);
            this.label37.TabIndex = 4;
            this.label37.Text = "机构及科别";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(9, 7);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(53, 12);
            this.label38.TabIndex = 0;
            this.label38.Text = "转诊原因";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tbDoctor);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dtpVisit);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1352, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbDoctor
            // 
            this.tbDoctor.Font = new System.Drawing.Font("宋体", 15F);
            this.tbDoctor.Location = new System.Drawing.Point(475, 14);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(138, 30);
            this.tbDoctor.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F);
            this.label15.Location = new System.Drawing.Point(377, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 20);
            this.label15.TabIndex = 43;
            this.label15.Text = "随访医生";
            // 
            // dtpVisit
            // 
            this.dtpVisit.Font = new System.Drawing.Font("宋体", 15F);
            this.dtpVisit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVisit.Location = new System.Drawing.Point(119, 15);
            this.dtpVisit.Name = "dtpVisit";
            this.dtpVisit.Size = new System.Drawing.Size(160, 30);
            this.dtpVisit.TabIndex = 0;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 15F);
            this.label43.Location = new System.Drawing.Point(15, 20);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(99, 20);
            this.label43.TabIndex = 41;
            this.label43.Text = "随访日期:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radMZ);
            this.panel1.Controls.Add(this.radPhone);
            this.panel1.Controls.Add(this.radFamily);
            this.panel1.Font = new System.Drawing.Font("宋体", 15F);
            this.panel1.Location = new System.Drawing.Point(783, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 36);
            this.panel1.TabIndex = 2;
            // 
            // radMZ
            // 
            this.radMZ.AutoSize = true;
            this.radMZ.Location = new System.Drawing.Point(3, 4);
            this.radMZ.Name = "radMZ";
            this.radMZ.Size = new System.Drawing.Size(67, 24);
            this.radMZ.TabIndex = 0;
            this.radMZ.TabStop = true;
            this.radMZ.Text = "门诊";
            this.radMZ.UseVisualStyleBackColor = true;
            // 
            // radPhone
            // 
            this.radPhone.AutoSize = true;
            this.radPhone.Location = new System.Drawing.Point(209, 4);
            this.radPhone.Name = "radPhone";
            this.radPhone.Size = new System.Drawing.Size(67, 24);
            this.radPhone.TabIndex = 2;
            this.radPhone.TabStop = true;
            this.radPhone.Text = "电话";
            this.radPhone.UseVisualStyleBackColor = true;
            // 
            // radFamily
            // 
            this.radFamily.AutoSize = true;
            this.radFamily.Location = new System.Drawing.Point(110, 4);
            this.radFamily.Name = "radFamily";
            this.radFamily.Size = new System.Drawing.Size(67, 24);
            this.radFamily.TabIndex = 1;
            this.radFamily.TabStop = true;
            this.radFamily.Text = "家庭";
            this.radFamily.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(682, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "随访方式:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(3, 7);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(11, 12);
            this.label39.TabIndex = 1;
            this.label39.Text = "(";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(213, 7);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(11, 12);
            this.label40.TabIndex = 1;
            this.label40.Text = ")";
            // 
            // ckbncz
            // 
            this.ckbncz.AutoSize = true;
            this.ckbncz.Location = new System.Drawing.Point(18, 5);
            this.ckbncz.Name = "ckbncz";
            this.ckbncz.Size = new System.Drawing.Size(60, 16);
            this.ckbncz.TabIndex = 0;
            this.ckbncz.Text = "脑卒中";
            this.ckbncz.UseVisualStyleBackColor = true;
            // 
            // ckbgxb
            // 
            this.ckbgxb.AutoSize = true;
            this.ckbgxb.Location = new System.Drawing.Point(90, 5);
            this.ckbgxb.Name = "ckbgxb";
            this.ckbgxb.Size = new System.Drawing.Size(60, 16);
            this.ckbgxb.TabIndex = 0;
            this.ckbgxb.Text = "冠心病";
            this.ckbgxb.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(164, 5);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(48, 16);
            this.checkBox7.TabIndex = 0;
            this.checkBox7.Text = "其他";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(5, 6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 18);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "控制不满意";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(90, 5);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(68, 18);
            this.checkBox6.TabIndex = 0;
            this.checkBox6.Text = "冠心病";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label38);
            this.panel6.Controls.Add(this.label37);
            this.panel6.Location = new System.Drawing.Point(170, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(444, 28);
            this.panel6.TabIndex = 51;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label40);
            this.panel4.Controls.Add(this.checkBox7);
            this.panel4.Controls.Add(this.ckbgxb);
            this.panel4.Controls.Add(this.ckbncz);
            this.panel4.Controls.Add(this.label39);
            this.panel4.Location = new System.Drawing.Point(247, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(232, 25);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.groupBox10);
            this.panel3.Controls.Add(this.groupBox9);
            this.panel3.Controls.Add(this.groupBox7);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox6);
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(66, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 656);
            this.panel3.TabIndex = 6;
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.Transparent;
            this.groupBox10.Controls.Add(this.yongYaoYC4);
            this.groupBox10.Controls.Add(this.yongYaoYC3);
            this.groupBox10.Controls.Add(this.yongYaoYC2);
            this.groupBox10.Controls.Add(this.yongYaoYC1);
            this.groupBox10.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox10.Location = new System.Drawing.Point(15, 621);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1357, 119);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "目前用药情况";
            // 
            // yongYaoYC4
            // 
            this.yongYaoYC4.ErrorInput = false;
            this.yongYaoYC4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYC4.Location = new System.Drawing.Point(692, 74);
            this.yongYaoYC4.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYC4.MText = "其他药物";
            this.yongYaoYC4.Name = "yongYaoYC4";
            this.yongYaoYC4.Size = new System.Drawing.Size(643, 38);
            this.yongYaoYC4.Source.DailyTime = null;
            this.yongYaoYC4.Source.DosAge = null;
            this.yongYaoYC4.Source.drugtype = null;
            this.yongYaoYC4.Source.EveryTimeMg = null;
            this.yongYaoYC4.Source.factory = null;
            this.yongYaoYC4.Source.ID = 0;
            this.yongYaoYC4.Source.IDCardNo = null;
            this.yongYaoYC4.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoYC4.Source.Name = null;
            this.yongYaoYC4.Source.OUTKey = 0;
            this.yongYaoYC4.Source.Type = null;
            this.yongYaoYC4.TabIndex = 0;
            // 
            // yongYaoYC3
            // 
            this.yongYaoYC3.ErrorInput = false;
            this.yongYaoYC3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYC3.Location = new System.Drawing.Point(15, 74);
            this.yongYaoYC3.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYC3.MText = "药物名称3";
            this.yongYaoYC3.Name = "yongYaoYC3";
            this.yongYaoYC3.Size = new System.Drawing.Size(637, 38);
            this.yongYaoYC3.Source.DailyTime = null;
            this.yongYaoYC3.Source.DosAge = null;
            this.yongYaoYC3.Source.drugtype = null;
            this.yongYaoYC3.Source.EveryTimeMg = null;
            this.yongYaoYC3.Source.factory = null;
            this.yongYaoYC3.Source.ID = 0;
            this.yongYaoYC3.Source.IDCardNo = null;
            this.yongYaoYC3.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoYC3.Source.Name = null;
            this.yongYaoYC3.Source.OUTKey = 0;
            this.yongYaoYC3.Source.Type = null;
            this.yongYaoYC3.TabIndex = 1;
            // 
            // yongYaoYC2
            // 
            this.yongYaoYC2.ErrorInput = false;
            this.yongYaoYC2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYC2.Location = new System.Drawing.Point(693, 26);
            this.yongYaoYC2.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYC2.MText = "药物名称2";
            this.yongYaoYC2.Name = "yongYaoYC2";
            this.yongYaoYC2.Size = new System.Drawing.Size(642, 39);
            this.yongYaoYC2.Source.DailyTime = null;
            this.yongYaoYC2.Source.DosAge = null;
            this.yongYaoYC2.Source.drugtype = null;
            this.yongYaoYC2.Source.EveryTimeMg = null;
            this.yongYaoYC2.Source.factory = null;
            this.yongYaoYC2.Source.ID = 0;
            this.yongYaoYC2.Source.IDCardNo = null;
            this.yongYaoYC2.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoYC2.Source.Name = null;
            this.yongYaoYC2.Source.OUTKey = 0;
            this.yongYaoYC2.Source.Type = null;
            this.yongYaoYC2.TabIndex = 2;
            // 
            // yongYaoYC1
            // 
            this.yongYaoYC1.ErrorInput = false;
            this.yongYaoYC1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYC1.Location = new System.Drawing.Point(16, 26);
            this.yongYaoYC1.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYC1.MText = "药物名称1";
            this.yongYaoYC1.Name = "yongYaoYC1";
            this.yongYaoYC1.Size = new System.Drawing.Size(645, 37);
            this.yongYaoYC1.Source.DailyTime = null;
            this.yongYaoYC1.Source.DosAge = null;
            this.yongYaoYC1.Source.drugtype = null;
            this.yongYaoYC1.Source.EveryTimeMg = null;
            this.yongYaoYC1.Source.factory = null;
            this.yongYaoYC1.Source.ID = 0;
            this.yongYaoYC1.Source.IDCardNo = null;
            this.yongYaoYC1.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoYC1.Source.Name = null;
            this.yongYaoYC1.Source.OUTKey = 0;
            this.yongYaoYC1.Source.Type = null;
            this.yongYaoYC1.TabIndex = 3;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.yongYaoYCTZ3);
            this.groupBox9.Controls.Add(this.yongYaoYCTZ2);
            this.groupBox9.Controls.Add(this.yongYaoYCTZ1);
            this.groupBox9.Location = new System.Drawing.Point(9, 746);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1359, 111);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "用药调整意见";
            // 
            // yongYaoYCTZ3
            // 
            this.yongYaoYCTZ3.ErrorInput = false;
            this.yongYaoYCTZ3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYCTZ3.Location = new System.Drawing.Point(17, 70);
            this.yongYaoYCTZ3.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYCTZ3.MText = "药物名称3";
            this.yongYaoYCTZ3.Name = "yongYaoYCTZ3";
            this.yongYaoYCTZ3.Size = new System.Drawing.Size(645, 40);
            this.yongYaoYCTZ3.Source.DailyTime = null;
            this.yongYaoYCTZ3.Source.DosAge = null;
            this.yongYaoYCTZ3.Source.drugtype = null;
            this.yongYaoYCTZ3.Source.EveryTimeMg = null;
            this.yongYaoYCTZ3.Source.factory = null;
            this.yongYaoYCTZ3.Source.ID = 0;
            this.yongYaoYCTZ3.Source.IDCardNo = null;
            this.yongYaoYCTZ3.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoYCTZ3.Source.Name = null;
            this.yongYaoYCTZ3.Source.OUTKey = 0;
            this.yongYaoYCTZ3.Source.Type = null;
            this.yongYaoYCTZ3.TabIndex = 0;
            // 
            // yongYaoYCTZ2
            // 
            this.yongYaoYCTZ2.ErrorInput = false;
            this.yongYaoYCTZ2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYCTZ2.Location = new System.Drawing.Point(694, 25);
            this.yongYaoYCTZ2.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYCTZ2.MText = "药物名称2";
            this.yongYaoYCTZ2.Name = "yongYaoYCTZ2";
            this.yongYaoYCTZ2.Size = new System.Drawing.Size(650, 38);
            this.yongYaoYCTZ2.Source.DailyTime = null;
            this.yongYaoYCTZ2.Source.DosAge = null;
            this.yongYaoYCTZ2.Source.drugtype = null;
            this.yongYaoYCTZ2.Source.EveryTimeMg = null;
            this.yongYaoYCTZ2.Source.factory = null;
            this.yongYaoYCTZ2.Source.ID = 0;
            this.yongYaoYCTZ2.Source.IDCardNo = null;
            this.yongYaoYCTZ2.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoYCTZ2.Source.Name = null;
            this.yongYaoYCTZ2.Source.OUTKey = 0;
            this.yongYaoYCTZ2.Source.Type = null;
            this.yongYaoYCTZ2.TabIndex = 1;
            // 
            // yongYaoYCTZ1
            // 
            this.yongYaoYCTZ1.ErrorInput = false;
            this.yongYaoYCTZ1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYCTZ1.Location = new System.Drawing.Point(17, 25);
            this.yongYaoYCTZ1.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYCTZ1.MText = "药物名称1";
            this.yongYaoYCTZ1.Name = "yongYaoYCTZ1";
            this.yongYaoYCTZ1.Size = new System.Drawing.Size(675, 40);
            this.yongYaoYCTZ1.Source.DailyTime = null;
            this.yongYaoYCTZ1.Source.DosAge = null;
            this.yongYaoYCTZ1.Source.drugtype = null;
            this.yongYaoYCTZ1.Source.EveryTimeMg = null;
            this.yongYaoYCTZ1.Source.factory = null;
            this.yongYaoYCTZ1.Source.ID = 0;
            this.yongYaoYCTZ1.Source.IDCardNo = null;
            this.yongYaoYCTZ1.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoYCTZ1.Source.Name = null;
            this.yongYaoYCTZ1.Source.OUTKey = 0;
            this.yongYaoYCTZ1.Source.Type = null;
            this.yongYaoYCTZ1.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.yongYaoTZ3);
            this.groupBox7.Controls.Add(this.yongYaoTZ2);
            this.groupBox7.Controls.Add(this.yongYaoTZ1);
            this.groupBox7.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox7.Location = new System.Drawing.Point(11, 746);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1359, 111);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "用药调整意见";
            this.groupBox7.Visible = false;
            // 
            // yongYaoTZ3
            // 
            this.yongYaoTZ3.ErrorInput = false;
            this.yongYaoTZ3.Font = new System.Drawing.Font("宋体", 15F);
            this.yongYaoTZ3.Location = new System.Drawing.Point(3, 65);
            this.yongYaoTZ3.Margin = new System.Windows.Forms.Padding(5);
            this.yongYaoTZ3.MText = "药物名称3";
            this.yongYaoTZ3.Name = "yongYaoTZ3";
            this.yongYaoTZ3.Size = new System.Drawing.Size(679, 34);
            this.yongYaoTZ3.Source.DailyTime = null;
            this.yongYaoTZ3.Source.DosAge = null;
            this.yongYaoTZ3.Source.drugtype = null;
            this.yongYaoTZ3.Source.EveryTimeMg = null;
            this.yongYaoTZ3.Source.factory = null;
            this.yongYaoTZ3.Source.ID = 0;
            this.yongYaoTZ3.Source.IDCardNo = null;
            this.yongYaoTZ3.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoTZ3.Source.Name = null;
            this.yongYaoTZ3.Source.OUTKey = 0;
            this.yongYaoTZ3.Source.Type = null;
            this.yongYaoTZ3.TabIndex = 2;
            // 
            // yongYaoTZ2
            // 
            this.yongYaoTZ2.ErrorInput = false;
            this.yongYaoTZ2.Font = new System.Drawing.Font("宋体", 15F);
            this.yongYaoTZ2.Location = new System.Drawing.Point(684, 20);
            this.yongYaoTZ2.Margin = new System.Windows.Forms.Padding(5);
            this.yongYaoTZ2.MText = "药物名称2";
            this.yongYaoTZ2.Name = "yongYaoTZ2";
            this.yongYaoTZ2.Size = new System.Drawing.Size(660, 34);
            this.yongYaoTZ2.Source.DailyTime = null;
            this.yongYaoTZ2.Source.DosAge = null;
            this.yongYaoTZ2.Source.drugtype = null;
            this.yongYaoTZ2.Source.EveryTimeMg = null;
            this.yongYaoTZ2.Source.factory = null;
            this.yongYaoTZ2.Source.ID = 0;
            this.yongYaoTZ2.Source.IDCardNo = null;
            this.yongYaoTZ2.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoTZ2.Source.Name = null;
            this.yongYaoTZ2.Source.OUTKey = 0;
            this.yongYaoTZ2.Source.Type = null;
            this.yongYaoTZ2.TabIndex = 1;
            // 
            // yongYaoTZ1
            // 
            this.yongYaoTZ1.ErrorInput = false;
            this.yongYaoTZ1.Font = new System.Drawing.Font("宋体", 15F);
            this.yongYaoTZ1.Location = new System.Drawing.Point(3, 20);
            this.yongYaoTZ1.Margin = new System.Windows.Forms.Padding(5);
            this.yongYaoTZ1.MText = "药物名称1";
            this.yongYaoTZ1.Name = "yongYaoTZ1";
            this.yongYaoTZ1.Size = new System.Drawing.Size(675, 34);
            this.yongYaoTZ1.Source.DailyTime = null;
            this.yongYaoTZ1.Source.DosAge = null;
            this.yongYaoTZ1.Source.drugtype = null;
            this.yongYaoTZ1.Source.EveryTimeMg = null;
            this.yongYaoTZ1.Source.factory = null;
            this.yongYaoTZ1.Source.ID = 0;
            this.yongYaoTZ1.Source.IDCardNo = null;
            this.yongYaoTZ1.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoTZ1.Source.Name = null;
            this.yongYaoTZ1.Source.OUTKey = 0;
            this.yongYaoTZ1.Source.Type = null;
            this.yongYaoTZ1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.tbSmokeCountTarget);
            this.groupBox3.Controls.Add(this.cbVisitType);
            this.groupBox3.Controls.Add(this.cbNextMeasures);
            this.groupBox3.Controls.Add(this.label49);
            this.groupBox3.Controls.Add(this.btnNoDrink);
            this.groupBox3.Controls.Add(this.btnNoSmoke);
            this.groupBox3.Controls.Add(this.cbxSportMinTarget);
            this.groupBox3.Controls.Add(this.cbxSportCountTarget);
            this.groupBox3.Controls.Add(this.cbxSportMin);
            this.groupBox3.Controls.Add(this.cbxSportCount);
            this.groupBox3.Controls.Add(this.tbAidExam);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.tbdorctview);
            this.groupBox3.Controls.Add(this.tbBlfyxx);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.cbxBlfy);
            this.groupBox3.Controls.Add(this.cbxFyycx);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.cbxYanTarget);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.tbDrinkTarget);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.cbxZyxw);
            this.groupBox3.Controls.Add(this.cbxXltz);
            this.groupBox3.Controls.Add(this.cbxYan);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbDrink);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbSomkeCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox3.Location = new System.Drawing.Point(16, 290);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1352, 317);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "生活方式指导及辅助检查";
            // 
            // tbSmokeCountTarget
            // 
            this.tbSmokeCountTarget.Location = new System.Drawing.Point(500, 25);
            this.tbSmokeCountTarget.MaxLength = 2;
            this.tbSmokeCountTarget.Name = "tbSmokeCountTarget";
            this.tbSmokeCountTarget.Size = new System.Drawing.Size(84, 30);
            this.tbSmokeCountTarget.TabIndex = 1;
            // 
            // cbVisitType
            // 
            this.cbVisitType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbVisitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisitType.Font = new System.Drawing.Font("宋体", 15F);
            this.cbVisitType.FormattingEnabled = true;
            this.cbVisitType.Items.AddRange(new object[] {
            "控制满意",
            "控制不满意",
            "不良反应 ",
            "并发症"});
            this.cbVisitType.Location = new System.Drawing.Point(191, 239);
            this.cbVisitType.Name = "cbVisitType";
            this.cbVisitType.Size = new System.Drawing.Size(167, 28);
            this.cbVisitType.TabIndex = 55;
            // 
            // cbNextMeasures
            // 
            this.cbNextMeasures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNextMeasures.Font = new System.Drawing.Font("宋体", 15F);
            this.cbNextMeasures.FormattingEnabled = true;
            this.cbNextMeasures.Items.AddRange(new object[] {
            "常规随访",
            "第1次控制不满意2周随访",
            "两次控制不满意转诊随访",
            "紧急转诊  "});
            this.cbNextMeasures.Location = new System.Drawing.Point(610, 239);
            this.cbNextMeasures.Name = "cbNextMeasures";
            this.cbNextMeasures.Size = new System.Drawing.Size(250, 28);
            this.cbNextMeasures.TabIndex = 54;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(443, 243);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(149, 20);
            this.label49.TabIndex = 53;
            this.label49.Text = "下一步管理措施";
            // 
            // btnNoDrink
            // 
            this.btnNoDrink.Location = new System.Drawing.Point(1272, 26);
            this.btnNoDrink.Name = "btnNoDrink";
            this.btnNoDrink.Size = new System.Drawing.Size(69, 27);
            this.btnNoDrink.TabIndex = 5;
            this.btnNoDrink.Text = "戒酒";
            this.btnNoDrink.UseVisualStyleBackColor = true;
            this.btnNoDrink.Click += new System.EventHandler(this.btnNoDrink_Click);
            // 
            // btnNoSmoke
            // 
            this.btnNoSmoke.Location = new System.Drawing.Point(623, 26);
            this.btnNoSmoke.Name = "btnNoSmoke";
            this.btnNoSmoke.Size = new System.Drawing.Size(62, 27);
            this.btnNoSmoke.TabIndex = 2;
            this.btnNoSmoke.Text = "戒烟";
            this.btnNoSmoke.UseVisualStyleBackColor = true;
            this.btnNoSmoke.Click += new System.EventHandler(this.btnNoSmoke_Click);
            // 
            // cbxSportMinTarget
            // 
            this.cbxSportMinTarget.FormattingEnabled = true;
            this.cbxSportMinTarget.Items.AddRange(new object[] {
            "60",
            "30",
            "20",
            "10"});
            this.cbxSportMinTarget.Location = new System.Drawing.Point(966, 69);
            this.cbxSportMinTarget.Name = "cbxSportMinTarget";
            this.cbxSportMinTarget.Size = new System.Drawing.Size(84, 28);
            this.cbxSportMinTarget.TabIndex = 9;
            // 
            // cbxSportCountTarget
            // 
            this.cbxSportCountTarget.FormattingEnabled = true;
            this.cbxSportCountTarget.Items.AddRange(new object[] {
            "7",
            "5",
            "3",
            "1"});
            this.cbxSportCountTarget.Location = new System.Drawing.Point(816, 70);
            this.cbxSportCountTarget.Name = "cbxSportCountTarget";
            this.cbxSportCountTarget.Size = new System.Drawing.Size(84, 28);
            this.cbxSportCountTarget.TabIndex = 8;
            // 
            // cbxSportMin
            // 
            this.cbxSportMin.FormattingEnabled = true;
            this.cbxSportMin.Items.AddRange(new object[] {
            "60",
            "30",
            "20",
            "10"});
            this.cbxSportMin.Location = new System.Drawing.Point(357, 70);
            this.cbxSportMin.Name = "cbxSportMin";
            this.cbxSportMin.Size = new System.Drawing.Size(98, 28);
            this.cbxSportMin.TabIndex = 7;
            // 
            // cbxSportCount
            // 
            this.cbxSportCount.FormattingEnabled = true;
            this.cbxSportCount.Items.AddRange(new object[] {
            "7",
            "5",
            "3",
            "1"});
            this.cbxSportCount.Location = new System.Drawing.Point(191, 70);
            this.cbxSportCount.Name = "cbxSportCount";
            this.cbxSportCount.Size = new System.Drawing.Size(83, 28);
            this.cbxSportCount.TabIndex = 6;
            // 
            // tbAidExam
            // 
            this.tbAidExam.Location = new System.Drawing.Point(191, 151);
            this.tbAidExam.MaxLength = 100;
            this.tbAidExam.Name = "tbAidExam";
            this.tbAidExam.Size = new System.Drawing.Size(994, 30);
            this.tbAidExam.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(82, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 52;
            this.label12.Text = "辅助检查";
            // 
            // tbdorctview
            // 
            this.tbdorctview.Location = new System.Drawing.Point(191, 274);
            this.tbdorctview.Name = "tbdorctview";
            this.tbdorctview.Size = new System.Drawing.Size(1081, 30);
            this.tbdorctview.TabIndex = 20;
            // 
            // tbBlfyxx
            // 
            this.tbBlfyxx.Location = new System.Drawing.Point(787, 192);
            this.tbBlfyxx.MaxLength = 20;
            this.tbBlfyxx.Name = "tbBlfyxx";
            this.tbBlfyxx.Size = new System.Drawing.Size(508, 30);
            this.tbBlfyxx.TabIndex = 17;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(42, 239);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(129, 20);
            this.label20.TabIndex = 49;
            this.label20.Text = "此次随访分类";
            // 
            // cbxBlfy
            // 
            this.cbxBlfy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBlfy.Font = new System.Drawing.Font("宋体", 15F);
            this.cbxBlfy.FormattingEnabled = true;
            this.cbxBlfy.Items.AddRange(new object[] {
            "无",
            "有"});
            this.cbxBlfy.Location = new System.Drawing.Point(610, 194);
            this.cbxBlfy.Name = "cbxBlfy";
            this.cbxBlfy.Size = new System.Drawing.Size(167, 28);
            this.cbxBlfy.TabIndex = 16;
            // 
            // cbxFyycx
            // 
            this.cbxFyycx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFyycx.Font = new System.Drawing.Font("宋体", 15F);
            this.cbxFyycx.FormattingEnabled = true;
            this.cbxFyycx.Items.AddRange(new object[] {
            "规律",
            "间断",
            "不服药"});
            this.cbxFyycx.Location = new System.Drawing.Point(191, 194);
            this.cbxFyycx.Name = "cbxFyycx";
            this.cbxFyycx.Size = new System.Drawing.Size(163, 28);
            this.cbxFyycx.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(2, 278);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(169, 20);
            this.label19.TabIndex = 46;
            this.label19.Text = "此次随访医生建议";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(454, 197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 20);
            this.label13.TabIndex = 46;
            this.label13.Text = "药物不良反应";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(62, 197);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 20);
            this.label14.TabIndex = 45;
            this.label14.Text = "服药依从性";
            // 
            // cbxYanTarget
            // 
            this.cbxYanTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYanTarget.Font = new System.Drawing.Font("宋体", 15F);
            this.cbxYanTarget.FormattingEnabled = true;
            this.cbxYanTarget.Items.AddRange(new object[] {
            "轻",
            "中",
            "重"});
            this.cbxYanTarget.Location = new System.Drawing.Point(521, 110);
            this.cbxYanTarget.Name = "cbxYanTarget";
            this.cbxYanTarget.Size = new System.Drawing.Size(154, 28);
            this.cbxYanTarget.TabIndex = 11;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(386, 116);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(129, 20);
            this.label35.TabIndex = 42;
            this.label35.Text = "下次随访目标";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(1058, 74);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(79, 20);
            this.label29.TabIndex = 41;
            this.label29.Text = "分钟/次";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(901, 73);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(59, 20);
            this.label30.TabIndex = 39;
            this.label30.Text = "次/周";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(676, 74);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(129, 20);
            this.label31.TabIndex = 37;
            this.label31.Text = "下次随访目标";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(1240, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 20);
            this.label27.TabIndex = 36;
            this.label27.Text = "两";
            // 
            // tbDrinkTarget
            // 
            this.tbDrinkTarget.Location = new System.Drawing.Point(1154, 27);
            this.tbDrinkTarget.MaxLength = 4;
            this.tbDrinkTarget.Name = "tbDrinkTarget";
            this.tbDrinkTarget.Size = new System.Drawing.Size(84, 30);
            this.tbDrinkTarget.TabIndex = 4;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(1008, 32);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(129, 20);
            this.label28.TabIndex = 34;
            this.label28.Text = "下次随访目标";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(593, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 20);
            this.label25.TabIndex = 33;
            this.label25.Text = "支";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(353, 31);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(129, 20);
            this.label26.TabIndex = 31;
            this.label26.Text = "下次随访目标";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(901, 31);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 20);
            this.label24.TabIndex = 30;
            this.label24.Text = "两";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(281, 31);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 20);
            this.label23.TabIndex = 29;
            this.label23.Text = "支";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(466, 74);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 20);
            this.label22.TabIndex = 28;
            this.label22.Text = "分钟/次";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(281, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 20);
            this.label21.TabIndex = 26;
            this.label21.Text = "次/周";
            // 
            // cbxZyxw
            // 
            this.cbxZyxw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxZyxw.Font = new System.Drawing.Font("宋体", 15F);
            this.cbxZyxw.FormattingEnabled = true;
            this.cbxZyxw.Items.AddRange(new object[] {
            "良好",
            "一般",
            "差"});
            this.cbxZyxw.Location = new System.Drawing.Point(1113, 112);
            this.cbxZyxw.Name = "cbxZyxw";
            this.cbxZyxw.Size = new System.Drawing.Size(217, 28);
            this.cbxZyxw.TabIndex = 13;
            // 
            // cbxXltz
            // 
            this.cbxXltz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxXltz.Font = new System.Drawing.Font("宋体", 15F);
            this.cbxXltz.FormattingEnabled = true;
            this.cbxXltz.Items.AddRange(new object[] {
            "良好",
            "一般",
            "差"});
            this.cbxXltz.Location = new System.Drawing.Point(815, 112);
            this.cbxXltz.Name = "cbxXltz";
            this.cbxXltz.Size = new System.Drawing.Size(178, 28);
            this.cbxXltz.TabIndex = 12;
            // 
            // cbxYan
            // 
            this.cbxYan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYan.Font = new System.Drawing.Font("宋体", 15F);
            this.cbxYan.FormattingEnabled = true;
            this.cbxYan.Items.AddRange(new object[] {
            "轻",
            "中",
            "重"});
            this.cbxYan.Location = new System.Drawing.Point(191, 112);
            this.cbxYan.Name = "cbxYan";
            this.cbxYan.Size = new System.Drawing.Size(163, 28);
            this.cbxYan.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1018, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "遵医行为";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(716, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "心理调整";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "摄盐情况";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "运动";
            // 
            // tbDrink
            // 
            this.tbDrink.Location = new System.Drawing.Point(815, 26);
            this.tbDrink.MaxLength = 4;
            this.tbDrink.Name = "tbDrink";
            this.tbDrink.Size = new System.Drawing.Size(84, 30);
            this.tbDrink.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(716, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "日饮酒量";
            // 
            // tbSomkeCount
            // 
            this.tbSomkeCount.Location = new System.Drawing.Point(191, 27);
            this.tbSomkeCount.MaxLength = 2;
            this.tbSomkeCount.Name = "tbSomkeCount";
            this.tbSomkeCount.Size = new System.Drawing.Size(84, 30);
            this.tbSomkeCount.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(82, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "日吸烟量";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.lkYs);
            this.groupBox6.Controls.Add(this.picSignYs);
            this.groupBox6.Controls.Add(this.label42);
            this.groupBox6.Controls.Add(this.panel7);
            this.groupBox6.Controls.Add(this.lkJm);
            this.groupBox6.Controls.Add(this.picSignJm);
            this.groupBox6.Controls.Add(this.label54);
            this.groupBox6.Controls.Add(this.tbRemark);
            this.groupBox6.Controls.Add(this.label52);
            this.groupBox6.Controls.Add(this.label51);
            this.groupBox6.Controls.Add(this.txtReferralContacts);
            this.groupBox6.Controls.Add(this.label50);
            this.groupBox6.Controls.Add(this.tbJgkb);
            this.groupBox6.Controls.Add(this.label47);
            this.groupBox6.Controls.Add(this.tbZzyy);
            this.groupBox6.Controls.Add(this.label48);
            this.groupBox6.Controls.Add(this.panel5);
            this.groupBox6.Controls.Add(this.dtpNext);
            this.groupBox6.Controls.Add(this.linkLabel1);
            this.groupBox6.Controls.Add(this.label41);
            this.groupBox6.Controls.Add(this.label361);
            this.groupBox6.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox6.Location = new System.Drawing.Point(11, 863);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1357, 220);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            // 
            // lkYs
            // 
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(431, 188);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 164;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(148, 154);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(228, 60);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 162;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 15F);
            this.label42.Location = new System.Drawing.Point(35, 179);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(99, 20);
            this.label42.TabIndex = 161;
            this.label42.Text = "医生签名:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.rddw);
            this.panel7.Controls.Add(this.rdwdw);
            this.panel7.Enabled = false;
            this.panel7.Location = new System.Drawing.Point(473, 66);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 29);
            this.panel7.TabIndex = 160;
            // 
            // rddw
            // 
            this.rddw.AutoSize = true;
            this.rddw.Location = new System.Drawing.Point(8, 3);
            this.rddw.Name = "rddw";
            this.rddw.Size = new System.Drawing.Size(67, 24);
            this.rddw.TabIndex = 152;
            this.rddw.TabStop = true;
            this.rddw.Text = "到位";
            this.rddw.UseVisualStyleBackColor = true;
            // 
            // rdwdw
            // 
            this.rdwdw.AutoSize = true;
            this.rdwdw.Location = new System.Drawing.Point(89, 3);
            this.rdwdw.Name = "rdwdw";
            this.rdwdw.Size = new System.Drawing.Size(87, 24);
            this.rdwdw.TabIndex = 153;
            this.rdwdw.TabStop = true;
            this.rdwdw.Text = "不到位";
            this.rdwdw.UseVisualStyleBackColor = true;
            // 
            // lkJm
            // 
            this.lkJm.AutoSize = true;
            this.lkJm.Location = new System.Drawing.Point(1022, 186);
            this.lkJm.Name = "lkJm";
            this.lkJm.Size = new System.Drawing.Size(89, 20);
            this.lkJm.TabIndex = 159;
            this.lkJm.TabStop = true;
            this.lkJm.Text = "重置签名";
            this.lkJm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // picSignJm
            // 
            this.picSignJm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJm.Location = new System.Drawing.Point(741, 152);
            this.picSignJm.Name = "picSignJm";
            this.picSignJm.Size = new System.Drawing.Size(228, 60);
            this.picSignJm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJm.TabIndex = 157;
            this.picSignJm.TabStop = false;
            this.picSignJm.Click += new System.EventHandler(this.picSignJm_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("宋体", 15F);
            this.label54.Location = new System.Drawing.Point(631, 181);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(99, 20);
            this.label54.TabIndex = 156;
            this.label54.Text = "居民签名:";
            // 
            // tbRemark
            // 
            this.tbRemark.Location = new System.Drawing.Point(148, 106);
            this.tbRemark.MaxLength = 100;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(515, 30);
            this.tbRemark.TabIndex = 155;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("宋体", 15F);
            this.label52.Location = new System.Drawing.Point(75, 113);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(59, 20);
            this.label52.TabIndex = 154;
            this.label52.Text = "备注:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(398, 71);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(59, 20);
            this.label51.TabIndex = 53;
            this.label51.Text = "结 果";
            // 
            // txtReferralContacts
            // 
            this.txtReferralContacts.Location = new System.Drawing.Point(148, 65);
            this.txtReferralContacts.MaxLength = 20;
            this.txtReferralContacts.Name = "txtReferralContacts";
            this.txtReferralContacts.ReadOnly = true;
            this.txtReferralContacts.Size = new System.Drawing.Size(197, 30);
            this.txtReferralContacts.TabIndex = 52;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(8, 69);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(129, 20);
            this.label50.TabIndex = 51;
            this.label50.Text = "联系人及电话";
            // 
            // tbJgkb
            // 
            this.tbJgkb.Location = new System.Drawing.Point(871, 17);
            this.tbJgkb.MaxLength = 20;
            this.tbJgkb.Name = "tbJgkb";
            this.tbJgkb.ReadOnly = true;
            this.tbJgkb.Size = new System.Drawing.Size(164, 30);
            this.tbJgkb.TabIndex = 2;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(756, 23);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(109, 20);
            this.label47.TabIndex = 50;
            this.label47.Text = "机构及科别";
            // 
            // tbZzyy
            // 
            this.tbZzyy.Location = new System.Drawing.Point(473, 18);
            this.tbZzyy.MaxLength = 20;
            this.tbZzyy.Name = "tbZzyy";
            this.tbZzyy.ReadOnly = true;
            this.tbZzyy.Size = new System.Drawing.Size(188, 30);
            this.tbZzyy.TabIndex = 1;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(368, 21);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(89, 20);
            this.label48.TabIndex = 48;
            this.label48.Text = "转诊原因";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rdzzno);
            this.panel5.Controls.Add(this.rdzzyes);
            this.panel5.Location = new System.Drawing.Point(146, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(154, 31);
            this.panel5.TabIndex = 0;
            // 
            // rdzzno
            // 
            this.rdzzno.AutoSize = true;
            this.rdzzno.Location = new System.Drawing.Point(89, 3);
            this.rdzzno.Name = "rdzzno";
            this.rdzzno.Size = new System.Drawing.Size(47, 24);
            this.rdzzno.TabIndex = 1;
            this.rdzzno.TabStop = true;
            this.rdzzno.Text = "否";
            this.rdzzno.UseVisualStyleBackColor = true;
            // 
            // rdzzyes
            // 
            this.rdzzyes.AutoSize = true;
            this.rdzzyes.Location = new System.Drawing.Point(5, 3);
            this.rdzzyes.Name = "rdzzyes";
            this.rdzzyes.Size = new System.Drawing.Size(47, 24);
            this.rdzzyes.TabIndex = 0;
            this.rdzzyes.TabStop = true;
            this.rdzzyes.Text = "是";
            this.rdzzyes.UseVisualStyleBackColor = true;
            this.rdzzyes.CheckedChanged += new System.EventHandler(this.rdzzyes_CheckedChanged);
            // 
            // dtpNext
            // 
            this.dtpNext.Font = new System.Drawing.Font("宋体", 15F);
            this.dtpNext.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNext.Location = new System.Drawing.Point(873, 105);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(162, 30);
            this.dtpNext.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.Location = new System.Drawing.Point(1080, 31);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(114, 20);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "编辑常用药";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(48, 22);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(89, 20);
            this.label41.TabIndex = 0;
            this.label41.Text = "转诊情况";
            // 
            // label361
            // 
            this.label361.AutoSize = true;
            this.label361.Font = new System.Drawing.Font("宋体", 15F);
            this.label361.Location = new System.Drawing.Point(726, 113);
            this.label361.Name = "label361";
            this.label361.Size = new System.Drawing.Size(139, 20);
            this.label361.TabIndex = 43;
            this.label361.Text = "下次随访日期:";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.yongYaoQK4);
            this.groupBox5.Controls.Add(this.yongYaoQK3);
            this.groupBox5.Controls.Add(this.yongYaoQK2);
            this.groupBox5.Controls.Add(this.yongYaoQK1);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox5.Location = new System.Drawing.Point(16, 621);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1357, 119);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "目前用药情况";
            // 
            // yongYaoQK4
            // 
            this.yongYaoQK4.ErrorInput = false;
            this.yongYaoQK4.Font = new System.Drawing.Font("宋体", 15F);
            this.yongYaoQK4.Location = new System.Drawing.Point(684, 76);
            this.yongYaoQK4.Margin = new System.Windows.Forms.Padding(7);
            this.yongYaoQK4.MText = "其他药物";
            this.yongYaoQK4.Name = "yongYaoQK4";
            this.yongYaoQK4.Size = new System.Drawing.Size(665, 36);
            this.yongYaoQK4.Source.DailyTime = null;
            this.yongYaoQK4.Source.DosAge = null;
            this.yongYaoQK4.Source.drugtype = null;
            this.yongYaoQK4.Source.EveryTimeMg = null;
            this.yongYaoQK4.Source.factory = null;
            this.yongYaoQK4.Source.ID = 0;
            this.yongYaoQK4.Source.IDCardNo = null;
            this.yongYaoQK4.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoQK4.Source.Name = null;
            this.yongYaoQK4.Source.OUTKey = 0;
            this.yongYaoQK4.Source.Type = null;
            this.yongYaoQK4.TabIndex = 3;
            // 
            // yongYaoQK3
            // 
            this.yongYaoQK3.ErrorInput = false;
            this.yongYaoQK3.Font = new System.Drawing.Font("宋体", 15F);
            this.yongYaoQK3.Location = new System.Drawing.Point(3, 74);
            this.yongYaoQK3.Margin = new System.Windows.Forms.Padding(7);
            this.yongYaoQK3.MText = "药物名称3";
            this.yongYaoQK3.Name = "yongYaoQK3";
            this.yongYaoQK3.Size = new System.Drawing.Size(667, 38);
            this.yongYaoQK3.Source.DailyTime = null;
            this.yongYaoQK3.Source.DosAge = null;
            this.yongYaoQK3.Source.drugtype = null;
            this.yongYaoQK3.Source.EveryTimeMg = null;
            this.yongYaoQK3.Source.factory = null;
            this.yongYaoQK3.Source.ID = 0;
            this.yongYaoQK3.Source.IDCardNo = null;
            this.yongYaoQK3.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoQK3.Source.Name = null;
            this.yongYaoQK3.Source.OUTKey = 0;
            this.yongYaoQK3.Source.Type = null;
            this.yongYaoQK3.TabIndex = 2;
            // 
            // yongYaoQK2
            // 
            this.yongYaoQK2.ErrorInput = false;
            this.yongYaoQK2.Font = new System.Drawing.Font("宋体", 15F);
            this.yongYaoQK2.Location = new System.Drawing.Point(684, 26);
            this.yongYaoQK2.Margin = new System.Windows.Forms.Padding(7);
            this.yongYaoQK2.MText = "药物名称2";
            this.yongYaoQK2.Name = "yongYaoQK2";
            this.yongYaoQK2.Size = new System.Drawing.Size(658, 49);
            this.yongYaoQK2.Source.DailyTime = null;
            this.yongYaoQK2.Source.DosAge = null;
            this.yongYaoQK2.Source.drugtype = null;
            this.yongYaoQK2.Source.EveryTimeMg = null;
            this.yongYaoQK2.Source.factory = null;
            this.yongYaoQK2.Source.ID = 0;
            this.yongYaoQK2.Source.IDCardNo = null;
            this.yongYaoQK2.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoQK2.Source.Name = null;
            this.yongYaoQK2.Source.OUTKey = 0;
            this.yongYaoQK2.Source.Type = null;
            this.yongYaoQK2.TabIndex = 1;
            // 
            // yongYaoQK1
            // 
            this.yongYaoQK1.ErrorInput = false;
            this.yongYaoQK1.Font = new System.Drawing.Font("宋体", 15F);
            this.yongYaoQK1.Location = new System.Drawing.Point(3, 26);
            this.yongYaoQK1.Margin = new System.Windows.Forms.Padding(7);
            this.yongYaoQK1.MText = "药物名称1";
            this.yongYaoQK1.Name = "yongYaoQK1";
            this.yongYaoQK1.Size = new System.Drawing.Size(672, 43);
            this.yongYaoQK1.Source.DailyTime = null;
            this.yongYaoQK1.Source.DosAge = null;
            this.yongYaoQK1.Source.drugtype = null;
            this.yongYaoQK1.Source.EveryTimeMg = null;
            this.yongYaoQK1.Source.factory = null;
            this.yongYaoQK1.Source.ID = 0;
            this.yongYaoQK1.Source.IDCardNo = null;
            this.yongYaoQK1.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoQK1.Source.Name = null;
            this.yongYaoQK1.Source.OUTKey = 0;
            this.yongYaoQK1.Source.Type = null;
            this.yongYaoQK1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.tbTzzsTarget);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.label53);
            this.groupBox2.Controls.Add(this.btnNextBMI);
            this.groupBox2.Controls.Add(this.btnBMI);
            this.groupBox2.Controls.Add(this.btnWeightNext);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.btnWeight);
            this.groupBox2.Controls.Add(this.tbWeight);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.tbWeightTarget);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.btnXueya);
            this.groupBox2.Controls.Add(this.tbXinlv);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.tbHight);
            this.groupBox2.Controls.Add(this.tbTzzs);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbOther);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbXueya);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox2.Location = new System.Drawing.Point(18, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1352, 110);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "体征";
            // 
            // tbTzzsTarget
            // 
            this.tbTzzsTarget.Location = new System.Drawing.Point(1106, 29);
            this.tbTzzsTarget.MaxLength = 6;
            this.tbTzzsTarget.Name = "tbTzzsTarget";
            this.tbTzzsTarget.Size = new System.Drawing.Size(69, 30);
            this.tbTzzsTarget.TabIndex = 4;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 15F);
            this.label36.Location = new System.Drawing.Point(1182, 33);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(59, 20);
            this.label36.TabIndex = 39;
            this.label36.Text = "Kg/㎡";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("宋体", 15F);
            this.label58.Location = new System.Drawing.Point(808, 35);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(59, 20);
            this.label58.TabIndex = 39;
            this.label58.Text = "Kg/㎡";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(812, 71);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(29, 20);
            this.label53.TabIndex = 38;
            this.label53.Text = "cm";
            // 
            // btnNextBMI
            // 
            this.btnNextBMI.Location = new System.Drawing.Point(1248, 29);
            this.btnNextBMI.Name = "btnNextBMI";
            this.btnNextBMI.Size = new System.Drawing.Size(68, 27);
            this.btnNextBMI.TabIndex = 5;
            this.btnNextBMI.Text = "计算";
            this.btnNextBMI.UseVisualStyleBackColor = true;
            this.btnNextBMI.Click += new System.EventHandler(this.btnNextBMI_Click);
            // 
            // btnBMI
            // 
            this.btnBMI.Location = new System.Drawing.Point(871, 32);
            this.btnBMI.Name = "btnBMI";
            this.btnBMI.Size = new System.Drawing.Size(69, 27);
            this.btnBMI.TabIndex = 5;
            this.btnBMI.Text = "计算";
            this.btnBMI.UseVisualStyleBackColor = true;
            this.btnBMI.Click += new System.EventHandler(this.btnBMI_Click);
            // 
            // btnWeightNext
            // 
            this.btnWeightNext.Location = new System.Drawing.Point(551, 71);
            this.btnWeightNext.Name = "btnWeightNext";
            this.btnWeightNext.Size = new System.Drawing.Size(58, 27);
            this.btnWeightNext.TabIndex = 9;
            this.btnWeightNext.Text = "计算";
            this.btnWeightNext.UseVisualStyleBackColor = true;
            this.btnWeightNext.Click += new System.EventHandler(this.btnWeightNext_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F);
            this.label17.Location = new System.Drawing.Point(521, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 20);
            this.label17.TabIndex = 37;
            this.label17.Text = "Kg";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 15F);
            this.label45.Location = new System.Drawing.Point(180, 76);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(29, 20);
            this.label45.TabIndex = 36;
            this.label45.Text = "Kg";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F);
            this.label16.Location = new System.Drawing.Point(495, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 35;
            this.label16.Text = "次/分钟";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 15F);
            this.label44.Location = new System.Drawing.Point(174, 33);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(49, 20);
            this.label44.TabIndex = 34;
            this.label44.Text = "mmHg";
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(228, 70);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(37, 27);
            this.btnWeight.TabIndex = 7;
            this.btnWeight.Text = "..";
            this.btnWeight.UseVisualStyleBackColor = true;
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // tbWeight
            // 
            this.tbWeight.Location = new System.Drawing.Point(86, 70);
            this.tbWeight.MaxLength = 6;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(86, 30);
            this.tbWeight.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "体重";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(963, 35);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(129, 20);
            this.label34.TabIndex = 18;
            this.label34.Text = "下次随访目标";
            // 
            // tbWeightTarget
            // 
            this.tbWeightTarget.Location = new System.Drawing.Point(444, 69);
            this.tbWeightTarget.MaxLength = 6;
            this.tbWeightTarget.Name = "tbWeightTarget";
            this.tbWeightTarget.Size = new System.Drawing.Size(70, 30);
            this.tbWeightTarget.TabIndex = 8;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(302, 75);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(129, 20);
            this.label33.TabIndex = 15;
            this.label33.Text = "下次随访目标";
            // 
            // btnXueya
            // 
            this.btnXueya.Location = new System.Drawing.Point(230, 27);
            this.btnXueya.Name = "btnXueya";
            this.btnXueya.Size = new System.Drawing.Size(37, 27);
            this.btnXueya.TabIndex = 1;
            this.btnXueya.Text = "..";
            this.btnXueya.UseVisualStyleBackColor = true;
            this.btnXueya.Click += new System.EventHandler(this.btnXueya_Click);
            // 
            // tbXinlv
            // 
            this.tbXinlv.Location = new System.Drawing.Point(380, 28);
            this.tbXinlv.MaxLength = 3;
            this.tbXinlv.Name = "tbXinlv";
            this.tbXinlv.Size = new System.Drawing.Size(108, 30);
            this.tbXinlv.TabIndex = 2;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(302, 32);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(49, 20);
            this.label32.TabIndex = 10;
            this.label32.Text = "心率";
            // 
            // tbHight
            // 
            this.tbHight.Location = new System.Drawing.Point(716, 68);
            this.tbHight.MaxLength = 6;
            this.tbHight.Name = "tbHight";
            this.tbHight.Size = new System.Drawing.Size(86, 30);
            this.tbHight.TabIndex = 10;
            // 
            // tbTzzs
            // 
            this.tbTzzs.Location = new System.Drawing.Point(716, 30);
            this.tbTzzs.MaxLength = 6;
            this.tbTzzs.Name = "tbTzzs";
            this.tbTzzs.Size = new System.Drawing.Size(86, 30);
            this.tbTzzs.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(661, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 20);
            this.label18.TabIndex = 8;
            this.label18.Text = "身高";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(621, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "体质指数";
            // 
            // tbOther
            // 
            this.tbOther.Location = new System.Drawing.Point(1106, 68);
            this.tbOther.MaxLength = 20;
            this.tbOther.Name = "tbOther";
            this.tbOther.Size = new System.Drawing.Size(220, 30);
            this.tbOther.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(963, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "其他";
            // 
            // tbXueya
            // 
            this.tbXueya.Location = new System.Drawing.Point(88, 28);
            this.tbXueya.Name = "tbXueya";
            this.tbXueya.Size = new System.Drawing.Size(86, 30);
            this.tbXueya.TabIndex = 0;
            this.tbXueya.TextChanged += new System.EventHandler(this.tbXueya_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "血压";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Controls.Add(this.tbZzOther);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox4.Location = new System.Drawing.Point(18, 59);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1352, 97);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "症状";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckGroup10);
            this.panel2.Controls.Add(this.ckGroup9);
            this.panel2.Controls.Add(this.ckGroup8);
            this.panel2.Controls.Add(this.ckGroup7);
            this.panel2.Controls.Add(this.ckGroup6);
            this.panel2.Controls.Add(this.ckGroup5);
            this.panel2.Controls.Add(this.ckGroup4);
            this.panel2.Controls.Add(this.ckGroup3);
            this.panel2.Controls.Add(this.ckGroup2);
            this.panel2.Controls.Add(this.ckGroup1);
            this.panel2.Location = new System.Drawing.Point(7, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 76);
            this.panel2.TabIndex = 0;
            // 
            // ckGroup10
            // 
            this.ckGroup10.AutoSize = true;
            this.ckGroup10.Location = new System.Drawing.Point(577, 38);
            this.ckGroup10.Name = "ckGroup10";
            this.ckGroup10.Size = new System.Drawing.Size(108, 24);
            this.ckGroup10.TabIndex = 9;
            this.ckGroup10.Text = "其他症状";
            this.ckGroup10.UseVisualStyleBackColor = true;
            this.ckGroup10.CheckedChanged += new System.EventHandler(this.ckGroup10_CheckedChanged);
            // 
            // ckGroup9
            // 
            this.ckGroup9.AutoSize = true;
            this.ckGroup9.Location = new System.Drawing.Point(439, 38);
            this.ckGroup9.Name = "ckGroup9";
            this.ckGroup9.Size = new System.Drawing.Size(108, 24);
            this.ckGroup9.TabIndex = 8;
            this.ckGroup9.Text = "下肢水肿";
            this.ckGroup9.UseVisualStyleBackColor = true;
            // 
            // ckGroup8
            // 
            this.ckGroup8.AutoSize = true;
            this.ckGroup8.Location = new System.Drawing.Point(308, 38);
            this.ckGroup8.Name = "ckGroup8";
            this.ckGroup8.Size = new System.Drawing.Size(108, 24);
            this.ckGroup8.TabIndex = 7;
            this.ckGroup8.Text = "四肢发麻";
            this.ckGroup8.UseVisualStyleBackColor = true;
            // 
            // ckGroup7
            // 
            this.ckGroup7.AutoSize = true;
            this.ckGroup7.Location = new System.Drawing.Point(143, 38);
            this.ckGroup7.Name = "ckGroup7";
            this.ckGroup7.Size = new System.Drawing.Size(148, 24);
            this.ckGroup7.TabIndex = 6;
            this.ckGroup7.Text = "鼻衄出血不止";
            this.ckGroup7.UseVisualStyleBackColor = true;
            // 
            // ckGroup6
            // 
            this.ckGroup6.AutoSize = true;
            this.ckGroup6.Location = new System.Drawing.Point(12, 38);
            this.ckGroup6.Name = "ckGroup6";
            this.ckGroup6.Size = new System.Drawing.Size(108, 24);
            this.ckGroup6.TabIndex = 5;
            this.ckGroup6.Text = "心悸胸闷";
            this.ckGroup6.UseVisualStyleBackColor = true;
            // 
            // ckGroup5
            // 
            this.ckGroup5.AutoSize = true;
            this.ckGroup5.Location = new System.Drawing.Point(577, 10);
            this.ckGroup5.Name = "ckGroup5";
            this.ckGroup5.Size = new System.Drawing.Size(108, 24);
            this.ckGroup5.TabIndex = 4;
            this.ckGroup5.Text = "呼吸困难";
            this.ckGroup5.UseVisualStyleBackColor = true;
            // 
            // ckGroup4
            // 
            this.ckGroup4.AutoSize = true;
            this.ckGroup4.Location = new System.Drawing.Point(439, 10);
            this.ckGroup4.Name = "ckGroup4";
            this.ckGroup4.Size = new System.Drawing.Size(108, 24);
            this.ckGroup4.TabIndex = 3;
            this.ckGroup4.Text = "眼花耳鸣";
            this.ckGroup4.UseVisualStyleBackColor = true;
            // 
            // ckGroup3
            // 
            this.ckGroup3.AutoSize = true;
            this.ckGroup3.Location = new System.Drawing.Point(308, 10);
            this.ckGroup3.Name = "ckGroup3";
            this.ckGroup3.Size = new System.Drawing.Size(108, 24);
            this.ckGroup3.TabIndex = 2;
            this.ckGroup3.Text = "恶心呕吐";
            this.ckGroup3.UseVisualStyleBackColor = true;
            // 
            // ckGroup2
            // 
            this.ckGroup2.AutoSize = true;
            this.ckGroup2.Location = new System.Drawing.Point(143, 10);
            this.ckGroup2.Name = "ckGroup2";
            this.ckGroup2.Size = new System.Drawing.Size(108, 24);
            this.ckGroup2.TabIndex = 1;
            this.ckGroup2.Text = "头痛头晕";
            this.ckGroup2.UseVisualStyleBackColor = true;
            // 
            // ckGroup1
            // 
            this.ckGroup1.AutoSize = true;
            this.ckGroup1.Location = new System.Drawing.Point(12, 10);
            this.ckGroup1.Name = "ckGroup1";
            this.ckGroup1.Size = new System.Drawing.Size(88, 24);
            this.ckGroup1.TabIndex = 0;
            this.ckGroup1.Text = "无症状";
            this.ckGroup1.UseVisualStyleBackColor = true;
            // 
            // tbZzOther
            // 
            this.tbZzOther.Location = new System.Drawing.Point(718, 21);
            this.tbZzOther.MaxLength = 100;
            this.tbZzOther.Multiline = true;
            this.tbZzOther.Name = "tbZzOther";
            this.tbZzOther.ReadOnly = true;
            this.tbZzOther.Size = new System.Drawing.Size(612, 62);
            this.tbZzOther.TabIndex = 1;
            // 
            // HypVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "HypVisitForm";
            this.Text = "HypVisitForm";
            this.Load += new System.EventHandler(this.FrmHypFollow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJm)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void bd_Parse(object sender, ConvertEventArgs e)
        {
            decimal num;
            if (!decimal.TryParse(e.Value.ToString(), out num))
            {
                e.Value = null;
            }
        }

        private void bd_ParseStr(object sender, ConvertEventArgs e)
        {
            string s = e.Value as string;
            Binding bd = sender as Binding;
            InputRangeStr str2 = this.inputrange_str.Find(c => c.Name == bd.BindingMemberInfo.BindingField);
            if (str2 != null)
            {
                if (Encoding.GetEncoding("GB2312").GetByteCount(s) > str2.BytesCount)
                {
                    str2.ErrorInput = true;
                    bd.Control.BackColor = Color.Salmon;
                }
                else
                {
                    str2.ErrorInput = false;
                    bd.Control.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void btnWeight_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "22")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tbWeight.Text = select.m_Result.value1;
            }
        }

        private void btnXueya_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "20")
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (select.ShowDialog() == DialogResult.OK)
            {
                this.HypertensionFollowRcd.Hypertension = new decimal?(int.Parse(select.m_Result.value1));
                this.HypertensionFollowRcd.Hypotension = new decimal?(int.Parse(select.m_Result.value2));

                this.tbXueya.Text = select.m_Result.value1 + "/" + select.m_Result.value2;
                this.tbXinlv.Text = select.m_Result.value3;

                if (this.HypertensionFollowRcd.Hypertension >= 180 || this.HypertensionFollowRcd.Hypotension >= 110)
                {
                    this.cbNextMeasures.SelectedIndex = 3;
                    this.HypertensionFollowRcd.NextMeasures = "4";
                    this.cbVisitType.SelectedIndex = 1;
                    this.HypertensionFollowRcd.FollowUpType = "2";
                }
                else if (this.HypertensionFollowRcd.Hypertension >= 140 || this.HypertensionFollowRcd.Hypotension >= 90)
                {
                    this.cbNextMeasures.SelectedIndex = 2;
                    this.HypertensionFollowRcd.NextMeasures = "3";
                    this.cbVisitType.SelectedIndex = 1;
                    this.HypertensionFollowRcd.FollowUpType = "2";
                }
                else
                {
                    this.cbNextMeasures.SelectedIndex = 0;
                    this.HypertensionFollowRcd.NextMeasures = "1";
                    this.cbVisitType.SelectedIndex = 0;
                    this.HypertensionFollowRcd.FollowUpType = "1";
                }
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            bool flag = false;
            if (this.dtpNext.Value.Date < this.dtpVisit.Value.Date)
            {
                flag = true;
                this.SaveDataInfo = "下次随访日期不能小于当前随访日期！";
            }
            if (this.dtpVisit.Value.Date > DateTime.Today)
            {
                HypVisitForm follow = this;
                string str = follow.SaveDataInfo + "随访日期不能晚于当前日期!\r\n";
                follow.SaveDataInfo = str;
                flag = true;
            }
            if ((this.inputrange_str.Count<InputRangeStr>(c => c.ErrorInput) <= 0) && !flag)
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

        private void FrmHypFollow_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.SignPath))
            {
                Directory.CreateDirectory(this.SignPath);
            }
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void GetModel()
        {
            if (this.IDPerson > 0)
            {
                this.HypertensionFollowRcd = hypertensionVisitBll.GetModelID(this.IDPerson);//通过IDPerson获取一笔数据

                if (this.HypertensionFollowRcd.FollowUpDate.HasValue)
                {
                    this.dtpVisit.Value = this.HypertensionFollowRcd.FollowUpDate.Value;
                    this.visitdate = this.HypertensionFollowRcd.FollowUpDate.ToString();
                }
            }
            else
            {
                // 取默认项设置
                PresetValue();

                this.dtpVisit.Value = DateTime.Today.Date;
            }

            if (this.HypertensionFollowRcd == null)
            {
                ChronicHypertensionVisitModel cd_Hypertensionfollowup = new ChronicHypertensionVisitModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    FollowUpType = "1"
                };

                this.HypertensionFollowRcd = cd_Hypertensionfollowup;
                this.HypertensionFollowRcd.CreatedBy = ConfigHelper.GetNodeDec("doctor").ToString();
                this.HypertensionFollowRcd.CreatedDate = new DateTime?(DateTime.Today);
                this.DrugConditions = new List<ChronicDrugConditionModel>();
                this.DrugConditionsTZ = new List<ChronicDrugConditionModel>();
            }
            else
            {
                this.HypertensionFollowRcd.LastUpdateBy = ConfigHelper.GetNodeDec("doctor").ToString();
                this.HypertensionFollowRcd.LastUpdateDate = new DateTime?(DateTime.Today);

                if (this.IDPerson > 0)
                {
                    this.DrugConditions = drugConditionBll.GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '" + this.IDPerson + "' ", this.HypertensionFollowRcd.IDCardNo, "1"));

                    // 高血压用药调整情况，默认为7
                    this.DrugConditionsTZ = drugConditionBll.GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '" + this.IDPerson + "' ", this.HypertensionFollowRcd.IDCardNo, "7"));
                }
                else
                {
                    this.DrugConditions = drugConditionBll.GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '" + this.HypertensionFollowRcd.ID + "' ", this.HypertensionFollowRcd.IDCardNo, "1"));
                    this.DrugConditionsTZ = drugConditionBll.GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '" + this.HypertensionFollowRcd.ID + "' ", this.HypertensionFollowRcd.IDCardNo, "7"));
                }
            }

            if (string.IsNullOrEmpty(this.HypertensionFollowRcd.FollowUpDoctor))
            {
                this.HypertensionFollowRcd.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
            }
        }

        public void InitEveryThing()
        {
            int num;
            this.GetModel();

            if (this.HypertensionFollowRcd.Hypertension.HasValue || this.HypertensionFollowRcd.Hypotension.HasValue)
            {
                if (this.HypertensionFollowRcd.Hypertension.HasValue && this.HypertensionFollowRcd.Hypotension.HasValue)
                {
                    this.tbXueya.Text = this.HypertensionFollowRcd.Hypertension.Value.ToString() + "/" + this.HypertensionFollowRcd.Hypotension.Value.ToString();
                }
                else if (this.HypertensionFollowRcd.Hypertension.HasValue)
                {
                    this.tbXueya.Text = this.HypertensionFollowRcd.Hypertension.Value.ToString();
                }
                else if (this.HypertensionFollowRcd.Hypotension.HasValue)
                {
                    this.tbXueya.Text = "/" + this.HypertensionFollowRcd.Hypotension.Value.ToString();
                }
            }
            else
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20");

                if (devData.HasValue)
                {
                    this.HypertensionFollowRcd.Hypertension = new decimal?(int.Parse(devData.value1));
                    this.HypertensionFollowRcd.Hypotension = new decimal?(int.Parse(devData.value2));

                    if (!string.IsNullOrEmpty(devData.value3))
                    {
                        this.HypertensionFollowRcd.HeartRate = new decimal?(int.Parse(devData.value3));
                    }

                    this.tbXueya.Text = devData.value1 + "/" + devData.value2;

                    if (this.HypertensionFollowRcd.Hypertension >= 180 || this.HypertensionFollowRcd.Hypotension >= 110)
                    {
                        this.cbNextMeasures.SelectedIndex = 3;
                        this.HypertensionFollowRcd.NextMeasures = "4";
                        this.cbVisitType.SelectedIndex = 1;
                        this.HypertensionFollowRcd.FollowUpType = "2";
                    }
                    else if (this.HypertensionFollowRcd.Hypertension >= 140 || this.HypertensionFollowRcd.Hypotension >= 90)
                    {
                        this.cbNextMeasures.SelectedIndex = 2;
                        this.HypertensionFollowRcd.NextMeasures = "3";
                        this.cbVisitType.SelectedIndex = 1;
                        this.HypertensionFollowRcd.FollowUpType = "2";
                    }
                    else
                    {
                        this.cbNextMeasures.SelectedIndex = 0;
                        this.HypertensionFollowRcd.NextMeasures = "1";
                        this.cbVisitType.SelectedIndex = 0;
                        this.HypertensionFollowRcd.FollowUpType = "1";
                    }
                }
            }

            this.SimpleBinding(this.tbXinlv, "HeartRate", true, DataSourceUpdateMode.OnPropertyChanged);

            if (this.tbXinlv.Text == "")
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20");
                if (devData.HasValue)
                {
                    this.tbXinlv.Text = devData.value3;
                }
            }

            this.SimpleBinding(this.tbWeight, "Weight", true, DataSourceUpdateMode.OnPropertyChanged);

            if (this.tbWeight.Text == "")
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                if (_result2.HasValue)
                {
                    this.tbWeight.Text = _result2.value1;
                }
            }

            this.SimpleBinding(this.tbDoctor, "FollowUpDoctor", false, DataSourceUpdateMode.OnPropertyChanged);

            string followupWay = this.HypertensionFollowRcd.FollowUpWay;

            if (followupWay == null) this.radMZ.Checked = true;
            else if (!(followupWay == ""))
            {
                if (followupWay == "1") this.radMZ.Checked = true;
                else if (followupWay == "2") this.radFamily.Checked = true;
                else if (followupWay == "3") this.radPhone.Checked = true;
            }
            else this.radMZ.Checked = true;

            this.zhengzhuang = new ManyCheckboxs<ChronicHypertensionVisitModel>(this.HypertensionFollowRcd);
            this.zhengzhuang.AddCk(this.ckGroup1, true);
            this.zhengzhuang.AddCk(new CheckBox[] { this.ckGroup2, this.ckGroup3, this.ckGroup4, this.ckGroup5, this.ckGroup6, this.ckGroup7, this.ckGroup8, this.ckGroup9, this.ckGroup10 });
            this.zhengzhuang.BindingProperty("Symptom", "");

            this.SimpleBinding(this.tbZzOther, "SymptomOther", false, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbWeightTarget, "WeightTarGet", true, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbTzzs, "BMI", true, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbTzzsTarget, "BMITarget", true, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbOther, "PhysicalSympToMother", false, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbSomkeCount, "DailySmokeNum", true, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbSmokeCountTarget, "DailySmokeNumTarget", true, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbDrink, "DailyDrinkNum", true, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbDrinkTarget, "DailyDrinkNumTarget", true, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.cbxSportMin, "SportPerMinuteTime", true, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.cbxSportCount, "SportTimePerWeek", true, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.cbxSportCountTarget, "SportTimeSperWeekTarget", true, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.cbxSportMinTarget, "SportPerMinutesTimeTarget", true, DataSourceUpdateMode.OnPropertyChanged);

            tbXinlv.Leave += (o, e) => { Leave(o, e, "高血压随访", "高血压随访信息", "心率"); };
            tbTzzs.Leave += (o, e) => { Leave(o, e, "高血压随访", "高血压随访信息", "体质指数"); };
            tbTzzsTarget.Leave += (o, e) => { Leave(o, e, "高血压随访", "高血压随访信息", "体质指数下次随访目标"); };
            tbWeight.Leave += (o, e) => { Leave(o, e, "高血压随访", "高血压随访信息", "体重"); };
            tbWeightTarget.Leave += (o, e) => { Leave(o, e, "高血压随访", "高血压随访信息", "体重下次随访目标"); };
            tbHight.Leave += (o, e) => { Leave(o, e, "高血压随访", "高血压随访信息", "身高"); };
            tbSomkeCount.Leave += (o, e) => { Leave(o, e, "高血压随访", "高血压随访信息", "日吸烟量"); };
            tbSmokeCountTarget.Leave += (o, e) => { Leave(o, e, "高血压随访", "高血压随访信息", "日吸烟量下次随访目标"); };
            tbDrink.Leave += (o, e) => { Leave(o, e, "高血压随访", "高血压随访信息", "日饮酒量"); };
            tbDrinkTarget.Leave += (o, e) => { Leave(o, e, "高血压随访", "高血压随访信息", "饮酒量下次随访目标"); };

            this.SetComobox(this.cbxYan, this.HypertensionFollowRcd.EatSaltType);
            this.SetComobox(this.cbxYanTarget, this.HypertensionFollowRcd.EatSaltTarGet);

            if (!string.IsNullOrEmpty(this.HypertensionFollowRcd.PsyChoadJustMent))
            {
                if (int.TryParse(this.HypertensionFollowRcd.PsyChoadJustMent, out num))
                {
                    this.cbxXltz.SelectedIndex = num - 1;
                }
            }
            else this.cbxXltz.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(this.HypertensionFollowRcd.ObeyDoctorBehavior))
            {
                if (int.TryParse(this.HypertensionFollowRcd.ObeyDoctorBehavior, out num))
                {
                    this.cbxZyxw.SelectedIndex = num - 1;
                }
            }
            else this.cbxZyxw.SelectedIndex = 0;

            this.SimpleBinding(this.tbAidExam, "AssistantExam", false, DataSourceUpdateMode.OnPropertyChanged);

            new CSelectItem { Info = this.tbBlfyxx, Name = "服药不良反应", Other = "有", CmbSelect = this.cbxBlfy }.TransInfo(this.HypertensionFollowRcd.Adr, this.HypertensionFollowRcd.AdrEx);

            if (!string.IsNullOrEmpty(this.HypertensionFollowRcd.FollowUpType)) //此次随访分类
            {
                this.cbVisitType.SelectedIndex = int.Parse(this.HypertensionFollowRcd.FollowUpType) - 1;
            }

            this.SimpleBinding(this.tbHight, "Hight", true, DataSourceUpdateMode.OnPropertyChanged);

            // 医生建议
            this.SimpleBinding(this.tbdorctview, "DoctorView", false, DataSourceUpdateMode.OnPropertyChanged);

            if (!string.IsNullOrEmpty(this.HypertensionFollowRcd.IsReferral))  //是否转诊
            {
                if (this.HypertensionFollowRcd.IsReferral == "1") this.rdzzyes.Checked = true;
                else if (this.HypertensionFollowRcd.IsReferral == "2") this.rdzzno.Checked = true;
            }

            // 读取用药情况
            if (File.Exists(Application.StartupPath + "\\dose.xml"))
            {
                DataSet ds = new DataSet();

                ds.ReadXml(Application.StartupPath + "\\dose.xml");
                DataTable dt_yw1 = ds.Tables[0];
                yongYaoYC1.setSource(dt_yw1);
                yongYaoYC2.setSource(DeepCopy(dt_yw1));
                yongYaoYC3.setSource(DeepCopy(dt_yw1));
                yongYaoYC4.setSource(DeepCopy(dt_yw1));
                yongYaoYCTZ1.setSource(DeepCopy(dt_yw1));
                yongYaoYCTZ2.setSource(DeepCopy(dt_yw1));
                yongYaoYCTZ3.setSource(DeepCopy(dt_yw1));
            }

            for (int i = 0; i < this.yongyaoyc.Count; i++)
            {
                if (i < this.DrugConditions.Count)
                {
                    this.yongyaoyc[i].Source = this.DrugConditions[i];

                    this.HypertensionFollowRcd.MedicationCompliance = "1";
                }
                else
                {
                    ChronicDrugConditionModel cd_drugcondition = new ChronicDrugConditionModel
                    {
                        ModelState = RecordsStateModel.NoValue,
                        IDCardNo = this.Model.IDCardNo,
                        Type = "1"
                    };

                    this.yongyaoyc[i].Source = cd_drugcondition;
                }
            }

            for (int i = 0; i < this.yongyaoYCtz.Count; i++)
            {
                if (i < this.DrugConditionsTZ.Count)
                {
                    this.yongyaoYCtz[i].Source = this.DrugConditionsTZ[i];

                    this.HypertensionFollowRcd.MedicationCompliance = "1";
                }
                else
                {
                    ChronicDrugConditionModel cd_drugconditionTZ = new ChronicDrugConditionModel
                    {
                        ModelState = RecordsStateModel.NoValue,
                        IDCardNo = this.Model.IDCardNo,
                        Type = "7"
                    };

                    this.yongyaoYCtz[i].Source = cd_drugconditionTZ;
                }
            }

            this.SetComobox(this.cbxFyycx, this.HypertensionFollowRcd.MedicationCompliance);
            this.SimpleBinding(this.tbZzyy, "ReferralReason", false, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbJgkb, "ReferralOrg", false, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.txtReferralContacts, "ReferralContacts", false, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbRemark, "Remarks", false, DataSourceUpdateMode.OnPropertyChanged);

            if (this.HypertensionFollowRcd.NextFollowUpDate.HasValue)
            {
                this.dtpNext.Value = this.HypertensionFollowRcd.NextFollowUpDate.Value;
            }
            else
            {
                this.dtpNext.Value = this.dtpVisit.Value.AddMonths(3);
            }

            if (!string.IsNullOrEmpty(this.HypertensionFollowRcd.NextMeasures))
            {
                this.cbNextMeasures.SelectedIndex = int.Parse(this.HypertensionFollowRcd.NextMeasures) - 1;
            }

            if (this.HypertensionFollowRcd.ReferralResult == "1")
            {
                this.rddw.Checked = true;
            }
            else if (this.HypertensionFollowRcd.ReferralResult == "2")
            {
                this.rdwdw.Checked = true;
            }

            MustChoose();

            // 签名初始化
            this.SignS = string.Format("{0}{1}_{2}.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpVisit.Value).ToString("yyyyMMdd"));
            if (File.Exists(this.SignS))
            {
                Image imgeb = Image.FromFile(SignS);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSignJm.Image = bmp;
                picSignJm.Show();
                imgeb.Dispose();
                this.lkJm.Enabled = true;
                picSignJm.BackColor = Color.White;
            }
            this.SignDoc = string.Format("{0}{1}_{2}_Doc.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpVisit.Value).ToString("yyyyMMdd"));
            if (File.Exists(this.SignDoc))
            {
                Image imgeb = Image.FromFile(SignDoc);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSignYs.Image = bmp;
                picSignYs.Show();
                imgeb.Dispose();
                this.lkYs.Enabled = true;
                picSignYs.BackColor = Color.White;
            }

            this.EveryThingIsOk = true;

            if (this.IDPerson == 0)
            {
                // 同步体检
                RecordsCustomerBaseInfoModel customerBaseModel = new RecordsCustomerBaseInfoBLL().GetMaxModel(Model.IDCardNo);

                if (customerBaseModel != null)
                {
                    DataTable dtLifeStyle = lifeStyleBll.GetRecordslifestyledt(Model.IDCardNo, customerBaseModel.ID).Tables[0];
                    DataTable dtGeneralCondition = generalConditionBll.Getrecordsgeneralconditiondt(Model.IDCardNo, customerBaseModel.ID).Tables[0];

                    if (dtGeneralCondition.Rows.Count > 0)
                    {
                        DataRow rowGeneralCondition = dtGeneralCondition.Rows[0];

                        // 一般状况
                        tbXueya.Text = rowGeneralCondition["LeftHeight"].ToString() + "/" + rowGeneralCondition["LeftPre"].ToString();

                        if (rowGeneralCondition["BreathRate"].ToString() != "")
                        {
                            tbXinlv.Text = rowGeneralCondition["BreathRate"].ToString();
                        }

                        this.HypertensionFollowRcd.Hypertension = new decimal?(int.Parse(rowGeneralCondition["LeftHeight"].ToString()));
                        this.HypertensionFollowRcd.Hypotension = new decimal?(int.Parse(rowGeneralCondition["LeftPre"].ToString()));

                        if (this.HypertensionFollowRcd.Hypertension >= 180 || this.HypertensionFollowRcd.Hypotension >= 110)
                        {
                            this.cbNextMeasures.SelectedIndex = 3;
                            this.HypertensionFollowRcd.NextMeasures = "4";
                            this.cbVisitType.SelectedIndex = 1;
                            this.HypertensionFollowRcd.FollowUpType = "2";
                        }
                        else if (this.HypertensionFollowRcd.Hypertension >= 140 || this.HypertensionFollowRcd.Hypotension >= 90)
                        {
                            this.cbNextMeasures.SelectedIndex = 2;
                            this.HypertensionFollowRcd.NextMeasures = "3";
                            this.cbVisitType.SelectedIndex = 1;
                            this.HypertensionFollowRcd.FollowUpType = "2";
                        }
                        else
                        {
                            this.cbNextMeasures.SelectedIndex = 0;
                            this.HypertensionFollowRcd.NextMeasures = "1";
                            this.cbVisitType.SelectedIndex = 0;
                            this.HypertensionFollowRcd.FollowUpType = "1";
                        }

                        tbWeight.Text = rowGeneralCondition["Weight"].ToString();
                        tbTzzs.Text = rowGeneralCondition["BMI"].ToString();
                        this.tbHight.Text = rowGeneralCondition["Height"].ToString();
                    }

                    if (dtLifeStyle.Rows.Count > 0)
                    {
                        DataRow rowLifeStyle = dtLifeStyle.Rows[0];

                        // 生活方式
                        tbSomkeCount.Text = rowLifeStyle["SmokeDayNum"].ToString();
                        tbDrink.Text = rowLifeStyle["DayDrinkVolume"].ToString();

                        if (!string.IsNullOrEmpty(rowLifeStyle["SmokeDayNum"].ToString()))
                        {
                            double smokeNum = Math.Ceiling((double)Convert.ToDouble(rowLifeStyle["SmokeDayNum"].ToString()) * (double)0.5);
                            tbSmokeCountTarget.Text = smokeNum.ToString();
                        }

                        if (!string.IsNullOrEmpty(rowLifeStyle["DayDrinkVolume"].ToString()))
                        {
                            double drinkNum = Math.Ceiling(Convert.ToDouble(rowLifeStyle["DayDrinkVolume"].ToString()) / 2);
                            tbDrinkTarget.Text = drinkNum.ToString();
                        }
                    }
                }
            }
        }

        private void IniPenSignByContrl(AxHWPenSignLib.AxHWPenSign axHWPenSign)
        {
            const UInt32 intColor = 0xC8F8DE;
            axHWPenSign.HWSetBkColor(intColor);
            axHWPenSign.HWSetCtlFrame(2, 0x000000);
            axHWPenSign.HWSetExtWndHandle(this.Handle.ToInt32());
            axHWPenSign.HWSetPenWidth(1);
        }

        /// <summary>
        /// 默认项设置
        /// </summary>
        private void PresetValue()
        {
            ChronicHypertensionVisitModel hypertensionOldModel = hypertensionVisitBll.GetMaxModel(this.Model.IDCardNo);// 获取最新一笔随访数据
            if (hypertensionOldModel == null) hypertensionOldModel = new ChronicHypertensionVisitModel();
            if (HypertensionFollowRcd == null) HypertensionFollowRcd = new ChronicHypertensionVisitModel();

            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = " IsSetValue='是' OR IsSetValue='预设上次体检' ";
            DataTable dt = dv.ToTable();

            HypertensionFollowRcd = CommonExtensions.EntityAssignment<ChronicHypertensionVisitModel>(hypertensionOldModel, HypertensionFollowRcd, dt);
            HypertensionFollowRcd.IDCardNo = this.Model.IDCardNo;
        }

        private void MustChoose()
        {
            DataTable dt = dsRequire.Tables[0];
            DataTable drugdt = drugConditionBll.GetList("IDCardNo ='" + Model.IDCardNo + "' AND Type = '1' " + " AND OUtKey = " + this.IDPerson).Tables[0];
            DataTable drugTZdt = drugConditionBll.GetList("IDCardNo ='" + Model.IDCardNo + "' AND Type = '7' " + " AND OUtKey = " + this.IDPerson).Tables[0];

            ChronicHypertensionVisitModel HypertensionFollowRcds = hypertensionVisitBll.GetModelID(this.IDPerson);
            string NewSign = string.Format("{0}{1}_{2}.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpVisit.Value).ToString("yyyyMMdd"));
            string NewSignDoc = string.Format("{0}{1}_{2}_Doc.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpVisit.Value).ToString("yyyyMMdd"));

            if (HypertensionFollowRcds == null) HypertensionFollowRcds = new ChronicHypertensionVisitModel();


            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "症状":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.Symptom))
                            {
                                this.groupBox4.Text = "*症状";
                                this.groupBox4.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.groupBox4.Text = "症状";
                                this.groupBox4.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血压":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.Hypertension)) && string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.Hypotension)))
                            {
                                this.label2.Text = "*血压";
                                this.label2.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label2.Text = "血压";
                                this.label2.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "心率":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.HeartRate)))
                            {
                                this.label32.Text = "*心率";
                                this.label32.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label32.Text = "心率";
                                this.label32.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体质指数":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.BMI)))
                            {
                                this.label4.Text = "*体质指数";
                                this.label4.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label4.Text = "体质指数";
                                this.label4.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体质指数下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.BMITarGet)))
                            {
                                this.label34.Text = "*下次随访目标";
                                this.label34.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label34.Text = "下次随访目标";
                                this.label34.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体重":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.Weight)))
                            {
                                this.label3.Text = "*体重";
                                this.label3.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label3.Text = "体重";
                                this.label3.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体重下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.WeightTarGet)))
                            {
                                this.label33.Text = "*下次随访目标";
                                this.label33.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label33.Text = "下次随访目标";
                                this.label33.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "日吸烟量":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.DailySmokeNum)))
                            {
                                this.label9.Text = "*日吸烟量";
                                this.label9.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label9.Text = "日吸烟量";
                                this.label9.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "日吸烟量下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.DailySmokeNumTarget)))
                            {
                                this.label26.Text = "*下次随访目标";
                                this.label26.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label26.Text = "下次随访目标";
                                this.label26.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "日饮酒量":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.DailyDrinkNum)))
                            {
                                this.label8.Text = "*日饮酒量";
                                this.label8.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label8.Text = "日饮酒量";
                                this.label8.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "饮酒量下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.DailyDrinkNumTarget)))
                            {
                                this.label28.Text = "*下次随访目标";
                                this.label28.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label28.Text = "下次随访目标";
                                this.label28.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "运动":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.SportTimePerWeek)) && string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.SportPerMinuteTime)))
                            {
                                this.label7.Text = "*运动";
                                this.label7.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label7.Text = "运动";
                                this.label7.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "运动下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.SportPerMinutesTimeTarget)) && string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.SportTimeSperWeekTarget)))
                            {
                                this.label31.Text = "*下次随访目标";
                                this.label31.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label31.Text = "下次随访目标";
                                this.label31.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "摄盐情况":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.EatSaltType))
                            {
                                this.label6.Text = "*摄盐情况";
                                this.label6.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label6.Text = "摄盐情况";
                                this.label6.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "摄盐情况下次随访目标":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.EatSaltTarGet))
                            {
                                this.label35.Text = "*下次随访目标";
                                this.label35.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label35.Text = "下次随访目标";
                                this.label35.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "心里调整":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.PsyChoadJustMent))
                            {
                                this.label10.Text = "*心理调整";
                                this.label10.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label10.Text = "心理调整";
                                this.label10.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "服药依从性":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.MedicationCompliance))
                            {
                                this.label14.Text = "*服药依从性";
                                this.label14.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label14.Text = "服药依从性";
                                this.label14.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "药物不良反应":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.Adr))
                            {
                                this.label13.Text = "*药物不良反应";
                                this.label13.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label13.Text = "药物不良反应";
                                this.label13.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "用药情况":
                            if (drugdt.Rows.Count > 0)
                            {
                                this.groupBox10.Text = "用药情况";
                                this.groupBox10.ForeColor = System.Drawing.Color.Black;
                                break;
                            }
                            else
                            {
                                this.groupBox10.Text = "*用药情况";
                                this.groupBox10.ForeColor = System.Drawing.Color.Red;
                            }
                            break;
                        case "随访日期":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.FollowUpDate)))
                            {
                                this.label43.Text = "*随访日期";
                                this.label43.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label43.Text = "随访日期";
                                this.label43.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "随访医生":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.FollowUpDoctor))
                            {
                                this.label15.Text = "*随访医生";
                                this.label15.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label15.Text = "随访医生";
                                this.label15.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "随访方式":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.FollowUpWay))
                            {
                                this.label1.Text = "*随访方式";
                                this.label1.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label1.Text = "随访方式";
                                this.label1.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "身高":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.Hight)))
                            {
                                this.label18.Text = "*身高";
                                this.label18.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label18.Text = "身高";
                                this.label18.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体征其他":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.PhysicalSympToMother))
                            {
                                this.label5.Text = "*其他";
                                this.label5.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label5.Text = "其他";
                                this.label5.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "遵医行为":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.ObeyDoctorBehavior))
                            {
                                this.label11.Text = "*遵医行为";
                                this.label11.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label11.Text = "遵医行为";
                                this.label11.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "辅助检查":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.AssistantExam))
                            {
                                this.label12.Text = "*辅助检查";
                                this.label12.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label12.Text = "辅助检查";
                                this.label12.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "此次随访分类":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.FollowUpType))
                            {
                                this.label20.Text = "*此次随访分类";
                                this.label20.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label20.Text = "此次随访分类";
                                this.label20.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "下一步管理措施":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.NextMeasures))
                            {
                                this.label49.Text = "*下一步管理措施";
                                this.label49.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label49.Text = "下一步管理措施";
                                this.label49.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "此次随访医生建议":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.DoctorView))
                            {
                                this.label19.Text = "*此次随访医生建议";
                                this.label19.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label19.Text = "此次随访医生建议";
                                this.label19.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "用药调整意见":
                            if (drugTZdt.Rows.Count > 0)
                            {
                                this.groupBox9.Text = "用药调整意见";
                                this.groupBox9.ForeColor = System.Drawing.Color.Black;
                                break;
                            }
                            else
                            {
                                this.groupBox9.Text = "*用药调整意见";
                                this.groupBox9.ForeColor = System.Drawing.Color.Red;
                            }
                            break;
                        case "转诊情况":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.IsReferral))
                            {
                                this.label41.Text = "*转诊情况";
                                this.label41.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label41.Text = "转诊情况";
                                this.label41.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "备注":
                            if (string.IsNullOrEmpty(HypertensionFollowRcds.Remarks))
                            {
                                this.label52.Text = "*备注";
                                this.label52.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label52.Text = "备注";
                                this.label52.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "下次随访日期":
                            if (string.IsNullOrEmpty(Convert.ToString(HypertensionFollowRcds.NextFollowUpDate)))
                            {
                                this.label361.Text = "*下次随访日期";
                                this.label361.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label361.Text = "下次随访日期";
                                this.label361.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "医生签名":
                            if (File.Exists(NewSignDoc))
                            {
                                this.label42.Text = "医生签名";
                                this.label42.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.label42.Text = "*医生签名";
                                this.label42.ForeColor = System.Drawing.Color.Red;
                            }
                            break;
                        case "居民签名":
                            if (File.Exists(NewSign))
                            {
                                this.label54.Text = "居民签名";
                                this.label54.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.label54.Text = "*居民签名";
                                this.label54.ForeColor = System.Drawing.Color.Red;
                            }
                            break;
                        default: break;
                    }
                }
            }
        }

        public void NotisfyChildStatus()
        {
        }

        public T DeepCopy<T>(T mo)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, mo);
            stream.Position = 0;

            return (T)formatter.Deserialize(stream);
        }

        private void SaveModel()
        {
            decimal num2;

            if (!string.IsNullOrEmpty(this.tbXueya.Text.Trim()))
            {
                string[] xueyadata = this.tbXueya.Text.Trim().Split('/');

                if (xueyadata.Length == 2)
                {
                    if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                    {
                        this.HypertensionFollowRcd.Hypertension = Convert.ToDecimal(xueyadata[0].Trim());
                    }
                    else
                    {
                        this.HypertensionFollowRcd.Hypertension = null;
                    }
                    if (!string.IsNullOrEmpty(xueyadata[1].ToString()))
                    {
                        this.HypertensionFollowRcd.Hypotension = Convert.ToDecimal(xueyadata[1].Trim());
                    }
                    else
                    {
                        this.HypertensionFollowRcd.Hypotension = null;
                    }
                }
                else if (xueyadata.Length == 1)
                {
                    if (this.tbXueya.Text.Substring(0, 1) == "/")
                    {
                        if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                        {
                            this.HypertensionFollowRcd.Hypertension = null;
                            this.HypertensionFollowRcd.Hypotension = Convert.ToDecimal(xueyadata[0].Trim());
                        }
                    }
                    else if ((decimal.TryParse(this.tbXueya.Text, out num2)) && (num2 != 0M))
                    {
                        if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                        {
                            this.HypertensionFollowRcd.Hypertension = Convert.ToDecimal(xueyadata[0].Trim());
                            this.HypertensionFollowRcd.Hypotension = null;
                        }
                    }
                    else
                    {
                        this.tbXueya.Text = "";
                        this.HypertensionFollowRcd.Hypertension = null;
                        this.HypertensionFollowRcd.Hypotension = null;
                    }
                }
            }
            else
            {
                this.HypertensionFollowRcd.Hypertension = null;
                this.HypertensionFollowRcd.Hypotension = null;
            }

            ChronicHypertensionVisitModel hyperVisitModel = hypertensionVisitBll.ExistsCheckDate(this.HypertensionFollowRcd);

            if (hyperVisitModel != null)
            {
                if (this.IDPerson > 0 && this.visitdate == this.HypertensionFollowRcd.FollowUpDate.ToString())
                {
                    this.IDPerson = hyperVisitModel.ID;
                    this.HypertensionFollowRcd.ID = hyperVisitModel.ID;
                    hypertensionVisitBll.Update(this.HypertensionFollowRcd);
                }
                else
                {
                    DialogResult result = DialogResult.OK;

                    result = MessageBox.Show("此日期下已有随访信息，是否进行修改？", "提示", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        hypertensionVisitBll.Delete(this.IDPerson);
                        drugConditionBll.DeleteOUTKey(this.IDPerson, "1");
                        this.IDPerson = hyperVisitModel.ID;
                        this.HypertensionFollowRcd.ID = hyperVisitModel.ID;
                        hypertensionVisitBll.Update(this.HypertensionFollowRcd);
                    }
                    else return;
                }
            }
            else
            {
                if (this.IDPerson > 0)
                {
                    hypertensionVisitBll.Delete(this.IDPerson);
                    drugConditionBll.DeleteOUTKey(this.IDPerson, "1");
                }

                this.IDPerson = hypertensionVisitBll.Add(this.HypertensionFollowRcd);
            }

            // 目前用药情况
            drugConditionBll.DeleteOUTKey(this.IDPerson, "1");

            for (int i = 0; i < this.DrugConditions.Count; i++)
            {
                DrugConditions[i].OUTKey = this.IDPerson;
                DrugConditions[i].Type = "1";

                if (!string.IsNullOrEmpty(this.DrugConditions[i].Name))
                {
                    drugConditionBll.Add(this.DrugConditions[i]);
                }
            }

            // 用药调整情况
            drugConditionBll.DeleteOUTKey(this.IDPerson, "7");

            for (int i = 0; i < this.DrugConditionsTZ.Count; i++)
            {
                DrugConditionsTZ[i].OUTKey = this.IDPerson;
                DrugConditionsTZ[i].Type = "7";

                if (!string.IsNullOrEmpty(this.DrugConditionsTZ[i].Name))
                {
                    drugConditionBll.Add(this.DrugConditionsTZ[i]);
                }
            }

            string NewSign = string.Format("{0}{1}_{2}.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpVisit.Value).ToString("yyyyMMdd"));
            string NewSignDoc = string.Format("{0}{1}_{2}_Doc.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpVisit.Value).ToString("yyyyMMdd"));
        }

        public bool SaveModelToDB()
        {
            this.SaveModel();
            return true;
        }

        private void SetComobox(ComboBox cbx, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                int num;
                if (int.TryParse(value, out num))
                {
                    cbx.SelectedIndex = num - 1;
                }
            }
            else
            {
                cbx.SelectedIndex = 0;
            }
        }

        private void SimpleBinding(ComboBox cb, string member, bool formate, DataSourceUpdateMode mode)
        {
            Binding binding = new Binding("Text", this.HypertensionFollowRcd, member, formate, mode);
            if (formate)
            {
                binding.Parse += new ConvertEventHandler(this.bd_Parse);
            }
            else
            {
                binding.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
            cb.DataBindings.Add(binding);
        }

        private void SimpleBinding(TextBox tb, string member, bool formate, DataSourceUpdateMode mode)
        {
            Binding binding = new Binding("Text", this.HypertensionFollowRcd, member, formate, mode);
            if (formate)
            {
                binding.Parse += new ConvertEventHandler(this.bd_Parse);
            }
            else
            {
                binding.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
            tb.DataBindings.Add(binding);
        }

        private void btnWeightNext_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbHight.Text))
            {
                if (tbTzzsTarget.Text != "")
                {
                    double height = Convert.ToDouble(this.tbHight.Text) * (0.01);
                    double height2 = Convert.ToDouble(height * height);
                    double WTarget = Convert.ToDouble(tbTzzsTarget.Text.ToString());
                    decimal WeightTarget = (decimal)(WTarget * height2);

                    if (string.IsNullOrEmpty(this.tbWeight.Text))  //减轻体重量目标最大为3kg，超过3kg，按3kg减轻。
                    {
                        tbWeightTarget.Text = WeightTarget.ToString(".00");
                    }
                    else
                    {
                        decimal reduceWeight = Convert.ToDecimal(this.tbWeight.Text) - WeightTarget;

                        if (reduceWeight > 3)
                        {
                            tbWeightTarget.Text = (Convert.ToDecimal(this.tbWeight.Text) - 3).ToString(".00");
                        }
                        else tbWeightTarget.Text = WeightTarget.ToString(".00");
                    }
                }
            }
            else
            {
                RecordsCustomerBaseInfoModel customerbasemodel = new RecordsCustomerBaseInfoBLL().GetMaxModel(Model.IDCardNo);

                if (customerbasemodel != null)
                {
                    DataTable dtGeneralCondition = generalConditionBll.Getrecordsgeneralconditiondt(Model.IDCardNo, customerbasemodel.ID).Tables[0];

                    if (dtGeneralCondition.Rows.Count > 0)
                    {
                        DataRow rowGeneralCondition = dtGeneralCondition.Rows[0];

                        if (tbTzzsTarget.Text != "" && rowGeneralCondition["Height"].ToString() != "")
                        {
                            double height = Convert.ToDouble(rowGeneralCondition["Height"].ToString()) * (0.01);
                            double height2 = Convert.ToDouble(height * height);
                            double WTarget = Convert.ToDouble(tbTzzsTarget.Text.ToString());
                            decimal WeightTarget = (decimal)(WTarget * height2);

                            if (string.IsNullOrEmpty(this.tbWeight.Text))
                            {
                                tbWeightTarget.Text = WeightTarget.ToString(".00");
                            }
                            else
                            {
                                decimal ReduceWeight = Convert.ToDecimal(this.tbWeight.Text) - WeightTarget;

                                if (ReduceWeight > 3)
                                {
                                    tbWeightTarget.Text = (Convert.ToDecimal(this.tbWeight.Text) - 3).ToString(".00");
                                }
                                else
                                {
                                    tbWeightTarget.Text = WeightTarget.ToString(".00");
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 随访目标体质指数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBMI_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbHight.Text))
            {
                if (tbWeight.Text != "")
                {
                    double height = Convert.ToDouble(this.tbHight.Text) * (0.01);
                    double height2 = Convert.ToDouble(height * height);
                    double WTarget = Convert.ToDouble(tbWeight.Text.ToString());
                    tbTzzs.Text = ((decimal)(WTarget / height2)).ToString("0.00");
                }
            }
            else
            {
                RecordsCustomerBaseInfoModel customerBaseModel = new RecordsCustomerBaseInfoBLL().GetMaxModel(Model.IDCardNo);

                if (customerBaseModel != null)
                {
                    DataTable dtGeneralCondition = generalConditionBll.Getrecordsgeneralconditiondt(Model.IDCardNo, customerBaseModel.ID).Tables[0];

                    if (dtGeneralCondition.Rows.Count > 0)
                    {
                        DataRow rowGeneralCondition = dtGeneralCondition.Rows[0];

                        if (tbWeight.Text != "" && rowGeneralCondition["Height"].ToString() != "")
                        {
                            double height = Convert.ToDouble(rowGeneralCondition["Height"].ToString()) * (0.01);
                            double height2 = Convert.ToDouble(height * height);
                            double WTarget = Convert.ToDouble(tbWeight.Text.ToString());

                            tbTzzs.Text = ((decimal)(WTarget / height2)).ToString("0.00");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 焦点离开方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="TabName">模块名称</param>
        /// <param name="Comment">功能名称</param>
        /// <param name="ChinName">栏位名称</param>
        public void Leave(object sender, EventArgs e, string TabName, string Comment, string ChinName)
        {
            double f = 0f;
            TextBox txt = (TextBox)sender;
            string WenBen = txt.Text.ToString();

            if (string.IsNullOrEmpty(WenBen)) return;

            if (!double.TryParse(WenBen, out f))
            {
                MessageBox.Show(ChinName + "只能输入数字！");
                txt.Text = "";
                return;
            }

            // 如果文本中不存在 . 表示不是小数，不需要判断
            if (WenBen.IndexOf('.') == -1) return;

            // 如果文本中第一位是.那么前面加个0
            if (WenBen.IndexOf('.') == 0)
            {
                txt.Text = 0 + WenBen;
                WenBen = txt.Text.ToString();
            }

            // 根据模块名称、功能名称、栏位名称查询数据
            RequireModel model = requireBLL.GetModel(TabName, Comment, ChinName);

            if (model == null)
            {
                model = new RequireModel();
                model.IsDecimalPlace = "是";
                model.DecimalPlace = 2;
            }

            string i = WenBen.ToString().Remove(0, WenBen.ToString().IndexOf('.') + 1);

            if (model.IsDecimalPlace == "是" || model.DecimalPlace == 0)
            {
                if (i.Length > model.DecimalPlace)
                {
                    MessageBox.Show("当前默认项设定" + ChinName + "只能有" + model.DecimalPlace + "位小数！");
                    if (model.DecimalPlace == 0)
                    {
                        txt.Text = WenBen.Substring(0, WenBen.IndexOf('.'));
                    }
                    else
                    {
                        txt.Text = WenBen.Substring(0, WenBen.IndexOf('.') + model.DecimalPlace + 1);
                    }
                    return;
                }
                else if (i.Length == 0) txt.Text = WenBen + "0";
            }
            else
            {
                MessageBox.Show("当前默认项设定" + ChinName + "不能输入小数或小数位数为0！");
                txt.Text = WenBen.Substring(0, WenBen.IndexOf('.'));
                return;
            }
        }

        /// <summary>
        /// 下次随访目标体质指数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextBMI_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbHight.Text))
            {
                if (tbWeightTarget.Text != "")
                {
                    double height = Convert.ToDouble(this.tbHight.Text) * (0.01);
                    double height2 = Convert.ToDouble(height * height);
                    double WTarget = Convert.ToDouble(tbWeightTarget.Text.ToString());
                    tbTzzsTarget.Text = ((decimal)(WTarget / height2)).ToString("0.00");
                }
            }
            else
            {
                RecordsCustomerBaseInfoModel customerBaseModel = new RecordsCustomerBaseInfoBLL().GetMaxModel(Model.IDCardNo);

                if (customerBaseModel != null)
                {
                    DataTable dtGeneralCondition = generalConditionBll.Getrecordsgeneralconditiondt(Model.IDCardNo, customerBaseModel.ID).Tables[0];

                    if (dtGeneralCondition.Rows.Count > 0)
                    {
                        DataRow rowGeneralCondition = dtGeneralCondition.Rows[0];

                        if (tbWeightTarget.Text != "" && rowGeneralCondition["Height"].ToString() != "")
                        {
                            double height = Convert.ToDouble(rowGeneralCondition["Height"].ToString()) * (0.01);
                            double height2 = Convert.ToDouble(height * height);
                            double WTarget = Convert.ToDouble(tbWeightTarget.Text.ToString());

                            tbTzzsTarget.Text = ((decimal)(WTarget / height2)).ToString("0.00");
                        }
                    }
                }
            }
        }

        private void btnNoSmoke_Click(object sender, EventArgs e)
        {
            tbSmokeCountTarget.Text = "0";
        }

        private void btnNoDrink_Click(object sender, EventArgs e)
        {
            tbDrinkTarget.Text = "0";
        }

        public void UpdataToModel()
        {
            this.HypertensionFollowRcd.FollowUpDate = new DateTime?(this.dtpVisit.Value.Date);
            this.HypertensionFollowRcd.CustomerName = this.Model.CustomerName;

            if (this.radMZ.Checked) this.HypertensionFollowRcd.FollowUpWay = "1";
            if (this.radPhone.Checked) this.HypertensionFollowRcd.FollowUpWay = "3";
            if (this.radFamily.Checked) this.HypertensionFollowRcd.FollowUpWay = "2";

            this.HypertensionFollowRcd.EatSaltType = Convert.ToString((int)(this.cbxYan.SelectedIndex + 1));
            this.HypertensionFollowRcd.EatSaltTarGet = Convert.ToString((int)(this.cbxYanTarget.SelectedIndex + 1));
            this.HypertensionFollowRcd.PsyChoadJustMent = Convert.ToString((int)(this.cbxXltz.SelectedIndex + 1));
            this.HypertensionFollowRcd.ObeyDoctorBehavior = Convert.ToString((int)(this.cbxZyxw.SelectedIndex + 1));
            this.HypertensionFollowRcd.MedicationCompliance = Convert.ToString((int)(this.cbxFyycx.SelectedIndex + 1));
            this.HypertensionFollowRcd.Adr = Convert.ToString((int)(this.cbxBlfy.SelectedIndex + 1));
            this.HypertensionFollowRcd.AdrEx = this.tbBlfyxx.Text;

            if (this.cbVisitType.SelectedIndex != -1)
            {
                this.HypertensionFollowRcd.FollowUpType = Convert.ToString((int)(this.cbVisitType.SelectedIndex + 1));
            }

            decimal numHight;

            if (decimal.TryParse(this.tbHight.Text, out numHight))
            {
                this.HypertensionFollowRcd.Hight = numHight;
            }

            // 是否转诊
            if (this.rdzzno.Checked) this.HypertensionFollowRcd.IsReferral = "2";
            else if (this.rdzzyes.Checked) this.HypertensionFollowRcd.IsReferral = "1";

            for (int i = 0; i < this.yongyaoyc.Count; i++)
            {
                this.yongyaoyc[i].UpdateSource();

                if (this.yongyaoyc[i].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.DrugConditions.Add(this.yongyaoyc[i].Source);
                }
            }

            for (int i = 0; i < this.yongyaoYCtz.Count; i++)
            {
                this.yongyaoYCtz[i].UpdateSource();
                if (this.yongyaoYCtz[i].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.DrugConditionsTZ.Add(this.yongyaoYCtz[i].Source);
                }
            }

            this.HypertensionFollowRcd.NextFollowUpDate = new DateTime?(this.dtpNext.Value.Date);

            if (this.cbNextMeasures.SelectedIndex != -1)
            {
                this.HypertensionFollowRcd.NextMeasures = Convert.ToString(this.cbNextMeasures.SelectedIndex + 1);
            }

            if (this.rddw.Checked) this.HypertensionFollowRcd.ReferralResult = "1";
            else if (this.rdwdw.Checked) this.HypertensionFollowRcd.ReferralResult = "2";
            else this.HypertensionFollowRcd.ReferralResult = null;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoseFrm f = new DoseFrm();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private List<ChronicDrugConditionModel> DrugConditions { get; set; }

        private List<ChronicDrugConditionModel> DrugConditionsTZ { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        private ChronicHypertensionVisitModel HypertensionFollowRcd { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public int IDPerson { get; set; }

        /// <summary>
        /// 症状其他
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckGroup10_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckGroup10.Checked)
            {
                this.tbZzOther.ReadOnly = false;
            }
            else
            {
                this.tbZzOther.Clear();
                this.tbZzOther.ReadOnly = true;
            }
        }

        /// <summary>
        /// 是否转诊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdzzyes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdzzyes.Checked)
            {
                this.tbZzyy.ReadOnly = false;
                this.tbJgkb.ReadOnly = false;
                this.txtReferralContacts.ReadOnly = false;
                this.panel7.Enabled = true;
            }
            else
            {
                this.tbZzyy.Clear();
                this.tbJgkb.Clear();
                this.txtReferralContacts.Clear();
                this.tbZzyy.ReadOnly = true;
                this.tbJgkb.ReadOnly = true;
                this.txtReferralContacts.ReadOnly = true;
                this.panel7.Enabled = false;
                this.rddw.Checked = false;
                this.rdwdw.Checked = false;
            }
        }

        public override void UpdateDeviceinfoContent(int msg)
        {
            switch (msg)
            {
                case 0x597:
                    {
                        stru_result _result = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20", "血压");

                        if (_result.HasValue)
                        {
                            this.HypertensionFollowRcd.Hypertension = new decimal?((int.Parse(_result.value1)));
                            this.HypertensionFollowRcd.Hypotension = new decimal?((int.Parse(_result.value2)));

                            this.tbXueya.Text = _result.value1 + "/" + _result.value2;
                            this.tbXinlv.Text = _result.value3;

                            if (this.HypertensionFollowRcd.Hypertension >= 180 || this.HypertensionFollowRcd.Hypotension >= 110)
                            {
                                this.cbNextMeasures.SelectedIndex = 3;
                                this.HypertensionFollowRcd.NextMeasures = "4";
                                this.cbVisitType.SelectedIndex = 1;
                                this.HypertensionFollowRcd.FollowUpType = "2";
                            }
                            else if (this.HypertensionFollowRcd.Hypertension >= 140 || this.HypertensionFollowRcd.Hypotension >= 90)
                            {
                                this.cbNextMeasures.SelectedIndex = 2;
                                this.HypertensionFollowRcd.NextMeasures = "3";
                                this.cbVisitType.SelectedIndex = 1;
                                this.HypertensionFollowRcd.FollowUpType = "2";
                            }
                            else
                            {
                                this.cbNextMeasures.SelectedIndex = 0;
                                this.HypertensionFollowRcd.NextMeasures = "1";
                                this.cbVisitType.SelectedIndex = 0;
                                this.HypertensionFollowRcd.FollowUpType = "1";
                            }

                            return;
                        }
                        return;
                    }

                case 0x599:

                case 0x59b:
                    break;

                case 0x59c:
                    {
                        stru_result _result4 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                        if (_result4.HasValue)
                        {
                            this.tbWeight.Text = _result4.value1;
                            return;
                        }
                        return;
                    }

                default:
                    return;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("", picSignJm);
        }

        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_Doc", picSignYs);
        }

        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();
            string date = dtpVisit.Value.ToString("yyyyMMdd");
            if (!Directory.Exists(SignPath + date))
            {
                Directory.CreateDirectory(SignPath + date);
            }
            loadForm.IDCardNo = Model.IDCardNo + "_" + date;
            loadForm.SignPath = SignPath;
            loadForm.SignName = DaySign;
            if (loadForm.ShowDialog() == DialogResult.OK)
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                }
                string path = string.Format("{0}{1}{2}.png", SignPath, Model.IDCardNo + "_" + date, DaySign);
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
                    string date = dtpVisit.Value.ToString("yyyyMMdd");
                    string path = SignPath + Model.IDCardNo + "_" + date + DaySign + ".png";
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

        private void picSignYs_Click(object sender, EventArgs e)
        {
            Sign("_Doc", picSignYs);
        }

        private void picSignJm_Click(object sender, EventArgs e)
        {
            Sign("", picSignJm);
        }

        private void tbXueya_TextChanged(object sender, EventArgs e)
        {
            string[] value = tbXueya.Text.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            if (value.Length > 1)
            {
                decimal Hypertension = Convert.ToDecimal(value[0]);
                decimal Hypotension = Convert.ToDecimal(value[1]);

                if (Hypertension >= 180 || Hypotension >= 110)
                {
                    this.cbNextMeasures.SelectedIndex = 3;
                    this.HypertensionFollowRcd.NextMeasures = "4";
                    this.cbVisitType.SelectedIndex = 1;
                    this.HypertensionFollowRcd.FollowUpType = "2";
                }
                else if (Hypertension >= 140 || Hypotension >= 90)
                {
                    this.cbNextMeasures.SelectedIndex = 2;
                    this.HypertensionFollowRcd.NextMeasures = "3";
                    this.cbVisitType.SelectedIndex = 1;
                    this.HypertensionFollowRcd.FollowUpType = "2";
                }
                else
                {
                    this.cbNextMeasures.SelectedIndex = 0;
                    this.HypertensionFollowRcd.NextMeasures = "1";
                    this.cbVisitType.SelectedIndex = 0;
                    this.HypertensionFollowRcd.FollowUpType = "1";
                }
            }
        }
    }
}