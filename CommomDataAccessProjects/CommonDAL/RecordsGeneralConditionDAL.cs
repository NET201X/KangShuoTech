using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsGeneralConditionDAL
    {
        public int Add(RecordsGeneralConditionModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_GENERALCONDITION(");
            builder.Append("PhysicalID,IDCardNo,AnimalHeat,BreathRate,Waistline,Height,OldRecognise,OldEmotion,PulseRate,Weight,BMI,InterScore,GloomyScore,");
            builder.Append("LeftPre,RightPre,WaistIp,LeftHeight,RightHeight,OldHealthStaus,OldSelfCareability,OutKey,LeftReason,RightReason");

            if (VersionNo.Contains("3.0")) builder.Append(" ,OldMange)");
            else builder.Append(" ,SelfID,OldMange)");

            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@IDCardNo,@AnimalHeat,@BreathRate,@Waistline,@Height,@OldRecognise,@OldEmotion,@PulseRate,@Weight,@BMI,@InterScore,@GloomyScore,");
            builder.Append("@LeftPre,@RightPre,@WaistIp,@LeftHeight,@RightHeight,@OldHealthStaus,@OldSelfCareability,@OutKey,@LeftReason,@RightReason");

            if (VersionNo.Contains("3.0")) builder.Append(" ,@OldMange)");
            else builder.Append(" ,@SelfID,@OldMange)");

            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@AnimalHeat", MySqlDbType.Decimal),
                new MySqlParameter("@BreathRate", MySqlDbType.Decimal),
                new MySqlParameter("@Waistline", MySqlDbType.Decimal),
                new MySqlParameter("@Height", MySqlDbType.Decimal),
                new MySqlParameter("@OldRecognise", MySqlDbType.String, 1),
                new MySqlParameter("@OldEmotion", MySqlDbType.String, 1),
                new MySqlParameter("@PulseRate", MySqlDbType.Decimal),
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@InterScore", MySqlDbType.Decimal),
                new MySqlParameter("@GloomyScore", MySqlDbType.Decimal),
                new MySqlParameter("@LeftPre", MySqlDbType.Decimal),
                new MySqlParameter("@RightPre", MySqlDbType.Decimal),
                new MySqlParameter("@WaistIp", MySqlDbType.Decimal),
                new MySqlParameter("@LeftHeight", MySqlDbType.Decimal),
                new MySqlParameter("@RightHeight", MySqlDbType.Decimal),
                new MySqlParameter("@OldHealthStaus", MySqlDbType.String, 1),
                new MySqlParameter("@OldSelfCareability", MySqlDbType.String, 1),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4),
                new MySqlParameter("@LeftReason", MySqlDbType.String, 100),
                new MySqlParameter("@RightReason", MySqlDbType.String, 100),
                new MySqlParameter("@OldMange",MySqlDbType.String,1),
                new MySqlParameter("@SelfID", MySqlDbType.Int32, 4)
             };

            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.AnimalHeat;
            cmdParms[3].Value = model.BreathRate;
            cmdParms[4].Value = model.Waistline;
            cmdParms[5].Value = model.Height;
            cmdParms[6].Value = model.OldRecognise;
            cmdParms[7].Value = model.OldEmotion;
            cmdParms[8].Value = model.PulseRate;
            cmdParms[9].Value = model.Weight;
            cmdParms[10].Value = model.BMI;
            cmdParms[11].Value = model.InterScore;
            cmdParms[12].Value = model.GloomyScore;
            cmdParms[13].Value = model.LeftPre;
            cmdParms[14].Value = model.RightPre;
            cmdParms[15].Value = model.WaistIp;
            cmdParms[16].Value = model.LeftHeight;
            cmdParms[17].Value = model.RightHeight;
            cmdParms[18].Value = model.OldHealthStaus;
            cmdParms[19].Value = model.OldSelfCareability;
            cmdParms[20].Value = model.OutKey;
            cmdParms[21].Value = model.LeftReason;
            cmdParms[22].Value = model.RightReason;
            cmdParms[23].Value = model.OldMange;
            cmdParms[24].Value = model.SelfID;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetModelByCheckDate(string IDCardNo, string checkDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT D.OutKey,D.ID,D.PhysicalID,D.IDCardNo,D.AnimalHeat,D.BreathRate,D.Waistline,D.Height,D.OldRecognise,D.OldEmotion,");
            builder.Append("D.PulseRate,D.Weight,D.BMI,D.InterScore,D.GloomyScore,D.LeftPre,D.RightPre,D.WaistIp,D.LeftHeight,D.RightHeight,");
            builder.Append("D.OldHealthStaus,D.OldSelfCareability,D.SelfID,M.CheckDate ");
            builder.Append(" FROM ARCHIVE_GENERALCONDITION D ");
            builder.Append(" INNER JOIN ARCHIVE_CUSTOMERBASEINFO M ON M.ID=D.OutKey ");
            builder.Append(" AND M.CheckDate=(SELECT MAX(CheckDate) FROM ARCHIVE_CUSTOMERBASEINFO ");
            builder.Append("    WHERE IDCardNo=@IDCardNo AND LEFT(CheckDate,4)=@CheckDate) ");
            builder.Append(" WHERE M.IDCardNo=@IDCardNo");

            if (Convert.ToString(checkDate).Length > 3) checkDate = checkDate.Substring(0, 4);

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", IDCardNo),
                new MySqlParameter("@CheckDate", checkDate)
            };

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        /// <summary>
        /// 身高体重的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniSTPad(RecordsGeneralConditionModel model, string OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                            ARCHIVE_GENERALCONDITION
                                       SET 
                                            Weight=@Weight
                                            ,BMI=@BMI
                                            ,Height=@Height");

            if (model.Waistline.HasValue) builder.Append(@",Waistline=@Waistline");

            builder.Append(@" 
                                WHERE
                                    IDCardNo = @IDCardNo
                                    AND OutKey = @OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@OutKey", OutKey),
                new MySqlParameter("@Weight", model.Weight),
                new MySqlParameter("@BMI", model.BMI),
                new MySqlParameter("@Height", model.Height),
                new MySqlParameter("@Waistline", model.Waistline)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 体温体重-体重体质指数的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniTTPad(RecordsGeneralConditionModel model, string checkDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"UPDATE 
                                    ARCHIVE_GENERALCONDITION  D
                             SET 
                                    Weight=@Weight
                                    ,BMI=@BMI
                                    ,Waistline=@Waistline                               
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
                new MySqlParameter("@Weight", model.Weight),
                new MySqlParameter("@BMI", model.BMI),
                new MySqlParameter("@Waistline", model.Waistline)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 体温体重-体温更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniTWPad(RecordsGeneralConditionModel model, string checkDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"UPDATE 
                                    ARCHIVE_GENERALCONDITION  D
                             SET 
                                     AnimalHeat=@AnimalHeat                               
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
                new MySqlParameter("@AnimalHeat", model.AnimalHeat)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 血压的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniPad(RecordsGeneralConditionModel model, string checkDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                    ARCHIVE_GENERALCONDITION  D
                             SET 
                                    LeftPre=@LeftPre
                                    ,RightPre=@RightPre
                                    ,LeftHeight=@LeftHeight
                                    ,RightHeight=@RightHeight
                                    ,BreathRate=@BreathRate
                                    ,PulseRate=@PulseRate
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
                                    );
                             UPDATE 
                                    ARCHIVE_PHYSICALEXAM  D
                             SET 
                                    HeartRate=@PulseRate
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
                new MySqlParameter("@BreathRate", model.BreathRate),
                new MySqlParameter("@LeftPre", model.LeftPre),
                new MySqlParameter("@RightPre", model.RightPre),
                new MySqlParameter("@PulseRate", model.PulseRate),
                new MySqlParameter("@LeftHeight", model.LeftHeight),
                new MySqlParameter("@RightHeight", model.RightHeight),
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 心电同步更新脉率
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="OutKey"></param>
        /// <param name="PulseRate"></param>
        /// <param name="BreathRate"></param>
        /// <returns></returns>
        public bool UpdateByEcg(string IDCardNo, string OutKey, string PulseRate, string BreathRate)
        {
            StringBuilder builder = new StringBuilder();
            string sql = "";

            builder.Append("UPDATE ARCHIVE_GENERALCONDITION SET ");

            if (PulseRate != "") sql += "PulseRate=@PulseRate,";
            if (BreathRate != "") sql += "BreathRate=@BreathRate,";

            builder.Append(sql.TrimEnd(','));

            if (builder.ToString() != "UPDATE ARCHIVE_GENERALCONDITION SET ")
            {
                builder.Append(@" WHERE IDCardNo = @IDCardNo
                                            AND OutKey = @OutKey ");
            }

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", IDCardNo),
                new MySqlParameter("@OutKey",OutKey),
                new MySqlParameter("@PulseRate", PulseRate),
                new MySqlParameter("@BreathRate", BreathRate)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 抑郁评估的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByGloomy(RecordsGeneralConditionModel model, string OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                            ARCHIVE_GENERALCONDITION
                                       SET 
                                            GloomyScore=@GloomyScore
                                            ,OldEmotion=@OldEmotion");

            if (!string.IsNullOrEmpty(model.OldHealthStaus)) builder.Append(@",OldHealthStaus=@OldHealthStaus");

            builder.Append(@" 
                                WHERE
                                    IDCardNo = @IDCardNo
                                    AND OutKey = @OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@OutKey", OutKey),
                new MySqlParameter("@GloomyScore", model.GloomyScore),
                new MySqlParameter("@OldHealthStaus", model.OldHealthStaus),
                new MySqlParameter("@OldEmotion", model.OldEmotion)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 智力评估的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByIntelligence(RecordsGeneralConditionModel model, string OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                            ARCHIVE_GENERALCONDITION
                                       SET 
                                            InterScore=@InterScore
                                            ,OldRecognise=@OldRecognise
                                        WHERE
                                            IDCardNo = @IDCardNo
                                            AND OutKey = @OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@OutKey", OutKey),
                new MySqlParameter("@InterScore", model.InterScore),
                new MySqlParameter("@OldRecognise", model.OldRecognise)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataTable GetMaxDateModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT General.* FROM ARCHIVE_GENERALCONDITION General ");
            builder.Append("INNER JOIN ARCHIVE_CUSTOMERBASEINFO Customer ");
            builder.Append("ON General.IDCardNo = Customer.IDCardNo ");
            builder.Append("WHERE General.IDCardNo=@IDCardNo ");
            builder.Append("ORDER BY Customer.CheckDate DESC,General.OutKey DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            if (set.Tables[0].Rows.Count > 0) return set.Tables[0];

            return null;
        }

        public DataSet GetModelByOutKey(int OutKey)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT * FROM ARCHIVE_GENERALCONDITION ");
            strSql.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@OutKey", MySqlDbType.Int32)
            };
            cmdParms[0].Value = OutKey;

            DataSet set = MySQLHelper.Query(strSql.ToString(), cmdParms);

            return set;
        }

        #region 辽宁抑郁、智力表存档

        /// <summary>
        /// 抑郁评估的新增
        /// </summary>
        /// <param name="model"></param>
        /// <param name="OutKey"></param>
        /// <returns></returns>
        public int Add(OldGloomyModel model, string OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"INSERT INTO tbl_OldGloomy
                                    (
                                        IDCardNo
                                        ,Satisfied
                                        ,Hobby
                                        ,Emptiness
                                        ,Boring
                                        ,Hope
                                        ,Annoyance
                                        ,Spirit
                                        ,Fair
                                        ,Happy
                                        ,Helpless
                                        ,Calm
                                        ,Lazy
                                        ,Future
                                        ,Memory
                                        ,Life
                                        ,Mood
                                        ,Useless
                                        ,Worry
                                        ,Excitement
                                        ,Study
                                        ,Energy
                                        ,Present
                                        ,Feel
                                        ,Doing
                                        ,Cry
                                        ,Focus
                                        ,Morning
                                        ,Activity
                                        ,Decision
                                        ,Brain
                                        ,TotalScore
                                        ,OldHealthStaus
                                        ,VisitDate
                                        ,VisitDoctor
                                        ,NextVisitDate
                                        ,CreatedBy
                                        ,CreatedDate
                                        ,LastUpDateBy
                                        ,LastUpDateDate
                                        ,OutKey
                                    )
                                    VALUES
                                    (
                                        @IDCardNo
                                        ,@Satisfied
                                        ,@Hobby
                                        ,@Emptiness
                                        ,@Boring
                                        ,@Hope
                                        ,@Annoyance
                                        ,@Spirit
                                        ,@Fair
                                        ,@Happy
                                        ,@Helpless
                                        ,@Calm
                                        ,@Lazy
                                        ,@Future
                                        ,@Memory
                                        ,@Life
                                        ,@Mood
                                        ,@Useless
                                        ,@Worry
                                        ,@Excitement
                                        ,@Study
                                        ,@Energy
                                        ,@Present
                                        ,@Feel
                                        ,@Doing
                                        ,@Cry
                                        ,@Focus
                                        ,@Morning
                                        ,@Activity
                                        ,@Decision
                                        ,@Brain
                                        ,@TotalScore
                                        ,@OldHealthStaus
                                        ,@VisitDate
                                        ,@VisitDoctor
                                        ,@NextVisitDate
                                        ,@CreatedBy
                                        ,@CreatedDate
                                        ,@LastUpDateBy
                                        ,@LastUpDateDate
                                        ,@OutKey
                                    ) ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@IDCardNo", MySqlDbType.String, 18),
                 new MySqlParameter("@Satisfied", MySqlDbType.Int32),
                 new MySqlParameter("@Hobby", MySqlDbType.Int32),
                 new MySqlParameter("@Emptiness", MySqlDbType.Int32),
                 new MySqlParameter("@Boring", MySqlDbType.Int32),
                 new MySqlParameter("@Hope", MySqlDbType.Int32),
                 new MySqlParameter("@Annoyance", MySqlDbType.Int32),
                 new MySqlParameter("@Spirit", MySqlDbType.Int32),
                 new MySqlParameter("@Fair", MySqlDbType.Int32),
                 new MySqlParameter("@Happy", MySqlDbType.Int32),
                 new MySqlParameter("@Helpless", MySqlDbType.Int32),
                 new MySqlParameter("@Calm", MySqlDbType.Int32),
                 new MySqlParameter("@Lazy", MySqlDbType.Int32),
                 new MySqlParameter("@Future", MySqlDbType.Int32),
                 new MySqlParameter("@Memory", MySqlDbType.Int32),
                 new MySqlParameter("@Life", MySqlDbType.Int32),
                 new MySqlParameter("@Mood", MySqlDbType.Int32),
                 new MySqlParameter("@Useless", MySqlDbType.Int32),
                 new MySqlParameter("@Worry", MySqlDbType.Int32),
                 new MySqlParameter("@Excitement", MySqlDbType.Int32),
                 new MySqlParameter("@Study", MySqlDbType.Int32),
                 new MySqlParameter("@Energy", MySqlDbType.Int32),
                 new MySqlParameter("@Present", MySqlDbType.Int32),
                 new MySqlParameter("@Feel", MySqlDbType.Int32),
                 new MySqlParameter("@Doing", MySqlDbType.Int32),
                 new MySqlParameter("@Cry", MySqlDbType.Int32),
                 new MySqlParameter("@Focus", MySqlDbType.Int32),
                 new MySqlParameter("@Morning", MySqlDbType.Int32),
                 new MySqlParameter("@Activity", MySqlDbType.Int32),
                 new MySqlParameter("@Decision", MySqlDbType.Int32),
                 new MySqlParameter("@Brain", MySqlDbType.Int32),
                 new MySqlParameter("@TotalScore", MySqlDbType.Int32),
                 new MySqlParameter("@OldHealthStaus", MySqlDbType.String, 1),
                 new MySqlParameter("@VisitDate", MySqlDbType.Date),
                 new MySqlParameter("@VisitDoctor", MySqlDbType.String, 50),
                 new MySqlParameter("@NextVisitDate", MySqlDbType.Date),
                 new MySqlParameter("@CreatedBy", MySqlDbType.String, 100),
                 new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                 new MySqlParameter("@LastUpDateBy", MySqlDbType.String, 100),
                 new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                 new MySqlParameter("@OutKey", MySqlDbType.Int32)
            };

            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Satisfied == "" ? null : model.Satisfied;
            cmdParms[2].Value = model.Hobby == "" ? null : model.Hobby;
            cmdParms[3].Value = model.Emptiness == "" ? null : model.Emptiness;
            cmdParms[4].Value = model.Boring == "" ? null : model.Boring;
            cmdParms[5].Value = model.Hope == "" ? null : model.Hope;
            cmdParms[6].Value = model.Annoyance == "" ? null : model.Annoyance;
            cmdParms[7].Value = model.Spirit == "" ? null : model.Spirit;
            cmdParms[8].Value = model.Fair == "" ? null : model.Fair;
            cmdParms[9].Value = model.Happy == "" ? null : model.Happy;
            cmdParms[10].Value = model.Helpless == "" ? null : model.Helpless;
            cmdParms[11].Value = model.Calm == "" ? null : model.Calm;
            cmdParms[12].Value = model.Lazy == "" ? null : model.Lazy;
            cmdParms[13].Value = model.Future == "" ? null : model.Future;
            cmdParms[14].Value = model.Memory == "" ? null : model.Memory;
            cmdParms[15].Value = model.Life == "" ? null : model.Life;
            cmdParms[16].Value = model.Mood == "" ? null : model.Mood;
            cmdParms[17].Value = model.Useless == "" ? null : model.Useless;
            cmdParms[18].Value = model.Worry == "" ? null : model.Worry;
            cmdParms[19].Value = model.Excitement == "" ? null : model.Excitement;
            cmdParms[20].Value = model.Study == "" ? null : model.Study;
            cmdParms[21].Value = model.Energy == "" ? null : model.Energy;
            cmdParms[22].Value = model.Present == "" ? null : model.Present;
            cmdParms[23].Value = model.Feel == "" ? null : model.Feel;
            cmdParms[24].Value = model.Doing == "" ? null : model.Doing;
            cmdParms[25].Value = model.Cry == "" ? null : model.Cry;
            cmdParms[26].Value = model.Focus == "" ? null : model.Focus;
            cmdParms[27].Value = model.Morning == "" ? null : model.Morning;
            cmdParms[28].Value = model.Activity == "" ? null : model.Activity;
            cmdParms[29].Value = model.Decision == "" ? null : model.Decision;
            cmdParms[30].Value = model.Brain == "" ? null : model.Brain;
            cmdParms[31].Value = model.TotalScore == "" ? null : model.TotalScore;
            cmdParms[32].Value = model.OldHealthStaus;
            cmdParms[33].Value = model.VisitDate;
            cmdParms[34].Value = model.VisitDoctor;
            cmdParms[35].Value = model.NextVisitDate;
            cmdParms[36].Value = model.CreatedBy;
            cmdParms[37].Value = model.CreatedDate;
            cmdParms[38].Value = model.LastUpDateBy;
            cmdParms[39].Value = model.LastUpDateDate;
            cmdParms[40].Value = OutKey;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 抑郁评估的删除
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="OutKey"></param>
        /// <returns></returns>
        public bool Delete(string IDCardNo, string OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"DELETE FROM tbl_OldGloomy 
                                    WHERE
                                        IDCardNo = @IDCardNo
                                        AND OutKey = @OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@IDCardNo", MySqlDbType.String, 18),
                 new MySqlParameter("@OutKey", MySqlDbType.Int32)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OutKey;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 智力评估的新增
        /// </summary>
        /// <param name="model"></param>
        /// <param name="OutKey"></param>
        /// <returns></returns>
        public int Add(OldIntelligenceModel model, string OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"INSERT INTO tbl_OldIntelligence
                                    (
                                        IDCardNo
                                        ,DirectionalOne
                                        ,DirectionalTwo
                                        ,Memory
                                        ,Attention
                                        ,RecallAbility
                                        ,NamingAbility
                                        ,RetellAbility
                                        ,Comprehension
                                        ,ReadAbility
                                        ,WriteAbility
                                        ,StructureAbility
                                        ,TotalScore
                                        ,VisitDate
                                        ,VisitDoctor
                                        ,NextVisitDate
                                        ,CreatedBy
                                        ,CreatedDate
                                        ,LastUpDateBy
                                        ,LastUpDateDate
                                        ,OutKey
                                    )
                                    VALUES
                                    (
                                        @IDCardNo
                                        ,@DirectionalOne
                                        ,@DirectionalTwo
                                        ,@Memory
                                        ,@Attention
                                        ,@RecallAbility
                                        ,@NamingAbility
                                        ,@RetellAbility
                                        ,@Comprehension
                                        ,@ReadAbility
                                        ,@WriteAbility
                                        ,@StructureAbility
                                        ,@TotalScore
                                        ,@VisitDate
                                        ,@VisitDoctor
                                        ,@NextVisitDate
                                        ,@CreatedBy
                                        ,@CreatedDate
                                        ,@LastUpDateBy
                                        ,@LastUpDateDate
                                        ,@OutKey
                                    ) ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@IDCardNo", MySqlDbType.String, 18),
                 new MySqlParameter("@DirectionalOne", MySqlDbType.Int32),
                 new MySqlParameter("@DirectionalTwo", MySqlDbType.Int32),
                 new MySqlParameter("@Memory", MySqlDbType.Int32),
                 new MySqlParameter("@Attention", MySqlDbType.Int32),
                 new MySqlParameter("@RecallAbility", MySqlDbType.Int32),
                 new MySqlParameter("@NamingAbility", MySqlDbType.Int32),
                 new MySqlParameter("@RetellAbility", MySqlDbType.Int32),
                 new MySqlParameter("@Comprehension", MySqlDbType.Int32),
                 new MySqlParameter("@ReadAbility", MySqlDbType.Int32),
                 new MySqlParameter("@WriteAbility", MySqlDbType.Int32),
                 new MySqlParameter("@StructureAbility", MySqlDbType.Int32),
                 new MySqlParameter("@TotalScore", MySqlDbType.Int32),
                 new MySqlParameter("@VisitDate", MySqlDbType.Date),
                 new MySqlParameter("@VisitDoctor", MySqlDbType.String, 50),
                 new MySqlParameter("@NextVisitDate", MySqlDbType.Date),
                 new MySqlParameter("@CreatedBy", MySqlDbType.String, 100),
                 new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                 new MySqlParameter("@LastUpDateBy", MySqlDbType.String, 100),
                 new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                 new MySqlParameter("@OutKey", MySqlDbType.Int32)
            };

            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.DirectionalOne == "" ? null : model.DirectionalOne;
            cmdParms[2].Value = model.DirectionalTwo == "" ? null : model.DirectionalTwo;
            cmdParms[3].Value = model.Memory == "" ? null : model.Memory;
            cmdParms[4].Value = model.Attention == "" ? null : model.Attention;
            cmdParms[5].Value = model.RecallAbility == "" ? null : model.RecallAbility;
            cmdParms[6].Value = model.NamingAbility == "" ? null : model.NamingAbility;
            cmdParms[7].Value = model.RetellAbility == "" ? null : model.RetellAbility;
            cmdParms[8].Value = model.Comprehension == "" ? null : model.Comprehension;
            cmdParms[9].Value = model.ReadAbility == "" ? null : model.ReadAbility;
            cmdParms[10].Value = model.WriteAbility == "" ? null : model.WriteAbility;
            cmdParms[11].Value = model.StructureAbility == "" ? null : model.StructureAbility;
            cmdParms[12].Value = model.TotalScore == "" ? null : model.TotalScore;
            cmdParms[13].Value = model.VisitDate;
            cmdParms[14].Value = model.VisitDoctor;
            cmdParms[15].Value = model.NextVisitDate;
            cmdParms[16].Value = model.CreatedBy;
            cmdParms[17].Value = model.CreatedDate;
            cmdParms[18].Value = model.LastUpDateBy;
            cmdParms[19].Value = model.LastUpDateDate;
            cmdParms[20].Value = OutKey;
                            
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 智力评估的删除
        /// </summary>
        /// <param name="model"></param>
        /// <param name="OutKey"></param>
        /// <returns></returns>
        public bool DeleteByOldIntelligence(string IDCardNo, string OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"DELETE FROM tbl_OldIntelligence 
                                    WHERE
                                        IDCardNo = @IDCardNo
                                        AND OutKey = @OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@IDCardNo", MySqlDbType.String, 18),
                 new MySqlParameter("@OutKey", MySqlDbType.Int32)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OutKey;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        #endregion
    }
}
