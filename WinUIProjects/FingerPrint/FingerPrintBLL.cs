using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.MySQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FingerPrint
{
    public class FingerPrintBLL
    {
        /// <summary>
        /// 保存指纹&身份证对应
        /// </summary>
        /// <param name="strfingerid"></param>
        /// <param name="strIDCard"></param>
        public void SaveFingerInfo(string strfingerid, string strIDCard)
        {
            StringBuilder sbSave = new StringBuilder();
            sbSave.Append(@"insert into 
                            tbl_fingerinfo
                            (
                                fingerid
                                ,idcardno
                            )
                            values
                            (
                                @fingerid
                                ,@idcardno
                            )");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();
            cmdParms.Add(new MySqlParameter("@fingerid", strfingerid));
            cmdParms.Add(new MySqlParameter("@idcardno", strIDCard));

            MySQLHelper.ExecuteSql(sbSave.ToString(), cmdParms.ToArray());
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
                                fingerid 
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
        /// 根据指纹ID获取身份
        /// </summary>
        /// <param name="strIDCard"></param>
        /// <returns></returns>
        public string GetIDCardNoByFinerID(string strfingerID)
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(@"SELECT 
                                idcardno 
                            FROM 
                                tbl_fingerinfo 
                            WHERE fingerid = @fingerid");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            cmdParms.Add(new MySqlParameter("@fingerid", strfingerID));

            DataSet ds = MySQLHelper.ExecuteDataSet(MySQLHelper.ConnectionString, CommandType.Text, sbQuery.ToString(), cmdParms.ToArray());

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return "";
            }

            return ds.Tables[0].Rows[0][0].ToString();
        }

        /// <summary>
        /// 删除不存在的指纹id
        /// </summary>
        public void DeleteFingerInfo()
        {
            StringBuilder sbSave = new StringBuilder();
            sbSave.Append(@"delete FROM
                            tbl_fingerinfo
                            where 
                            idcardno not IN
                            (
	                            SELECT tbl_recordsbaseinfo.IDCardNo from tbl_recordsbaseinfo
                            )");

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            MySQLHelper.ExecuteSql(sbSave.ToString(), cmdParms.ToArray());
        }
    }
}