namespace KangShuoTech.DataAccessProjects.DAL
{
    using Utilities.MySQLHelper;
    using Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class KidsTcmhmOneDAL
    {
        public int Add(KidsTcmhmOneModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_kidstcmhmone(");
            builder.Append("CustomerID,RecordID,FollowupType,FollowupDate,Tcmhm,TcmhmOther,NextFollowDate,FollowDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@FollowupType,@FollowupDate,@Tcmhm,@TcmhmOther,@NextFollowDate,@FollowDoctor,@IsDel,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IDCardNo)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@FollowupType", MySqlDbType.String, 1), 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10), 
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255),
                new MySqlParameter("@NextFollowDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowDoctor", MySqlDbType.String, 50),
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
            cmdParms[4].Value = model.Tcmhm;
            cmdParms[5].Value = model.TcmhmOther;
            cmdParms[6].Value = model.NextFollowDate;
            cmdParms[7].Value = model.FollowDoctor;
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

        public int AddServer(KidsTcmhmOneModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_kidstcmhmone(");
            builder.Append("CustomerID,RecordID,FollowupType,FollowupDate,Tcmhm,TcmhmOther,NextFollowDate,FollowDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@FollowupType,@FollowupDate,@Tcmhm,@TcmhmOther,@NextFollowDate,@FollowDoctor,@IsDel,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IDCardNo)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@FollowupType", MySqlDbType.String, 1), 
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10), 
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255),
                new MySqlParameter("@NextFollowDate", MySqlDbType.Date), 
                new MySqlParameter("@FollowDoctor", MySqlDbType.String, 50),
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
            cmdParms[4].Value = model.Tcmhm;
            cmdParms[5].Value = model.TcmhmOther;
            cmdParms[6].Value = model.NextFollowDate;
            cmdParms[7].Value = model.FollowDoctor;
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

        public KidsTcmhmOneModel DataRowToModel(DataRow row)
        {
            KidsTcmhmOneModel kidsTcmhmOneModel = new KidsTcmhmOneModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    kidsTcmhmOneModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    kidsTcmhmOneModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    kidsTcmhmOneModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["FollowupType"] != null) && (row["FollowupType"] != DBNull.Value))
                {
                    kidsTcmhmOneModel.FollowupType = row["FollowupType"].ToString();
                }
                if (((row["FollowupDate"] != null) && (row["FollowupDate"] != DBNull.Value)) && (row["FollowupDate"].ToString() != ""))
                {
                    kidsTcmhmOneModel.FollowupDate = new DateTime?(DateTime.Parse(row["FollowupDate"].ToString()));
                }
                if ((row["Tcmhm"] != null) && (row["Tcmhm"] != DBNull.Value))
                {
                    kidsTcmhmOneModel.Tcmhm = row["Tcmhm"].ToString();
                }
                if ((row["TcmhmOther"] != null) && (row["TcmhmOther"] != DBNull.Value))
                {
                    kidsTcmhmOneModel.TcmhmOther = row["TcmhmOther"].ToString();
                }
                if (((row["NextFollowDate"] != null) && (row["NextFollowDate"] != DBNull.Value)) && (row["NextFollowDate"].ToString() != ""))
                {
                    kidsTcmhmOneModel.NextFollowDate = new DateTime?(DateTime.Parse(row["NextFollowDate"].ToString()));
                }
                if ((row["FollowDoctor"] != null) && (row["FollowDoctor"] != DBNull.Value))
                {
                    kidsTcmhmOneModel.FollowDoctor = row["FollowDoctor"].ToString();
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    kidsTcmhmOneModel.IsDel = row["IsDel"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    kidsTcmhmOneModel.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    kidsTcmhmOneModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    kidsTcmhmOneModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    kidsTcmhmOneModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    kidsTcmhmOneModel.IDCardNo = row["IDCardNo"].ToString();
                }

                kidsTcmhmOneModel.ModelState = RecordsStateModel.Unchanged;
            }
            return kidsTcmhmOneModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_kidstcmhmone ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_kidstcmhmone ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_kidstcmhmone");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,FollowupType,FollowupDate,Tcmhm,TcmhmOther,NextFollowDate,FollowDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo ");
            builder.Append(" FROM tbl_kidstcmhmone ");
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
            builder.Append(")AS Row, T.*  from tbl_kidstcmhmone T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_kidstcmhmone");
        }

        public KidsTcmhmOneModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,FollowupType,FollowupDate,Tcmhm,TcmhmOther,NextFollowDate,FollowDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo from tbl_kidstcmhmone ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new KidsTcmhmOneModel();
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
            builder.Append("select count(1) FROM tbl_kidstcmhmone ");
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

        public bool Update(KidsTcmhmOneModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_kidstcmhmone set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("FollowupType=@FollowupType,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("Tcmhm=@Tcmhm,");
            builder.Append("TcmhmOther=@TcmhmOther,");
            builder.Append("NextFollowDate=@NextFollowDate,");
            builder.Append("FollowDoctor=@FollowDoctor,");
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
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10), 
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255),
                new MySqlParameter("@NextFollowDate", MySqlDbType.Date),
                new MySqlParameter("@FollowDoctor", MySqlDbType.String, 50),
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
            cmdParms[4].Value = model.Tcmhm;
            cmdParms[5].Value = model.TcmhmOther;
            cmdParms[6].Value = model.NextFollowDate;
            cmdParms[7].Value = model.FollowDoctor;
            cmdParms[8].Value = model.IsDel;
            cmdParms[9].Value = model.CreatedBy;
            cmdParms[10].Value = model.CreatedDate;
            cmdParms[11].Value = model.LastUpdateBy;
            cmdParms[12].Value = model.LastUpdateDate;
            cmdParms[13].Value = model.IDCardNo;
            cmdParms[14].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(KidsTcmhmOneModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_kidstcmhmone set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("FollowupType=@FollowupType,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("Tcmhm=@Tcmhm,");
            builder.Append("TcmhmOther=@TcmhmOther,");
            builder.Append("NextFollowDate=@NextFollowDate,");
            builder.Append("FollowDoctor=@FollowDoctor,");
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
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10), 
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255),
                new MySqlParameter("@NextFollowDate", MySqlDbType.Date),
                new MySqlParameter("@FollowDoctor", MySqlDbType.String, 50),
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
            cmdParms[4].Value = model.Tcmhm;
            cmdParms[5].Value = model.TcmhmOther;
            cmdParms[6].Value = model.NextFollowDate;
            cmdParms[7].Value = model.FollowDoctor;
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

