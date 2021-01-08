namespace KangShuoTech.DataAccessProjects.DAL
{
    using Utilities.MySQLHelper;
    using Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
   
    public class KidsTcmhmThreeToSixDAL
    {
        public int Add(KidsTcmhmThreeToSixModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_kidstcmhmthreetosix(");
            builder.Append("CustomerID,RecordID,FollowupType,Tcmhm,TcmhmOther,FollowupDate,NextFollowUpDate,FollowUpDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@FollowupType,@Tcmhm,@TcmhmOther,@FollowupDate,@NextFollowUpDate,@FollowUpDoctor,@IsDel,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IDCardNo)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@FollowupType", MySqlDbType.String, 1),
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10), 
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
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
            cmdParms[3].Value = model.Tcmhm;
            cmdParms[4].Value = model.TcmhmOther;
            cmdParms[5].Value = model.FollowupDate;
            cmdParms[6].Value = model.NextFollowupDate;
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

        public int AddServer(KidsTcmhmThreeToSixModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_kidstcmhmthreetosix(");
            builder.Append("CustomerID,RecordID,FollowupType,Tcmhm,TcmhmOther,FollowupDate,NextFollowUpDate,FollowUpDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@FollowupType,@Tcmhm,@TcmhmOther,@FollowupDate,@NextFollowUpDate,@FollowUpDoctor,@IsDel,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IDCardNo)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@FollowupType", MySqlDbType.String, 1),
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10), 
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date),
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
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
            cmdParms[3].Value = model.Tcmhm;
            cmdParms[4].Value = model.TcmhmOther;
            cmdParms[5].Value = model.FollowupDate;
            cmdParms[6].Value = model.NextFollowupDate;
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

        public KidsTcmhmThreeToSixModel DataRowToModel(DataRow row)
        {
            KidsTcmhmThreeToSixModel kidsTcmhmThreeToSixModel = new KidsTcmhmThreeToSixModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    kidsTcmhmThreeToSixModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    kidsTcmhmThreeToSixModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    kidsTcmhmThreeToSixModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["FollowupType"] != null) && (row["FollowupType"] != DBNull.Value))
                {
                    kidsTcmhmThreeToSixModel.FollowupType = row["FollowupType"].ToString();
                }
                if ((row["Tcmhm"] != null) && (row["Tcmhm"] != DBNull.Value))
                {
                    kidsTcmhmThreeToSixModel.Tcmhm = row["Tcmhm"].ToString();
                }
                if ((row["TcmhmOther"] != null) && (row["TcmhmOther"] != DBNull.Value))
                {
                    kidsTcmhmThreeToSixModel.TcmhmOther = row["TcmhmOther"].ToString();
                }
                if (((row["FollowupDate"] != null) && (row["FollowupDate"] != DBNull.Value)) && (row["FollowupDate"].ToString() != ""))
                {
                    kidsTcmhmThreeToSixModel.FollowupDate = new DateTime?(DateTime.Parse(row["FollowupDate"].ToString()));
                }
                if (((row["NextFollowUpDate"] != null) && (row["NextFollowUpDate"] != DBNull.Value)) && (row["NextFollowUpDate"].ToString() != ""))
                {
                    kidsTcmhmThreeToSixModel.NextFollowupDate = new DateTime?(DateTime.Parse(row["NextFollowUpDate"].ToString()));
                }
                if ((row["FollowUpDoctor"] != null) && (row["FollowUpDoctor"] != DBNull.Value))
                {
                    kidsTcmhmThreeToSixModel.FollowUpDoctor = row["FollowUpDoctor"].ToString();
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    kidsTcmhmThreeToSixModel.IsDel = row["IsDel"].ToString();
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    kidsTcmhmThreeToSixModel.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    kidsTcmhmThreeToSixModel.CreatedDate = (DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    kidsTcmhmThreeToSixModel.LastUpdateBy = (decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    kidsTcmhmThreeToSixModel.LastUpdateDate =(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    kidsTcmhmThreeToSixModel.IDCardNo = row["IDCardNo"].ToString();
                }

                kidsTcmhmThreeToSixModel.ModelState = RecordsStateModel.Unchanged;
            }
            return kidsTcmhmThreeToSixModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_kidstcmhmthreetosix ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_kidstcmhmthreetosix ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_kidstcmhmthreetosix");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,FollowupType,Tcmhm,TcmhmOther,FollowupDate,NextFollowUpDate,FollowUpDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo ");
            builder.Append(" FROM tbl_kidstcmhmthreetosix ");
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
            builder.Append(")AS Row, T.*  from tbl_kidstcmhmthreetosix T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_kidstcmhmthreetosix");
        }

        public KidsTcmhmThreeToSixModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,FollowupType,Tcmhm,TcmhmOther,FollowupDate,NextFollowUpDate,FollowUpDoctor,IsDel,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IDCardNo from tbl_kidstcmhmthreetosix ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new KidsTcmhmThreeToSixModel();
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
            builder.Append("select count(1) FROM tbl_kidstcmhmthreetosix ");
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

        public bool Update(KidsTcmhmThreeToSixModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_kidstcmhmthreetosix set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("FollowupType=@FollowupType,");
            builder.Append("Tcmhm=@Tcmhm,");
            builder.Append("TcmhmOther=@TcmhmOther,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
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
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10),
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
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
            cmdParms[3].Value = model.Tcmhm;
            cmdParms[4].Value = model.TcmhmOther;
            cmdParms[5].Value = model.FollowupDate;
            cmdParms[6].Value = model.NextFollowupDate;
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

        public bool UpdateServer(KidsTcmhmThreeToSixModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_kidstcmhmthreetosix set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("FollowupType=@FollowupType,");
            builder.Append("Tcmhm=@Tcmhm,");
            builder.Append("TcmhmOther=@TcmhmOther,");
            builder.Append("FollowupDate=@FollowupDate,");
            builder.Append("NextFollowUpDate=@NextFollowUpDate,");
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
                new MySqlParameter("@Tcmhm", MySqlDbType.String, 10),
                new MySqlParameter("@TcmhmOther", MySqlDbType.String, 255),
                new MySqlParameter("@FollowupDate", MySqlDbType.Date), 
                new MySqlParameter("@NextFollowUpDate", MySqlDbType.Date),
                new MySqlParameter("@FollowUpDoctor", MySqlDbType.String, 50),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
               // new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.FollowupType;
            cmdParms[3].Value = model.Tcmhm;
            cmdParms[4].Value = model.TcmhmOther;
            cmdParms[5].Value = model.FollowupDate;
            cmdParms[6].Value = model.NextFollowupDate;
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

