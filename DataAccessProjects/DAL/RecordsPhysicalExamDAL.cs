namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsPhysicalExamDAL
    {
        public int Add(RecordsPhysicalExamModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_PHYSICALEXAM(");
            builder.Append("PhysicalID,IDCardNo,Skin,Sclere,Lymph,BarrelChest,BreathSounds,Rale,HeartRate, ");
            builder.Append("HeartRhythm,Noise,EnclosedMass,Edema,FootBack,Anus,Breast,Vulva,Vagina,CervixUteri, ");
            builder.Append("Corpus,Attach,Other,PressPain,Liver,Spleen,Voiced,SkinEx,SclereEx,LymphEx,BreastEx, ");
            builder.Append("AnusEx,BreathSoundsEx,RaleEx,NoiseEx,CervixUteriEx,CorpusEx,AttachEx,VulvaEx, ");
            builder.Append("VaginaEx,PressPainEx,LiverEx,SpleenEx,VoicedEx,EnclosedMassEx,EyeRound,EyeRoundEx,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@Skin,@Sclere,@Lymph,@BarrelChest,@BreathSounds,@Rale,@HeartRate, ");
            builder.Append("@HeartRhythm,@Noise,@EnclosedMass,@Edema,@FootBack,@Anus,@Breast,@Vulva,@Vagina,@CervixUteri, ");
            builder.Append("@Corpus,@Attach,@Other,@PressPain,@Liver,@Spleen,@Voiced,@SkinEx,@SclereEx,@LymphEx,@BreastEx, ");
            builder.Append("@AnusEx,@BreathSoundsEx,@RaleEx,@NoiseEx,@CervixUteriEx,@CorpusEx,@AttachEx,@VulvaEx, ");
            builder.Append("@VaginaEx,@PressPainEx,@LiverEx,@SpleenEx,@VoicedEx,@EnclosedMassEx,@EyeRound,@EyeRoundEx,@OutKey)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 

                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Skin", MySqlDbType.String, 50), 
                new MySqlParameter("@Sclere", MySqlDbType.String, 50), 
                new MySqlParameter("@Lymph", MySqlDbType.String, 50), 
                new MySqlParameter("@BarrelChest", MySqlDbType.String, 1), 
                new MySqlParameter("@BreathSounds", MySqlDbType.String, 1), 
                new MySqlParameter("@Rale", MySqlDbType.String, 50), 
                new MySqlParameter("@HeartRate", MySqlDbType.String, 8), 
                new MySqlParameter("@HeartRhythm", MySqlDbType.String, 1), 
                new MySqlParameter("@Noise", MySqlDbType.String, 1), 
                new MySqlParameter("@EnclosedMass", MySqlDbType.String, 1), 
                new MySqlParameter("@Edema", MySqlDbType.String, 1), 
                new MySqlParameter("@FootBack", MySqlDbType.String, 1), 
                new MySqlParameter("@Anus", MySqlDbType.String, 50), 
                new MySqlParameter("@Breast", MySqlDbType.String, 50), 
                new MySqlParameter("@Vulva", MySqlDbType.String, 1),
                new MySqlParameter("@Vagina", MySqlDbType.String, 1),
                new MySqlParameter("@CervixUteri", MySqlDbType.String, 1), 
                new MySqlParameter("@Corpus", MySqlDbType.String, 1), 
                new MySqlParameter("@Attach", MySqlDbType.String, 1), 
                new MySqlParameter("@Other", MySqlDbType.String, 500), 
                new MySqlParameter("@PressPain", MySqlDbType.String, 1),
                new MySqlParameter("@Liver", MySqlDbType.String, 1), 
                new MySqlParameter("@Spleen", MySqlDbType.String, 1), 
                new MySqlParameter("@Voiced", MySqlDbType.String, 1), 
                new MySqlParameter("@SkinEx", MySqlDbType.String, 200), 
                new MySqlParameter("@SclereEx", MySqlDbType.String, 200),
                new MySqlParameter("@LymphEx", MySqlDbType.String, 200), 
                new MySqlParameter("@BreastEx", MySqlDbType.String, 200), 
                new MySqlParameter("@AnusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@BreathSoundsEx", MySqlDbType.String, 200), 
                new MySqlParameter("@RaleEx", MySqlDbType.String, 200), 
                new MySqlParameter("@NoiseEx", MySqlDbType.String, 200), 
                new MySqlParameter("@CervixUteriEx", MySqlDbType.String, 200),
                new MySqlParameter("@CorpusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@AttachEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VulvaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VaginaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@PressPainEx", MySqlDbType.String, 200),
                new MySqlParameter("@LiverEx", MySqlDbType.String, 200), 
                new MySqlParameter("@SpleenEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VoicedEx", MySqlDbType.String, 200), 
                new MySqlParameter("@EnclosedMassEx", MySqlDbType.String, 200), 
                new MySqlParameter("@EyeRound", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeRoundEx", MySqlDbType.String, 200),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Skin;
            cmdParms[3].Value = model.Sclere;
            cmdParms[4].Value = model.Lymph;
            cmdParms[5].Value = model.BarrelChest;
            cmdParms[6].Value = model.BreathSounds;
            cmdParms[7].Value = model.Rale;
            cmdParms[8].Value = model.HeartRate;
            cmdParms[9].Value = model.HeartRhythm;
            cmdParms[10].Value = model.Noise;
            cmdParms[11].Value = model.EnclosedMass;
            cmdParms[12].Value = model.Edema;
            cmdParms[13].Value = model.FootBack;
            cmdParms[14].Value = model.Anus;
            cmdParms[15].Value = model.Breast;
            cmdParms[16].Value = model.Vulva;
            cmdParms[17].Value = model.Vagina;
            cmdParms[18].Value = model.CervixUteri;
            cmdParms[19].Value = model.Corpus;
            cmdParms[20].Value = model.Attach;
            cmdParms[21].Value = model.Other;
            cmdParms[22].Value = model.PressPain;
            cmdParms[23].Value = model.Liver;
            cmdParms[24].Value = model.Spleen;
            cmdParms[25].Value = model.Voiced;
            cmdParms[26].Value = model.SkinEx;
            cmdParms[27].Value = model.SclereEx;
            cmdParms[28].Value = model.LymphEx;
            cmdParms[29].Value = model.BreastEx;
            cmdParms[30].Value = model.AnusEx;
            cmdParms[31].Value = model.BreathSoundsEx;
            cmdParms[32].Value = model.RaleEx;
            cmdParms[33].Value = model.NoiseEx;
            cmdParms[34].Value = model.CervixUteriEx;
            cmdParms[35].Value = model.CorpusEx;
            cmdParms[36].Value = model.AttachEx;
            cmdParms[37].Value = model.VulvaEx;
            cmdParms[38].Value = model.VaginaEx;
            cmdParms[39].Value = model.PressPainEx;
            cmdParms[40].Value = model.LiverEx;
            cmdParms[41].Value = model.SpleenEx;
            cmdParms[42].Value = model.VoicedEx;
            cmdParms[43].Value = model.EnclosedMassEx;
            cmdParms[44].Value = model.EyeRound;
            cmdParms[45].Value = model.EyeRoundEx;
            cmdParms[46].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public int AddIDCardNo(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_PHYSICALEXAM (IDCardNo) values (@IDCardNo) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
             };
            cmdParms[0].Value = IDCardNo;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public int AddServer(RecordsPhysicalExamModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_PHYSICALEXAM(");
            builder.Append("PhysicalID,IDCardNo,Skin,Sclere,Lymph,BarrelChest,BreathSounds,Rale,HeartRate, ");
            builder.Append("HeartRhythm,Noise,EnclosedMass,Edema,FootBack,Anus,Breast,Vulva,Vagina,CervixUteri, ");
            builder.Append("Corpus,Attach,Other,PressPain,Liver,Spleen,Voiced,SkinEx,SclereEx,LymphEx,BreastEx, ");
            builder.Append("AnusEx,BreathSoundsEx,RaleEx,NoiseEx,CervixUteriEx,CorpusEx,AttachEx,VulvaEx, ");
            builder.Append("VaginaEx,PressPainEx,LiverEx,SpleenEx,VoicedEx,EnclosedMassEx,EyeRound,EyeRoundEx,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@Skin,@Sclere,@Lymph,@BarrelChest,@BreathSounds,@Rale,@HeartRate, ");
            builder.Append("@HeartRhythm,@Noise,@EnclosedMass,@Edema,@FootBack,@Anus,@Breast,@Vulva,@Vagina,@CervixUteri, ");
            builder.Append("@Corpus,@Attach,@Other,@PressPain,@Liver,@Spleen,@Voiced,@SkinEx,@SclereEx,@LymphEx,@BreastEx, ");
            builder.Append("@AnusEx,@BreathSoundsEx,@RaleEx,@NoiseEx,@CervixUteriEx,@CorpusEx,@AttachEx,@VulvaEx, ");
            builder.Append("@VaginaEx,@PressPainEx,@LiverEx,@SpleenEx,@VoicedEx,@EnclosedMassEx,@EyeRound,@EyeRoundEx,@OutKey)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 

                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Skin", MySqlDbType.String, 50), 
                new MySqlParameter("@Sclere", MySqlDbType.String, 50), 
                new MySqlParameter("@Lymph", MySqlDbType.String, 50), 
                new MySqlParameter("@BarrelChest", MySqlDbType.String, 1), 
                new MySqlParameter("@BreathSounds", MySqlDbType.String, 1), 
                new MySqlParameter("@Rale", MySqlDbType.String, 50), 
                new MySqlParameter("@HeartRate", MySqlDbType.String, 8), 
                new MySqlParameter("@HeartRhythm", MySqlDbType.String, 1), 
                new MySqlParameter("@Noise", MySqlDbType.String, 1), 
                new MySqlParameter("@EnclosedMass", MySqlDbType.String, 1), 
                new MySqlParameter("@Edema", MySqlDbType.String, 1), 
                new MySqlParameter("@FootBack", MySqlDbType.String, 1), 
                new MySqlParameter("@Anus", MySqlDbType.String, 50), 
                new MySqlParameter("@Breast", MySqlDbType.String, 50), 
                new MySqlParameter("@Vulva", MySqlDbType.String, 1),
                new MySqlParameter("@Vagina", MySqlDbType.String, 1),
                new MySqlParameter("@CervixUteri", MySqlDbType.String, 1), 
                new MySqlParameter("@Corpus", MySqlDbType.String, 1), 
                new MySqlParameter("@Attach", MySqlDbType.String, 1), 
                new MySqlParameter("@Other", MySqlDbType.String, 500), 
                new MySqlParameter("@PressPain", MySqlDbType.String, 1),
                new MySqlParameter("@Liver", MySqlDbType.String, 1), 
                new MySqlParameter("@Spleen", MySqlDbType.String, 1), 
                new MySqlParameter("@Voiced", MySqlDbType.String, 1), 
                new MySqlParameter("@SkinEx", MySqlDbType.String, 200), 
                new MySqlParameter("@SclereEx", MySqlDbType.String, 200),
                new MySqlParameter("@LymphEx", MySqlDbType.String, 200), 
                new MySqlParameter("@BreastEx", MySqlDbType.String, 200), 
                new MySqlParameter("@AnusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@BreathSoundsEx", MySqlDbType.String, 200), 
                new MySqlParameter("@RaleEx", MySqlDbType.String, 200), 
                new MySqlParameter("@NoiseEx", MySqlDbType.String, 200), 
                new MySqlParameter("@CervixUteriEx", MySqlDbType.String, 200),
                new MySqlParameter("@CorpusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@AttachEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VulvaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VaginaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@PressPainEx", MySqlDbType.String, 200),
                new MySqlParameter("@LiverEx", MySqlDbType.String, 200), 
                new MySqlParameter("@SpleenEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VoicedEx", MySqlDbType.String, 200), 
                new MySqlParameter("@EnclosedMassEx", MySqlDbType.String, 200), 
                new MySqlParameter("@EyeRound", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeRoundEx", MySqlDbType.String, 200),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Skin;
            cmdParms[3].Value = model.Sclere;
            cmdParms[4].Value = model.Lymph;
            cmdParms[5].Value = model.BarrelChest;
            cmdParms[6].Value = model.BreathSounds;
            cmdParms[7].Value = model.Rale;
            cmdParms[8].Value = model.HeartRate;
            cmdParms[9].Value = model.HeartRhythm;
            cmdParms[10].Value = model.Noise;
            cmdParms[11].Value = model.EnclosedMass;
            cmdParms[12].Value = model.Edema;
            cmdParms[13].Value = model.FootBack;
            cmdParms[14].Value = model.Anus;
            cmdParms[15].Value = model.Breast;
            cmdParms[16].Value = model.Vulva;
            cmdParms[17].Value = model.Vagina;
            cmdParms[18].Value = model.CervixUteri;
            cmdParms[19].Value = model.Corpus;
            cmdParms[20].Value = model.Attach;
            cmdParms[21].Value = model.Other;
            cmdParms[22].Value = model.PressPain;
            cmdParms[23].Value = model.Liver;
            cmdParms[24].Value = model.Spleen;
            cmdParms[25].Value = model.Voiced;
            cmdParms[26].Value = model.SkinEx;
            cmdParms[27].Value = model.SclereEx;
            cmdParms[28].Value = model.LymphEx;
            cmdParms[29].Value = model.BreastEx;
            cmdParms[30].Value = model.AnusEx;
            cmdParms[31].Value = model.BreathSoundsEx;
            cmdParms[32].Value = model.RaleEx;
            cmdParms[33].Value = model.NoiseEx;
            cmdParms[34].Value = model.CervixUteriEx;
            cmdParms[35].Value = model.CorpusEx;
            cmdParms[36].Value = model.AttachEx;
            cmdParms[37].Value = model.VulvaEx;
            cmdParms[38].Value = model.VaginaEx;
            cmdParms[39].Value = model.PressPainEx;
            cmdParms[40].Value = model.LiverEx;
            cmdParms[41].Value = model.SpleenEx;
            cmdParms[42].Value = model.VoicedEx;
            cmdParms[43].Value = model.EnclosedMassEx;
            cmdParms[44].Value = model.EyeRound;
            cmdParms[45].Value = model.EyeRoundEx;
            cmdParms[46].Value = model.OutKey;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsPhysicalExamModel DataRowToModel(DataRow row)
        {
            RecordsPhysicalExamModel recordsPhysicalExamModel = new RecordsPhysicalExamModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsPhysicalExamModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Skin"] != null) && (row["Skin"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Skin = row["Skin"].ToString();
                }
                if ((row["Sclere"] != null) && (row["Sclere"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Sclere = row["Sclere"].ToString();
                }
                if ((row["Lymph"] != null) && (row["Lymph"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Lymph = row["Lymph"].ToString();
                }
                if ((row["BarrelChest"] != null) && (row["BarrelChest"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.BarrelChest = row["BarrelChest"].ToString();
                }
                if ((row["BreathSounds"] != null) && (row["BreathSounds"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.BreathSounds = row["BreathSounds"].ToString();
                }
                if ((row["Rale"] != null) && (row["Rale"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Rale = row["Rale"].ToString();
                }
                if ((row["HeartRate"] != null) && (row["HeartRate"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.HeartRate = row["HeartRate"].ToString();
                }
                if ((row["HeartRhythm"] != null) && (row["HeartRhythm"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.HeartRhythm = row["HeartRhythm"].ToString();
                }
                if ((row["Noise"] != null) && (row["Noise"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Noise = row["Noise"].ToString();
                }
                if ((row["EnclosedMass"] != null) && (row["EnclosedMass"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.EnclosedMass = row["EnclosedMass"].ToString();
                }
                if ((row["Edema"] != null) && (row["Edema"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Edema = row["Edema"].ToString();
                }
                if ((row["FootBack"] != null) && (row["FootBack"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.FootBack = row["FootBack"].ToString();
                }
                if ((row["Anus"] != null) && (row["Anus"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Anus = row["Anus"].ToString();
                }
                if ((row["Breast"] != null) && (row["Breast"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Breast = row["Breast"].ToString();
                }
                if ((row["Vulva"] != null) && (row["Vulva"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Vulva = row["Vulva"].ToString();
                }
                if ((row["Vagina"] != null) && (row["Vagina"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Vagina = row["Vagina"].ToString();
                }
                if ((row["CervixUteri"] != null) && (row["CervixUteri"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.CervixUteri = row["CervixUteri"].ToString();
                }
                if ((row["Corpus"] != null) && (row["Corpus"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Corpus = row["Corpus"].ToString();
                }
                if ((row["Attach"] != null) && (row["Attach"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Attach = row["Attach"].ToString();
                }
                if ((row["Other"] != null) && (row["Other"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Other = row["Other"].ToString();
                }
                if ((row["PressPain"] != null) && (row["PressPain"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.PressPain = row["PressPain"].ToString();
                }
                if ((row["Liver"] != null) && (row["Liver"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Liver = row["Liver"].ToString();
                }
                if ((row["Spleen"] != null) && (row["Spleen"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Spleen = row["Spleen"].ToString();
                }
                if ((row["Voiced"] != null) && (row["Voiced"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.Voiced = row["Voiced"].ToString();
                }
                if ((row["SkinEx"] != null) && (row["SkinEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.SkinEx = row["SkinEx"].ToString();
                }
                if ((row["SclereEx"] != null) && (row["SclereEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.SclereEx = row["SclereEx"].ToString();
                }
                if ((row["LymphEx"] != null) && (row["LymphEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.LymphEx = row["LymphEx"].ToString();
                }
                if ((row["BreastEx"] != null) && (row["BreastEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.BreastEx = row["BreastEx"].ToString();
                }
                if ((row["AnusEx"] != null) && (row["AnusEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.AnusEx = row["AnusEx"].ToString();
                }
                if ((row["BreathSoundsEx"] != null) && (row["BreathSoundsEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.BreathSoundsEx = row["BreathSoundsEx"].ToString();
                }
                if ((row["RaleEx"] != null) && (row["RaleEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.RaleEx = row["RaleEx"].ToString();
                }
                if ((row["NoiseEx"] != null) && (row["NoiseEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.NoiseEx = row["NoiseEx"].ToString();
                }
                if ((row["CervixUteriEx"] != null) && (row["CervixUteriEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.CervixUteriEx = row["CervixUteriEx"].ToString();
                }
                if ((row["CorpusEx"] != null) && (row["CorpusEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.CorpusEx = row["CorpusEx"].ToString();
                }
                if ((row["AttachEx"] != null) && (row["AttachEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.AttachEx = row["AttachEx"].ToString();
                }
                if ((row["VulvaEx"] != null) && (row["VulvaEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.VulvaEx = row["VulvaEx"].ToString();
                }
                if ((row["VaginaEx"] != null) && (row["VaginaEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.VaginaEx = row["VaginaEx"].ToString();
                }
                if ((row["PressPainEx"] != null) && (row["PressPainEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.PressPainEx = row["PressPainEx"].ToString();
                }
                if ((row["LiverEx"] != null) && (row["LiverEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.LiverEx = row["LiverEx"].ToString();
                }
                if ((row["SpleenEx"] != null) && (row["SpleenEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.SpleenEx = row["SpleenEx"].ToString();
                }
                if ((row["VoicedEx"] != null) && (row["VoicedEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.VoicedEx = row["VoicedEx"].ToString();
                }
                if ((row["EnclosedMassEx"] != null) && (row["EnclosedMassEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.EnclosedMassEx = row["EnclosedMassEx"].ToString();
                }
                if ((row["EyeRound"] != null) && (row["EyeRound"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.EyeRound = row["EyeRound"].ToString();
                }
                if ((row["EyeRoundEx"] != null) && (row["EyeRoundEx"] != DBNull.Value))
                {
                    recordsPhysicalExamModel.EyeRoundEx = row["EyeRoundEx"].ToString();
                }
            }
            return recordsPhysicalExamModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_PHYSICALEXAM ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_PHYSICALEXAM ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_PHYSICALEXAM");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,Skin,Sclere,Lymph,BarrelChest,BreathSounds,Rale,");
            builder.Append("HeartRate,HeartRhythm,Noise,EnclosedMass,Edema,FootBack,Anus,Breast,Vulva,Vagina,");
            builder.Append("CervixUteri,Corpus,Attach,Other,PressPain,Liver,Spleen,Voiced,SkinEx,SclereEx,LymphEx,");
            builder.Append("BreastEx,AnusEx,BreathSoundsEx,RaleEx,NoiseEx,CervixUteriEx,CorpusEx,AttachEx,VulvaEx,");
            builder.Append("VaginaEx,PressPainEx,LiverEx,SpleenEx,VoicedEx,EnclosedMassEx,EyeRound,EyeRoundEx ");
            builder.Append(" FROM ARCHIVE_PHYSICALEXAM ");

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
            builder.Append(")AS Row, T.*  from ARCHIVE_PHYSICALEXAM T ");
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
            return MySQLHelper.GetMaxID("ID", "ARCHIVE_PHYSICALEXAM");
        }

        public RecordsPhysicalExamModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,Skin,Sclere,Lymph,BarrelChest,BreathSounds,Rale,HeartRate,");
            builder.Append("HeartRhythm,Noise,EnclosedMass,Edema,FootBack,Anus,Breast,Vulva,Vagina,CervixUteri,Corpus,");
            builder.Append("Attach,Other,PressPain,Liver,Spleen,Voiced,SkinEx,SclereEx,LymphEx,BreastEx,AnusEx,BreathSoundsEx,");
            builder.Append("RaleEx,NoiseEx,CervixUteriEx,CorpusEx,AttachEx,VulvaEx,VaginaEx,PressPainEx,LiverEx,SpleenEx,VoicedEx,");
            builder.Append("EnclosedMassEx,EyeRound,EyeRoundEx from ARCHIVE_PHYSICALEXAM ");
            builder.Append(" where IDCardNo=@IDCardNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;

            new RecordsPhysicalExamModel();
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
            builder.Append("select count(1) FROM ARCHIVE_PHYSICALEXAM ");
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

        public bool Update(RecordsPhysicalExamModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_PHYSICALEXAM set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Skin=@Skin,");
            builder.Append("Sclere=@Sclere,");
            builder.Append("Lymph=@Lymph,");
            builder.Append("BarrelChest=@BarrelChest,");
            builder.Append("BreathSounds=@BreathSounds,");
            builder.Append("Rale=@Rale,");
            builder.Append("HeartRate=@HeartRate,");
            builder.Append("HeartRhythm=@HeartRhythm,");
            builder.Append("Noise=@Noise,");
            builder.Append("EnclosedMass=@EnclosedMass,");
            builder.Append("Edema=@Edema,");
            builder.Append("FootBack=@FootBack,");
            builder.Append("Anus=@Anus,");
            builder.Append("Breast=@Breast,");
            builder.Append("Vulva=@Vulva,");
            builder.Append("Vagina=@Vagina,");
            builder.Append("CervixUteri=@CervixUteri,");
            builder.Append("Corpus=@Corpus,");
            builder.Append("Attach=@Attach,");
            builder.Append("Other=@Other,");
            builder.Append("PressPain=@PressPain,");
            builder.Append("Liver=@Liver,");
            builder.Append("Spleen=@Spleen,");
            builder.Append("Voiced=@Voiced,");
            builder.Append("SkinEx=@SkinEx,");
            builder.Append("SclereEx=@SclereEx,");
            builder.Append("LymphEx=@LymphEx,");
            builder.Append("BreastEx=@BreastEx,");
            builder.Append("AnusEx=@AnusEx,");
            builder.Append("BreathSoundsEx=@BreathSoundsEx,");
            builder.Append("RaleEx=@RaleEx,");
            builder.Append("NoiseEx=@NoiseEx,");
            builder.Append("CervixUteriEx=@CervixUteriEx,");
            builder.Append("CorpusEx=@CorpusEx,");
            builder.Append("AttachEx=@AttachEx,");
            builder.Append("VulvaEx=@VulvaEx,");
            builder.Append("VaginaEx=@VaginaEx,");
            builder.Append("PressPainEx=@PressPainEx,");
            builder.Append("LiverEx=@LiverEx,");
            builder.Append("SpleenEx=@SpleenEx,");
            builder.Append("VoicedEx=@VoicedEx,");
            builder.Append("EnclosedMassEx=@EnclosedMassEx,");
            builder.Append("EyeRound=@EyeRound,");
            builder.Append("EyeRoundEx=@EyeRoundEx");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
               new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Skin", MySqlDbType.String, 50), 
                new MySqlParameter("@Sclere", MySqlDbType.String, 50), 
                new MySqlParameter("@Lymph", MySqlDbType.String, 50), 
                new MySqlParameter("@BarrelChest", MySqlDbType.String, 1), 
                new MySqlParameter("@BreathSounds", MySqlDbType.String, 1), 
                new MySqlParameter("@Rale", MySqlDbType.String, 50), 
                new MySqlParameter("@HeartRate", MySqlDbType.String, 8), 
                new MySqlParameter("@HeartRhythm", MySqlDbType.String, 1), 
                new MySqlParameter("@Noise", MySqlDbType.String, 1), 
                new MySqlParameter("@EnclosedMass", MySqlDbType.String, 1), 
                new MySqlParameter("@Edema", MySqlDbType.String, 1), 
                new MySqlParameter("@FootBack", MySqlDbType.String, 1), 
                new MySqlParameter("@Anus", MySqlDbType.String, 50), 
                new MySqlParameter("@Breast", MySqlDbType.String, 50), 
                new MySqlParameter("@Vulva", MySqlDbType.String, 1),
                new MySqlParameter("@Vagina", MySqlDbType.String, 1),
                new MySqlParameter("@CervixUteri", MySqlDbType.String, 1), 
                new MySqlParameter("@Corpus", MySqlDbType.String, 1), 
                new MySqlParameter("@Attach", MySqlDbType.String, 1), 
                new MySqlParameter("@Other", MySqlDbType.String, 500), 
                new MySqlParameter("@PressPain", MySqlDbType.String, 1),
                new MySqlParameter("@Liver", MySqlDbType.String, 1), 
                new MySqlParameter("@Spleen", MySqlDbType.String, 1), 
                new MySqlParameter("@Voiced", MySqlDbType.String, 1), 
                new MySqlParameter("@SkinEx", MySqlDbType.String, 200), 
                new MySqlParameter("@SclereEx", MySqlDbType.String, 200),
                new MySqlParameter("@LymphEx", MySqlDbType.String, 200), 
                new MySqlParameter("@BreastEx", MySqlDbType.String, 200), 
                new MySqlParameter("@AnusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@BreathSoundsEx", MySqlDbType.String, 200), 
                new MySqlParameter("@RaleEx", MySqlDbType.String, 200), 
                new MySqlParameter("@NoiseEx", MySqlDbType.String, 200), 
                new MySqlParameter("@CervixUteriEx", MySqlDbType.String, 200),
                new MySqlParameter("@CorpusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@AttachEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VulvaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VaginaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@PressPainEx", MySqlDbType.String, 200),
                new MySqlParameter("@LiverEx", MySqlDbType.String, 200), 
                new MySqlParameter("@SpleenEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VoicedEx", MySqlDbType.String, 200), 
                new MySqlParameter("@EnclosedMassEx", MySqlDbType.String, 200), 
                new MySqlParameter("@EyeRound", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeRoundEx", MySqlDbType.String, 200), 
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Skin;
            cmdParms[3].Value = model.Sclere;
            cmdParms[4].Value = model.Lymph;
            cmdParms[5].Value = model.BarrelChest;
            cmdParms[6].Value = model.BreathSounds;
            cmdParms[7].Value = model.Rale;
            cmdParms[8].Value = model.HeartRate;
            cmdParms[9].Value = model.HeartRhythm;
            cmdParms[10].Value = model.Noise;
            cmdParms[11].Value = model.EnclosedMass;
            cmdParms[12].Value = model.Edema;
            cmdParms[13].Value = model.FootBack;
            cmdParms[14].Value = model.Anus;
            cmdParms[15].Value = model.Breast;
            cmdParms[16].Value = model.Vulva;
            cmdParms[17].Value = model.Vagina;
            cmdParms[18].Value = model.CervixUteri;
            cmdParms[19].Value = model.Corpus;
            cmdParms[20].Value = model.Attach;
            cmdParms[21].Value = model.Other;
            cmdParms[22].Value = model.PressPain;
            cmdParms[23].Value = model.Liver;
            cmdParms[24].Value = model.Spleen;
            cmdParms[25].Value = model.Voiced;
            cmdParms[26].Value = model.SkinEx;
            cmdParms[27].Value = model.SclereEx;
            cmdParms[28].Value = model.LymphEx;
            cmdParms[29].Value = model.BreastEx;
            cmdParms[30].Value = model.AnusEx;
            cmdParms[31].Value = model.BreathSoundsEx;
            cmdParms[32].Value = model.RaleEx;
            cmdParms[33].Value = model.NoiseEx;
            cmdParms[34].Value = model.CervixUteriEx;
            cmdParms[35].Value = model.CorpusEx;
            cmdParms[36].Value = model.AttachEx;
            cmdParms[37].Value = model.VulvaEx;
            cmdParms[38].Value = model.VaginaEx;
            cmdParms[39].Value = model.PressPainEx;
            cmdParms[40].Value = model.LiverEx;
            cmdParms[41].Value = model.SpleenEx;
            cmdParms[42].Value = model.VoicedEx;
            cmdParms[43].Value = model.EnclosedMassEx;
            cmdParms[44].Value = model.EyeRound;
            cmdParms[45].Value = model.EyeRoundEx;
            cmdParms[0x2e].Value = model.OutKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsPhysicalExamModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_PHYSICALEXAM set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Skin=@Skin,");
            builder.Append("Sclere=@Sclere,");
            builder.Append("Lymph=@Lymph,");
            builder.Append("BarrelChest=@BarrelChest,");
            builder.Append("BreathSounds=@BreathSounds,");
            builder.Append("Rale=@Rale,");
            builder.Append("HeartRate=@HeartRate,");
            builder.Append("HeartRhythm=@HeartRhythm,");
            builder.Append("Noise=@Noise,");
            builder.Append("EnclosedMass=@EnclosedMass,");
            builder.Append("Edema=@Edema,");
            builder.Append("FootBack=@FootBack,");
            builder.Append("Anus=@Anus,");
            builder.Append("Breast=@Breast,");
            builder.Append("Vulva=@Vulva,");
            builder.Append("Vagina=@Vagina,");
            builder.Append("CervixUteri=@CervixUteri,");
            builder.Append("Corpus=@Corpus,");
            builder.Append("Attach=@Attach,");
            builder.Append("Other=@Other,");
            builder.Append("PressPain=@PressPain,");
            builder.Append("Liver=@Liver,");
            builder.Append("Spleen=@Spleen,");
            builder.Append("Voiced=@Voiced,");
            builder.Append("SkinEx=@SkinEx,");
            builder.Append("SclereEx=@SclereEx,");
            builder.Append("LymphEx=@LymphEx,");
            builder.Append("BreastEx=@BreastEx,");
            builder.Append("AnusEx=@AnusEx,");
            builder.Append("BreathSoundsEx=@BreathSoundsEx,");
            builder.Append("RaleEx=@RaleEx,");
            builder.Append("NoiseEx=@NoiseEx,");
            builder.Append("CervixUteriEx=@CervixUteriEx,");
            builder.Append("CorpusEx=@CorpusEx,");
            builder.Append("AttachEx=@AttachEx,");
            builder.Append("VulvaEx=@VulvaEx,");
            builder.Append("VaginaEx=@VaginaEx,");
            builder.Append("PressPainEx=@PressPainEx,");
            builder.Append("LiverEx=@LiverEx,");
            builder.Append("SpleenEx=@SpleenEx,");
            builder.Append("VoicedEx=@VoicedEx,");
            builder.Append("EnclosedMassEx=@EnclosedMassEx,");
            builder.Append("EyeRound=@EyeRound,");
            builder.Append("EyeRoundEx=@EyeRoundEx");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
               new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Skin", MySqlDbType.String, 50), 
                new MySqlParameter("@Sclere", MySqlDbType.String, 50), 
                new MySqlParameter("@Lymph", MySqlDbType.String, 50), 
                new MySqlParameter("@BarrelChest", MySqlDbType.String, 1), 
                new MySqlParameter("@BreathSounds", MySqlDbType.String, 1), 
                new MySqlParameter("@Rale", MySqlDbType.String, 50), 
                new MySqlParameter("@HeartRate", MySqlDbType.String, 8), 
                new MySqlParameter("@HeartRhythm", MySqlDbType.String, 1), 
                new MySqlParameter("@Noise", MySqlDbType.String, 1), 
                new MySqlParameter("@EnclosedMass", MySqlDbType.String, 1), 
                new MySqlParameter("@Edema", MySqlDbType.String, 1), 
                new MySqlParameter("@FootBack", MySqlDbType.String, 1), 
                new MySqlParameter("@Anus", MySqlDbType.String, 50), 
                new MySqlParameter("@Breast", MySqlDbType.String, 50), 
                new MySqlParameter("@Vulva", MySqlDbType.String, 1),
                new MySqlParameter("@Vagina", MySqlDbType.String, 1),
                new MySqlParameter("@CervixUteri", MySqlDbType.String, 1), 
                new MySqlParameter("@Corpus", MySqlDbType.String, 1), 
                new MySqlParameter("@Attach", MySqlDbType.String, 1), 
                new MySqlParameter("@Other", MySqlDbType.String, 500), 
                new MySqlParameter("@PressPain", MySqlDbType.String, 1),
                new MySqlParameter("@Liver", MySqlDbType.String, 1), 
                new MySqlParameter("@Spleen", MySqlDbType.String, 1), 
                new MySqlParameter("@Voiced", MySqlDbType.String, 1), 
                new MySqlParameter("@SkinEx", MySqlDbType.String, 200), 
                new MySqlParameter("@SclereEx", MySqlDbType.String, 200),
                new MySqlParameter("@LymphEx", MySqlDbType.String, 200), 
                new MySqlParameter("@BreastEx", MySqlDbType.String, 200), 
                new MySqlParameter("@AnusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@BreathSoundsEx", MySqlDbType.String, 200), 
                new MySqlParameter("@RaleEx", MySqlDbType.String, 200), 
                new MySqlParameter("@NoiseEx", MySqlDbType.String, 200), 
                new MySqlParameter("@CervixUteriEx", MySqlDbType.String, 200),
                new MySqlParameter("@CorpusEx", MySqlDbType.String, 200), 
                new MySqlParameter("@AttachEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VulvaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VaginaEx", MySqlDbType.String, 200), 
                new MySqlParameter("@PressPainEx", MySqlDbType.String, 200),
                new MySqlParameter("@LiverEx", MySqlDbType.String, 200), 
                new MySqlParameter("@SpleenEx", MySqlDbType.String, 200), 
                new MySqlParameter("@VoicedEx", MySqlDbType.String, 200), 
                new MySqlParameter("@EnclosedMassEx", MySqlDbType.String, 200), 
                new MySqlParameter("@EyeRound", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeRoundEx", MySqlDbType.String, 200), 
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Skin;
            cmdParms[3].Value = model.Sclere;
            cmdParms[4].Value = model.Lymph;
            cmdParms[5].Value = model.BarrelChest;
            cmdParms[6].Value = model.BreathSounds;
            cmdParms[7].Value = model.Rale;
            cmdParms[8].Value = model.HeartRate;
            cmdParms[9].Value = model.HeartRhythm;
            cmdParms[10].Value = model.Noise;
            cmdParms[11].Value = model.EnclosedMass;
            cmdParms[12].Value = model.Edema;
            cmdParms[13].Value = model.FootBack;
            cmdParms[14].Value = model.Anus;
            cmdParms[15].Value = model.Breast;
            cmdParms[16].Value = model.Vulva;
            cmdParms[17].Value = model.Vagina;
            cmdParms[18].Value = model.CervixUteri;
            cmdParms[19].Value = model.Corpus;
            cmdParms[20].Value = model.Attach;
            cmdParms[21].Value = model.Other;
            cmdParms[22].Value = model.PressPain;
            cmdParms[23].Value = model.Liver;
            cmdParms[24].Value = model.Spleen;
            cmdParms[25].Value = model.Voiced;
            cmdParms[26].Value = model.SkinEx;
            cmdParms[27].Value = model.SclereEx;
            cmdParms[28].Value = model.LymphEx;
            cmdParms[29].Value = model.BreastEx;
            cmdParms[30].Value = model.AnusEx;
            cmdParms[31].Value = model.BreathSoundsEx;
            cmdParms[32].Value = model.RaleEx;
            cmdParms[33].Value = model.NoiseEx;
            cmdParms[34].Value = model.CervixUteriEx;
            cmdParms[35].Value = model.CorpusEx;
            cmdParms[36].Value = model.AttachEx;
            cmdParms[37].Value = model.VulvaEx;
            cmdParms[38].Value = model.VaginaEx;
            cmdParms[39].Value = model.PressPainEx;
            cmdParms[40].Value = model.LiverEx;
            cmdParms[41].Value = model.SpleenEx;
            cmdParms[42].Value = model.VoicedEx;
            cmdParms[43].Value = model.EnclosedMassEx;
            cmdParms[44].Value = model.EyeRound;
            cmdParms[45].Value = model.EyeRoundEx;
           // cmdParms[0x2e].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public RecordsPhysicalExamModel GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,Skin,Sclere,Lymph,BarrelChest,BreathSounds,Rale,HeartRate,");
            builder.Append("HeartRhythm,Noise,EnclosedMass,Edema,FootBack,Anus,Breast,Vulva,Vagina,CervixUteri,Corpus,");
            builder.Append("Attach,Other,PressPain,Liver,Spleen,Voiced,SkinEx,SclereEx,LymphEx,BreastEx,AnusEx,BreathSoundsEx,");
            builder.Append("RaleEx,NoiseEx,CervixUteriEx,CorpusEx,AttachEx,VulvaEx,VaginaEx,PressPainEx,LiverEx,SpleenEx,VoicedEx,");
            builder.Append("EnclosedMassEx,EyeRound,EyeRoundEx,OutKey from ARCHIVE_PHYSICALEXAM ");
            builder.Append(" where OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.String) };
            cmdParms[0].Value = OutKey;

            new RecordsPhysicalExamModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_PHYSICALEXAM");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) 
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OutKey;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public bool UpdateByTJMiniPad(RecordsPhysicalExamModel model, string checkDate) //体检问询同步
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"UPDATE 
                                    ARCHIVE_PHYSICALEXAM  D
                             SET 
                                BarrelChest=@BarrelChest,BreathSounds=@BreathSounds,Rale=@Rale,
                                HeartRhythm=@HeartRhythm,Noise=@Noise,PressPain=@PressPain,EnclosedMass=@EnclosedMass,
                                Liver=@Liver,Spleen=@Spleen,Voiced=@Voiced,Edema=@Edema,
                                FootBack=@FootBack,RaleEx=@RaleEx,BreathSoundsEx=@BreathSoundsEx,NoiseEx=@NoiseEx,
                                PressPainEx=@PressPainEx, EnclosedMassEx=@EnclosedMassEx,LiverEx=@LiverEx,
                                SpleenEx=@SpleenEx,VoicedEx=@VoicedEx 
                                
                             WHERE
                                    EXISTS
                                    (
                                        SELECT 
                                            ID 
                                        FROM
                                        ARCHIVE_CUSTOMERBASEINFO M
                                        WHERE M.ID = D.OutKey
                                        AND M.IDCardNo = @IDCardNo
                                        AND M.CheckDate = @CheckDate
                                    )
                            ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@CheckDate",checkDate),
                new MySqlParameter("@BarrelChest", model.BarrelChest),
                new MySqlParameter("@BreathSounds", model.BreathSounds),
                new MySqlParameter("@Rale", model.Rale),
                new MySqlParameter("@HeartRhythm", model.HeartRhythm),
                new MySqlParameter("@Noise", model.Noise),
                new MySqlParameter("@PressPain", model.PressPain),
                new MySqlParameter("@EnclosedMass", model.EnclosedMass),
                new MySqlParameter("@Liver", model.Liver),
                new MySqlParameter("@Spleen", model.Spleen),
                new MySqlParameter("@Voiced", model.Voiced),
                new MySqlParameter("@Edema", model.Edema),
                new MySqlParameter("@FootBack", model.FootBack),
                new MySqlParameter("@RaleEx",model.RaleEx),
                new MySqlParameter("@BreathSoundsEx",model.BreathSoundsEx),
                new MySqlParameter("@NoiseEx",model.NoiseEx),
                new MySqlParameter("@PressPainEx",model.PressPainEx),
                new MySqlParameter("@EnclosedMassEx",model.EnclosedMassEx),
                new MySqlParameter("@LiverEx",model.LiverEx),
                new MySqlParameter("@SpleenEx",model.SpleenEx),
                new MySqlParameter("@VoicedEx",model.VoicedEx)

             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

