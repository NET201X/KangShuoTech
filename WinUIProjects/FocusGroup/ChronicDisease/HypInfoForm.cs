
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class HypInfoForm : Form, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private ComboBox cbxFromWhere;
        private ComboBox cbxManagerGroup;
        private ComboBox cbxStopResult;
        private CheckBox ck1;
        private CheckBox ck2;
        private CheckBox ck3;
        private CheckBox ck4;
        private CheckBox ck5;
        private CheckBox ck6;
        private CheckBox ck7;
        private CheckedListBox cklSymptom;
        private CheckedListBox cklTogetherSymptom;
        private CheckBox ckxStopManager;
        private IContainer components;
        private DateTimePicker dtpStopDate;
        private ManyCheckboxs<ChronicHypertensionBaseInfoModel> famHistory;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label35;
        private Label label4;
        private List<ItemDictonaryModel<string>> mgrGroup;
        private Panel panel1;
        private Panel panel2;
        private RadioButton rdNo;
        private RadioButton rdYes;
        private List<ItemDictonaryModel<string>> stopManager;
        private CMoreChange symptom;
        private CMoreChange together;
        private List<ItemDictonaryModel<string>> whereFrom;

        public HypInfoForm()
        {
            this.InitializeComponent();
            this.InitComobox();
            this.EveryThingIsOk = false;
        }

        private void BindingModel()
        {
            this.hpyBaseInfo = new ChronicHypertensionBaseInfoBLL().GetModel(this.Model.IDCardNo);

            if (this.hpyBaseInfo == null)
            {
                ChronicHypertensionBaseInfoModel cd_Hypertension_baseinfo = new ChronicHypertensionBaseInfoModel {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID,
                    Hypotensor = "1"
                };
                this.hpyBaseInfo = cd_Hypertension_baseinfo;
                this.hpyBaseInfo.ManagementGroup = "1";
                this.hpyBaseInfo.CaseOurce = "1";
                this.hpyBaseInfo.CreateUnit = new decimal?(ConfigHelper.GetNodeDec("orgCode"));
                this.hpyBaseInfo.CreateoBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.hpyBaseInfo.CreatedDate = new DateTime?(DateTime.Today);
            }
            else
            {
                this.hpyBaseInfo.LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.hpyBaseInfo.LastUpdateDate = new DateTime?(DateTime.Today);
            }
            this.hpyBaseInfo.CurrentUnit = new decimal?(ConfigHelper.GetNodeDec("orgCode"));
            this.SimpleBinding(this.cbxManagerGroup, this.hpyBaseInfo, "ManagementGroup");
            this.SimpleBinding(this.cbxFromWhere, this.hpyBaseInfo, "CaseOurce");
            this.SimpleBinding(this.cbxStopResult, this.hpyBaseInfo, "TerminateExcuse");
            this.famHistory = new ManyCheckboxs<ChronicHypertensionBaseInfoModel>(this.hpyBaseInfo);
            this.famHistory.AddCk(new LoneCheckbox[] { new LoneCheckbox(this.ck1), new LoneCheckbox(this.ck2), new LoneCheckbox(this.ck3), new LoneCheckbox(this.ck4), new LoneCheckbox(this.ck5, true), new LoneCheckbox(this.ck6, true), new LoneCheckbox(this.ck7, true) });
            this.famHistory.BindingProperty("FatherHistory", "");
            CMoreChange change = new CMoreChange {
                Name = "目前症状",
                MoreChange = this.cklSymptom,
                Unusual = "无症状"
            };
            this.symptom = change;
            this.symptom.TransInfo(this.hpyBaseInfo.Symptom, "");
            CMoreChange change2 = new CMoreChange {
                Name = "并发症",
                MoreChange = this.cklTogetherSymptom,
                Unusual = "无任何并发症"
            };
            this.together = change2;
            this.together.TransInfo(this.hpyBaseInfo.HypertensionComplication, "");
            if (this.hpyBaseInfo.TerminateManagemen == "1")
            {
                this.ckxStopManager.Checked = true;
                this.cbxStopResult.Enabled = true;
            }
            else if (this.hpyBaseInfo.TerminateManagemen == "2")
            {
                this.cbxStopResult.Enabled = false;
                this.dtpStopDate.Enabled = false;
            }
            if (this.hpyBaseInfo.TerminateTime.HasValue)
            {
                this.dtpStopDate.Value = this.hpyBaseInfo.TerminateTime.Value;
            }
            if (this.hpyBaseInfo.Hypotensor == "1")
            {
                this.rdYes.Checked = true;
            }
            else
            {
                this.rdNo.Checked = true;
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        private void ckxStopManager_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckxStopManager.Checked)
            {
                this.cbxStopResult.Enabled = true;
                this.dtpStopDate.Enabled = true;
                this.hpyBaseInfo.TerminateManagemen = "1";
            }
            else
            {
                this.hpyBaseInfo.TerminateManagemen = "2";
                this.cbxStopResult.SelectedIndex = 0;
                this.cbxStopResult.Enabled = false;
                this.dtpStopDate.Value = DateTime.Today;
                this.dtpStopDate.Enabled = false;
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

        private void FrmHypInfo_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void InitComobox()
        {
            this.mgrGroup = new List<ItemDictonaryModel<string>>();
            this.mgrGroup.Add(new ItemDictonaryModel<string>("重点组", "1"));
            this.mgrGroup.Add(new ItemDictonaryModel<string>("好转组", "2"));
            this.mgrGroup.Add(new ItemDictonaryModel<string>("稳定组", "3"));
            this.cbxManagerGroup.DisplayMember = "DISPLAYMEMBER";
            this.cbxManagerGroup.ValueMember = "VALUEMEMBER";
            this.cbxManagerGroup.DataSource = this.mgrGroup;
            this.whereFrom = new List<ItemDictonaryModel<string>>();
            this.whereFrom.Add(new ItemDictonaryModel<string>("健康档案", "1"));
            this.whereFrom.Add(new ItemDictonaryModel<string>("首诊测压", "2"));
            this.whereFrom.Add(new ItemDictonaryModel<string>("社区门诊", "3"));
            this.cbxFromWhere.DisplayMember = "DISPLAYMEMBER";
            this.cbxFromWhere.ValueMember = "VALUEMEMBER";
            this.cbxFromWhere.DataSource = this.whereFrom;
            this.stopManager = new List<ItemDictonaryModel<string>>();
            this.stopManager.Add(new ItemDictonaryModel<string>("死亡", "1"));
            this.stopManager.Add(new ItemDictonaryModel<string>("迁出", "2"));
            this.stopManager.Add(new ItemDictonaryModel<string>("失访", "3"));
            this.stopManager.Add(new ItemDictonaryModel<string>("拒绝", "4"));
            this.cbxStopResult.DisplayMember = "DISPLAYMEMBER";
            this.cbxStopResult.ValueMember = "VALUEMEMBER";
            this.cbxStopResult.DataSource = this.stopManager;
        }

        public void InitEveryThing()
        {
            this.BindingModel();
            MustChoose();
            this.EveryThingIsOk = true;
        }
        //private void MustChoose() //必选项设置
        //{
        //    DataTable HyperInfoDt = new ChronicHypertensionBaseInfoBLL().GetList("IDCardNo ='" + Model.IDCardNo + "'").Tables[0];
        //    bool flag = (HyperInfoDt.Rows.Count > 0) ? true : false;
         
        //    if (File.Exists(Application.StartupPath + "\\requiredHyper.xml"))
        //    {
        //        DataSet dsrequire = new DataSet();
        //        dsrequire.ReadXml(Application.StartupPath + "\\requiredHyper.xml");
        //        DataTable dt = dsrequire.Tables[0];
        //        foreach (DataRow item in dt.Rows)
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1" && item["COMMENT"].ToString() == "基本信息，家族史")
        //            {
        //                if (flag)
        //                {
        //                    DataRow row = HyperInfoDt.Rows[0];
        //                    if (string.IsNullOrEmpty(row["FatherHistory"].ToString()))
        //                    {
        //                        this.groupBox3.Text = "*家族史";
        //                        this.groupBox3.ForeColor = System.Drawing.Color.Red;
        //                    }
        //                    else
        //                    {
        //                        this.groupBox3.Text = "家族史";
        //                        this.groupBox3.ForeColor = System.Drawing.Color.Black;
        //                    }
        //                    break;
        //                }
        //                else
        //                {
        //                    this.groupBox3.Text = "*家族史";
        //                    this.groupBox3.ForeColor = System.Drawing.Color.Red;
        //                }

        //            }
        //        }
        //        foreach (DataRow item in dt.Rows)
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1" && item["COMMENT"].ToString() == "基本信息，目前症状")
        //            {
        //                if (flag)
        //                {
        //                    DataRow row = HyperInfoDt.Rows[0];
        //                    if (string.IsNullOrEmpty(row["Symptom"].ToString()))
        //                    {
        //                        this.groupBox2.Text = "*目前症状";
        //                        this.groupBox2.ForeColor = System.Drawing.Color.Red;
        //                    }
        //                    else
        //                    {
        //                        this.groupBox2.Text = "目前症状";
        //                        this.groupBox2.ForeColor = System.Drawing.Color.Black;
        //                    }
        //                    break;
        //                }
        //                else
        //                {
        //                    this.groupBox2.Text = "*目前症状";
        //                    this.groupBox2.ForeColor = System.Drawing.Color.Red;
        //                }
        //            }
        //        }
        //        foreach (DataRow item in dt.Rows)
        //        {
        //            if (item["ISREQUIRED"].ToString() == "1" && item["COMMENT"].ToString() == "基本信息，是否使用降压药")
        //            {
        //                if (flag)
        //                {
        //                    DataRow row = HyperInfoDt.Rows[0];
        //                    if (string.IsNullOrEmpty(row["Hypotensor"].ToString()))
        //                    {
        //                        this.label3.Text = "*是否使用降压药:";
        //                        this.label3.ForeColor = System.Drawing.Color.Red;
        //                    }
        //                    else
        //                    {
        //                        this.label3.Text = "是否使用降压药:";
        //                        this.label3.ForeColor = System.Drawing.Color.Black;
        //                    }
        //                    break;
        //                }
        //                else
        //                {
        //                    this.label3.Text = "*是否使用降压药:";
        //                    this.label3.ForeColor = System.Drawing.Color.Red;
        //                }
        //            }
        //        }

        //    }
        //}
        private void MustChoose()
        {
            DataSet dsrequire = new DataSet();
            dsrequire = new RequireBLL().GetList("TabName = '高血压随访' and Comment = '高血压基本信息' ");
            DataTable dt = dsrequire.Tables[0];
            if (this.hpyBaseInfo==null)
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
                            case "目前症状":
                                this.groupBox2.Text = "*目前症状";
                                this.groupBox2.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "是否使用降压药":
                                this.label3.Text = "*是否使用降压药:";
                                this.label3.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "管理组别":
                                this.label35.Text = "*管理组别:";
                                this.label35.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "病历来源":
                                this.label1.Text = "*病历来源:";
                                this.label1.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "高血压并发症情况":
                                this.groupBox4.Text = "*高血压并发症情况";
                                this.groupBox4.ForeColor = System.Drawing.Color.Red;
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
                    switch (item["ChinName"].ToString())
                    {
                        case "家族史":
                            if (string.IsNullOrEmpty(this.hpyBaseInfo.FatherHistory))
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
                        case "目前症状":
                            if (string.IsNullOrEmpty(this.hpyBaseInfo.Symptom))
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
                        case "是否使用降压药":
                            if (string.IsNullOrEmpty(this.hpyBaseInfo.Hypotensor))
                            {
                                this.label3.Text = "*是否使用降压药:";
                                this.label3.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label3.Text = "是否使用降压药:";
                                this.label3.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "管理组别":
                            if (string.IsNullOrEmpty(this.hpyBaseInfo.ManagementGroup))
                            {
                                this.label35.Text = "*管理组别:";
                                this.label35.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label35.Text = "管理组别:";
                                this.label35.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "病历来源":
                            if (string.IsNullOrEmpty(this.hpyBaseInfo.CaseOurce))
                            {
                                this.label1.Text = "*病历来源:";
                                this.label1.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label1.Text = "病历来源:";
                                this.label1.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "高血压并发症情况":
                            if (string.IsNullOrEmpty(this.hpyBaseInfo.HypertensionComplication))
                            {
                                this.groupBox4.Text = "*高血压并发症情况";
                                this.groupBox4.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.groupBox4.Text = "高血压并发症情况";
                                this.groupBox4.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        default: break;
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
            this.ckxStopManager = new System.Windows.Forms.CheckBox();
            this.cbxStopResult = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cklSymptom = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ck7 = new System.Windows.Forms.CheckBox();
            this.ck6 = new System.Windows.Forms.CheckBox();
            this.ck5 = new System.Windows.Forms.CheckBox();
            this.ck4 = new System.Windows.Forms.CheckBox();
            this.ck3 = new System.Windows.Forms.CheckBox();
            this.ck2 = new System.Windows.Forms.CheckBox();
            this.ck1 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cklTogetherSymptom = new System.Windows.Forms.CheckedListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.rdYes = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStopDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxManagerGroup
            // 
            this.cbxManagerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxManagerGroup.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxManagerGroup.FormattingEnabled = true;
            this.cbxManagerGroup.Location = new System.Drawing.Point(108, 16);
            this.cbxManagerGroup.Name = "cbxManagerGroup";
            this.cbxManagerGroup.Size = new System.Drawing.Size(150, 28);
            this.cbxManagerGroup.TabIndex = 45;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 19);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(99, 20);
            this.label35.TabIndex = 44;
            this.label35.Text = "管理组别:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbxFromWhere);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxManagerGroup);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Location = new System.Drawing.Point(20, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1500, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbxFromWhere
            // 
            this.cbxFromWhere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFromWhere.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxFromWhere.FormattingEnabled = true;
            this.cbxFromWhere.Location = new System.Drawing.Point(432, 16);
            this.cbxFromWhere.Name = "cbxFromWhere";
            this.cbxFromWhere.Size = new System.Drawing.Size(150, 28);
            this.cbxFromWhere.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "病历来源:";
            // 
            // ckxStopManager
            // 
            this.ckxStopManager.AutoSize = true;
            this.ckxStopManager.Location = new System.Drawing.Point(57, 132);
            this.ckxStopManager.Name = "ckxStopManager";
            this.ckxStopManager.Size = new System.Drawing.Size(108, 24);
            this.ckxStopManager.TabIndex = 2;
            this.ckxStopManager.Text = "终止管理";
            this.ckxStopManager.UseVisualStyleBackColor = true;
            this.ckxStopManager.CheckedChanged += new System.EventHandler(this.ckxStopManager_CheckedChanged);
            // 
            // cbxStopResult
            // 
            this.cbxStopResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStopResult.Enabled = false;
            this.cbxStopResult.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxStopResult.FormattingEnabled = true;
            this.cbxStopResult.Location = new System.Drawing.Point(250, 130);
            this.cbxStopResult.Name = "cbxStopResult";
            this.cbxStopResult.Size = new System.Drawing.Size(150, 28);
            this.cbxStopResult.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cklSymptom);
            this.groupBox2.Location = new System.Drawing.Point(26, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(735, 232);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目前症状";
            // 
            // cklSymptom
            // 
            this.cklSymptom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cklSymptom.CheckOnClick = true;
            this.cklSymptom.ColumnWidth = 200;
            this.cklSymptom.FormattingEnabled = true;
            this.cklSymptom.Items.AddRange(new object[] {
            "无症状",
            "头痛头晕",
            "恶心呕吐",
            "眼花耳鸣",
            "呼吸困难",
            "心悸胸闷",
            "鼻衄出血不止",
            "四肢发麻",
            "下肢水肿",
            "其他症状"});
            this.cklSymptom.Location = new System.Drawing.Point(9, 48);
            this.cklSymptom.MultiColumn = true;
            this.cklSymptom.Name = "cklSymptom";
            this.cklSymptom.Size = new System.Drawing.Size(720, 154);
            this.cklSymptom.TabIndex = 89;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Location = new System.Drawing.Point(23, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1497, 68);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "家族史";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ck7);
            this.panel2.Controls.Add(this.ck6);
            this.panel2.Controls.Add(this.ck5);
            this.panel2.Controls.Add(this.ck4);
            this.panel2.Controls.Add(this.ck3);
            this.panel2.Controls.Add(this.ck2);
            this.panel2.Controls.Add(this.ck1);
            this.panel2.Location = new System.Drawing.Point(9, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(907, 40);
            this.panel2.TabIndex = 0;
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
            this.groupBox4.Controls.Add(this.cklTogetherSymptom);
            this.groupBox4.Location = new System.Drawing.Point(775, 164);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(745, 232);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "高血压并发症情况";
            // 
            // cklTogetherSymptom
            // 
            this.cklTogetherSymptom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cklTogetherSymptom.CheckOnClick = true;
            this.cklTogetherSymptom.ColumnWidth = 250;
            this.cklTogetherSymptom.FormattingEnabled = true;
            this.cklTogetherSymptom.Items.AddRange(new object[] {
            "无任何并发症",
            "缺血性卒中",
            "脑出血",
            "短暂性脑缺血发作（TIA）",
            "心肌梗死",
            "心绞痛",
            "充血性心力衰竭",
            "高血压肾病 ",
            "肾功能衰竭",
            "视网膜出血或渗出",
            "视乳头水肿",
            "其他并发症"});
            this.cklTogetherSymptom.Location = new System.Drawing.Point(9, 48);
            this.cklTogetherSymptom.MultiColumn = true;
            this.cklTogetherSymptom.Name = "cklTogetherSymptom";
            this.cklTogetherSymptom.Size = new System.Drawing.Size(728, 154);
            this.cklTogetherSymptom.TabIndex = 91;
            this.cklTogetherSymptom.SelectedIndexChanged += new System.EventHandler(this.cklTogetherSymptom_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.dtpStopDate);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.cbxStopResult);
            this.groupBox5.Controls.Add(this.ckxStopManager);
            this.groupBox5.Location = new System.Drawing.Point(23, 399);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1497, 260);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 93;
            this.label4.Text = "理由:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdNo);
            this.panel1.Controls.Add(this.rdYes);
            this.panel1.Location = new System.Drawing.Point(172, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 34);
            this.panel1.TabIndex = 1;
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.Location = new System.Drawing.Point(69, 5);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(47, 24);
            this.rdNo.TabIndex = 1;
            this.rdNo.TabStop = true;
            this.rdNo.Text = "否";
            this.rdNo.UseVisualStyleBackColor = true;
            // 
            // rdYes
            // 
            this.rdYes.AutoSize = true;
            this.rdYes.Location = new System.Drawing.Point(3, 5);
            this.rdYes.Name = "rdYes";
            this.rdYes.Size = new System.Drawing.Size(47, 24);
            this.rdYes.TabIndex = 0;
            this.rdYes.TabStop = true;
            this.rdYes.Text = "是";
            this.rdYes.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "是否使用降压药:";
            // 
            // dtpStopDate
            // 
            this.dtpStopDate.Location = new System.Drawing.Point(655, 129);
            this.dtpStopDate.Name = "dtpStopDate";
            this.dtpStopDate.Size = new System.Drawing.Size(200, 30);
            this.dtpStopDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(512, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "终止管理日期:";
            // 
            // HypInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HypInfoForm";
            this.Text = "HypInfoForm";
            this.Load += new System.EventHandler(this.FrmHypInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            ChronicHypertensionBaseInfoBLL cd_Hypertension_baseinfo = new ChronicHypertensionBaseInfoBLL();
            if (cd_Hypertension_baseinfo.Exists(this.hpyBaseInfo.ID))
            {
                cd_Hypertension_baseinfo.Update(this.hpyBaseInfo);
            }
            else
            {
                cd_Hypertension_baseinfo.Add(this.hpyBaseInfo);
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
            this.hpyBaseInfo.TerminateTime = new DateTime?(this.dtpStopDate.Value.Date);
            this.hpyBaseInfo.Symptom = this.symptom.FinalResult;
            this.hpyBaseInfo.HypertensionComplication = this.together.FinalResult;
            if (!(this.hpyBaseInfo.TerminateManagemen == "1") && (this.hpyBaseInfo.TerminateManagemen == "2"))
            {
                this.hpyBaseInfo.TerminateExcuse = null;
                this.hpyBaseInfo.TerminateTime = null;
            }
            if (this.rdYes.Checked)
            {
                this.hpyBaseInfo.Hypotensor = "1";
            }
            if (this.rdNo.Checked)
            {
                this.hpyBaseInfo.Hypotensor = "2";
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        private ChronicHypertensionBaseInfoModel hpyBaseInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        private void cklTogetherSymptom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

