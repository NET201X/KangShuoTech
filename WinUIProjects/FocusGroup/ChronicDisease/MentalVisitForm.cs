
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
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Drawing;
using AxHWPenSignLib;
using System.Configuration;

namespace FocusGroup.ChronicDisease
{
    public class MentalVisitForm : Form, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<ChronicMentalDiseaseVisitModel> bindingManager;
        private IContainer components;
        private List<DrugCondion> drugs;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private CMoreChange kangfu;
        private CSingleItem sysjc;
        //private CSingleItem ywblfy;
        private Panel panel1;
        private List<DoseVisitUserControl> doses = new List<DoseVisitUserControl>();
        private List<YongYaoQKUserControlYC> dosesyc = new List<YongYaoQKUserControlYC>();
        private DoseVisitUserControl doseVUC3;
        private DoseVisitUserControl doseVUC2;
        private DoseVisitUserControl doseVUC1;
        private YongYaoQKUserControlYC doseycVUC3;
        private YongYaoQKUserControlYC doseycVUC2;
        private YongYaoQKUserControlYC doseycVUC1;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckedListBox chklbKfchs;
        private DateTimePicker dtpLastEscape;
        private Label label57;
        private ComboBox cbInHospital;
        private ComboBox cbLockStatus;
        private Panel panel10;
        private Label label15;
        private Label label19;
        private TextBox tbZhisha;
        private Label label20;
        private Label label47;
        private TextBox tbZhiShang;
        private Label label48;
        private Label label49;
        private TextBox tbZhaoHuo;
        private Label label50;
        private Label label51;
        private TextBox tbZhaoshi;
        private Label label52;
        private Label label53;
        private TextBox tbQdzs;
        private Label label54;
        private ComboBox cbDinner;
        private ComboBox cbSleep;
        private Label lbDinner;
        private Label label3;
        private ComboBox cbSelfKnow;
        private DateTimePicker dtpFollowDate;
        private TextBox tbIDCARD;
        private TextBox tbName;
        private Label label2;
        private Label label11;
        private ComboBox cbDangerous;
        private Panel panel9;
        private Label label12;
        private ComboBox cbCommunicate;
        private Label label8;
        private ComboBox cbStudy;
        private Label lbWorkAndJob;
        private ComboBox cbWorkAndJob;
        private Label label6;
        private ComboBox cbFamWork;
        private Label label5;
        private ComboBox cbLife;
        private Label label56;
        private Panel panel12;
        private RadioButton rdSysYes;
        private RadioButton rdSysNo;
        private TextBox tbSyshave;
        private Label label58;
        private ComboBox cbDrugWay;
        private Panel panel11;
        private TextBox tbBlfy;
        private Label label21;
        private ComboBox cbMedication;
        private Panel panel7;
        private RadioButton rdNoZz;
        private RadioButton rdYesZz;
        private Label label23;
        private TextBox tbZzYy;
        private Label label24;
        private TextBox tbZzKs;
        private TextBox tbKfchsQt;
        private CheckedListBox chklbSystom;
        private TextBox tbSysptonOther;
        private Label label55;
        private Label label14;
        private Label label1;
        private Label label9;
        private Label label16;
        private Label label10;
        private Label label13;
        private Label label17;
        private Label label18;
        private Label label22;
        private Label label43;
        private Panel panel5;
        private Label label44;
        private ComboBox cbVisitType;
        private Label label45;
        private DateTimePicker dtpNext;
        private Label label46;
        private TextBox tbDoctor;
        private LinkLabel linkLabel1;
        private CMoreChange zhengzh;
        private Panel panel13;
        private Label label27;
        private ComboBox cbfqtjb;
        private ComboBox cbqtjb;
        private Label label29;
        private ComboBox cbsfyy;
        private Label label7;
        private Label label28;
        private Panel panel8;
        private RadioButton rdsw2;
        private RadioButton rdsw1;
        private Label label4;
        private DateTimePicker dtDeathDay;
        private Label label26;
        private Label label30;
        private TextBox tbqtwhxw;
        private Label label32;
        private Label label33;
        private ComboBox cmbsffs;
        private GroupBox groupBox1;
        private Label label36;
        private Label label35;
        private Label label34;
        private DoseVisitUserControl doseYYZD2;
        private DoseVisitUserControl doseYYZD1;
        private GroupBox groupBox2;
        private Label label25;
        private Label label31;
        private Label label37;
        private string visitdate;
        private DoseVisitUserControl doseYYZD3;
        private YongYaoQKUserControlYC doseycYYZD3;
        private YongYaoQKUserControlYC doseycYYZD2;
        private YongYaoQKUserControlYC doseycYYZD1;
        private ComboBox cmbywfy;
        private Panel panel2;
        private RadioButton rdLxNo;
        private RadioButton rdLxYes;
        private Label label38;
        private Panel panel3;
        private TextBox tbPoliceAgentTel;
        private Label label40;
        private TextBox tbPoliceAgent;
        private Label label39;
        private Panel panel4;
        private TextBox tbCommunityAgentTel;
        private Label label41;
        private TextBox tbCommunityAgent;
        private Label label42;
        private Panel panel6;
        private Label label62;
        private TextBox tbZzLxdh;
        private Label label61;
        private TextBox tbZzLxr;
        private Label label60;
        private TextBox tbZzJg;
        private Label label59;
        private Panel panel14;
        private RadioButton rdZzcgNo;
        private RadioButton rdZzcgYes;
        private Label label63;
        private Label label64;
        private Panel panel15;
        private RadioButton rdZkysNo;
        private RadioButton rdZkysYes;
        private Panel panel16;
        private TextBox tbZKYSJG;
        private Label label67;
        private TextBox tbZKYSDH;
        private Label label66;
        private TextBox tbZKYSXM;
        private Label label65;
        private RadioButton radioButton1;
        private TextBox tb;
        private TextBox textBox3;
        private RadioButton radioButton2;
        private TextBox textBox7;
        private TextBox textBox10;
        private Label label68;
        private PictureBox picSignJs;
        private List<DoseVisitUserControl> YYZDdoses = new List<DoseVisitUserControl>();
        private List<YongYaoQKUserControlYC> YYZDdosesyc = new List<YongYaoQKUserControlYC>();
        private string SignS = "";
        private string SignDoc = "";//医生签名
        private LinkLabel lkJs;
        private Panel panel17;
        private LinkLabel lkYs;
        private Label label69;
        private PictureBox picSignYs;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/MentalVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "MentalVisit//"; //签名保存路径

        public MentalVisitForm()
        {
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();

            this.dosesyc.Add(this.doseycVUC1);
            this.dosesyc.Add(this.doseycVUC2);
            this.dosesyc.Add(this.doseycVUC3);
            this.YYZDdosesyc.Add(this.doseycYYZD1);
            this.YYZDdosesyc.Add(this.doseycYYZD2);
            this.YYZDdosesyc.Add(this.doseycYYZD3);

            this.InitEveryOne();
            this.EveryThingIsOk = false;
            this.tableLayoutPanel1.ResumeLayout();
        }

