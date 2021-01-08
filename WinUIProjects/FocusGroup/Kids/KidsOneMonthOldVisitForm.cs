
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
    public class KidsOneMonthOldVisitForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<KidsOneToThreeYearOldModel> bindingManager;
        private JustSingleItem<KidsOneToThreeYearOldModel> butai;
        private IContainer components;
        private JustSingleItem<KidsOneToThreeYearOldModel> erwaiguan;
        private JustSingleItem<KidsOneToThreeYearOldModel> fubu;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private JustSingleItem<KidsOneToThreeYearOldModel> mianse;
        private int monthAgeIndex = 1;
        private JustSingleItem<KidsOneToThreeYearOldModel> qianxin;
        private JustSingleItem<KidsOneToThreeYearOldModel> sizhi;
        private JustSingleItem<KidsOneToThreeYearOldModel> skin;
        private JustSingleItem<KidsOneToThreeYearOldModel> tingli;
        private JustSingleItem<KidsOneToThreeYearOldModel> xiongbu;
        private JustSingleItem<KidsOneToThreeYearOldModel> yanwaiguan;
        private ManyCheckboxs<KidsOneToThreeYearOldModel> zhidao;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSelectHB;
        private Label label11;
        private Panel panel2;
        private TextBox tbGuides;
        private CheckBox ckGuides5;
        private CheckBox ckGuides4;
        private CheckBox ckGuides3;
        private CheckBox ckGuides2;
        private CheckBox ckGuides1;
        private Label label35;
        private Label label34;
        private Label label32;
        private Panel panel19;
        private Panel panel_fayu;
        private Label label30;
        private Panel panel16;
        private Label label24;
        private TextBox tbOutSport;
        private Label label23;
        private Panel panel_hem;
        private Label lbHem;
        private TextBox tbHem;
        private Panel panel_gltizh;
        private Panel panel_butai;
        private RadioButton rdBut2;
        private RadioButton rdBut1;
        private Panel panel11;
        private RadioButton rdSiz2;
        private RadioButton rdSiz1;
        private Panel panel3;
        private RadioButton rdFub2;
        private RadioButton rdFub1;
        private Panel panel10;
        private RadioButton rdXiongb2;
        private RadioButton rdXiongb1;
        private Panel panel9;
        private Label label15;
        private TextBox tbBedTooth;
        private Label label19;
        private TextBox tbTooth;
        private Panel panel_tingli;
        private RadioButton rdTingl2;
        private RadioButton rdTingl1;
        private Panel panel7;
        private RadioButton rdEr2;
        private RadioButton rdEr1;
        private Panel panel6;
        private RadioButton rdYanwaiguan2;
        private RadioButton rdYanwaiguan1;
        private Panel panel_qianxin;
        private Label lbQianxin2;
        private TextBox tbQianXb;
        private Label lbQianxin1;
        private TextBox tbQianXa;
        private RadioButton rdQianX2;
        private RadioButton rdQianX1;
        private Label label1;
        private Panel panel4;
        private RadioButton rdSkin2;
        private RadioButton rdSkin1;
        private Panel panel36;
        private RadioButton rdMianse2;
        private RadioButton rdMianse1;
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
        private Label label29;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label7;
        private Label label16;
        private Panel panel12;
        private ComboBox cbBodyLength;
        private Label label12;
        private TextBox tbBornLength;
        private Label label20;
        private Label label18;
        private Label label21;
        private Label label25;
        private Panel panel_vd;
        private Label lbVD;
        private TextBox tbVD;
        private Panel panel20;
        private RadioButton rdZhuanzhenHave;
        private RadioButton rdZhuanzhenNo;
        private TextBox tbZhuanzhenResult;
        private Label label10;
        private Label label68;
        private TextBox tbZhuanzhenKs;
        private DateTimePicker dtpNext;
        private Label label79;
        private TextBox tbDoctorMark;
        private Label lbName;
        private RadioButton rdMianse3;
        private ComboBox cbGLTizh;
        private ComboBox cbFypg;
        private Panel panel8;
        private Label label43;
        private TextBox tbHbqt;
        private Label label44;
        private Label label41;
        private TextBox tbWscs;
        private Label label42;
        private Label label39;
        private TextBox tbFxcs;
        private Label label40;
        private Label label38;
        private TextBox tbFycs;
        private Label label37;
        private Label label14;
        private TextBox tbZhuanzhenlxr;
        private Label label45;
        private TextBox tbZhuanzhenlxfs;
        private Label label46;
        private Panel panel14;
        private RadioButton rdDw2;
        private RadioButton rdDw1;
        private CheckBox ckGuides6;
        private Label label17;
        private PictureBox picSignJs;
        private LinkLabel lkJs;
        private JustSingleItem<KidsOneToThreeYearOldModel> zhuanzhen;
        private string SignS = "";
        private string SignDoc = "";//医生签名
        private Panel panel15;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label22;
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径
        
        public KidsOneMonthOldVisitForm(int index)
        {
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();
            //this.InitEveryOne();
            this.EveryThingIsOk = false;
            this.tableLayoutPanel1.ResumeLayout();
            this.monthAgeIndex = index;
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
            if (this.bindingManager.ErrorInput && !flag)
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

        private void FrmChild_1to2_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryOne();
                this.InitEveryThing();
            }
            if (this.monthAgeIndex == 1)
            {
                this.butai.MVisiable = false;
                this.tbHem.Visible = false;
                this.lbHem.Visible = false;
                this.SignS = string.Format("{0}{1}_Month_12.png", this.SignPath, this.Model.IDCardNo);
                this.SignDoc = string.Format("{0}{1}_Month_12_Doc.png", this.SignPath, this.Model.IDCardNo);
            }
            if (this.monthAgeIndex == 2)
            {
                this.tingli.MVisiable = false;
                this.SignS = string.Format("{0}{1}_Month_18.png", this.SignPath, this.Model.IDCardNo);
                this.SignDoc = string.Format("{0}{1}_Month_18_Doc.png", this.SignPath, this.Model.IDCardNo);
            }
            if (this.monthAgeIndex == 3)
            {
                this.ckGuides1.Text = "合理膳食";
                this.tbHem.Visible = false;
                this.lbHem.Visible = false;
                this.SignS = string.Format("{0}{1}_Month_24.png", this.SignPath, this.Model.IDCardNo);
                this.SignDoc = string.Format("{0}{1}_Month_24_Doc.png", this.SignPath, this.Model.IDCardNo);
            }
            if (this.monthAgeIndex == 4)
            {
                this.ckGuides1.Text = "合理膳食";
                this.qianxin.MVisiable = false;
                this.tbQianXa.Visible = false;
                this.tbQianXb.Visible = false;
                this.lbQianxin1.Visible = false;
                this.lbQianxin2.Visible = false;
                this.tingli.MVisiable = false;
                //this.goulouzheng.v = false;
                this.panel_gltizh.Visible = false;
                this.tbVD.Visible = false;
                this.lbVD.Visible = false;
                this.SignS = string.Format("{0}{1}_Month_30.png", this.SignPath, this.Model.IDCardNo);
                this.SignDoc = string.Format("{0}{1}_Month_30_Doc.png", this.SignPath, this.Model.IDCardNo);
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
        }

        private void FrmChildMonthAge_Paint(object sender, PaintEventArgs e)
        {
            if (this.monthAgeIndex == 1)
            {
                this.panel_butai.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
                this.panel_hem.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
            if (this.monthAgeIndex == 2)
            {
                this.panel_tingli.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
            if (this.monthAgeIndex == 3)
            {
                this.panel_hem.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
            if (this.monthAgeIndex == 4)
            {
                this.panel_qianxin.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
                this.panel_tingli.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
                this.panel_gltizh.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
                this.panel_vd.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
                this.panel_gltizh.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
                this.panel_fayu.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
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
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("Stature", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("BregmaLeft", 100M, false));
            this.inputRanges.Add(new InputRangeDec("BregmaRight", 100M, false));
            this.inputRanges.Add(new InputRangeDec("TeethDcnLeft", 100M, true, false));
            this.inputRanges.Add(new InputRangeDec("TeethDcnRight", 100M, true, false));
            this.inputRanges.Add(new InputRangeDec("HemoglobinValue", 1000M));
            this.inputRanges.Add(new InputRangeDec("OutdoorActivities", 24M, false));
            this.inputRanges.Add(new InputRangeDec("TakingVitaminsd", 100M));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("Other", 100));
            this.inputrange_str.Add(new InputRangeStr("ReferralReason", 500));
            this.inputrange_str.Add(new InputRangeStr("AgenciesDepartments", 80));
            this.inputrange_str.Add(new InputRangeStr("GuidanceOther", 100));
            List<ItemDictonaryModel<string>> list3 = new List<ItemDictonaryModel<string>>();
            if (this.monthAgeIndex == 1)
            {
                this.cbGLTizh.Visible = false;
            }
            else
            {
                list3.Add(new ItemDictonaryModel<string>("无", "1"));
                list3.Add(new ItemDictonaryModel<string>("肋串珠", "2"));
                list3.Add(new ItemDictonaryModel<string>("肋软骨沟", "3"));
                list3.Add(new ItemDictonaryModel<string>("鸡胸", "4"));
                list3.Add(new ItemDictonaryModel<string>("手足镯", "5"));
                list3.Add(new ItemDictonaryModel<string>("“O”型腿", "6"));
                list3.Add(new ItemDictonaryModel<string>("“X”型腿", "7"));
            }

            this.cbGLTizh.DisplayMember = "DISPLAYMEMBER";
            this.cbGLTizh.ValueMember = "VALUEMEMBER";
            this.cbGLTizh.DataSource = list3;

            List<ItemDictonaryModel<string>> list4 = new List<ItemDictonaryModel<string>>();
            if (this.monthAgeIndex == 1)
            {
                list4.Add(new ItemDictonaryModel<string>("呼唤名字无反应", "1"));
                list4.Add(new ItemDictonaryModel<string>("不会模仿“再见”或“欢迎”动作", "2"));
                list4.Add(new ItemDictonaryModel<string>("不会用拇食指对捏小物品", "3"));
                list4.Add(new ItemDictonaryModel<string>("不会扶物站立", "4"));
            }
            else if (this.monthAgeIndex == 2)
            {
                list4.Add(new ItemDictonaryModel<string>("不会有意识叫“爸爸”或“妈妈”", "1"));
                list4.Add(new ItemDictonaryModel<string>("不会按要求指人或物", "2"));
                list4.Add(new ItemDictonaryModel<string>("与人无目光交流", "3"));
                list4.Add(new ItemDictonaryModel<string>("不会独走", "4"));
            }
            else if (this.monthAgeIndex == 3)
            {
                list4.Add(new ItemDictonaryModel<string>("不会说3个物品的名称", "1"));
                list4.Add(new ItemDictonaryModel<string>("不会按吩咐做简单事情", "2"));
                list4.Add(new ItemDictonaryModel<string>("不会用勺吃饭", "3"));
                list4.Add(new ItemDictonaryModel<string>("不会扶栏上楼/台阶", "4"));
            }
            else if (this.monthAgeIndex == 4)
            {
                list4.Add(new ItemDictonaryModel<string>("不会说2-3个字的短语", "1"));
                list4.Add(new ItemDictonaryModel<string>("兴趣单一、刻板", "2"));
                list4.Add(new ItemDictonaryModel<string>("不会示意大小便", "3"));
                list4.Add(new ItemDictonaryModel<string>("不会跑", "4"));
            }
            this.cbFypg.DisplayMember = "DISPLAYMEMBER";
            this.cbFypg.ValueMember = "VALUEMEMBER";
            this.cbFypg.DataSource = list4;
           
        }

        public void InitEveryThing()
        {
            List<KidsOneToThreeYearOldModel> modelList = new KidsOneToThreeYearOldBLL().GetModelList(string.Format(" Flag ='{0}' AND IDCardNo ='{1}' ", this.monthAgeIndex, this.Model.IDCardNo));
            if (modelList.Count > 0)
            {
                this.ChildOneTwo = modelList[0];
                this.ChildOneTwo.LastUpdateBy = ConfigHelper.GetNodeDec("doctor");
                this.ChildOneTwo.LastUpdateDate = DateTime.Today;
            }
            else
            {
                this.ChildOneTwo = new KidsOneToThreeYearOldModel();
                this.ChildOneTwo.IDCardNo = this.Model.IDCardNo;
                this.ChildOneTwo.RecordID = this.Model.RecordID;
                this.ChildOneTwo.CreatedBy = ConfigHelper.GetNodeDec("doctor");
                this.ChildOneTwo.CreatedDate = DateTime.Today;
                this.ChildOneTwo.Flag = this.monthAgeIndex.ToString();
            }
            if (string.IsNullOrEmpty(this.ChildOneTwo.FollowUpDoctorSign))
            {
                this.ChildOneTwo.FollowUpDoctorSign = ConfigHelper.GetNode("doctorName");
            }
            this.bindingManager = new SimpleBindingManager<KidsOneToThreeYearOldModel>(this.inputRanges, this.inputrange_str, this.ChildOneTwo);
            if (!this.ChildOneTwo.Weight.HasValue)
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                if (devData.HasValue)
                {
                    this.ChildOneTwo.Weight = new decimal?(decimal.Parse(devData.value1));
                }
            }
            if (!this.ChildOneTwo.HemoglobinValue.HasValue)
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "52", "血红蛋白");
                if (_result2.HasValue)
                {
                    this.ChildOneTwo.HemoglobinValue = new decimal?(decimal.Parse(_result2.value1));
                }
            }
            this.srcData = GlbTools.DeepCopy(this.ChildOneTwo);
            this.lbName.Text = this.Model.CustomerName;
            if (this.ChildOneTwo.FollowupDate.HasValue)
            {
                this.dtpVisit.Value = this.ChildOneTwo.FollowupDate.Value;
            }
            this.bindingManager.SimpleBinding(this.tbWeight, "Weight", true);
            this.bindingManager.SimpleBinding(this.cbWeight, "WeightAnalysis");
            this.bindingManager.SimpleBinding(this.tbBornLength, "Stature", true);
            this.bindingManager.SimpleBinding(this.cbBodyLength, "StatureAnalysis");
            this.bindingManager.SimpleBinding(this.cbGLTizh, "SuspiciousRickets");
            //JustSingleItem<KidsOneToThreeYearOldModel> item = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
            //    R1 = this.rdMianse1,
            //    R2 = this.rdMianse2,
            //    R3 = this.rdMianse3
            //};
            //this.mianse = item;
            //this.mianse.BindProperty("ColourFace");
            JustSingleItem<KidsOneToThreeYearOldModel> item2 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
                R1 = this.rdSkin1,
                R2 = this.rdSkin2
            };
            this.skin = item2;
            this.skin.BindProperty("Skin");
            JustSingleItem<KidsOneToThreeYearOldModel> item3 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
                R1 = this.rdQianX1,
                R2 = this.rdQianX2
            };
            this.qianxin = item3;
            this.qianxin.statusChanged = (Action<string>) Delegate.Combine(this.qianxin.statusChanged, new Action<string>(this.justQianxinChanged));
            this.qianxin.BindProperty("Bregma");
            this.bindingManager.SimpleBinding(this.tbQianXa, "BregmaLeft", true);
            this.bindingManager.SimpleBinding(this.tbQianXb, "BregmaRight", true);
            JustSingleItem<KidsOneToThreeYearOldModel> item4 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
                R1 = this.rdYanwaiguan1,
                R2 = this.rdYanwaiguan2
            };
            this.yanwaiguan = item4;
            this.yanwaiguan.BindProperty("EyeAppearance");
            JustSingleItem<KidsOneToThreeYearOldModel> item5 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
                R1 = this.rdEr1,
                R2 = this.rdEr2
            };
            this.erwaiguan = item5;
            this.erwaiguan.BindProperty("EarAppearance");
            JustSingleItem<KidsOneToThreeYearOldModel> item6 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
                R1 = this.rdTingl1,
                R2 = this.rdTingl2
            };
            this.tingli = item6;
            this.tingli.BindProperty("Listening");
            this.bindingManager.SimpleBinding(this.tbTooth, "TeethDcnLeft", true);
            this.bindingManager.SimpleBinding(this.tbBedTooth, "TeethDcnRight", true);
            JustSingleItem<KidsOneToThreeYearOldModel> item7 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
                R1 = this.rdXiongb1,
                R2 = this.rdXiongb2
            };
            this.xiongbu = item7;
            this.xiongbu.BindProperty("Chest");
            JustSingleItem<KidsOneToThreeYearOldModel> item8 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
                R1 = this.rdFub1,
                R2 = this.rdFub2
            };
            this.fubu = item8;
            this.fubu.BindProperty("Stomach");
            JustSingleItem<KidsOneToThreeYearOldModel> item9 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
                R1 = this.rdSiz1,
                R2 = this.rdSiz2
            };
            this.sizhi = item9;
            this.sizhi.BindProperty("FourLimb");
            JustSingleItem<KidsOneToThreeYearOldModel> item10 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
                R1 = this.rdBut1,
                R2 = this.rdBut2
            };
            this.butai = item10;
            this.butai.BindProperty("Gait");
            //JustSingleItem<KidsOneToThreeYearOldModel> item11 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
            //    R1 = this.rdO,
            //    R2 = this.rdX,
            //    R3 = this.rdW
            //};
            //this.goulouzheng = item11;
            //this.goulouzheng.BindProperty("SuspiciousRickets");
            this.bindingManager.SimpleBinding(this.tbHem, "HemoglobinValue", true);
            this.bindingManager.SimpleBinding(this.tbOutSport, "OutdoorActivities", true);
            this.bindingManager.SimpleBinding(this.tbVD, "TakingVitaminsd", true);

            JustSingleItem<KidsOneToThreeYearOldModel> item14 = new JustSingleItem<KidsOneToThreeYearOldModel>(this.ChildOneTwo) {
                R1 = this.rdZhuanzhenNo,
                R2 = this.rdZhuanzhenHave
            };
            this.zhuanzhen = item14;
            this.zhuanzhen.statusChanged = (Action<string>) Delegate.Combine(this.zhuanzhen.statusChanged, new Action<string>(this.JustZhuanzhenChanged));
            this.zhuanzhen.BindProperty("ReferralAdvice");
            this.bindingManager.SimpleBinding(this.tbZhuanzhenResult, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenKs, "AgenciesDepartments", false);
            this.zhidao = new ManyCheckboxs<KidsOneToThreeYearOldModel>(this.ChildOneTwo);
            this.zhidao.AddCk(new CheckBox[] { this.ckGuides1, this.ckGuides2, this.ckGuides3, this.ckGuides4, this.ckGuides5 });
            this.zhidao.AddCk(this.ckGuides6, this.tbGuides);
            this.zhidao.BindingProperty("Guidance", "GuidanceOther");

            if (this.ChildOneTwo.NextFollowupDate.HasValue)
            {
                this.dtpNext.Value = this.ChildOneTwo.NextFollowupDate.Value;
            }

            this.bindingManager.SimpleBinding(this.tbDoctorMark, "FollowUpDoctorSign", false);
            if (!string.IsNullOrEmpty(this.ChildOneTwo.AuxeEstimate))
            {
 
            }
            this.bindingManager.SimpleBinding(this.cbFypg, "AuxeEstimate");
            this.bindingManager.SimpleBinding(this.tbFycs, "PneumoniaCounts", true);
            this.bindingManager.SimpleBinding(this.tbFxcs, "DiarrheaCounts", true);
            this.bindingManager.SimpleBinding(this.tbWscs, "TraumaCounts", true);
            this.bindingManager.SimpleBinding(this.tbHbqt, "SickOther", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenlxr, "ReferraContacts", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenlxfs, "ReferralContactsTel", false);
            if (this.ChildOneTwo.ReferralResult == "1")
            {
                this.rdDw1.Checked = true;
            }
            else if (this.ChildOneTwo.ReferralResult == "2")
            {
                this.rdDw2.Checked = true;
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
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckGuides6 = new System.Windows.Forms.CheckBox();
            this.tbGuides = new System.Windows.Forms.TextBox();
            this.ckGuides5 = new System.Windows.Forms.CheckBox();
            this.ckGuides4 = new System.Windows.Forms.CheckBox();
            this.ckGuides3 = new System.Windows.Forms.CheckBox();
            this.ckGuides2 = new System.Windows.Forms.CheckBox();
            this.ckGuides1 = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.tbDoctorMark = new System.Windows.Forms.TextBox();
            this.panel_fayu = new System.Windows.Forms.Panel();
            this.cbFypg = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.tbOutSport = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.panel_hem = new System.Windows.Forms.Panel();
            this.btnSelectHB = new System.Windows.Forms.Button();
            this.lbHem = new System.Windows.Forms.Label();
            this.tbHem = new System.Windows.Forms.TextBox();
            this.panel_gltizh = new System.Windows.Forms.Panel();
            this.cbGLTizh = new System.Windows.Forms.ComboBox();
            this.panel_butai = new System.Windows.Forms.Panel();
            this.rdBut2 = new System.Windows.Forms.RadioButton();
            this.rdBut1 = new System.Windows.Forms.RadioButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.rdSiz2 = new System.Windows.Forms.RadioButton();
            this.rdSiz1 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdFub2 = new System.Windows.Forms.RadioButton();
            this.rdFub1 = new System.Windows.Forms.RadioButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rdXiongb2 = new System.Windows.Forms.RadioButton();
            this.rdXiongb1 = new System.Windows.Forms.RadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.tbBedTooth = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbTooth = new System.Windows.Forms.TextBox();
            this.panel_tingli = new System.Windows.Forms.Panel();
            this.rdTingl2 = new System.Windows.Forms.RadioButton();
            this.rdTingl1 = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdEr2 = new System.Windows.Forms.RadioButton();
            this.rdEr1 = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdYanwaiguan2 = new System.Windows.Forms.RadioButton();
            this.rdYanwaiguan1 = new System.Windows.Forms.RadioButton();
            this.panel_qianxin = new System.Windows.Forms.Panel();
            this.lbQianxin2 = new System.Windows.Forms.Label();
            this.tbQianXb = new System.Windows.Forms.TextBox();
            this.lbQianxin1 = new System.Windows.Forms.Label();
            this.tbQianXa = new System.Windows.Forms.TextBox();
            this.rdQianX2 = new System.Windows.Forms.RadioButton();
            this.rdQianX1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdSkin2 = new System.Windows.Forms.RadioButton();
            this.rdSkin1 = new System.Windows.Forms.RadioButton();
            this.panel36 = new System.Windows.Forms.Panel();
            this.rdMianse3 = new System.Windows.Forms.RadioButton();
            this.rdMianse2 = new System.Windows.Forms.RadioButton();
            this.rdMianse1 = new System.Windows.Forms.RadioButton();
            this.dtpVisit = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbWeight = new System.Windows.Forms.ComboBox();
            this.btnWeight = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.cbBodyLength = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbBornLength = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.panel_vd = new System.Windows.Forms.Panel();
            this.lbVD = new System.Windows.Forms.Label();
            this.tbVD = new System.Windows.Forms.TextBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.rdZhuanzhenHave = new System.Windows.Forms.RadioButton();
            this.rdZhuanzhenNo = new System.Windows.Forms.RadioButton();
            this.tbZhuanzhenResult = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.tbZhuanzhenKs = new System.Windows.Forms.TextBox();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label43 = new System.Windows.Forms.Label();
            this.tbHbqt = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.tbWscs = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.tbFxcs = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.tbFycs = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbZhuanzhenlxr = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.tbZhuanzhenlxfs = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.rdDw2 = new System.Windows.Forms.RadioButton();
            this.rdDw1 = new System.Windows.Forms.RadioButton();
            this.label79 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lkJs = new System.Windows.Forms.LinkLabel();
            this.picSignJs = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel_fayu.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel_hem.SuspendLayout();
            this.panel_gltizh.SuspendLayout();
            this.panel_butai.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel_tingli.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel_qianxin.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel_vd.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(82, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1394, 655);
            this.panel1.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(58, 7);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 20);
            this.lbName.TabIndex = 174;
            this.lbName.Text = "姓名:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.65741F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.13272F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.47225F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.03744F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.04321F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.67593F));
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.label35, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.label34, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label32, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.panel19, 5, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel_fayu, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.label30, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel16, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.label23, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel_hem, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel_gltizh, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel_butai, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel_tingli, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel_qianxin, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel36, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpVisit, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label67, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label33, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label29, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label20, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label18, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.label21, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label25, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel_vd, 5, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel20, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenResult, 4, 12);
            this.tableLayoutPanel1.Controls.Add(this.label10, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.label68, 5, 12);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenKs, 6, 12);
            this.tableLayoutPanel1.Controls.Add(this.dtpNext, 2, 16);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.label14, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenlxr, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.label45, 3, 13);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenlxfs, 4, 13);
            this.tableLayoutPanel1.Controls.Add(this.label46, 5, 13);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 6, 13);
            this.tableLayoutPanel1.Controls.Add(this.label79, 4, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel15, 3, 16);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(33, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 17;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1329, 601);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label11, 2);
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(3, 558);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(203, 43);
            this.label11.TabIndex = 178;
            this.label11.Text = "下次随访日期:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.panel2.Location = new System.Drawing.Point(209, 493);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(1004, 65);
            this.panel2.TabIndex = 24;
            // 
            // ckGuides6
            // 
            this.ckGuides6.AutoSize = true;
            this.ckGuides6.Location = new System.Drawing.Point(645, 5);
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
            this.tbGuides.Location = new System.Drawing.Point(6, 31);
            this.tbGuides.MaxLength = 20;
            this.tbGuides.Multiline = true;
            this.tbGuides.Name = "tbGuides";
            this.tbGuides.Size = new System.Drawing.Size(792, 28);
            this.tbGuides.TabIndex = 186;
            // 
            // ckGuides5
            // 
            this.ckGuides5.AutoSize = true;
            this.ckGuides5.Location = new System.Drawing.Point(517, 5);
            this.ckGuides5.Name = "ckGuides5";
            this.ckGuides5.Size = new System.Drawing.Size(108, 24);
            this.ckGuides5.TabIndex = 4;
            this.ckGuides5.Text = "口腔保健";
            this.ckGuides5.UseVisualStyleBackColor = true;
            // 
            // ckGuides4
            // 
            this.ckGuides4.AutoSize = true;
            this.ckGuides4.Location = new System.Drawing.Point(390, 5);
            this.ckGuides4.Name = "ckGuides4";
            this.ckGuides4.Size = new System.Drawing.Size(108, 24);
            this.ckGuides4.TabIndex = 3;
            this.ckGuides4.Text = "预防伤害";
            this.ckGuides4.UseVisualStyleBackColor = true;
            // 
            // ckGuides3
            // 
            this.ckGuides3.AutoSize = true;
            this.ckGuides3.Location = new System.Drawing.Point(262, 5);
            this.ckGuides3.Name = "ckGuides3";
            this.ckGuides3.Size = new System.Drawing.Size(108, 24);
            this.ckGuides3.TabIndex = 2;
            this.ckGuides3.Text = "疾病预防";
            this.ckGuides3.UseVisualStyleBackColor = true;
            // 
            // ckGuides2
            // 
            this.ckGuides2.AutoSize = true;
            this.ckGuides2.Location = new System.Drawing.Point(134, 5);
            this.ckGuides2.Name = "ckGuides2";
            this.ckGuides2.Size = new System.Drawing.Size(108, 24);
            this.ckGuides2.TabIndex = 1;
            this.ckGuides2.Text = "生长发育";
            this.ckGuides2.UseVisualStyleBackColor = true;
            // 
            // ckGuides1
            // 
            this.ckGuides1.AutoSize = true;
            this.ckGuides1.Location = new System.Drawing.Point(6, 5);
            this.ckGuides1.Name = "ckGuides1";
            this.ckGuides1.Size = new System.Drawing.Size(108, 24);
            this.ckGuides1.TabIndex = 0;
            this.ckGuides1.Text = "科学喂养";
            this.ckGuides1.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label35, 2);
            this.label35.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(3, 493);
            this.label35.Name = "label35";
            this.tableLayoutPanel1.SetRowSpan(this.label35, 2);
            this.label35.Size = new System.Drawing.Size(203, 65);
            this.label35.TabIndex = 177;
            this.label35.Text = "指    导:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label34, 2);
            this.label34.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(3, 422);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(203, 35);
            this.label34.TabIndex = 177;
            this.label34.Text = "转诊建议:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label32, 2);
            this.label32.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(3, 383);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(203, 39);
            this.label32.TabIndex = 176;
            this.label32.Text = "两次随访间患病情况:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel19
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel19, 2);
            this.panel19.Controls.Add(this.tbDoctorMark);
            this.panel19.Location = new System.Drawing.Point(889, 346);
            this.panel19.Margin = new System.Windows.Forms.Padding(0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(308, 37);
            this.panel19.TabIndex = 19;
            // 
            // tbDoctorMark
            // 
            this.tbDoctorMark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDoctorMark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDoctorMark.ForeColor = System.Drawing.Color.Black;
            this.tbDoctorMark.Location = new System.Drawing.Point(3, 5);
            this.tbDoctorMark.Margin = new System.Windows.Forms.Padding(10);
            this.tbDoctorMark.MaxLength = 20;
            this.tbDoctorMark.Multiline = true;
            this.tbDoctorMark.Name = "tbDoctorMark";
            this.tbDoctorMark.Size = new System.Drawing.Size(164, 28);
            this.tbDoctorMark.TabIndex = 26;
            this.tbDoctorMark.Visible = false;
            // 
            // panel_fayu
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_fayu, 2);
            this.panel_fayu.Controls.Add(this.cbFypg);
            this.panel_fayu.Location = new System.Drawing.Point(209, 346);
            this.panel_fayu.Margin = new System.Windows.Forms.Padding(0);
            this.panel_fayu.Name = "panel_fayu";
            this.panel_fayu.Size = new System.Drawing.Size(308, 37);
            this.panel_fayu.TabIndex = 18;
            // 
            // cbFypg
            // 
            this.cbFypg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFypg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFypg.FormattingEnabled = true;
            this.cbFypg.Location = new System.Drawing.Point(3, 5);
            this.cbFypg.Name = "cbFypg";
            this.cbFypg.Size = new System.Drawing.Size(266, 28);
            this.cbFypg.TabIndex = 261;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label30, 2);
            this.label30.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(3, 346);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(203, 37);
            this.label30.TabIndex = 175;
            this.label30.Text = "发育评估:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel16
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel16, 2);
            this.panel16.Controls.Add(this.label24);
            this.panel16.Controls.Add(this.tbOutSport);
            this.panel16.Location = new System.Drawing.Point(209, 307);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(309, 39);
            this.panel16.TabIndex = 16;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(109, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 20);
            this.label24.TabIndex = 149;
            this.label24.Text = "小时/日";
            // 
            // tbOutSport
            // 
            this.tbOutSport.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbOutSport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbOutSport.ForeColor = System.Drawing.Color.Black;
            this.tbOutSport.Location = new System.Drawing.Point(4, 6);
            this.tbOutSport.MaxLength = 2;
            this.tbOutSport.Multiline = true;
            this.tbOutSport.Name = "tbOutSport";
            this.tbOutSport.Size = new System.Drawing.Size(97, 28);
            this.tbOutSport.TabIndex = 148;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label23, 2);
            this.label23.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(3, 307);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(203, 39);
            this.label23.TabIndex = 174;
            this.label23.Text = "户外活动:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_hem
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_hem, 2);
            this.panel_hem.Controls.Add(this.btnSelectHB);
            this.panel_hem.Controls.Add(this.lbHem);
            this.panel_hem.Controls.Add(this.tbHem);
            this.panel_hem.Location = new System.Drawing.Point(209, 271);
            this.panel_hem.Margin = new System.Windows.Forms.Padding(0);
            this.panel_hem.Name = "panel_hem";
            this.panel_hem.Size = new System.Drawing.Size(309, 36);
            this.panel_hem.TabIndex = 15;
            // 
            // btnSelectHB
            // 
            this.btnSelectHB.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectHB.Location = new System.Drawing.Point(171, 2);
            this.btnSelectHB.Name = "btnSelectHB";
            this.btnSelectHB.Size = new System.Drawing.Size(41, 31);
            this.btnSelectHB.TabIndex = 173;
            this.btnSelectHB.Text = "...";
            this.btnSelectHB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectHB.UseVisualStyleBackColor = true;
            this.btnSelectHB.Click += new System.EventHandler(this.btnSelectHB_Click);
            // 
            // lbHem
            // 
            this.lbHem.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbHem.AutoSize = true;
            this.lbHem.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHem.Location = new System.Drawing.Point(116, 11);
            this.lbHem.Name = "lbHem";
            this.lbHem.Size = new System.Drawing.Size(39, 20);
            this.lbHem.TabIndex = 149;
            this.lbHem.Text = "g/L";
            // 
            // tbHem
            // 
            this.tbHem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbHem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHem.ForeColor = System.Drawing.Color.Black;
            this.tbHem.Location = new System.Drawing.Point(5, 4);
            this.tbHem.MaxLength = 3;
            this.tbHem.Multiline = true;
            this.tbHem.Name = "tbHem";
            this.tbHem.ReadOnly = true;
            this.tbHem.Size = new System.Drawing.Size(97, 28);
            this.tbHem.TabIndex = 148;
            // 
            // panel_gltizh
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_gltizh, 2);
            this.panel_gltizh.Controls.Add(this.cbGLTizh);
            this.panel_gltizh.Location = new System.Drawing.Point(889, 235);
            this.panel_gltizh.Margin = new System.Windows.Forms.Padding(0);
            this.panel_gltizh.Name = "panel_gltizh";
            this.panel_gltizh.Size = new System.Drawing.Size(308, 36);
            this.panel_gltizh.TabIndex = 14;
            // 
            // cbGLTizh
            // 
            this.cbGLTizh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGLTizh.FormattingEnabled = true;
            this.cbGLTizh.Location = new System.Drawing.Point(4, 5);
            this.cbGLTizh.Name = "cbGLTizh";
            this.cbGLTizh.Size = new System.Drawing.Size(207, 28);
            this.cbGLTizh.TabIndex = 0;
            // 
            // panel_butai
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_butai, 2);
            this.panel_butai.Controls.Add(this.rdBut2);
            this.panel_butai.Controls.Add(this.rdBut1);
            this.panel_butai.Location = new System.Drawing.Point(209, 235);
            this.panel_butai.Margin = new System.Windows.Forms.Padding(0);
            this.panel_butai.Name = "panel_butai";
            this.panel_butai.Size = new System.Drawing.Size(308, 36);
            this.panel_butai.TabIndex = 13;
            // 
            // rdBut2
            // 
            this.rdBut2.AutoSize = true;
            this.rdBut2.Location = new System.Drawing.Point(171, 6);
            this.rdBut2.Name = "rdBut2";
            this.rdBut2.Size = new System.Drawing.Size(67, 24);
            this.rdBut2.TabIndex = 153;
            this.rdBut2.TabStop = true;
            this.rdBut2.Text = "异常";
            this.rdBut2.UseVisualStyleBackColor = true;
            // 
            // rdBut1
            // 
            this.rdBut1.AutoSize = true;
            this.rdBut1.Location = new System.Drawing.Point(4, 6);
            this.rdBut1.Name = "rdBut1";
            this.rdBut1.Size = new System.Drawing.Size(107, 24);
            this.rdBut1.TabIndex = 152;
            this.rdBut1.TabStop = true;
            this.rdBut1.Text = "未见异常";
            this.rdBut1.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel11, 2);
            this.panel11.Controls.Add(this.rdSiz2);
            this.panel11.Controls.Add(this.rdSiz1);
            this.panel11.Location = new System.Drawing.Point(889, 200);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(308, 35);
            this.panel11.TabIndex = 12;
            // 
            // rdSiz2
            // 
            this.rdSiz2.AutoSize = true;
            this.rdSiz2.Location = new System.Drawing.Point(147, 6);
            this.rdSiz2.Name = "rdSiz2";
            this.rdSiz2.Size = new System.Drawing.Size(67, 24);
            this.rdSiz2.TabIndex = 153;
            this.rdSiz2.TabStop = true;
            this.rdSiz2.Text = "异常";
            this.rdSiz2.UseVisualStyleBackColor = true;
            // 
            // rdSiz1
            // 
            this.rdSiz1.AutoSize = true;
            this.rdSiz1.Location = new System.Drawing.Point(4, 6);
            this.rdSiz1.Name = "rdSiz1";
            this.rdSiz1.Size = new System.Drawing.Size(107, 24);
            this.rdSiz1.TabIndex = 152;
            this.rdSiz1.TabStop = true;
            this.rdSiz1.Text = "未见异常";
            this.rdSiz1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.rdFub2);
            this.panel3.Controls.Add(this.rdFub1);
            this.panel3.Location = new System.Drawing.Point(209, 200);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(308, 35);
            this.panel3.TabIndex = 11;
            // 
            // rdFub2
            // 
            this.rdFub2.AutoSize = true;
            this.rdFub2.Location = new System.Drawing.Point(171, 6);
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
            // panel10
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel10, 2);
            this.panel10.Controls.Add(this.rdXiongb2);
            this.panel10.Controls.Add(this.rdXiongb1);
            this.panel10.Location = new System.Drawing.Point(889, 167);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(308, 33);
            this.panel10.TabIndex = 10;
            // 
            // rdXiongb2
            // 
            this.rdXiongb2.AutoSize = true;
            this.rdXiongb2.Location = new System.Drawing.Point(147, 6);
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
            this.rdXiongb1.Location = new System.Drawing.Point(4, 6);
            this.rdXiongb1.Name = "rdXiongb1";
            this.rdXiongb1.Size = new System.Drawing.Size(107, 24);
            this.rdXiongb1.TabIndex = 152;
            this.rdXiongb1.TabStop = true;
            this.rdXiongb1.Text = "未见异常";
            this.rdXiongb1.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel9, 2);
            this.panel9.Controls.Add(this.label15);
            this.panel9.Controls.Add(this.tbBedTooth);
            this.panel9.Controls.Add(this.label19);
            this.panel9.Controls.Add(this.tbTooth);
            this.panel9.Location = new System.Drawing.Point(209, 167);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(308, 33);
            this.panel9.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(121, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 20);
            this.label15.TabIndex = 254;
            this.label15.Text = "颗";
            // 
            // tbBedTooth
            // 
            this.tbBedTooth.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbBedTooth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBedTooth.ForeColor = System.Drawing.Color.Black;
            this.tbBedTooth.Location = new System.Drawing.Point(68, 3);
            this.tbBedTooth.MaxLength = 2;
            this.tbBedTooth.Multiline = true;
            this.tbBedTooth.Name = "tbBedTooth";
            this.tbBedTooth.Size = new System.Drawing.Size(46, 28);
            this.tbBedTooth.TabIndex = 253;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(50, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 20);
            this.label19.TabIndex = 252;
            this.label19.Text = "/";
            // 
            // tbTooth
            // 
            this.tbTooth.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbTooth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTooth.ForeColor = System.Drawing.Color.Black;
            this.tbTooth.Location = new System.Drawing.Point(4, 3);
            this.tbTooth.MaxLength = 2;
            this.tbTooth.Multiline = true;
            this.tbTooth.Name = "tbTooth";
            this.tbTooth.Size = new System.Drawing.Size(46, 28);
            this.tbTooth.TabIndex = 251;
            // 
            // panel_tingli
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_tingli, 2);
            this.panel_tingli.Controls.Add(this.rdTingl2);
            this.panel_tingli.Controls.Add(this.rdTingl1);
            this.panel_tingli.Location = new System.Drawing.Point(889, 133);
            this.panel_tingli.Margin = new System.Windows.Forms.Padding(0);
            this.panel_tingli.Name = "panel_tingli";
            this.panel_tingli.Size = new System.Drawing.Size(308, 34);
            this.panel_tingli.TabIndex = 8;
            // 
            // rdTingl2
            // 
            this.rdTingl2.AutoSize = true;
            this.rdTingl2.Location = new System.Drawing.Point(147, 6);
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
            this.rdTingl1.Location = new System.Drawing.Point(4, 6);
            this.rdTingl1.Name = "rdTingl1";
            this.rdTingl1.Size = new System.Drawing.Size(67, 24);
            this.rdTingl1.TabIndex = 152;
            this.rdTingl1.TabStop = true;
            this.rdTingl1.Text = "通过";
            this.rdTingl1.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel7, 2);
            this.panel7.Controls.Add(this.rdEr2);
            this.panel7.Controls.Add(this.rdEr1);
            this.panel7.Location = new System.Drawing.Point(209, 133);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(308, 34);
            this.panel7.TabIndex = 7;
            // 
            // rdEr2
            // 
            this.rdEr2.AutoSize = true;
            this.rdEr2.Location = new System.Drawing.Point(171, 6);
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
            // panel6
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 2);
            this.panel6.Controls.Add(this.rdYanwaiguan2);
            this.panel6.Controls.Add(this.rdYanwaiguan1);
            this.panel6.Location = new System.Drawing.Point(889, 99);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(308, 34);
            this.panel6.TabIndex = 6;
            // 
            // rdYanwaiguan2
            // 
            this.rdYanwaiguan2.AutoSize = true;
            this.rdYanwaiguan2.Location = new System.Drawing.Point(147, 6);
            this.rdYanwaiguan2.Name = "rdYanwaiguan2";
            this.rdYanwaiguan2.Size = new System.Drawing.Size(67, 24);
            this.rdYanwaiguan2.TabIndex = 153;
            this.rdYanwaiguan2.TabStop = true;
            this.rdYanwaiguan2.Text = "异常";
            this.rdYanwaiguan2.UseVisualStyleBackColor = true;
            // 
            // rdYanwaiguan1
            // 
            this.rdYanwaiguan1.AutoSize = true;
            this.rdYanwaiguan1.Location = new System.Drawing.Point(4, 6);
            this.rdYanwaiguan1.Name = "rdYanwaiguan1";
            this.rdYanwaiguan1.Size = new System.Drawing.Size(107, 24);
            this.rdYanwaiguan1.TabIndex = 152;
            this.rdYanwaiguan1.TabStop = true;
            this.rdYanwaiguan1.Text = "未见异常";
            this.rdYanwaiguan1.UseVisualStyleBackColor = true;
            // 
            // panel_qianxin
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_qianxin, 2);
            this.panel_qianxin.Controls.Add(this.lbQianxin2);
            this.panel_qianxin.Controls.Add(this.tbQianXb);
            this.panel_qianxin.Controls.Add(this.lbQianxin1);
            this.panel_qianxin.Controls.Add(this.tbQianXa);
            this.panel_qianxin.Controls.Add(this.rdQianX2);
            this.panel_qianxin.Controls.Add(this.rdQianX1);
            this.panel_qianxin.Location = new System.Drawing.Point(209, 99);
            this.panel_qianxin.Margin = new System.Windows.Forms.Padding(0);
            this.panel_qianxin.Name = "panel_qianxin";
            this.panel_qianxin.Size = new System.Drawing.Size(418, 34);
            this.panel_qianxin.TabIndex = 5;
            // 
            // lbQianxin2
            // 
            this.lbQianxin2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbQianxin2.AutoSize = true;
            this.lbQianxin2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbQianxin2.Location = new System.Drawing.Point(388, 10);
            this.lbQianxin2.Name = "lbQianxin2";
            this.lbQianxin2.Size = new System.Drawing.Size(29, 20);
            this.lbQianxin2.TabIndex = 250;
            this.lbQianxin2.Text = "㎝";
            // 
            // tbQianXb
            // 
            this.tbQianXb.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbQianXb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbQianXb.ForeColor = System.Drawing.Color.Black;
            this.tbQianXb.Location = new System.Drawing.Point(342, 2);
            this.tbQianXb.MaxLength = 2;
            this.tbQianXb.Multiline = true;
            this.tbQianXb.Name = "tbQianXb";
            this.tbQianXb.ReadOnly = true;
            this.tbQianXb.Size = new System.Drawing.Size(46, 28);
            this.tbQianXb.TabIndex = 249;
            // 
            // lbQianxin1
            // 
            this.lbQianxin1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbQianxin1.AutoSize = true;
            this.lbQianxin1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbQianxin1.Location = new System.Drawing.Point(289, 10);
            this.lbQianxin1.Name = "lbQianxin1";
            this.lbQianxin1.Size = new System.Drawing.Size(49, 20);
            this.lbQianxin1.TabIndex = 248;
            this.lbQianxin1.Text = "㎝ X";
            // 
            // tbQianXa
            // 
            this.tbQianXa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbQianXa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbQianXa.ForeColor = System.Drawing.Color.Black;
            this.tbQianXa.Location = new System.Drawing.Point(243, 2);
            this.tbQianXa.MaxLength = 2;
            this.tbQianXa.Multiline = true;
            this.tbQianXa.Name = "tbQianXa";
            this.tbQianXa.ReadOnly = true;
            this.tbQianXa.Size = new System.Drawing.Size(46, 28);
            this.tbQianXa.TabIndex = 154;
            // 
            // rdQianX2
            // 
            this.rdQianX2.AutoSize = true;
            this.rdQianX2.Location = new System.Drawing.Point(171, 6);
            this.rdQianX2.Name = "rdQianX2";
            this.rdQianX2.Size = new System.Drawing.Size(67, 24);
            this.rdQianX2.TabIndex = 153;
            this.rdQianX2.TabStop = true;
            this.rdQianX2.Text = "未闭";
            this.rdQianX2.UseVisualStyleBackColor = true;
            // 
            // rdQianX1
            // 
            this.rdQianX1.AutoSize = true;
            this.rdQianX1.Location = new System.Drawing.Point(4, 6);
            this.rdQianX1.Name = "rdQianX1";
            this.rdQianX1.Size = new System.Drawing.Size(67, 24);
            this.rdQianX1.TabIndex = 152;
            this.rdQianX1.TabStop = true;
            this.rdQianX1.Text = "闭合";
            this.rdQianX1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(107, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 240;
            this.label1.Text = "前    囟:";
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.rdSkin2);
            this.panel4.Controls.Add(this.rdSkin1);
            this.panel4.Location = new System.Drawing.Point(889, 65);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(308, 34);
            this.panel4.TabIndex = 4;
            // 
            // rdSkin2
            // 
            this.rdSkin2.AutoSize = true;
            this.rdSkin2.Location = new System.Drawing.Point(147, 6);
            this.rdSkin2.Name = "rdSkin2";
            this.rdSkin2.Size = new System.Drawing.Size(67, 24);
            this.rdSkin2.TabIndex = 153;
            this.rdSkin2.TabStop = true;
            this.rdSkin2.Text = "异常";
            this.rdSkin2.UseVisualStyleBackColor = true;
            // 
            // rdSkin1
            // 
            this.rdSkin1.AutoSize = true;
            this.rdSkin1.Location = new System.Drawing.Point(4, 6);
            this.rdSkin1.Name = "rdSkin1";
            this.rdSkin1.Size = new System.Drawing.Size(107, 24);
            this.rdSkin1.TabIndex = 152;
            this.rdSkin1.TabStop = true;
            this.rdSkin1.Text = "未见异常";
            this.rdSkin1.UseVisualStyleBackColor = true;
            // 
            // panel36
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel36, 2);
            this.panel36.Controls.Add(this.rdMianse3);
            this.panel36.Controls.Add(this.rdMianse2);
            this.panel36.Controls.Add(this.rdMianse1);
            this.panel36.Location = new System.Drawing.Point(209, 65);
            this.panel36.Margin = new System.Windows.Forms.Padding(0);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(417, 34);
            this.panel36.TabIndex = 3;
            // 
            // rdMianse3
            // 
            this.rdMianse3.AutoSize = true;
            this.rdMianse3.Location = new System.Drawing.Point(6, 6);
            this.rdMianse3.Name = "rdMianse3";
            this.rdMianse3.Size = new System.Drawing.Size(67, 24);
            this.rdMianse3.TabIndex = 153;
            this.rdMianse3.TabStop = true;
            this.rdMianse3.Text = "未检";
            this.rdMianse3.UseVisualStyleBackColor = true;
            // 
            // rdMianse2
            // 
            this.rdMianse2.AutoSize = true;
            this.rdMianse2.Location = new System.Drawing.Point(171, 6);
            this.rdMianse2.Name = "rdMianse2";
            this.rdMianse2.Size = new System.Drawing.Size(67, 24);
            this.rdMianse2.TabIndex = 153;
            this.rdMianse2.TabStop = true;
            this.rdMianse2.Text = "其他";
            this.rdMianse2.UseVisualStyleBackColor = true;
            // 
            // rdMianse1
            // 
            this.rdMianse1.AutoSize = true;
            this.rdMianse1.Location = new System.Drawing.Point(90, 6);
            this.rdMianse1.Name = "rdMianse1";
            this.rdMianse1.Size = new System.Drawing.Size(67, 24);
            this.rdMianse1.TabIndex = 152;
            this.rdMianse1.TabStop = true;
            this.rdMianse1.Text = "红润";
            this.rdMianse1.UseVisualStyleBackColor = true;
            // 
            // dtpVisit
            // 
            this.dtpVisit.Location = new System.Drawing.Point(212, 3);
            this.dtpVisit.Name = "dtpVisit";
            this.dtpVisit.Size = new System.Drawing.Size(194, 30);
            this.dtpVisit.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(528, 7);
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
            this.panel5.Location = new System.Drawing.Point(630, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(440, 35);
            this.panel5.TabIndex = 1;
            // 
            // cbWeight
            // 
            this.cbWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeight.FormattingEnabled = true;
            this.cbWeight.Location = new System.Drawing.Point(219, 1);
            this.cbWeight.Name = "cbWeight";
            this.cbWeight.Size = new System.Drawing.Size(121, 28);
            this.cbWeight.TabIndex = 3;
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(162, 1);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(44, 30);
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
            this.label31.Location = new System.Drawing.Point(121, 6);
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
            this.tbWeight.Location = new System.Drawing.Point(5, 5);
            this.tbWeight.MaxLength = 6;
            this.tbWeight.Multiline = true;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.ReadOnly = true;
            this.tbWeight.Size = new System.Drawing.Size(97, 28);
            this.tbWeight.TabIndex = 0;
            // 
            // label67
            // 
            this.label67.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.Location = new System.Drawing.Point(0, 65);
            this.label67.Margin = new System.Windows.Forms.Padding(0);
            this.label67.Name = "label67";
            this.tableLayoutPanel1.SetRowSpan(this.label67, 7);
            this.label67.Size = new System.Drawing.Size(33, 242);
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
            this.label13.Size = new System.Drawing.Size(203, 35);
            this.label13.TabIndex = 100;
            this.label13.Text = "随访日期:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(107, 72);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 20);
            this.label33.TabIndex = 164;
            this.label33.Text = "面    色:";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(787, 72);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(99, 20);
            this.label29.TabIndex = 162;
            this.label29.Text = "皮    肤:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(107, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 241;
            this.label2.Text = "耳 外 观:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(57, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 242;
            this.label3.Text = "出牙/(龋齿数):";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(107, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 243;
            this.label4.Text = "腹    部:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(787, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 244;
            this.label5.Text = "眼 外 观:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(787, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 245;
            this.label6.Text = "听    力:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(787, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 247;
            this.label8.Text = "胸    部:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(787, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 246;
            this.label7.Text = "四    肢:";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label16, 2);
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(3, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(203, 30);
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
            this.panel12.Location = new System.Drawing.Point(209, 35);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(421, 30);
            this.panel12.TabIndex = 2;
            // 
            // cbBodyLength
            // 
            this.cbBodyLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodyLength.FormattingEnabled = true;
            this.cbBodyLength.Location = new System.Drawing.Point(155, 1);
            this.cbBodyLength.Name = "cbBodyLength";
            this.cbBodyLength.Size = new System.Drawing.Size(121, 28);
            this.cbBodyLength.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(111, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 20);
            this.label12.TabIndex = 145;
            this.label12.Text = "㎝";
            // 
            // tbBornLength
            // 
            this.tbBornLength.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbBornLength.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBornLength.ForeColor = System.Drawing.Color.Black;
            this.tbBornLength.Location = new System.Drawing.Point(7, 1);
            this.tbBornLength.MaxLength = 3;
            this.tbBornLength.Multiline = true;
            this.tbBornLength.Name = "tbBornLength";
            this.tbBornLength.Size = new System.Drawing.Size(97, 28);
            this.tbBornLength.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(107, 243);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 20);
            this.label20.TabIndex = 250;
            this.label20.Text = "步    态:";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(727, 243);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(159, 20);
            this.label18.TabIndex = 249;
            this.label18.Text = "可疑佝偻病体征:";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(87, 279);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(119, 20);
            this.label21.TabIndex = 251;
            this.label21.Text = "血红蛋白值:";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(757, 316);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(129, 20);
            this.label25.TabIndex = 252;
            this.label25.Text = "服用维生素D:";
            // 
            // panel_vd
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_vd, 2);
            this.panel_vd.Controls.Add(this.lbVD);
            this.panel_vd.Controls.Add(this.tbVD);
            this.panel_vd.Location = new System.Drawing.Point(889, 307);
            this.panel_vd.Margin = new System.Windows.Forms.Padding(0);
            this.panel_vd.Name = "panel_vd";
            this.panel_vd.Size = new System.Drawing.Size(200, 39);
            this.panel_vd.TabIndex = 17;
            // 
            // lbVD
            // 
            this.lbVD.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbVD.AutoSize = true;
            this.lbVD.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbVD.Location = new System.Drawing.Point(105, 12);
            this.lbVD.Name = "lbVD";
            this.lbVD.Size = new System.Drawing.Size(59, 20);
            this.lbVD.TabIndex = 149;
            this.lbVD.Text = "1U/日";
            // 
            // tbVD
            // 
            this.tbVD.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbVD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbVD.ForeColor = System.Drawing.Color.Black;
            this.tbVD.Location = new System.Drawing.Point(2, 7);
            this.tbVD.MaxLength = 3;
            this.tbVD.Multiline = true;
            this.tbVD.Name = "tbVD";
            this.tbVD.Size = new System.Drawing.Size(97, 28);
            this.tbVD.TabIndex = 148;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.rdZhuanzhenHave);
            this.panel20.Controls.Add(this.rdZhuanzhenNo);
            this.panel20.Location = new System.Drawing.Point(212, 425);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(218, 29);
            this.panel20.TabIndex = 21;
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
            // tbZhuanzhenResult
            // 
            this.tbZhuanzhenResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenResult.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenResult.Location = new System.Drawing.Point(633, 425);
            this.tbZhuanzhenResult.MaxLength = 20;
            this.tbZhuanzhenResult.Multiline = true;
            this.tbZhuanzhenResult.Name = "tbZhuanzhenResult";
            this.tbZhuanzhenResult.ReadOnly = true;
            this.tbZhuanzhenResult.Size = new System.Drawing.Size(176, 28);
            this.tbZhuanzhenResult.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(528, 429);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 181;
            this.label10.Text = "转诊原因:";
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label68.Location = new System.Drawing.Point(948, 429);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(119, 20);
            this.label68.TabIndex = 186;
            this.label68.Text = "机构及科室:";
            // 
            // tbZhuanzhenKs
            // 
            this.tbZhuanzhenKs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenKs.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenKs.Location = new System.Drawing.Point(1073, 425);
            this.tbZhuanzhenKs.MaxLength = 20;
            this.tbZhuanzhenKs.Multiline = true;
            this.tbZhuanzhenKs.Name = "tbZhuanzhenKs";
            this.tbZhuanzhenKs.ReadOnly = true;
            this.tbZhuanzhenKs.Size = new System.Drawing.Size(174, 28);
            this.tbZhuanzhenKs.TabIndex = 23;
            // 
            // dtpNext
            // 
            this.dtpNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpNext.Location = new System.Drawing.Point(219, 568);
            this.dtpNext.Margin = new System.Windows.Forms.Padding(10);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(187, 30);
            this.dtpNext.TabIndex = 25;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel8, 5);
            this.panel8.Controls.Add(this.label43);
            this.panel8.Controls.Add(this.tbHbqt);
            this.panel8.Controls.Add(this.label44);
            this.panel8.Controls.Add(this.label41);
            this.panel8.Controls.Add(this.tbWscs);
            this.panel8.Controls.Add(this.label42);
            this.panel8.Controls.Add(this.label39);
            this.panel8.Controls.Add(this.tbFxcs);
            this.panel8.Controls.Add(this.label40);
            this.panel8.Controls.Add(this.label38);
            this.panel8.Controls.Add(this.tbFycs);
            this.panel8.Controls.Add(this.label37);
            this.panel8.Location = new System.Drawing.Point(209, 383);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1120, 39);
            this.panel8.TabIndex = 254;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(15, 9);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 20);
            this.label43.TabIndex = 24;
            this.label43.Text = "无";
            // 
            // tbHbqt
            // 
            this.tbHbqt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHbqt.Location = new System.Drawing.Point(649, 3);
            this.tbHbqt.Name = "tbHbqt";
            this.tbHbqt.Size = new System.Drawing.Size(256, 30);
            this.tbHbqt.TabIndex = 23;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(590, 8);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(49, 20);
            this.label44.TabIndex = 22;
            this.label44.Text = "其他";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(508, 9);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(29, 20);
            this.label41.TabIndex = 21;
            this.label41.Text = "次";
            // 
            // tbWscs
            // 
            this.tbWscs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWscs.Location = new System.Drawing.Point(466, 4);
            this.tbWscs.Name = "tbWscs";
            this.tbWscs.Size = new System.Drawing.Size(36, 30);
            this.tbWscs.TabIndex = 20;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(412, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(49, 20);
            this.label42.TabIndex = 19;
            this.label42.Text = "外伤";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(333, 9);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(29, 20);
            this.label39.TabIndex = 18;
            this.label39.Text = "次";
            // 
            // tbFxcs
            // 
            this.tbFxcs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFxcs.Location = new System.Drawing.Point(291, 3);
            this.tbFxcs.Name = "tbFxcs";
            this.tbFxcs.Size = new System.Drawing.Size(36, 30);
            this.tbFxcs.TabIndex = 17;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(239, 9);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(49, 20);
            this.label40.TabIndex = 16;
            this.label40.Text = "腹泻";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(162, 9);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(29, 20);
            this.label38.TabIndex = 15;
            this.label38.Text = "次";
            // 
            // tbFycs
            // 
            this.tbFycs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFycs.Location = new System.Drawing.Point(120, 3);
            this.tbFycs.Name = "tbFycs";
            this.tbFycs.Size = new System.Drawing.Size(36, 30);
            this.tbFycs.TabIndex = 14;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(71, 10);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(49, 20);
            this.label37.TabIndex = 13;
            this.label37.Text = "肺炎";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(127, 465);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 20);
            this.label14.TabIndex = 257;
            this.label14.Text = "联系人:";
            // 
            // tbZhuanzhenlxr
            // 
            this.tbZhuanzhenlxr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenlxr.Location = new System.Drawing.Point(212, 460);
            this.tbZhuanzhenlxr.Name = "tbZhuanzhenlxr";
            this.tbZhuanzhenlxr.ReadOnly = true;
            this.tbZhuanzhenlxr.Size = new System.Drawing.Size(171, 30);
            this.tbZhuanzhenlxr.TabIndex = 258;
            // 
            // label45
            // 
            this.label45.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(528, 465);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(99, 20);
            this.label45.TabIndex = 259;
            this.label45.Text = "联系方式:";
            // 
            // tbZhuanzhenlxfs
            // 
            this.tbZhuanzhenlxfs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenlxfs.Location = new System.Drawing.Point(633, 460);
            this.tbZhuanzhenlxfs.Name = "tbZhuanzhenlxfs";
            this.tbZhuanzhenlxfs.ReadOnly = true;
            this.tbZhuanzhenlxfs.Size = new System.Drawing.Size(178, 30);
            this.tbZhuanzhenlxfs.TabIndex = 260;
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(978, 465);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(89, 20);
            this.label46.TabIndex = 261;
            this.label46.Text = "是否到位";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.rdDw2);
            this.panel14.Controls.Add(this.rdDw1);
            this.panel14.Enabled = false;
            this.panel14.Location = new System.Drawing.Point(1073, 460);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(253, 30);
            this.panel14.TabIndex = 262;
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
            // label79
            // 
            this.label79.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label79.Location = new System.Drawing.Point(747, 354);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(139, 20);
            this.label79.TabIndex = 190;
            this.label79.Text = "随访医生签名:";
            this.label79.Visible = false;
            // 
            // panel15
            // 
            this.panel15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel15, 4);
            this.panel15.Controls.Add(this.lkYs);
            this.panel15.Controls.Add(this.picSignYs);
            this.panel15.Controls.Add(this.label22);
            this.panel15.Controls.Add(this.lkJs);
            this.panel15.Controls.Add(this.picSignJs);
            this.panel15.Controls.Add(this.label17);
            this.panel15.Location = new System.Drawing.Point(443, 558);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(886, 43);
            this.panel15.TabIndex = 265;
            // 
            // lkYs
            // 
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(311, 14);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 266;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(153, 1);
            this.picSignYs.Margin = new System.Windows.Forms.Padding(0);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(150, 38);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 264;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(139, 20);
            this.label22.TabIndex = 267;
            this.label22.Text = "随访医生签名:";
            // 
            // lkJs
            // 
            this.lkJs.AutoSize = true;
            this.lkJs.Location = new System.Drawing.Point(710, 14);
            this.lkJs.Name = "lkJs";
            this.lkJs.Size = new System.Drawing.Size(89, 20);
            this.lkJs.TabIndex = 175;
            this.lkJs.TabStop = true;
            this.lkJs.Text = "重置签名";
            this.lkJs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // picSignJs
            // 
            this.picSignJs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJs.Location = new System.Drawing.Point(555, 1);
            this.picSignJs.Margin = new System.Windows.Forms.Padding(0);
            this.picSignJs.Name = "picSignJs";
            this.picSignJs.Size = new System.Drawing.Size(150, 36);
            this.picSignJs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJs.TabIndex = 0;
            this.picSignJs.TabStop = false;
            this.picSignJs.Click += new System.EventHandler(this.picSignJs_Click);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(442, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 20);
            this.label17.TabIndex = 263;
            this.label17.Text = "家长签名:";
            // 
            // KidsOneMonthOldVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "KidsOneMonthOldVisitForm";
            this.Text = "FrmChild_1to2";
            this.Load += new System.EventHandler(this.FrmChild_1to2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmChildMonthAge_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel_fayu.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel_hem.ResumeLayout(false);
            this.panel_hem.PerformLayout();
            this.panel_gltizh.ResumeLayout(false);
            this.panel_butai.ResumeLayout(false);
            this.panel_butai.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel_tingli.ResumeLayout(false);
            this.panel_tingli.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel_qianxin.ResumeLayout(false);
            this.panel_qianxin.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel_vd.ResumeLayout(false);
            this.panel_vd.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).EndInit();
            this.ResumeLayout(false);

        }

        private void justQianxinChanged(string hhv)
        {
            if (hhv == "1")
            {
                this.tbQianXa.Clear();
                this.tbQianXa.ReadOnly = true;
                this.tbQianXb.Clear();
                this.tbQianXb.ReadOnly = true;
            }
            if (hhv == "2")
            {
                this.tbQianXa.ReadOnly = false;
                this.tbQianXb.ReadOnly = false;
            }
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
            if (GlbTools.IsChanged(this.srcData, this.ChildOneTwo, new string[] { "VisitDate", "NextVisitDate", "FollowUpDoctorSign" }))
            {
                KidsOneToThreeYearOldBLL child_onethree_year_old = new KidsOneToThreeYearOldBLL();
                if (child_onethree_year_old.Exists(this.ChildOneTwo.ID))
                {
                    child_onethree_year_old.Update(this.ChildOneTwo);
                }
                else
                {
                    child_onethree_year_old.Add(this.ChildOneTwo);
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
            this.ChildOneTwo.FollowupDate = new DateTime?(this.dtpVisit.Value.Date);
            this.ChildOneTwo.NextFollowupDate = new DateTime?(this.dtpNext.Value.Date);
            if ((this.ChildOneTwo.PneumoniaCounts + this.ChildOneTwo.DiarrheaCounts + this.ChildOneTwo.TraumaCounts) < 0
              && !string.IsNullOrEmpty(this.tbHbqt.Text))
            {
                this.ChildOneTwo.SickNone = "无";
            }
            else
            {
                this.ChildOneTwo.SickNone = "有";
            }
            if (this.rdDw1.Checked)
            {
                this.ChildOneTwo.ReferralResult = "1";
            }
            else if (this.rdDw2.Checked)
            {
                this.ChildOneTwo.ReferralResult = "2";
            }
            else
            {
                this.ChildOneTwo.ReferralResult = null;
            }
        }

        private KidsOneToThreeYearOldModel ChildOneTwo { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public object srcData { get; set; }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.monthAgeIndex == 1)
            {
                Clear("_Month_12", picSignJs);
            }
            if (this.monthAgeIndex == 2)
            {
                Clear("_Month_18", picSignJs);
            }
            if (this.monthAgeIndex == 3)
            {
                Clear("_Month_24", picSignJs);
            }
            if (this.monthAgeIndex == 4)
            {
                Clear("_Month_30", picSignJs);
            }
        }

        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.monthAgeIndex == 1)
            {
                Clear("_Month_12_Doc", picSignYs);
            }
            if (this.monthAgeIndex == 2)
            {
                Clear("_Month_18_Doc", picSignYs);
            }
            if (this.monthAgeIndex == 3)
            {
                Clear("_Month_24_Doc", picSignYs);
            }
            if (this.monthAgeIndex == 4)
            {
                Clear("_Month_30_Doc", picSignYs);
            }
        }

        private void picSignYs_Click(object sender, EventArgs e)
        {
            if (this.monthAgeIndex == 1)
            {
                Sign("_Month_12_Doc", picSignYs);
            }
            if (this.monthAgeIndex == 2)
            {
                Sign("_Month_18_Doc", picSignYs);
            }
            if (this.monthAgeIndex == 3)
            {
                Sign("_Month_24_Doc", picSignYs);
            }
            if (this.monthAgeIndex == 4)
            {
                Sign("_Month_30_Doc", picSignYs);
            }
        }

        private void picSignJs_Click(object sender, EventArgs e)
        {
            if (this.monthAgeIndex == 1)
            {
                Sign("_Month_12", picSignJs);
            }
            if (this.monthAgeIndex == 2)
            {
                Sign("_Month_18", picSignJs);
            }
            if (this.monthAgeIndex == 3)
            {
                Sign("_Month_24", picSignJs);
            }
            if (this.monthAgeIndex == 4)
            {
                Sign("_Month_30", picSignJs);
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
    }
}

