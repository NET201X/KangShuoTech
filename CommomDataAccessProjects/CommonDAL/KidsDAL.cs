namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using System.Data;
    using System.Text;
    using CommonUtilities.SQL;
    using MySql.Data.MySqlClient;

    public class KidsTcmhmOneDAL
    {
        public DataSet GetList(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM CHILD_TCMHM_ONE ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }
    }

    public class KidsTcmhmOneToThreeDAL
    {
        public DataSet GetList(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM CHILD_TCMHM_ONE2THREE ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }
    }

    public class KidsTcmhmThreeToSixDAL
    {
        public DataSet GetList(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM CHILD_TCMHM_THREE2SIX ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }
    }

    public class KidsWithinOneYearOldDAL
    {
        public DataSet GetList(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM CHILD_WITHIN_ONE_YEAR_OLD ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }
    }
}