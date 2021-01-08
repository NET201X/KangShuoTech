using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsHealthConditionDAL
    {
        public DataSet GetMaxList(string strWhere, string conn = "")
        {
            StringBuilder builder = new StringBuilder();

            string table = "SELECT COUNT(0) FROM sqlite_master WHERE TYPE='table' AND NAME = 'tbl_RecordsHealthCondition' ";

            object single = YcSqliteHelper.GetSingle(table, conn);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count == 0) return null;

            builder.Append("SELECT * FROM tbl_RecordsHealthCondition ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY IDCardNo,date(RecordDate) ");

            return YcSqliteHelper.Query(builder.ToString(), conn);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(RecordsHealthConditionModel model,string outKey)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tbl_recordshealthcondition(");
            strSql.Append("IDCardNo,FamilyHistory,FamilyHistoryOther,FoodAllergy,OtherAllergy,DrugAllergy,AllergyHistory,HealthStatus,SickStats,HypertensionOld,HypertensionAdvice,HypertensionInterrupt,HypertensionInterruptMonth,DiabetesOld,DiabetesAdvice,DiabetesInterrupt,DiabetesInterruptMonth,CerebralIschemia,CerebralIschemiaSum,CerebralIschemiaStartOld,CerebralIschemiaStartMonth,CerebralIschemiaEndOld,CerebralIschemiaEndMonth,CerebralHemorrhage,CerebralHemorrhageSum,CerebralHemorrhageStartOld,CerebralHemorrhageStartMonth,CerebralHemorrhageEndOld,CerebralHemorrhageEndMonth,CerebralTIA,CerebralTIASum,CerebralTIAStartOld,CerebralTIAStartMonth,CerebralTIAEndOld,CerebralTIAEndMonth,SubarachnoidHemorrhage,MiocardialInfarction,MiocardialInfarctionSum,MiocardialInfarctionStartOld,MiocardialInfarctionStartMonth,MiocardialInfarctionEndOld,MiocardialInfarctionEndMonth,HeartDisease,Kidney,BloodVessel,EyeDiseases,Other,OtherValue,OutKey)");
            strSql.Append(" VALUES (");
            strSql.Append("@IDCardNo,@FamilyHistory,@FamilyHistoryOther,@FoodAllergy,@OtherAllergy,@DrugAllergy,@AllergyHistory,@HealthStatus,@SickStats,@HypertensionOld,@HypertensionAdvice,@HypertensionInterrupt,@HypertensionInterruptMonth,@DiabetesOld,@DiabetesAdvice,@DiabetesInterrupt,@DiabetesInterruptMonth,@CerebralIschemia,@CerebralIschemiaSum,@CerebralIschemiaStartOld,@CerebralIschemiaStartMonth,@CerebralIschemiaEndOld,@CerebralIschemiaEndMonth,@CerebralHemorrhage,@CerebralHemorrhageSum,@CerebralHemorrhageStartOld,@CerebralHemorrhageStartMonth,@CerebralHemorrhageEndOld,@CerebralHemorrhageEndMonth,@CerebralTIA,@CerebralTIASum,@CerebralTIAStartOld,@CerebralTIAStartMonth,@CerebralTIAEndOld,@CerebralTIAEndMonth,@SubarachnoidHemorrhage,@MiocardialInfarction,@MiocardialInfarctionSum,@MiocardialInfarctionStartOld,@MiocardialInfarctionStartMonth,@MiocardialInfarctionEndOld,@MiocardialInfarctionEndMonth,@HeartDisease,@Kidney,@BloodVessel,@EyeDiseases,@Other,@OtherValue,@OutKey)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@OutKey", MySqlDbType.Int32,11),
                    new MySqlParameter("@IDCardNo", MySqlDbType.VarChar,21),
                    new MySqlParameter("@FamilyHistory", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FamilyHistoryOther", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FoodAllergy", MySqlDbType.VarChar,255),
                    new MySqlParameter("@OtherAllergy", MySqlDbType.VarChar,255),
                    new MySqlParameter("@DrugAllergy", MySqlDbType.VarChar,255),
                    new MySqlParameter("@AllergyHistory", MySqlDbType.VarChar,50),
                    new MySqlParameter("@HealthStatus", MySqlDbType.VarChar,50),
                    new MySqlParameter("@SickStats", MySqlDbType.VarChar,1),
                    new MySqlParameter("@HypertensionOld", MySqlDbType.VarChar,50),
                    new MySqlParameter("@HypertensionAdvice", MySqlDbType.VarChar,1),
                    new MySqlParameter("@HypertensionInterrupt", MySqlDbType.VarChar,1),
                    new MySqlParameter("@HypertensionInterruptMonth", MySqlDbType.VarChar,50),
                    new MySqlParameter("@DiabetesOld", MySqlDbType.VarChar,50),
                    new MySqlParameter("@DiabetesAdvice", MySqlDbType.VarChar,1),
                    new MySqlParameter("@DiabetesInterrupt", MySqlDbType.VarChar,1),
                    new MySqlParameter("@DiabetesInterruptMonth", MySqlDbType.VarChar,50),
                    new MySqlParameter("@CerebralIschemia", MySqlDbType.VarChar,1),
                    new MySqlParameter("@CerebralIschemiaSum", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralIschemiaStartOld", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralIschemiaStartMonth", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralIschemiaEndOld", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralIschemiaEndMonth", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralHemorrhage", MySqlDbType.VarChar,1),
                    new MySqlParameter("@CerebralHemorrhageSum", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralHemorrhageStartOld", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralHemorrhageStartMonth", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralHemorrhageEndOld", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralHemorrhageEndMonth", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralTIA", MySqlDbType.VarChar,1),
                    new MySqlParameter("@CerebralTIASum", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralTIAStartOld", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralTIAStartMonth", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralTIAEndOld", MySqlDbType.VarChar,10),
                    new MySqlParameter("@CerebralTIAEndMonth", MySqlDbType.VarChar,10),
                    new MySqlParameter("@SubarachnoidHemorrhage", MySqlDbType.VarChar,10),
                    new MySqlParameter("@MiocardialInfarction", MySqlDbType.VarChar,10),
                    new MySqlParameter("@MiocardialInfarctionSum", MySqlDbType.VarChar,10),
                    new MySqlParameter("@MiocardialInfarctionStartOld", MySqlDbType.VarChar,10),
                    new MySqlParameter("@MiocardialInfarctionStartMonth", MySqlDbType.VarChar,10),
                    new MySqlParameter("@MiocardialInfarctionEndOld", MySqlDbType.VarChar,10),
                    new MySqlParameter("@MiocardialInfarctionEndMonth", MySqlDbType.VarChar,10),
                    new MySqlParameter("@HeartDisease", MySqlDbType.VarChar,10),
                    new MySqlParameter("@Kidney", MySqlDbType.VarChar,50),
                    new MySqlParameter("@BloodVessel", MySqlDbType.VarChar,50),
                    new MySqlParameter("@EyeDiseases", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Other", MySqlDbType.VarChar,50),
                    new MySqlParameter("@OtherValue", MySqlDbType.VarChar,50)};

            parameters[0].Value = outKey;
            parameters[1].Value = model.IDCardNo;
            parameters[2].Value = model.FamilyHistory;
            parameters[3].Value = model.FamilyHistoryOther;
            parameters[4].Value = model.FoodAllergy;
            parameters[5].Value = model.OtherAllergy;
            parameters[6].Value = model.DrugAllergy;
            parameters[7].Value = model.AllergyHistory;
            parameters[8].Value = model.HealthStatus;
            parameters[9].Value = model.SickStats;
            parameters[10].Value = model.HypertensionOld;
            parameters[11].Value = model.HypertensionAdvice;
            parameters[12].Value = model.HypertensionInterrupt;
            parameters[13].Value = model.HypertensionInterruptMonth;
            parameters[14].Value = model.DiabetesOld;
            parameters[15].Value = model.DiabetesAdvice;
            parameters[16].Value = model.DiabetesInterrupt;
            parameters[17].Value = model.DiabetesInterruptMonth;
            parameters[18].Value = model.CerebralIschemia;
            parameters[19].Value = model.CerebralIschemiaSum;
            parameters[20].Value = model.CerebralIschemiaStartOld;
            parameters[21].Value = model.CerebralIschemiaStartMonth;
            parameters[22].Value = model.CerebralIschemiaEndOld;
            parameters[23].Value = model.CerebralIschemiaEndMonth;
            parameters[24].Value = model.CerebralHemorrhage;
            parameters[25].Value = model.CerebralHemorrhageSum;
            parameters[26].Value = model.CerebralHemorrhageStartOld;
            parameters[27].Value = model.CerebralHemorrhageStartMonth;
            parameters[28].Value = model.CerebralHemorrhageEndOld;
            parameters[29].Value = model.CerebralHemorrhageEndMonth;
            parameters[30].Value = model.CerebralTIA;
            parameters[31].Value = model.CerebralTIASum;
            parameters[32].Value = model.CerebralTIAStartOld;
            parameters[33].Value = model.CerebralTIAStartMonth;
            parameters[34].Value = model.CerebralTIAEndOld;
            parameters[35].Value = model.CerebralTIAEndMonth;
            parameters[36].Value = model.SubarachnoidHemorrhage;
            parameters[37].Value = model.MiocardialInfarction;
            parameters[38].Value = model.MiocardialInfarctionSum;
            parameters[39].Value = model.MiocardialInfarctionStartOld;
            parameters[40].Value = model.MiocardialInfarctionStartMonth;
            parameters[41].Value = model.MiocardialInfarctionEndOld;
            parameters[42].Value = model.MiocardialInfarctionEndMonth;
            parameters[43].Value = model.HeartDisease;
            parameters[44].Value = model.Kidney;
            parameters[45].Value = model.BloodVessel;
            parameters[46].Value = model.EyeDiseases;
            parameters[47].Value = model.Other;
            parameters[48].Value = model.OtherValue;

            int rows = MySQLHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateByMiniPad(RecordsHealthConditionModel model,string OutKey)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_RecordsHealthCondition SET ");
            strSql.Append("FamilyHistory=@FamilyHistory,");
            strSql.Append("FamilyHistoryOther=@FamilyHistoryOther,");
            strSql.Append("FoodAllergy=@FoodAllergy,");
            strSql.Append("OtherAllergy=@OtherAllergy,");
            strSql.Append("DrugAllergy=@DrugAllergy,");
            strSql.Append("AllergyHistory=@AllergyHistory,");
            strSql.Append("HealthStatus=@HealthStatus,");
            strSql.Append("SickStats=@SickStats,");
            strSql.Append("HypertensionOld=@HypertensionOld,");
            strSql.Append("HypertensionAdvice=@HypertensionAdvice,");
            strSql.Append("HypertensionInterrupt=@HypertensionInterrupt,");
            strSql.Append("HypertensionInterruptMonth=@HypertensionInterruptMonth,");
            strSql.Append("DiabetesOld=@DiabetesOld,");
            strSql.Append("DiabetesAdvice=@DiabetesAdvice,");
            strSql.Append("DiabetesInterrupt=@DiabetesInterrupt,");
            strSql.Append("DiabetesInterruptMonth=@DiabetesInterruptMonth,");
            strSql.Append("CerebralIschemia=@CerebralIschemia,");
            strSql.Append("CerebralIschemiaSum=@CerebralIschemiaSum,");
            strSql.Append("CerebralIschemiaStartOld=@CerebralIschemiaStartOld,");
            strSql.Append("CerebralIschemiaStartMonth=@CerebralIschemiaStartMonth,");
            strSql.Append("CerebralIschemiaEndOld=@CerebralIschemiaEndOld,");
            strSql.Append("CerebralIschemiaEndMonth=@CerebralIschemiaEndMonth,");
            strSql.Append("CerebralHemorrhage=@CerebralHemorrhage,");
            strSql.Append("CerebralHemorrhageSum=@CerebralHemorrhageSum,");
            strSql.Append("CerebralHemorrhageStartOld=@CerebralHemorrhageStartOld,");
            strSql.Append("CerebralHemorrhageStartMonth=@CerebralHemorrhageStartMonth,");
            strSql.Append("CerebralHemorrhageEndOld=@CerebralHemorrhageEndOld,");
            strSql.Append("CerebralHemorrhageEndMonth=@CerebralHemorrhageEndMonth,");
            strSql.Append("CerebralTIA=@CerebralTIA,");
            strSql.Append("CerebralTIASum=@CerebralTIASum,");
            strSql.Append("CerebralTIAStartOld=@CerebralTIAStartOld,");
            strSql.Append("CerebralTIAStartMonth=@CerebralTIAStartMonth,");
            strSql.Append("CerebralTIAEndOld=@CerebralTIAEndOld,");
            strSql.Append("CerebralTIAEndMonth=@CerebralTIAEndMonth,");
            strSql.Append("SubarachnoidHemorrhage=@SubarachnoidHemorrhage,");
            strSql.Append("MiocardialInfarction=@MiocardialInfarction,");
            strSql.Append("MiocardialInfarctionSum=@MiocardialInfarctionSum,");
            strSql.Append("MiocardialInfarctionStartOld=@MiocardialInfarctionStartOld,");
            strSql.Append("MiocardialInfarctionStartMonth=@MiocardialInfarctionStartMonth,");
            strSql.Append("MiocardialInfarctionEndOld=@MiocardialInfarctionEndOld,");
            strSql.Append("MiocardialInfarctionEndMonth=@MiocardialInfarctionEndMonth,");
            strSql.Append("HeartDisease=@HeartDisease,");
            strSql.Append("Kidney=@Kidney,");
            strSql.Append("BloodVessel=@BloodVessel,");
            strSql.Append("EyeDiseases=@EyeDiseases,");
            strSql.Append("Other=@Other,");
            strSql.Append("OtherValue=@OtherValue");
            strSql.Append(@" WHERE OutKey=@OutKey AND IDCardNo=@IDCardNo;");

            MySqlParameter[] parameters = {
                    new MySqlParameter("@FamilyHistory", model.FamilyHistory),
                    new MySqlParameter("@FamilyHistoryOther", model.FamilyHistoryOther),
                    new MySqlParameter("@FoodAllergy", model.FoodAllergy),
                    new MySqlParameter("@OtherAllergy", model.OtherAllergy),
                    new MySqlParameter("@DrugAllergy", model.DrugAllergy),
                    new MySqlParameter("@AllergyHistory", model.AllergyHistory),
                    new MySqlParameter("@HealthStatus", model.HealthStatus),
                    new MySqlParameter("@SickStats",model.SickStats),
                    new MySqlParameter("@HypertensionOld", model.HypertensionOld),
                    new MySqlParameter("@HypertensionAdvice", model.HypertensionAdvice),
                    new MySqlParameter("@HypertensionInterrupt", model.HypertensionInterrupt),
                    new MySqlParameter("@HypertensionInterruptMonth",model.HypertensionInterruptMonth),
                    new MySqlParameter("@DiabetesOld", model.DiabetesOld),
                    new MySqlParameter("@DiabetesAdvice", model.DiabetesAdvice),
                    new MySqlParameter("@DiabetesInterrupt",model.DiabetesInterrupt),
                    new MySqlParameter("@DiabetesInterruptMonth", model.DiabetesInterruptMonth),
                    new MySqlParameter("@CerebralIschemia", model.CerebralIschemia),
                    new MySqlParameter("@CerebralIschemiaSum", model.CerebralIschemiaSum),
                    new MySqlParameter("@CerebralIschemiaStartOld", model.CerebralIschemiaStartOld),
                    new MySqlParameter("@CerebralIschemiaStartMonth", model.CerebralIschemiaStartMonth),
                    new MySqlParameter("@CerebralIschemiaEndOld", model.CerebralIschemiaEndOld),
                    new MySqlParameter("@CerebralIschemiaEndMonth", model.CerebralIschemiaEndMonth),
                    new MySqlParameter("@CerebralHemorrhage", model.CerebralHemorrhage),
                    new MySqlParameter("@CerebralHemorrhageSum", model.CerebralHemorrhageSum),
                    new MySqlParameter("@CerebralHemorrhageStartOld", model.CerebralHemorrhageStartOld),
                    new MySqlParameter("@CerebralHemorrhageStartMonth", model.CerebralHemorrhageStartMonth),
                    new MySqlParameter("@CerebralHemorrhageEndOld", model.CerebralHemorrhageEndOld),
                    new MySqlParameter("@CerebralHemorrhageEndMonth", model.CerebralHemorrhageEndMonth),
                    new MySqlParameter("@CerebralTIA", model.CerebralTIA),
                    new MySqlParameter("@CerebralTIASum", model.CerebralTIASum),
                    new MySqlParameter("@CerebralTIAStartOld", model.CerebralTIAStartOld),
                    new MySqlParameter("@CerebralTIAStartMonth", model.CerebralTIAStartMonth),
                    new MySqlParameter("@CerebralTIAEndOld", model.CerebralTIAEndOld),
                    new MySqlParameter("@CerebralTIAEndMonth", model.CerebralTIAEndMonth),
                    new MySqlParameter("@SubarachnoidHemorrhage", model.SubarachnoidHemorrhage),
                    new MySqlParameter("@MiocardialInfarction", model.MiocardialInfarction),
                    new MySqlParameter("@MiocardialInfarctionSum", model.MiocardialInfarctionSum),
                    new MySqlParameter("@MiocardialInfarctionStartOld", model.MiocardialInfarctionStartOld),
                    new MySqlParameter("@MiocardialInfarctionStartMonth", model.MiocardialInfarctionStartMonth),
                    new MySqlParameter("@MiocardialInfarctionEndOld", model.MiocardialInfarctionEndOld),
                    new MySqlParameter("@MiocardialInfarctionEndMonth", model.MiocardialInfarctionEndMonth),
                    new MySqlParameter("@HeartDisease", model.HeartDisease),
                    new MySqlParameter("@Kidney", model.Kidney),
                    new MySqlParameter("@BloodVessel", model.BloodVessel),
                    new MySqlParameter("@EyeDiseases", model.EyeDiseases),
                    new MySqlParameter("@Other", model.Other),
                    new MySqlParameter("@OtherValue", model.OtherValue),
                    new MySqlParameter("@OutKey", OutKey),
                    new MySqlParameter("@IDCardNo", model.IDCardNo)};

            return (MySQLHelper.ExecuteSql(strSql.ToString(), parameters) > 0);
        }
    }
}
