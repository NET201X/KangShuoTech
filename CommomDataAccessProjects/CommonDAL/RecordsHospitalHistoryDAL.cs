using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Text;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsHospitalHistoryDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(RecordsHospitalHistoryModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO ARCHIVE_HOSPITALHISTORY(");
            strSql.Append("PhysicalID,IDCardNo,InHospitalDate,Reason,IllcaseNum,HospitalName,OutHospitalDate,OutKey)");
            strSql.Append(" VALUES (");
            strSql.Append("@PhysicalID,@IDCardNo,@InHospitalDate,@Reason,@IllcaseNum,@HospitalName,@OutHospitalDate,@OutKey)");

            MySqlParameter[] parameters = {
                new MySqlParameter("@PhysicalID", MySqlDbType.VarChar,100),
                new MySqlParameter("@IDCardNo", MySqlDbType.VarChar,21),
                new MySqlParameter("@InHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@Reason", MySqlDbType.VarChar,100),
                new MySqlParameter("@IllcaseNum", MySqlDbType.VarChar,100),
                new MySqlParameter("@HospitalName", MySqlDbType.VarChar,100),
                new MySqlParameter("@OutHospitalDate", MySqlDbType.Date),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,11)
            };

            parameters[0].Value = model.PhysicalID;
            parameters[1].Value = model.IDCardNo;
            parameters[2].Value = model.InHospitalDate;
            parameters[3].Value = model.Reason;
            parameters[4].Value = model.IllcaseNum;
            parameters[5].Value = model.HospitalName;
            parameters[6].Value = model.OutHospitalDate;
            parameters[7].Value = model.OutKey;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        public bool DeleteByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("DELETE FROM ARCHIVE_HOSPITALHISTORY ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

		public DataSet GetList(string strWhere)
		{
			StringBuilder builder = new StringBuilder();

			builder.Append("SELECT * FROM ARCHIVE_HOSPITALHISTORY ");

			if (strWhere.Trim() != "")
			{
				builder.Append(" WHERE " + strWhere + " ORDER BY id LIMIT 2");
			}

			return MySQLHelper.Query(builder.ToString());
		}
    }
}
