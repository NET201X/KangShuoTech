using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace HealthHouse
{
    using KangShuoTech.Utilities.Common;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    public class HealthOldMedEX : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private ManyCheckboxs<HealthHouseMedicineResultModel> advis_pinghe;
        private ManyCheckboxs<HealthHouseMedicineResultModel> advis_qixu;
        private ManyCheckboxs<HealthHouseMedicineResultModel> advis_qiyu;
        private ManyCheckboxs<HealthHouseMedicineResultModel> advis_shire;
        private ManyCheckboxs<HealthHouseMedicineResultModel> advis_tanshi;
        private ManyCheckboxs<HealthHouseMedicineResultModel> advis_tebing;
        private ManyCheckboxs<HealthHouseMedicineResultModel> advis_xueyu;
        private ManyCheckboxs<HealthHouseMedicineResultModel> advis_yang;
        private ManyCheckboxs<HealthHouseMedicineResultModel> advis_yin;
        private SimpleBindingManager<HealthHouseMedicineResultModel> bindingManager;
        private Button btnResult;
        private Button btnSave;
        private CheckBox ckPinghe1;
        private CheckBox ckPinghe2;
        private CheckBox ckPinghe3;
        private CheckBox ckPinghe4;
        private CheckBox ckPinghe5;
        private CheckBox ckPingheOth;
        private CheckBox ckQixu1;
        private CheckBox ckQixu2;
        private CheckBox ckQixu3;
        private CheckBox ckQixu4;
        private CheckBox ckQixu5;
        private CheckBox ckQixuOth;
        private CheckBox ckQiyu1;
        private CheckBox ckQiyu2;
        private CheckBox ckQiyu3;
        private CheckBox ckQiyu4;
        private CheckBox ckQiyu5;
        private CheckBox ckQiyuOth;
        private CheckBox ckShire1;
        private CheckBox ckShire2;
        private CheckBox ckShire3;
        private CheckBox ckShire4;
        private CheckBox ckShire5;
        private CheckBox ckShireOth;
        private CheckBox ckTans1;
        private CheckBox ckTans1Oth;
        private CheckBox ckTans2;
        private CheckBox ckTans3;
        private CheckBox ckTans4;
        private CheckBox ckTans5;
        private CheckBox ckTebing1;
        private CheckBox ckTebing2;
        private CheckBox ckTebing3;
        private CheckBox ckTebing4;
        private CheckBox ckTebing5;
        private CheckBox ckTebingOth;
        private CheckBox ckXueyu1;
        private CheckBox ckXueyu2;
        private CheckBox ckXueyu3;
        private CheckBox ckXueyu4;
        private CheckBox ckXueyu5;
        private CheckBox ckXueyuOth;
        private CheckBox ckYangxu1;
        private CheckBox ckYangxu2;
        private CheckBox ckYangxu3;
        private CheckBox ckYangxu4;
        private CheckBox ckYangxu5;
        private CheckBox ckYangxuOth;
        private CheckBox ckYinxu1;
        private CheckBox ckYinxu2;
        private CheckBox ckYinxu3;
        private CheckBox ckYinxu4;
        private CheckBox ckYinxu5;
        private CheckBox ckYinxuOth;
        private IContainer components;
        private DataGridView dataGridView1;
        private DateTimePicker dtpTypeDate;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private ScoreJudge judge_qixu;
        private ScoreJudge judge_qiyu;
        private ScoreJudge judge_shire;
        private ScoreJudge judge_tanshi;
        private ScoreJudge judge_tebing;
        private List<ScoreJudge> judge_tizhiAll;
        private ScoreJudge judge_xueyu;
        private ScoreJudge judge_yang;
        private ScoreJudge judge_yin;
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
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        public HealthHouseMedicineCnModel MedCn;
        public HealthHouseMedicineResultModel MedResult;
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
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        public HealthHouseMediPhyModel phy;
        private RadioButton rdPinghe_QYes;
        private RadioButton rdPinghe_Yes;
        private RadioButton rdQiXu_QYes;
        private RadioButton rdQiXu_Yes;
        private RadioButton rdQiyu_QYes;
        private RadioButton rdQiyu_Yes;
        private RadioButton rdShire_QYes;
        private RadioButton rdShire_Yes;
        private RadioButton rdTanshi_QYes;
        private RadioButton rdTanshi_Yes;
        private RadioButton rdTebing_QYes;
        private RadioButton rdTebing_Yes;
        private RadioButton rdXueyu_QYes;
        private RadioButton rdXueyu_Yes;
        private RadioButton rdYangxu_QYes;
        private RadioButton rdYangxu_Yes;
        private RadioButton rdYinxu_QYes;
        private RadioButton rdYinxu_Yes;
        private List<ChItems> s0Items;
        private List<ChItems> s1Items;
        private List<ChItems> s2Items;
        private List<ChItems> s3Items;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbDoctor;
        private TextBox tbPinghe;
        private TextBox tbPingheScore;
        private TextBox tbQixu;
        private TextBox tbQixuScore;
        private TextBox tbQiyu;
        private TextBox tbQiyuScore;
        private TextBox tbShire;
        private TextBox tbShireScore;
        private TextBox tbTanshi;
        private TextBox tbTanshiScore;
        private TextBox tbTebing;
        private TextBox tbTebingScore;
        private TextBox tbXueyu;
        private TextBox tbXueyuScore;
        private TextBox tbYangxu;
        private TextBox tbYangxuSorce;
        private TextBox tbYinxu;
        private TextBox tbYinxuScore;
        private List<ChItems> usualItems;
        private DataSet xmlDs;
        private bool MedResultFlage = false;
        private bool MedCnFlage = false;
        private Label label9;
        string community = ConfigHelper.GetNode("community");

        public HealthOldMedEX()
        {
            this.InitializeComponent();
            this.InitEveryOne();
            this.EveryThingIsOk = false;
        }

        public HealthOldMedEX(RecordsBaseInfoModel p_model)
        {
            this.InitializeComponent();
            this.InitEveryOne();
            this.EveryThingIsOk = false;
            this.Model = p_model;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            if (!this.panel1.Visible)
            {
                GlbTools.DatatableFillModel<HealthHouseMedicineCnModel>(this.MedCn, this.xmlDs.Tables[0]);
                this.MedResult.FaintScore = new decimal?(this.GetScore(this.MedCn.Tired, this.MedCn.Breath, this.MedCn.Voice, this.MedCn.Influenza));
                this.MedResult.YangsCore = new decimal?(this.GetScore(this.MedCn.FootHand, this.MedCn.Stomach, this.MedCn.Cold, this.MedCn.Coolfood));
                this.MedResult.YinScore = new decimal?(this.GetScore(this.MedCn.Eye, this.MedCn.Mouth, this.MedCn.Thirsty, this.MedCn.Defecate));
                this.MedResult.PhlegmdampScore = new decimal?(this.GetScore(this.MedCn.Weight, this.MedCn.Snore, this.MedCn.Abdomen, this.MedCn.Tongue));
                this.MedResult.MuggyScore = new decimal?(this.GetScore(this.MedCn.Greasy, this.MedCn.Eczema, this.MedCn.Smell, this.MedCn.Defecate));
                this.MedResult.BloodStasisScore = new decimal?(this.GetScore(this.MedCn.Skin, this.MedCn.Arms, this.MedCn.Spot, this.MedCn.Vein));
                this.MedResult.QiConstraintScore = new decimal?(this.GetScore(this.MedCn.Emotion, this.MedCn.Spirit, this.MedCn.Alone, this.MedCn.Fear));
                this.MedResult.CharacteristicScore = new decimal?(this.GetScore(this.MedCn.Nasal, this.MedCn.Allergy, this.MedCn.Urticaria, this.MedCn.Scratch));
                this.MedResult.MildScore = new decimal?(this.GetPinghe(this.MedCn.Energy, this.MedCn.Tired, this.MedCn.Voice, this.MedCn.Emotion, this.MedCn.Cold));
                this.bindingManager.UpdateControl();
                this.UpdateJudge();
                this.btnResult.Text = "查看问题项";
            }
            else
            {
                this.btnResult.Text = "查看结果";
            }
            this.panel1.Visible = !this.panel1.Visible;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.CheckErrorInput() == ChildFormStatus.NoErrorInput)
            {
                this.UpdataToModel();
                RecordsMediPhysDistBLL recordsMediPhysDistBLL = new RecordsMediPhysDistBLL();
                GlbTools.M1_TO_M2<HealthHouseMedicineResultModel, HealthHouseMediPhyModel>(this.MedResult, this.phy);
                base.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("错误", this.SaveDataInfo, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            if (((!this.advis_qixu.ErrorInput && !this.advis_pinghe.ErrorInput) && (!this.advis_qiyu.ErrorInput && !this.advis_shire.ErrorInput)) && ((!this.advis_tanshi.ErrorInput && !this.advis_tebing.ErrorInput) && ((!this.advis_xueyu.ErrorInput && !this.advis_yang.ErrorInput) && !this.advis_yin.ErrorInput)))
            {
                return ChildFormStatus.NoErrorInput;
            }
            return ChildFormStatus.HasErrorInput;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmOldMedEX_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
            new Thread(new ThreadStart(this.Get)).Start();
        }

        private void Get()
        {
            this.xmlDs = new DataSet();
            this.xmlDs.ReadXml(Application.StartupPath + @"\old_med.xml");
            this.UpDatagridview();
        }

        private DataGridViewComboBoxColumn GetCobColoums(string headtext, string mapingName, int width)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn
            {
                HeaderText = headtext
            };
            if (mapingName != "")
            {
                column.DataPropertyName = mapingName;
            }
            column.Width = width;
            column.DisplayMember = "DisplayMem";
            column.ValueMember = "ValueMem";
            return column;
        }

        private decimal GetPinghe(decimal? d1, decimal? d2, decimal? d3, decimal? d4, decimal? d5)
        {
            decimal num = new decimal(0);
            if (d1.HasValue)
            {
                num += d1.Value;
            }
            if (d2.HasValue)
            {
                num += 6M - d2.Value;
            }
            if (d3.HasValue)
            {
                num += 6M - d3.Value;
            }
            if (d4.HasValue)
            {
                num += 6M - d4.Value;
            }
            if (d5.HasValue)
            {
                num += 6M - d5.Value;
            }
            return num;
        }

        private decimal GetScore(decimal? d1, decimal? d2, decimal? d3, decimal? d4)
        {
            decimal num = new decimal(0);
            if (d1.HasValue)
            {
                num += d1.Value;
            }
            if (d2.HasValue)
            {
                num += d2.Value;
            }
            if (d3.HasValue)
            {
                num += d3.Value;
            }
            if (d4.HasValue)
            {
                num += d4.Value;
            }
            return num;
        }

        private DataGridViewTextBoxColumn GetTextColums(string headtext, string mapingName, int width)
        {
            return new DataGridViewTextBoxColumn { HeaderText = headtext, DataPropertyName = mapingName, Width = width, ReadOnly = true };
        }

        private void InitEveryOne()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.Add(this.GetTextColums("请根据近一年的体验和感觉，回答以下问题。", "content", 750));
            this.dataGridView1.Columns.Add(this.GetCobColoums("选择", "result", 250));
            this.usualItems = new List<ChItems>();
            this.usualItems.Add(new ChItems("1.没有(根本不/从来没有)", "1"));
            this.usualItems.Add(new ChItems("2.很少(有一点/偶尔)", "2"));
            this.usualItems.Add(new ChItems("3.有时(有些/少数时间)", "3"));
            this.usualItems.Add(new ChItems("4.经常(相当/多数时间)", "4"));
            this.usualItems.Add(new ChItems("5.经常(非常/每天)", "5"));
            this.s0Items = new List<ChItems>();
            this.s0Items.Add(new ChItems("1.(BMI＜24)", "1"));
            this.s0Items.Add(new ChItems("2.(24≤BMI＜25)", "2"));
            this.s0Items.Add(new ChItems("3.(25≤BMI＜26)", "3"));
            this.s0Items.Add(new ChItems("4.(26≤BMI＜28)", "4"));
            this.s0Items.Add(new ChItems("5.(BMI≥28)", "5"));
            this.s1Items = new List<ChItems>();
            this.s1Items.Add(new ChItems("1.一年＜2次", "1"));
            this.s1Items.Add(new ChItems("2.一年感冒2-4次", "2"));
            this.s1Items.Add(new ChItems("3.一年感冒5-6次", "3"));
            this.s1Items.Add(new ChItems("4.一年8次以上", "4"));
            this.s1Items.Add(new ChItems("5.几乎每月都感冒", "5"));
            this.s2Items = new List<ChItems>();
            this.s2Items.Add(new ChItems("1.从来没有", "1"));
            this.s2Items.Add(new ChItems("2.一年1、2次", "2"));
            this.s2Items.Add(new ChItems("3.一年3、4次", "3"));
            this.s2Items.Add(new ChItems("4.一年5、6次", "4"));
            this.s2Items.Add(new ChItems("5.每次遇到上述原因都过敏", "5"));
            this.s3Items = new List<ChItems>();
            this.s3Items.Add(new ChItems("1.（腹围<80cm，相当于2.4尺）", "1"));
            this.s3Items.Add(new ChItems("2.(腹围80-85cm，2.4-2.55尺)", "2"));
            this.s3Items.Add(new ChItems("3.(腹围86-90cm，2.56-2.7尺)", "3"));
            this.s3Items.Add(new ChItems("4.(腹围91-105cm，2.71-3.15尺)", "4"));
            this.s3Items.Add(new ChItems("5.（腹围>105cm或3.15尺）", "5"));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("MildAdvising", 0x12));
            this.inputrange_str.Add(new InputRangeStr("FaintAdvising", 0x12));
            this.inputrange_str.Add(new InputRangeStr("YangAdvising", 0x12));
            this.inputrange_str.Add(new InputRangeStr("YinAdvising", 0x12));
            this.inputrange_str.Add(new InputRangeStr("PhlegmdampAdvising", 0x12));
            this.inputrange_str.Add(new InputRangeStr("MuggyAdvising", 0x12));
            this.inputrange_str.Add(new InputRangeStr("BloodStasisAdvising", 0x12));
            this.inputrange_str.Add(new InputRangeStr("QiconstraintAdvising", 0x12));
            this.inputrange_str.Add(new InputRangeStr("CharacteristicAdvising", 0x12));
            this.inputrange_str.Add(new InputRangeStr("MildAdvisingEx", 200));
            this.inputrange_str.Add(new InputRangeStr("FaintAdvisingEx", 200));
            this.inputrange_str.Add(new InputRangeStr("YangadvisingEx", 200));
            this.inputrange_str.Add(new InputRangeStr("YinAdvisingEx", 200));
            this.inputrange_str.Add(new InputRangeStr("PhlegmdampAdvisingEx", 200));
            this.inputrange_str.Add(new InputRangeStr("MuggyAdvisingEx", 200));
            this.inputrange_str.Add(new InputRangeStr("BloodStasisAdvisingEx", 200));
            this.inputrange_str.Add(new InputRangeStr("QiconstraintAdvisingEx", 200));
            this.inputrange_str.Add(new InputRangeStr("CharacteristicAdvisingEx", 200));
            this.inputRanges = new List<InputRangeDec>();
        }

        public void InitEveryThing()
        {
            if (this.MedCn == null)
            {
                this.MedCnFlage = true;
                this.MedCn = new HealthHouseMedicineCnModel();
                this.MedCn.IDCardNo = this.Model.IDCardNo;
            }
          
            if (this.MedResult == null)
            {
                this.MedResultFlage = true;
                this.MedResult = new HealthHouseMedicineResultModel();
                this.MedResult.IDCardNo = this.Model.IDCardNo;
            }
            if (HealthModel == null)
            {
                this.HealthModel = new HealthHouseModel();
            }
            if (string.IsNullOrEmpty(this.MedCn.FollowUpDoctor))
            {
                this.tbDoctor.Text = this.Model.Doctor;
            }
            else
            {
                this.tbDoctor.Text = this.MedCn.FollowUpDoctor;
            }

            if (this.MedCn.RecordDate.HasValue)
            {
                this.dtpTypeDate.Value = Convert.ToDateTime(this.MedCn.RecordDate);
            }

            this.bindingManager = new SimpleBindingManager<HealthHouseMedicineResultModel>(this.inputRanges, this.inputrange_str, this.MedResult);
            this.bindingManager.SimpleBinding(this.tbQixuScore, "FaintScore", true);
            this.bindingManager.SimpleBinding(this.tbYangxuSorce, "YangsCore", true);
            this.bindingManager.SimpleBinding(this.tbYinxuScore, "YinsCore", true);
            this.bindingManager.SimpleBinding(this.tbTanshiScore, "PhlegmdampScore", true);
            this.bindingManager.SimpleBinding(this.tbShireScore, "MuggyScore", true);
            this.bindingManager.SimpleBinding(this.tbXueyuScore, "BloodStasisScore", true);
            this.bindingManager.SimpleBinding(this.tbQiyuScore, "QiConstraintScore", true);
            this.bindingManager.SimpleBinding(this.tbTebingScore, "CharacteristicScore", true);
            this.bindingManager.SimpleBinding(this.tbPingheScore, "MildScore", true);
            this.judge_qixu = new ScoreJudge(this.MedResult, "FaintScore", "Faint", this.rdQiXu_Yes, this.rdQiXu_QYes);
            this.judge_yang = new ScoreJudge(this.MedResult, "YangsCore", "Yang", this.rdYangxu_Yes, this.rdYangxu_QYes);
            this.judge_yin = new ScoreJudge(this.MedResult, "YinScore", "Yin", this.rdYinxu_Yes, this.rdYinxu_QYes);
            this.judge_tanshi = new ScoreJudge(this.MedResult, "PhlegmdampScore", "PhlegmDamp", this.rdTanshi_Yes, this.rdTanshi_QYes);
            this.judge_shire = new ScoreJudge(this.MedResult, "MuggyScore", "Muggy", this.rdShire_Yes, this.rdShire_QYes);
            this.judge_xueyu = new ScoreJudge(this.MedResult, "BloodStasisScore", "BloodStasis", this.rdXueyu_Yes, this.rdXueyu_QYes);
            this.judge_qiyu = new ScoreJudge(this.MedResult, "QiConstraintScore", "QiConstraint", this.rdQiyu_Yes, this.rdQiyu_QYes);
            this.judge_tebing = new ScoreJudge(this.MedResult, "CharacteristicScore", "Characteristic", this.rdTebing_Yes, this.rdTebing_QYes);
            this.judge_tizhiAll = new List<ScoreJudge>();
            this.judge_tizhiAll.AddRange((IEnumerable<ScoreJudge>)new ScoreJudge[] { this.judge_qixu, this.judge_yang, this.judge_yin, this.judge_tanshi, this.judge_shire, this.judge_xueyu, this.judge_qiyu, this.judge_tebing });
            this.advis_qixu = new ManyCheckboxs<HealthHouseMedicineResultModel>(this.MedResult);
            this.advis_qixu.AddCk(new CheckBox[] { this.ckQixu1, this.ckQixu2, this.ckQixu3, this.ckQixu4, this.ckQixu5 });
            this.advis_qixu.AddCk(this.ckQixuOth, this.tbQixu);
            this.advis_qixu.BindingProperty("FaintAdvising", "FaintAdvisingEx");
            this.advis_yang = new ManyCheckboxs<HealthHouseMedicineResultModel>(this.MedResult);
            this.advis_yang.AddCk(new CheckBox[] { this.ckYangxu1, this.ckYangxu2, this.ckYangxu3, this.ckYangxu4, this.ckYangxu5 });
            this.advis_yang.AddCk(this.ckYangxuOth, this.tbYangxu);
            this.advis_yang.BindingProperty("YangAdvising", "YangadvisingEx");
            this.advis_yin = new ManyCheckboxs<HealthHouseMedicineResultModel>(this.MedResult);
            this.advis_yin.AddCk(new CheckBox[] { this.ckYinxu1, this.ckYinxu2, this.ckYinxu3, this.ckYinxu4, this.ckYinxu5 });
            this.advis_yin.AddCk(this.ckYinxuOth, this.tbYinxu);
            this.advis_yin.BindingProperty("YinAdvising", "YinAdvisingEx");
            this.advis_tanshi = new ManyCheckboxs<HealthHouseMedicineResultModel>(this.MedResult);
            this.advis_tanshi.AddCk(new CheckBox[] { this.ckTans1, this.ckTans2, this.ckTans3, this.ckTans4, this.ckTans5 });
            this.advis_tanshi.AddCk(this.ckTans1Oth, this.tbTanshi);
            this.advis_tanshi.BindingProperty("PhlegmdampAdvising", "PhlegmdampAdvisingEx");
            this.advis_shire = new ManyCheckboxs<HealthHouseMedicineResultModel>(this.MedResult);
            this.advis_shire.AddCk(new CheckBox[] { this.ckShire1, this.ckShire2, this.ckShire3, this.ckShire4, this.ckShire5 });
            this.advis_shire.AddCk(this.ckShireOth, this.tbShire);
            this.advis_shire.BindingProperty("MuggyAdvising", "MuggyAdvisingEx");
            this.advis_xueyu = new ManyCheckboxs<HealthHouseMedicineResultModel>(this.MedResult);
            this.advis_xueyu.AddCk(new CheckBox[] { this.ckXueyu1, this.ckXueyu2, this.ckXueyu3, this.ckXueyu4, this.ckXueyu5 });
            this.advis_xueyu.AddCk(this.ckXueyuOth, this.tbXueyu);
            this.advis_xueyu.BindingProperty("BloodStasisAdvising", "BloodStasisAdvisingEx");
            this.advis_qiyu = new ManyCheckboxs<HealthHouseMedicineResultModel>(this.MedResult);
            this.advis_qiyu.AddCk(new CheckBox[] { this.ckQiyu1, this.ckQiyu2, this.ckQiyu3, this.ckQiyu4, this.ckQiyu5 });
            this.advis_qiyu.AddCk(this.ckQiyuOth, this.tbQiyu);
            this.advis_qiyu.BindingProperty("QiconstraintAdvising", "QiconstraintAdvisingEx");
            this.advis_tebing = new ManyCheckboxs<HealthHouseMedicineResultModel>(this.MedResult);
            this.advis_tebing.AddCk(new CheckBox[] { this.ckTebing1, this.ckTebing2, this.ckTebing3, this.ckTebing4, this.ckTebing5 });
            this.advis_tebing.AddCk(this.ckTebingOth, this.tbTebing);
            this.advis_tebing.BindingProperty("CharacteristicAdvising", "CharacteristicAdvisingEx");
            this.advis_pinghe = new ManyCheckboxs<HealthHouseMedicineResultModel>(this.MedResult);
            this.advis_pinghe.AddCk(new CheckBox[] { this.ckPinghe1, this.ckPinghe2, this.ckPinghe3, this.ckPinghe4, this.ckPinghe5 });
            this.advis_pinghe.AddCk(this.ckPingheOth, this.tbPinghe);
            this.advis_pinghe.BindingProperty("MildAdvising", "MildAdvisingEx");
            this.EveryThingIsOk = true;
        }

        private void InitializeComponent()
        {
            this.btnResult = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dtpTypeDate = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.rdPinghe_QYes = new System.Windows.Forms.RadioButton();
            this.rdPinghe_Yes = new System.Windows.Forms.RadioButton();
            this.tbPingheScore = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rdTebing_QYes = new System.Windows.Forms.RadioButton();
            this.rdTebing_Yes = new System.Windows.Forms.RadioButton();
            this.tbTebingScore = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdQiyu_QYes = new System.Windows.Forms.RadioButton();
            this.rdQiyu_Yes = new System.Windows.Forms.RadioButton();
            this.tbQiyuScore = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdXueyu_QYes = new System.Windows.Forms.RadioButton();
            this.rdXueyu_Yes = new System.Windows.Forms.RadioButton();
            this.tbXueyuScore = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdShire_QYes = new System.Windows.Forms.RadioButton();
            this.rdShire_Yes = new System.Windows.Forms.RadioButton();
            this.tbShireScore = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdTanshi_QYes = new System.Windows.Forms.RadioButton();
            this.rdTanshi_Yes = new System.Windows.Forms.RadioButton();
            this.tbTanshiScore = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdYinxu_QYes = new System.Windows.Forms.RadioButton();
            this.rdYinxu_Yes = new System.Windows.Forms.RadioButton();
            this.tbYinxuScore = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdYangxu_QYes = new System.Windows.Forms.RadioButton();
            this.rdYangxu_Yes = new System.Windows.Forms.RadioButton();
            this.tbYangxuSorce = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.tbPinghe = new System.Windows.Forms.TextBox();
            this.ckPingheOth = new System.Windows.Forms.CheckBox();
            this.ckPinghe5 = new System.Windows.Forms.CheckBox();
            this.ckPinghe4 = new System.Windows.Forms.CheckBox();
            this.ckPinghe3 = new System.Windows.Forms.CheckBox();
            this.ckPinghe2 = new System.Windows.Forms.CheckBox();
            this.ckPinghe1 = new System.Windows.Forms.CheckBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.tbTebing = new System.Windows.Forms.TextBox();
            this.ckTebingOth = new System.Windows.Forms.CheckBox();
            this.ckTebing5 = new System.Windows.Forms.CheckBox();
            this.ckTebing4 = new System.Windows.Forms.CheckBox();
            this.ckTebing3 = new System.Windows.Forms.CheckBox();
            this.ckTebing2 = new System.Windows.Forms.CheckBox();
            this.ckTebing1 = new System.Windows.Forms.CheckBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.tbQiyu = new System.Windows.Forms.TextBox();
            this.ckQiyuOth = new System.Windows.Forms.CheckBox();
            this.ckQiyu5 = new System.Windows.Forms.CheckBox();
            this.ckQiyu4 = new System.Windows.Forms.CheckBox();
            this.ckQiyu3 = new System.Windows.Forms.CheckBox();
            this.ckQiyu2 = new System.Windows.Forms.CheckBox();
            this.ckQiyu1 = new System.Windows.Forms.CheckBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.tbXueyu = new System.Windows.Forms.TextBox();
            this.ckXueyuOth = new System.Windows.Forms.CheckBox();
            this.ckXueyu5 = new System.Windows.Forms.CheckBox();
            this.ckXueyu4 = new System.Windows.Forms.CheckBox();
            this.ckXueyu3 = new System.Windows.Forms.CheckBox();
            this.ckXueyu2 = new System.Windows.Forms.CheckBox();
            this.ckXueyu1 = new System.Windows.Forms.CheckBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.tbShire = new System.Windows.Forms.TextBox();
            this.ckShireOth = new System.Windows.Forms.CheckBox();
            this.ckShire5 = new System.Windows.Forms.CheckBox();
            this.ckShire4 = new System.Windows.Forms.CheckBox();
            this.ckShire3 = new System.Windows.Forms.CheckBox();
            this.ckShire2 = new System.Windows.Forms.CheckBox();
            this.ckShire1 = new System.Windows.Forms.CheckBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.tbTanshi = new System.Windows.Forms.TextBox();
            this.ckTans1Oth = new System.Windows.Forms.CheckBox();
            this.ckTans5 = new System.Windows.Forms.CheckBox();
            this.ckTans4 = new System.Windows.Forms.CheckBox();
            this.ckTans3 = new System.Windows.Forms.CheckBox();
            this.ckTans2 = new System.Windows.Forms.CheckBox();
            this.ckTans1 = new System.Windows.Forms.CheckBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.tbYinxu = new System.Windows.Forms.TextBox();
            this.ckYinxuOth = new System.Windows.Forms.CheckBox();
            this.ckYinxu5 = new System.Windows.Forms.CheckBox();
            this.ckYinxu4 = new System.Windows.Forms.CheckBox();
            this.ckYinxu3 = new System.Windows.Forms.CheckBox();
            this.ckYinxu2 = new System.Windows.Forms.CheckBox();
            this.ckYinxu1 = new System.Windows.Forms.CheckBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tbYangxu = new System.Windows.Forms.TextBox();
            this.ckYangxuOth = new System.Windows.Forms.CheckBox();
            this.ckYangxu5 = new System.Windows.Forms.CheckBox();
            this.ckYangxu4 = new System.Windows.Forms.CheckBox();
            this.ckYangxu3 = new System.Windows.Forms.CheckBox();
            this.ckYangxu2 = new System.Windows.Forms.CheckBox();
            this.ckYangxu1 = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rdQiXu_QYes = new System.Windows.Forms.RadioButton();
            this.rdQiXu_Yes = new System.Windows.Forms.RadioButton();
            this.tbQixuScore = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.tbQixu = new System.Windows.Forms.TextBox();
            this.ckQixuOth = new System.Windows.Forms.CheckBox();
            this.ckQixu5 = new System.Windows.Forms.CheckBox();
            this.ckQixu4 = new System.Windows.Forms.CheckBox();
            this.ckQixu3 = new System.Windows.Forms.CheckBox();
            this.ckQixu2 = new System.Windows.Forms.CheckBox();
            this.ckQixu1 = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel19.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(597, 620);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(121, 43);
            this.btnResult.TabIndex = 2;
            this.btnResult.Text = "计算结果";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(177, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1047, 550);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.tbDoctor);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.dtpTypeDate);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1425, 614);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // tbDoctor
            // 
            this.tbDoctor.Location = new System.Drawing.Point(991, 518);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.ReadOnly = true;
            this.tbDoctor.Size = new System.Drawing.Size(258, 26);
            this.tbDoctor.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(904, 525);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 16);
            this.label23.TabIndex = 9;
            this.label23.Text = "医生签名:";
            // 
            // dtpTypeDate
            // 
            this.dtpTypeDate.Location = new System.Drawing.Point(634, 518);
            this.dtpTypeDate.Name = "dtpTypeDate";
            this.dtpTypeDate.Size = new System.Drawing.Size(228, 26);
            this.dtpTypeDate.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(547, 525);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 16);
            this.label22.TabIndex = 7;
            this.label22.Text = "填表日期:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel18, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel17, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel16, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel15, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel13, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label21, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel19, 1, 2);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(144, 54);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1105, 451);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(1021, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 19);
            this.label9.TabIndex = 22;
            this.label9.Text = "平和质";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.rdPinghe_QYes);
            this.panel9.Controls.Add(this.rdPinghe_Yes);
            this.panel9.Controls.Add(this.tbPingheScore);
            this.panel9.Controls.Add(this.label20);
            this.panel9.Location = new System.Drawing.Point(996, 59);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(109, 103);
            this.panel9.TabIndex = 17;
            // 
            // rdPinghe_QYes
            // 
            this.rdPinghe_QYes.AutoSize = true;
            this.rdPinghe_QYes.Enabled = false;
            this.rdPinghe_QYes.Location = new System.Drawing.Point(7, 66);
            this.rdPinghe_QYes.Name = "rdPinghe_QYes";
            this.rdPinghe_QYes.Size = new System.Drawing.Size(74, 20);
            this.rdPinghe_QYes.TabIndex = 3;
            this.rdPinghe_QYes.TabStop = true;
            this.rdPinghe_QYes.Text = "基本是";
            this.rdPinghe_QYes.UseVisualStyleBackColor = true;
            // 
            // rdPinghe_Yes
            // 
            this.rdPinghe_Yes.AutoSize = true;
            this.rdPinghe_Yes.Enabled = false;
            this.rdPinghe_Yes.Location = new System.Drawing.Point(7, 39);
            this.rdPinghe_Yes.Name = "rdPinghe_Yes";
            this.rdPinghe_Yes.Size = new System.Drawing.Size(42, 20);
            this.rdPinghe_Yes.TabIndex = 2;
            this.rdPinghe_Yes.TabStop = true;
            this.rdPinghe_Yes.Text = "是";
            this.rdPinghe_Yes.UseVisualStyleBackColor = true;
            // 
            // tbPingheScore
            // 
            this.tbPingheScore.Location = new System.Drawing.Point(50, 6);
            this.tbPingheScore.Name = "tbPingheScore";
            this.tbPingheScore.ReadOnly = true;
            this.tbPingheScore.Size = new System.Drawing.Size(50, 26);
            this.tbPingheScore.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "得分:";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rdTebing_QYes);
            this.panel8.Controls.Add(this.rdTebing_Yes);
            this.panel8.Controls.Add(this.tbTebingScore);
            this.panel8.Controls.Add(this.label19);
            this.panel8.Location = new System.Drawing.Point(886, 59);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(109, 103);
            this.panel8.TabIndex = 15;
            // 
            // rdTebing_QYes
            // 
            this.rdTebing_QYes.AutoSize = true;
            this.rdTebing_QYes.Enabled = false;
            this.rdTebing_QYes.Location = new System.Drawing.Point(7, 66);
            this.rdTebing_QYes.Name = "rdTebing_QYes";
            this.rdTebing_QYes.Size = new System.Drawing.Size(74, 20);
            this.rdTebing_QYes.TabIndex = 3;
            this.rdTebing_QYes.TabStop = true;
            this.rdTebing_QYes.Text = "倾向是";
            this.rdTebing_QYes.UseVisualStyleBackColor = true;
            // 
            // rdTebing_Yes
            // 
            this.rdTebing_Yes.AutoSize = true;
            this.rdTebing_Yes.Enabled = false;
            this.rdTebing_Yes.Location = new System.Drawing.Point(7, 39);
            this.rdTebing_Yes.Name = "rdTebing_Yes";
            this.rdTebing_Yes.Size = new System.Drawing.Size(42, 20);
            this.rdTebing_Yes.TabIndex = 2;
            this.rdTebing_Yes.TabStop = true;
            this.rdTebing_Yes.Text = "是";
            this.rdTebing_Yes.UseVisualStyleBackColor = true;
            // 
            // tbTebingScore
            // 
            this.tbTebingScore.Location = new System.Drawing.Point(50, 6);
            this.tbTebingScore.Name = "tbTebingScore";
            this.tbTebingScore.ReadOnly = true;
            this.tbTebingScore.Size = new System.Drawing.Size(50, 26);
            this.tbTebingScore.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 16);
            this.label19.TabIndex = 0;
            this.label19.Text = "得分:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.rdQiyu_QYes);
            this.panel7.Controls.Add(this.rdQiyu_Yes);
            this.panel7.Controls.Add(this.tbQiyuScore);
            this.panel7.Controls.Add(this.label18);
            this.panel7.Location = new System.Drawing.Point(776, 59);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(109, 103);
            this.panel7.TabIndex = 13;
            // 
            // rdQiyu_QYes
            // 
            this.rdQiyu_QYes.AutoSize = true;
            this.rdQiyu_QYes.Enabled = false;
            this.rdQiyu_QYes.Location = new System.Drawing.Point(7, 66);
            this.rdQiyu_QYes.Name = "rdQiyu_QYes";
            this.rdQiyu_QYes.Size = new System.Drawing.Size(74, 20);
            this.rdQiyu_QYes.TabIndex = 3;
            this.rdQiyu_QYes.TabStop = true;
            this.rdQiyu_QYes.Text = "倾向是";
            this.rdQiyu_QYes.UseVisualStyleBackColor = true;
            // 
            // rdQiyu_Yes
            // 
            this.rdQiyu_Yes.AutoSize = true;
            this.rdQiyu_Yes.Enabled = false;
            this.rdQiyu_Yes.Location = new System.Drawing.Point(7, 39);
            this.rdQiyu_Yes.Name = "rdQiyu_Yes";
            this.rdQiyu_Yes.Size = new System.Drawing.Size(42, 20);
            this.rdQiyu_Yes.TabIndex = 2;
            this.rdQiyu_Yes.TabStop = true;
            this.rdQiyu_Yes.Text = "是";
            this.rdQiyu_Yes.UseVisualStyleBackColor = true;
            // 
            // tbQiyuScore
            // 
            this.tbQiyuScore.Location = new System.Drawing.Point(50, 6);
            this.tbQiyuScore.Name = "tbQiyuScore";
            this.tbQiyuScore.ReadOnly = true;
            this.tbQiyuScore.Size = new System.Drawing.Size(50, 26);
            this.tbQiyuScore.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 16);
            this.label18.TabIndex = 0;
            this.label18.Text = "得分:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rdXueyu_QYes);
            this.panel6.Controls.Add(this.rdXueyu_Yes);
            this.panel6.Controls.Add(this.tbXueyuScore);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Location = new System.Drawing.Point(666, 59);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(109, 103);
            this.panel6.TabIndex = 11;
            // 
            // rdXueyu_QYes
            // 
            this.rdXueyu_QYes.AutoSize = true;
            this.rdXueyu_QYes.Enabled = false;
            this.rdXueyu_QYes.Location = new System.Drawing.Point(7, 66);
            this.rdXueyu_QYes.Name = "rdXueyu_QYes";
            this.rdXueyu_QYes.Size = new System.Drawing.Size(74, 20);
            this.rdXueyu_QYes.TabIndex = 3;
            this.rdXueyu_QYes.TabStop = true;
            this.rdXueyu_QYes.Text = "倾向是";
            this.rdXueyu_QYes.UseVisualStyleBackColor = true;
            // 
            // rdXueyu_Yes
            // 
            this.rdXueyu_Yes.AutoSize = true;
            this.rdXueyu_Yes.Enabled = false;
            this.rdXueyu_Yes.Location = new System.Drawing.Point(7, 39);
            this.rdXueyu_Yes.Name = "rdXueyu_Yes";
            this.rdXueyu_Yes.Size = new System.Drawing.Size(42, 20);
            this.rdXueyu_Yes.TabIndex = 2;
            this.rdXueyu_Yes.TabStop = true;
            this.rdXueyu_Yes.Text = "是";
            this.rdXueyu_Yes.UseVisualStyleBackColor = true;
            // 
            // tbXueyuScore
            // 
            this.tbXueyuScore.Location = new System.Drawing.Point(50, 6);
            this.tbXueyuScore.Name = "tbXueyuScore";
            this.tbXueyuScore.ReadOnly = true;
            this.tbXueyuScore.Size = new System.Drawing.Size(50, 26);
            this.tbXueyuScore.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "得分:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rdShire_QYes);
            this.panel5.Controls.Add(this.rdShire_Yes);
            this.panel5.Controls.Add(this.tbShireScore);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Location = new System.Drawing.Point(556, 59);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(109, 103);
            this.panel5.TabIndex = 9;
            // 
            // rdShire_QYes
            // 
            this.rdShire_QYes.AutoSize = true;
            this.rdShire_QYes.Enabled = false;
            this.rdShire_QYes.Location = new System.Drawing.Point(7, 66);
            this.rdShire_QYes.Name = "rdShire_QYes";
            this.rdShire_QYes.Size = new System.Drawing.Size(74, 20);
            this.rdShire_QYes.TabIndex = 3;
            this.rdShire_QYes.TabStop = true;
            this.rdShire_QYes.Text = "倾向是";
            this.rdShire_QYes.UseVisualStyleBackColor = true;
            // 
            // rdShire_Yes
            // 
            this.rdShire_Yes.AutoSize = true;
            this.rdShire_Yes.Enabled = false;
            this.rdShire_Yes.Location = new System.Drawing.Point(7, 39);
            this.rdShire_Yes.Name = "rdShire_Yes";
            this.rdShire_Yes.Size = new System.Drawing.Size(42, 20);
            this.rdShire_Yes.TabIndex = 2;
            this.rdShire_Yes.TabStop = true;
            this.rdShire_Yes.Text = "是";
            this.rdShire_Yes.UseVisualStyleBackColor = true;
            // 
            // tbShireScore
            // 
            this.tbShireScore.Location = new System.Drawing.Point(50, 6);
            this.tbShireScore.Name = "tbShireScore";
            this.tbShireScore.ReadOnly = true;
            this.tbShireScore.Size = new System.Drawing.Size(50, 26);
            this.tbShireScore.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "得分:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdTanshi_QYes);
            this.panel4.Controls.Add(this.rdTanshi_Yes);
            this.panel4.Controls.Add(this.tbTanshiScore);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(446, 59);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(109, 103);
            this.panel4.TabIndex = 7;
            // 
            // rdTanshi_QYes
            // 
            this.rdTanshi_QYes.AutoSize = true;
            this.rdTanshi_QYes.Enabled = false;
            this.rdTanshi_QYes.Location = new System.Drawing.Point(7, 66);
            this.rdTanshi_QYes.Name = "rdTanshi_QYes";
            this.rdTanshi_QYes.Size = new System.Drawing.Size(74, 20);
            this.rdTanshi_QYes.TabIndex = 3;
            this.rdTanshi_QYes.TabStop = true;
            this.rdTanshi_QYes.Text = "倾向是";
            this.rdTanshi_QYes.UseVisualStyleBackColor = true;
            // 
            // rdTanshi_Yes
            // 
            this.rdTanshi_Yes.AutoSize = true;
            this.rdTanshi_Yes.Enabled = false;
            this.rdTanshi_Yes.Location = new System.Drawing.Point(7, 39);
            this.rdTanshi_Yes.Name = "rdTanshi_Yes";
            this.rdTanshi_Yes.Size = new System.Drawing.Size(42, 20);
            this.rdTanshi_Yes.TabIndex = 2;
            this.rdTanshi_Yes.TabStop = true;
            this.rdTanshi_Yes.Text = "是";
            this.rdTanshi_Yes.UseVisualStyleBackColor = true;
            // 
            // tbTanshiScore
            // 
            this.tbTanshiScore.Location = new System.Drawing.Point(50, 6);
            this.tbTanshiScore.Name = "tbTanshiScore";
            this.tbTanshiScore.ReadOnly = true;
            this.tbTanshiScore.Size = new System.Drawing.Size(50, 26);
            this.tbTanshiScore.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "得分:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdYinxu_QYes);
            this.panel3.Controls.Add(this.rdYinxu_Yes);
            this.panel3.Controls.Add(this.tbYinxuScore);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(336, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(109, 103);
            this.panel3.TabIndex = 5;
            // 
            // rdYinxu_QYes
            // 
            this.rdYinxu_QYes.AutoSize = true;
            this.rdYinxu_QYes.Enabled = false;
            this.rdYinxu_QYes.Location = new System.Drawing.Point(7, 66);
            this.rdYinxu_QYes.Name = "rdYinxu_QYes";
            this.rdYinxu_QYes.Size = new System.Drawing.Size(74, 20);
            this.rdYinxu_QYes.TabIndex = 3;
            this.rdYinxu_QYes.TabStop = true;
            this.rdYinxu_QYes.Text = "倾向是";
            this.rdYinxu_QYes.UseVisualStyleBackColor = true;
            // 
            // rdYinxu_Yes
            // 
            this.rdYinxu_Yes.AutoSize = true;
            this.rdYinxu_Yes.Enabled = false;
            this.rdYinxu_Yes.Location = new System.Drawing.Point(7, 39);
            this.rdYinxu_Yes.Name = "rdYinxu_Yes";
            this.rdYinxu_Yes.Size = new System.Drawing.Size(42, 20);
            this.rdYinxu_Yes.TabIndex = 2;
            this.rdYinxu_Yes.TabStop = true;
            this.rdYinxu_Yes.Text = "是";
            this.rdYinxu_Yes.UseVisualStyleBackColor = true;
            // 
            // tbYinxuScore
            // 
            this.tbYinxuScore.Location = new System.Drawing.Point(50, 6);
            this.tbYinxuScore.Name = "tbYinxuScore";
            this.tbYinxuScore.ReadOnly = true;
            this.tbYinxuScore.Size = new System.Drawing.Size(50, 26);
            this.tbYinxuScore.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "得分:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdYangxu_QYes);
            this.panel2.Controls.Add(this.rdYangxu_Yes);
            this.panel2.Controls.Add(this.tbYangxuSorce);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(226, 59);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(109, 103);
            this.panel2.TabIndex = 3;
            // 
            // rdYangxu_QYes
            // 
            this.rdYangxu_QYes.AutoSize = true;
            this.rdYangxu_QYes.Enabled = false;
            this.rdYangxu_QYes.Location = new System.Drawing.Point(7, 66);
            this.rdYangxu_QYes.Name = "rdYangxu_QYes";
            this.rdYangxu_QYes.Size = new System.Drawing.Size(74, 20);
            this.rdYangxu_QYes.TabIndex = 3;
            this.rdYangxu_QYes.TabStop = true;
            this.rdYangxu_QYes.Text = "倾向是";
            this.rdYangxu_QYes.UseVisualStyleBackColor = true;
            // 
            // rdYangxu_Yes
            // 
            this.rdYangxu_Yes.AutoSize = true;
            this.rdYangxu_Yes.Enabled = false;
            this.rdYangxu_Yes.Location = new System.Drawing.Point(7, 39);
            this.rdYangxu_Yes.Name = "rdYangxu_Yes";
            this.rdYangxu_Yes.Size = new System.Drawing.Size(42, 20);
            this.rdYangxu_Yes.TabIndex = 2;
            this.rdYangxu_Yes.TabStop = true;
            this.rdYangxu_Yes.Text = "是";
            this.rdYangxu_Yes.UseVisualStyleBackColor = true;
            // 
            // tbYangxuSorce
            // 
            this.tbYangxuSorce.Location = new System.Drawing.Point(50, 6);
            this.tbYangxuSorce.Name = "tbYangxuSorce";
            this.tbYangxuSorce.ReadOnly = true;
            this.tbYangxuSorce.Size = new System.Drawing.Size(50, 26);
            this.tbYangxuSorce.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "得分:";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.tbPinghe);
            this.panel18.Controls.Add(this.ckPingheOth);
            this.panel18.Controls.Add(this.ckPinghe5);
            this.panel18.Controls.Add(this.ckPinghe4);
            this.panel18.Controls.Add(this.ckPinghe3);
            this.panel18.Controls.Add(this.ckPinghe2);
            this.panel18.Controls.Add(this.ckPinghe1);
            this.panel18.Location = new System.Drawing.Point(996, 163);
            this.panel18.Margin = new System.Windows.Forms.Padding(0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(109, 282);
            this.panel18.TabIndex = 18;
            // 
            // tbPinghe
            // 
            this.tbPinghe.Location = new System.Drawing.Point(7, 174);
            this.tbPinghe.MaxLength = 100;
            this.tbPinghe.Multiline = true;
            this.tbPinghe.Name = "tbPinghe";
            this.tbPinghe.ReadOnly = true;
            this.tbPinghe.Size = new System.Drawing.Size(93, 105);
            this.tbPinghe.TabIndex = 9;
            // 
            // ckPingheOth
            // 
            this.ckPingheOth.AutoSize = true;
            this.ckPingheOth.Location = new System.Drawing.Point(7, 146);
            this.ckPingheOth.Name = "ckPingheOth";
            this.ckPingheOth.Size = new System.Drawing.Size(59, 20);
            this.ckPingheOth.TabIndex = 8;
            this.ckPingheOth.Text = "其他";
            this.ckPingheOth.UseVisualStyleBackColor = true;
            // 
            // ckPinghe5
            // 
            this.ckPinghe5.AutoSize = true;
            this.ckPinghe5.Location = new System.Drawing.Point(7, 119);
            this.ckPinghe5.Name = "ckPinghe5";
            this.ckPinghe5.Size = new System.Drawing.Size(91, 20);
            this.ckPinghe5.TabIndex = 7;
            this.ckPinghe5.Text = "穴位保健";
            this.ckPinghe5.UseVisualStyleBackColor = true;
            // 
            // ckPinghe4
            // 
            this.ckPinghe4.AutoSize = true;
            this.ckPinghe4.Location = new System.Drawing.Point(7, 91);
            this.ckPinghe4.Name = "ckPinghe4";
            this.ckPinghe4.Size = new System.Drawing.Size(91, 20);
            this.ckPinghe4.TabIndex = 6;
            this.ckPinghe4.Text = "运动保健";
            this.ckPinghe4.UseVisualStyleBackColor = true;
            // 
            // ckPinghe3
            // 
            this.ckPinghe3.AutoSize = true;
            this.ckPinghe3.Location = new System.Drawing.Point(7, 64);
            this.ckPinghe3.Name = "ckPinghe3";
            this.ckPinghe3.Size = new System.Drawing.Size(91, 20);
            this.ckPinghe3.TabIndex = 5;
            this.ckPinghe3.Text = "起居调摄";
            this.ckPinghe3.UseVisualStyleBackColor = true;
            // 
            // ckPinghe2
            // 
            this.ckPinghe2.AutoSize = true;
            this.ckPinghe2.Location = new System.Drawing.Point(7, 37);
            this.ckPinghe2.Name = "ckPinghe2";
            this.ckPinghe2.Size = new System.Drawing.Size(91, 20);
            this.ckPinghe2.TabIndex = 4;
            this.ckPinghe2.Text = "饮食调养";
            this.ckPinghe2.UseVisualStyleBackColor = true;
            // 
            // ckPinghe1
            // 
            this.ckPinghe1.AutoSize = true;
            this.ckPinghe1.Location = new System.Drawing.Point(7, 9);
            this.ckPinghe1.Name = "ckPinghe1";
            this.ckPinghe1.Size = new System.Drawing.Size(91, 20);
            this.ckPinghe1.TabIndex = 3;
            this.ckPinghe1.Text = "情志调摄";
            this.ckPinghe1.UseVisualStyleBackColor = true;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.tbTebing);
            this.panel17.Controls.Add(this.ckTebingOth);
            this.panel17.Controls.Add(this.ckTebing5);
            this.panel17.Controls.Add(this.ckTebing4);
            this.panel17.Controls.Add(this.ckTebing3);
            this.panel17.Controls.Add(this.ckTebing2);
            this.panel17.Controls.Add(this.ckTebing1);
            this.panel17.Location = new System.Drawing.Point(886, 163);
            this.panel17.Margin = new System.Windows.Forms.Padding(0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(109, 282);
            this.panel17.TabIndex = 16;
            // 
            // tbTebing
            // 
            this.tbTebing.Location = new System.Drawing.Point(7, 174);
            this.tbTebing.MaxLength = 100;
            this.tbTebing.Multiline = true;
            this.tbTebing.Name = "tbTebing";
            this.tbTebing.ReadOnly = true;
            this.tbTebing.Size = new System.Drawing.Size(93, 105);
            this.tbTebing.TabIndex = 9;
            // 
            // ckTebingOth
            // 
            this.ckTebingOth.AutoSize = true;
            this.ckTebingOth.Location = new System.Drawing.Point(7, 146);
            this.ckTebingOth.Name = "ckTebingOth";
            this.ckTebingOth.Size = new System.Drawing.Size(59, 20);
            this.ckTebingOth.TabIndex = 8;
            this.ckTebingOth.Text = "其他";
            this.ckTebingOth.UseVisualStyleBackColor = true;
            // 
            // ckTebing5
            // 
            this.ckTebing5.AutoSize = true;
            this.ckTebing5.Location = new System.Drawing.Point(7, 119);
            this.ckTebing5.Name = "ckTebing5";
            this.ckTebing5.Size = new System.Drawing.Size(91, 20);
            this.ckTebing5.TabIndex = 7;
            this.ckTebing5.Text = "穴位保健";
            this.ckTebing5.UseVisualStyleBackColor = true;
            // 
            // ckTebing4
            // 
            this.ckTebing4.AutoSize = true;
            this.ckTebing4.Location = new System.Drawing.Point(7, 91);
            this.ckTebing4.Name = "ckTebing4";
            this.ckTebing4.Size = new System.Drawing.Size(91, 20);
            this.ckTebing4.TabIndex = 6;
            this.ckTebing4.Text = "运动保健";
            this.ckTebing4.UseVisualStyleBackColor = true;
            // 
            // ckTebing3
            // 
            this.ckTebing3.AutoSize = true;
            this.ckTebing3.Location = new System.Drawing.Point(7, 64);
            this.ckTebing3.Name = "ckTebing3";
            this.ckTebing3.Size = new System.Drawing.Size(91, 20);
            this.ckTebing3.TabIndex = 5;
            this.ckTebing3.Text = "起居调摄";
            this.ckTebing3.UseVisualStyleBackColor = true;
            // 
            // ckTebing2
            // 
            this.ckTebing2.AutoSize = true;
            this.ckTebing2.Location = new System.Drawing.Point(7, 37);
            this.ckTebing2.Name = "ckTebing2";
            this.ckTebing2.Size = new System.Drawing.Size(91, 20);
            this.ckTebing2.TabIndex = 4;
            this.ckTebing2.Text = "饮食调养";
            this.ckTebing2.UseVisualStyleBackColor = true;
            // 
            // ckTebing1
            // 
            this.ckTebing1.AutoSize = true;
            this.ckTebing1.Location = new System.Drawing.Point(7, 9);
            this.ckTebing1.Name = "ckTebing1";
            this.ckTebing1.Size = new System.Drawing.Size(91, 20);
            this.ckTebing1.TabIndex = 3;
            this.ckTebing1.Text = "情志调摄";
            this.ckTebing1.UseVisualStyleBackColor = true;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.tbQiyu);
            this.panel16.Controls.Add(this.ckQiyuOth);
            this.panel16.Controls.Add(this.ckQiyu5);
            this.panel16.Controls.Add(this.ckQiyu4);
            this.panel16.Controls.Add(this.ckQiyu3);
            this.panel16.Controls.Add(this.ckQiyu2);
            this.panel16.Controls.Add(this.ckQiyu1);
            this.panel16.Location = new System.Drawing.Point(776, 163);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(109, 282);
            this.panel16.TabIndex = 14;
            // 
            // tbQiyu
            // 
            this.tbQiyu.Location = new System.Drawing.Point(7, 174);
            this.tbQiyu.MaxLength = 100;
            this.tbQiyu.Multiline = true;
            this.tbQiyu.Name = "tbQiyu";
            this.tbQiyu.ReadOnly = true;
            this.tbQiyu.Size = new System.Drawing.Size(93, 105);
            this.tbQiyu.TabIndex = 9;
            // 
            // ckQiyuOth
            // 
            this.ckQiyuOth.AutoSize = true;
            this.ckQiyuOth.Location = new System.Drawing.Point(7, 146);
            this.ckQiyuOth.Name = "ckQiyuOth";
            this.ckQiyuOth.Size = new System.Drawing.Size(59, 20);
            this.ckQiyuOth.TabIndex = 8;
            this.ckQiyuOth.Text = "其他";
            this.ckQiyuOth.UseVisualStyleBackColor = true;
            // 
            // ckQiyu5
            // 
            this.ckQiyu5.AutoSize = true;
            this.ckQiyu5.Location = new System.Drawing.Point(7, 119);
            this.ckQiyu5.Name = "ckQiyu5";
            this.ckQiyu5.Size = new System.Drawing.Size(91, 20);
            this.ckQiyu5.TabIndex = 7;
            this.ckQiyu5.Text = "穴位保健";
            this.ckQiyu5.UseVisualStyleBackColor = true;
            // 
            // ckQiyu4
            // 
            this.ckQiyu4.AutoSize = true;
            this.ckQiyu4.Location = new System.Drawing.Point(7, 91);
            this.ckQiyu4.Name = "ckQiyu4";
            this.ckQiyu4.Size = new System.Drawing.Size(91, 20);
            this.ckQiyu4.TabIndex = 6;
            this.ckQiyu4.Text = "运动保健";
            this.ckQiyu4.UseVisualStyleBackColor = true;
            // 
            // ckQiyu3
            // 
            this.ckQiyu3.AutoSize = true;
            this.ckQiyu3.Location = new System.Drawing.Point(7, 64);
            this.ckQiyu3.Name = "ckQiyu3";
            this.ckQiyu3.Size = new System.Drawing.Size(91, 20);
            this.ckQiyu3.TabIndex = 5;
            this.ckQiyu3.Text = "起居调摄";
            this.ckQiyu3.UseVisualStyleBackColor = true;
            // 
            // ckQiyu2
            // 
            this.ckQiyu2.AutoSize = true;
            this.ckQiyu2.Location = new System.Drawing.Point(7, 37);
            this.ckQiyu2.Name = "ckQiyu2";
            this.ckQiyu2.Size = new System.Drawing.Size(91, 20);
            this.ckQiyu2.TabIndex = 4;
            this.ckQiyu2.Text = "饮食调养";
            this.ckQiyu2.UseVisualStyleBackColor = true;
            // 
            // ckQiyu1
            // 
            this.ckQiyu1.AutoSize = true;
            this.ckQiyu1.Location = new System.Drawing.Point(7, 9);
            this.ckQiyu1.Name = "ckQiyu1";
            this.ckQiyu1.Size = new System.Drawing.Size(91, 20);
            this.ckQiyu1.TabIndex = 3;
            this.ckQiyu1.Text = "情志调摄";
            this.ckQiyu1.UseVisualStyleBackColor = true;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.tbXueyu);
            this.panel15.Controls.Add(this.ckXueyuOth);
            this.panel15.Controls.Add(this.ckXueyu5);
            this.panel15.Controls.Add(this.ckXueyu4);
            this.panel15.Controls.Add(this.ckXueyu3);
            this.panel15.Controls.Add(this.ckXueyu2);
            this.panel15.Controls.Add(this.ckXueyu1);
            this.panel15.Location = new System.Drawing.Point(666, 163);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(109, 282);
            this.panel15.TabIndex = 12;
            // 
            // tbXueyu
            // 
            this.tbXueyu.Location = new System.Drawing.Point(7, 174);
            this.tbXueyu.MaxLength = 100;
            this.tbXueyu.Multiline = true;
            this.tbXueyu.Name = "tbXueyu";
            this.tbXueyu.ReadOnly = true;
            this.tbXueyu.Size = new System.Drawing.Size(93, 105);
            this.tbXueyu.TabIndex = 9;
            // 
            // ckXueyuOth
            // 
            this.ckXueyuOth.AutoSize = true;
            this.ckXueyuOth.Location = new System.Drawing.Point(7, 146);
            this.ckXueyuOth.Name = "ckXueyuOth";
            this.ckXueyuOth.Size = new System.Drawing.Size(59, 20);
            this.ckXueyuOth.TabIndex = 8;
            this.ckXueyuOth.Text = "其他";
            this.ckXueyuOth.UseVisualStyleBackColor = true;
            // 
            // ckXueyu5
            // 
            this.ckXueyu5.AutoSize = true;
            this.ckXueyu5.Location = new System.Drawing.Point(7, 119);
            this.ckXueyu5.Name = "ckXueyu5";
            this.ckXueyu5.Size = new System.Drawing.Size(91, 20);
            this.ckXueyu5.TabIndex = 7;
            this.ckXueyu5.Text = "穴位保健";
            this.ckXueyu5.UseVisualStyleBackColor = true;
            // 
            // ckXueyu4
            // 
            this.ckXueyu4.AutoSize = true;
            this.ckXueyu4.Location = new System.Drawing.Point(7, 91);
            this.ckXueyu4.Name = "ckXueyu4";
            this.ckXueyu4.Size = new System.Drawing.Size(91, 20);
            this.ckXueyu4.TabIndex = 6;
            this.ckXueyu4.Text = "运动保健";
            this.ckXueyu4.UseVisualStyleBackColor = true;
            // 
            // ckXueyu3
            // 
            this.ckXueyu3.AutoSize = true;
            this.ckXueyu3.Location = new System.Drawing.Point(7, 64);
            this.ckXueyu3.Name = "ckXueyu3";
            this.ckXueyu3.Size = new System.Drawing.Size(91, 20);
            this.ckXueyu3.TabIndex = 5;
            this.ckXueyu3.Text = "起居调摄";
            this.ckXueyu3.UseVisualStyleBackColor = true;
            // 
            // ckXueyu2
            // 
            this.ckXueyu2.AutoSize = true;
            this.ckXueyu2.Location = new System.Drawing.Point(7, 37);
            this.ckXueyu2.Name = "ckXueyu2";
            this.ckXueyu2.Size = new System.Drawing.Size(91, 20);
            this.ckXueyu2.TabIndex = 4;
            this.ckXueyu2.Text = "饮食调养";
            this.ckXueyu2.UseVisualStyleBackColor = true;
            // 
            // ckXueyu1
            // 
            this.ckXueyu1.AutoSize = true;
            this.ckXueyu1.Location = new System.Drawing.Point(7, 9);
            this.ckXueyu1.Name = "ckXueyu1";
            this.ckXueyu1.Size = new System.Drawing.Size(91, 20);
            this.ckXueyu1.TabIndex = 3;
            this.ckXueyu1.Text = "情志调摄";
            this.ckXueyu1.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.tbShire);
            this.panel14.Controls.Add(this.ckShireOth);
            this.panel14.Controls.Add(this.ckShire5);
            this.panel14.Controls.Add(this.ckShire4);
            this.panel14.Controls.Add(this.ckShire3);
            this.panel14.Controls.Add(this.ckShire2);
            this.panel14.Controls.Add(this.ckShire1);
            this.panel14.Location = new System.Drawing.Point(556, 163);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(109, 282);
            this.panel14.TabIndex = 10;
            // 
            // tbShire
            // 
            this.tbShire.Location = new System.Drawing.Point(7, 174);
            this.tbShire.MaxLength = 100;
            this.tbShire.Multiline = true;
            this.tbShire.Name = "tbShire";
            this.tbShire.ReadOnly = true;
            this.tbShire.Size = new System.Drawing.Size(93, 105);
            this.tbShire.TabIndex = 9;
            // 
            // ckShireOth
            // 
            this.ckShireOth.AutoSize = true;
            this.ckShireOth.Location = new System.Drawing.Point(7, 146);
            this.ckShireOth.Name = "ckShireOth";
            this.ckShireOth.Size = new System.Drawing.Size(59, 20);
            this.ckShireOth.TabIndex = 8;
            this.ckShireOth.Text = "其他";
            this.ckShireOth.UseVisualStyleBackColor = true;
            // 
            // ckShire5
            // 
            this.ckShire5.AutoSize = true;
            this.ckShire5.Location = new System.Drawing.Point(7, 119);
            this.ckShire5.Name = "ckShire5";
            this.ckShire5.Size = new System.Drawing.Size(91, 20);
            this.ckShire5.TabIndex = 7;
            this.ckShire5.Text = "穴位保健";
            this.ckShire5.UseVisualStyleBackColor = true;
            // 
            // ckShire4
            // 
            this.ckShire4.AutoSize = true;
            this.ckShire4.Location = new System.Drawing.Point(7, 91);
            this.ckShire4.Name = "ckShire4";
            this.ckShire4.Size = new System.Drawing.Size(91, 20);
            this.ckShire4.TabIndex = 6;
            this.ckShire4.Text = "运动保健";
            this.ckShire4.UseVisualStyleBackColor = true;
            // 
            // ckShire3
            // 
            this.ckShire3.AutoSize = true;
            this.ckShire3.Location = new System.Drawing.Point(7, 64);
            this.ckShire3.Name = "ckShire3";
            this.ckShire3.Size = new System.Drawing.Size(91, 20);
            this.ckShire3.TabIndex = 5;
            this.ckShire3.Text = "起居调摄";
            this.ckShire3.UseVisualStyleBackColor = true;
            // 
            // ckShire2
            // 
            this.ckShire2.AutoSize = true;
            this.ckShire2.Location = new System.Drawing.Point(7, 37);
            this.ckShire2.Name = "ckShire2";
            this.ckShire2.Size = new System.Drawing.Size(91, 20);
            this.ckShire2.TabIndex = 4;
            this.ckShire2.Text = "饮食调养";
            this.ckShire2.UseVisualStyleBackColor = true;
            // 
            // ckShire1
            // 
            this.ckShire1.AutoSize = true;
            this.ckShire1.Location = new System.Drawing.Point(7, 9);
            this.ckShire1.Name = "ckShire1";
            this.ckShire1.Size = new System.Drawing.Size(91, 20);
            this.ckShire1.TabIndex = 3;
            this.ckShire1.Text = "情志调摄";
            this.ckShire1.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.tbTanshi);
            this.panel13.Controls.Add(this.ckTans1Oth);
            this.panel13.Controls.Add(this.ckTans5);
            this.panel13.Controls.Add(this.ckTans4);
            this.panel13.Controls.Add(this.ckTans3);
            this.panel13.Controls.Add(this.ckTans2);
            this.panel13.Controls.Add(this.ckTans1);
            this.panel13.Location = new System.Drawing.Point(446, 163);
            this.panel13.Margin = new System.Windows.Forms.Padding(0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(109, 282);
            this.panel13.TabIndex = 8;
            // 
            // tbTanshi
            // 
            this.tbTanshi.Location = new System.Drawing.Point(7, 174);
            this.tbTanshi.MaxLength = 100;
            this.tbTanshi.Multiline = true;
            this.tbTanshi.Name = "tbTanshi";
            this.tbTanshi.ReadOnly = true;
            this.tbTanshi.Size = new System.Drawing.Size(93, 105);
            this.tbTanshi.TabIndex = 9;
            // 
            // ckTans1Oth
            // 
            this.ckTans1Oth.AutoSize = true;
            this.ckTans1Oth.Location = new System.Drawing.Point(7, 146);
            this.ckTans1Oth.Name = "ckTans1Oth";
            this.ckTans1Oth.Size = new System.Drawing.Size(59, 20);
            this.ckTans1Oth.TabIndex = 8;
            this.ckTans1Oth.Text = "其他";
            this.ckTans1Oth.UseVisualStyleBackColor = true;
            // 
            // ckTans5
            // 
            this.ckTans5.AutoSize = true;
            this.ckTans5.Location = new System.Drawing.Point(7, 119);
            this.ckTans5.Name = "ckTans5";
            this.ckTans5.Size = new System.Drawing.Size(91, 20);
            this.ckTans5.TabIndex = 7;
            this.ckTans5.Text = "穴位保健";
            this.ckTans5.UseVisualStyleBackColor = true;
            // 
            // ckTans4
            // 
            this.ckTans4.AutoSize = true;
            this.ckTans4.Location = new System.Drawing.Point(7, 91);
            this.ckTans4.Name = "ckTans4";
            this.ckTans4.Size = new System.Drawing.Size(91, 20);
            this.ckTans4.TabIndex = 6;
            this.ckTans4.Text = "运动保健";
            this.ckTans4.UseVisualStyleBackColor = true;
            // 
            // ckTans3
            // 
            this.ckTans3.AutoSize = true;
            this.ckTans3.Location = new System.Drawing.Point(7, 64);
            this.ckTans3.Name = "ckTans3";
            this.ckTans3.Size = new System.Drawing.Size(91, 20);
            this.ckTans3.TabIndex = 5;
            this.ckTans3.Text = "起居调摄";
            this.ckTans3.UseVisualStyleBackColor = true;
            // 
            // ckTans2
            // 
            this.ckTans2.AutoSize = true;
            this.ckTans2.Location = new System.Drawing.Point(7, 37);
            this.ckTans2.Name = "ckTans2";
            this.ckTans2.Size = new System.Drawing.Size(91, 20);
            this.ckTans2.TabIndex = 4;
            this.ckTans2.Text = "饮食调养";
            this.ckTans2.UseVisualStyleBackColor = true;
            // 
            // ckTans1
            // 
            this.ckTans1.AutoSize = true;
            this.ckTans1.Location = new System.Drawing.Point(7, 9);
            this.ckTans1.Name = "ckTans1";
            this.ckTans1.Size = new System.Drawing.Size(91, 20);
            this.ckTans1.TabIndex = 3;
            this.ckTans1.Text = "情志调摄";
            this.ckTans1.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.tbYinxu);
            this.panel12.Controls.Add(this.ckYinxuOth);
            this.panel12.Controls.Add(this.ckYinxu5);
            this.panel12.Controls.Add(this.ckYinxu4);
            this.panel12.Controls.Add(this.ckYinxu3);
            this.panel12.Controls.Add(this.ckYinxu2);
            this.panel12.Controls.Add(this.ckYinxu1);
            this.panel12.Location = new System.Drawing.Point(336, 163);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(109, 282);
            this.panel12.TabIndex = 6;
            // 
            // tbYinxu
            // 
            this.tbYinxu.Location = new System.Drawing.Point(7, 174);
            this.tbYinxu.MaxLength = 100;
            this.tbYinxu.Multiline = true;
            this.tbYinxu.Name = "tbYinxu";
            this.tbYinxu.ReadOnly = true;
            this.tbYinxu.Size = new System.Drawing.Size(93, 105);
            this.tbYinxu.TabIndex = 9;
            // 
            // ckYinxuOth
            // 
            this.ckYinxuOth.AutoSize = true;
            this.ckYinxuOth.Location = new System.Drawing.Point(7, 146);
            this.ckYinxuOth.Name = "ckYinxuOth";
            this.ckYinxuOth.Size = new System.Drawing.Size(59, 20);
            this.ckYinxuOth.TabIndex = 8;
            this.ckYinxuOth.Text = "其他";
            this.ckYinxuOth.UseVisualStyleBackColor = true;
            // 
            // ckYinxu5
            // 
            this.ckYinxu5.AutoSize = true;
            this.ckYinxu5.Location = new System.Drawing.Point(7, 119);
            this.ckYinxu5.Name = "ckYinxu5";
            this.ckYinxu5.Size = new System.Drawing.Size(91, 20);
            this.ckYinxu5.TabIndex = 7;
            this.ckYinxu5.Text = "穴位保健";
            this.ckYinxu5.UseVisualStyleBackColor = true;
            // 
            // ckYinxu4
            // 
            this.ckYinxu4.AutoSize = true;
            this.ckYinxu4.Location = new System.Drawing.Point(7, 91);
            this.ckYinxu4.Name = "ckYinxu4";
            this.ckYinxu4.Size = new System.Drawing.Size(91, 20);
            this.ckYinxu4.TabIndex = 6;
            this.ckYinxu4.Text = "运动保健";
            this.ckYinxu4.UseVisualStyleBackColor = true;
            // 
            // ckYinxu3
            // 
            this.ckYinxu3.AutoSize = true;
            this.ckYinxu3.Location = new System.Drawing.Point(7, 64);
            this.ckYinxu3.Name = "ckYinxu3";
            this.ckYinxu3.Size = new System.Drawing.Size(91, 20);
            this.ckYinxu3.TabIndex = 5;
            this.ckYinxu3.Text = "起居调摄";
            this.ckYinxu3.UseVisualStyleBackColor = true;
            // 
            // ckYinxu2
            // 
            this.ckYinxu2.AutoSize = true;
            this.ckYinxu2.Location = new System.Drawing.Point(7, 37);
            this.ckYinxu2.Name = "ckYinxu2";
            this.ckYinxu2.Size = new System.Drawing.Size(91, 20);
            this.ckYinxu2.TabIndex = 4;
            this.ckYinxu2.Text = "饮食调养";
            this.ckYinxu2.UseVisualStyleBackColor = true;
            // 
            // ckYinxu1
            // 
            this.ckYinxu1.AutoSize = true;
            this.ckYinxu1.Location = new System.Drawing.Point(7, 9);
            this.ckYinxu1.Name = "ckYinxu1";
            this.ckYinxu1.Size = new System.Drawing.Size(91, 20);
            this.ckYinxu1.TabIndex = 3;
            this.ckYinxu1.Text = "情志调摄";
            this.ckYinxu1.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.tbYangxu);
            this.panel11.Controls.Add(this.ckYangxuOth);
            this.panel11.Controls.Add(this.ckYangxu5);
            this.panel11.Controls.Add(this.ckYangxu4);
            this.panel11.Controls.Add(this.ckYangxu3);
            this.panel11.Controls.Add(this.ckYangxu2);
            this.panel11.Controls.Add(this.ckYangxu1);
            this.panel11.Location = new System.Drawing.Point(226, 163);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(109, 282);
            this.panel11.TabIndex = 4;
            // 
            // tbYangxu
            // 
            this.tbYangxu.Location = new System.Drawing.Point(7, 174);
            this.tbYangxu.MaxLength = 100;
            this.tbYangxu.Multiline = true;
            this.tbYangxu.Name = "tbYangxu";
            this.tbYangxu.ReadOnly = true;
            this.tbYangxu.Size = new System.Drawing.Size(93, 105);
            this.tbYangxu.TabIndex = 9;
            // 
            // ckYangxuOth
            // 
            this.ckYangxuOth.AutoSize = true;
            this.ckYangxuOth.Location = new System.Drawing.Point(7, 146);
            this.ckYangxuOth.Name = "ckYangxuOth";
            this.ckYangxuOth.Size = new System.Drawing.Size(59, 20);
            this.ckYangxuOth.TabIndex = 8;
            this.ckYangxuOth.Text = "其他";
            this.ckYangxuOth.UseVisualStyleBackColor = true;
            // 
            // ckYangxu5
            // 
            this.ckYangxu5.AutoSize = true;
            this.ckYangxu5.Location = new System.Drawing.Point(7, 119);
            this.ckYangxu5.Name = "ckYangxu5";
            this.ckYangxu5.Size = new System.Drawing.Size(91, 20);
            this.ckYangxu5.TabIndex = 7;
            this.ckYangxu5.Text = "穴位保健";
            this.ckYangxu5.UseVisualStyleBackColor = true;
            // 
            // ckYangxu4
            // 
            this.ckYangxu4.AutoSize = true;
            this.ckYangxu4.Location = new System.Drawing.Point(7, 91);
            this.ckYangxu4.Name = "ckYangxu4";
            this.ckYangxu4.Size = new System.Drawing.Size(91, 20);
            this.ckYangxu4.TabIndex = 6;
            this.ckYangxu4.Text = "运动保健";
            this.ckYangxu4.UseVisualStyleBackColor = true;
            // 
            // ckYangxu3
            // 
            this.ckYangxu3.AutoSize = true;
            this.ckYangxu3.Location = new System.Drawing.Point(7, 64);
            this.ckYangxu3.Name = "ckYangxu3";
            this.ckYangxu3.Size = new System.Drawing.Size(91, 20);
            this.ckYangxu3.TabIndex = 5;
            this.ckYangxu3.Text = "起居调摄";
            this.ckYangxu3.UseVisualStyleBackColor = true;
            // 
            // ckYangxu2
            // 
            this.ckYangxu2.AutoSize = true;
            this.ckYangxu2.Location = new System.Drawing.Point(7, 37);
            this.ckYangxu2.Name = "ckYangxu2";
            this.ckYangxu2.Size = new System.Drawing.Size(91, 20);
            this.ckYangxu2.TabIndex = 4;
            this.ckYangxu2.Text = "饮食调养";
            this.ckYangxu2.UseVisualStyleBackColor = true;
            // 
            // ckYangxu1
            // 
            this.ckYangxu1.AutoSize = true;
            this.ckYangxu1.Location = new System.Drawing.Point(7, 9);
            this.ckYangxu1.Name = "ckYangxu1";
            this.ckYangxu1.Size = new System.Drawing.Size(91, 20);
            this.ckYangxu1.TabIndex = 0;
            this.ckYangxu1.Text = "情志调摄";
            this.ckYangxu1.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(4, 299);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(108, 14);
            this.label21.TabIndex = 21;
            this.label21.Text = "中医药保健指导";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(4, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 14);
            this.label10.TabIndex = 1;
            this.label10.Text = "体质类型";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(119, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "气虚质";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(229, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "阳虚质";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(339, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "阴虚质";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(449, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "痰湿质";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(559, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "湿热质";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(669, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "血瘀质";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(779, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "气郁质";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(889, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 14);
            this.label8.TabIndex = 9;
            this.label8.Text = "特禀质";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(4, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 14);
            this.label11.TabIndex = 11;
            this.label11.Text = "体质辨识";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.rdQiXu_QYes);
            this.panel10.Controls.Add(this.rdQiXu_Yes);
            this.panel10.Controls.Add(this.tbQixuScore);
            this.panel10.Controls.Add(this.label12);
            this.panel10.Location = new System.Drawing.Point(116, 59);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(109, 103);
            this.panel10.TabIndex = 1;
            // 
            // rdQiXu_QYes
            // 
            this.rdQiXu_QYes.AutoSize = true;
            this.rdQiXu_QYes.Enabled = false;
            this.rdQiXu_QYes.Location = new System.Drawing.Point(7, 66);
            this.rdQiXu_QYes.Name = "rdQiXu_QYes";
            this.rdQiXu_QYes.Size = new System.Drawing.Size(74, 20);
            this.rdQiXu_QYes.TabIndex = 3;
            this.rdQiXu_QYes.TabStop = true;
            this.rdQiXu_QYes.Text = "倾向是";
            this.rdQiXu_QYes.UseVisualStyleBackColor = true;
            // 
            // rdQiXu_Yes
            // 
            this.rdQiXu_Yes.AutoSize = true;
            this.rdQiXu_Yes.Enabled = false;
            this.rdQiXu_Yes.Location = new System.Drawing.Point(7, 39);
            this.rdQiXu_Yes.Name = "rdQiXu_Yes";
            this.rdQiXu_Yes.Size = new System.Drawing.Size(42, 20);
            this.rdQiXu_Yes.TabIndex = 2;
            this.rdQiXu_Yes.TabStop = true;
            this.rdQiXu_Yes.Text = "是";
            this.rdQiXu_Yes.UseVisualStyleBackColor = true;
            // 
            // tbQixuScore
            // 
            this.tbQixuScore.Location = new System.Drawing.Point(50, 6);
            this.tbQixuScore.Name = "tbQixuScore";
            this.tbQixuScore.ReadOnly = true;
            this.tbQixuScore.Size = new System.Drawing.Size(50, 26);
            this.tbQixuScore.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "得分:";
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.tbQixu);
            this.panel19.Controls.Add(this.ckQixuOth);
            this.panel19.Controls.Add(this.ckQixu5);
            this.panel19.Controls.Add(this.ckQixu4);
            this.panel19.Controls.Add(this.ckQixu3);
            this.panel19.Controls.Add(this.ckQixu2);
            this.panel19.Controls.Add(this.ckQixu1);
            this.panel19.Location = new System.Drawing.Point(116, 163);
            this.panel19.Margin = new System.Windows.Forms.Padding(0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(109, 282);
            this.panel19.TabIndex = 2;
            // 
            // tbQixu
            // 
            this.tbQixu.Location = new System.Drawing.Point(7, 174);
            this.tbQixu.MaxLength = 100;
            this.tbQixu.Multiline = true;
            this.tbQixu.Name = "tbQixu";
            this.tbQixu.ReadOnly = true;
            this.tbQixu.Size = new System.Drawing.Size(93, 105);
            this.tbQixu.TabIndex = 9;
            // 
            // ckQixuOth
            // 
            this.ckQixuOth.AutoSize = true;
            this.ckQixuOth.Location = new System.Drawing.Point(7, 146);
            this.ckQixuOth.Name = "ckQixuOth";
            this.ckQixuOth.Size = new System.Drawing.Size(59, 20);
            this.ckQixuOth.TabIndex = 8;
            this.ckQixuOth.Text = "其他";
            this.ckQixuOth.UseVisualStyleBackColor = true;
            // 
            // ckQixu5
            // 
            this.ckQixu5.AutoSize = true;
            this.ckQixu5.Location = new System.Drawing.Point(7, 119);
            this.ckQixu5.Name = "ckQixu5";
            this.ckQixu5.Size = new System.Drawing.Size(91, 20);
            this.ckQixu5.TabIndex = 7;
            this.ckQixu5.Text = "穴位保健";
            this.ckQixu5.UseVisualStyleBackColor = true;
            // 
            // ckQixu4
            // 
            this.ckQixu4.AutoSize = true;
            this.ckQixu4.Location = new System.Drawing.Point(7, 91);
            this.ckQixu4.Name = "ckQixu4";
            this.ckQixu4.Size = new System.Drawing.Size(91, 20);
            this.ckQixu4.TabIndex = 6;
            this.ckQixu4.Text = "运动保健";
            this.ckQixu4.UseVisualStyleBackColor = true;
            // 
            // ckQixu3
            // 
            this.ckQixu3.AutoSize = true;
            this.ckQixu3.Location = new System.Drawing.Point(7, 64);
            this.ckQixu3.Name = "ckQixu3";
            this.ckQixu3.Size = new System.Drawing.Size(91, 20);
            this.ckQixu3.TabIndex = 5;
            this.ckQixu3.Text = "起居调摄";
            this.ckQixu3.UseVisualStyleBackColor = true;
            // 
            // ckQixu2
            // 
            this.ckQixu2.AutoSize = true;
            this.ckQixu2.Location = new System.Drawing.Point(7, 37);
            this.ckQixu2.Name = "ckQixu2";
            this.ckQixu2.Size = new System.Drawing.Size(91, 20);
            this.ckQixu2.TabIndex = 4;
            this.ckQixu2.Text = "饮食调养";
            this.ckQixu2.UseVisualStyleBackColor = true;
            // 
            // ckQixu1
            // 
            this.ckQixu1.AutoSize = true;
            this.ckQixu1.Location = new System.Drawing.Point(7, 9);
            this.ckQixu1.Name = "ckQixu1";
            this.ckQixu1.Size = new System.Drawing.Size(91, 20);
            this.ckQixu1.TabIndex = 3;
            this.ckQixu1.Text = "情志调摄";
            this.ckQixu1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(738, 620);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 43);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存结果";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            // 
            // HealthOldMedEX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1460, 731);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "HealthOldMedEX";
            this.Text = "FrmOldMedEX";
            this.Load += new System.EventHandler(this.FrmOldMedEX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.ResumeLayout(false);

        }

        private void judgePinghebyScore()
        {
            decimal? nullable = this.MedResult.MildScore;
            if (((nullable.GetValueOrDefault() < 17M) ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            {
                int num = this.judge_tizhiAll.Count<ScoreJudge>(a => a.m_score < 8M);
                if (this.judge_tizhiAll.Count<ScoreJudge>(a => (a.m_score < 10M)) == this.judge_tizhiAll.Count)
                {
                    if (num == this.judge_tizhiAll.Count)
                    {
                        this.MedResult.Mild = "1";
                        this.rdPinghe_Yes.Checked = true;
                    }
                    else
                    {
                        this.MedResult.Mild = "2";
                        this.rdPinghe_QYes.Checked = true;
                    }
                }
                else
                {
                    this.MedResult.Mild = "";
                    this.rdPinghe_QYes.Checked = false;
                    this.rdPinghe_Yes.Checked = false;
                }
            }
            else
            {
                this.MedResult.Mild = "";
                this.rdPinghe_QYes.Checked = false;
                this.rdPinghe_Yes.Checked = false;
            }
        }

        public void NotisfyChildStatus()
        {
        }

        public void PhysicalItem()
        {
            this.btnSave.Visible = true;
            this.btnSave.Location = new Point(0x386, 0x257);
            this.btnResult.Location = new Point(0x2fb, 0x257);
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
        }

        public bool SaveModelToDB()
        {
            return true;
        }

        private void UpDatagridview()
        {
            Action method = new Action(this.UpDatagridview);
            if (this.dataGridView1.InvokeRequired)
            {
                this.dataGridView1.Invoke(method);
            }
            else
            {
                GlbTools.ModelFillDatatabel<HealthHouseMedicineCnModel>(this.MedCn, this.xmlDs.Tables[0]);
                this.dataGridView1.DataSource = this.xmlDs.Tables[0];
                List<ChItems>[] listArray = new List<ChItems>[] { this.usualItems, this.s0Items, this.s1Items, this.s2Items, this.s3Items };
                int num = 0;
                if (this.MedCnFlage)
                {
                    foreach (DataGridViewRow row in (IEnumerable)this.dataGridView1.Rows)
                    {
                        DataGridViewComboBoxCell cell = row.Cells[1] as DataGridViewComboBoxCell;
                        if (cell != null)
                        {
                            DataRow row2 = this.xmlDs.Tables[0].Rows[num];
                            cell.DataSource = listArray[int.Parse(row2["select"].ToString())];
                            if (num == 8)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(this.HealthModel.BMI)))
                                {
                                    if (Convert.ToDouble(this.HealthModel.BMI) < 24)
                                    {
                                        row.Cells[1].Value = 1;
                                    }
                                    else if (Convert.ToDouble(this.HealthModel.BMI) >= 24 && Convert.ToDouble(this.HealthModel.BMI) < 25)
                                    {
                                        row.Cells[1].Value = 2;
                                    }
                                    else if (Convert.ToDouble(this.HealthModel.BMI) >= 25 && Convert.ToDouble(this.HealthModel.BMI) < 26)
                                    {
                                        row.Cells[1].Value = 3;
                                    }
                                    else if (Convert.ToDouble(this.HealthModel.BMI) >= 26 && Convert.ToDouble(this.HealthModel.BMI) < 28)
                                    {
                                        row.Cells[1].Value = 4;
                                    }
                                    else if (Convert.ToDouble(this.HealthModel.BMI) >= 28)
                                    {
                                        row.Cells[1].Value = 5;
                                    }
                                }
                                else
                                    row.Cells[1].Value = 1;
                            }
                            else if (num == 0)
                            {
                                row.Cells[1].Value = 5;
                            }
                            //else if (num == 27)
                            //{
                            //    if (!string.IsNullOrEmpty(Convert.ToString(this.HealthModel.Waistline)))
                            //    {
                            //        if (Convert.ToDouble(this.generalconditionmodel.Waistline) < 80)
                            //        {
                            //            row.Cells[1].Value = 1;
                            //        }
                            //        else if (Convert.ToDouble(this.generalconditionmodel.Waistline) >= 80 && Convert.ToDouble(this.generalconditionmodel.Waistline) <= 85)
                            //        {
                            //            row.Cells[1].Value = 2;
                            //        }
                            //        else if (Convert.ToDouble(this.generalconditionmodel.Waistline) >= 86 && Convert.ToDouble(this.generalconditionmodel.Waistline) <= 90)
                            //        {
                            //            row.Cells[1].Value = 3;
                            //        }
                            //        else if (Convert.ToDouble(this.generalconditionmodel.Waistline) >= 91 && Convert.ToDouble(this.generalconditionmodel.Waistline) <= 105)
                            //        {
                            //            row.Cells[1].Value = 4;
                            //        }
                            //        else if (Convert.ToDouble(this.generalconditionmodel.Waistline) > 105)
                            //        {
                            //            row.Cells[1].Value = 5;
                            //        }
                            //    }
                            //    else
                            //        row.Cells[1].Value = 1;
                            //}
                            else
                            {
                                row.Cells[1].Value = 1;
                            }
                            num++;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in (IEnumerable)this.dataGridView1.Rows)
                    {
                        DataGridViewComboBoxCell cell = row.Cells[1] as DataGridViewComboBoxCell;
                        if (cell != null)
                        {
                            DataRow row2 = this.xmlDs.Tables[0].Rows[num];
                            cell.DataSource = listArray[int.Parse(row2["select"].ToString())];
                            num++;
                        }
                    }
                }
            }
        }

        public void UpdataToModel()
        {
            this.MedCn.FollowUpDoctor = this.tbDoctor.Text.Trim();
            this.MedCn.RecordDate = this.dtpTypeDate.Value;
            if (!GlbTools.DatatableCompareModel<HealthHouseMedicineCnModel>(this.MedCn, this.xmlDs.Tables[0]))
            {
                GlbTools.DatatableFillModel<HealthHouseMedicineCnModel>(this.MedCn, this.xmlDs.Tables[0]);
                this.MedResult.FaintScore = new decimal?(this.GetScore(this.MedCn.Tired, this.MedCn.Breath, this.MedCn.Voice, this.MedCn.Influenza));
                this.MedResult.YangsCore = new decimal?(this.GetScore(this.MedCn.FootHand, this.MedCn.Stomach, this.MedCn.Cold, this.MedCn.Coolfood));
                this.MedResult.YinScore = new decimal?(this.GetScore(this.MedCn.Eye, this.MedCn.Mouth, this.MedCn.Thirsty, this.MedCn.Defecate));
                this.MedResult.PhlegmdampScore = new decimal?(this.GetScore(this.MedCn.Weight, this.MedCn.Snore, this.MedCn.Abdomen, this.MedCn.Tongue));
                this.MedResult.MuggyScore = new decimal?(this.GetScore(this.MedCn.Greasy, this.MedCn.Eczema, this.MedCn.Smell, this.MedCn.Defecate));
                this.MedResult.BloodStasisScore = new decimal?(this.GetScore(this.MedCn.Skin, this.MedCn.Arms, this.MedCn.Spot, this.MedCn.Vein));
                this.MedResult.QiConstraintScore = new decimal?(this.GetScore(this.MedCn.Emotion, this.MedCn.Spirit, this.MedCn.Alone, this.MedCn.Fear));
                this.MedResult.CharacteristicScore = new decimal?(this.GetScore(this.MedCn.Nasal, this.MedCn.Allergy, this.MedCn.Urticaria, this.MedCn.Scratch));
                this.MedResult.MildScore = new decimal?(this.GetPinghe(this.MedCn.Energy, this.MedCn.Tired, this.MedCn.Voice, this.MedCn.Emotion, this.MedCn.Cold));
                this.bindingManager.UpdateControl();
                this.UpdateJudge();
            }
        }

        private void UpdateJudge()
        {
            this.judge_qixu.UpdateResult();
            this.judge_yang.UpdateResult();
            this.judge_tanshi.UpdateResult();
            this.judge_yin.UpdateResult();
            this.judge_shire.UpdateResult();
            this.judge_xueyu.UpdateResult();
            this.judge_qiyu.UpdateResult();
            this.judge_tebing.UpdateResult();
            this.judgePinghebyScore();
            if (this.MedResultFlage)
            {
                if (this.rdQiXu_Yes.Checked == true || this.rdQiXu_QYes.Checked == true)
                {
                    this.ckQixu1.Checked = true;
                    this.ckQixu2.Checked = true;
                    this.ckQixu3.Checked = true;
                    this.ckQixu4.Checked = true;
                    this.ckQixu5.Checked = true;
                }
                else
                {
                    this.ckQixu1.Checked = false;
                    this.ckQixu2.Checked = false;
                    this.ckQixu3.Checked = false;
                    this.ckQixu4.Checked = false;
                    this.ckQixu5.Checked = false;
                }
                if (rdYangxu_Yes.Checked == true || this.rdYangxu_QYes.Checked == true)
                {
                    this.ckYangxu1.Checked = true;
                    this.ckYangxu2.Checked = true;
                    this.ckYangxu3.Checked = true;
                    this.ckYangxu4.Checked = true;
                    this.ckYangxu5.Checked = true;
                }
                else
                {
                    this.ckYangxu1.Checked = false;
                    this.ckYangxu2.Checked = false;
                    this.ckYangxu3.Checked = false;
                    this.ckYangxu4.Checked = false;
                    this.ckYangxu5.Checked = false;
                }
                if (this.rdYinxu_Yes.Checked == true || this.rdYinxu_QYes.Checked == true)
                {
                    this.ckYinxu1.Checked = true;
                    this.ckYinxu2.Checked = true;
                    this.ckYinxu3.Checked = true;
                    this.ckYinxu4.Checked = true;
                    this.ckYinxu5.Checked = true;
                }
                else
                {
                    this.ckYinxu1.Checked = false;
                    this.ckYinxu2.Checked = false;
                    this.ckYinxu3.Checked = false;
                    this.ckYinxu4.Checked = false;
                    this.ckYinxu5.Checked = false;
                }
                if (this.rdTanshi_Yes.Checked == true || this.rdTanshi_QYes.Checked == true)
                {
                    this.ckTans1.Checked = true;
                    this.ckTans2.Checked = true;
                    this.ckTans3.Checked = true;
                    this.ckTans4.Checked = true;
                    this.ckTans5.Checked = true;
                }
                else
                {
                    this.ckTans1.Checked = false;
                    this.ckTans2.Checked = false;
                    this.ckTans3.Checked = false;
                    this.ckTans4.Checked = false;
                    this.ckTans5.Checked = false;
                }
                if (this.rdShire_Yes.Checked == true || this.rdShire_QYes.Checked == true)
                {
                    this.ckShire1.Checked = true;
                    this.ckShire2.Checked = true;
                    this.ckShire3.Checked = true;
                    this.ckShire4.Checked = true;
                    this.ckShire5.Checked = true;
                }
                else
                {
                    this.ckShire1.Checked = false;
                    this.ckShire2.Checked = false;
                    this.ckShire3.Checked = false;
                    this.ckShire4.Checked = false;
                    this.ckShire5.Checked = false;
                }
                if (this.rdXueyu_QYes.Checked == true || this.rdXueyu_Yes.Checked == true)
                {
                    this.ckXueyu1.Checked = true;
                    this.ckXueyu2.Checked = true;
                    this.ckXueyu3.Checked = true;
                    this.ckXueyu4.Checked = true;
                    this.ckXueyu5.Checked = true;
                }
                else
                {
                    this.ckXueyu1.Checked = false;
                    this.ckXueyu2.Checked = false;
                    this.ckXueyu3.Checked = false;
                    this.ckXueyu4.Checked = false;
                    this.ckXueyu5.Checked = false;
                }

                if (this.rdQiyu_QYes.Checked == true || this.rdQiyu_Yes.Checked == true)
                {
                    this.ckQiyu1.Checked = true;
                    this.ckQiyu2.Checked = true;
                    this.ckQiyu3.Checked = true;
                    this.ckQiyu4.Checked = true;
                    this.ckQiyu5.Checked = true;
                }
                else
                {
                    this.ckQiyu1.Checked = false;
                    this.ckQiyu2.Checked = false;
                    this.ckQiyu3.Checked = false;
                    this.ckQiyu4.Checked = false;
                    this.ckQiyu5.Checked = false;
                }
                if (this.rdTebing_QYes.Checked == true || this.rdTebing_Yes.Checked == true)
                {
                    this.ckTebing1.Checked = true;
                    this.ckTebing2.Checked = true;
                    this.ckTebing3.Checked = true;
                    this.ckTebing4.Checked = true;
                    this.ckTebing5.Checked = true;
                }
                else
                {
                    this.ckTebing1.Checked = false;
                    this.ckTebing2.Checked = false;
                    this.ckTebing3.Checked = false;
                    this.ckTebing4.Checked = false;
                    this.ckTebing5.Checked = false;
                }
                if (this.rdPinghe_Yes.Checked == true || this.rdPinghe_QYes.Checked == true)
                {
                    this.ckPinghe1.Checked = true;
                    this.ckPinghe2.Checked = true;
                    this.ckPinghe3.Checked = true;
                    this.ckPinghe4.Checked = true;
                    this.ckPinghe5.Checked = true;
                }
                else
                {
                    this.ckPinghe1.Checked = false;
                    this.ckPinghe2.Checked = false;
                    this.ckPinghe3.Checked = false;
                    this.ckPinghe4.Checked = false;
                    this.ckPinghe5.Checked = false;
                }
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }
        public HealthHouseModel HealthModel { get; set; }
        public string SaveDataInfo { get; set; }
    }
}

