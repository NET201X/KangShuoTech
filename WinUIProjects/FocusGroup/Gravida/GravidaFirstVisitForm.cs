
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using System.IO;
using System.Drawing;
using System.Configuration;

namespace FocusGroup.Gravida
{
    public class GravidaFirstVisitForm : Form, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<WomenGravidaFirstVisitModel> bindingManager_GF;
        private SimpleBindingManager<WomenGravidaPreAssistCheckModel> bindingManager_GFC;
        private Button btnAssistCheck;
        private Button btnBaseInfo;
        private Button btnCountBMI;
        private Button btnDown;
        private Button btnFPGL;
        private Button btnSelectHB;
        private Button btnSelectHyp;
        private Button btnSelectNiao;
        private Button btnUp;
        private Button btnWeight;
        private ComboBox cbVaginCleaess;
        private CheckBox ckBJBeforXX;
        private CheckBox ckBJBmblyx;
        private CheckBox ckBJEX;
        private CheckBox ckBJPerHealth;
        private CheckBox ckBJXinl;
        private CheckBox ckBJYingy;
        private CheckBox ckDichong;
        private CheckBox ckFam1;
        private CheckBox ckFam2;
        private CheckBox ckFam3;
        private CheckBox ckJsjmj;
        private CheckBox ckJws2;
        private CheckBox ckJws3;
        private CheckBox ckJws4;
        private CheckBox ckJws5;
        private CheckBox ckJws6;
        private CheckBox ckJws7;
        private CheckBox ckJws8;
        private CheckBox ckJwsNo;
        private CheckBox ckPerHis1;
        private CheckBox ckPerHis2;
        private CheckBox ckPerHis3;
        private CheckBox ckPerHis4;
        private CheckBox ckPerHis5;
        private CheckBox ckPerHis6;
        private CheckBox ckVaginEx;
        private CheckBox ckVaginNormal;
        private IContainer components;
        private DateTimePicker dtpExpectedDate;
        private DateTimePicker dtpLastMenstruation;
        private DateTimePicker dtpNext;
        private DateTimePicker dtpTypeDate;
        private SingleItemT<WomenGravidaFirstVisitModel> fei;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private SingleItemT<WomenGravidaFirstVisitModel> fujian;
        private SingleItemT<WomenGravidaFirstVisitModel> fukeshoushushi;
        private ManyCheckboxs<WomenGravidaFirstVisitModel> gerenshi;
        private SingleItemT<WomenGravidaFirstVisitModel> gongjing;
        private List<InputRangeStr> inputrange_str_GF;
        private List<InputRangeStr> inputrange_str_GFC;
        private List<InputRangeDec> inputRanges_GF;
        private List<InputRangeDec> inputRanges_GFC;
        private ManyCheckboxs<WomenGravidaFirstVisitModel> jiankangzhidao;
        private ManyCheckboxs<WomenGravidaFirstVisitModel> jiazhushi;
        private ManyCheckboxs<WomenGravidaFirstVisitModel> jiwangshi;
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
        private Label label2;
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
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label5;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label59;
        private Label label6;
        private Label label60;
        private Label label61;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label label65;
        private Label label66;
        private Label label67;
        private Label label68;
        private Label label69;
        private Label label7;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label73;
        private Label label74;
        private Label label75;
        private Label label76;
        private Label label77;
        private Label label78;
        private Label label79;
        private Label label8;
        private Label label80;
        private Label label81;
        private Label label82;
        private Label label83;
        private Label label84;
        private Label label85;
        private Label label86;
        private Label label87;
        private Label label88;
        private Label label89;
        private Label label9;
        private Label label90;
        private Label label91;
        private Label lbInfo;
        private Label lbName;
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
        private Panel panel18;
        private Panel panel19;
        private Panel panel2;
        private Panel panel20;
        private Panel panel21;
        private Panel panel22;
        private Panel panel23;
        private Panel panel24;
        private Panel panel25;
        private Panel panel26;
        private Panel panel27;
        private Panel panel28;
        private Panel panel29;
        private Panel panel3;
        private Panel panel30;
        private Panel panel31;
        private Panel panel32;
        private Panel panel33;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        public GravidaForm par_From;
        private RadioButton rdFujHave;
        private RadioButton rdFujNo;
        private RadioButton rdFukOpHave;
        private RadioButton rdFukOpNo;
        private RadioButton rdGongjHave;
        private RadioButton rdGongjNo;
        private RadioButton rdHeartHave;
        private RadioButton rdHeartNo;
        private RadioButton rdHIVYang;
        private RadioButton rdHIVYin;
        private RadioButton rdLastMHave;
        private RadioButton rdLastMNo;
        private RadioButton rdLungHave;
        private RadioButton rdLungNo;
        private RadioButton rdMeidYang;
        private RadioButton rdMeidYin;
        private RadioButton rdVaginHave;
        private RadioButton rdVaginNo;
        private RadioButton rdVulvaHave;
        private RadioButton rdVulvaNo;
        private RadioButton rdZhuanzhenHave;
        private RadioButton rdZhuanzhenNo;
        private RadioButton rdZigHave;
        private RadioButton rdZigNo;
        private RadioButton rdZtpgHave;
        private RadioButton rdZtpgNo;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox tbBloodEx;
        private TextBox tbBloodType;
        private TextBox tbBMI;
        private TextBox tbBornPGC;
        private TextBox tbBornYD;
        private TextBox tbBP;
        private TextBox tbBSuper;
        private TextBox tbBUN;
        private TextBox tbCB;
        private TextBox tbDeadBorn;
        private TextBox tbDeadFetus;
        private TextBox tbDeadNewBorn;
        private TextBox tbDoctorMark;
        private TextBox tbDropBaby;
        private TextBox tbFPGL;
        private TextBox tbFujEx;
        private TextBox tbGongjingEx;
        private TextBox tbGOT;
        private TextBox tbGrvAge;
        private TextBox tbGrvCount;
        private TextBox tbHB;
        private TextBox tbHBCAB;
        private TextBox tbHBEAB;
        private TextBox tbHBEAG;
        private TextBox tbHBSAB;
        private TextBox tbHBSAG;
        private TextBox tbHeartEX;
        private TextBox tbHeight;
        private TextBox tbHisOther;
        private TextBox tbHomeHisOther;
        private TextBox tbHusbandAge;
        private TextBox tbHusbandName;
        private TextBox tbHusbandPhone;
        private TextBox tbHype;
        private TextBox tbLungEx;
        private TextBox tbNewbornDefect;
        private TextBox tbNiao;
        private TextBox tbNiaoEx;
        private TextBox tbPersonOther;
        private TextBox tbPLT;
        private TextBox tbRh;
        private TextBox tbSCR;
        private TextBox tbSGPT;
        private TextBox tbTBIL;
        private TextBox tbVaginEx;
        private TextBox tbVulvaEx;
        private TextBox tbWBC;
        private TextBox tbWeek;
        private TextBox tbWeight;
        private TextBox tbWomenOperation;
        private TextBox tbYindEx;
        private TextBox tbZhuanzhenKs;
        private TextBox tbZhuanzhenResult;
        private TextBox tbZigEx;
        private TextBox tbZtpgEx;
        private System.Timers.Timer time_up;
        private System.Timers.Timer timer_down;
        private SingleItemT<WomenGravidaFirstVisitModel> waiyin;
        private SingleItemT<WomenGravidaFirstVisitModel> xinzhang;
        private SingleItemT<WomenGravidaFirstVisitModel> yindao;
        private ManyCheckboxs<WomenGravidaPreAssistCheckModel> yindaofenmiwu;
        private SingleItemT<WomenGravidaFirstVisitModel> zigong;
        private TextBox tbDropBaby2;
        private Label label92;
        private Label label93;
        private Panel panel34;
        private TextBox txtAssistOther;
        private Label label94;
        private Panel panel35;
        private TextBox tbBooks;
        private RadioButton rdBooks2;
        private RadioButton rdBooks1;
        private SingleItemT<WomenGravidaFirstVisitModel> zongtipinggu;
        private Label label97;
        private Panel panel36;
        private RadioButton rdwdw;
        private RadioButton rddw;
        private Label label95;
        private TextBox txtReferralContacts;
        private Label label96;
        private TextBox txtReferralContactsTel;
        private Label label98;
        private SingleItemT<WomenGravidaFirstVisitModel> jiance;
        private TextBox tbBJEX;
        private PictureBox picSignJs;
        private LinkLabel lkJs;
        private string SignS = "";
        private string SignDoc = "";
        private CheckBox ckFam4;
        private Panel panel37;
        private PictureBox picSignYs;
        private LinkLabel lkYs;
        private Label label99;//本人或家属签名
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Gravida/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Gravida//"; //签名保存路径

        public GravidaFirstVisitForm()
        {
            this.InitializeComponent();
            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel1.SuspendLayout();
            this.InitSomeControl();
            this.EveryThingIsOk = false;
            this.tableLayoutPanel1.ResumeLayout();
        }

        private void btnAssistCheck_Click(object sender, EventArgs e)
        {
            this.panel6.VerticalScroll.Value = 500;
            this.panel6.VerticalScroll.Value = 500;
        }

        private void btnBaseInfo_Click(object sender, EventArgs e)
        {
            this.panel6.VerticalScroll.Value = 0;
            this.panel6.VerticalScroll.Value = 0;
        }

        private void btnCountBMI_Click(object sender, EventArgs e)
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

