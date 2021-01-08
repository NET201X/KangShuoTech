using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.ChronicDisease
{
    using CommonControl;
    using FocusGroup;
    using KangShuoTech.Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Data;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class StrokeVisitForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SingleItemT<ChronicStrokeVisitModel> adverseReaction;
        private JustSingleItem<ChronicStrokeVisitModel> afterpill;
        private SimpleBindingManager<ChronicStrokeVisitModel> bindingManager;
        private IContainer components;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private TextBox tbSyOther;
        private ComboBox cbxXltz;
        private Label label8;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox tbName;
        private Label label19;
        private DateTimePicker dtpFollowDate;
        private Label label26;
        private Label label27;
        private TextBox tbDoctor;
        private ComboBox cbVisitWay;
        private GroupBox groupBox7;
        private TextBox tbxfnczzz;
        private Label label28;
        private Panel pnnczbfz;
        private TextBox tbbfzqt;
        private CheckBox ckbfz6;
        private CheckBox ckbfz5;
        private CheckBox ckbfz4;
        private CheckBox ckbfz3;
        private CheckBox ckbfz2;
        private Panel pngrbs;
        private CheckBox ckgrbs5;
        private CheckBox ckgrbs4;
        private CheckBox ckgrbs3;
        private CheckBox ckgrbs2;
        private CheckBox ckbfz1;
        private CheckBox ckgrbs1;
        private Panel pnxncz;
        private CheckBox ckxncz10;
        private CheckBox ckxncz12;
        private CheckBox ckxncz11;
        private CheckBox ckxncz9;
        private CheckBox ckxncz8;
        private CheckBox ckxncz7;
        private CheckBox ckxncz6;
        private CheckBox ckxncz5;
        private CheckBox ckxncz4;
        private CheckBox ckxncz3;
        private CheckBox ckxncz2;
        private CheckBox ckxncz1;
        private CheckBox ckxZhz1;
        private Label label10;
        private Label label11;
        private Label label29;
        private Label label30;
        private Label label32;
        private Panel panel22;
        private RadioButton rdnczlx7;
        private RadioButton rdnczlx6;
        private RadioButton rdnczlx5;
        private RadioButton rdnczlx4;
        private RadioButton rdnczlx3;
        private RadioButton rdnczlx2;
        private RadioButton rdnczlx1;
        private Label label33;
        private ComboBox cmbnczbw;
        private Panel pnmqzz;
        private CheckBox ckOth;
        private CheckBox ckxZhz7;
        private CheckBox ckxZhz6;
        private CheckBox ckxZhz5;
        private CheckBox ckxZhz4;
        private CheckBox ckxZhz3;
        private CheckBox ckxZhz2;
        private CheckBox ckmqzzw;
        private CheckBox ckmqzzbsbs;
        private GroupBox groupBox6;
        private List<YongYaoQKUserControl> YongyaoDose = new List<YongYaoQKUserControl>();
        private List<YongYaoQKUserControlYC> YongyaoDoseyc = new List<YongYaoQKUserControlYC>();
        private YongYaoQKUserControl yongYao4;
        private YongYaoQKUserControl yongYao3;
        private YongYaoQKUserControl yongYao2;
        private YongYaoQKUserControl yongYao1;
        private YongYaoQKUserControlYC yongYaoyc4;
        private YongYaoQKUserControlYC yongYaoyc3;
        private YongYaoQKUserControlYC yongYaoyc2;
        private YongYaoQKUserControlYC yongYaoyc1;
        private Panel panel1;
        private GroupBox groupBox4;
        private Label label7;
        private Label label17;
        private Label label18;
        private Label label55;
        private LinkLabel linkLabel1;
        private TextBox tbZzYy;
        private TextBox tbZzKs;
        private DateTimePicker dtpNext;
        private Panel panel11;
        private RadioButton rdNoZz;
        private RadioButton rdYesZz;
        private GroupBox groupBox2;
        private Label label2;
        private ComboBox cmbshnfzl;
        private Label label21;
        private Label label20;
        private CheckBox ckjkzl1;
        private Panel panel16;
        private TextBox tbAdverseReaction;
        private RadioButton rdAdverseReactionYes;
        private RadioButton rdAdverseReactionNo;
        private ComboBox cmbztgnhfqk;
        private Panel pnkfzl;
        private TextBox tbjkzlother;
        private CheckBox ckjkzl5;
        private CheckBox ckjkzl4;
        private CheckBox ckjkzl3;
        private CheckBox ckjkzl2;
        private Label label5;
        private ComboBox cbxComplance;
        private Label label51;
        private Label label4;
        private Label label50;
        private CheckBox cksffl1;
        private TextBox tbdoctorview;
        private Label label48;
        private TextBox tbAidCheck;
        private Panel pnsffl;
        private TextBox tbbfzother;
        private CheckBox cksffl4;
        private CheckBox cksffl3;
        private CheckBox cksffl2;
        private Label label52;
        private GroupBox groupBox3;
        private TextBox tbTizhOth;
        private Button btnWeight;
        private Label label6;
        private TextBox tbWeight;
        private TextBox tbHype;
        private Button btnSelectHyp;
        private Button btnyaowei;
        private Button btnBMI;
        private Label label49;
        private Label label53;
        private Label label54;
        private Label label9;
        private TextBox tbWhatDrug;
        private TextBox tbhight;
        private Label label56;
        private Label label57;
        private TextBox tbkfxt;
        private Label label58;
        private TextBox tbyaowei;
        private Label label59;
        private Label label60;
        private TextBox tbBMI;
        private Label label61;
        private Label label62;
        private Label label63;
        private Label label64;
        private GroupBox groupBox5;
        private Label label38;
        private Label label34;
        private Label label16;
        private Label label35;
        private TextBox tbminute;
        private TextBox tbdrink;
        private TextBox tbsportweek;
        private TextBox tbsmoke;
        private Label label36;
        private Label label39;
        private Label label40;
        private Label label41;
        private Label label42;
        private ComboBox cbxSmokeWine;
        private Label label44;
        private ComboBox cbxSport;
        private Label label46;
        private ComboBox cbxSalt;
        private CheckBox cksfflmy;
        private CheckBox cksfflblfy;
        private ManyCheckboxs<ChronicStrokeVisitModel> symptom;//目前症状
        private ManyCheckboxs<ChronicStrokeVisitModel> MedicalHistory;//个人病史
        private ManyCheckboxs<ChronicStrokeVisitModel> Syndrome;//脑卒中并发症情况
        private ManyCheckboxs<ChronicStrokeVisitModel> NewSymptom;//新发卒中症状
        private ManyCheckboxs<ChronicStrokeVisitModel> RecoveryCure;//康复治疗方式
        private List<CheckBox> sfflist = new List<CheckBox>();
        private ComboBox cbxObeyDoctor;//此次随访分类
        private List<RadioButton> ncztypelist = new List<RadioButton>();
        private GroupBox groupBox8;//脑卒中类型
        private string visitdate;

        public StrokeVisitForm()
        {
            this.InitializeComponent();
            this.YongyaoDose.Add(this.yongYao1);
            this.YongyaoDose.Add(this.yongYao2);
            this.YongyaoDose.Add(this.yongYao3);
            this.YongyaoDose.Add(this.yongYao4);
            this.YongyaoDoseyc.Add(this.yongYaoyc1);
            this.YongyaoDoseyc.Add(this.yongYaoyc2);
            this.YongyaoDoseyc.Add(this.yongYaoyc3);
            this.YongyaoDoseyc.Add(this.yongYaoyc4);
            this.sfflist.Add(this.cksffl1);//此次随访分类
            this.sfflist.Add(this.cksffl2);
            this.sfflist.Add(this.cksffl3);
            this.sfflist.Add(this.cksffl4);
            this.ncztypelist.Add(this.rdnczlx1);//脑卒中类型
            this.ncztypelist.Add(this.rdnczlx2);
            this.ncztypelist.Add(this.rdnczlx3);
            this.ncztypelist.Add(this.rdnczlx4);
            this.ncztypelist.Add(this.rdnczlx5);
            this.ncztypelist.Add(this.rdnczlx6);
            this.ncztypelist.Add(this.rdnczlx7);
            this.InitEveryOne();
            this.EveryThingIsOk = false;
        }

        public ChildFormStatus CheckErrorInput()
        {
            bool flag = false;
            if (this.dtpFollowDate.Value.Date > DateTime.Today)
            {
                flag = true;
                StrokeVisitForm stroke = this;
                string str = stroke.SaveDataInfo + "随访日期不能晚于当前日期!\r\n";
                stroke.SaveDataInfo = str;
            }
            if (this.dtpNext.Value.Date < this.dtpFollowDate.Value.Date)
            {
                flag = true;
                StrokeVisitForm stroke2 = this;
                string str2 = stroke2.SaveDataInfo + "下次随访日期不能小于当前随访日期!";
                stroke2.SaveDataInfo = str2;
            }

            bool flag2 = (this.YongyaoDoseyc.Count<YongYaoQKUserControlYC>(c => c.ErrorInput) > 0);
            bool flag3 = this.symptom.ErrorInput || this.adverseReaction.ErrorInput || this.MedicalHistory.ErrorInput
                           || this.Syndrome.ErrorInput || this.NewSymptom.ErrorInput || this.RecoveryCure.ErrorInput;

            if ((!flag && !this.bindingManager.ErrorInput) && (!flag3 && !flag2))
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

        private void FrmStroke_Load(object sender, EventArgs e)
        {
            this.groupBox8.Visible = true;

            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void InitEveryOne()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> { //随访方式
                new ItemDictonaryModel<string>("门诊", "1"),
                new ItemDictonaryModel<string>("家庭", "2"),
                new ItemDictonaryModel<string>("电话", "3"),
                new ItemDictonaryModel<string>("其他", "4")
            };
            this.cbVisitWay.DisplayMember = "DISPLAYMEMBER";
            this.cbVisitWay.ValueMember = "VALUEMEMBER";
            this.cbVisitWay.DataSource = list;
            List<ItemDictonaryModel<string>> list2 = new List<ItemDictonaryModel<string>> { //服药依从性
                new ItemDictonaryModel<string>("规律", "1"),
                new ItemDictonaryModel<string>("间断", "2"),
                new ItemDictonaryModel<string>("不服药", "3")
            };
            this.cbxComplance.DisplayMember = "DISPLAYMEMBER";
            this.cbxComplance.ValueMember = "VALUEMEMBER";
            this.cbxComplance.DataSource = list2;

            List<ItemDictonaryModel<string>> list3 = new List<ItemDictonaryModel<string>> { //脑卒中部位
                new ItemDictonaryModel<string>("请选择", "1"),
                new ItemDictonaryModel<string>("大脑半球左侧", "2"),
                new ItemDictonaryModel<string>("大脑半球右侧", "3"),
                new ItemDictonaryModel<string>("脑干", "4"),
                new ItemDictonaryModel<string>("小脑", "5"),
                new ItemDictonaryModel<string>("不确定", "6")
            };
            this.cmbnczbw.DisplayMember = "DISPLAYMEMBER";
            this.cmbnczbw.ValueMember = "VALUEMEMBER";
            this.cmbnczbw.DataSource = list3;
            List<ItemDictonaryModel<string>> list4 = new List<ItemDictonaryModel<string>> { //遵医行为
                new ItemDictonaryModel<string>("良好", "1"),
                new ItemDictonaryModel<string>("一般", "2"),
                new ItemDictonaryModel<string>("差", "3")
            };
            this.cbxObeyDoctor.DisplayMember = "DISPLAYMEMBER";
            this.cbxObeyDoctor.ValueMember = "VALUEMEMBER";
            this.cbxObeyDoctor.DataSource = list4;
            List<ItemDictonaryModel<string>> list6 = new List<ItemDictonaryModel<string>> { //生活能否自理能力
                new ItemDictonaryModel<string>("请选择", "1"),
                new ItemDictonaryModel<string>("完全自理", "2"),
                new ItemDictonaryModel<string>("部分自理", "3"),
                new ItemDictonaryModel<string>("完全不能自理", "4")
            };
            this.cmbshnfzl.DisplayMember = "DISPLAYMEMBER";
            this.cmbshnfzl.ValueMember = "VALUEMEMBER";
            this.cmbshnfzl.DataSource = list6;
            List<ItemDictonaryModel<string>> list7 = new List<ItemDictonaryModel<string>> { //肢体功能恢复情况
                new ItemDictonaryModel<string>("请选择", "1"),
                new ItemDictonaryModel<string>("好", "2"),
                new ItemDictonaryModel<string>("一般", "3"),
                new ItemDictonaryModel<string>("差", "4")
            };
            this.cmbztgnhfqk.DisplayMember = "DISPLAYMEMBER";
            this.cmbztgnhfqk.ValueMember = "VALUEMEMBER";
            this.cmbztgnhfqk.DataSource = list7;

            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("VisitDoctor", 30));
            this.inputrange_str.Add(new InputRangeStr("Symptom", 30));
            this.inputrange_str.Add(new InputRangeStr("SymptomOther", 0xff));
            this.inputrange_str.Add(new InputRangeStr("MedicalHistory", 30));
            this.inputrange_str.Add(new InputRangeStr("SignOther", 0xff));
            this.inputrange_str.Add(new InputRangeStr("SmokeDrinkAttention", 0xff));
            this.inputrange_str.Add(new InputRangeStr("SportAttention", 0xff));
            this.inputrange_str.Add(new InputRangeStr("EatSaltAttention", 0xff));
            this.inputrange_str.Add(new InputRangeStr("AssistantExam", 0xff));
            this.inputrange_str.Add(new InputRangeStr("AdrEx", 0xff));
            this.inputrange_str.Add(new InputRangeStr("ReferralReason", 0xff));
            this.inputrange_str.Add(new InputRangeStr("ReferralOrg", 0xff));
            this.inputrange_str.Add(new InputRangeStr("EatingDrug", 0xff));
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("Hypertension", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Hypotension", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Weight", 1000M, false));
        }

        public void InitEveryThing()
        {
            this.groupBox8.Visible = true;

            if (this.IDPerson > 0)
            {
                this.strokeFollowup = new ChronicStrokeVisitBLL().GetModelID(this.IDPerson);
                this.CustomerBaseInfo = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.Model.IDCardNo); //获取用户信息Model

                if (this.strokeFollowup.FollowupDate.HasValue)
                {
                    this.dtpFollowDate.Value = this.strokeFollowup.FollowupDate.Value;
                    this.visitdate = this.strokeFollowup.FollowupDate.ToString();
                }
            }
            else
            {
                this.strokeFollowup = new ChronicStrokeVisitBLL().GetModel(this.Model.IDCardNo);
                this.dtpFollowDate.Value = DateTime.Today.Date;

                if (this.strokeFollowup == null) this.strokeFollowup = new ChronicStrokeVisitModel();

                if (this.strokeFollowup.FollowupDate == null || (this.strokeFollowup.FollowupDate != null && this.strokeFollowup.FollowupDate.Value != this.dtpFollowDate.Value))
                {
                    this.strokeFollowup.FollowupDate = this.dtpFollowDate.Value;
                    this.strokeFollowup.NextFollowupDate = DateTime.Today.Date.AddYears(1);
                    this.strokeFollowup.FollowupWay = "1";
                }

                this.strokeFollowup.IDCardNo = this.Model.IDCardNo;
            }

            if (this.strokeFollowup == null)
            {
                this.strokeFollowup = new ChronicStrokeVisitModel();
                this.strokeFollowup.IDCardNo = this.Model.IDCardNo;
                this.strokeFollowup.RecordID = this.Model.RecordID;
                this.strokeFollowup.CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.strokeFollowup.CreatedDate = new DateTime?(DateTime.Today);
                this.DrugConditions = new List<ChronicDrugConditionModel>();
            }
            else
            {
                this.strokeFollowup.LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.strokeFollowup.LastUpdateDate = new DateTime?(DateTime.Today);

                if (this.IDPerson > 0)
                {
                    this.DrugConditions = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '" + this.IDPerson + "' ", this.Model.IDCardNo, "5"));
                }
                else
                {
                    this.DrugConditions = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '" + this.strokeFollowup.ID + "' ", this.Model.IDCardNo, "5"));
                }
            }

            if (string.IsNullOrEmpty(this.strokeFollowup.FollowUpDoctor))
            {
                this.strokeFollowup.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
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

            this.bindingManager = new SimpleBindingManager<ChronicStrokeVisitModel>(this.inputRanges, this.inputrange_str, this.strokeFollowup);

            if (!this.strokeFollowup.Weight.HasValue)
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                if (devData.HasValue)
                {
                    this.strokeFollowup.Weight = new decimal?(decimal.Parse(devData.value1));
                }
            }

            if (!this.strokeFollowup.Hypertension.HasValue)
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20", "血压");
                if (_result2.HasValue)
                {
                    this.strokeFollowup.Hypertension = new decimal?(decimal.Parse(_result2.value1));
                    this.strokeFollowup.Hypotension = new decimal?(decimal.Parse(_result2.value2));
                }
            }

            this.tbName.Text = this.Model.CustomerName;
            this.bindingManager.SimpleBinding(this.cbVisitWay, "FollowupWay");
            this.symptom = new ManyCheckboxs<ChronicStrokeVisitModel>(this.strokeFollowup, 500);//目前症状
            this.symptom.AddCk(this.ckxZhz1, true);
            this.symptom.AddCk(new CheckBox[] { this.ckxZhz2, this.ckxZhz3, this.ckxZhz4, this.ckxZhz5, this.ckxZhz6, this.ckxZhz7 });
            this.symptom.AddCk(this.ckOth, this.tbSyOther);
            this.symptom.BindingProperty("Symptom", "SymptomOther");
            this.MedicalHistory = new ManyCheckboxs<ChronicStrokeVisitModel>(this.strokeFollowup, 500);//个人病史
            this.MedicalHistory.AddCk(this.ckgrbs1, true);
            this.MedicalHistory.AddCk(new CheckBox[] { this.ckgrbs2, this.ckgrbs3, this.ckgrbs4, this.ckgrbs5 });
            this.MedicalHistory.BindingProperty("MedicalHistory", "");
            this.Syndrome = new ManyCheckboxs<ChronicStrokeVisitModel>(this.strokeFollowup, 500);//脑卒中并发症情况
            this.Syndrome.AddCk(this.ckbfz1, true);
            this.Syndrome.AddCk(new CheckBox[] { this.ckbfz2, this.ckbfz3, this.ckbfz4, this.ckbfz5 });
            this.Syndrome.AddCk(this.ckbfz6, this.tbbfzqt);
            this.Syndrome.BindingProperty("Syndrome", "SyndromeOther");
            this.NewSymptom = new ManyCheckboxs<ChronicStrokeVisitModel>(this.strokeFollowup, 500);//新发卒中症状
            this.NewSymptom.AddCk(this.ckxncz1, true);
            this.NewSymptom.AddCk(new CheckBox[] { this.ckxncz2, this.ckxncz3, this.ckxncz4, this.ckxncz5, this.ckxncz6, this.ckxncz7,
                                                   this.ckxncz8,this.ckxncz9,this.ckxncz10,this.ckxncz11,this.ckxncz12 });
            this.NewSymptom.BindingProperty("NewSymptom", "");
            this.bindingManager.SimpleBinding(this.tbxfnczzz, "NewSymptomOther", false);
            this.RecoveryCure = new ManyCheckboxs<ChronicStrokeVisitModel>(this.strokeFollowup, 500);//康复治疗方式
            this.RecoveryCure.AddCk(this.ckjkzl1, true);
            this.RecoveryCure.AddCk(new CheckBox[] { this.ckjkzl2, this.ckjkzl3, this.ckjkzl4 });
            this.RecoveryCure.AddCk(this.ckjkzl5, this.tbjkzlother);
            this.RecoveryCure.BindingProperty("RecoveryCure", "RecoveryCureOther");
            this.bindingManager.SimpleBinding(this.tbsmoke, "SmokeDay", true);
            this.bindingManager.SimpleBinding(this.tbdrink, "DrinkDay", true);
            this.bindingManager.SimpleBindingInt(this.tbsportweek, "SportWeek", true);
            this.bindingManager.SimpleBindingInt(this.tbminute, "SportMinute", true);
            this.bindingManager.SimpleBinding(this.tbWeight, "Weight", true);

            if (string.IsNullOrEmpty(this.tbWeight.Text))
            {
                this.tbWeight.Text = this.GeneralModel.Weight.ToString();
            }

            this.bindingManager.SimpleBinding(this.tbhight, "Height", true);

            if (string.IsNullOrEmpty(this.tbhight.Text))
            {
                this.tbhight.Text = this.GeneralModel.Height.ToString();
            }

            this.bindingManager.SimpleBinding(this.tbBMI, "BMI", true);
            if (string.IsNullOrEmpty(this.tbBMI.Text))
            {
                this.tbBMI.Text = this.GeneralModel.BMI.ToString();
            }

            this.bindingManager.SimpleBinding(this.tbyaowei, "Waistline", true);
            if (string.IsNullOrEmpty(this.tbyaowei.Text))
            {
                this.tbyaowei.Text = this.GeneralModel.Waistline.ToString();
            }

            this.bindingManager.SimpleBinding(this.tbkfxt, "FPGL", true);
            if (string.IsNullOrEmpty(this.tbkfxt.Text))
            {
                this.tbkfxt.Text = this.AssistCheckModel.FPGL.ToString();
            }

            if (this.strokeFollowup.Hypertension.HasValue || this.strokeFollowup.Hypotension.HasValue)
            {
                if (this.strokeFollowup.Hypertension.HasValue && this.strokeFollowup.Hypotension.HasValue)
                {
                    this.tbHype.Text = string.Format("{0}/{1}", this.strokeFollowup.Hypertension.Value, this.strokeFollowup.Hypotension.Value);
                }
                else if (this.strokeFollowup.Hypertension.HasValue)
                {
                    this.tbHype.Text = string.Format("{0}/", this.strokeFollowup.Hypertension.Value);
                }
                else if (this.strokeFollowup.Hypotension.HasValue)
                {
                    this.tbHype.Text = string.Format("/{0}", this.strokeFollowup.Hypotension.Value);
                }
            }

            if (string.IsNullOrEmpty(this.tbHype.Text))
            {
                if (!string.IsNullOrEmpty(this.GeneralModel.LeftHeight.ToString()) || !string.IsNullOrEmpty(this.GeneralModel.LeftPre.ToString()))
                {
                    this.tbHype.Text = this.GeneralModel.LeftHeight.ToString() + "/" + this.GeneralModel.LeftPre.ToString();
                }
            }

            this.bindingManager.SimpleBinding(this.tbTizhOth, "SignOther", false);
            this.bindingManager.SimpleBinding(this.tbWhatDrug, "EatingDrug", false);
            this.bindingManager.SimpleBinding(this.cbxSmokeWine, "SmokeDrinkAttention", false);
            this.bindingManager.SimpleBinding(this.cbxSport, "SportAttention", false);
            this.bindingManager.SimpleBinding(this.cbxSalt, "EatSaltAttention", false);
            this.bindingManager.SimpleBinding(this.cbxXltz, "PsychicAdjust");
            this.bindingManager.SimpleBinding(this.cbxObeyDoctor, "ObeyDoctorBehavio");
            this.bindingManager.SimpleBinding(this.tbAidCheck, "AssistantExam", false);
            this.bindingManager.SimpleBinding(this.cbxComplance, "MedicationCompliance");
            this.bindingManager.SimpleBinding(this.cmbnczbw, "Strokelocation");
            this.bindingManager.SimpleBinding(this.cmbshnfzl, "LifeSelfCare");
            this.bindingManager.SimpleBinding(this.cmbztgnhfqk, "LimbRecover");

            SingleItemT<ChronicStrokeVisitModel> mt = new SingleItemT<ChronicStrokeVisitModel>(this.strokeFollowup)
            {
                Name = "服药不良反应",
                Usual = this.rdAdverseReactionNo,
                Unusual = this.rdAdverseReactionYes,
                Info = this.tbAdverseReaction,
                MaxBytesCount = 200
            };

            this.adverseReaction = mt;
            this.adverseReaction.BindProperty("Adr", "AdrEx");

            if (!string.IsNullOrEmpty(this.strokeFollowup.StrokeType)) //脑卒中类型
            {
                string strnczlx = this.strokeFollowup.StrokeType;
                char[] Arrnczlx = new char[] { ',' };
                foreach (string str in strnczlx.Split(Arrnczlx))
                {
                    int numnczlx;
                    if (int.TryParse(str, out numnczlx))
                    {
                        this.ncztypelist[numnczlx - 1].Checked = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.strokeFollowup.FollowupType)) //此次随访方式
            {
                string strsffl = this.strokeFollowup.FollowupType;
                char[] Arrsffl = new char[] { ',' };
                foreach (string str in strsffl.Split(Arrsffl))
                {
                    int numsf;
                    if (int.TryParse(str, out numsf))
                    {
                        this.sfflist[numsf - 1].Checked = true;
                    }
                }
            }

            this.bindingManager.SimpleBinding(this.tbbfzother, "FollowupTypeOther", false);
            this.bindingManager.SimpleBinding(this.tbdoctorview, "DoctorView", false);

            if (!string.IsNullOrEmpty(this.strokeFollowup.IsReferral))
            {
                if (this.strokeFollowup.IsReferral == "1") this.rdYesZz.Checked = true;
                else if (this.strokeFollowup.IsReferral == "2") this.rdNoZz.Checked = true;
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

            for (int k = 0; k < this.YongyaoDoseyc.Count; k++)
            {
                if (k < this.DrugConditions.Count)
                {
                    this.YongyaoDoseyc[k].Source = this.DrugConditions[k];
                }
                else
                {
                    ChronicDrugConditionModel chronicDrugConditionsModel = new ChronicDrugConditionModel
                    {
                        IDCardNo = this.Model.IDCardNo,
                        ModelState = RecordsStateModel.NoValue,
                        Type = "5"
                    };

                    this.YongyaoDoseyc[k].Source = chronicDrugConditionsModel;
                }
            }

            this.bindingManager.SimpleBinding(this.tbZzYy, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.tbZzKs, "ReferralOrg", false);

            if (this.strokeFollowup.NextFollowupDate.HasValue)
            {
                this.dtpNext.Value = this.strokeFollowup.NextFollowupDate.Value;
            }

            this.bindingManager.SimpleBinding(this.tbDoctor, "FollowupDoctor", false);
            this.EveryThingIsOk = true;
        }

        private void InitializeComponent()
        {
            this.tbSyOther = new System.Windows.Forms.TextBox();
            this.cbxXltz = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpFollowDate = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.cbVisitWay = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbxfnczzz = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.pnnczbfz = new System.Windows.Forms.Panel();
            this.tbbfzqt = new System.Windows.Forms.TextBox();
            this.ckbfz6 = new System.Windows.Forms.CheckBox();
            this.ckbfz5 = new System.Windows.Forms.CheckBox();
            this.ckbfz4 = new System.Windows.Forms.CheckBox();
            this.ckbfz3 = new System.Windows.Forms.CheckBox();
            this.ckbfz2 = new System.Windows.Forms.CheckBox();
            this.pngrbs = new System.Windows.Forms.Panel();
            this.ckgrbs5 = new System.Windows.Forms.CheckBox();
            this.ckgrbs4 = new System.Windows.Forms.CheckBox();
            this.ckgrbs3 = new System.Windows.Forms.CheckBox();
            this.ckgrbs2 = new System.Windows.Forms.CheckBox();
            this.ckbfz1 = new System.Windows.Forms.CheckBox();
            this.ckgrbs1 = new System.Windows.Forms.CheckBox();
            this.pnxncz = new System.Windows.Forms.Panel();
            this.ckxncz10 = new System.Windows.Forms.CheckBox();
            this.ckxncz12 = new System.Windows.Forms.CheckBox();
            this.ckxncz11 = new System.Windows.Forms.CheckBox();
            this.ckxncz9 = new System.Windows.Forms.CheckBox();
            this.ckxncz8 = new System.Windows.Forms.CheckBox();
            this.ckxncz7 = new System.Windows.Forms.CheckBox();
            this.ckxncz6 = new System.Windows.Forms.CheckBox();
            this.ckxncz5 = new System.Windows.Forms.CheckBox();
            this.ckxncz4 = new System.Windows.Forms.CheckBox();
            this.ckxncz3 = new System.Windows.Forms.CheckBox();
            this.ckxncz2 = new System.Windows.Forms.CheckBox();
            this.ckxncz1 = new System.Windows.Forms.CheckBox();
            this.pnmqzz = new System.Windows.Forms.Panel();
            this.ckOth = new System.Windows.Forms.CheckBox();
            this.ckxZhz7 = new System.Windows.Forms.CheckBox();
            this.ckxZhz6 = new System.Windows.Forms.CheckBox();
            this.ckxZhz5 = new System.Windows.Forms.CheckBox();
            this.ckxZhz4 = new System.Windows.Forms.CheckBox();
            this.ckxZhz3 = new System.Windows.Forms.CheckBox();
            this.ckxZhz2 = new System.Windows.Forms.CheckBox();
            this.ckxZhz1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.rdnczlx7 = new System.Windows.Forms.RadioButton();
            this.rdnczlx6 = new System.Windows.Forms.RadioButton();
            this.rdnczlx5 = new System.Windows.Forms.RadioButton();
            this.rdnczlx4 = new System.Windows.Forms.RadioButton();
            this.rdnczlx3 = new System.Windows.Forms.RadioButton();
            this.rdnczlx2 = new System.Windows.Forms.RadioButton();
            this.rdnczlx1 = new System.Windows.Forms.RadioButton();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbnczbw = new System.Windows.Forms.ComboBox();
            this.ckmqzzw = new System.Windows.Forms.CheckBox();
            this.ckmqzzbsbs = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.yongYao4 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYao3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYao2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.yongYao1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControl();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.yongYaoyc4 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoyc3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoyc2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.yongYaoyc1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbZzYy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tbZzKs = new System.Windows.Forms.TextBox();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.panel11 = new System.Windows.Forms.Panel();
            this.rdNoZz = new System.Windows.Forms.RadioButton();
            this.rdYesZz = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbshnfzl = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ckjkzl1 = new System.Windows.Forms.CheckBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.tbAdverseReaction = new System.Windows.Forms.TextBox();
            this.rdAdverseReactionYes = new System.Windows.Forms.RadioButton();
            this.rdAdverseReactionNo = new System.Windows.Forms.RadioButton();
            this.cmbztgnhfqk = new System.Windows.Forms.ComboBox();
            this.pnkfzl = new System.Windows.Forms.Panel();
            this.tbjkzlother = new System.Windows.Forms.TextBox();
            this.ckjkzl5 = new System.Windows.Forms.CheckBox();
            this.ckjkzl4 = new System.Windows.Forms.CheckBox();
            this.ckjkzl3 = new System.Windows.Forms.CheckBox();
            this.ckjkzl2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxObeyDoctor = new System.Windows.Forms.ComboBox();
            this.cbxComplance = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.cksffl1 = new System.Windows.Forms.CheckBox();
            this.tbdoctorview = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.tbAidCheck = new System.Windows.Forms.TextBox();
            this.pnsffl = new System.Windows.Forms.Panel();
            this.tbbfzother = new System.Windows.Forms.TextBox();
            this.cksffl4 = new System.Windows.Forms.CheckBox();
            this.cksffl3 = new System.Windows.Forms.CheckBox();
            this.cksffl2 = new System.Windows.Forms.CheckBox();
            this.label52 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbTizhOth = new System.Windows.Forms.TextBox();
            this.btnWeight = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.tbHype = new System.Windows.Forms.TextBox();
            this.btnSelectHyp = new System.Windows.Forms.Button();
            this.btnyaowei = new System.Windows.Forms.Button();
            this.btnBMI = new System.Windows.Forms.Button();
            this.label49 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbWhatDrug = new System.Windows.Forms.TextBox();
            this.tbhight = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.tbkfxt = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.tbyaowei = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.tbBMI = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.tbminute = new System.Windows.Forms.TextBox();
            this.tbdrink = new System.Windows.Forms.TextBox();
            this.tbsportweek = new System.Windows.Forms.TextBox();
            this.tbsmoke = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.cbxSmokeWine = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.cbxSport = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.cbxSalt = new System.Windows.Forms.ComboBox();
            this.cksfflmy = new System.Windows.Forms.CheckBox();
            this.cksfflblfy = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.pnnczbfz.SuspendLayout();
            this.pngrbs.SuspendLayout();
            this.pnxncz.SuspendLayout();
            this.pnmqzz.SuspendLayout();
            this.panel22.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel11.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel16.SuspendLayout();
            this.pnkfzl.SuspendLayout();
            this.pnsffl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSyOther
            // 
            this.tbSyOther.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbSyOther.Location = new System.Drawing.Point(908, 3);
            this.tbSyOther.MaxLength = 100;
            this.tbSyOther.Multiline = true;
            this.tbSyOther.Name = "tbSyOther";
            this.tbSyOther.ReadOnly = true;
            this.tbSyOther.Size = new System.Drawing.Size(122, 29);
            this.tbSyOther.TabIndex = 7;
            // 
            // cbxXltz
            // 
            this.cbxXltz.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxXltz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxXltz.FormattingEnabled = true;
            this.cbxXltz.Location = new System.Drawing.Point(115, 61);
            this.cbxXltz.Name = "cbxXltz";
            this.cbxXltz.Size = new System.Drawing.Size(173, 24);
            this.cbxXltz.TabIndex = 238;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(39, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 236;
            this.label8.Text = "心理调整:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(419, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 236;
            this.label15.Text = "遵医行为:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(11, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 14);
            this.label14.TabIndex = 230;
            this.label14.Text = "摄盐注意事项:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(391, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 14);
            this.label13.TabIndex = 228;
            this.label13.Text = "运动注意事项:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(10, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 14);
            this.label12.TabIndex = 226;
            this.label12.Text = "烟酒注意事项:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.dtpFollowDate);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.tbDoctor);
            this.groupBox1.Controls.Add(this.cbVisitWay);
            this.groupBox1.Location = new System.Drawing.Point(56, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1317, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 26);
            this.label1.TabIndex = 94;
            this.label1.Text = "姓    名:";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(113, 16);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(138, 36);
            this.tbName.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(274, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(129, 26);
            this.label19.TabIndex = 136;
            this.label19.Text = "随访日期:";
            // 
            // dtpFollowDate
            // 
            this.dtpFollowDate.Location = new System.Drawing.Point(379, 16);
            this.dtpFollowDate.Name = "dtpFollowDate";
            this.dtpFollowDate.Size = new System.Drawing.Size(187, 36);
            this.dtpFollowDate.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(622, 20);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(129, 26);
            this.label26.TabIndex = 215;
            this.label26.Text = "随访方式:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(941, 21);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(129, 26);
            this.label27.TabIndex = 219;
            this.label27.Text = "随访医生:";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Location = new System.Drawing.Point(1047, 16);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(142, 36);
            this.tbDoctor.TabIndex = 3;
            // 
            // cbVisitWay
            // 
            this.cbVisitWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisitWay.FormattingEnabled = true;
            this.cbVisitWay.Location = new System.Drawing.Point(727, 16);
            this.cbVisitWay.Name = "cbVisitWay";
            this.cbVisitWay.Size = new System.Drawing.Size(163, 33);
            this.cbVisitWay.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbxfnczzz);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Controls.Add(this.pnnczbfz);
            this.groupBox7.Controls.Add(this.pngrbs);
            this.groupBox7.Controls.Add(this.ckbfz1);
            this.groupBox7.Controls.Add(this.ckgrbs1);
            this.groupBox7.Controls.Add(this.pnxncz);
            this.groupBox7.Controls.Add(this.ckxncz1);
            this.groupBox7.Controls.Add(this.pnmqzz);
            this.groupBox7.Controls.Add(this.ckxZhz1);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label29);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.label32);
            this.groupBox7.Controls.Add(this.panel22);
            this.groupBox7.Controls.Add(this.label33);
            this.groupBox7.Controls.Add(this.cmbnczbw);
            this.groupBox7.Location = new System.Drawing.Point(56, 54);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1317, 363);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            // 
            // tbxfnczzz
            // 
            this.tbxfnczzz.Location = new System.Drawing.Point(196, 322);
            this.tbxfnczzz.Name = "tbxfnczzz";
            this.tbxfnczzz.Size = new System.Drawing.Size(694, 36);
            this.tbxfnczzz.TabIndex = 10;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(7, 325);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(233, 26);
            this.label28.TabIndex = 220;
            this.label28.Text = "其他新发卒中症状:";
            // 
            // pnnczbfz
            // 
            this.pnnczbfz.Controls.Add(this.tbbfzqt);
            this.pnnczbfz.Controls.Add(this.ckbfz6);
            this.pnnczbfz.Controls.Add(this.ckbfz5);
            this.pnnczbfz.Controls.Add(this.ckbfz4);
            this.pnnczbfz.Controls.Add(this.ckbfz3);
            this.pnnczbfz.Controls.Add(this.ckbfz2);
            this.pnnczbfz.Location = new System.Drawing.Point(281, 190);
            this.pnnczbfz.Name = "pnnczbfz";
            this.pnnczbfz.Size = new System.Drawing.Size(833, 36);
            this.pnnczbfz.TabIndex = 7;
            // 
            // tbbfzqt
            // 
            this.tbbfzqt.Location = new System.Drawing.Point(611, 3);
            this.tbbfzqt.Name = "tbbfzqt";
            this.tbbfzqt.ReadOnly = true;
            this.tbbfzqt.Size = new System.Drawing.Size(219, 36);
            this.tbbfzqt.TabIndex = 5;
            // 
            // ckbfz6
            // 
            this.ckbfz6.AutoSize = true;
            this.ckbfz6.Location = new System.Drawing.Point(523, 5);
            this.ckbfz6.Name = "ckbfz6";
            this.ckbfz6.Size = new System.Drawing.Size(86, 30);
            this.ckbfz6.TabIndex = 4;
            this.ckbfz6.Text = "其他";
            this.ckbfz6.UseVisualStyleBackColor = true;
            // 
            // ckbfz5
            // 
            this.ckbfz5.AutoSize = true;
            this.ckbfz5.Location = new System.Drawing.Point(400, 5);
            this.ckbfz5.Name = "ckbfz5";
            this.ckbfz5.Size = new System.Drawing.Size(138, 30);
            this.ckbfz5.TabIndex = 3;
            this.ckbfz5.Text = "深静脉炎";
            this.ckbfz5.UseVisualStyleBackColor = true;
            // 
            // ckbfz4
            // 
            this.ckbfz4.AutoSize = true;
            this.ckbfz4.Location = new System.Drawing.Point(255, 5);
            this.ckbfz4.Name = "ckbfz4";
            this.ckbfz4.Size = new System.Drawing.Size(164, 30);
            this.ckbfz4.TabIndex = 2;
            this.ckbfz4.Text = "泌尿道感染";
            this.ckbfz4.UseVisualStyleBackColor = true;
            // 
            // ckbfz3
            // 
            this.ckbfz3.AutoSize = true;
            this.ckbfz3.Location = new System.Drawing.Point(123, 5);
            this.ckbfz3.Name = "ckbfz3";
            this.ckbfz3.Size = new System.Drawing.Size(164, 30);
            this.ckbfz3.TabIndex = 1;
            this.ckbfz3.Text = "呼吸道感染";
            this.ckbfz3.UseVisualStyleBackColor = true;
            // 
            // ckbfz2
            // 
            this.ckbfz2.AutoSize = true;
            this.ckbfz2.Location = new System.Drawing.Point(4, 5);
            this.ckbfz2.Name = "ckbfz2";
            this.ckbfz2.Size = new System.Drawing.Size(86, 30);
            this.ckbfz2.TabIndex = 0;
            this.ckbfz2.Text = "褥疮";
            this.ckbfz2.UseVisualStyleBackColor = true;
            // 
            // pngrbs
            // 
            this.pngrbs.Controls.Add(this.ckgrbs5);
            this.pngrbs.Controls.Add(this.ckgrbs4);
            this.pngrbs.Controls.Add(this.ckgrbs3);
            this.pngrbs.Controls.Add(this.ckgrbs2);
            this.pngrbs.Location = new System.Drawing.Point(281, 149);
            this.pngrbs.Name = "pngrbs";
            this.pngrbs.Size = new System.Drawing.Size(833, 35);
            this.pngrbs.TabIndex = 5;
            // 
            // ckgrbs5
            // 
            this.ckgrbs5.AutoSize = true;
            this.ckgrbs5.Location = new System.Drawing.Point(400, 3);
            this.ckgrbs5.Name = "ckgrbs5";
            this.ckgrbs5.Size = new System.Drawing.Size(112, 30);
            this.ckgrbs5.TabIndex = 3;
            this.ckgrbs5.Text = "糖尿病";
            this.ckgrbs5.UseVisualStyleBackColor = true;
            // 
            // ckgrbs4
            // 
            this.ckgrbs4.AutoSize = true;
            this.ckgrbs4.Location = new System.Drawing.Point(255, 3);
            this.ckgrbs4.Name = "ckgrbs4";
            this.ckgrbs4.Size = new System.Drawing.Size(138, 30);
            this.ckgrbs4.TabIndex = 2;
            this.ckgrbs4.Text = "高脂血症";
            this.ckgrbs4.UseVisualStyleBackColor = true;
            // 
            // ckgrbs3
            // 
            this.ckgrbs3.AutoSize = true;
            this.ckgrbs3.Location = new System.Drawing.Point(123, 3);
            this.ckgrbs3.Name = "ckgrbs3";
            this.ckgrbs3.Size = new System.Drawing.Size(112, 30);
            this.ckgrbs3.TabIndex = 1;
            this.ckgrbs3.Text = "高血压";
            this.ckgrbs3.UseVisualStyleBackColor = true;
            // 
            // ckgrbs2
            // 
            this.ckgrbs2.AutoSize = true;
            this.ckgrbs2.Location = new System.Drawing.Point(4, 5);
            this.ckgrbs2.Name = "ckgrbs2";
            this.ckgrbs2.Size = new System.Drawing.Size(112, 30);
            this.ckgrbs2.TabIndex = 0;
            this.ckgrbs2.Text = "冠心病";
            this.ckgrbs2.UseVisualStyleBackColor = true;
            // 
            // ckbfz1
            // 
            this.ckbfz1.AutoSize = true;
            this.ckbfz1.Location = new System.Drawing.Point(192, 195);
            this.ckbfz1.Name = "ckbfz1";
            this.ckbfz1.Size = new System.Drawing.Size(60, 30);
            this.ckbfz1.TabIndex = 6;
            this.ckbfz1.Text = "无";
            this.ckbfz1.UseVisualStyleBackColor = true;
            // 
            // ckgrbs1
            // 
            this.ckgrbs1.AutoSize = true;
            this.ckgrbs1.Location = new System.Drawing.Point(192, 154);
            this.ckgrbs1.Name = "ckgrbs1";
            this.ckgrbs1.Size = new System.Drawing.Size(60, 30);
            this.ckgrbs1.TabIndex = 4;
            this.ckgrbs1.Text = "无";
            this.ckgrbs1.UseVisualStyleBackColor = true;
            // 
            // pnxncz
            // 
            this.pnxncz.Controls.Add(this.ckxncz10);
            this.pnxncz.Controls.Add(this.ckxncz12);
            this.pnxncz.Controls.Add(this.ckxncz11);
            this.pnxncz.Controls.Add(this.ckxncz9);
            this.pnxncz.Controls.Add(this.ckxncz8);
            this.pnxncz.Controls.Add(this.ckxncz7);
            this.pnxncz.Controls.Add(this.ckxncz6);
            this.pnxncz.Controls.Add(this.ckxncz5);
            this.pnxncz.Controls.Add(this.ckxncz4);
            this.pnxncz.Controls.Add(this.ckxncz3);
            this.pnxncz.Controls.Add(this.ckxncz2);
            this.pnxncz.Location = new System.Drawing.Point(281, 232);
            this.pnxncz.Name = "pnxncz";
            this.pnxncz.Size = new System.Drawing.Size(1030, 84);
            this.pnxncz.TabIndex = 9;
            // 
            // ckxncz10
            // 
            this.ckxncz10.AutoSize = true;
            this.ckxncz10.Location = new System.Drawing.Point(3, 43);
            this.ckxncz10.Name = "ckxncz10";
            this.ckxncz10.Size = new System.Drawing.Size(86, 30);
            this.ckxncz10.TabIndex = 8;
            this.ckxncz10.Text = "头疼";
            this.ckxncz10.UseVisualStyleBackColor = true;
            // 
            // ckxncz12
            // 
            this.ckxncz12.AutoSize = true;
            this.ckxncz12.Location = new System.Drawing.Point(200, 46);
            this.ckxncz12.Name = "ckxncz12";
            this.ckxncz12.Size = new System.Drawing.Size(138, 30);
            this.ckxncz12.TabIndex = 10;
            this.ckxncz12.Text = "意识障碍";
            this.ckxncz12.UseVisualStyleBackColor = true;
            // 
            // ckxncz11
            // 
            this.ckxncz11.AutoSize = true;
            this.ckxncz11.Location = new System.Drawing.Point(123, 43);
            this.ckxncz11.Name = "ckxncz11";
            this.ckxncz11.Size = new System.Drawing.Size(86, 30);
            this.ckxncz11.TabIndex = 9;
            this.ckxncz11.Text = "呕吐";
            this.ckxncz11.UseVisualStyleBackColor = true;
            // 
            // ckxncz9
            // 
            this.ckxncz9.AutoSize = true;
            this.ckxncz9.Location = new System.Drawing.Point(742, 4);
            this.ckxncz9.Name = "ckxncz9";
            this.ckxncz9.Size = new System.Drawing.Size(190, 30);
            this.ckxncz9.TabIndex = 7;
            this.ckxncz9.Text = "右侧肢体瘫痪";
            this.ckxncz9.UseVisualStyleBackColor = true;
            // 
            // ckxncz8
            // 
            this.ckxncz8.AutoSize = true;
            this.ckxncz8.Location = new System.Drawing.Point(662, 4);
            this.ckxncz8.Name = "ckxncz8";
            this.ckxncz8.Size = new System.Drawing.Size(86, 30);
            this.ckxncz8.TabIndex = 6;
            this.ckxncz8.Text = "昏迷";
            this.ckxncz8.UseVisualStyleBackColor = true;
            // 
            // ckxncz7
            // 
            this.ckxncz7.AutoSize = true;
            this.ckxncz7.Location = new System.Drawing.Point(546, 5);
            this.ckxncz7.Name = "ckxncz7";
            this.ckxncz7.Size = new System.Drawing.Size(138, 30);
            this.ckxncz7.TabIndex = 5;
            this.ckxncz7.Text = "共济失调";
            this.ckxncz7.UseVisualStyleBackColor = true;
            // 
            // ckxncz6
            // 
            this.ckxncz6.AutoSize = true;
            this.ckxncz6.Location = new System.Drawing.Point(392, 5);
            this.ckxncz6.Name = "ckxncz6";
            this.ckxncz6.Size = new System.Drawing.Size(190, 30);
            this.ckxncz6.TabIndex = 4;
            this.ckxncz6.Text = "左侧肢体瘫痪";
            this.ckxncz6.UseVisualStyleBackColor = true;
            // 
            // ckxncz5
            // 
            this.ckxncz5.AutoSize = true;
            this.ckxncz5.Location = new System.Drawing.Point(277, 5);
            this.ckxncz5.Name = "ckxncz5";
            this.ckxncz5.Size = new System.Drawing.Size(138, 30);
            this.ckxncz5.TabIndex = 3;
            this.ckxncz5.Text = "感觉障碍";
            this.ckxncz5.UseVisualStyleBackColor = true;
            // 
            // ckxncz4
            // 
            this.ckxncz4.AutoSize = true;
            this.ckxncz4.Location = new System.Drawing.Point(200, 5);
            this.ckxncz4.Name = "ckxncz4";
            this.ckxncz4.Size = new System.Drawing.Size(86, 30);
            this.ckxncz4.TabIndex = 2;
            this.ckxncz4.Text = "面瘫";
            this.ckxncz4.UseVisualStyleBackColor = true;
            // 
            // ckxncz3
            // 
            this.ckxncz3.AutoSize = true;
            this.ckxncz3.Location = new System.Drawing.Point(123, 5);
            this.ckxncz3.Name = "ckxncz3";
            this.ckxncz3.Size = new System.Drawing.Size(86, 30);
            this.ckxncz3.TabIndex = 1;
            this.ckxncz3.Text = "失语";
            this.ckxncz3.UseVisualStyleBackColor = true;
            // 
            // ckxncz2
            // 
            this.ckxncz2.AutoSize = true;
            this.ckxncz2.Location = new System.Drawing.Point(4, 5);
            this.ckxncz2.Name = "ckxncz2";
            this.ckxncz2.Size = new System.Drawing.Size(138, 30);
            this.ckxncz2.TabIndex = 0;
            this.ckxncz2.Text = "构音障碍";
            this.ckxncz2.UseVisualStyleBackColor = true;
            // 
            // ckxncz1
            // 
            this.ckxncz1.AutoSize = true;
            this.ckxncz1.Location = new System.Drawing.Point(192, 236);
            this.ckxncz1.Name = "ckxncz1";
            this.ckxncz1.Size = new System.Drawing.Size(112, 30);
            this.ckxncz1.TabIndex = 8;
            this.ckxncz1.Text = "无症状";
            this.ckxncz1.UseVisualStyleBackColor = true;
            // 
            // pnmqzz
            // 
            this.pnmqzz.Controls.Add(this.ckOth);
            this.pnmqzz.Controls.Add(this.ckxZhz7);
            this.pnmqzz.Controls.Add(this.ckxZhz6);
            this.pnmqzz.Controls.Add(this.ckxZhz5);
            this.pnmqzz.Controls.Add(this.ckxZhz4);
            this.pnmqzz.Controls.Add(this.tbSyOther);
            this.pnmqzz.Controls.Add(this.ckxZhz3);
            this.pnmqzz.Controls.Add(this.ckxZhz2);
            this.pnmqzz.Location = new System.Drawing.Point(281, 106);
            this.pnmqzz.Name = "pnmqzz";
            this.pnmqzz.Size = new System.Drawing.Size(1033, 37);
            this.pnmqzz.TabIndex = 3;
            // 
            // ckOth
            // 
            this.ckOth.AutoSize = true;
            this.ckOth.Location = new System.Drawing.Point(780, 5);
            this.ckOth.Name = "ckOth";
            this.ckOth.Size = new System.Drawing.Size(151, 30);
            this.ckOth.TabIndex = 6;
            this.ckOth.Text = "8其他症状";
            this.ckOth.UseVisualStyleBackColor = true;
            this.ckOth.CheckedChanged += new System.EventHandler(this.ckOth_CheckedChanged);
            // 
            // ckxZhz7
            // 
            this.ckxZhz7.AutoSize = true;
            this.ckxZhz7.Location = new System.Drawing.Point(651, 5);
            this.ckxZhz7.Name = "ckxZhz7";
            this.ckxZhz7.Size = new System.Drawing.Size(151, 30);
            this.ckxZhz7.TabIndex = 5;
            this.ckxZhz7.Text = "7智力障碍";
            this.ckxZhz7.UseVisualStyleBackColor = true;
            // 
            // ckxZhz6
            // 
            this.ckxZhz6.AutoSize = true;
            this.ckxZhz6.Location = new System.Drawing.Point(523, 5);
            this.ckxZhz6.Name = "ckxZhz6";
            this.ckxZhz6.Size = new System.Drawing.Size(151, 30);
            this.ckxZhz6.TabIndex = 4;
            this.ckxZhz6.Text = "6舌强言蹇";
            this.ckxZhz6.UseVisualStyleBackColor = true;
            // 
            // ckxZhz5
            // 
            this.ckxZhz5.AutoSize = true;
            this.ckxZhz5.Location = new System.Drawing.Point(400, 5);
            this.ckxZhz5.Name = "ckxZhz5";
            this.ckxZhz5.Size = new System.Drawing.Size(151, 30);
            this.ckxZhz5.TabIndex = 3;
            this.ckxZhz5.Text = "5半身不遂";
            this.ckxZhz5.UseVisualStyleBackColor = true;
            // 
            // ckxZhz4
            // 
            this.ckxZhz4.AutoSize = true;
            this.ckxZhz4.Location = new System.Drawing.Point(256, 5);
            this.ckxZhz4.Name = "ckxZhz4";
            this.ckxZhz4.Size = new System.Drawing.Size(177, 30);
            this.ckxZhz4.TabIndex = 2;
            this.ckxZhz4.Text = "4嘴、眼歪斜";
            this.ckxZhz4.UseVisualStyleBackColor = true;
            // 
            // ckxZhz3
            // 
            this.ckxZhz3.AutoSize = true;
            this.ckxZhz3.Location = new System.Drawing.Point(123, 5);
            this.ckxZhz3.Name = "ckxZhz3";
            this.ckxZhz3.Size = new System.Drawing.Size(151, 30);
            this.ckxZhz3.TabIndex = 1;
            this.ckxZhz3.Text = "3不省人事";
            this.ckxZhz3.UseVisualStyleBackColor = true;
            // 
            // ckxZhz2
            // 
            this.ckxZhz2.AutoSize = true;
            this.ckxZhz2.Location = new System.Drawing.Point(4, 5);
            this.ckxZhz2.Name = "ckxZhz2";
            this.ckxZhz2.Size = new System.Drawing.Size(151, 30);
            this.ckxZhz2.TabIndex = 0;
            this.ckxZhz2.Text = "2猝然昏扑";
            this.ckxZhz2.UseVisualStyleBackColor = true;
            // 
            // ckxZhz1
            // 
            this.ckxZhz1.AutoSize = true;
            this.ckxZhz1.Location = new System.Drawing.Point(192, 111);
            this.ckxZhz1.Name = "ckxZhz1";
            this.ckxZhz1.Size = new System.Drawing.Size(73, 30);
            this.ckxZhz1.TabIndex = 2;
            this.ckxZhz1.Text = "1无";
            this.ckxZhz1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 26);
            this.label10.TabIndex = 217;
            this.label10.Text = "脑卒中并发症情况:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 237);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 26);
            this.label11.TabIndex = 217;
            this.label11.Text = "新发卒中症状:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(87, 155);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(129, 26);
            this.label29.TabIndex = 217;
            this.label29.Text = "个人病史:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(87, 111);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(129, 26);
            this.label30.TabIndex = 217;
            this.label30.Text = "目前症状:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(189, 70);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(155, 26);
            this.label32.TabIndex = 2;
            this.label32.Text = "脑卒中部位:";
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.rdnczlx7);
            this.panel22.Controls.Add(this.rdnczlx6);
            this.panel22.Controls.Add(this.rdnczlx5);
            this.panel22.Controls.Add(this.rdnczlx4);
            this.panel22.Controls.Add(this.rdnczlx3);
            this.panel22.Controls.Add(this.rdnczlx2);
            this.panel22.Controls.Add(this.rdnczlx1);
            this.panel22.Location = new System.Drawing.Point(192, 20);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(996, 39);
            this.panel22.TabIndex = 0;
            // 
            // rdnczlx7
            // 
            this.rdnczlx7.AutoSize = true;
            this.rdnczlx7.Location = new System.Drawing.Point(796, 4);
            this.rdnczlx7.Name = "rdnczlx7";
            this.rdnczlx7.Size = new System.Drawing.Size(189, 30);
            this.rdnczlx7.TabIndex = 6;
            this.rdnczlx7.TabStop = true;
            this.rdnczlx7.Text = "未分类脑卒中";
            this.rdnczlx7.UseVisualStyleBackColor = true;
            // 
            // rdnczlx6
            // 
            this.rdnczlx6.AutoSize = true;
            this.rdnczlx6.Location = new System.Drawing.Point(633, 4);
            this.rdnczlx6.Name = "rdnczlx6";
            this.rdnczlx6.Size = new System.Drawing.Size(189, 30);
            this.rdnczlx6.TabIndex = 5;
            this.rdnczlx6.TabStop = true;
            this.rdnczlx6.Text = "分水岭脑梗死";
            this.rdnczlx6.UseVisualStyleBackColor = true;
            // 
            // rdnczlx5
            // 
            this.rdnczlx5.AutoSize = true;
            this.rdnczlx5.Location = new System.Drawing.Point(500, 4);
            this.rdnczlx5.Name = "rdnczlx5";
            this.rdnczlx5.Size = new System.Drawing.Size(163, 30);
            this.rdnczlx5.TabIndex = 4;
            this.rdnczlx5.TabStop = true;
            this.rdnczlx5.Text = "腔隙性梗死";
            this.rdnczlx5.UseVisualStyleBackColor = true;
            // 
            // rdnczlx4
            // 
            this.rdnczlx4.AutoSize = true;
            this.rdnczlx4.Location = new System.Drawing.Point(406, 4);
            this.rdnczlx4.Name = "rdnczlx4";
            this.rdnczlx4.Size = new System.Drawing.Size(111, 30);
            this.rdnczlx4.TabIndex = 3;
            this.rdnczlx4.TabStop = true;
            this.rdnczlx4.Text = "脑栓塞";
            this.rdnczlx4.UseVisualStyleBackColor = true;
            // 
            // rdnczlx3
            // 
            this.rdnczlx3.AutoSize = true;
            this.rdnczlx3.Location = new System.Drawing.Point(271, 5);
            this.rdnczlx3.Name = "rdnczlx3";
            this.rdnczlx3.Size = new System.Drawing.Size(163, 30);
            this.rdnczlx3.TabIndex = 2;
            this.rdnczlx3.TabStop = true;
            this.rdnczlx3.Text = "脑血栓形成";
            this.rdnczlx3.UseVisualStyleBackColor = true;
            // 
            // rdnczlx2
            // 
            this.rdnczlx2.AutoSize = true;
            this.rdnczlx2.Location = new System.Drawing.Point(175, 5);
            this.rdnczlx2.Name = "rdnczlx2";
            this.rdnczlx2.Size = new System.Drawing.Size(111, 30);
            this.rdnczlx2.TabIndex = 1;
            this.rdnczlx2.TabStop = true;
            this.rdnczlx2.Text = "脑出血";
            this.rdnczlx2.UseVisualStyleBackColor = true;
            // 
            // rdnczlx1
            // 
            this.rdnczlx1.AutoSize = true;
            this.rdnczlx1.Location = new System.Drawing.Point(3, 4);
            this.rdnczlx1.Name = "rdnczlx1";
            this.rdnczlx1.Size = new System.Drawing.Size(215, 30);
            this.rdnczlx1.TabIndex = 0;
            this.rdnczlx1.TabStop = true;
            this.rdnczlx1.Text = "蛛网膜下腔出血";
            this.rdnczlx1.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(67, 27);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(155, 26);
            this.label33.TabIndex = 0;
            this.label33.Text = "脑卒中类型:";
            // 
            // cmbnczbw
            // 
            this.cmbnczbw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbnczbw.FormattingEnabled = true;
            this.cmbnczbw.Location = new System.Drawing.Point(315, 66);
            this.cmbnczbw.Name = "cmbnczbw";
            this.cmbnczbw.Size = new System.Drawing.Size(138, 33);
            this.cmbnczbw.TabIndex = 1;
            // 
            // ckmqzzw
            // 
            this.ckmqzzw.AutoSize = true;
            this.ckmqzzw.Location = new System.Drawing.Point(85, 59);
            this.ckmqzzw.Name = "ckmqzzw";
            this.ckmqzzw.Size = new System.Drawing.Size(47, 18);
            this.ckmqzzw.TabIndex = 218;
            this.ckmqzzw.Text = "1无";
            this.ckmqzzw.UseVisualStyleBackColor = true;
            // 
            // ckmqzzbsbs
            // 
            this.ckmqzzbsbs.AutoSize = true;
            this.ckmqzzbsbs.Location = new System.Drawing.Point(299, 5);
            this.ckmqzzbsbs.Name = "ckmqzzbsbs";
            this.ckmqzzbsbs.Size = new System.Drawing.Size(89, 18);
            this.ckmqzzbsbs.TabIndex = 0;
            this.ckmqzzbsbs.Text = "5半身不遂";
            this.ckmqzzbsbs.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.yongYao4);
            this.groupBox6.Controls.Add(this.yongYao3);
            this.groupBox6.Controls.Add(this.yongYao2);
            this.groupBox6.Controls.Add(this.yongYao1);
            this.groupBox6.Location = new System.Drawing.Point(56, 670);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1317, 122);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            // 
            // yongYao4
            // 
            this.yongYao4.ErrorInput = false;
            this.yongYao4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYao4.Location = new System.Drawing.Point(660, 69);
            this.yongYao4.Margin = new System.Windows.Forms.Padding(4);
            this.yongYao4.MText = "其他药物";
            this.yongYao4.Name = "yongYao4";
            this.yongYao4.Size = new System.Drawing.Size(654, 37);
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
            this.yongYao3.Location = new System.Drawing.Point(3, 69);
            this.yongYao3.Margin = new System.Windows.Forms.Padding(4);
            this.yongYao3.MText = "药物名称3";
            this.yongYao3.Name = "yongYao3";
            this.yongYao3.Size = new System.Drawing.Size(658, 38);
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
            this.yongYao2.Location = new System.Drawing.Point(660, 18);
            this.yongYao2.Margin = new System.Windows.Forms.Padding(4);
            this.yongYao2.MText = "药物名称2";
            this.yongYao2.Name = "yongYao2";
            this.yongYao2.Size = new System.Drawing.Size(654, 43);
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
            this.yongYao1.Location = new System.Drawing.Point(3, 17);
            this.yongYao1.Margin = new System.Windows.Forms.Padding(4);
            this.yongYao1.MText = "药物名称1";
            this.yongYao1.Name = "yongYao1";
            this.yongYao1.Size = new System.Drawing.Size(654, 37);
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
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.yongYaoyc4);
            this.groupBox8.Controls.Add(this.yongYaoyc3);
            this.groupBox8.Controls.Add(this.yongYaoyc2);
            this.groupBox8.Controls.Add(this.yongYaoyc1);
            this.groupBox8.Location = new System.Drawing.Point(56, 670);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1317, 122);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            // 
            // yongYaoyc4
            // 
            this.yongYaoyc4.ErrorInput = false;
            this.yongYaoyc4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoyc4.Location = new System.Drawing.Point(673, 69);
            this.yongYaoyc4.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoyc4.MText = "其他药物";
            this.yongYaoyc4.Name = "yongYaoyc4";
            this.yongYaoyc4.Size = new System.Drawing.Size(641, 37);
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
            this.yongYaoyc3.Location = new System.Drawing.Point(11, 68);
            this.yongYaoyc3.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoyc3.MText = "药物名称3";
            this.yongYaoyc3.Name = "yongYaoyc3";
            this.yongYaoyc3.Size = new System.Drawing.Size(640, 40);
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
            this.yongYaoyc3.TabIndex = 1;
            // 
            // yongYaoyc2
            // 
            this.yongYaoyc2.ErrorInput = false;
            this.yongYaoyc2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoyc2.Location = new System.Drawing.Point(673, 20);
            this.yongYaoyc2.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoyc2.MText = "药物名称2";
            this.yongYaoyc2.Name = "yongYaoyc2";
            this.yongYaoyc2.Size = new System.Drawing.Size(641, 34);
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
            this.yongYaoyc2.TabIndex = 2;
            // 
            // yongYaoyc1
            // 
            this.yongYaoyc1.ErrorInput = false;
            this.yongYaoyc1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yongYaoyc1.Location = new System.Drawing.Point(11, 20);
            this.yongYaoyc1.Margin = new System.Windows.Forms.Padding(4);
            this.yongYaoyc1.MText = "药物名称1";
            this.yongYaoyc1.Name = "yongYaoyc1";
            this.yongYaoyc1.Size = new System.Drawing.Size(641, 39);
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
            this.yongYaoyc1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Location = new System.Drawing.Point(32, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1417, 637);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbZzYy);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.tbZzKs);
            this.groupBox4.Controls.Add(this.dtpNext);
            this.groupBox4.Controls.Add(this.panel11);
            this.groupBox4.Location = new System.Drawing.Point(56, 1031);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1317, 57);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // tbZzYy
            // 
            this.tbZzYy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZzYy.Location = new System.Drawing.Point(374, 18);
            this.tbZzYy.MaxLength = 20;
            this.tbZzYy.Name = "tbZzYy";
            this.tbZzYy.ReadOnly = true;
            this.tbZzYy.Size = new System.Drawing.Size(155, 36);
            this.tbZzYy.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(11, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 26);
            this.label7.TabIndex = 190;
            this.label7.Text = "是否转诊:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(269, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(129, 26);
            this.label17.TabIndex = 1;
            this.label17.Text = "转诊原因:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(553, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(207, 26);
            this.label18.TabIndex = 194;
            this.label18.Text = "转诊机构及科别:";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.Location = new System.Drawing.Point(872, 22);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(181, 26);
            this.label55.TabIndex = 217;
            this.label55.Text = "下次随访日期:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(1215, 28);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.linkLabel1.Size = new System.Drawing.Size(123, 21);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "编辑常用药";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tbZzKs
            // 
            this.tbZzKs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZzKs.Location = new System.Drawing.Point(714, 20);
            this.tbZzKs.MaxLength = 20;
            this.tbZzKs.Name = "tbZzKs";
            this.tbZzKs.ReadOnly = true;
            this.tbZzKs.Size = new System.Drawing.Size(136, 36);
            this.tbZzKs.TabIndex = 3;
            // 
            // dtpNext
            // 
            this.dtpNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpNext.Location = new System.Drawing.Point(1017, 20);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(181, 36);
            this.dtpNext.TabIndex = 4;
            // 
            // panel11
            // 
            this.panel11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel11.Controls.Add(this.rdNoZz);
            this.panel11.Controls.Add(this.rdYesZz);
            this.panel11.Location = new System.Drawing.Point(111, 19);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(139, 32);
            this.panel11.TabIndex = 0;
            // 
            // rdNoZz
            // 
            this.rdNoZz.AutoSize = true;
            this.rdNoZz.Location = new System.Drawing.Point(81, 4);
            this.rdNoZz.Name = "rdNoZz";
            this.rdNoZz.Size = new System.Drawing.Size(59, 30);
            this.rdNoZz.TabIndex = 1;
            this.rdNoZz.TabStop = true;
            this.rdNoZz.Text = "否";
            this.rdNoZz.UseVisualStyleBackColor = true;
            // 
            // rdYesZz
            // 
            this.rdYesZz.AutoSize = true;
            this.rdYesZz.Location = new System.Drawing.Point(8, 4);
            this.rdYesZz.Name = "rdYesZz";
            this.rdYesZz.Size = new System.Drawing.Size(59, 30);
            this.rdYesZz.TabIndex = 0;
            this.rdYesZz.TabStop = true;
            this.rdYesZz.Text = "是";
            this.rdYesZz.UseVisualStyleBackColor = true;
            this.rdYesZz.CheckedChanged += new System.EventHandler(this.rdYesZz_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbshnfzl);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.ckjkzl1);
            this.groupBox2.Controls.Add(this.panel16);
            this.groupBox2.Controls.Add(this.cmbztgnhfqk);
            this.groupBox2.Controls.Add(this.pnkfzl);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbxObeyDoctor);
            this.groupBox2.Controls.Add(this.cbxComplance);
            this.groupBox2.Controls.Add(this.label51);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label50);
            this.groupBox2.Controls.Add(this.cksffl1);
            this.groupBox2.Controls.Add(this.tbdoctorview);
            this.groupBox2.Controls.Add(this.label48);
            this.groupBox2.Controls.Add(this.tbAidCheck);
            this.groupBox2.Controls.Add(this.pnsffl);
            this.groupBox2.Controls.Add(this.label52);
            this.groupBox2.Location = new System.Drawing.Point(56, 800);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1317, 225);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 26);
            this.label2.TabIndex = 233;
            this.label2.Text = "生活能否自理能力:";
            // 
            // cmbshnfzl
            // 
            this.cmbshnfzl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbshnfzl.FormattingEnabled = true;
            this.cmbshnfzl.Location = new System.Drawing.Point(197, 60);
            this.cmbshnfzl.Name = "cmbshnfzl";
            this.cmbshnfzl.Size = new System.Drawing.Size(134, 33);
            this.cmbshnfzl.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(832, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(181, 26);
            this.label21.TabIndex = 226;
            this.label21.Text = "药物不良反应:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(717, 62);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(155, 26);
            this.label20.TabIndex = 233;
            this.label20.Text = "服药依从性:";
            // 
            // ckjkzl1
            // 
            this.ckjkzl1.AutoSize = true;
            this.ckjkzl1.Location = new System.Drawing.Point(196, 107);
            this.ckjkzl1.Name = "ckjkzl1";
            this.ckjkzl1.Size = new System.Drawing.Size(60, 30);
            this.ckjkzl1.TabIndex = 218;
            this.ckjkzl1.Text = "无";
            this.ckjkzl1.UseVisualStyleBackColor = true;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.tbAdverseReaction);
            this.panel16.Controls.Add(this.rdAdverseReactionYes);
            this.panel16.Controls.Add(this.rdAdverseReactionNo);
            this.panel16.Location = new System.Drawing.Point(974, 99);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(310, 34);
            this.panel16.TabIndex = 6;
            // 
            // tbAdverseReaction
            // 
            this.tbAdverseReaction.Location = new System.Drawing.Point(143, 2);
            this.tbAdverseReaction.MaxLength = 100;
            this.tbAdverseReaction.Name = "tbAdverseReaction";
            this.tbAdverseReaction.Size = new System.Drawing.Size(142, 36);
            this.tbAdverseReaction.TabIndex = 2;
            // 
            // rdAdverseReactionYes
            // 
            this.rdAdverseReactionYes.AutoSize = true;
            this.rdAdverseReactionYes.Location = new System.Drawing.Point(81, 5);
            this.rdAdverseReactionYes.Name = "rdAdverseReactionYes";
            this.rdAdverseReactionYes.Size = new System.Drawing.Size(59, 30);
            this.rdAdverseReactionYes.TabIndex = 1;
            this.rdAdverseReactionYes.TabStop = true;
            this.rdAdverseReactionYes.Text = "有";
            this.rdAdverseReactionYes.UseVisualStyleBackColor = true;
            // 
            // rdAdverseReactionNo
            // 
            this.rdAdverseReactionNo.AutoSize = true;
            this.rdAdverseReactionNo.Location = new System.Drawing.Point(7, 5);
            this.rdAdverseReactionNo.Name = "rdAdverseReactionNo";
            this.rdAdverseReactionNo.Size = new System.Drawing.Size(59, 30);
            this.rdAdverseReactionNo.TabIndex = 0;
            this.rdAdverseReactionNo.TabStop = true;
            this.rdAdverseReactionNo.Text = "无";
            this.rdAdverseReactionNo.UseVisualStyleBackColor = true;
            // 
            // cmbztgnhfqk
            // 
            this.cmbztgnhfqk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbztgnhfqk.FormattingEnabled = true;
            this.cmbztgnhfqk.Location = new System.Drawing.Point(548, 59);
            this.cmbztgnhfqk.Name = "cmbztgnhfqk";
            this.cmbztgnhfqk.Size = new System.Drawing.Size(128, 33);
            this.cmbztgnhfqk.TabIndex = 2;
            // 
            // pnkfzl
            // 
            this.pnkfzl.Controls.Add(this.tbjkzlother);
            this.pnkfzl.Controls.Add(this.ckjkzl5);
            this.pnkfzl.Controls.Add(this.ckjkzl4);
            this.pnkfzl.Controls.Add(this.ckjkzl3);
            this.pnkfzl.Controls.Add(this.ckjkzl2);
            this.pnkfzl.Location = new System.Drawing.Point(254, 99);
            this.pnkfzl.Name = "pnkfzl";
            this.pnkfzl.Size = new System.Drawing.Size(565, 42);
            this.pnkfzl.TabIndex = 5;
            // 
            // tbjkzlother
            // 
            this.tbjkzlother.Location = new System.Drawing.Point(392, 4);
            this.tbjkzlother.Name = "tbjkzlother";
            this.tbjkzlother.ReadOnly = true;
            this.tbjkzlother.Size = new System.Drawing.Size(158, 36);
            this.tbjkzlother.TabIndex = 4;
            // 
            // ckjkzl5
            // 
            this.ckjkzl5.AutoSize = true;
            this.ckjkzl5.Location = new System.Drawing.Point(273, 7);
            this.ckjkzl5.Name = "ckjkzl5";
            this.ckjkzl5.Size = new System.Drawing.Size(138, 30);
            this.ckjkzl5.TabIndex = 3;
            this.ckjkzl5.Text = "其他方式";
            this.ckjkzl5.UseVisualStyleBackColor = true;
            // 
            // ckjkzl4
            // 
            this.ckjkzl4.AutoSize = true;
            this.ckjkzl4.Location = new System.Drawing.Point(152, 7);
            this.ckjkzl4.Name = "ckjkzl4";
            this.ckjkzl4.Size = new System.Drawing.Size(138, 30);
            this.ckjkzl4.TabIndex = 2;
            this.ckjkzl4.Text = "运动训练";
            this.ckjkzl4.UseVisualStyleBackColor = true;
            // 
            // ckjkzl3
            // 
            this.ckjkzl3.AutoSize = true;
            this.ckjkzl3.Location = new System.Drawing.Point(78, 7);
            this.ckjkzl3.Name = "ckjkzl3";
            this.ckjkzl3.Size = new System.Drawing.Size(86, 30);
            this.ckjkzl3.TabIndex = 1;
            this.ckjkzl3.Text = "针灸";
            this.ckjkzl3.UseVisualStyleBackColor = true;
            // 
            // ckjkzl2
            // 
            this.ckjkzl2.AutoSize = true;
            this.ckjkzl2.Location = new System.Drawing.Point(4, 7);
            this.ckjkzl2.Name = "ckjkzl2";
            this.ckjkzl2.Size = new System.Drawing.Size(86, 30);
            this.ckjkzl2.TabIndex = 0;
            this.ckjkzl2.Text = "按摩";
            this.ckjkzl2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(1009, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 26);
            this.label5.TabIndex = 232;
            this.label5.Text = "遵医行为:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxObeyDoctor
            // 
            this.cbxObeyDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxObeyDoctor.FormattingEnabled = true;
            this.cbxObeyDoctor.Location = new System.Drawing.Point(1117, 58);
            this.cbxObeyDoctor.Name = "cbxObeyDoctor";
            this.cbxObeyDoctor.Size = new System.Drawing.Size(142, 33);
            this.cbxObeyDoctor.TabIndex = 4;
            // 
            // cbxComplance
            // 
            this.cbxComplance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxComplance.FormattingEnabled = true;
            this.cbxComplance.Location = new System.Drawing.Point(840, 58);
            this.cbxComplance.Name = "cbxComplance";
            this.cbxComplance.Size = new System.Drawing.Size(133, 33);
            this.cbxComplance.TabIndex = 3;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label51.Location = new System.Drawing.Point(365, 63);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(233, 26);
            this.label51.TabIndex = 236;
            this.label51.Text = "肢体功能恢复情况:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 26);
            this.label4.TabIndex = 217;
            this.label4.Text = "康复治疗的方式:";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.Location = new System.Drawing.Point(47, 153);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(181, 26);
            this.label50.TabIndex = 236;
            this.label50.Text = "此次随访分类:";
            // 
            // cksffl1
            // 
            this.cksffl1.AutoSize = true;
            this.cksffl1.Location = new System.Drawing.Point(196, 152);
            this.cksffl1.Name = "cksffl1";
            this.cksffl1.Size = new System.Drawing.Size(138, 30);
            this.cksffl1.TabIndex = 7;
            this.cksffl1.Text = "控制满意";
            this.cksffl1.UseVisualStyleBackColor = true;
            this.cksffl1.CheckedChanged += new System.EventHandler(this.cksfflmy_CheckedChanged);
            // 
            // tbdoctorview
            // 
            this.tbdoctorview.Location = new System.Drawing.Point(190, 191);
            this.tbdoctorview.Name = "tbdoctorview";
            this.tbdoctorview.Size = new System.Drawing.Size(886, 36);
            this.tbdoctorview.TabIndex = 9;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label48.Location = new System.Drawing.Point(87, 18);
            this.label48.Margin = new System.Windows.Forms.Padding(0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(104, 37);
            this.label48.TabIndex = 231;
            this.label48.Text = "辅助检查:";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbAidCheck
            // 
            this.tbAidCheck.Location = new System.Drawing.Point(197, 15);
            this.tbAidCheck.MaxLength = 100;
            this.tbAidCheck.Name = "tbAidCheck";
            this.tbAidCheck.Size = new System.Drawing.Size(1062, 36);
            this.tbAidCheck.TabIndex = 0;
            // 
            // pnsffl
            // 
            this.pnsffl.Controls.Add(this.tbbfzother);
            this.pnsffl.Controls.Add(this.cksffl4);
            this.pnsffl.Controls.Add(this.cksffl3);
            this.pnsffl.Controls.Add(this.cksffl2);
            this.pnsffl.Location = new System.Drawing.Point(192, 147);
            this.pnsffl.Name = "pnsffl";
            this.pnsffl.Size = new System.Drawing.Size(1092, 38);
            this.pnsffl.TabIndex = 8;
            // 
            // tbbfzother
            // 
            this.tbbfzother.Location = new System.Drawing.Point(474, 6);
            this.tbbfzother.Name = "tbbfzother";
            this.tbbfzother.ReadOnly = true;
            this.tbbfzother.Size = new System.Drawing.Size(593, 36);
            this.tbbfzother.TabIndex = 3;
            // 
            // cksffl4
            // 
            this.cksffl4.AutoSize = true;
            this.cksffl4.Location = new System.Drawing.Point(380, 5);
            this.cksffl4.Name = "cksffl4";
            this.cksffl4.Size = new System.Drawing.Size(125, 30);
            this.cksffl4.TabIndex = 2;
            this.cksffl4.Text = "并发症 ";
            this.cksffl4.UseVisualStyleBackColor = true;
            this.cksffl4.CheckedChanged += new System.EventHandler(this.cksffl4_CheckedChanged);
            // 
            // cksffl3
            // 
            this.cksffl3.AutoSize = true;
            this.cksffl3.Location = new System.Drawing.Point(258, 5);
            this.cksffl3.Name = "cksffl3";
            this.cksffl3.Size = new System.Drawing.Size(138, 30);
            this.cksffl3.TabIndex = 1;
            this.cksffl3.Text = "不良反应";
            this.cksffl3.UseVisualStyleBackColor = true;
            // 
            // cksffl2
            // 
            this.cksffl2.AutoSize = true;
            this.cksffl2.Location = new System.Drawing.Point(123, 5);
            this.cksffl2.Name = "cksffl2";
            this.cksffl2.Size = new System.Drawing.Size(164, 30);
            this.cksffl2.TabIndex = 0;
            this.cksffl2.Text = "控制不满意";
            this.cksffl2.UseVisualStyleBackColor = true;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(7, 194);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(233, 26);
            this.label52.TabIndex = 260;
            this.label52.Text = "本次随访医生建议:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbTizhOth);
            this.groupBox3.Controls.Add(this.btnWeight);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbWeight);
            this.groupBox3.Controls.Add(this.tbHype);
            this.groupBox3.Controls.Add(this.btnSelectHyp);
            this.groupBox3.Controls.Add(this.btnyaowei);
            this.groupBox3.Controls.Add(this.btnBMI);
            this.groupBox3.Controls.Add(this.label49);
            this.groupBox3.Controls.Add(this.label53);
            this.groupBox3.Controls.Add(this.label54);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbWhatDrug);
            this.groupBox3.Controls.Add(this.tbhight);
            this.groupBox3.Controls.Add(this.label56);
            this.groupBox3.Controls.Add(this.label57);
            this.groupBox3.Controls.Add(this.tbkfxt);
            this.groupBox3.Controls.Add(this.label58);
            this.groupBox3.Controls.Add(this.tbyaowei);
            this.groupBox3.Controls.Add(this.label59);
            this.groupBox3.Controls.Add(this.label60);
            this.groupBox3.Controls.Add(this.tbBMI);
            this.groupBox3.Controls.Add(this.label61);
            this.groupBox3.Controls.Add(this.label62);
            this.groupBox3.Controls.Add(this.label63);
            this.groupBox3.Controls.Add(this.label64);
            this.groupBox3.Location = new System.Drawing.Point(56, 553);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1317, 110);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "体检结果";
            // 
            // tbTizhOth
            // 
            this.tbTizhOth.Location = new System.Drawing.Point(666, 65);
            this.tbTizhOth.MaxLength = 100;
            this.tbTizhOth.Name = "tbTizhOth";
            this.tbTizhOth.Size = new System.Drawing.Size(180, 36);
            this.tbTizhOth.TabIndex = 10;
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(502, 21);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(44, 27);
            this.btnWeight.TabIndex = 2;
            this.btnWeight.Text = ".....";
            this.btnWeight.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(601, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 26);
            this.label6.TabIndex = 193;
            this.label6.Text = "其他:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbWeight
            // 
            this.tbWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWeight.ForeColor = System.Drawing.Color.Black;
            this.tbWeight.Location = new System.Drawing.Point(405, 23);
            this.tbWeight.MaxLength = 6;
            this.tbWeight.Multiline = true;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(73, 25);
            this.tbWeight.TabIndex = 1;
            // 
            // tbHype
            // 
            this.tbHype.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHype.ForeColor = System.Drawing.Color.Black;
            this.tbHype.Location = new System.Drawing.Point(74, 67);
            this.tbHype.Multiline = true;
            this.tbHype.Name = "tbHype";
            this.tbHype.Size = new System.Drawing.Size(77, 25);
            this.tbHype.TabIndex = 7;
            // 
            // btnSelectHyp
            // 
            this.btnSelectHyp.Location = new System.Drawing.Point(209, 63);
            this.btnSelectHyp.Name = "btnSelectHyp";
            this.btnSelectHyp.Size = new System.Drawing.Size(44, 29);
            this.btnSelectHyp.TabIndex = 8;
            this.btnSelectHyp.Text = ".....";
            this.btnSelectHyp.UseVisualStyleBackColor = true;
            // 
            // btnyaowei
            // 
            this.btnyaowei.Location = new System.Drawing.Point(1238, 21);
            this.btnyaowei.Name = "btnyaowei";
            this.btnyaowei.Size = new System.Drawing.Size(65, 27);
            this.btnyaowei.TabIndex = 6;
            this.btnyaowei.Text = "计算";
            this.btnyaowei.UseVisualStyleBackColor = true;
            this.btnyaowei.Click += new System.EventHandler(this.btnyaowei_Click);
            // 
            // btnBMI
            // 
            this.btnBMI.Location = new System.Drawing.Point(818, 21);
            this.btnBMI.Name = "btnBMI";
            this.btnBMI.Size = new System.Drawing.Size(61, 27);
            this.btnBMI.TabIndex = 4;
            this.btnBMI.Text = "计算";
            this.btnBMI.UseVisualStyleBackColor = true;
            this.btnBMI.Click += new System.EventHandler(this.btnBMI_Click);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label49.Location = new System.Drawing.Point(10, 70);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(77, 26);
            this.label49.TabIndex = 189;
            this.label49.Text = "血压:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label53.Location = new System.Drawing.Point(156, 69);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(64, 26);
            this.label53.TabIndex = 145;
            this.label53.Text = "mmhg";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.Location = new System.Drawing.Point(11, 28);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(77, 26);
            this.label54.TabIndex = 223;
            this.label54.Text = "身高:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(941, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(233, 26);
            this.label9.TabIndex = 246;
            this.label9.Text = "服用何种药物防治:";
            // 
            // tbWhatDrug
            // 
            this.tbWhatDrug.Location = new System.Drawing.Point(1128, 61);
            this.tbWhatDrug.MaxLength = 100;
            this.tbWhatDrug.Name = "tbWhatDrug";
            this.tbWhatDrug.Size = new System.Drawing.Size(175, 36);
            this.tbWhatDrug.TabIndex = 11;
            // 
            // tbhight
            // 
            this.tbhight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbhight.ForeColor = System.Drawing.Color.Black;
            this.tbhight.Location = new System.Drawing.Point(74, 24);
            this.tbhight.MaxLength = 6;
            this.tbhight.Multiline = true;
            this.tbhight.Name = "tbhight";
            this.tbhight.Size = new System.Drawing.Size(77, 24);
            this.tbhight.TabIndex = 0;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label56.Location = new System.Drawing.Point(296, 71);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(129, 26);
            this.label56.TabIndex = 223;
            this.label56.Text = "空腹血糖:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.Location = new System.Drawing.Point(1061, 26);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(77, 26);
            this.label57.TabIndex = 223;
            this.label57.Text = "腰围:";
            // 
            // tbkfxt
            // 
            this.tbkfxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbkfxt.ForeColor = System.Drawing.Color.Black;
            this.tbkfxt.Location = new System.Drawing.Point(406, 65);
            this.tbkfxt.MaxLength = 6;
            this.tbkfxt.Multiline = true;
            this.tbkfxt.Name = "tbkfxt";
            this.tbkfxt.Size = new System.Drawing.Size(60, 30);
            this.tbkfxt.TabIndex = 9;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label58.Location = new System.Drawing.Point(611, 25);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(64, 26);
            this.label58.TabIndex = 223;
            this.label58.Text = "BMI:";
            // 
            // tbyaowei
            // 
            this.tbyaowei.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbyaowei.ForeColor = System.Drawing.Color.Black;
            this.tbyaowei.Location = new System.Drawing.Point(1126, 22);
            this.tbyaowei.MaxLength = 6;
            this.tbyaowei.Multiline = true;
            this.tbyaowei.Name = "tbyaowei";
            this.tbyaowei.Size = new System.Drawing.Size(60, 23);
            this.tbyaowei.TabIndex = 5;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label59.Location = new System.Drawing.Point(336, 26);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(77, 26);
            this.label59.TabIndex = 223;
            this.label59.Text = "体重:";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label60.Location = new System.Drawing.Point(469, 69);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(90, 26);
            this.label60.TabIndex = 145;
            this.label60.Text = "mmol/L";
            // 
            // tbBMI
            // 
            this.tbBMI.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBMI.ForeColor = System.Drawing.Color.Black;
            this.tbBMI.Location = new System.Drawing.Point(673, 21);
            this.tbBMI.MaxLength = 6;
            this.tbBMI.Multiline = true;
            this.tbBMI.Name = "tbBMI";
            this.tbBMI.Size = new System.Drawing.Size(72, 26);
            this.tbBMI.TabIndex = 3;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label61.Location = new System.Drawing.Point(1202, 25);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(38, 26);
            this.label61.TabIndex = 145;
            this.label61.Text = "cm";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label62.Location = new System.Drawing.Point(160, 27);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(38, 26);
            this.label62.TabIndex = 145;
            this.label62.Text = "cm";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label63.Location = new System.Drawing.Point(752, 25);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(90, 26);
            this.label63.TabIndex = 145;
            this.label63.Text = "kg/m2 ";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label64.Location = new System.Drawing.Point(479, 26);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(38, 26);
            this.label64.TabIndex = 145;
            this.label64.Text = "㎏";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label38);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label35);
            this.groupBox5.Controls.Add(this.tbminute);
            this.groupBox5.Controls.Add(this.tbdrink);
            this.groupBox5.Controls.Add(this.tbsportweek);
            this.groupBox5.Controls.Add(this.tbsmoke);
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.label39);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Controls.Add(this.label42);
            this.groupBox5.Controls.Add(this.cbxSmokeWine);
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Controls.Add(this.cbxSport);
            this.groupBox5.Controls.Add(this.label46);
            this.groupBox5.Controls.Add(this.cbxSalt);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(56, 429);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1317, 112);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "生活方式指导";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(528, 72);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(129, 26);
            this.label38.TabIndex = 248;
            this.label38.Text = "(分钟/次)";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(529, 31);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(103, 26);
            this.label34.TabIndex = 248;
            this.label34.Text = "(两/天)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(211, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 26);
            this.label16.TabIndex = 248;
            this.label16.Text = "(次/周)";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(211, 32);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(103, 26);
            this.label35.TabIndex = 248;
            this.label35.Text = "(支/天)";
            // 
            // tbminute
            // 
            this.tbminute.Location = new System.Drawing.Point(454, 69);
            this.tbminute.Name = "tbminute";
            this.tbminute.Size = new System.Drawing.Size(71, 36);
            this.tbminute.TabIndex = 5;
            // 
            // tbdrink
            // 
            this.tbdrink.Location = new System.Drawing.Point(454, 27);
            this.tbdrink.Name = "tbdrink";
            this.tbdrink.Size = new System.Drawing.Size(73, 36);
            this.tbdrink.TabIndex = 1;
            // 
            // tbsportweek
            // 
            this.tbsportweek.Location = new System.Drawing.Point(109, 69);
            this.tbsportweek.Name = "tbsportweek";
            this.tbsportweek.Size = new System.Drawing.Size(93, 36);
            this.tbsportweek.TabIndex = 4;
            // 
            // tbsmoke
            // 
            this.tbsmoke.Location = new System.Drawing.Point(109, 28);
            this.tbsmoke.Name = "tbsmoke";
            this.tbsmoke.Size = new System.Drawing.Size(93, 36);
            this.tbsmoke.TabIndex = 0;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(311, 72);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(181, 26);
            this.label36.TabIndex = 246;
            this.label36.Text = "每次持续时间:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(351, 31);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(129, 26);
            this.label39.TabIndex = 246;
            this.label39.Text = "饮酒情况:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(8, 73);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(129, 26);
            this.label40.TabIndex = 246;
            this.label40.Text = "运动频率:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(10, 32);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(129, 26);
            this.label41.TabIndex = 246;
            this.label41.Text = "吸烟情况:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(676, 30);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(181, 26);
            this.label42.TabIndex = 226;
            this.label42.Text = "烟酒注意事项:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxSmokeWine
            // 
            this.cbxSmokeWine.FormattingEnabled = true;
            this.cbxSmokeWine.Items.AddRange(new object[] {
            "戒烟戒酒"});
            this.cbxSmokeWine.Location = new System.Drawing.Point(823, 27);
            this.cbxSmokeWine.Name = "cbxSmokeWine";
            this.cbxSmokeWine.Size = new System.Drawing.Size(118, 33);
            this.cbxSmokeWine.TabIndex = 2;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(676, 73);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(181, 26);
            this.label44.TabIndex = 228;
            this.label44.Text = "运动注意事项:";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxSport
            // 
            this.cbxSport.FormattingEnabled = true;
            this.cbxSport.Items.AddRange(new object[] {
            "适量运动"});
            this.cbxSport.Location = new System.Drawing.Point(825, 69);
            this.cbxSport.Name = "cbxSport";
            this.cbxSport.Size = new System.Drawing.Size(116, 33);
            this.cbxSport.TabIndex = 6;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(985, 32);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(181, 26);
            this.label46.TabIndex = 230;
            this.label46.Text = "摄盐注意事项:";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxSalt
            // 
            this.cbxSalt.FormattingEnabled = true;
            this.cbxSalt.Items.AddRange(new object[] {
            "每天/每人6克盐"});
            this.cbxSalt.Location = new System.Drawing.Point(1131, 29);
            this.cbxSalt.Name = "cbxSalt";
            this.cbxSalt.Size = new System.Drawing.Size(132, 33);
            this.cbxSalt.TabIndex = 3;
            // 
            // cksfflmy
            // 
            this.cksfflmy.AutoSize = true;
            this.cksfflmy.Location = new System.Drawing.Point(109, 122);
            this.cksfflmy.Name = "cksfflmy";
            this.cksfflmy.Size = new System.Drawing.Size(82, 18);
            this.cksfflmy.TabIndex = 218;
            this.cksfflmy.Text = "控制满意";
            this.cksfflmy.UseVisualStyleBackColor = true;
            // 
            // cksfflblfy
            // 
            this.cksfflblfy.AutoSize = true;
            this.cksfflblfy.Location = new System.Drawing.Point(100, 5);
            this.cksfflblfy.Name = "cksfflblfy";
            this.cksfflblfy.Size = new System.Drawing.Size(82, 18);
            this.cksfflblfy.TabIndex = 0;
            this.cksfflblfy.Text = "不良反应";
            this.cksfflblfy.UseVisualStyleBackColor = true;
            // 
            // StrokeVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "StrokeVisitForm";
            this.Text = "StrokeVisitForm";
            this.Load += new System.EventHandler(this.FrmStroke_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.pnnczbfz.ResumeLayout(false);
            this.pnnczbfz.PerformLayout();
            this.pngrbs.ResumeLayout(false);
            this.pngrbs.PerformLayout();
            this.pnxncz.ResumeLayout(false);
            this.pnxncz.PerformLayout();
            this.pnmqzz.ResumeLayout(false);
            this.pnmqzz.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.pnkfzl.ResumeLayout(false);
            this.pnkfzl.PerformLayout();
            this.pnsffl.ResumeLayout(false);
            this.pnsffl.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
            decimal num2;
            if (!string.IsNullOrEmpty(this.tbWeight.Text.Trim()))
            {
                this.strokeFollowup.Weight = Convert.ToDecimal(this.tbWeight.Text.ToString());
            }

            if (!string.IsNullOrEmpty(this.tbHype.Text.Trim()))
            {
                string[] xueyadata = this.tbHype.Text.Trim().Split('/');
                if (xueyadata.Length == 2)
                {
                    if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                    {
                        this.strokeFollowup.Hypertension = Convert.ToDecimal(xueyadata[0].ToString());
                    }
                    else
                    {
                        this.strokeFollowup.Hypertension = null;
                    }
                    if (!string.IsNullOrEmpty(xueyadata[1].ToString()))
                    {
                        this.strokeFollowup.Hypotension = Convert.ToDecimal(xueyadata[1].ToString());
                    }
                    else
                    {
                        this.strokeFollowup.Hypotension = null;
                    }
                }
                else if (xueyadata.Length == 1)
                {
                    if (this.tbHype.Text.Substring(0, 1) == "/")
                    {
                        if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                        {
                            this.strokeFollowup.Hypertension = null;
                            this.strokeFollowup.Hypotension = Convert.ToDecimal(xueyadata[0].ToString());
                        }
                    }
                    else if ((decimal.TryParse(this.tbHype.Text, out num2)) && (num2 != 0M))
                    {
                        if (!string.IsNullOrEmpty(xueyadata[0].ToString()))
                        {
                            this.strokeFollowup.Hypertension = Convert.ToDecimal(xueyadata[0].ToString());
                            this.strokeFollowup.Hypotension = null;
                        }
                    }
                    else
                    {
                        this.tbHype.Text = "";
                        this.strokeFollowup.Hypertension = null;
                        this.strokeFollowup.Hypotension = null;
                    }
                }
            }
            else
            {
                this.strokeFollowup.Hypertension = null;
                this.strokeFollowup.Hypotension = null;
            }

            ChronicStrokeVisitBLL chronicStrokeVisitBLL = new ChronicStrokeVisitBLL();
            ChronicDrugConditionBLL chronicDrugconditionBLL = new ChronicDrugConditionBLL();
            ChronicStrokeVisitModel strokevisitmodel1 = chronicStrokeVisitBLL.GetModelFollowUpDate(this.strokeFollowup);
            if (strokevisitmodel1 != null)
            {
                if (this.IDPerson > 0 && this.visitdate == this.strokeFollowup.FollowupDate.ToString())
                {
                    this.IDPerson = strokevisitmodel1.ID;
                    this.strokeFollowup.ID = strokevisitmodel1.ID;
                    chronicStrokeVisitBLL.Update(this.strokeFollowup);
                }
                else
                {
                    DialogResult result = MessageBox.Show("此日期下已有随访信息，是否进行修改？", "提示", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        chronicStrokeVisitBLL.Delete(this.IDPerson);
                        chronicDrugconditionBLL.DeleteOUTKey(this.IDPerson, "5");
                        this.IDPerson = strokevisitmodel1.ID;
                        this.strokeFollowup.ID = strokevisitmodel1.ID;
                        chronicStrokeVisitBLL.Update(this.strokeFollowup);
                    }
                    else
                        return true;
                }
            }
            else
            {
                if (this.IDPerson > 0)
                {
                    chronicStrokeVisitBLL.Delete(this.IDPerson);
                    chronicDrugconditionBLL.DeleteOUTKey(this.IDPerson, "5");
                }
                this.IDPerson = chronicStrokeVisitBLL.Add(this.strokeFollowup);
            }
            chronicDrugconditionBLL.DeleteOUTKey(this.IDPerson, "5");
            for (int i = 0; i < this.DrugConditions.Count; i++)
            {
                DrugConditions[i].OUTKey = this.IDPerson;
                DrugConditions[i].Type = "5";
                if (!string.IsNullOrEmpty(this.DrugConditions[i].Name))
                {
                    chronicDrugconditionBLL.Add(this.DrugConditions[i]);
                }
            }

            return true;
        }

        public void UpdataToModel()
        {
            this.strokeFollowup.FollowupDate = new DateTime?(this.dtpFollowDate.Value.Date);
            this.strokeFollowup.NextFollowupDate = new DateTime?(this.dtpNext.Value.Date);
            string strnczlx = "";
            for (int i = 0; i < ncztypelist.Count; i++)
            {
                if (this.ncztypelist[i].Checked)
                {
                    strnczlx = string.Format("{0}", i + 1);
                }
            }
            this.strokeFollowup.StrokeType = strnczlx.Trim();

            string strsffl = "";
            for (int i = 0; i < sfflist.Count; i++)
            {
                if (this.sfflist[i].Checked)
                {
                    strsffl = strsffl + string.Format("{0},", i + 1);
                }
            }
            this.strokeFollowup.FollowupType = strsffl.Trim(new char[] { ',' });
            if (this.rdYesZz.Checked)
            {
                this.strokeFollowup.IsReferral = "1";
            }
            else if (this.rdNoZz.Checked)
            {
                this.strokeFollowup.IsReferral = "2";
            }

            for (int k = 0; k < this.YongyaoDoseyc.Count; k++)
            {
                this.YongyaoDoseyc[k].UpdateSource();
                if (this.YongyaoDoseyc[k].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.DrugConditions.Add(this.YongyaoDoseyc[k].Source);
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

        public string SaveDataInfo { get; set; }

        public ChronicStrokeVisitModel strokeFollowup { get; set; }

        public RecordsGeneralConditionModel GeneralModel { get; set; }

        public RecordsCustomerBaseInfoModel CustomerBaseInfo { get; set; }

        public RecordsAssistCheckModel AssistCheckModel { get; set; }

        public int IDPerson { get; set; }

        private void cksffl4_CheckedChanged(object sender, EventArgs e)//此次随访分类：并发症
        {
            if (this.cksffl4.Checked)
            {
                this.tbbfzother.ReadOnly = false;
            }
            else
            {
                this.tbbfzother.Clear();
                this.tbbfzother.ReadOnly = true;
            }
        }

        private void cksfflmy_CheckedChanged(object sender, EventArgs e) //此次随访分类：控制满意
        {
            if (this.cksffl1.Checked)
            {
                this.cksffl2.Checked = false;
            }
        }

        private void ckOth_CheckedChanged(object sender, EventArgs e) //目前症状：其他症状
        {
            if (this.ckOth.Checked)
            {
                this.tbSyOther.ReadOnly = false;
            }
            else
            {
                this.tbSyOther.Clear();
                this.tbSyOther.ReadOnly = true;
            }

        }

        private void btnBMI_Click(object sender, EventArgs e) //体质指数计算
        {
            decimal num;
            decimal num2;
            if ((decimal.TryParse(this.tbhight.Text, out num) && decimal.TryParse(this.tbWeight.Text, out num2)) && (num != 0M))
            {
                decimal num3 = num / 100M;
                decimal num4 = num3 * num3;
                this.tbBMI.Text = (num2 / num4).ToString(".00");
            }
        }

        private void btnyaowei_Click(object sender, EventArgs e)//腰围计算
        {
            decimal num;
            decimal num2;
            if ((decimal.TryParse(this.tbhight.Text, out num) && decimal.TryParse(this.tbWeight.Text, out num2)) && (num != 0M))
            {
                decimal num3 = num / 100M;
                decimal num4 = num3 * num3;
                this.tbyaowei.Text = (num2 * (decimal)3.3 / num4 + (decimal)5).ToString(".00");
            }
        }

        private void rdYesZz_CheckedChanged(object sender, EventArgs e)//转诊判断
        {
            if (this.rdYesZz.Checked)
            {
                this.tbZzKs.ReadOnly = false;
                this.tbZzYy.ReadOnly = false;
            }
            else
            {
                this.tbZzKs.Clear();
                this.tbZzYy.Clear();
                this.tbZzKs.ReadOnly = true;
                this.tbZzYy.ReadOnly = true;
            }
        }
    }
}