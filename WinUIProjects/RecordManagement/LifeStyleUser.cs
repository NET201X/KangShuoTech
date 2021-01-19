using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
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

    public class UCLifeStyle : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private CheckedListBox chByjzl;
        private CheckedListBox chBysxg;
        private ComboBox cmbduanlianpinlv;
        private ComboBox cmbxiyanzhuangkuang;
        private ComboBox cmbyinjiuzhuangkuang;
        private IContainer components;
        private List<ItemDictonaryModel<string>> duanlianpinlv;
        private DuWuUserControl DuWuFC;
        private DuWuUserControl DuWuFSX;
        private DuWuUserControl DuWuHX;
        private DuWuUserControl DuWuOther;
        private List<DuWuUserControl> duwus = new List<DuWuUserControl>();
        private DuWuUserControl DuWuWl;
        private GroupBox groupBox16;
        private GroupBox groupBox17;
        private GroupBox groupBox18;
        private GroupBox groupBox19;
        private GroupBox groupBox20;
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr>();
        private List<InputRangeDec> inputRanges;
        private Label label37;
        private Label label38;
        private Label label39;
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
        private Label label60;
        private Label label61;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label label65;
        private Label label66;
        private Panel panel1;
        private Panel panel2;
        private RadioButton radNo;
        private RadioButton radweiJiu;
        private RadioButton radYes;
        private RadioButton radyjieju;
        private RadioButton radzyHave;
        private RadioButton radzyNoHave;
        private TextBox txtdlyear;
        private TextBox txtexWay;
        private TextBox txtgunSomkeAge;
        private TextBox txtJieAage;
        private TextBox txtjiuSum;
        private TextBox txtjQiTa;
        private TextBox txtMint;
        private TextBox txtSmokingAge;
        private TextBox txtyanSum;
        private TextBox txtyinAage;
        private TextBox txtzygz;
        private TextBox txtzyyear;
        private CMoreChange wine;
        private List<ItemDictonaryModel<string>> xiyan;
        private Panel panel3;
        private CheckBox ckbdlqt;
        private CheckBox ckbdlgcw;
        private CheckBox ckbdlpb;
        private CheckBox ckbdlsb;
        private TextBox tbdlfsqt;
        private List<ItemDictonaryModel<string>> yinjiu;
        private List<CheckBox> dlfslist = new List<CheckBox>();
        private DataSet dsRequire;
        public UCLifeStyle()
        {
            this.InitializeComponent();
            this.duwus.Add(this.DuWuFSX);
            this.duwus.Add(this.DuWuWl);
            this.duwus.Add(this.DuWuFC);
            this.duwus.Add(this.DuWuHX);
            this.duwus.Add(this.DuWuOther);
            this.dlfslist.Add(this.ckbdlsb);
            this.dlfslist.Add(this.ckbdlpb);
            this.dlfslist.Add(this.ckbdlgcw);
            this.dlfslist.Add(this.ckbdlqt);
            this.InitControlSource();
            this.EveryThingIsOk = false;
        }

        private void bd_Format(object sender, ConvertEventArgs e)
        {
            decimal num;
            if ((e.Value == null) || !decimal.TryParse(e.Value.ToString(), out num))
            {
                e.Value = "";
            }
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

        public ChildFormStatus CheckErrorInput()
        {
            if ((this.inputRanges.Count<InputRangeDec>(c => c.ErrorInput) <= 0) && ((this.inputrange_str.Count<InputRangeStr>(c => c.ErrorInput) <= 0) && !this.wine.ErrorInput))
            {
                return ChildFormStatus.NoErrorInput;
            }
            return ChildFormStatus.HasErrorInput;
        }

        private void cmbduanlianpinlv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbduanlianpinlv.Text == "不锻炼")
            {
                this.txtdlyear.Text = "";
                this.txtdlyear.ReadOnly = true;
                this.txtMint.Text = "";
                this.txtMint.ReadOnly = true;
                //this.txtexWay.Text = "";
                //this.txtexWay.ReadOnly = true;
            }
            else
            {
                this.txtdlyear.ReadOnly = false;
                this.txtMint.ReadOnly = false;
                //this.txtexWay.ReadOnly = false;
            }
        }

        private void cmbxiyanzhuangkuang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbxiyanzhuangkuang.Text == "从不吸烟")
            {
                this.txtyanSum.Text = "";
                this.txtSmokingAge.Text = "";
                this.txtgunSomkeAge.Text = "";
                this.txtyanSum.ReadOnly = true;
                this.txtSmokingAge.ReadOnly = true;
                this.txtgunSomkeAge.ReadOnly = true;
            }
            else
            {
                this.txtyanSum.ReadOnly = false;
                this.txtSmokingAge.ReadOnly = false;
                this.txtgunSomkeAge.ReadOnly = false;
                if (this.cmbxiyanzhuangkuang.Text == "吸烟")
                {
                    this.txtgunSomkeAge.Clear();
                    this.txtgunSomkeAge.ReadOnly = true;
                }
            }
        }

        private void cmbyinjiuzhuangkuang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbyinjiuzhuangkuang.Text == "从不")
            {
                foreach (Control control in this.groupBox19.Controls)
                {
                    if (control.GetType().Equals(typeof(TextBox)))
                    {
                        TextBox box = control as TextBox;
                        box.Text = "";
                        box.ReadOnly = true;
                    }
                    if (control.GetType().Equals(typeof(CheckedListBox)))
                    {
                        CheckedListBox box2 = control as CheckedListBox;
                        box2.ClearSelected();
                        box2.Enabled = false;
                    }
                }
                for (int i = 0; i < this.chByjzl.Items.Count; i++)
                {
                    this.chByjzl.SetItemCheckState(i, CheckState.Unchecked);
                }
                this.chByjzl.Enabled = false;
                this.radweiJiu.Checked = false;
                this.radyjieju.Checked = false;
                this.radYes.Checked = false;
                this.radNo.Checked = false;
                this.radweiJiu.Enabled = false;
                this.radyjieju.Enabled = false;
                this.radYes.Enabled = false;
                this.radNo.Enabled = false;
            }
            else
            {
                foreach (Control control2 in this.groupBox19.Controls)
                {
                    if (control2.GetType().Equals(typeof(TextBox)))
                    {
                        TextBox box3 = control2 as TextBox;
                        if (box3 == this.txtJieAage)
                        {
                            if (this.radweiJiu.Checked)
                            {
                                box3.ReadOnly = true;
                            }
                        }
                        else
                        {
                            box3.ReadOnly = false;
                        }
                    }
                    if (control2.GetType().Equals(typeof(CheckedListBox)))
                    {
                        CheckedListBox box4 = control2 as CheckedListBox;
                        box4.ClearSelected();
                        box4.Enabled = true;
                    }
                }
                this.chByjzl.Enabled = true;
                this.radweiJiu.Enabled = true;
                this.radyjieju.Enabled = true;
                this.radYes.Enabled = true;
                this.radNo.Enabled = true;
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

        private void InitControlSource()
        {
            this.duanlianpinlv = new List<ItemDictonaryModel<string>>();
            this.duanlianpinlv.Add(new ItemDictonaryModel<string>("每天", "1"));
            this.duanlianpinlv.Add(new ItemDictonaryModel<string>("每周一次以上", "2"));
            this.duanlianpinlv.Add(new ItemDictonaryModel<string>("偶尔", "3"));
            this.duanlianpinlv.Add(new ItemDictonaryModel<string>("不锻炼", "4"));
            this.cmbduanlianpinlv.DisplayMember = "DISPLAYMEMBER";
            this.cmbduanlianpinlv.ValueMember = "VALUEMEMBER";
            this.cmbduanlianpinlv.DataSource = this.duanlianpinlv;
            this.xiyan = new List<ItemDictonaryModel<string>>();
            this.xiyan.Add(new ItemDictonaryModel<string>("从不吸烟", "1"));
            this.xiyan.Add(new ItemDictonaryModel<string>("已戒烟", "2"));
            this.xiyan.Add(new ItemDictonaryModel<string>("吸烟", "3"));
            this.cmbxiyanzhuangkuang.DisplayMember = "DISPLAYMEMBER";
            this.cmbxiyanzhuangkuang.ValueMember = "VALUEMEMBER";
            this.cmbxiyanzhuangkuang.DataSource = this.xiyan;
            this.yinjiu = new List<ItemDictonaryModel<string>>();
            this.yinjiu.Add(new ItemDictonaryModel<string>("从不", "1"));
            this.yinjiu.Add(new ItemDictonaryModel<string>("偶尔", "2"));
            this.yinjiu.Add(new ItemDictonaryModel<string>("经常", "3"));
            this.yinjiu.Add(new ItemDictonaryModel<string>("每天", "4"));
            this.cmbyinjiuzhuangkuang.DisplayMember = "DISPLAYMEMBER";
            this.cmbyinjiuzhuangkuang.ValueMember = "VALUEMEMBER";
            this.cmbyinjiuzhuangkuang.DataSource = this.yinjiu;
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("SmokeDayNum", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("SmokeAgeStart", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("SmokeAgeForbiddon", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("ExerciseTimes", 10000M, false));
            this.inputRanges.Add(new InputRangeDec("ExcisepersistTime", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("DayDrinkVolume", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("ForbiddonAge", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("DrinkStartAge", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("WorkTime", 1000M, false));
            this.inputrange_str.Add(new InputRangeStr("ExerciseExistense", 50));
            this.inputrange_str.Add(new InputRangeStr("WorkType", 30));
        }

        public void InitEveryThing()
        {
            dsRequire = new RequireBLL().GetList("TabName = '健康体检' AND Comment = '生活方式' ");
            this.LifeStyle = new RecordsLifeStyleBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (this.LifeStyle == null)
            {
                RecordsLifeStyleModel recordsLifeStyleModel = new RecordsLifeStyleModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    ExerciseRate = "4",
                    SmokeCondition = "1",
                    DrinkRate = "1"
                };
                this.LifeStyle = recordsLifeStyleModel;
            }
            if (PhysicalInfoFactory.falgID == 0)
            {
                this.PresetValue();//默认项设置
            }
            this.SimpleBinding(this.cmbduanlianpinlv, this.LifeStyle, "ExerciseRate");
            this.SimpleBinding(this.cmbxiyanzhuangkuang, this.LifeStyle, "SmokeCondition");
            this.SimpleBinding(this.cmbyinjiuzhuangkuang, this.LifeStyle, "DrinkRate");

            this.SimpleBinding(this.txtMint, "ExerciseTimes", true);
            this.SimpleBinding(this.txtdlyear, "ExcisepersistTime", true);
            this.Transdlfs(); //锻炼方式
            this.TransHabit();//饮食习惯
            this.SimpleBinding(this.txtyanSum, "SmokeDayNum", true);
            this.SimpleBinding(this.txtSmokingAge, "SmokeAgeStart", true);
            this.SimpleBinding(this.txtgunSomkeAge, "SmokeAgeForbiddon", true);
            this.SimpleBinding(this.txtjiuSum, "DayDrinkVolume", true);
            this.SimpleBinding(this.txtyinAage, "DrinkStartAge", true);
            this.SimpleBinding(this.txtJieAage, "ForbiddonAge", true);
            this.SimpleBinding(this.tbdlfsqt, "ExerciseExistenseOther", false);
            if (!string.IsNullOrEmpty(this.LifeStyle.IsDrinkForbiddon))
            {
                if (this.LifeStyle.IsDrinkForbiddon == "1")
                {
                    this.radweiJiu.Checked = true;
                }
                else
                {
                    this.radyjieju.Checked = true;
                }
            }
  
            if (!string.IsNullOrEmpty(this.LifeStyle.DrinkThisYear))
            {
                if (this.LifeStyle.DrinkThisYear == "1")
                {
                    this.radYes.Checked = true;
                }
                else
                {
                    this.radNo.Checked = true;
                }
            }
   
            CMoreChange change = new CMoreChange {
                Name = "酒类",
                MoreChange = this.chByjzl,
                Other = this.txtjQiTa,
                MaxBytesCount = 20
            };
            this.wine = change;
            this.wine.TransInfo(this.LifeStyle.DrinkType, this.LifeStyle.DrinkTypeOther);
            if (!string.IsNullOrEmpty(this.LifeStyle.CareerHarmFactorHistory))
            {
                if (this.LifeStyle.CareerHarmFactorHistory == "1")
                {
                    this.radzyNoHave.Checked = true;
                }
                else
                {
                    this.radzyHave.Checked = true;
                }
            }
    
            this.SimpleBinding(this.txtzygz, "WorkType", false);
            this.SimpleBinding(this.txtzyyear, "WorkTime", true);
            if (!string.IsNullOrEmpty(this.LifeStyle.IDCardNo))
            {
                this.DuWuFC.TypeName = this.LifeStyle.Dust;
                this.DuWuFC.IsProject = this.LifeStyle.DustProtect;
                this.DuWuFC.ProtectMothed = this.LifeStyle.DustProtectEx;
                this.DuWuFSX.TypeName = this.LifeStyle.Radiogen;
                this.DuWuFSX.IsProject = this.LifeStyle.RadiogenProtect;
                this.DuWuFSX.ProtectMothed = this.LifeStyle.RadiogenProtectEx;
                this.DuWuWl.TypeName = this.LifeStyle.Physical;
                this.DuWuWl.IsProject = this.LifeStyle.PhysicalProtect;
                this.DuWuWl.ProtectMothed = this.LifeStyle.PhysicalProtectEx;
                this.DuWuHX.TypeName = this.LifeStyle.Chem;
                this.DuWuHX.IsProject = this.LifeStyle.ChemProtect;
                this.DuWuHX.ProtectMothed = this.LifeStyle.ChemProtectEx;
                this.DuWuOther.TypeName = this.LifeStyle.Other;
                this.DuWuOther.IsProject = this.LifeStyle.OtherProtect;
                this.DuWuOther.ProtectMothed = this.LifeStyle.OtherProtectEx;
            }
            MustChoose();
            this.EveryThingIsOk = true;
        }
        //默认项设置
        private void PresetValue()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = " IsSetValue='是' or IsSetValue='预设上次体检' ";
            DataTable dt = dv.ToTable();
            RecordsCustomerBaseInfoModel CustomerBaseInfos = new RecordsCustomerBaseInfoBLL().GetMaxModel(this.Model.IDCardNo);//获取最新一笔体检数据
            RecordsLifeStyleModel LifeStyles = new RecordsLifeStyleModel();
            if (CustomerBaseInfos != null)
            {
                LifeStyles = new RecordsLifeStyleBLL().GetModelByOutKey(CustomerBaseInfos.ID);
            }
            foreach (DataRow item in dt.Rows)
            {
                switch (item["ChinName"].ToString())
                {
                    case "锻炼频率":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.LifeStyle.ExerciseRate = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.LifeStyle.ExerciseRate = LifeStyles.ExerciseRate;
                            this.LifeStyle.ExerciseTimes = LifeStyles.ExerciseTimes;
                            this.LifeStyle.ExcisepersistTime = LifeStyles.ExcisepersistTime;
                        }
                        break;
                    case "饮食习惯":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.LifeStyle.DietaryHabit = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.LifeStyle.DietaryHabit = LifeStyles.DietaryHabit;
                        }
                        break;
                    case "职业病危害因素接触史":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.LifeStyle.CareerHarmFactorHistory = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.LifeStyle.CareerHarmFactorHistory = LifeStyles.CareerHarmFactorHistory;
                            this.LifeStyle.WorkType = LifeStyles.WorkType;
                            this.LifeStyle.WorkTime = LifeStyles.WorkTime;
                            this.LifeStyle.Dust = LifeStyles.Dust;
                            this.LifeStyle.DustProtect = LifeStyles.DustProtect;
                            this.LifeStyle.DustProtectEx = LifeStyles.DustProtectEx;
                            this.LifeStyle.Radiogen = LifeStyles.Radiogen;
                            this.LifeStyle.RadiogenProtect = LifeStyles.RadiogenProtect;
                            this.LifeStyle.RadiogenProtectEx = LifeStyles.RadiogenProtectEx;
                            this.LifeStyle.Physical = LifeStyles.Physical;
                            this.LifeStyle.PhysicalProtect = LifeStyles.PhysicalProtect;
                            this.LifeStyle.PhysicalProtectEx = LifeStyles.PhysicalProtectEx;
                            this.LifeStyle.Chem = LifeStyles.Chem;
                            this.LifeStyle.ChemProtect = LifeStyles.ChemProtect;
                            this.LifeStyle.ChemProtectEx = LifeStyles.ChemProtectEx;
                            this.LifeStyle.Other = LifeStyles.Other;
                            this.LifeStyle.OtherProtect = LifeStyles.OtherProtect;
                            this.LifeStyle.OtherProtectEx = LifeStyles.OtherProtectEx;
                        }
                        break;
                    case "吸烟状况":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.LifeStyle.SmokeCondition = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.LifeStyle.SmokeCondition = LifeStyles.SmokeCondition;
                            this.LifeStyle.SmokeDayNum = LifeStyles.SmokeDayNum;
                            this.LifeStyle.SmokeAgeStart = LifeStyles.SmokeAgeStart;
                            this.LifeStyle.ForbiddonAge = LifeStyles.ForbiddonAge;
                        }
                        break;
                    case "饮酒频率":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.LifeStyle.DrinkRate = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.LifeStyle.DrinkRate = LifeStyles.DrinkRate;
                            this.LifeStyle.DayDrinkVolume = LifeStyles.DayDrinkVolume;
                            this.LifeStyle.DrinkStartAge = LifeStyles.DrinkStartAge;
                            this.LifeStyle.IsDrinkForbiddon = LifeStyles.IsDrinkForbiddon;
                            this.LifeStyle.ForbiddonAge = LifeStyles.ForbiddonAge;
                            this.LifeStyle.DrinkThisYear = LifeStyles.DrinkThisYear;
                            this.LifeStyle.DrinkType = LifeStyles.DrinkType;
                            this.LifeStyle.DrinkTypeOther = LifeStyles.DrinkTypeOther;
                        }
                        break;
                    case "锻炼方式":
                        if (item["IsSetValue"].ToString() == "是")
                        {
                            this.LifeStyle.ExerciseExistense = item["ItemValue"].ToString();
                        }
                        else
                        {
                            this.LifeStyle.ExerciseExistense = LifeStyles.ExerciseExistense;
                            this.LifeStyle.ExerciseExistenseOther = LifeStyles.ExerciseExistenseOther;
                        }
                        break;
                }
            }
        }
        private void MustChoose()
        {
            DataView dv = dsRequire.Tables[0].DefaultView;
            dv.RowFilter = "IsRequired='1' ";
            DataTable dt = dv.ToTable();
            RecordsLifeStyleModel LifeStyles = new RecordsLifeStyleBLL().GetModelByOutKey(PhysicalInfoFactory.ID);
            if (LifeStyles == null) LifeStyles = new RecordsLifeStyleModel();

            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "饮食习惯":
                            if (string.IsNullOrEmpty(Convert.ToString(LifeStyles.DietaryHabit)))
                            {
                                this.groupBox17.Text = "*饮食习惯";
                                this.groupBox17.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.groupBox17.Text = "饮食习惯";
                                this.groupBox17.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "职业病危害因素接触史":
                            if (string.IsNullOrEmpty(Convert.ToString(LifeStyles.CareerHarmFactorHistory)))
                            {
                                this.groupBox20.Text = "*职业病危害因素接触史";
                                this.groupBox20.ForeColor = System.Drawing.Color.Red;
                                this.radzyNoHave.ForeColor = System.Drawing.Color.Black;
                                this.radzyHave.ForeColor = System.Drawing.Color.Black;
                                this.label64.ForeColor = System.Drawing.Color.Black;
                                this.label65.ForeColor = System.Drawing.Color.Black;
                                this.label63.ForeColor = System.Drawing.Color.Black;
                                this.DuWuFC.ForeColor = System.Drawing.Color.Black;
                                this.DuWuFSX.ForeColor = System.Drawing.Color.Black;
                                this.DuWuWl.ForeColor = System.Drawing.Color.Black;
                                this.DuWuHX.ForeColor = System.Drawing.Color.Black;
                                this.DuWuOther.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.groupBox20.Text = "职业病危害因素接触史";
                                this.groupBox20.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "锻炼频率":
                            if (string.IsNullOrEmpty(LifeStyles.ExerciseRate))
                            {
                                this.label37.Text = "*锻炼频率:";
                                this.label37.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label37.Text = "锻炼频率:";
                                this.label37.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "锻炼方式":
                            if (string.IsNullOrEmpty(LifeStyles.ExerciseExistense))
                            {
                                this.label42.Text = "*锻炼方式:";
                                this.label42.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label42.Text = "锻炼方式:";
                                this.label42.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "吸烟状况":
                            if (string.IsNullOrEmpty(LifeStyles.SmokeCondition))
                            {
                                this.label43.Text = "*吸烟状况:";
                                this.label43.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label43.Text = "吸烟状况:";
                                this.label43.ForeColor = System.Drawing.Color.Black;
                            }
                            break;

                        case "饮酒频率":
                            if (string.IsNullOrEmpty(LifeStyles.DrinkRate))
                            {
                                this.label51.Text = "*饮酒频率:";
                                this.label51.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label51.Text = "饮酒频率:";
                                this.label51.ForeColor = System.Drawing.Color.Black;
                            }
                            break;


                        default: break;
                    }
                }
            }
        }
        private void InitializeComponent()
        {
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.DuWuOther = new KangShuoTech.Utilities.CommonControl.DuWuUserControl();
            this.DuWuHX = new KangShuoTech.Utilities.CommonControl.DuWuUserControl();
            this.DuWuWl = new KangShuoTech.Utilities.CommonControl.DuWuUserControl();
            this.DuWuFC = new KangShuoTech.Utilities.CommonControl.DuWuUserControl();
            this.DuWuFSX = new KangShuoTech.Utilities.CommonControl.DuWuUserControl();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.txtzygz = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.txtzyyear = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.radzyNoHave = new System.Windows.Forms.RadioButton();
            this.radzyHave = new System.Windows.Forms.RadioButton();
            this.label62 = new System.Windows.Forms.Label();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.cmbyinjiuzhuangkuang = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radNo = new System.Windows.Forms.RadioButton();
            this.radYes = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radyjieju = new System.Windows.Forms.RadioButton();
            this.radweiJiu = new System.Windows.Forms.RadioButton();
            this.chByjzl = new System.Windows.Forms.CheckedListBox();
            this.txtjQiTa = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.txtJieAage = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.txtyinAage = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.txtjiuSum = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.cmbxiyanzhuangkuang = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtgunSomkeAge = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.txtSmokingAge = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.txtyanSum = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.chBysxg = new System.Windows.Forms.CheckedListBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.tbdlfsqt = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckbdlqt = new System.Windows.Forms.CheckBox();
            this.ckbdlgcw = new System.Windows.Forms.CheckBox();
            this.ckbdlpb = new System.Windows.Forms.CheckBox();
            this.ckbdlsb = new System.Windows.Forms.CheckBox();
            this.cmbduanlianpinlv = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtdlyear = new System.Windows.Forms.TextBox();
            this.txtMint = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.DuWuOther);
            this.groupBox20.Controls.Add(this.DuWuHX);
            this.groupBox20.Controls.Add(this.DuWuWl);
            this.groupBox20.Controls.Add(this.DuWuFC);
            this.groupBox20.Controls.Add(this.DuWuFSX);
            this.groupBox20.Controls.Add(this.label66);
            this.groupBox20.Controls.Add(this.label65);
            this.groupBox20.Controls.Add(this.txtzygz);
            this.groupBox20.Controls.Add(this.label63);
            this.groupBox20.Controls.Add(this.txtzyyear);
            this.groupBox20.Controls.Add(this.label64);
            this.groupBox20.Controls.Add(this.radzyNoHave);
            this.groupBox20.Controls.Add(this.radzyHave);
            this.groupBox20.Controls.Add(this.label62);
            this.groupBox20.Location = new System.Drawing.Point(76, 414);
            this.groupBox20.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox20.Size = new System.Drawing.Size(1400, 258);
            this.groupBox20.TabIndex = 4;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "职业病危害因素接触史";
            // 
            // DuWuOther
            // 
            this.DuWuOther.CCaption = "其他";
            this.DuWuOther.Font = new System.Drawing.Font("宋体", 15F);
            this.DuWuOther.IsProject = "1";
            this.DuWuOther.Location = new System.Drawing.Point(148, 215);
            this.DuWuOther.Margin = new System.Windows.Forms.Padding(4);
            this.DuWuOther.Name = "DuWuOther";
            this.DuWuOther.ProtectMothed = "";
            this.DuWuOther.Size = new System.Drawing.Size(1140, 38);
            this.DuWuOther.TabIndex = 12;
            this.DuWuOther.TypeName = "";
            // 
            // DuWuHX
            // 
            this.DuWuHX.CCaption = "化学物质";
            this.DuWuHX.Font = new System.Drawing.Font("宋体", 15F);
            this.DuWuHX.IsProject = "1";
            this.DuWuHX.Location = new System.Drawing.Point(148, 177);
            this.DuWuHX.Margin = new System.Windows.Forms.Padding(4);
            this.DuWuHX.Name = "DuWuHX";
            this.DuWuHX.ProtectMothed = "";
            this.DuWuHX.Size = new System.Drawing.Size(1158, 80);
            this.DuWuHX.TabIndex = 11;
            this.DuWuHX.TypeName = "";
            // 
            // DuWuWl
            // 
            this.DuWuWl.CCaption = "物理因素";
            this.DuWuWl.Font = new System.Drawing.Font("宋体", 15F);
            this.DuWuWl.IsProject = "1";
            this.DuWuWl.Location = new System.Drawing.Point(148, 138);
            this.DuWuWl.Margin = new System.Windows.Forms.Padding(4);
            this.DuWuWl.Name = "DuWuWl";
            this.DuWuWl.ProtectMothed = "";
            this.DuWuWl.Size = new System.Drawing.Size(1140, 38);
            this.DuWuWl.TabIndex = 10;
            this.DuWuWl.TypeName = "";
            // 
            // DuWuFC
            // 
            this.DuWuFC.CCaption = "粉尘";
            this.DuWuFC.Font = new System.Drawing.Font("宋体", 15F);
            this.DuWuFC.IsProject = "1";
            this.DuWuFC.Location = new System.Drawing.Point(148, 62);
            this.DuWuFC.Margin = new System.Windows.Forms.Padding(4);
            this.DuWuFC.Name = "DuWuFC";
            this.DuWuFC.ProtectMothed = "";
            this.DuWuFC.Size = new System.Drawing.Size(1165, 38);
            this.DuWuFC.TabIndex = 8;
            this.DuWuFC.TypeName = "";
            this.DuWuFC.Load += new System.EventHandler(this.DuWuFC_Load);
            // 
            // DuWuFSX
            // 
            this.DuWuFSX.CCaption = "放射性物质";
            this.DuWuFSX.Font = new System.Drawing.Font("宋体", 15F);
            this.DuWuFSX.IsProject = "1";
            this.DuWuFSX.Location = new System.Drawing.Point(148, 101);
            this.DuWuFSX.Margin = new System.Windows.Forms.Padding(4);
            this.DuWuFSX.Name = "DuWuFSX";
            this.DuWuFSX.ProtectMothed = "";
            this.DuWuFSX.Size = new System.Drawing.Size(1140, 38);
            this.DuWuFSX.TabIndex = 9;
            this.DuWuFSX.TypeName = "";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(26, 70);
            this.label66.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(129, 26);
            this.label66.TabIndex = 39;
            this.label66.Text = "毒物种类:";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(544, 32);
            this.label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(116, 26);
            this.label65.TabIndex = 5;
            this.label65.Text = "从业时间";
            // 
            // txtzygz
            // 
            this.txtzygz.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtzygz.Location = new System.Drawing.Point(436, 26);
            this.txtzygz.Margin = new System.Windows.Forms.Padding(4);
            this.txtzygz.MaxLength = 20;
            this.txtzygz.Name = "txtzygz";
            this.txtzygz.Size = new System.Drawing.Size(103, 36);
            this.txtzygz.TabIndex = 4;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(732, 31);
            this.label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(64, 26);
            this.label63.TabIndex = 7;
            this.label63.Text = "年﹚";
            // 
            // txtzyyear
            // 
            this.txtzyyear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtzyyear.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtzyyear.Location = new System.Drawing.Point(674, 26);
            this.txtzyyear.Margin = new System.Windows.Forms.Padding(4);
            this.txtzyyear.MaxLength = 2;
            this.txtzyyear.Name = "txtzyyear";
            this.txtzyyear.Size = new System.Drawing.Size(50, 36);
            this.txtzyyear.TabIndex = 6;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(332, 32);
            this.label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(90, 26);
            this.label64.TabIndex = 3;
            this.label64.Text = "﹙工种";
            // 
            // radzyNoHave
            // 
            this.radzyNoHave.AutoSize = true;
            this.radzyNoHave.Location = new System.Drawing.Point(155, 28);
            this.radzyNoHave.Margin = new System.Windows.Forms.Padding(4);
            this.radzyNoHave.Name = "radzyNoHave";
            this.radzyNoHave.Size = new System.Drawing.Size(59, 30);
            this.radzyNoHave.TabIndex = 1;
            this.radzyNoHave.TabStop = true;
            this.radzyNoHave.Text = "无";
            this.radzyNoHave.UseVisualStyleBackColor = true;
            this.radzyNoHave.CheckedChanged += new System.EventHandler(this.radzyNoHave_CheckedChanged);
            // 
            // radzyHave
            // 
            this.radzyHave.AutoSize = true;
            this.radzyHave.Location = new System.Drawing.Point(265, 28);
            this.radzyHave.Margin = new System.Windows.Forms.Padding(4);
            this.radzyHave.Name = "radzyHave";
            this.radzyHave.Size = new System.Drawing.Size(59, 30);
            this.radzyHave.TabIndex = 2;
            this.radzyHave.TabStop = true;
            this.radzyHave.Text = "有";
            this.radzyHave.UseVisualStyleBackColor = true;
            this.radzyHave.CheckedChanged += new System.EventHandler(this.radzyHave_CheckedChanged);
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(26, 32);
            this.label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(129, 26);
            this.label62.TabIndex = 0;
            this.label62.Text = "有无危害:";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.cmbyinjiuzhuangkuang);
            this.groupBox19.Controls.Add(this.panel2);
            this.groupBox19.Controls.Add(this.panel1);
            this.groupBox19.Controls.Add(this.chByjzl);
            this.groupBox19.Controls.Add(this.txtjQiTa);
            this.groupBox19.Controls.Add(this.label61);
            this.groupBox19.Controls.Add(this.label60);
            this.groupBox19.Controls.Add(this.label58);
            this.groupBox19.Controls.Add(this.txtJieAage);
            this.groupBox19.Controls.Add(this.label59);
            this.groupBox19.Controls.Add(this.label57);
            this.groupBox19.Controls.Add(this.label56);
            this.groupBox19.Controls.Add(this.txtyinAage);
            this.groupBox19.Controls.Add(this.label55);
            this.groupBox19.Controls.Add(this.label53);
            this.groupBox19.Controls.Add(this.txtjiuSum);
            this.groupBox19.Controls.Add(this.label54);
            this.groupBox19.Controls.Add(this.label52);
            this.groupBox19.Controls.Add(this.label51);
            this.groupBox19.Location = new System.Drawing.Point(76, 254);
            this.groupBox19.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox19.Size = new System.Drawing.Size(1400, 160);
            this.groupBox19.TabIndex = 3;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "饮酒情况";
            // 
            // cmbyinjiuzhuangkuang
            // 
            this.cmbyinjiuzhuangkuang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyinjiuzhuangkuang.FormattingEnabled = true;
            this.cmbyinjiuzhuangkuang.Location = new System.Drawing.Point(149, 26);
            this.cmbyinjiuzhuangkuang.Margin = new System.Windows.Forms.Padding(4);
            this.cmbyinjiuzhuangkuang.Name = "cmbyinjiuzhuangkuang";
            this.cmbyinjiuzhuangkuang.Size = new System.Drawing.Size(232, 33);
            this.cmbyinjiuzhuangkuang.TabIndex = 0;
            this.cmbyinjiuzhuangkuang.SelectedIndexChanged += new System.EventHandler(this.cmbyinjiuzhuangkuang_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radNo);
            this.panel2.Controls.Add(this.radYes);
            this.panel2.Location = new System.Drawing.Point(1125, 65);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 45);
            this.panel2.TabIndex = 5;
            // 
            // radNo
            // 
            this.radNo.AutoSize = true;
            this.radNo.Location = new System.Drawing.Point(102, 9);
            this.radNo.Margin = new System.Windows.Forms.Padding(4);
            this.radNo.Name = "radNo";
            this.radNo.Size = new System.Drawing.Size(59, 30);
            this.radNo.TabIndex = 31;
            this.radNo.TabStop = true;
            this.radNo.Text = "否";
            this.radNo.UseVisualStyleBackColor = true;
            // 
            // radYes
            // 
            this.radYes.AutoSize = true;
            this.radYes.Location = new System.Drawing.Point(18, 9);
            this.radYes.Margin = new System.Windows.Forms.Padding(4);
            this.radYes.Name = "radYes";
            this.radYes.Size = new System.Drawing.Size(59, 30);
            this.radYes.TabIndex = 30;
            this.radYes.TabStop = true;
            this.radYes.Text = "是";
            this.radYes.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radyjieju);
            this.panel1.Controls.Add(this.radweiJiu);
            this.panel1.Location = new System.Drawing.Point(149, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 49);
            this.panel1.TabIndex = 3;
            // 
            // radyjieju
            // 
            this.radyjieju.AutoSize = true;
            this.radyjieju.Location = new System.Drawing.Point(113, 11);
            this.radyjieju.Margin = new System.Windows.Forms.Padding(4);
            this.radyjieju.Name = "radyjieju";
            this.radyjieju.Size = new System.Drawing.Size(111, 30);
            this.radyjieju.TabIndex = 25;
            this.radyjieju.TabStop = true;
            this.radyjieju.Text = "已戒酒";
            this.radyjieju.UseVisualStyleBackColor = true;
            this.radyjieju.CheckedChanged += new System.EventHandler(this.radyjieju_CheckedChanged);
            // 
            // radweiJiu
            // 
            this.radweiJiu.AutoSize = true;
            this.radweiJiu.Location = new System.Drawing.Point(6, 11);
            this.radweiJiu.Margin = new System.Windows.Forms.Padding(4);
            this.radweiJiu.Name = "radweiJiu";
            this.radweiJiu.Size = new System.Drawing.Size(111, 30);
            this.radweiJiu.TabIndex = 24;
            this.radweiJiu.TabStop = true;
            this.radweiJiu.Text = "未戒酒";
            this.radweiJiu.UseVisualStyleBackColor = true;
            this.radweiJiu.CheckedChanged += new System.EventHandler(this.radweiJiu_CheckedChanged);
            // 
            // chByjzl
            // 
            this.chByjzl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chByjzl.CheckOnClick = true;
            this.chByjzl.FormattingEnabled = true;
            this.chByjzl.Items.AddRange(new object[] {
            "白酒",
            "啤酒",
            "红酒",
            "黄酒",
            "其他"});
            this.chByjzl.Location = new System.Drawing.Point(149, 118);
            this.chByjzl.Margin = new System.Windows.Forms.Padding(4);
            this.chByjzl.MultiColumn = true;
            this.chByjzl.Name = "chByjzl";
            this.chByjzl.Size = new System.Drawing.Size(773, 35);
            this.chByjzl.TabIndex = 6;
            // 
            // txtjQiTa
            // 
            this.txtjQiTa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtjQiTa.Location = new System.Drawing.Point(938, 117);
            this.txtjQiTa.Margin = new System.Windows.Forms.Padding(4);
            this.txtjQiTa.MaxLength = 20;
            this.txtjQiTa.Name = "txtjQiTa";
            this.txtjQiTa.ReadOnly = true;
            this.txtjQiTa.Size = new System.Drawing.Size(216, 36);
            this.txtjQiTa.TabIndex = 7;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(26, 123);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(129, 26);
            this.label61.TabIndex = 30;
            this.label61.Text = "饮酒种类:";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(932, 80);
            this.label60.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(207, 26);
            this.label60.TabIndex = 27;
            this.label60.Text = "近一年是否醉酒:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(822, 79);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(38, 26);
            this.label58.TabIndex = 26;
            this.label58.Text = "岁";
            // 
            // txtJieAage
            // 
            this.txtJieAage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtJieAage.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtJieAage.Location = new System.Drawing.Point(673, 73);
            this.txtJieAage.Margin = new System.Windows.Forms.Padding(4);
            this.txtJieAage.MaxLength = 3;
            this.txtJieAage.Name = "txtJieAage";
            this.txtJieAage.ReadOnly = true;
            this.txtJieAage.Size = new System.Drawing.Size(116, 36);
            this.txtJieAage.TabIndex = 4;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(552, 76);
            this.label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(129, 26);
            this.label59.TabIndex = 24;
            this.label59.Text = "戒酒年龄:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(26, 81);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(129, 26);
            this.label57.TabIndex = 21;
            this.label57.Text = "是否戒酒:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(1220, 29);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(38, 26);
            this.label56.TabIndex = 20;
            this.label56.Text = "岁";
            // 
            // txtyinAage
            // 
            this.txtyinAage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtyinAage.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtyinAage.Location = new System.Drawing.Point(1125, 23);
            this.txtyinAage.Margin = new System.Windows.Forms.Padding(4);
            this.txtyinAage.MaxLength = 2;
            this.txtyinAage.Name = "txtyinAage";
            this.txtyinAage.Size = new System.Drawing.Size(89, 36);
            this.txtyinAage.TabIndex = 2;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(952, 30);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(181, 26);
            this.label55.TabIndex = 18;
            this.label55.Text = "开始饮酒年龄:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(822, 35);
            this.label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(38, 26);
            this.label53.TabIndex = 17;
            this.label53.Text = "两";
            // 
            // txtjiuSum
            // 
            this.txtjiuSum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtjiuSum.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtjiuSum.Location = new System.Drawing.Point(734, 27);
            this.txtjiuSum.Margin = new System.Windows.Forms.Padding(4);
            this.txtjiuSum.MaxLength = 6;
            this.txtjiuSum.Name = "txtjiuSum";
            this.txtjiuSum.Size = new System.Drawing.Size(80, 36);
            this.txtjiuSum.TabIndex = 1;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(673, 35);
            this.label54.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(64, 26);
            this.label54.TabIndex = 15;
            this.label54.Text = "平均";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(552, 35);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(129, 26);
            this.label52.TabIndex = 14;
            this.label52.Text = "日饮洒量:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(26, 35);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(129, 26);
            this.label51.TabIndex = 7;
            this.label51.Text = "饮酒频率:";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.cmbxiyanzhuangkuang);
            this.groupBox18.Controls.Add(this.label49);
            this.groupBox18.Controls.Add(this.txtgunSomkeAge);
            this.groupBox18.Controls.Add(this.label50);
            this.groupBox18.Controls.Add(this.label48);
            this.groupBox18.Controls.Add(this.txtSmokingAge);
            this.groupBox18.Controls.Add(this.label47);
            this.groupBox18.Controls.Add(this.label46);
            this.groupBox18.Controls.Add(this.txtyanSum);
            this.groupBox18.Controls.Add(this.label45);
            this.groupBox18.Controls.Add(this.label44);
            this.groupBox18.Controls.Add(this.label43);
            this.groupBox18.Location = new System.Drawing.Point(76, 185);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox18.Size = new System.Drawing.Size(1400, 68);
            this.groupBox18.TabIndex = 2;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "吸烟情况";
            // 
            // cmbxiyanzhuangkuang
            // 
            this.cmbxiyanzhuangkuang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxiyanzhuangkuang.FormattingEnabled = true;
            this.cmbxiyanzhuangkuang.Location = new System.Drawing.Point(149, 29);
            this.cmbxiyanzhuangkuang.Margin = new System.Windows.Forms.Padding(4);
            this.cmbxiyanzhuangkuang.Name = "cmbxiyanzhuangkuang";
            this.cmbxiyanzhuangkuang.Size = new System.Drawing.Size(232, 33);
            this.cmbxiyanzhuangkuang.TabIndex = 0;
            this.cmbxiyanzhuangkuang.SelectedIndexChanged += new System.EventHandler(this.cmbxiyanzhuangkuang_SelectedIndexChanged);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(1284, 33);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(38, 26);
            this.label49.TabIndex = 19;
            this.label49.Text = "岁";
            // 
            // txtgunSomkeAge
            // 
            this.txtgunSomkeAge.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtgunSomkeAge.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtgunSomkeAge.Location = new System.Drawing.Point(1197, 27);
            this.txtgunSomkeAge.Margin = new System.Windows.Forms.Padding(4);
            this.txtgunSomkeAge.MaxLength = 3;
            this.txtgunSomkeAge.Name = "txtgunSomkeAge";
            this.txtgunSomkeAge.Size = new System.Drawing.Size(80, 36);
            this.txtgunSomkeAge.TabIndex = 3;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(1073, 31);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(129, 26);
            this.label50.TabIndex = 17;
            this.label50.Text = "戒烟年龄:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(1007, 33);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(38, 26);
            this.label48.TabIndex = 16;
            this.label48.Text = "岁";
            // 
            // txtSmokingAge
            // 
            this.txtSmokingAge.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSmokingAge.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSmokingAge.Location = new System.Drawing.Point(917, 29);
            this.txtSmokingAge.Margin = new System.Windows.Forms.Padding(4);
            this.txtSmokingAge.MaxLength = 2;
            this.txtSmokingAge.Name = "txtSmokingAge";
            this.txtSmokingAge.Size = new System.Drawing.Size(82, 36);
            this.txtSmokingAge.TabIndex = 2;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(741, 32);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(181, 26);
            this.label47.TabIndex = 14;
            this.label47.Text = "开始吸烟年龄:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(673, 33);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(38, 26);
            this.label46.TabIndex = 13;
            this.label46.Text = "支";
            // 
            // txtyanSum
            // 
            this.txtyanSum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtyanSum.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtyanSum.Location = new System.Drawing.Point(582, 27);
            this.txtyanSum.Margin = new System.Windows.Forms.Padding(4);
            this.txtyanSum.MaxLength = 2;
            this.txtyanSum.Name = "txtyanSum";
            this.txtyanSum.Size = new System.Drawing.Size(82, 36);
            this.txtyanSum.TabIndex = 1;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(521, 33);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(64, 26);
            this.label45.TabIndex = 11;
            this.label45.Text = "平均";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(411, 33);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(129, 26);
            this.label44.TabIndex = 10;
            this.label44.Text = "日吸烟量:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(26, 32);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(129, 26);
            this.label43.TabIndex = 6;
            this.label43.Text = "吸烟状况:";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.chBysxg);
            this.groupBox17.Location = new System.Drawing.Point(76, 119);
            this.groupBox17.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox17.Size = new System.Drawing.Size(1400, 66);
            this.groupBox17.TabIndex = 1;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "饮食习惯";
            // 
            // chBysxg
            // 
            this.chBysxg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chBysxg.CheckOnClick = true;
            this.chBysxg.FormattingEnabled = true;
            this.chBysxg.Items.AddRange(new object[] {
            "荤素均衡",
            "荤食为主",
            "素食为主",
            "嗜盐",
            "嗜油",
            "嗜糖"});
            this.chBysxg.Location = new System.Drawing.Point(143, 28);
            this.chBysxg.Margin = new System.Windows.Forms.Padding(4);
            this.chBysxg.MultiColumn = true;
            this.chBysxg.Name = "chBysxg";
            this.chBysxg.Size = new System.Drawing.Size(941, 35);
            this.chBysxg.TabIndex = 0;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.tbdlfsqt);
            this.groupBox16.Controls.Add(this.panel3);
            this.groupBox16.Controls.Add(this.cmbduanlianpinlv);
            this.groupBox16.Controls.Add(this.label42);
            this.groupBox16.Controls.Add(this.label41);
            this.groupBox16.Controls.Add(this.txtdlyear);
            this.groupBox16.Controls.Add(this.txtMint);
            this.groupBox16.Controls.Add(this.label40);
            this.groupBox16.Controls.Add(this.label39);
            this.groupBox16.Controls.Add(this.label38);
            this.groupBox16.Controls.Add(this.label37);
            this.groupBox16.Location = new System.Drawing.Point(76, 3);
            this.groupBox16.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox16.Size = new System.Drawing.Size(1400, 115);
            this.groupBox16.TabIndex = 0;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "体育锻炼";
            // 
            // tbdlfsqt
            // 
            this.tbdlfsqt.Location = new System.Drawing.Point(616, 73);
            this.tbdlfsqt.Margin = new System.Windows.Forms.Padding(4);
            this.tbdlfsqt.Name = "tbdlfsqt";
            this.tbdlfsqt.ReadOnly = true;
            this.tbdlfsqt.Size = new System.Drawing.Size(416, 36);
            this.tbdlfsqt.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ckbdlqt);
            this.panel3.Controls.Add(this.ckbdlgcw);
            this.panel3.Controls.Add(this.ckbdlpb);
            this.panel3.Controls.Add(this.ckbdlsb);
            this.panel3.Location = new System.Drawing.Point(149, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(459, 40);
            this.panel3.TabIndex = 3;
            // 
            // ckbdlqt
            // 
            this.ckbdlqt.AutoSize = true;
            this.ckbdlqt.Location = new System.Drawing.Point(365, 10);
            this.ckbdlqt.Margin = new System.Windows.Forms.Padding(4);
            this.ckbdlqt.Name = "ckbdlqt";
            this.ckbdlqt.Size = new System.Drawing.Size(86, 30);
            this.ckbdlqt.TabIndex = 3;
            this.ckbdlqt.Text = "其他";
            this.ckbdlqt.UseVisualStyleBackColor = true;
            this.ckbdlqt.CheckedChanged += new System.EventHandler(this.ckbdlqt_CheckedChanged);
            // 
            // ckbdlgcw
            // 
            this.ckbdlgcw.AutoSize = true;
            this.ckbdlgcw.Location = new System.Drawing.Point(226, 10);
            this.ckbdlgcw.Margin = new System.Windows.Forms.Padding(4);
            this.ckbdlgcw.Name = "ckbdlgcw";
            this.ckbdlgcw.Size = new System.Drawing.Size(112, 30);
            this.ckbdlgcw.TabIndex = 2;
            this.ckbdlgcw.Text = "广场舞";
            this.ckbdlgcw.UseVisualStyleBackColor = true;
            // 
            // ckbdlpb
            // 
            this.ckbdlpb.AutoSize = true;
            this.ckbdlpb.Location = new System.Drawing.Point(111, 10);
            this.ckbdlpb.Margin = new System.Windows.Forms.Padding(4);
            this.ckbdlpb.Name = "ckbdlpb";
            this.ckbdlpb.Size = new System.Drawing.Size(86, 30);
            this.ckbdlpb.TabIndex = 1;
            this.ckbdlpb.Text = "跑步";
            this.ckbdlpb.UseVisualStyleBackColor = true;
            // 
            // ckbdlsb
            // 
            this.ckbdlsb.AutoSize = true;
            this.ckbdlsb.Location = new System.Drawing.Point(6, 10);
            this.ckbdlsb.Margin = new System.Windows.Forms.Padding(4);
            this.ckbdlsb.Name = "ckbdlsb";
            this.ckbdlsb.Size = new System.Drawing.Size(86, 30);
            this.ckbdlsb.TabIndex = 0;
            this.ckbdlsb.Text = "散步";
            this.ckbdlsb.UseVisualStyleBackColor = true;
            // 
            // cmbduanlianpinlv
            // 
            this.cmbduanlianpinlv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbduanlianpinlv.FormattingEnabled = true;
            this.cmbduanlianpinlv.Location = new System.Drawing.Point(149, 31);
            this.cmbduanlianpinlv.Margin = new System.Windows.Forms.Padding(4);
            this.cmbduanlianpinlv.Name = "cmbduanlianpinlv";
            this.cmbduanlianpinlv.Size = new System.Drawing.Size(270, 33);
            this.cmbduanlianpinlv.TabIndex = 0;
            this.cmbduanlianpinlv.SelectedIndexChanged += new System.EventHandler(this.cmbduanlianpinlv_SelectedIndexChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(26, 81);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(129, 26);
            this.label42.TabIndex = 9;
            this.label42.Text = "锻炼方式:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(1100, 36);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(38, 26);
            this.label41.TabIndex = 8;
            this.label41.Text = "年";
            // 
            // txtdlyear
            // 
            this.txtdlyear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtdlyear.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtdlyear.Location = new System.Drawing.Point(1012, 31);
            this.txtdlyear.Margin = new System.Windows.Forms.Padding(4);
            this.txtdlyear.MaxLength = 2;
            this.txtdlyear.Name = "txtdlyear";
            this.txtdlyear.Size = new System.Drawing.Size(85, 36);
            this.txtdlyear.TabIndex = 2;
            // 
            // txtMint
            // 
            this.txtMint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMint.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMint.Location = new System.Drawing.Point(649, 31);
            this.txtMint.Margin = new System.Windows.Forms.Padding(4);
            this.txtMint.MaxLength = 3;
            this.txtMint.Name = "txtMint";
            this.txtMint.Size = new System.Drawing.Size(97, 36);
            this.txtMint.TabIndex = 1;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(836, 35);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(181, 26);
            this.label40.TabIndex = 5;
            this.label40.Text = "坚持锻炼时间:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(758, 37);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(64, 26);
            this.label39.TabIndex = 4;
            this.label39.Text = "分钟";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(472, 35);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(181, 26);
            this.label38.TabIndex = 2;
            this.label38.Text = "每次锻炼时间:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(26, 35);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(129, 26);
            this.label37.TabIndex = 0;
            this.label37.Text = "锻炼频率:";
            // 
            // UCLifeStyle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.groupBox20);
            this.Controls.Add(this.groupBox19);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.groupBox16);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCLifeStyle";
            this.Load += new System.EventHandler(this.UCLifeStyle_Load);
            this.VisibleChanged += new System.EventHandler(this.UCLifeStyle_VisibleChanged);
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
            throw new NotImplementedException();
        }

        private void radweiJiu_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radyjieju_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radyjieju.Checked)
            {
                this.txtJieAage.ReadOnly = false;
            }
            else
            {
                this.txtJieAage.Clear();
                this.txtJieAage.ReadOnly = true;
            }
        }

        private void radzyHave_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radzyHave.Checked)
            {
                for (int i = 0; i < this.duwus.Count; i++)
                {
                    this.duwus[i].SetPanelEnabled(true);
                }
            }
        }

        private void radzyNoHave_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = this.radzyNoHave.Checked;
            this.txtzygz.Clear();
            this.txtzyyear.Clear();
            this.txtzygz.ReadOnly = flag;
            this.txtzyyear.ReadOnly = flag;
            for (int i = 0; i < this.duwus.Count; i++)
            {
                this.duwus[i].SetPanelEnabled(!flag);
            }
        }

        public bool SaveModelToDB()
        {
            if (this.LifeStyle == null)
            {
                return false;
            }
            if (PhysicalInfoFactory.ID == -1)
            {
                return true;
            }
            RecordsLifeStyleBLL recordsLifeStyleModel = new RecordsLifeStyleBLL();
            this.LifeStyle.OutKey = PhysicalInfoFactory.ID;
            if (!recordsLifeStyleModel.ExistsOutKey(this.LifeStyle.IDCardNo,PhysicalInfoFactory.ID))
            {
                recordsLifeStyleModel.Add(this.LifeStyle);
            }
            else
            {
                recordsLifeStyleModel.Update(this.LifeStyle);
            }
            return true;
        }

        public void SimpleBinding(ComboBox cb, object src, string member)
        {
            Binding binding = new Binding("SelectedValue", src, member, false, DataSourceUpdateMode.OnValidation) {
                DataSourceNullValue = string.Empty
            };
            cb.DataBindings.Add(binding);
        }

        private void SimpleBinding(TextBox tb, string member, bool formate)
        {
            Binding binding = new Binding("Text", this.LifeStyle, member, formate, DataSourceUpdateMode.OnPropertyChanged);
            if (formate)
            {
                binding.Parse += new ConvertEventHandler(this.bd_Parse);
            }
            else
            {
                binding.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
            tb.DataBindings.Add(binding);
        }
        private void Transdlfs() //锻炼方式
        {
            if (!string.IsNullOrEmpty(this.LifeStyle.ExerciseExistense))
            {
                string dlfs = this.LifeStyle.ExerciseExistense;
                char[] separator1 = new char[] { ',' };
                foreach (string str1 in dlfs.Split(separator1))
                {
                    int num;
                    if (int.TryParse(str1, out num))
                    {
                        this.dlfslist[num - 1].Checked = true;
                    }
                }
            }
        }
        private void TransHabit()
        {

            if (!string.IsNullOrEmpty(this.LifeStyle.DietaryHabit))
            {
                string eATHOBBY = this.LifeStyle.DietaryHabit;
                char[] separator = new char[] { ',' };
                foreach (string str2 in eATHOBBY.Split(separator))
                {
                    int num;
                    if (int.TryParse(str2, out num))
                    {
                        this.chBysxg.SetItemChecked(num - 1, true);
                    }
                }
            }
    
        }

        private void UCLifeStyle_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void UpdataToModel()
        {
            this.LifeStyle.IDCardNo = this.Model.IDCardNo;
            string str = "";
            string str1 = "";
            for (int i = 0; i < this.chBysxg.Items.Count; i++)
            {
                if (this.chBysxg.GetItemChecked(i))
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        str = str + string.Format(",{0}", i + 1);
                    }
                    else
                    {
                        str = str + string.Format("{0}", i + 1);
                    }
                }
            }
            for (int k = 0; k < this.dlfslist.Count; k++) //锻炼方式
            {
                if (this.dlfslist[k].Checked)
                {
                    if (!string.IsNullOrEmpty(str1))
                    {
                        str1 = str1 + string.Format(",{0}", k + 1);
                    }
                    else
                    {
                        str1 = str1 + string.Format("{0}", k + 1);
                    }
                }
            }
            this.LifeStyle.DietaryHabit = str;
            this.LifeStyle.ExerciseExistense = str1.Trim(new char[]{','});
            this.LifeStyle.DrinkType = this.wine.FinalResult;
            this.LifeStyle.DrinkTypeOther = this.wine.FinalResultEX;
            this.LifeStyle.IsDrinkForbiddon = !this.radweiJiu.Checked ? ((string) (!this.radyjieju.Checked ? null : "2")) : "1";
            this.LifeStyle.DrinkThisYear = !this.radYes.Checked ? ((string) (!this.radNo.Checked ? null : "2")) : "1";
            this.LifeStyle.CareerHarmFactorHistory = !this.radzyNoHave.Checked ? "2" : "1";
            this.LifeStyle.Dust = this.DuWuFC.TypeName;
            this.LifeStyle.DustProtect = this.DuWuFC.IsProject;
            this.LifeStyle.DustProtectEx = this.DuWuFC.ProtectMothed;
            this.LifeStyle.Radiogen = this.DuWuFSX.TypeName;
            this.LifeStyle.RadiogenProtect = this.DuWuFSX.IsProject;
            this.LifeStyle.RadiogenProtectEx = this.DuWuFSX.ProtectMothed;
            this.LifeStyle.Physical = this.DuWuWl.TypeName;
            this.LifeStyle.PhysicalProtect = this.DuWuWl.IsProject;
            this.LifeStyle.PhysicalProtectEx = this.DuWuWl.ProtectMothed;
            this.LifeStyle.Chem = this.DuWuHX.TypeName;
            this.LifeStyle.ChemProtect = this.DuWuHX.IsProject;
            this.LifeStyle.ChemProtectEx = this.DuWuHX.ProtectMothed;
            this.LifeStyle.Other = this.DuWuOther.TypeName;
            this.LifeStyle.OtherProtect = this.DuWuOther.IsProject;
            this.LifeStyle.OtherProtectEx = this.DuWuOther.ProtectMothed;
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsLifeStyleModel LifeStyle { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        private void ckbdlqt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbdlqt.Checked)
            {
                this.tbdlfsqt.ReadOnly = false;
            }
            else
            {
                this.tbdlfsqt.Clear();
                this.tbdlfsqt.ReadOnly = true;
            }
        }

        private void UCLifeStyle_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                if (this.cmbyinjiuzhuangkuang.SelectedValue != null)
                {
                    RecordsManageMentModel.DrinkRate = this.cmbyinjiuzhuangkuang.SelectedValue.ToString();
                }
                if (this.cmbxiyanzhuangkuang.SelectedValue != null)
                {
                    RecordsManageMentModel.SmokeCondition = this.cmbxiyanzhuangkuang.SelectedValue.ToString();
                }
                if (this.cmbduanlianpinlv.SelectedValue != null)
                {
                    RecordsManageMentModel.ExerciseRate = this.cmbduanlianpinlv.SelectedValue.ToString();
                }

                RecordsManageMentModel.ExerciseTimes = this.txtMint.Text.ToString();
                string str = "";
                for (int i = 0; i < this.chBysxg.Items.Count; i++)
                {
                    if (this.chBysxg.GetItemChecked(i))
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            str = str + string.Format(",{0}", i + 1);
                        }
                        else
                        {
                            str = str + string.Format("{0}", i + 1);
                        }
                    }
                }

                RecordsManageMentModel.DietaryHabit = str;
                if (this.radweiJiu.Checked)
                {
                    RecordsManageMentModel.IsDrinkForbiddon = "1";
                }
                else if (this.radyjieju.Checked)
                {
                    RecordsManageMentModel.IsDrinkForbiddon = "2";
                }
                else
                {
                    RecordsManageMentModel.IsDrinkForbiddon = "";
                }
            }
        }

        private void DuWuFC_Load(object sender, EventArgs e)
        {

        }
    }
}

