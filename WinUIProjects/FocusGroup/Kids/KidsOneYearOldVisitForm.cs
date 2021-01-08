
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.Utilities.Common;
using System.IO;
using System.Configuration;

namespace FocusGroup.Kids
{
    public class KidsOneYearOldVisitForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<KidsThreeToSixYearOldModel> bindingManager;
        private IContainer components;
        private JustSingleItem<KidsThreeToSixYearOldModel> fubu;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private JustSingleItem<KidsThreeToSixYearOldModel> tingli;
        private JustSingleItem<KidsThreeToSixYearOldModel> xiongb;
        private int yearAge = 3;
        private ManyCheckboxs<KidsThreeToSixYearOldModel> zhidao;
        private Panel panel1;
        private Label lbName;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label15;
        private Panel panel_shili;
        private TextBox tbShili;
        private DateTimePicker dtpVisit;
        private Label label9;
        private Panel panel5;
        private ComboBox cbWeight;
        private Button btnWeight;
        private Label label31;
        private TextBox tbWeight;
        private Label label67;
        private Label label13;
        private Label label33;
        private Label label16;
        private Panel panel12;
        private ComboBox cbBodyLength;
        private Label label12;
        private TextBox tbBornLength;
        private ComboBox cbTig;
        private Label label6;
        private Panel panel_tingli;
        private RadioButton rdTingl2;
        private RadioButton rdTingl1;
        private Label label3;
        private Panel panel9;
        private Label label5;
        private TextBox tbBedTooth;
        private Label label19;
        private TextBox tbTooth;
        private Label label8;
        private Panel panel10;
        private RadioButton rdXiongb2;
        private RadioButton rdXiongb1;
        private Label label4;
        private Panel panel3;
        private RadioButton rdFub2;
        private RadioButton rdFub1;
        private Label label21;
        private Panel panel15;
        private Button btnSelectHB;
        private Label label22;
        private TextBox tbHem;
        private Label label25;
        private TextBox tbOther;
        private Panel panel16;
        private Label label24;
        private TextBox tbHuanbingOth;
        private Label label18;
        private Label label20;
        private TextBox tbWaishang;
        private Label label14;
        private Label label17;
        private TextBox tbFuxie;
        private Label label7;
        private Label label2;
        private TextBox tbfeiyan;
        private CheckBox ckHuanbing;
        private Label label34;
        private Panel panel20;
        private RadioButton rdZhuanzhenHave;
        private RadioButton rdZhuanzhenNo;
        private Label label10;
        private TextBox tbZhuanzhenResult;
        private Label label68;
        private TextBox tbZhuanzhenKs;
        private Label label35;
        private Panel panel2;
        private TextBox tbGuides;
        private CheckBox ckGuides5;
        private CheckBox ckGuides4;
        private CheckBox ckGuides3;
        private CheckBox ckGuides2;
        private CheckBox ckGuides1;
        private Label label11;
        private DateTimePicker dtpNext;
        private Label label79;
        private TextBox tbDoctorMark;
        private Panel panel7;
        private ComboBox cbWdivH;
        private TextBox tbWdivH;
        private Label label23;
        private TextBox tbYey;
        private Label label26;
        private TextBox tbGllxr;
        private Label label27;
        private TextBox tbGllxdh;
        private Label label28;
        private ComboBox cbCtjg;
        private Panel panel4;
        private TextBox tbCtqt;
        private Panel panel6;
        private Label label29;
        private CheckBox ckGuides6;
        private Label label32;
        private TextBox tbZhuanzhenlxr;
        private Label label45;
        private TextBox tbZhuanzhenlxfs;
        private Label label46;
        private Panel panel14;
        private RadioButton rdDw2;
        private RadioButton rdDw1;
        private Button btnCalute;
        private Label label36;
        private LinkLabel lkJs;
        private JustSingleItem<KidsThreeToSixYearOldModel> zhuanzhen;
        private string SignS = "";
        private string SignDoc = "";//随访医生
        private Panel panel_fayu;
        private ComboBox cbFypg;
        private Label label30;
        private Panel panel11;
        private PictureBox picSignJs;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label37;
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public KidsOneYearOldVisitForm(int year)
        {
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();
            this.InitEveryOne();
            this.EveryThingIsOk = false;
            this.tableLayoutPanel1.ResumeLayout();
            this.yearAge = year;
        }

