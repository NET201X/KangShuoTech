namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsEducationActivitiesDAL
    {
        public int Add(RecordsEducationActivitiesModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordseducationactivities(");
            builder.Append("CustomerID,RecordID,IDCardNo,ActivityDate,ActivityAddress,ActivityType,ActivityTheme,Planner,EducationClasses,EducationNumber,DataFileNumber,ActivityContent,Activity,ActivityType,ResponsiblePerson,InformationPerson,FillformTime,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@ActivityDate,@ActivityAddress,@ActivityType,@ActivityTheme,@Planner,@EducationClasses,@EducationNumber,@DataFileNumber,@ActivityContent,@Activity,@ActivityType,@ResponsiblePerson,@InformationPerson,@FillformTime,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@ActivityDate", MySqlDbType.Date), 
                new MySqlParameter("@ActivityAddress", MySqlDbType.String, 200),
                new MySqlParameter("@ActivityType", MySqlDbType.String, 100), 
                new MySqlParameter("@ActivityTheme", MySqlDbType.String, 100), 
                new MySqlParameter("@Planner", MySqlDbType.String, 30), 
                new MySqlParameter("@EducationClasses", MySqlDbType.String, 50),
                new MySqlParameter("@EducationNumber", MySqlDbType.Decimal),
                new MySqlParameter("@DataFileNumber", MySqlDbType.String, 200),
                new MySqlParameter("@ActivityContent", MySqlDbType.String, 200),
                new MySqlParameter("@Activity", MySqlDbType.String),
                new MySqlParameter("@ActivityType", MySqlDbType.String, 20),
                new MySqlParameter("@ResponsiblePerson", MySqlDbType.String, 20), 
                new MySqlParameter("@InformationPerson", MySqlDbType.String, 20), 
                new MySqlParameter("@FillformTime", MySqlDbType.Date), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ActivityDate;
            cmdParms[4].Value = model.ActivityAddress;
            cmdParms[5].Value = model.ActivityType;
            cmdParms[6].Value = model.ActivityTheme;
            cmdParms[7].Value = model.Planner;
            cmdParms[8].Value = model.EducationClasses;
            cmdParms[9].Value = model.EducationNumber;
            cmdParms[10].Value = model.DataFileNumber;
            cmdParms[11].Value = model.ActivityContent;
            cmdParms[12].Value = model.Activity;
            cmdParms[13].Value = model.ActivityType;
            cmdParms[14].Value = model.ResponsiblePerson;
            cmdParms[15].Value = model.InformationPerson;
            cmdParms[16].Value = model.FillformTime;
            cmdParms[17].Value = model.CreatedBy;
            cmdParms[18].Value = model.CreatedDate;
            cmdParms[19].Value = model.LastUpdateBy;
            cmdParms[20].Value = model.LastUpdateDate;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsEducationActivitiesModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordseducationactivities(");
            builder.Append("CustomerID,RecordID,IDCardNo,ActivityDate,ActivityAddress,ActivityType,ActivityTheme,Planner,EducationClasses,EducationNumber,DataFileNumber,ActivityContent,Activity,ActivityType,ResponsiblePerson,InformationPerson,FillformTime,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@ActivityDate,@ActivityAddress,@ActivityType,@ActivityTheme,@Planner,@EducationClasses,@EducationNumber,@DataFileNumber,@ActivityContent,@Activity,@ActivityType,@ResponsiblePerson,@InformationPerson,@FillformTime,@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@ActivityDate", MySqlDbType.Date), 
                new MySqlParameter("@ActivityAddress", MySqlDbType.String, 200),
                new MySqlParameter("@ActivityType", MySqlDbType.String, 100), 
                new MySqlParameter("@ActivityTheme", MySqlDbType.String, 100), 
                new MySqlParameter("@Planner", MySqlDbType.String, 30), 
                new MySqlParameter("@EducationClasses", MySqlDbType.String, 50),
                new MySqlParameter("@EducationNumber", MySqlDbType.Decimal),
                new MySqlParameter("@DataFileNumber", MySqlDbType.String, 200),
                new MySqlParameter("@ActivityContent", MySqlDbType.String, 200),
                new MySqlParameter("@Activity", MySqlDbType.String),
                new MySqlParameter("@ActivityType", MySqlDbType.String, 20),
                new MySqlParameter("@ResponsiblePerson", MySqlDbType.String, 20), 
                new MySqlParameter("@InformationPerson", MySqlDbType.String, 20), 
                new MySqlParameter("@FillformTime", MySqlDbType.Date), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ActivityDate;
            cmdParms[4].Value = model.ActivityAddress;
            cmdParms[5].Value = model.ActivityType;
            cmdParms[6].Value = model.ActivityTheme;
            cmdParms[7].Value = model.Planner;
            cmdParms[8].Value = model.EducationClasses;
            cmdParms[9].Value = model.EducationNumber;
            cmdParms[10].Value = model.DataFileNumber;
            cmdParms[11].Value = model.ActivityContent;
            cmdParms[12].Value = model.Activity;
            cmdParms[13].Value = model.ActivityType;
            cmdParms[14].Value = model.ResponsiblePerson;
            cmdParms[15].Value = model.InformationPerson;
            cmdParms[16].Value = model.FillformTime;
            cmdParms[17].Value = model.CreatedBy;
            cmdParms[18].Value = model.CreatedDate;
            cmdParms[19].Value = model.LastUpdateBy;
            cmdParms[20].Value = model.LastUpdateDate;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsEducationActivitiesModel DataRowToModel(DataRow row)
        {
            RecordsEducationActivitiesModel recordsEducationActivitiesModel = new RecordsEducationActivitiesModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsEducationActivitiesModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if (((row["ActivityDate"] != null) && (row["ActivityDate"] != DBNull.Value)) && (row["ActivityDate"].ToString() != ""))
                {
                    recordsEducationActivitiesModel.ActivityDate = new DateTime?(DateTime.Parse(row["ActivityDate"].ToString()));
                }
                if ((row["ActivityAddress"] != null) && (row["ActivityAddress"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.ActivityAddress = row["ActivityAddress"].ToString();
                }
                if ((row["ActivityType"] != null) && (row["ActivityType"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.ActivityType = row["ActivityType"].ToString();
                }
                if ((row["ActivityTheme"] != null) && (row["ActivityTheme"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.ActivityTheme = row["ActivityTheme"].ToString();
                }
                if ((row["Planner"] != null) && (row["Planner"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.Planner = row["Planner"].ToString();
                }
                if ((row["EducationClasses"] != null) && (row["EducationClasses"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.EducationClasses = row["EducationClasses"].ToString();
                }
                if (((row["EducationNumber"] != null) && (row["EducationNumber"] != DBNull.Value)) && (row["EducationNumber"].ToString() != ""))
                {
                    recordsEducationActivitiesModel.EducationNumber = new decimal?(decimal.Parse(row["EducationNumber"].ToString()));
                }
                if ((row["DataFileNumber"] != null) && (row["DataFileNumber"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.DataFileNumber = row["DataFileNumber"].ToString();
                }
                if ((row["ActivityContent"] != null) && (row["ActivityContent"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.ActivityContent = row["ActivityContent"].ToString();
                }
                if ((row["ActivityType"] != null) && (row["ActivityType"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.ActivityType = row["ActivityType"].ToString();
                }
                if ((row["ResponsiblePerson"] != null) && (row["ResponsiblePerson"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.ResponsiblePerson = row["ResponsiblePerson"].ToString();
                }
                if ((row["InformationPerson"] != null) && (row["InformationPerson"] != DBNull.Value))
                {
                    recordsEducationActivitiesModel.InformationPerson = row["InformationPerson"].ToString();
                }
                if (((row["FillformTime"] != null) && (row["FillformTime"] != DBNull.Value)) && (row["FillformTime"].ToString() != ""))
                {
                    recordsEducationActivitiesModel.FillformTime = new DateTime?(DateTime.Parse(row["FillformTime"].ToString()));
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    recordsEducationActivitiesModel.CreatedBy = decimal.Parse(row["CreatedBy"].ToString());
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    recordsEducationActivitiesModel.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    recordsEducationActivitiesModel.LastUpdateBy = decimal.Parse(row["LastUpdateBy"].ToString());
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    recordsEducationActivitiesModel.LastUpdateDate = DateTime.Parse(row["LastUpdateDate"].ToString());
                }
            }
            return recordsEducationActivitiesModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordseducationactivities ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordseducationactivities ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordseducationactivities");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,ActivityDate,ActivityAddress,ActivityType,ActivityTheme,Planner,EducationClasses,EducationNumber,DataFileNumber,ActivityContent,Activity,ActivityType,ResponsiblePerson,InformationPerson,FillformTime,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate ");
            builder.Append(" FROM tbl_recordseducationactivities ");
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
            builder.Append(")AS Row, T.*  from tbl_recordseducationactivities T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_recordseducationactivities");
        }

        public RecordsEducationActivitiesModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,ActivityDate,ActivityAddress,ActivityType,ActivityTheme,Planner,EducationClasses,EducationNumber,DataFileNumber,ActivityContent,Activity,ActivityType,ResponsiblePerson,InformationPerson,FillformTime,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate from tbl_recordseducationactivities ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsEducationActivitiesModel();
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
            builder.Append("select count(1) FROM tbl_recordseducationactivities ");
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

        public bool Update(RecordsEducationActivitiesModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordseducationactivities set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("ActivityDate=@ActivityDate,");
            builder.Append("ActivityAddress=@ActivityAddress,");
            builder.Append("ActivityType=@ActivityType,");
            builder.Append("ActivityTheme=@ActivityTheme,");
            builder.Append("Planner=@Planner,");
            builder.Append("EducationClasses=@EducationClasses,");
            builder.Append("EducationNumber=@EducationNumber,");
            builder.Append("DataFileNumber=@DataFileNumber,");
            builder.Append("ActivityContent=@ActivityContent,");
            builder.Append("Activity=@Activity,");
            builder.Append("ActivityType=@ActivityType,");
            builder.Append("ResponsiblePerson=@ResponsiblePerson,");
            builder.Append("InformationPerson=@InformationPerson,");
            builder.Append("FillformTime=@FillformTime,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@ActivityDate", MySqlDbType.Date), 
                new MySqlParameter("@ActivityAddress", MySqlDbType.String, 200),
                new MySqlParameter("@ActivityType", MySqlDbType.String, 100), 
                new MySqlParameter("@ActivityTheme", MySqlDbType.String, 100), 
                new MySqlParameter("@Planner", MySqlDbType.String, 30),
                new MySqlParameter("@EducationClasses", MySqlDbType.String, 50),
                new MySqlParameter("@EducationNumber", MySqlDbType.Decimal), 
                new MySqlParameter("@DataFileNumber", MySqlDbType.String, 200),
                new MySqlParameter("@ActivityContent", MySqlDbType.String, 200), 
                new MySqlParameter("@Activity", MySqlDbType.String), 
                new MySqlParameter("@ActivityType", MySqlDbType.String, 20),
                new MySqlParameter("@ResponsiblePerson", MySqlDbType.String, 20),
                new MySqlParameter("@InformationPerson", MySqlDbType.String, 20), 
                new MySqlParameter("@FillformTime", MySqlDbType.Date), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ActivityDate;
            cmdParms[4].Value = model.ActivityAddress;
            cmdParms[5].Value = model.ActivityType;
            cmdParms[6].Value = model.ActivityTheme;
            cmdParms[7].Value = model.Planner;
            cmdParms[8].Value = model.EducationClasses;
            cmdParms[9].Value = model.EducationNumber;
            cmdParms[10].Value = model.DataFileNumber;
            cmdParms[11].Value = model.ActivityContent;
            cmdParms[12].Value = model.Activity;
            cmdParms[13].Value = model.ActivityType;
            cmdParms[14].Value = model.ResponsiblePerson;
            cmdParms[15].Value = model.InformationPerson;
            cmdParms[16].Value = model.FillformTime;
            cmdParms[17].Value = model.CreatedBy;
            cmdParms[18].Value = model.CreatedDate;
            cmdParms[19].Value = model.LastUpdateBy;
            cmdParms[20].Value = model.LastUpdateDate;
            cmdParms[21].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsEducationActivitiesModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordseducationactivities set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("ActivityDate=@ActivityDate,");
            builder.Append("ActivityAddress=@ActivityAddress,");
            builder.Append("ActivityType=@ActivityType,");
            builder.Append("ActivityTheme=@ActivityTheme,");
            builder.Append("Planner=@Planner,");
            builder.Append("EducationClasses=@EducationClasses,");
            builder.Append("EducationNumber=@EducationNumber,");
            builder.Append("DataFileNumber=@DataFileNumber,");
            builder.Append("ActivityContent=@ActivityContent,");
            builder.Append("Activity=@Activity,");
            builder.Append("ActivityType=@ActivityType,");
            builder.Append("ResponsiblePerson=@ResponsiblePerson,");
            builder.Append("InformationPerson=@InformationPerson,");
            builder.Append("FillformTime=@FillformTime,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@ActivityDate", MySqlDbType.Date), 
                new MySqlParameter("@ActivityAddress", MySqlDbType.String, 200),
                new MySqlParameter("@ActivityType", MySqlDbType.String, 100), 
                new MySqlParameter("@ActivityTheme", MySqlDbType.String, 100), 
                new MySqlParameter("@Planner", MySqlDbType.String, 30),
                new MySqlParameter("@EducationClasses", MySqlDbType.String, 50),
                new MySqlParameter("@EducationNumber", MySqlDbType.Decimal), 
                new MySqlParameter("@DataFileNumber", MySqlDbType.String, 200),
                new MySqlParameter("@ActivityContent", MySqlDbType.String, 200), 
                new MySqlParameter("@Activity", MySqlDbType.String), 
                new MySqlParameter("@ActivityType", MySqlDbType.String, 20),
                new MySqlParameter("@ResponsiblePerson", MySqlDbType.String, 20),
                new MySqlParameter("@InformationPerson", MySqlDbType.String, 20), 
                new MySqlParameter("@FillformTime", MySqlDbType.Date), 
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ActivityDate;
            cmdParms[4].Value = model.ActivityAddress;
            cmdParms[5].Value = model.ActivityType;
            cmdParms[6].Value = model.ActivityTheme;
            cmdParms[7].Value = model.Planner;
            cmdParms[8].Value = model.EducationClasses;
            cmdParms[9].Value = model.EducationNumber;
            cmdParms[10].Value = model.DataFileNumber;
            cmdParms[11].Value = model.ActivityContent;
            cmdParms[12].Value = model.Activity;
            cmdParms[13].Value = model.ActivityType;
            cmdParms[14].Value = model.ResponsiblePerson;
            cmdParms[15].Value = model.InformationPerson;
            cmdParms[16].Value = model.FillformTime;
            cmdParms[17].Value = model.CreatedBy;
            cmdParms[18].Value = model.CreatedDate;
            cmdParms[19].Value = model.LastUpdateBy;
            cmdParms[20].Value = model.LastUpdateDate;
            //cmdParms[21].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

