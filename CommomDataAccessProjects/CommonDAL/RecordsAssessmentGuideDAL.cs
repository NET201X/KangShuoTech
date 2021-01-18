namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using CommonUtilities.SQL;
    using System;
    using CommonModel;

    public class RecordsAssessmentGuideDAL
    {
        public int Add(RecordsAssessmentGuideModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_ASSESSMENTGUIDE(IDCardNo,OutKey)");
            builder.Append(" VALUES (@IDCardNo,@OutKey)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,11)
            };

            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.OutKey;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_ASSESSMENTGUIDE ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }
    }
}