using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.Model;
using System.Data;
using MySql.Data.MySqlClient;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    public class HealthHouseMediPhyDAL
    {
        public int Add(HealthHouseMediPhyModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_hhmediphysdist(");
            builder.Append("IDCardNo,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QiConstraint,Characteristic,PID,MedicineID,MedicineResultID)");
            builder.Append(" values (");
            builder.Append("@IDCardNo,@Mild,@Faint,@Yang,@Yin,@PhlegmDamp,@Muggy,@BloodStasis,@QiConstraint,@Characteristic,@PID,@MedicineID,@MedicineResultID)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Mild", MySqlDbType.String, 1), 
                new MySqlParameter("@Faint", MySqlDbType.String, 1), 
                new MySqlParameter("@Yang", MySqlDbType.String, 1), 
                new MySqlParameter("@Yin", MySqlDbType.String, 1), 
                new MySqlParameter("@PhlegmDamp", MySqlDbType.String, 1), 
                new MySqlParameter("@Muggy", MySqlDbType.String, 1), 
                new MySqlParameter("@BloodStasis", MySqlDbType.String, 1), 
                new MySqlParameter("@QiConstraint", MySqlDbType.String, 1), 
                new MySqlParameter("@Characteristic", MySqlDbType.String, 1),
                new MySqlParameter("@PID", MySqlDbType.Int32, 4),
                new MySqlParameter("@MedicineID", MySqlDbType.Int32, 4),
                new MySqlParameter("@MedicineResultID", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Mild;
            cmdParms[2].Value = model.Faint;
            cmdParms[3].Value = model.Yang;
            cmdParms[4].Value = model.Yin;
            cmdParms[5].Value = model.PhlegmDamp;
            cmdParms[6].Value = model.Muggy;
            cmdParms[7].Value = model.BloodStasis;
            cmdParms[8].Value = model.QiConstraint;
            cmdParms[9].Value = model.Characteristic;
            cmdParms[10].Value = model.PID;
            cmdParms[11].Value = model.MedicineID;
            cmdParms[12].Value = model.MedicineResultID;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public HealthHouseMediPhyModel GetModel(int PID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  from tbl_hhmediphysdist ");
            builder.Append(" where PID=@PID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@PID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = PID;
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public HealthHouseMediPhyModel DataRowToModel(DataRow row)
        {
            HealthHouseMediPhyModel HHMediPhysDistModel = new HealthHouseMediPhyModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    HHMediPhysDistModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    HHMediPhysDistModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Mild"] != null) && (row["Mild"] != DBNull.Value))
                {
                    HHMediPhysDistModel.Mild = row["Mild"].ToString();
                }
                if ((row["Faint"] != null) && (row["Faint"] != DBNull.Value))
                {
                    HHMediPhysDistModel.Faint = row["Faint"].ToString();
                }
                if ((row["Yang"] != null) && (row["Yang"] != DBNull.Value))
                {
                    HHMediPhysDistModel.Yang = row["Yang"].ToString();
                }
                if ((row["Yin"] != null) && (row["Yin"] != DBNull.Value))
                {
                    HHMediPhysDistModel.Yin = row["Yin"].ToString();
                }
                if ((row["PhlegmDamp"] != null) && (row["PhlegmDamp"] != DBNull.Value))
                {
                    HHMediPhysDistModel.PhlegmDamp = row["PhlegmDamp"].ToString();
                }
                if ((row["Muggy"] != null) && (row["Muggy"] != DBNull.Value))
                {
                    HHMediPhysDistModel.Muggy = row["Muggy"].ToString();
                }
                if ((row["BloodStasis"] != null) && (row["BloodStasis"] != DBNull.Value))
                {
                    HHMediPhysDistModel.BloodStasis = row["BloodStasis"].ToString();
                }
                if ((row["QiConstraint"] != null) && (row["QiConstraint"] != DBNull.Value))
                {
                    HHMediPhysDistModel.QiConstraint = row["QiConstraint"].ToString();
                }
                if ((row["Characteristic"] != null) && (row["Characteristic"] != DBNull.Value))
                {
                    HHMediPhysDistModel.Characteristic = row["Characteristic"].ToString();
                }
                if (((row["MedicineID"] != null) && (row["MedicineID"] != DBNull.Value)) && (row["MedicineID"].ToString() != ""))
                {
                    HHMediPhysDistModel.MedicineID = int.Parse(row["MedicineID"].ToString());
                }
                if (((row["MedicineResultID"] != null) && (row["MedicineResultID"] != DBNull.Value)) && (row["MedicineResultID"].ToString() != ""))
                {
                    HHMediPhysDistModel.MedicineResultID = int.Parse(row["MedicineResultID"].ToString());
                }
            }
            return HHMediPhysDistModel;
        }
        public bool Update(HealthHouseMediPhyModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_hhmediphysdist set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Mild=@Mild,");
            builder.Append("Faint=@Faint,");
            builder.Append("Yang=@Yang,");
            builder.Append("Yin=@Yin,");
            builder.Append("PhlegmDamp=@PhlegmDamp,");
            builder.Append("Muggy=@Muggy,");
            builder.Append("BloodStasis=@BloodStasis,");
            builder.Append("QiConstraint=@QiConstraint,");
            builder.Append("Characteristic=@Characteristic,");
            builder.Append("MedicineID=@MedicineID,");
            builder.Append("MedicineResultID=@MedicineResultID ");
            builder.Append(" where PID=@PID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Mild", MySqlDbType.String, 1), 
                new MySqlParameter("@Faint", MySqlDbType.String, 1), 
                new MySqlParameter("@Yang", MySqlDbType.String, 1), 
                new MySqlParameter("@Yin", MySqlDbType.String, 1), 
                new MySqlParameter("@PhlegmDamp", MySqlDbType.String, 1), 
                new MySqlParameter("@Muggy", MySqlDbType.String, 1), 
                new MySqlParameter("@BloodStasis", MySqlDbType.String, 1), 
                new MySqlParameter("@QiConstraint", MySqlDbType.String, 1), 
                new MySqlParameter("@Characteristic", MySqlDbType.String, 1),
                new MySqlParameter("@MedicineID", MySqlDbType.Int32, 4),
                new MySqlParameter("@MedicineResultID", MySqlDbType.Int32, 4),
                new MySqlParameter("@PID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Mild;
            cmdParms[2].Value = model.Faint;
            cmdParms[3].Value = model.Yang;
            cmdParms[4].Value = model.Yin;
            cmdParms[5].Value = model.PhlegmDamp;
            cmdParms[6].Value = model.Muggy;
            cmdParms[7].Value = model.BloodStasis;
            cmdParms[8].Value = model.QiConstraint;
            cmdParms[9].Value = model.Characteristic;
            cmdParms[10].Value = model.MedicineID;
            cmdParms[11].Value = model.MedicineResultID;
            cmdParms[12].Value = model.PID;    
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
