using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.DataAccessProjects.Model;
    using KangShuoTech.Utilities.MySQLHelper;
    using System.Data;
    using MySql.Data.MySqlClient;
    public class RecordsChdStrokeReportDAL
    {
        public int Add(RecordsChdStrokeReportModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ARCHIVE_CHD_STROKE_REPORT(");
            sb.Append("PatientNo,AdmissionNo,CardNo,IDCardNo,ICD10Code,Age,Phone,AddDistrict,HouesAddDistrict,AddTown,HouesAddTown,AddVillage,HouseAddVillage,AddNum,HouseAddNum,");
            sb.Append("AcuteMI,SAH,Diagnosis,DiseaseTime,DiagnosisTime,FirstOnset,ConfirmedUnit,CardUnit,CardDoctor,CardDate,DeathDate,DeathReason,DeathCode,OutKey )");
            sb.Append("values(");
            sb.Append("@PatientNo,@AdmissionNo,@CardNo,@IDCardNo,@ICD10Code,@Age,@Phone,@AddDistrict,@HouesAddDistrict,@AddTown,@HouesAddTown,@AddVillage,@HouseAddVillage,@AddNum,@HouseAddNum,");
            sb.Append("@AcuteMI,@SAH,@Diagnosis,@DiseaseTime,@DiagnosisTime,@FirstOnset,@ConfirmedUnit,@CardUnit,@CardDoctor,@CardDate,@DeathDate,@DeathReason,@DeathCode,@OutKey )");
            sb.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
             {
                 new MySqlParameter("@PatientNo", MySqlDbType.String, 20),
                 new MySqlParameter("@AdmissionNo", MySqlDbType.String, 20),
                 new MySqlParameter("@CardNo", MySqlDbType.String, 20),
                 new MySqlParameter("@IDCardNo", MySqlDbType.String, 18),
                 new MySqlParameter("@ICD10Code", MySqlDbType.String),
                 new MySqlParameter("@Age", MySqlDbType.String),
                 new MySqlParameter("@Phone", MySqlDbType.String),
                 new MySqlParameter("@AddDistrict", MySqlDbType.String),
                 new MySqlParameter("@HouesAddDistrict", MySqlDbType.String),
                 new MySqlParameter("@AddTown", MySqlDbType.String),
                 new MySqlParameter("@HouesAddTown", MySqlDbType.String),
                 new MySqlParameter("@AddVillage", MySqlDbType.String),
                 new MySqlParameter("@HouseAddVillage", MySqlDbType.String),
                 new MySqlParameter("@AddNum", MySqlDbType.String),
                 new MySqlParameter("@HouseAddNum", MySqlDbType.String),
                 new MySqlParameter("@AcuteMI", MySqlDbType.String),
                 
                 new MySqlParameter("@SAH", MySqlDbType.String),
                 
                 new MySqlParameter("@Diagnosis", MySqlDbType.String),
                 
                 new MySqlParameter("@DiseaseTime", MySqlDbType.Date),
                 new MySqlParameter("@DiagnosisTime", MySqlDbType.Date),
                 new MySqlParameter("@FirstOnset", MySqlDbType.String),
                 new MySqlParameter("@ConfirmedUnit", MySqlDbType.String),
                 new MySqlParameter("@CardUnit", MySqlDbType.String),
                 new MySqlParameter("@CardDoctor", MySqlDbType.String),
                 new MySqlParameter("@CardDate", MySqlDbType.Date),
                 new MySqlParameter("@DeathDate", MySqlDbType.Date),
                 new MySqlParameter("@DeathReason", MySqlDbType.String),
                 new MySqlParameter("@DeathCode", MySqlDbType.String),
                 new MySqlParameter("@OutKey",MySqlDbType.Int32,4)


             };
            cmdParms[0].Value = model.PatientNo;
            cmdParms[1].Value = model.AdmissionNo;
            cmdParms[2].Value = model.CardNo;
            cmdParms[3].Value = model.IDCardNo;
            cmdParms[4].Value = model.ICD10Code;
            cmdParms[5].Value = model.Age;
            cmdParms[6].Value = model.Phone;
            cmdParms[7].Value = model.AddDistrict;
            cmdParms[8].Value = model.HouesAddDistrict;
            cmdParms[9].Value = model.AddTown;
            cmdParms[10].Value = model.HouesAddTown;
            cmdParms[11].Value = model.AddVillage;
            cmdParms[12].Value = model.HouseAddVillage;
            cmdParms[13].Value = model.AddNum;
            cmdParms[14].Value = model.HouseAddNum;
            cmdParms[15].Value = model.AcuteMI;
            cmdParms[16].Value = model.SAH;
            cmdParms[17].Value = model.Diagnosis;
            cmdParms[18].Value = model.DiseaseTime;
            cmdParms[19].Value = model.DiagnosisTime;
            cmdParms[20].Value = model.FirstOnset;
            cmdParms[21].Value = model.ConfirmedUnit;
            cmdParms[22].Value = model.CardUnit;
            cmdParms[23].Value = model.CardDoctor;
            cmdParms[24].Value = model.CardDate;
            cmdParms[25].Value = model.DeathDate;
            cmdParms[26].Value = model.DeathReason;
            cmdParms[27].Value = model.DeathCode;
            cmdParms[28].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(sb.ToString(),cmdParms);
            if(single==null)
            {
                return 0;   
            }
            return Convert.ToInt32(single);

        }

        public bool Update(RecordsChdStrokeReportModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ARCHIVE_CHD_STROKE_REPORT set ");
            sb.Append("PatientNo=@PatientNo,AdmissionNo=@AdmissionNo,CardNo=@CardNo,IDCardNo=@IDCardNo,ICD10Code=@ICD10Code,AddDistrict=@AddDistrict,HouesAddDistrict=@HouesAddDistrict, ");
            sb.Append("AddTown=@AddTown,HouesAddTown=@HouesAddTown,AddVillage=@AddVillage,HouseAddVillage=@HouseAddVillage,AddNum=@AddNum,HouseAddNum=@HouseAddNum, ");
            sb.Append("AcuteMI=@AcuteMI,SAH=@SAH,Diagnosis=@Diagnosis,");
            sb.Append("DiseaseTime=@DiseaseTime,DiagnosisTime=@DiagnosisTime,FirstOnset=@FirstOnset,");
            sb.Append("ConfirmedUnit=@ConfirmedUnit,CardUnit=@CardUnit,CardDoctor=@CardDoctor,CardDate=@CardDate,DeathDate=@DeathDate,DeathReason=@DeathReason,DeathCode=@DeathCode,OutKey=@OutKey ");
            sb.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
               new MySqlParameter("@PatientNo", MySqlDbType.String, 20),
                 new MySqlParameter("@AdmissionNo", MySqlDbType.String, 20),
                 new MySqlParameter("@CardNo", MySqlDbType.String, 20),
                 new MySqlParameter("@IDCardNo", MySqlDbType.String, 18),
                 new MySqlParameter("@ICD10Code", MySqlDbType.String),
                 new MySqlParameter("@AddDistrict", MySqlDbType.String),
                 new MySqlParameter("@HouesAddDistrict", MySqlDbType.String),
                 new MySqlParameter("@AddTown", MySqlDbType.String),
                 new MySqlParameter("@HouesAddTown", MySqlDbType.String),
                 new MySqlParameter("@AddVillage", MySqlDbType.String),
                 new MySqlParameter("@HouseAddVillage", MySqlDbType.String),
                 new MySqlParameter("@AddNum", MySqlDbType.String),
                 new MySqlParameter("@HouseAddNum", MySqlDbType.String),
                 new MySqlParameter("@AcuteMI", MySqlDbType.String),

                 new MySqlParameter("@SAH", MySqlDbType.String),

                 new MySqlParameter("@Diagnosis", MySqlDbType.String),

                 new MySqlParameter("@DiseaseTime", MySqlDbType.Date),
                 new MySqlParameter("@DiagnosisTime", MySqlDbType.Date),
                 new MySqlParameter("@FirstOnset", MySqlDbType.String),
                 new MySqlParameter("@ConfirmedUnit", MySqlDbType.String),
                 new MySqlParameter("@CardUnit", MySqlDbType.String),
                 new MySqlParameter("@CardDoctor", MySqlDbType.String),
                 new MySqlParameter("@CardDate", MySqlDbType.Date),
                 new MySqlParameter("@DeathDate", MySqlDbType.Date),
                 new MySqlParameter("@DeathReason", MySqlDbType.String),
                 new MySqlParameter("@DeathCode", MySqlDbType.String),
                 new MySqlParameter("@OutKey",MySqlDbType.Int32,4),
                 new MySqlParameter("@ID", MySqlDbType.Int32)
            };

            cmdParms[0].Value = model.PatientNo;
            cmdParms[1].Value = model.AdmissionNo;
            cmdParms[2].Value = model.CardNo;
            cmdParms[3].Value = model.IDCardNo;
            cmdParms[4].Value = model.ICD10Code;
            cmdParms[5].Value = model.AddDistrict;
            cmdParms[6].Value = model.HouesAddDistrict;
            cmdParms[7].Value = model.AddTown;
            cmdParms[8].Value = model.HouesAddTown;
            cmdParms[9].Value = model.AddVillage;
            cmdParms[10].Value = model.HouseAddVillage;
            cmdParms[11].Value = model.AddNum;
            cmdParms[12].Value = model.HouseAddNum;
            cmdParms[13].Value = model.AcuteMI;

            cmdParms[14].Value = model.SAH;

            cmdParms[15].Value = model.Diagnosis;

            cmdParms[16].Value = model.DiseaseTime;
            cmdParms[17].Value = model.DiagnosisTime;
            cmdParms[18].Value = model.FirstOnset;
            cmdParms[19].Value = model.ConfirmedUnit;
            cmdParms[20].Value = model.CardUnit;
            cmdParms[21].Value = model.CardDoctor;
            cmdParms[22].Value = model.CardDate;
            cmdParms[23].Value = model.DeathDate;
            cmdParms[24].Value = model.DeathReason;
            cmdParms[25].Value = model.DeathCode;
            cmdParms[26].Value = model.OutKey;
            cmdParms[27].Value = model.ID;
            return (MySQLHelper.ExecuteSql(sb.ToString(), cmdParms) > 0);
        }

        public RecordsChdStrokeReportModel GetModel(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID ,PatientNo,AdmissionNo,CardNo,IDCardNo,ICD10Code,Age,Phone,AddDistrict,HouesAddDistrict,AddTown,HouesAddTown,AddVillage,HouseAddVillage,AddNum,HouseAddNum,");
            builder.Append("AcuteMI,SAH,Diagnosis,DiseaseTime,DiagnosisTime,FirstOnset,ConfirmedUnit,CardUnit,CardDoctor,CardDate,DeathDate,DeathReason,DeathCode,OutKey ");
            builder.Append(" FROM ARCHIVE_CHD_STROKE_REPORT where OutKey=@OutKey ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32) };
            cmdParms[0].Value = OutKey;
            new RecordsChdStrokeReportModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            if (set.Tables[0].Rows.Count > 0)
            {
                return this.GetRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public RecordsChdStrokeReportModel GetRowToModel(DataRow row)
        {
            RecordsChdStrokeReportModel model=new RecordsChdStrokeReportModel();
            if(row!=null)
            {
                if((row["ID"]!=null)&&(row["ID"]!=DBNull.Value)&&(row["ID"]!=""))
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if(row["PatientNo"]!=null && row["PatientNo"]!=DBNull.Value)
                {
                    model.PatientNo = row["PatientNo"].ToString();
                }
                if(row["AdmissionNo"]!=null && row["AdmissionNo"]!=DBNull.Value)
                {
                    model.AdmissionNo = row["AdmissionNo"].ToString();
                }
                if(row["CardNo"]!=null && row["CardNo"]!=DBNull.Value)
                {
                    model.CardNo = row["CardNo"].ToString();
                }
                if (row["Age"] != null && row["Age"] != DBNull.Value)
                {
                    model.Age = row["Age"].ToString();
                }
                if(row["ICD10Code"]!=null && row["ICD10Code"]!=DBNull.Value)
                {
                    model.ICD10Code = row["ICD10Code"].ToString();
                }
                if(row["AddDistrict"]!=null && row["AddDistrict"]!=DBNull.Value)
                {
                    model.AddDistrict = row["AddDistrict"].ToString();
                }
                if(row["HouesAddDistrict"]!=null && row["HouesAddDistrict"]!=DBNull.Value)
                {
                    model.HouesAddDistrict = row["HouesAddDistrict"].ToString();
                }
                if(row["AddTown"]!=null && row["AddTown"]!=DBNull.Value)
                {
                    model.AddTown = row["AddTown"].ToString();
                }
                if (row["HouesAddTown"] != null && row["HouesAddTown"] != DBNull.Value)
                {
                    model.HouesAddTown = row["HouesAddTown"].ToString();
                }
                if (row["AddVillage"] != null && row["AddVillage"] != DBNull.Value)
                {
                    model.AddVillage = row["AddVillage"].ToString();
                }
                if (row["HouseAddVillage"] != null && row["HouseAddVillage"] != DBNull.Value)
                {
                    model.HouseAddVillage = row["HouseAddVillage"].ToString();
                }
                if (row["AddNum"] != null && row["AddNum"] != DBNull.Value)
                {
                    model.AddNum = row["AddNum"].ToString();
                }
                if (row["HouseAddNum"] != null && row["HouseAddNum"] != DBNull.Value)
                {
                    model.HouseAddNum = row["HouseAddNum"].ToString();
                }
                if (row["AcuteMI"] != null && row["AcuteMI"] != DBNull.Value)
                {
                    model.AcuteMI = row["AcuteMI"].ToString();
                }
                if (row["Diagnosis"] != null && row["Diagnosis"] != DBNull.Value)
                {
                    model.Diagnosis = row["Diagnosis"].ToString();
                }
                if (row["SAH"] != null && row["SAH"] != DBNull.Value)
                {
                    model.SAH = row["SAH"].ToString();
                }
                if (row["DiseaseTime"] != null && row["DiseaseTime"] != DBNull.Value && row["DiseaseTime"] != "")
                {
                    model.DiseaseTime = new DateTime?(DateTime.Parse(row["DiseaseTime"].ToString()));
                }
                if (row["DiagnosisTime"] != null && row["DiagnosisTime"] != DBNull.Value && row["DiagnosisTime"] != "")
                {
                    model.DiagnosisTime = new DateTime?(DateTime.Parse(row["DiagnosisTime"].ToString()));
                }
                if (row["FirstOnset"] != null && row["FirstOnset"] != DBNull.Value)
                {
                    model.FirstOnset = row["FirstOnset"].ToString();
                }
                if (row["ConfirmedUnit"] != null && row["ConfirmedUnit"] != DBNull.Value)
                {
                    model.ConfirmedUnit = row["ConfirmedUnit"].ToString();
                }
                if (row["CardUnit"] != null && row["CardUnit"] != DBNull.Value)
                {
                    model.CardUnit = row["CardUnit"].ToString();
                }
                if(row["CardDoctor"]!=null && row["CardDoctor"]!=DBNull.Value)
                {
                    model.CardDoctor = row["CardDoctor"].ToString();
                }
                if(row["CardDate"]!=null && row["CardDate"]!=DBNull.Value && row["CardDate"]!="")
                {
                    model.CardDate = new DateTime?(DateTime.Parse(row["CardDate"].ToString()));
                }
                if (row["DeathDate"] != null && row["DeathDate"] != DBNull.Value && row["DeathDate"] != "")
                {
                    model.DeathDate = new DateTime?(DateTime.Parse(row["DeathDate"].ToString()));
                }
                if (row["DeathReason"] != null && row["DeathReason"] != DBNull.Value)
                {
                    model.DeathReason = row["DeathReason"].ToString();
                }
                if (row["CardDoctor"] != null && row["CardDoctor"] != DBNull.Value)
                {
                    model.DeathCode = row["DeathCode"].ToString();
                }
                if (((row["OutKey"] != null) && (row["OutKey"] != DBNull.Value)) && (row["OutKey"].ToString() != ""))
                {
                    model.OutKey = int.Parse(row["OutKey"].ToString());
                }
            }
            return model;
        }

        public bool Exists(int ID)
        {
            string str = "select count(1) from ARCHIVE_CHD_STROKE_REPORT where ID='"+ID+"'";
            return MySQLHelper.Exists(str); 
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID ,PatientNo,AdmissionNo,CardNo,IDCardNo,ICD10Code,Age,Phone,AddDistrict,HouesAddDistrict,AddTown,HouesAddTown,AddVillage,HouseAddVillage,AddNum,HouseAddNum,");
            builder.Append("AcuteMI,SAH,Diagnosis,DiseaseTime,DiagnosisTime,FirstOnset,ConfirmedUnit,CardUnit,CardDoctor,CardDate,DeathDate,DeathReason,DeathCode,OutKey ");
            builder.Append(" FROM ARCHIVE_CHD_STROKE_REPORT ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_CHD_STROKE_REPORT");
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
