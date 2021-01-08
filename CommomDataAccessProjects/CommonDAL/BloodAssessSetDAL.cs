namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using System.Data;
    using System.Text;
    using CommonUtilities.SQL;
    using MySql.Data.MySqlClient;
    using CommonModel;

    public partial class BloodAssessSetDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BloodAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_BloodAssessSet(");
            strSql.Append("BloodType,IsShowNum,Unit,ExceptionCol,IncludeEqual,GeneralHighMax,GeneralLowMax,GeneralHighContent,GeneralHighContent2,GeneralHighContent3,GeneralHighMin,GeneralLowMin,");
            strSql.Append("GeneralLowContent,GeneralLowContent2,GeneralLowContent3,DistiPopType,HypHighMax,HypLowMax,HypHighContent,HypHighContent2,HypHighContent3,HypHighMin,HypLowMin,HypLowContent,");
            strSql.Append("HypLowContent2,HypLowContent3,DistiOlder,OldHighMax,OldLowMax,OldHighContent,OldHighContent2,OldHighContent3,OldHighMin,OldLowMin,OldLowContent,OldLowContent2,OldLowContent3,");
            strSql.Append("IsReview,ReviewHighMax,ReviewLowMax,ReviewHighMin,ReviewLowMin,IsReferral,ReferralHighMax,ReferralLowMax,ReferralHighMin,ReferralLowMin,CreatedBy,CreatedDate,LastUpDateBy,LastUpdateDate)");
            strSql.Append(" VALUES (");
            strSql.Append("@BloodType,@IsShowNum,@Unit,@ExceptionCol,@IncludeEqual,@GeneralHighMax,@GeneralLowMax,@GeneralHighContent,@GeneralHighContent2,@GeneralHighContent3,@GeneralHighMin,@GeneralLowMin,");
            strSql.Append("@GeneralLowContent,@GeneralLowContent2,@GeneralLowContent3,@DistiPopType,@HypHighMax,@HypLowMax,@HypHighContent,@HypHighContent2,@HypHighContent3,@HypHighMin,@HypLowMin,@HypLowContent,");
            strSql.Append("@HypLowContent2,@HypLowContent3,@DistiOlder,@OldHighMax,@OldLowMax,@OldHighContent,@OldHighContent2,@OldHighContent3,@OldHighMin,@OldLowMin,@OldLowContent,@OldLowContent2,@OldLowContent3,");
            strSql.Append("@IsReview,@ReviewHighMax,@ReviewLowMax,@ReviewHighMin,@ReviewLowMin,@IsReferral,@ReferralHighMax,@ReferralLowMax,@ReferralHighMin,@ReferralLowMin,@CreatedBy,@CreatedDate,@LastUpDateBy,@LastUpdateDate)");

            MySqlParameter[] parameters = {
                new MySqlParameter("@BloodType", MySqlDbType.VarChar,1),
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@Unit", MySqlDbType.VarChar,10),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@GeneralHighMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralLowMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralHighMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralLowMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@DistiPopType", MySqlDbType.VarChar,1),
                new MySqlParameter("@HypHighMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@HypLowMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@HypHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@HypHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@HypHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@HypHighMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@HypLowMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@HypLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@HypLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@HypLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@DistiOlder", MySqlDbType.VarChar,1),
                new MySqlParameter("@OldHighMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldLowMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldHighMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldLowMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@IsReview", MySqlDbType.VarChar,1),
                new MySqlParameter("@ReviewHighMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReviewLowMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReviewHighMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReviewLowMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@IsReferral", MySqlDbType.VarChar,1),
                new MySqlParameter("@ReferralHighMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReferralLowMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReferralHighMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReferralLowMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@CreatedBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime)
            };

            parameters[0].Value = model.BloodType;
            parameters[1].Value = model.IsShowNum;
            parameters[2].Value = model.Unit;
            parameters[3].Value = model.ExceptionCol;
            parameters[4].Value = model.IncludeEqual;
            parameters[5].Value = model.GeneralHighMax;
            parameters[6].Value = model.GeneralLowMax;
            parameters[7].Value = model.GeneralHighContent;
            parameters[8].Value = model.GeneralHighContent2;
            parameters[9].Value = model.GeneralHighContent3;
            parameters[10].Value = model.GeneralHighMin;
            parameters[11].Value = model.GeneralLowMin;
            parameters[12].Value = model.GeneralLowContent;
            parameters[13].Value = model.GeneralLowContent2;
            parameters[14].Value = model.GeneralLowContent3;
            parameters[15].Value = model.DistiPopType;
            parameters[16].Value = model.HypHighMax;
            parameters[17].Value = model.HypLowMax;
            parameters[18].Value = model.HypHighContent;
            parameters[19].Value = model.HypHighContent2;
            parameters[20].Value = model.HypHighContent3;
            parameters[21].Value = model.HypHighMin;
            parameters[22].Value = model.HypLowMin;
            parameters[23].Value = model.HypLowContent;
            parameters[24].Value = model.HypLowContent2;
            parameters[25].Value = model.HypLowContent3;
            parameters[26].Value = model.DistiOlder;
            parameters[27].Value = model.OldHighMax;
            parameters[28].Value = model.OldLowMax;
            parameters[29].Value = model.OldHighContent;
            parameters[30].Value = model.OldHighContent2;
            parameters[31].Value = model.OldHighContent3;
            parameters[32].Value = model.OldHighMin;
            parameters[33].Value = model.OldLowMin;
            parameters[34].Value = model.OldLowContent;
            parameters[35].Value = model.OldLowContent2;
            parameters[36].Value = model.OldLowContent3;
            parameters[37].Value = model.IsReview;
            parameters[38].Value = model.ReviewHighMax;
            parameters[39].Value = model.ReviewLowMax;
            parameters[40].Value = model.ReviewHighMin;
            parameters[41].Value = model.ReviewLowMin;
            parameters[42].Value = model.IsReferral;
            parameters[43].Value = model.ReferralHighMax;
            parameters[44].Value = model.ReferralLowMax;
            parameters[45].Value = model.ReferralHighMin;
            parameters[46].Value = model.ReferralLowMin;
            parameters[47].Value = model.CreatedBy;
            parameters[48].Value = model.CreatedDate;
            parameters[49].Value = model.LastUpDateBy;
            parameters[50].Value = model.LastUpdateDate;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BloodAssessSetModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_BloodAssessSet SET ");
            strSql.Append("BloodType=@BloodType,");
            strSql.Append("IsShowNum=@IsShowNum,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("ExceptionCol=@ExceptionCol,");
            strSql.Append("IncludeEqual=@IncludeEqual,");
            strSql.Append("GeneralHighMax=@GeneralHighMax,");
            strSql.Append("GeneralLowMax=@GeneralLowMax,");
            strSql.Append("GeneralHighContent=@GeneralHighContent,");
            strSql.Append("GeneralHighContent2=@GeneralHighContent2,");
            strSql.Append("GeneralHighContent3=@GeneralHighContent3,");
            strSql.Append("GeneralHighMin=@GeneralHighMin,");
            strSql.Append("GeneralLowMin=@GeneralLowMin,");
            strSql.Append("GeneralLowContent=@GeneralLowContent,");
            strSql.Append("GeneralLowContent2=@GeneralLowContent2,");
            strSql.Append("GeneralLowContent3=@GeneralLowContent3,");
            strSql.Append("DistiPopType=@DistiPopType,");
            strSql.Append("HypHighMax=@HypHighMax,");
            strSql.Append("HypLowMax=@HypLowMax,");
            strSql.Append("HypHighContent=@HypHighContent,");
            strSql.Append("HypHighContent2=@HypHighContent2,");
            strSql.Append("HypHighContent3=@HypHighContent3,");
            strSql.Append("HypHighMin=@HypHighMin,");
            strSql.Append("HypLowMin=@HypLowMin,");
            strSql.Append("HypLowContent=@HypLowContent,");
            strSql.Append("HypLowContent2=@HypLowContent2,");
            strSql.Append("HypLowContent3=@HypLowContent3,");
            strSql.Append("DistiOlder=@DistiOlder,");
            strSql.Append("OldHighMax=@OldHighMax,");
            strSql.Append("OldLowMax=@OldLowMax,");
            strSql.Append("OldHighContent=@OldHighContent,");
            strSql.Append("OldHighContent2=@OldHighContent2,");
            strSql.Append("OldHighContent3=@OldHighContent3,");
            strSql.Append("OldHighMin=@OldHighMin,");
            strSql.Append("OldLowMin=@OldLowMin,");
            strSql.Append("OldLowContent=@OldLowContent,");
            strSql.Append("OldLowContent2=@OldLowContent2,");
            strSql.Append("OldLowContent3=@OldLowContent3,");
            strSql.Append("IsReview=@IsReview,");
            strSql.Append("ReviewHighMax=@ReviewHighMax,");
            strSql.Append("ReviewLowMax=@ReviewLowMax,");
            strSql.Append("ReviewHighMin=@ReviewHighMin,");
            strSql.Append("ReviewLowMin=@ReviewLowMin,");
            strSql.Append("IsReferral=@IsReferral,");
            strSql.Append("ReferralHighMax=@ReferralHighMax,");
            strSql.Append("ReferralLowMax=@ReferralLowMax,");
            strSql.Append("ReferralHighMin=@ReferralHighMin,");
            strSql.Append("ReferralLowMin=@ReferralLowMin,");
            strSql.Append("LastUpDateBy=@LastUpDateBy,");
            strSql.Append("LastUpdateDate=@LastUpdateDate");
            strSql.Append(" WHERE ID=@ID");

            MySqlParameter[] parameters = {
                new MySqlParameter("@BloodType", MySqlDbType.VarChar,1),
                new MySqlParameter("@IsShowNum", MySqlDbType.VarChar,1),
                new MySqlParameter("@Unit", MySqlDbType.VarChar,10),
                new MySqlParameter("@ExceptionCol", MySqlDbType.VarChar,20),
                new MySqlParameter("@IncludeEqual", MySqlDbType.VarChar,1),
                new MySqlParameter("@GeneralHighMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralLowMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralHighMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralLowMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@GeneralLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@GeneralLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@DistiPopType", MySqlDbType.VarChar,1),
                new MySqlParameter("@HypHighMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@HypLowMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@HypHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@HypHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@HypHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@HypHighMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@HypLowMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@HypLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@HypLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@HypLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@DistiOlder", MySqlDbType.VarChar,1),
                new MySqlParameter("@OldHighMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldLowMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldHighContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldHighContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldHighContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldHighMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldLowMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@OldLowContent", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldLowContent2", MySqlDbType.VarChar,50),
                new MySqlParameter("@OldLowContent3", MySqlDbType.VarChar,50),
                new MySqlParameter("@IsReview", MySqlDbType.VarChar,1),
                new MySqlParameter("@ReviewHighMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReviewLowMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReviewHighMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReviewLowMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@IsReferral", MySqlDbType.VarChar,1),
                new MySqlParameter("@ReferralHighMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReferralLowMax", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReferralHighMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@ReferralLowMin", MySqlDbType.Decimal,10),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.VarChar,100),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.DateTime),
                new MySqlParameter("@ID", MySqlDbType.Int32,11)
            };

            parameters[0].Value = model.BloodType;
            parameters[1].Value = model.IsShowNum;
            parameters[2].Value = model.Unit;
            parameters[3].Value = model.ExceptionCol;
            parameters[4].Value = model.IncludeEqual;
            parameters[5].Value = model.GeneralHighMax;
            parameters[6].Value = model.GeneralLowMax;
            parameters[7].Value = model.GeneralHighContent;
            parameters[8].Value = model.GeneralHighContent2;
            parameters[9].Value = model.GeneralHighContent3;
            parameters[10].Value = model.GeneralHighMin;
            parameters[11].Value = model.GeneralLowMin;
            parameters[12].Value = model.GeneralLowContent;
            parameters[13].Value = model.GeneralLowContent2;
            parameters[14].Value = model.GeneralLowContent3;
            parameters[15].Value = model.DistiPopType;
            parameters[16].Value = model.HypHighMax;
            parameters[17].Value = model.HypLowMax;
            parameters[18].Value = model.HypHighContent;
            parameters[19].Value = model.HypHighContent2;
            parameters[20].Value = model.HypHighContent3;
            parameters[21].Value = model.HypHighMin;
            parameters[22].Value = model.HypLowMin;
            parameters[23].Value = model.HypLowContent;
            parameters[24].Value = model.HypLowContent2;
            parameters[25].Value = model.HypLowContent3;
            parameters[26].Value = model.DistiOlder;
            parameters[27].Value = model.OldHighMax;
            parameters[28].Value = model.OldLowMax;
            parameters[29].Value = model.OldHighContent;
            parameters[30].Value = model.OldHighContent2;
            parameters[31].Value = model.OldHighContent3;
            parameters[32].Value = model.OldHighMin;
            parameters[33].Value = model.OldLowMin;
            parameters[34].Value = model.OldLowContent;
            parameters[35].Value = model.OldLowContent2;
            parameters[36].Value = model.OldLowContent3;
            parameters[37].Value = model.IsReview;
            parameters[38].Value = model.ReviewHighMax;
            parameters[39].Value = model.ReviewLowMax;
            parameters[40].Value = model.ReviewHighMin;
            parameters[41].Value = model.ReviewLowMin;
            parameters[42].Value = model.IsReferral;
            parameters[43].Value = model.ReferralHighMax;
            parameters[44].Value = model.ReferralLowMax;
            parameters[45].Value = model.ReferralHighMin;
            parameters[46].Value = model.ReferralLowMin;
            parameters[47].Value = model.LastUpDateBy;
            parameters[48].Value = model.LastUpdateDate;
            parameters[49].Value = model.ID;

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

            strSql.Append("SELECT * FROM tbl_BloodAssessSet ");

            if (strWHERE.Trim() != "")
            {
                strSql.Append(" WHERE " + strWHERE);
            }

            return MySQLHelper.Query(strSql.ToString());
        }
    }
}

