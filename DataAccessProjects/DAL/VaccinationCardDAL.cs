namespace KangShuoTech.DataAccessProjects.DAL
{
    using Utilities.MySQLHelper;
    using Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class  VaccinationCardDAL
    {
        public int Add( VaccinationCardModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into INOCULATION_CARD(");
            builder.Append("CustomerID,RecordID,IDCardNo,VaccinationCardID,Guardian,Relation,Phone,HomeAddress,HouseHoldAddress,VaccinationInTime, ");
            builder.Append("VaccinationOutTime,VaccinationOutReason,VaccinationIllHistory,VaccinationTaboo,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDelete,VaccinationExpHistory) ");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@VaccinationCardID,@Guardian,@Relation,@Phone,@HomeAddress,@HouseHoldAddress,@VaccinationInTime,@VaccinationOutTime,@VaccinationOutReason,@VaccinationIllHistory,@VaccinationTaboo,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate,@IsDelete,@VaccinationExpHistory )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 0x20),
                new MySqlParameter("@RecordID", MySqlDbType.String, 0x11),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@VaccinationCardID", MySqlDbType.String, 0x11), 
                new MySqlParameter("@Guardian", MySqlDbType.String, 20),
                new MySqlParameter("@Relation", MySqlDbType.String, 10),
                new MySqlParameter("@Phone", MySqlDbType.String, 15), 
                new MySqlParameter("@HomeAddress", MySqlDbType.String, 200), 
                new MySqlParameter("@HouseHoldAddress", MySqlDbType.String, 200), 
                new MySqlParameter("@VaccinationInTime", MySqlDbType.Date), 
                new MySqlParameter("@VaccinationOutTime", MySqlDbType.Date), 
                new MySqlParameter("@VaccinationOutReason", MySqlDbType.String, 200), 
                new MySqlParameter("@VaccinationIllHistory", MySqlDbType.String, 500),
                new MySqlParameter("@VaccinationTaboo", MySqlDbType.String, 500), 
                new MySqlParameter("@CreateBy", MySqlDbType.String), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                new MySqlParameter( "@VaccinationExpHistory",MySqlDbType.String,200)
                
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.VaccinationCardID;
            cmdParms[4].Value = model.Guardian;
            cmdParms[5].Value = model.Relation;
            cmdParms[6].Value = model.Phone;
            cmdParms[7].Value = model.HomeAddress;
            cmdParms[8].Value = model.HouseHoldAddress;
            cmdParms[9].Value = model.VaccinationInTime;
            cmdParms[10].Value = model.VaccinationOutTime;
            cmdParms[11].Value = model.VaccinationOutReason;
            cmdParms[12].Value = model.VaccinationIllHistory;
            cmdParms[13].Value = model.VaccinationTaboo;
            cmdParms[14].Value = model.CreateBy;
            cmdParms[15].Value = model.CreateDate;
            cmdParms[16].Value = model.LastUpdateBy;
            cmdParms[17].Value = model.LastUpdateDate;
            cmdParms[18].Value = model.IsDelete;
            cmdParms[19].Value = model.VaccinationExpHistory;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public VaccinationCardModel DataRowToModel(DataRow row)
        {
            VaccinationCardModel inoculation_card = new VaccinationCardModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    inoculation_card.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    inoculation_card.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    inoculation_card.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    inoculation_card.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["VaccinationCardID"] != null) && (row["VaccinationCardID"] != DBNull.Value))
                {
                    inoculation_card.VaccinationCardID = row["VaccinationCardID"].ToString();
                }
                if ((row["Guardian"] != null) && (row["Guardian"] != DBNull.Value))
                {
                    inoculation_card.Guardian = row["Guardian"].ToString();
                }
                if ((row["Relation"] != null) && (row["Relation"] != DBNull.Value))
                {
                    inoculation_card.Relation = row["Relation"].ToString();
                }
                if ((row["Phone"] != null) && (row["Phone"] != DBNull.Value))
                {
                    inoculation_card.Phone = row["Phone"].ToString();
                }
                if ((row["HomeAddress"] != null) && (row["HomeAddress"] != DBNull.Value))
                {
                    inoculation_card.HomeAddress = row["HomeAddress"].ToString();
                }
                if ((row["HouseHoldAddress"] != null) && (row["HouseHoldAddress"] != DBNull.Value))
                {
                    inoculation_card.HouseHoldAddress = row["HouseHoldAddress"].ToString();
                }
                if (((row["VaccinationInTime"] != null) && (row["VaccinationInTime"] != DBNull.Value)) && (row["VaccinationInTime"].ToString() != ""))
                {
                    inoculation_card.VaccinationInTime = new DateTime?(DateTime.Parse(row["VaccinationInTime"].ToString()));
                }
                if (((row["VaccinationOutTime"] != null) && (row["VaccinationOutTime"] != DBNull.Value)) && (row["VaccinationOutTime"].ToString() != ""))
                {
                    inoculation_card.VaccinationOutTime = new DateTime?(DateTime.Parse(row["VaccinationOutTime"].ToString()));
                }
                if ((row["VaccinationOutReason"] != null) && (row["VaccinationOutReason"] != DBNull.Value))
                {
                    inoculation_card.VaccinationOutReason = row["VaccinationOutReason"].ToString();
                }
                if ((row["VaccinationIllHistory"] != null) && (row["VaccinationIllHistory"] != DBNull.Value))
                {
                    inoculation_card.VaccinationIllHistory = row["VaccinationIllHistory"].ToString();
                }
                if ((row["VaccinationTaboo"] != null) && (row["VaccinationTaboo"] != DBNull.Value))
                {
                    inoculation_card.VaccinationTaboo = row["VaccinationTaboo"].ToString();
                }
                if ((row["VaccinationExpHistory"] != null) && (row["VaccinationExpHistory"] != DBNull.Value))
                {
                    inoculation_card.VaccinationExpHistory = row["VaccinationExpHistory"].ToString();
                }
                if (((row["CreateBy"] != null) && (row["CreateBy"] != DBNull.Value)) && (row["CreateBy"].ToString() != ""))
                {
                    inoculation_card.CreateBy = row["CreateBy"].ToString();
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    inoculation_card.CreateDate = new DateTime?(DateTime.Parse(row["CreateDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    inoculation_card.LastUpdateBy = row["LastUpdateBy"].ToString();
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    inoculation_card.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDelete"] != null) && (row["IsDelete"] != DBNull.Value))
                {
                    inoculation_card.IsDelete = row["IsDelete"].ToString();
                }
            }
            return inoculation_card;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from INOCULATION_CARD ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from INOCULATION_CARD ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from INOCULATION_CARD");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,VaccinationCardID,Guardian,Relation,Phone,HomeAddress,HouseHoldAddress,VaccinationInTime,VaccinationOutTime,VaccinationOutReason,VaccinationIllHistory,VaccinationTaboo,VaccinationExpHistory,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDelete ");
            builder.Append(" FROM INOCULATION_CARD ");
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
            builder.Append(")AS Row, T.*  from INOCULATION_CARD T ");
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
            return MySQLHelper.GetMaxID("ID", "INOCULATION_CARD");
        }

        public VaccinationCardModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,VaccinationCardID,Guardian,Relation,Phone,HomeAddress,HouseHoldAddress,VaccinationInTime,VaccinationOutTime,VaccinationOutReason,VaccinationIllHistory,VaccinationTaboo,VaccinationExpHistory,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDelete from INOCULATION_CARD ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new VaccinationCardModel();
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
            builder.Append("select count(1) FROM INOCULATION_CARD ");
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

        public bool Update(VaccinationCardModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update INOCULATION_CARD set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("VaccinationCardID=@VaccinationCardID,");
            builder.Append("Guardian=@Guardian,");
            builder.Append("Relation=@Relation,");
            builder.Append("Phone=@Phone,");
            builder.Append("HomeAddress=@HomeAddress,");
            builder.Append("HouseHoldAddress=@HouseHoldAddress,");
            builder.Append("VaccinationInTime=@VaccinationInTime,");
            builder.Append("VaccinationOutTime=@VaccinationOutTime,");
            builder.Append("VaccinationOutReason=@VaccinationOutReason,");
            builder.Append("VaccinationIllHistory=@VaccinationIllHistory,");
            builder.Append("VaccinationTaboo=@VaccinationTaboo,");
            builder.Append("VaccinationExpHistory=@VaccinationExpHistory,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDelete=@IsDelete");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@VaccinationCardID", MySqlDbType.String, 17), 
                new MySqlParameter("@Guardian", MySqlDbType.String, 20), 
                new MySqlParameter("@Relation", MySqlDbType.String, 10),
                new MySqlParameter("@Phone", MySqlDbType.String, 15), 
                new MySqlParameter("@HomeAddress", MySqlDbType.String, 200),
                new MySqlParameter("@HouseHoldAddress", MySqlDbType.String, 200), 
                new MySqlParameter("@VaccinationInTime", MySqlDbType.Date), 
                new MySqlParameter("@VaccinationOutTime", MySqlDbType.Date),
                new MySqlParameter("@VaccinationOutReason", MySqlDbType.String, 200),
                new MySqlParameter("@VaccinationIllHistory", MySqlDbType.String, 500), 
                new MySqlParameter("@VaccinationTaboo", MySqlDbType.String, 500),
                new MySqlParameter("@VaccinationExpHistory", MySqlDbType.String, 500),
                new MySqlParameter("@CreateBy", MySqlDbType.String), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.VaccinationCardID;
            cmdParms[4].Value = model.Guardian;
            cmdParms[5].Value = model.Relation;
            cmdParms[6].Value = model.Phone;
            cmdParms[7].Value = model.HomeAddress;
            cmdParms[8].Value = model.HouseHoldAddress;
            cmdParms[9].Value = model.VaccinationInTime;
            cmdParms[10].Value = model.VaccinationOutTime;
            cmdParms[11].Value = model.VaccinationOutReason;
            cmdParms[12].Value = model.VaccinationIllHistory;
            cmdParms[13].Value = model.VaccinationTaboo;
            cmdParms[14].Value = model.VaccinationExpHistory;
            cmdParms[15].Value = model.CreateBy;
            cmdParms[16].Value = model.CreateDate;
            cmdParms[17].Value = model.LastUpdateBy;
            cmdParms[18].Value = model.LastUpdateDate;
            cmdParms[19].Value = model.IsDelete;
            cmdParms[20].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

