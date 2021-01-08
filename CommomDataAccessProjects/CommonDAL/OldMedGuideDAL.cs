using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class OldMedGuideDAL
    {
        public int Add(OldMedGuideModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" INSERT INTO tbl_oldmedguide( ");
            builder.Append(" IDCardNo,GuideDate,Doctor,IdentifyResult,IdentifyDes,EmotionAdjust,DietAdjust,LiveAdjust,Sport,Collateral,Attention,OtherGuide,Type,OutKey) ");
            builder.Append(" VALUES (");
            builder.Append(" @IDCardNo,@GuideDate,@Doctor,@IdentifyResult,@IdentifyDes,@EmotionAdjust,@DietAdjust,@LiveAdjust,@Sport,@Collateral,@Attention,@OtherGuide,@Type,@OutKey) ");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@GuideDate", MySqlDbType.Date),
                new MySqlParameter("@Doctor", MySqlDbType.String, 50),
                new MySqlParameter("@IdentifyResult", MySqlDbType.String, 10),
                new MySqlParameter("@IdentifyDes", MySqlDbType.String, 1000),
                new MySqlParameter("@EmotionAdjust", MySqlDbType.String, 1000),
                new MySqlParameter("@DietAdjust", MySqlDbType.String, 1000),
                new MySqlParameter("@LiveAdjust", MySqlDbType.String, 1000),
                new MySqlParameter("@Sport", MySqlDbType.String, 1000),
                new MySqlParameter("@Collateral", MySqlDbType.String, 1000),
                new MySqlParameter("@Attention", MySqlDbType.String, 1000),
                new MySqlParameter("@OtherGuide", MySqlDbType.String, 1000),
                new MySqlParameter("@Type", MySqlDbType.Int32, 4),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4)
            };

            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.GuideDate;
            cmdParms[2].Value = model.Doctor;
            cmdParms[3].Value = model.IdentifyResult;
            cmdParms[4].Value = model.IdentifyDes;
            cmdParms[5].Value = model.EmotionAdjust;
            cmdParms[6].Value = model.DietAdjust;
            cmdParms[7].Value = model.LiveAdjust;
            cmdParms[8].Value = model.Sport;
            cmdParms[9].Value = model.Collateral;
            cmdParms[10].Value = model.Attention;
            cmdParms[11].Value = model.OtherGuide;
            cmdParms[12].Value = model.Type;
            cmdParms[13].Value = model.OutKey;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 中医体质同步存入指导意见
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByUpload(OldMedGuideModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_oldmedguide SET ");
            builder.Append("Doctor=@Doctor,");
            builder.Append("IdentifyResult=@IdentifyResult,");
            builder.Append("IdentifyDes=@IdentifyDes,");
            builder.Append("EmotionAdjust=@EmotionAdjust,");
            builder.Append("DietAdjust=@DietAdjust,");
            builder.Append("LiveAdjust=@LiveAdjust,");
            builder.Append("Sport=@Sport,");
            builder.Append("Collateral=@Collateral,");
            builder.Append("Attention=@Attention, ");
            builder.Append("OtherGuide=@OtherGuide ");
            builder.Append(" WHERE OutKey=@OutKey");
            builder.Append(" AND Type=@Type");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Doctor", MySqlDbType.String, 50),
                new MySqlParameter("@IdentifyResult", MySqlDbType.String, 10),
                new MySqlParameter("@IdentifyDes", MySqlDbType.String, 1000),
                new MySqlParameter("@EmotionAdjust", MySqlDbType.String, 1000),
                new MySqlParameter("@DietAdjust", MySqlDbType.String, 1000),
                new MySqlParameter("@LiveAdjust", MySqlDbType.String, 1000),
                new MySqlParameter("@Sport", MySqlDbType.String, 1000),
                new MySqlParameter("@Collateral", MySqlDbType.String, 1000),
                new MySqlParameter("@Attention", MySqlDbType.String, 1000),
                new MySqlParameter("@OtherGuide", MySqlDbType.String, 1000),
                new MySqlParameter("@OutKey",MySqlDbType.Int32),
                new MySqlParameter("@Type",MySqlDbType.Int32)
            };

            cmdParms[0].Value = model.Doctor;
            cmdParms[1].Value = model.IdentifyResult;
            cmdParms[2].Value = model.IdentifyDes;
            cmdParms[3].Value = model.EmotionAdjust;
            cmdParms[4].Value = model.DietAdjust;
            cmdParms[5].Value = model.LiveAdjust;
            cmdParms[6].Value = model.Sport;
            cmdParms[7].Value = model.Collateral;
            cmdParms[8].Value = model.Attention;
            cmdParms[9].Value = model.OtherGuide;
            cmdParms[10].Value = model.OutKey;
            cmdParms[11].Value = model.Type;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
