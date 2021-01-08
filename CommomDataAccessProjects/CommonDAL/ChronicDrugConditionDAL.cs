namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using System.Data;
    using System.Text;
    using CommonUtilities.SQL;
    using MySql.Data.MySqlClient;
    using System;
    using CommonModel;

    /// <summary>
    /// 用药
    /// </summary>
    public class ChronicDrugConditionDAL
    {
        public int Add(ChronicDrugConditionModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_ChronicDrugCondition(");
            builder.Append("IDCardNo,Type,Name,DailyTime,EveryTimeMg,drugtype,factory,OutKey )");
            builder.Append(" VALUES (");
            builder.Append("@IDCardNo,@Type,@Name,@DailyTime,@EveryTimeMg,@drugtype,@factory,@OutKey )");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Type", MySqlDbType.String, 1),
                new MySqlParameter("@Name", MySqlDbType.String, 100),
                new MySqlParameter("@DailyTime", MySqlDbType.String,100),
                new MySqlParameter("@EveryTimeMg", MySqlDbType.String),
                new MySqlParameter("@drugtype", MySqlDbType.String,100),
                new MySqlParameter("@factory", MySqlDbType.String,100),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,11)
            };

            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Type;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.DailyTime;
            cmdParms[4].Value = model.EveryTimeMg;
            cmdParms[5].Value = model.DrugType;
            cmdParms[6].Value = model.Factory;
            cmdParms[7].Value = model.OutKey;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_ChronicDrugCondition ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE " + strWhere + " ORDER BY id LIMIT 4");
            }

            return MySQLHelper.Query(builder.ToString());
        }
    }

    /// <summary>
    /// 重性精神疾病患者个人信息表
    /// </summary>
    public class ChronicMentalDiseaseBaseInfoDAL
    {
        public int Add(ChronicMentalDiseaseBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_ChronicMentalDiseaseBaseInfo(");
            builder.Append("CustomerID,RecordID,IDCardNo,GuardianRecordID,GuardianName,Ralation,GuradianAddr,");
            builder.Append("GuradianPhone,FirstTime,AgreeManagement,AgreeSignature,AgreeTime,Symptom,SymptomOther,OutPatien,");
            builder.Append("HospitalCount,DiagnosisInfo,DiagnosisHospital,DiagnosisTime,LastCure,VillageContacts,VillageTel,");
            builder.Append("LockInfo,Economy,SpecialistProposal,FillformTime,DoctorMark,CreatedBy,CreatedDate,LastUpdateBy,");
            builder.Append("LastUpDateDate,CreateUnit,CurrentUnit,IsDel,FirstTreatmenTTime,MildTroubleFrequen,CreateDistuFrequen,");
            builder.Append("CauseAccidFrequen,AutolesionFrequen,AttemptSuicFrequen,AttemptSuicideNone,Professional,OtherDangerFrequen,HouseType)");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@GuardianRecordID,@GuardianName,@Ralation,@GuradianAddr,@GuradianPhone,");
            builder.Append("@FirstTime,@AgreeManagement,@AgreeSignature,@AgreeTime,@Symptom,@SymptomOther,@OutPatien,@HospitalCount,");
            builder.Append("@DiagnosisInfo,@DiagnosisHospital,@DiagnosisTime,@LastCure,@VillageContacts,@VillageTel,@LockInfo,@Economy,");
            builder.Append("@SpecialistProposal,@FillformTime,@DoctorMark,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpDateDate,");
            builder.Append("@CreateUnit,@CurrentUnit,@IsDel,@FirstTreatmenTTime,@MildTroubleFrequen,@CreateDistuFrequen,");
            builder.Append("@CauseAccidFrequen,@AutolesionFrequen,@AttemptSuicFrequen,@AttemptSuicideNone,@Professional,@OtherDangerFrequen,@HouseType)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@GuardianRecordID", MySqlDbType.String, 17),
                new MySqlParameter("@GuardianName", MySqlDbType.String, 30),
                new MySqlParameter("@Ralation", MySqlDbType.String, 1),
                new MySqlParameter("@GuradianAddr", MySqlDbType.String, 200),
                new MySqlParameter("@GuradianPhone", MySqlDbType.String, 15),
                new MySqlParameter("@FirstTime", MySqlDbType.Date),
                new MySqlParameter("@AgreeManagement", MySqlDbType.String, 1),
                new MySqlParameter("@AgreeSignature", MySqlDbType.String, 30),
                new MySqlParameter("@AgreeTime", MySqlDbType.Date),
                new MySqlParameter("@Symptom", MySqlDbType.String, 50),
                new MySqlParameter("@SymptomOther", MySqlDbType.String, 200),
                new MySqlParameter("@OutPatien", MySqlDbType.String, 1),
                new MySqlParameter("@HospitalCount", MySqlDbType.Int32),
                new MySqlParameter("@DiagnosisInfo", MySqlDbType.String, 500),
                new MySqlParameter("@DiagnosisHospital", MySqlDbType.String, 200),
                new MySqlParameter("@DiagnosisTime", MySqlDbType.Date),
                new MySqlParameter("@LastCure", MySqlDbType.String, 1),
                new MySqlParameter("@VillageContacts", MySqlDbType.String, 30),
                new MySqlParameter("@VillageTel", MySqlDbType.String, 15),
                new MySqlParameter("@LockInfo", MySqlDbType.String, 1),
                new MySqlParameter("@Economy", MySqlDbType.String, 1),
                new MySqlParameter("@SpecialistProposal", MySqlDbType.String, 500),
                new MySqlParameter("@FillformTime", MySqlDbType.Date),
                new MySqlParameter("@DoctorMark", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@FirstTreatmenTTime", MySqlDbType.Date),
                new MySqlParameter("@MildTroubleFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CreateDistuFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CauseAccidFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AutolesionFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AttemptSuicFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AttemptSuicideNone", MySqlDbType.String, 2),
                new MySqlParameter("@Professional", MySqlDbType.String, 1),
                new MySqlParameter("@OtherDangerFrequen",MySqlDbType.Decimal),
                new MySqlParameter("@HouseType",MySqlDbType.String,1)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.GuardianRecordID;
            cmdParms[4].Value = model.GuardianName;
            cmdParms[5].Value = model.Ralation;
            cmdParms[6].Value = model.GuradianAddr;
            cmdParms[7].Value = model.GuradianPhone;
            cmdParms[8].Value = model.FirstTime;
            cmdParms[9].Value = model.AgreeManagement;
            cmdParms[10].Value = model.AgreeSignature;
            cmdParms[11].Value = model.AgreeTime;
            cmdParms[12].Value = model.Symptom;
            cmdParms[13].Value = model.SymptomOther;
            cmdParms[14].Value = model.OutPatien;
            cmdParms[15].Value = model.HospitalCount;
            cmdParms[16].Value = model.DiagnosisInfo;
            cmdParms[17].Value = model.DiagnosisHospital;
            cmdParms[18].Value = model.DiagnosisTime;
            cmdParms[19].Value = model.LastCure;
            cmdParms[20].Value = model.VillageContacts;
            cmdParms[21].Value = model.VillageTel;
            cmdParms[22].Value = model.LockInfo;
            cmdParms[23].Value = model.Economy;
            cmdParms[24].Value = model.SpecialistProposal;
            cmdParms[25].Value = model.FillformTime;
            cmdParms[26].Value = model.DoctorMark;
            cmdParms[27].Value = model.CreatedBy;
            cmdParms[28].Value = model.CreatedDate;
            cmdParms[29].Value = model.LastUpdateBy;
            cmdParms[30].Value = model.LastUpDateDate;
            cmdParms[31].Value = model.CreateUnit;
            cmdParms[32].Value = model.CurrentUnit;
            cmdParms[33].Value = model.IsDel;
            cmdParms[34].Value = model.FirstTreatmenTTime;
            cmdParms[35].Value = model.MildTroubleFrequen;
            cmdParms[36].Value = model.CreateDistuFrequen;
            cmdParms[37].Value = model.CauseAccidFrequen;
            cmdParms[38].Value = model.AutolesionFrequen;
            cmdParms[39].Value = model.AttemptSuicFrequen;
            cmdParms[40].Value = model.AttemptSuicideNone;
            cmdParms[41].Value = model.Professional;
            cmdParms[42].Value = model.OtherDangerFrequen;
            cmdParms[43].Value = model.HouseType;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_ChronicMentalDiseaseBaseInfo ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE " + strWhere);
            }

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 是否有随访基本信息
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(0) FROM tbl_ChronicMentalDiseaseBaseInfo ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

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
    /// 重性精神疾病患者随访服务记录表
    /// </summary>
    public class ChronicMentalDiseaseVisitDAL
    {
        public int Add(ChronicMentalDiseaseVisitModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_ChronicMentalDiseaseVisit(");
            builder.Append("CustomerID,RecordID,IDCardNo,Fatalness,PresentSymptom,PresentSymptoOther,");

            if (VersionNo.Contains("3.0")) builder.Append(" VisitDate,VisitDoctor,NextVisitDate,VisitType, ");
            else builder.Append(" FollowUpDate,FollowUpDoctor,NextFollowUpDate,FollowUpType, ");

            builder.Append("Insight,SleepQuality,Diet,PersonalCare,Housework,ProductLaborWork,LearningAbility,");
            builder.Append("SocialInterIntera,MildTroubleFrequen,CreateDistuFrequen,CauseAccidFrequen,AutolesionFrequen,");
            builder.Append("AttemptSuicFrequen,AttemptSuicideNone,LockCondition,HospitalizatiStatus,LastLeaveHospTime,");
            builder.Append("LaborExaminati,LaborExaminatiHave,MedicatioCompliance,AdnerDruReact,AdverDruReactHave,");
            builder.Append("TreatmentEffect,WhetherReferral,ReferralReason,ReferralAgencDepar,RehabiliMeasu,");
            builder.Append("RehabiliMeasuOther,FollowupClassificat,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,");
            builder.Append("IsDel,NoVisitReason,DeathDate,IllReason,DeathReason,OtherDangerFrequen)");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Fatalness,@PresentSymptom,@PresentSymptoOther,@FollowUpDate,@FollowUpDoctor,");
            builder.Append("@NextFollowUpDate,@FollowUpType,@Insight,@SleepQuality,@Diet,@PersonalCare,@Housework,@ProductLaborWork,@LearningAbility,");
            builder.Append("@SocialInterIntera,@MildTroubleFrequen,@CreateDistuFrequen,@CauseAccidFrequen,@AutolesionFrequen,@AttemptSuicFrequen,");
            builder.Append("@AttemptSuicideNone,@LockCondition,@HospitalizatiStatus,@LastLeaveHospTime,@LaborExaminati,@LaborExaminatiHave,");
            builder.Append("@MedicatioCompliance,@AdnerDruReact,@AdverDruReactHave,@TreatmentEffect,@WhetherReferral,@ReferralReason,");
            builder.Append("@ReferralAgencDepar,@RehabiliMeasu,@RehabiliMeasuOther,@FollowupClassificat,@CreatedBy,@CreatedDate,");
            builder.Append("@LastUpdateBy,@LastUpdateDate,@IsDel,@NoVisitReason,@DeathDate,@IllReason,@DeathReason,@OtherDangerFrequen)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@Fatalness", MySqlDbType.String, 1),
                new MySqlParameter("@PresentSymptom", MySqlDbType.String, 50),
                new MySqlParameter("@PresentSymptoOther", MySqlDbType.String, 200),
                new MySqlParameter("@Insight", MySqlDbType.String, 1),
                new MySqlParameter("@SleepQuality", MySqlDbType.String, 1),
                new MySqlParameter("@Diet", MySqlDbType.String, 1),
                new MySqlParameter("@PersonalCare", MySqlDbType.String, 1),
                new MySqlParameter("@Housework", MySqlDbType.String, 1),
                new MySqlParameter("@ProductLaborWork", MySqlDbType.String, 1),
                new MySqlParameter("@LearningAbility", MySqlDbType.String, 1),
                new MySqlParameter("@SocialInterIntera", MySqlDbType.String, 1),
                new MySqlParameter("@MildTroubleFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CreateDistuFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CauseAccidFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AutolesionFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AttemptSuicFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AttemptSuicideNone", MySqlDbType.String, 1),
                new MySqlParameter("@LockCondition", MySqlDbType.String, 1),
                new MySqlParameter("@HospitalizatiStatus", MySqlDbType.String, 1),
                new MySqlParameter("@LastLeaveHospTime", MySqlDbType.Date),
                new MySqlParameter("@LaborExaminati", MySqlDbType.String, 1),
                new MySqlParameter("@LaborExaminatiHave", MySqlDbType.String, 100),
                new MySqlParameter("@MedicatioCompliance", MySqlDbType.String, 1),
                new MySqlParameter("@AdnerDruReact", MySqlDbType.String, 1),
                new MySqlParameter("@AdverDruReactHave", MySqlDbType.String, 100),
                new MySqlParameter("@TreatmentEffect", MySqlDbType.String, 1),
                new MySqlParameter("@WhetherReferral", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 200),
                new MySqlParameter("@ReferralAgencDepar", MySqlDbType.String, 80),
                new MySqlParameter("@RehabiliMeasu", MySqlDbType.String, 20),
                new MySqlParameter("@RehabiliMeasuOther", MySqlDbType.String, 10),
                new MySqlParameter("@FollowupClassificat", MySqlDbType.String, 1),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@NoVisitReason",MySqlDbType.String,1),
                new MySqlParameter("@DeathDate",MySqlDbType.Date),
                new MySqlParameter("@IllReason",MySqlDbType.String,1),
                new MySqlParameter("@DeathReason",MySqlDbType.String,1),
                new MySqlParameter("@OtherDangerFrequen",MySqlDbType.Decimal),
                new MySqlParameter("@FollowUpType",MySqlDbType.String,1)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.FollowUpDate;
            cmdParms[4].Value = model.Fatalness;
            cmdParms[5].Value = model.PresentSymptom;
            cmdParms[6].Value = model.PresentSymptoOther;
            cmdParms[7].Value = model.Insight;
            cmdParms[8].Value = model.SleepQuality;
            cmdParms[9].Value = model.Diet;
            cmdParms[10].Value = model.PersonalCare;
            cmdParms[11].Value = model.Housework;
            cmdParms[12].Value = model.ProductLaborWork;
            cmdParms[13].Value = model.LearningAbility;
            cmdParms[14].Value = model.SocialInterIntera;
            cmdParms[15].Value = model.MildTroubleFrequen;
            cmdParms[16].Value = model.CreateDistuFrequen;
            cmdParms[17].Value = model.CauseAccidFrequen;
            cmdParms[18].Value = model.AutolesionFrequen;
            cmdParms[19].Value = model.AttemptSuicFrequen;
            cmdParms[20].Value = model.AttemptSuicideNone;
            cmdParms[21].Value = model.LockCondition;
            cmdParms[22].Value = model.HospitalizatiStatus;
            cmdParms[23].Value = model.LastLeaveHospTime;
            cmdParms[24].Value = model.LaborExaminati;
            cmdParms[25].Value = model.LaborExaminatiHave;
            cmdParms[26].Value = model.MedicatioCompliance;
            cmdParms[27].Value = model.AdnerDruReact;
            cmdParms[28].Value = model.AdverDruReactHave;
            cmdParms[29].Value = model.TreatmentEffect;
            cmdParms[30].Value = model.WhetherReferral;
            cmdParms[31].Value = model.ReferralReason;
            cmdParms[32].Value = model.ReferralAgencDepar;
            cmdParms[33].Value = model.RehabiliMeasu;
            cmdParms[34].Value = model.RehabiliMeasuOther;
            cmdParms[35].Value = model.FollowupClassificat;
            cmdParms[36].Value = model.NextFollowUpDate;
            cmdParms[37].Value = model.FollowUpDoctor;
            cmdParms[38].Value = model.CreatedBy;
            cmdParms[39].Value = model.CreatedDate;
            cmdParms[40].Value = model.LastUpdateBy;
            cmdParms[41].Value = model.LastUpdateDate;
            cmdParms[42].Value = model.IsDel;
            cmdParms[43].Value = model.NoVisitReason;
            cmdParms[44].Value = model.DeathDate;
            cmdParms[45].Value = model.IllReason;
            cmdParms[46].Value = model.DeathReason;
            cmdParms[47].Value = model.OtherDangerFrequen;
            cmdParms[48].Value = model.FollowUpType;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetMaxModel(string IDCardNo, string CheckDate, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_ChronicMentalDiseaseVisit ");
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

            builder.Append("SELECT * FROM tbl_ChronicMentalDiseaseVisit ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            builder.AppendFormat(" ORDER BY {0} DESC LIMIT 0,1 ", column);

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 本季度是否有随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(0) FROM tbl_ChronicMentalDiseaseVisit ");
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
}