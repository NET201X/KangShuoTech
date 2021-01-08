using MySql.Data.MySqlClient;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using Utilities.MySQLHelper;
    using Model;
    using System;
    using System.Data;

    using System.Text;

    public class RecordsIllnessHistoryInfoDAL
    {
        public int Add(RecordsIllnessHistoryInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsillnesshistoryinfo(");
            builder.Append("RecordID,IDCardNo,IllnessType,IllnessName,Therioma,IllnessOther,JobIllness,IllnessNameOther,DiagnoseTime)");
            builder.Append(" values (");
            builder.Append("@RecordID,@IDCardNo,@IllnessType,@IllnessName,@Therioma,@IllnessOther,@JobIllness,@IllnessNameOther,@DiagnoseTime)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@IllnessType", MySqlDbType.String, 1), 
                new MySqlParameter("@IllnessName", MySqlDbType.String, 200), 
                new MySqlParameter("@Therioma", MySqlDbType.String, 200), 
                new MySqlParameter("@IllnessOther", MySqlDbType.String, 200),
                new MySqlParameter("@JobIllness", MySqlDbType.String, 200), 
                new MySqlParameter("@IllnessNameOther", MySqlDbType.String, 200),
                new MySqlParameter("@DiagnoseTime", MySqlDbType.Date)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.IllnessType;
            cmdParms[3].Value = model.IllnessName;
            cmdParms[4].Value = model.Therioma;
            cmdParms[5].Value = model.IllnessOther;
            cmdParms[6].Value = model.JobIllness;
            cmdParms[7].Value = model.IllnessNameOther;
            cmdParms[8].Value = model.DiagnoseTime;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public int AddServer(RecordsIllnessHistoryInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsillnesshistoryinfo(");
            builder.Append("RecordID,IDCardNo,IllnessType,IllnessName,Therioma,IllnessOther,JobIllness,IllnessNameOther,DiagnoseTime)");
            builder.Append(" values (");
            builder.Append("@RecordID,@IDCardNo,@IllnessType,@IllnessName,@Therioma,@IllnessOther,@JobIllness,@IllnessNameOther,@DiagnoseTime)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@IllnessType", MySqlDbType.String, 1), 
                new MySqlParameter("@IllnessName", MySqlDbType.String, 200), 
                new MySqlParameter("@Therioma", MySqlDbType.String, 200), 
                new MySqlParameter("@IllnessOther", MySqlDbType.String, 200),
                new MySqlParameter("@JobIllness", MySqlDbType.String, 200), 
                new MySqlParameter("@IllnessNameOther", MySqlDbType.String, 200),
                new MySqlParameter("@DiagnoseTime", MySqlDbType.Date)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.IllnessType;
            cmdParms[3].Value = model.IllnessName;
            cmdParms[4].Value = model.Therioma;
            cmdParms[5].Value = model.IllnessOther;
            cmdParms[6].Value = model.JobIllness;
            cmdParms[7].Value = model.IllnessNameOther;
            cmdParms[8].Value = model.DiagnoseTime;

            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsIllnessHistoryInfoModel DataRowToModel(DataRow row)
        {
            RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel = new RecordsIllnessHistoryInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsIllnessHistoryInfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    recordsIllnessHistoryInfoModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsIllnessHistoryInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["IllnessType"] != null) && (row["IllnessType"] != DBNull.Value))
                {
                    recordsIllnessHistoryInfoModel.IllnessType = row["IllnessType"].ToString();
                }
                if ((row["IllnessName"] != null) && (row["IllnessName"] != DBNull.Value))
                {
                    recordsIllnessHistoryInfoModel.IllnessName = row["IllnessName"].ToString();
                }
                if ((row["Therioma"] != null) && (row["Therioma"] != DBNull.Value))
                {
                    recordsIllnessHistoryInfoModel.Therioma = row["Therioma"].ToString();
                }
                if ((row["IllnessOther"] != null) && (row["IllnessOther"] != DBNull.Value))
                {
                    recordsIllnessHistoryInfoModel.IllnessOther = row["IllnessOther"].ToString();
                }
                if ((row["JobIllness"] != null) && (row["JobIllness"] != DBNull.Value))
                {
                    recordsIllnessHistoryInfoModel.JobIllness = row["JobIllness"].ToString();
                }
                if ((row["IllnessNameOther"] != null) && (row["IllnessNameOther"] != DBNull.Value))
                {
                    recordsIllnessHistoryInfoModel.IllnessNameOther = row["IllnessNameOther"].ToString();
                }
                if (((row["DiagnoseTime"] != null) && (row["DiagnoseTime"] != DBNull.Value)) && (row["DiagnoseTime"].ToString() != ""))
                {
                    recordsIllnessHistoryInfoModel.DiagnoseTime = new DateTime?(DateTime.Parse(row["DiagnoseTime"].ToString()));
                }
                recordsIllnessHistoryInfoModel.RecordState = RecordsStateModel.Unchanged;
            }
            return recordsIllnessHistoryInfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsillnesshistoryinfo ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsillnesshistoryinfo ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordsillnesshistoryinfo");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,RecordID,IDCardNo,IllnessType,IllnessName,Therioma,IllnessOther,JobIllness,IllnessNameOther,DiagnoseTime ");
            builder.Append(" FROM tbl_recordsillnesshistoryinfo ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere + " order by id limit 6");
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
            builder.Append(")AS Row, T.*  from tbl_recordsillnesshistoryinfo T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_recordsillnesshistoryinfo");
        }

        public RecordsIllnessHistoryInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,RecordID,IDCardNo,IllnessType,IllnessName,Therioma,IllnessOther,JobIllness,IllnessNameOther,DiagnoseTime from tbl_recordsillnesshistoryinfo ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsIllnessHistoryInfoModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public DataSet Getdt(string IDCardNo ,string s)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,RecordID,IDCardNo,IllnessType,IllnessName,Therioma,IllnessOther,IllnessNameOther from tbl_recordsillnesshistoryinfo ");
            builder.Append(" where IDCardNo= '" + IDCardNo + "' and IllnessType = '"+Convert.ToChar(s.ToString ())+"' ");
           
            return MySQLHelper.Query(builder.ToString());
        }
        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM tbl_recordsillnesshistoryinfo ");
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

        public bool Update(RecordsIllnessHistoryInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsillnesshistoryinfo set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("IllnessType=@IllnessType,");
            builder.Append("IllnessName=@IllnessName,");
            builder.Append("Therioma=@Therioma,");
            builder.Append("IllnessOther=@IllnessOther,");
            builder.Append("JobIllness=@JobIllness,");
            builder.Append("IllnessNameOther=@IllnessNameOther,");
            builder.Append("DiagnoseTime=@DiagnoseTime");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IllnessType", MySqlDbType.String, 1),
                new MySqlParameter("@IllnessName", MySqlDbType.String, 200),
                new MySqlParameter("@Therioma", MySqlDbType.String, 200),
                new MySqlParameter("@IllnessOther", MySqlDbType.String, 200), 
                new MySqlParameter("@JobIllness", MySqlDbType.String, 200), 
                new MySqlParameter("@IllnessNameOther", MySqlDbType.String, 200),
                new MySqlParameter("@DiagnoseTime", MySqlDbType.Date),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.IllnessType;
            cmdParms[3].Value = model.IllnessName;
            cmdParms[4].Value = model.Therioma;
            cmdParms[5].Value = model.IllnessOther;
            cmdParms[6].Value = model.JobIllness;
            cmdParms[7].Value = model.IllnessNameOther;
            cmdParms[8].Value = model.DiagnoseTime;
            cmdParms[9].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool UpdateServer(RecordsIllnessHistoryInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsillnesshistoryinfo set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("IllnessType=@IllnessType,");
            builder.Append("IllnessName=@IllnessName,");
            builder.Append("Therioma=@Therioma,");
            builder.Append("IllnessOther=@IllnessOther,");
            builder.Append("JobIllness=@JobIllness,");
            builder.Append("IllnessNameOther=@IllnessNameOther,");
            builder.Append("DiagnoseTime=@DiagnoseTime");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IllnessType", MySqlDbType.String, 1),
                new MySqlParameter("@IllnessName", MySqlDbType.String, 200),
                new MySqlParameter("@Therioma", MySqlDbType.String, 200),
                new MySqlParameter("@IllnessOther", MySqlDbType.String, 200), 
                new MySqlParameter("@JobIllness", MySqlDbType.String, 200), 
                new MySqlParameter("@IllnessNameOther", MySqlDbType.String, 200),
                new MySqlParameter("@DiagnoseTime", MySqlDbType.Date)
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.IllnessType;
            cmdParms[3].Value = model.IllnessName;
            cmdParms[4].Value = model.Therioma;
            cmdParms[5].Value = model.IllnessOther;
            cmdParms[6].Value = model.JobIllness;
            cmdParms[7].Value = model.IllnessNameOther;
            cmdParms[8].Value = model.DiagnoseTime;
           // cmdParms[9].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