        private void btnSelectHB_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "52") {
                ItemTypeName = "血红蛋白",
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tbHem.Text = select.m_Result.value1;
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
                this.SaveDataInfo = "下次随访日期不能小于当前的随访日期！\r\n";
            }
            if (this.bindingManager.ErrorInput&&!flag)
            {
                return ChildFormStatus.HasErrorInput;
            }
            return ChildFormStatus.NoErrorInput;
        }

        private void ckHuanbing_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.ckHuanbing.Checked)
            {
                this.ChildThreeSix.AmongTwoFolloNone = "2";
                this.tbfeiyan.ReadOnly = false;
                this.tbFuxie.ReadOnly = false;
                this.tbHuanbingOth.ReadOnly = false;
                this.tbWaishang.ReadOnly = false;
            }
            else
            {
                this.ChildThreeSix.AmongTwoFolloNone = "1";
                this.tbfeiyan.Clear();
                this.tbWaishang.Clear();
                this.tbfeiyan.Clear();
                this.tbFuxie.Clear();
                this.tbHuanbingOth.Clear();
                this.tbFuxie.ReadOnly = true;
                this.tbfeiyan.ReadOnly = true;
                this.tbFuxie.ReadOnly = true;
                this.tbHuanbingOth.ReadOnly = true;
                this.tbWaishang.ReadOnly = true;
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

        private void FrmChild3_6_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {

                List<ItemDictonaryModel<string>> list1 = new List<ItemDictonaryModel<string>>();
                if (this.yearAge == 3)
                {
                    list1.Add(new ItemDictonaryModel<string>("不会说自己的名字", "1"));
                    list1.Add(new ItemDictonaryModel<string>("不会玩“拿棍当马骑”等假想游戏", "2"));
                    list1.Add(new ItemDictonaryModel<string>("不会模仿画圆", "3"));
                    list1.Add(new ItemDictonaryModel<string>("不会双脚跳", "4"));
                    this.SignS = string.Format("{0}{1}_Year_3.png", this.SignPath, this.Model.IDCardNo);
                    this.SignDoc = string.Format("{0}{1}_Year_3_Doc.png", this.SignPath, this.Model.IDCardNo);
                }
                if (this.yearAge == 4)
                {
                    list1.Add(new ItemDictonaryModel<string>("不会说带形容词的句子", "1"));
                    list1.Add(new ItemDictonaryModel<string>("不能按要求等待或轮流", "2"));
                    list1.Add(new ItemDictonaryModel<string>("不会独立穿衣", "3"));
                    list1.Add(new ItemDictonaryModel<string>("不会单脚站立", "4"));
                    this.SignS = string.Format("{0}{1}_Year_4.png", this.SignPath, this.Model.IDCardNo);
                    this.SignDoc = string.Format("{0}{1}_Year_4_Doc.png", this.SignPath, this.Model.IDCardNo);
                }
                if (this.yearAge == 5)
                {
                    list1.Add(new ItemDictonaryModel<string>("不能简单叙说事情经过", "1"));
                    list1.Add(new ItemDictonaryModel<string>("不知道自己的性别", "2"));
                    list1.Add(new ItemDictonaryModel<string>("不会用筷子吃饭", "3"));
                    list1.Add(new ItemDictonaryModel<string>("不会单脚跳", "4"));
                    this.SignS = string.Format("{0}{1}_Year_5.png", this.SignPath, this.Model.IDCardNo);
                    this.SignDoc = string.Format("{0}{1}_Year_5_Doc.png", this.SignPath, this.Model.IDCardNo);
                }
                if (this.yearAge == 6)
                {
                    list1.Add(new ItemDictonaryModel<string>("不会表达自己的感受或想法", "1"));
                    list1.Add(new ItemDictonaryModel<string>("不会玩角色扮演的集体游戏", "2"));
                    list1.Add(new ItemDictonaryModel<string>("不会画方形", "3"));
                    list1.Add(new ItemDictonaryModel<string>("不会奔跑", "4"));
                    this.SignS = string.Format("{0}{1}_Year_6.png", this.SignPath, this.Model.IDCardNo);
                    this.SignDoc = string.Format("{0}{1}_Year_6_Doc.png", this.SignPath, this.Model.IDCardNo);
                }

                this.cbFypg.DisplayMember = "DISPLAYMEMBER";
                this.cbFypg.ValueMember = "VALUEMEMBER";
                this.cbFypg.DataSource = list1;

                this.InitEveryThing();
            }
        }

        private void FrmChildYearOld_Paint(object sender, PaintEventArgs e)
        {
            if (this.yearAge == 3)
            {
                this.panel_shili.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
            if (this.yearAge == 4)
            {
                this.panel_tingli.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
            if (this.yearAge == 5)
            {
                this.panel_tingli.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
            if (this.yearAge == 6)
            {
                this.panel_tingli.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
        }

        private void InitEveryOne()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("请选择", "1"),
                new ItemDictonaryModel<string>("上", "2"),
                new ItemDictonaryModel<string>("中", "3"),
                new ItemDictonaryModel<string>("下", "4")
            };
            this.cbWeight.DisplayMember = "DISPLAYMEMBER";
            this.cbWeight.ValueMember = "VALUEMEMBER";
            this.cbWeight.DataSource = list;
            List<ItemDictonaryModel<string>> list2 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("请选择", "1"),
                new ItemDictonaryModel<string>("上", "2"),
                new ItemDictonaryModel<string>("中", "3"),
                new ItemDictonaryModel<string>("下", "4")
            };
            this.cbBodyLength.DisplayMember = "DISPLAYMEMBER";
            this.cbBodyLength.ValueMember = "VALUEMEMBER";
            this.cbBodyLength.DataSource = list2;

            List<ItemDictonaryModel<string>> list3 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("请选择", "1"),
                new ItemDictonaryModel<string>("上", "2"),
                new ItemDictonaryModel<string>("中", "3"),
                new ItemDictonaryModel<string>("下", "4")
            };
            this.cbWdivH.DisplayMember = "DISPLAYMEMBER";
            this.cbWdivH.ValueMember = "VALUEMEMBER";
            this.cbWdivH.DataSource = list3;

            List<ItemDictonaryModel<string>> list4 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("正常", "1"),
                new ItemDictonaryModel<string>("低体重", "2"),
                new ItemDictonaryModel<string>("消瘦", "3"),
                new ItemDictonaryModel<string>("发育迟缓", "4"),
                new ItemDictonaryModel<string>("超重", "5")
            };
            this.cbTig.DisplayMember = "DISPLAYMEMBER";
            this.cbTig.ValueMember = "VALUEMEMBER";
            this.cbTig.DataSource = list4;

   
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("Stature", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("BregmaLeft", 100M, false));
            this.inputRanges.Add(new InputRangeDec("BregmaRight", 100M, false));
            this.inputRanges.Add(new InputRangeDec("TeethDcnLeft", 100M, true, false));
            this.inputRanges.Add(new InputRangeDec("TeethDcnRight", 100M, true, false));
            this.inputRanges.Add(new InputRangeDec("HemoglobinValue", 10000M));
            this.inputRanges.Add(new InputRangeDec("OutdoorActivities", 24M, false));
            this.inputRanges.Add(new InputRangeDec("TakingVitaminsd", 100M));
            this.inputRanges.Add(new InputRangeDec("Sight", 20M, false));
            this.inputRanges.Add(new InputRangeDec("PneumoniaFrequen", 100M, true, false));
            this.inputRanges.Add(new InputRangeDec("DiarrhoeaFrequen", 100M, true, false));
            this.inputRanges.Add(new InputRangeDec("TraumatismFrequen", 100M, true, false));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("Other", 100));
            this.inputrange_str.Add(new InputRangeStr("ReferralReason", 500));
            this.inputrange_str.Add(new InputRangeStr("AgenciesDepartments", 80));
            this.inputrange_str.Add(new InputRangeStr("GuidanceOther", 100));
            this.inputrange_str.Add(new InputRangeStr("AmongTwoFolloOther", 200));
        }

        public void InitEveryThing()
        {
            List<KidsThreeToSixYearOldModel> modelList = new KidsThreeToSixYearOldBLL().GetModelList(string.Format(" Flag ='{0}' AND IDCardNo ='{1}' ", this.yearAge, this.Model.IDCardNo));
            if (modelList.Count > 0)
            {
                this.ChildThreeSix = modelList[0];
                this.ChildThreeSix.LastUpdateBy = ConfigHelper.GetNodeDec("doctor");
                this.ChildThreeSix.LastUpdateDate = DateTime.Today;
            }
            else
            {
                this.ChildThreeSix = new KidsThreeToSixYearOldModel();
                this.ChildThreeSix.IDCardNo = this.Model.IDCardNo;
                this.ChildThreeSix.RecordID = this.Model.RecordID;
                this.ChildThreeSix.CreateBy = ConfigHelper.GetNodeDec("doctor");
                this.ChildThreeSix.CreateDate = DateTime.Today;
                this.ChildThreeSix.AmongTwoFolloNone = "1";
                this.ChildThreeSix.Flag = this.yearAge.ToString();
            }
            if (string.IsNullOrEmpty(this.ChildThreeSix.VisitDoctorSign))
            {
                this.ChildThreeSix.VisitDoctorSign = ConfigHelper.GetNode("doctorName");
            }
            this.bindingManager = new SimpleBindingManager<KidsThreeToSixYearOldModel>(this.inputRanges, this.inputrange_str, this.ChildThreeSix);
            if (!this.ChildThreeSix.Weight.HasValue)
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                if (devData.HasValue)
                {
                    this.ChildThreeSix.Weight = new decimal?(decimal.Parse(devData.value1));
                }
            }
            if (!this.ChildThreeSix.HemoglobinValue.HasValue)
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "52", "血红蛋白");
                if (_result2.HasValue)
                {
                    this.ChildThreeSix.HemoglobinValue = new decimal?(decimal.Parse(_result2.value1));
                }
            }
            this.srcData = GlbTools.DeepCopy(this.ChildThreeSix);
            this.lbName.Text = this.Model.CustomerName;
            this.bindingManager.SimpleBinding(this.tbWeight, "Weight", true);
            this.bindingManager.SimpleBinding(this.cbWeight, "WeightAnalysis");
            this.bindingManager.SimpleBinding(this.tbBornLength, "Stature", true);
            this.bindingManager.SimpleBinding(this.cbBodyLength, "StatureAnalysis");
            if (this.ChildThreeSix.VisitDate.HasValue)
            {
                this.dtpVisit.Value = this.ChildThreeSix.VisitDate.Value;
            }
            this.bindingManager.SimpleBinding(this.cbTig, "PhysicalAuxeEvaluat");
            this.bindingManager.SimpleBinding(this.tbShili, "Sight", true);
            JustSingleItem<KidsThreeToSixYearOldModel> item = new JustSingleItem<KidsThreeToSixYearOldModel>(this.ChildThreeSix) {
                R1 = this.rdTingl1,
                R2 = this.rdTingl2
            };
            this.tingli = item;
            this.tingli.BindProperty("Listening");
            this.bindingManager.SimpleBinding(this.tbTooth, "TcnLeft", true);
            this.bindingManager.SimpleBinding(this.tbBedTooth, "TdcnRight", true);
            JustSingleItem<KidsThreeToSixYearOldModel> item2 = new JustSingleItem<KidsThreeToSixYearOldModel>(this.ChildThreeSix) {
                R1 = this.rdXiongb1,
                R2 = this.rdXiongb2
            };
            this.xiongb = item2;
            this.xiongb.BindProperty("Chest");
            JustSingleItem<KidsThreeToSixYearOldModel> item3 = new JustSingleItem<KidsThreeToSixYearOldModel>(this.ChildThreeSix) {
                R1 = this.rdFub1,
                R2 = this.rdFub2
            };
            this.fubu = item3;
            this.fubu.BindProperty("Stomach");
            this.bindingManager.SimpleBinding(this.tbHem, "HemoglobinValue", true);
            this.bindingManager.SimpleBinding(this.tbOther, "Other", false);
            if (!string.IsNullOrEmpty(this.ChildThreeSix.AmongTwoFolloNone))
            {
                this.ckHuanbing.Checked = (this.ChildThreeSix.AmongTwoFolloNone == "1") || !(this.ChildThreeSix.AmongTwoFolloNone == "2");
            }
            this.bindingManager.SimpleBinding(this.tbfeiyan, "PneumoniaFrequen", true);
            this.bindingManager.SimpleBinding(this.tbFuxie, "DiarrhoeaFrequen", true);
            this.bindingManager.SimpleBinding(this.tbWaishang, "TraumatismFrequen", true);
            this.bindingManager.SimpleBinding(this.tbHuanbingOth, "AmongTwoFolloOther", false);
            JustSingleItem<KidsThreeToSixYearOldModel> item4 = new JustSingleItem<KidsThreeToSixYearOldModel>(this.ChildThreeSix) {
                R1 = this.rdZhuanzhenNo,
                R2 = this.rdZhuanzhenHave
            };
            this.zhuanzhen = item4;
            this.zhuanzhen.statusChanged = (Action<string>) Delegate.Combine(this.zhuanzhen.statusChanged, new Action<string>(this.JustZhuanzhenChanged));
            this.zhuanzhen.BindProperty("ReferralAdvice");
            this.bindingManager.SimpleBinding(this.tbZhuanzhenResult, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenKs, "AgenciesDepartments", false);
            this.zhidao = new ManyCheckboxs<KidsThreeToSixYearOldModel>(this.ChildThreeSix);
            this.zhidao.AddCk(new CheckBox[] { this.ckGuides1, this.ckGuides2, this.ckGuides3, this.ckGuides4, this.ckGuides5 });
            this.zhidao.AddCk(this.ckGuides6, this.tbGuides);
            this.zhidao.BindingProperty("Guidance", "GuidanceOther");
            
            if (this.ChildThreeSix.NextVisitDate.HasValue)
            {
                this.dtpNext.Value = this.ChildThreeSix.NextVisitDate.Value;
            }

            this.bindingManager.SimpleBinding(this.tbDoctorMark, "VisitDoctorSign", false);
            if (this.ChildThreeSix.AmongTwoFolloNone == "1")
            {
                this.ckHuanbing.Checked = true;
            }
            else if (this.ChildThreeSix.AmongTwoFolloNone == "2")
            {
                this.ckHuanbing.Checked = false;
            }
            this.ckHuanbing_CheckedChanged(null, null);
            this.bindingManager.SimpleBinding(this.tbYey, "Kindergarten", false);
            this.bindingManager.SimpleBinding(this.tbGllxr, "ManagerContact", false);
            this.bindingManager.SimpleBinding(this.tbGllxdh, "ManagerContactTel", false);
            this.bindingManager.SimpleBinding(this.tbCtqt, "InstitutionOther", false);
            this.bindingManager.SimpleBinding(this.tbWdivH, "WeightVsHeight", true);
            this.bindingManager.SimpleBinding(this.cbWdivH, "WeightVsHeightAnalysis",false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenlxr, "ReferraContacts",false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenlxfs, "ReferralContactsTel", false);
            this.bindingManager.SimpleBinding(this.cbFypg, "AuxeEstimate");
            if (!string.IsNullOrEmpty(this.ChildThreeSix.BodyInstitution))
            {
                this.cbCtjg.SelectedIndex = int.Parse(this.ChildThreeSix.BodyInstitution) - 1;
            }
            if (this.ChildThreeSix.ReferralResult=="1")
            {
                this.rdDw1.Checked = true;
            }
            else if (this.ChildThreeSix.ReferralResult == "2")
            {
                this.rdDw2.Checked = true;
            }
            //签名初始化
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
            this.lbName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_fayu = new System.Windows.Forms.Panel();
            this.cbFypg = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnCalute = new System.Windows.Forms.Button();
            this.cbWdivH = new System.Windows.Forms.ComboBox();
            this.tbWdivH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_shili = new System.Windows.Forms.Panel();
            this.tbShili = new System.Windows.Forms.TextBox();
            this.dtpVisit = new System.Windows.Forms.DateTimePicker();
            this.label67 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.cbBodyLength = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbBornLength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_tingli = new System.Windows.Forms.Panel();
            this.rdTingl2 = new System.Windows.Forms.RadioButton();
            this.rdTingl1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBedTooth = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbTooth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rdXiongb2 = new System.Windows.Forms.RadioButton();
            this.rdXiongb1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdFub2 = new System.Windows.Forms.RadioButton();
            this.rdFub1 = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnSelectHB = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.tbHem = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbOther = new System.Windows.Forms.TextBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.tbHuanbingOth = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbWaishang = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbFuxie = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbfeiyan = new System.Windows.Forms.TextBox();
            this.ckHuanbing = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.rdZhuanzhenHave = new System.Windows.Forms.RadioButton();
            this.rdZhuanzhenNo = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.tbZhuanzhenResult = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.tbZhuanzhenKs = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckGuides6 = new System.Windows.Forms.CheckBox();
            this.tbGuides = new System.Windows.Forms.TextBox();
            this.ckGuides5 = new System.Windows.Forms.CheckBox();
            this.ckGuides4 = new System.Windows.Forms.CheckBox();
            this.ckGuides3 = new System.Windows.Forms.CheckBox();
            this.ckGuides2 = new System.Windows.Forms.CheckBox();
            this.ckGuides1 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.label79 = new System.Windows.Forms.Label();
            this.tbDoctorMark = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbWeight = new System.Windows.Forms.ComboBox();
            this.btnWeight = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbYey = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbGllxr = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbGllxdh = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cbCtjg = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbCtqt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbTig = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbZhuanzhenlxr = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.tbZhuanzhenlxfs = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.rdDw2 = new System.Windows.Forms.RadioButton();
            this.rdDw1 = new System.Windows.Forms.RadioButton();
            this.label30 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.label37 = new System.Windows.Forms.Label();
            this.lkJs = new System.Windows.Forms.LinkLabel();
            this.picSignJs = new System.Windows.Forms.PictureBox();
            this.label36 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_fayu.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel_shili.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel_tingli.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Font = new System.Drawing.Font("宋体", 15F);
            this.panel1.Location = new System.Drawing.Point(62, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1420, 662);
            this.panel1.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(47, 9);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 20);
            this.lbName.TabIndex = 176;
            this.lbName.Text = "姓名:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5648F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.42265F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.43307F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.03744F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.01526F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.52678F));
            this.tableLayoutPanel1.Controls.Add(this.panel_fayu, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel_shili, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpVisit, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label67, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label33, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel_tingli, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.label21, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel15, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.label25, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbOther, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel16, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.label34, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.panel20, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.label10, 3, 11);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenResult, 4, 11);
            this.tableLayoutPanel1.Controls.Add(this.label68, 5, 11);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenKs, 6, 11);
            this.tableLayoutPanel1.Controls.Add(this.label35, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.dtpNext, 2, 15);
            this.tableLayoutPanel1.Controls.Add(this.label79, 3, 15);
            this.tableLayoutPanel1.Controls.Add(this.tbDoctorMark, 4, 15);
            this.tableLayoutPanel1.Controls.Add(this.label9, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label23, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbYey, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label26, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbGllxr, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label27, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbGllxdh, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label28, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbCtjg, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label29, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label32, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenlxr, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.label45, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenlxfs, 4, 12);
            this.tableLayoutPanel1.Controls.Add(this.label46, 5, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 6, 12);
            this.tableLayoutPanel1.Controls.Add(this.label30, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 1, 16);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(51, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 17;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1331, 611);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_fayu
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_fayu, 2);
            this.panel_fayu.Controls.Add(this.cbFypg);
            this.panel_fayu.Location = new System.Drawing.Point(895, 179);
            this.panel_fayu.Margin = new System.Windows.Forms.Padding(0);
            this.panel_fayu.Name = "panel_fayu";
            this.panel_fayu.Size = new System.Drawing.Size(308, 34);
            this.panel_fayu.TabIndex = 273;
            // 
            // cbFypg
            // 
            this.cbFypg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFypg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFypg.FormattingEnabled = true;
            this.cbFypg.Location = new System.Drawing.Point(3, 4);
            this.cbFypg.Name = "cbFypg";
            this.cbFypg.Size = new System.Drawing.Size(266, 28);
            this.cbFypg.TabIndex = 261;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel7, 2);
            this.panel7.Controls.Add(this.btnCalute);
            this.panel7.Controls.Add(this.cbWdivH);
            this.panel7.Controls.Add(this.tbWdivH);
            this.panel7.Location = new System.Drawing.Point(196, 106);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(439, 36);
            this.panel7.TabIndex = 264;
            // 
            // btnCalute
            // 
            this.btnCalute.Location = new System.Drawing.Point(115, 3);
            this.btnCalute.Name = "btnCalute";
            this.btnCalute.Size = new System.Drawing.Size(57, 28);
            this.btnCalute.TabIndex = 3;
            this.btnCalute.Text = "计算";
            this.btnCalute.UseVisualStyleBackColor = true;
            this.btnCalute.Click += new System.EventHandler(this.btnCalute_Click);
            // 
            // cbWdivH
            // 
            this.cbWdivH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWdivH.FormattingEnabled = true;
            this.cbWdivH.Location = new System.Drawing.Point(198, 4);
            this.cbWdivH.Name = "cbWdivH";
            this.cbWdivH.Size = new System.Drawing.Size(121, 28);
            this.cbWdivH.TabIndex = 2;
            // 
            // tbWdivH
            // 
            this.tbWdivH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbWdivH.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWdivH.ForeColor = System.Drawing.Color.Black;
            this.tbWdivH.Location = new System.Drawing.Point(5, 1);
            this.tbWdivH.MaxLength = 3;
            this.tbWdivH.Name = "tbWdivH";
            this.tbWdivH.Size = new System.Drawing.Size(97, 30);
            this.tbWdivH.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 322);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.tableLayoutPanel1.SetRowSpan(this.label1, 2);
            this.label1.Size = new System.Drawing.Size(196, 69);
            this.label1.TabIndex = 175;
            this.label1.Text = "两次随访间患病情况:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_shili
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_shili, 2);
            this.panel_shili.Controls.Add(this.tbShili);
            this.panel_shili.Location = new System.Drawing.Point(196, 142);
            this.panel_shili.Margin = new System.Windows.Forms.Padding(0);
            this.panel_shili.Name = "panel_shili";
            this.panel_shili.Size = new System.Drawing.Size(308, 33);
            this.panel_shili.TabIndex = 4;
            // 
            // tbShili
            // 
            this.tbShili.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbShili.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbShili.ForeColor = System.Drawing.Color.Black;
            this.tbShili.Location = new System.Drawing.Point(3, 3);
            this.tbShili.MaxLength = 4;
            this.tbShili.Multiline = true;
            this.tbShili.Name = "tbShili";
            this.tbShili.Size = new System.Drawing.Size(180, 28);
            this.tbShili.TabIndex = 149;
            // 
            // dtpVisit
            // 
            this.dtpVisit.Location = new System.Drawing.Point(199, 3);
            this.dtpVisit.Name = "dtpVisit";
            this.dtpVisit.Size = new System.Drawing.Size(178, 30);
            this.dtpVisit.TabIndex = 0;
            // 
            // label67
            // 
            this.label67.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.Location = new System.Drawing.Point(0, 142);
            this.label67.Margin = new System.Windows.Forms.Padding(0);
            this.label67.Name = "label67";
            this.tableLayoutPanel1.SetRowSpan(this.label67, 5);
            this.label67.Size = new System.Drawing.Size(33, 180);
            this.label67.TabIndex = 184;
            this.label67.Text = "体格检查";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label13, 2);
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(190, 36);
            this.label13.TabIndex = 100;
            this.label13.Text = "随访日期:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(94, 150);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 20);
            this.label33.TabIndex = 164;
            this.label33.Text = "视    力:";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label16, 2);
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(3, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(190, 36);
            this.label16.TabIndex = 248;
            this.label16.Text = "身长(㎝):";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel12, 2);
            this.panel12.Controls.Add(this.cbBodyLength);
            this.panel12.Controls.Add(this.label12);
            this.panel12.Controls.Add(this.tbBornLength);
            this.panel12.Location = new System.Drawing.Point(196, 70);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(439, 36);
            this.panel12.TabIndex = 2;
            // 
            // cbBodyLength
            // 
            this.cbBodyLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodyLength.FormattingEnabled = true;
            this.cbBodyLength.Location = new System.Drawing.Point(198, 5);
            this.cbBodyLength.Name = "cbBodyLength";
            this.cbBodyLength.Size = new System.Drawing.Size(121, 28);
            this.cbBodyLength.TabIndex = 2;
            this.cbBodyLength.SelectedIndexChanged += new System.EventHandler(this.cbBodyLength_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(117, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "㎝";
            // 
            // tbBornLength
            // 
            this.tbBornLength.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbBornLength.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBornLength.ForeColor = System.Drawing.Color.Black;
            this.tbBornLength.Location = new System.Drawing.Point(5, 3);
            this.tbBornLength.MaxLength = 3;
            this.tbBornLength.Multiline = true;
            this.tbBornLength.Name = "tbBornLength";
            this.tbBornLength.Size = new System.Drawing.Size(97, 28);
            this.tbBornLength.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(793, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 245;
            this.label6.Text = "听    力:";
            // 
            // panel_tingli
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_tingli, 2);
            this.panel_tingli.Controls.Add(this.rdTingl2);
            this.panel_tingli.Controls.Add(this.rdTingl1);
            this.panel_tingli.Location = new System.Drawing.Point(895, 142);
            this.panel_tingli.Margin = new System.Windows.Forms.Padding(0);
            this.panel_tingli.Name = "panel_tingli";
            this.panel_tingli.Size = new System.Drawing.Size(308, 30);
            this.panel_tingli.TabIndex = 5;
            // 
            // rdTingl2
            // 
            this.rdTingl2.AutoSize = true;
            this.rdTingl2.Location = new System.Drawing.Point(130, 3);
            this.rdTingl2.Name = "rdTingl2";
            this.rdTingl2.Size = new System.Drawing.Size(87, 24);
            this.rdTingl2.TabIndex = 153;
            this.rdTingl2.TabStop = true;
            this.rdTingl2.Text = "未通过";
            this.rdTingl2.UseVisualStyleBackColor = true;
            // 
            // rdTingl1
            // 
            this.rdTingl1.AutoSize = true;
            this.rdTingl1.Location = new System.Drawing.Point(4, 3);
            this.rdTingl1.Name = "rdTingl1";
            this.rdTingl1.Size = new System.Drawing.Size(67, 24);
            this.rdTingl1.TabIndex = 152;
            this.rdTingl1.TabStop = true;
            this.rdTingl1.Text = "通过";
            this.rdTingl1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(44, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 242;
            this.label3.Text = "牙数/(龋齿数):";
            // 
            // panel9
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel9, 2);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Controls.Add(this.tbBedTooth);
            this.panel9.Controls.Add(this.label19);
            this.panel9.Controls.Add(this.tbTooth);
            this.panel9.Location = new System.Drawing.Point(196, 179);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(308, 34);
            this.panel9.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(137, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "颗";
            // 
            // tbBedTooth
            // 
            this.tbBedTooth.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbBedTooth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBedTooth.ForeColor = System.Drawing.Color.Black;
            this.tbBedTooth.Location = new System.Drawing.Point(89, 3);
            this.tbBedTooth.MaxLength = 2;
            this.tbBedTooth.Multiline = true;
            this.tbBedTooth.Name = "tbBedTooth";
            this.tbBedTooth.Size = new System.Drawing.Size(46, 28);
            this.tbBedTooth.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(61, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "/";
            // 
            // tbTooth
            // 
            this.tbTooth.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbTooth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTooth.ForeColor = System.Drawing.Color.Black;
            this.tbTooth.Location = new System.Drawing.Point(4, 2);
            this.tbTooth.MaxLength = 2;
            this.tbTooth.Multiline = true;
            this.tbTooth.Name = "tbTooth";
            this.tbTooth.Size = new System.Drawing.Size(46, 28);
            this.tbTooth.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(94, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 247;
            this.label8.Text = "胸    部:";
            // 
            // panel10
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel10, 2);
            this.panel10.Controls.Add(this.rdXiongb2);
            this.panel10.Controls.Add(this.rdXiongb1);
            this.panel10.Location = new System.Drawing.Point(196, 213);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(308, 36);
            this.panel10.TabIndex = 7;
            // 
            // rdXiongb2
            // 
            this.rdXiongb2.AutoSize = true;
            this.rdXiongb2.Location = new System.Drawing.Point(133, 5);
            this.rdXiongb2.Name = "rdXiongb2";
            this.rdXiongb2.Size = new System.Drawing.Size(67, 24);
            this.rdXiongb2.TabIndex = 153;
            this.rdXiongb2.TabStop = true;
            this.rdXiongb2.Text = "异常";
            this.rdXiongb2.UseVisualStyleBackColor = true;
            // 
            // rdXiongb1
            // 
            this.rdXiongb1.AutoSize = true;
            this.rdXiongb1.Location = new System.Drawing.Point(4, 5);
            this.rdXiongb1.Name = "rdXiongb1";
            this.rdXiongb1.Size = new System.Drawing.Size(107, 24);
            this.rdXiongb1.TabIndex = 152;
            this.rdXiongb1.TabStop = true;
            this.rdXiongb1.Text = "未见异常";
            this.rdXiongb1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(793, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 243;
            this.label4.Text = "腹    部:";
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.rdFub2);
            this.panel3.Controls.Add(this.rdFub1);
            this.panel3.Location = new System.Drawing.Point(895, 213);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(308, 34);
            this.panel3.TabIndex = 8;
            // 
            // rdFub2
            // 
            this.rdFub2.AutoSize = true;
            this.rdFub2.Location = new System.Drawing.Point(130, 6);
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
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(74, 260);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(119, 20);
            this.label21.TabIndex = 251;
            this.label21.Text = "血红蛋白值:";
            // 
            // panel15
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel15, 2);
            this.panel15.Controls.Add(this.btnSelectHB);
            this.panel15.Controls.Add(this.label22);
            this.panel15.Controls.Add(this.tbHem);
            this.panel15.Location = new System.Drawing.Point(196, 251);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(309, 36);
            this.panel15.TabIndex = 9;
            // 
            // btnSelectHB
            // 
            this.btnSelectHB.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectHB.Location = new System.Drawing.Point(150, 5);
            this.btnSelectHB.Name = "btnSelectHB";
            this.btnSelectHB.Size = new System.Drawing.Size(40, 27);
            this.btnSelectHB.TabIndex = 176;
            this.btnSelectHB.Text = "...";
            this.btnSelectHB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectHB.UseVisualStyleBackColor = true;
            this.btnSelectHB.Click += new System.EventHandler(this.btnSelectHB_Click);
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(102, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 20);
            this.label22.TabIndex = 149;
            this.label22.Text = "g/L";
            // 
            // tbHem
            // 
            this.tbHem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbHem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHem.ForeColor = System.Drawing.Color.Black;
            this.tbHem.Location = new System.Drawing.Point(5, 4);
            this.tbHem.MaxLength = 6;
            this.tbHem.Multiline = true;
            this.tbHem.Name = "tbHem";
            this.tbHem.Size = new System.Drawing.Size(97, 28);
            this.tbHem.TabIndex = 148;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(94, 296);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(99, 20);
            this.label25.TabIndex = 252;
            this.label25.Text = "其    他:";
            // 
            // tbOther
            // 
            this.tbOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.tbOther, 5);
            this.tbOther.ForeColor = System.Drawing.Color.Black;
            this.tbOther.Location = new System.Drawing.Point(199, 293);
            this.tbOther.MaxLength = 20;
            this.tbOther.Multiline = true;
            this.tbOther.Name = "tbOther";
            this.tbOther.Size = new System.Drawing.Size(795, 26);
            this.tbOther.TabIndex = 10;
            // 
            // panel16
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel16, 5);
            this.panel16.Controls.Add(this.label24);
            this.panel16.Controls.Add(this.tbHuanbingOth);
            this.panel16.Controls.Add(this.label18);
            this.panel16.Controls.Add(this.label20);
            this.panel16.Controls.Add(this.tbWaishang);
            this.panel16.Controls.Add(this.label14);
            this.panel16.Controls.Add(this.label17);
            this.panel16.Controls.Add(this.tbFuxie);
            this.panel16.Controls.Add(this.label7);
            this.panel16.Controls.Add(this.label2);
            this.panel16.Controls.Add(this.tbfeiyan);
            this.panel16.Controls.Add(this.ckHuanbing);
            this.panel16.Location = new System.Drawing.Point(196, 322);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.tableLayoutPanel1.SetRowSpan(this.panel16, 2);
            this.panel16.Size = new System.Drawing.Size(801, 68);
            this.panel16.TabIndex = 11;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(409, 39);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 20);
            this.label24.TabIndex = 161;
            this.label24.Text = "其他";
            // 
            // tbHuanbingOth
            // 
            this.tbHuanbingOth.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbHuanbingOth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHuanbingOth.ForeColor = System.Drawing.Color.Black;
            this.tbHuanbingOth.Location = new System.Drawing.Point(477, 37);
            this.tbHuanbingOth.MaxLength = 20;
            this.tbHuanbingOth.Multiline = true;
            this.tbHuanbingOth.Name = "tbHuanbingOth";
            this.tbHuanbingOth.ReadOnly = true;
            this.tbHuanbingOth.Size = new System.Drawing.Size(257, 28);
            this.tbHuanbingOth.TabIndex = 159;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(77, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 20);
            this.label18.TabIndex = 158;
            this.label18.Text = "外伤";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(231, 38);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 20);
            this.label20.TabIndex = 157;
            this.label20.Text = "次";
            // 
            // tbWaishang
            // 
            this.tbWaishang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbWaishang.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWaishang.ForeColor = System.Drawing.Color.Black;
            this.tbWaishang.Location = new System.Drawing.Point(134, 37);
            this.tbWaishang.MaxLength = 2;
            this.tbWaishang.Multiline = true;
            this.tbWaishang.Name = "tbWaishang";
            this.tbWaishang.ReadOnly = true;
            this.tbWaishang.Size = new System.Drawing.Size(97, 28);
            this.tbWaishang.TabIndex = 156;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(409, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 20);
            this.label14.TabIndex = 155;
            this.label14.Text = "腹泻";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(574, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 20);
            this.label17.TabIndex = 154;
            this.label17.Text = "次";
            // 
            // tbFuxie
            // 
            this.tbFuxie.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbFuxie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFuxie.ForeColor = System.Drawing.Color.Black;
            this.tbFuxie.Location = new System.Drawing.Point(477, 5);
            this.tbFuxie.MaxLength = 2;
            this.tbFuxie.Multiline = true;
            this.tbFuxie.Name = "tbFuxie";
            this.tbFuxie.ReadOnly = true;
            this.tbFuxie.Size = new System.Drawing.Size(97, 28);
            this.tbFuxie.TabIndex = 153;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(78, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 152;
            this.label7.Text = "肺炎";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(232, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 151;
            this.label2.Text = "次";
            // 
            // tbfeiyan
            // 
            this.tbfeiyan.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbfeiyan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbfeiyan.ForeColor = System.Drawing.Color.Black;
            this.tbfeiyan.Location = new System.Drawing.Point(135, 4);
            this.tbfeiyan.MaxLength = 2;
            this.tbfeiyan.Multiline = true;
            this.tbfeiyan.Name = "tbfeiyan";
            this.tbfeiyan.ReadOnly = true;
            this.tbfeiyan.Size = new System.Drawing.Size(97, 28);
            this.tbfeiyan.TabIndex = 150;
            // 
            // ckHuanbing
            // 
            this.ckHuanbing.AutoSize = true;
            this.ckHuanbing.Location = new System.Drawing.Point(4, 3);
            this.ckHuanbing.Name = "ckHuanbing";
            this.ckHuanbing.Size = new System.Drawing.Size(48, 24);
            this.ckHuanbing.TabIndex = 1;
            this.ckHuanbing.Text = "无";
            this.ckHuanbing.UseVisualStyleBackColor = true;
            this.ckHuanbing.CheckedChanged += new System.EventHandler(this.ckHuanbing_CheckedChanged);
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label34, 2);
            this.label34.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(3, 391);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(190, 36);
            this.label34.TabIndex = 177;
            this.label34.Text = "转诊建议:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.rdZhuanzhenHave);
            this.panel20.Controls.Add(this.rdZhuanzhenNo);
            this.panel20.Location = new System.Drawing.Point(199, 394);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(206, 30);
            this.panel20.TabIndex = 12;
            // 
            // rdZhuanzhenHave
            // 
            this.rdZhuanzhenHave.AutoSize = true;
            this.rdZhuanzhenHave.Location = new System.Drawing.Point(91, 3);
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
            this.rdZhuanzhenNo.Location = new System.Drawing.Point(4, 3);
            this.rdZhuanzhenNo.Name = "rdZhuanzhenNo";
            this.rdZhuanzhenNo.Size = new System.Drawing.Size(47, 24);
            this.rdZhuanzhenNo.TabIndex = 149;
            this.rdZhuanzhenNo.TabStop = true;
            this.rdZhuanzhenNo.Text = "无";
            this.rdZhuanzhenNo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(533, 399);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 181;
            this.label10.Text = "转诊原因:";
            // 
            // tbZhuanzhenResult
            // 
            this.tbZhuanzhenResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenResult.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenResult.Location = new System.Drawing.Point(638, 394);
            this.tbZhuanzhenResult.MaxLength = 20;
            this.tbZhuanzhenResult.Multiline = true;
            this.tbZhuanzhenResult.Name = "tbZhuanzhenResult";
            this.tbZhuanzhenResult.ReadOnly = true;
            this.tbZhuanzhenResult.Size = new System.Drawing.Size(176, 28);
            this.tbZhuanzhenResult.TabIndex = 13;
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label68.Location = new System.Drawing.Point(954, 399);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(119, 20);
            this.label68.TabIndex = 186;
            this.label68.Text = "机构及科室:";
            // 
            // tbZhuanzhenKs
            // 
            this.tbZhuanzhenKs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenKs.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenKs.Location = new System.Drawing.Point(1079, 394);
            this.tbZhuanzhenKs.MaxLength = 20;
            this.tbZhuanzhenKs.Multiline = true;
            this.tbZhuanzhenKs.Name = "tbZhuanzhenKs";
            this.tbZhuanzhenKs.ReadOnly = true;
            this.tbZhuanzhenKs.Size = new System.Drawing.Size(174, 28);
            this.tbZhuanzhenKs.TabIndex = 14;
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label35, 2);
            this.label35.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(3, 462);
            this.label35.Name = "label35";
            this.tableLayoutPanel1.SetRowSpan(this.label35, 2);
            this.label35.Size = new System.Drawing.Size(190, 61);
            this.label35.TabIndex = 177;
            this.label35.Text = "指    导:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 5);
            this.panel2.Controls.Add(this.ckGuides6);
            this.panel2.Controls.Add(this.tbGuides);
            this.panel2.Controls.Add(this.ckGuides5);
            this.panel2.Controls.Add(this.ckGuides4);
            this.panel2.Controls.Add(this.ckGuides3);
            this.panel2.Controls.Add(this.ckGuides2);
            this.panel2.Controls.Add(this.ckGuides1);
            this.panel2.Location = new System.Drawing.Point(196, 462);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(801, 60);
            this.panel2.TabIndex = 15;
            // 
            // ckGuides6
            // 
            this.ckGuides6.AutoSize = true;
            this.ckGuides6.Location = new System.Drawing.Point(625, 3);
            this.ckGuides6.Name = "ckGuides6";
            this.ckGuides6.Size = new System.Drawing.Size(68, 24);
            this.ckGuides6.TabIndex = 187;
            this.ckGuides6.Text = "其他";
            this.ckGuides6.UseVisualStyleBackColor = true;
            // 
            // tbGuides
            // 
            this.tbGuides.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGuides.ForeColor = System.Drawing.Color.Black;
            this.tbGuides.Location = new System.Drawing.Point(6, 28);
            this.tbGuides.MaxLength = 20;
            this.tbGuides.Multiline = true;
            this.tbGuides.Name = "tbGuides";
            this.tbGuides.ReadOnly = true;
            this.tbGuides.Size = new System.Drawing.Size(792, 28);
            this.tbGuides.TabIndex = 186;
            // 
            // ckGuides5
            // 
            this.ckGuides5.AutoSize = true;
            this.ckGuides5.Location = new System.Drawing.Point(498, 3);
            this.ckGuides5.Name = "ckGuides5";
            this.ckGuides5.Size = new System.Drawing.Size(108, 24);
            this.ckGuides5.TabIndex = 4;
            this.ckGuides5.Text = "口腔保健";
            this.ckGuides5.UseVisualStyleBackColor = true;
            // 
            // ckGuides4
            // 
            this.ckGuides4.AutoSize = true;
            this.ckGuides4.Location = new System.Drawing.Point(372, 3);
            this.ckGuides4.Name = "ckGuides4";
            this.ckGuides4.Size = new System.Drawing.Size(108, 24);
            this.ckGuides4.TabIndex = 3;
            this.ckGuides4.Text = "预防伤害";
            this.ckGuides4.UseVisualStyleBackColor = true;
            // 
            // ckGuides3
            // 
            this.ckGuides3.AutoSize = true;
            this.ckGuides3.Location = new System.Drawing.Point(247, 3);
            this.ckGuides3.Name = "ckGuides3";
            this.ckGuides3.Size = new System.Drawing.Size(108, 24);
            this.ckGuides3.TabIndex = 2;
            this.ckGuides3.Text = "疾病预防";
            this.ckGuides3.UseVisualStyleBackColor = true;
            // 
            // ckGuides2
            // 
            this.ckGuides2.AutoSize = true;
            this.ckGuides2.Location = new System.Drawing.Point(125, 3);
            this.ckGuides2.Name = "ckGuides2";
            this.ckGuides2.Size = new System.Drawing.Size(108, 24);
            this.ckGuides2.TabIndex = 1;
            this.ckGuides2.Text = "生长发育";
            this.ckGuides2.UseVisualStyleBackColor = true;
            // 
            // ckGuides1
            // 
            this.ckGuides1.AutoSize = true;
            this.ckGuides1.Location = new System.Drawing.Point(6, 3);
            this.ckGuides1.Name = "ckGuides1";
            this.ckGuides1.Size = new System.Drawing.Size(108, 24);
            this.ckGuides1.TabIndex = 0;
            this.ckGuides1.Text = "合理膳食";
            this.ckGuides1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label11, 2);
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(3, 523);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(190, 36);
            this.label11.TabIndex = 178;
            this.label11.Text = "下次随访日期:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpNext
            // 
            this.dtpNext.Location = new System.Drawing.Point(199, 526);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(167, 30);
            this.dtpNext.TabIndex = 16;
            // 
            // label79
            // 
            this.label79.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label79.Location = new System.Drawing.Point(493, 531);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(139, 20);
            this.label79.TabIndex = 190;
            this.label79.Text = "随访医生签名:";
            this.label79.Visible = false;
            // 
            // tbDoctorMark
            // 
            this.tbDoctorMark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDoctorMark.ForeColor = System.Drawing.Color.Black;
            this.tbDoctorMark.Location = new System.Drawing.Point(638, 526);
            this.tbDoctorMark.MaxLength = 20;
            this.tbDoctorMark.Name = "tbDoctorMark";
            this.tbDoctorMark.Size = new System.Drawing.Size(164, 30);
            this.tbDoctorMark.TabIndex = 17;
            this.tbDoctorMark.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(793, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 153;
            this.label9.Text = "体    重:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel5, 2);
            this.panel5.Controls.Add(this.cbWeight);
            this.panel5.Controls.Add(this.btnWeight);
            this.panel5.Controls.Add(this.label31);
            this.panel5.Controls.Add(this.tbWeight);
            this.panel5.Location = new System.Drawing.Point(895, 70);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(436, 36);
            this.panel5.TabIndex = 1;
            // 
            // cbWeight
            // 
            this.cbWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeight.FormattingEnabled = true;
            this.cbWeight.Location = new System.Drawing.Point(217, 5);
            this.cbWeight.Name = "cbWeight";
            this.cbWeight.Size = new System.Drawing.Size(121, 28);
            this.cbWeight.TabIndex = 3;
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(153, 3);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(44, 32);
            this.btnWeight.TabIndex = 2;
            this.btnWeight.Text = ".....";
            this.btnWeight.UseVisualStyleBackColor = true;
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(118, 11);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 20);
            this.label31.TabIndex = 1;
            this.label31.Text = "㎏";
            // 
            // tbWeight
            // 
            this.tbWeight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWeight.ForeColor = System.Drawing.Color.Black;
            this.tbWeight.Location = new System.Drawing.Point(7, 5);
            this.tbWeight.MaxLength = 6;
            this.tbWeight.Multiline = true;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.ReadOnly = true;
            this.tbWeight.Size = new System.Drawing.Size(97, 28);
            this.tbWeight.TabIndex = 0;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(513, 8);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(119, 20);
            this.label23.TabIndex = 253;
            this.label23.Text = "所在幼儿园:";
            // 
            // tbYey
            // 
            this.tbYey.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbYey.Location = new System.Drawing.Point(638, 3);
            this.tbYey.Name = "tbYey";
            this.tbYey.Size = new System.Drawing.Size(178, 30);
            this.tbYey.TabIndex = 254;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(898, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(175, 20);
            this.label26.TabIndex = 255;
            this.label26.Text = "健康管理联系人:";
            // 
            // tbGllxr
            // 
            this.tbGllxr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGllxr.Location = new System.Drawing.Point(1079, 3);
            this.tbGllxr.Name = "tbGllxr";
            this.tbGllxr.Size = new System.Drawing.Size(171, 30);
            this.tbGllxr.TabIndex = 256;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(94, 43);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(99, 20);
            this.label27.TabIndex = 257;
            this.label27.Text = "联系电话:";
            // 
            // tbGllxdh
            // 
            this.tbGllxdh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGllxdh.Location = new System.Drawing.Point(199, 39);
            this.tbGllxdh.Name = "tbGllxdh";
            this.tbGllxdh.Size = new System.Drawing.Size(173, 30);
            this.tbGllxdh.TabIndex = 258;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(533, 43);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(99, 20);
            this.label28.TabIndex = 259;
            this.label28.Text = "查体机构:";
            // 
            // cbCtjg
            // 
            this.cbCtjg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCtjg.FormattingEnabled = true;
            this.cbCtjg.Items.AddRange(new object[] {
            "本机构",
            "幼儿园",
            "其他医疗机构"});
            this.cbCtjg.Location = new System.Drawing.Point(638, 39);
            this.cbCtjg.Name = "cbCtjg";
            this.cbCtjg.Size = new System.Drawing.Size(178, 28);
            this.cbCtjg.TabIndex = 260;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.tbCtqt);
            this.panel4.Location = new System.Drawing.Point(895, 36);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(436, 34);
            this.panel4.TabIndex = 261;
            // 
            // tbCtqt
            // 
            this.tbCtqt.Location = new System.Drawing.Point(5, 2);
            this.tbCtqt.Name = "tbCtqt";
            this.tbCtqt.Size = new System.Drawing.Size(297, 30);
            this.tbCtqt.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(753, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(139, 20);
            this.label15.TabIndex = 249;
            this.label15.Text = "体格发育评价:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 2);
            this.panel6.Controls.Add(this.cbTig);
            this.panel6.Location = new System.Drawing.Point(895, 106);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(310, 36);
            this.panel6.TabIndex = 262;
            // 
            // cbTig
            // 
            this.cbTig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTig.FormattingEnabled = true;
            this.cbTig.Location = new System.Drawing.Point(4, 4);
            this.cbTig.Name = "cbTig";
            this.cbTig.Size = new System.Drawing.Size(180, 28);
            this.cbTig.TabIndex = 3;
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(84, 114);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(109, 20);
            this.label29.TabIndex = 263;
            this.label29.Text = "体重/身高:";
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(114, 434);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(79, 20);
            this.label32.TabIndex = 265;
            this.label32.Text = "联系人:";
            // 
            // tbZhuanzhenlxr
            // 
            this.tbZhuanzhenlxr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenlxr.Location = new System.Drawing.Point(199, 430);
            this.tbZhuanzhenlxr.Name = "tbZhuanzhenlxr";
            this.tbZhuanzhenlxr.ReadOnly = true;
            this.tbZhuanzhenlxr.Size = new System.Drawing.Size(181, 30);
            this.tbZhuanzhenlxr.TabIndex = 266;
            // 
            // label45
            // 
            this.label45.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(533, 434);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(99, 20);
            this.label45.TabIndex = 267;
            this.label45.Text = "联系方式:";
            // 
            // tbZhuanzhenlxfs
            // 
            this.tbZhuanzhenlxfs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenlxfs.Location = new System.Drawing.Point(638, 430);
            this.tbZhuanzhenlxfs.Name = "tbZhuanzhenlxfs";
            this.tbZhuanzhenlxfs.ReadOnly = true;
            this.tbZhuanzhenlxfs.Size = new System.Drawing.Size(178, 30);
            this.tbZhuanzhenlxfs.TabIndex = 268;
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(984, 434);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(89, 20);
            this.label46.TabIndex = 269;
            this.label46.Text = "是否到位";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.rdDw2);
            this.panel14.Controls.Add(this.rdDw1);
            this.panel14.Enabled = false;
            this.panel14.Location = new System.Drawing.Point(1079, 430);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(224, 29);
            this.panel14.TabIndex = 270;
            // 
            // rdDw2
            // 
            this.rdDw2.AutoSize = true;
            this.rdDw2.Location = new System.Drawing.Point(102, 3);
            this.rdDw2.Name = "rdDw2";
            this.rdDw2.Size = new System.Drawing.Size(87, 24);
            this.rdDw2.TabIndex = 1;
            this.rdDw2.TabStop = true;
            this.rdDw2.Text = "不到位";
            this.rdDw2.UseVisualStyleBackColor = true;
            // 
            // rdDw1
            // 
            this.rdDw1.AutoSize = true;
            this.rdDw1.Location = new System.Drawing.Point(4, 3);
            this.rdDw1.Name = "rdDw1";
            this.rdDw1.Size = new System.Drawing.Size(67, 24);
            this.rdDw1.TabIndex = 0;
            this.rdDw1.TabStop = true;
            this.rdDw1.Text = "到位";
            this.rdDw1.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(793, 186);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(99, 20);
            this.label30.TabIndex = 274;
            this.label30.Text = "发育评估:";
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel11, 6);
            this.panel11.Controls.Add(this.lkYs);
            this.panel11.Controls.Add(this.picSignYs);
            this.panel11.Controls.Add(this.label37);
            this.panel11.Controls.Add(this.lkJs);
            this.panel11.Controls.Add(this.picSignJs);
            this.panel11.Controls.Add(this.label36);
            this.panel11.Location = new System.Drawing.Point(33, 559);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1298, 52);
            this.panel11.TabIndex = 275;
            this.panel11.Paint += new System.Windows.Forms.PaintEventHandler(this.panel11_Paint);
            // 
            // lkYs
            // 
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(383, 20);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 274;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(167, 6);
            this.picSignYs.Margin = new System.Windows.Forms.Padding(0);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(191, 42);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 273;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // label37
            // 
            this.label37.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(20, 14);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(139, 20);
            this.label37.TabIndex = 275;
            this.label37.Text = "随访医生签名:";
            // 
            // lkJs
            // 
            this.lkJs.AutoSize = true;
            this.lkJs.Location = new System.Drawing.Point(1130, 19);
            this.lkJs.Name = "lkJs";
            this.lkJs.Size = new System.Drawing.Size(89, 20);
            this.lkJs.TabIndex = 177;
            this.lkJs.TabStop = true;
            this.lkJs.Text = "重置签名";
            this.lkJs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // picSignJs
            // 
            this.picSignJs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJs.Location = new System.Drawing.Point(914, 7);
            this.picSignJs.Margin = new System.Windows.Forms.Padding(0);
            this.picSignJs.Name = "picSignJs";
            this.picSignJs.Size = new System.Drawing.Size(191, 42);
            this.picSignJs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJs.TabIndex = 0;
            this.picSignJs.TabStop = false;
            this.picSignJs.Click += new System.EventHandler(this.picSignJs_Click);
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(809, 18);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(99, 20);
            this.label36.TabIndex = 271;
            this.label36.Text = "家长签名:";
            // 
            // KidsOneYearOldVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "KidsOneYearOldVisitForm";
            this.Text = "KitsThreeToSix";
            this.Load += new System.EventHandler(this.FrmChild3_6_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmChildYearOld_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_fayu.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel_shili.ResumeLayout(false);
            this.panel_shili.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel_tingli.ResumeLayout(false);
            this.panel_tingli.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).EndInit();
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
                this.tbZhuanzhenlxr.Clear();
                this.tbZhuanzhenlxr.ReadOnly = true;
                this.tbZhuanzhenlxfs.Clear();
                this.tbZhuanzhenlxfs.ReadOnly = true;
                this.rdDw1.Checked = false;
                this.rdDw2.Checked = false;
                this.panel14.Enabled = false;
            }
            if (haf == "2")
            {
                this.tbZhuanzhenKs.ReadOnly = false;
                this.tbZhuanzhenResult.ReadOnly = false;
                this.tbZhuanzhenlxr.ReadOnly = false;
                this.tbZhuanzhenlxfs.ReadOnly = false;
                this.panel14.Enabled = true;
            }
        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            if (GlbTools.IsChanged(this.srcData, this.ChildThreeSix, new string[] { "AmongTwoFolloNone", "VisitDate", "NextVisitDate", "VisitDoctorSign" }))
            {
               
                KidsThreeToSixYearOldBLL child_threesix_year_old = new KidsThreeToSixYearOldBLL();
                if (child_threesix_year_old.Exists(this.ChildThreeSix.ID))
                {
                    child_threesix_year_old.Update(this.ChildThreeSix);
                }
                else
                {
                    child_threesix_year_old.Add(this.ChildThreeSix);
                }
            }
            return true;
        }

        private void tbBornLength_TextChanged(object sender, EventArgs e)
        {
            if (this.tbBornLength.Text != "")
            {
                this.cbBodyLength.Enabled = true;
            }
            else
            {
                this.cbBodyLength.SelectedIndex = -1;
                this.cbBodyLength.Enabled = false;
            }
        }

        private void tbWeight_TextChanged(object sender, EventArgs e)
        {
            if (this.tbWeight.Text != "")
            {
                this.cbWeight.Enabled = true;
            }
            else
            {
                this.cbWeight.SelectedIndex = -1;
                this.cbWeight.Enabled = false;
            }
        }

        public void UpdataToModel()
        {
            if (this.ckHuanbing.Checked)
            {
                this.ChildThreeSix.AmongTwoFolloNone = "1";
            }
            this.ChildThreeSix.VisitDate = new DateTime?(this.dtpVisit.Value.Date);
            this.ChildThreeSix.NextVisitDate = new DateTime?(this.dtpNext.Value.Date);
            if (this.rdDw1.Checked)
            {
                this.ChildThreeSix.ReferralResult = "1";
            }
            else if (this.rdDw2.Checked)
            {
                this.ChildThreeSix.ReferralResult = "2";
            }
            else
            {
                this.ChildThreeSix.ReferralResult = null;
            }
            if (this.cbCtjg.SelectedIndex!=-1)
            {
                this.ChildThreeSix.BodyInstitution = Convert.ToString(this.cbCtjg.SelectedIndex+1);
            }
        }

        private KidsThreeToSixYearOldModel ChildThreeSix { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public object srcData { get; set; }

        private void btnCalute_Click(object sender, EventArgs e)
        {
            decimal num;
            decimal num2;
            if ((decimal.TryParse(this.tbBornLength.Text, out num) && decimal.TryParse(this.tbWeight.Text, out num2)) && (num != 0M))
            {
                this.tbWdivH.Text = (num2 / num).ToString("0.00");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.yearAge == 3)
            {
                Clear("_Year_3", picSignJs);
            }
            if (this.yearAge == 4)
            {
                Clear("_Year_4", picSignJs);
            }
            if (this.yearAge == 5)
            {
                Clear("_Year_5", picSignJs);
            }
            if (this.yearAge == 6)
            {
                Clear("_Year_6", picSignJs);
            }
        }

        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.yearAge == 3)
            {
                Clear("_Year_3_Doc", picSignYs);
            }
            if (this.yearAge == 4)
            {
                Clear("_Year_4_Doc", picSignYs);
            }
            if (this.yearAge == 5)
            {
                Clear("_Year_5_Doc", picSignYs);
            }
            if (this.yearAge == 6)
            {
                Clear("_Year_6_Doc", picSignYs);
            }
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

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbBodyLength_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picSignYs_Click(object sender, EventArgs e)
        {
            if (this.yearAge == 3)
            {
                Sign("_Year_3_Doc", picSignYs);
            }
            if (this.yearAge == 4)
            {
                Sign("_Year_4_Doc", picSignYs);
            }
            if (this.yearAge == 5)
            {
                Sign("_Year_5_Doc", picSignYs);
            }
            if (this.yearAge == 6)
            {
                Sign("_Year_6_Doc", picSignYs);
            }
        }

        private void picSignJs_Click(object sender, EventArgs e)
        {
            if (this.yearAge == 3)
            {
                Sign("_Year_3", picSignJs);
            }
            if (this.yearAge == 4)
            {
                Sign("_Year_4", picSignJs);
            }
            if (this.yearAge == 5)
            {
                Sign("_Year_5", picSignJs);
            }
            if (this.yearAge == 6)
            {
                Sign("_Year_6", picSignJs);
            }
        }
    }
}

