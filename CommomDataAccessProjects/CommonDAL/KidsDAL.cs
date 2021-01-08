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

            builder.Append("SELECT * FROM tbl_KidsTcmhmOne ");
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

            builder.Append("SELECT * FROM tbl_KidsTcmhmOneToThree ");
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

            builder.Append("SELECT * FROM tbl_KidsTcmhmThreeToSix ");
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

            builder.Append("SELECT * FROM tbl_kidswithinoneyearold ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }
    }
}