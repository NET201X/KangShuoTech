namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class WomenGravidaFirstVisitDAL
    {
        public int Add(WomenGravidaFirstVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_womengravidafirstvisit(");
            builder.Append("CustomerID,RecordID,IDCardNo,RecordDate,PregancyWeeks,CustomerAge,HusbandName,HusbandAge,HusbandPhone,PregancyCount,NatrualChildBirthCount,CaeSareanCount,LastMenStruation,LastMenStruationDate,ExpectedDueDate,CustomerHistory,CustomerHistoryEx,FamilyHistory,FamilyHistoryEx,PersonalHistory,PersonalHistoryEx,GyNecoloGyHistory,AbortionInfo,Deadfetus,StillBirthInfo,NewBornDead,NewBornDefect,Height,Weight,Bmi,HBloodpressure,LBloodpressure,Heart,Heartex,Lung,Lungex,Vulva,VulvaEx,Vagina,VaginaEx,CervixuTeri,CervixuTeriex,Corpus,CorpusEx,Attach,AttachEx,OverAlassessMent,HealthZhiDao,HealthZhiDaoOthers,Referral,ReferralReason,ReferralOrg,NextfollowupDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,GynecologyHistoryEx,OverAlassessmentEx,");
            builder.Append("ArtificialAbortion,BooksInfo,BooksInstitution,ReferralContacts,ReferralContactsTel,ReferralResult)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@RecordDate,@PregancyWeeks,@CustomerAge,@HusbandName,@HusbandAge,@HusbandPhone,@PregancyCount,@NatrualChildBirthCount,@CaeSareanCount,@LastMenStruation,@LastMenStruationDate,@ExpectedDueDate,@CustomerHistory,@CustomerHistoryEx,@FamilyHistory,@FamilyHistoryEx,@PersonalHistory,@PersonalHistoryEx,@GyNecoloGyHistory,@AbortionInfo,@Deadfetus,@StillBirthInfo,@NewBornDead,@NewBornDefect,@Height,@Weight,@Bmi,@HBloodpressure,@LBloodpressure,@Heart,@Heartex,@Lung,@Lungex,@Vulva,@VulvaEx,@Vagina,@VaginaEx,@CervixuTeri,@CervixuTeriex,@Corpus,@CorpusEx,@Attach,@AttachEx,@OverAlassessMent,@HealthZhiDao,@HealthZhiDaoOthers,@Referral,@ReferralReason,@ReferralOrg,@NextfollowupDate,@FollowUpDoctor,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@GynecologyHistoryEx,@OverAlassessmentEx,");
            builder.Append("@ArtificialAbortion,@BooksInfo,@BooksInstitution,@ReferralContacts,@ReferralContactsTel,@ReferralResult)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 80), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@RecordDate", MySqlDbType.Date), 
                new MySqlParameter("@PregancyWeeks", MySqlDbType.Int32),
                new MySqlParameter("@CustomerAge", MySqlDbType.Int32), 
                new MySqlParameter("@HusbandName", MySqlDbType.String, 30), 
                new MySqlParameter("@HusbandAge", MySqlDbType.Int32), 
                new MySqlParameter("@HusbandPhone", MySqlDbType.String, 15), 
                new MySqlParameter("@PregancyCount", MySqlDbType.Int32), 
                new MySqlParameter("@NatrualChildBirthCount", MySqlDbType.Int32), 
                new MySqlParameter("@CaeSareanCount", MySqlDbType.Int32), 
                new MySqlParameter("@LastMenStruation", MySqlDbType.String, 1), 
                new MySqlParameter("@LastMenStruationDate", MySqlDbType.Date), 
                new MySqlParameter("@ExpectedDueDate", MySqlDbType.Date), 
                new MySqlParameter("@CustomerHistory", MySqlDbType.String, 30), 
                new MySqlParameter("@CustomerHistoryEx", MySqlDbType.String, 100), 
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@FamilyHistoryEx", MySqlDbType.String, 100),
                new MySqlParameter("@PersonalHistory", MySqlDbType.String, 32), 
                new MySqlParameter("@PersonalHistoryEx", MySqlDbType.String, 100),
                new MySqlParameter("@GyNecoloGyHistory", MySqlDbType.String, 1),
                new MySqlParameter("@AbortionInfo", MySqlDbType.String, 200),
                new MySqlParameter("@Deadfetus", MySqlDbType.String, 200), 
                new MySqlParameter("@StillBirthInfo", MySqlDbType.String, 200),
                new MySqlParameter("@NewBornDead", MySqlDbType.String, 200), 
                new MySqlParameter("@NewBornDefect", MySqlDbType.String, 200),
                new MySqlParameter("@Height", MySqlDbType.Decimal), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@Bmi", MySqlDbType.Decimal), 
                new MySqlParameter("@HBloodpressure", MySqlDbType.Int32), 
                new MySqlParameter("@LBloodpressure", MySqlDbType.Int32), 
                new MySqlParameter("@Heart", MySqlDbType.String, 1),
                new MySqlParameter("@Heartex", MySqlDbType.String, 100),
                new MySqlParameter("@Lung", MySqlDbType.String, 1),
                new MySqlParameter("@Lungex", MySqlDbType.String, 100), 
                new MySqlParameter("@Vulva", MySqlDbType.String, 1), 
                new MySqlParameter("@VulvaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Vagina", MySqlDbType.String, 1), 
                new MySqlParameter("@VaginaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@CervixuTeri", MySqlDbType.String, 1), 
                new MySqlParameter("@CervixuTeriex", MySqlDbType.String, 200),
                new MySqlParameter("@Corpus", MySqlDbType.String, 1), 
                new MySqlParameter("@CorpusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Attach", MySqlDbType.String, 1), 
                new MySqlParameter("@AttachEx", MySqlDbType.String, 200), 
                new MySqlParameter("@OverAlassessMent", MySqlDbType.String, 1), 
                new MySqlParameter("@HealthZhiDao", MySqlDbType.String, 30), 
                new MySqlParameter("@HealthZhiDaoOthers", MySqlDbType.String, 200),
                new MySqlParameter("@Referral", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextfollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@GynecologyHistoryEx", MySqlDbType.String, 200), 
                new MySqlParameter("@OverAlassessmentEx", MySqlDbType.String, 200),
                new MySqlParameter("@ArtificialAbortion", MySqlDbType.String, 100),
           
                new MySqlParameter("@BooksInfo", MySqlDbType.String, 1),
                new MySqlParameter("@BooksInstitution", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.RecordDate;
            cmdParms[4].Value = model.PregancyWeeks;
            cmdParms[5].Value = model.CustomerAge;
            cmdParms[6].Value = model.HusbandName;
            cmdParms[7].Value = model.HusbandAge;
            cmdParms[8].Value = model.HusbandPhone;
            cmdParms[9].Value = model.PregancyCount;
            cmdParms[10].Value = model.NatrualChildBirthCount;
            cmdParms[11].Value = model.CaeSareanCount;
            cmdParms[12].Value = model.LastMenStruation;
            cmdParms[13].Value = model.LastMenStruationDate;
            cmdParms[14].Value = model.ExpectedDueDate;
            cmdParms[15].Value = model.CustomerHistory;
            cmdParms[16].Value = model.CustomerHistoryEx;
            cmdParms[17].Value = model.FamilyHistory;
            cmdParms[18].Value = model.FamilyHistoryEx;
            cmdParms[19].Value = model.PersonalHistory;
            cmdParms[20].Value = model.PersonalHistoryEx;
            cmdParms[21].Value = model.GyNecoloGyHistory;
            cmdParms[22].Value = model.AbortionInfo;
            cmdParms[23].Value = model.Deadfetus;
            cmdParms[24].Value = model.StillBirthInfo;
            cmdParms[25].Value = model.NewBornDead;
            cmdParms[26].Value = model.NewBornDefect;
            cmdParms[27].Value = model.Height;
            cmdParms[28].Value = model.Weight;
            cmdParms[29].Value = model.Bmi;
            cmdParms[30].Value = model.HBloodpressure;
            cmdParms[31].Value = model.LBloodpressure;
            cmdParms[32].Value = model.Heart;
            cmdParms[33].Value = model.Heartex;
            cmdParms[34].Value = model.Lung;
            cmdParms[35].Value = model.Lungex;
            cmdParms[36].Value = model.Vulva;
            cmdParms[37].Value = model.VulvaEx;
            cmdParms[38].Value = model.Vagina;
            cmdParms[39].Value = model.VaginaEx;
            cmdParms[40].Value = model.CervixuTeri;
            cmdParms[41].Value = model.CervixuTeriex;
            cmdParms[42].Value = model.Corpus;
            cmdParms[43].Value = model.CorpusEx;
            cmdParms[44].Value = model.Attach;
            cmdParms[45].Value = model.AttachEx;
            cmdParms[46].Value = model.OverAlassessMent;
            cmdParms[47].Value = model.HealthZhiDao;
            cmdParms[49].Value = model.HealthZhiDaoOthers;
            cmdParms[50].Value = model.Referral;
            cmdParms[50].Value = model.ReferralReason;
            cmdParms[51].Value = model.ReferralOrg;
            cmdParms[52].Value = model.NextfollowupDate;
            cmdParms[53].Value = model.FollowUpDoctor;
            cmdParms[54].Value = model.CreatedBy;
            cmdParms[55].Value = model.CreatedDate;
            cmdParms[56].Value = model.LastUpdateBy;
            cmdParms[57].Value = model.LastUpdateDate;
            cmdParms[58].Value = model.IsDel;
            cmdParms[59].Value = model.GynecologyHistoryEx;
            cmdParms[60].Value = model.OverAlassessmentEx;
            cmdParms[61].Value = model.ArtificialAbortion;
            cmdParms[62].Value = model.BooksInfo;
            cmdParms[63].Value = model.BooksInstitution;
            cmdParms[64].Value = model.ReferralContacts;
            cmdParms[65].Value = model.ReferralContactsTel;
            cmdParms[66].Value = model.ReferralResult;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(WomenGravidaFirstVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_womengravidafirstvisit(");
            builder.Append("CustomerID,RecordID,IDCardNo,RecordDate,PregancyWeeks,CustomerAge,HusbandName,HusbandAge,HusbandPhone,PregancyCount,NatrualChildBirthCount,CaeSareanCount,LastMenStruation,LastMenStruationDate,ExpectedDueDate,CustomerHistory,CustomerHistoryEx,FamilyHistory,FamilyHistoryEx,PersonalHistory,PersonalHistoryEx,GyNecoloGyHistory,AbortionInfo,Deadfetus,StillBirthInfo,NewBornDead,NewBornDefect,Height,Weight,Bmi,HBloodpressure,LBloodpressure,Heart,Heartex,Lung,Lungex,Vulva,VulvaEx,Vagina,VaginaEx,CervixuTeri,CervixuTeriex,Corpus,CorpusEx,Attach,AttachEx,OverAlassessMent,HealthZhiDao,HealthZhiDaoOthers,Referral,ReferralReason,ReferralOrg,NextfollowupDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,GynecologyHistoryEx,OverAlassessmentEx,");
            builder.Append("ArtificialAbortion,BooksInfo,BooksInstitution,ReferralContacts,ReferralContactsTel,ReferralResult)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@RecordDate,@PregancyWeeks,@CustomerAge,@HusbandName,@HusbandAge,@HusbandPhone,@PregancyCount,@NatrualChildBirthCount,@CaeSareanCount,@LastMenStruation,@LastMenStruationDate,@ExpectedDueDate,@CustomerHistory,@CustomerHistoryEx,@FamilyHistory,@FamilyHistoryEx,@PersonalHistory,@PersonalHistoryEx,@GyNecoloGyHistory,@AbortionInfo,@Deadfetus,@StillBirthInfo,@NewBornDead,@NewBornDefect,@Height,@Weight,@Bmi,@HBloodpressure,@LBloodpressure,@Heart,@Heartex,@Lung,@Lungex,@Vulva,@VulvaEx,@Vagina,@VaginaEx,@CervixuTeri,@CervixuTeriex,@Corpus,@CorpusEx,@Attach,@AttachEx,@OverAlassessMent,@HealthZhiDao,@HealthZhiDaoOthers,@Referral,@ReferralReason,@ReferralOrg,@NextfollowupDate,@FollowUpDoctor,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@GynecologyHistoryEx,@OverAlassessmentEx,");
            builder.Append("@ArtificialAbortion,@BooksInfo,@BooksInstitution,@ReferralContacts,@ReferralContactsTel,@ReferralResult)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 80), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@RecordDate", MySqlDbType.Date), 
                new MySqlParameter("@PregancyWeeks", MySqlDbType.Int32),
                new MySqlParameter("@CustomerAge", MySqlDbType.Int32), 
                new MySqlParameter("@HusbandName", MySqlDbType.String, 30), 
                new MySqlParameter("@HusbandAge", MySqlDbType.Int32), 
                new MySqlParameter("@HusbandPhone", MySqlDbType.String, 15), 
                new MySqlParameter("@PregancyCount", MySqlDbType.Int32), 
                new MySqlParameter("@NatrualChildBirthCount", MySqlDbType.Int32), 
                new MySqlParameter("@CaeSareanCount", MySqlDbType.Int32), 
                new MySqlParameter("@LastMenStruation", MySqlDbType.String, 1), 
                new MySqlParameter("@LastMenStruationDate", MySqlDbType.Date), 
                new MySqlParameter("@ExpectedDueDate", MySqlDbType.Date), 
                new MySqlParameter("@CustomerHistory", MySqlDbType.String, 30), 
                new MySqlParameter("@CustomerHistoryEx", MySqlDbType.String, 100), 
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@FamilyHistoryEx", MySqlDbType.String, 100),
                new MySqlParameter("@PersonalHistory", MySqlDbType.String, 32), 
                new MySqlParameter("@PersonalHistoryEx", MySqlDbType.String, 100),
                new MySqlParameter("@GyNecoloGyHistory", MySqlDbType.String, 1),
                new MySqlParameter("@AbortionInfo", MySqlDbType.String, 200),
                new MySqlParameter("@Deadfetus", MySqlDbType.String, 200), 
                new MySqlParameter("@StillBirthInfo", MySqlDbType.String, 200),
                new MySqlParameter("@NewBornDead", MySqlDbType.String, 200), 
                new MySqlParameter("@NewBornDefect", MySqlDbType.String, 200),
                new MySqlParameter("@Height", MySqlDbType.Decimal), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@Bmi", MySqlDbType.Decimal), 
                new MySqlParameter("@HBloodpressure", MySqlDbType.Int32), 
                new MySqlParameter("@LBloodpressure", MySqlDbType.Int32), 
                new MySqlParameter("@Heart", MySqlDbType.String, 1),
                new MySqlParameter("@Heartex", MySqlDbType.String, 100),
                new MySqlParameter("@Lung", MySqlDbType.String, 1),
                new MySqlParameter("@Lungex", MySqlDbType.String, 100), 
                new MySqlParameter("@Vulva", MySqlDbType.String, 1), 
                new MySqlParameter("@VulvaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Vagina", MySqlDbType.String, 1), 
                new MySqlParameter("@VaginaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@CervixuTeri", MySqlDbType.String, 1), 
                new MySqlParameter("@CervixuTeriex", MySqlDbType.String, 200),
                new MySqlParameter("@Corpus", MySqlDbType.String, 1), 
                new MySqlParameter("@CorpusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Attach", MySqlDbType.String, 1), 
                new MySqlParameter("@AttachEx", MySqlDbType.String, 200), 
                new MySqlParameter("@OverAlassessMent", MySqlDbType.String, 1), 
                new MySqlParameter("@HealthZhiDao", MySqlDbType.String, 30), 
                new MySqlParameter("@HealthZhiDaoOthers", MySqlDbType.String, 200),
                new MySqlParameter("@Referral", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextfollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@GynecologyHistoryEx", MySqlDbType.String, 200), 
                new MySqlParameter("@OverAlassessmentEx", MySqlDbType.String, 200),
                new MySqlParameter("@ArtificialAbortion", MySqlDbType.String, 100),
           
                new MySqlParameter("@BooksInfo", MySqlDbType.String, 1),
                new MySqlParameter("@BooksInstitution", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.RecordDate;
            cmdParms[4].Value = model.PregancyWeeks;
            cmdParms[5].Value = model.CustomerAge;
            cmdParms[6].Value = model.HusbandName;
            cmdParms[7].Value = model.HusbandAge;
            cmdParms[8].Value = model.HusbandPhone;
            cmdParms[9].Value = model.PregancyCount;
            cmdParms[10].Value = model.NatrualChildBirthCount;
            cmdParms[11].Value = model.CaeSareanCount;
            cmdParms[12].Value = model.LastMenStruation;
            cmdParms[13].Value = model.LastMenStruationDate;
            cmdParms[14].Value = model.ExpectedDueDate;
            cmdParms[15].Value = model.CustomerHistory;
            cmdParms[16].Value = model.CustomerHistoryEx;
            cmdParms[17].Value = model.FamilyHistory;
            cmdParms[18].Value = model.FamilyHistoryEx;
            cmdParms[19].Value = model.PersonalHistory;
            cmdParms[20].Value = model.PersonalHistoryEx;
            cmdParms[21].Value = model.GyNecoloGyHistory;
            cmdParms[22].Value = model.AbortionInfo;
            cmdParms[23].Value = model.Deadfetus;
            cmdParms[24].Value = model.StillBirthInfo;
            cmdParms[25].Value = model.NewBornDead;
            cmdParms[26].Value = model.NewBornDefect;
            cmdParms[27].Value = model.Height;
            cmdParms[28].Value = model.Weight;
            cmdParms[29].Value = model.Bmi;
            cmdParms[30].Value = model.HBloodpressure;
            cmdParms[31].Value = model.LBloodpressure;
            cmdParms[32].Value = model.Heart;
            cmdParms[33].Value = model.Heartex;
            cmdParms[34].Value = model.Lung;
            cmdParms[35].Value = model.Lungex;
            cmdParms[36].Value = model.Vulva;
            cmdParms[37].Value = model.VulvaEx;
            cmdParms[38].Value = model.Vagina;
            cmdParms[39].Value = model.VaginaEx;
            cmdParms[40].Value = model.CervixuTeri;
            cmdParms[41].Value = model.CervixuTeriex;
            cmdParms[42].Value = model.Corpus;
            cmdParms[43].Value = model.CorpusEx;
            cmdParms[44].Value = model.Attach;
            cmdParms[45].Value = model.AttachEx;
            cmdParms[46].Value = model.OverAlassessMent;
            cmdParms[47].Value = model.HealthZhiDao;
            cmdParms[49].Value = model.HealthZhiDaoOthers;
            cmdParms[50].Value = model.Referral;
            cmdParms[50].Value = model.ReferralReason;
            cmdParms[51].Value = model.ReferralOrg;
            cmdParms[52].Value = model.NextfollowupDate;
            cmdParms[53].Value = model.FollowUpDoctor;
            cmdParms[54].Value = model.CreatedBy;
            cmdParms[55].Value = model.CreatedDate;
            cmdParms[56].Value = model.LastUpdateBy;
            cmdParms[57].Value = model.LastUpdateDate;
            cmdParms[58].Value = model.IsDel;
            cmdParms[59].Value = model.GynecologyHistoryEx;
            cmdParms[60].Value = model.OverAlassessmentEx;
            cmdParms[61].Value = model.ArtificialAbortion;
            cmdParms[62].Value = model.BooksInfo;
            cmdParms[63].Value = model.BooksInstitution;
            cmdParms[64].Value = model.ReferralContacts;
            cmdParms[65].Value = model.ReferralContactsTel;
            cmdParms[66].Value = model.ReferralResult;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public WomenGravidaFirstVisitModel DataRowToModel(DataRow row)
        {
            WomenGravidaFirstVisitModel gravida_firstfollowup = new WomenGravidaFirstVisitModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    gravida_firstfollowup.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    gravida_firstfollowup.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    gravida_firstfollowup.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    gravida_firstfollowup.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["RecordDate"] != null) && (row["RecordDate"] != DBNull.Value)) && (row["RecordDate"].ToString() != ""))
                {
                    gravida_firstfollowup.RecordDate = new DateTime?(DateTime.Parse(row["RecordDate"].ToString()));
                }
                if (((row["PregancyWeeks"] != null) && (row["PregancyWeeks"] != DBNull.Value)) && (row["PregancyWeeks"].ToString() != ""))
                {
                    gravida_firstfollowup.PregancyWeeks = new int?(int.Parse(row["PregancyWeeks"].ToString()));
                }
                if (((row["CustomerAge"] != null) && (row["CustomerAge"] != DBNull.Value)) && (row["CustomerAge"].ToString() != ""))
                {
                    gravida_firstfollowup.CustomerAge = new int?(int.Parse(row["CustomerAge"].ToString()));
                }
                if ((row["HusbandName"] != null) && (row["HusbandName"] != DBNull.Value))
                {
                    gravida_firstfollowup.HusbandName = row["HusbandName"].ToString();
                }
                if (((row["HusbandAge"] != null) && (row["HusbandAge"] != DBNull.Value)) && (row["HusbandAge"].ToString() != ""))
                {
                    gravida_firstfollowup.HusbandAge = new int?(int.Parse(row["HusbandAge"].ToString()));
                }
                if ((row["HusbandPhone"] != null) && (row["HusbandPhone"] != DBNull.Value))
                {
                    gravida_firstfollowup.HusbandPhone = row["HusbandPhone"].ToString();
                }
                if (((row["PregancyCount"] != null) && (row["PregancyCount"] != DBNull.Value)) && (row["PregancyCount"].ToString() != ""))
                {
                    gravida_firstfollowup.PregancyCount = new int?(int.Parse(row["PregancyCount"].ToString()));
                }
                if (((row["NatrualChildBirthCount"] != null) && (row["NatrualChildBirthCount"] != DBNull.Value)) && (row["NatrualChildBirthCount"].ToString() != ""))
                {
                    gravida_firstfollowup.NatrualChildBirthCount = new int?(int.Parse(row["NatrualChildBirthCount"].ToString()));
                }
                if (((row["CaeSareanCount"] != null) && (row["CaeSareanCount"] != DBNull.Value)) && (row["CaeSareanCount"].ToString() != ""))
                {
                    gravida_firstfollowup.CaeSareanCount = new int?(int.Parse(row["CaeSareanCount"].ToString()));
                }
                if ((row["LastMenStruation"] != null) && (row["LastMenStruation"] != DBNull.Value))
                {
                    gravida_firstfollowup.LastMenStruation = row["LastMenStruation"].ToString();
                }
                if (((row["LastMenStruationDate"] != null) && (row["LastMenStruationDate"] != DBNull.Value)) && (row["LastMenStruationDate"].ToString() != ""))
                {
                    gravida_firstfollowup.LastMenStruationDate = new DateTime?(DateTime.Parse(row["LastMenStruationDate"].ToString()));
                }
                if (((row["ExpectedDueDate"] != null) && (row["ExpectedDueDate"] != DBNull.Value)) && (row["ExpectedDueDate"].ToString() != ""))
                {
                    gravida_firstfollowup.ExpectedDueDate = new DateTime?(DateTime.Parse(row["ExpectedDueDate"].ToString()));
                }
                if ((row["CustomerHistory"] != null) && (row["CustomerHistory"] != DBNull.Value))
                {
                    gravida_firstfollowup.CustomerHistory = row["CustomerHistory"].ToString();
                }
                if ((row["CustomerHistoryEx"] != null) && (row["CustomerHistoryEx"] != DBNull.Value))
                {
                    gravida_firstfollowup.CustomerHistoryEx = row["CustomerHistoryEx"].ToString();
                }
                if ((row["FamilyHistory"] != null) && (row["FamilyHistory"] != DBNull.Value))
                {
                    gravida_firstfollowup.FamilyHistory = row["FamilyHistory"].ToString();
                }
                if ((row["FamilyHistoryEx"] != null) && (row["FamilyHistoryEx"] != DBNull.Value))
                {
                    gravida_firstfollowup.FamilyHistoryEx = row["FamilyHistoryEx"].ToString();
                }
                if ((row["PersonalHistory"] != null) && (row["PersonalHistory"] != DBNull.Value))
                {
                    gravida_firstfollowup.PersonalHistory = row["PersonalHistory"].ToString();
                }
                if ((row["PersonalHistoryEx"] != null) && (row["PersonalHistoryEx"] != DBNull.Value))
                {
                    gravida_firstfollowup.PersonalHistoryEx = row["PersonalHistoryEx"].ToString();
                }
                if ((row["GyNecoloGyHistory"] != null) && (row["GyNecoloGyHistory"] != DBNull.Value))
                {
                    gravida_firstfollowup.GyNecoloGyHistory = row["GyNecoloGyHistory"].ToString();
                }
                if ((row["AbortionInfo"] != null) && (row["AbortionInfo"] != DBNull.Value))
                {
                    gravida_firstfollowup.AbortionInfo = row["AbortionInfo"].ToString();
                }
                if ((row["Deadfetus"] != null) && (row["Deadfetus"] != DBNull.Value))
                {
                    gravida_firstfollowup.Deadfetus = row["Deadfetus"].ToString();
                }
                if ((row["StillBirthInfo"] != null) && (row["StillBirthInfo"] != DBNull.Value))
                {
                    gravida_firstfollowup.StillBirthInfo = row["StillBirthInfo"].ToString();
                }
                if ((row["NewBornDead"] != null) && (row["NewBornDead"] != DBNull.Value))
                {
                    gravida_firstfollowup.NewBornDead = row["NewBornDead"].ToString();
                }
                if ((row["NewBornDefect"] != null) && (row["NewBornDefect"] != DBNull.Value))
                {
                    gravida_firstfollowup.NewBornDefect = row["NewBornDefect"].ToString();
                }
                if (((row["Height"] != null) && (row["Height"] != DBNull.Value)) && (row["Height"].ToString() != ""))
                {
                    gravida_firstfollowup.Height = new decimal?(decimal.Parse(row["Height"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    gravida_firstfollowup.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if (((row["Bmi"] != null) && (row["Bmi"] != DBNull.Value)) && (row["Bmi"].ToString() != ""))
                {
                    gravida_firstfollowup.Bmi = new decimal?(decimal.Parse(row["Bmi"].ToString()));
                }
                if (((row["HBloodpressure"] != null) && (row["HBloodpressure"] != DBNull.Value)) && (row["HBloodpressure"].ToString() != ""))
                {
                    gravida_firstfollowup.HBloodpressure = new int?(int.Parse(row["HBloodpressure"].ToString()));
                }
                if (((row["LBloodpressure"] != null) && (row["LBloodpressure"] != DBNull.Value)) && (row["LBloodpressure"].ToString() != ""))
                {
                    gravida_firstfollowup.LBloodpressure = new int?(int.Parse(row["LBloodpressure"].ToString()));
                }
                if ((row["Heart"] != null) && (row["Heart"] != DBNull.Value))
                {
                    gravida_firstfollowup.Heart = row["Heart"].ToString();
                }
                if ((row["Heartex"] != null) && (row["Heartex"] != DBNull.Value))
                {
                    gravida_firstfollowup.Heartex = row["Heartex"].ToString();
                }
                if ((row["Lung"] != null) && (row["Lung"] != DBNull.Value))
                {
                    gravida_firstfollowup.Lung = row["Lung"].ToString();
                }
                if ((row["Lungex"] != null) && (row["Lungex"] != DBNull.Value))
                {
                    gravida_firstfollowup.Lungex = row["Lungex"].ToString();
                }
                if ((row["Vulva"] != null) && (row["Vulva"] != DBNull.Value))
                {
                    gravida_firstfollowup.Vulva = row["Vulva"].ToString();
                }
                if ((row["VulvaEx"] != null) && (row["VulvaEx"] != DBNull.Value))
                {
                    gravida_firstfollowup.VulvaEx = row["VulvaEx"].ToString();
                }
                if ((row["Vagina"] != null) && (row["Vagina"] != DBNull.Value))
                {
                    gravida_firstfollowup.Vagina = row["Vagina"].ToString();
                }
                if ((row["VaginaEx"] != null) && (row["VaginaEx"] != DBNull.Value))
                {
                    gravida_firstfollowup.VaginaEx = row["VaginaEx"].ToString();
                }
                if ((row["CervixuTeri"] != null) && (row["CervixuTeri"] != DBNull.Value))
                {
                    gravida_firstfollowup.CervixuTeri = row["CervixuTeri"].ToString();
                }
                if ((row["CervixuTeriex"] != null) && (row["CervixuTeriex"] != DBNull.Value))
                {
                    gravida_firstfollowup.CervixuTeriex = row["CervixuTeriex"].ToString();
                }
                if ((row["Corpus"] != null) && (row["Corpus"] != DBNull.Value))
                {
                    gravida_firstfollowup.Corpus = row["Corpus"].ToString();
                }
                if ((row["CorpusEx"] != null) && (row["CorpusEx"] != DBNull.Value))
                {
                    gravida_firstfollowup.CorpusEx = row["CorpusEx"].ToString();
                }
                if ((row["Attach"] != null) && (row["Attach"] != DBNull.Value))
                {
                    gravida_firstfollowup.Attach = row["Attach"].ToString();
                }
                if ((row["AttachEx"] != null) && (row["AttachEx"] != DBNull.Value))
                {
                    gravida_firstfollowup.AttachEx = row["AttachEx"].ToString();
                }
                if ((row["OverAlassessMent"] != null) && (row["OverAlassessMent"] != DBNull.Value))
                {
                    gravida_firstfollowup.OverAlassessMent = row["OverAlassessMent"].ToString();
                }
                if ((row["HealthZhiDao"] != null) && (row["HealthZhiDao"] != DBNull.Value))
                {
                    gravida_firstfollowup.HealthZhiDao = row["HealthZhiDao"].ToString();
                }
                if ((row["HealthZhiDaoOthers"] != null) && (row["HealthZhiDaoOthers"] != DBNull.Value))
                {
                    gravida_firstfollowup.HealthZhiDaoOthers = row["HealthZhiDaoOthers"].ToString();
                }
                if ((row["Referral"] != null) && (row["Referral"] != DBNull.Value))
                {
                    gravida_firstfollowup.Referral = row["Referral"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    gravida_firstfollowup.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["ReferralOrg"] != null) && (row["ReferralOrg"] != DBNull.Value))
                {
                    gravida_firstfollowup.ReferralOrg = row["ReferralOrg"].ToString();
                }
                if (((row["NextfollowupDate"] != null) && (row["NextfollowupDate"] != DBNull.Value)) && (row["NextfollowupDate"].ToString() != ""))
                {
                    gravida_firstfollowup.NextfollowupDate = new DateTime?(DateTime.Parse(row["NextfollowupDate"].ToString()));
                }
                if ((row["FollowUpDoctor"] != null) && (row["FollowUpDoctor"] != DBNull.Value))
                {
                    gravida_firstfollowup.FollowUpDoctor = row["FollowUpDoctor"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    gravida_firstfollowup.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    gravida_firstfollowup.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    gravida_firstfollowup.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    gravida_firstfollowup.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    gravida_firstfollowup.IsDel = row["IsDel"].ToString();
                }
                if ((row["GynecologyHistoryEx"] != null) && (row["GynecologyHistoryEx"] != DBNull.Value))
                {
                    gravida_firstfollowup.GynecologyHistoryEx = row["GynecologyHistoryEx"].ToString();
                }
                if ((row["OverAlassessmentEx"] != null) && (row["OverAlassessmentEx"] != DBNull.Value))
                {
                    gravida_firstfollowup.OverAlassessmentEx = row["OverAlassessmentEx"].ToString();
                }
                if ((row["ArtificialAbortion"] != null) && (row["ArtificialAbortion"] != DBNull.Value))
                {
                    gravida_firstfollowup.ArtificialAbortion = row["ArtificialAbortion"].ToString();
                }
               
                if ((row["BooksInfo"] != null) && (row["BooksInfo"] != DBNull.Value))
                {
                    gravida_firstfollowup.BooksInfo = row["BooksInfo"].ToString();
                }
                if ((row["BooksInstitution"] != null) && (row["BooksInstitution"] != DBNull.Value))
                {
                    gravida_firstfollowup.BooksInstitution = row["BooksInstitution"].ToString();
                }
                if ((row["ReferralContacts"] != null) && (row["ReferralContacts"] != DBNull.Value))
                {
                    gravida_firstfollowup.ReferralContacts = row["ReferralContacts"].ToString();
                }
                if ((row["ReferralContactsTel"] != null) && (row["ReferralContactsTel"] != DBNull.Value))
                {
                    gravida_firstfollowup.ReferralContactsTel = row["ReferralContactsTel"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    gravida_firstfollowup.ReferralResult = row["ReferralResult"].ToString();
                }
            }
            return gravida_firstfollowup;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_womengravidafirstvisit ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_womengravidafirstvisit ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_womengravidafirstvisit");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,RecordDate,PregancyWeeks,CustomerAge,HusbandName,HusbandAge,HusbandPhone,PregancyCount,NatrualChildBirthCount,CaeSareanCount,LastMenStruation,LastMenStruationDate,ExpectedDueDate,CustomerHistory,CustomerHistoryEx,FamilyHistory,FamilyHistoryEx,PersonalHistory,PersonalHistoryEx,GyNecoloGyHistory,AbortionInfo,Deadfetus,StillBirthInfo,NewBornDead,NewBornDefect,Height,Weight,Bmi,HBloodpressure,LBloodpressure,Heart,Heartex,Lung,Lungex,Vulva,VulvaEx,Vagina,VaginaEx,CervixuTeri,CervixuTeriex,Corpus,CorpusEx,Attach,AttachEx,OverAlassessMent,HealthZhiDao,HealthZhiDaoOthers,Referral,ReferralReason,ReferralOrg,NextfollowupDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,GynecologyHistoryEx,OverAlassessmentEx, ");
            builder.Append("ArtificialAbortion,BooksInfo,BooksInstitution,ReferralContacts,ReferralContactsTel,ReferralResult ");
            builder.Append(" FROM tbl_womengravidafirstvisit ");
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
            builder.Append(")AS Row, T.*  from tbl_womengravidafirstvisit T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_womengravidafirstvisit");
        }

        public WomenGravidaFirstVisitModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,RecordDate,PregancyWeeks,CustomerAge,HusbandName,HusbandAge,HusbandPhone,PregancyCount,NatrualChildBirthCount,CaeSareanCount,LastMenStruation,LastMenStruationDate,ExpectedDueDate,CustomerHistory,CustomerHistoryEx,FamilyHistory,FamilyHistoryEx,PersonalHistory,PersonalHistoryEx,GyNecoloGyHistory,AbortionInfo,Deadfetus,StillBirthInfo,NewBornDead,NewBornDefect,Height,Weight,Bmi,HBloodpressure,LBloodpressure,Heart,Heartex,Lung,Lungex,Vulva,VulvaEx,Vagina,VaginaEx,CervixuTeri,CervixuTeriex,Corpus,CorpusEx,Attach,AttachEx,OverAlassessMent,HealthZhiDao,HealthZhiDaoOthers,Referral,ReferralReason,ReferralOrg,NextfollowupDate,FollowUpDoctor,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,GynecologyHistoryEx,OverAlassessmentEx,ArtificialAbortion,BooksInfo,BooksInstitution,ReferralContacts,ReferralContactsTel,ReferralResult from tbl_womengravidafirstvisit ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new WomenGravidaFirstVisitModel();
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
            builder.Append("select count(1) FROM tbl_womengravidafirstvisit ");
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

        public bool Update(WomenGravidaFirstVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_womengravidafirstvisit set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("RecordDate=@RecordDate,");
            builder.Append("PregancyWeeks=@PregancyWeeks,");
            builder.Append("CustomerAge=@CustomerAge,");
            builder.Append("HusbandName=@HusbandName,");
            builder.Append("HusbandAge=@HusbandAge,");
            builder.Append("HusbandPhone=@HusbandPhone,");
            builder.Append("PregancyCount=@PregancyCount,");
            builder.Append("NatrualChildBirthCount=@NatrualChildBirthCount,");
            builder.Append("CaeSareanCount=@CaeSareanCount,");
            builder.Append("LastMenStruation=@LastMenStruation,");
            builder.Append("LastMenStruationDate=@LastMenStruationDate,");
            builder.Append("ExpectedDueDate=@ExpectedDueDate,");
            builder.Append("CustomerHistory=@CustomerHistory,");
            builder.Append("CustomerHistoryEx=@CustomerHistoryEx,");
            builder.Append("FamilyHistory=@FamilyHistory,");
            builder.Append("FamilyHistoryEx=@FamilyHistoryEx,");
            builder.Append("PersonalHistory=@PersonalHistory,");
            builder.Append("PersonalHistoryEx=@PersonalHistoryEx,");
            builder.Append("GyNecoloGyHistory=@GyNecoloGyHistory,");
            builder.Append("AbortionInfo=@AbortionInfo,");
            builder.Append("Deadfetus=@Deadfetus,");
            builder.Append("StillBirthInfo=@StillBirthInfo,");
            builder.Append("NewBornDead=@NewBornDead,");
            builder.Append("NewBornDefect=@NewBornDefect,");
            builder.Append("Height=@Height,");
            builder.Append("Weight=@Weight,");
            builder.Append("Bmi=@Bmi,");
            builder.Append("HBloodpressure=@HBloodpressure,");
            builder.Append("LBloodpressure=@LBloodpressure,");
            builder.Append("Heart=@Heart,");
            builder.Append("Heartex=@Heartex,");
            builder.Append("Lung=@Lung,");
            builder.Append("Lungex=@Lungex,");
            builder.Append("Vulva=@Vulva,");
            builder.Append("VulvaEx=@VulvaEx,");
            builder.Append("Vagina=@Vagina,");
            builder.Append("VaginaEx=@VaginaEx,");
            builder.Append("CervixuTeri=@CervixuTeri,");
            builder.Append("CervixuTeriex=@CervixuTeriex,");
            builder.Append("Corpus=@Corpus,");
            builder.Append("CorpusEx=@CorpusEx,");
            builder.Append("Attach=@Attach,");
            builder.Append("AttachEx=@AttachEx,");
            builder.Append("OverAlassessMent=@OverAlassessMent,");
            builder.Append("HealthZhiDao=@HealthZhiDao,");
            builder.Append("HealthZhiDaoOthers=@HealthZhiDaoOthers,");
            builder.Append("Referral=@Referral,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("NextfollowupDate=@NextfollowupDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("GynecologyHistoryEx=@GynecologyHistoryEx,");
            builder.Append("OverAlassessmentEx=@OverAlassessmentEx,");
            builder.Append("ArtificialAbortion=@ArtificialAbortion,");
            builder.Append("BooksInfo=@BooksInfo,");
            builder.Append("BooksInstitution=@BooksInstitution,");
            builder.Append("ReferralContacts=@ReferralContacts,");
            builder.Append("ReferralContactsTel=@ReferralContactsTel,");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 80), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@RecordDate", MySqlDbType.Date), 
                new MySqlParameter("@PregancyWeeks", MySqlDbType.Int32),
                new MySqlParameter("@CustomerAge", MySqlDbType.Int32), 
                new MySqlParameter("@HusbandName", MySqlDbType.String, 30), 
                new MySqlParameter("@HusbandAge", MySqlDbType.Int32), 
                new MySqlParameter("@HusbandPhone", MySqlDbType.String, 15), 
                new MySqlParameter("@PregancyCount", MySqlDbType.Int32), 
                new MySqlParameter("@NatrualChildBirthCount", MySqlDbType.Int32), 
                new MySqlParameter("@CaeSareanCount", MySqlDbType.Int32), 
                new MySqlParameter("@LastMenStruation", MySqlDbType.String, 1), 
                new MySqlParameter("@LastMenStruationDate", MySqlDbType.Date), 
                new MySqlParameter("@ExpectedDueDate", MySqlDbType.Date), 
                new MySqlParameter("@CustomerHistory", MySqlDbType.String, 30), 
                new MySqlParameter("@CustomerHistoryEx", MySqlDbType.String, 100), 
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@FamilyHistoryEx", MySqlDbType.String, 100),
                new MySqlParameter("@PersonalHistory", MySqlDbType.String, 32), 
                new MySqlParameter("@PersonalHistoryEx", MySqlDbType.String, 100),
                new MySqlParameter("@GyNecoloGyHistory", MySqlDbType.String, 1),
                new MySqlParameter("@AbortionInfo", MySqlDbType.String, 200),
                new MySqlParameter("@Deadfetus", MySqlDbType.String, 200), 
                new MySqlParameter("@StillBirthInfo", MySqlDbType.String, 200),
                new MySqlParameter("@NewBornDead", MySqlDbType.String, 200), 
                new MySqlParameter("@NewBornDefect", MySqlDbType.String, 200),
                new MySqlParameter("@Height", MySqlDbType.Decimal), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@Bmi", MySqlDbType.Decimal), 
                new MySqlParameter("@HBloodpressure", MySqlDbType.Int32), 
                new MySqlParameter("@LBloodpressure", MySqlDbType.Int32), 
                new MySqlParameter("@Heart", MySqlDbType.String, 1),
                new MySqlParameter("@Heartex", MySqlDbType.String, 100),
                new MySqlParameter("@Lung", MySqlDbType.String, 1),
                new MySqlParameter("@Lungex", MySqlDbType.String, 100), 
                new MySqlParameter("@Vulva", MySqlDbType.String, 1), 
                new MySqlParameter("@VulvaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Vagina", MySqlDbType.String, 1), 
                new MySqlParameter("@VaginaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@CervixuTeri", MySqlDbType.String, 1), 
                new MySqlParameter("@CervixuTeriex", MySqlDbType.String, 200),
                new MySqlParameter("@Corpus", MySqlDbType.String, 1), 
                new MySqlParameter("@CorpusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Attach", MySqlDbType.String, 1), 
                new MySqlParameter("@AttachEx", MySqlDbType.String, 200), 
                new MySqlParameter("@OverAlassessMent", MySqlDbType.String, 1), 
                new MySqlParameter("@HealthZhiDao", MySqlDbType.String, 30), 
                new MySqlParameter("@HealthZhiDaoOthers", MySqlDbType.String, 200),
                new MySqlParameter("@Referral", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextfollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@GynecologyHistoryEx", MySqlDbType.String, 200),
                new MySqlParameter("@OverAlassessmentEx", MySqlDbType.String, 200),
                new MySqlParameter("@ArtificialAbortion", MySqlDbType.String, 100),
                new MySqlParameter("@BooksInfo", MySqlDbType.String, 1),
                new MySqlParameter("@BooksInstitution", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.RecordDate;
            cmdParms[4].Value = model.PregancyWeeks;
            cmdParms[5].Value = model.CustomerAge;
            cmdParms[6].Value = model.HusbandName;
            cmdParms[7].Value = model.HusbandAge;
            cmdParms[8].Value = model.HusbandPhone;
            cmdParms[9].Value = model.PregancyCount;
            cmdParms[10].Value = model.NatrualChildBirthCount;
            cmdParms[11].Value = model.CaeSareanCount;
            cmdParms[12].Value = model.LastMenStruation;
            cmdParms[13].Value = model.LastMenStruationDate;
            cmdParms[14].Value = model.ExpectedDueDate;
            cmdParms[15].Value = model.CustomerHistory;
            cmdParms[16].Value = model.CustomerHistoryEx;
            cmdParms[17].Value = model.FamilyHistory;
            cmdParms[18].Value = model.FamilyHistoryEx;
            cmdParms[19].Value = model.PersonalHistory;
            cmdParms[20].Value = model.PersonalHistoryEx;
            cmdParms[21].Value = model.GyNecoloGyHistory;
            cmdParms[22].Value = model.AbortionInfo;
            cmdParms[23].Value = model.Deadfetus;
            cmdParms[24].Value = model.StillBirthInfo;
            cmdParms[25].Value = model.NewBornDead;
            cmdParms[26].Value = model.NewBornDefect;
            cmdParms[27].Value = model.Height;
            cmdParms[28].Value = model.Weight;
            cmdParms[29].Value = model.Bmi;
            cmdParms[30].Value = model.HBloodpressure;
            cmdParms[31].Value = model.LBloodpressure;
            cmdParms[32].Value = model.Heart;
            cmdParms[33].Value = model.Heartex;
            cmdParms[34].Value = model.Lung;
            cmdParms[35].Value = model.Lungex;
            cmdParms[36].Value = model.Vulva;
            cmdParms[37].Value = model.VulvaEx;
            cmdParms[38].Value = model.Vagina;
            cmdParms[39].Value = model.VaginaEx;
            cmdParms[40].Value = model.CervixuTeri;
            cmdParms[41].Value = model.CervixuTeriex;
            cmdParms[42].Value = model.Corpus;
            cmdParms[43].Value = model.CorpusEx;
            cmdParms[44].Value = model.Attach;
            cmdParms[45].Value = model.AttachEx;
            cmdParms[46].Value = model.OverAlassessMent;
            cmdParms[47].Value = model.HealthZhiDao;
            cmdParms[48].Value = model.HealthZhiDaoOthers;
            cmdParms[49].Value = model.Referral;
            cmdParms[50].Value = model.ReferralReason;
            cmdParms[51].Value = model.ReferralOrg;
            cmdParms[52].Value = model.NextfollowupDate;
            cmdParms[53].Value = model.FollowUpDoctor;
            cmdParms[54].Value = model.CreatedBy;
            cmdParms[55].Value = model.CreatedDate;
            cmdParms[56].Value = model.LastUpdateBy;
            cmdParms[57].Value = model.LastUpdateDate;
            cmdParms[58].Value = model.IsDel;
            cmdParms[59].Value = model.GynecologyHistoryEx;
            cmdParms[60].Value = model.OverAlassessmentEx;
            cmdParms[61].Value = model.ArtificialAbortion;
            cmdParms[62].Value = model.BooksInfo;
            cmdParms[63].Value = model.BooksInstitution;
            cmdParms[64].Value = model.ReferralContacts;
            cmdParms[65].Value = model.ReferralContactsTel;
            cmdParms[66].Value = model.ReferralResult;
            cmdParms[67].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool UpdateServer(WomenGravidaFirstVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_womengravidafirstvisit set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("RecordDate=@RecordDate,");
            builder.Append("PregancyWeeks=@PregancyWeeks,");
            builder.Append("CustomerAge=@CustomerAge,");
            builder.Append("HusbandName=@HusbandName,");
            builder.Append("HusbandAge=@HusbandAge,");
            builder.Append("HusbandPhone=@HusbandPhone,");
            builder.Append("PregancyCount=@PregancyCount,");
            builder.Append("NatrualChildBirthCount=@NatrualChildBirthCount,");
            builder.Append("CaeSareanCount=@CaeSareanCount,");
            builder.Append("LastMenStruation=@LastMenStruation,");
            builder.Append("LastMenStruationDate=@LastMenStruationDate,");
            builder.Append("ExpectedDueDate=@ExpectedDueDate,");
            builder.Append("CustomerHistory=@CustomerHistory,");
            builder.Append("CustomerHistoryEx=@CustomerHistoryEx,");
            builder.Append("FamilyHistory=@FamilyHistory,");
            builder.Append("FamilyHistoryEx=@FamilyHistoryEx,");
            builder.Append("PersonalHistory=@PersonalHistory,");
            builder.Append("PersonalHistoryEx=@PersonalHistoryEx,");
            builder.Append("GyNecoloGyHistory=@GyNecoloGyHistory,");
            builder.Append("AbortionInfo=@AbortionInfo,");
            builder.Append("Deadfetus=@Deadfetus,");
            builder.Append("StillBirthInfo=@StillBirthInfo,");
            builder.Append("NewBornDead=@NewBornDead,");
            builder.Append("NewBornDefect=@NewBornDefect,");
            builder.Append("Height=@Height,");
            builder.Append("Weight=@Weight,");
            builder.Append("Bmi=@Bmi,");
            builder.Append("HBloodpressure=@HBloodpressure,");
            builder.Append("LBloodpressure=@LBloodpressure,");
            builder.Append("Heart=@Heart,");
            builder.Append("Heartex=@Heartex,");
            builder.Append("Lung=@Lung,");
            builder.Append("Lungex=@Lungex,");
            builder.Append("Vulva=@Vulva,");
            builder.Append("VulvaEx=@VulvaEx,");
            builder.Append("Vagina=@Vagina,");
            builder.Append("VaginaEx=@VaginaEx,");
            builder.Append("CervixuTeri=@CervixuTeri,");
            builder.Append("CervixuTeriex=@CervixuTeriex,");
            builder.Append("Corpus=@Corpus,");
            builder.Append("CorpusEx=@CorpusEx,");
            builder.Append("Attach=@Attach,");
            builder.Append("AttachEx=@AttachEx,");
            builder.Append("OverAlassessMent=@OverAlassessMent,");
            builder.Append("HealthZhiDao=@HealthZhiDao,");
            builder.Append("HealthZhiDaoOthers=@HealthZhiDaoOthers,");
            builder.Append("Referral=@Referral,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("NextfollowupDate=@NextfollowupDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("GynecologyHistoryEx=@GynecologyHistoryEx,");
            builder.Append("OverAlassessmentEx=@OverAlassessmentEx,");
            builder.Append("ArtificialAbortion=@ArtificialAbortion,");
            builder.Append("BooksInfo=@BooksInfo,");
            builder.Append("BooksInstitution=@BooksInstitution,");
            builder.Append("ReferralContacts=@ReferralContacts,");
            builder.Append("ReferralContactsTel=@ReferralContactsTel,");
            builder.Append("ReferralResult=@ReferralResult ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 80), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@RecordDate", MySqlDbType.Date), 
                new MySqlParameter("@PregancyWeeks", MySqlDbType.Int32),
                new MySqlParameter("@CustomerAge", MySqlDbType.Int32), 
                new MySqlParameter("@HusbandName", MySqlDbType.String, 30), 
                new MySqlParameter("@HusbandAge", MySqlDbType.Int32), 
                new MySqlParameter("@HusbandPhone", MySqlDbType.String, 15), 
                new MySqlParameter("@PregancyCount", MySqlDbType.Int32), 
                new MySqlParameter("@NatrualChildBirthCount", MySqlDbType.Int32), 
                new MySqlParameter("@CaeSareanCount", MySqlDbType.Int32), 
                new MySqlParameter("@LastMenStruation", MySqlDbType.String, 1), 
                new MySqlParameter("@LastMenStruationDate", MySqlDbType.Date), 
                new MySqlParameter("@ExpectedDueDate", MySqlDbType.Date), 
                new MySqlParameter("@CustomerHistory", MySqlDbType.String, 30), 
                new MySqlParameter("@CustomerHistoryEx", MySqlDbType.String, 100), 
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@FamilyHistoryEx", MySqlDbType.String, 100),
                new MySqlParameter("@PersonalHistory", MySqlDbType.String, 32), 
                new MySqlParameter("@PersonalHistoryEx", MySqlDbType.String, 100),
                new MySqlParameter("@GyNecoloGyHistory", MySqlDbType.String, 1),
                new MySqlParameter("@AbortionInfo", MySqlDbType.String, 200),
                new MySqlParameter("@Deadfetus", MySqlDbType.String, 200), 
                new MySqlParameter("@StillBirthInfo", MySqlDbType.String, 200),
                new MySqlParameter("@NewBornDead", MySqlDbType.String, 200), 
                new MySqlParameter("@NewBornDefect", MySqlDbType.String, 200),
                new MySqlParameter("@Height", MySqlDbType.Decimal), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@Bmi", MySqlDbType.Decimal), 
                new MySqlParameter("@HBloodpressure", MySqlDbType.Int32), 
                new MySqlParameter("@LBloodpressure", MySqlDbType.Int32), 
                new MySqlParameter("@Heart", MySqlDbType.String, 1),
                new MySqlParameter("@Heartex", MySqlDbType.String, 100),
                new MySqlParameter("@Lung", MySqlDbType.String, 1),
                new MySqlParameter("@Lungex", MySqlDbType.String, 100), 
                new MySqlParameter("@Vulva", MySqlDbType.String, 1), 
                new MySqlParameter("@VulvaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Vagina", MySqlDbType.String, 1), 
                new MySqlParameter("@VaginaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@CervixuTeri", MySqlDbType.String, 1), 
                new MySqlParameter("@CervixuTeriex", MySqlDbType.String, 200),
                new MySqlParameter("@Corpus", MySqlDbType.String, 1), 
                new MySqlParameter("@CorpusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@Attach", MySqlDbType.String, 1), 
                new MySqlParameter("@AttachEx", MySqlDbType.String, 200), 
                new MySqlParameter("@OverAlassessMent", MySqlDbType.String, 1), 
                new MySqlParameter("@HealthZhiDao", MySqlDbType.String, 30), 
                new MySqlParameter("@HealthZhiDaoOthers", MySqlDbType.String, 200),
                new MySqlParameter("@Referral", MySqlDbType.String, 1), 
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@NextfollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@GynecologyHistoryEx", MySqlDbType.String, 200),
                new MySqlParameter("@OverAlassessmentEx", MySqlDbType.String, 200),
                new MySqlParameter("@ArtificialAbortion", MySqlDbType.String, 100),
                new MySqlParameter("@BooksInfo", MySqlDbType.String, 1),
                new MySqlParameter("@BooksInstitution", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralContactsTel", MySqlDbType.String, 50),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.RecordDate;
            cmdParms[4].Value = model.PregancyWeeks;
            cmdParms[5].Value = model.CustomerAge;
            cmdParms[6].Value = model.HusbandName;
            cmdParms[7].Value = model.HusbandAge;
            cmdParms[8].Value = model.HusbandPhone;
            cmdParms[9].Value = model.PregancyCount;
            cmdParms[10].Value = model.NatrualChildBirthCount;
            cmdParms[11].Value = model.CaeSareanCount;
            cmdParms[12].Value = model.LastMenStruation;
            cmdParms[13].Value = model.LastMenStruationDate;
            cmdParms[14].Value = model.ExpectedDueDate;
            cmdParms[15].Value = model.CustomerHistory;
            cmdParms[16].Value = model.CustomerHistoryEx;
            cmdParms[17].Value = model.FamilyHistory;
            cmdParms[18].Value = model.FamilyHistoryEx;
            cmdParms[19].Value = model.PersonalHistory;
            cmdParms[20].Value = model.PersonalHistoryEx;
            cmdParms[21].Value = model.GyNecoloGyHistory;
            cmdParms[22].Value = model.AbortionInfo;
            cmdParms[23].Value = model.Deadfetus;
            cmdParms[24].Value = model.StillBirthInfo;
            cmdParms[25].Value = model.NewBornDead;
            cmdParms[26].Value = model.NewBornDefect;
            cmdParms[27].Value = model.Height;
            cmdParms[28].Value = model.Weight;
            cmdParms[29].Value = model.Bmi;
            cmdParms[30].Value = model.HBloodpressure;
            cmdParms[31].Value = model.LBloodpressure;
            cmdParms[32].Value = model.Heart;
            cmdParms[33].Value = model.Heartex;
            cmdParms[34].Value = model.Lung;
            cmdParms[35].Value = model.Lungex;
            cmdParms[36].Value = model.Vulva;
            cmdParms[37].Value = model.VulvaEx;
            cmdParms[38].Value = model.Vagina;
            cmdParms[39].Value = model.VaginaEx;
            cmdParms[40].Value = model.CervixuTeri;
            cmdParms[41].Value = model.CervixuTeriex;
            cmdParms[42].Value = model.Corpus;
            cmdParms[43].Value = model.CorpusEx;
            cmdParms[44].Value = model.Attach;
            cmdParms[45].Value = model.AttachEx;
            cmdParms[46].Value = model.OverAlassessMent;
            cmdParms[47].Value = model.HealthZhiDao;
            cmdParms[48].Value = model.HealthZhiDaoOthers;
            cmdParms[49].Value = model.Referral;
            cmdParms[50].Value = model.ReferralReason;
            cmdParms[51].Value = model.ReferralOrg;
            cmdParms[52].Value = model.NextfollowupDate;
            cmdParms[53].Value = model.FollowUpDoctor;
            cmdParms[54].Value = model.CreatedBy;
            cmdParms[55].Value = model.CreatedDate;
            cmdParms[56].Value = model.LastUpdateBy;
            cmdParms[57].Value = model.LastUpdateDate;
            cmdParms[58].Value = model.IsDel;
            cmdParms[59].Value = model.GynecologyHistoryEx;
            cmdParms[60].Value = model.OverAlassessmentEx;
            cmdParms[61].Value = model.ArtificialAbortion;
            cmdParms[62].Value = model.BooksInfo;
            cmdParms[63].Value = model.BooksInstitution;
            cmdParms[64].Value = model.ReferralContacts;
            cmdParms[65].Value = model.ReferralContactsTel;
            cmdParms[66].Value = model.ReferralResult;
           // cmdParms[61].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

