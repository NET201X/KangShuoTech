using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.Utilities.Common;

namespace HealthHouse
{
    public partial class HealthAssessExamenForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private CMoreChange jzjbs;
        private CMoreChange jbs;
        private CMoreChange ysxg;
        private CMoreChange dlfs;
        private HealthAssessExamModel AExamModel { get; set; }
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr>();
        private List<InputRangeDec> inputRanges = new List<InputRangeDec>();
        private SimpleBindingManager<HealthAssessExamModel> bindingManager;
        public HealthSelfCareabilityModel HSelfModel { get; set; }
        private TimeParser timeParser = new TimeParser();

        public HealthAssessExamenForm()
        {
            InitializeComponent();
            this.EveryThingIsOk = false;
            this.inputRanges.Add(new InputRangeDec("ExerciseTimes", 1000M, false));

        }
        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }
        public void InitEveryThing()
        {
            this.AExamModel = new HealthAssessExamBLL().GetModel(HealthAssessFactory.ID);
            if (this.AExamModel == null)
            {
                this.AExamModel = new HealthAssessExamModel { IDCardNo = this.Model.IDCardNo };
            }

            // 获取病人是否有健康指导
            HealthHouseModel houseModel = new HealthHouseBLL().GetMaxData(this.Model.IDCardNo);
            RecordsBaseInfoModel baseInfo = new RecordsBaseInfoBLL().GetModel(this.Model.IDCardNo);  // 体检人基本信息

            this.lbName.Text = baseInfo.CustomerName;
            this.lbData.Text = houseModel.CheckDate.Value.ToString("yyyy-MM-dd");
            this.lblAge.Text = timeParser.GetAge(baseInfo.Birthday);
            this.lblSex.Text = StringPlus.GetSex(baseInfo.Sex);

            CMoreChange change = new CMoreChange
           {
               MoreChange = this.cbFamilySick,
               Name = "家庭疾病史",
               Unusual = "无",
               Other = this.tbFamilySick,
               MaxBytesCount = 200
           };
            this.jzjbs = change;
            this.jzjbs.TransInfo(this.AExamModel.FamilyHistory, this.AExamModel.FamilyOther);
            CMoreChange change1 = new CMoreChange
            {
                MoreChange = this.cbSick,
                Name = "疾病史",
                Unusual = "无",
                Other = this.tbcbSick,
                MaxBytesCount = 200
            };
            this.jbs = change1;
            this.jbs.TransInfo(this.AExamModel.MedicalHistory, this.AExamModel.MedicalOther);
            CMoreChange change3 = new CMoreChange
            {
                MoreChange = this.cbdlfs,
                Name = "锻炼方式",
                Other = this.tbdlfs,
                MaxBytesCount = 200
            };
            this.dlfs = change3;
            this.dlfs.TransInfo(this.AExamModel.ExerciseExistense, this.AExamModel.ExerciseExistenseOther);

            this.bindingManager = new SimpleBindingManager<HealthAssessExamModel>(this.inputRanges, this.inputrange_str,
                this.AExamModel);
            this.bindingManager.SimpleBinding(this.txtMint, "ExerciseTimes", true);
            this.bindingManager.SimpleBinding(this.tbScore, "GloomyScore", true);
            this.bindingManager.SimpleBinding(this.tbDietOther, "DietaryOther", false);

            SetCom(this.cbDietCout, this.AExamModel.DietaryNum);
            SetCom(this.cbDietRe, this.AExamModel.DietaryLaw);
            SetCom(this.cmbduanlianpinlv, this.AExamModel.ExerciseRate);
            SetCom(this.cbzys, this.AExamModel.HospitalHistory);
            SetCom(this.cbfy, this.AExamModel.TakingMedicine);
            SetCom(this.cmbzilinengli, this.AExamModel.OldSelfCareability);

            this.TransHabit();//饮食习惯

            if (this.Model.PopulationType.Contains("4"))
            {
                this.gpOld.Enabled = true;
            }
            else
            {
                this.gpOld.Enabled = false;
            }

            //老年人自理能力
            this.HSelfModel = new HealthSelfCareabilityBLL().GetModel(this.AExamModel.PID);
            this.EveryThingIsOk = true;
        }
        public bool SaveModelToDB()
        {
            HealthAssessExamBLL Exambll = new HealthAssessExamBLL();
            HealthSelfCareabilityBLL HCarebll = new HealthSelfCareabilityBLL();
            this.AExamModel.PID = HealthAssessFactory.ID;

            if (Exambll.ExistsPID(this.Model.IDCardNo, HealthAssessFactory.ID))
            {
                Exambll.Update(this.AExamModel);
            }
            else
            {
                Exambll.Add(this.AExamModel);
            }
            if (this.HSelfModel != null)
            {
                this.HSelfModel.PID = HealthAssessFactory.ID;
                if (HCarebll.ExistsPID(this.Model.IDCardNo, HealthAssessFactory.ID))
                {
                    HCarebll.Update(this.HSelfModel);
                }
                else
                {
                    HCarebll.Add(this.HSelfModel);
                }
            }
            return true;
        }
        public void NotisfyChildStatus()
        {

        }
        public void UpdataToModel()
        {
            string str = "";
            for (int i = 0; i < this.cbDiet.Items.Count; i++)
            {
                if (this.cbDiet.GetItemChecked(i))
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
            this.AExamModel.DietaryHabit = str;
            this.AExamModel.MedicalHistory = this.jbs.FinalResult;
            this.AExamModel.MedicalOther = this.jbs.FinalResultEX;
            this.AExamModel.FamilyHistory = this.jzjbs.FinalResult;
            this.AExamModel.FamilyOther = this.jzjbs.FinalResultEX;
            this.AExamModel.ExerciseExistense = this.dlfs.FinalResult;
            this.AExamModel.ExerciseExistenseOther = this.dlfs.FinalResultEX;
            this.AExamModel.DietaryNum = GetCom(this.cbDietCout).ToString();
            this.AExamModel.DietaryLaw = GetCom(this.cbDietRe).ToString();
            this.AExamModel.ExerciseRate = GetCom(this.cmbduanlianpinlv).ToString();
            this.AExamModel.HospitalHistory = GetCom(this.cbzys).ToString();
            this.AExamModel.TakingMedicine = GetCom(this.cbfy).ToString();
            this.AExamModel.OldSelfCareability = GetCom(this.cmbzilinengli).ToString();

        }
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }
        /// <summary>
        /// 饮食习惯
        /// </summary>
        private void TransHabit()
        {
            if (!string.IsNullOrEmpty(this.AExamModel.DietaryHabit))
            {
                string eATHOBBY = this.AExamModel.DietaryHabit;
                char[] separator = new char[] { ',' };
                foreach (string str2 in eATHOBBY.Split(separator))
                {
                    int num;
                    if (int.TryParse(str2, out num))
                    {
                        this.cbDiet.SetItemChecked(num - 1, true);
                    }
                }
            }
            else
            {
                this.cbDiet.SetItemChecked(0, true);
            }
        }
        private void HealthAssessExamenForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }
        public void SimpleBinding(TextBox tb, string member, bool formate)
        {
            Binding item = new Binding("Text", this.Model, member, formate, DataSourceUpdateMode.OnPropertyChanged);
            if (formate)
            {
                item.Parse += new ConvertEventHandler(this.bd_Parse);
            }
            else
            {
                item.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
            tb.DataBindings.Add(item);
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
        private void SetCom(ComboBox cb, object num)
        {
            if (num != null && num != "")
            {
                cb.SelectedIndex = int.Parse(num.ToString()) - 1;

            }
            else
            {
                cb.SelectedIndex = -1;
            }

        }
        public string GetCom(ComboBox cb)
        {
            if (cb.SelectedIndex == -1)
            {
                return "";
            }
            else
            {
                return (cb.SelectedIndex + 1).ToString();
            }
        }

        private void lkbOld_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OldPeopleInfoForm info = new OldPeopleInfoForm(this.Model)
            {
                HelderSelf = this.HSelfModel,
                ShowIcon = false,
                ShowInTaskbar = false,
                MaximizeBox = false,
                MinimizeBox = false,
                Text = "老年人生活自理能力评估表",
                //FormBorderStyle = FormBorderStyle.Sizable,
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
                this.HSelfModel = info.HelderSelf;
                this.tbScore.Text = this.HSelfModel.TotalScore.ToString();
            }
        }
    }
}
