using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KangShuoTech.Utilities.CommonControl
{
    public class OlderCnAndResult
    {
        private DataSet xmlDs;
        private ScoreJudge judge_qixu;
        private ScoreJudge judge_qiyu;
        private ScoreJudge judge_shire;
        private ScoreJudge judge_tanshi;
        private ScoreJudge judge_tebing;
        private List<ScoreJudge> judge_tizhiAll;
        private ScoreJudge judge_xueyu;
        private ScoreJudge judge_yang;
        private ScoreJudge judge_yin;
        OlderMedicineCnModel oldMedCn;
        OlderMedicineResultModel oldMedResult;
        OlderMedicineCnBLL olderMedicineCnBLL = new OlderMedicineCnBLL();
        OlderMedicineResultBLL olderMedicineResultBLL = new OlderMedicineResultBLL();
        public void SetCnResult(string IDCardNo)
        {
            if (string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BMI))
                && string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.Waistline)))
                return;
            string strYear = DateTime.Now.Year.ToString();
            string  strOldWhere = string.Format("IDCardNo='{0}' AND  left(FollowUpDate,4) = '{1}' order by FollowUpDate Desc limit 0,1  ",IDCardNo, strYear);
            List<OlderSelfCareabilityModel> OlderList = new List<OlderSelfCareabilityModel>();
            OlderList = new OlderSelfCareabilityBLL().GetModelList(strOldWhere);
            if (OlderList.Count == 0)
                return;
            OlderSelfCareabilityModel olderModel = OlderList[0];
            oldMedCn = olderMedicineCnBLL.GetModel(olderModel.IDCardNo, olderModel.ID);
            oldMedResult = olderMedicineResultBLL.GetModel(olderModel.IDCardNo, olderModel.ID);
            if (oldMedCn == null || oldMedResult == null)
                return;
            this.judge_qixu = new ScoreJudge(this.oldMedResult, "FaintScore", "Faint");
            this.judge_yang = new ScoreJudge(this.oldMedResult, "YangsCore", "Yang");
            this.judge_yin = new ScoreJudge(this.oldMedResult, "YinScore", "Yin");
            this.judge_tanshi = new ScoreJudge(this.oldMedResult, "PhlegmdampScore", "PhlegmDamp");
            this.judge_shire = new ScoreJudge(this.oldMedResult, "MuggyScore", "Muggy");
            this.judge_xueyu = new ScoreJudge(this.oldMedResult, "BloodStasisScore", "BloodStasis");
            this.judge_qiyu = new ScoreJudge(this.oldMedResult, "QiConstraintScore", "QiConstraint");
            this.judge_tebing = new ScoreJudge(this.oldMedResult, "CharacteristicScore", "Characteristic");
            this.judge_tizhiAll = new List<ScoreJudge>();
            this.judge_tizhiAll.AddRange((IEnumerable<ScoreJudge>)new ScoreJudge[] { this.judge_qixu, this.judge_yang, this.judge_yin, this.judge_tanshi, this.judge_shire, this.judge_xueyu, this.judge_qiyu, this.judge_tebing });
            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.BMI)))
            {
                if (Convert.ToDouble(RecordsManageMentModel.BMI) < 24)
                {
                    oldMedCn.Weight = 1;
                }
                else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 24 && Convert.ToDouble(RecordsManageMentModel.BMI) < 25)
                {
                    oldMedCn.Weight = 2;
                }
                else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 25 && Convert.ToDouble(RecordsManageMentModel.BMI) < 26)
                {
                    oldMedCn.Weight = 3;
                }
                else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 26 && Convert.ToDouble(RecordsManageMentModel.BMI) < 28)
                {
                    oldMedCn.Weight = 4;
                }
                else if (Convert.ToDouble(RecordsManageMentModel.BMI) >= 28)
                {
                    oldMedCn.Weight = 5;
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(RecordsManageMentModel.Waistline)))
            {
                if (Convert.ToDouble(RecordsManageMentModel.Waistline) < 80)
                {
                    oldMedCn.Abdomen = 1;
                }
                else if (Convert.ToDouble(RecordsManageMentModel.Waistline) >= 80 && Convert.ToDouble(RecordsManageMentModel.Waistline) <= 85)
                {
                    oldMedCn.Abdomen = 2;
                }
                else if (Convert.ToDouble(RecordsManageMentModel.Waistline) >= 86 && Convert.ToDouble(RecordsManageMentModel.Waistline) <= 90)
                {
                    oldMedCn.Abdomen = 3;
                }
                else if (Convert.ToDouble(RecordsManageMentModel.Waistline) >= 91 && Convert.ToDouble(RecordsManageMentModel.Waistline) <= 105)
                {
                    oldMedCn.Abdomen = 4;
                }
                else if (Convert.ToDouble(RecordsManageMentModel.Waistline) > 105)
                {
                    oldMedCn.Abdomen = 5;
                }
            }
            //this.xmlDs = new DataSet();
            //this.xmlDs.ReadXml(Application.StartupPath + @"\old_med.xml");
            //GlbTools.DatatableFillModel<OlderMedicineCnModel>(oldMedCn, this.xmlDs.Tables[0]);
            oldMedResult.FaintScore = new decimal?(this.GetScore(oldMedCn.Tired, oldMedCn.Breath, oldMedCn.Voice, oldMedCn.Influenza));
            oldMedResult.YangsCore = new decimal?(this.GetScore(oldMedCn.FootHand, oldMedCn.Stomach, oldMedCn.Cold, oldMedCn.Coolfood));
            oldMedResult.YinScore = new decimal?(this.GetScore(oldMedCn.Eye, oldMedCn.Mouth, oldMedCn.Thirsty, oldMedCn.Defecatedry));
            oldMedResult.PhlegmdampScore = new decimal?(this.GetScore(oldMedCn.Weight, oldMedCn.Snore, oldMedCn.Abdomen, oldMedCn.Tongue));
            oldMedResult.MuggyScore = new decimal?(this.GetScore(oldMedCn.Greasy, oldMedCn.Eczema, oldMedCn.Smell, oldMedCn.Defecate));
            oldMedResult.BloodStasisScore = new decimal?(this.GetScore(oldMedCn.Skin, oldMedCn.Arms, oldMedCn.Spot, oldMedCn.Vein));
            oldMedResult.QiConstraintScore = new decimal?(this.GetScore(oldMedCn.Emotion, oldMedCn.Spirit, oldMedCn.Alone, oldMedCn.Fear));
            oldMedResult.CharacteristicScore = new decimal?(this.GetScore(oldMedCn.Nasal, oldMedCn.Allergy, oldMedCn.Urticaria, oldMedCn.Scratch));
            oldMedResult.MildScore = new decimal?(this.GetPinghe(oldMedCn.Energy, oldMedCn.Tired, oldMedCn.Voice, oldMedCn.Emotion, oldMedCn.Cold));
            this.UpdateJudge();
            //修改数据
            olderMedicineCnBLL.Update(this.oldMedCn);
            olderMedicineResultBLL.Update(this.oldMedResult);
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
        private void UpdateJudge()
        {
            this.judge_qixu.UpdateResult();
            this.judge_yang.UpdateResult();
            this.judge_yin.UpdateResult();
            this.judge_tanshi.UpdateResult();
            this.judge_shire.UpdateResult();
            this.judge_xueyu.UpdateResult();
            this.judge_qiyu.UpdateResult();
            this.judge_tebing.UpdateResult();
            this.judgePinghebyScore();
            if (this.oldMedResult.Mild == "1" || this.oldMedResult.Mild == "2")
            {
                this.oldMedResult.MildAdvising = "1,2,3,4,5";
            }
            else
            {
                this.oldMedResult.MildAdvising = "";
                this.oldMedResult.MildAdvisingEx = "";
            }
            if (this.oldMedResult.Faint == "1" || this.oldMedResult.Faint == "2")
            {
                this.oldMedResult.FaintAdvising = "1,2,3,4,5";
            }
            else
            {
                this.oldMedResult.FaintAdvising = "";
                this.oldMedResult.FaintAdvisingEx = "";
            }
            if (this.oldMedResult.Yang == "1" || this.oldMedResult.Yang == "2")
            {
                this.oldMedResult.YangAdvising = "1,2,3,4,5";
            }
            else
            {
                this.oldMedResult.YangAdvising = "";
                this.oldMedResult.YangadvisingEx = "";
            }
            if (this.oldMedResult.Yin == "1" || this.oldMedResult.Yin == "2")
            {
                this.oldMedResult.YinAdvising = "1,2,3,4,5";
            }
            else
            {
                this.oldMedResult.YinAdvising = "";
                this.oldMedResult.YinAdvisingEx = "";
            }
            if (this.oldMedResult.PhlegmDamp == "1" || this.oldMedResult.PhlegmDamp == "2")
            {
                this.oldMedResult.PhlegmdampAdvising = "1,2,3,4,5";
            }
            else
            {
                this.oldMedResult.PhlegmdampAdvising = "";
                this.oldMedResult.PhlegmdampAdvisingEx = "";
            }
            if (this.oldMedResult.Muggy == "1" || this.oldMedResult.Muggy == "2")
            {
                this.oldMedResult.MuggyAdvising = "1,2,3,4,5";
            }
            else
            {
                this.oldMedResult.MuggyAdvising = "";
                this.oldMedResult.MuggyAdvisingEx = "";
            }
            if (this.oldMedResult.BloodStasis == "1" || this.oldMedResult.BloodStasis == "2")
            {
                this.oldMedResult.BloodStasisAdvising = "1,2,3,4,5";
            }
            else
            {
                this.oldMedResult.BloodStasisAdvising = "";
                this.oldMedResult.BloodStasisAdvisingEx = "";
            }
            if (this.oldMedResult.QiConstraint == "1" || this.oldMedResult.QiConstraint == "2")
            {
                this.oldMedResult.QiconstraintAdvising = "1,2,3,4,5";
            }
            else
            {
                this.oldMedResult.QiconstraintAdvising = "";
                this.oldMedResult.QiconstraintAdvisingEx = "";
            }
            if (this.oldMedResult.Characteristic == "1" || this.oldMedResult.Characteristic == "2")
            {
                this.oldMedResult.CharacteristicAdvising = "1,2,3,4,5";
            }
            else
            {
                this.oldMedResult.CharacteristicAdvising = "";
                this.oldMedResult.CharacteristicAdvisingEx = "";
            }
        }
        private void judgePinghebyScore()
        {
            decimal? nullable = oldMedResult.MildScore;
            if (((nullable.GetValueOrDefault() < 17M) ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            {
                int num = this.judge_tizhiAll.Count<ScoreJudge>(a => a.m_score <= 8M);
                if (this.judge_tizhiAll.Count<ScoreJudge>(a => (a.m_score < 10M)) == this.judge_tizhiAll.Count)
                {
                    if (num == this.judge_tizhiAll.Count)
                    {
                        this.oldMedResult.Mild = "1";
                    }
                    else
                    {
                        this.oldMedResult.Mild = "2";
                    }
                }
                else
                {
                    this.oldMedResult.Mild = "";
                }
            }
            else
            {
                this.oldMedResult.Mild = "";
            }
        }
    }
}
