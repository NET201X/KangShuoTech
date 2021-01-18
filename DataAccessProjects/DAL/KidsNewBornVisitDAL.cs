namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class KidsNewBornVisitDAL
    {
        public int Add(KidsNewBornVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CHILD_NEWBORN_FOLLOWUP(");
            builder.Append("CustomerID,RecordID,IDCardNo,Sex,Birthday,HomeAddr,FatherName,FatherJob,FatherTel,FatherBirthday,MotherName,MotherJob,MotherTel,MotherBirthday,GestationalWeek,PregnancPreva,PregnancPrevaOther,MidwifOrganizaName,BirthInforma,BirthInformaOther,Aasphyxia,Apgar,WhetherAbnorma,WhetherAbnormaHave,HearingScreen,DiseaseScreen,DiseaseScreenOther,BirthWeight,PresentWeight,BirthStature,FeedingPattern,NursingQuantity,InfantFrequen,Vomit,Stool,StoolFrequen,Temperature,PulseRate,BreathingRate,ColourFace,ColourFaceOther,Jaundice,BregmaLeft,BregmaRight,Bregma,BregmaOther,EyeAppearance,EyeAppearanceEx,LimbsActivity,LimbsActivityEx,EarAppearance,EarAppearanceEx,NeckMass,NeckMassHave,Nose,NoseEx,Skin,SkinOther,MouthCavity,MouthCavityEx,Anus,AnusEx,HeartLungAuscul,HeartLungAusculEx,Aedea,AedeaEx,AbdominalTouch,AbdominalTouchEx,Spine,SpineEx,UmbilicalCord,UmbilicalCordOther,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,InterviewDate,NextFollowupPlace,NextFollowUpDate,FollowUpDoctorSign,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,Apgar1,Apgar5,");
            builder.Append("FatherID,MotherID,Chest,ChestEx,GuidanceOther,ReferralOrgan,ReferraContacts,ReferralContactsTel,ReferralResult) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Sex,@Birthday,@HomeAddr,@FatherName,@FatherJob,@FatherTel,@FatherBirthday,@MotherName,@MotherJob,@MotherTel,@MotherBirthday,@GestationalWeek,@PregnancPreva,@PregnancPrevaOther,@MidwifOrganizaName,@BirthInforma,@BirthInformaOther,@Aasphyxia,@Apgar,@WhetherAbnorma,@WhetherAbnormaHave,@HearingScreen,@DiseaseScreen,@DiseaseScreenOther,@BirthWeight,@PresentWeight,@BirthStature,@FeedingPattern,@NursingQuantity,@InfantFrequen,@Vomit,@Stool,@StoolFrequen,@Temperature,@PulseRate,@BreathingRate,@ColourFace,@ColourFaceOther,@Jaundice,@BregmaLeft,@BregmaRight,@Bregma,@BregmaOther,@EyeAppearance,@EyeAppearanceEx,@LimbsActivity,@LimbsActivityEx,@EarAppearance,@EarAppearanceEx,@NeckMass,@NeckMassHave,@Nose,@NoseEx,@Skin,@SkinOther,@MouthCavity,@MouthCavityEx,@Anus,@AnusEx,@HeartLungAuscul,@HeartLungAusculEx,@Aedea,@AedeaEx,@AbdominalTouch,@AbdominalTouchEx,@Spine,@SpineEx,@UmbilicalCord,@UmbilicalCordOther,@ReferralAdvice,@ReferralReason,@AgenciesDepartments,@Guidance,@InterviewDate,@NextFollowupPlace,@NextFollowUpDate,@FollowUpDoctorSign,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@Apgar1,@Apgar5,");
            builder.Append("@FatherID,@MotherID,@Chest,@ChestEx,@GuidanceOther,@ReferralOrgan,@ReferraContacts,@ReferralContactsTel,@ReferralResult) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Sex", MySqlDbType.String, 1),
                new MySqlParameter("@Birthday", MySqlDbType.Date),
                new MySqlParameter("@HomeAddr", MySqlDbType.String, 200),
                new MySqlParameter("@FatherName", MySqlDbType.String, 30),
                new MySqlParameter("@FatherJob", MySqlDbType.String, 50),
                new MySqlParameter("@FatherTel", MySqlDbType.String, 15),
                new MySqlParameter("@FatherBirthday", MySqlDbType.Date), 
                new MySqlParameter("@MotherName", MySqlDbType.String, 30),
                new MySqlParameter("@MotherJob", MySqlDbType.String, 50),
                new MySqlParameter("@MotherTel", MySqlDbType.String, 15),
                new MySqlParameter("@MotherBirthday", MySqlDbType.Date), 
                new MySqlParameter("@GestationalWeek", MySqlDbType.Decimal), 
                new MySqlParameter("@PregnancPreva", MySqlDbType.String, 1), 
                new MySqlParameter("@PregnancPrevaOther", MySqlDbType.String, 100),
                new MySqlParameter("@MidwifOrganizaName", MySqlDbType.String, 50),
                new MySqlParameter("@BirthInforma", MySqlDbType.String, 30),
                new MySqlParameter("@BirthInformaOther", MySqlDbType.String, 100), 
                new MySqlParameter("@Aasphyxia", MySqlDbType.String, 1), 
                new MySqlParameter("@Apgar", MySqlDbType.String, 100), 
                new MySqlParameter("@WhetherAbnorma", MySqlDbType.String, 1),
                new MySqlParameter("@WhetherAbnormaHave", MySqlDbType.String, 100),
                new MySqlParameter("@HearingScreen", MySqlDbType.String, 1),
                new MySqlParameter("@DiseaseScreen", MySqlDbType.String, 100),
                new MySqlParameter("@DiseaseScreenOther", MySqlDbType.String, 100),
                new MySqlParameter("@BirthWeight", MySqlDbType.Decimal),
                new MySqlParameter("@PresentWeight", MySqlDbType.Decimal),
                new MySqlParameter("@BirthStature", MySqlDbType.Decimal), 
                new MySqlParameter("@FeedingPattern", MySqlDbType.String, 1), 
                new MySqlParameter("@NursingQuantity", MySqlDbType.Decimal), 
                new MySqlParameter("@InfantFrequen", MySqlDbType.Decimal), 
                new MySqlParameter("@Vomit", MySqlDbType.String, 1), 
                new MySqlParameter("@Stool", MySqlDbType.String, 1),
                new MySqlParameter("@StoolFrequen", MySqlDbType.Decimal),
                new MySqlParameter("@Temperature", MySqlDbType.Decimal),
                new MySqlParameter("@PulseRate", MySqlDbType.Decimal), 
                new MySqlParameter("@BreathingRate", MySqlDbType.Decimal),
                new MySqlParameter("@ColourFace", MySqlDbType.String, 100), 
                new MySqlParameter("@ColourFaceOther", MySqlDbType.String, 100),
                new MySqlParameter("@Jaundice", MySqlDbType.String, 1),
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal),
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal), 
                new MySqlParameter("@Bregma", MySqlDbType.String, 1),
                new MySqlParameter("@BregmaOther", MySqlDbType.String, 100),
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@EyeAppearanceEx", MySqlDbType.String, 100), 
                new MySqlParameter("@LimbsActivity", MySqlDbType.String, 1), 
                new MySqlParameter("@LimbsActivityEx", MySqlDbType.String, 100),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@EarAppearanceEx", MySqlDbType.String, 100), 
                new MySqlParameter("@NeckMass", MySqlDbType.String, 1), 
                new MySqlParameter("@NeckMassHave", MySqlDbType.String, 100),
                new MySqlParameter("@Nose", MySqlDbType.String, 1), 
                new MySqlParameter("@NoseEx", MySqlDbType.String, 100), 
                new MySqlParameter("@Skin", MySqlDbType.String, 100), 
                new MySqlParameter("@SkinOther", MySqlDbType.String, 100),
                new MySqlParameter("@MouthCavity", MySqlDbType.String, 1), 
                new MySqlParameter("@MouthCavityEx", MySqlDbType.String, 100), 
                new MySqlParameter("@Anus", MySqlDbType.String, 1), 
                new MySqlParameter("@AnusEx", MySqlDbType.String, 100),
                new MySqlParameter("@HeartLungAuscul", MySqlDbType.String, 1), 
                new MySqlParameter("@HeartLungAusculEx", MySqlDbType.String, 100), 
                new MySqlParameter("@Aedea", MySqlDbType.String, 1), 
                new MySqlParameter("@AedeaEx", MySqlDbType.String, 100),
                new MySqlParameter("@AbdominalTouch", MySqlDbType.String, 1),
                new MySqlParameter("@AbdominalTouchEx", MySqlDbType.String, 100),
                new MySqlParameter("@Spine", MySqlDbType.String, 1),
                new MySqlParameter("@SpineEx", MySqlDbType.String, 100),
                new MySqlParameter("@UmbilicalCord", MySqlDbType.String, 1),
                new MySqlParameter("@UmbilicalCordOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80), 
                new MySqlParameter("@Guidance", MySqlDbType.String, 20),
                new MySqlParameter("@InterviewDate", MySqlDbType.Date), 
                new MySqlParameter("@NextFollowupPlace", MySqlDbType.String, 100),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30), 
                new MySqlParameter("@CreatedBy", MySqlDbType.String),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Apgar1", MySqlDbType.Decimal),
                new MySqlParameter("@Apgar5", MySqlDbType.Decimal),
                new MySqlParameter("@FatherID", MySqlDbType.String, 21),
                new MySqlParameter("@MotherID", MySqlDbType.String, 21),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@ChestEx", MySqlDbType.String, 100),
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralOrgan",MySqlDbType.String,100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Sex;
            cmdParms[4].Value = model.Birthday;
            cmdParms[5].Value = model.HomeAddr;
            cmdParms[6].Value = model.FatherName;
            cmdParms[7].Value = model.FatherJob;
            cmdParms[8].Value = model.FatherTel;
            cmdParms[9].Value = model.FatherBirthday;
            cmdParms[10].Value = model.MotherName;
            cmdParms[11].Value = model.MotherJob;
            cmdParms[12].Value = model.MotherTel;
            cmdParms[13].Value = model.MotherBirthday;
            cmdParms[14].Value = model.GestationalWeek;
            cmdParms[15].Value = model.PregnancPreva;
            cmdParms[16].Value = model.PregnancPrevaOther;
            cmdParms[17].Value = model.MidwifOrganizaName;
            cmdParms[18].Value = model.BirthInforma;
            cmdParms[19].Value = model.BirthInformaOther;
            cmdParms[20].Value = model.Aasphyxia;
            cmdParms[21].Value = model.Apgar;
            cmdParms[22].Value = model.WhetherAbnorma;
            cmdParms[23].Value = model.WhetherAbnormaHave;
            cmdParms[24].Value = model.HearingScreen;
            cmdParms[25].Value = model.DiseaseScreen;
            cmdParms[26].Value = model.DiseaseScreenOther;
            cmdParms[27].Value = model.BirthWeight;
            cmdParms[28].Value = model.PresentWeight;
            cmdParms[29].Value = model.BirthStature;
            cmdParms[30].Value = model.FeedingPattern;
            cmdParms[31].Value = model.NursingQuantity;
            cmdParms[32].Value = model.InfantFrequen;
            cmdParms[33].Value = model.Vomit;
            cmdParms[34].Value = model.Stool;
            cmdParms[35].Value = model.StoolFrequen;
            cmdParms[36].Value = model.Temperature;
            cmdParms[37].Value = model.PulseRate;
            cmdParms[38].Value = model.BreathingRate;
            cmdParms[39].Value = model.ColourFace;
            cmdParms[40].Value = model.ColourFaceOther;
            cmdParms[41].Value = model.Jaundice;
            cmdParms[42].Value = model.BregmaLeft;
            cmdParms[43].Value = model.BregmaRight;
            cmdParms[44].Value = model.Bregma;
            cmdParms[45].Value = model.BregmaOther;
            cmdParms[46].Value = model.EyeAppearance;
            cmdParms[47].Value = model.EyeAppearanceEx;
            cmdParms[48].Value = model.LimbsActivity;
            cmdParms[49].Value = model.LimbsActivityEx;
            cmdParms[50].Value = model.EarAppearance;
            cmdParms[51].Value = model.EarAppearanceEx;
            cmdParms[52].Value = model.NeckMass;
            cmdParms[53].Value = model.NeckMassHave;
            cmdParms[54].Value = model.Nose;
            cmdParms[55].Value = model.NoseEx;
            cmdParms[56].Value = model.Skin;
            cmdParms[57].Value = model.SkinOther;
            cmdParms[58].Value = model.MouthCavity;
            cmdParms[59].Value = model.MouthCavityEx;
            cmdParms[60].Value = model.Anus;
            cmdParms[61].Value = model.AnusEx;
            cmdParms[62].Value = model.HeartLungAuscul;
            cmdParms[63].Value = model.HeartLungAusculEx;
            cmdParms[64].Value = model.Aedea;
            cmdParms[65].Value = model.AedeaEx;
            cmdParms[66].Value = model.AbdominalTouch;
            cmdParms[67].Value = model.AbdominalTouchEx;
            cmdParms[68].Value = model.Spine;
            cmdParms[69].Value = model.SpineEx;
            cmdParms[70].Value = model.UmbilicalCord;
            cmdParms[71].Value = model.UmbilicalCordOther;
            cmdParms[72].Value = model.ReferralAdvice;
            cmdParms[73].Value = model.ReferralReason;
            cmdParms[74].Value = model.AgenciesDepartments;
            cmdParms[75].Value = model.Guidance;
            cmdParms[76].Value = model.InterviewDate;
            cmdParms[77].Value = model.NextFollowupPlace;
            cmdParms[78].Value = model.NextFollowupDate;
            cmdParms[79].Value = model.FollowUpDoctorSign;
            cmdParms[80].Value = model.CreatedBy;
            cmdParms[81].Value = model.CreatedDate;
            cmdParms[82].Value = model.LastUpdateBy;
            cmdParms[83].Value = model.LastUpdateDate;
            cmdParms[84].Value = model.IsDel;
            cmdParms[85].Value = model.Apgar1;
            cmdParms[86].Value = model.Apgar5;
            cmdParms[87].Value = model.FatherID;           
            cmdParms[88].Value = model.MotherID;           
            cmdParms[89].Value = model.Chest;              
            cmdParms[90].Value = model.ChestEx;            
            cmdParms[91].Value = model.GuidanceOther;      
            cmdParms[92].Value = model.ReferralOrgan;      
            cmdParms[93].Value = model.ReferraContacts;    
            cmdParms[94].Value = model.ReferralContactsTel;
            cmdParms[95].Value = model.ReferralResult;     
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(KidsNewBornVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CHILD_NEWBORN_FOLLOWUP(");
            builder.Append("CustomerID,RecordID,IDCardNo,Sex,Birthday,HomeAddr,FatherName,FatherJob,FatherTel,FatherBirthday,MotherName,MotherJob,MotherTel,MotherBirthday,GestationalWeek,PregnancPreva,PregnancPrevaOther,MidwifOrganizaName,BirthInforma,BirthInformaOther,Aasphyxia,Apgar,WhetherAbnorma,WhetherAbnormaHave,HearingScreen,DiseaseScreen,DiseaseScreenOther,BirthWeight,PresentWeight,BirthStature,FeedingPattern,NursingQuantity,InfantFrequen,Vomit,Stool,StoolFrequen,Temperature,PulseRate,BreathingRate,ColourFace,ColourFaceOther,Jaundice,BregmaLeft,BregmaRight,Bregma,BregmaOther,EyeAppearance,EyeAppearanceEx,LimbsActivity,LimbsActivityEx,EarAppearance,EarAppearanceEx,NeckMass,NeckMassHave,Nose,NoseEx,Skin,SkinOther,MouthCavity,MouthCavityEx,Anus,AnusEx,HeartLungAuscul,HeartLungAusculEx,Aedea,AedeaEx,AbdominalTouch,AbdominalTouchEx,Spine,SpineEx,UmbilicalCord,UmbilicalCordOther,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,InterviewDate,NextFollowupPlace,NextFollowUpDate,FollowUpDoctorSign,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,Apgar1,Apgar5,");
            builder.Append("FatherID,MotherID,Chest,ChestEx,GuidanceOther,ReferralOrgan,ReferraContacts,ReferralContactsTel,ReferralResult) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Sex,@Birthday,@HomeAddr,@FatherName,@FatherJob,@FatherTel,@FatherBirthday,@MotherName,@MotherJob,@MotherTel,@MotherBirthday,@GestationalWeek,@PregnancPreva,@PregnancPrevaOther,@MidwifOrganizaName,@BirthInforma,@BirthInformaOther,@Aasphyxia,@Apgar,@WhetherAbnorma,@WhetherAbnormaHave,@HearingScreen,@DiseaseScreen,@DiseaseScreenOther,@BirthWeight,@PresentWeight,@BirthStature,@FeedingPattern,@NursingQuantity,@InfantFrequen,@Vomit,@Stool,@StoolFrequen,@Temperature,@PulseRate,@BreathingRate,@ColourFace,@ColourFaceOther,@Jaundice,@BregmaLeft,@BregmaRight,@Bregma,@BregmaOther,@EyeAppearance,@EyeAppearanceEx,@LimbsActivity,@LimbsActivityEx,@EarAppearance,@EarAppearanceEx,@NeckMass,@NeckMassHave,@Nose,@NoseEx,@Skin,@SkinOther,@MouthCavity,@MouthCavityEx,@Anus,@AnusEx,@HeartLungAuscul,@HeartLungAusculEx,@Aedea,@AedeaEx,@AbdominalTouch,@AbdominalTouchEx,@Spine,@SpineEx,@UmbilicalCord,@UmbilicalCordOther,@ReferralAdvice,@ReferralReason,@AgenciesDepartments,@Guidance,@InterviewDate,@NextFollowupPlace,@NextFollowUpDate,@FollowUpDoctorSign,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@Apgar1,@Apgar5,");
            builder.Append("@FatherID,@MotherID,@Chest,@ChestEx,@GuidanceOther,@ReferralOrgan,@ReferraContacts,@ReferralContactsTel,@ReferralResult) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Sex", MySqlDbType.String, 1),
                new MySqlParameter("@Birthday", MySqlDbType.Date),
                new MySqlParameter("@HomeAddr", MySqlDbType.String, 200),
                new MySqlParameter("@FatherName", MySqlDbType.String, 30),
                new MySqlParameter("@FatherJob", MySqlDbType.String, 50),
                new MySqlParameter("@FatherTel", MySqlDbType.String, 15),
                new MySqlParameter("@FatherBirthday", MySqlDbType.Date), 
                new MySqlParameter("@MotherName", MySqlDbType.String, 30),
                new MySqlParameter("@MotherJob", MySqlDbType.String, 50),
                new MySqlParameter("@MotherTel", MySqlDbType.String, 15),
                new MySqlParameter("@MotherBirthday", MySqlDbType.Date), 
                new MySqlParameter("@GestationalWeek", MySqlDbType.Decimal), 
                new MySqlParameter("@PregnancPreva", MySqlDbType.String, 1), 
                new MySqlParameter("@PregnancPrevaOther", MySqlDbType.String, 100),
                new MySqlParameter("@MidwifOrganizaName", MySqlDbType.String, 50),
                new MySqlParameter("@BirthInforma", MySqlDbType.String, 30),
                new MySqlParameter("@BirthInformaOther", MySqlDbType.String, 100), 
                new MySqlParameter("@Aasphyxia", MySqlDbType.String, 1), 
                new MySqlParameter("@Apgar", MySqlDbType.String, 100), 
                new MySqlParameter("@WhetherAbnorma", MySqlDbType.String, 1),
                new MySqlParameter("@WhetherAbnormaHave", MySqlDbType.String, 100),
                new MySqlParameter("@HearingScreen", MySqlDbType.String, 1),
                new MySqlParameter("@DiseaseScreen", MySqlDbType.String, 100),
                new MySqlParameter("@DiseaseScreenOther", MySqlDbType.String, 100),
                new MySqlParameter("@BirthWeight", MySqlDbType.Decimal),
                new MySqlParameter("@PresentWeight", MySqlDbType.Decimal),
                new MySqlParameter("@BirthStature", MySqlDbType.Decimal), 
                new MySqlParameter("@FeedingPattern", MySqlDbType.String, 1), 
                new MySqlParameter("@NursingQuantity", MySqlDbType.Decimal), 
                new MySqlParameter("@InfantFrequen", MySqlDbType.Decimal), 
                new MySqlParameter("@Vomit", MySqlDbType.String, 1), 
                new MySqlParameter("@Stool", MySqlDbType.String, 1),
                new MySqlParameter("@StoolFrequen", MySqlDbType.Decimal),
                new MySqlParameter("@Temperature", MySqlDbType.Decimal),
                new MySqlParameter("@PulseRate", MySqlDbType.Decimal), 
                new MySqlParameter("@BreathingRate", MySqlDbType.Decimal),
                new MySqlParameter("@ColourFace", MySqlDbType.String, 100), 
                new MySqlParameter("@ColourFaceOther", MySqlDbType.String, 100),
                new MySqlParameter("@Jaundice", MySqlDbType.String, 1),
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal),
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal), 
                new MySqlParameter("@Bregma", MySqlDbType.String, 1),
                new MySqlParameter("@BregmaOther", MySqlDbType.String, 100),
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1),
                new MySqlParameter("@EyeAppearanceEx", MySqlDbType.String, 100), 
                new MySqlParameter("@LimbsActivity", MySqlDbType.String, 1), 
                new MySqlParameter("@LimbsActivityEx", MySqlDbType.String, 100),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@EarAppearanceEx", MySqlDbType.String, 100), 
                new MySqlParameter("@NeckMass", MySqlDbType.String, 1), 
                new MySqlParameter("@NeckMassHave", MySqlDbType.String, 100),
                new MySqlParameter("@Nose", MySqlDbType.String, 1), 
                new MySqlParameter("@NoseEx", MySqlDbType.String, 100), 
                new MySqlParameter("@Skin", MySqlDbType.String, 100), 
                new MySqlParameter("@SkinOther", MySqlDbType.String, 100),
                new MySqlParameter("@MouthCavity", MySqlDbType.String, 1), 
                new MySqlParameter("@MouthCavityEx", MySqlDbType.String, 100), 
                new MySqlParameter("@Anus", MySqlDbType.String, 1), 
                new MySqlParameter("@AnusEx", MySqlDbType.String, 100),
                new MySqlParameter("@HeartLungAuscul", MySqlDbType.String, 1), 
                new MySqlParameter("@HeartLungAusculEx", MySqlDbType.String, 100), 
                new MySqlParameter("@Aedea", MySqlDbType.String, 1), 
                new MySqlParameter("@AedeaEx", MySqlDbType.String, 100),
                new MySqlParameter("@AbdominalTouch", MySqlDbType.String, 1),
                new MySqlParameter("@AbdominalTouchEx", MySqlDbType.String, 100),
                new MySqlParameter("@Spine", MySqlDbType.String, 1),
                new MySqlParameter("@SpineEx", MySqlDbType.String, 100),
                new MySqlParameter("@UmbilicalCord", MySqlDbType.String, 1),
                new MySqlParameter("@UmbilicalCordOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80), 
                new MySqlParameter("@Guidance", MySqlDbType.String, 20),
                new MySqlParameter("@InterviewDate", MySqlDbType.Date), 
                new MySqlParameter("@NextFollowupPlace", MySqlDbType.String, 100),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30), 
                new MySqlParameter("@CreatedBy", MySqlDbType.String),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Apgar1", MySqlDbType.Decimal),
                new MySqlParameter("@Apgar5", MySqlDbType.Decimal),
                new MySqlParameter("@FatherID", MySqlDbType.String, 21),
                new MySqlParameter("@MotherID", MySqlDbType.String, 21),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@ChestEx", MySqlDbType.String, 100),
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralOrgan",MySqlDbType.String,100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Sex;
            cmdParms[4].Value = model.Birthday;
            cmdParms[5].Value = model.HomeAddr;
            cmdParms[6].Value = model.FatherName;
            cmdParms[7].Value = model.FatherJob;
            cmdParms[8].Value = model.FatherTel;
            cmdParms[9].Value = model.FatherBirthday;
            cmdParms[10].Value = model.MotherName;
            cmdParms[11].Value = model.MotherJob;
            cmdParms[12].Value = model.MotherTel;
            cmdParms[13].Value = model.MotherBirthday;
            cmdParms[14].Value = model.GestationalWeek;
            cmdParms[15].Value = model.PregnancPreva;
            cmdParms[16].Value = model.PregnancPrevaOther;
            cmdParms[17].Value = model.MidwifOrganizaName;
            cmdParms[18].Value = model.BirthInforma;
            cmdParms[19].Value = model.BirthInformaOther;
            cmdParms[20].Value = model.Aasphyxia;
            cmdParms[21].Value = model.Apgar;
            cmdParms[22].Value = model.WhetherAbnorma;
            cmdParms[23].Value = model.WhetherAbnormaHave;
            cmdParms[24].Value = model.HearingScreen;
            cmdParms[25].Value = model.DiseaseScreen;
            cmdParms[26].Value = model.DiseaseScreenOther;
            cmdParms[27].Value = model.BirthWeight;
            cmdParms[28].Value = model.PresentWeight;
            cmdParms[29].Value = model.BirthStature;
            cmdParms[30].Value = model.FeedingPattern;
            cmdParms[31].Value = model.NursingQuantity;
            cmdParms[32].Value = model.InfantFrequen;
            cmdParms[33].Value = model.Vomit;
            cmdParms[34].Value = model.Stool;
            cmdParms[35].Value = model.StoolFrequen;
            cmdParms[36].Value = model.Temperature;
            cmdParms[37].Value = model.PulseRate;
            cmdParms[38].Value = model.BreathingRate;
            cmdParms[39].Value = model.ColourFace;
            cmdParms[40].Value = model.ColourFaceOther;
            cmdParms[41].Value = model.Jaundice;
            cmdParms[42].Value = model.BregmaLeft;
            cmdParms[43].Value = model.BregmaRight;
            cmdParms[44].Value = model.Bregma;
            cmdParms[45].Value = model.BregmaOther;
            cmdParms[46].Value = model.EyeAppearance;
            cmdParms[47].Value = model.EyeAppearanceEx;
            cmdParms[48].Value = model.LimbsActivity;
            cmdParms[49].Value = model.LimbsActivityEx;
            cmdParms[50].Value = model.EarAppearance;
            cmdParms[51].Value = model.EarAppearanceEx;
            cmdParms[52].Value = model.NeckMass;
            cmdParms[53].Value = model.NeckMassHave;
            cmdParms[54].Value = model.Nose;
            cmdParms[55].Value = model.NoseEx;
            cmdParms[56].Value = model.Skin;
            cmdParms[57].Value = model.SkinOther;
            cmdParms[58].Value = model.MouthCavity;
            cmdParms[59].Value = model.MouthCavityEx;
            cmdParms[60].Value = model.Anus;
            cmdParms[61].Value = model.AnusEx;
            cmdParms[62].Value = model.HeartLungAuscul;
            cmdParms[63].Value = model.HeartLungAusculEx;
            cmdParms[64].Value = model.Aedea;
            cmdParms[65].Value = model.AedeaEx;
            cmdParms[66].Value = model.AbdominalTouch;
            cmdParms[67].Value = model.AbdominalTouchEx;
            cmdParms[68].Value = model.Spine;
            cmdParms[69].Value = model.SpineEx;
            cmdParms[70].Value = model.UmbilicalCord;
            cmdParms[71].Value = model.UmbilicalCordOther;
            cmdParms[72].Value = model.ReferralAdvice;
            cmdParms[73].Value = model.ReferralReason;
            cmdParms[74].Value = model.AgenciesDepartments;
            cmdParms[75].Value = model.Guidance;
            cmdParms[76].Value = model.InterviewDate;
            cmdParms[77].Value = model.NextFollowupPlace;
            cmdParms[78].Value = model.NextFollowupDate;
            cmdParms[79].Value = model.FollowUpDoctorSign;
            cmdParms[80].Value = model.CreatedBy;
            cmdParms[81].Value = model.CreatedDate;
            cmdParms[82].Value = model.LastUpdateBy;
            cmdParms[83].Value = model.LastUpdateDate;
            cmdParms[84].Value = model.IsDel;
            cmdParms[85].Value = model.Apgar1;
            cmdParms[86].Value = model.Apgar5;
            cmdParms[87].Value = model.FatherID;
            cmdParms[88].Value = model.MotherID;
            cmdParms[89].Value = model.Chest;
            cmdParms[90].Value = model.ChestEx;
            cmdParms[91].Value = model.GuidanceOther;
            cmdParms[92].Value = model.ReferralOrgan;
            cmdParms[93].Value = model.ReferraContacts;
            cmdParms[94].Value = model.ReferralContactsTel;
            cmdParms[95].Value = model.ReferralResult;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public KidsNewBornVisitModel DataRowToModel(DataRow row)
        {
            KidsNewBornVisitModel kidsNewBornVisitModel = new KidsNewBornVisitModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    kidsNewBornVisitModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Sex"] != null) && (row["Sex"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Sex = row["Sex"].ToString();
                }
                if (((row["Birthday"] != null) && (row["Birthday"] != DBNull.Value)) && (row["Birthday"].ToString() != ""))
                {
                    kidsNewBornVisitModel.Birthday = new DateTime?(DateTime.Parse(row["Birthday"].ToString()));
                }
                if ((row["HomeAddr"] != null) && (row["HomeAddr"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.HomeAddr = row["HomeAddr"].ToString();
                }
                if ((row["FatherName"] != null) && (row["FatherName"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.FatherName = row["FatherName"].ToString();
                }
                if ((row["FatherJob"] != null) && (row["FatherJob"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.FatherJob = row["FatherJob"].ToString();
                }
                if ((row["FatherTel"] != null) && (row["FatherTel"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.FatherTel = row["FatherTel"].ToString();
                }
                if (((row["FatherBirthday"] != null) && (row["FatherBirthday"] != DBNull.Value)) && (row["FatherBirthday"].ToString() != ""))
                {
                    kidsNewBornVisitModel.FatherBirthday = new DateTime?(DateTime.Parse(row["FatherBirthday"].ToString()));
                }
                if ((row["MotherName"] != null) && (row["MotherName"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.MotherName = row["MotherName"].ToString();
                }
                if ((row["MotherJob"] != null) && (row["MotherJob"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.MotherJob = row["MotherJob"].ToString();
                }
                if ((row["MotherTel"] != null) && (row["MotherTel"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.MotherTel = row["MotherTel"].ToString();
                }
                if (((row["MotherBirthday"] != null) && (row["MotherBirthday"] != DBNull.Value)) && (row["MotherBirthday"].ToString() != ""))
                {
                    kidsNewBornVisitModel.MotherBirthday = new DateTime?(DateTime.Parse(row["MotherBirthday"].ToString()));
                }
                if (((row["GestationalWeek"] != null) && (row["GestationalWeek"] != DBNull.Value)) && (row["GestationalWeek"].ToString() != ""))
                {
                    kidsNewBornVisitModel.GestationalWeek = new decimal?(decimal.Parse(row["GestationalWeek"].ToString()));
                }
                if ((row["PregnancPreva"] != null) && (row["PregnancPreva"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.PregnancPreva = row["PregnancPreva"].ToString();
                }
                if ((row["PregnancPrevaOther"] != null) && (row["PregnancPrevaOther"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.PregnancPrevaOther = row["PregnancPrevaOther"].ToString();
                }
                if ((row["MidwifOrganizaName"] != null) && (row["MidwifOrganizaName"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.MidwifOrganizaName = row["MidwifOrganizaName"].ToString();
                }
                if ((row["BirthInforma"] != null) && (row["BirthInforma"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.BirthInforma = row["BirthInforma"].ToString();
                }
                if ((row["BirthInformaOther"] != null) && (row["BirthInformaOther"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.BirthInformaOther = row["BirthInformaOther"].ToString();
                }
                if ((row["Aasphyxia"] != null) && (row["Aasphyxia"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Aasphyxia = row["Aasphyxia"].ToString();
                }
                if ((row["Apgar"] != null) && (row["Apgar"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Apgar = row["Apgar"].ToString();
                }
                if ((row["WhetherAbnorma"] != null) && (row["WhetherAbnorma"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.WhetherAbnorma = row["WhetherAbnorma"].ToString();
                }
                if ((row["WhetherAbnormaHave"] != null) && (row["WhetherAbnormaHave"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.WhetherAbnormaHave = row["WhetherAbnormaHave"].ToString();
                }
                if ((row["HearingScreen"] != null) && (row["HearingScreen"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.HearingScreen = row["HearingScreen"].ToString();
                }
                if ((row["DiseaseScreen"] != null) && (row["DiseaseScreen"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.DiseaseScreen = row["DiseaseScreen"].ToString();
                }
                if ((row["DiseaseScreenOther"] != null) && (row["DiseaseScreenOther"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.DiseaseScreenOther = row["DiseaseScreenOther"].ToString();
                }
                if (((row["BirthWeight"] != null) && (row["BirthWeight"] != DBNull.Value)) && (row["BirthWeight"].ToString() != ""))
                {
                    kidsNewBornVisitModel.BirthWeight = new decimal?(decimal.Parse(row["BirthWeight"].ToString()));
                }
                if (((row["PresentWeight"] != null) && (row["PresentWeight"] != DBNull.Value)) && (row["PresentWeight"].ToString() != ""))
                {
                    kidsNewBornVisitModel.PresentWeight = new decimal?(decimal.Parse(row["PresentWeight"].ToString()));
                }
                if (((row["BirthStature"] != null) && (row["BirthStature"] != DBNull.Value)) && (row["BirthStature"].ToString() != ""))
                {
                    kidsNewBornVisitModel.BirthStature = new decimal?(decimal.Parse(row["BirthStature"].ToString()));
                }
                if ((row["FeedingPattern"] != null) && (row["FeedingPattern"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.FeedingPattern = row["FeedingPattern"].ToString();
                }
                if (((row["NursingQuantity"] != null) && (row["NursingQuantity"] != DBNull.Value)) && (row["NursingQuantity"].ToString() != ""))
                {
                    kidsNewBornVisitModel.NursingQuantity = new decimal?(decimal.Parse(row["NursingQuantity"].ToString()));
                }
                if (((row["InfantFrequen"] != null) && (row["InfantFrequen"] != DBNull.Value)) && (row["InfantFrequen"].ToString() != ""))
                {
                    kidsNewBornVisitModel.InfantFrequen = new decimal?(decimal.Parse(row["InfantFrequen"].ToString()));
                }
                if ((row["Vomit"] != null) && (row["Vomit"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Vomit = row["Vomit"].ToString();
                }
                if ((row["Stool"] != null) && (row["Stool"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Stool = row["Stool"].ToString();
                }
                if (((row["StoolFrequen"] != null) && (row["StoolFrequen"] != DBNull.Value)) && (row["StoolFrequen"].ToString() != ""))
                {
                    kidsNewBornVisitModel.StoolFrequen = new decimal?(decimal.Parse(row["StoolFrequen"].ToString()));
                }
                if (((row["Temperature"] != null) && (row["Temperature"] != DBNull.Value)) && (row["Temperature"].ToString() != ""))
                {
                    kidsNewBornVisitModel.Temperature = new decimal?(decimal.Parse(row["Temperature"].ToString()));
                }
                if (((row["PulseRate"] != null) && (row["PulseRate"] != DBNull.Value)) && (row["PulseRate"].ToString() != ""))
                {
                    kidsNewBornVisitModel.PulseRate = new decimal?(decimal.Parse(row["PulseRate"].ToString()));
                }
                if (((row["BreathingRate"] != null) && (row["BreathingRate"] != DBNull.Value)) && (row["BreathingRate"].ToString() != ""))
                {
                    kidsNewBornVisitModel.BreathingRate = new decimal?(decimal.Parse(row["BreathingRate"].ToString()));
                }
                if ((row["ColourFace"] != null) && (row["ColourFace"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.ColourFace = row["ColourFace"].ToString();
                }
                if ((row["ColourFaceOther"] != null) && (row["ColourFaceOther"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.ColourFaceOther = row["ColourFaceOther"].ToString();
                }
                if ((row["Jaundice"] != null) && (row["Jaundice"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Jaundice = row["Jaundice"].ToString();
                }
                if (((row["BregmaLeft"] != null) && (row["BregmaLeft"] != DBNull.Value)) && (row["BregmaLeft"].ToString() != ""))
                {
                    kidsNewBornVisitModel.BregmaLeft = new decimal?(decimal.Parse(row["BregmaLeft"].ToString()));
                }
                if (((row["BregmaRight"] != null) && (row["BregmaRight"] != DBNull.Value)) && (row["BregmaRight"].ToString() != ""))
                {
                    kidsNewBornVisitModel.BregmaRight = new decimal?(decimal.Parse(row["BregmaRight"].ToString()));
                }
                if ((row["Bregma"] != null) && (row["Bregma"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Bregma = row["Bregma"].ToString();
                }
                if ((row["BregmaOther"] != null) && (row["BregmaOther"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.BregmaOther = row["BregmaOther"].ToString();
                }
                if ((row["EyeAppearance"] != null) && (row["EyeAppearance"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.EyeAppearance = row["EyeAppearance"].ToString();
                }
                if ((row["EyeAppearanceEx"] != null) && (row["EyeAppearanceEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.EyeAppearanceEx = row["EyeAppearanceEx"].ToString();
                }
                if ((row["LimbsActivity"] != null) && (row["LimbsActivity"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.LimbsActivity = row["LimbsActivity"].ToString();
                }
                if ((row["LimbsActivityEx"] != null) && (row["LimbsActivityEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.LimbsActivityEx = row["LimbsActivityEx"].ToString();
                }
                if ((row["EarAppearance"] != null) && (row["EarAppearance"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.EarAppearance = row["EarAppearance"].ToString();
                }
                if ((row["EarAppearanceEx"] != null) && (row["EarAppearanceEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.EarAppearanceEx = row["EarAppearanceEx"].ToString();
                }
                if ((row["NeckMass"] != null) && (row["NeckMass"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.NeckMass = row["NeckMass"].ToString();
                }
                if ((row["NeckMassHave"] != null) && (row["NeckMassHave"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.NeckMassHave = row["NeckMassHave"].ToString();
                }
                if ((row["Nose"] != null) && (row["Nose"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Nose = row["Nose"].ToString();
                }
                if ((row["NoseEx"] != null) && (row["NoseEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.NoseEx = row["NoseEx"].ToString();
                }
                if ((row["Skin"] != null) && (row["Skin"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Skin = row["Skin"].ToString();
                }
                if ((row["SkinOther"] != null) && (row["SkinOther"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.SkinOther = row["SkinOther"].ToString();
                }
                if ((row["MouthCavity"] != null) && (row["MouthCavity"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.MouthCavity = row["MouthCavity"].ToString();
                }
                if ((row["MouthCavityEx"] != null) && (row["MouthCavityEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.MouthCavityEx = row["MouthCavityEx"].ToString();
                }
                if ((row["Anus"] != null) && (row["Anus"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Anus = row["Anus"].ToString();
                }
                if ((row["AnusEx"] != null) && (row["AnusEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.AnusEx = row["AnusEx"].ToString();
                }
                if ((row["HeartLungAuscul"] != null) && (row["HeartLungAuscul"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.HeartLungAuscul = row["HeartLungAuscul"].ToString();
                }
                if ((row["HeartLungAusculEx"] != null) && (row["HeartLungAusculEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.HeartLungAusculEx = row["HeartLungAusculEx"].ToString();
                }
                if ((row["Aedea"] != null) && (row["Aedea"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Aedea = row["Aedea"].ToString();
                }
                if ((row["AedeaEx"] != null) && (row["AedeaEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.AedeaEx = row["AedeaEx"].ToString();
                }
                if ((row["AbdominalTouch"] != null) && (row["AbdominalTouch"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.AbdominalTouch = row["AbdominalTouch"].ToString();
                }
                if ((row["AbdominalTouchEx"] != null) && (row["AbdominalTouchEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.AbdominalTouchEx = row["AbdominalTouchEx"].ToString();
                }
                if ((row["Spine"] != null) && (row["Spine"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Spine = row["Spine"].ToString();
                }
                if ((row["SpineEx"] != null) && (row["SpineEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.SpineEx = row["SpineEx"].ToString();
                }
                if ((row["UmbilicalCord"] != null) && (row["UmbilicalCord"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.UmbilicalCord = row["UmbilicalCord"].ToString();
                }
                if ((row["UmbilicalCordOther"] != null) && (row["UmbilicalCordOther"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.UmbilicalCordOther = row["UmbilicalCordOther"].ToString();
                }
                if ((row["ReferralAdvice"] != null) && (row["ReferralAdvice"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.ReferralAdvice = row["ReferralAdvice"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["AgenciesDepartments"] != null) && (row["AgenciesDepartments"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.AgenciesDepartments = row["AgenciesDepartments"].ToString();
                }
                if ((row["Guidance"] != null) && (row["Guidance"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Guidance = row["Guidance"].ToString();
                }
                if (((row["InterviewDate"] != null) && (row["InterviewDate"] != DBNull.Value)) && (row["InterviewDate"].ToString() != ""))
                {
                    kidsNewBornVisitModel.InterviewDate = new DateTime?(DateTime.Parse(row["InterviewDate"].ToString()));
                }
                if ((row["NextFollowupPlace"] != null) && (row["NextFollowupPlace"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.NextFollowupPlace = row["NextFollowupPlace"].ToString();
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    kidsNewBornVisitModel.NextFollowupDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["FollowUpDoctorSign"] != null) && (row["FollowUpDoctorSign"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.FollowUpDoctorSign = row["FollowUpDoctorSign"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    kidsNewBornVisitModel.CreatedBy = row["CreatedBy"].ToString();
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    kidsNewBornVisitModel.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    kidsNewBornVisitModel.LastUpdateBy = row["LastUpdateBy"].ToString();
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    kidsNewBornVisitModel.LastUpdateDate = DateTime.Parse(row["LastUpdateDate"].ToString());
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.IsDel = row["IsDel"].ToString();
                }
                if (((row["Apgar1"] != null) && (row["Apgar1"] != DBNull.Value)) && (row["Apgar1"].ToString() != ""))
                {
                    kidsNewBornVisitModel.Apgar1 = new decimal?(decimal.Parse(row["Apgar1"].ToString()));
                }
                if (((row["Apgar5"] != null) && (row["Apgar5"] != DBNull.Value)) && (row["Apgar5"].ToString() != ""))
                {
                    kidsNewBornVisitModel.BreathingRate = new decimal?(decimal.Parse(row["Apgar5"].ToString()));
                }
                if ((row["FatherID"] != null) && (row["FatherID"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.FatherID = row["FatherID"].ToString();
                }
                if ((row["MotherID"] != null) && (row["MotherID"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.MotherID = row["MotherID"].ToString();
                }
                if ((row["Chest"] != null) && (row["Chest"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.Chest = row["Chest"].ToString();
                }
                if ((row["ChestEx"] != null) && (row["ChestEx"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.ChestEx = row["ChestEx"].ToString();
                }
                if ((row["GuidanceOther"] != null) && (row["GuidanceOther"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.GuidanceOther = row["GuidanceOther"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.ReferralResult = row["ReferralResult"].ToString();
                }
                if ((row["ReferralOrgan"] != null) && (row["ReferralOrgan"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.ReferralOrgan = row["ReferralOrgan"].ToString();
                }
                if ((row["ReferraContacts"] != null) && (row["ReferraContacts"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.ReferraContacts = row["ReferraContacts"].ToString();
                }
                if ((row["ReferralContactsTel"] != null) && (row["ReferralContactsTel"] != DBNull.Value))
                {
                    kidsNewBornVisitModel.ReferralContactsTel = row["ReferralContactsTel"].ToString();
                }
            }
            return kidsNewBornVisitModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CHILD_NEWBORN_FOLLOWUP ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CHILD_NEWBORN_FOLLOWUP ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CHILD_NEWBORN_FOLLOWUP");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,Sex,Birthday,HomeAddr,FatherName,FatherJob,FatherTel,FatherBirthday,MotherName,MotherJob,MotherTel,MotherBirthday,GestationalWeek,PregnancPreva,PregnancPrevaOther,MidwifOrganizaName,BirthInforma,BirthInformaOther,Aasphyxia,Apgar,WhetherAbnorma,WhetherAbnormaHave,HearingScreen,DiseaseScreen,DiseaseScreenOther,BirthWeight,PresentWeight,BirthStature,FeedingPattern,NursingQuantity,InfantFrequen,Vomit,Stool,StoolFrequen,Temperature,PulseRate,BreathingRate,ColourFace,ColourFaceOther,Jaundice,BregmaLeft,BregmaRight,Bregma,BregmaOther,EyeAppearance,EyeAppearanceEx,LimbsActivity,LimbsActivityEx,EarAppearance,EarAppearanceEx,NeckMass,NeckMassHave,Nose,NoseEx,Skin,SkinOther,MouthCavity,MouthCavityEx,Anus,AnusEx,HeartLungAuscul,HeartLungAusculEx,Aedea,AedeaEx,AbdominalTouch,AbdominalTouchEx,Spine,SpineEx,UmbilicalCord,UmbilicalCordOther,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,InterviewDate,NextFollowupPlace,NextFollowUpDate,FollowUpDoctorSign,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,Apgar1,Apgar5, ");
            builder.Append("FatherID,MotherID,Chest,ChestEx,GuidanceOther,ReferralOrgan,ReferraContacts,ReferralContactsTel,ReferralResult ");
            builder.Append(" FROM CHILD_NEWBORN_FOLLOWUP ");
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
            builder.Append(")AS Row, T.*  from CHILD_NEWBORN_FOLLOWUP T ");
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
            return MySQLHelper.GetMaxID("ID", "CHILD_NEWBORN_FOLLOWUP");
        }

        public KidsNewBornVisitModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Sex,Birthday,HomeAddr,FatherName,FatherJob,FatherTel,FatherBirthday,MotherName,MotherJob,MotherTel,MotherBirthday,GestationalWeek,PregnancPreva,PregnancPrevaOther,MidwifOrganizaName,BirthInforma,BirthInformaOther,Aasphyxia,Apgar,WhetherAbnorma,WhetherAbnormaHave,HearingScreen,DiseaseScreen,DiseaseScreenOther,BirthWeight,PresentWeight,BirthStature,FeedingPattern,NursingQuantity,InfantFrequen,Vomit,Stool,StoolFrequen,Temperature,PulseRate,BreathingRate,ColourFace,ColourFaceOther,Jaundice,BregmaLeft,BregmaRight,Bregma,BregmaOther,EyeAppearance,EyeAppearanceEx,LimbsActivity,LimbsActivityEx,EarAppearance,EarAppearanceEx,NeckMass,NeckMassHave,Nose,NoseEx,Skin,SkinOther,MouthCavity,MouthCavityEx,Anus,AnusEx,HeartLungAuscul,HeartLungAusculEx,Aedea,AedeaEx,AbdominalTouch,AbdominalTouchEx,Spine,SpineEx,UmbilicalCord,UmbilicalCordOther,ReferralAdvice,ReferralReason,AgenciesDepartments,Guidance,InterviewDate,NextFollowupPlace,NextFollowUpDate,FollowUpDoctorSign,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,Apgar1,Apgar5, ");
            builder.Append("FatherID,MotherID,Chest,ChestEx,GuidanceOther,ReferralOrgan,ReferraContacts,ReferralContactsTel,ReferralResult ");
            builder.Append(" FROM CHILD_NEWBORN_FOLLOWUP ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new KidsNewBornVisitModel();
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
            builder.Append("select count(1) FROM CHILD_NEWBORN_FOLLOWUP ");
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

        public bool Update(KidsNewBornVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CHILD_NEWBORN_FOLLOWUP set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Sex=@Sex,");
            builder.Append("Birthday=@Birthday,");
            builder.Append("HomeAddr=@HomeAddr,");
            builder.Append("FatherName=@FatherName,");
            builder.Append("FatherJob=@FatherJob,");
            builder.Append("FatherTel=@FatherTel,");
            builder.Append("FatherBirthday=@FatherBirthday,");
            builder.Append("MotherName=@MotherName,");
            builder.Append("MotherJob=@MotherJob,");
            builder.Append("MotherTel=@MotherTel,");
            builder.Append("MotherBirthday=@MotherBirthday,");
            builder.Append("GestationalWeek=@GestationalWeek,");
            builder.Append("PregnancPreva=@PregnancPreva,");
            builder.Append("PregnancPrevaOther=@PregnancPrevaOther,");
            builder.Append("MidwifOrganizaName=@MidwifOrganizaName,");
            builder.Append("BirthInforma=@BirthInforma,");
            builder.Append("BirthInformaOther=@BirthInformaOther,");
            builder.Append("Aasphyxia=@Aasphyxia,");
            builder.Append("Apgar=@Apgar,");
            builder.Append("WhetherAbnorma=@WhetherAbnorma,");
            builder.Append("WhetherAbnormaHave=@WhetherAbnormaHave,");
            builder.Append("HearingScreen=@HearingScreen,");
            builder.Append("DiseaseScreen=@DiseaseScreen,");
            builder.Append("DiseaseScreenOther=@DiseaseScreenOther,");
            builder.Append("BirthWeight=@BirthWeight,");
            builder.Append("PresentWeight=@PresentWeight,");
            builder.Append("BirthStature=@BirthStature,");
            builder.Append("FeedingPattern=@FeedingPattern,");
            builder.Append("NursingQuantity=@NursingQuantity,");
            builder.Append("InfantFrequen=@InfantFrequen,");
            builder.Append("Vomit=@Vomit,");
            builder.Append("Stool=@Stool,");
            builder.Append("StoolFrequen=@StoolFrequen,");
            builder.Append("Temperature=@Temperature,");
            builder.Append("PulseRate=@PulseRate,");
            builder.Append("BreathingRate=@BreathingRate,");
            builder.Append("ColourFace=@ColourFace,");
            builder.Append("ColourFaceOther=@ColourFaceOther,");
            builder.Append("Jaundice=@Jaundice,");
            builder.Append("BregmaLeft=@BregmaLeft,");
            builder.Append("BregmaRight=@BregmaRight,");
            builder.Append("Bregma=@Bregma,");
            builder.Append("BregmaOther=@BregmaOther,");
            builder.Append("EyeAppearance=@EyeAppearance,");
            builder.Append("EyeAppearanceEx=@EyeAppearanceEx,");
            builder.Append("LimbsActivity=@LimbsActivity,");
            builder.Append("LimbsActivityEx=@LimbsActivityEx,");
            builder.Append("EarAppearance=@EarAppearance,");
            builder.Append("EarAppearanceEx=@EarAppearanceEx,");
            builder.Append("NeckMass=@NeckMass,");
            builder.Append("NeckMassHave=@NeckMassHave,");
            builder.Append("Nose=@Nose,");
            builder.Append("NoseEx=@NoseEx,");
            builder.Append("Skin=@Skin,");
            builder.Append("SkinOther=@SkinOther,");
            builder.Append("MouthCavity=@MouthCavity,");
            builder.Append("MouthCavityEx=@MouthCavityEx,");
            builder.Append("Anus=@Anus,");
            builder.Append("AnusEx=@AnusEx,");
            builder.Append("HeartLungAuscul=@HeartLungAuscul,");
            builder.Append("HeartLungAusculEx=@HeartLungAusculEx,");
            builder.Append("Aedea=@Aedea,");
            builder.Append("AedeaEx=@AedeaEx,");
            builder.Append("AbdominalTouch=@AbdominalTouch,");
            builder.Append("AbdominalTouchEx=@AbdominalTouchEx,");
            builder.Append("Spine=@Spine,");
            builder.Append("SpineEx=@SpineEx,");
            builder.Append("UmbilicalCord=@UmbilicalCord,");
            builder.Append("UmbilicalCordOther=@UmbilicalCordOther,");
            builder.Append("ReferralAdvice=@ReferralAdvice,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("AgenciesDepartments=@AgenciesDepartments,");
            builder.Append("Guidance=@Guidance,");
            builder.Append("InterviewDate=@InterviewDate,");
            builder.Append("NextFollowupPlace=@NextFollowupPlace,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctorSign=@FollowUpDoctorSign,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("Apgar1=@Apgar1,");
            builder.Append("Apgar5=@Apgar5, ");
            builder.Append("FatherID=@FatherID, ");
            builder.Append("MotherID=@MotherID, ");
            builder.Append("Chest=@Chest, ");
            builder.Append("ChestEx=@ChestEx, ");
            builder.Append("GuidanceOther=@GuidanceOther, ");
            builder.Append("ReferralOrgan=@ReferralOrgan, ");
            builder.Append("ReferraContacts=@ReferraContacts, ");
            builder.Append("ReferralContactsTel=@ReferralContactsTel, ");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Sex", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date),
                new MySqlParameter("@HomeAddr", MySqlDbType.String, 200),
                new MySqlParameter("@FatherName", MySqlDbType.String, 30),
                new MySqlParameter("@FatherJob", MySqlDbType.String, 50), 
                new MySqlParameter("@FatherTel", MySqlDbType.String, 15), 
                new MySqlParameter("@FatherBirthday", MySqlDbType.Date), 
                new MySqlParameter("@MotherName", MySqlDbType.String, 30),
                new MySqlParameter("@MotherJob", MySqlDbType.String, 50), 
                new MySqlParameter("@MotherTel", MySqlDbType.String, 15), 
                new MySqlParameter("@MotherBirthday", MySqlDbType.Date), 
                new MySqlParameter("@GestationalWeek", MySqlDbType.Decimal),
                new MySqlParameter("@PregnancPreva", MySqlDbType.String, 1), 
                new MySqlParameter("@PregnancPrevaOther", MySqlDbType.String, 100),
                new MySqlParameter("@MidwifOrganizaName", MySqlDbType.String, 50), 
                new MySqlParameter("@BirthInforma", MySqlDbType.String, 30), 
                new MySqlParameter("@BirthInformaOther", MySqlDbType.String, 100),
                new MySqlParameter("@Aasphyxia", MySqlDbType.String, 1), 
                new MySqlParameter("@Apgar", MySqlDbType.String, 100), 
                new MySqlParameter("@WhetherAbnorma", MySqlDbType.String, 1), 
                new MySqlParameter("@WhetherAbnormaHave", MySqlDbType.String, 100), 
                new MySqlParameter("@HearingScreen", MySqlDbType.String, 1), 
                new MySqlParameter("@DiseaseScreen", MySqlDbType.String, 100),
                new MySqlParameter("@DiseaseScreenOther", MySqlDbType.String, 100),
                new MySqlParameter("@BirthWeight", MySqlDbType.Decimal), 
                new MySqlParameter("@PresentWeight", MySqlDbType.Decimal), 
                new MySqlParameter("@BirthStature", MySqlDbType.Decimal), 
                new MySqlParameter("@FeedingPattern", MySqlDbType.String, 1),
                new MySqlParameter("@NursingQuantity", MySqlDbType.Decimal), 
                new MySqlParameter("@InfantFrequen", MySqlDbType.Decimal),
                new MySqlParameter("@Vomit", MySqlDbType.String, 1), 
                new MySqlParameter("@Stool", MySqlDbType.String, 1), 
                new MySqlParameter("@StoolFrequen", MySqlDbType.Decimal), 
                new MySqlParameter("@Temperature", MySqlDbType.Decimal), 
                new MySqlParameter("@PulseRate", MySqlDbType.Decimal), 
                new MySqlParameter("@BreathingRate", MySqlDbType.Decimal), 
                new MySqlParameter("@ColourFace", MySqlDbType.String, 100), 
                new MySqlParameter("@ColourFaceOther", MySqlDbType.String, 100),
                new MySqlParameter("@Jaundice", MySqlDbType.String, 1), 
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal),
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal), 
                new MySqlParameter("@Bregma", MySqlDbType.String, 1), 
                new MySqlParameter("@BregmaOther", MySqlDbType.String, 100),
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeAppearanceEx", MySqlDbType.String, 100), 
                new MySqlParameter("@LimbsActivity", MySqlDbType.String, 1), 
                new MySqlParameter("@LimbsActivityEx", MySqlDbType.String, 100),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@EarAppearanceEx", MySqlDbType.String, 100),
                new MySqlParameter("@NeckMass", MySqlDbType.String, 1), 
                new MySqlParameter("@NeckMassHave", MySqlDbType.String, 100),
                new MySqlParameter("@Nose", MySqlDbType.String, 1),
                new MySqlParameter("@NoseEx", MySqlDbType.String, 100),
                new MySqlParameter("@Skin", MySqlDbType.String, 100), 
                new MySqlParameter("@SkinOther", MySqlDbType.String, 100), 
                new MySqlParameter("@MouthCavity", MySqlDbType.String, 1), 
                new MySqlParameter("@MouthCavityEx", MySqlDbType.String, 100),
                new MySqlParameter("@Anus", MySqlDbType.String, 1), 
                new MySqlParameter("@AnusEx", MySqlDbType.String, 100), 
                new MySqlParameter("@HeartLungAuscul", MySqlDbType.String, 1),
                new MySqlParameter("@HeartLungAusculEx", MySqlDbType.String, 100), 
                new MySqlParameter("@Aedea", MySqlDbType.String, 1), 
                new MySqlParameter("@AedeaEx", MySqlDbType.String, 100),
                new MySqlParameter("@AbdominalTouch", MySqlDbType.String, 1),
                new MySqlParameter("@AbdominalTouchEx", MySqlDbType.String, 100),
                new MySqlParameter("@Spine", MySqlDbType.String, 1), 
                new MySqlParameter("@SpineEx", MySqlDbType.String, 100), 
                new MySqlParameter("@UmbilicalCord", MySqlDbType.String, 1), 
                new MySqlParameter("@UmbilicalCordOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80), 
                new MySqlParameter("@Guidance", MySqlDbType.String, 20), 
                new MySqlParameter("@InterviewDate", MySqlDbType.Date), 
                new MySqlParameter("@NextFollowupPlace", MySqlDbType.String, 100),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30), 
                new MySqlParameter("@CreatedBy", MySqlDbType.String), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@Apgar1", MySqlDbType.Decimal), 
                new MySqlParameter("@Apgar5", MySqlDbType.Decimal),
                new MySqlParameter("@FatherID", MySqlDbType.String, 21),
                new MySqlParameter("@MotherID", MySqlDbType.String, 21),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@ChestEx", MySqlDbType.String, 100),
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralOrgan",MySqlDbType.String,100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Sex;
            cmdParms[4].Value = model.Birthday;
            cmdParms[5].Value = model.HomeAddr;
            cmdParms[6].Value = model.FatherName;
            cmdParms[7].Value = model.FatherJob;
            cmdParms[8].Value = model.FatherTel;
            cmdParms[9].Value = model.FatherBirthday;
            cmdParms[10].Value = model.MotherName;
            cmdParms[11].Value = model.MotherJob;
            cmdParms[12].Value = model.MotherTel;
            cmdParms[13].Value = model.MotherBirthday;
            cmdParms[14].Value = model.GestationalWeek;
            cmdParms[15].Value = model.PregnancPreva;
            cmdParms[16].Value = model.PregnancPrevaOther;
            cmdParms[17].Value = model.MidwifOrganizaName;
            cmdParms[18].Value = model.BirthInforma;
            cmdParms[19].Value = model.BirthInformaOther;
            cmdParms[20].Value = model.Aasphyxia;
            cmdParms[21].Value = model.Apgar;
            cmdParms[22].Value = model.WhetherAbnorma;
            cmdParms[23].Value = model.WhetherAbnormaHave;
            cmdParms[24].Value = model.HearingScreen;
            cmdParms[25].Value = model.DiseaseScreen;
            cmdParms[26].Value = model.DiseaseScreenOther;
            cmdParms[27].Value = model.BirthWeight;
            cmdParms[28].Value = model.PresentWeight;
            cmdParms[29].Value = model.BirthStature;
            cmdParms[30].Value = model.FeedingPattern;
            cmdParms[31].Value = model.NursingQuantity;
            cmdParms[32].Value = model.InfantFrequen;
            cmdParms[33].Value = model.Vomit;
            cmdParms[34].Value = model.Stool;
            cmdParms[35].Value = model.StoolFrequen;
            cmdParms[36].Value = model.Temperature;
            cmdParms[37].Value = model.PulseRate;
            cmdParms[38].Value = model.BreathingRate;
            cmdParms[39].Value = model.ColourFace;
            cmdParms[40].Value = model.ColourFaceOther;
            cmdParms[41].Value = model.Jaundice;
            cmdParms[42].Value = model.BregmaLeft;
            cmdParms[43].Value = model.BregmaRight;
            cmdParms[44].Value = model.Bregma;
            cmdParms[45].Value = model.BregmaOther;
            cmdParms[46].Value = model.EyeAppearance;
            cmdParms[47].Value = model.EyeAppearanceEx;
            cmdParms[48].Value = model.LimbsActivity;
            cmdParms[49].Value = model.LimbsActivityEx;
            cmdParms[50].Value = model.EarAppearance;
            cmdParms[51].Value = model.EarAppearanceEx;
            cmdParms[52].Value = model.NeckMass;
            cmdParms[53].Value = model.NeckMassHave;
            cmdParms[54].Value = model.Nose;
            cmdParms[55].Value = model.NoseEx;
            cmdParms[56].Value = model.Skin;
            cmdParms[57].Value = model.SkinOther;
            cmdParms[58].Value = model.MouthCavity;
            cmdParms[59].Value = model.MouthCavityEx;
            cmdParms[60].Value = model.Anus;
            cmdParms[61].Value = model.AnusEx;
            cmdParms[62].Value = model.HeartLungAuscul;
            cmdParms[63].Value = model.HeartLungAusculEx;
            cmdParms[64].Value = model.Aedea;
            cmdParms[65].Value = model.AedeaEx;
            cmdParms[66].Value = model.AbdominalTouch;
            cmdParms[67].Value = model.AbdominalTouchEx;
            cmdParms[68].Value = model.Spine;
            cmdParms[69].Value = model.SpineEx;
            cmdParms[70].Value = model.UmbilicalCord;
            cmdParms[71].Value = model.UmbilicalCordOther;
            cmdParms[72].Value = model.ReferralAdvice;
            cmdParms[73].Value = model.ReferralReason;
            cmdParms[74].Value = model.AgenciesDepartments;
            cmdParms[75].Value = model.Guidance;
            cmdParms[76].Value = model.InterviewDate;
            cmdParms[77].Value = model.NextFollowupPlace;
            cmdParms[78].Value = model.NextFollowupDate;
            cmdParms[79].Value = model.FollowUpDoctorSign;
            cmdParms[80].Value = model.CreatedBy;
            cmdParms[81].Value = model.CreatedDate;
            cmdParms[82].Value = model.LastUpdateBy;
            cmdParms[83].Value = model.LastUpdateDate;
            cmdParms[84].Value = model.IsDel;
            cmdParms[85].Value = model.Apgar1;
            cmdParms[86].Value = model.Apgar5;
            cmdParms[87].Value = model.FatherID;
            cmdParms[88].Value = model.MotherID;
            cmdParms[89].Value = model.Chest;
            cmdParms[90].Value = model.ChestEx;
            cmdParms[91].Value = model.GuidanceOther;
            cmdParms[92].Value = model.ReferralOrgan;
            cmdParms[93].Value = model.ReferraContacts;
            cmdParms[94].Value = model.ReferralContactsTel;
            cmdParms[95].Value = model.ReferralResult;
            cmdParms[96].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(KidsNewBornVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CHILD_NEWBORN_FOLLOWUP set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Sex=@Sex,");
            builder.Append("Birthday=@Birthday,");
            builder.Append("HomeAddr=@HomeAddr,");
            builder.Append("FatherName=@FatherName,");
            builder.Append("FatherJob=@FatherJob,");
            builder.Append("FatherTel=@FatherTel,");
            builder.Append("FatherBirthday=@FatherBirthday,");
            builder.Append("MotherName=@MotherName,");
            builder.Append("MotherJob=@MotherJob,");
            builder.Append("MotherTel=@MotherTel,");
            builder.Append("MotherBirthday=@MotherBirthday,");
            builder.Append("GestationalWeek=@GestationalWeek,");
            builder.Append("PregnancPreva=@PregnancPreva,");
            builder.Append("PregnancPrevaOther=@PregnancPrevaOther,");
            builder.Append("MidwifOrganizaName=@MidwifOrganizaName,");
            builder.Append("BirthInforma=@BirthInforma,");
            builder.Append("BirthInformaOther=@BirthInformaOther,");
            builder.Append("Aasphyxia=@Aasphyxia,");
            builder.Append("Apgar=@Apgar,");
            builder.Append("WhetherAbnorma=@WhetherAbnorma,");
            builder.Append("WhetherAbnormaHave=@WhetherAbnormaHave,");
            builder.Append("HearingScreen=@HearingScreen,");
            builder.Append("DiseaseScreen=@DiseaseScreen,");
            builder.Append("DiseaseScreenOther=@DiseaseScreenOther,");
            builder.Append("BirthWeight=@BirthWeight,");
            builder.Append("PresentWeight=@PresentWeight,");
            builder.Append("BirthStature=@BirthStature,");
            builder.Append("FeedingPattern=@FeedingPattern,");
            builder.Append("NursingQuantity=@NursingQuantity,");
            builder.Append("InfantFrequen=@InfantFrequen,");
            builder.Append("Vomit=@Vomit,");
            builder.Append("Stool=@Stool,");
            builder.Append("StoolFrequen=@StoolFrequen,");
            builder.Append("Temperature=@Temperature,");
            builder.Append("PulseRate=@PulseRate,");
            builder.Append("BreathingRate=@BreathingRate,");
            builder.Append("ColourFace=@ColourFace,");
            builder.Append("ColourFaceOther=@ColourFaceOther,");
            builder.Append("Jaundice=@Jaundice,");
            builder.Append("BregmaLeft=@BregmaLeft,");
            builder.Append("BregmaRight=@BregmaRight,");
            builder.Append("Bregma=@Bregma,");
            builder.Append("BregmaOther=@BregmaOther,");
            builder.Append("EyeAppearance=@EyeAppearance,");
            builder.Append("EyeAppearanceEx=@EyeAppearanceEx,");
            builder.Append("LimbsActivity=@LimbsActivity,");
            builder.Append("LimbsActivityEx=@LimbsActivityEx,");
            builder.Append("EarAppearance=@EarAppearance,");
            builder.Append("EarAppearanceEx=@EarAppearanceEx,");
            builder.Append("NeckMass=@NeckMass,");
            builder.Append("NeckMassHave=@NeckMassHave,");
            builder.Append("Nose=@Nose,");
            builder.Append("NoseEx=@NoseEx,");
            builder.Append("Skin=@Skin,");
            builder.Append("SkinOther=@SkinOther,");
            builder.Append("MouthCavity=@MouthCavity,");
            builder.Append("MouthCavityEx=@MouthCavityEx,");
            builder.Append("Anus=@Anus,");
            builder.Append("AnusEx=@AnusEx,");
            builder.Append("HeartLungAuscul=@HeartLungAuscul,");
            builder.Append("HeartLungAusculEx=@HeartLungAusculEx,");
            builder.Append("Aedea=@Aedea,");
            builder.Append("AedeaEx=@AedeaEx,");
            builder.Append("AbdominalTouch=@AbdominalTouch,");
            builder.Append("AbdominalTouchEx=@AbdominalTouchEx,");
            builder.Append("Spine=@Spine,");
            builder.Append("SpineEx=@SpineEx,");
            builder.Append("UmbilicalCord=@UmbilicalCord,");
            builder.Append("UmbilicalCordOther=@UmbilicalCordOther,");
            builder.Append("ReferralAdvice=@ReferralAdvice,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("AgenciesDepartments=@AgenciesDepartments,");
            builder.Append("Guidance=@Guidance,");
            builder.Append("InterviewDate=@InterviewDate,");
            builder.Append("NextFollowupPlace=@NextFollowupPlace,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("FollowUpDoctorSign=@FollowUpDoctorSign,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("Apgar1=@Apgar1,");
            builder.Append("Apgar5=@Apgar5, ");
            builder.Append("FatherID=@FatherID, ");
            builder.Append("MotherID=@MotherID, ");
            builder.Append("Chest=@Chest, ");
            builder.Append("ChestEx=@ChestEx, ");
            builder.Append("GuidanceOther=@GuidanceOther, ");
            builder.Append("ReferralOrgan=@ReferralOrgan, ");
            builder.Append("ReferraContacts=@ReferraContacts, ");
            builder.Append("ReferralContactsTel=@ReferralContactsTel, ");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Sex", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date),
                new MySqlParameter("@HomeAddr", MySqlDbType.String, 200),
                new MySqlParameter("@FatherName", MySqlDbType.String, 30),
                new MySqlParameter("@FatherJob", MySqlDbType.String, 50), 
                new MySqlParameter("@FatherTel", MySqlDbType.String, 15), 
                new MySqlParameter("@FatherBirthday", MySqlDbType.Date), 
                new MySqlParameter("@MotherName", MySqlDbType.String, 30),
                new MySqlParameter("@MotherJob", MySqlDbType.String, 50), 
                new MySqlParameter("@MotherTel", MySqlDbType.String, 15), 
                new MySqlParameter("@MotherBirthday", MySqlDbType.Date), 
                new MySqlParameter("@GestationalWeek", MySqlDbType.Decimal),
                new MySqlParameter("@PregnancPreva", MySqlDbType.String, 1), 
                new MySqlParameter("@PregnancPrevaOther", MySqlDbType.String, 100),
                new MySqlParameter("@MidwifOrganizaName", MySqlDbType.String, 50), 
                new MySqlParameter("@BirthInforma", MySqlDbType.String, 30), 
                new MySqlParameter("@BirthInformaOther", MySqlDbType.String, 100),
                new MySqlParameter("@Aasphyxia", MySqlDbType.String, 1), 
                new MySqlParameter("@Apgar", MySqlDbType.String, 1), 
                new MySqlParameter("@WhetherAbnorma", MySqlDbType.String, 1), 
                new MySqlParameter("@WhetherAbnormaHave", MySqlDbType.String, 100), 
                new MySqlParameter("@HearingScreen", MySqlDbType.String, 1), 
                new MySqlParameter("@DiseaseScreen", MySqlDbType.String, 100),
                new MySqlParameter("@DiseaseScreenOther", MySqlDbType.String, 100),
                new MySqlParameter("@BirthWeight", MySqlDbType.Decimal), 
                new MySqlParameter("@PresentWeight", MySqlDbType.Decimal), 
                new MySqlParameter("@BirthStature", MySqlDbType.Decimal), 
                new MySqlParameter("@FeedingPattern", MySqlDbType.String, 1),
                new MySqlParameter("@NursingQuantity", MySqlDbType.Decimal), 
                new MySqlParameter("@InfantFrequen", MySqlDbType.Decimal),
                new MySqlParameter("@Vomit", MySqlDbType.String, 1), 
                new MySqlParameter("@Stool", MySqlDbType.String, 1), 
                new MySqlParameter("@StoolFrequen", MySqlDbType.Decimal), 
                new MySqlParameter("@Temperature", MySqlDbType.Decimal), 
                new MySqlParameter("@PulseRate", MySqlDbType.Decimal), 
                new MySqlParameter("@BreathingRate", MySqlDbType.Decimal), 
                new MySqlParameter("@ColourFace", MySqlDbType.String, 100), 
                new MySqlParameter("@ColourFaceOther", MySqlDbType.String, 100),
                new MySqlParameter("@Jaundice", MySqlDbType.String, 1), 
                new MySqlParameter("@BregmaLeft", MySqlDbType.Decimal),
                new MySqlParameter("@BregmaRight", MySqlDbType.Decimal), 
                new MySqlParameter("@Bregma", MySqlDbType.String, 1), 
                new MySqlParameter("@BregmaOther", MySqlDbType.String, 100),
                new MySqlParameter("@EyeAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeAppearanceEx", MySqlDbType.String, 100), 
                new MySqlParameter("@LimbsActivity", MySqlDbType.String, 1), 
                new MySqlParameter("@LimbsActivityEx", MySqlDbType.String, 100),
                new MySqlParameter("@EarAppearance", MySqlDbType.String, 1), 
                new MySqlParameter("@EarAppearanceEx", MySqlDbType.String, 100),
                new MySqlParameter("@NeckMass", MySqlDbType.String, 1), 
                new MySqlParameter("@NeckMassHave", MySqlDbType.String, 100),
                new MySqlParameter("@Nose", MySqlDbType.String, 1),
                new MySqlParameter("@NoseEx", MySqlDbType.String, 100),
                new MySqlParameter("@Skin", MySqlDbType.String, 100), 
                new MySqlParameter("@SkinOther", MySqlDbType.String, 100), 
                new MySqlParameter("@MouthCavity", MySqlDbType.String, 1), 
                new MySqlParameter("@MouthCavityEx", MySqlDbType.String, 100),
                new MySqlParameter("@Anus", MySqlDbType.String, 1), 
                new MySqlParameter("@AnusEx", MySqlDbType.String, 100), 
                new MySqlParameter("@HeartLungAuscul", MySqlDbType.String, 1),
                new MySqlParameter("@HeartLungAusculEx", MySqlDbType.String, 100), 
                new MySqlParameter("@Aedea", MySqlDbType.String, 100), 
                new MySqlParameter("@AedeaEx", MySqlDbType.String, 100),
                new MySqlParameter("@AbdominalTouch", MySqlDbType.String, 1),
                new MySqlParameter("@AbdominalTouchEx", MySqlDbType.String, 100),
                new MySqlParameter("@Spine", MySqlDbType.String, 1), 
                new MySqlParameter("@SpineEx", MySqlDbType.String, 100), 
                new MySqlParameter("@UmbilicalCord", MySqlDbType.String, 1), 
                new MySqlParameter("@UmbilicalCordOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralAdvice", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@AgenciesDepartments", MySqlDbType.String, 80), 
                new MySqlParameter("@Guidance", MySqlDbType.String, 20), 
                new MySqlParameter("@InterviewDate", MySqlDbType.Date), 
                new MySqlParameter("@NextFollowupPlace", MySqlDbType.String, 100),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctorSign", MySqlDbType.String, 30), 
                new MySqlParameter("@CreatedBy", MySqlDbType.String), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8),
                new MySqlParameter("@Apgar1", MySqlDbType.Decimal), 
                new MySqlParameter("@Apgar5", MySqlDbType.Decimal),
                new MySqlParameter("@FatherID", MySqlDbType.String, 21),
                new MySqlParameter("@MotherID", MySqlDbType.String, 21),
                new MySqlParameter("@Chest", MySqlDbType.String, 1),
                new MySqlParameter("@ChestEx", MySqlDbType.String, 100),
                new MySqlParameter("@GuidanceOther", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralOrgan",MySqlDbType.String,100),
                new MySqlParameter("@ReferraContacts",MySqlDbType.String,50),
                new MySqlParameter("@ReferralContactsTel",MySqlDbType.String,50),
                new MySqlParameter("@ReferralResult",MySqlDbType.String,1)
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Sex;
            cmdParms[4].Value = model.Birthday;
            cmdParms[5].Value = model.HomeAddr;
            cmdParms[6].Value = model.FatherName;
            cmdParms[7].Value = model.FatherJob;
            cmdParms[8].Value = model.FatherTel;
            cmdParms[9].Value = model.FatherBirthday;
            cmdParms[10].Value = model.MotherName;
            cmdParms[11].Value = model.MotherJob;
            cmdParms[12].Value = model.MotherTel;
            cmdParms[13].Value = model.MotherBirthday;
            cmdParms[14].Value = model.GestationalWeek;
            cmdParms[15].Value = model.PregnancPreva;
            cmdParms[16].Value = model.PregnancPrevaOther;
            cmdParms[17].Value = model.MidwifOrganizaName;
            cmdParms[18].Value = model.BirthInforma;
            cmdParms[19].Value = model.BirthInformaOther;
            cmdParms[20].Value = model.Aasphyxia;
            cmdParms[21].Value = model.Apgar;
            cmdParms[22].Value = model.WhetherAbnorma;
            cmdParms[23].Value = model.WhetherAbnormaHave;
            cmdParms[24].Value = model.HearingScreen;
            cmdParms[25].Value = model.DiseaseScreen;
            cmdParms[26].Value = model.DiseaseScreenOther;
            cmdParms[27].Value = model.BirthWeight;
            cmdParms[28].Value = model.PresentWeight;
            cmdParms[29].Value = model.BirthStature;
            cmdParms[30].Value = model.FeedingPattern;
            cmdParms[31].Value = model.NursingQuantity;
            cmdParms[32].Value = model.InfantFrequen;
            cmdParms[33].Value = model.Vomit;
            cmdParms[34].Value = model.Stool;
            cmdParms[35].Value = model.StoolFrequen;
            cmdParms[36].Value = model.Temperature;
            cmdParms[37].Value = model.PulseRate;
            cmdParms[38].Value = model.BreathingRate;
            cmdParms[39].Value = model.ColourFace;
            cmdParms[40].Value = model.ColourFaceOther;
            cmdParms[41].Value = model.Jaundice;
            cmdParms[42].Value = model.BregmaLeft;
            cmdParms[43].Value = model.BregmaRight;
            cmdParms[44].Value = model.Bregma;
            cmdParms[45].Value = model.BregmaOther;
            cmdParms[46].Value = model.EyeAppearance;
            cmdParms[47].Value = model.EyeAppearanceEx;
            cmdParms[48].Value = model.LimbsActivity;
            cmdParms[49].Value = model.LimbsActivityEx;
            cmdParms[50].Value = model.EarAppearance;
            cmdParms[51].Value = model.EarAppearanceEx;
            cmdParms[52].Value = model.NeckMass;
            cmdParms[53].Value = model.NeckMassHave;
            cmdParms[54].Value = model.Nose;
            cmdParms[55].Value = model.NoseEx;
            cmdParms[56].Value = model.Skin;
            cmdParms[57].Value = model.SkinOther;
            cmdParms[58].Value = model.MouthCavity;
            cmdParms[59].Value = model.MouthCavityEx;
            cmdParms[60].Value = model.Anus;
            cmdParms[61].Value = model.AnusEx;
            cmdParms[62].Value = model.HeartLungAuscul;
            cmdParms[63].Value = model.HeartLungAusculEx;
            cmdParms[64].Value = model.Aedea;
            cmdParms[65].Value = model.AedeaEx;
            cmdParms[66].Value = model.AbdominalTouch;
            cmdParms[67].Value = model.AbdominalTouchEx;
            cmdParms[68].Value = model.Spine;
            cmdParms[69].Value = model.SpineEx;
            cmdParms[70].Value = model.UmbilicalCord;
            cmdParms[71].Value = model.UmbilicalCordOther;
            cmdParms[72].Value = model.ReferralAdvice;
            cmdParms[73].Value = model.ReferralReason;
            cmdParms[74].Value = model.AgenciesDepartments;
            cmdParms[75].Value = model.Guidance;
            cmdParms[76].Value = model.InterviewDate;
            cmdParms[77].Value = model.NextFollowupPlace;
            cmdParms[78].Value = model.NextFollowupDate;
            cmdParms[79].Value = model.FollowUpDoctorSign;
            cmdParms[80].Value = model.CreatedBy;
            cmdParms[81].Value = model.CreatedDate;
            cmdParms[82].Value = model.LastUpdateBy;
            cmdParms[83].Value = model.LastUpdateDate;
            cmdParms[84].Value = model.IsDel;
            cmdParms[85].Value = model.Apgar1;
            cmdParms[86].Value = model.Apgar5;
            cmdParms[87].Value = model.FatherID;
            cmdParms[88].Value = model.MotherID;
            cmdParms[89].Value = model.Chest;
            cmdParms[90].Value = model.ChestEx;
            cmdParms[91].Value = model.GuidanceOther;
            cmdParms[92].Value = model.ReferralOrgan;
            cmdParms[93].Value = model.ReferraContacts;
            cmdParms[94].Value = model.ReferralContactsTel;
            cmdParms[95].Value = model.ReferralResult;
            //cmdParms[85].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

