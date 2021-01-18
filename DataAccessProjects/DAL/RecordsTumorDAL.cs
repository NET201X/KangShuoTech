using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsTumorDAL
    {
        public int Add(RecordsTumorModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_TUMOR(");
            builder.Append("IDCardNo,RecordID,Age,ClinicID,ICD,ICDO,HospitalizationID,Phone,OrigDiagnose,MedicareCardID,HouseholtDistict,HouseholtTown, ");
            builder.Append("HouseholtVillage,HouseholtNum,PresentDistict,PresentTown,PresentVillage,PresentNum,PathologyType,PrimaryParts,");
            builder.Append("StageT,StageN,StageM,ReportsUnit,ReportsDoctor,DieReason,Judgment,OrigDiagnoseDate,DiagnoseDate,DieDate,ReportDate,Diagnose,OutKey )");
            builder.Append(" values (");
            builder.Append("@IDCardNo,@RecordID,@Age,@ClinicID,@ICD,@ICDO,@HospitalizationID,@Phone,@OrigDiagnose,@MedicareCardID,@HouseholtDistict,@HouseholtTown, ");
            builder.Append("@HouseholtVillage,@HouseholtNum,@PresentDistict,@PresentTown,@PresentVillage,@PresentNum,@PathologyType,@PrimaryParts,");
            builder.Append("@StageT,@StageN,@StageM,@ReportsUnit,@ReportsDoctor,@DieReason,@Judgment,@OrigDiagnoseDate,@DiagnoseDate,@DieDate,@ReportDate,@Diagnose,@OutKey )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String), 
                new MySqlParameter("@Age", MySqlDbType.Int32), 
                new MySqlParameter("@ClinicID", MySqlDbType.String), 
                new MySqlParameter("@ICD", MySqlDbType.String),
                new MySqlParameter("@ICDO", MySqlDbType.String),
                new MySqlParameter("@HospitalizationID", MySqlDbType.String),
                new MySqlParameter("@Phone", MySqlDbType.String),
                new MySqlParameter("@OrigDiagnose", MySqlDbType.String),
                new MySqlParameter("@MedicareCardID", MySqlDbType.String),
                new MySqlParameter("@HouseholtDistict", MySqlDbType.String),
                new MySqlParameter("@HouseholtTown", MySqlDbType.String),
                new MySqlParameter("@HouseholtVillage", MySqlDbType.String),
                new MySqlParameter("@HouseholtNum", MySqlDbType.String),
                new MySqlParameter("@PresentDistict", MySqlDbType.String),
                new MySqlParameter("@PresentTown", MySqlDbType.String),
                new MySqlParameter("@PresentVillage", MySqlDbType.String),
                new MySqlParameter("@PresentNum", MySqlDbType.String),
                new MySqlParameter("@PathologyType", MySqlDbType.String),
                new MySqlParameter("@PrimaryParts", MySqlDbType.String),
                new MySqlParameter("@StageT", MySqlDbType.String),
                new MySqlParameter("@StageN", MySqlDbType.String),
                new MySqlParameter("@StageM", MySqlDbType.String),
                new MySqlParameter("@ReportsUnit", MySqlDbType.String),
                new MySqlParameter("@ReportsDoctor", MySqlDbType.String),
                new MySqlParameter("@DieReason", MySqlDbType.String),
                new MySqlParameter("@Judgment", MySqlDbType.String),
                new MySqlParameter("@OrigDiagnoseDate", MySqlDbType.Date),
                new MySqlParameter("@DiagnoseDate", MySqlDbType.Date),
                new MySqlParameter("@DieDate", MySqlDbType.Date),
                new MySqlParameter("@ReportDate",MySqlDbType.Date),
                new MySqlParameter("@Diagnose",MySqlDbType.String),
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.Age;
            cmdParms[3].Value = model.ClinicID;
            cmdParms[4].Value = model.ICD;
            cmdParms[5].Value = model.ICDO;
            cmdParms[6].Value = model.HospitalizationID;
            cmdParms[7].Value = model.Phone;
            cmdParms[8].Value = model.OrigDiagnose;
            cmdParms[9].Value = model.MedicareCardID;
            cmdParms[10].Value = model.HouseholtDistict;
            cmdParms[11].Value = model.HouseholtTown;
            cmdParms[12].Value = model.HouseholtVillage;
            cmdParms[13].Value = model.HouseholtNum;
            cmdParms[14].Value = model.PresentDistict;
            cmdParms[15].Value = model.PresentTown;
            cmdParms[16].Value = model.PresentVillage;
            cmdParms[17].Value = model.PresentNum;
            cmdParms[18].Value = model.PathologyType;
            cmdParms[19].Value = model.PrimaryParts;
            cmdParms[20].Value = model.StageT;
            cmdParms[21].Value = model.StageN;
            cmdParms[22].Value = model.StageM;
            cmdParms[23].Value = model.ReportsUnit;
            cmdParms[24].Value = model.ReportsDoctor;
            cmdParms[25].Value = model.DieReason;
            cmdParms[26].Value = model.Judgment;
            cmdParms[27].Value = model.OrigDiagnoseDate;
            cmdParms[28].Value = model.DiagnoseDate;
            cmdParms[29].Value = model.DieDate;
            cmdParms[30].Value = model.ReportDate;
            cmdParms[31].Value = model.Diagnose;
            cmdParms[32].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public RecordsTumorModel DataRowToModel(DataRow row)
        {
            RecordsTumorModel TumorModel = new RecordsTumorModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    TumorModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    TumorModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    TumorModel.RecordID = row["RecordID"].ToString();
                }
                if (((row["Age"] != null) && (row["Age"] != DBNull.Value)) && (row["Age"].ToString() != ""))
                {
                    TumorModel.Age =row["Age"].ToString();
                }
                if ((row["ClinicID"] != null) && (row["ClinicID"] != DBNull.Value))
                {
                    TumorModel.ClinicID = row["ClinicID"].ToString();
                }
                if ((row["ICD"] != null) && (row["ICD"] != DBNull.Value))
                {
                    TumorModel.ICD = row["ICD"].ToString();
                }
                if ((row["ICDO"] != null) && (row["ICDO"] != DBNull.Value))
                {
                    TumorModel.ICDO = row["ICDO"].ToString();
                }
                if ((row["HospitalizationID"] != null) && (row["HospitalizationID"] != DBNull.Value))
                {
                    TumorModel.HospitalizationID = row["HospitalizationID"].ToString();
                }
                if ((row["Phone"] != null) && (row["Phone"] != DBNull.Value))
                {
                    TumorModel.Phone = row["Phone"].ToString();
                }
                if ((row["OrigDiagnose"] != null) && (row["OrigDiagnose"] != DBNull.Value))
                {
                    TumorModel.OrigDiagnose = row["OrigDiagnose"].ToString();
                }
                if ((row["MedicareCardID"] != null) && (row["MedicareCardID"] != DBNull.Value))
                {
                    TumorModel.MedicareCardID = row["MedicareCardID"].ToString();
                }
                if ((row["HouseholtDistict"] != null) && (row["HouseholtDistict"] != DBNull.Value))
                {
                    TumorModel.HouseholtDistict = row["HouseholtDistict"].ToString();
                }
                if ((row["HouseholtTown"] != null) && (row["HouseholtTown"] != DBNull.Value))
                {
                    TumorModel.HouseholtTown = row["HouseholtTown"].ToString();
                }
                if ((row["HouseholtVillage"] != null) && (row["HouseholtVillage"] != DBNull.Value))
                {
                    TumorModel.HouseholtVillage = row["HouseholtVillage"].ToString();
                }
                if ((row["HouseholtNum"] != null) && (row["HouseholtNum"] != DBNull.Value))
                {
                    TumorModel.HouseholtNum = row["HouseholtNum"].ToString();
                }
                if ((row["PresentDistict"] != null) && (row["PresentDistict"] != DBNull.Value))
                {
                    TumorModel.PresentDistict = row["PresentDistict"].ToString();
                }
                if ((row["PresentTown"] != null) && (row["PresentTown"] != DBNull.Value))
                {
                    TumorModel.PresentTown = row["PresentTown"].ToString();
                }
                if ((row["PresentVillage"] != null) && (row["PresentVillage"] != DBNull.Value))
                {
                    TumorModel.PresentVillage = row["PresentVillage"].ToString();
                }
                if ((row["PresentNum"] != null) && (row["PresentNum"] != DBNull.Value))
                {
                    TumorModel.PresentNum = row["PresentNum"].ToString();
                }
                if ((row["PathologyType"] != null) && (row["PathologyType"] != DBNull.Value))
                {
                    TumorModel.PathologyType = row["PathologyType"].ToString();
                }
                if ((row["PrimaryParts"] != null) && (row["PrimaryParts"] != DBNull.Value))
                {
                    TumorModel.PrimaryParts = row["PrimaryParts"].ToString();
                }
                if ((row["StageT"] != null) && (row["StageT"] != DBNull.Value))
                {
                    TumorModel.StageT = row["StageT"].ToString();
                }
                if ((row["StageN"] != null) && (row["StageN"] != DBNull.Value))
                {
                    TumorModel.StageN = row["StageN"].ToString();
                }
                if ((row["StageM"] != null) && (row["StageM"] != DBNull.Value))
                {
                    TumorModel.StageM = row["StageM"].ToString();
                }
                if ((row["ReportsUnit"] != null) && (row["ReportsUnit"] != DBNull.Value))
                {
                    TumorModel.ReportsUnit = row["ReportsUnit"].ToString();
                }
                if ((row["ReportsDoctor"] != null) && (row["ReportsDoctor"] != DBNull.Value))
                {
                    TumorModel.ReportsDoctor = row["ReportsDoctor"].ToString();
                }
                if ((row["DieReason"] != null) && (row["DieReason"] != DBNull.Value))
                {
                    TumorModel.DieReason = row["DieReason"].ToString();
                }
                if ((row["Judgment"] != null) && (row["Judgment"] != DBNull.Value))
                {
                    TumorModel.Judgment = row["Judgment"].ToString();
                }
                if (((row["OrigDiagnoseDate"] != null) && (row["OrigDiagnoseDate"] != DBNull.Value)) && (row["OrigDiagnoseDate"].ToString() != ""))
                {
                    TumorModel.OrigDiagnoseDate = new DateTime?(DateTime.Parse(row["OrigDiagnoseDate"].ToString()));
                }
                if (((row["DiagnoseDate"] != null) && (row["DiagnoseDate"] != DBNull.Value)) && (row["DiagnoseDate"].ToString() != ""))
                {
                    TumorModel.DiagnoseDate = new DateTime?(DateTime.Parse(row["DiagnoseDate"].ToString()));
                }
                if (((row["DieDate"] != null) && (row["DieDate"] != DBNull.Value)) && (row["DieDate"].ToString() != ""))
                {
                    TumorModel.DieDate = new DateTime?(DateTime.Parse(row["DieDate"].ToString()));
                }
                if(row["ReportDate"]!=null && row["ReportDate"]!=DBNull.Value && row["ReportDate"].ToString()!="")
                {
                    TumorModel.ReportDate = new DateTime?(DateTime.Parse(row["ReportDate"].ToString()));
                }
                if ((row["Diagnose"] != null) && (row["Diagnose"] != DBNull.Value))
                {
                    TumorModel.Diagnose = row["Diagnose"].ToString();
                }
                if (((row["OutKey"] != null) && (row["OutKey"] != DBNull.Value)) && (row["OutKey"].ToString() != ""))
                {
                    TumorModel.OutKey = int.Parse(row["OutKey"].ToString());
                }
            }
            return TumorModel;
        }
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_TUMOR ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_TUMOR ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_TUMOR ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,RecordID,Age,ClinicID,ICD,ICDO,HospitalizationID,Phone,OrigDiagnose,MedicareCardID,HouseholtDistict,HouseholtTown, ");
            builder.Append("HouseholtVillage,HouseholtNum,PresentDistict,PresentTown,PresentVillage,PresentNum,PathologyType,PrimaryParts,");
            builder.Append("StageT,StageN,StageM,ReportsUnit,ReportsDoctor,DieReason,Judgment,OrigDiagnoseDate,DiagnoseDate,DieDate,ReportDate,Diagnose,OutKey ");
            builder.Append(" FROM ARCHIVE_TUMOR ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }
        public RecordsTumorModel GetModel(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,RecordID,Age,ClinicID,ICD,ICDO,HospitalizationID,Phone,OrigDiagnose,MedicareCardID,HouseholtDistict,HouseholtTown, ");
            builder.Append("HouseholtVillage,HouseholtNum,PresentDistict,PresentTown,PresentVillage,PresentNum,PathologyType,PrimaryParts,");
            builder.Append("StageT,StageN,StageM,ReportsUnit,ReportsDoctor,DieReason,Judgment,OrigDiagnoseDate,DiagnoseDate,DieDate,ReportDate,Diagnose,OutKey ");
            builder.Append(" from ARCHIVE_TUMOR where OutKey=@OutKey ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32) };
            cmdParms[0].Value = OutKey;
            new RecordsTumorModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public bool Update(RecordsTumorModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_TUMOR set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("Age=@Age,");
            builder.Append("ClinicID=@ClinicID,");
            builder.Append("ICD=@ICD,");
            builder.Append("ICDO=@ICDO,");
            builder.Append("HospitalizationID=@HospitalizationID,");
            builder.Append("Phone=@Phone,");
            builder.Append("OrigDiagnose=@OrigDiagnose,");
            builder.Append("MedicareCardID=@MedicareCardID,");
            builder.Append("HouseholtDistict=@HouseholtDistict,");
            builder.Append("HouseholtTown=@HouseholtTown,");
            builder.Append("HouseholtVillage=@HouseholtVillage,");
            builder.Append("HouseholtNum=@HouseholtNum,");
            builder.Append("PresentDistict=@PresentDistict,");
            builder.Append("PresentTown=@PresentTown,");
            builder.Append("PresentVillage=@PresentVillage,");
            builder.Append("PresentNum=@PresentNum,");
            builder.Append("PathologyType=@PathologyType,");
            builder.Append("PrimaryParts=@PrimaryParts,");
            builder.Append("StageT=@StageT,");
            builder.Append("StageN=@StageN,");
            builder.Append("StageM=@StageM,");
            builder.Append("ReportsUnit=@ReportsUnit,");
            builder.Append("ReportsDoctor=@ReportsDoctor,");
            builder.Append("DieReason=@DieReason,");
            builder.Append("Judgment=@Judgment,");
            builder.Append("OrigDiagnoseDate=@OrigDiagnoseDate,");
            builder.Append("DiagnoseDate=@DiagnoseDate,");
            builder.Append("DieDate=@DieDate, ");
            builder.Append("ReportDate=@ReportDate,");
            builder.Append("Diagnose=@Diagnose, ");
            builder.Append("OutKey=@OutKey ");
            builder.Append(" where ID=@ID ");
            MySqlParameter[] cmdParms = new MySqlParameter[] 
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String), 
                new MySqlParameter("@Age", MySqlDbType.Int32), 
                new MySqlParameter("@ClinicID", MySqlDbType.String), 
                new MySqlParameter("@ICD", MySqlDbType.String),
                new MySqlParameter("@ICDO", MySqlDbType.String),
                new MySqlParameter("@HospitalizationID", MySqlDbType.String),
                new MySqlParameter("@Phone", MySqlDbType.String),
                new MySqlParameter("@OrigDiagnose", MySqlDbType.String),
                new MySqlParameter("@MedicareCardID", MySqlDbType.String),
                new MySqlParameter("@HouseholtDistict", MySqlDbType.String),
                new MySqlParameter("@HouseholtTown", MySqlDbType.String),
                new MySqlParameter("@HouseholtVillage", MySqlDbType.String),
                new MySqlParameter("@HouseholtNum", MySqlDbType.String),
                new MySqlParameter("@PresentDistict", MySqlDbType.String),
                new MySqlParameter("@PresentTown", MySqlDbType.String),
                new MySqlParameter("@PresentVillage", MySqlDbType.String),
                new MySqlParameter("@PresentNum", MySqlDbType.String),
                new MySqlParameter("@PathologyType", MySqlDbType.String),
                new MySqlParameter("@PrimaryParts", MySqlDbType.String),
                new MySqlParameter("@StageT", MySqlDbType.String),
                new MySqlParameter("@StageN", MySqlDbType.String),
                new MySqlParameter("@StageM", MySqlDbType.String),
                new MySqlParameter("@ReportsUnit", MySqlDbType.String),
                new MySqlParameter("@ReportsDoctor", MySqlDbType.String),
                new MySqlParameter("@DieReason", MySqlDbType.String),
                new MySqlParameter("@Judgment", MySqlDbType.String),
                new MySqlParameter("@OrigDiagnoseDate", MySqlDbType.Date),
                new MySqlParameter("@DiagnoseDate", MySqlDbType.Date),
                new MySqlParameter("@DieDate", MySqlDbType.Date),
                new MySqlParameter("@ReportDate",MySqlDbType.Date), 
                new MySqlParameter("@Diagnose",MySqlDbType.String), 
                new MySqlParameter("@OutKey",MySqlDbType.Int32,4),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8) 
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.Age;
            cmdParms[3].Value = model.ClinicID;
            cmdParms[4].Value = model.ICD;
            cmdParms[5].Value = model.ICDO;
            cmdParms[6].Value = model.HospitalizationID;
            cmdParms[7].Value = model.Phone;
            cmdParms[8].Value = model.OrigDiagnose;
            cmdParms[9].Value = model.MedicareCardID;
            cmdParms[10].Value = model.HouseholtDistict;
            cmdParms[11].Value = model.HouseholtTown;
            cmdParms[12].Value = model.HouseholtVillage;
            cmdParms[13].Value = model.HouseholtNum;
            cmdParms[14].Value = model.PresentDistict;
            cmdParms[15].Value = model.PresentTown;
            cmdParms[16].Value = model.PresentVillage;
            cmdParms[17].Value = model.PresentNum;
            cmdParms[18].Value = model.PathologyType;
            cmdParms[19].Value = model.PrimaryParts;
            cmdParms[20].Value = model.StageT;
            cmdParms[21].Value = model.StageN;
            cmdParms[22].Value = model.StageM;
            cmdParms[23].Value = model.ReportsUnit;
            cmdParms[24].Value = model.ReportsDoctor;
            cmdParms[25].Value = model.DieReason;
            cmdParms[26].Value = model.Judgment;
            cmdParms[27].Value = model.OrigDiagnoseDate;
            cmdParms[28].Value = model.DiagnoseDate;
            cmdParms[29].Value = model.DieDate;
            cmdParms[30].Value = model.ReportDate;
            cmdParms[31].Value = model.Diagnose;
            cmdParms[32].Value = model.OutKey;
            cmdParms[33].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_TUMOR");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) 
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OutKey;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

    }
}
