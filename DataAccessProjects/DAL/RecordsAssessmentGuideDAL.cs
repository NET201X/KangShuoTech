namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsAssessmentGuideDAL
    {
        public int Add(RecordsAssessmentGuideModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsassessmentguide(");
            builder.Append("PhysicalID,IDCardNo,IsNormal,HealthGuide,DangerControl,Exception1,Exception2,Exception3,Arm,VaccineAdvice,Other,Exception4,OutKey,WaistlineArm,Exception5,Exception6)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@IsNormal,@HealthGuide,@DangerControl,@Exception1,@Exception2,@Exception3,@Arm,@VaccineAdvice,@Other,@Exception4,@OutKey,@WaistlineArm,@Exception5,@Exception6)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IsNormal", MySqlDbType.String, 1),
                new MySqlParameter("@HealthGuide", MySqlDbType.String, 20),
                new MySqlParameter("@DangerControl", MySqlDbType.String, 30),
                new MySqlParameter("@Exception1", MySqlDbType.String, 500),
                new MySqlParameter("@Exception2", MySqlDbType.String, 500),
                new MySqlParameter("@Exception3", MySqlDbType.String, 500),
                new MySqlParameter("@Arm", MySqlDbType.String, 500),
                new MySqlParameter("@VaccineAdvice", MySqlDbType.String, 500),
                new MySqlParameter("@Other", MySqlDbType.String, 500),
                new MySqlParameter("@Exception4", MySqlDbType.String, 500),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4),
                new MySqlParameter("@WaistlineArm",MySqlDbType.String,100),
                new MySqlParameter("@Exception5", MySqlDbType.String, 500),
                new MySqlParameter("@Exception6", MySqlDbType.String, 500)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.IsNormal;
            cmdParms[3].Value = model.HealthGuide;
            cmdParms[4].Value = model.DangerControl;
            cmdParms[5].Value = model.Exception1;
            cmdParms[6].Value = model.Exception2;
            cmdParms[7].Value = model.Exception3;
            cmdParms[8].Value = model.Arm;
            cmdParms[9].Value = model.VaccineAdvice;
            cmdParms[10].Value = model.Other;
            cmdParms[11].Value = model.Exception4;
            cmdParms[12].Value = model.OutKey;
            cmdParms[13].Value = model.WaistlineArm;
            cmdParms[14].Value = model.Exception5;
            cmdParms[15].Value = model.Exception6;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsAssessmentGuideModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsassessmentguide(");
            builder.Append("PhysicalID,IDCardNo,IsNormal,HealthGuide,DangerControl,Exception1,Exception2,Exception3,Arm,VaccineAdvice,Other,Exception4,OutKey)");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@IsNormal,@HealthGuide,@DangerControl,@Exception1,@Exception2,@Exception3,@Arm,@VaccineAdvice,@Other,@Exception4,@OutKey)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IsNormal", MySqlDbType.String, 1),
                new MySqlParameter("@HealthGuide", MySqlDbType.String, 20),
                new MySqlParameter("@DangerControl", MySqlDbType.String, 30),
                new MySqlParameter("@Exception1", MySqlDbType.String, 500),
                new MySqlParameter("@Exception2", MySqlDbType.String, 500),
                new MySqlParameter("@Exception3", MySqlDbType.String, 500),
                new MySqlParameter("@Arm", MySqlDbType.String, 500),
                new MySqlParameter("@VaccineAdvice", MySqlDbType.String, 500),
                new MySqlParameter("@Other", MySqlDbType.String, 500),
                new MySqlParameter("@Exception4", MySqlDbType.String, 500),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.IsNormal;
            cmdParms[3].Value = model.HealthGuide;
            cmdParms[4].Value = model.DangerControl;
            cmdParms[5].Value = model.Exception1;
            cmdParms[6].Value = model.Exception2;
            cmdParms[7].Value = model.Exception3;
            cmdParms[8].Value = model.Arm;
            cmdParms[9].Value = model.VaccineAdvice;
            cmdParms[10].Value = model.Other;
            cmdParms[11].Value = model.Exception4;
            cmdParms[12].Value = model.OutKey;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsAssessmentGuideModel DataRowToModel(DataRow row)
        {
            RecordsAssessmentGuideModel recordsAssessmentGuideModel = new RecordsAssessmentGuideModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsAssessmentGuideModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["IsNormal"] != null) && (row["IsNormal"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.IsNormal = row["IsNormal"].ToString();
                }
                if ((row["HealthGuide"] != null) && (row["HealthGuide"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.HealthGuide = row["HealthGuide"].ToString();
                }
                if ((row["DangerControl"] != null) && (row["DangerControl"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.DangerControl = row["DangerControl"].ToString();
                }
                if ((row["Exception1"] != null) && (row["Exception1"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.Exception1 = row["Exception1"].ToString();
                }
                if ((row["Exception2"] != null) && (row["Exception2"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.Exception2 = row["Exception2"].ToString();
                }
                if ((row["Exception3"] != null) && (row["Exception3"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.Exception3 = row["Exception3"].ToString();
                }
                if ((row["Arm"] != null) && (row["Arm"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.Arm = row["Arm"].ToString();
                }
                if ((row["VaccineAdvice"] != null) && (row["VaccineAdvice"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.VaccineAdvice = row["VaccineAdvice"].ToString();
                }
                if ((row["Other"] != null) && (row["Other"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.Other = row["Other"].ToString();
                }
                if ((row["Exception4"] != null) && (row["Exception4"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.Exception4 = row["Exception4"].ToString();
                }
                if ((row["WaistlineArm"] != null) && (row["WaistlineArm"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.WaistlineArm = row["WaistlineArm"].ToString();
                }
                if ((row["Exception5"] != null) && (row["Exception5"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.Exception5 = row["Exception5"].ToString();
                }
                if ((row["Exception6"] != null) && (row["Exception6"] != DBNull.Value))
                {
                    recordsAssessmentGuideModel.Exception6 = row["Exception6"].ToString();
                }
            }
            return recordsAssessmentGuideModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsassessmentguide ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsassessmentguide ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordsassessmentguide");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM tbl_recordsassessmentguide ");
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
            builder.Append(")AS Row, T.*  from tbl_recordsassessmentguide T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_recordsassessmentguide");
        }

        public RecordsAssessmentGuideModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from tbl_recordsassessmentguide ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsAssessmentGuideModel();
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
            builder.Append("select count(1) FROM tbl_recordsassessmentguide ");
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

        public bool Update(RecordsAssessmentGuideModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsassessmentguide set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("IsNormal=@IsNormal,");
            builder.Append("HealthGuide=@HealthGuide,");
            builder.Append("DangerControl=@DangerControl,");
            builder.Append("Exception1=@Exception1,");
            builder.Append("Exception2=@Exception2,");
            builder.Append("Exception3=@Exception3,");
            builder.Append("Arm=@Arm,");
            builder.Append("VaccineAdvice=@VaccineAdvice,");
            builder.Append("Other=@Other,");
            builder.Append("Exception4=@Exception4,");
            builder.Append("WaistlineArm=@WaistlineArm, ");
            builder.Append("Exception5=@Exception5,");
            builder.Append("Exception6=@Exception6 ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IsNormal", MySqlDbType.String, 1),
                new MySqlParameter("@HealthGuide", MySqlDbType.String, 20),
                new MySqlParameter("@DangerControl", MySqlDbType.String, 30),
                new MySqlParameter("@Exception1", MySqlDbType.String, 500),
                new MySqlParameter("@Exception2", MySqlDbType.String, 500),
                new MySqlParameter("@Exception3", MySqlDbType.String, 500),
                new MySqlParameter("@Arm", MySqlDbType.String, 500),
                new MySqlParameter("@VaccineAdvice", MySqlDbType.String, 500),
                new MySqlParameter("@Other", MySqlDbType.String, 500),
                new MySqlParameter("@Exception4", MySqlDbType.String, 500),
                new MySqlParameter("@WaistlineArm",MySqlDbType.String,100),
                new MySqlParameter("@Exception5", MySqlDbType.String, 500),
                new MySqlParameter("@Exception6", MySqlDbType.String, 500),
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.IsNormal;
            cmdParms[3].Value = model.HealthGuide;
            cmdParms[4].Value = model.DangerControl;
            cmdParms[5].Value = model.Exception1;
            cmdParms[6].Value = model.Exception2;
            cmdParms[7].Value = model.Exception3;
            cmdParms[8].Value = model.Arm;
            cmdParms[9].Value = model.VaccineAdvice;
            cmdParms[10].Value = model.Other;
            cmdParms[11].Value = model.Exception4;
            cmdParms[12].Value = model.WaistlineArm;
            cmdParms[13].Value = model.Exception5;
            cmdParms[14].Value = model.Exception6;
            cmdParms[15].Value = model.OutKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsAssessmentGuideModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsassessmentguide set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("IsNormal=@IsNormal,");
            builder.Append("HealthGuide=@HealthGuide,");
            builder.Append("DangerControl=@DangerControl,");
            builder.Append("Exception1=@Exception1,");
            builder.Append("Exception2=@Exception2,");
            builder.Append("Exception3=@Exception3,");
            builder.Append("Arm=@Arm,");
            builder.Append("VaccineAdvice=@VaccineAdvice,");
            builder.Append("Other=@Other,");
            builder.Append("Exception4=@Exception4");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IsNormal", MySqlDbType.String, 1),
                new MySqlParameter("@HealthGuide", MySqlDbType.String, 20),
                new MySqlParameter("@DangerControl", MySqlDbType.String, 30),
                new MySqlParameter("@Exception1", MySqlDbType.String, 500),
                new MySqlParameter("@Exception2", MySqlDbType.String, 500),
                new MySqlParameter("@Exception3", MySqlDbType.String, 500),
                new MySqlParameter("@Arm", MySqlDbType.String, 500),
                new MySqlParameter("@VaccineAdvice", MySqlDbType.String, 500),
                new MySqlParameter("@Other", MySqlDbType.String, 500),
                new MySqlParameter("@Exception4", MySqlDbType.String, 500), 
               // new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.IsNormal;
            cmdParms[3].Value = model.HealthGuide;
            cmdParms[4].Value = model.DangerControl;
            cmdParms[5].Value = model.Exception1;
            cmdParms[6].Value = model.Exception2;
            cmdParms[7].Value = model.Exception3;
            cmdParms[8].Value = model.Arm;
            cmdParms[9].Value = model.VaccineAdvice;
            cmdParms[10].Value = model.Other;
            cmdParms[11].Value = model.Exception4;
            // cmdParms[12].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public RecordsAssessmentGuideModel GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from tbl_recordsassessmentguide ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;
            new RecordsAssessmentGuideModel();
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
            builder.Append("select count(1) from tbl_recordsassessmentguide");
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

