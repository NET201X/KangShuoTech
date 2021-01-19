using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;

namespace ArchiveInfo
{
    public partial class frmHealthRefresh : Form
    {
        string community = ConfigHelper.GetSetNode("community");
        string area = ConfigHelper.GetSetNode("area");
        private HealthAssessment healthAssessment;
        private OlderCnAndResult olderCnandResult;

        public frmHealthRefresh()
        {
            InitializeComponent();
        }

        private void btndataupload_Click(object sender, EventArgs e)
        {
            string strwhere = "";

            if (this.ckbcheckdate.Checked)
            {
                strwhere = string.Format(" CheckDate BETWEEN '{0}' and '{1}' ",
                    this.dtpstart.Value.Date.ToString("yyyy-MM-dd"), this.dtpend.Value.Date.ToString("yyyy-MM-dd"));
            }

            DataSet customds = new RecordsCustomerBaseInfoBLL().GetList(strwhere);

            int amount = 0;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = customds.Tables[0].Rows.Count;
            progressBar1.BackColor = Color.Green;
            labCountnum.Text = customds.Tables[0].Rows.Count.ToString();

            foreach (DataRow row in customds.Tables[0].Rows)
            {
                if (string.IsNullOrEmpty(row["IDCardNo"].ToString())) continue;

                int OutKey = Convert.ToInt32(row["ID"].ToString());

                // 基本信息
                this.Model = new RecordsBaseInfoBLL().GetModel(row["IDCardNo"].ToString());
                if (this.Model == null)
                {
                    this.Model = new RecordsBaseInfoModel();
                }

                // 健康评价
                this.AssessmentGuides = new RecordsAssessmentGuideBLL().GetModelByOutKey(OutKey);

                if (this.AssessmentGuides == null)
                {
                    this.AssessmentGuides = new RecordsAssessmentGuideModel();
                }

                this.AssessmentGuides.IDCardNo = this.Model.IDCardNo;

                // 辅助检查
                this.AssistCheck = new RecordsAssistCheckBLL().GetModelByOutKey(OutKey);
                if (this.AssistCheck == null)
                {
                    this.AssistCheck = new RecordsAssistCheckModel();
                }

                // 一般状况
                this.generalconditionmodel = new RecordsGeneralConditionBLL().GetModelByOutKey(OutKey);
                if (this.generalconditionmodel == null)
                {
                    this.generalconditionmodel = new RecordsGeneralConditionModel();
                }

                // 查体
                this.physicalModel = new RecordsPhysicalExamBLL().GetModelByOutKey(OutKey);
                if (this.physicalModel == null)
                {
                    this.physicalModel = new RecordsPhysicalExamModel();
                }

                // 现存健康问题
                this.questionModel = new RecordsHealthQuestionBLL().GetModelByOutKey(OutKey);
                if (this.questionModel == null)
                {
                    this.questionModel = new RecordsHealthQuestionModel();
                }

                // 生活方式
                this.liftModel = new RecordsLifeStyleBLL().GetModelByOutKey(OutKey);
                if (this.liftModel == null)
                {
                    this.liftModel = new RecordsLifeStyleModel();
                }

                //脏器功能
                this.visceraFunctionModel = new RecordsVisceraFunctionBLL().GetModelByOutKey(OutKey);
                if (this.visceraFunctionModel == null)
                {
                    this.visceraFunctionModel = new RecordsVisceraFunctionModel();
                }
                AssessmentGuides.IsNormal = "1";
                AssessmentGuides.Exception1 = null;
                AssessmentGuides.Exception2 = null;
                AssessmentGuides.Exception3 = null;
                AssessmentGuides.Exception4 = null;
                AssessmentGuides.HealthGuide = null;
                AssessmentGuides.DangerControl = null;
                AssessmentGuides.Arm = null;
                AssessmentGuides.VaccineAdvice = null;
                AssessmentGuides.Other = null;
                AssessmentGuides.WaistlineArm = null;

                #region  赋值给RecordsManageMentModel

                RecordsManageMentModel.Symptom = row["Symptom"].ToString();
                RecordsManageMentModel.Other = row["Other"].ToString();
                RecordsManageMentModel.BMI = this.generalconditionmodel.BMI;
                RecordsManageMentModel.RightHeight = this.generalconditionmodel.RightHeight;
                RecordsManageMentModel.RightPre = this.generalconditionmodel.RightPre;
                RecordsManageMentModel.LeftHeight = this.generalconditionmodel.LeftHeight;
                RecordsManageMentModel.LeftPre = this.generalconditionmodel.LeftPre;
                RecordsManageMentModel.Waistline = this.generalconditionmodel.Waistline;
                RecordsManageMentModel.Height = this.generalconditionmodel.Height;
                RecordsManageMentModel.PulseRate = this.generalconditionmodel.PulseRate;
                RecordsManageMentModel.Weight = this.generalconditionmodel.Weight;
                RecordsManageMentModel.OldSelfCareability = this.generalconditionmodel.OldSelfCareability;
                RecordsManageMentModel.DrinkRate = this.liftModel.DrinkRate;
                RecordsManageMentModel.SmokeCondition = this.liftModel.SmokeCondition;
                RecordsManageMentModel.ExerciseRate = this.liftModel.ExerciseRate;

                if (this.liftModel.ExerciseTimes.HasValue)
                {
                    RecordsManageMentModel.ExerciseTimes = this.liftModel.ExerciseTimes.ToString();
                }
                else
                {
                    RecordsManageMentModel.ExerciseTimes = "";
                }

                RecordsManageMentModel.DietaryHabit = this.liftModel.DietaryHabit;
                RecordsManageMentModel.ECG = this.AssistCheck.ECG;
                RecordsManageMentModel.ECGEx = "";

                if (!string.IsNullOrEmpty(this.AssistCheck.ECG))
                {
                    if (this.AssistCheck.ECG.Contains("2"))
                    {
                        RecordsManageMentModel.ECGEx += "ST-T改变,";
                    }
                    if (this.AssistCheck.ECG.Contains("3"))
                    {
                        RecordsManageMentModel.ECGEx += "陈旧性心肌梗塞,";
                    }
                    if (this.AssistCheck.ECG.Contains("4"))
                    {
                        RecordsManageMentModel.ECGEx += "窦性心动过速,";
                    }
                    if (this.AssistCheck.ECG.Contains("5"))
                    {
                        RecordsManageMentModel.ECGEx += "窦性心动过缓,";
                    }
                    if (this.AssistCheck.ECG.Contains("6"))
                    {
                        RecordsManageMentModel.ECGEx += "早搏,";
                    }
                    if (this.AssistCheck.ECG.Contains("7"))
                    {
                        RecordsManageMentModel.ECGEx += "房颤,";
                    }
                    if (this.AssistCheck.ECG.Contains("8"))
                    {
                        RecordsManageMentModel.ECGEx += "房室传导阻滞,";
                    }
                    if (this.AssistCheck.ECG.Contains("9"))
                    {
                        RecordsManageMentModel.ECGEx += this.AssistCheck.ECGEx;
                    }
                }
                else RecordsManageMentModel.ECGEx = "";

                RecordsManageMentModel.BCHAO = this.AssistCheck.BCHAO;
                RecordsManageMentModel.BCHAOEx = this.AssistCheck.BCHAOEx;
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
                RecordsManageMentModel.HCY = this.AssistCheck.HCY;
                RecordsManageMentModel.Other = this.AssistCheck.Other;

                if (community.Equals("威海美年大健康") && StringPlus.toString(this.AssistCheck.UA) != "")
                {
                    RecordsManageMentModel.UA = this.AssistCheck.UA;
                }

                RecordsManageMentModel.BrainDis = this.questionModel.BrainDis;
                RecordsManageMentModel.RenalDis = this.questionModel.RenalDis;
                RecordsManageMentModel.HeartDis = this.questionModel.HeartDis;
                RecordsManageMentModel.EyeDis = this.questionModel.EyeDis;
                RecordsManageMentModel.NerveDis = this.questionModel.NerveDis;
                RecordsManageMentModel.ElseDis = this.questionModel.ElseDis;
                RecordsManageMentModel.BrainOther = this.questionModel.BrainOther;
                RecordsManageMentModel.RenalOther = this.questionModel.RenalOther;
                RecordsManageMentModel.HeartOther = this.questionModel.HeartOther;
                RecordsManageMentModel.EyeOther = this.questionModel.EyeOther;
                RecordsManageMentModel.NerveOther = this.questionModel.NerveOther;
                RecordsManageMentModel.ElseOther = this.questionModel.ElseOther;
                RecordsManageMentModel.BarrelChest = this.physicalModel.BarrelChest;//桶状胸
                RecordsManageMentModel.BreathSounds = this.physicalModel.BreastEx;//呼吸音
                RecordsManageMentModel.Rale = this.physicalModel.Rale;//罗音
                RecordsManageMentModel.HeartRhythm = this.physicalModel.HeartRhythm;//心律
                RecordsManageMentModel.Noise = this.physicalModel.Noise;//杂音
                RecordsManageMentModel.PressPain = this.physicalModel.PressPain;//压痛
                RecordsManageMentModel.EnclosedMass = this.physicalModel.EnclosedMass;//包块
                RecordsManageMentModel.Liver = this.physicalModel.Liver;//肝大
                RecordsManageMentModel.Spleen = this.physicalModel.Spleen;//脾大
                RecordsManageMentModel.Voiced = this.physicalModel.Voiced;//移动性浊音
                RecordsManageMentModel.FootBack = this.physicalModel.FootBack;//足背动脉搏动
                RecordsManageMentModel.Edema = this.physicalModel.Edema;// 下肢水肿
                RecordsManageMentModel.LeftView = this.visceraFunctionModel.LeftView;
                RecordsManageMentModel.RightView = this.visceraFunctionModel.RightView;
                RecordsManageMentModel.HeartRate = this.physicalModel.HeartRate;
                RecordsManageMentModel.Listen = visceraFunctionModel.Listen;
                RecordsManageMentModel.SportFunction = visceraFunctionModel.SportFunction;

                #endregion

                healthAssessment = new HealthAssessment { Model = this.Model };
                olderCnandResult = new OlderCnAndResult();

                // 异常信息
                this.AssessmentGuides = healthAssessment.SetHealthEx(this.AssessmentGuides);

                // 危险因素控制
                this.AssessmentGuides = healthAssessment.SetDangerous(this.AssessmentGuides);

                //随访中医辨识更新
                olderCnandResult.SetCnResult(row["IDCardNo"].ToString());

                // 健康评价异常的更新
                if (this.AssessmentGuides != null)
                {
                    this.AssessmentGuides.OutKey = OutKey;
                    RecordsAssessmentGuideBLL recordsAssessmentGuideBll = new RecordsAssessmentGuideBLL();
                    if (!recordsAssessmentGuideBll.ExistsOutKey(this.AssessmentGuides.IDCardNo, OutKey))
                    {

                        if (recordsAssessmentGuideBll.Add(this.AssessmentGuides) > 0)
                        {
                            amount++;
                            labUploadnum.Text = amount.ToString();
                            progressBar1.Value = amount;
                        }
                    }
                    else
                    {
                        if (recordsAssessmentGuideBll.Update(this.AssessmentGuides))
                        {
                            amount++;
                            labUploadnum.Text = amount.ToString();
                            progressBar1.Value = amount;
                        }
                    }
                }
            }

            MessageBox.Show("成功匹配：" + amount + "条数据！", "提示");
            progressBar1.Visible = false;
        }

