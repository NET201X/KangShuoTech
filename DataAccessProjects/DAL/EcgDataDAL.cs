using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class EcgDataDAL
    {
        public int Add(EcgDataModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ECG_DATA(");
            builder.Append("RecordID,CustomerID,IDCardNo,ECG)");
            builder.Append(" values (");
            builder.Append("@RecordID,@CustomerID,@IDCardNo,@ECG)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@ECG", MySqlDbType.Binary)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.CustomerID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ECG;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public EcgDataModel DataRowToModel(DataRow row)
        {
            EcgDataModel ecg_data = new EcgDataModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    ecg_data.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    ecg_data.RecordID = row["RecordID"].ToString();
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    ecg_data.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    ecg_data.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["ECG"] != null) && (row["ECG"] != DBNull.Value)) && (row["ECG"].ToString() != ""))
                {
                    ecg_data.ECG = (byte[]) row["ECG"];
                }
            }
            return ecg_data;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ECG_DATA ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ECG_DATA ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ECG_DATA");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,CustomerID,IDCardNo,ECG ");
            builder.Append(" FROM ECG_DATA ");
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
            builder.Append(")AS Row, T.*  from ECG_DATA T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public EcgDataModel GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,CustomerID,IDCardNo,ECG from ECG_DATA ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            new EcgDataModel();
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
            builder.Append("select count(1) FROM ECG_DATA ");
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

        public bool Update(EcgDataModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ECG_DATA set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("ECG=@ECG");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@ECG", MySqlDbType.Binary), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.CustomerID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ECG;
            cmdParms[4].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

