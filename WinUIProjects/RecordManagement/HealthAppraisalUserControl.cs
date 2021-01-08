using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace RecordManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;

    using System.Windows.Forms;
    using System.Data;
    using System.IO;
    using KangShuoTech.Utilities.Common;
    using System.Text.RegularExpressions;

    public class HealthAppraisalUserControl : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private CheckBox chex;
        private CheckBox chgunjiu;
        private CheckBox chgunSmoke;
        private CheckBox chjyfc;
        private CheckBox chjyzz;
        private CheckBox ckMxb;
        private CheckBox ckxOther;
        private CheckBox ckxWeight;
        private CheckBox ckxYimiao;
        private IContainer components;
        private FangYiUserControl fangYi1;
        private FangYiUserControl fangYi2;
        private FangYiUserControl fangYi3;
        private List<FangYiUserControl> fangyis;
        private GroupBox groupBox36;
        private GroupBox groupBox37;
        private GroupBox groupBox38;
        private List<CheckBox> jkzd = new List<CheckBox>();
        private Label label107;
        private Label label108;
        private Label label109;
        private Label label110;
        private Label label111;
        private Label label112;
        private Label label114;
        private Label label237;
        private Label labl;
        private RadioButton radtjwyc;
        private RadioButton radtjyyc;
        private TextBox txtjtz;
        private TextBox txtjyjzym;
        private TextBox txttjyc1;
        private TextBox txttjyc2;
        private TextBox txttjyc3;
        private TextBox txttjyc4;
        private TextBox txtwxysqt;
        private CheckBox ckdqsf;
        private List<CheckBox> wxys = new List<CheckBox>();
        private List<InputRangeDec> inputRanges = new List<InputRangeDec>();
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr>();
        private CheckBox chys;
        private SimpleBindingManager<RecordsAssessmentGuideModel> bindingManager;
        private string strex1;
        private string strex2;
        private string strex3;
        private string strex4;
        private ConvertDBCAndSBC common = new ConvertDBCAndSBC();
        string community = ConfigHelper.GetSetNode("community");
        string area = ConfigHelper.GetSetNode("area");
        private DataSet dsRequire;
        private CheckBox ckjyw;
        private Label label1;
        private TextBox txtjyw;
        private TextBox txttjyc6;
        private Label label3;
        private TextBox txttjyc5;
        private Label label2;
        private HealthAssessment healthAssessment = new HealthAssessment();
        public HealthAppraisalUserControl()
        {
            this.InitializeComponent();
            this.jkzd.Add(this.ckMxb);
            this.jkzd.Add(this.chjyfc);
            this.jkzd.Add(this.chjyzz);
            this.jkzd.Add(this.ckdqsf);
            this.wxys.Add(this.chgunSmoke);
            this.wxys.Add(this.chgunjiu);
            this.wxys.Add(this.chys);
            this.wxys.Add(this.chex);
            this.wxys.Add(this.ckxWeight);
            this.wxys.Add(this.ckxYimiao);
            this.wxys.Add(this.ckxOther);
            this.wxys.Add(this.ckjyw);
            this.EveryThingIsOk = false;
            if (area.Equals("威海"))
            {
                this.ckjyw.Visible = true;
                this.txtjyw.Visible = true;
                this.label1.Visible = true;
            }
            if (community.Equals("聊城东昌府区"))
            {
                this.label1.Visible = true;
                this.label2.Visible = true;
                this.txttjyc5.Visible = true;
                this.txttjyc6.Visible = true;
            }
        }

        private void bd_Parse(object sender, ConvertEventArgs e)
        {
            decimal num;
            if (!decimal.TryParse(e.Value.ToString(), out num))
            {
                e.Value = null;
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            if (this.fangyis.Count<FangYiUserControl>(c => c.ErrorInput) > 0)
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

        public void InitEveryThing()
        {
            dsRequire = new RequireBLL().GetList("TabName = '健康体检' and Comment = '健康评价' ");
            this.InoculationHistory = new RecordsInoculationHistoryBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, PhysicalInfoFactory.ID));
            this.AssessmentGuides = new RecordsAssessmentGuideBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            this.ArchiveCard = new RecordsCardBLL().GetModel(this.Model.IDCardNo);
            if (this.AssessmentGuides == null)
            {
                this.AssessmentGuides = new RecordsAssessmentGuideModel();
                this.AssessmentGuides.DangerControl = "";
            }
            if (this.ArchiveCard == null)
            {
                this.ArchiveCard = new RecordsCardModel();
                GlbTools.M1_TO_M2<RecordsBaseInfoModel, RecordsCardModel>(this.Model, this.ArchiveCard);
            }
            //新增体检时，默认项设置
            if (PhysicalInfoFactory.falgID == 0)
            {
                this.PresetValue();
            }
            this.bindingManager = new SimpleBindingManager<RecordsAssessmentGuideModel>(this.inputRanges, this.inputrange_str, this.AssessmentGuides);
            new CHealthGuid { Name = "减体重", Check = this.ckxWeight, Content = this.txtjtz }.eventBinding();
            new CHealthGuid { Name = "建议接种疫苗", Check = this.ckxYimiao, Content = this.txtjyjzym }.eventBinding();
            new CHealthGuid { Name = "其他", Check = this.ckxOther, Content = this.txtwxysqt }.eventBinding();
            this.fangyis = new List<FangYiUserControl> { this.fangYi1, this.fangYi2, this.fangYi3 };
            for (int i = 0; i < this.InoculationHistory.Count; i++)
            {
                this.fangyis[i].Source = this.InoculationHistory[i];
            }
            SetHealthEx();//健康异常设置
            SetDangerous();//危险因素控制
            MustChoose();
            this.EveryThingIsOk = true;
        }
        private void SetHealthEx()
        {
            if (PhysicalInfoFactory.falgID == 0)
            {
                AssessmentGuides.Exception1 = "";
                AssessmentGuides.Exception2 = "";
                AssessmentGuides.Exception3 = "";
                AssessmentGuides.Exception4 = "";
                AssessmentGuides.IsNormal = "1";
            }
            healthAssessment.Model = this.Model;
            this.AssessmentGuides = healthAssessment.SetHealthEx(this.AssessmentGuides);

            if (!string.IsNullOrEmpty(this.AssessmentGuides.IsNormal))
            {
                if (this.AssessmentGuides.IsNormal == "1")
                {
                    this.radtjwyc.Checked = true;
                }
                else if (this.AssessmentGuides.IsNormal == "2")
                {
                    this.radtjyyc.Checked = true;
                }
            }
            else
            {
                this.radtjwyc.Checked = true;
            }

            this.txttjyc1.Text = this.AssessmentGuides.Exception1;
            this.txttjyc2.Text = this.AssessmentGuides.Exception2;
            this.txttjyc3.Text = this.AssessmentGuides.Exception3;
            this.txttjyc4.Text = this.AssessmentGuides.Exception4;
            this.txttjyc5.Text = this.AssessmentGuides.Exception5;
            this.txttjyc6.Text = this.AssessmentGuides.Exception6;
        }

        /// <summary>
        /// 健康指导
        /// </summary>
        private void SetDangerous()
        {
            this.AssessmentGuides = healthAssessment.SetDangerous(this.AssessmentGuides);

            //勾选checkedbox
            if (!string.IsNullOrEmpty(this.AssessmentGuides.DangerControl))
            {
                for (int j = 0; j < this.wxys.Count; j++) //清空栏位重新赋值
                {
                    this.wxys[j].Checked = false;
                }
                string dANGERCONTROL = this.AssessmentGuides.DangerControl;
                char[] chArray2 = new char[] { ',' };

                foreach (string str4 in dANGERCONTROL.Split(chArray2))
                {
                    int num3;
                    if (int.TryParse(str4, out num3))
                    {
                        this.wxys[num3 - 1].Checked = true;
                    }
                }
            }
            if (!string.IsNullOrEmpty(this.AssessmentGuides.Arm))
            {
                this.txtjtz.Text = this.AssessmentGuides.Arm.ToString();
            }
            if (!string.IsNullOrEmpty(this.AssessmentGuides.WaistlineArm))
            {
                this.txtjyw.Text = this.AssessmentGuides.WaistlineArm.ToString();
            }
            if (!string.IsNullOrEmpty(this.AssessmentGuides.Other))
            {
                this.txtwxysqt.Text = this.AssessmentGuides.Other;
            }
            if (!string.IsNullOrEmpty(this.AssessmentGuides.VaccineAdvice))
            {
                this.txtjyjzym.Text = this.AssessmentGuides.VaccineAdvice;
            }
            if (!string.IsNullOrEmpty(this.AssessmentGuides.HealthGuide))
            {
                for (int j = 0; j < this.jkzd.Count; j++) //清空栏位重新赋值
                {
                    this.jkzd[j].Checked = false;
                }
                string hEALTHZHIDAO = this.AssessmentGuides.HealthGuide;
                char[] separator = new char[] { ',' };
                foreach (string str2 in hEALTHZHIDAO.Split(separator))
                {
                    int num2;
                    if (int.TryParse(str2, out num2))
                    {
                        this.jkzd[num2 - 1].Checked = true;
                    }
                }
            }
        }
        private void PresetValue()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = " IsSetValue='是' or IsSetValue='预设上次体检' ";
            DataTable dt = dv.ToTable();
            RecordsCustomerBaseInfoModel CustomerBaseInfos = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.Model.IDCardNo);//获取最新一笔体检数据
            List<RecordsInoculationHistoryModel> InoculationHistoryTemp = new List<RecordsInoculationHistoryModel>();
            if (CustomerBaseInfos != null)
            {
                InoculationHistoryTemp = new RecordsInoculationHistoryBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, CustomerBaseInfos.ID));
            }

            foreach (DataRow item in dt.Rows)
            {
                switch (item["ChinName"].ToString())
                {
                    case "非免疫预防接种史":
                        if (item["IsSetValue"].ToString() == "预设上次体检")
                        {
                            this.InoculationHistory = InoculationHistoryTemp;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        private void MustChoose()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = "IsRequired='1' ";
            DataTable dt = dv.ToTable();
            RecordsAssessmentGuideModel AssessmentGuide = new RecordsAssessmentGuideBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (AssessmentGuide == null) AssessmentGuide = new RecordsAssessmentGuideModel();
            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "是否正常1:体检无异常2:有异常":
                            if (string.IsNullOrEmpty(Convert.ToString(AssessmentGuide.IsNormal)))
                            {
                                this.groupBox37.Text = "*健康评价";
                                this.groupBox37.ForeColor = System.Drawing.Color.Red;
                                this.radtjwyc.ForeColor = System.Drawing.Color.Black;
                                this.radtjyyc.ForeColor = System.Drawing.Color.Black;
                                this.label109.ForeColor = System.Drawing.Color.Black;
                                this.label110.ForeColor = System.Drawing.Color.Black;
                                this.label111.ForeColor = System.Drawing.Color.Black;
                                this.label237.ForeColor = System.Drawing.Color.Black;

                            }
                            else
                            {
                                this.groupBox37.Text = "健康评价";
                                this.groupBox37.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "健康指导":
                            if (string.IsNullOrEmpty(Convert.ToString(AssessmentGuide.HealthGuide)))
                            {
                                this.groupBox38.Text = "*健康指导";
                                this.groupBox38.ForeColor = System.Drawing.Color.Red;
                                this.ckMxb.ForeColor = System.Drawing.Color.Black;
                                this.chjyfc.ForeColor = System.Drawing.Color.Black;
                                this.chjyzz.ForeColor = System.Drawing.Color.Black;
                                this.ckdqsf.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.groupBox38.Text = "健康指导";
                                this.groupBox38.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "危险因素控制":
                            if (string.IsNullOrEmpty(Convert.ToString(AssessmentGuide.DangerControl)))
                            {
                                this.label112.Text = "*危险因素控制";
                                this.label112.ForeColor = System.Drawing.Color.Red;
                                this.chgunSmoke.ForeColor = System.Drawing.Color.Black;
                                this.chgunjiu.ForeColor = System.Drawing.Color.Black;
                                this.chys.ForeColor = System.Drawing.Color.Black;
                                this.chex.ForeColor = System.Drawing.Color.Black;
                                this.ckxWeight.ForeColor = System.Drawing.Color.Black;
                                this.label114.ForeColor = System.Drawing.Color.Black;
                                this.ckxYimiao.ForeColor = System.Drawing.Color.Black;
                                this.ckxOther.ForeColor = System.Drawing.Color.Black;
                                this.ckjyw.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.label112.Text = "危险因素控制";
                                this.label112.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        default: break;
                    }
                }
            }
            List<RecordsInoculationHistoryModel> InoculationHistorys = new RecordsInoculationHistoryBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo, PhysicalInfoFactory.ID));
            if (InoculationHistorys.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item["Isrequired"].ToString() == "1")
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "非免疫预防接种史":
                                this.groupBox36.Text = "非免疫预防接种史";
                                this.groupBox36.ForeColor = System.Drawing.Color.Black;
                                this.labl.ForeColor = System.Drawing.Color.Black;
                                this.label107.ForeColor = System.Drawing.Color.Black;
                                this.label108.ForeColor = System.Drawing.Color.Black;
                                break;
                            default: break;
                        }
                    }
                }
            }
            else //非免疫预防接种史无值
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item["Isrequired"].ToString() == "1")
                    {
                        switch (item["ChinName"].ToString())
                        {
                            case "非免疫预防接种史":
                                this.groupBox36.Text = "*非免疫预防接种史";
                                this.groupBox36.ForeColor = System.Drawing.Color.Red;
                                this.labl.ForeColor = System.Drawing.Color.Black;
                                this.label107.ForeColor = System.Drawing.Color.Black;
                                this.label108.ForeColor = System.Drawing.Color.Black;
                                break;
                            default: break;
                        }
                    }
                }
            }
        }
        private void InitializeComponent()
        {
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.ckjyw = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtjyw = new System.Windows.Forms.TextBox();
            this.ckMxb = new System.Windows.Forms.CheckBox();
            this.ckxOther = new System.Windows.Forms.CheckBox();
            this.ckxYimiao = new System.Windows.Forms.CheckBox();
            this.ckxWeight = new System.Windows.Forms.CheckBox();
            this.txtwxysqt = new System.Windows.Forms.TextBox();
            this.txtjyjzym = new System.Windows.Forms.TextBox();
            this.label114 = new System.Windows.Forms.Label();
            this.txtjtz = new System.Windows.Forms.TextBox();
            this.chex = new System.Windows.Forms.CheckBox();
            this.chys = new System.Windows.Forms.CheckBox();
            this.chgunjiu = new System.Windows.Forms.CheckBox();
            this.chgunSmoke = new System.Windows.Forms.CheckBox();
            this.label112 = new System.Windows.Forms.Label();
            this.ckdqsf = new System.Windows.Forms.CheckBox();
            this.chjyzz = new System.Windows.Forms.CheckBox();
            this.chjyfc = new System.Windows.Forms.CheckBox();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.txttjyc6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttjyc5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txttjyc4 = new System.Windows.Forms.TextBox();
            this.label237 = new System.Windows.Forms.Label();
            this.txttjyc3 = new System.Windows.Forms.TextBox();
            this.txttjyc2 = new System.Windows.Forms.TextBox();
            this.txttjyc1 = new System.Windows.Forms.TextBox();
            this.label111 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.radtjyyc = new System.Windows.Forms.RadioButton();
            this.radtjwyc = new System.Windows.Forms.RadioButton();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.fangYi3 = new KangShuoTech.Utilities.CommonControl.FangYiUserControl();
            this.fangYi2 = new KangShuoTech.Utilities.CommonControl.FangYiUserControl();
            this.fangYi1 = new KangShuoTech.Utilities.CommonControl.FangYiUserControl();
            this.label108 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.labl = new System.Windows.Forms.Label();
            this.groupBox38.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox36.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.ckjyw);
            this.groupBox38.Controls.Add(this.label1);
            this.groupBox38.Controls.Add(this.txtjyw);
            this.groupBox38.Controls.Add(this.ckMxb);
            this.groupBox38.Controls.Add(this.ckxOther);
            this.groupBox38.Controls.Add(this.ckxYimiao);
            this.groupBox38.Controls.Add(this.ckxWeight);
            this.groupBox38.Controls.Add(this.txtwxysqt);
            this.groupBox38.Controls.Add(this.txtjyjzym);
            this.groupBox38.Controls.Add(this.label114);
            this.groupBox38.Controls.Add(this.txtjtz);
            this.groupBox38.Controls.Add(this.chex);
            this.groupBox38.Controls.Add(this.chys);
            this.groupBox38.Controls.Add(this.chgunjiu);
            this.groupBox38.Controls.Add(this.chgunSmoke);
            this.groupBox38.Controls.Add(this.label112);
            this.groupBox38.Controls.Add(this.ckdqsf);
            this.groupBox38.Controls.Add(this.chjyzz);
            this.groupBox38.Controls.Add(this.chjyfc);
            this.groupBox38.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox38.Location = new System.Drawing.Point(111, 472);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(1313, 196);
            this.groupBox38.TabIndex = 2;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "健康指导";
            // 
            // ckjyw
            // 
            this.ckjyw.AutoSize = true;
            this.ckjyw.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckjyw.Location = new System.Drawing.Point(549, 168);
            this.ckjyw.Name = "ckjyw";
            this.ckjyw.Size = new System.Drawing.Size(148, 24);
            this.ckjyw.TabIndex = 15;
            this.ckjyw.Text = "减腹围 (目标";
            this.ckjyw.UseVisualStyleBackColor = true;
            this.ckjyw.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(886, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "cm )";
            this.label1.Visible = false;
            // 
            // txtjyw
            // 
            this.txtjyw.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtjyw.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjyw.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtjyw.Location = new System.Drawing.Point(710, 164);
            this.txtjyw.MaxLength = 5;
            this.txtjyw.Name = "txtjyw";
            this.txtjyw.Size = new System.Drawing.Size(164, 30);
            this.txtjyw.TabIndex = 17;
            this.txtjyw.Visible = false;
            // 
            // ckMxb
            // 
            this.ckMxb.AutoSize = true;
            this.ckMxb.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckMxb.Location = new System.Drawing.Point(9, 33);
            this.ckMxb.Name = "ckMxb";
            this.ckMxb.Size = new System.Drawing.Size(248, 24);
            this.ckMxb.TabIndex = 0;
            this.ckMxb.Text = "纳入慢性病患者健康管理";
            this.ckMxb.UseVisualStyleBackColor = true;
            // 
            // ckxOther
            // 
            this.ckxOther.AutoSize = true;
            this.ckxOther.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckxOther.Location = new System.Drawing.Point(549, 135);
            this.ckxOther.Name = "ckxOther";
            this.ckxOther.Size = new System.Drawing.Size(68, 24);
            this.ckxOther.TabIndex = 13;
            this.ckxOther.Text = "其他";
            this.ckxOther.UseVisualStyleBackColor = true;
            // 
            // ckxYimiao
            // 
            this.ckxYimiao.AutoSize = true;
            this.ckxYimiao.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckxYimiao.Location = new System.Drawing.Point(548, 98);
            this.ckxYimiao.Name = "ckxYimiao";
            this.ckxYimiao.Size = new System.Drawing.Size(148, 24);
            this.ckxYimiao.TabIndex = 11;
            this.ckxYimiao.Text = "建议接种疫苗";
            this.ckxYimiao.UseVisualStyleBackColor = true;
            // 
            // ckxWeight
            // 
            this.ckxWeight.AutoSize = true;
            this.ckxWeight.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckxWeight.Location = new System.Drawing.Point(548, 66);
            this.ckxWeight.Name = "ckxWeight";
            this.ckxWeight.Size = new System.Drawing.Size(138, 24);
            this.ckxWeight.TabIndex = 9;
            this.ckxWeight.Text = "减体重(目标";
            this.ckxWeight.UseVisualStyleBackColor = true;
            // 
            // txtwxysqt
            // 
            this.txtwxysqt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtwxysqt.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtwxysqt.Location = new System.Drawing.Point(709, 131);
            this.txtwxysqt.MaxLength = 20;
            this.txtwxysqt.Name = "txtwxysqt";
            this.txtwxysqt.Size = new System.Drawing.Size(196, 30);
            this.txtwxysqt.TabIndex = 14;
            // 
            // txtjyjzym
            // 
            this.txtjyjzym.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtjyjzym.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjyjzym.Location = new System.Drawing.Point(709, 93);
            this.txtjyjzym.MaxLength = 20;
            this.txtjyjzym.Name = "txtjyjzym";
            this.txtjyjzym.Size = new System.Drawing.Size(196, 30);
            this.txtjyjzym.TabIndex = 12;
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label114.Location = new System.Drawing.Point(885, 62);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(49, 20);
            this.label114.TabIndex = 9;
            this.label114.Text = "KG )";
            // 
            // txtjtz
            // 
            this.txtjtz.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtjtz.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjtz.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtjtz.Location = new System.Drawing.Point(709, 58);
            this.txtjtz.MaxLength = 5;
            this.txtjtz.Name = "txtjtz";
            this.txtjtz.Size = new System.Drawing.Size(164, 30);
            this.txtjtz.TabIndex = 10;
            // 
            // chex
            // 
            this.chex.AutoSize = true;
            this.chex.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chex.Location = new System.Drawing.Point(892, 28);
            this.chex.Name = "chex";
            this.chex.Size = new System.Drawing.Size(68, 24);
            this.chex.TabIndex = 8;
            this.chex.Text = "锻炼";
            this.chex.UseVisualStyleBackColor = true;
            // 
            // chys
            // 
            this.chys.AutoSize = true;
            this.chys.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chys.Location = new System.Drawing.Point(784, 28);
            this.chys.Name = "chys";
            this.chys.Size = new System.Drawing.Size(68, 24);
            this.chys.TabIndex = 7;
            this.chys.Text = "饮食";
            this.chys.UseVisualStyleBackColor = true;
            // 
            // chgunjiu
            // 
            this.chgunjiu.AutoSize = true;
            this.chgunjiu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chgunjiu.Location = new System.Drawing.Point(646, 28);
            this.chgunjiu.Name = "chgunjiu";
            this.chgunjiu.Size = new System.Drawing.Size(108, 24);
            this.chgunjiu.TabIndex = 6;
            this.chgunjiu.Text = "健康饮酒";
            this.chgunjiu.UseVisualStyleBackColor = true;
            // 
            // chgunSmoke
            // 
            this.chgunSmoke.AutoSize = true;
            this.chgunSmoke.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chgunSmoke.Location = new System.Drawing.Point(549, 28);
            this.chgunSmoke.Name = "chgunSmoke";
            this.chgunSmoke.Size = new System.Drawing.Size(68, 24);
            this.chgunSmoke.TabIndex = 5;
            this.chgunSmoke.Text = "戒烟";
            this.chgunSmoke.UseVisualStyleBackColor = true;
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label112.Location = new System.Drawing.Point(408, 29);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(129, 20);
            this.label112.TabIndex = 4;
            this.label112.Text = "危险因素控制";
            // 
            // ckdqsf
            // 
            this.ckdqsf.AutoSize = true;
            this.ckdqsf.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckdqsf.Location = new System.Drawing.Point(9, 122);
            this.ckdqsf.Name = "ckdqsf";
            this.ckdqsf.Size = new System.Drawing.Size(108, 24);
            this.ckdqsf.TabIndex = 3;
            this.ckdqsf.Text = "定期随访";
            this.ckdqsf.UseVisualStyleBackColor = true;
            // 
            // chjyzz
            // 
            this.chjyzz.AutoSize = true;
            this.chjyzz.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chjyzz.Location = new System.Drawing.Point(9, 93);
            this.chjyzz.Name = "chjyzz";
            this.chjyzz.Size = new System.Drawing.Size(108, 24);
            this.chjyzz.TabIndex = 2;
            this.chjyzz.Text = "建议转诊";
            this.chjyzz.UseVisualStyleBackColor = true;
            // 
            // chjyfc
            // 
            this.chjyfc.AutoSize = true;
            this.chjyfc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chjyfc.Location = new System.Drawing.Point(9, 63);
            this.chjyfc.Name = "chjyfc";
            this.chjyfc.Size = new System.Drawing.Size(108, 24);
            this.chjyfc.TabIndex = 1;
            this.chjyfc.Text = "建议复查";
            this.chjyfc.UseVisualStyleBackColor = true;
            this.chjyfc.CheckedChanged += new System.EventHandler(this.chjyfc_CheckedChanged);
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.txttjyc6);
            this.groupBox37.Controls.Add(this.label3);
            this.groupBox37.Controls.Add(this.txttjyc5);
            this.groupBox37.Controls.Add(this.label2);
            this.groupBox37.Controls.Add(this.txttjyc4);
            this.groupBox37.Controls.Add(this.label237);
            this.groupBox37.Controls.Add(this.txttjyc3);
            this.groupBox37.Controls.Add(this.txttjyc2);
            this.groupBox37.Controls.Add(this.txttjyc1);
            this.groupBox37.Controls.Add(this.label111);
            this.groupBox37.Controls.Add(this.label110);
            this.groupBox37.Controls.Add(this.label109);
            this.groupBox37.Controls.Add(this.radtjyyc);
            this.groupBox37.Controls.Add(this.radtjwyc);
            this.groupBox37.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox37.Location = new System.Drawing.Point(111, 174);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(1313, 292);
            this.groupBox37.TabIndex = 1;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "健康评价";
            // 
            // txttjyc6
            // 
            this.txttjyc6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txttjyc6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttjyc6.Location = new System.Drawing.Point(82, 253);
            this.txttjyc6.MaxLength = 100;
            this.txttjyc6.Name = "txttjyc6";
            this.txttjyc6.ReadOnly = true;
            this.txttjyc6.Size = new System.Drawing.Size(781, 30);
            this.txttjyc6.TabIndex = 15;
            this.txttjyc6.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "异常6";
            this.label3.Visible = false;
            // 
            // txttjyc5
            // 
            this.txttjyc5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txttjyc5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttjyc5.Location = new System.Drawing.Point(82, 216);
            this.txttjyc5.MaxLength = 100;
            this.txttjyc5.Name = "txttjyc5";
            this.txttjyc5.ReadOnly = true;
            this.txttjyc5.Size = new System.Drawing.Size(781, 30);
            this.txttjyc5.TabIndex = 13;
            this.txttjyc5.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "异常5";
            this.label2.Visible = false;
            // 
            // txttjyc4
            // 
            this.txttjyc4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txttjyc4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttjyc4.Location = new System.Drawing.Point(82, 180);
            this.txttjyc4.MaxLength = 100;
            this.txttjyc4.Name = "txttjyc4";
            this.txttjyc4.ReadOnly = true;
            this.txttjyc4.Size = new System.Drawing.Size(781, 30);
            this.txttjyc4.TabIndex = 11;
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label237.Location = new System.Drawing.Point(6, 186);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(59, 20);
            this.label237.TabIndex = 10;
            this.label237.Text = "异常4";
            // 
            // txttjyc3
            // 
            this.txttjyc3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txttjyc3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttjyc3.Location = new System.Drawing.Point(82, 146);
            this.txttjyc3.MaxLength = 100;
            this.txttjyc3.Name = "txttjyc3";
            this.txttjyc3.ReadOnly = true;
            this.txttjyc3.Size = new System.Drawing.Size(781, 30);
            this.txttjyc3.TabIndex = 9;
            // 
            // txttjyc2
            // 
            this.txttjyc2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txttjyc2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttjyc2.Location = new System.Drawing.Point(82, 108);
            this.txttjyc2.MaxLength = 100;
            this.txttjyc2.Name = "txttjyc2";
            this.txttjyc2.ReadOnly = true;
            this.txttjyc2.Size = new System.Drawing.Size(781, 30);
            this.txttjyc2.TabIndex = 8;
            // 
            // txttjyc1
            // 
            this.txttjyc1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txttjyc1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttjyc1.Location = new System.Drawing.Point(82, 69);
            this.txttjyc1.MaxLength = 100;
            this.txttjyc1.Name = "txttjyc1";
            this.txttjyc1.ReadOnly = true;
            this.txttjyc1.Size = new System.Drawing.Size(781, 30);
            this.txttjyc1.TabIndex = 7;
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label111.Location = new System.Drawing.Point(6, 151);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(59, 20);
            this.label111.TabIndex = 2;
            this.label111.Text = "异常3";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label110.Location = new System.Drawing.Point(6, 112);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(59, 20);
            this.label110.TabIndex = 2;
            this.label110.Text = "异常2";
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label109.Location = new System.Drawing.Point(7, 73);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(59, 20);
            this.label109.TabIndex = 2;
            this.label109.Text = "异常1";
            // 
            // radtjyyc
            // 
            this.radtjyyc.AutoSize = true;
            this.radtjyyc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radtjyyc.Location = new System.Drawing.Point(147, 29);
            this.radtjyyc.Name = "radtjyyc";
            this.radtjyyc.Size = new System.Drawing.Size(87, 24);
            this.radtjyyc.TabIndex = 1;
            this.radtjyyc.Text = "有异常";
            this.radtjyyc.UseVisualStyleBackColor = true;
            // 
            // radtjwyc
            // 
            this.radtjwyc.AutoSize = true;
            this.radtjwyc.Checked = true;
            this.radtjwyc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radtjwyc.Location = new System.Drawing.Point(7, 29);
            this.radtjwyc.Name = "radtjwyc";
            this.radtjwyc.Size = new System.Drawing.Size(127, 24);
            this.radtjwyc.TabIndex = 0;
            this.radtjwyc.TabStop = true;
            this.radtjwyc.Text = "体检无异常";
            this.radtjwyc.UseVisualStyleBackColor = true;
            this.radtjwyc.CheckedChanged += new System.EventHandler(this.radtjwyc_CheckedChanged);
            // 
            // groupBox36
            // 
            this.groupBox36.Controls.Add(this.fangYi3);
            this.groupBox36.Controls.Add(this.fangYi2);
            this.groupBox36.Controls.Add(this.fangYi1);
            this.groupBox36.Controls.Add(this.label108);
            this.groupBox36.Controls.Add(this.label107);
            this.groupBox36.Controls.Add(this.labl);
            this.groupBox36.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox36.Location = new System.Drawing.Point(111, 23);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(1313, 150);
            this.groupBox36.TabIndex = 0;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "非免疫预防接种史";
            // 
            // fangYi3
            // 
            this.fangYi3.JZName = "";
            this.fangYi3.JZOrganization = "";
            this.fangYi3.Location = new System.Drawing.Point(33, 113);
            this.fangYi3.Margin = new System.Windows.Forms.Padding(13);
            this.fangYi3.Name = "fangYi3";
            this.fangYi3.Size = new System.Drawing.Size(1264, 37);
            this.fangYi3.StrTime = null;
            this.fangYi3.TabIndex = 12;
            // 
            // fangYi2
            // 
            this.fangYi2.JZName = "";
            this.fangYi2.JZOrganization = "";
            this.fangYi2.Location = new System.Drawing.Point(33, 80);
            this.fangYi2.Margin = new System.Windows.Forms.Padding(13);
            this.fangYi2.Name = "fangYi2";
            this.fangYi2.Size = new System.Drawing.Size(1264, 37);
            this.fangYi2.StrTime = null;
            this.fangYi2.TabIndex = 11;
            // 
            // fangYi1
            // 
            this.fangYi1.JZName = "";
            this.fangYi1.JZOrganization = "";
            this.fangYi1.Location = new System.Drawing.Point(33, 49);
            this.fangYi1.Margin = new System.Windows.Forms.Padding(13);
            this.fangYi1.Name = "fangYi1";
            this.fangYi1.Size = new System.Drawing.Size(1264, 34);
            this.fangYi1.StrTime = null;
            this.fangYi1.TabIndex = 10;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label108.Location = new System.Drawing.Point(723, 23);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(89, 20);
            this.label108.TabIndex = 1;
            this.label108.Text = "接种机构";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label107.Location = new System.Drawing.Point(341, 23);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(89, 20);
            this.label107.TabIndex = 0;
            this.label107.Text = "接种时间";
            // 
            // labl
            // 
            this.labl.AutoSize = true;
            this.labl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labl.Location = new System.Drawing.Point(118, 23);
            this.labl.Name = "labl";
            this.labl.Size = new System.Drawing.Size(49, 20);
            this.labl.TabIndex = 0;
            this.labl.Text = "名称";
            // 
            // HealthAppraisalUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1460, 680);
            this.Controls.Add(this.groupBox38);
            this.Controls.Add(this.groupBox37);
            this.Controls.Add(this.groupBox36);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "HealthAppraisalUserControl";
            this.Text = "  ";
            this.Load += new System.EventHandler(this.UCHealthAppraisal_Load);
            this.VisibleChanged += new System.EventHandler(this.HealthAppraisalUserControl_VisibleChanged);
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        private void radtjwyc_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (button != null)
            {
                if (button.Checked)
                {
                    this.txttjyc1.Text = "";
                    this.txttjyc1.ReadOnly = true;
                    this.txttjyc2.Text = "";
                    this.txttjyc2.ReadOnly = true;
                    this.txttjyc3.Text = "";
                    this.txttjyc3.ReadOnly = true;
                    this.txttjyc4.Text = "";
                    this.txttjyc4.ReadOnly = true;
                }
                else
                {
                    this.txttjyc1.ReadOnly = false;
                    this.txttjyc2.ReadOnly = false;
                    this.txttjyc3.ReadOnly = false;
                    this.txttjyc4.ReadOnly = false;
                }
            }
        }

        private void SaveAssessmentGuides()
        {
            if (this.AssessmentGuides != null)
            {
                this.AssessmentGuides.OutKey = PhysicalInfoFactory.ID;
                RecordsAssessmentGuideBLL recordsAssessmentGuideBll = new RecordsAssessmentGuideBLL();
                if (!recordsAssessmentGuideBll.ExistsOutKey(this.AssessmentGuides.IDCardNo, PhysicalInfoFactory.ID))
                {
                    recordsAssessmentGuideBll.Add(this.AssessmentGuides);
                }
                else
                {
                    recordsAssessmentGuideBll.Update(this.AssessmentGuides);
                }
            }
        }

        private void SaveInoculationHistory()
        {
            RecordsInoculationHistoryBLL recordsInoculationHistoryBll = new RecordsInoculationHistoryBLL();
            recordsInoculationHistoryBll.DeleteByOutKey(PhysicalInfoFactory.ID);

            if (this.InoculationHistory != null)
            {
                foreach (RecordsInoculationHistoryModel recordsInoculationHistoryModel in this.InoculationHistory)
                {
                    recordsInoculationHistoryModel.OutKey = PhysicalInfoFactory.ID;
                    if (recordsInoculationHistoryModel.ModelState != RecordsStateModel.DeleteInDB)
                    {
                        recordsInoculationHistoryBll.Add(recordsInoculationHistoryModel);
                    }
                }
            }
        }

        public bool SaveModelToDB()
        {
            if (PhysicalInfoFactory.ID != -1)
            {
                this.SaveInoculationHistory();
                this.SaveAssessmentGuides();
            }
            return true;
        }

        private void SimpleBinding(TextBox tb, string srcMember, bool isFormate)
        {
            Binding binding = new Binding("Text", this.AssessmentGuides, srcMember, isFormate, DataSourceUpdateMode.OnPropertyChanged);
            tb.DataBindings.Add(binding);
            if (isFormate)
            {
                binding.Parse += new ConvertEventHandler(this.bd_Parse);
            }
        }

        private void UCHealthAppraisal_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void UpdataToModel()
        {
            for (int i = 0; i < this.fangyis.Count; i++)
            {
                this.fangyis[i].UpdateSource(this.Model.IDCardNo);
                if (this.fangyis[i].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.InoculationHistory.Add(this.fangyis[i].Source);
                }
            }
            this.AssessmentGuides.IDCardNo = this.Model.IDCardNo;
            this.AssessmentGuides.IsNormal = !this.radtjwyc.Checked ? "2" : "1";
            string str = "";
            for (int j = 0; j < this.jkzd.Count; j++)
            {
                if (this.jkzd[j].Checked)
                {
                    str = str + string.Format("{0},", j + 1);
                }
            }
            this.AssessmentGuides.HealthGuide = str.Trim(new char[] { ',' });
            string str2 = "";
            for (int k = 0; k < this.wxys.Count; k++)
            {
                if (this.wxys[k].Checked)
                {
                    str2 = str2 + string.Format("{0},", k + 1);
                }
            }
            this.AssessmentGuides.DangerControl = str2.Trim(new char[] { ',' });
            this.AssessmentGuides.Exception1 = this.txttjyc1.Text;
            this.AssessmentGuides.Exception2 = this.txttjyc2.Text;
            this.AssessmentGuides.Exception3 = this.txttjyc3.Text;
            this.AssessmentGuides.Exception4 = this.txttjyc4.Text;
            this.AssessmentGuides.Exception5 = this.txttjyc5.Text;
            this.AssessmentGuides.Exception6 = this.txttjyc6.Text;
            decimal armnum;
            if (Decimal.TryParse(this.txtjtz.Text, out armnum))
            {
                this.AssessmentGuides.Arm = armnum.ToString();
            }
            else
            {
                this.AssessmentGuides.Arm = "";
            }
            this.AssessmentGuides.VaccineAdvice = this.txtjyjzym.Text;
            this.AssessmentGuides.Other = this.txtwxysqt.Text;
        }

        private RecordsCardModel ArchiveCard { get; set; }

        public RecordsAssessmentGuideModel AssessmentGuides { get; set; }

        public RecordsLifeStyleModel LifeStylemodel { get; set; }

        public RecordsGeneralConditionModel generalconditionmodel { get; set; }

        public RecordsAssistCheckModel assistcheckmodel { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public List<RecordsInoculationHistoryModel> InoculationHistory { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        internal class CHealthGuid
        {
            private bool UState;

            private void Check_CheckedChanged(object sender, EventArgs e)
            {
                if (!this.Check.Checked)
                {
                    this.Content.Clear();
                }
            }

            private void Content_TextChanged(object sender, EventArgs e)
            {
                this.SetEnabled((sender as TextBox).Text != "");
            }

            public void eventBinding()
            {
                this.Content.TextChanged += new EventHandler(this.Content_TextChanged);
                this.Check.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            }

            private void SetEnabled(bool p_enabled)
            {
                if (this.UState != p_enabled)
                {
                    this.Check.Checked = p_enabled;
                    this.UState = p_enabled;
                }
            }

            public CheckBox Check { get; set; }

            public TextBox Content { get; set; }

            public string Name { get; set; }
        }

        private void HealthAppraisalUserControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (PhysicalInfoFactory.falgID == 0)
                {
                    AssessmentGuides.DangerControl = "";
                    AssessmentGuides.Arm = "";
                    AssessmentGuides.Other = "";
                    AssessmentGuides.HealthGuide = "";
                    AssessmentGuides.VaccineAdvice = "";
                    AssessmentGuides.WaistlineArm = "";
                }

                SetHealthEx();//健康异常设置
                SetDangerous();//危险因素控制
            }
        }

        private void chjyfc_CheckedChanged(object sender, EventArgs e)
        {
            if (chjyfc.Checked)
            {
                ckxOther.Checked = true;
                if (string.IsNullOrEmpty(txtwxysqt.Text))
                {
                    if(!area.Equals("济宁"))
                    txtwxysqt.Text = "低盐低脂饮食。";
                }
            }
        }
    }
}

