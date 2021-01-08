using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Text;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsSelfcareabilityDAL
    {
        public int Add(RecordsSelfcareabilityModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_RecordsSelfCareAbility(");
            builder.Append("CustomerID,RecordID,IDCardNo,Dine,Groming,Dressing,Tolet,Activity,TotalScore,FollowUpDate,");
            builder.Append("FollowUpDoctor,NextfollowUpDate,CreatedBy,CreatedDate,LastUpDateBy,LastUpDateDate,NextVisitAim ");

            // 判断是否存在OutKey栏位，3.0用OutKey做关联
            string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'tbl_RecordsSelfCareAbility' AND TABLE_SCHEMA='qcpaddb' AND COLUMN_NAME='OutKey'";

            object single = MySQLHelper.GetSingle(table);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0) builder.Append(",OutKey ");

            builder.Append(")");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Dine,@Groming,@Dressing,@Tolet,@Activity,@TotalScore,");
            builder.Append("@FollowUpDate,@FollowUpDoctor,@NextfollowUpDate,@CreatedBy,@CreatedDate,");
            builder.Append("@LastUpDateBy,@LastUpDateDate,@NextVisitAim ");

            // 判断是否存在OutKey栏位，3.0用OutKey做关联
            if (count > 0) builder.Append(",@OutKey ");

            builder.Append(")");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@CustomerID", MySqlDbType.String),
                new MySqlParameter("@RecordID", MySqlDbType.String),
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@Dine", MySqlDbType.Decimal),
                new MySqlParameter("@Groming", MySqlDbType.Decimal),
                new MySqlParameter("@Dressing", MySqlDbType.Decimal),
                new MySqlParameter("@Tolet", MySqlDbType.Decimal),
                new MySqlParameter("@Activity", MySqlDbType.Decimal),
                new MySqlParameter("@TotalScore", MySqlDbType.Decimal),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String),
                new MySqlParameter("@NextfollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpDateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                new MySqlParameter("@NextVisitAim",MySqlDbType.String),
                new MySqlParameter("@OutKey",MySqlDbType.String)
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
            cmdParms[17].Value = model.OutKey;

            single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public bool UpdateByMiniPad(RecordsSelfcareabilityModel model, string RecordDate, string oldSelf)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_RecordsSelfCareAbility Self SET ");
            builder.Append("Dine=@Dine");
            builder.Append(",Groming=@Groming");
            builder.Append(",Dressing=@Dressing");
            builder.Append(",Tolet=@Tolet");
            builder.Append(",Activity=@Activity");
            builder.Append(",TotalScore=@TotalScore ");
            builder.Append(",LastUpDateBy=@LastUpDateBy");
            builder.Append(",LastUpDateDate=@LastUpDateDate");

            // 判断是否存在OutKey栏位，3.0用OutKey做关联
            string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'tbl_RecordsSelfCareAbility' AND TABLE_SCHEMA='qcpaddb' AND COLUMN_NAME='OutKey'";

            object single = MySQLHelper.GetSingle(table);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0) builder.Append(",OutKey=@OutKey ");

            builder.Append(@" WHERE 
                                    EXISTS                                    
                                     (
                                        SELECT 
                                            Self.ID
                                        FROM
                                            tbl_recordscustomerbaseinfo BaseInfo 
                                        INNER JOIN tbl_recordsgeneralcondition G 
                                            ON BaseInfo.ID = G.OutKey
                                        WHERE Self.ID= G.SelfID
                                            AND BaseInfo.IDCardNo = @IDCardNo
                                            AND BaseInfo.CheckDate = @CheckDate
                                    );
                                    UPDATE tbl_recordsgeneralcondition G SET 
                                        OldSelfCareability =@OldSelfCareability
                                    WHERE EXISTS
                                    (
                                        SELECT 
                                            G.SelfID 
                                        FROM
                                            tbl_recordscustomerbaseinfo BaseInfo 
                                        INNER JOIN tbl_RecordsSelfCareAbility med 
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
                new MySqlParameter("@LastUpDateDate", model.LastUpDateDate),
                new MySqlParameter("@OutKey", model.OutKey)
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateGeneral(string IDCardNo, string RecordDate, int ID, string oldSelf)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_recordsgeneralcondition D SET ");
            builder.Append("SelfID=@SelfID ");
            builder.Append(",OldSelfCareability=@OldSelfCareability ");
            builder.Append(@" WHERE EXISTS
                                    (  
                                        SELECT 
                                             M.ID 
                                         FROM  tbl_recordscustomerbaseinfo M 
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

        public DataSet GetModel(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT* FROM tbl_RecordsSelfCareAbility ");
            builder.Append(" WHERE OutKey=@OutKey ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@OutKey", MySqlDbType.Int32)
            };
            cmdParms[0].Value = OutKey;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }
    }
}
