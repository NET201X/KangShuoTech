namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using CommonUtilities.SQL;
    using System;
    using CommonModel;
    using CommomUtilities.Common;

    /// <summary>
    /// 糖尿病患者随访记录表
    /// </summary>
    public class ChronicDiadetesVisitDAL
    {
        public int Add(ChronicDiabetesBaseInfoModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_ChronicDiabetesBaseInfo(");
            builder.Append("CustomerID,RecordID,IDCardNo,ManagementGroup,CaseSource,FamilyHistory,DiabetesType,");
            builder.Append("DiabetesTime,DiabetesWork,Insulin,InsulinWeight,EnalaprilMelete,EndManage,EndWhy,");
            builder.Append("EndTime,HappnTime,CreateUnit,CurrentUnit,LastUpdateBy,LastUpdateDate,");

            if (VersionNo.Contains("3.0")) builder.Append(" CreatedBy,CreatedDate, ");
            else builder.Append(" CreateBy,CreateDate,");

            builder.Append("IsDelete,Symptom,RenalLesionsTime,NeuropathyTime,HeartDiseaseTime,RetinopathyTime,FootLesionsTime,CerebrovascularTime,");
            builder.Append("LesionsOther,LesionsOtherTime,Lesions,CureEffect,SmokeGoal,DrinkGoal,SaltGoal,DietGoal,SportGoal,DiagnosisWay,EateHabits,MentalState )");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@ManagementGroup,@CaseSource,@FamilyHistory,@DiabetesType,@DiabetesTime,");
            builder.Append("@DiabetesWork,@Insulin,@InsulinWeight,@EnalaprilMelete,@EndManage,@EndWhy,@EndTime,@HappnTime,@CreateUnit,");
            builder.Append("@CurrentUnit,@LastUpdateBy,@LastUpdateDate,@CreateBy,@CreateDate,@IsDelete,@Symptom,@RenalLesionsTime,");
            builder.Append("@NeuropathyTime,@HeartDiseaseTime,@RetinopathyTime,@FootLesionsTime,@CerebrovascularTime,@LesionsOther,@LesionsOtherTime,");
            builder.Append("@Lesions,@CureEffect,@SmokeGoal,@DrinkGoal,@SaltGoal,@DietGoal,@SportGoal,@DiagnosisWay,@EateHabits,@MentalState )");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@ManagementGroup", MySqlDbType.String, 1),
                new MySqlParameter("@CaseSource", MySqlDbType.String, 1),
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@DiabetesType", MySqlDbType.String, 1),
                new MySqlParameter("@DiabetesTime", MySqlDbType.Date),
                new MySqlParameter("@DiabetesWork", MySqlDbType.String, 100),
                new MySqlParameter("@Insulin", MySqlDbType.String, 1),
                new MySqlParameter("@InsulinWeight", MySqlDbType.String, 50),
                new MySqlParameter("@EnalaprilMelete", MySqlDbType.String, 100),
                new MySqlParameter("@EndManage", MySqlDbType.String, 1),
                new MySqlParameter("@EndWhy", MySqlDbType.String, 100),
                new MySqlParameter("@EndTime", MySqlDbType.Date),
                new MySqlParameter("@HappnTime", MySqlDbType.Date),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreateBy", MySqlDbType.String, 18),
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String, 18),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30),
                new MySqlParameter("@RenalLesionsTime", MySqlDbType.String, 4),
                new MySqlParameter("@NeuropathyTime", MySqlDbType.String, 4),
                new MySqlParameter("@HeartDiseaseTime", MySqlDbType.String, 4),
                new MySqlParameter("@RetinopathyTime", MySqlDbType.String, 4),
                new MySqlParameter("@FootLesionsTime", MySqlDbType.String, 4),
                new MySqlParameter("@CerebrovascularTime", MySqlDbType.String, 4),
                new MySqlParameter("@LesionsOther", MySqlDbType.String, 100),
                new MySqlParameter("@LesionsOtherTime", MySqlDbType.String, 4),
                new MySqlParameter("@Lesions", MySqlDbType.String, 1),
                new MySqlParameter("@CureEffect", MySqlDbType.String, 2),
                new MySqlParameter("@SmokeGoal", MySqlDbType.String, 300),
                new MySqlParameter("@DrinkGoal", MySqlDbType.String, 300),
                new MySqlParameter("@SaltGoal", MySqlDbType.String, 300),
                new MySqlParameter("@DietGoal", MySqlDbType.String, 300),
                new MySqlParameter("@SportGoal", MySqlDbType.String, 300),
                new MySqlParameter("@DiagnosisWay", MySqlDbType.String, 2),
                new MySqlParameter("@EateHabits", MySqlDbType.String, 2),
                new MySqlParameter("@MentalState", MySqlDbType.String, 2)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ManagementGroup;
            cmdParms[4].Value = model.CaseSource;
            cmdParms[5].Value = model.FamilyHistory;
            cmdParms[6].Value = model.DiabetesType;
            cmdParms[7].Value = model.DiabetesTime;
            cmdParms[8].Value = model.DiabetesWork;
            cmdParms[9].Value = model.Insulin;
            cmdParms[10].Value = model.InsulinWeight;
            cmdParms[11].Value = model.EnalaprilMelete;
            cmdParms[12].Value = model.EndManage;
            cmdParms[13].Value = model.EndWhy;
            cmdParms[14].Value = model.EndTime;
            cmdParms[15].Value = model.HappnTime;
            cmdParms[16].Value = model.CreateUnit;
            cmdParms[17].Value = model.CurrentUnit;
            cmdParms[18].Value = model.CreateBy;
            cmdParms[19].Value = model.CreateDate;
            cmdParms[20].Value = model.LastUpdateBy;
            cmdParms[21].Value = model.LastUpdateDate;
            cmdParms[22].Value = model.IsDelete;
            cmdParms[23].Value = model.Symptom;
            cmdParms[24].Value = model.RenalLesionsTime;
            cmdParms[25].Value = model.NeuropathyTime;
            cmdParms[26].Value = model.HeartDiseaseTime;
            cmdParms[27].Value = model.RetinopathyTime;
            cmdParms[28].Value = model.FootLesionsTime;
            cmdParms[29].Value = model.CerebrovascularTime;
            cmdParms[30].Value = model.LesionsOther;
            cmdParms[31].Value = model.LesionsOtherTime;
            cmdParms[32].Value = model.Lesions;
            cmdParms[33].Value = model.CureEffect;
            cmdParms[34].Value = model.SmokeGoal;
            cmdParms[35].Value = model.DrinkGoal;
            cmdParms[36].Value = model.SaltGoal;
            cmdParms[37].Value = model.DietGoal;
            cmdParms[38].Value = model.SportGoal;
            cmdParms[39].Value = model.DiagnosisWay;
            cmdParms[40].Value = model.EateHabits;
            cmdParms[41].Value = model.MentalState;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public int Add(ChronicDiadetesVisitModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_ChronicDiadetesVisit(");
            builder.Append("CustomerID,RecordID,IDCardNo,CustomerName,VisitDate,VisitDoctor,");
            builder.Append("NextVisitDate,Symptom,SymptomOther,Hypertension,Hypotension,Weight,Height,");
            builder.Append("BMI,DorsalisPedispulse,PhysicalSymptomMother,DailySmokeNum,DailyDrinkNum,");
            builder.Append("SportTimePerWeek,SportPerMinuteTime,StapleFooddailyg,PsychoAdjustment,ObeyDoctorBehavior,");
            builder.Append("FPG,HbAlc,ExamDate,AssistantExam,MedicationCompliance,Adr,AdrEx,HypoglyceMiarreAction,");
            builder.Append("VisitType,InsulinType,InsulinUsage,VisitWay,ReferralReason,ReferralOrg,TargetWeight,BMITarget,");
            builder.Append("DailySmokeNumTarget,DailyDrinkNumTarget,SportTimePerWeekTarget,SportPerMinuteTimeTarget,");

            if (VersionNo.Contains("3.0")) builder.Append(" CreatedBy,CreatedDate, ");
            else builder.Append(" CreateBy,CreateDate,");

            builder.Append("LastUpdateBy,LastUpdateDate,IsDelete,StapleFooddailygTarget,DorsalisPedispulseType)");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@CustomerName,@VisitDate,@VisitDoctor,@NextVisitDate,@Symptom,@SymptomOther,");
            builder.Append("@Hypertension,@Hypotension,@Weight,@Height,@BMI,@DorsalisPedispulse,@PhysicalSymptomMother,@DailySmokeNum,@DailyDrinkNum,");
            builder.Append("@SportTimePerWeek,@SportPerMinuteTime,@StapleFooddailyg,@PsychoAdjustment,@ObeyDoctorBehavior,@FPG,@HbAlc,@ExamDate,");
            builder.Append("@AssistantExam,@MedicationCompliance,@Adr,@AdrEx,@HypoglyceMiarreAction,@VisitType,@InsulinType,@InsulinUsage,@VisitWay,");
            builder.Append("@ReferralReason,@ReferralOrg,@TargetWeight,@BMITarget,@DailySmokeNumTarget,@DailyDrinkNumTarget,@SportTimePerWeekTarget,");
            builder.Append("@SportPerMinuteTimeTarget,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate,@IsDelete,@StapleFooddailygTarget,@DorsalisPedispulseType)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerName", MySqlDbType.String, 30),
                new MySqlParameter("@VisitDate", MySqlDbType.Date),
                new MySqlParameter("@VisitDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@NextVisitDate", MySqlDbType.Date),
                new MySqlParameter("@Symptom", MySqlDbType.String, 20),
                new MySqlParameter("@SymptomOther", MySqlDbType.String, 500),
                new MySqlParameter("@Hypertension", MySqlDbType.Int32),
                new MySqlParameter("@Hypotension", MySqlDbType.Int32),
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@DorsalisPedispulse", MySqlDbType.Decimal),
                new MySqlParameter("@PhysicalSymptomMother", MySqlDbType.String, 500),
                new MySqlParameter("@DailySmokeNum", MySqlDbType.Int32),
                new MySqlParameter("@DailyDrinkNum", MySqlDbType.Int32),
                new MySqlParameter("@SportTimePerWeek", MySqlDbType.Int32),
                new MySqlParameter("@SportPerMinuteTime", MySqlDbType.Int32),
                new MySqlParameter("@StapleFooddailyg", MySqlDbType.Decimal),
                new MySqlParameter("@PsychoAdjustment", MySqlDbType.String, 500),
                new MySqlParameter("@ObeyDoctorBehavior", MySqlDbType.String, 1),
                new MySqlParameter("@FPG", MySqlDbType.Decimal),
                new MySqlParameter("@HbAlc", MySqlDbType.Decimal),
                new MySqlParameter("@ExamDate", MySqlDbType.Date),
                new MySqlParameter("@AssistantExam", MySqlDbType.String, 500),
                new MySqlParameter("@MedicationCompliance", MySqlDbType.String, 1),
                new MySqlParameter("@Adr", MySqlDbType.String, 1),
                new MySqlParameter("@AdrEx", MySqlDbType.String, 500),
                new MySqlParameter("@HypoglyceMiarreAction", MySqlDbType.String, 1),
                new MySqlParameter("@VisitType", MySqlDbType.String, 1),
                new MySqlParameter("@InsulinType", MySqlDbType.String, 20),
                new MySqlParameter("@InsulinUsage", MySqlDbType.String, 500),
                new MySqlParameter("@VisitWay", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80),
                new MySqlParameter("@TargetWeight", MySqlDbType.Decimal),
                new MySqlParameter("@BMITarget", MySqlDbType.Decimal),
                new MySqlParameter("@DailySmokeNumTarget", MySqlDbType.Int32),
                new MySqlParameter("@DailyDrinkNumTarget", MySqlDbType.Int32),
                new MySqlParameter("@SportTimePerWeekTarget", MySqlDbType.Int32),
                new MySqlParameter("@SportPerMinuteTimeTarget", MySqlDbType.Int32),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                new MySqlParameter("@StapleFooddailygTarget", MySqlDbType.Decimal),
                new MySqlParameter("@DorsalisPedispulseType",MySqlDbType.String)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.CustomerName;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.VisitDoctor;
            cmdParms[6].Value = model.NextVisitDate;
            cmdParms[7].Value = model.Symptom;
            cmdParms[8].Value = model.SymptomOther;
            cmdParms[9].Value = model.Hypertension;
            cmdParms[10].Value = model.Hypotension;
            cmdParms[11].Value = model.Weight;
            cmdParms[12].Value = model.Height;
            cmdParms[13].Value = model.BMI;
            cmdParms[14].Value = model.DorsalisPedispulse;
            cmdParms[15].Value = model.PhysicalSymptomMother;
            cmdParms[16].Value = model.DailySmokeNum;
            cmdParms[17].Value = model.DailyDrinkNum;
            cmdParms[18].Value = model.SportTimePerWeek;
            cmdParms[19].Value = model.SportPerMinuteTime;
            cmdParms[20].Value = model.StapleFooddailyg;
            cmdParms[21].Value = model.PsychoAdjustment;
            cmdParms[22].Value = model.ObeyDoctorBehavior;
            cmdParms[23].Value = model.FPG;
            cmdParms[24].Value = model.HbAlc;
            cmdParms[25].Value = model.ExamDate;
            cmdParms[26].Value = model.AssistantExam;
            cmdParms[27].Value = model.MedicationCompliance;
            cmdParms[28].Value = model.Adr;
            cmdParms[29].Value = model.AdrEx;
            cmdParms[30].Value = model.HypoglyceMiarreAction;
            cmdParms[31].Value = model.VisitType;
            cmdParms[32].Value = model.InsulinType;
            cmdParms[33].Value = model.InsulinUsage;
            cmdParms[34].Value = model.VisitWay;
            cmdParms[35].Value = model.ReferralReason;
            cmdParms[36].Value = model.ReferralOrg;
            cmdParms[37].Value = model.TargetWeight;
            cmdParms[38].Value = model.BMITarget;
            cmdParms[39].Value = model.DailySmokeNumTarget;
            cmdParms[40].Value = model.DailyDrinkNumTarget;
            cmdParms[41].Value = model.SportTimePerWeekTarget;
            cmdParms[42].Value = model.SportPerMinuteTimeTarget;
            cmdParms[43].Value = model.CreateBy;
            cmdParms[44].Value = model.CreateDate;
            cmdParms[45].Value = model.LastUpdateBy;
            cmdParms[46].Value = model.LastUpdateDate;
            cmdParms[47].Value = model.IsDelete;
            cmdParms[48].Value = model.StapleFooddailygTarget;
            cmdParms[49].Value = model.DorsalisPedispulseType;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetList(string IDCardNo, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_ChronicDiadetesVisit");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (Convert.ToString(CheckDate).Length > 3)
            {
                builder.Append(" AND LEFT(VisitDate,4)=@VisitDate ");

                CheckDate = CheckDate.Substring(0, 4);
            }

            builder.Append(" ORDER BY VisitDate DESC LIMIT 0,4 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@VisitDate", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public DataSet GetModel(string IDCardNo, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_ChronicDiadetesVisit");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (Convert.ToString(CheckDate).Length > 3)
            {
                builder.Append(" AND LEFT(VisitDate,4)=@VisitDate ");

                CheckDate = CheckDate.Substring(0, 4);
            }

            builder.Append(" ORDER BY VisitDate DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@VisitDate", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 取最后一次随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public DataSet GetMaxModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_ChronicDiadetesVisit ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");
            builder.Append(" ORDER BY VisitDate DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 是否有随访基本信息
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetBaseDataCount(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(0) FROM tbl_ChronicDiabetesBaseInfo ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 本季度是否有随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(0) FROM tbl_ChronicDiadetesVisit ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");
            builder.Append(" AND YEAR(VisitDate)=YEAR(NOW())");
            builder.Append(" AND QUARTER(VisitDate) = QUARTER(NOW())");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 随访同步
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateDate(ChronicDiadetesVisitModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_ChronicDiadetesVisit SET ");

            decimal value;

            if (decimal.TryParse(StringPlus.toString(model.Hypertension), out value))
            {
                builder.Append("Hypertension='" + value + "',");
            }
            if (decimal.TryParse(StringPlus.toString(model.Hypotension), out value))
            {
                builder.Append("Hypotension='" + value + "',");
            }
            if (decimal.TryParse(StringPlus.toString(model.Weight), out value))
            {
                builder.Append("Weight='" + value + "',");
            }
            if (decimal.TryParse(StringPlus.toString(model.BMI), out value))
            {
                builder.Append("BMI='" + value + "',");
            }
            if (decimal.TryParse(StringPlus.toString(model.Height), out value))
            {
                builder.Append("Hight='" + value + "',");
            }
            if (decimal.TryParse(StringPlus.toString(model.DailySmokeNum), out value))
            {
                builder.Append("DailySmokeNum='" + value + "',");
            }
            if (decimal.TryParse(StringPlus.toString(model.DailyDrinkNum), out value))
            {
                builder.Append("DailyDrinkNum='" + value + "',");
            }

            builder.Append("DailySmokeNumTarget='" + model.DailySmokeNumTarget + "',");
            builder.Append("DailyDrinkNumTarget='" + model.DailyDrinkNumTarget + "',");
            builder.Append("SportTimePerWeekTarget='" + model.SportTimePerWeekTarget + "',");
            builder.Append("SportPerMinuteTimeTarget='" + model.SportPerMinuteTimeTarget + "',");

            if (decimal.TryParse(StringPlus.toString(model.FPG), out value))
            {
                builder.Append("FPG='" + value + "',");
            }
            if (decimal.TryParse(StringPlus.toString(model.HbAlc), out value))
            {
                builder.Append("HbAlc='" + value + "',");
            }
            if (model.BMI < 24)
            {
                builder.Append("TargetWeight=null,");
            }
            else
            {
                if (decimal.TryParse(StringPlus.toString(model.TargetWeight), out value))
                {
                    builder.Append("TargetWeight='" + value + "',");
                }
            }

            string sql = builder.ToString();

            sql = sql.Substring(0, sql.LastIndexOf(','));
            sql += " WHERE ID=(SELECT * FROM (SELECT ID FROM tbl_ChronicDiadetesVisit WHERE VisitDate LIKE '" + 
                DateTime.Now.Year + "%' AND IDCardNo='" + model.IDCardNo + "' ORDER BY VisitDate DESC LIMIT 1) DATAS)";

            return (MySQLHelper.ExecuteSql(sql) > 0);
        }
    }
}

