using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArchiveInfo
{
    public partial class frmFollowDataUpdate : Form
    {
        public frmFollowDataUpdate()
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
                int OutKey = Convert.ToInt32(row["ID"].ToString());

                if (string.IsNullOrEmpty(row["IDCardNo"].ToString())) continue;

                // 基本信息
                RecordsBaseInfoModel Model = new RecordsBaseInfoBLL().GetModel(row["IDCardNo"].ToString());
                if (Model == null) Model = new RecordsBaseInfoModel();

                // 一般状况
                RecordsGeneralConditionModel generalConditionModel = new RecordsGeneralConditionBLL().GetModelByOutKey(OutKey);
                if (generalConditionModel == null) generalConditionModel = new RecordsGeneralConditionModel();

                ChronicDiadetesVisitModel diabetesModel = new ChronicDiadetesVisitModel();

                diabetesModel.IDCardNo = row["IDCardNo"].ToString();
                diabetesModel.Hypertension = generalConditionModel.RightHeight;
                diabetesModel.Hypotension = generalConditionModel.RightPre;
                diabetesModel.BMI = generalConditionModel.BMI;
                diabetesModel.Weight = generalConditionModel.Weight;
                diabetesModel.Hight = generalConditionModel.Height;

                if (diabetesModel.BMI != null)
                {
                    if (diabetesModel.BMI >= 24)
                    {
                        diabetesModel.TargetWeight = diabetesModel.Weight - 5;
                    }
                }

                // 生活方式
                RecordsLifeStyleModel lifeModel = new RecordsLifeStyleBLL().GetModelByOutKey(OutKey);
                if (lifeModel == null) lifeModel = new RecordsLifeStyleModel();

                if (lifeModel.SmokeCondition == "3")
                {
                    diabetesModel.DailySmokeNum = lifeModel.SmokeDayNum;
                }
                else diabetesModel.DailySmokeNum = 0;

                if (lifeModel.DrinkRate == "2" || lifeModel.DrinkRate == "3" || lifeModel.DrinkRate == "4")
                {
                    diabetesModel.DailyDrinkNum = lifeModel.DayDrinkVolume;
                }
                else diabetesModel.DailyDrinkNum = 0;

                diabetesModel.DailySmokeNumTarget = 0;
                diabetesModel.DailyDrinkNumTarget = 0;
                diabetesModel.SportTimePerWeekTarget = 7;
                diabetesModel.SportPerMinuteTimeTarget = 60;

                // 辅助检查
                RecordsAssistCheckModel AssistCheck = new RecordsAssistCheckBLL().GetModelByOutKey(OutKey);
                if (AssistCheck == null) AssistCheck = new RecordsAssistCheckModel();

                diabetesModel.FPG = AssistCheck.FPGL;
                diabetesModel.HbAlc = AssistCheck.HBALC;

                new ChronicDiadetesVisitBLL().UpdateDate(diabetesModel);

                ChronicHypertensionVisitModel hypertensionModel = new ChronicHypertensionVisitModel();
                hypertensionModel.Hypertension = generalConditionModel.RightHeight;
                hypertensionModel.Hypotension = generalConditionModel.RightPre;
                hypertensionModel.BMI = generalConditionModel.BMI;
                hypertensionModel.Weight = generalConditionModel.Weight;
                hypertensionModel.Hight = generalConditionModel.Height;

                if (hypertensionModel.BMI != null)
                {
                    if (hypertensionModel.BMI >= 24)
                    {
                        hypertensionModel.WeightTarGet = hypertensionModel.Weight - 5;
                    }
                }
                if (AssistCheck.FPGL != null)
                {
                    hypertensionModel.AssistantExam = $"空腹血糖:{AssistCheck.FPGL}mmol/L";
                }

                // 查体
                RecordsPhysicalExamModel physicalModel = new RecordsPhysicalExamBLL().GetModelByOutKey(OutKey);
                if (physicalModel == null) physicalModel = new RecordsPhysicalExamModel();

                decimal dd = 0;
                if (!string.IsNullOrEmpty(physicalModel.HeartRate))
                {
                    if (decimal.TryParse(physicalModel.HeartRate, out dd)) hypertensionModel.HeartRate = dd;
                }

                if (lifeModel.SmokeCondition == "3")
                {
                    hypertensionModel.DailySmokeNum = lifeModel.SmokeDayNum;
                }
                else hypertensionModel.DailySmokeNum = 0;

                if (lifeModel.DrinkRate == "2" || lifeModel.DrinkRate == "3" || lifeModel.DrinkRate == "4")
                {
                    hypertensionModel.DailyDrinkNum = lifeModel.DayDrinkVolume;
                }
                else hypertensionModel.DailyDrinkNum = 0;

                hypertensionModel.DailySmokeNumTarget = 0;
                hypertensionModel.DailyDrinkNumTarget = 0;
                hypertensionModel.SportTimeSperWeekTarget = 7;
                hypertensionModel.SportPerMinutesTimeTarget = 60;
                hypertensionModel.IDCardNo = row["IDCardNo"].ToString();

                new ChronicHypertensionVisitBLL().UpdateDate(hypertensionModel);

                amount++;
                labUploadnum.Text = amount.ToString();
                progressBar1.Value = amount;
            }

            MessageBox.Show("成功匹配：" + amount + "条数据！", "提示");
            progressBar1.Visible = false;
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
    }
}
