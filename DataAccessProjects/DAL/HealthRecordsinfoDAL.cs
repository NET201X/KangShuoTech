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
    public class HealthRecordsinfoDAL
    {
        public int Add(HealthRecordsinfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_BASEINFO_OUT(");
            builder.Append("IDCardNo,Prevalence,PrevalenceOther,OrgTelphone,FamilyDoctor,FamilyDoctorTel,Nurses,NursesTel,HealthPersonnel,HealthPersonnelTel,Others)");
            builder.Append(" values (");
            builder.Append("@IDCardNo,@Prevalence,@PrevalenceOther,@OrgTelphone,@FamilyDoctor,@FamilyDoctorTel,@Nurses,@NursesTel,@HealthPersonnel,@HealthPersonnelTel,@Others)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String,21), 
                new MySqlParameter("@Prevalence", MySqlDbType.String,20), 
                new MySqlParameter("@PrevalenceOther", MySqlDbType.String), 
                new MySqlParameter("@OrgTelphone", MySqlDbType.String,100), 
                new MySqlParameter("@FamilyDoctor", MySqlDbType.String,100), 
                new MySqlParameter("@FamilyDoctorTel", MySqlDbType.String,100),
                new MySqlParameter("@Nurses", MySqlDbType.String,100),
                new MySqlParameter("@NursesTel",MySqlDbType.String,100),
                new MySqlParameter("@HealthPersonnel", MySqlDbType.String,100),
                new MySqlParameter("@HealthPersonnelTel", MySqlDbType.String,100),
                new MySqlParameter("@Others", MySqlDbType.String,500)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Prevalence;
            cmdParms[2].Value = model.PrevalenceOther;
            cmdParms[3].Value = model.OrgTelphone;
            cmdParms[4].Value = model.FamilyDoctor;
            cmdParms[5].Value = model.FamilyDoctorTel;
            cmdParms[6].Value = model.Nurses;
            cmdParms[7].Value = model.NursesTel;
            cmdParms[8].Value = model.HealthPersonnel;
            cmdParms[9].Value = model.HealthPersonnelTel;
            cmdParms[10].Value = model.Others;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public HealthRecordsinfoModel DataRowToModel(DataRow row)
        {
            HealthRecordsinfoModel healthRecordsinfoModel = new HealthRecordsinfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    healthRecordsinfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    healthRecordsinfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Prevalence"] != null) && (row["Prevalence"] != DBNull.Value))
                {
                    healthRecordsinfoModel.Prevalence = row["Prevalence"].ToString();
                }
                if ((row["PrevalenceOther"] != null) && (row["PrevalenceOther"] != DBNull.Value))
                {
                    healthRecordsinfoModel.PrevalenceOther = row["PrevalenceOther"].ToString();
                }
                if ((row["OrgTelphone"] != null) && (row["OrgTelphone"] != DBNull.Value))
                {
                    healthRecordsinfoModel.OrgTelphone = row["OrgTelphone"].ToString();
                }
                if ((row["FamilyDoctor"] != null) && (row["FamilyDoctor"] != DBNull.Value))
                {
                    healthRecordsinfoModel.FamilyDoctor = row["FamilyDoctor"].ToString();
                }
                if ((row["FamilyDoctorTel"] != null) && (row["FamilyDoctorTel"] != DBNull.Value))
                {
                    healthRecordsinfoModel.FamilyDoctorTel = row["FamilyDoctorTel"].ToString();
                }
                if ((row["Nurses"] != null) && (row["Nurses"] != DBNull.Value))
                {
                    healthRecordsinfoModel.Nurses = row["Nurses"].ToString();
                }
                if ((row["NursesTel"] != null) && (row["NursesTel"] != DBNull.Value))
                {
                    healthRecordsinfoModel.NursesTel = row["NursesTel"].ToString();
                }
                if ((row["HealthPersonnel"] != null) && (row["HealthPersonnel"] != DBNull.Value))
                {
                    healthRecordsinfoModel.HealthPersonnel = row["HealthPersonnel"].ToString();
                }
                if ((row["HealthPersonnelTel"] != null) && (row["HealthPersonnelTel"] != DBNull.Value))
                {
                    healthRecordsinfoModel.HealthPersonnelTel = row["HealthPersonnelTel"].ToString();
                }
                if ((row["Others"] != null) && (row["Others"] != DBNull.Value))
                {
                    healthRecordsinfoModel.Others = row["Others"].ToString();
                }
  
            }
            return healthRecordsinfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_BASEINFO_OUT ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_BASEINFO_OUT");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM ARCHIVE_BASEINFO_OUT ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public HealthRecordsinfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  * from ARCHIVE_BASEINFO_OUT ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
           
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public bool Update(HealthRecordsinfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_BASEINFO_OUT set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Prevalence=@Prevalence,");
            builder.Append("PrevalenceOther=@PrevalenceOther,");
            builder.Append("OrgTelphone=@OrgTelphone,");
            builder.Append("FamilyDoctor=@FamilyDoctor,");
            builder.Append("FamilyDoctorTel=@FamilyDoctorTel,");
            builder.Append("Nurses=@Nurses,");
            builder.Append("NursesTel=@NursesTel ,");
            builder.Append("HealthPersonnel=@HealthPersonnel, ");
            builder.Append("HealthPersonnelTel=@HealthPersonnelTel, ");
            builder.Append("Others=@Others ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String,21), 
                new MySqlParameter("@Prevalence", MySqlDbType.String,20), 
                new MySqlParameter("@PrevalenceOther", MySqlDbType.String), 
                new MySqlParameter("@OrgTelphone", MySqlDbType.String,100), 
                new MySqlParameter("@FamilyDoctor", MySqlDbType.String,100), 
                new MySqlParameter("@FamilyDoctorTel", MySqlDbType.String,100),
                new MySqlParameter("@Nurses", MySqlDbType.String,100),
                new MySqlParameter("@NursesTel",MySqlDbType.String,100),
                new MySqlParameter("@HealthPersonnel", MySqlDbType.String,100),
                new MySqlParameter("@HealthPersonnelTel", MySqlDbType.String,100),
                new MySqlParameter("@Others",MySqlDbType.String,500),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8),
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Prevalence;
            cmdParms[2].Value = model.PrevalenceOther;
            cmdParms[3].Value = model.OrgTelphone;
            cmdParms[4].Value = model.FamilyDoctor;
            cmdParms[5].Value = model.FamilyDoctorTel;
            cmdParms[6].Value = model.Nurses;
            cmdParms[7].Value = model.NursesTel;
            cmdParms[8].Value = model.HealthPersonnel;
            cmdParms[9].Value = model.HealthPersonnelTel;
            cmdParms[10].Value = model.Others;
            cmdParms[11].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
