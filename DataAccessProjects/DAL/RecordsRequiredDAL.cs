namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsRequiredDAL
    {
        public int Add(RecordsRequiredModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into RecordsRequired(");
            builder.Append("BTable,Name,Comment,IsRequired)");
            builder.Append(" values (");
            builder.Append("@BTable,@Name,@Comment,@IsRequired)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@BTable", MySqlDbType.String), 
                new MySqlParameter("@Name", MySqlDbType.String), 
                new MySqlParameter("@Comment", MySqlDbType.String), 
                new MySqlParameter("@IsRequired", MySqlDbType.Int32)
            };
            cmdParms[0].Value = model.BTable;
            cmdParms[1].Value = model.Name;
            cmdParms[2].Value = model.Comment;
            cmdParms[3].Value = model.IsRequired;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsRequiredModel DataRowToModel(DataRow row)
        {
            RecordsRequiredModel recordsRequiredModel = new RecordsRequiredModel();
            if (row != null)
            {
                if ((row["ID"] != null) && (row["ID"].ToString() != ""))
                {
                    recordsRequiredModel.ID = int.Parse(row["ID"].ToString());
                }

                if (row["BTable"] != null)
                {
                    recordsRequiredModel.BTable = row["BTable"].ToString();
                }

                if (row["Name"] != null)
                {
                    recordsRequiredModel.Name = row["Name"].ToString();
                }
                if (row["Comment"] != null)
                {
                    recordsRequiredModel.Comment = row["Comment"].ToString();
                }

                if ((row["IsRequired"] != null) && (row["IsRequired"].ToString() != ""))
                {
                    recordsRequiredModel.IsRequired = new decimal?(decimal.Parse(row["IsRequired"].ToString()));
                }
            
                recordsRequiredModel.RcdState = RecordsStateModel.Unchanged;
            }
            return recordsRequiredModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from RecordsRequired ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from RecordsRequired ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from RecordsRequired");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,BTable,Name,Comment,IsRequired ");
            builder.Append(" FROM RecordsRequired ");
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
            builder.Append(")AS Row, T.*  from RecordsRequired T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public RecordsRequiredModel GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,BTable,Name,Comment,IsRequired from RecordsRequired ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            new RecordsRequiredModel();
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
            builder.Append("select count(1) FROM RecordsRequired ");
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

        public bool Update(RecordsRequiredModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update RecordsRequired set ");
            builder.Append("BTable=@BTable,");
            builder.Append("Name=@Name,");
            builder.Append("Comment=@Comment,");
            builder.Append("IsRequired=@IsRequired ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@BTable", MySqlDbType.String),
                new MySqlParameter("@Name", MySqlDbType.String),
                new MySqlParameter("@Comment", MySqlDbType.String), 
                new MySqlParameter("@IsRequired", MySqlDbType.Int32), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.BTable;
            cmdParms[1].Value = model.Name;
            cmdParms[2].Value = model.Comment;
            cmdParms[3].Value = model.IsRequired;
            cmdParms[4].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

