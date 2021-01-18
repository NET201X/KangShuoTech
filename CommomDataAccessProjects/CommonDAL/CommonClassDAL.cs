using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class CommonClassDAL
    {
        public bool Update(string idCardNo, string photoPath)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ARCHIVE_BASEINFO SET ");
            builder.Append("PhotoPath=@PhotoPath");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@PhotoPath", photoPath),
                new MySqlParameter("@IDCardNo", idCardNo)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(1) FROM ARCHIVE_BASEINFO ");

            if (strWhere.Trim() != "") builder.Append(" WHERE 1=1 " + strWhere);

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_BASEINFO ");

            if (!string.IsNullOrEmpty(strWhere.Trim())) builder.Append(" WHERE 1=1 " + strWhere);

            if (!string.IsNullOrEmpty(orderBy.Trim())) builder.Append(" ORDER BY " + orderBy);
            else builder.Append(" ORDER BY ID DESC");

            builder.Append(string.Format(" LIMIT {0},{1}", startIndex, endIndex));

            return MySQLHelper.Query(builder.ToString());
        }

        public DataTable GetData(string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_DataUpload ");

            return MySQLHelper.GetDataTable(builder.ToString(), conn);
        }

        public bool Update(string conn, string startDate, string endDate, string dataType, string deviceType, string versionNo,
            string isNewTypeB, string ecgType, string total, string count, string col2, string col3)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE tbl_DataUpload 
                             SET 
                                StartDate = @StartDate 
                                ,EndDate = @EndDate 
                                ,DataType = @DataType 
                                ,DeviceType = @DeviceType 
                                ,VersionNo = @VersionNo 
                                ,IsNewTypeB = @IsNewTypeB 
                                ,ECGType = @ECGType 
                                ,Total = @Total 
                                ,Count = @Count 
                                ,Col2 = @Col2 
                                ,Col3 = @Col3 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@StartDate", MySqlDbType.String, 10),
                new MySqlParameter("@EndDate", MySqlDbType.String, 10),
                new MySqlParameter("@DataType", MySqlDbType.String, 30),
                new MySqlParameter("@DeviceType", MySqlDbType.String, 10),
                new MySqlParameter("@VersionNo", MySqlDbType.String, 10),
                new MySqlParameter("@IsNewTypeB", MySqlDbType.String, 1),
                new MySqlParameter("@ECGType", MySqlDbType.String, 1),
                new MySqlParameter("@Total", MySqlDbType.Int32),
                new MySqlParameter("@Count", MySqlDbType.Int32),
                new MySqlParameter("@Col2", MySqlDbType.String, 50),
                new MySqlParameter("@Col3", MySqlDbType.String, 20)
            };

            cmdParms[0].Value = startDate;
            cmdParms[1].Value = endDate;
            cmdParms[2].Value = dataType;
            cmdParms[3].Value = deviceType;
            cmdParms[4].Value = versionNo;
            cmdParms[5].Value = isNewTypeB;
            cmdParms[6].Value = ecgType;
            cmdParms[7].Value = total;
            cmdParms[8].Value = count;
            cmdParms[9].Value = col2;
            cmdParms[10].Value = col3;

            return (MySQLHelper.ExecuteSql(builder.ToString(), conn, cmdParms) > 0);
        }
    }
}
