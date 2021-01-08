using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class BioDetailAssessSetDAL
    {
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BioDetailAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_BioDetailAssessSet(");
            strSql.Append("Type,CodeName,Code,Unit,IsShowNum,IncludeEqual,Sex,MaxVal,MinVal,Content,Content2,Content3,CreatedBy,CreatedDate,LastUpDateBy,LastUpdateDate,Seq,IfUsing)");
            strSql.Append(" VALUES (");
            strSql.Append("@Type,@CodeName,@Code,@Unit,@IsShowNum,@IncludeEqual,@Sex,@MaxVal,@MinVal,@Content,@Content2,@Content3,@CreatedBy,@CreatedDate,@LastUpDateBy,@LastUpdateDate,@Seq,@IfUsing)");

            MySqlParameter[] parameters = {
                new MySqlParameter("@Type", MySqlDbType.VarChar,2),
                new MySqlParameter("@CodeName", MySqlDbType.VarChar,50),
                new MySqlParameter("@Code", MySqlDbType.VarChar,10),
                new MySqlParameter("@Unit", MySqlDbType.VarChar,10),
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@Sex", MySqlDbType.VarChar,1),
                new MySqlParameter("@MaxVal", MySqlDbType.VarChar,30),
                new MySqlParameter("@MinVal", MySqlDbType.VarChar,30),
                new MySqlParameter("@Content", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content2", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content3", MySqlDbType.VarChar,50),
                new MySqlParameter("@CreatedBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime),
                new MySqlParameter("@Seq",MySqlDbType.Int32,11),
                new MySqlParameter("@IfUsing",MySqlDbType.Int32,10)
            };

            parameters[0].Value = model.Type;
            parameters[1].Value = model.CodeName;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.Unit;
            parameters[4].Value = model.IsShowNum;
            parameters[5].Value = model.IncludeEqual;
            parameters[6].Value = model.Sex;
            parameters[7].Value = model.MaxVal;
            parameters[8].Value = model.MinVal;
            parameters[9].Value = model.Content;
            parameters[10].Value = model.Content2;
            parameters[11].Value = model.Content3;
            parameters[12].Value = model.CreatedBy;
            parameters[13].Value = model.CreatedDate;
            parameters[14].Value = model.LastUpDateBy;
            parameters[15].Value = model.LastUpdateDate;
            parameters[16].Value = model.Seq;
            parameters[17].Value = model.IfUsing;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BioDetailAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_BioDetailAssessSet SET ");
            strSql.Append("Type=@Type,");
            strSql.Append("CodeName=@CodeName,");
            strSql.Append("Code=@Code,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("IsShowNum=@IsShowNum,");
            strSql.Append("IncludeEqual=@IncludeEqual,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("MaxVal=@MaxVal,");
            strSql.Append("MinVal=@MinVal,");
            strSql.Append("Content=@Content,");
            strSql.Append("Content2=@Content2,");
            strSql.Append("Content3=@Content3,");
            strSql.Append("LastUpDateBy=@LastUpDateBy,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("Seq=@Seq,");
            strSql.Append("IfUsing=@IfUsing");
            strSql.Append(" WHERE ID=@ID");

            MySqlParameter[] parameters = {
                new MySqlParameter("@Type", MySqlDbType.VarChar,2),
                new MySqlParameter("@CodeName", MySqlDbType.VarChar,50),
                new MySqlParameter("@Code", MySqlDbType.VarChar,10),
                new MySqlParameter("@Unit", MySqlDbType.VarChar,10),
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@Sex", MySqlDbType.VarChar,1),
                new MySqlParameter("@MaxVal", MySqlDbType.VarChar,30),
                new MySqlParameter("@MinVal", MySqlDbType.VarChar,30),
                new MySqlParameter("@Content", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content2", MySqlDbType.VarChar,50),
                new MySqlParameter("@Content3", MySqlDbType.VarChar,50),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime),
                new MySqlParameter("@Seq",MySqlDbType.Int32,11),
                new MySqlParameter("@IfUsing",MySqlDbType.Int32,11),
                new MySqlParameter("@ID", MySqlDbType.Int32,11)
            };

            parameters[0].Value = model.Type;
            parameters[1].Value = model.CodeName;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.Unit;
            parameters[4].Value = model.IsShowNum;
            parameters[5].Value = model.IncludeEqual;
            parameters[6].Value = model.Sex;
            parameters[7].Value = model.MaxVal;
            parameters[8].Value = model.MinVal;
            parameters[9].Value = model.Content;
            parameters[10].Value = model.Content2;
            parameters[11].Value = model.Content3;
            parameters[12].Value = model.LastUpDateBy;
            parameters[13].Value = model.LastUpdateDate;
            parameters[14].Value = model.Seq;
            parameters[15].Value = model.IfUsing;
            parameters[16].Value = model.ID;

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

            strSql.Append("SELECT * FROM tbl_BioDetailAssessSet ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            return MySQLHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("DELETE FROM tbl_BioDetailAssessSet ");
            strSql.Append(" WHERE Type=@ID");

            MySqlParameter[] parameters = {
                new MySqlParameter("@Type", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        public DataTable GetDistinctCode(int Type)
        {
            string sql = $"SELECT DISTINCT code FROM tbl_BioDetailAssessSet WHERE Type='{Type}' AND sex!='0' and IfUsing='1' GROUP BY code";
            return MySQLHelper.GetDataTable(sql);
        }

        public bool InserBio(ArrayList list) {
            return MySQLHelper.ExecuteSqlTran(list);
        }
    }
}
