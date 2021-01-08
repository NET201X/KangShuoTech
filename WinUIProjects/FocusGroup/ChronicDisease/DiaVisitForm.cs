using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup
{
    using KangShuoTech.Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using FocusGroup.ChronicDisease;
    using AxHWPenSignLib;
    using System.Configuration;

    public class DiaVisitForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<ChronicDiadetesVisitModel> bindingManager;
        private IContainer components;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private List<YongYaoQKUserControl> yongyaos;
        private List<YongYaoQKUserControlYC> yongyaoyc;
        private ManyCheckboxs<ChronicDiadetesVisitModel> zhengzhuang;
        private string visitdate;
        private Panel panel4;
        private GroupBox groupBox7;
        private Panel panel2;
        private CheckBox ckGroup9;
        private CheckBox ckGroup8;
        private CheckBox ckGroup7;
        private CheckBox ckGroup6;
        private CheckBox ckGroup10;
        private CheckBox ckGroup5;
        private CheckBox ckGroup4;
        private CheckBox ckGroup3;
        private CheckBox ckGroup2;
        private CheckBox ckGroup1;
        private TextBox tbZzOther;
        private GroupBox groupBox2;
        private Panel panel3;
        private RadioButton rbzb3;
        private RadioButton rbzb2;
        private RadioButton rbzb1;
        private Label label58;
        private Label label57;
        private Label label53;
        private Button btnBMI;
        private Button btnNextBMI;
        private Label label46;
        private Button btnWeightNext;
        private Label label45;
        private Label label44;
        private ComboBox cbxZbdmbd;
        private TextBox tbTzzsTarget;
        private Label label2;
        private TextBox tbWeightTarget;
        private Label label3;
        private Button btnWeight;
        private Button btnXueya;
        private Label label4;
        private TextBox tbTzzs;
        private Label label5;
        private TextBox tbhight;
        private TextBox tbOther;
        private Label label48;
        private Label label29;
        private TextBox tbWeight;
        private Label label41;
        private TextBox tbXueya;
        private Label label42;
        private GroupBox groupBox6;
        private Panel panel5;
        private RadioButton rdzzno;
        private RadioButton rdzzyes;
        private LinkLabel linkLabel1;
        private Label label56;
        private DateTimePicker dtpNext;
        private TextBox tbJgkb;
        private Label label36;
        private Label label37;
        private TextBox tbZzyy;
        private Label label38;
        private GroupBox groupBox5;
        private TextBox tbYdsyf;
        private Label label34;
        private TextBox tbYdszl;
        private Label label33;
        private YongYaoQKUserControl yongYaoQK3;
        private YongYaoQKUserControl yongYaoQK2;
        private YongYaoQKUserControl yongYaoQK1;
        private YongYaoQKUserControlYC yongYaoYCQK3;
        private YongYaoQKUserControlYC yongYaoYCQK2;
        private YongYaoQKUserControlYC yongYaoYCQK1;
        private GroupBox groupBox3;
        private Button btnNoDrink;
        private Button btnNoSmoke;
        private ComboBox cbxSportMinTarget;
        private ComboBox cbxSportCountTarget;
        private ComboBox cbxSportMin;
        private ComboBox cbxSportCount;
        private ComboBox cbxMainFoodTarget;
        private ComboBox cbxMainFood;
        private Label label39;
        private Label label40;
        private Label label35;
        private Label label6;
        private Label label30;
        private Label label31;
        private Label label27;
        private Label label28;
        private Label label25;
        private TextBox tbDrinkTarget;
        private TextBox tbSmokeTarget;
        private Label label26;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label21;
        private ComboBox cbxZyxw;
        private ComboBox cbxXltz;
        private Label label11;
        private Label label10;
        private Label label7;
        private Label label8;
        private TextBox tbDrink;
        private Label label9;
        private TextBox tbSmoke;
        private Label label32;
        private GroupBox groupBox4;
        private TextBox tbdorctview;
        private Label label55;
        private Label label52;
        private Label label50;
        private Label label47;
        private TextBox tbAidExam;
        private Label label51;
        private Label label49;
        private Label label16;
        private Button btnXuetang;
        private TextBox tbBlfyxx;
        private Label label20;
        private DateTimePicker dtpCheckTime;
        private Label label19;
        private Label label17;
        private TextBox tbchxt;
        private TextBox tbThxhdb;
        private TextBox tbsjxt;
        private Label label18;
        private TextBox tblBG;
        private ComboBox cbxDxtfy;
        private ComboBox cbxYblfy;
        private ComboBox cbxFyycx;
        private Label label12;
        private Label label13;
        private Label label14;
        private GroupBox groupBox1;
        private TextBox tbDoctor;
        private Label label15;
        private DateTimePicker dtpVisit;
        private Label label43;
        private Panel panel1;
        private RadioButton radMZ;
        private RadioButton radsfqt;
        private RadioButton radPhone;
        private RadioButton radFamily;
        private Label label1;
        private ComboBox cbNextMeasures;
        private Label label59;
        private GroupBox groupBox8;
        private TextBox tbYDSTZYL;
        private Label label60;
        private TextBox tbYDSTZZL;
        private Label label61;
        private YongYaoQKUserControl yongYaoTZ3;
        private YongYaoQKUserControl yongYaoTZ2;
        private YongYaoQKUserControl yongYaoTZ1;
        private YongYaoQKUserControlYC yongYaoYCTZ3;
        private YongYaoQKUserControlYC yongYaoYCTZ2;
        private YongYaoQKUserControlYC yongYaoYCTZ1;
        private Panel panel7;
        private RadioButton rddw;
        private RadioButton rdwdw;
        private Label label62;
        private TextBox txtReferralContacts;
        private Label label63;
        private TextBox tbRemark;
        private Label label64;
        private LinkLabel lkJm;
        private PictureBox picSignJm;
        private Label label65;
        private ChronicHypertensionVisitBLL hyp_oper = new ChronicHypertensionVisitBLL();
        private List<YongYaoQKUserControl> yongyaotz;
        private List<YongYaoQKUserControlYC> yongyaotzyc;
        private string SignS = "";
        private string SignDoc = "";//医生签名
        private ComboBox cbVisitType;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label54;
        private GroupBox groupBox9;
        private Label label66;
        private TextBox tbYdsyf1;
        private Label label67;
        private TextBox tbYdszl1;
        private GroupBox groupBox10;
        private TextBox tbYDSTZYL1;
        private Label label69;
        private TextBox tbYDSTZZL1;
        private Label label68;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/DiaVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "DiaVisit//"; //签名保存路径
        RecordsGeneralConditionBLL generalConditionBll = new RecordsGeneralConditionBLL();
        ChronicDiadetesVisitBLL diadetesVisitBll = new ChronicDiadetesVisitBLL();
        ChronicDrugConditionBLL drugConditionBll = new ChronicDrugConditionBLL();
        DataSet dsRequire = new DataSet();

        public DiaVisitForm()
        {
            this.InitializeComponent();
            this.yongyaos = new List<YongYaoQKUserControl> { this.yongYaoQK1, this.yongYaoQK2, this.yongYaoQK3 };
            this.yongyaotz = new List<YongYaoQKUserControl> { this.yongYaoTZ1, this.yongYaoTZ2, this.yongYaoTZ3 };
            this.yongyaoyc = new List<YongYaoQKUserControlYC> { this.yongYaoYCQK1, this.yongYaoYCQK2, this.yongYaoYCQK3 };
            this.yongyaotzyc = new List<YongYaoQKUserControlYC> { this.yongYaoYCTZ1, this.yongYaoYCTZ2, this.yongYaoYCTZ3 };

            yongYaoQK1.cbxFyycx = this.cbxFyycx;
            yongYaoQK2.cbxFyycx = this.cbxFyycx;
            yongYaoQK3.cbxFyycx = this.cbxFyycx;
            yongYaoTZ1.cbxFyycx = this.cbxFyycx;
            yongYaoTZ2.cbxFyycx = this.cbxFyycx;
            yongYaoTZ3.cbxFyycx = this.cbxFyycx;

            yongYaoYCQK1.cbxFyycx = this.cbxFyycx;
            yongYaoYCQK2.cbxFyycx = this.cbxFyycx;
            yongYaoYCQK3.cbxFyycx = this.cbxFyycx;
            yongYaoYCTZ1.cbxFyycx = this.cbxFyycx;
            yongYaoYCTZ2.cbxFyycx = this.cbxFyycx;
            yongYaoYCTZ3.cbxFyycx = this.cbxFyycx;

            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("CustomerName", 30));
            this.inputrange_str.Add(new InputRangeStr("FollowUpDoctor", 30));
            this.inputrange_str.Add(new InputRangeStr("Symptom", 30));
            this.inputrange_str.Add(new InputRangeStr("ReferralOrg", 30));
            this.inputrange_str.Add(new InputRangeStr("InsulinType", 30));
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("Hypertension", 1000M));
            this.inputRanges.Add(new InputRangeDec("Hypotension", 1000M));
            this.inputRanges.Add(new InputRangeDec("Weight", 1000M));
            this.inputRanges.Add(new InputRangeDec("BMI", 1000M));
            this.inputRanges.Add(new InputRangeDec("DorsalisPedispulse", 1000M));
            this.inputRanges.Add(new InputRangeDec("DailySmokeNum", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("DailyDrinkNum", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("SportTimePerWeek", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("SportPerMinuteTime", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("StapleFooddailyg", 10000M, false));
            this.inputRanges.Add(new InputRangeDec("FPG", 1000M));
            this.inputRanges.Add(new InputRangeDec("HbAlc", 1000M));
            this.inputRanges.Add(new InputRangeDec("TargetWeight", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("BMITarget", 1000M));
            this.inputRanges.Add(new InputRangeDec("DailySmokeNumTarget", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("DailyDrinkNumTarget", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("SportTimePerWeekTarget", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("SportPerMinuteTimeTarget", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("StapleFooddailygTarget", 10000M, false));
            this.inputRanges.Add(new InputRangeDec("PBG", 10000M, false));
            this.inputRanges.Add(new InputRangeDec("RBG", 10000M, false));
            this.EveryThingIsOk = false;

            dsRequire = new RequireBLL().GetList("TabName = '糖尿病随访' AND Comment = '糖尿病随访信息' ");
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

        private void btnXuetang_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "24")
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tblBG.Text = select.m_Result.value1;
                this.DiabetessFollowupRcd.FPG = new decimal?((int.Parse(select.m_Result.value1)));

                if (this.DiabetessFollowupRcd.FPG >= Convert.ToDecimal(16.7))
                {
                    this.cbNextMeasures.SelectedIndex = 3;
                    this.DiabetessFollowupRcd.NextMeasures = "4";
                    this.cbVisitType.SelectedIndex = 1;
                    this.DiabetessFollowupRcd.VisitType = "2";
                }
                else if (this.DiabetessFollowupRcd.FPG >= 7)
                {
                    this.cbNextMeasures.SelectedIndex = 2;
                    this.DiabetessFollowupRcd.NextMeasures = "3";
                    this.cbVisitType.SelectedIndex = 1;
                    this.DiabetessFollowupRcd.VisitType = "2";
                }
                else
                {
                    this.cbNextMeasures.SelectedIndex = 0;
                    this.DiabetessFollowupRcd.NextMeasures = "1";
                    this.cbVisitType.SelectedIndex = 0;
                    this.DiabetessFollowupRcd.VisitType = "1";
                }
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
                this.DiabetessFollowupRcd.Hypertension = new decimal?(int.Parse(select.m_Result.value1));
                this.DiabetessFollowupRcd.Hypotension = new decimal?(int.Parse(select.m_Result.value2));
                this.tbXueya.Text = select.m_Result.value1 + "/" + select.m_Result.value2;
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            bool flag = false;
            if (this.dtpNext.Value.Date < this.dtpVisit.Value.Date)
            {
                flag = true;
                this.SaveDataInfo = "下次随访日期不能小于当前的随访日期！\r\n";
            }
            if (this.dtpVisit.Value.Date > DateTime.Today)
            {
                DiaVisitForm follow = this;
                string str = follow.SaveDataInfo + "随访日期不能晚于当前日期!\r\n";
                follow.SaveDataInfo = str;
                flag = true;
            }
            bool flag2 = false;
            if (this.dtpCheckTime.Value.Date > this.dtpVisit.Value.Date)
            {
                flag2 = true;
                DiaVisitForm follow2 = this;
                string str2 = follow2.SaveDataInfo + "检查日期大于当前的随访日期!";
                follow2.SaveDataInfo = str2;
            }
            if (((!this.bindingManager.ErrorInput && !flag) && !flag2) && (this.yongyaoyc.Count<YongYaoQKUserControlYC>(f => f.ErrorInput) <= 0))
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

        private void FrmDiaFollow_Load(object sender, EventArgs e)
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
                this.DiabetessFollowupRcd = diadetesVisitBll.GetModelID(this.IDPerson);

                if (this.DiabetessFollowupRcd.VisitDate.HasValue)
                {
                    this.dtpVisit.Value = this.DiabetessFollowupRcd.VisitDate.Value;
                    this.visitdate = this.DiabetessFollowupRcd.VisitDate.ToString();
                }
            }
            else
            {
                // 取默认项设置
                PresetValue();
                this.dtpVisit.Value = DateTime.Today.Date;
            }

            if (this.DiabetessFollowupRcd == null)
            {
                ChronicDiadetesVisitModel chronicDiadetesVisitModel = new ChronicDiadetesVisitModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    VisitType = "1"
                };

                this.DiabetessFollowupRcd = chronicDiadetesVisitModel;
                this.DiabetessFollowupRcd.CreateBy = ConfigHelper.GetNode("doctor");
                this.DiabetessFollowupRcd.CreateDate = new DateTime?(DateTime.Today);
                this.DrugConditions = new List<ChronicDrugConditionModel>();
                this.DrugConditionsTZ = new List<ChronicDrugConditionModel>();
            }
            else
            {
                this.DiabetessFollowupRcd.LastUpdateBy = ConfigHelper.GetNode("doctor");
                this.DiabetessFollowupRcd.LastUpdateDate = new DateTime?(DateTime.Today);

                if (this.IDPerson > 0)
                {
                    this.DrugConditions = drugConditionBll.GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '{2}' ", this.DiabetessFollowupRcd.IDCardNo, "2", this.IDPerson));
                    this.DrugConditionsTZ = drugConditionBll.GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '{2}' ", this.DiabetessFollowupRcd.IDCardNo, "8", this.IDPerson));//糖尿病用药调整类型为8
                }
                else
                {
                    this.DrugConditions = drugConditionBll.GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '{2}' ", this.DiabetessFollowupRcd.IDCardNo, "2", this.DiabetessFollowupRcd.ID));
                    this.DrugConditionsTZ = drugConditionBll.GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '{2}' ", this.DiabetessFollowupRcd.IDCardNo, "8", this.DiabetessFollowupRcd.ID));
                }
            }

            this.bindingManager = new SimpleBindingManager<ChronicDiadetesVisitModel>(this.inputRanges, this.inputrange_str, this.DiabetessFollowupRcd);
        }

        public void InitEveryThing()
        {
            int num;
            this.GetModel();
            this.HypertensionFollowRcd = this.hyp_oper.GetModels(this.Model.IDCardNo); //通过时间日期获取最新一笔数据

            if (this.HypertensionFollowRcd == null) this.HypertensionFollowRcd = new ChronicHypertensionVisitModel();

            if (string.IsNullOrEmpty(this.DiabetessFollowupRcd.VisitDoctor))
            {
                this.DiabetessFollowupRcd.VisitDoctor = ConfigHelper.GetNode("doctorName");
            }

            if (this.DiabetessFollowupRcd.Hypertension.HasValue || this.DiabetessFollowupRcd.Hypotension.HasValue)
            {
                if (this.DiabetessFollowupRcd.Hypertension.HasValue && this.DiabetessFollowupRcd.Hypotension.HasValue)
                {
                    this.tbXueya.Text = this.DiabetessFollowupRcd.Hypertension.Value.ToString() + "/" + this.DiabetessFollowupRcd.Hypotension.Value.ToString();
                }
                else if (this.DiabetessFollowupRcd.Hypertension.HasValue)
                {
                    this.tbXueya.Text = this.DiabetessFollowupRcd.Hypertension.Value.ToString();
                }
                else if (this.DiabetessFollowupRcd.Hypotension.HasValue)
                {
                    this.tbXueya.Text = "/" + this.DiabetessFollowupRcd.Hypotension.Value.ToString();
                }
            }
            else
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20");

                if (devData.HasValue)
                {
                    this.DiabetessFollowupRcd.Hypertension = new decimal?(int.Parse(devData.value1));
                    this.DiabetessFollowupRcd.Hypotension = new decimal?(int.Parse(devData.value2));
                    this.tbXueya.Text = devData.value1 + "/" + devData.value2;
                }
            }

            this.bindingManager.SimpleBinding(this.tbWeight, "Weight", true);

            if (this.tbWeight.Text == "")
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                if (_result2.HasValue)
                {
                    this.tbWeight.Text = _result2.value1;
                }
            }

            this.bindingManager.SimpleBinding(this.tbDoctor, "VisitDoctor", false);
            string followupWay = this.DiabetessFollowupRcd.VisitWay;

            if (followupWay == null) this.radMZ.Checked = true;
            else if (!(followupWay == ""))
            {
                if (followupWay == "1") this.radMZ.Checked = true;
                else if (followupWay == "2") this.radFamily.Checked = true;
                else if (followupWay == "3") this.radPhone.Checked = true;
                else if (followupWay == "4") this.radsfqt.Checked = true;
            }
            else this.radMZ.Checked = true;

            this.zhengzhuang = new ManyCheckboxs<ChronicDiadetesVisitModel>(this.DiabetessFollowupRcd);
            this.zhengzhuang.AddCk(this.ckGroup1, true);
            this.zhengzhuang.AddCk(new CheckBox[] { this.ckGroup2, this.ckGroup3, this.ckGroup4, this.ckGroup5, this.ckGroup6, this.ckGroup7, this.ckGroup8, this.ckGroup9, this.ckGroup10 });
            this.zhengzhuang.BindingProperty("Symptom", "");
            this.bindingManager.SimpleBinding(this.tbZzOther, "SymptomOther", false);

            if (this.IDPerson == 0 && this.Model.PopulationType.Contains("6") && this.Model.PopulationType.Contains("7"))
            {
                this.tbXueya.Text = this.HypertensionFollowRcd.Hypertension.ToString() + "/" + this.HypertensionFollowRcd.Hypotension.ToString(); //血压
                this.tbWeight.Text = this.HypertensionFollowRcd.Weight.ToString();//体重
                this.DiabetessFollowupRcd.TargetWeight = this.HypertensionFollowRcd.WeightTarGet;//体重下次随访目标
                this.DiabetessFollowupRcd.BMI = this.HypertensionFollowRcd.BMI;//体质指数
                this.DiabetessFollowupRcd.BMITarget = this.HypertensionFollowRcd.BMITarGet;//体质指数下次随访目标
                this.DiabetessFollowupRcd.Hight = this.HypertensionFollowRcd.Hight; //身高
                this.DiabetessFollowupRcd.DailySmokeNum = this.HypertensionFollowRcd.DailySmokeNum;//日吸烟量
                this.DiabetessFollowupRcd.DailySmokeNumTarget = this.HypertensionFollowRcd.DailySmokeNumTarget;//日吸烟量下次随访目标
                this.DiabetessFollowupRcd.DailyDrinkNum = this.HypertensionFollowRcd.DailyDrinkNum;//日饮酒量
                this.DiabetessFollowupRcd.DailyDrinkNumTarget = this.HypertensionFollowRcd.DailyDrinkNumTarget;//日饮酒量下次随访目标
                this.DiabetessFollowupRcd.SportTimePerWeek = this.HypertensionFollowRcd.SportTimePerWeek;//运动周
                this.DiabetessFollowupRcd.SportPerMinuteTime = this.HypertensionFollowRcd.SportPerMinuteTime; //运动分
                this.DiabetessFollowupRcd.SportTimePerWeekTarget = this.HypertensionFollowRcd.SportTimeSperWeekTarget;//运动周下次随访目标
                this.DiabetessFollowupRcd.SportPerMinuteTimeTarget = this.HypertensionFollowRcd.SportPerMinutesTimeTarget;//运动分下次随访目标
            }

            this.bindingManager.SimpleBinding(this.tbWeightTarget, "TargetWeight", true);
            if (this.DiabetessFollowupRcd.DorsalisPedispulse.HasValue)
            {
                this.cbxZbdmbd.SelectedIndex = ((int)this.DiabetessFollowupRcd.DorsalisPedispulse.Value) - 1;
            }
            if (this.DiabetessFollowupRcd.DorsalisPedispulse.HasValue)
            {
                this.cbxZbdmbd.SelectedIndex = ((int)this.DiabetessFollowupRcd.DorsalisPedispulse.Value) - 1;
            }
            else this.cbxZbdmbd.SelectedIndex = 0;

            this.bindingManager.SimpleBinding(this.tbTzzs, "BMI", true);
            this.bindingManager.SimpleBinding(this.tbTzzsTarget, "BMITarget", true);
            this.bindingManager.SimpleBinding(this.tbOther, "PhysicalSymptomMother", false);
            this.bindingManager.SimpleBinding(this.tbSmoke, "DailySmokeNum", true);
            this.bindingManager.SimpleBinding(this.tbSmokeTarget, "DailySmokeNumTarget", true);
            this.bindingManager.SimpleBinding(this.tbDrink, "DailyDrinkNum", true);
            this.bindingManager.SimpleBinding(this.tbDrinkTarget, "DailyDrinkNumTarget", true);
            this.bindingManager.SimpleBinding(this.cbxSportMin, "SportPerMinuteTime", true);
            this.bindingManager.SimpleBinding(this.cbxSportCount, "SportTimePerWeek", true);
            this.bindingManager.SimpleBinding(this.cbxSportCountTarget, "SportTimePerWeekTarget", true);
            this.bindingManager.SimpleBinding(this.cbxSportMinTarget, "SportPerMinuteTimeTarget", true);
            this.bindingManager.SimpleBinding(this.cbxMainFood, "StapleFooddailyg", true);
            this.bindingManager.SimpleBinding(this.cbxMainFoodTarget, "StapleFooddailygTarget", true);

            if (!string.IsNullOrEmpty(this.DiabetessFollowupRcd.PsychoAdjustment))
            {
                if (int.TryParse(this.DiabetessFollowupRcd.PsychoAdjustment, out num))
                {
                    this.cbxXltz.SelectedIndex = num - 1;
                }
            }
            else this.cbxXltz.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(this.DiabetessFollowupRcd.ObeyDoctorBehavior))
            {
                if (int.TryParse(this.DiabetessFollowupRcd.ObeyDoctorBehavior, out num))
                {
                    this.cbxZyxw.SelectedIndex = num - 1;
                }
            }
            else this.cbxZyxw.SelectedIndex = 0;

            this.bindingManager.SimpleBinding(this.tblBG, "FPG", true);

            if (!this.DiabetessFollowupRcd.FPG.HasValue)
            {
                stru_result _result3 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "24");

                if (_result3.HasValue)
                {
                    this.tblBG.Text = _result3.value1;
                    this.DiabetessFollowupRcd.FPG = new decimal?((int.Parse(_result3.value1)));

                    if (this.DiabetessFollowupRcd.FPG >= Convert.ToDecimal(16.7))
                    {
                        this.cbNextMeasures.SelectedIndex = 3;
                        this.DiabetessFollowupRcd.NextMeasures = "4";
                        this.cbVisitType.SelectedIndex = 1;
                        this.DiabetessFollowupRcd.VisitType = "2";
                    }
                    else if (this.DiabetessFollowupRcd.FPG >= 7)
                    {
                        this.cbNextMeasures.SelectedIndex = 2;
                        this.DiabetessFollowupRcd.NextMeasures = "3";
                        this.cbVisitType.SelectedIndex = 1;
                        this.DiabetessFollowupRcd.VisitType = "2";
                    }
                    else
                    {
                        this.cbNextMeasures.SelectedIndex = 0;
                        this.DiabetessFollowupRcd.NextMeasures = "1";
                        this.cbVisitType.SelectedIndex = 0;
                        this.DiabetessFollowupRcd.VisitType = "1";
                    }
                }
            }

            this.bindingManager.SimpleBinding(this.tbThxhdb, "HbAlc", true);
            if (this.DiabetessFollowupRcd.ExamDate.HasValue)
            {
                this.dtpCheckTime.Value = this.DiabetessFollowupRcd.ExamDate.Value;
            }

            this.bindingManager.SimpleBinding(this.tbAidExam, "AssistantExam", false);
            new CSelectItem { Info = this.tbBlfyxx, Name = "服药不良反应", Other = "有", CmbSelect = this.cbxYblfy }.TransInfo(this.DiabetessFollowupRcd.Adr, this.DiabetessFollowupRcd.AdrEx);
            this.SetComobox(this.cbxDxtfy, this.DiabetessFollowupRcd.HypoglyceMiarreAction);

            if (!string.IsNullOrEmpty(this.DiabetessFollowupRcd.VisitType)) //此次随访分类
            {
                this.cbVisitType.SelectedIndex = int.Parse(this.DiabetessFollowupRcd.VisitType) - 1;
            }

            this.bindingManager.SimpleBinding(this.tbsjxt, "RBG", true);//随机血糖
            this.bindingManager.SimpleBinding(this.tbchxt, "PBG", true);//餐后两个小时血糖
            this.bindingManager.SimpleBinding(this.tbdorctview, "DoctorView", false);//医生建议

            if (!string.IsNullOrEmpty(this.DiabetessFollowupRcd.Hight.ToString()))
            {
                this.tbhight.Text = this.DiabetessFollowupRcd.Hight.ToString();
            }

            if (!string.IsNullOrEmpty(this.DiabetessFollowupRcd.IsReferral))
            {
                if (this.DiabetessFollowupRcd.IsReferral == "1")
                {
                    this.rdzzyes.Checked = true;
                }
                else if (this.DiabetessFollowupRcd.IsReferral == "2")
                {
                    this.rdzzno.Checked = true;
                }
            }

            // 读取用药情况
            if (File.Exists(Application.StartupPath + "\\dose.xml"))
            {
                DataSet ds = new DataSet();

                ds.ReadXml(Application.StartupPath + "\\dose.xml");
                DataTable dt_yw1 = ds.Tables[0];

                yongYaoYCQK1.setSource(dt_yw1);
                yongYaoYCQK2.setSource(DeepCopy(dt_yw1));
                yongYaoYCQK3.setSource(DeepCopy(dt_yw1));
                yongYaoYCTZ1.setSource(DeepCopy(dt_yw1));
                yongYaoYCTZ2.setSource(DeepCopy(dt_yw1));
                yongYaoYCTZ3.setSource(DeepCopy(dt_yw1));
            }

            for (int i = 0; i < this.yongyaoyc.Count; i++)
            {
                if (i < this.DrugConditions.Count)
                {
                    this.yongyaoyc[i].Source = this.DrugConditions[i];

                    this.DiabetessFollowupRcd.MedicationCompliance = "1";
                }
                else
                {
                    ChronicDrugConditionModel cd_drugcondition = new ChronicDrugConditionModel
                    {
                        ModelState = RecordsStateModel.NoValue,
                        IDCardNo = this.Model.IDCardNo,
                        Type = "2"
                    };
                    this.yongyaoyc[i].Source = cd_drugcondition;
                }
            }

            // 药物调整意见
            for (int i = 0; i < this.yongyaotzyc.Count; i++)
            {
                if (i < this.DrugConditionsTZ.Count)
                {
                    this.yongyaotzyc[i].Source = this.DrugConditionsTZ[i];

                    this.DiabetessFollowupRcd.MedicationCompliance = "1";
                }
                else
                {
                    ChronicDrugConditionModel cd_drugconditionTZ = new ChronicDrugConditionModel
                    {
                        ModelState = RecordsStateModel.NoValue,
                        IDCardNo = this.Model.IDCardNo,
                        Type = "1"
                    };

                    this.yongyaotzyc[i].Source = cd_drugconditionTZ;
                }
            }


            this.SetComobox(this.cbxFyycx, this.DiabetessFollowupRcd.MedicationCompliance);
            this.bindingManager.SimpleBinding(this.tbYdszl1, "InsulinType", false);
            this.bindingManager.SimpleBinding(this.tbYdsyf1, "InsulinUsage", false);
            this.bindingManager.SimpleBinding(this.tbYDSTZZL1, "InsulinAdjustType", false);
            this.bindingManager.SimpleBinding(this.tbYDSTZYL1, "InsulinAdjustUsage", false);
            this.bindingManager.SimpleBinding(this.tbZzyy, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.tbJgkb, "ReferralOrg", false);
            this.SimpleBinding(this.txtReferralContacts, "ReferralContacts", false, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.tbRemark, "Remarks", false, DataSourceUpdateMode.OnPropertyChanged);

            if (this.DiabetessFollowupRcd.NextVisitDate.HasValue)
            {
                this.dtpNext.Value = this.DiabetessFollowupRcd.NextVisitDate.Value;
            }
            else
            {
                this.dtpNext.Value = this.dtpVisit.Value.AddMonths(3);
            }

            if (this.DiabetessFollowupRcd.DorsalisPedispulseType == "1")
            {
                this.rbzb1.Checked = true;
            }
            else if (this.DiabetessFollowupRcd.DorsalisPedispulseType == "2")
            {
                this.rbzb2.Checked = true;
            }
            else if (this.DiabetessFollowupRcd.DorsalisPedispulseType == "3")
            {
                this.rbzb3.Checked = true;
            }

            if (!string.IsNullOrEmpty(this.DiabetessFollowupRcd.NextMeasures))
            {
                this.cbNextMeasures.SelectedIndex = int.Parse(this.DiabetessFollowupRcd.NextMeasures) - 1;
            }

            if (this.DiabetessFollowupRcd.ReferralResult == "1")
            {
                this.rddw.Checked = true;
            }
            else if (this.DiabetessFollowupRcd.ReferralResult == "2")
            {
                this.rdwdw.Checked = true;
            }

            //签名初始化
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

            MustChoose();
            this.EveryThingIsOk = true;
        }

        private void MustChoose()
        {
            DataTable dt = dsRequire.Tables[0];

            ChronicDiadetesVisitModel DiabetessFollowupRcds = diadetesVisitBll.GetModelID(this.IDPerson);
            DataTable drugDt = drugConditionBll.GetList("IDCardNo ='" + Model.IDCardNo + "' AND Type = '2' " + " AND OUtKey = " + this.IDPerson).Tables[0];
            DataTable drugTZDt = drugConditionBll.GetList("IDCardNo ='" + Model.IDCardNo + "' AND Type = '8' " + " AND OUtKey = " + this.IDPerson).Tables[0];

            string Signjm = string.Format("{0}{1}_{2}.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpVisit.Value).ToString("yyyyMMdd"));
            string SignDocstr = string.Format("{0}{1}_{2}_Doc.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpVisit.Value).ToString("yyyyMMdd"));

            if (DiabetessFollowupRcds == null) DiabetessFollowupRcds = new ChronicDiadetesVisitModel();

            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "症状":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.Symptom))
                            {
                                this.groupBox7.Text = "*症状";
                                this.groupBox7.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.groupBox7.Text = "症状";
                                this.groupBox7.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血压":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.Hypertension)) && string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.Hypotension)))
                            {
                                this.label42.Text = "*血压";
                                this.label42.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label42.Text = "血压";
                                this.label42.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体质指数":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.BMI)))
                            {
                                this.label5.Text = "*体质指数";
                                this.label5.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label5.Text = "体质指数";
                                this.label5.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体质指数下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.BMITarget)))
                            {
                                this.label3.Text = "*下次随访目标";
                                this.label3.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label3.Text = "下次随访目标";
                                this.label3.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "足背动脉搏动":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.DorsalisPedispulse)))
                            {
                                this.label4.Text = "*足背动脉搏动";
                                this.label4.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label4.Text = "足背动脉搏动";
                                this.label4.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体重":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.Weight)))
                            {
                                this.label41.Text = "*体重";
                                this.label41.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label41.Text = "体重";
                                this.label41.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体重下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.TargetWeight)))
                            {
                                this.label2.Text = "*下次随访目标";
                                this.label2.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label2.Text = "下次随访目标";
                                this.label2.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "日吸烟量":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.DailySmokeNum)))
                            {
                                this.label32.Text = "*日吸烟量";
                                this.label32.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label32.Text = "日吸烟量";
                                this.label32.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "日吸烟量下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.DailySmokeNumTarget)))
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
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.DailyDrinkNum)))
                            {
                                this.label9.Text = "*日饮酒量";
                                this.label9.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label9.Text = "日饮酒量";
                                this.label9.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "日饮酒量下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.DailyDrinkNumTarget)))
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
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.SportTimePerWeek)) && string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.SportPerMinuteTime)))
                            {
                                this.label8.Text = "*运动";
                                this.label8.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label8.Text = "运动";
                                this.label8.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "运动下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.SportPerMinuteTimeTarget)) && string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.SportTimePerWeekTarget)))
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
                        case "主食":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.StapleFooddailyg)))
                            {
                                this.label7.Text = "*主食";
                                this.label7.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label7.Text = "主食";
                                this.label7.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "主食下次随访目标":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.StapleFooddailygTarget)))
                            {
                                this.label40.Text = "*下次随访目标";
                                this.label40.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label40.Text = "下次随访目标";
                                this.label40.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "心里调整":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.PsychoAdjustment))
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
                        case "遵医行为":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.ObeyDoctorBehavior))
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
                        case "空腹血糖值":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.FPG)))
                            {
                                this.label16.Text = "*空腹血糖值";
                                this.label16.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label16.Text = "空腹血糖值";
                                this.label16.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "糖化血红蛋白":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.HbAlc)))
                            {
                                this.label18.Text = "*糖化血红蛋白";
                                this.label18.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label18.Text = "糖化血红蛋白";
                                this.label18.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "检查日期":
                            if (DiabetessFollowupRcds.ExamDate == null)
                            {
                                this.label19.Text = "*检查日期";
                                this.label19.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label19.Text = "检查日期";
                                this.label19.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "服药依从性":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.MedicationCompliance))
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
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.Adr))
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
                        case "低血糖反应":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.HypoglyceMiarreAction))
                            {
                                this.label12.Text = "*低血糖反应";
                                this.label12.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label12.Text = "低血糖反应";
                                this.label12.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "随访分类":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.VisitType))
                            {
                                this.label20.Text = "*随访分类";
                                this.label20.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label20.Text = "随访分类";
                                this.label20.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "胰岛素种类":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.InsulinType))
                            {
                                this.label33.Text = "*胰岛素种类:";
                                this.label33.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label33.Text = "胰岛素种类:";
                                this.label33.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "用法与用量":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.InsulinUsage))
                            {
                                this.label34.Text = "*用法和用量:";
                                this.label34.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label34.Text = "用法和用量:";
                                this.label34.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "用药情况":
                            if (drugDt.Rows.Count > 0)
                            {
                                this.groupBox9.Text = "用药情况";
                                this.groupBox9.ForeColor = System.Drawing.Color.Black;
                                break;
                            }
                            else
                            {
                                this.groupBox9.Text = "*用药情况";
                                this.groupBox9.ForeColor = System.Drawing.Color.Red;
                            }
                            break;
                        case "随访日期":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.VisitDate)))
                            {
                                this.label43.Text = "*随访日期:";
                                this.label43.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label43.Text = "随访日期:";
                                this.label43.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "随访医生":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.VisitDoctor))
                            {
                                this.label15.Text = "*随访医生:";
                                this.label15.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label15.Text = "随访医生:";
                                this.label15.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "随访方式":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.VisitWay))
                            {
                                this.label1.Text = "*随访方式:";
                                this.label1.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label1.Text = "随访方式:";
                                this.label1.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体征其他":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.PhysicalSymptomMother))
                            {
                                this.label29.Text = "*其他";
                                this.label29.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label29.Text = "其他";
                                this.label29.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "身高":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.Hight)))
                            {
                                this.label48.Text = "*身高";
                                this.label48.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label48.Text = "身高";
                                this.label48.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "随机血糖":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.RBG)))
                            {
                                this.label49.Text = "*随机血糖";
                                this.label49.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label49.Text = "随机血糖";
                                this.label49.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "餐后2小时血糖":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.PBG)))
                            {
                                this.label51.Text = "*餐后2小时血糖";
                                this.label51.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label51.Text = "餐后2小时血糖";
                                this.label51.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "此次随访医生建议":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.DoctorView))
                            {
                                this.label55.Text = "*此次随访医生建议";
                                this.label55.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label55.Text = "此次随访医生建议";
                                this.label55.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "下一步管理措施":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.NextMeasures))
                            {
                                this.label59.Text = "*下一步管理措施";
                                this.label59.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label59.Text = "下一步管理措施";
                                this.label59.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "用药调整意见":
                            if (drugTZDt.Rows.Count > 0)
                            {
                                this.groupBox10.Text = "用药调整意见";
                                this.groupBox10.ForeColor = System.Drawing.Color.Black;
                                break;
                            }
                            else
                            {
                                this.groupBox10.Text = "*用药调整意见";
                                this.groupBox10.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "用药调整胰岛素种类":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.InsulinAdjustType))
                            {
                                this.label61.Text = "*胰岛素种类:";
                                this.label61.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label61.Text = "胰岛素种类:";
                                this.label61.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "用药调整用法和用量":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.InsulinAdjustUsage))
                            {
                                this.label60.Text = "*用法和用量:";
                                this.label60.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label60.Text = "用法和用量:";
                                this.label60.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "转诊情况":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.IsReferral))
                            {
                                this.label56.Text = "*转诊情况";
                                this.label56.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label56.Text = "转诊情况";
                                this.label56.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "备注":
                            if (string.IsNullOrEmpty(DiabetessFollowupRcds.Remarks))
                            {
                                this.label64.Text = "*备注:";
                                this.label64.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label64.Text = "备注:";
                                this.label64.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "下次随访日期":
                            if (string.IsNullOrEmpty(Convert.ToString(DiabetessFollowupRcds.NextVisitDate)))
                            {
                                this.label36.Text = "*下次随访日期:";
                                this.label36.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label36.Text = "下次随访日期:";
                                this.label36.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "医生签名":
                            if (!File.Exists(SignDocstr))
                            {
                                this.label54.Text = "*医生签名:";
                                this.label54.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label54.Text = "医生签名:";
                                this.label54.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "居民签字":
                            if (!File.Exists(Signjm))
                            {
                                this.label65.Text = "*居民签字:";
                                this.label65.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label65.Text = "居民签字:";
                                this.label65.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        default: break;
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tbYDSTZYL1 = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.tbYDSTZZL1 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.yongYaoYCTZ3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoYCTZ2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoYCTZ1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.tbYDSTZYL = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.tbYDSTZZL = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.yongYaoTZ3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYaoTZ2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYaoTZ1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckGroup9 = new System.Windows.Forms.CheckBox();
            this.ckGroup8 = new System.Windows.Forms.CheckBox();
            this.ckGroup7 = new System.Windows.Forms.CheckBox();
            this.ckGroup6 = new System.Windows.Forms.CheckBox();
            this.ckGroup10 = new System.Windows.Forms.CheckBox();
            this.ckGroup5 = new System.Windows.Forms.CheckBox();
            this.ckGroup4 = new System.Windows.Forms.CheckBox();
            this.ckGroup3 = new System.Windows.Forms.CheckBox();
            this.ckGroup2 = new System.Windows.Forms.CheckBox();
            this.ckGroup1 = new System.Windows.Forms.CheckBox();
            this.tbZzOther = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbWeightTarget = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbzb3 = new System.Windows.Forms.RadioButton();
            this.rbzb2 = new System.Windows.Forms.RadioButton();
            this.rbzb1 = new System.Windows.Forms.RadioButton();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.btnBMI = new System.Windows.Forms.Button();
            this.btnNextBMI = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.btnWeightNext = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.cbxZbdmbd = new System.Windows.Forms.ComboBox();
            this.tbTzzsTarget = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnWeight = new System.Windows.Forms.Button();
            this.btnXueya = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTzzs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbhight = new System.Windows.Forms.TextBox();
            this.tbOther = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.tbXueya = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.label54 = new System.Windows.Forms.Label();
            this.lkJm = new System.Windows.Forms.LinkLabel();
            this.picSignJm = new System.Windows.Forms.PictureBox();
            this.label65 = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rddw = new System.Windows.Forms.RadioButton();
            this.rdwdw = new System.Windows.Forms.RadioButton();
            this.label62 = new System.Windows.Forms.Label();
            this.txtReferralContacts = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdzzno = new System.Windows.Forms.RadioButton();
            this.rdzzyes = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label56 = new System.Windows.Forms.Label();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.tbJgkb = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.tbZzyy = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tbYdsyf1 = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.tbYdszl1 = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.yongYaoYCQK3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoYCQK2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoYCQK1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.tbYdsyf = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tbYdszl = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.yongYaoQK3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYaoQK2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYaoQK1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxMainFoodTarget = new System.Windows.Forms.ComboBox();
            this.btnNoDrink = new System.Windows.Forms.Button();
            this.btnNoSmoke = new System.Windows.Forms.Button();
            this.cbxSportMinTarget = new System.Windows.Forms.ComboBox();
            this.cbxSportCountTarget = new System.Windows.Forms.ComboBox();
            this.cbxSportMin = new System.Windows.Forms.ComboBox();
            this.cbxSportCount = new System.Windows.Forms.ComboBox();
            this.cbxMainFood = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tbDrinkTarget = new System.Windows.Forms.TextBox();
            this.tbSmokeTarget = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cbxZyxw = new System.Windows.Forms.ComboBox();
            this.cbxXltz = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDrink = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSmoke = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbVisitType = new System.Windows.Forms.ComboBox();
            this.cbNextMeasures = new System.Windows.Forms.ComboBox();
            this.label59 = new System.Windows.Forms.Label();
            this.tbdorctview = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.tbAidExam = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnXuetang = new System.Windows.Forms.Button();
            this.tbBlfyxx = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpCheckTime = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbchxt = new System.Windows.Forms.TextBox();
            this.tbThxhdb = new System.Windows.Forms.TextBox();
            this.tbsjxt = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tblBG = new System.Windows.Forms.TextBox();
            this.cbxDxtfy = new System.Windows.Forms.ComboBox();
            this.cbxYblfy = new System.Windows.Forms.ComboBox();
            this.cbxFyycx = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpVisit = new System.Windows.Forms.DateTimePicker();
            this.label43 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radMZ = new System.Windows.Forms.RadioButton();
            this.radsfqt = new System.Windows.Forms.RadioButton();
            this.radPhone = new System.Windows.Forms.RadioButton();
            this.radFamily = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJm)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.groupBox8);
            this.panel4.Controls.Add(this.groupBox7);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox6);
            this.panel4.Controls.Add(this.groupBox5);
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Location = new System.Drawing.Point(59, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1410, 622);
            this.panel4.TabIndex = 7;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Controls.Add(this.tbYDSTZYL);
            this.groupBox8.Controls.Add(this.label60);
            this.groupBox8.Controls.Add(this.tbYDSTZZL);
            this.groupBox8.Controls.Add(this.label61);
            this.groupBox8.Controls.Add(this.yongYaoTZ3);
            this.groupBox8.Controls.Add(this.yongYaoTZ2);
            this.groupBox8.Controls.Add(this.yongYaoTZ1);
            this.groupBox8.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox8.Location = new System.Drawing.Point(23, 739);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1358, 111);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "用药调整意见";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tbYDSTZYL1);
            this.groupBox10.Controls.Add(this.label69);
            this.groupBox10.Controls.Add(this.tbYDSTZZL1);
            this.groupBox10.Controls.Add(this.label68);
            this.groupBox10.Controls.Add(this.yongYaoYCTZ3);
            this.groupBox10.Controls.Add(this.yongYaoYCTZ2);
            this.groupBox10.Controls.Add(this.yongYaoYCTZ1);
            this.groupBox10.Location = new System.Drawing.Point(0, 0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1358, 111);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "用药调整意见";
            // 
            // tbYDSTZYL1
            // 
            this.tbYDSTZYL1.Location = new System.Drawing.Point(1168, 70);
            this.tbYDSTZYL1.Name = "tbYDSTZYL1";
            this.tbYDSTZYL1.Size = new System.Drawing.Size(169, 30);
            this.tbYDSTZYL1.TabIndex = 183;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(1043, 75);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(119, 20);
            this.label69.TabIndex = 3;
            this.label69.Text = "用法和用量:";
            // 
            // tbYDSTZZL1
            // 
            this.tbYDSTZZL1.Location = new System.Drawing.Point(830, 71);
            this.tbYDSTZZL1.Name = "tbYDSTZZL1";
            this.tbYDSTZZL1.Size = new System.Drawing.Size(175, 30);
            this.tbYDSTZZL1.TabIndex = 2;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(706, 74);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(119, 20);
            this.label68.TabIndex = 1;
            this.label68.Text = "胰岛素种类:";
            // 
            // yongYaoYCTZ3
            // 
            this.yongYaoYCTZ3.ErrorInput = false;
            this.yongYaoYCTZ3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYCTZ3.Location = new System.Drawing.Point(12, 67);
            this.yongYaoYCTZ3.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYCTZ3.MText = "药物名称3";
            this.yongYaoYCTZ3.Name = "yongYaoYCTZ3";
            this.yongYaoYCTZ3.Size = new System.Drawing.Size(639, 34);
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
            this.yongYaoYCTZ2.Location = new System.Drawing.Point(716, 18);
            this.yongYaoYCTZ2.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYCTZ2.MText = "药物名称2";
            this.yongYaoYCTZ2.Name = "yongYaoYCTZ2";
            this.yongYaoYCTZ2.Size = new System.Drawing.Size(635, 38);
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
            this.yongYaoYCTZ2.TabIndex = 0;
            // 
            // yongYaoYCTZ1
            // 
            this.yongYaoYCTZ1.ErrorInput = false;
            this.yongYaoYCTZ1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYCTZ1.Location = new System.Drawing.Point(12, 23);
            this.yongYaoYCTZ1.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYCTZ1.MText = "药物名称1";
            this.yongYaoYCTZ1.Name = "yongYaoYCTZ1";
            this.yongYaoYCTZ1.Size = new System.Drawing.Size(650, 41);
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
            this.yongYaoYCTZ1.TabIndex = 0;
            // 
            // tbYDSTZYL
            // 
            this.tbYDSTZYL.Location = new System.Drawing.Point(1111, 70);
            this.tbYDSTZYL.MaxLength = 20;
            this.tbYDSTZYL.Name = "tbYDSTZYL";
            this.tbYDSTZYL.Size = new System.Drawing.Size(226, 30);
            this.tbYDSTZYL.TabIndex = 7;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(987, 77);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(119, 20);
            this.label60.TabIndex = 6;
            this.label60.Text = "用法和用量:";
            // 
            // tbYDSTZZL
            // 
            this.tbYDSTZZL.Location = new System.Drawing.Point(794, 71);
            this.tbYDSTZZL.MaxLength = 256;
            this.tbYDSTZZL.Name = "tbYDSTZZL";
            this.tbYDSTZZL.Size = new System.Drawing.Size(146, 30);
            this.tbYDSTZZL.TabIndex = 5;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(681, 75);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(119, 20);
            this.label61.TabIndex = 4;
            this.label61.Text = "胰岛素种类:";
            // 
            // yongYaoTZ3
            // 
            this.yongYaoTZ3.ErrorInput = false;
            this.yongYaoTZ3.Font = new System.Drawing.Font("宋体", 15F);
            this.yongYaoTZ3.Location = new System.Drawing.Point(3, 66);
            this.yongYaoTZ3.Margin = new System.Windows.Forms.Padding(5);
            this.yongYaoTZ3.MText = "药物名称3";
            this.yongYaoTZ3.Name = "yongYaoTZ3";
            this.yongYaoTZ3.Size = new System.Drawing.Size(667, 34);
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
            this.yongYaoTZ2.Location = new System.Drawing.Point(683, 22);
            this.yongYaoTZ2.Margin = new System.Windows.Forms.Padding(5);
            this.yongYaoTZ2.MText = "药物名称2";
            this.yongYaoTZ2.Name = "yongYaoTZ2";
            this.yongYaoTZ2.Size = new System.Drawing.Size(654, 40);
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
            this.yongYaoTZ1.Location = new System.Drawing.Point(3, 23);
            this.yongYaoTZ1.Margin = new System.Windows.Forms.Padding(5);
            this.yongYaoTZ1.MText = "药物名称1";
            this.yongYaoTZ1.Name = "yongYaoTZ1";
            this.yongYaoTZ1.Size = new System.Drawing.Size(667, 39);
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
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.panel2);
            this.groupBox7.Controls.Add(this.tbZzOther);
            this.groupBox7.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox7.Location = new System.Drawing.Point(24, 75);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1358, 76);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "症状";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckGroup9);
            this.panel2.Controls.Add(this.ckGroup8);
            this.panel2.Controls.Add(this.ckGroup7);
            this.panel2.Controls.Add(this.ckGroup6);
            this.panel2.Controls.Add(this.ckGroup10);
            this.panel2.Controls.Add(this.ckGroup5);
            this.panel2.Controls.Add(this.ckGroup4);
            this.panel2.Controls.Add(this.ckGroup3);
            this.panel2.Controls.Add(this.ckGroup2);
            this.panel2.Controls.Add(this.ckGroup1);
            this.panel2.Location = new System.Drawing.Point(9, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1015, 42);
            this.panel2.TabIndex = 0;
            // 
            // ckGroup9
            // 
            this.ckGroup9.AutoSize = true;
            this.ckGroup9.Location = new System.Drawing.Point(783, 10);
            this.ckGroup9.Name = "ckGroup9";
            this.ckGroup9.Size = new System.Drawing.Size(148, 24);
            this.ckGroup9.TabIndex = 17;
            this.ckGroup9.Text = "体重明显下降";
            this.ckGroup9.UseVisualStyleBackColor = true;
            // 
            // ckGroup8
            // 
            this.ckGroup8.AutoSize = true;
            this.ckGroup8.Location = new System.Drawing.Point(672, 10);
            this.ckGroup8.Name = "ckGroup8";
            this.ckGroup8.Size = new System.Drawing.Size(108, 24);
            this.ckGroup8.TabIndex = 16;
            this.ckGroup8.Text = "下肢浮肿";
            this.ckGroup8.UseVisualStyleBackColor = true;
            // 
            // ckGroup7
            // 
            this.ckGroup7.AutoSize = true;
            this.ckGroup7.Location = new System.Drawing.Point(557, 10);
            this.ckGroup7.Name = "ckGroup7";
            this.ckGroup7.Size = new System.Drawing.Size(108, 24);
            this.ckGroup7.TabIndex = 15;
            this.ckGroup7.Text = "手脚麻木";
            this.ckGroup7.UseVisualStyleBackColor = true;
            // 
            // ckGroup6
            // 
            this.ckGroup6.AutoSize = true;
            this.ckGroup6.Location = new System.Drawing.Point(477, 10);
            this.ckGroup6.Name = "ckGroup6";
            this.ckGroup6.Size = new System.Drawing.Size(68, 24);
            this.ckGroup6.TabIndex = 14;
            this.ckGroup6.Text = "感染";
            this.ckGroup6.UseVisualStyleBackColor = true;
            // 
            // ckGroup10
            // 
            this.ckGroup10.AutoSize = true;
            this.ckGroup10.Location = new System.Drawing.Point(937, 9);
            this.ckGroup10.Name = "ckGroup10";
            this.ckGroup10.Size = new System.Drawing.Size(68, 24);
            this.ckGroup10.TabIndex = 18;
            this.ckGroup10.Text = "其他";
            this.ckGroup10.UseVisualStyleBackColor = true;
            this.ckGroup10.CheckedChanged += new System.EventHandler(this.ckGroup10_CheckedChanged);
            // 
            // ckGroup5
            // 
            this.ckGroup5.AutoSize = true;
            this.ckGroup5.Location = new System.Drawing.Point(361, 9);
            this.ckGroup5.Name = "ckGroup5";
            this.ckGroup5.Size = new System.Drawing.Size(108, 24);
            this.ckGroup5.TabIndex = 13;
            this.ckGroup5.Text = "视力模糊";
            this.ckGroup5.UseVisualStyleBackColor = true;
            // 
            // ckGroup4
            // 
            this.ckGroup4.AutoSize = true;
            this.ckGroup4.Location = new System.Drawing.Point(278, 9);
            this.ckGroup4.Name = "ckGroup4";
            this.ckGroup4.Size = new System.Drawing.Size(68, 24);
            this.ckGroup4.TabIndex = 12;
            this.ckGroup4.Text = "多尿";
            this.ckGroup4.UseVisualStyleBackColor = true;
            // 
            // ckGroup3
            // 
            this.ckGroup3.AutoSize = true;
            this.ckGroup3.Location = new System.Drawing.Point(192, 10);
            this.ckGroup3.Name = "ckGroup3";
            this.ckGroup3.Size = new System.Drawing.Size(68, 24);
            this.ckGroup3.TabIndex = 11;
            this.ckGroup3.Text = "多食";
            this.ckGroup3.UseVisualStyleBackColor = true;
            // 
            // ckGroup2
            // 
            this.ckGroup2.AutoSize = true;
            this.ckGroup2.Location = new System.Drawing.Point(111, 10);
            this.ckGroup2.Name = "ckGroup2";
            this.ckGroup2.Size = new System.Drawing.Size(68, 24);
            this.ckGroup2.TabIndex = 10;
            this.ckGroup2.Text = "多饮";
            this.ckGroup2.UseVisualStyleBackColor = true;
            // 
            // ckGroup1
            // 
            this.ckGroup1.AutoSize = true;
            this.ckGroup1.Location = new System.Drawing.Point(5, 10);
            this.ckGroup1.Name = "ckGroup1";
            this.ckGroup1.Size = new System.Drawing.Size(88, 24);
            this.ckGroup1.TabIndex = 9;
            this.ckGroup1.Text = "无症状";
            this.ckGroup1.UseVisualStyleBackColor = true;
            // 
            // tbZzOther
            // 
            this.tbZzOther.Location = new System.Drawing.Point(1030, 28);
            this.tbZzOther.MaxLength = 100;
            this.tbZzOther.Multiline = true;
            this.tbZzOther.Name = "tbZzOther";
            this.tbZzOther.ReadOnly = true;
            this.tbZzOther.Size = new System.Drawing.Size(252, 34);
            this.tbZzOther.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbWeightTarget);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.label57);
            this.groupBox2.Controls.Add(this.label53);
            this.groupBox2.Controls.Add(this.btnBMI);
            this.groupBox2.Controls.Add(this.btnNextBMI);
            this.groupBox2.Controls.Add(this.label46);
            this.groupBox2.Controls.Add(this.btnWeightNext);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.cbxZbdmbd);
            this.groupBox2.Controls.Add(this.tbTzzsTarget);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnWeight);
            this.groupBox2.Controls.Add(this.btnXueya);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbTzzs);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbhight);
            this.groupBox2.Controls.Add(this.tbOther);
            this.groupBox2.Controls.Add(this.label48);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.tbWeight);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.tbXueya);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox2.Location = new System.Drawing.Point(23, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1359, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "体征";
            // 
            // tbWeightTarget
            // 
            this.tbWeightTarget.Location = new System.Drawing.Point(410, 61);
            this.tbWeightTarget.MaxLength = 5;
            this.tbWeightTarget.Name = "tbWeightTarget";
            this.tbWeightTarget.Size = new System.Drawing.Size(73, 30);
            this.tbWeightTarget.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbzb3);
            this.panel3.Controls.Add(this.rbzb2);
            this.panel3.Controls.Add(this.rbzb1);
            this.panel3.Font = new System.Drawing.Font("宋体", 15F);
            this.panel3.Location = new System.Drawing.Point(1128, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 29);
            this.panel3.TabIndex = 39;
            // 
            // rbzb3
            // 
            this.rbzb3.AutoSize = true;
            this.rbzb3.Location = new System.Drawing.Point(157, 2);
            this.rbzb3.Name = "rbzb3";
            this.rbzb3.Size = new System.Drawing.Size(67, 24);
            this.rbzb3.TabIndex = 3;
            this.rbzb3.TabStop = true;
            this.rbzb3.Text = "右侧";
            this.rbzb3.UseVisualStyleBackColor = true;
            // 
            // rbzb2
            // 
            this.rbzb2.AutoSize = true;
            this.rbzb2.Location = new System.Drawing.Point(80, 3);
            this.rbzb2.Name = "rbzb2";
            this.rbzb2.Size = new System.Drawing.Size(67, 24);
            this.rbzb2.TabIndex = 2;
            this.rbzb2.TabStop = true;
            this.rbzb2.Text = "左侧";
            this.rbzb2.UseVisualStyleBackColor = true;
            // 
            // rbzb1
            // 
            this.rbzb1.AutoSize = true;
            this.rbzb1.Location = new System.Drawing.Point(5, 3);
            this.rbzb1.Name = "rbzb1";
            this.rbzb1.Size = new System.Drawing.Size(67, 24);
            this.rbzb1.TabIndex = 1;
            this.rbzb1.TabStop = true;
            this.rbzb1.Text = "双侧";
            this.rbzb1.UseVisualStyleBackColor = true;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("宋体", 15F);
            this.label58.Location = new System.Drawing.Point(874, 24);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(59, 20);
            this.label58.TabIndex = 38;
            this.label58.Text = "Kg/㎡";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("宋体", 15F);
            this.label57.Location = new System.Drawing.Point(486, 25);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(59, 20);
            this.label57.TabIndex = 38;
            this.label57.Text = "Kg/㎡";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(793, 67);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(29, 20);
            this.label53.TabIndex = 37;
            this.label53.Text = "cm";
            // 
            // btnBMI
            // 
            this.btnBMI.Location = new System.Drawing.Point(549, 19);
            this.btnBMI.Name = "btnBMI";
            this.btnBMI.Size = new System.Drawing.Size(70, 27);
            this.btnBMI.TabIndex = 4;
            this.btnBMI.Text = "计算";
            this.btnBMI.UseVisualStyleBackColor = true;
            this.btnBMI.Click += new System.EventHandler(this.btnBMI_Click);
            // 
            // btnNextBMI
            // 
            this.btnNextBMI.Location = new System.Drawing.Point(938, 21);
            this.btnNextBMI.Name = "btnNextBMI";
            this.btnNextBMI.Size = new System.Drawing.Size(65, 27);
            this.btnNextBMI.TabIndex = 4;
            this.btnNextBMI.Text = "计算";
            this.btnNextBMI.UseVisualStyleBackColor = true;
            this.btnNextBMI.Click += new System.EventHandler(this.btnNextBMI_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 15F);
            this.label46.Location = new System.Drawing.Point(173, 69);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(29, 20);
            this.label46.TabIndex = 36;
            this.label46.Text = "Kg";
            // 
            // btnWeightNext
            // 
            this.btnWeightNext.Location = new System.Drawing.Point(549, 60);
            this.btnWeightNext.Name = "btnWeightNext";
            this.btnWeightNext.Size = new System.Drawing.Size(70, 27);
            this.btnWeightNext.TabIndex = 9;
            this.btnWeightNext.Text = "计算";
            this.btnWeightNext.UseVisualStyleBackColor = true;
            this.btnWeightNext.Click += new System.EventHandler(this.btnWeightNext_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 15F);
            this.label45.Location = new System.Drawing.Point(492, 65);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(29, 20);
            this.label45.TabIndex = 35;
            this.label45.Text = "Kg";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 15F);
            this.label44.Location = new System.Drawing.Point(164, 25);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(49, 20);
            this.label44.TabIndex = 33;
            this.label44.Text = "mmHg";
            // 
            // cbxZbdmbd
            // 
            this.cbxZbdmbd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxZbdmbd.FormattingEnabled = true;
            this.cbxZbdmbd.Items.AddRange(new object[] {
            "触及正常         ",
            "减弱",
            "消失"});
            this.cbxZbdmbd.Location = new System.Drawing.Point(980, 62);
            this.cbxZbdmbd.Name = "cbxZbdmbd";
            this.cbxZbdmbd.Size = new System.Drawing.Size(142, 28);
            this.cbxZbdmbd.TabIndex = 5;
            this.cbxZbdmbd.SelectedIndexChanged += new System.EventHandler(this.cbxZbdmbd_SelectedIndexChanged);
            // 
            // tbTzzsTarget
            // 
            this.tbTzzsTarget.Location = new System.Drawing.Point(784, 20);
            this.tbTzzsTarget.MaxLength = 6;
            this.tbTzzsTarget.Name = "tbTzzsTarget";
            this.tbTzzsTarget.Size = new System.Drawing.Size(86, 30);
            this.tbTzzsTarget.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "下次随访目标";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(636, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "下次随访目标";
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(219, 61);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(37, 27);
            this.btnWeight.TabIndex = 7;
            this.btnWeight.Text = "..";
            this.btnWeight.UseVisualStyleBackColor = true;
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // btnXueya
            // 
            this.btnXueya.Location = new System.Drawing.Point(219, 20);
            this.btnXueya.Name = "btnXueya";
            this.btnXueya.Size = new System.Drawing.Size(37, 27);
            this.btnXueya.TabIndex = 1;
            this.btnXueya.Text = "..";
            this.btnXueya.UseVisualStyleBackColor = true;
            this.btnXueya.Click += new System.EventHandler(this.btnXueya_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(831, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "足背动脉搏动";
            // 
            // tbTzzs
            // 
            this.tbTzzs.Location = new System.Drawing.Point(411, 21);
            this.tbTzzs.MaxLength = 6;
            this.tbTzzs.Name = "tbTzzs";
            this.tbTzzs.Size = new System.Drawing.Size(71, 30);
            this.tbTzzs.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "体质指数";
            // 
            // tbhight
            // 
            this.tbhight.Location = new System.Drawing.Point(699, 63);
            this.tbhight.MaxLength = 100;
            this.tbhight.Name = "tbhight";
            this.tbhight.Size = new System.Drawing.Size(85, 30);
            this.tbhight.TabIndex = 10;
            // 
            // tbOther
            // 
            this.tbOther.Location = new System.Drawing.Point(1098, 23);
            this.tbOther.MaxLength = 100;
            this.tbOther.Name = "tbOther";
            this.tbOther.Size = new System.Drawing.Size(173, 30);
            this.tbOther.TabIndex = 11;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(644, 68);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(49, 20);
            this.label48.TabIndex = 6;
            this.label48.Text = "身高";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(1040, 27);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(49, 20);
            this.label29.TabIndex = 6;
            this.label29.Text = "其他";
            // 
            // tbWeight
            // 
            this.tbWeight.Location = new System.Drawing.Point(76, 61);
            this.tbWeight.MaxLength = 5;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(84, 30);
            this.tbWeight.TabIndex = 6;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(19, 65);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(49, 20);
            this.label41.TabIndex = 2;
            this.label41.Text = "体重";
            // 
            // tbXueya
            // 
            this.tbXueya.Location = new System.Drawing.Point(76, 21);
            this.tbXueya.Name = "tbXueya";
            this.tbXueya.Size = new System.Drawing.Size(86, 30);
            this.tbXueya.TabIndex = 0;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(19, 26);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(49, 20);
            this.label42.TabIndex = 0;
            this.label42.Text = "血压";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lkYs);
            this.groupBox6.Controls.Add(this.picSignYs);
            this.groupBox6.Controls.Add(this.label54);
            this.groupBox6.Controls.Add(this.lkJm);
            this.groupBox6.Controls.Add(this.picSignJm);
            this.groupBox6.Controls.Add(this.label65);
            this.groupBox6.Controls.Add(this.tbRemark);
            this.groupBox6.Controls.Add(this.label64);
            this.groupBox6.Controls.Add(this.panel7);
            this.groupBox6.Controls.Add(this.label62);
            this.groupBox6.Controls.Add(this.txtReferralContacts);
            this.groupBox6.Controls.Add(this.label63);
            this.groupBox6.Controls.Add(this.panel5);
            this.groupBox6.Controls.Add(this.linkLabel1);
            this.groupBox6.Controls.Add(this.label56);
            this.groupBox6.Controls.Add(this.dtpNext);
            this.groupBox6.Controls.Add(this.tbJgkb);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Controls.Add(this.tbZzyy);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox6.Location = new System.Drawing.Point(19, 856);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1358, 214);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            // 
            // lkYs
            // 
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(388, 167);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 182;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(112, 137);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(199, 65);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 180;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("宋体", 15F);
            this.label54.Location = new System.Drawing.Point(5, 151);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(99, 20);
            this.label54.TabIndex = 179;
            this.label54.Text = "医生签名:";
            // 
            // lkJm
            // 
            this.lkJm.AutoSize = true;
            this.lkJm.Location = new System.Drawing.Point(1070, 167);
            this.lkJm.Name = "lkJm";
            this.lkJm.Size = new System.Drawing.Size(89, 20);
            this.lkJm.TabIndex = 170;
            this.lkJm.TabStop = true;
            this.lkJm.Text = "重置签名";
            this.lkJm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // picSignJm
            // 
            this.picSignJm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJm.Location = new System.Drawing.Point(794, 137);
            this.picSignJm.Name = "picSignJm";
            this.picSignJm.Size = new System.Drawing.Size(199, 65);
            this.picSignJm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJm.TabIndex = 168;
            this.picSignJm.TabStop = false;
            this.picSignJm.Click += new System.EventHandler(this.picSignJm_Click);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("宋体", 15F);
            this.label65.Location = new System.Drawing.Point(688, 151);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(99, 20);
            this.label65.TabIndex = 167;
            this.label65.Text = "居民签字:";
            // 
            // tbRemark
            // 
            this.tbRemark.Location = new System.Drawing.Point(111, 88);
            this.tbRemark.MaxLength = 100;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(455, 30);
            this.tbRemark.TabIndex = 166;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("宋体", 15F);
            this.label64.Location = new System.Drawing.Point(45, 96);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(59, 20);
            this.label64.TabIndex = 165;
            this.label64.Text = "备注:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.rddw);
            this.panel7.Controls.Add(this.rdwdw);
            this.panel7.Enabled = false;
            this.panel7.Location = new System.Drawing.Point(793, 55);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 34);
            this.panel7.TabIndex = 164;
            // 
            // rddw
            // 
            this.rddw.AutoSize = true;
            this.rddw.Location = new System.Drawing.Point(8, 6);
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
            this.rdwdw.Location = new System.Drawing.Point(90, 6);
            this.rdwdw.Name = "rdwdw";
            this.rdwdw.Size = new System.Drawing.Size(87, 24);
            this.rdwdw.TabIndex = 153;
            this.rdwdw.TabStop = true;
            this.rdwdw.Text = "不到位";
            this.rdwdw.UseVisualStyleBackColor = true;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(721, 61);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(59, 20);
            this.label62.TabIndex = 163;
            this.label62.Text = "结 果";
            // 
            // txtReferralContacts
            // 
            this.txtReferralContacts.Location = new System.Drawing.Point(393, 56);
            this.txtReferralContacts.MaxLength = 20;
            this.txtReferralContacts.Name = "txtReferralContacts";
            this.txtReferralContacts.ReadOnly = true;
            this.txtReferralContacts.Size = new System.Drawing.Size(173, 30);
            this.txtReferralContacts.TabIndex = 162;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(252, 58);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(129, 20);
            this.label63.TabIndex = 161;
            this.label63.Text = "联系人及电话";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rdzzno);
            this.panel5.Controls.Add(this.rdzzyes);
            this.panel5.Location = new System.Drawing.Point(113, 13);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(134, 31);
            this.panel5.TabIndex = 0;
            // 
            // rdzzno
            // 
            this.rdzzno.AutoSize = true;
            this.rdzzno.Location = new System.Drawing.Point(70, 5);
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
            this.rdzzyes.Location = new System.Drawing.Point(5, 5);
            this.rdzzyes.Name = "rdzzyes";
            this.rdzzyes.Size = new System.Drawing.Size(47, 24);
            this.rdzzyes.TabIndex = 0;
            this.rdzzyes.TabStop = true;
            this.rdzzyes.Text = "是";
            this.rdzzyes.UseVisualStyleBackColor = true;
            this.rdzzyes.CheckedChanged += new System.EventHandler(this.rdzzyes_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.Location = new System.Drawing.Point(1014, 64);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(114, 20);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "编辑常用药";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(15, 20);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(89, 20);
            this.label56.TabIndex = 89;
            this.label56.Text = "转诊情况";
            // 
            // dtpNext
            // 
            this.dtpNext.Font = new System.Drawing.Font("宋体", 15F);
            this.dtpNext.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNext.Location = new System.Drawing.Point(793, 95);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(173, 30);
            this.dtpNext.TabIndex = 3;
            // 
            // tbJgkb
            // 
            this.tbJgkb.Location = new System.Drawing.Point(793, 14);
            this.tbJgkb.MaxLength = 100;
            this.tbJgkb.Name = "tbJgkb";
            this.tbJgkb.ReadOnly = true;
            this.tbJgkb.Size = new System.Drawing.Size(173, 30);
            this.tbJgkb.TabIndex = 2;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 15F);
            this.label36.Location = new System.Drawing.Point(648, 101);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(139, 20);
            this.label36.TabIndex = 43;
            this.label36.Text = "下次随访日期:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(671, 19);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(109, 20);
            this.label37.TabIndex = 4;
            this.label37.Text = "机构及科别";
            // 
            // tbZzyy
            // 
            this.tbZzyy.Location = new System.Drawing.Point(392, 16);
            this.tbZzyy.MaxLength = 100;
            this.tbZzyy.Name = "tbZzyy";
            this.tbZzyy.ReadOnly = true;
            this.tbZzyy.Size = new System.Drawing.Size(175, 30);
            this.tbZzyy.TabIndex = 1;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(292, 19);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(89, 20);
            this.label38.TabIndex = 0;
            this.label38.Text = "转诊原因";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox9);
            this.groupBox5.Controls.Add(this.tbYdsyf);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.tbYdszl);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this.yongYaoQK3);
            this.groupBox5.Controls.Add(this.yongYaoQK2);
            this.groupBox5.Controls.Add(this.yongYaoQK1);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox5.Location = new System.Drawing.Point(23, 621);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1358, 112);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "用药情况";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tbYdsyf1);
            this.groupBox9.Controls.Add(this.label67);
            this.groupBox9.Controls.Add(this.tbYdszl1);
            this.groupBox9.Controls.Add(this.label66);
            this.groupBox9.Controls.Add(this.yongYaoYCQK3);
            this.groupBox9.Controls.Add(this.yongYaoYCQK2);
            this.groupBox9.Controls.Add(this.yongYaoYCQK1);
            this.groupBox9.Location = new System.Drawing.Point(0, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1358, 112);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "用药情况";
            // 
            // tbYdsyf1
            // 
            this.tbYdsyf1.Location = new System.Drawing.Point(1165, 70);
            this.tbYdsyf1.Name = "tbYdsyf1";
            this.tbYdsyf1.Size = new System.Drawing.Size(169, 30);
            this.tbYdsyf1.TabIndex = 6;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(1040, 73);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(119, 20);
            this.label67.TabIndex = 5;
            this.label67.Text = "用法和用量:";
            // 
            // tbYdszl1
            // 
            this.tbYdszl1.Location = new System.Drawing.Point(827, 70);
            this.tbYdszl1.Name = "tbYdszl1";
            this.tbYdszl1.Size = new System.Drawing.Size(176, 30);
            this.tbYdszl1.TabIndex = 4;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(703, 73);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(119, 20);
            this.label66.TabIndex = 3;
            this.label66.Text = "胰岛素种类:";
            // 
            // yongYaoYCQK3
            // 
            this.yongYaoYCQK3.ErrorInput = false;
            this.yongYaoYCQK3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYCQK3.Location = new System.Drawing.Point(7, 63);
            this.yongYaoYCQK3.Margin = new System.Windows.Forms.Padding(9);
            this.yongYaoYCQK3.MText = "药物名称3";
            this.yongYaoYCQK3.Name = "yongYaoYCQK3";
            this.yongYaoYCQK3.Size = new System.Drawing.Size(654, 37);
            this.yongYaoYCQK3.Source.DailyTime = null;
            this.yongYaoYCQK3.Source.DosAge = null;
            this.yongYaoYCQK3.Source.drugtype = null;
            this.yongYaoYCQK3.Source.EveryTimeMg = null;
            this.yongYaoYCQK3.Source.factory = null;
            this.yongYaoYCQK3.Source.ID = 0;
            this.yongYaoYCQK3.Source.IDCardNo = null;
            this.yongYaoYCQK3.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoYCQK3.Source.Name = null;
            this.yongYaoYCQK3.Source.OUTKey = 0;
            this.yongYaoYCQK3.Source.Type = null;
            this.yongYaoYCQK3.TabIndex = 0;
            // 
            // yongYaoYCQK2
            // 
            this.yongYaoYCQK2.ErrorInput = false;
            this.yongYaoYCQK2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYCQK2.Location = new System.Drawing.Point(713, 18);
            this.yongYaoYCQK2.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYCQK2.MText = "药物名称2";
            this.yongYaoYCQK2.Name = "yongYaoYCQK2";
            this.yongYaoYCQK2.Size = new System.Drawing.Size(638, 37);
            this.yongYaoYCQK2.Source.DailyTime = null;
            this.yongYaoYCQK2.Source.DosAge = null;
            this.yongYaoYCQK2.Source.drugtype = null;
            this.yongYaoYCQK2.Source.EveryTimeMg = null;
            this.yongYaoYCQK2.Source.factory = null;
            this.yongYaoYCQK2.Source.ID = 0;
            this.yongYaoYCQK2.Source.IDCardNo = null;
            this.yongYaoYCQK2.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoYCQK2.Source.Name = null;
            this.yongYaoYCQK2.Source.OUTKey = 0;
            this.yongYaoYCQK2.Source.Type = null;
            this.yongYaoYCQK2.TabIndex = 1;
            // 
            // yongYaoYCQK1
            // 
            this.yongYaoYCQK1.ErrorInput = false;
            this.yongYaoYCQK1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoYCQK1.Location = new System.Drawing.Point(7, 18);
            this.yongYaoYCQK1.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoYCQK1.MText = "药物名称1";
            this.yongYaoYCQK1.Name = "yongYaoYCQK1";
            this.yongYaoYCQK1.Size = new System.Drawing.Size(706, 41);
            this.yongYaoYCQK1.Source.DailyTime = null;
            this.yongYaoYCQK1.Source.DosAge = null;
            this.yongYaoYCQK1.Source.drugtype = null;
            this.yongYaoYCQK1.Source.EveryTimeMg = null;
            this.yongYaoYCQK1.Source.factory = null;
            this.yongYaoYCQK1.Source.ID = 0;
            this.yongYaoYCQK1.Source.IDCardNo = null;
            this.yongYaoYCQK1.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoYCQK1.Source.Name = null;
            this.yongYaoYCQK1.Source.OUTKey = 0;
            this.yongYaoYCQK1.Source.Type = null;
            this.yongYaoYCQK1.TabIndex = 2;
            // 
            // tbYdsyf
            // 
            this.tbYdsyf.Location = new System.Drawing.Point(1111, 75);
            this.tbYdsyf.MaxLength = 20;
            this.tbYdsyf.Name = "tbYdsyf";
            this.tbYdsyf.Size = new System.Drawing.Size(223, 30);
            this.tbYdsyf.TabIndex = 7;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(987, 78);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(119, 20);
            this.label34.TabIndex = 6;
            this.label34.Text = "用法和用量:";
            // 
            // tbYdszl
            // 
            this.tbYdszl.Location = new System.Drawing.Point(790, 75);
            this.tbYdszl.MaxLength = 256;
            this.tbYdszl.Name = "tbYdszl";
            this.tbYdszl.Size = new System.Drawing.Size(146, 30);
            this.tbYdszl.TabIndex = 5;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(676, 84);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(119, 20);
            this.label33.TabIndex = 4;
            this.label33.Text = "胰岛素种类:";
            // 
            // yongYaoQK3
            // 
            this.yongYaoQK3.ErrorInput = false;
            this.yongYaoQK3.Font = new System.Drawing.Font("宋体", 15F);
            this.yongYaoQK3.Location = new System.Drawing.Point(3, 73);
            this.yongYaoQK3.Margin = new System.Windows.Forms.Padding(5);
            this.yongYaoQK3.MText = "药物名称3";
            this.yongYaoQK3.Name = "yongYaoQK3";
            this.yongYaoQK3.Size = new System.Drawing.Size(664, 34);
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
            this.yongYaoQK2.Location = new System.Drawing.Point(680, 23);
            this.yongYaoQK2.Margin = new System.Windows.Forms.Padding(5);
            this.yongYaoQK2.MText = "药物名称2";
            this.yongYaoQK2.Name = "yongYaoQK2";
            this.yongYaoQK2.Size = new System.Drawing.Size(674, 34);
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
            this.yongYaoQK1.Location = new System.Drawing.Point(3, 23);
            this.yongYaoQK1.Margin = new System.Windows.Forms.Padding(5);
            this.yongYaoQK1.MText = "药物名称1";
            this.yongYaoQK1.Name = "yongYaoQK1";
            this.yongYaoQK1.Size = new System.Drawing.Size(668, 40);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxMainFoodTarget);
            this.groupBox3.Controls.Add(this.btnNoDrink);
            this.groupBox3.Controls.Add(this.btnNoSmoke);
            this.groupBox3.Controls.Add(this.cbxSportMinTarget);
            this.groupBox3.Controls.Add(this.cbxSportCountTarget);
            this.groupBox3.Controls.Add(this.cbxSportMin);
            this.groupBox3.Controls.Add(this.cbxSportCount);
            this.groupBox3.Controls.Add(this.cbxMainFood);
            this.groupBox3.Controls.Add(this.label39);
            this.groupBox3.Controls.Add(this.label40);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.tbDrinkTarget);
            this.groupBox3.Controls.Add(this.tbSmokeTarget);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.cbxZyxw);
            this.groupBox3.Controls.Add(this.cbxXltz);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbDrink);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbSmoke);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox3.Location = new System.Drawing.Point(23, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1358, 152);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "生活方式指导";
            // 
            // cbxMainFoodTarget
            // 
            this.cbxMainFoodTarget.FormattingEnabled = true;
            this.cbxMainFoodTarget.Items.AddRange(new object[] {
            "600",
            "500",
            "400"});
            this.cbxMainFoodTarget.Location = new System.Drawing.Point(434, 111);
            this.cbxMainFoodTarget.Name = "cbxMainFoodTarget";
            this.cbxMainFoodTarget.Size = new System.Drawing.Size(84, 28);
            this.cbxMainFoodTarget.TabIndex = 11;
            // 
            // btnNoDrink
            // 
            this.btnNoDrink.Location = new System.Drawing.Point(1178, 26);
            this.btnNoDrink.Name = "btnNoDrink";
            this.btnNoDrink.Size = new System.Drawing.Size(65, 27);
            this.btnNoDrink.TabIndex = 5;
            this.btnNoDrink.Text = "戒酒";
            this.btnNoDrink.UseVisualStyleBackColor = true;
            this.btnNoDrink.Click += new System.EventHandler(this.btnNoDrink_Click);
            // 
            // btnNoSmoke
            // 
            this.btnNoSmoke.Location = new System.Drawing.Point(559, 25);
            this.btnNoSmoke.Name = "btnNoSmoke";
            this.btnNoSmoke.Size = new System.Drawing.Size(67, 29);
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
            this.cbxSportMinTarget.Location = new System.Drawing.Point(934, 69);
            this.cbxSportMinTarget.Name = "cbxSportMinTarget";
            this.cbxSportMinTarget.Size = new System.Drawing.Size(83, 28);
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
            this.cbxSportCountTarget.Location = new System.Drawing.Point(791, 71);
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
            this.cbxSportMin.Location = new System.Drawing.Point(298, 71);
            this.cbxSportMin.Name = "cbxSportMin";
            this.cbxSportMin.Size = new System.Drawing.Size(84, 28);
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
            this.cbxSportCount.Location = new System.Drawing.Point(121, 69);
            this.cbxSportCount.Name = "cbxSportCount";
            this.cbxSportCount.Size = new System.Drawing.Size(82, 28);
            this.cbxSportCount.TabIndex = 6;
            // 
            // cbxMainFood
            // 
            this.cbxMainFood.FormattingEnabled = true;
            this.cbxMainFood.Items.AddRange(new object[] {
            "1000",
            "800",
            "600",
            "500"});
            this.cbxMainFood.Location = new System.Drawing.Point(121, 111);
            this.cbxMainFood.Name = "cbxMainFood";
            this.cbxMainFood.Size = new System.Drawing.Size(86, 28);
            this.cbxMainFood.TabIndex = 10;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(524, 115);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(59, 20);
            this.label39.TabIndex = 46;
            this.label39.Text = "克/天";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(293, 114);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(129, 20);
            this.label40.TabIndex = 44;
            this.label40.Text = "下次随访目标";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(206, 116);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(59, 20);
            this.label35.TabIndex = 43;
            this.label35.Text = "克/天";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1025, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "分钟/次";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(877, 74);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(59, 20);
            this.label30.TabIndex = 39;
            this.label30.Text = "次/周";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(650, 73);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(129, 20);
            this.label31.TabIndex = 37;
            this.label31.Text = "下次随访目标";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(1143, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 20);
            this.label27.TabIndex = 36;
            this.label27.Text = "两";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(933, 33);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(129, 20);
            this.label28.TabIndex = 34;
            this.label28.Text = "下次随访目标";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(515, 30);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 20);
            this.label25.TabIndex = 33;
            this.label25.Text = "支";
            // 
            // tbDrinkTarget
            // 
            this.tbDrinkTarget.Location = new System.Drawing.Point(1071, 26);
            this.tbDrinkTarget.MaxLength = 2;
            this.tbDrinkTarget.Name = "tbDrinkTarget";
            this.tbDrinkTarget.Size = new System.Drawing.Size(67, 30);
            this.tbDrinkTarget.TabIndex = 4;
            // 
            // tbSmokeTarget
            // 
            this.tbSmokeTarget.Location = new System.Drawing.Point(436, 24);
            this.tbSmokeTarget.MaxLength = 2;
            this.tbSmokeTarget.Name = "tbSmokeTarget";
            this.tbSmokeTarget.Size = new System.Drawing.Size(71, 30);
            this.tbSmokeTarget.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(292, 32);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(129, 20);
            this.label26.TabIndex = 31;
            this.label26.Text = "下次随访目标";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(877, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 20);
            this.label24.TabIndex = 30;
            this.label24.Text = "两";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(206, 32);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 20);
            this.label23.TabIndex = 29;
            this.label23.Text = "支";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(383, 74);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 20);
            this.label22.TabIndex = 28;
            this.label22.Text = "分钟/次";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(206, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 20);
            this.label21.TabIndex = 26;
            this.label21.Text = "次/周";
            // 
            // cbxZyxw
            // 
            this.cbxZyxw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxZyxw.FormattingEnabled = true;
            this.cbxZyxw.Items.AddRange(new object[] {
            "良好",
            "一般",
            "差"});
            this.cbxZyxw.Location = new System.Drawing.Point(1071, 111);
            this.cbxZyxw.Name = "cbxZyxw";
            this.cbxZyxw.Size = new System.Drawing.Size(171, 28);
            this.cbxZyxw.TabIndex = 13;
            // 
            // cbxXltz
            // 
            this.cbxXltz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxXltz.FormattingEnabled = true;
            this.cbxXltz.Items.AddRange(new object[] {
            "良好",
            "一般",
            "差"});
            this.cbxXltz.Location = new System.Drawing.Point(791, 112);
            this.cbxXltz.Name = "cbxXltz";
            this.cbxXltz.Size = new System.Drawing.Size(136, 28);
            this.cbxXltz.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(966, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "遵医行为";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(690, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "心理调整";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "主食";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "运动";
            // 
            // tbDrink
            // 
            this.tbDrink.Location = new System.Drawing.Point(791, 28);
            this.tbDrink.MaxLength = 2;
            this.tbDrink.Name = "tbDrink";
            this.tbDrink.Size = new System.Drawing.Size(84, 30);
            this.tbDrink.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(690, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "日饮酒量";
            // 
            // tbSmoke
            // 
            this.tbSmoke.Location = new System.Drawing.Point(120, 28);
            this.tbSmoke.MaxLength = 2;
            this.tbSmoke.Name = "tbSmoke";
            this.tbSmoke.Size = new System.Drawing.Size(84, 30);
            this.tbSmoke.TabIndex = 0;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(15, 32);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(89, 20);
            this.label32.TabIndex = 0;
            this.label32.Text = "日吸烟量";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbVisitType);
            this.groupBox4.Controls.Add(this.cbNextMeasures);
            this.groupBox4.Controls.Add(this.label59);
            this.groupBox4.Controls.Add(this.tbdorctview);
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Controls.Add(this.label52);
            this.groupBox4.Controls.Add(this.label50);
            this.groupBox4.Controls.Add(this.label47);
            this.groupBox4.Controls.Add(this.tbAidExam);
            this.groupBox4.Controls.Add(this.label51);
            this.groupBox4.Controls.Add(this.label49);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.btnXuetang);
            this.groupBox4.Controls.Add(this.tbBlfyxx);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.dtpCheckTime);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.tbchxt);
            this.groupBox4.Controls.Add(this.tbThxhdb);
            this.groupBox4.Controls.Add(this.tbsjxt);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.tblBG);
            this.groupBox4.Controls.Add(this.cbxDxtfy);
            this.groupBox4.Controls.Add(this.cbxYblfy);
            this.groupBox4.Controls.Add(this.cbxFyycx);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox4.Location = new System.Drawing.Point(23, 421);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1358, 194);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
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
            this.cbVisitType.Location = new System.Drawing.Point(871, 95);
            this.cbVisitType.Name = "cbVisitType";
            this.cbVisitType.Size = new System.Drawing.Size(463, 28);
            this.cbVisitType.TabIndex = 59;
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
            this.cbNextMeasures.Location = new System.Drawing.Point(990, 146);
            this.cbNextMeasures.Name = "cbNextMeasures";
            this.cbNextMeasures.Size = new System.Drawing.Size(344, 28);
            this.cbNextMeasures.TabIndex = 58;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(830, 152);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(149, 20);
            this.label59.TabIndex = 57;
            this.label59.Text = "下一步管理措施";
            // 
            // tbdorctview
            // 
            this.tbdorctview.Location = new System.Drawing.Point(187, 149);
            this.tbdorctview.MaxLength = 500;
            this.tbdorctview.Name = "tbdorctview";
            this.tbdorctview.Size = new System.Drawing.Size(577, 30);
            this.tbdorctview.TabIndex = 14;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(7, 153);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(169, 20);
            this.label55.TabIndex = 13;
            this.label55.Text = "此次随访医生建议";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("宋体", 15F);
            this.label52.Location = new System.Drawing.Point(666, 65);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(69, 20);
            this.label52.TabIndex = 56;
            this.label52.Text = "mmol/L";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 15F);
            this.label50.Location = new System.Drawing.Point(273, 67);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(69, 20);
            this.label50.TabIndex = 56;
            this.label50.Text = "mmol/L";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("宋体", 15F);
            this.label47.Location = new System.Drawing.Point(273, 22);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(69, 20);
            this.label47.TabIndex = 56;
            this.label47.Text = "mmol/L";
            // 
            // tbAidExam
            // 
            this.tbAidExam.Location = new System.Drawing.Point(944, 17);
            this.tbAidExam.MaxLength = 20;
            this.tbAidExam.Name = "tbAidExam";
            this.tbAidExam.Size = new System.Drawing.Size(390, 30);
            this.tbAidExam.TabIndex = 4;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(426, 65);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(139, 20);
            this.label51.TabIndex = 39;
            this.label51.Text = "餐后2小时血糖";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(87, 67);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(89, 20);
            this.label49.TabIndex = 39;
            this.label49.Text = "随机血糖";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(67, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 20);
            this.label16.TabIndex = 39;
            this.label16.Text = "空腹血糖值";
            // 
            // btnXuetang
            // 
            this.btnXuetang.Location = new System.Drawing.Point(348, 17);
            this.btnXuetang.Name = "btnXuetang";
            this.btnXuetang.Size = new System.Drawing.Size(37, 27);
            this.btnXuetang.TabIndex = 1;
            this.btnXuetang.Text = "..";
            this.btnXuetang.UseVisualStyleBackColor = true;
            this.btnXuetang.Click += new System.EventHandler(this.btnXuetang_Click);
            // 
            // tbBlfyxx
            // 
            this.tbBlfyxx.Location = new System.Drawing.Point(270, 106);
            this.tbBlfyxx.MaxLength = 100;
            this.tbBlfyxx.Name = "tbBlfyxx";
            this.tbBlfyxx.Size = new System.Drawing.Size(322, 30);
            this.tbBlfyxx.TabIndex = 10;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(766, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 20);
            this.label20.TabIndex = 34;
            this.label20.Text = "随访分类";
            // 
            // dtpCheckTime
            // 
            this.dtpCheckTime.Font = new System.Drawing.Font("宋体", 15F);
            this.dtpCheckTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckTime.Location = new System.Drawing.Point(797, 17);
            this.dtpCheckTime.Name = "dtpCheckTime";
            this.dtpCheckTime.Size = new System.Drawing.Size(144, 30);
            this.dtpCheckTime.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(709, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 20);
            this.label19.TabIndex = 32;
            this.label19.Text = "检查日期";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(668, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 20);
            this.label17.TabIndex = 31;
            this.label17.Text = "%";
            // 
            // tbchxt
            // 
            this.tbchxt.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.tbchxt.Location = new System.Drawing.Point(577, 62);
            this.tbchxt.MaxLength = 6;
            this.tbchxt.Name = "tbchxt";
            this.tbchxt.Size = new System.Drawing.Size(84, 30);
            this.tbchxt.TabIndex = 6;
            // 
            // tbThxhdb
            // 
            this.tbThxhdb.Location = new System.Drawing.Point(575, 19);
            this.tbThxhdb.MaxLength = 6;
            this.tbThxhdb.Name = "tbThxhdb";
            this.tbThxhdb.Size = new System.Drawing.Size(84, 30);
            this.tbThxhdb.TabIndex = 2;
            // 
            // tbsjxt
            // 
            this.tbsjxt.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.tbsjxt.Location = new System.Drawing.Point(187, 63);
            this.tbsjxt.MaxLength = 6;
            this.tbsjxt.Name = "tbsjxt";
            this.tbsjxt.Size = new System.Drawing.Size(84, 30);
            this.tbsjxt.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(436, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 20);
            this.label18.TabIndex = 29;
            this.label18.Text = "糖化血红蛋白";
            // 
            // tblBG
            // 
            this.tblBG.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.tblBG.Location = new System.Drawing.Point(187, 19);
            this.tblBG.MaxLength = 6;
            this.tblBG.Name = "tblBG";
            this.tblBG.Size = new System.Drawing.Size(84, 30);
            this.tblBG.TabIndex = 0;
            this.tblBG.TextChanged += new System.EventHandler(this.tblBG_TextChanged);
            // 
            // cbxDxtfy
            // 
            this.cbxDxtfy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDxtfy.FormattingEnabled = true;
            this.cbxDxtfy.Items.AddRange(new object[] {
            "无",
            "偶尔",
            "频繁"});
            this.cbxDxtfy.Location = new System.Drawing.Point(870, 61);
            this.cbxDxtfy.Name = "cbxDxtfy";
            this.cbxDxtfy.Size = new System.Drawing.Size(135, 28);
            this.cbxDxtfy.TabIndex = 7;
            // 
            // cbxYblfy
            // 
            this.cbxYblfy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYblfy.FormattingEnabled = true;
            this.cbxYblfy.Items.AddRange(new object[] {
            "无",
            "有"});
            this.cbxYblfy.Location = new System.Drawing.Point(186, 106);
            this.cbxYblfy.Name = "cbxYblfy";
            this.cbxYblfy.Size = new System.Drawing.Size(79, 28);
            this.cbxYblfy.TabIndex = 9;
            // 
            // cbxFyycx
            // 
            this.cbxFyycx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFyycx.FormattingEnabled = true;
            this.cbxFyycx.Items.AddRange(new object[] {
            "规律",
            "间断",
            "不服药"});
            this.cbxFyycx.Location = new System.Drawing.Point(1140, 60);
            this.cbxFyycx.Name = "cbxFyycx";
            this.cbxFyycx.Size = new System.Drawing.Size(194, 28);
            this.cbxFyycx.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(746, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 20);
            this.label12.TabIndex = 9;
            this.label12.Text = "低血糖反应";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(47, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "药物不良反应";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1019, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 20);
            this.label14.TabIndex = 6;
            this.label14.Text = "服药依从性";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDoctor);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dtpVisit);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1358, 63);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // tbDoctor
            // 
            this.tbDoctor.Font = new System.Drawing.Font("宋体", 15F);
            this.tbDoctor.Location = new System.Drawing.Point(489, 21);
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(138, 30);
            this.tbDoctor.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F);
            this.label15.Location = new System.Drawing.Point(392, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 20);
            this.label15.TabIndex = 45;
            this.label15.Text = "随访医生";
            // 
            // dtpVisit
            // 
            this.dtpVisit.Font = new System.Drawing.Font("宋体", 15F);
            this.dtpVisit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVisit.Location = new System.Drawing.Point(115, 19);
            this.dtpVisit.Name = "dtpVisit";
            this.dtpVisit.Size = new System.Drawing.Size(150, 30);
            this.dtpVisit.TabIndex = 0;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 15F);
            this.label43.Location = new System.Drawing.Point(15, 21);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(99, 20);
            this.label43.TabIndex = 41;
            this.label43.Text = "随访日期:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radMZ);
            this.panel1.Controls.Add(this.radsfqt);
            this.panel1.Controls.Add(this.radPhone);
            this.panel1.Controls.Add(this.radFamily);
            this.panel1.Font = new System.Drawing.Font("宋体", 15F);
            this.panel1.Location = new System.Drawing.Point(783, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 36);
            this.panel1.TabIndex = 2;
            // 
            // radMZ
            // 
            this.radMZ.AutoSize = true;
            this.radMZ.Location = new System.Drawing.Point(3, 2);
            this.radMZ.Name = "radMZ";
            this.radMZ.Size = new System.Drawing.Size(67, 24);
            this.radMZ.TabIndex = 0;
            this.radMZ.TabStop = true;
            this.radMZ.Text = "门诊";
            this.radMZ.UseVisualStyleBackColor = true;
            // 
            // radsfqt
            // 
            this.radsfqt.AutoSize = true;
            this.radsfqt.Location = new System.Drawing.Point(325, 2);
            this.radsfqt.Name = "radsfqt";
            this.radsfqt.Size = new System.Drawing.Size(67, 24);
            this.radsfqt.TabIndex = 3;
            this.radsfqt.TabStop = true;
            this.radsfqt.Text = "其他";
            this.radsfqt.UseVisualStyleBackColor = true;
            // 
            // radPhone
            // 
            this.radPhone.AutoSize = true;
            this.radPhone.Location = new System.Drawing.Point(225, 2);
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
            this.radFamily.Location = new System.Drawing.Point(113, 2);
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
            this.label1.Location = new System.Drawing.Point(680, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "随访方式:";
            // 
            // DiaVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "DiaVisitForm";
            this.Text = "DiaVisitForm";
            this.Load += new System.EventHandler(this.FrmDiaFollow_Load);
            this.panel4.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJm)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// 默认项设置
        /// </summary>
        private void PresetValue()
        {
            ChronicDiadetesVisitModel diadetesOldModel = diadetesVisitBll.GetMaxModel(this.Model.IDCardNo);// 获取最新一笔随访数据
            if (diadetesOldModel == null) diadetesOldModel = new ChronicDiadetesVisitModel();
            if (DiabetessFollowupRcd == null) DiabetessFollowupRcd = new ChronicDiadetesVisitModel();

            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = " IsSetValue='是' OR IsSetValue='预设上次体检' ";
            DataTable dt = dv.ToTable();

            DiabetessFollowupRcd = CommonExtensions.EntityAssignment<ChronicDiadetesVisitModel>(diadetesOldModel, DiabetessFollowupRcd, dt);
            DiabetessFollowupRcd.IDCardNo = this.Model.IDCardNo;
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
                        this.DiabetessFollowupRcd.Hypertension = Convert.ToDecimal(xueyadata[0].ToString());
                    }
                    else
                    {
                        this.DiabetessFollowupRcd.Hypertension = null;
                    }
                    if (!string.IsNullOrEmpty(xueyadata[1].ToString()))
                    {
                        this.DiabetessFollowupRcd.Hypotension = Convert.ToDecimal(xueyadata[1].ToString());
                    }
                    else
                    {
                        this.DiabetessFollowupRcd.Hypotension = null;
                    }
                }
                else if (xueyadata.Length == 1)
                {
                    if (this.tbXueya.Text.Substring(0, 1) == "/")
                    {
                        if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                        {
                            this.DiabetessFollowupRcd.Hypertension = null;
                            this.DiabetessFollowupRcd.Hypotension = Convert.ToDecimal(xueyadata[0].ToString());
                        }
                    }
                    else if ((decimal.TryParse(this.tbXueya.Text, out num2)) && (num2 != 0M))
                    {
                        if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                        {
                            this.DiabetessFollowupRcd.Hypertension = Convert.ToDecimal(xueyadata[0].ToString());
                            this.DiabetessFollowupRcd.Hypotension = null;
                        }
                    }
                    else
                    {
                        this.tbXueya.Text = "";
                        this.DiabetessFollowupRcd.Hypertension = null;
                        this.DiabetessFollowupRcd.Hypotension = null;
                    }
                }
            }
            else
            {
                this.DiabetessFollowupRcd.Hypertension = null;
                this.DiabetessFollowupRcd.Hypotension = null;
            }

            ChronicDiadetesVisitModel diavisitmodel1 = diadetesVisitBll.ExistsCheckDate(this.DiabetessFollowupRcd);
            if (diavisitmodel1 != null)
            {
                if (this.IDPerson > 0 && this.visitdate == this.DiabetessFollowupRcd.VisitDate.ToString()) //随访查询中，
                {                                                                                          //随访日期不修改时候，不做提示
                    this.IDPerson = diavisitmodel1.ID;
                    this.DiabetessFollowupRcd.ID = diavisitmodel1.ID;
                    diadetesVisitBll.Update(this.DiabetessFollowupRcd);
                }
                else
                {
                    DialogResult result = DialogResult.OK;
                    result = MessageBox.Show("此日期下已有随访信息，是否进行修改？", "提示", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        diadetesVisitBll.Delete(this.IDPerson);
                        drugConditionBll.DeleteOUTKey(this.IDPerson, "2");
                        this.IDPerson = diavisitmodel1.ID;
                        this.DiabetessFollowupRcd.ID = diavisitmodel1.ID;
                        diadetesVisitBll.Update(this.DiabetessFollowupRcd);
                    }
                    else
                    {

                        return;
                    }
                }
            }
            else
            {
                if (this.IDPerson > 0)
                {
                    diadetesVisitBll.Delete(this.IDPerson);
                    drugConditionBll.DeleteOUTKey(this.IDPerson, "2");
                }
                this.IDPerson = diadetesVisitBll.Add(this.DiabetessFollowupRcd);
            }

            //用药情况
            drugConditionBll.DeleteOUTKey(this.IDPerson, "2");
            for (int i = 0; i < this.DrugConditions.Count; i++)
            {
                DrugConditions[i].OUTKey = this.IDPerson;
                DrugConditions[i].Type = "2";
                if (!string.IsNullOrEmpty(this.DrugConditions[i].Name))
                {
                    drugConditionBll.Add(this.DrugConditions[i]);
                }
            }

            //用药调整情况
            drugConditionBll.DeleteOUTKey(this.IDPerson, "8");
            for (int i = 0; i < this.DrugConditionsTZ.Count; i++)
            {
                DrugConditionsTZ[i].OUTKey = this.IDPerson;
                DrugConditionsTZ[i].Type = "8";
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

        public void SetOther(bool v)
        {
            this.tbZzOther.ReadOnly = v;
            if (v)
            {
                this.tbZzOther.Text = "";
            }
        }

        private void SimpleBinding(TextBox tb, string member, bool formate, DataSourceUpdateMode mode)
        {
            Binding binding = new Binding("Text", this.DiabetessFollowupRcd, member, formate, mode);
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
            if (this.tbhight.Text != "")
            {
                if (tbTzzsTarget.Text != "")
                {
                    double height = Convert.ToDouble(this.tbhight.Text) * (0.01);
                    double height2 = Convert.ToDouble(height * height);
                    double WTarget = Convert.ToDouble(tbTzzsTarget.Text.ToString());
                    tbWeightTarget.Text = ((decimal)(WTarget * height2)).ToString(".00");
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

                        if (tbTzzsTarget.Text != "" && rowGeneralCondition["Height"].ToString() != "")
                        {
                            double height = Convert.ToDouble(rowGeneralCondition["Height"].ToString()) * (0.01);
                            double height2 = Convert.ToDouble(height * height);
                            double WTarget = Convert.ToDouble(tbTzzsTarget.Text.ToString());

                            tbWeightTarget.Text = ((decimal)(WTarget * height2)).ToString(".00");
                        }
                    }
                }
            }
        }

        private void btnBMI_Click(object sender, EventArgs e) //体质指数
        {
            if (this.tbhight.Text != "")
            {
                if (tbWeight.Text != "")
                {
                    double height = Convert.ToDouble(this.tbhight.Text) * (0.01);
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

        private void btnNextBMI_Click(object sender, EventArgs e) // 下次随访体质指数
        {
            if (this.tbhight.Text != "")
            {
                if (tbWeightTarget.Text != "")
                {
                    double height = Convert.ToDouble(this.tbhight.Text) * (0.01);
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
            tbSmokeTarget.Text = "0";
        }

        private void btnNoDrink_Click(object sender, EventArgs e)
        {
            tbDrinkTarget.Text = "0";
        }

        public void UpdataToModel()
        {
            this.DiabetessFollowupRcd.VisitDate = new DateTime?(this.dtpVisit.Value.Date);
            this.DiabetessFollowupRcd.CustomerName = this.Model.CustomerName;

            if (this.radMZ.Checked) this.DiabetessFollowupRcd.VisitWay = "1";
            else if (this.radFamily.Checked) this.DiabetessFollowupRcd.VisitWay = "2";
            else if (this.radPhone.Checked) this.DiabetessFollowupRcd.VisitWay = "3";
            else if (this.radsfqt.Checked) this.DiabetessFollowupRcd.VisitWay = "4";

            this.DiabetessFollowupRcd.DorsalisPedispulse = new decimal?(this.cbxZbdmbd.SelectedIndex + 1);
            this.DiabetessFollowupRcd.PsychoAdjustment = Convert.ToString((int)(this.cbxXltz.SelectedIndex + 1));
            this.DiabetessFollowupRcd.ObeyDoctorBehavior = Convert.ToString((int)(this.cbxZyxw.SelectedIndex + 1));
            this.DiabetessFollowupRcd.ExamDate = new DateTime?(this.dtpCheckTime.Value);
            this.DiabetessFollowupRcd.MedicationCompliance = Convert.ToString((int)(this.cbxFyycx.SelectedIndex + 1));
            this.DiabetessFollowupRcd.Adr = Convert.ToString((int)(this.cbxYblfy.SelectedIndex + 1));
            this.DiabetessFollowupRcd.AdrEx = this.tbBlfyxx.Text;
            this.DiabetessFollowupRcd.HypoglyceMiarreAction = Convert.ToString((int)(this.cbxDxtfy.SelectedIndex + 1));

            // 此次随访分类
            if (this.cbVisitType.SelectedIndex != -1)
            {
                this.DiabetessFollowupRcd.VisitType = Convert.ToString((int)(this.cbVisitType.SelectedIndex + 1));
            }

            // 转诊与否
            if (this.rdzzno.Checked) this.DiabetessFollowupRcd.IsReferral = "2";
            else if (this.rdzzyes.Checked) this.DiabetessFollowupRcd.IsReferral = "1";

            decimal numHight;
            if (decimal.TryParse(this.tbhight.Text, out numHight)) //身高
            {
                this.DiabetessFollowupRcd.Hight = numHight;
            }

            for (int i = 0; i < this.yongyaoyc.Count; i++)
            {
                this.yongyaoyc[i].UpdateSource();

                if (this.yongyaoyc[i].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.DrugConditions.Add(this.yongyaoyc[i].Source);
                }
            }

            for (int i = 0; i < this.yongyaotzyc.Count; i++)
            {
                this.yongyaotzyc[i].UpdateSource();

                if (this.yongyaotzyc[i].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.DrugConditionsTZ.Add(this.yongyaotzyc[i].Source);
                }
            }

            this.DiabetessFollowupRcd.NextVisitDate = new DateTime?(this.dtpNext.Value.Date);

            if (this.rbzb1.Checked)
            {
                this.DiabetessFollowupRcd.DorsalisPedispulseType = "1";
            }
            else if (this.rbzb2.Checked)
            {
                this.DiabetessFollowupRcd.DorsalisPedispulseType = "2";
            }
            else if (this.rbzb3.Checked)
            {
                this.DiabetessFollowupRcd.DorsalisPedispulseType = "3";
            }

            if (this.cbNextMeasures.SelectedIndex != -1)
            {
                this.DiabetessFollowupRcd.NextMeasures = Convert.ToString(this.cbNextMeasures.SelectedIndex + 1);
            }

            if (this.rddw.Checked)
            {
                this.DiabetessFollowupRcd.ReferralResult = "1";
            }
            else if (this.rdwdw.Checked)
            {
                this.DiabetessFollowupRcd.ReferralResult = "2";
            }
            else
            {
                this.DiabetessFollowupRcd.ReferralResult = null;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoseFrm f = new DoseFrm();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        public ChronicDiadetesVisitModel DiabetessFollowupRcd { get; set; }

        private ChronicHypertensionVisitModel HypertensionFollowRcd { get; set; }

        private List<ChronicDrugConditionModel> DrugConditions { get; set; }

        private List<ChronicDrugConditionModel> DrugConditionsTZ { get; set; }//用药调整

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public int IDPerson { get; set; }

        private void ckGroup10_CheckedChanged(object sender, EventArgs e) //症状其他
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

        private void rdzzyes_CheckedChanged(object sender, EventArgs e) //转诊是否
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
                            this.DiabetessFollowupRcd.Hypertension = new decimal?((int.Parse(_result.value1)));
                            this.DiabetessFollowupRcd.Hypotension = new decimal?((int.Parse(_result.value2)));
                            this.tbXueya.Text = _result.value1 + "/" + _result.value2;
                            return;
                        }
                        return;
                    }

                case 0x599:
                    {
                        stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "24");

                        if (devData.HasValue)
                        {
                            if (devData.value1 == ".0") return;

                            this.DiabetessFollowupRcd.FPG = new decimal?((int.Parse(devData.value1)));
                            this.tblBG.Text = devData.value1;

                            if (this.DiabetessFollowupRcd.FPG >= Convert.ToDecimal(16.7))
                            {
                                this.cbNextMeasures.SelectedIndex = 3;
                                this.DiabetessFollowupRcd.NextMeasures = "4";
                                this.cbVisitType.SelectedIndex = 1;
                                this.DiabetessFollowupRcd.VisitType = "2";
                            }
                            else if (this.DiabetessFollowupRcd.FPG >= 7)
                            {
                                this.cbNextMeasures.SelectedIndex = 2;
                                this.DiabetessFollowupRcd.NextMeasures = "3";
                                this.cbVisitType.SelectedIndex = 1;
                                this.DiabetessFollowupRcd.VisitType = "2";
                            }
                            else
                            {
                                this.cbNextMeasures.SelectedIndex = 0;
                                this.DiabetessFollowupRcd.NextMeasures = "1";
                                this.cbVisitType.SelectedIndex = 0;
                                this.DiabetessFollowupRcd.VisitType = "1";
                            }

                            return;
                        }
                        return;
                    }
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

        private void cbxZbdmbd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxZbdmbd.SelectedIndex == 0)//触及正常时
            {
                this.panel3.Enabled = false;
            }
            else
            {
                this.rbzb1.Checked = false;
                this.rbzb2.Checked = false;
                this.rbzb3.Checked = false;
                this.panel3.Enabled = true;
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

        private void tblBG_TextChanged(object sender, EventArgs e)
        {
            if (tblBG.Text != "")
            {
                decimal FPG = Convert.ToDecimal(tblBG.Text);

                if (FPG >= Convert.ToDecimal(16.7))
                {
                    this.cbNextMeasures.SelectedIndex = 3;
                    this.DiabetessFollowupRcd.NextMeasures = "4";
                    this.cbVisitType.SelectedIndex = 1;
                    this.DiabetessFollowupRcd.VisitType = "2";
                }
                else if (FPG >= 7)
                {
                    this.cbNextMeasures.SelectedIndex = 2;
                    this.DiabetessFollowupRcd.NextMeasures = "3";
                    this.cbVisitType.SelectedIndex = 1;
                    this.DiabetessFollowupRcd.VisitType = "2";
                }
                else
                {
                    this.cbNextMeasures.SelectedIndex = 0;
                    this.DiabetessFollowupRcd.NextMeasures = "1";
                    this.cbVisitType.SelectedIndex = 0;
                    this.DiabetessFollowupRcd.VisitType = "1";
                }
            }
        }
    }
}