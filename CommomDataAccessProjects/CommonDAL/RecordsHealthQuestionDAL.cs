using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsHealthQuestionDAL
    {
        public int Add(RecordsHealthQuestionModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_recordshealthquestion(");
            builder.Append("PhysicalID,IDCardNo,BrainDis,RenalDis,HeartDis,VesselDis,EyeDis,NerveDis,ElseDis,BrainOther,RenalOther,HeartOther,VesselOther,EyeOther,NerveOther,ElseOther,OutKey )");
            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@IDCardNo,@BrainDis,@RenalDis,@HeartDis,@VesselDis,@EyeDis,@NerveDis,@ElseDis,@BrainOther,@RenalOther,@HeartOther,@VesselOther,@EyeOther,@NerveOther,@ElseOther,@OutKey )");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@BrainDis", MySqlDbType.String, 30),
                new MySqlParameter("@RenalDis", MySqlDbType.String, 30),
                new MySqlParameter("@HeartDis", MySqlDbType.String, 30),
                new MySqlParameter("@VesselDis", MySqlDbType.String, 20),
                new MySqlParameter("@EyeDis", MySqlDbType.String, 20),
                new MySqlParameter("@NerveDis", MySqlDbType.String, 100),
                new MySqlParameter("@ElseDis", MySqlDbType.String, 100),
                new MySqlParameter("@BrainOther", MySqlDbType.String, 500),
                new MySqlParameter("@RenalOther", MySqlDbType.String, 500),
                new MySqlParameter("@HeartOther", MySqlDbType.String, 500),
                new MySqlParameter("@VesselOther", MySqlDbType.String, 500),
                new MySqlParameter("@EyeOther", MySqlDbType.String, 500),
                new MySqlParameter("@NerveOther", MySqlDbType.String, 500),
                new MySqlParameter("@ElseOther", MySqlDbType.String, 500),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.BrainDis;
            cmdParms[3].Value = model.RenalDis;
            cmdParms[4].Value = model.HeartDis;
            cmdParms[5].Value = model.VesselDis;
            cmdParms[6].Value = model.EyeDis;
            cmdParms[7].Value = model.NerveDis;
            cmdParms[8].Value = model.ElseDis;
            cmdParms[9].Value = model.BrainOther;
            cmdParms[10].Value = model.RenalOther;
            cmdParms[11].Value = model.HeartOther;
            cmdParms[12].Value = model.VesselOther;
            cmdParms[13].Value = model.EyeOther;
            cmdParms[14].Value = model.NerveOther;
            cmdParms[15].Value = model.ElseOther;
            cmdParms[16].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public DataSet GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_recordshealthquestion ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }

        public bool Update(RecordsHealthQuestionModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_recordshealthquestion SET ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("BrainDis=@BrainDis,");
            builder.Append("RenalDis=@RenalDis,");
            builder.Append("HeartDis=@HeartDis,");
            builder.Append("VesselDis=@VesselDis,");
            builder.Append("EyeDis=@EyeDis,");
            builder.Append("NerveDis=@NerveDis,");
            builder.Append("ElseDis=@ElseDis,");
            builder.Append("BrainOther=@BrainOther,");
            builder.Append("RenalOther=@RenalOther,");
            builder.Append("HeartOther=@HeartOther,");
            builder.Append("VesselOther=@VesselOther,");
            builder.Append("EyeOther=@EyeOther,");
            builder.Append("NerveOther=@NerveOther,");
            builder.Append("ElseOther=@ElseOther");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@BrainDis", MySqlDbType.String, 30),
                new MySqlParameter("@RenalDis", MySqlDbType.String, 30),
                new MySqlParameter("@HeartDis", MySqlDbType.String, 30),
                new MySqlParameter("@VesselDis", MySqlDbType.String, 20),
                new MySqlParameter("@EyeDis", MySqlDbType.String, 20),
                new MySqlParameter("@NerveDis", MySqlDbType.String, 1),
                new MySqlParameter("@ElseDis", MySqlDbType.String, 1),
                new MySqlParameter("@BrainOther", MySqlDbType.String, 500),
                new MySqlParameter("@RenalOther", MySqlDbType.String, 500),
                new MySqlParameter("@HeartOther", MySqlDbType.String, 500),
                new MySqlParameter("@VesselOther", MySqlDbType.String, 500),
                new MySqlParameter("@EyeOther", MySqlDbType.String, 500),
                new MySqlParameter("@NerveOther", MySqlDbType.String, 500),
                new MySqlParameter("@ElseOther", MySqlDbType.String, 500),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8)
            };

            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.BrainDis;
            cmdParms[3].Value = model.RenalDis;
            cmdParms[4].Value = model.HeartDis;
            cmdParms[5].Value = model.VesselDis;
            cmdParms[6].Value = model.EyeDis;
            cmdParms[7].Value = model.NerveDis;
            cmdParms[8].Value = model.ElseDis;
            cmdParms[9].Value = model.BrainOther;
            cmdParms[10].Value = model.RenalOther;
            cmdParms[11].Value = model.HeartOther;
            cmdParms[12].Value = model.VesselOther;
            cmdParms[13].Value = model.EyeOther;
            cmdParms[14].Value = model.NerveOther;
            cmdParms[15].Value = model.ElseOther;
            cmdParms[16].Value = model.OutKey;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 其他系统疾病的更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="outKey"></param>
        /// <returns></returns>
        public bool UpdateOtherDis(RecordsHealthQuestionModel model, string outKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                    tbl_RecordsHealthQuestion
                             SET 
                                    ElseDis=@ElseDis
                                    ,ElseOther=@ElseOther
                             WHERE
                                    OutKey = @OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@OutKey",outKey),
                new MySqlParameter("@ElseDis",model.ElseDis),
                new MySqlParameter("@ElseOther",model.ElseOther),
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
