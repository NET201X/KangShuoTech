namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsFamilyHistoryInfoDAL
    {
        public int Add(RecordsFamilyHistoryInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_FAMILYHISTORYINFO(");
            builder.Append("RecordID,IDCardNo,FamilyType,FatherHistory,FatherHistoryOther,MotherHistory,MotherHistoryOther,BrotherSisterHistory,BrotherSisterHistoryOther,ChildrenHistory,ChildrenHistoryOther)");
            builder.Append(" values (");
            builder.Append("@RecordID,@IDCardNo,@FamilyType,@FatherHistory,@FatherHistoryOther,@MotherHistory,@MotherHistoryOther,@BrotherSisterHistory,@BrotherSisterHistoryOther,@ChildrenHistory,@ChildrenHistoryOther)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@FamilyType", MySqlDbType.String, 1), 
                new MySqlParameter("@FatherHistory", MySqlDbType.String, 50),
                new MySqlParameter("@FatherHistoryOther", MySqlDbType.String, 200),
                new MySqlParameter("@MotherHistory", MySqlDbType.String, 50),
                new MySqlParameter("@MotherHistoryOther", MySqlDbType.String, 200),
                new MySqlParameter("@BrotherSisterHistory", MySqlDbType.String, 50), 
                new MySqlParameter("@BrotherSisterHistoryOther", MySqlDbType.String, 200), 
                new MySqlParameter("@ChildrenHistory", MySqlDbType.String, 50),
                new MySqlParameter("@ChildrenHistoryOther", MySqlDbType.String, 200)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.FamilyType;
            cmdParms[3].Value = model.FatherHistory;
            cmdParms[4].Value = model.FatherHistoryOther;
            cmdParms[5].Value = model.MotherHistory;
            cmdParms[6].Value = model.MotherHistoryOther;
            cmdParms[7].Value = model.BrotherSisterHistory;
            cmdParms[8].Value = model.BrotherSisterHistoryOther;
            cmdParms[9].Value = model.ChildrenHistory;
            cmdParms[10].Value = model.ChildrenHistoryOther;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsFamilyHistoryInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_FAMILYHISTORYINFO(");
            builder.Append("RecordID,IDCardNo,FamilyType,FatherHistory,FatherHistoryOther,MotherHistory,MotherHistoryOther,BrotherSisterHistory,BrotherSisterHistoryOther,ChildrenHistory,ChildrenHistoryOther)");
            builder.Append(" values (");
            builder.Append("@RecordID,@IDCardNo,@FamilyType,@FatherHistory,@FatherHistoryOther,@MotherHistory,@MotherHistoryOther,@BrotherSisterHistory,@BrotherSisterHistoryOther,@ChildrenHistory,@ChildrenHistoryOther)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@FamilyType", MySqlDbType.String, 1), 
                new MySqlParameter("@FatherHistory", MySqlDbType.String, 50),
                new MySqlParameter("@FatherHistoryOther", MySqlDbType.String, 200),
                new MySqlParameter("@MotherHistory", MySqlDbType.String, 50),
                new MySqlParameter("@MotherHistoryOther", MySqlDbType.String, 200),
                new MySqlParameter("@BrotherSisterHistory", MySqlDbType.String, 50), 
                new MySqlParameter("@BrotherSisterHistoryOther", MySqlDbType.String, 200), 
                new MySqlParameter("@ChildrenHistory", MySqlDbType.String, 50),
                new MySqlParameter("@ChildrenHistoryOther", MySqlDbType.String, 200)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.FamilyType;
            cmdParms[3].Value = model.FatherHistory;
            cmdParms[4].Value = model.FatherHistoryOther;
            cmdParms[5].Value = model.MotherHistory;
            cmdParms[6].Value = model.MotherHistoryOther;
            cmdParms[7].Value = model.BrotherSisterHistory;
            cmdParms[8].Value = model.BrotherSisterHistoryOther;
            cmdParms[9].Value = model.ChildrenHistory;
            cmdParms[10].Value = model.ChildrenHistoryOther;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsFamilyHistoryInfoModel DataRowToModel(DataRow row)
        {
            RecordsFamilyHistoryInfoModel recordsFamilyHistoryInfoModel = new RecordsFamilyHistoryInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsFamilyHistoryInfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["FamilyType"] != null) && (row["FamilyType"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.FamilyType = row["FamilyType"].ToString();
                }
                if ((row["FatherHistory"] != null) && (row["FatherHistory"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.FatherHistory = row["FatherHistory"].ToString();
                }
                if ((row["FatherHistoryOther"] != null) && (row["FatherHistoryOther"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.FatherHistoryOther = row["FatherHistoryOther"].ToString();
                }
                if ((row["MotherHistory"] != null) && (row["MotherHistory"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.MotherHistory = row["MotherHistory"].ToString();
                }
                if ((row["MotherHistoryOther"] != null) && (row["MotherHistoryOther"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.MotherHistoryOther = row["MotherHistoryOther"].ToString();
                }
                if ((row["BrotherSisterHistory"] != null) && (row["BrotherSisterHistory"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.BrotherSisterHistory = row["BrotherSisterHistory"].ToString();
                }
                if ((row["BrotherSisterHistoryOther"] != null) && (row["BrotherSisterHistoryOther"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.BrotherSisterHistoryOther = row["BrotherSisterHistoryOther"].ToString();
                }
                if ((row["ChildrenHistory"] != null) && (row["ChildrenHistory"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.ChildrenHistory = row["ChildrenHistory"].ToString();
                }
                if ((row["ChildrenHistoryOther"] != null) && (row["ChildrenHistoryOther"] != DBNull.Value))
                {
                    recordsFamilyHistoryInfoModel.ChildrenHistoryOther = row["ChildrenHistoryOther"].ToString();
                }
            }
            return recordsFamilyHistoryInfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_FAMILYHISTORYINFO ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_FAMILYHISTORYINFO ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_FAMILYHISTORYINFO");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,RecordID,IDCardNo,FamilyType,FatherHistory,FatherHistoryOther,MotherHistory,MotherHistoryOther,BrotherSisterHistory,BrotherSisterHistoryOther,ChildrenHistory,ChildrenHistoryOther ");
            builder.Append(" FROM ARCHIVE_FAMILYHISTORYINFO ");
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
            builder.Append(")AS Row, T.*  from ARCHIVE_FAMILYHISTORYINFO T ");
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
            return MySQLHelper.GetMaxID("ID", "ARCHIVE_FAMILYHISTORYINFO");
        }

        public RecordsFamilyHistoryInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,RecordID,IDCardNo,FamilyType,FatherHistory,FatherHistoryOther,MotherHistory,MotherHistoryOther,BrotherSisterHistory,BrotherSisterHistoryOther,ChildrenHistory,ChildrenHistoryOther from ARCHIVE_FAMILYHISTORYINFO ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsFamilyHistoryInfoModel();
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
            builder.Append("select count(1) FROM ARCHIVE_FAMILYHISTORYINFO ");
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

        public bool Update(RecordsFamilyHistoryInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_FAMILYHISTORYINFO set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FamilyType=@FamilyType,");
            builder.Append("FatherHistory=@FatherHistory,");
            builder.Append("FatherHistoryOther=@FatherHistoryOther,");
            builder.Append("MotherHistory=@MotherHistory,");
            builder.Append("MotherHistoryOther=@MotherHistoryOther,");
            builder.Append("BrotherSisterHistory=@BrotherSisterHistory,");
            builder.Append("BrotherSisterHistoryOther=@BrotherSisterHistoryOther,");
            builder.Append("ChildrenHistory=@ChildrenHistory,");
            builder.Append("ChildrenHistoryOther=@ChildrenHistoryOther");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FamilyType", MySqlDbType.String, 1), 
                new MySqlParameter("@FatherHistory", MySqlDbType.String, 50), 
                new MySqlParameter("@FatherHistoryOther", MySqlDbType.String, 200), 
                new MySqlParameter("@MotherHistory", MySqlDbType.String, 50),
                new MySqlParameter("@MotherHistoryOther", MySqlDbType.String, 200), 
                new MySqlParameter("@BrotherSisterHistory", MySqlDbType.String, 50),
                new MySqlParameter("@BrotherSisterHistoryOther", MySqlDbType.String, 200),
                new MySqlParameter("@ChildrenHistory", MySqlDbType.String, 50),
                new MySqlParameter("@ChildrenHistoryOther", MySqlDbType.String, 200),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.FamilyType;
            cmdParms[3].Value = model.FatherHistory;
            cmdParms[4].Value = model.FatherHistoryOther;
            cmdParms[5].Value = model.MotherHistory;
            cmdParms[6].Value = model.MotherHistoryOther;
            cmdParms[7].Value = model.BrotherSisterHistory;
            cmdParms[8].Value = model.BrotherSisterHistoryOther;
            cmdParms[9].Value = model.ChildrenHistory;
            cmdParms[10].Value = model.ChildrenHistoryOther;
            cmdParms[11].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool UpdateServer(RecordsFamilyHistoryInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_FAMILYHISTORYINFO set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("FamilyType=@FamilyType,");
            builder.Append("FatherHistory=@FatherHistory,");
            builder.Append("FatherHistoryOther=@FatherHistoryOther,");
            builder.Append("MotherHistory=@MotherHistory,");
            builder.Append("MotherHistoryOther=@MotherHistoryOther,");
            builder.Append("BrotherSisterHistory=@BrotherSisterHistory,");
            builder.Append("BrotherSisterHistoryOther=@BrotherSisterHistoryOther,");
            builder.Append("ChildrenHistory=@ChildrenHistory,");
            builder.Append("ChildrenHistoryOther=@ChildrenHistoryOther");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@FamilyType", MySqlDbType.String, 1), 
                new MySqlParameter("@FatherHistory", MySqlDbType.String, 50), 
                new MySqlParameter("@FatherHistoryOther", MySqlDbType.String, 200), 
                new MySqlParameter("@MotherHistory", MySqlDbType.String, 50),
                new MySqlParameter("@MotherHistoryOther", MySqlDbType.String, 200), 
                new MySqlParameter("@BrotherSisterHistory", MySqlDbType.String, 50),
                new MySqlParameter("@BrotherSisterHistoryOther", MySqlDbType.String, 200),
                new MySqlParameter("@ChildrenHistory", MySqlDbType.String, 50),
                new MySqlParameter("@ChildrenHistoryOther", MySqlDbType.String, 200)
               // new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.FamilyType;
            cmdParms[3].Value = model.FatherHistory;
            cmdParms[4].Value = model.FatherHistoryOther;
            cmdParms[5].Value = model.MotherHistory;
            cmdParms[6].Value = model.MotherHistoryOther;
            cmdParms[7].Value = model.BrotherSisterHistory;
            cmdParms[8].Value = model.BrotherSisterHistoryOther;
            cmdParms[9].Value = model.ChildrenHistory;
            cmdParms[10].Value = model.ChildrenHistoryOther;
           // cmdParms[11].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

