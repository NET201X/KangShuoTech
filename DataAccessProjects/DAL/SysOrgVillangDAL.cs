namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class SysOrgVillangDAL
    {
        public bool Add(SysOrgVillangModle model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_sysorgvillage(");
            builder.Append("ID,Code,Name,TownID)");
            builder.Append(" values (");
            builder.Append("@ID,@Code,@Name,@TownID)");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@ID", MySqlDbType.String), 
                new MySqlParameter("@Code", MySqlDbType.String), 
                new MySqlParameter("@Name", MySqlDbType.String), 
                new MySqlParameter("@TownID", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Code;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.TownID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public SysOrgVillangModle DataRowToModel(DataRow row)
        {
            SysOrgVillangModle sys_org_village = new SysOrgVillangModle();
            if (row != null)
            {
                sys_org_village.ID = row["ID"].ToString();
                if ((row["Code"] != null) && (row["Code"] != DBNull.Value))
                {
                    sys_org_village.Code = row["Code"].ToString();
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    sys_org_village.Name = row["Name"].ToString();
                }
                sys_org_village.TownID = int.Parse(row["TownID"].ToString());
            }
            return sys_org_village;
        }

        public bool Delete()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_sysorgvillage ");
            builder.Append(" where ");
            MySqlParameter[] cmdParms = new MySqlParameter[0];
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,Code,Name,TownID ");
            builder.Append(" FROM tbl_sysorgvillage ");
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
            builder.Append(")AS Row, T.*  from tbl_sysorgvillage T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public SysOrgVillangModle GetModel(string code)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,Code,Name,TownID from tbl_sysorgvillage ");
            builder.Append(" where Code = @Code");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@Code", MySqlDbType.String) };
            cmdParms[0].Value = code;
            new SysOrgVillangModle();
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
            builder.Append("select count(1) FROM tbl_sysorgvillage ");
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

        public bool Update(SysOrgVillangModle model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_sysorgvillage set ");
            builder.Append("ID=@ID,");
            builder.Append("Code=@Code,");
            builder.Append("Name=@Name,");
            builder.Append("TownID=@TownID");
            builder.Append(" where ");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@ID", MySqlDbType.String),
                new MySqlParameter("@Code", MySqlDbType.String),
                new MySqlParameter("@Name", MySqlDbType.String), 
                new MySqlParameter("@TownID", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Code;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.TownID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

