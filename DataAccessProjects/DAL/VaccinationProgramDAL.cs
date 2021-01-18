namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class VaccinationProgramDAL
    {
        public int Add(VaccinationProgramModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into INOCULATION_PROGRAM(");
            builder.Append("CustomerID,RecordID,IDCardNo,VaccinationName,VaccinationChild,VaccinationTimes,VaccinationPart,VaccinationDoes,Remark,");
            builder.Append("VaccineBatchNumber,VaccinationDoctor,VaccinationTime,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@VaccinationName,@VaccinationChild,@VaccinationTimes,@VaccinationPart,@VaccinationDoes,@Remark,@VaccineBatchNumber,@VaccinationDoctor,@VaccinationTime,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@CustomerID", MySqlDbType.String, 0x12),
                new MySqlParameter("@RecordID", MySqlDbType.String, 0x11),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@VaccinationName", MySqlDbType.String, 60), 
                new MySqlParameter("@VaccinationChild", MySqlDbType.String, 80),
                new MySqlParameter("@VaccinationTimes", MySqlDbType.Decimal),
                new MySqlParameter("@VaccinationPart", MySqlDbType.String, 40), 
                new MySqlParameter("@VaccinationDoes", MySqlDbType.String, 150), 
                new MySqlParameter("@Remark", MySqlDbType.String, 150), 
                new MySqlParameter("@VaccineBatchNumber", MySqlDbType.String, 30), 
                new MySqlParameter("@VaccinationDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@VaccinationTime", MySqlDbType.Date),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date)
            };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.VaccinationName;
            cmdParms[4].Value = model.VaccinationChild;
            cmdParms[5].Value = model.VaccinationTimes;
            cmdParms[6].Value = model.VaccinationPart;
            cmdParms[7].Value = model.VaccinationDoes;
            cmdParms[8].Value = model.Remark;
            cmdParms[9].Value = model.VaccineBatchNumber;
            cmdParms[10].Value = model.VaccinationDoctor;
            cmdParms[11].Value = model.VaccinationTime;
            cmdParms[12].Value = model.CreateBy;
            cmdParms[13].Value = model.CreateDate;
            cmdParms[14].Value = model.LastUpdateBy;
            cmdParms[15].Value = model.LastUpdateDate;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public VaccinationProgramModel DataRowToModel(DataRow row)
        {
            VaccinationProgramModel INOCULATION_OTHERPROGRAM = new VaccinationProgramModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    INOCULATION_OTHERPROGRAM.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    INOCULATION_OTHERPROGRAM.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    INOCULATION_OTHERPROGRAM.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    INOCULATION_OTHERPROGRAM.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["VaccinationName"] != null) && (row["VaccinationName"] != DBNull.Value))
                {
                    INOCULATION_OTHERPROGRAM.VaccinationName = row["VaccinationName"].ToString();
                }
                if ((row["VaccinationChild"] != null) && (row["VaccinationChild"] != DBNull.Value))
                {
                    INOCULATION_OTHERPROGRAM.VaccinationChild = row["VaccinationChild"].ToString();
                }
                if (((row["VaccinationTimes"] != null) && (row["VaccinationTimes"] != DBNull.Value)) && (row["VaccinationTimes"].ToString() != ""))
                {
                    INOCULATION_OTHERPROGRAM.VaccinationTimes = new decimal?(decimal.Parse(row["VaccinationTimes"].ToString()));
                }
                if ((row["VaccinationPart"] != null) && (row["VaccinationPart"] != DBNull.Value))
                {
                    INOCULATION_OTHERPROGRAM.VaccinationPart = row["VaccinationPart"].ToString();
                }
                if ((row["VaccinationDoes"] != null) && (row["VaccinationDoes"] != DBNull.Value))
                {
                    INOCULATION_OTHERPROGRAM.VaccinationDoes = row["VaccinationDoes"].ToString();
                }
                if ((row["Remark"] != null) && (row["Remark"] != DBNull.Value))
                {
                    INOCULATION_OTHERPROGRAM.Remark = row["Remark"].ToString();
                }
                if ((row["VaccineBatchNumber"] != null) && (row["VaccineBatchNumber"] != DBNull.Value))
                {
                    INOCULATION_OTHERPROGRAM.VaccineBatchNumber = row["VaccineBatchNumber"].ToString();
                }
                if ((row["VaccinationDoctor"] != null) && (row["VaccinationDoctor"] != DBNull.Value))
                {
                    INOCULATION_OTHERPROGRAM.VaccinationDoctor = row["VaccinationDoctor"].ToString();
                }
                if (((row["VaccinationTime"] != null) && (row["VaccinationTime"] != DBNull.Value)) && (row["VaccinationTime"].ToString() != ""))
                {
                    INOCULATION_OTHERPROGRAM.VaccinationTime = new DateTime?(DateTime.Parse(row["VaccinationTime"].ToString()));
                }
                if (((row["CreateBy"] != null) && (row["CreateBy"] != DBNull.Value)) && (row["CreateBy"].ToString() != ""))
                {
                    INOCULATION_OTHERPROGRAM.CreateBy = new decimal?(decimal.Parse(row["CreateBy"].ToString()));
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    INOCULATION_OTHERPROGRAM.CreateDate = new DateTime?(DateTime.Parse(row["CreateDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    INOCULATION_OTHERPROGRAM.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    INOCULATION_OTHERPROGRAM.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                INOCULATION_OTHERPROGRAM.ModelStatus = RecordsStateModel.Unchanged;
            }
            return INOCULATION_OTHERPROGRAM;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from INOCULATION_PROGRAM ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from INOCULATION_PROGRAM ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from INOCULATION_PROGRAM");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,VaccinationName,VaccinationChild,VaccinationTimes,VaccinationPart,VaccinationDoes,Remark,VaccineBatchNumber,VaccinationDoctor,VaccinationTime,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate ");
            builder.Append(" FROM INOCULATION_PROGRAM ");
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
            builder.Append(")AS Row, T.*  from INOCULATION_PROGRAM T ");
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
            return MySQLHelper.GetMaxID("ID", "INOCULATION_PROGRAM");
        }

        public VaccinationProgramModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,VaccinationName,VaccinationChild,VaccinationTimes,VaccinationPart,VaccinationDoes,Remark,VaccineBatchNumber,VaccinationDoctor,VaccinationTime,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate from INOCULATION_PROGRAM ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new VaccinationProgramModel();
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
            builder.Append("select count(1) FROM INOCULATION_PROGRAM ");
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

        public bool Update(VaccinationProgramModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update INOCULATION_PROGRAM set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("VaccinationName=@VaccinationName,");
            builder.Append("VaccinationChild=@VaccinationChild,");
            builder.Append("VaccinationTimes=@VaccinationTimes,");
            builder.Append("VaccinationPart=@VaccinationPart,");
            builder.Append("VaccinationDoes=@VaccinationDoes,");
            builder.Append("Remark=@Remark,");
            builder.Append("VaccineBatchNumber=@VaccineBatchNumber,");
            builder.Append("VaccinationDoctor=@VaccinationDoctor,");
            builder.Append("VaccinationTime=@VaccinationTime,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@VaccinationName", MySqlDbType.String, 60), 
                new MySqlParameter("@VaccinationChild", MySqlDbType.String, 80), 
                new MySqlParameter("@VaccinationTimes", MySqlDbType.Decimal),
                new MySqlParameter("@VaccinationPart", MySqlDbType.String, 40), 
                new MySqlParameter("@VaccinationDoes", MySqlDbType.String, 150), 
                new MySqlParameter("@Remark", MySqlDbType.String, 150), 
                new MySqlParameter("@VaccineBatchNumber", MySqlDbType.String, 30),
                new MySqlParameter("@VaccinationDoctor", MySqlDbType.String, 30),
                new MySqlParameter("@VaccinationTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.VaccinationName;
            cmdParms[4].Value = model.VaccinationChild;
            cmdParms[5].Value = model.VaccinationTimes;
            cmdParms[6].Value = model.VaccinationPart;
            cmdParms[7].Value = model.VaccinationDoes;
            cmdParms[8].Value = model.Remark;
            cmdParms[9].Value = model.VaccineBatchNumber;
            cmdParms[10].Value = model.VaccinationDoctor;
            cmdParms[11].Value = model.VaccinationTime;
            cmdParms[12].Value = model.CreateBy;
            cmdParms[13].Value = model.CreateDate;
            cmdParms[14].Value = model.LastUpdateBy;
            cmdParms[15].Value = model.LastUpdateDate;
            cmdParms[16].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

