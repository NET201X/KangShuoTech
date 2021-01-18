namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class OlderSelfCareabilityDAL
    {
        public int Add(OlderSelfCareabilityModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("INSERT INTO OLDER_SELFCAREABILITY(");
            builder.Append("CustomerID,RecordID,IDCardNo,Dine,Groming,Dressing,Tolet,Activity,TotalScore,FollowUpDate,");
            builder.Append("FollowUpDoctor,NextfollowUpDate,CreatedBy,CreatedDate,LastUpDateBy,LastUpDateDate,NextVisitAim)");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Dine,@Groming,@Dressing,@Tolet,@Activity,@TotalScore,");
            builder.Append("@FollowUpDate,@FollowUpDoctor,@NextfollowUpDate,@CreatedBy,@CreatedDate,");
            builder.Append("@LastUpDateBy,@LastUpDateDate,@NextVisitAim) ");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 0x12),
                new MySqlParameter("@RecordID", MySqlDbType.String, 0x11),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Dine", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Groming", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Dressing", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Tolet", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Activity", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@TotalScore", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@NextfollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                //新增字段
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

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from OLDER_SELFCAREABILITY ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        
        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from OLDER_SELFCAREABILITY");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet CheckModel(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Dine,Groming,Dressing,Tolet,");
            builder.Append("Activity,TotalScore,FollowUpDate,FollowUpDoctor,NextfollowUpDate,CreatedBy,CreatedDate,");
            builder.Append("LastUpDateBy,LastUpDateDate,NextVisitAim from OLDER_SELFCAREABILITY ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append("where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());

        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,Dine,Groming,Dressing,Tolet,");
            builder.Append("Activity,TotalScore,FollowUpDate,FollowUpDoctor,NextfollowUpDate,CreatedBy,");
            builder.Append("CreatedDate,LastUpDateBy,LastUpDateDate,NextVisitAim ");
            builder.Append(" FROM OLDER_SELFCAREABILITY ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            //builder.Append(" order by FollowUpDate limit 0,1");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select C.IDCardNo,C.ID,T.RecordID,T.CustomerName,T.Nation,T.Sex,T.Birthday,T.Phone,");
            builder.Append("T.Doctor,T.Address,T.HouseHoldAddress,T.Minority,");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate, ");
            builder.Append("(case C.FollowUpDate when null then null when '' then null else C.FollowUpDate end)FollowUpDate , ");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName ");
            builder.Append(" from OLDER_SELFCAREABILITY C inner join ARCHIVE_BASEINFO T on T.IDCardNo = C.IDCardNo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by " + orderby);
            }
            else
            {
                builder.Append(" order by FollowUpDate desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }
        
        public DataSet GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Dine,Groming,Dressing,Tolet,");
            builder.Append("Activity,TotalScore,FollowUpDate,FollowUpDoctor,NextfollowUpDate,CreatedBy,CreatedDate,");
            builder.Append("LastUpDateBy,LastUpDateDate,NextVisitAim from OLDER_SELFCAREABILITY ");
            builder.Append(" where IDCardNo=@IDCardNo order by FollowUpDate desc limit 0,1 ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            return MySQLHelper.Query(builder.ToString(), cmdParms);

        }

        public DataSet GetModelID(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Dine,Groming,Dressing,Tolet,Activity,");
            builder.Append("TotalScore,FollowUpDate,FollowUpDoctor,NextfollowUpDate,CreatedBy,CreatedDate,LastUpDateBy,");
            builder.Append("LastUpDateDate,NextVisitAim from OLDER_SELFCAREABILITY ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 8) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Query(builder.ToString(), cmdParms);

        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM OLDER_SELFCAREABILITY C ");
            builder.Append("left join ARCHIVE_BASEINFO T on T.IDCardNo = C.IDCardNo   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(OlderSelfCareabilityModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update OLDER_SELFCAREABILITY set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Dine=@Dine,");
            builder.Append("Groming=@Groming,");
            builder.Append("Dressing=@Dressing,");
            builder.Append("Tolet=@Tolet,");
            builder.Append("Activity=@Activity,");
            builder.Append("TotalScore=@TotalScore,");
            builder.Append("FollowUpDate=@FollowUpDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("NextfollowUpDate=@NextfollowUpDate,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpDateBy=@LastUpDateBy,");
            builder.Append("LastUpDateDate=@LastUpDateDate,");
            //新增字段
            builder.Append("NextVisitAim=@NextVisitAim ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 0x12),
                new MySqlParameter("@RecordID", MySqlDbType.String, 0x11),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Dine", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Groming", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Dressing", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Tolet", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Activity", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@TotalScore", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@NextfollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date), 
                //新增字段
                new MySqlParameter("@NextVisitAim", MySqlDbType.String, 100),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
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
            cmdParms[17].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
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
    }
}

