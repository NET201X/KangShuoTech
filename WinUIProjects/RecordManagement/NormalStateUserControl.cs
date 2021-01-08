
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using System.IO;
using System.Data;
using System.Reflection;
using System.Configuration;

namespace RecordManagement
{
    public class NormalStateUserControl : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<RecordsGeneralConditionModel> bindingManager;
        private Button btnBreathe;
        private Button btnCount;
        private Button btnHeight;
        private Button btnLeftBP;
        private Button btnMaiLv;
        private Button btnRightBP;
        private Button btnSelectBW;
        private Button btnTemp;
        private CheckedListBox chBbz;
        private ComboBox cmbzilinengli;
        private IContainer components;
        private InputRangeStr doctor;
        private DateTimePicker dtpCheckDate;
        private GroupBox groupBox1;
        private GroupBox groupBox11;
        private GroupBox groupBox12;
        private GroupBox groupBox13;
        private GroupBox groupBox14;
        private GroupBox groupBox15;
        private GroupBox groupBox2;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private List<ItemDictonaryModel<string>> jiankang;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label13;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label33;
        private Label label35;
        private Label label36;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private LinkLabel lkbOld;
        private SingleItemT<RecordsGeneralConditionModel> qinggan;
        private RadioButton radqgcsyanx;
        private RadioButton radqgcsyx;
        private RadioButton radrzcsyanx;
        private RadioButton radrzcsyx;
        private SingleItemT<RecordsGeneralConditionModel> renzhi;
        private TextBox tbDoctor;
        private TextBox tbHeight;
        private TextBox tbLeftH;
        private TextBox tbLeftL;
        private TextBox tbName;
        private TextBox tbRightH;
        private TextBox tbRightL;
        private TextBox tbWeight;
        private TextBox txthxpl;
        private TextBox txttiwen;
        private TextBox txttzzs;
        private TextBox txtyaowei;
        private TextBox txtyuzf;
        private TextBox txtzhengzhuangqita;
        private TextBox txtzlzf;
        private CMoreChange zhengzhuang;
        private List<ItemDictonaryModel<string>> ziling;
        private int n;
        private Button btnYaowei;
        private TextBox tbLeftReason;
        private TextBox tbRightReason;
        private Label label12;
        private Label label9;
        private int m;
        private bool flagdelet = true;
        public RecordsSelfcareabilityModel SelfcareabilityModel;
        private Button btnHW;
        private Button btnhxpl;
        private TextBox tbMailv;
        private ComboBox cmbziwopingu;
        private Label label14;
        private ComboBox cbOldMange;
        private Button btnPhoto;
        private int flagfactoryID = 0;//记录页面 PhysicalInfoFactory.ID的初始值
        private DataSet dsRequire;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径
        private string PhotosPath = ConfigurationManager.AppSettings["PhotosPath"] == null ? @"D:/QCSoft/photos/" : ConfigurationManager.AppSettings["PhotosPath"].ToString(); //拍照照片路径

        public NormalStateUserControl(RecordsPhysicalExamModel phy)
        {
            this.InitializeComponent();
            this.PhysicalExam = phy;
            Random ran = new Random();
            n = ran.Next(1, 8);
            m = 0;
            while (m < n)  //m大n小
            {
                m = ran.Next(1, 8);
            }
            this.InitControlSource();
            this.EveryThingIsOk = false;
        }

        private void bd_Parse(object sender, ConvertEventArgs e)
        {
            decimal num;
            Predicate<InputRangeDec> match = null;
            Binding bd = sender as Binding;
            if (decimal.TryParse(e.Value.ToString(), out num))
            {
                if (match == null)
                {
                    match = c => c.Name == bd.BindingMemberInfo.BindingField;
                }
                InputRangeDec dec = this.inputRanges.Find(match);
                if (dec != null)
                {
                    if (dec.CheckIt(ref num))
                    {
                        bd.Control.BackColor = Color.WhiteSmoke;
                        e.Value = num;
                    }
                    else
                    {
                        bd.Control.BackColor = Color.Salmon;
                    }
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
            Binding binding = sender as Binding;
            InputRangeStr str2 = this.inputrange_str[0];
            if (str2 != null)
            {
                if (Encoding.GetEncoding("GB2312").GetByteCount(s) > str2.BytesCount)
                {
                    str2.ErrorInput = true;
                    binding.Control.BackColor = Color.Salmon;
                }
                else
                {
                    str2.ErrorInput = false;
                    binding.Control.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void btnBreathe_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "98")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                //this.txthxpl.Text = select.m_Result.value1;
                if (Convert.ToInt32(select.m_Result.value1) / 4 >= 20)
                {
                    this.txthxpl.Text = "20";
                }
                else if (Convert.ToInt32(select.m_Result.value1) / 4 <= 16)
                {
                    this.txthxpl.Text = "16";
                }
                else
                {
                    this.txthxpl.Text = Convert.ToString(Convert.ToInt32(select.m_Result.value1) / 4);
                }

            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            decimal num;
            decimal num2;
            if ((decimal.TryParse(this.tbHeight.Text, out num) && decimal.TryParse(this.tbWeight.Text, out num2)) && (num != 0M))
            {
                decimal num3 = num / 100M;
                decimal num4 = num3 * num3;
                this.txttzzs.Text = (num2 / num4).ToString("0.00");
            }
        }
        private void btnYaowei_Click(object sender, EventArgs e)
        {
            decimal num;
            decimal num2;
            if ((decimal.TryParse(this.tbHeight.Text, out num) && decimal.TryParse(this.tbWeight.Text, out num2)) && (num != 0M))
            {
                decimal num3 = num / 100M;
                decimal num4 = num3 * num3;
                string stryw = (num2 * (decimal)3.3 / num4 + (decimal)5).ToString("0.00");
                this.txtyaowei.Text = stryw.Remove(stryw.LastIndexOf('.'));
            }
        }
        private void btnHeight_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "39")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tbHeight.Text = select.m_Result.value1;
                //腰围计算
                decimal num;
                decimal num2;
                if ((decimal.TryParse(this.tbHeight.Text, out num) && decimal.TryParse(this.tbWeight.Text, out num2)) && (num != 0M))
                {
                    decimal num3 = num / 100M;
                    decimal num4 = num3 * num3;
                    this.txtyaowei.Text = (num2 * (decimal)3.3 / num4 + (decimal)5).ToString("0");
                }
            }
        }

