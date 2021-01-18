namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
	using MySql.Data.MySqlClient;
	using CommonModel;
	using CommonUtilities.SQL;
	using System;
	using System.Data;
	using System.Text;

    public class RecordsPhysicalExamDAL
    {
        public int Add(RecordsPhysicalExamModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_PHYSICALEXAM(");
            builder.Append("PhysicalID,IDCardNo,Skin,Sclere,Lymph,BarrelChest,BreathSounds,Rale,HeartRate, ");
            builder.Append("HeartRhythm,Noise,EnclosedMass,Edema,FootBack,Anus,Breast,Vulva,Vagina,CervixUteri, ");
            builder.Append("Corpus,Attach,Other,PressPain,Liver,Spleen,Voiced,SkinEx,SclereEx,LymphEx,BreastEx, ");
            builder.Append("AnusEx,BreathSoundsEx,RaleEx,NoiseEx,CervixUteriEx,CorpusEx,AttachEx,VulvaEx, ");
            builder.Append("VaginaEx,PressPainEx,LiverEx,SpleenEx,VoicedEx,EnclosedMassEx,EyeRound,EyeRoundEx,OutKey)");
            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@IDCardNo,@Skin,@Sclere,@Lymph,@BarrelChest,@BreathSounds,@Rale,@HeartRate, ");
            builder.Append("@HeartRhythm,@Noise,@EnclosedMass,@Edema,@FootBack,@Anus,@Breast,@Vulva,@Vagina,@CervixUteri, ");
            builder.Append("@Corpus,@Attach,@Other,@PressPain,@Liver,@Spleen,@Voiced,@SkinEx,@SclereEx,@LymphEx,@BreastEx, ");
            builder.Append("@AnusEx,@BreathSoundsEx,@RaleEx,@NoiseEx,@CervixUteriEx,@CorpusEx,@AttachEx,@VulvaEx, ");
            builder.Append("@VaginaEx,@PressPainEx,@LiverEx,@SpleenEx,@VoicedEx,@EnclosedMassEx,@EyeRound,@EyeRoundEx,@OutKey)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@PhysicalID", MySqlDbType.String,100 ), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Skin", MySqlDbType.String, 50), 
                new MySqlParameter("@Sclere", MySqlDbType.String, 50), 
                new MySqlParameter("@Lymph", MySqlDbType.String, 1), 
                new MySqlParameter("@BarrelChest", MySqlDbType.String, 1), 
                new MySqlParameter("@BreathSounds", MySqlDbType.String, 1), 
                new MySqlParameter("@Rale", MySqlDbType.String, 50), 
                new MySqlParameter("@HeartRate", MySqlDbType.String, 100), 
                new MySqlParameter("@HeartRhythm", MySqlDbType.String, 1), 
                new MySqlParameter("@Noise", MySqlDbType.String, 1), 
                new MySqlParameter("@EnclosedMass", MySqlDbType.String, 1), 
                new MySqlParameter("@Edema", MySqlDbType.String, 1), 
                new MySqlParameter("@FootBack", MySqlDbType.String, 1), 
                new MySqlParameter("@Anus", MySqlDbType.String, 50), 
                new MySqlParameter("@Breast", MySqlDbType.String, 100), 
                new MySqlParameter("@Vulva", MySqlDbType.String, 1),
                new MySqlParameter("@Vagina", MySqlDbType.String, 1),
                new MySqlParameter("@CervixUteri", MySqlDbType.String, 1), 
                new MySqlParameter("@Corpus", MySqlDbType.String, 1), 
                new MySqlParameter("@Attach", MySqlDbType.String, 1), 
                new MySqlParameter("@Other", MySqlDbType.String, 100), 
                new MySqlParameter("@PressPain", MySqlDbType.String, 1),
                new MySqlParameter("@Liver", MySqlDbType.String, 1), 
                new MySqlParameter("@Spleen", MySqlDbType.String, 1), 
                new MySqlParameter("@Voiced", MySqlDbType.String, 1), 
                new MySqlParameter("@SkinEx", MySqlDbType.String, 100), 
                new MySqlParameter("@SclereEx", MySqlDbType.String, 100),
                new MySqlParameter("@LymphEx", MySqlDbType.String, 100), 
                new MySqlParameter("@BreastEx", MySqlDbType.String, 100), 
                new MySqlParameter("@AnusEx", MySqlDbType.String, 100), 
                new MySqlParameter("@BreathSoundsEx", MySqlDbType.String,100), 
                new MySqlParameter("@RaleEx", MySqlDbType.String, 100), 
                new MySqlParameter("@NoiseEx", MySqlDbType.String, 100), 
                new MySqlParameter("@CervixUteriEx", MySqlDbType.String, 100),
                new MySqlParameter("@CorpusEx", MySqlDbType.String, 100), 
                new MySqlParameter("@AttachEx", MySqlDbType.String, 100), 
                new MySqlParameter("@VulvaEx", MySqlDbType.String, 100), 
                new MySqlParameter("@VaginaEx", MySqlDbType.String, 100), 
                new MySqlParameter("@PressPainEx", MySqlDbType.String, 100),
                new MySqlParameter("@LiverEx", MySqlDbType.String, 100), 
                new MySqlParameter("@SpleenEx", MySqlDbType.String, 100), 
                new MySqlParameter("@VoicedEx", MySqlDbType.String, 100), 
                new MySqlParameter("@EnclosedMassEx", MySqlDbType.String, 100), 
                new MySqlParameter("@EyeRound", MySqlDbType.String, 1), 
                new MySqlParameter("@EyeRoundEx", MySqlDbType.String, 100),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,11)
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

        public DataSet GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_PHYSICALEXAM ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.String) };
            cmdParms[0].Value = OutKey;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 心电更新查体心律、心率
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="OutKey"></param>
        /// <param name="HeartRhythm"></param>
        /// <param name="HeartRate"></param>
        /// <returns></returns>
        public bool Update(string IDCardNo, string OutKey, string HeartRhythm, string HeartRate)
        {
            StringBuilder builder = new StringBuilder();
            string sql = "";

            builder.Append("UPDATE ARCHIVE_PHYSICALEXAM SET ");

            if (HeartRhythm != "") sql += "HeartRhythm=@HeartRhythm,";
            if (HeartRate != "") sql += "HeartRate=@HeartRate,";

            builder.Append(sql.TrimEnd(','));

            if (builder.ToString() != "UPDATE ARCHIVE_PHYSICALEXAM SET ")
            {
                builder.Append(@" WHERE IDCardNo = @IDCardNo
                                            AND OutKey = @OutKey ");
            }

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", IDCardNo),
                new MySqlParameter("@OutKey",OutKey),
                new MySqlParameter("@HeartRhythm", HeartRhythm),
                new MySqlParameter("@HeartRate", HeartRate)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

