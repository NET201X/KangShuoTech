
namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using CommonUtilities.SQL;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using CommonModel;
    using System.Collections.Generic;

    public class RequireDAL
    {
        /// <summary>
        /// 取奇偶数设定
        /// </summary>
        /// <param name="TabName"></param>
        /// <param name="Comment"></param>
        /// <param name="ChinName"></param>
        /// <returns></returns>
        public DataSet GetData(string TabName, string Comment, string ChinName)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_REQUIRED ");
            builder.Append(" WHERE TabName=@TabName AND Comment=@Comment AND ChinName LIKE @ChinName");
            builder.Append(" AND IFNULL(IsOdevity,'否')!='否' AND IsOdevity!=''");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@TabName", MySqlDbType.VarChar),
                new MySqlParameter("@Comment", MySqlDbType.VarChar),
                new MySqlParameter("@ChinName", MySqlDbType.VarChar)
            };

            cmdParms[0].Value = TabName;
            cmdParms[1].Value = Comment;
            cmdParms[2].Value = "%" + ChinName;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        /// <summary>
        /// 取小数位设定
        /// </summary>
        /// <param name="TabName"></param>
        /// <param name="Comment"></param>
        /// <param name="ChinName"></param>
        /// <returns></returns>
        public DataSet GetDecimalData(string TabName, string Comment, string ChinName)
        {
            StringBuilder builder = new StringBuilder();
            List<MySqlParameter> cmdParms = new List<MySqlParameter>();

            builder.Append("SELECT * FROM ARCHIVE_REQUIRED ");
            builder.Append(" WHERE TabName=@TabName AND Comment=@Comment ");

            if(ChinName != "")
            {
                builder.Append(" AND ChinName LIKE @ChinName");
                cmdParms.Add(new MySqlParameter("@ChinName", "%" + ChinName));
            }

            builder.Append(" AND IFNULL(IsDecimalPlace, '') = '是' AND IFNULL(DecimalPlace, '') != '' ");

            cmdParms.Add(new MySqlParameter("@TabName", TabName));
            cmdParms.Add(new MySqlParameter("@Comment", Comment));

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms.ToArray());

            return set;
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT *  ");
            builder.Append(" FROM ARCHIVE_REQUIRED ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" GROUP BY TabName,Comment,ChinName ");

            return MySQLHelper.Query(builder.ToString());
        }

        public bool UpdateID(int id, string Isrequired, string IsDecimalPlace, int DecimalPlace, string IsOdevity, string SetValue, string isSetValue, string ItemValue)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ARCHIVE_REQUIRED SET ");
            builder.Append("Isrequired=@Isrequired,  ");
            builder.Append("IsSetValue=@IsSetValue, ");
            builder.Append("SetValue=@SetValue,  ");
            builder.Append("ItemValue=@ItemValue, ");
            builder.Append("IsDecimalPlace=@IsDecimalPlace, ");
            builder.Append("DecimalPlace=@DecimalPlace, ");
            builder.Append("IsOdevity=@IsOdevity ");
            builder.Append(" WHERE ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
              new MySqlParameter("@Isrequired", MySqlDbType.String),
              new MySqlParameter("@IsSetValue",MySqlDbType.String),
              new MySqlParameter("@SetValue", MySqlDbType.String),
              new MySqlParameter("@ItemValue",MySqlDbType.String),
              new MySqlParameter("@ID", MySqlDbType.Int32, 8),
              new MySqlParameter("@IsDecimalPlace",MySqlDbType.String),
              new MySqlParameter("@DecimalPlace",MySqlDbType.Int32),
              new MySqlParameter("@IsOdevity",MySqlDbType.String)
            };

            cmdParms[0].Value = Isrequired;
            cmdParms[1].Value = isSetValue;
            cmdParms[2].Value = SetValue;
            cmdParms[3].Value = ItemValue;
            cmdParms[4].Value = id;
            cmdParms[5].Value = IsDecimalPlace;
            cmdParms[6].Value = DecimalPlace;
            cmdParms[7].Value = IsOdevity;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public void UpdateTable(string TableName, string OptionName, string DecimalPlace)
        {
            if (string.IsNullOrEmpty(DecimalPlace)) return;

            //获取字段类型
            string SqlGetType = string.Format("SELECT column_name,column_comment,data_type,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE " +
                "FROM information_schema.columns WHERE table_name = '{0}' AND table_schema = 'kangshuo_db' AND column_name='{1}'", TableName, OptionName);

            DataTable dt = MySQLHelper.Query(SqlGetType).Tables[0];

            if (dt.Rows.Count > 0)
            {
                //字段类型
                string data_type = dt.Rows[0]["data_type"].ToString();

                //字段长度
                string NUMERIC_PRECISION = dt.Rows[0]["NUMERIC_PRECISION"].ToString();

                //小数位数
                //string NUMERIC_SCALE = dt.Rows[0]["NUMERIC_SCALE"].ToString();
                if (data_type == "decimal")
                {
                    string sql = string.Format("alter table {0} modify column {1} decimal({2}, {3}); ", TableName, OptionName, NUMERIC_PRECISION, DecimalPlace);
                    MySQLHelper.ExecuteSql(sql);
                }
            }
        }

        public DataSet GetTabName()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT TabName  FROM ARCHIVE_REQUIRED  ");
            builder.Append(" GROUP BY TabName ");

            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetComment()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT TabName,Comment  FROM ARCHIVE_REQUIRED  ");
            builder.Append(" GROUP BY Comment ");

            return MySQLHelper.Query(builder.ToString());
        }
    }
}
