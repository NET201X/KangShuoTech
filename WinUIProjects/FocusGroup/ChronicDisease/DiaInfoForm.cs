
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
using System.Data;
using System.IO;

namespace FocusGroup.ChronicDisease
{
    public class DiaInfoForm : Form, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<ChronicDiabetesBaseInfoModel> bindingManager;
        private ComboBox cbEndManage;
        private ComboBox cbxDietesTypes;
        private ComboBox cbxFromWhere;
        private ComboBox cbxManagerGroup;
        private CheckBox ck1;
        private CheckBox ck2;
        private CheckBox ck3;
        private CheckBox ck4;
        private CheckBox ck5;
        private CheckBox ck6;
        private CheckBox ck7;
        private CheckedListBox cklSymptom;
        private CheckBox ckNxg;
        private CheckBox ckQt;
        private CheckBox ckSj;
        private CheckBox ckSwm;
        private CheckBox ckSz;
        private CheckBox ckXz;
        private CheckBox ckZb;
        private IContainer components;
        private DateTimePicker dtpDiabeteDate;
        private DateTimePicker dtpNaoxueguan;
        private DateTimePicker dtpOther;
        private DateTimePicker dtpShengjing;
        private DateTimePicker dtpShenzhang;
        private DateTimePicker dtpShiwangm;
        private DateTimePicker dtpStopDate;
        private DateTimePicker dtpXinzhang;
        private DateTimePicker dtpZhubu;
        private JustSingleItem<ChronicDiabetesBaseInfoModel> endManager;
        private ManyCheckboxs<ChronicDiabetesBaseInfoModel> famHistory;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label35;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private RadioButton rdEndNo;
        private RadioButton rdEndYes;
        private RadioButton rdNoJYY;
        private RadioButton rdNoYDS;
        private RadioButton rdUseJYY;
        private RadioButton rdUseYDS;
        private CMoreChange symptom;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbDiabeteUnit;
        private TextBox tbQtIll;
        private TextBox tbYDS;
        private SingleItemT<ChronicDiabetesBaseInfoModel> useYDS;

        public DiaInfoForm()
        {
            this.InitializeComponent();
            this.InitComobox();
            this.EveryThingIsOk = false;
        }