        private void btnFPGL_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "24")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                if (select.m_Result.value1 == ".0")
                {
                    this.tbFPGL.Text = "0";
                }
                else
                {
                    this.tbFPGL.Text = select.m_Result.value1;
                }
            }
        }

        private void btnSelectHB_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "52")
            {
                ItemTypeName = "血红蛋白",
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tbHB.Text = select.m_Result.value1;
            }
        }

        private void btnSelectHyp_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "20")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.GrvFirst.HBloodpressure = new int?(int.Parse(select.m_Result.value1));
                this.GrvFirst.LBloodpressure = new int?(int.Parse(select.m_Result.value2));
                this.tbHype.Text = string.Format("{0}/{1}", this.GrvFirst.HBloodpressure.Value, this.GrvFirst.LBloodpressure.Value);
            }
        }

        private void btnSelectNiao_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "33")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.GrvFrCheck.PRO = select.m_Result.value6;
                this.GrvFrCheck.GLU = select.m_Result.value5;
                this.GrvFrCheck.KET = select.m_Result.value4;
                this.GrvFrCheck.BLD = select.m_Result.value2;
                this.tbNiao.Text = string.Format("蛋白质{0}/葡萄糖{1}/酮体{2}/潜血{3}", new object[] { this.GrvFrCheck.PRO, this.GrvFrCheck.GLU, this.GrvFrCheck.KET, this.GrvFrCheck.BLD });
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
            bool flag = this.bindingManager_GF.ErrorInput || this.bindingManager_GFC.ErrorInput;
            if (((!this.jiwangshi.ErrorInput && !this.jiazhushi.ErrorInput) && (!this.gerenshi.ErrorInput && !this.xinzhang.ErrorInput)) && !this.fei.ErrorInput)
            {
                bool errorInput = this.waiyin.ErrorInput;
            }
            if (((!this.yindao.ErrorInput && !this.gongjing.ErrorInput) && (!this.zigong.ErrorInput && !this.fujian.ErrorInput)) && (!this.yindaofenmiwu.ErrorInput && !this.zongtipinggu.ErrorInput))
            {
                bool flag6 = this.jiankangzhidao.ErrorInput;
            }
            bool flag2 = false;
            if (this.dtpTypeDate.Value.Date > DateTime.Today)
            {
                this.SaveDataInfo = "填表日期不能大于当前日期!";
                flag2 = true;
            }
            bool flag3 = false;
            if (this.dtpExpectedDate.Value < DateTime.Today)
            {
                GravidaFirstVisitForm visit = this;
                string str = visit.SaveDataInfo + "\r\n预产期错误,不能小于当前日期!";
                visit.SaveDataInfo = str;
                flag3 = true;
            }
            bool flag4 = false;
            if (!this.rdLastMNo.Checked && (this.dtpLastMenstruation.Value.Date >= this.dtpExpectedDate.Value.Date))
            {
                GravidaFirstVisitForm visit2 = this;
                string str2 = visit2.SaveDataInfo + "\r\n预产期应当大于末次月经日期";
                visit2.SaveDataInfo = str2;
                flag4 = true;
            }
            bool flag5 = false;
            if (this.tbWeek.Text == "")
            {
                GravidaFirstVisitForm visit3 = this;
                string str3 = visit3.SaveDataInfo + "孕周不能为空";
                visit3.SaveDataInfo = str3;
                flag5 = true;
            }
            if ((!flag && !flag2) && ((!flag3 && !flag4) && !flag5))
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

        private void FrmGrvFirstVisit_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(SignPath))
            {
                Directory.CreateDirectory(SignPath);
            }

            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void InitEveryThing()
        {
            this.InitModel();
            this.InitGrvFollow();
            this.InitGrvAssitCheck();

            this.SignS = string.Format("{0}{1}_{2}.png", SignPath, Model.IDCardNo, "PrenatalS_1");
            if (File.Exists(this.SignS))
            {
                Image imgeb = Image.FromFile(this.SignS);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSignJs.Image = bmp;
                picSignJs.Show();
                imgeb.Dispose();
                this.lkJs.Enabled = true;
                picSignJs.BackColor = Color.White;
            }
            this.SignDoc = string.Format("{0}{1}_{2}_Doc.png", SignPath, Model.IDCardNo, "PrenatalS_1");
            if (File.Exists(this.SignDoc))
            {
                Image imgeb = Image.FromFile(this.SignDoc);
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

        private void InitGrvAssitCheck()
        {
            this.bindingManager_GFC.SimpleBinding(this.tbHB, "HB", true);
            this.bindingManager_GFC.SimpleBinding(this.tbWBC, "WBC", true);
            this.bindingManager_GFC.SimpleBinding(this.tbPLT, "PlT", true);
            this.bindingManager_GFC.SimpleBinding(this.tbBloodEx, "BloodOther", false);
            this.bindingManager_GFC.SimpleBinding(this.tbNiaoEx, "UrineOthers", false);
            string str = "";
            string bLOODTYPE = this.GrvFrCheck.BloodType;
            if (bLOODTYPE != null)
            {
                if (!(bLOODTYPE == "1"))
                {
                    if (bLOODTYPE == "2")
                    {
                        str = "B型";
                    }
                    else if (bLOODTYPE == "3")
                    {
                        str = "O型";
                    }
                    else if (bLOODTYPE == "4")
                    {
                        str = "AB型";
                    }
                    else if (bLOODTYPE == "5")
                    {
                        str = "不详";
                    }
                }
                else
                {
                    str = "A型";
                }
            }
            this.tbBloodType.Text = str;
            if (this.GrvFrCheck.RH == "1")
            {
                this.tbRh.Text = "阳性";
            }
            else if (this.GrvFrCheck.RH == "2")
            {
                this.tbRh.Text = "阴性";
            }
            else if (this.GrvFrCheck.RH == "3")
            {
                this.tbRh.Text = "不祥";
            }
            this.bindingManager_GFC.SimpleBinding(this.tbFPGL, "FPGL", true);
            this.bindingManager_GFC.SimpleBinding(this.tbSGPT, "SGPT", true);
            this.bindingManager_GFC.SimpleBinding(this.tbGOT, "GOT", true);
            this.bindingManager_GFC.SimpleBinding(this.tbBP, "BP", true);
            this.bindingManager_GFC.SimpleBinding(this.tbTBIL, "TBIL", true);
            this.bindingManager_GFC.SimpleBinding(this.tbCB, "CB", true);
            this.bindingManager_GFC.SimpleBinding(this.tbSCR, "SCR", true);
            this.bindingManager_GFC.SimpleBinding(this.tbBUN, "BUN", true);
            this.yindaofenmiwu = new ManyCheckboxs<WomenGravidaPreAssistCheckModel>(this.GrvFrCheck);
            this.yindaofenmiwu.AddCk(new LoneCheckbox(this.ckVaginNormal, true));
            this.yindaofenmiwu.AddCk(new LoneCheckbox(this.ckDichong));
            this.yindaofenmiwu.AddCk(new LoneCheckbox(this.ckJsjmj));
            this.yindaofenmiwu.AddCk(new LoneCheckbox(this.ckVaginEx, this.tbVaginEx));
            this.yindaofenmiwu.BindingProperty("VaginalSecretions", "VaginalSecretionSothers");
            this.bindingManager_GFC.SimpleBinding(this.cbVaginCleaess, "VaginalCleaess");
            this.bindingManager_GFC.SimpleBinding(this.tbHBSAG, "HBSAG", false);
            this.bindingManager_GFC.SimpleBinding(this.tbHBSAB, "HBSAB", false);
            this.bindingManager_GFC.SimpleBinding(this.tbHBEAG, "HBEAG", false);
            this.bindingManager_GFC.SimpleBinding(this.tbHBEAB, "HBEAB", false);
            this.bindingManager_GFC.SimpleBinding(this.tbHBCAB, "HBCAB", false);
            if (!string.IsNullOrEmpty(this.GrvFrCheck.LUES))
            {
                if (this.GrvFrCheck.LUES == "1")
                {
                    this.rdMeidYin.Checked = true;
                }
                else
                {
                    this.rdMeidYang.Checked = true;
                }
            }
            if (!string.IsNullOrEmpty(this.GrvFrCheck.HIV))
            {
                if (this.GrvFrCheck.HIV == "1")
                {
                    this.rdHIVYin.Checked = true;
                }
                else
                {
                    this.rdHIVYang.Checked = true;
                }
            }
            this.bindingManager_GFC.SimpleBinding(this.tbBSuper, "BCHAO", false);
            this.bindingManager_GFC.SimpleBinding(this.txtAssistOther, "AssistOther", false);
            SingleItemT<WomenGravidaFirstVisitModel> mt = new SingleItemT<WomenGravidaFirstVisitModel>(this.GrvFirst)
            {
                Name = "总体评估",
                Usual = this.rdZtpgNo,
                Unusual = this.rdZtpgHave,
                Info = this.tbZtpgEx,
                MaxBytesCount = 200
            };
            this.zongtipinggu = mt;
            this.zongtipinggu.BindProperty("OverAlassessMent", "OverAlassessmentEx");
            SingleItemT<WomenGravidaFirstVisitModel> jc = new SingleItemT<WomenGravidaFirstVisitModel>(this.GrvFirst)
            {
                Name = "建册情况",
                Usual = this.rdBooks1,
                Unusual = this.rdBooks2,
                Info = this.tbBooks,
                MaxBytesCount = 200
            };
            this.jiance = jc;
            this.jiance.BindProperty("BooksInfo", "BooksInstitution");

            this.jiankangzhidao = new ManyCheckboxs<WomenGravidaFirstVisitModel>(this.GrvFirst);
            this.jiankangzhidao.AddCk(new LoneCheckbox(this.ckBJPerHealth));
            this.jiankangzhidao.AddCk(new LoneCheckbox(this.ckBJXinl));
            this.jiankangzhidao.AddCk(new LoneCheckbox(this.ckBJYingy));
            this.jiankangzhidao.AddCk(new LoneCheckbox(this.ckBJBmblyx));
            this.jiankangzhidao.AddCk(new LoneCheckbox(this.ckBJBeforXX));
            this.jiankangzhidao.AddCk(new LoneCheckbox(this.ckBJEX, this.tbBJEX));
            this.jiankangzhidao.BindingProperty("HealthZhiDao", "HealthZhiDaoOthers");
            if (!string.IsNullOrEmpty(this.GrvFirst.Referral))
            {
                if (this.GrvFirst.Referral == "1")
                {
                    this.rdZhuanzhenNo.Checked = true;
                }
                else
                {
                    this.rdZhuanzhenHave.Checked = true;
                }
            }
            else
            {
                this.rdZhuanzhenNo.Checked = true;
            }
            this.bindingManager_GF.SimpleBinding(this.tbZhuanzhenResult, "ReferralReason", false);
            this.bindingManager_GF.SimpleBinding(this.tbZhuanzhenKs, "ReferralOrg", false);
            this.bindingManager_GF.SimpleBinding(this.txtReferralContacts, "ReferralContacts", false);
            this.bindingManager_GF.SimpleBinding(this.txtReferralContactsTel, "ReferralContactsTel", false);
            if (this.GrvFirst.ReferralResult == "1")
            {
                this.rddw.Checked = true;
            }
            else if (this.GrvFirst.ReferralResult == "2")
            {
                this.rdwdw.Checked = true;
            }
            if (this.GrvFirst.NextfollowupDate.HasValue)
            {
                this.dtpNext.Value = this.GrvFirst.NextfollowupDate.Value;
            }

            this.bindingManager_GF.SimpleBinding(this.tbDoctorMark, "FollowUpDoctor", false);
        }

        private void InitGrvFollow()
        {
            this.lbName.Text = this.Model.CustomerName;
            if (this.GrvFirst.RecordDate.HasValue)
            {
                this.dtpTypeDate.Value = this.GrvFirst.RecordDate.Value;
            }

            if (this.GrvFirst.CustomerAge.HasValue)
            {
                this.tbGrvAge.Text = this.GrvFirst.CustomerAge.Value.ToString();
            }

            this.bindingManager_GF.SimpleBindingInt(this.tbWeek, "PregancyWeeks", true);
            this.bindingManager_GF.SimpleBinding(this.tbHusbandName, "HusbandName", false);
            this.bindingManager_GF.SimpleBindingInt(this.tbHusbandAge, "HusbandAge", true);
            this.bindingManager_GF.SimpleBindingPhoneNum(this.tbHusbandPhone, "HusbandPhone", false);
            this.bindingManager_GF.SimpleBindingInt(this.tbGrvCount, "PregancyCount", true);
            this.bindingManager_GF.SimpleBindingInt(this.tbBornYD, "NatrualChildBirthCount", true);
            this.bindingManager_GF.SimpleBindingInt(this.tbBornPGC, "CaeSareanCount", true);
            if (string.IsNullOrEmpty(this.GrvFirst.LastMenStruation))
            {
                this.rdLastMNo.Checked = true;
            }
            else if (this.GrvFirst.LastMenStruation == "0")
            {
                this.rdLastMNo.Checked = true;
            }
            else
            {
                this.rdLastMHave.Checked = true;
                this.dtpLastMenstruation.Value = this.GrvFirst.LastMenStruationDate.Value;
            }
            if (this.GrvFirst.ExpectedDueDate.HasValue)
            {
                this.dtpExpectedDate.Value = this.GrvFirst.ExpectedDueDate.Value;
            }
            this.jiwangshi = new ManyCheckboxs<WomenGravidaFirstVisitModel>(this.GrvFirst, 100);
            this.jiwangshi.AddCk(new LoneCheckbox(this.ckJwsNo, true));
            this.jiwangshi.AddCk(new LoneCheckbox(this.ckJws2));
            this.jiwangshi.AddCk(new LoneCheckbox(this.ckJws3));
            this.jiwangshi.AddCk(new LoneCheckbox(this.ckJws4));
            this.jiwangshi.AddCk(new LoneCheckbox(this.ckJws5));
            this.jiwangshi.AddCk(new LoneCheckbox(this.ckJws6));
            this.jiwangshi.AddCk(new LoneCheckbox(this.ckJws7));
            this.jiwangshi.AddCk(new LoneCheckbox(this.ckJws8, this.tbHisOther));
            this.jiwangshi.BindingProperty("CustomerHistory", "CustomerHistoryEx");
            this.jiazhushi = new ManyCheckboxs<WomenGravidaFirstVisitModel>(this.GrvFirst, 100);
            this.jiazhushi.AddCk(new LoneCheckbox(this.ckFam4));
            this.jiazhushi.AddCk(new LoneCheckbox(this.ckFam1));
            this.jiazhushi.AddCk(new LoneCheckbox(this.ckFam2));
            this.jiazhushi.AddCk(new LoneCheckbox(this.ckFam3, this.tbHomeHisOther));
            this.jiazhushi.BindingProperty("FamilyHistory", "FamilyHistoryEx");
            this.gerenshi = new ManyCheckboxs<WomenGravidaFirstVisitModel>(this.GrvFirst, 100);
            this.gerenshi.AddCk(new LoneCheckbox(this.ckPerHis1));
            this.gerenshi.AddCk(new LoneCheckbox(this.ckPerHis2));
            this.gerenshi.AddCk(new LoneCheckbox(this.ckPerHis3));
            this.gerenshi.AddCk(new LoneCheckbox(this.ckPerHis4));
            this.gerenshi.AddCk(new LoneCheckbox(this.ckPerHis5));
            this.gerenshi.AddCk(new LoneCheckbox(this.ckPerHis6, this.tbPersonOther));
            this.gerenshi.BindingProperty("PersonalHistory", "PersonalHistoryEx");
            SingleItemT<WomenGravidaFirstVisitModel> mt = new SingleItemT<WomenGravidaFirstVisitModel>(this.GrvFirst)
            {
                Name = "妇科手术史",
                Usual = this.rdFukOpNo,
                Unusual = this.rdFukOpHave,
                Info = this.tbWomenOperation,
                MaxBytesCount = 200
            };
            this.fukeshoushushi = mt;
            this.fukeshoushushi.BindProperty("GyNecoloGyHistory", "GynecologyHistoryEx");
            this.bindingManager_GF.SimpleBinding(this.tbDropBaby, "AbortionInfo", false);
            this.bindingManager_GF.SimpleBinding(this.tbDropBaby2, "ArtificialAbortion", false);
            this.bindingManager_GF.SimpleBinding(this.tbDeadFetus, "Deadfetus", false);
            this.bindingManager_GF.SimpleBinding(this.tbDeadBorn, "StillBirthInfo", false);
            this.bindingManager_GF.SimpleBinding(this.tbDeadNewBorn, "NewBornDead", false);
            this.bindingManager_GF.SimpleBinding(this.tbNewbornDefect, "NewBornDefect", false);
            this.bindingManager_GF.SimpleBinding(this.tbHeight, "Height", true);
            this.bindingManager_GF.SimpleBinding(this.tbWeight, "Weight", true);
            this.bindingManager_GF.SimpleBinding(this.tbBMI, "BMI", true);
            if (this.GrvFirst.HBloodpressure.HasValue && this.GrvFirst.LBloodpressure.HasValue)
            {
                this.tbHype.Text = string.Format("{0}/{1}", this.GrvFirst.HBloodpressure.Value, this.GrvFirst.LBloodpressure.Value);
            }
            SingleItemT<WomenGravidaFirstVisitModel> mt2 = new SingleItemT<WomenGravidaFirstVisitModel>(this.GrvFirst)
            {
                Name = "心脏",
                Usual = this.rdHeartNo,
                Unusual = this.rdHeartHave,
                Info = this.tbHeartEX,
                MaxBytesCount = 100
            };
            this.xinzhang = mt2;
            this.xinzhang.BindProperty("Heart", "Heartex");
            SingleItemT<WomenGravidaFirstVisitModel> mt3 = new SingleItemT<WomenGravidaFirstVisitModel>(this.GrvFirst)
            {
                Name = "肺部",
                Usual = this.rdLungNo,
                Unusual = this.rdLungHave,
                Info = this.tbLungEx,
                MaxBytesCount = 100
            };
            this.fei = mt3;
            this.fei.BindProperty("Lung", "Lungex");
            SingleItemT<WomenGravidaFirstVisitModel> mt4 = new SingleItemT<WomenGravidaFirstVisitModel>(this.GrvFirst)
            {
                Name = "外阴",
                Usual = this.rdVulvaNo,
                Unusual = this.rdVulvaHave,
                Info = this.tbVulvaEx,
                MaxBytesCount = 200
            };
            this.waiyin = mt4;
            this.waiyin.BindProperty("Vulva", "VulvaEx");
            SingleItemT<WomenGravidaFirstVisitModel> mt5 = new SingleItemT<WomenGravidaFirstVisitModel>(this.GrvFirst)
            {
                Name = "阴道",
                Usual = this.rdVaginNo,
                Unusual = this.rdVaginHave,
                Info = this.tbYindEx,
                MaxBytesCount = 200
            };
            this.yindao = mt5;
            this.yindao.BindProperty("Vagina", "VaginaEx");
            SingleItemT<WomenGravidaFirstVisitModel> mt6 = new SingleItemT<WomenGravidaFirstVisitModel>(this.GrvFirst)
            {
                Name = "宫颈",
                Usual = this.rdGongjNo,
                Unusual = this.rdGongjHave,
                Info = this.tbGongjingEx,
                MaxBytesCount = 200
            };
            this.gongjing = mt6;
            this.gongjing.BindProperty("CervixuTeri", "CervixuTeriex");
            SingleItemT<WomenGravidaFirstVisitModel> mt7 = new SingleItemT<WomenGravidaFirstVisitModel>(this.GrvFirst)
            {
                Name = "子宫",
                Usual = this.rdZigNo,
                Unusual = this.rdZigHave,
                Info = this.tbZigEx,
                MaxBytesCount = 200
            };
            this.zigong = mt7;
            this.zigong.BindProperty("Corpus", "CorpusEx");
            SingleItemT<WomenGravidaFirstVisitModel> mt8 = new SingleItemT<WomenGravidaFirstVisitModel>(this.GrvFirst)
            {
                Name = "附件",
                Usual = this.rdFujNo,
                Unusual = this.rdFujHave,
                Info = this.tbFujEx,
                MaxBytesCount = 200
            };
            this.fujian = mt8;
            this.fujian.BindProperty("Attach", "AttachEx");
        }

        private void InitializeComponent()
        {
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpTypeDate = new System.Windows.Forms.DateTimePicker();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label81 = new System.Windows.Forms.Label();
            this.tbWeek = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rdFujHave = new System.Windows.Forms.RadioButton();
            this.rdFujNo = new System.Windows.Forms.RadioButton();
            this.tbFujEx = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.rdZigHave = new System.Windows.Forms.RadioButton();
            this.rdZigNo = new System.Windows.Forms.RadioButton();
            this.tbZigEx = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.rdGongjHave = new System.Windows.Forms.RadioButton();
            this.rdGongjNo = new System.Windows.Forms.RadioButton();
            this.tbGongjingEx = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.rdVaginHave = new System.Windows.Forms.RadioButton();
            this.rdVaginNo = new System.Windows.Forms.RadioButton();
            this.tbYindEx = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.rdVulvaHave = new System.Windows.Forms.RadioButton();
            this.rdVulvaNo = new System.Windows.Forms.RadioButton();
            this.tbVulvaEx = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnSelectHyp = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.tbHype = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnWeight = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.ckFam4 = new System.Windows.Forms.CheckBox();
            this.ckFam1 = new System.Windows.Forms.CheckBox();
            this.ckFam2 = new System.Windows.Forms.CheckBox();
            this.ckFam3 = new System.Windows.Forms.CheckBox();
            this.tbHomeHisOther = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.ckJwsNo = new System.Windows.Forms.CheckBox();
            this.ckJws2 = new System.Windows.Forms.CheckBox();
            this.ckJws3 = new System.Windows.Forms.CheckBox();
            this.ckJws4 = new System.Windows.Forms.CheckBox();
            this.ckJws5 = new System.Windows.Forms.CheckBox();
            this.ckJws6 = new System.Windows.Forms.CheckBox();
            this.ckJws7 = new System.Windows.Forms.CheckBox();
            this.ckJws8 = new System.Windows.Forms.CheckBox();
            this.tbHisOther = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.tbBornPGC = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbBornYD = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbGrvCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbHusbandAge = new System.Windows.Forms.TextBox();
            this.tbHusbandName = new System.Windows.Forms.TextBox();
            this.tbHusbandPhone = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbDropBaby2 = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.tbNewbornDefect = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbDeadNewBorn = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbDeadBorn = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbDeadFetus = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbDropBaby = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbWomenOperation = new System.Windows.Forms.TextBox();
            this.rdFukOpHave = new System.Windows.Forms.RadioButton();
            this.rdFukOpNo = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ckPerHis1 = new System.Windows.Forms.CheckBox();
            this.ckPerHis2 = new System.Windows.Forms.CheckBox();
            this.ckPerHis3 = new System.Windows.Forms.CheckBox();
            this.ckPerHis4 = new System.Windows.Forms.CheckBox();
            this.ckPerHis5 = new System.Windows.Forms.CheckBox();
            this.ckPerHis6 = new System.Windows.Forms.CheckBox();
            this.tbPersonOther = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.rdLungHave = new System.Windows.Forms.RadioButton();
            this.rdLungNo = new System.Windows.Forms.RadioButton();
            this.tbLungEx = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.rdHeartHave = new System.Windows.Forms.RadioButton();
            this.rdHeartNo = new System.Windows.Forms.RadioButton();
            this.tbHeartEX = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGrvAge = new System.Windows.Forms.TextBox();
            this.panel32 = new System.Windows.Forms.Panel();
            this.rdLastMHave = new System.Windows.Forms.RadioButton();
            this.rdLastMNo = new System.Windows.Forms.RadioButton();
            this.dtpLastMenstruation = new System.Windows.Forms.DateTimePicker();
            this.dtpExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.btnCountBMI = new System.Windows.Forms.Button();
            this.tbBMI = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label97 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.tbZtpgEx = new System.Windows.Forms.TextBox();
            this.rdZtpgHave = new System.Windows.Forms.RadioButton();
            this.rdZtpgNo = new System.Windows.Forms.RadioButton();
            this.label45 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.tbBJEX = new System.Windows.Forms.TextBox();
            this.ckBJEX = new System.Windows.Forms.CheckBox();
            this.ckBJBeforXX = new System.Windows.Forms.CheckBox();
            this.ckBJBmblyx = new System.Windows.Forms.CheckBox();
            this.ckBJYingy = new System.Windows.Forms.CheckBox();
            this.ckBJXinl = new System.Windows.Forms.CheckBox();
            this.ckBJPerHealth = new System.Windows.Forms.CheckBox();
            this.label66 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.rdZhuanzhenHave = new System.Windows.Forms.RadioButton();
            this.rdZhuanzhenNo = new System.Windows.Forms.RadioButton();
            this.panel36 = new System.Windows.Forms.Panel();
            this.rdwdw = new System.Windows.Forms.RadioButton();
            this.rddw = new System.Windows.Forms.RadioButton();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.tbZhuanzhenResult = new System.Windows.Forms.TextBox();
            this.tbZhuanzhenKs = new System.Windows.Forms.TextBox();
            this.dtpNext = new System.Windows.Forms.DateTimePicker();
            this.label79 = new System.Windows.Forms.Label();
            this.tbDoctorMark = new System.Windows.Forms.TextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.panel35 = new System.Windows.Forms.Panel();
            this.tbBooks = new System.Windows.Forms.TextBox();
            this.rdBooks2 = new System.Windows.Forms.RadioButton();
            this.rdBooks1 = new System.Windows.Forms.RadioButton();
            this.label95 = new System.Windows.Forms.Label();
            this.txtReferralContacts = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.txtReferralContactsTel = new System.Windows.Forms.TextBox();
            this.panel37 = new System.Windows.Forms.Panel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.label99 = new System.Windows.Forms.Label();
            this.picSignJs = new System.Windows.Forms.PictureBox();
            this.lkJs = new System.Windows.Forms.LinkLabel();
            this.label98 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label93 = new System.Windows.Forms.Label();
            this.panel30 = new System.Windows.Forms.Panel();
            this.rdHIVYang = new System.Windows.Forms.RadioButton();
            this.rdHIVYin = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.rdMeidYang = new System.Windows.Forms.RadioButton();
            this.rdMeidYin = new System.Windows.Forms.RadioButton();
            this.panel26 = new System.Windows.Forms.Panel();
            this.tbCB = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.tbTBIL = new System.Windows.Forms.TextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.tbBP = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.tbGOT = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.tbSGPT = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.tbRh = new System.Windows.Forms.TextBox();
            this.panel23 = new System.Windows.Forms.Panel();
            this.tbNiaoEx = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.btnSelectNiao = new System.Windows.Forms.Button();
            this.tbNiao = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.panel28 = new System.Windows.Forms.Panel();
            this.cbVaginCleaess = new System.Windows.Forms.ComboBox();
            this.label65 = new System.Windows.Forms.Label();
            this.tbVaginEx = new System.Windows.Forms.TextBox();
            this.ckVaginEx = new System.Windows.Forms.CheckBox();
            this.ckJsjmj = new System.Windows.Forms.CheckBox();
            this.ckDichong = new System.Windows.Forms.CheckBox();
            this.ckVaginNormal = new System.Windows.Forms.CheckBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.btnSelectHB = new System.Windows.Forms.Button();
            this.tbBloodEx = new System.Windows.Forms.TextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.tbPLT = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.tbWBC = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.tbHB = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.tbBloodType = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.panel24 = new System.Windows.Forms.Panel();
            this.label47 = new System.Windows.Forms.Label();
            this.tbBUN = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.tbSCR = new System.Windows.Forms.TextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.tbHBCAB = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.tbHBEAB = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.tbHBEAG = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.tbHBSAB = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.tbHBSAG = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.btnFPGL = new System.Windows.Forms.Button();
            this.label91 = new System.Windows.Forms.Label();
            this.tbFPGL = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tbBSuper = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.txtAssistOther = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBaseInfo = new System.Windows.Forms.Button();
            this.btnAssistCheck = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.panel31 = new System.Windows.Forms.Panel();
            this.lbInfo = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel22.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel31.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tableLayoutPanel1);
            this.panel6.Controls.Add(this.lbName);
            this.panel6.Controls.Add(this.tableLayoutPanel3);
            this.panel6.Controls.Add(this.label43);
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(82, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1381, 584);
            this.panel6.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.Controls.Add(this.dtpTypeDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel21, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label80, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel15, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbGrvCount, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbHusbandAge, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbHusbandName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbHusbandPhone, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label26, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label24, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.label25, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label28, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label29, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label33, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label35, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbGrvAge, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel32, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpExpectedDate, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel22, 5, 9);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1307, 581);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtpTypeDate
            // 
            this.dtpTypeDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpTypeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTypeDate.Location = new System.Drawing.Point(184, 4);
            this.dtpTypeDate.Name = "dtpTypeDate";
            this.dtpTypeDate.Size = new System.Drawing.Size(173, 30);
            this.dtpTypeDate.TabIndex = 0;
            // 
            // panel21
            // 
            this.panel21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel21.Controls.Add(this.label81);
            this.panel21.Controls.Add(this.tbWeek);
            this.panel21.Location = new System.Drawing.Point(1051, 0);
            this.panel21.Margin = new System.Windows.Forms.Padding(0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(256, 38);
            this.panel21.TabIndex = 2;
            // 
            // label81
            // 
            this.label81.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label81.Location = new System.Drawing.Point(149, 9);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(29, 20);
            this.label81.TabIndex = 145;
            this.label81.Text = "周";
            // 
            // tbWeek
            // 
            this.tbWeek.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbWeek.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWeek.ForeColor = System.Drawing.Color.Black;
            this.tbWeek.Location = new System.Drawing.Point(3, 5);
            this.tbWeek.MaxLength = 2;
            this.tbWeek.Name = "tbWeek";
            this.tbWeek.Size = new System.Drawing.Size(140, 30);
            this.tbWeek.TabIndex = 111;
            // 
            // label80
            // 
            this.label80.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label80.Location = new System.Drawing.Point(949, 9);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(99, 20);
            this.label80.TabIndex = 167;
            this.label80.Text = "填表孕周:";
            // 
            // panel15
            // 
            this.panel15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel15, 5);
            this.panel15.Controls.Add(this.panel8);
            this.panel15.Controls.Add(this.panel9);
            this.panel15.Controls.Add(this.panel13);
            this.panel15.Controls.Add(this.panel17);
            this.panel15.Controls.Add(this.panel18);
            this.panel15.Location = new System.Drawing.Point(181, 456);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.tableLayoutPanel1.SetRowSpan(this.panel15, 3);
            this.panel15.Size = new System.Drawing.Size(1126, 125);
            this.panel15.TabIndex = 20;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rdFujHave);
            this.panel8.Controls.Add(this.rdFujNo);
            this.panel8.Controls.Add(this.tbFujEx);
            this.panel8.Controls.Add(this.label34);
            this.panel8.Location = new System.Drawing.Point(3, 87);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(557, 38);
            this.panel8.TabIndex = 4;
            // 
            // rdFujHave
            // 
            this.rdFujHave.AutoSize = true;
            this.rdFujHave.Location = new System.Drawing.Point(275, 5);
            this.rdFujHave.Name = "rdFujHave";
            this.rdFujHave.Size = new System.Drawing.Size(67, 24);
            this.rdFujHave.TabIndex = 2;
            this.rdFujHave.TabStop = true;
            this.rdFujHave.Text = "异常";
            this.rdFujHave.UseVisualStyleBackColor = true;
            // 
            // rdFujNo
            // 
            this.rdFujNo.AutoSize = true;
            this.rdFujNo.Location = new System.Drawing.Point(92, 5);
            this.rdFujNo.Name = "rdFujNo";
            this.rdFujNo.Size = new System.Drawing.Size(107, 24);
            this.rdFujNo.TabIndex = 1;
            this.rdFujNo.TabStop = true;
            this.rdFujNo.Text = "未见异常";
            this.rdFujNo.UseVisualStyleBackColor = true;
            // 
            // tbFujEx
            // 
            this.tbFujEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbFujEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFujEx.ForeColor = System.Drawing.Color.Black;
            this.tbFujEx.Location = new System.Drawing.Point(350, 3);
            this.tbFujEx.MaxLength = 20;
            this.tbFujEx.Multiline = true;
            this.tbFujEx.Name = "tbFujEx";
            this.tbFujEx.Size = new System.Drawing.Size(172, 32);
            this.tbFujEx.TabIndex = 3;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(3, 7);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(59, 20);
            this.label34.TabIndex = 0;
            this.label34.Text = "附件:";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.rdZigHave);
            this.panel9.Controls.Add(this.rdZigNo);
            this.panel9.Controls.Add(this.tbZigEx);
            this.panel9.Controls.Add(this.label38);
            this.panel9.Location = new System.Drawing.Point(638, 43);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(482, 40);
            this.panel9.TabIndex = 3;
            // 
            // rdZigHave
            // 
            this.rdZigHave.AutoSize = true;
            this.rdZigHave.Location = new System.Drawing.Point(220, 5);
            this.rdZigHave.Name = "rdZigHave";
            this.rdZigHave.Size = new System.Drawing.Size(67, 24);
            this.rdZigHave.TabIndex = 2;
            this.rdZigHave.TabStop = true;
            this.rdZigHave.Text = "异常";
            this.rdZigHave.UseVisualStyleBackColor = true;
            // 
            // rdZigNo
            // 
            this.rdZigNo.AutoSize = true;
            this.rdZigNo.Location = new System.Drawing.Point(78, 5);
            this.rdZigNo.Name = "rdZigNo";
            this.rdZigNo.Size = new System.Drawing.Size(107, 24);
            this.rdZigNo.TabIndex = 1;
            this.rdZigNo.TabStop = true;
            this.rdZigNo.Text = "未见异常";
            this.rdZigNo.UseVisualStyleBackColor = true;
            // 
            // tbZigEx
            // 
            this.tbZigEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbZigEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZigEx.ForeColor = System.Drawing.Color.Black;
            this.tbZigEx.Location = new System.Drawing.Point(298, 5);
            this.tbZigEx.MaxLength = 20;
            this.tbZigEx.Multiline = true;
            this.tbZigEx.Name = "tbZigEx";
            this.tbZigEx.Size = new System.Drawing.Size(172, 32);
            this.tbZigEx.TabIndex = 3;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(3, 7);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(59, 20);
            this.label38.TabIndex = 0;
            this.label38.Text = "子宫:";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.rdGongjHave);
            this.panel13.Controls.Add(this.rdGongjNo);
            this.panel13.Controls.Add(this.tbGongjingEx);
            this.panel13.Controls.Add(this.label39);
            this.panel13.Location = new System.Drawing.Point(3, 43);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(557, 37);
            this.panel13.TabIndex = 2;
            // 
            // rdGongjHave
            // 
            this.rdGongjHave.AutoSize = true;
            this.rdGongjHave.Location = new System.Drawing.Point(275, 5);
            this.rdGongjHave.Name = "rdGongjHave";
            this.rdGongjHave.Size = new System.Drawing.Size(67, 24);
            this.rdGongjHave.TabIndex = 2;
            this.rdGongjHave.TabStop = true;
            this.rdGongjHave.Text = "异常";
            this.rdGongjHave.UseVisualStyleBackColor = true;
            // 
            // rdGongjNo
            // 
            this.rdGongjNo.AutoSize = true;
            this.rdGongjNo.Location = new System.Drawing.Point(92, 5);
            this.rdGongjNo.Name = "rdGongjNo";
            this.rdGongjNo.Size = new System.Drawing.Size(107, 24);
            this.rdGongjNo.TabIndex = 1;
            this.rdGongjNo.TabStop = true;
            this.rdGongjNo.Text = "未见异常";
            this.rdGongjNo.UseVisualStyleBackColor = true;
            // 
            // tbGongjingEx
            // 
            this.tbGongjingEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbGongjingEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGongjingEx.ForeColor = System.Drawing.Color.Black;
            this.tbGongjingEx.Location = new System.Drawing.Point(350, 5);
            this.tbGongjingEx.MaxLength = 20;
            this.tbGongjingEx.Multiline = true;
            this.tbGongjingEx.Name = "tbGongjingEx";
            this.tbGongjingEx.Size = new System.Drawing.Size(172, 29);
            this.tbGongjingEx.TabIndex = 3;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(3, 7);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(59, 20);
            this.label39.TabIndex = 0;
            this.label39.Text = "宫颈:";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.rdVaginHave);
            this.panel17.Controls.Add(this.rdVaginNo);
            this.panel17.Controls.Add(this.tbYindEx);
            this.panel17.Controls.Add(this.label40);
            this.panel17.Location = new System.Drawing.Point(638, 1);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(482, 36);
            this.panel17.TabIndex = 1;
            // 
            // rdVaginHave
            // 
            this.rdVaginHave.AutoSize = true;
            this.rdVaginHave.Location = new System.Drawing.Point(220, 5);
            this.rdVaginHave.Name = "rdVaginHave";
            this.rdVaginHave.Size = new System.Drawing.Size(67, 24);
            this.rdVaginHave.TabIndex = 2;
            this.rdVaginHave.TabStop = true;
            this.rdVaginHave.Text = "异常";
            this.rdVaginHave.UseVisualStyleBackColor = true;
            // 
            // rdVaginNo
            // 
            this.rdVaginNo.AutoSize = true;
            this.rdVaginNo.Location = new System.Drawing.Point(78, 5);
            this.rdVaginNo.Name = "rdVaginNo";
            this.rdVaginNo.Size = new System.Drawing.Size(107, 24);
            this.rdVaginNo.TabIndex = 1;
            this.rdVaginNo.TabStop = true;
            this.rdVaginNo.Text = "未见异常";
            this.rdVaginNo.UseVisualStyleBackColor = true;
            // 
            // tbYindEx
            // 
            this.tbYindEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbYindEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbYindEx.ForeColor = System.Drawing.Color.Black;
            this.tbYindEx.Location = new System.Drawing.Point(298, 2);
            this.tbYindEx.MaxLength = 20;
            this.tbYindEx.Multiline = true;
            this.tbYindEx.Name = "tbYindEx";
            this.tbYindEx.Size = new System.Drawing.Size(172, 31);
            this.tbYindEx.TabIndex = 3;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(3, 7);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(59, 20);
            this.label40.TabIndex = 0;
            this.label40.Text = "阴道:";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.rdVulvaHave);
            this.panel18.Controls.Add(this.rdVulvaNo);
            this.panel18.Controls.Add(this.tbVulvaEx);
            this.panel18.Controls.Add(this.label41);
            this.panel18.Location = new System.Drawing.Point(3, 1);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(557, 36);
            this.panel18.TabIndex = 0;
            // 
            // rdVulvaHave
            // 
            this.rdVulvaHave.AutoSize = true;
            this.rdVulvaHave.Location = new System.Drawing.Point(275, 5);
            this.rdVulvaHave.Name = "rdVulvaHave";
            this.rdVulvaHave.Size = new System.Drawing.Size(67, 24);
            this.rdVulvaHave.TabIndex = 2;
            this.rdVulvaHave.TabStop = true;
            this.rdVulvaHave.Text = "异常";
            this.rdVulvaHave.UseVisualStyleBackColor = true;
            // 
            // rdVulvaNo
            // 
            this.rdVulvaNo.AutoSize = true;
            this.rdVulvaNo.Location = new System.Drawing.Point(92, 5);
            this.rdVulvaNo.Name = "rdVulvaNo";
            this.rdVulvaNo.Size = new System.Drawing.Size(107, 24);
            this.rdVulvaNo.TabIndex = 1;
            this.rdVulvaNo.TabStop = true;
            this.rdVulvaNo.Text = "未见异常";
            this.rdVulvaNo.UseVisualStyleBackColor = true;
            // 
            // tbVulvaEx
            // 
            this.tbVulvaEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbVulvaEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbVulvaEx.ForeColor = System.Drawing.Color.Black;
            this.tbVulvaEx.Location = new System.Drawing.Point(350, 3);
            this.tbVulvaEx.MaxLength = 20;
            this.tbVulvaEx.Multiline = true;
            this.tbVulvaEx.Name = "tbVulvaEx";
            this.tbVulvaEx.Size = new System.Drawing.Size(172, 30);
            this.tbVulvaEx.TabIndex = 3;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(3, 7);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(59, 20);
            this.label41.TabIndex = 0;
            this.label41.Text = "外阴:";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel7, 2);
            this.panel7.Controls.Add(this.btnSelectHyp);
            this.panel7.Controls.Add(this.label32);
            this.panel7.Controls.Add(this.tbHype);
            this.panel7.Location = new System.Drawing.Point(181, 380);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(435, 38);
            this.panel7.TabIndex = 18;
            // 
            // btnSelectHyp
            // 
            this.btnSelectHyp.Location = new System.Drawing.Point(161, 3);
            this.btnSelectHyp.Name = "btnSelectHyp";
            this.btnSelectHyp.Size = new System.Drawing.Size(44, 35);
            this.btnSelectHyp.TabIndex = 146;
            this.btnSelectHyp.Text = ".....";
            this.btnSelectHyp.UseVisualStyleBackColor = true;
            this.btnSelectHyp.Click += new System.EventHandler(this.btnSelectHyp_Click);
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(214, 12);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(49, 20);
            this.label32.TabIndex = 145;
            this.label32.Text = "mmhg";
            // 
            // tbHype
            // 
            this.tbHype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbHype.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHype.ForeColor = System.Drawing.Color.Black;
            this.tbHype.Location = new System.Drawing.Point(3, 3);
            this.tbHype.Multiline = true;
            this.tbHype.Name = "tbHype";
            this.tbHype.ReadOnly = true;
            this.tbHype.Size = new System.Drawing.Size(141, 33);
            this.tbHype.TabIndex = 111;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btnWeight);
            this.panel5.Controls.Add(this.label31);
            this.panel5.Controls.Add(this.tbWeight);
            this.panel5.Location = new System.Drawing.Point(616, 342);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(254, 38);
            this.panel5.TabIndex = 16;
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(148, 4);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(44, 31);
            this.btnWeight.TabIndex = 147;
            this.btnWeight.Text = ".....";
            this.btnWeight.UseVisualStyleBackColor = true;
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(202, 10);
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
            this.tbWeight.MaxLength = 6;
            this.tbWeight.Multiline = true;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.ReadOnly = true;
            this.tbWeight.Size = new System.Drawing.Size(133, 29);
            this.tbWeight.TabIndex = 111;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label30);
            this.panel4.Controls.Add(this.tbHeight);
            this.panel4.Location = new System.Drawing.Point(181, 342);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(254, 38);
            this.panel4.TabIndex = 15;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(158, 15);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 20);
            this.label30.TabIndex = 145;
            this.label30.Text = "㎝";
            // 
            // tbHeight
            // 
            this.tbHeight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbHeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHeight.ForeColor = System.Drawing.Color.Black;
            this.tbHeight.Location = new System.Drawing.Point(3, 4);
            this.tbHeight.MaxLength = 6;
            this.tbHeight.Multiline = true;
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(140, 31);
            this.tbHeight.TabIndex = 111;
            // 
            // flowLayoutPanel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel3, 5);
            this.flowLayoutPanel3.Controls.Add(this.ckFam4);
            this.flowLayoutPanel3.Controls.Add(this.ckFam1);
            this.flowLayoutPanel3.Controls.Add(this.ckFam2);
            this.flowLayoutPanel3.Controls.Add(this.ckFam3);
            this.flowLayoutPanel3.Controls.Add(this.tbHomeHisOther);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(181, 190);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(970, 38);
            this.flowLayoutPanel3.TabIndex = 11;
            // 
            // ckFam4
            // 
            this.ckFam4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckFam4.AutoSize = true;
            this.ckFam4.Location = new System.Drawing.Point(3, 5);
            this.ckFam4.Name = "ckFam4";
            this.ckFam4.Size = new System.Drawing.Size(48, 24);
            this.ckFam4.TabIndex = 108;
            this.ckFam4.Text = "无";
            this.ckFam4.UseVisualStyleBackColor = true;
            // 
            // ckFam1
            // 
            this.ckFam1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckFam1.AutoSize = true;
            this.ckFam1.Location = new System.Drawing.Point(57, 5);
            this.ckFam1.Name = "ckFam1";
            this.ckFam1.Size = new System.Drawing.Size(148, 24);
            this.ckFam1.TabIndex = 5;
            this.ckFam1.Text = "遗传性疾病史";
            this.ckFam1.UseVisualStyleBackColor = true;
            // 
            // ckFam2
            // 
            this.ckFam2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckFam2.AutoSize = true;
            this.ckFam2.Location = new System.Drawing.Point(211, 5);
            this.ckFam2.Name = "ckFam2";
            this.ckFam2.Size = new System.Drawing.Size(148, 24);
            this.ckFam2.TabIndex = 6;
            this.ckFam2.Text = "精神病疾病史";
            this.ckFam2.UseVisualStyleBackColor = true;
            // 
            // ckFam3
            // 
            this.ckFam3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckFam3.AutoSize = true;
            this.ckFam3.Location = new System.Drawing.Point(365, 5);
            this.ckFam3.Name = "ckFam3";
            this.ckFam3.Size = new System.Drawing.Size(68, 24);
            this.ckFam3.TabIndex = 7;
            this.ckFam3.Text = "其他";
            this.ckFam3.UseVisualStyleBackColor = true;
            // 
            // tbHomeHisOther
            // 
            this.tbHomeHisOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHomeHisOther.ForeColor = System.Drawing.Color.Black;
            this.tbHomeHisOther.Location = new System.Drawing.Point(439, 3);
            this.tbHomeHisOther.MaxLength = 20;
            this.tbHomeHisOther.Multiline = true;
            this.tbHomeHisOther.Name = "tbHomeHisOther";
            this.tbHomeHisOther.ReadOnly = true;
            this.tbHomeHisOther.Size = new System.Drawing.Size(319, 26);
            this.tbHomeHisOther.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(79, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 160;
            this.label2.Text = "既 往 史:";
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 5);
            this.flowLayoutPanel2.Controls.Add(this.ckJwsNo);
            this.flowLayoutPanel2.Controls.Add(this.ckJws2);
            this.flowLayoutPanel2.Controls.Add(this.ckJws3);
            this.flowLayoutPanel2.Controls.Add(this.ckJws4);
            this.flowLayoutPanel2.Controls.Add(this.ckJws5);
            this.flowLayoutPanel2.Controls.Add(this.ckJws6);
            this.flowLayoutPanel2.Controls.Add(this.ckJws7);
            this.flowLayoutPanel2.Controls.Add(this.ckJws8);
            this.flowLayoutPanel2.Controls.Add(this.tbHisOther);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(181, 152);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1123, 38);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // ckJwsNo
            // 
            this.ckJwsNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckJwsNo.AutoSize = true;
            this.ckJwsNo.Location = new System.Drawing.Point(3, 5);
            this.ckJwsNo.Name = "ckJwsNo";
            this.ckJwsNo.Size = new System.Drawing.Size(48, 24);
            this.ckJwsNo.TabIndex = 0;
            this.ckJwsNo.Text = "无";
            this.ckJwsNo.UseVisualStyleBackColor = true;
            // 
            // ckJws2
            // 
            this.ckJws2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckJws2.AutoSize = true;
            this.ckJws2.Location = new System.Drawing.Point(57, 5);
            this.ckJws2.Name = "ckJws2";
            this.ckJws2.Size = new System.Drawing.Size(98, 24);
            this.ckJws2.TabIndex = 1;
            this.ckJws2.Text = "2心脏病";
            this.ckJws2.UseVisualStyleBackColor = true;
            // 
            // ckJws3
            // 
            this.ckJws3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckJws3.AutoSize = true;
            this.ckJws3.Location = new System.Drawing.Point(161, 5);
            this.ckJws3.Name = "ckJws3";
            this.ckJws3.Size = new System.Drawing.Size(118, 24);
            this.ckJws3.TabIndex = 2;
            this.ckJws3.Text = "3肾脏疾病";
            this.ckJws3.UseVisualStyleBackColor = true;
            // 
            // ckJws4
            // 
            this.ckJws4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckJws4.AutoSize = true;
            this.ckJws4.Location = new System.Drawing.Point(285, 5);
            this.ckJws4.Name = "ckJws4";
            this.ckJws4.Size = new System.Drawing.Size(118, 24);
            this.ckJws4.TabIndex = 3;
            this.ckJws4.Text = "4肝脏疾病";
            this.ckJws4.UseVisualStyleBackColor = true;
            // 
            // ckJws5
            // 
            this.ckJws5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckJws5.AutoSize = true;
            this.ckJws5.Location = new System.Drawing.Point(409, 5);
            this.ckJws5.Name = "ckJws5";
            this.ckJws5.Size = new System.Drawing.Size(98, 24);
            this.ckJws5.TabIndex = 4;
            this.ckJws5.Text = "5高血压";
            this.ckJws5.UseVisualStyleBackColor = true;
            // 
            // ckJws6
            // 
            this.ckJws6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckJws6.AutoSize = true;
            this.ckJws6.Location = new System.Drawing.Point(513, 5);
            this.ckJws6.Name = "ckJws6";
            this.ckJws6.Size = new System.Drawing.Size(78, 24);
            this.ckJws6.TabIndex = 5;
            this.ckJws6.Text = "6贫血";
            this.ckJws6.UseVisualStyleBackColor = true;
            // 
            // ckJws7
            // 
            this.ckJws7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckJws7.AutoSize = true;
            this.ckJws7.Location = new System.Drawing.Point(597, 5);
            this.ckJws7.Name = "ckJws7";
            this.ckJws7.Size = new System.Drawing.Size(98, 24);
            this.ckJws7.TabIndex = 6;
            this.ckJws7.Text = "7糖尿病";
            this.ckJws7.UseVisualStyleBackColor = true;
            // 
            // ckJws8
            // 
            this.ckJws8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckJws8.AutoSize = true;
            this.ckJws8.Location = new System.Drawing.Point(701, 5);
            this.ckJws8.Name = "ckJws8";
            this.ckJws8.Size = new System.Drawing.Size(78, 24);
            this.ckJws8.TabIndex = 7;
            this.ckJws8.Text = "8其他";
            this.ckJws8.UseVisualStyleBackColor = true;
            // 
            // tbHisOther
            // 
            this.tbHisOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHisOther.ForeColor = System.Drawing.Color.Black;
            this.tbHisOther.Location = new System.Drawing.Point(785, 3);
            this.tbHisOther.MaxLength = 20;
            this.tbHisOther.Multiline = true;
            this.tbHisOther.Name = "tbHisOther";
            this.tbHisOther.ReadOnly = true;
            this.tbHisOther.Size = new System.Drawing.Size(174, 26);
            this.tbHisOther.TabIndex = 107;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.tbBornPGC);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.tbBornYD);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(616, 76);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 38);
            this.panel1.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(382, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 20);
            this.label20.TabIndex = 1;
            this.label20.Text = "次";
            // 
            // tbBornPGC
            // 
            this.tbBornPGC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbBornPGC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBornPGC.ForeColor = System.Drawing.Color.Black;
            this.tbBornPGC.Location = new System.Drawing.Point(337, 6);
            this.tbBornPGC.MaxLength = 2;
            this.tbBornPGC.Name = "tbBornPGC";
            this.tbBornPGC.Size = new System.Drawing.Size(39, 30);
            this.tbBornPGC.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(249, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 20);
            this.label21.TabIndex = 151;
            this.label21.Text = "剖宫产:";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(157, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 20);
            this.label18.TabIndex = 149;
            this.label18.Text = "次";
            // 
            // tbBornYD
            // 
            this.tbBornYD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbBornYD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBornYD.ForeColor = System.Drawing.Color.Black;
            this.tbBornYD.Location = new System.Drawing.Point(112, 5);
            this.tbBornYD.MaxLength = 2;
            this.tbBornYD.Name = "tbBornYD";
            this.tbBornYD.Size = new System.Drawing.Size(39, 30);
            this.tbBornYD.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(7, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 148;
            this.label12.Text = "阴道分娩:";
            // 
            // tbGrvCount
            // 
            this.tbGrvCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbGrvCount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGrvCount.ForeColor = System.Drawing.Color.Black;
            this.tbGrvCount.Location = new System.Drawing.Point(184, 80);
            this.tbGrvCount.MaxLength = 2;
            this.tbGrvCount.Name = "tbGrvCount";
            this.tbGrvCount.Size = new System.Drawing.Size(173, 30);
            this.tbGrvCount.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(514, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 135;
            this.label10.Text = "产    次:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(79, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 112;
            this.label4.Text = "丈夫姓名:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(514, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 111;
            this.label16.Text = "丈夫年龄:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(949, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 133;
            this.label5.Text = "丈夫电话:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(79, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 134;
            this.label6.Text = "孕    次:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(76, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 26);
            this.label7.TabIndex = 129;
            this.label7.Text = "末次月经:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbHusbandAge
            // 
            this.tbHusbandAge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandAge.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandAge.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandAge.Location = new System.Drawing.Point(619, 42);
            this.tbHusbandAge.MaxLength = 2;
            this.tbHusbandAge.Name = "tbHusbandAge";
            this.tbHusbandAge.Size = new System.Drawing.Size(173, 30);
            this.tbHusbandAge.TabIndex = 4;
            // 
            // tbHusbandName
            // 
            this.tbHusbandName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandName.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandName.Location = new System.Drawing.Point(184, 42);
            this.tbHusbandName.MaxLength = 15;
            this.tbHusbandName.Name = "tbHusbandName";
            this.tbHusbandName.Size = new System.Drawing.Size(173, 30);
            this.tbHusbandName.TabIndex = 3;
            // 
            // tbHusbandPhone
            // 
            this.tbHusbandPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandPhone.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandPhone.Location = new System.Drawing.Point(1054, 42);
            this.tbHusbandPhone.MaxLength = 15;
            this.tbHusbandPhone.Name = "tbHusbandPhone";
            this.tbHusbandPhone.Size = new System.Drawing.Size(173, 30);
            this.tbHusbandPhone.TabIndex = 5;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(79, 389);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(99, 20);
            this.label26.TabIndex = 157;
            this.label26.Text = "血    压:";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(79, 351);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(99, 20);
            this.label24.TabIndex = 135;
            this.label24.Text = "身    高:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(514, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 153;
            this.label9.Text = "体    重:";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(949, 351);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(99, 20);
            this.label25.TabIndex = 155;
            this.label25.Text = "体质指数:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(99, 313);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 147;
            this.label11.Text = "孕产史:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 5);
            this.panel3.Controls.Add(this.tbDropBaby2);
            this.panel3.Controls.Add(this.label92);
            this.panel3.Controls.Add(this.tbNewbornDefect);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.tbDeadNewBorn);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.tbDeadBorn);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.tbDeadFetus);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.tbDropBaby);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(181, 304);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1126, 38);
            this.panel3.TabIndex = 14;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // tbDropBaby2
            // 
            this.tbDropBaby2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDropBaby2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDropBaby2.ForeColor = System.Drawing.Color.Black;
            this.tbDropBaby2.Location = new System.Drawing.Point(292, 2);
            this.tbDropBaby2.MaxLength = 2;
            this.tbDropBaby2.Name = "tbDropBaby2";
            this.tbDropBaby2.Size = new System.Drawing.Size(39, 30);
            this.tbDropBaby2.TabIndex = 153;
            // 
            // label92
            // 
            this.label92.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label92.Location = new System.Drawing.Point(177, 10);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(109, 20);
            this.label92.TabIndex = 152;
            this.label92.Text = "2人工流产:";
            // 
            // tbNewbornDefect
            // 
            this.tbNewbornDefect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbNewbornDefect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNewbornDefect.ForeColor = System.Drawing.Color.Black;
            this.tbNewbornDefect.Location = new System.Drawing.Point(995, 2);
            this.tbNewbornDefect.MaxLength = 2;
            this.tbNewbornDefect.Name = "tbNewbornDefect";
            this.tbNewbornDefect.Size = new System.Drawing.Size(39, 30);
            this.tbNewbornDefect.TabIndex = 151;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(867, 10);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(119, 20);
            this.label23.TabIndex = 150;
            this.label23.Text = "6出生缺陷儿";
            // 
            // tbDeadNewBorn
            // 
            this.tbDeadNewBorn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDeadNewBorn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDeadNewBorn.ForeColor = System.Drawing.Color.Black;
            this.tbDeadNewBorn.Location = new System.Drawing.Point(795, 2);
            this.tbDeadNewBorn.MaxLength = 2;
            this.tbDeadNewBorn.Name = "tbDeadNewBorn";
            this.tbDeadNewBorn.Size = new System.Drawing.Size(39, 30);
            this.tbDeadNewBorn.TabIndex = 149;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(662, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(129, 20);
            this.label22.TabIndex = 148;
            this.label22.Text = "5新生儿死亡:";
            // 
            // tbDeadBorn
            // 
            this.tbDeadBorn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDeadBorn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDeadBorn.ForeColor = System.Drawing.Color.Black;
            this.tbDeadBorn.Location = new System.Drawing.Point(586, 2);
            this.tbDeadBorn.MaxLength = 2;
            this.tbDeadBorn.Name = "tbDeadBorn";
            this.tbDeadBorn.Size = new System.Drawing.Size(39, 30);
            this.tbDeadBorn.TabIndex = 147;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(508, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 20);
            this.label19.TabIndex = 146;
            this.label19.Text = "4死产:";
            // 
            // tbDeadFetus
            // 
            this.tbDeadFetus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDeadFetus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDeadFetus.ForeColor = System.Drawing.Color.Black;
            this.tbDeadFetus.Location = new System.Drawing.Point(436, 2);
            this.tbDeadFetus.MaxLength = 2;
            this.tbDeadFetus.Name = "tbDeadFetus";
            this.tbDeadFetus.Size = new System.Drawing.Size(39, 30);
            this.tbDeadFetus.TabIndex = 145;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(353, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 20);
            this.label17.TabIndex = 144;
            this.label17.Text = "3死胎:";
            // 
            // tbDropBaby
            // 
            this.tbDropBaby.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDropBaby.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDropBaby.ForeColor = System.Drawing.Color.Black;
            this.tbDropBaby.Location = new System.Drawing.Point(120, 2);
            this.tbDropBaby.MaxLength = 2;
            this.tbDropBaby.Name = "tbDropBaby";
            this.tbDropBaby.Size = new System.Drawing.Size(39, 30);
            this.tbDropBaby.TabIndex = 143;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(4, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 20);
            this.label14.TabIndex = 129;
            this.label14.Text = "1自然流产:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(59, 275);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 20);
            this.label15.TabIndex = 146;
            this.label15.Text = "妇科手术史:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this.tbWomenOperation);
            this.panel2.Controls.Add(this.rdFukOpHave);
            this.panel2.Controls.Add(this.rdFukOpNo);
            this.panel2.Location = new System.Drawing.Point(181, 266);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(689, 38);
            this.panel2.TabIndex = 13;
            // 
            // tbWomenOperation
            // 
            this.tbWomenOperation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWomenOperation.ForeColor = System.Drawing.Color.Black;
            this.tbWomenOperation.Location = new System.Drawing.Point(131, 4);
            this.tbWomenOperation.MaxLength = 20;
            this.tbWomenOperation.Multiline = true;
            this.tbWomenOperation.Name = "tbWomenOperation";
            this.tbWomenOperation.Size = new System.Drawing.Size(354, 31);
            this.tbWomenOperation.TabIndex = 111;
            // 
            // rdFukOpHave
            // 
            this.rdFukOpHave.AutoSize = true;
            this.rdFukOpHave.Location = new System.Drawing.Point(65, 6);
            this.rdFukOpHave.Name = "rdFukOpHave";
            this.rdFukOpHave.Size = new System.Drawing.Size(47, 24);
            this.rdFukOpHave.TabIndex = 110;
            this.rdFukOpHave.TabStop = true;
            this.rdFukOpHave.Text = "有";
            this.rdFukOpHave.UseVisualStyleBackColor = true;
            // 
            // rdFukOpNo
            // 
            this.rdFukOpNo.AutoSize = true;
            this.rdFukOpNo.Location = new System.Drawing.Point(3, 6);
            this.rdFukOpNo.Name = "rdFukOpNo";
            this.rdFukOpNo.Size = new System.Drawing.Size(47, 24);
            this.rdFukOpNo.TabIndex = 109;
            this.rdFukOpNo.TabStop = true;
            this.rdFukOpNo.Text = "无";
            this.rdFukOpNo.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(79, 199);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(99, 20);
            this.label28.TabIndex = 161;
            this.label28.Text = "家 族 史:";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(79, 237);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(99, 20);
            this.label29.TabIndex = 162;
            this.label29.Text = "个 人 史:";
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 5);
            this.flowLayoutPanel1.Controls.Add(this.ckPerHis1);
            this.flowLayoutPanel1.Controls.Add(this.ckPerHis2);
            this.flowLayoutPanel1.Controls.Add(this.ckPerHis3);
            this.flowLayoutPanel1.Controls.Add(this.ckPerHis4);
            this.flowLayoutPanel1.Controls.Add(this.ckPerHis5);
            this.flowLayoutPanel1.Controls.Add(this.ckPerHis6);
            this.flowLayoutPanel1.Controls.Add(this.tbPersonOther);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(181, 228);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(978, 38);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // ckPerHis1
            // 
            this.ckPerHis1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckPerHis1.AutoSize = true;
            this.ckPerHis1.Location = new System.Drawing.Point(3, 11);
            this.ckPerHis1.Name = "ckPerHis1";
            this.ckPerHis1.Size = new System.Drawing.Size(68, 24);
            this.ckPerHis1.TabIndex = 0;
            this.ckPerHis1.Text = "吸烟";
            this.ckPerHis1.UseVisualStyleBackColor = true;
            // 
            // ckPerHis2
            // 
            this.ckPerHis2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckPerHis2.AutoSize = true;
            this.ckPerHis2.Location = new System.Drawing.Point(77, 11);
            this.ckPerHis2.Name = "ckPerHis2";
            this.ckPerHis2.Size = new System.Drawing.Size(68, 24);
            this.ckPerHis2.TabIndex = 1;
            this.ckPerHis2.Text = "饮酒";
            this.ckPerHis2.UseVisualStyleBackColor = true;
            // 
            // ckPerHis3
            // 
            this.ckPerHis3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckPerHis3.AutoSize = true;
            this.ckPerHis3.Location = new System.Drawing.Point(151, 11);
            this.ckPerHis3.Name = "ckPerHis3";
            this.ckPerHis3.Size = new System.Drawing.Size(108, 24);
            this.ckPerHis3.TabIndex = 2;
            this.ckPerHis3.Text = "服用药物";
            this.ckPerHis3.UseVisualStyleBackColor = true;
            // 
            // ckPerHis4
            // 
            this.ckPerHis4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckPerHis4.AutoSize = true;
            this.ckPerHis4.Location = new System.Drawing.Point(265, 11);
            this.ckPerHis4.Name = "ckPerHis4";
            this.ckPerHis4.Size = new System.Drawing.Size(188, 24);
            this.ckPerHis4.TabIndex = 3;
            this.ckPerHis4.Text = "接触有毒有害物质";
            this.ckPerHis4.UseVisualStyleBackColor = true;
            // 
            // ckPerHis5
            // 
            this.ckPerHis5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckPerHis5.AutoSize = true;
            this.ckPerHis5.Location = new System.Drawing.Point(459, 11);
            this.ckPerHis5.Name = "ckPerHis5";
            this.ckPerHis5.Size = new System.Drawing.Size(128, 24);
            this.ckPerHis5.TabIndex = 4;
            this.ckPerHis5.Text = "接触放射线";
            this.ckPerHis5.UseVisualStyleBackColor = true;
            // 
            // ckPerHis6
            // 
            this.ckPerHis6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ckPerHis6.AutoSize = true;
            this.ckPerHis6.Location = new System.Drawing.Point(593, 11);
            this.ckPerHis6.Name = "ckPerHis6";
            this.ckPerHis6.Size = new System.Drawing.Size(68, 24);
            this.ckPerHis6.TabIndex = 5;
            this.ckPerHis6.Text = "其他";
            this.ckPerHis6.UseVisualStyleBackColor = true;
            // 
            // tbPersonOther
            // 
            this.tbPersonOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbPersonOther.ForeColor = System.Drawing.Color.Black;
            this.tbPersonOther.Location = new System.Drawing.Point(667, 3);
            this.tbPersonOther.MaxLength = 20;
            this.tbPersonOther.Multiline = true;
            this.tbPersonOther.Name = "tbPersonOther";
            this.tbPersonOther.ReadOnly = true;
            this.tbPersonOther.Size = new System.Drawing.Size(174, 32);
            this.tbPersonOther.TabIndex = 107;
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(79, 427);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 20);
            this.label33.TabIndex = 164;
            this.label33.Text = "听    诊:";
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label35.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(56, 477);
            this.label35.Name = "label35";
            this.tableLayoutPanel1.SetRowSpan(this.label35, 3);
            this.label35.Size = new System.Drawing.Size(122, 82);
            this.label35.TabIndex = 165;
            this.label35.Text = "妇科检查:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel14
            // 
            this.panel14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel14, 5);
            this.panel14.Controls.Add(this.panel11);
            this.panel14.Controls.Add(this.panel12);
            this.panel14.Location = new System.Drawing.Point(181, 418);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1126, 38);
            this.panel14.TabIndex = 19;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.rdLungHave);
            this.panel11.Controls.Add(this.rdLungNo);
            this.panel11.Controls.Add(this.tbLungEx);
            this.panel11.Controls.Add(this.label36);
            this.panel11.Location = new System.Drawing.Point(638, 1);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(482, 34);
            this.panel11.TabIndex = 1;
            // 
            // rdLungHave
            // 
            this.rdLungHave.AutoSize = true;
            this.rdLungHave.Location = new System.Drawing.Point(220, 5);
            this.rdLungHave.Name = "rdLungHave";
            this.rdLungHave.Size = new System.Drawing.Size(67, 24);
            this.rdLungHave.TabIndex = 2;
            this.rdLungHave.TabStop = true;
            this.rdLungHave.Text = "异常";
            this.rdLungHave.UseVisualStyleBackColor = true;
            // 
            // rdLungNo
            // 
            this.rdLungNo.AutoSize = true;
            this.rdLungNo.Location = new System.Drawing.Point(78, 5);
            this.rdLungNo.Name = "rdLungNo";
            this.rdLungNo.Size = new System.Drawing.Size(107, 24);
            this.rdLungNo.TabIndex = 1;
            this.rdLungNo.TabStop = true;
            this.rdLungNo.Text = "未见异常";
            this.rdLungNo.UseVisualStyleBackColor = true;
            // 
            // tbLungEx
            // 
            this.tbLungEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbLungEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbLungEx.ForeColor = System.Drawing.Color.Black;
            this.tbLungEx.Location = new System.Drawing.Point(298, 2);
            this.tbLungEx.MaxLength = 20;
            this.tbLungEx.Multiline = true;
            this.tbLungEx.Name = "tbLungEx";
            this.tbLungEx.Size = new System.Drawing.Size(172, 29);
            this.tbLungEx.TabIndex = 3;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(3, 7);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(59, 20);
            this.label36.TabIndex = 0;
            this.label36.Text = "肺部:";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.rdHeartHave);
            this.panel12.Controls.Add(this.rdHeartNo);
            this.panel12.Controls.Add(this.tbHeartEX);
            this.panel12.Controls.Add(this.label37);
            this.panel12.Location = new System.Drawing.Point(3, 1);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(557, 34);
            this.panel12.TabIndex = 0;
            // 
            // rdHeartHave
            // 
            this.rdHeartHave.AutoSize = true;
            this.rdHeartHave.Location = new System.Drawing.Point(275, 5);
            this.rdHeartHave.Name = "rdHeartHave";
            this.rdHeartHave.Size = new System.Drawing.Size(67, 24);
            this.rdHeartHave.TabIndex = 1;
            this.rdHeartHave.TabStop = true;
            this.rdHeartHave.Text = "异常";
            this.rdHeartHave.UseVisualStyleBackColor = true;
            // 
            // rdHeartNo
            // 
            this.rdHeartNo.AutoSize = true;
            this.rdHeartNo.Location = new System.Drawing.Point(92, 5);
            this.rdHeartNo.Name = "rdHeartNo";
            this.rdHeartNo.Size = new System.Drawing.Size(107, 24);
            this.rdHeartNo.TabIndex = 0;
            this.rdHeartNo.TabStop = true;
            this.rdHeartNo.Text = "未见异常";
            this.rdHeartNo.UseVisualStyleBackColor = true;
            // 
            // tbHeartEX
            // 
            this.tbHeartEX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbHeartEX.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHeartEX.ForeColor = System.Drawing.Color.Black;
            this.tbHeartEX.Location = new System.Drawing.Point(350, 3);
            this.tbHeartEX.MaxLength = 20;
            this.tbHeartEX.Multiline = true;
            this.tbHeartEX.Name = "tbHeartEX";
            this.tbHeartEX.Size = new System.Drawing.Size(172, 29);
            this.tbHeartEX.TabIndex = 2;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(3, 7);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(59, 20);
            this.label37.TabIndex = 0;
            this.label37.Text = "心脏:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(79, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 100;
            this.label13.Text = "填表日期:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(514, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 101;
            this.label3.Text = "孕妇年龄:";
            // 
            // tbGrvAge
            // 
            this.tbGrvAge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbGrvAge.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGrvAge.ForeColor = System.Drawing.Color.Black;
            this.tbGrvAge.Location = new System.Drawing.Point(619, 4);
            this.tbGrvAge.MaxLength = 2;
            this.tbGrvAge.Name = "tbGrvAge";
            this.tbGrvAge.ReadOnly = true;
            this.tbGrvAge.Size = new System.Drawing.Size(173, 30);
            this.tbGrvAge.TabIndex = 1;
            // 
            // panel32
            // 
            this.panel32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel32, 2);
            this.panel32.Controls.Add(this.rdLastMHave);
            this.panel32.Controls.Add(this.rdLastMNo);
            this.panel32.Controls.Add(this.dtpLastMenstruation);
            this.panel32.Location = new System.Drawing.Point(181, 114);
            this.panel32.Margin = new System.Windows.Forms.Padding(0);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(435, 38);
            this.panel32.TabIndex = 8;
            // 
            // rdLastMHave
            // 
            this.rdLastMHave.AutoSize = true;
            this.rdLastMHave.Location = new System.Drawing.Point(79, 6);
            this.rdLastMHave.Name = "rdLastMHave";
            this.rdLastMHave.Size = new System.Drawing.Size(67, 24);
            this.rdLastMHave.TabIndex = 1;
            this.rdLastMHave.TabStop = true;
            this.rdLastMHave.Text = "时间";
            this.rdLastMHave.UseVisualStyleBackColor = true;
            this.rdLastMHave.CheckedChanged += new System.EventHandler(this.rdLastMHave_CheckedChanged);
            // 
            // rdLastMNo
            // 
            this.rdLastMNo.AutoSize = true;
            this.rdLastMNo.Location = new System.Drawing.Point(3, 6);
            this.rdLastMNo.Name = "rdLastMNo";
            this.rdLastMNo.Size = new System.Drawing.Size(67, 24);
            this.rdLastMNo.TabIndex = 0;
            this.rdLastMNo.TabStop = true;
            this.rdLastMNo.Text = "不详";
            this.rdLastMNo.UseVisualStyleBackColor = true;
            this.rdLastMNo.CheckedChanged += new System.EventHandler(this.rdLastMNo_CheckedChanged);
            // 
            // dtpLastMenstruation
            // 
            this.dtpLastMenstruation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpLastMenstruation.Enabled = false;
            this.dtpLastMenstruation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLastMenstruation.Location = new System.Drawing.Point(174, 4);
            this.dtpLastMenstruation.Name = "dtpLastMenstruation";
            this.dtpLastMenstruation.Size = new System.Drawing.Size(152, 30);
            this.dtpLastMenstruation.TabIndex = 2;
            // 
            // dtpExpectedDate
            // 
            this.dtpExpectedDate.Location = new System.Drawing.Point(1054, 117);
            this.dtpExpectedDate.Name = "dtpExpectedDate";
            this.dtpExpectedDate.Size = new System.Drawing.Size(192, 30);
            this.dtpExpectedDate.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(949, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 128;
            this.label1.Text = "预 产 期:";
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.btnCountBMI);
            this.panel22.Controls.Add(this.tbBMI);
            this.panel22.Location = new System.Drawing.Point(1051, 342);
            this.panel22.Margin = new System.Windows.Forms.Padding(0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(232, 38);
            this.panel22.TabIndex = 17;
            // 
            // btnCountBMI
            // 
            this.btnCountBMI.Location = new System.Drawing.Point(106, 4);
            this.btnCountBMI.Name = "btnCountBMI";
            this.btnCountBMI.Size = new System.Drawing.Size(60, 31);
            this.btnCountBMI.TabIndex = 157;
            this.btnCountBMI.Text = "计算";
            this.btnCountBMI.UseVisualStyleBackColor = true;
            this.btnCountBMI.Click += new System.EventHandler(this.btnCountBMI_Click);
            // 
            // tbBMI
            // 
            this.tbBMI.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBMI.ForeColor = System.Drawing.Color.Black;
            this.tbBMI.Location = new System.Drawing.Point(5, 3);
            this.tbBMI.MaxLength = 6;
            this.tbBMI.Multiline = true;
            this.tbBMI.Name = "tbBMI";
            this.tbBMI.Size = new System.Drawing.Size(95, 32);
            this.tbBMI.TabIndex = 156;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(122, 1);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 20);
            this.lbName.TabIndex = 167;
            this.lbName.Text = "aaa";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88722F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44611F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88722F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44611F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88722F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44611F));
            this.tableLayoutPanel3.Controls.Add(this.label97, 4, 5);
            this.tableLayoutPanel3.Controls.Add(this.label78, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label44, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel16, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label45, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel19, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label66, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.panel20, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.panel36, 5, 5);
            this.tableLayoutPanel3.Controls.Add(this.label67, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.label68, 4, 4);
            this.tableLayoutPanel3.Controls.Add(this.tbZhuanzhenResult, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.tbZhuanzhenKs, 5, 4);
            this.tableLayoutPanel3.Controls.Add(this.dtpNext, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.label79, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.tbDoctorMark, 3, 6);
            this.tableLayoutPanel3.Controls.Add(this.label94, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel35, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label95, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtReferralContacts, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label96, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtReferralContactsTel, 3, 5);
            this.tableLayoutPanel3.Controls.Add(this.panel37, 0, 7);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 1247);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.1678F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.1678F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.1678F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.1678F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.1678F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.17206F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.1678F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.82112F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1308, 372);
            this.tableLayoutPanel3.TabIndex = 166;
            // 
            // label97
            // 
            this.label97.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(989, 237);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(59, 20);
            this.label97.TabIndex = 191;
            this.label97.Text = "结果:";
            // 
            // label78
            // 
            this.label78.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label78.Location = new System.Drawing.Point(39, 282);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(139, 20);
            this.label78.TabIndex = 184;
            this.label78.Text = "下次随访日期:";
            // 
            // label44
            // 
            this.label44.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.Location = new System.Drawing.Point(79, 12);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(99, 20);
            this.label44.TabIndex = 174;
            this.label44.Text = "总体评估:";
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.panel16, 5);
            this.panel16.Controls.Add(this.tbZtpgEx);
            this.panel16.Controls.Add(this.rdZtpgHave);
            this.panel16.Controls.Add(this.rdZtpgNo);
            this.panel16.Location = new System.Drawing.Point(181, 0);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(1127, 45);
            this.panel16.TabIndex = 0;
            // 
            // tbZtpgEx
            // 
            this.tbZtpgEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZtpgEx.ForeColor = System.Drawing.Color.Black;
            this.tbZtpgEx.Location = new System.Drawing.Point(235, 7);
            this.tbZtpgEx.MaxLength = 100;
            this.tbZtpgEx.Multiline = true;
            this.tbZtpgEx.Name = "tbZtpgEx";
            this.tbZtpgEx.ReadOnly = true;
            this.tbZtpgEx.Size = new System.Drawing.Size(561, 30);
            this.tbZtpgEx.TabIndex = 169;
            // 
            // rdZtpgHave
            // 
            this.rdZtpgHave.AutoSize = true;
            this.rdZtpgHave.Location = new System.Drawing.Point(141, 10);
            this.rdZtpgHave.Name = "rdZtpgHave";
            this.rdZtpgHave.Size = new System.Drawing.Size(67, 24);
            this.rdZtpgHave.TabIndex = 150;
            this.rdZtpgHave.TabStop = true;
            this.rdZtpgHave.Text = "异常";
            this.rdZtpgHave.UseVisualStyleBackColor = true;
            // 
            // rdZtpgNo
            // 
            this.rdZtpgNo.AutoSize = true;
            this.rdZtpgNo.Location = new System.Drawing.Point(4, 10);
            this.rdZtpgNo.Name = "rdZtpgNo";
            this.rdZtpgNo.Size = new System.Drawing.Size(107, 24);
            this.rdZtpgNo.TabIndex = 149;
            this.rdZtpgNo.TabStop = true;
            this.rdZtpgNo.Text = "未见异常";
            this.rdZtpgNo.UseVisualStyleBackColor = true;
            // 
            // label45
            // 
            this.label45.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label45.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.Location = new System.Drawing.Point(56, 128);
            this.label45.Name = "label45";
            this.tableLayoutPanel3.SetRowSpan(this.label45, 2);
            this.label45.Size = new System.Drawing.Size(122, 14);
            this.label45.TabIndex = 176;
            this.label45.Text = "保健指导:";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel19
            // 
            this.panel19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.panel19, 5);
            this.panel19.Controls.Add(this.tbBJEX);
            this.panel19.Controls.Add(this.ckBJEX);
            this.panel19.Controls.Add(this.ckBJBeforXX);
            this.panel19.Controls.Add(this.ckBJBmblyx);
            this.panel19.Controls.Add(this.ckBJYingy);
            this.panel19.Controls.Add(this.ckBJXinl);
            this.panel19.Controls.Add(this.ckBJPerHealth);
            this.panel19.Location = new System.Drawing.Point(181, 90);
            this.panel19.Margin = new System.Windows.Forms.Padding(0);
            this.panel19.Name = "panel19";
            this.tableLayoutPanel3.SetRowSpan(this.panel19, 2);
            this.panel19.Size = new System.Drawing.Size(1127, 90);
            this.panel19.TabIndex = 1;
            // 
            // tbBJEX
            // 
            this.tbBJEX.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBJEX.ForeColor = System.Drawing.Color.Black;
            this.tbBJEX.Location = new System.Drawing.Point(293, 42);
            this.tbBJEX.MaxLength = 20;
            this.tbBJEX.Multiline = true;
            this.tbBJEX.Name = "tbBJEX";
            this.tbBJEX.ReadOnly = true;
            this.tbBJEX.Size = new System.Drawing.Size(324, 29);
            this.tbBJEX.TabIndex = 170;
            // 
            // ckBJEX
            // 
            this.ckBJEX.AutoSize = true;
            this.ckBJEX.Location = new System.Drawing.Point(218, 47);
            this.ckBJEX.Name = "ckBJEX";
            this.ckBJEX.Size = new System.Drawing.Size(68, 24);
            this.ckBJEX.TabIndex = 9;
            this.ckBJEX.Text = "其他";
            this.ckBJEX.UseVisualStyleBackColor = true;
            // 
            // ckBJBeforXX
            // 
            this.ckBJBeforXX.AutoSize = true;
            this.ckBJBeforXX.Location = new System.Drawing.Point(6, 47);
            this.ckBJBeforXX.Name = "ckBJBeforXX";
            this.ckBJBeforXX.Size = new System.Drawing.Size(188, 24);
            this.ckBJBeforXX.TabIndex = 8;
            this.ckBJBeforXX.Text = "产前筛查宣传告知";
            this.ckBJBeforXX.UseVisualStyleBackColor = true;
            // 
            // ckBJBmblyx
            // 
            this.ckBJBmblyx.AutoSize = true;
            this.ckBJBmblyx.Location = new System.Drawing.Point(470, 8);
            this.ckBJBmblyx.Name = "ckBJBmblyx";
            this.ckBJBmblyx.Size = new System.Drawing.Size(368, 24);
            this.ckBJBmblyx.TabIndex = 7;
            this.ckBJBmblyx.Text = "避免畸形因素和疾病对胚胎的不良影响";
            this.ckBJBmblyx.UseVisualStyleBackColor = true;
            // 
            // ckBJYingy
            // 
            this.ckBJYingy.AutoSize = true;
            this.ckBJYingy.Location = new System.Drawing.Point(344, 8);
            this.ckBJYingy.Name = "ckBJYingy";
            this.ckBJYingy.Size = new System.Drawing.Size(68, 24);
            this.ckBJYingy.TabIndex = 6;
            this.ckBJYingy.Text = "营养";
            this.ckBJYingy.UseVisualStyleBackColor = true;
            // 
            // ckBJXinl
            // 
            this.ckBJXinl.AutoSize = true;
            this.ckBJXinl.Location = new System.Drawing.Point(218, 8);
            this.ckBJXinl.Name = "ckBJXinl";
            this.ckBJXinl.Size = new System.Drawing.Size(68, 24);
            this.ckBJXinl.TabIndex = 5;
            this.ckBJXinl.Text = "心理";
            this.ckBJXinl.UseVisualStyleBackColor = true;
            // 
            // ckBJPerHealth
            // 
            this.ckBJPerHealth.AutoSize = true;
            this.ckBJPerHealth.Location = new System.Drawing.Point(6, 8);
            this.ckBJPerHealth.Name = "ckBJPerHealth";
            this.ckBJPerHealth.Size = new System.Drawing.Size(108, 24);
            this.ckBJPerHealth.TabIndex = 4;
            this.ckBJPerHealth.Text = "生活方式";
            this.ckBJPerHealth.UseVisualStyleBackColor = true;
            // 
            // label66
            // 
            this.label66.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.Location = new System.Drawing.Point(79, 192);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(99, 20);
            this.label66.TabIndex = 178;
            this.label66.Text = "转    诊:";
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.rdZhuanzhenHave);
            this.panel20.Controls.Add(this.rdZhuanzhenNo);
            this.panel20.Location = new System.Drawing.Point(184, 183);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(173, 39);
            this.panel20.TabIndex = 2;
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
            this.rdZhuanzhenHave.CheckedChanged += new System.EventHandler(this.rdZhuanzhenHave_CheckedChanged);
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
            this.rdZhuanzhenNo.CheckedChanged += new System.EventHandler(this.rdZhuanzhenNo_CheckedChanged);
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.rdwdw);
            this.panel36.Controls.Add(this.rddw);
            this.panel36.Enabled = false;
            this.panel36.Location = new System.Drawing.Point(1054, 228);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(176, 32);
            this.panel36.TabIndex = 194;
            // 
            // rdwdw
            // 
            this.rdwdw.AutoSize = true;
            this.rdwdw.Location = new System.Drawing.Point(85, 5);
            this.rdwdw.Name = "rdwdw";
            this.rdwdw.Size = new System.Drawing.Size(87, 24);
            this.rdwdw.TabIndex = 151;
            this.rdwdw.TabStop = true;
            this.rdwdw.Text = "未到位";
            this.rdwdw.UseVisualStyleBackColor = true;
            // 
            // rddw
            // 
            this.rddw.AutoSize = true;
            this.rddw.Location = new System.Drawing.Point(4, 5);
            this.rddw.Name = "rddw";
            this.rddw.Size = new System.Drawing.Size(67, 24);
            this.rddw.TabIndex = 150;
            this.rddw.TabStop = true;
            this.rddw.Text = "到位";
            this.rddw.UseVisualStyleBackColor = true;
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.Location = new System.Drawing.Point(514, 192);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(99, 20);
            this.label67.TabIndex = 180;
            this.label67.Text = "原    因:";
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label68.Location = new System.Drawing.Point(929, 192);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(119, 20);
            this.label68.TabIndex = 181;
            this.label68.Text = "机构及科室:";
            // 
            // tbZhuanzhenResult
            // 
            this.tbZhuanzhenResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenResult.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenResult.Location = new System.Drawing.Point(619, 183);
            this.tbZhuanzhenResult.MaxLength = 20;
            this.tbZhuanzhenResult.Name = "tbZhuanzhenResult";
            this.tbZhuanzhenResult.ReadOnly = true;
            this.tbZhuanzhenResult.Size = new System.Drawing.Size(173, 30);
            this.tbZhuanzhenResult.TabIndex = 3;
            // 
            // tbZhuanzhenKs
            // 
            this.tbZhuanzhenKs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZhuanzhenKs.ForeColor = System.Drawing.Color.Black;
            this.tbZhuanzhenKs.Location = new System.Drawing.Point(1054, 183);
            this.tbZhuanzhenKs.MaxLength = 20;
            this.tbZhuanzhenKs.Name = "tbZhuanzhenKs";
            this.tbZhuanzhenKs.ReadOnly = true;
            this.tbZhuanzhenKs.Size = new System.Drawing.Size(173, 30);
            this.tbZhuanzhenKs.TabIndex = 4;
            // 
            // dtpNext
            // 
            this.dtpNext.Location = new System.Drawing.Point(184, 273);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(191, 30);
            this.dtpNext.TabIndex = 185;
            // 
            // label79
            // 
            this.label79.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label79.Location = new System.Drawing.Point(474, 282);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(139, 20);
            this.label79.TabIndex = 186;
            this.label79.Text = "随访医生签名:";
            this.label79.Visible = false;
            // 
            // tbDoctorMark
            // 
            this.tbDoctorMark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDoctorMark.ForeColor = System.Drawing.Color.Black;
            this.tbDoctorMark.Location = new System.Drawing.Point(619, 273);
            this.tbDoctorMark.MaxLength = 20;
            this.tbDoctorMark.Name = "tbDoctorMark";
            this.tbDoctorMark.Size = new System.Drawing.Size(173, 30);
            this.tbDoctorMark.TabIndex = 187;
            this.tbDoctorMark.Visible = false;
            // 
            // label94
            // 
            this.label94.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(79, 57);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(99, 20);
            this.label94.TabIndex = 188;
            this.label94.Text = "建册情况:";
            // 
            // panel35
            // 
            this.panel35.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.panel35, 5);
            this.panel35.Controls.Add(this.tbBooks);
            this.panel35.Controls.Add(this.rdBooks2);
            this.panel35.Controls.Add(this.rdBooks1);
            this.panel35.Location = new System.Drawing.Point(184, 48);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(1121, 39);
            this.panel35.TabIndex = 189;
            // 
            // tbBooks
            // 
            this.tbBooks.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBooks.ForeColor = System.Drawing.Color.Black;
            this.tbBooks.Location = new System.Drawing.Point(438, 3);
            this.tbBooks.MaxLength = 100;
            this.tbBooks.Multiline = true;
            this.tbBooks.Name = "tbBooks";
            this.tbBooks.ReadOnly = true;
            this.tbBooks.Size = new System.Drawing.Size(353, 30);
            this.tbBooks.TabIndex = 170;
            // 
            // rdBooks2
            // 
            this.rdBooks2.AutoSize = true;
            this.rdBooks2.Location = new System.Drawing.Point(229, 5);
            this.rdBooks2.Name = "rdBooks2";
            this.rdBooks2.Size = new System.Drawing.Size(187, 24);
            this.rdBooks2.TabIndex = 151;
            this.rdBooks2.TabStop = true;
            this.rdBooks2.Text = "已在其他机构建册";
            this.rdBooks2.UseVisualStyleBackColor = true;
            // 
            // rdBooks1
            // 
            this.rdBooks1.AutoSize = true;
            this.rdBooks1.Location = new System.Drawing.Point(1, 5);
            this.rdBooks1.Name = "rdBooks1";
            this.rdBooks1.Size = new System.Drawing.Size(187, 24);
            this.rdBooks1.TabIndex = 150;
            this.rdBooks1.TabStop = true;
            this.rdBooks1.Text = "本次随访同时建册";
            this.rdBooks1.UseVisualStyleBackColor = true;
            // 
            // label95
            // 
            this.label95.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(99, 237);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(79, 20);
            this.label95.TabIndex = 190;
            this.label95.Text = "联系人:";
            // 
            // txtReferralContacts
            // 
            this.txtReferralContacts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReferralContacts.ForeColor = System.Drawing.Color.Black;
            this.txtReferralContacts.Location = new System.Drawing.Point(184, 228);
            this.txtReferralContacts.MaxLength = 20;
            this.txtReferralContacts.Name = "txtReferralContacts";
            this.txtReferralContacts.ReadOnly = true;
            this.txtReferralContacts.Size = new System.Drawing.Size(191, 30);
            this.txtReferralContacts.TabIndex = 191;
            // 
            // label96
            // 
            this.label96.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label96.AutoSize = true;
            this.label96.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label96.Location = new System.Drawing.Point(514, 237);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(99, 20);
            this.label96.TabIndex = 192;
            this.label96.Text = "联系电话:";
            // 
            // txtReferralContactsTel
            // 
            this.txtReferralContactsTel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReferralContactsTel.ForeColor = System.Drawing.Color.Black;
            this.txtReferralContactsTel.Location = new System.Drawing.Point(619, 228);
            this.txtReferralContactsTel.MaxLength = 20;
            this.txtReferralContactsTel.Name = "txtReferralContactsTel";
            this.txtReferralContactsTel.ReadOnly = true;
            this.txtReferralContactsTel.Size = new System.Drawing.Size(173, 30);
            this.txtReferralContactsTel.TabIndex = 193;
            // 
            // panel37
            // 
            this.panel37.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.panel37, 6);
            this.panel37.Controls.Add(this.picSignYs);
            this.panel37.Controls.Add(this.lkYs);
            this.panel37.Controls.Add(this.label99);
            this.panel37.Controls.Add(this.picSignJs);
            this.panel37.Controls.Add(this.lkJs);
            this.panel37.Controls.Add(this.label98);
            this.panel37.Location = new System.Drawing.Point(0, 315);
            this.panel37.Margin = new System.Windows.Forms.Padding(0);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(1308, 57);
            this.panel37.TabIndex = 195;
            // 
            // picSignYs
            // 
            this.picSignYs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(180, 6);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(342, 43);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 198;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // lkYs
            // 
            this.lkYs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(548, 19);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 201;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // label99
            // 
            this.label99.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label99.AutoSize = true;
            this.label99.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label99.Location = new System.Drawing.Point(39, 19);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(139, 20);
            this.label99.TabIndex = 200;
            this.label99.Text = "随访医生签名:";
            // 
            // picSignJs
            // 
            this.picSignJs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picSignJs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJs.Location = new System.Drawing.Point(872, 8);
            this.picSignJs.Name = "picSignJs";
            this.picSignJs.Size = new System.Drawing.Size(280, 43);
            this.picSignJs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJs.TabIndex = 0;
            this.picSignJs.TabStop = false;
            this.picSignJs.Click += new System.EventHandler(this.picSignJs_Click);
            // 
            // lkJs
            // 
            this.lkJs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lkJs.AutoSize = true;
            this.lkJs.Location = new System.Drawing.Point(1158, 19);
            this.lkJs.Name = "lkJs";
            this.lkJs.Size = new System.Drawing.Size(89, 20);
            this.lkJs.TabIndex = 197;
            this.lkJs.TabStop = true;
            this.lkJs.Text = "重置签名";
            this.lkJs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label98
            // 
            this.label98.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label98.AutoSize = true;
            this.label98.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label98.Location = new System.Drawing.Point(690, 19);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(149, 20);
            this.label98.TabIndex = 195;
            this.label98.Text = "居民/家属签名:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(15, 627);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(139, 20);
            this.label43.TabIndex = 165;
            this.label43.Text = "妇科辅助检查:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel2.Controls.Add(this.label93, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.panel30, 3, 11);
            this.tableLayoutPanel2.Controls.Add(this.label27, 2, 11);
            this.tableLayoutPanel2.Controls.Add(this.panel29, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.panel26, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label50, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbRh, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.panel23, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label60, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label62, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label74, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.panel28, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label76, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label77, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.panel25, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbBloodType, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label49, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label75, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.panel24, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.panel27, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label64, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.panel33, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.panel10, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.label42, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.panel34, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.label61, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 654);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 14;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.741573F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.303371F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.17603F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1308, 570);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label93
            // 
            this.label93.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label93.AutoSize = true;
            this.label93.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label93.Location = new System.Drawing.Point(119, 535);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(59, 20);
            this.label93.TabIndex = 174;
            this.label93.Text = "其他:";
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.rdHIVYang);
            this.panel30.Controls.Add(this.rdHIVYin);
            this.panel30.Location = new System.Drawing.Point(619, 438);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(173, 32);
            this.panel30.TabIndex = 10;
            // 
            // rdHIVYang
            // 
            this.rdHIVYang.AutoSize = true;
            this.rdHIVYang.Location = new System.Drawing.Point(91, 3);
            this.rdHIVYang.Name = "rdHIVYang";
            this.rdHIVYang.Size = new System.Drawing.Size(67, 24);
            this.rdHIVYang.TabIndex = 150;
            this.rdHIVYang.TabStop = true;
            this.rdHIVYang.Text = "阳性";
            this.rdHIVYang.UseVisualStyleBackColor = true;
            // 
            // rdHIVYin
            // 
            this.rdHIVYin.AutoSize = true;
            this.rdHIVYin.Location = new System.Drawing.Point(4, 3);
            this.rdHIVYin.Name = "rdHIVYin";
            this.rdHIVYin.Size = new System.Drawing.Size(67, 24);
            this.rdHIVYin.TabIndex = 149;
            this.rdHIVYin.TabStop = true;
            this.rdHIVYin.Text = "阴性";
            this.rdHIVYin.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(474, 444);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(139, 20);
            this.label27.TabIndex = 171;
            this.label27.Text = "HIV抗体检测*:";
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.rdMeidYang);
            this.panel29.Controls.Add(this.rdMeidYin);
            this.panel29.Location = new System.Drawing.Point(184, 438);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(173, 32);
            this.panel29.TabIndex = 9;
            // 
            // rdMeidYang
            // 
            this.rdMeidYang.AutoSize = true;
            this.rdMeidYang.Location = new System.Drawing.Point(91, 3);
            this.rdMeidYang.Name = "rdMeidYang";
            this.rdMeidYang.Size = new System.Drawing.Size(67, 24);
            this.rdMeidYang.TabIndex = 150;
            this.rdMeidYang.TabStop = true;
            this.rdMeidYang.Text = "阳性";
            this.rdMeidYang.UseVisualStyleBackColor = true;
            // 
            // rdMeidYin
            // 
            this.rdMeidYin.AutoSize = true;
            this.rdMeidYin.Location = new System.Drawing.Point(4, 3);
            this.rdMeidYin.Name = "rdMeidYin";
            this.rdMeidYin.Size = new System.Drawing.Size(67, 24);
            this.rdMeidYin.TabIndex = 149;
            this.rdMeidYin.TabStop = true;
            this.rdMeidYin.Text = "阴性";
            this.rdMeidYin.UseVisualStyleBackColor = true;
            // 
            // panel26
            // 
            this.panel26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.panel26, 5);
            this.panel26.Controls.Add(this.tbCB);
            this.panel26.Controls.Add(this.label51);
            this.panel26.Controls.Add(this.label85);
            this.panel26.Controls.Add(this.label86);
            this.panel26.Controls.Add(this.tbTBIL);
            this.panel26.Controls.Add(this.label87);
            this.panel26.Controls.Add(this.label52);
            this.panel26.Controls.Add(this.tbBP);
            this.panel26.Controls.Add(this.label53);
            this.panel26.Controls.Add(this.label54);
            this.panel26.Controls.Add(this.tbGOT);
            this.panel26.Controls.Add(this.label63);
            this.panel26.Controls.Add(this.label83);
            this.panel26.Controls.Add(this.tbSGPT);
            this.panel26.Controls.Add(this.label84);
            this.panel26.Location = new System.Drawing.Point(181, 160);
            this.panel26.Margin = new System.Windows.Forms.Padding(0);
            this.panel26.Name = "panel26";
            this.tableLayoutPanel2.SetRowSpan(this.panel26, 2);
            this.panel26.Size = new System.Drawing.Size(1127, 80);
            this.panel26.TabIndex = 5;
            // 
            // tbCB
            // 
            this.tbCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCB.ForeColor = System.Drawing.Color.Black;
            this.tbCB.Location = new System.Drawing.Point(527, 43);
            this.tbCB.MaxLength = 3;
            this.tbCB.Name = "tbCB";
            this.tbCB.Size = new System.Drawing.Size(62, 30);
            this.tbCB.TabIndex = 13;
            // 
            // label51
            // 
            this.label51.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label51.Location = new System.Drawing.Point(600, 50);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(79, 20);
            this.label51.TabIndex = 14;
            this.label51.Text = "μmol/L";
            // 
            // label85
            // 
            this.label85.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label85.Location = new System.Drawing.Point(397, 52);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(119, 20);
            this.label85.TabIndex = 12;
            this.label85.Text = "综合胆红素:";
            // 
            // label86
            // 
            this.label86.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label86.Location = new System.Drawing.Point(248, 52);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(79, 20);
            this.label86.TabIndex = 11;
            this.label86.Text = "μmol/L";
            // 
            // tbTBIL
            // 
            this.tbTBIL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbTBIL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbTBIL.ForeColor = System.Drawing.Color.Black;
            this.tbTBIL.Location = new System.Drawing.Point(172, 47);
            this.tbTBIL.MaxLength = 3;
            this.tbTBIL.Name = "tbTBIL";
            this.tbTBIL.Size = new System.Drawing.Size(62, 30);
            this.tbTBIL.TabIndex = 10;
            // 
            // label87
            // 
            this.label87.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label87.AutoSize = true;
            this.label87.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label87.Location = new System.Drawing.Point(67, 52);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(99, 20);
            this.label87.TabIndex = 9;
            this.label87.Text = "总胆红素:";
            // 
            // label52
            // 
            this.label52.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label52.Location = new System.Drawing.Point(860, 9);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(39, 20);
            this.label52.TabIndex = 8;
            this.label52.Text = "g/L";
            // 
            // tbBP
            // 
            this.tbBP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbBP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBP.ForeColor = System.Drawing.Color.Black;
            this.tbBP.Location = new System.Drawing.Point(787, 3);
            this.tbBP.MaxLength = 3;
            this.tbBP.Name = "tbBP";
            this.tbBP.Size = new System.Drawing.Size(62, 30);
            this.tbBP.TabIndex = 7;
            // 
            // label53
            // 
            this.label53.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label53.Location = new System.Drawing.Point(699, 11);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(79, 20);
            this.label53.TabIndex = 6;
            this.label53.Text = "白蛋白:";
            // 
            // label54
            // 
            this.label54.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.Location = new System.Drawing.Point(600, 11);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(39, 20);
            this.label54.TabIndex = 5;
            this.label54.Text = "U/L";
            // 
            // tbGOT
            // 
            this.tbGOT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbGOT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGOT.ForeColor = System.Drawing.Color.Black;
            this.tbGOT.Location = new System.Drawing.Point(527, 3);
            this.tbGOT.MaxLength = 3;
            this.tbGOT.Name = "tbGOT";
            this.tbGOT.Size = new System.Drawing.Size(62, 30);
            this.tbGOT.TabIndex = 4;
            // 
            // label63
            // 
            this.label63.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label63.Location = new System.Drawing.Point(359, 11);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(159, 20);
            this.label63.TabIndex = 3;
            this.label63.Text = "血清谷草转氨酶:";
            // 
            // label83
            // 
            this.label83.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label83.Location = new System.Drawing.Point(251, 13);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(39, 20);
            this.label83.TabIndex = 2;
            this.label83.Text = "U/L";
            // 
            // tbSGPT
            // 
            this.tbSGPT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbSGPT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSGPT.ForeColor = System.Drawing.Color.Black;
            this.tbSGPT.Location = new System.Drawing.Point(172, 6);
            this.tbSGPT.MaxLength = 3;
            this.tbSGPT.Name = "tbSGPT";
            this.tbSGPT.Size = new System.Drawing.Size(62, 30);
            this.tbSGPT.TabIndex = 1;
            // 
            // label84
            // 
            this.label84.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label84.Location = new System.Drawing.Point(7, 13);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(159, 20);
            this.label84.TabIndex = 0;
            this.label84.Text = "血清谷丙转氨酶:";
            // 
            // label50
            // 
            this.label50.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.Location = new System.Drawing.Point(949, 130);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(99, 20);
            this.label50.TabIndex = 161;
            this.label50.Text = "血   糖*:";
            // 
            // tbRh
            // 
            this.tbRh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbRh.ForeColor = System.Drawing.Color.Black;
            this.tbRh.Location = new System.Drawing.Point(619, 123);
            this.tbRh.MaxLength = 20;
            this.tbRh.Multiline = true;
            this.tbRh.Name = "tbRh";
            this.tbRh.ReadOnly = true;
            this.tbRh.Size = new System.Drawing.Size(173, 34);
            this.tbRh.TabIndex = 3;
            // 
            // panel23
            // 
            this.panel23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.panel23, 5);
            this.panel23.Controls.Add(this.tbNiaoEx);
            this.panel23.Controls.Add(this.label46);
            this.panel23.Controls.Add(this.btnSelectNiao);
            this.panel23.Controls.Add(this.tbNiao);
            this.panel23.Location = new System.Drawing.Point(181, 80);
            this.panel23.Margin = new System.Windows.Forms.Padding(0);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(1127, 40);
            this.panel23.TabIndex = 1;
            // 
            // tbNiaoEx
            // 
            this.tbNiaoEx.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbNiaoEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNiaoEx.ForeColor = System.Drawing.Color.Black;
            this.tbNiaoEx.Location = new System.Drawing.Point(801, 7);
            this.tbNiaoEx.MaxLength = 15;
            this.tbNiaoEx.Name = "tbNiaoEx";
            this.tbNiaoEx.Size = new System.Drawing.Size(308, 30);
            this.tbNiaoEx.TabIndex = 159;
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.Location = new System.Drawing.Point(743, 13);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 20);
            this.label46.TabIndex = 158;
            this.label46.Text = "其他:";
            // 
            // btnSelectNiao
            // 
            this.btnSelectNiao.Location = new System.Drawing.Point(307, 6);
            this.btnSelectNiao.Name = "btnSelectNiao";
            this.btnSelectNiao.Size = new System.Drawing.Size(40, 32);
            this.btnSelectNiao.TabIndex = 146;
            this.btnSelectNiao.Text = "...";
            this.btnSelectNiao.UseVisualStyleBackColor = true;
            this.btnSelectNiao.Click += new System.EventHandler(this.btnSelectNiao_Click);
            // 
            // tbNiao
            // 
            this.tbNiao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbNiao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNiao.ForeColor = System.Drawing.Color.Black;
            this.tbNiao.Location = new System.Drawing.Point(3, 2);
            this.tbNiao.MaxLength = 100;
            this.tbNiao.Multiline = true;
            this.tbNiao.Name = "tbNiao";
            this.tbNiao.ReadOnly = true;
            this.tbNiao.Size = new System.Drawing.Size(298, 34);
            this.tbNiao.TabIndex = 111;
            // 
            // label60
            // 
            this.label60.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label60.Location = new System.Drawing.Point(79, 90);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(99, 20);
            this.label60.TabIndex = 134;
            this.label60.Text = "尿 常 规:";
            // 
            // label62
            // 
            this.label62.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label62.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label62.Location = new System.Drawing.Point(56, 22);
            this.label62.Name = "label62";
            this.tableLayoutPanel2.SetRowSpan(this.label62, 2);
            this.label62.Size = new System.Drawing.Size(122, 35);
            this.label62.TabIndex = 129;
            this.label62.Text = "血 常 规:";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label74
            // 
            this.label74.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label74.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label74.Location = new System.Drawing.Point(56, 307);
            this.label74.Name = "label74";
            this.tableLayoutPanel2.SetRowSpan(this.label74, 2);
            this.label74.Size = new System.Drawing.Size(122, 26);
            this.label74.TabIndex = 146;
            this.label74.Text = "阴道分泌物*:";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel28
            // 
            this.panel28.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.panel28, 5);
            this.panel28.Controls.Add(this.cbVaginCleaess);
            this.panel28.Controls.Add(this.label65);
            this.panel28.Controls.Add(this.tbVaginEx);
            this.panel28.Controls.Add(this.ckVaginEx);
            this.panel28.Controls.Add(this.ckJsjmj);
            this.panel28.Controls.Add(this.ckDichong);
            this.panel28.Controls.Add(this.ckVaginNormal);
            this.panel28.Location = new System.Drawing.Point(181, 280);
            this.panel28.Margin = new System.Windows.Forms.Padding(0);
            this.panel28.Name = "panel28";
            this.tableLayoutPanel2.SetRowSpan(this.panel28, 2);
            this.panel28.Size = new System.Drawing.Size(1127, 80);
            this.panel28.TabIndex = 7;
            // 
            // cbVaginCleaess
            // 
            this.cbVaginCleaess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVaginCleaess.FormattingEnabled = true;
            this.cbVaginCleaess.Location = new System.Drawing.Point(126, 43);
            this.cbVaginCleaess.Name = "cbVaginCleaess";
            this.cbVaginCleaess.Size = new System.Drawing.Size(214, 28);
            this.cbVaginCleaess.TabIndex = 162;
            // 
            // label65
            // 
            this.label65.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label65.Location = new System.Drawing.Point(8, 50);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(119, 20);
            this.label65.TabIndex = 161;
            this.label65.Text = "阴道清洁度:";
            // 
            // tbVaginEx
            // 
            this.tbVaginEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbVaginEx.ForeColor = System.Drawing.Color.Black;
            this.tbVaginEx.Location = new System.Drawing.Point(464, 3);
            this.tbVaginEx.MaxLength = 20;
            this.tbVaginEx.Multiline = true;
            this.tbVaginEx.Name = "tbVaginEx";
            this.tbVaginEx.ReadOnly = true;
            this.tbVaginEx.Size = new System.Drawing.Size(332, 26);
            this.tbVaginEx.TabIndex = 158;
            // 
            // ckVaginEx
            // 
            this.ckVaginEx.AutoSize = true;
            this.ckVaginEx.Location = new System.Drawing.Point(371, 5);
            this.ckVaginEx.Name = "ckVaginEx";
            this.ckVaginEx.Size = new System.Drawing.Size(68, 24);
            this.ckVaginEx.TabIndex = 3;
            this.ckVaginEx.Text = "其他";
            this.ckVaginEx.UseVisualStyleBackColor = true;
            // 
            // ckJsjmj
            // 
            this.ckJsjmj.AutoSize = true;
            this.ckJsjmj.Location = new System.Drawing.Point(216, 5);
            this.ckJsjmj.Name = "ckJsjmj";
            this.ckJsjmj.Size = new System.Drawing.Size(128, 24);
            this.ckJsjmj.TabIndex = 2;
            this.ckJsjmj.Text = "假丝酵母菌";
            this.ckJsjmj.UseVisualStyleBackColor = true;
            // 
            // ckDichong
            // 
            this.ckDichong.AutoSize = true;
            this.ckDichong.Location = new System.Drawing.Point(122, 5);
            this.ckDichong.Name = "ckDichong";
            this.ckDichong.Size = new System.Drawing.Size(68, 24);
            this.ckDichong.TabIndex = 1;
            this.ckDichong.Text = "滴虫";
            this.ckDichong.UseVisualStyleBackColor = true;
            // 
            // ckVaginNormal
            // 
            this.ckVaginNormal.AutoSize = true;
            this.ckVaginNormal.Location = new System.Drawing.Point(4, 5);
            this.ckVaginNormal.Name = "ckVaginNormal";
            this.ckVaginNormal.Size = new System.Drawing.Size(108, 24);
            this.ckVaginNormal.TabIndex = 0;
            this.ckVaginNormal.Text = "未见异常";
            this.ckVaginNormal.UseVisualStyleBackColor = true;
            // 
            // label76
            // 
            this.label76.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label76.Location = new System.Drawing.Point(79, 250);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(99, 20);
            this.label76.TabIndex = 162;
            this.label76.Text = "肾 功 能:";
            // 
            // label77
            // 
            this.label77.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label77.Location = new System.Drawing.Point(9, 444);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(169, 20);
            this.label77.TabIndex = 164;
            this.label77.Text = "梅毒血清学试验*:";
            // 
            // panel25
            // 
            this.panel25.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.panel25, 5);
            this.panel25.Controls.Add(this.btnSelectHB);
            this.panel25.Controls.Add(this.tbBloodEx);
            this.panel25.Controls.Add(this.label82);
            this.panel25.Controls.Add(this.label58);
            this.panel25.Controls.Add(this.tbPLT);
            this.panel25.Controls.Add(this.label59);
            this.panel25.Controls.Add(this.label56);
            this.panel25.Controls.Add(this.tbWBC);
            this.panel25.Controls.Add(this.label57);
            this.panel25.Controls.Add(this.label55);
            this.panel25.Controls.Add(this.tbHB);
            this.panel25.Controls.Add(this.label48);
            this.panel25.Location = new System.Drawing.Point(181, 0);
            this.panel25.Margin = new System.Windows.Forms.Padding(0);
            this.panel25.Name = "panel25";
            this.tableLayoutPanel2.SetRowSpan(this.panel25, 2);
            this.panel25.Size = new System.Drawing.Size(1127, 80);
            this.panel25.TabIndex = 0;
            // 
            // btnSelectHB
            // 
            this.btnSelectHB.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectHB.Location = new System.Drawing.Point(226, 7);
            this.btnSelectHB.Name = "btnSelectHB";
            this.btnSelectHB.Size = new System.Drawing.Size(40, 31);
            this.btnSelectHB.TabIndex = 1;
            this.btnSelectHB.Text = "...";
            this.btnSelectHB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectHB.UseVisualStyleBackColor = true;
            this.btnSelectHB.Click += new System.EventHandler(this.btnSelectHB_Click);
            // 
            // tbBloodEx
            // 
            this.tbBloodEx.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbBloodEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBloodEx.ForeColor = System.Drawing.Color.Black;
            this.tbBloodEx.Location = new System.Drawing.Point(134, 46);
            this.tbBloodEx.MaxLength = 15;
            this.tbBloodEx.Name = "tbBloodEx";
            this.tbBloodEx.Size = new System.Drawing.Size(365, 30);
            this.tbBloodEx.TabIndex = 4;
            // 
            // label82
            // 
            this.label82.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label82.Location = new System.Drawing.Point(8, 50);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(119, 20);
            this.label82.TabIndex = 157;
            this.label82.Text = "其      他:";
            // 
            // label58
            // 
            this.label58.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label58.Location = new System.Drawing.Point(797, 12);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(29, 20);
            this.label58.TabIndex = 156;
            this.label58.Text = "/L";
            // 
            // tbPLT
            // 
            this.tbPLT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbPLT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbPLT.ForeColor = System.Drawing.Color.Black;
            this.tbPLT.Location = new System.Drawing.Point(743, 8);
            this.tbPLT.MaxLength = 3;
            this.tbPLT.Name = "tbPLT";
            this.tbPLT.Size = new System.Drawing.Size(39, 30);
            this.tbPLT.TabIndex = 3;
            // 
            // label59
            // 
            this.label59.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label59.Location = new System.Drawing.Point(603, 12);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(139, 20);
            this.label59.TabIndex = 154;
            this.label59.Text = "血小板计数值:";
            // 
            // label56
            // 
            this.label56.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label56.Location = new System.Drawing.Point(517, 12);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(29, 20);
            this.label56.TabIndex = 153;
            this.label56.Text = "/L";
            // 
            // tbWBC
            // 
            this.tbWBC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbWBC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWBC.ForeColor = System.Drawing.Color.Black;
            this.tbWBC.Location = new System.Drawing.Point(464, 8);
            this.tbWBC.MaxLength = 3;
            this.tbWBC.Name = "tbWBC";
            this.tbWBC.Size = new System.Drawing.Size(39, 30);
            this.tbWBC.TabIndex = 2;
            // 
            // label57
            // 
            this.label57.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.Location = new System.Drawing.Point(324, 12);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(139, 20);
            this.label57.TabIndex = 151;
            this.label57.Text = "白细胞计数值:";
            // 
            // label55
            // 
            this.label55.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.Location = new System.Drawing.Point(183, 12);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(39, 20);
            this.label55.TabIndex = 150;
            this.label55.Text = "g/L";
            // 
            // tbHB
            // 
            this.tbHB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHB.ForeColor = System.Drawing.Color.Black;
            this.tbHB.Location = new System.Drawing.Point(134, 8);
            this.tbHB.MaxLength = 3;
            this.tbHB.Name = "tbHB";
            this.tbHB.Size = new System.Drawing.Size(39, 30);
            this.tbHB.TabIndex = 0;
            // 
            // label48
            // 
            this.label48.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label48.Location = new System.Drawing.Point(8, 12);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(119, 20);
            this.label48.TabIndex = 146;
            this.label48.Text = "血红蛋白值:";
            // 
            // tbBloodType
            // 
            this.tbBloodType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBloodType.ForeColor = System.Drawing.Color.Black;
            this.tbBloodType.Location = new System.Drawing.Point(184, 123);
            this.tbBloodType.MaxLength = 10;
            this.tbBloodType.Multiline = true;
            this.tbBloodType.Name = "tbBloodType";
            this.tbBloodType.ReadOnly = true;
            this.tbBloodType.Size = new System.Drawing.Size(173, 34);
            this.tbBloodType.TabIndex = 2;
            // 
            // label49
            // 
            this.label49.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label49.Location = new System.Drawing.Point(564, 130);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(49, 20);
            this.label49.TabIndex = 160;
            this.label49.Text = "RH*:";
            // 
            // label75
            // 
            this.label75.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label75.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label75.Location = new System.Drawing.Point(56, 183);
            this.label75.Name = "label75";
            this.tableLayoutPanel2.SetRowSpan(this.label75, 2);
            this.label75.Size = new System.Drawing.Size(122, 34);
            this.label75.TabIndex = 161;
            this.label75.Text = "肝 功 能:";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel24
            // 
            this.panel24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.panel24, 5);
            this.panel24.Controls.Add(this.label47);
            this.panel24.Controls.Add(this.tbBUN);
            this.panel24.Controls.Add(this.label90);
            this.panel24.Controls.Add(this.label89);
            this.panel24.Controls.Add(this.tbSCR);
            this.panel24.Controls.Add(this.label88);
            this.panel24.Location = new System.Drawing.Point(181, 240);
            this.panel24.Margin = new System.Windows.Forms.Padding(0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(1127, 40);
            this.panel24.TabIndex = 6;
            // 
            // label47
            // 
            this.label47.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.Location = new System.Drawing.Point(603, 6);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(69, 20);
            this.label47.TabIndex = 164;
            this.label47.Text = "mmol/L";
            // 
            // tbBUN
            // 
            this.tbBUN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbBUN.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBUN.ForeColor = System.Drawing.Color.Black;
            this.tbBUN.Location = new System.Drawing.Point(529, 3);
            this.tbBUN.MaxLength = 3;
            this.tbBUN.Name = "tbBUN";
            this.tbBUN.Size = new System.Drawing.Size(60, 30);
            this.tbBUN.TabIndex = 163;
            // 
            // label90
            // 
            this.label90.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label90.Location = new System.Drawing.Point(417, 9);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(99, 20);
            this.label90.TabIndex = 162;
            this.label90.Text = "血尿素氮:";
            // 
            // label89
            // 
            this.label89.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label89.AutoSize = true;
            this.label89.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label89.Location = new System.Drawing.Point(249, 10);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(79, 20);
            this.label89.TabIndex = 161;
            this.label89.Text = "μmol/L";
            // 
            // tbSCR
            // 
            this.tbSCR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbSCR.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSCR.ForeColor = System.Drawing.Color.Black;
            this.tbSCR.Location = new System.Drawing.Point(172, 5);
            this.tbSCR.MaxLength = 3;
            this.tbSCR.Name = "tbSCR";
            this.tbSCR.Size = new System.Drawing.Size(62, 30);
            this.tbSCR.TabIndex = 160;
            // 
            // label88
            // 
            this.label88.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label88.Location = new System.Drawing.Point(67, 10);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(99, 20);
            this.label88.TabIndex = 147;
            this.label88.Text = "血清肌酐:";
            // 
            // panel27
            // 
            this.panel27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.panel27, 5);
            this.panel27.Controls.Add(this.tbHBCAB);
            this.panel27.Controls.Add(this.label69);
            this.panel27.Controls.Add(this.tbHBEAB);
            this.panel27.Controls.Add(this.label70);
            this.panel27.Controls.Add(this.tbHBEAG);
            this.panel27.Controls.Add(this.label71);
            this.panel27.Controls.Add(this.tbHBSAB);
            this.panel27.Controls.Add(this.label72);
            this.panel27.Controls.Add(this.tbHBSAG);
            this.panel27.Controls.Add(this.label73);
            this.panel27.Location = new System.Drawing.Point(181, 360);
            this.panel27.Margin = new System.Windows.Forms.Padding(0);
            this.panel27.Name = "panel27";
            this.tableLayoutPanel2.SetRowSpan(this.panel27, 2);
            this.panel27.Size = new System.Drawing.Size(1127, 75);
            this.panel27.TabIndex = 8;
            // 
            // tbHBCAB
            // 
            this.tbHBCAB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHBCAB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHBCAB.ForeColor = System.Drawing.Color.Black;
            this.tbHBCAB.Location = new System.Drawing.Point(440, 36);
            this.tbHBCAB.MaxLength = 15;
            this.tbHBCAB.Name = "tbHBCAB";
            this.tbHBCAB.Size = new System.Drawing.Size(39, 30);
            this.tbHBCAB.TabIndex = 151;
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label69.Location = new System.Drawing.Point(261, 41);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(179, 20);
            this.label69.TabIndex = 150;
            this.label69.Text = "乙型肝炎核心抗体:";
            // 
            // tbHBEAB
            // 
            this.tbHBEAB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHBEAB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHBEAB.ForeColor = System.Drawing.Color.Black;
            this.tbHBEAB.Location = new System.Drawing.Point(198, 36);
            this.tbHBEAB.MaxLength = 15;
            this.tbHBEAB.Name = "tbHBEAB";
            this.tbHBEAB.Size = new System.Drawing.Size(39, 30);
            this.tbHBEAB.TabIndex = 149;
            // 
            // label70
            // 
            this.label70.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label70.Location = new System.Drawing.Point(41, 41);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(149, 20);
            this.label70.TabIndex = 148;
            this.label70.Text = "乙型肝炎e抗体:";
            // 
            // tbHBEAG
            // 
            this.tbHBEAG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHBEAG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHBEAG.ForeColor = System.Drawing.Color.Black;
            this.tbHBEAG.Location = new System.Drawing.Point(691, 1);
            this.tbHBEAG.MaxLength = 15;
            this.tbHBEAG.Name = "tbHBEAG";
            this.tbHBEAG.Size = new System.Drawing.Size(39, 30);
            this.tbHBEAG.TabIndex = 147;
            // 
            // label71
            // 
            this.label71.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label71.Location = new System.Drawing.Point(534, 6);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(149, 20);
            this.label71.TabIndex = 146;
            this.label71.Text = "乙型肝炎e抗原:";
            // 
            // tbHBSAB
            // 
            this.tbHBSAB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHBSAB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHBSAB.ForeColor = System.Drawing.Color.Black;
            this.tbHBSAB.Location = new System.Drawing.Point(441, 1);
            this.tbHBSAB.MaxLength = 15;
            this.tbHBSAB.Name = "tbHBSAB";
            this.tbHBSAB.Size = new System.Drawing.Size(39, 30);
            this.tbHBSAB.TabIndex = 145;
            // 
            // label72
            // 
            this.label72.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label72.Location = new System.Drawing.Point(263, 6);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(179, 20);
            this.label72.TabIndex = 144;
            this.label72.Text = "乙型肝炎表面抗体:";
            // 
            // tbHBSAG
            // 
            this.tbHBSAG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHBSAG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHBSAG.ForeColor = System.Drawing.Color.Black;
            this.tbHBSAG.Location = new System.Drawing.Point(199, 1);
            this.tbHBSAG.MaxLength = 15;
            this.tbHBSAG.Name = "tbHBSAG";
            this.tbHBSAG.Size = new System.Drawing.Size(39, 30);
            this.tbHBSAG.TabIndex = 1;
            // 
            // label73
            // 
            this.label73.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label73.Location = new System.Drawing.Point(11, 6);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(179, 20);
            this.label73.TabIndex = 0;
            this.label73.Text = "乙型肝炎表面抗原:";
            // 
            // label64
            // 
            this.label64.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label64.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label64.Location = new System.Drawing.Point(56, 380);
            this.label64.Name = "label64";
            this.tableLayoutPanel2.SetRowSpan(this.label64, 2);
            this.label64.Size = new System.Drawing.Size(122, 34);
            this.label64.TabIndex = 157;
            this.label64.Text = "乙型肝炎五项:";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.btnFPGL);
            this.panel33.Controls.Add(this.label91);
            this.panel33.Controls.Add(this.tbFPGL);
            this.panel33.Location = new System.Drawing.Point(1051, 120);
            this.panel33.Margin = new System.Windows.Forms.Padding(0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(251, 40);
            this.panel33.TabIndex = 4;
            // 
            // btnFPGL
            // 
            this.btnFPGL.Location = new System.Drawing.Point(189, 5);
            this.btnFPGL.Name = "btnFPGL";
            this.btnFPGL.Size = new System.Drawing.Size(44, 29);
            this.btnFPGL.TabIndex = 170;
            this.btnFPGL.Text = ".....";
            this.btnFPGL.UseVisualStyleBackColor = true;
            this.btnFPGL.Click += new System.EventHandler(this.btnFPGL_Click);
            // 
            // label91
            // 
            this.label91.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label91.Location = new System.Drawing.Point(96, 12);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(69, 20);
            this.label91.TabIndex = 169;
            this.label91.Text = "mmol/L";
            // 
            // tbFPGL
            // 
            this.tbFPGL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFPGL.ForeColor = System.Drawing.Color.Black;
            this.tbFPGL.Location = new System.Drawing.Point(2, 5);
            this.tbFPGL.MaxLength = 6;
            this.tbFPGL.Multiline = true;
            this.tbFPGL.Name = "tbFPGL";
            this.tbFPGL.ReadOnly = true;
            this.tbFPGL.Size = new System.Drawing.Size(72, 31);
            this.tbFPGL.TabIndex = 168;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.panel10, 5);
            this.panel10.Controls.Add(this.tbBSuper);
            this.panel10.Location = new System.Drawing.Point(181, 473);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1127, 48);
            this.panel10.TabIndex = 11;
            // 
            // tbBSuper
            // 
            this.tbBSuper.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbBSuper.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBSuper.ForeColor = System.Drawing.Color.Black;
            this.tbBSuper.Location = new System.Drawing.Point(3, 8);
            this.tbBSuper.MaxLength = 15;
            this.tbBSuper.Name = "tbBSuper";
            this.tbBSuper.Size = new System.Drawing.Size(793, 30);
            this.tbBSuper.TabIndex = 160;
            // 
            // label42
            // 
            this.label42.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.Location = new System.Drawing.Point(119, 487);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(59, 20);
            this.label42.TabIndex = 173;
            this.label42.Text = "B超*:";
            // 
            // panel34
            // 
            this.panel34.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.panel34, 5);
            this.panel34.Controls.Add(this.txtAssistOther);
            this.panel34.Location = new System.Drawing.Point(184, 524);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(1121, 43);
            this.panel34.TabIndex = 175;
            // 
            // txtAssistOther
            // 
            this.txtAssistOther.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAssistOther.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAssistOther.ForeColor = System.Drawing.Color.Black;
            this.txtAssistOther.Location = new System.Drawing.Point(1, 6);
            this.txtAssistOther.MaxLength = 15;
            this.txtAssistOther.Name = "txtAssistOther";
            this.txtAssistOther.Size = new System.Drawing.Size(793, 30);
            this.txtAssistOther.TabIndex = 161;
            // 
            // label61
            // 
            this.label61.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label61.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label61.Location = new System.Drawing.Point(61, 124);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(117, 32);
            this.label61.TabIndex = 129;
            this.label61.Text = "血    型:";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(16, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 129;
            this.label8.Text = "姓    名:";
            // 
            // btnBaseInfo
            // 
            this.btnBaseInfo.Location = new System.Drawing.Point(127, 2);
            this.btnBaseInfo.Name = "btnBaseInfo";
            this.btnBaseInfo.Size = new System.Drawing.Size(114, 37);
            this.btnBaseInfo.TabIndex = 0;
            this.btnBaseInfo.Text = "基本信息";
            this.btnBaseInfo.UseVisualStyleBackColor = true;
            this.btnBaseInfo.Click += new System.EventHandler(this.btnBaseInfo_Click);
            // 
            // btnAssistCheck
            // 
            this.btnAssistCheck.Location = new System.Drawing.Point(273, 2);
            this.btnAssistCheck.Name = "btnAssistCheck";
            this.btnAssistCheck.Size = new System.Drawing.Size(114, 37);
            this.btnAssistCheck.TabIndex = 1;
            this.btnAssistCheck.Text = "辅助检查";
            this.btnAssistCheck.UseVisualStyleBackColor = true;
            this.btnAssistCheck.Click += new System.EventHandler(this.btnAssistCheck_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(756, 5);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 33);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "下";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseUp);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(671, 5);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 33);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "上";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel31.Controls.Add(this.lbInfo);
            this.panel31.Controls.Add(this.btnBaseInfo);
            this.panel31.Controls.Add(this.btnDown);
            this.panel31.Controls.Add(this.btnAssistCheck);
            this.panel31.Controls.Add(this.btnUp);
            this.panel31.Location = new System.Drawing.Point(280, 607);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(955, 41);
            this.panel31.TabIndex = 1;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(845, 10);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(79, 20);
            this.lbInfo.TabIndex = 4;
            this.lbInfo.Text = "label92";
            this.lbInfo.Visible = false;
            // 
            // GravidaFirstVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel31);
            this.Controls.Add(this.panel6);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GravidaFirstVisitForm";
            this.Text = "GrvFirstVisitForm";
            this.Load += new System.EventHandler(this.FrmGrvFirstVisit_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panel35.ResumeLayout(false);
            this.panel35.PerformLayout();
            this.panel37.ResumeLayout(false);
            this.panel37.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel30.ResumeLayout(false);
            this.panel30.PerformLayout();
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panel33.ResumeLayout(false);
            this.panel33.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel34.ResumeLayout(false);
            this.panel34.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InitModel()
        {
            this.GrvFirst = new WomenGravidaFirstVisitBLL().GetModel(this.Model.IDCardNo);
            if (this.GrvFirst == null)
            {
                this.GrvFirst = new WomenGravidaFirstVisitModel();
                this.GrvFirst.RecordDate = new DateTime?(DateTime.Today);
                this.GrvFirst.CustomerAge = new int?(DateTime.Today.Year - this.Model.Birthday.Value.Year);
                this.GrvFirst.RecordID = this.Model.RecordID;
                this.GrvFirst.IDCardNo = this.Model.IDCardNo;
                this.GrvFirst.CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.GrvFirst.CreatedDate = new DateTime?(DateTime.Today);
                this.GrvFirst.OverAlassessMent = "1";
                this.GrvFrCheck = new WomenGravidaPreAssistCheckModel();
                this.GrvFrCheck.RecordID = this.Model.RecordID;
                this.GrvFrCheck.IDCardNo = this.Model.IDCardNo;
                this.GrvFrCheck.BloodType = this.Model.BloodType;
                this.GrvFrCheck.RH = this.Model.RH;
                this.GrvFrCheck.CreatedBy = this.GrvFirst.CreatedBy;
                this.GrvFrCheck.CreatedDate = new DateTime?(DateTime.Today);
            }
            else
            {
                this.GrvFrCheck = new WomenGravidaPreAssistCheckBLL().GetModel(this.Model.IDCardNo);
                this.GrvFirst.LastUpdateBy = this.GrvFirst.CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.GrvFirst.LastUpdateDate = new DateTime?(DateTime.Today);
                this.GrvFrCheck.BloodType = this.Model.BloodType;
                this.GrvFrCheck.RH = this.Model.RH;
                this.GrvFrCheck.LastUpdateBy = this.GrvFirst.LastUpdateBy;
                this.GrvFrCheck.LastUpdateDate = new DateTime?(DateTime.Today);
            }
            this.gravidaInfo = this.par_From.GravidaInfo;
            if (string.IsNullOrEmpty(this.GrvFirst.HusbandName))
            {
                this.GrvFirst.HusbandName = (this.gravidaInfo != null) ? this.gravidaInfo.HusbandName : "";
            }
            if (string.IsNullOrEmpty(this.GrvFirst.HusbandPhone))
            {
                this.GrvFirst.HusbandPhone = (this.gravidaInfo != null) ? this.gravidaInfo.HusbandPhone : "";
            }
            if ((!this.GrvFirst.HusbandAge.HasValue && (this.gravidaInfo != null)) && this.gravidaInfo.HusbandAge.HasValue)
            {
                this.GrvFirst.HusbandAge = new int?((int)this.gravidaInfo.HusbandAge.Value);
            }
            if (string.IsNullOrEmpty(this.GrvFirst.FollowUpDoctor))
            {
                this.GrvFirst.FollowUpDoctor = ConfigHelper.GetNode("doctorName");
            }
            this.bindingManager_GF = new SimpleBindingManager<WomenGravidaFirstVisitModel>(this.inputRanges_GF, this.inputrange_str_GF, this.GrvFirst);
            this.bindingManager_GFC = new SimpleBindingManager<WomenGravidaPreAssistCheckModel>(this.inputRanges_GFC, this.inputrange_str_GFC, this.GrvFrCheck);
            if (!this.GrvFirst.Weight.HasValue)
            {
                stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                if (devData.HasValue)
                {
                    this.GrvFirst.Weight = new decimal?(decimal.Parse(devData.value1));
                }
            }
            if (!this.GrvFrCheck.HB.HasValue)
            {
                stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "52", "血红蛋白");
                if (_result2.HasValue)
                {
                    this.GrvFrCheck.HB = new decimal?(decimal.Parse(_result2.value1));
                }
            }
            if (!this.GrvFirst.HBloodpressure.HasValue)
            {
                stru_result _result3 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20");
                if (_result3.HasValue)
                {
                    this.GrvFirst.HBloodpressure = new int?(int.Parse(_result3.value1));
                    this.GrvFirst.LBloodpressure = new int?(int.Parse(_result3.value2));
                }
            }
            if (string.IsNullOrEmpty(this.GrvFrCheck.PRO))
            {
                stru_result _result4 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "33");
                if (_result4.HasValue)
                {
                    this.GrvFrCheck.PRO = _result4.value6;
                    this.GrvFrCheck.GLU = _result4.value5;
                    this.GrvFrCheck.KET = _result4.value4;
                    this.GrvFrCheck.BLD = _result4.value2;
                    this.tbNiao.Text = string.Format("蛋白质{0}/葡萄糖{1}/酮体{2}/潜血{3}", new object[] { this.GrvFrCheck.PRO, this.GrvFrCheck.GLU, this.GrvFrCheck.KET, this.GrvFrCheck.BLD });
                }
            }
            else
            {
                this.tbNiao.Text = string.Format("蛋白质{0}/葡萄糖{1}/酮体{2}/潜血{3}", new object[] { this.GrvFrCheck.PRO, this.GrvFrCheck.GLU, this.GrvFrCheck.KET, this.GrvFrCheck.BLD });
            }
            if (!this.GrvFrCheck.FPGL.HasValue)
            {
                stru_result _result5 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "24");
                if (_result5.HasValue)
                {
                    this.GrvFrCheck.FPGL = !(_result5.value1 == ".0") ? new decimal?(decimal.Parse(_result5.value1)) : 0;
                }
            }
            this.srcData_fir = GlbTools.DeepCopy(this.GrvFirst);
            this.srcData_check = GlbTools.DeepCopy(this.GrvFrCheck);
        }

        private void InitSomeControl()
        {
            List<ItemDictonaryModel<string>> list = new List<ItemDictonaryModel<string>> {
                new ItemDictonaryModel<string>("Ⅰ度", "1"),
                new ItemDictonaryModel<string>("Ⅱ度", "2"),
                new ItemDictonaryModel<string>("Ⅲ度", "3"),
                new ItemDictonaryModel<string>("Ⅳ度", "4")
            };
            this.cbVaginCleaess.DisplayMember = "DISPLAYMEMBER";
            this.cbVaginCleaess.ValueMember = "VALUEMEMBER";
            this.cbVaginCleaess.DataSource = list;
            this.inputRanges_GF = new List<InputRangeDec>();
            this.inputRanges_GF.Add(new InputRangeDec("PregancyWeeks", 50M));
            this.inputRanges_GF.Add(new InputRangeDec("CustomerAge", 100M));
            this.inputRanges_GF.Add(new InputRangeDec("HusbandAge", 10000M));
            this.inputRanges_GF.Add(new InputRangeDec("PregancyCount", 50M));
            this.inputRanges_GF.Add(new InputRangeDec("NatrualChildBirthCount", 50M));
            this.inputRanges_GF.Add(new InputRangeDec("CaeSareanCount", 50M));
            this.inputRanges_GF.Add(new InputRangeDec("Height", 300M));
            this.inputRanges_GF.Add(new InputRangeDec("Weight", 500M));
            this.inputRanges_GF.Add(new InputRangeDec("BMI", 100M));
            this.inputRanges_GF.Add(new InputRangeDec("HBloodpressure", 500M));
            this.inputRanges_GF.Add(new InputRangeDec("LBloodpressure", 500M));
            this.inputrange_str_GF = new List<InputRangeStr>();
            this.inputrange_str_GF.Add(new InputRangeStr("CustomerHistoryEx", 30));
            this.inputrange_str_GF.Add(new InputRangeStr("FamilyHistoryEx", 100));
            this.inputrange_str_GF.Add(new InputRangeStr("PersonalHistoryEx", 100));
            this.inputrange_str_GF.Add(new InputRangeStr("HusbandPhone", 15));
            this.inputrange_str_GF.Add(new InputRangeStr("AbortionInfo", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("Deadfetus", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("StillBirthInfo", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("NewBornDead", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("NewBornDefect", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("Heartex", 100));
            this.inputrange_str_GF.Add(new InputRangeStr("Lungex", 100));
            this.inputrange_str_GF.Add(new InputRangeStr("VulvaEx", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("VaginaEx", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("CervixuTeriex", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("CorpusEx", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("AttachEx", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("HealthZhiDaoOthers", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("ReferralReason", 500));
            this.inputrange_str_GF.Add(new InputRangeStr("ReferralOrg", 80));
            this.inputrange_str_GF.Add(new InputRangeStr("GynecologyHistoryEx", 200));
            this.inputrange_str_GF.Add(new InputRangeStr("OverAlassessmentEx", 200));
            this.inputRanges_GFC = new List<InputRangeDec>();
            this.inputRanges_GFC.Add(new InputRangeDec("HB", 1000M));
            this.inputRanges_GFC.Add(new InputRangeDec("WBC", 1000M));
            this.inputRanges_GFC.Add(new InputRangeDec("PlT", 1000M));
            this.inputRanges_GFC.Add(new InputRangeDec("FPGL", 1000M));
            this.inputRanges_GFC.Add(new InputRangeDec("SGPT", 1000M));
            this.inputRanges_GFC.Add(new InputRangeDec("GOT", 1000M));
            this.inputRanges_GFC.Add(new InputRangeDec("BP", 1000M));
            this.inputRanges_GFC.Add(new InputRangeDec("TBIL", 1000M));
            this.inputRanges_GFC.Add(new InputRangeDec("CB", 1000M));
            this.inputRanges_GFC.Add(new InputRangeDec("SCR", 1000M));
            this.inputRanges_GFC.Add(new InputRangeDec("BUN", 1000M));
            this.inputrange_str_GFC = new List<InputRangeStr>();
            this.inputrange_str_GFC.Add(new InputRangeStr("BloodOther", 100));
            this.inputrange_str_GFC.Add(new InputRangeStr("PRO", 10));
            this.inputrange_str_GFC.Add(new InputRangeStr("GLU", 10));
            this.inputrange_str_GFC.Add(new InputRangeStr("KET", 10));
            this.inputrange_str_GFC.Add(new InputRangeStr("BLD", 10));
            this.inputrange_str_GFC.Add(new InputRangeStr("UrineOthers", 100));
            this.inputrange_str_GFC.Add(new InputRangeStr("VaginalSecretionSothers", 100));
            this.inputrange_str_GFC.Add(new InputRangeStr("HBSAG", 8));
            this.inputrange_str_GFC.Add(new InputRangeStr("HBSAB", 8));
            this.inputrange_str_GFC.Add(new InputRangeStr("HBEAG", 8));
            this.inputrange_str_GFC.Add(new InputRangeStr("HBEAB", 8));
            this.inputrange_str_GFC.Add(new InputRangeStr("HBCAB", 8));
            this.inputrange_str_GFC.Add(new InputRangeStr("BCHAO", 200));
        }

        public void NotisfyChildStatus()
        {
        }

        private void rdLastMHave_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdLastMHave.Checked)
            {
                this.dtpLastMenstruation.Enabled = true;
            }
        }

        private void rdLastMNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdLastMNo.Checked)
            {
                this.dtpLastMenstruation.Value = DateTime.Today;
                this.dtpLastMenstruation.Enabled = false;
            }
        }

        private void rdZhuanzhenHave_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdZhuanzhenHave.Checked)
            {
                this.tbZhuanzhenKs.ReadOnly = false;
                this.tbZhuanzhenResult.ReadOnly = false;
                this.txtReferralContacts.ReadOnly = false;
                this.txtReferralContactsTel.ReadOnly = false;
                this.panel36.Enabled = true;
            }
        }

        private void rdZhuanzhenNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdZhuanzhenNo.Checked)
            {
                this.tbZhuanzhenResult.Text = "";
                this.tbZhuanzhenKs.Text = "";
                this.txtReferralContacts.Clear();
                this.txtReferralContactsTel.Clear();
                this.rddw.Checked = false;
                this.rdwdw.Checked = false;
                this.tbZhuanzhenResult.ReadOnly = true;
                this.tbZhuanzhenKs.ReadOnly = true;
                this.txtReferralContacts.ReadOnly = true;
                this.txtReferralContactsTel.ReadOnly = true;
                this.panel36.Enabled = false;
            }
        }

        public bool SaveModelToDB()
        {
            if (GlbTools.IsChanged(this.srcData_fir, this.GrvFirst, new string[] { "NextfollowupDate", "Referral", "HIV", "LUES", "LastMenStruation", "LastMenStruationDate", "ExpectedDueDate", "RecordDate" }) || GlbTools.IsChanged(this.srcData_check, this.GrvFrCheck, new string[0]))
            {              

                WomenGravidaFirstVisitBLL gravida_firstfollowup = new WomenGravidaFirstVisitBLL();
                if (gravida_firstfollowup.Exists(this.GrvFirst.ID))
                {
                    gravida_firstfollowup.Update(this.GrvFirst);
                }
                else
                {
                    gravida_firstfollowup.Add(this.GrvFirst);
                }
                WomenGravidaPreAssistCheckBLL gravida_pre_assistcheck = new WomenGravidaPreAssistCheckBLL();
                if (gravida_pre_assistcheck.Exists(this.GrvFrCheck.ID))
                {
                    gravida_pre_assistcheck.Update(this.GrvFrCheck);
                }
                else
                {
                    gravida_pre_assistcheck.Add(this.GrvFrCheck);
                }
            }
            return true;
        }

        private void SetPanel22Scrol(int p_top)
        {
            Action<int> method = new Action<int>(this.SetPanel22Scrol);
            int num = this.panel6.VerticalScroll.Value + p_top;
            if (this.panel6.InvokeRequired)
            {
                this.panel6.Invoke(method, new object[] { p_top * 2 });
            }
            else if ((num <= this.panel6.VerticalScroll.Maximum) && (num >= this.panel6.VerticalScroll.Minimum))
            {
                this.panel6.VerticalScroll.Value = num;
                this.lbInfo.Text = this.panel6.VerticalScroll.Value.ToString();
            }
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
            this.GrvFirst.RecordDate = new DateTime?(this.dtpTypeDate.Value.Date);
            if (this.rdLastMNo.Checked)
            {
                this.GrvFirst.LastMenStruation = "0";
                this.GrvFirst.LastMenStruationDate = null;
            }
            this.GrvFirst.ExpectedDueDate = new DateTime?(this.dtpExpectedDate.Value);
            if (this.rdLastMHave.Checked)
            {
                this.GrvFirst.LastMenStruation = "1";
                this.GrvFirst.LastMenStruationDate = new DateTime?(this.dtpLastMenstruation.Value.Date);
            }
            if (this.rdMeidYin.Checked)
            {
                this.GrvFrCheck.LUES = "1";
            }
            if (this.rdMeidYang.Checked)
            {
                this.GrvFrCheck.LUES = "2";
            }
            if (this.rdHIVYin.Checked)
            {
                this.GrvFrCheck.HIV = "1";
            }
            if (this.rdHIVYang.Checked)
            {
                this.GrvFrCheck.HIV = "2";
            }
            if (this.rdZhuanzhenNo.Checked)
            {
                this.GrvFirst.Referral = "1";
            }
            if (this.rdZhuanzhenHave.Checked)
            {
                this.GrvFirst.Referral = "2";
            }
            if (this.rddw.Checked)
            {
                this.GrvFirst.ReferralResult = "1";
            }
            else if (this.rdwdw.Checked)
            {
                this.GrvFirst.ReferralResult = "2";
            }
            this.GrvFirst.NextfollowupDate = new DateTime?(this.dtpNext.Value.Date);
        }

        public bool EveryThingIsOk { get; set; }

        private WomenGravidaBaseInfoModel gravidaInfo { get; set; }

        private WomenGravidaFirstVisitModel GrvFirst { get; set; }

        private WomenGravidaPreAssistCheckModel GrvFrCheck { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public object srcData_check { get; set; }

        public object srcData_fir { get; set; }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_PrenatalS_1", picSignYs);
        }

        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_PrenatalS_1_Doc", picSignYs);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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
            Sign("_PrenatalS_1_Doc", picSignYs);
        }

        private void picSignJs_Click(object sender, EventArgs e)
        {
            Sign("_PrenatalS_1", picSignJs);
        }
    }
}

