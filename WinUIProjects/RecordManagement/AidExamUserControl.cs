
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using System.IO;
using System.Xml;
using KangShuoTech.Utilities.MySQLHelper;
using System.Configuration;

namespace ArchiveInfo
{
    public class AidExamUserControl : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private CSingleItem BCHAO;
        private CSingleItem BCHAOther;
        private SimpleBindingManager<RecordsAssistCheckModel> bindingManager;
        private Button btnCount;
        private Button btnECG;
        private Button btnGanYouSanZhi;
        private Button btnGaoMiDuDanBai;
        private Button btnReset_b;
        private Button btnReset_gj;
        private Button btnReset_qx;
        private Button btnReset_x;
        private Button btnReset_xd;
        private Button btnReset_yg;
        private Button btnSelectBE;
        private Button btnSelectBS;
        private Button btnSelectHB;
        private Button btnZongDGC;
        private IContainer components;
        private CSingleItem gongjingtupian;
        private GroupBox groupBox39;
        private GroupBox groupBox40;
        private GroupBox groupBox41;
        private GroupBox groupBox42;
        private GroupBox groupBox43;
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr>();
        private List<InputRangeDec> inputRanges = new List<InputRangeDec>();
        private Label label1;
        private Label label117;
        private Label label118;
        private Label label119;
        private Label label12;
        private Label label120;
        private Label label122;
        private Label label123;
        private Label label124;
        private Label label125;
        private Label label126;
        private Label label127;
        private Label label128;
        private Label label129;
        private Label label130;
        private Label label131;
        private Label label132;
        private Label label133;
        private Label label134;
        private Label label135;
        private Label label136;
        private Label label137;
        private Label label138;
        private Label label139;
        private Label label14;
        private Label label140;
        private Label label141;
        private Label label142;
        private Label label143;
        private Label label144;
        private Label label146;
        private Label label147;
        private Label label148;
        private Label label149;
        private Label label150;
        private Label label151;
        private Label label156;
        private Label label18;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label86;
        private Label label87;
        private Label label88;
        private Label label89;
        private Label label91;
        private Label label92;
        private Label label93;
        private LinkLabel lnklbEcg;
        private Panel panel16;
        private Panel panel17;
        private Panel panel18;
        private Panel panel19;
        private Panel panel2;
        private Panel panel20;
        private RadioButton radbcyc;
        private RadioButton radbczc;
        private RadioButton radgjtpyc;
        private RadioButton radgjtpzc;
        private RadioButton radqxyangx;
        private RadioButton radqxyx;
        private RadioButton radxbxxpyc;
        private RadioButton radxbxxpzc;
        private RadioButton radXDYC;
        private RadioButton radXDZC;
        private RadioButton radygyangx;
        private RadioButton radygyx;
        private TextBox tb_rGT;
        private TextBox tblBG;
        private TextBox tbNiaoQt;
        private TextBox txtbcyc;
        private TextBox txtbdb;
        private TextBox txtBXB;
        private TextBox txtgjtpyc;
        private TextBox txtgysz;
        private TextBox txtnwldb;
        private TextBox txtphxhdb;
        private TextBox txtqtqita;
        private TextBox txtxbxxpyc;
        private TextBox txtxcgQiTa;
        private TextBox txtXDYC;
        private TextBox txtXHDB;
        private TextBox txtxjnd;
        private TextBox txtxnnd;
        private TextBox txtxnsa;
        private TextBox txtxqdmdz;
        private TextBox txtxqgbzam;
        private TextBox txtxqgczam;
        private TextBox txtxqgmdz;
        private TextBox txtxqjh;
        private TextBox txtXXB;
        private TextBox txtzdgc;
        private TextBox txtzdhs;
        private TextBox txtzhdhs;
        private CSingleItem xindian;
        private Button btnshowECG;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox tbntGLU;
        private TextBox tbnqxBLD;
        private TextBox tbnttKET;
        private TextBox tbndbPRO;
        private TextBox tbchxt;
        private Label label10;
        private Label label5;
        private Label label13;
        private TextBox tbtxbgas;
        private Label label11;
        private Panel panel1;
        private Button btnReset_bqt;
        private RadioButton radbcqtyc;
        private RadioButton radbcqtzc;
        private TextBox txtbcqtyc;
        private Label label15;
        private Panel panel3;
        private CheckBox ckxdt9;
        private CheckBox ckxdt8;
        private CheckBox ckxdt7;
        private CheckBox ckxdt6;
        private CheckBox ckxdt5;
        private CheckBox ckxdt4;
        private CheckBox ckxdt3;
        private CheckBox ckxdt2;
        private CheckBox ckxdt1;
        private CSingleItem xiongbuX;
        private Label label16;
        private ComboBox cmbXieXin;
        private ComboBox cmbRH;
        private Label label186;
        private ManyCheckboxs<RecordsAssistCheckModel> ECG;
        private Button btnBChao;
        private DataTable dt_blood;
        private DataSet dsRequire;
        string community = ConfigHelper.GetSetNode("community");
        private string area = ConfigHelper.GetSetNode("area");
        string BChaoReport = ConfigurationManager.AppSettings["BChaoReport"] == null ? @"D:\QCSoft\TypeB" : ConfigurationManager.AppSettings["BChaoReport"].ToString();
        string ECGReport = ConfigurationManager.AppSettings["ECGReport"] == null ? @"D:\QCSoft\ECGPDF\outFile" : ConfigurationManager.AppSettings["ECGReport"].ToString();

        public AidExamUserControl()
        {
            this.InitializeComponent();
            this.inputrange_str.Add(new InputRangeStr("BloodOther", 30));
            this.inputrange_str.Add(new InputRangeStr("UrineOther", 100));
            this.inputrange_str.Add(new InputRangeStr("Other", 30));
            this.inputRanges.Add(new InputRangeDec("HB", 10000M));
            this.inputRanges.Add(new InputRangeDec("WBC", 1000M));
            this.inputRanges.Add(new InputRangeDec("PLT", 1000M));
            this.inputRanges.Add(new InputRangeDec("FPGL", 1000M));
            this.inputRanges.Add(new InputRangeDec("ALBUMIN", 1000M));
            this.inputRanges.Add(new InputRangeDec("HBALC", 1000M));
            this.inputRanges.Add(new InputRangeDec("SGPT", 1000M));
            this.inputRanges.Add(new InputRangeDec("GOT", 1000M));
            this.inputRanges.Add(new InputRangeDec("BP", 1000M));
            this.inputRanges.Add(new InputRangeDec("TBIL", 1000M));
            this.inputRanges.Add(new InputRangeDec("CB", 1000M));
            this.inputRanges.Add(new InputRangeDec("SCR", 1000M));
            this.inputRanges.Add(new InputRangeDec("BUN", 1000M));
            this.inputRanges.Add(new InputRangeDec("PC", 1000M));
            this.inputRanges.Add(new InputRangeDec("HYPE", 1000M));
            this.inputRanges.Add(new InputRangeDec("TC", 1000M));
            this.inputRanges.Add(new InputRangeDec("TG", 1000M));
            this.inputRanges.Add(new InputRangeDec("HCY", 1000M));
            InputRangeDec item = new InputRangeDec("LowCho", 1000M)
            {
                Min = -100M
            };
            this.inputRanges.Add(item);
            this.inputRanges.Add(new InputRangeDec("HeiCho", 1000M));
            this.inputRanges.Add(new InputRangeDec("FPGDL", 1000M));
            this.EveryThingIsOk = false;
        }

