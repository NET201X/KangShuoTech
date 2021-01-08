using CommomUtilities.Common;
using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class WaistlineAssessSetDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WaistlineAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_WaistlineAssessSet(");
            strSql.Append("IsShowNum,Unit,ExceptionCol,IncludeEqual,MaleWaistline,FemaleWaistline,Content,Content2,Content3,CreatedBy,CreatedDate,LastUpDateBy,LastUpdateDate)");
            strSql.Append(" VALUES (");
            strSql.Append("@IsShowNum,@Unit,@ExceptionCol,@IncludeEqual,@MaleWaistline,@FemaleWaistline,@Content,@Content2,@Content3,@CreatedBy,@CreatedDate,@LastUpDateBy,@LastUpdateDate)");

            MySqlParameter[] parameters = {
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@Unit", MySqlDbType.VarChar,10),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@MaleWaistline", MySqlDbType.Decimal,10),
                new MySqlParameter("@FemaleWaistline", MySqlDbType.Decimal,10),
                new MySqlParameter("@Content", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content2", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content3", MySqlDbType.VarChar,50),
                new MySqlParameter("@CreatedBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime)
            };

            parameters[0].Value = model.IsShowNum;
            parameters[1].Value = model.Unit;
            parameters[2].Value = model.ExceptionCol;
            parameters[3].Value = model.IncludeEqual;
            parameters[4].Value = model.MaleWaistline;
            parameters[5].Value = model.FemaleWaistline;
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
        public bool Update(WaistlineAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_WaistlineAssessSet SET ");
            strSql.Append("IsShowNum=@IsShowNum,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("ExceptionCol=@ExceptionCol,");
            strSql.Append("IncludeEqual=@IncludeEqual,");
            strSql.Append("MaleWaistline=@MaleWaistline,");
            strSql.Append("FemaleWaistline=@FemaleWaistline,");
            strSql.Append("Content=@Content,");
            strSql.Append("Content2=@Content2,");
            strSql.Append("Content3=@Content3,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("CreatedDate=@CreatedDate,");
            strSql.Append("LastUpDateBy=@LastUpDateBy,");
            strSql.Append("LastUpdateDate=@LastUpdateDate");
            strSql.Append(" WHERE ID=@ID");

            MySqlParameter[] parameters = {
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@Unit", MySqlDbType.VarChar,10),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@MaleWaistline", MySqlDbType.Decimal,10),
                new MySqlParameter("@FemaleWaistline", MySqlDbType.Decimal,10),
                new MySqlParameter("@Content", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content2", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content3", MySqlDbType.VarChar,50),
                new MySqlParameter("@CreatedBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime),
                new MySqlParameter("@ID", MySqlDbType.Int32,11)
            };

            parameters[0].Value = model.IsShowNum;
            parameters[1].Value = model.Unit;
            parameters[2].Value = model.ExceptionCol;
            parameters[3].Value = model.IncludeEqual;
            parameters[4].Value = model.MaleWaistline;
            parameters[5].Value = model.FemaleWaistline;
            parameters[6].Value = model.Content;
            parameters[7].Value = model.Content2;
            parameters[8].Value = model.Content3;
            parameters[9].Value = model.CreatedBy;
            parameters[10].Value = model.CreatedDate;
            parameters[11].Value = model.LastUpDateBy;
            parameters[12].Value = model.LastUpdateDate;
            parameters[13].Value = model.ID;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT * FROM tbl_WaistlineAssessSet ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            return MySQLHelper.Query(strSql.ToString());
        }
    }
}