        /// <summary>
        /// 字串Null转换为空白
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string toString(object value)
        {
            if (value == null) return "";
            else return value.ToString();
        }

        private void ckbcheckdate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbcheckdate.Checked)
            {
                this.dtpstart.Enabled = true;
                this.dtpend.Enabled = true;
            }
            else
            {
                this.dtpstart.Enabled = false;
                this.dtpend.Enabled = false;
            }
        }

        public RecordsCustomerBaseInfoModel CustomerBaseInfo { get; set; }

        public RecordsAssessmentGuideModel AssessmentGuides { get; set; }

        public RecordsAssistCheckModel AssistCheck { get; set; }

        public RecordsGeneralConditionModel generalconditionmodel { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public RecordsLifeStyleModel liftModel { get; set; }

        public RecordsPhysicalExamModel physicalModel { get; set; }

        public RecordsHealthQuestionModel questionModel { get; set; }
        public RecordsVisceraFunctionModel visceraFunctionModel { get; set; }

        private void pictureBoxDataupload_Click(object sender, EventArgs e)
        {
            string strwhere = "";

            if (this.ckbcheckdate.Checked)
            {
                strwhere = string.Format(" CheckDate BETWEEN '{0}' and '{1}' ",
                    this.dtpstart.Value.Date.ToString("yyyy-MM-dd"), this.dtpend.Value.Date.ToString("yyyy-MM-dd"));
            }

            DataSet customds = new RecordsCustomerBaseInfoBLL().GetList(strwhere);

            int amount = 0;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = customds.Tables[0].Rows.Count;
            progressBar1.BackColor = Color.Green;
            labCountnum.Text = customds.Tables[0].Rows.Count.ToString();

            foreach (DataRow row in customds.Tables[0].Rows)
            {
                if (string.IsNullOrEmpty(row["IDCardNo"].ToString())) continue;

                int OutKey = Convert.ToInt32(row["ID"].ToString());

                // 基本信息
                this.Model = new RecordsBaseInfoBLL().GetModel(row["IDCardNo"].ToString());
                if (this.Model == null)
                {
                    this.Model = new RecordsBaseInfoModel();
                }

                // 健康评价
                this.AssessmentGuides = new RecordsAssessmentGuideBLL().GetModelByOutKey(OutKey);

                if (this.AssessmentGuides == null)
                {
                    this.AssessmentGuides = new RecordsAssessmentGuideModel();
                }

                this.AssessmentGuides.IDCardNo = this.Model.IDCardNo;

                // 辅助检查
                this.AssistCheck = new RecordsAssistCheckBLL().GetModelByOutKey(OutKey);
                if (this.AssistCheck == null)
                {
                    this.AssistCheck = new RecordsAssistCheckModel();
                }

                // 一般状况
                this.generalconditionmodel = new RecordsGeneralConditionBLL().GetModelByOutKey(OutKey);
                if (this.generalconditionmodel == null)
                {
                    this.generalconditionmodel = new RecordsGeneralConditionModel();
                }

                // 查体
                this.physicalModel = new RecordsPhysicalExamBLL().GetModelByOutKey(OutKey);
                if (this.physicalModel == null)
                {
                    this.physicalModel = new RecordsPhysicalExamModel();
                }

                // 现存健康问题
                this.questionModel = new RecordsHealthQuestionBLL().GetModelByOutKey(OutKey);
                if (this.questionModel == null)
                {
                    this.questionModel = new RecordsHealthQuestionModel();
                }

                // 生活方式
                this.liftModel = new RecordsLifeStyleBLL().GetModelByOutKey(OutKey);
                if (this.liftModel == null)
                {
                    this.liftModel = new RecordsLifeStyleModel();
                }

                //脏器功能
                this.visceraFunctionModel = new RecordsVisceraFunctionBLL().GetModelByOutKey(OutKey);
                if (this.visceraFunctionModel == null)
                {
                    this.visceraFunctionModel = new RecordsVisceraFunctionModel();
                }
                AssessmentGuides.IsNormal = "1";
                AssessmentGuides.Exception1 = null;
                AssessmentGuides.Exception2 = null;
                AssessmentGuides.Exception3 = null;
                AssessmentGuides.Exception4 = null;
                AssessmentGuides.HealthGuide = null;
                AssessmentGuides.DangerControl = null;
                AssessmentGuides.Arm = null;
                AssessmentGuides.VaccineAdvice = null;
                AssessmentGuides.Other = null;
                AssessmentGuides.WaistlineArm = null;

                #region  赋值给RecordsManageMentModel

                RecordsManageMentModel.Symptom = row["Symptom"].ToString();
                RecordsManageMentModel.Other = row["Other"].ToString();
                RecordsManageMentModel.BMI = this.generalconditionmodel.BMI;
                RecordsManageMentModel.RightHeight = this.generalconditionmodel.RightHeight;
                RecordsManageMentModel.RightPre = this.generalconditionmodel.RightPre;
                RecordsManageMentModel.LeftHeight = this.generalconditionmodel.LeftHeight;
                RecordsManageMentModel.LeftPre = this.generalconditionmodel.LeftPre;
                RecordsManageMentModel.Waistline = this.generalconditionmodel.Waistline;
                RecordsManageMentModel.Height = this.generalconditionmodel.Height;
                RecordsManageMentModel.PulseRate = this.generalconditionmodel.PulseRate;
                RecordsManageMentModel.Weight = this.generalconditionmodel.Weight;
                RecordsManageMentModel.OldSelfCareability = this.generalconditionmodel.OldSelfCareability;
                RecordsManageMentModel.DrinkRate = this.liftModel.DrinkRate;
                RecordsManageMentModel.SmokeCondition = this.liftModel.SmokeCondition;
                RecordsManageMentModel.ExerciseRate = this.liftModel.ExerciseRate;

                if (this.liftModel.ExerciseTimes.HasValue)
                {
                    RecordsManageMentModel.ExerciseTimes = this.liftModel.ExerciseTimes.ToString();
                }
                else
                {
                    RecordsManageMentModel.ExerciseTimes = "";
                }

                RecordsManageMentModel.DietaryHabit = this.liftModel.DietaryHabit;
                RecordsManageMentModel.ECG = this.AssistCheck.ECG;
                RecordsManageMentModel.ECGEx = "";

                if (!string.IsNullOrEmpty(this.AssistCheck.ECG))
                {
                    if (this.AssistCheck.ECG.Contains("2"))
                    {
                        RecordsManageMentModel.ECGEx += "ST-T改变,";
                    }
                    if (this.AssistCheck.ECG.Contains("3"))
                    {
                        RecordsManageMentModel.ECGEx += "陈旧性心肌梗塞,";
                    }
                    if (this.AssistCheck.ECG.Contains("4"))
                    {
                        RecordsManageMentModel.ECGEx += "窦性心动过速,";
                    }
                    if (this.AssistCheck.ECG.Contains("5"))
                    {
                        RecordsManageMentModel.ECGEx += "窦性心动过缓,";
                    }
                    if (this.AssistCheck.ECG.Contains("6"))
                    {
                        RecordsManageMentModel.ECGEx += "早搏,";
                    }
                    if (this.AssistCheck.ECG.Contains("7"))
                    {
                        RecordsManageMentModel.ECGEx += "房颤,";
                    }
                    if (this.AssistCheck.ECG.Contains("8"))
                    {
                        RecordsManageMentModel.ECGEx += "房室传导阻滞,";
                    }
                    if (this.AssistCheck.ECG.Contains("9"))
                    {
                        RecordsManageMentModel.ECGEx += this.AssistCheck.ECGEx;
                    }
                }
                else RecordsManageMentModel.ECGEx = "";

                RecordsManageMentModel.BCHAO = this.AssistCheck.BCHAO;
                RecordsManageMentModel.BCHAOEx = this.AssistCheck.BCHAOEx;
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
                RecordsManageMentModel.HCY = this.AssistCheck.HCY;
                RecordsManageMentModel.Other = this.AssistCheck.Other;

                if (community.Equals("威海美年大健康") && StringPlus.toString(this.AssistCheck.UA) != "")
                {
                    RecordsManageMentModel.UA = this.AssistCheck.UA;
                }

                RecordsManageMentModel.BrainDis = this.questionModel.BrainDis;
                RecordsManageMentModel.RenalDis = this.questionModel.RenalDis;
                RecordsManageMentModel.HeartDis = this.questionModel.HeartDis;
                RecordsManageMentModel.EyeDis = this.questionModel.EyeDis;
                RecordsManageMentModel.NerveDis = this.questionModel.NerveDis;
                RecordsManageMentModel.ElseDis = this.questionModel.ElseDis;
                RecordsManageMentModel.BrainOther = this.questionModel.BrainOther;
                RecordsManageMentModel.RenalOther = this.questionModel.RenalOther;
                RecordsManageMentModel.HeartOther = this.questionModel.HeartOther;
                RecordsManageMentModel.EyeOther = this.questionModel.EyeOther;
                RecordsManageMentModel.NerveOther = this.questionModel.NerveOther;
                RecordsManageMentModel.ElseOther = this.questionModel.ElseOther;
                RecordsManageMentModel.BarrelChest = this.physicalModel.BarrelChest;//桶状胸
                RecordsManageMentModel.BreathSounds = this.physicalModel.BreastEx;//呼吸音
                RecordsManageMentModel.Rale = this.physicalModel.Rale;//罗音
                RecordsManageMentModel.HeartRhythm = this.physicalModel.HeartRhythm;//心律
                RecordsManageMentModel.Noise = this.physicalModel.Noise;//杂音
                RecordsManageMentModel.PressPain = this.physicalModel.PressPain;//压痛
                RecordsManageMentModel.EnclosedMass = this.physicalModel.EnclosedMass;//包块
                RecordsManageMentModel.Liver = this.physicalModel.Liver;//肝大
                RecordsManageMentModel.Spleen = this.physicalModel.Spleen;//脾大
                RecordsManageMentModel.Voiced = this.physicalModel.Voiced;//移动性浊音
                RecordsManageMentModel.FootBack = this.physicalModel.FootBack;//足背动脉搏动
                RecordsManageMentModel.Edema = this.physicalModel.Edema;// 下肢水肿
                RecordsManageMentModel.LeftView = this.visceraFunctionModel.LeftView;
                RecordsManageMentModel.RightView = this.visceraFunctionModel.RightView;
                RecordsManageMentModel.HeartRate = this.physicalModel.HeartRate;
                RecordsManageMentModel.Listen = visceraFunctionModel.Listen;
                RecordsManageMentModel.SportFunction = visceraFunctionModel.SportFunction;

                #endregion

                healthAssessment = new HealthAssessment { Model = this.Model };
                olderCnandResult = new OlderCnAndResult();

                // 异常信息
                this.AssessmentGuides = healthAssessment.SetHealthEx(this.AssessmentGuides);

                // 危险因素控制
                this.AssessmentGuides = healthAssessment.SetDangerous(this.AssessmentGuides);

                //随访中医辨识更新
                olderCnandResult.SetCnResult(row["IDCardNo"].ToString());

                // 健康评价异常的更新
                if (this.AssessmentGuides != null)
                {
                    this.AssessmentGuides.OutKey = OutKey;
                    RecordsAssessmentGuideBLL recordsAssessmentGuideBll = new RecordsAssessmentGuideBLL();
                    if (!recordsAssessmentGuideBll.ExistsOutKey(this.AssessmentGuides.IDCardNo, OutKey))
                    {

                        if (recordsAssessmentGuideBll.Add(this.AssessmentGuides) > 0)
                        {
                            amount++;
                            labUploadnum.Text = amount.ToString();
                            progressBar1.Value = amount;
                        }
                    }
                    else
                    {
                        if (recordsAssessmentGuideBll.Update(this.AssessmentGuides))
                        {
                            amount++;
                            labUploadnum.Text = amount.ToString();
                            progressBar1.Value = amount;
                        }
                    }
                }
            }

            MessageBox.Show("成功匹配：" + amount + "条数据！", "提示");
            progressBar1.Visible = false;
        }
    }
}
