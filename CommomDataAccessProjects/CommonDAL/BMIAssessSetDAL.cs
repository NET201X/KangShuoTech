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
    public partial class BMIAssessSetDAL
    {
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BMIAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_BMIAssessSet(");
            strSql.Append("IsShowNum,Unit,ExceptionCol,IncludeEqual,Thin,ThinContent,ThinContent2,ThinContent3,Overweight,OverweightContent,OverweightContent2,OverweightContent3,Obesity,");
            strSql.Append("ObesityContent,ObesityContent2,ObesityContent3,CreatedBy,CreatedDate,LastUpDateBy,LastUpdateDate)");
            strSql.Append(" VALUES (");
            strSql.Append("@IsShowNum,@Unit,@ExceptionCol,@IncludeEqual,@Thin,@ThinContent,@ThinContent2,@ThinContent3,@Overweight,@OverweightContent,@OverweightContent2,@OverweightContent3,");
            strSql.Append("@Obesity,@ObesityContent,@ObesityContent2,@ObesityContent3,@CreatedBy,@CreatedDate,@LastUpDateBy,@LastUpdateDate)");

            MySqlParameter[] parameters = {
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@Unit", MySqlDbType.VarChar,10),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@Thin", MySqlDbType.Decimal,10),
                new MySqlParameter("@ThinContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@ThinContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@ThinContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@Overweight", MySqlDbType.Decimal,10),
                new MySqlParameter("@OverweightContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@OverweightContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@OverweightContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@Obesity", MySqlDbType.Decimal,10),
                new MySqlParameter("@ObesityContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@ObesityContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@ObesityContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@CreatedBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime)
            };

            parameters[0].Value = model.IsShowNum;
            parameters[1].Value = model.Unit;
            parameters[2].Value = model.ExceptionCol;
            parameters[3].Value = model.IncludeEqual;
            parameters[4].Value = model.Thin;
            parameters[5].Value = model.ThinContent;
            parameters[6].Value = model.ThinContent2;
            parameters[7].Value = model.ThinContent3;
            parameters[8].Value = model.Overweight;
            parameters[9].Value = model.OverweightContent;
            parameters[10].Value = model.OverweightContent2;
            parameters[11].Value = model.OverweightContent3;
            parameters[12].Value = model.Obesity;
            parameters[13].Value = model.ObesityContent;
            parameters[14].Value = model.ObesityContent2;
            parameters[15].Value = model.ObesityContent3;
            parameters[16].Value = model.CreatedBy;
            parameters[17].Value = model.CreatedDate;
            parameters[18].Value = model.LastUpDateBy;
            parameters[19].Value = model.LastUpdateDate;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BMIAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_BMIAssessSet SET ");
            strSql.Append("IsShowNum=@IsShowNum,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("ExceptionCol=@ExceptionCol,");
            strSql.Append("IncludeEqual=@IncludeEqual,");
            strSql.Append("Thin=@Thin,");
            strSql.Append("ThinContent=@ThinContent,");
            strSql.Append("ThinContent2=@ThinContent2,");
            strSql.Append("ThinContent3=@ThinContent3,");
            strSql.Append("Overweight=@Overweight,");
            strSql.Append("OverweightContent=@OverweightContent,");
            strSql.Append("OverweightContent2=@OverweightContent2,");
            strSql.Append("OverweightContent3=@OverweightContent3,");
            strSql.Append("Obesity=@Obesity,");
            strSql.Append("ObesityContent=@ObesityContent,");
            strSql.Append("ObesityContent2=@ObesityContent2,");
            strSql.Append("ObesityContent3=@ObesityContent3,");
            strSql.Append("LastUpDateBy=@LastUpDateBy,");
            strSql.Append("LastUpdateDate=@LastUpdateDate");
            strSql.Append(" WHERE ID=@ID");

            MySqlParameter[] parameters = {
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@Unit", MySqlDbType.VarChar,10),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@Thin", MySqlDbType.Decimal,10),
                new MySqlParameter("@ThinContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@ThinContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@ThinContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@Overweight", MySqlDbType.Decimal,10),
                new MySqlParameter("@OverweightContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@OverweightContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@OverweightContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@Obesity", MySqlDbType.Decimal,10),
                new MySqlParameter("@ObesityContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@ObesityContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@ObesityContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime),
                new MySqlParameter("@ID", MySqlDbType.Int32,11)
            };

            parameters[0].Value = model.IsShowNum;
            parameters[1].Value = model.Unit;
            parameters[2].Value = model.ExceptionCol;
            parameters[3].Value = model.IncludeEqual;
            parameters[4].Value = model.Thin;
            parameters[5].Value = model.ThinContent;
            parameters[6].Value = model.ThinContent2;
            parameters[7].Value = model.ThinContent3;
            parameters[8].Value = model.Overweight;
            parameters[9].Value = model.OverweightContent;
            parameters[10].Value = model.OverweightContent2;
            parameters[11].Value = model.OverweightContent3;
            parameters[12].Value = model.Obesity;
            parameters[13].Value = model.ObesityContent;
            parameters[14].Value = model.ObesityContent2;
            parameters[15].Value = model.ObesityContent3;
            parameters[16].Value = model.LastUpDateBy;
            parameters[17].Value = model.LastUpdateDate;
            parameters[18].Value = model.ID;

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
            strSql.Append("SELECT * ");
            strSql.Append(" FROM tbl_BMIAssessSet ");
            if (strWHERE.Trim() != "")
            {
                strSql.Append(" WHERE " + strWHERE);
            }
            return MySQLHelper.Query(strSql.ToString());
        }
    }
}