        private void cbInHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbInHospital.Text == "期间未住院") || (this.cbInHospital.Text == ""))
            {
                this.dtpLastEscape.Value = DateTime.Today;
                this.dtpLastEscape.Enabled = false;
            }
            else
            {
                this.dtpLastEscape.Enabled = true;
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            bool flag = false;
            if (this.dtpNext.Value.Date < this.dtpFollowDate.Value.Date)
            {
                flag = true;
                MentalVisitForm follow = this;
                string str = follow.SaveDataInfo + "下次随访日期不能小于当前随访日期!";
                follow.SaveDataInfo = str;
            }
            if (this.dtpFollowDate.Value.Date > DateTime.Today)
            {
                MentalVisitForm follow2 = this;
                string str2 = follow2.SaveDataInfo + "随访日期不能晚于当前日期!\r\n";
                follow2.SaveDataInfo = str2;
                flag = true;
            }

            if (((!flag && !this.bindingManager.ErrorInput) && (!this.zhengzh.ErrorInput && !this.sysjc.ErrorInput)) && (!this.kangfu.ErrorInput))
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

        private void FrmMentalFollow_Load(object sender, EventArgs e)
        {
            this.groupBox5.Visible = true;
            this.groupBox4.Visible = true;
            this.groupBox1.Text = "                 ";
            this.groupBox2.Text = "                 ";

            if (!Directory.Exists(this.SignPath))
            {
                Directory.CreateDirectory(this.SignPath);
            }
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void InitEveryOne()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("0级", "0"),
                new ItemDictonaryModel<string>("1级", "1"),
                new ItemDictonaryModel<string>("2级", "2"),
                new ItemDictonaryModel<string>("3级", "3"),
                new ItemDictonaryModel<string>("4级", "4"),
                new ItemDictonaryModel<string>("5级", "5")
            };
            this.cbDangerous.DisplayMember = "DISPLAYMEMBER";
            this.cbDangerous.ValueMember = "VALUEMEMBER";
            this.cbDangerous.DataSource = list;
            List<ItemDictonaryModel<string>> list2 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("自知力完全", "1"),
                new ItemDictonaryModel<string>("自知力不全", "2"),
                new ItemDictonaryModel<string>("自知力缺失", "3")
            };
            this.cbSelfKnow.DisplayMember = "DISPLAYMEMBER";
            this.cbSelfKnow.ValueMember = "VALUEMEMBER";
            this.cbSelfKnow.DataSource = list2;
            List<ItemDictonaryModel<string>> list3 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("良好", "1"),
                new ItemDictonaryModel<string>("一般", "2"),
                new ItemDictonaryModel<string>("较差", "3")
            };
            this.cbSleep.DisplayMember = "DISPLAYMEMBER";
            this.cbSleep.ValueMember = "VALUEMEMBER";
            this.cbSleep.DataSource = list3;
            List<ItemDictonaryModel<string>> list4 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("良好", "1"),
                new ItemDictonaryModel<string>("一般", "2"),
                new ItemDictonaryModel<string>("较差", "3")
            };
            this.cbDinner.DisplayMember = "DISPLAYMEMBER";
            this.cbDinner.ValueMember = "VALUEMEMBER";
            this.cbDinner.DataSource = list4;
            List<ItemDictonaryModel<string>> list5 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("良好", "1"),
                new ItemDictonaryModel<string>("一般", "2"),
                new ItemDictonaryModel<string>("较差", "3")
            };
            this.cbLife.DisplayMember = "DISPLAYMEMBER";
            this.cbLife.ValueMember = "VALUEMEMBER";
            this.cbLife.DataSource = list5;
            List<ItemDictonaryModel<string>> list6 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("良好", "1"),
                new ItemDictonaryModel<string>("一般", "2"),
                new ItemDictonaryModel<string>("较差", "3")
            };
            this.cbFamWork.DisplayMember = "DISPLAYMEMBER";
            this.cbFamWork.ValueMember = "VALUEMEMBER";
            this.cbFamWork.DataSource = list6;
            List<ItemDictonaryModel<string>> list7 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("良好", "1"),
                new ItemDictonaryModel<string>("一般", "2"),
                new ItemDictonaryModel<string>("较差", "3"),
                new ItemDictonaryModel<string>("此项不适用", "9")
            };
            this.cbWorkAndJob.DisplayMember = "DISPLAYMEMBER";
            this.cbWorkAndJob.ValueMember = "VALUEMEMBER";
            this.cbWorkAndJob.DataSource = list7;
            List<ItemDictonaryModel<string>> list8 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("良好", "1"),
                new ItemDictonaryModel<string>("一般", "2"),
                new ItemDictonaryModel<string>("较差", "3")
            };
            this.cbStudy.DisplayMember = "DISPLAYMEMBER";
            this.cbStudy.ValueMember = "VALUEMEMBER";
            this.cbStudy.DataSource = list8;
            List<ItemDictonaryModel<string>> list9 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("良好", "1"),
                new ItemDictonaryModel<string>("一般", "2"),
                new ItemDictonaryModel<string>("较差", "3")
            };
            this.cbCommunicate.DisplayMember = "DISPLAYMEMBER";
            this.cbCommunicate.ValueMember = "VALUEMEMBER";
            this.cbCommunicate.DataSource = list9;
            List<ItemDictonaryModel<string>> list10 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("无关锁", "1"),
                new ItemDictonaryModel<string>("关锁", "2"),
                new ItemDictonaryModel<string>("关锁已解除", "3")
            };
            this.cbLockStatus.DisplayMember = "DISPLAYMEMBER";
            this.cbLockStatus.ValueMember = "VALUEMEMBER";
            this.cbLockStatus.DataSource = list10;
            List<ItemDictonaryModel<string>> list11 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("从未住院", "0"),
                new ItemDictonaryModel<string>("目前正在住院", "1"),
                new ItemDictonaryModel<string>("既住院，现未住院", "2")
            };
            this.cbInHospital.DisplayMember = "DISPLAYMEMBER";
            this.cbInHospital.ValueMember = "VALUEMEMBER";
            this.cbInHospital.DataSource = list11;
            List<ItemDictonaryModel<string>> list12 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("按医嘱规律用药", "1"),
                new ItemDictonaryModel<string>("间断用药", "2"),
                new ItemDictonaryModel<string>("不用药", "3"),
                new ItemDictonaryModel<string>("医嘱勿需用药","4")
            };
            this.cbDrugWay.DisplayMember = "DISPLAYMEMBER";
            this.cbDrugWay.ValueMember = "VALUEMEMBER";
            this.cbDrugWay.DataSource = list12;
            List<ItemDictonaryModel<string>> list13 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("痊愈", "1"),
                new ItemDictonaryModel<string>("好转", "2"),
                new ItemDictonaryModel<string>("无变化", "3"),
                new ItemDictonaryModel<string>("加重", "4"),
                new ItemDictonaryModel<string>("此项不适用", "9")
            };
            this.cbMedication.DisplayMember = "DISPLAYMEMBER";
            this.cbMedication.ValueMember = "VALUEMEMBER";
            this.cbMedication.DataSource = list13;
            List<ItemDictonaryModel<string>> list14 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("不稳定", "1"),
                new ItemDictonaryModel<string>("基本稳定", "2"),
                new ItemDictonaryModel<string>("稳定", "3")
            };
            this.cbVisitType.DisplayMember = "DISPLAYMEMBER";
            this.cbVisitType.ValueMember = "VALUEMEMBER";
            this.cbVisitType.DataSource = list14;
            List<ItemDictonaryModel<string>> list15 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("外出打工", "1"),
                new ItemDictonaryModel<string>("迁居他处", "2"),
                new ItemDictonaryModel<string>("走失", "3"),
                new ItemDictonaryModel<string>("连续3次未到访", "4"),
                new ItemDictonaryModel<string>("其他", "5")
            };
            this.cbsfyy.DisplayMember = "DISPLAYMEMBER";
            this.cbsfyy.ValueMember = "VALUEMEMBER";
            this.cbsfyy.DataSource = list15;
            List<ItemDictonaryModel<string>> list16 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("传染病和寄生虫病", "1"),
                new ItemDictonaryModel<string>("肿瘤", "2"),
                new ItemDictonaryModel<string>("心脏病", "3"),
                new ItemDictonaryModel<string>("脑血管病", "4"),
                new ItemDictonaryModel<string>("呼吸系统疾病", "5"),
                new ItemDictonaryModel<string>("消化系统疾病", "6"),
                new ItemDictonaryModel<string>("其他疾病", "7"),
                new ItemDictonaryModel<string>("不详", "8")
            };
            this.cbqtjb.DisplayMember = "DISPLAYMEMBER";
            this.cbqtjb.ValueMember = "VALUEMEMBER";
            this.cbqtjb.DataSource = list16;
            List<ItemDictonaryModel<string>> list17 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("自杀", "2"),
                new ItemDictonaryModel<string>("他杀", "3"),
                new ItemDictonaryModel<string>("意外", "4"),
                new ItemDictonaryModel<string>("精神疾病相关并发症", "5"),
                new ItemDictonaryModel<string>("其他", "6")
            };
            this.cbfqtjb.DisplayMember = "DISPLAYMEMBER";
            this.cbfqtjb.ValueMember = "VALUEMEMBER";
            this.cbfqtjb.DataSource = list17;
            List<ItemDictonaryModel<string>> list18 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("门诊", "1"),
                new ItemDictonaryModel<string>("家庭访视", "2"),
                new ItemDictonaryModel<string>("电话", "3")
            };
            this.cmbsffs.DisplayMember = "DISPLAYMEMBER";
            this.cmbsffs.ValueMember = "VALUEMEMBER";
            this.cmbsffs.DataSource = list18;
            List<ItemDictonaryModel<string>> list19 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("无", "1"),
                new ItemDictonaryModel<string>("有", "2"),
                new ItemDictonaryModel<string>("此项不适用", "9")
            };
            this.cmbywfy.DisplayMember = "DISPLAYMEMBER";
            this.cmbywfy.ValueMember = "VALUEMEMBER";
            this.cmbywfy.DataSource = list19;
            this.rdYesZz.CheckedChanged += new EventHandler(this.rdYesZz_CheckedChanged);
            this.rdNoZz.CheckedChanged += new EventHandler(this.rdNoZz_CheckedChanged);
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("HospitalCount", 1000M));
            this.inputRanges.Add(new InputRangeDec("MildTroubleFrequen", 1000M));
            this.inputRanges.Add(new InputRangeDec("CreateDistuFrequen", 1000M));
            this.inputRanges.Add(new InputRangeDec("CauseAccidFrequen", 1000M));
            this.inputRanges.Add(new InputRangeDec("AutolesionFrequen", 1000M));
            this.inputRanges.Add(new InputRangeDec("AttemptSuicFrequen", 1000M));
            this.inputRanges.Add(new InputRangeDec("OtherDangerFrequen", 1000M));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("PresentSymptoOther", 200));
            this.inputrange_str.Add(new InputRangeStr("LaborExaminatiHave", 100));
            this.inputrange_str.Add(new InputRangeStr("AdverDruReactHave", 100));
            this.inputrange_str.Add(new InputRangeStr("ReferralReason", 200));
            this.inputrange_str.Add(new InputRangeStr("ReferralAgencDepar", 80));
            this.inputrange_str.Add(new InputRangeStr("RehabiliMeasuOther", 200));
            this.inputrange_str.Add(new InputRangeStr("FollowUpDoctor", 30));
        }

        public void InitEveryThing()
        {
            this.groupBox5.Visible = true;
            this.groupBox4.Visible = true;
            this.groupBox1.Text = "                 ";
            this.groupBox2.Text = "                 ";

            if (this.IDPerson > 0)
            {
                this.MentalVisit = new ChronicMentalDiseaseVisitBLL().GetModelID(this.IDPerson);
            }
            else
            {
                this.MentalVisit = new ChronicMentalDiseaseVisitBLL().GetModel(this.Model.IDCardNo);
                this.dtpFollowDate.Value = DateTime.Today.Date;

                if (this.MentalVisit == null) this.MentalVisit = new ChronicMentalDiseaseVisitModel();

                if (this.MentalVisit.FollowUpDate == null || (this.MentalVisit.FollowUpDate != null && this.MentalVisit.FollowUpDate.Value != this.dtpFollowDate.Value))
                {
                    this.MentalVisit.FollowUpDate = this.dtpFollowDate.Value;
                    this.MentalVisit.NextFollowUpDate = DateTime.Today.Date.AddMonths(3);
                }

                this.MentalVisit.IDCardNo = this.Model.IDCardNo;
            }

            if (this.MentalVisit == null)
            {
                ChronicMentalDiseaseVisitModel cd_mentaldisease_followup = new ChronicMentalDiseaseVisitModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID,
                    FollowupClassificat = "1"
                };

                this.MentalVisit = cd_mentaldisease_followup;
                this.MentalVisit.CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.MentalVisit.CreatedDate = new DateTime?(DateTime.Today);
                this.DrugConditions = new List<ChronicDrugConditionModel>();
                this.YYZDDrugConditions = new List<ChronicDrugConditionModel>();
            }
            else
            {
                if (this.MentalVisit.FollowUpDate.HasValue)
                {
                    this.dtpFollowDate.Value = this.MentalVisit.FollowUpDate.Value;
                    this.visitdate = this.MentalVisit.FollowUpDate.ToString();
                }

                this.MentalVisit.LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.MentalVisit.LastUpdateDate = new DateTime?(DateTime.Today);

                if (this.IDPerson > 0)
                {
                    this.DrugConditions = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '{2}' ", this.Model.IDCardNo, "3", this.IDPerson));
                    this.YYZDDrugConditions = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '{2}' ", this.Model.IDCardNo, "6", this.IDPerson));//用药指导，类型为6
                }
                else
                {
                    this.DrugConditions = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '{2}' ", this.Model.IDCardNo, "3", this.MentalVisit.ID));
                    this.YYZDDrugConditions = new ChronicDrugConditionBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND type = '{1}' AND OUTKey = '{2}' ", this.Model.IDCardNo, "6", this.MentalVisit.ID));//用药指导，类型为6
                }
            }

            if (string.IsNullOrEmpty(this.MentalVisit.FollowUpDoctor))
            {
                this.MentalVisit.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
            }

            this.bindingManager = new SimpleBindingManager<ChronicMentalDiseaseVisitModel>(this.inputRanges, this.inputrange_str, this.MentalVisit);
            this.bindingManager.SimpleBinding(this.tbIDCARD, "IDCardNo", false);
            this.tbName.Text = this.Model.CustomerName;
            this.bindingManager.SimpleBinding(this.cbDangerous, "Fatalness");

            CMoreChange change = new CMoreChange
            {
                Name = "症状",
                MoreChange = this.chklbSystom,
                Other = this.tbSysptonOther,
                MaxBytesCount = 200
            };

            this.zhengzh = change;
            this.zhengzh.TransInfo(this.MentalVisit.PresentSymptom, this.MentalVisit.PresentSymptoOther);
            this.bindingManager.SimpleBinding(this.cbSelfKnow, "Insight");
            this.bindingManager.SimpleBinding(this.cbSleep, "SleepQuality");
            this.bindingManager.SimpleBinding(this.cbDinner, "Diet");
            this.bindingManager.SimpleBinding(this.cbLife, "PersonalCare");
            this.bindingManager.SimpleBinding(this.cbFamWork, "Housework");
            this.bindingManager.SimpleBinding(this.cbWorkAndJob, "ProductLaborWork");
            this.bindingManager.SimpleBinding(this.cbStudy, "LearningAbility");
            this.bindingManager.SimpleBinding(this.cbCommunicate, "SocialInterIntera");
            this.bindingManager.SimpleBindingInt(this.tbQdzs, "MildTroubleFrequen", true);
            this.bindingManager.SimpleBindingInt(this.tbZhaoshi, "CreateDistuFrequen", true);
            this.bindingManager.SimpleBindingInt(this.tbZhaoHuo, "CauseAccidFrequen", true);
            this.bindingManager.SimpleBindingInt(this.tbZhiShang, "AutolesionFrequen", true);
            this.bindingManager.SimpleBindingInt(this.tbZhisha, "AttemptSuicFrequen", true);
            this.bindingManager.SimpleBindingInt(this.tbqtwhxw, "OtherDangerFrequen", true);
            this.bindingManager.SimpleBinding(this.cbLockStatus, "LockCondition");
            this.bindingManager.SimpleBinding(this.cbInHospital, "HospitalizatiStatus");
            this.bindingManager.SimpleBinding(this.cbsfyy, "NoVisitReason");
            this.bindingManager.SimpleBinding(this.cbqtjb, "IllReason");
            this.bindingManager.SimpleBinding(this.cbfqtjb, "DeathReason");
            this.bindingManager.SimpleBinding(this.cmbsffs, "FollowUpType");
            this.bindingManager.SimpleBinding(this.cmbywfy, "AdnerDruReact");

            if (this.MentalVisit.AdnerDruReact == "2")
            {
                this.bindingManager.SimpleBinding(this.tbBlfy, "AdverDruReactHave", false);
            }

            if (this.MentalVisit.LastLeaveHospTime.HasValue)
            {
                this.dtpLastEscape.Value = this.MentalVisit.LastLeaveHospTime.Value;
            }

            CSingleItem item = new CSingleItem
            {
                Name = "实验室检查",
                Usual = this.rdSysNo,
                Unusual = this.rdSysYes,
                Info = this.tbSyshave
            };

            this.sysjc = item;
            this.sysjc.TransInfo(this.MentalVisit.LaborExaminati, this.MentalVisit.LaborExaminatiHave);
            this.bindingManager.SimpleBinding(this.cbDrugWay, "MedicatioCompliance");
            this.bindingManager.SimpleBinding(this.cbMedication, "TreatmentEffect");

            if (!string.IsNullOrEmpty(this.MentalVisit.WhetherReferral))
            {
                if (this.MentalVisit.WhetherReferral == "1") this.rdNoZz.Checked = true;
                else this.rdYesZz.Checked = true;
            }
            else this.rdNoZz.Checked = true;

            this.bindingManager.SimpleBinding(this.tbZzYy, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.tbZzKs, "ReferralAgencDepar", false);

            //读取用药情况、用药指导
            if (File.Exists(Application.StartupPath + "\\dose.xml"))
            {
                DataSet ds = new DataSet();

                ds.ReadXml(Application.StartupPath + "\\dose.xml");

                DataTable dt_yw1 = ds.Tables[0];
                doseycVUC1.setSource(dt_yw1);
                doseycVUC2.setSource(DeepCopy(dt_yw1));
                doseycVUC3.setSource(DeepCopy(dt_yw1));
                doseycYYZD1.setSource(dt_yw1);
                doseycYYZD2.setSource(DeepCopy(dt_yw1));
                doseycYYZD3.setSource(DeepCopy(dt_yw1));
            }

            for (int k = 0; k < this.dosesyc.Count; k++)
            {
                if (k < this.DrugConditions.Count)
                {
                    this.dosesyc[k].Source = this.DrugConditions[k];
                }
                else
                {
                    ChronicDrugConditionModel chronicDrugConditionsModel = new ChronicDrugConditionModel
                    {
                        IDCardNo = this.Model.IDCardNo,
                        ModelState = RecordsStateModel.NoValue,
                        Type = "3"
                    };

                    this.dosesyc[k].Source = chronicDrugConditionsModel;
                }
            }
            for (int k = 0; k < this.YYZDdosesyc.Count; k++)
            {
                if (k < this.YYZDDrugConditions.Count)
                {
                    this.YYZDdosesyc[k].Source = this.YYZDDrugConditions[k];
                }
                else
                {
                    ChronicDrugConditionModel chronicDrugConditionsModel = new ChronicDrugConditionModel
                    {
                        IDCardNo = this.Model.IDCardNo,
                        ModelState = RecordsStateModel.NoValue,
                        Type = "6"
                    };

                    this.YYZDdosesyc[k].Source = chronicDrugConditionsModel;
                }
            }

            CMoreChange change2 = new CMoreChange
            {
                Name = "症状",
                MoreChange = this.chklbKfchs,
                Other = this.tbKfchsQt,
                MaxBytesCount = 100
            };

            this.kangfu = change2;
            this.kangfu.TransInfo(this.MentalVisit.RehabiliMeasu, this.MentalVisit.RehabiliMeasuOther);
            this.bindingManager.SimpleBinding(this.cbVisitType, "FollowupClassificat");

            if (this.MentalVisit.NextFollowUpDate.HasValue)
            {
                this.dtpNext.Value = this.MentalVisit.NextFollowUpDate.Value;
            }

            this.bindingManager.SimpleBinding(this.tbDoctor, "FollowUpDoctor", false);

            if (this.MentalVisit.DeathDate.HasValue)
            {
                this.dtDeathDay.Value = this.MentalVisit.DeathDate.Value;
            }
            if (this.MentalVisit.DeathDate.HasValue || !string.IsNullOrEmpty(this.MentalVisit.IllReason) || !string.IsNullOrEmpty(this.MentalVisit.DeathReason))
            {
                this.rdsw1.Checked = false;
                this.rdsw2.Checked = true;
            }
            else
            {
                this.rdsw1.Checked = true;
                this.rdsw2.Checked = false;
            }

            this.bindingManager.SimpleBinding(this.tbZzJg, "ReferralOrgan", false);
            this.bindingManager.SimpleBinding(this.tbZzLxr, "ReferraContacts", false);
            this.bindingManager.SimpleBinding(this.tbZzLxdh, "ReferralContactsTel", false);
            this.bindingManager.SimpleBinding(this.tbZKYSXM, "SpecialistName", false);
            this.bindingManager.SimpleBinding(this.tbZKYSDH, "SpecialistTel", false);
            this.bindingManager.SimpleBinding(this.tbZKYSJG, "DisposalResult", false);
            this.bindingManager.SimpleBinding(this.tbPoliceAgent, "PoliceAgent", false);
            this.bindingManager.SimpleBinding(this.tbPoliceAgentTel, "PoliceAgentTel", false);
            this.bindingManager.SimpleBinding(this.tbCommunityAgent, "CommunityAgent", false);
            this.bindingManager.SimpleBinding(this.tbCommunityAgentTel, "CommunityAgentTel", false);

            if (this.MentalVisit.JointPartFlag == "1") this.rdLxYes.Checked = true;
            else if (this.MentalVisit.JointPartFlag == "2") this.rdLxNo.Checked = true;
            if (this.MentalVisit.ReferralResult == "1") this.rdZzcgNo.Checked = true;
            else if (this.MentalVisit.ReferralResult == "2") this.rdZzcgYes.Checked = true;
            if (this.MentalVisit.ContactSpecialist == "1") this.rdZkysNo.Checked = true;
            else if (this.MentalVisit.ContactSpecialist == "2") this.rdZkysYes.Checked = true;

            //签名初始化
            this.SignS = string.Format("{0}{1}_{2}.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpFollowDate.Value).ToString("yyyyMMdd"));
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

            this.SignDoc = string.Format("{0}{1}_{2}_Doc.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpFollowDate.Value).ToString("yyyyMMdd"));
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
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdLxNo = new System.Windows.Forms.RadioButton();
            this.rdLxYes = new System.Windows.Forms.RadioButton();
            this.label33 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.cbfqtjb = new System.Windows.Forms.ComboBox();
            this.cbqtjb = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.chklbKfchs = new System.Windows.Forms.CheckedListBox();
            this.dtpLastEscape = new System.Windows.Forms.DateTimePicker();
            this.label57 = new System.Windows.Forms.Label();
            this.cbInHospital = new System.Windows.Forms.ComboBox();
            this.cbLockStatus = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.tbqtwhxw = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbZhisha = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.tbZhiShang = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.tbZhaoHuo = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.tbZhaoshi = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.tbQdzs = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbDinner = new System.Windows.Forms.ComboBox();
            this.cbSleep = new System.Windows.Forms.ComboBox();
            this.lbDinner = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSelfKnow = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFollowDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.tbIDCARD = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.cbCommunicate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbStudy = new System.Windows.Forms.ComboBox();
            this.lbWorkAndJob = new System.Windows.Forms.Label();
            this.cbWorkAndJob = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFamWork = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbLife = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.rdSysYes = new System.Windows.Forms.RadioButton();
            this.rdSysNo = new System.Windows.Forms.RadioButton();
            this.tbSyshave = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.cbDrugWay = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbBlfy = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbMedication = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdNoZz = new System.Windows.Forms.RadioButton();
            this.rdYesZz = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.tbZzYy = new System.Windows.Forms.TextBox();
            this.tbKfchsQt = new System.Windows.Forms.TextBox();
            this.chklbSystom = new System.Windows.Forms.CheckedListBox();
            this.tbSysptonOther = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label44 = new System.Windows.Forms.Label();
            this.cbVisitType = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.label46 = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rdsw2 = new System.Windows.Forms.RadioButton();
            this.rdsw1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDeathDay = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.cbsfyy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDangerous = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbsffs = new System.Windows.Forms.ComboBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cmbywfy = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.doseycYYZD3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.doseycYYZD2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.doseycYYZD1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.doseycVUC3 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.doseycVUC2 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.doseycVUC1 = new KangShuoTech.Utilities.CommonControl.YongYaoQKUserControlYC();
            this.label25 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbPoliceAgentTel = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.tbPoliceAgent = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbCommunityAgentTel = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.tbCommunityAgent = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label62 = new System.Windows.Forms.Label();
            this.tbZzLxdh = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.tbZzLxr = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.tbZzJg = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbZzKs = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.rdZzcgNo = new System.Windows.Forms.RadioButton();
            this.rdZzcgYes = new System.Windows.Forms.RadioButton();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.rdZkysNo = new System.Windows.Forms.RadioButton();
            this.rdZkysYes = new System.Windows.Forms.RadioButton();
            this.panel16 = new System.Windows.Forms.Panel();
            this.tbZKYSJG = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.tbZKYSDH = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.tbZKYSXM = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.label69 = new System.Windows.Forms.Label();
            this.lkJs = new System.Windows.Forms.LinkLabel();
            this.picSignJs = new System.Windows.Forms.PictureBox();
            this.label68 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tb = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(55, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1423, 635);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.48673F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.77286F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.9005F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.91389F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.34768F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.46872F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.label33, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel13, 1, 27);
            this.tableLayoutPanel1.Controls.Add(this.chklbKfchs, 1, 25);
            this.tableLayoutPanel1.Controls.Add(this.dtpLastEscape, 5, 9);
            this.tableLayoutPanel1.Controls.Add(this.label57, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbInHospital, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbLockStatus, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label55, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbDinner, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbSleep, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbDinner, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbSelfKnow, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpFollowDate, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbIDCARD, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label56, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.tbSyshave, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.label58, 4, 10);
            this.tableLayoutPanel1.Controls.Add(this.cbDrugWay, 5, 10);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.tbBlfy, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.label21, 4, 11);
            this.tableLayoutPanel1.Controls.Add(this.cbMedication, 5, 11);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.label23, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.tbZzYy, 3, 14);
            this.tableLayoutPanel1.Controls.Add(this.tbKfchsQt, 5, 25);
            this.tableLayoutPanel1.Controls.Add(this.chklbSystom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbSysptonOther, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label43, 0, 25);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 28);
            this.tableLayoutPanel1.Controls.Add(this.label28, 0, 26);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 1, 26);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 26);
            this.tableLayoutPanel1.Controls.Add(this.dtDeathDay, 3, 26);
            this.tableLayoutPanel1.Controls.Add(this.label26, 0, 27);
            this.tableLayoutPanel1.Controls.Add(this.cbsfyy, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbDangerous, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbsffs, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 22);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 19);
            this.tableLayoutPanel1.Controls.Add(this.label38, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 15);
            this.tableLayoutPanel1.Controls.Add(this.label22, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.label59, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.label63, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.label64, 1, 17);
            this.tableLayoutPanel1.Controls.Add(this.panel15, 2, 17);
            this.tableLayoutPanel1.Controls.Add(this.panel16, 3, 17);
            this.tableLayoutPanel1.Controls.Add(this.panel17, 0, 29);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 30;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.264883F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.343689F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.141042F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.398792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.870091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.758308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.07362F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.828221F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.6042296F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.45092F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.26488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.262891F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.262891F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.860169F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.500865F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.088999F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.397898F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.395958F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.950162F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1372, 1304);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel2.Controls.Add(this.rdLxNo);
            this.panel2.Controls.Add(this.rdLxYes);
            this.panel2.Location = new System.Drawing.Point(215, 509);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(173, 34);
            this.panel2.TabIndex = 236;
            // 
            // rdLxNo
            // 
            this.rdLxNo.AutoSize = true;
            this.rdLxNo.Location = new System.Drawing.Point(76, 4);
            this.rdLxNo.Name = "rdLxNo";
            this.rdLxNo.Size = new System.Drawing.Size(47, 24);
            this.rdLxNo.TabIndex = 101;
            this.rdLxNo.TabStop = true;
            this.rdLxNo.Text = "否";
            this.rdLxNo.UseVisualStyleBackColor = true;
            this.rdLxNo.CheckedChanged += new System.EventHandler(this.rdLxNo_CheckedChanged);
            // 
            // rdLxYes
            // 
            this.rdLxYes.AutoSize = true;
            this.rdLxYes.Location = new System.Drawing.Point(8, 4);
            this.rdLxYes.Name = "rdLxYes";
            this.rdLxYes.Size = new System.Drawing.Size(47, 24);
            this.rdLxYes.TabIndex = 100;
            this.rdLxYes.TabStop = true;
            this.rdLxYes.Text = "是";
            this.rdLxYes.UseVisualStyleBackColor = true;
            this.rdLxYes.CheckedChanged += new System.EventHandler(this.rdLxYes_CheckedChanged);
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(70, 53);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(139, 20);
            this.label33.TabIndex = 231;
            this.label33.Text = "本次随访形式:";
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel13, 5);
            this.panel13.Controls.Add(this.label27);
            this.panel13.Controls.Add(this.cbfqtjb);
            this.panel13.Controls.Add(this.cbqtjb);
            this.panel13.Controls.Add(this.label29);
            this.panel13.Location = new System.Drawing.Point(215, 1137);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1154, 37);
            this.panel13.TabIndex = 230;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(447, 7);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(149, 20);
            this.label27.TabIndex = 15;
            this.label27.Text = "非躯体疾病原因";
            // 
            // cbfqtjb
            // 
            this.cbfqtjb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbfqtjb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfqtjb.FormattingEnabled = true;
            this.cbfqtjb.Location = new System.Drawing.Point(604, 3);
            this.cbfqtjb.Name = "cbfqtjb";
            this.cbfqtjb.Size = new System.Drawing.Size(192, 28);
            this.cbfqtjb.TabIndex = 14;
            // 
            // cbqtjb
            // 
            this.cbqtjb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbqtjb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbqtjb.FormattingEnabled = true;
            this.cbqtjb.Location = new System.Drawing.Point(139, 1);
            this.cbqtjb.Name = "cbqtjb";
            this.cbqtjb.Size = new System.Drawing.Size(173, 28);
            this.cbqtjb.TabIndex = 13;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(4, 5);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(129, 20);
            this.label29.TabIndex = 0;
            this.label29.Text = "躯体疾病原因";
            // 
            // chklbKfchs
            // 
            this.chklbKfchs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chklbKfchs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chklbKfchs.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chklbKfchs, 4);
            this.chklbKfchs.FormattingEnabled = true;
            this.chklbKfchs.Items.AddRange(new object[] {
            "生活劳动能力",
            "职业训练",
            "学习能力",
            "社会交往",
            "其他"});
            this.chklbKfchs.Location = new System.Drawing.Point(215, 1057);
            this.chklbKfchs.MultiColumn = true;
            this.chklbKfchs.Name = "chklbKfchs";
            this.chklbKfchs.Size = new System.Drawing.Size(762, 29);
            this.chklbKfchs.TabIndex = 23;
            this.chklbKfchs.SelectedIndexChanged += new System.EventHandler(this.chklbKfchs_SelectedIndexChanged);
            // 
            // dtpLastEscape
            // 
            this.dtpLastEscape.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpLastEscape.Location = new System.Drawing.Point(1105, 384);
            this.dtpLastEscape.Name = "dtpLastEscape";
            this.dtpLastEscape.Size = new System.Drawing.Size(199, 30);
            this.dtpLastEscape.TabIndex = 13;
            // 
            // label57
            // 
            this.label57.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.Location = new System.Drawing.Point(960, 389);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(139, 20);
            this.label57.TabIndex = 179;
            this.label57.Text = "末次出院时间:";
            // 
            // cbInHospital
            // 
            this.cbInHospital.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbInHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInHospital.FormattingEnabled = true;
            this.cbInHospital.Location = new System.Drawing.Point(649, 385);
            this.cbInHospital.Name = "cbInHospital";
            this.cbInHospital.Size = new System.Drawing.Size(173, 28);
            this.cbInHospital.TabIndex = 12;
            this.cbInHospital.SelectedIndexChanged += new System.EventHandler(this.cbInHospital_SelectedIndexChanged);
            // 
            // cbLockStatus
            // 
            this.cbLockStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbLockStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLockStatus.FormattingEnabled = true;
            this.cbLockStatus.Location = new System.Drawing.Point(215, 385);
            this.cbLockStatus.Name = "cbLockStatus";
            this.cbLockStatus.Size = new System.Drawing.Size(173, 28);
            this.cbLockStatus.TabIndex = 11;
            // 
            // label55
            // 
            this.label55.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.Location = new System.Drawing.Point(110, 389);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(99, 20);
            this.label55.TabIndex = 143;
            this.label55.Text = "关锁情况:";
            // 
            // panel10
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel10, 5);
            this.panel10.Controls.Add(this.label30);
            this.panel10.Controls.Add(this.tbqtwhxw);
            this.panel10.Controls.Add(this.label32);
            this.panel10.Controls.Add(this.label15);
            this.panel10.Controls.Add(this.label19);
            this.panel10.Controls.Add(this.tbZhisha);
            this.panel10.Controls.Add(this.label20);
            this.panel10.Controls.Add(this.label47);
            this.panel10.Controls.Add(this.tbZhiShang);
            this.panel10.Controls.Add(this.label48);
            this.panel10.Controls.Add(this.label49);
            this.panel10.Controls.Add(this.tbZhaoHuo);
            this.panel10.Controls.Add(this.label50);
            this.panel10.Controls.Add(this.label51);
            this.panel10.Controls.Add(this.tbZhaoshi);
            this.panel10.Controls.Add(this.label52);
            this.panel10.Controls.Add(this.label53);
            this.panel10.Controls.Add(this.tbQdzs);
            this.panel10.Controls.Add(this.label54);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.panel10.Location = new System.Drawing.Point(212, 294);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.tableLayoutPanel1.SetRowSpan(this.panel10, 2);
            this.panel10.Size = new System.Drawing.Size(1160, 84);
            this.panel10.TabIndex = 10;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(880, 10);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 20);
            this.label30.TabIndex = 18;
            this.label30.Text = "次";
            // 
            // tbqtwhxw
            // 
            this.tbqtwhxw.Location = new System.Drawing.Point(828, 6);
            this.tbqtwhxw.MaxLength = 3;
            this.tbqtwhxw.Name = "tbqtwhxw";
            this.tbqtwhxw.Size = new System.Drawing.Size(46, 30);
            this.tbqtwhxw.TabIndex = 17;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(683, 10);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(139, 20);
            this.label32.TabIndex = 16;
            this.label32.Text = "4其他危害行为";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(473, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 20);
            this.label15.TabIndex = 15;
            this.label15.Text = "7无";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(403, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 20);
            this.label19.TabIndex = 14;
            this.label19.Text = "次";
            // 
            // tbZhisha
            // 
            this.tbZhisha.Location = new System.Drawing.Point(351, 48);
            this.tbZhisha.MaxLength = 3;
            this.tbZhisha.Name = "tbZhisha";
            this.tbZhisha.Size = new System.Drawing.Size(46, 30);
            this.tbZhisha.TabIndex = 13;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(247, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 20);
            this.label20.TabIndex = 12;
            this.label20.Text = "6自杀未遂";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(172, 50);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(29, 20);
            this.label47.TabIndex = 11;
            this.label47.Text = "次";
            // 
            // tbZhiShang
            // 
            this.tbZhiShang.Location = new System.Drawing.Point(119, 46);
            this.tbZhiShang.MaxLength = 3;
            this.tbZhiShang.Name = "tbZhiShang";
            this.tbZhiShang.Size = new System.Drawing.Size(46, 30);
            this.tbZhiShang.TabIndex = 10;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(40, 50);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(59, 20);
            this.label48.TabIndex = 9;
            this.label48.Text = "5自伤";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(589, 9);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(29, 20);
            this.label49.TabIndex = 8;
            this.label49.Text = "次";
            // 
            // tbZhaoHuo
            // 
            this.tbZhaoHuo.Location = new System.Drawing.Point(537, 5);
            this.tbZhaoHuo.MaxLength = 3;
            this.tbZhaoHuo.Name = "tbZhaoHuo";
            this.tbZhaoHuo.Size = new System.Drawing.Size(46, 30);
            this.tbZhaoHuo.TabIndex = 7;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(470, 9);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(59, 20);
            this.label50.TabIndex = 6;
            this.label50.Text = "3肇祸";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(403, 9);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(29, 20);
            this.label51.TabIndex = 5;
            this.label51.Text = "次";
            // 
            // tbZhaoshi
            // 
            this.tbZhaoshi.Location = new System.Drawing.Point(351, 5);
            this.tbZhaoshi.MaxLength = 3;
            this.tbZhaoshi.Name = "tbZhaoshi";
            this.tbZhaoshi.Size = new System.Drawing.Size(46, 30);
            this.tbZhaoshi.TabIndex = 4;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(275, 9);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(59, 20);
            this.label52.TabIndex = 3;
            this.label52.Text = "2肇事";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(172, 9);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(29, 20);
            this.label53.TabIndex = 2;
            this.label53.Text = "次";
            // 
            // tbQdzs
            // 
            this.tbQdzs.Location = new System.Drawing.Point(119, 5);
            this.tbQdzs.MaxLength = 3;
            this.tbQdzs.Name = "tbQdzs";
            this.tbQdzs.Size = new System.Drawing.Size(46, 30);
            this.tbQdzs.TabIndex = 1;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(12, 9);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(99, 20);
            this.label54.TabIndex = 0;
            this.label54.Text = "1轻度滋事";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(9, 311);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.tableLayoutPanel1.SetRowSpan(this.label14, 2);
            this.label14.Size = new System.Drawing.Size(203, 50);
            this.label14.TabIndex = 177;
            this.label14.Text = "对家庭和社会影响:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbDinner
            // 
            this.cbDinner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDinner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDinner.FormattingEnabled = true;
            this.cbDinner.Location = new System.Drawing.Point(1105, 175);
            this.cbDinner.Name = "cbDinner";
            this.cbDinner.Size = new System.Drawing.Size(173, 28);
            this.cbDinner.TabIndex = 8;
            // 
            // cbSleep
            // 
            this.cbSleep.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbSleep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSleep.FormattingEnabled = true;
            this.cbSleep.Location = new System.Drawing.Point(649, 175);
            this.cbSleep.Name = "cbSleep";
            this.cbSleep.Size = new System.Drawing.Size(173, 28);
            this.cbSleep.TabIndex = 7;
            // 
            // lbDinner
            // 
            this.lbDinner.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDinner.AutoSize = true;
            this.lbDinner.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDinner.Location = new System.Drawing.Point(1000, 179);
            this.lbDinner.Name = "lbDinner";
            this.lbDinner.Size = new System.Drawing.Size(99, 20);
            this.lbDinner.TabIndex = 132;
            this.lbDinner.Text = "饮食情况:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(544, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 131;
            this.label3.Text = "睡眠情况:";
            // 
            // cbSelfKnow
            // 
            this.cbSelfKnow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbSelfKnow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelfKnow.FormattingEnabled = true;
            this.cbSelfKnow.Location = new System.Drawing.Point(215, 175);
            this.cbSelfKnow.Name = "cbSelfKnow";
            this.cbSelfKnow.Size = new System.Drawing.Size(173, 28);
            this.cbSelfKnow.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(110, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 105;
            this.label1.Text = "自 知 力:";
            // 
            // dtpFollowDate
            // 
            this.dtpFollowDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFollowDate.Location = new System.Drawing.Point(1105, 6);
            this.dtpFollowDate.Name = "dtpFollowDate";
            this.dtpFollowDate.Size = new System.Drawing.Size(173, 30);
            this.dtpFollowDate.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(3, 242);
            this.label9.Name = "label9";
            this.tableLayoutPanel1.SetRowSpan(this.label9, 2);
            this.label9.Size = new System.Drawing.Size(206, 20);
            this.label9.TabIndex = 130;
            this.label9.Text = "社会功能情况:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbIDCARD
            // 
            this.tbIDCARD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbIDCARD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbIDCARD.ForeColor = System.Drawing.Color.Black;
            this.tbIDCARD.Location = new System.Drawing.Point(649, 6);
            this.tbIDCARD.MaxLength = 18;
            this.tbIDCARD.Name = "tbIDCARD";
            this.tbIDCARD.ReadOnly = true;
            this.tbIDCARD.Size = new System.Drawing.Size(227, 30);
            this.tbIDCARD.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(0, 116);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.tableLayoutPanel1.SetRowSpan(this.label16, 2);
            this.label16.Size = new System.Drawing.Size(212, 20);
            this.label16.TabIndex = 111;
            this.label16.Text = "        目前症状:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(110, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 94;
            this.label10.Text = "姓    名:";
            // 
            // tbName
            // 
            this.tbName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(215, 6);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(173, 30);
            this.tbName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(544, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 130;
            this.label2.Text = "身份证号:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(1000, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 136;
            this.label11.Text = "随访日期:";
            // 
            // panel9
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel9, 5);
            this.panel9.Controls.Add(this.label12);
            this.panel9.Controls.Add(this.cbCommunicate);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.cbStudy);
            this.panel9.Controls.Add(this.lbWorkAndJob);
            this.panel9.Controls.Add(this.cbWorkAndJob);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Controls.Add(this.cbFamWork);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Controls.Add(this.cbLife);
            this.panel9.Location = new System.Drawing.Point(212, 210);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.tableLayoutPanel1.SetRowSpan(this.panel9, 2);
            this.panel9.Size = new System.Drawing.Size(978, 82);
            this.panel9.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(313, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "社会人际交往:";
            // 
            // cbCommunicate
            // 
            this.cbCommunicate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommunicate.FormattingEnabled = true;
            this.cbCommunicate.Location = new System.Drawing.Point(464, 50);
            this.cbCommunicate.Name = "cbCommunicate";
            this.cbCommunicate.Size = new System.Drawing.Size(145, 28);
            this.cbCommunicate.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(20, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "学 习 能 力:";
            // 
            // cbStudy
            // 
            this.cbStudy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudy.FormattingEnabled = true;
            this.cbStudy.Location = new System.Drawing.Point(157, 50);
            this.cbStudy.Name = "cbStudy";
            this.cbStudy.Size = new System.Drawing.Size(145, 28);
            this.cbStudy.TabIndex = 7;
            // 
            // lbWorkAndJob
            // 
            this.lbWorkAndJob.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbWorkAndJob.AutoSize = true;
            this.lbWorkAndJob.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWorkAndJob.Location = new System.Drawing.Point(634, 7);
            this.lbWorkAndJob.Name = "lbWorkAndJob";
            this.lbWorkAndJob.Size = new System.Drawing.Size(159, 20);
            this.lbWorkAndJob.TabIndex = 4;
            this.lbWorkAndJob.Text = "生产劳动及工作:";
            // 
            // cbWorkAndJob
            // 
            this.cbWorkAndJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkAndJob.FormattingEnabled = true;
            this.cbWorkAndJob.Location = new System.Drawing.Point(801, 6);
            this.cbWorkAndJob.Name = "cbWorkAndJob";
            this.cbWorkAndJob.Size = new System.Drawing.Size(145, 28);
            this.cbWorkAndJob.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(353, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "家务劳动:";
            // 
            // cbFamWork
            // 
            this.cbFamWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFamWork.FormattingEnabled = true;
            this.cbFamWork.Location = new System.Drawing.Point(464, 6);
            this.cbFamWork.Name = "cbFamWork";
            this.cbFamWork.Size = new System.Drawing.Size(145, 28);
            this.cbFamWork.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(10, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "个人生活料理:";
            // 
            // cbLife
            // 
            this.cbLife.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLife.FormattingEnabled = true;
            this.cbLife.Location = new System.Drawing.Point(157, 6);
            this.cbLife.Name = "cbLife";
            this.cbLife.Size = new System.Drawing.Size(145, 28);
            this.cbLife.TabIndex = 1;
            // 
            // label56
            // 
            this.label56.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label56.Location = new System.Drawing.Point(544, 389);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(99, 20);
            this.label56.TabIndex = 178;
            this.label56.Text = "住院情况:";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(90, 431);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 20);
            this.label17.TabIndex = 180;
            this.label17.Text = "实验室检查:";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.rdSysYes);
            this.panel12.Controls.Add(this.rdSysNo);
            this.panel12.Location = new System.Drawing.Point(215, 423);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(173, 35);
            this.panel12.TabIndex = 14;
            // 
            // rdSysYes
            // 
            this.rdSysYes.AutoSize = true;
            this.rdSysYes.Location = new System.Drawing.Point(76, 4);
            this.rdSysYes.Name = "rdSysYes";
            this.rdSysYes.Size = new System.Drawing.Size(47, 24);
            this.rdSysYes.TabIndex = 103;
            this.rdSysYes.TabStop = true;
            this.rdSysYes.Text = "有";
            this.rdSysYes.UseVisualStyleBackColor = true;
            // 
            // rdSysNo
            // 
            this.rdSysNo.AutoSize = true;
            this.rdSysNo.Location = new System.Drawing.Point(8, 4);
            this.rdSysNo.Name = "rdSysNo";
            this.rdSysNo.Size = new System.Drawing.Size(47, 24);
            this.rdSysNo.TabIndex = 102;
            this.rdSysNo.TabStop = true;
            this.rdSysNo.Text = "无";
            this.rdSysNo.UseVisualStyleBackColor = true;
            // 
            // tbSyshave
            // 
            this.tbSyshave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.tbSyshave, 2);
            this.tbSyshave.Location = new System.Drawing.Point(459, 426);
            this.tbSyshave.MaxLength = 20;
            this.tbSyshave.Name = "tbSyshave";
            this.tbSyshave.Size = new System.Drawing.Size(302, 30);
            this.tbSyshave.TabIndex = 15;
            // 
            // label58
            // 
            this.label58.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label58.Location = new System.Drawing.Point(980, 431);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(119, 20);
            this.label58.TabIndex = 183;
            this.label58.Text = "服药依从性:";
            // 
            // cbDrugWay
            // 
            this.cbDrugWay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDrugWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrugWay.FormattingEnabled = true;
            this.cbDrugWay.Location = new System.Drawing.Point(1105, 427);
            this.cbDrugWay.Name = "cbDrugWay";
            this.cbDrugWay.Size = new System.Drawing.Size(199, 28);
            this.cbDrugWay.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(70, 473);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(139, 20);
            this.label18.TabIndex = 185;
            this.label18.Text = "药物不良反应:";
            // 
            // tbBlfy
            // 
            this.tbBlfy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.tbBlfy, 2);
            this.tbBlfy.Location = new System.Drawing.Point(459, 468);
            this.tbBlfy.MaxLength = 20;
            this.tbBlfy.Name = "tbBlfy";
            this.tbBlfy.Size = new System.Drawing.Size(302, 30);
            this.tbBlfy.TabIndex = 18;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(1000, 473);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 20);
            this.label21.TabIndex = 188;
            this.label21.Text = "治疗效果:";
            // 
            // cbMedication
            // 
            this.cbMedication.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbMedication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMedication.FormattingEnabled = true;
            this.cbMedication.Location = new System.Drawing.Point(1105, 469);
            this.cbMedication.Name = "cbMedication";
            this.cbMedication.Size = new System.Drawing.Size(199, 28);
            this.cbMedication.TabIndex = 19;
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel7.Controls.Add(this.rdNoZz);
            this.panel7.Controls.Add(this.rdYesZz);
            this.panel7.Location = new System.Drawing.Point(215, 592);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(173, 28);
            this.panel7.TabIndex = 20;
            // 
            // rdNoZz
            // 
            this.rdNoZz.AutoSize = true;
            this.rdNoZz.Location = new System.Drawing.Point(10, 3);
            this.rdNoZz.Name = "rdNoZz";
            this.rdNoZz.Size = new System.Drawing.Size(47, 24);
            this.rdNoZz.TabIndex = 101;
            this.rdNoZz.TabStop = true;
            this.rdNoZz.Text = "否";
            this.rdNoZz.UseVisualStyleBackColor = true;
            this.rdNoZz.CheckedChanged += new System.EventHandler(this.rdNoZz_CheckedChanged);
            // 
            // rdYesZz
            // 
            this.rdYesZz.AutoSize = true;
            this.rdYesZz.Location = new System.Drawing.Point(76, 3);
            this.rdYesZz.Name = "rdYesZz";
            this.rdYesZz.Size = new System.Drawing.Size(47, 24);
            this.rdYesZz.TabIndex = 100;
            this.rdYesZz.TabStop = true;
            this.rdYesZz.Text = "是";
            this.rdYesZz.UseVisualStyleBackColor = true;
            this.rdYesZz.CheckedChanged += new System.EventHandler(this.rdYesZz_CheckedChanged);
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(544, 596);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 20);
            this.label23.TabIndex = 192;
            this.label23.Text = "转诊原因:";
            // 
            // tbZzYy
            // 
            this.tbZzYy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZzYy.Location = new System.Drawing.Point(649, 591);
            this.tbZzYy.MaxLength = 20;
            this.tbZzYy.Name = "tbZzYy";
            this.tbZzYy.ReadOnly = true;
            this.tbZzYy.Size = new System.Drawing.Size(173, 30);
            this.tbZzYy.TabIndex = 21;
            // 
            // tbKfchsQt
            // 
            this.tbKfchsQt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbKfchsQt.Location = new System.Drawing.Point(1105, 1056);
            this.tbKfchsQt.Name = "tbKfchsQt";
            this.tbKfchsQt.ReadOnly = true;
            this.tbKfchsQt.Size = new System.Drawing.Size(175, 30);
            this.tbKfchsQt.TabIndex = 25;
            // 
            // chklbSystom
            // 
            this.chklbSystom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chklbSystom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chklbSystom.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chklbSystom, 4);
            this.chklbSystom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklbSystom.FormattingEnabled = true;
            this.chklbSystom.Items.AddRange(new object[] {
            "幻觉",
            "交流困难",
            "猜疑",
            "喜怒无常",
            "行为怪异",
            "兴奋话多",
            "伤人毁物",
            "悲观厌世",
            "无故外走",
            "自语自笑",
            "孤僻懒散",
            "其他"});
            this.chklbSystom.Location = new System.Drawing.Point(212, 84);
            this.chklbSystom.Margin = new System.Windows.Forms.Padding(0);
            this.chklbSystom.MultiColumn = true;
            this.chklbSystom.Name = "chklbSystom";
            this.tableLayoutPanel1.SetRowSpan(this.chklbSystom, 2);
            this.chklbSystom.Size = new System.Drawing.Size(890, 84);
            this.chklbSystom.TabIndex = 4;
            // 
            // tbSysptonOther
            // 
            this.tbSysptonOther.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbSysptonOther.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSysptonOther.Location = new System.Drawing.Point(1105, 100);
            this.tbSysptonOther.MaxLength = 100;
            this.tbSysptonOther.Multiline = true;
            this.tbSysptonOther.Name = "tbSysptonOther";
            this.tbSysptonOther.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.tbSysptonOther, 2);
            this.tbSysptonOther.Size = new System.Drawing.Size(176, 52);
            this.tbSysptonOther.TabIndex = 5;
            // 
            // label43
            // 
            this.label43.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(110, 1061);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(99, 20);
            this.label43.TabIndex = 213;
            this.label43.Text = "康复措施:";
            // 
            // panel5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel5, 7);
            this.panel5.Controls.Add(this.linkLabel1);
            this.panel5.Controls.Add(this.label44);
            this.panel5.Controls.Add(this.cbVisitType);
            this.panel5.Controls.Add(this.label45);
            this.panel5.Controls.Add(this.dtpNext);
            this.panel5.Controls.Add(this.label46);
            this.panel5.Controls.Add(this.tbDoctor);
            this.panel5.Location = new System.Drawing.Point(0, 1178);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1186, 44);
            this.panel5.TabIndex = 26;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(1058, 19);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(93, 16);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "编辑常用药";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label44
            // 
            this.label44.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.Location = new System.Drawing.Point(46, 16);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(139, 20);
            this.label44.TabIndex = 215;
            this.label44.Text = "本次随访分类:";
            // 
            // cbVisitType
            // 
            this.cbVisitType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbVisitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisitType.FormattingEnabled = true;
            this.cbVisitType.Location = new System.Drawing.Point(191, 7);
            this.cbVisitType.Name = "cbVisitType";
            this.cbVisitType.Size = new System.Drawing.Size(134, 28);
            this.cbVisitType.TabIndex = 0;
            // 
            // label45
            // 
            this.label45.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.Location = new System.Drawing.Point(653, 11);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(139, 20);
            this.label45.TabIndex = 217;
            this.label45.Text = "下次随访日期:";
            // 
            // dtpNext
            // 
            this.dtpNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpNext.Location = new System.Drawing.Point(795, 6);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(192, 30);
            this.dtpNext.TabIndex = 1;
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.Location = new System.Drawing.Point(384, 11);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(99, 20);
            this.label46.TabIndex = 219;
            this.label46.Text = "随访医生:";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDoctor.Location = new System.Drawing.Point(486, 7);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(139, 30);
            this.tbDoctor.TabIndex = 2;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(110, 1104);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(99, 20);
            this.label28.TabIndex = 225;
            this.label28.Text = "是否死亡:";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rdsw2);
            this.panel8.Controls.Add(this.rdsw1);
            this.panel8.Location = new System.Drawing.Point(215, 1097);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(182, 34);
            this.panel8.TabIndex = 226;
            // 
            // rdsw2
            // 
            this.rdsw2.AutoSize = true;
            this.rdsw2.Location = new System.Drawing.Point(89, 3);
            this.rdsw2.Name = "rdsw2";
            this.rdsw2.Size = new System.Drawing.Size(47, 24);
            this.rdsw2.TabIndex = 1;
            this.rdsw2.TabStop = true;
            this.rdsw2.Text = "是";
            this.rdsw2.UseVisualStyleBackColor = true;
            this.rdsw2.CheckedChanged += new System.EventHandler(this.rdsw2_CheckedChanged);
            // 
            // rdsw1
            // 
            this.rdsw1.AutoSize = true;
            this.rdsw1.Location = new System.Drawing.Point(3, 3);
            this.rdsw1.Name = "rdsw1";
            this.rdsw1.Size = new System.Drawing.Size(47, 24);
            this.rdsw1.TabIndex = 0;
            this.rdsw1.TabStop = true;
            this.rdsw1.Text = "否";
            this.rdsw1.UseVisualStyleBackColor = true;
            this.rdsw1.CheckedChanged += new System.EventHandler(this.rdsw1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 1104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 227;
            this.label4.Text = "死亡日期:";
            // 
            // dtDeathDay
            // 
            this.dtDeathDay.Location = new System.Drawing.Point(649, 1097);
            this.dtDeathDay.Name = "dtDeathDay";
            this.dtDeathDay.Size = new System.Drawing.Size(175, 30);
            this.dtDeathDay.TabIndex = 228;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(110, 1146);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(99, 20);
            this.label26.TabIndex = 229;
            this.label26.Text = "死亡原因:";
            // 
            // cbsfyy
            // 
            this.cbsfyy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsfyy.FormattingEnabled = true;
            this.cbsfyy.Location = new System.Drawing.Point(1105, 45);
            this.cbsfyy.Name = "cbsfyy";
            this.cbsfyy.Size = new System.Drawing.Size(173, 28);
            this.cbsfyy.TabIndex = 218;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1000, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 217;
            this.label7.Text = "失访原因:";
            // 
            // cbDangerous
            // 
            this.cbDangerous.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDangerous.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDangerous.FormattingEnabled = true;
            this.cbDangerous.Location = new System.Drawing.Point(649, 49);
            this.cbDangerous.Name = "cbDangerous";
            this.cbDangerous.Size = new System.Drawing.Size(173, 28);
            this.cbDangerous.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(544, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 100;
            this.label13.Text = "危 险 性:";
            // 
            // cmbsffs
            // 
            this.cmbsffs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsffs.FormattingEnabled = true;
            this.cmbsffs.Location = new System.Drawing.Point(215, 45);
            this.cmbsffs.Name = "cmbsffs";
            this.cmbsffs.Size = new System.Drawing.Size(175, 28);
            this.cmbsffs.TabIndex = 232;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.cmbywfy);
            this.panel11.Location = new System.Drawing.Point(215, 465);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(173, 35);
            this.panel11.TabIndex = 17;
            // 
            // cmbywfy
            // 
            this.cmbywfy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbywfy.FormattingEnabled = true;
            this.cmbywfy.Location = new System.Drawing.Point(1, 5);
            this.cmbywfy.Name = "cmbywfy";
            this.cmbywfy.Size = new System.Drawing.Size(172, 28);
            this.cmbywfy.TabIndex = 0;
            this.cmbywfy.SelectedIndexChanged += new System.EventHandler(this.cmbywfy_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 6);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Location = new System.Drawing.Point(3, 918);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 3);
            this.groupBox1.Size = new System.Drawing.Size(1366, 128);
            this.groupBox1.TabIndex = 233;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "调整用药情况";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.doseycYYZD3);
            this.groupBox4.Controls.Add(this.doseycYYZD2);
            this.groupBox4.Controls.Add(this.doseycYYZD1);
            this.groupBox4.Location = new System.Drawing.Point(0, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1350, 128);
            this.groupBox4.TabIndex = 210;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "调整用药情况";
            // 
            // doseycYYZD3
            // 
            this.doseycYYZD3.ErrorInput = false;
            this.doseycYYZD3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseycYYZD3.Location = new System.Drawing.Point(34, 88);
            this.doseycYYZD3.Margin = new System.Windows.Forms.Padding(4);
            this.doseycYYZD3.MText = "药物名称3";
            this.doseycYYZD3.Name = "doseycYYZD3";
            this.doseycYYZD3.Size = new System.Drawing.Size(660, 35);
            this.doseycYYZD3.Source.DailyTime = null;
            this.doseycYYZD3.Source.DosAge = null;
            this.doseycYYZD3.Source.drugtype = null;
            this.doseycYYZD3.Source.EveryTimeMg = null;
            this.doseycYYZD3.Source.factory = null;
            this.doseycYYZD3.Source.ID = 0;
            this.doseycYYZD3.Source.IDCardNo = null;
            this.doseycYYZD3.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.doseycYYZD3.Source.Name = null;
            this.doseycYYZD3.Source.OUTKey = 0;
            this.doseycYYZD3.Source.Type = null;
            this.doseycYYZD3.TabIndex = 0;
            // 
            // doseycYYZD2
            // 
            this.doseycYYZD2.ErrorInput = false;
            this.doseycYYZD2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseycYYZD2.Location = new System.Drawing.Point(34, 52);
            this.doseycYYZD2.Margin = new System.Windows.Forms.Padding(4);
            this.doseycYYZD2.MText = "药物名称2";
            this.doseycYYZD2.Name = "doseycYYZD2";
            this.doseycYYZD2.Size = new System.Drawing.Size(667, 34);
            this.doseycYYZD2.Source.DailyTime = null;
            this.doseycYYZD2.Source.DosAge = null;
            this.doseycYYZD2.Source.drugtype = null;
            this.doseycYYZD2.Source.EveryTimeMg = null;
            this.doseycYYZD2.Source.factory = null;
            this.doseycYYZD2.Source.ID = 0;
            this.doseycYYZD2.Source.IDCardNo = null;
            this.doseycYYZD2.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.doseycYYZD2.Source.Name = null;
            this.doseycYYZD2.Source.OUTKey = 0;
            this.doseycYYZD2.Source.Type = null;
            this.doseycYYZD2.TabIndex = 1;
            this.doseycYYZD2.Load += new System.EventHandler(this.doseycYYZD2_Load);
            // 
            // doseycYYZD1
            // 
            this.doseycYYZD1.ErrorInput = false;
            this.doseycYYZD1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseycYYZD1.Location = new System.Drawing.Point(34, 16);
            this.doseycYYZD1.Margin = new System.Windows.Forms.Padding(4);
            this.doseycYYZD1.MText = "药物名称1";
            this.doseycYYZD1.Name = "doseycYYZD1";
            this.doseycYYZD1.Size = new System.Drawing.Size(742, 36);
            this.doseycYYZD1.Source.DailyTime = null;
            this.doseycYYZD1.Source.DosAge = null;
            this.doseycYYZD1.Source.drugtype = null;
            this.doseycYYZD1.Source.EveryTimeMg = null;
            this.doseycYYZD1.Source.factory = null;
            this.doseycYYZD1.Source.ID = 0;
            this.doseycYYZD1.Source.IDCardNo = null;
            this.doseycYYZD1.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.doseycYYZD1.Source.Name = null;
            this.doseycYYZD1.Source.OUTKey = 0;
            this.doseycYYZD1.Source.Type = null;
            this.doseycYYZD1.TabIndex = 2;
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(50, 96);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(99, 20);
            this.label36.TabIndex = 208;
            this.label36.Text = "药 物  3:";
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(50, 62);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(99, 20);
            this.label35.TabIndex = 203;
            this.label35.Text = "药 物  2:";
            // 
            // label34
            // 
            this.label34.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(51, 28);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(99, 20);
            this.label34.TabIndex = 197;
            this.label34.Text = "药 物  1:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Location = new System.Drawing.Point(3, 789);
            this.groupBox2.Name = "groupBox2";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox2, 3);
            this.groupBox2.Size = new System.Drawing.Size(1366, 123);
            this.groupBox2.TabIndex = 234;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目前用药情况";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.doseycVUC3);
            this.groupBox5.Controls.Add(this.doseycVUC2);
            this.groupBox5.Controls.Add(this.doseycVUC1);
            this.groupBox5.Location = new System.Drawing.Point(1, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1350, 125);
            this.groupBox5.TabIndex = 213;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "目前用药情况";
            // 
            // doseycVUC3
            // 
            this.doseycVUC3.ErrorInput = false;
            this.doseycVUC3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseycVUC3.Location = new System.Drawing.Point(34, 85);
            this.doseycVUC3.Margin = new System.Windows.Forms.Padding(4);
            this.doseycVUC3.MText = "药物名称3";
            this.doseycVUC3.Name = "doseycVUC3";
            this.doseycVUC3.Size = new System.Drawing.Size(638, 37);
            this.doseycVUC3.Source.DailyTime = null;
            this.doseycVUC3.Source.DosAge = null;
            this.doseycVUC3.Source.drugtype = null;
            this.doseycVUC3.Source.EveryTimeMg = null;
            this.doseycVUC3.Source.factory = null;
            this.doseycVUC3.Source.ID = 0;
            this.doseycVUC3.Source.IDCardNo = null;
            this.doseycVUC3.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.doseycVUC3.Source.Name = null;
            this.doseycVUC3.Source.OUTKey = 0;
            this.doseycVUC3.Source.Type = null;
            this.doseycVUC3.TabIndex = 0;
            // 
            // doseycVUC2
            // 
            this.doseycVUC2.ErrorInput = false;
            this.doseycVUC2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseycVUC2.Location = new System.Drawing.Point(34, 50);
            this.doseycVUC2.Margin = new System.Windows.Forms.Padding(4);
            this.doseycVUC2.MText = "药物名称2";
            this.doseycVUC2.Name = "doseycVUC2";
            this.doseycVUC2.Size = new System.Drawing.Size(651, 36);
            this.doseycVUC2.Source.DailyTime = null;
            this.doseycVUC2.Source.DosAge = null;
            this.doseycVUC2.Source.drugtype = null;
            this.doseycVUC2.Source.EveryTimeMg = null;
            this.doseycVUC2.Source.factory = null;
            this.doseycVUC2.Source.ID = 0;
            this.doseycVUC2.Source.IDCardNo = null;
            this.doseycVUC2.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.doseycVUC2.Source.Name = null;
            this.doseycVUC2.Source.OUTKey = 0;
            this.doseycVUC2.Source.Type = null;
            this.doseycVUC2.TabIndex = 1;
            // 
            // doseycVUC1
            // 
            this.doseycVUC1.ErrorInput = false;
            this.doseycVUC1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doseycVUC1.Location = new System.Drawing.Point(34, 15);
            this.doseycVUC1.Margin = new System.Windows.Forms.Padding(4);
            this.doseycVUC1.MText = "药物名称1";
            this.doseycVUC1.Name = "doseycVUC1";
            this.doseycVUC1.Size = new System.Drawing.Size(771, 36);
            this.doseycVUC1.Source.DailyTime = null;
            this.doseycVUC1.Source.DosAge = null;
            this.doseycVUC1.Source.drugtype = null;
            this.doseycVUC1.Source.EveryTimeMg = null;
            this.doseycVUC1.Source.factory = null;
            this.doseycVUC1.Source.ID = 0;
            this.doseycVUC1.Source.IDCardNo = null;
            this.doseycVUC1.Source.ModelState = KangShuoTech.DataAccessProjects.Model.RecordsStateModel.Unchanged;
            this.doseycVUC1.Source.Name = null;
            this.doseycVUC1.Source.OUTKey = 0;
            this.doseycVUC1.Source.Type = null;
            this.doseycVUC1.TabIndex = 2;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(50, 91);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(99, 20);
            this.label25.TabIndex = 211;
            this.label25.Text = "药 物  3:";
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(50, 60);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(99, 20);
            this.label31.TabIndex = 210;
            this.label31.Text = "药 物  2:";
            // 
            // label37
            // 
            this.label37.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(51, 26);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(99, 20);
            this.label37.TabIndex = 209;
            this.label37.Text = "药 物  1:";
            // 
            // label38
            // 
            this.label38.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(70, 516);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(139, 20);
            this.label38.TabIndex = 235;
            this.label38.Text = "通知联席部门:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 4);
            this.panel3.Controls.Add(this.tbPoliceAgentTel);
            this.panel3.Controls.Add(this.label40);
            this.panel3.Controls.Add(this.tbPoliceAgent);
            this.panel3.Controls.Add(this.label39);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(456, 504);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(916, 44);
            this.panel3.TabIndex = 237;
            // 
            // tbPoliceAgentTel
            // 
            this.tbPoliceAgentTel.Location = new System.Drawing.Point(538, 7);
            this.tbPoliceAgentTel.Name = "tbPoliceAgentTel";
            this.tbPoliceAgentTel.Size = new System.Drawing.Size(171, 30);
            this.tbPoliceAgentTel.TabIndex = 239;
            // 
            // label40
            // 
            this.label40.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(482, 12);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(59, 20);
            this.label40.TabIndex = 238;
            this.label40.Text = "电话:";
            // 
            // tbPoliceAgent
            // 
            this.tbPoliceAgent.Location = new System.Drawing.Point(254, 8);
            this.tbPoliceAgent.Name = "tbPoliceAgent";
            this.tbPoliceAgent.Size = new System.Drawing.Size(151, 30);
            this.tbPoliceAgent.TabIndex = 237;
            // 
            // label39
            // 
            this.label39.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(57, 11);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(199, 20);
            this.label39.TabIndex = 236;
            this.label39.Text = "公安部门受理人姓名:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 4);
            this.panel4.Controls.Add(this.tbCommunityAgentTel);
            this.panel4.Controls.Add(this.label41);
            this.panel4.Controls.Add(this.tbCommunityAgent);
            this.panel4.Controls.Add(this.label42);
            this.panel4.Enabled = false;
            this.panel4.Location = new System.Drawing.Point(456, 548);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(916, 37);
            this.panel4.TabIndex = 238;
            // 
            // tbCommunityAgentTel
            // 
            this.tbCommunityAgentTel.Location = new System.Drawing.Point(537, 3);
            this.tbCommunityAgentTel.Name = "tbCommunityAgentTel";
            this.tbCommunityAgentTel.Size = new System.Drawing.Size(171, 30);
            this.tbCommunityAgentTel.TabIndex = 239;
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(482, 13);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(59, 20);
            this.label41.TabIndex = 238;
            this.label41.Text = "电话:";
            // 
            // tbCommunityAgent
            // 
            this.tbCommunityAgent.Location = new System.Drawing.Point(254, 3);
            this.tbCommunityAgent.Name = "tbCommunityAgent";
            this.tbCommunityAgent.Size = new System.Drawing.Size(151, 30);
            this.tbCommunityAgent.TabIndex = 237;
            // 
            // label42
            // 
            this.label42.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(17, 12);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(239, 20);
            this.label42.TabIndex = 236;
            this.label42.Text = "社区综治中心受理人姓名:";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 4);
            this.panel6.Controls.Add(this.label62);
            this.panel6.Controls.Add(this.tbZzLxdh);
            this.panel6.Controls.Add(this.label61);
            this.panel6.Controls.Add(this.tbZzLxr);
            this.panel6.Controls.Add(this.label60);
            this.panel6.Controls.Add(this.tbZzJg);
            this.panel6.Controls.Add(this.label24);
            this.panel6.Controls.Add(this.tbZzKs);
            this.panel6.Enabled = false;
            this.panel6.Location = new System.Drawing.Point(456, 627);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.tableLayoutPanel1.SetRowSpan(this.panel6, 2);
            this.panel6.Size = new System.Drawing.Size(916, 76);
            this.panel6.TabIndex = 240;
            // 
            // label62
            // 
            this.label62.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label62.Location = new System.Drawing.Point(358, 47);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(99, 20);
            this.label62.TabIndex = 200;
            this.label62.Text = "联系电话:";
            // 
            // tbZzLxdh
            // 
            this.tbZzLxdh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZzLxdh.Location = new System.Drawing.Point(480, 44);
            this.tbZzLxdh.MaxLength = 20;
            this.tbZzLxdh.Name = "tbZzLxdh";
            this.tbZzLxdh.Size = new System.Drawing.Size(175, 30);
            this.tbZzLxdh.TabIndex = 199;
            // 
            // label61
            // 
            this.label61.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label61.Location = new System.Drawing.Point(66, 47);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(79, 20);
            this.label61.TabIndex = 198;
            this.label61.Text = "联系人:";
            // 
            // tbZzLxr
            // 
            this.tbZzLxr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZzLxr.Location = new System.Drawing.Point(164, 44);
            this.tbZzLxr.MaxLength = 20;
            this.tbZzLxr.Name = "tbZzLxr";
            this.tbZzLxr.Size = new System.Drawing.Size(175, 30);
            this.tbZzLxr.TabIndex = 197;
            // 
            // label60
            // 
            this.label60.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label60.Location = new System.Drawing.Point(358, 14);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(99, 20);
            this.label60.TabIndex = 196;
            this.label60.Text = "转诊科室:";
            // 
            // tbZzJg
            // 
            this.tbZzJg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZzJg.Location = new System.Drawing.Point(164, 4);
            this.tbZzJg.MaxLength = 20;
            this.tbZzJg.Name = "tbZzJg";
            this.tbZzJg.Size = new System.Drawing.Size(175, 30);
            this.tbZzJg.TabIndex = 195;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(40, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(99, 20);
            this.label24.TabIndex = 194;
            this.label24.Text = "转诊机构:";
            // 
            // tbZzKs
            // 
            this.tbZzKs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZzKs.Location = new System.Drawing.Point(480, 6);
            this.tbZzKs.MaxLength = 20;
            this.tbZzKs.Name = "tbZzKs";
            this.tbZzKs.Size = new System.Drawing.Size(175, 30);
            this.tbZzKs.TabIndex = 22;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(110, 596);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 20);
            this.label22.TabIndex = 190;
            this.label22.Text = "是否转诊:";
            // 
            // label59
            // 
            this.label59.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(70, 648);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(139, 20);
            this.label59.TabIndex = 239;
            this.label59.Text = "转诊是否成功:";
            // 
            // panel14
            // 
            this.panel14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel14.Controls.Add(this.rdZzcgNo);
            this.panel14.Controls.Add(this.rdZzcgYes);
            this.panel14.Location = new System.Drawing.Point(215, 641);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(173, 34);
            this.panel14.TabIndex = 241;
            // 
            // rdZzcgNo
            // 
            this.rdZzcgNo.AutoSize = true;
            this.rdZzcgNo.Location = new System.Drawing.Point(7, 4);
            this.rdZzcgNo.Name = "rdZzcgNo";
            this.rdZzcgNo.Size = new System.Drawing.Size(47, 24);
            this.rdZzcgNo.TabIndex = 101;
            this.rdZzcgNo.TabStop = true;
            this.rdZzcgNo.Text = "否";
            this.rdZzcgNo.UseVisualStyleBackColor = true;
            this.rdZzcgNo.CheckedChanged += new System.EventHandler(this.rdZzcgNo_CheckedChanged);
            // 
            // rdZzcgYes
            // 
            this.rdZzcgYes.AutoSize = true;
            this.rdZzcgYes.Location = new System.Drawing.Point(75, 4);
            this.rdZzcgYes.Name = "rdZzcgYes";
            this.rdZzcgYes.Size = new System.Drawing.Size(47, 24);
            this.rdZzcgYes.TabIndex = 100;
            this.rdZzcgYes.TabStop = true;
            this.rdZzcgYes.Text = "是";
            this.rdZzcgYes.UseVisualStyleBackColor = true;
            this.rdZzcgYes.CheckedChanged += new System.EventHandler(this.rdZzcgYes_CheckedChanged);
            // 
            // label63
            // 
            this.label63.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(10, 731);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(199, 20);
            this.label63.TabIndex = 242;
            this.label63.Text = "未住院或转诊未成功:";
            // 
            // label64
            // 
            this.label64.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(274, 731);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(179, 20);
            this.label64.TabIndex = 243;
            this.label64.Text = "联系精神专科医师:";
            // 
            // panel15
            // 
            this.panel15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel15.Controls.Add(this.rdZkysNo);
            this.panel15.Controls.Add(this.rdZkysYes);
            this.panel15.Location = new System.Drawing.Point(459, 721);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(164, 40);
            this.panel15.TabIndex = 244;
            // 
            // rdZkysNo
            // 
            this.rdZkysNo.AutoSize = true;
            this.rdZkysNo.Location = new System.Drawing.Point(4, 4);
            this.rdZkysNo.Name = "rdZkysNo";
            this.rdZkysNo.Size = new System.Drawing.Size(47, 24);
            this.rdZkysNo.TabIndex = 101;
            this.rdZkysNo.TabStop = true;
            this.rdZkysNo.Text = "否";
            this.rdZkysNo.UseVisualStyleBackColor = true;
            this.rdZkysNo.CheckedChanged += new System.EventHandler(this.rdZkysNo_CheckedChanged);
            // 
            // rdZkysYes
            // 
            this.rdZkysYes.AutoSize = true;
            this.rdZkysYes.Location = new System.Drawing.Point(66, 4);
            this.rdZkysYes.Name = "rdZkysYes";
            this.rdZkysYes.Size = new System.Drawing.Size(47, 24);
            this.rdZkysYes.TabIndex = 100;
            this.rdZkysYes.TabStop = true;
            this.rdZkysYes.Text = "是";
            this.rdZkysYes.UseVisualStyleBackColor = true;
            this.rdZkysYes.CheckedChanged += new System.EventHandler(this.rdZkysYes_CheckedChanged);
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel16, 3);
            this.panel16.Controls.Add(this.tbZKYSJG);
            this.panel16.Controls.Add(this.label67);
            this.panel16.Controls.Add(this.tbZKYSDH);
            this.panel16.Controls.Add(this.label66);
            this.panel16.Controls.Add(this.tbZKYSXM);
            this.panel16.Controls.Add(this.label65);
            this.panel16.Enabled = false;
            this.panel16.Location = new System.Drawing.Point(649, 706);
            this.panel16.Name = "panel16";
            this.tableLayoutPanel1.SetRowSpan(this.panel16, 2);
            this.panel16.Size = new System.Drawing.Size(720, 77);
            this.panel16.TabIndex = 245;
            // 
            // tbZKYSJG
            // 
            this.tbZKYSJG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZKYSJG.Location = new System.Drawing.Point(208, 44);
            this.tbZKYSJG.MaxLength = 20;
            this.tbZKYSJG.Name = "tbZKYSJG";
            this.tbZKYSJG.Size = new System.Drawing.Size(365, 30);
            this.tbZKYSJG.TabIndex = 204;
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.Location = new System.Drawing.Point(112, 50);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(99, 20);
            this.label67.TabIndex = 203;
            this.label67.Text = "处置结果:";
            // 
            // tbZKYSDH
            // 
            this.tbZKYSDH.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZKYSDH.Location = new System.Drawing.Point(402, 5);
            this.tbZKYSDH.MaxLength = 20;
            this.tbZKYSDH.Name = "tbZKYSDH";
            this.tbZKYSDH.Size = new System.Drawing.Size(171, 30);
            this.tbZKYSDH.TabIndex = 202;
            // 
            // label66
            // 
            this.label66.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.Location = new System.Drawing.Point(348, 10);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(59, 20);
            this.label66.TabIndex = 201;
            this.label66.Text = "电话:";
            // 
            // tbZKYSXM
            // 
            this.tbZKYSXM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZKYSXM.Location = new System.Drawing.Point(208, 5);
            this.tbZKYSXM.MaxLength = 20;
            this.tbZKYSXM.Name = "tbZKYSXM";
            this.tbZKYSXM.Size = new System.Drawing.Size(120, 30);
            this.tbZKYSXM.TabIndex = 200;
            // 
            // label65
            // 
            this.label65.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label65.Location = new System.Drawing.Point(32, 8);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(179, 20);
            this.label65.TabIndex = 199;
            this.label65.Text = "精神专科医师姓名:";
            // 
            // panel17
            // 
            this.panel17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel17, 6);
            this.panel17.Controls.Add(this.picSignYs);
            this.panel17.Controls.Add(this.lkYs);
            this.panel17.Controls.Add(this.label69);
            this.panel17.Controls.Add(this.lkJs);
            this.panel17.Controls.Add(this.picSignJs);
            this.panel17.Controls.Add(this.label68);
            this.panel17.Location = new System.Drawing.Point(0, 1222);
            this.panel17.Margin = new System.Windows.Forms.Padding(0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1372, 82);
            this.panel17.TabIndex = 246;
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(222, 8);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(242, 68);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 253;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // lkYs
            // 
            this.lkYs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(477, 40);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 252;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(102, 39);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(99, 20);
            this.label69.TabIndex = 249;
            this.label69.Text = "医生签名:";
            // 
            // lkJs
            // 
            this.lkJs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lkJs.AutoSize = true;
            this.lkJs.Location = new System.Drawing.Point(1116, 40);
            this.lkJs.Name = "lkJs";
            this.lkJs.Size = new System.Drawing.Size(89, 20);
            this.lkJs.TabIndex = 248;
            this.lkJs.TabStop = true;
            this.lkJs.Text = "重置签名";
            this.lkJs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // picSignJs
            // 
            this.picSignJs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJs.Location = new System.Drawing.Point(859, 8);
            this.picSignJs.Name = "picSignJs";
            this.picSignJs.Size = new System.Drawing.Size(242, 68);
            this.picSignJs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJs.TabIndex = 0;
            this.picSignJs.TabStop = false;
            this.picSignJs.Click += new System.EventHandler(this.picSignJs_Click);
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(669, 40);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(159, 20);
            this.label68.TabIndex = 246;
            this.label68.Text = "患者(家属)签名:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(76, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(39, 18);
            this.radioButton1.TabIndex = 101;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "否";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(173, 1);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(151, 21);
            this.tb.TabIndex = 237;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(438, 1);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(171, 21);
            this.textBox3.TabIndex = 239;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(76, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 18);
            this.radioButton2.TabIndex = 101;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "否";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox7.Location = new System.Drawing.Point(436, 25);
            this.textBox7.MaxLength = 20;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(175, 21);
            this.textBox7.TabIndex = 199;
            // 
            // textBox10
            // 
            this.textBox10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox10.Location = new System.Drawing.Point(130, 27);
            this.textBox10.MaxLength = 20;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(350, 21);
            this.textBox10.TabIndex = 204;
            // 
            // MentalVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MentalVisitForm";
            this.Text = "MentalVisitForm";
            this.Load += new System.EventHandler(this.FrmMentalFollow_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).EndInit();
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
            ChronicMentalDiseaseVisitBLL cd_mentaldisease_followup = new ChronicMentalDiseaseVisitBLL();
            ChronicDrugConditionBLL chronicDrugconditionBLL = new ChronicDrugConditionBLL();
            ChronicMentalDiseaseVisitModel mentalmodel1 = cd_mentaldisease_followup.ExistsCheckDate(this.MentalVisit);
            if (mentalmodel1 != null)
            {
                if (this.IDPerson > 0 && this.visitdate == this.MentalVisit.FollowUpDate.ToString()) //随访查询中如果日期没做修改，不给提示
                {
                    this.IDPerson = mentalmodel1.ID;
                    this.MentalVisit.ID = mentalmodel1.ID;
                    cd_mentaldisease_followup.Update(this.MentalVisit);
                }
                else
                {
                    DialogResult result = DialogResult.OK;
                    result = MessageBox.Show("此日期下已有随访信息，是否进行修改？", "提示", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        cd_mentaldisease_followup.Delete(this.IDPerson);
                        chronicDrugconditionBLL.DeleteOUTKey(this.IDPerson, "3");
                        this.IDPerson = mentalmodel1.ID;
                        this.MentalVisit.ID = mentalmodel1.ID;
                        cd_mentaldisease_followup.Update(this.MentalVisit);
                    }
                    else
                        return true;
                }
            }
            else
            {
                if (this.IDPerson > 0)
                {
                    cd_mentaldisease_followup.Delete(this.IDPerson);
                    chronicDrugconditionBLL.DeleteOUTKey(this.IDPerson, "3");
                }
                this.IDPerson = cd_mentaldisease_followup.Add(this.MentalVisit);

            }
            chronicDrugconditionBLL.DeleteOUTKey(this.IDPerson, "3");
            for (int i = 0; i < this.DrugConditions.Count; i++)
            {
                DrugConditions[i].OUTKey = this.IDPerson;
                DrugConditions[i].Type = "3";
                if (!string.IsNullOrEmpty(this.DrugConditions[i].Name))
                {
                    chronicDrugconditionBLL.Add(this.DrugConditions[i]);
                }
            }
            chronicDrugconditionBLL.DeleteOUTKey(this.IDPerson, "6");//删除用药指导
            for (int i = 0; i < this.YYZDDrugConditions.Count; i++)
            {
                YYZDDrugConditions[i].OUTKey = this.IDPerson;
                YYZDDrugConditions[i].Type = "6";
                if (!string.IsNullOrEmpty(this.YYZDDrugConditions[i].Name))
                {
                    chronicDrugconditionBLL.Add(this.YYZDDrugConditions[i]);
                }
            }

            string NewSign = string.Format("{0}{1}_{2}.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpFollowDate.Value).ToString("yyyyMMdd"));
            string NewSignDoc = string.Format("{0}{1}_{2}_Doc.png", this.SignPath, this.Model.IDCardNo, Convert.ToDateTime(this.dtpFollowDate.Value).ToString("yyyyMMdd"));
            return true;
        }

        public void UpdataToModel()
        {
            this.MentalVisit.PresentSymptom = this.zhengzh.FinalResult;
            this.MentalVisit.PresentSymptoOther = this.zhengzh.FinalResultEX;
            this.MentalVisit.LaborExaminati = this.sysjc.Choose;
            this.MentalVisit.LaborExaminatiHave = this.sysjc.Choose_EX;
            //this.MentalVisit.AdnerDruReact = this.ywblfy.Choose;
            //this.MentalVisit.AdverDruReactHave = this.ywblfy.Choose_EX;
            this.MentalVisit.RehabiliMeasu = this.kangfu.FinalResult;
            this.MentalVisit.RehabiliMeasuOther = this.kangfu.FinalResultEX;
            this.MentalVisit.LastLeaveHospTime = ((this.MentalVisit.HospitalizatiStatus == "0") || string.IsNullOrEmpty(this.MentalVisit.HospitalizatiStatus)) ? null : new DateTime?(this.dtpLastEscape.Value.Date);
            this.MentalVisit.AttemptSuicideNone = ((((((this.MentalVisit.MildTroubleFrequen + this.MentalVisit.CreateDistuFrequen) + this.MentalVisit.CauseAccidFrequen) + this.MentalVisit.AutolesionFrequen) + this.MentalVisit.AttemptSuicFrequen) + this.MentalVisit.OtherDangerFrequen) <= 0) ? "无" : "有";
            if (this.rdNoZz.Checked)
            {
                this.MentalVisit.WhetherReferral = "1";
            }
            if (this.rdYesZz.Checked)
            {
                this.MentalVisit.WhetherReferral = "2";
            }
            this.MentalVisit.FollowUpDate = new DateTime?(this.dtpFollowDate.Value.Date);
            this.MentalVisit.NextFollowUpDate = new DateTime?(this.dtpNext.Value.Date);

            for (int k = 0; k < this.dosesyc.Count; k++)
            {
                this.dosesyc[k].UpdateSource();
                if (this.dosesyc[k].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.DrugConditions.Add(this.dosesyc[k].Source);
                }
            }
            for (int k = 0; k < this.YYZDdosesyc.Count; k++)
            {
                this.YYZDdosesyc[k].UpdateSource();
                if (this.YYZDdosesyc[k].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.YYZDDrugConditions.Add(this.YYZDdosesyc[k].Source);
                }
            }

            if (this.rdsw1.Checked)
            {
                this.MentalVisit.DeathDate = null;
                this.MentalVisit.IllReason = "";
                this.MentalVisit.DeathReason = "";
            }
            if (this.rdsw2.Checked)
            {
                this.MentalVisit.DeathDate = this.dtDeathDay.Value;
            }
            if (this.rdLxYes.Checked)
            {
                this.MentalVisit.JointPartFlag = "1";
            }
            else if (this.rdLxNo.Checked)
            {
                this.MentalVisit.JointPartFlag = "2";
            }
            if (this.rdZzcgNo.Checked)
            {
                this.MentalVisit.ReferralResult = "1";
            }
            else if (this.rdZzcgYes.Checked)
            {
                this.MentalVisit.ReferralResult = "2";
            }
            else
            {
                this.MentalVisit.ReferralResult = null;
            }
            if (this.rdZkysNo.Checked)
            {
                this.MentalVisit.ContactSpecialist = "1";
            }
            else if (this.rdZkysYes.Checked)
            {
                this.MentalVisit.ContactSpecialist = "2";
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoseFrm f = new DoseFrm();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private List<ChronicDrugConditionModel> DrugConditions { get; set; }

        private List<ChronicDrugConditionModel> YYZDDrugConditions { get; set; }//用药指导

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        private ChronicMentalDiseaseVisitModel MentalVisit { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public int IDPerson { get; set; }

        private void rdsw1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdsw1.Checked)
            {
                this.dtDeathDay.Enabled = false;
                this.panel13.Enabled = false;
            }
        }

        private void rdsw2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdsw2.Checked)
            {
                this.dtDeathDay.Enabled = true;
                this.panel13.Enabled = true;
            }
        }

        private void cmbywfy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbywfy.SelectedIndex == 1)//不良反应为有时
            {
                this.tbBlfy.ReadOnly = false;
            }
            else
            {
                this.tbBlfy.Clear();
                this.tbBlfy.ReadOnly = true;
            }
        }

        private void rdLxYes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdLxYes.Checked)
            {
                this.panel3.Enabled = true;
                this.panel4.Enabled = true;
            }

        }

        private void rdLxNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdLxNo.Checked)
            {
                this.tbPoliceAgent.Clear();
                this.tbPoliceAgentTel.Clear();
                this.tbCommunityAgent.Clear();
                this.tbCommunityAgentTel.Clear();
                this.panel3.Enabled = false;
                this.panel4.Enabled = false;
            }
        }

        private void rdYesZz_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdYesZz.Checked)
            {
                this.tbZzYy.ReadOnly = false;
                this.panel14.Enabled = true;
            }
        }

        private void rdNoZz_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdNoZz.Checked)
            {
                this.tbZzYy.Clear();
                this.tbZzJg.Clear();
                this.tbZzKs.Clear();
                this.tbZzLxdh.Clear();
                this.tbZzLxr.Clear();
                this.tbZzYy.ReadOnly = true;
                this.panel14.Enabled = false;
                this.rdZzcgNo.Checked = false;
                this.rdZzcgYes.Checked = false;
                this.tbZzJg.Clear();
                this.tbZzKs.Clear();
                this.tbZzLxdh.Clear();
                this.tbZzLxr.Clear();
                this.panel6.Enabled = false;
            }
        }

        private void rdZzcgYes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdZzcgYes.Checked)
            {
                this.panel6.Enabled = true;
            }
        }

        private void rdZzcgNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdZzcgNo.Checked)
            {
                this.tbZzJg.Clear();
                this.tbZzKs.Clear();
                this.tbZzLxdh.Clear();
                this.tbZzLxr.Clear();
                this.panel6.Enabled = false;
            }
        }

        private void rdZkysYes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdZkysYes.Checked)
            {
                this.panel16.Enabled = true;

            }
        }

        private void rdZkysNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdZkysNo.Checked)
            {
                this.tbZKYSXM.Clear();
                this.tbZKYSDH.Clear();
                this.tbZKYSJG.Clear();
                this.panel16.Enabled = false;

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("", picSignJs);
        }

        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_Doc", picSignYs);
        }

        private void chklbKfchs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void doseycYYZD2_Load(object sender, EventArgs e)
        {

        }

        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();
            string date = Convert.ToDateTime(this.dtpFollowDate.Value).ToString("yyyyMMdd");
            if (!Directory.Exists(SignPath))
            {
                Directory.CreateDirectory(SignPath);
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
                    string date = Convert.ToDateTime(this.dtpFollowDate.Value).ToString("yyyyMMdd");
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

        private void picSignJs_Click(object sender, EventArgs e)
        {
            Sign("", picSignJs);
        }
    }
}