        private void bd_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                decimal num;
                decimal.TryParse(e.Value.ToString(), out num);
            }
        }

        private void bd_Parse(object sender, ConvertEventArgs e)
        {
            decimal num;
            Binding binding = sender as Binding;
            if (decimal.TryParse(e.Value.ToString(), out num))
            {
                if ((num >= 0M) && (num < 1000M))
                {
                    binding.Control.BackColor = Color.WhiteSmoke;
                    e.Value = num;
                }
                else
                {
                    binding.Control.BackColor = Color.Salmon;
                }
            }
            else
            {
                e.Value = null;
            }
        }

        private void bd_ParseStr(object sender, ConvertEventArgs e)
        {
            string s = e.Value as string;
            Binding bd = sender as Binding;
            InputRangeStr str2 = this.inputrange_str.Find(c => c.Name == bd.BindingMemberInfo.BindingField);
            if (str2 != null)
            {
                if (Encoding.GetEncoding("GB2312").GetByteCount(s) > str2.BytesCount)
                {
                    str2.ErrorInput = true;
                    bd.Control.BackColor = Color.Salmon;
                }
                else
                {
                    str2.ErrorInput = false;
                    bd.Control.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            decimal num;
            decimal num2;
            decimal num3;
            if ((decimal.TryParse(this.txtzdgc.Text, out num) && decimal.TryParse(this.txtxqgmdz.Text, out num2)) && decimal.TryParse(this.txtgysz.Text, out num3))
            {
                this.txtxqdmdz.Text = string.Format("{0:##0.00}", Math.Round((decimal)((num - num2) - (num3 / 2.2M)), 2));
            }
        }

        private void btnECG_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "97")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if ((select.ShowDialog() == DialogResult.OK) && (select.m_Result.value1 != ""))
            {
                if (select.m_Result.value1 == "正常范围心电图")
                {
                    this.AssistCheck.ECG = "1";
                }
                else
                {
                    this.AssistCheck.ECG = "2";
                    this.txtXDYC.Text = select.m_Result.value1.Replace('\n', ';').Replace('\r', ' ').Replace(" ", "");
                }
            }
        }

        private void btnGanYouSanZhi_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "35")
            {
                ItemTypeName = "血甘油三脂",
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.txtgysz.Text = select.m_Result.value1;
            }
        }

        private void btnGaoMiDuDanBai_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "35")
            {
                ItemTypeName = "血高密度脂蛋白",
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.txtxqgmdz.Text = select.m_Result.value1;
            }
        }

        private void btnReset_b_Click(object sender, EventArgs e) //腹部B超
        {
            this.txtbcyc.Text = string.Empty;
            this.radbcyc.Checked = false;
            this.radbczc.Checked = false;
            this.AssistCheck.BCHAO = string.Empty;
        }
        private void btnReset_bqt_Click(object sender, EventArgs e) //其他B超
        {
            this.txtbcqtyc.Text = string.Empty;
            this.radbcqtzc.Checked = false;
            this.radbcqtyc.Checked = false;
            this.AssistCheck.BCHAOther = string.Empty;
        }
        private void btnReset_gj_Click(object sender, EventArgs e)
        {
            this.txtgjtpyc.Text = string.Empty;
            this.radgjtpyc.Checked = false;
            this.radgjtpzc.Checked = false;
            this.AssistCheck.CERVIXEx = string.Empty;
        }

        private void btnReset_qx_Click(object sender, EventArgs e)
        {
            this.radqxyx.Checked = false;
            this.radqxyangx.Checked = false;
            this.AssistCheck.FOB = string.Empty;
        }

        private void btnReset_x_Click(object sender, EventArgs e)
        {
            this.txtxbxxpyc.Text = string.Empty;
            this.radxbxxpzc.Checked = false;
            this.radxbxxpyc.Checked = false;
            this.AssistCheck.CHESTX = string.Empty;
        }

        private void btnReset_xd_Click(object sender, EventArgs e)
        {
            this.txtXDYC.Text = string.Empty;
            this.radXDYC.Checked = false;
            this.radXDZC.Checked = false;
            this.AssistCheck.ECG = string.Empty;
        }

        private void btnReset_yg_Click(object sender, EventArgs e)
        {
            this.radygyx.Checked = false;
            this.radygyangx.Checked = false;
            this.AssistCheck.HBSAG = string.Empty;
        }

        private void btnSelectBE_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "33")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                if (area.Equals("济宁"))
                {
                    this.AssistCheck.PRO = GetExNiaoPlus(select.m_Result.value6.ToString());
                    this.AssistCheck.GLU = GetExNiaoPlus(select.m_Result.value5.ToString());
                    this.AssistCheck.KET = GetExNiaoPlus(select.m_Result.value4.ToString());
                    this.AssistCheck.BLD = GetExNiaoPlus(select.m_Result.value2.ToString());
                    this.tbndbPRO.Text = GetExNiaoPlus(select.m_Result.value6);
                    //this.tbNiao.Text = select.m_Result.value6 + "/" + select.m_Result.value5 + "/" + select.m_Result.value4 + "/" + select.m_Result.value2;
                    this.tbntGLU.Text = GetExNiaoPlus(select.m_Result.value5);
                    this.tbnttKET.Text = GetExNiaoPlus(select.m_Result.value4);
                    this.tbnqxBLD.Text = GetExNiaoPlus(select.m_Result.value2);
                }
                else
                {
                    this.AssistCheck.PRO = select.m_Result.value6.ToString();
                    this.AssistCheck.GLU = select.m_Result.value5.ToString();
                    this.AssistCheck.KET = select.m_Result.value4.ToString();
                    this.AssistCheck.BLD = select.m_Result.value2.ToString();
                    this.tbndbPRO.Text = select.m_Result.value6;
                    //this.tbNiao.Text = select.m_Result.value6 + "/" + select.m_Result.value5 + "/" + select.m_Result.value4 + "/" + select.m_Result.value2;
                    this.tbntGLU.Text = select.m_Result.value5;
                    this.tbnttKET.Text = select.m_Result.value4;
                    this.tbnqxBLD.Text = select.m_Result.value2;
                }

                string NiaoQt = "";
                if (!string.IsNullOrEmpty(select.m_Result.value1) && select.m_Result.value1.Contains('+'))
                {
                    NiaoQt = "尿胆原:" + select.m_Result.value1.ToString();
                }
                if (!string.IsNullOrEmpty(select.m_Result.value3) && select.m_Result.value3.Contains('+'))
                {
                    NiaoQt = "胆红素:" + select.m_Result.value3.ToString();
                }
                if (!string.IsNullOrEmpty(select.m_Result.value7) && select.m_Result.value7.Contains('+'))
                {
                    NiaoQt += " PH:" + select.m_Result.value7.ToString();
                }
                if (!string.IsNullOrEmpty(select.m_Result.value8) && select.m_Result.value8.Contains('+'))
                {
                    NiaoQt += " 亚硝酸盐:" + select.m_Result.value8.ToString();
                }
                if (!string.IsNullOrEmpty(select.m_Result.value9) && select.m_Result.value9.Contains('+'))
                {
                    NiaoQt += " 白细胞:" + select.m_Result.value9.ToString();
                }
                if (!string.IsNullOrEmpty(select.m_Result.value10) && select.m_Result.value10.Contains('+'))
                {
                    NiaoQt += " 比重:" + select.m_Result.value10.ToString();
                }
                if (!string.IsNullOrEmpty(select.m_Result.value11) && select.m_Result.value11.Contains('+'))
                {
                    NiaoQt += " 维生素C:" + select.m_Result.value11.ToString();
                }
                if (area.Equals("平度"))
                {
                    if (string.IsNullOrEmpty(NiaoQt))
                    {
                        NiaoQt = "-";
                    }
                }
                tbNiaoQt.Text = NiaoQt;

                this.AssistCheck.UrineOther = NiaoQt;
            }
        }

        private void btnSelectBS_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "24")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tblBG.Text = select.m_Result.value1;
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
                this.txtXHDB.Text = select.m_Result.value1;
            }
        }

        private void btnZongDGC_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "35")
            {
                ItemTypeName = "血总胆固醇",
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.txtzdgc.Text = select.m_Result.value1;
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            if (!this.bindingManager.ErrorInput)
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

        public void InitEveryThing()
        {
            dsRequire = new RequireBLL().GetList("TabName = '健康体检' AND Comment = '辅助检查' ");
            this.AssistCheck = new RecordsAssistCheckBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            this.CustomerBaseInfo = new RecordsCustomerBaseInfoBLL().GetModelByID(PhysicalInfoFactory.ID);

            if (this.AssistCheck == null)
            {
                this.AssistCheck = new RecordsAssistCheckModel();
            }
            this.bindingManager = new SimpleBindingManager<RecordsAssistCheckModel>(this.inputRanges, this.inputrange_str, this.AssistCheck);
            if (PhysicalInfoFactory.falgID == 0)
            {
                this.PresetValue();
            }
            this.bindingManager.SimpleBinding(this.txtXHDB, "HB", true); //血红蛋白
            this.bindingManager.SimpleBinding(this.txtBXB, "WBC", true); //白细胞
            this.bindingManager.SimpleBinding(this.txtXXB, "PLT", true);  //血小板
            this.bindingManager.SimpleBinding(this.txtxcgQiTa, "BloodOther", false); //血常规其他
            this.bindingManager.SimpleBinding(this.tblBG, "FPGL", true);  //空腹血糖
            this.bindingManager.SimpleBinding(this.tbchxt, "FPGDL", true); //餐后两小时血糖
            this.bindingManager.SimpleBinding(this.tbNiaoQt, "UrineOther", false); //尿常规其他

            if (!string.IsNullOrEmpty(this.AssistCheck.ECGEx))
            {
                this.AssistCheck.ECGEx = this.AssistCheck.ECGEx.Replace('\n', ';').Replace('\r', ' ').Replace(" ", "");
            }
            this.ECG = new ManyCheckboxs<RecordsAssistCheckModel>(this.AssistCheck, 500);
            this.ECG.AddCk(this.ckxdt1, true);
            this.ECG.AddCk(new CheckBox[] { this.ckxdt2, this.ckxdt3, this.ckxdt4, this.ckxdt5, this.ckxdt6, this.ckxdt7, this.ckxdt8 });
            this.ECG.AddCk(this.ckxdt9, this.txtXDYC);
            this.ECG.BindingProperty("ECG", "ECGEx");

            this.bindingManager.SimpleBinding(this.txtnwldb, "ALBUMIN", true);//尿微量蛋白
            if (!string.IsNullOrEmpty(this.AssistCheck.FOB)) //大便潜血
            {
                if (this.AssistCheck.FOB == "1")
                {
                    this.radqxyx.Checked = true;
                }
                else if (this.AssistCheck.FOB == "2")
                {
                    this.radqxyangx.Checked = true;
                }
            }

            this.bindingManager.SimpleBinding(this.txtphxhdb, "HBALC", true);//糖化血红蛋白
            if (!string.IsNullOrEmpty(this.AssistCheck.HBSAG)) //乙型肝炎表面抗原
            {
                if (this.AssistCheck.HBSAG == "1")
                {
                    this.radygyx.Checked = true;
                }
                else if (this.AssistCheck.HBSAG == "2")
                {
                    this.radygyangx.Checked = true;
                }
            }
            this.bindingManager.SimpleBinding(this.tbndbPRO, "PRO", false);//尿蛋白
            this.bindingManager.SimpleBinding(this.tbntGLU, "GLU", false);//尿糖
            this.bindingManager.SimpleBinding(this.tbnttKET, "KET", false);//尿酮体
            this.bindingManager.SimpleBinding(this.tbnqxBLD, "BLD", false); //尿潜血
            this.bindingManager.SimpleBinding(this.txtxqgbzam, "SGPT", true);//血清谷丙转氨酶
            this.bindingManager.SimpleBinding(this.txtxqgczam, "GOT", true); //血清谷草转氨酶
            this.bindingManager.SimpleBinding(this.txtbdb, "BP", true);//
            this.bindingManager.SimpleBinding(this.txtzhdhs, "CB", true);//
            this.bindingManager.SimpleBinding(this.tb_rGT, "GT", true);//
            this.bindingManager.SimpleBinding(this.txtzdhs, "TBIL", true);//
            this.bindingManager.SimpleBinding(this.txtxqjh, "SCR", true);//
            this.bindingManager.SimpleBinding(this.txtxnsa, "BUN", true);//
            this.bindingManager.SimpleBinding(this.txtxjnd, "PC", true);//
            this.bindingManager.SimpleBinding(this.txtxnnd, "HYPE", true);//
            this.bindingManager.SimpleBinding(this.txtzdgc, "TC", true);//
            this.bindingManager.SimpleBinding(this.txtxqdmdz, "LowCho", true);//
            this.bindingManager.SimpleBinding(this.txtgysz, "TG", true);//
            this.bindingManager.SimpleBinding(this.txtxqgmdz, "HeiCho", true);
            this.bindingManager.SimpleBinding(this.tbtxbgas, "HCY", true);//同型半胱氨酸
            CSingleItem item2 = new CSingleItem
            {
                Name = "胸部X射线",
                Usual = this.radxbxxpzc,
                Unusual = this.radxbxxpyc,
                Info = this.txtxbxxpyc
            };
            this.xiongbuX = item2;
            this.xiongbuX.TransInfo(this.AssistCheck.CHESTX, this.AssistCheck.CHESTXEx);
            CSingleItem item3 = new CSingleItem
            {
                Name = "腹部B超",
                Usual = this.radbczc,
                Unusual = this.radbcyc,
                Info = this.txtbcyc
            };
            this.BCHAO = item3;
            this.BCHAO.TransInfo(this.AssistCheck.BCHAO, this.AssistCheck.BCHAOEx);
            CSingleItem item4 = new CSingleItem
            {
                Name = "宫颈涂片",
                Usual = this.radgjtpzc,
                Unusual = this.radgjtpyc,
                Info = this.txtgjtpyc
            };
            this.gongjingtupian = item4;
            this.gongjingtupian.TransInfo(this.AssistCheck.CERVIX, this.AssistCheck.CERVIXEx);
            CSingleItem item5 = new CSingleItem
            {
                Name = "其他B超",
                Usual = this.radbcqtzc,
                Unusual = this.radbcqtyc,
                Info = this.txtbcqtyc
            };
            this.BCHAOther = item5;
            this.BCHAOther.TransInfo(this.AssistCheck.BCHAOther, this.AssistCheck.BCHAOtherEx);
            if (this.Model.Sex == "1")
            {
                this.gongjingtupian.Enableed = false;
                this.btnReset_gj.Enabled = false;
            }
            this.bindingManager.SimpleBinding(this.txtqtqita, "Other", false);

            this.EveryThingIsOk = true;
            string node = ConfigHelper.GetNode("ds_modify");
            if (string.IsNullOrEmpty(node))
            {
                node = "111110000000111";
                ConfigHelper.WriteNode("ds_modify", "111110000000111");
            }
            this.dt_blood = new DataTable();
            this.dt_blood.Columns.Add("Name", typeof(string));
            this.dt_blood.Columns.Add("Value", typeof(string));
            this.dt_blood.Rows.Add(new object[] { "无", "" });
            this.dt_blood.Rows.Add(new object[] { "A型", "1" });
            this.dt_blood.Rows.Add(new object[] { "B型", "2" });
            this.dt_blood.Rows.Add(new object[] { "O型", "3" });
            this.dt_blood.Rows.Add(new object[] { "AB型", "4" });
            this.cmbXieXin.DisplayMember = "Name";
            this.cmbXieXin.ValueMember = "Value";
            this.cmbXieXin.DataSource = this.dt_blood;
            this.cmbXieXin.SelectedValue = "";

            if (this.AssistCheck.BloodType!=null)
            {
                this.cmbXieXin.SelectedValue = this.AssistCheck.BloodType;
            }
            else if (!string.IsNullOrEmpty(this.Model.BloodType))
            {
                this.cmbXieXin.SelectedValue = this.Model.BloodType;
            }

            if (!string.IsNullOrEmpty(this.AssistCheck.RH))
            {
                this.cmbRH.SelectedIndex = int.Parse(this.AssistCheck.RH) - 1;
            }
            else if (!string.IsNullOrEmpty(this.Model.RH))
            {
                this.cmbRH.SelectedIndex = int.Parse(this.Model.RH) - 1;
            }

            MustChoose();
        }

        //默认项设置
        private void PresetValue()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = " IsSetValue='是' or IsSetValue='预设上次体检' ";
            DataTable dt = dv.ToTable();
            RecordsAssistCheckModel AssistChecks = new RecordsAssistCheckModel();
            RecordsCustomerBaseInfoModel CustomerBaseInfos = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.Model.IDCardNo);//获取最新一笔体检数据
            if (CustomerBaseInfos != null)
            {
                AssistChecks = new RecordsAssistCheckBLL().GetModelByOutKey(CustomerBaseInfos.ID);
            }

            if (AssistChecks == null) AssistChecks = new RecordsAssistCheckModel();
            foreach (DataRow item in dt.Rows)
            {
                switch (item["ChinName"].ToString())
                {
                    case "心电图":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.ECG = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.ECG = AssistChecks.ECG;
                            this.AssistCheck.ECGEx = AssistChecks.ECGEx;
                        }
                        break;
                    case "空腹血糖DL":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.FPGL = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.FPGL = AssistChecks.FPGL;
                        }
                        break;
                    case "其他":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.Other = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.Other = AssistChecks.Other;
                        }
                        break;
                    case "宫颈涂片":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.CERVIX = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.CERVIX = AssistChecks.CERVIX;
                            this.AssistCheck.CERVIXEx = AssistChecks.CERVIXEx;
                        }
                        break;
                    case "腹部B超":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.BCHAO = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.BCHAO = AssistChecks.BCHAO;
                            this.AssistCheck.BCHAOEx = AssistChecks.BCHAOEx;
                        }
                        break;
                    case "其他B超":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.BCHAOther = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.BCHAOther = AssistChecks.BCHAOther;
                            this.AssistCheck.BCHAOtherEx = AssistChecks.BCHAOtherEx;
                        }
                        break;
                    case "胸部X线片":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.CHESTX = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.CHESTX = AssistChecks.CHESTX;
                            this.AssistCheck.CHESTXEx = AssistChecks.CHESTXEx;
                        }
                        break;
                    case "血清高密度脂蛋白胆固醇":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.HeiCho = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.HeiCho = AssistChecks.HeiCho;
                        }
                        break;
                    case "甘油三酯":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.TG = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.TG = AssistChecks.TG;
                        }
                        break;
                    case "血清低密度脂蛋白胆固醇":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.LowCho = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.LowCho = AssistChecks.LowCho;
                        }
                        break;
                    case "总胆固醇":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.TC = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.TC = AssistChecks.TC;
                        }
                        break;
                    case "血钠浓度":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.HYPE = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.HYPE = AssistChecks.HYPE;
                        }
                        break;
                    case "血钾浓度":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.PC = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.PC = AssistChecks.PC;
                        }
                        break;
                    case "血尿素氮":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.BUN = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.BUN = AssistChecks.BUN;
                        }
                        break;
                    case "血清肌酐":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.SCR = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.SCR = AssistChecks.SCR;
                        }
                        break;
                    case "r-谷氨酰转肽酶":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.GT = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.GT = AssistChecks.GT;
                        }
                        break;
                    case "总胆红素":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.TBIL = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.TBIL = AssistChecks.TBIL;
                        }
                        break;
                    case "结合胆红素":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.CB = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.CB = AssistChecks.CB;
                        }
                        break;
                    case "白蛋白":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.BP = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.BP = AssistChecks.BP;
                        }
                        break;
                    case "血清谷草转氨酶":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.GOT = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.GOT = AssistChecks.GOT;
                        }
                        break;
                    case "血清谷丙转氨酶":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.SGPT = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.SGPT = AssistChecks.SGPT;
                        }
                        break;
                    case "乙型肝炎表面抗原":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.HBSAG = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.HBSAG = AssistChecks.HBSAG;
                        }
                        break;
                    case "糖化血红蛋白":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.HBALC = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.HBALC = AssistChecks.HBALC;
                        }
                        break;
                    case "大便潜血":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.FOB = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.FOB = AssistChecks.FOB;
                        }
                        break;
                    case "尿常规其他":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.UrineOther = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.UrineOther = AssistChecks.UrineOther;
                        }
                        break;
                    case "尿潜血":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.BLD = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.BLD = AssistChecks.BLD;
                        }
                        break;
                    case "尿酮体":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.KET = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.KET = AssistChecks.KET;
                        }
                        break;
                    case "尿糖":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.GLU = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.GLU = AssistChecks.GLU;
                        }
                        break;
                    case "尿蛋白":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.PRO = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.PRO = AssistChecks.PRO;
                        }
                        break;
                    case "尿微量白蛋白":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.ALBUMIN = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.ALBUMIN = AssistChecks.ALBUMIN;
                        }
                        break;
                    case "血常规其他":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.BloodOther = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.BloodOther = AssistChecks.BloodOther;
                        }
                        break;
                    case "血小板":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.PLT = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.PLT = AssistChecks.PLT;
                        }
                        break;
                    case "白细胞":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.WBC = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.WBC = AssistChecks.WBC;
                        }
                        break;
                    case "血红蛋白":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.HB = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.HB = AssistChecks.HB;
                        }
                        break;
                    case "餐后2小时血糖":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.FPGDL = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.FPGDL = AssistChecks.FPGDL;
                        }
                        break;
                    case "同型半胱氨酸":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                this.AssistCheck.HCY = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                            }
                        }
                        else
                        {
                            this.AssistCheck.HCY = AssistChecks.HCY;
                        }
                        break;
                    case "血型":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.BloodType = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.BloodType = AssistChecks.BloodType;
                        }
                        break;
                    case "RH":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.AssistCheck.RH = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.AssistCheck.RH = AssistChecks.RH;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void MustChoose()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = "IsRequired='1' ";
            DataTable dt = dv.ToTable();
            RecordsAssistCheckModel AssistChecks = new RecordsAssistCheckBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (AssistChecks == null) AssistChecks = new RecordsAssistCheckModel();

            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "空腹血糖DL":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.FPGL)))
                            {
                                this.label12.Text = "*空腹血糖";
                                this.label12.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label12.Text = "空腹血糖";
                                this.label12.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血红蛋白":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.HB)))
                            {
                                this.label86.Text = "*血红蛋白";
                                this.label86.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label86.Text = "血红蛋白";
                                this.label86.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "白细胞":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.WBC)))
                            {
                                this.label89.Text = "*白细胞";
                                this.label89.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label89.Text = "白细胞";
                                this.label89.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血小板":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.PLT)))
                            {
                                this.label92.Text = "*血小板";
                                this.label92.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label92.Text = "血小板";
                                this.label92.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血常规其他":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.BloodOther)))
                            {
                                this.label93.Text = "*血常规其他";
                                this.label93.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label93.Text = "血常规其他";
                                this.label93.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "尿微量白蛋白":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.ALBUMIN)))
                            {
                                this.label117.Text = "*尿微量白蛋白";
                                this.label117.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label117.Text = "尿微量白蛋白";
                                this.label117.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "尿蛋白":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.PRO)))
                            {
                                this.label6.Text = "*尿蛋白";
                                this.label6.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label6.Text = "尿蛋白";
                                this.label6.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "尿糖":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.GLU)))
                            {
                                this.label7.Text = "*尿糖";
                                this.label7.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label7.Text = "尿糖";
                                this.label7.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "尿酮体":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.KET)))
                            {
                                this.label8.Text = "*尿酮体";
                                this.label8.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label8.Text = "尿酮体";
                                this.label8.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "尿潜血":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.BLD)))
                            {
                                this.label9.Text = "*尿潜血";
                                this.label9.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label9.Text = "尿潜血";
                                this.label9.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "尿常规其他":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.UrineOther)))
                            {
                                this.label2.Text = "*尿常规其他";
                                this.label2.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label2.Text = "尿常规其他";
                                this.label2.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "大便潜血":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.FOB)))
                            {
                                this.label119.Text = "*大便潜血";
                                this.label119.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label119.Text = "大便潜血";
                                this.label119.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "糖化血红蛋白":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.HBALC)))
                            {
                                this.label120.Text = "*糖化血红蛋白";
                                this.label120.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label120.Text = "糖化血红蛋白";
                                this.label120.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "乙型肝炎表面抗原":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.HBSAG)))
                            {
                                this.label122.Text = "*乙型肝炎表面抗原";
                                this.label122.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label122.Text = "乙型肝炎表面抗原";
                                this.label122.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "心电图":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.ECG)))
                            {
                                this.btnshowECG.Text = "*心电图";
                                this.btnshowECG.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.btnshowECG.Text = "心电图";
                                this.btnshowECG.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "血清谷丙转氨酶":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.SGPT)))
                            {
                                this.label123.Text = "*血清谷丙转氨酶";
                                this.label123.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label123.Text = "血清谷丙转氨酶";
                                this.label123.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血清谷草转氨酶":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.GOT)))
                            {
                                this.label126.Text = "*血清谷草转氨酶";
                                this.label126.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label126.Text = "血清谷草转氨酶";
                                this.label126.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "白蛋白":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.BP)))
                            {
                                this.label128.Text = "*白蛋白";
                                this.label128.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label128.Text = "白蛋白";
                                this.label128.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "结合胆红素":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.CB)))
                            {
                                this.label132.Text = "*结合胆红素";
                                this.label132.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label132.Text = "结合胆红素";
                                this.label132.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "总胆红素":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.TBIL)))
                            {
                                this.label129.Text = "*总胆红素";
                                this.label129.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label129.Text = "总胆红素";
                                this.label129.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "r-谷氨酰转肽酶":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.GT)))
                            {
                                this.label4.Text = "*r-谷氨酰转肽酶";
                                this.label4.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label4.Text = "r-谷氨酰转肽酶";
                                this.label4.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血清肌酐":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.SCR)))
                            {
                                this.label142.Text = "*血清肌酐";
                                this.label142.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label142.Text = "血清肌酐";
                                this.label142.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血尿素氮":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.BUN)))
                            {
                                this.label140.Text = "*血尿素氮";
                                this.label140.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label140.Text = "血尿素氮";
                                this.label140.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血钾浓度":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.PC)))
                            {
                                this.label138.Text = "*血钾浓度";
                                this.label138.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label138.Text = "血钾浓度";
                                this.label138.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血钠浓度":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.HYPE)))
                            {
                                this.label134.Text = "*血钠浓度";
                                this.label134.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label134.Text = "血钠浓度";
                                this.label134.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "总胆固醇":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.TC)))
                            {
                                this.label148.Text = "*总胆固醇";
                                this.label148.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label148.Text = "总胆固醇";
                                this.label148.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血清低密度脂蛋白胆固醇":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.LowCho)))
                            {
                                this.label144.Text = "*血清低密度脂蛋白胆固醇";
                                this.label144.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label144.Text = "血清低密度脂蛋白胆固醇";
                                this.label144.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "甘油三酯":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.TG)))
                            {
                                this.label146.Text = "*甘油三酯";
                                this.label146.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label146.Text = "甘油三酯";
                                this.label146.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血清高密度脂蛋白胆固醇":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.HeiCho)))
                            {
                                this.label143.Text = "*血清高密度脂蛋白胆固醇";
                                this.label143.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label143.Text = "血清高密度脂蛋白胆固醇";
                                this.label143.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "胸部X线片":
                            if (string.IsNullOrEmpty(AssistChecks.CHESTX))
                            {
                                this.label156.Text = "*胸部X线片";
                                this.label156.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label156.Text = "胸部X线片";
                                this.label156.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "腹部B超":
                            if (string.IsNullOrEmpty(AssistChecks.BCHAO))
                            {
                                this.btnBChao.Text = "*B超";
                                this.btnBChao.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.btnBChao.Text = "B超";
                                this.btnBChao.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "其他B超":
                            if (string.IsNullOrEmpty(AssistChecks.BCHAOther))
                            {
                                this.label15.Text = "*其他B超";
                                this.label15.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label15.Text = "其他B超";
                                this.label15.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "宫颈涂片":
                            if (this.Model != null && Model.Sex == "2")
                            {
                                if (string.IsNullOrEmpty(AssistChecks.CERVIX))
                                {
                                    this.label150.Text = "*宫颈涂片";
                                    this.label150.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label150.Text = "宫颈涂片";
                                    this.label150.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "其他":
                            if (string.IsNullOrEmpty(AssistChecks.Other))
                            {
                                this.label151.Text = "*其他";
                                this.label151.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label151.Text = "其他";
                                this.label151.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "餐后2小时血糖":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.FPGDL)))
                            {
                                this.label5.Text = "*餐后2H血糖";
                                this.label5.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label5.Text = "餐后2H血糖";
                                this.label5.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "同型半胱氨酸":
                            if (string.IsNullOrEmpty(Convert.ToString(AssistChecks.HCY)))
                            {
                                this.label11.Text = "*同型半胱氨酸";
                                this.label11.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label11.Text = "同型半胱氨酸";
                                this.label11.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血型":
                            if (string.IsNullOrEmpty(AssistChecks.BloodType))
                            {
                                this.label16.Text = "*血型";
                                this.label16.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label16.Text = "血型";
                                this.label16.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "RH":
                            if (string.IsNullOrEmpty(AssistChecks.RH))
                            {
                                this.label186.Text = "*RH";
                                this.label186.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label186.Text = "RH";
                                this.label186.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        default: break;
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.groupBox43 = new System.Windows.Forms.GroupBox();
            this.btnBChao = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset_bqt = new System.Windows.Forms.Button();
            this.radbcqtyc = new System.Windows.Forms.RadioButton();
            this.radbcqtzc = new System.Windows.Forms.RadioButton();
            this.panel20 = new System.Windows.Forms.Panel();
            this.btnReset_b = new System.Windows.Forms.Button();
            this.radbcyc = new System.Windows.Forms.RadioButton();
            this.radbczc = new System.Windows.Forms.RadioButton();
            this.panel19 = new System.Windows.Forms.Panel();
            this.btnReset_x = new System.Windows.Forms.Button();
            this.radxbxxpyc = new System.Windows.Forms.RadioButton();
            this.radxbxxpzc = new System.Windows.Forms.RadioButton();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btnReset_gj = new System.Windows.Forms.Button();
            this.radgjtpyc = new System.Windows.Forms.RadioButton();
            this.radgjtpzc = new System.Windows.Forms.RadioButton();
            this.txtgjtpyc = new System.Windows.Forms.TextBox();
            this.label150 = new System.Windows.Forms.Label();
            this.txtbcqtyc = new System.Windows.Forms.TextBox();
            this.txtbcyc = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtxbxxpyc = new System.Windows.Forms.TextBox();
            this.label156 = new System.Windows.Forms.Label();
            this.txtqtqita = new System.Windows.Forms.TextBox();
            this.label151 = new System.Windows.Forms.Label();
            this.groupBox42 = new System.Windows.Forms.GroupBox();
            this.btnGaoMiDuDanBai = new System.Windows.Forms.Button();
            this.btnGanYouSanZhi = new System.Windows.Forms.Button();
            this.label149 = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.txtxqgmdz = new System.Windows.Forms.TextBox();
            this.label143 = new System.Windows.Forms.Label();
            this.txtgysz = new System.Windows.Forms.TextBox();
            this.label146 = new System.Windows.Forms.Label();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnZongDGC = new System.Windows.Forms.Button();
            this.label135 = new System.Windows.Forms.Label();
            this.txtxqdmdz = new System.Windows.Forms.TextBox();
            this.label144 = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.txtzdgc = new System.Windows.Forms.TextBox();
            this.label148 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnReset_xd = new System.Windows.Forms.Button();
            this.radXDYC = new System.Windows.Forms.RadioButton();
            this.radXDZC = new System.Windows.Forms.RadioButton();
            this.groupBox41 = new System.Windows.Forms.GroupBox();
            this.label133 = new System.Windows.Forms.Label();
            this.txtxnnd = new System.Windows.Forms.TextBox();
            this.label134 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.txtxjnd = new System.Windows.Forms.TextBox();
            this.label138 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.txtxnsa = new System.Windows.Forms.TextBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.txtxqjh = new System.Windows.Forms.TextBox();
            this.label142 = new System.Windows.Forms.Label();
            this.groupBox40 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.txtzhdhs = new System.Windows.Forms.TextBox();
            this.tb_rGT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.txtzdhs = new System.Windows.Forms.TextBox();
            this.label129 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.txtbdb = new System.Windows.Forms.TextBox();
            this.label128 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.txtxqgczam = new System.Windows.Forms.TextBox();
            this.label126 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.txtxqgbzam = new System.Windows.Forms.TextBox();
            this.label123 = new System.Windows.Forms.Label();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.cmbRH = new System.Windows.Forms.ComboBox();
            this.label186 = new System.Windows.Forms.Label();
            this.cmbXieXin = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckxdt9 = new System.Windows.Forms.CheckBox();
            this.ckxdt8 = new System.Windows.Forms.CheckBox();
            this.ckxdt7 = new System.Windows.Forms.CheckBox();
            this.ckxdt6 = new System.Windows.Forms.CheckBox();
            this.ckxdt5 = new System.Windows.Forms.CheckBox();
            this.ckxdt4 = new System.Windows.Forms.CheckBox();
            this.ckxdt3 = new System.Windows.Forms.CheckBox();
            this.ckxdt2 = new System.Windows.Forms.CheckBox();
            this.ckxdt1 = new System.Windows.Forms.CheckBox();
            this.tbntGLU = new System.Windows.Forms.TextBox();
            this.tbnqxBLD = new System.Windows.Forms.TextBox();
            this.tbnttKET = new System.Windows.Forms.TextBox();
            this.tbndbPRO = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnshowECG = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lnklbEcg = new System.Windows.Forms.LinkLabel();
            this.btnECG = new System.Windows.Forms.Button();
            this.tbNiaoQt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectHB = new System.Windows.Forms.Button();
            this.btnSelectBE = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtxcgQiTa = new System.Windows.Forms.TextBox();
            this.label93 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.txtXXB = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.txtBXB = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.txtXHDB = new System.Windows.Forms.TextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.tbchxt = new System.Windows.Forms.TextBox();
            this.tblBG = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReset_qx = new System.Windows.Forms.Button();
            this.radqxyangx = new System.Windows.Forms.RadioButton();
            this.radqxyx = new System.Windows.Forms.RadioButton();
            this.txtXDYC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectBS = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.btnReset_yg = new System.Windows.Forms.Button();
            this.radygyangx = new System.Windows.Forms.RadioButton();
            this.radygyx = new System.Windows.Forms.RadioButton();
            this.label122 = new System.Windows.Forms.Label();
            this.txtphxhdb = new System.Windows.Forms.TextBox();
            this.label120 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.tbtxbgas = new System.Windows.Forms.TextBox();
            this.txtnwldb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.groupBox43.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel18.SuspendLayout();
            this.groupBox42.SuspendLayout();
            this.panel16.SuspendLayout();
            this.groupBox41.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox43
            // 
            this.groupBox43.Controls.Add(this.btnBChao);
            this.groupBox43.Controls.Add(this.panel1);
            this.groupBox43.Controls.Add(this.panel20);
            this.groupBox43.Controls.Add(this.panel19);
            this.groupBox43.Controls.Add(this.panel18);
            this.groupBox43.Controls.Add(this.txtgjtpyc);
            this.groupBox43.Controls.Add(this.label150);
            this.groupBox43.Controls.Add(this.txtbcqtyc);
            this.groupBox43.Controls.Add(this.txtbcyc);
            this.groupBox43.Controls.Add(this.label15);
            this.groupBox43.Controls.Add(this.txtxbxxpyc);
            this.groupBox43.Controls.Add(this.label156);
            this.groupBox43.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox43.Location = new System.Drawing.Point(56, 494);
            this.groupBox43.Name = "groupBox43";
            this.groupBox43.Size = new System.Drawing.Size(1414, 136);
            this.groupBox43.TabIndex = 5;
            this.groupBox43.TabStop = false;
            this.groupBox43.Text = "*";
            // 
            // btnBChao
            // 
            this.btnBChao.Location = new System.Drawing.Point(77, 53);
            this.btnBChao.Name = "btnBChao";
            this.btnBChao.Size = new System.Drawing.Size(76, 32);
            this.btnBChao.TabIndex = 20;
            this.btnBChao.Text = "B超";
            this.btnBChao.UseVisualStyleBackColor = true;
            this.btnBChao.Click += new System.EventHandler(this.btnBChao_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReset_bqt);
            this.panel1.Controls.Add(this.radbcqtyc);
            this.panel1.Controls.Add(this.radbcqtzc);
            this.panel1.Location = new System.Drawing.Point(775, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 37);
            this.panel1.TabIndex = 2;
            // 
            // btnReset_bqt
            // 
            this.btnReset_bqt.Location = new System.Drawing.Point(182, 4);
            this.btnReset_bqt.Name = "btnReset_bqt";
            this.btnReset_bqt.Size = new System.Drawing.Size(87, 27);
            this.btnReset_bqt.TabIndex = 16;
            this.btnReset_bqt.Text = "重置";
            this.btnReset_bqt.UseVisualStyleBackColor = true;
            this.btnReset_bqt.Click += new System.EventHandler(this.btnReset_bqt_Click);
            // 
            // radbcqtyc
            // 
            this.radbcqtyc.AutoSize = true;
            this.radbcqtyc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radbcqtyc.Location = new System.Drawing.Point(95, 6);
            this.radbcqtyc.Name = "radbcqtyc";
            this.radbcqtyc.Size = new System.Drawing.Size(67, 24);
            this.radbcqtyc.TabIndex = 15;
            this.radbcqtyc.Text = "异常";
            this.radbcqtyc.UseVisualStyleBackColor = true;
            // 
            // radbcqtzc
            // 
            this.radbcqtzc.AutoSize = true;
            this.radbcqtzc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radbcqtzc.Location = new System.Drawing.Point(7, 7);
            this.radbcqtzc.Name = "radbcqtzc";
            this.radbcqtzc.Size = new System.Drawing.Size(67, 24);
            this.radbcqtzc.TabIndex = 14;
            this.radbcqtzc.Text = "正常";
            this.radbcqtzc.UseVisualStyleBackColor = true;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.btnReset_b);
            this.panel20.Controls.Add(this.radbcyc);
            this.panel20.Controls.Add(this.radbczc);
            this.panel20.Location = new System.Drawing.Point(160, 53);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(263, 37);
            this.panel20.TabIndex = 2;
            // 
            // btnReset_b
            // 
            this.btnReset_b.Location = new System.Drawing.Point(167, 4);
            this.btnReset_b.Name = "btnReset_b";
            this.btnReset_b.Size = new System.Drawing.Size(87, 27);
            this.btnReset_b.TabIndex = 16;
            this.btnReset_b.Text = "重置";
            this.btnReset_b.UseVisualStyleBackColor = true;
            this.btnReset_b.Click += new System.EventHandler(this.btnReset_b_Click);
            // 
            // radbcyc
            // 
            this.radbcyc.AutoSize = true;
            this.radbcyc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radbcyc.Location = new System.Drawing.Point(92, 7);
            this.radbcyc.Name = "radbcyc";
            this.radbcyc.Size = new System.Drawing.Size(67, 24);
            this.radbcyc.TabIndex = 15;
            this.radbcyc.Text = "异常";
            this.radbcyc.UseVisualStyleBackColor = true;
            // 
            // radbczc
            // 
            this.radbczc.AutoSize = true;
            this.radbczc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radbczc.Location = new System.Drawing.Point(7, 7);
            this.radbczc.Name = "radbczc";
            this.radbczc.Size = new System.Drawing.Size(67, 24);
            this.radbczc.TabIndex = 14;
            this.radbczc.Text = "正常";
            this.radbczc.UseVisualStyleBackColor = true;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.btnReset_x);
            this.panel19.Controls.Add(this.radxbxxpyc);
            this.panel19.Controls.Add(this.radxbxxpzc);
            this.panel19.Location = new System.Drawing.Point(160, 15);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(263, 39);
            this.panel19.TabIndex = 0;
            // 
            // btnReset_x
            // 
            this.btnReset_x.Location = new System.Drawing.Point(167, 3);
            this.btnReset_x.Name = "btnReset_x";
            this.btnReset_x.Size = new System.Drawing.Size(87, 27);
            this.btnReset_x.TabIndex = 13;
            this.btnReset_x.Text = "重置";
            this.btnReset_x.UseVisualStyleBackColor = true;
            this.btnReset_x.Click += new System.EventHandler(this.btnReset_x_Click);
            // 
            // radxbxxpyc
            // 
            this.radxbxxpyc.AutoSize = true;
            this.radxbxxpyc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radxbxxpyc.Location = new System.Drawing.Point(92, 7);
            this.radxbxxpyc.Name = "radxbxxpyc";
            this.radxbxxpyc.Size = new System.Drawing.Size(67, 24);
            this.radxbxxpyc.TabIndex = 12;
            this.radxbxxpyc.Text = "异常";
            this.radxbxxpyc.UseVisualStyleBackColor = true;
            // 
            // radxbxxpzc
            // 
            this.radxbxxpzc.AutoSize = true;
            this.radxbxxpzc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radxbxxpzc.Location = new System.Drawing.Point(8, 7);
            this.radxbxxpzc.Name = "radxbxxpzc";
            this.radxbxxpzc.Size = new System.Drawing.Size(67, 24);
            this.radxbxxpzc.TabIndex = 11;
            this.radxbxxpzc.Text = "正常";
            this.radxbxxpzc.UseVisualStyleBackColor = true;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.btnReset_gj);
            this.panel18.Controls.Add(this.radgjtpyc);
            this.panel18.Controls.Add(this.radgjtpzc);
            this.panel18.Location = new System.Drawing.Point(160, 90);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(263, 39);
            this.panel18.TabIndex = 4;
            // 
            // btnReset_gj
            // 
            this.btnReset_gj.Location = new System.Drawing.Point(168, 4);
            this.btnReset_gj.Name = "btnReset_gj";
            this.btnReset_gj.Size = new System.Drawing.Size(87, 27);
            this.btnReset_gj.TabIndex = 24;
            this.btnReset_gj.Text = "重置";
            this.btnReset_gj.UseVisualStyleBackColor = true;
            this.btnReset_gj.Click += new System.EventHandler(this.btnReset_gj_Click);
            // 
            // radgjtpyc
            // 
            this.radgjtpyc.AutoSize = true;
            this.radgjtpyc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radgjtpyc.Location = new System.Drawing.Point(92, 6);
            this.radgjtpyc.Name = "radgjtpyc";
            this.radgjtpyc.Size = new System.Drawing.Size(67, 24);
            this.radgjtpyc.TabIndex = 23;
            this.radgjtpyc.Text = "异常";
            this.radgjtpyc.UseVisualStyleBackColor = true;
            // 
            // radgjtpzc
            // 
            this.radgjtpzc.AutoSize = true;
            this.radgjtpzc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radgjtpzc.Location = new System.Drawing.Point(8, 7);
            this.radgjtpzc.Name = "radgjtpzc";
            this.radgjtpzc.Size = new System.Drawing.Size(67, 24);
            this.radgjtpzc.TabIndex = 22;
            this.radgjtpzc.Text = "正常";
            this.radgjtpzc.UseVisualStyleBackColor = true;
            // 
            // txtgjtpyc
            // 
            this.txtgjtpyc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtgjtpyc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtgjtpyc.Location = new System.Drawing.Point(448, 91);
            this.txtgjtpyc.MaxLength = 100;
            this.txtgjtpyc.Name = "txtgjtpyc";
            this.txtgjtpyc.ReadOnly = true;
            this.txtgjtpyc.Size = new System.Drawing.Size(803, 30);
            this.txtgjtpyc.TabIndex = 5;
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label150.Location = new System.Drawing.Point(64, 96);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(89, 20);
            this.label150.TabIndex = 19;
            this.label150.Text = "宫颈涂片";
            // 
            // txtbcqtyc
            // 
            this.txtbcqtyc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtbcqtyc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbcqtyc.Location = new System.Drawing.Point(1104, 55);
            this.txtbcqtyc.MaxLength = 100;
            this.txtbcqtyc.Name = "txtbcqtyc";
            this.txtbcqtyc.ReadOnly = true;
            this.txtbcqtyc.Size = new System.Drawing.Size(147, 30);
            this.txtbcqtyc.TabIndex = 3;
            // 
            // txtbcyc
            // 
            this.txtbcyc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtbcyc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbcyc.Location = new System.Drawing.Point(447, 55);
            this.txtbcyc.MaxLength = 100;
            this.txtbcyc.Name = "txtbcyc";
            this.txtbcyc.ReadOnly = true;
            this.txtbcyc.Size = new System.Drawing.Size(223, 30);
            this.txtbcyc.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(688, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 20);
            this.label15.TabIndex = 11;
            this.label15.Text = "其他B超";
            // 
            // txtxbxxpyc
            // 
            this.txtxbxxpyc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtxbxxpyc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxbxxpyc.Location = new System.Drawing.Point(447, 19);
            this.txtxbxxpyc.MaxLength = 100;
            this.txtxbxxpyc.Name = "txtxbxxpyc";
            this.txtxbxxpyc.ReadOnly = true;
            this.txtxbxxpyc.Size = new System.Drawing.Size(804, 30);
            this.txtxbxxpyc.TabIndex = 1;
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label156.Location = new System.Drawing.Point(54, 23);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(99, 20);
            this.label156.TabIndex = 9;
            this.label156.Text = "胸部X线片";
            // 
            // txtqtqita
            // 
            this.txtqtqita.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtqtqita.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtqtqita.Location = new System.Drawing.Point(139, 632);
            this.txtqtqita.MaxLength = 100;
            this.txtqtqita.Name = "txtqtqita";
            this.txtqtqita.Size = new System.Drawing.Size(1062, 30);
            this.txtqtqita.TabIndex = 6;
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label151.Location = new System.Drawing.Point(71, 635);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(59, 20);
            this.label151.TabIndex = 23;
            this.label151.Text = "其他*";
            // 
            // groupBox42
            // 
            this.groupBox42.Controls.Add(this.btnGaoMiDuDanBai);
            this.groupBox42.Controls.Add(this.btnGanYouSanZhi);
            this.groupBox42.Controls.Add(this.label149);
            this.groupBox42.Controls.Add(this.label136);
            this.groupBox42.Controls.Add(this.txtxqgmdz);
            this.groupBox42.Controls.Add(this.label143);
            this.groupBox42.Controls.Add(this.txtgysz);
            this.groupBox42.Controls.Add(this.label146);
            this.groupBox42.Controls.Add(this.btnCount);
            this.groupBox42.Controls.Add(this.btnZongDGC);
            this.groupBox42.Controls.Add(this.label135);
            this.groupBox42.Controls.Add(this.txtxqdmdz);
            this.groupBox42.Controls.Add(this.label144);
            this.groupBox42.Controls.Add(this.label147);
            this.groupBox42.Controls.Add(this.txtzdgc);
            this.groupBox42.Controls.Add(this.label148);
            this.groupBox42.Controls.Add(this.panel16);
            this.groupBox42.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox42.Location = new System.Drawing.Point(56, 402);
            this.groupBox42.Name = "groupBox42";
            this.groupBox42.Size = new System.Drawing.Size(1414, 89);
            this.groupBox42.TabIndex = 4;
            this.groupBox42.TabStop = false;
            this.groupBox42.Text = "血脂*";
            // 
            // btnGaoMiDuDanBai
            // 
            this.btnGaoMiDuDanBai.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGaoMiDuDanBai.Location = new System.Drawing.Point(880, 52);
            this.btnGaoMiDuDanBai.Name = "btnGaoMiDuDanBai";
            this.btnGaoMiDuDanBai.Size = new System.Drawing.Size(61, 31);
            this.btnGaoMiDuDanBai.TabIndex = 7;
            this.btnGaoMiDuDanBai.Text = "...";
            this.btnGaoMiDuDanBai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGaoMiDuDanBai.UseVisualStyleBackColor = true;
            this.btnGaoMiDuDanBai.Click += new System.EventHandler(this.btnGaoMiDuDanBai_Click);
            // 
            // btnGanYouSanZhi
            // 
            this.btnGanYouSanZhi.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGanYouSanZhi.Location = new System.Drawing.Point(353, 52);
            this.btnGanYouSanZhi.Name = "btnGanYouSanZhi";
            this.btnGanYouSanZhi.Size = new System.Drawing.Size(47, 31);
            this.btnGanYouSanZhi.TabIndex = 5;
            this.btnGanYouSanZhi.Text = "...";
            this.btnGanYouSanZhi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGanYouSanZhi.UseVisualStyleBackColor = true;
            this.btnGanYouSanZhi.Click += new System.EventHandler(this.btnGanYouSanZhi_Click);
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label149.Location = new System.Drawing.Point(280, 60);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(69, 20);
            this.label149.TabIndex = 21;
            this.label149.Text = "mmol/L";
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label136.Location = new System.Drawing.Point(797, 59);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(69, 20);
            this.label136.TabIndex = 20;
            this.label136.Text = "mmol/L";
            // 
            // txtxqgmdz
            // 
            this.txtxqgmdz.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtxqgmdz.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxqgmdz.Location = new System.Drawing.Point(682, 55);
            this.txtxqgmdz.MaxLength = 5;
            this.txtxqgmdz.Name = "txtxqgmdz";
            this.txtxqgmdz.Size = new System.Drawing.Size(103, 30);
            this.txtxqgmdz.TabIndex = 6;
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label143.Location = new System.Drawing.Point(445, 59);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(229, 20);
            this.label143.TabIndex = 18;
            this.label143.Text = "血清高密度脂蛋白胆固醇";
            // 
            // txtgysz
            // 
            this.txtgysz.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtgysz.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtgysz.Location = new System.Drawing.Point(162, 55);
            this.txtgysz.MaxLength = 5;
            this.txtgysz.Name = "txtgysz";
            this.txtgysz.Size = new System.Drawing.Size(103, 30);
            this.txtgysz.TabIndex = 4;
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label146.Location = new System.Drawing.Point(64, 63);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(89, 20);
            this.label146.TabIndex = 12;
            this.label146.Text = "甘油三酯";
            // 
            // btnCount
            // 
            this.btnCount.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCount.Location = new System.Drawing.Point(879, 13);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(62, 31);
            this.btnCount.TabIndex = 3;
            this.btnCount.Text = "计算";
            this.btnCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnZongDGC
            // 
            this.btnZongDGC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZongDGC.Location = new System.Drawing.Point(353, 14);
            this.btnZongDGC.Name = "btnZongDGC";
            this.btnZongDGC.Size = new System.Drawing.Size(47, 31);
            this.btnZongDGC.TabIndex = 1;
            this.btnZongDGC.Text = "...";
            this.btnZongDGC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZongDGC.UseVisualStyleBackColor = true;
            this.btnZongDGC.Click += new System.EventHandler(this.btnZongDGC_Click);
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label135.Location = new System.Drawing.Point(797, 25);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(69, 20);
            this.label135.TabIndex = 24;
            this.label135.Text = "mmol/L";
            // 
            // txtxqdmdz
            // 
            this.txtxqdmdz.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtxqdmdz.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxqdmdz.Location = new System.Drawing.Point(681, 19);
            this.txtxqdmdz.MaxLength = 5;
            this.txtxqdmdz.Name = "txtxqdmdz";
            this.txtxqdmdz.Size = new System.Drawing.Size(103, 30);
            this.txtxqdmdz.TabIndex = 2;
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label144.Location = new System.Drawing.Point(445, 22);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(229, 20);
            this.label144.TabIndex = 22;
            this.label144.Text = "血清低密度脂蛋白胆固醇";
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label147.Location = new System.Drawing.Point(280, 18);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(69, 20);
            this.label147.TabIndex = 11;
            this.label147.Text = "mmol/L";
            // 
            // txtzdgc
            // 
            this.txtzdgc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtzdgc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzdgc.Location = new System.Drawing.Point(162, 19);
            this.txtzdgc.MaxLength = 5;
            this.txtzdgc.Name = "txtzdgc";
            this.txtzdgc.Size = new System.Drawing.Size(103, 30);
            this.txtzdgc.TabIndex = 0;
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label148.Location = new System.Drawing.Point(64, 29);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(89, 20);
            this.label148.TabIndex = 9;
            this.label148.Text = "总胆固醇";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.btnReset_xd);
            this.panel16.Controls.Add(this.radXDYC);
            this.panel16.Controls.Add(this.radXDZC);
            this.panel16.Location = new System.Drawing.Point(1048, 17);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(268, 36);
            this.panel16.TabIndex = 17;
            this.panel16.Visible = false;
            // 
            // btnReset_xd
            // 
            this.btnReset_xd.Location = new System.Drawing.Point(167, 2);
            this.btnReset_xd.Name = "btnReset_xd";
            this.btnReset_xd.Size = new System.Drawing.Size(87, 27);
            this.btnReset_xd.TabIndex = 37;
            this.btnReset_xd.Text = "重置";
            this.btnReset_xd.UseVisualStyleBackColor = true;
            this.btnReset_xd.Click += new System.EventHandler(this.btnReset_xd_Click);
            // 
            // radXDYC
            // 
            this.radXDYC.AutoSize = true;
            this.radXDYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radXDYC.Location = new System.Drawing.Point(81, 6);
            this.radXDYC.Name = "radXDYC";
            this.radXDYC.Size = new System.Drawing.Size(67, 24);
            this.radXDYC.TabIndex = 36;
            this.radXDYC.Text = "异常";
            this.radXDYC.UseVisualStyleBackColor = true;
            // 
            // radXDZC
            // 
            this.radXDZC.AutoSize = true;
            this.radXDZC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radXDZC.Location = new System.Drawing.Point(3, 6);
            this.radXDZC.Name = "radXDZC";
            this.radXDZC.Size = new System.Drawing.Size(67, 24);
            this.radXDZC.TabIndex = 35;
            this.radXDZC.Text = "正常";
            this.radXDZC.UseVisualStyleBackColor = true;
            // 
            // groupBox41
            // 
            this.groupBox41.Controls.Add(this.label133);
            this.groupBox41.Controls.Add(this.txtxnnd);
            this.groupBox41.Controls.Add(this.label134);
            this.groupBox41.Controls.Add(this.label137);
            this.groupBox41.Controls.Add(this.txtxjnd);
            this.groupBox41.Controls.Add(this.label138);
            this.groupBox41.Controls.Add(this.label139);
            this.groupBox41.Controls.Add(this.txtxnsa);
            this.groupBox41.Controls.Add(this.label140);
            this.groupBox41.Controls.Add(this.label141);
            this.groupBox41.Controls.Add(this.txtxqjh);
            this.groupBox41.Controls.Add(this.label142);
            this.groupBox41.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox41.Location = new System.Drawing.Point(56, 345);
            this.groupBox41.Name = "groupBox41";
            this.groupBox41.Size = new System.Drawing.Size(1414, 56);
            this.groupBox41.TabIndex = 3;
            this.groupBox41.TabStop = false;
            this.groupBox41.Text = "肾功能*";
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label133.Location = new System.Drawing.Point(1170, 23);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(69, 20);
            this.label133.TabIndex = 26;
            this.label133.Text = "mmol/L";
            // 
            // txtxnnd
            // 
            this.txtxnnd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtxnnd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxnnd.Location = new System.Drawing.Point(1062, 19);
            this.txtxnnd.MaxLength = 5;
            this.txtxnnd.Name = "txtxnnd";
            this.txtxnnd.Size = new System.Drawing.Size(103, 30);
            this.txtxnnd.TabIndex = 25;
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label134.Location = new System.Drawing.Point(969, 24);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(89, 20);
            this.label134.TabIndex = 24;
            this.label134.Text = "血钠浓度";
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label137.Location = new System.Drawing.Point(872, 23);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(69, 20);
            this.label137.TabIndex = 17;
            this.label137.Text = "mmol/L";
            // 
            // txtxjnd
            // 
            this.txtxjnd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtxjnd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxjnd.Location = new System.Drawing.Point(763, 19);
            this.txtxjnd.MaxLength = 5;
            this.txtxjnd.Name = "txtxjnd";
            this.txtxjnd.Size = new System.Drawing.Size(103, 30);
            this.txtxjnd.TabIndex = 16;
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label138.Location = new System.Drawing.Point(668, 24);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(89, 20);
            this.label138.TabIndex = 15;
            this.label138.Text = "血钾浓度";
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label139.Location = new System.Drawing.Point(569, 24);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(69, 20);
            this.label139.TabIndex = 14;
            this.label139.Text = "mmol/L";
            // 
            // txtxnsa
            // 
            this.txtxnsa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtxnsa.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxnsa.Location = new System.Drawing.Point(484, 20);
            this.txtxnsa.MaxLength = 5;
            this.txtxnsa.Name = "txtxnsa";
            this.txtxnsa.Size = new System.Drawing.Size(79, 30);
            this.txtxnsa.TabIndex = 13;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label140.Location = new System.Drawing.Point(393, 27);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(89, 20);
            this.label140.TabIndex = 12;
            this.label140.Text = "血尿素氮";
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label141.Location = new System.Drawing.Point(275, 28);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(79, 20);
            this.label141.TabIndex = 11;
            this.label141.Text = "μmol/L";
            // 
            // txtxqjh
            // 
            this.txtxqjh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtxqjh.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxqjh.Location = new System.Drawing.Point(162, 24);
            this.txtxqjh.MaxLength = 5;
            this.txtxqjh.Name = "txtxqjh";
            this.txtxqjh.Size = new System.Drawing.Size(101, 30);
            this.txtxqjh.TabIndex = 10;
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label142.Location = new System.Drawing.Point(64, 27);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(89, 20);
            this.label142.TabIndex = 9;
            this.label142.Text = "血清肌酐";
            // 
            // groupBox40
            // 
            this.groupBox40.Controls.Add(this.label3);
            this.groupBox40.Controls.Add(this.label131);
            this.groupBox40.Controls.Add(this.txtzhdhs);
            this.groupBox40.Controls.Add(this.tb_rGT);
            this.groupBox40.Controls.Add(this.label4);
            this.groupBox40.Controls.Add(this.label132);
            this.groupBox40.Controls.Add(this.label130);
            this.groupBox40.Controls.Add(this.txtzdhs);
            this.groupBox40.Controls.Add(this.label129);
            this.groupBox40.Controls.Add(this.label127);
            this.groupBox40.Controls.Add(this.txtbdb);
            this.groupBox40.Controls.Add(this.label128);
            this.groupBox40.Controls.Add(this.label125);
            this.groupBox40.Controls.Add(this.txtxqgczam);
            this.groupBox40.Controls.Add(this.label126);
            this.groupBox40.Controls.Add(this.label124);
            this.groupBox40.Controls.Add(this.txtxqgbzam);
            this.groupBox40.Controls.Add(this.label123);
            this.groupBox40.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox40.Location = new System.Drawing.Point(56, 250);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Size = new System.Drawing.Size(1414, 94);
            this.groupBox40.TabIndex = 2;
            this.groupBox40.TabStop = false;
            this.groupBox40.Text = "肝功能*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(1173, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "U/L";
            this.label3.Visible = false;
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label131.Location = new System.Drawing.Point(273, 62);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(79, 20);
            this.label131.TabIndex = 26;
            this.label131.Text = "μmol/L";
            // 
            // txtzhdhs
            // 
            this.txtzhdhs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtzhdhs.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzhdhs.Location = new System.Drawing.Point(162, 58);
            this.txtzhdhs.MaxLength = 5;
            this.txtzhdhs.Name = "txtzhdhs";
            this.txtzhdhs.Size = new System.Drawing.Size(103, 30);
            this.txtzhdhs.TabIndex = 3;
            // 
            // tb_rGT
            // 
            this.tb_rGT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tb_rGT.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_rGT.Location = new System.Drawing.Point(1061, 58);
            this.tb_rGT.MaxLength = 5;
            this.tb_rGT.Name = "tb_rGT";
            this.tb_rGT.Size = new System.Drawing.Size(103, 30);
            this.tb_rGT.TabIndex = 5;
            this.tb_rGT.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(910, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "r-谷氨酰转肽酶";
            this.label4.Visible = false;
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label132.Location = new System.Drawing.Point(44, 62);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(109, 20);
            this.label132.TabIndex = 24;
            this.label132.Text = "结合胆红素";
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label130.Location = new System.Drawing.Point(753, 58);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(79, 20);
            this.label130.TabIndex = 20;
            this.label130.Text = "μmol/L";
            // 
            // txtzdhs
            // 
            this.txtzdhs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtzdhs.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzdhs.Location = new System.Drawing.Point(637, 56);
            this.txtzdhs.MaxLength = 5;
            this.txtzdhs.Name = "txtzdhs";
            this.txtzdhs.Size = new System.Drawing.Size(103, 30);
            this.txtzdhs.TabIndex = 4;
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label129.Location = new System.Drawing.Point(538, 59);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(89, 20);
            this.label129.TabIndex = 18;
            this.label129.Text = "总胆红素";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label127.Location = new System.Drawing.Point(1173, 22);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(39, 20);
            this.label127.TabIndex = 17;
            this.label127.Text = "g/L";
            // 
            // txtbdb
            // 
            this.txtbdb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtbdb.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbdb.Location = new System.Drawing.Point(1061, 17);
            this.txtbdb.MaxLength = 5;
            this.txtbdb.Name = "txtbdb";
            this.txtbdb.Size = new System.Drawing.Size(103, 30);
            this.txtbdb.TabIndex = 2;
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label128.Location = new System.Drawing.Point(990, 22);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(69, 20);
            this.label128.TabIndex = 15;
            this.label128.Text = "白蛋白";
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label125.Location = new System.Drawing.Point(754, 21);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(39, 20);
            this.label125.TabIndex = 14;
            this.label125.Text = "U/L";
            // 
            // txtxqgczam
            // 
            this.txtxqgczam.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtxqgczam.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxqgczam.Location = new System.Drawing.Point(636, 18);
            this.txtxqgczam.MaxLength = 5;
            this.txtxqgczam.Name = "txtxqgczam";
            this.txtxqgczam.Size = new System.Drawing.Size(103, 30);
            this.txtxqgczam.TabIndex = 1;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label126.Location = new System.Drawing.Point(478, 21);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(149, 20);
            this.label126.TabIndex = 12;
            this.label126.Text = "血清谷草转氨酶";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label124.Location = new System.Drawing.Point(278, 24);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(39, 20);
            this.label124.TabIndex = 11;
            this.label124.Text = "U/L";
            // 
            // txtxqgbzam
            // 
            this.txtxqgbzam.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtxqgbzam.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxqgbzam.Location = new System.Drawing.Point(162, 22);
            this.txtxqgbzam.MaxLength = 5;
            this.txtxqgbzam.Name = "txtxqgbzam";
            this.txtxqgbzam.Size = new System.Drawing.Size(103, 30);
            this.txtxqgbzam.TabIndex = 0;
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label123.Location = new System.Drawing.Point(4, 27);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(149, 20);
            this.label123.TabIndex = 9;
            this.label123.Text = "血清谷丙转氨酶";
            // 
            // groupBox39
            // 
            this.groupBox39.Controls.Add(this.cmbRH);
            this.groupBox39.Controls.Add(this.label186);
            this.groupBox39.Controls.Add(this.cmbXieXin);
            this.groupBox39.Controls.Add(this.label16);
            this.groupBox39.Controls.Add(this.panel3);
            this.groupBox39.Controls.Add(this.tbntGLU);
            this.groupBox39.Controls.Add(this.tbnqxBLD);
            this.groupBox39.Controls.Add(this.tbnttKET);
            this.groupBox39.Controls.Add(this.tbndbPRO);
            this.groupBox39.Controls.Add(this.label9);
            this.groupBox39.Controls.Add(this.label8);
            this.groupBox39.Controls.Add(this.label7);
            this.groupBox39.Controls.Add(this.label6);
            this.groupBox39.Controls.Add(this.btnshowECG);
            this.groupBox39.Controls.Add(this.label13);
            this.groupBox39.Controls.Add(this.lnklbEcg);
            this.groupBox39.Controls.Add(this.btnECG);
            this.groupBox39.Controls.Add(this.tbNiaoQt);
            this.groupBox39.Controls.Add(this.label2);
            this.groupBox39.Controls.Add(this.btnSelectHB);
            this.groupBox39.Controls.Add(this.btnSelectBE);
            this.groupBox39.Controls.Add(this.label14);
            this.groupBox39.Controls.Add(this.txtxcgQiTa);
            this.groupBox39.Controls.Add(this.label93);
            this.groupBox39.Controls.Add(this.label91);
            this.groupBox39.Controls.Add(this.txtXXB);
            this.groupBox39.Controls.Add(this.label92);
            this.groupBox39.Controls.Add(this.label88);
            this.groupBox39.Controls.Add(this.txtBXB);
            this.groupBox39.Controls.Add(this.label89);
            this.groupBox39.Controls.Add(this.label87);
            this.groupBox39.Controls.Add(this.txtXHDB);
            this.groupBox39.Controls.Add(this.label86);
            this.groupBox39.Controls.Add(this.tbchxt);
            this.groupBox39.Controls.Add(this.tblBG);
            this.groupBox39.Controls.Add(this.panel2);
            this.groupBox39.Controls.Add(this.txtXDYC);
            this.groupBox39.Controls.Add(this.label1);
            this.groupBox39.Controls.Add(this.btnSelectBS);
            this.groupBox39.Controls.Add(this.label10);
            this.groupBox39.Controls.Add(this.label18);
            this.groupBox39.Controls.Add(this.label5);
            this.groupBox39.Controls.Add(this.label12);
            this.groupBox39.Controls.Add(this.panel17);
            this.groupBox39.Controls.Add(this.label122);
            this.groupBox39.Controls.Add(this.txtphxhdb);
            this.groupBox39.Controls.Add(this.label120);
            this.groupBox39.Controls.Add(this.label119);
            this.groupBox39.Controls.Add(this.label118);
            this.groupBox39.Controls.Add(this.tbtxbgas);
            this.groupBox39.Controls.Add(this.txtnwldb);
            this.groupBox39.Controls.Add(this.label11);
            this.groupBox39.Controls.Add(this.label117);
            this.groupBox39.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox39.Location = new System.Drawing.Point(56, -10);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(1414, 258);
            this.groupBox39.TabIndex = 0;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "*";
            // 
            // cmbRH
            // 
            this.cmbRH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRH.FormattingEnabled = true;
            this.cmbRH.Items.AddRange(new object[] {
            "否",
            "是",
            "不详"});
            this.cmbRH.Location = new System.Drawing.Point(494, 153);
            this.cmbRH.Name = "cmbRH";
            this.cmbRH.Size = new System.Drawing.Size(117, 28);
            this.cmbRH.TabIndex = 95;
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label186.Location = new System.Drawing.Point(454, 158);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(29, 20);
            this.label186.TabIndex = 96;
            this.label186.Text = "RH";
            // 
            // cmbXieXin
            // 
            this.cmbXieXin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXieXin.FormattingEnabled = true;
            this.cmbXieXin.Location = new System.Drawing.Point(135, 158);
            this.cmbXieXin.Name = "cmbXieXin";
            this.cmbXieXin.Size = new System.Drawing.Size(155, 28);
            this.cmbXieXin.TabIndex = 94;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(48, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 20);
            this.label16.TabIndex = 93;
            this.label16.Text = "血型";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ckxdt9);
            this.panel3.Controls.Add(this.ckxdt8);
            this.panel3.Controls.Add(this.ckxdt7);
            this.panel3.Controls.Add(this.ckxdt6);
            this.panel3.Controls.Add(this.ckxdt5);
            this.panel3.Controls.Add(this.ckxdt4);
            this.panel3.Controls.Add(this.ckxdt3);
            this.panel3.Controls.Add(this.ckxdt2);
            this.panel3.Controls.Add(this.ckxdt1);
            this.panel3.Location = new System.Drawing.Point(131, 187);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1228, 32);
            this.panel3.TabIndex = 92;
            // 
            // ckxdt9
            // 
            this.ckxdt9.AutoSize = true;
            this.ckxdt9.Location = new System.Drawing.Point(1020, 4);
            this.ckxdt9.Name = "ckxdt9";
            this.ckxdt9.Size = new System.Drawing.Size(68, 24);
            this.ckxdt9.TabIndex = 0;
            this.ckxdt9.Text = "其他";
            this.ckxdt9.UseVisualStyleBackColor = true;
            this.ckxdt9.CheckedChanged += new System.EventHandler(this.ckxdt9_CheckedChanged);
            // 
            // ckxdt8
            // 
            this.ckxdt8.AutoSize = true;
            this.ckxdt8.Location = new System.Drawing.Point(866, 4);
            this.ckxdt8.Name = "ckxdt8";
            this.ckxdt8.Size = new System.Drawing.Size(148, 24);
            this.ckxdt8.TabIndex = 0;
            this.ckxdt8.Text = "房室传导阻滞";
            this.ckxdt8.UseVisualStyleBackColor = true;
            this.ckxdt8.CheckedChanged += new System.EventHandler(this.ckxdt8_CheckedChanged);
            // 
            // ckxdt7
            // 
            this.ckxdt7.AutoSize = true;
            this.ckxdt7.Location = new System.Drawing.Point(775, 4);
            this.ckxdt7.Name = "ckxdt7";
            this.ckxdt7.Size = new System.Drawing.Size(68, 24);
            this.ckxdt7.TabIndex = 0;
            this.ckxdt7.Text = "房颤";
            this.ckxdt7.UseVisualStyleBackColor = true;
            this.ckxdt7.CheckedChanged += new System.EventHandler(this.ckxdt7_CheckedChanged);
            // 
            // ckxdt6
            // 
            this.ckxdt6.AutoSize = true;
            this.ckxdt6.Location = new System.Drawing.Point(684, 4);
            this.ckxdt6.Name = "ckxdt6";
            this.ckxdt6.Size = new System.Drawing.Size(68, 24);
            this.ckxdt6.TabIndex = 0;
            this.ckxdt6.Text = "早搏";
            this.ckxdt6.UseVisualStyleBackColor = true;
            this.ckxdt6.CheckedChanged += new System.EventHandler(this.ckxdt6_CheckedChanged);
            // 
            // ckxdt5
            // 
            this.ckxdt5.AutoSize = true;
            this.ckxdt5.Location = new System.Drawing.Point(529, 4);
            this.ckxdt5.Name = "ckxdt5";
            this.ckxdt5.Size = new System.Drawing.Size(148, 24);
            this.ckxdt5.TabIndex = 0;
            this.ckxdt5.Text = "窦性心动过缓";
            this.ckxdt5.UseVisualStyleBackColor = true;
            this.ckxdt5.CheckedChanged += new System.EventHandler(this.ckxdt5_CheckedChanged);
            // 
            // ckxdt4
            // 
            this.ckxdt4.AutoSize = true;
            this.ckxdt4.Location = new System.Drawing.Point(372, 4);
            this.ckxdt4.Name = "ckxdt4";
            this.ckxdt4.Size = new System.Drawing.Size(148, 24);
            this.ckxdt4.TabIndex = 0;
            this.ckxdt4.Text = "窦性心动过速";
            this.ckxdt4.UseVisualStyleBackColor = true;
            this.ckxdt4.CheckedChanged += new System.EventHandler(this.ckxdt4_CheckedChanged);
            // 
            // ckxdt3
            // 
            this.ckxdt3.AutoSize = true;
            this.ckxdt3.Location = new System.Drawing.Point(195, 5);
            this.ckxdt3.Name = "ckxdt3";
            this.ckxdt3.Size = new System.Drawing.Size(168, 24);
            this.ckxdt3.TabIndex = 0;
            this.ckxdt3.Text = "陈旧性心肌梗塞";
            this.ckxdt3.UseVisualStyleBackColor = true;
            this.ckxdt3.CheckedChanged += new System.EventHandler(this.ckxdt3_CheckedChanged);
            // 
            // ckxdt2
            // 
            this.ckxdt2.AutoSize = true;
            this.ckxdt2.Location = new System.Drawing.Point(85, 5);
            this.ckxdt2.Name = "ckxdt2";
            this.ckxdt2.Size = new System.Drawing.Size(108, 24);
            this.ckxdt2.TabIndex = 0;
            this.ckxdt2.Text = "ST-T改变";
            this.ckxdt2.UseVisualStyleBackColor = true;
            this.ckxdt2.CheckedChanged += new System.EventHandler(this.ckxdt2_CheckedChanged);
            // 
            // ckxdt1
            // 
            this.ckxdt1.AutoSize = true;
            this.ckxdt1.Location = new System.Drawing.Point(3, 5);
            this.ckxdt1.Name = "ckxdt1";
            this.ckxdt1.Size = new System.Drawing.Size(68, 24);
            this.ckxdt1.TabIndex = 0;
            this.ckxdt1.Text = "正常";
            this.ckxdt1.UseVisualStyleBackColor = true;
            this.ckxdt1.CheckedChanged += new System.EventHandler(this.ckxdt1_CheckedChanged);
            // 
            // tbntGLU
            // 
            this.tbntGLU.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbntGLU.Location = new System.Drawing.Point(378, 82);
            this.tbntGLU.Name = "tbntGLU";
            this.tbntGLU.Size = new System.Drawing.Size(100, 30);
            this.tbntGLU.TabIndex = 9;
            // 
            // tbnqxBLD
            // 
            this.tbnqxBLD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbnqxBLD.Location = new System.Drawing.Point(799, 82);
            this.tbnqxBLD.Name = "tbnqxBLD";
            this.tbnqxBLD.Size = new System.Drawing.Size(103, 30);
            this.tbnqxBLD.TabIndex = 11;
            // 
            // tbnttKET
            // 
            this.tbnttKET.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbnttKET.Location = new System.Drawing.Point(604, 78);
            this.tbnttKET.Name = "tbnttKET";
            this.tbnttKET.Size = new System.Drawing.Size(114, 30);
            this.tbnttKET.TabIndex = 10;
            // 
            // tbndbPRO
            // 
            this.tbndbPRO.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbndbPRO.Location = new System.Drawing.Point(201, 82);
            this.tbndbPRO.Name = "tbndbPRO";
            this.tbndbPRO.Size = new System.Drawing.Size(100, 30);
            this.tbndbPRO.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(721, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 91;
            this.label9.Text = "尿潜血";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(525, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 91;
            this.label8.Text = "尿酮体";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 91;
            this.label7.Text = "尿糖";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 91;
            this.label6.Text = "尿蛋白";
            // 
            // btnshowECG
            // 
            this.btnshowECG.Location = new System.Drawing.Point(8, 190);
            this.btnshowECG.Name = "btnshowECG";
            this.btnshowECG.Size = new System.Drawing.Size(90, 31);
            this.btnshowECG.TabIndex = 16;
            this.btnshowECG.Text = "心电图";
            this.btnshowECG.UseVisualStyleBackColor = true;
            this.btnshowECG.Click += new System.EventHandler(this.btnshowECG_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(929, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 20);
            this.label13.TabIndex = 11;
            this.label13.Text = "μmol/L";
            // 
            // lnklbEcg
            // 
            this.lnklbEcg.AutoSize = true;
            this.lnklbEcg.Location = new System.Drawing.Point(16, 199);
            this.lnklbEcg.Name = "lnklbEcg";
            this.lnklbEcg.Size = new System.Drawing.Size(69, 20);
            this.lnklbEcg.TabIndex = 89;
            this.lnklbEcg.TabStop = true;
            this.lnklbEcg.Text = "心电图";
            this.lnklbEcg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbEcg_LinkClicked);
            // 
            // btnECG
            // 
            this.btnECG.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnECG.Location = new System.Drawing.Point(1351, 46);
            this.btnECG.Name = "btnECG";
            this.btnECG.Size = new System.Drawing.Size(47, 31);
            this.btnECG.TabIndex = 15;
            this.btnECG.Text = "...";
            this.btnECG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnECG.UseVisualStyleBackColor = true;
            this.btnECG.Visible = false;
            this.btnECG.Click += new System.EventHandler(this.btnECG_Click);
            // 
            // tbNiaoQt
            // 
            this.tbNiaoQt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNiaoQt.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbNiaoQt.Location = new System.Drawing.Point(1104, 84);
            this.tbNiaoQt.Name = "tbNiaoQt";
            this.tbNiaoQt.Size = new System.Drawing.Size(294, 30);
            this.tbNiaoQt.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(986, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 84;
            this.label2.Text = "尿常规其他";
            // 
            // btnSelectHB
            // 
            this.btnSelectHB.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectHB.Location = new System.Drawing.Point(308, 13);
            this.btnSelectHB.Name = "btnSelectHB";
            this.btnSelectHB.Size = new System.Drawing.Size(47, 31);
            this.btnSelectHB.TabIndex = 1;
            this.btnSelectHB.Text = "...";
            this.btnSelectHB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectHB.UseVisualStyleBackColor = true;
            this.btnSelectHB.Click += new System.EventHandler(this.btnSelectHB_Click);
            // 
            // btnSelectBE
            // 
            this.btnSelectBE.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectBE.Location = new System.Drawing.Point(912, 78);
            this.btnSelectBE.Name = "btnSelectBE";
            this.btnSelectBE.Size = new System.Drawing.Size(47, 31);
            this.btnSelectBE.TabIndex = 12;
            this.btnSelectBE.Text = "...";
            this.btnSelectBE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectBE.UseVisualStyleBackColor = true;
            this.btnSelectBE.Click += new System.EventHandler(this.btnSelectBE_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(28, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 20);
            this.label14.TabIndex = 82;
            this.label14.Text = "尿常规";
            // 
            // txtxcgQiTa
            // 
            this.txtxcgQiTa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtxcgQiTa.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxcgQiTa.Location = new System.Drawing.Point(1169, 18);
            this.txtxcgQiTa.MaxLength = 20;
            this.txtxcgQiTa.Name = "txtxcgQiTa";
            this.txtxcgQiTa.Size = new System.Drawing.Size(231, 30);
            this.txtxcgQiTa.TabIndex = 4;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label93.Location = new System.Drawing.Point(1047, 25);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(109, 20);
            this.label93.TabIndex = 80;
            this.label93.Text = "血常规其他";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label91.Location = new System.Drawing.Point(929, 20);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(79, 20);
            this.label91.TabIndex = 79;
            this.label91.Text = "x10^9/L";
            // 
            // txtXXB
            // 
            this.txtXXB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtXXB.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXXB.Location = new System.Drawing.Point(818, 15);
            this.txtXXB.MaxLength = 5;
            this.txtXXB.Name = "txtXXB";
            this.txtXXB.Size = new System.Drawing.Size(103, 30);
            this.txtXXB.TabIndex = 3;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label92.Location = new System.Drawing.Point(736, 18);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(69, 20);
            this.label92.TabIndex = 77;
            this.label92.Text = "血小板";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label88.Location = new System.Drawing.Point(593, 20);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(79, 20);
            this.label88.TabIndex = 76;
            this.label88.Text = "x10^9/L";
            // 
            // txtBXB
            // 
            this.txtBXB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBXB.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBXB.Location = new System.Drawing.Point(483, 15);
            this.txtBXB.MaxLength = 5;
            this.txtBXB.Name = "txtBXB";
            this.txtBXB.Size = new System.Drawing.Size(103, 30);
            this.txtBXB.TabIndex = 2;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label89.Location = new System.Drawing.Point(402, 19);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(69, 20);
            this.label89.TabIndex = 74;
            this.label89.Text = "白细胞";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label87.Location = new System.Drawing.Point(238, 20);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(39, 20);
            this.label87.TabIndex = 73;
            this.label87.Text = "g/L";
            // 
            // txtXHDB
            // 
            this.txtXHDB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtXHDB.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXHDB.Location = new System.Drawing.Point(129, 16);
            this.txtXHDB.MaxLength = 5;
            this.txtXHDB.Name = "txtXHDB";
            this.txtXHDB.Size = new System.Drawing.Size(103, 30);
            this.txtXHDB.TabIndex = 0;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label86.Location = new System.Drawing.Point(8, 19);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(89, 20);
            this.label86.TabIndex = 71;
            this.label86.Text = "血红蛋白";
            // 
            // tbchxt
            // 
            this.tbchxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbchxt.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbchxt.Location = new System.Drawing.Point(484, 47);
            this.tbchxt.MaxLength = 5;
            this.tbchxt.Name = "tbchxt";
            this.tbchxt.Size = new System.Drawing.Size(103, 30);
            this.tbchxt.TabIndex = 7;
            // 
            // tblBG
            // 
            this.tblBG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tblBG.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tblBG.Location = new System.Drawing.Point(129, 47);
            this.tblBG.MaxLength = 5;
            this.tblBG.Name = "tblBG";
            this.tblBG.Size = new System.Drawing.Size(103, 30);
            this.tblBG.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReset_qx);
            this.panel2.Controls.Add(this.radqxyangx);
            this.panel2.Controls.Add(this.radqxyx);
            this.panel2.Location = new System.Drawing.Point(132, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 34);
            this.panel2.TabIndex = 19;
            // 
            // btnReset_qx
            // 
            this.btnReset_qx.Location = new System.Drawing.Point(233, 5);
            this.btnReset_qx.Name = "btnReset_qx";
            this.btnReset_qx.Size = new System.Drawing.Size(87, 27);
            this.btnReset_qx.TabIndex = 8;
            this.btnReset_qx.Text = "重置";
            this.btnReset_qx.UseVisualStyleBackColor = true;
            this.btnReset_qx.Click += new System.EventHandler(this.btnReset_qx_Click);
            // 
            // radqxyangx
            // 
            this.radqxyangx.AutoSize = true;
            this.radqxyangx.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqxyangx.Location = new System.Drawing.Point(95, 6);
            this.radqxyangx.Name = "radqxyangx";
            this.radqxyangx.Size = new System.Drawing.Size(67, 24);
            this.radqxyangx.TabIndex = 7;
            this.radqxyangx.Text = "阳性";
            this.radqxyangx.UseVisualStyleBackColor = true;
            // 
            // radqxyx
            // 
            this.radqxyx.AutoSize = true;
            this.radqxyx.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqxyx.Location = new System.Drawing.Point(3, 5);
            this.radqxyx.Name = "radqxyx";
            this.radqxyx.Size = new System.Drawing.Size(67, 24);
            this.radqxyx.TabIndex = 6;
            this.radqxyx.Text = "阴性";
            this.radqxyx.UseVisualStyleBackColor = true;
            // 
            // txtXDYC
            // 
            this.txtXDYC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtXDYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXDYC.Location = new System.Drawing.Point(131, 224);
            this.txtXDYC.MaxLength = 200;
            this.txtXDYC.Name = "txtXDYC";
            this.txtXDYC.ReadOnly = true;
            this.txtXDYC.Size = new System.Drawing.Size(1228, 30);
            this.txtXDYC.TabIndex = 18;
            this.txtXDYC.TextChanged += new System.EventHandler(this.txtXDYC_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(724, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "%";
            // 
            // btnSelectBS
            // 
            this.btnSelectBS.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectBS.Location = new System.Drawing.Point(308, 46);
            this.btnSelectBS.Name = "btnSelectBS";
            this.btnSelectBS.Size = new System.Drawing.Size(47, 31);
            this.btnSelectBS.TabIndex = 6;
            this.btnSelectBS.Text = "...";
            this.btnSelectBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectBS.UseVisualStyleBackColor = true;
            this.btnSelectBS.Click += new System.EventHandler(this.btnSelectBS_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(595, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "mmol/L";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(237, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 20);
            this.label18.TabIndex = 17;
            this.label18.Text = "mmol/L";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(362, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "餐后2H血糖";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(8, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "空腹血糖";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.btnReset_yg);
            this.panel17.Controls.Add(this.radygyangx);
            this.panel17.Controls.Add(this.radygyx);
            this.panel17.Location = new System.Drawing.Point(1022, 118);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(294, 33);
            this.panel17.TabIndex = 21;
            // 
            // btnReset_yg
            // 
            this.btnReset_yg.Location = new System.Drawing.Point(171, 1);
            this.btnReset_yg.Name = "btnReset_yg";
            this.btnReset_yg.Size = new System.Drawing.Size(85, 27);
            this.btnReset_yg.TabIndex = 13;
            this.btnReset_yg.Text = "重置";
            this.btnReset_yg.UseVisualStyleBackColor = true;
            this.btnReset_yg.Click += new System.EventHandler(this.btnReset_yg_Click);
            // 
            // radygyangx
            // 
            this.radygyangx.AutoSize = true;
            this.radygyangx.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radygyangx.Location = new System.Drawing.Point(94, 5);
            this.radygyangx.Name = "radygyangx";
            this.radygyangx.Size = new System.Drawing.Size(67, 24);
            this.radygyangx.TabIndex = 12;
            this.radygyangx.Text = "阳性";
            this.radygyangx.UseVisualStyleBackColor = true;
            // 
            // radygyx
            // 
            this.radygyx.AutoSize = true;
            this.radygyx.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radygyx.Location = new System.Drawing.Point(15, 6);
            this.radygyx.Name = "radygyx";
            this.radygyx.Size = new System.Drawing.Size(67, 24);
            this.radygyx.TabIndex = 11;
            this.radygyx.Text = "阴性";
            this.radygyx.UseVisualStyleBackColor = true;
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label122.Location = new System.Drawing.Point(843, 126);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(169, 20);
            this.label122.TabIndex = 8;
            this.label122.Text = "乙型肝炎表面抗原";
            // 
            // txtphxhdb
            // 
            this.txtphxhdb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtphxhdb.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtphxhdb.Location = new System.Drawing.Point(604, 118);
            this.txtphxhdb.MaxLength = 5;
            this.txtphxhdb.Name = "txtphxhdb";
            this.txtphxhdb.Size = new System.Drawing.Size(114, 30);
            this.txtphxhdb.TabIndex = 20;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label120.Location = new System.Drawing.Point(469, 125);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(129, 20);
            this.label120.TabIndex = 6;
            this.label120.Text = "糖化血红蛋白";
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label119.Location = new System.Drawing.Point(8, 124);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(89, 20);
            this.label119.TabIndex = 3;
            this.label119.Text = "大便潜血";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label118.Location = new System.Drawing.Point(1279, 50);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(59, 20);
            this.label118.TabIndex = 2;
            this.label118.Text = "mg/dL";
            // 
            // tbtxbgas
            // 
            this.tbtxbgas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbtxbgas.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbtxbgas.Location = new System.Drawing.Point(818, 47);
            this.tbtxbgas.MaxLength = 5;
            this.tbtxbgas.Name = "tbtxbgas";
            this.tbtxbgas.Size = new System.Drawing.Size(103, 30);
            this.tbtxbgas.TabIndex = 14;
            // 
            // txtnwldb
            // 
            this.txtnwldb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtnwldb.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtnwldb.Location = new System.Drawing.Point(1169, 50);
            this.txtnwldb.MaxLength = 5;
            this.txtnwldb.Name = "txtnwldb";
            this.txtnwldb.Size = new System.Drawing.Size(103, 30);
            this.txtnwldb.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(676, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "同型半胱氨酸";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label117.Location = new System.Drawing.Point(1027, 54);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(129, 20);
            this.label117.TabIndex = 0;
            this.label117.Text = "尿微量白蛋白";
            // 
            // AidExamUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1460, 680);
            this.Controls.Add(this.groupBox43);
            this.Controls.Add(this.groupBox42);
            this.Controls.Add(this.groupBox41);
            this.Controls.Add(this.txtqtqita);
            this.Controls.Add(this.label151);
            this.Controls.Add(this.groupBox40);
            this.Controls.Add(this.groupBox39);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "AidExamUserControl";
            this.Load += new System.EventHandler(this.AidExamUserControl_Load);
            this.VisibleChanged += new System.EventHandler(this.AidExamUserControl_VisibleChanged);
            this.groupBox43.ResumeLayout(false);
            this.groupBox43.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.groupBox42.ResumeLayout(false);
            this.groupBox42.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.groupBox41.ResumeLayout(false);
            this.groupBox41.PerformLayout();
            this.groupBox40.ResumeLayout(false);
            this.groupBox40.PerformLayout();
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lnklbEcg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //    ECGForm ecg = new ECGForm
            //    {
            //        IDCardNo = this.Model.IDCardNo,
            //        StartPosition = FormStartPosition.CenterParent
            //    };
            //    if (ecg.ShowDialog() == DialogResult.OK)
            //    {
            //        new RhElectroCardioBLL().DeleteListNotin(this.Model.IDCardNo, ecg.ECG_ID.ToString());
            //    }



        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            if (PhysicalInfoFactory.ID == -1)
            {
                return true;
            }
            RecordsAssistCheckBLL recordsAssistCheckBLL = new RecordsAssistCheckBLL();
            this.AssistCheck.OutKey = PhysicalInfoFactory.ID;
            if (!recordsAssistCheckBLL.ExistsOutKey(this.AssistCheck.IDCardNo, PhysicalInfoFactory.ID))
            {
                recordsAssistCheckBLL.Add(this.AssistCheck);
            }
            else
            {
                recordsAssistCheckBLL.Update(this.AssistCheck);
            }
            return true;
        }

        private void SimpleBinding(TextBox tb, string srcMember)
        {
            tb.ImeMode = ImeMode.Disable;
            Binding binding = new Binding("Text", this.AssistCheck, srcMember, true, DataSourceUpdateMode.OnPropertyChanged);
            tb.DataBindings.Add(binding);
            binding.Parse += new ConvertEventHandler(this.bd_Parse);
        }

        private void SimpleBinding(TextBox tb, string srcMember, bool isFormate)
        {
            Binding binding = new Binding("Text", this.AssistCheck, srcMember, isFormate, DataSourceUpdateMode.OnPropertyChanged);
            tb.DataBindings.Add(binding);
            if (isFormate)
            {
                binding.Parse += new ConvertEventHandler(this.bd_Parse);
            }
            else
            {
                binding.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
        }

        private void AidExamUserControl_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }

            if ((!string.IsNullOrEmpty(this.AssistCheck.PRO) || !string.IsNullOrEmpty(this.AssistCheck.GLU)) ||
                (!string.IsNullOrEmpty(this.AssistCheck.KET) || !string.IsNullOrEmpty(this.AssistCheck.PRO)))
            {
                this.tbndbPRO.Text = this.AssistCheck.PRO;
                this.tbntGLU.Text = this.AssistCheck.GLU;
                this.tbnttKET.Text = this.AssistCheck.KET;
                this.tbnqxBLD.Text = this.AssistCheck.BLD;
            }
        }

        public void UpdataToModel()
        {
            this.AssistCheck.IDCardNo = this.Model.IDCardNo;
            if (this.radqxyx.Checked)
            {
                this.AssistCheck.FOB = "1";
            }
            if (this.radqxyangx.Checked)
            {
                this.AssistCheck.FOB = "2";
            }
            if (this.radygyx.Checked)
            {
                this.AssistCheck.HBSAG = "1";
            }
            else if (this.radygyangx.Checked)
            {
                this.AssistCheck.HBSAG = "2";
            }
            else
            {
                this.AssistCheck.HBSAG = null;
            }


            //this.AssistCheck.ECG = this.xindian.Choose;
            //this.AssistCheck.ECGEx = this.xindian.Choose_EX.Replace('\n', ';').Replace('\r', ' ').Replace(" ", "");
            this.AssistCheck.CHESTX = this.xiongbuX.Choose;
            this.AssistCheck.CHESTXEx = this.xiongbuX.Choose_EX;
            this.AssistCheck.BCHAO = this.BCHAO.Choose;
            this.AssistCheck.BCHAOEx = this.BCHAO.Choose_EX;
            this.AssistCheck.BCHAOther = this.BCHAOther.Choose;
            this.AssistCheck.BCHAOtherEx = this.BCHAOther.Choose_EX;
            if (this.cmbXieXin.SelectedValue != null)
            {
                this.AssistCheck.BloodType = this.cmbXieXin.SelectedValue.ToString();
            }
            if (this.Model.Sex != "1")
            {
                this.AssistCheck.CERVIX = this.gongjingtupian.Choose;
                this.AssistCheck.CERVIXEx = this.gongjingtupian.Choose_EX;
            }
            if (this.cmbRH.SelectedIndex != -1)
            {
                this.AssistCheck.RH = Convert.ToString((int)(this.cmbRH.SelectedIndex + 1));
            }
        }

        public override void UpdateDeviceinfoContent(int msg)
        {
            switch (msg)
            {
                case 0x599:
                    {
                        stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "24");
                        if (devData.HasValue)
                        {
                            if (devData.value1 == ".0")
                            {
                                this.AssistCheck.FPGL = 0;
                                return;
                            }
                            this.AssistCheck.FPGL = new decimal?(decimal.Parse(devData.value1));
                            this.tblBG.Text = devData.value1;
                            return;
                        }
                        return;
                    }
                case 0x59a:
                case 0x59c:
                case 0x59d:
                    break;

                case 0x59b:
                    {
                        stru_result _result2 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "35", "血总胆固醇");
                        if (_result2.HasValue)
                        {
                            this.AssistCheck.TC = new decimal?(decimal.Parse(_result2.value1));
                        }
                        stru_result _result3 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "35", "血甘油三脂");
                        if (_result3.HasValue)
                        {
                            this.AssistCheck.TG = new decimal?(decimal.Parse(_result3.value1));
                        }
                        stru_result _result4 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "35", "血高密度脂蛋白");
                        if (_result4.HasValue)
                        {
                            this.AssistCheck.HeiCho = new decimal?(decimal.Parse(_result4.value1));
                        }
                        stru_result _result5 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "52", "血红蛋白");
                        if (_result5.HasValue)
                        {
                            this.AssistCheck.HB = new decimal?(decimal.Parse(_result5.value1));
                        }
                        return;
                    }
                case 0x59e:
                    {
                        stru_result _result6 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "33");
                        if (_result6.HasValue)
                        {
                            if (area.Equals("济宁"))
                            {
                                this.AssistCheck.PRO = GetExNiaoPlus(_result6.value6.ToString());
                                this.AssistCheck.GLU = GetExNiaoPlus(_result6.value5.ToString());
                                this.AssistCheck.KET = GetExNiaoPlus(_result6.value4.ToString());
                                this.AssistCheck.BLD = GetExNiaoPlus(_result6.value2.ToString());
                                //this.tbNiao.Text = _result6.value6 + "/" + _result6.value5 + "/" + _result6.value4 + "/" + _result6.value2;
                                this.tbndbPRO.Text = GetExNiaoPlus(_result6.value6);
                                this.tbntGLU.Text = GetExNiaoPlus(_result6.value5);
                                this.tbnttKET.Text = GetExNiaoPlus(_result6.value4);
                                this.tbnqxBLD.Text = GetExNiaoPlus(_result6.value2);
                            }
                            else
                            {
                                this.AssistCheck.PRO = _result6.value6.ToString();
                                this.AssistCheck.GLU = _result6.value5.ToString();
                                this.AssistCheck.KET = _result6.value4.ToString();
                                this.AssistCheck.BLD = _result6.value2.ToString();
                                //this.tbNiao.Text = _result6.value6 + "/" + _result6.value5 + "/" + _result6.value4 + "/" + _result6.value2;
                                this.tbndbPRO.Text = _result6.value6;
                                this.tbntGLU.Text = _result6.value5;
                                this.tbnttKET.Text = _result6.value4;
                                this.tbnqxBLD.Text = _result6.value2;
                            }

                            string NiaoQt = "";
                            if (!string.IsNullOrEmpty(_result6.value1) && _result6.value1.Contains('+'))
                            {
                                NiaoQt = "尿胆原:" + _result6.value1.ToString();
                            }
                            if (!string.IsNullOrEmpty(_result6.value3) && _result6.value3.Contains('+'))
                            {
                                NiaoQt = "胆红素:" + _result6.value3.ToString();
                            }
                            if (!string.IsNullOrEmpty(_result6.value7) && _result6.value7.Contains('+'))
                            {
                                NiaoQt += " PH:" + _result6.value7.ToString();
                            }
                            if (!string.IsNullOrEmpty(_result6.value8) && _result6.value8.Contains('+'))
                            {
                                NiaoQt += " 亚硝酸盐:" + _result6.value8.ToString();
                            }
                            if (!string.IsNullOrEmpty(_result6.value9) && _result6.value9.Contains('+'))
                            {
                                NiaoQt += " 白细胞:" + _result6.value9.ToString();
                            }
                            if (!string.IsNullOrEmpty(_result6.value10) && _result6.value10.Contains('+'))
                            {
                                NiaoQt += " 比重:" + _result6.value10.ToString();
                            }
                            if (!string.IsNullOrEmpty(_result6.value11) && _result6.value11.Contains('+'))
                            {
                                NiaoQt += " 维生素C:" + _result6.value11.ToString();
                            }
                            if (area.Equals("平度"))
                            {
                                if (string.IsNullOrEmpty(NiaoQt))
                                {
                                    NiaoQt = "-";
                                }
                            }
                            tbNiaoQt.Text = NiaoQt;

                            this.AssistCheck.UrineOther = NiaoQt;
                            return;
                        }
                        return;
                    }
                case 0x59f:
                    {
                        stru_result _result7 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "97");
                        if (_result7.HasValue)
                        {
                            if (_result7.value1 == "正常范围心电图")
                            {
                                this.AssistCheck.ECG = "1";
                                return;
                            }
                            this.AssistCheck.ECG = "9";
                            this.AssistCheck.ECGEx = _result7.value1;
                            break;
                        }
                        return;
                    }
                default:
                    return;
            }
        }

        public RecordsAssistCheckModel AssistCheck { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsCustomerBaseInfoModel CustomerBaseInfo { get; set; }

        private void btnshowECG_Click(object sender, EventArgs e)
        {
            string ectType = "1";

            XmlDocument document = new XmlDocument();
            document.Load(Environment.CurrentDirectory + @"\ECGconfig.xml");
            XmlNode node = document.SelectSingleNode("//ECGType");

            if (node != null)
            {
                ectType = node.InnerText.Trim();
            }

            if (ectType == "2")
            {
                string id = this.Model.IDCardNo;
                string strtest = "select max(MID),IDCardNo,Name,Conclusion,CreateTime FROM ARCHIVE_ECG WHERE IDCardNo='" + id + "' GROUP BY IDCardNo ";
                DataSet testSet = MySQLHelper.Query(strtest);
                DataTable dtTable = testSet.Tables[0];
                if (dtTable.Rows.Count > 0)
                {
                    ////插入结论
                    //string conclusion = "update ARCHIVE_ASSISTCHECK set ECG='2', ECGEx='" + dtTable.Rows[0][3] + "'where IDCardNo=" + dtTable.Rows[0][1];
                    //DataSet updataECG = MySQLHelper.Query(conclusion);

                    string fileName1 = ECGReport + "\\" + dtTable.Rows[0][0] + ".png ";

                    ECGShowM ecg = new ECGShowM();
                    ecg.FilePath = fileName1;
                    ecg.ShowDialog();
                }
                else
                {
                    MessageBox.Show("此用户没有心电图！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                ECGShow ecg = new ECGShow();
                ecg.IDCardNo = this.Model.IDCardNo;
                ecg.ShowDialog();
            }
        }


        private void tbndbPRO_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in this.tbndbPRO.Text.ToString().Trim())
            {
                if (c != '-' && c != '+')
                {
                    this.tbndbPRO.Clear();
                }
            }
        }

        private void tbntGLU_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in this.tbntGLU.Text.ToString().Trim())
            {
                if (c != '-' && c != '+')
                {
                    this.tbntGLU.Clear();
                }
            }
        }

        private void tbnttKET_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in this.tbnttKET.Text.ToString().Trim())
            {
                if (c != '-' && c != '+')
                {
                    this.tbnttKET.Clear();
                }
            }
        }

        private void tbnqxBLD_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in this.tbnqxBLD.Text.ToString().Trim())
            {
                if (c != '-' && c != '+')
                {
                    this.tbnqxBLD.Clear();
                }
            }
        }

        private void AidExamUserControl_VisibleChanged(object sender, EventArgs e)
        {
            RecordsManageMentModel.ECG = this.AssistCheck.ECG;
            RecordsManageMentModel.ECGEx = "";
            if (ckxdt2.Checked)
            {
                RecordsManageMentModel.ECGEx += "ST-T改变,";
            }
            if (ckxdt3.Checked)
            {
                RecordsManageMentModel.ECGEx += "陈旧性心肌梗塞,";
            }
            if (ckxdt4.Checked)
            {
                RecordsManageMentModel.ECGEx += "窦性心动过速,";
            }
            if (ckxdt5.Checked)
            {
                RecordsManageMentModel.ECGEx += "窦性心动过缓,";
            }
            if (ckxdt6.Checked)
            {
                RecordsManageMentModel.ECGEx += "早搏,";
            }
            if (ckxdt7.Checked)
            {
                RecordsManageMentModel.ECGEx += "房颤,";
            }
            if (ckxdt8.Checked)
            {
                RecordsManageMentModel.ECGEx += "房室传导阻滞,";
            }
            if (ckxdt9.Checked)
            {
                RecordsManageMentModel.ECGEx += txtXDYC.Text;
            }
            else if (!string.IsNullOrEmpty(RecordsManageMentModel.ECGEx))
            {
                RecordsManageMentModel.ECGEx = RecordsManageMentModel.ECGEx.Trim().TrimEnd(',');
            }


            RecordsManageMentModel.BCHAO = this.BCHAO.Choose;
            RecordsManageMentModel.BCHAOEx = this.BCHAO.Choose_EX;

            RecordsManageMentModel.PRO = this.AssistCheck.PRO;
            RecordsManageMentModel.GLU = this.AssistCheck.GLU;
            RecordsManageMentModel.KET = this.AssistCheck.KET;
            RecordsManageMentModel.BLD = this.AssistCheck.BLD;
            RecordsManageMentModel.UrineOther = this.AssistCheck.UrineOther;

            RecordsManageMentModel.HB = this.AssistCheck.HB;
            RecordsManageMentModel.WBC = this.AssistCheck.WBC;
            RecordsManageMentModel.PLT = this.AssistCheck.PLT;
            RecordsManageMentModel.SGPT = this.AssistCheck.SGPT;
            RecordsManageMentModel.GOT = this.AssistCheck.GOT;
            RecordsManageMentModel.BP = this.AssistCheck.BP;
            RecordsManageMentModel.TBIL = this.AssistCheck.TBIL;
            RecordsManageMentModel.CB = this.AssistCheck.CB;

            RecordsManageMentModel.SCR = this.AssistCheck.SCR;
            RecordsManageMentModel.BUN = this.AssistCheck.BUN;
            RecordsManageMentModel.PC = this.AssistCheck.PC;
            RecordsManageMentModel.TC = this.AssistCheck.TC;
            RecordsManageMentModel.HYPE = this.AssistCheck.HYPE;
            RecordsManageMentModel.TG = this.AssistCheck.TG;
            RecordsManageMentModel.GT = this.AssistCheck.GT;

            RecordsManageMentModel.LowCho = this.AssistCheck.LowCho;
            RecordsManageMentModel.HeiCho = this.AssistCheck.HeiCho;
            RecordsManageMentModel.FPGL = this.AssistCheck.FPGL;

            if (community.Equals("威海美年大健康") && StringPlus.toString(this.AssistCheck.UA) != "")
            {
                RecordsManageMentModel.UA = this.AssistCheck.UA;
            }
        }

        private void btnBChao_Click(object sender, EventArgs e)
        {
            string checkdt = "", strIDCardNo = "";
            if (this.CustomerBaseInfo != null)
            {
                checkdt = this.CustomerBaseInfo.CheckDate.Value.ToString("yyyy-MM-dd");
                strIDCardNo = this.CustomerBaseInfo.IDCardNo;
            }
            else
            {
                DateTime dt;
                if (DateTime.TryParse(RecordsManageMentModel.CheckDate.ToString(), out dt))
                {
                    checkdt = dt.ToString("yyyy-MM-dd");
                }
                strIDCardNo = this.Model.IDCardNo;
            }


            string typePath = string.Format(BChaoReport + @"\{0}_{1}.jpg", checkdt, strIDCardNo);

            TypeBUI.TypeBShow tfshow = new TypeBUI.TypeBShow(typePath, strIDCardNo);

            if (tfshow.ShowDialog() == DialogResult.Cancel)
            {
                tfshow.Close();
            }
        }

        private void txtXDYC_TextChanged(object sender, EventArgs e)
        {
            RecordsManageMentModel.ECGExx = txtXDYC.Text;
        }
        /// <summary>
        /// 将尿仪数据+1、+2改为+、++
        /// </summary>
        /// <param name="PRO"></param>
        /// <returns></returns>
        private string GetExNiaoPlus(string PRO)
        {
            if (string.IsNullOrEmpty(PRO))
            {
                return "";
            }
            PRO = PRO.Replace("+1", "+").Replace("+2", "++").Replace("+3", "+++").Replace("+4", "++++").Replace("+5", "+++++").Replace("+6", "++++++").Replace("+7", "+++++++").Replace("+8", "+++++++++");
            if (community == "小孟镇")
            {
                PRO = PRO.Replace("+-", "±");
            }
            return PRO;
        }

        private void ckxdt7_CheckedChanged(object sender, EventArgs e)
        {
            xuanze();
        }

        private void ckxdt2_CheckedChanged(object sender, EventArgs e)
        {
            xuanze();
        }

        private void ckxdt3_CheckedChanged(object sender, EventArgs e)
        {
            xuanze();
        }

        private void ckxdt4_CheckedChanged(object sender, EventArgs e)
        {
            xuanze();
        }

        private void ckxdt5_CheckedChanged(object sender, EventArgs e)
        {
            xuanze();
        }

        private void ckxdt6_CheckedChanged(object sender, EventArgs e)
        {
            xuanze();
        }

        private void xuanze() {
            RecordsManageMentModel.ECGEx = "";
            RecordsManageMentModel.ECG = "";
            if (ckxdt2.Checked)
            {
                RecordsManageMentModel.ECGEx += "ST-T改变,";
                RecordsManageMentModel.ECG += "2,";
            }
            if (ckxdt3.Checked)
            {
                RecordsManageMentModel.ECGEx += "陈旧性心肌梗塞,";
                RecordsManageMentModel.ECG += "3,";
            }
            if (ckxdt4.Checked)
            {
                RecordsManageMentModel.ECGEx += "窦性心动过速,";
                RecordsManageMentModel.ECG += "4,";
            }
            if (ckxdt5.Checked)
            {
                RecordsManageMentModel.ECGEx += "窦性心动过缓,";
                RecordsManageMentModel.ECG += "5,";
            }
            if (ckxdt6.Checked)
            {
                RecordsManageMentModel.ECGEx += "早搏,";
                RecordsManageMentModel.ECG += "6,";
            }
            if (ckxdt7.Checked)
            {
                RecordsManageMentModel.ECGEx += "房颤,";
                RecordsManageMentModel.ECG += "7,";
            }
            if (ckxdt8.Checked)
            {
                RecordsManageMentModel.ECGEx += "房室传导阻滞,";
                RecordsManageMentModel.ECG += "8,";
            }
            if (ckxdt9.Checked)
            {
                RecordsManageMentModel.ECGEx += txtXDYC.Text;
            }
            else if (!string.IsNullOrEmpty(RecordsManageMentModel.ECGEx))
            {
                RecordsManageMentModel.ECGEx = RecordsManageMentModel.ECGEx.Trim().TrimEnd(',');
            }
            if (!string.IsNullOrEmpty(RecordsManageMentModel.ECG))
            {
                RecordsManageMentModel.ECG = RecordsManageMentModel.ECG.Trim().TrimEnd(',');
            }
        }

        private void ckxdt8_CheckedChanged(object sender, EventArgs e)
        {
            xuanze();
        }

        private void ckxdt9_CheckedChanged(object sender, EventArgs e)
        {
            xuanze();
        }

        private void ckxdt1_CheckedChanged(object sender, EventArgs e)
        {
            xuanze();
        }
    }
}

