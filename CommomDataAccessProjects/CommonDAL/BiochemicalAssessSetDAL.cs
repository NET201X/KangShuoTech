using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class BiochemicalAssessSetDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BiochemicalAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_BiochemicalAssessSet(");
            strSql.Append("Type,ExceptionCol,IsShowDetail,Content,Content2,Content3,CreatedBy,CreatedDate,LastUpDateBy,LastUpdateDate)");
            strSql.Append(" VALUES (");
            strSql.Append("@Type,@ExceptionCol,@IsShowDetail,@Content,@Content2,@Content3,@CreatedBy,@CreatedDate,@LastUpDateBy,@LastUpdateDate)");

            MySqlParameter[] parameters = {
                new MySqlParameter("@Type", MySqlDbType.VarChar,2),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IsShowDetail", MySqlDbType.VarChar,1),
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
            parameters[2].Value = model.IsShowDetail;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.Content2;
            parameters[5].Value = model.Content3;
            parameters[6].Value = model.CreatedBy;
            parameters[7].Value = model.CreatedDate;
            parameters[8].Value = model.LastUpDateBy;
            parameters[9].Value = model.LastUpdateDate;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BiochemicalAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_BiochemicalAssessSet SET ");
            strSql.Append("Type=@Type,");
            strSql.Append("ExceptionCol=@ExceptionCol,");
            strSql.Append("IsShowDetail=@IsShowDetail,");
            strSql.Append("Content=@Content,");
            strSql.Append("Content2=@Content2,");
            strSql.Append("Content3=@Content3,");
            strSql.Append("LastUpDateBy=@LastUpDateBy,");
            strSql.Append("LastUpdateDate=@LastUpdateDate");
            strSql.Append(" WHERE ID=@ID");

            MySqlParameter[] parameters = {
                new MySqlParameter("@Type", MySqlDbType.VarChar,2),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IsShowDetail", MySqlDbType.VarChar,1),
                new MySqlParameter("@Content", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content2", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content3", MySqlDbType.VarChar,50),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime),
                new MySqlParameter("@ID", MySqlDbType.Int32,11)
            };

            parameters[0].Value = model.Type;
            parameters[1].Value = model.ExceptionCol;
            parameters[2].Value = model.IsShowDetail;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.Content2;
            parameters[5].Value = model.Content3;
            parameters[6].Value = model.LastUpDateBy;
            parameters[7].Value = model.LastUpdateDate;
            parameters[8].Value = model.ID;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
		/// 删除数据
		/// </summary>
		public bool Delete(int Type)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("DELETE FROM tbl_BiochemicalAssessSet ");
            strSql.Append(" WHERE Type=@Type");

            MySqlParameter[] parameters = {
                new MySqlParameter("@Type", MySqlDbType.Int32)
            };
            parameters[0].Value = Type;

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

            strSql.Append("SELECT * FROM tbl_BiochemicalAssessSet ");

            if (strWHERE.Trim() != "")
            {
                strSql.Append(" WHERE " + strWHERE);
            }

            return MySQLHelper.Query(strSql.ToString());
        }
    }
}
