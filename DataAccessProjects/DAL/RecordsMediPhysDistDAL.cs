namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsMediPhysDistDAL
    {
        public int Add(RecordsMediPhysDistModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsmediphysdist(");
            builder.Append("PhysicalID,IDCardNo,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QiConstraint,Characteristic,OutKey,MedicineID,MedicineResultID)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@Mild,@Faint,@Yang,@Yin,@PhlegmDamp,@Muggy,@BloodStasis,@QiConstraint,@Characteristic,@OutKey,@MedicineID,@MedicineResultID)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
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
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4),
                new MySqlParameter("@MedicineID", MySqlDbType.Int32, 4),
                new MySqlParameter("@MedicineResultID", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Mild;
            cmdParms[3].Value = model.Faint;
            cmdParms[4].Value = model.Yang;
            cmdParms[5].Value = model.Yin;
            cmdParms[6].Value = model.PhlegmDamp;
            cmdParms[7].Value = model.Muggy;
            cmdParms[8].Value = model.BloodStasis;
            cmdParms[9].Value = model.QiConstraint;
            cmdParms[10].Value = model.Characteristic;
            cmdParms[11].Value = model.OutKey;
            cmdParms[12].Value = model.MedicineID;
            cmdParms[13].Value = model.MedicineResultID;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsMediPhysDistModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsmediphysdist(");
            builder.Append("PhysicalID,IDCardNo,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QiConstraint,Characteristic,OutKey,MedicineID,MedicineResultID)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@Mild,@Faint,@Yang,@Yin,@PhlegmDamp,@Muggy,@BloodStasis,@QiConstraint,@Characteristic,@OutKey,@MedicineID,@MedicineResultID)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
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
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4),
                new MySqlParameter("@MedicineID", MySqlDbType.Int32, 4),
                new MySqlParameter("@MedicineResultID", MySqlDbType.Int32, 4)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Mild;
            cmdParms[3].Value = model.Faint;
            cmdParms[4].Value = model.Yang;
            cmdParms[5].Value = model.Yin;
            cmdParms[6].Value = model.PhlegmDamp;
            cmdParms[7].Value = model.Muggy;
            cmdParms[8].Value = model.BloodStasis;
            cmdParms[9].Value = model.QiConstraint;
            cmdParms[10].Value = model.Characteristic;
            cmdParms[11].Value = model.OutKey;
            cmdParms[12].Value = model.MedicineID;
            cmdParms[13].Value = model.MedicineResultID;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsMediPhysDistModel DataRowToModel(DataRow row)
        {
            RecordsMediPhysDistModel recordsMediPhysDistModel = new RecordsMediPhysDistModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsMediPhysDistModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Mild"] != null) && (row["Mild"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.Mild = row["Mild"].ToString();
                }
                if ((row["Faint"] != null) && (row["Faint"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.Faint = row["Faint"].ToString();
                }
                if ((row["Yang"] != null) && (row["Yang"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.Yang = row["Yang"].ToString();
                }
                if ((row["Yin"] != null) && (row["Yin"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.Yin = row["Yin"].ToString();
                }
                if ((row["PhlegmDamp"] != null) && (row["PhlegmDamp"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.PhlegmDamp = row["PhlegmDamp"].ToString();
                }
                if ((row["Muggy"] != null) && (row["Muggy"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.Muggy = row["Muggy"].ToString();
                }
                if ((row["BloodStasis"] != null) && (row["BloodStasis"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.BloodStasis = row["BloodStasis"].ToString();
                }
                if ((row["QiConstraint"] != null) && (row["QiConstraint"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.QiConstraint = row["QiConstraint"].ToString();
                }
                if ((row["Characteristic"] != null) && (row["Characteristic"] != DBNull.Value))
                {
                    recordsMediPhysDistModel.Characteristic = row["Characteristic"].ToString();
                }
                if (((row["MedicineID"] != null) && (row["MedicineID"] != DBNull.Value)) && (row["MedicineID"].ToString() != ""))
                {
                    recordsMediPhysDistModel.MedicineID = int.Parse(row["MedicineID"].ToString());
                }
                if (((row["MedicineResultID"] != null) && (row["MedicineResultID"] != DBNull.Value)) && (row["MedicineResultID"].ToString() != ""))
                {
                    recordsMediPhysDistModel.MedicineResultID = int.Parse(row["MedicineResultID"].ToString());
                }
            }
            return recordsMediPhysDistModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsmediphysdist ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsmediphysdist ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordsmediphysdist");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QiConstraint,Characteristic,,OutKey,MedicineID,MedicineResultID ");
            builder.Append(" FROM tbl_recordsmediphysdist ");
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
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from tbl_recordsmediphysdist T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_recordsmediphysdist");
        }

        public RecordsMediPhysDistModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QiConstraint,Characteristic,OutKey,MedicineID,MedicineResultID from tbl_recordsmediphysdist ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsMediPhysDistModel();
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
            builder.Append("select count(1) FROM tbl_recordsmediphysdist ");
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

        public bool Update(RecordsMediPhysDistModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsmediphysdist set ");
            builder.Append("PhysicalID=@PhysicalID,");
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
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
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
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Mild;
            cmdParms[3].Value = model.Faint;
            cmdParms[4].Value = model.Yang;
            cmdParms[5].Value = model.Yin;
            cmdParms[6].Value = model.PhlegmDamp;
            cmdParms[7].Value = model.Muggy;
            cmdParms[8].Value = model.BloodStasis;
            cmdParms[9].Value = model.QiConstraint;
            cmdParms[10].Value = model.Characteristic;
            cmdParms[11].Value = model.MedicineID;
            cmdParms[12].Value = model.MedicineResultID;
            cmdParms[13].Value = model.OutKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsMediPhysDistModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsmediphysdist set ");
            builder.Append("PhysicalID=@PhysicalID,");
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
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
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
                new MySqlParameter("@MedicineResultID", MySqlDbType.Int32, 4)
               // new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Mild;
            cmdParms[3].Value = model.Faint;
            cmdParms[4].Value = model.Yang;
            cmdParms[5].Value = model.Yin;
            cmdParms[6].Value = model.PhlegmDamp;
            cmdParms[7].Value = model.Muggy;
            cmdParms[8].Value = model.BloodStasis;
            cmdParms[9].Value = model.QiConstraint;
            cmdParms[10].Value = model.Characteristic;
            cmdParms[11].Value = model.MedicineID;
            cmdParms[12].Value = model.MedicineResultID;
            //cmdParms[11].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public RecordsMediPhysDistModel GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,Mild,Faint,Yang,Yin,PhlegmDamp,Muggy,BloodStasis,QiConstraint,Characteristic,OutKey,MedicineID,MedicineResultID from tbl_recordsmediphysdist ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;
            new RecordsMediPhysDistModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordsmediphysdist");
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

