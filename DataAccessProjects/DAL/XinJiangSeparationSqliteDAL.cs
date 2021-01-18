namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using KangShuoTech.Utilities.SQLiteHelper;

    public class XinJiangSeparationSqliteDAL
    {
        #region 五官

        /// <summary>
        /// 取得对应条件的五官科资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string conn = "")
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(@"
                            SELECT
                                ID
                                ,IDCardNo
                                ,RecordDate
                                ,Lips
                                ,ToothResides
                                ,MissingTeeth AS HypodontiaEx
                                ,Caries AS SaprodontiaEx
                                ,Denture AS DentureEx
                                ,Pharyngeal
                                ,Listen
                                ,LeftView
                                ,RightView
                                ,LeftEyecorrect
                                ,RightEyecorrect
                            FROM 
                                tbl_Mouth ");

            if (strWhere.Trim() != "")
            {
                sbQuery.Append(" WHERE 1=1 " + strWhere);
            }

            return YcSqliteHelper.Query(sbQuery.ToString(), conn);
        }

        /// <summary>
        /// 更新终端资料库中的脏器资料--五官
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateByMouth(RecordsVisceraFunctionModel model, string RecordDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            UPDATE 
                                ARCHIVE_VISCERAFUNCTION D
                            SET 
                                Lips = @Lips
                                ,ToothResides= @ToothResides
                                ,Pharyngeal= @Pharyngeal
                                ,LeftView= @LeftView
                                ,Listen= @Listen
                                ,RightView= @RightView
                                ,LeftEyecorrect= @LeftEyecorrect
                                ,RightEyecorrect= @RightEyecorrect
                                ,HypodontiaEx = @HypodontiaEx
                                ,SaprodontiaEx = @SaprodontiaEx
                                ,DentureEx = @DentureEx
                            WHERE 
                                D.OUTKEY=
                                (
                                    SELECT 
                                        M.ID 
                                    FROM
                                        ARCHIVE_CUSTOMERBASEINFO M 
                                    WHERE  
                                        IFNULL(M.IsDel,'')!='Y'
                                        AND M.IDCardNo =@IDCardNo 
                                        AND LEFT(M.CheckDate,4) = @CheckDate 
                                        order by M.CheckDate DESC LIMIT 0,1 
                                );  ");
            if (Convert.ToString(RecordDate).Length > 3) RecordDate = RecordDate.Substring(0, 4);
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Lips",model.Lips),
                new MySqlParameter("@ToothResides",model.ToothResides),
                new MySqlParameter("@HypodontiaEx",model.HypodontiaEx),
                new MySqlParameter("@SaprodontiaEx",model.SaprodontiaEx),
                new MySqlParameter("@DentureEx",model.DentureEx),
                new MySqlParameter("@Pharyngeal",model.Pharyngeal),
                new MySqlParameter("@Listen",model.Listen),
                new MySqlParameter("@LeftView",model.LeftView),
                new MySqlParameter("@RightView",model.RightView),
                new MySqlParameter("@LeftEyecorrect",model.LeftEyecorrect),
                new MySqlParameter("@RightEyecorrect",model.RightEyecorrect),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@CheckDate",RecordDate)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 更新终端资料库中的脏器资料--五官
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public void InsertByMouth(RecordsVisceraFunctionModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            INSERT INTO
                                ARCHIVE_VISCERAFUNCTION
                            (
                                PhysicalID
                                ,IDCardNo
                                ,Lips
                                ,ToothResides
                                ,Pharyngeal
                                ,LeftView
                                ,Listen
                                ,RightView
                                ,LeftEyecorrect
                                ,RightEyecorrect
                                ,OutKey
                                ,HypodontiaEx
                                ,SaprodontiaEx
                                ,DentureEx
                            )
                            VALUES
                             (
                                @PhysicalID
                                ,@IDCardNo
                                ,@Lips
                                ,@ToothResides
                                ,@Pharyngeal
                                ,@LeftView
                                ,@Listen
                                ,@RightView
                                ,@LeftEyecorrect
                                ,@RightEyecorrect
                                ,@OutKey
                                ,@HypodontiaEx
                                ,@SaprodontiaEx
                                ,@DentureEx
                            ) ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Lips",model.Lips),
                new MySqlParameter("@ToothResides",model.ToothResides),
                new MySqlParameter("@HypodontiaEx",model.HypodontiaEx),
                new MySqlParameter("@SaprodontiaEx",model.SaprodontiaEx),
                new MySqlParameter("@DentureEx",model.DentureEx),
                new MySqlParameter("@Pharyngeal",model.Pharyngeal),
                new MySqlParameter("@Listen",model.Listen),
                new MySqlParameter("@LeftView",model.LeftView),
                new MySqlParameter("@RightView",model.RightView),
                new MySqlParameter("@LeftEyecorrect",model.LeftEyecorrect),
                new MySqlParameter("@RightEyecorrect",model.RightEyecorrect),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@OutKey",model.OutKey),
                new MySqlParameter("@PhysicalID",model.PhysicalID)
             };

            MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);
        }

        #endregion

        #region 外科

        /// <summary>
        /// 取得对应条件的外科资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetSurgicalList(string strWhere, string conn = "")
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(@"
                            SELECT
                                ID
                                ,IDCardNo
                                ,RecordDate
                                ,SportFunction
                                ,Skin
                                ,SkinEx
                                ,Sclera AS Sclere
                                ,ScleraEx AS SclereEx
                                ,Lymph
                                ,LymphEx
                                ,PressPain
                                ,PressPainEx
                                ,EnclosedMass
                                ,EnclosedMassEx
                                ,Liver
                                ,LiverEx
                                ,Spleen
                                ,SpleenEx
                                ,Voiced
                                ,VoicedEx
                                ,Edema
                                ,FootBack
                                ,ElseDis
                                ,ElseOther
                                ,Other
                            FROM 
                                tbl_Surgical ");

            if (strWhere.Trim() != "")
            {
                sbQuery.Append(" WHERE 1=1 " + strWhere);
            }

            return YcSqliteHelper.Query(sbQuery.ToString(), conn);
        }

        /// <summary>
        /// 更新终端资料库中的查体资料--外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateBySurgical(RecordsPhysicalExamModel model, string RecordDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            UPDATE 
                                ARCHIVE_PHYSICALEXAM D
                            SET 
                                Skin = @Skin 
                                ,SkinEx = @SkinEx 
                                ,Sclere = @Sclere 
                                ,SclereEx = @SclereEx 
                                ,Lymph = @Lymph 
                                ,LymphEx = @LymphEx 
                                ,PressPain = @PressPain 
                                ,PressPainEx = @PressPainEx 
                                ,EnclosedMass = @EnclosedMass 
                                ,EnclosedMassEx = @EnclosedMassEx 
                                ,Liver = @Liver 
                                ,LiverEx = @LiverEx 
                                ,Spleen = @Spleen 
                                ,SpleenEx = @SpleenEx 
                                ,Voiced = @Voiced 
                                ,VoicedEx = @VoicedEx 
                                ,Edema = @Edema 
                                ,FootBack = @FootBack 
                                ,Other = @Other 
                            WHERE 
                              D.OUTKEY=
                                (
                                    SELECT 
                                        M.ID 
                                    FROM
                                        ARCHIVE_CUSTOMERBASEINFO M 
                                    WHERE  
                                        IFNULL(M.IsDel,'')!='Y'
                                        AND M.IDCardNo =@IDCardNo 
                                        AND LEFT(M.CheckDate,4) = @CheckDate 
                                        order by M.CheckDate DESC LIMIT 0,1 
                                );  ");
            if (Convert.ToString(RecordDate).Length > 3) RecordDate = RecordDate.Substring(0, 4);
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Skin",model.Skin),
                new MySqlParameter("@SkinEx",model.SkinEx),
                new MySqlParameter("@Sclere",model.Sclere),
                new MySqlParameter("@SclereEx",model.SclereEx),
                new MySqlParameter("@Lymph",model.Lymph),
                new MySqlParameter("@LymphEx",model.LymphEx),
                new MySqlParameter("@PressPain",model.PressPain),
                new MySqlParameter("@PressPainEx",model.PressPainEx),
                new MySqlParameter("@EnclosedMass",model.EnclosedMass),
                new MySqlParameter("@EnclosedMassEx",model.EnclosedMassEx),
                new MySqlParameter("@Liver",model.Liver),
                new MySqlParameter("@LiverEx",model.LiverEx),
                new MySqlParameter("@Spleen",model.Spleen),
                new MySqlParameter("@SpleenEx",model.SpleenEx),
                new MySqlParameter("@Voiced",model.Voiced),
                new MySqlParameter("@VoicedEx",model.VoicedEx),
                new MySqlParameter("@Edema",model.Edema),
                new MySqlParameter("@FootBack",model.FootBack),
                new MySqlParameter("@Other",model.Other),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@CheckDate",RecordDate)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 更新终端资料库中的脏器资料--外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateVisceraBySurgical(RecordsPhysicalExamModel model, string RecordDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            UPDATE 
                                ARCHIVE_VISCERAFUNCTION D
                            SET 
                                SportFunction = @SportFunction
                            WHERE 
                                D.OUTKEY=
                                (
                                    SELECT 
                                        M.ID 
                                    FROM
                                        ARCHIVE_CUSTOMERBASEINFO M 
                                    WHERE  
                                        IFNULL(M.IsDel,'')!='Y'
                                        AND M.IDCardNo =@IDCardNo 
                                        AND LEFT(M.CheckDate,4) = @CheckDate 
                                        order by M.CheckDate DESC LIMIT 0,1 
                                );  ");
            if (Convert.ToString(RecordDate).Length > 3) RecordDate = RecordDate.Substring(0, 4);
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@SportFunction",model.SportFunction),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@CheckDate",RecordDate)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 更新终端资料库中的健康资料--外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateHealthBySurgical(RecordsPhysicalExamModel model, string RecordDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            UPDATE 
                                ARCHIVE_HEALTHQUESTION D
                            SET 
                                ElseDis = @ElseDis
                                ,ElseOther = @ElseOther
                            WHERE 
                                D.OUTKEY=
                                (
                                    SELECT 
                                        M.ID 
                                    FROM
                                        ARCHIVE_CUSTOMERBASEINFO M 
                                    WHERE  
                                        IFNULL(M.IsDel,'')!='Y'
                                        AND M.IDCardNo =@IDCardNo 
                                        AND LEFT(M.CheckDate,4) = @CheckDate 
                                        order by M.CheckDate DESC LIMIT 0,1 
                                );  ");
            if (Convert.ToString(RecordDate).Length > 3) RecordDate = RecordDate.Substring(0, 4);
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ElseDis",model.ElseDis),
                new MySqlParameter("@ElseOther",model.ElseOther),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@CheckDate",RecordDate)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 新增终端资料库中的脏器资料--外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public void InsertVisceraBySurgical(RecordsPhysicalExamModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            INSERT INTO 
                                ARCHIVE_VISCERAFUNCTION 
                            (
                                PhysicalID
                                ,IDCardNo
                                ,SportFunction
                                ,OutKey
                            )
                            VALUES
                             (
                                @PhysicalID
                                ,@IDCardNo
                                ,@SportFunction
                                ,@OutKey
                             )  ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@SportFunction",model.SportFunction),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@OutKey",model.OutKey),
                new MySqlParameter("@PhysicalID",model.PhysicalID)
             };

            MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 新增终端资料库中的健康资料--外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public void InsertHealthBySurgical(RecordsPhysicalExamModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            INSERT INTO 
                                ARCHIVE_HEALTHQUESTION 
                            (
                                PhysicalID
                                ,IDCardNo
                                ,ElseDis
                                ,ElseOther
                                ,OutKey
                            )
                            VALUES
                             (
                                @PhysicalID
                                ,@IDCardNo
                                ,@ElseDis
                                ,@ElseOther
                                ,@OutKey
                             )  ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@ElseDis",model.ElseDis),
                new MySqlParameter("@ElseOther",model.ElseOther),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@OutKey",model.OutKey),
                new MySqlParameter("@PhysicalID",model.PhysicalID)
             };

            MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);
        }

        #endregion

        #region 内科

        /// <summary>
        /// 取得对应条件的内科资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetInternalMedicineList(string strWhere, string conn = "")
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(@"
                            SELECT
                                ID
                                ,IDCardNo
                                ,RecordDate
                                ,EyeRound
                                ,EyeRoundEx
                                ,BarrelChest
                                ,BreathSounds
                                ,BreathSoundsEx
                                ,Rale
                                ,RaleEx
                                ,HeartRate
                                ,HeartRhythm
                                ,Noise
                                ,NoiseEx
                                ,Anus
                                ,AnusEx
                                ,Breast
                                ,BreastEx
                                ,Vulva
                                ,VulvaEx
                                ,Vagina
                                ,VaginaEx
                                ,CervixUteri
                                ,CervixUteriEx
                                ,Corpus
                                ,CorpusEx
                                ,Attach
                                ,AttachEx
                            FROM 
                                tbl_InternalMedicine ");

            if (strWhere.Trim() != "")
            {
                sbQuery.Append(" WHERE 1=1 " + strWhere);
            }

            return YcSqliteHelper.Query(sbQuery.ToString(), conn);
        }

        /// <summary>
        /// 更新终端资料库中的查体资料--内科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateByInternalMedicine(RecordsPhysicalExamModel model, string RecordDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            UPDATE 
                                ARCHIVE_PHYSICALEXAM D
                            SET 
                                EyeRound = @EyeRound 
                                ,EyeRoundEx = @EyeRoundEx 
                                ,BarrelChest = @BarrelChest 
                                ,BreathSounds = @BreathSounds 
                                ,BreathSoundsEx = @BreathSoundsEx 
                                ,Rale = @Rale 
                                ,RaleEx = @RaleEx 
                                ,HeartRhythm = @HeartRhythm 
                                ,Noise = @Noise 
                                ,NoiseEx = @NoiseEx 
                                ,Anus = @Anus 
                                ,AnusEx = @AnusEx 
                                ,Breast = @Breast 
                                ,BreastEx = @BreastEx 
                                ,Vulva = @Vulva 
                                ,VulvaEx = @VulvaEx 
                                ,Vagina = @Vagina 
                                ,VaginaEx = @VaginaEx 
                                ,CervixUteri = @CervixUteri 
                                ,CervixUteriEx = @CervixUteriEx 
                                ,Corpus = @Corpus 
                                ,CorpusEx = @CorpusEx 
                                ,Attach = @Attach 
                                ,AttachEx = @AttachEx 
                            WHERE 
                                D.OUTKEY=
                                (
                                    SELECT 
                                        M.ID 
                                    FROM
                                        ARCHIVE_CUSTOMERBASEINFO M 
                                    WHERE  
                                        IFNULL(M.IsDel,'')!='Y'
                                        AND M.IDCardNo =@IDCardNo 
                                        AND LEFT(M.CheckDate,4) = @CheckDate 
                                        order by M.CheckDate DESC LIMIT 0,1 
                                );  ");

            if (Convert.ToString(RecordDate).Length > 3) RecordDate = RecordDate.Substring(0, 4);

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@EyeRound",model.EyeRound),
                new MySqlParameter("@EyeRoundEx",model.EyeRoundEx),
                new MySqlParameter("@BarrelChest",model.BarrelChest),
                new MySqlParameter("@BreathSounds",model.BreathSounds),
                new MySqlParameter("@BreathSoundsEx",model.BreathSoundsEx),
                new MySqlParameter("@Rale",model.Rale),
                new MySqlParameter("@RaleEx",model.RaleEx),
                new MySqlParameter("@HeartRhythm",model.HeartRhythm),
                new MySqlParameter("@Noise",model.Noise),
                new MySqlParameter("@NoiseEx",model.NoiseEx),
                new MySqlParameter("@Anus",model.Anus),
                new MySqlParameter("@AnusEx",model.AnusEx),
                new MySqlParameter("@Breast",model.Breast),
                new MySqlParameter("@BreastEx",model.BreastEx),
                new MySqlParameter("@Vulva",model.Vulva),
                new MySqlParameter("@VulvaEx",model.VulvaEx),
                new MySqlParameter("@Vagina",model.Vagina),
                new MySqlParameter("@VaginaEx",model.VaginaEx),
                new MySqlParameter("@CervixUteri",model.CervixUteri),
                new MySqlParameter("@CervixUteriEx",model.CervixUteriEx),
                new MySqlParameter("@Corpus",model.Corpus),
                new MySqlParameter("@CorpusEx",model.CorpusEx),
                new MySqlParameter("@Attach",model.Attach),
                new MySqlParameter("@AttachEx",model.AttachEx),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@CheckDate",RecordDate)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 更新终端资料库中的查体资料--内科,外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public void Insert(RecordsPhysicalExamModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            INSERT INTO
                                ARCHIVE_PHYSICALEXAM
                            (
                                PhysicalID
                                ,IDCardNo
                                ,Skin
                                ,Sclere
                                ,Lymph
                                ,BarrelChest
                                ,BreathSounds
                                ,Rale
                                ,HeartRhythm
                                ,Noise
                                ,EnclosedMass
                                ,Edema
                                ,FootBack
                                ,Anus
                                ,Breast
                                ,Vulva
                                ,Vagina
                                ,CervixUteri
                                ,Corpus
                                ,Attach
                                ,Other
                                ,PressPain
                                ,Liver
                                ,Spleen
                                ,Voiced
                                ,SkinEx
                                ,SclereEx
                                ,LymphEx
                                ,BreastEx
                                ,AnusEx
                                ,BreathSoundsEx
                                ,RaleEx
                                ,NoiseEx
                                ,CervixUteriEx
                                ,CorpusEx
                                ,AttachEx
                                ,VulvaEx
                                ,VaginaEx
                                ,PressPainEx
                                ,LiverEx
                                ,SpleenEx
                                ,VoicedEx
                                ,EnclosedMassEx
                                ,EyeRound
                                ,EyeRoundEx
                                ,OutKey
                            )
                            VALUES
                             (
                                @PhysicalID
                                ,@IDCardNo
                                ,@Skin
                                ,@Sclere
                                ,@Lymph
                                ,@BarrelChest
                                ,@BreathSounds
                                ,@Rale
                                ,@HeartRhythm
                                ,@Noise
                                ,@EnclosedMass
                                ,@Edema
                                ,@FootBack
                                ,@Anus
                                ,@Breast
                                ,@Vulva
                                ,@Vagina
                                ,@CervixUteri
                                ,@Corpus
                                ,@Attach
                                ,@Other
                                ,@PressPain
                                ,@Liver
                                ,@Spleen
                                ,@Voiced
                                ,@SkinEx
                                ,@SclereEx
                                ,@LymphEx
                                ,@BreastEx
                                ,@AnusEx
                                ,@BreathSoundsEx
                                ,@RaleEx
                                ,@NoiseEx
                                ,@CervixUteriEx
                                ,@CorpusEx
                                ,@AttachEx
                                ,@VulvaEx
                                ,@VaginaEx
                                ,@PressPainEx
                                ,@LiverEx
                                ,@SpleenEx
                                ,@VoicedEx
                                ,@EnclosedMassEx
                                ,@EyeRound
                                ,@EyeRoundEx
                                ,@OutKey
                            ) ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Skin",model.Skin),
                new MySqlParameter("@Sclere",model.Sclere),
                new MySqlParameter("@Lymph",model.Lymph),
                new MySqlParameter("@BarrelChest",model.BarrelChest),
                new MySqlParameter("@BreathSounds",model.BreathSounds),
                new MySqlParameter("@Rale",model.Rale),
                new MySqlParameter("@HeartRhythm",model.HeartRhythm),
                new MySqlParameter("@Noise",model.Noise),
                new MySqlParameter("@EnclosedMass",model.EnclosedMass),
                new MySqlParameter("@Edema",model.Edema),
                new MySqlParameter("@FootBack",model.FootBack),
                new MySqlParameter("@Anus",model.Anus),
                new MySqlParameter("@Breast",model.Breast),
                new MySqlParameter("@Vulva",model.Vulva),
                new MySqlParameter("@Vagina",model.Vagina),
                new MySqlParameter("@CervixUteri",model.CervixUteri),
                new MySqlParameter("@Corpus",model.Corpus),
                new MySqlParameter("@Attach",model.Attach),
                new MySqlParameter("@Other",model.Other),
                new MySqlParameter("@PressPain",model.PressPain),
                new MySqlParameter("@Liver",model.Liver),
                new MySqlParameter("@Spleen",model.Spleen),
                new MySqlParameter("@Voiced",model.Voiced),
                new MySqlParameter("@SkinEx",model.SkinEx),
                new MySqlParameter("@SclereEx",model.SclereEx),
                new MySqlParameter("@LymphEx",model.LymphEx),
                new MySqlParameter("@BreastEx",model.BreastEx),
                new MySqlParameter("@AnusEx",model.AnusEx),
                new MySqlParameter("@BreathSoundsEx",model.BreathSoundsEx),
                new MySqlParameter("@RaleEx",model.RaleEx),
                new MySqlParameter("@NoiseEx",model.NoiseEx),
                new MySqlParameter("@CervixUteriEx",model.CervixUteriEx),
                new MySqlParameter("@CorpusEx",model.CorpusEx),
                new MySqlParameter("@AttachEx",model.AttachEx),
                new MySqlParameter("@VulvaEx",model.VulvaEx),
                new MySqlParameter("@VaginaEx",model.VaginaEx),
                new MySqlParameter("@PressPainEx",model.PressPainEx),
                new MySqlParameter("@LiverEx",model.LiverEx),
                new MySqlParameter("@SpleenEx",model.SpleenEx),
                new MySqlParameter("@VoicedEx",model.VoicedEx),
                new MySqlParameter("@EnclosedMassEx",model.EnclosedMassEx),
                new MySqlParameter("@EyeRound",model.EyeRound),
                new MySqlParameter("@EyeRoundEx",model.EyeRoundEx),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@OutKey",model.OutKey),
                new MySqlParameter("@PhysicalID",model.PhysicalID)
             };

            MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);
        }

        #endregion

        #region X光

        /// <summary>
        /// 取得对应条件的X光资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetChestXList(string strWhere, string conn = "")
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(@"
                            SELECT
                                ID
                                ,IDCardNo
                                ,RecordDate
                                ,CHESTX
                                ,CHESTXEx
                            FROM 
                                tbl_RecordsChestX ");

            if (strWhere.Trim() != "")
            {
                sbQuery.Append(" WHERE 1=1 " + strWhere);
            }

            return YcSqliteHelper.Query(sbQuery.ToString(), conn);
        }

        /// <summary>
        /// 更新终端资料库中的查体资料--X光
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public bool UpdateByChestX(RecordsAssistCheckModel model, string RecordDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            UPDATE 
                                ARCHIVE_ASSISTCHECK D
                            SET 
                                CHESTX = @CHESTX 
                                ,CHESTXEx = @CHESTXEx
                            WHERE 
                                D.OUTKEY=
                                (
                                    SELECT 
                                        M.ID 
                                    FROM
                                        ARCHIVE_CUSTOMERBASEINFO M 
                                    WHERE  
                                        IFNULL(M.IsDel,'')!='Y'
                                        AND M.IDCardNo =@IDCardNo 
                                        AND LEFT(M.CheckDate,4) = @CheckDate 
                                        order by M.CheckDate DESC LIMIT 0,1 
                                );  ");

            if (Convert.ToString(RecordDate).Length > 3) RecordDate = RecordDate.Substring(0, 4);

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CHESTX",model.CHESTX),
                new MySqlParameter("@CHESTXEx",model.CHESTXEx),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@CheckDate",RecordDate)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 更新终端资料库中的查体资料--内科,外科
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RecordDate"></param>
        /// <returns></returns>
        public void InsertByChestX(RecordsAssistCheckModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"
                            INSERT INTO
                                ARCHIVE_ASSISTCHECK
                            (
                                PhysicalID
                                ,IDCardNo
                                ,CHESTX
                                ,CHESTXEx
                                ,OutKey
                            )
                            VALUES
                             (
                                @PhysicalID
                                ,@IDCardNo
                                ,@CHESTX
                                ,@CHESTXEx
                                ,@OutKey
                            ) ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CHESTX",model.CHESTX),
                new MySqlParameter("@CHESTXEx",model.CHESTXEx),
                new MySqlParameter("@OutKey",model.OutKey),
                new MySqlParameter("@IDCardNo",model.IDCardNo),
                new MySqlParameter("@PhysicalID",model.PhysicalID)
             };

            MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);
        }

        #endregion
    }
}