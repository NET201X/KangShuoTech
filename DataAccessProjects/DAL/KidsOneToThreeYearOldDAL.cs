namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class KidsOneToThreeYearOldDAL
    {
        public int Add(KidsOneToThreeYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CHILD_ONE2THREE_YEAR_OLD(");
            builder.Append("CustomerID,RecordID,IDCardNo,Name,FollowupDate,Weight,WeightAnalysis,Stature,StatureAnalysis,ColourFace,Skin,Bregma,BregmaLeft,BregmaRight,EyeAppearance,EarAppearance,Listening,TeethDcnLeft,TeethDcnRight,HeartLung,Stomach,FourLimb,Gait,SuspiciousRickets,HemoglobinValue,OutdoorActivities,TakingVitaminsd,AuxeEstimate,AmongTwoFollowup,Other,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,GuidanceOther,NextFollowUpDate,FollowUpDoctorSign,Flag,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,");
            builder.Append("Chest,SickNone,PneumoniaCounts,DiarrheaCounts,TraumaCounts,SickOther,ReferraContacts,ReferralContactsTel,ReferralResult) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Name,@FollowupDate,@Weight,@WeightAnalysis,@Stature,@StatureAnalysis,@ColourFace,@Skin,@Bregma,@BregmaLeft,@BregmaRight,@EyeAppearance,@EarAppearance,@Listening,@TeethDcnLeft,@TeethDcnRight,@HeartLung,@Stomach,@FourLimb,@Gait,@SuspiciousRickets,@HemoglobinValue,@OutdoorActivities,@TakingVitaminsd,@AuxeEstimate,@AmongTwoFollowup,@Other,@ReferralAdvice,@ReferralReason,@AgenciesDepartments,@Guidance,@GuidanceOther,@NextFollowUpDate,@FollowUpDoctorSign,@Flag,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,");
            builder.Append("@Chest,@SickNone,@PneumoniaCounts,@DiarrheaCounts,@TraumaCounts,@SickOther,@ReferraContacts,@ReferralContactsTel,@ReferralResult) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1), 
                new MySqlParameter("@Stature", MySqlDbType.Decimal),
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@ColourFace", MySqlDbType.String, 1), 
                new MySqlParameter("@Skin", MySqlDbType.String, 1),
                new MySqlParameter("@Bregma", MySqlDbType.String, 1),
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal),
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal),
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@Listening", MySqlDbType.String, 1), 
                new MySqlParameter("@TeethDcnLeft", MySqlDbType.Decimal),
                new MySqlParameter("@TeethDcnRight", MySqlDbType.Decimal),
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1),
                new MySqlParameter("@FourLimb", MySqlDbType.String, 1),
                new MySqlParameter("@Gait", MySqlDbType.String, 1),
                new MySqlParameter("@SuspiciousRickets", MySqlDbType.String, 1), 
                new MySqlParameter("@HemoglobinValue", MySqlDbType.Decimal), 
                new MySqlParameter("@OutdoorActivities", MySqlDbType.Decimal),
                new MySqlParameter("@TakingVitaminsd", MySqlDbType.Decimal),
                new MySqlParameter("@AuxeEstimate", MySqlDbType.String, 1), 
                new MySqlParameter("@AmongTwoFollowup", MySqlDbType.String, 1),
                new MySqlParameter("@Other", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80),
                new MySqlParameter("@Guidance", MySqlDbType.String, 30), 
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30),
                new MySqlParameter("@Flag", MySqlDbType.String, 1),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@SickNone", MySqlDbType.String, 10),
                new MySqlParameter("@PneumoniaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@DiarrheaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@TraumaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@SickOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.FollowupDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.ColourFace;
            cmdParms[10].Value = model.Skin;
            cmdParms[11].Value = model.Bregma;
            cmdParms[12].Value = model.BregmaLeft;
            cmdParms[13].Value = model.BregmaRight;
            cmdParms[14].Value = model.EyeAppearance;
            cmdParms[15].Value = model.EarAppearance;
            cmdParms[16].Value = model.Listening;
            cmdParms[17].Value = model.TeethDcnLeft;
            cmdParms[18].Value = model.TeethDcnRight;
            cmdParms[19].Value = model.HeartLung;
            cmdParms[20].Value = model.Stomach;
            cmdParms[21].Value = model.FourLimb;
            cmdParms[22].Value = model.Gait;
            cmdParms[23].Value = model.SuspiciousRickets;
            cmdParms[24].Value = model.HemoglobinValue;
            cmdParms[25].Value = model.OutdoorActivities;
            cmdParms[26].Value = model.TakingVitaminsd;
            cmdParms[27].Value = model.AuxeEstimate;
            cmdParms[28].Value = model.AmongTwoFollowup;
            cmdParms[29].Value = model.Other;
            cmdParms[30].Value = model.ReferralAdvice;
            cmdParms[31].Value = model.ReferralReason;
            cmdParms[32].Value = model.AgenciesDepartments;
            cmdParms[33].Value = model.Guidance;
            cmdParms[34].Value = model.GuidanceOther;
            cmdParms[35].Value = model.NextFollowupDate;
            cmdParms[36].Value = model.FollowUpDoctorSign;
            cmdParms[37].Value = model.Flag;
            cmdParms[38].Value = model.CreatedBy;
            cmdParms[39].Value = model.CreatedDate;
            cmdParms[40].Value = model.LastUpdateBy;
            cmdParms[41].Value = model.LastUpdateDate;
            cmdParms[42].Value = model.IsDel;
            cmdParms[43].Value = model.Chest;
            cmdParms[44].Value = model.SickNone;
            cmdParms[45].Value = model.PneumoniaCounts;
            cmdParms[46].Value = model.DiarrheaCounts;
            cmdParms[47].Value = model.TraumaCounts;
            cmdParms[48].Value = model.SickOther;
            cmdParms[49].Value = model.ReferraContacts;
            cmdParms[50].Value = model.ReferralContactsTel;
            cmdParms[51].Value = model.ReferralResult;  
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(KidsOneToThreeYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CHILD_ONE2THREE_YEAR_OLD(");
            builder.Append("CustomerID,RecordID,IDCardNo,Name,FollowupDate,Weight,WeightAnalysis,Stature,StatureAnalysis,ColourFace,Skin,Bregma,BregmaLeft,BregmaRight,EyeAppearance,EarAppearance,Listening,TeethDcnLeft,TeethDcnRight,HeartLung,Stomach,FourLimb,Gait,SuspiciousRickets,HemoglobinValue,OutdoorActivities,TakingVitaminsd,AuxeEstimate,AmongTwoFollowup,Other,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,GuidanceOther,NextFollowUpDate,FollowUpDoctorSign,Flag,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,");
            builder.Append("Chest,SickNone,PneumoniaCounts,DiarrheaCounts,TraumaCounts,SickOther,ReferraContacts,ReferralContactsTel,ReferralResult) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Name,@FollowupDate,@Weight,@WeightAnalysis,@Stature,@StatureAnalysis,@ColourFace,@Skin,@Bregma,@BregmaLeft,@BregmaRight,@EyeAppearance,@EarAppearance,@Listening,@TeethDcnLeft,@TeethDcnRight,@HeartLung,@Stomach,@FourLimb,@Gait,@SuspiciousRickets,@HemoglobinValue,@OutdoorActivities,@TakingVitaminsd,@AuxeEstimate,@AmongTwoFollowup,@Other,@ReferralAdvice,@ReferralReason,@AgenciesDepartments,@Guidance,@GuidanceOther,@NextFollowUpDate,@FollowUpDoctorSign,@Flag,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,");
            builder.Append("@Chest,@SickNone,@PneumoniaCounts,@DiarrheaCounts,@TraumaCounts,@SickOther,@ReferraContacts,@ReferralContactsTel,@ReferralResult) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1), 
                new MySqlParameter("@Stature", MySqlDbType.Decimal),
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@ColourFace", MySqlDbType.String, 1), 
                new MySqlParameter("@Skin", MySqlDbType.String, 1),
                new MySqlParameter("@Bregma", MySqlDbType.String, 1),
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal),
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal),
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@Listening", MySqlDbType.String, 1), 
                new MySqlParameter("@TeethDcnLeft", MySqlDbType.Decimal),
                new MySqlParameter("@TeethDcnRight", MySqlDbType.Decimal),
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1),
                new MySqlParameter("@FourLimb", MySqlDbType.String, 1),
                new MySqlParameter("@Gait", MySqlDbType.String, 1),
                new MySqlParameter("@SuspiciousRickets", MySqlDbType.String, 1), 
                new MySqlParameter("@HemoglobinValue", MySqlDbType.Decimal), 
                new MySqlParameter("@OutdoorActivities", MySqlDbType.Decimal),
                new MySqlParameter("@TakingVitaminsd", MySqlDbType.Decimal),
                new MySqlParameter("@AuxeEstimate", MySqlDbType.String, 1), 
                new MySqlParameter("@AmongTwoFollowup", MySqlDbType.String, 1),
                new MySqlParameter("@Other", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80),
                new MySqlParameter("@Guidance", MySqlDbType.String, 30), 
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30),
                new MySqlParameter("@Flag", MySqlDbType.String, 1),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@SickNone", MySqlDbType.String, 10),
                new MySqlParameter("@PneumoniaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@DiarrheaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@TraumaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@SickOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.FollowupDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.ColourFace;
            cmdParms[10].Value = model.Skin;
            cmdParms[11].Value = model.Bregma;
            cmdParms[12].Value = model.BregmaLeft;
            cmdParms[13].Value = model.BregmaRight;
            cmdParms[14].Value = model.EyeAppearance;
            cmdParms[15].Value = model.EarAppearance;
            cmdParms[16].Value = model.Listening;
            cmdParms[17].Value = model.TeethDcnLeft;
            cmdParms[18].Value = model.TeethDcnRight;
            cmdParms[19].Value = model.HeartLung;
            cmdParms[20].Value = model.Stomach;
            cmdParms[21].Value = model.FourLimb;
            cmdParms[22].Value = model.Gait;
            cmdParms[23].Value = model.SuspiciousRickets;
            cmdParms[24].Value = model.HemoglobinValue;
            cmdParms[25].Value = model.OutdoorActivities;
            cmdParms[26].Value = model.TakingVitaminsd;
            cmdParms[27].Value = model.AuxeEstimate;
            cmdParms[28].Value = model.AmongTwoFollowup;
            cmdParms[29].Value = model.Other;
            cmdParms[30].Value = model.ReferralAdvice;
            cmdParms[31].Value = model.ReferralReason;
            cmdParms[32].Value = model.AgenciesDepartments;
            cmdParms[33].Value = model.Guidance;
            cmdParms[34].Value = model.GuidanceOther;
            cmdParms[35].Value = model.NextFollowupDate;
            cmdParms[36].Value = model.FollowUpDoctorSign;
            cmdParms[37].Value = model.Flag;
            cmdParms[38].Value = model.CreatedBy;
            cmdParms[39].Value = model.CreatedDate;
            cmdParms[40].Value = model.LastUpdateBy;
            cmdParms[41].Value = model.LastUpdateDate;
            cmdParms[42].Value = model.IsDel;
            cmdParms[43].Value = model.Chest;
            cmdParms[44].Value = model.SickNone;
            cmdParms[45].Value = model.PneumoniaCounts;
            cmdParms[46].Value = model.DiarrheaCounts;
            cmdParms[47].Value = model.TraumaCounts;
            cmdParms[48].Value = model.SickOther;
            cmdParms[49].Value = model.ReferraContacts;
            cmdParms[50].Value = model.ReferralContactsTel;
            cmdParms[51].Value = model.ReferralResult;  
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public KidsOneToThreeYearOldModel DataRowToModel(DataRow row)
        {
            KidsOneToThreeYearOldModel kidsOneToThreeYearOldModel = new KidsOneToThreeYearOldModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.Name = row["Name"].ToString();
                }
                if (((row["FollowupDate"] != null) && (row["FollowupDate"] != DBNull.Value)) && (row["FollowupDate"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.FollowupDate = new DateTime?(DateTime.Parse(row["FollowupDate"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if ((row["WeightAnalysis"] != null) && (row["WeightAnalysis"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.WeightAnalysis = row["WeightAnalysis"].ToString();
                }
                if (((row["Stature"] != null) && (row["Stature"] != DBNull.Value)) && (row["Stature"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.Stature = new decimal?(decimal.Parse(row["Stature"].ToString()));
                }
                if ((row["StatureAnalysis"] != null) && (row["StatureAnalysis"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.StatureAnalysis = row["StatureAnalysis"].ToString();
                }
                if ((row["ColourFace"] != null) && (row["ColourFace"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.ColourFace = row["ColourFace"].ToString();
                }
                if ((row["Skin"] != null) && (row["Skin"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.Skin = row["Skin"].ToString();
                }
                if ((row["Bregma"] != null) && (row["Bregma"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.Bregma = row["Bregma"].ToString();
                }
                if (((row["BregmaLeft"] != null) && (row["BregmaLeft"] != DBNull.Value)) && (row["BregmaLeft"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.BregmaLeft = new decimal?(decimal.Parse(row["BregmaLeft"].ToString()));
                }
                if (((row["BregmaRight"] != null) && (row["BregmaRight"] != DBNull.Value)) && (row["BregmaRight"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.BregmaRight = new decimal?(decimal.Parse(row["BregmaRight"].ToString()));
                }
                if ((row["EyeAppearance"] != null) && (row["EyeAppearance"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.EyeAppearance = row["EyeAppearance"].ToString();
                }
                if ((row["EarAppearance"] != null) && (row["EarAppearance"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.EarAppearance = row["EarAppearance"].ToString();
                }
                if ((row["Listening"] != null) && (row["Listening"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.Listening = row["Listening"].ToString();
                }
                if (((row["TeethDcnLeft"] != null) && (row["TeethDcnLeft"] != DBNull.Value)) && (row["TeethDcnLeft"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.TeethDcnLeft = new decimal?(decimal.Parse(row["TeethDcnLeft"].ToString()));
                }
                if (((row["TeethDcnRight"] != null) && (row["TeethDcnRight"] != DBNull.Value)) && (row["TeethDcnRight"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.TeethDcnRight = new decimal?(decimal.Parse(row["TeethDcnRight"].ToString()));
                }
                if ((row["HeartLung"] != null) && (row["HeartLung"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.HeartLung = row["HeartLung"].ToString();
                }
                if ((row["Stomach"] != null) && (row["Stomach"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.Stomach = row["Stomach"].ToString();
                }
                if ((row["FourLimb"] != null) && (row["FourLimb"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.FourLimb = row["FourLimb"].ToString();
                }
                if ((row["Gait"] != null) && (row["Gait"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.Gait = row["Gait"].ToString();
                }
                if ((row["SuspiciousRickets"] != null) && (row["SuspiciousRickets"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.SuspiciousRickets = row["SuspiciousRickets"].ToString();
                }
                if (((row["HemoglobinValue"] != null) && (row["HemoglobinValue"] != DBNull.Value)) && (row["HemoglobinValue"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.HemoglobinValue = new decimal?(decimal.Parse(row["HemoglobinValue"].ToString()));
                }
                if (((row["OutdoorActivities"] != null) && (row["OutdoorActivities"] != DBNull.Value)) && (row["OutdoorActivities"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.OutdoorActivities = new decimal?(decimal.Parse(row["OutdoorActivities"].ToString()));
                }
                if (((row["TakingVitaminsd"] != null) && (row["TakingVitaminsd"] != DBNull.Value)) && (row["TakingVitaminsd"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.TakingVitaminsd = new decimal?(decimal.Parse(row["TakingVitaminsd"].ToString()));
                }
                if ((row["AuxeEstimate"] != null) && (row["AuxeEstimate"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.AuxeEstimate = row["AuxeEstimate"].ToString();
                }
                if ((row["AmongTwoFollowup"] != null) && (row["AmongTwoFollowup"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.AmongTwoFollowup = row["AmongTwoFollowup"].ToString();
                }
                if ((row["Other"] != null) && (row["Other"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.Other = row["Other"].ToString();
                }
                if ((row["ReferralAdvice"] != null) && (row["ReferralAdvice"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.ReferralAdvice = row["ReferralAdvice"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["AgenciesDepartments"] != null) && (row["AgenciesDepartments"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.AgenciesDepartments = row["AgenciesDepartments"].ToString();
                }
                if ((row["Guidance"] != null) && (row["Guidance"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.Guidance = row["Guidance"].ToString();
                }
                if ((row["GuidanceOther"] != null) && (row["GuidanceOther"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.GuidanceOther = row["GuidanceOther"].ToString();
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.NextFollowupDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["FollowUpDoctorSign"] != null) && (row["FollowUpDoctorSign"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.FollowUpDoctorSign = row["FollowUpDoctorSign"].ToString();
                }
                if ((row["Flag"] != null) && (row["Flag"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.Flag = row["Flag"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.CreatedBy = decimal.Parse(row["CreatedBy"].ToString());
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.LastUpdateBy = decimal.Parse(row["LastUpdateBy"].ToString());
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.LastUpdateDate = DateTime.Parse(row["LastUpdateDate"].ToString());
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.IsDel = row["IsDel"].ToString();
                }
                if ((row["Chest"] != null) && (row["Chest"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.Chest = row["Chest"].ToString();
                }
                if ((row["SickNone"] != null) && (row["SickNone"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.SickNone = row["SickNone"].ToString();
                }
                if (((row["PneumoniaCounts"] != null) && (row["PneumoniaCounts"] != DBNull.Value)) && (row["PneumoniaCounts"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.PneumoniaCounts = new decimal?(decimal.Parse(row["PneumoniaCounts"].ToString()));
                }
                if (((row["DiarrheaCounts"] != null) && (row["DiarrheaCounts"] != DBNull.Value)) && (row["DiarrheaCounts"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.DiarrheaCounts = new decimal?(decimal.Parse(row["DiarrheaCounts"].ToString()));
                }
                if (((row["TraumaCounts"] != null) && (row["TraumaCounts"] != DBNull.Value)) && (row["TraumaCounts"].ToString() != ""))
                {
                    kidsOneToThreeYearOldModel.TraumaCounts = new decimal?(decimal.Parse(row["TraumaCounts"].ToString()));
                }
                if ((row["SickOther"] != null) && (row["SickOther"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.SickOther = row["SickOther"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.ReferralResult = row["ReferralResult"].ToString();
                }
                if ((row["ReferraContacts"] != null) && (row["ReferraContacts"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.ReferraContacts = row["ReferraContacts"].ToString();
                }
                if ((row["ReferralContactsTel"] != null) && (row["ReferralContactsTel"] != DBNull.Value))
                {
                    kidsOneToThreeYearOldModel.ReferralContactsTel = row["ReferralContactsTel"].ToString();
                }

            }
            return kidsOneToThreeYearOldModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CHILD_ONE2THREE_YEAR_OLD ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CHILD_ONE2THREE_YEAR_OLD ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CHILD_ONE2THREE_YEAR_OLD");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,Name,FollowupDate,Weight,WeightAnalysis,Stature,StatureAnalysis,ColourFace,Skin,Bregma,BregmaLeft,BregmaRight,EyeAppearance,EarAppearance,Listening,TeethDcnLeft,TeethDcnRight,HeartLung,Stomach,FourLimb,Gait,SuspiciousRickets,HemoglobinValue,OutdoorActivities,TakingVitaminsd,AuxeEstimate,AmongTwoFollowup,Other,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,GuidanceOther,NextFollowUpDate,FollowUpDoctorSign,Flag,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel, ");
            builder.Append("Chest,SickNone,PneumoniaCounts,DiarrheaCounts,TraumaCounts,SickOther,ReferraContacts,ReferralContactsTel,ReferralResult ");
            builder.Append(" FROM CHILD_ONE2THREE_YEAR_OLD ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from CHILD_ONE2THREE_YEAR_OLD T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "CHILD_ONE2THREE_YEAR_OLD");
        }

        public KidsOneToThreeYearOldModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Name,FollowupDate,Weight,WeightAnalysis,Stature,StatureAnalysis,ColourFace,Skin,Bregma,BregmaLeft,BregmaRight,EyeAppearance,EarAppearance,Listening,TeethDcnLeft,TeethDcnRight,HeartLung,Stomach,FourLimb,Gait,SuspiciousRickets,HemoglobinValue,OutdoorActivities,TakingVitaminsd,AuxeEstimate,AmongTwoFollowup,Other,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,GuidanceOther,NextFollowUpDate,FollowUpDoctorSign,Flag,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel, ");
            builder.Append("Chest,SickNone,PneumoniaCounts,DiarrheaCounts,TraumaCounts,SickOther,ReferraContacts,ReferralContactsTel,ReferralResult ");
            builder.Append(" FROM CHILD_ONE2THREE_YEAR_OLD ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };
            cmdParms[0].Value = IDCardNo;
            new KidsOneToThreeYearOldModel();
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
            builder.Append("select count(1) FROM CHILD_ONE2THREE_YEAR_OLD ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(KidsOneToThreeYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CHILD_ONE2THREE_YEAR_OLD set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Name=@Name,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("Weight=@Weight,");
            builder.Append("WeightAnalysis=@WeightAnalysis,");
            builder.Append("Stature=@Stature,");
            builder.Append("StatureAnalysis=@StatureAnalysis,");
            builder.Append("ColourFace=@ColourFace,");
            builder.Append("Skin=@Skin,");
            builder.Append("Bregma=@Bregma,");
            builder.Append("BregmaLeft=@BregmaLeft,");
            builder.Append("BregmaRight=@BregmaRight,");
            builder.Append("EyeAppearance=@EyeAppearance,");
            builder.Append("EarAppearance=@EarAppearance,");
            builder.Append("Listening=@Listening,");
            builder.Append("TeethDcnLeft=@TeethDcnLeft,");
            builder.Append("TeethDcnRight=@TeethDcnRight,");
            builder.Append("HeartLung=@HeartLung,");
            builder.Append("Stomach=@Stomach,");
            builder.Append("FourLimb=@FourLimb,");
            builder.Append("Gait=@Gait,");
            builder.Append("SuspiciousRickets=@SuspiciousRickets,");
            builder.Append("HemoglobinValue=@HemoglobinValue,");
            builder.Append("OutdoorActivities=@OutdoorActivities,");
            builder.Append("TakingVitaminsd=@TakingVitaminsd,");
            builder.Append("AuxeEstimate=@AuxeEstimate,");
            builder.Append("AmongTwoFollowup=@AmongTwoFollowup,");
            builder.Append("Other=@Other,");
            builder.Append("ReferralAdvice=@ReferralAdvice,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("AgenciesDepartments=@AgenciesDepartments,");
            builder.Append("Guidance=@Guidance,");
            builder.Append("GuidanceOther=@GuidanceOther,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctorSign=@FollowUpDoctorSign,");
            builder.Append("Flag=@Flag,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("Chest=@Chest,");
            builder.Append("SickNone=@SickNone,");
            builder.Append("PneumoniaCounts=@PneumoniaCounts,");
            builder.Append("DiarrheaCounts=@DiarrheaCounts,");
            builder.Append("TraumaCounts=@TraumaCounts,");
            builder.Append("SickOther=@SickOther,");
            builder.Append("ReferraContacts=@ReferraContacts, ");
            builder.Append("ReferralContactsTel=@ReferralContactsTel, ");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1), 
                new MySqlParameter("@Stature", MySqlDbType.Decimal),
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@ColourFace", MySqlDbType.String, 1),
                new MySqlParameter("@Skin", MySqlDbType.String, 1),
                new MySqlParameter("@Bregma", MySqlDbType.String, 1),
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal),
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal),
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@Listening", MySqlDbType.String, 1), 
                new MySqlParameter("@TeethDcnLeft", MySqlDbType.Decimal),
                new MySqlParameter("@TeethDcnRight", MySqlDbType.Decimal),
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1), 
                new MySqlParameter("@FourLimb", MySqlDbType.String, 1), 
                new MySqlParameter("@Gait", MySqlDbType.String, 1), 
                new MySqlParameter("@SuspiciousRickets", MySqlDbType.String, 1),
                new MySqlParameter("@HemoglobinValue", MySqlDbType.Decimal),
                new MySqlParameter("@OutdoorActivities", MySqlDbType.Decimal), 
                new MySqlParameter("@TakingVitaminsd", MySqlDbType.Decimal),
                new MySqlParameter("@AuxeEstimate", MySqlDbType.String, 1), 
                new MySqlParameter("@AmongTwoFollowup", MySqlDbType.String, 1),
                new MySqlParameter("@Other", MySqlDbType.String, 100), 
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80),
                new MySqlParameter("@Guidance", MySqlDbType.String, 30), 
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30),
                new MySqlParameter("@Flag", MySqlDbType.String, 1), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@SickNone", MySqlDbType.String, 10),
                new MySqlParameter("@PneumoniaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@DiarrheaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@TraumaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@SickOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.FollowupDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.ColourFace;
            cmdParms[10].Value = model.Skin;
            cmdParms[11].Value = model.Bregma;
            cmdParms[12].Value = model.BregmaLeft;
            cmdParms[13].Value = model.BregmaRight;
            cmdParms[14].Value = model.EyeAppearance;
            cmdParms[15].Value = model.EarAppearance;
            cmdParms[16].Value = model.Listening;
            cmdParms[17].Value = model.TeethDcnLeft;
            cmdParms[18].Value = model.TeethDcnRight;
            cmdParms[19].Value = model.HeartLung;
            cmdParms[20].Value = model.Stomach;
            cmdParms[21].Value = model.FourLimb;
            cmdParms[22].Value = model.Gait;
            cmdParms[23].Value = model.SuspiciousRickets;
            cmdParms[24].Value = model.HemoglobinValue;
            cmdParms[25].Value = model.OutdoorActivities;
            cmdParms[26].Value = model.TakingVitaminsd;
            cmdParms[27].Value = model.AuxeEstimate;
            cmdParms[28].Value = model.AmongTwoFollowup;
            cmdParms[29].Value = model.Other;
            cmdParms[30].Value = model.ReferralAdvice;
            cmdParms[31].Value = model.ReferralReason;
            cmdParms[32].Value = model.AgenciesDepartments;
            cmdParms[33].Value = model.Guidance;
            cmdParms[34].Value = model.GuidanceOther;
            cmdParms[35].Value = model.NextFollowupDate;
            cmdParms[36].Value = model.FollowUpDoctorSign;
            cmdParms[37].Value = model.Flag;
            cmdParms[38].Value = model.CreatedBy;
            cmdParms[39].Value = model.CreatedDate;
            cmdParms[40].Value = model.LastUpdateBy;
            cmdParms[41].Value = model.LastUpdateDate;
            cmdParms[42].Value = model.IsDel;
            cmdParms[43].Value = model.Chest;
            cmdParms[44].Value = model.SickNone;
            cmdParms[45].Value = model.PneumoniaCounts;
            cmdParms[46].Value = model.DiarrheaCounts;
            cmdParms[47].Value = model.TraumaCounts;
            cmdParms[48].Value = model.SickOther;
            cmdParms[49].Value = model.ReferraContacts;
            cmdParms[50].Value = model.ReferralContactsTel;
            cmdParms[51].Value = model.ReferralResult; 
            cmdParms[52].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(KidsOneToThreeYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CHILD_ONE2THREE_YEAR_OLD set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Name=@Name,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("Weight=@Weight,");
            builder.Append("WeightAnalysis=@WeightAnalysis,");
            builder.Append("Stature=@Stature,");
            builder.Append("StatureAnalysis=@StatureAnalysis,");
            builder.Append("ColourFace=@ColourFace,");
            builder.Append("Skin=@Skin,");
            builder.Append("Bregma=@Bregma,");
            builder.Append("BregmaLeft=@BregmaLeft,");
            builder.Append("BregmaRight=@BregmaRight,");
            builder.Append("EyeAppearance=@EyeAppearance,");
            builder.Append("EarAppearance=@EarAppearance,");
            builder.Append("Listening=@Listening,");
            builder.Append("TeethDcnLeft=@TeethDcnLeft,");
            builder.Append("TeethDcnRight=@TeethDcnRight,");
            builder.Append("HeartLung=@HeartLung,");
            builder.Append("Stomach=@Stomach,");
            builder.Append("FourLimb=@FourLimb,");
            builder.Append("Gait=@Gait,");
            builder.Append("SuspiciousRickets=@SuspiciousRickets,");
            builder.Append("HemoglobinValue=@HemoglobinValue,");
            builder.Append("OutdoorActivities=@OutdoorActivities,");
            builder.Append("TakingVitaminsd=@TakingVitaminsd,");
            builder.Append("AuxeEstimate=@AuxeEstimate,");
            builder.Append("AmongTwoFollowup=@AmongTwoFollowup,");
            builder.Append("Other=@Other,");
            builder.Append("ReferralAdvice=@ReferralAdvice,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("AgenciesDepartments=@AgenciesDepartments,");
            builder.Append("Guidance=@Guidance,");
            builder.Append("GuidanceOther=@GuidanceOther,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctorSign=@FollowUpDoctorSign,");
            builder.Append("Flag=@Flag,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("Chest=@Chest,");
            builder.Append("SickNone=@SickNone,");
            builder.Append("PneumoniaCounts=@PneumoniaCounts,");
            builder.Append("DiarrheaCounts=@DiarrheaCounts,");
            builder.Append("TraumaCounts=@TraumaCounts,");
            builder.Append("SickOther=@SickOther,");
            builder.Append("ReferraContacts=@ReferraContacts, ");
            builder.Append("ReferralContactsTel=@ReferralContactsTel, ");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1), 
                new MySqlParameter("@Stature", MySqlDbType.Decimal),
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@ColourFace", MySqlDbType.String, 1),
                new MySqlParameter("@Skin", MySqlDbType.String, 1),
                new MySqlParameter("@Bregma", MySqlDbType.String, 1),
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal),
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal),
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@Listening", MySqlDbType.String, 1), 
                new MySqlParameter("@TeethDcnLeft", MySqlDbType.Decimal),
                new MySqlParameter("@TeethDcnRight", MySqlDbType.Decimal),
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1), 
                new MySqlParameter("@FourLimb", MySqlDbType.String, 1), 
                new MySqlParameter("@Gait", MySqlDbType.String, 1), 
                new MySqlParameter("@SuspiciousRickets", MySqlDbType.String, 1),
                new MySqlParameter("@HemoglobinValue", MySqlDbType.Decimal),
                new MySqlParameter("@OutdoorActivities", MySqlDbType.Decimal), 
                new MySqlParameter("@TakingVitaminsd", MySqlDbType.Decimal),
                new MySqlParameter("@AuxeEstimate", MySqlDbType.String, 1), 
                new MySqlParameter("@AmongTwoFollowup", MySqlDbType.String, 1),
                new MySqlParameter("@Other", MySqlDbType.String, 100), 
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80),
                new MySqlParameter("@Guidance", MySqlDbType.String, 30), 
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30),
                new MySqlParameter("@Flag", MySqlDbType.String, 1), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@SickNone", MySqlDbType.String, 10),
                new MySqlParameter("@PneumoniaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@DiarrheaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@TraumaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@SickOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.FollowupDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.ColourFace;
            cmdParms[10].Value = model.Skin;
            cmdParms[11].Value = model.Bregma;
            cmdParms[12].Value = model.BregmaLeft;
            cmdParms[13].Value = model.BregmaRight;
            cmdParms[14].Value = model.EyeAppearance;
            cmdParms[15].Value = model.EarAppearance;
            cmdParms[16].Value = model.Listening;
            cmdParms[17].Value = model.TeethDcnLeft;
            cmdParms[18].Value = model.TeethDcnRight;
            cmdParms[19].Value = model.HeartLung;
            cmdParms[20].Value = model.Stomach;
            cmdParms[21].Value = model.FourLimb;
            cmdParms[22].Value = model.Gait;
            cmdParms[23].Value = model.SuspiciousRickets;
            cmdParms[24].Value = model.HemoglobinValue;
            cmdParms[25].Value = model.OutdoorActivities;
            cmdParms[26].Value = model.TakingVitaminsd;
            cmdParms[27].Value = model.AuxeEstimate;
            cmdParms[28].Value = model.AmongTwoFollowup;
            cmdParms[29].Value = model.Other;
            cmdParms[30].Value = model.ReferralAdvice;
            cmdParms[31].Value = model.ReferralReason;
            cmdParms[32].Value = model.AgenciesDepartments;
            cmdParms[33].Value = model.Guidance;
            cmdParms[34].Value = model.GuidanceOther;
            cmdParms[35].Value = model.NextFollowupDate;
            cmdParms[36].Value = model.FollowUpDoctorSign;
            cmdParms[37].Value = model.Flag;
            cmdParms[38].Value = model.CreatedBy;
            cmdParms[39].Value = model.CreatedDate;
            cmdParms[40].Value = model.LastUpdateBy;
            cmdParms[41].Value = model.LastUpdateDate;
            cmdParms[42].Value = model.IsDel;
            cmdParms[43].Value = model.Chest;
            cmdParms[44].Value = model.SickNone;
            cmdParms[45].Value = model.PneumoniaCounts;
            cmdParms[46].Value = model.DiarrheaCounts;
            cmdParms[47].Value = model.TraumaCounts;
            cmdParms[48].Value = model.SickOther;
            cmdParms[49].Value = model.ReferraContacts;
            cmdParms[50].Value = model.ReferralContactsTel;
            cmdParms[51].Value = model.ReferralResult; 
            //cmdParms[43].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

