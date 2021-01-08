namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using CommonUtilities.SQL;

    public class SysOrgTownDAL
    {
        public DataSet GetModel(string code)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_SysOrgTown ");
            builder.Append(" WHERE Code = @Code");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@Code", MySqlDbType.String) };

            cmdParms[0].Value = code;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            
            return set;
        }
    }
}

