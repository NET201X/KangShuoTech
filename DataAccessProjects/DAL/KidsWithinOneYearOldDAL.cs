namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class KidsWithinOneYearOldDAL
    {
        public int Add(KidsWithinOneYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CHILD_WITHIN_ONE_YEAR_OLD(");
            builder.Append("CustomerID,RecordID,IDCardNo,Name,VisitDate,Weight,WeightAnalysis,Stature,StatureAnalysis,HeadCircumference,ColorFace,Skin,Bregma,BregmaLeft,BregmaRight,NeckMass,EyeAppearance,EarAppearance,Listening,OralCavity,HeartLung,Stomach,UmbilicalRegion,FourLimb,RicketsSympotom,RicketsSign,AnusExternalGenita,HemoglobinValue,OutdoorActivities,TakingVitaminsd,AuxeEstimate,AmongTwoFollowup,Other,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,NextFollowUpDate,FollowUpDoctorSign,Flag,TeethNum,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,");
            builder.Append("Chest,SickNone,PneumoniaCounts,DiarrheaCounts,TraumaCounts,SickOther,GuidesOther,ReferraContacts,ReferralContactsTel,ReferralResult) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Name,@VisitDate,@Weight,@WeightAnalysis,@Stature,@StatureAnalysis,@HeadCircumference,@ColorFace,@Skin,@Bregma,@BregmaLeft,@BregmaRight,@NeckMass,@EyeAppearance,@EarAppearance,@Listening,@OralCavity,@HeartLung,@Stomach,@UmbilicalRegion,@FourLimb,@RicketsSympotom,@RicketsSign,@AnusExternalGenita,@HemoglobinValue,@OutdoorActivities,@TakingVitaminsd,@AuxeEstimate,@AmongTwoFollowup,@Other,@ReferralAdvice,@ReferralReason,@AgenciesDepartments,@Guidance,@NextFollowUpDate,@FollowUpDoctorSign,@Flag,@TeethNum,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,");
            builder.Append("@Chest,@SickNone,@PneumoniaCounts,@DiarrheaCounts,@TraumaCounts,@SickOther,@GuidesOther,@ReferraContacts,@ReferralContactsTel,@ReferralResult) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@VisitDate", MySqlDbType.Date),
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1), 
                new MySqlParameter("@Stature", MySqlDbType.Decimal),
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@HeadCircumference", MySqlDbType.Decimal), 
                new MySqlParameter("@ColorFace", MySqlDbType.String, 1), 
                new MySqlParameter("@Skin", MySqlDbType.String, 1),
                new MySqlParameter("@Bregma", MySqlDbType.String, 1), 
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal),
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal),
                new MySqlParameter("@NeckMass", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@Listening", MySqlDbType.String, 1), 
                new MySqlParameter("@OralCavity", MySqlDbType.String, 1),
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1), 
                new MySqlParameter("@UmbilicalRegion", MySqlDbType.String, 1),
                new MySqlParameter("@FourLimb", MySqlDbType.String, 1), 
                new MySqlParameter("@RicketsSympotom", MySqlDbType.String, 1), 
                new MySqlParameter("@RicketsSign", MySqlDbType.String, 1), 
                new MySqlParameter("@AnusExternalGenita", MySqlDbType.String, 1), 
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
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30),
                new MySqlParameter("@Flag", MySqlDbType.String, 1),
                new MySqlParameter("@TeethNum", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedBy", MySqlDbType.String), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@SickNone", MySqlDbType.String, 10),
                new MySqlParameter("@PneumoniaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@DiarrheaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@TraumaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@SickOther", MySqlDbType.String, 100),
                new MySqlParameter("@GuidesOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.HeadCircumference;
            cmdParms[10].Value = model.ColorFace;
            cmdParms[11].Value = model.Skin;
            cmdParms[12].Value = model.Bregma;
            cmdParms[13].Value = model.BregmaLeft;
            cmdParms[14].Value = model.BregmaRight;
            cmdParms[15].Value = model.NeckMass;
            cmdParms[16].Value = model.EyeAppearance;
            cmdParms[17].Value = model.EarAppearance;
            cmdParms[18].Value = model.Listening;
            cmdParms[19].Value = model.OralCavity;
            cmdParms[20].Value = model.HeartLung;
            cmdParms[21].Value = model.Stomach;
            cmdParms[22].Value = model.UmbilicalRegion;
            cmdParms[23].Value = model.FourLimb;
            cmdParms[24].Value = model.RicketsSympotom;
            cmdParms[25].Value = model.RicketsSign;
            cmdParms[26].Value = model.AnusExternalGenita;
            cmdParms[27].Value = model.HemoglobinValue;
            cmdParms[28].Value = model.OutdoorActivities;
            cmdParms[29].Value = model.TakingVitaminsd;
            cmdParms[30].Value = model.AuxeEstimate;
            cmdParms[31].Value = model.AmongTwoFollowup;
            cmdParms[32].Value = model.Other;
            cmdParms[33].Value = model.ReferralAdvice;
            cmdParms[34].Value = model.ReferralReason;
            cmdParms[35].Value = model.AgenciesDepartments;
            cmdParms[36].Value = model.Guidance;
            cmdParms[37].Value = model.NextFollowupDate;
            cmdParms[38].Value = model.FollowUpDoctorSign;
            cmdParms[39].Value = model.Flag;
            cmdParms[40].Value = model.TeethNum;
            cmdParms[41].Value = model.CreatedBy;
            cmdParms[42].Value = model.CreatedDate;
            cmdParms[43].Value = model.LastUpdateBy;
            cmdParms[44].Value = model.LastUpdateDate;
            cmdParms[45].Value = model.IsDel;
            cmdParms[46].Value = model.Chest;              
            cmdParms[47].Value = model.SickNone;           
            cmdParms[48].Value = model.PneumoniaCounts;    
            cmdParms[49].Value = model.DiarrheaCounts;     
            cmdParms[50].Value = model.TraumaCounts;       
            cmdParms[51].Value = model.SickOther;          
            cmdParms[52].Value = model.GuidesOther;        
            cmdParms[53].Value = model.ReferraContacts;    
            cmdParms[54].Value = model.ReferralContactsTel;
            cmdParms[55].Value = model.ReferralResult;     
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(KidsWithinOneYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CHILD_WITHIN_ONE_YEAR_OLD(");
            builder.Append("CustomerID,RecordID,IDCardNo,Name,VisitDate,Weight,WeightAnalysis,Stature,StatureAnalysis,HeadCircumference,ColorFace,Skin,Bregma,BregmaLeft,BregmaRight,NeckMass,EyeAppearance,EarAppearance,Listening,OralCavity,HeartLung,Stomach,UmbilicalRegion,FourLimb,RicketsSympotom,RicketsSign,AnusExternalGenita,HemoglobinValue,OutdoorActivities,TakingVitaminsd,AuxeEstimate,AmongTwoFollowup,Other,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,NextFollowUpDate,FollowUpDoctorSign,Flag,TeethNum,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,");
            builder.Append("Chest,SickNone,PneumoniaCounts,DiarrheaCounts,TraumaCounts,SickOther,GuidesOther,ReferraContacts,ReferralContactsTel,ReferralResult) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Name,@VisitDate,@Weight,@WeightAnalysis,@Stature,@StatureAnalysis,@HeadCircumference,@ColorFace,@Skin,@Bregma,@BregmaLeft,@BregmaRight,@NeckMass,@EyeAppearance,@EarAppearance,@Listening,@OralCavity,@HeartLung,@Stomach,@UmbilicalRegion,@FourLimb,@RicketsSympotom,@RicketsSign,@AnusExternalGenita,@HemoglobinValue,@OutdoorActivities,@TakingVitaminsd,@AuxeEstimate,@AmongTwoFollowup,@Other,@ReferralAdvice,@ReferralReason,@AgenciesDepartments,@Guidance,@NextFollowUpDate,@FollowUpDoctorSign,@Flag,@TeethNum,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,");
            builder.Append("@Chest,@SickNone,@PneumoniaCounts,@DiarrheaCounts,@TraumaCounts,@SickOther,@GuidesOther,@ReferraContacts,@ReferralContactsTel,@ReferralResult) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@VisitDate", MySqlDbType.Date),
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1), 
                new MySqlParameter("@Stature", MySqlDbType.Decimal),
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@HeadCircumference", MySqlDbType.Decimal), 
                new MySqlParameter("@ColorFace", MySqlDbType.String, 1), 
                new MySqlParameter("@Skin", MySqlDbType.String, 1),
                new MySqlParameter("@Bregma", MySqlDbType.String, 1), 
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal),
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal),
                new MySqlParameter("@NeckMass", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@Listening", MySqlDbType.String, 1), 
                new MySqlParameter("@OralCavity", MySqlDbType.String, 1),
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1), 
                new MySqlParameter("@UmbilicalRegion", MySqlDbType.String, 1),
                new MySqlParameter("@FourLimb", MySqlDbType.String, 1), 
                new MySqlParameter("@RicketsSympotom", MySqlDbType.String, 1), 
                new MySqlParameter("@RicketsSign", MySqlDbType.String, 1), 
                new MySqlParameter("@AnusExternalGenita", MySqlDbType.String, 1), 
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
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30),
                new MySqlParameter("@Flag", MySqlDbType.String, 1),
                new MySqlParameter("@TeethNum", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedBy", MySqlDbType.String), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@SickNone", MySqlDbType.String, 10),
                new MySqlParameter("@PneumoniaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@DiarrheaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@TraumaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@SickOther", MySqlDbType.String, 100),
                new MySqlParameter("@GuidesOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.HeadCircumference;
            cmdParms[10].Value = model.ColorFace;
            cmdParms[11].Value = model.Skin;
            cmdParms[12].Value = model.Bregma;
            cmdParms[13].Value = model.BregmaLeft;
            cmdParms[14].Value = model.BregmaRight;
            cmdParms[15].Value = model.NeckMass;
            cmdParms[16].Value = model.EyeAppearance;
            cmdParms[17].Value = model.EarAppearance;
            cmdParms[18].Value = model.Listening;
            cmdParms[19].Value = model.OralCavity;
            cmdParms[20].Value = model.HeartLung;
            cmdParms[21].Value = model.Stomach;
            cmdParms[22].Value = model.UmbilicalRegion;
            cmdParms[23].Value = model.FourLimb;
            cmdParms[24].Value = model.RicketsSympotom;
            cmdParms[25].Value = model.RicketsSign;
            cmdParms[26].Value = model.AnusExternalGenita;
            cmdParms[27].Value = model.HemoglobinValue;
            cmdParms[28].Value = model.OutdoorActivities;
            cmdParms[29].Value = model.TakingVitaminsd;
            cmdParms[30].Value = model.AuxeEstimate;
            cmdParms[31].Value = model.AmongTwoFollowup;
            cmdParms[32].Value = model.Other;
            cmdParms[33].Value = model.ReferralAdvice;
            cmdParms[34].Value = model.ReferralReason;
            cmdParms[35].Value = model.AgenciesDepartments;
            cmdParms[36].Value = model.Guidance;
            cmdParms[37].Value = model.NextFollowupDate;
            cmdParms[38].Value = model.FollowUpDoctorSign;
            cmdParms[39].Value = model.Flag;
            cmdParms[40].Value = model.TeethNum;
            cmdParms[41].Value = model.CreatedBy;
            cmdParms[42].Value = model.CreatedDate;
            cmdParms[43].Value = model.LastUpdateBy;
            cmdParms[44].Value = model.LastUpdateDate;
            cmdParms[45].Value = model.IsDel;
            cmdParms[46].Value = model.Chest;
            cmdParms[47].Value = model.SickNone;
            cmdParms[48].Value = model.PneumoniaCounts;
            cmdParms[49].Value = model.DiarrheaCounts;
            cmdParms[50].Value = model.TraumaCounts;
            cmdParms[51].Value = model.SickOther;
            cmdParms[52].Value = model.GuidesOther;
            cmdParms[53].Value = model.ReferraContacts;
            cmdParms[54].Value = model.ReferralContactsTel;
            cmdParms[55].Value = model.ReferralResult;    
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public KidsWithinOneYearOldModel DataRowToModel(DataRow row)
        {
            KidsWithinOneYearOldModel kidsWithinOneYearOldModel = new KidsWithinOneYearOldModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.Name = row["Name"].ToString();
                }
                if (((row["VisitDate"] != null) && (row["VisitDate"] != DBNull.Value)) && (row["VisitDate"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.VisitDate = new DateTime?(DateTime.Parse(row["VisitDate"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if ((row["WeightAnalysis"] != null) && (row["WeightAnalysis"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.WeightAnalysis = row["WeightAnalysis"].ToString();
                }
                if (((row["Stature"] != null) && (row["Stature"] != DBNull.Value)) && (row["Stature"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.Stature = new decimal?(decimal.Parse(row["Stature"].ToString()));
                }
                if ((row["StatureAnalysis"] != null) && (row["StatureAnalysis"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.StatureAnalysis = row["StatureAnalysis"].ToString();
                }
                if (((row["HeadCircumference"] != null) && (row["HeadCircumference"] != DBNull.Value)) && (row["HeadCircumference"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.HeadCircumference = new decimal?(decimal.Parse(row["HeadCircumference"].ToString()));
                }
                if ((row["ColorFace"] != null) && (row["ColorFace"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.ColorFace = row["ColorFace"].ToString();
                }
                if ((row["Skin"] != null) && (row["Skin"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.Skin = row["Skin"].ToString();
                }
                if ((row["Bregma"] != null) && (row["Bregma"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.Bregma = row["Bregma"].ToString();
                }
                if (((row["BregmaLeft"] != null) && (row["BregmaLeft"] != DBNull.Value)) && (row["BregmaLeft"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.BregmaLeft = new decimal?(decimal.Parse(row["BregmaLeft"].ToString()));
                }
                if (((row["BregmaRight"] != null) && (row["BregmaRight"] != DBNull.Value)) && (row["BregmaRight"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.BregmaRight = new decimal?(decimal.Parse(row["BregmaRight"].ToString()));
                }
                if ((row["NeckMass"] != null) && (row["NeckMass"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.NeckMass = row["NeckMass"].ToString();
                }
                if ((row["EyeAppearance"] != null) && (row["EyeAppearance"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.EyeAppearance = row["EyeAppearance"].ToString();
                }
                if ((row["EarAppearance"] != null) && (row["EarAppearance"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.EarAppearance = row["EarAppearance"].ToString();
                }
                if ((row["Listening"] != null) && (row["Listening"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.Listening = row["Listening"].ToString();
                }
                if ((row["OralCavity"] != null) && (row["OralCavity"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.OralCavity = row["OralCavity"].ToString();
                }
                if ((row["HeartLung"] != null) && (row["HeartLung"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.HeartLung = row["HeartLung"].ToString();
                }
                if ((row["Stomach"] != null) && (row["Stomach"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.Stomach = row["Stomach"].ToString();
                }
                if ((row["UmbilicalRegion"] != null) && (row["UmbilicalRegion"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.UmbilicalRegion = row["UmbilicalRegion"].ToString();
                }
                if ((row["FourLimb"] != null) && (row["FourLimb"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.FourLimb = row["FourLimb"].ToString();
                }
                if ((row["RicketsSympotom"] != null) && (row["RicketsSympotom"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.RicketsSympotom = row["RicketsSympotom"].ToString();
                }
                if ((row["RicketsSign"] != null) && (row["RicketsSign"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.RicketsSign = row["RicketsSign"].ToString();
                }
                if ((row["AnusExternalGenita"] != null) && (row["AnusExternalGenita"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.AnusExternalGenita = row["AnusExternalGenita"].ToString();
                }
                if (((row["HemoglobinValue"] != null) && (row["HemoglobinValue"] != DBNull.Value)) && (row["HemoglobinValue"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.HemoglobinValue = new decimal?(decimal.Parse(row["HemoglobinValue"].ToString()));
                }
                if (((row["OutdoorActivities"] != null) && (row["OutdoorActivities"] != DBNull.Value)) && (row["OutdoorActivities"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.OutdoorActivities = new decimal?(decimal.Parse(row["OutdoorActivities"].ToString()));
                }
                if (((row["TakingVitaminsd"] != null) && (row["TakingVitaminsd"] != DBNull.Value)) && (row["TakingVitaminsd"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.TakingVitaminsd = new decimal?(decimal.Parse(row["TakingVitaminsd"].ToString()));
                }
                if ((row["AuxeEstimate"] != null) && (row["AuxeEstimate"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.AuxeEstimate = row["AuxeEstimate"].ToString();
                }
                if ((row["AmongTwoFollowup"] != null) && (row["AmongTwoFollowup"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.AmongTwoFollowup = row["AmongTwoFollowup"].ToString();
                }
                if ((row["Other"] != null) && (row["Other"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.Other = row["Other"].ToString();
                }
                if ((row["ReferralAdvice"] != null) && (row["ReferralAdvice"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.ReferralAdvice = row["ReferralAdvice"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["AgenciesDepartments"] != null) && (row["AgenciesDepartments"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.AgenciesDepartments = row["AgenciesDepartments"].ToString();
                }
                if ((row["Guidance"] != null) && (row["Guidance"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.Guidance = row["Guidance"].ToString();
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.NextFollowupDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["FollowUpDoctorSign"] != null) && (row["FollowUpDoctorSign"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.FollowUpDoctorSign = row["FollowUpDoctorSign"].ToString();
                }
                if ((row["Flag"] != null) && (row["Flag"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.Flag = row["Flag"].ToString();
                }
                if (((row["TeethNum"] != null) && (row["TeethNum"] != DBNull.Value)) && (row["TeethNum"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.TeethNum = new decimal?(decimal.Parse(row["TeethNum"].ToString()));
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.CreatedBy = row["CreatedBy"].ToString();
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.LastUpdateBy = row["LastUpdateBy"].ToString();
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.LastUpdateDate = DateTime.Parse(row["LastUpdateDate"].ToString());
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.IsDel = row["IsDel"].ToString();
                }
                if ((row["Chest"] != null) && (row["Chest"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.Chest = row["Chest"].ToString();
                }
                if ((row["SickNone"] != null) && (row["SickNone"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.SickNone = row["SickNone"].ToString();
                }
                if (((row["PneumoniaCounts"] != null) && (row["PneumoniaCounts"] != DBNull.Value)) && (row["PneumoniaCounts"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.PneumoniaCounts = new decimal?(decimal.Parse(row["PneumoniaCounts"].ToString()));
                }
                if (((row["DiarrheaCounts"] != null) && (row["DiarrheaCounts"] != DBNull.Value)) && (row["DiarrheaCounts"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.DiarrheaCounts = new decimal?(decimal.Parse(row["DiarrheaCounts"].ToString()));
                }
                if (((row["TraumaCounts"] != null) && (row["TraumaCounts"] != DBNull.Value)) && (row["TraumaCounts"].ToString() != ""))
                {
                    kidsWithinOneYearOldModel.TraumaCounts = new decimal?(decimal.Parse(row["TraumaCounts"].ToString()));
                }
                if ((row["SickOther"] != null) && (row["SickOther"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.SickOther = row["SickOther"].ToString();
                }
                if ((row["GuidesOther"] != null) && (row["GuidesOther"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.GuidesOther = row["GuidesOther"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.ReferralResult = row["ReferralResult"].ToString();
                }
                if ((row["ReferraContacts"] != null) && (row["ReferraContacts"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.ReferraContacts = row["ReferraContacts"].ToString();
                }
                if ((row["ReferralContactsTel"] != null) && (row["ReferralContactsTel"] != DBNull.Value))
                {
                    kidsWithinOneYearOldModel.ReferralContactsTel = row["ReferralContactsTel"].ToString();
                }
            }
            return kidsWithinOneYearOldModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CHILD_WITHIN_ONE_YEAR_OLD ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CHILD_WITHIN_ONE_YEAR_OLD ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CHILD_WITHIN_ONE_YEAR_OLD");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,Name,VisitDate,Weight,WeightAnalysis,Stature,StatureAnalysis,HeadCircumference,ColorFace,Skin,Bregma,BregmaLeft,BregmaRight,NeckMass,EyeAppearance,EarAppearance,Listening,OralCavity,HeartLung,Stomach,UmbilicalRegion,FourLimb,RicketsSympotom,RicketsSign,AnusExternalGenita,HemoglobinValue,OutdoorActivities,TakingVitaminsd,AuxeEstimate,AmongTwoFollowup,Other,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,NextFollowUpDate,FollowUpDoctorSign,Flag,TeethNum,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel, ");
            builder.Append("Chest,SickNone,PneumoniaCounts,DiarrheaCounts,TraumaCounts,SickOther,GuidesOther,ReferraContacts,ReferralContactsTel,ReferralResult ");
            builder.Append(" FROM CHILD_WITHIN_ONE_YEAR_OLD ");
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
            builder.Append(")AS Row, T.*  from CHILD_WITHIN_ONE_YEAR_OLD T ");
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
            return MySQLHelper.GetMaxID("ID", "CHILD_WITHIN_ONE_YEAR_OLD");
        }

        public KidsWithinOneYearOldModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Name,VisitDate,Weight,WeightAnalysis,Stature,StatureAnalysis,HeadCircumference,ColorFace,Skin,Bregma,BregmaLeft,BregmaRight,NeckMass,EyeAppearance,EarAppearance,Listening,OralCavity,HeartLung,Stomach,UmbilicalRegion,FourLimb,RicketsSympotom,RicketsSign,AnusExternalGenita,HemoglobinValue,OutdoorActivities,TakingVitaminsd,AuxeEstimate,AmongTwoFollowup,Other,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,NextFollowUpDate,FollowUpDoctorSign,Flag,TeethNum,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel, ");
            builder.Append("Chest,SickNone,PneumoniaCounts,DiarrheaCounts,TraumaCounts,SickOther,GuidesOther,ReferraContacts,ReferralContactsTel,ReferralResult ");
            builder.Append(" FROM CHILD_WITHIN_ONE_YEAR_OLD ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new KidsWithinOneYearOldModel();
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
            builder.Append("select count(1) FROM CHILD_WITHIN_ONE_YEAR_OLD ");
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

        public bool Update(KidsWithinOneYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CHILD_WITHIN_ONE_YEAR_OLD set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Name=@Name,");
            builder.Append("VisitDate=@VisitDate,");
            builder.Append("Weight=@Weight,");
            builder.Append("WeightAnalysis=@WeightAnalysis,");
            builder.Append("Stature=@Stature,");
            builder.Append("StatureAnalysis=@StatureAnalysis,");
            builder.Append("HeadCircumference=@HeadCircumference,");
            builder.Append("ColorFace=@ColorFace,");
            builder.Append("Skin=@Skin,");
            builder.Append("Bregma=@Bregma,");
            builder.Append("BregmaLeft=@BregmaLeft,");
            builder.Append("BregmaRight=@BregmaRight,");
            builder.Append("NeckMass=@NeckMass,");
            builder.Append("EyeAppearance=@EyeAppearance,");
            builder.Append("EarAppearance=@EarAppearance,");
            builder.Append("Listening=@Listening,");
            builder.Append("OralCavity=@OralCavity,");
            builder.Append("HeartLung=@HeartLung,");
            builder.Append("Stomach=@Stomach,");
            builder.Append("UmbilicalRegion=@UmbilicalRegion,");
            builder.Append("FourLimb=@FourLimb,");
            builder.Append("RicketsSympotom=@RicketsSympotom,");
            builder.Append("RicketsSign=@RicketsSign,");
            builder.Append("AnusExternalGenita=@AnusExternalGenita,");
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
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctorSign=@FollowUpDoctorSign,");
            builder.Append("Flag=@Flag,");
            builder.Append("TeethNum=@TeethNum,");
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
            builder.Append("GuidesOther=@GuidesOther,");
            builder.Append("ReferraContacts=@ReferraContacts, ");
            builder.Append("ReferralContactsTel=@ReferralContactsTel, ");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30),
                new MySqlParameter("@VisitDate", MySqlDbType.Date), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@Stature", MySqlDbType.Decimal),
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1), 
                new MySqlParameter("@HeadCircumference", MySqlDbType.Decimal), 
                new MySqlParameter("@ColorFace", MySqlDbType.String, 1), 
                new MySqlParameter("@Skin", MySqlDbType.String, 1),
                new MySqlParameter("@Bregma", MySqlDbType.String, 1), 
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal), 
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal),
                new MySqlParameter("@NeckMass", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@Listening", MySqlDbType.String, 1), 
                new MySqlParameter("@OralCavity", MySqlDbType.String, 1), 
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1),
                new MySqlParameter("@UmbilicalRegion", MySqlDbType.String, 1),
                new MySqlParameter("@FourLimb", MySqlDbType.String, 1), 
                new MySqlParameter("@RicketsSympotom", MySqlDbType.String, 1),
                new MySqlParameter("@RicketsSign", MySqlDbType.String, 1), 
                new MySqlParameter("@AnusExternalGenita", MySqlDbType.String, 1),
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
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30),
                new MySqlParameter("@Flag", MySqlDbType.String, 1),
                new MySqlParameter("@TeethNum", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedBy", MySqlDbType.String), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@SickNone", MySqlDbType.String, 10),
                new MySqlParameter("@PneumoniaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@DiarrheaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@TraumaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@SickOther", MySqlDbType.String, 100),
                new MySqlParameter("@GuidesOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.HeadCircumference;
            cmdParms[10].Value = model.ColorFace;
            cmdParms[11].Value = model.Skin;
            cmdParms[12].Value = model.Bregma;
            cmdParms[13].Value = model.BregmaLeft;
            cmdParms[14].Value = model.BregmaRight;
            cmdParms[15].Value = model.NeckMass;
            cmdParms[16].Value = model.EyeAppearance;
            cmdParms[17].Value = model.EarAppearance;
            cmdParms[18].Value = model.Listening;
            cmdParms[19].Value = model.OralCavity;
            cmdParms[20].Value = model.HeartLung;
            cmdParms[21].Value = model.Stomach;
            cmdParms[22].Value = model.UmbilicalRegion;
            cmdParms[23].Value = model.FourLimb;
            cmdParms[24].Value = model.RicketsSympotom;
            cmdParms[25].Value = model.RicketsSign;
            cmdParms[26].Value = model.AnusExternalGenita;
            cmdParms[27].Value = model.HemoglobinValue;
            cmdParms[28].Value = model.OutdoorActivities;
            cmdParms[29].Value = model.TakingVitaminsd;
            cmdParms[30].Value = model.AuxeEstimate;
            cmdParms[31].Value = model.AmongTwoFollowup;
            cmdParms[32].Value = model.Other;
            cmdParms[33].Value = model.ReferralAdvice;
            cmdParms[34].Value = model.ReferralReason;
            cmdParms[35].Value = model.AgenciesDepartments;
            cmdParms[36].Value = model.Guidance;
            cmdParms[37].Value = model.NextFollowupDate;
            cmdParms[38].Value = model.FollowUpDoctorSign;
            cmdParms[39].Value = model.Flag;
            cmdParms[40].Value = model.TeethNum;
            cmdParms[41].Value = model.CreatedBy;
            cmdParms[42].Value = model.CreatedDate;
            cmdParms[43].Value = model.LastUpdateBy;
            cmdParms[44].Value = model.LastUpdateDate;
            cmdParms[45].Value = model.IsDel;
            cmdParms[46].Value = model.Chest;
            cmdParms[47].Value = model.SickNone;
            cmdParms[48].Value = model.PneumoniaCounts;
            cmdParms[49].Value = model.DiarrheaCounts;
            cmdParms[50].Value = model.TraumaCounts;
            cmdParms[51].Value = model.SickOther;
            cmdParms[52].Value = model.GuidesOther;
            cmdParms[53].Value = model.ReferraContacts;
            cmdParms[54].Value = model.ReferralContactsTel;
            cmdParms[55].Value = model.ReferralResult; 
            cmdParms[56].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(KidsWithinOneYearOldModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CHILD_WITHIN_ONE_YEAR_OLD set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Name=@Name,");
            builder.Append("VisitDate=@VisitDate,");
            builder.Append("Weight=@Weight,");
            builder.Append("WeightAnalysis=@WeightAnalysis,");
            builder.Append("Stature=@Stature,");
            builder.Append("StatureAnalysis=@StatureAnalysis,");
            builder.Append("HeadCircumference=@HeadCircumference,");
            builder.Append("ColorFace=@ColorFace,");
            builder.Append("Skin=@Skin,");
            builder.Append("Bregma=@Bregma,");
            builder.Append("BregmaLeft=@BregmaLeft,");
            builder.Append("BregmaRight=@BregmaRight,");
            builder.Append("NeckMass=@NeckMass,");
            builder.Append("EyeAppearance=@EyeAppearance,");
            builder.Append("EarAppearance=@EarAppearance,");
            builder.Append("Listening=@Listening,");
            builder.Append("OralCavity=@OralCavity,");
            builder.Append("HeartLung=@HeartLung,");
            builder.Append("Stomach=@Stomach,");
            builder.Append("UmbilicalRegion=@UmbilicalRegion,");
            builder.Append("FourLimb=@FourLimb,");
            builder.Append("RicketsSympotom=@RicketsSympotom,");
            builder.Append("RicketsSign=@RicketsSign,");
            builder.Append("AnusExternalGenita=@AnusExternalGenita,");
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
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctorSign=@FollowUpDoctorSign,");
            builder.Append("Flag=@Flag,");
            builder.Append("TeethNum=@TeethNum,");
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
            builder.Append("GuidesOther=@GuidesOther,");
            builder.Append("ReferraContacts=@ReferraContacts, ");
            builder.Append("ReferralContactsTel=@ReferralContactsTel, ");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30),
                new MySqlParameter("@VisitDate", MySqlDbType.Date), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal), 
                new MySqlParameter("@WeightAnalysis", MySqlDbType.String, 1),
                new MySqlParameter("@Stature", MySqlDbType.Decimal),
                new MySqlParameter("@StatureAnalysis", MySqlDbType.String, 1), 
                new MySqlParameter("@HeadCircumference", MySqlDbType.Decimal), 
                new MySqlParameter("@ColorFace", MySqlDbType.String, 1), 
                new MySqlParameter("@Skin", MySqlDbType.String, 1),
                new MySqlParameter("@Bregma", MySqlDbType.String, 1), 
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal), 
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal),
                new MySqlParameter("@NeckMass", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@Listening", MySqlDbType.String, 1), 
                new MySqlParameter("@OralCavity", MySqlDbType.String, 1), 
                new MySqlParameter("@HeartLung", MySqlDbType.String, 1), 
                new MySqlParameter("@Stomach", MySqlDbType.String, 1),
                new MySqlParameter("@UmbilicalRegion", MySqlDbType.String, 1),
                new MySqlParameter("@FourLimb", MySqlDbType.String, 1), 
                new MySqlParameter("@RicketsSympotom", MySqlDbType.String, 1),
                new MySqlParameter("@RicketsSign", MySqlDbType.String, 1), 
                new MySqlParameter("@AnusExternalGenita", MySqlDbType.String, 1),
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
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30),
                new MySqlParameter("@Flag", MySqlDbType.String, 1),
                new MySqlParameter("@TeethNum", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedBy", MySqlDbType.String), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@SickNone", MySqlDbType.String, 10),
                new MySqlParameter("@PneumoniaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@DiarrheaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@TraumaCounts", MySqlDbType.Decimal),
                new MySqlParameter("@SickOther", MySqlDbType.String, 100),
                new MySqlParameter("@GuidesOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1)
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.Weight;
            cmdParms[6].Value = model.WeightAnalysis;
            cmdParms[7].Value = model.Stature;
            cmdParms[8].Value = model.StatureAnalysis;
            cmdParms[9].Value = model.HeadCircumference;
            cmdParms[10].Value = model.ColorFace;
            cmdParms[11].Value = model.Skin;
            cmdParms[12].Value = model.Bregma;
            cmdParms[13].Value = model.BregmaLeft;
            cmdParms[14].Value = model.BregmaRight;
            cmdParms[15].Value = model.NeckMass;
            cmdParms[16].Value = model.EyeAppearance;
            cmdParms[17].Value = model.EarAppearance;
            cmdParms[18].Value = model.Listening;
            cmdParms[19].Value = model.OralCavity;
            cmdParms[20].Value = model.HeartLung;
            cmdParms[21].Value = model.Stomach;
            cmdParms[22].Value = model.UmbilicalRegion;
            cmdParms[23].Value = model.FourLimb;
            cmdParms[24].Value = model.RicketsSympotom;
            cmdParms[25].Value = model.RicketsSign;
            cmdParms[26].Value = model.AnusExternalGenita;
            cmdParms[27].Value = model.HemoglobinValue;
            cmdParms[28].Value = model.OutdoorActivities;
            cmdParms[29].Value = model.TakingVitaminsd;
            cmdParms[30].Value = model.AuxeEstimate;
            cmdParms[31].Value = model.AmongTwoFollowup;
            cmdParms[32].Value = model.Other;
            cmdParms[33].Value = model.ReferralAdvice;
            cmdParms[34].Value = model.ReferralReason;
            cmdParms[35].Value = model.AgenciesDepartments;
            cmdParms[36].Value = model.Guidance;
            cmdParms[37].Value = model.NextFollowupDate;
            cmdParms[38].Value = model.FollowUpDoctorSign;
            cmdParms[39].Value = model.Flag;
            cmdParms[40].Value = model.TeethNum;
            cmdParms[41].Value = model.CreatedBy;
            cmdParms[42].Value = model.CreatedDate;
            cmdParms[43].Value = model.LastUpdateBy;
            cmdParms[44].Value = model.LastUpdateDate;
            cmdParms[45].Value = model.IsDel;
            cmdParms[46].Value = model.Chest;
            cmdParms[47].Value = model.SickNone;
            cmdParms[48].Value = model.PneumoniaCounts;
            cmdParms[49].Value = model.DiarrheaCounts;
            cmdParms[50].Value = model.TraumaCounts;
            cmdParms[51].Value = model.SickOther;
            cmdParms[52].Value = model.GuidesOther;
            cmdParms[53].Value = model.ReferraContacts;
            cmdParms[54].Value = model.ReferralContactsTel;
            cmdParms[55].Value = model.ReferralResult; 
           // cmdParms[46].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

