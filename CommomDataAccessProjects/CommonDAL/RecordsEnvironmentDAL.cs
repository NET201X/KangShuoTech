namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using MySql.Data.MySqlClient;
    using CommonUtilities.SQL;
    using System.Data;
    using System.Text;

    public class RecordsEnvironmentDAL
    {
        public DataSet GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_recordsenvironment ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }        
    }
}