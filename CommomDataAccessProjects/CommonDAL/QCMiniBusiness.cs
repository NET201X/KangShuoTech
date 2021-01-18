using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using CommonUtilities.SQL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Data.SQLite;
using System.Configuration;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class QCMiniBusiness
    {
        #region 血压 血糖 身高体重 尿仪 体温体重

        /// <summary>
        /// 获取资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="deviceType">设备类型 20:血压 24:血糖 39:身高体重 33:尿仪 22:体温 40:体重</param>
        /// <returns></returns>
        public int GetDeviceInfoCount(string startDate, string endDate, string deviceType, string conn)
        {
            string sql = @"SELECT Count(0) FROM DeviceInfo WHERE DATE(UpdateData) IS NOT NULL ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(UpdateData) BETWEEN @StartDate AND @EndDate ";
            }

            if (deviceType.Length > 0)
            {
                if (deviceType.Equals("22")) sql += "AND (Devicetype='22' OR Devicetype='40') ";
                else sql += "AND Devicetype=@DeviceType ";
            }

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));
            param.Add(new SQLiteParameter("@DeviceType", deviceType));

            object result = YcSqliteHelper.GetSingle(sql, param, conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="deviceType">设备类型 20:血压 24:血糖 39:身高体重 33:尿仪 22:体温 40:体重</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetDeviceInfo(string startDate, string endDate, string deviceType, int startIndex, int endIndex, string conn)
        {
            string sql = @"SELECT *,DATE(UpdateData) CheckDate FROM DeviceInfo WHERE DATE(UpdateData) IS NOT NULL ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(UpdateData) BETWEEN @StartDate AND @EndDate ";
            }

            if (deviceType.Length > 0)
            {
                if (deviceType.Equals("22")) sql += "AND (Devicetype='22' OR Devicetype='40') ";
                else sql += "AND Devicetype=@DeviceType ";
            }

            sql += "ORDER BY ID ";
            sql += "LIMIT @StartIndex,@EndIndex";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));
            param.Add(new SQLiteParameter("@DeviceType", deviceType));
            param.Add(new SQLiteParameter("@StartIndex", startIndex));
            param.Add(new SQLiteParameter("@EndIndex", endIndex));

            DataSet ds = YcSqliteHelper.Query(sql, param, conn);

            return ds;
        }

        #endregion

        #region 体检问询

        /// <summary>
        /// 获取体检问询资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetMedicalEnquiryCount(string startDate, string endDate, string conn)
        {
            string sql = @"SELECT Count(0) FROM
                                  (
                                        SELECT Count(0) FROM tbl_recordscustomerinfo WHERE 1=1 ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "GROUP BY IDCardNo,DATE(RecordDate) ";
            sql += ") AS DATAS ";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            object result = YcSqliteHelper.GetSingle(sql, param, conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取体检问询资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetMedicalEnquiry(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            // 体检问询
            string sql = "SELECT * FROM tbl_recordscustomerinfo WHERE 1=1 ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "GROUP BY IDCardNo,DATE(RecordDate) ";
            sql += "ORDER BY IDCardNo,DATE(RecordDate),ID ";
            sql += "LIMIT @StartIndex,@EndIndex";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));
            param.Add(new SQLiteParameter("@StartIndex", startIndex));
            param.Add(new SQLiteParameter("@EndIndex", endIndex));

            DataSet ds = YcSqliteHelper.Query(sql, param, conn);

            return ds;
        }

        /// <summary>
        /// 获取体检问询用药资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public DataSet GetMedication(string startDate, string endDate, string conn)
        {
            // 体检问询用药
            string sql = @"SELECT * FROM ARCHIVE_MEDICATION WHERE EXISTS 
                                (
                                    SELECT ID FROM tbl_recordscustomerinfo
                                    WHERE ID = OutKey ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "GROUP BY IDCardNo,DATE(RecordDate)";
            sql += ")";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            DataSet ds = YcSqliteHelper.Query(sql, param, conn);

            return ds;
        }

        /// <summary>
        /// 获取体检问询住院、免疫接种史资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public DataSet GetHistory(string startDate, string endDate, string conn)
        {
            // 判断分离式中是否有住院史及接种史的表
            string isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='tbl_RecordsHistory'";

            object single = YcSqliteHelper.GetSingle(isExist, conn);

            if (single != null && Convert.ToInt32(single) > 0)
            {
                // 住院、免疫接种史
                string sql = @"SELECT * FROM tbl_RecordsHistory WHERE EXISTS 
                                (
                                    SELECT ID FROM tbl_recordscustomerinfo
                                    WHERE ID = OutKey ";

                if (startDate.Length > 0)
                {
                    sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
                }

                sql += "GROUP BY IDCardNo,DATE(RecordDate)";
                sql += ")";

                List<SQLiteParameter> param = new List<SQLiteParameter>();

                param.Add(new SQLiteParameter("@StartDate", startDate));
                param.Add(new SQLiteParameter("@EndDate", endDate));

                DataSet ds = YcSqliteHelper.Query(sql, param, conn);

                return ds;
            }

            return null;
        }

        #endregion

        #region 中医体质

        /// <summary>
        /// 获取中医体质资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetMedicineCount(string startDate, string endDate, string conn)
        {
            // 判断分离式中是否有中医体质
            string isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='OLD_MEDICINE_RESULT'";

            object single = YcSqliteHelper.GetSingle(isExist, conn);

            if (single != null && Convert.ToInt32(single) > 0)
            {
                // 中医体质笔数
                string sql = @"SELECT COUNT(0) FROM 
                                  (
                                        SELECT Count(0) FROM OLD_MEDICINE_CN WHERE 1=1 ";

                if (startDate.Length > 0)
                {
                    sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
                }

                sql += "GROUP BY IDCardNo,DATE(RecordDate) ";
                sql += ") AS DATAS ";

                List<SQLiteParameter> param = new List<SQLiteParameter>();

                param.Add(new SQLiteParameter("@StartDate", startDate));
                param.Add(new SQLiteParameter("@EndDate", endDate));

                object result = YcSqliteHelper.GetSingle(sql, param, conn);

                int count = result == null ? 0 : Convert.ToInt32(result);

                // 判断分离式中是否有自理能力表
                isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='OLDER_SELFCAREABILITY'";

                single = YcSqliteHelper.GetSingle(isExist, conn);

                if (single != null && Convert.ToInt32(single) > 0)
                {
                    // 自理能力笔数
                    sql = @"SELECT COUNT(0) FROM 
                                  (
                                        SELECT COUNT(0) FROM OLDER_SELFCAREABILITY WHERE 1=1 ";

                    if (startDate.Length > 0)
                    {
                        sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
                    }

                    sql += "GROUP BY IDCardNo,DATE(RecordDate) ";
                    sql += ") AS DATAS ";

                    result = YcSqliteHelper.GetSingle(sql, param, conn);
                }

                int count2 = result == null ? 0 : Convert.ToInt32(result);

                return count > count2 ? count : count2;
            }

            return 0;
        }

        /// <summary>
        /// 获取中医体质资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetMedicine(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            // 中医体质
            StringBuilder builder = new StringBuilder();

            // 判断分离式中是否有中医体质
            string isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='OLD_MEDICINE_RESULT'";

            object single = YcSqliteHelper.GetSingle(isExist, conn);

            if (single != null && Convert.ToInt32(single) > 0)
            {
                builder.Append("SELECT Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QIconStraint,Characteristic, ");
                builder.Append("MildScore,FaintScore,YangsCore,YinScore,PhlegmdampScore,MuggyScore,BloodStasisScore, ");
                builder.Append("QiConstraintScore,CharacteristicScore,MildAdvising,FaintAdvising,YangAdvising,YinAdvising, ");
                builder.Append("PhlegmdampAdvising,MuggyAdvising,BloodStasisAdvising,QiconstraintAdvising,CharacteristicAdvising, ");
                builder.Append("MildAdvisingEx,FaintAdvisingEx,YangadvisingEx,YinAdvisingEx,PhlegmdampAdvisingEx,MuggyAdvisingEx, ");
                builder.Append("BloodStasisAdvisingEx,QiconstraintAdvisingEx,CharacteristicAdvisingEx, ");
                builder.Append("Medicinecn.RecordDate,Medicinecn.IDCardNo, ");
                builder.Append("Energy,Tired,Breath,Voice,Emotion,Spirit,Alone,Fear,Weight,Eye,FootHand,Stomach,Cold,Influenza,Nasal, ");
                builder.Append("Snore,Allergy,Urticaria,Skin,Scratch,Mouth,Arms,Greasy,Spot,Eczema,Thirsty,Smell,Abdomen,Coolfood, ");
                builder.Append("Defecate,Defecatedry,Medicinecn.Tongue,Vein,'' AS Sign,'' AS Finger ");

                string table = "SELECT COUNT(0) FROM sqlite_master WHERE NAME = 'OLD_MEDICINE_RESULT' AND SQL LIKE '%Tongue%'";

                single = YcSqliteHelper.GetSingle(table, conn);
                int count = 0;

                if (single != null) count = int.Parse(single.ToString());

                if (count > 0) builder.Append(",Result.Tongue AS TongueM,TongueColor,TongueFur,Pulse ");

                builder.Append("FROM OLD_MEDICINE_CN Medicinecn ");
                builder.Append("LEFT JOIN OLD_MEDICINE_RESULT Result ");
                builder.Append("ON Result.IDCardNo=Medicinecn.IDCardNo ");
                builder.Append("AND Result.RecordDate=Medicinecn.RecordDate ");
                builder.Append("WHERE 1=1 ");

                if (startDate.Length > 0)
                {
                    builder.Append("AND DATE(Medicinecn.RecordDate) BETWEEN @StartDate AND @EndDate ");
                }

                builder.Append(" GROUP BY Medicinecn.IDCardNo,DATE(Medicinecn.RecordDate) ");
                builder.Append(" ORDER BY Medicinecn.IDCardNo,DATE(Medicinecn.RecordDate),Medicinecn.ID ");
                builder.Append(" LIMIT @StartIndex,@EndIndex ");

                List<SQLiteParameter> param = new List<SQLiteParameter>();

                param.Add(new SQLiteParameter("@StartDate", startDate));
                param.Add(new SQLiteParameter("@EndDate", endDate));
                param.Add(new SQLiteParameter("@StartIndex", startIndex));
                param.Add(new SQLiteParameter("@EndIndex", endIndex));

                DataSet ds = YcSqliteHelper.Query(builder.ToString(), param, conn);

                return ds;
            }

            return null;
        }

        /// <summary>
        /// 获取自理能力资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public DataSet GetOldSelf(string startDate, string endDate, string conn)
        {
            // 判断分离式中是否有自理能力表
            string isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='OLDER_SELFCAREABILITY'";

            object single = YcSqliteHelper.GetSingle(isExist, conn);

            if (single != null && Convert.ToInt32(single) > 0)
            {
                // 自理能力
                string sql = @"SELECT * FROM OLDER_SELFCAREABILITY WHERE 1=1 ";

                if (startDate.Length > 0)
                {
                    sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
                }

                sql += "GROUP BY IDCardNo,DATE(RecordDate)";

                List<SQLiteParameter> param = new List<SQLiteParameter>();

                param.Add(new SQLiteParameter("@StartDate", startDate));
                param.Add(new SQLiteParameter("@EndDate", endDate));

                DataSet ds = YcSqliteHelper.Query(sql, param, conn);

                return ds;
            }

            return null;
        }

        #endregion

        #region 心电

        /// <summary>
        /// 获取心电资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetECGCount(string startDate, string endDate, string conn)
        {
            // 心电
            string sql = "SELECT Count(0) FROM QRCodeInfo WHERE ECGDate IS NOT NULL ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(ECGDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "ORDER BY ID";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            object result = YcSqliteHelper.GetSingle(sql, param, conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取心电资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetECG(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            // 心电资料
            string sql = "SELECT *,'' AS Picture FROM QRCodeInfo WHERE ECGDate IS NOT NULL ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(ECGDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "ORDER BY ID ";
            sql += "LIMIT @StartIndex,@EndIndex";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));
            param.Add(new SQLiteParameter("@StartIndex", startIndex));
            param.Add(new SQLiteParameter("@EndIndex", endIndex));

            DataSet ds = YcSqliteHelper.Query(sql, param, conn);

            return ds;
        }

        #endregion

        #region 一代B超

        /// <summary>
        /// 获取B超资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetBTypeCount(string startDate, string endDate, string conn)
        {
            // B超资料
            string sql = "SELECT Count(0) FROM PTNTBL WHERE CHKSTS=1 AND PTNIDNO<>'' ";

            List<FbParameter> cmdParms = new List<FbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                sql += " AND DIAGTM>@StartDate AND DIAGTM<@EndDate ";

                cmdParms.Add(new FbParameter("@StartDate", startDate));
                cmdParms.Add(new FbParameter("@EndDate", endDate));
            }

            object result = FbHelper.GetSingle(sql, cmdParms.ToArray(), conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取B超资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetBType(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            // B超资料
            string sql = "SELECT *, '' AS Picture FROM PTNTBL WHERE CHKSTS=1 AND PTNIDNO<>'' ";

            List<FbParameter> cmdParms = new List<FbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                sql += " AND DIAGTM>@StartDate AND DIAGTM<@EndDate ";

                cmdParms.Add(new FbParameter("@StartDate", startDate));
                cmdParms.Add(new FbParameter("@EndDate", endDate));

            }

            sql += "ORDER BY RECID ";
            sql += "ROWS @StartIndex TO @EndIndex";

            cmdParms.Add(new FbParameter("@StartIndex", startIndex));
            cmdParms.Add(new FbParameter("@EndIndex", endIndex));

            try
            {
                DataSet ds = FbHelper.ExecuteQuery(sql, cmdParms.ToArray(), conn);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 五官

        /// <summary>
        /// 获取五官资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetMouthCount(string startDate, string endDate, string conn)
        {
            // 五官
            string sql = "SELECT Count(0) FROM tbl_Mouth WHERE 1=1 ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "ORDER BY ID";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            object result = YcSqliteHelper.GetSingle(sql, param, conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 取得对应条件的五官科资料
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetMouth(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            // 五官资料
            string sql = @"
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
                            FROM tbl_Mouth WHERE 1=1 ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "ORDER BY ID ";
            sql += "LIMIT @StartIndex,@EndIndex";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));
            param.Add(new SQLiteParameter("@StartIndex", startIndex));
            param.Add(new SQLiteParameter("@EndIndex", endIndex));

            DataSet ds = YcSqliteHelper.Query(sql, param, conn);

            return ds;
        }

        #endregion

        #region 外科

        /// <summary>
        /// 获取外科资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetSurgicalCount(string startDate, string endDate, string conn)
        {
            // 外科
            string sql = "SELECT Count(0) FROM tbl_Surgical WHERE 1=1 ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "ORDER BY ID";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            object result = YcSqliteHelper.GetSingle(sql, param, conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 取得对应条件的外科资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetSurgical(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            // 外科
            string sql = @"
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
                            FROM tbl_Surgical WHERE 1=1 ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "ORDER BY ID ";
            sql += "LIMIT @StartIndex,@EndIndex";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));
            param.Add(new SQLiteParameter("@StartIndex", startIndex));
            param.Add(new SQLiteParameter("@EndIndex", endIndex));

            DataSet ds = YcSqliteHelper.Query(sql, param, conn);

            return ds;
        }

        #endregion

        #region 内科

        /// <summary>
        /// 获取内科资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetInternalMedicineCount(string startDate, string endDate, string conn)
        {
            // 内科
            string sql = "SELECT Count(0) FROM tbl_InternalMedicine WHERE 1=1 ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "ORDER BY ID";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            object result = YcSqliteHelper.GetSingle(sql, param, conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 取得对应条件的内科资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetInternalMedicine(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            // 内科资料
            string sql = "SELECT * FROM tbl_InternalMedicine WHERE 1=1 ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "ORDER BY ID ";
            sql += "LIMIT @StartIndex,@EndIndex";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));
            param.Add(new SQLiteParameter("@StartIndex", startIndex));
            param.Add(new SQLiteParameter("@EndIndex", endIndex));

            DataSet ds = YcSqliteHelper.Query(sql, param, conn);

            return ds;
        }

        #endregion

        #region X光

        /// <summary>
        /// 获取X光资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetRecordsChestXCount(string startDate, string endDate, string conn)
        {
            // X光
            string sql = "SELECT Count(0) FROM tbl_RecordsChestX WHERE 1=1 ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "ORDER BY ID";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            object result = YcSqliteHelper.GetSingle(sql, param, conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 取得对应条件的X光资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetRecordsChestX(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            // X光
            string sql = "SELECT * FROM tbl_RecordsChestX WHERE 1=1 ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            sql += "ORDER BY ID ";
            sql += "LIMIT @StartIndex,@EndIndex";

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));
            param.Add(new SQLiteParameter("@StartIndex", startIndex));
            param.Add(new SQLiteParameter("@EndIndex", endIndex));

            DataSet ds = YcSqliteHelper.Query(sql, param, conn);

            return ds;
        }

        #endregion

        #region 视力

        /// <summary>
        /// 获取视力资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetVsiualCount(string startDate, string endDate, string conn)
        {
            // 视力资料
            string sql = "SELECT Count(0) FROM VisionInFo ";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                sql += " AND (AddTime BETWEEN @StartDate AND @EndDate OR AddTime BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            object result = AccessDBUtil.ExecuteScalar(sql, cmdParms.ToArray(), conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取视力资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetVsiual(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            string where = "";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                where = " AND (AddTime BETWEEN @StartDate AND @EndDate OR AddTime BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            // 视力资料
            string sql = string.Format(@"SELECT A.* FROM
                                (
                                    SELECT TOP {0} * FROM VisionInFo   
                                        {2}
                                        ORDER BY ID
                                ) A
                                LEFT JOIN 
                                (
                                    SELECT TOP {1} * FROM VisionInFo   
                                        {2}
                                        ORDER BY ID
                                ) B
                                ON A.ID=B.ID
                                WHERE IIF(B.ID,'0','1')='1' ", endIndex, startIndex, where);

            if (startIndex <= 0)
            {
                sql = string.Format(@"SELECT TOP {0} * FROM VisionInFo {1} ORDER BY ID ", endIndex, where);
            }

            try
            {
                DataSet ds = AccessDBUtil.ExecuteQuery(sql, cmdParms.ToArray(), conn);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 生化

        /// <summary>
        /// 获取生化资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetBiochemicalCount(string startDate, string endDate, string conn)
        {
            // 生化资料
            string sql = "SELECT Count(0) FROM PersonInfoSH WHERE Mark='Y' ";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                sql += " AND (TestTime BETWEEN @StartDate AND @EndDate OR TestTime BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            object result = AccessDBUtil.ExecuteScalar(sql, cmdParms.ToArray(), conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取生化资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetBiochemical(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            string where = "";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                where = " AND (TestTime BETWEEN @StartDate AND @EndDate OR TestTime BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            // 生化资料
            string sql = string.Format(@"SELECT A.* FROM
                                (
                                    SELECT TOP {0} * FROM PersonInfoSH WHERE Mark='Y' 
                                        {2}
                                        ORDER BY ID
                                ) A
                                LEFT JOIN 
                                (
                                    SELECT TOP {1} * FROM PersonInfoSH WHERE Mark='Y' 
                                        {2}
                                        ORDER BY ID
                                ) B
                                ON A.ID=B.ID
                                WHERE IIF(B.ID,'0','1')='1' ", endIndex, startIndex, where);

            if (startIndex <= 0)
            {
                sql = string.Format(@"SELECT TOP {0} * FROM PersonInfoSH WHERE Mark='Y' 
                    {1} ORDER BY ID ", endIndex, where);
            }

            try
            {
                DataSet ds = AccessDBUtil.ExecuteQuery(sql, cmdParms.ToArray(), conn);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 血球

        /// <summary>
        /// 获取血球资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetBloodCount(string startDate, string endDate, string conn)
        {
            // 血球资料
            string sql = "SELECT Count(0) FROM PersonInfoXQ WHERE Mark='Y' ";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                sql += " AND (TestTime BETWEEN @StartDate AND @EndDate OR TestTime BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            object result = AccessDBUtil.ExecuteScalar(sql, cmdParms.ToArray(), conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取血球资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetBlood(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            string where = "";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                where = " AND (TestTime BETWEEN @StartDate AND @EndDate OR TestTime BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            // 血球资料
            string sql = string.Format(@"SELECT A.* FROM
                                (
                                    SELECT TOP {0} * FROM PersonInfoXQ WHERE Mark='Y' 
                                        {2}
                                        ORDER BY ID
                                ) A
                                LEFT JOIN 
                                (
                                    SELECT TOP {1} * FROM PersonInfoXQ WHERE Mark='Y' 
                                        {2}
                                        ORDER BY ID
                                ) B
                                ON A.ID=B.ID
                                WHERE IIF(B.ID,'0','1')='1' ", endIndex, startIndex, where);

            if (startIndex <= 0)
            {
                sql = string.Format(@"SELECT TOP {0} * FROM PersonInfoXQ WHERE Mark='Y' {1} ORDER BY ID ", endIndex, where);
            }

            try
            {
                DataSet ds = AccessDBUtil.ExecuteQuery(sql, cmdParms.ToArray(), conn);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 尿仪

        /// <summary>
        /// 获取尿仪资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetUrineCount(string startDate, string endDate, string conn)
        {
            // 尿仪资料
            string sql = "SELECT Count(0) FROM PersonInfoNJ WHERE Mark='Y' ";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                sql += " AND (TestTime BETWEEN @StartDate AND @EndDate OR TestTime BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            object result = AccessDBUtil.ExecuteScalar(sql, cmdParms.ToArray(), conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取尿仪资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetUrine(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            string where = "";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                where = " AND (TestTime BETWEEN @StartDate AND @EndDate OR TestTime BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            // 尿仪资料
            string sql = string.Format(@"SELECT A.* FROM
                                (
                                    SELECT TOP {0} * FROM PersonInfoNJ WHERE Mark='Y' 
                                        {2}
                                        ORDER BY ID
                                ) A
                                LEFT JOIN 
                                (
                                    SELECT TOP {1} * FROM PersonInfoNJ WHERE Mark='Y' 
                                        {2}
                                        ORDER BY ID
                                ) B
                                ON A.ID=B.ID
                                WHERE IIF(B.ID,'0','1')='1' ", endIndex, startIndex, where);

            if (startIndex <= 0)
            {
                sql = string.Format(@"SELECT TOP {0} * FROM PersonInfoNJ WHERE Mark='Y' {1} ORDER BY ID ", endIndex, where);
            }

            try
            {
                DataSet ds = AccessDBUtil.ExecuteQuery(sql, cmdParms.ToArray(), conn);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 身高体重

        /// <summary>
        /// 获取身高体重资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public DataSet GetHeightWeight(string startDate, string endDate, string conn)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(conn);
                connection.Open();

                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                bool isExist = false;

                // 判断表是否存在
                if (schemaTable != null)
                {
                    for (int row = 0; row < schemaTable.Rows.Count; row++)
                    {
                        string col_name = schemaTable.Rows[row]["TABLE_NAME"].ToString();

                        if (col_name == "BaseInfo") isExist = true;
                    }
                }

                if (!isExist) return null;

                // 身高体重资料
                string sql = "SELECT * FROM BaseInfo WHERE Mark='Y'";

                List<OleDbParameter> cmdParms = new List<OleDbParameter>();

                if (!string.IsNullOrEmpty(startDate))
                {
                    sql += " AND (TestTime BETWEEN @StartDate AND @EndDate OR TestTime BETWEEN @StartDate2 AND @EndDate2) ";

                    cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                    cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                    cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                    cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
                }

                DataSet ds = AccessDBUtil.ExecuteQuery(sql, cmdParms.ToArray(), conn);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 安徽扫码 X光

        /// <summary>
        /// 获取X光资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetChestXCount(string startDate, string endDate, string conn)
        {
            // X光资料
            string sql = "SELECT Count(0) FROM ChestX WHERE 1=1 ";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                sql += " AND LEFT(TestTime, 8) BETWEEN @StartDate AND @EndDate ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate));
            }

            object result = AccessDBUtil.ExecuteScalar(sql, cmdParms.ToArray(), conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取X光资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetChestX(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            string where = "";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                where = " AND LEFT(TestTime, 8) BETWEEN @StartDate AND @EndDate ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate));
            }

            // X光资料
            string sql = string.Format(@"SELECT A.* FROM
                                (
                                    SELECT TOP {0} * FROM ChestX WHERE 1=1
                                        {2}
                                        ORDER BY ID
                                ) A
                                LEFT JOIN 
                                (
                                    SELECT TOP {1} * FROM ChestX WHERE 1=1
                                        {2}
                                        ORDER BY ID
                                ) B
                                ON A.ID=B.ID
                                WHERE IIF(B.ID,'0','1')='1' ", endIndex, startIndex, where);

            if (startIndex <= 0)
            {
                sql = string.Format(@"SELECT TOP {0} * FROM ChestX WHERE 1=1 {1} ORDER BY ID ", endIndex, where);
            }

            try
            {
                DataSet ds = AccessDBUtil.ExecuteQuery(sql, cmdParms.ToArray(), conn);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 重庆B超，从access数据中获取B超

        /// <summary>
        /// 获取B超资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetBChaoCount(string startDate, string endDate, string conn)
        {
            // B超资料
            string sql = @"SELECT Count(0) FROM PersonInfoBC WHERE Mark='Y' 
                                  AND ID IN(SELECT MAX(ID) FROM PersonInfoBC GROUP BY IDCardNo)";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                sql += " AND(TestTime BETWEEN @StartDate AND @EndDate OR TestTime BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            object result = AccessDBUtil.ExecuteScalar(sql, cmdParms.ToArray(), conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取B超资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetBChao(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            // B超资料
            string sql = @"SELECT * FROM PersonInfoBC WHERE Mark='Y' 
                                  AND ID IN(SELECT MAX(ID) FROM PersonInfoBC GROUP BY IDCardNo)";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                sql += " AND (TestTime BETWEEN @StartDate AND @EndDate OR TestTime BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            try
            {
                DataSet ds = AccessDBUtil.ExecuteQuery(sql, cmdParms.ToArray(), conn);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 新版B超

        /// <summary>
        /// 获取B超资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetNewBTypeCount(string startDate, string endDate, string conn)
        {
            // B超资料
            string sql = "SELECT Count(0) FROM PatientInfo WHERE  jczt = '是' AND sfzh <> '' ";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                sql += " AND (jcrq BETWEEN @StartDate AND @EndDate OR jcrq BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            object result = AccessDBUtil.ExecuteScalar(sql, cmdParms.ToArray(), conn);

            return result == null ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取B超资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetNewBType(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            // B超资料
            string where = "";

            List<OleDbParameter> cmdParms = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(startDate))
            {
                where = " AND (jcrq BETWEEN @StartDate AND @EndDate OR jcrq BETWEEN @StartDate2 AND @EndDate2) ";

                cmdParms.Add(new OleDbParameter("@StartDate", startDate + " 00:00:00"));
                cmdParms.Add(new OleDbParameter("@EndDate", endDate + " 23:59:59"));
                cmdParms.Add(new OleDbParameter("@StartDate2", startDate));
                cmdParms.Add(new OleDbParameter("@EndDate2", endDate));
            }

            string sql = string.Format(@"SELECT A.*, '' AS Picture FROM
                                (
                                    SELECT TOP {0} * FROM PatientInfo WHERE  jczt = '是' AND sfzh <> ''
                                        {2}
                                        ORDER BY uid
                                ) A
                                LEFT JOIN 
                                (
                                    SELECT TOP {1} * FROM PatientInfo WHERE  jczt = '是' AND sfzh <> ''
                                        {2}
                                        ORDER BY uid
                                ) B
                                ON A.uid=B.uid
                                WHERE IIF(B.uid,'0','1')='1' ", endIndex, startIndex, where);

            if (startIndex <= 0)
            {
                sql = string.Format(@"SELECT TOP {0} *, '' AS Picture FROM PatientInfo WHERE  jczt = '是' AND sfzh <> ''
                        {1} ORDER BY uid ", endIndex, where);
            }

            try
            {
                DataSet ds = AccessDBUtil.ExecuteQuery(sql, cmdParms.ToArray(), conn);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 抑郁评估

        /// <summary>
        /// 查询抑郁评估笔数
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public int GetGloomyCount(string startDate, string endDate, string conn)
        {
            // 判断分离式中是否有抑郁评估表
            string isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='tbl_oldgloomy'";

            object single = YcSqliteHelper.GetSingle(isExist, conn);
            if (single == null || Convert.ToInt32(single) == 0) return 0;

            string sql = @"SELECT Count(*) FROM tbl_oldgloomy WHERE 1=1  ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            object result = YcSqliteHelper.GetSingle(sql, param, conn);

            int count = result == null ? 0 : Convert.ToInt32(result);

            return count;
        }

        /// <summary>
        /// 获取抑郁评估资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetGloomy(string startDate, string endDate, string conn)
        {
            // 判断分离式中是否有抑郁评估表
            string isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='tbl_oldgloomy'";

            object single = YcSqliteHelper.GetSingle(isExist, conn);
            if (single == null || Convert.ToInt32(single) == 0) return null;

            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_oldgloomy  ");
            builder.Append("WHERE 1=1 ");

            if (startDate.Length > 0)
            {
                builder.Append("AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ");
            }

            builder.Append(" ORDER BY DATE(RecordDate) ASC ");

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            DataSet ds = YcSqliteHelper.Query(builder.ToString(), param, conn);

            return ds;
        }

        #endregion

        #region 智力评估

        /// <summary>
        /// 查询智力评估笔数
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public int GetIntelligenceCount(string startDate, string endDate, string conn)
        {
            // 判断分离式中是否有抑郁评估表
            string isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='tbl_oldintelligence'";
            object single = YcSqliteHelper.GetSingle(isExist, conn);

            if (single == null || Convert.ToInt32(single) == 0) return 0;

            string sql = @"SELECT Count(*) FROM tbl_oldintelligence WHERE 1=1  ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            object result = YcSqliteHelper.GetSingle(sql, param, conn);

            int count = result == null ? 0 : Convert.ToInt32(result);

            return count;
        }

        /// <summary>
        /// 获取智力评估资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public DataSet GetIntelligence(string startDate, string endDate, string conn)
        {
            // 判断分离式中是否有抑郁评估表
            string isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='tbl_oldintelligence'";
            object single = YcSqliteHelper.GetSingle(isExist, conn);

            if (single == null || Convert.ToInt32(single) == 0) return null;

            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_oldintelligence ");
            builder.Append("WHERE 1=1 ");

            if (startDate.Length > 0)
            {
                builder.Append("AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ");
            }

            builder.Append(" ORDER BY DATE(RecordDate) ASC ");

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            DataSet ds = YcSqliteHelper.Query(builder.ToString(), param, conn);

            return ds;
        }

        #endregion

        #region 健康状况

        /// <summary>
        /// 查询健康状况笔数
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int GetHealthCount(string startDate, string endDate, string conn)
        {
            // 判断分离式中是否有健康状况表
            string isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='ARCHIVE_HEALTH_CONDITION'";
            object single = YcSqliteHelper.GetSingle(isExist, conn);

            if (single == null || Convert.ToInt32(single) == 0) return 0;

            string sql = @"SELECT Count(*) FROM ARCHIVE_HEALTH_CONDITION WHERE 1=1  ";

            if (startDate.Length > 0)
            {
                sql += "AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ";
            }

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            object result = YcSqliteHelper.GetSingle(sql, param, conn);

            int count = result == null ? 0 : Convert.ToInt32(result);

            return count;
        }

        /// <summary>
        /// 获取健康状况资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetHealth(string startDate, string endDate, string conn)
        {
            // 判断分离式中是否有健康状况表
            string isExist = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='ARCHIVE_HEALTH_CONDITION'";
            object single = YcSqliteHelper.GetSingle(isExist, conn);

            if (single == null || Convert.ToInt32(single) == 0) return null;

            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_HEALTH_CONDITION ");
            builder.Append("WHERE 1=1 ");

            if (startDate.Length > 0)
            {
                builder.Append("AND DATE(RecordDate) BETWEEN @StartDate AND @EndDate ");
            }

            builder.Append(" ORDER BY DATE(RecordDate) ASC ");

            List<SQLiteParameter> param = new List<SQLiteParameter>();

            param.Add(new SQLiteParameter("@StartDate", startDate));
            param.Add(new SQLiteParameter("@EndDate", endDate));

            DataSet ds = YcSqliteHelper.Query(builder.ToString(), param, conn);

            return ds;
        }

        #endregion
    }
}