        private void BindingModel()
        {
            bingfazheng bingfazheng1;
            this.diabetesBaseInfo = new ChronicDiabetesBaseInfoBLL().GetModel(this.Model.IDCardNo);
            if (this.diabetesBaseInfo == null)
            {
                ChronicDiabetesBaseInfoModel chronicDiabetesBaseInfoBLL = new ChronicDiabetesBaseInfoModel {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID
                };
                this.diabetesBaseInfo = chronicDiabetesBaseInfoBLL;
                this.diabetesBaseInfo.ManagementGroup = "1";
                this.diabetesBaseInfo.CaseSource = "1";
                this.diabetesBaseInfo.Symptom = "1";
                this.diabetesBaseInfo.Lesions = "1";
                this.diabetesBaseInfo.EndManage = "2";
                this.diabetesBaseInfo.CreateUnit = new decimal?(ConfigHelper.GetNodeDec("orgCode"));
                this.diabetesBaseInfo.CreateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.diabetesBaseInfo.CreateDate = new DateTime?(DateTime.Today);
            }
            else
            {
                this.diabetesBaseInfo.CreateUnit = new decimal?(ConfigHelper.GetNodeDec("orgCode"));
                this.diabetesBaseInfo.LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.diabetesBaseInfo.LastUpdateDate = new DateTime?(DateTime.Today);
            }
            this.bindingManager = new SimpleBindingManager<ChronicDiabetesBaseInfoModel>(this.inputRanges, this.inputrange_str, this.diabetesBaseInfo);
            this.SimpleBinding(this.cbxManagerGroup, this.diabetesBaseInfo, "ManagementGroup");
            this.SimpleBinding(this.cbxFromWhere, this.diabetesBaseInfo, "CaseSource");
            this.SimpleBinding(this.cbxDietesTypes, this.diabetesBaseInfo, "DiabetesType");
            this.famHistory = new ManyCheckboxs<ChronicDiabetesBaseInfoModel>(this.diabetesBaseInfo);
            this.famHistory.AddCk(new LoneCheckbox[] { new LoneCheckbox(this.ck1), new LoneCheckbox(this.ck2), new LoneCheckbox(this.ck3), new LoneCheckbox(this.ck4), new LoneCheckbox(this.ck5, true), new LoneCheckbox(this.ck6, true), new LoneCheckbox(this.ck7, true) });
            this.famHistory.BindingProperty("FamilyHistory", "");
            if (this.diabetesBaseInfo.DiabetesTime.HasValue)
            {
                this.dtpDiabeteDate.Value = this.diabetesBaseInfo.DiabetesTime.Value;
            }
            this.bindingManager.SimpleBinding(this.tbDiabeteUnit, "DiabetesWork", false);
            SingleItemT<ChronicDiabetesBaseInfoModel> mt = new SingleItemT<ChronicDiabetesBaseInfoModel>(this.diabetesBaseInfo) {
                Name = "脾大",
                Usual = this.rdNoYDS,
                Unusual = this.rdUseYDS,
                Info = this.tbYDS,
                MaxBytesCount = 50,
                StrUsual = "1",
                StrUnusual = "2"
            };
            this.useYDS = mt;
            this.useYDS.BindProperty("Insulin", "InsulinWeight");
            if (!string.IsNullOrEmpty(this.diabetesBaseInfo.EnalaprilMelete))
            {
                if (this.diabetesBaseInfo.EnalaprilMelete == "1")
                {
                    this.rdUseJYY.Checked = true;
                }
                else
                {
                    this.rdNoJYY.Checked = true;
                }
            }
            else
            {
                this.rdNoJYY.Checked = false;
            }
            CMoreChange change = new CMoreChange {
                Name = "目前症状",
                MoreChange = this.cklSymptom,
                Unusual = "无症状"
            };
            this.symptom = change;
            this.symptom.TransInfo(this.diabetesBaseInfo.Symptom, "");
            new bingfazheng(this.ckSz, this.dtpShenzhang, this.diabetesBaseInfo, "RenalLesionsTime");
            new bingfazheng(this.ckSj, this.dtpShengjing, this.diabetesBaseInfo, "NeuropathyTime");
            new bingfazheng(this.ckXz, this.dtpXinzhang, this.diabetesBaseInfo, "HeartDiseaseTime");
            new bingfazheng(this.ckSwm, this.dtpShiwangm, this.diabetesBaseInfo, "RetinopathyTime");
            new bingfazheng(this.ckZb, this.dtpZhubu, this.diabetesBaseInfo, "FootLesionsTime");
            new bingfazheng(this.ckNxg, this.dtpNaoxueguan, this.diabetesBaseInfo, "CerebrovascularTime");
            bingfazheng1 = new bingfazheng(this.ckQt, this.dtpOther, this.diabetesBaseInfo, "LesionsOtherTime");
            bingfazheng1 = new bingfazheng(this.ckQt, this.dtpOther, this.diabetesBaseInfo, "LesionsOtherTime") {
                ckChecked = (Action<bool>) Delegate.Combine(bingfazheng1.ckChecked, new Action<bool>(this.ckQt_checked))
            };
            this.bindingManager.SimpleBinding(this.tbQtIll, "LesionsOther", false);
            if (this.ckQt.Checked)
            {
                this.tbQtIll.ReadOnly = false;
            }
            JustSingleItem<ChronicDiabetesBaseInfoModel> item = new JustSingleItem<ChronicDiabetesBaseInfoModel>(this.diabetesBaseInfo) {
                R1 = this.rdEndYes,
                R2 = this.rdEndNo
            };
            this.endManager = item;
            this.endManager.statusChanged = (Action<string>) Delegate.Combine(this.endManager.statusChanged, new Action<string>(this.ckend_checked));
            this.endManager.BindProperty("EndManage");
            this.bindingManager.SimpleBinding(this.cbEndManage, "EndWhy");
            this.ckend_checked(this.diabetesBaseInfo.EndManage);
            if (this.diabetesBaseInfo.EndTime.HasValue)
            {
                this.dtpStopDate.Value = this.diabetesBaseInfo.EndTime.Value;
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            if (this.bindingManager.ErrorInput)
            {
                return ChildFormStatus.HasErrorInput;
            }
            return ChildFormStatus.NoErrorInput;
        }

        private void ckend_checked(string result)
        {
            if (result == "1")
            {
                this.dtpStopDate.Enabled = true;
                this.cbEndManage.Enabled = true;
            }
            else
            {
                this.dtpStopDate.Enabled = false;
                this.cbEndManage.Enabled = false;
                this.cbEndManage.SelectedIndex = -1;
            }
        }

        private void ckQt_checked(bool result)
        {
            if (result)
            {
                this.tbQtIll.ReadOnly = false;
            }
            else
            {
                this.tbQtIll.Text = "";
                this.tbQtIll.ReadOnly = true;
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

        private void FrmDiaInfo_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void InitComobox()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("常规管理", "1"),
                new ItemDictonaryModel<string>("强化管理", "2")
            };
            this.cbxManagerGroup.DisplayMember = "DISPLAYMEMBER";
            this.cbxManagerGroup.ValueMember = "VALUEMEMBER";
            this.cbxManagerGroup.DataSource = list;
            List<ItemDictonaryModel<string>> list2 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("健康档案", "1"),
                new ItemDictonaryModel<string>("首诊测压", "2"),
                new ItemDictonaryModel<string>("社区门诊", "3")
            };
            this.cbxFromWhere.DisplayMember = "DISPLAYMEMBER";
            this.cbxFromWhere.ValueMember = "VALUEMEMBER";
            this.cbxFromWhere.DataSource = list2;
            List<ItemDictonaryModel<string>> list3 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("1型糖尿病", "1"),
                new ItemDictonaryModel<string>("2型糖尿病", "2"),
                new ItemDictonaryModel<string>("营养不良型", "3"),
                new ItemDictonaryModel<string>("IGT", "4"),
                new ItemDictonaryModel<string>("IFG", "5"),
                new ItemDictonaryModel<string>("其他", "6")
            };
            this.cbxDietesTypes.DisplayMember = "DISPLAYMEMBER";
            this.cbxDietesTypes.ValueMember = "VALUEMEMBER";
            this.cbxDietesTypes.DataSource = list3;
            List<ItemDictonaryModel<string>> list4 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("死亡", "1"),
                new ItemDictonaryModel<string>("迁出", "2"),
                new ItemDictonaryModel<string>("失访", "3"),
                new ItemDictonaryModel<string>("拒绝", "4")
            };
            this.cbEndManage.DisplayMember = "DISPLAYMEMBER";
            this.cbEndManage.ValueMember = "VALUEMEMBER";
            this.cbEndManage.DataSource = list4;
            this.inputRanges = new List<InputRangeDec>();
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("DiabetesWork", 100));
            this.inputrange_str.Add(new InputRangeStr("InsulinWeight", 100));
        }

        public void InitEveryThing()
        {
            this.BindingModel();
            MustChoose();
            this.EveryThingIsOk = true;
        }
       
        private void MustChoose()
        {
            DataSet dsrequire = new DataSet();
            dsrequire = new RequireBLL().GetList("TabName = '糖尿病随访' and Comment = '糖尿病基本信息' ");
            ChronicDiabetesBaseInfoModel diabetesBaseInfos = new ChronicDiabetesBaseInfoBLL().GetModel(this.Model.IDCardNo);
            DataTable dt = dsrequire.Tables[0];
            if (diabetesBaseInfos == null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item["Isrequired"].ToString() == "1")
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "家族史":
                                this.groupBox3.Text = "*家族史";
                                this.groupBox3.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "糖尿病类型":
                                this.label3.Text = "*糖尿病类型:";
                                this.label3.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "确诊时间":
                                this.label4.Text = "*确诊时间:";
                                this.label4.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "确诊单位":
                                this.label5.Text = "*确诊单位:";
                                this.label5.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "是否使用胰岛素":
                                this.label6.Text = "*使用胰岛素:";
                                this.label6.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "胰岛素用量":
                                this.label8.Text = "*胰岛素用量:";
                                this.label8.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "是否使用口服降糖药":
                                this.label7.Text = "*是否使用口服降糖药:";
                                this.label7.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "目前症状":
                                this.groupBox2.Text = "*目前症状";
                                this.groupBox2.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "管理组别":
                                this.label35.Text = "*管理组别";
                                this.label35.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "病例来源":
                                this.label1.Text = "*病例来源";
                                this.label1.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "是否终止管理":
                                this.label9.Text = "*是否终止管理";
                                this.label9.ForeColor = System.Drawing.Color.Red;
                                break;
                            default: break;
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item["Isrequired"].ToString() == "1")
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "家族史":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.FamilyHistory))
                                {
                                    this.groupBox3.Text = "*家族史";
                                    this.groupBox3.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.groupBox3.Text = "家族史";
                                    this.groupBox3.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "糖尿病类型":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.DiabetesType))
                                {
                                    this.label3.Text = "*糖尿病类型:";
                                    this.label3.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label3.Text = "糖尿病类型:";
                                    this.label3.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "确诊时间":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.DiabetesTime.Value.ToString("yyyyMMdd")))
                                {
                                    this.label4.Text = "*确诊时间:";
                                    this.label4.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label4.Text = "确诊时间:";
                                    this.label4.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "确诊单位":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.DiabetesWork))
                                {
                                    this.label5.Text = "*确诊单位:";
                                    this.label5.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label5.Text = "确诊单位:";
                                    this.label5.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "是否使用胰岛素":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.Insulin))
                                {
                                    this.label6.Text = "*使用胰岛素:";
                                    this.label6.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label6.Text = "使用胰岛素:";
                                    this.label6.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "胰岛素用量":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.InsulinWeight))
                                {
                                    this.label8.Text = "*胰岛素用量:";
                                    this.label8.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label8.Text = "胰岛素用量:";
                                    this.label8.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "是否使用口服降糖药":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.EnalaprilMelete))
                                {
                                    this.label7.Text = "*是否使用口服降糖药:";
                                    this.label7.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label7.Text = "是否使用口服降糖药:";
                                    this.label7.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "目前症状":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.Symptom))
                                {
                                    this.groupBox2.Text = "*目前症状";
                                    this.groupBox2.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.groupBox2.Text = "目前症状";
                                    this.groupBox2.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "管理组别":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.ManagementGroup))
                                {
                                    this.label35.Text = "*管理组别";
                                    this.label35.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label35.Text = "管理组别";
                                    this.label35.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "病例来源":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.CaseSource))
                                {
                                    this.label1.Text = "*病例来源";
                                    this.label1.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label1.Text = "病例来源";
                                    this.label1.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            case "是否终止管理":
                                if (string.IsNullOrEmpty(diabetesBaseInfos.EndManage))
                                {
                                    this.label9.Text = "*是否终止管理";
                                    this.label9.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label9.Text = "是否终止管理";
                                    this.label9.ForeColor = System.Drawing.Color.Black;
                                }
                                break;
                            default: break;
                        }
                    }
                }
            }

        }
        private void InitializeComponent()
        {
            this.cbxManagerGroup = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxFromWhere = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cklSymptom = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.ck7 = new System.Windows.Forms.CheckBox();
            this.ck6 = new System.Windows.Forms.CheckBox();
            this.ck5 = new System.Windows.Forms.CheckBox();
            this.ck4 = new System.Windows.Forms.CheckBox();
            this.ck3 = new System.Windows.Forms.CheckBox();
            this.ck2 = new System.Windows.Forms.CheckBox();
            this.ck1 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ckZb = new System.Windows.Forms.CheckBox();
            this.dtpZhubu = new System.Windows.Forms.DateTimePicker();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ckNxg = new System.Windows.Forms.CheckBox();
            this.dtpNaoxueguan = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbQtIll = new System.Windows.Forms.TextBox();
            this.ckQt = new System.Windows.Forms.CheckBox();
            this.dtpOther = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckSz = new System.Windows.Forms.CheckBox();
            this.dtpShenzhang = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckSj = new System.Windows.Forms.CheckBox();
            this.dtpShengjing = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ckXz = new System.Windows.Forms.CheckBox();
            this.dtpXinzhang = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ckSwm = new System.Windows.Forms.CheckBox();
            this.dtpShiwangm = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbEndManage = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rdEndNo = new System.Windows.Forms.RadioButton();
            this.rdEndYes = new System.Windows.Forms.RadioButton();
            this.dtpStopDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.rdNoJYY = new System.Windows.Forms.RadioButton();
            this.rdUseJYY = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rdNoYDS = new System.Windows.Forms.RadioButton();
            this.rdUseYDS = new System.Windows.Forms.RadioButton();
            this.tbYDS = new System.Windows.Forms.TextBox();
            this.tbDiabeteUnit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDiabeteDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDietesTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxManagerGroup
            // 
            this.cbxManagerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxManagerGroup.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxManagerGroup.FormattingEnabled = true;
            this.cbxManagerGroup.Location = new System.Drawing.Point(132, 19);
            this.cbxManagerGroup.Name = "cbxManagerGroup";
            this.cbxManagerGroup.Size = new System.Drawing.Size(150, 28);
            this.cbxManagerGroup.TabIndex = 45;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(5, 22);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(119, 20);
            this.label35.TabIndex = 44;
            this.label35.Text = "  管理组别:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbxFromWhere);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxManagerGroup);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Location = new System.Drawing.Point(70, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1402, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbxFromWhere
            // 
            this.cbxFromWhere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFromWhere.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxFromWhere.FormattingEnabled = true;
            this.cbxFromWhere.Location = new System.Drawing.Point(452, 19);
            this.cbxFromWhere.Name = "cbxFromWhere";
            this.cbxFromWhere.Size = new System.Drawing.Size(150, 28);
            this.cbxFromWhere.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "病历来源:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cklSymptom);
            this.groupBox2.Location = new System.Drawing.Point(70, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1401, 109);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目前症状";
            // 
            // cklSymptom
            // 
            this.cklSymptom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cklSymptom.CheckOnClick = true;
            this.cklSymptom.FormattingEnabled = true;
            this.cklSymptom.Items.AddRange(new object[] {
            "无症状",
            "感染",
            "手脚麻木",
            "下肢浮肿",
            "消瘦",
            "乏力",
            "多饮",
            "多食",
            "多尿",
            "视力模糊",
            "其他症状"});
            this.cklSymptom.Location = new System.Drawing.Point(9, 34);
            this.cklSymptom.MultiColumn = true;
            this.cklSymptom.Name = "cklSymptom";
            this.cklSymptom.Size = new System.Drawing.Size(888, 54);
            this.cklSymptom.TabIndex = 0;
            this.cklSymptom.SelectedIndexChanged += new System.EventHandler(this.cklSymptom_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.panel11);
            this.groupBox3.Location = new System.Drawing.Point(71, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1401, 71);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "家族史";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.ck7);
            this.panel11.Controls.Add(this.ck6);
            this.panel11.Controls.Add(this.ck5);
            this.panel11.Controls.Add(this.ck4);
            this.panel11.Controls.Add(this.ck3);
            this.panel11.Controls.Add(this.ck2);
            this.panel11.Controls.Add(this.ck1);
            this.panel11.Location = new System.Drawing.Point(27, 25);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(907, 38);
            this.panel11.TabIndex = 0;
            // 
            // ck7
            // 
            this.ck7.AutoSize = true;
            this.ck7.Location = new System.Drawing.Point(679, 6);
            this.ck7.Name = "ck7";
            this.ck7.Size = new System.Drawing.Size(68, 24);
            this.ck7.TabIndex = 6;
            this.ck7.Text = "拒答";
            this.ck7.UseVisualStyleBackColor = true;
            // 
            // ck6
            // 
            this.ck6.AutoSize = true;
            this.ck6.Location = new System.Drawing.Point(581, 6);
            this.ck6.Name = "ck6";
            this.ck6.Size = new System.Drawing.Size(68, 24);
            this.ck6.TabIndex = 5;
            this.ck6.Text = "不详";
            this.ck6.UseVisualStyleBackColor = true;
            // 
            // ck5
            // 
            this.ck5.AutoSize = true;
            this.ck5.Location = new System.Drawing.Point(455, 6);
            this.ck5.Name = "ck5";
            this.ck5.Size = new System.Drawing.Size(108, 24);
            this.ck5.TabIndex = 4;
            this.ck5.Text = "以上皆无";
            this.ck5.UseVisualStyleBackColor = true;
            // 
            // ck4
            // 
            this.ck4.AutoSize = true;
            this.ck4.Location = new System.Drawing.Point(343, 6);
            this.ck4.Name = "ck4";
            this.ck4.Size = new System.Drawing.Size(88, 24);
            this.ck4.TabIndex = 3;
            this.ck4.Text = "糖尿病";
            this.ck4.UseVisualStyleBackColor = true;
            // 
            // ck3
            // 
            this.ck3.AutoSize = true;
            this.ck3.Location = new System.Drawing.Point(231, 6);
            this.ck3.Name = "ck3";
            this.ck3.Size = new System.Drawing.Size(88, 24);
            this.ck3.TabIndex = 2;
            this.ck3.Text = "脑卒中";
            this.ck3.UseVisualStyleBackColor = true;
            // 
            // ck2
            // 
            this.ck2.AutoSize = true;
            this.ck2.Location = new System.Drawing.Point(119, 6);
            this.ck2.Name = "ck2";
            this.ck2.Size = new System.Drawing.Size(88, 24);
            this.ck2.TabIndex = 1;
            this.ck2.Text = "冠心病";
            this.ck2.UseVisualStyleBackColor = true;
            // 
            // ck1
            // 
            this.ck1.AutoSize = true;
            this.ck1.Location = new System.Drawing.Point(7, 6);
            this.ck1.Name = "ck1";
            this.ck1.Size = new System.Drawing.Size(88, 24);
            this.ck1.TabIndex = 0;
            this.ck1.Text = "高血压";
            this.ck1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Location = new System.Drawing.Point(71, 426);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1400, 155);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "糖尿病并发症情况";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1150, 117);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ckZb);
            this.panel7.Controls.Add(this.dtpZhubu);
            this.panel7.Location = new System.Drawing.Point(4, 62);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(223, 35);
            this.panel7.TabIndex = 4;
            // 
            // ckZb
            // 
            this.ckZb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckZb.AutoSize = true;
            this.ckZb.Location = new System.Drawing.Point(3, 9);
            this.ckZb.Name = "ckZb";
            this.ckZb.Size = new System.Drawing.Size(108, 24);
            this.ckZb.TabIndex = 55;
            this.ckZb.Text = "足部病变";
            this.ckZb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckZb.UseVisualStyleBackColor = true;
            // 
            // dtpZhubu
            // 
            this.dtpZhubu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpZhubu.CustomFormat = "yyyy";
            this.dtpZhubu.Enabled = false;
            this.dtpZhubu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpZhubu.Location = new System.Drawing.Point(140, 2);
            this.dtpZhubu.Name = "dtpZhubu";
            this.dtpZhubu.ShowUpDown = true;
            this.dtpZhubu.Size = new System.Drawing.Size(80, 30);
            this.dtpZhubu.TabIndex = 56;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ckNxg);
            this.panel6.Controls.Add(this.dtpNaoxueguan);
            this.panel6.Location = new System.Drawing.Point(291, 62);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(223, 35);
            this.panel6.TabIndex = 5;
            // 
            // ckNxg
            // 
            this.ckNxg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckNxg.AutoSize = true;
            this.ckNxg.Location = new System.Drawing.Point(3, 9);
            this.ckNxg.Name = "ckNxg";
            this.ckNxg.Size = new System.Drawing.Size(128, 24);
            this.ckNxg.TabIndex = 0;
            this.ckNxg.Text = "脑血管病变";
            this.ckNxg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckNxg.UseVisualStyleBackColor = true;
            // 
            // dtpNaoxueguan
            // 
            this.dtpNaoxueguan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpNaoxueguan.CustomFormat = "yyyy";
            this.dtpNaoxueguan.Enabled = false;
            this.dtpNaoxueguan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNaoxueguan.Location = new System.Drawing.Point(140, 2);
            this.dtpNaoxueguan.Name = "dtpNaoxueguan";
            this.dtpNaoxueguan.ShowUpDown = true;
            this.dtpNaoxueguan.Size = new System.Drawing.Size(80, 30);
            this.dtpNaoxueguan.TabIndex = 56;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.tbQtIll);
            this.panel3.Controls.Add(this.ckQt);
            this.panel3.Controls.Add(this.dtpOther);
            this.panel3.Location = new System.Drawing.Point(578, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(517, 35);
            this.panel3.TabIndex = 6;
            // 
            // tbQtIll
            // 
            this.tbQtIll.Location = new System.Drawing.Point(123, 3);
            this.tbQtIll.Name = "tbQtIll";
            this.tbQtIll.ReadOnly = true;
            this.tbQtIll.Size = new System.Drawing.Size(279, 30);
            this.tbQtIll.TabIndex = 1;
            // 
            // ckQt
            // 
            this.ckQt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckQt.AutoSize = true;
            this.ckQt.Location = new System.Drawing.Point(3, 9);
            this.ckQt.Name = "ckQt";
            this.ckQt.Size = new System.Drawing.Size(108, 24);
            this.ckQt.TabIndex = 0;
            this.ckQt.Text = "其他病变";
            this.ckQt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckQt.UseVisualStyleBackColor = true;
            // 
            // dtpOther
            // 
            this.dtpOther.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpOther.CustomFormat = "yyyy";
            this.dtpOther.Enabled = false;
            this.dtpOther.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOther.Location = new System.Drawing.Point(408, 3);
            this.dtpOther.Name = "dtpOther";
            this.dtpOther.ShowUpDown = true;
            this.dtpOther.Size = new System.Drawing.Size(80, 30);
            this.dtpOther.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckSz);
            this.panel1.Controls.Add(this.dtpShenzhang);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 49);
            this.panel1.TabIndex = 0;
            // 
            // ckSz
            // 
            this.ckSz.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckSz.AutoSize = true;
            this.ckSz.Location = new System.Drawing.Point(3, 16);
            this.ckSz.Name = "ckSz";
            this.ckSz.Size = new System.Drawing.Size(108, 24);
            this.ckSz.TabIndex = 55;
            this.ckSz.Text = "肾脏病变";
            this.ckSz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckSz.UseVisualStyleBackColor = true;
            // 
            // dtpShenzhang
            // 
            this.dtpShenzhang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpShenzhang.CustomFormat = "yyyy";
            this.dtpShenzhang.Enabled = false;
            this.dtpShenzhang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShenzhang.Location = new System.Drawing.Point(140, 13);
            this.dtpShenzhang.Name = "dtpShenzhang";
            this.dtpShenzhang.ShowUpDown = true;
            this.dtpShenzhang.Size = new System.Drawing.Size(80, 30);
            this.dtpShenzhang.TabIndex = 56;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckSj);
            this.panel2.Controls.Add(this.dtpShengjing);
            this.panel2.Location = new System.Drawing.Point(291, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 49);
            this.panel2.TabIndex = 1;
            // 
            // ckSj
            // 
            this.ckSj.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckSj.AutoSize = true;
            this.ckSj.Location = new System.Drawing.Point(3, 16);
            this.ckSj.Name = "ckSj";
            this.ckSj.Size = new System.Drawing.Size(108, 24);
            this.ckSj.TabIndex = 55;
            this.ckSj.Text = "神经病变";
            this.ckSj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckSj.UseVisualStyleBackColor = true;
            // 
            // dtpShengjing
            // 
            this.dtpShengjing.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpShengjing.CustomFormat = "yyyy";
            this.dtpShengjing.Enabled = false;
            this.dtpShengjing.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShengjing.Location = new System.Drawing.Point(140, 13);
            this.dtpShengjing.Name = "dtpShengjing";
            this.dtpShengjing.ShowUpDown = true;
            this.dtpShengjing.Size = new System.Drawing.Size(80, 30);
            this.dtpShengjing.TabIndex = 56;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ckXz);
            this.panel5.Controls.Add(this.dtpXinzhang);
            this.panel5.Location = new System.Drawing.Point(578, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(223, 49);
            this.panel5.TabIndex = 2;
            // 
            // ckXz
            // 
            this.ckXz.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckXz.AutoSize = true;
            this.ckXz.Location = new System.Drawing.Point(3, 16);
            this.ckXz.Name = "ckXz";
            this.ckXz.Size = new System.Drawing.Size(108, 24);
            this.ckXz.TabIndex = 55;
            this.ckXz.Text = "心脏病变";
            this.ckXz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckXz.UseVisualStyleBackColor = true;
            // 
            // dtpXinzhang
            // 
            this.dtpXinzhang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpXinzhang.CustomFormat = "yyyy";
            this.dtpXinzhang.Enabled = false;
            this.dtpXinzhang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpXinzhang.Location = new System.Drawing.Point(140, 13);
            this.dtpXinzhang.Name = "dtpXinzhang";
            this.dtpXinzhang.ShowUpDown = true;
            this.dtpXinzhang.Size = new System.Drawing.Size(80, 30);
            this.dtpXinzhang.TabIndex = 56;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ckSwm);
            this.panel4.Controls.Add(this.dtpShiwangm);
            this.panel4.Location = new System.Drawing.Point(865, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(223, 49);
            this.panel4.TabIndex = 3;
            // 
            // ckSwm
            // 
            this.ckSwm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckSwm.AutoSize = true;
            this.ckSwm.Location = new System.Drawing.Point(3, 16);
            this.ckSwm.Name = "ckSwm";
            this.ckSwm.Size = new System.Drawing.Size(128, 24);
            this.ckSwm.TabIndex = 55;
            this.ckSwm.Text = "视网膜病变";
            this.ckSwm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckSwm.UseVisualStyleBackColor = true;
            // 
            // dtpShiwangm
            // 
            this.dtpShiwangm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpShiwangm.CustomFormat = "yyyy";
            this.dtpShiwangm.Enabled = false;
            this.dtpShiwangm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShiwangm.Location = new System.Drawing.Point(140, 13);
            this.dtpShiwangm.Name = "dtpShiwangm";
            this.dtpShiwangm.ShowUpDown = true;
            this.dtpShiwangm.Size = new System.Drawing.Size(80, 30);
            this.dtpShiwangm.TabIndex = 56;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.cbEndManage);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.panel10);
            this.groupBox5.Controls.Add(this.dtpStopDate);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(71, 591);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1401, 78);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // cbEndManage
            // 
            this.cbEndManage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndManage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbEndManage.FormattingEnabled = true;
            this.cbEndManage.Location = new System.Drawing.Point(300, 25);
            this.cbEndManage.Name = "cbEndManage";
            this.cbEndManage.Size = new System.Drawing.Size(195, 28);
            this.cbEndManage.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "是否终止管理:";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.rdEndNo);
            this.panel10.Controls.Add(this.rdEndYes);
            this.panel10.Location = new System.Drawing.Point(154, 22);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(122, 31);
            this.panel10.TabIndex = 1;
            // 
            // rdEndNo
            // 
            this.rdEndNo.AutoSize = true;
            this.rdEndNo.Checked = true;
            this.rdEndNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdEndNo.Location = new System.Drawing.Point(69, 4);
            this.rdEndNo.Name = "rdEndNo";
            this.rdEndNo.Size = new System.Drawing.Size(47, 24);
            this.rdEndNo.TabIndex = 11;
            this.rdEndNo.TabStop = true;
            this.rdEndNo.Text = "否";
            this.rdEndNo.UseVisualStyleBackColor = true;
            // 
            // rdEndYes
            // 
            this.rdEndYes.AutoSize = true;
            this.rdEndYes.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdEndYes.Location = new System.Drawing.Point(3, 4);
            this.rdEndYes.Name = "rdEndYes";
            this.rdEndYes.Size = new System.Drawing.Size(47, 24);
            this.rdEndYes.TabIndex = 10;
            this.rdEndYes.Text = "是";
            this.rdEndYes.UseVisualStyleBackColor = true;
            // 
            // dtpStopDate
            // 
            this.dtpStopDate.Location = new System.Drawing.Point(833, 26);
            this.dtpStopDate.Name = "dtpStopDate";
            this.dtpStopDate.Size = new System.Drawing.Size(200, 30);
            this.dtpStopDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(691, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "终止管理日期:";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.panel9);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.panel8);
            this.groupBox6.Controls.Add(this.tbYDS);
            this.groupBox6.Controls.Add(this.tbDiabeteUnit);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.dtpDiabeteDate);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.cbxDietesTypes);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(71, 153);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1401, 117);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(346, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 20);
            this.label8.TabIndex = 67;
            this.label8.Text = "胰岛素用量:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(684, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 20);
            this.label7.TabIndex = 66;
            this.label7.Text = "是否使用口服降糖药:";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.rdNoJYY);
            this.panel9.Controls.Add(this.rdUseJYY);
            this.panel9.Location = new System.Drawing.Point(897, 68);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(148, 30);
            this.panel9.TabIndex = 5;
            // 
            // rdNoJYY
            // 
            this.rdNoJYY.AutoSize = true;
            this.rdNoJYY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdNoJYY.Location = new System.Drawing.Point(74, 2);
            this.rdNoJYY.Name = "rdNoJYY";
            this.rdNoJYY.Size = new System.Drawing.Size(47, 24);
            this.rdNoJYY.TabIndex = 11;
            this.rdNoJYY.TabStop = true;
            this.rdNoJYY.Text = "否";
            this.rdNoJYY.UseVisualStyleBackColor = true;
            // 
            // rdUseJYY
            // 
            this.rdUseJYY.AutoSize = true;
            this.rdUseJYY.Checked = true;
            this.rdUseJYY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdUseJYY.Location = new System.Drawing.Point(8, 2);
            this.rdUseJYY.Name = "rdUseJYY";
            this.rdUseJYY.Size = new System.Drawing.Size(47, 24);
            this.rdUseJYY.TabIndex = 10;
            this.rdUseJYY.TabStop = true;
            this.rdUseJYY.Text = "是";
            this.rdUseJYY.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 64;
            this.label6.Text = "使用胰岛素:";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rdNoYDS);
            this.panel8.Controls.Add(this.rdUseYDS);
            this.panel8.Location = new System.Drawing.Point(130, 68);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(149, 30);
            this.panel8.TabIndex = 3;
            // 
            // rdNoYDS
            // 
            this.rdNoYDS.AutoSize = true;
            this.rdNoYDS.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdNoYDS.Location = new System.Drawing.Point(7, 2);
            this.rdNoYDS.Name = "rdNoYDS";
            this.rdNoYDS.Size = new System.Drawing.Size(47, 24);
            this.rdNoYDS.TabIndex = 11;
            this.rdNoYDS.TabStop = true;
            this.rdNoYDS.Text = "否";
            this.rdNoYDS.UseVisualStyleBackColor = true;
            // 
            // rdUseYDS
            // 
            this.rdUseYDS.AutoSize = true;
            this.rdUseYDS.Checked = true;
            this.rdUseYDS.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdUseYDS.Location = new System.Drawing.Point(94, 2);
            this.rdUseYDS.Name = "rdUseYDS";
            this.rdUseYDS.Size = new System.Drawing.Size(47, 24);
            this.rdUseYDS.TabIndex = 10;
            this.rdUseYDS.TabStop = true;
            this.rdUseYDS.Text = "是";
            this.rdUseYDS.UseVisualStyleBackColor = true;
            // 
            // tbYDS
            // 
            this.tbYDS.Location = new System.Drawing.Point(482, 72);
            this.tbYDS.MaxLength = 20;
            this.tbYDS.Name = "tbYDS";
            this.tbYDS.Size = new System.Drawing.Size(137, 30);
            this.tbYDS.TabIndex = 4;
            // 
            // tbDiabeteUnit
            // 
            this.tbDiabeteUnit.Location = new System.Drawing.Point(897, 20);
            this.tbDiabeteUnit.MaxLength = 20;
            this.tbDiabeteUnit.Name = "tbDiabeteUnit";
            this.tbDiabeteUnit.Size = new System.Drawing.Size(148, 30);
            this.tbDiabeteUnit.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(784, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 58;
            this.label5.Text = "确诊单位:";
            // 
            // dtpDiabeteDate
            // 
            this.dtpDiabeteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDiabeteDate.Location = new System.Drawing.Point(482, 21);
            this.dtpDiabeteDate.Name = "dtpDiabeteDate";
            this.dtpDiabeteDate.Size = new System.Drawing.Size(137, 30);
            this.dtpDiabeteDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 48;
            this.label4.Text = "确诊时间:";
            // 
            // cbxDietesTypes
            // 
            this.cbxDietesTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDietesTypes.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxDietesTypes.FormattingEnabled = true;
            this.cbxDietesTypes.Location = new System.Drawing.Point(134, 22);
            this.cbxDietesTypes.Name = "cbxDietesTypes";
            this.cbxDietesTypes.Size = new System.Drawing.Size(150, 28);
            this.cbxDietesTypes.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "糖尿病类型:";
            // 
            // DiaInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiaInfoForm";
            this.Text = "DiaInfoForm";
            this.Load += new System.EventHandler(this.FrmDiaInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            ChronicDiabetesBaseInfoBLL chronicDiabetesBaseInfoBLL = new ChronicDiabetesBaseInfoBLL();
            if (chronicDiabetesBaseInfoBLL.Exists(this.diabetesBaseInfo.ID))
            {
                chronicDiabetesBaseInfoBLL.Update(this.diabetesBaseInfo);
            }
            else
            {
                chronicDiabetesBaseInfoBLL.Add(this.diabetesBaseInfo);
            }

            return true;
        }

        public void SimpleBinding(ComboBox cb, object src, string member)
        {
            Binding binding = new Binding("SelectedValue", src, member, false, DataSourceUpdateMode.OnValidation) {
                DataSourceNullValue = string.Empty
            };
            cb.DataBindings.Add(binding);
        }

        public void UpdataToModel()
        {
            this.diabetesBaseInfo.Symptom = this.symptom.FinalResult;
            this.diabetesBaseInfo.Insulin = this.useYDS.Choose;
            this.diabetesBaseInfo.InsulinWeight = this.useYDS.Choose_EX;
            this.diabetesBaseInfo.DiabetesTime = new DateTime?(this.dtpDiabeteDate.Value.Date);
            this.diabetesBaseInfo.EndTime = new DateTime?(this.dtpStopDate.Value.Date);
            ChronicDiabetesBaseInfoModel diabetesBaseInfo = this.diabetesBaseInfo;
            this.diabetesBaseInfo.Lesions = string.IsNullOrEmpty(diabetesBaseInfo.RenalLesionsTime + diabetesBaseInfo.NeuropathyTime + diabetesBaseInfo.HeartDiseaseTime + diabetesBaseInfo.RetinopathyTime + diabetesBaseInfo.FootLesionsTime + diabetesBaseInfo.CerebrovascularTime + diabetesBaseInfo.LesionsOtherTime) ? "1" : "2";
            if (this.rdUseJYY.Checked)
            {
                this.diabetesBaseInfo.EnalaprilMelete = "1";
            }
            if (this.rdNoJYY.Checked)
            {
                this.diabetesBaseInfo.EnalaprilMelete = "2";
            }
            if (this.diabetesBaseInfo.EndManage == "2")
            {
                this.diabetesBaseInfo.EndWhy = null;
                this.diabetesBaseInfo.EndTime = null;
            }
        }

        private ChronicDiabetesBaseInfoModel diabetesBaseInfo { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        internal class bingfazheng
        {
            public Action<bool> ckChecked;
            private PropertyInfo proinfo;

            public bingfazheng(CheckBox bx, DateTimePicker dtp, object dataSrc, string pro)
            {
                this.name = bx;
                this.dtpDate = dtp;
                this.dtpDate.MaxDate = DateTime.Now;
                this.DataSrc = dataSrc;
                this.ProperName = pro;
                this.name.CheckedChanged += new EventHandler(this.name_CheckedChanged);
                this.proinfo = dataSrc.GetType().GetProperty(this.ProperName);
                if (this.proinfo == null)
                {
                    throw new Exception("找不到属性:" + this.ProperName);
                }
                object obj2 = this.proinfo.GetValue(dataSrc, null);
                if (obj2 != null)
                {
                    int num;
                    DateTime today = DateTime.Today;
                    if (int.TryParse(obj2.ToString(), out num))
                    {
                        int num2 = num - DateTime.Today.Year;
                        this.dtpDate.Value = today.AddYears(num2);
                        this.name.Checked = true;
                    }
                }
                this.dtpDate.ValueChanged += new EventHandler(this.dtpDate_ValueChanged);
            }

            private void dtpDate_ValueChanged(object sender, EventArgs e)
            {
                this.proinfo.SetValue(this.DataSrc, this.dtpDate.Value.ToString("yyyy"), null);
            }

            private void name_CheckedChanged(object sender, EventArgs e)
            {
                if (this.name.Checked)
                {
                    this.dtpDate.Enabled = true;
                    if (this.proinfo != null)
                    {
                        this.proinfo.SetValue(this.DataSrc, this.dtpDate.Value.ToString("yyyy"), null);
                    }
                }
                else
                {
                    if (this.proinfo != null)
                    {
                        this.proinfo.SetValue(this.DataSrc, string.Empty, null);
                    }
                    this.dtpDate.Value = DateTime.Today;
                    this.dtpDate.Enabled = false;
                }
                if (this.ckChecked != null)
                {
                    this.ckChecked(this.name.Checked);
                }
            }

            public object DataSrc { get; set; }

            public DateTimePicker dtpDate { get; set; }

            public CheckBox name { get; set; }

            public string ProperName { get; set; }
           
        }

        private void cklSymptom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

