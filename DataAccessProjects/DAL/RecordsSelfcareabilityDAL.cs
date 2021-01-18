using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.Utilities.MySQLHelper;
using MySql.Data.MySqlClient;
using System.Data;
using KangShuoTech.DataAccessProjects.Model;


namespace KangShuoTech.DataAccessProjects.DAL
{
    public class RecordsSelfcareabilityDAL
    {
        public int Add(RecordsSelfcareabilityModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_SELFCAREABILITY(");
            builder.Append("CustomerID,RecordID,IDCardNo,Dine,Groming,Dressing,Tolet,Activity,TotalScore,FollowUpDate,");
            builder.Append("FollowUpDoctor,NextfollowUpDate,CreatedBy,CreatedDate,LastUpDateBy,LastUpDateDate,NextVisitAim)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Dine,@Groming,@Dressing,@Tolet,@Activity,@TotalScore,");
            builder.Append("@FollowUpDate,@FollowUpDoctor,@NextfollowUpDate,@CreatedBy,@CreatedDate,");
            builder.Append("@LastUpDateBy,@LastUpDateDate,@NextVisitAim) ");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 100),
                new MySqlParameter("@RecordID", MySqlDbType.String, 50),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Dine", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Groming", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Dressing", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Tolet", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@Activity", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@TotalScore", MySqlDbType.Decimal, 0x7fffffff),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 100),
                new MySqlParameter("@NextfollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                new MySqlParameter("@NextVisitAim",MySqlDbType.String,100)
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
            cmdParms[16].Value = model.NextVisitAim;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_SELFCAREABILITY ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_SELFCAREABILITY ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_SELFCAREABILITY");
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
            builder.Append("LastUpDateBy,LastUpDateDate,NextVisitAim from ARCHIVE_SELFCAREABILITY ");
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
            builder.Append(" FROM ARCHIVE_SELFCAREABILITY ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by FollowUpDate limit 0,1");
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
            builder.Append(" from ARCHIVE_SELFCAREABILITY C inner join ARCHIVE_BASEINFO T on T.IDCardNo = C.IDCardNo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by FollowUpDate desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "ARCHIVE_SELFCAREABILITY");
        }

        public DataSet GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Dine,Groming,Dressing,Tolet,");
            builder.Append("Activity,TotalScore,FollowUpDate,FollowUpDoctor,NextfollowUpDate,CreatedBy,CreatedDate,");
            builder.Append("LastUpDateBy,LastUpDateDate,NextVisitAim from ARCHIVE_SELFCAREABILITY ");
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
            builder.Append("LastUpDateDate,NextVisitAim from ARCHIVE_SELFCAREABILITY ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 8) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Query(builder.ToString(), cmdParms);

        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM ARCHIVE_SELFCAREABILITY C ");
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

        public bool Update(RecordsSelfcareabilityModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_SELFCAREABILITY set ");
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
            builder.Append("NextVisitAim=@NextVisitAim");
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
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                new MySqlParameter("@NextVisitAim",MySqlDbType.String,100),
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
            cmdParms[16].Value = model.NextVisitAim;
            cmdParms[17].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateByMiniPad(RecordsSelfcareabilityModel model, string RecordDate, string oldSelf)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ARCHIVE_SELFCAREABILITY Self SET ");
            builder.Append("Dine=@Dine");
            builder.Append(",Groming=@Groming");
            builder.Append(",Dressing=@Dressing");
            builder.Append(",Tolet=@Tolet");
            builder.Append(",Activity=@Activity");
            builder.Append(",TotalScore=@TotalScore ");
            builder.Append(",LastUpDateBy=@LastUpDateBy");
            builder.Append(",LastUpDateDate=@LastUpDateDate");
            builder.Append(@" WHERE 
                                    EXISTS                                    
                                     (
                                        SELECT 
                                            Self.ID
                                        FROM
                                            ARCHIVE_CUSTOMERBASEINFO BaseInfo 
                                        INNER JOIN ARCHIVE_GENERALCONDITION G 
                                            ON BaseInfo.ID = G.OutKey
                                        WHERE Self.ID= G.SelfID
                                            AND BaseInfo.IDCardNo = @IDCardNo
                                            AND BaseInfo.CheckDate = @CheckDate
                                    );
                                    UPDATE ARCHIVE_GENERALCONDITION G SET 
                                        OldSelfCareability =@OldSelfCareability
                                    WHERE EXISTS
                                    (
                                        SELECT 
                                            G.SelfID 
                                        FROM
                                            ARCHIVE_CUSTOMERBASEINFO BaseInfo 
                                        INNER JOIN ARCHIVE_SELFCAREABILITY med 
                                            ON BaseInfo.IDCardNo = med.IDCardNo
                                        WHERE G.SelfID= med.ID
                                            AND BaseInfo.IDCardNo = @IDCardNo
                                            AND BaseInfo.CheckDate = @CheckDate
                                    );");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@Dine", model.Dine),
                new MySqlParameter("@Groming", model.Groming),
                new MySqlParameter("@Dressing", model.Dressing),
                new MySqlParameter("@Tolet", model.Tolet),
                new MySqlParameter("@Activity", model.Activity),
                new MySqlParameter("@TotalScore", model.TotalScore),
                new MySqlParameter("@CheckDate", RecordDate),
                new MySqlParameter("@OldSelfCareability", oldSelf),
                new MySqlParameter("@LastUpDateBy", model.LastUpDateBy),
                new MySqlParameter("@LastUpDateDate", model.LastUpDateDate)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool ExistData(string IDCardNo, string RecordDate) //测试pad中当天是不是有这笔数据
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_GENERALCONDITION G inner join  ARCHIVE_CUSTOMERBASEINFO M on M.ID = G.OutKey ");
            builder.Append(" where M.IDCardNo = @IDCardNo AND M.CheckDate = @CheckDate ");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", IDCardNo) ,
                new MySqlParameter("@CheckDate", RecordDate)
            };
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public bool UpdateGeneral(string IDCardNo, string RecordDate, int ID, string oldSelf)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ARCHIVE_GENERALCONDITION D SET ");
            builder.Append("SelfID=@SelfID ");
            builder.Append(",OldSelfCareability=@OldSelfCareability ");
            builder.Append(@" WHERE EXISTS
                                    (  
                                        SELECT 
                                             M.ID 
                                         FROM  ARCHIVE_CUSTOMERBASEINFO M 
                                         WHERE M.ID = D.OutKey
                                             AND M.IDCardNo = @IDCardNo
                                             AND M.CheckDate = @CheckDate
                                   )  ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", IDCardNo),
                new MySqlParameter("@CheckDate", RecordDate),
                new MySqlParameter("@SelfID", ID),
                new MySqlParameter("OldSelfCareability", oldSelf)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
