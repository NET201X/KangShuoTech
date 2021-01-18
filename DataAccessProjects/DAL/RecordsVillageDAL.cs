namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsVillageDAL
    {
        public bool Add(RecordsVillageModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_VILLAGE(");
            builder.Append("ID,Code,Name,TownID,IsDelete)");
            builder.Append(" values (");
            builder.Append("@ID,@Code,@Name,@TownID,@IsDelete)");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@ID", MySqlDbType.Int32, 4), 
                new MySqlParameter("@Code", MySqlDbType.String), 
                new MySqlParameter("@Name", MySqlDbType.String), 
                new MySqlParameter("@TownID", MySqlDbType.Int32, 4), 
                new MySqlParameter("@IsDelete", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Code;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.TownID;
            cmdParms[4].Value = model.IsDelete;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public RecordsVillageModel DataRowToModel(DataRow row)
        {
            RecordsVillageModel archive_village = new RecordsVillageModel();
            if (row != null)
            {
                archive_village.ID = row["ID"].ToString();
                if ((row["Code"] != null) && (row["Code"] != DBNull.Value))
                {
                    archive_village.Code = row["Code"].ToString();
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    archive_village.Name = row["Name"].ToString();
                }
                if ((row["TownID"] != null) && (row["TownID"] != DBNull.Value))
                {
                    archive_village.TownID = int.Parse(row["TownID"].ToString());
                }
                if (row["IsDelete"] != null)
                {
                    object obj1 = row["IsDelete"];
                }
            }
            return archive_village;
        }

        public bool Delete()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_VILLAGE ");
            builder.Append(" where ");
            MySqlParameter[] cmdParms = new MySqlParameter[0];
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,Code,Name,TownID,IsDelete ");
            builder.Append(" FROM ARCHIVE_VILLAGE ");
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
                builder.Append("order by T." + orderby);
            }
            else
            {
                builder.Append("order by T. desc");
            }
            builder.Append(")AS Row, T.*  from ARCHIVE_VILLAGE T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public RecordsVillageModel GetModel(string code)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,Code,Name,TownID,IsDelete from ARCHIVE_VILLAGE ");
            builder.Append(" where ID = @ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.String) };
            cmdParms[0].Value = code;
            new RecordsVillageModel();
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
            builder.Append("select count(1) FROM ARCHIVE_VILLAGE ");
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

        public bool Update(RecordsVillageModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_VILLAGE set ");
            builder.Append("ID=@ID,");
            builder.Append("Code=@Code,");
            builder.Append("Name=@Name,");
            builder.Append("TownID=@TownID,");
            builder.Append("IsDelete=@IsDelete");
            builder.Append(" where ");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@ID", MySqlDbType.Int32, 4), 
                new MySqlParameter("@Code", MySqlDbType.String),
                new MySqlParameter("@Name", MySqlDbType.String), 
                new MySqlParameter("@TownID", MySqlDbType.Int32, 4),
                new MySqlParameter("@IsDelete", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Code;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.TownID;
            cmdParms[4].Value = model.IsDelete;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

