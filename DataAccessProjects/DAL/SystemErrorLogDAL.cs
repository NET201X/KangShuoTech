using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class SystemErrorLogDAL
    {
        public int Add(SystemErrorLogModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_SystemErrorLog(");
            builder.Append("LogData,Message,StackTrace,TargetSite,IDCardNo,CreateDate,SendEd,SendDate)");
            builder.Append(" values (");
            builder.Append("@LogData,@Message,@StackTrace,@TargetSite,@IDCardNo,@CreateDate,@SendEd,@SendDate)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@LogData", MySqlDbType.String), 
                new MySqlParameter("@Message", MySqlDbType.String), 
                new MySqlParameter("@StackTrace", MySqlDbType.String), 
                new MySqlParameter("@TargetSite", MySqlDbType.String), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@SendEd", MySqlDbType.String, 1), 
                new MySqlParameter("@SendDate", MySqlDbType.Date)
            };
            cmdParms[0].Value = model.LogData;
            cmdParms[1].Value = model.Message;
            cmdParms[2].Value = model.StackTrace;
            cmdParms[3].Value = model.TargetSite;
            cmdParms[4].Value = model.IDCardNo;
            cmdParms[5].Value = model.CreateDate;
            cmdParms[6].Value = model.SendEd;
            cmdParms[7].Value = model.SendDate;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public void CheckTable(string tabels)
        {
            DataTable datatable = MySQLHelper.GetDataTable(string.Format("select table_name from information_schema.tables where table_name = '{0}' ", tabels));
            bool flag = false;
            if ((datatable != null) && (datatable.Rows.Count > 0))
            {
                flag = true;
            }
            if (!flag)
            {
                MySQLHelper.ExecuteSql("CREATE TABLE [tbl_SystemErrorLog] (\r\n\t                                        [ID] integer NOT NULL PRIMARY KEY AUTOINCREMENT, \r\n\t                                        [LogData] text, \r\n\t                                        [Message] text, \r\n\t                                        [StackTrace] text, \r\n\t                                        [TargetSite] text,\t\r\n\t                                        [IDCardNo] nvarchar(50), \r\n\t                                        [CreateDate] date,\r\n\t                                        [SendEd] char(1),\r\n\t                                        [SendDate] date\r\n                                        );");
            }
        }

        public SystemErrorLogModel DataRowToModel(DataRow row)
        {
            SystemErrorLogModel report = new SystemErrorLogModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    report.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["LogData"] != null) && (row["LogData"] != DBNull.Value))
                {
                    report.LogData = row["LogData"].ToString();
                }
                if ((row["Message"] != null) && (row["Message"] != DBNull.Value))
                {
                    report.Message = row["Message"].ToString();
                }
                if ((row["StackTrace"] != null) && (row["StackTrace"] != DBNull.Value))
                {
                    report.StackTrace = row["StackTrace"].ToString();
                }
                if ((row["TargetSite"] != null) && (row["TargetSite"] != DBNull.Value))
                {
                    report.TargetSite = row["TargetSite"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    report.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    report.CreateDate = new DateTime?(DateTime.Parse(row["CreateDate"].ToString()));
                }
                if ((row["SendEd"] != null) && (row["SendEd"] != DBNull.Value))
                {
                    report.SendEd = row["SendEd"].ToString();
                }
                if (((row["SendDate"] != null) && (row["SendDate"] != DBNull.Value)) && (row["SendDate"].ToString() != ""))
                {
                    report.SendDate = new DateTime?(DateTime.Parse(row["SendDate"].ToString()));
                }
            }
            return report;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_SystemErrorLog ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_SystemErrorLog ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_SystemErrorLog");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,LogData,Message,StackTrace,TargetSite,IDCardNo,CreateDate,SendEd,SendDate ");
            builder.Append(" FROM tbl_SystemErrorLog ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from tbl_SystemErrorLog T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public SystemErrorLogModel GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,LogData,Message,StackTrace,TargetSite,IDCardNo,CreateDate,SendEd,SendDate from tbl_SystemErrorLog ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            new SystemErrorLogModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM tbl_SystemErrorLog ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(SystemErrorLogModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_SystemErrorLog set ");
            builder.Append("LogData=@LogData,");
            builder.Append("Message=@Message,");
            builder.Append("StackTrace=@StackTrace,");
            builder.Append("TargetSite=@TargetSite,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("SendEd=@SendEd,");
            builder.Append("SendDate=@SendDate");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@LogData", MySqlDbType.String), 
                new MySqlParameter("@Message", MySqlDbType.String), 
                new MySqlParameter("@StackTrace", MySqlDbType.String), 
                new MySqlParameter("@TargetSite", MySqlDbType.String), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@SendEd", MySqlDbType.String, 1), 
                new MySqlParameter("@SendDate", MySqlDbType.Date), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };

            cmdParms[0].Value = model.LogData;
            cmdParms[1].Value = model.Message;
            cmdParms[2].Value = model.StackTrace;
            cmdParms[3].Value = model.TargetSite;
            cmdParms[4].Value = model.IDCardNo;
            cmdParms[5].Value = model.CreateDate;
            cmdParms[6].Value = model.SendEd;
            cmdParms[7].Value = model.SendDate;
            cmdParms[8].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

