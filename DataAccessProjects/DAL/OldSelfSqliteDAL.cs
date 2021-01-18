using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.SQLiteHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class OldSelfSqliteDAL
    {
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,Dine,Groming,Dressing,Tolet,Activity,TotalScore,RecordDate ");
            builder.Append(" FROM OLDER_SELFCAREABILITY ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return YcSqliteHelper.Query(builder.ToString());
        }

        public DataSet GetMaxList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT ID,IDCardNo,Dine,Groming,Dressing,Tolet,Activity,TotalScore,RecordDate ");
            builder.Append(" FROM OLDER_SELFCAREABILITY Medicinecn ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY IDCardNo,date(RecordDate) ");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }
    }
}
