namespace KangShuoTech.DataAccessProjects.DAL
{
    using Utilities.MySQLHelper;
    using Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicStrokeVisitDAL
    {
        //山东v2.0添加字段：Strokelocation,StrokeType,MedicalHistory,Syndrome,SyndromeOther,NewSymptom,NewSymptomOther,SmokeDay,DrinkDay,SportWeek,
        //SportMinute,FPGL,Height,BMI,Waistline,LifeSelfCare,LimbRecover,RecoveryCure,RecoveryCureOther,DoctorView,IsReferral --共21个
        public int Add(ChronicStrokeVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_chronicstrokevisit(");
            builder.Append("CustomerID,IDCardNo,FollowupDate,FollowUpDoctor,NextFollowUpDate,Symptom,SymptomOther,");
            builder.Append("Hypertension,Hypotension,Weight,SignOther,SmokeDrinkAttention,SportAttention,");
            builder.Append("EatSaltAttention,PsychicAdjust,ObeyDoctorBehavio,AssistantExam,MedicationCompliance,");
            builder.Append("Adr,AdrEx,FollowupType,ReferralReason,ReferralOrg,FollowupWay,CreatedBy,");
            builder.Append("CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,RecordID,EatingDrug, ");
            builder.Append("Strokelocation,StrokeType,MedicalHistory,Syndrome,SyndromeOther,NewSymptom,NewSymptomOther,");
            builder.Append("SmokeDay,DrinkDay,SportWeek,SportMinute,FPGL,Height,BMI,Waistline,LifeSelfCare,LimbRecover,");
            builder.Append("RecoveryCure,RecoveryCureOther,DoctorView,IsReferral,FollowupTypeOther ) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@IDCardNo,@FollowupDate,@FollowUpDoctor,@NextFollowUpDate,@Symptom,@SymptomOther,");
            builder.Append("@Hypertension,@Hypotension,@Weight,@SignOther,@SmokeDrinkAttention,@SportAttention,@EatSaltAttention,");
            builder.Append("@PsychicAdjust,@ObeyDoctorBehavio,@AssistantExam,@MedicationCompliance,@Adr,@AdrEx,@FollowupType,");
            builder.Append("@ReferralReason,@ReferralOrg,@FollowupWay,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,");
            builder.Append("@IsDel,@RecordID,@EatingDrug,");
            builder.Append("@Strokelocation,@StrokeType,@MedicalHistory,@Syndrome,@SyndromeOther,@NewSymptom,@NewSymptomOther,");
            builder.Append("@SmokeDay,@DrinkDay,@SportWeek,@SportMinute,@FPGL,@Height,@BMI,@Waistline,@LifeSelfCare,@LimbRecover,");
            builder.Append("@RecoveryCure,@RecoveryCureOther,@DoctorView,@IsReferral,@FollowupTypeOther ) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
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
                new MySqlParameter("@EatingDrug", MySqlDbType.String, 255),
                new MySqlParameter("@Strokelocation", MySqlDbType.String, 1),
                new MySqlParameter("@StrokeType", MySqlDbType.String, 1),
                new MySqlParameter("@MedicalHistory", MySqlDbType.String, 255),
                new MySqlParameter("@Syndrome", MySqlDbType.String, 255),
                new MySqlParameter("@SyndromeOther", MySqlDbType.String, 255),
                new MySqlParameter("@NewSymptom", MySqlDbType.String, 255),
                new MySqlParameter("@NewSymptomOther", MySqlDbType.String, 255),
                new MySqlParameter("@SmokeDay", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkDay", MySqlDbType.Decimal),
                new MySqlParameter("@SportWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportMinute", MySqlDbType.Decimal),
                new MySqlParameter("@FPGL", MySqlDbType.Decimal),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@Waistline", MySqlDbType.Decimal),
                new MySqlParameter("@LifeSelfCare", MySqlDbType.String, 1),
                new MySqlParameter("@LimbRecover", MySqlDbType.String, 1),
                new MySqlParameter("@RecoveryCure", MySqlDbType.String, 100),
                new MySqlParameter("@RecoveryCureOther", MySqlDbType.String, 255),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 255),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1),
                new MySqlParameter("@FollowupTypeOther", MySqlDbType.String, 255)
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
            cmdParms[31].Value = model.Strokelocation;
            cmdParms[32].Value = model.StrokeType;
            cmdParms[33].Value = model.MedicalHistory;
            cmdParms[34].Value = model.Syndrome;
            cmdParms[35].Value = model.SyndromeOther;
            cmdParms[36].Value = model.NewSymptom;
            cmdParms[37].Value = model.NewSymptomOther;
            cmdParms[38].Value = model.SmokeDay;
            cmdParms[39].Value = model.DrinkDay;
            cmdParms[40].Value = model.SportWeek;
            cmdParms[41].Value = model.SportMinute;
            cmdParms[42].Value = model.FPGL;
            cmdParms[43].Value = model.Height;
            cmdParms[44].Value = model.BMI;
            cmdParms[45].Value = model.Waistline;
            cmdParms[46].Value = model.LifeSelfCare;
            cmdParms[47].Value = model.LimbRecover;
            cmdParms[48].Value = model.RecoveryCure;
            cmdParms[49].Value = model.RecoveryCureOther;
            cmdParms[50].Value = model.DoctorView;
            cmdParms[51].Value = model.IsReferral;
            cmdParms[52].Value = model.FollowupTypeOther; 
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(ChronicStrokeVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_chronicstrokevisit(");
            builder.Append("CustomerID,IDCardNo,FollowupDate,FollowUpDoctor,NextFollowUpDate,Symptom,SymptomOther,");
            builder.Append("Hypertension,Hypotension,Weight,SignOther,SmokeDrinkAttention,SportAttention,");
            builder.Append("EatSaltAttention,PsychicAdjust,ObeyDoctorBehavio,AssistantExam,MedicationCompliance,");
            builder.Append("Adr,AdrEx,FollowupType,ReferralReason,ReferralOrg,FollowupWay,CreatedBy,");
            builder.Append("CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,RecordID,EatingDrug, ");
            builder.Append("Strokelocation,StrokeType,MedicalHistory,Syndrome,SyndromeOther,NewSymptom,NewSymptomOther,");
            builder.Append("SmokeDay,DrinkDay,SportWeek,SportMinute,FPGL,Height,BMI,Waistline,LifeSelfCare,LimbRecover,");
            builder.Append("RecoveryCure,RecoveryCureOther,DoctorView,IsReferral,FollowupTypeOther ) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@IDCardNo,@FollowupDate,@FollowUpDoctor,@NextFollowUpDate,@Symptom,@SymptomOther,");
            builder.Append("@Hypertension,@Hypotension,@Weight,@SignOther,@SmokeDrinkAttention,@SportAttention,@EatSaltAttention,");
            builder.Append("@PsychicAdjust,@ObeyDoctorBehavio,@AssistantExam,@MedicationCompliance,@Adr,@AdrEx,@FollowupType,");
            builder.Append("@ReferralReason,@ReferralOrg,@FollowupWay,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,");
            builder.Append("@IsDel,@RecordID,@EatingDrug,");
            builder.Append("@Strokelocation,@StrokeType,@MedicalHistory,@Syndrome,@SyndromeOther,@NewSymptom,@NewSymptomOther,");
            builder.Append("@SmokeDay,@DrinkDay,@SportWeek,@SportMinute,@FPGL,@Height,@BMI,@Waistline,@LifeSelfCare,@LimbRecover,");
            builder.Append("@RecoveryCure,@RecoveryCureOther,@DoctorView,@IsReferral,@FollowupTypeOther ) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
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
                new MySqlParameter("@EatingDrug", MySqlDbType.String, 255),
                new MySqlParameter("@Strokelocation", MySqlDbType.String, 1),
                new MySqlParameter("@StrokeType", MySqlDbType.String, 1),
                new MySqlParameter("@MedicalHistory", MySqlDbType.String, 255),
                new MySqlParameter("@Syndrome", MySqlDbType.String, 255),
                new MySqlParameter("@SyndromeOther", MySqlDbType.String, 255),
                new MySqlParameter("@NewSymptom", MySqlDbType.String, 255),
                new MySqlParameter("@NewSymptomOther", MySqlDbType.String, 255),
                new MySqlParameter("@SmokeDay", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkDay", MySqlDbType.Decimal),
                new MySqlParameter("@SportWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportMinute", MySqlDbType.Decimal),
                new MySqlParameter("@FPGL", MySqlDbType.Decimal),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@Waistline", MySqlDbType.Decimal),
                new MySqlParameter("@LifeSelfCare", MySqlDbType.String, 1),
                new MySqlParameter("@LimbRecover", MySqlDbType.String, 1),
                new MySqlParameter("@RecoveryCure", MySqlDbType.String, 100),
                new MySqlParameter("@RecoveryCureOther", MySqlDbType.String, 255),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 255),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1),
                new MySqlParameter("@FollowupTypeOther", MySqlDbType.String, 255)
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
            cmdParms[31].Value = model.Strokelocation;
            cmdParms[32].Value = model.StrokeType;
            cmdParms[33].Value = model.MedicalHistory;
            cmdParms[34].Value = model.Syndrome;
            cmdParms[35].Value = model.SyndromeOther;
            cmdParms[36].Value = model.NewSymptom;
            cmdParms[37].Value = model.NewSymptomOther;
            cmdParms[38].Value = model.SmokeDay;
            cmdParms[39].Value = model.DrinkDay;
            cmdParms[40].Value = model.SportWeek;
            cmdParms[41].Value = model.SportMinute;
            cmdParms[42].Value = model.FPGL;
            cmdParms[43].Value = model.Height;
            cmdParms[44].Value = model.BMI;
            cmdParms[45].Value = model.Waistline;
            cmdParms[46].Value = model.LifeSelfCare;
            cmdParms[47].Value = model.LimbRecover;
            cmdParms[48].Value = model.RecoveryCure;
            cmdParms[49].Value = model.RecoveryCureOther;
            cmdParms[50].Value = model.DoctorView;
            cmdParms[51].Value = model.IsReferral;
            cmdParms[52].Value = model.FollowupTypeOther; 
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public ChronicStrokeVisitModel DataRowToModel(DataRow row)
        {
            ChronicStrokeVisitModel chronicStrokeVisitModel = new ChronicStrokeVisitModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicStrokeVisitModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["FollowupDate"] != null) && (row["FollowupDate"] != DBNull.Value)) && (row["FollowupDate"].ToString() != ""))
                {
                    chronicStrokeVisitModel.FollowupDate = new DateTime?(DateTime.Parse(row["FollowupDate"].ToString()));
                }
                if ((row["FollowUpDoctor"] != null) && (row["FollowUpDoctor"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.FollowUpDoctor = row["FollowUpDoctor"].ToString();
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    chronicStrokeVisitModel.NextFollowupDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["Symptom"] != null) && (row["Symptom"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.Symptom = row["Symptom"].ToString();
                }
                if ((row["SymptomOther"] != null) && (row["SymptomOther"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.SymptomOther = row["SymptomOther"].ToString();
                }
                if (((row["Hypertension"] != null) && (row["Hypertension"] != DBNull.Value)) && (row["Hypertension"].ToString() != ""))
                {
                    chronicStrokeVisitModel.Hypertension = new decimal?(decimal.Parse(row["Hypertension"].ToString()));
                }
                if (((row["Hypotension"] != null) && (row["Hypotension"] != DBNull.Value)) && (row["Hypotension"].ToString() != ""))
                {
                    chronicStrokeVisitModel.Hypotension  = new decimal?(decimal.Parse(row["Hypotension"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    chronicStrokeVisitModel.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if ((row["SignOther"] != null) && (row["SignOther"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.SignOther = row["SignOther"].ToString();
                }
                if ((row["SmokeDrinkAttention"] != null) && (row["SmokeDrinkAttention"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.SmokeDrinkAttention = row["SmokeDrinkAttention"].ToString();
                }
                if ((row["SportAttention"] != null) && (row["SportAttention"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.SportAttention = row["SportAttention"].ToString();
                }
                if ((row["EatSaltAttention"] != null) && (row["EatSaltAttention"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.EatSaltAttention = row["EatSaltAttention"].ToString();
                }
                if ((row["PsychicAdjust"] != null) && (row["PsychicAdjust"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.PsychicAdjust = row["PsychicAdjust"].ToString();
                }
                if ((row["ObeyDoctorBehavio"] != null) && (row["ObeyDoctorBehavio"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.ObeyDoctorBehavio = row["ObeyDoctorBehavio"].ToString();
                }
                if ((row["AssistantExam"] != null) && (row["AssistantExam"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.AssistantExam = row["AssistantExam"].ToString();
                }
                if ((row["MedicationCompliance"] != null) && (row["MedicationCompliance"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.MedicationCompliance = row["MedicationCompliance"].ToString();
                }
                if ((row["Adr"] != null) && (row["Adr"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.Adr = row["Adr"].ToString();
                }
                if ((row["AdrEx"] != null) && (row["AdrEx"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.AdrEx = row["AdrEx"].ToString();
                }
                if ((row["FollowupType"] != null) && (row["FollowupType"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.FollowupType = row["FollowupType"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["ReferralOrg"] != null) && (row["ReferralOrg"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.ReferralOrg = row["ReferralOrg"].ToString();
                }
                if ((row["FollowupWay"] != null) && (row["FollowupWay"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.FollowupWay = row["FollowupWay"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    chronicStrokeVisitModel.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    chronicStrokeVisitModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    chronicStrokeVisitModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    chronicStrokeVisitModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.IsDel = row["IsDel"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["EatingDrug"] != null) && (row["EatingDrug"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.EatingDrug = row["EatingDrug"].ToString();
                }
                if ((row["Strokelocation"] != null) && (row["Strokelocation"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.Strokelocation = row["Strokelocation"].ToString();
                }
                if ((row["StrokeType"] != null) && (row["StrokeType"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.StrokeType = row["StrokeType"].ToString();
                }
                if ((row["MedicalHistory"] != null) && (row["MedicalHistory"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.MedicalHistory = row["MedicalHistory"].ToString();
                }
                if ((row["Syndrome"] != null) && (row["Syndrome"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.Syndrome = row["Syndrome"].ToString();
                }
                if ((row["SyndromeOther"] != null) && (row["SyndromeOther"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.SyndromeOther = row["SyndromeOther"].ToString();
                }
                if ((row["NewSymptom"] != null) && (row["NewSymptom"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.NewSymptom = row["NewSymptom"].ToString();
                }
                if ((row["NewSymptomOther"] != null) && (row["NewSymptomOther"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.NewSymptomOther = row["NewSymptomOther"].ToString();
                }
                if (((row["SmokeDay"] != null) && (row["SmokeDay"] != DBNull.Value)) && (row["SmokeDay"].ToString() != ""))
                {
                    chronicStrokeVisitModel.SmokeDay = new decimal?(decimal.Parse(row["SmokeDay"].ToString()));
                }
                if (((row["DrinkDay"] != null) && (row["DrinkDay"] != DBNull.Value)) && (row["DrinkDay"].ToString() != ""))
                {
                    chronicStrokeVisitModel.DrinkDay = new decimal?(decimal.Parse(row["DrinkDay"].ToString()));
                }
                if (((row["SportWeek"] != null) && (row["SportWeek"] != DBNull.Value)) && (row["SportWeek"].ToString() != ""))
                {
                    chronicStrokeVisitModel.SportWeek = new decimal?(decimal.Parse(row["SportWeek"].ToString()));
                }
                if (((row["SportMinute"] != null) && (row["SportMinute"] != DBNull.Value)) && (row["SportMinute"].ToString() != ""))
                {
                    chronicStrokeVisitModel.SportMinute = new decimal?(decimal.Parse(row["SportMinute"].ToString()));
                }
                if (((row["FPGL"] != null) && (row["FPGL"] != DBNull.Value)) && (row["FPGL"].ToString() != ""))
                {
                    chronicStrokeVisitModel.FPGL = new decimal?(decimal.Parse(row["FPGL"].ToString()));
                }
                if (((row["Height"] != null) && (row["Height"] != DBNull.Value)) && (row["Height"].ToString() != ""))
                {
                    chronicStrokeVisitModel.Height = new decimal?(decimal.Parse(row["Height"].ToString()));
                }
                if (((row["BMI"] != null) && (row["BMI"] != DBNull.Value)) && (row["BMI"].ToString() != ""))
                {
                    chronicStrokeVisitModel.BMI = new decimal?(decimal.Parse(row["BMI"].ToString()));
                }
                if (((row["Waistline"] != null) && (row["Waistline"] != DBNull.Value)) && (row["Waistline"].ToString() != ""))
                {
                    chronicStrokeVisitModel.Waistline = new decimal?(decimal.Parse(row["Waistline"].ToString()));
                }
                if ((row["LifeSelfCare"] != null) && (row["LifeSelfCare"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.LifeSelfCare = row["LifeSelfCare"].ToString();
                }
                if ((row["LimbRecover"] != null) && (row["LimbRecover"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.LimbRecover = row["LimbRecover"].ToString();
                }
                if ((row["RecoveryCure"] != null) && (row["RecoveryCure"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.RecoveryCure = row["RecoveryCure"].ToString();
                }
                if ((row["RecoveryCureOther"] != null) && (row["RecoveryCureOther"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.RecoveryCureOther = row["RecoveryCureOther"].ToString();
                }
                if ((row["DoctorView"] != null) && (row["DoctorView"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.DoctorView = row["DoctorView"].ToString();
                }
                if ((row["IsReferral"] != null) && (row["IsReferral"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.IsReferral = row["IsReferral"].ToString();
                }
                if ((row["FollowupTypeOther"] != null) && (row["FollowupTypeOther"] != DBNull.Value))
                {
                    chronicStrokeVisitModel.FollowupTypeOther = row["FollowupTypeOther"].ToString();
                }
            }
            return chronicStrokeVisitModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chronicstrokevisit ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chronicstrokevisit ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_chronicstrokevisit");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public bool ExistVisitdate(string visitdate, string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_chronicstrokevisit ");
            builder.Append(" where FollowupDate = @FollowupDate and IDCardNo =@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@FollowupDate", Convert.ToDateTime( visitdate).ToShortDateString()),
                new MySqlParameter("@IDCardNo", IDCardNo)
            };
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public ChronicStrokeVisitModel ExistsCheckDate(ChronicStrokeVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,IDCardNo,FollowupDate,FollowUpDoctor,NextFollowUpDate,Symptom,");
            builder.Append("SymptomOther,Hypertension,Hypotension,Weight,SignOther,SmokeDrinkAttention,SportAttention,");
            builder.Append("EatSaltAttention,PsychicAdjust,ObeyDoctorBehavio,AssistantExam,MedicationCompliance,Adr,AdrEx,");
            builder.Append("FollowupType,ReferralReason,ReferralOrg,FollowupWay,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,");
            builder.Append("IsDel,RecordID,EatingDrug, ");
            builder.Append("Strokelocation,StrokeType,MedicalHistory,Syndrome,SyndromeOther,NewSymptom,NewSymptomOther,");
            builder.Append("SmokeDay,DrinkDay,SportWeek,SportMinute,FPGL,Height,BMI,Waistline,LifeSelfCare,LimbRecover,");
            builder.Append("RecoveryCure,RecoveryCureOther,DoctorView,IsReferral,FollowupTypeOther ");
            builder.Append(" FROM tbl_chronicstrokevisit ");
            builder.Append(" where FollowupDate = @FollowupDate and IDCardNo =@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
            };
            cmdParms[0].Value = model.FollowupDate;
            cmdParms[1].Value = model.IDCardNo;
            new ChronicStrokeVisitModel();
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
            builder.Append("select ID,CustomerID,IDCardNo,FollowupDate,FollowUpDoctor,NextFollowUpDate,Symptom,");
            builder.Append("SymptomOther,Hypertension,Hypotension,Weight,SignOther,SmokeDrinkAttention,SportAttention,");
            builder.Append("EatSaltAttention,PsychicAdjust,ObeyDoctorBehavio,AssistantExam,MedicationCompliance,Adr,AdrEx,");
            builder.Append("FollowupType,ReferralReason,ReferralOrg,FollowupWay,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,");
            builder.Append("IsDel,RecordID,EatingDrug, ");
            builder.Append("Strokelocation,StrokeType,MedicalHistory,Syndrome,SyndromeOther,NewSymptom,NewSymptomOther,");
            builder.Append("SmokeDay,DrinkDay,SportWeek,SportMinute,FPGL,Height,BMI,Waistline,LifeSelfCare,LimbRecover,");
            builder.Append("RecoveryCure,RecoveryCureOther,DoctorView,IsReferral,FollowupTypeOther ");
            builder.Append(" FROM tbl_chronicstrokevisit ");
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
            builder.Append("(case C.FollowupDate when null then null when '' then null else C.FollowupDate end) FollowupDate, ");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName ");
            builder.Append(" from tbl_chronicstrokevisit C inner join tbl_recordsbaseinfo T on T.IDCardNo = C.IDCardNo ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_chronicstrokevisit");
        }

        public ChronicStrokeVisitModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,IDCardNo,FollowupDate,FollowUpDoctor,NextFollowUpDate,Symptom,");
            builder.Append("SymptomOther,Hypertension,Hypotension,Weight,SignOther,SmokeDrinkAttention,SportAttention,");
            builder.Append("EatSaltAttention,PsychicAdjust,ObeyDoctorBehavio,AssistantExam,MedicationCompliance,Adr,AdrEx,");
            builder.Append("FollowupType,ReferralReason,ReferralOrg,FollowupWay,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,");
            builder.Append("IsDel,RecordID,EatingDrug , ");
            builder.Append("Strokelocation,StrokeType,MedicalHistory,Syndrome,SyndromeOther,NewSymptom,NewSymptomOther,");
            builder.Append("SmokeDay,DrinkDay,SportWeek,SportMinute,FPGL,Height,BMI,Waistline,LifeSelfCare,LimbRecover,");
            builder.Append("RecoveryCure,RecoveryCureOther,DoctorView,IsReferral,FollowupTypeOther ");
            builder.Append(" from tbl_chronicstrokevisit where IDCardNo=@IDCardNo order by FollowupDate desc limit 0,1 ");
            //builder.Append("select tbl_chronicstrokevisit.ID,tbl_chronicstrokevisit.CustomerID,tbl_chronicstrokevisit.IDCardNo,FollowupDate,FollowUpDoctor,NextFollowUpDate,Symptom,");
            //builder.Append("SymptomOther,tbl_recordsgeneralcondition.LeftHeight as Hypertension,tbl_recordsgeneralcondition.LeftPre as Hypotension,tbl_recordsgeneralcondition.Weight,SignOther,SmokeDrinkAttention,SportAttention,");
            //builder.Append("EatSaltAttention,PsychicAdjust,ObeyDoctorBehavio,AssistantExam,MedicationCompliance,Adr,AdrEx,");
            //builder.Append("FollowupType,ReferralReason,ReferralOrg,FollowupWay,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,");
            //builder.Append("IsDel,RecordID,EatingDrug from tbl_chronicstrokevisit  ");
            //builder.Append("	LEFT JOIN tbl_recordsgeneralcondition ON tbl_recordsgeneralcondition.IDCardNo=tbl_chronicstrokevisit.IDCardNo ");
            //builder.Append(" where tbl_chronicstrokevisit.IDCardNo=@IDCardNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new ChronicStrokeVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public ChronicStrokeVisitModel GetModelFollowUpDate(ChronicStrokeVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,IDCardNo,FollowupDate,FollowUpDoctor,NextFollowUpDate,Symptom,");
            builder.Append("SymptomOther,Hypertension,Hypotension,Weight,SignOther,SmokeDrinkAttention,SportAttention,");
            builder.Append("EatSaltAttention,PsychicAdjust,ObeyDoctorBehavio,AssistantExam,MedicationCompliance,Adr,AdrEx,");
            builder.Append("FollowupType,ReferralReason,ReferralOrg,FollowupWay,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,");
            builder.Append("IsDel,RecordID,EatingDrug , ");
            builder.Append("Strokelocation,StrokeType,MedicalHistory,Syndrome,SyndromeOther,NewSymptom,NewSymptomOther,");
            builder.Append("SmokeDay,DrinkDay,SportWeek,SportMinute,FPGL,Height,BMI,Waistline,LifeSelfCare,LimbRecover,");
            builder.Append("RecoveryCure,RecoveryCureOther,DoctorView,IsReferral,FollowupTypeOther ");
            builder.Append(" from tbl_chronicstrokevisit where IDCardNo=@IDCardNo and FollowupDate=@FollowupDate ");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.FollowupDate;
            new ChronicStrokeVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public ChronicStrokeVisitModel GetModelID(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,IDCardNo,FollowupDate,FollowUpDoctor,NextFollowUpDate,Symptom,");
            builder.Append("SymptomOther,Hypertension,Hypotension,Weight,SignOther,SmokeDrinkAttention,SportAttention,");
            builder.Append("EatSaltAttention,PsychicAdjust,ObeyDoctorBehavio,AssistantExam,MedicationCompliance,Adr,AdrEx,");
            builder.Append("FollowupType,ReferralReason,ReferralOrg,FollowupWay,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,");
            builder.Append("IsDel,RecordID,EatingDrug , ");
            builder.Append("Strokelocation,StrokeType,MedicalHistory,Syndrome,SyndromeOther,NewSymptom,NewSymptomOther,");
            builder.Append("SmokeDay,DrinkDay,SportWeek,SportMinute,FPGL,Height,BMI,Waistline,LifeSelfCare,LimbRecover,");
            builder.Append("RecoveryCure,RecoveryCureOther,DoctorView,IsReferral,FollowupTypeOther ");
            builder.Append(" from tbl_chronicstrokevisit where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = ID;
            new ChronicStrokeVisitModel();
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
            builder.Append("select count(1) FROM tbl_chronicstrokevisit C ");
            builder.Append("left join tbl_recordsbaseinfo T on T.IDCardNo = C.IDCardNo   ");
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
      
        public bool Update(ChronicStrokeVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_chronicstrokevisit set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("SymptomOther=@SymptomOther,");
            builder.Append("Hypertension=@Hypertension,");
            builder.Append("Hypotension=@Hypotension,");
            builder.Append("Weight=@Weight,");
            builder.Append("SignOther=@SignOther,");
            builder.Append("SmokeDrinkAttention=@SmokeDrinkAttention,");
            builder.Append("SportAttention=@SportAttention,");
            builder.Append("EatSaltAttention=@EatSaltAttention,");
            builder.Append("PsychicAdjust=@PsychicAdjust,");
            builder.Append("ObeyDoctorBehavio=@ObeyDoctorBehavio,");
            builder.Append("AssistantExam=@AssistantExam,");
            builder.Append("MedicationCompliance=@MedicationCompliance,");
            builder.Append("Adr=@Adr,");
            builder.Append("AdrEx=@AdrEx,");
            builder.Append("FollowupType=@FollowupType,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("FollowupWay=@FollowupWay,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("EatingDrug=@EatingDrug,");
            builder.Append("Strokelocation=@Strokelocation, StrokeType=@StrokeType,MedicalHistory=@MedicalHistory,Syndrome=@Syndrome,");
            builder.Append("SyndromeOther=@SyndromeOther, NewSymptom=@NewSymptom,NewSymptomOther=@NewSymptomOther,SmokeDay=@SmokeDay,");
            builder.Append("DrinkDay=@DrinkDay, SportWeek=@SportWeek,SportMinute=@SportMinute,FPGL=@FPGL,Height=@Height,BMI=@BMI,Waistline=@Waistline, ");
            builder.Append("LifeSelfCare=@LifeSelfCare,LimbRecover=@LimbRecover,RecoveryCure=@RecoveryCure,RecoveryCureOther=@RecoveryCureOther,");
            builder.Append("DoctorView=@DoctorView,IsReferral=@IsReferral,FollowupTypeOther=@FollowupTypeOther ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
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
                new MySqlParameter("@EatingDrug", MySqlDbType.String, 255),
                new MySqlParameter("@Strokelocation", MySqlDbType.String, 1),
                new MySqlParameter("@StrokeType", MySqlDbType.String, 1),
                new MySqlParameter("@MedicalHistory", MySqlDbType.String, 255),
                new MySqlParameter("@Syndrome", MySqlDbType.String, 255),
                new MySqlParameter("@SyndromeOther", MySqlDbType.String, 255),
                new MySqlParameter("@NewSymptom", MySqlDbType.String, 255),
                new MySqlParameter("@NewSymptomOther", MySqlDbType.String, 255),
                new MySqlParameter("@SmokeDay", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkDay", MySqlDbType.Decimal),
                new MySqlParameter("@SportWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportMinute", MySqlDbType.Decimal),
                new MySqlParameter("@FPGL", MySqlDbType.Decimal),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@Waistline", MySqlDbType.Decimal),
                new MySqlParameter("@LifeSelfCare", MySqlDbType.String, 1),
                new MySqlParameter("@LimbRecover", MySqlDbType.String, 1),
                new MySqlParameter("@RecoveryCure", MySqlDbType.String, 100),
                new MySqlParameter("@RecoveryCureOther", MySqlDbType.String, 255),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 255),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1),
                new MySqlParameter("@FollowupTypeOther", MySqlDbType.String, 255),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
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
            cmdParms[31].Value = model.Strokelocation;
            cmdParms[32].Value = model.StrokeType;
            cmdParms[33].Value = model.MedicalHistory;
            cmdParms[34].Value = model.Syndrome;
            cmdParms[35].Value = model.SyndromeOther;
            cmdParms[36].Value = model.NewSymptom;
            cmdParms[37].Value = model.NewSymptomOther;
            cmdParms[38].Value = model.SmokeDay;
            cmdParms[39].Value = model.DrinkDay;
            cmdParms[40].Value = model.SportWeek;
            cmdParms[41].Value = model.SportMinute;
            cmdParms[42].Value = model.FPGL;
            cmdParms[43].Value = model.Height;
            cmdParms[44].Value = model.BMI;
            cmdParms[45].Value = model.Waistline;
            cmdParms[46].Value = model.LifeSelfCare;
            cmdParms[47].Value = model.LimbRecover;
            cmdParms[48].Value = model.RecoveryCure;
            cmdParms[49].Value = model.RecoveryCureOther;
            cmdParms[50].Value = model.DoctorView;
            cmdParms[51].Value = model.IsReferral;
            cmdParms[52].Value = model.FollowupTypeOther;
            cmdParms[53].Value = model.ID; 
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(ChronicStrokeVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_chronicstrokevisit set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("SymptomOther=@SymptomOther,");
            builder.Append("Hypertension=@Hypertension,");
            builder.Append("Hypotension=@Hypotension,");
            builder.Append("Weight=@Weight,");
            builder.Append("SignOther=@SignOther,");
            builder.Append("SmokeDrinkAttention=@SmokeDrinkAttention,");
            builder.Append("SportAttention=@SportAttention,");
            builder.Append("EatSaltAttention=@EatSaltAttention,");
            builder.Append("PsychicAdjust=@PsychicAdjust,");
            builder.Append("ObeyDoctorBehavio=@ObeyDoctorBehavio,");
            builder.Append("AssistantExam=@AssistantExam,");
            builder.Append("MedicationCompliance=@MedicationCompliance,");
            builder.Append("Adr=@Adr,");
            builder.Append("AdrEx=@AdrEx,");
            builder.Append("FollowupType=@FollowupType,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("FollowupWay=@FollowupWay,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("EatingDrug=@EatingDrug,");
            builder.Append("Strokelocation=@Strokelocation, StrokeType=@StrokeType,MedicalHistory=@MedicalHistory,Syndrome=@Syndrome,");
            builder.Append("SyndromeOther=@SyndromeOther, NewSymptom=@NewSymptom,NewSymptomOther=@NewSymptomOther,SmokeDay=@SmokeDay,");
            builder.Append("DrinkDay=@DrinkDay, SportWeek=@SportWeek,SportMinute=@SportMinute,FPGL=@FPGL,Height=@Height,BMI=@BMI,Waistline=@Waistline, ");
            builder.Append("LifeSelfCare=@LifeSelfCare,LimbRecover=@LimbRecover,RecoveryCure=@RecoveryCure,RecoveryCureOther=@RecoveryCureOther,");
            builder.Append("DoctorView=@DoctorView,IsReferral=@IsReferral,FollowupTypeOther=@FollowupTypeOther ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
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
                new MySqlParameter("@EatingDrug", MySqlDbType.String, 255),
                new MySqlParameter("@Strokelocation", MySqlDbType.String, 1),
                new MySqlParameter("@StrokeType", MySqlDbType.String, 1),
                new MySqlParameter("@MedicalHistory", MySqlDbType.String, 255),
                new MySqlParameter("@Syndrome", MySqlDbType.String, 255),
                new MySqlParameter("@SyndromeOther", MySqlDbType.String, 255),
                new MySqlParameter("@NewSymptom", MySqlDbType.String, 255),
                new MySqlParameter("@NewSymptomOther", MySqlDbType.String, 255),
                new MySqlParameter("@SmokeDay", MySqlDbType.Decimal),
                new MySqlParameter("@DrinkDay", MySqlDbType.Decimal),
                new MySqlParameter("@SportWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportMinute", MySqlDbType.Decimal),
                new MySqlParameter("@FPGL", MySqlDbType.Decimal),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@Waistline", MySqlDbType.Decimal),
                new MySqlParameter("@LifeSelfCare", MySqlDbType.String, 1),
                new MySqlParameter("@LimbRecover", MySqlDbType.String, 1),
                new MySqlParameter("@RecoveryCure", MySqlDbType.String, 100),
                new MySqlParameter("@RecoveryCureOther", MySqlDbType.String, 255),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 255),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1),
                new MySqlParameter("@FollowupTypeOther", MySqlDbType.String, 255),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
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
            cmdParms[31].Value = model.Strokelocation;
            cmdParms[32].Value = model.StrokeType;
            cmdParms[33].Value = model.MedicalHistory;
            cmdParms[34].Value = model.Syndrome;
            cmdParms[35].Value = model.SyndromeOther;
            cmdParms[36].Value = model.NewSymptom;
            cmdParms[37].Value = model.NewSymptomOther;
            cmdParms[38].Value = model.SmokeDay;
            cmdParms[39].Value = model.DrinkDay;
            cmdParms[40].Value = model.SportWeek;
            cmdParms[41].Value = model.SportMinute;
            cmdParms[42].Value = model.FPGL;
            cmdParms[43].Value = model.Height;
            cmdParms[44].Value = model.BMI;
            cmdParms[45].Value = model.Waistline;
            cmdParms[46].Value = model.LifeSelfCare;
            cmdParms[47].Value = model.LimbRecover;
            cmdParms[48].Value = model.RecoveryCure;
            cmdParms[49].Value = model.RecoveryCureOther;
            cmdParms[50].Value = model.DoctorView;
            cmdParms[51].Value = model.IsReferral;
            cmdParms[52].Value = model.FollowupTypeOther;
            cmdParms[53].Value = model.ID; 
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }

        public DataSet DtStrokeCount()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select IDCardNo , NextFollowUpDate FROM  tbl_chronicstrokevisit order by NextFollowUpDate desc ");
            return MySQLHelper.Query(builder.ToString());
        }
    }
}

