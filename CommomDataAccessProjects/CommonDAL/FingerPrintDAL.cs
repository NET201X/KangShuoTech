using MySql.Data.MySqlClient;
using CommonUtilities.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class FingerPrintDAL
    {
        /// <summary>
        /// 保存指纹&身份证对应
        /// </summary>
        /// <param name="strfingerid"></param>
        /// <param name="strIDCard"></param>
        /// <param name="strFingerInfo"></param>
        public string SaveFingerInfo(string strfingerid, string strIDCard, string strFingerInfo)
        {
            StringBuilder sbSave = new StringBuilder();
            sbSave.Append(@"INSERT INTO 
                            tbl_fingerinfo
                            (
                                fingerid
                                ,idcardno
                                ,FingerInfo
                            )
                            VALUES
                            (
                                @fingerid
                                ,@idcardno
                                ,@FingerInfo
                            )");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();
            cmdParms.Add(new MySqlParameter("@idcardno", strIDCard));
            cmdParms.Add(new MySqlParameter("@FingerInfo", strFingerInfo));

            // 如果为外接指纹设备时，key值取最大值+1
            if (strfingerid == "0")
            {
                strfingerid = (Convert.ToInt32(GetMaxFinerID()) + 1).ToString();
            }

            cmdParms.Add(new MySqlParameter("@fingerid", strfingerid));

            MySQLHelper.ExecuteSql(sbSave.ToString(), cmdParms.ToArray());

            return strfingerid;
        }

        /// <summary>
        /// 根据身份获取指纹ID
        /// </summary>
        /// <param name="strIDCard"></param>
        /// <returns></returns>
        public string GetFinerIDByIDCardNo(string strIDCard)
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(@"SELECT 
                                FingerInfo 
                            FROM 
                                tbl_fingerinfo 
                            WHERE idcardno = @idcardno");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            cmdParms.Add(new MySqlParameter("@idcardno", strIDCard));

            DataSet ds = MySQLHelper.ExecuteDataSet(MySQLHelper.ConnectionString, CommandType.Text, sbQuery.ToString(), cmdParms.ToArray());

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return "";
            }

            return ds.Tables[0].Rows[0][0].ToString();
        }

        /// <summary>
        /// 获取最大指纹ID
        /// </summary>
        /// <param name="strIDCard"></param>
        /// <returns></returns>
        public string GetMaxFinerID()
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(@"SELECT 
                                IFNULL(MAX(fingerid), 0)
                            FROM 
                                tbl_fingerinfo ");

            DataSet ds = MySQLHelper.ExecuteDataSet(MySQLHelper.ConnectionString, CommandType.Text,
                sbQuery.ToString());

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return "0";
            }

            return ds.Tables[0].Rows[0][0].ToString();
        }

        /// <summary>
        /// 根据指纹ID获取身份
        /// </summary>
        /// <param name="strIDCard"></param>
        /// <returns></returns>
        public string GetIDCardNoByFinerID(string strFingerID)
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(@"SELECT 
                                idcardno 
                            FROM 
                                tbl_fingerinfo 
                            WHERE fingerid = @fingerid");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            cmdParms.Add(new MySqlParameter("@fingerid", strFingerID));

            DataSet ds = MySQLHelper.ExecuteDataSet(MySQLHelper.ConnectionString, CommandType.Text, sbQuery.ToString(), cmdParms.ToArray());

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return "";
            }

            return ds.Tables[0].Rows[0][0].ToString();
        }

        /// <summary>
        /// 取得所有指纹记录
        /// </summary>
        /// <param name="strIDCard"></param>
        /// <returns></returns>
        public DataTable GetFingerInfo()
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(@"SELECT 
                                idcardno
                                ,FingerInfo
                            FROM 
                                tbl_fingerinfo ");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            DataSet ds = MySQLHelper.ExecuteDataSet(MySQLHelper.ConnectionString, 
                CommandType.Text, sbQuery.ToString());

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return new DataTable();
            }

            return ds.Tables[0];
        }

        /// <summary>
        /// 删除不存在的指纹id
        /// </summary>
        public void DeleteFingerInfo()
        {
            StringBuilder sbSave = new StringBuilder();
            sbSave.Append(@"DELETE FROM
                            tbl_fingerinfo
                            WHERE 
                            idcardno not IN
                            (
	                            SELECT tbl_recordsbaseinfo.IDCardNo FROM tbl_recordsbaseinfo
                            )");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            MySQLHelper.ExecuteSql(sbSave.ToString(), cmdParms.ToArray());
        }
    }
}