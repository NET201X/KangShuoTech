namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsGeneralConditionDAL
    {
        public int Add(RecordsGeneralConditionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_GENERALCONDITION(");
            builder.Append("PhysicalID,IDCardNo,AnimalHeat,BreathRate,Waistline,Height,OldRecognise,OldEmotion,PulseRate,Weight,BMI,InterScore,GloomyScore,LeftPre,RightPre,WaistIp,LeftHeight,RightHeight,OldHealthStaus,OldSelfCareability,OutKey,LeftReason,RightReason,SelfID,OldMange)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@AnimalHeat,@BreathRate,@Waistline,@Height,@OldRecognise,@OldEmotion,@PulseRate,@Weight,@BMI,@InterScore,@GloomyScore,@LeftPre,@RightPre,@WaistIp,@LeftHeight,@RightHeight,@OldHealthStaus,@OldSelfCareability,@OutKey,@LeftReason,@RightReason,@SelfID,@OldMange )");
            builder.Append(";select @@IDENTITY");
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
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsGeneralConditionModel DataRowToModel(DataRow row)
        {
            RecordsGeneralConditionModel recordsGeneralConditionModel = new RecordsGeneralConditionModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsGeneralConditionModel.ID = int.Parse(row["ID"].ToString());
                }
                if (((row["OutKey"] != null) && (row["OutKey"] != DBNull.Value)) && (row["OutKey"].ToString() != ""))
                {
                    recordsGeneralConditionModel.OutKey = int.Parse(row["OutKey"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsGeneralConditionModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsGeneralConditionModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["AnimalHeat"] != null) && (row["AnimalHeat"] != DBNull.Value)) && (row["AnimalHeat"].ToString() != ""))
                {
                    recordsGeneralConditionModel.AnimalHeat = new decimal?(decimal.Parse(row["AnimalHeat"].ToString()));
                }
                if (((row["BreathRate"] != null) && (row["BreathRate"] != DBNull.Value)) && (row["BreathRate"].ToString() != ""))
                {
                    recordsGeneralConditionModel.BreathRate = new decimal?(decimal.Parse(row["BreathRate"].ToString()));
                }
                if (((row["Waistline"] != null) && (row["Waistline"] != DBNull.Value)) && (row["Waistline"].ToString() != ""))
                {
                    recordsGeneralConditionModel.Waistline = new decimal?(decimal.Parse(row["Waistline"].ToString()));
                }
                if (((row["Height"] != null) && (row["Height"] != DBNull.Value)) && (row["Height"].ToString() != ""))
                {
                    recordsGeneralConditionModel.Height = new decimal?(decimal.Parse(row["Height"].ToString()));
                }
                if ((row["OldRecognise"] != null) && (row["OldRecognise"] != DBNull.Value))
                {
                    recordsGeneralConditionModel.OldRecognise = row["OldRecognise"].ToString();
                }
                if ((row["OldEmotion"] != null) && (row["OldEmotion"] != DBNull.Value))
                {
                    recordsGeneralConditionModel.OldEmotion = row["OldEmotion"].ToString();
                }
                if (((row["PulseRate"] != null) && (row["PulseRate"] != DBNull.Value)) && (row["PulseRate"].ToString() != ""))
                {
                    recordsGeneralConditionModel.PulseRate = new decimal?(decimal.Parse(row["PulseRate"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    recordsGeneralConditionModel.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if (((row["BMI"] != null) && (row["BMI"] != DBNull.Value)) && (row["BMI"].ToString() != ""))
                {
                    recordsGeneralConditionModel.BMI = new decimal?(decimal.Parse(row["BMI"].ToString()));
                }
                if (((row["InterScore"] != null) && (row["InterScore"] != DBNull.Value)) && (row["InterScore"].ToString() != ""))
                {
                    recordsGeneralConditionModel.InterScore = new decimal?(decimal.Parse(row["InterScore"].ToString()));
                }
                if (((row["GloomyScore"] != null) && (row["GloomyScore"] != DBNull.Value)) && (row["GloomyScore"].ToString() != ""))
                {
                    recordsGeneralConditionModel.GloomyScore = new decimal?(decimal.Parse(row["GloomyScore"].ToString()));
                }
                if (((row["LeftPre"] != null) && (row["LeftPre"] != DBNull.Value)) && (row["LeftPre"].ToString() != ""))
                {
                    recordsGeneralConditionModel.LeftPre = new decimal?(decimal.Parse(row["LeftPre"].ToString()));
                }
                if (((row["RightPre"] != null) && (row["RightPre"] != DBNull.Value)) && (row["RightPre"].ToString() != ""))
                {
                    recordsGeneralConditionModel.RightPre = new decimal?(decimal.Parse(row["RightPre"].ToString()));
                }
                if (((row["WaistIp"] != null) && (row["WaistIp"] != DBNull.Value)) && (row["WaistIp"].ToString() != ""))
                {
                    recordsGeneralConditionModel.WaistIp = new decimal?(decimal.Parse(row["WaistIp"].ToString()));
                }
                if (((row["LeftHeight"] != null) && (row["LeftHeight"] != DBNull.Value)) && (row["LeftHeight"].ToString() != ""))
                {
                    recordsGeneralConditionModel.LeftHeight = new decimal?(decimal.Parse(row["LeftHeight"].ToString()));
                }
                if (((row["RightHeight"] != null) && (row["RightHeight"] != DBNull.Value)) && (row["RightHeight"].ToString() != ""))
                {
                    recordsGeneralConditionModel.RightHeight = new decimal?(decimal.Parse(row["RightHeight"].ToString()));
                }
                if ((row["OldHealthStaus"] != null) && (row["OldHealthStaus"] != DBNull.Value))
                {
                    recordsGeneralConditionModel.OldHealthStaus = row["OldHealthStaus"].ToString();
                }
                if ((row["OldSelfCareability"] != null) && (row["OldSelfCareability"] != DBNull.Value))
                {
                    recordsGeneralConditionModel.OldSelfCareability = row["OldSelfCareability"].ToString();
                }
                if ((row["LeftReason"] != null) && (row["LeftReason"] != DBNull.Value))
                {
                    recordsGeneralConditionModel.LeftReason = row["LeftReason"].ToString();
                }
                if ((row["RightReason"] != null) && (row["RightReason"] != DBNull.Value))
                {
                    recordsGeneralConditionModel.RightReason = row["RightReason"].ToString();
                }
                if (((row["SelfID"] != null) && (row["SelfID"] != DBNull.Value)) && (row["SelfID"].ToString() != ""))
                {
                    recordsGeneralConditionModel.SelfID = int.Parse(row["SelfID"].ToString());
                }
                if ((row["OldMange"] != null) && (row["OldMange"] != DBNull.Value))
                {
                    recordsGeneralConditionModel.OldMange = row["OldMange"].ToString();
                }
            }
            return recordsGeneralConditionModel;
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,AnimalHeat,BreathRate,Waistline,Height,OldRecognise,OldEmotion,PulseRate,Weight,BMI,InterScore,GloomyScore,LeftPre,RightPre,WaistIp,LeftHeight,RightHeight,OldHealthStaus,OldSelfCareability,OutKey,LeftReason,RightReason,SelfID ");
            builder.Append(" FROM ARCHIVE_GENERALCONDITION ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet Getrecordsgeneralconditiondt(string IDCardNo, int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_GENERALCONDITION WHERE IDCardNo='" + IDCardNo + "' AND OutKey = '" + OutKey + "'  ");

            return MySQLHelper.Query(builder.ToString());
        }

        public RecordsGeneralConditionModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,AnimalHeat,BreathRate,Waistline,Height,OldRecognise,OldEmotion,PulseRate,Weight,BMI,InterScore,GloomyScore,LeftPre,RightPre,WaistIp,LeftHeight,RightHeight,OldHealthStaus,OldSelfCareability,OutKey,LeftReason,RightReason,SelfID,OldMange from ARCHIVE_GENERALCONDITION ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsGeneralConditionModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public bool Update(RecordsGeneralConditionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_GENERALCONDITION set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("AnimalHeat=@AnimalHeat,");
            builder.Append("BreathRate=@BreathRate,");
            builder.Append("Waistline=@Waistline,");
            builder.Append("Height=@Height,");
            builder.Append("OldRecognise=@OldRecognise,");
            builder.Append("OldEmotion=@OldEmotion,");
            builder.Append("PulseRate=@PulseRate,");
            builder.Append("Weight=@Weight,");
            builder.Append("BMI=@BMI,");
            builder.Append("InterScore=@InterScore,");
            builder.Append("GloomyScore=@GloomyScore,");
            builder.Append("LeftPre=@LeftPre,");
            builder.Append("RightPre=@RightPre,");
            builder.Append("WaistIp=@WaistIp,");
            builder.Append("LeftHeight=@LeftHeight,");
            builder.Append("RightHeight=@RightHeight,");
            builder.Append("OldHealthStaus=@OldHealthStaus,");
            builder.Append("OldSelfCareability=@OldSelfCareability,");
            builder.Append("LeftReason=@LeftReason,");
            builder.Append("RightReason=@RightReason, ");
            builder.Append("SelfID=@SelfID, ");
            builder.Append("OldMange=@OldMange ");
            builder.Append(" where OutKey=@OutKey ");
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
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8),
                new MySqlParameter("@LeftReason", MySqlDbType.String, 100),
                new MySqlParameter("@RightReason", MySqlDbType.String, 100),
                new MySqlParameter("@SelfID", MySqlDbType.Int32,4),
                new MySqlParameter("@OldMange",MySqlDbType.String,1)
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
            cmdParms[23].Value = model.SelfID;
            cmdParms[24].Value = model.OldMange;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public RecordsGeneralConditionModel GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,AnimalHeat,BreathRate,Waistline,Height,OldRecognise,OldEmotion,PulseRate,Weight,BMI,InterScore,GloomyScore,LeftPre,RightPre,WaistIp,LeftHeight,RightHeight,OldHealthStaus,OldSelfCareability,OutKey,LeftReason,RightReason,SelfID,OldMange from ARCHIVE_GENERALCONDITION ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;
            new RecordsGeneralConditionModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public bool UpdateByMiniPad(RecordsGeneralConditionModel model, string checkDate) //血压的更新
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

        public bool UpdateByMiniTTPad(RecordsGeneralConditionModel model, string checkDate) //体重体质指数的更新
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

        public bool UpdateByMiniTWPad(RecordsGeneralConditionModel model, string checkDate) //体温更新
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

        public DataSet GetModelByCheckDate(string IDCardNo, string checkDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT D.ID,D.PhysicalID,D.IDCardNo,D.AnimalHeat,D.BreathRate,D.Waistline,D.Height,D.OldRecognise,D.OldEmotion,");
            builder.Append("D.PulseRate,D.Weight,D.BMI,D.InterScore,D.GloomyScore,D.LeftPre,D.RightPre,D.WaistIp,D.LeftHeight,D.RightHeight,");
            builder.Append("D.OldHealthStaus,D.OldSelfCareability,D.SelfID,M.CheckDate ");
            builder.Append(" FROM ARCHIVE_GENERALCONDITION D ");
            builder.Append(" INNER JOIN ARCHIVE_CUSTOMERBASEINFO M ON M.ID=D.OutKey ");
            builder.Append(" AND M.CheckDate=(SELECT MAX(CheckDate) FROM ARCHIVE_CUSTOMERBASEINFO ");
            builder.Append("    WHERE IDCardNo=@IDCardNo AND LEFT(CheckDate,4)=@checkDate) ");
            builder.Append(" WHERE M.IDCardNo=@IDCardNo");

            if (Convert.ToString(checkDate).Length > 3) checkDate = checkDate.Substring(0, 4);

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", IDCardNo),
                new MySqlParameter("@checkDate", checkDate)
            };

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        public DataTable GetMaxDateModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("select a.ID,a.PhysicalID,a.IDCardNo,a.AnimalHeat,a.BreathRate,a.Waistline,a.Height,a.OldRecognise,a.OldEmotion,");
            builder.Append("a.PulseRate,a.Weight,a.BMI,a.InterScore,a.GloomyScore,a.LeftPre,a.RightPre,a.WaistIp,a.LeftHeight,a.RightHeight,");
            builder.Append("a.OldHealthStaus,a.OldSelfCareability,a.OutKey,a.SelfID ");
            builder.Append("from ARCHIVE_GENERALCONDITION a inner join  ARCHIVE_CUSTOMERBASEINFO b on a.IDCardNo = b.IDCardNo ");
            builder.Append(" where a.IDCardNo=@IDCardNo order by b.CheckDate,a.OutKey desc LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            if (set.Tables[0].Rows.Count > 0) return set.Tables[0];

            return null;
        }

        /// <summary>
        /// 身高体重的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool UpdateByMiniSTPad(RecordsGeneralConditionModel model, string checkDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                            ARCHIVE_GENERALCONDITION  D
                                       SET 
                                            Weight=@Weight
                                            ,BMI=@BMI
                                            ,Height=@Height");

            if (model.Waistline.HasValue)
                builder.Append(@",Waistline=@Waistline");

            builder.Append(@" 
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
                new MySqlParameter("@CheckDate", checkDate),
                new MySqlParameter("@Weight", model.Weight),
                new MySqlParameter("@BMI", model.BMI),
                new MySqlParameter("@Height", model.Height),
                new MySqlParameter("@Waistline", model.Waistline)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 修改BMI
        /// </summary>
        /// <param name="outKey"></param>
        /// <param name="bMI"></param>
        /// <returns></returns>
        public bool UpdateBMI(int outKey,decimal? bMI) {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_GENERALCONDITION set ");
            builder.Append("BMI=@BMI");
            builder.Append(" where OutKey=@OutKey ");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8)
             };

            cmdParms[0].Value = bMI;
            cmdParms[1].Value = outKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}