namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using CommonUtilities.SQL;
    using System;
    using CommonModel;

    /// <summary>
    /// 肺结核第一次入户随访
    /// </summary>
    public class ChronicLungerFirstVisitDAL
    {
        public int Add(ChronicLungerFirstVisitModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_chroniclungerfirstvisit(");
            builder.Append("RecordID,CustomerID,IDCardNo,CustomerName,EstimateDoctor,");
            builder.Append("PatientType,Sputumfungs,DrugFast,Symptom,SymptomEx,MedicationCompliance,");

            if (VersionNo.Contains("3.0")) builder.Append(" VisitDate,VisitWay, ");
            else builder.Append(" FollowupDate,FollowupWay,");

            builder.Append("ChemotherapyScheme,DrugType,Supervisor,StandaloneRoom,Ventilation,");
            builder.Append("SmokeDayNum,DayDrinkVolume,MediclineReceiveTime,MediclineReceivePlace,RecordcardWrite,");
            builder.Append("PharmacyWayDeposit,Therapies,IndisciplineHarm,AdrsHandle,SubsequentVisit,InsistPharmacy,LivingHabit,");
            builder.Append("ChecktouchPerson,NextVisitDate,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,VisitDoctor,");
            builder.Append("NextSmokeDayNum,NextDayDrinkVolume)");
            builder.Append(" VALUES (");
            builder.Append("@RecordID,@CustomerID,@IDCardNo,@CustomerName,@EstimateDoctor,@PatientType,");
            builder.Append("@Sputumfungs,@DrugFast,@Symptom,@SymptomEx,@MedicationCompliance,@FollowupDate,@FollowupWay,");
            builder.Append("@ChemotherapyScheme,@DrugType,@Supervisor,@StandaloneRoom,@Ventilation,");
            builder.Append("@SmokeDayNum,@DayDrinkVolume,@MediclineReceiveTime,@MediclineReceivePlace,@RecordcardWrite,");
            builder.Append("@PharmacyWayDeposit,@Therapies,@IndisciplineHarm,@AdrsHandle,@SubsequentVisit,@InsistPharmacy,@LivingHabit,");
            builder.Append("@ChecktouchPerson,@NextVisitDate,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@VisitDoctor,");
            builder.Append("@NextSmokeDayNum,@NextDayDrinkVolume)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerName", MySqlDbType.String, 30),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@EstimateDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@FollowupWay", MySqlDbType.String,1),
                new MySqlParameter("@PatientType", MySqlDbType.String, 1),
                new MySqlParameter("@Sputumfungs", MySqlDbType.String, 1),
                new MySqlParameter("@DrugFast", MySqlDbType.String , 1),
                new MySqlParameter("@Symptom", MySqlDbType.String ,20),
                new MySqlParameter("@SymptomEx", MySqlDbType.String ,500),
                new MySqlParameter("@MedicationCompliance", MySqlDbType.String, 1),
                new MySqlParameter("@ChemotherapyScheme", MySqlDbType.String ,500),
                new MySqlParameter("@DrugType", MySqlDbType.String, 20),
                new MySqlParameter("@Supervisor", MySqlDbType.String,1),
                new MySqlParameter("@StandaloneRoom", MySqlDbType.String,1),
                new MySqlParameter("@Ventilation", MySqlDbType.String ,1),
                new MySqlParameter("@SmokeDayNum", MySqlDbType.Decimal),
                new MySqlParameter("@DayDrinkVolume", MySqlDbType.Decimal),
                new MySqlParameter("@MediclineReceiveTime", MySqlDbType.Date),
                new MySqlParameter("@MediclineReceivePlace", MySqlDbType.String,500),
                new MySqlParameter("@RecordcardWrite", MySqlDbType.String, 1),
                new MySqlParameter("@PharmacyWayDeposit", MySqlDbType.String, 1),
                new MySqlParameter("@Therapies", MySqlDbType.String, 1),
                new MySqlParameter("@IndisciplineHarm", MySqlDbType.String, 1),
                new MySqlParameter("@AdrsHandle", MySqlDbType.String, 1),
                new MySqlParameter("@SubsequentVisit", MySqlDbType.String, 1),
                new MySqlParameter("@InsistPharmacy", MySqlDbType.String, 1),
                new MySqlParameter("@LivingHabit", MySqlDbType.String, 1),
                new MySqlParameter("@ChecktouchPerson", MySqlDbType.String, 1),
                new MySqlParameter("@NextVisitDate", MySqlDbType.Date),
                new MySqlParameter("@CreatedBy", MySqlDbType.String,30),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String,30),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String ,1),
                new MySqlParameter("@VisitDoctor", MySqlDbType.String ,100),
                new MySqlParameter("@NextSmokeDayNum", MySqlDbType.Decimal),
                new MySqlParameter("@NextDayDrinkVolume", MySqlDbType.Decimal)
            };

            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.CustomerID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.CustomerName;
            cmdParms[4].Value = model.FollowupDate;
            cmdParms[5].Value = model.EstimateDoctor;
            cmdParms[6].Value = model.FollowupWay;
            cmdParms[7].Value = model.PatientType;
            cmdParms[8].Value = model.Sputumfungs;
            cmdParms[9].Value = model.DrugFast;
            cmdParms[10].Value = model.Symptom;
            cmdParms[11].Value = model.SymptomEx;
            cmdParms[12].Value = model.MedicationCompliance;
            cmdParms[13].Value = model.ChemotherapyScheme;
            cmdParms[14].Value = model.DrugType;
            cmdParms[15].Value = model.Supervisor;
            cmdParms[16].Value = model.StandaloneRoom;
            cmdParms[17].Value = model.Ventilation;
            cmdParms[18].Value = model.SmokeDayNum;
            cmdParms[19].Value = model.DayDrinkVolume;
            cmdParms[20].Value = model.MediclineReceiveTime;
            cmdParms[21].Value = model.MediclineReceivePlace;
            cmdParms[22].Value = model.RecordcardWrite;
            cmdParms[23].Value = model.PharmacyWayDeposit;
            cmdParms[24].Value = model.Therapies;
            cmdParms[25].Value = model.IndisciplineHarm;
            cmdParms[26].Value = model.AdrsHandle;
            cmdParms[27].Value = model.SubsequentVisit;
            cmdParms[28].Value = model.InsistPharmacy;
            cmdParms[29].Value = model.LivingHabit;
            cmdParms[30].Value = model.ChecktouchPerson;
            cmdParms[31].Value = model.NextVisitDate;
            cmdParms[32].Value = model.CreatedBy;
            cmdParms[33].Value = model.CreatedDate;
            cmdParms[34].Value = model.LastUpdateBy;
            cmdParms[35].Value = model.LastUpdateDate;
            cmdParms[36].Value = model.IsDel;
            cmdParms[37].Value = model.VisitDoctor;
            cmdParms[38].Value = model.NextSmokeDayNum;
            cmdParms[39].Value = model.NextDayDrinkVolume;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public int Add(ChronicLungerVisitModel model, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_chroniclungervisit(");
            builder.Append("RecordID,CustomerID,IDCardNo,CustomerName,VisitDoctor,");

            if (VersionNo.Contains("3.0")) builder.Append(" VisitDate,VisitWay, ");
            else builder.Append(" FollowupDate,FollowupWay,");

            builder.Append("CureMonth,Supervisor,Symptom,SymptomEx,SmokeDayNum,DayDrinkVolume,");
            builder.Append("ChemotherapyScheme,MedicationCompliance,DrugType,OmissiveTimes,Adr,AdrEx,");
            builder.Append("Complication,ComplicationEx,ReferralOrg,ReferralReason,ReferralResult,");
            builder.Append("HandleView,NextVisitDate,StopCureDate,StopCureReason,ShouldVisitTimes,");
            builder.Append("VisitTimes,ShouldPharmacyTimes,PharmacyTimes,EstimateDoctor,PharmacyRate,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,NextSmokeDayNum,NextDayDrinkVolume,VisitCount,OutKey )");
            builder.Append(" VALUES (");
            builder.Append("@RecordID,@CustomerID,@IDCardNo,@CustomerName,@VisitDoctor,@FollowupDate,@FollowupWay,");
            builder.Append("@CureMonth,@Supervisor,@Symptom,@SymptomEx,@SmokeDayNum,@DayDrinkVolume,");
            builder.Append("@ChemotherapyScheme,@MedicationCompliance,@DrugType,@OmissiveTimes,@Adr,@AdrEx,");
            builder.Append("@Complication,@ComplicationEx,@ReferralOrg,@ReferralReason,@ReferralResult,");
            builder.Append("@HandleView,@NextVisitDate,@StopCureDate,@StopCureReason,@ShouldVisitTimes,");
            builder.Append("@VisitTimes,@ShouldPharmacyTimes,@PharmacyTimes,@EstimateDoctor,@PharmacyRate,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@NextSmokeDayNum,@NextDayDrinkVolume,@VisitCount,@OutKey)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerName", MySqlDbType.String, 30),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@VisitDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@CureMonth", MySqlDbType.String,100),
                new MySqlParameter("@Supervisor", MySqlDbType.String, 100),
                new MySqlParameter("@FollowupWay", MySqlDbType.String, 1),
                new MySqlParameter("@Symptom", MySqlDbType.String , 20),
                new MySqlParameter("@SymptomEx", MySqlDbType.String ,100),
                new MySqlParameter("@SmokeDayNum", MySqlDbType.Decimal),
                new MySqlParameter("@DayDrinkVolume", MySqlDbType.Decimal),
                new MySqlParameter("@ChemotherapyScheme", MySqlDbType.String ,100),
                new MySqlParameter("@MedicationCompliance", MySqlDbType.String, 1),
                new MySqlParameter("@DrugType", MySqlDbType.String,100),
                new MySqlParameter("@OmissiveTimes", MySqlDbType.Int32,20),
                new MySqlParameter("@Adr", MySqlDbType.String ,1),
                new MySqlParameter("@AdrEx", MySqlDbType.String ,100),
                new MySqlParameter("@Complication", MySqlDbType.String,1),
                new MySqlParameter("@ComplicationEx", MySqlDbType.String,100),
                new MySqlParameter("@ReferralOrg", MySqlDbType.String,100),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 100),
                new MySqlParameter("@HandleView", MySqlDbType.String, 100),
                new MySqlParameter("@NextVisitDate", MySqlDbType.Date),
                new MySqlParameter("@StopCureDate", MySqlDbType.Date),
                new MySqlParameter("@StopCureReason", MySqlDbType.String, 100),
                new MySqlParameter("@ShouldVisitTimes", MySqlDbType.Int32, 20),
                new MySqlParameter("@VisitTimes", MySqlDbType.Int32,20),
                new MySqlParameter("@ShouldPharmacyTimes", MySqlDbType.Int32,20),
                new MySqlParameter("@PharmacyTimes", MySqlDbType.Int32,20),
                new MySqlParameter("@EstimateDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@PharmacyRate", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.String,30),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String,30),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String ,1),
                new MySqlParameter("@NextSmokeDayNum", MySqlDbType.Decimal),
                new MySqlParameter("@NextDayDrinkVolume", MySqlDbType.Decimal),
                new MySqlParameter("@VisitCount",MySqlDbType.Int32,1),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4)
            };

            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.CustomerID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.CustomerName;
            cmdParms[4].Value = model.FollowupDate;
            cmdParms[5].Value = model.VisitDoctor;
            cmdParms[6].Value = model.CureMonth;
            cmdParms[7].Value = model.Supervisor;
            cmdParms[8].Value = model.FollowupWay;
            cmdParms[9].Value = model.Symptom;
            cmdParms[10].Value = model.SymptomEx;
            cmdParms[11].Value = model.SmokeDayNum;
            cmdParms[12].Value = model.DayDrinkVolume;
            cmdParms[13].Value = model.ChemotherapyScheme;
            cmdParms[14].Value = model.MedicationCompliance;
            cmdParms[15].Value = model.DrugType;
            cmdParms[16].Value = model.OmissiveTimes;
            cmdParms[17].Value = model.Adr;
            cmdParms[18].Value = model.AdrEx;
            cmdParms[19].Value = model.Complication;
            cmdParms[20].Value = model.ComplicationEx;
            cmdParms[21].Value = model.ReferralOrg;
            cmdParms[22].Value = model.ReferralReason;
            cmdParms[23].Value = model.ReferralResult;
            cmdParms[24].Value = model.HandleView;
            cmdParms[25].Value = model.NextVisitDate;
            cmdParms[26].Value = model.StopCureDate;
            cmdParms[27].Value = model.StopCureReason;
            cmdParms[28].Value = model.ShouldVisitTimes;
            cmdParms[29].Value = model.VisitTimes;
            cmdParms[30].Value = model.ShouldPharmacyTimes;
            cmdParms[31].Value = model.PharmacyTimes;
            cmdParms[32].Value = model.EstimateDoctor;
            cmdParms[33].Value = model.PharmacyRate;
            cmdParms[34].Value = model.CreatedBy;
            cmdParms[35].Value = model.CreatedDate;
            cmdParms[36].Value = model.LastUpdateBy;
            cmdParms[37].Value = model.LastUpdateDate;
            cmdParms[38].Value = model.IsDel;
            cmdParms[39].Value = model.NextSmokeDayNum;
            cmdParms[40].Value = model.NextDayDrinkVolume;
            cmdParms[41].Value = model.VisitCount;
            cmdParms[42].Value = model.OutKey;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 本季度是否有随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public int GetDataCount(string IDCardNo, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT SUM(COUNTS) FROM( ");

            if (VersionNo.Contains("3.0"))
            {
                builder.Append("SELECT COUNT(0) AS COUNTS FROM tbl_ChronicLungerFirstVisit ");
                builder.Append("WHERE IDCardNo=@IDCardNo ");
                builder.Append(" AND YEAR(VisitDate)=YEAR(NOW())");
                builder.Append(" AND QUARTER(VisitDate) = QUARTER(NOW())");
                builder.Append(" UNION ");
                builder.Append("SELECT COUNT(0) AS COUNTS FROM tbl_ChronicLungerVisit ");
                builder.Append("WHERE IDCardNo=@IDCardNo ");
                builder.Append(" AND YEAR(VisitDate)=YEAR(NOW())");
                builder.Append(" AND QUARTER(VisitDate) = QUARTER(NOW())");
            }
            else
            {
                builder.Append("SELECT COUNT(0) AS COUNTS FROM tbl_ChronicLungerFirstVisit ");
                builder.Append("WHERE IDCardNo=@IDCardNo ");
                builder.Append(" AND YEAR(FollowUpDate)=YEAR(NOW())");
                builder.Append(" AND QUARTER(FollowUpDate) = QUARTER(NOW())");
                builder.Append(" UNION ");
                builder.Append("SELECT COUNT(0) AS COUNTS FROM tbl_ChronicLungerVisit ");
                builder.Append("WHERE IDCardNo=@IDCardNo ");
                builder.Append(" AND YEAR(FollowUpDate)=YEAR(NOW())");
                builder.Append(" AND QUARTER(FollowUpDate) = QUARTER(NOW())");
            }

            builder.Append(") AS DATAS ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }
                
        /// <summary>
        /// 取第一次随访信息
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public DataSet GetFirstMaxModel(string IDCardNo, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();
            string column = VersionNo.Contains("3.0") ? "VisitDate" : "FollowupDate";

            builder.Append("SELECT * FROM tbl_ChronicLungerFirstVisit ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            builder.AppendFormat(" ORDER BY {0} DESC LIMIT 0,1 ", column);

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 取最后一次随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public DataSet GetMaxModel(string IDCardNo, string VersionNo)
        {
            StringBuilder builder = new StringBuilder();
            string column = VersionNo.Contains("3.0") ? "VisitDate" : "FollowupDate";

            builder.Append("SELECT * FROM tbl_ChronicLungerVisit ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");

            builder.AppendFormat(" ORDER BY {0} DESC LIMIT 0,1 ", column);

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }
    }
}
