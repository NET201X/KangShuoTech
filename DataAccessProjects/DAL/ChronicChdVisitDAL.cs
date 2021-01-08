using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicChdVisitDAL
    {
        //山东v2.0添加字段 ChdType,Height,BMI,FPGL,TC,TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,HeartCheckResult,SmokeDay,DrinkDay,
        //SportWeek,SportMinute,SpecialTreated,NondrugTreat,Syndromeother,DoctorView,IsReferral --22个
        public int Add(ChronicChdVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_chronicchdvisit(");
            builder.Append("RecordID,IDCardNo,CustomerID,Symptom,SymptomEx,Systolic,Diastolic,Weight,HearVoice,");
            builder.Append("HeatRate,Apex,Smoking,Sports,Salt,Action,AssistCheck,AfterPill,Compliance,Untoward,UntowardEx,");
            builder.Append("FollowType,ReferralReason,ReferralDepart,NextVisitDate,VisitDoctor,CreateBy,CreateDate,");
            builder.Append("LastUpDateBy,LastUpDateDate,IsDelete,VisitDate,VisitType,ChdType,Height,BMI,FPGL,TC,");
            builder.Append("TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,HeartCheckResult,");
            builder.Append("SmokeDay,DrinkDay,SportWeek,SportMinute,SpecialTreated,NondrugTreat,Syndromeother,DoctorView,IsReferral)");
            builder.Append(" values (");
            builder.Append("@RecordID,@IDCardNo,@CustomerID,@Symptom,@SymptomEx,@Systolic,@Diastolic,@Weight,@HearVoice,");
            builder.Append("@HeatRate,@Apex,@Smoking,@Sports,@Salt,@Action,@AssistCheck,@AfterPill,@Compliance,@Untoward,@UntowardEx,");
            builder.Append("@FollowType,@ReferralReason,@ReferralDepart,@NextVisitDate,@VisitDoctor,@CreateBy,@CreateDate,");
            builder.Append("@LastUpDateBy,@LastUpDateDate,@IsDelete,@VisitDate,@VisitType,@ChdType,@Height,@BMI,@FPGL,@TC,");
            builder.Append("@TG,@LowCho,@HeiCho,@EcgCheckResult,@EcgExerciseResult,@CAG,@EnzymesResult,@HeartCheckResult,");
            builder.Append("@SmokeDay,@DrinkDay,@SportWeek,@SportMinute,@SpecialTreated,@NondrugTreat,@Syndromeother,@DoctorView,@IsReferral)");
            builder.Append(";select @@IDENTITY");
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
                new MySqlParameter("@HeatRate", MySqlDbType.String, 1), 
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
                new MySqlParameter("@VisitType", MySqlDbType.String, 1),
                new MySqlParameter("@ChdType", MySqlDbType.String, 100),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@FPGL", MySqlDbType.Decimal),
                new MySqlParameter("@TC", MySqlDbType.Decimal),
                new MySqlParameter("@TG", MySqlDbType.Decimal),
                new MySqlParameter("@LowCho", MySqlDbType.Decimal),
                new MySqlParameter("@HeiCho", MySqlDbType.Decimal),
                new MySqlParameter("@EcgCheckResult", MySqlDbType.String, 100),
                new MySqlParameter("@EcgExerciseResult", MySqlDbType.String, 100),
                new MySqlParameter("@CAG", MySqlDbType.String, 100),
                new MySqlParameter("@EnzymesResult", MySqlDbType.String, 100),
                new MySqlParameter("@HeartCheckResult", MySqlDbType.String, 100),
                new MySqlParameter("@SmokeDay", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkDay", MySqlDbType.Decimal),
                new MySqlParameter("@SportWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportMinute", MySqlDbType.Decimal),
                new MySqlParameter("@SpecialTreated", MySqlDbType.String, 100),
                new MySqlParameter("@NondrugTreat", MySqlDbType.String, 100),
                new MySqlParameter("@Syndromeother", MySqlDbType.String, 100),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 100),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1)
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
            cmdParms[32].Value = model.ChdType;
            cmdParms[33].Value = model.Height;
            cmdParms[34].Value = model.BMI;
            cmdParms[35].Value = model.FPGL;
            cmdParms[36].Value = model.TC;
            cmdParms[37].Value = model.TG;
            cmdParms[38].Value = model.LowCho;
            cmdParms[39].Value = model.HeiCho;
            cmdParms[40].Value = model.EcgCheckResult;
            cmdParms[41].Value = model.EcgExerciseResult;
            cmdParms[42].Value = model.CAG;
            cmdParms[43].Value = model.EnzymesResult;
            cmdParms[44].Value = model.HeartCheckResult;
            cmdParms[45].Value = model.SmokeDay;
            cmdParms[46].Value = model.DrinkDay;
            cmdParms[47].Value = model.SportWeek;
            cmdParms[48].Value = model.SportMinute;
            cmdParms[49].Value = model.SpecialTreated;
            cmdParms[50].Value = model.NondrugTreat;
            cmdParms[51].Value = model.Syndromeother;
            cmdParms[52].Value = model.DoctorView;
            cmdParms[53].Value = model.IsReferral; 
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(ChronicChdVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_chronicchdvisit(");
            builder.Append("RecordID,IDCardNo,CustomerID,Symptom,SymptomEx,Systolic,Diastolic,Weight,HearVoice,");
            builder.Append("HeatRate,Apex,Smoking,Sports,Salt,Action,AssistCheck,AfterPill,Compliance,Untoward,UntowardEx,");
            builder.Append("FollowType,ReferralReason,ReferralDepart,NextVisitDate,VisitDoctor,CreateBy,CreateDate,");
            builder.Append("LastUpDateBy,LastUpDateDate,IsDelete,VisitDate,VisitType,ChdType,Height,BMI,FPGL,TC,");
            builder.Append("TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,HeartCheckResult,");
            builder.Append("SmokeDay,DrinkDay,SportWeek,SportMinute,SpecialTreated,NondrugTreat,Syndromeother,DoctorView,IsReferral)");
            builder.Append(" values (");
            builder.Append("@RecordID,@IDCardNo,@CustomerID,@Symptom,@SymptomEx,@Systolic,@Diastolic,@Weight,@HearVoice,");
            builder.Append("@HeatRate,@Apex,@Smoking,@Sports,@Salt,@Action,@AssistCheck,@AfterPill,@Compliance,@Untoward,@UntowardEx,");
            builder.Append("@FollowType,@ReferralReason,@ReferralDepart,@NextVisitDate,@VisitDoctor,@CreateBy,@CreateDate,");
            builder.Append("@LastUpDateBy,@LastUpDateDate,@IsDelete,@VisitDate,@VisitType,@ChdType,@Height,@BMI,@FPGL,@TC,");
            builder.Append("@TG,@LowCho,@HeiCho,@EcgCheckResult,@EcgExerciseResult,@CAG,@EnzymesResult,@HeartCheckResult,");
            builder.Append("@SmokeDay,@DrinkDay,@SportWeek,@SportMinute,@SpecialTreated,@NondrugTreat,@Syndromeother,@DoctorView,@IsReferral)");
            builder.Append(";select @@IDENTITY");
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
                new MySqlParameter("@HeatRate", MySqlDbType.String, 1), 
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
                new MySqlParameter("@VisitType", MySqlDbType.String, 1),
                new MySqlParameter("@ChdType", MySqlDbType.String, 100),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@FPGL", MySqlDbType.Decimal),
                new MySqlParameter("@TC", MySqlDbType.Decimal),
                new MySqlParameter("@TG", MySqlDbType.Decimal),
                new MySqlParameter("@LowCho", MySqlDbType.Decimal),
                new MySqlParameter("@HeiCho", MySqlDbType.Decimal),
                new MySqlParameter("@EcgCheckResult", MySqlDbType.String, 100),
                new MySqlParameter("@EcgExerciseResult", MySqlDbType.String, 100),
                new MySqlParameter("@CAG", MySqlDbType.String, 100),
                new MySqlParameter("@EnzymesResult", MySqlDbType.String, 100),
                new MySqlParameter("@HeartCheckResult", MySqlDbType.String, 100),
                new MySqlParameter("@SmokeDay", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkDay", MySqlDbType.Decimal),
                new MySqlParameter("@SportWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportMinute", MySqlDbType.Decimal),
                new MySqlParameter("@SpecialTreated", MySqlDbType.String, 100),
                new MySqlParameter("@NondrugTreat", MySqlDbType.String, 100),
                new MySqlParameter("@Syndromeother", MySqlDbType.String, 100),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 100),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1)
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
            cmdParms[32].Value = model.ChdType;
            cmdParms[33].Value = model.Height;
            cmdParms[34].Value = model.BMI;
            cmdParms[35].Value = model.FPGL;
            cmdParms[36].Value = model.TC;
            cmdParms[37].Value = model.TG;
            cmdParms[38].Value = model.LowCho;
            cmdParms[39].Value = model.HeiCho;
            cmdParms[40].Value = model.EcgCheckResult;
            cmdParms[41].Value = model.EcgExerciseResult;
            cmdParms[42].Value = model.CAG;
            cmdParms[43].Value = model.EnzymesResult;
            cmdParms[44].Value = model.HeartCheckResult;
            cmdParms[45].Value = model.SmokeDay;
            cmdParms[46].Value = model.DrinkDay;
            cmdParms[47].Value = model.SportWeek;
            cmdParms[48].Value = model.SportMinute;
            cmdParms[49].Value = model.SpecialTreated;
            cmdParms[50].Value = model.NondrugTreat;
            cmdParms[51].Value = model.Syndromeother;
            cmdParms[52].Value = model.DoctorView;
            cmdParms[53].Value = model.IsReferral; 
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public ChronicChdVisitModel DataRowToModel(DataRow row)
        {
            ChronicChdVisitModel chronicChdVisitModel = new ChronicChdVisitModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicChdVisitModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicChdVisitModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicChdVisitModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicChdVisitModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["Symptom"] != null) && (row["Symptom"] != DBNull.Value))
                {
                    chronicChdVisitModel.Symptom = row["Symptom"].ToString();
                }
                if ((row["SymptomEx"] != null) && (row["SymptomEx"] != DBNull.Value))
                {
                    chronicChdVisitModel.SymptomEx = row["SymptomEx"].ToString();
                }
                if (((row["Systolic"] != null) && (row["Systolic"] != DBNull.Value)) && (row["Systolic"].ToString() != ""))
                {
                    chronicChdVisitModel.Systolic = new decimal?(decimal.Parse(row["Systolic"].ToString()));
                }
                if (((row["Diastolic"] != null) && (row["Diastolic"] != DBNull.Value)) && (row["Diastolic"].ToString() != ""))
                {
                    chronicChdVisitModel.Diastolic = new decimal?(decimal.Parse(row["Diastolic"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    chronicChdVisitModel.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if ((row["HearVoice"] != null) && (row["HearVoice"] != DBNull.Value))
                {
                    chronicChdVisitModel.HearVoice = row["HearVoice"].ToString();
                }
                if ((row["HeatRate"] != null) && (row["HeatRate"] != DBNull.Value))
                {
                    chronicChdVisitModel.HeartRate = row["HeatRate"].ToString();
                }
                if ((row["Apex"] != null) && (row["Apex"] != DBNull.Value))
                {
                    chronicChdVisitModel.Apex = row["Apex"].ToString();
                }
                if ((row["Smoking"] != null) && (row["Smoking"] != DBNull.Value))
                {
                    chronicChdVisitModel.Smoking = row["Smoking"].ToString();
                }
                if ((row["Sports"] != null) && (row["Sports"] != DBNull.Value))
                {
                    chronicChdVisitModel.Sports = row["Sports"].ToString();
                }
                if ((row["Salt"] != null) && (row["Salt"] != DBNull.Value))
                {
                    chronicChdVisitModel.Salt = row["Salt"].ToString();
                }
                if ((row["Action"] != null) && (row["Action"] != DBNull.Value))
                {
                    chronicChdVisitModel.Action = row["Action"].ToString();
                }
                if ((row["AssistCheck"] != null) && (row["AssistCheck"] != DBNull.Value))
                {
                    chronicChdVisitModel.AssistCheck = row["AssistCheck"].ToString();
                }
                if ((row["AfterPill"] != null) && (row["AfterPill"] != DBNull.Value))
                {
                    chronicChdVisitModel.AfterPill = row["AfterPill"].ToString();
                }
                if ((row["Compliance"] != null) && (row["Compliance"] != DBNull.Value))
                {
                    chronicChdVisitModel.Compliance = row["Compliance"].ToString();
                }
                if ((row["Untoward"] != null) && (row["Untoward"] != DBNull.Value))
                {
                    chronicChdVisitModel.Untoward = row["Untoward"].ToString();
                }
                if ((row["UntowardEx"] != null) && (row["UntowardEx"] != DBNull.Value))
                {
                    chronicChdVisitModel.UntowardEx = row["UntowardEx"].ToString();
                }
                if ((row["FollowType"] != null) && (row["FollowType"] != DBNull.Value))
                {
                    chronicChdVisitModel.FollowType = row["FollowType"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    chronicChdVisitModel.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["ReferralDepart"] != null) && (row["ReferralDepart"] != DBNull.Value))
                {
                    chronicChdVisitModel.ReferralDepart = row["ReferralDepart"].ToString();
                }
                if (((row["NextVisitDate"] != null) && (row["NextVisitDate"] != DBNull.Value)) && (row["NextVisitDate"].ToString() != ""))
                {
                    chronicChdVisitModel.NextVisitDate = new DateTime?(DateTime.Parse(row["NextVisitDate"].ToString()));
                }
                if ((row["VisitDoctor"] != null) && (row["VisitDoctor"] != DBNull.Value))
                {
                    chronicChdVisitModel.VisitDoctor = row["VisitDoctor"].ToString();
                }
                if (((row["CreateBy"] != null) && (row["CreateBy"] != DBNull.Value)) && (row["CreateBy"].ToString() != ""))
                {
                    chronicChdVisitModel.CreateBy = new decimal?(decimal.Parse(row["CreateBy"].ToString()));
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    chronicChdVisitModel.CreateDate = new DateTime?(DateTime.Parse(row["CreateDate"].ToString()));
                }
                if (((row["LastUpDateBy"] != null) && (row["LastUpDateBy"] != DBNull.Value)) && (row["LastUpDateBy"].ToString() != ""))
                {
                    chronicChdVisitModel.LastUpDateBy = new decimal?(decimal.Parse(row["LastUpDateBy"].ToString()));
                }
                if (((row["LastUpDateDate"] != null) && (row["LastUpDateDate"] != DBNull.Value)) && (row["LastUpDateDate"].ToString() != ""))
                {
                    chronicChdVisitModel.LastUpDateDate = new DateTime?(DateTime.Parse(row["LastUpDateDate"].ToString()));
                }
                if ((row["IsDelete"] != null) && (row["IsDelete"] != DBNull.Value))
                {
                    chronicChdVisitModel.IsDelete = row["IsDelete"].ToString();
                }
                if (((row["VisitDate"] != null) && (row["VisitDate"] != DBNull.Value)) && (row["VisitDate"].ToString() != ""))
                {
                    chronicChdVisitModel.VisitDate = new DateTime?(DateTime.Parse(row["VisitDate"].ToString()));
                }
                if ((row["VisitType"] != null) && (row["VisitType"] != DBNull.Value))
                {
                    chronicChdVisitModel.VisitType = row["VisitType"].ToString();
                }
                if ((row["ChdType"] != null) && (row["ChdType"] != DBNull.Value))
                {
                    chronicChdVisitModel.ChdType = row["ChdType"].ToString();
                }
                if (((row["Height"] != null) && (row["Height"] != DBNull.Value)) && (row["Height"].ToString() != ""))
                {
                    chronicChdVisitModel.Height = new decimal?(decimal.Parse(row["Height"].ToString()));
                }
                if (((row["BMI"] != null) && (row["BMI"] != DBNull.Value)) && (row["BMI"].ToString() != ""))
                {
                    chronicChdVisitModel.BMI = new decimal?(decimal.Parse(row["BMI"].ToString()));
                }
                if (((row["FPGL"] != null) && (row["FPGL"] != DBNull.Value)) && (row["FPGL"].ToString() != ""))
                {
                    chronicChdVisitModel.FPGL = new decimal?(decimal.Parse(row["FPGL"].ToString()));
                }
                if (((row["TC"] != null) && (row["TC"] != DBNull.Value)) && (row["TC"].ToString() != ""))
                {
                    chronicChdVisitModel.TC = new decimal?(decimal.Parse(row["TC"].ToString()));
                }
                if (((row["TG"] != null) && (row["TG"] != DBNull.Value)) && (row["TG"].ToString() != ""))
                {
                    chronicChdVisitModel.TG = new decimal?(decimal.Parse(row["TG"].ToString()));
                }
                if (((row["LowCho"] != null) && (row["LowCho"] != DBNull.Value)) && (row["LowCho"].ToString() != ""))
                {
                    chronicChdVisitModel.LowCho = new decimal?(decimal.Parse(row["LowCho"].ToString()));
                }
                if (((row["HeiCho"] != null) && (row["HeiCho"] != DBNull.Value)) && (row["HeiCho"].ToString() != ""))
                {
                    chronicChdVisitModel.HeiCho = new decimal?(decimal.Parse(row["HeiCho"].ToString()));
                }
              
                if ((row["EcgCheckResult"] != null) && (row["EcgCheckResult"] != DBNull.Value))
                {
                    chronicChdVisitModel.EcgCheckResult = row["EcgCheckResult"].ToString();
                }
                if ((row["EcgExerciseResult"] != null) && (row["EcgExerciseResult"] != DBNull.Value))
                {
                    chronicChdVisitModel.EcgExerciseResult = row["EcgExerciseResult"].ToString();
                }
                if ((row["CAG"] != null) && (row["CAG"] != DBNull.Value))
                {
                    chronicChdVisitModel.CAG = row["CAG"].ToString();
                }
                if ((row["EnzymesResult"] != null) && (row["EnzymesResult"] != DBNull.Value))
                {
                    chronicChdVisitModel.EnzymesResult = row["EnzymesResult"].ToString();
                }
                if ((row["HeartCheckResult"] != null) && (row["HeartCheckResult"] != DBNull.Value))
                {
                    chronicChdVisitModel.HeartCheckResult = row["HeartCheckResult"].ToString();
                }
                if (((row["SmokeDay"] != null) && (row["SmokeDay"] != DBNull.Value)) && (row["SmokeDay"].ToString() != ""))
                {
                    chronicChdVisitModel.SmokeDay = new decimal?(decimal.Parse(row["SmokeDay"].ToString()));
                }
                if (((row["DrinkDay"] != null) && (row["DrinkDay"] != DBNull.Value)) && (row["DrinkDay"].ToString() != ""))
                {
                    chronicChdVisitModel.DrinkDay = new decimal?(decimal.Parse(row["DrinkDay"].ToString()));
                }
                if (((row["SportWeek"] != null) && (row["SportWeek"] != DBNull.Value)) && (row["SportWeek"].ToString() != ""))
                {
                    chronicChdVisitModel.SportWeek = new decimal?(decimal.Parse(row["SportWeek"].ToString()));
                }
                if (((row["SportMinute"] != null) && (row["SportMinute"] != DBNull.Value)) && (row["SportMinute"].ToString() != ""))
                {
                    chronicChdVisitModel.SportMinute = new decimal?(decimal.Parse(row["SportMinute"].ToString()));
                }
                if ((row["SpecialTreated"] != null) && (row["SpecialTreated"] != DBNull.Value))
                {
                    chronicChdVisitModel.SpecialTreated = row["SpecialTreated"].ToString();
                }
                if ((row["NondrugTreat"] != null) && (row["NondrugTreat"] != DBNull.Value))
                {
                    chronicChdVisitModel.NondrugTreat = row["NondrugTreat"].ToString();
                }
                if ((row["Syndromeother"] != null) && (row["Syndromeother"] != DBNull.Value))
                {
                    chronicChdVisitModel.Syndromeother = row["Syndromeother"].ToString();
                }
                if ((row["DoctorView"] != null) && (row["DoctorView"] != DBNull.Value))
                {
                    chronicChdVisitModel.DoctorView = row["DoctorView"].ToString();
                }
                if ((row["IsReferral"] != null) && (row["IsReferral"] != DBNull.Value))
                {
                    chronicChdVisitModel.IsReferral = row["IsReferral"].ToString();
                }

            }
            return chronicChdVisitModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chronicchdvisit ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chronicchdvisit ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_chronicchdvisit");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public bool ExistVisitdate(string visitdate, string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_chronicchdvisit");
            builder.Append(" where VisitDate = @VisitDate and IDCardNo =@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@VisitDate", Convert.ToDateTime( visitdate).ToShortDateString()),
                new MySqlParameter("@IDCardNo", IDCardNo)
            };
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        //山东v2.0添加字段 ChdType,Height,BMI,FPGL,TC,TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,HeartCheckResult,SmokeDay,DrinkDay,
        //SportWeek,SportMinute,SpecialTreated,NondrugTreat,Syndromeother,DoctorView,IsReferral --22个
        public ChronicChdVisitModel ExistsCheckDate(ChronicChdVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,Symptom,SymptomEx,Systolic,Diastolic,Weight, ");
            builder.Append("HearVoice,HeatRate,Apex,Smoking,Sports,Salt,Action,AssistCheck,AfterPill,Compliance,Untoward,UntowardEx,");
            builder.Append("FollowType,ReferralReason,ReferralDepart,NextVisitDate,VisitDoctor,CreateBy,CreateDate,LastUpDateBy,");
            builder.Append("LastUpDateDate,IsDelete,VisitDate,VisitType, ");
            builder.Append("ChdType,Height,BMI,FPGL,TC,TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,");
            builder.Append("HeartCheckResult,SmokeDay,DrinkDay,SportWeek,SportMinute,SpecialTreated,NondrugTreat,Syndromeother,");
            builder.Append("DoctorView,IsReferral ");
            builder.Append(" from tbl_chronicchdvisit where VisitDate = @VisitDate and IDCardNo =@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@VisitDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
            };
            cmdParms[0].Value = model.VisitDate;
            cmdParms[1].Value = model.IDCardNo;
            new ChronicChdVisitModel();
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
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,Symptom,SymptomEx,Systolic,Diastolic,Weight, ");
            builder.Append("HearVoice,HeatRate,Apex,Smoking,Sports,Salt,Action,AssistCheck,AfterPill,Compliance,Untoward,UntowardEx,");
            builder.Append("FollowType,ReferralReason,ReferralDepart,NextVisitDate,VisitDoctor,CreateBy,CreateDate,LastUpDateBy,");
            builder.Append("LastUpDateDate,IsDelete,VisitDate,VisitType, ");
            builder.Append("ChdType,Height,BMI,FPGL,TC,TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,");
            builder.Append("HeartCheckResult,SmokeDay,DrinkDay,SportWeek,SportMinute,SpecialTreated,NondrugTreat,Syndromeother,");
            builder.Append("DoctorView,IsReferral ");
            builder.Append(" FROM tbl_chronicchdvisit ");
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
            builder.Append("(case C.VisitDate when null then null when '' then null else C.VisitDate end)VisitDate, ");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName ");
            builder.Append(" from tbl_chronicchdvisit C inner join tbl_recordsbaseinfo T on T.IDCardNo = C.IDCardNo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by  " + orderby);
            }
            else
            {
                builder.Append(" order by VisitDate desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "tbl_chronicchdvisit");
        }

        public ChronicChdVisitModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,Symptom,SymptomEx,Systolic,Diastolic,Weight, ");
            builder.Append("HearVoice,HeatRate,Apex,Smoking,Sports,Salt,Action,AssistCheck,AfterPill,Compliance,Untoward,UntowardEx,");
            builder.Append("FollowType,ReferralReason,ReferralDepart,NextVisitDate,VisitDoctor,CreateBy,CreateDate,LastUpDateBy,");
            builder.Append("LastUpDateDate,IsDelete,VisitDate,VisitType,");
            builder.Append("ChdType,Height,BMI,FPGL,TC,TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,");
            builder.Append("HeartCheckResult,SmokeDay,DrinkDay,SportWeek,SportMinute,SpecialTreated,NondrugTreat,Syndromeother,");
            builder.Append("DoctorView,IsReferral ");
            builder.Append(" from tbl_chronicchdvisit where IDCardNo=@IDCardNo order by VisitDate desc limit 0,1 ");
            //builder.Append("select tbl_chronicchdvisit.ID,tbl_chronicchdvisit.RecordID,tbl_chronicchdvisit.IDCardNo,tbl_chronicchdvisit.CustomerID,");
            //builder.Append("Symptom,SymptomEx,tbl_recordsgeneralcondition.LeftHeight as Systolic,tbl_recordsgeneralcondition.LeftPre as Diastolic,tbl_recordsgeneralcondition.Weight, ");
            //builder.Append("HearVoice,HeatRate,Apex,Smoking,Sports,Salt,Action,AssistCheck,AfterPill,Compliance,Untoward,UntowardEx,");
            //builder.Append("FollowType,ReferralReason,ReferralDepart,NextVisitDate,VisitDoctor,CreateBy,CreateDate,LastUpDateBy,");
            //builder.Append("LastUpDateDate,IsDelete,VisitDate,VisitType from tbl_chronicchdvisit ");
            //builder.Append("LEFT JOIN tbl_recordsgeneralcondition ON tbl_chronicchdvisit.IDCardNo=tbl_recordsgeneralcondition.IDCardNo ");
            //builder.Append("where tbl_chronicchdvisit.IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };
            cmdParms[0].Value = IDCardNo;
            new ChronicChdVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public ChronicChdVisitModel GetModelFollowUpDate(ChronicChdVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,Symptom,SymptomEx,Systolic,Diastolic,Weight, ");
            builder.Append("HearVoice,HeatRate,Apex,Smoking,Sports,Salt,Action,AssistCheck,AfterPill,Compliance,Untoward,UntowardEx,");
            builder.Append("FollowType,ReferralReason,ReferralDepart,NextVisitDate,VisitDoctor,CreateBy,CreateDate,LastUpDateBy,");
            builder.Append("LastUpDateDate,IsDelete,VisitDate,VisitType ,");
            builder.Append("ChdType,Height,BMI,FPGL,TC,TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,");
            builder.Append("HeartCheckResult,SmokeDay,DrinkDay,SportWeek,SportMinute,SpecialTreated,NondrugTreat,Syndromeother,");
            builder.Append("DoctorView,IsReferral ");
            builder.Append(" from tbl_chronicchdvisit where IDCardNo=@IDCardNo and VisitDate=@VisitDate ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@VisitDate", MySqlDbType.Date)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.VisitDate;
            new ChronicChdVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public ChronicChdVisitModel GetModelID(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,Symptom,SymptomEx,Systolic,Diastolic,Weight, ");
            builder.Append("HearVoice,HeatRate,Apex,Smoking,Sports,Salt,Action,AssistCheck,AfterPill,Compliance,Untoward,UntowardEx,");
            builder.Append("FollowType,ReferralReason,ReferralDepart,NextVisitDate,VisitDoctor,CreateBy,CreateDate,LastUpDateBy,");
            builder.Append("LastUpDateDate,IsDelete,VisitDate,VisitType,");
            builder.Append("ChdType,Height,BMI,FPGL,TC,TG,LowCho,HeiCho,EcgCheckResult,EcgExerciseResult,CAG,EnzymesResult,");
            builder.Append("HeartCheckResult,SmokeDay,DrinkDay,SportWeek,SportMinute,SpecialTreated,NondrugTreat,Syndromeother,");
            builder.Append("DoctorView,IsReferral ");
            builder.Append(" from tbl_chronicchdvisit where ID=@ID ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = ID;
            new ChronicChdVisitModel();
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
            builder.Append("select count(1)  FROM tbl_chronicchdvisit C ");
            builder.Append("left join tbl_recordsbaseinfo T on T.IDCardNo = C.IDCardNo   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1  " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(ChronicChdVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_chronicchdvisit set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("SymptomEx=@SymptomEx,");
            builder.Append("Systolic=@Systolic,");
            builder.Append("Diastolic=@Diastolic,");
            builder.Append("Weight=@Weight,");
            builder.Append("HearVoice=@HearVoice,");
            builder.Append("HeatRate=@HeatRate,");
            builder.Append("Apex=@Apex,");
            builder.Append("Smoking=@Smoking,");
            builder.Append("Sports=@Sports,");
            builder.Append("Salt=@Salt,");
            builder.Append("Action=@Action,");
            builder.Append("AssistCheck=@AssistCheck,");
            builder.Append("AfterPill=@AfterPill,");
            builder.Append("Compliance=@Compliance,");
            builder.Append("Untoward=@Untoward,");
            builder.Append("UntowardEx=@UntowardEx,");
            builder.Append("FollowType=@FollowType,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralDepart=@ReferralDepart,");
            builder.Append("NextVisitDate=@NextVisitDate,");
            builder.Append("VisitDoctor=@VisitDoctor,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpDateBy=@LastUpDateBy,");
            builder.Append("LastUpDateDate=@LastUpDateDate,");
            builder.Append("IsDelete=@IsDelete,");
            builder.Append("VisitDate=@VisitDate,");
            builder.Append("VisitType=@VisitType,");
            builder.Append("ChdType=@ChdType,");
            builder.Append("Height=@Height,");
            builder.Append("BMI=@BMI,");
            builder.Append("FPGL=@FPGL,");
            builder.Append("TC=@TC,");
            builder.Append("TG=@TG,");
            builder.Append("LowCho=@LowCho,");
            builder.Append("HeiCho=@HeiCho,");
            builder.Append("EcgCheckResult=@EcgCheckResult,");
            builder.Append("EcgExerciseResult=@EcgExerciseResult,");
            builder.Append("CAG=@CAG,");
            builder.Append("EnzymesResult=@EnzymesResult,");
            builder.Append("HeartCheckResult=@HeartCheckResult,");
            builder.Append("SmokeDay=@SmokeDay,");
            builder.Append("DrinkDay=@DrinkDay,");
            builder.Append("SportWeek=@SportWeek,");
            builder.Append("SportMinute=@SportMinute,");
            builder.Append("SpecialTreated=@SpecialTreated,");
            builder.Append("NondrugTreat=@NondrugTreat,");
            builder.Append("Syndromeother=@Syndromeother,");
            builder.Append("DoctorView=@DoctorView,");
            builder.Append("IsReferral=@IsReferral ");
            builder.Append(" where ID=@ID");
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
                new MySqlParameter("@HeatRate", MySqlDbType.String, 1), 
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
                new MySqlParameter("@VisitType", MySqlDbType.String, 1), 
                new MySqlParameter("@ChdType", MySqlDbType.String, 100),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@FPGL", MySqlDbType.Decimal),
                new MySqlParameter("@TC", MySqlDbType.Decimal),
                new MySqlParameter("@TG", MySqlDbType.Decimal),
                new MySqlParameter("@LowCho", MySqlDbType.Decimal),
                new MySqlParameter("@HeiCho", MySqlDbType.Decimal),
                new MySqlParameter("@EcgCheckResult", MySqlDbType.String, 100),
                new MySqlParameter("@EcgExerciseResult", MySqlDbType.String, 100),
                new MySqlParameter("@CAG", MySqlDbType.String, 100),
                new MySqlParameter("@EnzymesResult", MySqlDbType.String, 100),
                new MySqlParameter("@HeartCheckResult", MySqlDbType.String, 100),
                new MySqlParameter("@SmokeDay", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkDay", MySqlDbType.Decimal),
                new MySqlParameter("@SportWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportMinute", MySqlDbType.Decimal),
                new MySqlParameter("@SpecialTreated", MySqlDbType.String, 100),
                new MySqlParameter("@NondrugTreat", MySqlDbType.String, 100),
                new MySqlParameter("@Syndromeother", MySqlDbType.String, 100),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 100),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
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
            cmdParms[32].Value = model.ChdType;
            cmdParms[33].Value = model.Height;
            cmdParms[34].Value = model.BMI;
            cmdParms[35].Value = model.FPGL;
            cmdParms[36].Value = model.TC;
            cmdParms[37].Value = model.TG;
            cmdParms[38].Value = model.LowCho;
            cmdParms[39].Value = model.HeiCho;
            cmdParms[40].Value = model.EcgCheckResult;
            cmdParms[41].Value = model.EcgExerciseResult;
            cmdParms[42].Value = model.CAG;
            cmdParms[43].Value = model.EnzymesResult;
            cmdParms[44].Value = model.HeartCheckResult;
            cmdParms[45].Value = model.SmokeDay;
            cmdParms[46].Value = model.DrinkDay;
            cmdParms[47].Value = model.SportWeek;
            cmdParms[48].Value = model.SportMinute;
            cmdParms[49].Value = model.SpecialTreated;
            cmdParms[50].Value = model.NondrugTreat;
            cmdParms[51].Value = model.Syndromeother;
            cmdParms[52].Value = model.DoctorView;
            cmdParms[53].Value = model.IsReferral; 
            cmdParms[54].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(ChronicChdVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_chronicchdvisit set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("SymptomEx=@SymptomEx,");
            builder.Append("Systolic=@Systolic,");
            builder.Append("Diastolic=@Diastolic,");
            builder.Append("Weight=@Weight,");
            builder.Append("HearVoice=@HearVoice,");
            builder.Append("HeatRate=@HeatRate,");
            builder.Append("Apex=@Apex,");
            builder.Append("Smoking=@Smoking,");
            builder.Append("Sports=@Sports,");
            builder.Append("Salt=@Salt,");
            builder.Append("Action=@Action,");
            builder.Append("AssistCheck=@AssistCheck,");
            builder.Append("AfterPill=@AfterPill,");
            builder.Append("Compliance=@Compliance,");
            builder.Append("Untoward=@Untoward,");
            builder.Append("UntowardEx=@UntowardEx,");
            builder.Append("FollowType=@FollowType,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralDepart=@ReferralDepart,");
            builder.Append("NextVisitDate=@NextVisitDate,");
            builder.Append("VisitDoctor=@VisitDoctor,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpDateBy=@LastUpDateBy,");
            builder.Append("LastUpDateDate=@LastUpDateDate,");
            builder.Append("IsDelete=@IsDelete,");
            builder.Append("VisitDate=@VisitDate,");
            builder.Append("VisitType=@VisitType,");
            builder.Append("ChdType=@ChdType,");
            builder.Append("Height=@Height,");
            builder.Append("BMI=@BMI,");
            builder.Append("FPGL=@FPGL,");
            builder.Append("TC=@TC,");
            builder.Append("TG=@TG,");
            builder.Append("LowCho=@LowCho,");
            builder.Append("HeiCho=@HeiCho,");
            builder.Append("EcgCheckResult=@EcgCheckResult,");
            builder.Append("EcgExerciseResult=@EcgExerciseResult,");
            builder.Append("CAG=@CAG,");
            builder.Append("EnzymesResult=@EnzymesResult,");
            builder.Append("HeartCheckResult=@HeartCheckResult,");
            builder.Append("SmokeDay=@SmokeDay,");
            builder.Append("DrinkDay=@DrinkDay,");
            builder.Append("SportWeek=@SportWeek,");
            builder.Append("SportMinute=@SportMinute,");
            builder.Append("SpecialTreated=@SpecialTreated,");
            builder.Append("NondrugTreat=@NondrugTreat,");
            builder.Append("Syndromeother=@Syndromeother,");
            builder.Append("DoctorView=@DoctorView,");
            builder.Append("IsReferral=@IsReferral ");
            builder.Append(" where ID=@ID");
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
                new MySqlParameter("@HeatRate", MySqlDbType.String, 1), 
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
                new MySqlParameter("@VisitType", MySqlDbType.String, 1), 
                new MySqlParameter("@ChdType", MySqlDbType.String, 100),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@FPGL", MySqlDbType.Decimal),
                new MySqlParameter("@TC", MySqlDbType.Decimal),
                new MySqlParameter("@TG", MySqlDbType.Decimal),
                new MySqlParameter("@LowCho", MySqlDbType.Decimal),
                new MySqlParameter("@HeiCho", MySqlDbType.Decimal),
                new MySqlParameter("@EcgCheckResult", MySqlDbType.String, 100),
                new MySqlParameter("@EcgExerciseResult", MySqlDbType.String, 100),
                new MySqlParameter("@CAG", MySqlDbType.String, 100),
                new MySqlParameter("@EnzymesResult", MySqlDbType.String, 100),
                new MySqlParameter("@HeartCheckResult", MySqlDbType.String, 100),
                new MySqlParameter("@SmokeDay", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkDay", MySqlDbType.Decimal),
                new MySqlParameter("@SportWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportMinute", MySqlDbType.Decimal),
                new MySqlParameter("@SpecialTreated", MySqlDbType.String, 100),
                new MySqlParameter("@NondrugTreat", MySqlDbType.String, 100),
                new MySqlParameter("@Syndromeother", MySqlDbType.String, 100),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 100),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
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
            cmdParms[32].Value = model.ChdType;
            cmdParms[33].Value = model.Height;
            cmdParms[34].Value = model.BMI;
            cmdParms[35].Value = model.FPGL;
            cmdParms[36].Value = model.TC;
            cmdParms[37].Value = model.TG;
            cmdParms[38].Value = model.LowCho;
            cmdParms[39].Value = model.HeiCho;
            cmdParms[40].Value = model.EcgCheckResult;
            cmdParms[41].Value = model.EcgExerciseResult;
            cmdParms[42].Value = model.CAG;
            cmdParms[43].Value = model.EnzymesResult;
            cmdParms[44].Value = model.HeartCheckResult;
            cmdParms[45].Value = model.SmokeDay;
            cmdParms[46].Value = model.DrinkDay;
            cmdParms[47].Value = model.SportWeek;
            cmdParms[48].Value = model.SportMinute;
            cmdParms[49].Value = model.SpecialTreated;
            cmdParms[50].Value = model.NondrugTreat;
            cmdParms[51].Value = model.Syndromeother;
            cmdParms[52].Value = model.DoctorView;
            cmdParms[53].Value = model.IsReferral;
            cmdParms[54].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public DataSet DtChdCount()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select IDCardNo , NextVisitDate FROM  tbl_chronicchdvisit order by NextVisitDate desc ");
            return MySQLHelper.Query(builder.ToString());
        }
    }
}

