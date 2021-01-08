using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Text;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsFamilyBedHistoryDAL
    {
        public bool Add(RecordsFamilyBedHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_recordsfamilybedhistory(");
            builder.Append("PhysicalID,IDCardNo,HospitalName,InHospitalDate,IllcaseNums,Reasons,OutHospitalDate,OutKey)");
            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@IDCardNo,@HospitalName,@InHospitalDate,@IllcaseNums,@Reasons,@OutHospitalDate,@OutKey)");

            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@HospitalName", MySqlDbType.String, 100),
                new MySqlParameter("@InHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@IllcaseNums", MySqlDbType.String, 50),
                new MySqlParameter("@Reasons", MySqlDbType.String, 100),
                new MySqlParameter("@OutHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,11)
            };

            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.HospitalName;
            cmdParms[3].Value = model.InHospitalDate;
            cmdParms[4].Value = model.IllcaseNums;
            cmdParms[5].Value = model.Reasons;
            cmdParms[6].Value = model.OutHospitalDate;
            cmdParms[7].Value = model.OutKey;

            int rows = MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);

            if (rows > 0) return true;
            else return false;
        }

        public bool DeleteByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("DELETE FROM tbl_recordsfamilybedhistory ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

		public DataSet GetList(string strWhere)
		{
			StringBuilder builder = new StringBuilder();

			builder.Append("SELECT* FROM tbl_recordsfamilybedhistory ");

			if (strWhere.Trim() != "")
			{
				builder.Append(" WHERE " + strWhere + " ORDER BY id LIMIT 2");
			}

			return MySQLHelper.Query(builder.ToString());
		}
    }
}
