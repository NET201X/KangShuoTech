using KangShuoTech.Utilities.SQLiteHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using System.Text;
    using System.Data.SQLite;
    using System.Collections.Generic;

    public class DeviceInfoSqliteDAL
    {
        public DataSet GetList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT *,DATE(UpdateData) CheckDate ");
            builder.Append("FROM DeviceInfo ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }

        public DataSet GetMaxList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT date(UpdateData) CheckDate,ID,DeviceType,DeviceName,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,Value10,Value11,Value12,Value13,IsUpload,IDCardNo,ID ");
            builder.Append(" FROM DeviceInfo  ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" ORDER BY ID");
            //builder.Append(" GROUP BY IDCardNo,DeviceType,date(UpdateData),Type ");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }

        public void Update(string failedInfo, string conn = "") //更新minipad 血压,尿仪,体温体重
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"Update DeviceInfo set 
                            IsUpload='Y'");
            builder.Append(failedInfo);
            YcSqliteHelper.ExecuteSqlConnect(builder.ToString(), conn);
        }
    }
}
