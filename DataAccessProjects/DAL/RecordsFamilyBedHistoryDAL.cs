namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsFamilyBedHistoryDAL
    {
        public int Add(RecordsFamilyBedHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsfamilybedhistory(");
            builder.Append("PhysicalID,IDCardNo,HospitalName,InHospitalDate,IllcaseNums,Reasons,OutHospitalDate,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@HospitalName,@InHospitalDate,@IllcaseNums,@Reasons,@OutHospitalDate,@OutKey)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@HospitalName", MySqlDbType.String, 100),
                new MySqlParameter("@InHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@IllcaseNums", MySqlDbType.String, 50),
                new MySqlParameter("@Reasons", MySqlDbType.String, 100),
                new MySqlParameter("@OutHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.HospitalName;
            cmdParms[3].Value = model.InHospitalDate;
            cmdParms[4].Value = model.IllcaseNums;
            cmdParms[5].Value = model.Reasons;
            cmdParms[6].Value = model.OutHospitalDate;
            cmdParms[7].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsFamilyBedHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsfamilybedhistory(");
            builder.Append("PhysicalID,IDCardNo,HospitalName,InHospitalDate,IllcaseNums,Reasons,OutHospitalDate,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@HospitalName,@InHospitalDate,@IllcaseNums,@Reasons,@OutHospitalDate,@OutKey)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@HospitalName", MySqlDbType.String, 100),
                new MySqlParameter("@InHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@IllcaseNums", MySqlDbType.String, 50),
                new MySqlParameter("@Reasons", MySqlDbType.String, 100),
                new MySqlParameter("@OutHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.HospitalName;
            cmdParms[3].Value = model.InHospitalDate;
            cmdParms[4].Value = model.IllcaseNums;
            cmdParms[5].Value = model.Reasons;
            cmdParms[6].Value = model.OutHospitalDate;
            cmdParms[7].Value = model.OutKey;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsFamilyBedHistoryModel DataRowToModel(DataRow row)
        {
            RecordsFamilyBedHistoryModel recordsFamilyBedHistoryModel = new RecordsFamilyBedHistoryModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsFamilyBedHistoryModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsFamilyBedHistoryModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsFamilyBedHistoryModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["HospitalName"] != null) && (row["HospitalName"] != DBNull.Value))
                {
                    recordsFamilyBedHistoryModel.HospitalName = row["HospitalName"].ToString();
                }
                if (((row["InHospitalDate"] != null) && (row["InHospitalDate"] != DBNull.Value)) && (row["InHospitalDate"].ToString() != ""))
                {
                    recordsFamilyBedHistoryModel.InHospitalDate = new DateTime?(DateTime.Parse(row["InHospitalDate"].ToString()));
                }
                if ((row["IllcaseNums"] != null) && (row["IllcaseNums"] != DBNull.Value))
                {
                    recordsFamilyBedHistoryModel.IllcaseNums = row["IllcaseNums"].ToString();
                }
                if ((row["Reasons"] != null) && (row["Reasons"] != DBNull.Value))
                {
                    recordsFamilyBedHistoryModel.Reasons = row["Reasons"].ToString();
                }
                if (((row["OutHospitalDate"] != null) && (row["OutHospitalDate"] != DBNull.Value)) && (row["OutHospitalDate"].ToString() != ""))
                {
                    recordsFamilyBedHistoryModel.OutHospitalDate = new DateTime?(DateTime.Parse(row["OutHospitalDate"].ToString()));
                }
            }
            return recordsFamilyBedHistoryModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsfamilybedhistory ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsfamilybedhistory ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordsfamilybedhistory");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,PhysicalID,IDCardNo,HospitalName,InHospitalDate,IllcaseNums,Reasons,OutHospitalDate ");
            builder.Append(" FROM tbl_recordsfamilybedhistory ");
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
            builder.Append(")AS Row, T.*  from tbl_recordsfamilybedhistory T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_recordsfamilybedhistory");
        }

        public RecordsFamilyBedHistoryModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,PhysicalID,IDCardNo,HospitalName,InHospitalDate,IllcaseNums,Reasons,OutHospitalDate from tbl_recordsfamilybedhistory ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsFamilyBedHistoryModel();
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
            builder.Append("select count(1) FROM tbl_recordsfamilybedhistory ");
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

        public bool Update(RecordsFamilyBedHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsfamilybedhistory set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("HospitalName=@HospitalName,");
            builder.Append("InHospitalDate=@InHospitalDate,");
            builder.Append("IllcaseNums=@IllcaseNums,");
            builder.Append("Reasons=@Reasons,");
            builder.Append("OutHospitalDate=@OutHospitalDate");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@HospitalName", MySqlDbType.String, 100),
                new MySqlParameter("@InHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@IllcaseNums", MySqlDbType.String, 50),
                new MySqlParameter("@Reasons", MySqlDbType.String, 100), 
                new MySqlParameter("@OutHospitalDate", MySqlDbType.Date), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.HospitalName;
            cmdParms[3].Value = model.InHospitalDate;
            cmdParms[4].Value = model.IllcaseNums;
            cmdParms[5].Value = model.Reasons;
            cmdParms[6].Value = model.OutHospitalDate;
            cmdParms[7].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsFamilyBedHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsfamilybedhistory set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("HospitalName=@HospitalName,");
            builder.Append("InHospitalDate=@InHospitalDate,");
            builder.Append("IllcaseNums=@IllcaseNums,");
            builder.Append("Reasons=@Reasons,");
            builder.Append("OutHospitalDate=@OutHospitalDate");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@HospitalName", MySqlDbType.String, 100),
                new MySqlParameter("@InHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@IllcaseNums", MySqlDbType.String, 50),
                new MySqlParameter("@Reasons", MySqlDbType.String, 100), 
                new MySqlParameter("@OutHospitalDate", MySqlDbType.Date), 
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.HospitalName;
            cmdParms[3].Value = model.InHospitalDate;
            cmdParms[4].Value = model.IllcaseNums;
            cmdParms[5].Value = model.Reasons;
            cmdParms[6].Value = model.OutHospitalDate;
            //cmdParms[7].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public bool DeleteByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsfamilybedhistory ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

