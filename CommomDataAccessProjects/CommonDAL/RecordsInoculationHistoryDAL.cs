using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsInoculationHistoryDAL
    {
        public bool Add(RecordsInoculationHistoryModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_INOCULATIONHISTORY(");
            builder.Append("PhysicalID,IDCardNo,PillName,InoculationDate,InoculationHistory,OutKey)");
            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@IDCardNo,@PillName,@InoculationDate,@InoculationHistory,@OutKey)");

            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@PillName", MySqlDbType.String, 100),
                new MySqlParameter("@InoculationDate", MySqlDbType.Date),
                new MySqlParameter("@InoculationHistory", MySqlDbType.String, 100),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4)
            };

            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.PillName;
            cmdParms[3].Value = model.InoculationDate;
            cmdParms[4].Value = model.InoculationHistory;
            cmdParms[5].Value = model.OutKey;

            int rows = MySQLHelper.ExecuteSql(builder.ToString(), cmdParms);

            if (rows > 0) return true;
            else return false;
        }

        public bool DeleteByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("DELETE FROM ARCHIVE_INOCULATIONHISTORY ");
            builder.Append(" WHERE OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

		public DataSet GetList(string strWhere)
		{
			StringBuilder builder = new StringBuilder();

			builder.Append("SELECT * FROM ARCHIVE_INOCULATIONHISTORY ");

			if (strWhere.Trim() != "")
			{
				builder.Append(" WHERE " + strWhere + " ORDER BY id LIMIT 3");
			}

			return MySQLHelper.Query(builder.ToString());
		}
    }
}
