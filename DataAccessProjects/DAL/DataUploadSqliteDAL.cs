namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using KangShuoTech.Utilities.SQLiteHelper;

    public class DataUploadSqliteDAL
    {
        public DataSet GetMaxList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * ");
            builder.Append(" FROM tbl_recordscustomerinfo ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY IDCardNo,DATE(RecordDate) ");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }

        /// <summary>
        /// 取得住院史及接种史
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetHistoryList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();

            // 判断分离式中是否有住院史及接种史的表
            builder.Append("SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME='tbl_RecordsHistory'");

            object single = YcSqliteHelper.GetSingle(builder.ToString(), conn);

            if (single != null && Convert.ToInt32(single) > 0)
            {
                builder.Clear();
                builder.Append(@"SELECT 
                                        ID
                                        ,IDCardNo
                                        ,Type
                                        ,RecordDate
                                        ,InDate
                                        ,Reason
                                        ,IllcaseNum
                                        ,Name
                                        ,OutDate
                                        ,InoculationHistory
                                        ,OutKey
                                    FROM tbl_RecordsHistory");

                if (strWhere.Trim() != "")
                {
                    builder.Append(" WHERE 1=1 " + strWhere);
                }

                builder.Append(" GROUP BY IDCardNo,DATE(RecordDate),Type ");

                return YcSqliteHelper.Query(builder.ToString(), conn);
            }

            return new DataSet();
        }

        /// <summary>
        /// 心电
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetECGList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM QRCodeInfo WHERE ECGDate IS NOT NULL ");

            if (strWhere.Trim() != "")
            {
                builder.Append(strWhere);
            }

            builder.Append(" GROUP BY IDCard,DATE(ECGDate) ");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }

        #region X光

        /// <summary>
        /// 取得对应条件的X光资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetChestXList(string strWhere)
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

            return YcSqliteHelper.Query(sbQuery.ToString());
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
                                tbl_recordsassistcheck D
                            SET 
                                CHESTX = @CHESTX 
                                ,CHESTXEx = @CHESTXEx
                            WHERE 
                                EXISTS
                                (
                                    SELECT 
                                        D.ID 
                                    FROM
                                        tbl_recordscustomerbaseinfo M 
                                    WHERE  
                                        IFNULL(M.IsDel,'')!='Y'
                                        AND M.ID= D.OUTkey
                                        AND M.IDCardNo = @IDCardNo
                                        AND M.CheckDate = @CheckDate
                                );  ");

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
                                tbl_recordsassistcheck
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
