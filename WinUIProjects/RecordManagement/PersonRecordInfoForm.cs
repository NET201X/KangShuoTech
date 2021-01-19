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
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using FocusGroup.Kids;

    public class PersonRecordInfoForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private Button btnFind;
        private CheckBox c1;
        private CheckBox c2;
        private CheckBox c4;
        private CheckBox c5;
        private CheckBox c6;
        private CheckBox c7;
        private CheckBox c8;
        private CMoreChange canji;
        private ComboBox cbxRole;
        private CheckedListBox chcanjqk;
        private List<MyCheckBox> chkBoxs = new List<MyCheckBox>();
        private CheckedListBox chywgm;
        private CheckBox ckGroup1;
        private CheckBox ckGroup2;
        private CheckBox ckGroup3;
        private CheckBox ckGroup4;
        private CheckBox ckGroup5;
        private CheckBox ckGroup6;
        private CheckBox ckGroup7;
        private CheckBox ckGroup8;
        private CheckBox ckGroup9;
        private ComboBox cmbhf;
        private ComboBox cmbRH;
        private ComboBox cmbwhcd;
        private ComboBox cmbXieXin;
        private ComboBox cmbzy;
        private IContainer components;
        private CSingleItem disease;
        private DataTable dt_blood;
        private GroupBox gbBoxIdCard;
        private GroupBox groupBox45;
        private CMoreChange guomin;
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr>();
        private Label label1;
        private Label label172;
        private Label label174;
        private Label label180;
        private Label label181;
        private Label label182;
        private Label label183;
        private Label label184;
        private Label label185;
        private Label label186;
        private Label label187;
        private Label label188;
        private Label label189;
        private Label label190;
        private Label label191;
        private Label label192;
        private Label label193;
        private Label label2;
        private Label label211;
        private Label label238;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblBrith;
        private Label lblIdNo;
        private Label lblName;
        private Label lblSex;
        private Panel panel1;
        private Panel panel3;
        private Panel panel34;
        private List<CheckBox> payStyle;
        private RadioButton radczfhj;
        private RadioButton radczhj;
        private RadioButton radycbw;
        private RadioButton radycby;
        private List<ItemDictonaryModel<string>> ralation;
        private ManyCheckboxs<RecordsBaseInfoModel> renqun;
        private int state_is_onload;
        private TextBox tbEmail;
        private TextBox tbFamBossIDCARD;
        private TextBox tbFamBossName;
        private TextBox tbHomeAddr;
        private TextBox tbOther;
        private TextBox tbRelation;
        private SelectItemT<RecordsBaseInfoModel> theRelation;
        private ToolTip toolTip1;
        private TextBox txtbenrdh;
        private TextBox txtcanjqt;
        private TextBox txtgongzdw;
        private TextBox txtlianxrdh;
        private TextBox txtlianxrName;
        private TextBox txtycb;
        private TextBox txtywgmqt;
        private TextBox txtzerenyisheng;
        private ComboBox comboBox1;
        private CheckBox ckGroup10;
        private Button BtnAddChild;
        private TextBox tbCard3;
        private Label label12;
        private TextBox tbCard2;
        private Label label11;
        private TextBox tbCard1;
        private Label label10;
        private ComboBox cbZZQK;
        private Label label13;
        private TextBox tbFamilyStructure;
        private Label label16;
        private TextBox tbFamilyNum;
        private Label label15;
        private Panel panel2;
        private ComboBox cmbCC;
        private ComboBox cmbYC;
        private Label label18;
        private Label label17;
        private RadioButton rdYc5;
        private RadioButton rdYc4;
        private RadioButton rdYc3;
        private RadioButton rdYc2;
        private RadioButton rdYc1;
        private Label label14;
        private TextBox tbSx;
        private TextBox tbDw;
        private TextBox tbHxp;
        private CheckBox ckbls4;
        private CheckBox ckbls3;
        private CheckBox ckbls2;
        private CheckBox ckbls1;
        private CMoreIllness zhifu;
        private TextBox textBox1;
        private Panel panel4;
        private CheckBox ckGroup11;
        private CheckBox c3;
        private ManyCheckboxs<RecordsBaseInfoModel> baoloushi;

        public PersonRecordInfoForm()
        {
            this.InitializeComponent();
            this.payStyle = new List<CheckBox> { this.c1, this.c2, this.c3, this.c4, this.c5, this.c6, this.c7, this.c8 };
            this.chkBoxs.Add(new MyCheckBox(this.c1, "城镇职工基本医疗保险", "1"));
            this.chkBoxs.Add(new MyCheckBox(this.c2, "城镇居民基本医疗保险", "2"));
            this.chkBoxs.Add(new MyCheckBox(this.c3, "新型农村合作医疗", "3"));
            this.chkBoxs.Add(new MyCheckBox(this.c4, "贫困救助", "4"));
            this.chkBoxs.Add(new MyCheckBox(this.c5, "商业医疗保险", "5"));
            this.chkBoxs.Add(new MyCheckBox(this.c6, "全公费", "6"));
            this.chkBoxs.Add(new MyCheckBox(this.c7, "全自费", "7"));
            this.chkBoxs.Add(new MyCheckBox(this.c8, "其他", "8"));
            this.inputrange_str.Add(new InputRangeStr("HouseName", 0x20));
            this.inputrange_str.Add(new InputRangeStr("ContactName", 30));
            this.inputrange_str.Add(new InputRangeStr("WorkUnit", 200));
            this.inputrange_str.Add(new InputRangeStr("TownName", 200));
            this.inputrange_str.Add(new InputRangeStr("VillageName", 100));
            this.inputrange_str.Add(new InputRangeStr("OrgName", 100));
            this.inputrange_str.Add(new InputRangeStr("HouseRelation", 50));
            this.inputrange_str.Add(new InputRangeStr("MedicalPayTypeOther", 50));
            this.inputrange_str.Add(new InputRangeStr("Address", 50));
            this.SaveDataInfo = "";
            this.ralation = new List<ItemDictonaryModel<string>>();
            this.ralation.Add(new ItemDictonaryModel<string>("户主", "1"));
            this.ralation.Add(new ItemDictonaryModel<string>("配偶", "2"));
            this.ralation.Add(new ItemDictonaryModel<string>("父亲", "3"));
            this.ralation.Add(new ItemDictonaryModel<string>("母亲", "4"));
            this.ralation.Add(new ItemDictonaryModel<string>("兄弟", "5"));
            this.ralation.Add(new ItemDictonaryModel<string>("姐妹", "6"));
            this.ralation.Add(new ItemDictonaryModel<string>("儿子", "7"));
            this.ralation.Add(new ItemDictonaryModel<string>("女儿", "8"));
            this.ralation.Add(new ItemDictonaryModel<string>("儿媳", "9"));
            this.ralation.Add(new ItemDictonaryModel<string>("女婿", "10"));
            this.ralation.Add(new ItemDictonaryModel<string>("孙子", "11"));
            this.ralation.Add(new ItemDictonaryModel<string>("孙女", "12"));
            this.ralation.Add(new ItemDictonaryModel<string>("外孙", "13"));
            this.ralation.Add(new ItemDictonaryModel<string>("外孙女", "14"));
            this.ralation.Add(new ItemDictonaryModel<string>("其他", "15"));
            this.cbxRole.DisplayMember = "DISPLAYMEMBER";
            this.cbxRole.ValueMember = "VALUEMEMBER";
            this.cbxRole.DataSource = this.ralation;
            this.EveryThingIsOk = false;
        }

        private bool archive_illnessoper(RecordsIllnessHistoryInfoBLL oper, List<RecordsIllnessHistoryInfoModel> items)
        {
            bool flag = true;
            if (items == null)
            {
                return false;
            }
            foreach (RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel in items)
            {
                recordsIllnessHistoryInfoModel.RecordID = this.Model.RecordID;
                recordsIllnessHistoryInfoModel.IDCardNo = this.Model.IDCardNo;

                if (recordsIllnessHistoryInfoModel.RecordState == RecordsStateModel.AddToDB)
                {
                    if (oper.Add(recordsIllnessHistoryInfoModel) <= 0)
                    {
                        PersonRecordInfoForm info = this;
                        string str = info.SaveDataInfo + string.Format("疾病: IllnessType:{0} IllnessName:{1},新增失败！\r\n ", recordsIllnessHistoryInfoModel.IllnessType, recordsIllnessHistoryInfoModel.IllnessName);
                        info.SaveDataInfo = str;
                        flag = false;
                    }
                }
                else if (recordsIllnessHistoryInfoModel.RecordState == RecordsStateModel.DeleteInDB)
                {
                    if (!oper.Delete(recordsIllnessHistoryInfoModel.ID))
                    {
                        PersonRecordInfoForm info2 = this;
                        string str2 = info2.SaveDataInfo + string.Format("疾病: IllnessType:{0} IllnessName:{1},删除失败！\r\n ", recordsIllnessHistoryInfoModel.IllnessType, recordsIllnessHistoryInfoModel.IllnessName);
                        info2.SaveDataInfo = str2;
                        flag = false;
                    }
                }
                else if ((recordsIllnessHistoryInfoModel.RecordState == RecordsStateModel.UpdateInDB) && !oper.Update(recordsIllnessHistoryInfoModel))
                {
                    PersonRecordInfoForm info3 = this;
                    string str3 = info3.SaveDataInfo + string.Format("疾病: IllnessType:{0} IllnessName:{1},更新失败！\r\n ", recordsIllnessHistoryInfoModel.IllnessType, recordsIllnessHistoryInfoModel.IllnessName);
                    info3.SaveDataInfo = str3;
                    flag = false;
                }
            }
            return flag;
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

        private void btnFind_broke_Click(object sender, EventArgs e)
        {
            if (this.Model.HouseRelation == "1")
            {
                if (MessageBox.Show("当前人员为户主且有相应的家庭档案信息，是否删除现家庭档案？\r\n（注意：这样将会删除现家庭档案的所有信息和家庭中所有对应的人员关系!）", "家庭档案", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    RecordsBaseInfoBLL recordsBaseInfoBll = new RecordsBaseInfoBLL();
                    foreach (RecordsBaseInfoModel recordsBaseInfoModel in recordsBaseInfoBll.GetModelList(string.Format(" and FamilyIDCardNo = '{0}' ", this.Model.FamilyIDCardNo)))
                    {
                        recordsBaseInfoModel.FamilyIDCardNo = null;
                        recordsBaseInfoModel.HouseRelation = null;
                        recordsBaseInfoModel.HouseRealOther = null;
                        recordsBaseInfoBll.Update(recordsBaseInfoModel);
                    }
                    RecordsFamilyInfoBLL recordsFamilyInfoBll = new RecordsFamilyInfoBLL();
                    RecordsFamilyInfoModel model = recordsFamilyInfoBll.GetModel(this.Model.IDCardNo);
                    if (model != null)
                    {
                        recordsFamilyInfoBll.Delete(model.ID);
                    }
                    this.tbRelation.Text = "";
                    this.tbFamBossIDCARD.Text = "";
                    this.tbFamBossName.Text = "";
                    this.cbxRole.SelectedIndex = -1;
                    this.btnFind.Text = "与家庭关联";
                    //this.cbxRole.Enabled = false;
                    this.cbZZQK.SelectedIndex = -1;
                    //this.cbZZQK.Enabled = false;
                    this.tbFamilyNum.Clear();
                    this.tbFamilyStructure.Text = "";
                }
            }
            else if (MessageBox.Show("是否移除家庭关联和成员角色？", "家庭档案", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.tbRelation.Text = "";
                this.tbFamBossIDCARD.Text = "";
                this.tbFamBossName.Text = "";
                this.cbxRole.SelectedIndex = -1;
                this.btnFind.Text = "与家庭关联";
                //this.cbxRole.Enabled = false;
                this.cbZZQK.SelectedIndex = -1;
                //this.cbZZQK.Enabled = false;
                this.tbFamilyNum.Clear();
                this.tbFamilyStructure.Text = "";
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (this.btnFind.Text == "解除与家庭关联")
            {
                this.btnFind_broke_Click(sender, e);
            }
            else if (this.btnFind.Text == "与家庭关联")
            {
                this.btnFind_revence_Click(sender, e);
            }
        }

        private void btnFind_revence_Click(object sender, EventArgs e)
        {
            HomeQueryForm family = new HomeQueryForm
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterParent,
                Model = this.Model
            };
            if (family.ShowDialog() == DialogResult.OK)
            {
                this.tbFamBossIDCARD.DataBindings[0].ReadValue();
                this.tbFamBossName.DataBindings[0].ReadValue();
                this.cbxRole.DataBindings[0].ReadValue();
                int index = this.ralation.FindIndex(hz => hz.VALUEMEMBER == "1");
                if (index >= 0)
                {
                    this.ralation.RemoveAt(index);
                }
                this.cbxRole.DataSource = null;
                this.cbxRole.DisplayMember = "DISPLAYMEMBER";
                this.cbxRole.ValueMember = "VALUEMEMBER";
                this.cbxRole.DataSource = this.ralation;
                //this.cbxRole.Enabled = true;
                //this.cbZZQK.Enabled = true;
                this.btnFind.Text = "解除与家庭关联";
            }
        }

        private void c8_CheckedChanged(object sender, EventArgs e)
        {
            if (this.c8.Checked)
            {
                this.tbOther.ReadOnly = false;
            }
            else
            {
                this.tbOther.Text = "";
                this.tbOther.ReadOnly = true;
            }
        }

        private void cbxRole_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        public ChildFormStatus CheckErrorInput()
        {
            bool flag = !(this.txtlianxrdh.BackColor == Color.WhiteSmoke) || !(this.txtbenrdh.BackColor == Color.WhiteSmoke);
            bool flag2 = !(this.tbEmail.BackColor == Color.WhiteSmoke) || !(this.txtbenrdh.BackColor == Color.WhiteSmoke);
            bool flag3 = this.inputrange_str.Count<InputRangeStr>(c => c.ErrorInput) > 0;
            bool errorInput = this.disease.ErrorInput;
            bool flag5 = this.zhifu.ErrorInput;
            bool flag6 = this.guomin.ErrorInput;
            bool flag7 = false;
            if ((!string.IsNullOrWhiteSpace(this.Model.FamilyIDCardNo) && (this.Model.FamilyIDCardNo != this.Model.IDCardNo)) && (this.cbxRole.Text == "户主"))
            {
                flag7 = true;
                this.SaveDataInfo = "不能将当前人员设定为户主!\r\n";
            }
            if (((!flag && !flag3) && (!errorInput && !flag5)) && ((!flag6 && !flag2) && !flag7))
            {
                return ChildFormStatus.NoErrorInput;
            }
            return ChildFormStatus.HasErrorInput;
        }

        private RecordsBaseInfoModel DeepCopy(RecordsBaseInfoModel mo)
        {
            MemoryStream serializationStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream, mo);
            serializationStream.Position = 0L;
            return (RecordsBaseInfoModel)formatter.Deserialize(serializationStream);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void PersonRecordInfoForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void PersonRecordInfoForm_VisibleChanged(object sender, EventArgs e)
        {
        }

        public void InitEveryThing()
        {
            this.dt_blood = new DataTable();
            this.dt_blood.Columns.Add("Name", typeof(string));
            this.dt_blood.Columns.Add("Value", typeof(string));
            this.dt_blood.Rows.Add(new object[] { "A型", "1" });
            this.dt_blood.Rows.Add(new object[] { "B型", "2" });
            this.dt_blood.Rows.Add(new object[] { "O型", "3" });
            this.dt_blood.Rows.Add(new object[] { "AB型", "4" });

            this.cmbXieXin.DisplayMember = "Name";
            this.cmbXieXin.ValueMember = "Value";
            this.cmbXieXin.DataSource = this.dt_blood;
            this.cmbXieXin.SelectedValue = "";
            this.cmbRH.SelectedIndex = -1;

            DataTable dtNation = new DataTable();

            dtNation.Columns.Add("Name", typeof(string));
            dtNation.Columns.Add("Value", typeof(string));
            dtNation.Rows.Add(new object[] { "汉族", "01" });
            dtNation.Rows.Add(new object[] { "蒙古族", "02" });
            dtNation.Rows.Add(new object[] { "回族", "03" });
            dtNation.Rows.Add(new object[] { "藏族", "04" });
            dtNation.Rows.Add(new object[] { "维吾尔族", "05" });
            dtNation.Rows.Add(new object[] { "苗族", "06" });
            dtNation.Rows.Add(new object[] { "彝族", "07" });
            dtNation.Rows.Add(new object[] { "壮族", "08" });
            dtNation.Rows.Add(new object[] { "布依族", "09" });
            dtNation.Rows.Add(new object[] { "朝鲜族", "10" });
            dtNation.Rows.Add(new object[] { "满族", "11" });
            dtNation.Rows.Add(new object[] { "侗族", "12" });
            dtNation.Rows.Add(new object[] { "瑶族", "13" });
            dtNation.Rows.Add(new object[] { "白族", "14" });
            dtNation.Rows.Add(new object[] { "土家族", "15" });
            dtNation.Rows.Add(new object[] { "哈尼族", "16" });
            dtNation.Rows.Add(new object[] { "哈萨克族", "17" });
            dtNation.Rows.Add(new object[] { "傣族", "18" });
            dtNation.Rows.Add(new object[] { "黎族", "19" });
            dtNation.Rows.Add(new object[] { "傈傈族", "20" });
            dtNation.Rows.Add(new object[] { "佤族", "21" });
            dtNation.Rows.Add(new object[] { "畲族", "22" });
            dtNation.Rows.Add(new object[] { "高山族", "23" });
            dtNation.Rows.Add(new object[] { "拉祜族", "24" });
            dtNation.Rows.Add(new object[] { "水族", "25" });
            dtNation.Rows.Add(new object[] { "东乡族", "26" });
            dtNation.Rows.Add(new object[] { "纳西族", "27" });
            dtNation.Rows.Add(new object[] { "景颇族", "28" });
            dtNation.Rows.Add(new object[] { "柯尔克孜族", "29" });
            dtNation.Rows.Add(new object[] { "土族", "30" });
            dtNation.Rows.Add(new object[] { "达斡尔族", "31" });
            dtNation.Rows.Add(new object[] { "仫佬族", "32" });
            dtNation.Rows.Add(new object[] { "羌族", "33" });
            dtNation.Rows.Add(new object[] { "布朗族", "34" });
            dtNation.Rows.Add(new object[] { "撒拉族", "35" });
            dtNation.Rows.Add(new object[] { "毛难族", "36" });
            dtNation.Rows.Add(new object[] { "仡佬族", "37" });
            dtNation.Rows.Add(new object[] { "锡伯族", "38" });
            dtNation.Rows.Add(new object[] { "阿昌族", "39" });
            dtNation.Rows.Add(new object[] { "普米族", "40" });
            dtNation.Rows.Add(new object[] { "塔吉克族", "41" });
            dtNation.Rows.Add(new object[] { "怒族", "42" });
            dtNation.Rows.Add(new object[] { "乌孜别克族", "43" });
            dtNation.Rows.Add(new object[] { "俄罗斯族", "44" });
            dtNation.Rows.Add(new object[] { "鄂温克族", "45" });
            dtNation.Rows.Add(new object[] { "崩龙族", "46" });
            dtNation.Rows.Add(new object[] { "保安族", "47" });
            dtNation.Rows.Add(new object[] { "裕固族", "48" });
            dtNation.Rows.Add(new object[] { "京族", "49" });
            dtNation.Rows.Add(new object[] { "塔塔尔族", "50" });
            dtNation.Rows.Add(new object[] { "独龙族", "51" });
            dtNation.Rows.Add(new object[] { "鄂伦春族", "52" });
            dtNation.Rows.Add(new object[] { "赫哲族", "53" });
            dtNation.Rows.Add(new object[] { "门巴族", "54" });
            dtNation.Rows.Add(new object[] { "珞巴族", "55" });
            dtNation.Rows.Add(new object[] { "基诺族", "56" });
            dtNation.Rows.Add(new object[] { "其他", "57" });
            dtNation.Rows.Add(new object[] { "外国血统", "58" });

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Value";
            comboBox1.DataSource = dtNation;

            //默认项设置
            this.PresetValue();
            this.renqun = new ManyCheckboxs<RecordsBaseInfoModel>(this.Model);
            LoneCheckbox it = new LoneCheckbox(this.ckGroup1, true);
            LoneCheckbox checkbox2 = new LoneCheckbox(this.ckGroup2);
            LoneCheckbox checkbox3 = new LoneCheckbox(this.ckGroup3);
            LoneCheckbox checkbox4 = new LoneCheckbox(this.ckGroup4);

            checkbox2.AddEnemyRange(new LoneCheckbox[] { it, checkbox3, checkbox4 });
            checkbox3.AddEnemyRange(new LoneCheckbox[] { it, checkbox2, checkbox4 });
            checkbox4.AddEnemyRange(new LoneCheckbox[] { it, checkbox2, checkbox3 });

            this.renqun.AddCk(it);
            this.renqun.AddCk(checkbox2);
            this.renqun.AddCk(checkbox3);
            this.renqun.AddCk(checkbox4);
            this.ckGroup11.Visible = false;

            this.renqun.AddCk(new CheckBox[] { this.ckGroup5, this.ckGroup6, this.ckGroup7, this.ckGroup8, this.ckGroup9, this.ckGroup10 });
            this.renqun.BindingProperty("PopulationType", "");

            if (this.Model.Sex == "1")
            {
                checkbox3.CouldIt = false;
            }
            int num = DateTime.Today.Year - this.Model.Birthday.Value.Year;
            if (num > 6)
            {
                checkbox2.CouldIt = false;
            }
            if (num < 60)
            {
                checkbox4.CouldIt = false;
            }
            this.SimpleBinding(this.tbEmail, "Email");
            CSingleItem item = new CSingleItem
            {
                Name = "遗传病史",
                Usual = this.radycbw,
                Unusual = this.radycby,
                Info = this.txtycb,
                StrUsual = "1",
                StrUnusual = "2",
                MaxBytesCount = 200
            };
            this.disease = item;
            this.disease.Choose = this.Model.Disease;
            this.disease.Choose_EX = this.Model.DiseaseEx;


            CMoreIllness illness = new CMoreIllness
            {
                otherText = "其他",
                TbOther = this.tbOther,
                list_ckx = this.payStyle,
                MaxBytesCount = 50
            };
            this.zhifu = illness;
            this.zhifu.TransInfo(this.Model.MedicalPayType, this.Model.MedicalPayTypeOther);
            CMoreChange change = new CMoreChange
            {
                Name = "过敏",
                MoreChange = this.chywgm,
                Unusual = "无",
                Other = this.txtywgmqt,
                MaxBytesCount = 200
            };
            this.guomin = change;
            this.guomin.TransInfo(this.Model.DrugAllergic, this.Model.DrugAllergicOther);
            this.baoloushi = new ManyCheckboxs<RecordsBaseInfoModel>(this.Model);
            this.baoloushi.AddCk(this.ckbls1, true);
            this.baoloushi.AddCk(this.ckbls2, this.tbHxp);
            this.baoloushi.AddCk(this.ckbls3, this.tbDw);
            this.baoloushi.AddCk(this.ckbls4, this.tbSx);
            this.baoloushi.BindingProperty("Exposure", "");
            this.tbHxp.DataBindings.Add("Text", this.Model, "Chemical", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbDw.DataBindings.Add("Text", this.Model, "Poison", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbSx.DataBindings.Add("Text", this.Model, "Radial", false, DataSourceUpdateMode.OnPropertyChanged);

            this.lblIdNo.DataBindings.Add("Text", this.Model, "IDCardNo", false, DataSourceUpdateMode.OnPropertyChanged);
            this.lblName.DataBindings.Add("Text", this.Model, "CustomerName", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox1.DataBindings.Add("Text", this.Model, "IDCardNo", false, DataSourceUpdateMode.OnPropertyChanged);

            if (this.Model.Sex == "1")
            {
                this.lblSex.Text = "男";
            }
            else if (this.Model.Sex == "2")
            {
                this.lblSex.Text = "女";
                if (this.Model.PopulationType != "2")
                {
                    BtnAddChild.Visible = true;
                }
            }
            else
            {
                int id = int.Parse(Model.IDCardNo.Substring(Model.IDCardNo.Length - 2, 1));

                if (id % 2 == 0)
                {
                    this.lblSex.Text = "女";
                }
                else
                {
                    this.lblSex.Text = "男";
                }
            }

            if (this.Model.Nation == "1")
            {
                //this.lblFlok.Text = "汉族";
                comboBox1.SelectedValue = "01";
            }
            else if (this.Model.Nation == "2")
            {
                //this.lblFlok.Text = this.Model.Minority;
                comboBox1.SelectedValue = GetNation(Model.Minority);
            }

            this.txtzerenyisheng.Text = this.Model.Doctor;
            this.SimpleBinding(this.tbHomeAddr, "HouseHoldAddress");
            if (this.Model.Birthday.HasValue)
            {
                this.lblBrith.Text = this.Model.Birthday.Value.ToShortDateString();
            }
            this.SimpleBinding(this.tbFamBossName, "HouseName");
            this.SimpleBinding(this.tbFamBossIDCARD, "FamilyIDCardNo");
            if (!string.IsNullOrEmpty(this.Model.FamilyIDCardNo))
            {
                this.btnFind.Text = "解除与家庭关联";
                //if (this.Model.HouseRelation == "1")
                //{
                //    this.cbxRole.Enabled = false;
                //}
            }
            else
            {
                //this.cbxRole.Enabled = false;
                //this.cbZZQK.Enabled = false;
            }
            SelectItemT<RecordsBaseInfoModel> mt = new SelectItemT<RecordsBaseInfoModel>(this.Model)
            {
                CmbSelect = this.cbxRole,
                Info = this.tbRelation,
                MaxBytesCount = 20
            };
            this.theRelation = mt;
            this.theRelation.BindProperty("HouseRelation", string.Empty, "HouseRealOther");
            if (string.IsNullOrEmpty(this.Model.WorkUnit))
            {
                this.Model.WorkUnit = ConfigHelper.GetNode("VillageName");
            }
            this.SimpleBinding(this.txtgongzdw, "WorkUnit");
            this.SimpleBinding(this.tbCard1, "TownMedicalCard");
            this.SimpleBinding(this.tbCard2, "ResidentMedicalCard");
            this.SimpleBinding(this.tbCard3, "PovertyReliefMedicalCard");
            this.SimpleBinding(this.tbFamilyStructure, "FamilyStructure");
            if (this.Model.FamilyNum.HasValue)
            {
                this.tbFamilyNum.Text = this.Model.FamilyNum.ToString();
            }

            this.txtbenrdh.DataBindings.Add("Text", this.Model, "Phone", false, DataSourceUpdateMode.OnPropertyChanged);
            this.SimpleBinding(this.txtlianxrName, "ContactName");

            if (string.IsNullOrEmpty(this.Model.ContactPhone))
            {
                this.Model.ContactPhone = this.Model.Phone;
            }
            this.txtlianxrdh.DataBindings.Add("Text", this.Model, "ContactPhone", false, DataSourceUpdateMode.OnPropertyChanged);

            if (this.Model.LiveType == "2")
            {
                this.radczfhj.Checked = true;
            }
            else if (this.Model.LiveType == "1")
            {
                this.radczhj.Checked = true;
            }
            if (!string.IsNullOrEmpty(this.Model.BloodType) && this.Model.BloodType != "5")
            {
                this.cmbXieXin.SelectedValue = this.Model.BloodType;
            }
            if (!string.IsNullOrEmpty(this.Model.RH))
            {
                this.cmbRH.SelectedIndex = int.Parse(this.Model.RH) - 1;
            }
            if (!string.IsNullOrEmpty(this.Model.Culture) && this.Model.Culture != "10")
            {
                this.cmbwhcd.SelectedIndex = int.Parse(this.Model.Culture) - 1;
            }
            if (!string.IsNullOrEmpty(this.Model.Job))
            {
                this.cmbzy.SelectedIndex = int.Parse(this.Model.Job) - 1;
            }
            if (!string.IsNullOrEmpty(this.Model.MaritalStatus))
            {
                this.cmbhf.SelectedIndex = int.Parse(this.Model.MaritalStatus) - 1;
            }
            if (!string.IsNullOrEmpty(this.Model.LiveCondition))
            {
                this.cbZZQK.SelectedIndex = int.Parse(this.Model.LiveCondition) - 1;
            }

            CMoreChange change3 = new CMoreChange
            {
                Name = "残疾情况",
                MoreChange = this.chcanjqk,
                Unusual = "无残疾",
                Other = this.txtcanjqt,
                MaxBytesCount = 200
            };
            this.canji = change3;
            this.canji.TransInfo(this.Model.DiseasEndition, this.Model.DiseasEnditionEx);
            this.cmbYC.DataBindings.Add("Text", this.Model, "PreNum", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cmbCC.DataBindings.Add("Text", this.Model, "YieldNum", false, DataSourceUpdateMode.OnPropertyChanged);
            if (!string.IsNullOrEmpty(this.Model.PreSituation))
            {
                switch (this.Model.PreSituation)
                {
                    case "1":
                        this.rdYc1.Checked = true;
                        break;
                    case "2":
                        this.rdYc2.Checked = true;
                        break;
                    case "3":
                        this.rdYc3.Checked = true;
                        break;
                    case "4":
                        this.rdYc4.Checked = true;
                        break;
                    case "5":
                        this.rdYc5.Checked = true;
                        break;
                    default:
                        break;
                }
            }

            if (this.Model.PopulationType.Contains("3"))
            {
                this.panel2.Enabled = true;
            }
            else
            {
                this.panel2.Enabled = false;
                this.rdYc1.Checked = false;
                this.rdYc2.Checked = false;
                this.rdYc3.Checked = false;
                this.rdYc4.Checked = false;
                this.rdYc5.Checked = false;
                this.cmbYC.SelectedIndex = -1;
                this.cmbCC.SelectedIndex = -1;
            }
            this.ModelCopy = this.DeepCopy(this.Model);
            MustChoose();
            this.EveryThingIsOk = true;
        }

        private void PresetValue()
        {
            DataSet dsre = new DataSet();
            dsre = new RequireBLL().GetList("TabName = '个人档案' and Comment = '详细信息' and IsSetValue='是' ");
            DataTable dt = dsre.Tables[0];

            foreach (DataRow item in dt.Rows)
            {
                string str = item["ChinName"].ToString();
                switch (str)
                {
                    case "联系人姓名":
                        if (string.IsNullOrEmpty(this.Model.ContactName))
                            this.Model.ContactName = item["ItemValue"].ToString();
                        break;
                    case "联系人电话":
                        if (string.IsNullOrEmpty(this.Model.ContactPhone))
                            this.Model.ContactPhone = item["ItemValue"].ToString();
                        break;
                    case "遗传病史":
                        if (string.IsNullOrEmpty(this.Model.Disease))
                            this.Model.Disease = item["ItemValue"].ToString();
                        break;
                    case "工作单位":
                        if (string.IsNullOrEmpty(this.Model.WorkUnit))
                            this.Model.WorkUnit = item["ItemValue"].ToString();
                        break;
                    case "常住类型":
                        if (string.IsNullOrEmpty(this.Model.LiveType))
                            this.Model.LiveType = item["ItemValue"].ToString();
                        break;
                    case "RH阴性":
                        if (string.IsNullOrEmpty(this.Model.RH))
                            this.Model.RH = item["ItemValue"].ToString();
                        break;
                    case "血型":
                        if (string.IsNullOrEmpty(this.Model.BloodType))
                            this.Model.BloodType = item["ItemValue"].ToString();
                        break;
                    case "支付方式":
                        if (string.IsNullOrEmpty(this.Model.MedicalPayType))
                            this.Model.MedicalPayType = item["ItemValue"].ToString();
                        break;
                    case "暴露史":
                        if (string.IsNullOrEmpty(this.Model.Exposure))
                            this.Model.Exposure = item["ItemValue"].ToString();
                        break;
                    case "民族":
                        if (string.IsNullOrEmpty(this.Model.Nation))
                        {
                            if (!string.IsNullOrEmpty(item["SetValue"].ToString()))
                            {
                                this.Model.Minority = item["SetValue"].ToString();
                                if (item["SetValue"].ToString() == "汉族")
                                {
                                    this.Model.Nation = "1";
                                }
                                else
                                {
                                    this.Model.Nation = "2";
                                }
                            }
                        }
                        break;
                    case "药物过敏史":
                        if (string.IsNullOrEmpty(this.Model.DrugAllergic))
                            this.Model.DrugAllergic = item["ItemValue"].ToString();
                        break;
                    case "残疾情况":
                        if (string.IsNullOrEmpty(this.Model.DiseasEndition))
                            this.Model.DiseasEndition = item["ItemValue"].ToString();
                        break;
                    case "邮箱":
                        if (string.IsNullOrEmpty(this.Model.Email))
                            this.Model.Email = item["ItemValue"].ToString();
                        break;
                    case "文化程度":
                        if (string.IsNullOrEmpty(this.Model.Culture))
                            this.Model.Culture = item["ItemValue"].ToString();
                        break;
                    case "职业":
                        if (string.IsNullOrEmpty(this.Model.Job))
                            this.Model.Job = item["ItemValue"].ToString();
                        break;
                    case "婚姻情况":
                        if (string.IsNullOrEmpty(this.Model.MaritalStatus))
                            this.Model.MaritalStatus = item["ItemValue"].ToString();
                        break;
                    case "本人电话":
                        if (string.IsNullOrEmpty(this.Model.Phone))
                            this.Model.Phone = item["ItemValue"].ToString();
                        break;
                    case "户籍住址":
                        if (string.IsNullOrEmpty(this.Model.HouseHoldAddress))
                            this.Model.HouseHoldAddress = item["ItemValue"].ToString();
                        break;
                    case "人群分类":
                        if (string.IsNullOrEmpty(this.Model.PopulationType))
                            this.Model.PopulationType = item["ItemValue"].ToString();
                        break;
                    case "户主姓名":
                        if (string.IsNullOrEmpty(this.Model.CustomerName))
                            this.Model.CustomerName = item["ItemValue"].ToString();
                        break;
                    case "户主身份证号":
                        if (string.IsNullOrEmpty(this.Model.FamilyIDCardNo))
                            this.Model.FamilyIDCardNo = item["ItemValue"].ToString();
                        break;
                    case "家庭人口数":
                        if (this.Model.FamilyNum.HasValue)
                            this.Model.FamilyNum = new decimal?(decimal.Parse(item["ItemValue"].ToString()));
                        break;
                    case "居住情况":
                        if (string.IsNullOrEmpty(this.Model.LiveCondition))
                            this.Model.LiveCondition = item["ItemValue"].ToString();
                        break;
                    case "与户主关系":
                        if (string.IsNullOrEmpty(this.Model.HouseRelation))
                            this.Model.HouseRelation = item["ItemValue"].ToString();
                        break;
                    case "家庭结构":
                        if (string.IsNullOrEmpty(this.Model.FamilyStructure))
                            this.Model.FamilyStructure = item["ItemValue"].ToString();
                        break;
                    case "孕产情况":
                        if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("3") && string.IsNullOrEmpty(this.Model.PreSituation))
                            this.Model.PreSituation = item["ItemValue"].ToString();
                        break;
                    case "孕次":
                        if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("3") && string.IsNullOrEmpty(this.Model.PreNum))
                            this.Model.PreNum = item["ItemValue"].ToString();
                        break;
                    case "产次":
                        if (!string.IsNullOrEmpty(this.Model.PopulationType) && this.Model.PopulationType.Contains("3") && string.IsNullOrEmpty(this.Model.YieldNum))
                            this.Model.YieldNum = item["ItemValue"].ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void MustChoose()
        {
            DataSet dsrequire = new DataSet();
            dsrequire = new RequireBLL().GetList("TabName = '个人档案' and Comment = '详细信息' ");
            RecordsBaseInfoModel Models = new RecordsBaseInfoBLL().GetModel(Model.IDCardNo.ToString());
            DataTable dt = dsrequire.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                if (item["Isrequired"].ToString() == "1")
                {
                    switch (item["ChinName"].ToString())
                    {
                        case "联系人姓名":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.ContactName)))
                            {
                                this.label183.Text = "*联系人姓名:";
                                this.label183.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label183.Text = "联系人姓名:";
                                this.label183.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "联系人电话":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.ContactPhone)))
                            {
                                this.label184.Text = "*联系人电话:";
                                this.label184.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label184.Text = "联系人电话:";
                                this.label184.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "遗传病史":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.Disease)))
                            {
                                this.label193.Text = "*遗传病史:";
                                this.label193.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label193.Text = "遗传病史:";
                                this.label193.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "支付方式":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.MedicalPayType)))
                            {
                                this.label191.Text = "*支付方式:";
                                this.label191.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label191.Text = "支付方式:";
                                this.label191.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "药物过敏史":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.DrugAllergic)))
                            {
                                this.label192.Text = "*药物过敏史:";
                                this.label192.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label192.Text = "药物过敏史:";
                                this.label192.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "暴露史":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.Exposure)))
                            {
                                this.label7.Text = "*暴露史:";
                                this.label7.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label7.Text = "暴露史:";
                                this.label7.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "残疾情况":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.DiseasEndition)))
                            {
                                this.label211.Text = "*残疾情况:";
                                this.label211.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label211.Text = "残疾情况:";
                                this.label211.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "户主姓名":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.HouseName)))
                            {
                                this.label172.Text = "*户主姓名:";
                                this.label172.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label172.Text = "户主姓名:";
                                this.label172.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "户主身份证号":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.FamilyIDCardNo)))
                            {
                                this.label174.Text = "*身份证号:";
                                this.label174.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label174.Text = "身份证号:";
                                this.label174.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "家庭人口数":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.FamilyNum)))
                            {
                                this.label15.Text = "*家庭人口数:";
                                this.label15.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label15.Text = "家庭人口数:";
                                this.label15.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "居住情况":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.LiveCondition)))
                            {
                                this.label13.Text = "*居住情况:";
                                this.label13.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label13.Text = "居住情况:";
                                this.label13.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "与户主关系":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.HouseRelation)))
                            {
                                this.label180.Text = "*与户主关系:";
                                this.label180.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label180.Text = "与户主关系:";
                                this.label180.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "家庭结构":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.FamilyStructure)))
                            {
                                this.label16.Text = "*家庭结构:";
                                this.label16.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label16.Text = "家庭结构:";
                                this.label16.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "民族":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.Nation)))
                            {
                                this.label3.Text = "*民族:";
                                this.label3.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label3.Text = "民族:";
                                this.label3.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "户籍住址":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.HouseHoldAddress)))
                            {
                                this.label6.Text = "*户籍住址:";
                                this.label6.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label6.Text = "户籍住址:";
                                this.label6.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "工作单位":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.WorkUnit)))
                            {
                                this.label181.Text = "*工作单位:";
                                this.label181.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label181.Text = "工作单位:";
                                this.label181.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "本人电话":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.Phone)))
                            {
                                this.label182.Text = "*本人电话:";
                                this.label182.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label182.Text = "本人电话:";
                                this.label182.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "常住类型":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.LiveType)))
                            {
                                this.label185.Text = "*常住类型:";
                                this.label185.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label185.Text = "常住类型:";
                                this.label185.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "血型":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.BloodType)))
                            {
                                this.label187.Text = "*血　　型:";
                                this.label187.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label187.Text = "血　　型:";
                                this.label187.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "RH阴性":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.RH)))
                            {
                                this.label186.Text = "*RH　阴性:";
                                this.label186.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label186.Text = "RH　阴性:";
                                this.label186.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "文化程度":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.Culture)))
                            {
                                this.label188.Text = "*文化程度:";
                                this.label188.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label188.Text = "文化程度:";
                                this.label188.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "职业":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.Job)))
                            {
                                this.label189.Text = "*职　　业:";
                                this.label189.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label189.Text = "职　　业:";
                                this.label189.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "婚姻情况":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.MaritalStatus)))
                            {
                                this.label190.Text = "*婚姻情况:";
                                this.label190.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label190.Text = "婚姻情况:";
                                this.label190.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "邮箱":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.Email)))
                            {
                                this.label9.Text = "*邮箱:";
                                this.label9.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label9.Text = "邮箱:";
                                this.label9.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "人群分类":
                            if (string.IsNullOrEmpty(Convert.ToString(Models.PopulationType)))
                            {
                                this.label8.Text = "*人群分类:";
                                this.label8.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label8.Text = "人群分类:";
                                this.label8.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "孕产情况":
                            if (!string.IsNullOrEmpty(Models.PopulationType) && Models.PopulationType.Contains("3") && string.IsNullOrEmpty(Convert.ToString(Models.PreSituation)))
                            {
                                this.label14.Text = "*孕产情况:";
                                this.label14.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label14.Text = "孕产情况:";
                                this.label14.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "孕次":
                            if (!string.IsNullOrEmpty(Models.PopulationType) && Models.PopulationType.Contains("3") && string.IsNullOrEmpty(Convert.ToString(Models.PreNum)))
                            {
                                this.label17.Text = "*孕次:";
                                this.label17.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label17.Text = "孕次:";
                                this.label17.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        case "产次":
                            if (!string.IsNullOrEmpty(Models.PopulationType) && Models.PopulationType.Contains("3") && string.IsNullOrEmpty(Convert.ToString(Models.YieldNum)))
                            {
                                this.label18.Text = "*产次:";
                                this.label18.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                this.label18.Text = "产次:";
                                this.label18.ForeColor = System.Drawing.Color.Black;
                            }
                            break;
                        default: break;
                    }
                }
            }

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbBoxIdCard = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbSx = new System.Windows.Forms.TextBox();
            this.tbDw = new System.Windows.Forms.TextBox();
            this.tbHxp = new System.Windows.Forms.TextBox();
            this.ckbls4 = new System.Windows.Forms.CheckBox();
            this.ckbls3 = new System.Windows.Forms.CheckBox();
            this.ckbls2 = new System.Windows.Forms.CheckBox();
            this.ckbls1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckGroup11 = new System.Windows.Forms.CheckBox();
            this.ckGroup10 = new System.Windows.Forms.CheckBox();
            this.ckGroup9 = new System.Windows.Forms.CheckBox();
            this.ckGroup8 = new System.Windows.Forms.CheckBox();
            this.ckGroup7 = new System.Windows.Forms.CheckBox();
            this.ckGroup6 = new System.Windows.Forms.CheckBox();
            this.ckGroup5 = new System.Windows.Forms.CheckBox();
            this.ckGroup4 = new System.Windows.Forms.CheckBox();
            this.ckGroup3 = new System.Windows.Forms.CheckBox();
            this.ckGroup2 = new System.Windows.Forms.CheckBox();
            this.ckGroup1 = new System.Windows.Forms.CheckBox();
            this.label211 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtcanjqt = new System.Windows.Forms.TextBox();
            this.chcanjqk = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbHomeAddr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c3 = new System.Windows.Forms.CheckBox();
            this.tbCard3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCard2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbCard1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbOther = new System.Windows.Forms.TextBox();
            this.c7 = new System.Windows.Forms.CheckBox();
            this.c8 = new System.Windows.Forms.CheckBox();
            this.c4 = new System.Windows.Forms.CheckBox();
            this.c6 = new System.Windows.Forms.CheckBox();
            this.c5 = new System.Windows.Forms.CheckBox();
            this.c2 = new System.Windows.Forms.CheckBox();
            this.c1 = new System.Windows.Forms.CheckBox();
            this.txtzerenyisheng = new System.Windows.Forms.TextBox();
            this.label238 = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.radycby = new System.Windows.Forms.RadioButton();
            this.radycbw = new System.Windows.Forms.RadioButton();
            this.cmbwhcd = new System.Windows.Forms.ComboBox();
            this.txtywgmqt = new System.Windows.Forms.TextBox();
            this.txtycb = new System.Windows.Forms.TextBox();
            this.label193 = new System.Windows.Forms.Label();
            this.chywgm = new System.Windows.Forms.CheckedListBox();
            this.label192 = new System.Windows.Forms.Label();
            this.label191 = new System.Windows.Forms.Label();
            this.cmbhf = new System.Windows.Forms.ComboBox();
            this.label190 = new System.Windows.Forms.Label();
            this.cmbzy = new System.Windows.Forms.ComboBox();
            this.label189 = new System.Windows.Forms.Label();
            this.label188 = new System.Windows.Forms.Label();
            this.cmbRH = new System.Windows.Forms.ComboBox();
            this.label186 = new System.Windows.Forms.Label();
            this.cmbXieXin = new System.Windows.Forms.ComboBox();
            this.label187 = new System.Windows.Forms.Label();
            this.radczfhj = new System.Windows.Forms.RadioButton();
            this.radczhj = new System.Windows.Forms.RadioButton();
            this.label185 = new System.Windows.Forms.Label();
            this.txtlianxrdh = new System.Windows.Forms.TextBox();
            this.label184 = new System.Windows.Forms.Label();
            this.txtbenrdh = new System.Windows.Forms.TextBox();
            this.txtlianxrName = new System.Windows.Forms.TextBox();
            this.label183 = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.txtgongzdw = new System.Windows.Forms.TextBox();
            this.label181 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblBrith = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIdNo = new System.Windows.Forms.Label();
            this.groupBox45 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbCC = new System.Windows.Forms.ComboBox();
            this.cmbYC = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.rdYc5 = new System.Windows.Forms.RadioButton();
            this.rdYc4 = new System.Windows.Forms.RadioButton();
            this.rdYc3 = new System.Windows.Forms.RadioButton();
            this.rdYc2 = new System.Windows.Forms.RadioButton();
            this.rdYc1 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.tbFamilyStructure = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbFamilyNum = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbZZQK = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.BtnAddChild = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.label174 = new System.Windows.Forms.Label();
            this.tbFamBossIDCARD = new System.Windows.Forms.TextBox();
            this.tbFamBossName = new System.Windows.Forms.TextBox();
            this.label172 = new System.Windows.Forms.Label();
            this.tbRelation = new System.Windows.Forms.TextBox();
            this.cbxRole = new System.Windows.Forms.ComboBox();
            this.label180 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.gbBoxIdCard.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel34.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBoxIdCard
            // 
            this.gbBoxIdCard.BackColor = System.Drawing.Color.Transparent;
            this.gbBoxIdCard.Controls.Add(this.textBox1);
            this.gbBoxIdCard.Controls.Add(this.tbSx);
            this.gbBoxIdCard.Controls.Add(this.tbDw);
            this.gbBoxIdCard.Controls.Add(this.tbHxp);
            this.gbBoxIdCard.Controls.Add(this.ckbls4);
            this.gbBoxIdCard.Controls.Add(this.ckbls3);
            this.gbBoxIdCard.Controls.Add(this.ckbls2);
            this.gbBoxIdCard.Controls.Add(this.ckbls1);
            this.gbBoxIdCard.Controls.Add(this.comboBox1);
            this.gbBoxIdCard.Controls.Add(this.panel3);
            this.gbBoxIdCard.Controls.Add(this.label211);
            this.gbBoxIdCard.Controls.Add(this.tbEmail);
            this.gbBoxIdCard.Controls.Add(this.label9);
            this.gbBoxIdCard.Controls.Add(this.txtcanjqt);
            this.gbBoxIdCard.Controls.Add(this.chcanjqk);
            this.gbBoxIdCard.Controls.Add(this.label8);
            this.gbBoxIdCard.Controls.Add(this.tbHomeAddr);
            this.gbBoxIdCard.Controls.Add(this.label7);
            this.gbBoxIdCard.Controls.Add(this.panel1);
            this.gbBoxIdCard.Controls.Add(this.txtzerenyisheng);
            this.gbBoxIdCard.Controls.Add(this.label238);
            this.gbBoxIdCard.Controls.Add(this.panel34);
            this.gbBoxIdCard.Controls.Add(this.cmbwhcd);
            this.gbBoxIdCard.Controls.Add(this.txtywgmqt);
            this.gbBoxIdCard.Controls.Add(this.txtycb);
            this.gbBoxIdCard.Controls.Add(this.label193);
            this.gbBoxIdCard.Controls.Add(this.chywgm);
            this.gbBoxIdCard.Controls.Add(this.label192);
            this.gbBoxIdCard.Controls.Add(this.label191);
            this.gbBoxIdCard.Controls.Add(this.cmbhf);
            this.gbBoxIdCard.Controls.Add(this.label190);
            this.gbBoxIdCard.Controls.Add(this.cmbzy);
            this.gbBoxIdCard.Controls.Add(this.label189);
            this.gbBoxIdCard.Controls.Add(this.label188);
            this.gbBoxIdCard.Controls.Add(this.cmbRH);
            this.gbBoxIdCard.Controls.Add(this.label186);
            this.gbBoxIdCard.Controls.Add(this.cmbXieXin);
            this.gbBoxIdCard.Controls.Add(this.label187);
            this.gbBoxIdCard.Controls.Add(this.radczfhj);
            this.gbBoxIdCard.Controls.Add(this.radczhj);
            this.gbBoxIdCard.Controls.Add(this.label185);
            this.gbBoxIdCard.Controls.Add(this.txtlianxrdh);
            this.gbBoxIdCard.Controls.Add(this.label184);
            this.gbBoxIdCard.Controls.Add(this.txtbenrdh);
            this.gbBoxIdCard.Controls.Add(this.txtlianxrName);
            this.gbBoxIdCard.Controls.Add(this.label183);
            this.gbBoxIdCard.Controls.Add(this.label182);
            this.gbBoxIdCard.Controls.Add(this.txtgongzdw);
            this.gbBoxIdCard.Controls.Add(this.label181);
            this.gbBoxIdCard.Controls.Add(this.lblName);
            this.gbBoxIdCard.Controls.Add(this.lblSex);
            this.gbBoxIdCard.Controls.Add(this.lblBrith);
            this.gbBoxIdCard.Controls.Add(this.label6);
            this.gbBoxIdCard.Controls.Add(this.label5);
            this.gbBoxIdCard.Controls.Add(this.label4);
            this.gbBoxIdCard.Controls.Add(this.label3);
            this.gbBoxIdCard.Controls.Add(this.label2);
            this.gbBoxIdCard.Controls.Add(this.label1);
            this.gbBoxIdCard.Location = new System.Drawing.Point(6, 216);
            this.gbBoxIdCard.Name = "gbBoxIdCard";
            this.gbBoxIdCard.Size = new System.Drawing.Size(1300, 739);
            this.gbBoxIdCard.TabIndex = 1;
            this.gbBoxIdCard.TabStop = false;
            this.gbBoxIdCard.Text = "个人信息";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(158, 30);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(184, 30);
            this.textBox1.TabIndex = 2;
            // 
            // tbSx
            // 
            this.tbSx.Location = new System.Drawing.Point(789, 494);
            this.tbSx.Name = "tbSx";
            this.tbSx.ReadOnly = true;
            this.tbSx.Size = new System.Drawing.Size(127, 30);
            this.tbSx.TabIndex = 101;
            // 
            // tbDw
            // 
            this.tbDw.Location = new System.Drawing.Point(572, 493);
            this.tbDw.Name = "tbDw";
            this.tbDw.ReadOnly = true;
            this.tbDw.Size = new System.Drawing.Size(121, 30);
            this.tbDw.TabIndex = 100;
            // 
            // tbHxp
            // 
            this.tbHxp.Location = new System.Drawing.Point(348, 493);
            this.tbHxp.Name = "tbHxp";
            this.tbHxp.ReadOnly = true;
            this.tbHxp.Size = new System.Drawing.Size(130, 30);
            this.tbHxp.TabIndex = 99;
            // 
            // ckbls4
            // 
            this.ckbls4.AutoSize = true;
            this.ckbls4.Location = new System.Drawing.Point(703, 498);
            this.ckbls4.Name = "ckbls4";
            this.ckbls4.Size = new System.Drawing.Size(68, 24);
            this.ckbls4.TabIndex = 98;
            this.ckbls4.Text = "射线";
            this.ckbls4.UseVisualStyleBackColor = true;
            // 
            // ckbls3
            // 
            this.ckbls3.AutoSize = true;
            this.ckbls3.Location = new System.Drawing.Point(489, 498);
            this.ckbls3.Name = "ckbls3";
            this.ckbls3.Size = new System.Drawing.Size(68, 24);
            this.ckbls3.TabIndex = 97;
            this.ckbls3.Text = "毒物";
            this.ckbls3.UseVisualStyleBackColor = true;
            // 
            // ckbls2
            // 
            this.ckbls2.AutoSize = true;
            this.ckbls2.Location = new System.Drawing.Point(239, 498);
            this.ckbls2.Name = "ckbls2";
            this.ckbls2.Size = new System.Drawing.Size(88, 24);
            this.ckbls2.TabIndex = 96;
            this.ckbls2.Text = "化学品";
            this.ckbls2.UseVisualStyleBackColor = true;
            // 
            // ckbls1
            // 
            this.ckbls1.AutoSize = true;
            this.ckbls1.Location = new System.Drawing.Point(165, 498);
            this.ckbls1.Name = "ckbls1";
            this.ckbls1.Size = new System.Drawing.Size(48, 24);
            this.ckbls1.TabIndex = 95;
            this.ckbls1.Text = "无";
            this.ckbls1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(847, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 94;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.ckGroup11);
            this.panel3.Controls.Add(this.ckGroup10);
            this.panel3.Controls.Add(this.ckGroup9);
            this.panel3.Controls.Add(this.ckGroup8);
            this.panel3.Controls.Add(this.ckGroup7);
            this.panel3.Controls.Add(this.ckGroup6);
            this.panel3.Controls.Add(this.ckGroup5);
            this.panel3.Controls.Add(this.ckGroup4);
            this.panel3.Controls.Add(this.ckGroup3);
            this.panel3.Controls.Add(this.ckGroup2);
            this.panel3.Controls.Add(this.ckGroup1);
            this.panel3.Location = new System.Drawing.Point(163, 649);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 76);
            this.panel3.TabIndex = 22;
            // 
            // ckGroup11
            // 
            this.ckGroup11.AutoSize = true;
            this.ckGroup11.Location = new System.Drawing.Point(610, 8);
            this.ckGroup11.Name = "ckGroup11";
            this.ckGroup11.Size = new System.Drawing.Size(88, 24);
            this.ckGroup11.TabIndex = 10;
            this.ckGroup11.Text = "残疾人";
            this.ckGroup11.UseVisualStyleBackColor = true;
            // 
            // ckGroup10
            // 
            this.ckGroup10.AutoSize = true;
            this.ckGroup10.Location = new System.Drawing.Point(474, 32);
            this.ckGroup10.Name = "ckGroup10";
            this.ckGroup10.Size = new System.Drawing.Size(88, 24);
            this.ckGroup10.TabIndex = 9;
            this.ckGroup10.Text = "肺结核";
            this.ckGroup10.UseVisualStyleBackColor = true;
            // 
            // ckGroup9
            // 
            this.ckGroup9.AutoSize = true;
            this.ckGroup9.Location = new System.Drawing.Point(362, 32);
            this.ckGroup9.Name = "ckGroup9";
            this.ckGroup9.Size = new System.Drawing.Size(88, 24);
            this.ckGroup9.TabIndex = 8;
            this.ckGroup9.Text = "脑卒中";
            this.ckGroup9.UseVisualStyleBackColor = true;
            // 
            // ckGroup8
            // 
            this.ckGroup8.AutoSize = true;
            this.ckGroup8.Location = new System.Drawing.Point(250, 32);
            this.ckGroup8.Name = "ckGroup8";
            this.ckGroup8.Size = new System.Drawing.Size(88, 24);
            this.ckGroup8.TabIndex = 7;
            this.ckGroup8.Text = "冠心病";
            this.ckGroup8.UseVisualStyleBackColor = true;
            // 
            // ckGroup7
            // 
            this.ckGroup7.AutoSize = true;
            this.ckGroup7.Location = new System.Drawing.Point(139, 32);
            this.ckGroup7.Name = "ckGroup7";
            this.ckGroup7.Size = new System.Drawing.Size(88, 24);
            this.ckGroup7.TabIndex = 6;
            this.ckGroup7.Text = "糖尿病";
            this.ckGroup7.UseVisualStyleBackColor = true;
            // 
            // ckGroup6
            // 
            this.ckGroup6.AutoSize = true;
            this.ckGroup6.Location = new System.Drawing.Point(4, 32);
            this.ckGroup6.Name = "ckGroup6";
            this.ckGroup6.Size = new System.Drawing.Size(88, 24);
            this.ckGroup6.TabIndex = 5;
            this.ckGroup6.Text = "高血压";
            this.ckGroup6.UseVisualStyleBackColor = true;
            // 
            // ckGroup5
            // 
            this.ckGroup5.AutoSize = true;
            this.ckGroup5.Location = new System.Drawing.Point(475, 8);
            this.ckGroup5.Name = "ckGroup5";
            this.ckGroup5.Size = new System.Drawing.Size(108, 24);
            this.ckGroup5.TabIndex = 4;
            this.ckGroup5.Text = "重精神病";
            this.ckGroup5.UseVisualStyleBackColor = true;
            // 
            // ckGroup4
            // 
            this.ckGroup4.AutoSize = true;
            this.ckGroup4.Location = new System.Drawing.Point(362, 8);
            this.ckGroup4.Name = "ckGroup4";
            this.ckGroup4.Size = new System.Drawing.Size(88, 24);
            this.ckGroup4.TabIndex = 3;
            this.ckGroup4.Text = "老年人";
            this.ckGroup4.UseVisualStyleBackColor = true;
            // 
            // ckGroup3
            // 
            this.ckGroup3.AutoSize = true;
            this.ckGroup3.Location = new System.Drawing.Point(250, 8);
            this.ckGroup3.Name = "ckGroup3";
            this.ckGroup3.Size = new System.Drawing.Size(88, 24);
            this.ckGroup3.TabIndex = 2;
            this.ckGroup3.Text = "孕产妇";
            this.ckGroup3.UseVisualStyleBackColor = true;
            this.ckGroup3.CheckedChanged += new System.EventHandler(this.ckGroup3_CheckedChanged);
            // 
            // ckGroup2
            // 
            this.ckGroup2.AutoSize = true;
            this.ckGroup2.Location = new System.Drawing.Point(139, 8);
            this.ckGroup2.Name = "ckGroup2";
            this.ckGroup2.Size = new System.Drawing.Size(68, 24);
            this.ckGroup2.TabIndex = 1;
            this.ckGroup2.Text = "儿童";
            this.ckGroup2.UseVisualStyleBackColor = true;
            // 
            // ckGroup1
            // 
            this.ckGroup1.AutoSize = true;
            this.ckGroup1.Location = new System.Drawing.Point(4, 8);
            this.ckGroup1.Name = "ckGroup1";
            this.ckGroup1.Size = new System.Drawing.Size(108, 24);
            this.ckGroup1.TabIndex = 0;
            this.ckGroup1.Text = "一般人群";
            this.ckGroup1.UseVisualStyleBackColor = true;
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Location = new System.Drawing.Point(35, 557);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(99, 20);
            this.label211.TabIndex = 92;
            this.label211.Text = "残疾情况:";
            // 
            // tbEmail
            // 
            this.tbEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbEmail.ForeColor = System.Drawing.Color.Black;
            this.tbEmail.Location = new System.Drawing.Point(1038, 653);
            this.tbEmail.MaxLength = 50;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(208, 30);
            this.tbEmail.TabIndex = 23;
            this.tbEmail.TextChanged += new System.EventHandler(this.tbEmail_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(967, 656);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 20);
            this.label9.TabIndex = 87;
            this.label9.Text = "邮箱:";
            // 
            // txtcanjqt
            // 
            this.txtcanjqt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtcanjqt.ForeColor = System.Drawing.Color.Black;
            this.txtcanjqt.Location = new System.Drawing.Point(551, 576);
            this.txtcanjqt.MaxLength = 100;
            this.txtcanjqt.Name = "txtcanjqt";
            this.txtcanjqt.ReadOnly = true;
            this.txtcanjqt.Size = new System.Drawing.Size(352, 30);
            this.txtcanjqt.TabIndex = 21;
            // 
            // chcanjqk
            // 
            this.chcanjqk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chcanjqk.CheckOnClick = true;
            this.chcanjqk.FormattingEnabled = true;
            this.chcanjqk.Items.AddRange(new object[] {
            "无残疾",
            "视力残疾",
            "听力残疾",
            "言语残疾",
            "肢体残疾",
            "智力残疾",
            "精神残疾",
            "其他"});
            this.chcanjqk.Location = new System.Drawing.Point(163, 546);
            this.chcanjqk.MultiColumn = true;
            this.chcanjqk.Name = "chcanjqk";
            this.chcanjqk.Size = new System.Drawing.Size(1050, 79);
            this.chcanjqk.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 654);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "人群分类:";
            // 
            // tbHomeAddr
            // 
            this.tbHomeAddr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHomeAddr.ForeColor = System.Drawing.Color.Black;
            this.tbHomeAddr.Location = new System.Drawing.Point(847, 71);
            this.tbHomeAddr.MaxLength = 20;
            this.tbHomeAddr.Name = "tbHomeAddr";
            this.tbHomeAddr.ReadOnly = true;
            this.tbHomeAddr.Size = new System.Drawing.Size(380, 30);
            this.tbHomeAddr.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 497);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 84;
            this.label7.Text = "暴露史:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.c3);
            this.panel1.Controls.Add(this.tbCard3);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tbCard2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.tbCard1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbOther);
            this.panel1.Controls.Add(this.c7);
            this.panel1.Controls.Add(this.c8);
            this.panel1.Controls.Add(this.c4);
            this.panel1.Controls.Add(this.c6);
            this.panel1.Controls.Add(this.c5);
            this.panel1.Controls.Add(this.c2);
            this.panel1.Controls.Add(this.c1);
            this.panel1.Location = new System.Drawing.Point(159, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 124);
            this.panel1.TabIndex = 15;
            // 
            // c3
            // 
            this.c3.AutoSize = true;
            this.c3.Location = new System.Drawing.Point(5, 45);
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(188, 24);
            this.c3.TabIndex = 15;
            this.c3.Text = "新型农村合作医疗";
            this.c3.UseVisualStyleBackColor = true;
            // 
            // tbCard3
            // 
            this.tbCard3.Location = new System.Drawing.Point(502, 43);
            this.tbCard3.Name = "tbCard3";
            this.tbCard3.ReadOnly = true;
            this.tbCard3.Size = new System.Drawing.Size(155, 30);
            this.tbCard3.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(431, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 20);
            this.label12.TabIndex = 13;
            this.label12.Text = "卡号";
            // 
            // tbCard2
            // 
            this.tbCard2.Location = new System.Drawing.Point(979, 4);
            this.tbCard2.Name = "tbCard2";
            this.tbCard2.ReadOnly = true;
            this.tbCard2.Size = new System.Drawing.Size(136, 30);
            this.tbCard2.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(870, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "医保卡号";
            // 
            // tbCard1
            // 
            this.tbCard1.Location = new System.Drawing.Point(385, 4);
            this.tbCard1.Name = "tbCard1";
            this.tbCard1.ReadOnly = true;
            this.tbCard1.Size = new System.Drawing.Size(146, 30);
            this.tbCard1.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(290, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "医保卡号";
            // 
            // tbOther
            // 
            this.tbOther.Location = new System.Drawing.Point(95, 84);
            this.tbOther.MaxLength = 20;
            this.tbOther.Name = "tbOther";
            this.tbOther.ReadOnly = true;
            this.tbOther.Size = new System.Drawing.Size(376, 30);
            this.tbOther.TabIndex = 8;
            // 
            // c7
            // 
            this.c7.AutoSize = true;
            this.c7.Location = new System.Drawing.Point(996, 46);
            this.c7.Name = "c7";
            this.c7.Size = new System.Drawing.Size(88, 24);
            this.c7.TabIndex = 6;
            this.c7.Text = "全自费";
            this.c7.UseVisualStyleBackColor = true;
            // 
            // c8
            // 
            this.c8.AutoSize = true;
            this.c8.Location = new System.Drawing.Point(5, 88);
            this.c8.Name = "c8";
            this.c8.Size = new System.Drawing.Size(68, 24);
            this.c8.TabIndex = 7;
            this.c8.Text = "其他";
            this.c8.UseVisualStyleBackColor = true;
            this.c8.CheckedChanged += new System.EventHandler(this.c8_CheckedChanged);
            // 
            // c4
            // 
            this.c4.AutoSize = true;
            this.c4.Location = new System.Drawing.Point(295, 48);
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(108, 24);
            this.c4.TabIndex = 3;
            this.c4.Text = "贫困救助";
            this.c4.UseVisualStyleBackColor = true;
            this.c4.CheckedChanged += new System.EventHandler(this.c4_CheckedChanged);
            // 
            // c6
            // 
            this.c6.AutoSize = true;
            this.c6.Location = new System.Drawing.Point(876, 46);
            this.c6.Name = "c6";
            this.c6.Size = new System.Drawing.Size(88, 24);
            this.c6.TabIndex = 5;
            this.c6.Text = "全公费";
            this.c6.UseVisualStyleBackColor = true;
            // 
            // c5
            // 
            this.c5.AutoSize = true;
            this.c5.Location = new System.Drawing.Point(694, 46);
            this.c5.Name = "c5";
            this.c5.Size = new System.Drawing.Size(148, 24);
            this.c5.TabIndex = 4;
            this.c5.Text = "商业医疗保险";
            this.c5.UseVisualStyleBackColor = true;
            // 
            // c2
            // 
            this.c2.AutoSize = true;
            this.c2.Location = new System.Drawing.Point(599, 7);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(228, 24);
            this.c2.TabIndex = 1;
            this.c2.Text = "城镇居民基本医疗保险";
            this.c2.UseVisualStyleBackColor = true;
            this.c2.CheckedChanged += new System.EventHandler(this.c2_CheckedChanged);
            // 
            // c1
            // 
            this.c1.AutoSize = true;
            this.c1.Location = new System.Drawing.Point(4, 7);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(228, 24);
            this.c1.TabIndex = 0;
            this.c1.Text = "城镇职工基本医疗保险";
            this.c1.UseVisualStyleBackColor = true;
            this.c1.CheckedChanged += new System.EventHandler(this.c1_CheckedChanged);
            // 
            // txtzerenyisheng
            // 
            this.txtzerenyisheng.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtzerenyisheng.ForeColor = System.Drawing.Color.Black;
            this.txtzerenyisheng.Location = new System.Drawing.Point(975, 236);
            this.txtzerenyisheng.MaxLength = 20;
            this.txtzerenyisheng.Name = "txtzerenyisheng";
            this.txtzerenyisheng.ReadOnly = true;
            this.txtzerenyisheng.Size = new System.Drawing.Size(163, 30);
            this.txtzerenyisheng.TabIndex = 14;
            this.txtzerenyisheng.Visible = false;
            // 
            // label238
            // 
            this.label238.AutoSize = true;
            this.label238.Location = new System.Drawing.Point(851, 241);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(99, 20);
            this.label238.TabIndex = 73;
            this.label238.Text = "责任医生:";
            this.label238.Visible = false;
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.radycby);
            this.panel34.Controls.Add(this.radycbw);
            this.panel34.Location = new System.Drawing.Point(495, 232);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(120, 35);
            this.panel34.TabIndex = 12;
            // 
            // radycby
            // 
            this.radycby.AutoSize = true;
            this.radycby.Location = new System.Drawing.Point(56, 7);
            this.radycby.Name = "radycby";
            this.radycby.Size = new System.Drawing.Size(47, 24);
            this.radycby.TabIndex = 33;
            this.radycby.Text = "有";
            this.radycby.UseVisualStyleBackColor = true;
            // 
            // radycbw
            // 
            this.radycbw.AutoSize = true;
            this.radycbw.Checked = true;
            this.radycbw.Location = new System.Drawing.Point(2, 7);
            this.radycbw.Name = "radycbw";
            this.radycbw.Size = new System.Drawing.Size(47, 24);
            this.radycbw.TabIndex = 32;
            this.radycbw.TabStop = true;
            this.radycbw.Text = "无";
            this.radycbw.UseVisualStyleBackColor = true;
            // 
            // cmbwhcd
            // 
            this.cmbwhcd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbwhcd.FormattingEnabled = true;
            this.cmbwhcd.Items.AddRange(new object[] {
            "研究生",
            "大学本科",
            "大学专科和专科学校",
            "中等专业学校",
            "技工学校",
            "高中",
            "初中",
            "小学",
            "文盲及半文盲"});
            this.cmbwhcd.Location = new System.Drawing.Point(497, 192);
            this.cmbwhcd.Name = "cmbwhcd";
            this.cmbwhcd.Size = new System.Drawing.Size(163, 28);
            this.cmbwhcd.TabIndex = 9;
            // 
            // txtywgmqt
            // 
            this.txtywgmqt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtywgmqt.ForeColor = System.Drawing.Color.Black;
            this.txtywgmqt.Location = new System.Drawing.Point(551, 412);
            this.txtywgmqt.MaxLength = 20;
            this.txtywgmqt.Name = "txtywgmqt";
            this.txtywgmqt.ReadOnly = true;
            this.txtywgmqt.Size = new System.Drawing.Size(170, 30);
            this.txtywgmqt.TabIndex = 18;
            // 
            // txtycb
            // 
            this.txtycb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtycb.ForeColor = System.Drawing.Color.Black;
            this.txtycb.Location = new System.Drawing.Point(621, 235);
            this.txtycb.MaxLength = 100;
            this.txtycb.Name = "txtycb";
            this.txtycb.ReadOnly = true;
            this.txtycb.Size = new System.Drawing.Size(189, 30);
            this.txtycb.TabIndex = 13;
            // 
            // label193
            // 
            this.label193.AutoSize = true;
            this.label193.Location = new System.Drawing.Point(372, 242);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(99, 20);
            this.label193.TabIndex = 28;
            this.label193.Text = "遗传病史:";
            // 
            // chywgm
            // 
            this.chywgm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chywgm.CheckOnClick = true;
            this.chywgm.FormattingEnabled = true;
            this.chywgm.Items.AddRange(new object[] {
            "无",
            "青霉素",
            "磺胺",
            "链霉素",
            "其他"});
            this.chywgm.Location = new System.Drawing.Point(162, 409);
            this.chywgm.MultiColumn = true;
            this.chywgm.Name = "chywgm";
            this.chywgm.Size = new System.Drawing.Size(1051, 54);
            this.chywgm.TabIndex = 17;
            // 
            // label192
            // 
            this.label192.AutoSize = true;
            this.label192.Location = new System.Drawing.Point(10, 415);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(119, 20);
            this.label192.TabIndex = 26;
            this.label192.Text = "药物过敏史:";
            // 
            // label191
            // 
            this.label191.AutoSize = true;
            this.label191.Location = new System.Drawing.Point(35, 283);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(99, 20);
            this.label191.TabIndex = 24;
            this.label191.Text = "支付方式:";
            // 
            // cmbhf
            // 
            this.cmbhf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbhf.FormattingEnabled = true;
            this.cmbhf.Items.AddRange(new object[] {
            "未婚",
            "已婚",
            "丧偶",
            "离婚",
            "未说明的婚姻状况"});
            this.cmbhf.Location = new System.Drawing.Point(160, 239);
            this.cmbhf.Name = "cmbhf";
            this.cmbhf.Size = new System.Drawing.Size(184, 28);
            this.cmbhf.TabIndex = 11;
            // 
            // label190
            // 
            this.label190.AutoSize = true;
            this.label190.Location = new System.Drawing.Point(35, 243);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(99, 20);
            this.label190.TabIndex = 22;
            this.label190.Text = "婚姻情况:";
            // 
            // cmbzy
            // 
            this.cmbzy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbzy.FormattingEnabled = true;
            this.cmbzy.Items.AddRange(new object[] {
            "国家机关、党群组织、企业、事业单位负责人",
            "专业技术人员",
            "办事人员和有关人员",
            "商业服务业人员",
            "农、林、牧、渔、水利生产人员",
            "生产、运输设备操作人员及有关人员",
            "军人",
            "不便分类的其他从业人员",
            "无职业"});
            this.cmbzy.Location = new System.Drawing.Point(847, 192);
            this.cmbzy.Name = "cmbzy";
            this.cmbzy.Size = new System.Drawing.Size(235, 28);
            this.cmbzy.TabIndex = 10;
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.Location = new System.Drawing.Point(691, 196);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(99, 20);
            this.label189.TabIndex = 20;
            this.label189.Text = "职　　业:";
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Location = new System.Drawing.Point(371, 196);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(99, 20);
            this.label188.TabIndex = 18;
            this.label188.Text = "文化程度:";
            // 
            // cmbRH
            // 
            this.cmbRH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRH.FormattingEnabled = true;
            this.cmbRH.Items.AddRange(new object[] {
            "否",
            "是",
            "不详"});
            this.cmbRH.Location = new System.Drawing.Point(159, 192);
            this.cmbRH.Name = "cmbRH";
            this.cmbRH.Size = new System.Drawing.Size(184, 28);
            this.cmbRH.TabIndex = 8;
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.Location = new System.Drawing.Point(34, 196);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(99, 20);
            this.label186.TabIndex = 16;
            this.label186.Text = "RH　阴性:";
            // 
            // cmbXieXin
            // 
            this.cmbXieXin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXieXin.FormattingEnabled = true;
            this.cmbXieXin.Location = new System.Drawing.Point(847, 154);
            this.cmbXieXin.Name = "cmbXieXin";
            this.cmbXieXin.Size = new System.Drawing.Size(140, 28);
            this.cmbXieXin.TabIndex = 7;
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Location = new System.Drawing.Point(691, 158);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(99, 20);
            this.label187.TabIndex = 14;
            this.label187.Text = "血　　型:";
            // 
            // radczfhj
            // 
            this.radczfhj.AutoSize = true;
            this.radczfhj.Location = new System.Drawing.Point(576, 156);
            this.radczfhj.Name = "radczfhj";
            this.radczfhj.Size = new System.Drawing.Size(87, 24);
            this.radczfhj.TabIndex = 6;
            this.radczfhj.TabStop = true;
            this.radczfhj.Text = "非户籍";
            this.radczfhj.UseVisualStyleBackColor = true;
            // 
            // radczhj
            // 
            this.radczhj.AutoSize = true;
            this.radczhj.Location = new System.Drawing.Point(497, 156);
            this.radczhj.Name = "radczhj";
            this.radczhj.Size = new System.Drawing.Size(67, 24);
            this.radczhj.TabIndex = 5;
            this.radczhj.TabStop = true;
            this.radczhj.Text = "户籍";
            this.radczhj.UseVisualStyleBackColor = true;
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Location = new System.Drawing.Point(371, 158);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(99, 20);
            this.label185.TabIndex = 10;
            this.label185.Text = "常住类型:";
            // 
            // txtlianxrdh
            // 
            this.txtlianxrdh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtlianxrdh.ForeColor = System.Drawing.Color.Black;
            this.txtlianxrdh.Location = new System.Drawing.Point(159, 154);
            this.txtlianxrdh.MaxLength = 15;
            this.txtlianxrdh.Name = "txtlianxrdh";
            this.txtlianxrdh.Size = new System.Drawing.Size(184, 30);
            this.txtlianxrdh.TabIndex = 4;
            this.txtlianxrdh.TextChanged += new System.EventHandler(this.txtbenrdh_TextChanged);
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.Location = new System.Drawing.Point(10, 158);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(119, 20);
            this.label184.TabIndex = 8;
            this.label184.Text = "联系人电话:";
            // 
            // txtbenrdh
            // 
            this.txtbenrdh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtbenrdh.Enabled = false;
            this.txtbenrdh.ForeColor = System.Drawing.Color.Black;
            this.txtbenrdh.Location = new System.Drawing.Point(497, 112);
            this.txtbenrdh.MaxLength = 15;
            this.txtbenrdh.Name = "txtbenrdh";
            this.txtbenrdh.ReadOnly = true;
            this.txtbenrdh.Size = new System.Drawing.Size(166, 30);
            this.txtbenrdh.TabIndex = 2;
            this.txtbenrdh.TabStop = false;
            this.toolTip1.SetToolTip(this.txtbenrdh, "请在\"封面信息\"中填写用户个人电话");
            // 
            // txtlianxrName
            // 
            this.txtlianxrName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtlianxrName.ForeColor = System.Drawing.Color.Black;
            this.txtlianxrName.Location = new System.Drawing.Point(847, 112);
            this.txtlianxrName.MaxLength = 10;
            this.txtlianxrName.Name = "txtlianxrName";
            this.txtlianxrName.Size = new System.Drawing.Size(139, 30);
            this.txtlianxrName.TabIndex = 3;
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.Location = new System.Drawing.Point(691, 116);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(119, 20);
            this.label183.TabIndex = 6;
            this.label183.Text = "联系人姓名:";
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.Location = new System.Drawing.Point(371, 116);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(99, 20);
            this.label182.TabIndex = 4;
            this.label182.Text = "本人电话:";
            // 
            // txtgongzdw
            // 
            this.txtgongzdw.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtgongzdw.ForeColor = System.Drawing.Color.Black;
            this.txtgongzdw.Location = new System.Drawing.Point(159, 112);
            this.txtgongzdw.MaxLength = 20;
            this.txtgongzdw.Name = "txtgongzdw";
            this.txtgongzdw.Size = new System.Drawing.Size(184, 30);
            this.txtgongzdw.TabIndex = 1;
            // 
            // label181
            // 
            this.label181.AutoSize = true;
            this.label181.Location = new System.Drawing.Point(36, 116);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(99, 20);
            this.label181.TabIndex = 2;
            this.label181.Text = "工作单位:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(497, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label6";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(497, 74);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(69, 20);
            this.lblSex.TabIndex = 1;
            this.lblSex.Text = "label6";
            // 
            // lblBrith
            // 
            this.lblBrith.AutoSize = true;
            this.lblBrith.Location = new System.Drawing.Point(159, 74);
            this.lblBrith.Name = "lblBrith";
            this.lblBrith.Size = new System.Drawing.Size(69, 20);
            this.lblBrith.TabIndex = 1;
            this.lblBrith.Text = "label6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(691, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "户籍住址:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "性别:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "出生日期:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(691, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "民族:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "姓名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "身份证号:";
            // 
            // lblIdNo
            // 
            this.lblIdNo.AutoSize = true;
            this.lblIdNo.Location = new System.Drawing.Point(32, 175);
            this.lblIdNo.Name = "lblIdNo";
            this.lblIdNo.Size = new System.Drawing.Size(69, 20);
            this.lblIdNo.TabIndex = 1;
            this.lblIdNo.Text = "label6";
            this.lblIdNo.Visible = false;
            // 
            // groupBox45
            // 
            this.groupBox45.BackColor = System.Drawing.Color.Transparent;
            this.groupBox45.Controls.Add(this.panel2);
            this.groupBox45.Controls.Add(this.tbFamilyStructure);
            this.groupBox45.Controls.Add(this.label16);
            this.groupBox45.Controls.Add(this.tbFamilyNum);
            this.groupBox45.Controls.Add(this.label15);
            this.groupBox45.Controls.Add(this.cbZZQK);
            this.groupBox45.Controls.Add(this.label13);
            this.groupBox45.Controls.Add(this.BtnAddChild);
            this.groupBox45.Controls.Add(this.btnFind);
            this.groupBox45.Controls.Add(this.label174);
            this.groupBox45.Controls.Add(this.tbFamBossIDCARD);
            this.groupBox45.Controls.Add(this.tbFamBossName);
            this.groupBox45.Controls.Add(this.label172);
            this.groupBox45.Controls.Add(this.tbRelation);
            this.groupBox45.Controls.Add(this.cbxRole);
            this.groupBox45.Controls.Add(this.label180);
            this.groupBox45.Location = new System.Drawing.Point(6, 4);
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Size = new System.Drawing.Size(1300, 206);
            this.groupBox45.TabIndex = 0;
            this.groupBox45.TabStop = false;
            this.groupBox45.Text = "档案信息";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbCC);
            this.panel2.Controls.Add(this.cmbYC);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.rdYc5);
            this.panel2.Controls.Add(this.rdYc4);
            this.panel2.Controls.Add(this.rdYc3);
            this.panel2.Controls.Add(this.rdYc2);
            this.panel2.Controls.Add(this.rdYc1);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(14, 149);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1213, 49);
            this.panel2.TabIndex = 35;
            // 
            // cmbCC
            // 
            this.cmbCC.FormattingEnabled = true;
            this.cmbCC.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmbCC.Location = new System.Drawing.Point(1125, 6);
            this.cmbCC.Name = "cmbCC";
            this.cmbCC.Size = new System.Drawing.Size(70, 28);
            this.cmbCC.TabIndex = 37;
            // 
            // cmbYC
            // 
            this.cmbYC.FormattingEnabled = true;
            this.cmbYC.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbYC.Location = new System.Drawing.Point(966, 6);
            this.cmbYC.Name = "cmbYC";
            this.cmbYC.Size = new System.Drawing.Size(70, 28);
            this.cmbYC.TabIndex = 36;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1059, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 20);
            this.label18.TabIndex = 35;
            this.label18.Text = "产次";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(904, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 20);
            this.label17.TabIndex = 34;
            this.label17.Text = "孕次";
            // 
            // rdYc5
            // 
            this.rdYc5.AutoSize = true;
            this.rdYc5.Location = new System.Drawing.Point(818, 9);
            this.rdYc5.Name = "rdYc5";
            this.rdYc5.Size = new System.Drawing.Size(67, 24);
            this.rdYc5.TabIndex = 17;
            this.rdYc5.TabStop = true;
            this.rdYc5.Text = "不详";
            this.rdYc5.UseVisualStyleBackColor = true;
            // 
            // rdYc4
            // 
            this.rdYc4.AutoSize = true;
            this.rdYc4.Location = new System.Drawing.Point(590, 9);
            this.rdYc4.Name = "rdYc4";
            this.rdYc4.Size = new System.Drawing.Size(187, 24);
            this.rdYc4.TabIndex = 16;
            this.rdYc4.TabStop = true;
            this.rdYc4.Text = "已生产(随访期外)";
            this.rdYc4.UseVisualStyleBackColor = true;
            // 
            // rdYc3
            // 
            this.rdYc3.AutoSize = true;
            this.rdYc3.Location = new System.Drawing.Point(361, 9);
            this.rdYc3.Name = "rdYc3";
            this.rdYc3.Size = new System.Drawing.Size(197, 24);
            this.rdYc3.TabIndex = 15;
            this.rdYc3.TabStop = true;
            this.rdYc3.Text = "已生产(随访期内) ";
            this.rdYc3.UseVisualStyleBackColor = true;
            // 
            // rdYc2
            // 
            this.rdYc2.AutoSize = true;
            this.rdYc2.Location = new System.Drawing.Point(206, 9);
            this.rdYc2.Name = "rdYc2";
            this.rdYc2.Size = new System.Drawing.Size(127, 24);
            this.rdYc2.TabIndex = 14;
            this.rdYc2.TabStop = true;
            this.rdYc2.Text = "已孕未生产";
            this.rdYc2.UseVisualStyleBackColor = true;
            // 
            // rdYc1
            // 
            this.rdYc1.AutoSize = true;
            this.rdYc1.Location = new System.Drawing.Point(126, 9);
            this.rdYc1.Name = "rdYc1";
            this.rdYc1.Size = new System.Drawing.Size(67, 24);
            this.rdYc1.TabIndex = 13;
            this.rdYc1.TabStop = true;
            this.rdYc1.Text = "未孕";
            this.rdYc1.UseVisualStyleBackColor = true;
            this.rdYc1.CheckedChanged += new System.EventHandler(this.rdYc1_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 20);
            this.label14.TabIndex = 12;
            this.label14.Text = "孕产情况:";
            // 
            // tbFamilyStructure
            // 
            this.tbFamilyStructure.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFamilyStructure.ForeColor = System.Drawing.Color.Black;
            this.tbFamilyStructure.Location = new System.Drawing.Point(525, 114);
            this.tbFamilyStructure.MaxLength = 100;
            this.tbFamilyStructure.Name = "tbFamilyStructure";
            this.tbFamilyStructure.Size = new System.Drawing.Size(402, 30);
            this.tbFamilyStructure.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(404, 118);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 33;
            this.label16.Text = "家庭结构:";
            // 
            // tbFamilyNum
            // 
            this.tbFamilyNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFamilyNum.ForeColor = System.Drawing.Color.Black;
            this.tbFamilyNum.Location = new System.Drawing.Point(159, 75);
            this.tbFamilyNum.MaxLength = 20;
            this.tbFamilyNum.Name = "tbFamilyNum";
            this.tbFamilyNum.Size = new System.Drawing.Size(116, 30);
            this.tbFamilyNum.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = "家庭人口数:";
            // 
            // cbZZQK
            // 
            this.cbZZQK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZZQK.FormattingEnabled = true;
            this.cbZZQK.Items.AddRange(new object[] {
            "与成年子女同住",
            "与子孙三代（四代）同住",
            "夫妻二人同住",
            "独居",
            "计划生育特殊家庭  "});
            this.cbZZQK.Location = new System.Drawing.Point(529, 72);
            this.cbZZQK.Name = "cbZZQK";
            this.cbZZQK.Size = new System.Drawing.Size(203, 28);
            this.cbZZQK.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(404, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "居住情况:";
            // 
            // BtnAddChild
            // 
            this.BtnAddChild.Location = new System.Drawing.Point(984, 37);
            this.BtnAddChild.Name = "BtnAddChild";
            this.BtnAddChild.Size = new System.Drawing.Size(179, 47);
            this.BtnAddChild.TabIndex = 5;
            this.BtnAddChild.Text = "儿童档案新增";
            this.BtnAddChild.UseVisualStyleBackColor = true;
            this.BtnAddChild.Visible = false;
            this.BtnAddChild.Click += new System.EventHandler(this.BtnAddChild_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(760, 30);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(167, 36);
            this.btnFind.TabIndex = 2;
            this.btnFind.Tag = "";
            this.btnFind.Text = "与家庭关联";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label174
            // 
            this.label174.AutoSize = true;
            this.label174.Location = new System.Drawing.Point(402, 33);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(99, 20);
            this.label174.TabIndex = 26;
            this.label174.Text = "身份证号:";
            // 
            // tbFamBossIDCARD
            // 
            this.tbFamBossIDCARD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFamBossIDCARD.ForeColor = System.Drawing.Color.Black;
            this.tbFamBossIDCARD.Location = new System.Drawing.Point(529, 30);
            this.tbFamBossIDCARD.MaxLength = 18;
            this.tbFamBossIDCARD.Name = "tbFamBossIDCARD";
            this.tbFamBossIDCARD.Size = new System.Drawing.Size(201, 30);
            this.tbFamBossIDCARD.TabIndex = 1;
            // 
            // tbFamBossName
            // 
            this.tbFamBossName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFamBossName.ForeColor = System.Drawing.Color.Black;
            this.tbFamBossName.Location = new System.Drawing.Point(159, 30);
            this.tbFamBossName.MaxLength = 20;
            this.tbFamBossName.Name = "tbFamBossName";
            this.tbFamBossName.Size = new System.Drawing.Size(239, 30);
            this.tbFamBossName.TabIndex = 0;
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Location = new System.Drawing.Point(25, 36);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(99, 20);
            this.label172.TabIndex = 23;
            this.label172.Text = "户主姓名:";
            // 
            // tbRelation
            // 
            this.tbRelation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbRelation.ForeColor = System.Drawing.Color.Black;
            this.tbRelation.Location = new System.Drawing.Point(281, 114);
            this.tbRelation.MaxLength = 20;
            this.tbRelation.Name = "tbRelation";
            this.tbRelation.ReadOnly = true;
            this.tbRelation.Size = new System.Drawing.Size(117, 30);
            this.tbRelation.TabIndex = 4;
            // 
            // cbxRole
            // 
            this.cbxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRole.FormattingEnabled = true;
            this.cbxRole.Location = new System.Drawing.Point(159, 115);
            this.cbxRole.Name = "cbxRole";
            this.cbxRole.Size = new System.Drawing.Size(116, 28);
            this.cbxRole.TabIndex = 3;
            // 
            // label180
            // 
            this.label180.AutoSize = true;
            this.label180.Location = new System.Drawing.Point(13, 118);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(119, 20);
            this.label180.TabIndex = 11;
            this.label180.Text = "与户主关系:";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "注意";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.gbBoxIdCard);
            this.panel4.Controls.Add(this.groupBox45);
            this.panel4.Location = new System.Drawing.Point(53, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1400, 670);
            this.panel4.TabIndex = 2;
            // 
            // PersonRecordInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1460, 680);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblIdNo);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "PersonRecordInfoForm";
            this.Text = "PersonRecordInfoForm";
            this.Load += new System.EventHandler(this.PersonRecordInfoForm_Load);
            this.VisibleChanged += new System.EventHandler(this.PersonRecordInfoForm_VisibleChanged);
            this.gbBoxIdCard.ResumeLayout(false);
            this.gbBoxIdCard.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel34.ResumeLayout(false);
            this.panel34.PerformLayout();
            this.groupBox45.ResumeLayout(false);
            this.groupBox45.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool IsChanged(object a, object b)
        {
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] properties = a.GetType().GetProperties(bindingAttr);
            PropertyInfo[] infoArray2 = b.GetType().GetProperties(bindingAttr);
            foreach (PropertyInfo info in infoArray2)
            {
                foreach (PropertyInfo info2 in properties)
                {
                    if ((info.Name == info2.Name) && info.PropertyType.Equals(info2.PropertyType))
                    {
                        object obj2 = info.GetValue(a, null);
                        object obj3 = info2.GetValue(b, null);
                        if (((obj2 != null) && (obj3 != null)) && ((obj2 != DBNull.Value) && (obj3 != DBNull.Value)))
                        {
                            if (obj2.ToString() != obj3.ToString())
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (((obj2 == null) && (obj3 != null)) && (obj3 != DBNull.Value))
                            {
                                return true;
                            }
                            if (((obj2 != null) && (obj2 != DBNull.Value)) && (obj3 == null))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool IsEmail(string str_Email)
        {
            return Regex.IsMatch(str_Email, @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$");
        }

        public bool IsHandset(string str_handset)
        {
            return Regex.IsMatch(str_handset, @"^[1]+[0-9]+\d{9}");
        }

        public bool IsTelephone(string str_telephone)
        {
            if (!Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$"))
            {
                return Regex.IsMatch(str_telephone, @"^(\d{3,4})?\d{6,8}$");
            }
            return true;
        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            RecordsBaseInfoBLL ARCHIVE_BASEINFO = new RecordsBaseInfoBLL();
            if (this.IsChanged(this.Model, this.ModelCopy))
            {
                this.Model.IsUpdate = "Y";
            }
            ARCHIVE_BASEINFO.Update(this.Model);
            return true;
        }

        private void SimpleBinding(TextBox tb, string member)
        {
            Binding binding = new Binding("Text", this.Model, member, false, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += new ConvertEventHandler(this.bd_ParseStr);
            tb.DataBindings.Add(binding);
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            if (this.IsEmail(this.tbEmail.Text))
            {
                this.tbEmail.BackColor = Color.WhiteSmoke;
            }
            else
            {
                this.tbEmail.BackColor = Color.Salmon;
            }
        }

        private void txtbenrdh_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if ((string.IsNullOrEmpty(box.Text) || this.IsTelephone(box.Text)) || this.IsHandset(box.Text))
            {
                box.BackColor = Color.WhiteSmoke;
                box.Tag = 0;
            }
            else
            {
                box.BackColor = Color.Salmon;
                box.Tag = 1;
            }
        }

        public void UpdataToModel()
        {
            if (this.radczhj.Checked)
            {
                this.Model.LiveType = "1";
            }
            else if (this.radczfhj.Checked)
            {
                this.Model.LiveType = "2";
            }
            if (this.comboBox1.Text != "")
            {
                if (this.comboBox1.Text != "汉族")
                {

                    this.Model.Nation = Convert.ToString(2);
                    this.Model.Minority = this.comboBox1.Text;
                }
                else
                {
                    this.Model.Nation = Convert.ToString(1);
                    this.Model.Minority = this.comboBox1.Text;
                }

            }
            else
            {
                this.Model.Nation = Convert.ToString(1);
                this.Model.Minority = this.comboBox1.Text;
            }

            this.Model.LastUpdateDate = new DateTime?(DateTime.Today);
            this.Model.LastUpdateBy = ConfigHelper.GetNodeDec("doctor").ToString();
            this.Model.BloodType = this.cmbXieXin.SelectedValue == null ? null : this.cmbXieXin.SelectedValue.ToString();
            this.Model.RH = Convert.ToString((int)(this.cmbRH.SelectedIndex + 1));
            this.Model.Culture = Convert.ToString((int)(this.cmbwhcd.SelectedIndex + 1));
            this.Model.Job = Convert.ToString((int)(this.cmbzy.SelectedIndex + 1));
            this.Model.MaritalStatus = Convert.ToString((int)(this.cmbhf.SelectedIndex + 1));
            this.Model.LiveCondition = Convert.ToString((int)(this.cbZZQK.SelectedIndex + 1));
            this.Model.Disease = this.disease.Choose;
            this.Model.DiseaseEx = this.disease.Choose_EX;
            this.Model.DrugAllergic = this.guomin.GetYaoWu();
            this.Model.DrugAllergicOther = this.guomin.FinalResultEX;
            this.Model.MedicalPayType = this.zhifu.FinalResult;
            this.Model.MedicalPayTypeOther = this.zhifu.FinalResultEX;
            this.Model.DiseasEndition = this.canji.FinalResult;
            this.Model.DiseasEnditionEx = this.canji.FinalResultEX;
            if (!string.IsNullOrEmpty(this.tbFamilyNum.Text))
            {
                this.Model.FamilyNum = decimal.Parse(this.tbFamilyNum.Text);
            }
            if (this.rdYc1.Checked)
            {
                this.Model.PreSituation = "1";
            }
            else if (this.rdYc2.Checked)
            {
                this.Model.PreSituation = "2";
            }
            else if (this.rdYc3.Checked)
            {
                this.Model.PreSituation = "3";
            }
            else if (this.rdYc4.Checked)
            {
                this.Model.PreSituation = "4";
            }
            else if (this.rdYc5.Checked)
            {
                this.Model.PreSituation = "5";
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        private RecordsBaseInfoModel ModelCopy { get; set; }

        public string SaveDataInfo { get; set; }

        public string GetNation(string code)
        {
            string nationName = "";
            switch (code)
            {
                case "汉族":
                    nationName = "01";
                    break;
                case "蒙古族":
                    nationName = "02";
                    break;
                case "回族":
                    nationName = "03";
                    break;
                case "藏族":
                    nationName = "04";
                    break;
                case "维吾尔族":
                    nationName = "05";
                    break;
                case "苗族":
                    nationName = "06";
                    break;
                case "彝族":
                    nationName = "07";
                    break;
                case "壮族":
                    nationName = "08";
                    break;
                case "布依族":
                    nationName = "09";
                    break;
                case "朝鲜族":
                    nationName = "10";
                    break;
                case "满族":
                    nationName = "11";
                    break;
                case "侗族":
                    nationName = "12";
                    break;
                case "瑶族":
                    nationName = "13";
                    break;
                case "白族":
                    nationName = "14";
                    break;
                case "土家族":
                    nationName = "15";
                    break;
                case "哈尼族":
                    nationName = "16";
                    break;
                case "哈萨克族":
                    nationName = "17";
                    break;
                case "傣族":
                    nationName = "18";
                    break;
                case "黎族":
                    nationName = "19";
                    break;
                case "僳僳族":
                    nationName = "20";
                    break;
                case "佤族":
                    nationName = "21";
                    break;
                case "畲族":
                    nationName = "22";
                    break;
                case "高山族":
                    nationName = "23";
                    break;
                case "拉祜族":
                    nationName = "24";
                    break;
                case "水族":
                    nationName = "25";
                    break;
                case "东乡族":
                    nationName = "26";
                    break;
                case "纳西族":
                    nationName = "27";
                    break;
                case "景颇族":
                    nationName = "28";
                    break;
                case "柯尔克孜族":
                    nationName = "29";
                    break;
                case "土族":
                    nationName = "30";
                    break;
                case "达斡尔族":
                    nationName = "31";
                    break;
                case "仫佬族":
                    nationName = "32";
                    break;
                case "羌族":
                    nationName = "33";
                    break;
                case "布朗族":
                    nationName = "34";
                    break;
                case "撒拉族":
                    nationName = "35";
                    break;
                case "毛南族":
                    nationName = "36";
                    break;
                case "仡佬族":
                    nationName = "37";
                    break;
                case "锡伯族":
                    nationName = "38";
                    break;
                case "阿昌族":
                    nationName = "39";
                    break;
                case "普米族":
                    nationName = "40";
                    break;
                case "塔吉克族":
                    nationName = "41";
                    break;
                case "怒族":
                    nationName = "42";
                    break;
                case "乌孜别克族":
                    nationName = "43";
                    break;
                case "俄罗斯族":
                    nationName = "44";
                    break;
                case "鄂温克族":
                    nationName = "45";
                    break;
                case "崩龙族":
                    nationName = "46";
                    break;
                case "保安族":
                    nationName = "47";
                    break;
                case "裕固族":
                    nationName = "48";
                    break;
                case "京族":
                    nationName = "49";
                    break;
                case "塔塔尔族":
                    nationName = "50";
                    break;
                case "独龙族":
                    nationName = "51";
                    break;
                case "鄂伦春族":
                    nationName = "52";
                    break;
                case "赫哲族":
                    nationName = "53";
                    break;
                case "门巴族":
                    nationName = "54";
                    break;
                case "珞巴族":
                    nationName = "55";
                    break;
                case "基诺族":
                    nationName = "56";
                    break;
                case "其他":
                    nationName = "57";
                    break;
                case "外国血统":
                    nationName = "58";
                    break;
                default:
                    nationName = "01";
                    break;
            }

            return nationName;
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            KidsInfoForm KidForm = new KidsInfoForm(this.Model)
            {
                FormBorderStyle = FormBorderStyle.Sizable,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "儿童管理卡",
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false
            };
            if (KidForm.ShowDialog() == DialogResult.OK)
            {
                this.tbFamBossIDCARD.Text = this.Model.FamilyIDCardNo;
                this.tbFamBossName.Text = this.Model.CustomerName;
                if (!string.IsNullOrEmpty(this.Model.FamilyIDCardNo))
                {
                    this.btnFind.Text = "解除与家庭关联";
                    //if (this.Model.HouseRelation == "1")
                    //{
                    //    this.cbxRole.Enabled = false;
                    //}
                }
                else
                {
                    //this.cbxRole.Enabled = false;
                    //this.cbZZQK.Enabled = false;
                }
            }
        }

        private void c1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.c1.Checked)
            {
                this.tbCard1.ReadOnly = false;
                if (string.IsNullOrEmpty(this.tbCard1.Text))
                {
                    this.tbCard1.Text = this.Model.IDCardNo;
                }
            }
            else
            {
                this.tbCard1.Clear();
                this.tbCard1.ReadOnly = true;
            }
        }

        private void c2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.c2.Checked)
            {
                this.tbCard2.ReadOnly = false;
                if (string.IsNullOrEmpty(tbCard2.Text))
                {
                    this.tbCard2.Text = this.Model.IDCardNo;
                }
            }
            else
            {
                this.tbCard2.Clear();
                this.tbCard2.ReadOnly = true;
            }
        }

        private void c4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.c4.Checked)
            {
                this.tbCard3.ReadOnly = false;
                if (string.IsNullOrEmpty(this.tbCard3.Text))
                {
                    this.tbCard3.Text = this.Model.IDCardNo;
                }
            }
            else
            {
                this.tbCard3.Clear();
                this.tbCard3.ReadOnly = true;
            }
        }

        private void rdYc1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdYc1.Checked)
            {
                this.cmbYC.SelectedIndex = -1;
                this.cmbCC.SelectedIndex = -1;
                this.cmbYC.Enabled = false;
                this.cmbCC.Enabled = false;
            }
            else
            {
                this.cmbYC.Enabled = true;
                this.cmbCC.Enabled = true;
            }
        }

        private void ckGroup3_CheckedChanged(object sender, EventArgs e)
        {
            if (ckGroup3.Checked)
            {
                this.panel2.Enabled = true;
            }
            else
            {
                this.panel2.Enabled = false;
                this.rdYc1.Checked = false;
                this.rdYc2.Checked = false;
                this.rdYc3.Checked = false;
                this.rdYc4.Checked = false;
                this.rdYc5.Checked = false;
                this.cmbYC.SelectedIndex = -1;
                this.cmbCC.SelectedIndex = -1;
            }
        }

    }
}

