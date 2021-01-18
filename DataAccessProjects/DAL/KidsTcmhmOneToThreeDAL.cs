namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class KidsTcmhmOneToThreeDAL
    {
        public int Add(KidsTcmhmOneToThreeModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CHILD_TCMHM_ONE2THREE(");
            builder.Append("CustomerID,RecordID,FollowupType,FollowupDate,NextFollowUpDate,Tcmhm,TcmhmOther,FollowUpDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@FollowupType,@FollowupDate,@NextFollowUpDate,@Tcmhm,@TcmhmOther,@FollowUpDoctor,@IsDel,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IDCardNo)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@FollowupType", MySqlDbType.String, 1),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10),
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 50),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
            };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.FollowupType;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.NextFollowupDate;
            cmdParms[5].Value = model.Tcmhm;
            cmdParms[6].Value = model.TcmhmOther;
            cmdParms[7].Value = model.FollowUpDoctor;
            cmdParms[8].Value = model.IsDel;
            cmdParms[9].Value = model.CreatedBy;
            cmdParms[10].Value = model.CreatedDate;
            cmdParms[11].Value = model.LastUpdateBy;
            cmdParms[12].Value = model.LastUpdateDate;
            cmdParms[13].Value = model.IDCardNo;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(KidsTcmhmOneToThreeModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CHILD_TCMHM_ONE2THREE(");
            builder.Append("CustomerID,RecordID,FollowupType,FollowupDate,NextFollowUpDate,Tcmhm,TcmhmOther,FollowUpDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@FollowupType,@FollowupDate,@NextFollowUpDate,@Tcmhm,@TcmhmOther,@FollowUpDoctor,@IsDel,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IDCardNo)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@FollowupType", MySqlDbType.String, 1),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date), 
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10),
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 50),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
            };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.FollowupType;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.NextFollowupDate;
            cmdParms[5].Value = model.Tcmhm;
            cmdParms[6].Value = model.TcmhmOther;
            cmdParms[7].Value = model.FollowUpDoctor;
            cmdParms[8].Value = model.IsDel;
            cmdParms[9].Value = model.CreatedBy;
            cmdParms[10].Value = model.CreatedDate;
            cmdParms[11].Value = model.LastUpdateBy;
            cmdParms[12].Value = model.LastUpdateDate;
            cmdParms[13].Value = model.IDCardNo;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public KidsTcmhmOneToThreeModel DataRowToModel(DataRow row)
        {
            KidsTcmhmOneToThreeModel kidsTcmhmOneToThreeModel = new KidsTcmhmOneToThreeModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    kidsTcmhmOneToThreeModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    kidsTcmhmOneToThreeModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    kidsTcmhmOneToThreeModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["FollowupType"] != null) && (row["FollowupType"] != DBNull.Value))
                {
                    kidsTcmhmOneToThreeModel.FollowupType = row["FollowupType"].ToString();
                }
                if (((row["FollowupDate"] != null) && (row["FollowupDate"] != DBNull.Value)) && (row["FollowupDate"].ToString() != ""))
                {
                    kidsTcmhmOneToThreeModel.FollowupDate = new DateTime?(DateTime.Parse(row["FollowupDate"].ToString()));
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    kidsTcmhmOneToThreeModel.NextFollowupDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["Tcmhm"] != null) && (row["Tcmhm"] != DBNull.Value))
                {
                    kidsTcmhmOneToThreeModel.Tcmhm = row["Tcmhm"].ToString();
                }
                if ((row["TcmhmOther"] != null) && (row["TcmhmOther"] != DBNull.Value))
                {
                    kidsTcmhmOneToThreeModel.TcmhmOther = row["TcmhmOther"].ToString();
                }
                if ((row["FollowUpDoctor"] != null) && (row["FollowUpDoctor"] != DBNull.Value))
                {
                    kidsTcmhmOneToThreeModel.FollowUpDoctor = row["FollowUpDoctor"].ToString();
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    kidsTcmhmOneToThreeModel.IsDel = row["IsDel"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    kidsTcmhmOneToThreeModel.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    kidsTcmhmOneToThreeModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    kidsTcmhmOneToThreeModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    kidsTcmhmOneToThreeModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    kidsTcmhmOneToThreeModel.IDCardNo = row["IDCardNo"].ToString();
                }
                kidsTcmhmOneToThreeModel.ModelState = RecordsStateModel.Unchanged;
            }
            return kidsTcmhmOneToThreeModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CHILD_TCMHM_ONE2THREE ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CHILD_TCMHM_ONE2THREE ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CHILD_TCMHM_ONE2THREE");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,FollowupType,FollowupDate,NextFollowUpDate,Tcmhm,TcmhmOther,FollowUpDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo ");
            builder.Append(" FROM CHILD_TCMHM_ONE2THREE ");
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
            builder.Append(")AS Row, T.*  from CHILD_TCMHM_ONE2THREE T ");
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
            return MySQLHelper.GetMaxID("ID", "CHILD_TCMHM_ONE2THREE");
        }

        public KidsTcmhmOneToThreeModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,FollowupType,FollowupDate,NextFollowUpDate,Tcmhm,TcmhmOther,FollowUpDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo from CHILD_TCMHM_ONE2THREE ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new KidsTcmhmOneToThreeModel();
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
            builder.Append("select count(1) FROM CHILD_TCMHM_ONE2THREE ");
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

        public bool Update(KidsTcmhmOneToThreeModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CHILD_TCMHM_ONE2THREE set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("FollowupType=@FollowupType,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("Tcmhm=@Tcmhm,");
            builder.Append("TcmhmOther=@TcmhmOther,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IDCardNo=@IDCardNo");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@FollowupType", MySqlDbType.String, 1), 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10),
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 50), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.FollowupType;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.NextFollowupDate;
            cmdParms[5].Value = model.Tcmhm;
            cmdParms[6].Value = model.TcmhmOther;
            cmdParms[7].Value = model.FollowUpDoctor;
            cmdParms[8].Value = model.IsDel;
            cmdParms[9].Value = model.CreatedBy;
            cmdParms[10].Value = model.CreatedDate;
            cmdParms[11].Value = model.LastUpdateBy;
            cmdParms[12].Value = model.LastUpdateDate;
            cmdParms[13].Value = model.IDCardNo;
            cmdParms[14].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(KidsTcmhmOneToThreeModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CHILD_TCMHM_ONE2THREE set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("FollowupType=@FollowupType,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
            builder.Append("Tcmhm=@Tcmhm,");
            builder.Append("TcmhmOther=@TcmhmOther,");
            builder.Append("FollowUpDoctor=@FollowUpDoctor,");
            builder.Append("IsDel=@IsDel,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IDCardNo=@IDCardNo");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@FollowupType", MySqlDbType.String, 1), 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10),
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255), 
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 50), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.FollowupType;
            cmdParms[3].Value = model.FollowupDate;
            cmdParms[4].Value = model.NextFollowupDate;
            cmdParms[5].Value = model.Tcmhm;
            cmdParms[6].Value = model.TcmhmOther;
            cmdParms[7].Value = model.FollowUpDoctor;
            cmdParms[8].Value = model.IsDel;
            cmdParms[9].Value = model.CreatedBy;
            cmdParms[10].Value = model.CreatedDate;
            cmdParms[11].Value = model.LastUpdateBy;
            cmdParms[12].Value = model.LastUpdateDate;
            cmdParms[13].Value = model.IDCardNo;
            //cmdParms[14].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

