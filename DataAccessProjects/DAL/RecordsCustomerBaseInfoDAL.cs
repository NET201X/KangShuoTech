namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsCustomerBaseInfoDAL
    {
        public int Add(RecordsCustomerBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordscustomerbaseinfo(");
            builder.Append("CustomerID,IDCardNo,CheckDate,Doctor,Symptom,Other,PhysicalID,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDel)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@IDCardNo,@CheckDate,@Doctor,@Symptom,@Other,@PhysicalID,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate,@IsDel)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@CheckDate", MySqlDbType.Date),
                new MySqlParameter("@Doctor", MySqlDbType.String, 30),
                new MySqlParameter("@Symptom", MySqlDbType.String, 100), 
                new MySqlParameter("@Other", MySqlDbType.String, 200), 
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1) };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.CheckDate;
            cmdParms[3].Value = model.Doctor;
            cmdParms[4].Value = model.Symptom;
            cmdParms[5].Value = model.Other;
            cmdParms[6].Value = model.PhysicalID;
            cmdParms[7].Value = model.CreateBy;
            cmdParms[8].Value = model.CreateDate;
            cmdParms[9].Value = model.LastUpdateBy;
            cmdParms[10].Value = model.LastUpdateDate;
            cmdParms[11].Value = model.IsDel;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        
        public RecordsCustomerBaseInfoModel DataRowToModel(DataRow row)
        {
            RecordsCustomerBaseInfoModel recordsCustomerBaseInfoModel = new RecordsCustomerBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsCustomerBaseInfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    recordsCustomerBaseInfoModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsCustomerBaseInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["CheckDate"] != null) && (row["CheckDate"] != DBNull.Value)) && (row["CheckDate"].ToString() != ""))
                {
                    recordsCustomerBaseInfoModel.CheckDate = new DateTime?(DateTime.Parse(row["CheckDate"].ToString()));
                }
                if ((row["Doctor"] != null) && (row["Doctor"] != DBNull.Value))
                {
                    recordsCustomerBaseInfoModel.Doctor = row["Doctor"].ToString();
                }
                if ((row["Symptom"] != null) && (row["Symptom"] != DBNull.Value))
                {
                    recordsCustomerBaseInfoModel.Symptom = row["Symptom"].ToString();
                }
                if ((row["Other"] != null) && (row["Other"] != DBNull.Value))
                {
                    recordsCustomerBaseInfoModel.Other = row["Other"].ToString();
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsCustomerBaseInfoModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if (((row["CreateBy"] != null) && (row["CreateBy"] != DBNull.Value)) && (row["CreateBy"].ToString() != ""))
                {
                    recordsCustomerBaseInfoModel.CreateBy = new decimal?(decimal.Parse(row["CreateBy"].ToString()));
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    recordsCustomerBaseInfoModel.CreateDate = new DateTime?(DateTime.Parse(row["CreateDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    recordsCustomerBaseInfoModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    recordsCustomerBaseInfoModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    recordsCustomerBaseInfoModel.IsDel = row["IsDel"].ToString();
                }
            }
            return recordsCustomerBaseInfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordscustomerbaseinfo ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,IDCardNo,CheckDate,Doctor,Symptom,Other,PhysicalID,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDel ");
            builder.Append(" FROM tbl_recordscustomerbaseinfo ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public RecordsCustomerBaseInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,IDCardNo,CheckDate,Doctor,Symptom,Other,PhysicalID,CreateBy,CreateDate,LastUpdateBy,");
            builder.Append("LastUpdateDate,IsDel from tbl_recordscustomerbaseinfo ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsCustomerBaseInfoModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public bool Update(RecordsCustomerBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordscustomerbaseinfo set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("CheckDate=@CheckDate,");
            builder.Append("Doctor=@Doctor,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("Other=@Other,");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@CheckDate", MySqlDbType.Date), 
                new MySqlParameter("@Doctor", MySqlDbType.String, 30), 
                new MySqlParameter("@Symptom", MySqlDbType.String, 100), 
                new MySqlParameter("@Other", MySqlDbType.String, 200), 
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.CheckDate;
            cmdParms[3].Value = model.Doctor;
            cmdParms[4].Value = model.Symptom;
            cmdParms[5].Value = model.Other;
            cmdParms[6].Value = model.PhysicalID;
            cmdParms[7].Value = model.CreateBy;
            cmdParms[8].Value = model.CreateDate;
            cmdParms[9].Value = model.LastUpdateBy;
            cmdParms[10].Value = model.LastUpdateDate;
            cmdParms[11].Value = model.IsDel;
            cmdParms[12].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        
        public int GetCustomerRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT COUNT(1)");
            builder.Append(" from tbl_recordscustomerbaseinfo  B left join tbl_recordsbaseinfo T on T.IDCardNo = B.IDCardNo   ");
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

        public DataSet GetCustomerListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select B.ID,T.IDCardNo,T.Nation,T.CustomerName,T.Sex,T.Birthday,T.Phone,T.HouseHoldAddress,T.Minority,B.CheckDate,");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate, ");
            builder.Append("(case T.LastUpdateDate when null then null when '' then null else T.LastUpdateDate end ) as LastUpdateDate, ");
            builder.Append("T.PopulationType,T.CreateMenName, B.CheckDate ");
            builder.Append(" from tbl_recordscustomerbaseinfo B left join tbl_recordsbaseinfo T on T.IDCardNo = B.IDCardNo");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by B." + orderby);
            }
            else
            {
                builder.Append(" order by B.ID desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }

        public RecordsCustomerBaseInfoModel GetMaxModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,IDCardNo,CheckDate,Doctor,Symptom,Other,PhysicalID,CreateBy,CreateDate,LastUpdateBy,");
            builder.Append("LastUpdateDate,IsDel from tbl_recordscustomerbaseinfo ");
            builder.Append(" where IDCardNo=@IDCardNo");
            builder.Append(" order by CheckDate DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsCustomerBaseInfoModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public RecordsCustomerBaseInfoModel GetModelByID(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,IDCardNo,CheckDate,Doctor,Symptom,Other,PhysicalID,CreateBy,CreateDate,LastUpdateBy,");
            builder.Append("LastUpdateDate,IsDel from tbl_recordscustomerbaseinfo ");
            builder.Append(" where ID=@ID");


            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.String) };
            cmdParms[0].Value = ID;
            new RecordsCustomerBaseInfoModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public RecordsCustomerBaseInfoModel GetModelByWhere(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,IDCardNo,CheckDate,Doctor,Symptom,Other,PhysicalID,CreateBy,CreateDate,LastUpdateBy,");
            builder.Append("LastUpdateDate,IsDel from tbl_recordscustomerbaseinfo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 and " + strWhere);
            }
            new RecordsCustomerBaseInfoModel();
            DataSet set = MySQLHelper.Query(builder.ToString());
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public DataSet GetTownList()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  DISTINCT(TownName) from tbl_recordsbaseinfo");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetVillageList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  DISTINCT(VillageName) from tbl_recordsbaseinfo");
            builder.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append( strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 同步时取得年度的最后一次体检资料
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public DataSet GetModelByCheckDate(string IDCardNo, string checkDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT ID,CheckDate ");
            builder.Append(" FROM tbl_recordscustomerbaseinfo ");
            builder.Append(" WHERE ID=(SELECT ID FROM tbl_recordscustomerbaseinfo ");
            builder.Append("    WHERE IDCardNo=@IDCardNo AND LEFT(CheckDate,4)=@CheckDate ORDER BY CheckDate DESC LIMIT 0,1) ");

            if (Convert.ToString(checkDate).Length > 3) checkDate = checkDate.Substring(0, 4);

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", IDCardNo),
                new MySqlParameter("@CheckDate", checkDate)
            };

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }
    }
}