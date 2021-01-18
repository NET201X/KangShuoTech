namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicMentalDiseaseBaseInfoDAL
    {
        public int Add(ChronicMentalDiseaseBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_MENTALDISEASE_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,GuardianRecordID,GuardianName,Ralation,GuradianAddr,");
            builder.Append("GuradianPhone,FirstTime,AgreeManagement,AgreeSignature,AgreeTime,Symptom,SymptomOther,OutPatien,");
            builder.Append("HospitalCount,DiagnosisInfo,DiagnosisHospital,DiagnosisTime,LastCure,VillageContacts,VillageTel,");
            builder.Append("LockInfo,Economy,SpecialistProposal,FillformTime,DoctorMark,CreatedBy,CreatedDate,LastUpdateBy,");
            builder.Append("LastUpDateDate,CreateUnit,CurrentUnit,IsDel,FirstTreatmenTTime,MildTroubleFrequen,CreateDistuFrequen,");
            builder.Append("CauseAccidFrequen,AutolesionFrequen,AttemptSuicFrequen,AttemptSuicideNone,Professional,OtherDangerFrequen,HouseType)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@GuardianRecordID,@GuardianName,@Ralation,@GuradianAddr,@GuradianPhone,");
            builder.Append("@FirstTime,@AgreeManagement,@AgreeSignature,@AgreeTime,@Symptom,@SymptomOther,@OutPatien,@HospitalCount,");
            builder.Append("@DiagnosisInfo,@DiagnosisHospital,@DiagnosisTime,@LastCure,@VillageContacts,@VillageTel,@LockInfo,@Economy,");
            builder.Append("@SpecialistProposal,@FillformTime,@DoctorMark,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpDateDate,");
            builder.Append("@CreateUnit,@CurrentUnit,@IsDel,@FirstTreatmenTTime,@MildTroubleFrequen,@CreateDistuFrequen,");
            builder.Append("@CauseAccidFrequen,@AutolesionFrequen,@AttemptSuicFrequen,@AttemptSuicideNone,@Professional,@OtherDangerFrequen,@HouseType)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@GuardianRecordID", MySqlDbType.String, 17),
                new MySqlParameter("@GuardianName", MySqlDbType.String, 30), 
                new MySqlParameter("@Ralation", MySqlDbType.String, 1), 
                new MySqlParameter("@GuradianAddr", MySqlDbType.String, 200),
                new MySqlParameter("@GuradianPhone", MySqlDbType.String, 15),
                new MySqlParameter("@FirstTime", MySqlDbType.Date), 
                new MySqlParameter("@AgreeManagement", MySqlDbType.String, 1),
                new MySqlParameter("@AgreeSignature", MySqlDbType.String, 30),
                new MySqlParameter("@AgreeTime", MySqlDbType.Date), 
                new MySqlParameter("@Symptom", MySqlDbType.String, 50),
                new MySqlParameter("@SymptomOther", MySqlDbType.String, 200),
                new MySqlParameter("@OutPatien", MySqlDbType.String, 1), 
                new MySqlParameter("@HospitalCount", MySqlDbType.Int32), 
                new MySqlParameter("@DiagnosisInfo", MySqlDbType.String, 500), 
                new MySqlParameter("@DiagnosisHospital", MySqlDbType.String, 200),
                new MySqlParameter("@DiagnosisTime", MySqlDbType.Date),
                new MySqlParameter("@LastCure", MySqlDbType.String, 1), 
                new MySqlParameter("@VillageContacts", MySqlDbType.String, 30),
                new MySqlParameter("@VillageTel", MySqlDbType.String, 15), 
                new MySqlParameter("@LockInfo", MySqlDbType.String, 1),
                new MySqlParameter("@Economy", MySqlDbType.String, 1),
                new MySqlParameter("@SpecialistProposal", MySqlDbType.String, 500),
                new MySqlParameter("@FillformTime", MySqlDbType.Date), 
                new MySqlParameter("@DoctorMark", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@FirstTreatmenTTime", MySqlDbType.Date),
                new MySqlParameter("@MildTroubleFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CreateDistuFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CauseAccidFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AutolesionFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AttemptSuicFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AttemptSuicideNone", MySqlDbType.String, 2),
                new MySqlParameter("@Professional", MySqlDbType.String, 1),
                new MySqlParameter("@OtherDangerFrequen",MySqlDbType.Decimal),
                new MySqlParameter("@HouseType",MySqlDbType.String,1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.GuardianRecordID;
            cmdParms[4].Value = model.GuardianName;
            cmdParms[5].Value = model.Ralation;
            cmdParms[6].Value = model.GuradianAddr;
            cmdParms[7].Value = model.GuradianPhone;
            cmdParms[8].Value = model.FirstTime;
            cmdParms[9].Value = model.AgreeManagement;
            cmdParms[10].Value = model.AgreeSignature;
            cmdParms[11].Value = model.AgreeTime;
            cmdParms[12].Value = model.Symptom;
            cmdParms[13].Value = model.SymptomOther;
            cmdParms[14].Value = model.OutPatien;
            cmdParms[15].Value = model.HospitalCount;
            cmdParms[16].Value = model.DiagnosisInfo;
            cmdParms[17].Value = model.DiagnosisHospital;
            cmdParms[18].Value = model.DiagnosisTime;
            cmdParms[19].Value = model.LastCure;
            cmdParms[20].Value = model.VillageContacts;
            cmdParms[21].Value = model.VillageTel;
            cmdParms[22].Value = model.LockInfo;
            cmdParms[23].Value = model.Economy;
            cmdParms[24].Value = model.SpecialistProposal;
            cmdParms[25].Value = model.FillformTime;
            cmdParms[26].Value = model.DoctorMark;
            cmdParms[27].Value = model.CreatedBy;
            cmdParms[28].Value = model.CreatedDate;
            cmdParms[29].Value = model.LastUpdateBy;
            cmdParms[30].Value = model.LastUpDateDate;
            cmdParms[31].Value = model.CreateUnit;
            cmdParms[32].Value = model.CurrentUnit;
            cmdParms[33].Value = model.IsDel;
            cmdParms[34].Value = model.FirstTreatmenTTime;
            cmdParms[35].Value = model.MildTroubleFrequen;
            cmdParms[36].Value = model.CreateDistuFrequen;
            cmdParms[37].Value = model.CauseAccidFrequen;
            cmdParms[38].Value = model.AutolesionFrequen;
            cmdParms[39].Value = model.AttemptSuicFrequen;
            cmdParms[40].Value = model.AttemptSuicideNone;
            cmdParms[41].Value = model.Professional;
            cmdParms[42].Value = model.OtherDangerFrequen;
            cmdParms[43].Value = model.HouseType;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(ChronicMentalDiseaseBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_MENTALDISEASE_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,GuardianRecordID,GuardianName,Ralation,GuradianAddr,");
            builder.Append("GuradianPhone,FirstTime,AgreeManagement,AgreeSignature,AgreeTime,Symptom,SymptomOther,OutPatien,");
            builder.Append("HospitalCount,DiagnosisInfo,DiagnosisHospital,DiagnosisTime,LastCure,VillageContacts,VillageTel,");
            builder.Append("LockInfo,Economy,SpecialistProposal,FillformTime,DoctorMark,CreatedBy,CreatedDate,LastUpdateBy,");
            builder.Append("LastUpDateDate,CreateUnit,CurrentUnit,IsDel,FirstTreatmenTTime,MildTroubleFrequen,CreateDistuFrequen,");
            builder.Append("CauseAccidFrequen,AutolesionFrequen,AttemptSuicFrequen,AttemptSuicideNone,Professional,OtherDangerFrequen,HouseType)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@GuardianRecordID,@GuardianName,@Ralation,@GuradianAddr,@GuradianPhone,");
            builder.Append("@FirstTime,@AgreeManagement,@AgreeSignature,@AgreeTime,@Symptom,@SymptomOther,@OutPatien,@HospitalCount,");
            builder.Append("@DiagnosisInfo,@DiagnosisHospital,@DiagnosisTime,@LastCure,@VillageContacts,@VillageTel,@LockInfo,@Economy,");
            builder.Append("@SpecialistProposal,@FillformTime,@DoctorMark,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpDateDate,");
            builder.Append("@CreateUnit,@CurrentUnit,@IsDel,@FirstTreatmenTTime,@MildTroubleFrequen,@CreateDistuFrequen,");
            builder.Append("@CauseAccidFrequen,@AutolesionFrequen,@AttemptSuicFrequen,@AttemptSuicideNone,@Professional,@OtherDangerFrequen,@HouseType)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@GuardianRecordID", MySqlDbType.String, 17),
                new MySqlParameter("@GuardianName", MySqlDbType.String, 30), 
                new MySqlParameter("@Ralation", MySqlDbType.String, 1), 
                new MySqlParameter("@GuradianAddr", MySqlDbType.String, 200),
                new MySqlParameter("@GuradianPhone", MySqlDbType.String, 15),
                new MySqlParameter("@FirstTime", MySqlDbType.Date), 
                new MySqlParameter("@AgreeManagement", MySqlDbType.String, 1),
                new MySqlParameter("@AgreeSignature", MySqlDbType.String, 30),
                new MySqlParameter("@AgreeTime", MySqlDbType.Date), 
                new MySqlParameter("@Symptom", MySqlDbType.String, 50),
                new MySqlParameter("@SymptomOther", MySqlDbType.String, 200),
                new MySqlParameter("@OutPatien", MySqlDbType.String, 1), 
                new MySqlParameter("@HospitalCount", MySqlDbType.Int32), 
                new MySqlParameter("@DiagnosisInfo", MySqlDbType.String, 500), 
                new MySqlParameter("@DiagnosisHospital", MySqlDbType.String, 200),
                new MySqlParameter("@DiagnosisTime", MySqlDbType.Date),
                new MySqlParameter("@LastCure", MySqlDbType.String, 1), 
                new MySqlParameter("@VillageContacts", MySqlDbType.String, 30),
                new MySqlParameter("@VillageTel", MySqlDbType.String, 15), 
                new MySqlParameter("@LockInfo", MySqlDbType.String, 1),
                new MySqlParameter("@Economy", MySqlDbType.String, 1),
                new MySqlParameter("@SpecialistProposal", MySqlDbType.String, 500),
                new MySqlParameter("@FillformTime", MySqlDbType.Date), 
                new MySqlParameter("@DoctorMark", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@FirstTreatmenTTime", MySqlDbType.Date),
                new MySqlParameter("@MildTroubleFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CreateDistuFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CauseAccidFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AutolesionFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AttemptSuicFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AttemptSuicideNone", MySqlDbType.String, 2),
                new MySqlParameter("@Professional", MySqlDbType.String, 1),
                new MySqlParameter("@OtherDangerFrequen",MySqlDbType.Decimal),
                new MySqlParameter("@HouseType",MySqlDbType.String,1)

             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.GuardianRecordID;
            cmdParms[4].Value = model.GuardianName;
            cmdParms[5].Value = model.Ralation;
            cmdParms[6].Value = model.GuradianAddr;
            cmdParms[7].Value = model.GuradianPhone;
            cmdParms[8].Value = model.FirstTime;
            cmdParms[9].Value = model.AgreeManagement;
            cmdParms[10].Value = model.AgreeSignature;
            cmdParms[11].Value = model.AgreeTime;
            cmdParms[12].Value = model.Symptom;
            cmdParms[13].Value = model.SymptomOther;
            cmdParms[14].Value = model.OutPatien;
            cmdParms[15].Value = model.HospitalCount;
            cmdParms[16].Value = model.DiagnosisInfo;
            cmdParms[17].Value = model.DiagnosisHospital;
            cmdParms[18].Value = model.DiagnosisTime;
            cmdParms[19].Value = model.LastCure;
            cmdParms[20].Value = model.VillageContacts;
            cmdParms[21].Value = model.VillageTel;
            cmdParms[22].Value = model.LockInfo;
            cmdParms[23].Value = model.Economy;
            cmdParms[24].Value = model.SpecialistProposal;
            cmdParms[25].Value = model.FillformTime;
            cmdParms[26].Value = model.DoctorMark;
            cmdParms[27].Value = model.CreatedBy;
            cmdParms[28].Value = model.CreatedDate;
            cmdParms[29].Value = model.LastUpdateBy;
            cmdParms[30].Value = model.LastUpDateDate;
            cmdParms[31].Value = model.CreateUnit;
            cmdParms[32].Value = model.CurrentUnit;
            cmdParms[33].Value = model.IsDel;
            cmdParms[34].Value = model.FirstTreatmenTTime;
            cmdParms[35].Value = model.MildTroubleFrequen;
            cmdParms[36].Value = model.CreateDistuFrequen;
            cmdParms[37].Value = model.CauseAccidFrequen;
            cmdParms[38].Value = model.AutolesionFrequen;
            cmdParms[39].Value = model.AttemptSuicFrequen;
            cmdParms[40].Value = model.AttemptSuicideNone;
            cmdParms[41].Value = model.Professional;
            cmdParms[42].Value = model.OtherDangerFrequen;
            cmdParms[43].Value = model.HouseType;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public ChronicMentalDiseaseBaseInfoModel DataRowToModel(DataRow row)
        {
            ChronicMentalDiseaseBaseInfoModel chronicMentalDiseaseBaseInfoModel = new ChronicMentalDiseaseBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["GuardianRecordID"] != null) && (row["GuardianRecordID"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.GuardianRecordID = row["GuardianRecordID"].ToString();
                }
                if ((row["GuardianName"] != null) && (row["GuardianName"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.GuardianName = row["GuardianName"].ToString();
                }
                if ((row["Ralation"] != null) && (row["Ralation"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.Ralation = row["Ralation"].ToString();
                }
                if ((row["GuradianAddr"] != null) && (row["GuradianAddr"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.GuradianAddr = row["GuradianAddr"].ToString();
                }
                if ((row["GuradianPhone"] != null) && (row["GuradianPhone"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.GuradianPhone = row["GuradianPhone"].ToString();
                }
                if (((row["FirstTime"] != null) && (row["FirstTime"] != DBNull.Value)) && (row["FirstTime"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.FirstTime = new DateTime?(DateTime.Parse(row["FirstTime"].ToString()));
                }
                if ((row["AgreeManagement"] != null) && (row["AgreeManagement"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.AgreeManagement = row["AgreeManagement"].ToString();
                }
                if ((row["AgreeSignature"] != null) && (row["AgreeSignature"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.AgreeSignature = row["AgreeSignature"].ToString();
                }
                if (((row["AgreeTime"] != null) && (row["AgreeTime"] != DBNull.Value)) && (row["AgreeTime"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.AgreeTime = new DateTime?(DateTime.Parse(row["AgreeTime"].ToString()));
                }
                if ((row["Symptom"] != null) && (row["Symptom"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.Symptom = row["Symptom"].ToString();
                }
                if ((row["SymptomOther"] != null) && (row["SymptomOther"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.SymptomOther = row["SymptomOther"].ToString();
                }
                if ((row["OutPatien"] != null) && (row["OutPatien"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.OutPatien = row["OutPatien"].ToString();
                }
                if (((row["HospitalCount"] != null) && (row["HospitalCount"] != DBNull.Value)) && (row["HospitalCount"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.HospitalCount = int.Parse(row["HospitalCount"].ToString());
                }
                if ((row["DiagnosisInfo"] != null) && (row["DiagnosisInfo"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.DiagnosisInfo = row["DiagnosisInfo"].ToString();
                }
                if ((row["DiagnosisHospital"] != null) && (row["DiagnosisHospital"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.DiagnosisHospital = row["DiagnosisHospital"].ToString();
                }
                if (((row["DiagnosisTime"] != null) && (row["DiagnosisTime"] != DBNull.Value)) && (row["DiagnosisTime"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.DiagnosisTime = new DateTime?(DateTime.Parse(row["DiagnosisTime"].ToString()));
                }
                if ((row["LastCure"] != null) && (row["LastCure"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.LastCure = row["LastCure"].ToString();
                }
                if ((row["VillageContacts"] != null) && (row["VillageContacts"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.VillageContacts = row["VillageContacts"].ToString();
                }
                if ((row["VillageTel"] != null) && (row["VillageTel"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.VillageTel = row["VillageTel"].ToString();
                }
                if ((row["LockInfo"] != null) && (row["LockInfo"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.LockInfo = row["LockInfo"].ToString();
                }
                if ((row["Economy"] != null) && (row["Economy"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.Economy = row["Economy"].ToString();
                }
                if ((row["SpecialistProposal"] != null) && (row["SpecialistProposal"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.SpecialistProposal = row["SpecialistProposal"].ToString();
                }
                if (((row["FillformTime"] != null) && (row["FillformTime"] != DBNull.Value)) && (row["FillformTime"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.FillformTime = new DateTime?(DateTime.Parse(row["FillformTime"].ToString()));
                }
                if ((row["DoctorMark"] != null) && (row["DoctorMark"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.DoctorMark = row["DoctorMark"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpDateDate"] != null) && (row["LastUpDateDate"] != DBNull.Value)) && (row["LastUpDateDate"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.LastUpDateDate = new DateTime?(DateTime.Parse(row["LastUpDateDate"].ToString()));
                }
                if (((row["CreateUnit"] != null) && (row["CreateUnit"] != DBNull.Value)) && (row["CreateUnit"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.CreateUnit = new decimal?(decimal.Parse(row["CreateUnit"].ToString()));
                }
                if (((row["CurrentUnit"] != null) && (row["CurrentUnit"] != DBNull.Value)) && (row["CurrentUnit"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.CurrentUnit = new decimal?(decimal.Parse(row["CurrentUnit"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.IsDel = row["IsDel"].ToString();
                }
                if (((row["FirstTreatmenTTime"] != null) && (row["FirstTreatmenTTime"] != DBNull.Value)) && (row["FirstTreatmenTTime"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.FirstTreatmenTTime = new DateTime?(DateTime.Parse(row["FirstTreatmenTTime"].ToString()));
                }
                if (((row["MildTroubleFrequen"] != null) && (row["MildTroubleFrequen"] != DBNull.Value)) && (row["MildTroubleFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.MildTroubleFrequen = int.Parse(row["MildTroubleFrequen"].ToString());
                }
                if (((row["CreateDistuFrequen"] != null) && (row["CreateDistuFrequen"] != DBNull.Value)) && (row["CreateDistuFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.CreateDistuFrequen = int.Parse(row["CreateDistuFrequen"].ToString());
                }
                if (((row["CauseAccidFrequen"] != null) && (row["CauseAccidFrequen"] != DBNull.Value)) && (row["CauseAccidFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.CauseAccidFrequen = int.Parse(row["CauseAccidFrequen"].ToString());
                }
                if (((row["AutolesionFrequen"] != null) && (row["AutolesionFrequen"] != DBNull.Value)) && (row["AutolesionFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.AutolesionFrequen = int.Parse(row["AutolesionFrequen"].ToString());
                }
                if (((row["AttemptSuicFrequen"] != null) && (row["AttemptSuicFrequen"] != DBNull.Value)) && (row["AttemptSuicFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.AttemptSuicFrequen = int.Parse(row["AttemptSuicFrequen"].ToString());
                }
                if ((row["AttemptSuicideNone"] != null) && (row["AttemptSuicideNone"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.AttemptSuicideNone = row["AttemptSuicideNone"].ToString();
                }
                if ((row["Professional"] != null) && (row["Professional"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.Professional = row["Professional"].ToString();
                }
                if ((row["HouseType"] != null) && (row["HouseType"] != DBNull.Value))
                {
                    chronicMentalDiseaseBaseInfoModel.HouseType = row["HouseType"].ToString();
                }
                if (((row["OtherDangerFrequen"] != null) && (row["OtherDangerFrequen"] != DBNull.Value)) && (row["OtherDangerFrequen"].ToString() != ""))
                {
                    chronicMentalDiseaseBaseInfoModel.OtherDangerFrequen = int.Parse(row["OtherDangerFrequen"].ToString());
                }
            }
            return chronicMentalDiseaseBaseInfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_MENTALDISEASE_BASEINFO ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
       
        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_MENTALDISEASE_BASEINFO ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CD_MENTALDISEASE_BASEINFO");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

       

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,GuardianRecordID,");
            builder.Append("GuardianName,Ralation,GuradianAddr,GuradianPhone,FirstTime,AgreeManagement,");
            builder.Append("AgreeSignature,AgreeTime,Symptom,SymptomOther,OutPatien,HospitalCount,DiagnosisInfo,");
            builder.Append("DiagnosisHospital,DiagnosisTime,LastCure,VillageContacts,VillageTel,LockInfo,Economy,");
            builder.Append("SpecialistProposal,FillformTime,DoctorMark,CreatedBy,CreatedDate,LastUpdateBy,LastUpDateDate,");
            builder.Append("CreateUnit,CurrentUnit,IsDel,FirstTreatmenTTime,MildTroubleFrequen,CreateDistuFrequen, ");
            builder.Append("CauseAccidFrequen,AutolesionFrequen,AttemptSuicFrequen,AttemptSuicideNone,Professional,OtherDangerFrequen,HouseType ");
            builder.Append(" FROM CD_MENTALDISEASE_BASEINFO ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append("order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from CD_MENTALDISEASE_BASEINFO T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "CD_MENTALDISEASE_BASEINFO");
        }

        public ChronicMentalDiseaseBaseInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,GuardianRecordID,");
            builder.Append("GuardianName,Ralation,GuradianAddr,GuradianPhone,");
            builder.Append("FirstTime,AgreeManagement,AgreeSignature,AgreeTime,Symptom,SymptomOther,");
            builder.Append("OutPatien,HospitalCount,DiagnosisInfo,DiagnosisHospital,DiagnosisTime,LastCure,VillageContacts,");
            builder.Append("VillageTel,LockInfo,Economy,SpecialistProposal,FillformTime,DoctorMark,CreatedBy,");
            builder.Append("CreatedDate,LastUpdateBy,LastUpDateDate,CreateUnit,CurrentUnit,IsDel,");
            builder.Append("FirstTreatmenTTime,MildTroubleFrequen,CreateDistuFrequen,CauseAccidFrequen,");
            builder.Append("AutolesionFrequen,AttemptSuicFrequen,AttemptSuicideNone,Professional,OtherDangerFrequen,HouseType from CD_MENTALDISEASE_BASEINFO ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new ChronicMentalDiseaseBaseInfoModel();
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
            builder.Append("select count(1) FROM CD_MENTALDISEASE_BASEINFO ");
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

        public bool Update(ChronicMentalDiseaseBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_MENTALDISEASE_BASEINFO set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("GuardianRecordID=@GuardianRecordID,");
            builder.Append("GuardianName=@GuardianName,");
            builder.Append("Ralation=@Ralation,");
            builder.Append("GuradianAddr=@GuradianAddr,");
            builder.Append("GuradianPhone=@GuradianPhone,");
            builder.Append("FirstTime=@FirstTime,");
            builder.Append("AgreeManagement=@AgreeManagement,");
            builder.Append("AgreeSignature=@AgreeSignature,");
            builder.Append("AgreeTime=@AgreeTime,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("SymptomOther=@SymptomOther,");
            builder.Append("OutPatien=@OutPatien,");
            builder.Append("HospitalCount=@HospitalCount,");
            builder.Append("DiagnosisInfo=@DiagnosisInfo,");
            builder.Append("DiagnosisHospital=@DiagnosisHospital,");
            builder.Append("DiagnosisTime=@DiagnosisTime,");
            builder.Append("LastCure=@LastCure,");
            builder.Append("VillageContacts=@VillageContacts,");
            builder.Append("VillageTel=@VillageTel,");
            builder.Append("LockInfo=@LockInfo,");
            builder.Append("Economy=@Economy,");
            builder.Append("SpecialistProposal=@SpecialistProposal,");
            builder.Append("FillformTime=@FillformTime,");
            builder.Append("DoctorMark=@DoctorMark,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpDateDate=@LastUpDateDate,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("FirstTreatmenTTime=@FirstTreatmenTTime,");
            builder.Append("MildTroubleFrequen=@MildTroubleFrequen,");
            builder.Append("CreateDistuFrequen=@CreateDistuFrequen,");
            builder.Append("CauseAccidFrequen=@CauseAccidFrequen,");
            builder.Append("AutolesionFrequen=@AutolesionFrequen,");
            builder.Append("AttemptSuicFrequen=@AttemptSuicFrequen,");
            builder.Append("AttemptSuicideNone=@AttemptSuicideNone, ");
            builder.Append("Professional=@Professional,");
            builder.Append("OtherDangerFrequen=@OtherDangerFrequen, ");
            builder.Append("HouseType=@HouseType ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@GuardianRecordID", MySqlDbType.String, 17),
                new MySqlParameter("@GuardianName", MySqlDbType.String, 30), 
                new MySqlParameter("@Ralation", MySqlDbType.String, 1),
                new MySqlParameter("@GuradianAddr", MySqlDbType.String, 200),
                new MySqlParameter("@GuradianPhone", MySqlDbType.String, 15),
                new MySqlParameter("@FirstTime", MySqlDbType.Date),
                new MySqlParameter("@AgreeManagement", MySqlDbType.String, 1),
                new MySqlParameter("@AgreeSignature", MySqlDbType.String, 30),
                new MySqlParameter("@AgreeTime", MySqlDbType.Date), 
                new MySqlParameter("@Symptom", MySqlDbType.String, 50),
                new MySqlParameter("@SymptomOther", MySqlDbType.String, 200), 
                new MySqlParameter("@OutPatien", MySqlDbType.String, 1), 
                new MySqlParameter("@HospitalCount", MySqlDbType.Int32), 
                new MySqlParameter("@DiagnosisInfo", MySqlDbType.String, 500),
                new MySqlParameter("@DiagnosisHospital", MySqlDbType.String, 200),
                new MySqlParameter("@DiagnosisTime", MySqlDbType.Date),
                new MySqlParameter("@LastCure", MySqlDbType.String, 1),
                new MySqlParameter("@VillageContacts", MySqlDbType.String, 30),
                new MySqlParameter("@VillageTel", MySqlDbType.String, 15),
                new MySqlParameter("@LockInfo", MySqlDbType.String, 1), 
                new MySqlParameter("@Economy", MySqlDbType.String, 1), 
                new MySqlParameter("@SpecialistProposal", MySqlDbType.String, 500),
                new MySqlParameter("@FillformTime", MySqlDbType.Date),
                new MySqlParameter("@DoctorMark", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@FirstTreatmenTTime", MySqlDbType.Date), 
                new MySqlParameter("@MildTroubleFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CreateDistuFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CauseAccidFrequen", MySqlDbType.Int32), 
                new MySqlParameter("@AutolesionFrequen", MySqlDbType.Int32), 
                new MySqlParameter("@AttemptSuicFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AttemptSuicideNone", MySqlDbType.String, 2),
                new MySqlParameter("@Professional", MySqlDbType.String, 1),
                new MySqlParameter("@OtherDangerFrequen",MySqlDbType.Decimal),
                new MySqlParameter("@HouseType", MySqlDbType.String, 1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.GuardianRecordID;
            cmdParms[4].Value = model.GuardianName;
            cmdParms[5].Value = model.Ralation;
            cmdParms[6].Value = model.GuradianAddr;
            cmdParms[7].Value = model.GuradianPhone;
            cmdParms[8].Value = model.FirstTime;
            cmdParms[9].Value = model.AgreeManagement;
            cmdParms[10].Value = model.AgreeSignature;
            cmdParms[11].Value = model.AgreeTime;
            cmdParms[12].Value = model.Symptom;
            cmdParms[13].Value = model.SymptomOther;
            cmdParms[14].Value = model.OutPatien;
            cmdParms[15].Value = model.HospitalCount;
            cmdParms[16].Value = model.DiagnosisInfo;
            cmdParms[17].Value = model.DiagnosisHospital;
            cmdParms[18].Value = model.DiagnosisTime;
            cmdParms[19].Value = model.LastCure;
            cmdParms[20].Value = model.VillageContacts;
            cmdParms[21].Value = model.VillageTel;
            cmdParms[22].Value = model.LockInfo;
            cmdParms[23].Value = model.Economy;
            cmdParms[24].Value = model.SpecialistProposal;
            cmdParms[25].Value = model.FillformTime;
            cmdParms[26].Value = model.DoctorMark;
            cmdParms[27].Value = model.CreatedBy;
            cmdParms[28].Value = model.CreatedDate;
            cmdParms[29].Value = model.LastUpdateBy;
            cmdParms[30].Value = model.LastUpDateDate;
            cmdParms[31].Value = model.CreateUnit;
            cmdParms[32].Value = model.CurrentUnit;
            cmdParms[33].Value = model.IsDel;
            cmdParms[34].Value = model.FirstTreatmenTTime;
            cmdParms[35].Value = model.MildTroubleFrequen;
            cmdParms[36].Value = model.CreateDistuFrequen;
            cmdParms[37].Value = model.CauseAccidFrequen;
            cmdParms[38].Value = model.AutolesionFrequen;
            cmdParms[39].Value = model.AttemptSuicFrequen;
            cmdParms[40].Value = model.AttemptSuicideNone;
            cmdParms[41].Value = model.Professional;
            cmdParms[42].Value = model.OtherDangerFrequen;
            cmdParms[43].Value = model.HouseType;
            cmdParms[44].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(ChronicMentalDiseaseBaseInfoModel model)
        {

            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_MENTALDISEASE_BASEINFO set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("GuardianRecordID=@GuardianRecordID,");
            builder.Append("GuardianName=@GuardianName,");
            builder.Append("Ralation=@Ralation,");
            builder.Append("GuradianAddr=@GuradianAddr,");
            builder.Append("GuradianPhone=@GuradianPhone,");
            builder.Append("FirstTime=@FirstTime,");
            builder.Append("AgreeManagement=@AgreeManagement,");
            builder.Append("AgreeSignature=@AgreeSignature,");
            builder.Append("AgreeTime=@AgreeTime,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("SymptomOther=@SymptomOther,");
            builder.Append("OutPatien=@OutPatien,");
            builder.Append("HospitalCount=@HospitalCount,");
            builder.Append("DiagnosisInfo=@DiagnosisInfo,");
            builder.Append("DiagnosisHospital=@DiagnosisHospital,");
            builder.Append("DiagnosisTime=@DiagnosisTime,");
            builder.Append("LastCure=@LastCure,");
            builder.Append("VillageContacts=@VillageContacts,");
            builder.Append("VillageTel=@VillageTel,");
            builder.Append("LockInfo=@LockInfo,");
            builder.Append("Economy=@Economy,");
            builder.Append("SpecialistProposal=@SpecialistProposal,");
            builder.Append("FillformTime=@FillformTime,");
            builder.Append("DoctorMark=@DoctorMark,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpDateDate=@LastUpDateDate,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("FirstTreatmenTTime=@FirstTreatmenTTime,");
            builder.Append("MildTroubleFrequen=@MildTroubleFrequen,");
            builder.Append("CreateDistuFrequen=@CreateDistuFrequen,");
            builder.Append("CauseAccidFrequen=@CauseAccidFrequen,");
            builder.Append("AutolesionFrequen=@AutolesionFrequen,");
            builder.Append("AttemptSuicFrequen=@AttemptSuicFrequen,");
            builder.Append("AttemptSuicideNone=@AttemptSuicideNone, ");
            builder.Append("Professional=@Professional,");
            builder.Append("OtherDangerFrequen=@OtherDangerFrequen, ");
            builder.Append("HouseType=@HouseType ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@GuardianRecordID", MySqlDbType.String, 17),
                new MySqlParameter("@GuardianName", MySqlDbType.String, 30), 
                new MySqlParameter("@Ralation", MySqlDbType.String, 1),
                new MySqlParameter("@GuradianAddr", MySqlDbType.String, 200),
                new MySqlParameter("@GuradianPhone", MySqlDbType.String, 15),
                new MySqlParameter("@FirstTime", MySqlDbType.Date),
                new MySqlParameter("@AgreeManagement", MySqlDbType.String, 1),
                new MySqlParameter("@AgreeSignature", MySqlDbType.String, 30),
                new MySqlParameter("@AgreeTime", MySqlDbType.Date), 
                new MySqlParameter("@Symptom", MySqlDbType.String, 50),
                new MySqlParameter("@SymptomOther", MySqlDbType.String, 200), 
                new MySqlParameter("@OutPatien", MySqlDbType.String, 1), 
                new MySqlParameter("@HospitalCount", MySqlDbType.Int32), 
                new MySqlParameter("@DiagnosisInfo", MySqlDbType.String, 500),
                new MySqlParameter("@DiagnosisHospital", MySqlDbType.String, 200),
                new MySqlParameter("@DiagnosisTime", MySqlDbType.Date),
                new MySqlParameter("@LastCure", MySqlDbType.String, 1),
                new MySqlParameter("@VillageContacts", MySqlDbType.String, 30),
                new MySqlParameter("@VillageTel", MySqlDbType.String, 15),
                new MySqlParameter("@LockInfo", MySqlDbType.String, 1), 
                new MySqlParameter("@Economy", MySqlDbType.String, 1), 
                new MySqlParameter("@SpecialistProposal", MySqlDbType.String, 500),
                new MySqlParameter("@FillformTime", MySqlDbType.Date),
                new MySqlParameter("@DoctorMark", MySqlDbType.String, 30),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpDateDate", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@FirstTreatmenTTime", MySqlDbType.Date), 
                new MySqlParameter("@MildTroubleFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CreateDistuFrequen", MySqlDbType.Int32),
                new MySqlParameter("@CauseAccidFrequen", MySqlDbType.Int32), 
                new MySqlParameter("@AutolesionFrequen", MySqlDbType.Int32), 
                new MySqlParameter("@AttemptSuicFrequen", MySqlDbType.Int32),
                new MySqlParameter("@AttemptSuicideNone", MySqlDbType.String, 2),
                new MySqlParameter("@Professional", MySqlDbType.String, 1),
                new MySqlParameter("@OtherDangerFrequen",MySqlDbType.Decimal),
                new MySqlParameter("@HouseType", MySqlDbType.String, 1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.GuardianRecordID;
            cmdParms[4].Value = model.GuardianName;
            cmdParms[5].Value = model.Ralation;
            cmdParms[6].Value = model.GuradianAddr;
            cmdParms[7].Value = model.GuradianPhone;
            cmdParms[8].Value = model.FirstTime;
            cmdParms[9].Value = model.AgreeManagement;
            cmdParms[10].Value = model.AgreeSignature;
            cmdParms[11].Value = model.AgreeTime;
            cmdParms[12].Value = model.Symptom;
            cmdParms[13].Value = model.SymptomOther;
            cmdParms[14].Value = model.OutPatien;
            cmdParms[15].Value = model.HospitalCount;
            cmdParms[16].Value = model.DiagnosisInfo;
            cmdParms[17].Value = model.DiagnosisHospital;
            cmdParms[18].Value = model.DiagnosisTime;
            cmdParms[19].Value = model.LastCure;
            cmdParms[20].Value = model.VillageContacts;
            cmdParms[21].Value = model.VillageTel;
            cmdParms[22].Value = model.LockInfo;
            cmdParms[23].Value = model.Economy;
            cmdParms[24].Value = model.SpecialistProposal;
            cmdParms[25].Value = model.FillformTime;
            cmdParms[26].Value = model.DoctorMark;
            cmdParms[27].Value = model.CreatedBy;
            cmdParms[28].Value = model.CreatedDate;
            cmdParms[29].Value = model.LastUpdateBy;
            cmdParms[30].Value = model.LastUpDateDate;
            cmdParms[31].Value = model.CreateUnit;
            cmdParms[32].Value = model.CurrentUnit;
            cmdParms[33].Value = model.IsDel;
            cmdParms[34].Value = model.FirstTreatmenTTime;
            cmdParms[35].Value = model.MildTroubleFrequen;
            cmdParms[36].Value = model.CreateDistuFrequen;
            cmdParms[37].Value = model.CauseAccidFrequen;
            cmdParms[38].Value = model.AutolesionFrequen;
            cmdParms[39].Value = model.AttemptSuicFrequen;
            cmdParms[40].Value = model.AttemptSuicideNone;
            cmdParms[41].Value = model.Professional;
            cmdParms[42].Value = model.OtherDangerFrequen;
            cmdParms[43].Value = model.HouseType;
            cmdParms[44].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

