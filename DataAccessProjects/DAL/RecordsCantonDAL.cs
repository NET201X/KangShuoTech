namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsCantonDAL
    {
        public bool Add(RecordsCantonModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordscanton(");
            builder.Append("ID,Code,Name,Type)");
            builder.Append(" values (");
            builder.Append("@ID,@Code,@Name,@Type)");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@ID", MySqlDbType.Decimal),
                new MySqlParameter("@Code", MySqlDbType.String, 6),
                new MySqlParameter("@Name", MySqlDbType.String, 50), 
                new MySqlParameter("@Type", MySqlDbType.String, 1)
            };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Code;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.Type;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public RecordsCantonModel DataRowToModel(DataRow row)
        {
            RecordsCantonModel recordsCantonModel = new RecordsCantonModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsCantonModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["Code"] != null) && (row["Code"] != DBNull.Value))
                {
                    recordsCantonModel.Code = row["Code"].ToString();
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    recordsCantonModel.Name = row["Name"].ToString();
                }
                if ((row["Type"] != null) && (row["Type"] != DBNull.Value))
                {
                    recordsCantonModel.Type = row["Type"].ToString();
                }
            }
            return recordsCantonModel;
        }

        public bool Delete()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordscanton ");
            builder.Append(" where ");
            MySqlParameter[] cmdParms = new MySqlParameter[0];
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,Code,Name,Type ");
            builder.Append(" FROM tbl_recordscanton ");
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
            builder.Append(")AS Row, T.*  from tbl_recordscanton T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public RecordsCantonModel GetModel()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,Code,Name,Type from tbl_recordscanton ");
            builder.Append(" where ");
            MySqlParameter[] cmdParms = new MySqlParameter[0];
            new RecordsCantonModel();
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
            builder.Append("select count(1) FROM tbl_recordscanton ");
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

        public bool Update(RecordsCantonModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordscanton set ");
            builder.Append("ID=@ID,");
            builder.Append("Code=@Code,");
            builder.Append("Name=@Name,");
            builder.Append("Type=@Type");
            builder.Append(" where ");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@ID", MySqlDbType.Decimal), 
                new MySqlParameter("@Code", MySqlDbType.String, 6),
                new MySqlParameter("@Name", MySqlDbType.String, 50), 
                new MySqlParameter("@Type", MySqlDbType.String, 1)
            };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Code;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.Type;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

