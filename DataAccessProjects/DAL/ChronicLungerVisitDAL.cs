namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicLungerVisitDAL
    {
        public int Add(ChronicLungerVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_chroniclungervisit(");
            builder.Append("RecordID,CustomerID,IDCardNo,CustomerName,FollowupDate,VisitDoctor,");
            builder.Append("CureMonth,Supervisor,FollowupWay,Symptom,SymptomEx,SmokeDayNum,DayDrinkVolume,");
            builder.Append("ChemotherapyScheme,MedicationCompliance,DrugType,OmissiveTimes,Adr,AdrEx,");
            builder.Append("Complication,ComplicationEx,ReferralOrg,ReferralReason,ReferralResult,");
            builder.Append("HandleView,NextVisitDate,StopCureDate,StopCureReason,ShouldVisitTimes,");
            builder.Append("VisitTimes,ShouldPharmacyTimes,PharmacyTimes,EstimateDoctor,PharmacyRate,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,NextSmokeDayNum,NextDayDrinkVolume,VisitCount,OutKey )");
            builder.Append(" values (");
            builder.Append("@RecordID,@CustomerID,@IDCardNo,@CustomerName,@FollowupDate,@VisitDoctor,");
            builder.Append("@CureMonth,@Supervisor,@FollowupWay,@Symptom,@SymptomEx,@SmokeDayNum,@DayDrinkVolume,");
            builder.Append("@ChemotherapyScheme,@MedicationCompliance,@DrugType,@OmissiveTimes,@Adr,@AdrEx,");
            builder.Append("@Complication,@ComplicationEx,@ReferralOrg,@ReferralReason,@ReferralResult,");
            builder.Append("@HandleView,@NextVisitDate,@StopCureDate,@StopCureReason,@ShouldVisitTimes,");
            builder.Append("@VisitTimes,@ShouldPharmacyTimes,@PharmacyTimes,@EstimateDoctor,@PharmacyRate,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@NextSmokeDayNum,@NextDayDrinkVolume,@VisitCount,@OutKey)");
            builder.Append(";select @@IDENTITY");
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
            cmdParms[42].Value = model.OUTKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public ChronicLungerVisitModel DataRowToModel(DataRow row)
        {
            ChronicLungerVisitModel chronicLungerVisitModel = new ChronicLungerVisitModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicLungerVisitModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicLungerVisitModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicLungerVisitModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicLungerVisitModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["CustomerName"] != null) && (row["CustomerName"] != DBNull.Value))
                {
                    chronicLungerVisitModel.CustomerName = row["CustomerName"].ToString();
                }
                if (((row["FollowupDate"] != null) && (row["FollowupDate"] != DBNull.Value)) && (row["FollowupDate"].ToString() != ""))
                {
                    chronicLungerVisitModel.FollowupDate = new DateTime?(DateTime.Parse(row["FollowupDate"].ToString()));
                }
                if ((row["VisitDoctor"] != null) && (row["VisitDoctor"] != DBNull.Value))
                {
                    chronicLungerVisitModel.VisitDoctor = row["VisitDoctor"].ToString();
                }
                if ((row["CureMonth"] != null) && (row["CureMonth"] != DBNull.Value))
                {
                    chronicLungerVisitModel.CureMonth = row["CureMonth"].ToString();
                }
                if ((row["Supervisor"] != null) && (row["Supervisor"] != DBNull.Value))
                {
                    chronicLungerVisitModel.Supervisor = row["Supervisor"].ToString();
                }
                if ((row["FollowupWay"] != null) && (row["FollowupWay"] != DBNull.Value))
                {
                    chronicLungerVisitModel.FollowupWay = row["FollowupWay"].ToString();
                }
                if ((row["Symptom"] != null) && (row["Symptom"] != DBNull.Value))
                {
                    chronicLungerVisitModel.Symptom = row["Symptom"].ToString();
                }
                if ((row["SymptomEx"] != null) && (row["SymptomEx"] != DBNull.Value))
                {
                    chronicLungerVisitModel.SymptomEx = row["SymptomEx"].ToString();
                }
                if (((row["SmokeDayNum"] != null) && (row["SmokeDayNum"] != DBNull.Value)) && (row["SmokeDayNum"].ToString() != ""))
                {
                    chronicLungerVisitModel.SmokeDayNum = new decimal?(decimal.Parse(row["SmokeDayNum"].ToString()));
                }
                if (((row["NextSmokeDayNum"] != null) && (row["NextSmokeDayNum"] != DBNull.Value)) && (row["NextSmokeDayNum"].ToString() != ""))
                {
                    chronicLungerVisitModel.NextSmokeDayNum = new decimal?(decimal.Parse(row["NextSmokeDayNum"].ToString()));
                }
                if (((row["DayDrinkVolume"] != null) && (row["DayDrinkVolume"] != DBNull.Value)) && (row["DayDrinkVolume"].ToString() != ""))
                {
                    chronicLungerVisitModel.DayDrinkVolume = new decimal?(decimal.Parse(row["DayDrinkVolume"].ToString()));
                }
                if (((row["NextDayDrinkVolume"] != null) && (row["NextDayDrinkVolume"] != DBNull.Value)) && (row["NextDayDrinkVolume"].ToString() != ""))
                {
                    chronicLungerVisitModel.NextDayDrinkVolume = new decimal?(decimal.Parse(row["NextDayDrinkVolume"].ToString()));
                }
                if ((row["ChemotherapyScheme"] != null) && (row["ChemotherapyScheme"] != DBNull.Value))
                {
                    chronicLungerVisitModel.ChemotherapyScheme = row["ChemotherapyScheme"].ToString();
                }
                if ((row["MedicationCompliance"] != null) && (row["MedicationCompliance"] != DBNull.Value))
                {
                    chronicLungerVisitModel.MedicationCompliance = row["MedicationCompliance"].ToString();
                }
                if ((row["DrugType"] != null) && (row["DrugType"] != DBNull.Value))
                {
                    chronicLungerVisitModel.DrugType = row["DrugType"].ToString();
                }
                if (((row["OmissiveTimes"] != null) && (row["OmissiveTimes"] != DBNull.Value)) && (row["OmissiveTimes"].ToString() != ""))
                {
                    chronicLungerVisitModel.OmissiveTimes = int.Parse(row["OmissiveTimes"].ToString());
                }
                if ((row["Adr"] != null) && (row["Adr"] != DBNull.Value))
                {
                    chronicLungerVisitModel.Adr = row["Adr"].ToString();
                }
                if ((row["AdrEx"] != null) && (row["AdrEx"] != DBNull.Value))
                {
                    chronicLungerVisitModel.AdrEx = row["AdrEx"].ToString();
                }
                if ((row["Complication"] != null) && (row["Complication"] != DBNull.Value)) 
                {
                    chronicLungerVisitModel.Complication =row["Complication"].ToString();
                }
                if ((row["ComplicationEx"] != null) && (row["ComplicationEx"] != DBNull.Value)) 
                {
                    chronicLungerVisitModel.ComplicationEx = row["ComplicationEx"].ToString();
                }
                if ((row["ReferralOrg"] != null) && (row["ReferralOrg"] != DBNull.Value))
                {
                    chronicLungerVisitModel.ReferralOrg = row["ReferralOrg"].ToString();
                }
                if ((row["ReferralReason"] != null) && (row["ReferralReason"] != DBNull.Value))
                {
                    chronicLungerVisitModel.ReferralReason = row["ReferralReason"].ToString();
                }
                if ((row["ReferralResult"] != null) && (row["ReferralResult"] != DBNull.Value))
                {
                    chronicLungerVisitModel.ReferralResult = row["ReferralResult"].ToString();
                }
                if ((row["HandleView"] != null) && (row["HandleView"] != DBNull.Value))
                {
                    chronicLungerVisitModel.HandleView = row["HandleView"].ToString();
                }
                if (((row["NextVisitDate"] != null) && (row["NextVisitDate"] != DBNull.Value)) && (row["NextVisitDate"].ToString() != ""))
                {
                    chronicLungerVisitModel.NextVisitDate = new DateTime?(DateTime.Parse(row["NextVisitDate"].ToString()));
                }
                if (((row["StopCureDate"] != null) && (row["StopCureDate"] != DBNull.Value)) && (row["StopCureDate"].ToString() != ""))
                {
                    chronicLungerVisitModel.StopCureDate = new DateTime?(DateTime.Parse(row["StopCureDate"].ToString()));
                }
                if ((row["StopCureReason"] != null) && (row["StopCureReason"] != DBNull.Value))
                {
                    chronicLungerVisitModel.StopCureReason = row["StopCureReason"].ToString();
                }
                if (((row["ShouldVisitTimes"] != null) && (row["ShouldVisitTimes"] != DBNull.Value)) && (row["ShouldVisitTimes"].ToString() != ""))
                {
                    chronicLungerVisitModel.ShouldVisitTimes = int.Parse(row["ShouldVisitTimes"].ToString());
                }
                if (((row["VisitTimes"] != null) && (row["VisitTimes"] != DBNull.Value)) && (row["VisitTimes"].ToString() != ""))
                {
                    chronicLungerVisitModel.VisitTimes = int.Parse(row["VisitTimes"].ToString());
                }
                if (((row["ShouldPharmacyTimes"] != null) && (row["ShouldPharmacyTimes"] != DBNull.Value)) && (row["ShouldPharmacyTimes"].ToString() != ""))
                {
                    chronicLungerVisitModel.ShouldPharmacyTimes = int.Parse(row["ShouldPharmacyTimes"].ToString());
                }
                if (((row["PharmacyTimes"] != null) && (row["PharmacyTimes"] != DBNull.Value)) && (row["PharmacyTimes"].ToString() != ""))
                {
                    chronicLungerVisitModel.PharmacyTimes = int.Parse(row["PharmacyTimes"].ToString());
                }
                if ((row["EstimateDoctor"] != null) && (row["EstimateDoctor"] != DBNull.Value))
                {
                    chronicLungerVisitModel.EstimateDoctor = row["EstimateDoctor"].ToString();
                }
                if (((row["PharmacyRate"] != null) && (row["PharmacyRate"] != DBNull.Value)) && (row["PharmacyRate"].ToString() != ""))
                {
                    chronicLungerVisitModel.PharmacyRate = new decimal?(decimal.Parse(row["PharmacyRate"].ToString()));
                }
                if (((row["VisitCount"] != null) && (row["VisitCount"] != DBNull.Value)) && (row["VisitCount"].ToString() != ""))
                {
                    chronicLungerVisitModel.VisitCount = int.Parse(row["VisitCount"].ToString());
                }
                if ((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value))
                {
                    chronicLungerVisitModel.CreatedBy = row["CreatedBy"].ToString();
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    chronicLungerVisitModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if ((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value))
                {
                    chronicLungerVisitModel.LastUpdateBy = row["LastUpdateBy"].ToString();
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    chronicLungerVisitModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    chronicLungerVisitModel.IsDel = row["IsDel"].ToString();
                }
            }
            return chronicLungerVisitModel;
        }
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chroniclungervisit ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chroniclungervisit ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }
        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_chroniclungervisit");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,CustomerID,IDCardNo,CustomerName,FollowupDate,VisitDoctor,");
            builder.Append("CureMonth,Supervisor,FollowupWay,Symptom,SymptomEx,SmokeDayNum,DayDrinkVolume,NextSmokeDayNum,");
            builder.Append("NextDayDrinkVolume,ChemotherapyScheme,MedicationCompliance,DrugType,OmissiveTimes,Adr,AdrEx,");
            builder.Append("Complication,ComplicationEx,ReferralOrg,ReferralReason,ReferralResult,");
            builder.Append("HandleView,NextVisitDate,StopCureDate,StopCureReason,ShouldVisitTimes,");
            builder.Append("VisitTimes,ShouldPharmacyTimes,PharmacyTimes,EstimateDoctor,PharmacyRate,VisitCount,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel");
            builder.Append(" FROM tbl_chroniclungervisit ");
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
            builder.Append("(case C.FollowupDate when null then null when '' then null else C.FollowupDate end)FollowupDate, ");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName ");
            builder.Append(" from tbl_chroniclungervisit C left join tbl_recordsbaseinfo T on T.IDCardNo = C.IDCardNo ");
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
                builder.Append(" order by FollowupDate desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }
        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "tbl_chroniclungervisit");
        }
        public ChronicLungerVisitModel GetModel(string IDCardNo , string Count)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,CustomerID,IDCardNo,CustomerName,FollowupDate,VisitDoctor,");
            builder.Append("CureMonth,Supervisor,FollowupWay,Symptom,SymptomEx,SmokeDayNum,DayDrinkVolume,NextSmokeDayNum,");
            builder.Append("NextDayDrinkVolume,ChemotherapyScheme,MedicationCompliance,DrugType,OmissiveTimes,Adr,AdrEx,");
            builder.Append("Complication,ComplicationEx,ReferralOrg,ReferralReason,ReferralResult,");
            builder.Append("HandleView,NextVisitDate,StopCureDate,StopCureReason,ShouldVisitTimes,");
            builder.Append("VisitTimes,ShouldPharmacyTimes,PharmacyTimes,EstimateDoctor,PharmacyRate,VisitCount,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel ");
            builder.Append(" from tbl_chroniclungervisit where IDCardNo = @IDCardNo and VisitCount = @VisitCount ");
            builder.Append(" order by FollowupDate DESC LIMIT 0,1 ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@VisitCount",MySqlDbType.Int32,11)
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value =Convert.ToInt32( Count);
            new ChronicLungerVisitModel();
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
            builder.Append("select count(1) FROM tbl_chroniclungervisit C ");
            builder.Append("left join tbl_recordsbaseinfo T on T.IDCardNo = C.IDCardNo   ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1" + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public bool Update(ChronicLungerVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_chroniclungervisit set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CustomerName=@CustomerName,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("VisitDoctor=@VisitDoctor,");
            builder.Append("CureMonth=@CureMonth,");
            builder.Append("Supervisor=@Supervisor,");
            builder.Append("FollowupWay=@FollowupWay,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("SymptomEx=@SymptomEx,");
            builder.Append("SmokeDayNum=@SmokeDayNum,");
            builder.Append("DayDrinkVolume=@DayDrinkVolume,");
            builder.Append("ChemotherapyScheme=@ChemotherapyScheme,");
            builder.Append("MedicationCompliance=@MedicationCompliance,");
            builder.Append("DrugType=@DrugType,");
            builder.Append("OmissiveTimes=@OmissiveTimes,");
            builder.Append("Adr=@Adr,");
            builder.Append("AdrEx=@AdrEx,");
            builder.Append("Complication=@Complication,");
            builder.Append("ComplicationEx=@ComplicationEx,");
            builder.Append("ReferralOrg=@ReferralOrg,");
            builder.Append("ReferralReason=@ReferralReason,");
            builder.Append("ReferralResult=@ReferralResult,");
            builder.Append("HandleView=@HandleView,");
            builder.Append("NextVisitDate=@NextVisitDate,");
            builder.Append("StopCureDate=@StopCureDate,");
            builder.Append("StopCureReason=@StopCureReason,");
            builder.Append("ShouldVisitTimes=@ShouldVisitTimes,");
            builder.Append("VisitTimes=@VisitTimes,");
            builder.Append("ShouldPharmacyTimes=@ShouldPharmacyTimes,");
            builder.Append("PharmacyTimes=@PharmacyTimes,");
            builder.Append("EstimateDoctor=@EstimateDoctor,");
            builder.Append("PharmacyRate=@PharmacyRate,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("NextSmokeDayNum=@NextSmokeDayNum,");
            builder.Append("NextDayDrinkVolume=@NextDayDrinkVolume,");
            builder.Append("VisitCount = @VisitCount");
            builder.Append(" where OutKey=@OutKey And VisitCount=@VisitCount");
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
                new MySqlParameter ("@VisitCount",MySqlDbType.Int32 ,1),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8)
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
            cmdParms[42].Value = model.OUTKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public ChronicLungerVisitModel GetModelByOutKey(int OutKey, string Count)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,CustomerID,IDCardNo,CustomerName,FollowupDate,VisitDoctor,");
            builder.Append("CureMonth,Supervisor,FollowupWay,Symptom,SymptomEx,SmokeDayNum,DayDrinkVolume,NextSmokeDayNum,");
            builder.Append("NextDayDrinkVolume,ChemotherapyScheme,MedicationCompliance,DrugType,OmissiveTimes,Adr,AdrEx,");
            builder.Append("Complication,ComplicationEx,ReferralOrg,ReferralReason,ReferralResult,");
            builder.Append("HandleView,NextVisitDate,StopCureDate,StopCureReason,ShouldVisitTimes,");
            builder.Append("VisitTimes,ShouldPharmacyTimes,PharmacyTimes,EstimateDoctor,PharmacyRate,VisitCount,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel ");
            builder.Append(" from tbl_chroniclungervisit where OutKey = @OutKey and VisitCount = @VisitCount ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4),
                new MySqlParameter("@VisitCount",MySqlDbType.Int32,11)
            };
            cmdParms[0].Value = OutKey;
            cmdParms[1].Value = Convert.ToInt32(Count);
            new ChronicLungerVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey, int VisitCount)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_chroniclungervisit");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and OutKey=@OutKey");
            builder.Append(" and VisitCount=@VisitCount");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) ,
                new MySqlParameter("@VisitCount", MySqlDbType.Int32, 4) 
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OutKey;
            cmdParms[2].Value = VisitCount;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
    }
}
