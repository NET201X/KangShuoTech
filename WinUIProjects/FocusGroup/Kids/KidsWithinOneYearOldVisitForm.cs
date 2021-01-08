
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
    public class KidsWithinOneYearOldVisitForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<KidsWithinOneYearOldModel> bindingManager;
        private IContainer components;
        private JustSingleItem<KidsWithinOneYearOldModel> erwaiguan;
        private JustSingleItem<KidsWithinOneYearOldModel> fayupinggu;
        private JustSingleItem<KidsWithinOneYearOldModel> fubu;
        private JustSingleItem<KidsWithinOneYearOldModel> gangmen;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private JustSingleItem<KidsWithinOneYearOldModel> jingbu;
        private JustSingleItem<KidsWithinOneYearOldModel> kouqiang;
        private ManyRadionButtons<KidsWithinOneYearOldModel> m_qibu;
        private ManyRadionButtons<KidsWithinOneYearOldModel> mianse;
        private int monthAgeIndex = 1;
        private JustSingleItem<KidsWithinOneYearOldModel> qianxin;
        private JustSingleItem<KidsWithinOneYearOldModel> sizhi;
        private JustSingleItem<KidsWithinOneYearOldModel> skin;
        private JustSingleItem<KidsWithinOneYearOldModel> tingli;
        private JustSingleItem<KidsWithinOneYearOldModel> xiongbu;
        private JustSingleItem<KidsWithinOneYearOldModel> yanwaiguan;
        private ManyCheckboxs<KidsWithinOneYearOldModel> zhidao;
        private Panel panel1;
        private Label lbName;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel_qib;
        private RadioButton rdQibu1;
        private RadioButton rdQibu2;
        private RadioButton rdQibu3;
        private RadioButton rdQibu4;
        private Panel panel24;
        private RadioButton rdGangm2;
        private RadioButton rdGangm1;
        private Label label20;
        private Label label3;
        private Panel panel_kouqiang;
        private Label lbGrowTooth;
        private TextBox tbToothNum;
        private RadioButton rdKouq2;
        private RadioButton rdKouq1;
        private Label lbKouqiang;
        private Panel panel_Jingb;
        private RadioButton rdJingb2;
        private RadioButton rdJingb1;
        private Label label36;
        private Panel panel21;
        private Label label27;
        private TextBox tbTouwei;
        private Label label15;
        private Label label11;
        private Panel panel3;
        private CheckBox ckGuides5;
        private CheckBox ckGuides4;
        private CheckBox ckGuides3;
        private CheckBox ckGuides2;
        private CheckBox ckGuides1;
        private Label label35;
        private Label label34;
        private Panel panel18;
        private Label label30;
        private Panel panel16;
        private Label label24;
        private TextBox tbOutSport;
        private Label label23;
        private Panel panel11;
        private RadioButton rdSiz2;
        private RadioButton rdSiz1;
        private Panel panel4;
        private Label label17;
        private TextBox tbQianXb;
        private Label label14;
        private TextBox tbQianXa;
        private RadioButton rdQianX2;
        private RadioButton rdQianX1;
        private Label label1;
        private Panel panel8;
        private RadioButton rdSkin2;
        private RadioButton rdSkin1;
        private Panel panel36;
        private RadioButton rdMianse3;
        private RadioButton rdMianse2;
        private RadioButton rdMianse1;
        private DateTimePicker dtpVisit;
        private Panel panel5;
        private ComboBox cbWeight;
        private Button btnWeight;
        private Label label31;
        private TextBox tbWeight;
        private Label label67;
        private Label label13;
        private Label label33;
        private Label label29;
        private Label label7;
        private Label label16;
        private Panel panel12;
        private ComboBox cbBodyLength;
        private Label label12;
        private TextBox tbBornLength;
        private Label label25;
        private Panel panel17;
        private Label label28;
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
        private Label label5;
        private Panel panel6;
        private RadioButton rdYanwaiguan2;
        private RadioButton rdYanwaiguan1;
        private Label label2;
        private Panel panel7;
        private RadioButton rdEr2;
        private RadioButton rdEr1;
        private Label label6;
        private Panel panel_tingli;
        private RadioButton rdTingl2;
        private RadioButton rdTingl1;
        private Label label8;
        private Panel panel10;
        private RadioButton rdXiongb2;
        private RadioButton rdXiongb1;
        private Label label4;
        private Panel panel2;
        private RadioButton rdFub2;
        private RadioButton rdFub1;
        private Label label21;
        private Panel panel15;
        private Button btnSelectHB;
        private Label label22;
        private TextBox tbHem;
        private Label label9;
        private RadioButton rdMianse4;
        private ComboBox cbFypg;
        private Panel panel9;
        private Label label26;
        private Panel panel13;
        private Label label41;
        private TextBox tbWscs;
        private Label label42;
        private Label label39;
        private TextBox tbFxcs;
        private Label label40;
        private Label label38;
        private TextBox tbFycs;
        private Label label37;
        private TextBox tbHbqt;
        private Label label44;
        private Label label43;
        private Label label32;
        private TextBox tbZhuanzhenlxr;
        private Label label45;
        private TextBox tbZhuanzhenlxfs;
        private Label label46;
        private Panel panel14;
        private RadioButton rdDw2;
        private RadioButton rdDw1;
        private CheckBox ckGuides6;
        private TextBox tbGuidesOther;
        private Label label47;
        private PictureBox picSignJs;
        private JustSingleItem<KidsWithinOneYearOldModel> zhuanzhen;
        private string SignS = "";
        private string SignDoc = "";//随访医生签名
        private LinkLabel lkJs;
        private Label label18;
        private Panel panel_GLzhengz;
        private ComboBox cbGLZhengzh;
        private Panel panel_GLTizh;
        private ComboBox cbGLTizh;
        private Label label19;
        private Panel panel22;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label48;
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public KidsWithinOneYearOldVisitForm(int index)
        {
            this.monthAgeIndex = index;
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();
            this.InitEveryOne();
            this.EveryThingIsOk = false;
            this.tableLayoutPanel1.ResumeLayout();
        }

        private void AddCheckbox(string[] items)
        {
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

        private void FrmChildWithinAgeOne_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.SignPath))
            {
                Directory.CreateDirectory(this.SignPath);
            }
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
            if (this.monthAgeIndex == 1)
            {
                this.tingli.MVisiable = false;
                this.cbGLZhengzh.Visible = false;
                this.cbGLTizh.Visible = false;
                this.tbHem.Clear();
                this.panel15.Visible = false;
                this.SignS = string.Format("{0}{1}_Month_1.png", this.SignPath, this.Model.IDCardNo);
                this.SignDoc = string.Format("{0}{1}_Month_1_Doc.png", this.SignPath, this.Model.IDCardNo);
            }
            else if (this.monthAgeIndex == 2)
            {
                this.tingli.MVisiable = false;
                this.m_qibu["1"].Text = "未见异常";
                this.m_qibu["2"].Text = "异常";
                this.m_qibu["2"].Location = new Point(0x70, 6);
                this.m_qibu["3"].Visible = false;
                this.m_qibu["4"].Visible = false;
                this.SignS = string.Format("{0}{1}_Month_3.png", this.SignPath, this.Model.IDCardNo);
                this.SignDoc = string.Format("{0}{1}_Month_3_Doc.png", this.SignPath, this.Model.IDCardNo);
            }
            else if (this.monthAgeIndex == 3)
            {
                this.m_qibu.Hide();
                this.rdMianse2.Text = "其他";
                this.rdMianse3.Visible = false;
                this.rdTingl1.Text = "通过";
                this.rdTingl2.Text = "未通过";
                this.SignS = string.Format("{0}{1}_Month_6.png", this.SignPath, this.Model.IDCardNo);
                this.SignDoc = string.Format("{0}{1}_Month_6_Doc.png", this.SignPath, this.Model.IDCardNo);
            }
            else if (this.monthAgeIndex == 4)
            {
                this.jingbu.MVisiable = false;
                this.tingli.MVisiable = false;
                this.m_qibu.Hide();
                this.rdMianse2.Text = "其他";
                this.rdMianse3.Visible = false;
                this.SignS = string.Format("{0}{1}_Month_8.png", this.SignPath, this.Model.IDCardNo);
                this.SignDoc = string.Format("{0}{1}_Month_8_Doc.png", this.SignPath, this.Model.IDCardNo);
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

        private void FrmChildWithinAgeOne_Paint(object sender, PaintEventArgs e)
        {
            if (this.monthAgeIndex == 1)
            {
                this.panel_tingli.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
                this.panel_GLzhengz.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
            else if (this.monthAgeIndex == 2)
            {
                this.panel_tingli.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
            else if (this.monthAgeIndex == 3)
            {
                this.panel_qib.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
            else if (this.monthAgeIndex == 4)
            {
                this.panel_Jingb.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
                this.panel_tingli.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
                this.panel_qib.CreateGraphics().DrawString("--------------", new Font("宋体", 15f), new SolidBrush(Color.Black), new PointF(3f, 10f));
            }
        }

        private void InitEveryOne()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("无", "1"),
                new ItemDictonaryModel<string>("夜惊", "2"),
                new ItemDictonaryModel<string>("多汗", "3"),
                new ItemDictonaryModel<string>("烦躁", "4")
            };
            this.cbGLZhengzh.DisplayMember = "DISPLAYMEMBER";
            this.cbGLZhengzh.ValueMember = "VALUEMEMBER";
            this.cbGLZhengzh.DataSource = list;
            List<ItemDictonaryModel<string>> list2 = new List<ItemDictonaryModel<string>>();
            if (this.monthAgeIndex == 2)
            {
                list2.Add(new ItemDictonaryModel<string>("无", "1"));
                list2.Add(new ItemDictonaryModel<string>("颅骨软化", "2"));
                //list2.Add(new ItemDictonaryModel<string>("方颅", "3"));
                //list2.Add(new ItemDictonaryModel<string>("枕秃", "4"));
            }
            if ((this.monthAgeIndex == 3) || (this.monthAgeIndex == 4))
            {
                list2.Add(new ItemDictonaryModel<string>("无", "1"));
                list2.Add(new ItemDictonaryModel<string>("肋串珠", "2"));
                list2.Add(new ItemDictonaryModel<string>("肋软骨沟", "3"));
                list2.Add(new ItemDictonaryModel<string>("鸡胸", "4"));
                list2.Add(new ItemDictonaryModel<string>("手镯征", "5"));
                list2.Add(new ItemDictonaryModel<string>("颅骨软化", "6"));
                list2.Add(new ItemDictonaryModel<string>("方颅", "7"));
                this.lbGrowTooth.Text = "出牙数(颗):";
                this.lbGrowTooth.Location = new Point(3, 8);
                this.lbGrowTooth.Visible = true;
                this.rdKouq1.Visible = false;
                this.rdKouq2.Visible = false;
                this.tbToothNum.Location = new Point(0x59, 4);
                this.tbToothNum.Visible = true;
            }
            this.cbGLTizh.DisplayMember = "DISPLAYMEMBER";
            this.cbGLTizh.ValueMember = "VALUEMEMBER";
            this.cbGLTizh.DataSource = list2;
            List<ItemDictonaryModel<string>> list3 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("请选择", "1"),
                new ItemDictonaryModel<string>("上", "2"),
                new ItemDictonaryModel<string>("中", "3"),
                new ItemDictonaryModel<string>("下", "4")
            };
            this.cbWeight.DisplayMember = "DISPLAYMEMBER";
            this.cbWeight.ValueMember = "VALUEMEMBER";
            this.cbWeight.DataSource = list3;
            List<ItemDictonaryModel<string>> list4 = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("请选择", "1"),
                new ItemDictonaryModel<string>("上", "2"),
                new ItemDictonaryModel<string>("中", "3"),
                new ItemDictonaryModel<string>("下", "4")
            };
            this.cbBodyLength.DisplayMember = "DISPLAYMEMBER";
            this.cbBodyLength.ValueMember = "VALUEMEMBER";
            this.cbBodyLength.DataSource = list4;
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("Stature", 100M, false));
            this.inputRanges.Add(new InputRangeDec("HeadCircumference", 100M, false));
            this.inputRanges.Add(new InputRangeDec("BregmaLeft", 100M, false));
            this.inputRanges.Add(new InputRangeDec("BregmaRight", 100M, false));
            this.inputRanges.Add(new InputRangeDec("HemoglobinValue", 1000M));
            this.inputRanges.Add(new InputRangeDec("OutdoorActivities", 24M, false));
            this.inputRanges.Add(new InputRangeDec("TakingVitaminsd", 100M));
            this.inputRanges.Add(new InputRangeDec("TeethNum", 100M, true, false));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("Other", 100));
            this.inputrange_str.Add(new InputRangeStr("ReferralReason", 500));
            this.inputrange_str.Add(new InputRangeStr("AgenciesDepartments", 80));
            this.inputrange_str.Add(new InputRangeStr("GuidanceOther", 100));
            List<ItemDictonaryModel<string>> list5 = new List<ItemDictonaryModel<string>>(); //发育评估
            if (this.monthAgeIndex == 1)
            {
                this.cbFypg.Visible = false;
            }
            else if (this.monthAgeIndex == 2)
            {
                list5.Add(new ItemDictonaryModel<string>("对很大声音没有反应", "1"));
                list5.Add(new ItemDictonaryModel<string>("逗引时不发音或不微笑", "2"));
                list5.Add(new ItemDictonaryModel<string>("不注视人脸，不追视移动人或物品", "3"));
                list5.Add(new ItemDictonaryModel<string>("俯卧时不会抬头", "4"));
            }
            else if (this.monthAgeIndex == 3)
            {
                list5.Add(new ItemDictonaryModel<string>("发音少，不会笑出声", "1"));
                list5.Add(new ItemDictonaryModel<string>("不会伸手抓物", "2"));
                list5.Add(new ItemDictonaryModel<string>("紧握拳松不开", "3"));
                list5.Add(new ItemDictonaryModel<string>("不能扶坐", "4"));
            }
            else if (this.monthAgeIndex == 4)
            {
                list5.Add(new ItemDictonaryModel<string>("听到声音无应答", "1"));
                list5.Add(new ItemDictonaryModel<string>("不会区分生人和熟人", "2"));
                list5.Add(new ItemDictonaryModel<string>("双手间不会传递玩具", "3"));
                list5.Add(new ItemDictonaryModel<string>("不会独坐", "4"));
            }
            this.cbFypg.DisplayMember = "DISPLAYMEMBER";
            this.cbFypg.ValueMember = "VALUEMEMBER";
            this.cbFypg.DataSource = list5;
        }

        public void InitEveryThing()
        {
            List<KidsWithinOneYearOldModel> modelList = new KidsWithinOneYearOldBLL().GetModelList(string.Format(" Flag ='{0}' AND IDCardNo ='{1}' ", this.monthAgeIndex, this.Model.IDCardNo));
            if (modelList.Count > 0)
            {
                this.ChildWithinOne = modelList[0];
                this.ChildWithinOne.LastUpdateBy = ConfigHelper.GetNode("doctor");
                this.ChildWithinOne.LastUpdateDate = DateTime.Today;
            }
            else
            {
                this.ChildWithinOne = new KidsWithinOneYearOldModel();
                this.ChildWithinOne.IDCardNo = this.Model.IDCardNo;
                this.ChildWithinOne.RecordID = this.Model.RecordID;
                this.ChildWithinOne.CreatedBy = ConfigHelper.GetNode("doctor");
                this.ChildWithinOne.CreatedDate = DateTime.Today;
                this.ChildWithinOne.Flag = this.monthAgeIndex.ToString();
            }
            if (string.IsNullOrEmpty(this.ChildWithinOne.FollowUpDoctorSign))
            {
                this.ChildWithinOne.FollowUpDoctorSign = ConfigHelper.GetNode("doctorName");
            }
            this.bindingManager = new SimpleBindingManager<KidsWithinOneYearOldModel>(this.inputRanges, this.inputrange_str, this.ChildWithinOne);
            if (!this.ChildWithinOne.Weight.HasValue)
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                if (devData.HasValue)
                {
                    this.ChildWithinOne.Weight = new decimal?(decimal.Parse(devData.value1));
                }
            }
            if (!this.ChildWithinOne.HemoglobinValue.HasValue)
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "52", "血红蛋白");
                if (_result2.HasValue)
                {
                    this.ChildWithinOne.HemoglobinValue = new decimal?(decimal.Parse(_result2.value1));
                }
            }
            this.srcData = GlbTools.DeepCopy(this.ChildWithinOne);
            this.lbName.Text = this.Model.CustomerName;
            if (this.ChildWithinOne.VisitDate.HasValue)
            {
                this.dtpVisit.Value = this.ChildWithinOne.VisitDate.Value;
            }
            this.bindingManager.SimpleBinding(this.tbWeight, "Weight", true);
            this.bindingManager.SimpleBinding(this.cbWeight, "WeightAnalysis");
            this.bindingManager.SimpleBinding(this.tbBornLength, "Stature", true);
            this.bindingManager.SimpleBinding(this.cbBodyLength, "StatureAnalysis");
            this.bindingManager.SimpleBinding(this.tbTouwei, "HeadCircumference", true);
            this.mianse = new ManyRadionButtons<KidsWithinOneYearOldModel>(this.ChildWithinOne);
            this.mianse.AddRdBtn(new RadioButton[] { this.rdMianse1, this.rdMianse2, this.rdMianse3,this.rdMianse4  });
            this.mianse.BindPropertyInfo("ColorFace", "");
            JustSingleItem<KidsWithinOneYearOldModel> item = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdSkin1,
                R2 = this.rdSkin2
            };
            this.skin = item;
            this.skin.BindProperty("Skin");
            JustSingleItem<KidsWithinOneYearOldModel> item2 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdQianX1,
                R2 = this.rdQianX2
            };
            this.qianxin = item2;
            this.qianxin.statusChanged = (Action<string>) Delegate.Combine(this.qianxin.statusChanged, new Action<string>(this.justQianxinChanged));
            this.qianxin.BindProperty("Bregma");
            this.bindingManager.SimpleBinding(this.tbQianXa, "BregmaLeft", true);
            this.bindingManager.SimpleBinding(this.tbQianXb, "BregmaRight", true);
            JustSingleItem<KidsWithinOneYearOldModel> item3 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdJingb1,
                R2 = this.rdJingb2
            };
            this.jingbu = item3;
            this.jingbu.BindProperty("NeckMass");
            JustSingleItem<KidsWithinOneYearOldModel> item4 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdYanwaiguan1,
                R2 = this.rdYanwaiguan2
            };
            this.yanwaiguan = item4;
            this.yanwaiguan.BindProperty("EyeAppearance");
            JustSingleItem<KidsWithinOneYearOldModel> item5 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdEr1,
                R2 = this.rdEr2
            };
            this.erwaiguan = item5;
            this.erwaiguan.BindProperty("EarAppearance");
            JustSingleItem<KidsWithinOneYearOldModel> item6 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdTingl1,
                R2 = this.rdTingl2
            };
            this.tingli = item6;
            this.tingli.BindProperty("Listening");
            JustSingleItem<KidsWithinOneYearOldModel> item7 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdKouq1,
                R2 = this.rdKouq2
            };
            this.kouqiang = item7;
            this.kouqiang.BindProperty("OralCavity");
            this.bindingManager.SimpleBinding(this.tbToothNum, "TeethNum", true);
            JustSingleItem<KidsWithinOneYearOldModel> item8 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdXiongb1,
                R2 = this.rdXiongb2
            };
            this.xiongbu = item8;
            this.xiongbu.BindProperty("Chest");
            JustSingleItem<KidsWithinOneYearOldModel> item9 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdFub1,
                R2 = this.rdFub2
            };
            this.fubu = item9;
            this.fubu.BindProperty("Stomach");
            JustSingleItem<KidsWithinOneYearOldModel> item10 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdSiz1,
                R2 = this.rdSiz2
            };
            this.sizhi = item10;
            this.sizhi.BindProperty("FourLimb");
            this.m_qibu = new ManyRadionButtons<KidsWithinOneYearOldModel>(this.ChildWithinOne);
            this.m_qibu.AddRdBtn(new RadioButton[] { this.rdQibu1, this.rdQibu2, this.rdQibu3, this.rdQibu4 });
            this.m_qibu.BindPropertyInfo("UmbilicalRegion", "");
            this.bindingManager.SimpleBinding(this.cbGLZhengzh, "RicketsSympotom");
            this.bindingManager.SimpleBinding(this.cbGLTizh, "RicketsSign");
            JustSingleItem<KidsWithinOneYearOldModel> item11 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdGangm1,
                R2 = this.rdGangm2
            };
            this.gangmen = item11;
            this.gangmen.BindProperty("AnusExternalGenita");
            this.bindingManager.SimpleBinding(this.tbHem, "HemoglobinValue", true);
            this.bindingManager.SimpleBinding(this.tbOutSport, "OutdoorActivities", true);
            this.bindingManager.SimpleBinding(this.tbVD, "TakingVitaminsd", true);
            JustSingleItem<KidsWithinOneYearOldModel> item14 = new JustSingleItem<KidsWithinOneYearOldModel>(this.ChildWithinOne) {
                R1 = this.rdZhuanzhenNo,
                R2 = this.rdZhuanzhenHave
            };
            this.zhuanzhen = item14;
            this.zhuanzhen.statusChanged = (Action<string>) Delegate.Combine(this.zhuanzhen.statusChanged, new Action<string>(this.JustZhuanzhenChanged));
            this.zhuanzhen.BindProperty("ReferralAdvice");
            this.bindingManager.SimpleBinding(this.tbZhuanzhenResult, "ReferralReason", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenKs, "AgenciesDepartments", false);
            this.zhidao = new ManyCheckboxs<KidsWithinOneYearOldModel>(this.ChildWithinOne);
            this.zhidao.AddCk(new CheckBox[] { this.ckGuides1, this.ckGuides2, this.ckGuides3, this.ckGuides4, this.ckGuides5 });
            this.zhidao.AddCk(this.ckGuides6,this.tbGuidesOther);
            this.zhidao.BindingProperty("Guidance", "GuidesOther");
           

            if (this.ChildWithinOne.NextFollowupDate.HasValue)
            {
               this.dtpNext.Value = this.ChildWithinOne.NextFollowupDate.Value;
            }

            this.bindingManager.SimpleBinding(this.tbDoctorMark, "FollowUpDoctorSign", false);

            this.bindingManager.SimpleBinding(this.cbFypg, "AuxeEstimate");
            this.bindingManager.SimpleBinding(this.tbFycs, "PneumoniaCounts",true);
            this.bindingManager.SimpleBinding(this.tbFxcs, "DiarrheaCounts", true);
            this.bindingManager.SimpleBinding(this.tbWscs, "TraumaCounts", true);
            this.bindingManager.SimpleBinding(this.tbHbqt, "SickOther", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenlxr, "ReferraContacts", false);
            this.bindingManager.SimpleBinding(this.tbZhuanzhenlxfs, "ReferralContactsTel", false);
            if (this.ChildWithinOne.ReferralResult == "1")
            {
                this.rdDw1.Checked = true;
            }
            else if (this.ChildWithinOne.ReferralResult == "2")
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
            this.panel_qib = new System.Windows.Forms.Panel();
            this.rdQibu1 = new System.Windows.Forms.RadioButton();
            this.rdQibu2 = new System.Windows.Forms.RadioButton();
            this.rdQibu3 = new System.Windows.Forms.RadioButton();
            this.rdQibu4 = new System.Windows.Forms.RadioButton();
            this.panel24 = new System.Windows.Forms.Panel();
            this.rdGangm2 = new System.Windows.Forms.RadioButton();
            this.rdGangm1 = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_kouqiang = new System.Windows.Forms.Panel();
            this.lbGrowTooth = new System.Windows.Forms.Label();
            this.tbToothNum = new System.Windows.Forms.TextBox();
            this.rdKouq2 = new System.Windows.Forms.RadioButton();
            this.rdKouq1 = new System.Windows.Forms.RadioButton();
            this.lbKouqiang = new System.Windows.Forms.Label();
            this.panel_Jingb = new System.Windows.Forms.Panel();
            this.rdJingb2 = new System.Windows.Forms.RadioButton();
            this.rdJingb1 = new System.Windows.Forms.RadioButton();
            this.label36 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.tbTouwei = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckGuides6 = new System.Windows.Forms.CheckBox();
            this.tbGuidesOther = new System.Windows.Forms.TextBox();
            this.ckGuides5 = new System.Windows.Forms.CheckBox();
            this.ckGuides4 = new System.Windows.Forms.CheckBox();
            this.ckGuides3 = new System.Windows.Forms.CheckBox();
            this.ckGuides2 = new System.Windows.Forms.CheckBox();
            this.ckGuides1 = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.cbFypg = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.tbOutSport = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.rdSiz2 = new System.Windows.Forms.RadioButton();
            this.rdSiz1 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.tbQianXb = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbQianXa = new System.Windows.Forms.TextBox();
            this.rdQianX2 = new System.Windows.Forms.RadioButton();
            this.rdQianX1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rdSkin2 = new System.Windows.Forms.RadioButton();
            this.rdSkin1 = new System.Windows.Forms.RadioButton();
            this.panel36 = new System.Windows.Forms.Panel();
            this.rdMianse3 = new System.Windows.Forms.RadioButton();
            this.rdMianse2 = new System.Windows.Forms.RadioButton();
            this.rdMianse4 = new System.Windows.Forms.RadioButton();
            this.rdMianse1 = new System.Windows.Forms.RadioButton();
            this.dtpVisit = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbWeight = new System.Windows.Forms.ComboBox();
            this.btnWeight = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.cbBodyLength = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbBornLength = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.tbVD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdYanwaiguan2 = new System.Windows.Forms.RadioButton();
            this.rdYanwaiguan1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdEr2 = new System.Windows.Forms.RadioButton();
            this.rdEr1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_tingli = new System.Windows.Forms.Panel();
            this.rdTingl2 = new System.Windows.Forms.RadioButton();
            this.rdTingl1 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rdXiongb2 = new System.Windows.Forms.RadioButton();
            this.rdXiongb1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdFub2 = new System.Windows.Forms.RadioButton();
            this.rdFub1 = new System.Windows.Forms.RadioButton();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnSelectHB = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.tbHem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel_GLzhengz = new System.Windows.Forms.Panel();
            this.cbGLZhengzh = new System.Windows.Forms.ComboBox();
            this.panel_GLTizh = new System.Windows.Forms.Panel();
            this.cbGLTizh = new System.Windows.Forms.ComboBox();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.tbDoctorMark = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
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
            this.panel20 = new System.Windows.Forms.Panel();
            this.rdZhuanzhenHave = new System.Windows.Forms.RadioButton();
            this.rdZhuanzhenNo = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.tbZhuanzhenResult = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.tbZhuanzhenKs = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbZhuanzhenlxr = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.tbZhuanzhenlxfs = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.rdDw2 = new System.Windows.Forms.RadioButton();
            this.rdDw1 = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.label48 = new System.Windows.Forms.Label();
            this.lkJs = new System.Windows.Forms.LinkLabel();
            this.picSignJs = new System.Windows.Forms.PictureBox();
            this.label47 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_qib.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel_kouqiang.SuspendLayout();
            this.panel_Jingb.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel_tingli.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel_GLzhengz.SuspendLayout();
            this.panel_GLTizh.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(58, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1423, 669);
            this.panel1.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(40, 3);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.58643F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.45781F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.57036F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.78562F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.03939F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5604F));
            this.tableLayoutPanel1.Controls.Add(this.panel_qib, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel24, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.label20, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel_kouqiang, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbKouqiang, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel_Jingb, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label36, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel21, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 15);
            this.tableLayoutPanel1.Controls.Add(this.label35, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.panel18, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.label30, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.panel16, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.label23, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel36, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpVisit, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label67, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label33, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label29, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label25, 4, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel17, 5, 10);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel_tingli, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.label18, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label21, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel15, 5, 9);
            this.tableLayoutPanel1.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_GLzhengz, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel_GLTizh, 5, 8);
            this.tableLayoutPanel1.Controls.Add(this.dtpNext, 2, 17);
            this.tableLayoutPanel1.Controls.Add(this.tbDoctorMark, 4, 17);
            this.tableLayoutPanel1.Controls.Add(this.label79, 3, 17);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel13, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel20, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.label10, 3, 13);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenResult, 4, 13);
            this.tableLayoutPanel1.Controls.Add(this.label68, 5, 13);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenKs, 6, 13);
            this.tableLayoutPanel1.Controls.Add(this.label34, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.label32, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenlxr, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.label45, 3, 14);
            this.tableLayoutPanel1.Controls.Add(this.tbZhuanzhenlxfs, 4, 14);
            this.tableLayoutPanel1.Controls.Add(this.label46, 5, 14);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 6, 14);
            this.tableLayoutPanel1.Controls.Add(this.label19, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel22, 1, 18);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(39, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 19;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1350, 634);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_qib
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_qib, 2);
            this.panel_qib.Controls.Add(this.rdQibu1);
            this.panel_qib.Controls.Add(this.rdQibu2);
            this.panel_qib.Controls.Add(this.rdQibu3);
            this.panel_qib.Controls.Add(this.rdQibu4);
            this.panel_qib.Location = new System.Drawing.Point(198, 236);
            this.panel_qib.Margin = new System.Windows.Forms.Padding(0);
            this.panel_qib.Name = "panel_qib";
            this.panel_qib.Size = new System.Drawing.Size(418, 35);
            this.panel_qib.TabIndex = 14;
            // 
            // rdQibu1
            // 
            this.rdQibu1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdQibu1.AutoSize = true;
            this.rdQibu1.Location = new System.Drawing.Point(4, 5);
            this.rdQibu1.Name = "rdQibu1";
            this.rdQibu1.Size = new System.Drawing.Size(67, 24);
            this.rdQibu1.TabIndex = 159;
            this.rdQibu1.TabStop = true;
            this.rdQibu1.Text = "未脱";
            this.rdQibu1.UseVisualStyleBackColor = true;
            // 
            // rdQibu2
            // 
            this.rdQibu2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdQibu2.AutoSize = true;
            this.rdQibu2.Location = new System.Drawing.Point(84, 5);
            this.rdQibu2.Name = "rdQibu2";
            this.rdQibu2.Size = new System.Drawing.Size(67, 24);
            this.rdQibu2.TabIndex = 158;
            this.rdQibu2.TabStop = true;
            this.rdQibu2.Text = "脱落";
            this.rdQibu2.UseVisualStyleBackColor = true;
            // 
            // rdQibu3
            // 
            this.rdQibu3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdQibu3.AutoSize = true;
            this.rdQibu3.Location = new System.Drawing.Point(169, 5);
            this.rdQibu3.Name = "rdQibu3";
            this.rdQibu3.Size = new System.Drawing.Size(127, 24);
            this.rdQibu3.TabIndex = 160;
            this.rdQibu3.TabStop = true;
            this.rdQibu3.Text = "脐部有渗出";
            this.rdQibu3.UseVisualStyleBackColor = true;
            // 
            // rdQibu4
            // 
            this.rdQibu4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdQibu4.AutoSize = true;
            this.rdQibu4.Location = new System.Drawing.Point(314, 5);
            this.rdQibu4.Name = "rdQibu4";
            this.rdQibu4.Size = new System.Drawing.Size(67, 24);
            this.rdQibu4.TabIndex = 161;
            this.rdQibu4.TabStop = true;
            this.rdQibu4.Text = "其他";
            this.rdQibu4.UseVisualStyleBackColor = true;
            // 
            // panel24
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel24, 2);
            this.panel24.Controls.Add(this.rdGangm2);
            this.panel24.Controls.Add(this.rdGangm1);
            this.panel24.Location = new System.Drawing.Point(198, 306);
            this.panel24.Margin = new System.Windows.Forms.Padding(0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(306, 30);
            this.panel24.TabIndex = 18;
            // 
            // rdGangm2
            // 
            this.rdGangm2.AutoSize = true;
            this.rdGangm2.Location = new System.Drawing.Point(141, 4);
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
            this.rdGangm1.Location = new System.Drawing.Point(4, 4);
            this.rdGangm1.Name = "rdGangm1";
            this.rdGangm1.Size = new System.Drawing.Size(107, 24);
            this.rdGangm1.TabIndex = 152;
            this.rdGangm1.TabStop = true;
            this.rdGangm1.Text = "未见异常";
            this.rdGangm1.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(66, 312);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(129, 20);
            this.label20.TabIndex = 247;
            this.label20.Text = "肛门/外生殖:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(96, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 248;
            this.label3.Text = "脐    部:";
            // 
            // panel_kouqiang
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_kouqiang, 2);
            this.panel_kouqiang.Controls.Add(this.lbGrowTooth);
            this.panel_kouqiang.Controls.Add(this.tbToothNum);
            this.panel_kouqiang.Controls.Add(this.rdKouq2);
            this.panel_kouqiang.Controls.Add(this.rdKouq1);
            this.panel_kouqiang.Location = new System.Drawing.Point(905, 168);
            this.panel_kouqiang.Margin = new System.Windows.Forms.Padding(0);
            this.panel_kouqiang.Name = "panel_kouqiang";
            this.panel_kouqiang.Size = new System.Drawing.Size(407, 33);
            this.panel_kouqiang.TabIndex = 11;
            // 
            // lbGrowTooth
            // 
            this.lbGrowTooth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbGrowTooth.AutoSize = true;
            this.lbGrowTooth.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbGrowTooth.Location = new System.Drawing.Point(248, 6);
            this.lbGrowTooth.Name = "lbGrowTooth";
            this.lbGrowTooth.Size = new System.Drawing.Size(39, 20);
            this.lbGrowTooth.TabIndex = 247;
            this.lbGrowTooth.Text = "口:";
            this.lbGrowTooth.Visible = false;
            // 
            // tbToothNum
            // 
            this.tbToothNum.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbToothNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbToothNum.ForeColor = System.Drawing.Color.Black;
            this.tbToothNum.Location = new System.Drawing.Point(293, 2);
            this.tbToothNum.MaxLength = 10;
            this.tbToothNum.Name = "tbToothNum";
            this.tbToothNum.Size = new System.Drawing.Size(97, 30);
            this.tbToothNum.TabIndex = 154;
            this.tbToothNum.Visible = false;
            // 
            // rdKouq2
            // 
            this.rdKouq2.AutoSize = true;
            this.rdKouq2.Location = new System.Drawing.Point(155, 6);
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
            // lbKouqiang
            // 
            this.lbKouqiang.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbKouqiang.AutoSize = true;
            this.lbKouqiang.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbKouqiang.Location = new System.Drawing.Point(803, 174);
            this.lbKouqiang.Name = "lbKouqiang";
            this.lbKouqiang.Size = new System.Drawing.Size(99, 20);
            this.lbKouqiang.TabIndex = 246;
            this.lbKouqiang.Text = "口    腔:";
            // 
            // panel_Jingb
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_Jingb, 2);
            this.panel_Jingb.Controls.Add(this.rdJingb2);
            this.panel_Jingb.Controls.Add(this.rdJingb1);
            this.panel_Jingb.Location = new System.Drawing.Point(905, 105);
            this.panel_Jingb.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Jingb.Name = "panel_Jingb";
            this.panel_Jingb.Size = new System.Drawing.Size(308, 31);
            this.panel_Jingb.TabIndex = 7;
            // 
            // rdJingb2
            // 
            this.rdJingb2.AutoSize = true;
            this.rdJingb2.Location = new System.Drawing.Point(155, 6);
            this.rdJingb2.Name = "rdJingb2";
            this.rdJingb2.Size = new System.Drawing.Size(47, 24);
            this.rdJingb2.TabIndex = 153;
            this.rdJingb2.TabStop = true;
            this.rdJingb2.Text = "无";
            this.rdJingb2.UseVisualStyleBackColor = true;
            // 
            // rdJingb1
            // 
            this.rdJingb1.AutoSize = true;
            this.rdJingb1.Location = new System.Drawing.Point(4, 6);
            this.rdJingb1.Name = "rdJingb1";
            this.rdJingb1.Size = new System.Drawing.Size(47, 24);
            this.rdJingb1.TabIndex = 0;
            this.rdJingb1.TabStop = true;
            this.rdJingb1.Text = "有";
            this.rdJingb1.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(803, 110);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(99, 20);
            this.label36.TabIndex = 245;
            this.label36.Text = "颈部包块:";
            // 
            // panel21
            // 
            this.panel21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel21, 2);
            this.panel21.Controls.Add(this.label27);
            this.panel21.Controls.Add(this.tbTouwei);
            this.panel21.Location = new System.Drawing.Point(905, 35);
            this.panel21.Margin = new System.Windows.Forms.Padding(0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(445, 37);
            this.panel21.TabIndex = 3;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(113, 10);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 20);
            this.label27.TabIndex = 145;
            this.label27.Text = "㎝";
            // 
            // tbTouwei
            // 
            this.tbTouwei.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbTouwei.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTouwei.ForeColor = System.Drawing.Color.Black;
            this.tbTouwei.Location = new System.Drawing.Point(6, 4);
            this.tbTouwei.MaxLength = 3;
            this.tbTouwei.Name = "tbTouwei";
            this.tbTouwei.Size = new System.Drawing.Size(97, 30);
            this.tbTouwei.TabIndex = 111;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(803, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 20);
            this.label15.TabIndex = 175;
            this.label15.Text = "头    围:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label11, 2);
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(3, 551);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 35);
            this.label11.TabIndex = 178;
            this.label11.Text = "下次随访日期:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 5);
            this.panel3.Controls.Add(this.ckGuides6);
            this.panel3.Controls.Add(this.tbGuidesOther);
            this.panel3.Controls.Add(this.ckGuides5);
            this.panel3.Controls.Add(this.ckGuides4);
            this.panel3.Controls.Add(this.ckGuides3);
            this.panel3.Controls.Add(this.ckGuides2);
            this.panel3.Controls.Add(this.ckGuides1);
            this.panel3.Location = new System.Drawing.Point(198, 513);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(992, 38);
            this.panel3.TabIndex = 28;
            // 
            // ckGuides6
            // 
            this.ckGuides6.AutoSize = true;
            this.ckGuides6.Location = new System.Drawing.Point(627, 5);
            this.ckGuides6.Name = "ckGuides6";
            this.ckGuides6.Size = new System.Drawing.Size(68, 24);
            this.ckGuides6.TabIndex = 14;
            this.ckGuides6.Text = "其他";
            this.ckGuides6.UseVisualStyleBackColor = true;
            // 
            // tbGuidesOther
            // 
            this.tbGuidesOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGuidesOther.Location = new System.Drawing.Point(711, 3);
            this.tbGuidesOther.Name = "tbGuidesOther";
            this.tbGuidesOther.ReadOnly = true;
            this.tbGuidesOther.Size = new System.Drawing.Size(247, 30);
            this.tbGuidesOther.TabIndex = 13;
            // 
            // ckGuides5
            // 
            this.ckGuides5.AutoSize = true;
            this.ckGuides5.Location = new System.Drawing.Point(508, 5);
            this.ckGuides5.Name = "ckGuides5";
            this.ckGuides5.Size = new System.Drawing.Size(108, 24);
            this.ckGuides5.TabIndex = 4;
            this.ckGuides5.Text = "口腔保健";
            this.ckGuides5.UseVisualStyleBackColor = true;
            // 
            // ckGuides4
            // 
            this.ckGuides4.AutoSize = true;
            this.ckGuides4.Location = new System.Drawing.Point(384, 5);
            this.ckGuides4.Name = "ckGuides4";
            this.ckGuides4.Size = new System.Drawing.Size(108, 24);
            this.ckGuides4.TabIndex = 3;
            this.ckGuides4.Text = "预防伤害";
            this.ckGuides4.UseVisualStyleBackColor = true;
            // 
            // ckGuides3
            // 
            this.ckGuides3.AutoSize = true;
            this.ckGuides3.Location = new System.Drawing.Point(260, 5);
            this.ckGuides3.Name = "ckGuides3";
            this.ckGuides3.Size = new System.Drawing.Size(108, 24);
            this.ckGuides3.TabIndex = 2;
            this.ckGuides3.Text = "疾病预防";
            this.ckGuides3.UseVisualStyleBackColor = true;
            // 
            // ckGuides2
            // 
            this.ckGuides2.AutoSize = true;
            this.ckGuides2.Location = new System.Drawing.Point(131, 5);
            this.ckGuides2.Name = "ckGuides2";
            this.ckGuides2.Size = new System.Drawing.Size(108, 24);
            this.ckGuides2.TabIndex = 1;
            this.ckGuides2.Text = "生长发育";
            this.ckGuides2.UseVisualStyleBackColor = true;
            // 
            // ckGuides1
            // 
            this.ckGuides1.AutoSize = true;
            this.ckGuides1.Location = new System.Drawing.Point(4, 5);
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
            this.label35.Location = new System.Drawing.Point(3, 513);
            this.label35.Name = "label35";
            this.tableLayoutPanel1.SetRowSpan(this.label35, 2);
            this.label35.Size = new System.Drawing.Size(192, 38);
            this.label35.TabIndex = 177;
            this.label35.Text = "指    导:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel18
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel18, 2);
            this.panel18.Controls.Add(this.cbFypg);
            this.panel18.Location = new System.Drawing.Point(198, 372);
            this.panel18.Margin = new System.Windows.Forms.Padding(0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(306, 37);
            this.panel18.TabIndex = 22;
            // 
            // cbFypg
            // 
            this.cbFypg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFypg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFypg.FormattingEnabled = true;
            this.cbFypg.Location = new System.Drawing.Point(3, 6);
            this.cbFypg.Name = "cbFypg";
            this.cbFypg.Size = new System.Drawing.Size(266, 28);
            this.cbFypg.TabIndex = 260;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label30, 2);
            this.label30.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(3, 372);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(192, 37);
            this.label30.TabIndex = 175;
            this.label30.Text = "发育评估:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel16
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel16, 2);
            this.panel16.Controls.Add(this.label24);
            this.panel16.Controls.Add(this.tbOutSport);
            this.panel16.Location = new System.Drawing.Point(198, 338);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(306, 34);
            this.panel16.TabIndex = 20;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(106, 10);
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
            this.tbOutSport.Location = new System.Drawing.Point(3, 4);
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
            this.label23.Location = new System.Drawing.Point(3, 338);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(192, 34);
            this.label23.TabIndex = 174;
            this.label23.Text = "户外活动:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel11
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel11, 2);
            this.panel11.Controls.Add(this.rdSiz2);
            this.panel11.Controls.Add(this.rdSiz1);
            this.panel11.Location = new System.Drawing.Point(905, 236);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(308, 35);
            this.panel11.TabIndex = 15;
            // 
            // rdSiz2
            // 
            this.rdSiz2.AutoSize = true;
            this.rdSiz2.Location = new System.Drawing.Point(155, 6);
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
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.tbQianXb);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.tbQianXa);
            this.panel4.Controls.Add(this.rdQianX2);
            this.panel4.Controls.Add(this.rdQianX1);
            this.panel4.Location = new System.Drawing.Point(198, 105);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(421, 31);
            this.panel4.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(394, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 20);
            this.label17.TabIndex = 250;
            this.label17.Text = "㎝";
            // 
            // tbQianXb
            // 
            this.tbQianXb.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbQianXb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbQianXb.ForeColor = System.Drawing.Color.Black;
            this.tbQianXb.Location = new System.Drawing.Point(349, 1);
            this.tbQianXb.MaxLength = 2;
            this.tbQianXb.Multiline = true;
            this.tbQianXb.Name = "tbQianXb";
            this.tbQianXb.ReadOnly = true;
            this.tbQianXb.Size = new System.Drawing.Size(46, 28);
            this.tbQianXb.TabIndex = 249;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(296, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 20);
            this.label14.TabIndex = 248;
            this.label14.Text = "㎝ X";
            // 
            // tbQianXa
            // 
            this.tbQianXa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbQianXa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbQianXa.ForeColor = System.Drawing.Color.Black;
            this.tbQianXa.Location = new System.Drawing.Point(249, 1);
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
            this.rdQianX2.Location = new System.Drawing.Point(169, 6);
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
            this.label1.Location = new System.Drawing.Point(96, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 240;
            this.label1.Text = "前    囟:";
            // 
            // panel8
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel8, 2);
            this.panel8.Controls.Add(this.rdSkin2);
            this.panel8.Controls.Add(this.rdSkin1);
            this.panel8.Location = new System.Drawing.Point(905, 72);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(308, 33);
            this.panel8.TabIndex = 5;
            // 
            // rdSkin2
            // 
            this.rdSkin2.AutoSize = true;
            this.rdSkin2.Location = new System.Drawing.Point(155, 6);
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
            this.panel36.Controls.Add(this.rdMianse4);
            this.panel36.Controls.Add(this.rdMianse1);
            this.panel36.Location = new System.Drawing.Point(198, 72);
            this.panel36.Margin = new System.Windows.Forms.Padding(0);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(405, 33);
            this.panel36.TabIndex = 4;
            // 
            // rdMianse3
            // 
            this.rdMianse3.AutoSize = true;
            this.rdMianse3.Location = new System.Drawing.Point(259, 6);
            this.rdMianse3.Name = "rdMianse3";
            this.rdMianse3.Size = new System.Drawing.Size(67, 24);
            this.rdMianse3.TabIndex = 154;
            this.rdMianse3.TabStop = true;
            this.rdMianse3.Text = "其他";
            this.rdMianse3.UseVisualStyleBackColor = true;
            // 
            // rdMianse2
            // 
            this.rdMianse2.AutoSize = true;
            this.rdMianse2.Location = new System.Drawing.Point(170, 6);
            this.rdMianse2.Name = "rdMianse2";
            this.rdMianse2.Size = new System.Drawing.Size(67, 24);
            this.rdMianse2.TabIndex = 153;
            this.rdMianse2.TabStop = true;
            this.rdMianse2.Text = "黄染";
            this.rdMianse2.UseVisualStyleBackColor = true;
            // 
            // rdMianse4
            // 
            this.rdMianse4.AutoSize = true;
            this.rdMianse4.Location = new System.Drawing.Point(5, 6);
            this.rdMianse4.Name = "rdMianse4";
            this.rdMianse4.Size = new System.Drawing.Size(67, 24);
            this.rdMianse4.TabIndex = 152;
            this.rdMianse4.TabStop = true;
            this.rdMianse4.Text = "未检";
            this.rdMianse4.UseVisualStyleBackColor = true;
            // 
            // rdMianse1
            // 
            this.rdMianse1.AutoSize = true;
            this.rdMianse1.Location = new System.Drawing.Point(88, 6);
            this.rdMianse1.Name = "rdMianse1";
            this.rdMianse1.Size = new System.Drawing.Size(67, 24);
            this.rdMianse1.TabIndex = 152;
            this.rdMianse1.TabStop = true;
            this.rdMianse1.Text = "红润";
            this.rdMianse1.UseVisualStyleBackColor = true;
            // 
            // dtpVisit
            // 
            this.dtpVisit.Location = new System.Drawing.Point(201, 3);
            this.dtpVisit.Name = "dtpVisit";
            this.dtpVisit.Size = new System.Drawing.Size(178, 30);
            this.dtpVisit.TabIndex = 0;
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
            this.panel5.Location = new System.Drawing.Point(905, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(445, 35);
            this.panel5.TabIndex = 1;
            // 
            // cbWeight
            // 
            this.cbWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeight.FormattingEnabled = true;
            this.cbWeight.Location = new System.Drawing.Point(210, 3);
            this.cbWeight.Name = "cbWeight";
            this.cbWeight.Size = new System.Drawing.Size(121, 28);
            this.cbWeight.TabIndex = 2;
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(148, 2);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(44, 31);
            this.btnWeight.TabIndex = 1;
            this.btnWeight.Text = ".....";
            this.btnWeight.UseVisualStyleBackColor = true;
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(113, 8);
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
            this.tbWeight.Location = new System.Drawing.Point(7, 3);
            this.tbWeight.MaxLength = 4;
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
            this.label67.Location = new System.Drawing.Point(0, 72);
            this.label67.Margin = new System.Windows.Forms.Padding(0);
            this.label67.Name = "label67";
            this.tableLayoutPanel1.SetRowSpan(this.label67, 8);
            this.label67.Size = new System.Drawing.Size(33, 266);
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
            this.label13.Size = new System.Drawing.Size(192, 35);
            this.label13.TabIndex = 100;
            this.label13.Text = "随访日期:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(96, 78);
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
            this.label29.Location = new System.Drawing.Point(803, 78);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(99, 20);
            this.label29.TabIndex = 162;
            this.label29.Text = "皮    肤:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(803, 244);
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
            this.label16.Size = new System.Drawing.Size(192, 37);
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
            this.panel12.Location = new System.Drawing.Point(198, 35);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(421, 37);
            this.panel12.TabIndex = 2;
            // 
            // cbBodyLength
            // 
            this.cbBodyLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodyLength.FormattingEnabled = true;
            this.cbBodyLength.Location = new System.Drawing.Point(175, 3);
            this.cbBodyLength.Name = "cbBodyLength";
            this.cbBodyLength.Size = new System.Drawing.Size(151, 28);
            this.cbBodyLength.TabIndex = 149;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(113, 8);
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
            this.tbBornLength.Location = new System.Drawing.Point(6, 4);
            this.tbBornLength.MaxLength = 3;
            this.tbBornLength.Multiline = true;
            this.tbBornLength.Name = "tbBornLength";
            this.tbBornLength.Size = new System.Drawing.Size(97, 28);
            this.tbBornLength.TabIndex = 111;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(773, 345);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(129, 20);
            this.label25.TabIndex = 252;
            this.label25.Text = "服用维生素D:";
            // 
            // panel17
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel17, 2);
            this.panel17.Controls.Add(this.label28);
            this.panel17.Controls.Add(this.tbVD);
            this.panel17.Location = new System.Drawing.Point(905, 338);
            this.panel17.Margin = new System.Windows.Forms.Padding(0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(197, 34);
            this.panel17.TabIndex = 21;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(111, 10);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(59, 20);
            this.label28.TabIndex = 149;
            this.label28.Text = "IU/日";
            // 
            // tbVD
            // 
            this.tbVD.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbVD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbVD.ForeColor = System.Drawing.Color.Black;
            this.tbVD.Location = new System.Drawing.Point(5, 3);
            this.tbVD.MaxLength = 3;
            this.tbVD.Multiline = true;
            this.tbVD.Name = "tbVD";
            this.tbVD.Size = new System.Drawing.Size(97, 28);
            this.tbVD.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(96, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 244;
            this.label5.Text = "眼 外 观:";
            // 
            // panel6
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 2);
            this.panel6.Controls.Add(this.rdYanwaiguan2);
            this.panel6.Controls.Add(this.rdYanwaiguan1);
            this.panel6.Location = new System.Drawing.Point(198, 136);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(306, 32);
            this.panel6.TabIndex = 8;
            // 
            // rdYanwaiguan2
            // 
            this.rdYanwaiguan2.AutoSize = true;
            this.rdYanwaiguan2.Location = new System.Drawing.Point(169, 6);
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
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(803, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 241;
            this.label2.Text = "耳 外 观:";
            // 
            // panel7
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel7, 2);
            this.panel7.Controls.Add(this.rdEr2);
            this.panel7.Controls.Add(this.rdEr1);
            this.panel7.Location = new System.Drawing.Point(905, 136);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(308, 31);
            this.panel7.TabIndex = 9;
            // 
            // rdEr2
            // 
            this.rdEr2.AutoSize = true;
            this.rdEr2.Location = new System.Drawing.Point(155, 6);
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
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(96, 174);
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
            this.panel_tingli.Location = new System.Drawing.Point(198, 168);
            this.panel_tingli.Margin = new System.Windows.Forms.Padding(0);
            this.panel_tingli.Name = "panel_tingli";
            this.panel_tingli.Size = new System.Drawing.Size(306, 33);
            this.panel_tingli.TabIndex = 10;
            // 
            // rdTingl2
            // 
            this.rdTingl2.AutoSize = true;
            this.rdTingl2.Location = new System.Drawing.Point(169, 6);
            this.rdTingl2.Name = "rdTingl2";
            this.rdTingl2.Size = new System.Drawing.Size(67, 24);
            this.rdTingl2.TabIndex = 153;
            this.rdTingl2.TabStop = true;
            this.rdTingl2.Text = "异常";
            this.rdTingl2.UseVisualStyleBackColor = true;
            // 
            // rdTingl1
            // 
            this.rdTingl1.AutoSize = true;
            this.rdTingl1.Location = new System.Drawing.Point(4, 6);
            this.rdTingl1.Name = "rdTingl1";
            this.rdTingl1.Size = new System.Drawing.Size(107, 24);
            this.rdTingl1.TabIndex = 152;
            this.rdTingl1.TabStop = true;
            this.rdTingl1.Text = "未见异常";
            this.rdTingl1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(96, 208);
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
            this.panel10.Location = new System.Drawing.Point(198, 201);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(306, 35);
            this.panel10.TabIndex = 12;
            // 
            // rdXiongb2
            // 
            this.rdXiongb2.AutoSize = true;
            this.rdXiongb2.Location = new System.Drawing.Point(169, 3);
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
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(803, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 243;
            this.label4.Text = "腹    部:";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.rdFub2);
            this.panel2.Controls.Add(this.rdFub1);
            this.panel2.Location = new System.Drawing.Point(905, 201);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 35);
            this.panel2.TabIndex = 13;
            // 
            // rdFub2
            // 
            this.rdFub2.AutoSize = true;
            this.rdFub2.Location = new System.Drawing.Point(155, 6);
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
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(36, 279);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(159, 20);
            this.label18.TabIndex = 249;
            this.label18.Text = "可疑佝偻病症状:";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(783, 312);
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
            this.panel15.Location = new System.Drawing.Point(905, 306);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(308, 32);
            this.panel15.TabIndex = 19;
            // 
            // btnSelectHB
            // 
            this.btnSelectHB.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectHB.Location = new System.Drawing.Point(157, 2);
            this.btnSelectHB.Name = "btnSelectHB";
            this.btnSelectHB.Size = new System.Drawing.Size(40, 27);
            this.btnSelectHB.TabIndex = 175;
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
            this.label22.Location = new System.Drawing.Point(105, 7);
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
            this.tbHem.Location = new System.Drawing.Point(4, 2);
            this.tbHem.MaxLength = 3;
            this.tbHem.Multiline = true;
            this.tbHem.Name = "tbHem";
            this.tbHem.Size = new System.Drawing.Size(97, 28);
            this.tbHem.TabIndex = 148;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(803, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 153;
            this.label9.Text = "体    重:";
            // 
            // panel_GLzhengz
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_GLzhengz, 2);
            this.panel_GLzhengz.Controls.Add(this.cbGLZhengzh);
            this.panel_GLzhengz.Location = new System.Drawing.Point(198, 272);
            this.panel_GLzhengz.Margin = new System.Windows.Forms.Padding(0);
            this.panel_GLzhengz.Name = "panel_GLzhengz";
            this.panel_GLzhengz.Size = new System.Drawing.Size(306, 34);
            this.panel_GLzhengz.TabIndex = 16;
            // 
            // cbGLZhengzh
            // 
            this.cbGLZhengzh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbGLZhengzh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGLZhengzh.FormattingEnabled = true;
            this.cbGLZhengzh.Location = new System.Drawing.Point(2, 2);
            this.cbGLZhengzh.Name = "cbGLZhengzh";
            this.cbGLZhengzh.Size = new System.Drawing.Size(189, 28);
            this.cbGLZhengzh.TabIndex = 258;
            // 
            // panel_GLTizh
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_GLTizh, 2);
            this.panel_GLTizh.Controls.Add(this.cbGLTizh);
            this.panel_GLTizh.Location = new System.Drawing.Point(905, 272);
            this.panel_GLTizh.Margin = new System.Windows.Forms.Padding(0);
            this.panel_GLTizh.Name = "panel_GLTizh";
            this.panel_GLTizh.Size = new System.Drawing.Size(306, 34);
            this.panel_GLTizh.TabIndex = 17;
            // 
            // cbGLTizh
            // 
            this.cbGLTizh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbGLTizh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGLTizh.FormattingEnabled = true;
            this.cbGLTizh.Location = new System.Drawing.Point(2, 3);
            this.cbGLTizh.Name = "cbGLTizh";
            this.cbGLTizh.Size = new System.Drawing.Size(189, 28);
            this.cbGLTizh.TabIndex = 259;
            // 
            // dtpNext
            // 
            this.dtpNext.Location = new System.Drawing.Point(201, 554);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(177, 30);
            this.dtpNext.TabIndex = 29;
            // 
            // tbDoctorMark
            // 
            this.tbDoctorMark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDoctorMark.ForeColor = System.Drawing.Color.Black;
            this.tbDoctorMark.Location = new System.Drawing.Point(622, 554);
            this.tbDoctorMark.MaxLength = 20;
            this.tbDoctorMark.Name = "tbDoctorMark";
            this.tbDoctorMark.Size = new System.Drawing.Size(189, 30);
            this.tbDoctorMark.TabIndex = 30;
            this.tbDoctorMark.Visible = false;
            // 
            // label79
            // 
            this.label79.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label79.Location = new System.Drawing.Point(477, 558);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(139, 20);
            this.label79.TabIndex = 190;
            this.label79.Text = "随访医生签名:";
            this.label79.Visible = false;
            // 
            // panel9
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel9, 2);
            this.panel9.Controls.Add(this.label26);
            this.panel9.Location = new System.Drawing.Point(3, 412);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(148, 24);
            this.panel9.TabIndex = 254;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(5, 3);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(199, 20);
            this.label26.TabIndex = 253;
            this.label26.Text = "两次随访间患病情况:";
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel13, 5);
            this.panel13.Controls.Add(this.label43);
            this.panel13.Controls.Add(this.tbHbqt);
            this.panel13.Controls.Add(this.label44);
            this.panel13.Controls.Add(this.label41);
            this.panel13.Controls.Add(this.tbWscs);
            this.panel13.Controls.Add(this.label42);
            this.panel13.Controls.Add(this.label39);
            this.panel13.Controls.Add(this.tbFxcs);
            this.panel13.Controls.Add(this.label40);
            this.panel13.Controls.Add(this.label38);
            this.panel13.Controls.Add(this.tbFycs);
            this.panel13.Controls.Add(this.label37);
            this.panel13.Location = new System.Drawing.Point(198, 409);
            this.panel13.Margin = new System.Windows.Forms.Padding(0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1152, 36);
            this.panel13.TabIndex = 255;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(4, 11);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 20);
            this.label43.TabIndex = 12;
            this.label43.Text = "无";
            // 
            // tbHbqt
            // 
            this.tbHbqt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHbqt.Location = new System.Drawing.Point(607, 3);
            this.tbHbqt.Name = "tbHbqt";
            this.tbHbqt.Size = new System.Drawing.Size(256, 30);
            this.tbHbqt.TabIndex = 11;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(546, 11);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(49, 20);
            this.label44.TabIndex = 10;
            this.label44.Text = "其他";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(471, 11);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(29, 20);
            this.label41.TabIndex = 9;
            this.label41.Text = "次";
            // 
            // tbWscs
            // 
            this.tbWscs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWscs.Location = new System.Drawing.Point(427, 3);
            this.tbWscs.Name = "tbWscs";
            this.tbWscs.Size = new System.Drawing.Size(36, 30);
            this.tbWscs.TabIndex = 8;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(379, 11);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(49, 20);
            this.label42.TabIndex = 7;
            this.label42.Text = "外伤";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(311, 11);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(29, 20);
            this.label39.TabIndex = 6;
            this.label39.Text = "次";
            // 
            // tbFxcs
            // 
            this.tbFxcs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFxcs.Location = new System.Drawing.Point(269, 3);
            this.tbFxcs.Name = "tbFxcs";
            this.tbFxcs.Size = new System.Drawing.Size(36, 30);
            this.tbFxcs.TabIndex = 5;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(220, 11);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(49, 20);
            this.label40.TabIndex = 4;
            this.label40.Text = "腹泻";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(158, 11);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(29, 20);
            this.label38.TabIndex = 3;
            this.label38.Text = "次";
            // 
            // tbFycs
            // 
            this.tbFycs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFycs.Location = new System.Drawing.Point(116, 3);
            this.tbFycs.Name = "tbFycs";
            this.tbFycs.Size = new System.Drawing.Size(36, 30);
            this.tbFycs.TabIndex = 2;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(60, 11);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(49, 20);
            this.label37.TabIndex = 1;
            this.label37.Text = "肺炎";
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.rdZhuanzhenHave);
            this.panel20.Controls.Add(this.rdZhuanzhenNo);
            this.panel20.Location = new System.Drawing.Point(201, 448);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(173, 28);
            this.panel20.TabIndex = 25;
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
            this.label10.Location = new System.Drawing.Point(517, 452);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 181;
            this.label10.Text = "转诊原因:";
            // 
            // tbZhuanzhenResult
            // 
            this.tbZhuanzhenResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenResult.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenResult.Location = new System.Drawing.Point(622, 448);
            this.tbZhuanzhenResult.MaxLength = 20;
            this.tbZhuanzhenResult.Multiline = true;
            this.tbZhuanzhenResult.Name = "tbZhuanzhenResult";
            this.tbZhuanzhenResult.ReadOnly = true;
            this.tbZhuanzhenResult.Size = new System.Drawing.Size(202, 28);
            this.tbZhuanzhenResult.TabIndex = 26;
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label68.Location = new System.Drawing.Point(967, 452);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(119, 20);
            this.label68.TabIndex = 186;
            this.label68.Text = "机构及科室:";
            // 
            // tbZhuanzhenKs
            // 
            this.tbZhuanzhenKs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenKs.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenKs.Location = new System.Drawing.Point(1092, 448);
            this.tbZhuanzhenKs.MaxLength = 20;
            this.tbZhuanzhenKs.Multiline = true;
            this.tbZhuanzhenKs.Name = "tbZhuanzhenKs";
            this.tbZhuanzhenKs.ReadOnly = true;
            this.tbZhuanzhenKs.Size = new System.Drawing.Size(182, 28);
            this.tbZhuanzhenKs.TabIndex = 27;
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(36, 445);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(159, 34);
            this.label34.TabIndex = 177;
            this.label34.Text = "转诊建议:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(116, 486);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(79, 20);
            this.label32.TabIndex = 256;
            this.label32.Text = "联系人:";
            // 
            // tbZhuanzhenlxr
            // 
            this.tbZhuanzhenlxr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenlxr.Location = new System.Drawing.Point(201, 482);
            this.tbZhuanzhenlxr.Name = "tbZhuanzhenlxr";
            this.tbZhuanzhenlxr.ReadOnly = true;
            this.tbZhuanzhenlxr.Size = new System.Drawing.Size(191, 30);
            this.tbZhuanzhenlxr.TabIndex = 257;
            // 
            // label45
            // 
            this.label45.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(517, 486);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(99, 20);
            this.label45.TabIndex = 258;
            this.label45.Text = "联系方式:";
            // 
            // tbZhuanzhenlxfs
            // 
            this.tbZhuanzhenlxfs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenlxfs.Location = new System.Drawing.Point(622, 482);
            this.tbZhuanzhenlxfs.Name = "tbZhuanzhenlxfs";
            this.tbZhuanzhenlxfs.ReadOnly = true;
            this.tbZhuanzhenlxfs.Size = new System.Drawing.Size(202, 30);
            this.tbZhuanzhenlxfs.TabIndex = 259;
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(997, 486);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(89, 20);
            this.label46.TabIndex = 260;
            this.label46.Text = "是否到位";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.rdDw2);
            this.panel14.Controls.Add(this.rdDw1);
            this.panel14.Enabled = false;
            this.panel14.Location = new System.Drawing.Point(1092, 482);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(235, 28);
            this.panel14.TabIndex = 261;
            // 
            // rdDw2
            // 
            this.rdDw2.AutoSize = true;
            this.rdDw2.Location = new System.Drawing.Point(99, 3);
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
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(743, 279);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(159, 20);
            this.label19.TabIndex = 250;
            this.label19.Text = "可疑佝偻病体征:";
            // 
            // panel22
            // 
            this.panel22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel22, 6);
            this.panel22.Controls.Add(this.lkYs);
            this.panel22.Controls.Add(this.picSignYs);
            this.panel22.Controls.Add(this.label48);
            this.panel22.Controls.Add(this.lkJs);
            this.panel22.Controls.Add(this.picSignJs);
            this.panel22.Controls.Add(this.label47);
            this.panel22.Location = new System.Drawing.Point(33, 586);
            this.panel22.Margin = new System.Windows.Forms.Padding(0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(1317, 48);
            this.panel22.TabIndex = 264;
            // 
            // lkYs
            // 
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(371, 19);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 265;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(173, 3);
            this.picSignYs.Margin = new System.Windows.Forms.Padding(0);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(187, 42);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 264;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // label48
            // 
            this.label48.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(19, 14);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(139, 20);
            this.label48.TabIndex = 266;
            this.label48.Text = "随访医生签名:";
            // 
            // lkJs
            // 
            this.lkJs.AutoSize = true;
            this.lkJs.Location = new System.Drawing.Point(1083, 15);
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
            this.picSignJs.Location = new System.Drawing.Point(885, 3);
            this.picSignJs.Margin = new System.Windows.Forms.Padding(0);
            this.picSignJs.Name = "picSignJs";
            this.picSignJs.Size = new System.Drawing.Size(187, 42);
            this.picSignJs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJs.TabIndex = 0;
            this.picSignJs.TabStop = false;
            this.picSignJs.Click += new System.EventHandler(this.picSignJs_Click);
            // 
            // label47
            // 
            this.label47.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(770, 14);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(99, 20);
            this.label47.TabIndex = 262;
            this.label47.Text = "家长签名:";
            // 
            // KidsWithinOneYearOldVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "KidsWithinOneYearOldVisitForm";
            this.Text = "KidsWithinOneYearOldVisitForm";
            this.Load += new System.EventHandler(this.FrmChildWithinAgeOne_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmChildWithinAgeOne_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_qib.ResumeLayout(false);
            this.panel_qib.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel_kouqiang.ResumeLayout(false);
            this.panel_kouqiang.PerformLayout();
            this.panel_Jingb.ResumeLayout(false);
            this.panel_Jingb.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel_tingli.ResumeLayout(false);
            this.panel_tingli.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel_GLzhengz.ResumeLayout(false);
            this.panel_GLTizh.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
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
                this.panel14.Enabled = true ;
            }
        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            if (GlbTools.IsChanged(this.srcData, this.ChildWithinOne, new string[] { "VisitDate", "NextVisitDate", "FollowUpDoctorSign" }))
            {
                
                KidsWithinOneYearOldBLL child_within_one_year_old = new KidsWithinOneYearOldBLL();
                if (child_within_one_year_old.Exists(this.ChildWithinOne.ID))
                {
                    child_within_one_year_old.Update(this.ChildWithinOne);
                }
                else
                {
                    child_within_one_year_old.Add(this.ChildWithinOne);
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
            this.ChildWithinOne.VisitDate = new DateTime?(this.dtpVisit.Value.Date);
            this.ChildWithinOne.NextFollowupDate = new DateTime?(this.dtpNext.Value.Date);
            if ((this.ChildWithinOne.PneumoniaCounts + this.ChildWithinOne.DiarrheaCounts + this.ChildWithinOne.TraumaCounts) < 0
                && !string.IsNullOrEmpty(this.tbHbqt.Text))
            {
                this.ChildWithinOne.SickNone = "无";
            }
            else
            {
                this.ChildWithinOne.SickNone = "有";
            }
            if (this.rdDw1.Checked)
            {
                this.ChildWithinOne.ReferralResult = "1";
            }
            else if (this.rdDw2.Checked)
            {
                this.ChildWithinOne.ReferralResult = "2";
            }
            else
            {
                this.ChildWithinOne.ReferralResult = null;
            }

        }

        private KidsWithinOneYearOldModel ChildWithinOne { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public object srcData { get; set; }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.monthAgeIndex == 1)
            {
                Clear("_Month_1", picSignJs);
            }
            else if (this.monthAgeIndex == 2)
            {
                Clear("_Month_3", picSignJs);
            }
            else if (this.monthAgeIndex == 3)
            {
                Clear("_Month_6", picSignJs);
            }
            else if (this.monthAgeIndex == 4)
            {
                Clear("_Month_8", picSignJs);
            }
        }
        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.monthAgeIndex == 1)
            {
                Clear("_Month_1_Doc", picSignYs);
            }
            else if (this.monthAgeIndex == 2)
            {
                Clear("_Month_3_Doc", picSignYs);
            }
            else if (this.monthAgeIndex == 3)
            {
                Clear("_Month_6_Doc", picSignYs);
            }
            else if (this.monthAgeIndex == 4)
            {
                Clear("_Month_8_Doc", picSignYs);
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
        private void picSignYs_Click(object sender, EventArgs e)
        {
            if (this.monthAgeIndex == 1)
            {
                Sign("_Month_1_Doc", picSignYs);
            }
            else if (this.monthAgeIndex == 2)
            {
                Sign("_Month_3_Doc", picSignYs);
            }
            else if (this.monthAgeIndex == 3)
            {
                Sign("_Month_6_Doc", picSignYs);
            }
            else if (this.monthAgeIndex == 4)
            {
                Sign("_Month_8_Doc", picSignYs);
            }
        }

        private void picSignJs_Click(object sender, EventArgs e)
        {
            if (this.monthAgeIndex == 1)
            {
                Sign("_Month_1", picSignJs);
            }
            else if (this.monthAgeIndex == 2)
            {
                Sign("_Month_3", picSignJs);
            }
            else if (this.monthAgeIndex == 3)
            {
                Sign("_Month_6", picSignJs);
            }
            else if (this.monthAgeIndex == 4)
            {
                Sign("_Month_8", picSignJs);
            }
        }
    }
}

