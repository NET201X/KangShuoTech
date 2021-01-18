namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicMentalDiseaseVisitDAL
    {
        public int Add(ChronicMentalDiseaseVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_MENTALDISEASE_FOLLOWUP(");
            builder.Append("CustomerID,RecordID,IDCardNo,FollowUpDate,Fatalness,PresentSymptom,PresentSymptoOther,");
            builder.Append("Insight,SleepQuality,Diet,PersonalCare,Housework,ProductLaborWork,LearningAbility,");
            builder.Append("SocialInterIntera,MildTroubleFrequen,CreateDistuFrequen,CauseAccidFrequen,AutolesionFrequen,");
            builder.Append("AttemptSuicFrequen,AttemptSuicideNone,LockCondition,HospitalizatiStatus,LastLeaveHospTime,");
            builder.Append("LaborExaminati,LaborExaminatiHave,MedicatioCompliance,AdnerDruReact,AdverDruReactHave,");
            builder.Append("TreatmentEffect,WhetherReferral,ReferralReason,ReferralAgencDepar,RehabiliMeasu,");
            builder.Append("RehabiliMeasuOther,FollowupClassificat,NextFollowUpDate,FollowUpDoctor,CreatedBy,");
            builder.Append("CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,NoVisitReason,DeathDate,IllReason,DeathReason,OtherDangerFrequen,FollowUpType,");
            builder.Append("JointPartFlag,PoliceAgent,PoliceAgentTel,CommunityAgent,CommunityAgentTel,ReferralResult,ReferralOrgan,ReferraContacts,ReferralContactsTel,ContactSpecialist,SpecialistName,SpecialistTel,DisposalResult ) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@FollowUpDate,@Fatalness,@PresentSymptom,@PresentSymptoOther,");
            builder.Append("@Insight,@SleepQuality,@Diet,@PersonalCare,@Housework,@ProductLaborWork,@LearningAbility,");
            builder.Append("@SocialInterIntera,@MildTroubleFrequen,@CreateDistuFrequen,@CauseAccidFrequen,@AutolesionFrequen,");
            builder.Append("@AttemptSuicFrequen,@AttemptSuicideNone,@LockCondition,@HospitalizatiStatus,@LastLeaveHospTime,");
            builder.Append("@LaborExaminati,@LaborExaminatiHave,@MedicatioCompliance,@AdnerDruReact,@AdverDruReactHave,");
            builder.Append("@TreatmentEffect,@WhetherReferral,@ReferralReason,@ReferralAgencDepar,@RehabiliMeasu,");
            builder.Append("@RehabiliMeasuOther,@FollowupClassificat,@NextFollowUpDate,@FollowUpDoctor,@CreatedBy,");
            builder.Append("@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@NoVisitReason,@DeathDate,@IllReason,@DeathReason,@OtherDangerFrequen,@FollowUpType,");
            builder.Append("@JointPartFlag,@PoliceAgent,@PoliceAgentTel,@CommunityAgent,@CommunityAgentTel,@ReferralResult,@ReferralOrgan,@ReferraContacts,@ReferralContactsTel,@ContactSpecialist,@SpecialistName,@SpecialistTel,@DisposalResult ) ");
            builder.Append(";select @@IDENTITY");
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
                new MySqlParameter("@FollowUpType",MySqlDbType.String,1),
                new MySqlParameter("@JointPartFlag",MySqlDbType.String,1),
                new MySqlParameter("@PoliceAgent",MySqlDbType.String,100),
                new MySqlParameter("@PoliceAgentTel",MySqlDbType.String,100),
                new MySqlParameter("@CommunityAgent",MySqlDbType.String,100),
                new MySqlParameter("@CommunityAgentTel",MySqlDbType.String,100),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@ReferralOrgan",MySqlDbType.String,100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ContactSpecialist",MySqlDbType.String,1),
                new MySqlParameter("@SpecialistName",MySqlDbType.String,50),
                new MySqlParameter("@SpecialistTel",MySqlDbType.String,50),
                new MySqlParameter("@DisposalResult",MySqlDbType.String,500)
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
            cmdParms[49].Value = model.JointPartFlag;      
            cmdParms[50].Value = model.PoliceAgent;        
            cmdParms[51].Value = model.PoliceAgentTel;     
            cmdParms[52].Value = model.CommunityAgent;     
            cmdParms[53].Value = model.CommunityAgentTel;  
            cmdParms[54].Value = model.ReferralResult;     
            cmdParms[55].Value = model.ReferralOrgan ;     
            cmdParms[56].Value = model.ReferraContacts ;   
            cmdParms[57].Value = model.ReferralContactsTel;
            cmdParms[58].Value = model.ContactSpecialist;  
            cmdParms[59].Value = model.SpecialistName ;    
            cmdParms[60].Value = model.SpecialistTel;
            cmdParms[61].Value = model.DisposalResult;  
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(ChronicMentalDiseaseVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_MENTALDISEASE_FOLLOWUP(");
            builder.Append("CustomerID,RecordID,IDCardNo,FollowUpDate,Fatalness,PresentSymptom,PresentSymptoOther,");
            builder.Append("Insight,SleepQuality,Diet,PersonalCare,Housework,ProductLaborWork,LearningAbility,");
            builder.Append("SocialInterIntera,MildTroubleFrequen,CreateDistuFrequen,CauseAccidFrequen,AutolesionFrequen,");
            builder.Append("AttemptSuicFrequen,AttemptSuicideNone,LockCondition,HospitalizatiStatus,LastLeaveHospTime,");
            builder.Append("LaborExaminati,LaborExaminatiHave,MedicatioCompliance,AdnerDruReact,AdverDruReactHave,");
            builder.Append("TreatmentEffect,WhetherReferral,ReferralReason,ReferralAgencDepar,RehabiliMeasu,");
            builder.Append("RehabiliMeasuOther,FollowupClassificat,NextFollowUpDate,FollowUpDoctor,CreatedBy,");
            builder.Append("CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,NoVisitReason,DeathDate,IllReason,DeathReason,OtherDangerFrequen,FollowUpType,");
            builder.Append("JointPartFlag,PoliceAgent,PoliceAgentTel,CommunityAgent,CommunityAgentTel,ReferralResult,ReferralOrgan,ReferraContacts,ReferralContactsTel,ContactSpecialist,SpecialistName,SpecialistTel,DisposalResult ) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@FollowUpDate,@Fatalness,@PresentSymptom,@PresentSymptoOther,");
            builder.Append("@Insight,@SleepQuality,@Diet,@PersonalCare,@Housework,@ProductLaborWork,@LearningAbility,");
            builder.Append("@SocialInterIntera,@MildTroubleFrequen,@CreateDistuFrequen,@CauseAccidFrequen,@AutolesionFrequen,");
            builder.Append("@AttemptSuicFrequen,@AttemptSuicideNone,@LockCondition,@HospitalizatiStatus,@LastLeaveHospTime,");
            builder.Append("@LaborExaminati,@LaborExaminatiHave,@MedicatioCompliance,@AdnerDruReact,@AdverDruReactHave,");
            builder.Append("@TreatmentEffect,@WhetherReferral,@ReferralReason,@ReferralAgencDepar,@RehabiliMeasu,");
            builder.Append("@RehabiliMeasuOther,@FollowupClassificat,@NextFollowUpDate,@FollowUpDoctor,@CreatedBy,");
            builder.Append("@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@NoVisitReason,@DeathDate,@IllReason,@DeathReason,@OtherDangerFrequen,@FollowUpType,");
            builder.Append("@JointPartFlag,@PoliceAgent,@PoliceAgentTel,@CommunityAgent,@CommunityAgentTel,@ReferralResult,@ReferralOrgan,@ReferraContacts,@ReferralContactsTel,@ContactSpecialist,@SpecialistName,@SpecialistTel,@DisposalResult ) ");
            builder.Append(";select @@IDENTITY");
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
                new MySqlParameter("@FollowUpType",MySqlDbType.String,1),
                new MySqlParameter("@JointPartFlag",MySqlDbType.String,1),
                new MySqlParameter("@PoliceAgent",MySqlDbType.String,100),
                new MySqlParameter("@PoliceAgentTel",MySqlDbType.String,100),
                new MySqlParameter("@CommunityAgent",MySqlDbType.String,100),
                new MySqlParameter("@CommunityAgentTel",MySqlDbType.String,100),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@ReferralOrgan",MySqlDbType.String,100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ContactSpecialist",MySqlDbType.String,1),
                new MySqlParameter("@SpecialistName",MySqlDbType.String,50),
                new MySqlParameter("@SpecialistTel",MySqlDbType.String,50),
                new MySqlParameter("@DisposalResult",MySqlDbType.String,500)
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
            cmdParms[49].Value = model.JointPartFlag;
            cmdParms[50].Value = model.PoliceAgent;
            cmdParms[51].Value = model.PoliceAgentTel;
            cmdParms[52].Value = model.CommunityAgent;
            cmdParms[53].Value = model.CommunityAgentTel;
            cmdParms[54].Value = model.ReferralResult;
            cmdParms[55].Value = model.ReferralOrgan;
            cmdParms[56].Value = model.ReferraContacts;
            cmdParms[57].Value = model.ReferralContactsTel;
            cmdParms[58].Value = model.ContactSpecialist;
            cmdParms[59].Value = model.SpecialistName;
            cmdParms[60].Value = model.SpecialistTel;
            cmdParms[61].Value = model.DisposalResult;  
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public ChronicMentalDiseaseVisitModel DataRowToModel(DataRow row)
        {
            ChronicMentalDiseaseVisitModel chronicMentalDiseaseVisitModel = new ChronicMentalDiseaseVisitModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["FollowUpDate"] != null) && (row["FollowUpDate"] != DBNull.Value)) && (row["FollowUpDate"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.FollowUpDate = new DateTime?(DateTime.Parse(row["FollowUpDate"].ToString()));
                }
                if ((row["Fatalness"] != null) && (row["Fatalness"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.Fatalness = row["Fatalness"].ToString();
                }
                if ((row["PresentSymptom"] != null) && (row["PresentSymptom"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.PresentSymptom = row["PresentSymptom"].ToString();
                }
                if ((row["PresentSymptoOther"] != null) && (row["PresentSymptoOther"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.PresentSymptoOther = row["PresentSymptoOther"].ToString();
                }
                if ((row["Insight"] != null) && (row["Insight"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.Insight = row["Insight"].ToString();
                }
                if ((row["SleepQuality"] != null) && (row["SleepQuality"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.SleepQuality = row["SleepQuality"].ToString();
                }
                if ((row["Diet"] != null) && (row["Diet"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.Diet = row["Diet"].ToString();
                }
                if ((row["PersonalCare"] != null) && (row["PersonalCare"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.PersonalCare = row["PersonalCare"].ToString();
                }
                if ((row["Housework"] != null) && (row["Housework"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.Housework = row["Housework"].ToString();
                }
                if ((row["ProductLaborWork"] != null) && (row["ProductLaborWork"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.ProductLaborWork = row["ProductLaborWork"].ToString();
                }
                if ((row["LearningAbility"] != null) && (row["LearningAbility"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.LearningAbility = row["LearningAbility"].ToString();
                }
                if ((row["SocialInterIntera"] != null) && (row["SocialInterIntera"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.SocialInterIntera = row["SocialInterIntera"].ToString();
                }
                if (((row["MildTroubleFrequen"] != null) && (row["MildTroubleFrequen"] != DBNull.Value)) && (row["MildTroubleFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.MildTroubleFrequen = int.Parse(row["MildTroubleFrequen"].ToString());
                }
                if (((row["CreateDistuFrequen"] != null) && (row["CreateDistuFrequen"] != DBNull.Value)) && (row["CreateDistuFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.CreateDistuFrequen = int.Parse(row["CreateDistuFrequen"].ToString());
                }
                if (((row["CauseAccidFrequen"] != null) && (row["CauseAccidFrequen"] != DBNull.Value)) && (row["CauseAccidFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.CauseAccidFrequen = int.Parse(row["CauseAccidFrequen"].ToString());
                }
                if (((row["AutolesionFrequen"] != null) && (row["AutolesionFrequen"] != DBNull.Value)) && (row["AutolesionFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.AutolesionFrequen = int.Parse(row["AutolesionFrequen"].ToString());
                }
                if (((row["AttemptSuicFrequen"] != null) && (row["AttemptSuicFrequen"] != DBNull.Value)) && (row["AttemptSuicFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.AttemptSuicFrequen = int.Parse(row["AttemptSuicFrequen"].ToString());
                }
                if ((row["AttemptSuicideNone"] != null) && (row["AttemptSuicideNone"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.AttemptSuicideNone = row["AttemptSuicideNone"].ToString();
                }
                if ((row["LockCondition"] != null) && (row["LockCondition"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.LockCondition = row["LockCondition"].ToString();
                }
                if ((row["HospitalizatiStatus"] != null) && (row["HospitalizatiStatus"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.HospitalizatiStatus = row["HospitalizatiStatus"].ToString();
                }
                if (((row["LastLeaveHospTime"] != null) && (row["LastLeaveHospTime"] != DBNull.Value)) && (row["LastLeaveHospTime"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.LastLeaveHospTime = new DateTime?(DateTime.Parse(row["LastLeaveHospTime"].ToString()));
                }
                if ((row["LaborExaminati"] != null) && (row["LaborExaminati"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.LaborExaminati = row["LaborExaminati"].ToString();
                }
                if ((row["LaborExaminatiHave"] != null) && (row["LaborExaminatiHave"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.LaborExaminatiHave = row["LaborExaminatiHave"].ToString();
                }
                if ((row["MedicatioCompliance"] != null) && (row["MedicatioCompliance"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.MedicatioCompliance = row["MedicatioCompliance"].ToString();
                }
                if ((row["AdnerDruReact"] != null) && (row["AdnerDruReact"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.AdnerDruReact = row["AdnerDruReact"].ToString();
                }
                if ((row["AdverDruReactHave"] != null) && (row["AdverDruReactHave"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.AdverDruReactHave = row["AdverDruReactHave"].ToString();
                }
                if ((row["TreatmentEffect"] != null) && (row["TreatmentEffect"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.TreatmentEffect = row["TreatmentEffect"].ToString();
                }
                if ((row["WhetherReferral"] != null) && (row["WhetherReferral"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.WhetherReferral = row["WhetherReferral"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["ReferralAgencDepar"] != null) && (row["ReferralAgencDepar"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.ReferralAgencDepar = row["ReferralAgencDepar"].ToString();
                }
                if ((row["RehabiliMeasu"] != null) && (row["RehabiliMeasu"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.RehabiliMeasu = row["RehabiliMeasu"].ToString();
                }
                if ((row["RehabiliMeasuOther"] != null) && (row["RehabiliMeasuOther"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.RehabiliMeasuOther = row["RehabiliMeasuOther"].ToString();
                }
                if ((row["FollowupClassificat"] != null) && (row["FollowupClassificat"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.FollowupClassificat = row["FollowupClassificat"].ToString();
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.NextFollowUpDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["FollowUpDoctor"] != null) && (row["FollowUpDoctor"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.FollowUpDoctor = row["FollowUpDoctor"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.IsDel = row["IsDel"].ToString();
                }
                if ((row["NoVisitReason"] != null) && (row["NoVisitReason"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.NoVisitReason = row["NoVisitReason"].ToString();
                }
                if ((row["IllReason"] != null) && (row["IllReason"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.IllReason = row["IllReason"].ToString();
                }
                if ((row["DeathReason"] != null) && (row["DeathReason"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.DeathReason = row["DeathReason"].ToString();
                }
                if (((row["DeathDate"] != null) && (row["DeathDate"] != DBNull.Value)) && (row["DeathDate"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.DeathDate = new DateTime?(DateTime.Parse(row["DeathDate"].ToString()));
                }
                if (((row["OtherDangerFrequen"] != null) && (row["OtherDangerFrequen"] != DBNull.Value)) && (row["OtherDangerFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseVisitModel.OtherDangerFrequen = int.Parse(row["OtherDangerFrequen"].ToString());
                }
                if ((row["FollowUpType"] != null) && (row["FollowUpType"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.FollowUpType = row["FollowUpType"].ToString();
                }
                if ((row["FollowUpType"] != null) && (row["FollowUpType"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.FollowUpType = row["FollowUpType"].ToString();
                }
                if ((row["JointPartFlag"] != null) && (row["JointPartFlag"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.JointPartFlag = row["JointPartFlag"].ToString();
                }
                if ((row["PoliceAgent"] != null) && (row["PoliceAgent"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.PoliceAgent = row["PoliceAgent"].ToString();
                }
                if ((row["PoliceAgentTel"] != null) && (row["PoliceAgentTel"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.PoliceAgentTel = row["PoliceAgentTel"].ToString();
                }
                if ((row["CommunityAgent"] != null) && (row["CommunityAgent"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.CommunityAgent = row["CommunityAgent"].ToString();
                }
                if ((row["CommunityAgentTel"] != null) && (row["CommunityAgentTel"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.CommunityAgentTel = row["CommunityAgentTel"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.ReferralResult = row["ReferralResult"].ToString();
                }
                if ((row["ReferralOrgan"] != null) && (row["ReferralOrgan"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.ReferralOrgan = row["ReferralOrgan"].ToString();
                }
                if ((row["ReferraContacts"] != null) && (row["ReferraContacts"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.ReferraContacts = row["ReferraContacts"].ToString();
                }
                if ((row["ReferralContactsTel"] != null) && (row["ReferralContactsTel"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.ReferralContactsTel = row["ReferralContactsTel"].ToString();
                }
                if ((row["ContactSpecialist"] != null) && (row["ContactSpecialist"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.ContactSpecialist = row["ContactSpecialist"].ToString();
                }
                if ((row["SpecialistName"] != null) && (row["SpecialistName"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.SpecialistName = row["SpecialistName"].ToString();
                }
                if ((row["SpecialistTel"] != null) && (row["SpecialistTel"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.SpecialistTel = row["SpecialistTel"].ToString();
                }
                if ((row["DisposalResult"] != null) && (row["DisposalResult"] != DBNull.Value))
                {
                    chronicMentalDiseaseVisitModel.DisposalResult = row["DisposalResult"].ToString();
                }
            }
            return chronicMentalDiseaseVisitModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_MENTALDISEASE_FOLLOWUP ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_MENTALDISEASE_FOLLOWUP ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CD_MENTALDISEASE_FOLLOWUP");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public bool ExistVisitdate(string visitdate, string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CD_MENTALDISEASE_FOLLOWUP");
            builder.Append(" where FollowUpDate = @FollowUpDate and IDCardNo =@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@FollowUpDate", Convert.ToDateTime( visitdate).ToShortDateString()),
                new MySqlParameter("@IDCardNo", IDCardNo)
            };
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public ChronicMentalDiseaseVisitModel ExistsCheckDate(ChronicMentalDiseaseVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,FollowUpDate,Fatalness,PresentSymptom,");
            builder.Append("PresentSymptoOther,Insight,SleepQuality,Diet,PersonalCare,Housework,ProductLaborWork,");
            builder.Append("LearningAbility,SocialInterIntera,MildTroubleFrequen,CreateDistuFrequen,");
            builder.Append("CauseAccidFrequen,AutolesionFrequen,AttemptSuicFrequen,AttemptSuicideNone,");
            builder.Append("LockCondition,HospitalizatiStatus,LastLeaveHospTime,LaborExaminati,LaborExaminatiHave,");
            builder.Append("MedicatioCompliance,AdnerDruReact,AdverDruReactHave,TreatmentEffect,WhetherReferral,");
            builder.Append("ReferralReason,ReferralAgencDepar,RehabiliMeasu,RehabiliMeasuOther,FollowupClassificat,");
            builder.Append("NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,NoVisitReason,DeathDate,IllReason,DeathReason,OtherDangerFrequen,FollowUpType, ");
            builder.Append("JointPartFlag,PoliceAgent,PoliceAgentTel,CommunityAgent,CommunityAgentTel,ReferralResult,ReferralOrgan,ReferraContacts,ReferralContactsTel,ContactSpecialist,SpecialistName,SpecialistTel,DisposalResult  ");
            builder.Append(" FROM CD_MENTALDISEASE_FOLLOWUP ");
            builder.Append(" where FollowUpDate = @FollowUpDate and IDCardNo =@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
            };
            cmdParms[0].Value = model.FollowUpDate;
            cmdParms[1].Value = model.IDCardNo;
            new ChronicMentalDiseaseVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,FollowUpDate,Fatalness,PresentSymptom,");
            builder.Append("PresentSymptoOther,Insight,SleepQuality,Diet,PersonalCare,Housework,ProductLaborWork,");
            builder.Append("LearningAbility,SocialInterIntera,MildTroubleFrequen,CreateDistuFrequen,");
            builder.Append("CauseAccidFrequen,AutolesionFrequen,AttemptSuicFrequen,AttemptSuicideNone,");
            builder.Append("LockCondition,HospitalizatiStatus,LastLeaveHospTime,LaborExaminati,LaborExaminatiHave,");
            builder.Append("MedicatioCompliance,AdnerDruReact,AdverDruReactHave,TreatmentEffect,WhetherReferral,");
            builder.Append("ReferralReason,ReferralAgencDepar,RehabiliMeasu,RehabiliMeasuOther,FollowupClassificat,");
            builder.Append("NextFollowUpDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,NoVisitReason,DeathDate,IllReason,DeathReason,OtherDangerFrequen,FollowUpType, ");
            builder.Append("JointPartFlag,PoliceAgent,PoliceAgentTel,CommunityAgent,CommunityAgentTel,ReferralResult,ReferralOrgan,ReferraContacts,ReferralContactsTel,ContactSpecialist,SpecialistName,SpecialistTel,DisposalResult  ");
            builder.Append(" FROM CD_MENTALDISEASE_FOLLOWUP ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select C.IDCardNo,C.ID,T.RecordID,T.CustomerName,T.Nation,T.Sex,T.Birthday,T.Phone,");
            builder.Append("T.Doctor,T.Address,T.HouseHoldAddress,T.Minority,");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate, ");
            builder.Append("(case C.FollowUpDate when null then null when '' then null else C.FollowUpDate end)FollowUpDate, ");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName,C.NoVisitReason,C.DeathDate,C.IllReason,C.DeathReason,C.OtherDangerFrequen,C.FollowUpType ");
            builder.Append(" from CD_MENTALDISEASE_FOLLOWUP C inner join ARCHIVE_BASEINFO T on T.IDCardNo = C.IDCardNo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by " + orderby);
            }
            else
            {
                builder.Append(" order by FollowUpDate desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "CD_MENTALDISEASE_FOLLOWUP");
        }

        public ChronicMentalDiseaseVisitModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,FollowUpDate,Fatalness,PresentSymptom,");
            builder.Append("PresentSymptoOther,Insight,SleepQuality,Diet,PersonalCare,Housework,ProductLaborWork,");
            builder.Append("LearningAbility,SocialInterIntera,MildTroubleFrequen,CreateDistuFrequen,CauseAccidFrequen,");
            builder.Append("AutolesionFrequen,AttemptSuicFrequen,AttemptSuicideNone,LockCondition,HospitalizatiStatus,");
            builder.Append("LastLeaveHospTime,LaborExaminati,LaborExaminatiHave,MedicatioCompliance,AdnerDruReact,");
            builder.Append("AdverDruReactHave,TreatmentEffect,WhetherReferral,ReferralReason,ReferralAgencDepar,");
            builder.Append("RehabiliMeasu,RehabiliMeasuOther,FollowupClassificat,NextFollowUpDate,FollowUpDoctor,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,NoVisitReason,DeathDate,IllReason,DeathReason,OtherDangerFrequen,FollowUpType, ");
            builder.Append("JointPartFlag,PoliceAgent,PoliceAgentTel,CommunityAgent,CommunityAgentTel,ReferralResult,ReferralOrgan,ReferraContacts,ReferralContactsTel,ContactSpecialist,SpecialistName,SpecialistTel,DisposalResult  ");
            builder.Append(" from CD_MENTALDISEASE_FOLLOWUP");
            builder.Append(" where IDCardNo=@IDCardNo order by FollowUpDate desc limit 0,1 ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new ChronicMentalDiseaseVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public ChronicMentalDiseaseVisitModel GetModelFollowUpDate(ChronicMentalDiseaseVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,FollowUpDate,Fatalness,PresentSymptom,");
            builder.Append("PresentSymptoOther,Insight,SleepQuality,Diet,PersonalCare,Housework,ProductLaborWork,");
            builder.Append("LearningAbility,SocialInterIntera,MildTroubleFrequen,CreateDistuFrequen,CauseAccidFrequen,");
            builder.Append("AutolesionFrequen,AttemptSuicFrequen,AttemptSuicideNone,LockCondition,HospitalizatiStatus,");
            builder.Append("LastLeaveHospTime,LaborExaminati,LaborExaminatiHave,MedicatioCompliance,AdnerDruReact,");
            builder.Append("AdverDruReactHave,TreatmentEffect,WhetherReferral,ReferralReason,ReferralAgencDepar,");
            builder.Append("RehabiliMeasu,RehabiliMeasuOther,FollowupClassificat,NextFollowUpDate,FollowUpDoctor,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,NoVisitReason,DeathDate,IllReason,DeathReason,OtherDangerFrequen,FollowUpType,");
            builder.Append("JointPartFlag,PoliceAgent,PoliceAgentTel,CommunityAgent,CommunityAgentTel,ReferralResult,ReferralOrgan,ReferraContacts,ReferralContactsTel,ContactSpecialist,SpecialistName,SpecialistTel,DisposalResult  ");
            builder.Append(" from CD_MENTALDISEASE_FOLLOWUP");
            builder.Append(" where IDCardNo=@IDCardNo and FollowUpDate=@FollowUpDate ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.FollowUpDate;
            new ChronicMentalDiseaseVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public ChronicMentalDiseaseVisitModel GetModelID(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,FollowUpDate,Fatalness,PresentSymptom,");
            builder.Append("PresentSymptoOther,Insight,SleepQuality,Diet,PersonalCare,Housework,ProductLaborWork,");
            builder.Append("LearningAbility,SocialInterIntera,MildTroubleFrequen,CreateDistuFrequen,CauseAccidFrequen,");
            builder.Append("AutolesionFrequen,AttemptSuicFrequen,AttemptSuicideNone,LockCondition,HospitalizatiStatus,");
            builder.Append("LastLeaveHospTime,LaborExaminati,LaborExaminatiHave,MedicatioCompliance,AdnerDruReact,");
            builder.Append("AdverDruReactHave,TreatmentEffect,WhetherReferral,ReferralReason,ReferralAgencDepar,");
            builder.Append("RehabiliMeasu,RehabiliMeasuOther,FollowupClassificat,NextFollowUpDate,FollowUpDoctor,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,NoVisitReason,DeathDate,IllReason,DeathReason,OtherDangerFrequen,FollowUpType, ");
            builder.Append("JointPartFlag,PoliceAgent,PoliceAgentTel,CommunityAgent,CommunityAgentTel,ReferralResult,ReferralOrgan,ReferraContacts,ReferralContactsTel,ContactSpecialist,SpecialistName,SpecialistTel,DisposalResult  ");
            builder.Append(" from CD_MENTALDISEASE_FOLLOWUP");
            builder.Append(" where ID=@ID ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = ID;
            new ChronicMentalDiseaseVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM CD_MENTALDISEASE_FOLLOWUP C ");
            builder.Append("left join ARCHIVE_BASEINFO T on T.IDCardNo = C.IDCardNo   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(ChronicMentalDiseaseVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_MENTALDISEASE_FOLLOWUP set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FollowUpDate=@FollowUpDate,");
            builder.Append("Fatalness=@Fatalness,");
            builder.Append("PresentSymptom=@PresentSymptom,");
            builder.Append("PresentSymptoOther=@PresentSymptoOther,");
            builder.Append("Insight=@Insight,");
            builder.Append("SleepQuality=@SleepQuality,");
            builder.Append("Diet=@Diet,");
            builder.Append("PersonalCare=@PersonalCare,");
            builder.Append("Housework=@Housework,");
            builder.Append("ProductLaborWork=@ProductLaborWork,");
            builder.Append("LearningAbility=@LearningAbility,");
            builder.Append("SocialInterIntera=@SocialInterIntera,");
            builder.Append("MildTroubleFrequen=@MildTroubleFrequen,");
            builder.Append("CreateDistuFrequen=@CreateDistuFrequen,");
            builder.Append("CauseAccidFrequen=@CauseAccidFrequen,");
            builder.Append("AutolesionFrequen=@AutolesionFrequen,");
            builder.Append("AttemptSuicFrequen=@AttemptSuicFrequen,");
            builder.Append("AttemptSuicideNone=@AttemptSuicideNone,");
            builder.Append("LockCondition=@LockCondition,");
            builder.Append("HospitalizatiStatus=@HospitalizatiStatus,");
            builder.Append("LastLeaveHospTime=@LastLeaveHospTime,");
            builder.Append("LaborExaminati=@LaborExaminati,");
            builder.Append("LaborExaminatiHave=@LaborExaminatiHave,");
            builder.Append("MedicatioCompliance=@MedicatioCompliance,");
            builder.Append("AdnerDruReact=@AdnerDruReact,");
            builder.Append("AdverDruReactHave=@AdverDruReactHave,");
            builder.Append("TreatmentEffect=@TreatmentEffect,");
            builder.Append("WhetherReferral=@WhetherReferral,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralAgencDepar=@ReferralAgencDepar,");
            builder.Append("RehabiliMeasu=@RehabiliMeasu,");
            builder.Append("RehabiliMeasuOther=@RehabiliMeasuOther,");
            builder.Append("FollowupClassificat=@FollowupClassificat,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel, ");
            builder.Append("NoVisitReason=@NoVisitReason, ");
            builder.Append("DeathDate=@DeathDate, ");
            builder.Append("IllReason=@IllReason, ");
            builder.Append("DeathReason=@DeathReason, ");
            builder.Append("OtherDangerFrequen=@OtherDangerFrequen, ");
            builder.Append("FollowUpType=@FollowUpType, ");
            builder.Append("JointPartFlag=@JointPartFlag, ");
            builder.Append("PoliceAgent=@PoliceAgent, ");
            builder.Append("PoliceAgentTel=@PoliceAgentTel, ");
            builder.Append("CommunityAgent=@CommunityAgent, ");
            builder.Append("CommunityAgentTel=@CommunityAgentTel, ");
            builder.Append("ReferralResult=@ReferralResult, ");
            builder.Append("ReferralOrgan=@ReferralOrgan, ");
            builder.Append("ReferraContacts=@ReferraContacts, ");
            builder.Append("ReferralContactsTel=@ReferralContactsTel, ");
            builder.Append("ContactSpecialist=@ContactSpecialist, ");
            builder.Append("SpecialistName=@SpecialistName, ");
            builder.Append("SpecialistTel=@SpecialistTel, ");
            builder.Append("DisposalResult=@DisposalResult ");
            builder.Append(" where ID=@ID");
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
                new MySqlParameter("@NoVisitReason", MySqlDbType.String, 1),
                new MySqlParameter("@DeathDate", MySqlDbType.Date),
                new MySqlParameter("@IllReason", MySqlDbType.String, 1),
                new MySqlParameter("@DeathReason", MySqlDbType.String, 1),
                new MySqlParameter("@OtherDangerFrequen",MySqlDbType.Decimal),
                new MySqlParameter("@FollowUpType",MySqlDbType.String,1),
                new MySqlParameter("@JointPartFlag",MySqlDbType.String,1),
                new MySqlParameter("@PoliceAgent",MySqlDbType.String,100),
                new MySqlParameter("@PoliceAgentTel",MySqlDbType.String,100),
                new MySqlParameter("@CommunityAgent",MySqlDbType.String,100),
                new MySqlParameter("@CommunityAgentTel",MySqlDbType.String,100),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@ReferralOrgan",MySqlDbType.String,100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ContactSpecialist",MySqlDbType.String,1),
                new MySqlParameter("@SpecialistName",MySqlDbType.String,50),
                new MySqlParameter("@SpecialistTel",MySqlDbType.String,50),
                new MySqlParameter("@DisposalResult",MySqlDbType.String,500),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
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
            cmdParms[49].Value = model.JointPartFlag;
            cmdParms[50].Value = model.PoliceAgent;
            cmdParms[51].Value = model.PoliceAgentTel;
            cmdParms[52].Value = model.CommunityAgent;
            cmdParms[53].Value = model.CommunityAgentTel;
            cmdParms[54].Value = model.ReferralResult;
            cmdParms[55].Value = model.ReferralOrgan;
            cmdParms[56].Value = model.ReferraContacts;
            cmdParms[57].Value = model.ReferralContactsTel;
            cmdParms[58].Value = model.ContactSpecialist;
            cmdParms[59].Value = model.SpecialistName;
            cmdParms[60].Value = model.SpecialistTel;
            cmdParms[61].Value = model.DisposalResult;  
            cmdParms[62].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(ChronicMentalDiseaseVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_MENTALDISEASE_FOLLOWUP set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FollowUpDate=@FollowUpDate,");
            builder.Append("Fatalness=@Fatalness,");
            builder.Append("PresentSymptom=@PresentSymptom,");
            builder.Append("PresentSymptoOther=@PresentSymptoOther,");
            builder.Append("Insight=@Insight,");
            builder.Append("SleepQuality=@SleepQuality,");
            builder.Append("Diet=@Diet,");
            builder.Append("PersonalCare=@PersonalCare,");
            builder.Append("Housework=@Housework,");
            builder.Append("ProductLaborWork=@ProductLaborWork,");
            builder.Append("LearningAbility=@LearningAbility,");
            builder.Append("SocialInterIntera=@SocialInterIntera,");
            builder.Append("MildTroubleFrequen=@MildTroubleFrequen,");
            builder.Append("CreateDistuFrequen=@CreateDistuFrequen,");
            builder.Append("CauseAccidFrequen=@CauseAccidFrequen,");
            builder.Append("AutolesionFrequen=@AutolesionFrequen,");
            builder.Append("AttemptSuicFrequen=@AttemptSuicFrequen,");
            builder.Append("AttemptSuicideNone=@AttemptSuicideNone,");
            builder.Append("LockCondition=@LockCondition,");
            builder.Append("HospitalizatiStatus=@HospitalizatiStatus,");
            builder.Append("LastLeaveHospTime=@LastLeaveHospTime,");
            builder.Append("LaborExaminati=@LaborExaminati,");
            builder.Append("LaborExaminatiHave=@LaborExaminatiHave,");
            builder.Append("MedicatioCompliance=@MedicatioCompliance,");
            builder.Append("AdnerDruReact=@AdnerDruReact,");
            builder.Append("AdverDruReactHave=@AdverDruReactHave,");
            builder.Append("TreatmentEffect=@TreatmentEffect,");
            builder.Append("WhetherReferral=@WhetherReferral,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralAgencDepar=@ReferralAgencDepar,");
            builder.Append("RehabiliMeasu=@RehabiliMeasu,");
            builder.Append("RehabiliMeasuOther=@RehabiliMeasuOther,");
            builder.Append("FollowupClassificat=@FollowupClassificat,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel, ");
            builder.Append("NoVisitReason=@NoVisitReason, ");
            builder.Append("DeathDate=@DeathDate, ");
            builder.Append("IllReason=@IllReason, ");
            builder.Append("DeathReason=@DeathReason, ");
            builder.Append("OtherDangerFrequen=@OtherDangerFrequen, ");
            builder.Append("FollowUpType=@FollowUpType, ");
            builder.Append("JointPartFlag=@JointPartFlag, ");
            builder.Append("PoliceAgent=@PoliceAgent, ");
            builder.Append("PoliceAgentTel=@PoliceAgentTel, ");
            builder.Append("CommunityAgent=@CommunityAgent, ");
            builder.Append("CommunityAgentTel=@CommunityAgentTel, ");
            builder.Append("ReferralResult=@ReferralResult, ");
            builder.Append("ReferralOrgan=@ReferralOrgan, ");
            builder.Append("ReferraContacts=@ReferraContacts, ");
            builder.Append("ReferralContactsTel=@ReferralContactsTel, ");
            builder.Append("ContactSpecialist=@ContactSpecialist, ");
            builder.Append("SpecialistName=@SpecialistName, ");
            builder.Append("SpecialistTel=@SpecialistTel, ");
            builder.Append("DisposalResult=@DisposalResult ");
            builder.Append(" where ID=@ID");
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
                new MySqlParameter("@NoVisitReason", MySqlDbType.String, 1),
                new MySqlParameter("@DeathDate", MySqlDbType.Date),
                new MySqlParameter("@IllReason", MySqlDbType.String, 1),
                new MySqlParameter("@DeathReason", MySqlDbType.String, 1),
                new MySqlParameter("@OtherDangerFrequen",MySqlDbType.Decimal),
                new MySqlParameter("@FollowUpType",MySqlDbType.String,1),
                new MySqlParameter("@JointPartFlag",MySqlDbType.String,1),
                new MySqlParameter("@PoliceAgent",MySqlDbType.String,100),
                new MySqlParameter("@PoliceAgentTel",MySqlDbType.String,100),
                new MySqlParameter("@CommunityAgent",MySqlDbType.String,100),
                new MySqlParameter("@CommunityAgentTel",MySqlDbType.String,100),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@ReferralOrgan",MySqlDbType.String,100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ContactSpecialist",MySqlDbType.String,1),
                new MySqlParameter("@SpecialistName",MySqlDbType.String,50),
                new MySqlParameter("@SpecialistTel",MySqlDbType.String,50),
                new MySqlParameter("@DisposalResult",MySqlDbType.String,500),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
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
            cmdParms[49].Value = model.JointPartFlag;
            cmdParms[50].Value = model.PoliceAgent;
            cmdParms[51].Value = model.PoliceAgentTel;
            cmdParms[52].Value = model.CommunityAgent;
            cmdParms[53].Value = model.CommunityAgentTel;
            cmdParms[54].Value = model.ReferralResult;
            cmdParms[55].Value = model.ReferralOrgan;
            cmdParms[56].Value = model.ReferraContacts;
            cmdParms[57].Value = model.ReferralContactsTel;
            cmdParms[58].Value = model.ContactSpecialist;
            cmdParms[59].Value = model.SpecialistName;
            cmdParms[60].Value = model.SpecialistTel;
            cmdParms[61].Value = model.DisposalResult;
            cmdParms[62].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet DtMentaldiseaseCount()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select IDCardNo , NextFollowUpDate FROM  CD_MENTALDISEASE_FOLLOWUP order by NextFollowUpDate desc ");
            return MySQLHelper.Query(builder.ToString());
        }
    }
}

