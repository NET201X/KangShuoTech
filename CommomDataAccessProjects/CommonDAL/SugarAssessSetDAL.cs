namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using CommonUtilities.SQL;
    using MySql.Data.MySqlClient;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class SugarAssessSetDAL
    {
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SugarAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_SugarAssessSet(");
            strSql.Append("IsShowNum,Unit,ExceptionCol,IncludeEqual,GeneralHigh,GeneralHighContent,GeneralHighContent2,GeneralHighContent3,GeneralLow,GeneralLowContent,GeneralLowContent2,GeneralLowContent3,");
            strSql.Append("DistiPopType,DiaHigh,DiaHighContent,DiaHighContent2,DiaHighContent3,DiaLow,DiaLowContent,DiaLowContent2,DiaLowContent3,DistiOlder,OldHigh,OldHighContent,OldHighContent2,");
            strSql.Append("OldHighContent3,OldLow,OldLowContent,OldLowContent2,OldLowContent3,IsReview,ReviewHigh,ReviewLow,IsReferral,ReferralHigh,ReferralLow,CreatedBy,CreatedDate,LastUpDateBy,LastUpdateDate)");
            strSql.Append(" VALUES (");
            strSql.Append("@IsShowNum,@Unit,@ExceptionCol,@IncludeEqual,@GeneralHigh,@GeneralHighContent,@GeneralHighContent2,@GeneralHighContent3,@GeneralLow,@GeneralLowContent,@GeneralLowContent2,");
            strSql.Append("@GeneralLowContent3,@DistiPopType,@DiaHigh,@DiaHighContent,@DiaHighContent2,@DiaHighContent3,@DiaLow,@DiaLowContent,@DiaLowContent2,@DiaLowContent3,@DistiOlder,@OldHigh,@OldHighContent,");
            strSql.Append("@OldHighContent2,@OldHighContent3,@OldLow,@OldLowContent,@OldLowContent2,@OldLowContent3,@IsReview,@ReviewHigh,@ReviewLow,@IsReferral,@ReferralHigh,@ReferralLow,@CreatedBy,@CreatedDate,");
            strSql.Append("@LastUpDateBy,@LastUpdateDate)");

            MySqlParameter[] parameters = {
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@Unit", MySqlDbType.VarChar,10),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@GeneralHigh", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralLow", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@DistiPopType", MySqlDbType.VarChar,1),
                new MySqlParameter("@DiaHigh", MySqlDbType.Decimal,10),
                new MySqlParameter("@DiaHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@DiaHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@DiaHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@DiaLow", MySqlDbType.Decimal,10),
                new MySqlParameter("@DiaLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@DiaLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@DiaLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@DistiOlder", MySqlDbType.VarChar,1),
                new MySqlParameter("@OldHigh", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldLow", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@IsReview", MySqlDbType.VarChar,1),
                new MySqlParameter("@ReviewHigh", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReviewLow", MySqlDbType.Decimal,10),
                new MySqlParameter("@IsReferral", MySqlDbType.VarChar,1),
                new MySqlParameter("@ReferralHigh", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReferralLow", MySqlDbType.Decimal,10),
                new MySqlParameter("@CreatedBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime)
            };

            parameters[0].Value = model.IsShowNum;
            parameters[1].Value = model.Unit;
            parameters[2].Value = model.ExceptionCol;
            parameters[3].Value = model.IncludeEqual;
            parameters[4].Value = model.GeneralHigh;
            parameters[5].Value = model.GeneralHighContent;
            parameters[6].Value = model.GeneralHighContent2;
            parameters[7].Value = model.GeneralHighContent3;
            parameters[8].Value = model.GeneralLow;
            parameters[9].Value = model.GeneralLowContent;
            parameters[10].Value = model.GeneralLowContent2;
            parameters[11].Value = model.GeneralLowContent3;
            parameters[12].Value = model.DistiPopType;
            parameters[13].Value = model.DiaHigh;
            parameters[14].Value = model.DiaHighContent;
            parameters[15].Value = model.DiaHighContent2;
            parameters[16].Value = model.DiaHighContent3;
            parameters[17].Value = model.DiaLow;
            parameters[18].Value = model.DiaLowContent;
            parameters[19].Value = model.DiaLowContent2;
            parameters[20].Value = model.DiaLowContent3;
            parameters[21].Value = model.DistiOlder;
            parameters[22].Value = model.OldHigh;
            parameters[23].Value = model.OldHighContent;
            parameters[24].Value = model.OldHighContent2;
            parameters[25].Value = model.OldHighContent3;
            parameters[26].Value = model.OldLow;
            parameters[27].Value = model.OldLowContent;
            parameters[28].Value = model.OldLowContent2;
            parameters[29].Value = model.OldLowContent3;
            parameters[30].Value = model.IsReview;
            parameters[31].Value = model.ReviewHigh;
            parameters[32].Value = model.ReviewLow;
            parameters[33].Value = model.IsReferral;
            parameters[34].Value = model.ReferralHigh;
            parameters[35].Value = model.ReferralLow;
            parameters[36].Value = model.CreatedBy;
            parameters[37].Value = model.CreatedDate;
            parameters[38].Value = model.LastUpDateBy;
            parameters[39].Value = model.LastUpdateDate;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SugarAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_SugarAssessSet SET ");
            strSql.Append("IsShowNum=@IsShowNum,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("ExceptionCol=@ExceptionCol,");
            strSql.Append("IncludeEqual=@IncludeEqual,");
            strSql.Append("GeneralHigh=@GeneralHigh,");
            strSql.Append("GeneralHighContent=@GeneralHighContent,");
            strSql.Append("GeneralHighContent2=@GeneralHighContent2,");
            strSql.Append("GeneralHighContent3=@GeneralHighContent3,");
            strSql.Append("GeneralLow=@GeneralLow,");
            strSql.Append("GeneralLowContent=@GeneralLowContent,");
            strSql.Append("GeneralLowContent2=@GeneralLowContent2,");
            strSql.Append("GeneralLowContent3=@GeneralLowContent3,");
            strSql.Append("DistiPopType=@DistiPopType,");
            strSql.Append("DiaHigh=@DiaHigh,");
            strSql.Append("DiaHighContent=@DiaHighContent,");
            strSql.Append("DiaHighContent2=@DiaHighContent2,");
            strSql.Append("DiaHighContent3=@DiaHighContent3,");
            strSql.Append("DiaLow=@DiaLow,");
            strSql.Append("DiaLowContent=@DiaLowContent,");
            strSql.Append("DiaLowContent2=@DiaLowContent2,");
            strSql.Append("DiaLowContent3=@DiaLowContent3,");
            strSql.Append("DistiOlder=@DistiOlder,");
            strSql.Append("OldHigh=@OldHigh,");
            strSql.Append("OldHighContent=@OldHighContent,");
            strSql.Append("OldHighContent2=@OldHighContent2,");
            strSql.Append("OldHighContent3=@OldHighContent3,");
            strSql.Append("OldLow=@OldLow,");
            strSql.Append("OldLowContent=@OldLowContent,");
            strSql.Append("OldLowContent2=@OldLowContent2,");
            strSql.Append("OldLowContent3=@OldLowContent3,");
            strSql.Append("IsReview=@IsReview,");
            strSql.Append("ReviewHigh=@ReviewHigh,");
            strSql.Append("ReviewLow=@ReviewLow,");
            strSql.Append("IsReferral=@IsReferral,");
            strSql.Append("ReferralHigh=@ReferralHigh,");
            strSql.Append("ReferralLow=@ReferralLow,");
            strSql.Append("LastUpDateBy=@LastUpDateBy,");
            strSql.Append("LastUpdateDate=@LastUpdateDate");
            strSql.Append(" WHERE ID=@ID");

            MySqlParameter[] parameters = {
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@Unit", MySqlDbType.VarChar,10),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@GeneralHigh", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralLow", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@DistiPopType", MySqlDbType.VarChar,1),
                new MySqlParameter("@DiaHigh", MySqlDbType.Decimal,10),
                new MySqlParameter("@DiaHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@DiaHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@DiaHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@DiaLow", MySqlDbType.Decimal,10),
                new MySqlParameter("@DiaLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@DiaLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@DiaLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@DistiOlder", MySqlDbType.VarChar,1),
                new MySqlParameter("@OldHigh", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldLow", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@IsReview", MySqlDbType.VarChar,1),
                new MySqlParameter("@ReviewHigh", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReviewLow", MySqlDbType.Decimal,10),
                new MySqlParameter("@IsReferral", MySqlDbType.VarChar,1),
                new MySqlParameter("@ReferralHigh", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReferralLow", MySqlDbType.Decimal,10),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime),
                new MySqlParameter("@ID", MySqlDbType.Int32,11)
            };

            parameters[0].Value = model.IsShowNum;
            parameters[1].Value = model.Unit;
            parameters[2].Value = model.ExceptionCol;
            parameters[3].Value = model.IncludeEqual;
            parameters[4].Value = model.GeneralHigh;
            parameters[5].Value = model.GeneralHighContent;
            parameters[6].Value = model.GeneralHighContent2;
            parameters[7].Value = model.GeneralHighContent3;
            parameters[8].Value = model.GeneralLow;
            parameters[9].Value = model.GeneralLowContent;
            parameters[10].Value = model.GeneralLowContent2;
            parameters[11].Value = model.GeneralLowContent3;
            parameters[12].Value = model.DistiPopType;
            parameters[13].Value = model.DiaHigh;
            parameters[14].Value = model.DiaHighContent;
            parameters[15].Value = model.DiaHighContent2;
            parameters[16].Value = model.DiaHighContent3;
            parameters[17].Value = model.DiaLow;
            parameters[18].Value = model.DiaLowContent;
            parameters[19].Value = model.DiaLowContent2;
            parameters[20].Value = model.DiaLowContent3;
            parameters[21].Value = model.DistiOlder;
            parameters[22].Value = model.OldHigh;
            parameters[23].Value = model.OldHighContent;
            parameters[24].Value = model.OldHighContent2;
            parameters[25].Value = model.OldHighContent3;
            parameters[26].Value = model.OldLow;
            parameters[27].Value = model.OldLowContent;
            parameters[28].Value = model.OldLowContent2;
            parameters[29].Value = model.OldLowContent3;
            parameters[30].Value = model.IsReview;
            parameters[31].Value = model.ReviewHigh;
            parameters[32].Value = model.ReviewLow;
            parameters[33].Value = model.IsReferral;
            parameters[34].Value = model.ReferralHigh;
            parameters[35].Value = model.ReferralLow;
            parameters[36].Value = model.LastUpDateBy;
            parameters[37].Value = model.LastUpdateDate;
            parameters[38].Value = model.ID;

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

            strSql.Append("SELECT * FROM tbl_SugarAssessSet ");

            if (strWHERE.Trim() != "")
            {
                strSql.Append(" WHERE " + strWHERE);
            }

            return MySQLHelper.Query(strSql.ToString());
        }
    }
}
