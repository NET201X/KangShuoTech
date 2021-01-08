namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsHospitalHistoryDAL
    {
        public int Add(RecordsHospitalHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordshospitalhistory(");
            builder.Append("PhysicalID,IDCardNo,InHospitalDate,Reason,IllcaseNum,HospitalName,OutHospitalDate,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@InHospitalDate,@Reason,@IllcaseNum,@HospitalName,@OutHospitalDate,@OutKey)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@InHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@Reason", MySqlDbType.String, 100),
                new MySqlParameter("@IllcaseNum", MySqlDbType.String, 50),
                new MySqlParameter("@HospitalName", MySqlDbType.String, 100),
                new MySqlParameter("@OutHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4),
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.InHospitalDate;
            cmdParms[3].Value = model.Reason;
            cmdParms[4].Value = model.IllcaseNum;
            cmdParms[5].Value = model.HospitalName;
            cmdParms[6].Value = model.OutHospitalDate;
            cmdParms[7].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsHospitalHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordshospitalhistory(");
            builder.Append("PhysicalID,IDCardNo,InHospitalDate,Reason,IllcaseNum,HospitalName,OutHospitalDate,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@InHospitalDate,@Reason,@IllcaseNum,@HospitalName,@OutHospitalDate,@OutKey)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@InHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@Reason", MySqlDbType.String, 100),
                new MySqlParameter("@IllcaseNum", MySqlDbType.String, 50),
                new MySqlParameter("@HospitalName", MySqlDbType.String, 100),
                new MySqlParameter("@OutHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4),
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.InHospitalDate;
            cmdParms[3].Value = model.Reason;
            cmdParms[4].Value = model.IllcaseNum;
            cmdParms[5].Value = model.HospitalName;
            cmdParms[6].Value = model.OutHospitalDate;
            cmdParms[7].Value = model.OutKey;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsHospitalHistoryModel DataRowToModel(DataRow row)
        {
            RecordsHospitalHistoryModel recordsHospitalHistoryModel = new RecordsHospitalHistoryModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsHospitalHistoryModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsHospitalHistoryModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsHospitalHistoryModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["InHospitalDate"] != null) && (row["InHospitalDate"] != DBNull.Value)) && (row["InHospitalDate"].ToString() != ""))
                {
                    recordsHospitalHistoryModel.InHospitalDate = new DateTime?(DateTime.Parse(row["InHospitalDate"].ToString()));
                }
                if ((row["Reason"] != null) && (row["Reason"] != DBNull.Value))
                {
                    recordsHospitalHistoryModel.Reason = row["Reason"].ToString();
                }
                if ((row["IllcaseNum"] != null) && (row["IllcaseNum"] != DBNull.Value))
                {
                    recordsHospitalHistoryModel.IllcaseNum = row["IllcaseNum"].ToString();
                }
                if ((row["HospitalName"] != null) && (row["HospitalName"] != DBNull.Value))
                {
                    recordsHospitalHistoryModel.HospitalName = row["HospitalName"].ToString();
                }
                if (((row["OutHospitalDate"] != null) && (row["OutHospitalDate"] != DBNull.Value)) && (row["OutHospitalDate"].ToString() != ""))
                {
                    recordsHospitalHistoryModel.OutHospitalDate = new DateTime?(DateTime.Parse(row["OutHospitalDate"].ToString()));
                }
            }
            return recordsHospitalHistoryModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordshospitalhistory ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordshospitalhistory ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordshospitalhistory");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,PhysicalID,IDCardNo,InHospitalDate,Reason,IllcaseNum,HospitalName,OutHospitalDate ");
            builder.Append(" FROM tbl_recordshospitalhistory ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere + " order by id limit 2");
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
            builder.Append(")AS Row, T.*  from tbl_recordshospitalhistory T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_recordshospitalhistory");
        }

        public RecordsHospitalHistoryModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,PhysicalID,IDCardNo,InHospitalDate,Reason,IllcaseNum,HospitalName,OutHospitalDate from tbl_recordshospitalhistory ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsHospitalHistoryModel();
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
            builder.Append("select count(1) FROM tbl_recordshospitalhistory ");
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

        public bool Update(RecordsHospitalHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordshospitalhistory set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("InHospitalDate=@InHospitalDate,");
            builder.Append("Reason=@Reason,");
            builder.Append("IllcaseNum=@IllcaseNum,");
            builder.Append("HospitalName=@HospitalName,");
            builder.Append("OutHospitalDate=@OutHospitalDate");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@InHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@Reason", MySqlDbType.String, 100),
                new MySqlParameter("@IllcaseNum", MySqlDbType.String, 50),
                new MySqlParameter("@HospitalName", MySqlDbType.String, 100), 
                new MySqlParameter("@OutHospitalDate", MySqlDbType.Date), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.InHospitalDate;
            cmdParms[3].Value = model.Reason;
            cmdParms[4].Value = model.IllcaseNum;
            cmdParms[5].Value = model.HospitalName;
            cmdParms[6].Value = model.OutHospitalDate;
            cmdParms[7].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsHospitalHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordshospitalhistory set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("InHospitalDate=@InHospitalDate,");
            builder.Append("Reason=@Reason,");
            builder.Append("IllcaseNum=@IllcaseNum,");
            builder.Append("HospitalName=@HospitalName,");
            builder.Append("OutHospitalDate=@OutHospitalDate");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@InHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@Reason", MySqlDbType.String, 100),
                new MySqlParameter("@IllcaseNum", MySqlDbType.String, 50),
                new MySqlParameter("@HospitalName", MySqlDbType.String, 100), 
                new MySqlParameter("@OutHospitalDate", MySqlDbType.Date), 
               // new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.InHospitalDate;
            cmdParms[3].Value = model.Reason;
            cmdParms[4].Value = model.IllcaseNum;
            cmdParms[5].Value = model.HospitalName;
            cmdParms[6].Value = model.OutHospitalDate;
            //cmdParms[7].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public bool DeleteByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordshospitalhistory ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

