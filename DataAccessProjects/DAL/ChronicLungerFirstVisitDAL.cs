namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicLungerFirstVisitDAL
    {
        public int Add(ChronicLungerFirstVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_chroniclungerfirstvisit(");
            builder.Append("RecordID,CustomerID,IDCardNo,CustomerName,FollowupDate,EstimateDoctor,");
            builder.Append("FollowupWay,PatientType,Sputumfungs,DrugFast,Symptom,SymptomEx,MedicationCompliance,");
            builder.Append("ChemotherapyScheme,DrugType,Supervisor,StandaloneRoom,Ventilation,");
            builder.Append("SmokeDayNum,DayDrinkVolume,MediclineReceiveTime,MediclineReceivePlace,RecordcardWrite,");
            builder.Append("PharmacyWayDeposit,Therapies,IndisciplineHarm,AdrsHandle,SubsequentVisit,InsistPharmacy,LivingHabit,");
            builder.Append("ChecktouchPerson,NextVisitDate,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel,VisitDoctor,");
            builder.Append("NextSmokeDayNum,NextDayDrinkVolume)");
            builder.Append(" values (");
            builder.Append("@RecordID,@CustomerID,@IDCardNo,@CustomerName,@FollowupDate,@EstimateDoctor,");
            builder.Append("@FollowupWay,@PatientType,@Sputumfungs,@DrugFast,@Symptom,@SymptomEx,@MedicationCompliance,");
            builder.Append("@ChemotherapyScheme,@DrugType,@Supervisor,@StandaloneRoom,@Ventilation,");
            builder.Append("@SmokeDayNum,@DayDrinkVolume,@MediclineReceiveTime,@MediclineReceivePlace,@RecordcardWrite,");
            builder.Append("@PharmacyWayDeposit,@Therapies,@IndisciplineHarm,@AdrsHandle,@SubsequentVisit,@InsistPharmacy,@LivingHabit,");
            builder.Append("@ChecktouchPerson,@NextVisitDate,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel,@VisitDoctor,");
            builder.Append("@NextSmokeDayNum,@NextDayDrinkVolume)");
            builder.Append(";select @@IDENTITY");
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
            cmdParms[11].Value = model.SymptomEx ;
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
            cmdParms[27].Value = model.SubsequentVisit ;
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
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public ChronicLungerFirstVisitModel DataRowToModel(DataRow row)
        {
            ChronicLungerFirstVisitModel chronicLungerFirstVisitModel = new ChronicLungerFirstVisitModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicLungerFirstVisitModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["CustomerName"] != null) && (row["CustomerName"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.CustomerName = row["CustomerName"].ToString();
                }
                if (((row["FollowupDate"] != null) && (row["FollowupDate"] != DBNull.Value)) && (row["FollowupDate"].ToString() != ""))
                {
                    chronicLungerFirstVisitModel.FollowupDate = new DateTime?(DateTime.Parse(row["FollowupDate"].ToString()));
                }
                if ((row["EstimateDoctor"] != null) && (row["EstimateDoctor"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.EstimateDoctor = row["EstimateDoctor"].ToString();
                }
                if ((row["FollowupWay"] != null) && (row["FollowupWay"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.FollowupWay = row["FollowupWay"].ToString();
                }
                if ((row["PatientType"] != null) && (row["PatientType"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.PatientType = row["PatientType"].ToString();
                }
                if ((row["Sputumfungs"] != null) && (row["Sputumfungs"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.Sputumfungs = row["Sputumfungs"].ToString();
                }
                if ((row["DrugFast"] != null) && (row["DrugFast"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.DrugFast = row["DrugFast"].ToString();
                }
                if ((row["Symptom"] != null) && (row["Symptom"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.Symptom = row["Symptom"].ToString();
                }
                if ((row["SymptomEx"] != null) && (row["SymptomEx"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.SymptomEx = row["SymptomEx"].ToString();
                }
                if ((row["MedicationCompliance"] != null) && (row["MedicationCompliance"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.MedicationCompliance = row["MedicationCompliance"].ToString();
                }
                if ((row["ChemotherapyScheme"] != null) && (row["ChemotherapyScheme"] != DBNull.Value)) 
                {
                    chronicLungerFirstVisitModel.ChemotherapyScheme = row["ChemotherapyScheme"].ToString();
                }
                if ((row["DrugType"] != null) && (row["DrugType"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.DrugType = row["DrugType"].ToString();
                }
                if ((row["Supervisor"] != null) && (row["Supervisor"] != DBNull.Value)) 
                {
                    chronicLungerFirstVisitModel.Supervisor = row["Supervisor"].ToString();
                }
                if ((row["StandaloneRoom"] != null) && (row["StandaloneRoom"] != DBNull.Value)) 
                {
                    chronicLungerFirstVisitModel.StandaloneRoom = row["StandaloneRoom"].ToString();
                }
                if ((row["Ventilation"] != null) && (row["Ventilation"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.Ventilation = row["Ventilation"].ToString();
                }
                if (((row["SmokeDayNum"] != null) && (row["SmokeDayNum"] != DBNull.Value)) && (row["SmokeDayNum"].ToString() != ""))
                {
                    chronicLungerFirstVisitModel.SmokeDayNum = new decimal?(decimal.Parse(row["SmokeDayNum"].ToString()));
                }
                if (((row["NextSmokeDayNum"] != null) && (row["NextSmokeDayNum"] != DBNull.Value)) && (row["NextSmokeDayNum"].ToString() != ""))
                {
                    chronicLungerFirstVisitModel.NextSmokeDayNum = new decimal?(decimal.Parse(row["NextSmokeDayNum"].ToString()));
                }
                if (((row["DayDrinkVolume"] != null) && (row["DayDrinkVolume"] != DBNull.Value)) && (row["DayDrinkVolume"].ToString() != ""))
                {
                    chronicLungerFirstVisitModel.DayDrinkVolume = new decimal?(decimal.Parse(row["DayDrinkVolume"].ToString()));
                }
                if (((row["NextDayDrinkVolume"] != null) && (row["NextDayDrinkVolume"] != DBNull.Value)) && (row["NextDayDrinkVolume"].ToString() != ""))
                {
                    chronicLungerFirstVisitModel.NextDayDrinkVolume = new decimal?(decimal.Parse(row["NextDayDrinkVolume"].ToString()));
                }
                if (((row["MediclineReceiveTime"] != null) && (row["MediclineReceiveTime"] != DBNull.Value)) && (row["MediclineReceiveTime"].ToString() != ""))
                {
                    chronicLungerFirstVisitModel.MediclineReceiveTime = new DateTime?(DateTime.Parse(row["MediclineReceiveTime"].ToString()));
                }
                if ((row["MediclineReceivePlace"] != null) && (row["MediclineReceivePlace"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.MediclineReceivePlace = row["MediclineReceivePlace"].ToString();
                }
                if ((row["RecordcardWrite"] != null) && (row["RecordcardWrite"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.RecordcardWrite = row["RecordcardWrite"].ToString();
                }
                if ((row["PharmacyWayDeposit"] != null) && (row["PharmacyWayDeposit"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.PharmacyWayDeposit = row["PharmacyWayDeposit"].ToString();
                }
                if ((row["Therapies"] != null) && (row["Therapies"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.Therapies = row["Therapies"].ToString();
                }
                if ((row["IndisciplineHarm"] != null) && (row["IndisciplineHarm"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.IndisciplineHarm = row["IndisciplineHarm"].ToString();
                }
                if ((row["AdrsHandle"] != null) && (row["AdrsHandle"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.AdrsHandle = row["AdrsHandle"].ToString();
                }
                if ((row["SubsequentVisit"] != null) && (row["SubsequentVisit"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.SubsequentVisit = row["SubsequentVisit"].ToString();
                }
                if ((row["InsistPharmacy"] != null) && (row["InsistPharmacy"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.InsistPharmacy = row["InsistPharmacy"].ToString();
                }
                if ((row["LivingHabit"] != null) && (row["LivingHabit"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.LivingHabit = row["LivingHabit"].ToString();
                }
                if ((row["ChecktouchPerson"] != null) && (row["ChecktouchPerson"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.ChecktouchPerson = row["ChecktouchPerson"].ToString();
                }
                if (((row["NextVisitDate"] != null) && (row["NextVisitDate"] != DBNull.Value)) && (row["NextVisitDate"].ToString() != ""))
                {
                    chronicLungerFirstVisitModel.NextVisitDate = new DateTime?(DateTime.Parse(row["NextVisitDate"].ToString()));
                }
                if ((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.CreatedBy = row["CreatedBy"].ToString();
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    chronicLungerFirstVisitModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if ((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.LastUpdateBy = row["LastUpdateBy"].ToString();
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    chronicLungerFirstVisitModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.IsDel = row["IsDel"].ToString();
                }
                if ((row["VisitDoctor"] != null) && (row["VisitDoctor"] != DBNull.Value))
                {
                    chronicLungerFirstVisitModel.VisitDoctor = row["VisitDoctor"].ToString();
                }
            }
            return chronicLungerFirstVisitModel;
        }
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chroniclungerfirstvisit ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool DelOUTkey(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chroniclungerfirstvisit ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chroniclungerfirstvisit ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }
        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_chroniclungerfirstvisit");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,CustomerID,IDCardNo,CustomerName,FollowupDate,EstimateDoctor,VisitDoctor,");
            builder.Append("FollowupWay,PatientType,Sputumfungs,DrugFast,Symptom,SymptomEx,MedicationCompliance,");
            builder.Append("ChemotherapyScheme,DrugType,Supervisor,StandaloneRoom,Ventilation,");
            builder.Append("SmokeDayNum,DayDrinkVolume,NextSmokeDayNum,NextDayDrinkVolume,MediclineReceiveTime,MediclineReceivePlace,RecordcardWrite,");
            builder.Append("PharmacyWayDeposit,Therapies,IndisciplineHarm,AdrsHandle,SubsequentVisit,InsistPharmacy,LivingHabit,");
            builder.Append("ChecktouchPerson,NextVisitDate,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel");
            builder.Append(" FROM tbl_chroniclungerfirstvisit ");
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
            builder.Append("(case C.FollowUpDate when null then null when '' then null else C.FollowUpDate end) as FollowUpDate, ");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName ");
            builder.Append(" from tbl_chroniclungerfirstvisit C inner join tbl_recordsbaseinfo T on T.IDCardNo = C.IDCardNo ");
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
        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "tbl_chroniclungerfirstvisit");
        }
        public ChronicLungerFirstVisitModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,IDCardNo,CustomerName,FollowupDate,EstimateDoctor,VisitDoctor,");
            builder.Append("FollowupWay,PatientType,Sputumfungs,DrugFast,Symptom,SymptomEx,MedicationCompliance,");
            builder.Append("ChemotherapyScheme,DrugType,Supervisor,StandaloneRoom,Ventilation,");
            builder.Append("SmokeDayNum,DayDrinkVolume,NextSmokeDayNum,NextDayDrinkVolume,MediclineReceiveTime,MediclineReceivePlace,RecordcardWrite,");
            builder.Append("PharmacyWayDeposit,Therapies,IndisciplineHarm,AdrsHandle,SubsequentVisit,InsistPharmacy,LivingHabit,");
            builder.Append("ChecktouchPerson,NextVisitDate,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel ");
            builder.Append(" from tbl_chroniclungerfirstvisit where IDCardNo = @IDCardNo ");
            builder.Append(" order by FollowupDate desc LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new ChronicLungerFirstVisitModel();
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
            builder.Append("select count(1) FROM tbl_chroniclungerfirstvisit C left join tbl_recordsbaseinfo T on T.IDCardNo = C.IDCardNo   ");
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
        public bool Update(ChronicLungerFirstVisitModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_chroniclungerfirstvisit set ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CustomerName=@CustomerName,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("EstimateDoctor=@EstimateDoctor,");
            builder.Append("FollowupWay=@FollowupWay,");
            builder.Append("PatientType=@PatientType,");
            builder.Append("Sputumfungs=@Sputumfungs,");
            builder.Append("DrugFast=@DrugFast,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("SymptomEx=@SymptomEx,");
            builder.Append("MedicationCompliance=@MedicationCompliance,");
            builder.Append("ChemotherapyScheme=@ChemotherapyScheme,");
            builder.Append("DrugType=@DrugType,");
            builder.Append("Supervisor=@Supervisor,");
            builder.Append("StandaloneRoom=@StandaloneRoom,");
            builder.Append("Ventilation=@Ventilation,");
            builder.Append("SmokeDayNum=@SmokeDayNum,");
            builder.Append("DayDrinkVolume=@DayDrinkVolume,");
            builder.Append("MediclineReceiveTime=@MediclineReceiveTime,");
            builder.Append("MediclineReceivePlace=@MediclineReceivePlace,");
            builder.Append("RecordcardWrite=@RecordcardWrite,");
            builder.Append("PharmacyWayDeposit=@PharmacyWayDeposit,");
            builder.Append("Therapies=@Therapies,");
            builder.Append("IndisciplineHarm=@IndisciplineHarm,");
            builder.Append("AdrsHandle=@AdrsHandle,");
            builder.Append("SubsequentVisit=@SubsequentVisit,");
            builder.Append("InsistPharmacy=@InsistPharmacy,");
            builder.Append("LivingHabit=@LivingHabit,");
            builder.Append("ChecktouchPerson=@ChecktouchPerson,");
            builder.Append("NextVisitDate=@NextVisitDate,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("VisitDoctor = @VisitDoctor, ");
            builder.Append("NextSmokeDayNum=@NextSmokeDayNum,");
            builder.Append("NextDayDrinkVolume=@NextDayDrinkVolume ");
            builder.Append(" where ID=@ID");
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
                new MySqlParameter("@NextDayDrinkVolume", MySqlDbType.Decimal),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
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
            cmdParms[21].Value = model.MediclineReceivePlace ;
            cmdParms[22].Value = model.RecordcardWrite;
            cmdParms[23].Value =model.PharmacyWayDeposit ;
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
            cmdParms[40].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public ChronicLungerFirstVisitModel GetModelByID(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,IDCardNo,CustomerName,FollowupDate,EstimateDoctor,VisitDoctor,");
            builder.Append("FollowupWay,PatientType,Sputumfungs,DrugFast,Symptom,SymptomEx,MedicationCompliance,");
            builder.Append("ChemotherapyScheme,DrugType,Supervisor,StandaloneRoom,Ventilation,");
            builder.Append("SmokeDayNum,DayDrinkVolume,NextSmokeDayNum,NextDayDrinkVolume,MediclineReceiveTime,MediclineReceivePlace,RecordcardWrite,");
            builder.Append("PharmacyWayDeposit,Therapies,IndisciplineHarm,AdrsHandle,SubsequentVisit,InsistPharmacy,LivingHabit,");
            builder.Append("ChecktouchPerson,NextVisitDate,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel ");
            builder.Append(" from tbl_chroniclungerfirstvisit where ID = @ID ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.String) };
            cmdParms[0].Value = ID;
            new ChronicLungerFirstVisitModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public ChronicLungerFirstVisitModel CheckModel(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,RecordID,IDCardNo,CustomerID,IDCardNo,CustomerName,FollowupDate,EstimateDoctor,VisitDoctor,");
            builder.Append("FollowupWay,PatientType,Sputumfungs,DrugFast,Symptom,SymptomEx,MedicationCompliance,");
            builder.Append("ChemotherapyScheme,DrugType,Supervisor,StandaloneRoom,Ventilation,");
            builder.Append("SmokeDayNum,DayDrinkVolume,NextSmokeDayNum,NextDayDrinkVolume,MediclineReceiveTime,MediclineReceivePlace,RecordcardWrite,");
            builder.Append("PharmacyWayDeposit,Therapies,IndisciplineHarm,AdrsHandle,SubsequentVisit,InsistPharmacy,LivingHabit,");
            builder.Append("ChecktouchPerson,NextVisitDate,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel ");
            builder.Append(" from tbl_chroniclungerfirstvisit  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(" where "+strWhere);
            }
            DataSet set = MySQLHelper.Query(builder.ToString());
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
    }
}
