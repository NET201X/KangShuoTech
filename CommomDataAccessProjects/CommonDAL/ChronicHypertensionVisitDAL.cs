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
    /// 高血压患者随访记录表
    /// </summary>
    public class ChronicHypertensionVisitDAL
    {
        public int Add(ChronicHypertensionBaseInfoModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO CD_HYPERTENSION_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,ManagementGroup,CaseOurce,TerminateExcuse,");
            builder.Append("FatherHistory,Symptom,HypertensionComplication,Hypotensor,TerminateManagemen,");
            builder.Append("TerminateTime,CreateUnit,CurrentUnit,CreatedDate,");

            if (VersionNo.Contains("3.0")) builder.Append(" CreatedBy, ");
            else builder.Append(" CreateoBy,");

            builder.Append("LastUpdateBy,LastUpdateDate,IsDel,HypType,DiagnoseHospital,TreatPlace,TreatPlaceOther,DiagnoseDate, ");
            builder.Append("Medication,MedicationAdvise,DietAdvise,PhysicalAdvise,DrinkAdvise,CureOther,DepressurizationEffect,BadLifeImprove,BloodHeight,BloodPre, EateHabits,MentalState ) ");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@ManagementGroup,@CaseOurce,@TerminateExcuse,");
            builder.Append("@FatherHistory,@Symptom,@HypertensionComplication,@Hypotensor,@TerminateManagemen,");
            builder.Append("@TerminateTime,@CreateUnit,@CurrentUnit,@CreatedDate,@CreatedBy,@LastUpdateBy,");
            builder.Append("@LastUpdateDate,@IsDel,@HypType,@DiagnoseHospital,@TreatPlace,@TreatPlaceOther,@DiagnoseDate,");
            builder.Append("@Medication,@MedicationAdvise,@DietAdvise,@PhysicalAdvise,@DrinkAdvise,@CureOther,@DepressurizationEffect,@BadLifeImprove,@BloodHeight,@BloodPre, @EateHabits,@MentalState ) ");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@ManagementGroup", MySqlDbType.String, 1),
                new MySqlParameter("@CaseOurce", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateExcuse", MySqlDbType.String, 1),
                new MySqlParameter("@FatherHistory", MySqlDbType.String, 30),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30),
                new MySqlParameter("@HypertensionComplication", MySqlDbType.String, 50),
                new MySqlParameter("@Hypotensor", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateManagemen", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateTime", MySqlDbType.Date),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@HypType", MySqlDbType.String, 100),
                new MySqlParameter("@DiagnoseHospital", MySqlDbType.String, 300),
                new MySqlParameter("@TreatPlace", MySqlDbType.String, 300),
                new MySqlParameter("@TreatPlaceOther", MySqlDbType.String, 100),
                new MySqlParameter("@DiagnoseDate", MySqlDbType.Date),
                new MySqlParameter("@Medication", MySqlDbType.String, 1),
                new MySqlParameter("@MedicationAdvise", MySqlDbType.String, 300),
                new MySqlParameter("@DietAdvise", MySqlDbType.String, 300),
                new MySqlParameter("@PhysicalAdvise", MySqlDbType.String, 300),
                new MySqlParameter("@DrinkAdvise", MySqlDbType.String, 300),
                new MySqlParameter("@CureOther", MySqlDbType.String, 300),
                new MySqlParameter("@DepressurizationEffect", MySqlDbType.String, 100),
                new MySqlParameter("@BadLifeImprove",MySqlDbType.String,100),
                new MySqlParameter("@BloodHeight",MySqlDbType.Decimal),
                new MySqlParameter("@BloodPre",MySqlDbType.Decimal),
                new MySqlParameter("@EateHabits", MySqlDbType.String, 2),
                new MySqlParameter("@MentalState", MySqlDbType.String, 2)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ManagementGroup;
            cmdParms[4].Value = model.CaseOurce;
            cmdParms[5].Value = model.TerminateExcuse;
            cmdParms[6].Value = model.FatherHistory;
            cmdParms[7].Value = model.Symptom;
            cmdParms[8].Value = model.HypertensionComplication;
            cmdParms[9].Value = model.Hypotensor;
            cmdParms[10].Value = model.TerminateManagemen;
            cmdParms[11].Value = model.TerminateTime;
            cmdParms[12].Value = model.CreateUnit;
            cmdParms[13].Value = model.CurrentUnit;
            cmdParms[14].Value = model.CreatedBy;
            cmdParms[15].Value = model.CreatedDate;
            cmdParms[16].Value = model.LastUpdateBy;
            cmdParms[17].Value = model.LastUpdateDate;
            cmdParms[18].Value = model.IsDel;
            cmdParms[19].Value = model.HypType;
            cmdParms[20].Value = model.DiagnoseHospital;
            cmdParms[21].Value = model.TreatPlace;
            cmdParms[22].Value = model.TreatPlaceOther;
            cmdParms[23].Value = model.DiagnoseDate;
            cmdParms[24].Value = model.Medication;
            cmdParms[25].Value = model.MedicationAdvise;
            cmdParms[26].Value = model.DietAdvise;
            cmdParms[27].Value = model.PhysicalAdvise;
            cmdParms[28].Value = model.DrinkAdvise;
            cmdParms[29].Value = model.CureOther;
            cmdParms[30].Value = model.DepressurizationEffect;
            cmdParms[31].Value = model.BadLifeImprove;
            cmdParms[32].Value = model.BloodHeight;
            cmdParms[33].Value = model.BloodPre;
            cmdParms[34].Value = model.EateHabits;
            cmdParms[35].Value = model.MentalState;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public int Add(ChronicHypertensionVisitModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("INSERT INTO CD_HYPERTENSIONFOLLOWUP(");
            builder.Append("RecordID,CustomerID,IDCardNo,CustomerName,");

            if (VersionNo.Contains("3.0")) builder.Append(" VisitDate,VisitDoctor,NextVisitDate,VisitWay,VisitType, ");
            else builder.Append(" FollowUpDate,FollowUpDoctor,NextFollowUpDate,FollowUpWay,FollowUpType, ");

            builder.Append("Symptom,SympToMother,Hypertension,Hypotension,Weight,Height,BMI,");
            //builder.Append("HeartRate )");
            builder.Append("HeartRate,PhysicalSympToMother,DailySmokeNum,DailyDrinkNum,SportTimePerWeek,");
            builder.Append("SportPerMinuteTime,EatSaltType,EatSaltTarGet,PsyChoadJustMent,ObeyDoctorBehavior,");
            builder.Append("AssistantExam,MedicationCompliance,Adr,AdrEx,ReferralReason,ReferralOrg,");
            builder.Append("WeightTarGet,BMITarGet,DailySmokeNumTarget,DailyDrinkNumTarget,");
            builder.Append("SportTimeSperWeekTarget,SportPerMinutesTimeTarget,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,");
            builder.Append("IsDel )");
            builder.Append(" VALUES (");
            builder.Append("@RecordID,@CustomerID,@IDCardNo,@CustomerName,@FollowUpDate,@FollowUpDoctor,@NextFollowUpDate,@FollowUpWay,@FollowUpType,");
            //builder.Append("@Symptom,@SympToMother,@Hypertension,@Hypotension,@Weight,@Height,@BMI,@HeartRate )");

            builder.Append("@Symptom,@SympToMother,@Hypertension,@Hypotension,@Weight,@Height,@BMI,@HeartRate,@PhysicalSympToMother,@DailySmokeNum,@DailyDrinkNum,");
            builder.Append("@SportTimePerWeek,@SportPerMinuteTime,@EatSaltType,@EatSaltTarGet,@PsyChoadJustMent,@ObeyDoctorBehavior,@AssistantExam,");
            builder.Append("@MedicationCompliance,@Adr,@AdrEx,@ReferralReason,@ReferralOrg,@WeightTarGet,@BMITarGet,");
            builder.Append("@DailySmokeNumTarget,@DailyDrinkNumTarget,@SportTimeSperWeekTarget,@SportPerMinutesTimeTarget,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerName", MySqlDbType.String, 30),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpWay", MySqlDbType.String, 1),
                new MySqlParameter("@FollowUpType", MySqlDbType.String, 1),
                new MySqlParameter("@Symptom", MySqlDbType.String, 20),
                new MySqlParameter("@SympToMother", MySqlDbType.String, 500),
                new MySqlParameter("@Hypertension", MySqlDbType.Decimal),
                new MySqlParameter("@Hypotension", MySqlDbType.Decimal),
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@HeartRate", MySqlDbType.String, 10),
                new MySqlParameter("@PhysicalSympToMother", MySqlDbType.String, 500),
                new MySqlParameter("@DailySmokeNum", MySqlDbType.Decimal),
                new MySqlParameter("@DailyDrinkNum", MySqlDbType.Decimal),
                new MySqlParameter("@SportTimePerWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportPerMinuteTime", MySqlDbType.Decimal),
                new MySqlParameter("@EatSaltType", MySqlDbType.String, 1),
                new MySqlParameter("@EatSaltTarGet", MySqlDbType.String, 1),
                new MySqlParameter("@PsyChoadJustMent", MySqlDbType.String, 500),
                new MySqlParameter("@ObeyDoctorBehavior", MySqlDbType.String, 1),
                new MySqlParameter("@AssistantExam", MySqlDbType.String, 500),
                new MySqlParameter("@MedicationCompliance", MySqlDbType.String, 1),
                new MySqlParameter("@Adr", MySqlDbType.String, 1),
                new MySqlParameter("@AdrEx", MySqlDbType.String, 500),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80),
                new MySqlParameter("@WeightTarGet", MySqlDbType.Decimal),
                new MySqlParameter("@BMITarGet", MySqlDbType.Decimal),
                new MySqlParameter("@DailySmokeNumTarget", MySqlDbType.Decimal),
                new MySqlParameter("@DailyDrinkNumTarget", MySqlDbType.Decimal),
                new MySqlParameter("@SportTimeSperWeekTarget", MySqlDbType.Decimal),
                new MySqlParameter("@SportPerMinutesTimeTarget", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.String, 18),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String, 18),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1)
            };

            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.CustomerID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.CustomerName;
            cmdParms[4].Value = model.FollowUpDate;
            cmdParms[5].Value = model.FollowUpDoctor;
            cmdParms[6].Value = model.NextFollowUpDate;
            cmdParms[7].Value = model.FollowUpWay;
            cmdParms[8].Value = model.FollowUpType;
            cmdParms[9].Value = model.Symptom;
            cmdParms[10].Value = model.SympToMother;
            cmdParms[11].Value = model.Hypertension;
            cmdParms[12].Value = model.Hypotension;
            cmdParms[13].Value = model.Weight;
            cmdParms[14].Value = model.Height;
            cmdParms[15].Value = model.BMI;
            cmdParms[16].Value = model.HeartRate;
            cmdParms[17].Value = model.PhysicalSympToMother;
            cmdParms[18].Value = model.DailySmokeNum;
            cmdParms[19].Value = model.DailyDrinkNum;
            cmdParms[20].Value = model.SportTimePerWeek;
            cmdParms[21].Value = model.SportPerMinuteTime;
            cmdParms[22].Value = model.EatSaltType;
            cmdParms[23].Value = model.EatSaltTarGet;
            cmdParms[24].Value = model.PsyChoadJustMent;
            cmdParms[25].Value = model.ObeyDoctorBehavior;
            cmdParms[26].Value = model.AssistantExam;
            cmdParms[27].Value = model.MedicationCompliance;
            cmdParms[28].Value = model.Adr;
            cmdParms[29].Value = model.AdrEx;
            cmdParms[30].Value = model.ReferralReason;
            cmdParms[31].Value = model.ReferralOrg;
            cmdParms[32].Value = model.WeightTarGet;
            cmdParms[33].Value = model.BMITarGet;
            cmdParms[34].Value = model.DailySmokeNumTarget;
            cmdParms[35].Value = model.DailyDrinkNumTarget;
            cmdParms[36].Value = model.SportTimeSperWeekTarget;
            cmdParms[37].Value = model.SportPerMinutesTimeTarget;
            cmdParms[38].Value = model.CreatedBy;
            cmdParms[39].Value = model.CreatedDate;
            cmdParms[40].Value = model.LastUpdateBy;
            cmdParms[41].Value = model.LastUpdateDate;
            cmdParms[42].Value = model.IsDel;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetList(string IDCardNo, string CheckDate, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM CD_HYPERTENSIONFOLLOWUP");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (Convert.ToString(CheckDate).Length > 3)
            {
                if (VersionNo.Contains("3.0"))
                {
                    builder.Append(" AND LEFT(VisitDate,4)=@CheckDate ");
                    builder.Append(" ORDER BY VisitDate DESC LIMIT 0,4 ");
                }
                else
                {
                    builder.Append(" AND LEFT(FollowUpDate,4)=@CheckDate ");
                    builder.Append(" ORDER BY FollowUpDate DESC LIMIT 0,4 ");
                }

                CheckDate = CheckDate.Substring(0, 4);
            }

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@CheckDate", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 取年度的最后一次随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public DataSet GetModel(string IDCardNo, string CheckDate, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM CD_HYPERTENSIONFOLLOWUP");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (Convert.ToString(CheckDate).Length > 3)
            {
                if (VersionNo.Contains("3.0"))
                {
                    builder.Append(" AND LEFT(VisitDate,4)=@CheckDate ");
                    builder.Append(" ORDER BY VisitDate DESC LIMIT 0,1 ");
                }
                else
                {
                    builder.Append(" AND LEFT(FollowUpDate,4)=@CheckDate ");
                    builder.Append(" ORDER BY FollowUpDate DESC LIMIT 0,1 ");
                }

                CheckDate = CheckDate.Substring(0, 4);
            }

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@CheckDate", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 取最后一次随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public DataSet GetMaxModel(string IDCardNo, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();
            string column = VersionNo.Contains("3.0") ? "VisitDate" : "FollowupDate";

            builder.Append("SELECT * FROM CD_HYPERTENSIONFOLLOWUP ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            builder.AppendFormat(" ORDER BY {0} DESC LIMIT 0,1 ", column);

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
        public int GetDataCount(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(0) FROM CD_HYPERTENSION_BASEINFO ");
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
        public int GetDataCount(string IDCardNo, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(0) FROM CD_HYPERTENSIONFOLLOWUP ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (VersionNo.Contains("3.0"))
            {
                builder.Append(" AND YEAR(VisitDate)=YEAR(NOW())");
                builder.Append(" AND QUARTER(VisitDate) = QUARTER(NOW())");
            }
            else
            {
                builder.Append(" AND YEAR(FollowUpDate)=YEAR(NOW())");
                builder.Append(" AND QUARTER(FollowUpDate) = QUARTER(NOW())");
            }

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
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public bool UpdateDate(ChronicHypertensionVisitModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE CD_HYPERTENSIONFOLLOWUP SET ");

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
            if (model.BMI < 24)
            {
                builder.Append("WeightTarGet=null,");
            }
            else
            {
                if (decimal.TryParse(StringPlus.toString(model.WeightTarGet), out value))
                {
                    builder.Append("WeightTarGet='" + value + "',");
                }
            }

            builder.Append("DailySmokeNumTarget='" + model.DailySmokeNumTarget + "',");
            builder.Append("DailyDrinkNumTarget='" + model.DailyDrinkNumTarget + "',");
            builder.Append("SportTimeSperWeekTarget='" + model.SportTimeSperWeekTarget + "',");
            builder.Append("SportPerMinutesTimeTarget='" + model.SportPerMinutesTimeTarget + "',");
            builder.Append("AssistantExam='" + model.AssistantExam + "',");

            if (decimal.TryParse(StringPlus.toString(model.HeartRate), out value))
            {
                builder.Append("HeartRate='" + value + "',");
            }

            string sql = builder.ToString();

            sql = sql.Substring(0, sql.LastIndexOf(','));


            if (VersionNo.Contains("3.0"))
            {
                sql += " WHERE ID=(SELECT * FROM (SELECT ID FROM CD_HYPERTENSIONFOLLOWUP WHERE VisitDate LIKE '" +
                    DateTime.Now.Year + "%' AND IDCardNo='" + model.IDCardNo + "' ORDER BY VisitDate DESC LIMIT 1) AS DATAS )";
            }
            else
            {
                sql += " WHERE ID=(SELECT * FROM (SELECT ID FROM CD_HYPERTENSIONFOLLOWUP WHERE FollowUpDate LIKE '" +
                    DateTime.Now.Year + "%' AND IDCardNo='" + model.IDCardNo + "' ORDER BY FollowUpDate DESC LIMIT 1) AS DATAS )";
            }

            return (MySQLHelper.ExecuteSql(sql) > 0);
        }
    }

    /// <summary>
    /// 脑卒中随访记录表
    /// </summary>
    public class ChronicStrokeVisitDAL
    {
        public int Add(ChronicStrokeBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO CD_STROKE_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,IllSource,IllTime,DiagnosisHource,");
            builder.Append("Familyhistory,HosState,Mrs,GroupLevel,DangerousElement,DgrElementOther,");
            builder.Append("CT,Mri,StrokeType,StrokePosition,SelfAbility,DrugsRely,SpecialTreatment,");
            builder.Append("OtherTreatment,StopManager,StopTime,StopReason,OccurTime,CreateUnit,");
            builder.Append("CurrentUnit,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel)");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@IllSource,@IllTime,@DiagnosisHource,@Familyhistory,");
            builder.Append("@HosState,@Mrs,@GroupLevel,@DangerousElement,@DgrElementOther,@CT,@Mri,@StrokeType,");
            builder.Append("@StrokePosition,@SelfAbility,@DrugsRely,@SpecialTreatment,@OtherTreatment,@StopManager,");
            builder.Append("@StopTime,@StopReason,@OccurTime,@CreateUnit,@CurrentUnit,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IllSource", MySqlDbType.String, 1),
                new MySqlParameter("@IllTime", MySqlDbType.Date),
                new MySqlParameter("@DiagnosisHource", MySqlDbType.String, 100),
                new MySqlParameter("@Familyhistory", MySqlDbType.String, 30),
                new MySqlParameter("@HosState", MySqlDbType.String, 50),
                new MySqlParameter("@Mrs", MySqlDbType.Decimal),
                new MySqlParameter("@GroupLevel", MySqlDbType.String, 1),
                new MySqlParameter("@DangerousElement", MySqlDbType.String, 50),
                new MySqlParameter("@DgrElementOther", MySqlDbType.String, 200),
                new MySqlParameter("@CT", MySqlDbType.String, 200),
                new MySqlParameter("@Mri", MySqlDbType.String, 200),
                new MySqlParameter("@StrokeType", MySqlDbType.String, 1),
                new MySqlParameter("@StrokePosition", MySqlDbType.String, 1),
                new MySqlParameter("@SelfAbility", MySqlDbType.String, 1),
                new MySqlParameter("@DrugsRely", MySqlDbType.String, 1),
                new MySqlParameter("@SpecialTreatment", MySqlDbType.String, 30),
                new MySqlParameter("@OtherTreatment", MySqlDbType.String, 50),
                new MySqlParameter("@StopManager", MySqlDbType.String, 1),
                new MySqlParameter("@StopTime", MySqlDbType.Date),
                new MySqlParameter("@StopReason", MySqlDbType.String, 1),
                new MySqlParameter("@OccurTime", MySqlDbType.Date),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.IllSource;
            cmdParms[4].Value = model.IllTime;
            cmdParms[5].Value = model.DiagnosisHource;
            cmdParms[6].Value = model.Familyhistory;
            cmdParms[7].Value = model.HosState;
            cmdParms[8].Value = model.Mrs;
            cmdParms[9].Value = model.GroupLevel;
            cmdParms[10].Value = model.DangerousElement;
            cmdParms[11].Value = model.DgrElementOther;
            cmdParms[12].Value = model.CT;
            cmdParms[13].Value = model.Mri;
            cmdParms[14].Value = model.StrokeType;
            cmdParms[15].Value = model.StrokePosition;
            cmdParms[16].Value = model.SelfAbility;
            cmdParms[17].Value = model.DrugsRely;
            cmdParms[18].Value = model.SpecialTreatment;
            cmdParms[19].Value = model.OtherTreatment;
            cmdParms[20].Value = model.StopManager;
            cmdParms[21].Value = model.StopTime;
            cmdParms[22].Value = model.StopReason;
            cmdParms[23].Value = model.OccurTime;
            cmdParms[24].Value = model.CreateUnit;
            cmdParms[25].Value = model.CurrentUnit;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpdateDate;
            cmdParms[30].Value = model.IsDel;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public int Add(ChronicStrokeVisitModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO CD_STROKE_FOLLOWUP(");
            builder.Append("CustomerID,IDCardNo,Symptom,SymptomOther,Hypertension,Hypotension,Weight,SignOther,");

            if (VersionNo.Contains("3.0")) builder.Append(" VisitDate,VisitDoctor,NextVisitDate, ");
            else builder.Append(" FollowupDate,FollowUpDoctor,NextFollowUpDate, ");

            builder.Append("SmokeDrinkAttention,SportAttention,EatSaltAttention,PsychicAdjust,ObeyDoctorBehavio,AssistantExam,");
            builder.Append("MedicationCompliance,Adr,AdrEx,FollowupType,ReferralReason,ReferralOrg,FollowupWay,CreatedBy,");
            builder.Append("CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,RecordID,EatingDrug )");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@IDCardNo,@Symptom,@SymptomOther,@Hypertension,@Hypotension,@Weight,@SignOther,");
            builder.Append("@FollowUpDate,@FollowUpDoctor,@NextFollowUpDate,@SmokeDrinkAttention,@SportAttention,@EatSaltAttention,");
            builder.Append("@PsychicAdjust,@ObeyDoctorBehavio,@AssistantExam,@MedicationCompliance,@Adr,@AdrEx,@FollowupType,");
            builder.Append("@ReferralReason,@ReferralOrg,@FollowupWay,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,");
            builder.Append("@IsDel,@RecordID,@EatingDrug )");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30),
                new MySqlParameter("@SymptomOther", MySqlDbType.String, 255),
                new MySqlParameter("@Hypertension", MySqlDbType.Decimal),
                new MySqlParameter("@Hypotension", MySqlDbType.Decimal),
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@SignOther", MySqlDbType.String, 255),
                new MySqlParameter("@SmokeDrinkAttention", MySqlDbType.String, 255),
                new MySqlParameter("@SportAttention", MySqlDbType.String, 255),
                new MySqlParameter("@EatSaltAttention", MySqlDbType.String, 255),
                new MySqlParameter("@PsychicAdjust", MySqlDbType.String, 1),
                new MySqlParameter("@ObeyDoctorBehavio", MySqlDbType.String, 1),
                new MySqlParameter("@AssistantExam", MySqlDbType.String, 255),
                new MySqlParameter("@MedicationCompliance", MySqlDbType.String, 1),
                new MySqlParameter("@Adr", MySqlDbType.String, 1),
                new MySqlParameter("@AdrEx", MySqlDbType.String, 255),
                new MySqlParameter("@FollowupType", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 255),
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 255),
                new MySqlParameter("@FollowupWay", MySqlDbType.String, 1),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@EatingDrug", MySqlDbType.String, 255)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.FollowupDate;
            cmdParms[3].Value = model.FollowUpDoctor;
            cmdParms[4].Value = model.NextFollowupDate;
            cmdParms[5].Value = model.Symptom;
            cmdParms[6].Value = model.SymptomOther;
            cmdParms[7].Value = model.Hypertension;
            cmdParms[8].Value = model.Hypotension;
            cmdParms[9].Value = model.Weight;
            cmdParms[10].Value = model.SignOther;
            cmdParms[11].Value = model.SmokeDrinkAttention;
            cmdParms[12].Value = model.SportAttention;
            cmdParms[13].Value = model.EatSaltAttention;
            cmdParms[14].Value = model.PsychicAdjust;
            cmdParms[15].Value = model.ObeyDoctorBehavio;
            cmdParms[16].Value = model.AssistantExam;
            cmdParms[17].Value = model.MedicationCompliance;
            cmdParms[18].Value = model.Adr;
            cmdParms[19].Value = model.AdrEx;
            cmdParms[20].Value = model.FollowupType;
            cmdParms[21].Value = model.ReferralReason;
            cmdParms[22].Value = model.ReferralOrg;
            cmdParms[23].Value = model.FollowupWay;
            cmdParms[24].Value = model.CreatedBy;
            cmdParms[25].Value = model.CreatedDate;
            cmdParms[26].Value = model.LastUpdateBy;
            cmdParms[27].Value = model.LastUpdateDate;
            cmdParms[28].Value = model.IsDel;
            cmdParms[29].Value = model.RecordID;
            cmdParms[30].Value = model.EatingDrug;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetList(string IDCardNo, string CheckDate, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM CD_STROKE_FOLLOWUP");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (CheckDate != "")
            {
                if (VersionNo.Contains("3.0"))
                {
                    builder.Append("AND VisitDate=@CheckDate");
                    builder.Append(" ORDER BY VisitDate DESC LIMIT 0,1 ");
                }
                else
                {
                    builder.Append("AND FollowupDate=@CheckDate");
                    builder.Append(" ORDER BY FollowupDate DESC LIMIT 0,1 ");
                }
            }

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@CheckDate", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 取最后一次随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public DataSet GetMaxModel(string IDCardNo, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();
            string column = VersionNo.Contains("3.0") ? "VisitDate" : "FollowupDate";

            builder.Append("SELECT * FROM CD_STROKE_FOLLOWUP ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            builder.AppendFormat(" ORDER BY {0} DESC LIMIT 0,1 ", column);

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
        public int GetDataCount(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(0) FROM CD_STROKE_BASEINFO ");
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
        public int GetDataCount(string IDCardNo, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(0) FROM CD_STROKE_FOLLOWUP ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (VersionNo.Contains("3.0"))
            {
                builder.Append(" AND YEAR(VisitDate)=YEAR(NOW())");
                builder.Append(" AND QUARTER(VisitDate) = QUARTER(NOW())");
            }
            else
            {
                builder.Append(" AND YEAR(FollowUpDate)=YEAR(NOW())");
                builder.Append(" AND QUARTER(FollowUpDate) = QUARTER(NOW())");
            }

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }
    }

    /// <summary>
    /// 冠心病患者随访表
    /// </summary>
    public class ChronicChdVisitDAL
    {
        public int Add(ChronicChdBaseInfoModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO CD_CHD_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,Source,FamilyHistory,SureDate,SureUnit,CoroType,CurrenStatus,History,Height,Weight,");
            builder.Append("BMI,HeatRate,Hypertension,Hypotension,FPG,HLIP,LLIP,Glycerate,Chole,Waistline,CheckDate,ECGResult,ECGSports,ECGColor,");
            builder.Append("Artery,Myocardial,Smoking,Drinking,Exercise,Life,Medical,Status,EndDate,EndReason,GroupLevel,");

            if (VersionNo.Contains("3.0")) builder.Append(" CreatedBy,CreatedDate, ");
            else builder.Append(" CreateBy,CreateDate, ");

            builder.Append("LastUpdateBy,LastUpdateDate,IsDelete)");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Source,@FamilyHistory,@SureDate,@SureUnit,@CoroType,@CurrenStatus,@History,@Height,@Weight,");
            builder.Append("@BMI,@HeatRate,@Hypertension,@Hypotension,@FPG,@HLIP,@LLIP,@Glycerate,@Chole,@Waistline,@CheckDate,@ECGResult,@ECGSports,@ECGColor,");
            builder.Append("@Artery,@Myocardial,@Smoking,@Drinking,@Exercise,@Life,@Medical,@Status,@EndDate,@EndReason,@GroupLevel,@CreateBy,@CreateDate,");
            builder.Append("@LastUpdateBy,@LastUpdateDate,@IsDelete)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Source", MySqlDbType.String, 1),
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@SureDate", MySqlDbType.Date),
                new MySqlParameter("@SureUnit", MySqlDbType.String, 80),
                new MySqlParameter("@CoroType", MySqlDbType.String, 1),
                new MySqlParameter("@CurrenStatus", MySqlDbType.String, 1),
                new MySqlParameter("@History", MySqlDbType.String, 1),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@HeatRate", MySqlDbType.Decimal),
                new MySqlParameter("@Hypertension", MySqlDbType.Decimal),
                new MySqlParameter("@Hypotension", MySqlDbType.Decimal),
                new MySqlParameter("@FPG", MySqlDbType.Decimal),
                new MySqlParameter("@HLIP", MySqlDbType.Decimal),
                new MySqlParameter("@LLIP", MySqlDbType.Decimal),
                new MySqlParameter("@Glycerate", MySqlDbType.Decimal),
                new MySqlParameter("@Chole", MySqlDbType.Decimal),
                new MySqlParameter("@Waistline", MySqlDbType.Decimal),
                new MySqlParameter("@CheckDate", MySqlDbType.Date),
                new MySqlParameter("@ECGResult", MySqlDbType.String, 100),
                new MySqlParameter("@ECGSports", MySqlDbType.String, 100),
                new MySqlParameter("@ECGColor", MySqlDbType.String, 100),
                new MySqlParameter("@Artery", MySqlDbType.String, 100),
                new MySqlParameter("@Myocardial", MySqlDbType.String, 100),
                new MySqlParameter("@Smoking", MySqlDbType.String, 1),
                new MySqlParameter("@Drinking", MySqlDbType.String, 1),
                new MySqlParameter("@Exercise", MySqlDbType.String, 1),
                new MySqlParameter("@Life", MySqlDbType.String, 1),
                new MySqlParameter("@Medical", MySqlDbType.String, 1),
                new MySqlParameter("@Status", MySqlDbType.String, 1),
                new MySqlParameter("@EndDate", MySqlDbType.Date),
                new MySqlParameter("@EndReason", MySqlDbType.String, 1),
                new MySqlParameter("@GroupLevel", MySqlDbType.String, 1),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1)
             };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Source;
            cmdParms[4].Value = model.FamilyHistory;
            cmdParms[5].Value = model.SureDate;
            cmdParms[6].Value = model.SureUnit;
            cmdParms[7].Value = model.CoroType;
            cmdParms[8].Value = model.CurrenStatus;
            cmdParms[9].Value = model.History;
            cmdParms[10].Value = model.Height;
            cmdParms[11].Value = model.Weight;
            cmdParms[12].Value = model.BMI;
            cmdParms[13].Value = model.HeatRate;
            cmdParms[14].Value = model.Hypertension;
            cmdParms[15].Value = model.Hypotension;
            cmdParms[16].Value = model.FPG;
            cmdParms[17].Value = model.HLIP;
            cmdParms[18].Value = model.LLIP;
            cmdParms[19].Value = model.Glycerate;
            cmdParms[20].Value = model.Chole;
            cmdParms[21].Value = model.Waistline;
            cmdParms[22].Value = model.CheckDate;
            cmdParms[23].Value = model.ECGResult;
            cmdParms[24].Value = model.ECGSports;
            cmdParms[25].Value = model.ECGColor;
            cmdParms[26].Value = model.Artery;
            cmdParms[27].Value = model.Myocardial;
            cmdParms[28].Value = model.Smoking;
            cmdParms[29].Value = model.Drinking;
            cmdParms[30].Value = model.Exercise;
            cmdParms[31].Value = model.Life;
            cmdParms[32].Value = model.Medical;
            cmdParms[33].Value = model.Status;
            cmdParms[34].Value = model.EndDate;
            cmdParms[35].Value = model.EndReason;
            cmdParms[36].Value = model.GroupLevel;
            cmdParms[37].Value = model.CreateBy;
            cmdParms[38].Value = model.CreateDate;
            cmdParms[39].Value = model.LastUpdateBy;
            cmdParms[40].Value = model.LastUpdateDate;
            cmdParms[41].Value = model.IsDelete;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public int Add(ChronicChdVisitModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO CD_CHD_FOLLOWUP(");
            builder.Append("RecordID,IDCardNo,CustomerID,Symptom,SymptomEx,Systolic,Diastolic,Weight,HearVoice,");
            builder.Append("HeatRate,Apex,Smoking,Sports,Salt,Action,AssistCheck,AfterPill,Compliance,Untoward,UntowardEx,");
            builder.Append("FollowType,ReferralReason,ReferralDepart,NextVisitDate,VisitDoctor,");

            if (VersionNo.Contains("3.0")) builder.Append(" CreatedBy,CreatedDate, ");
            else builder.Append(" CreateBy,CreateDate, ");

            builder.Append("LastUpDateBy,LastUpDateDate,IsDelete,VisitDate,VisitType)");
            builder.Append(" VALUES (");
            builder.Append("@RecordID,@IDCardNo,@CustomerID,@Symptom,@SymptomEx,@Systolic,@Diastolic,@Weight,@HearVoice,");
            builder.Append("@HeatRate,@Apex,@Smoking,@Sports,@Salt,@Action,@AssistCheck,@AfterPill,@Compliance,@Untoward,@UntowardEx,");
            builder.Append("@FollowType,@ReferralReason,@ReferralDepart,@NextVisitDate,@VisitDoctor,@CreateBy,@CreateDate,");
            builder.Append("@LastUpDateBy,@LastUpDateDate,@IsDelete,@VisitDate,@VisitType)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 17),
                new MySqlParameter("@Symptom", MySqlDbType.String, 7),
                new MySqlParameter("@SymptomEx", MySqlDbType.String, 200),
                new MySqlParameter("@Systolic", MySqlDbType.Decimal),
                new MySqlParameter("@Diastolic", MySqlDbType.Decimal),
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@HearVoice", MySqlDbType.String, 1),
                new MySqlParameter("@HeatRate", MySqlDbType.String, 10),
                new MySqlParameter("@Apex", MySqlDbType.String, 1),
                new MySqlParameter("@Smoking", MySqlDbType.String, 200),
                new MySqlParameter("@Sports", MySqlDbType.String, 200),
                new MySqlParameter("@Salt", MySqlDbType.String, 200),
                new MySqlParameter("@Action", MySqlDbType.String, 1),
                new MySqlParameter("@AssistCheck", MySqlDbType.String, 200),
                new MySqlParameter("@AfterPill", MySqlDbType.String, 1),
                new MySqlParameter("@Compliance", MySqlDbType.String, 1),
                new MySqlParameter("@Untoward", MySqlDbType.String, 1),
                new MySqlParameter("@UntowardEx", MySqlDbType.String, 200),
                new MySqlParameter("@FollowType", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 200),
                new MySqlParameter("@ReferralDepart", MySqlDbType.String, 200),
                new MySqlParameter("@NextVisitDate", MySqlDbType.Date),
                new MySqlParameter("@VisitDoctor", MySqlDbType.String, 20),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                new MySqlParameter("@VisitDate", MySqlDbType.Date),
                new MySqlParameter("@VisitType", MySqlDbType.String, 1)
            };

            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.CustomerID;
            cmdParms[3].Value = model.Symptom;
            cmdParms[4].Value = model.SymptomEx;
            cmdParms[5].Value = model.Systolic;
            cmdParms[6].Value = model.Diastolic;
            cmdParms[7].Value = model.Weight;
            cmdParms[8].Value = model.HearVoice;
            cmdParms[9].Value = model.HeartRate;
            cmdParms[10].Value = model.Apex;
            cmdParms[11].Value = model.Smoking;
            cmdParms[12].Value = model.Sports;
            cmdParms[13].Value = model.Salt;
            cmdParms[14].Value = model.Action;
            cmdParms[15].Value = model.AssistCheck;
            cmdParms[16].Value = model.AfterPill;
            cmdParms[17].Value = model.Compliance;
            cmdParms[18].Value = model.Untoward;
            cmdParms[19].Value = model.UntowardEx;
            cmdParms[20].Value = model.FollowType;
            cmdParms[21].Value = model.ReferralReason;
            cmdParms[22].Value = model.ReferralDepart;
            cmdParms[23].Value = model.NextVisitDate;
            cmdParms[24].Value = model.VisitDoctor;
            cmdParms[25].Value = model.CreateBy;
            cmdParms[26].Value = model.CreateDate;
            cmdParms[27].Value = model.LastUpDateBy;
            cmdParms[28].Value = model.LastUpDateDate;
            cmdParms[29].Value = model.IsDelete;
            cmdParms[30].Value = model.VisitDate;
            cmdParms[31].Value = model.VisitType;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetList(string IDCardNo, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM CD_CHD_FOLLOWUP");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (CheckDate != "") builder.Append("AND VisitDate=@VisitDate");

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
        /// <param name="VersionNo"></param>
        /// <returns></returns>
        public DataSet GetMaxModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM CD_CHD_FOLLOWUP ");
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

            builder.Append("SELECT COUNT(0) FROM CD_CHD_BASEINFO ");
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

            builder.Append("SELECT COUNT(0) FROM CD_CHD_FOLLOWUP ");
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
    }
}