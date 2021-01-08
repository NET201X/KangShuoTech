namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsMedicationDAL
    {
        public int Add(RecordsMedicationModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsmedication(");
            builder.Append("PhysicalID,IDCardNo,UseAge,UseNum,");
            builder.Append("StartTime,EndTime,PillDependence,MedicinalName,drugtype,factory,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@UseAge,@UseNum,@StartTime,@EndTime,@PillDependence,@MedicinalName,");
            builder.Append("@drugtype,@factory,@OutKey)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@UseAge", MySqlDbType.String, 500), 
                new MySqlParameter("@UseNum", MySqlDbType.String, 100),
                new MySqlParameter("@StartTime", MySqlDbType.String, 70),
                new MySqlParameter("@EndTime", MySqlDbType.String, 70), 
                new MySqlParameter("@PillDependence", MySqlDbType.String, 10), 
                new MySqlParameter("@MedicinalName", MySqlDbType.String, 100),
                new MySqlParameter("@drugtype", MySqlDbType.String, 100),
                new MySqlParameter("@factory", MySqlDbType.String, 100),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4),
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.UseAge;
            cmdParms[3].Value = model.UseNum;
            cmdParms[4].Value = model.StartTime;
            cmdParms[5].Value = model.EndTime;
            cmdParms[6].Value = model.PillDependence;
            cmdParms[7].Value = model.MedicinalName;
            cmdParms[8].Value = model.DrugType;
            cmdParms[9].Value = model.Factory;
            cmdParms[10].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsMedicationModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsmedication(");
            builder.Append("PhysicalID,IDCardNo,UseAge,UseNum,");
            builder.Append("StartTime,EndTime,PillDependence,MedicinalName,drugtype,factory,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@UseAge,@UseNum,@StartTime,@EndTime,@PillDependence,@MedicinalName,@OutKey");
            builder.Append("@drugtype,@factory)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@UseAge", MySqlDbType.String, 500), 
                new MySqlParameter("@UseNum", MySqlDbType.String, 100),
                new MySqlParameter("@StartTime", MySqlDbType.String, 70),
                new MySqlParameter("@EndTime", MySqlDbType.String, 70), 
                new MySqlParameter("@PillDependence", MySqlDbType.String, 10), 
                new MySqlParameter("@MedicinalName", MySqlDbType.String, 100),
                new MySqlParameter("@drugtype", MySqlDbType.String, 100),
                new MySqlParameter("@factory", MySqlDbType.String, 100),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4),
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.UseAge;
            cmdParms[3].Value = model.UseNum;
            cmdParms[4].Value = model.StartTime;
            cmdParms[5].Value = model.EndTime;
            cmdParms[6].Value = model.PillDependence;
            cmdParms[7].Value = model.MedicinalName;
            cmdParms[8].Value = model.DrugType;
            cmdParms[9].Value = model.Factory;
            cmdParms[10].Value = model.OutKey;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsMedicationModel DataRowToModel(DataRow row)
        {
            RecordsMedicationModel recordsMedicationModel = new RecordsMedicationModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsMedicationModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsMedicationModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsMedicationModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["UseAge"] != null) && (row["UseAge"] != DBNull.Value))
                {
                    recordsMedicationModel.UseAge = row["UseAge"].ToString();
                }
                if ((row["UseNum"] != null) && (row["UseNum"] != DBNull.Value))
                {
                    recordsMedicationModel.UseNum = row["UseNum"].ToString();
                }
                if ((row["StartTime"] != null) && (row["StartTime"] != DBNull.Value))
                {
                    recordsMedicationModel.StartTime = row["StartTime"].ToString();
                }
                if ((row["EndTime"] != null) && (row["EndTime"] != DBNull.Value))
                {
                    recordsMedicationModel.EndTime = row["EndTime"].ToString();
                }
                if ((row["PillDependence"] != null) && (row["PillDependence"] != DBNull.Value))
                {
                    recordsMedicationModel.PillDependence = row["PillDependence"].ToString();
                }
                if ((row["MedicinalName"] != null) && (row["MedicinalName"] != DBNull.Value))
                {
                    recordsMedicationModel.MedicinalName = row["MedicinalName"].ToString();
                }
                if ((row["drugtype"] != null) && (row["drugtype"] != DBNull.Value))
                {
                    recordsMedicationModel.DrugType = row["drugtype"].ToString();
                }
                if ((row["factory"] != null) && (row["factory"] != DBNull.Value))
                {
                    recordsMedicationModel.Factory = row["factory"].ToString();
                }
            }
            return recordsMedicationModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsmedication ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsmedication ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordsmedication");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,UseAge,UseNum,StartTime,EndTime,PillDependence,MedicinalName,");
            builder.Append("drugtype,factory ");
            builder.Append(" FROM tbl_recordsmedication ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere + " order by id limit 6");
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
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from tbl_recordsmedication T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_recordsmedication");
        }

        public RecordsMedicationModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,UseAge,UseNum,StartTime,EndTime,PillDependence,MedicinalName,");
            builder.Append("drugtype,factory from tbl_recordsmedication ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsMedicationModel();
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
            builder.Append("select count(1) FROM tbl_recordsmedication ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(RecordsMedicationModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsmedication set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("UseAge=@UseAge,");
            builder.Append("UseNum=@UseNum,");
            builder.Append("StartTime=@StartTime,");
            builder.Append("EndTime=@EndTime,");
            builder.Append("PillDependence=@PillDependence,");
            builder.Append("MedicinalName=@MedicinalName,");
            builder.Append("drugtype =@drugtype,");
            builder.Append("factory =@factory ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@UseAge", MySqlDbType.String, 500), 
                new MySqlParameter("@UseNum", MySqlDbType.String, 100),
                new MySqlParameter("@StartTime", MySqlDbType.String, 70),
                new MySqlParameter("@EndTime", MySqlDbType.String, 70), 
                new MySqlParameter("@PillDependence", MySqlDbType.String, 10), 
                new MySqlParameter("@MedicinalName", MySqlDbType.String, 100),
                new MySqlParameter("@drugtype", MySqlDbType.String, 100),
                new MySqlParameter("@factory", MySqlDbType.String, 100),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.UseAge;
            cmdParms[3].Value = model.UseNum;
            cmdParms[4].Value = model.StartTime;
            cmdParms[5].Value = model.EndTime;
            cmdParms[6].Value = model.PillDependence;
            cmdParms[7].Value = model.MedicinalName;
            cmdParms[8].Value = model.DrugType;
            cmdParms[9].Value = model.Factory;
            cmdParms[10].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsMedicationModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsmedication set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("UseAge=@UseAge,");
            builder.Append("UseNum=@UseNum,");
            builder.Append("StartTime=@StartTime,");
            builder.Append("EndTime=@EndTime,");
            builder.Append("PillDependence=@PillDependence,");
            builder.Append("MedicinalName=@MedicinalName,");
            builder.Append("drugtype =@drugtype,");
            builder.Append("factory =@factory ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@UseAge", MySqlDbType.String, 500), 
                new MySqlParameter("@UseNum", MySqlDbType.String, 100),
                new MySqlParameter("@StartTime", MySqlDbType.String, 70),
                new MySqlParameter("@EndTime", MySqlDbType.String, 70), 
                new MySqlParameter("@PillDependence", MySqlDbType.String, 10), 
                new MySqlParameter("@MedicinalName", MySqlDbType.String, 100),
                 new MySqlParameter("@drugtype", MySqlDbType.String, 100),
                new MySqlParameter("@factory", MySqlDbType.String, 100)
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.UseAge;
            cmdParms[3].Value = model.UseNum;
            cmdParms[4].Value = model.StartTime;
            cmdParms[5].Value = model.EndTime;
            cmdParms[6].Value = model.PillDependence;
            cmdParms[7].Value = model.MedicinalName;
            cmdParms[8].Value = model.DrugType;
            cmdParms[9].Value = model.Factory;
           // cmdParms[10].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool DeleteByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsmedication ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

