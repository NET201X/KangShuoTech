namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using KangShuoTech.Utilities.SQLiteHelper;

    public class RecordsMedicationSqliteDAL
    {
        public bool ISconnectOpen()
        {
            return YcSqliteHelper.ISconnectOpen();
        }

        public DataSet GetList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("select * ");
            builder.Append(" FROM tbl_recordsmedication ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }

        public DataSet GetMaxList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select id,medicinalname,useage,usenum,pilldependence,starttime,drugtype,outkey ");
            builder.Append(" FROM tbl_recordsmedication ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            //builder.Append(" GROUP BY IDCardNo,date(RecordDate) ");

            return YcSqliteHelper.Query(builder.ToString());
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM tbl_recordsmedication ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = YcSqliteHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
    }
}
