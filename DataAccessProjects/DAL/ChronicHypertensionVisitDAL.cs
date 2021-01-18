namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicHypertensionVisitDAL
    {
        public int Add(ChronicHypertensionVisitModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO CD_HYPERTENSIONFOLLOWUP(");
            builder.Append("RecordID,CustomerID,IDCardNo,CustomerName,FollowUpDate,FollowUpDoctor,");
            builder.Append("NextFollowUpDate,Symptom,SympToMother,Hypertension,Hypotension,Weight,BMI,");
            builder.Append("HeartRate,PhysicalSympToMother,DailySmokeNum,DailyDrinkNum,SportTimePerWeek,");
            builder.Append("SportPerMinuteTime,EatSaltType,EatSaltTarGet,PsyChoadJustMent,ObeyDoctorBehavior,");
            builder.Append("AssistantExam,MedicationCompliance,Adr,AdrEx,FollowUpType,ReferralReason,ReferralOrg,");
            builder.Append("FollowUpWay,WeightTarGet,BMITarGet,DailySmokeNumTarget,DailyDrinkNumTarget,");
            builder.Append("SportTimeSperWeekTarget,SportPerMinutesTimeTarget,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,");
            builder.Append("IsDel,Hight,DoctorView,IsReferral,NextMeasures,ReferralContacts,ReferralResult,Remarks )");
            builder.Append(" VALUES (");
            builder.Append("@RecordID,@CustomerID,@IDCardNo,@CustomerName,@FollowUpDate,@FollowUpDoctor,@NextFollowUpDate,@Symptom,");
            builder.Append("@SympToMother,@Hypertension,@Hypotension,@Weight,@BMI,@HeartRate,@PhysicalSympToMother,@DailySmokeNum,@DailyDrinkNum,");
            builder.Append("@SportTimePerWeek,@SportPerMinuteTime,@EatSaltType,@EatSaltTarGet,@PsyChoadJustMent,@ObeyDoctorBehavior,@AssistantExam,");
            builder.Append("@MedicationCompliance,@Adr,@AdrEx,@FollowUpType,@ReferralReason,@ReferralOrg,@FollowUpWay,@WeightTarGet,@BMITarGet,");
            builder.Append("@DailySmokeNumTarget,@DailyDrinkNumTarget,@SportTimeSperWeekTarget,@SportPerMinutesTimeTarget,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@Hight,@DoctorView,@IsReferral,@NextMeasures,@ReferralContacts,@ReferralResult,@Remarks )");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerName", MySqlDbType.String, 30),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@Symptom", MySqlDbType.String, 20),
                new MySqlParameter("@SympToMother", MySqlDbType.String, 500),
                new MySqlParameter("@Hypertension", MySqlDbType.Decimal),
                new MySqlParameter("@Hypotension", MySqlDbType.Decimal),
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@HeartRate", MySqlDbType.Decimal),
                new MySqlParameter("@PhysicalSympToMother", MySqlDbType.String, 500),
                new MySqlParameter("@DailySmokeNum", MySqlDbType.Decimal),
                new MySqlParameter("@DailyDrinkNum", MySqlDbType.Decimal),
                new MySqlParameter("@SportTimePerWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportPerMinuteTime", MySqlDbType.Decimal),
                new MySqlParameter("@EatSaltType", MySqlDbType.String, 1),
                new MySqlParameter("@EatSaltTarGet", MySqlDbType.String, 1),
                new MySqlParameter("@PsyChoadJustMent", MySqlDbType.String, 500),
                new MySqlParameter("@ObeyDoctorBehavior", MySqlDbType.String, 1),
                new MySqlParameter("@AssistantExam", MySqlDbType.String, 500),
                new MySqlParameter("@MedicationCompliance", MySqlDbType.String, 1),
                new MySqlParameter("@Adr", MySqlDbType.String, 1),
                new MySqlParameter("@AdrEx", MySqlDbType.String, 500),
                new MySqlParameter("@FollowUpType", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80),
                new MySqlParameter("@FollowUpWay", MySqlDbType.String, 1),
                new MySqlParameter("@WeightTarGet", MySqlDbType.Decimal),
                new MySqlParameter("@BMITarGet", MySqlDbType.Decimal),
                new MySqlParameter("@DailySmokeNumTarget", MySqlDbType.Decimal),
                new MySqlParameter("@DailyDrinkNumTarget", MySqlDbType.Decimal),
                new MySqlParameter("@SportTimeSperWeekTarget", MySqlDbType.Decimal),
                new MySqlParameter("@SportPerMinutesTimeTarget", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.String, 18),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String, 18),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Hight", MySqlDbType.Decimal),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 80),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1),
                new MySqlParameter("@NextMeasures", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@Remarks", MySqlDbType.String, 100)
            };

            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.CustomerID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.CustomerName;
            cmdParms[4].Value = model.FollowUpDate;
            cmdParms[5].Value = model.FollowUpDoctor;
            cmdParms[6].Value = model.NextFollowUpDate;
            cmdParms[7].Value = model.Symptom;
            cmdParms[8].Value = model.SympToMother;
            cmdParms[9].Value = model.Hypertension;
            cmdParms[10].Value = model.Hypotension;
            cmdParms[11].Value = model.Weight;
            cmdParms[12].Value = model.BMI;
            cmdParms[13].Value = model.HeartRate;
            cmdParms[14].Value = model.PhysicalSympToMother;
            cmdParms[15].Value = model.DailySmokeNum;
            cmdParms[16].Value = model.DailyDrinkNum;
            cmdParms[17].Value = model.SportTimePerWeek;
            cmdParms[18].Value = model.SportPerMinuteTime;
            cmdParms[19].Value = model.EatSaltType;
            cmdParms[20].Value = model.EatSaltTarGet;
            cmdParms[21].Value = model.PsyChoadJustMent;
            cmdParms[22].Value = model.ObeyDoctorBehavior;
            cmdParms[23].Value = model.AssistantExam;
            cmdParms[24].Value = model.MedicationCompliance;
            cmdParms[25].Value = model.Adr;
            cmdParms[26].Value = model.AdrEx;
            cmdParms[27].Value = model.FollowUpType;
            cmdParms[28].Value = model.ReferralReason;
            cmdParms[29].Value = model.ReferralOrg;
            cmdParms[30].Value = model.FollowUpWay;
            cmdParms[31].Value = model.WeightTarGet;
            cmdParms[32].Value = model.BMITarGet;
            cmdParms[33].Value = model.DailySmokeNumTarget;
            cmdParms[34].Value = model.DailyDrinkNumTarget;
            cmdParms[35].Value = model.SportTimeSperWeekTarget;
            cmdParms[36].Value = model.SportPerMinutesTimeTarget;
            cmdParms[37].Value = model.CreatedBy;
            cmdParms[38].Value = model.CreatedDate;
            cmdParms[39].Value = model.LastUpdateBy;
            cmdParms[40].Value = model.LastUpdateDate;
            cmdParms[41].Value = model.IsDel;
            cmdParms[42].Value = model.Hight;
            cmdParms[43].Value = model.DoctorView;
            cmdParms[44].Value = model.IsReferral;
            cmdParms[45].Value = model.NextMeasures;
            cmdParms[46].Value = model.ReferralContacts;
            cmdParms[47].Value = model.ReferralResult;
            cmdParms[48].Value = model.Remarks;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }
        
        public ChronicHypertensionVisitModel DataRowToModel(DataRow row)
        {
            ChronicHypertensionVisitModel chronicHypertensionVisitModel = new ChronicHypertensionVisitModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["CustomerName"] != null) && (row["CustomerName"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.CustomerName = row["CustomerName"].ToString();
                }
                if (((row["FollowUpDate"] != null) && (row["FollowUpDate"] != DBNull.Value)) && (row["FollowUpDate"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.FollowUpDate = new DateTime?(DateTime.Parse(row["FollowUpDate"].ToString()));
                }
                if ((row["FollowUpDoctor"] != null) && (row["FollowUpDoctor"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.FollowUpDoctor = row["FollowUpDoctor"].ToString();
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.NextFollowUpDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["Symptom"] != null) && (row["Symptom"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.Symptom = row["Symptom"].ToString();
                }
                if ((row["SympToMother"] != null) && (row["SympToMother"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.SympToMother = row["SympToMother"].ToString();
                }
                if (((row["Hypertension"] != null) && (row["Hypertension"] != DBNull.Value)) && (row["Hypertension"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.Hypertension = new decimal?(decimal.Parse(row["Hypertension"].ToString()));
                }
                if (((row["Hypotension"] != null) && (row["Hypotension"] != DBNull.Value)) && (row["Hypotension"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.Hypotension = new decimal?(decimal.Parse(row["Hypotension"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if (((row["BMI"] != null) && (row["BMI"] != DBNull.Value)) && (row["BMI"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.BMI = new decimal?(decimal.Parse(row["BMI"].ToString()));
                }
                if (((row["HeartRate"] != null) && (row["HeartRate"] != DBNull.Value)) && (row["HeartRate"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.HeartRate = new decimal?(decimal.Parse(row["HeartRate"].ToString()));
                }
                if ((row["PhysicalSympToMother"] != null) && (row["PhysicalSympToMother"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.PhysicalSympToMother = row["PhysicalSympToMother"].ToString();
                }
                if (((row["DailySmokeNum"] != null) && (row["DailySmokeNum"] != DBNull.Value)) && (row["DailySmokeNum"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.DailySmokeNum = new decimal?(decimal.Parse(row["DailySmokeNum"].ToString()));
                }
                if (((row["DailyDrinkNum"] != null) && (row["DailyDrinkNum"] != DBNull.Value)) && (row["DailyDrinkNum"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.DailyDrinkNum = new decimal?(decimal.Parse(row["DailyDrinkNum"].ToString()));
                }
                if (((row["SportTimePerWeek"] != null) && (row["SportTimePerWeek"] != DBNull.Value)) && (row["SportTimePerWeek"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.SportTimePerWeek = new decimal?(decimal.Parse(row["SportTimePerWeek"].ToString()));
                }
                if (((row["SportPerMinuteTime"] != null) && (row["SportPerMinuteTime"] != DBNull.Value)) && (row["SportPerMinuteTime"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.SportPerMinuteTime = new decimal?(decimal.Parse(row["SportPerMinuteTime"].ToString()));
                }
                if ((row["EatSaltType"] != null) && (row["EatSaltType"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.EatSaltType = row["EatSaltType"].ToString();
                }
                if ((row["EatSaltTarGet"] != null) && (row["EatSaltTarGet"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.EatSaltTarGet = row["EatSaltTarGet"].ToString();
                }
                if ((row["PsyChoadJustMent"] != null) && (row["PsyChoadJustMent"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.PsyChoadJustMent = row["PsyChoadJustMent"].ToString();
                }
                if ((row["ObeyDoctorBehavior"] != null) && (row["ObeyDoctorBehavior"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.ObeyDoctorBehavior = row["ObeyDoctorBehavior"].ToString();
                }
                if ((row["AssistantExam"] != null) && (row["AssistantExam"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.AssistantExam = row["AssistantExam"].ToString();
                }
                if ((row["MedicationCompliance"] != null) && (row["MedicationCompliance"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.MedicationCompliance = row["MedicationCompliance"].ToString();
                }
                if ((row["Adr"] != null) && (row["Adr"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.Adr = row["Adr"].ToString();
                }
                if ((row["AdrEx"] != null) && (row["AdrEx"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.AdrEx = row["AdrEx"].ToString();
                }
                if ((row["FollowUpType"] != null) && (row["FollowUpType"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.FollowUpType = row["FollowUpType"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["ReferralOrg"] != null) && (row["ReferralOrg"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.ReferralOrg = row["ReferralOrg"].ToString();
                }
                if ((row["FollowUpWay"] != null) && (row["FollowUpWay"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.FollowUpWay = row["FollowUpWay"].ToString();
                }
                if (((row["WeightTarGet"] != null) && (row["WeightTarGet"] != DBNull.Value)) && (row["WeightTarGet"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.WeightTarGet = new decimal?(decimal.Parse(row["WeightTarGet"].ToString()));
                }
                if (((row["BMITarGet"] != null) && (row["BMITarGet"] != DBNull.Value)) && (row["BMITarGet"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.BMITarGet = new decimal?(decimal.Parse(row["BMITarGet"].ToString()));
                }
                if (((row["DailySmokeNumTarget"] != null) && (row["DailySmokeNumTarget"] != DBNull.Value)) && (row["DailySmokeNumTarget"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.DailySmokeNumTarget = new decimal?(decimal.Parse(row["DailySmokeNumTarget"].ToString()));
                }
                if (((row["DailyDrinkNumTarget"] != null) && (row["DailyDrinkNumTarget"] != DBNull.Value)) && (row["DailyDrinkNumTarget"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.DailyDrinkNumTarget = new decimal?(decimal.Parse(row["DailyDrinkNumTarget"].ToString()));
                }
                if (((row["SportTimeSperWeekTarget"] != null) && (row["SportTimeSperWeekTarget"] != DBNull.Value)) && (row["SportTimeSperWeekTarget"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.SportTimeSperWeekTarget = new decimal?(decimal.Parse(row["SportTimeSperWeekTarget"].ToString()));
                }
                if (((row["SportPerMinutesTimeTarget"] != null) && (row["SportPerMinutesTimeTarget"] != DBNull.Value)) && (row["SportPerMinutesTimeTarget"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.SportPerMinutesTimeTarget = new decimal?(decimal.Parse(row["SportPerMinutesTimeTarget"].ToString()));
                }
                if ((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.CreatedBy = row["CreatedBy"].ToString();
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if ((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.LastUpdateBy = row["LastUpdateBy"].ToString();
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.IsDel = row["IsDel"].ToString();
                }
                if (((row["Hight"] != null) && (row["Hight"] != DBNull.Value)) && (row["Hight"].ToString() != ""))
                {
                    chronicHypertensionVisitModel.Hight = new decimal?(decimal.Parse(row["Hight"].ToString()));
                }
                if ((row["DoctorView"] != null) && (row["DoctorView"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.DoctorView = row["DoctorView"].ToString();
                }
                if ((row["IsReferral"] != null) && (row["IsReferral"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.IsReferral = row["IsReferral"].ToString();
                }
                if ((row["NextMeasures"] != null) && (row["NextMeasures"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.NextMeasures = row["NextMeasures"].ToString();
                }
                if ((row["ReferralContacts"] != null) && (row["ReferralContacts"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.ReferralContacts = row["ReferralContacts"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.ReferralResult = row["ReferralResult"].ToString();
                }
                if ((row["Remarks"] != null) && (row["Remarks"] != DBNull.Value))
                {
                    chronicHypertensionVisitModel.Remarks = row["Remarks"].ToString();
                }
            }
            return chronicHypertensionVisitModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_HYPERTENSIONFOLLOWUP ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public ChronicHypertensionVisitModel ExistsCheckDate(ChronicHypertensionVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,RecordID,CustomerID,IDCardNo,CustomerName,");
            builder.Append("FollowUpDate,FollowUpDoctor,NextFollowUpDate,");
            builder.Append("Symptom,SympToMother,Hypertension,Hypotension,Weight,BMI,HeartRate,PhysicalSympToMother,");
            builder.Append("DailySmokeNum,DailyDrinkNum,SportTimePerWeek,SportPerMinuteTime,EatSaltType,EatSaltTarGet,");
            builder.Append("PsyChoadJustMent,ObeyDoctorBehavior,AssistantExam,MedicationCompliance,Adr,AdrEx,FollowUpType,");
            builder.Append("ReferralReason,ReferralOrg,FollowUpWay,WeightTarGet,BMITarGet,DailySmokeNumTarget,DailyDrinkNumTarget,");
            builder.Append("SportTimeSperWeekTarget,SportPerMinutesTimeTarget,CreatedBy,CreatedDate,");
            builder.Append("LastUpdateBy,LastUpdateDate,IsDel,Hight,DoctorView,IsReferral,NextMeasures,ReferralContacts,ReferralResult,Remarks from CD_HYPERTENSIONFOLLOWUP ");
            builder.Append(" where FollowUpDate = @FollowUpDate and IDCardNo =@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
            };
            cmdParms[0].Value = model.FollowUpDate;
            cmdParms[1].Value = model.IDCardNo;
            new ChronicHypertensionVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,CustomerID,IDCardNo,CustomerName,FollowUpDate,FollowUpDoctor, ");
            builder.Append("NextFollowUpDate,Symptom,SympToMother,Hypertension,Hypotension,Weight,BMI,HeartRate,");
            builder.Append("PhysicalSympToMother,DailySmokeNum,DailyDrinkNum,SportTimePerWeek,SportPerMinuteTime,");
            builder.Append("EatSaltType,EatSaltTarGet,PsyChoadJustMent,ObeyDoctorBehavior,AssistantExam,");
            builder.Append("MedicationCompliance,Adr,AdrEx,FollowUpType,ReferralReason,ReferralOrg,FollowUpWay,");
            builder.Append("WeightTarGet,BMITarGet,DailySmokeNumTarget,DailyDrinkNumTarget,SportTimeSperWeekTarget,");
            builder.Append("SportPerMinutesTimeTarget,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,Hight,DoctorView,IsReferral, ");
            builder.Append("NextMeasures,ReferralContacts,ReferralResult,Remarks ");
            builder.Append(" FROM CD_HYPERTENSIONFOLLOWUP ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetChypertensionvisitdt(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select IDCardNo FROM CD_HYPERTENSIONFOLLOWUP ");
            builder.Append(" where IDCardNo = '" + IDCardNo + "' ");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select C.IDCardNo,C.ID,T.RecordID,T.CustomerName,T.Nation,T.Sex,T.Birthday,T.Phone,");
            builder.Append("T.Doctor,T.Address,T.HouseHoldAddress,T.Minority,");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate, ");
            builder.Append("(case C.FollowUpDate when null then null when '' then null else C.FollowUpDate end)FollowUpDate, ");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName ");
            builder.Append(" from CD_HYPERTENSIONFOLLOWUP C inner join ARCHIVE_BASEINFO T on T.IDCardNo = C.IDCardNo ");
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
        
        public ChronicHypertensionVisitModel GetModels(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,RecordID,CustomerID,IDCardNo,CustomerName,");
            builder.Append("FollowUpDate,FollowUpDoctor,NextFollowUpDate,");
            builder.Append("Symptom,SympToMother,Hypertension,Hypotension,Weight,BMI,HeartRate,PhysicalSympToMother,");
            builder.Append("DailySmokeNum,DailyDrinkNum,SportTimePerWeek,SportPerMinuteTime,EatSaltType,EatSaltTarGet,");
            builder.Append("PsyChoadJustMent,ObeyDoctorBehavior,AssistantExam,MedicationCompliance,Adr,AdrEx,FollowUpType,");
            builder.Append("ReferralReason,ReferralOrg,FollowUpWay,WeightTarGet,BMITarGet,DailySmokeNumTarget,DailyDrinkNumTarget,");
            builder.Append("SportTimeSperWeekTarget,SportPerMinutesTimeTarget,CreatedBy,CreatedDate,");
            builder.Append("LastUpdateBy,LastUpdateDate,IsDel,Hight,DoctorView,IsReferral, ");
            builder.Append("NextMeasures,ReferralContacts,ReferralResult,Remarks ");
            builder.Append(" from CD_HYPERTENSIONFOLLOWUP ");
            builder.Append(" where IDCardNo=@IDCardNo order by FollowUpDate desc limit 0,1 ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String, 21) };
            cmdParms[0].Value = IDCardNo;
            new ChronicHypertensionVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public ChronicHypertensionVisitModel GetModelID(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,RecordID,CustomerID,IDCardNo,CustomerName,");
            builder.Append("FollowUpDate,FollowUpDoctor,NextFollowUpDate,");
            builder.Append("Symptom,SympToMother,Hypertension,Hypotension,Weight,BMI,HeartRate,PhysicalSympToMother,");
            builder.Append("DailySmokeNum,DailyDrinkNum,SportTimePerWeek,SportPerMinuteTime,EatSaltType,EatSaltTarGet,");
            builder.Append("PsyChoadJustMent,ObeyDoctorBehavior,AssistantExam,MedicationCompliance,Adr,AdrEx,FollowUpType,");
            builder.Append("ReferralReason,ReferralOrg,FollowUpWay,WeightTarGet,BMITarGet,DailySmokeNumTarget,DailyDrinkNumTarget,");
            builder.Append("SportTimeSperWeekTarget,SportPerMinutesTimeTarget,CreatedBy,CreatedDate,");
            builder.Append("LastUpdateBy,LastUpdateDate,IsDel,Hight,DoctorView,IsReferral,");
            builder.Append("NextMeasures,ReferralContacts,ReferralResult,Remarks ");
            builder.Append(" from CD_HYPERTENSIONFOLLOWUP ");
            builder.Append(" where ID=@ID ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = ID;
            new ChronicHypertensionVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 取最后一次随访
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <returns></returns>
        public DataSet GetMaxModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM CD_HYPERTENSIONFOLLOWUP ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");
            builder.Append(" ORDER BY FollowupDate DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM CD_HYPERTENSIONFOLLOWUP C ");
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

        public bool Update(ChronicHypertensionVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_HYPERTENSIONFOLLOWUP set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CustomerName=@CustomerName,");
            builder.Append("FollowUpDate=@FollowUpDate,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("SympToMother=@SympToMother,");
            builder.Append("Hypertension=@Hypertension,");
            builder.Append("Hypotension=@Hypotension,");
            builder.Append("Weight=@Weight,");
            builder.Append("BMI=@BMI,");
            builder.Append("HeartRate=@HeartRate,");
            builder.Append("PhysicalSympToMother=@PhysicalSympToMother,");
            builder.Append("DailySmokeNum=@DailySmokeNum,");
            builder.Append("DailyDrinkNum=@DailyDrinkNum,");
            builder.Append("SportTimePerWeek=@SportTimePerWeek,");
            builder.Append("SportPerMinuteTime=@SportPerMinuteTime,");
            builder.Append("EatSaltType=@EatSaltType,");
            builder.Append("EatSaltTarGet=@EatSaltTarGet,");
            builder.Append("PsyChoadJustMent=@PsyChoadJustMent,");
            builder.Append("ObeyDoctorBehavior=@ObeyDoctorBehavior,");
            builder.Append("AssistantExam=@AssistantExam,");
            builder.Append("MedicationCompliance=@MedicationCompliance,");
            builder.Append("Adr=@Adr,");
            builder.Append("AdrEx=@AdrEx,");
            builder.Append("FollowUpType=@FollowUpType,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("FollowUpWay=@FollowUpWay,");
            builder.Append("WeightTarGet=@WeightTarGet,");
            builder.Append("BMITarGet=@BMITarGet,");
            builder.Append("DailySmokeNumTarget=@DailySmokeNumTarget,");
            builder.Append("DailyDrinkNumTarget=@DailyDrinkNumTarget,");
            builder.Append("SportTimeSperWeekTarget=@SportTimeSperWeekTarget,");
            builder.Append("SportPerMinutesTimeTarget=@SportPerMinutesTimeTarget,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("Hight=@Hight, ");
            builder.Append("DoctorView=@DoctorView, ");
            builder.Append("IsReferral=@IsReferral, ");
            builder.Append("NextMeasures=@NextMeasures, ");
            builder.Append("ReferralContacts=@ReferralContacts, ");
            builder.Append("ReferralResult=@ReferralResult, ");
            builder.Append("Remarks=@Remarks ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerName", MySqlDbType.String, 30),
                new MySqlParameter("@FollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@Symptom", MySqlDbType.String, 20),
                new MySqlParameter("@SympToMother", MySqlDbType.String, 500),
                new MySqlParameter("@Hypertension", MySqlDbType.Decimal),
                new MySqlParameter("@Hypotension", MySqlDbType.Decimal),
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@HeartRate", MySqlDbType.Decimal),
                new MySqlParameter("@PhysicalSympToMother", MySqlDbType.String, 500),
                new MySqlParameter("@DailySmokeNum", MySqlDbType.Decimal),
                new MySqlParameter("@DailyDrinkNum", MySqlDbType.Decimal),
                new MySqlParameter("@SportTimePerWeek", MySqlDbType.Decimal),
                new MySqlParameter("@SportPerMinuteTime", MySqlDbType.Decimal),
                new MySqlParameter("@EatSaltType", MySqlDbType.String, 1),
                new MySqlParameter("@EatSaltTarGet", MySqlDbType.String, 1),
                new MySqlParameter("@PsyChoadJustMent", MySqlDbType.String, 500),
                new MySqlParameter("@ObeyDoctorBehavior", MySqlDbType.String, 1),
                new MySqlParameter("@AssistantExam", MySqlDbType.String, 500),
                new MySqlParameter("@MedicationCompliance", MySqlDbType.String, 1),
                new MySqlParameter("@Adr", MySqlDbType.String, 1),
                new MySqlParameter("@AdrEx", MySqlDbType.String, 500),
                new MySqlParameter("@FollowUpType", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500),
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80),
                new MySqlParameter("@FollowUpWay", MySqlDbType.String, 1),
                new MySqlParameter("@WeightTarGet", MySqlDbType.Decimal),
                new MySqlParameter("@BMITarGet", MySqlDbType.Decimal),
                new MySqlParameter("@DailySmokeNumTarget", MySqlDbType.Decimal),
                new MySqlParameter("@DailyDrinkNumTarget", MySqlDbType.Decimal),
                new MySqlParameter("@SportTimeSperWeekTarget", MySqlDbType.Decimal),
                new MySqlParameter("@SportPerMinutesTimeTarget", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.String, 18),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String, 18),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@Hight", MySqlDbType.Decimal),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 100),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1),
                new MySqlParameter("@NextMeasures", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@Remarks", MySqlDbType.String, 100),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.CustomerID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.CustomerName;
            cmdParms[4].Value = model.FollowUpDate;
            cmdParms[5].Value = model.FollowUpDoctor;
            cmdParms[6].Value = model.NextFollowUpDate;
            cmdParms[7].Value = model.Symptom;
            cmdParms[8].Value = model.SympToMother;
            cmdParms[9].Value = model.Hypertension;
            cmdParms[10].Value = model.Hypotension;
            cmdParms[11].Value = model.Weight;
            cmdParms[12].Value = model.BMI;
            cmdParms[13].Value = model.HeartRate;
            cmdParms[14].Value = model.PhysicalSympToMother;
            cmdParms[15].Value = model.DailySmokeNum;
            cmdParms[16].Value = model.DailyDrinkNum;
            cmdParms[17].Value = model.SportTimePerWeek;
            cmdParms[18].Value = model.SportPerMinuteTime;
            cmdParms[19].Value = model.EatSaltType;
            cmdParms[20].Value = model.EatSaltTarGet;
            cmdParms[21].Value = model.PsyChoadJustMent;
            cmdParms[22].Value = model.ObeyDoctorBehavior;
            cmdParms[23].Value = model.AssistantExam;
            cmdParms[24].Value = model.MedicationCompliance;
            cmdParms[25].Value = model.Adr;
            cmdParms[26].Value = model.AdrEx;
            cmdParms[27].Value = model.FollowUpType;
            cmdParms[28].Value = model.ReferralReason;
            cmdParms[29].Value = model.ReferralOrg;
            cmdParms[30].Value = model.FollowUpWay;
            cmdParms[31].Value = model.WeightTarGet;
            cmdParms[32].Value = model.BMITarGet;
            cmdParms[33].Value = model.DailySmokeNumTarget;
            cmdParms[34].Value = model.DailyDrinkNumTarget;
            cmdParms[35].Value = model.SportTimeSperWeekTarget;
            cmdParms[36].Value = model.SportPerMinutesTimeTarget;
            cmdParms[37].Value = model.CreatedBy;
            cmdParms[38].Value = model.CreatedDate;
            cmdParms[39].Value = model.LastUpdateBy;
            cmdParms[40].Value = model.LastUpdateDate;
            cmdParms[41].Value = model.IsDel;
            cmdParms[42].Value = model.Hight;
            cmdParms[43].Value = model.DoctorView;
            cmdParms[44].Value = model.IsReferral;
            cmdParms[45].Value = model.NextMeasures;
            cmdParms[46].Value = model.ReferralContacts;
            cmdParms[47].Value = model.ReferralResult;
            cmdParms[48].Value = model.Remarks;
            cmdParms[49].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateDate(ChronicHypertensionVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_HYPERTENSIONFOLLOWUP set ");
            decimal d;
            if (decimal.TryParse(model.Hypertension.ToString(), out d))
            {
                builder.Append("Hypertension='" + d + "',");
            }
            if (decimal.TryParse(model.Hypotension.ToString(), out d))
            {
                builder.Append("Hypotension='" + d + "',");
            }
            if (decimal.TryParse(model.Weight.ToString(), out d))
            {
                builder.Append("Weight='" + d + "',");
            }
            if (decimal.TryParse(model.BMI.ToString(), out d))
            {
                builder.Append("BMI='" + d + "',");
            }
            if (decimal.TryParse(model.Hight.ToString(), out d))
            {
                builder.Append("Hight='" + d + "',");
            }
            if (decimal.TryParse(model.DailySmokeNum.ToString(), out d))
            {
                builder.Append("DailySmokeNum='" + d + "',");
            }

            if (decimal.TryParse(model.DailyDrinkNum.ToString(), out d))
            {
                builder.Append("DailyDrinkNum='" + d + "',");
            }
            if (model.BMI < 24)
            {
                builder.Append("WeightTarGet=null,");
            }
            else
            {
                if (decimal.TryParse(model.WeightTarGet.ToString(), out d))
                {
                    builder.Append("WeightTarGet='" + d + "',");
                }
            }
            builder.Append("DailySmokeNumTarget='" + model.DailySmokeNumTarget + "',");
            builder.Append("DailyDrinkNumTarget='" + model.DailyDrinkNumTarget + "',");
            builder.Append("SportTimeSperWeekTarget='" + model.SportTimeSperWeekTarget + "',");
            builder.Append("SportPerMinutesTimeTarget='" + model.SportPerMinutesTimeTarget + "',");
            builder.Append("AssistantExam='" + model.AssistantExam + "',");
            if (decimal.TryParse(model.HeartRate.ToString(), out d))
            {
                builder.Append("HeartRate='" + d + "',");
            }
            string sql = builder.ToString();
            sql = sql.Substring(0, sql.LastIndexOf(','));

            sql += " where ID=(select * from (select ID from CD_HYPERTENSIONFOLLOWUP where FollowUpDate like '" + DateTime.Now.Year + "%' and IDCardNo='" + model.IDCardNo + "' order by FollowUpDate desc LIMIT 1 )t)";

            return (MySQLHelper.ExecuteSql(sql) > 0);
        }

        public DataSet DtPertensionCount()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select IDCardNo ,NextFollowUpDate FROM  CD_HYPERTENSIONFOLLOWUP order by NextFollowUpDate desc ");
            return MySQLHelper.Query(builder.ToString());
        }
    }
}