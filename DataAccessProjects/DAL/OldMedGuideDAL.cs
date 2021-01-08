using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.MySQLHelper;
using System.Data;

namespace KangShuoTech.DataAccessProjects.DAL
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

        public DataSet ExistByWhere(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT ID,IDCardNo,GuideDate,Doctor,IdentifyResult,IdentifyDes,EmotionAdjust,");
            builder.Append(" DietAdjust,LiveAdjust,Sport,Collateral,Attention,OtherGuide,Type");
            builder.Append(" FROM tbl_oldmedguide ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(" WHERE " + strWhere);
            }

            return MySQLHelper.Query(builder.ToString());
        }

        public bool Update(OldMedGuideModel model)
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
            builder.Append(" WHERE ID=@ID");

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
                new MySqlParameter("@ID",MySqlDbType.Int32)
            };

            cmdParms[0].Value = model.IdentifyResult;
            cmdParms[1].Value = model.IdentifyDes;
            cmdParms[2].Value = model.EmotionAdjust;
            cmdParms[3].Value = model.DietAdjust;
            cmdParms[4].Value = model.LiveAdjust;
            cmdParms[5].Value = model.Sport;
            cmdParms[6].Value = model.Collateral;
            cmdParms[7].Value = model.Attention;
            cmdParms[8].Value = model.OtherGuide;
            cmdParms[9].Value = model.ID;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
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