        private void btnLeftBP_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "20", "Left")
            {
                ItemTypeName = "血压",
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.GerneralCondition.LeftHeight = new decimal?(int.Parse(select.m_Result.value1));
                this.GerneralCondition.LeftPre = new decimal?(int.Parse(select.m_Result.value2));
                this.tbLeftH.Text = Convert.ToString(int.Parse(select.m_Result.value1));
                this.tbLeftL.Text = Convert.ToString(int.Parse(select.m_Result.value2));
            }
        }

        private void btnMaiLv_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "32")
            {
                ItemTypeName = "脉率",
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tbMailv.Text = select.m_Result.value2;
                if (Convert.ToInt32(select.m_Result.value2) / 4 >= 20)
                {
                    this.GerneralCondition.BreathRate = 20;
                }
                else if (Convert.ToInt32(select.m_Result.value2) / 4 <= 16)
                {
                    this.GerneralCondition.BreathRate = 16;
                }
                else
                {
                    this.GerneralCondition.BreathRate = new decimal?(Convert.ToInt32(select.m_Result.value2) / 4);
                }
            }
        }

        private void btnRightBP_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "20", "Right")
            {
                ItemTypeName = "血压",
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.GerneralCondition.RightHeight = new decimal?(int.Parse(select.m_Result.value1));
                this.GerneralCondition.RightPre = new decimal?(int.Parse(select.m_Result.value2));
                this.tbRightH.Text = Convert.ToString(int.Parse(select.m_Result.value1));
                this.tbRightL.Text = Convert.ToString(int.Parse(select.m_Result.value2));
            }
        }

        private void btnSelectBW_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "22")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.tbWeight.Text = select.m_Result.value1;
                //腰围计算
                decimal num;
                decimal num2;
                if ((decimal.TryParse(this.tbHeight.Text, out num) && decimal.TryParse(this.tbWeight.Text, out num2)) && (num != 0M))
                {
                    decimal num3 = num / 100M;
                    decimal num4 = num3 * num3;
                    this.txtyaowei.Text = (num2 * (decimal)3.3 / num4 + (decimal)5).ToString("0");
                }
            }
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "40")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.txttiwen.Text = select.m_Result.value1;
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            if ((!this.bindingManager.ErrorInput && !this.zhengzhuang.ErrorInput) && ((!this.qinggan.ErrorInput && !this.renzhi.ErrorInput) && !this.doctor.ErrorInput))
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

        private void InitControlSource()
        {
            this.jiankang = new List<ItemDictonaryModel<string>>();
            this.jiankang.Add(new ItemDictonaryModel<string>("满意", "1"));
            this.jiankang.Add(new ItemDictonaryModel<string>("基本满意", "2"));
            this.jiankang.Add(new ItemDictonaryModel<string>("说不清楚", "3"));
            this.jiankang.Add(new ItemDictonaryModel<string>("不太满意", "4"));
            this.jiankang.Add(new ItemDictonaryModel<string>("不满意", "5"));
            this.cmbziwopingu.DisplayMember = "DISPLAYMEMBER";
            this.cmbziwopingu.ValueMember = "VALUEMEMBER";
            this.cmbziwopingu.DataSource = this.jiankang;
            this.ziling = new List<ItemDictonaryModel<string>>();
            this.ziling.Add(new ItemDictonaryModel<string>("可自理(0-3分)", "1"));
            this.ziling.Add(new ItemDictonaryModel<string>("轻度依赖(4-8分)", "2"));
            this.ziling.Add(new ItemDictonaryModel<string>("中度依赖(9-18分)", "3"));
            this.ziling.Add(new ItemDictonaryModel<string>("不能自理(>=19分)", "4"));
            this.cmbzilinengli.DisplayMember = "DISPLAYMEMBER";
            this.cmbzilinengli.ValueMember = "VALUEMEMBER";
            this.cmbzilinengli.DataSource = this.ziling;
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("BreathRate", 200M, false));
            this.inputRanges.Add(new InputRangeDec("PulseRate", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Weight", 2000M, true));
            this.inputRanges.Add(new InputRangeDec("LeftPre", 300M, false));
            this.inputRanges.Add(new InputRangeDec("LeftHeight", 300M, false));
            this.inputRanges.Add(new InputRangeDec("RightPre", 300M, false));
            this.inputRanges.Add(new InputRangeDec("RightHeight", 300M, false));
            this.inputRanges.Add(new InputRangeDec("BMI", 1000M));
            this.inputRanges.Add(new InputRangeDec("InterScore", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("GloomyScore", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Height", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("AnimalHeat", 100M));
            this.inputRanges.Add(new InputRangeDec("Waistline", 1000M, false));
            this.doctor = new InputRangeStr("Doctor", 30);
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("Doctor", 30));
        }

        public void InitEveryThing()
        {
            dsRequire = new RequireBLL().GetList("TabName = '健康体检' AND Comment = '一般状况' ");

            if (!Directory.Exists(SignPath))
            {
                Directory.CreateDirectory(SignPath);
            }

            GetRecordsManageMentModelNull();

            this.flagfactoryID = PhysicalInfoFactory.ID;
            PhysicalInfoFactory.falgID = PhysicalInfoFactory.ID;

            if (PhysicalInfoFactory.ID == 0)
            {
                this.CustomerBaseInfo = new RecordsCustomerBaseInfoBLL().GetModelByWhere(string.Format(" IDCardNo='{0}' and CheckDate='{1}'", this.Model.IDCardNo, DateTime.Now.ToString("yyyyMMdd")));
                this.dtpCheckDate.Value = DateTime.Now;
                flagdelet = false;
            }
            else
            {
                this.CustomerBaseInfo = new RecordsCustomerBaseInfoBLL().GetModelByID(PhysicalInfoFactory.ID);
            }

            if (this.CustomerBaseInfo == null)
            {
                RecordsCustomerBaseInfoModel recordsCustomerBaseInfoModel = new RecordsCustomerBaseInfoModel
                {
                    IDCardNo = this.Model.IDCardNo
                };
                this.CustomerBaseInfo = recordsCustomerBaseInfoModel;
                this.CustomerBaseInfo.Doctor = ConfigHelper.GetNode("doctorName");
                this.CustomerBaseInfo.CreateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.CustomerBaseInfo.CreateDate = new DateTime?(DateTime.Today);
            }
            else
            {
                if (this.CustomerBaseInfo.CheckDate.HasValue && PhysicalInfoFactory.ID > 0)
                {
                    this.dtpCheckDate.Value = this.CustomerBaseInfo.CheckDate.Value;
                }
                else  this.dtpCheckDate.Value = DateTime.Now;

                if (this.CustomerBaseInfo.CheckDate.HasValue && this.CustomerBaseInfo.CheckDate.Value == DateTime.Now.Date)
                {
                    //如果最后一笔数据的体检日期与当天的体检日期相同，就新增时候就显示出所有数据。
                    PhysicalInfoFactory.falgID = 1;
                }

                PhysicalInfoFactory.ID = CustomerBaseInfo.ID;
                this.CustomerBaseInfo.LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.CustomerBaseInfo.LastUpdateDate = new DateTime?(DateTime.Today);

                if (string.IsNullOrEmpty(this.CustomerBaseInfo.Doctor))
                {
                    this.CustomerBaseInfo.Doctor = ConfigHelper.GetNode("doctorName");
                }
            }

            RecordsManageMentModel.CheckDate = this.dtpCheckDate.Value;

            this.GerneralCondition = new RecordsGeneralConditionBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (this.GerneralCondition == null)
            {
                RecordsGeneralConditionModel recordsGeneralConditionModel = new RecordsGeneralConditionModel
                {
                    IDCardNo = this.Model.IDCardNo
                };
                this.GerneralCondition = recordsGeneralConditionModel;
            }
            else
            {
                this.SelfcareabilityModel = new RecordsSelfcareabilityBLL().GetModelID(this.GerneralCondition.SelfID);
            }

            if (PhysicalInfoFactory.falgID == 0)
            {
                this.PresetValue();//默认项设置
            }

            this.bindingManager = new SimpleBindingManager<RecordsGeneralConditionModel>(this.inputRanges, this.inputrange_str, this.GerneralCondition);
            CMoreChange change = new CMoreChange
            {
                MoreChange = this.chBbz,
                Name = "症状",
                Other = this.txtzhengzhuangqita,
                Unusual = "无症状",
                MaxBytesCount = 200
            };
            this.zhengzhuang = change;
            this.zhengzhuang.TransInfo(this.CustomerBaseInfo.Symptom, this.CustomerBaseInfo.Other);
            SingleItemT<RecordsGeneralConditionModel> mt = new SingleItemT<RecordsGeneralConditionModel>(this.GerneralCondition, 1000M)
            {
                Usual = this.radrzcsyx,
                Unusual = this.radrzcsyanx,
                Info = this.txtzlzf,
                StrUsual = "1",
                StrUnusual = "2"
            };
            this.renzhi = mt;
            this.renzhi.BindProperty("OldRecognise", "InterScore");
            SingleItemT<RecordsGeneralConditionModel> mt2 = new SingleItemT<RecordsGeneralConditionModel>(this.GerneralCondition, 1000M)
            {
                Usual = this.radqgcsyx,
                Unusual = this.radqgcsyanx,
                Info = this.txtyuzf,
                StrUsual = "1",
                StrUnusual = "2"
            };
            this.qinggan = mt2;
            this.qinggan.BindProperty("OldEmotion", "GloomyScore");
            this.tbName.Text = this.Model.CustomerName;

            this.bindingManager.SimpleBinding(this.txtyaowei, "Waistline", true);
            this.SimpleBindingC(this.tbDoctor, "Doctor", false);
            this.bindingManager.SimpleBinding(this.txttzzs, "BMI", true);
            this.bindingManager.SimpleBinding(this.tbHeight, "Height", true);
            this.bindingManager.SimpleBinding(this.txthxpl, "BreathRate", true);
            this.bindingManager.SimpleBinding(this.tbLeftH, "LeftHeight", true);
            this.bindingManager.SimpleBinding(this.tbLeftL, "LeftPre", true);
            this.bindingManager.SimpleBinding(this.tbRightH, "RightHeight", true);
            this.bindingManager.SimpleBinding(this.tbRightL, "RightPre", true);
            this.bindingManager.SimpleBinding(this.tbMailv, "PulseRate", true);
            this.bindingManager.SimpleBinding(this.tbWeight, "Weight", true);

            //体温
            if (this.GerneralCondition.AnimalHeat.ToString() != "")
            {
                GerneralCondition.AnimalHeat = Math.Round(decimal.Parse(GerneralCondition.AnimalHeat.ToString()), 1);
            }

            this.SimpleBindingk(this.txttiwen, "AnimalHeat", true);
            this.SimpleBindingG(this.tbLeftReason, "LeftReason", false);
            this.SimpleBindingG(this.tbRightReason, "RightReason", false);
            this.bindingManager.SimpleBinding(this.cmbziwopingu, "OldHealthStaus");
            this.cmbzilinengli.DataBindings.Add(new Binding("SelectedValue", this.GerneralCondition, "OldSelfCareability", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.cmbzilinengli.DataBindings[0].DataSourceNullValue = string.Empty;

            if (!string.IsNullOrEmpty(this.GerneralCondition.OldMange))
            {
                this.cbOldMange.SelectedIndex = int.Parse(this.GerneralCondition.OldMange) - 1;
            }

            string node = ConfigHelper.GetNode("ds_modify");

            if (string.IsNullOrEmpty(node))
            {
                node = "111100110000111";
                ConfigHelper.WriteNode("ds_modify", "111100110000111");
            }

            MustChoose();
            this.EveryThingIsOk = true;
        }

        private void SimpleBindingk(TextBox tb, string member, bool formate)
        {
            Binding binding = new Binding("Text", this.GerneralCondition, member, formate, DataSourceUpdateMode.OnPropertyChanged);
            if (formate)
            {
                binding.Parse += new ConvertEventHandler(this.bd_Parsek);
            }
            else
            {
                binding.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
            tb.DataBindings.Add(binding);
        }

        private void bd_Parsek(object sender, ConvertEventArgs e)
        {
            decimal num;
            Binding binding = sender as Binding;
            if (decimal.TryParse(e.Value.ToString(), out num))
            {
                if ((num >= 0M) && (num < 1000M))
                {
                    binding.Control.BackColor = Color.WhiteSmoke;
                    e.Value = num.ToString(".0");
                    //e.Value = num;
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

        //默认项设置
        private void PresetValue()
        {
            RecordsCustomerBaseInfoModel CustomerBaseInfos = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.Model.IDCardNo);//获取最新一笔体检数据
            if (CustomerBaseInfos == null) CustomerBaseInfos = new RecordsCustomerBaseInfoModel();
            RecordsGeneralConditionModel GerneralConditions = new RecordsGeneralConditionBLL().GetModelByOutKey(CustomerBaseInfos.ID);
            if (GerneralConditions == null) GerneralConditions = new RecordsGeneralConditionModel();
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = " IsSetValue='是' or IsSetValue='预设上次体检' ";
            DataTable dt = dv.ToTable();
            foreach (DataRow item in dt.Rows)
            {
                switch (item["ChinName"].ToString())
                {
                    case "症状":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.CustomerBaseInfo.Symptom = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.CustomerBaseInfo.Symptom = CustomerBaseInfos.Symptom;
                            this.CustomerBaseInfo.Other = CustomerBaseInfos.Other;
                        }
                        break;
                    case "体温":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.AnimalHeat = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.AnimalHeat = GerneralConditions.AnimalHeat;
                        }
                        break;
                    case "呼吸频率":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.BreathRate = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.BreathRate = GerneralConditions.BreathRate;
                        }
                        break;
                    case "腰围":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.Waistline = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.Waistline = GerneralConditions.Waistline;
                        }
                        break;
                    case "身高":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.Height = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.Height = GerneralConditions.Height;
                        }
                        break;
                    case "脉率":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.PulseRate = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.PulseRate = GerneralConditions.PulseRate;
                        }
                        break;
                    case "体重":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.Weight = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.Weight = GerneralConditions.Weight;
                        }
                        break;
                    case "体质指数":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.BMI = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.BMI = GerneralConditions.BMI;
                        }
                        break;
                    case "左侧低血压":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.LeftPre = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.LeftPre = GerneralConditions.LeftPre;
                        }
                        break;
                    case "右侧低血压":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.RightPre = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.RightPre = GerneralConditions.RightPre;
                        }
                        break;
                    case "左侧高血压":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.LeftHeight = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.LeftHeight = GerneralConditions.LeftHeight;
                        }
                        break;
                    case "右侧高血压":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                            {
                                if (GetDecimal(item["ItemValue"].ToString()))
                                {
                                    this.GerneralCondition.RightHeight = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            this.GerneralCondition.RightHeight = GerneralConditions.RightHeight;
                        }
                        break;
                    case "左侧原因":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.GerneralCondition.LeftReason = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.GerneralCondition.LeftReason = GerneralConditions.LeftReason;
                        }
                        break;
                    case "右侧原因":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.GerneralCondition.RightReason = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.GerneralCondition.RightReason = GerneralConditions.RightReason;
                        }
                        break;
                    case "老年人健康状态自我评估":
                        if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                        {
                            if (item["IsSetValue"].ToString() == "是")
                            {
                                this.GerneralCondition.OldHealthStaus = item["ItemValue"].ToString();
                            }
                            else
                            {
                                this.GerneralCondition.OldHealthStaus = GerneralConditions.OldHealthStaus;
                            }
                        }
                        break;
                    case "老年人生活自理能力自我评估":
                        if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                        {
                            if (item["IsSetValue"].ToString() == "是")
                            {
                                this.GerneralCondition.OldSelfCareability = item["ItemValue"].ToString();
                            }
                            else
                            {
                                this.GerneralCondition.OldSelfCareability = GerneralConditions.OldSelfCareability;
                            }
                        }
                        break;
                    case "老年人认知功能":
                        if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                        {
                            if (item["IsSetValue"].ToString() == "是")
                            {
                                this.GerneralCondition.OldRecognise = item["ItemValue"].ToString();
                            }
                            else
                            {
                                this.GerneralCondition.OldRecognise = GerneralConditions.OldRecognise;
                            }
                        }
                        break;
                    case "老年人情感状态":
                        if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                        {
                            if (item["IsSetValue"].ToString() == "是")
                            {
                                this.GerneralCondition.OldEmotion = item["ItemValue"].ToString();
                            }
                            else
                            {
                                this.GerneralCondition.OldEmotion = GerneralConditions.OldEmotion;
                            }
                        }
                        break;
                    case "简易智力状态检查总分":
                        if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                        {
                            if (item["IsSetValue"].ToString() == "是")
                            {
                                if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                                {
                                    if (GetDecimal(item["ItemValue"].ToString()))
                                    {
                                        this.GerneralCondition.InterScore = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                    }
                                }
                            }
                            else
                            {
                                this.GerneralCondition.InterScore = GerneralConditions.InterScore;
                            }
                        }
                        break;
                    case "老年人抑郁评分检查总分":
                        if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                        {
                            if (item["IsSetValue"].ToString() == "是")
                            {
                                if (!string.IsNullOrEmpty(item["ItemValue"].ToString()))
                                {
                                    if (GetDecimal(item["ItemValue"].ToString()))
                                    {
                                        this.GerneralCondition.GloomyScore = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                                    }
                                }
                            }
                            else
                            {
                                this.GerneralCondition.GloomyScore = GerneralConditions.GloomyScore;
                            }
                        }
                        break;
                    case "老年人是否规范管理":
                        if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                        {
                            if (item["IsSetValue"].ToString() == "是")
                            {
                                this.GerneralCondition.OldMange = item["ItemValue"].ToString();
                            }
                            else
                            {
                                this.GerneralCondition.OldMange = GerneralConditions.OldMange;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 验证是否是deciaml
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public bool GetDecimal(string pValue)
        {
            decimal d;
            if (decimal.TryParse(pValue, out d))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MustChoose()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = "IsRequired='1' ";
            DataTable dt = dv.ToTable();
            RecordsCustomerBaseInfoModel CustomerBaseInfos = new RecordsCustomerBaseInfoBLL().GetModelByID(CustomerBaseInfo.ID);
            RecordsGeneralConditionModel GerneralConditions = new RecordsGeneralConditionBLL().GetModelByOutKey(CustomerBaseInfo.ID);
            if (CustomerBaseInfos == null) CustomerBaseInfos = new RecordsCustomerBaseInfoModel();
            if (GerneralConditions == null) GerneralConditions = new RecordsGeneralConditionModel();
            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "症状":
                            if (CustomerBaseInfos == null)
                            {
                                this.groupBox1.Text = "*症状";
                                this.groupBox1.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(CustomerBaseInfos.Symptom))
                                {
                                    this.groupBox1.Text = "*症状";
                                    this.groupBox1.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.groupBox1.Text = "症状";
                                    this.groupBox1.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "体温":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.AnimalHeat)))
                            {
                                this.label19.Text = "*体温:";
                                this.label19.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label19.Text = "体温:";
                                this.label19.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "呼吸频率":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.BreathRate)))
                            {
                                this.label20.Text = "*呼吸频率:";
                                this.label20.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label20.Text = "呼吸频率:";
                                this.label20.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "腰围":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.Waistline)))
                            {
                                this.label22.Text = "*腰围:";
                                this.label22.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label22.Text = "腰围:";
                                this.label22.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "身高":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.Height)))
                            {
                                this.label21.Text = "*身高:";
                                this.label21.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label21.Text = "身高:";
                                this.label21.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "脉率":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.PulseRate)))
                            {
                                this.label11.Text = "*脉率:";
                                this.label11.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label11.Text = "脉率:";
                                this.label11.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体重":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.Weight)))
                            {
                                this.label13.Text = "*体重:";
                                this.label13.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label13.Text = "体重:";
                                this.label13.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "体质指数":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.BMI)))
                            {
                                this.label25.Text = "*体质指数(BMI):";
                                this.label25.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label25.Text = "体质指数(BMI):";
                                this.label25.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "左侧低血压":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.LeftPre)) || string.IsNullOrEmpty(Convert.ToString(GerneralConditions.LeftHeight)))
                            {
                                this.label10.Text = "*左侧血压:";
                                this.label10.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label10.Text = "左侧血压:";
                                this.label10.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "右侧低血压":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.RightPre)) || string.IsNullOrEmpty(Convert.ToString(GerneralConditions.RightHeight)))
                            {
                                this.label2.Text = "*右侧血压:";
                                this.label2.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label2.Text = "右侧血压:";
                                this.label2.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "左侧高血压":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.LeftPre)) || string.IsNullOrEmpty(Convert.ToString(GerneralConditions.LeftHeight)))
                            {
                                this.label10.Text = "*左侧血压:";
                                this.label10.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label10.Text = "左侧血压:";
                                this.label10.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "右侧高血压":
                            if (string.IsNullOrEmpty(Convert.ToString(GerneralConditions.RightPre)) || string.IsNullOrEmpty(Convert.ToString(GerneralConditions.RightHeight)))
                            {
                                this.label2.Text = "*右侧血压:";
                                this.label2.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label2.Text = "右侧血压:";
                                this.label2.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "左侧原因":
                            if (string.IsNullOrEmpty(GerneralConditions.LeftReason))
                            {
                                this.label9.Text = "*左侧原因:";
                                this.label9.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label9.Text = "左侧原因:";
                                this.label9.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "右侧原因":
                            if (string.IsNullOrEmpty(GerneralConditions.RightReason))
                            {
                                this.label12.Text = "*右侧原因:";
                                this.label12.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label12.Text = "右侧原因:";
                                this.label12.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "老年人健康状态自我评估":
                            if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                            {
                                if (string.IsNullOrEmpty(GerneralConditions.OldHealthStaus))
                                {
                                    this.groupBox12.Text = "*老年人健康状态自我评估:";
                                    this.groupBox12.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.groupBox12.Text = "老年人健康状态自我评估:";
                                    this.groupBox12.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "老年人生活自理能力自我评估":
                            if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                            {
                                if (string.IsNullOrEmpty(GerneralConditions.OldSelfCareability))
                                {
                                    this.groupBox14.Text = "*老年人生活自理能力自我评估:";
                                    this.groupBox14.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.groupBox14.Text = "老年人生活自理能力自我评估:";
                                    this.groupBox14.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "老年人认知功能":
                            if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                            {
                                if (string.IsNullOrEmpty(GerneralConditions.OldRecognise))
                                {
                                    this.groupBox13.Text = "*老年人认知功能:";
                                    this.groupBox13.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.groupBox13.Text = "老年人认知功能:";
                                    this.groupBox13.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "老年人情感状态":
                            if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                            {
                                if (string.IsNullOrEmpty(GerneralConditions.OldEmotion))
                                {
                                    this.groupBox15.Text = "*老年人情感状态:";
                                    this.groupBox15.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.groupBox15.Text = "老年人情感状态:";
                                    this.groupBox15.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "简易智力状态检查总分":
                            if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                            {
                                if (!GerneralConditions.InterScore.HasValue)
                                {
                                    this.label35.Text = "*简易智力状态检查,总分:";
                                    this.label35.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label35.Text = "简易智力状态检查,总分:";
                                    this.label35.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                            break;
                        case "老年人抑郁评分检查总分":
                            if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                            {
                                if (!GerneralConditions.GloomyScore.HasValue)
                                {
                                    this.label36.Text = "*老年人抑郁评分检查,总分:";
                                    this.label36.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label36.Text = "老年人抑郁评分检查,总分:";
                                    this.label36.ForeColor = System.Drawing.Color.Black;
                                }

                            }
                            break;
                        case "老年人是否规范管理":
                            if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                            {
                                if (string.IsNullOrEmpty(GerneralConditions.OldMange))
                                {
                                    this.label14.Text = "*老年人是否规范管理:";
                                    this.label14.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.label14.Text = "老年人是否规范管理:";
                                    this.label14.ForeColor = System.Drawing.Color.Black;
                                }

                            }
                            break;
                        default: break;
                    }
                }
            }
        }

        public void GetRecordsManageMentModelNull()
        {
            RecordsManageMentModel.BMI = null; //体质指数
            RecordsManageMentModel.LeftHeight = null; //血压
            RecordsManageMentModel.LeftPre = null;
            RecordsManageMentModel.RightHeight = null;
            RecordsManageMentModel.RightPre = null;
            RecordsManageMentModel.Waistline = null; //腰围
            RecordsManageMentModel.PulseRate = null; //脉率
            RecordsManageMentModel.HBSAG = null; //乙型肝炎表面抗原
            RecordsManageMentModel.ECG = null; //心电
            RecordsManageMentModel.ECGEx = null;
            RecordsManageMentModel.BCHAO = null; //B超
            RecordsManageMentModel.BCHAOEx = null;
            RecordsManageMentModel.PRO = null;  //尿蛋白
            RecordsManageMentModel.GLU = null;  //尿糖
            RecordsManageMentModel.KET = null;  //尿酮体
            RecordsManageMentModel.BLD = null;  //尿潜血
            RecordsManageMentModel.UrineOther = null;  //尿常规其他
            RecordsManageMentModel.HB = null; //血红蛋白
            RecordsManageMentModel.WBC = null;//白细胞
            RecordsManageMentModel.PLT = null;//血小板
            RecordsManageMentModel.SGPT = null; //血清谷丙转氨酶
            RecordsManageMentModel.GOT = null;//血清谷草转氨酶
            RecordsManageMentModel.BP = null;//白蛋白
            RecordsManageMentModel.TBIL = null;//总胆红素
            RecordsManageMentModel.CB = null;//结合胆红素 
            RecordsManageMentModel.GT = null;//谷氨酰转肽酶
            RecordsManageMentModel.SCR = null;//血清肌酐
            RecordsManageMentModel.BUN = null;//血尿素氮
            RecordsManageMentModel.PC = null;//血钾浓度
            RecordsManageMentModel.HYPE = null;//血钠浓度
            RecordsManageMentModel.TC = null;//总胆固醇
            RecordsManageMentModel.TG = null;//甘油三酯
            RecordsManageMentModel.LowCho = null;//血清低密度脂蛋白胆固醇
            RecordsManageMentModel.HeiCho = null;//血清高密度脂蛋白胆固醇
            RecordsManageMentModel.FPGL = null;//空腹血糖
            RecordsManageMentModel.DrinkRate = null;//饮酒
            RecordsManageMentModel.Height = null; //身高
            RecordsManageMentModel.SmokeCondition = null;//吸烟
            RecordsManageMentModel.ExerciseRate = null; // 锻炼频率
            RecordsManageMentModel.DietaryHabit = null; // 饮食习惯
            RecordsManageMentModel.BrainDis = null;           //脑血管疾病
            RecordsManageMentModel.RenalDis = null;          //肾脏疾病肾脏疾病
            RecordsManageMentModel.HeartDis = null;          //心血管疾病
            RecordsManageMentModel.EyeDis = null;   //眼部疾病
            RecordsManageMentModel.NerveDis = null;   //神经系统疾病
            RecordsManageMentModel.ElseDis = null;   //其他系统疾病
            RecordsManageMentModel.BrainOther = null;   //脑血管疾病其他
            RecordsManageMentModel.RenalOther = null;   //肾脏疾病其他
            RecordsManageMentModel.HeartOther = null;   //心脏疾病其他
            RecordsManageMentModel.VesselOther = null;   //血管其他疾病
            RecordsManageMentModel.EyeOther = null;   //眼部其他疾病
            RecordsManageMentModel.NerveOther = null;   //神经系统疾病其它
            RecordsManageMentModel.ElseOther = null;   //其他系统疾病其它
            RecordsManageMentModel.Weight = null;//体重
            RecordsManageMentModel.HearRate = null;//心率
            RecordsManageMentModel.OldSelfCareability = null;//老年人自理能力评估
            RecordsManageMentModel.Symptom = null;// 症状
            RecordsManageMentModel.SymptomOther = null;
            RecordsManageMentModel.ExerciseTimes = null;//锻炼时间
            RecordsManageMentModel.Other = null;
            RecordsManageMentModel.ECGExx = null;//山东需求判断B超异常带有 不齐字段时，查体信息心律改为不齐
            RecordsManageMentModel.BarrelChest = null;//桶状胸
            RecordsManageMentModel.BreathSounds = null;//呼吸音
            RecordsManageMentModel.Rale = null;//罗音
            RecordsManageMentModel.HeartRhythm = null;//心律
            RecordsManageMentModel.Noise = null;//杂音
            RecordsManageMentModel.PressPain = null;//压痛
            RecordsManageMentModel.EnclosedMass = null;//包块
            RecordsManageMentModel.Liver = null;//肝大
            RecordsManageMentModel.Spleen = null;//脾大
            RecordsManageMentModel.Voiced = null;//移动性浊音
            RecordsManageMentModel.FootBack = null;//足背动脉搏动
            RecordsManageMentModel.Edema = null;// 下肢水肿
            RecordsManageMentModel.LeftView = null;//左眼视力
            RecordsManageMentModel.RightView = null;//右眼视力
            RecordsManageMentModel.HeartRate = null;
            RecordsManageMentModel.NoiseEx = null;
            RecordsManageMentModel.Listen = null;
            RecordsManageMentModel.SportFunction = null;
        }

        private void InitializeComponent()
        {
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.txtyuzf = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.radqgcsyanx = new System.Windows.Forms.RadioButton();
            this.radqgcsyx = new System.Windows.Forms.RadioButton();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.lkbOld = new System.Windows.Forms.LinkLabel();
            this.cmbzilinengli = new System.Windows.Forms.ComboBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtzlzf = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.radrzcsyanx = new System.Windows.Forms.RadioButton();
            this.radrzcsyx = new System.Windows.Forms.RadioButton();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.cmbziwopingu = new System.Windows.Forms.ComboBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tbLeftL = new System.Windows.Forms.TextBox();
            this.btnHW = new System.Windows.Forms.Button();
            this.tbLeftReason = new System.Windows.Forms.TextBox();
            this.tbRightReason = new System.Windows.Forms.TextBox();
            this.btnhxpl = new System.Windows.Forms.Button();
            this.btnYaowei = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRightL = new System.Windows.Forms.TextBox();
            this.tbRightH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLeftH = new System.Windows.Forms.TextBox();
            this.tbMailv = new System.Windows.Forms.TextBox();
            this.btnCount = new System.Windows.Forms.Button();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.btnHeight = new System.Windows.Forms.Button();
            this.btnMaiLv = new System.Windows.Forms.Button();
            this.btnBreathe = new System.Windows.Forms.Button();
            this.btnTemp = new System.Windows.Forms.Button();
            this.btnRightBP = new System.Windows.Forms.Button();
            this.btnLeftBP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectBW = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txttzzs = new System.Windows.Forms.TextBox();
            this.txthxpl = new System.Windows.Forms.TextBox();
            this.txtyaowei = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.txttiwen = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtzhengzhuangqita = new System.Windows.Forms.TextBox();
            this.chBbz = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpCheckDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbOldMange = new System.Windows.Forms.ComboBox();
            this.btnPhoto = new System.Windows.Forms.Button();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.txtyuzf);
            this.groupBox15.Controls.Add(this.label36);
            this.groupBox15.Controls.Add(this.radqgcsyanx);
            this.groupBox15.Controls.Add(this.radqgcsyx);
            this.groupBox15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox15.Location = new System.Drawing.Point(75, 593);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(885, 68);
            this.groupBox15.TabIndex = 7;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "老年人情感状态*";
            // 
            // txtyuzf
            // 
            this.txtyuzf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtyuzf.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyuzf.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtyuzf.Location = new System.Drawing.Point(648, 23);
            this.txtyuzf.MaxLength = 3;
            this.txtyuzf.Name = "txtyuzf";
            this.txtyuzf.ReadOnly = true;
            this.txtyuzf.Size = new System.Drawing.Size(116, 30);
            this.txtyuzf.TabIndex = 8;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(381, 29);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(259, 20);
            this.label36.TabIndex = 7;
            this.label36.Text = "老年人抑郁评分检查,总分：";
            // 
            // radqgcsyanx
            // 
            this.radqgcsyanx.AutoSize = true;
            this.radqgcsyanx.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqgcsyanx.Location = new System.Drawing.Point(185, 29);
            this.radqgcsyanx.Name = "radqgcsyanx";
            this.radqgcsyanx.Size = new System.Drawing.Size(107, 24);
            this.radqgcsyanx.TabIndex = 5;
            this.radqgcsyanx.Text = "粗筛阳性";
            this.radqgcsyanx.UseVisualStyleBackColor = true;
            // 
            // radqgcsyx
            // 
            this.radqgcsyx.AutoSize = true;
            this.radqgcsyx.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radqgcsyx.Location = new System.Drawing.Point(12, 29);
            this.radqgcsyx.Name = "radqgcsyx";
            this.radqgcsyx.Size = new System.Drawing.Size(107, 24);
            this.radqgcsyx.TabIndex = 4;
            this.radqgcsyx.Text = "粗筛阴性";
            this.radqgcsyx.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.lkbOld);
            this.groupBox14.Controls.Add(this.cmbzilinengli);
            this.groupBox14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox14.Location = new System.Drawing.Point(569, 454);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(391, 113);
            this.groupBox14.TabIndex = 5;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "老年人自理能力评估*";
            // 
            // lkbOld
            // 
            this.lkbOld.AutoSize = true;
            this.lkbOld.Location = new System.Drawing.Point(21, 77);
            this.lkbOld.Name = "lkbOld";
            this.lkbOld.Size = new System.Drawing.Size(249, 20);
            this.lkbOld.TabIndex = 5;
            this.lkbOld.TabStop = true;
            this.lkbOld.Text = "老年人生活自理能力评估表";
            this.lkbOld.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbOld_LinkClicked);
            // 
            // cmbzilinengli
            // 
            this.cmbzilinengli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbzilinengli.Enabled = false;
            this.cmbzilinengli.FormattingEnabled = true;
            this.cmbzilinengli.Location = new System.Drawing.Point(25, 35);
            this.cmbzilinengli.Name = "cmbzilinengli";
            this.cmbzilinengli.Size = new System.Drawing.Size(245, 28);
            this.cmbzilinengli.TabIndex = 4;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.txtzlzf);
            this.groupBox13.Controls.Add(this.label35);
            this.groupBox13.Controls.Add(this.radrzcsyanx);
            this.groupBox13.Controls.Add(this.radrzcsyx);
            this.groupBox13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox13.Location = new System.Drawing.Point(1000, 454);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(411, 113);
            this.groupBox13.TabIndex = 6;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "老年人认知功能*";
            // 
            // txtzlzf
            // 
            this.txtzlzf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtzlzf.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzlzf.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtzlzf.Location = new System.Drawing.Point(242, 70);
            this.txtzlzf.MaxLength = 3;
            this.txtzlzf.Name = "txtzlzf";
            this.txtzlzf.ReadOnly = true;
            this.txtzlzf.Size = new System.Drawing.Size(116, 30);
            this.txtzlzf.TabIndex = 3;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(7, 80);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(229, 20);
            this.label35.TabIndex = 2;
            this.label35.Text = "简易智力状态检查,总分:";
            // 
            // radrzcsyanx
            // 
            this.radrzcsyanx.AutoSize = true;
            this.radrzcsyanx.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radrzcsyanx.Location = new System.Drawing.Point(201, 34);
            this.radrzcsyanx.Name = "radrzcsyanx";
            this.radrzcsyanx.Size = new System.Drawing.Size(107, 24);
            this.radrzcsyanx.TabIndex = 1;
            this.radrzcsyanx.Text = "粗筛阳性";
            this.radrzcsyanx.UseVisualStyleBackColor = true;
            // 
            // radrzcsyx
            // 
            this.radrzcsyx.AutoSize = true;
            this.radrzcsyx.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radrzcsyx.Location = new System.Drawing.Point(38, 34);
            this.radrzcsyx.Name = "radrzcsyx";
            this.radrzcsyx.Size = new System.Drawing.Size(107, 24);
            this.radrzcsyx.TabIndex = 0;
            this.radrzcsyx.Text = "粗筛阴性";
            this.radrzcsyx.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.cmbziwopingu);
            this.groupBox12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox12.Location = new System.Drawing.Point(75, 453);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(434, 113);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "老年人健康自我评估*";
            // 
            // cmbziwopingu
            // 
            this.cmbziwopingu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbziwopingu.FormattingEnabled = true;
            this.cmbziwopingu.Location = new System.Drawing.Point(19, 30);
            this.cmbziwopingu.Name = "cmbziwopingu";
            this.cmbziwopingu.Size = new System.Drawing.Size(367, 28);
            this.cmbziwopingu.TabIndex = 1;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tbLeftL);
            this.groupBox11.Controls.Add(this.btnHW);
            this.groupBox11.Controls.Add(this.tbLeftReason);
            this.groupBox11.Controls.Add(this.tbRightReason);
            this.groupBox11.Controls.Add(this.btnhxpl);
            this.groupBox11.Controls.Add(this.btnYaowei);
            this.groupBox11.Controls.Add(this.label7);
            this.groupBox11.Controls.Add(this.tbRightL);
            this.groupBox11.Controls.Add(this.tbRightH);
            this.groupBox11.Controls.Add(this.label6);
            this.groupBox11.Controls.Add(this.tbLeftH);
            this.groupBox11.Controls.Add(this.tbMailv);
            this.groupBox11.Controls.Add(this.btnCount);
            this.groupBox11.Controls.Add(this.tbWeight);
            this.groupBox11.Controls.Add(this.btnHeight);
            this.groupBox11.Controls.Add(this.btnMaiLv);
            this.groupBox11.Controls.Add(this.btnBreathe);
            this.groupBox11.Controls.Add(this.btnTemp);
            this.groupBox11.Controls.Add(this.btnRightBP);
            this.groupBox11.Controls.Add(this.btnLeftBP);
            this.groupBox11.Controls.Add(this.label1);
            this.groupBox11.Controls.Add(this.label2);
            this.groupBox11.Controls.Add(this.btnSelectBW);
            this.groupBox11.Controls.Add(this.label16);
            this.groupBox11.Controls.Add(this.label11);
            this.groupBox11.Controls.Add(this.label17);
            this.groupBox11.Controls.Add(this.label15);
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Controls.Add(this.label12);
            this.groupBox11.Controls.Add(this.label9);
            this.groupBox11.Controls.Add(this.label10);
            this.groupBox11.Controls.Add(this.label8);
            this.groupBox11.Controls.Add(this.txttzzs);
            this.groupBox11.Controls.Add(this.txthxpl);
            this.groupBox11.Controls.Add(this.txtyaowei);
            this.groupBox11.Controls.Add(this.tbHeight);
            this.groupBox11.Controls.Add(this.txttiwen);
            this.groupBox11.Controls.Add(this.label33);
            this.groupBox11.Controls.Add(this.label31);
            this.groupBox11.Controls.Add(this.label30);
            this.groupBox11.Controls.Add(this.label28);
            this.groupBox11.Controls.Add(this.label27);
            this.groupBox11.Controls.Add(this.label26);
            this.groupBox11.Controls.Add(this.label25);
            this.groupBox11.Controls.Add(this.label22);
            this.groupBox11.Controls.Add(this.label21);
            this.groupBox11.Controls.Add(this.label20);
            this.groupBox11.Controls.Add(this.label19);
            this.groupBox11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox11.Location = new System.Drawing.Point(75, 220);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(1336, 227);
            this.groupBox11.TabIndex = 3;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "基本信息";
            // 
            // tbLeftL
            // 
            this.tbLeftL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbLeftL.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLeftL.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbLeftL.Location = new System.Drawing.Point(577, 123);
            this.tbLeftL.MaxLength = 5;
            this.tbLeftL.Name = "tbLeftL";
            this.tbLeftL.Size = new System.Drawing.Size(34, 30);
            this.tbLeftL.TabIndex = 15;
            this.tbLeftL.Tag = "6";
            // 
            // btnHW
            // 
            this.btnHW.BackColor = System.Drawing.Color.LimeGreen;
            this.btnHW.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHW.ForeColor = System.Drawing.Color.Black;
            this.btnHW.Location = new System.Drawing.Point(292, 55);
            this.btnHW.Name = "btnHW";
            this.btnHW.Size = new System.Drawing.Size(77, 59);
            this.btnHW.TabIndex = 60;
            this.btnHW.Text = "身高检测";
            this.btnHW.UseVisualStyleBackColor = false;
            this.btnHW.Click += new System.EventHandler(this.btnHW_Click);
            // 
            // tbLeftReason
            // 
            this.tbLeftReason.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbLeftReason.Location = new System.Drawing.Point(963, 122);
            this.tbLeftReason.Name = "tbLeftReason";
            this.tbLeftReason.Size = new System.Drawing.Size(229, 30);
            this.tbLeftReason.TabIndex = 17;
            // 
            // tbRightReason
            // 
            this.tbRightReason.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbRightReason.Location = new System.Drawing.Point(517, 166);
            this.tbRightReason.Name = "tbRightReason";
            this.tbRightReason.Size = new System.Drawing.Size(218, 30);
            this.tbRightReason.TabIndex = 21;
            // 
            // btnhxpl
            // 
            this.btnhxpl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnhxpl.Location = new System.Drawing.Point(741, 26);
            this.btnhxpl.Name = "btnhxpl";
            this.btnhxpl.Size = new System.Drawing.Size(60, 27);
            this.btnhxpl.TabIndex = 1;
            this.btnhxpl.Text = "计算";
            this.btnhxpl.UseVisualStyleBackColor = true;
            this.btnhxpl.Click += new System.EventHandler(this.btnhxpl_Click);
            // 
            // btnYaowei
            // 
            this.btnYaowei.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYaowei.Location = new System.Drawing.Point(306, 26);
            this.btnYaowei.Name = "btnYaowei";
            this.btnYaowei.Size = new System.Drawing.Size(62, 27);
            this.btnYaowei.TabIndex = 1;
            this.btnYaowei.Text = "计算";
            this.btnYaowei.UseVisualStyleBackColor = true;
            this.btnYaowei.Click += new System.EventHandler(this.btnYaowei_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 20);
            this.label7.TabIndex = 58;
            this.label7.Text = "/";
            // 
            // tbRightL
            // 
            this.tbRightL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbRightL.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRightL.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbRightL.Location = new System.Drawing.Point(185, 166);
            this.tbRightL.MaxLength = 5;
            this.tbRightL.Name = "tbRightL";
            this.tbRightL.Size = new System.Drawing.Size(34, 30);
            this.tbRightL.TabIndex = 19;
            this.tbRightL.Tag = "6";
            // 
            // tbRightH
            // 
            this.tbRightH.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbRightH.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRightH.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbRightH.Location = new System.Drawing.Point(120, 166);
            this.tbRightH.MaxLength = 5;
            this.tbRightH.Name = "tbRightH";
            this.tbRightH.Size = new System.Drawing.Size(34, 30);
            this.tbRightH.TabIndex = 18;
            this.tbRightH.Tag = "6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(555, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "/";
            // 
            // tbLeftH
            // 
            this.tbLeftH.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbLeftH.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLeftH.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbLeftH.Location = new System.Drawing.Point(517, 123);
            this.tbLeftH.MaxLength = 5;
            this.tbLeftH.Name = "tbLeftH";
            this.tbLeftH.Size = new System.Drawing.Size(34, 30);
            this.tbLeftH.TabIndex = 14;
            this.tbLeftH.Tag = "6";
            // 
            // tbMailv
            // 
            this.tbMailv.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMailv.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMailv.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbMailv.Location = new System.Drawing.Point(120, 123);
            this.tbMailv.MaxLength = 3;
            this.tbMailv.Name = "tbMailv";
            this.tbMailv.Size = new System.Drawing.Size(88, 30);
            this.tbMailv.TabIndex = 12;
            this.tbMailv.Tag = "5";
            // 
            // btnCount
            // 
            this.btnCount.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCount.Location = new System.Drawing.Point(1126, 66);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(66, 27);
            this.btnCount.TabIndex = 11;
            this.btnCount.Text = "计算";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // tbWeight
            // 
            this.tbWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbWeight.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWeight.Location = new System.Drawing.Point(517, 76);
            this.tbWeight.MaxLength = 6;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(88, 30);
            this.tbWeight.TabIndex = 8;
            this.tbWeight.Tag = "3";
            // 
            // btnHeight
            // 
            this.btnHeight.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHeight.Location = new System.Drawing.Point(246, 73);
            this.btnHeight.Name = "btnHeight";
            this.btnHeight.Size = new System.Drawing.Size(40, 27);
            this.btnHeight.TabIndex = 7;
            this.btnHeight.Text = "...";
            this.btnHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHeight.UseVisualStyleBackColor = true;
            this.btnHeight.Click += new System.EventHandler(this.btnHeight_Click);
            // 
            // btnMaiLv
            // 
            this.btnMaiLv.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMaiLv.Location = new System.Drawing.Point(321, 119);
            this.btnMaiLv.Name = "btnMaiLv";
            this.btnMaiLv.Size = new System.Drawing.Size(47, 31);
            this.btnMaiLv.TabIndex = 13;
            this.btnMaiLv.Text = "...";
            this.btnMaiLv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaiLv.UseVisualStyleBackColor = true;
            this.btnMaiLv.Click += new System.EventHandler(this.btnMaiLv_Click);
            // 
            // btnBreathe
            // 
            this.btnBreathe.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBreathe.Location = new System.Drawing.Point(688, 25);
            this.btnBreathe.Name = "btnBreathe";
            this.btnBreathe.Size = new System.Drawing.Size(47, 31);
            this.btnBreathe.TabIndex = 3;
            this.btnBreathe.Text = "...";
            this.btnBreathe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBreathe.UseVisualStyleBackColor = true;
            this.btnBreathe.Click += new System.EventHandler(this.btnBreathe_Click);
            // 
            // btnTemp
            // 
            this.btnTemp.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTemp.Location = new System.Drawing.Point(1145, 23);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(47, 31);
            this.btnTemp.TabIndex = 5;
            this.btnTemp.Text = "...";
            this.btnTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTemp.UseVisualStyleBackColor = true;
            this.btnTemp.Click += new System.EventHandler(this.btnTemp_Click);
            // 
            // btnRightBP
            // 
            this.btnRightBP.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightBP.Location = new System.Drawing.Point(322, 164);
            this.btnRightBP.Name = "btnRightBP";
            this.btnRightBP.Size = new System.Drawing.Size(47, 31);
            this.btnRightBP.TabIndex = 20;
            this.btnRightBP.Text = "...";
            this.btnRightBP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRightBP.UseVisualStyleBackColor = true;
            this.btnRightBP.Click += new System.EventHandler(this.btnRightBP_Click);
            // 
            // btnLeftBP
            // 
            this.btnLeftBP.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftBP.Location = new System.Drawing.Point(688, 120);
            this.btnLeftBP.Name = "btnLeftBP";
            this.btnLeftBP.Size = new System.Drawing.Size(47, 31);
            this.btnLeftBP.TabIndex = 16;
            this.btnLeftBP.Text = "...";
            this.btnLeftBP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeftBP.UseVisualStyleBackColor = true;
            this.btnLeftBP.Click += new System.EventHandler(this.btnLeftBP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(232, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "mmHg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "右侧血压:";
            // 
            // btnSelectBW
            // 
            this.btnSelectBW.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectBW.Location = new System.Drawing.Point(688, 71);
            this.btnSelectBW.Name = "btnSelectBW";
            this.btnSelectBW.Size = new System.Drawing.Size(47, 31);
            this.btnSelectBW.TabIndex = 9;
            this.btnSelectBW.Text = "...";
            this.btnSelectBW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectBW.UseVisualStyleBackColor = true;
            this.btnSelectBW.Click += new System.EventHandler(this.btnSelectBW_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(216, 127);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 33;
            this.label16.Text = "次/分钟";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(57, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "脉率:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(611, 79);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 20);
            this.label17.TabIndex = 34;
            this.label17.Text = "Kg";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(615, 127);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 20);
            this.label15.TabIndex = 32;
            this.label15.Text = "mmHg";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(447, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "体重:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(407, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "右侧原因:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(849, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "左侧原因:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(407, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "左侧血压:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(1204, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 16);
            this.label8.TabIndex = 24;
            // 
            // txttzzs
            // 
            this.txttzzs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txttzzs.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttzzs.Location = new System.Drawing.Point(963, 72);
            this.txttzzs.MaxLength = 6;
            this.txttzzs.Name = "txttzzs";
            this.txttzzs.Size = new System.Drawing.Size(88, 30);
            this.txttzzs.TabIndex = 10;
            this.txttzzs.Tag = "4";
            // 
            // txthxpl
            // 
            this.txthxpl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txthxpl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthxpl.Location = new System.Drawing.Point(517, 26);
            this.txthxpl.MaxLength = 3;
            this.txthxpl.Name = "txthxpl";
            this.txthxpl.Size = new System.Drawing.Size(88, 30);
            this.txthxpl.TabIndex = 2;
            this.txthxpl.Tag = "0";
            // 
            // txtyaowei
            // 
            this.txtyaowei.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtyaowei.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyaowei.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtyaowei.Location = new System.Drawing.Point(120, 28);
            this.txtyaowei.MaxLength = 3;
            this.txtyaowei.Name = "txtyaowei";
            this.txtyaowei.Size = new System.Drawing.Size(88, 30);
            this.txtyaowei.TabIndex = 0;
            this.txtyaowei.TextChanged += new System.EventHandler(this.txtyaowei_TextChanged);
            // 
            // tbHeight
            // 
            this.tbHeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHeight.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHeight.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbHeight.Location = new System.Drawing.Point(120, 74);
            this.tbHeight.MaxLength = 6;
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(88, 30);
            this.tbHeight.TabIndex = 6;
            this.tbHeight.Tag = "2";
            // 
            // txttiwen
            // 
            this.txttiwen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txttiwen.Location = new System.Drawing.Point(963, 26);
            this.txttiwen.MaxLength = 5;
            this.txttiwen.Name = "txttiwen";
            this.txttiwen.Size = new System.Drawing.Size(88, 30);
            this.txttiwen.TabIndex = 4;
            this.txttiwen.Tag = "1";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F);
            this.label33.Location = new System.Drawing.Point(1063, 75);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(59, 20);
            this.label33.TabIndex = 16;
            this.label33.Text = "Kg/㎡";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 15F);
            this.label31.Location = new System.Drawing.Point(1273, 31);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(0, 20);
            this.label31.TabIndex = 14;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 15F);
            this.label30.Location = new System.Drawing.Point(606, 29);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 20);
            this.label30.TabIndex = 12;
            this.label30.Text = "次/分钟";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 15F);
            this.label28.Location = new System.Drawing.Point(209, 32);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 20);
            this.label28.TabIndex = 8;
            this.label28.Text = "cm";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 15F);
            this.label27.Location = new System.Drawing.Point(209, 77);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 20);
            this.label27.TabIndex = 6;
            this.label27.Text = "cm";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(1051, 31);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 20);
            this.label26.TabIndex = 4;
            this.label26.Text = "℃";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(799, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(149, 20);
            this.label25.TabIndex = 2;
            this.label25.Text = "体质指数(BMI):";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(57, 33);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 20);
            this.label22.TabIndex = 0;
            this.label22.Text = "腰围:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(57, 78);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 20);
            this.label21.TabIndex = 0;
            this.label21.Text = "身高:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(407, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "呼吸频率:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(889, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "体温:";
            // 
            // tbDoctor
            // 
            this.tbDoctor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDoctor.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDoctor.Location = new System.Drawing.Point(858, 15);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(232, 30);
            this.tbDoctor.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(752, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "责任医生:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtzhengzhuangqita);
            this.groupBox1.Controls.Add(this.chBbz);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(75, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1336, 146);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "症状";
            // 
            // txtzhengzhuangqita
            // 
            this.txtzhengzhuangqita.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtzhengzhuangqita.Location = new System.Drawing.Point(815, 29);
            this.txtzhengzhuangqita.MaxLength = 20;
            this.txtzhengzhuangqita.Name = "txtzhengzhuangqita";
            this.txtzhengzhuangqita.ReadOnly = true;
            this.txtzhengzhuangqita.Size = new System.Drawing.Size(291, 30);
            this.txtzhengzhuangqita.TabIndex = 1;
            // 
            // chBbz
            // 
            this.chBbz.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chBbz.CheckOnClick = true;
            this.chBbz.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chBbz.FormattingEnabled = true;
            this.chBbz.Items.AddRange(new object[] {
            "无症状",
            "头痛",
            "头晕",
            "心悸",
            "胸闷",
            "胸痛",
            "慢性咳嗽",
            "咳痰",
            "呼吸困难",
            "多饮",
            "多尿",
            "体重下降",
            "乏力",
            "关节肿痛",
            "视力模糊",
            "手脚麻木",
            "尿急",
            "尿痛",
            "便秘",
            "腹泻",
            "恶心呕吐",
            "眼花",
            "耳鸣",
            "乳房胀痛",
            "其他"});
            this.chBbz.Location = new System.Drawing.Point(7, 26);
            this.chBbz.MultiColumn = true;
            this.chBbz.Name = "chBbz";
            this.chBbz.Size = new System.Drawing.Size(1226, 104);
            this.chBbz.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpCheckDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbDoctor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(75, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1336, 51);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // dtpCheckDate
            // 
            this.dtpCheckDate.Location = new System.Drawing.Point(502, 15);
            this.dtpCheckDate.Name = "dtpCheckDate";
            this.dtpCheckDate.Size = new System.Drawing.Size(200, 30);
            this.dtpCheckDate.TabIndex = 1;
            this.dtpCheckDate.Value = new System.DateTime(2016, 4, 15, 8, 50, 37, 512);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(396, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "体检日期:";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.Location = new System.Drawing.Point(112, 16);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(232, 30);
            this.tbName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "姓    名:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(1070, 630);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(209, 20);
            this.label14.TabIndex = 8;
            this.label14.Text = "老年人是否规范管理：";
            // 
            // cbOldMange
            // 
            this.cbOldMange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOldMange.FormattingEnabled = true;
            this.cbOldMange.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbOldMange.Location = new System.Drawing.Point(1292, 622);
            this.cbOldMange.Name = "cbOldMange";
            this.cbOldMange.Size = new System.Drawing.Size(121, 28);
            this.cbOldMange.TabIndex = 9;
            // 
            // btnPhoto
            // 
            this.btnPhoto.Location = new System.Drawing.Point(1432, 12);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(74, 58);
            this.btnPhoto.TabIndex = 150;
            this.btnPhoto.Text = "拍照";
            this.btnPhoto.UseVisualStyleBackColor = true;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // NormalStateUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1460, 680);
            this.Controls.Add(this.btnPhoto);
            this.Controls.Add(this.cbOldMange);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "NormalStateUserControl";
            this.Load += new System.EventHandler(this.NormalStateUserControl_Load);
            this.VisibleChanged += new System.EventHandler(this.NormalStateUserControl_VisibleChanged);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lkbOld_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OldPeopleInfoForm info = new OldPeopleInfoForm(this.Model)
            {
                elderSelf = this.SelfcareabilityModel,
                PhysicalInfoFactoryID = this.flagfactoryID,
                ShowIcon = false,
                ShowInTaskbar = false,
                MaximizeBox = false,
                MinimizeBox = false,
                Text = "老年人生活自理能力评估表",
                FormBorderStyle = FormBorderStyle.Sizable,
                StartPosition = FormStartPosition.CenterScreen
            };
            if (info.ShowDialog() == DialogResult.OK)
            {
                if (info.account <= 3M)
                {
                    this.cmbzilinengli.SelectedIndex = 0;
                }
                else if ((info.account >= 4M) && (info.account <= 8M))
                {
                    this.cmbzilinengli.SelectedIndex = 1;
                }
                else if ((info.account >= 9M) && (info.account <= 18M))
                {
                    this.cmbzilinengli.SelectedIndex = 2;
                }
                else if (info.account >= 19M)
                {
                    this.cmbzilinengli.SelectedIndex = 3;
                }
                this.SelfcareabilityModel = info.elderSelf;

            }
        }

        public void NotisfyChildStatus()
        {
            throw new NotImplementedException();
        }

        public void Deletes()
        {
            RecordsCustomerBaseInfoBLL recordsCustomerBaseInfoBll = new RecordsCustomerBaseInfoBLL();
            RecordsGeneralConditionModel GerneralCondition = new RecordsGeneralConditionBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (GerneralCondition != null)
            {
                RecordsSelfcareabilityBLL RecordsSelfcareabilityBLL = new RecordsSelfcareabilityBLL();
                RecordsSelfcareabilityBLL.Delete(GerneralCondition.SelfID);
            }

            RecordsMediPhysDistModel MediPhys = new RecordsMediPhysDistBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (MediPhys != null)
            {
                RecordsMedicineCnBLL MedicineCnBLL = new RecordsMedicineCnBLL();
                RecordsMedicineResultBLL MedicineResultBLL = new RecordsMedicineResultBLL();
                MedicineCnBLL.Delete(MediPhys.MedicineID);
                MedicineResultBLL.Delete(MediPhys.MedicineResultID);
            }
            recordsCustomerBaseInfoBll.Delete(PhysicalInfoFactory.ID);
        }

        private void SaveCustomerBaseInfo()
        {
            if (this.CustomerBaseInfo != null)
            {
                RecordsCustomerBaseInfoBLL recordsCustomerBaseInfoBll = new RecordsCustomerBaseInfoBLL();
                RecordsCustomerBaseInfoModel recordModel = recordsCustomerBaseInfoBll.GetModelByWhere(string.Format("CheckDate='{0}' and IDCardNo='{1}'", this.dtpCheckDate.Value.Date, CustomerBaseInfo.IDCardNo));

                if (recordModel == null)
                {
                    if (flagdelet && PhysicalInfoFactory.ID > 0)//修改信息时，更改检查日期，新增数据时，需将原日期信息删除
                    {
                        Deletes();
                    }
                    PhysicalInfoFactory.ID = recordsCustomerBaseInfoBll.Add(this.CustomerBaseInfo);
                }
                else
                {
                    DialogResult result = DialogResult.OK;
                    if (flagdelet && PhysicalInfoFactory.ID == recordModel.ID)
                    {

                        result = DialogResult.OK;
                    }
                    else
                    {
                        result = MessageBox.Show("此日期下已有体检信息，是否进行修改？", "提示", MessageBoxButtons.OKCancel);
                    }

                    if (result == DialogResult.OK)
                    {
                        if (flagdelet && PhysicalInfoFactory.ID != recordModel.ID)//修改信息时，更改检查日期，更新修改后日期数据时，需将原日期信息删除
                        {
                            Deletes();
                        }
                        PhysicalInfoFactory.ID = recordModel.ID;
                        this.CustomerBaseInfo.ID = recordModel.ID;
                        this.CustomerBaseInfo.CheckDate = new DateTime?(this.dtpCheckDate.Value.Date);
                        this.CustomerBaseInfo.CreateDate = new DateTime?(this.dtpCheckDate.Value.Date);
                        recordsCustomerBaseInfoBll.Update(this.CustomerBaseInfo);
                    }
                    else
                    {
                        PhysicalInfoFactory.ID = -1;
                    }
                }
            }
        }

        private void SaveGerneralCondition()
        {
            if (this.GerneralCondition != null)
            {
                if (PhysicalInfoFactory.ID == -1)
                    return;
                RecordsGeneralConditionModel GerneralModel = new RecordsGeneralConditionBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
                RecordsGeneralConditionBLL recordsGeneralConditionBll = new RecordsGeneralConditionBLL();
                this.GerneralCondition.OutKey = PhysicalInfoFactory.ID;
                RecordsSelfcareabilityBLL RecordsSelfcareabilityBLL = new RecordsSelfcareabilityBLL();
                this.GerneralCondition.SelfID = 0;
                if (GerneralModel == null)
                {
                    if (this.SelfcareabilityModel != null)
                    {
                        this.GerneralCondition.SelfID = RecordsSelfcareabilityBLL.Add(this.SelfcareabilityModel);
                    }
                    recordsGeneralConditionBll.Add(this.GerneralCondition);
                }
                else
                {
                    if (this.SelfcareabilityModel != null)
                    {
                        if (GerneralModel.SelfID == 0)//一般状况中，无老年人自理评估表信息
                        {
                            this.GerneralCondition.SelfID = RecordsSelfcareabilityBLL.Add(this.SelfcareabilityModel);
                        }
                        else //一般状况中，有老年人自理评估表信息
                        {
                            this.SelfcareabilityModel.ID = GerneralModel.SelfID;
                            this.GerneralCondition.SelfID = GerneralModel.SelfID;
                            RecordsSelfcareabilityBLL.Update(this.SelfcareabilityModel);
                        }
                    }

                    recordsGeneralConditionBll.Update(this.GerneralCondition);
                }
            }
        }

        public bool SaveModelToDB()
        {
            this.SaveCustomerBaseInfo();
            this.SaveGerneralCondition();
            return true;
        }

        private void SavePhysicExam()
        {
            if (this.PhysicalExam != null)
            {
                RecordsPhysicalExamBLL recordsPhysicalExamBll = new RecordsPhysicalExamBLL();
                if (!recordsPhysicalExamBll.Exists(this.PhysicalExam.ID))
                {
                    recordsPhysicalExamBll.Add(this.PhysicalExam);
                }
                else
                {
                    recordsPhysicalExamBll.Update(this.PhysicalExam);
                }
            }
        }

        public void SimpleBinding(ComboBox cb, object src, string member)
        {
            Binding binding = new Binding("SelectedValue", src, member, false, DataSourceUpdateMode.OnValidation)
            {
                DataSourceNullValue = string.Empty
            };
            cb.DataBindings.Add(binding);
        }

        private void SimpleBindingC(TextBox tb, string srcMember, bool isFormate)
        {
            Binding binding = new Binding("Text", this.CustomerBaseInfo, srcMember, isFormate, DataSourceUpdateMode.OnPropertyChanged);
            tb.DataBindings.Add(binding);
            if (isFormate)
            {
                binding.Parse += new ConvertEventHandler(this.bd_Parse);
            }
            if (srcMember == "Doctor")
            {
                binding.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
        }

        private void SimpleBindingG(TextBox tb, string srcMember, bool isFormate)
        {
            Binding binding = new Binding("Text", this.GerneralCondition, srcMember, isFormate, DataSourceUpdateMode.OnPropertyChanged);
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

        private void NormalStateUserControl_Load(object sender, EventArgs e)
        {
            this.btnPhoto.Visible = false;

            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }

            if (this.GerneralCondition.LeftHeight.HasValue)
            {
                this.tbLeftH.Text = this.GerneralCondition.LeftHeight.Value.ToString();
                this.tbLeftL.Text = this.GerneralCondition.LeftPre.ToString();
            }

            if (this.GerneralCondition.RightHeight.HasValue)
            {
                this.tbRightH.Text = this.GerneralCondition.RightHeight.Value.ToString();
                this.tbRightL.Text = this.GerneralCondition.RightPre.ToString();
            }

            if (this.GerneralCondition.BreathRate.HasValue)
            {
                this.txthxpl.Text = this.GerneralCondition.BreathRate.Value.ToString();
            }
            if (this.GerneralCondition.PulseRate.HasValue)
            {
                this.tbMailv.Text = this.GerneralCondition.PulseRate.Value.ToString();
            }
            if (this.GerneralCondition.Weight.HasValue)
            {
                this.tbWeight.Text = this.GerneralCondition.Weight.ToString();
            }
            if (this.GerneralCondition.AnimalHeat.HasValue)
            {
                this.txttiwen.Text = this.GerneralCondition.AnimalHeat.Value.ToString();
            }
            if (this.GerneralCondition.Height.HasValue)
            {
                this.tbHeight.Text = this.GerneralCondition.Height.Value.ToString();
            }
            if ((DateTime.Now.Year - this.Model.Birthday.Value.Year) < 0x41)
            {
                this.cmbzilinengli.SelectedIndex = -1;
                this.cmbzilinengli.Enabled = false;
                this.cmbziwopingu.SelectedIndex = -1;
                this.cmbziwopingu.Enabled = false;
                this.GerneralCondition.OldHealthStaus = null;
                this.lkbOld.Enabled = false;
                this.radrzcsyx.Checked = false;
                this.radqgcsyx.Checked = false;
                this.radrzcsyx.Enabled = false;
                this.radrzcsyanx.Enabled = false;
                this.radqgcsyx.Enabled = false;
                this.radqgcsyanx.Enabled = false;
                this.txtzlzf.ReadOnly = true;
                this.txtyuzf.ReadOnly = true;
            }

            if (tbLeftL.Text != "")
            {
                this.tbLeftL.Text = (Convert.ToInt32(decimal.Parse(tbLeftL.Text))).ToString();
            }

            if (tbRightL.Text != "")
            {
                this.tbRightL.Text = (Convert.ToInt32(decimal.Parse(tbRightL.Text))).ToString();
            }

            if (tbRightH.Text != "")
            {
                this.tbRightH.Text = (Convert.ToInt32(decimal.Parse(tbRightH.Text))).ToString();
            }

            if (tbLeftH.Text != "")
            {
                this.tbLeftH.Text = (Convert.ToInt32(decimal.Parse(tbLeftH.Text))).ToString();
            }
        }

        public void UpdataToModel()
        {
            this.CustomerBaseInfo.CheckDate = new DateTime?(this.dtpCheckDate.Value.Date);
            this.CustomerBaseInfo.IDCardNo = this.Model.IDCardNo;
            this.GerneralCondition.IDCardNo = this.Model.IDCardNo;
            this.CustomerBaseInfo.Symptom = this.zhengzhuang.FinalResult;
            this.CustomerBaseInfo.Other = this.zhengzhuang.FinalResultEX;
            this.GerneralCondition.OldRecognise = this.renzhi.Choose;
            this.GerneralCondition.OldEmotion = this.qinggan.Choose;
            if (this.cbOldMange.SelectedIndex != -1)
            {
                this.GerneralCondition.OldMange = Convert.ToString(this.cbOldMange.SelectedIndex + 1);
            }
            if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4") && this.SelfcareabilityModel == null)
            {
                this.SelfcareabilityModel = new RecordsSelfcareabilityModel()
                {
                    IDCardNo = this.Model.IDCardNo,
                    FollowUpDate = new DateTime?(this.dtpCheckDate.Value.Date),
                    FollowUpDoctor = tbDoctor.Text.ToString(),
                    Dine = 0,
                    Groming = 0,
                    Dressing = 0,
                    Tolet = 0,
                    Activity = 0,
                    TotalScore = 0
                };
                this.SelfcareabilityModel.NextVisitAim = "低盐饮食，预防高血压";
            }
            if (this.SelfcareabilityModel != null)
            {
                this.SelfcareabilityModel.NextFollowUpDate = new DateTime?(this.dtpCheckDate.Value.Date.AddYears(1));
            }
        }

        public override void UpdateDeviceinfoContent(int msg)
        {
            switch (msg)
            {
                case 0x597:
                    int m = GetRandom();
                    stru_result _result = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20", "血压");
                    if (_result.HasValue)
                    {
                        this.GerneralCondition.RightHeight = new decimal?((int.Parse(_result.value1)));
                        this.GerneralCondition.RightPre = new decimal?((int.Parse(_result.value2)));
                        this.GerneralCondition.LeftHeight = new decimal?(int.Parse(_result.value1) - m);
                        this.GerneralCondition.LeftPre = new decimal?(int.Parse(_result.value2) - m);
                        this.GerneralCondition.PulseRate = new decimal?(int.Parse(_result.value3));

                        if (Convert.ToInt32(_result.value3) / 4 >= 20)
                        {
                            this.GerneralCondition.BreathRate = 20;
                        }
                        else if (Convert.ToInt32(_result.value3) / 4 <= 16)
                        {
                            this.GerneralCondition.BreathRate = 16;
                        }
                        else
                        {
                            this.GerneralCondition.BreathRate = new decimal?(Convert.ToInt32(_result.value3) / 4);
                        }

                        this.tbLeftH.Text = Convert.ToString((int.Parse(_result.value1)) - m);
                        this.tbLeftL.Text = Convert.ToString((int.Parse(_result.value2)) - m);
                        this.tbRightH.Text = Convert.ToString((int.Parse(_result.value1)));
                        this.tbRightL.Text = Convert.ToString((int.Parse(_result.value2)));

                        if (Convert.ToInt32(_result.value3) / 4 >= 20) this.txthxpl.Text = "20";
                        else if (Convert.ToInt32(_result.value3) / 4 <= 16) this.txthxpl.Text = "16";
                        else
                        {
                            this.txthxpl.Text = Convert.ToString(Convert.ToInt32(_result.value3) / 4);
                        }
                        return;
                    }
                    return;
                case 0x598:
                    stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "39");
                    if (devData.HasValue)
                    {
                        this.tbHeight.Text = devData.value1;

                        //腰围计算
                        decimal num;
                        decimal num2;
                        if ((decimal.TryParse(this.tbHeight.Text, out num) && decimal.TryParse(this.tbWeight.Text, out num2)) && (num != 0M))
                        {
                            decimal num3 = num / 100M;
                            decimal num4 = num3 * num3;
                            this.txtyaowei.Text = (num2 * (decimal)3.3 / num4 + (decimal)5).ToString("0");
                        }
                        return;
                    }
                    return;
                case 0x599:
                case 0x59b:
                    break;

                case 0x59a:
                    stru_result _result3 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "32");
                    if (!_result3.HasValue) break;

                    if (_result3.value2 != "0")
                    {
                        this.tbMailv.Text = _result3.value2;
                        return;
                    }
                    return;
                case 0x59c:
                    {
                        stru_result _result4 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");
                        if (_result4.HasValue)
                        {
                            this.tbWeight.Text = _result4.value1;
                            return;
                        }
                        return;
                    }
                case 0x59d:
                    {
                        stru_result _result5 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "40");
                        if (_result5.HasValue)
                        {
                            this.txttiwen.Text = _result5.value1;
                            break;
                        }
                        return;
                    }
                default:
                    return;
            }
        }

        private int GetRandom()
        {
            int n = 0, m = 0;
            Random ran = new Random();
            n = ran.Next(1, 8);
            while (m < n)
            {
                m = ran.Next(1, 8);
            }

            return m;
        }

        public RecordsCustomerBaseInfoModel CustomerBaseInfo { get; set; }

        public bool EveryThingIsOk { get; set; }

        public RecordsGeneralConditionModel GerneralCondition { get; set; }

        public RecordsPhysicalExamModel PhysicalExam { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        private delegate void SetCmbAutoValue();

        private void txtyaowei_TextChanged(object sender, EventArgs e)
        {
            decimal m;
            if (decimal.TryParse(this.txtyaowei.Text, out m))
            {
                this.txtyaowei.Text = Convert.ToInt32(m).ToString();
            }
        }

        private void NormalStateUserControl_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                RecordsManageMentModel.BMI = this.GerneralCondition.BMI;
                RecordsManageMentModel.RightHeight = this.GerneralCondition.RightHeight;
                RecordsManageMentModel.RightPre = this.GerneralCondition.RightPre;
                RecordsManageMentModel.LeftHeight = this.GerneralCondition.LeftHeight;
                RecordsManageMentModel.LeftPre = this.GerneralCondition.LeftPre;
                RecordsManageMentModel.Waistline = this.GerneralCondition.Waistline;
                RecordsManageMentModel.Height = this.GerneralCondition.Height;
                RecordsManageMentModel.PulseRate = this.GerneralCondition.PulseRate;
                RecordsManageMentModel.Weight = this.GerneralCondition.Weight;
                RecordsManageMentModel.Symptom = this.zhengzhuang.FinalResult;
                RecordsManageMentModel.SymptomOther = this.zhengzhuang.FinalResultEX;
                RecordsManageMentModel.CheckDate = this.dtpCheckDate.Value;

                if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("4"))
                {
                    RecordsManageMentModel.OldSelfCareability = (this.cmbzilinengli.SelectedIndex + 1).ToString();
                }
                else
                {
                    RecordsManageMentModel.OldSelfCareability = null;
                }
            }
        }

        private void btnHW_Click(object sender, EventArgs e)
        {
            ShowHW frm = new ShowHW();
            frm.ShowDialog();

            stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "39");
            if (devData.HasValue)
            {
                this.tbHeight.Text = devData.value1;

                if (devData.value1 != "")
                {
                    this.GerneralCondition.Height = decimal.Parse(devData.value1);
                }

                this.tbWeight.Text = devData.value2;

                if (devData.value2 != "")
                {
                    this.GerneralCondition.Weight = decimal.Parse(devData.value2);
                }

                this.txttzzs.Text = devData.value3;

                if (devData.value3 != "")
                {
                    this.GerneralCondition.BMI = decimal.Parse(devData.value3);
                }
            }
        }

        private void btnhxpl_Click(object sender, EventArgs e) //呼吸频率的计算
        {
            int m;
            if (int.TryParse(tbMailv.Text, out m))
            {
                if (m / 4 >= 20)
                {
                    this.txthxpl.Text = "20";
                }
                else if (m / 4 <= 16)
                {
                    this.txthxpl.Text = "16";
                }
                else
                    this.txthxpl.Text = Convert.ToString(m / 4);
            }
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            Assembly sampleAssembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + @"\" + "PhotoGraph.exe");

            if (sampleAssembly != null)
            {
                Form loadForm = (Form)sampleAssembly.CreateInstance("PhotoGraph.FrmCameraB");
                string path = PhotosPath + "Physical//";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                path = path + this.Model.IDCardNo + ".jpg";

                PropertyInfo property = loadForm.GetType().GetProperty("SavePath", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (property != null)
                {
                    property.SetValue(loadForm, path, null);
                }

                loadForm.ShowDialog();
            }
        }
    }
}