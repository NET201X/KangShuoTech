using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HealthHouse
{
    public partial class HealthHouseForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private HealthHouseBLL healthHouseBLL = new HealthHouseBLL();
        private HHBoneBLL hhBoneBLL = new HHBoneBLL();
        private HHCardiovascularBLL hhCardiovascularBLL = new HHCardiovascularBLL();
        private HHLungBLL hhLungBLL = new HHLungBLL();
        private StringPlus stringTool = new StringPlus();
        private SimpleBindingManager<HealthHouseModel> bindingManager;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private int n, m;
        private string LRType = ConfigurationManager.AppSettings["LRType"] != null ?
            ConfigurationManager.AppSettings["LRType"].ToString() : ""; // 取得设定的左侧或右侧血压

        private HealthHouseModel healthHouserModel { get; set; }

        public RecordsBaseInfoModel Model { get; set; }
        
        public HealthHouseForm()
        {
            InitializeComponent();

            Random ran = new Random();

            n = ran.Next(1, 8);
            m = 0;

            while (m < n)
            {
                m = ran.Next(1, 8);
            }

            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("Doctor", 30));
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("PulseRate", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Weight", 2000M, true));
            this.inputRanges.Add(new InputRangeDec("LeftPre", 300M, false));
            this.inputRanges.Add(new InputRangeDec("LeftHeight", 300M, false));
            this.inputRanges.Add(new InputRangeDec("RightPre", 300M, false));
            this.inputRanges.Add(new InputRangeDec("RightHeight", 300M, false));
            this.inputRanges.Add(new InputRangeDec("BMI", 1000M));
            this.inputRanges.Add(new InputRangeDec("Height", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("LeftView", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("RightView", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("LeftEyecorrect", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("RightEyecorrect", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Fat", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Water", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Muscle", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Skeleton", 1000M, false));
            this.inputRanges.Add(new InputRangeDec("Calorie", 1000M, false)); 

        }

        public ChildFormStatus CheckErrorInput()
        {
            if (!this.bindingManager.ErrorInput)
            {
                return ChildFormStatus.NoErrorInput;
            }

            return ChildFormStatus.NoErrorInput;
        }

        public void InitEveryThing()
        {
            if (HealthHouseFactory.ID == 0) //新增加时
            {
                string checkDate = DateTime.Today.ToString("yyyy-MM-dd");
                this.dtpCheckDate.Value = DateTime.Today;
                // 取得当前日期是否有查体资料
                healthHouserModel = healthHouseBLL.GetData(this.Model.IDCardNo,checkDate);
            }
            else //查询已有数据
            {
                this.healthHouserModel = healthHouseBLL.GetDataByID(HealthHouseFactory.ID);
            }
          
            if (healthHouserModel == null)
            {
                healthHouserModel = new HealthHouseModel();

                this.healthHouserModel.IDCardNo = this.Model.IDCardNo;
                this.healthHouserModel.Doctor = ConfigHelper.GetNode("doctorName");
                this.healthHouserModel.CreateBy = ConfigHelper.GetNode("doctor");
                this.healthHouserModel.CreateDate = new DateTime?(DateTime.Today);
            }
            else
            {
                HealthHouseFactory.ID = this.healthHouserModel.ID;
                this.dtpCheckDate.Value = this.healthHouserModel.CheckDate.Value;
            }

            this.healthHouserModel.UpdataBy = ConfigHelper.GetNode("doctor");
            this.healthHouserModel.UpdateDate = new DateTime?(DateTime.Today);

            this.bindingManager = new SimpleBindingManager<HealthHouseModel>(this.inputRanges, this.inputrange_str,
                this.healthHouserModel);

            this.SimpleBindingC(this.txtDoctor, "Doctor", false);
            this.bindingManager.SimpleBinding(this.txtBMI, "BMI", true);
            this.bindingManager.SimpleBinding(this.txtHeight, "Height", true);
            this.bindingManager.SimpleBinding(this.txtLeftHeight, "LeftHeight", true);
            this.bindingManager.SimpleBinding(this.txtLeftPre, "LeftPre", true);
            this.bindingManager.SimpleBinding(this.txtRightHeight, "RightHeight", true);
            this.bindingManager.SimpleBinding(this.txtRightPre, "RightPre", true);
            this.bindingManager.SimpleBinding(this.txtPulseRate, "PulseRate", true);
            this.bindingManager.SimpleBinding(this.txtWeight, "Weight", true);
            this.bindingManager.SimpleBinding(this.txtBloodOxygen, "BloodOxygen", true);
            this.bindingManager.SimpleBinding(this.txtleftsl, "LeftView", true);
            this.bindingManager.SimpleBinding(this.txtrightsl, "RightView", true);
            this.bindingManager.SimpleBinding(this.txtjzleft, "LeftEyecorrect", true);
            this.bindingManager.SimpleBinding(this.txtjzrightsl, "RightEyecorrect", true);
            this.bindingManager.SimpleBinding(this.tbFat, "Fat", true);
            this.bindingManager.SimpleBinding(this.tbWater, "Water", true);
            this.bindingManager.SimpleBinding(this.tbMuscle, "Muscle", true);
            this.bindingManager.SimpleBinding(this.tbSkeleton, "Skeleton", true);
            this.bindingManager.SimpleBinding(this.tbCalorie, "Calorie", true);
            this.txtName.Text = this.Model.CustomerName;

            this.EveryThingIsOk = true;
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

        private void SimpleBindingC(TextBox tb, string srcMember, bool isFormate)
        {
            Binding binding = new Binding("Text", this.healthHouserModel, srcMember, isFormate, DataSourceUpdateMode.OnPropertyChanged);
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

        public bool SaveModelToDB()
        {
            bool result = true;

            try
            {
                HealthHouseModel houseModelTem = healthHouseBLL.GetData(this.Model.IDCardNo, Convert.ToString(this.dtpCheckDate.Value));
                if (HealthHouseFactory.ID > 0)//修改时
                {
                    if (houseModelTem!=null&&HealthHouseFactory.ID != houseModelTem.ID)//修改的体检日期下有数据，删除原来数据，在更新此次数据
                    {
                        healthHouseBLL.Delete(houseModelTem.ID);
                    }
                    healthHouseBLL.Update(healthHouserModel);//更新数据
                }
                else//新增加时
                {
                    if (houseModelTem == null) //此日期下无数据
                    {
                        healthHouserModel.ID = healthHouseBLL.Insert(healthHouserModel);
                        HealthHouseFactory.ID = healthHouserModel.ID;
                    }
                    else
                    {
                        healthHouseBLL.Update(healthHouserModel);//更新数据
                    }
                }
               
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }

            return result;
        }

        public void NotisfyChildStatus()
        {
        }

        public void UpdataToModel()
        {
            this.healthHouserModel.CheckDate = new DateTime?(this.dtpCheckDate.Value);
            this.healthHouserModel.UpdataBy = ConfigHelper.GetNode("doctor");
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }
        /// <summary>
        /// 画面加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HealthHouseForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        #region 重置按钮事件

 

        #endregion

        /// <summary>
        /// 身高按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHeight_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "39")
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (select.ShowDialog() == DialogResult.OK)
            {
                this.txtHeight.Text = select.m_Result.value1;
            }
        }

        /// <summary>
        /// 体重按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWeight_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "22")
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (select.ShowDialog() == DialogResult.OK)
            {
                this.txtWeight.Text = select.m_Result.value1;
            }
        }

        /// <summary>
        /// 体质指数计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBMI_Click(object sender, EventArgs e)
        {
            decimal num, num2;

            if ((decimal.TryParse(this.txtHeight.Text, out num) && decimal.TryParse(this.txtWeight.Text, out num2)) && (num != 0M))
            {
                decimal num3 = num / 100M;
                decimal num4 = num3 * num3;

                this.txtBMI.Text = (num2 / num4).ToString(".00");
            }
        }

        /// <summary>
        /// 脉率按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPulseRate_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "32")
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (select.ShowDialog() == DialogResult.OK)
            {
                this.txtBloodOxygen.Text = select.m_Result.value1;
                this.txtPulseRate.Text = select.m_Result.value2;
            }
        }

        /// <summary>
        /// 血氧按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodOxygen_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "32")
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (select.ShowDialog() == DialogResult.OK)
            {
                this.txtBloodOxygen.Text = select.m_Result.value1;
                this.txtPulseRate.Text = select.m_Result.value2;
            }
        }

        /// <summary>
        /// 左侧血压按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "20")
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (select.ShowDialog() == DialogResult.OK)
            {
                // 根据设定值判断为左侧血压(L)还是右侧血压(R)
                if (LRType.Equals("L"))
                {
                    this.healthHouserModel.LeftHeight = new decimal?(int.Parse(select.m_Result.value1));
                    this.healthHouserModel.LeftPre = new decimal?(int.Parse(select.m_Result.value2));
                }
                else
                {
                    this.healthHouserModel.LeftHeight = new decimal?((int.Parse(select.m_Result.value1) - m));
                    this.healthHouserModel.LeftPre = new decimal?((int.Parse(select.m_Result.value2) - n));
                }

                this.txtLeftHeight.Text = this.healthHouserModel.LeftHeight.ToString();
                this.txtLeftPre.Text = this.healthHouserModel.LeftPre.ToString();
                this.txtPulseRate.Text = select.m_Result.value3;
            }
        }

        /// <summary>
        /// 右侧血压按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "20")
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (select.ShowDialog() == DialogResult.OK)
            {
                // 根据设定值判断为左侧血压(L)还是右侧血压(R)
                if (LRType.Equals("L"))
                {
                    this.healthHouserModel.RightHeight = new decimal?((int.Parse(select.m_Result.value1) + m));
                    this.healthHouserModel.RightPre = new decimal?((int.Parse(select.m_Result.value2) + n));
                }
                else
                {
                    this.healthHouserModel.RightHeight = new decimal?(int.Parse(select.m_Result.value1));
                    this.healthHouserModel.RightPre = new decimal?(int.Parse(select.m_Result.value2));
                }

                this.txtRightHeight.Text = this.healthHouserModel.RightHeight.ToString();
                this.txtRightPre.Text = this.healthHouserModel.RightPre.ToString();
                this.txtPulseRate.Text = select.m_Result.value3;
            }
        }

        /// <summary>
        /// 抓取蓝牙上传资料
        /// </summary>
        /// <param name="msg"></param>
        public override void UpdateDeviceinfoContent(int msg)
        {
            switch (msg)
            {
                case 0x597:
                    stru_result _result = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "20", "血压");

                    if (_result.HasValue)
                    {
                        this.healthHouserModel.PulseRate = new decimal?(int.Parse(_result.value3));

                        // 根据设定值判断为左侧血压(L)还是右侧血压(R)
                        if (LRType.Equals("L"))
                        {
                            this.healthHouserModel.LeftHeight = new decimal?(int.Parse(_result.value1));
                            this.healthHouserModel.LeftPre = new decimal?(int.Parse(_result.value2));
                            this.healthHouserModel.RightHeight = new decimal?((int.Parse(_result.value1) + m));
                            this.healthHouserModel.RightPre = new decimal?((int.Parse(_result.value2) + n));
                        }
                        else
                        {
                            this.healthHouserModel.RightHeight = new decimal?(int.Parse(_result.value1));
                            this.healthHouserModel.RightPre = new decimal?(int.Parse(_result.value2));
                            this.healthHouserModel.LeftHeight = new decimal?((int.Parse(_result.value1) - m));
                            this.healthHouserModel.LeftPre = new decimal?((int.Parse(_result.value2) - n));
                        }

                        this.txtRightHeight.Text = this.healthHouserModel.RightHeight.ToString();
                        this.txtRightPre.Text = this.healthHouserModel.RightPre.ToString();
                        this.txtLeftHeight.Text = this.healthHouserModel.LeftHeight.ToString();
                        this.txtLeftPre.Text = this.healthHouserModel.LeftPre.ToString();
                        this.txtPulseRate.Text = _result.value3;
                    }

                    return;

                case 0x598:
                    // 身高
                    stru_result devData = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "39");

                    if (devData.HasValue) this.txtHeight.Text = devData.value1;

                    return;

                case 0x599:
                case 0x59b:
                    break;

                case 0x59a:
                    // 血氧
                    stru_result _result3 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "32");

                    if (_result3.HasValue && _result3.value2 != "0")
                    {
                        this.txtBloodOxygen.Text = _result3.value1;
                        this.txtPulseRate.Text = _result3.value2;
                    }

                    return;

                case 0x59c:
                    // 体重
                    stru_result _result4 = ClsGetDevInfo.GetDevData(this.Model.IDCardNo, "22");

                    if (_result4.HasValue) this.txtWeight.Text = _result4.value1;

                    return;

                default:
                    return;
            }
        }
    }
}
