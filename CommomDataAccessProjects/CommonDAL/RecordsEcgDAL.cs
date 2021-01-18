using CommonUtilities.SQL;
using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsEcgDAL
    {
        public DataSet GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT E.IDCardNo,T.CustomerName,T.Sex,T.Nation,T.Birthday,T.Phone,T.HouseHoldAddress,");
            builder.Append("E.Conclusion ,MAX(E.MID) AS MID,T.Minority ");
            builder.Append(" FROM  ARCHIVE_ECG E LEFT JOIN ARCHIVE_BASEINFO T ON T.IDCardNo = E.IDCardNo");
            builder.Append(" LEFT JOIN ARCHIVE_CUSTOMERBASEINFO B ON T.IDCardNo = B.IDCardNo ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY E.IDCardNo");

            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                builder.Append(" ORDER BY T." + orderBy);
            }
            else
            {
                builder.Append(" ORDER BY T.ID DESC");
            }

            builder.Append(string.Format(" LIMIT {0},{1}", startIndex, endIndex));

            return MySQLHelper.Query(builder.ToString());
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT COUNT(*) FROM ");
            builder.Append(" (SELECT MAX(E.MID)AS MID FROM  ARCHIVE_ECG E LEFT JOIN ARCHIVE_BASEINFO T  ON T.IDCardNo = E.IDCardNo ");
            builder.Append(" LEFT JOIN ARCHIVE_CUSTOMERBASEINFO B ON E.IDCardNo = B.IDCardNo ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            builder.Append(" GROUP BY E.IDCardNo)F ");

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public int GetMIDCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT COUNT(*) FROM ");
            builder.Append(" (SELECT MAX(E.MID)AS MID FROM  ARCHIVE_ECG E LEFT JOIN ARCHIVE_BASEINFO T  ON T.IDCardNo = E.IDCardNo ");
            builder.Append(" LEFT JOIN ARCHIVE_CUSTOMERBASEINFO B ON E.IDCardNo = B.IDCardNo ");
            builder.Append(" WHERE MID IS NOT NULL ");

            if (strWhere.Trim() != "")
            {
                builder.Append(string.Format("AND E.IDCardNo = '{0}' ", strWhere));
            }
            builder.Append(" GROUP BY E.IDCardNo) F ");

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetUserDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT T.CreateMenName FROM  ARCHIVE_ECG E LEFT JOIN ARCHIVE_BASEINFO T ON T.IDCardNo = E.IDCardNo ");
            builder.Append("LEFT JOIN ARCHIVE_CUSTOMERBASEINFO B ON E.IDCardNo = B.IDCardNo ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY T.CreateMenName ");

            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetMaxModel(string IDCardNo, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_ECG ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (Convert.ToString(CheckDate).Length > 3) CheckDate = CheckDate.Substring(0, 4);
            if (CheckDate != "") builder.Append("AND LEFT(CreateTime,4)=@CreateTime");

            builder.Append(" ORDER BY CreateTime DESC,ID DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@CreateTime", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public int Add(EcgDataModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_ECG(");
            builder.Append("MID,IDCardNo,Name,Conclusion,CreateTime)");
            builder.Append(" VALUES (");
            builder.Append("@MID,@IDCardNo,@Name,@Conclusion,@CreateTime)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@MID", MySqlDbType.String),
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@Name", MySqlDbType.String),
                new MySqlParameter("@Conclusion", MySqlDbType.String),
                new MySqlParameter("@CreateTime", MySqlDbType.Date)
            };

            cmdParms[0].Value = model.MID;
            cmdParms[1].Value = model.IDCard;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.Conclusion;
            cmdParms[4].Value = model.CreateTime;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public void Delete(EcgDataModel model) {
            StringBuilder builder = new StringBuilder();

            builder.Append("DELETE FROM ARCHIVE_ECG ");
            builder.Append(" WHERE MID=@MID AND IDCardNo=@IDCardNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@MID", model.MID),
                new MySqlParameter("@IDCardNo", model.IDCard)
            };
            MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);
        }
    }

    public class TypeBDAL
    {
        public DataSet GetList(string IDCardNo, string CheckDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT PTNIDNO,CLNCDIAG,DIAG,CONCAT(LEFT(DIAGTM,10),'_',PTNIDNO) AS MID FROM ARCHIVE_ULTRASONICB_RESULT");
            builder.Append(" WHERE PTNIDNO=@IDCardNo ");

            if (Convert.ToString(CheckDate).Length > 3) CheckDate = CheckDate.Substring(0, 4);
            if (CheckDate != "") builder.Append("AND LEFT(DIAGTM,4)=@DIAGTM");

            builder.Append(" ORDER BY DIAGTM DESC,ID DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@DIAGTM", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public DataSet GetPutInfo(string strStart, string strEnd, string conn = "")
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(@"SELECT
	                            PTNTBL.*
                            FROM
                                PTNTBL
                            INNER JOIN
                            (
                                SELECT
  	                                PTNIDNO
                                    ,MAX(DIAGTM) AS DIAGTM
                                FROM
                                    PTNTBL
                                WHERE 
                                    CHKSTS =1
                                    AND PTNIDNO <> '' ");

            List<FbParameter> cmdParms = new List<FbParameter>();

            if (!string.IsNullOrEmpty(strStart))
            {
                sbQuery.Append("  AND DIAGTM>=@strStart");
                cmdParms.Add(new FbParameter("@strStart", strStart));
            }

            if (!string.IsNullOrEmpty(strEnd))
            {
                sbQuery.Append("  AND DIAGTM<=@strEnd");
                cmdParms.Add(new FbParameter("@strEnd", strEnd));
            }

            sbQuery.Append(@" GROUP BY PTNIDNO,LEFT(DIAGTM,10)
                            ) AS LASTV
                            ON PTNTBL.PTNIDNO = LASTV.PTNIDNO
                            AND PTNTBL.DIAGTM = LASTV.DIAGTM
                            order by RECID");

            return FbHelper.ExecuteQuery(sbQuery.ToString(), cmdParms.ToArray(), conn);
        }

        public void InsDB(DataRow drInfo)
        {
            StringBuilder sbQuery = new StringBuilder();
            StringBuilder sbC = new StringBuilder();
            StringBuilder sbCVal = new StringBuilder();

            // MySQLHelper.
            List<MySqlParameter> cmdParms = new List<MySqlParameter>();
            foreach (DataColumn c in drInfo.Table.Columns)
            {
                if (c.ColumnName.ToUpper().Equals("ID")) continue;

                sbC.Append(",").Append(c.ColumnName);
                sbCVal.Append(",@").Append(c.ColumnName);

                cmdParms.Add(new MySqlParameter("@" + c.ColumnName, drInfo[c.ColumnName]));
            }

            sbQuery.Append(@"INSERT INTO ARCHIVE_ULTRASONICB_RESULT (").Append(sbC.ToString().TrimStart(',')).Append(")");
            sbQuery.Append(" VALUES (").Append(sbCVal.ToString().TrimStart(',')).Append(")");

            MySQLHelper.ExecuteSql(sbQuery.ToString(), cmdParms.ToArray());
        }

        public int DelDB(DataRow drInfo)
        {
            StringBuilder sbDelete = new StringBuilder();

            // MySQLHelper.
            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            string dtm = drInfo["DIAGTM"].ToString().Substring(0, 10);

            sbDelete.Append(@"DELETE FROM ARCHIVE_ULTRASONICB_RESULT
                                         WHERE PTNIDNO=@PTNIDNO
                                         AND DIAGTM LIKE @CHECKDATE ");

            cmdParms.Add(new MySqlParameter("PTNIDNO", drInfo["PTNIDNO"].ToString()));
            cmdParms.Add(new MySqlParameter("CHECKDATE", string.Format("{0}%", dtm)));

            return MySQLHelper.ExecuteSql(sbDelete.ToString(), cmdParms.ToArray());
        }

        #region 新版B超

        /// <summary>
        /// B超-更新体检B超资料
        /// </summary>
        /// <param name="drInfo"></param>
        /// <param name="strID"></param>
        public int DeletePtn(DataRow drInfo)
        {
            string dtm = DateTime.Parse(drInfo["jcrq"].ToString()).ToString("yyyy-MM-dd");
            StringBuilder builder = new StringBuilder();

            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            builder.Append(@"
                                    DELETE FROM ARCHIVE_ULTRASONICB_RESULT 
                                    WHERE PTNIDNO=@PTNIDNO
                                        AND DIAGTM LIKE @CHECKDATE ");

            cmdParms.Add(new MySqlParameter("@PTNIDNO", drInfo["sfzh"]));
            cmdParms.Add(new MySqlParameter("@CHECKDATE", string.Format("{0}%", dtm)));

            object single = MySQLHelper.ExecuteSql(builder.ToString(), cmdParms.ToArray());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// B超-新增体检B超资料
        /// </summary>
        /// <param name="drInfo"></param>
        public int InsertPtn(DataRow drInfo)
        {
            string dtm = DateTime.Parse(drInfo["jcrq"].ToString()).ToString("yyyy-MM-dd");
            StringBuilder builder = new StringBuilder();
            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            builder.Append(@"INSERT INTO ARCHIVE_ULTRASONICB_RESULT 
                                        (
                                            RECID
                                            ,PTNNM
                                            ,PTNSEX
                                            ,PTNAGE
                                            ,CHKNO
                                            ,PRETM
                                            ,DIAGTM
                                            ,DIAGDR
                                            ,CLNCDIAG
                                            ,CHKVIEW
                                            ,PREOPDIAG
                                            ,POSTOPDIAG
                                            ,PATHOVIEW
                                            ,DIAG
                                            ,PTNIDNO
                                        )
                                        VALUES
                                        (
                                            @RECID
                                            ,@PTNNM
                                            ,@PTNSEX
                                            ,@PTNAGE
                                            ,@CHKNO
                                            ,@PRETM
                                            ,@DIAGTM
                                            ,@DIAGDR
                                            ,@CLNCDIAG
                                            ,@CHKVIEW
                                            ,@PREOPDIAG
                                            ,@POSTOPDIAG
                                            ,@PATHOVIEW
                                            ,@DIAG
                                            ,@PTNIDNO
                                        )");

            cmdParms.Add(new MySqlParameter("@RECID", drInfo["uid"]));
            cmdParms.Add(new MySqlParameter("@PTNNM", drInfo["xm"]));
            cmdParms.Add(new MySqlParameter("@PTNSEX", drInfo["xb"]));
            cmdParms.Add(new MySqlParameter("@PTNAGE", drInfo["nl"]));
            cmdParms.Add(new MySqlParameter("@CHKNO", drInfo["jcbh"]));
            cmdParms.Add(new MySqlParameter("@PRETM", dtm));
            cmdParms.Add(new MySqlParameter("@DIAGTM", dtm));
            cmdParms.Add(new MySqlParameter("@DIAGDR", drInfo["jcys"]));
            cmdParms.Add(new MySqlParameter("@PREOPDIAG", drInfo.Table.Columns.Contains("fbbczd") ? drInfo["fbbczd"].ToString() : ""));
            cmdParms.Add(new MySqlParameter("@PATHOVIEW", drInfo.Table.Columns.Contains("jcsj") ? drInfo["jcsj"].ToString() : ""));
            cmdParms.Add(new MySqlParameter("@POSTOPDIAG", drInfo.Table.Columns.Contains("fbbc") ? drInfo["fbbc"].ToString() : ""));
            cmdParms.Add(new MySqlParameter("@CLNCDIAG", drInfo["lczd"]));
            cmdParms.Add(new MySqlParameter("@CHKVIEW", drInfo["jcsj"]));
            cmdParms.Add(new MySqlParameter("@DIAG", drInfo["jcyj"]));
            cmdParms.Add(new MySqlParameter("@PTNIDNO", drInfo["sfzh"]));

            object single = MySQLHelper.ExecuteSql(builder.ToString(), cmdParms.ToArray());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        #endregion

        #region 重庆B超

        /// <summary>
        /// 重庆从Access数据中获取数据
        /// </summary>
        /// <param name="drInfo"></param>
        /// <returns></returns>
        public void DeleteByChongQing(DataRow drInfo)
        {
            StringBuilder builder = new StringBuilder();

            // MySQLHelper.
            List<MySqlParameter> cmdParms = new List<MySqlParameter>();
            DateTime dt = (DateTime)drInfo["TestTime"];

            builder.Append(@"
                                    DELETE FROM ARCHIVE_ULTRASONICB_RESULT 
                                    WHERE PTNIDNO=@PTNIDNO
                                        AND DIAGTM LIKE @CHECKDATE ");

            cmdParms.Add(new MySqlParameter("PTNIDNO", drInfo["IDCardNo"].ToString()));
            cmdParms.Add(new MySqlParameter("CHECKDATE", dt.ToString("yyyy-MM-dd")));

            MySQLHelper.ExecuteSql(builder.ToString(), cmdParms.ToArray());
        }

        /// <summary>
        /// 重庆从Access数据中获取数据
        /// </summary>
        /// <param name="drInfo"></param>
        public void InsDBByChongQing(DataRow drInfo)
        {
            StringBuilder sbQuery = new StringBuilder();
            DateTime dt = (DateTime)drInfo["TestTime"];

            // MySQLHelper.
            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            sbQuery.Append("INSERT INTO ARCHIVE_ULTRASONICB_RESULT ( CHKNO,PTNIDNO,DIAGTM,DIAG) ");
            sbQuery.Append(" VALUES(@CHKNO,@PTNIDNO,@DIAGTM,@DIAG) ");

            cmdParms.Add(new MySqlParameter("CHKNO", drInfo["PersonID"].ToString()));
            cmdParms.Add(new MySqlParameter("DIAG", drInfo["ModDia"].ToString()));
            cmdParms.Add(new MySqlParameter("PTNIDNO", drInfo["IDCardNo"].ToString()));
            cmdParms.Add(new MySqlParameter("DIAGTM", dt.ToString("yyyy-MM-dd")));

            MySQLHelper.ExecuteSql(sbQuery.ToString(), cmdParms.ToArray());
        }

        #endregion
    }
}
