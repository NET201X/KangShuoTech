namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using System.Data;
    using System.Text;
    using CommonUtilities.SQL;
    using MySql.Data.MySqlClient;
    using System;
    using CommonModel;
    /// <summary>
    /// </summary>
    public class OtherAssessSetDAL
    {
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(OtherAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_OtherAssessSet(");
            strSql.Append("Type,ExceptionCol,IsShowNum,IncludeEqual,MaxVal,MinVal,Content,Content2,Content3,CreatedBy,CreatedDate,LastUpDateBy,LastUpdateDate)");
            strSql.Append(" VALUES (");
            strSql.Append("@Type,@ExceptionCol,@IsShowNum,@IncludeEqual,@MaxVal,@MinVal,@Content,@Content2,@Content3,@CreatedBy,@CreatedDate,@LastUpDateBy,@LastUpdateDate)");

            MySqlParameter[] parameters = {
                new MySqlParameter("@Type", MySqlDbType.VarChar,2),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@MaxVal", MySqlDbType.Decimal,10),
                new MySqlParameter("@MinVal", MySqlDbType.Decimal,10),
                new MySqlParameter("@Content", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content2", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content3", MySqlDbType.VarChar,50),
                new MySqlParameter("@CreatedBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime)
            };

            parameters[0].Value = model.Type;
            parameters[1].Value = model.ExceptionCol;
            parameters[2].Value = model.IsShowNum;
            parameters[3].Value = model.IncludeEqual;
            parameters[4].Value = model.MaxVal;
            parameters[5].Value = model.MinVal;
            parameters[6].Value = model.Content;
            parameters[7].Value = model.Content2;
            parameters[8].Value = model.Content3;
            parameters[9].Value = model.CreatedBy;
            parameters[10].Value = model.CreatedDate;
            parameters[11].Value = model.LastUpDateBy;
            parameters[12].Value = model.LastUpdateDate;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(OtherAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_OtherAssessSet SET ");
            strSql.Append("Type=@Type,");
            strSql.Append("ExceptionCol=@ExceptionCol,");
            strSql.Append("IsShowNum=@IsShowNum,");
            strSql.Append("IncludeEqual=@IncludeEqual,");
            strSql.Append("MaxVal=@MaxVal,");
            strSql.Append("MinVal=@MinVal,");
            strSql.Append("Content=@Content,");
            strSql.Append("Content2=@Content2,");
            strSql.Append("Content3=@Content3,");
            strSql.Append("LastUpDateBy=@LastUpDateBy,");
            strSql.Append("LastUpdateDate=@LastUpdateDate");
            strSql.Append(" WHERE ID=@ID");

            MySqlParameter[] parameters = {
                new MySqlParameter("@Type", MySqlDbType.VarChar,2),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@MaxVal", MySqlDbType.Decimal,10),
                new MySqlParameter("@MinVal", MySqlDbType.Decimal,10),
                new MySqlParameter("@Content", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content2", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content3", MySqlDbType.VarChar,50),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime),
                new MySqlParameter("@ID", MySqlDbType.Int32,11)
            };

            parameters[0].Value = model.Type;
            parameters[1].Value = model.ExceptionCol;
            parameters[2].Value = model.IsShowNum;
            parameters[3].Value = model.IncludeEqual;
            parameters[4].Value = model.MaxVal;
            parameters[5].Value = model.MinVal;
            parameters[6].Value = model.Content;
            parameters[7].Value = model.Content2;
            parameters[8].Value = model.Content3;
            parameters[9].Value = model.LastUpDateBy;
            parameters[10].Value = model.LastUpdateDate;
            parameters[11].Value = model.ID;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("DELETE FROM tbl_OtherAssessSet ");
            strSql.Append(" WHERE ID=@ID");

            MySqlParameter[] parameters = {
                new MySqlParameter("@ID", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWHERE)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT * FROM tbl_OtherAssessSet ");

            if (strWHERE.Trim() != "")
            {
                strSql.Append(" WHERE " + strWHERE);
            }

            return MySQLHelper.Query(strSql.ToString());
        }
    }
}
