using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.ChronicDisease
{
    using KangShuoTech.Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Windows.Forms;
    using System.IO;
    using System.Drawing;
    using System.Configuration;

    public class MentalInfoForm : Form, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<ChronicMentalDiseaseBaseInfoModel> bindingManager;
        private ComboBox cbAgreeKnow;
        private ComboBox cbEconmy;
        private ComboBox cbLast;
        private ComboBox cbLockStatus;
        private ComboBox cbMenzhen;
        private ComboBox cbRelation;
        private CheckedListBox chklbSystom;
        private IContainer components;
        private DateTimePicker dtpFirstHappen;
        private DateTimePicker dtpFirstMedicl;
        private DateTimePicker dtpMarkDate;
        private DateTimePicker dtpQuezhenriq;
        private DateTimePicker dtpTypeTable;
        private GroupBox groupBox2;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox tbAdvise;
        private TextBox tbDoctor;
        private TextBox tbInHosCount;
        private TextBox tbMark;
        private TextBox tbMonAdr;
        private TextBox tbMonIdCard;
        private TextBox tbMonitor;
        private TextBox tbMonPhone;
        private TextBox tbName;
        private TextBox tbQdzs;
        private TextBox tbQzyy;
        private TextBox tbSystomOther;
        private TextBox tbVilConnect;
        private TextBox tbVilConPhone;
        private TextBox tbZhaoHuo;
        private TextBox tbZhaoshi;
        private TextBox tbZhenduan;
        private TextBox tbZhisha;
        private TextBox tbZhiShang;
        private Label label40;
        private ComboBox cbjyqk;
        private Label label2;
        private Label label42;
        private TextBox tbqtwhxw;
        private Label label43;
        private Panel panel2;
        private RadioButton rbhb2;
        private RadioButton rbhb1;
        private PictureBox picSignJs;
        private CMoreChange zhengzh;
        private string SignS = "";
        private string SignDoc = "";//医生签名
        private LinkLabel lkJs;
        private Panel panel4;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label44;
        private Label label41;
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/MentalVisit/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "MentalVisit//"; //签名保存路径

        public MentalInfoForm()
        {
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();
            this.InitEveryControl();

            this.EveryThingIsOk = false;
            this.tableLayoutPanel1.ResumeLayout();
        }

        private void cbMenzhen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbMenzhen.SelectedIndex > 0)
            {
                this.dtpFirstMedicl.Enabled = true;
            }
            else
            {
                this.dtpFirstMedicl.Value = DateTime.Today;
                this.dtpFirstMedicl.Enabled = false;
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            bool flag = false;
            if (this.dtpMarkDate.Value.Date > this.dtpTypeTable.Value.Date)
            {
                flag = true;
                MentalInfoForm info = this;
                string str = info.SaveDataInfo + "签字时间不能大于填表时间!";
                info.SaveDataInfo = str;
            }
            if (!this.bindingManager.ErrorInput && !flag)
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

        private void FrmMentalDisInfo_Load(object sender, EventArgs e)
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

        private void InitEveryControl()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("户主", "1"),
                new ItemDictonaryModel<string>("配偶", "2"),
                new ItemDictonaryModel<string>("父亲", "3"),
                new ItemDictonaryModel<string>("母亲", "4"),
                new ItemDictonaryModel<string>("兄弟", "5"),
                new ItemDictonaryModel<string>("姐妹", "6"),
                new ItemDictonaryModel<string>("儿子", "7"),
                new ItemDictonaryModel<string>("女儿", "8"),
                new ItemDictonaryModel<string>("儿媳", "9"),
                new ItemDictonaryModel<string>("女婿", "10"),
                new ItemDictonaryModel<string>("孙子", "11"),
                new ItemDictonaryModel<string>("孙女", "12"),
                new ItemDictonaryModel<string>("外孙", "13"),
                new ItemDictonaryModel<string>("外孙女", "14"),
                new ItemDictonaryModel<string>("其他", "15")
            };
            this.cbRelation.DisplayMember = "DISPLAYMEMBER";
            this.cbRelation.ValueMember = "VALUEMEMBER";
            this.cbRelation.DataSource = list;
            List<ItemDictonaryModel<string>> list2 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("同意参加管理", "1"),
                new ItemDictonaryModel<string>("不同意参加管理", "0")
            };
            this.cbAgreeKnow.DisplayMember = "DISPLAYMEMBER";
            this.cbAgreeKnow.ValueMember = "VALUEMEMBER";
            this.cbAgreeKnow.DataSource = list2;
            List<ItemDictonaryModel<string>> list3 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("未治", "1"),
                new ItemDictonaryModel<string>("间断门诊治疗", "2"),
                new ItemDictonaryModel<string>("连续门诊治疗", "3")
            };
            this.cbMenzhen.DisplayMember = "DISPLAYMEMBER";
            this.cbMenzhen.ValueMember = "VALUEMEMBER";
            this.cbMenzhen.DataSource = list3;
            List<ItemDictonaryModel<string>> list4 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("痊愈", "1"),
                new ItemDictonaryModel<string>("好转", "2"),
                new ItemDictonaryModel<string>("无变化", "3"),
                new ItemDictonaryModel<string>("加重", "4")
            };
            this.cbLast.DisplayMember = "DISPLAYMEMBER";
            this.cbLast.ValueMember = "VALUEMEMBER";
            this.cbLast.DataSource = list4;
            List<ItemDictonaryModel<string>> list5 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("无关锁", "1"),
                new ItemDictonaryModel<string>("关锁", "2"),
                new ItemDictonaryModel<string>("关锁已解除", "3")
            };
            this.cbLockStatus.DisplayMember = "DISPLAYMEMBER";
            this.cbLockStatus.ValueMember = "VALUEMEMBER";
            this.cbLockStatus.DataSource = list5;
            List<ItemDictonaryModel<string>> list6 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("贫困，在当地贫困线标准以下", "1"),
                new ItemDictonaryModel<string>("非贫困", "2")
            };
            this.cbEconmy.DisplayMember = "DISPLAYMEMBER";
            this.cbEconmy.ValueMember = "VALUEMEMBER";
            this.cbEconmy.DataSource = list6;
            List<ItemDictonaryModel<string>> list7 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("在岗工人", "1"),
                new ItemDictonaryModel<string>("在岗管理者", "2"),
                new ItemDictonaryModel<string>("农民", "3"),
                new ItemDictonaryModel<string>("下岗或无业", "4"),
                new ItemDictonaryModel<string>("在校学生", "5"),
                new ItemDictonaryModel<string>("退休", "6"),
                new ItemDictonaryModel<string>("专业技术人员", "7"),
                new ItemDictonaryModel<string>("其他", "8"),
                new ItemDictonaryModel<string>("不详", "9")
            };
            this.cbjyqk.DisplayMember = "DISPLAYMEMBER";
            this.cbjyqk.ValueMember = "VALUEMEMBER";
            this.cbjyqk.DataSource = list7;
            this.dtpFirstHappen.MaxDate = DateTime.Today;
            this.dtpFirstMedicl.MaxDate = DateTime.Today;
            this.dtpQuezhenriq.MaxDate = DateTime.Today;
            this.dtpTypeTable.MaxDate = DateTime.Today;
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("HospitalCount", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("MildTroubleFrequen", 1000M));
            this.inputRanges.Add(new InputRangeDec("CreateDistuFrequen", 1000M));
            this.inputRanges.Add(new InputRangeDec("CauseAccidFrequen", 1000M));
            this.inputRanges.Add(new InputRangeDec("AutolesionFrequen", 1000M));
            this.inputRanges.Add(new InputRangeDec("AttemptSuicFrequen", 1000M));
            this.inputRanges.Add(new InputRangeDec("OtherDangerFrequen", 1000M));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("GuardianName", 30));
            this.inputrange_str.Add(new InputRangeStr("GuradianAddr", 200));
            this.inputrange_str.Add(new InputRangeStr("GuradianPhone", 15));
            this.inputrange_str.Add(new InputRangeStr("SymptomOther", 200));
            this.inputrange_str.Add(new InputRangeStr("DiagnosisInfo", 500));
            this.inputrange_str.Add(new InputRangeStr("DiagnosisHospital", 200));
            this.inputrange_str.Add(new InputRangeStr("VillageContacts", 30));
            this.inputrange_str.Add(new InputRangeStr("VillageTel", 15));
            this.inputrange_str.Add(new InputRangeStr("SpecialistProposal", 500));
            this.inputrange_str.Add(new InputRangeStr("DoctorMark", 200));
            this.inputrange_str.Add(new InputRangeStr("VillageTel", 15));
            this.inputrange_str.Add(new InputRangeStr("GuardianRecordID", 0x12));
        }

        public void InitEveryThing()
        {
            this.MentalBase = new ChronicMentalDiseaseBaseInfoBLL().GetModel(this.Model.IDCardNo);

            if (this.MentalBase == null)
            {
                ChronicMentalDiseaseBaseInfoModel chronicMentalDiseaseBaseInfoModel = new ChronicMentalDiseaseBaseInfoModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID,
                    Economy = "1"
                };
                this.MentalBase = chronicMentalDiseaseBaseInfoModel;
                this.MentalBase.CreateUnit = new decimal?(ConfigHelper.GetNodeDec("orgCode"));
                this.MentalBase.CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.MentalBase.CreatedDate = new DateTime?(DateTime.Today);
            }
            else
            {
                this.MentalBase.LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.MentalBase.LastUpDateDate = new DateTime?(DateTime.Today);
            }
            if (string.IsNullOrEmpty(this.MentalBase.DoctorMark))
            {
                this.MentalBase.DoctorMark = ConfigHelper.GetNode("doctorName");
            }
            this.bindingManager = new SimpleBindingManager<ChronicMentalDiseaseBaseInfoModel>(this.inputRanges, this.inputrange_str, this.MentalBase);
            this.tbName.Text = this.Model.CustomerName;
            this.bindingManager.SimpleBindingIdentify(this.tbMonIdCard, "GuardianRecordID");
            this.bindingManager.SimpleBinding(this.tbMonitor, "GuardianName", false);
            this.bindingManager.SimpleBinding(this.cbRelation, "Ralation");
            this.bindingManager.SimpleBinding(this.tbMonAdr, "GuradianAddr", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbMonPhone, "GuradianPhone", false);
            this.bindingManager.SimpleBinding(this.tbVilConnect, "VillageContacts", false);
            this.bindingManager.SimpleBindingPhoneNum(this.tbVilConPhone, "VillageTel", false);
            this.bindingManager.SimpleBinding(this.cbAgreeKnow, "AgreeManagement");
            this.bindingManager.SimpleBinding(this.tbMark, "AgreeSignature", false);
            this.bindingManager.SimpleBinding(this.cbjyqk, "Professional");//就业情况
            if (this.MentalBase.AgreeTime.HasValue)
            {
                this.dtpMarkDate.Value = this.MentalBase.AgreeTime.Value;
            }
            if (this.MentalBase.FirstTime.HasValue)
            {
                this.dtpFirstHappen.Value = this.MentalBase.FirstTime.Value;
            }
            if (this.MentalBase.HouseType == "1")
            {
                this.rbhb1.Checked = true;
            }
            else if (this.MentalBase.HouseType == "2")
            {
                this.rbhb2.Checked = true;
            }
            CMoreChange change = new CMoreChange {
                Name = "症状",
                MoreChange = this.chklbSystom,
                Other = this.tbSystomOther,
                MaxBytesCount = 200
            };
            this.zhengzh = change;
            this.zhengzh.TransInfo(this.MentalBase.Symptom, this.MentalBase.SymptomOther);
            this.bindingManager.SimpleBinding(this.cbMenzhen, "OutPatien");
            if (this.MentalBase.FirstTreatmenTTime.HasValue)
            {
                this.dtpFirstMedicl.Value = this.MentalBase.FirstTreatmenTTime.Value;
            }
            this.bindingManager.SimpleBindingInt(this.tbInHosCount, "HospitalCount", true);
            this.bindingManager.SimpleBinding(this.tbZhenduan, "DiagnosisInfo", false);
            this.bindingManager.SimpleBinding(this.tbQzyy, "DiagnosisHospital", false);
            if (this.MentalBase.DiagnosisTime.HasValue)
            {
                this.dtpQuezhenriq.Value = this.MentalBase.DiagnosisTime.Value;
            }
            this.bindingManager.SimpleBinding(this.cbLast, "LastCure");
            this.bindingManager.SimpleBindingInt(this.tbQdzs, "MildTroubleFrequen", true);
            this.bindingManager.SimpleBindingInt(this.tbZhaoshi, "CreateDistuFrequen", true);
            this.bindingManager.SimpleBindingInt(this.tbZhaoHuo, "CauseAccidFrequen", true);
            this.bindingManager.SimpleBindingInt(this.tbZhiShang, "AutolesionFrequen", true);
            this.bindingManager.SimpleBindingInt(this.tbZhisha, "AttemptSuicFrequen", true);
            this.bindingManager.SimpleBindingInt(this.tbqtwhxw, "OtherDangerFrequen", true);
            this.bindingManager.SimpleBinding(this.cbLockStatus, "LockInfo");
            this.bindingManager.SimpleBinding(this.cbEconmy, "Economy");
            this.bindingManager.SimpleBinding(this.tbAdvise, "SpecialistProposal", false);
            if (this.MentalBase.FillformTime.HasValue)
            {
                this.dtpTypeTable.Value = this.MentalBase.FillformTime.Value;
            }
            this.bindingManager.SimpleBinding(this.tbDoctor, "DoctorMark", false);
            
            //签名初始化
            this.SignS = string.Format("{0}{1}_{2}.png", this.SignPath, this.Model.IDCardNo, "BaseInfo");
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
            this.SignDoc = string.Format("{0}{1}_{2}_Doc.png", this.SignPath, this.Model.IDCardNo, "BaseInfo");
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbSystomOther = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chklbSystom = new System.Windows.Forms.CheckedListBox();
            this.tbInHosCount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpFirstMedicl = new System.Windows.Forms.DateTimePicker();
            this.cbMenzhen = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbMonitor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMonIdCard = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRelation = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbMonAdr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMonPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbVilConnect = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbVilConPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbAgreeKnow = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpMarkDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFirstHappen = new System.Windows.Forms.DateTimePicker();
            this.label40 = new System.Windows.Forms.Label();
            this.cbjyqk = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbhb2 = new System.Windows.Forms.RadioButton();
            this.rbhb1 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.cbLast = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpQuezhenriq = new System.Windows.Forms.DateTimePicker();
            this.tbZhenduan = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbQzyy = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.tbqtwhxw = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbZhisha = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tbZhiShang = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tbZhaoHuo = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tbZhaoshi = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tbQdzs = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.cbLockStatus = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cbEconmy = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tbAdvise = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.dtpTypeTable = new System.Windows.Forms.DateTimePicker();
            this.label38 = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.picSignJs = new System.Windows.Forms.PictureBox();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.lkJs = new System.Windows.Forms.LinkLabel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.label44 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.tbSystomOther);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.chklbSystom);
            this.groupBox2.Controls.Add(this.tbInHosCount);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dtpFirstMedicl);
            this.groupBox2.Controls.Add(this.cbMenzhen);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(78, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1380, 128);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "既往主要症状和治疗情况";
            // 
            // tbSystomOther
            // 
            this.tbSystomOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSystomOther.ForeColor = System.Drawing.Color.Black;
            this.tbSystomOther.Location = new System.Drawing.Point(694, 50);
            this.tbSystomOther.MaxLength = 20;
            this.tbSystomOther.Multiline = true;
            this.tbSystomOther.Name = "tbSystomOther";
            this.tbSystomOther.ReadOnly = true;
            this.tbSystomOther.Size = new System.Drawing.Size(174, 25);
            this.tbSystomOther.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(1212, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 20);
            this.label15.TabIndex = 6;
            this.label15.Text = "次";
            // 
            // chklbSystom
            // 
            this.chklbSystom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chklbSystom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chklbSystom.CheckOnClick = true;
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
            this.chklbSystom.Location = new System.Drawing.Point(9, 25);
            this.chklbSystom.MultiColumn = true;
            this.chklbSystom.Name = "chklbSystom";
            this.chklbSystom.Size = new System.Drawing.Size(1252, 52);
            this.chklbSystom.TabIndex = 0;
            // 
            // tbInHosCount
            // 
            this.tbInHosCount.Location = new System.Drawing.Point(1157, 85);
            this.tbInHosCount.MaxLength = 2;
            this.tbInHosCount.Name = "tbInHosCount";
            this.tbInHosCount.Size = new System.Drawing.Size(46, 30);
            this.tbInHosCount.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(810, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(339, 20);
            this.label14.TabIndex = 4;
            this.label14.Text = "曾住精神专科医院/综合医院精神专科";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(741, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 20);
            this.label12.TabIndex = 131;
            this.label12.Text = "住院:";
            // 
            // dtpFirstMedicl
            // 
            this.dtpFirstMedicl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFirstMedicl.Location = new System.Drawing.Point(553, 85);
            this.dtpFirstMedicl.Name = "dtpFirstMedicl";
            this.dtpFirstMedicl.Size = new System.Drawing.Size(149, 30);
            this.dtpFirstMedicl.TabIndex = 3;
            // 
            // cbMenzhen
            // 
            this.cbMenzhen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMenzhen.FormattingEnabled = true;
            this.cbMenzhen.Location = new System.Drawing.Point(74, 86);
            this.cbMenzhen.Name = "cbMenzhen";
            this.cbMenzhen.Size = new System.Drawing.Size(177, 28);
            this.cbMenzhen.TabIndex = 2;
            this.cbMenzhen.SelectedIndexChanged += new System.EventHandler(this.cbMenzhen_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(6, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 20);
            this.label20.TabIndex = 94;
            this.label20.Text = "门诊:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(307, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(239, 20);
            this.label11.TabIndex = 122;
            this.label11.Text = "首次抗精神病药治疗时间:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbMonitor, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbMonIdCard, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbRelation, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbMonAdr, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbMonPhone, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbVilConnect, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label19, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbVilConPhone, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbAgreeKnow, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbMark, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpMarkDate, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpFirstHappen, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label40, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbjyqk, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 5, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(86, 9);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1373, 177);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(88, 7);
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
            this.tbName.Location = new System.Drawing.Point(193, 3);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(189, 30);
            this.tbName.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(525, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 20);
            this.label13.TabIndex = 100;
            this.label13.Text = "监护人姓名:";
            // 
            // tbMonitor
            // 
            this.tbMonitor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMonitor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMonitor.ForeColor = System.Drawing.Color.Black;
            this.tbMonitor.Location = new System.Drawing.Point(650, 3);
            this.tbMonitor.MaxLength = 20;
            this.tbMonitor.Name = "tbMonitor";
            this.tbMonitor.Size = new System.Drawing.Size(173, 30);
            this.tbMonitor.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(962, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 101;
            this.label3.Text = "监护人身份证:";
            // 
            // tbMonIdCard
            // 
            this.tbMonIdCard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMonIdCard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMonIdCard.ForeColor = System.Drawing.Color.Black;
            this.tbMonIdCard.Location = new System.Drawing.Point(1107, 3);
            this.tbMonIdCard.MaxLength = 18;
            this.tbMonIdCard.Name = "tbMonIdCard";
            this.tbMonIdCard.Size = new System.Drawing.Size(190, 30);
            this.tbMonIdCard.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(68, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 112;
            this.label4.Text = "与患者关系:";
            // 
            // cbRelation
            // 
            this.cbRelation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRelation.FormattingEnabled = true;
            this.cbRelation.Location = new System.Drawing.Point(193, 42);
            this.cbRelation.Name = "cbRelation";
            this.cbRelation.Size = new System.Drawing.Size(189, 28);
            this.cbRelation.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(525, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 20);
            this.label16.TabIndex = 111;
            this.label16.Text = "监护人住址:";
            // 
            // tbMonAdr
            // 
            this.tbMonAdr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMonAdr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMonAdr.ForeColor = System.Drawing.Color.Black;
            this.tbMonAdr.Location = new System.Drawing.Point(650, 38);
            this.tbMonAdr.MaxLength = 20;
            this.tbMonAdr.Name = "tbMonAdr";
            this.tbMonAdr.Size = new System.Drawing.Size(173, 30);
            this.tbMonAdr.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(982, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 133;
            this.label5.Text = "监护人电话:";
            // 
            // tbMonPhone
            // 
            this.tbMonPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMonPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMonPhone.ForeColor = System.Drawing.Color.Black;
            this.tbMonPhone.Location = new System.Drawing.Point(1107, 38);
            this.tbMonPhone.MaxLength = 15;
            this.tbMonPhone.Name = "tbMonPhone";
            this.tbMonPhone.Size = new System.Drawing.Size(190, 30);
            this.tbMonPhone.TabIndex = 5;
            this.tbMonPhone.TextChanged += new System.EventHandler(this.tbMonPhone_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(48, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 20);
            this.label6.TabIndex = 134;
            this.label6.Text = "居委会联系人:";
            // 
            // tbVilConnect
            // 
            this.tbVilConnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbVilConnect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbVilConnect.ForeColor = System.Drawing.Color.Black;
            this.tbVilConnect.Location = new System.Drawing.Point(193, 73);
            this.tbVilConnect.MaxLength = 30;
            this.tbVilConnect.Name = "tbVilConnect";
            this.tbVilConnect.Size = new System.Drawing.Size(189, 30);
            this.tbVilConnect.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(485, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(159, 20);
            this.label19.TabIndex = 111;
            this.label19.Text = "居委会联系电话:";
            // 
            // tbVilConPhone
            // 
            this.tbVilConPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbVilConPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbVilConPhone.ForeColor = System.Drawing.Color.Black;
            this.tbVilConPhone.Location = new System.Drawing.Point(650, 73);
            this.tbVilConPhone.MaxLength = 15;
            this.tbVilConPhone.Name = "tbVilConPhone";
            this.tbVilConPhone.Size = new System.Drawing.Size(173, 30);
            this.tbVilConPhone.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(88, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 129;
            this.label7.Text = "知情同意:";
            // 
            // cbAgreeKnow
            // 
            this.cbAgreeKnow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbAgreeKnow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAgreeKnow.FormattingEnabled = true;
            this.cbAgreeKnow.Location = new System.Drawing.Point(193, 112);
            this.cbAgreeKnow.Name = "cbAgreeKnow";
            this.cbAgreeKnow.Size = new System.Drawing.Size(189, 28);
            this.cbAgreeKnow.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(545, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 129;
            this.label8.Text = "签    字:";
            // 
            // tbMark
            // 
            this.tbMark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMark.ForeColor = System.Drawing.Color.Black;
            this.tbMark.Location = new System.Drawing.Point(650, 108);
            this.tbMark.MaxLength = 20;
            this.tbMark.Name = "tbMark";
            this.tbMark.Size = new System.Drawing.Size(173, 30);
            this.tbMark.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1002, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 128;
            this.label1.Text = "签字时间:";
            // 
            // dtpMarkDate
            // 
            this.dtpMarkDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpMarkDate.Location = new System.Drawing.Point(1107, 108);
            this.dtpMarkDate.Name = "dtpMarkDate";
            this.dtpMarkDate.Size = new System.Drawing.Size(190, 30);
            this.dtpMarkDate.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(48, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 130;
            this.label9.Text = "初次发病时间:";
            // 
            // dtpFirstHappen
            // 
            this.dtpFirstHappen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFirstHappen.Location = new System.Drawing.Point(193, 143);
            this.dtpFirstHappen.Name = "dtpFirstHappen";
            this.dtpFirstHappen.Size = new System.Drawing.Size(189, 30);
            this.dtpFirstHappen.TabIndex = 11;
            // 
            // label40
            // 
            this.label40.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(545, 148);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(99, 20);
            this.label40.TabIndex = 138;
            this.label40.Text = "就业情况:";
            // 
            // cbjyqk
            // 
            this.cbjyqk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbjyqk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbjyqk.FormattingEnabled = true;
            this.cbjyqk.Location = new System.Drawing.Point(650, 144);
            this.cbjyqk.Name = "cbjyqk";
            this.cbjyqk.Size = new System.Drawing.Size(173, 28);
            this.cbjyqk.TabIndex = 139;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1042, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 140;
            this.label2.Text = "户别:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbhb2);
            this.panel2.Controls.Add(this.rbhb1);
            this.panel2.Location = new System.Drawing.Point(1107, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 31);
            this.panel2.TabIndex = 141;
            // 
            // rbhb2
            // 
            this.rbhb2.AutoSize = true;
            this.rbhb2.Location = new System.Drawing.Point(116, 4);
            this.rbhb2.Name = "rbhb2";
            this.rbhb2.Size = new System.Drawing.Size(67, 24);
            this.rbhb2.TabIndex = 1;
            this.rbhb2.TabStop = true;
            this.rbhb2.Text = "农村";
            this.rbhb2.UseVisualStyleBackColor = true;
            // 
            // rbhb1
            // 
            this.rbhb1.AutoSize = true;
            this.rbhb1.Location = new System.Drawing.Point(6, 4);
            this.rbhb1.Name = "rbhb1";
            this.rbhb1.Size = new System.Drawing.Size(67, 24);
            this.rbhb1.TabIndex = 0;
            this.rbhb1.TabStop = true;
            this.rbhb1.Text = "城镇";
            this.rbhb1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.43226F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.78316F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.91011F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.48218F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.91011F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.48218F));
            this.tableLayoutPanel2.Controls.Add(this.label23, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbLast, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label22, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpQuezhenriq, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbZhenduan, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label21, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label18, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbQzyy, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label35, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.cbLockStatus, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label36, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.cbEconmy, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.label37, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.tbAdvise, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label39, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.dtpTypeTable, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label38, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.tbDoctor, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 8);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(77, 330);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.13797F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.13797F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.13797F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.13797F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.13797F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.13797F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.13797F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.4113F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.62293F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1382, 341);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(15, 87);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.tableLayoutPanel2.SetRowSpan(this.label23, 2);
            this.label23.Size = new System.Drawing.Size(184, 30);
            this.label23.TabIndex = 176;
            this.label23.Text = "对家庭和社会影响:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbLast
            // 
            this.cbLast.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbLast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLast.FormattingEnabled = true;
            this.cbLast.Location = new System.Drawing.Point(202, 37);
            this.cbLast.Name = "cbLast";
            this.cbLast.Size = new System.Drawing.Size(170, 28);
            this.cbLast.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(17, 41);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(179, 20);
            this.label22.TabIndex = 140;
            this.label22.Text = "最近一次治疗效果:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(7, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(189, 20);
            this.label17.TabIndex = 95;
            this.label17.Text = "目前诊断 情况诊断:";
            // 
            // dtpQuezhenriq
            // 
            this.dtpQuezhenriq.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpQuezhenriq.Location = new System.Drawing.Point(1114, 3);
            this.dtpQuezhenriq.Name = "dtpQuezhenriq";
            this.dtpQuezhenriq.Size = new System.Drawing.Size(185, 30);
            this.dtpQuezhenriq.TabIndex = 2;
            // 
            // tbZhenduan
            // 
            this.tbZhenduan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbZhenduan.Location = new System.Drawing.Point(202, 3);
            this.tbZhenduan.MaxLength = 20;
            this.tbZhenduan.Name = "tbZhenduan";
            this.tbZhenduan.Size = new System.Drawing.Size(170, 30);
            this.tbZhenduan.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(1009, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 20);
            this.label21.TabIndex = 138;
            this.label21.Text = "确诊日期:";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(548, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 20);
            this.label18.TabIndex = 136;
            this.label18.Text = "确诊医院:";
            // 
            // tbQzyy
            // 
            this.tbQzyy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbQzyy.Location = new System.Drawing.Point(653, 3);
            this.tbQzyy.MaxLength = 20;
            this.tbQzyy.Name = "tbQzyy";
            this.tbQzyy.Size = new System.Drawing.Size(173, 30);
            this.tbQzyy.TabIndex = 1;
            // 
            // panel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel1, 5);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.tbqtwhxw);
            this.panel1.Controls.Add(this.label43);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.tbZhisha);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.tbZhiShang);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.tbZhaoHuo);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.tbZhaoshi);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.tbQdzs);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(200, 69);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel2.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(1181, 66);
            this.panel1.TabIndex = 4;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(912, 7);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(29, 20);
            this.label42.TabIndex = 18;
            this.label42.Text = "次";
            // 
            // tbqtwhxw
            // 
            this.tbqtwhxw.Location = new System.Drawing.Point(857, 3);
            this.tbqtwhxw.MaxLength = 3;
            this.tbqtwhxw.Name = "tbqtwhxw";
            this.tbqtwhxw.Size = new System.Drawing.Size(46, 30);
            this.tbqtwhxw.TabIndex = 17;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(713, 7);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(139, 20);
            this.label43.TabIndex = 16;
            this.label43.Text = "4其他危害行为";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(512, 37);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(39, 20);
            this.label34.TabIndex = 15;
            this.label34.Text = "7无";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(416, 38);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 20);
            this.label32.TabIndex = 14;
            this.label32.Text = "次";
            // 
            // tbZhisha
            // 
            this.tbZhisha.Location = new System.Drawing.Point(361, 34);
            this.tbZhisha.MaxLength = 3;
            this.tbZhisha.Name = "tbZhisha";
            this.tbZhisha.Size = new System.Drawing.Size(46, 30);
            this.tbZhisha.TabIndex = 13;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(253, 38);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 20);
            this.label33.TabIndex = 12;
            this.label33.Text = "6自杀未遂";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(176, 38);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 20);
            this.label30.TabIndex = 11;
            this.label30.Text = "次";
            // 
            // tbZhiShang
            // 
            this.tbZhiShang.Location = new System.Drawing.Point(122, 34);
            this.tbZhiShang.MaxLength = 3;
            this.tbZhiShang.Name = "tbZhiShang";
            this.tbZhiShang.Size = new System.Drawing.Size(46, 30);
            this.tbZhiShang.TabIndex = 10;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(52, 39);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(59, 20);
            this.label31.TabIndex = 9;
            this.label31.Text = "5自伤";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(631, 6);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 20);
            this.label26.TabIndex = 8;
            this.label26.Text = "次";
            // 
            // tbZhaoHuo
            // 
            this.tbZhaoHuo.Location = new System.Drawing.Point(578, 2);
            this.tbZhaoHuo.MaxLength = 3;
            this.tbZhaoHuo.Name = "tbZhaoHuo";
            this.tbZhaoHuo.Size = new System.Drawing.Size(46, 30);
            this.tbZhaoHuo.TabIndex = 7;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(511, 7);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 20);
            this.label29.TabIndex = 6;
            this.label29.Text = "3肇祸";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(416, 7);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 20);
            this.label24.TabIndex = 5;
            this.label24.Text = "次";
            // 
            // tbZhaoshi
            // 
            this.tbZhaoshi.Location = new System.Drawing.Point(361, 3);
            this.tbZhaoshi.MaxLength = 3;
            this.tbZhaoshi.Name = "tbZhaoshi";
            this.tbZhaoshi.Size = new System.Drawing.Size(46, 30);
            this.tbZhaoshi.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(293, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 20);
            this.label25.TabIndex = 3;
            this.label25.Text = "2肇事";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(176, 6);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 20);
            this.label28.TabIndex = 2;
            this.label28.Text = "次";
            // 
            // tbQdzs
            // 
            this.tbQdzs.Location = new System.Drawing.Point(122, 2);
            this.tbQdzs.MaxLength = 3;
            this.tbQdzs.Name = "tbQdzs";
            this.tbQdzs.Size = new System.Drawing.Size(46, 30);
            this.tbQdzs.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 6);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(99, 20);
            this.label27.TabIndex = 0;
            this.label27.Text = "1轻度滋事";
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(97, 143);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(99, 20);
            this.label35.TabIndex = 178;
            this.label35.Text = "关锁状况:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbLockStatus
            // 
            this.cbLockStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbLockStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLockStatus.FormattingEnabled = true;
            this.cbLockStatus.Location = new System.Drawing.Point(202, 139);
            this.cbLockStatus.Name = "cbLockStatus";
            this.cbLockStatus.Size = new System.Drawing.Size(170, 28);
            this.cbLockStatus.TabIndex = 5;
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(548, 143);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(99, 20);
            this.label36.TabIndex = 180;
            this.label36.Text = "经济状况:";
            // 
            // cbEconmy
            // 
            this.cbEconmy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.SetColumnSpan(this.cbEconmy, 2);
            this.cbEconmy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEconmy.FormattingEnabled = true;
            this.cbEconmy.Location = new System.Drawing.Point(653, 139);
            this.cbEconmy.Name = "cbEconmy";
            this.cbEconmy.Size = new System.Drawing.Size(352, 28);
            this.cbEconmy.TabIndex = 6;
            // 
            // label37
            // 
            this.label37.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label37.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(11, 191);
            this.label37.Margin = new System.Windows.Forms.Padding(0);
            this.label37.Name = "label37";
            this.tableLayoutPanel2.SetRowSpan(this.label37, 2);
            this.label37.Size = new System.Drawing.Size(188, 26);
            this.label37.TabIndex = 182;
            this.label37.Text = "  专科医生的意见:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbAdvise
            // 
            this.tbAdvise.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.SetColumnSpan(this.tbAdvise, 5);
            this.tbAdvise.Location = new System.Drawing.Point(199, 173);
            this.tbAdvise.Margin = new System.Windows.Forms.Padding(0);
            this.tbAdvise.MaxLength = 3000;
            this.tbAdvise.Multiline = true;
            this.tbAdvise.Name = "tbAdvise";
            this.tableLayoutPanel2.SetRowSpan(this.tbAdvise, 2);
            this.tbAdvise.Size = new System.Drawing.Size(806, 61);
            this.tbAdvise.TabIndex = 7;
            // 
            // label39
            // 
            this.label39.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(97, 247);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(99, 20);
            this.label39.TabIndex = 186;
            this.label39.Text = "填表时间:";
            // 
            // dtpTypeTable
            // 
            this.dtpTypeTable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpTypeTable.Location = new System.Drawing.Point(202, 242);
            this.dtpTypeTable.Name = "dtpTypeTable";
            this.dtpTypeTable.Size = new System.Drawing.Size(203, 30);
            this.dtpTypeTable.TabIndex = 8;
            // 
            // label38
            // 
            this.label38.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(548, 247);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(99, 20);
            this.label38.TabIndex = 184;
            this.label38.Text = "医生签字:";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDoctor.Location = new System.Drawing.Point(653, 242);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(207, 30);
            this.tbDoctor.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.panel4, 6);
            this.panel4.Controls.Add(this.label41);
            this.panel4.Controls.Add(this.picSignJs);
            this.panel4.Controls.Add(this.lkYs);
            this.panel4.Controls.Add(this.lkJs);
            this.panel4.Controls.Add(this.picSignYs);
            this.panel4.Controls.Add(this.label44);
            this.panel4.Location = new System.Drawing.Point(0, 276);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1382, 65);
            this.panel4.TabIndex = 187;
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(754, 27);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(159, 20);
            this.label41.TabIndex = 187;
            this.label41.Text = "患者(家属)签字:";
            // 
            // picSignJs
            // 
            this.picSignJs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJs.Location = new System.Drawing.Point(923, 5);
            this.picSignJs.Margin = new System.Windows.Forms.Padding(0);
            this.picSignJs.Name = "picSignJs";
            this.picSignJs.Size = new System.Drawing.Size(190, 50);
            this.picSignJs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJs.TabIndex = 0;
            this.picSignJs.TabStop = false;
            this.picSignJs.Click += new System.EventHandler(this.picSignJs_Click);
            // 
            // lkYs
            // 
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(405, 27);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 191;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // lkJs
            // 
            this.lkJs.AutoSize = true;
            this.lkJs.Location = new System.Drawing.Point(1124, 23);
            this.lkJs.Name = "lkJs";
            this.lkJs.Size = new System.Drawing.Size(89, 20);
            this.lkJs.TabIndex = 3;
            this.lkJs.TabStop = true;
            this.lkJs.Text = "重置签名";
            this.lkJs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkJs_LinkClicked);
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(202, 7);
            this.picSignYs.Margin = new System.Windows.Forms.Padding(0);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(190, 50);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 190;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // label44
            // 
            this.label44.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.Location = new System.Drawing.Point(97, 23);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(99, 20);
            this.label44.TabIndex = 189;
            this.label44.Text = "医生签名:";
            // 
            // MentalInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MentalInfoForm";
            this.Text = "MentalDisInfoForm";
            this.Load += new System.EventHandler(this.FrmMentalDisInfo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            
            ChronicMentalDiseaseBaseInfoBLL cd_mentaldisease_baseinfo = new ChronicMentalDiseaseBaseInfoBLL();
            if (cd_mentaldisease_baseinfo.Exists(this.MentalBase.ID))
            {
                cd_mentaldisease_baseinfo.Update(this.MentalBase);
            }
            else
            {
                cd_mentaldisease_baseinfo.Add(this.MentalBase);
            }
            return true;
        }

        private void tbMonPhone_TextChanged(object sender, EventArgs e)
        {
        }

        public void UpdataToModel()
        {
            this.MentalBase.FirstTreatmenTTime = ((this.MentalBase.OutPatien == "") || (this.MentalBase.OutPatien == "1")) ? null : new DateTime?(this.dtpFirstMedicl.Value.Date);
            this.MentalBase.AttemptSuicideNone = ((((((this.MentalBase.MildTroubleFrequen + this.MentalBase.CreateDistuFrequen) + this.MentalBase.CauseAccidFrequen) + this.MentalBase.AutolesionFrequen) + this.MentalBase.AttemptSuicFrequen)+this.MentalBase.OtherDangerFrequen) <= 0) ? "无" : "有";
            this.MentalBase.DiagnosisTime = new DateTime?(this.dtpQuezhenriq.Value.Date);
            this.MentalBase.Symptom = this.zhengzh.FinalResult;
            this.MentalBase.SymptomOther = this.zhengzh.FinalResultEX;
            this.MentalBase.FirstTime = new DateTime?(this.dtpFirstHappen.Value.Date);
            this.MentalBase.AgreeTime = new DateTime?(this.dtpMarkDate.Value.Date);
            this.MentalBase.FillformTime = new DateTime?(this.dtpTypeTable.Value);
            if (this.rbhb1.Checked)
            {
                this.MentalBase.HouseType = "1";
            }
            else if (this.rbhb2.Checked)
            {
                this.MentalBase.HouseType = "2";
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        private ChronicMentalDiseaseBaseInfoModel MentalBase { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }


        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Clear("_BaseInfo_Doc", picSignYs);
        }

        private void lkJs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_BaseInfo", picSignYs);
        }

        private void picSignYs_Click(object sender, EventArgs e)
        {
            Sign("_BaseInfo_Doc", picSignYs);
        }

        private void picSignJs_Click(object sender, EventArgs e)
        {
            Sign("_BaseInfo", picSignJs);
        }
        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();
            if (!Directory.Exists(SignPath))
            {
                Directory.CreateDirectory(SignPath);
            }
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

