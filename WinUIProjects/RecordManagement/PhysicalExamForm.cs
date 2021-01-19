using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace ArchiveInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Data;

    public class PhysicalExamForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private CSingleItem baokuai;
        private IContainer components;
        private CSingleItem eye;
        private CSingleItem fujian;
        private CSingleItem ganda;
        private CSelectItem gangmen;
        private CSingleItem gongjing;
        private CSelectItem gongmo;
        private CSingleItem gongti;
        private CSingleItem huxi;
        private CSelectItem linba;
        private CSelectItem luoyin;
        private InputRangeStr other;
        private CSingleItem pida;
        private CSelectItem pifu;
        private CMoreChange ruxian;
        private List<CSelectItem> selectItems = new List<CSelectItem>();
        private List<CSingleItem> singleItems = new List<CSingleItem>();
        private CSingleItem waiyin;
        private CSingleItem yatong;
        private CSingleItem yidongzhuoyin;
        private CSingleItem yindao;
        private Panel panel1;
        private Panel panel12;
        private Label label4;
        private TextBox txtlhmnQiTa;
        private Panel panel11;
        private TextBox txtScalerQiTa;
        private Label label2;
        private Panel panel3;
        private Label label1;
        private TextBox txtyandi;
        private RadioButton radEarY;
        private RadioButton radEarZ;
        private Panel panel4;
        private TextBox txtSkinQiTa;
        private Label label3;
        private GroupBox groupBox32;
        private Panel panel15;
        private RadioButton radGTYC;
        private RadioButton radFKGTWJYC;
        private Panel panel14;
        private RadioButton radFKYYC;
        private RadioButton radFKYWJYC;
        private Panel panel13;
        private RadioButton radFKFJYC;
        private RadioButton radFKFJWYC;
        private Panel panel16;
        private RadioButton radFKGYC;
        private RadioButton radFKGWJYC;
        private Panel panel17;
        private RadioButton radFKWYC;
        private RadioButton radFKWJYC;
        private TextBox txtFKFJYC;
        private TextBox textBox12;
        private Label label84;
        private TextBox txtGTYC;
        private Label label83;
        private TextBox txtFKGYC;
        private Label label82;
        private TextBox txtFKYYC;
        private Label label81;
        private TextBox txtFKWYC;
        private Label label80;
        private TextBox txtqt;
        private GroupBox groupBox28;
        private Label label8;
        private TextBox txtRXQiTa;
        private CheckedListBox checkedListBox1;
        private TextBox txtGMQiTa;
        private Label label7;
        private Label label6;
        private Label label5;
        private ComboBox cmbzudongmai;
        private ComboBox cmbxiazhishuizhong;
        private GroupBox groupBox25;
        private Button btnXinLv;
        private Panel panel10;
        private RadioButton radBellygdHave;
        private RadioButton radBellyGdNHave;
        private Panel panel9;
        private RadioButton radBellyzyHave1;
        private RadioButton radBellyzyNHave1;
        private Panel panel8;
        private RadioButton radBellyBkHave;
        private RadioButton radBellyBkNHave;
        private Panel panel7;
        private RadioButton radBellypdHave1;
        private RadioButton radBellypdNHave;
        private Panel panel6;
        private RadioButton radBellyYtHave;
        private RadioButton radBellyYtNHave1;
        private TextBox txtBellyzyHave;
        private Label label79;
        private TextBox txtBellypdHave;
        private Label label77;
        private TextBox txtBellyGdHave;
        private Label label76;
        private TextBox txtBellybkHave;
        private Label label75;
        private TextBox txtBellyYtHave;
        private Label label78;
        private Panel panel2;
        private RadioButton radLungsY;
        private RadioButton radLungsZ;
        private ComboBox cmbxinguilv;
        private Panel panel5;
        private RadioButton radLungsNo;
        private RadioButton radLungsYes;
        private Panel panel18;
        private RadioButton radHeartzyYes;
        private RadioButton radHeartzyNo;
        private TextBox txtheartzyy;
        private Label label74;
        private TextBox txtLungsQiTa;
        private Label label73;
        private TextBox txtLungsY;
        private Label label72;
        private Label label70;
        private TextBox txtHeartLv;
        private Label label71;
        private Label label69;
        private Label label68;
        private Label radFKQiTa;
        private Button btnEyeReset;
        private CSingleItem zayin;
        private List<InputRangeDec> inputRanges = new List<InputRangeDec>();
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr>();
        private SimpleBindingManager<RecordsPhysicalExamModel> bindingManager;
        private List<CheckBox> ScleraList = new List<CheckBox>();
        private Button btnfkReset;
        private ComboBox cbSkin;
        private ComboBox cbScaler;
        private ComboBox cblhmn;
        private ComboBox cbLungs;
        private ComboBox cbGM;
        private DataSet dsRequire;
        private string area = ConfigHelper.GetSetNode("area");
        public PhysicalExamForm()
        {
            this.InitializeComponent();
            this.EveryThingIsOk = false;
        }
        private void bd_ParseStr(object sender, ConvertEventArgs e)
        {
            string s = e.Value as string;
            Binding binding = sender as Binding;
            InputRangeStr other = this.other;
            if (other != null)
            {
                if (Encoding.GetEncoding("GB2312").GetByteCount(s) > other.BytesCount)
                {
                    other.ErrorInput = true;
                    binding.Control.BackColor = Color.Salmon;
                }
                else
                {
                    other.ErrorInput = false;
                    binding.Control.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void btnXinLv_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "20")
            {
                ItemTypeName = "心率",
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.txtHeartLv.Text = select.m_Result.value3;
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            //if ((!this.other.ErrorInput && (this.singleItems.Count<CSingleItem>(c => c.ErrorInput) <= 0)) && ((this.selectItems.Count<CSelectItem>(c => c.ErrorInput) <= 0) && !this.ruxian.ErrorInput))
            //{
            //    return ChildFormStatus.NoErrorInput;
            //}
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

        private void InitControlSource()
        {
            this.singleItems.AddRange((IEnumerable<CSingleItem>)new CSingleItem[] { this.huxi, this.waiyin, this.yindao, this.gongjing, this.gongti, this.fujian, this.zayin, this.yatong, this.baokuai, this.ganda, this.pida, this.yidongzhuoyin, this.eye });
            this.selectItems.AddRange((IEnumerable<CSelectItem>)new CSelectItem[] { this.pifu, this.gongmo, this.linba, this.luoyin, this.gangmen });
        }

        public void InitEveryThing()
        {
            int num;
            PhysicalExam = new RecordsPhysicalExamBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            dsRequire = new RequireBLL().GetList("TabName = '健康体检' AND Comment = '查体信息' ");
            if (this.PhysicalExam == null)
            {
                RecordsPhysicalExamModel recordsPhysicalExamModel = new RecordsPhysicalExamModel
                {
                    IDCardNo = this.Model.IDCardNo
                };
                this.PhysicalExam = recordsPhysicalExamModel;
            }

            this.bindingManager = new SimpleBindingManager<RecordsPhysicalExamModel>(this.inputRanges, this.inputrange_str, this.PhysicalExam);

            if (string.IsNullOrWhiteSpace(this.PhysicalExam.HeartRate) && !PhysicalInfoFactory.NewAdd) //新增页面，心率不取值
            {
                stru_result _result = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20", "心率");
                if (_result.HasValue)
                {
                    this.PhysicalExam.HeartRate = _result.value3;
                }
            }

            if (PhysicalInfoFactory.falgID == 0)//新增
            {
                this.PresetValue();//默认项设置
            }

            if (!string.IsNullOrEmpty(this.PhysicalExam.HeartRate))
            {
                this.txtHeartLv.Text = this.PhysicalExam.HeartRate;
            }

            if (!string.IsNullOrEmpty(this.PhysicalExam.Skin)) //皮肤
            {
                this.cbSkin.SelectedIndex = int.Parse(this.PhysicalExam.Skin) - 1;
            }
            this.bindingManager.SimpleBinding(this.txtSkinQiTa, "SkinEx", false);
            if (!string.IsNullOrEmpty(this.PhysicalExam.Sclere)) //巩膜
            {
                this.cbScaler.SelectedIndex = int.Parse(this.PhysicalExam.Sclere) - 1;
            }
            this.bindingManager.SimpleBinding(this.txtScalerQiTa, "SclereEx", false);

            if (!string.IsNullOrEmpty(this.PhysicalExam.Lymph)) //淋巴结
            {
                this.cblhmn.SelectedIndex = int.Parse(this.PhysicalExam.Lymph) - 1;
            }
            this.bindingManager.SimpleBinding(this.txtlhmnQiTa, "LymphEx", false);
            if (!string.IsNullOrEmpty(this.PhysicalExam.BarrelChest)) //桶状胸
            {
                if (this.PhysicalExam.BarrelChest == "1")
                {
                    this.radLungsNo.Checked = true;
                }
                else if (this.PhysicalExam.BarrelChest == "2")
                {
                    this.radLungsYes.Checked = true;
                }
            }
 
            CSingleItem item4 = new CSingleItem
            {
                Name = "呼吸音",
                Usual = this.radLungsZ,
                Unusual = this.radLungsY,
                Info = this.txtLungsY,
                MaxBytesCount = 200
            };
            this.huxi = item4;
            this.singleItems.Add(this.huxi);
            this.huxi.TransInfo(this.PhysicalExam.BreathSounds, this.PhysicalExam.BreathSoundsEx);
     
            if (!string.IsNullOrEmpty(this.PhysicalExam.Rale)) //啰音
            {
                this.cbLungs.SelectedIndex = int.Parse(this.PhysicalExam.Rale) - 1;
            }
            this.bindingManager.SimpleBinding(this.txtLungsQiTa, "RaleEx", false);

            if (!string.IsNullOrEmpty(this.PhysicalExam.HeartRhythm) && int.TryParse(this.PhysicalExam.HeartRhythm, out num))
            {
                this.cmbxinguilv.SelectedIndex = num - 1;
            }

            CSingleItem item6 = new CSingleItem
            {
                Name = "杂音",
                Usual = this.radHeartzyNo,
                Unusual = this.radHeartzyYes,
                Info = this.txtheartzyy,
                MaxBytesCount = 200
            };
            this.zayin = item6;
            this.singleItems.Add(this.zayin);
            this.zayin.TransInfo(this.PhysicalExam.Noise, this.PhysicalExam.NoiseEx);
 
            CSingleItem item7 = new CSingleItem
            {
                Name = "压痛",
                Usual = this.radBellyYtNHave1,
                Unusual = this.radBellyYtHave,
                Info = this.txtBellyYtHave,
                MaxBytesCount = 200
            };
            this.yatong = item7;
            this.singleItems.Add(this.yatong);
            this.yatong.TransInfo(this.PhysicalExam.PressPain, this.PhysicalExam.PressPainEx);

            CSingleItem item8 = new CSingleItem
            {
                Name = "包块",
                Usual = this.radBellyBkNHave,
                Unusual = this.radBellyBkHave,
                Info = this.txtBellybkHave,
                MaxBytesCount = 200
            };
            this.baokuai = item8;
            this.singleItems.Add(this.baokuai);
            this.baokuai.TransInfo(this.PhysicalExam.EnclosedMass, this.PhysicalExam.EnclosedMassEx);
            CSingleItem item9 = new CSingleItem
            {
                Name = "肝大",
                Usual = this.radBellyGdNHave,
                Unusual = this.radBellygdHave,
                Info = this.txtBellyGdHave,
                MaxBytesCount = 200
            };
            this.ganda = item9;
            this.singleItems.Add(this.ganda);
            this.ganda.TransInfo(this.PhysicalExam.Liver, this.PhysicalExam.LiverEx);

            CSingleItem item10 = new CSingleItem
            {
                Name = "脾大",
                Usual = this.radBellypdNHave,
                Unusual = this.radBellypdHave1,
                Info = this.txtBellypdHave,
                MaxBytesCount = 200
            };
            this.pida = item10;
            this.singleItems.Add(this.pida);
            this.pida.TransInfo(this.PhysicalExam.Spleen, this.PhysicalExam.SpleenEx);
  
            CSingleItem item11 = new CSingleItem
            {
                Name = "移动浊音",
                Usual = this.radBellyzyNHave1,
                Unusual = this.radBellyzyHave1,
                Info = this.txtBellyzyHave,
                MaxBytesCount = 200
            };
            this.yidongzhuoyin = item11;
            this.singleItems.Add(this.yidongzhuoyin);
            this.yidongzhuoyin.TransInfo(this.PhysicalExam.Voiced, this.PhysicalExam.VoicedEx);
            CSingleItem item12 = new CSingleItem
            {
                Name = "眼底",
                Usual = this.radEarZ,
                Unusual = this.radEarY,
                Info = this.txtyandi,
                MaxBytesCount = 200
            };
            this.eye = item12;
            this.singleItems.Add(this.eye);
            this.eye.TransInfo(this.PhysicalExam.EyeRound, this.PhysicalExam.EyeRoundEx);

            if (!string.IsNullOrEmpty(this.PhysicalExam.Edema) && int.TryParse(this.PhysicalExam.Edema, out num)) //下肢水肿
            {
                this.cmbxiazhishuizhong.SelectedIndex = num - 1;
            }
          

            if (!string.IsNullOrEmpty(this.PhysicalExam.FootBack) && int.TryParse(this.PhysicalExam.FootBack, out num))
            {
                this.cmbzudongmai.SelectedIndex = num - 1;
            }
           

            if (!string.IsNullOrEmpty(this.PhysicalExam.Anus)) //肛门指诊
            {
                this.cbGM.SelectedIndex = int.Parse(this.PhysicalExam.Anus) - 1;
            }
            this.bindingManager.SimpleBinding(this.txtGMQiTa, "AnusEx", false);
            if ((this.Model.Sex == "男") || (this.Model.Sex == "1"))
            {
                foreach (Control control in this.groupBox32.Controls)
                {
                    if (control.GetType().Equals(typeof(Panel)))
                    {
                        foreach (Control control2 in control.Controls)
                        {
                            control2.Enabled = false;
                        }
                    }
                    if (control.GetType().Equals(typeof(TextBox)) && (control.Name != "txtqt"))
                    {
                        control.Enabled = false;
                    }
                }
            }

            CMoreChange change = new CMoreChange
            {
                Name = "乳腺",
                Unusual = "未见异常",
                Other = this.txtRXQiTa,
                MoreChange = this.checkedListBox1,
                MaxBytesCount = 200
            };
            this.ruxian = change;
            this.ruxian.TransInfo(this.PhysicalExam.Breast, this.PhysicalExam.BreastEx);
            CSingleItem item14 = new CSingleItem
            {
                Name = "外阴",
                Usual = this.radFKWJYC,
                Unusual = this.radFKWYC,
                Info = this.txtFKWYC,
                MaxBytesCount = 200
            };
            this.waiyin = item14;
            this.waiyin.TransInfo(this.PhysicalExam.Vulva, this.PhysicalExam.VulvaEx);
            CSingleItem item15 = new CSingleItem
            {
                Name = "阴道",
                Usual = this.radFKYWJYC,
                Unusual = this.radFKYYC,
                Info = this.txtFKYYC,
                MaxBytesCount = 200
            };
            this.yindao = item15;
            this.yindao.TransInfo(this.PhysicalExam.Vagina, this.PhysicalExam.VaginaEx);
            CSingleItem item16 = new CSingleItem
            {
                Name = "宫颈",
                Usual = this.radFKGWJYC,
                Unusual = this.radFKGYC,
                Info = this.txtFKGYC,
                MaxBytesCount = 200
            };
            this.gongjing = item16;
            this.gongjing.TransInfo(this.PhysicalExam.CervixUteri, this.PhysicalExam.CervixUteriEx);
            CSingleItem item17 = new CSingleItem
            {
                Name = "宫体",
                Usual = this.radFKGTWJYC,
                Unusual = this.radGTYC,
                Info = this.txtGTYC,
                MaxBytesCount = 200
            };
            this.gongti = item17;
            this.gongti.TransInfo(this.PhysicalExam.Corpus, this.PhysicalExam.CorpusEx);
            CSingleItem item18 = new CSingleItem
            {
                Name = "附件",
                Usual = this.radFKFJWYC,
                Unusual = this.radFKFJYC,
                Info = this.txtFKFJYC,
                MaxBytesCount = 200
            };
            this.fujian = item18;
            this.fujian.TransInfo(this.PhysicalExam.Attach, this.PhysicalExam.AttachEx);
            this.other = new InputRangeStr("Other", 500);
            this.SimpleBinding(this.txtqt, "Other");
            this.InitControlSource();
            this.EveryThingIsOk = true;
            string node = ConfigHelper.GetNode("ds_modify");
            if (string.IsNullOrEmpty(node))
            {
                node = "111110000000111";
                ConfigHelper.WriteNode("ds_modify", "111110000000111");
            }
            this.txtHeartLv.ReadOnly = node.ElementAtOrDefault<char>(8) != '1';
            MustChoose();
        }
        //默认项设置
        private void PresetValue()
        {
            RecordsPhysicalExamModel ExamModelTemp = new RecordsPhysicalExamModel();
            RecordsCustomerBaseInfoModel CustomerBaseInfos = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.Model.IDCardNo);//获取最新一笔体检数据
            if (CustomerBaseInfos != null)
            {
                ExamModelTemp = new RecordsPhysicalExamBLL().GetModelByOutKey(CustomerBaseInfos.ID);
            }
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = " IsSetValue='是' or IsSetValue='预设上次体检' ";
            DataTable dt = dv.ToTable();

            foreach (DataRow item in dt.Rows)
            {
                switch (item["ChinName"].ToString())
                {
                    case "皮肤":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Skin = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Skin = ExamModelTemp.Skin;
                            this.PhysicalExam.SkinEx = ExamModelTemp.SkinEx;
                        }
                        break;
                    case "巩膜":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Sclere = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Sclere = ExamModelTemp.Sclere;
                            this.PhysicalExam.SclereEx = ExamModelTemp.SclereEx;
                        }
                        break;
                    case "淋巴结":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Lymph = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Lymph = ExamModelTemp.Lymph;
                            this.PhysicalExam.LymphEx = ExamModelTemp.LymphEx;
                        }
                        break;
                    case "桶状胸":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.BarrelChest = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.BarrelChest = ExamModelTemp.BarrelChest;
                        }
                        break;
                    case "呼吸音":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.BreathSounds = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.BreathSounds = ExamModelTemp.BreathSounds;
                            this.PhysicalExam.BreathSoundsEx = ExamModelTemp.BreathSoundsEx;
                        }
                        break;
                    case "罗音":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Rale = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Rale = ExamModelTemp.Rale;
                            this.PhysicalExam.RaleEx = ExamModelTemp.RaleEx;
                        }
                        break;
                    case "心率":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.HeartRate = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.HeartRate = ExamModelTemp.HeartRate;
                        }
                        break;
                    case "心律":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.HeartRhythm = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.HeartRhythm = ExamModelTemp.HeartRhythm;
                        }
                        break;
                    case "杂音":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Noise = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Noise = ExamModelTemp.Noise;
                            this.PhysicalExam.NoiseEx = ExamModelTemp.NoiseEx;
                        }
                        break;
                    case "包块":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.EnclosedMass = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.EnclosedMass = ExamModelTemp.EnclosedMass;
                            this.PhysicalExam.EnclosedMassEx = ExamModelTemp.EnclosedMassEx;
                        }
                        break;
                    case "下肢水肿":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Edema = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Edema = ExamModelTemp.Edema;
                        }
                        break;
                    case "足背动脉搏动":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.FootBack = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.FootBack = ExamModelTemp.FootBack;
                        }
                        break;
                    case "肛门指诊":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Anus = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Anus = ExamModelTemp.Anus;
                            this.PhysicalExam.AnusEx = ExamModelTemp.AnusEx;
                        }
                        break;
                    case "乳腺":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Breast = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Breast = ExamModelTemp.Breast;
                            this.PhysicalExam.BreastEx = ExamModelTemp.BreastEx;
                        }
                        break;
                    case "压痛":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.PressPain = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.PressPain = ExamModelTemp.PressPain;
                            this.PhysicalExam.PressPainEx = ExamModelTemp.PressPainEx;
                        }
                        break;
                    case "肝大":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Liver = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Liver = ExamModelTemp.Liver;
                            this.PhysicalExam.LiverEx = ExamModelTemp.LiverEx;
                        }
                        break;
                    case "脾大":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Spleen = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Spleen = ExamModelTemp.Spleen;
                            this.PhysicalExam.SpleenEx = ExamModelTemp.SpleenEx;
                        }
                        break;
                    case "移动性浊音":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Voiced = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Voiced = ExamModelTemp.Voiced;
                            this.PhysicalExam.VoicedEx = ExamModelTemp.VoicedEx;
                        }
                        break;
                    case "眼底":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.EyeRound = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.EyeRound = ExamModelTemp.EyeRound;
                            this.PhysicalExam.EyeRoundEx = ExamModelTemp.EyeRoundEx;
                        }
                        break;
                    case "其他":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Other = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Other = ExamModelTemp.Other;
                        }
                        break;
                    case "外阴":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Vulva = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Vulva = ExamModelTemp.Vulva;
                            this.PhysicalExam.VulvaEx = ExamModelTemp.VulvaEx;
                        }
                        break;
                    case "附件":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Attach = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Attach = ExamModelTemp.Attach;
                            this.PhysicalExam.AttachEx = ExamModelTemp.AttachEx;
                        }
                        break;
                    case "宫体":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Corpus = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Corpus = ExamModelTemp.Corpus;
                            this.PhysicalExam.CorpusEx = ExamModelTemp.CorpusEx;
                        }
                        break;
                    case "宫颈":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.CervixUteri = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.CervixUteri = ExamModelTemp.CervixUteri;
                            this.PhysicalExam.CervixUteriEx = ExamModelTemp.CervixUteriEx;
                        }
                        break;
                    case "阴道":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.PhysicalExam.Vagina = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.PhysicalExam.Vagina = ExamModelTemp.Vagina;
                            this.PhysicalExam.VaginaEx = ExamModelTemp.VaginaEx;
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
            RecordsPhysicalExamModel ExamModelTemp = new RecordsPhysicalExamBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (ExamModelTemp == null) ExamModelTemp = new RecordsPhysicalExamModel();
            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "皮肤":
                            if (string.IsNullOrEmpty(Convert.ToString(ExamModelTemp.Skin)))
                            {
                                this.label3.Text = "*皮肤";
                                this.label3.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label3.Text = "皮肤";
                                this.label3.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "巩膜":
                            if (string.IsNullOrEmpty(Convert.ToString(ExamModelTemp.Sclere)))
                            {
                                this.label2.Text = "*巩膜";
                                this.label2.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label2.Text = "巩膜";
                                this.label2.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "淋巴结":
                            if (string.IsNullOrEmpty(ExamModelTemp.Lymph))
                            {
                                this.label4.Text = "*淋巴结";
                                this.label4.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label4.Text = "淋巴结";
                                this.label4.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "桶状胸":
                            if (string.IsNullOrEmpty(ExamModelTemp.BarrelChest))
                            {
                                this.label68.Text = "*桶状胸:";
                                this.label68.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label68.Text = "桶状胸:";
                                this.label68.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "呼吸音":
                            if (string.IsNullOrEmpty(ExamModelTemp.BreathSounds))
                            {
                                this.label69.Text = "*呼吸音:";
                                this.label69.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label69.Text = "呼吸音:";
                                this.label69.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "罗音":
                            if (string.IsNullOrEmpty(ExamModelTemp.Rale))
                            {
                                this.label70.Text = "*罗音:";
                                this.label70.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label70.Text = "罗音:";
                                this.label70.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "心率":
                            if (string.IsNullOrEmpty(ExamModelTemp.HeartRate))
                            {
                                this.label71.Text = "*心率:";
                                this.label71.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label71.Text = "心率:";
                                this.label71.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "心律":
                            if (string.IsNullOrEmpty(ExamModelTemp.HeartRhythm))
                            {
                                this.label73.Text = "*心律:";
                                this.label73.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label73.Text = "心律:";
                                this.label73.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "杂音":
                            if (string.IsNullOrEmpty(ExamModelTemp.Noise))
                            {
                                this.label74.Text = "*杂音:";
                                this.label74.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label74.Text = "杂音:";
                                this.label74.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "包块":
                            if (string.IsNullOrEmpty(ExamModelTemp.EnclosedMass))
                            {
                                this.label75.Text = "*包块:";
                                this.label75.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label75.Text = "包块:";
                                this.label75.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "下肢水肿":
                            if (string.IsNullOrEmpty(ExamModelTemp.Edema))
                            {
                                this.label6.Text = "*下肢水肿:";
                                this.label6.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label6.Text = "下肢水肿:";
                                this.label6.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "足背动脉搏动":
                            if (string.IsNullOrEmpty(ExamModelTemp.FootBack))
                            {
                                this.label5.Text = "*足背动脉搏动:";
                                this.label5.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label5.Text = "足背动脉搏动:";
                                this.label5.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "压痛":
                            if (string.IsNullOrEmpty(ExamModelTemp.PressPain))
                            {
                                this.label78.Text = "*压痛:";
                                this.label78.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label78.Text = "压痛:";
                                this.label78.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "肝大":
                            if (string.IsNullOrEmpty(ExamModelTemp.Liver))
                            {
                                this.label76.Text = "*肝大:";
                                this.label76.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label76.Text = "肝大:";
                                this.label76.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "脾大":
                            if (string.IsNullOrEmpty(ExamModelTemp.Spleen))
                            {
                                this.label77.Text = "*脾大:";
                                this.label77.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label77.Text = "脾大:";
                                this.label77.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "移动性浊音":
                            if (string.IsNullOrEmpty(ExamModelTemp.Voiced))
                            {
                                this.label79.Text = "*移动性浊音:";
                                this.label79.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label79.Text = "移动性浊音:";
                                this.label79.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "其他":
                            if (string.IsNullOrEmpty(ExamModelTemp.Other))
                            {
                                this.radFKQiTa.Text = "*其他*";
                                this.radFKQiTa.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.radFKQiTa.Text = "其他*";
                                this.radFKQiTa.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "外阴":
                            if (this.Model != null && Model.Sex == "2")
                            {
                                if (string.IsNullOrEmpty(ExamModelTemp.Vulva))
                                {
                                    this.label80.Text = "*外阴";
                                    this.label80.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label80.Text = "外阴";
                                    this.label80.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;

                        case "阴道":
                            if (this.Model != null && Model.Sex == "2")
                            {
                                if (string.IsNullOrEmpty(ExamModelTemp.Vagina))
                                {
                                    this.label81.Text = "*阴道";
                                    this.label81.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label81.Text = "阴道";
                                    this.label81.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;

                        case "宫颈":
                            if (this.Model != null && Model.Sex == "2")
                            {
                                if (string.IsNullOrEmpty(ExamModelTemp.CervixUteri))
                                {
                                    this.label82.Text = "*宫颈";
                                    this.label82.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label82.Text = "宫颈";
                                    this.label82.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;

                        case "宫体":
                            if (this.Model != null && Model.Sex == "2")
                            {
                                if (string.IsNullOrEmpty(ExamModelTemp.Corpus))
                                {
                                    this.label83.Text = "*宫体";
                                    this.label83.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label83.Text = "宫体";
                                    this.label83.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;

                        case "附件":
                            if (this.Model != null && Model.Sex == "2")
                            {
                                if (string.IsNullOrEmpty(ExamModelTemp.Attach))
                                {
                                    this.label84.Text = "*附件";
                                    this.label84.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label84.Text = "附件";
                                    this.label84.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "眼底":
                            if (string.IsNullOrEmpty(ExamModelTemp.EyeRound))
                            {
                                this.label1.Text = "*眼底";
                                this.label1.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label1.Text = "眼底";
                                this.label1.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "乳腺":
                            if (string.IsNullOrEmpty(ExamModelTemp.Breast))
                            {
                                this.label8.Text = "*乳腺*:";
                                this.label8.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label8.Text = "乳腺*:";
                                this.label8.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "肛门指诊":
                            if (string.IsNullOrEmpty(ExamModelTemp.Anus))
                            {
                                this.label7.Text = "*肛门指诊*:";
                                this.label7.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label7.Text = "肛门指诊*:";
                                this.label7.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        default: break;
                    }
                }
            }
        }
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.cblhmn = new System.Windows.Forms.ComboBox();
            this.txtlhmnQiTa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cbScaler = new System.Windows.Forms.ComboBox();
            this.txtScalerQiTa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEyeReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtyandi = new System.Windows.Forms.TextBox();
            this.radEarY = new System.Windows.Forms.RadioButton();
            this.radEarZ = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSkinQiTa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSkin = new System.Windows.Forms.ComboBox();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.btnfkReset = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.radGTYC = new System.Windows.Forms.RadioButton();
            this.radFKGTWJYC = new System.Windows.Forms.RadioButton();
            this.panel14 = new System.Windows.Forms.Panel();
            this.radFKYYC = new System.Windows.Forms.RadioButton();
            this.radFKYWJYC = new System.Windows.Forms.RadioButton();
            this.panel13 = new System.Windows.Forms.Panel();
            this.radFKFJYC = new System.Windows.Forms.RadioButton();
            this.radFKFJWYC = new System.Windows.Forms.RadioButton();
            this.panel16 = new System.Windows.Forms.Panel();
            this.radFKGYC = new System.Windows.Forms.RadioButton();
            this.radFKGWJYC = new System.Windows.Forms.RadioButton();
            this.panel17 = new System.Windows.Forms.Panel();
            this.radFKWYC = new System.Windows.Forms.RadioButton();
            this.radFKWJYC = new System.Windows.Forms.RadioButton();
            this.txtFKFJYC = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.txtGTYC = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.txtFKGYC = new System.Windows.Forms.TextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.txtFKYYC = new System.Windows.Forms.TextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.txtFKWYC = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.txtqt = new System.Windows.Forms.TextBox();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.cmbxiazhishuizhong = new System.Windows.Forms.ComboBox();
            this.cmbzudongmai = new System.Windows.Forms.ComboBox();
            this.cbGM = new System.Windows.Forms.ComboBox();
            this.txtGMQiTa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRXQiTa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.cbLungs = new System.Windows.Forms.ComboBox();
            this.btnXinLv = new System.Windows.Forms.Button();
            this.txtLungsQiTa = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.radBellygdHave = new System.Windows.Forms.RadioButton();
            this.radBellyGdNHave = new System.Windows.Forms.RadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.radBellyzyHave1 = new System.Windows.Forms.RadioButton();
            this.radBellyzyNHave1 = new System.Windows.Forms.RadioButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.radBellyBkHave = new System.Windows.Forms.RadioButton();
            this.radBellyBkNHave = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.radBellypdHave1 = new System.Windows.Forms.RadioButton();
            this.radBellypdNHave = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radBellyYtHave = new System.Windows.Forms.RadioButton();
            this.radBellyYtNHave1 = new System.Windows.Forms.RadioButton();
            this.txtBellyzyHave = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.txtBellypdHave = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.txtBellyGdHave = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.txtBellybkHave = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.txtBellyYtHave = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radLungsY = new System.Windows.Forms.RadioButton();
            this.radLungsZ = new System.Windows.Forms.RadioButton();
            this.cmbxinguilv = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radLungsNo = new System.Windows.Forms.RadioButton();
            this.radLungsYes = new System.Windows.Forms.RadioButton();
            this.panel18 = new System.Windows.Forms.Panel();
            this.radHeartzyYes = new System.Windows.Forms.RadioButton();
            this.radHeartzyNo = new System.Windows.Forms.RadioButton();
            this.txtheartzyy = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.txtLungsY = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.txtHeartLv = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.radFKQiTa = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.groupBox32);
            this.panel1.Controls.Add(this.txtqt);
            this.panel1.Controls.Add(this.groupBox28);
            this.panel1.Controls.Add(this.groupBox25);
            this.panel1.Controls.Add(this.radFKQiTa);
            this.panel1.Location = new System.Drawing.Point(43, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1450, 661);
            this.panel1.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.Controls.Add(this.cblhmn);
            this.panel12.Controls.Add(this.txtlhmnQiTa);
            this.panel12.Controls.Add(this.label4);
            this.panel12.Location = new System.Drawing.Point(799, 44);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(617, 41);
            this.panel12.TabIndex = 3;
            // 
            // cblhmn
            // 
            this.cblhmn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cblhmn.FormattingEnabled = true;
            this.cblhmn.Items.AddRange(new object[] {
            "未触及",
            "锁骨上",
            "腋窝",
            "其他"});
            this.cblhmn.Location = new System.Drawing.Point(89, 6);
            this.cblhmn.Name = "cblhmn";
            this.cblhmn.Size = new System.Drawing.Size(147, 28);
            this.cblhmn.TabIndex = 51;
            this.cblhmn.SelectedIndexChanged += new System.EventHandler(this.cblhmn_SelectedIndexChanged);
            // 
            // txtlhmnQiTa
            // 
            this.txtlhmnQiTa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtlhmnQiTa.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtlhmnQiTa.Location = new System.Drawing.Point(242, 6);
            this.txtlhmnQiTa.MaxLength = 100;
            this.txtlhmnQiTa.Name = "txtlhmnQiTa";
            this.txtlhmnQiTa.ReadOnly = true;
            this.txtlhmnQiTa.Size = new System.Drawing.Size(261, 30);
            this.txtlhmnQiTa.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "淋巴结";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.cbScaler);
            this.panel11.Controls.Add(this.txtScalerQiTa);
            this.panel11.Controls.Add(this.label2);
            this.panel11.Location = new System.Drawing.Point(51, 44);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(726, 41);
            this.panel11.TabIndex = 2;
            // 
            // cbScaler
            // 
            this.cbScaler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScaler.FormattingEnabled = true;
            this.cbScaler.Items.AddRange(new object[] {
            "正常",
            " 黄染 ",
            "充血 ",
            "其他"});
            this.cbScaler.Location = new System.Drawing.Point(87, 6);
            this.cbScaler.Name = "cbScaler";
            this.cbScaler.Size = new System.Drawing.Size(242, 28);
            this.cbScaler.TabIndex = 4;
            this.cbScaler.SelectedIndexChanged += new System.EventHandler(this.cbScaler_SelectedIndexChanged);
            // 
            // txtScalerQiTa
            // 
            this.txtScalerQiTa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtScalerQiTa.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtScalerQiTa.Location = new System.Drawing.Point(421, 8);
            this.txtScalerQiTa.MaxLength = 100;
            this.txtScalerQiTa.Name = "txtScalerQiTa";
            this.txtScalerQiTa.ReadOnly = true;
            this.txtScalerQiTa.Size = new System.Drawing.Size(207, 30);
            this.txtScalerQiTa.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "巩膜";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btnEyeReset);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtyandi);
            this.panel3.Controls.Add(this.radEarY);
            this.panel3.Controls.Add(this.radEarZ);
            this.panel3.Location = new System.Drawing.Point(51, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(726, 41);
            this.panel3.TabIndex = 0;
            // 
            // btnEyeReset
            // 
            this.btnEyeReset.Location = new System.Drawing.Point(245, 6);
            this.btnEyeReset.Name = "btnEyeReset";
            this.btnEyeReset.Size = new System.Drawing.Size(84, 28);
            this.btnEyeReset.TabIndex = 3;
            this.btnEyeReset.Text = "重置";
            this.btnEyeReset.UseVisualStyleBackColor = true;
            this.btnEyeReset.Click += new System.EventHandler(this.btnEyeReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "眼底";
            // 
            // txtyandi
            // 
            this.txtyandi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtyandi.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyandi.Location = new System.Drawing.Point(421, 7);
            this.txtyandi.MaxLength = 100;
            this.txtyandi.Name = "txtyandi";
            this.txtyandi.ReadOnly = true;
            this.txtyandi.Size = new System.Drawing.Size(207, 30);
            this.txtyandi.TabIndex = 4;
            // 
            // radEarY
            // 
            this.radEarY.AutoSize = true;
            this.radEarY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radEarY.Location = new System.Drawing.Point(162, 9);
            this.radEarY.Name = "radEarY";
            this.radEarY.Size = new System.Drawing.Size(67, 24);
            this.radEarY.TabIndex = 2;
            this.radEarY.Text = "异常";
            this.radEarY.UseVisualStyleBackColor = true;
            // 
            // radEarZ
            // 
            this.radEarZ.AutoSize = true;
            this.radEarZ.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radEarZ.Location = new System.Drawing.Point(83, 9);
            this.radEarZ.Name = "radEarZ";
            this.radEarZ.Size = new System.Drawing.Size(67, 24);
            this.radEarZ.TabIndex = 1;
            this.radEarZ.Text = "正常";
            this.radEarZ.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.txtSkinQiTa);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cbSkin);
            this.panel4.Location = new System.Drawing.Point(799, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(617, 41);
            this.panel4.TabIndex = 1;
            // 
            // txtSkinQiTa
            // 
            this.txtSkinQiTa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSkinQiTa.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSkinQiTa.Location = new System.Drawing.Point(242, 6);
            this.txtSkinQiTa.MaxLength = 100;
            this.txtSkinQiTa.Name = "txtSkinQiTa";
            this.txtSkinQiTa.ReadOnly = true;
            this.txtSkinQiTa.Size = new System.Drawing.Size(264, 30);
            this.txtSkinQiTa.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "皮肤";
            // 
            // cbSkin
            // 
            this.cbSkin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkin.FormattingEnabled = true;
            this.cbSkin.Items.AddRange(new object[] {
            "正常",
            "潮红",
            "苍白",
            "发绀",
            "黄染 ",
            "色素沉着 ",
            "其他"});
            this.cbSkin.Location = new System.Drawing.Point(89, 7);
            this.cbSkin.Name = "cbSkin";
            this.cbSkin.Size = new System.Drawing.Size(147, 28);
            this.cbSkin.TabIndex = 50;
            this.cbSkin.SelectedIndexChanged += new System.EventHandler(this.cbSkin_SelectedIndexChanged);
            // 
            // groupBox32
            // 
            this.groupBox32.BackColor = System.Drawing.Color.Transparent;
            this.groupBox32.Controls.Add(this.btnfkReset);
            this.groupBox32.Controls.Add(this.panel15);
            this.groupBox32.Controls.Add(this.panel14);
            this.groupBox32.Controls.Add(this.panel13);
            this.groupBox32.Controls.Add(this.panel16);
            this.groupBox32.Controls.Add(this.panel17);
            this.groupBox32.Controls.Add(this.txtFKFJYC);
            this.groupBox32.Controls.Add(this.textBox12);
            this.groupBox32.Controls.Add(this.label84);
            this.groupBox32.Controls.Add(this.txtGTYC);
            this.groupBox32.Controls.Add(this.label83);
            this.groupBox32.Controls.Add(this.txtFKGYC);
            this.groupBox32.Controls.Add(this.label82);
            this.groupBox32.Controls.Add(this.txtFKYYC);
            this.groupBox32.Controls.Add(this.label81);
            this.groupBox32.Controls.Add(this.txtFKWYC);
            this.groupBox32.Controls.Add(this.label80);
            this.groupBox32.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox32.Location = new System.Drawing.Point(50, 437);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(1370, 159);
            this.groupBox32.TabIndex = 7;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "妇科*";
            // 
            // btnfkReset
            // 
            this.btnfkReset.Location = new System.Drawing.Point(675, 110);
            this.btnfkReset.Name = "btnfkReset";
            this.btnfkReset.Size = new System.Drawing.Size(107, 32);
            this.btnfkReset.TabIndex = 3;
            this.btnfkReset.Text = "妇科重置";
            this.btnfkReset.UseVisualStyleBackColor = true;
            this.btnfkReset.Click += new System.EventHandler(this.btnfkReset_Click);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.radGTYC);
            this.panel15.Controls.Add(this.radFKGTWJYC);
            this.panel15.Location = new System.Drawing.Point(676, 68);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(193, 30);
            this.panel15.TabIndex = 6;
            // 
            // radGTYC
            // 
            this.radGTYC.AutoSize = true;
            this.radGTYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radGTYC.Location = new System.Drawing.Point(112, 5);
            this.radGTYC.Name = "radGTYC";
            this.radGTYC.Size = new System.Drawing.Size(67, 24);
            this.radGTYC.TabIndex = 16;
            this.radGTYC.Text = "异常";
            this.radGTYC.UseVisualStyleBackColor = true;
            // 
            // radFKGTWJYC
            // 
            this.radFKGTWJYC.AutoSize = true;
            this.radFKGTWJYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radFKGTWJYC.Location = new System.Drawing.Point(3, 5);
            this.radFKGTWJYC.Name = "radFKGTWJYC";
            this.radFKGTWJYC.Size = new System.Drawing.Size(107, 24);
            this.radFKGTWJYC.TabIndex = 15;
            this.radFKGTWJYC.Text = "未见异常";
            this.radFKGTWJYC.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.radFKYYC);
            this.panel14.Controls.Add(this.radFKYWJYC);
            this.panel14.Location = new System.Drawing.Point(675, 26);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(194, 30);
            this.panel14.TabIndex = 2;
            // 
            // radFKYYC
            // 
            this.radFKYYC.AutoSize = true;
            this.radFKYYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radFKYYC.Location = new System.Drawing.Point(113, 3);
            this.radFKYYC.Name = "radFKYYC";
            this.radFKYYC.Size = new System.Drawing.Size(67, 24);
            this.radFKYYC.TabIndex = 8;
            this.radFKYYC.Text = "异常";
            this.radFKYYC.UseVisualStyleBackColor = true;
            // 
            // radFKYWJYC
            // 
            this.radFKYWJYC.AutoSize = true;
            this.radFKYWJYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radFKYWJYC.Location = new System.Drawing.Point(5, 3);
            this.radFKYWJYC.Name = "radFKYWJYC";
            this.radFKYWJYC.Size = new System.Drawing.Size(107, 24);
            this.radFKYWJYC.TabIndex = 7;
            this.radFKYWJYC.Text = "未见异常";
            this.radFKYWJYC.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.radFKFJYC);
            this.panel13.Controls.Add(this.radFKFJWYC);
            this.panel13.Location = new System.Drawing.Point(110, 110);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(206, 32);
            this.panel13.TabIndex = 8;
            // 
            // radFKFJYC
            // 
            this.radFKFJYC.AutoSize = true;
            this.radFKFJYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radFKFJYC.Location = new System.Drawing.Point(113, 5);
            this.radFKFJYC.Name = "radFKFJYC";
            this.radFKFJYC.Size = new System.Drawing.Size(67, 24);
            this.radFKFJYC.TabIndex = 20;
            this.radFKFJYC.Text = "异常";
            this.radFKFJYC.UseVisualStyleBackColor = true;
            // 
            // radFKFJWYC
            // 
            this.radFKFJWYC.AutoSize = true;
            this.radFKFJWYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radFKFJWYC.Location = new System.Drawing.Point(3, 5);
            this.radFKFJWYC.Name = "radFKFJWYC";
            this.radFKFJWYC.Size = new System.Drawing.Size(107, 24);
            this.radFKFJWYC.TabIndex = 19;
            this.radFKFJWYC.Text = "未见异常";
            this.radFKFJWYC.UseVisualStyleBackColor = true;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.radFKGYC);
            this.panel16.Controls.Add(this.radFKGWJYC);
            this.panel16.Location = new System.Drawing.Point(109, 68);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(207, 36);
            this.panel16.TabIndex = 4;
            // 
            // radFKGYC
            // 
            this.radFKGYC.AutoSize = true;
            this.radFKGYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radFKGYC.Location = new System.Drawing.Point(113, 6);
            this.radFKGYC.Name = "radFKGYC";
            this.radFKGYC.Size = new System.Drawing.Size(67, 24);
            this.radFKGYC.TabIndex = 12;
            this.radFKGYC.Text = "异常";
            this.radFKGYC.UseVisualStyleBackColor = true;
            // 
            // radFKGWJYC
            // 
            this.radFKGWJYC.AutoSize = true;
            this.radFKGWJYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radFKGWJYC.Location = new System.Drawing.Point(3, 6);
            this.radFKGWJYC.Name = "radFKGWJYC";
            this.radFKGWJYC.Size = new System.Drawing.Size(107, 24);
            this.radFKGWJYC.TabIndex = 11;
            this.radFKGWJYC.Text = "未见异常";
            this.radFKGWJYC.UseVisualStyleBackColor = true;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.radFKWYC);
            this.panel17.Controls.Add(this.radFKWJYC);
            this.panel17.Location = new System.Drawing.Point(109, 26);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(207, 36);
            this.panel17.TabIndex = 0;
            // 
            // radFKWYC
            // 
            this.radFKWYC.AutoSize = true;
            this.radFKWYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radFKWYC.Location = new System.Drawing.Point(113, 6);
            this.radFKWYC.Name = "radFKWYC";
            this.radFKWYC.Size = new System.Drawing.Size(67, 24);
            this.radFKWYC.TabIndex = 3;
            this.radFKWYC.Text = "异常";
            this.radFKWYC.UseVisualStyleBackColor = true;
            // 
            // radFKWJYC
            // 
            this.radFKWJYC.AutoSize = true;
            this.radFKWJYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radFKWJYC.Location = new System.Drawing.Point(5, 6);
            this.radFKWJYC.Name = "radFKWJYC";
            this.radFKWJYC.Size = new System.Drawing.Size(107, 24);
            this.radFKWJYC.TabIndex = 2;
            this.radFKWJYC.Text = "未见异常";
            this.radFKWJYC.UseVisualStyleBackColor = true;
            // 
            // txtFKFJYC
            // 
            this.txtFKFJYC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFKFJYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFKFJYC.Location = new System.Drawing.Point(340, 112);
            this.txtFKFJYC.MaxLength = 100;
            this.txtFKFJYC.Name = "txtFKFJYC";
            this.txtFKFJYC.ReadOnly = true;
            this.txtFKFJYC.Size = new System.Drawing.Size(242, 30);
            this.txtFKFJYC.TabIndex = 9;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(1136, 29);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(116, 30);
            this.textBox12.TabIndex = 19;
            this.textBox12.Visible = false;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label84.Location = new System.Drawing.Point(55, 117);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(49, 20);
            this.label84.TabIndex = 16;
            this.label84.Text = "附件";
            // 
            // txtGTYC
            // 
            this.txtGTYC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGTYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGTYC.Location = new System.Drawing.Point(891, 70);
            this.txtGTYC.MaxLength = 100;
            this.txtGTYC.Name = "txtGTYC";
            this.txtGTYC.ReadOnly = true;
            this.txtGTYC.Size = new System.Drawing.Size(228, 30);
            this.txtGTYC.TabIndex = 7;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label83.Location = new System.Drawing.Point(616, 75);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(49, 20);
            this.label83.TabIndex = 12;
            this.label83.Text = "宫体";
            // 
            // txtFKGYC
            // 
            this.txtFKGYC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFKGYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFKGYC.Location = new System.Drawing.Point(340, 70);
            this.txtFKGYC.MaxLength = 100;
            this.txtFKGYC.Name = "txtFKGYC";
            this.txtFKGYC.ReadOnly = true;
            this.txtFKGYC.Size = new System.Drawing.Size(242, 30);
            this.txtFKGYC.TabIndex = 5;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label82.Location = new System.Drawing.Point(55, 75);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(49, 20);
            this.label82.TabIndex = 8;
            this.label82.Text = "宫颈";
            // 
            // txtFKYYC
            // 
            this.txtFKYYC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFKYYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFKYYC.Location = new System.Drawing.Point(891, 28);
            this.txtFKYYC.MaxLength = 100;
            this.txtFKYYC.Name = "txtFKYYC";
            this.txtFKYYC.ReadOnly = true;
            this.txtFKYYC.Size = new System.Drawing.Size(230, 30);
            this.txtFKYYC.TabIndex = 3;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label81.Location = new System.Drawing.Point(614, 33);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(49, 20);
            this.label81.TabIndex = 4;
            this.label81.Text = "阴道";
            // 
            // txtFKWYC
            // 
            this.txtFKWYC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFKWYC.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFKWYC.Location = new System.Drawing.Point(340, 28);
            this.txtFKWYC.MaxLength = 100;
            this.txtFKWYC.Name = "txtFKWYC";
            this.txtFKWYC.ReadOnly = true;
            this.txtFKWYC.Size = new System.Drawing.Size(242, 30);
            this.txtFKWYC.TabIndex = 1;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label80.Location = new System.Drawing.Point(55, 33);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(49, 20);
            this.label80.TabIndex = 0;
            this.label80.Text = "外阴";
            // 
            // txtqt
            // 
            this.txtqt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtqt.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtqt.Location = new System.Drawing.Point(130, 610);
            this.txtqt.MaxLength = 100;
            this.txtqt.Name = "txtqt";
            this.txtqt.Size = new System.Drawing.Size(389, 30);
            this.txtqt.TabIndex = 8;
            // 
            // groupBox28
            // 
            this.groupBox28.BackColor = System.Drawing.Color.Transparent;
            this.groupBox28.Controls.Add(this.checkedListBox1);
            this.groupBox28.Controls.Add(this.cmbxiazhishuizhong);
            this.groupBox28.Controls.Add(this.cmbzudongmai);
            this.groupBox28.Controls.Add(this.cbGM);
            this.groupBox28.Controls.Add(this.txtGMQiTa);
            this.groupBox28.Controls.Add(this.label8);
            this.groupBox28.Controls.Add(this.txtRXQiTa);
            this.groupBox28.Controls.Add(this.label7);
            this.groupBox28.Controls.Add(this.label6);
            this.groupBox28.Controls.Add(this.label5);
            this.groupBox28.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox28.Location = new System.Drawing.Point(51, 331);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(1369, 98);
            this.groupBox28.TabIndex = 5;
            this.groupBox28.TabStop = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "未见异常",
            "乳房切除",
            "异常泌乳",
            "乳腺包块",
            "其他"});
            this.checkedListBox1.Location = new System.Drawing.Point(121, 61);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(648, 29);
            this.checkedListBox1.TabIndex = 4;
            // 
            // cmbxiazhishuizhong
            // 
            this.cmbxiazhishuizhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxiazhishuizhong.FormattingEnabled = true;
            this.cmbxiazhishuizhong.Items.AddRange(new object[] {
            "无",
            "单侧",
            "双侧不对称",
            "双侧对称"});
            this.cmbxiazhishuizhong.Location = new System.Drawing.Point(121, 21);
            this.cmbxiazhishuizhong.Name = "cmbxiazhishuizhong";
            this.cmbxiazhishuizhong.Size = new System.Drawing.Size(147, 28);
            this.cmbxiazhishuizhong.TabIndex = 0;
            // 
            // cmbzudongmai
            // 
            this.cmbzudongmai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbzudongmai.FormattingEnabled = true;
            this.cmbzudongmai.Items.AddRange(new object[] {
            "未触及",
            "触及双侧对称",
            "触及左侧弱或消失",
            "触及右侧弱或消失"});
            this.cmbzudongmai.Location = new System.Drawing.Point(439, 20);
            this.cmbzudongmai.Name = "cmbzudongmai";
            this.cmbzudongmai.Size = new System.Drawing.Size(158, 28);
            this.cmbzudongmai.TabIndex = 1;
            // 
            // cbGM
            // 
            this.cbGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGM.FormattingEnabled = true;
            this.cbGM.Items.AddRange(new object[] {
            "未及异常",
            " 触痛",
            "包块",
            "前列腺异常",
            "其他"});
            this.cbGM.Location = new System.Drawing.Point(747, 22);
            this.cbGM.Name = "cbGM";
            this.cbGM.Size = new System.Drawing.Size(147, 28);
            this.cbGM.TabIndex = 52;
            this.cbGM.SelectedIndexChanged += new System.EventHandler(this.cbGM_SelectedIndexChanged);
            // 
            // txtGMQiTa
            // 
            this.txtGMQiTa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGMQiTa.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGMQiTa.Location = new System.Drawing.Point(900, 23);
            this.txtGMQiTa.MaxLength = 100;
            this.txtGMQiTa.Name = "txtGMQiTa";
            this.txtGMQiTa.ReadOnly = true;
            this.txtGMQiTa.Size = new System.Drawing.Size(289, 30);
            this.txtGMQiTa.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(35, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "乳腺*:";
            // 
            // txtRXQiTa
            // 
            this.txtRXQiTa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRXQiTa.Font = new System.Drawing.Font("宋体", 15F);
            this.txtRXQiTa.Location = new System.Drawing.Point(776, 60);
            this.txtRXQiTa.MaxLength = 100;
            this.txtRXQiTa.Name = "txtRXQiTa";
            this.txtRXQiTa.ReadOnly = true;
            this.txtRXQiTa.Size = new System.Drawing.Size(321, 30);
            this.txtRXQiTa.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(625, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "肛门指诊*:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(5, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "下肢水肿:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(285, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "足背动脉搏动:";
            // 
            // groupBox25
            // 
            this.groupBox25.BackColor = System.Drawing.Color.Transparent;
            this.groupBox25.Controls.Add(this.cbLungs);
            this.groupBox25.Controls.Add(this.btnXinLv);
            this.groupBox25.Controls.Add(this.txtLungsQiTa);
            this.groupBox25.Controls.Add(this.panel10);
            this.groupBox25.Controls.Add(this.panel9);
            this.groupBox25.Controls.Add(this.panel8);
            this.groupBox25.Controls.Add(this.panel7);
            this.groupBox25.Controls.Add(this.panel6);
            this.groupBox25.Controls.Add(this.txtBellyzyHave);
            this.groupBox25.Controls.Add(this.label79);
            this.groupBox25.Controls.Add(this.txtBellypdHave);
            this.groupBox25.Controls.Add(this.label77);
            this.groupBox25.Controls.Add(this.txtBellyGdHave);
            this.groupBox25.Controls.Add(this.label76);
            this.groupBox25.Controls.Add(this.txtBellybkHave);
            this.groupBox25.Controls.Add(this.label75);
            this.groupBox25.Controls.Add(this.txtBellyYtHave);
            this.groupBox25.Controls.Add(this.label78);
            this.groupBox25.Controls.Add(this.panel2);
            this.groupBox25.Controls.Add(this.cmbxinguilv);
            this.groupBox25.Controls.Add(this.panel5);
            this.groupBox25.Controls.Add(this.panel18);
            this.groupBox25.Controls.Add(this.txtheartzyy);
            this.groupBox25.Controls.Add(this.label74);
            this.groupBox25.Controls.Add(this.label73);
            this.groupBox25.Controls.Add(this.txtLungsY);
            this.groupBox25.Controls.Add(this.label72);
            this.groupBox25.Controls.Add(this.label70);
            this.groupBox25.Controls.Add(this.txtHeartLv);
            this.groupBox25.Controls.Add(this.label71);
            this.groupBox25.Controls.Add(this.label69);
            this.groupBox25.Controls.Add(this.label68);
            this.groupBox25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox25.Location = new System.Drawing.Point(50, 94);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(1370, 237);
            this.groupBox25.TabIndex = 4;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "心肺及腹部";
            // 
            // cbLungs
            // 
            this.cbLungs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLungs.FormattingEnabled = true;
            this.cbLungs.Items.AddRange(new object[] {
            "无",
            "干罗音 ",
            "湿罗音",
            "其他"});
            this.cbLungs.Location = new System.Drawing.Point(93, 66);
            this.cbLungs.Name = "cbLungs";
            this.cbLungs.Size = new System.Drawing.Size(147, 28);
            this.cbLungs.TabIndex = 52;
            this.cbLungs.SelectedIndexChanged += new System.EventHandler(this.cbLungs_SelectedIndexChanged);
            // 
            // btnXinLv
            // 
            this.btnXinLv.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnXinLv.Location = new System.Drawing.Point(252, 105);
            this.btnXinLv.Name = "btnXinLv";
            this.btnXinLv.Size = new System.Drawing.Size(47, 31);
            this.btnXinLv.TabIndex = 6;
            this.btnXinLv.Text = "...";
            this.btnXinLv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXinLv.UseVisualStyleBackColor = true;
            this.btnXinLv.Click += new System.EventHandler(this.btnXinLv_Click);
            // 
            // txtLungsQiTa
            // 
            this.txtLungsQiTa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLungsQiTa.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLungsQiTa.Location = new System.Drawing.Point(248, 66);
            this.txtLungsQiTa.MaxLength = 100;
            this.txtLungsQiTa.Name = "txtLungsQiTa";
            this.txtLungsQiTa.ReadOnly = true;
            this.txtLungsQiTa.Size = new System.Drawing.Size(354, 30);
            this.txtLungsQiTa.TabIndex = 3;
            this.txtLungsQiTa.Text = " ";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.radBellygdHave);
            this.panel10.Controls.Add(this.radBellyGdNHave);
            this.panel10.Location = new System.Drawing.Point(838, 145);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(131, 35);
            this.panel10.TabIndex = 14;
            // 
            // radBellygdHave
            // 
            this.radBellygdHave.AutoSize = true;
            this.radBellygdHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBellygdHave.Location = new System.Drawing.Point(71, 7);
            this.radBellygdHave.Name = "radBellygdHave";
            this.radBellygdHave.Size = new System.Drawing.Size(47, 24);
            this.radBellygdHave.TabIndex = 19;
            this.radBellygdHave.TabStop = true;
            this.radBellygdHave.Text = "有";
            this.radBellygdHave.UseVisualStyleBackColor = true;
            // 
            // radBellyGdNHave
            // 
            this.radBellyGdNHave.AutoSize = true;
            this.radBellyGdNHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBellyGdNHave.Location = new System.Drawing.Point(8, 7);
            this.radBellyGdNHave.Name = "radBellyGdNHave";
            this.radBellyGdNHave.Size = new System.Drawing.Size(47, 24);
            this.radBellyGdNHave.TabIndex = 18;
            this.radBellyGdNHave.Text = "无";
            this.radBellyGdNHave.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.radBellyzyHave1);
            this.panel9.Controls.Add(this.radBellyzyNHave1);
            this.panel9.Location = new System.Drawing.Point(491, 192);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(131, 35);
            this.panel9.TabIndex = 18;
            // 
            // radBellyzyHave1
            // 
            this.radBellyzyHave1.AutoSize = true;
            this.radBellyzyHave1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBellyzyHave1.Location = new System.Drawing.Point(79, 7);
            this.radBellyzyHave1.Name = "radBellyzyHave1";
            this.radBellyzyHave1.Size = new System.Drawing.Size(47, 24);
            this.radBellyzyHave1.TabIndex = 27;
            this.radBellyzyHave1.TabStop = true;
            this.radBellyzyHave1.Text = "有";
            this.radBellyzyHave1.UseVisualStyleBackColor = true;
            // 
            // radBellyzyNHave1
            // 
            this.radBellyzyNHave1.AutoSize = true;
            this.radBellyzyNHave1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBellyzyNHave1.Location = new System.Drawing.Point(7, 7);
            this.radBellyzyNHave1.Name = "radBellyzyNHave1";
            this.radBellyzyNHave1.Size = new System.Drawing.Size(47, 24);
            this.radBellyzyNHave1.TabIndex = 26;
            this.radBellyzyNHave1.Text = "无";
            this.radBellyzyNHave1.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.radBellyBkHave);
            this.panel8.Controls.Add(this.radBellyBkNHave);
            this.panel8.Location = new System.Drawing.Point(493, 145);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(128, 35);
            this.panel8.TabIndex = 12;
            // 
            // radBellyBkHave
            // 
            this.radBellyBkHave.AutoSize = true;
            this.radBellyBkHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBellyBkHave.Location = new System.Drawing.Point(75, 7);
            this.radBellyBkHave.Name = "radBellyBkHave";
            this.radBellyBkHave.Size = new System.Drawing.Size(47, 24);
            this.radBellyBkHave.TabIndex = 15;
            this.radBellyBkHave.TabStop = true;
            this.radBellyBkHave.Text = "有";
            this.radBellyBkHave.UseVisualStyleBackColor = true;
            // 
            // radBellyBkNHave
            // 
            this.radBellyBkNHave.AutoSize = true;
            this.radBellyBkNHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBellyBkNHave.Location = new System.Drawing.Point(9, 7);
            this.radBellyBkNHave.Name = "radBellyBkNHave";
            this.radBellyBkNHave.Size = new System.Drawing.Size(47, 24);
            this.radBellyBkNHave.TabIndex = 14;
            this.radBellyBkNHave.Text = "无";
            this.radBellyBkNHave.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.radBellypdHave1);
            this.panel7.Controls.Add(this.radBellypdNHave);
            this.panel7.Location = new System.Drawing.Point(92, 191);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(131, 35);
            this.panel7.TabIndex = 16;
            // 
            // radBellypdHave1
            // 
            this.radBellypdHave1.AutoSize = true;
            this.radBellypdHave1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBellypdHave1.Location = new System.Drawing.Point(80, 7);
            this.radBellypdHave1.Name = "radBellypdHave1";
            this.radBellypdHave1.Size = new System.Drawing.Size(47, 24);
            this.radBellypdHave1.TabIndex = 23;
            this.radBellypdHave1.TabStop = true;
            this.radBellypdHave1.Text = "有";
            this.radBellypdHave1.UseVisualStyleBackColor = true;
            // 
            // radBellypdNHave
            // 
            this.radBellypdNHave.AutoSize = true;
            this.radBellypdNHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBellypdNHave.Location = new System.Drawing.Point(3, 7);
            this.radBellypdNHave.Name = "radBellypdNHave";
            this.radBellypdNHave.Size = new System.Drawing.Size(47, 24);
            this.radBellypdNHave.TabIndex = 22;
            this.radBellypdNHave.Text = "无";
            this.radBellypdNHave.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.radBellyYtHave);
            this.panel6.Controls.Add(this.radBellyYtNHave1);
            this.panel6.Location = new System.Drawing.Point(92, 145);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(131, 35);
            this.panel6.TabIndex = 10;
            // 
            // radBellyYtHave
            // 
            this.radBellyYtHave.AutoSize = true;
            this.radBellyYtHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBellyYtHave.Location = new System.Drawing.Point(80, 8);
            this.radBellyYtHave.Name = "radBellyYtHave";
            this.radBellyYtHave.Size = new System.Drawing.Size(47, 24);
            this.radBellyYtHave.TabIndex = 11;
            this.radBellyYtHave.TabStop = true;
            this.radBellyYtHave.Text = "有";
            this.radBellyYtHave.UseVisualStyleBackColor = true;
            // 
            // radBellyYtNHave1
            // 
            this.radBellyYtNHave1.AutoSize = true;
            this.radBellyYtNHave1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBellyYtNHave1.Location = new System.Drawing.Point(3, 8);
            this.radBellyYtNHave1.Name = "radBellyYtNHave1";
            this.radBellyYtNHave1.Size = new System.Drawing.Size(47, 24);
            this.radBellyYtNHave1.TabIndex = 10;
            this.radBellyYtNHave1.Text = "无";
            this.radBellyYtNHave1.UseVisualStyleBackColor = true;
            // 
            // txtBellyzyHave
            // 
            this.txtBellyzyHave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBellyzyHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBellyzyHave.Location = new System.Drawing.Point(630, 197);
            this.txtBellyzyHave.MaxLength = 100;
            this.txtBellyzyHave.Name = "txtBellyzyHave";
            this.txtBellyzyHave.ReadOnly = true;
            this.txtBellyzyHave.Size = new System.Drawing.Size(86, 30);
            this.txtBellyzyHave.TabIndex = 19;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label79.Location = new System.Drawing.Point(364, 201);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(119, 20);
            this.label79.TabIndex = 49;
            this.label79.Text = "移动性浊音:";
            // 
            // txtBellypdHave
            // 
            this.txtBellypdHave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBellypdHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBellypdHave.Location = new System.Drawing.Point(229, 197);
            this.txtBellypdHave.MaxLength = 100;
            this.txtBellypdHave.Name = "txtBellypdHave";
            this.txtBellypdHave.ReadOnly = true;
            this.txtBellypdHave.Size = new System.Drawing.Size(111, 30);
            this.txtBellypdHave.TabIndex = 17;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label77.Location = new System.Drawing.Point(28, 203);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(59, 20);
            this.label77.TabIndex = 47;
            this.label77.Text = "脾大:";
            // 
            // txtBellyGdHave
            // 
            this.txtBellyGdHave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBellyGdHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBellyGdHave.Location = new System.Drawing.Point(976, 149);
            this.txtBellyGdHave.MaxLength = 100;
            this.txtBellyGdHave.Name = "txtBellyGdHave";
            this.txtBellyGdHave.ReadOnly = true;
            this.txtBellyGdHave.Size = new System.Drawing.Size(110, 30);
            this.txtBellyGdHave.TabIndex = 15;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label76.Location = new System.Drawing.Point(772, 154);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(59, 20);
            this.label76.TabIndex = 45;
            this.label76.Text = "肝大:";
            // 
            // txtBellybkHave
            // 
            this.txtBellybkHave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBellybkHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBellybkHave.Location = new System.Drawing.Point(629, 149);
            this.txtBellybkHave.MaxLength = 100;
            this.txtBellybkHave.Name = "txtBellybkHave";
            this.txtBellybkHave.ReadOnly = true;
            this.txtBellybkHave.Size = new System.Drawing.Size(86, 30);
            this.txtBellybkHave.TabIndex = 13;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label75.Location = new System.Drawing.Point(424, 154);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(59, 20);
            this.label75.TabIndex = 43;
            this.label75.Text = "包块:";
            // 
            // txtBellyYtHave
            // 
            this.txtBellyYtHave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBellyYtHave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBellyYtHave.Location = new System.Drawing.Point(229, 149);
            this.txtBellyYtHave.MaxLength = 100;
            this.txtBellyYtHave.Name = "txtBellyYtHave";
            this.txtBellyYtHave.ReadOnly = true;
            this.txtBellyYtHave.Size = new System.Drawing.Size(111, 30);
            this.txtBellyYtHave.TabIndex = 11;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label78.Location = new System.Drawing.Point(28, 154);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(59, 20);
            this.label78.TabIndex = 41;
            this.label78.Text = "压痛:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radLungsY);
            this.panel2.Controls.Add(this.radLungsZ);
            this.panel2.Location = new System.Drawing.Point(491, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 30);
            this.panel2.TabIndex = 1;
            // 
            // radLungsY
            // 
            this.radLungsY.AutoSize = true;
            this.radLungsY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radLungsY.Location = new System.Drawing.Point(98, 5);
            this.radLungsY.Name = "radLungsY";
            this.radLungsY.Size = new System.Drawing.Size(67, 24);
            this.radLungsY.TabIndex = 9;
            this.radLungsY.TabStop = true;
            this.radLungsY.Text = "异常";
            this.radLungsY.UseVisualStyleBackColor = true;
            // 
            // radLungsZ
            // 
            this.radLungsZ.AutoSize = true;
            this.radLungsZ.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radLungsZ.Location = new System.Drawing.Point(16, 5);
            this.radLungsZ.Name = "radLungsZ";
            this.radLungsZ.Size = new System.Drawing.Size(67, 24);
            this.radLungsZ.TabIndex = 8;
            this.radLungsZ.Text = "正常";
            this.radLungsZ.UseVisualStyleBackColor = true;
            // 
            // cmbxinguilv
            // 
            this.cmbxinguilv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxinguilv.FormattingEnabled = true;
            this.cmbxinguilv.Items.AddRange(new object[] {
            "齐",
            "不齐",
            "绝对不齐"});
            this.cmbxinguilv.Location = new System.Drawing.Point(491, 107);
            this.cmbxinguilv.Name = "cmbxinguilv";
            this.cmbxinguilv.Size = new System.Drawing.Size(224, 28);
            this.cmbxinguilv.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radLungsNo);
            this.panel5.Controls.Add(this.radLungsYes);
            this.panel5.Location = new System.Drawing.Point(92, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(166, 30);
            this.panel5.TabIndex = 0;
            // 
            // radLungsNo
            // 
            this.radLungsNo.AutoSize = true;
            this.radLungsNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radLungsNo.Location = new System.Drawing.Point(26, 5);
            this.radLungsNo.Name = "radLungsNo";
            this.radLungsNo.Size = new System.Drawing.Size(47, 24);
            this.radLungsNo.TabIndex = 7;
            this.radLungsNo.Text = "否";
            this.radLungsNo.UseVisualStyleBackColor = true;
            // 
            // radLungsYes
            // 
            this.radLungsYes.AutoSize = true;
            this.radLungsYes.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radLungsYes.Location = new System.Drawing.Point(94, 5);
            this.radLungsYes.Name = "radLungsYes";
            this.radLungsYes.Size = new System.Drawing.Size(47, 24);
            this.radLungsYes.TabIndex = 8;
            this.radLungsYes.TabStop = true;
            this.radLungsYes.Text = "是";
            this.radLungsYes.UseVisualStyleBackColor = true;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.radHeartzyYes);
            this.panel18.Controls.Add(this.radHeartzyNo);
            this.panel18.Location = new System.Drawing.Point(838, 103);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(131, 35);
            this.panel18.TabIndex = 8;
            // 
            // radHeartzyYes
            // 
            this.radHeartzyYes.AutoSize = true;
            this.radHeartzyYes.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radHeartzyYes.Location = new System.Drawing.Point(71, 8);
            this.radHeartzyYes.Name = "radHeartzyYes";
            this.radHeartzyYes.Size = new System.Drawing.Size(47, 24);
            this.radHeartzyYes.TabIndex = 14;
            this.radHeartzyYes.Text = "有";
            this.radHeartzyYes.UseVisualStyleBackColor = true;
            // 
            // radHeartzyNo
            // 
            this.radHeartzyNo.AutoSize = true;
            this.radHeartzyNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radHeartzyNo.Location = new System.Drawing.Point(8, 9);
            this.radHeartzyNo.Name = "radHeartzyNo";
            this.radHeartzyNo.Size = new System.Drawing.Size(47, 24);
            this.radHeartzyNo.TabIndex = 13;
            this.radHeartzyNo.Text = "无";
            this.radHeartzyNo.UseVisualStyleBackColor = true;
            // 
            // txtheartzyy
            // 
            this.txtheartzyy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtheartzyy.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtheartzyy.Location = new System.Drawing.Point(976, 107);
            this.txtheartzyy.MaxLength = 100;
            this.txtheartzyy.Name = "txtheartzyy";
            this.txtheartzyy.ReadOnly = true;
            this.txtheartzyy.Size = new System.Drawing.Size(110, 30);
            this.txtheartzyy.TabIndex = 9;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label74.Location = new System.Drawing.Point(772, 112);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(59, 20);
            this.label74.TabIndex = 10;
            this.label74.Text = "杂音:";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label73.Location = new System.Drawing.Point(424, 114);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(59, 20);
            this.label73.TabIndex = 7;
            this.label73.Text = "心律:";
            // 
            // txtLungsY
            // 
            this.txtLungsY.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLungsY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLungsY.Location = new System.Drawing.Point(673, 26);
            this.txtLungsY.MaxLength = 100;
            this.txtLungsY.Name = "txtLungsY";
            this.txtLungsY.ReadOnly = true;
            this.txtLungsY.Size = new System.Drawing.Size(289, 30);
            this.txtLungsY.TabIndex = 2;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label72.Location = new System.Drawing.Point(172, 112);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(79, 20);
            this.label72.TabIndex = 6;
            this.label72.Text = "次/分钟";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(28, 74);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(59, 20);
            this.label70.TabIndex = 10;
            this.label70.Text = "罗音:";
            // 
            // txtHeartLv
            // 
            this.txtHeartLv.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHeartLv.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHeartLv.Location = new System.Drawing.Point(92, 107);
            this.txtHeartLv.MaxLength = 3;
            this.txtHeartLv.Name = "txtHeartLv";
            this.txtHeartLv.ReadOnly = true;
            this.txtHeartLv.Size = new System.Drawing.Size(76, 30);
            this.txtHeartLv.TabIndex = 5;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label71.Location = new System.Drawing.Point(28, 112);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(59, 20);
            this.label71.TabIndex = 4;
            this.label71.Text = "心率:";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label69.Location = new System.Drawing.Point(404, 29);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(79, 20);
            this.label69.TabIndex = 7;
            this.label69.Text = "呼吸音:";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label68.Location = new System.Drawing.Point(8, 30);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(79, 20);
            this.label68.TabIndex = 3;
            this.label68.Text = "桶状胸:";
            // 
            // radFKQiTa
            // 
            this.radFKQiTa.AutoSize = true;
            this.radFKQiTa.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radFKQiTa.Location = new System.Drawing.Point(59, 615);
            this.radFKQiTa.Name = "radFKQiTa";
            this.radFKQiTa.Size = new System.Drawing.Size(59, 20);
            this.radFKQiTa.TabIndex = 53;
            this.radFKQiTa.Text = "其他*";
            // 
            // PhysicalExamForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1460, 680);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "PhysicalExamForm";
            this.Load += new System.EventHandler(this.PhysicalExamForm_Load);
            this.VisibleChanged += new System.EventHandler(this.PhysicalExamForm_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            if (this.PhysicalExam == null)
            {
                return false;
            }
            if (PhysicalInfoFactory.ID == -1)
            {
                return true;
            }
            RecordsPhysicalExamBLL recordsPhysicalExamBll = new RecordsPhysicalExamBLL();
            this.PhysicalExam.OutKey = PhysicalInfoFactory.ID;
            if (!string.IsNullOrEmpty(RecordsManageMentModel.ECGExx))
            {
                if (RecordsManageMentModel.ECGExx.IndexOf("不齐") > -1)
                {
                    PhysicalExam.HeartRhythm = "2";
                }
                else
                {
                    PhysicalExam.HeartRhythm = "1";
                }
            }
            if (area == "禹城" || area == "乐陵")
            {
                try
                {
                    if (!string.IsNullOrEmpty(RecordsManageMentModel.ECGEx) && RecordsManageMentModel.ECGEx.IndexOf("房颤") > -1)
                    {
                        PhysicalExam.HeartRhythm = "3";
                    }
                    else if (!string.IsNullOrEmpty(RecordsManageMentModel.ECGEx) && RecordsManageMentModel.ECG.IndexOf("7") > -1)
                    {
                        PhysicalExam.HeartRhythm = "3";
                    }
                    else if (!string.IsNullOrEmpty(RecordsManageMentModel.ECGExx) && RecordsManageMentModel.ECGExx.IndexOf("不齐") > -1)
                    {
                        PhysicalExam.HeartRhythm = "2";
                    }
                    else
                    {
                        PhysicalExam.HeartRhythm = "1";
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
               
            }

            if (!recordsPhysicalExamBll.ExistsOutKey(this.PhysicalExam.IDCardNo, PhysicalInfoFactory.ID))
            {
                recordsPhysicalExamBll.Add(this.PhysicalExam);
            }
            else
            {
                recordsPhysicalExamBll.Update(this.PhysicalExam);
            }
            return true;
        }

        private void SimpleBinding(TextBox tb, string member)
        {
            Binding binding = new Binding("Text", this.PhysicalExam, member, false, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += new ConvertEventHandler(this.bd_ParseStr);
            tb.DataBindings.Add(binding);
        }

        private void PhysicalExamForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void PhysicalExamForm_VisibleChanged(object sender, EventArgs e)
        {
            RecordsManageMentModel.Edema = (cmbxiazhishuizhong.SelectedIndex + 1).ToString();
            RecordsManageMentModel.HeartRate = txtHeartLv.Text;
            RecordsManageMentModel.Noise = this.zayin.Choose;
            RecordsManageMentModel.NoiseEx = this.zayin.Choose_EX;
        }

        public void UpdataToModel()
        {
            this.PhysicalExam.IDCardNo = this.Model.IDCardNo;
            if (this.cbSkin.SelectedIndex != -1)//皮肤
            {
                this.PhysicalExam.Skin = Convert.ToString(this.cbSkin.SelectedIndex + 1);
            }
            if (this.cbScaler.SelectedIndex != -1)//巩膜
            {
                this.PhysicalExam.Sclere = Convert.ToString(this.cbScaler.SelectedIndex + 1);
            }
            if (this.cblhmn.SelectedIndex != -1) //淋巴结
            {
                this.PhysicalExam.Lymph = Convert.ToString(this.cblhmn.SelectedIndex + 1);
            }
            this.PhysicalExam.BarrelChest = this.radLungsNo.Checked ? "1" : "2";
            this.PhysicalExam.BreathSounds = this.huxi.Choose;
            this.PhysicalExam.BreathSoundsEx = this.huxi.Choose_EX;
            if (this.cbLungs.SelectedIndex != -1) //啰音
            {
                this.PhysicalExam.Rale = Convert.ToString(this.cbLungs.SelectedIndex + 1);
            }

            this.PhysicalExam.HeartRate = this.txtHeartLv.Text;
            this.PhysicalExam.HeartRhythm = Convert.ToString((int)(this.cmbxinguilv.SelectedIndex + 1));
            this.PhysicalExam.Noise = this.zayin.Choose;
            this.PhysicalExam.NoiseEx = this.zayin.Choose_EX;
            this.PhysicalExam.PressPain = this.yatong.Choose;
            this.PhysicalExam.PressPainEx = this.yatong.Choose_EX;
            this.PhysicalExam.EnclosedMass = this.baokuai.Choose;
            this.PhysicalExam.EnclosedMassEx = this.baokuai.Choose_EX;
            this.PhysicalExam.Liver = this.ganda.Choose;
            this.PhysicalExam.LiverEx = this.ganda.Choose_EX;
            this.PhysicalExam.Spleen = this.pida.Choose;
            this.PhysicalExam.SpleenEx = this.pida.Choose_EX;
            this.PhysicalExam.Voiced = this.yidongzhuoyin.Choose;
            this.PhysicalExam.VoicedEx = this.yidongzhuoyin.Choose_EX;
            this.PhysicalExam.EyeRound = this.eye.Choose;
            this.PhysicalExam.EyeRoundEx = this.eye.Choose_EX;
            this.PhysicalExam.Edema = Convert.ToString((int)(this.cmbxiazhishuizhong.SelectedIndex + 1));
            this.PhysicalExam.FootBack = Convert.ToString((int)(this.cmbzudongmai.SelectedIndex + 1));
            if (this.cbGM.SelectedIndex != -1)//肛门指诊
            {
                this.PhysicalExam.Anus = Convert.ToString(this.cbGM.SelectedIndex + 1);
            }
            this.PhysicalExam.Breast = this.ruxian.FinalResult;
            this.PhysicalExam.BreastEx = this.ruxian.FinalResultEX;
            if (this.Model.Sex == "2")
            {
                this.PhysicalExam.Vulva = this.waiyin.Choose;
                this.PhysicalExam.VulvaEx = this.waiyin.Choose_EX;
                this.PhysicalExam.Vagina = this.yindao.Choose;
                this.PhysicalExam.VaginaEx = this.yindao.Choose_EX;
                this.PhysicalExam.CervixUteri = this.gongjing.Choose;
                this.PhysicalExam.CervixUteriEx = this.gongjing.Choose_EX;
                this.PhysicalExam.Corpus = this.gongti.Choose;
                this.PhysicalExam.CorpusEx = this.gongti.Choose_EX;
                this.PhysicalExam.Attach = this.fujian.Choose;
                this.PhysicalExam.AttachEx = this.fujian.Choose_EX;
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public RecordsPhysicalExamModel PhysicalExam { get; set; }

        public RecordsGeneralConditionModel GerneralCondition { get; set; }

        public string SaveDataInfo { get; set; }

        //眼底重置功能
        private void btnEyeReset_Click(object sender, EventArgs e)
        {
            this.radEarZ.Checked = false;
            this.radEarY.Checked = false;
            this.txtyandi.Text = null;
            Application.DoEvents();
        }

        private void btnfkReset_Click(object sender, EventArgs e) //妇科重置
        {
            this.txtFKWYC.Clear();
            this.radFKWJYC.Checked = false;
            this.radFKWYC.Checked = false;

            this.txtFKGYC.Clear();
            this.radFKGWJYC.Checked = false;
            this.radFKGYC.Checked = false;

            this.txtFKFJYC.Clear();
            this.radFKFJWYC.Checked = false;
            this.radFKFJYC.Checked = false;

            this.txtFKYYC.Clear();
            this.radFKYWJYC.Checked = false;
            this.radFKYYC.Checked = false;

            this.txtGTYC.Clear();
            this.radFKGTWJYC.Checked = false;
            this.radGTYC.Checked = false;

        }

        private void cbSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbSkin.SelectedIndex == 6)
            {
                this.txtSkinQiTa.ReadOnly = false;
            }
            else
            {
                this.txtSkinQiTa.Clear();
                this.txtSkinQiTa.ReadOnly = true;
            }
        }

        private void cbScaler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbScaler.SelectedIndex == 3)//其他
            {
                this.txtScalerQiTa.ReadOnly = false;
            }
            else
            {
                this.txtScalerQiTa.Clear();
                this.txtScalerQiTa.ReadOnly = true;
            }
        }

        private void cblhmn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cblhmn.SelectedIndex == 3)//其他
            {
                this.txtlhmnQiTa.ReadOnly = false;
            }
            else
            {
                this.txtlhmnQiTa.Clear();
                this.txtlhmnQiTa.ReadOnly = true;
            }
        }

        private void cbLungs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbLungs.SelectedIndex == 3)//其他
            {
                this.txtLungsQiTa.ReadOnly = false;
            }
            else
            {
                this.txtLungsQiTa.ReadOnly = true;
                this.txtLungsQiTa.Clear();
            }
        }

        private void cbGM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbGM.SelectedIndex == 4)
            {
                this.txtGMQiTa.ReadOnly = false;
            }
            else
            {
                this.txtGMQiTa.ReadOnly = true;
                this.txtGMQiTa.Clear();
            }
        }
    }
}