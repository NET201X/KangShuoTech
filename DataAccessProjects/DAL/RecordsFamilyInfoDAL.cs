namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsFamilyInfoDAL
    {
        public int Add(RecordsFamilyInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsfamilyinfo(");
            builder.Append("FamilyRecordID,IDCardNo,RecordID,HomeAddr,HomeAddrInfo,ToiletType,HouseType,IsPoorfy,LiveStatus,IncomeAvg,CreateUnit,HouseArea,Monthoil,MonthSalt,CreatedBy,CreatedDate,LastUpDateBy,LastUpdateDate)");
            builder.Append(" values (");
            builder.Append("@FamilyRecordID,@IDCardNo,@RecordID,@HomeAddr,@HomeAddrInfo,@ToiletType,@HouseType,@IsPoorfy,@LiveStatus,@IncomeAvg,@CreateUnit,@HouseArea,@Monthoil,@MonthSalt,@CreatedBy,@CreatedDate,@LastUpDateBy,@LastUpdateDate)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@FamilyRecordID", MySqlDbType.String, 21),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@HomeAddr", MySqlDbType.String, 200),
                new MySqlParameter("@HomeAddrInfo", MySqlDbType.String, 200), 
                new MySqlParameter("@ToiletType", MySqlDbType.String, 1), 
                new MySqlParameter("@HouseType", MySqlDbType.String, 1), 
                new MySqlParameter("@IsPoorfy", MySqlDbType.String, 1), 
                new MySqlParameter("@LiveStatus", MySqlDbType.String, 1), 
                new MySqlParameter("@IncomeAvg", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateUnit", MySqlDbType.String, 100), 
                new MySqlParameter("@HouseArea", MySqlDbType.Decimal), 
                new MySqlParameter("@Monthoil", MySqlDbType.Decimal),
                new MySqlParameter("@MonthSalt", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedBy", MySqlDbType.String),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpDateBy", MySqlDbType.String), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date)
             };
            cmdParms[0].Value = model.FamilyRecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.RecordID;
            cmdParms[3].Value = model.HomeAddr;
            cmdParms[4].Value = model.HomeAddrInfo;
            cmdParms[5].Value = model.ToiletType;
            cmdParms[6].Value = model.HouseType;
            cmdParms[7].Value = model.IsPoorfy;
            cmdParms[8].Value = model.LiveStatus;
            cmdParms[9].Value = model.IncomeAvg;
            cmdParms[10].Value = model.CreateUnit;
            cmdParms[11].Value = model.HouseArea;
            cmdParms[12].Value = model.Monthoil;
            cmdParms[13].Value = model.MonthSalt;
            cmdParms[14].Value = model.CreateBy;
            cmdParms[15].Value = model.CreatedDate;
            cmdParms[16].Value = model.LastUpDateBy;
            cmdParms[17].Value = model.LastUpdateDate;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsFamilyInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordsfamilyinfo(");
            builder.Append("FamilyRecordID,IDCardNo,RecordID,HomeAddr,HomeAddrInfo,ToiletType,HouseType,IsPoorfy,LiveStatus,IncomeAvg,CreateUnit,HouseArea,Monthoil,MonthSalt,CreatedBy,CreatedDate,LastUpDateBy,LastUpdateDate)");
            builder.Append(" values (");
            builder.Append("@FamilyRecordID,@IDCardNo,@RecordID,@HomeAddr,@HomeAddrInfo,@ToiletType,@HouseType,@IsPoorfy,@LiveStatus,@IncomeAvg,@CreateUnit,@HouseArea,@Monthoil,@MonthSalt,@CreatedBy,@CreatedDate,@LastUpDateBy,@LastUpdateDate)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@FamilyRecordID", MySqlDbType.String, 21),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@HomeAddr", MySqlDbType.String, 200),
                new MySqlParameter("@HomeAddrInfo", MySqlDbType.String, 200), 
                new MySqlParameter("@ToiletType", MySqlDbType.String, 1), 
                new MySqlParameter("@HouseType", MySqlDbType.String, 1), 
                new MySqlParameter("@IsPoorfy", MySqlDbType.String, 1), 
                new MySqlParameter("@LiveStatus", MySqlDbType.String, 1), 
                new MySqlParameter("@IncomeAvg", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateUnit", MySqlDbType.String, 100), 
                new MySqlParameter("@HouseArea", MySqlDbType.Decimal), 
                new MySqlParameter("@Monthoil", MySqlDbType.Decimal),
                new MySqlParameter("@MonthSalt", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedBy", MySqlDbType.String),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpDateBy", MySqlDbType.String), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date)
             };
            cmdParms[0].Value = model.FamilyRecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.RecordID;
            cmdParms[3].Value = model.HomeAddr;
            cmdParms[4].Value = model.HomeAddrInfo;
            cmdParms[5].Value = model.ToiletType;
            cmdParms[6].Value = model.HouseType;
            cmdParms[7].Value = model.IsPoorfy;
            cmdParms[8].Value = model.LiveStatus;
            cmdParms[9].Value = model.IncomeAvg;
            cmdParms[10].Value = model.CreateUnit;
            cmdParms[11].Value = model.HouseArea;
            cmdParms[12].Value = model.Monthoil;
            cmdParms[13].Value = model.MonthSalt;
            cmdParms[14].Value = model.CreateBy;
            cmdParms[15].Value = model.CreatedDate;
            cmdParms[16].Value = model.LastUpDateBy;
            cmdParms[17].Value = model.LastUpdateDate;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsFamilyInfoModel DataRowToModel(DataRow row)
        {
            RecordsFamilyInfoModel recordsFamilyInfoModel = new RecordsFamilyInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsFamilyInfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["FamilyRecordID"] != null) && (row["FamilyRecordID"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.FamilyRecordID = row["FamilyRecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["HomeAddr"] != null) && (row["HomeAddr"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.HomeAddr = row["HomeAddr"].ToString();
                }
                if ((row["HomeAddrInfo"] != null) && (row["HomeAddrInfo"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.HomeAddrInfo = row["HomeAddrInfo"].ToString();
                }
                if ((row["ToiletType"] != null) && (row["ToiletType"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.ToiletType = row["ToiletType"].ToString();
                }
                if ((row["HouseType"] != null) && (row["HouseType"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.HouseType = row["HouseType"].ToString();
                }
                if ((row["IsPoorfy"] != null) && (row["IsPoorfy"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.IsPoorfy = row["IsPoorfy"].ToString();
                }
                if ((row["LiveStatus"] != null) && (row["LiveStatus"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.LiveStatus = row["LiveStatus"].ToString();
                }
                if (((row["IncomeAvg"] != null) && (row["IncomeAvg"] != DBNull.Value)) && (row["IncomeAvg"].ToString() != ""))
                {
                    recordsFamilyInfoModel.IncomeAvg = new decimal?(decimal.Parse(row["IncomeAvg"].ToString()));
                }
                if ((row["CreateUnit"] != null) && (row["CreateUnit"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.CreateUnit = row["CreateUnit"].ToString();
                }
                if (((row["HouseArea"] != null) && (row["HouseArea"] != DBNull.Value)) && (row["HouseArea"].ToString() != ""))
                {
                    recordsFamilyInfoModel.HouseArea = new decimal?(decimal.Parse(row["HouseArea"].ToString()));
                }
                if (((row["Monthoil"] != null) && (row["Monthoil"] != DBNull.Value)) && (row["Monthoil"].ToString() != ""))
                {
                    recordsFamilyInfoModel.Monthoil = new decimal?(decimal.Parse(row["Monthoil"].ToString()));
                }
                if (((row["MonthSalt"] != null) && (row["MonthSalt"] != DBNull.Value)) && (row["MonthSalt"].ToString() != ""))
                {
                    recordsFamilyInfoModel.MonthSalt = new decimal?(decimal.Parse(row["MonthSalt"].ToString()));
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    recordsFamilyInfoModel.CreateBy = row["CreatedBy"].ToString();
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    recordsFamilyInfoModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpDateBy"] != null) && (row["LastUpDateBy"] != DBNull.Value)) && (row["LastUpDateBy"].ToString() != ""))
                {
                    recordsFamilyInfoModel.LastUpDateBy = row["LastUpDateBy"].ToString();
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    recordsFamilyInfoModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["CustomerName"] != null) && (row["CustomerName"] != DBNull.Value))
                {
                    recordsFamilyInfoModel.CustomerName = row["CustomerName"].ToString();
                }
            }
            return recordsFamilyInfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsfamilyinfo ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordsfamilyinfo ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordsfamilyinfo");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select f.* ,b.CUSTOMERNAME \n  from tbl_recordsfamilyinfo f inner join tbl_recordsbaseinfo b on f.IDCardNo = b.IDCardNo WHERE 1 = 1 ");
            if (strWhere.Trim() != "")
            {
                builder.Append(strWhere);
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
            builder.Append(")AS Row, T.*  from tbl_recordsfamilyinfo T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_recordsfamilyinfo");
        }

        public RecordsFamilyInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(
                "select  f.ID,f.FamilyRecordID,f.IDCardNo,f.RecordID,f.HomeAddr,f.HomeAddrInfo,f.ToiletType,f.HouseType,");
            builder.Append(
                "f.IsPoorfy,f.LiveStatus,f.IncomeAvg,f.CreateUnit,f.HouseArea,f.Monthoil,f.MonthSalt,f.CreatedBy,");
            builder.Append("f.CreatedDate,f.LastUpDateBy,f.LastUpdateDate,b.CUSTOMERNAME ");
            builder.Append(" from tbl_recordsfamilyinfo f inner join tbl_recordsbaseinfo b on f.IDCardNo = b.IDCardNo ");
            builder.Append(" where f.IDCardNo=@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsFamilyInfoModel();
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
            builder.Append("select count(1) FROM tbl_recordsfamilyinfo ");
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

        public bool Update(RecordsFamilyInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsfamilyinfo set ");
            builder.Append("FamilyRecordID=@FamilyRecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("HomeAddr=@HomeAddr,");
            builder.Append("HomeAddrInfo=@HomeAddrInfo,");
            builder.Append("ToiletType=@ToiletType,");
            builder.Append("HouseType=@HouseType,");
            builder.Append("IsPoorfy=@IsPoorfy,");
            builder.Append("LiveStatus=@LiveStatus,");
            builder.Append("IncomeAvg=@IncomeAvg,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("HouseArea=@HouseArea,");
            builder.Append("Monthoil=@Monthoil,");
            builder.Append("MonthSalt=@MonthSalt,");
            builder.Append("CreatedBy=@CreateBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpDateBy=@LastUpDateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@FamilyRecordID", MySqlDbType.String, 21), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@HomeAddr", MySqlDbType.String, 200),
                new MySqlParameter("@HomeAddrInfo", MySqlDbType.String, 200), 
                new MySqlParameter("@ToiletType", MySqlDbType.String, 1), 
                new MySqlParameter("@HouseType", MySqlDbType.String, 1),
                new MySqlParameter("@IsPoorfy", MySqlDbType.String, 1), 
                new MySqlParameter("@LiveStatus", MySqlDbType.String, 1),
                new MySqlParameter("@IncomeAvg", MySqlDbType.Decimal),
                new MySqlParameter("@CreateUnit", MySqlDbType.String, 100),
                new MySqlParameter("@HouseArea", MySqlDbType.Decimal), 
                new MySqlParameter("@Monthoil", MySqlDbType.Decimal),
                new MySqlParameter("@MonthSalt", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateBy", MySqlDbType.String), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpDateBy", MySqlDbType.String), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.FamilyRecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.RecordID;
            cmdParms[3].Value = model.HomeAddr;
            cmdParms[4].Value = model.HomeAddrInfo;
            cmdParms[5].Value = model.ToiletType;
            cmdParms[6].Value = model.HouseType;
            cmdParms[7].Value = model.IsPoorfy;
            cmdParms[8].Value = model.LiveStatus;
            cmdParms[9].Value = model.IncomeAvg;
            cmdParms[10].Value = model.CreateUnit;
            cmdParms[11].Value = model.HouseArea;
            cmdParms[12].Value = model.Monthoil;
            cmdParms[13].Value = model.MonthSalt;
            cmdParms[14].Value = model.CreateBy;
            cmdParms[15].Value = model.CreatedDate;
            cmdParms[16].Value = model.LastUpDateBy;
            cmdParms[17].Value = model.LastUpdateDate;
            cmdParms[18].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsFamilyInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordsfamilyinfo set ");
            builder.Append("FamilyRecordID=@FamilyRecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("HomeAddr=@HomeAddr,");
            builder.Append("HomeAddrInfo=@HomeAddrInfo,");
            builder.Append("ToiletType=@ToiletType,");
            builder.Append("HouseType=@HouseType,");
            builder.Append("IsPoorfy=@IsPoorfy,");
            builder.Append("LiveStatus=@LiveStatus,");
            builder.Append("IncomeAvg=@IncomeAvg,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("HouseArea=@HouseArea,");
            builder.Append("Monthoil=@Monthoil,");
            builder.Append("MonthSalt=@MonthSalt,");
            builder.Append("CreatedBy=@CreateBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpDateBy=@LastUpDateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@FamilyRecordID", MySqlDbType.String, 21), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@HomeAddr", MySqlDbType.String, 200),
                new MySqlParameter("@HomeAddrInfo", MySqlDbType.String, 200), 
                new MySqlParameter("@ToiletType", MySqlDbType.String, 1), 
                new MySqlParameter("@HouseType", MySqlDbType.String, 1),
                new MySqlParameter("@IsPoorfy", MySqlDbType.String, 1), 
                new MySqlParameter("@LiveStatus", MySqlDbType.String, 1),
                new MySqlParameter("@IncomeAvg", MySqlDbType.Decimal),
                new MySqlParameter("@CreateUnit", MySqlDbType.String, 100),
                new MySqlParameter("@HouseArea", MySqlDbType.Decimal), 
                new MySqlParameter("@Monthoil", MySqlDbType.Decimal),
                new MySqlParameter("@MonthSalt", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateBy", MySqlDbType.String), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpDateBy", MySqlDbType.String), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.FamilyRecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.RecordID;
            cmdParms[3].Value = model.HomeAddr;
            cmdParms[4].Value = model.HomeAddrInfo;
            cmdParms[5].Value = model.ToiletType;
            cmdParms[6].Value = model.HouseType;
            cmdParms[7].Value = model.IsPoorfy;
            cmdParms[8].Value = model.LiveStatus;
            cmdParms[9].Value = model.IncomeAvg;
            cmdParms[10].Value = model.CreateUnit;
            cmdParms[11].Value = model.HouseArea;
            cmdParms[12].Value = model.Monthoil;
            cmdParms[13].Value = model.MonthSalt;
            cmdParms[14].Value = model.CreateBy;
            cmdParms[15].Value = model.CreatedDate;
            cmdParms[16].Value = model.LastUpDateBy;
            cmdParms[17].Value = model.LastUpdateDate;
            //cmdParms[18].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public int GetFamilyRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT COUNT(1)");
            builder.Append(" from tbl_recordsfamilyinfo  C inner join tbl_recordsbaseinfo T on T.FamilyIDCardNo = C.FamilyRecordID   ");
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
        public DataSet GetFamilyListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select T.IDCardNo,T.CustomerName,T.Sex,T.Birthday,T.Phone,T.HouseHoldAddress,C.RecordID,T.HouseRelation,C.FamilyRecordID ,T.CreateDate ");
            builder.Append("from tbl_recordsfamilyinfo  C inner join tbl_recordsbaseinfo T on T.FamilyIDCardNo = C.FamilyRecordID    ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }
    }
}

