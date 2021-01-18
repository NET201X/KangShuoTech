using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class OlderSelfCareabilityDAL
    {
        public int Add(OlderSelfCareabilityModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO OLDER_SELFCAREABILITY(");
            builder.Append("CustomerID,RecordID,IDCardNo,Dine,Groming,Dressing,Tolet,Activity,TotalScore,");

            if (VersionNo.Contains("3.0"))
            {
                builder.Append(" VisitDate,VisitDoctor,NextVisitDate,CreatedBy,CreatedDate,LastUpDateBy,LastUpDateDate,NextVisitAim)");
            }
            else
            {
                builder.Append(" FollowUpDate,FollowUpDoctor,NextfollowUpDate,CreatedBy,CreatedDate,LastUpDateBy,LastUpDateDate,NextVisitAim)");
            }

            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Dine,@Groming,@Dressing,@Tolet,@Activity,@TotalScore,");
            builder.Append("@FollowUpDate,@FollowUpDoctor,@NextfollowUpDate,@CreatedBy,@CreatedDate,");
            builder.Append("@LastUpDateBy,@LastUpDateDate,@NextVisitAim) ");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 21),
                new MySqlParameter("@RecordID", MySqlDbType.String, 21),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Dine", MySqlDbType.Decimal),
                new MySqlParameter("@Groming", MySqlDbType.Decimal),
                new MySqlParameter("@Dressing", MySqlDbType.Decimal),
                new MySqlParameter("@Tolet", MySqlDbType.Decimal),
                new MySqlParameter("@Activity", MySqlDbType.Decimal),
                new MySqlParameter("@TotalScore", MySqlDbType.Decimal),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@NextfollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                new MySqlParameter("@NextVisitAim", MySqlDbType.String, 100)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Dine;
            cmdParms[4].Value = model.Groming;
            cmdParms[5].Value = model.Dressing;
            cmdParms[6].Value = model.Tolet;
            cmdParms[7].Value = model.Activity;
            cmdParms[8].Value = model.TotalScore;
            cmdParms[9].Value = model.FollowUpDate;
            cmdParms[10].Value = model.FollowUpDoctor;
            cmdParms[11].Value = model.NextFollowUpDate;
            cmdParms[12].Value = model.CreatedBy;
            cmdParms[13].Value = model.CreatedDate;
            cmdParms[14].Value = model.LastUpDateBy;
            cmdParms[15].Value = model.LastUpDateDate;

            //新增字段
            cmdParms[16].Value = model.NextVisitAim;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 数据同步自理能力存档
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByUpload(OlderSelfCareabilityModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE OLDER_SELFCAREABILITY SET ");
            builder.Append("Dine=@Dine");
            builder.Append(",Groming=@Groming");
            builder.Append(",Dressing=@Dressing");
            builder.Append(",Tolet=@Tolet");
            builder.Append(",Activity=@Activity");
            builder.Append(",TotalScore=@TotalScore");
            builder.Append(",LastUpDateBy=@LastUpDateBy");
            builder.Append(",LastUpDateDate=@LastUpDateDate");
            builder.Append(" WHERE FollowUpDate=@FollowUpDate");
            builder.Append(" AND IDCardNo=@IDCardNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Dine", MySqlDbType.Decimal),
                new MySqlParameter("@Groming", MySqlDbType.Decimal),
                new MySqlParameter("@Dressing", MySqlDbType.Decimal),
                new MySqlParameter("@Tolet", MySqlDbType.Decimal),
                new MySqlParameter("@Activity", MySqlDbType.Decimal),
                new MySqlParameter("@TotalScore", MySqlDbType.Decimal),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date)
            };

            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Dine;
            cmdParms[2].Value = model.Groming;
            cmdParms[3].Value = model.Dressing;
            cmdParms[4].Value = model.Tolet;
            cmdParms[5].Value = model.Activity;
            cmdParms[6].Value = model.TotalScore;
            cmdParms[7].Value = model.FollowUpDate;
            cmdParms[8].Value = model.LastUpDateBy;
            cmdParms[9].Value = model.LastUpDateDate;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet CheckModel(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM OLDER_SELFCAREABILITY ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append("WHERE " + strWhere);
            }

            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetMaxModel(string IDCardNo, string CheckDate, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();
            string column = VersionNo.Contains("3.0") ? "VisitDate" : "FollowupDate";

            builder.Append("SELECT * FROM OLDER_SELFCAREABILITY ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (CheckDate != "")
            {
                if (VersionNo.Contains("3.0")) builder.Append("AND VisitDate=@CheckDate");
                else builder.Append("AND FollowupDate=@CheckDate");
            }

            builder.AppendFormat(" ORDER BY {0} DESC LIMIT 0,1 ", column);

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@CheckDate", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = CheckDate;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 本季度是否有随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(0) FROM OLDER_SELFCAREABILITY ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            if (VersionNo.Contains("3.0")) builder.Append(" AND YEAR(VisitDate)=YEAR(NOW())");
            else builder.Append(" AND YEAR(FollowUpDate)=YEAR(NOW())");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }
    }
}
