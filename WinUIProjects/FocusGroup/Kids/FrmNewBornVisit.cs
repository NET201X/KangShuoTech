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
    using System.Linq;
    using System.Reflection;
    using System.Timers;
    using System.Windows.Forms;
    using System.IO;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Configuration;

    public class FrmNewBornVisit : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SingleItemT<KidsNewBornVisitModel> bi;
        private SimpleBindingManager<KidsNewBornVisitModel> bindingManager;
        private ManyCheckboxs<KidsNewBornVisitModel> borninfo;
        private IContainer components;
        private SingleItemT<KidsNewBornVisitModel> erwaiguan;
        private SingleItemT<KidsNewBornVisitModel> fubuchuzhen;
        private SingleItemT<KidsNewBornVisitModel> ganmen;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private SingleItemT<KidsNewBornVisitModel> jingbubaokuai;
        private SingleItemT<KidsNewBornVisitModel> jixing;
        private SingleItemT<KidsNewBornVisitModel> jizhu;
        private SingleItemT<KidsNewBornVisitModel> kouqiang;
        private JustSingleItem<KidsNewBornVisitModel> outu;
        private SelectItemT<KidsNewBornVisitModel> qianxxx;
        private SelectItemT<KidsNewBornVisitModel> qidai;
        private SelectItemT<KidsNewBornVisitModel> renchenqi;
        private SingleItemT<KidsNewBornVisitModel> sizhihuodongdu;
        private System.Timers.Timer time_up;
        private System.Timers.Timer timer_down;
        private Dictionary<string, RadioButton> tingli;
        private SingleItemT<KidsNewBornVisitModel> waishengzhiqi;
        private SingleItemT<KidsNewBornVisitModel> xinfeitingzhen;
        private SingleItemT<KidsNewBornVisitModel> yanwaiguan;
        private ManyCheckboxs<KidsNewBornVisitModel> zhidao;
        private ManyCheckboxs<KidsNewBornVisitModel> jibingshaicha;
        private Panel panel1;
        private Panel panel21;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label17;
        private TextBox tbVisitDoctor;
        private DateTimePicker dtpNext;
        private Label label72;
        private Label label71;
        private TextBox tbNextSpace;
        private Label label70;
        private Label label69;
        private Panel panel40;
        private CheckBox ckGuides5;
        private CheckBox ckGuides4;
        private CheckBox ckGuides3;
        private CheckBox ckGuides2;
        private CheckBox ckGuides1;
        private Label label66;
        private TextBox tbZhuanzhenKs;
        private TextBox tbZhuanzhenResult;
        private Label label65;
        private Label label64;
        private Label label63;
        private Panel panel39;
        private RadioButton rdZhuanzhenHave;
        private RadioButton rdZhuanzhenNo;
        private Panel panel38;
        private ComboBox cbQid;
        private TextBox tbQid;
        private Label label62;
        private Panel panel37;
        private TextBox tbJiz;
        private RadioButton rdJiz2;
        private RadioButton rdJiz1;
        private Label label61;
        private Panel panel36;
        private TextBox tbFub;
        private RadioButton rdFub2;
        private RadioButton rdFub1;
        private Label label60;
        private Panel panel35;
        private TextBox tbWaiszq;
        private RadioButton rdWaiszq2;
        private RadioButton rdWaiszq1;
        private Label label59;
        private Panel panel34;
        private TextBox tbXinf;
        private RadioButton rdXinf2;
        private RadioButton rdXinf1;
        private Label label58;
        private Panel panel33;
        private TextBox tbGangm;
        private RadioButton rdGangm2;
        private RadioButton rdGangm1;
        private Label label57;
        private Panel panel32;
        private TextBox tbKouqEx;
        private RadioButton rdKouq2;
        private RadioButton rdKouq1;
        private Label label56;
        private Panel panel31;
        private TextBox tbSkin;
        private Label label55;
        private Panel panel30;
        private TextBox tbBiz;
        private RadioButton rdBiz2;
        private RadioButton rdBiz1;
        private Label label54;
        private Panel panel29;
        private TextBox tbJingbu;
        private RadioButton rdJingbu2;
        private RadioButton rdJingbu1;
        private Label label53;
        private Panel panel23;
        private Label label45;
        private TextBox tbBreath;
        private Panel panel27;
        private TextBox tbEr;
        private RadioButton rdEr2;
        private RadioButton rdEr1;
        private Panel panel26;
        private TextBox tbSizhi;
        private RadioButton rdSizhi2;
        private RadioButton rdSizhi1;
        private Label label47;
        private Label label48;
        private Panel panel22;
        private Label label44;
        private TextBox tbMailv;
        private Label label46;
        private Label label43;
        private Panel panel18;
        private Label label41;
        private TextBox tbShitTimes;
        private Panel panel19;
        private Button btnTemp;
        private Label label42;
        private TextBox tbTem;
        private Panel panel15;
        private Label label37;
        private TextBox tbSuckTimes;
        private Panel panel16;
        private RadioButton rdShitxi;
        private RadioButton rdShithu;
        private Panel panel14;
        private Label label24;
        private TextBox tbSuckAmount;
        private Panel panel12;
        private Label label14;
        private TextBox tbBornLength;
        private Panel panel2;
        private Button btnWeight;
        private Label label7;
        private TextBox tbNowWeight;
        private Panel panel11;
        private TextBox tbJibings;
        private Label label15;
        private Panel panel6;
        private Label label19;
        private Label label25;
        private TextBox tbMumPhone;
        private Label label26;
        private TextBox tbMumJob;
        private Label label27;
        private TextBox tbMumName;
        private Label label10;
        private Label label33;
        private Label label13;
        private TextBox tbName;
        private Label label80;
        private Label label67;
        private Label label68;
        private Label label78;
        private TextBox tbSex;
        private Label label12;
        private TextBox tbBirthday;
        private Label label9;
        private TextBox tbIDCARD;
        private TextBox tbHomeAddr;
        private Label label4;
        private Label label16;
        private Panel panel4;
        private Label label23;
        private Label label22;
        private Label label21;
        private TextBox tbDadJob;
        private Label label20;
        private TextBox tbDadName;
        private Label label3;
        private Label label32;
        private Panel panel3;
        private Label label36;
        private TextBox tbBornWeeks;
        private Panel panel7;
        private ComboBox cbMotherIllness;
        private TextBox tbMotherIll;
        private Label label30;
        private TextBox tbBornHelpUnit;
        private Label label35;
        private Label label18;
        private Panel panel8;
        private TextBox tbBornOth;
        private CheckBox ckBornInfo7;
        private CheckBox ckBornInfo6;
        private CheckBox ckBornInfo5;
        private CheckBox ckBornInfo4;
        private CheckBox ckBornInfo3;
        private CheckBox ckBornInfo2;
        private CheckBox ckBornInfo1;
        private Label label34;
        private Panel panel5;
        private Label label51;
        private Label label1;
        private RadioButton rdApneaHave;
        private RadioButton rdApneaNo;
        private TextBox tbJixEx;
        private RadioButton rdJixHave;
        private RadioButton rdJixNo;
        private Label label28;
        private Label label2;
        private Panel panel10;
        private RadioButton rdTingl4;
        private RadioButton rdTingl3;
        private RadioButton rdTingl2;
        private RadioButton rdTingl1;
        private Label label5;
        private Panel panel13;
        private Label label31;
        private TextBox tbWeight;
        private Label label6;
        private Label label8;
        private Label label11;
        private Label label29;
        private Label label38;
        private Panel panel20;
        private RadioButton rdOutuHave;
        private RadioButton rdOutuNo;
        private Label label39;
        private Label label40;
        private Panel panel17;
        private TextBox tbFaceOth;
        private Panel panel24;
        private TextBox tbQianx;
        private ComboBox cbQianX;
        private Label label50;
        private TextBox tbQianX2;
        private Label label49;
        private TextBox tbQianX1;
        private Panel panel25;
        private TextBox tbEyes;
        private RadioButton rdEye2;
        private RadioButton rdEye1;
        private DateTimePicker dtpVisit;
        private ComboBox cbFeeding;
        private Panel panel28;
        private Label lbInfo;
        private Button btnBaseInfo;
        private Button btnDown;
        private Button btnAssistCheck;
        private Button btnUp;
        private CheckBox ckjbsc1;
        private CheckBox ckjbsc6;
        private CheckBox ckjbsc5;
        private CheckBox ckjbsc4;
        private CheckBox ckjbsc3;
        private CheckBox ckjbsc2;
        private Label label74;
        private CheckBox ckjbsc7;
        private Panel panel9;
        private Panel panel41;
        private TextBox tbXiongBu;
        private RadioButton rdXb2;
        private RadioButton rdXb1;
        private Label label75;
        private TextBox tbZdqt;
        private CheckBox ckGuides6;
        private Label label76;
        private Label label77;
        private TextBox tbZhuanzhenLxr;
        private Label label79;
        private TextBox tbZhuanzhenJg;
        private TextBox tbZhuanzhenLxdh;
        private Label label81;
        private Panel panel42;
        private RadioButton rdZzjg2;
        private RadioButton rdZzjg1;
        private JustSingleItem<KidsNewBornVisitModel> zhuanzhen;
        private TextBox tbMotherID;
        private TextBox tbFatherID;
        private RadioButton rdShitqt;
        private Panel panel43;
        private CheckBox cbHd5;
        private CheckBox cbHd4;
        private CheckBox cbHd3;
        private CheckBox cbHd2;
        private CheckBox cbHd1;
        private SingleItemT<KidsNewBornVisitModel> xiongbu;
        private RadioButton rdmianse3;
        private RadioButton rdmianse2;
        private RadioButton rdmianse1;
        private Label label82;
        private PictureBox picSignJs;
        private ManyCheckboxs<KidsNewBornVisitModel> huangdan;
        private string SignS = "";
        private string SignDoc = "";//医生签名
        private LinkLabel lkJs;
        private Panel panel45;
        private ComboBox cbApgar;
        private ComboBox cbpifu;
        private TextBox tbDadPhone;
        private Panel panel46;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label52;
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public FrmNewBornVisit()
        {
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();
            this.InitEveryOne();
            this.EveryThingIsOk = false;
            this.tableLayoutPanel1.ResumeLayout();
        }

        private void btnAssistCheck_Click(object sender, EventArgs e)
        {
            this.panel21.VerticalScroll.Value = 500;
            this.panel21.VerticalScroll.Value = 500;
        }

        private void btnBaseInfo_Click(object sender, EventArgs e)
        {
            this.panel21.VerticalScroll.Value = 0;
            this.panel21.VerticalScroll.Value = 0;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.timer_down == null)
            {
                this.timer_down = new System.Timers.Timer(10.0);
                this.timer_down.Elapsed += new ElapsedEventHandler(this.timer_down_Elapsed);
            }
            this.timer_down.Start();
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.timer_down != null)
            {
                this.timer_down.Stop();
            }
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "40") {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tbTem.Text = select.m_Result.value1;
            }
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.time_up == null)
            {
                this.time_up = new System.Timers.Timer(10.0);
                this.time_up.Elapsed += new ElapsedEventHandler(this.time_up_Elapsed);
            }
            this.time_up.Start();
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.time_up != null)
            {
                this.time_up.Stop();
            }
        }

        private void btnWeight_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "22") {
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
            if (this.dtpNext.Value.Date < this.dtpVisit.Value.Date)
            {
                flag = true;
                this.SaveDataInfo = "下次随访日期不能小于当前随访日期！";
                return ChildFormStatus.HasErrorInput;
            }
            if (this.tbDadPhone.BackColor == Color.Salmon)
            {
                this.SaveDataInfo = "父亲联系电话输入有误！";
                return ChildFormStatus.HasErrorInput;
            }
            if (this.tbMumPhone.BackColor == Color.Salmon)
            {
                this.SaveDataInfo = "母亲联系电话输入有误！";
                return ChildFormStatus.HasErrorInput;
            }
            List<SingleItemT<KidsNewBornVisitModel>> source = new List<SingleItemT<KidsNewBornVisitModel>>();
            source.AddRange((IEnumerable<SingleItemT<KidsNewBornVisitModel>>) new SingleItemT<KidsNewBornVisitModel>[] { this.jixing, this.yanwaiguan, this.sizhihuodongdu, this.erwaiguan, this.jingbubaokuai, this.bi, this.kouqiang, this.ganmen, this.xinfeitingzhen, this.waishengzhiqi, this.fubuchuzhen, this.jizhu });
            List<SelectItemT<KidsNewBornVisitModel>> list2 = new List<SelectItemT<KidsNewBornVisitModel>>();
            list2.AddRange((IEnumerable<SelectItemT<KidsNewBornVisitModel>>) new SelectItemT<KidsNewBornVisitModel>[] { this.renchenqi, this.qianxxx,  this.qidai });
            if (((!this.bindingManager.ErrorInput && !this.borninfo.ErrorInput) && (!this.jibingshaicha.ErrorInput)) && ((source.Count<SingleItemT<KidsNewBornVisitModel>>(a => a.ErrorInput) + list2.Count<SelectItemT<KidsNewBornVisitModel>>(b => b.ErrorInput)) <= 0) && !flag
                )
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

        private void FrmChildInfo_Load(object sender, EventArgs e)
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

        private bool GetDateFromIDCARD(string idcard, out DateTime dt)
        {
            bool flag = false;
            dt = DateTime.Now;
            if (idcard.Length >= 15)
            {
                string str = "";
                if (idcard.Length == 15)
                {
                    string str2 = idcard.Substring(6, 6);
                    int num = DateTime.Now.Year - 0x7d0;
                    str = (int.Parse(str2.Substring(0, 2)) <= num) ? ("20" + str2) : ("19" + str2);
                }
                if (idcard.Length == 0x12)
                {
                    str = idcard.Substring(6, 8);
                }
                if ((DateTime.TryParse(str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6, 2), out dt) && (dt > DateTime.MinValue)) && (dt < DateTime.MaxValue))
                {
                    flag = true;
                }
            }
            return flag;
        }

        private void InitEveryOne()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("无", "1"),
                new ItemDictonaryModel<string>("糖尿病", "2"),
                new ItemDictonaryModel<string>("妊娠期高血压", "3"),
                new ItemDictonaryModel<string>("其他", "4")
            };
            this.cbMotherIllness.DisplayMember = "DISPLAYMEMBER";
            this.cbMotherIllness.ValueMember = "VALUEMEMBER";
            this.cbMotherIllness.DataSource = list;

            List<ItemDictonaryModel<string>> list4 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("正常", "1"),
                new ItemDictonaryModel<string>("膨隆", "2"),
                new ItemDictonaryModel<string>("凹陷", "3"),
                new ItemDictonaryModel<string>("其他", "4")
            };
            this.cbQianX.DisplayMember = "DISPLAYMEMBER";
            this.cbQianX.ValueMember = "VALUEMEMBER";
            this.cbQianX.DataSource = list4;
         
            List<ItemDictonaryModel<string>> list6 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("未脱", "1"),
                new ItemDictonaryModel<string>("脱落", "2"),
                new ItemDictonaryModel<string>("脐部有渗出", "3"),
                new ItemDictonaryModel<string>("其他", "4")
            };
            this.cbQid.DisplayMember = "DISPLAYMEMBER";
            this.cbQid.ValueMember = "VALUEMEMBER";
            this.cbQid.DataSource = list6;
            List<ItemDictonaryModel<string>> list7 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("纯母乳", "1"),
                new ItemDictonaryModel<string>("混合喂养", "2"),
                new ItemDictonaryModel<string>("人工乳", "3")
            };
            this.cbFeeding.DisplayMember = "DISPLAYMEMBER";
            this.cbFeeding.ValueMember = "VALUEMEMBER";
            this.cbFeeding.DataSource = list7;
            this.tingli = new Dictionary<string, RadioButton>();
            this.tingli.Add("1", this.rdTingl1);
            this.tingli.Add("2", this.rdTingl2);
            this.tingli.Add("3", this.rdTingl3);
            this.tingli.Add("4", this.rdTingl4);
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("HomeAddr", 200));
            this.inputrange_str.Add(new InputRangeStr("FatherName", 30));
            this.inputrange_str.Add(new InputRangeStr("FatherJob", 50));
            //this.inputrange_str.Add(new InputRangeStr("FatherTel", 15));
            this.inputrange_str.Add(new InputRangeStr("MotherName", 30));
            this.inputrange_str.Add(new InputRangeStr("MotherJob", 50));
            this.inputrange_str.Add(new InputRangeStr("MotherBirthday", 15));
            this.inputrange_str.Add(new InputRangeStr("PregnancPrevaOther", 100));
            this.inputrange_str.Add(new InputRangeStr("MidwifOrganizaName", 50));
            this.inputrange_str.Add(new InputRangeStr("BirthInformaOther", 100));
            this.inputrange_str.Add(new InputRangeStr("WhetherAbnormaHave", 100));
            this.inputrange_str.Add(new InputRangeStr("DiseaseScreenOther", 100));
            this.inputrange_str.Add(new InputRangeStr("ColourFaceOther", 100));
            this.inputrange_str.Add(new InputRangeStr("BregmaOther", 100));
            this.inputrange_str.Add(new InputRangeStr("EyeAppearanceEx", 100));
            this.inputrange_str.Add(new InputRangeStr("LimbsActivityEx", 100));
            this.inputrange_str.Add(new InputRangeStr("EarAppearanceEx", 100));
            this.inputrange_str.Add(new InputRangeStr("NeckMassHave", 100));
            this.inputrange_str.Add(new InputRangeStr("NoseEx", 100));
            this.inputrange_str.Add(new InputRangeStr("SkinOther", 100));
            this.inputrange_str.Add(new InputRangeStr("MouthCavityEx", 100));
            this.inputrange_str.Add(new InputRangeStr("AnusEx", 100));
            this.inputrange_str.Add(new InputRangeStr("HeartLungAusculEx", 100));
            this.inputrange_str.Add(new InputRangeStr("AedeaEx", 100));
            this.inputrange_str.Add(new InputRangeStr("AbdominalTouchEx", 100));
            this.inputrange_str.Add(new InputRangeStr("SpineEx", 100));
            this.inputrange_str.Add(new InputRangeStr("UmbilicalCordOther", 100));
            this.inputrange_str.Add(new InputRangeStr("ReferralReason", 500));
            this.inputrange_str.Add(new InputRangeStr("AgenciesDepartments", 80));
            this.inputrange_str.Add(new InputRangeStr("NextFollowupPlace", 100));
            this.inputrange_str.Add(new InputRangeStr("FollowUpDoctorSign", 30));
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("GestationalWeek", 100M, false));
            this.inputRanges.Add(new InputRangeDec("BirthWeight", 30M));
            this.inputRanges.Add(new InputRangeDec("BirthStature", 1000M));
            this.inputRanges.Add(new InputRangeDec("NursingQuantity", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("InfantFrequen", 100M, false));
            this.inputRanges.Add(new InputRangeDec("StoolFrequen", 100M, false));
            this.inputRanges.Add(new InputRangeDec("Temperature", 100M));
            this.inputRanges.Add(new InputRangeDec("PulseRate", 200M, false));
            this.inputRanges.Add(new InputRangeDec("BreathingRate", 100M, false));
            this.inputRanges.Add(new InputRangeDec("BregmaLeft", 20M));
            this.inputRanges.Add(new InputRangeDec("BregmaRight", 20M));
        }

        public void InitEveryThing()
        {
            Func<KeyValuePair<string, RadioButton>, bool> predicate = null;
            this.NewBornVisit = new KidsNewBornVisitBLL().GetModel(this.Model.IDCardNo);
            if (this.NewBornVisit == null)
            {
                this.NewBornVisit = new KidsNewBornVisitModel();
                this.NewBornVisit.IDCardNo = this.Model.IDCardNo;
                this.NewBornVisit.RecordID = this.Model.RecordID;
                this.NewBornVisit.Sex = this.Model.Sex;
                this.NewBornVisit.Birthday = this.Model.Birthday;
                this.NewBornVisit.CreatedBy = ConfigHelper.GetNode("doctor");
                this.NewBornVisit.CreatedDate = DateTime.Today;
            }
            else
            {
                this.NewBornVisit.LastUpdateBy = ConfigHelper.GetNode("doctor");
                this.NewBornVisit.LastUpdateDate = DateTime.Today;
            }

            KidsBaseInfoModel model = new KidsBaseInfoBLL().GetModel(this.Model.IDCardNo);

            if (string.IsNullOrEmpty(this.NewBornVisit.HomeAddr))
            {
                this.NewBornVisit.HomeAddr = this.Model.HouseHoldAddress;
            }
            if (string.IsNullOrEmpty(this.NewBornVisit.FollowUpDoctorSign))
            {
                this.NewBornVisit.FollowUpDoctorSign = ConfigHelper.GetNode("doctorName");
            }
            this.bindingManager = new SimpleBindingManager<KidsNewBornVisitModel>(this.inputRanges, this.inputrange_str, this.NewBornVisit);
            if (!this.NewBornVisit.PresentWeight.HasValue)
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                if (devData.HasValue)
                {
                    this.NewBornVisit.PresentWeight = new decimal?(decimal.Parse(devData.value1));
                }
            }
            if (!this.NewBornVisit.Temperature.HasValue)
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "40");
                if (_result2.HasValue)
                {
                    this.NewBornVisit.Temperature = new decimal?(decimal.Parse(_result2.value1));
                }
            }
            this.srcData = GlbTools.DeepCopy(this.NewBornVisit);
            this.tbName.Text = this.Model.CustomerName;
            this.tbSex.Text = (this.NewBornVisit.Sex == "1") ? "男" : "女";
            this.tbBirthday.Text = this.NewBornVisit.Birthday.Value.ToShortDateString();
            this.tbIDCARD.Text = this.NewBornVisit.IDCardNo;
            this.bindingManager.SimpleBinding(this.tbHomeAddr, "HomeAddr", false);
            this.bindingManager.SimpleBinding(this.tbDadName, "FatherName", false);
            this.bindingManager.SimpleBinding(this.tbDadJob, "FatherJob", false);
            this.bindingManager.SimpleBinding(this.tbDadPhone, "FatherTel", false);
          
            this.bindingManager.SimpleBinding(this.tbMumName, "MotherName", false);
            this.bindingManager.SimpleBinding(this.tbMumJob, "MotherJob", false);
            this.bindingManager.SimpleBinding(this.tbMumPhone, "MotherTel", false);
           
            this.bindingManager.SimpleBinding(this.tbBornWeeks, "GestationalWeek", true);
            SelectItemT<KidsNewBornVisitModel> mt = new SelectItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Name = "母亲妊娠期患病情况",
                CmbSelect = this.cbMotherIllness,
                Info = this.tbMotherIll,
                MaxBytesCount = 100
            };
            this.renchenqi = mt;
            this.renchenqi.BindProperty("PregnancPreva", "PregnancPrevaOther");
            this.bindingManager.SimpleBinding(this.tbBornHelpUnit, "MidwifOrganizaName", false);
            this.borninfo = new ManyCheckboxs<KidsNewBornVisitModel>(this.NewBornVisit);
            this.borninfo.AddCk(new CheckBox[] { this.ckBornInfo1, this.ckBornInfo2, this.ckBornInfo3, this.ckBornInfo4, this.ckBornInfo5, this.ckBornInfo6 });
            this.borninfo.AddCk(this.ckBornInfo7, this.tbBornOth);
            this.borninfo.BindingProperty("BirthInforma", "BirthInformaOther");
         
            SingleItemT<KidsNewBornVisitModel> mt2 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Name = "是否有畸形",
                Usual = this.rdJixNo,
                Unusual = this.rdJixHave,
                Info = this.tbJixEx,
                MaxBytesCount = 100
            };
            this.jixing = mt2;
            this.jixing.BindProperty("WhetherAbnorma", "WhetherAbnormaHave");
            if (!string.IsNullOrEmpty(this.NewBornVisit.HearingScreen))
            {
                try
                {
                    if (predicate == null)
                    {
                        predicate = t => t.Key == this.NewBornVisit.HearingScreen;
                    }
                    KeyValuePair<string, RadioButton> pair = this.tingli.Single<KeyValuePair<string, RadioButton>>(predicate);
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
            ManyRadionButtons<KidsNewBornVisitModel> buttons = new ManyRadionButtons<KidsNewBornVisitModel>(this.NewBornVisit) {
                tbOther = this.tbJibings,
                OthersText = "其他遗传代谢病",
                MaxBytesCount = 100
            };
           
            this.bindingManager.SimpleBinding(this.tbWeight, "BirthWeight", true);
            this.bindingManager.SimpleBinding(this.tbNowWeight, "PresentWeight", true);
            this.bindingManager.SimpleBinding(this.tbBornLength, "BirthStature", true);
            this.bindingManager.SimpleBinding(this.cbFeeding, "FeedingPattern");
            this.bindingManager.SimpleBinding(this.tbSuckAmount, "NursingQuantity", true);
            this.bindingManager.SimpleBinding(this.tbSuckTimes, "InfantFrequen", true);
            JustSingleItem<KidsNewBornVisitModel> item = new JustSingleItem<KidsNewBornVisitModel>(this.NewBornVisit) {
                R1 = this.rdOutuNo,
                R2 = this.rdOutuHave
            };
            this.outu = item;
            this.outu.BindProperty("Vomit");
            if (!string.IsNullOrEmpty(this.NewBornVisit.Stool))
            {
                if (this.NewBornVisit.Stool == "1")
                {
                    this.rdShithu.Checked = true;
                }
                else if (this.NewBornVisit.Stool == "2")
                {
                    this.rdShitxi.Checked = true;
                }
                else
                {
                    this.rdShitqt.Checked = true;
                }
            }
            else
            {
                this.rdShithu.Checked = true;
            }
            this.bindingManager.SimpleBinding(this.tbShitTimes, "StoolFrequen", true);
            this.bindingManager.SimpleBinding(this.tbTem, "Temperature", true);
            this.bindingManager.SimpleBinding(this.tbMailv, "PulseRate", true);
            this.bindingManager.SimpleBinding(this.tbBreath, "BreathingRate", true);
            this.bindingManager.SimpleBinding(this.tbQianX1, "BregmaLeft", true);
            this.bindingManager.SimpleBinding(this.tbQianX2, "BregmaRight", true);
            SelectItemT<KidsNewBornVisitModel> mt3 = new SelectItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Name = "前啥",
                CmbSelect = this.cbQianX,
                Info = this.tbQianx,
                MaxBytesCount = 100
            };
            this.qianxxx = mt3;
            this.qianxxx.BindProperty("Bregma", "BregmaOther");
            SingleItemT<KidsNewBornVisitModel> mt4 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdEye1,
                Unusual = this.rdEye2,
                Info = this.tbEyes,
                MaxBytesCount = 100
            };
            this.yanwaiguan = mt4;
            this.yanwaiguan.BindProperty("EyeAppearance", "EyeAppearanceEx");
            SingleItemT<KidsNewBornVisitModel> mt5 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdSizhi1,
                Unusual = this.rdSizhi2,
                Info = this.tbSizhi,
                MaxBytesCount = 100
            };
            this.sizhihuodongdu = mt5;
            this.sizhihuodongdu.BindProperty("LimbsActivity", "LimbsActivityEx");
            SingleItemT<KidsNewBornVisitModel> mt6 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdEr1,
                Unusual = this.rdEr2,
                Info = this.tbEr,
                MaxBytesCount = 100
            };
            this.erwaiguan = mt6;
            this.erwaiguan.BindProperty("EarAppearance", "EarAppearanceEx");
            SingleItemT<KidsNewBornVisitModel> mt7 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdJingbu1,
                Unusual = this.rdJingbu2,
                Info = this.tbJingbu,
                MaxBytesCount = 100
            };
            this.jingbubaokuai = mt7;
            this.jingbubaokuai.BindProperty("NeckMass", "NeckMassHave");
            SingleItemT<KidsNewBornVisitModel> mt8 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdBiz1,
                Unusual = this.rdBiz2,
                Info = this.tbBiz,
                MaxBytesCount = 100
            };
            this.bi = mt8;
            this.bi.BindProperty("Nose", "NoseEx");
          
            SingleItemT<KidsNewBornVisitModel> mt10 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdKouq1,
                Unusual = this.rdKouq2,
                Info = this.tbKouqEx,
                MaxBytesCount = 100
            };
            this.kouqiang = mt10;
            this.kouqiang.BindProperty("MouthCavity", "MouthCavityEx");
            SingleItemT<KidsNewBornVisitModel> mt11 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdGangm1,
                Unusual = this.rdGangm2,
                Info = this.tbGangm,
                MaxBytesCount = 100
            };
            this.ganmen = mt11;
            this.ganmen.BindProperty("Anus", "AnusEx");
            SingleItemT<KidsNewBornVisitModel> mt12 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdXinf1,
                Unusual = this.rdXinf2,
                Info = this.tbXinf,
                MaxBytesCount = 100
            };
            this.xinfeitingzhen = mt12;
            this.xinfeitingzhen.BindProperty("HeartLungAuscul", "HeartLungAusculEx");
            SingleItemT<KidsNewBornVisitModel> mt13 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdWaiszq1,
                Unusual = this.rdWaiszq2,
                Info = this.tbWaiszq,
                MaxBytesCount = 100
            };
            this.waishengzhiqi = mt13;
            this.waishengzhiqi.BindProperty("Aedea", "AedeaEx");
            SingleItemT<KidsNewBornVisitModel> mt14 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdFub1,
                Unusual = this.rdFub2,
                Info = this.tbFub,
                MaxBytesCount = 100
            };
            this.fubuchuzhen = mt14;
            this.fubuchuzhen.BindProperty("AbdominalTouch", "AbdominalTouchEx");
            SingleItemT<KidsNewBornVisitModel> mt15 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                Usual = this.rdJiz1,
                Unusual = this.rdJiz2,
                Info = this.tbJiz,
                MaxBytesCount = 100
            };
            this.jizhu = mt15;
            this.jizhu.BindProperty("Spine", "SpineEx");
            SelectItemT<KidsNewBornVisitModel> mt16 = new SelectItemT<KidsNewBornVisitModel>(this.NewBornVisit) {
                CmbSelect = this.cbQid,
                Info = this.tbQid,
                MaxBytesCount = 100
            };
            this.qidai = mt16;
            this.qidai.BindProperty("UmbilicalCord", "UmbilicalCordOther");
            JustSingleItem<KidsNewBornVisitModel> item2 = new JustSingleItem<KidsNewBornVisitModel>(this.NewBornVisit) {
                R1 = this.rdZhuanzhenNo,
                R2 = this.rdZhuanzhenHave
            };
            this.zhuanzhen = item2;
            this.zhuanzhen.statusChanged = (Action<string>) Delegate.Combine(this.zhuanzhen.statusChanged, new Action<string>(this.JustZhuanzhenChanged));
            this.zhuanzhen.BindProperty("ReferralAdvice");
            SingleItemT<KidsNewBornVisitModel> mt17 = new SingleItemT<KidsNewBornVisitModel>(this.NewBornVisit)
            {
                Usual = this.rdXb1,
                Unusual = this.rdXb2,
                Info = this.tbXiongBu,
                MaxBytesCount = 100
            };
            this.xiongbu = mt17;
            this.xiongbu.BindProperty("Chest", "ChestEx");

            this.bindingManager.SimpleBinding(this.tbZhuanzhenResult, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenKs, "AgenciesDepartments", false);
            this.zhidao = new ManyCheckboxs<KidsNewBornVisitModel>(this.NewBornVisit);
            this.zhidao.AddCk(new CheckBox[] { this.ckGuides1, this.ckGuides2, this.ckGuides3, this.ckGuides4, this.ckGuides5 });
            this.zhidao.AddCk(this.ckGuides6, this.tbZdqt);
            this.zhidao.BindingProperty("Guidance", "GuidanceOther");
            this.jibingshaicha = new ManyCheckboxs<KidsNewBornVisitModel>(this.NewBornVisit);
            this.jibingshaicha.AddCk(this.ckjbsc1, true);
            this.jibingshaicha.AddCk(new CheckBox[] {this.ckjbsc7, this.ckjbsc2, this.ckjbsc3, this.ckjbsc4, this.ckjbsc5 });
            this.jibingshaicha.AddCk(this.ckjbsc6, this.tbJibings);
            this.jibingshaicha.BindingProperty("DiseaseScreen", "DiseaseScreenOther");

            if (!string.IsNullOrEmpty(this.NewBornVisit.Skin))
            {
                this.cbpifu.SelectedIndex = int.Parse(this.NewBornVisit.Skin) - 1;
            }
            this.bindingManager.SimpleBindingInt(this.tbSkin, "SkinOther", false);
            if (!string.IsNullOrEmpty(this.NewBornVisit.Apgar))
            {
                this.cbApgar.SelectedIndex = int.Parse(this.NewBornVisit.Apgar)-1;
            }
            if (this.NewBornVisit.InterviewDate.HasValue)
            {
                this.dtpVisit.Value = this.NewBornVisit.InterviewDate.Value;
            }
            this.bindingManager.SimpleBinding(this.tbNextSpace, "NextFollowupPlace", false);
            
            if (this.NewBornVisit.NextFollowupDate.HasValue)
            {
                this.dtpNext.Value = this.NewBornVisit.NextFollowupDate.Value;
            }

            this.bindingManager.SimpleBinding(this.tbVisitDoctor, "FollowUpDoctorSign", false);

            if (!string.IsNullOrEmpty(this.NewBornVisit.Aasphyxia))
            {
                if (this.NewBornVisit.Aasphyxia == "1")
                {
                    this.rdApneaNo.Checked = true;
                }
                else
                {
                    this.rdApneaHave.Checked = true;
                }
            }
            else
            {
                this.rdApneaNo.Checked = true;
            }
            this.huangdan = new ManyCheckboxs<KidsNewBornVisitModel>(this.NewBornVisit);
            this.huangdan.AddCk(this.cbHd1,true);
            this.huangdan.AddCk(new CheckBox[] { this.cbHd2, this.cbHd3, this.cbHd4, this.cbHd5 });
            this.huangdan.BindingProperty("Jaundice","");

            this.bindingManager.SimpleBinding(this.tbZhuanzhenJg, "ReferralOrgan", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenLxr, "ReferraContacts", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenLxdh, "ReferralContactsTel", false);
            this.bindingManager.SimpleBinding(this.tbFatherID, "FatherID", false);
            this.bindingManager.SimpleBinding(this.tbMotherID, "MotherID", false);
            this.bindingManager.SimpleBindingInt(this.tbFaceOth, "ColourFaceOther", false);
            if (this.NewBornVisit.ReferralResult == "1")
            {
                this.rdZzjg1.Checked = true;
            }
            else if (this.NewBornVisit.ReferralResult == "2")
            {
                this.rdZzjg2.Checked = true;
            }
            if (this.NewBornVisit.ColourFace == "1")
            {
                this.rdmianse1.Checked = true;
            }
            else if (this.NewBornVisit.ColourFace == "2")
            {
                this.rdmianse2.Checked = true;
            }
            else if (this.NewBornVisit.ColourFace == "3")
            {
                this.rdmianse3.Checked = true;
            }

            //签名初始化
            this.SignS = string.Format("{0}{1}_NewBorn.png", this.SignPath, this.Model.IDCardNo);
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
            //签名初始化
            this.SignDoc = string.Format("{0}{1}_NewBorn_Doc.png", this.SignPath, this.Model.IDCardNo);
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

        private void IniPenSignByContrl(AxHWPenSignLib.AxHWPenSign axHWPenSign)
        {
            const UInt32 intColor = 0xC8F8DE;
            axHWPenSign.HWSetBkColor(intColor);
            axHWPenSign.HWSetCtlFrame(2, 0x000000);
            axHWPenSign.HWSetExtWndHandle(this.Handle.ToInt32());
            axHWPenSign.HWSetPenWidth(1);
        }
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel43 = new System.Windows.Forms.Panel();
            this.cbHd5 = new System.Windows.Forms.CheckBox();
            this.cbHd4 = new System.Windows.Forms.CheckBox();
            this.cbHd3 = new System.Windows.Forms.CheckBox();
            this.cbHd2 = new System.Windows.Forms.CheckBox();
            this.cbHd1 = new System.Windows.Forms.CheckBox();
            this.panel41 = new System.Windows.Forms.Panel();
            this.label75 = new System.Windows.Forms.Label();
            this.tbXiongBu = new System.Windows.Forms.TextBox();
            this.rdXb2 = new System.Windows.Forms.RadioButton();
            this.rdXb1 = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.tbNextSpace = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.tbZdqt = new System.Windows.Forms.TextBox();
            this.ckGuides6 = new System.Windows.Forms.CheckBox();
            this.ckGuides5 = new System.Windows.Forms.CheckBox();
            this.ckGuides4 = new System.Windows.Forms.CheckBox();
            this.ckGuides3 = new System.Windows.Forms.CheckBox();
            this.ckGuides2 = new System.Windows.Forms.CheckBox();
            this.ckGuides1 = new System.Windows.Forms.CheckBox();
            this.label66 = new System.Windows.Forms.Label();
            this.tbZhuanzhenResult = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.rdZhuanzhenHave = new System.Windows.Forms.RadioButton();
            this.rdZhuanzhenNo = new System.Windows.Forms.RadioButton();
            this.panel38 = new System.Windows.Forms.Panel();
            this.cbQid = new System.Windows.Forms.ComboBox();
            this.tbQid = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.tbJiz = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.rdJiz2 = new System.Windows.Forms.RadioButton();
            this.rdJiz1 = new System.Windows.Forms.RadioButton();
            this.panel36 = new System.Windows.Forms.Panel();
            this.tbFub = new System.Windows.Forms.TextBox();
            this.rdFub2 = new System.Windows.Forms.RadioButton();
            this.rdFub1 = new System.Windows.Forms.RadioButton();
            this.label60 = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.tbXinf = new System.Windows.Forms.TextBox();
            this.rdXinf2 = new System.Windows.Forms.RadioButton();
            this.rdXinf1 = new System.Windows.Forms.RadioButton();
            this.label58 = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.tbGangm = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.rdGangm2 = new System.Windows.Forms.RadioButton();
            this.rdGangm1 = new System.Windows.Forms.RadioButton();
            this.panel32 = new System.Windows.Forms.Panel();
            this.tbKouqEx = new System.Windows.Forms.TextBox();
            this.rdKouq2 = new System.Windows.Forms.RadioButton();
            this.rdKouq1 = new System.Windows.Forms.RadioButton();
            this.label56 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.cbpifu = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.tbSkin = new System.Windows.Forms.TextBox();
            this.panel30 = new System.Windows.Forms.Panel();
            this.tbBiz = new System.Windows.Forms.TextBox();
            this.rdBiz2 = new System.Windows.Forms.RadioButton();
            this.rdBiz1 = new System.Windows.Forms.RadioButton();
            this.label54 = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.tbJingbu = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.rdJingbu2 = new System.Windows.Forms.RadioButton();
            this.rdJingbu1 = new System.Windows.Forms.RadioButton();
            this.panel23 = new System.Windows.Forms.Panel();
            this.label45 = new System.Windows.Forms.Label();
            this.tbBreath = new System.Windows.Forms.TextBox();
            this.panel27 = new System.Windows.Forms.Panel();
            this.tbEr = new System.Windows.Forms.TextBox();
            this.rdEr2 = new System.Windows.Forms.RadioButton();
            this.rdEr1 = new System.Windows.Forms.RadioButton();
            this.label47 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label44 = new System.Windows.Forms.Label();
            this.tbMailv = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.tbShitTimes = new System.Windows.Forms.TextBox();
            this.panel19 = new System.Windows.Forms.Panel();
            this.btnTemp = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.tbTem = new System.Windows.Forms.TextBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.tbSuckTimes = new System.Windows.Forms.TextBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.rdShitqt = new System.Windows.Forms.RadioButton();
            this.rdShitxi = new System.Windows.Forms.RadioButton();
            this.rdShithu = new System.Windows.Forms.RadioButton();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.tbSuckAmount = new System.Windows.Forms.TextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.tbBornLength = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnWeight = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNowWeight = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.ckjbsc7 = new System.Windows.Forms.CheckBox();
            this.ckjbsc6 = new System.Windows.Forms.CheckBox();
            this.ckjbsc5 = new System.Windows.Forms.CheckBox();
            this.ckjbsc4 = new System.Windows.Forms.CheckBox();
            this.ckjbsc3 = new System.Windows.Forms.CheckBox();
            this.ckjbsc2 = new System.Windows.Forms.CheckBox();
            this.ckjbsc1 = new System.Windows.Forms.CheckBox();
            this.tbJibings = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbMotherID = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tbMumPhone = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbMumJob = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbMumName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.tbSex = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbBirthday = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbIDCARD = new System.Windows.Forms.TextBox();
            this.tbHomeAddr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbDadPhone = new System.Windows.Forms.TextBox();
            this.tbFatherID = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tbDadJob = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbDadName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.tbBornWeeks = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbMotherIllness = new System.Windows.Forms.ComboBox();
            this.tbMotherIll = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbBornHelpUnit = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbBornOth = new System.Windows.Forms.TextBox();
            this.ckBornInfo7 = new System.Windows.Forms.CheckBox();
            this.ckBornInfo6 = new System.Windows.Forms.CheckBox();
            this.ckBornInfo5 = new System.Windows.Forms.CheckBox();
            this.ckBornInfo4 = new System.Windows.Forms.CheckBox();
            this.ckBornInfo3 = new System.Windows.Forms.CheckBox();
            this.ckBornInfo2 = new System.Windows.Forms.CheckBox();
            this.ckBornInfo1 = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel45 = new System.Windows.Forms.Panel();
            this.rdJixNo = new System.Windows.Forms.RadioButton();
            this.rdJixHave = new System.Windows.Forms.RadioButton();
            this.cbApgar = new System.Windows.Forms.ComboBox();
            this.tbJixEx = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdApneaHave = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.rdApneaNo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rdTingl4 = new System.Windows.Forms.RadioButton();
            this.rdTingl3 = new System.Windows.Forms.RadioButton();
            this.rdTingl2 = new System.Windows.Forms.RadioButton();
            this.rdTingl1 = new System.Windows.Forms.RadioButton();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.rdOutuHave = new System.Windows.Forms.RadioButton();
            this.rdOutuNo = new System.Windows.Forms.RadioButton();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.rdmianse3 = new System.Windows.Forms.RadioButton();
            this.rdmianse2 = new System.Windows.Forms.RadioButton();
            this.rdmianse1 = new System.Windows.Forms.RadioButton();
            this.tbFaceOth = new System.Windows.Forms.TextBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.tbQianx = new System.Windows.Forms.TextBox();
            this.cbQianX = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.tbQianX2 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.tbQianX1 = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.tbEyes = new System.Windows.Forms.TextBox();
            this.rdEye2 = new System.Windows.Forms.RadioButton();
            this.rdEye1 = new System.Windows.Forms.RadioButton();
            this.dtpVisit = new System.Windows.Forms.DateTimePicker();
            this.cbFeeding = new System.Windows.Forms.ComboBox();
            this.panel26 = new System.Windows.Forms.Panel();
            this.tbSizhi = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.rdSizhi2 = new System.Windows.Forms.RadioButton();
            this.rdSizhi1 = new System.Windows.Forms.RadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel35 = new System.Windows.Forms.Panel();
            this.tbWaiszq = new System.Windows.Forms.TextBox();
            this.rdWaiszq2 = new System.Windows.Forms.RadioButton();
            this.rdWaiszq1 = new System.Windows.Forms.RadioButton();
            this.label65 = new System.Windows.Forms.Label();
            this.tbZhuanzhenKs = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.tbZhuanzhenLxr = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.tbZhuanzhenJg = new System.Windows.Forms.TextBox();
            this.tbZhuanzhenLxdh = new System.Windows.Forms.TextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.panel42 = new System.Windows.Forms.Panel();
            this.rdZzjg2 = new System.Windows.Forms.RadioButton();
            this.rdZzjg1 = new System.Windows.Forms.RadioButton();
            this.label35 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.label72 = new System.Windows.Forms.Label();
            this.tbVisitDoctor = new System.Windows.Forms.TextBox();
            this.panel46 = new System.Windows.Forms.Panel();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.label52 = new System.Windows.Forms.Label();
            this.lkJs = new System.Windows.Forms.LinkLabel();
            this.picSignJs = new System.Windows.Forms.PictureBox();
            this.label82 = new System.Windows.Forms.Label();
            this.panel28 = new System.Windows.Forms.Panel();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btnBaseInfo = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnAssistCheck = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel21.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel43.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panel39.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel46.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).BeginInit();
            this.panel28.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel21);
            this.panel1.Controls.Add(this.panel28);
            this.panel1.Location = new System.Drawing.Point(76, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1384, 595);
            this.panel1.TabIndex = 0;
            // 
            // panel21
            // 
            this.panel21.AutoScroll = true;
            this.panel21.BackColor = System.Drawing.Color.Transparent;
            this.panel21.Controls.Add(this.tableLayoutPanel1);
            this.panel21.Location = new System.Drawing.Point(26, 11);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(1344, 577);
            this.panel21.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.73422F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.52487F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.21765F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.97262F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.97983F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.47802F));
            this.tableLayoutPanel1.Controls.Add(this.panel43, 1, 17);
            this.tableLayoutPanel1.Controls.Add(this.panel41, 3, 23);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.label59, 0, 25);
            this.tableLayoutPanel1.Controls.Add(this.tbNextSpace, 3, 31);
            this.tableLayoutPanel1.Controls.Add(this.label70, 2, 31);
            this.tableLayoutPanel1.Controls.Add(this.label69, 0, 31);
            this.tableLayoutPanel1.Controls.Add(this.panel40, 1, 30);
            this.tableLayoutPanel1.Controls.Add(this.label66, 0, 30);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenResult, 3, 27);
            this.tableLayoutPanel1.Controls.Add(this.label64, 2, 27);
            this.tableLayoutPanel1.Controls.Add(this.label63, 0, 27);
            this.tableLayoutPanel1.Controls.Add(this.panel39, 1, 27);
            this.tableLayoutPanel1.Controls.Add(this.panel38, 1, 26);
            this.tableLayoutPanel1.Controls.Add(this.label62, 0, 26);
            this.tableLayoutPanel1.Controls.Add(this.panel37, 3, 24);
            this.tableLayoutPanel1.Controls.Add(this.panel36, 1, 24);
            this.tableLayoutPanel1.Controls.Add(this.label60, 0, 24);
            this.tableLayoutPanel1.Controls.Add(this.panel34, 1, 23);
            this.tableLayoutPanel1.Controls.Add(this.label58, 0, 23);
            this.tableLayoutPanel1.Controls.Add(this.panel33, 3, 22);
            this.tableLayoutPanel1.Controls.Add(this.panel32, 1, 22);
            this.tableLayoutPanel1.Controls.Add(this.label56, 0, 22);
            this.tableLayoutPanel1.Controls.Add(this.panel31, 3, 21);
            this.tableLayoutPanel1.Controls.Add(this.panel30, 1, 21);
            this.tableLayoutPanel1.Controls.Add(this.label54, 0, 21);
            this.tableLayoutPanel1.Controls.Add(this.panel29, 3, 20);
            this.tableLayoutPanel1.Controls.Add(this.panel23, 5, 15);
            this.tableLayoutPanel1.Controls.Add(this.panel27, 1, 20);
            this.tableLayoutPanel1.Controls.Add(this.label47, 0, 20);
            this.tableLayoutPanel1.Controls.Add(this.panel22, 3, 15);
            this.tableLayoutPanel1.Controls.Add(this.label46, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.label43, 0, 19);
            this.tableLayoutPanel1.Controls.Add(this.panel18, 5, 14);
            this.tableLayoutPanel1.Controls.Add(this.panel19, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.panel15, 5, 13);
            this.tableLayoutPanel1.Controls.Add(this.panel16, 3, 14);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 3, 13);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 5, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.label33, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label80, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label67, 2, 15);
            this.tableLayoutPanel1.Controls.Add(this.label68, 4, 15);
            this.tableLayoutPanel1.Controls.Add(this.label78, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.tbSex, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbBirthday, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbIDCARD, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbHomeAddr, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label32, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbBornHelpUnit, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel13, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 12);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.label29, 4, 13);
            this.tableLayoutPanel1.Controls.Add(this.label38, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.panel20, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.label39, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.label40, 4, 14);
            this.tableLayoutPanel1.Controls.Add(this.panel17, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.panel24, 1, 18);
            this.tableLayoutPanel1.Controls.Add(this.panel25, 1, 19);
            this.tableLayoutPanel1.Controls.Add(this.dtpVisit, 1, 31);
            this.tableLayoutPanel1.Controls.Add(this.cbFeeding, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.panel26, 3, 19);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel35, 1, 25);
            this.tableLayoutPanel1.Controls.Add(this.label65, 0, 28);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenKs, 1, 28);
            this.tableLayoutPanel1.Controls.Add(this.label76, 4, 27);
            this.tableLayoutPanel1.Controls.Add(this.label77, 2, 28);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenLxr, 3, 28);
            this.tableLayoutPanel1.Controls.Add(this.label79, 4, 28);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenJg, 5, 27);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenLxdh, 5, 28);
            this.tableLayoutPanel1.Controls.Add(this.label81, 0, 29);
            this.tableLayoutPanel1.Controls.Add(this.panel42, 1, 29);
            this.tableLayoutPanel1.Controls.Add(this.label35, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.label71, 4, 31);
            this.tableLayoutPanel1.Controls.Add(this.dtpNext, 5, 31);
            this.tableLayoutPanel1.Controls.Add(this.label72, 4, 29);
            this.tableLayoutPanel1.Controls.Add(this.tbVisitDoctor, 5, 29);
            this.tableLayoutPanel1.Controls.Add(this.panel46, 0, 32);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-3, -2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 33;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1317, 1333);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel43
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel43, 3);
            this.panel43.Controls.Add(this.cbHd5);
            this.panel43.Controls.Add(this.cbHd4);
            this.panel43.Controls.Add(this.cbHd3);
            this.panel43.Controls.Add(this.cbHd2);
            this.panel43.Controls.Add(this.cbHd1);
            this.panel43.Location = new System.Drawing.Point(181, 671);
            this.panel43.Margin = new System.Windows.Forms.Padding(0);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(546, 43);
            this.panel43.TabIndex = 251;
            // 
            // cbHd5
            // 
            this.cbHd5.AutoSize = true;
            this.cbHd5.Location = new System.Drawing.Point(350, 8);
            this.cbHd5.Name = "cbHd5";
            this.cbHd5.Size = new System.Drawing.Size(68, 24);
            this.cbHd5.TabIndex = 5;
            this.cbHd5.Text = "手足";
            this.cbHd5.UseVisualStyleBackColor = true;
            // 
            // cbHd4
            // 
            this.cbHd4.AutoSize = true;
            this.cbHd4.Location = new System.Drawing.Point(256, 8);
            this.cbHd4.Name = "cbHd4";
            this.cbHd4.Size = new System.Drawing.Size(68, 24);
            this.cbHd4.TabIndex = 4;
            this.cbHd4.Text = "四肢";
            this.cbHd4.UseVisualStyleBackColor = true;
            // 
            // cbHd3
            // 
            this.cbHd3.AutoSize = true;
            this.cbHd3.Location = new System.Drawing.Point(164, 8);
            this.cbHd3.Name = "cbHd3";
            this.cbHd3.Size = new System.Drawing.Size(68, 24);
            this.cbHd3.TabIndex = 3;
            this.cbHd3.Text = "躯干";
            this.cbHd3.UseVisualStyleBackColor = true;
            // 
            // cbHd2
            // 
            this.cbHd2.AutoSize = true;
            this.cbHd2.Location = new System.Drawing.Point(81, 8);
            this.cbHd2.Name = "cbHd2";
            this.cbHd2.Size = new System.Drawing.Size(68, 24);
            this.cbHd2.TabIndex = 2;
            this.cbHd2.Text = "面部";
            this.cbHd2.UseVisualStyleBackColor = true;
            // 
            // cbHd1
            // 
            this.cbHd1.AutoSize = true;
            this.cbHd1.Location = new System.Drawing.Point(7, 8);
            this.cbHd1.Name = "cbHd1";
            this.cbHd1.Size = new System.Drawing.Size(48, 24);
            this.cbHd1.TabIndex = 1;
            this.cbHd1.Text = "无";
            this.cbHd1.UseVisualStyleBackColor = true;
            // 
            // panel41
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel41, 3);
            this.panel41.Controls.Add(this.label75);
            this.panel41.Controls.Add(this.tbXiongBu);
            this.panel41.Controls.Add(this.rdXb2);
            this.panel41.Controls.Add(this.rdXb1);
            this.panel41.Location = new System.Drawing.Point(625, 918);
            this.panel41.Margin = new System.Windows.Forms.Padding(0);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(519, 41);
            this.panel41.TabIndex = 242;
            // 
            // label75
            // 
            this.label75.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label75.Location = new System.Drawing.Point(23, 10);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(99, 20);
            this.label75.TabIndex = 239;
            this.label75.Text = "胸    部:";
            // 
            // tbXiongBu
            // 
            this.tbXiongBu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbXiongBu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbXiongBu.ForeColor = System.Drawing.Color.Black;
            this.tbXiongBu.Location = new System.Drawing.Point(328, 5);
            this.tbXiongBu.MaxLength = 20;
            this.tbXiongBu.Multiline = true;
            this.tbXiongBu.Name = "tbXiongBu";
            this.tbXiongBu.ReadOnly = true;
            this.tbXiongBu.Size = new System.Drawing.Size(188, 31);
            this.tbXiongBu.TabIndex = 154;
            // 
            // rdXb2
            // 
            this.rdXb2.AutoSize = true;
            this.rdXb2.Location = new System.Drawing.Point(251, 5);
            this.rdXb2.Name = "rdXb2";
            this.rdXb2.Size = new System.Drawing.Size(67, 24);
            this.rdXb2.TabIndex = 153;
            this.rdXb2.TabStop = true;
            this.rdXb2.Text = "异常";
            this.rdXb2.UseVisualStyleBackColor = true;
            // 
            // rdXb1
            // 
            this.rdXb1.AutoSize = true;
            this.rdXb1.Location = new System.Drawing.Point(128, 6);
            this.rdXb1.Name = "rdXb1";
            this.rdXb1.Size = new System.Drawing.Size(107, 24);
            this.rdXb1.TabIndex = 152;
            this.rdXb1.TabStop = true;
            this.rdXb1.Text = "未见异常";
            this.rdXb1.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(533, 529);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 20);
            this.label17.TabIndex = 224;
            this.label17.Text = "*吃奶量:";
            // 
            // label59
            // 
            this.label59.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label59.Location = new System.Drawing.Point(79, 1010);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(99, 20);
            this.label59.TabIndex = 238;
            this.label59.Text = "外生殖器:";
            // 
            // tbNextSpace
            // 
            this.tbNextSpace.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNextSpace.ForeColor = System.Drawing.Color.Black;
            this.tbNextSpace.Location = new System.Drawing.Point(628, 1236);
            this.tbNextSpace.MaxLength = 20;
            this.tbNextSpace.Multiline = true;
            this.tbNextSpace.Name = "tbNextSpace";
            this.tbNextSpace.Size = new System.Drawing.Size(173, 30);
            this.tbNextSpace.TabIndex = 47;
            // 
            // label70
            // 
            this.label70.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label70.Location = new System.Drawing.Point(483, 1242);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(139, 20);
            this.label70.TabIndex = 239;
            this.label70.Text = "下次随访地点:";
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label69.Location = new System.Drawing.Point(39, 1242);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(139, 20);
            this.label69.TabIndex = 238;
            this.label69.Text = "本次随访日期:";
            // 
            // panel40
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel40, 5);
            this.panel40.Controls.Add(this.tbZdqt);
            this.panel40.Controls.Add(this.ckGuides6);
            this.panel40.Controls.Add(this.ckGuides5);
            this.panel40.Controls.Add(this.ckGuides4);
            this.panel40.Controls.Add(this.ckGuides3);
            this.panel40.Controls.Add(this.ckGuides2);
            this.panel40.Controls.Add(this.ckGuides1);
            this.panel40.Location = new System.Drawing.Point(181, 1193);
            this.panel40.Margin = new System.Windows.Forms.Padding(0);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(1085, 39);
            this.panel40.TabIndex = 45;
            // 
            // tbZdqt
            // 
            this.tbZdqt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZdqt.ForeColor = System.Drawing.Color.Black;
            this.tbZdqt.Location = new System.Drawing.Point(764, 4);
            this.tbZdqt.MaxLength = 20;
            this.tbZdqt.Multiline = true;
            this.tbZdqt.Name = "tbZdqt";
            this.tbZdqt.ReadOnly = true;
            this.tbZdqt.Size = new System.Drawing.Size(310, 26);
            this.tbZdqt.TabIndex = 161;
            // 
            // ckGuides6
            // 
            this.ckGuides6.AutoSize = true;
            this.ckGuides6.Location = new System.Drawing.Point(665, 6);
            this.ckGuides6.Name = "ckGuides6";
            this.ckGuides6.Size = new System.Drawing.Size(68, 24);
            this.ckGuides6.TabIndex = 160;
            this.ckGuides6.Text = "其他";
            this.ckGuides6.UseVisualStyleBackColor = true;
            // 
            // ckGuides5
            // 
            this.ckGuides5.AutoSize = true;
            this.ckGuides5.Location = new System.Drawing.Point(502, 6);
            this.ckGuides5.Name = "ckGuides5";
            this.ckGuides5.Size = new System.Drawing.Size(148, 24);
            this.ckGuides5.TabIndex = 159;
            this.ckGuides5.Text = "口腔保健指导";
            this.ckGuides5.UseVisualStyleBackColor = true;
            // 
            // ckGuides4
            // 
            this.ckGuides4.AutoSize = true;
            this.ckGuides4.Location = new System.Drawing.Point(349, 6);
            this.ckGuides4.Name = "ckGuides4";
            this.ckGuides4.Size = new System.Drawing.Size(148, 24);
            this.ckGuides4.TabIndex = 158;
            this.ckGuides4.Text = "预防伤害指导";
            this.ckGuides4.UseVisualStyleBackColor = true;
            // 
            // ckGuides3
            // 
            this.ckGuides3.AutoSize = true;
            this.ckGuides3.Location = new System.Drawing.Point(232, 6);
            this.ckGuides3.Name = "ckGuides3";
            this.ckGuides3.Size = new System.Drawing.Size(108, 24);
            this.ckGuides3.TabIndex = 157;
            this.ckGuides3.Text = "防病指导";
            this.ckGuides3.UseVisualStyleBackColor = true;
            // 
            // ckGuides2
            // 
            this.ckGuides2.AutoSize = true;
            this.ckGuides2.Location = new System.Drawing.Point(114, 6);
            this.ckGuides2.Name = "ckGuides2";
            this.ckGuides2.Size = new System.Drawing.Size(108, 24);
            this.ckGuides2.TabIndex = 156;
            this.ckGuides2.Text = "发育指导";
            this.ckGuides2.UseVisualStyleBackColor = true;
            // 
            // ckGuides1
            // 
            this.ckGuides1.AutoSize = true;
            this.ckGuides1.Location = new System.Drawing.Point(5, 6);
            this.ckGuides1.Name = "ckGuides1";
            this.ckGuides1.Size = new System.Drawing.Size(108, 24);
            this.ckGuides1.TabIndex = 155;
            this.ckGuides1.Text = "喂养指导";
            this.ckGuides1.UseVisualStyleBackColor = true;
            // 
            // label66
            // 
            this.label66.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.Location = new System.Drawing.Point(79, 1203);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(99, 20);
            this.label66.TabIndex = 238;
            this.label66.Text = "指    导:";
            // 
            // tbZhuanzhenResult
            // 
            this.tbZhuanzhenResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenResult.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenResult.Location = new System.Drawing.Point(628, 1083);
            this.tbZhuanzhenResult.MaxLength = 20;
            this.tbZhuanzhenResult.Multiline = true;
            this.tbZhuanzhenResult.Name = "tbZhuanzhenResult";
            this.tbZhuanzhenResult.ReadOnly = true;
            this.tbZhuanzhenResult.Size = new System.Drawing.Size(173, 31);
            this.tbZhuanzhenResult.TabIndex = 43;
            // 
            // label64
            // 
            this.label64.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label64.Location = new System.Drawing.Point(523, 1088);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(99, 20);
            this.label64.TabIndex = 238;
            this.label64.Text = "转诊原因:";
            // 
            // label63
            // 
            this.label63.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label63.Location = new System.Drawing.Point(79, 1088);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(99, 20);
            this.label63.TabIndex = 238;
            this.label63.Text = "转诊建议:";
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.rdZhuanzhenHave);
            this.panel39.Controls.Add(this.rdZhuanzhenNo);
            this.panel39.Location = new System.Drawing.Point(181, 1080);
            this.panel39.Margin = new System.Windows.Forms.Padding(0);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(179, 35);
            this.panel39.TabIndex = 42;
            // 
            // rdZhuanzhenHave
            // 
            this.rdZhuanzhenHave.AutoSize = true;
            this.rdZhuanzhenHave.Location = new System.Drawing.Point(91, 6);
            this.rdZhuanzhenHave.Name = "rdZhuanzhenHave";
            this.rdZhuanzhenHave.Size = new System.Drawing.Size(47, 24);
            this.rdZhuanzhenHave.TabIndex = 150;
            this.rdZhuanzhenHave.TabStop = true;
            this.rdZhuanzhenHave.Text = "有";
            this.rdZhuanzhenHave.UseVisualStyleBackColor = true;
            // 
            // rdZhuanzhenNo
            // 
            this.rdZhuanzhenNo.AutoSize = true;
            this.rdZhuanzhenNo.Location = new System.Drawing.Point(4, 6);
            this.rdZhuanzhenNo.Name = "rdZhuanzhenNo";
            this.rdZhuanzhenNo.Size = new System.Drawing.Size(47, 24);
            this.rdZhuanzhenNo.TabIndex = 149;
            this.rdZhuanzhenNo.TabStop = true;
            this.rdZhuanzhenNo.Text = "无";
            this.rdZhuanzhenNo.UseVisualStyleBackColor = true;
            // 
            // panel38
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel38, 4);
            this.panel38.Controls.Add(this.cbQid);
            this.panel38.Controls.Add(this.tbQid);
            this.panel38.Location = new System.Drawing.Point(181, 1041);
            this.panel38.Margin = new System.Windows.Forms.Padding(0);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(731, 39);
            this.panel38.TabIndex = 41;
            // 
            // cbQid
            // 
            this.cbQid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQid.FormattingEnabled = true;
            this.cbQid.Location = new System.Drawing.Point(4, 4);
            this.cbQid.Name = "cbQid";
            this.cbQid.Size = new System.Drawing.Size(175, 28);
            this.cbQid.TabIndex = 0;
            // 
            // tbQid
            // 
            this.tbQid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbQid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbQid.ForeColor = System.Drawing.Color.Black;
            this.tbQid.Location = new System.Drawing.Point(205, 4);
            this.tbQid.MaxLength = 20;
            this.tbQid.Multiline = true;
            this.tbQid.Name = "tbQid";
            this.tbQid.ReadOnly = true;
            this.tbQid.Size = new System.Drawing.Size(445, 32);
            this.tbQid.TabIndex = 1;
            // 
            // label62
            // 
            this.label62.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label62.Location = new System.Drawing.Point(79, 1050);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(99, 20);
            this.label62.TabIndex = 238;
            this.label62.Text = "脐    带:";
            // 
            // panel37
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel37, 3);
            this.panel37.Controls.Add(this.tbJiz);
            this.panel37.Controls.Add(this.label61);
            this.panel37.Controls.Add(this.rdJiz2);
            this.panel37.Controls.Add(this.rdJiz1);
            this.panel37.Location = new System.Drawing.Point(625, 959);
            this.panel37.Margin = new System.Windows.Forms.Padding(0);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(523, 41);
            this.panel37.TabIndex = 40;
            // 
            // tbJiz
            // 
            this.tbJiz.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbJiz.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbJiz.ForeColor = System.Drawing.Color.Black;
            this.tbJiz.Location = new System.Drawing.Point(328, 6);
            this.tbJiz.MaxLength = 20;
            this.tbJiz.Multiline = true;
            this.tbJiz.Name = "tbJiz";
            this.tbJiz.ReadOnly = true;
            this.tbJiz.Size = new System.Drawing.Size(187, 32);
            this.tbJiz.TabIndex = 154;
            // 
            // label61
            // 
            this.label61.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label61.Location = new System.Drawing.Point(23, 13);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(99, 20);
            this.label61.TabIndex = 238;
            this.label61.Text = "脊    柱:";
            // 
            // rdJiz2
            // 
            this.rdJiz2.AutoSize = true;
            this.rdJiz2.Location = new System.Drawing.Point(250, 10);
            this.rdJiz2.Name = "rdJiz2";
            this.rdJiz2.Size = new System.Drawing.Size(67, 24);
            this.rdJiz2.TabIndex = 153;
            this.rdJiz2.TabStop = true;
            this.rdJiz2.Text = "异常";
            this.rdJiz2.UseVisualStyleBackColor = true;
            // 
            // rdJiz1
            // 
            this.rdJiz1.AutoSize = true;
            this.rdJiz1.Location = new System.Drawing.Point(128, 10);
            this.rdJiz1.Name = "rdJiz1";
            this.rdJiz1.Size = new System.Drawing.Size(107, 24);
            this.rdJiz1.TabIndex = 152;
            this.rdJiz1.TabStop = true;
            this.rdJiz1.Text = "未见异常";
            this.rdJiz1.UseVisualStyleBackColor = true;
            // 
            // panel36
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel36, 2);
            this.panel36.Controls.Add(this.tbFub);
            this.panel36.Controls.Add(this.rdFub2);
            this.panel36.Controls.Add(this.rdFub1);
            this.panel36.Location = new System.Drawing.Point(181, 959);
            this.panel36.Margin = new System.Windows.Forms.Padding(0);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(444, 41);
            this.panel36.TabIndex = 39;
            // 
            // tbFub
            // 
            this.tbFub.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbFub.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFub.ForeColor = System.Drawing.Color.Black;
            this.tbFub.Location = new System.Drawing.Point(192, 4);
            this.tbFub.MaxLength = 20;
            this.tbFub.Multiline = true;
            this.tbFub.Name = "tbFub";
            this.tbFub.ReadOnly = true;
            this.tbFub.Size = new System.Drawing.Size(246, 34);
            this.tbFub.TabIndex = 154;
            // 
            // rdFub2
            // 
            this.rdFub2.AutoSize = true;
            this.rdFub2.Location = new System.Drawing.Point(120, 6);
            this.rdFub2.Name = "rdFub2";
            this.rdFub2.Size = new System.Drawing.Size(67, 24);
            this.rdFub2.TabIndex = 153;
            this.rdFub2.TabStop = true;
            this.rdFub2.Text = "异常";
            this.rdFub2.UseVisualStyleBackColor = true;
            // 
            // rdFub1
            // 
            this.rdFub1.AutoSize = true;
            this.rdFub1.Location = new System.Drawing.Point(4, 6);
            this.rdFub1.Name = "rdFub1";
            this.rdFub1.Size = new System.Drawing.Size(107, 24);
            this.rdFub1.TabIndex = 152;
            this.rdFub1.TabStop = true;
            this.rdFub1.Text = "未见异常";
            this.rdFub1.UseVisualStyleBackColor = true;
            // 
            // label60
            // 
            this.label60.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label60.Location = new System.Drawing.Point(79, 969);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(99, 20);
            this.label60.TabIndex = 239;
            this.label60.Text = "腹部触诊:";
            // 
            // panel34
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel34, 2);
            this.panel34.Controls.Add(this.tbXinf);
            this.panel34.Controls.Add(this.rdXinf2);
            this.panel34.Controls.Add(this.rdXinf1);
            this.panel34.Location = new System.Drawing.Point(181, 918);
            this.panel34.Margin = new System.Windows.Forms.Padding(0);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(444, 41);
            this.panel34.TabIndex = 37;
            // 
            // tbXinf
            // 
            this.tbXinf.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbXinf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbXinf.ForeColor = System.Drawing.Color.Black;
            this.tbXinf.Location = new System.Drawing.Point(193, 6);
            this.tbXinf.MaxLength = 20;
            this.tbXinf.Multiline = true;
            this.tbXinf.Name = "tbXinf";
            this.tbXinf.ReadOnly = true;
            this.tbXinf.Size = new System.Drawing.Size(246, 32);
            this.tbXinf.TabIndex = 154;
            // 
            // rdXinf2
            // 
            this.rdXinf2.AutoSize = true;
            this.rdXinf2.Location = new System.Drawing.Point(120, 6);
            this.rdXinf2.Name = "rdXinf2";
            this.rdXinf2.Size = new System.Drawing.Size(67, 24);
            this.rdXinf2.TabIndex = 153;
            this.rdXinf2.TabStop = true;
            this.rdXinf2.Text = "异常";
            this.rdXinf2.UseVisualStyleBackColor = true;
            // 
            // rdXinf1
            // 
            this.rdXinf1.AutoSize = true;
            this.rdXinf1.Location = new System.Drawing.Point(4, 6);
            this.rdXinf1.Name = "rdXinf1";
            this.rdXinf1.Size = new System.Drawing.Size(107, 24);
            this.rdXinf1.TabIndex = 152;
            this.rdXinf1.TabStop = true;
            this.rdXinf1.Text = "未见异常";
            this.rdXinf1.UseVisualStyleBackColor = true;
            // 
            // label58
            // 
            this.label58.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label58.Location = new System.Drawing.Point(79, 928);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(99, 20);
            this.label58.TabIndex = 238;
            this.label58.Text = "心肺听诊:";
            // 
            // panel33
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel33, 3);
            this.panel33.Controls.Add(this.tbGangm);
            this.panel33.Controls.Add(this.label57);
            this.panel33.Controls.Add(this.rdGangm2);
            this.panel33.Controls.Add(this.rdGangm1);
            this.panel33.Location = new System.Drawing.Point(625, 877);
            this.panel33.Margin = new System.Windows.Forms.Padding(0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(523, 41);
            this.panel33.TabIndex = 36;
            // 
            // tbGangm
            // 
            this.tbGangm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbGangm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGangm.ForeColor = System.Drawing.Color.Black;
            this.tbGangm.Location = new System.Drawing.Point(328, 10);
            this.tbGangm.MaxLength = 20;
            this.tbGangm.Multiline = true;
            this.tbGangm.Name = "tbGangm";
            this.tbGangm.ReadOnly = true;
            this.tbGangm.Size = new System.Drawing.Size(187, 28);
            this.tbGangm.TabIndex = 154;
            // 
            // label57
            // 
            this.label57.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.Location = new System.Drawing.Point(23, 10);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(99, 20);
            this.label57.TabIndex = 238;
            this.label57.Text = "肛    门:";
            // 
            // rdGangm2
            // 
            this.rdGangm2.AutoSize = true;
            this.rdGangm2.Location = new System.Drawing.Point(251, 6);
            this.rdGangm2.Name = "rdGangm2";
            this.rdGangm2.Size = new System.Drawing.Size(67, 24);
            this.rdGangm2.TabIndex = 153;
            this.rdGangm2.TabStop = true;
            this.rdGangm2.Text = "异常";
            this.rdGangm2.UseVisualStyleBackColor = true;
            // 
            // rdGangm1
            // 
            this.rdGangm1.AutoSize = true;
            this.rdGangm1.Location = new System.Drawing.Point(128, 6);
            this.rdGangm1.Name = "rdGangm1";
            this.rdGangm1.Size = new System.Drawing.Size(107, 24);
            this.rdGangm1.TabIndex = 152;
            this.rdGangm1.TabStop = true;
            this.rdGangm1.Text = "未见异常";
            this.rdGangm1.UseVisualStyleBackColor = true;
            // 
            // panel32
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel32, 2);
            this.panel32.Controls.Add(this.tbKouqEx);
            this.panel32.Controls.Add(this.rdKouq2);
            this.panel32.Controls.Add(this.rdKouq1);
            this.panel32.Location = new System.Drawing.Point(181, 877);
            this.panel32.Margin = new System.Windows.Forms.Padding(0);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(444, 41);
            this.panel32.TabIndex = 35;
            // 
            // tbKouqEx
            // 
            this.tbKouqEx.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbKouqEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbKouqEx.ForeColor = System.Drawing.Color.Black;
            this.tbKouqEx.Location = new System.Drawing.Point(192, 6);
            this.tbKouqEx.MaxLength = 20;
            this.tbKouqEx.Multiline = true;
            this.tbKouqEx.Name = "tbKouqEx";
            this.tbKouqEx.ReadOnly = true;
            this.tbKouqEx.Size = new System.Drawing.Size(246, 32);
            this.tbKouqEx.TabIndex = 154;
            // 
            // rdKouq2
            // 
            this.rdKouq2.AutoSize = true;
            this.rdKouq2.Location = new System.Drawing.Point(121, 6);
            this.rdKouq2.Name = "rdKouq2";
            this.rdKouq2.Size = new System.Drawing.Size(67, 24);
            this.rdKouq2.TabIndex = 153;
            this.rdKouq2.TabStop = true;
            this.rdKouq2.Text = "异常";
            this.rdKouq2.UseVisualStyleBackColor = true;
            // 
            // rdKouq1
            // 
            this.rdKouq1.AutoSize = true;
            this.rdKouq1.Location = new System.Drawing.Point(4, 6);
            this.rdKouq1.Name = "rdKouq1";
            this.rdKouq1.Size = new System.Drawing.Size(107, 24);
            this.rdKouq1.TabIndex = 152;
            this.rdKouq1.TabStop = true;
            this.rdKouq1.Text = "未见异常";
            this.rdKouq1.UseVisualStyleBackColor = true;
            // 
            // label56
            // 
            this.label56.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label56.Location = new System.Drawing.Point(79, 887);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(99, 20);
            this.label56.TabIndex = 238;
            this.label56.Text = "口    腔:";
            // 
            // panel31
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel31, 3);
            this.panel31.Controls.Add(this.cbpifu);
            this.panel31.Controls.Add(this.label55);
            this.panel31.Controls.Add(this.tbSkin);
            this.panel31.Location = new System.Drawing.Point(625, 837);
            this.panel31.Margin = new System.Windows.Forms.Padding(0);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(523, 40);
            this.panel31.TabIndex = 34;
            // 
            // cbpifu
            // 
            this.cbpifu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbpifu.FormattingEnabled = true;
            this.cbpifu.Items.AddRange(new object[] {
            "未见异常",
            "湿疹",
            "糜烂",
            "其他"});
            this.cbpifu.Location = new System.Drawing.Point(128, 7);
            this.cbpifu.Name = "cbpifu";
            this.cbpifu.Size = new System.Drawing.Size(179, 28);
            this.cbpifu.TabIndex = 6;
            this.cbpifu.SelectedIndexChanged += new System.EventHandler(this.cbpifu_SelectedIndexChanged);
            // 
            // label55
            // 
            this.label55.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.Location = new System.Drawing.Point(23, 15);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(99, 20);
            this.label55.TabIndex = 0;
            this.label55.Text = "皮    肤:";
            // 
            // tbSkin
            // 
            this.tbSkin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbSkin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSkin.ForeColor = System.Drawing.Color.Black;
            this.tbSkin.Location = new System.Drawing.Point(328, 6);
            this.tbSkin.MaxLength = 20;
            this.tbSkin.Multiline = true;
            this.tbSkin.Name = "tbSkin";
            this.tbSkin.ReadOnly = true;
            this.tbSkin.Size = new System.Drawing.Size(187, 30);
            this.tbSkin.TabIndex = 5;
            // 
            // panel30
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel30, 2);
            this.panel30.Controls.Add(this.tbBiz);
            this.panel30.Controls.Add(this.rdBiz2);
            this.panel30.Controls.Add(this.rdBiz1);
            this.panel30.Location = new System.Drawing.Point(181, 837);
            this.panel30.Margin = new System.Windows.Forms.Padding(0);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(444, 40);
            this.panel30.TabIndex = 33;
            // 
            // tbBiz
            // 
            this.tbBiz.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbBiz.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBiz.ForeColor = System.Drawing.Color.Black;
            this.tbBiz.Location = new System.Drawing.Point(192, 6);
            this.tbBiz.MaxLength = 20;
            this.tbBiz.Multiline = true;
            this.tbBiz.Name = "tbBiz";
            this.tbBiz.ReadOnly = true;
            this.tbBiz.Size = new System.Drawing.Size(246, 31);
            this.tbBiz.TabIndex = 154;
            // 
            // rdBiz2
            // 
            this.rdBiz2.AutoSize = true;
            this.rdBiz2.Location = new System.Drawing.Point(121, 6);
            this.rdBiz2.Name = "rdBiz2";
            this.rdBiz2.Size = new System.Drawing.Size(67, 24);
            this.rdBiz2.TabIndex = 153;
            this.rdBiz2.TabStop = true;
            this.rdBiz2.Text = "异常";
            this.rdBiz2.UseVisualStyleBackColor = true;
            // 
            // rdBiz1
            // 
            this.rdBiz1.AutoSize = true;
            this.rdBiz1.Location = new System.Drawing.Point(4, 6);
            this.rdBiz1.Name = "rdBiz1";
            this.rdBiz1.Size = new System.Drawing.Size(107, 24);
            this.rdBiz1.TabIndex = 152;
            this.rdBiz1.TabStop = true;
            this.rdBiz1.Text = "未见异常";
            this.rdBiz1.UseVisualStyleBackColor = true;
            // 
            // label54
            // 
            this.label54.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.Location = new System.Drawing.Point(139, 847);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(39, 20);
            this.label54.TabIndex = 238;
            this.label54.Text = "鼻:";
            // 
            // panel29
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel29, 3);
            this.panel29.Controls.Add(this.tbJingbu);
            this.panel29.Controls.Add(this.label53);
            this.panel29.Controls.Add(this.rdJingbu2);
            this.panel29.Controls.Add(this.rdJingbu1);
            this.panel29.Location = new System.Drawing.Point(625, 797);
            this.panel29.Margin = new System.Windows.Forms.Padding(0);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(524, 40);
            this.panel29.TabIndex = 32;
            // 
            // tbJingbu
            // 
            this.tbJingbu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbJingbu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbJingbu.ForeColor = System.Drawing.Color.Black;
            this.tbJingbu.Location = new System.Drawing.Point(328, 6);
            this.tbJingbu.MaxLength = 20;
            this.tbJingbu.Multiline = true;
            this.tbJingbu.Name = "tbJingbu";
            this.tbJingbu.ReadOnly = true;
            this.tbJingbu.Size = new System.Drawing.Size(187, 30);
            this.tbJingbu.TabIndex = 3;
            // 
            // label53
            // 
            this.label53.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label53.Location = new System.Drawing.Point(23, 12);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(99, 20);
            this.label53.TabIndex = 0;
            this.label53.Text = "颈部包块:";
            // 
            // rdJingbu2
            // 
            this.rdJingbu2.AutoSize = true;
            this.rdJingbu2.Location = new System.Drawing.Point(246, 6);
            this.rdJingbu2.Name = "rdJingbu2";
            this.rdJingbu2.Size = new System.Drawing.Size(67, 24);
            this.rdJingbu2.TabIndex = 2;
            this.rdJingbu2.TabStop = true;
            this.rdJingbu2.Text = "异常";
            this.rdJingbu2.UseVisualStyleBackColor = true;
            // 
            // rdJingbu1
            // 
            this.rdJingbu1.AutoSize = true;
            this.rdJingbu1.Location = new System.Drawing.Point(128, 6);
            this.rdJingbu1.Name = "rdJingbu1";
            this.rdJingbu1.Size = new System.Drawing.Size(107, 24);
            this.rdJingbu1.TabIndex = 1;
            this.rdJingbu1.TabStop = true;
            this.rdJingbu1.Text = "未见异常";
            this.rdJingbu1.UseVisualStyleBackColor = true;
            // 
            // panel23
            // 
            this.panel23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel23.Controls.Add(this.label45);
            this.panel23.Controls.Add(this.tbBreath);
            this.panel23.Location = new System.Drawing.Point(1059, 595);
            this.panel23.Margin = new System.Windows.Forms.Padding(0);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(258, 37);
            this.panel23.TabIndex = 25;
            // 
            // label45
            // 
            this.label45.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.Location = new System.Drawing.Point(121, 11);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(79, 20);
            this.label45.TabIndex = 145;
            this.label45.Text = "次/分钟";
            // 
            // tbBreath
            // 
            this.tbBreath.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbBreath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBreath.ForeColor = System.Drawing.Color.Black;
            this.tbBreath.Location = new System.Drawing.Point(9, 4);
            this.tbBreath.MaxLength = 3;
            this.tbBreath.Multiline = true;
            this.tbBreath.Name = "tbBreath";
            this.tbBreath.Size = new System.Drawing.Size(97, 30);
            this.tbBreath.TabIndex = 111;
            // 
            // panel27
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel27, 2);
            this.panel27.Controls.Add(this.tbEr);
            this.panel27.Controls.Add(this.rdEr2);
            this.panel27.Controls.Add(this.rdEr1);
            this.panel27.Location = new System.Drawing.Point(181, 797);
            this.panel27.Margin = new System.Windows.Forms.Padding(0);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(444, 40);
            this.panel27.TabIndex = 31;
            // 
            // tbEr
            // 
            this.tbEr.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbEr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbEr.ForeColor = System.Drawing.Color.Black;
            this.tbEr.Location = new System.Drawing.Point(192, 3);
            this.tbEr.MaxLength = 20;
            this.tbEr.Multiline = true;
            this.tbEr.Name = "tbEr";
            this.tbEr.ReadOnly = true;
            this.tbEr.Size = new System.Drawing.Size(246, 34);
            this.tbEr.TabIndex = 154;
            // 
            // rdEr2
            // 
            this.rdEr2.AutoSize = true;
            this.rdEr2.Location = new System.Drawing.Point(121, 6);
            this.rdEr2.Name = "rdEr2";
            this.rdEr2.Size = new System.Drawing.Size(67, 24);
            this.rdEr2.TabIndex = 153;
            this.rdEr2.TabStop = true;
            this.rdEr2.Text = "异常";
            this.rdEr2.UseVisualStyleBackColor = true;
            // 
            // rdEr1
            // 
            this.rdEr1.AutoSize = true;
            this.rdEr1.Location = new System.Drawing.Point(4, 6);
            this.rdEr1.Name = "rdEr1";
            this.rdEr1.Size = new System.Drawing.Size(107, 24);
            this.rdEr1.TabIndex = 152;
            this.rdEr1.TabStop = true;
            this.rdEr1.Text = "未见异常";
            this.rdEr1.UseVisualStyleBackColor = true;
            // 
            // label47
            // 
            this.label47.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.Location = new System.Drawing.Point(79, 807);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(99, 20);
            this.label47.TabIndex = 191;
            this.label47.Text = "耳 外 观:";
            // 
            // panel22
            // 
            this.panel22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel22.Controls.Add(this.label44);
            this.panel22.Controls.Add(this.tbMailv);
            this.panel22.Location = new System.Drawing.Point(625, 595);
            this.panel22.Margin = new System.Windows.Forms.Padding(0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(250, 37);
            this.panel22.TabIndex = 24;
            // 
            // label44
            // 
            this.label44.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.Location = new System.Drawing.Point(118, 10);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(79, 20);
            this.label44.TabIndex = 145;
            this.label44.Text = "次/分钟";
            // 
            // tbMailv
            // 
            this.tbMailv.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbMailv.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMailv.ForeColor = System.Drawing.Color.Black;
            this.tbMailv.Location = new System.Drawing.Point(9, 3);
            this.tbMailv.MaxLength = 3;
            this.tbMailv.Multiline = true;
            this.tbMailv.Name = "tbMailv";
            this.tbMailv.Size = new System.Drawing.Size(97, 30);
            this.tbMailv.TabIndex = 111;
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.Location = new System.Drawing.Point(79, 724);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(99, 20);
            this.label46.TabIndex = 190;
            this.label46.Text = "前    囟:";
            // 
            // label43
            // 
            this.label43.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(79, 765);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(99, 20);
            this.label43.TabIndex = 189;
            this.label43.Text = "眼 外 观:";
            // 
            // panel18
            // 
            this.panel18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel18.Controls.Add(this.label41);
            this.panel18.Controls.Add(this.tbShitTimes);
            this.panel18.Location = new System.Drawing.Point(1059, 557);
            this.panel18.Margin = new System.Windows.Forms.Padding(0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(258, 38);
            this.panel18.TabIndex = 22;
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(121, 6);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(59, 20);
            this.label41.TabIndex = 145;
            this.label41.Text = "次/日";
            // 
            // tbShitTimes
            // 
            this.tbShitTimes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbShitTimes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbShitTimes.ForeColor = System.Drawing.Color.Black;
            this.tbShitTimes.Location = new System.Drawing.Point(9, 6);
            this.tbShitTimes.MaxLength = 2;
            this.tbShitTimes.Multiline = true;
            this.tbShitTimes.Name = "tbShitTimes";
            this.tbShitTimes.Size = new System.Drawing.Size(97, 29);
            this.tbShitTimes.TabIndex = 111;
            // 
            // panel19
            // 
            this.panel19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel19.Controls.Add(this.btnTemp);
            this.panel19.Controls.Add(this.label42);
            this.panel19.Controls.Add(this.tbTem);
            this.panel19.Location = new System.Drawing.Point(181, 595);
            this.panel19.Margin = new System.Windows.Forms.Padding(0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(257, 37);
            this.panel19.TabIndex = 23;
            // 
            // btnTemp
            // 
            this.btnTemp.Location = new System.Drawing.Point(109, 4);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(44, 30);
            this.btnTemp.TabIndex = 148;
            this.btnTemp.Text = ".....";
            this.btnTemp.UseVisualStyleBackColor = true;
            this.btnTemp.Click += new System.EventHandler(this.btnTemp_Click);
            // 
            // label42
            // 
            this.label42.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.Location = new System.Drawing.Point(134, 10);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(29, 20);
            this.label42.TabIndex = 145;
            this.label42.Text = "℃";
            // 
            // tbTem
            // 
            this.tbTem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbTem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTem.ForeColor = System.Drawing.Color.Black;
            this.tbTem.Location = new System.Drawing.Point(-9, 3);
            this.tbTem.MaxLength = 4;
            this.tbTem.Multiline = true;
            this.tbTem.Name = "tbTem";
            this.tbTem.Size = new System.Drawing.Size(97, 31);
            this.tbTem.TabIndex = 111;
            // 
            // panel15
            // 
            this.panel15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel15.Controls.Add(this.label37);
            this.panel15.Controls.Add(this.tbSuckTimes);
            this.panel15.Location = new System.Drawing.Point(1059, 522);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(258, 35);
            this.panel15.TabIndex = 19;
            // 
            // label37
            // 
            this.label37.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(121, 6);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(59, 20);
            this.label37.TabIndex = 145;
            this.label37.Text = "次/日";
            // 
            // tbSuckTimes
            // 
            this.tbSuckTimes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbSuckTimes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSuckTimes.ForeColor = System.Drawing.Color.Black;
            this.tbSuckTimes.Location = new System.Drawing.Point(9, 1);
            this.tbSuckTimes.MaxLength = 2;
            this.tbSuckTimes.Multiline = true;
            this.tbSuckTimes.Name = "tbSuckTimes";
            this.tbSuckTimes.Size = new System.Drawing.Size(97, 30);
            this.tbSuckTimes.TabIndex = 111;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.rdShitqt);
            this.panel16.Controls.Add(this.rdShitxi);
            this.panel16.Controls.Add(this.rdShithu);
            this.panel16.Location = new System.Drawing.Point(628, 560);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(244, 32);
            this.panel16.TabIndex = 21;
            // 
            // rdShitqt
            // 
            this.rdShitqt.AutoSize = true;
            this.rdShitqt.Location = new System.Drawing.Point(171, 3);
            this.rdShitqt.Name = "rdShitqt";
            this.rdShitqt.Size = new System.Drawing.Size(67, 24);
            this.rdShitqt.TabIndex = 151;
            this.rdShitqt.TabStop = true;
            this.rdShitqt.Text = "其他";
            this.rdShitqt.UseVisualStyleBackColor = true;
            // 
            // rdShitxi
            // 
            this.rdShitxi.AutoSize = true;
            this.rdShitxi.Location = new System.Drawing.Point(101, 3);
            this.rdShitxi.Name = "rdShitxi";
            this.rdShitxi.Size = new System.Drawing.Size(47, 24);
            this.rdShitxi.TabIndex = 150;
            this.rdShitxi.TabStop = true;
            this.rdShitxi.Text = "稀";
            this.rdShitxi.UseVisualStyleBackColor = true;
            // 
            // rdShithu
            // 
            this.rdShithu.AutoSize = true;
            this.rdShithu.Location = new System.Drawing.Point(8, 3);
            this.rdShithu.Name = "rdShithu";
            this.rdShithu.Size = new System.Drawing.Size(67, 24);
            this.rdShithu.TabIndex = 149;
            this.rdShithu.TabStop = true;
            this.rdShithu.Text = "糊状";
            this.rdShithu.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            this.panel14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel14.Controls.Add(this.label24);
            this.panel14.Controls.Add(this.tbSuckAmount);
            this.panel14.Location = new System.Drawing.Point(625, 522);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(250, 35);
            this.panel14.TabIndex = 18;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(119, 8);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 20);
            this.label24.TabIndex = 145;
            this.label24.Text = "ml/次";
            // 
            // tbSuckAmount
            // 
            this.tbSuckAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbSuckAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSuckAmount.ForeColor = System.Drawing.Color.Black;
            this.tbSuckAmount.Location = new System.Drawing.Point(9, 3);
            this.tbSuckAmount.MaxLength = 3;
            this.tbSuckAmount.Multiline = true;
            this.tbSuckAmount.Name = "tbSuckAmount";
            this.tbSuckAmount.Size = new System.Drawing.Size(97, 29);
            this.tbSuckAmount.TabIndex = 111;
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.Controls.Add(this.label14);
            this.panel12.Controls.Add(this.tbBornLength);
            this.panel12.Location = new System.Drawing.Point(1059, 475);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(258, 47);
            this.panel12.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(131, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 20);
            this.label14.TabIndex = 145;
            this.label14.Text = "㎝";
            // 
            // tbBornLength
            // 
            this.tbBornLength.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbBornLength.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBornLength.ForeColor = System.Drawing.Color.Black;
            this.tbBornLength.Location = new System.Drawing.Point(9, 11);
            this.tbBornLength.MaxLength = 3;
            this.tbBornLength.Multiline = true;
            this.tbBornLength.Name = "tbBornLength";
            this.tbBornLength.Size = new System.Drawing.Size(97, 27);
            this.tbBornLength.TabIndex = 111;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnWeight);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tbNowWeight);
            this.panel2.Location = new System.Drawing.Point(625, 475);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 47);
            this.panel2.TabIndex = 15;
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(115, 9);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(44, 32);
            this.btnWeight.TabIndex = 2;
            this.btnWeight.Text = ".....";
            this.btnWeight.UseVisualStyleBackColor = true;
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(164, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "㎏";
            // 
            // tbNowWeight
            // 
            this.tbNowWeight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbNowWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNowWeight.ForeColor = System.Drawing.Color.Black;
            this.tbNowWeight.Location = new System.Drawing.Point(9, 10);
            this.tbNowWeight.MaxLength = 3;
            this.tbNowWeight.Multiline = true;
            this.tbNowWeight.Name = "tbNowWeight";
            this.tbNowWeight.Size = new System.Drawing.Size(97, 31);
            this.tbNowWeight.TabIndex = 0;
            // 
            // panel11
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel11, 5);
            this.panel11.Controls.Add(this.ckjbsc7);
            this.panel11.Controls.Add(this.ckjbsc6);
            this.panel11.Controls.Add(this.ckjbsc5);
            this.panel11.Controls.Add(this.ckjbsc4);
            this.panel11.Controls.Add(this.ckjbsc3);
            this.panel11.Controls.Add(this.ckjbsc2);
            this.panel11.Controls.Add(this.ckjbsc1);
            this.panel11.Controls.Add(this.tbJibings);
            this.panel11.Location = new System.Drawing.Point(181, 409);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.tableLayoutPanel1.SetRowSpan(this.panel11, 2);
            this.panel11.Size = new System.Drawing.Size(1120, 66);
            this.panel11.TabIndex = 13;
            // 
            // ckjbsc7
            // 
            this.ckjbsc7.AutoSize = true;
            this.ckjbsc7.Location = new System.Drawing.Point(99, 6);
            this.ckjbsc7.Name = "ckjbsc7";
            this.ckjbsc7.Size = new System.Drawing.Size(128, 24);
            this.ckjbsc7.TabIndex = 7;
            this.ckjbsc7.Text = "检查均阴性";
            this.ckjbsc7.UseVisualStyleBackColor = true;
            // 
            // ckjbsc6
            // 
            this.ckjbsc6.AutoSize = true;
            this.ckjbsc6.Location = new System.Drawing.Point(7, 41);
            this.ckjbsc6.Name = "ckjbsc6";
            this.ckjbsc6.Size = new System.Drawing.Size(148, 24);
            this.ckjbsc6.TabIndex = 5;
            this.ckjbsc6.Text = "其他遗传代谢";
            this.ckjbsc6.UseVisualStyleBackColor = true;
            // 
            // ckjbsc5
            // 
            this.ckjbsc5.AutoSize = true;
            this.ckjbsc5.Location = new System.Drawing.Point(751, 6);
            this.ckjbsc5.Name = "ckjbsc5";
            this.ckjbsc5.Size = new System.Drawing.Size(278, 24);
            this.ckjbsc5.TabIndex = 4;
            this.ckjbsc5.Text = "葡萄糖-6-磷酸脱氢酶缺乏症";
            this.ckjbsc5.UseVisualStyleBackColor = true;
            // 
            // ckjbsc4
            // 
            this.ckjbsc4.AutoSize = true;
            this.ckjbsc4.Location = new System.Drawing.Point(454, 6);
            this.ckjbsc4.Name = "ckjbsc4";
            this.ckjbsc4.Size = new System.Drawing.Size(288, 24);
            this.ckjbsc4.TabIndex = 3;
            this.ckjbsc4.Text = "先天性肾上腺皮质激素增生症";
            this.ckjbsc4.UseVisualStyleBackColor = true;
            // 
            // ckjbsc3
            // 
            this.ckjbsc3.AutoSize = true;
            this.ckjbsc3.Location = new System.Drawing.Point(321, 6);
            this.ckjbsc3.Name = "ckjbsc3";
            this.ckjbsc3.Size = new System.Drawing.Size(128, 24);
            this.ckjbsc3.TabIndex = 2;
            this.ckjbsc3.Text = "苯丙酮尿症";
            this.ckjbsc3.UseVisualStyleBackColor = true;
            // 
            // ckjbsc2
            // 
            this.ckjbsc2.AutoSize = true;
            this.ckjbsc2.Location = new System.Drawing.Point(242, 6);
            this.ckjbsc2.Name = "ckjbsc2";
            this.ckjbsc2.Size = new System.Drawing.Size(68, 24);
            this.ckjbsc2.TabIndex = 1;
            this.ckjbsc2.Text = "甲低";
            this.ckjbsc2.UseVisualStyleBackColor = true;
            // 
            // ckjbsc1
            // 
            this.ckjbsc1.AutoSize = true;
            this.ckjbsc1.Location = new System.Drawing.Point(7, 6);
            this.ckjbsc1.Name = "ckjbsc1";
            this.ckjbsc1.Size = new System.Drawing.Size(88, 24);
            this.ckjbsc1.TabIndex = 0;
            this.ckjbsc1.Text = "未进行";
            this.ckjbsc1.UseVisualStyleBackColor = true;
            // 
            // tbJibings
            // 
            this.tbJibings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbJibings.ForeColor = System.Drawing.Color.Black;
            this.tbJibings.Location = new System.Drawing.Point(164, 36);
            this.tbJibings.Multiline = true;
            this.tbJibings.Name = "tbJibings";
            this.tbJibings.ReadOnly = true;
            this.tbJibings.Size = new System.Drawing.Size(285, 27);
            this.tbJibings.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(3, 325);
            this.label15.Name = "label15";
            this.tableLayoutPanel1.SetRowSpan(this.label15, 2);
            this.label15.Size = new System.Drawing.Size(175, 20);
            this.label15.TabIndex = 146;
            this.label15.Text = "新生儿窒息:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 5);
            this.panel6.Controls.Add(this.tbMotherID);
            this.panel6.Controls.Add(this.label19);
            this.panel6.Controls.Add(this.label25);
            this.panel6.Controls.Add(this.tbMumPhone);
            this.panel6.Controls.Add(this.label26);
            this.panel6.Controls.Add(this.tbMumJob);
            this.panel6.Controls.Add(this.label27);
            this.panel6.Controls.Add(this.tbMumName);
            this.panel6.Location = new System.Drawing.Point(181, 138);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1136, 45);
            this.panel6.TabIndex = 6;
            // 
            // tbMotherID
            // 
            this.tbMotherID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMotherID.Location = new System.Drawing.Point(968, 6);
            this.tbMotherID.Name = "tbMotherID";
            this.tbMotherID.Size = new System.Drawing.Size(141, 30);
            this.tbMotherID.TabIndex = 211;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(868, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 20);
            this.label19.TabIndex = 210;
            this.label19.Text = "身份证号:";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(556, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(99, 20);
            this.label25.TabIndex = 208;
            this.label25.Text = "联系电话:";
            // 
            // tbMumPhone
            // 
            this.tbMumPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMumPhone.ForeColor = System.Drawing.Color.Black;
            this.tbMumPhone.Location = new System.Drawing.Point(664, 6);
            this.tbMumPhone.MaxLength = 15;
            this.tbMumPhone.Name = "tbMumPhone";
            this.tbMumPhone.Size = new System.Drawing.Size(160, 30);
            this.tbMumPhone.TabIndex = 207;
            this.tbMumPhone.TextChanged += new System.EventHandler(this.tbMumPhone_TextChanged);
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(293, 12);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 20);
            this.label26.TabIndex = 206;
            this.label26.Text = "职业:";
            // 
            // tbMumJob
            // 
            this.tbMumJob.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMumJob.ForeColor = System.Drawing.Color.Black;
            this.tbMumJob.Location = new System.Drawing.Point(366, 3);
            this.tbMumJob.MaxLength = 20;
            this.tbMumJob.Multiline = true;
            this.tbMumJob.Name = "tbMumJob";
            this.tbMumJob.Size = new System.Drawing.Size(159, 33);
            this.tbMumJob.TabIndex = 205;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(6, 12);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 20);
            this.label27.TabIndex = 204;
            this.label27.Text = "姓名:";
            // 
            // tbMumName
            // 
            this.tbMumName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMumName.ForeColor = System.Drawing.Color.Black;
            this.tbMumName.Location = new System.Drawing.Point(70, 2);
            this.tbMumName.MaxLength = 20;
            this.tbMumName.Multiline = true;
            this.tbMumName.Name = "tbMumName";
            this.tbMumName.Size = new System.Drawing.Size(180, 34);
            this.tbMumName.TabIndex = 200;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(79, 603);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 181;
            this.label10.Text = "体    温:";
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(19, 488);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(159, 20);
            this.label33.TabIndex = 164;
            this.label33.Text = "新生儿出生体重:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(79, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 100;
            this.label13.Text = "姓    名:";
            // 
            // tbName
            // 
            this.tbName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(184, 9);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(180, 30);
            this.tbName.TabIndex = 0;
            // 
            // label80
            // 
            this.label80.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label80.Location = new System.Drawing.Point(523, 14);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(99, 20);
            this.label80.TabIndex = 167;
            this.label80.Text = "性    别:";
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.Location = new System.Drawing.Point(523, 603);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(99, 20);
            this.label67.TabIndex = 184;
            this.label67.Text = "心    率:";
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label68.Location = new System.Drawing.Point(957, 603);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(99, 20);
            this.label68.TabIndex = 186;
            this.label68.Text = "呼吸频率:";
            // 
            // label78
            // 
            this.label78.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label78.Location = new System.Drawing.Point(79, 641);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(99, 20);
            this.label78.TabIndex = 188;
            this.label78.Text = "面    色:";
            // 
            // tbSex
            // 
            this.tbSex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbSex.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSex.ForeColor = System.Drawing.Color.Black;
            this.tbSex.Location = new System.Drawing.Point(628, 9);
            this.tbSex.MaxLength = 2;
            this.tbSex.Name = "tbSex";
            this.tbSex.ReadOnly = true;
            this.tbSex.Size = new System.Drawing.Size(173, 30);
            this.tbSex.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(957, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 193;
            this.label12.Text = "出生日期:";
            // 
            // tbBirthday
            // 
            this.tbBirthday.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbBirthday.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBirthday.ForeColor = System.Drawing.Color.Black;
            this.tbBirthday.Location = new System.Drawing.Point(1062, 9);
            this.tbBirthday.MaxLength = 30;
            this.tbBirthday.Name = "tbBirthday";
            this.tbBirthday.ReadOnly = true;
            this.tbBirthday.Size = new System.Drawing.Size(173, 30);
            this.tbBirthday.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(79, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 153;
            this.label9.Text = "身份证号:";
            // 
            // tbIDCARD
            // 
            this.tbIDCARD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbIDCARD.ForeColor = System.Drawing.Color.Black;
            this.tbIDCARD.Location = new System.Drawing.Point(184, 51);
            this.tbIDCARD.MaxLength = 18;
            this.tbIDCARD.Multiline = true;
            this.tbIDCARD.Name = "tbIDCARD";
            this.tbIDCARD.ReadOnly = true;
            this.tbIDCARD.Size = new System.Drawing.Size(178, 33);
            this.tbIDCARD.TabIndex = 3;
            // 
            // tbHomeAddr
            // 
            this.tbHomeAddr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHomeAddr.ForeColor = System.Drawing.Color.Black;
            this.tbHomeAddr.Location = new System.Drawing.Point(628, 51);
            this.tbHomeAddr.MaxLength = 20;
            this.tbHomeAddr.Multiline = true;
            this.tbHomeAddr.Name = "tbHomeAddr";
            this.tbHomeAddr.Size = new System.Drawing.Size(173, 33);
            this.tbHomeAddr.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(523, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 198;
            this.label4.Text = "家庭住址:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(79, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 199;
            this.label16.Text = "父    亲:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 5);
            this.panel4.Controls.Add(this.tbDadPhone);
            this.panel4.Controls.Add(this.tbFatherID);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.tbDadJob);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.tbDadName);
            this.panel4.Location = new System.Drawing.Point(181, 93);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1136, 45);
            this.panel4.TabIndex = 5;
            // 
            // tbDadPhone
            // 
            this.tbDadPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDadPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDadPhone.ForeColor = System.Drawing.Color.Black;
            this.tbDadPhone.Location = new System.Drawing.Point(664, 6);
            this.tbDadPhone.MaxLength = 15;
            this.tbDadPhone.Name = "tbDadPhone";
            this.tbDadPhone.Size = new System.Drawing.Size(160, 30);
            this.tbDadPhone.TabIndex = 212;
            this.tbDadPhone.TextChanged += new System.EventHandler(this.tbDadPhone_TextChanged);
            // 
            // tbFatherID
            // 
            this.tbFatherID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFatherID.Location = new System.Drawing.Point(968, 6);
            this.tbFatherID.Name = "tbFatherID";
            this.tbFatherID.Size = new System.Drawing.Size(141, 30);
            this.tbFatherID.TabIndex = 211;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(868, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 20);
            this.label23.TabIndex = 210;
            this.label23.Text = "身份证号:";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(556, 15);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 20);
            this.label22.TabIndex = 208;
            this.label22.Text = "联系电话:";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(293, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 20);
            this.label21.TabIndex = 206;
            this.label21.Text = "职业:";
            // 
            // tbDadJob
            // 
            this.tbDadJob.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDadJob.ForeColor = System.Drawing.Color.Black;
            this.tbDadJob.Location = new System.Drawing.Point(366, 4);
            this.tbDadJob.MaxLength = 20;
            this.tbDadJob.Multiline = true;
            this.tbDadJob.Name = "tbDadJob";
            this.tbDadJob.Size = new System.Drawing.Size(159, 32);
            this.tbDadJob.TabIndex = 205;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(6, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 20);
            this.label20.TabIndex = 204;
            this.label20.Text = "姓名:";
            // 
            // tbDadName
            // 
            this.tbDadName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDadName.ForeColor = System.Drawing.Color.Black;
            this.tbDadName.Location = new System.Drawing.Point(72, 3);
            this.tbDadName.MaxLength = 20;
            this.tbDadName.Multiline = true;
            this.tbDadName.Name = "tbDadName";
            this.tbDadName.Size = new System.Drawing.Size(177, 33);
            this.tbDadName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(79, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 208;
            this.label3.Text = "出生孕周:";
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(3, 255);
            this.label32.Name = "label32";
            this.tableLayoutPanel1.SetRowSpan(this.label32, 2);
            this.label32.Size = new System.Drawing.Size(175, 20);
            this.label32.TabIndex = 211;
            this.label32.Text = "助产机构名称:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label36);
            this.panel3.Controls.Add(this.tbBornWeeks);
            this.panel3.Location = new System.Drawing.Point(181, 183);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(257, 46);
            this.panel3.TabIndex = 7;
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(220, 11);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(29, 20);
            this.label36.TabIndex = 145;
            this.label36.Text = "周";
            // 
            // tbBornWeeks
            // 
            this.tbBornWeeks.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbBornWeeks.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBornWeeks.ForeColor = System.Drawing.Color.Black;
            this.tbBornWeeks.Location = new System.Drawing.Point(4, 8);
            this.tbBornWeeks.MaxLength = 2;
            this.tbBornWeeks.Multiline = true;
            this.tbBornWeeks.Name = "tbBornWeeks";
            this.tbBornWeeks.Size = new System.Drawing.Size(208, 30);
            this.tbBornWeeks.TabIndex = 111;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel7, 4);
            this.panel7.Controls.Add(this.cbMotherIllness);
            this.panel7.Controls.Add(this.tbMotherIll);
            this.panel7.Controls.Add(this.label30);
            this.panel7.Location = new System.Drawing.Point(438, 183);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(879, 46);
            this.panel7.TabIndex = 8;
            // 
            // cbMotherIllness
            // 
            this.cbMotherIllness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMotherIllness.FormattingEnabled = true;
            this.cbMotherIllness.Location = new System.Drawing.Point(220, 10);
            this.cbMotherIllness.Name = "cbMotherIllness";
            this.cbMotherIllness.Size = new System.Drawing.Size(216, 28);
            this.cbMotherIllness.TabIndex = 0;
            // 
            // tbMotherIll
            // 
            this.tbMotherIll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMotherIll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMotherIll.ForeColor = System.Drawing.Color.Black;
            this.tbMotherIll.Location = new System.Drawing.Point(443, 8);
            this.tbMotherIll.Margin = new System.Windows.Forms.Padding(0);
            this.tbMotherIll.MaxLength = 30;
            this.tbMotherIll.Name = "tbMotherIll";
            this.tbMotherIll.ReadOnly = true;
            this.tbMotherIll.Size = new System.Drawing.Size(261, 30);
            this.tbMotherIll.TabIndex = 1;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(4, 14);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(199, 20);
            this.label30.TabIndex = 210;
            this.label30.Text = "母亲妊娠期患病情况:";
            // 
            // tbBornHelpUnit
            // 
            this.tbBornHelpUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBornHelpUnit.ForeColor = System.Drawing.Color.Black;
            this.tbBornHelpUnit.Location = new System.Drawing.Point(184, 232);
            this.tbBornHelpUnit.MaxLength = 20;
            this.tbBornHelpUnit.Multiline = true;
            this.tbBornHelpUnit.Name = "tbBornHelpUnit";
            this.tableLayoutPanel1.SetRowSpan(this.tbBornHelpUnit, 2);
            this.tbBornHelpUnit.Size = new System.Drawing.Size(210, 54);
            this.tbBornHelpUnit.TabIndex = 9;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(79, 150);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 20);
            this.label18.TabIndex = 206;
            this.label18.Text = "母    亲:";
            // 
            // panel8
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel8, 4);
            this.panel8.Controls.Add(this.tbBornOth);
            this.panel8.Controls.Add(this.ckBornInfo7);
            this.panel8.Controls.Add(this.ckBornInfo6);
            this.panel8.Controls.Add(this.ckBornInfo5);
            this.panel8.Controls.Add(this.ckBornInfo4);
            this.panel8.Controls.Add(this.ckBornInfo3);
            this.panel8.Controls.Add(this.ckBornInfo2);
            this.panel8.Controls.Add(this.ckBornInfo1);
            this.panel8.Controls.Add(this.label34);
            this.panel8.Location = new System.Drawing.Point(438, 229);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.tableLayoutPanel1.SetRowSpan(this.panel8, 2);
            this.panel8.Size = new System.Drawing.Size(744, 72);
            this.panel8.TabIndex = 10;
            // 
            // tbBornOth
            // 
            this.tbBornOth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBornOth.ForeColor = System.Drawing.Color.Black;
            this.tbBornOth.Location = new System.Drawing.Point(329, 35);
            this.tbBornOth.MaxLength = 20;
            this.tbBornOth.Multiline = true;
            this.tbBornOth.Name = "tbBornOth";
            this.tbBornOth.ReadOnly = true;
            this.tbBornOth.Size = new System.Drawing.Size(375, 29);
            this.tbBornOth.TabIndex = 220;
            // 
            // ckBornInfo7
            // 
            this.ckBornInfo7.AutoSize = true;
            this.ckBornInfo7.Location = new System.Drawing.Point(204, 42);
            this.ckBornInfo7.Name = "ckBornInfo7";
            this.ckBornInfo7.Size = new System.Drawing.Size(68, 24);
            this.ckBornInfo7.TabIndex = 219;
            this.ckBornInfo7.Text = "其他";
            this.ckBornInfo7.UseVisualStyleBackColor = true;
            // 
            // ckBornInfo6
            // 
            this.ckBornInfo6.AutoSize = true;
            this.ckBornInfo6.Location = new System.Drawing.Point(109, 42);
            this.ckBornInfo6.Name = "ckBornInfo6";
            this.ckBornInfo6.Size = new System.Drawing.Size(68, 24);
            this.ckBornInfo6.TabIndex = 218;
            this.ckBornInfo6.Text = "臀位";
            this.ckBornInfo6.UseVisualStyleBackColor = true;
            // 
            // ckBornInfo5
            // 
            this.ckBornInfo5.AutoSize = true;
            this.ckBornInfo5.Location = new System.Drawing.Point(536, 5);
            this.ckBornInfo5.Name = "ckBornInfo5";
            this.ckBornInfo5.Size = new System.Drawing.Size(88, 24);
            this.ckBornInfo5.TabIndex = 217;
            this.ckBornInfo5.Text = "双多胎";
            this.ckBornInfo5.UseVisualStyleBackColor = true;
            // 
            // ckBornInfo4
            // 
            this.ckBornInfo4.AutoSize = true;
            this.ckBornInfo4.Location = new System.Drawing.Point(430, 5);
            this.ckBornInfo4.Name = "ckBornInfo4";
            this.ckBornInfo4.Size = new System.Drawing.Size(68, 24);
            this.ckBornInfo4.TabIndex = 216;
            this.ckBornInfo4.Text = "剖宫";
            this.ckBornInfo4.UseVisualStyleBackColor = true;
            // 
            // ckBornInfo3
            // 
            this.ckBornInfo3.AutoSize = true;
            this.ckBornInfo3.Location = new System.Drawing.Point(329, 5);
            this.ckBornInfo3.Name = "ckBornInfo3";
            this.ckBornInfo3.Size = new System.Drawing.Size(68, 24);
            this.ckBornInfo3.TabIndex = 215;
            this.ckBornInfo3.Text = "产钳";
            this.ckBornInfo3.UseVisualStyleBackColor = true;
            // 
            // ckBornInfo2
            // 
            this.ckBornInfo2.AutoSize = true;
            this.ckBornInfo2.Location = new System.Drawing.Point(204, 5);
            this.ckBornInfo2.Name = "ckBornInfo2";
            this.ckBornInfo2.Size = new System.Drawing.Size(108, 24);
            this.ckBornInfo2.TabIndex = 214;
            this.ckBornInfo2.Text = "胎头吸引";
            this.ckBornInfo2.UseVisualStyleBackColor = true;
            // 
            // ckBornInfo1
            // 
            this.ckBornInfo1.AutoSize = true;
            this.ckBornInfo1.Location = new System.Drawing.Point(109, 5);
            this.ckBornInfo1.Name = "ckBornInfo1";
            this.ckBornInfo1.Size = new System.Drawing.Size(68, 24);
            this.ckBornInfo1.TabIndex = 213;
            this.ckBornInfo1.Text = "顺产";
            this.ckBornInfo1.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(6, 12);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(99, 20);
            this.label34.TabIndex = 212;
            this.label34.Text = "出生情况:";
            // 
            // panel5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel5, 5);
            this.panel5.Controls.Add(this.panel45);
            this.panel5.Controls.Add(this.cbApgar);
            this.panel5.Controls.Add(this.tbJixEx);
            this.panel5.Controls.Add(this.label51);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.rdApneaHave);
            this.panel5.Controls.Add(this.label28);
            this.panel5.Controls.Add(this.rdApneaNo);
            this.panel5.Location = new System.Drawing.Point(181, 301);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.tableLayoutPanel1.SetRowSpan(this.panel5, 2);
            this.panel5.Size = new System.Drawing.Size(962, 60);
            this.panel5.TabIndex = 11;
            // 
            // panel45
            // 
            this.panel45.Controls.Add(this.rdJixNo);
            this.panel45.Controls.Add(this.rdJixHave);
            this.panel45.Location = new System.Drawing.Point(657, 13);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(151, 35);
            this.panel45.TabIndex = 10;
            // 
            // rdJixNo
            // 
            this.rdJixNo.AutoSize = true;
            this.rdJixNo.Location = new System.Drawing.Point(7, 6);
            this.rdJixNo.Name = "rdJixNo";
            this.rdJixNo.Size = new System.Drawing.Size(47, 24);
            this.rdJixNo.TabIndex = 6;
            this.rdJixNo.TabStop = true;
            this.rdJixNo.Text = "无";
            this.rdJixNo.UseVisualStyleBackColor = true;
            // 
            // rdJixHave
            // 
            this.rdJixHave.AutoSize = true;
            this.rdJixHave.Location = new System.Drawing.Point(81, 6);
            this.rdJixHave.Name = "rdJixHave";
            this.rdJixHave.Size = new System.Drawing.Size(47, 24);
            this.rdJixHave.TabIndex = 7;
            this.rdJixHave.TabStop = true;
            this.rdJixHave.Text = "有";
            this.rdJixHave.UseVisualStyleBackColor = true;
            // 
            // cbApgar
            // 
            this.cbApgar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApgar.FormattingEnabled = true;
            this.cbApgar.Items.AddRange(new object[] {
            "1min",
            "5min",
            "不详"});
            this.cbApgar.Location = new System.Drawing.Point(258, 17);
            this.cbApgar.Name = "cbApgar";
            this.cbApgar.Size = new System.Drawing.Size(123, 28);
            this.cbApgar.TabIndex = 9;
            // 
            // tbJixEx
            // 
            this.tbJixEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbJixEx.ForeColor = System.Drawing.Color.Black;
            this.tbJixEx.Location = new System.Drawing.Point(812, 14);
            this.tbJixEx.MaxLength = 20;
            this.tbJixEx.Multiline = true;
            this.tbJixEx.Name = "tbJixEx";
            this.tbJixEx.ReadOnly = true;
            this.tbJixEx.Size = new System.Drawing.Size(124, 31);
            this.tbJixEx.TabIndex = 8;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(387, 21);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(19, 20);
            this.label51.TabIndex = 4;
            this.label51.Text = ")";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "(Apgar评分:";
            // 
            // rdApneaHave
            // 
            this.rdApneaHave.AutoSize = true;
            this.rdApneaHave.Location = new System.Drawing.Point(71, 18);
            this.rdApneaHave.Name = "rdApneaHave";
            this.rdApneaHave.Size = new System.Drawing.Size(47, 24);
            this.rdApneaHave.TabIndex = 1;
            this.rdApneaHave.TabStop = true;
            this.rdApneaHave.Text = "有";
            this.rdApneaHave.UseVisualStyleBackColor = true;
            this.rdApneaHave.CheckedChanged += new System.EventHandler(this.rdApneaHave_CheckedChanged);
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(542, 21);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(119, 20);
            this.label28.TabIndex = 5;
            this.label28.Text = "是否有畸形:";
            // 
            // rdApneaNo
            // 
            this.rdApneaNo.AutoSize = true;
            this.rdApneaNo.Location = new System.Drawing.Point(7, 18);
            this.rdApneaNo.Name = "rdApneaNo";
            this.rdApneaNo.Size = new System.Drawing.Size(47, 24);
            this.rdApneaNo.TabIndex = 0;
            this.rdApneaNo.TabStop = true;
            this.rdApneaNo.Text = "无";
            this.rdApneaNo.UseVisualStyleBackColor = true;
            this.rdApneaNo.CheckedChanged += new System.EventHandler(this.rdApneaNo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 219;
            this.label2.Text = "新生儿听力筛查:";
            // 
            // panel10
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel10, 5);
            this.panel10.Controls.Add(this.rdTingl4);
            this.panel10.Controls.Add(this.rdTingl3);
            this.panel10.Controls.Add(this.rdTingl2);
            this.panel10.Controls.Add(this.rdTingl1);
            this.panel10.Location = new System.Drawing.Point(181, 369);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(882, 40);
            this.panel10.TabIndex = 12;
            // 
            // rdTingl4
            // 
            this.rdTingl4.AutoSize = true;
            this.rdTingl4.Location = new System.Drawing.Point(290, 6);
            this.rdTingl4.Name = "rdTingl4";
            this.rdTingl4.Size = new System.Drawing.Size(67, 24);
            this.rdTingl4.TabIndex = 217;
            this.rdTingl4.TabStop = true;
            this.rdTingl4.Text = "不详";
            this.rdTingl4.UseVisualStyleBackColor = true;
            // 
            // rdTingl3
            // 
            this.rdTingl3.AutoSize = true;
            this.rdTingl3.Location = new System.Drawing.Point(191, 6);
            this.rdTingl3.Name = "rdTingl3";
            this.rdTingl3.Size = new System.Drawing.Size(87, 24);
            this.rdTingl3.TabIndex = 216;
            this.rdTingl3.TabStop = true;
            this.rdTingl3.Text = "未筛查";
            this.rdTingl3.UseVisualStyleBackColor = true;
            // 
            // rdTingl2
            // 
            this.rdTingl2.AutoSize = true;
            this.rdTingl2.Location = new System.Drawing.Point(92, 6);
            this.rdTingl2.Name = "rdTingl2";
            this.rdTingl2.Size = new System.Drawing.Size(87, 24);
            this.rdTingl2.TabIndex = 215;
            this.rdTingl2.TabStop = true;
            this.rdTingl2.Text = "未通过";
            this.rdTingl2.UseVisualStyleBackColor = true;
            // 
            // rdTingl1
            // 
            this.rdTingl1.AutoSize = true;
            this.rdTingl1.Location = new System.Drawing.Point(7, 6);
            this.rdTingl1.Name = "rdTingl1";
            this.rdTingl1.Size = new System.Drawing.Size(67, 24);
            this.rdTingl1.TabIndex = 214;
            this.rdTingl1.TabStop = true;
            this.rdTingl1.Text = "通过";
            this.rdTingl1.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.Controls.Add(this.label31);
            this.panel13.Controls.Add(this.tbWeight);
            this.panel13.Location = new System.Drawing.Point(181, 475);
            this.panel13.Margin = new System.Windows.Forms.Padding(0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(257, 47);
            this.panel13.TabIndex = 14;
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(177, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 20);
            this.label31.TabIndex = 145;
            this.label31.Text = "㎏";
            // 
            // tbWeight
            // 
            this.tbWeight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWeight.ForeColor = System.Drawing.Color.Black;
            this.tbWeight.Location = new System.Drawing.Point(2, 10);
            this.tbWeight.MaxLength = 3;
            this.tbWeight.Multiline = true;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(173, 31);
            this.tbWeight.TabIndex = 111;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(523, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 223;
            this.label6.Text = "目前体重:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(957, 488);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 224;
            this.label8.Text = "出生身长:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(79, 529);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 147;
            this.label11.Text = "喂养方式:";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(947, 529);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(109, 20);
            this.label29.TabIndex = 225;
            this.label29.Text = "*吃奶次数:";
            // 
            // label38
            // 
            this.label38.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(109, 566);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(69, 20);
            this.label38.TabIndex = 226;
            this.label38.Text = "*呕吐:";
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.rdOutuHave);
            this.panel20.Controls.Add(this.rdOutuNo);
            this.panel20.Location = new System.Drawing.Point(184, 560);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(173, 32);
            this.panel20.TabIndex = 20;
            // 
            // rdOutuHave
            // 
            this.rdOutuHave.AutoSize = true;
            this.rdOutuHave.Location = new System.Drawing.Point(103, 3);
            this.rdOutuHave.Name = "rdOutuHave";
            this.rdOutuHave.Size = new System.Drawing.Size(47, 24);
            this.rdOutuHave.TabIndex = 150;
            this.rdOutuHave.TabStop = true;
            this.rdOutuHave.Text = "有";
            this.rdOutuHave.UseVisualStyleBackColor = true;
            // 
            // rdOutuNo
            // 
            this.rdOutuNo.AutoSize = true;
            this.rdOutuNo.Location = new System.Drawing.Point(4, 3);
            this.rdOutuNo.Name = "rdOutuNo";
            this.rdOutuNo.Size = new System.Drawing.Size(47, 24);
            this.rdOutuNo.TabIndex = 149;
            this.rdOutuNo.TabStop = true;
            this.rdOutuNo.Text = "无";
            this.rdOutuNo.UseVisualStyleBackColor = true;
            // 
            // label39
            // 
            this.label39.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(553, 566);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(69, 20);
            this.label39.TabIndex = 227;
            this.label39.Text = "*大便:";
            // 
            // label40
            // 
            this.label40.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(947, 566);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(109, 20);
            this.label40.TabIndex = 228;
            this.label40.Text = "*大便次数:";
            // 
            // panel17
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel17, 3);
            this.panel17.Controls.Add(this.rdmianse3);
            this.panel17.Controls.Add(this.rdmianse2);
            this.panel17.Controls.Add(this.rdmianse1);
            this.panel17.Controls.Add(this.tbFaceOth);
            this.panel17.Location = new System.Drawing.Point(181, 632);
            this.panel17.Margin = new System.Windows.Forms.Padding(0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(546, 39);
            this.panel17.TabIndex = 26;
            // 
            // rdmianse3
            // 
            this.rdmianse3.AutoSize = true;
            this.rdmianse3.Location = new System.Drawing.Point(164, 5);
            this.rdmianse3.Name = "rdmianse3";
            this.rdmianse3.Size = new System.Drawing.Size(67, 24);
            this.rdmianse3.TabIndex = 7;
            this.rdmianse3.TabStop = true;
            this.rdmianse3.Text = "其他";
            this.rdmianse3.UseVisualStyleBackColor = true;
            this.rdmianse3.CheckedChanged += new System.EventHandler(this.rdmianse3_CheckedChanged);
            // 
            // rdmianse2
            // 
            this.rdmianse2.AutoSize = true;
            this.rdmianse2.Location = new System.Drawing.Point(81, 5);
            this.rdmianse2.Name = "rdmianse2";
            this.rdmianse2.Size = new System.Drawing.Size(67, 24);
            this.rdmianse2.TabIndex = 6;
            this.rdmianse2.TabStop = true;
            this.rdmianse2.Text = "黄染";
            this.rdmianse2.UseVisualStyleBackColor = true;
            // 
            // rdmianse1
            // 
            this.rdmianse1.AutoSize = true;
            this.rdmianse1.Location = new System.Drawing.Point(5, 5);
            this.rdmianse1.Name = "rdmianse1";
            this.rdmianse1.Size = new System.Drawing.Size(67, 24);
            this.rdmianse1.TabIndex = 5;
            this.rdmianse1.TabStop = true;
            this.rdmianse1.Text = "红润";
            this.rdmianse1.UseVisualStyleBackColor = true;
            // 
            // tbFaceOth
            // 
            this.tbFaceOth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFaceOth.ForeColor = System.Drawing.Color.Black;
            this.tbFaceOth.Location = new System.Drawing.Point(283, 3);
            this.tbFaceOth.MaxLength = 20;
            this.tbFaceOth.Multiline = true;
            this.tbFaceOth.Name = "tbFaceOth";
            this.tbFaceOth.ReadOnly = true;
            this.tbFaceOth.Size = new System.Drawing.Size(253, 33);
            this.tbFaceOth.TabIndex = 4;
            // 
            // panel24
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel24, 5);
            this.panel24.Controls.Add(this.tbQianx);
            this.panel24.Controls.Add(this.cbQianX);
            this.panel24.Controls.Add(this.label50);
            this.panel24.Controls.Add(this.tbQianX2);
            this.panel24.Controls.Add(this.label49);
            this.panel24.Controls.Add(this.tbQianX1);
            this.panel24.Controls.Add(this.label74);
            this.panel24.Location = new System.Drawing.Point(181, 714);
            this.panel24.Margin = new System.Windows.Forms.Padding(0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(906, 40);
            this.panel24.TabIndex = 28;
            // 
            // tbQianx
            // 
            this.tbQianx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbQianx.ForeColor = System.Drawing.Color.Black;
            this.tbQianx.Location = new System.Drawing.Point(672, 3);
            this.tbQianx.Multiline = true;
            this.tbQianx.Name = "tbQianx";
            this.tbQianx.ReadOnly = true;
            this.tbQianx.Size = new System.Drawing.Size(221, 31);
            this.tbQianx.TabIndex = 6;
            // 
            // cbQianX
            // 
            this.cbQianX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQianX.FormattingEnabled = true;
            this.cbQianX.Location = new System.Drawing.Point(486, 5);
            this.cbQianX.Name = "cbQianX";
            this.cbQianX.Size = new System.Drawing.Size(175, 28);
            this.cbQianX.TabIndex = 5;
            // 
            // label50
            // 
            this.label50.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.Location = new System.Drawing.Point(299, 10);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(29, 20);
            this.label50.TabIndex = 3;
            this.label50.Text = "㎝";
            // 
            // tbQianX2
            // 
            this.tbQianX2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbQianX2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbQianX2.ForeColor = System.Drawing.Color.Black;
            this.tbQianX2.Location = new System.Drawing.Point(199, 3);
            this.tbQianX2.MaxLength = 2;
            this.tbQianX2.Multiline = true;
            this.tbQianX2.Name = "tbQianX2";
            this.tbQianX2.Size = new System.Drawing.Size(97, 31);
            this.tbQianX2.TabIndex = 2;
            // 
            // label49
            // 
            this.label49.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label49.Location = new System.Drawing.Point(115, 9);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(49, 20);
            this.label49.TabIndex = 1;
            this.label49.Text = "㎝ x";
            // 
            // tbQianX1
            // 
            this.tbQianX1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbQianX1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbQianX1.ForeColor = System.Drawing.Color.Black;
            this.tbQianX1.Location = new System.Drawing.Point(17, 3);
            this.tbQianX1.MaxLength = 2;
            this.tbQianX1.Multiline = true;
            this.tbQianX1.Name = "tbQianX1";
            this.tbQianX1.Size = new System.Drawing.Size(97, 31);
            this.tbQianX1.TabIndex = 0;
            // 
            // label74
            // 
            this.label74.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label74.Location = new System.Drawing.Point(380, 10);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(99, 20);
            this.label74.TabIndex = 4;
            this.label74.Text = "前囟状况:";
            // 
            // panel25
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel25, 2);
            this.panel25.Controls.Add(this.tbEyes);
            this.panel25.Controls.Add(this.rdEye2);
            this.panel25.Controls.Add(this.rdEye1);
            this.panel25.Location = new System.Drawing.Point(181, 754);
            this.panel25.Margin = new System.Windows.Forms.Padding(0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(444, 43);
            this.panel25.TabIndex = 29;
            // 
            // tbEyes
            // 
            this.tbEyes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbEyes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbEyes.ForeColor = System.Drawing.Color.Black;
            this.tbEyes.Location = new System.Drawing.Point(194, 6);
            this.tbEyes.MaxLength = 20;
            this.tbEyes.Multiline = true;
            this.tbEyes.Name = "tbEyes";
            this.tbEyes.ReadOnly = true;
            this.tbEyes.Size = new System.Drawing.Size(243, 34);
            this.tbEyes.TabIndex = 154;
            // 
            // rdEye2
            // 
            this.rdEye2.AutoSize = true;
            this.rdEye2.Location = new System.Drawing.Point(121, 6);
            this.rdEye2.Name = "rdEye2";
            this.rdEye2.Size = new System.Drawing.Size(67, 24);
            this.rdEye2.TabIndex = 153;
            this.rdEye2.TabStop = true;
            this.rdEye2.Text = "异常";
            this.rdEye2.UseVisualStyleBackColor = true;
            // 
            // rdEye1
            // 
            this.rdEye1.AutoSize = true;
            this.rdEye1.Location = new System.Drawing.Point(4, 6);
            this.rdEye1.Name = "rdEye1";
            this.rdEye1.Size = new System.Drawing.Size(107, 24);
            this.rdEye1.TabIndex = 152;
            this.rdEye1.TabStop = true;
            this.rdEye1.Text = "未见异常";
            this.rdEye1.UseVisualStyleBackColor = true;
            // 
            // dtpVisit
            // 
            this.dtpVisit.Location = new System.Drawing.Point(184, 1236);
            this.dtpVisit.Name = "dtpVisit";
            this.dtpVisit.Size = new System.Drawing.Size(180, 30);
            this.dtpVisit.TabIndex = 46;
            // 
            // cbFeeding
            // 
            this.cbFeeding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFeeding.FormattingEnabled = true;
            this.cbFeeding.Location = new System.Drawing.Point(184, 525);
            this.cbFeeding.Name = "cbFeeding";
            this.cbFeeding.Size = new System.Drawing.Size(173, 28);
            this.cbFeeding.TabIndex = 17;
            // 
            // panel26
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel26, 3);
            this.panel26.Controls.Add(this.tbSizhi);
            this.panel26.Controls.Add(this.label48);
            this.panel26.Controls.Add(this.rdSizhi2);
            this.panel26.Controls.Add(this.rdSizhi1);
            this.panel26.Location = new System.Drawing.Point(625, 754);
            this.panel26.Margin = new System.Windows.Forms.Padding(0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(523, 43);
            this.panel26.TabIndex = 30;
            // 
            // tbSizhi
            // 
            this.tbSizhi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbSizhi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSizhi.ForeColor = System.Drawing.Color.Black;
            this.tbSizhi.Location = new System.Drawing.Point(328, 6);
            this.tbSizhi.MaxLength = 20;
            this.tbSizhi.Multiline = true;
            this.tbSizhi.Name = "tbSizhi";
            this.tbSizhi.ReadOnly = true;
            this.tbSizhi.Size = new System.Drawing.Size(187, 34);
            this.tbSizhi.TabIndex = 3;
            // 
            // label48
            // 
            this.label48.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label48.Location = new System.Drawing.Point(9, 10);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(119, 20);
            this.label48.TabIndex = 0;
            this.label48.Text = "四肢活动度:";
            // 
            // rdSizhi2
            // 
            this.rdSizhi2.AutoSize = true;
            this.rdSizhi2.Location = new System.Drawing.Point(246, 6);
            this.rdSizhi2.Name = "rdSizhi2";
            this.rdSizhi2.Size = new System.Drawing.Size(67, 24);
            this.rdSizhi2.TabIndex = 2;
            this.rdSizhi2.TabStop = true;
            this.rdSizhi2.Text = "异常";
            this.rdSizhi2.UseVisualStyleBackColor = true;
            // 
            // rdSizhi1
            // 
            this.rdSizhi1.AutoSize = true;
            this.rdSizhi1.Location = new System.Drawing.Point(128, 6);
            this.rdSizhi1.Name = "rdSizhi1";
            this.rdSizhi1.Size = new System.Drawing.Size(107, 24);
            this.rdSizhi1.TabIndex = 1;
            this.rdSizhi1.TabStop = true;
            this.rdSizhi1.Text = "未见异常";
            this.rdSizhi1.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.label5);
            this.panel9.Location = new System.Drawing.Point(3, 412);
            this.panel9.Name = "panel9";
            this.tableLayoutPanel1.SetRowSpan(this.panel9, 2);
            this.panel9.Size = new System.Drawing.Size(175, 60);
            this.panel9.TabIndex = 241;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 221;
            this.label5.Text = "新生儿疾病筛查:";
            // 
            // panel35
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel35, 3);
            this.panel35.Controls.Add(this.tbWaiszq);
            this.panel35.Controls.Add(this.rdWaiszq2);
            this.panel35.Controls.Add(this.rdWaiszq1);
            this.panel35.Location = new System.Drawing.Point(181, 1000);
            this.panel35.Margin = new System.Windows.Forms.Padding(0);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(694, 41);
            this.panel35.TabIndex = 38;
            // 
            // tbWaiszq
            // 
            this.tbWaiszq.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbWaiszq.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWaiszq.ForeColor = System.Drawing.Color.Black;
            this.tbWaiszq.Location = new System.Drawing.Point(198, 5);
            this.tbWaiszq.MaxLength = 20;
            this.tbWaiszq.Multiline = true;
            this.tbWaiszq.Name = "tbWaiszq";
            this.tbWaiszq.ReadOnly = true;
            this.tbWaiszq.Size = new System.Drawing.Size(444, 34);
            this.tbWaiszq.TabIndex = 154;
            // 
            // rdWaiszq2
            // 
            this.rdWaiszq2.AutoSize = true;
            this.rdWaiszq2.Location = new System.Drawing.Point(120, 5);
            this.rdWaiszq2.Name = "rdWaiszq2";
            this.rdWaiszq2.Size = new System.Drawing.Size(67, 24);
            this.rdWaiszq2.TabIndex = 153;
            this.rdWaiszq2.TabStop = true;
            this.rdWaiszq2.Text = "异常";
            this.rdWaiszq2.UseVisualStyleBackColor = true;
            // 
            // rdWaiszq1
            // 
            this.rdWaiszq1.AutoSize = true;
            this.rdWaiszq1.Location = new System.Drawing.Point(5, 5);
            this.rdWaiszq1.Name = "rdWaiszq1";
            this.rdWaiszq1.Size = new System.Drawing.Size(107, 24);
            this.rdWaiszq1.TabIndex = 152;
            this.rdWaiszq1.TabStop = true;
            this.rdWaiszq1.Text = "未见异常";
            this.rdWaiszq1.UseVisualStyleBackColor = true;
            // 
            // label65
            // 
            this.label65.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label65.Location = new System.Drawing.Point(79, 1126);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(99, 20);
            this.label65.TabIndex = 238;
            this.label65.Text = "转诊科室:";
            // 
            // tbZhuanzhenKs
            // 
            this.tbZhuanzhenKs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenKs.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenKs.Location = new System.Drawing.Point(184, 1120);
            this.tbZhuanzhenKs.MaxLength = 20;
            this.tbZhuanzhenKs.Multiline = true;
            this.tbZhuanzhenKs.Name = "tbZhuanzhenKs";
            this.tbZhuanzhenKs.ReadOnly = true;
            this.tbZhuanzhenKs.Size = new System.Drawing.Size(173, 33);
            this.tbZhuanzhenKs.TabIndex = 44;
            // 
            // label76
            // 
            this.label76.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label76.Location = new System.Drawing.Point(957, 1088);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(99, 20);
            this.label76.TabIndex = 243;
            this.label76.Text = "转诊机构:";
            // 
            // label77
            // 
            this.label77.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label77.Location = new System.Drawing.Point(543, 1126);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(79, 20);
            this.label77.TabIndex = 244;
            this.label77.Text = "联系人:";
            // 
            // tbZhuanzhenLxr
            // 
            this.tbZhuanzhenLxr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenLxr.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenLxr.Location = new System.Drawing.Point(628, 1120);
            this.tbZhuanzhenLxr.MaxLength = 20;
            this.tbZhuanzhenLxr.Multiline = true;
            this.tbZhuanzhenLxr.Name = "tbZhuanzhenLxr";
            this.tbZhuanzhenLxr.ReadOnly = true;
            this.tbZhuanzhenLxr.Size = new System.Drawing.Size(173, 33);
            this.tbZhuanzhenLxr.TabIndex = 245;
            // 
            // label79
            // 
            this.label79.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label79.Location = new System.Drawing.Point(957, 1126);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(99, 20);
            this.label79.TabIndex = 246;
            this.label79.Text = "联系电话:";
            // 
            // tbZhuanzhenJg
            // 
            this.tbZhuanzhenJg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenJg.Location = new System.Drawing.Point(1062, 1083);
            this.tbZhuanzhenJg.Name = "tbZhuanzhenJg";
            this.tbZhuanzhenJg.Size = new System.Drawing.Size(190, 30);
            this.tbZhuanzhenJg.TabIndex = 247;
            // 
            // tbZhuanzhenLxdh
            // 
            this.tbZhuanzhenLxdh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenLxdh.Location = new System.Drawing.Point(1062, 1120);
            this.tbZhuanzhenLxdh.Name = "tbZhuanzhenLxdh";
            this.tbZhuanzhenLxdh.Size = new System.Drawing.Size(191, 30);
            this.tbZhuanzhenLxdh.TabIndex = 248;
            // 
            // label81
            // 
            this.label81.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(79, 1164);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(99, 20);
            this.label81.TabIndex = 249;
            this.label81.Text = "结    果:";
            // 
            // panel42
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel42, 2);
            this.panel42.Controls.Add(this.rdZzjg2);
            this.panel42.Controls.Add(this.rdZzjg1);
            this.panel42.Enabled = false;
            this.panel42.Location = new System.Drawing.Point(184, 1159);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(275, 31);
            this.panel42.TabIndex = 250;
            // 
            // rdZzjg2
            // 
            this.rdZzjg2.AutoSize = true;
            this.rdZzjg2.Location = new System.Drawing.Point(113, 2);
            this.rdZzjg2.Name = "rdZzjg2";
            this.rdZzjg2.Size = new System.Drawing.Size(87, 24);
            this.rdZzjg2.TabIndex = 151;
            this.rdZzjg2.TabStop = true;
            this.rdZzjg2.Text = "未到位";
            this.rdZzjg2.UseVisualStyleBackColor = true;
            // 
            // rdZzjg1
            // 
            this.rdZzjg1.AutoSize = true;
            this.rdZzjg1.Location = new System.Drawing.Point(4, 1);
            this.rdZzjg1.Name = "rdZzjg1";
            this.rdZzjg1.Size = new System.Drawing.Size(67, 24);
            this.rdZzjg1.TabIndex = 150;
            this.rdZzjg1.TabStop = true;
            this.rdZzjg1.Text = "到位";
            this.rdZzjg1.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(79, 682);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(99, 20);
            this.label35.TabIndex = 213;
            this.label35.Text = "黄疸部位:";
            // 
            // label71
            // 
            this.label71.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label71.Location = new System.Drawing.Point(917, 1242);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(139, 20);
            this.label71.TabIndex = 240;
            this.label71.Text = "下次随访日期:";
            // 
            // dtpNext
            // 
            this.dtpNext.Location = new System.Drawing.Point(1062, 1236);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(185, 30);
            this.dtpNext.TabIndex = 48;
            // 
            // label72
            // 
            this.label72.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label72.Location = new System.Drawing.Point(917, 1164);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(139, 20);
            this.label72.TabIndex = 240;
            this.label72.Text = "随访医生签名:";
            this.label72.Visible = false;
            // 
            // tbVisitDoctor
            // 
            this.tbVisitDoctor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbVisitDoctor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbVisitDoctor.ForeColor = System.Drawing.Color.Black;
            this.tbVisitDoctor.Location = new System.Drawing.Point(1062, 1160);
            this.tbVisitDoctor.MaxLength = 20;
            this.tbVisitDoctor.Multiline = true;
            this.tbVisitDoctor.Name = "tbVisitDoctor";
            this.tbVisitDoctor.Size = new System.Drawing.Size(162, 29);
            this.tbVisitDoctor.TabIndex = 49;
            this.tbVisitDoctor.Visible = false;
            // 
            // panel46
            // 
            this.panel46.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel46, 6);
            this.panel46.Controls.Add(this.lkYs);
            this.panel46.Controls.Add(this.picSignYs);
            this.panel46.Controls.Add(this.label52);
            this.panel46.Controls.Add(this.lkJs);
            this.panel46.Controls.Add(this.picSignJs);
            this.panel46.Controls.Add(this.label82);
            this.panel46.Location = new System.Drawing.Point(0, 1272);
            this.panel46.Margin = new System.Windows.Forms.Padding(0);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(1317, 61);
            this.panel46.TabIndex = 255;
            // 
            // lkYs
            // 
            this.lkYs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(501, 19);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 258;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(299, 8);
            this.picSignYs.Margin = new System.Windows.Forms.Padding(0);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(189, 48);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 255;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // label52
            // 
            this.label52.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(154, 19);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(139, 20);
            this.label52.TabIndex = 256;
            this.label52.Text = "随访医生签名:";
            // 
            // lkJs
            // 
            this.lkJs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lkJs.AutoSize = true;
            this.lkJs.Location = new System.Drawing.Point(1095, 19);
            this.lkJs.Name = "lkJs";
            this.lkJs.Size = new System.Drawing.Size(89, 20);
            this.lkJs.TabIndex = 254;
            this.lkJs.TabStop = true;
            this.lkJs.Text = "重置签名";
            this.lkJs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // picSignJs
            // 
            this.picSignJs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJs.Location = new System.Drawing.Point(886, 8);
            this.picSignJs.Margin = new System.Windows.Forms.Padding(0);
            this.picSignJs.Name = "picSignJs";
            this.picSignJs.Size = new System.Drawing.Size(189, 48);
            this.picSignJs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJs.TabIndex = 0;
            this.picSignJs.TabStop = false;
            this.picSignJs.Click += new System.EventHandler(this.picSignJs_Click);
            // 
            // label82
            // 
            this.label82.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(774, 19);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(99, 20);
            this.label82.TabIndex = 252;
            this.label82.Text = "家长签名:";
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel28.Controls.Add(this.lbInfo);
            this.panel28.Controls.Add(this.btnBaseInfo);
            this.panel28.Controls.Add(this.btnDown);
            this.panel28.Controls.Add(this.btnAssistCheck);
            this.panel28.Controls.Add(this.btnUp);
            this.panel28.Location = new System.Drawing.Point(217, 594);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(645, 36);
            this.panel28.TabIndex = 1;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(531, 10);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(79, 20);
            this.lbInfo.TabIndex = 112;
            this.lbInfo.Text = "label92";
            this.lbInfo.Visible = false;
            // 
            // btnBaseInfo
            // 
            this.btnBaseInfo.Location = new System.Drawing.Point(127, 4);
            this.btnBaseInfo.Name = "btnBaseInfo";
            this.btnBaseInfo.Size = new System.Drawing.Size(75, 28);
            this.btnBaseInfo.TabIndex = 108;
            this.btnBaseInfo.Text = "基本信息";
            this.btnBaseInfo.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(442, 5);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 28);
            this.btnDown.TabIndex = 111;
            this.btnDown.Text = "下";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnAssistCheck
            // 
            this.btnAssistCheck.Location = new System.Drawing.Point(209, 10);
            this.btnAssistCheck.Name = "btnAssistCheck";
            this.btnAssistCheck.Size = new System.Drawing.Size(45, 22);
            this.btnAssistCheck.TabIndex = 109;
            this.btnAssistCheck.Text = "体征状况";
            this.btnAssistCheck.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(357, 5);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 28);
            this.btnUp.TabIndex = 110;
            this.btnUp.Text = "上";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // FrmNewBornVisit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "FrmNewBornVisit";
            this.Text = "KidsInfoForm";
            this.Load += new System.EventHandler(this.FrmChildInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel43.ResumeLayout(false);
            this.panel43.PerformLayout();
            this.panel41.ResumeLayout(false);
            this.panel41.PerformLayout();
            this.panel40.ResumeLayout(false);
            this.panel40.PerformLayout();
            this.panel39.ResumeLayout(false);
            this.panel39.PerformLayout();
            this.panel38.ResumeLayout(false);
            this.panel38.PerformLayout();
            this.panel37.ResumeLayout(false);
            this.panel37.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panel34.ResumeLayout(false);
            this.panel34.PerformLayout();
            this.panel33.ResumeLayout(false);
            this.panel33.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel30.ResumeLayout(false);
            this.panel30.PerformLayout();
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel45.ResumeLayout(false);
            this.panel45.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel35.ResumeLayout(false);
            this.panel35.PerformLayout();
            this.panel42.ResumeLayout(false);
            this.panel42.PerformLayout();
            this.panel46.ResumeLayout(false);
            this.panel46.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).EndInit();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.ResumeLayout(false);

        }

        private void JustZhuanzhenChanged(string haf)
        {
            if (haf == "1")
            {
                this.tbZhuanzhenKs.Clear();
                this.tbZhuanzhenKs.ReadOnly = true;
                this.tbZhuanzhenResult.Clear();
                this.tbZhuanzhenResult.ReadOnly = true;
                this.tbZhuanzhenJg.Clear();
                this.tbZhuanzhenJg.ReadOnly = true;
                this.tbZhuanzhenLxr.Clear();
                this.tbZhuanzhenLxr.ReadOnly = true;
                this.tbZhuanzhenLxdh.Clear();
                this.tbZhuanzhenLxdh.ReadOnly = true;
                this.panel42.Enabled = false;
                this.rdZzjg1.Checked = false;
                this.rdZzjg2.Checked = false;
            }
            if (haf == "2")
            {
                this.tbZhuanzhenKs.ReadOnly = false;
                this.tbZhuanzhenResult.ReadOnly = false;
                this.tbZhuanzhenJg.ReadOnly = false;
                this.tbZhuanzhenLxr.ReadOnly = false ;
                this.tbZhuanzhenLxdh.ReadOnly = false;
                this.panel42.Enabled = true;
            }
        }

        public void NotisfyChildStatus()
        {
        }

        private void rdApneaHave_CheckedChanged(object sender, EventArgs e)
        {
            this.cbApgar.Enabled = true;
        }

        private void rdApneaNo_CheckedChanged(object sender, EventArgs e)
        {
            this.cbApgar.Enabled = false;
            this.cbApgar.SelectedIndex = -1;
        }
       

        public bool SaveModelToDB()
        {
         
            KidsNewBornVisitBLL child_newborn_followup = new KidsNewBornVisitBLL();
            if (child_newborn_followup.Exists(this.NewBornVisit.ID))
            {
                child_newborn_followup.Update(this.NewBornVisit);
            }
            else
            {
                child_newborn_followup.Add(this.NewBornVisit);
            }

            return true;
        }

        private void SetPanel22Scrol(int p_top)
        {
            Action<int> method = new Action<int>(this.SetPanel22Scrol);
            int num = this.panel21.VerticalScroll.Value + p_top;
            if (this.panel21.InvokeRequired)
            {
                this.panel21.Invoke(method, new object[] { p_top * 2 });
            }
            else if ((num <= this.panel21.VerticalScroll.Maximum) && (num >= this.panel21.VerticalScroll.Minimum))
            {
                this.panel21.VerticalScroll.Value = num;
                this.lbInfo.Text = this.panel6.VerticalScroll.Value.ToString();
            }
        }

        private void tbDadName_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbMumName_TextChanged(object sender, EventArgs e)
        {
        }

        private void time_up_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.SetPanel22Scrol(-1);
        }

        private void timer_down_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.SetPanel22Scrol(1);
        }

        public void UpdataToModel()
        {
          
            if (this.rdApneaNo.Checked)
            {
                this.NewBornVisit.Aasphyxia = "1";
            }
            else if (this.rdApneaHave.Checked)
            {
                this.NewBornVisit.Aasphyxia = "2";
            }
            if (this.tingli.Count<KeyValuePair<string, RadioButton>>(a => a.Value.Checked) == 1)
            {
                this.NewBornVisit.HearingScreen = this.tingli.Single<KeyValuePair<string, RadioButton>>(b => b.Value.Checked).Key;
            }
            if (this.rdShithu.Checked)
            {
                this.NewBornVisit.Stool = "1";
            }
            if (this.rdShitxi.Checked)
            {
                this.NewBornVisit.Stool = "2";
            }
            if (this.rdShitqt.Checked)
            {
                this.NewBornVisit.Stool = "3";
            }
            this.NewBornVisit.InterviewDate = new DateTime?(this.dtpVisit.Value.Date);
            this.NewBornVisit.NextFollowupDate = new DateTime?(this.dtpNext.Value.Date);
            if (this.rdZzjg1.Checked)
            {
                this.NewBornVisit.ReferralResult = "1";
            }
            else if (this.rdZzjg2.Checked)
            {
                this.NewBornVisit.ReferralResult = "2";
            }

            if (this.rdmianse1.Checked)
            {
                this.NewBornVisit.ColourFace = "1";
            }
            else if (this.rdmianse2.Checked)
            {
                this.NewBornVisit.ColourFace = "2";
            }
            else if (this.rdmianse3.Checked)
            {
                this.NewBornVisit.ColourFace = "3";
            }
            if (this.cbApgar.SelectedIndex != -1)
            {
                this.NewBornVisit.Apgar = Convert.ToString(this.cbApgar.SelectedIndex+1);
            }
            if (this.cbpifu.SelectedIndex != -1)
            {
                this.NewBornVisit.Skin = Convert.ToString(this.cbpifu.SelectedIndex + 1);
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        private KidsNewBornVisitModel NewBornVisit { get; set; }

        public string SaveDataInfo { get; set; }

        public object srcData { get; set; }

        private void rdmianse3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdmianse3.Checked)
            {
                this.tbFaceOth.ReadOnly = false;
            }
            else
            {
                this.tbFaceOth.Clear();
                this.tbFaceOth.ReadOnly = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_NewBorn", picSignJs);
        }

        private void cbpifu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbpifu.SelectedIndex == 3)//其他时
            {
                this.tbSkin.ReadOnly = false;
            }
            else
            {
                this.tbSkin.Clear();
                this.tbSkin.ReadOnly = true;
            }
        }
        public bool IsHandset(string str_handset)
        {
            return Regex.IsMatch(str_handset, @"^[1]+[0-9]+\d{9}");
        }

        public bool IsTelephone(string str_telephone)
        {
            if (!Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$"))
            {
                return Regex.IsMatch(str_telephone, @"^(\d{3,4})?\d{6,8}$");
            }
            return true;
        }


        private void tbMumPhone_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if ((string.IsNullOrEmpty(box.Text) || this.IsTelephone(box.Text)) || this.IsHandset(box.Text))
            {
                box.BackColor = Color.WhiteSmoke;
                box.Tag = 0;
            }
            else
            {
                box.BackColor = Color.Salmon;
                box.Tag = 1;
            }
        }

        private void tbDadPhone_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if ((string.IsNullOrEmpty(box.Text) || this.IsTelephone(box.Text)) || this.IsHandset(box.Text))
            {
                box.BackColor = Color.WhiteSmoke;
                box.Tag = 0;
            }
            else
            {
                box.BackColor = Color.Salmon;
                box.Tag = 1;
            }
        }

        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_NewBorn_Doc", picSignYs);
        }

        private void picSignYs_Click(object sender, EventArgs e)
        {
            Sign("_NewBorn_Doc", picSignYs);
        }

        private void picSignJs_Click(object sender, EventArgs e)
        {
            Sign("_NewBorn", picSignJs);
        }
        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();
            loadForm.IDCardNo = Model.IDCardNo;
            loadForm.SignPath = SignPath;
            loadForm.SignName = DaySign;
            if (loadForm.ShowDialog() == DialogResult.OK)
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                }
                string path = string.Format("{0}{1}{2}.png", SignPath, Model.IDCardNo, DaySign);
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
                    string date = dtpVisit.Value.ToString("yyyyMMdd");
                    string path = SignPath + Model.IDCardNo + DaySign + ".png";
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
    }
}

