
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using Femiani.Forms.UI.Input;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FocusGroup.ChronicDisease
{
    public class CHDVisitForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SingleItemT<ChronicChdVisitModel> adverseReaction;
        private JustSingleItem<ChronicChdVisitModel> afterpill;
        private JustSingleItem<ChronicChdVisitModel> apex;
        private SimpleBindingManager<ChronicChdVisitModel> bindingManager;
        private ChronicChdVisitModel chdFollowUp;
        private IContainer components;
        private List<DrugCondions> drugss;
        private Dictionary<string, RadioButton> folDoctor;
        private JustSingleItem<ChronicChdVisitModel> heartRate;
        private JustSingleItem<ChronicChdVisitModel> heartVoice;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private Panel panel1;
        private RadioButton rdHeartRateNo;
        private RadioButton rdHeartRateYes;
        private Label label8;
        private Label label19;
        private Label label21;
        private Button btnSelectHyp;
        private Label label2;
        private Label label3;
        private TextBox tbHype;
        private Label label10;
        private TextBox tbName;
        private Label label45;
        private DateTimePicker dtpNext;
        private Label label46;
        private TextBox tbDoctor;
        private Label label11;
        private DateTimePicker dtpFollowDate;
        private Label label44;
        private ComboBox cbVisitWay;
        private Panel pnzhengz;
        private TextBox tbSyOther;
        private Label label1;
        private CheckBox ckxZhz4;
        private CheckBox ckxZhz3;
        private CheckBox ckxZhz2;
        private Button btnWeight;
        private Label label5;
        private TextBox tbWeight;
        private Label label4;
        private RadioButton rdHeartVocNo;
        private RadioButton rdHeartVocYes;
        private Label label6;
        private RadioButton rdAPEXNo;
        private RadioButton rdAPEXYes;
        private Label label9;
        private RadioButton rdFlwDoctorCrap;
        private RadioButton rdFlwDoctorUsual;
        private RadioButton rdFlwDoctorOk;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label22;
        private Panel panel12;
        private RadioButton rdNoZz;
        private RadioButton rdYesZz;
        private Label label23;
        private TextBox tbZzYy;
        private Label label24;
        private TextBox tbZzKs;
        private RadioButton rdAftPillNo;
        private RadioButton rdAftPillYes;
        private Label label20;
        private TextBox tbAdverseReaction;
        private RadioButton rdAdverseReactionYes;
        private RadioButton rdAdverseReactionNo;
        private Label label43;
        private ComboBox cbxComplance;
        private Label label18;
        private TextBox tbAidCheck;
        private ComboBox cbxSport;
        private ComboBox cbxSmokeWine;
        private ComboBox cbxSalt;
        private List<YongYaoQKUserControl> Yongyao = new List<YongYaoQKUserControl>();
        private List<YongYaoQKUserControlYC> Yongyaoyc = new List<YongYaoQKUserControlYC>();
        private YongYaoQKUserControl yongYao1;
        private YongYaoQKUserControl yongYao2;
        private YongYaoQKUserControl yongYao3;
        private YongYaoQKUserControl yongYao4;
        private YongYaoQKUserControlYC yongYaoyc1;
        private YongYaoQKUserControlYC yongYaoyc2;
        private YongYaoQKUserControlYC yongYaoyc3;
        private YongYaoQKUserControlYC yongYaoyc4;
        private LinkLabel linkLabel1;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private Label label7;
        private Panel panel2;
        private RadioButton rdgxbtype6;
        private RadioButton rdgxbtype5;
        private RadioButton rdgxbtype4;
        private RadioButton rdgxbtype3;
        private RadioButton rdgxbtype2;
        private RadioButton rdgxbtype1;
        private Label label17;
        private CheckBox ckxZhz1;
        private CheckBox ckxZhz9;
        private CheckBox ckxZhz8;
        private CheckBox ckxZhz7;
        private CheckBox ckxZhz6;
        private CheckBox ckxZhz5;
        private GroupBox groupBox8;
        private Panel pnkfzl;
        private CheckBox cktszl4;
        private CheckBox cktszl3;
        private CheckBox cktszl2;
        private Label label30;
        private CheckBox cktszl1;
        private Label label32;
        private TextBox tbsmoke;
        private Label label31;
        private Label label34;
        private TextBox tbxdtjc;
        private Label label33;
        private Label label38;
        private Label label37;
        private TextBox tbminute;
        private TextBox tbsportweek;
        private Label label36;
        private Label label35;
        private Panel panel11;
        private Panel panel10;
        private Panel panel9;
        private Panel panel13;
        private Panel panel14;
        private Panel panel15;
        private Label label40;
        private TextBox tbHeight;
        private Label label50;
        private TextBox tbkfxt;
        private Label label42;
        private Label label49;
        private TextBox tbBMI;
        private Label label39;
        private Label label41;
        private Button btnBMI;
        private Panel pnsffl;
        private CheckBox cksfflbfz;
        private CheckBox cksfflblfy;
        private CheckBox cksfflkzbmy;
        private CheckBox cksfflmy;
        private TextBox tbbfzother;
        private Label label52;
        private TextBox tbdoctorview;
        private ManyCheckboxs<ChronicChdVisitModel> symptom;
        private CheckBox ckxZhz10;
        private Label label27;
        private TextBox tbgmdzdb;
        private Label label26;
        private Label label47;
        private TextBox tbdmdzdb;
        private Label label28;
        private Label label55;
        private TextBox tbdgc;
        private Label label53;
        private TextBox tbgysz;
        private Label label54;
        private Label label48;
        private GroupBox groupBox2;
        private Label label56;
        private TextBox tbxdtydfh;
        private Label label57;
        private TextBox tbxzccjc;
        private Label label59;
        private TextBox tbxjm;
        private Label label58;
        private TextBox tbgzdmzy;
        private TextBox tbdrink;
        private Label label51;
        private Panel pnfywzlcs;
        private CheckBox ckfywzl7;
        private CheckBox ckfywzl6;
        private CheckBox ckfywzl5;
        private CheckBox ckfywzl4;
        private CheckBox ckfywzl3;
        private CheckBox ckfywzl2;
        private CheckBox ckfywzl1;
        private Label label29;
        private CheckBox ckfywzl9;
        private CheckBox ckfywzl8;
        private List<CheckBox> sfflist = new List<CheckBox>();//此次随访分类
        private List<RadioButton> gxblxlist = new List<RadioButton>();//冠心病分类
        private List<CheckBox> tszlist = new List<CheckBox>();//特殊治疗
        private List<CheckBox> nondruglist = new List<CheckBox>();
        private GroupBox groupBox9;//非药物治疗措施
        private string visitdate;

        public CHDVisitForm()
        {
            this.InitializeComponent();
            this.Yongyao.Add(yongYao1);
            this.Yongyao.Add(yongYao2);
            this.Yongyao.Add(yongYao3);
            this.Yongyao.Add(yongYao4);
            this.Yongyaoyc.Add(yongYaoyc1);
            this.Yongyaoyc.Add(yongYaoyc2);
            this.Yongyaoyc.Add(yongYaoyc3);
            this.Yongyaoyc.Add(yongYaoyc4);
            this.sfflist.Add(this.cksfflmy); //此次随访分类
            this.sfflist.Add(this.cksfflkzbmy);
            this.sfflist.Add(this.cksfflblfy);
            this.sfflist.Add(this.cksfflbfz);
            this.gxblxlist.Add(this.rdgxbtype1);//冠心病分类
            this.gxblxlist.Add(this.rdgxbtype2);
            this.gxblxlist.Add(this.rdgxbtype3);
            this.gxblxlist.Add(this.rdgxbtype4);
            this.gxblxlist.Add(this.rdgxbtype5);
            this.gxblxlist.Add(this.rdgxbtype6);
            this.tszlist.Add(this.cktszl1);//特殊治疗
            this.tszlist.Add(this.cktszl2);
            this.tszlist.Add(this.cktszl3);
            this.tszlist.Add(this.cktszl4);
            this.nondruglist.Add(this.ckfywzl1); //非药物治疗措施
            this.nondruglist.Add(this.ckfywzl2);
            this.nondruglist.Add(this.ckfywzl3);
            this.nondruglist.Add(this.ckfywzl4);
            this.nondruglist.Add(this.ckfywzl5);
            this.nondruglist.Add(this.ckfywzl6);
            this.nondruglist.Add(this.ckfywzl7);
            this.nondruglist.Add(this.ckfywzl8);
            this.nondruglist.Add(this.ckfywzl9);
            this.InitEveryOne();
            this.EveryThingIsOk = false;
        }

        private void btnSelectHyp_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "20")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.chdFollowUp.Systolic = new decimal?(int.Parse(select.m_Result.value1));
                this.chdFollowUp.Diastolic = new decimal?(int.Parse(select.m_Result.value2));
                this.tbHype.Text = string.Format("{0}/{1}", this.chdFollowUp.Systolic.Value, this.chdFollowUp.Diastolic.Value);
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

        public ChildFormStatus CheckErrorInput()
        {
            bool flag = false;
            if (this.dtpFollowDate.Value.Date > DateTime.Today)
            {
                flag = true;
                CHDVisitForm follow = this;
                string str = follow.SaveDataInfo + "随访日期不能晚于当前日期!\r\n";
                follow.SaveDataInfo = str;
            }
            if (this.dtpNext.Value.Date < this.dtpFollowDate.Value.Date)
            {
                flag = true;
                CHDVisitForm follow2 = this;
                string str2 = follow2.SaveDataInfo + "下次随访日期不能小于当前随访日期!";
                follow2.SaveDataInfo = str2;
            }
            bool flag3 = ((flag || this.bindingManager.ErrorInput) || (this.symptom.ErrorInput || this.adverseReaction.ErrorInput));
            if (this.bindingManager.ErrorInput)
            {
                CHDVisitForm follow3 = this;
                string str3 = follow3.SaveDataInfo + this.bindingManager.WhatsUp;
                follow3.SaveDataInfo = str3;
            }
            if (flag3 || (this.Yongyaoyc.Count<YongYaoQKUserControlYC>(c => c.ErrorInput) > 0))
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

        private void FrmChdFollow_Load(object sender, EventArgs e)
        {
            this.groupBox9.Visible = true;

            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void InitEveryOne()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("门诊", "1"),
                new ItemDictonaryModel<string>("家庭", "2"),
                new ItemDictonaryModel<string>("电话", "3"),
                new ItemDictonaryModel<string>("其他", "4")
            };
            this.cbVisitWay.DisplayMember = "DISPLAYMEMBER";
            this.cbVisitWay.ValueMember = "VALUEMEMBER";
            this.cbVisitWay.DataSource = list;
            List<ItemDictonaryModel<string>> list2 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("规律", "1"),
                new ItemDictonaryModel<string>("间断", "2"),
                new ItemDictonaryModel<string>("不服药", "3")
            };
            this.cbxComplance.DisplayMember = "DISPLAYMEMBER";
            this.cbxComplance.ValueMember = "VALUEMEMBER";
            this.cbxComplance.DataSource = list2;

            this.folDoctor = new Dictionary<string, RadioButton>();
            this.folDoctor.Add("1", this.rdFlwDoctorOk);
            this.folDoctor.Add("2", this.rdFlwDoctorUsual);
            this.folDoctor.Add("3", this.rdFlwDoctorCrap);
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("Symptom", 7));
            this.inputrange_str.Add(new InputRangeStr("SymptomEx", 200));
            this.inputrange_str.Add(new InputRangeStr("Smoking", 200));
            this.inputrange_str.Add(new InputRangeStr("Sports", 200));
            this.inputrange_str.Add(new InputRangeStr("Salt", 200));
            this.inputrange_str.Add(new InputRangeStr("AssistCheck", 200));
            this.inputrange_str.Add(new InputRangeStr("UntowardEx", 200));
            this.inputrange_str.Add(new InputRangeStr("ReferralReason", 200));
            this.inputrange_str.Add(new InputRangeStr("ReferralDepart", 200));
            this.inputrange_str.Add(new InputRangeStr("VisitDoctor", 20));
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("Systolic", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Diastolic", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Weight", 1000M, false));
        }

        public void InitEveryThing()
        {
            this.groupBox9.Visible = true;

            Func<KeyValuePair<string, RadioButton>, bool> predicate = null;

            if (this.IDPerson > 0)
            {
                //查询标志
                this.chdFollowUp = new ChronicChdVisitBLL().GetModelID(this.IDPerson);
                this.CustomerBaseInfo = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.Model.IDCardNo); //获取用户信息Model
            }
            else
            {
                //新增的标志     
                this.chdFollowUp = new ChronicChdVisitBLL().GetModel(this.Model.IDCardNo);
                this.dtpFollowDate.Value = DateTime.Today.Date;

                if (this.chdFollowUp == null) this.chdFollowUp = new ChronicChdVisitModel();

                if (this.chdFollowUp.VisitDate == null || (this.chdFollowUp.VisitDate != null && this.chdFollowUp.VisitDate.Value != this.dtpFollowDate.Value))
                {
                    this.chdFollowUp.VisitDate = this.dtpFollowDate.Value;
                    this.chdFollowUp.NextVisitDate = DateTime.Today.Date.AddYears(1);
                    this.chdFollowUp.VisitType = "1";
                }

                this.chdFollowUp.IDCardNo = this.Model.IDCardNo;
            }

            if (this.chdFollowUp == null)
            {
                this.chdFollowUp = new ChronicChdVisitModel();
                this.chdFollowUp.IDCardNo = this.Model.IDCardNo;
                this.chdFollowUp.RecordID = this.Model.RecordID;
                this.chdFollowUp.CreateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.chdFollowUp.CreateDate = new DateTime?(DateTime.Today);
                this.chdFollowUp.VisitDate = new DateTime?(DateTime.Today);
                this.chdFollowUp.IsDelete = "N";
                this.DrugConditions = new List<ChronicDrugConditionModel>();
            }
            else
            {
                if (this.chdFollowUp.VisitDate.HasValue)
                {
                    this.dtpFollowDate.Value = this.chdFollowUp.VisitDate.Value;
                    this.visitdate = this.chdFollowUp.VisitDate.ToString();
                }

                this.chdFollowUp.LastUpDateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.chdFollowUp.LastUpDateDate = new DateTime?(DateTime.Today);

                if (this.IDPerson > 0)
                {
                    this.DrugConditions = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '" + this.IDPerson + "' ", this.Model.IDCardNo, "4"));
                }
                else
                {
                    this.DrugConditions = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '" + this.chdFollowUp.ID + "' ", this.Model.IDCardNo, "4"));
                }
            }

            if (this.CustomerBaseInfo == null)
            {
                this.CustomerBaseInfo = new RecordsCustomerBaseInfoModel();
                this.GeneralModel = new RecordsGeneralConditionModel();
                this.AssistCheckModel = new RecordsAssistCheckModel();
            }
            else
            {
                this.GeneralModel = new RecordsGeneralConditionBLL().GetModelByOutKey(this.CustomerBaseInfo.ID);//获取一般情况Model

                if (this.GeneralModel == null) this.GeneralModel = new RecordsGeneralConditionModel();

                this.AssistCheckModel = new RecordsAssistCheckBLL().GetModelByOutKey(this.CustomerBaseInfo.ID);//获取辅助检查Model

                if (this.AssistCheckModel == null) this.AssistCheckModel = new RecordsAssistCheckModel();
            }

            if (this.chdFollowUp.NextVisitDate.HasValue) this.dtpNext.Value = this.chdFollowUp.NextVisitDate.Value;

            if (string.IsNullOrEmpty(this.chdFollowUp.VisitDoctor))
            {
                this.chdFollowUp.VisitDoctor = ConfigHelper.GetNode("doctorName");
            }

            this.bindingManager = new SimpleBindingManager<ChronicChdVisitModel>(this.inputRanges, this.inputrange_str, this.chdFollowUp);

            if (!this.chdFollowUp.Weight.HasValue)
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                if (devData.HasValue)
                {
                    this.chdFollowUp.Weight = new decimal?(decimal.Parse(devData.value1));
                }
            }

            if (!this.chdFollowUp.Systolic.HasValue)
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20", "血压");
                if (_result2.HasValue)
                {
                    this.chdFollowUp.Systolic = new decimal?(decimal.Parse(_result2.value1));
                    this.chdFollowUp.Diastolic = new decimal?(decimal.Parse(_result2.value2));
                }
            }

            this.tbName.Text = this.Model.CustomerName;
            this.bindingManager.SimpleBinding(this.cbVisitWay, "VisitType");
            this.symptom = new ManyCheckboxs<ChronicChdVisitModel>(this.chdFollowUp);
            this.symptom.AddCk(new CheckBox[] { this.ckxZhz1, this.ckxZhz2, this.ckxZhz3, this.ckxZhz4, this.ckxZhz5, this.ckxZhz6, this.ckxZhz7, this.ckxZhz8, this.ckxZhz9, this.ckxZhz10 });
            this.symptom.BindingProperty("Symptom", "");
            this.bindingManager.SimpleBinding(this.tbSyOther, "SymptomEx", false);
            this.bindingManager.SimpleBinding(this.tbWeight, "Weight", true);

            if (!string.IsNullOrEmpty(this.chdFollowUp.Systolic.ToString()) || !(string.IsNullOrEmpty(this.chdFollowUp.Diastolic.ToString())))
            {
                if (string.IsNullOrEmpty(this.chdFollowUp.Systolic.ToString()))
                {
                    this.tbHype.Text = string.Format("/{0}", this.chdFollowUp.Diastolic.ToString());
                }
                else if (string.IsNullOrEmpty(this.chdFollowUp.Diastolic.ToString()))
                {
                    this.tbHype.Text = string.Format("{0}/", this.chdFollowUp.Systolic.ToString());
                }
                else
                {
                    this.tbHype.Text = string.Format("{0}/{1}", this.chdFollowUp.Systolic.ToString(), this.chdFollowUp.Diastolic.ToString());
                }
            }

            JustSingleItem<ChronicChdVisitModel> item = new JustSingleItem<ChronicChdVisitModel>(this.chdFollowUp)
            {
                R1 = this.rdHeartVocNo,
                R2 = this.rdHeartVocYes
            };
            this.heartVoice = item;
            this.heartVoice.BindProperty("HearVoice");

            JustSingleItem<ChronicChdVisitModel> item2 = new JustSingleItem<ChronicChdVisitModel>(this.chdFollowUp)
            {
                R1 = this.rdHeartRateNo,
                R2 = this.rdHeartRateYes
            };
            this.heartRate = item2;
            this.heartRate.BindProperty("HeartRate");

            JustSingleItem<ChronicChdVisitModel> item3 = new JustSingleItem<ChronicChdVisitModel>(this.chdFollowUp)
            {
                R1 = this.rdAPEXNo,
                R2 = this.rdAPEXYes
            };
            this.apex = item3;
            this.apex.BindProperty("Apex");
            this.bindingManager.SimpleBinding(this.cbxSmokeWine, "Smoking", false);
            this.bindingManager.SimpleBinding(this.cbxSport, "Sports", false);
            this.bindingManager.SimpleBinding(this.cbxSalt, "Salt", false);

            if (!string.IsNullOrEmpty(this.chdFollowUp.Action)) //尊医行为
            {
                try
                {
                    if (predicate == null)
                    {
                        predicate = t => t.Key == this.chdFollowUp.Action;
                    }
                    KeyValuePair<string, RadioButton> pair = this.folDoctor.Single<KeyValuePair<string, RadioButton>>(predicate);
                    if (pair.Value != null)
                    {
                        pair.Value.Checked = true;
                    }
                }
                catch (Exception exception)
                {
                    LogHelper.LogError(exception);
                }
            }

            this.bindingManager.SimpleBinding(this.tbAidCheck, "AssistCheck", false);
            JustSingleItem<ChronicChdVisitModel> item4 = new JustSingleItem<ChronicChdVisitModel>(this.chdFollowUp)
            {
                R1 = this.rdAftPillNo,
                R2 = this.rdAftPillYes
            };
            this.afterpill = item4;
            this.afterpill.BindProperty("AfterPill");
            this.bindingManager.SimpleBinding(this.cbxComplance, "Compliance");

            SingleItemT<ChronicChdVisitModel> mt = new SingleItemT<ChronicChdVisitModel>(this.chdFollowUp)
            {
                Name = "服药不良反应",
                Usual = this.rdAdverseReactionNo,
                Unusual = this.rdAdverseReactionYes,
                Info = this.tbAdverseReaction,
                MaxBytesCount = 200
            };
            this.adverseReaction = mt;
            this.adverseReaction.BindProperty("Untoward", "UntowardEx");

            if (!string.IsNullOrEmpty(this.chdFollowUp.ChdType)) //冠心病类型 
            {
                int numchdtype;
                if (int.TryParse(this.chdFollowUp.ChdType, out numchdtype))
                {
                    this.gxblxlist[numchdtype - 1].Checked = true;
                }
            }

            this.bindingManager.SimpleBinding(this.tbHeight, "Height", true);

            if (string.IsNullOrEmpty(this.tbHeight.Text))
            {
                this.tbHeight.Text = this.GeneralModel.Height.ToString();
            }
            this.bindingManager.SimpleBinding(this.tbBMI, "BMI", true);
            if (string.IsNullOrEmpty(this.tbBMI.Text))
            {
                this.tbBMI.Text = this.GeneralModel.BMI.ToString();
            }
            this.bindingManager.SimpleBinding(this.tbkfxt, "FPGL", true);
            if (string.IsNullOrEmpty(this.tbkfxt.Text))
            {
                this.tbkfxt.Text = this.AssistCheckModel.FPGL.ToString();
            }
            this.bindingManager.SimpleBinding(this.tbgmdzdb, "HeiCho", true);
            if (string.IsNullOrEmpty(this.tbgmdzdb.Text))
            {
                this.tbgmdzdb.Text = this.AssistCheckModel.HeiCho.ToString();
            }
            this.bindingManager.SimpleBinding(this.tbdmdzdb, "LowCho", true);
            if (string.IsNullOrEmpty(this.tbdmdzdb.Text))
            {
                this.tbdmdzdb.Text = this.AssistCheckModel.LowCho.ToString();
            }
            this.bindingManager.SimpleBinding(this.tbgysz, "TG", true);//甘油三酯
            if (string.IsNullOrEmpty(this.tbgysz.Text))
            {
                this.tbgysz.Text = this.AssistCheckModel.TG.ToString();
            }
            this.bindingManager.SimpleBinding(this.tbdgc, "TC", true);//总胆固醇
            if (string.IsNullOrEmpty(this.tbdgc.Text))
            {
                this.tbdgc.Text = this.AssistCheckModel.TC.ToString();
            }

            this.bindingManager.SimpleBinding(this.tbxdtjc, "EcgCheckResult", false);
            this.bindingManager.SimpleBinding(this.tbxdtydfh, "EcgExerciseResult", false);
            this.bindingManager.SimpleBinding(this.tbxzccjc, "HeartCheckResult", false);
            this.bindingManager.SimpleBinding(this.tbgzdmzy, "CAG", false);
            this.bindingManager.SimpleBinding(this.tbxjm, "EnzymesResult", false);
            this.bindingManager.SimpleBinding(this.tbsmoke, "SmokeDay", true);
            this.bindingManager.SimpleBinding(this.tbdrink, "DrinkDay", true);
            this.bindingManager.SimpleBindingInt(this.tbsportweek, "SportWeek", true);
            this.bindingManager.SimpleBindingInt(this.tbminute, "SportMinute", true);

            if (!string.IsNullOrEmpty(this.chdFollowUp.FollowType)) //此次随访分类
            {
                string strFollowType = this.chdFollowUp.FollowType;
                char[] Arraysf = new char[] { ',' };
                foreach (string str in strFollowType.Split(Arraysf))
                {
                    int num1;
                    if (int.TryParse(str, out num1))
                    {
                        this.sfflist[num1 - 1].Checked = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.chdFollowUp.SpecialTreated)) //特殊治疗
            {
                string strtszl = this.chdFollowUp.SpecialTreated;
                char[] Arraytszl = new char[] { ',' };
                foreach (string str in strtszl.Split(Arraytszl))
                {
                    int numtszl;
                    if (int.TryParse(str, out numtszl))
                    {
                        this.tszlist[numtszl - 1].Checked = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.chdFollowUp.NondrugTreat)) //非药物治疗措施
            {
                string strnondrug = this.chdFollowUp.NondrugTreat;
                char[] Arraytnondrug = new char[] { ',' };
                foreach (string str in strnondrug.Split(Arraytnondrug))
                {
                    int numtnondrug;
                    if (int.TryParse(str, out numtnondrug))
                    {
                        this.nondruglist[numtnondrug - 1].Checked = true;
                    }
                }
            }

            this.bindingManager.SimpleBinding(this.tbbfzother, "Syndromeother", false);
            this.bindingManager.SimpleBinding(this.tbdoctorview, "DoctorView", false);

            if (!string.IsNullOrEmpty(this.chdFollowUp.IsReferral))
            {
                if (this.chdFollowUp.IsReferral == "1") this.rdYesZz.Checked = true;
                else if (this.chdFollowUp.IsReferral == "2") this.rdNoZz.Checked = true;
            }

            //读取用药情况
            if (File.Exists(Application.StartupPath + "\\dose.xml"))
            {
                DataSet ds = new DataSet();

                ds.ReadXml(Application.StartupPath + "\\dose.xml");

                DataTable dt_yw1 = ds.Tables[0];
                this.yongYaoyc1.setSource(dt_yw1);
                this.yongYaoyc2.setSource(DeepCopy(dt_yw1));
                this.yongYaoyc3.setSource(DeepCopy(dt_yw1));
                this.yongYaoyc4.setSource(DeepCopy(dt_yw1));
            }

            for (int k = 0; k < this.Yongyaoyc.Count; k++)
            {
                if (k < this.DrugConditions.Count)
                {
                    this.Yongyaoyc[k].Source = this.DrugConditions[k];
                }
                else
                {
                    ChronicDrugConditionModel chronicDrugConditionsModel = new ChronicDrugConditionModel
                    {
                        IDCardNo = this.Model.IDCardNo,
                        ModelState = RecordsStateModel.NoValue,
                        Type = "4"
                    };

                    this.Yongyaoyc[k].Source = chronicDrugConditionsModel;
                }
            }

            this.bindingManager.SimpleBinding(this.tbZzYy, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.tbZzKs, "ReferralDepart", false);

            this.bindingManager.SimpleBinding(this.tbDoctor, "VisitDoctor", false);
            this.EveryThingIsOk = true;
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label57 = new System.Windows.Forms.Label();
            this.tbxzccjc = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.tbxjm = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.tbxdtydfh = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.rdAftPillYes = new System.Windows.Forms.RadioButton();
            this.rdAftPillNo = new System.Windows.Forms.RadioButton();
            this.panel13 = new System.Windows.Forms.Panel();
            this.rdHeartRateYes = new System.Windows.Forms.RadioButton();
            this.rdHeartRateNo = new System.Windows.Forms.RadioButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.rdAPEXYes = new System.Windows.Forms.RadioButton();
            this.rdAPEXNo = new System.Windows.Forms.RadioButton();
            this.tbgzdmzy = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tbxdtjc = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.rdHeartVocYes = new System.Windows.Forms.RadioButton();
            this.rdHeartVocNo = new System.Windows.Forms.RadioButton();
            this.label18 = new System.Windows.Forms.Label();
            this.tbAidCheck = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.pnfywzlcs = new System.Windows.Forms.Panel();
            this.ckfywzl7 = new System.Windows.Forms.CheckBox();
            this.ckfywzl6 = new System.Windows.Forms.CheckBox();
            this.ckfywzl5 = new System.Windows.Forms.CheckBox();
            this.ckfywzl4 = new System.Windows.Forms.CheckBox();
            this.ckfywzl9 = new System.Windows.Forms.CheckBox();
            this.ckfywzl3 = new System.Windows.Forms.CheckBox();
            this.ckfywzl8 = new System.Windows.Forms.CheckBox();
            this.ckfywzl2 = new System.Windows.Forms.CheckBox();
            this.ckfywzl1 = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tbdoctorview = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.rdAdverseReactionNo = new System.Windows.Forms.RadioButton();
            this.rdAdverseReactionYes = new System.Windows.Forms.RadioButton();
            this.pnsffl = new System.Windows.Forms.Panel();
            this.tbbfzother = new System.Windows.Forms.TextBox();
            this.cksfflbfz = new System.Windows.Forms.CheckBox();
            this.cksfflblfy = new System.Windows.Forms.CheckBox();
            this.cksfflkzbmy = new System.Windows.Forms.CheckBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rdFlwDoctorOk = new System.Windows.Forms.RadioButton();
            this.rdFlwDoctorUsual = new System.Windows.Forms.RadioButton();
            this.rdFlwDoctorCrap = new System.Windows.Forms.RadioButton();
            this.cksfflmy = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbxComplance = new System.Windows.Forms.ComboBox();
            this.pnkfzl = new System.Windows.Forms.Panel();
            this.cktszl4 = new System.Windows.Forms.CheckBox();
            this.cktszl3 = new System.Windows.Forms.CheckBox();
            this.cktszl2 = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.tbAdverseReaction = new System.Windows.Forms.TextBox();
            this.cktszl1 = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbSyOther = new System.Windows.Forms.TextBox();
            this.pnzhengz = new System.Windows.Forms.Panel();
            this.ckxZhz10 = new System.Windows.Forms.CheckBox();
            this.ckxZhz2 = new System.Windows.Forms.CheckBox();
            this.ckxZhz9 = new System.Windows.Forms.CheckBox();
            this.ckxZhz4 = new System.Windows.Forms.CheckBox();
            this.ckxZhz8 = new System.Windows.Forms.CheckBox();
            this.ckxZhz3 = new System.Windows.Forms.CheckBox();
            this.ckxZhz7 = new System.Windows.Forms.CheckBox();
            this.ckxZhz5 = new System.Windows.Forms.CheckBox();
            this.ckxZhz6 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckxZhz1 = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdgxbtype6 = new System.Windows.Forms.RadioButton();
            this.rdgxbtype5 = new System.Windows.Forms.RadioButton();
            this.rdgxbtype4 = new System.Windows.Forms.RadioButton();
            this.rdgxbtype3 = new System.Windows.Forms.RadioButton();
            this.rdgxbtype2 = new System.Windows.Forms.RadioButton();
            this.rdgxbtype1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.yongYaoyc4 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoyc3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoyc2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoyc1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYao4 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYao3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYao2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYao1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbminute = new System.Windows.Forms.TextBox();
            this.tbsportweek = new System.Windows.Forms.TextBox();
            this.tbdrink = new System.Windows.Forms.TextBox();
            this.tbsmoke = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxSmokeWine = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxSport = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxSalt = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.rdNoZz = new System.Windows.Forms.RadioButton();
            this.rdYesZz = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.tbZzYy = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbZzKs = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBMI = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHype = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectHyp = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.tbdgc = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.tbgysz = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.tbdmdzdb = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbgmdzdb = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.tbkfxt = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.tbBMI = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnWeight = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpFollowDate = new System.Windows.Forms.DateTimePicker();
            this.label44 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.cbVisitWay = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.pnfywzlcs.SuspendLayout();
            this.panel15.SuspendLayout();
            this.pnsffl.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnkfzl.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.pnzhengz.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel12.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(26, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1434, 652);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label57);
            this.groupBox2.Controls.Add(this.tbxzccjc);
            this.groupBox2.Controls.Add(this.label59);
            this.groupBox2.Controls.Add(this.tbxjm);
            this.groupBox2.Controls.Add(this.label56);
            this.groupBox2.Controls.Add(this.tbxdtydfh);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.panel14);
            this.groupBox2.Controls.Add(this.panel13);
            this.groupBox2.Controls.Add(this.panel11);
            this.groupBox2.Controls.Add(this.tbgzdmzy);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.tbxdtjc);
            this.groupBox2.Controls.Add(this.panel9);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.tbAidCheck);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Location = new System.Drawing.Point(55, 401);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1354, 180);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "辅助检查";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(963, 27);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(179, 20);
            this.label57.TabIndex = 246;
            this.label57.Text = "心脏彩超检查结果:";
            // 
            // tbxzccjc
            // 
            this.tbxzccjc.Location = new System.Drawing.Point(1153, 23);
            this.tbxzccjc.Name = "tbxzccjc";
            this.tbxzccjc.Size = new System.Drawing.Size(191, 30);
            this.tbxzccjc.TabIndex = 2;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(487, 61);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(179, 20);
            this.label59.TabIndex = 246;
            this.label59.Text = "心肌酶学检查结果:";
            // 
            // tbxjm
            // 
            this.tbxjm.Location = new System.Drawing.Point(676, 56);
            this.tbxjm.Name = "tbxjm";
            this.tbxjm.Size = new System.Drawing.Size(191, 30);
            this.tbxjm.TabIndex = 4;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(427, 27);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(239, 20);
            this.label56.TabIndex = 246;
            this.label56.Text = "心电图运动负荷试验结果:";
            // 
            // tbxdtydfh
            // 
            this.tbxdtydfh.Location = new System.Drawing.Point(677, 23);
            this.tbxdtydfh.Name = "tbxdtydfh";
            this.tbxdtydfh.Size = new System.Drawing.Size(191, 30);
            this.tbxdtydfh.TabIndex = 1;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(8, 61);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(179, 20);
            this.label58.TabIndex = 246;
            this.label58.Text = "冠状动脉造影结果:";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.rdAftPillYes);
            this.panel14.Controls.Add(this.rdAftPillNo);
            this.panel14.Location = new System.Drawing.Point(1155, 91);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(167, 31);
            this.panel14.TabIndex = 8;
            // 
            // rdAftPillYes
            // 
            this.rdAftPillYes.AutoSize = true;
            this.rdAftPillYes.Location = new System.Drawing.Point(6, 6);
            this.rdAftPillYes.Name = "rdAftPillYes";
            this.rdAftPillYes.Size = new System.Drawing.Size(47, 24);
            this.rdAftPillYes.TabIndex = 227;
            this.rdAftPillYes.TabStop = true;
            this.rdAftPillYes.Text = "是";
            this.rdAftPillYes.UseVisualStyleBackColor = true;
            // 
            // rdAftPillNo
            // 
            this.rdAftPillNo.AutoSize = true;
            this.rdAftPillNo.Location = new System.Drawing.Point(76, 6);
            this.rdAftPillNo.Name = "rdAftPillNo";
            this.rdAftPillNo.Size = new System.Drawing.Size(47, 24);
            this.rdAftPillNo.TabIndex = 228;
            this.rdAftPillNo.TabStop = true;
            this.rdAftPillNo.Text = "否";
            this.rdAftPillNo.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.rdHeartRateYes);
            this.panel13.Controls.Add(this.rdHeartRateNo);
            this.panel13.Location = new System.Drawing.Point(302, 92);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(118, 34);
            this.panel13.TabIndex = 6;
            // 
            // rdHeartRateYes
            // 
            this.rdHeartRateYes.AutoSize = true;
            this.rdHeartRateYes.Location = new System.Drawing.Point(5, 6);
            this.rdHeartRateYes.Name = "rdHeartRateYes";
            this.rdHeartRateYes.Size = new System.Drawing.Size(47, 24);
            this.rdHeartRateYes.TabIndex = 227;
            this.rdHeartRateYes.TabStop = true;
            this.rdHeartRateYes.Text = "是";
            this.rdHeartRateYes.UseVisualStyleBackColor = true;
            // 
            // rdHeartRateNo
            // 
            this.rdHeartRateNo.AutoSize = true;
            this.rdHeartRateNo.Location = new System.Drawing.Point(65, 6);
            this.rdHeartRateNo.Name = "rdHeartRateNo";
            this.rdHeartRateNo.Size = new System.Drawing.Size(47, 24);
            this.rdHeartRateNo.TabIndex = 228;
            this.rdHeartRateNo.TabStop = true;
            this.rdHeartRateNo.Text = "否";
            this.rdHeartRateNo.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.rdAPEXYes);
            this.panel11.Controls.Add(this.rdAPEXNo);
            this.panel11.Location = new System.Drawing.Point(675, 92);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(125, 34);
            this.panel11.TabIndex = 7;
            // 
            // rdAPEXYes
            // 
            this.rdAPEXYes.AutoSize = true;
            this.rdAPEXYes.Location = new System.Drawing.Point(3, 6);
            this.rdAPEXYes.Name = "rdAPEXYes";
            this.rdAPEXYes.Size = new System.Drawing.Size(47, 24);
            this.rdAPEXYes.TabIndex = 227;
            this.rdAPEXYes.TabStop = true;
            this.rdAPEXYes.Text = "是";
            this.rdAPEXYes.UseVisualStyleBackColor = true;
            // 
            // rdAPEXNo
            // 
            this.rdAPEXNo.AutoSize = true;
            this.rdAPEXNo.Location = new System.Drawing.Point(65, 6);
            this.rdAPEXNo.Name = "rdAPEXNo";
            this.rdAPEXNo.Size = new System.Drawing.Size(47, 24);
            this.rdAPEXNo.TabIndex = 228;
            this.rdAPEXNo.TabStop = true;
            this.rdAPEXNo.Text = "否";
            this.rdAPEXNo.UseVisualStyleBackColor = true;
            // 
            // tbgzdmzy
            // 
            this.tbgzdmzy.Location = new System.Drawing.Point(196, 57);
            this.tbgzdmzy.Name = "tbgzdmzy";
            this.tbgzdmzy.Size = new System.Drawing.Size(191, 30);
            this.tbgzdmzy.TabIndex = 3;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(28, 27);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(159, 20);
            this.label33.TabIndex = 246;
            this.label33.Text = "心电图检查结果:";
            // 
            // tbxdtjc
            // 
            this.tbxdtjc.Location = new System.Drawing.Point(195, 23);
            this.tbxdtjc.Name = "tbxdtjc";
            this.tbxdtjc.Size = new System.Drawing.Size(191, 30);
            this.tbxdtjc.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.rdHeartVocYes);
            this.panel9.Controls.Add(this.rdHeartVocNo);
            this.panel9.Location = new System.Drawing.Point(1155, 55);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(167, 32);
            this.panel9.TabIndex = 5;
            // 
            // rdHeartVocYes
            // 
            this.rdHeartVocYes.AutoSize = true;
            this.rdHeartVocYes.Location = new System.Drawing.Point(8, 6);
            this.rdHeartVocYes.Name = "rdHeartVocYes";
            this.rdHeartVocYes.Size = new System.Drawing.Size(47, 24);
            this.rdHeartVocYes.TabIndex = 194;
            this.rdHeartVocYes.TabStop = true;
            this.rdHeartVocYes.Text = "是";
            this.rdHeartVocYes.UseVisualStyleBackColor = true;
            // 
            // rdHeartVocNo
            // 
            this.rdHeartVocNo.AutoSize = true;
            this.rdHeartVocNo.Location = new System.Drawing.Point(75, 6);
            this.rdHeartVocNo.Name = "rdHeartVocNo";
            this.rdHeartVocNo.Size = new System.Drawing.Size(47, 24);
            this.rdHeartVocNo.TabIndex = 195;
            this.rdHeartVocNo.TabStop = true;
            this.rdHeartVocNo.Text = "否";
            this.rdHeartVocNo.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(90, 136);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 26);
            this.label18.TabIndex = 231;
            this.label18.Text = "辅助检查:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbAidCheck
            // 
            this.tbAidCheck.Location = new System.Drawing.Point(197, 132);
            this.tbAidCheck.Name = "tbAidCheck";
            this.tbAidCheck.Size = new System.Drawing.Size(852, 30);
            this.tbAidCheck.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(964, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 20);
            this.label6.TabIndex = 193;
            this.label6.Text = "第一心音是否减弱:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(299, 20);
            this.label8.TabIndex = 226;
            this.label8.Text = "心律失常是否闻及早搏心房纤颤:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(447, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 20);
            this.label9.TabIndex = 226;
            this.label9.Text = "心尖部是否闻及奔马律:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(824, 98);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(319, 20);
            this.label19.TabIndex = 226;
            this.label19.Text = "症状出现后服硝酸甘油后是否缓解:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.pnfywzlcs);
            this.groupBox8.Controls.Add(this.ckfywzl1);
            this.groupBox8.Controls.Add(this.label29);
            this.groupBox8.Controls.Add(this.tbdoctorview);
            this.groupBox8.Controls.Add(this.label52);
            this.groupBox8.Controls.Add(this.panel15);
            this.groupBox8.Controls.Add(this.pnsffl);
            this.groupBox8.Controls.Add(this.panel10);
            this.groupBox8.Controls.Add(this.cksfflmy);
            this.groupBox8.Controls.Add(this.label20);
            this.groupBox8.Controls.Add(this.cbxComplance);
            this.groupBox8.Controls.Add(this.pnkfzl);
            this.groupBox8.Controls.Add(this.label30);
            this.groupBox8.Controls.Add(this.label43);
            this.groupBox8.Controls.Add(this.tbAdverseReaction);
            this.groupBox8.Controls.Add(this.cktszl1);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.label21);
            this.groupBox8.Location = new System.Drawing.Point(55, 823);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1354, 233);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            // 
            // pnfywzlcs
            // 
            this.pnfywzlcs.Controls.Add(this.ckfywzl7);
            this.pnfywzlcs.Controls.Add(this.ckfywzl6);
            this.pnfywzlcs.Controls.Add(this.ckfywzl5);
            this.pnfywzlcs.Controls.Add(this.ckfywzl4);
            this.pnfywzlcs.Controls.Add(this.ckfywzl9);
            this.pnfywzlcs.Controls.Add(this.ckfywzl3);
            this.pnfywzlcs.Controls.Add(this.ckfywzl8);
            this.pnfywzlcs.Controls.Add(this.ckfywzl2);
            this.pnfywzlcs.Location = new System.Drawing.Point(319, 90);
            this.pnfywzlcs.Name = "pnfywzlcs";
            this.pnfywzlcs.Size = new System.Drawing.Size(1020, 66);
            this.pnfywzlcs.TabIndex = 7;
            // 
            // ckfywzl7
            // 
            this.ckfywzl7.AutoSize = true;
            this.ckfywzl7.Location = new System.Drawing.Point(743, 4);
            this.ckfywzl7.Name = "ckfywzl7";
            this.ckfywzl7.Size = new System.Drawing.Size(168, 24);
            this.ckfywzl7.TabIndex = 5;
            this.ckfywzl7.Text = "有规律体育运动";
            this.ckfywzl7.UseVisualStyleBackColor = true;
            // 
            // ckfywzl6
            // 
            this.ckfywzl6.AutoSize = true;
            this.ckfywzl6.Location = new System.Drawing.Point(625, 4);
            this.ckfywzl6.Name = "ckfywzl6";
            this.ckfywzl6.Size = new System.Drawing.Size(108, 24);
            this.ckfywzl6.TabIndex = 4;
            this.ckfywzl6.Text = "减轻体重";
            this.ckfywzl6.UseVisualStyleBackColor = true;
            // 
            // ckfywzl5
            // 
            this.ckfywzl5.AutoSize = true;
            this.ckfywzl5.Location = new System.Drawing.Point(466, 4);
            this.ckfywzl5.Name = "ckfywzl5";
            this.ckfywzl5.Size = new System.Drawing.Size(148, 24);
            this.ckfywzl5.TabIndex = 3;
            this.ckfywzl5.Text = "减少膳食脂肪";
            this.ckfywzl5.UseVisualStyleBackColor = true;
            // 
            // ckfywzl4
            // 
            this.ckfywzl4.AutoSize = true;
            this.ckfywzl4.Location = new System.Drawing.Point(270, 4);
            this.ckfywzl4.Name = "ckfywzl4";
            this.ckfywzl4.Size = new System.Drawing.Size(188, 24);
            this.ckfywzl4.TabIndex = 2;
            this.ckfywzl4.Text = "减少饮酒量或戒酒";
            this.ckfywzl4.UseVisualStyleBackColor = true;
            // 
            // ckfywzl9
            // 
            this.ckfywzl9.AutoSize = true;
            this.ckfywzl9.Location = new System.Drawing.Point(270, 39);
            this.ckfywzl9.Name = "ckfywzl9";
            this.ckfywzl9.Size = new System.Drawing.Size(108, 24);
            this.ckfywzl9.TabIndex = 7;
            this.ckfywzl9.Text = "心理指导";
            this.ckfywzl9.UseVisualStyleBackColor = true;
            // 
            // ckfywzl3
            // 
            this.ckfywzl3.AutoSize = true;
            this.ckfywzl3.Location = new System.Drawing.Point(78, 5);
            this.ckfywzl3.Name = "ckfywzl3";
            this.ckfywzl3.Size = new System.Drawing.Size(188, 24);
            this.ckfywzl3.TabIndex = 1;
            this.ckfywzl3.Text = "减少吸烟量或戒烟";
            this.ckfywzl3.UseVisualStyleBackColor = true;
            // 
            // ckfywzl8
            // 
            this.ckfywzl8.AutoSize = true;
            this.ckfywzl8.Location = new System.Drawing.Point(5, 35);
            this.ckfywzl8.Name = "ckfywzl8";
            this.ckfywzl8.Size = new System.Drawing.Size(108, 24);
            this.ckfywzl8.TabIndex = 6;
            this.ckfywzl8.Text = "放松精神";
            this.ckfywzl8.UseVisualStyleBackColor = true;
            // 
            // ckfywzl2
            // 
            this.ckfywzl2.AutoSize = true;
            this.ckfywzl2.Location = new System.Drawing.Point(4, 5);
            this.ckfywzl2.Name = "ckfywzl2";
            this.ckfywzl2.Size = new System.Drawing.Size(68, 24);
            this.ckfywzl2.TabIndex = 0;
            this.ckfywzl2.Text = "限盐";
            this.ckfywzl2.UseVisualStyleBackColor = true;
            // 
            // ckfywzl1
            // 
            this.ckfywzl1.AutoSize = true;
            this.ckfywzl1.Location = new System.Drawing.Point(191, 94);
            this.ckfywzl1.Name = "ckfywzl1";
            this.ckfywzl1.Size = new System.Drawing.Size(128, 24);
            this.ckfywzl1.TabIndex = 6;
            this.ckfywzl1.Text = "未采取措施";
            this.ckfywzl1.UseVisualStyleBackColor = true;
            this.ckfywzl1.CheckedChanged += new System.EventHandler(this.ckfywzl1_CheckedChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(27, 96);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(159, 20);
            this.label29.TabIndex = 262;
            this.label29.Text = "非药物治疗措施:";
            // 
            // tbdoctorview
            // 
            this.tbdoctorview.Location = new System.Drawing.Point(190, 199);
            this.tbdoctorview.Name = "tbdoctorview";
            this.tbdoctorview.Size = new System.Drawing.Size(895, 30);
            this.tbdoctorview.TabIndex = 10;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(7, 205);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(179, 20);
            this.label52.TabIndex = 260;
            this.label52.Text = "本次随访医生建议:";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.rdAdverseReactionNo);
            this.panel15.Controls.Add(this.rdAdverseReactionYes);
            this.panel15.Location = new System.Drawing.Point(951, 16);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(132, 33);
            this.panel15.TabIndex = 2;
            // 
            // rdAdverseReactionNo
            // 
            this.rdAdverseReactionNo.AutoSize = true;
            this.rdAdverseReactionNo.Location = new System.Drawing.Point(3, 5);
            this.rdAdverseReactionNo.Name = "rdAdverseReactionNo";
            this.rdAdverseReactionNo.Size = new System.Drawing.Size(47, 24);
            this.rdAdverseReactionNo.TabIndex = 227;
            this.rdAdverseReactionNo.TabStop = true;
            this.rdAdverseReactionNo.Text = "无";
            this.rdAdverseReactionNo.UseVisualStyleBackColor = true;
            // 
            // rdAdverseReactionYes
            // 
            this.rdAdverseReactionYes.AutoSize = true;
            this.rdAdverseReactionYes.Location = new System.Drawing.Point(79, 5);
            this.rdAdverseReactionYes.Name = "rdAdverseReactionYes";
            this.rdAdverseReactionYes.Size = new System.Drawing.Size(47, 24);
            this.rdAdverseReactionYes.TabIndex = 228;
            this.rdAdverseReactionYes.TabStop = true;
            this.rdAdverseReactionYes.Text = "有";
            this.rdAdverseReactionYes.UseVisualStyleBackColor = true;
            // 
            // pnsffl
            // 
            this.pnsffl.Controls.Add(this.tbbfzother);
            this.pnsffl.Controls.Add(this.cksfflbfz);
            this.pnsffl.Controls.Add(this.cksfflblfy);
            this.pnsffl.Controls.Add(this.cksfflkzbmy);
            this.pnsffl.Location = new System.Drawing.Point(319, 160);
            this.pnsffl.Name = "pnsffl";
            this.pnsffl.Size = new System.Drawing.Size(840, 35);
            this.pnsffl.TabIndex = 9;
            // 
            // tbbfzother
            // 
            this.tbbfzother.Location = new System.Drawing.Point(402, 3);
            this.tbbfzother.Name = "tbbfzother";
            this.tbbfzother.ReadOnly = true;
            this.tbbfzother.Size = new System.Drawing.Size(433, 30);
            this.tbbfzother.TabIndex = 3;
            // 
            // cksfflbfz
            // 
            this.cksfflbfz.AutoSize = true;
            this.cksfflbfz.Location = new System.Drawing.Point(269, 5);
            this.cksfflbfz.Name = "cksfflbfz";
            this.cksfflbfz.Size = new System.Drawing.Size(98, 24);
            this.cksfflbfz.TabIndex = 2;
            this.cksfflbfz.Text = "并发症 ";
            this.cksfflbfz.UseVisualStyleBackColor = true;
            this.cksfflbfz.CheckedChanged += new System.EventHandler(this.cksfflbfz_CheckedChanged);
            // 
            // cksfflblfy
            // 
            this.cksfflblfy.AutoSize = true;
            this.cksfflblfy.Location = new System.Drawing.Point(142, 5);
            this.cksfflblfy.Name = "cksfflblfy";
            this.cksfflblfy.Size = new System.Drawing.Size(108, 24);
            this.cksfflblfy.TabIndex = 1;
            this.cksfflblfy.Text = "不良反应";
            this.cksfflblfy.UseVisualStyleBackColor = true;
            // 
            // cksfflkzbmy
            // 
            this.cksfflkzbmy.AutoSize = true;
            this.cksfflkzbmy.Location = new System.Drawing.Point(4, 5);
            this.cksfflkzbmy.Name = "cksfflkzbmy";
            this.cksfflkzbmy.Size = new System.Drawing.Size(128, 24);
            this.cksfflkzbmy.TabIndex = 0;
            this.cksfflkzbmy.Text = "控制不满意";
            this.cksfflkzbmy.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.rdFlwDoctorOk);
            this.panel10.Controls.Add(this.rdFlwDoctorUsual);
            this.panel10.Controls.Add(this.rdFlwDoctorCrap);
            this.panel10.Location = new System.Drawing.Point(193, 14);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(247, 32);
            this.panel10.TabIndex = 0;
            // 
            // rdFlwDoctorOk
            // 
            this.rdFlwDoctorOk.AutoSize = true;
            this.rdFlwDoctorOk.Location = new System.Drawing.Point(3, 6);
            this.rdFlwDoctorOk.Name = "rdFlwDoctorOk";
            this.rdFlwDoctorOk.Size = new System.Drawing.Size(67, 24);
            this.rdFlwDoctorOk.TabIndex = 0;
            this.rdFlwDoctorOk.TabStop = true;
            this.rdFlwDoctorOk.Text = "良好";
            this.rdFlwDoctorOk.UseVisualStyleBackColor = true;
            // 
            // rdFlwDoctorUsual
            // 
            this.rdFlwDoctorUsual.AutoSize = true;
            this.rdFlwDoctorUsual.Location = new System.Drawing.Point(82, 6);
            this.rdFlwDoctorUsual.Name = "rdFlwDoctorUsual";
            this.rdFlwDoctorUsual.Size = new System.Drawing.Size(67, 24);
            this.rdFlwDoctorUsual.TabIndex = 1;
            this.rdFlwDoctorUsual.TabStop = true;
            this.rdFlwDoctorUsual.Text = "一般";
            this.rdFlwDoctorUsual.UseVisualStyleBackColor = true;
            // 
            // rdFlwDoctorCrap
            // 
            this.rdFlwDoctorCrap.AutoSize = true;
            this.rdFlwDoctorCrap.Location = new System.Drawing.Point(166, 6);
            this.rdFlwDoctorCrap.Name = "rdFlwDoctorCrap";
            this.rdFlwDoctorCrap.Size = new System.Drawing.Size(47, 24);
            this.rdFlwDoctorCrap.TabIndex = 2;
            this.rdFlwDoctorCrap.TabStop = true;
            this.rdFlwDoctorCrap.Text = "差";
            this.rdFlwDoctorCrap.UseVisualStyleBackColor = true;
            // 
            // cksfflmy
            // 
            this.cksfflmy.AutoSize = true;
            this.cksfflmy.Location = new System.Drawing.Point(191, 164);
            this.cksfflmy.Name = "cksfflmy";
            this.cksfflmy.Size = new System.Drawing.Size(108, 24);
            this.cksfflmy.TabIndex = 8;
            this.cksfflmy.Text = "控制满意";
            this.cksfflmy.UseVisualStyleBackColor = true;
            this.cksfflmy.CheckedChanged += new System.EventHandler(this.cksfflmy_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(469, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(119, 20);
            this.label20.TabIndex = 233;
            this.label20.Text = "服药依从性:";
            // 
            // cbxComplance
            // 
            this.cbxComplance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxComplance.FormattingEnabled = true;
            this.cbxComplance.Location = new System.Drawing.Point(595, 19);
            this.cbxComplance.Name = "cbxComplance";
            this.cbxComplance.Size = new System.Drawing.Size(173, 28);
            this.cbxComplance.TabIndex = 1;
            // 
            // pnkfzl
            // 
            this.pnkfzl.Controls.Add(this.cktszl4);
            this.pnkfzl.Controls.Add(this.cktszl3);
            this.pnkfzl.Controls.Add(this.cktszl2);
            this.pnkfzl.Location = new System.Drawing.Point(244, 52);
            this.pnkfzl.Name = "pnkfzl";
            this.pnkfzl.Size = new System.Drawing.Size(543, 32);
            this.pnkfzl.TabIndex = 5;
            // 
            // cktszl4
            // 
            this.cktszl4.AutoSize = true;
            this.cktszl4.Location = new System.Drawing.Point(294, 7);
            this.cktszl4.Name = "cktszl4";
            this.cktszl4.Size = new System.Drawing.Size(88, 24);
            this.cktszl4.TabIndex = 2;
            this.cktszl4.Text = "起搏器";
            this.cktszl4.UseVisualStyleBackColor = true;
            // 
            // cktszl3
            // 
            this.cktszl3.AutoSize = true;
            this.cktszl3.Location = new System.Drawing.Point(165, 7);
            this.cktszl3.Name = "cktszl3";
            this.cktszl3.Size = new System.Drawing.Size(108, 24);
            this.cktszl3.TabIndex = 1;
            this.cktszl3.Text = "介入治疗";
            this.cktszl3.UseVisualStyleBackColor = true;
            // 
            // cktszl2
            // 
            this.cktszl2.AutoSize = true;
            this.cktszl2.Location = new System.Drawing.Point(4, 7);
            this.cktszl2.Name = "cktszl2";
            this.cktszl2.Size = new System.Drawing.Size(148, 24);
            this.cktszl2.TabIndex = 0;
            this.cktszl2.Text = "外科手术治疗";
            this.cktszl2.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(85, 60);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(99, 20);
            this.label30.TabIndex = 217;
            this.label30.Text = "特殊治疗:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(47, 168);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(139, 20);
            this.label43.TabIndex = 236;
            this.label43.Text = "此次随访分类:";
            // 
            // tbAdverseReaction
            // 
            this.tbAdverseReaction.Location = new System.Drawing.Point(1089, 19);
            this.tbAdverseReaction.MaxLength = 100;
            this.tbAdverseReaction.Name = "tbAdverseReaction";
            this.tbAdverseReaction.Size = new System.Drawing.Size(250, 30);
            this.tbAdverseReaction.TabIndex = 3;
            // 
            // cktszl1
            // 
            this.cktszl1.AutoSize = true;
            this.cktszl1.Location = new System.Drawing.Point(190, 59);
            this.cktszl1.Name = "cktszl1";
            this.cktszl1.Size = new System.Drawing.Size(48, 24);
            this.cktszl1.TabIndex = 4;
            this.cktszl1.Text = "无";
            this.cktszl1.UseVisualStyleBackColor = true;
            this.cktszl1.CheckedChanged += new System.EventHandler(this.ckjkzlw_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(87, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 20);
            this.label15.TabIndex = 232;
            this.label15.Text = "遵医行为:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(810, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(139, 20);
            this.label21.TabIndex = 226;
            this.label21.Text = "药物不良反应:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbSyOther);
            this.groupBox7.Controls.Add(this.pnzhengz);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.ckxZhz1);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.panel2);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Location = new System.Drawing.Point(55, 65);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1354, 206);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            // 
            // tbSyOther
            // 
            this.tbSyOther.Location = new System.Drawing.Point(137, 169);
            this.tbSyOther.MaxLength = 100;
            this.tbSyOther.Name = "tbSyOther";
            this.tbSyOther.ReadOnly = true;
            this.tbSyOther.Size = new System.Drawing.Size(967, 30);
            this.tbSyOther.TabIndex = 4;
            // 
            // pnzhengz
            // 
            this.pnzhengz.Controls.Add(this.ckxZhz10);
            this.pnzhengz.Controls.Add(this.ckxZhz2);
            this.pnzhengz.Controls.Add(this.ckxZhz9);
            this.pnzhengz.Controls.Add(this.ckxZhz4);
            this.pnzhengz.Controls.Add(this.ckxZhz8);
            this.pnzhengz.Controls.Add(this.ckxZhz3);
            this.pnzhengz.Controls.Add(this.ckxZhz7);
            this.pnzhengz.Controls.Add(this.ckxZhz5);
            this.pnzhengz.Controls.Add(this.ckxZhz6);
            this.pnzhengz.Location = new System.Drawing.Point(238, 66);
            this.pnzhengz.Margin = new System.Windows.Forms.Padding(0);
            this.pnzhengz.Name = "pnzhengz";
            this.pnzhengz.Size = new System.Drawing.Size(1113, 94);
            this.pnzhengz.TabIndex = 3;
            // 
            // ckxZhz10
            // 
            this.ckxZhz10.AutoSize = true;
            this.ckxZhz10.Location = new System.Drawing.Point(1219, 33);
            this.ckxZhz10.Name = "ckxZhz10";
            this.ckxZhz10.Size = new System.Drawing.Size(188, 24);
            this.ckxZhz10.TabIndex = 8;
            this.ckxZhz10.Text = "10心动过速或过缓";
            this.ckxZhz10.UseVisualStyleBackColor = true;
            // 
            // ckxZhz2
            // 
            this.ckxZhz2.AutoSize = true;
            this.ckxZhz2.Location = new System.Drawing.Point(2, 4);
            this.ckxZhz2.Name = "ckxZhz2";
            this.ckxZhz2.Size = new System.Drawing.Size(848, 24);
            this.ckxZhz2.TabIndex = 0;
            this.ckxZhz2.Text = "2劳累或精神紧张时出现胸骨后或心前区闷痛，并向左肩左上臂放射3-5分钟，休息后自行缓解";
            this.ckxZhz2.UseVisualStyleBackColor = true;
            // 
            // ckxZhz9
            // 
            this.ckxZhz9.AutoSize = true;
            this.ckxZhz9.Location = new System.Drawing.Point(432, 65);
            this.ckxZhz9.Name = "ckxZhz9";
            this.ckxZhz9.Size = new System.Drawing.Size(98, 24);
            this.ckxZhz9.TabIndex = 7;
            this.ckxZhz9.Text = "9上腹痛";
            this.ckxZhz9.UseVisualStyleBackColor = true;
            // 
            // ckxZhz4
            // 
            this.ckxZhz4.AutoSize = true;
            this.ckxZhz4.Location = new System.Drawing.Point(432, 34);
            this.ckxZhz4.Name = "ckxZhz4";
            this.ckxZhz4.Size = new System.Drawing.Size(438, 24);
            this.ckxZhz4.TabIndex = 2;
            this.ckxZhz4.Text = "4反复出现脉搏不齐不明原因心跳过速或过缓者";
            this.ckxZhz4.UseVisualStyleBackColor = true;
            // 
            // ckxZhz8
            // 
            this.ckxZhz8.AutoSize = true;
            this.ckxZhz8.Location = new System.Drawing.Point(132, 65);
            this.ckxZhz8.Name = "ckxZhz8";
            this.ckxZhz8.Size = new System.Drawing.Size(258, 24);
            this.ckxZhz8.TabIndex = 6;
            this.ckxZhz8.Text = "8肩、背等部位放射性疼痛";
            this.ckxZhz8.UseVisualStyleBackColor = true;
            // 
            // ckxZhz3
            // 
            this.ckxZhz3.AutoSize = true;
            this.ckxZhz3.Location = new System.Drawing.Point(2, 34);
            this.ckxZhz3.Name = "ckxZhz3";
            this.ckxZhz3.Size = new System.Drawing.Size(418, 24);
            this.ckxZhz3.TabIndex = 1;
            this.ckxZhz3.Text = "3听到嗓音、饱餐寒冷时出现胸闷胸痛心慌者";
            this.ckxZhz3.UseVisualStyleBackColor = true;
            // 
            // ckxZhz7
            // 
            this.ckxZhz7.AutoSize = true;
            this.ckxZhz7.Location = new System.Drawing.Point(2, 65);
            this.ckxZhz7.Name = "ckxZhz7";
            this.ckxZhz7.Size = new System.Drawing.Size(78, 24);
            this.ckxZhz7.TabIndex = 5;
            this.ckxZhz7.Text = "7心悸";
            this.ckxZhz7.UseVisualStyleBackColor = true;
            // 
            // ckxZhz5
            // 
            this.ckxZhz5.AutoSize = true;
            this.ckxZhz5.Location = new System.Drawing.Point(900, 34);
            this.ckxZhz5.Name = "ckxZhz5";
            this.ckxZhz5.Size = new System.Drawing.Size(78, 24);
            this.ckxZhz5.TabIndex = 3;
            this.ckxZhz5.Text = "5胸痛";
            this.ckxZhz5.UseVisualStyleBackColor = true;
            // 
            // ckxZhz6
            // 
            this.ckxZhz6.AutoSize = true;
            this.ckxZhz6.Location = new System.Drawing.Point(1001, 34);
            this.ckxZhz6.Name = "ckxZhz6";
            this.ckxZhz6.Size = new System.Drawing.Size(78, 24);
            this.ckxZhz6.TabIndex = 4;
            this.ckxZhz6.Text = "6胸闷";
            this.ckxZhz6.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 143;
            this.label1.Text = "其他症状：";
            // 
            // ckxZhz1
            // 
            this.ckxZhz1.AutoSize = true;
            this.ckxZhz1.Location = new System.Drawing.Point(137, 71);
            this.ckxZhz1.Name = "ckxZhz1";
            this.ckxZhz1.Size = new System.Drawing.Size(98, 24);
            this.ckxZhz1.TabIndex = 2;
            this.ckxZhz1.Text = "1无症状";
            this.ckxZhz1.UseVisualStyleBackColor = true;
            this.ckxZhz1.CheckedChanged += new System.EventHandler(this.ckxZhz1_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 20);
            this.label17.TabIndex = 1;
            this.label17.Text = "目前症状:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdgxbtype6);
            this.panel2.Controls.Add(this.rdgxbtype5);
            this.panel2.Controls.Add(this.rdgxbtype4);
            this.panel2.Controls.Add(this.rdgxbtype3);
            this.panel2.Controls.Add(this.rdgxbtype2);
            this.panel2.Controls.Add(this.rdgxbtype1);
            this.panel2.Location = new System.Drawing.Point(137, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1035, 35);
            this.panel2.TabIndex = 0;
            // 
            // rdgxbtype6
            // 
            this.rdgxbtype6.AutoSize = true;
            this.rdgxbtype6.Location = new System.Drawing.Point(805, 4);
            this.rdgxbtype6.Name = "rdgxbtype6";
            this.rdgxbtype6.Size = new System.Drawing.Size(167, 24);
            this.rdgxbtype6.TabIndex = 5;
            this.rdgxbtype6.TabStop = true;
            this.rdgxbtype6.Text = "其他不确定类型";
            this.rdgxbtype6.UseVisualStyleBackColor = true;
            // 
            // rdgxbtype5
            // 
            this.rdgxbtype5.AutoSize = true;
            this.rdgxbtype5.Location = new System.Drawing.Point(696, 4);
            this.rdgxbtype5.Name = "rdgxbtype5";
            this.rdgxbtype5.Size = new System.Drawing.Size(87, 24);
            this.rdgxbtype5.TabIndex = 4;
            this.rdgxbtype5.TabStop = true;
            this.rdgxbtype5.Text = "猝死型";
            this.rdgxbtype5.UseVisualStyleBackColor = true;
            // 
            // rdgxbtype4
            // 
            this.rdgxbtype4.AutoSize = true;
            this.rdgxbtype4.Location = new System.Drawing.Point(512, 4);
            this.rdgxbtype4.Name = "rdgxbtype4";
            this.rdgxbtype4.Size = new System.Drawing.Size(167, 24);
            this.rdgxbtype4.TabIndex = 3;
            this.rdgxbtype4.TabStop = true;
            this.rdgxbtype4.Text = "陈旧性心肌梗死";
            this.rdgxbtype4.UseVisualStyleBackColor = true;
            // 
            // rdgxbtype3
            // 
            this.rdgxbtype3.AutoSize = true;
            this.rdgxbtype3.Location = new System.Drawing.Point(353, 4);
            this.rdgxbtype3.Name = "rdgxbtype3";
            this.rdgxbtype3.Size = new System.Drawing.Size(147, 24);
            this.rdgxbtype3.TabIndex = 2;
            this.rdgxbtype3.TabStop = true;
            this.rdgxbtype3.Text = "急性心肌梗死";
            this.rdgxbtype3.UseVisualStyleBackColor = true;
            // 
            // rdgxbtype2
            // 
            this.rdgxbtype2.AutoSize = true;
            this.rdgxbtype2.Location = new System.Drawing.Point(171, 4);
            this.rdgxbtype2.Name = "rdgxbtype2";
            this.rdgxbtype2.Size = new System.Drawing.Size(167, 24);
            this.rdgxbtype2.TabIndex = 1;
            this.rdgxbtype2.TabStop = true;
            this.rdgxbtype2.Text = "不稳定型心绞痛";
            this.rdgxbtype2.UseVisualStyleBackColor = true;
            // 
            // rdgxbtype1
            // 
            this.rdgxbtype1.AutoSize = true;
            this.rdgxbtype1.Location = new System.Drawing.Point(3, 4);
            this.rdgxbtype1.Name = "rdgxbtype1";
            this.rdgxbtype1.Size = new System.Drawing.Size(147, 24);
            this.rdgxbtype1.TabIndex = 0;
            this.rdgxbtype1.TabStop = true;
            this.rdgxbtype1.Text = "稳定型心绞痛";
            this.rdgxbtype1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "冠心病类型:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox9);
            this.groupBox6.Controls.Add(this.yongYao4);
            this.groupBox6.Controls.Add(this.yongYao3);
            this.groupBox6.Controls.Add(this.yongYao2);
            this.groupBox6.Controls.Add(this.yongYao1);
            this.groupBox6.Location = new System.Drawing.Point(55, 710);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1354, 107);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.yongYaoyc4);
            this.groupBox9.Controls.Add(this.yongYaoyc3);
            this.groupBox9.Controls.Add(this.yongYaoyc2);
            this.groupBox9.Controls.Add(this.yongYaoyc1);
            this.groupBox9.Location = new System.Drawing.Point(0, 1);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1354, 107);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            // 
            // yongYaoyc4
            // 
            this.yongYaoyc4.ErrorInput = false;
            this.yongYaoyc4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoyc4.Location = new System.Drawing.Point(702, 59);
            this.yongYaoyc4.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoyc4.MText = "其他药物";
            this.yongYaoyc4.Name = "yongYaoyc4";
            this.yongYaoyc4.Size = new System.Drawing.Size(639, 39);
            this.yongYaoyc4.Source.DailyTime = null;
            this.yongYaoyc4.Source.DosAge = null;
            this.yongYaoyc4.Source.drugtype = null;
            this.yongYaoyc4.Source.EveryTimeMg = null;
            this.yongYaoyc4.Source.factory = null;
            this.yongYaoyc4.Source.ID = 0;
            this.yongYaoyc4.Source.IDCardNo = null;
            this.yongYaoyc4.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoyc4.Source.Name = null;
            this.yongYaoyc4.Source.OUTKey = 0;
            this.yongYaoyc4.Source.Type = null;
            this.yongYaoyc4.TabIndex = 0;
            // 
            // yongYaoyc3
            // 
            this.yongYaoyc3.ErrorInput = false;
            this.yongYaoyc3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoyc3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.yongYaoyc3.Location = new System.Drawing.Point(6, 61);
            this.yongYaoyc3.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoyc3.MText = "药物名称3";
            this.yongYaoyc3.Name = "yongYaoyc3";
            this.yongYaoyc3.Size = new System.Drawing.Size(638, 38);
            this.yongYaoyc3.Source.DailyTime = null;
            this.yongYaoyc3.Source.DosAge = null;
            this.yongYaoyc3.Source.drugtype = null;
            this.yongYaoyc3.Source.EveryTimeMg = null;
            this.yongYaoyc3.Source.factory = null;
            this.yongYaoyc3.Source.ID = 0;
            this.yongYaoyc3.Source.IDCardNo = null;
            this.yongYaoyc3.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoyc3.Source.Name = null;
            this.yongYaoyc3.Source.OUTKey = 0;
            this.yongYaoyc3.Source.Type = null;
            this.yongYaoyc3.TabIndex = 0;
            // 
            // yongYaoyc2
            // 
            this.yongYaoyc2.ErrorInput = false;
            this.yongYaoyc2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoyc2.Location = new System.Drawing.Point(702, 15);
            this.yongYaoyc2.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoyc2.MText = "药物名称2";
            this.yongYaoyc2.Name = "yongYaoyc2";
            this.yongYaoyc2.Size = new System.Drawing.Size(645, 40);
            this.yongYaoyc2.Source.DailyTime = null;
            this.yongYaoyc2.Source.DosAge = null;
            this.yongYaoyc2.Source.drugtype = null;
            this.yongYaoyc2.Source.EveryTimeMg = null;
            this.yongYaoyc2.Source.factory = null;
            this.yongYaoyc2.Source.ID = 0;
            this.yongYaoyc2.Source.IDCardNo = null;
            this.yongYaoyc2.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoyc2.Source.Name = null;
            this.yongYaoyc2.Source.OUTKey = 0;
            this.yongYaoyc2.Source.Type = null;
            this.yongYaoyc2.TabIndex = 0;
            // 
            // yongYaoyc1
            // 
            this.yongYaoyc1.ErrorInput = false;
            this.yongYaoyc1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoyc1.Location = new System.Drawing.Point(7, 15);
            this.yongYaoyc1.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoyc1.MText = "药物名称1";
            this.yongYaoyc1.Name = "yongYaoyc1";
            this.yongYaoyc1.Size = new System.Drawing.Size(640, 38);
            this.yongYaoyc1.Source.DailyTime = null;
            this.yongYaoyc1.Source.DosAge = null;
            this.yongYaoyc1.Source.drugtype = null;
            this.yongYaoyc1.Source.EveryTimeMg = null;
            this.yongYaoyc1.Source.factory = null;
            this.yongYaoyc1.Source.ID = 0;
            this.yongYaoyc1.Source.IDCardNo = null;
            this.yongYaoyc1.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYaoyc1.Source.Name = null;
            this.yongYaoyc1.Source.OUTKey = 0;
            this.yongYaoyc1.Source.Type = null;
            this.yongYaoyc1.TabIndex = 0;
            // 
            // yongYao4
            // 
            this.yongYao4.ErrorInput = false;
            this.yongYao4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYao4.Location = new System.Drawing.Point(680, 61);
            this.yongYao4.Margin = new System.Windows.Forms.Padding(4);
            this.yongYao4.MText = "其他药物";
            this.yongYao4.Name = "yongYao4";
            this.yongYao4.Size = new System.Drawing.Size(666, 39);
            this.yongYao4.Source.DailyTime = null;
            this.yongYao4.Source.DosAge = null;
            this.yongYao4.Source.drugtype = null;
            this.yongYao4.Source.EveryTimeMg = null;
            this.yongYao4.Source.factory = null;
            this.yongYao4.Source.ID = 0;
            this.yongYao4.Source.IDCardNo = null;
            this.yongYao4.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYao4.Source.Name = null;
            this.yongYao4.Source.OUTKey = 0;
            this.yongYao4.Source.Type = null;
            this.yongYao4.TabIndex = 3;
            // 
            // yongYao3
            // 
            this.yongYao3.ErrorInput = false;
            this.yongYao3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYao3.Location = new System.Drawing.Point(7, 62);
            this.yongYao3.Margin = new System.Windows.Forms.Padding(4);
            this.yongYao3.MText = "药物名称3";
            this.yongYao3.Name = "yongYao3";
            this.yongYao3.Size = new System.Drawing.Size(691, 38);
            this.yongYao3.Source.DailyTime = null;
            this.yongYao3.Source.DosAge = null;
            this.yongYao3.Source.drugtype = null;
            this.yongYao3.Source.EveryTimeMg = null;
            this.yongYao3.Source.factory = null;
            this.yongYao3.Source.ID = 0;
            this.yongYao3.Source.IDCardNo = null;
            this.yongYao3.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYao3.Source.Name = null;
            this.yongYao3.Source.OUTKey = 0;
            this.yongYao3.Source.Type = null;
            this.yongYao3.TabIndex = 2;
            // 
            // yongYao2
            // 
            this.yongYao2.ErrorInput = false;
            this.yongYao2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYao2.Location = new System.Drawing.Point(680, 13);
            this.yongYao2.Margin = new System.Windows.Forms.Padding(4);
            this.yongYao2.MText = "药物名称2";
            this.yongYao2.Name = "yongYao2";
            this.yongYao2.Size = new System.Drawing.Size(666, 39);
            this.yongYao2.Source.DailyTime = null;
            this.yongYao2.Source.DosAge = null;
            this.yongYao2.Source.drugtype = null;
            this.yongYao2.Source.EveryTimeMg = null;
            this.yongYao2.Source.factory = null;
            this.yongYao2.Source.ID = 0;
            this.yongYao2.Source.IDCardNo = null;
            this.yongYao2.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYao2.Source.Name = null;
            this.yongYao2.Source.OUTKey = 0;
            this.yongYao2.Source.Type = null;
            this.yongYao2.TabIndex = 1;
            // 
            // yongYao1
            // 
            this.yongYao1.ErrorInput = false;
            this.yongYao1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYao1.Location = new System.Drawing.Point(7, 13);
            this.yongYao1.Margin = new System.Windows.Forms.Padding(4);
            this.yongYao1.MText = "药物名称1";
            this.yongYao1.Name = "yongYao1";
            this.yongYao1.Size = new System.Drawing.Size(691, 39);
            this.yongYao1.Source.DailyTime = null;
            this.yongYao1.Source.DosAge = null;
            this.yongYao1.Source.drugtype = null;
            this.yongYao1.Source.EveryTimeMg = null;
            this.yongYao1.Source.factory = null;
            this.yongYao1.Source.ID = 0;
            this.yongYao1.Source.IDCardNo = null;
            this.yongYao1.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.yongYao1.Source.Name = null;
            this.yongYao1.Source.OUTKey = 0;
            this.yongYao1.Source.Type = null;
            this.yongYao1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label38);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.label37);
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.tbminute);
            this.groupBox5.Controls.Add(this.tbsportweek);
            this.groupBox5.Controls.Add(this.tbdrink);
            this.groupBox5.Controls.Add(this.tbsmoke);
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.label35);
            this.groupBox5.Controls.Add(this.label51);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.cbxSmokeWine);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.cbxSport);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.cbxSalt);
            this.groupBox5.Location = new System.Drawing.Point(55, 590);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1354, 115);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "行为危险因素";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(623, 67);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(99, 20);
            this.label38.TabIndex = 248;
            this.label38.Text = "(分钟/次)";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(639, 29);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(79, 20);
            this.label34.TabIndex = 248;
            this.label34.Text = "(两/天)";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(292, 68);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(79, 20);
            this.label37.TabIndex = 248;
            this.label37.Text = "(次/周)";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(292, 30);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(79, 20);
            this.label32.TabIndex = 248;
            this.label32.Text = "(支/天)";
            // 
            // tbminute
            // 
            this.tbminute.Location = new System.Drawing.Point(542, 64);
            this.tbminute.Name = "tbminute";
            this.tbminute.Size = new System.Drawing.Size(71, 30);
            this.tbminute.TabIndex = 5;
            // 
            // tbsportweek
            // 
            this.tbsportweek.Location = new System.Drawing.Point(197, 64);
            this.tbsportweek.Name = "tbsportweek";
            this.tbsportweek.Size = new System.Drawing.Size(93, 30);
            this.tbsportweek.TabIndex = 4;
            // 
            // tbdrink
            // 
            this.tbdrink.Location = new System.Drawing.Point(542, 26);
            this.tbdrink.Name = "tbdrink";
            this.tbdrink.Size = new System.Drawing.Size(93, 30);
            this.tbdrink.TabIndex = 1;
            // 
            // tbsmoke
            // 
            this.tbsmoke.Location = new System.Drawing.Point(197, 26);
            this.tbsmoke.Name = "tbsmoke";
            this.tbsmoke.Size = new System.Drawing.Size(93, 30);
            this.tbsmoke.TabIndex = 0;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(391, 67);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(139, 20);
            this.label36.TabIndex = 246;
            this.label36.Text = "每次持续时间:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(88, 68);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(99, 20);
            this.label35.TabIndex = 246;
            this.label35.Text = "运动频率:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(431, 30);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(99, 20);
            this.label51.TabIndex = 246;
            this.label51.Text = "日饮酒量:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(88, 30);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(99, 20);
            this.label31.TabIndex = 246;
            this.label31.Text = "吸烟情况:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(742, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 20);
            this.label12.TabIndex = 226;
            this.label12.Text = "烟酒注意事项:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxSmokeWine
            // 
            this.cbxSmokeWine.FormattingEnabled = true;
            this.cbxSmokeWine.Items.AddRange(new object[] {
            "戒烟戒酒"});
            this.cbxSmokeWine.Location = new System.Drawing.Point(887, 25);
            this.cbxSmokeWine.Name = "cbxSmokeWine";
            this.cbxSmokeWine.Size = new System.Drawing.Size(118, 28);
            this.cbxSmokeWine.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(742, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 20);
            this.label13.TabIndex = 228;
            this.label13.Text = "运动注意事项:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxSport
            // 
            this.cbxSport.FormattingEnabled = true;
            this.cbxSport.Items.AddRange(new object[] {
            "适量运动"});
            this.cbxSport.Location = new System.Drawing.Point(890, 64);
            this.cbxSport.Name = "cbxSport";
            this.cbxSport.Size = new System.Drawing.Size(116, 28);
            this.cbxSport.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(1020, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(139, 20);
            this.label14.TabIndex = 230;
            this.label14.Text = "摄盐注意事项:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxSalt
            // 
            this.cbxSalt.FormattingEnabled = true;
            this.cbxSalt.Items.AddRange(new object[] {
            "每天/每人6克盐"});
            this.cbxSalt.Location = new System.Drawing.Point(1167, 27);
            this.cbxSalt.Name = "cbxSalt";
            this.cbxSalt.Size = new System.Drawing.Size(132, 28);
            this.cbxSalt.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.panel12);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.tbZzYy);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.tbZzKs);
            this.groupBox4.Controls.Add(this.label45);
            this.groupBox4.Controls.Add(this.dtpNext);
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Location = new System.Drawing.Point(55, 1062);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1354, 53);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(87, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 20);
            this.label22.TabIndex = 190;
            this.label22.Text = "是否转诊:";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.rdNoZz);
            this.panel12.Controls.Add(this.rdYesZz);
            this.panel12.Location = new System.Drawing.Point(186, 17);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(146, 30);
            this.panel12.TabIndex = 0;
            // 
            // rdNoZz
            // 
            this.rdNoZz.AutoSize = true;
            this.rdNoZz.Location = new System.Drawing.Point(75, 1);
            this.rdNoZz.Name = "rdNoZz";
            this.rdNoZz.Size = new System.Drawing.Size(47, 24);
            this.rdNoZz.TabIndex = 1;
            this.rdNoZz.TabStop = true;
            this.rdNoZz.Text = "否";
            this.rdNoZz.UseVisualStyleBackColor = true;
            // 
            // rdYesZz
            // 
            this.rdYesZz.AutoSize = true;
            this.rdYesZz.Location = new System.Drawing.Point(11, 1);
            this.rdYesZz.Name = "rdYesZz";
            this.rdYesZz.Size = new System.Drawing.Size(47, 24);
            this.rdYesZz.TabIndex = 0;
            this.rdYesZz.TabStop = true;
            this.rdYesZz.Text = "是";
            this.rdYesZz.UseVisualStyleBackColor = true;
            this.rdYesZz.CheckedChanged += new System.EventHandler(this.rdYesZz_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(349, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 20);
            this.label23.TabIndex = 1;
            this.label23.Text = "转诊原因:";
            // 
            // tbZzYy
            // 
            this.tbZzYy.Location = new System.Drawing.Point(449, 17);
            this.tbZzYy.MaxLength = 20;
            this.tbZzYy.Name = "tbZzYy";
            this.tbZzYy.ReadOnly = true;
            this.tbZzYy.Size = new System.Drawing.Size(144, 30);
            this.tbZzYy.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(620, 21);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(159, 20);
            this.label24.TabIndex = 194;
            this.label24.Text = "转诊机构及科别:";
            // 
            // tbZzKs
            // 
            this.tbZzKs.Location = new System.Drawing.Point(783, 17);
            this.tbZzKs.MaxLength = 20;
            this.tbZzKs.Name = "tbZzKs";
            this.tbZzKs.ReadOnly = true;
            this.tbZzKs.Size = new System.Drawing.Size(125, 30);
            this.tbZzKs.TabIndex = 3;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.Location = new System.Drawing.Point(922, 20);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(139, 20);
            this.label45.TabIndex = 217;
            this.label45.Text = "下次随访日期:";
            // 
            // dtpNext
            // 
            this.dtpNext.Location = new System.Drawing.Point(1064, 16);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(180, 30);
            this.dtpNext.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(1251, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.linkLabel1.Size = new System.Drawing.Size(96, 16);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "编辑常用药";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBMI);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbHype);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnSelectHyp);
            this.groupBox3.Controls.Add(this.label40);
            this.groupBox3.Controls.Add(this.tbHeight);
            this.groupBox3.Controls.Add(this.label55);
            this.groupBox3.Controls.Add(this.tbdgc);
            this.groupBox3.Controls.Add(this.label53);
            this.groupBox3.Controls.Add(this.tbgysz);
            this.groupBox3.Controls.Add(this.label47);
            this.groupBox3.Controls.Add(this.tbdmdzdb);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.tbgmdzdb);
            this.groupBox3.Controls.Add(this.label54);
            this.groupBox3.Controls.Add(this.label50);
            this.groupBox3.Controls.Add(this.label48);
            this.groupBox3.Controls.Add(this.tbkfxt);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label42);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label49);
            this.groupBox3.Controls.Add(this.tbBMI);
            this.groupBox3.Controls.Add(this.label39);
            this.groupBox3.Controls.Add(this.label41);
            this.groupBox3.Controls.Add(this.tbWeight);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnWeight);
            this.groupBox3.Location = new System.Drawing.Point(55, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1354, 103);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "体检结果";
            // 
            // btnBMI
            // 
            this.btnBMI.Location = new System.Drawing.Point(979, 28);
            this.btnBMI.Name = "btnBMI";
            this.btnBMI.Size = new System.Drawing.Size(68, 26);
            this.btnBMI.TabIndex = 7;
            this.btnBMI.Text = "计算";
            this.btnBMI.UseVisualStyleBackColor = true;
            this.btnBMI.Click += new System.EventHandler(this.btnBMI_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(84, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 189;
            this.label2.Text = "血压:";
            // 
            // tbHype
            // 
            this.tbHype.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHype.ForeColor = System.Drawing.Color.Black;
            this.tbHype.Location = new System.Drawing.Point(150, 24);
            this.tbHype.Multiline = true;
            this.tbHype.Name = "tbHype";
            this.tbHype.Size = new System.Drawing.Size(78, 25);
            this.tbHype.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(232, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 145;
            this.label3.Text = "mmhg";
            // 
            // btnSelectHyp
            // 
            this.btnSelectHyp.Location = new System.Drawing.Point(288, 21);
            this.btnSelectHyp.Name = "btnSelectHyp";
            this.btnSelectHyp.Size = new System.Drawing.Size(44, 29);
            this.btnSelectHyp.TabIndex = 1;
            this.btnSelectHyp.Text = ".....";
            this.btnSelectHyp.UseVisualStyleBackColor = true;
            this.btnSelectHyp.Click += new System.EventHandler(this.btnSelectHyp_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(354, 28);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(59, 20);
            this.label40.TabIndex = 223;
            this.label40.Text = "身高:";
            // 
            // tbHeight
            // 
            this.tbHeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHeight.ForeColor = System.Drawing.Color.Black;
            this.tbHeight.Location = new System.Drawing.Point(425, 25);
            this.tbHeight.MaxLength = 6;
            this.tbHeight.Multiline = true;
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(77, 23);
            this.tbHeight.TabIndex = 2;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.Location = new System.Drawing.Point(1013, 68);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(79, 20);
            this.label55.TabIndex = 223;
            this.label55.Text = "胆固醇:";
            // 
            // tbdgc
            // 
            this.tbdgc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbdgc.ForeColor = System.Drawing.Color.Black;
            this.tbdgc.Location = new System.Drawing.Point(1097, 65);
            this.tbdgc.MaxLength = 6;
            this.tbdgc.Multiline = true;
            this.tbdgc.Name = "tbdgc";
            this.tbdgc.Size = new System.Drawing.Size(60, 23);
            this.tbdgc.TabIndex = 13;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label53.Location = new System.Drawing.Point(701, 67);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(99, 20);
            this.label53.TabIndex = 223;
            this.label53.Text = "甘油三脂:";
            // 
            // tbgysz
            // 
            this.tbgysz.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbgysz.ForeColor = System.Drawing.Color.Black;
            this.tbgysz.Location = new System.Drawing.Point(806, 64);
            this.tbgysz.MaxLength = 6;
            this.tbgysz.Multiline = true;
            this.tbgysz.Name = "tbgysz";
            this.tbgysz.Size = new System.Drawing.Size(72, 23);
            this.tbgysz.TabIndex = 12;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.Location = new System.Drawing.Point(360, 70);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(139, 20);
            this.label47.TabIndex = 223;
            this.label47.Text = "低密度脂蛋白:";
            // 
            // tbdmdzdb
            // 
            this.tbdmdzdb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbdmdzdb.ForeColor = System.Drawing.Color.Black;
            this.tbdmdzdb.Location = new System.Drawing.Point(514, 67);
            this.tbdmdzdb.MaxLength = 6;
            this.tbdmdzdb.Multiline = true;
            this.tbdmdzdb.Name = "tbdmdzdb";
            this.tbdmdzdb.Size = new System.Drawing.Size(70, 23);
            this.tbdmdzdb.TabIndex = 11;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(4, 69);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(139, 20);
            this.label27.TabIndex = 9;
            this.label27.Text = "高密度脂蛋白:";
            // 
            // tbgmdzdb
            // 
            this.tbgmdzdb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbgmdzdb.ForeColor = System.Drawing.Color.Black;
            this.tbgmdzdb.Location = new System.Drawing.Point(150, 65);
            this.tbgmdzdb.MaxLength = 6;
            this.tbgmdzdb.Multiline = true;
            this.tbgmdzdb.Name = "tbgmdzdb";
            this.tbgmdzdb.Size = new System.Drawing.Size(78, 23);
            this.tbgmdzdb.TabIndex = 10;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.Location = new System.Drawing.Point(1160, 69);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(69, 20);
            this.label54.TabIndex = 145;
            this.label54.Text = "mmol/L";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.Location = new System.Drawing.Point(1060, 33);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(99, 20);
            this.label50.TabIndex = 223;
            this.label50.Text = "空腹血糖:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label48.Location = new System.Drawing.Point(889, 69);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(69, 20);
            this.label48.TabIndex = 145;
            this.label48.Text = "mmol/L";
            // 
            // tbkfxt
            // 
            this.tbkfxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbkfxt.ForeColor = System.Drawing.Color.Black;
            this.tbkfxt.Location = new System.Drawing.Point(1164, 30);
            this.tbkfxt.MaxLength = 6;
            this.tbkfxt.Multiline = true;
            this.tbkfxt.Name = "tbkfxt";
            this.tbkfxt.Size = new System.Drawing.Size(60, 23);
            this.tbkfxt.TabIndex = 8;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(592, 70);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(69, 20);
            this.label28.TabIndex = 145;
            this.label28.Text = "mmol/L";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.Location = new System.Drawing.Point(776, 30);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(49, 20);
            this.label42.TabIndex = 223;
            this.label42.Text = "BMI:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(237, 68);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 20);
            this.label26.TabIndex = 145;
            this.label26.Text = "mmol/L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(552, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "体重:";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label49.Location = new System.Drawing.Point(1226, 35);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(69, 20);
            this.label49.TabIndex = 145;
            this.label49.Text = "mmol/L";
            // 
            // tbBMI
            // 
            this.tbBMI.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBMI.ForeColor = System.Drawing.Color.Black;
            this.tbBMI.Location = new System.Drawing.Point(830, 27);
            this.tbBMI.MaxLength = 6;
            this.tbBMI.Multiline = true;
            this.tbBMI.Name = "tbBMI";
            this.tbBMI.Size = new System.Drawing.Size(72, 23);
            this.tbBMI.TabIndex = 6;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(507, 28);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(29, 20);
            this.label39.TabIndex = 145;
            this.label39.Text = "cm";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(911, 31);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(69, 20);
            this.label41.TabIndex = 145;
            this.label41.Text = "kg/m2 ";
            // 
            // tbWeight
            // 
            this.tbWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWeight.ForeColor = System.Drawing.Color.Black;
            this.tbWeight.Location = new System.Drawing.Point(615, 27);
            this.tbWeight.MaxLength = 6;
            this.tbWeight.Multiline = true;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(60, 23);
            this.tbWeight.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(679, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 145;
            this.label5.Text = "㎏";
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(711, 26);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(43, 27);
            this.btnWeight.TabIndex = 5;
            this.btnWeight.Text = ".....";
            this.btnWeight.UseVisualStyleBackColor = true;
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpFollowDate);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.tbDoctor);
            this.groupBox1.Controls.Add(this.cbVisitWay);
            this.groupBox1.Location = new System.Drawing.Point(55, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1354, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(7, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 94;
            this.label10.Text = "姓    名:";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(114, 20);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(138, 30);
            this.tbName.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(298, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 136;
            this.label11.Text = "随访日期:";
            // 
            // dtpFollowDate
            // 
            this.dtpFollowDate.Location = new System.Drawing.Point(405, 20);
            this.dtpFollowDate.Name = "dtpFollowDate";
            this.dtpFollowDate.Size = new System.Drawing.Size(183, 30);
            this.dtpFollowDate.TabIndex = 1;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.Location = new System.Drawing.Point(627, 24);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(99, 20);
            this.label44.TabIndex = 215;
            this.label44.Text = "随访方式:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.Location = new System.Drawing.Point(950, 25);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(99, 20);
            this.label46.TabIndex = 219;
            this.label46.Text = "随访医生:";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Location = new System.Drawing.Point(1054, 20);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(142, 30);
            this.tbDoctor.TabIndex = 3;
            // 
            // cbVisitWay
            // 
            this.cbVisitWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisitWay.FormattingEnabled = true;
            this.cbVisitWay.Location = new System.Drawing.Point(733, 20);
            this.cbVisitWay.Name = "cbVisitWay";
            this.cbVisitWay.Size = new System.Drawing.Size(163, 28);
            this.cbVisitWay.TabIndex = 2;
            // 
            // CHDVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CHDVisitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHDVisitForm";
            this.Load += new System.EventHandler(this.FrmChdFollow_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.pnfywzlcs.ResumeLayout(false);
            this.pnfywzlcs.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.pnsffl.ResumeLayout(false);
            this.pnsffl.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.pnkfzl.ResumeLayout(false);
            this.pnkfzl.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.pnzhengz.ResumeLayout(false);
            this.pnzhengz.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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

        public bool SaveModelToDB()
        {
            if (!string.IsNullOrEmpty(this.tbHype.Text.Trim()))
            {
                string[] xueyadata = this.tbHype.Text.Trim().Split('/');

                if (xueyadata.Length >= 2)
                {
                    if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                    {
                        this.chdFollowUp.Systolic = Convert.ToDecimal(xueyadata[0].ToString());
                    }
                    if (!string.IsNullOrEmpty(xueyadata[1].ToString()))
                    {
                        this.chdFollowUp.Diastolic = Convert.ToDecimal(xueyadata[1].ToString());
                    }
                }
                else if (xueyadata.Length > 0)
                {
                    if (this.tbHype.Text.Substring(0, 1) == "/")
                    {
                        if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                        {
                            this.chdFollowUp.Diastolic = Convert.ToDecimal(xueyadata[0].ToString());
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                        {
                            this.chdFollowUp.Systolic = Convert.ToDecimal(xueyadata[0].ToString());
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.tbWeight.Text.Trim()))
            {
                this.chdFollowUp.Weight = Convert.ToDecimal(this.tbWeight.Text.ToString());
            }

            ChronicChdVisitBLL chronicChdVisitBll = new ChronicChdVisitBLL();
            ChronicDrugConditionBLL chronicDrugConditionBLL = new ChronicDrugConditionBLL();
            ChronicChdVisitModel chdvisitmodel1 = chronicChdVisitBll.ExistsCheckDate(this.chdFollowUp);

            if (chdvisitmodel1 != null)
            {
                if (this.IDPerson > 0 && this.visitdate == this.chdFollowUp.VisitDate.ToString())
                {
                    this.IDPerson = chdvisitmodel1.ID;
                    this.chdFollowUp.ID = chdvisitmodel1.ID;
                    chronicChdVisitBll.Update(this.chdFollowUp);
                }
                else
                {
                    DialogResult result = MessageBox.Show("此日期下已有随访信息，是否进行修改？", "提示", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        chronicChdVisitBll.Delete(this.IDPerson);
                        chronicDrugConditionBLL.DeleteOUTKey(this.IDPerson, "4");
                        this.IDPerson = chdvisitmodel1.ID;
                        this.chdFollowUp.ID = chdvisitmodel1.ID;

                        chronicChdVisitBll.Update(this.chdFollowUp);
                    }
                    else return true;
                }
            }
            else
            {
                if (this.IDPerson > 0)
                {
                    chronicChdVisitBll.Delete(this.IDPerson);
                    chronicDrugConditionBLL.DeleteOUTKey(this.IDPerson, "4");
                }
                this.IDPerson = chronicChdVisitBll.Add(this.chdFollowUp);
            }

            chronicDrugConditionBLL.DeleteOUTKey(this.IDPerson, "4");

            for (int i = 0; i < this.DrugConditions.Count; i++)
            {
                DrugConditions[i].OUTKey = this.IDPerson;
                DrugConditions[i].Type = "4";

                if (!string.IsNullOrEmpty(this.DrugConditions[i].Name))
                {
                    chronicDrugConditionBLL.Add(this.DrugConditions[i]);
                }
            }

            return true;
        }

        public void UpdataToModel()
        {
            this.chdFollowUp.NextVisitDate = new DateTime?(this.dtpNext.Value.Date);
            this.chdFollowUp.VisitDate = new DateTime?(this.dtpFollowDate.Value.Date);
            if (this.folDoctor.Count<KeyValuePair<string, RadioButton>>(a => a.Value.Checked) == 1) //尊医行为
            {
                this.chdFollowUp.Action = this.folDoctor.Single<KeyValuePair<string, RadioButton>>(b => b.Value.Checked).Key;
            }
            string strchdtype = "";
            for (int i = 0; i < gxblxlist.Count; i++) //冠心病类型
            {
                if (this.gxblxlist[i].Checked)
                {
                    strchdtype = string.Format("{0}", i + 1);
                }
            }
            this.chdFollowUp.ChdType = strchdtype.Trim();
            string strFollowType = "";
            for (int i = 0; i < this.sfflist.Count; i++) //此次随访分类
            {
                if (this.sfflist[i].Checked)
                {
                    strFollowType = strFollowType + string.Format("{0},", i + 1);
                }
            }
            this.chdFollowUp.FollowType = strFollowType.Trim(new char[] { ',' });

            string strtszl = "";
            for (int i = 0; i < this.tszlist.Count; i++) //特殊治疗
            {
                if (this.tszlist[i].Checked)
                {
                    strtszl = strtszl + string.Format("{0},", i + 1);
                }
            }
            this.chdFollowUp.SpecialTreated = strtszl.Trim(new char[] { ',' });

            string strnondrug = "";
            for (int i = 0; i < this.nondruglist.Count; i++) //非药物治疗措施
            {
                if (this.nondruglist[i].Checked)
                {
                    strnondrug = strnondrug + string.Format("{0},", i + 1);
                }
            }
            this.chdFollowUp.NondrugTreat = strnondrug.Trim(new char[] { ',' });

            if (this.rdYesZz.Checked)
            {
                this.chdFollowUp.IsReferral = "1";
            }
            else if (this.rdNoZz.Checked)
            {
                this.chdFollowUp.IsReferral = "2";
            }

            for (int k = 0; k < this.Yongyaoyc.Count; k++)
            {
                this.Yongyaoyc[k].UpdateSource();
                if (this.Yongyaoyc[k].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.DrugConditions.Add(this.Yongyaoyc[k].Source);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoseFrm f = new DoseFrm();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private List<ChronicDrugConditionModel> DrugConditions { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public RecordsGeneralConditionModel GeneralModel { get; set; }

        public RecordsCustomerBaseInfoModel CustomerBaseInfo { get; set; }

        public RecordsAssistCheckModel AssistCheckModel { get; set; }

        public string SaveDataInfo { get; set; }

        public int IDPerson { get; set; }

        private void ckxZhz1_CheckedChanged(object sender, EventArgs e) //目前症状
        {
            if (this.ckxZhz1.Checked)
            {
                this.ckxZhz2.Checked = false;
                this.ckxZhz3.Checked = false;
                this.ckxZhz4.Checked = false;
                this.ckxZhz5.Checked = false;
                this.ckxZhz6.Checked = false;
                this.ckxZhz7.Checked = false;
                this.ckxZhz8.Checked = false;
                this.ckxZhz9.Checked = false;
                this.ckxZhz10.Checked = false;
                this.pnzhengz.Enabled = false;
                this.tbSyOther.Clear();
                this.tbSyOther.ReadOnly = true;
            }
            else
            {
                this.tbSyOther.ReadOnly = false;
                this.pnzhengz.Enabled = true;
            }
        }

        private void cksfflmy_CheckedChanged(object sender, EventArgs e)//此次随访分类
        {
            if (this.cksfflmy.Checked)
            {
                this.cksfflkzbmy.Checked = false;
            }
        }

        private void cksfflbfz_CheckedChanged(object sender, EventArgs e)//此次随访分类:并发症
        {
            if (this.cksfflbfz.Checked)
            {
                this.tbbfzother.ReadOnly = false;
            }
            else
            {
                this.tbbfzother.Clear();
                this.tbbfzother.ReadOnly = true;
            }
        }

        private void ckjkzlw_CheckedChanged(object sender, EventArgs e) //特殊治疗
        {
            if (this.cktszl1.Checked)
            {
                this.cktszl2.Checked = false;
                this.cktszl3.Checked = false;
                this.cktszl4.Checked = false;
                this.pnkfzl.Enabled = false;
            }
            else
            {
                this.pnkfzl.Enabled = true;
            }
        }

        private void rdYesZz_CheckedChanged(object sender, EventArgs e) //是否转诊
        {
            if (this.rdYesZz.Checked)
            {
                this.tbZzYy.ReadOnly = false;
                this.tbZzKs.ReadOnly = false;
            }
            else
            {
                this.tbZzYy.Clear();
                this.tbZzKs.Clear();
                this.tbZzYy.ReadOnly = true;
                this.tbZzKs.ReadOnly = true;
            }
        }

        private void btnBMI_Click(object sender, EventArgs e) //BMI计算
        {
            decimal num;
            decimal num2;
            if ((decimal.TryParse(this.tbHeight.Text, out num) && decimal.TryParse(this.tbWeight.Text, out num2)) && (num != 0M))
            {
                decimal num3 = num / 100M;
                decimal num4 = num3 * num3;
                this.tbBMI.Text = (num2 / num4).ToString(".00");
            }
        }

        private void ckfywzl1_CheckedChanged(object sender, EventArgs e) //非药物治疗措施
        {
            if (this.ckfywzl1.Checked)
            {
                this.ckfywzl2.Checked = false;
                this.ckfywzl3.Checked = false;
                this.ckfywzl4.Checked = false;
                this.ckfywzl5.Checked = false;
                this.ckfywzl6.Checked = false;
                this.ckfywzl7.Checked = false;
                this.ckfywzl8.Checked = false;
                this.ckfywzl9.Checked = false;
                this.pnfywzlcs.Enabled = false;
            }
            else
            {
                this.pnfywzlcs.Enabled = true;
            }
        }
    }
}

