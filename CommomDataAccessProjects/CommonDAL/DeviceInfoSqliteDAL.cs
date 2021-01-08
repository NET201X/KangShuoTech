
using CommonUtilities.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
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

            builder.Append("SELECT DATE(UpdateData) CheckDate,* ");
            builder.Append(" FROM DeviceInfo  ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" ORDER BY ID");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }
    }
}
