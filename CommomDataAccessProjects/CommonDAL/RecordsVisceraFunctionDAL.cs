namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using MySql.Data.MySqlClient;
    using KangShuoTech.CommomDataAccessProjects.CommonModel;
    using CommonUtilities.SQL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class RecordsVisceraFunctionDAL
    {
        public int Add(RecordsVisceraFunctionModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_VISCERAFUNCTION(");
            builder.Append("PhysicalID,IDCardNo,Lips,ToothResides,ToothResidesOther,Pharyngeal,LeftView,Listen,RightView,SportFunction,LeftEyecorrect,");
            builder.Append("RightEyecorrect,OutKey,HypodontiaEx,SaprodontiaEx,DentureEx, LipsEx,PharyngealEx,LeftViewEx,RightViewEx,LeftEye,RightEye)");
            builder.Append(" VALUES (");
            builder.Append("@PhysicalID,@IDCardNo,@Lips,@ToothResides,@ToothResidesOther,@Pharyngeal,@LeftView,@Listen,@RightView,@SportFunction,@LeftEyecorrect,");
            builder.Append("@RightEyecorrect,@OutKey,@HypodontiaEx,@SaprodontiaEx,@DentureEx, @LipsEx,@PharyngealEx,@LeftViewEx,@RightViewEx,@LeftEye,@RightEye)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 100),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Lips", MySqlDbType.String, 1),
                new MySqlParameter("@ToothResides", MySqlDbType.String, 100),
                 new MySqlParameter("@ToothResidesOther", MySqlDbType.String, 200),
                new MySqlParameter("@Pharyngeal", MySqlDbType.String, 1),
                new MySqlParameter("@LeftView", MySqlDbType.Decimal),
                new MySqlParameter("@Listen", MySqlDbType.String, 1),
                new MySqlParameter("@RightView", MySqlDbType.Decimal),
                new MySqlParameter("@SportFunction", MySqlDbType.String, 1),
                new MySqlParameter("@LeftEyecorrect", MySqlDbType.Decimal),
                new MySqlParameter("@RightEyecorrect", MySqlDbType.Decimal),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,11),
                new MySqlParameter("@HypodontiaEx", MySqlDbType.String, 100),
                new MySqlParameter("@SaprodontiaEx", MySqlDbType.String, 100),
                new MySqlParameter("@DentureEx", MySqlDbType.String, 100),
                new MySqlParameter("@LipsEx", MySqlDbType.String, 100),
                new MySqlParameter("@PharyngealEx", MySqlDbType.String, 100),
                new MySqlParameter("@LeftViewEx", MySqlDbType.String, 100),
                new MySqlParameter("@RightViewEx", MySqlDbType.String, 100),
                new MySqlParameter("@LeftEye", MySqlDbType.String, 10),
                new MySqlParameter("@RightEye", MySqlDbType.String, 10)
            };

            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Lips;
            cmdParms[3].Value = model.ToothResides;
            cmdParms[4].Value = model.ToothResidesOther;
            cmdParms[5].Value = model.Pharyngeal;
            cmdParms[6].Value = model.LeftView;
            cmdParms[7].Value = model.Listen;
            cmdParms[8].Value = model.RightView;
            cmdParms[9].Value = model.SportFunction;
            cmdParms[10].Value = model.LeftEyecorrect;
            cmdParms[11].Value = model.RightEyecorrect;
            cmdParms[12].Value = model.OutKey;
            cmdParms[13].Value = model.HypodontiaEx;
            cmdParms[14].Value = model.SaprodontiaEx;
            cmdParms[15].Value = model.DentureEx;
            cmdParms[16].Value = model.LipsEx;
            cmdParms[17].Value = model.PharyngealEx;
            cmdParms[18].Value = model.LeftViewEx;
            cmdParms[19].Value = model.RightViewEx;
            cmdParms[20].Value = model.LeftEye;
            cmdParms[21].Value = model.RightEye;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_VISCERAFUNCTION ");
            builder.Append(" WHERE OutKey=@OutKey");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public bool UpdateVsiual(RecordsVisceraFunctionModel model)
        {
            StringBuilder builder = new StringBuilder();

            List<MySqlParameter> ilistStr = new List<MySqlParameter>();
            MySqlParameter[] cmdParms = new MySqlParameter[] { };

            builder.Append(@"UPDATE ARCHIVE_VISCERAFUNCTION SET 
                                     IDCardNo=IDCardNo  ");

            if (model.LeftView.HasValue)
            {
                builder.Append(",LeftView=@LeftView");
                ilistStr.Add(new MySqlParameter("@LeftView", model.LeftView));
            }
            if (model.LeftEyecorrect.HasValue)
            {
                builder.Append(",LeftEyecorrect=@LeftEyecorrect");
                ilistStr.Add(new MySqlParameter("@LeftEyecorrect", model.LeftEyecorrect));
            }
            if (model.RightView.HasValue)
            {
                builder.Append(",RightView=@RightView");
                ilistStr.Add(new MySqlParameter("@RightView", model.RightView));
            }
            if (model.RightEyecorrect.HasValue)
            {
                builder.Append(",RightEyecorrect=@RightEyecorrect");
                ilistStr.Add(new MySqlParameter("@RightEyecorrect", model.RightEyecorrect));
            }

            builder.Append(" WHERE IDCardNo = @IDCardNo AND OutKey = @OutKey");

            ilistStr.Add(new MySqlParameter("@IDCardNo", model.IDCardNo));
            ilistStr.Add(new MySqlParameter("@OutKey", model.OutKey));

            cmdParms = ilistStr.ToArray();

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

