using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicDiadetesVisitDAL
    {
        public int Add(ChronicDiadetesVisitModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_chronicdiadetesvisit(");
            builder.Append("CustomerID,RecordID,IDCardNo,CustomerName,VisitDate,VisitDoctor,");
            builder.Append("NextVisitDate,Symptom,SymptomOther,Hypertension,Hypotension,Weight,");
            builder.Append("BMI,DorsalisPedispulse,PhysicalSymptomMother,DailySmokeNum,DailyDrinkNum,");
            builder.Append("SportTimePerWeek,SportPerMinuteTime,StapleFooddailyg,PsychoAdjustment,ObeyDoctorBehavior,");
            builder.Append("FPG,HbAlc,ExamDate,AssistantExam,MedicationCompliance,Adr,AdrEx,HypoglyceMiarreAction,");
            builder.Append("VisitType,InsulinType,InsulinUsage,VisitWay,ReferralReason,ReferralOrg,TargetWeight,BMITarget,");
            builder.Append("DailySmokeNumTarget,DailyDrinkNumTarget,SportTimePerWeekTarget,SportPerMinuteTimeTarget,CreateBy,");
            builder.Append("CreateDate,LastUpdateBy,LastUpdateDate,IsDelete,StapleFooddailygTarget,Hight,DoctorView,IsReferral,RBG,PBG,");
            builder.Append("NextMeasures,ReferralContacts,ReferralResult,Remarks,DorsalisPedispulseType,InsulinAdjustType,InsulinAdjustUsage) ");
            builder.Append(" VALUES (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@CustomerName,@VisitDate,@VisitDoctor,@NextVisitDate,@Symptom,@SymptomOther,");
            builder.Append("@Hypertension,@Hypotension,@Weight,@BMI,@DorsalisPedispulse,@PhysicalSymptomMother,@DailySmokeNum,@DailyDrinkNum,");
            builder.Append("@SportTimePerWeek,@SportPerMinuteTime,@StapleFooddailyg,@PsychoAdjustment,@ObeyDoctorBehavior,@FPG,@HbAlc,@ExamDate,");
            builder.Append("@AssistantExam,@MedicationCompliance,@Adr,@AdrEx,@HypoglyceMiarreAction,@VisitType,@InsulinType,@InsulinUsage,@VisitWay,");
            builder.Append("@ReferralReason,@ReferralOrg,@TargetWeight,@BMITarget,@DailySmokeNumTarget,@DailyDrinkNumTarget,@SportTimePerWeekTarget,");
            builder.Append("@SportPerMinuteTimeTarget,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate,@IsDelete,@StapleFooddailygTarget,");
            builder.Append("@Hight,@DoctorView,@IsReferral,@RBG,@PBG ,");
            builder.Append("@NextMeasures,@ReferralContacts,@ReferralResult,@Remarks,@DorsalisPedispulseType,@InsulinAdjustType,@InsulinAdjustUsage) ");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerName", MySqlDbType.String, 30),
                new MySqlParameter("@VisitDate", MySqlDbType.Date), 
                new MySqlParameter("@VisitDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@NextVisitDate", MySqlDbType.Date),
                new MySqlParameter("@Symptom", MySqlDbType.String, 20),
                new MySqlParameter("@SymptomOther", MySqlDbType.String, 500),
                new MySqlParameter("@Hypertension", MySqlDbType.Int32),
                new MySqlParameter("@Hypotension", MySqlDbType.Int32), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@DorsalisPedispulse", MySqlDbType.Decimal),
                new MySqlParameter("@PhysicalSymptomMother", MySqlDbType.String, 500), 
                new MySqlParameter("@DailySmokeNum", MySqlDbType.Int32), 
                new MySqlParameter("@DailyDrinkNum", MySqlDbType.Int32),
                new MySqlParameter("@SportTimePerWeek", MySqlDbType.Int32), 
                new MySqlParameter("@SportPerMinuteTime", MySqlDbType.Int32),
                new MySqlParameter("@StapleFooddailyg", MySqlDbType.Decimal), 
                new MySqlParameter("@PsychoAdjustment", MySqlDbType.String, 500),
                new MySqlParameter("@ObeyDoctorBehavior", MySqlDbType.String, 1),
                new MySqlParameter("@FPG", MySqlDbType.Decimal), 
                new MySqlParameter("@HbAlc", MySqlDbType.Decimal),
                new MySqlParameter("@ExamDate", MySqlDbType.Date), 
                new MySqlParameter("@AssistantExam", MySqlDbType.String, 500),
                new MySqlParameter("@MedicationCompliance", MySqlDbType.String, 1),
                new MySqlParameter("@Adr", MySqlDbType.String, 1), 
                new MySqlParameter("@AdrEx", MySqlDbType.String, 500), 
                new MySqlParameter("@HypoglyceMiarreAction", MySqlDbType.String, 1), 
                new MySqlParameter("@VisitType", MySqlDbType.String, 100), 
                new MySqlParameter("@InsulinType", MySqlDbType.String, 20), 
                new MySqlParameter("@InsulinUsage", MySqlDbType.String, 500),
                new MySqlParameter("@VisitWay", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80), 
                new MySqlParameter("@TargetWeight", MySqlDbType.Decimal),
                new MySqlParameter("@BMITarget", MySqlDbType.Decimal),
                new MySqlParameter("@DailySmokeNumTarget", MySqlDbType.Int32),
                new MySqlParameter("@DailyDrinkNumTarget", MySqlDbType.Int32),
                new MySqlParameter("@SportTimePerWeekTarget", MySqlDbType.Int32),
                new MySqlParameter("@SportPerMinuteTimeTarget", MySqlDbType.Int32),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                new MySqlParameter("@StapleFooddailygTarget", MySqlDbType.Decimal),
                new MySqlParameter("@Hight", MySqlDbType.Decimal),
                new MySqlParameter("@DoctorView", MySqlDbType.String, 500),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1),
                new MySqlParameter("@RBG", MySqlDbType.Decimal),
                new MySqlParameter("@PBG", MySqlDbType.Decimal),
                new MySqlParameter("@NextMeasures", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@Remarks", MySqlDbType.String, 100),
                new MySqlParameter("@DorsalisPedispulseType", MySqlDbType.String, 1),
                new MySqlParameter("@InsulinAdjustType", MySqlDbType.String, 100),
                new MySqlParameter("@InsulinAdjustUsage", MySqlDbType.String, 100)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.CustomerName;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.VisitDoctor;
            cmdParms[6].Value = model.NextVisitDate;
            cmdParms[7].Value = model.Symptom;
            cmdParms[8].Value = model.SymptomOther;
            cmdParms[9].Value = model.Hypertension;
            cmdParms[10].Value = model.Hypotension;
            cmdParms[11].Value = model.Weight;
            cmdParms[12].Value = model.BMI;
            cmdParms[13].Value = model.DorsalisPedispulse;
            cmdParms[14].Value = model.PhysicalSymptomMother;
            cmdParms[15].Value = model.DailySmokeNum;
            cmdParms[16].Value = model.DailyDrinkNum;
            cmdParms[17].Value = model.SportTimePerWeek;
            cmdParms[18].Value = model.SportPerMinuteTime;
            cmdParms[19].Value = model.StapleFooddailyg;
            cmdParms[20].Value = model.PsychoAdjustment;
            cmdParms[21].Value = model.ObeyDoctorBehavior;
            cmdParms[22].Value = model.FPG;
            cmdParms[23].Value = model.HbAlc;
            cmdParms[24].Value = model.ExamDate;
            cmdParms[25].Value = model.AssistantExam;
            cmdParms[26].Value = model.MedicationCompliance;
            cmdParms[27].Value = model.Adr;
            cmdParms[28].Value = model.AdrEx;
            cmdParms[29].Value = model.HypoglyceMiarreAction;
            cmdParms[30].Value = model.VisitType;
            cmdParms[31].Value = model.InsulinType;
            cmdParms[32].Value = model.InsulinUsage;
            cmdParms[33].Value = model.VisitWay;
            cmdParms[34].Value = model.ReferralReason;
            cmdParms[35].Value = model.ReferralOrg;
            cmdParms[36].Value = model.TargetWeight;
            cmdParms[37].Value = model.BMITarget;
            cmdParms[38].Value = model.DailySmokeNumTarget;
            cmdParms[39].Value = model.DailyDrinkNumTarget;
            cmdParms[40].Value = model.SportTimePerWeekTarget;
            cmdParms[41].Value = model.SportPerMinuteTimeTarget;
            cmdParms[42].Value = model.CreateBy;
            cmdParms[43].Value = model.CreateDate;
            cmdParms[44].Value = model.LastUpdateBy;
            cmdParms[45].Value = model.LastUpdateDate;
            cmdParms[46].Value = model.IsDelete;
            cmdParms[47].Value = model.StapleFooddailygTarget;//Hight,DoctorView,IsReferral,RBG,PBG
            cmdParms[48].Value = model.Hight;
            cmdParms[49].Value = model.DoctorView;
            cmdParms[50].Value = model.IsReferral;
            cmdParms[51].Value = model.RBG;
            cmdParms[52].Value = model.PBG;
            cmdParms[53].Value = model.NextMeasures;
            cmdParms[54].Value = model.ReferralContacts;
            cmdParms[55].Value = model.ReferralResult;
            cmdParms[56].Value = model.Remarks;
            cmdParms[57].Value = model.DorsalisPedispulseType;
            cmdParms[58].Value = model.InsulinAdjustType;
            cmdParms[59].Value = model.InsulinAdjustUsage;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null)  return 0;

            return Convert.ToInt32(single);
        }
        
        public ChronicDiadetesVisitModel DataRowToModel(DataRow row)
        {
            ChronicDiadetesVisitModel    chronicDiadetesVisitModel = new ChronicDiadetesVisitModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["CustomerName"] != null) && (row["CustomerName"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.CustomerName = row["CustomerName"].ToString();
                }
                if (((row["VisitDate"] != null) && (row["VisitDate"] != DBNull.Value)) && (row["VisitDate"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.VisitDate = new DateTime?(DateTime.Parse(row["VisitDate"].ToString()));
                }
                if ((row["VisitDoctor"] != null) && (row["VisitDoctor"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.VisitDoctor = row["VisitDoctor"].ToString();
                }
                if (((row["NextVisitDate"] != null) && (row["NextVisitDate"] != DBNull.Value)) && (row["NextVisitDate"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.NextVisitDate = new DateTime?(DateTime.Parse(row["NextVisitDate"].ToString()));
                }
                if ((row["Symptom"] != null) && (row["Symptom"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.Symptom = row["Symptom"].ToString();
                }
                if ((row["SymptomOther"] != null) && (row["SymptomOther"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.SymptomOther = row["SymptomOther"].ToString();
                }
                if (((row["Hypertension"] != null) && (row["Hypertension"] != DBNull.Value)) && (row["Hypertension"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.Hypertension = new decimal?(decimal.Parse(row["Hypertension"].ToString()));
                }
                if (((row["Hypotension"] != null) && (row["Hypotension"] != DBNull.Value)) && (row["Hypotension"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.Hypotension = new decimal?(decimal.Parse(row["Hypotension"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if (((row["BMI"] != null) && (row["BMI"] != DBNull.Value)) && (row["BMI"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.BMI = new decimal?(decimal.Parse(row["BMI"].ToString()));
                }
                if (((row["DorsalisPedispulse"] != null) && (row["DorsalisPedispulse"] != DBNull.Value)) && (row["DorsalisPedispulse"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.DorsalisPedispulse = new decimal?(decimal.Parse(row["DorsalisPedispulse"].ToString()));
                }
                if ((row["PhysicalSymptomMother"] != null) && (row["PhysicalSymptomMother"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.PhysicalSymptomMother = row["PhysicalSymptomMother"].ToString();
                }
                if (((row["DailySmokeNum"] != null) && (row["DailySmokeNum"] != DBNull.Value)) && (row["DailySmokeNum"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.DailySmokeNum = new decimal?(decimal.Parse(row["DailySmokeNum"].ToString()));
                }
                if (((row["DailyDrinkNum"] != null) && (row["DailyDrinkNum"] != DBNull.Value)) && (row["DailyDrinkNum"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.DailyDrinkNum = new int?(int.Parse(row["DailyDrinkNum"].ToString()));
                }
                if (((row["SportTimePerWeek"] != null) && (row["SportTimePerWeek"] != DBNull.Value)) && (row["SportTimePerWeek"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.SportTimePerWeek = new decimal?(decimal.Parse(row["SportTimePerWeek"].ToString()));
                }
                if (((row["SportPerMinuteTime"] != null) && (row["SportPerMinuteTime"] != DBNull.Value)) && (row["SportPerMinuteTime"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.SportPerMinuteTime = new decimal?(decimal.Parse(row["SportPerMinuteTime"].ToString()));
                }
                if (((row["StapleFooddailyg"] != null) && (row["StapleFooddailyg"] != DBNull.Value)) && (row["StapleFooddailyg"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.StapleFooddailyg = new decimal?(decimal.Parse(row["StapleFooddailyg"].ToString()));
                }
                if ((row["PsychoAdjustment"] != null) && (row["PsychoAdjustment"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.PsychoAdjustment = row["PsychoAdjustment"].ToString();
                }
                if ((row["ObeyDoctorBehavior"] != null) && (row["ObeyDoctorBehavior"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.ObeyDoctorBehavior = row["ObeyDoctorBehavior"].ToString();
                }
                if (((row["FPG"] != null) && (row["FPG"] != DBNull.Value)) && (row["FPG"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.FPG = new decimal?(decimal.Parse(row["FPG"].ToString()));
                }
                if (((row["HbAlc"] != null) && (row["HbAlc"] != DBNull.Value)) && (row["HbAlc"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.HbAlc = new decimal?(decimal.Parse(row["HbAlc"].ToString()));
                }
                if (((row["ExamDate"] != null) && (row["ExamDate"] != DBNull.Value)) && (row["ExamDate"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.ExamDate = new DateTime?(DateTime.Parse(row["ExamDate"].ToString()));
                }
                if ((row["AssistantExam"] != null) && (row["AssistantExam"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.AssistantExam = row["AssistantExam"].ToString();
                }
                if ((row["MedicationCompliance"] != null) && (row["MedicationCompliance"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.MedicationCompliance = row["MedicationCompliance"].ToString();
                }
                if ((row["Adr"] != null) && (row["Adr"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.Adr = row["Adr"].ToString();
                }
                if ((row["AdrEx"] != null) && (row["AdrEx"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.AdrEx = row["AdrEx"].ToString();
                }
                if ((row["HypoglyceMiarreAction"] != null) && (row["HypoglyceMiarreAction"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.HypoglyceMiarreAction = row["HypoglyceMiarreAction"].ToString();
                }
                if ((row["VisitType"] != null) && (row["VisitType"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.VisitType = row["VisitType"].ToString();
                }
                if ((row["InsulinType"] != null) && (row["InsulinType"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.InsulinType = row["InsulinType"].ToString();
                }
                if ((row["InsulinUsage"] != null) && (row["InsulinUsage"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.InsulinUsage = row["InsulinUsage"].ToString();
                }
                if ((row["VisitWay"] != null) && (row["VisitWay"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.VisitWay = row["VisitWay"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["ReferralOrg"] != null) && (row["ReferralOrg"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.ReferralOrg = row["ReferralOrg"].ToString();
                }
                if (((row["TargetWeight"] != null) && (row["TargetWeight"] != DBNull.Value)) && (row["TargetWeight"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.TargetWeight = new decimal?(decimal.Parse(row["TargetWeight"].ToString()));
                }
                if (((row["BMITarget"] != null) && (row["BMITarget"] != DBNull.Value)) && (row["BMITarget"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.BMITarget = new decimal?(decimal.Parse(row["BMITarget"].ToString()));
                }
                if (((row["DailySmokeNumTarget"] != null) && (row["DailySmokeNumTarget"] != DBNull.Value)) && (row["DailySmokeNumTarget"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.DailySmokeNumTarget = new decimal?(decimal.Parse(row["DailySmokeNumTarget"].ToString()));
                }
                if (((row["DailyDrinkNumTarget"] != null) && (row["DailyDrinkNumTarget"] != DBNull.Value)) && (row["DailyDrinkNumTarget"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.DailyDrinkNumTarget = new decimal?(decimal.Parse(row["DailyDrinkNumTarget"].ToString()));
                }
                if (((row["SportTimePerWeekTarget"] != null) && (row["SportTimePerWeekTarget"] != DBNull.Value)) && (row["SportTimePerWeekTarget"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.SportTimePerWeekTarget = new decimal?(decimal.Parse(row["SportTimePerWeekTarget"].ToString()));
                }
                if (((row["SportPerMinuteTimeTarget"] != null) && (row["SportPerMinuteTimeTarget"] != DBNull.Value)) && (row["SportPerMinuteTimeTarget"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.SportPerMinuteTimeTarget = new decimal?(decimal.Parse(row["SportPerMinuteTimeTarget"].ToString()));
                }
                if (((row["CreateBy"] != null) && (row["CreateBy"] != DBNull.Value)) && (row["CreateBy"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.CreateBy = row["CreateBy"].ToString();
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.CreateDate = new DateTime?(DateTime.Parse(row["CreateDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.LastUpdateBy = row["LastUpdateBy"].ToString();
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDelete"] != null) && (row["IsDelete"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.IsDelete = row["IsDelete"].ToString();
                }
                if (((row["StapleFooddailyg"] != null) && (row["StapleFooddailyg"] != DBNull.Value)) && (row["StapleFooddailyg"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.StapleFooddailyg = new decimal?(decimal.Parse(row["StapleFooddailyg"].ToString()));
                }
                if (((row["StapleFooddailygTarget"] != null) && (row["StapleFooddailygTarget"] != DBNull.Value)) && (row["StapleFooddailygTarget"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.StapleFooddailygTarget = new decimal?(decimal.Parse(row["StapleFooddailygTarget"].ToString()));
                }
                if (((row["Hight"] != null) && (row["Hight"] != DBNull.Value)) && (row["Hight"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.Hight = new decimal?(decimal.Parse(row["Hight"].ToString()));
                }
                if ((row["DoctorView"] != null) && (row["DoctorView"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.DoctorView = row["DoctorView"].ToString();
                }
                if ((row["IsReferral"] != null) && (row["IsReferral"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.IsReferral = row["IsReferral"].ToString();
                }
                if (((row["RBG"] != null) && (row["RBG"] != DBNull.Value)) && (row["RBG"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.RBG = new decimal?(decimal.Parse(row["RBG"].ToString()));
                }
                if (((row["PBG"] != null) && (row["PBG"] != DBNull.Value)) && (row["PBG"].ToString() != ""))
                {
                    chronicDiadetesVisitModel.PBG = new decimal?(decimal.Parse(row["PBG"].ToString()));
                }
                if ((row["NextMeasures"] != null) && (row["NextMeasures"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.NextMeasures = row["NextMeasures"].ToString();
                }
                if ((row["ReferralContacts"] != null) && (row["ReferralContacts"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.ReferralContacts = row["ReferralContacts"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.ReferralResult = row["ReferralResult"].ToString();
                }
                if ((row["Remarks"] != null) && (row["Remarks"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.Remarks = row["Remarks"].ToString();
                }
                if ((row["DorsalisPedispulseType"] != null) && (row["DorsalisPedispulseType"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.DorsalisPedispulseType = row["DorsalisPedispulseType"].ToString();
                }
                if ((row["InsulinAdjustType"] != null) && (row["InsulinAdjustType"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.InsulinAdjustType = row["InsulinAdjustType"].ToString();
                }
                if ((row["InsulinAdjustUsage"] != null) && (row["InsulinAdjustUsage"] != DBNull.Value))
                {
                    chronicDiadetesVisitModel.InsulinAdjustUsage = row["InsulinAdjustUsage"].ToString();
                }
            }
            return chronicDiadetesVisitModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chronicdiadetesvisit ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public ChronicDiadetesVisitModel ExistsCheckDate(ChronicDiadetesVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,CustomerName,");
            builder.Append("VisitDate,VisitDoctor,NextVisitDate,Symptom,SymptomOther,Hypertension,");
            builder.Append(" Hypotension,Weight,BMI,DorsalisPedispulse,PhysicalSymptomMother,DailySmokeNum,");
            builder.Append("DailyDrinkNum,SportTimePerWeek,SportPerMinuteTime,StapleFooddailyg,PsychoAdjustment,");
            builder.Append("ObeyDoctorBehavior,FPG,HbAlc,ExamDate,AssistantExam,MedicationCompliance,Adr,AdrEx,HypoglyceMiarreAction,");
            builder.Append("VisitType,InsulinType,InsulinUsage,VisitWay,ReferralReason,ReferralOrg,TargetWeight,BMITarget,");
            builder.Append("DailySmokeNumTarget,DailyDrinkNumTarget,SportTimePerWeekTarget,SportPerMinuteTimeTarget,CreateBy,");
            builder.Append("CreateDate,LastUpdateBy,LastUpdateDate,IsDelete,StapleFooddailygTarget,");
            builder.Append("Hight,DoctorView,IsReferral,RBG,PBG, ");
            builder.Append("NextMeasures,ReferralContacts,ReferralResult,Remarks,DorsalisPedispulseType,InsulinAdjustType,InsulinAdjustUsage ");
            builder.Append(" FROM tbl_chronicdiadetesvisit ");
            builder.Append(" where VisitDate = @VisitDate and IDCardNo =@IDCardNo "); 
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@VisitDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };
            cmdParms[0].Value = model.VisitDate;
            cmdParms[1].Value = model.IDCardNo;
            new ChronicDiadetesVisitModel();
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
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,CustomerName,");
            builder.Append("VisitDate,VisitDoctor,NextVisitDate,Symptom,SymptomOther,Hypertension,");
            builder.Append(" Hypotension,Weight,BMI,DorsalisPedispulse,PhysicalSymptomMother,DailySmokeNum,");
            builder.Append("DailyDrinkNum,SportTimePerWeek,SportPerMinuteTime,StapleFooddailyg,PsychoAdjustment,");
            builder.Append("ObeyDoctorBehavior,FPG,HbAlc,ExamDate,AssistantExam,MedicationCompliance,Adr,AdrEx,HypoglyceMiarreAction,");
            builder.Append("VisitType,InsulinType,InsulinUsage,VisitWay,ReferralReason,ReferralOrg,TargetWeight,BMITarget,");
            builder.Append("DailySmokeNumTarget,DailyDrinkNumTarget,SportTimePerWeekTarget,SportPerMinuteTimeTarget,CreateBy,");
            builder.Append("CreateDate,LastUpdateBy,LastUpdateDate,IsDelete,StapleFooddailygTarget,");
            builder.Append("Hight,DoctorView,IsReferral,RBG,PBG, ");
            builder.Append("NextMeasures,ReferralContacts,ReferralResult,Remarks,DorsalisPedispulseType,InsulinAdjustType,InsulinAdjustUsage ");
            builder.Append(" FROM tbl_chronicdiadetesvisit ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }
   
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select C.IDCardNo,C.ID,T.RecordID,T.CustomerName,T.Nation,T.Sex,T.Birthday,T.Phone,");
            builder.Append("T.Doctor,T.Address,T.HouseHoldAddress,T.Minority,");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate, ");
            builder.Append("(case C.VisitDate when null then null when '' then null else C.VisitDate end)VisitDate, ");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName ");
            builder.Append(" from tbl_chronicdiadetesvisit C inner join tbl_recordsbaseinfo T on T.IDCardNo = C.IDCardNo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by  " + orderby);
            }
            else
            {
                builder.Append(" order by VisitDate desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }

        public ChronicDiadetesVisitModel GetModels (string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,CustomerName,");
            builder.Append("VisitDate,VisitDoctor,NextVisitDate,Symptom,");
            builder.Append("SymptomOther,Hypertension,Hypotension,Weight,BMI,DorsalisPedispulse,PhysicalSymptomMother,");
            builder.Append("DailySmokeNum,DailyDrinkNum,SportTimePerWeek,SportPerMinuteTime,StapleFooddailyg,PsychoAdjustment,");
            builder.Append("ObeyDoctorBehavior,FPG,HbAlc,ExamDate,AssistantExam,MedicationCompliance,");
            builder.Append("Adr,AdrEx,HypoglyceMiarreAction,VisitType,InsulinType,InsulinUsage,VisitWay,ReferralReason,ReferralOrg,");
            builder.Append("TargetWeight,BMITarget,DailySmokeNumTarget,DailyDrinkNumTarget,SportTimePerWeekTarget,SportPerMinuteTimeTarget,");
            builder.Append("CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDelete,StapleFooddailygTarget,Hight,DoctorView,IsReferral,RBG,PBG, ");
            builder.Append("NextMeasures,ReferralContacts,ReferralResult,Remarks,DorsalisPedispulseType,InsulinAdjustType,InsulinAdjustUsage ");
            builder.Append(" from tbl_chronicdiadetesvisit  ");
            builder.Append(" where IDCardNo=@IDCardNo order by VisitDate desc limit 0,1");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new ChronicDiadetesVisitModel();
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

            builder.Append("SELECT * FROM tbl_ChronicDiadetesVisit ");
            builder.Append(" WHERE IDCardNo=@IDCardNo ");
            builder.Append(" ORDER BY VisitDate DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };

            cmdParms[0].Value = IDCardNo;

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public ChronicDiadetesVisitModel GetModelID(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,CustomerName,");
            builder.Append("VisitDate,VisitDoctor,NextVisitDate,Symptom,");
            builder.Append("SymptomOther,Hypertension,Hypotension,Weight,BMI,DorsalisPedispulse,PhysicalSymptomMother,");
            builder.Append("DailySmokeNum,DailyDrinkNum,SportTimePerWeek,SportPerMinuteTime,StapleFooddailyg,PsychoAdjustment,");
            builder.Append("ObeyDoctorBehavior,FPG,HbAlc,ExamDate,AssistantExam,MedicationCompliance,");
            builder.Append("Adr,AdrEx,HypoglyceMiarreAction,VisitType,InsulinType,InsulinUsage,VisitWay,ReferralReason,ReferralOrg,");
            builder.Append("TargetWeight,BMITarget,DailySmokeNumTarget,DailyDrinkNumTarget,SportTimePerWeekTarget,SportPerMinuteTimeTarget,");
            builder.Append("CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDelete,StapleFooddailygTarget,Hight,DoctorView,IsReferral,RBG,PBG, ");
            builder.Append("NextMeasures,ReferralContacts,ReferralResult,Remarks,DorsalisPedispulseType,InsulinAdjustType,InsulinAdjustUsage ");
            builder.Append(" from tbl_chronicdiadetesvisit ");
            builder.Append(" where ID=@ID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = ID;
            new ChronicDiadetesVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM tbl_chronicdiadetesvisit C ");
            builder.Append("left join tbl_recordsbaseinfo T on T.IDCardNo = C.IDCardNo   ");
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

        public bool Update(ChronicDiadetesVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_chronicdiadetesvisit set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CustomerName=@CustomerName,");
            builder.Append("VisitDate=@VisitDate,");
            builder.Append("VisitDoctor=@VisitDoctor,");
            builder.Append("NextVisitDate=@NextVisitDate,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("SymptomOther=@SymptomOther,");
            builder.Append("Hypertension=@Hypertension,");
            builder.Append("Hypotension=@Hypotension,");
            builder.Append("Weight=@Weight,");
            builder.Append("BMI=@BMI,");
            builder.Append("DorsalisPedispulse=@DorsalisPedispulse,");
            builder.Append("PhysicalSymptomMother=@PhysicalSymptomMother,");
            builder.Append("DailySmokeNum=@DailySmokeNum,");
            builder.Append("DailyDrinkNum=@DailyDrinkNum,");
            builder.Append("SportTimePerWeek=@SportTimePerWeek,");
            builder.Append("SportPerMinuteTime=@SportPerMinuteTime,");
            builder.Append("StapleFooddailyg=@StapleFooddailyg,");
            builder.Append("PsychoAdjustment=@PsychoAdjustment,");
            builder.Append("ObeyDoctorBehavior=@ObeyDoctorBehavior,");
            builder.Append("FPG=@FPG,");
            builder.Append("HbAlc=@HbAlc,");
            builder.Append("ExamDate=@ExamDate,");
            builder.Append("AssistantExam=@AssistantExam,");
            builder.Append("MedicationCompliance=@MedicationCompliance,");
            builder.Append("Adr=@Adr,");
            builder.Append("AdrEx=@AdrEx,");
            builder.Append("HypoglyceMiarreAction=@HypoglyceMiarreAction,");
            builder.Append("VisitType=@VisitType,");
            builder.Append("InsulinType=@InsulinType,");
            builder.Append("InsulinUsage=@InsulinUsage,");
            builder.Append("VisitWay=@VisitWay,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("TargetWeight=@TargetWeight,");
            builder.Append("BMITarget=@BMITarget,");
            builder.Append("DailySmokeNumTarget=@DailySmokeNumTarget,");
            builder.Append("DailyDrinkNumTarget=@DailyDrinkNumTarget,");
            builder.Append("SportTimePerWeekTarget=@SportTimePerWeekTarget,");
            builder.Append("SportPerMinuteTimeTarget=@SportPerMinuteTimeTarget,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDelete=@IsDelete,");
            builder.Append("StapleFooddailygTarget=@StapleFooddailygTarget,");
            builder.Append("Hight=@Hight, ");
            builder.Append("DoctorView=@DoctorView, ");
            builder.Append("IsReferral=@IsReferral, ");
            builder.Append("RBG=@RBG, ");
            builder.Append("PBG=@PBG, ");
            builder.Append("NextMeasures=@NextMeasures, ");
            builder.Append("ReferralContacts=@ReferralContacts, ");
            builder.Append("ReferralResult=@ReferralResult, ");
            builder.Append("Remarks=@Remarks, ");
            builder.Append("DorsalisPedispulseType=@DorsalisPedispulseType, ");
            builder.Append("InsulinAdjustType=@InsulinAdjustType, ");
            builder.Append("InsulinAdjustUsage=@InsulinAdjustUsage ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CustomerName", MySqlDbType.String, 30),
                new MySqlParameter("@VisitDate", MySqlDbType.Date), 
                new MySqlParameter("@VisitDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@NextVisitDate", MySqlDbType.Date), 
                new MySqlParameter("@Symptom", MySqlDbType.String, 20),
                new MySqlParameter("@SymptomOther", MySqlDbType.String, 500),
                new MySqlParameter("@Hypertension", MySqlDbType.Int32),
                new MySqlParameter("@Hypotension", MySqlDbType.Int32),
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@DorsalisPedispulse", MySqlDbType.Decimal),
                new MySqlParameter("@PhysicalSymptomMother", MySqlDbType.String, 500), 
                new MySqlParameter("@DailySmokeNum", MySqlDbType.Int32), 
                new MySqlParameter("@DailyDrinkNum", MySqlDbType.Int32), 
                new MySqlParameter("@SportTimePerWeek", MySqlDbType.Int32),
                new MySqlParameter("@SportPerMinuteTime", MySqlDbType.Int32), 
                new MySqlParameter("@StapleFooddailyg", MySqlDbType.Decimal),
                new MySqlParameter("@PsychoAdjustment", MySqlDbType.String, 500), 
                new MySqlParameter("@ObeyDoctorBehavior", MySqlDbType.String, 1), 
                new MySqlParameter("@FPG", MySqlDbType.Decimal),
                new MySqlParameter("@HbAlc", MySqlDbType.Decimal),
                new MySqlParameter("@ExamDate", MySqlDbType.Date), 
                new MySqlParameter("@AssistantExam", MySqlDbType.String, 500),
                new MySqlParameter("@MedicationCompliance", MySqlDbType.String, 1), 
                new MySqlParameter("@Adr", MySqlDbType.String, 1),
                new MySqlParameter("@AdrEx", MySqlDbType.String, 500), 
                new MySqlParameter("@HypoglyceMiarreAction", MySqlDbType.String, 1),
                new MySqlParameter("@VisitType", MySqlDbType.String, 100), 
                new MySqlParameter("@InsulinType", MySqlDbType.String, 20), 
                new MySqlParameter("@InsulinUsage", MySqlDbType.String, 500),
                new MySqlParameter("@VisitWay", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralReason", MySqlDbType.String, 500), 
                new MySqlParameter("@ReferralOrg", MySqlDbType.String, 80),
                new MySqlParameter("@TargetWeight", MySqlDbType.Decimal), 
                new MySqlParameter("@BMITarget", MySqlDbType.Decimal), 
                new MySqlParameter("@DailySmokeNumTarget", MySqlDbType.Int32),
                new MySqlParameter("@DailyDrinkNumTarget", MySqlDbType.Int32),
                new MySqlParameter("@SportTimePerWeekTarget", MySqlDbType.Int32), 
                new MySqlParameter("@SportPerMinuteTimeTarget", MySqlDbType.Int32),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1), 
                new MySqlParameter("@StapleFooddailygTarget", MySqlDbType.Decimal), 
                new MySqlParameter("@Hight", MySqlDbType.Decimal), 
                new MySqlParameter("@DoctorView", MySqlDbType.String, 500),
                new MySqlParameter("@IsReferral", MySqlDbType.String, 1),
                new MySqlParameter("@RBG", MySqlDbType.Decimal), 
                new MySqlParameter("@PBG", MySqlDbType.Decimal),
                new MySqlParameter("@NextMeasures", MySqlDbType.String, 1),
                new MySqlParameter("@ReferralContacts", MySqlDbType.String, 100),
                new MySqlParameter("@ReferralResult", MySqlDbType.String, 1),
                new MySqlParameter("@Remarks", MySqlDbType.String, 100),
                new MySqlParameter("@DorsalisPedispulseType", MySqlDbType.String, 1),
                new MySqlParameter("@InsulinAdjustType", MySqlDbType.String, 100),
                new MySqlParameter("@InsulinAdjustUsage", MySqlDbType.String, 100),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.CustomerName;
            cmdParms[4].Value = model.VisitDate;
            cmdParms[5].Value = model.VisitDoctor;
            cmdParms[6].Value = model.NextVisitDate;
            cmdParms[7].Value = model.Symptom;
            cmdParms[8].Value = model.SymptomOther;
            cmdParms[9].Value = model.Hypertension;
            cmdParms[10].Value = model.Hypotension;
            cmdParms[11].Value = model.Weight;
            cmdParms[12].Value = model.BMI;
            cmdParms[13].Value = model.DorsalisPedispulse;
            cmdParms[14].Value = model.PhysicalSymptomMother;
            cmdParms[15].Value = model.DailySmokeNum;
            cmdParms[16].Value = model.DailyDrinkNum;
            cmdParms[17].Value = model.SportTimePerWeek;
            cmdParms[18].Value = model.SportPerMinuteTime;
            cmdParms[19].Value = model.StapleFooddailyg;
            cmdParms[20].Value = model.PsychoAdjustment;
            cmdParms[21].Value = model.ObeyDoctorBehavior;
            cmdParms[22].Value = model.FPG;
            cmdParms[23].Value = model.HbAlc;
            cmdParms[24].Value = model.ExamDate;
            cmdParms[25].Value = model.AssistantExam;
            cmdParms[26].Value = model.MedicationCompliance;
            cmdParms[27].Value = model.Adr;
            cmdParms[28].Value = model.AdrEx;
            cmdParms[29].Value = model.HypoglyceMiarreAction;
            cmdParms[30].Value = model.VisitType;
            cmdParms[31].Value = model.InsulinType;
            cmdParms[32].Value = model.InsulinUsage;
            cmdParms[33].Value = model.VisitWay;
            cmdParms[34].Value = model.ReferralReason;
            cmdParms[35].Value = model.ReferralOrg;
            cmdParms[36].Value = model.TargetWeight;
            cmdParms[37].Value = model.BMITarget;
            cmdParms[38].Value = model.DailySmokeNumTarget;
            cmdParms[39].Value = model.DailyDrinkNumTarget;
            cmdParms[40].Value = model.SportTimePerWeekTarget;
            cmdParms[41].Value = model.SportPerMinuteTimeTarget;
            cmdParms[42].Value = model.CreateBy;
            cmdParms[43].Value = model.CreateDate;
            cmdParms[44].Value = model.LastUpdateBy;
            cmdParms[45].Value = model.LastUpdateDate;
            cmdParms[46].Value = model.IsDelete;
            cmdParms[47].Value = model.StapleFooddailygTarget;
            cmdParms[48].Value = model.Hight;
            cmdParms[49].Value = model.DoctorView;
            cmdParms[50].Value = model.IsReferral;
            cmdParms[51].Value = model.RBG;
            cmdParms[52].Value = model.PBG;
            cmdParms[53].Value = model.NextMeasures;
            cmdParms[54].Value = model.ReferralContacts;
            cmdParms[55].Value = model.ReferralResult;
            cmdParms[56].Value = model.Remarks;
            cmdParms[57].Value = model.DorsalisPedispulseType;
            cmdParms[58].Value = model.InsulinAdjustType;
            cmdParms[59].Value = model.InsulinAdjustUsage;
            cmdParms[60].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateDate(ChronicDiadetesVisitModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("update tbl_chronicdiadetesvisit set ");
            decimal d;
            if (decimal.TryParse( model.Hypertension.ToString(),out d))
            {
                builder.Append("Hypertension='"+ d + "',");
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
            builder.Append("DailySmokeNumTarget='" + model.DailySmokeNumTarget + "',");
            builder.Append("DailyDrinkNumTarget='" + model.DailyDrinkNumTarget + "',");
            builder.Append("SportTimePerWeekTarget='" + model.SportTimePerWeekTarget + "',");
            builder.Append("SportPerMinuteTimeTarget='" + model.SportPerMinuteTimeTarget + "',");
            if (decimal.TryParse(model.FPG.ToString(), out d))
            {
                builder.Append("FPG='" + d + "',");
            }
            if (decimal.TryParse(model.HbAlc.ToString(), out d))
            {
                builder.Append("HbAlc='" + d + "',");
            }
            if (model.BMI < 24)
            {
                builder.Append("TargetWeight=null,");
            }
            else
            {
                if (decimal.TryParse(model.TargetWeight.ToString(), out d))
                {
                    builder.Append("TargetWeight='" + d + "',");
                }
            }
            
            string sql = builder.ToString();
            sql =sql.Substring( 0,sql.LastIndexOf(','));

            sql+= " where ID=(select * from (select ID from tbl_chronicdiadetesvisit where VisitDate like '" + DateTime.Now.Year+"%' and IDCardNo='"+model.IDCardNo+ "' order by VisitDate desc LIMIT 1 )t)";

            return (MySQLHelper.ExecuteSql(sql) > 0);
        }
        
        public DataSet DtDiadetesCount()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select IDCardNo , NextVisitDate FROM  tbl_chronicdiadetesvisit order by NextVisitDate desc ");
            return MySQLHelper.Query(builder.ToString());
        }
    }
}