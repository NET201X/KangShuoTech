namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsInoculationHistoryDAL
    {
        public int Add(RecordsInoculationHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_INOCULATIONHISTORY(");
            builder.Append("PhysicalID,IDCardNo,PillName,InoculationDate,InoculationHistory,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@PillName,@InoculationDate,@InoculationHistory,@OutKey)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@PillName", MySqlDbType.String, 100),
                new MySqlParameter("@InoculationDate", MySqlDbType.Date),
                new MySqlParameter("@InoculationHistory", MySqlDbType.String, 100),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.PillName;
            cmdParms[3].Value = model.InoculationDate;
            cmdParms[4].Value = model.InoculationHistory;
            cmdParms[5].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsInoculationHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_INOCULATIONHISTORY(");
            builder.Append("PhysicalID,IDCardNo,PillName,InoculationDate,InoculationHistory,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@PillName,@InoculationDate,@InoculationHistory,@OutKey)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@PillName", MySqlDbType.String, 100),
                new MySqlParameter("@InoculationDate", MySqlDbType.Date),
                new MySqlParameter("@InoculationHistory", MySqlDbType.String, 100),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.PillName;
            cmdParms[3].Value = model.InoculationDate;
            cmdParms[4].Value = model.InoculationHistory;
            cmdParms[5].Value = model.OutKey;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsInoculationHistoryModel DataRowToModel(DataRow row)
        {
            RecordsInoculationHistoryModel recordsInoculationHistoryModel = new RecordsInoculationHistoryModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsInoculationHistoryModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsInoculationHistoryModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsInoculationHistoryModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["PillName"] != null) && (row["PillName"] != DBNull.Value))
                {
                    recordsInoculationHistoryModel.PillName = row["PillName"].ToString();
                }
                if (((row["InoculationDate"] != null) && (row["InoculationDate"] != DBNull.Value)) && (row["InoculationDate"].ToString() != ""))
                {
                    recordsInoculationHistoryModel.InoculationDate = new DateTime?(DateTime.Parse(row["InoculationDate"].ToString()));
                }
                if ((row["InoculationHistory"] != null) && (row["InoculationHistory"] != DBNull.Value))
                {
                    recordsInoculationHistoryModel.InoculationHistory = row["InoculationHistory"].ToString();
                }
            }
            return recordsInoculationHistoryModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_INOCULATIONHISTORY ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_INOCULATIONHISTORY ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_INOCULATIONHISTORY");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,PhysicalID,IDCardNo,PillName,InoculationDate,InoculationHistory ");
            builder.Append(" FROM ARCHIVE_INOCULATIONHISTORY ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere + " order by id limit 3");
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
                builder.Append("order by T." + orderby);
            }
            else
            {
                builder.Append("order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from ARCHIVE_INOCULATIONHISTORY T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "ARCHIVE_INOCULATIONHISTORY");
        }

        public RecordsInoculationHistoryModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,PhysicalID,IDCardNo,PillName,InoculationDate,InoculationHistory from ARCHIVE_INOCULATIONHISTORY ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsInoculationHistoryModel();
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
            builder.Append("select count(1) FROM ARCHIVE_INOCULATIONHISTORY ");
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

        public bool Update(RecordsInoculationHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_INOCULATIONHISTORY set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("PillName=@PillName,");
            builder.Append("InoculationDate=@InoculationDate,");
            builder.Append("InoculationHistory=@InoculationHistory");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@PillName", MySqlDbType.String, 100), 
                new MySqlParameter("@InoculationDate", MySqlDbType.Date), 
                new MySqlParameter("@InoculationHistory", MySqlDbType.String, 100),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.PillName;
            cmdParms[3].Value = model.InoculationDate;
            cmdParms[4].Value = model.InoculationHistory;
            cmdParms[5].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsInoculationHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_INOCULATIONHISTORY set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("PillName=@PillName,");
            builder.Append("InoculationDate=@InoculationDate,");
            builder.Append("InoculationHistory=@InoculationHistory");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@PillName", MySqlDbType.String, 100), 
                new MySqlParameter("@InoculationDate", MySqlDbType.Date), 
                new MySqlParameter("@InoculationHistory", MySqlDbType.String, 100),
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.PillName;
            cmdParms[3].Value = model.InoculationDate;
            cmdParms[4].Value = model.InoculationHistory;
            //cmdParms[5].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public bool DeleteByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_INOCULATIONHISTORY ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

    }
}

