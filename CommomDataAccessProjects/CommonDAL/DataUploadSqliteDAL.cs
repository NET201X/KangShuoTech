
using CommonUtilities.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class DataUploadSqliteDAL
    {
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

        /// <summary>
        /// 一代心电
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetFirstECGList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM apply WHERE createTime IS NOT NULL ");

            if (strWhere.Trim() != "")
            {
                builder.Append(strWhere);
            }

            builder.Append(" GROUP BY cardNumber,DATE(createTime) ");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }

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
                                    FROM tbl_RecordsHistory 
                                    WHERE EXISTS 
                                    (
                                        SELECT ID FROM tbl_recordscustomerinfo
                                        WHERE ID = OutKey ");

                if (strWhere.Trim() != "")
                {
                    builder.Append(strWhere);
                }

                builder.Append(" GROUP BY IDCardNo,DATE(RecordDate)) ");

                return YcSqliteHelper.Query(builder.ToString(), conn);
            }

            return new DataSet();
        }
    }
}
