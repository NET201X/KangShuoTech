namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsCardDAL
    {
        public int Add(RecordsCardModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_CARD(");
            builder.Append("CustomerID,RecordID,IDCardNo,Name,Sex,Birthday,BloodType,RH,ChronicDiseases,ChronicDiseasesOther,AllergicHistory,HomeAddr,HomePhone,UrgentName,UrgentPhone,OrgName,OrgPhone,Doctor,DoctorPhone,Other)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Name,@Sex,@Birthday,@BloodType,@RH,@ChronicDiseases,@ChronicDiseasesOther,@AllergicHistory,@HomeAddr,@HomePhone,@UrgentName,@UrgentPhone,@OrgName,@OrgPhone,@Doctor,@DoctorPhone,@Other)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@Sex", MySqlDbType.String, 1),
                new MySqlParameter("@Birthday", MySqlDbType.Date), 
                new MySqlParameter("@BloodType", MySqlDbType.String, 1), 
                new MySqlParameter("@RH", MySqlDbType.String, 1), 
                new MySqlParameter("@ChronicDiseases", MySqlDbType.String, 50),
                new MySqlParameter("@ChronicDiseasesOther", MySqlDbType.String, 200),
                new MySqlParameter("@AllergicHistory", MySqlDbType.String, 100), 
                new MySqlParameter("@HomeAddr", MySqlDbType.String, 50),
                new MySqlParameter("@HomePhone", MySqlDbType.String, 30), 
                new MySqlParameter("@UrgentName", MySqlDbType.String, 30),
                new MySqlParameter("@UrgentPhone", MySqlDbType.String, 15),
                new MySqlParameter("@OrgName", MySqlDbType.String, 50), 
                new MySqlParameter("@OrgPhone", MySqlDbType.String, 15),
                new MySqlParameter("@Doctor", MySqlDbType.String, 30), 
                new MySqlParameter("@DoctorPhone", MySqlDbType.String, 15),
                new MySqlParameter("@Other", MySqlDbType.String, 200)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.Sex;
            cmdParms[5].Value = model.Birthday;
            cmdParms[6].Value = model.BloodType;
            cmdParms[7].Value = model.RH;
            cmdParms[8].Value = model.ChronicDiseases;
            cmdParms[9].Value = model.ChronicDiseasesOther;
            cmdParms[10].Value = model.AllergicHistory;
            cmdParms[11].Value = model.HomeAddr;
            cmdParms[12].Value = model.HomePhone;
            cmdParms[13].Value = model.UrgentName;
            cmdParms[14].Value = model.UrgentPhone;
            cmdParms[15].Value = model.OrgName;
            cmdParms[16].Value = model.OrgPhone;
            cmdParms[17].Value = model.Doctor;
            cmdParms[18].Value = model.DoctorPhone;
            cmdParms[19].Value = model.Other;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsCardModel DataRowToModel(DataRow row)
        {
            RecordsCardModel recordsCardModel = new RecordsCardModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsCardModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    recordsCardModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    recordsCardModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsCardModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    recordsCardModel.Name = row["Name"].ToString();
                }
                if ((row["Sex"] != null) && (row["Sex"] != DBNull.Value))
                {
                    recordsCardModel.Sex = row["Sex"].ToString();
                }
                if (((row["Birthday"] != null) && (row["Birthday"] != DBNull.Value)) && (row["Birthday"].ToString() != ""))
                {
                    recordsCardModel.Birthday = new DateTime?(DateTime.Parse(row["Birthday"].ToString()));
                }
                if ((row["BloodType"] != null) && (row["BloodType"] != DBNull.Value))
                {
                    recordsCardModel.BloodType = row["BloodType"].ToString();
                }
                if ((row["RH"] != null) && (row["RH"] != DBNull.Value))
                {
                    recordsCardModel.RH = row["RH"].ToString();
                }
                if ((row["ChronicDiseases"] != null) && (row["ChronicDiseases"] != DBNull.Value))
                {
                    recordsCardModel.ChronicDiseases = row["ChronicDiseases"].ToString();
                }
                if ((row["ChronicDiseasesOther"] != null) && (row["ChronicDiseasesOther"] != DBNull.Value))
                {
                    recordsCardModel.ChronicDiseasesOther = row["ChronicDiseasesOther"].ToString();
                }
                if ((row["AllergicHistory"] != null) && (row["AllergicHistory"] != DBNull.Value))
                {
                    recordsCardModel.AllergicHistory = row["AllergicHistory"].ToString();
                }
                if ((row["HomeAddr"] != null) && (row["HomeAddr"] != DBNull.Value))
                {
                    recordsCardModel.HomeAddr = row["HomeAddr"].ToString();
                }
                if ((row["HomePhone"] != null) && (row["HomePhone"] != DBNull.Value))
                {
                    recordsCardModel.HomePhone = row["HomePhone"].ToString();
                }
                if ((row["UrgentName"] != null) && (row["UrgentName"] != DBNull.Value))
                {
                    recordsCardModel.UrgentName = row["UrgentName"].ToString();
                }
                if ((row["UrgentPhone"] != null) && (row["UrgentPhone"] != DBNull.Value))
                {
                    recordsCardModel.UrgentPhone = row["UrgentPhone"].ToString();
                }
                if ((row["OrgName"] != null) && (row["OrgName"] != DBNull.Value))
                {
                    recordsCardModel.OrgName = row["OrgName"].ToString();
                }
                if ((row["OrgPhone"] != null) && (row["OrgPhone"] != DBNull.Value))
                {
                    recordsCardModel.OrgPhone = row["OrgPhone"].ToString();
                }
                if ((row["Doctor"] != null) && (row["Doctor"] != DBNull.Value))
                {
                    recordsCardModel.Doctor = row["Doctor"].ToString();
                }
                if ((row["DoctorPhone"] != null) && (row["DoctorPhone"] != DBNull.Value))
                {
                    recordsCardModel.DoctorPhone = row["DoctorPhone"].ToString();
                }
                if ((row["Other"] != null) && (row["Other"] != DBNull.Value))
                {
                    recordsCardModel.Other = row["Other"].ToString();
                }
            }
            return recordsCardModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_CARD ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_CARD ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_CARD");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,Name,Sex,Birthday,BloodType,RH,ChronicDiseases,ChronicDiseasesOther,AllergicHistory,HomeAddr,HomePhone,UrgentName,UrgentPhone,OrgName,OrgPhone,Doctor,DoctorPhone,Other ");
            builder.Append(" FROM ARCHIVE_CARD ");
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
            builder.Append(")AS Row, T.*  from ARCHIVE_CARD T ");
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
            return MySQLHelper.GetMaxID("ID", "ARCHIVE_CARD");
        }

        public RecordsCardModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,Name,Sex,Birthday,BloodType,RH,ChronicDiseases,ChronicDiseasesOther,AllergicHistory,HomeAddr,HomePhone,UrgentName,UrgentPhone,OrgName,OrgPhone,Doctor,DoctorPhone,Other from ARCHIVE_CARD ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsCardModel();
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
            builder.Append("select count(1) FROM ARCHIVE_CARD ");
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

        public bool Update(RecordsCardModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_CARD set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Name=@Name,");
            builder.Append("Sex=@Sex,");
            builder.Append("Birthday=@Birthday,");
            builder.Append("BloodType=@BloodType,");
            builder.Append("RH=@RH,");
            builder.Append("ChronicDiseases=@ChronicDiseases,");
            builder.Append("ChronicDiseasesOther=@ChronicDiseasesOther,");
            builder.Append("AllergicHistory=@AllergicHistory,");
            builder.Append("HomeAddr=@HomeAddr,");
            builder.Append("HomePhone=@HomePhone,");
            builder.Append("UrgentName=@UrgentName,");
            builder.Append("UrgentPhone=@UrgentPhone,");
            builder.Append("OrgName=@OrgName,");
            builder.Append("OrgPhone=@OrgPhone,");
            builder.Append("Doctor=@Doctor,");
            builder.Append("DoctorPhone=@DoctorPhone,");
            builder.Append("Other=@Other");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 18), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Name", MySqlDbType.String, 30), 
                new MySqlParameter("@Sex", MySqlDbType.String, 1), 
                new MySqlParameter("@Birthday", MySqlDbType.Date), 
                new MySqlParameter("@BloodType", MySqlDbType.String, 1), 
                new MySqlParameter("@RH", MySqlDbType.String, 1), 
                new MySqlParameter("@ChronicDiseases", MySqlDbType.String, 50),
                new MySqlParameter("@ChronicDiseasesOther", MySqlDbType.String, 200),
                new MySqlParameter("@AllergicHistory", MySqlDbType.String, 100), 
                new MySqlParameter("@HomeAddr", MySqlDbType.String, 50), 
                new MySqlParameter("@HomePhone", MySqlDbType.String, 30), 
                new MySqlParameter("@UrgentName", MySqlDbType.String, 30), 
                new MySqlParameter("@UrgentPhone", MySqlDbType.String, 15), 
                new MySqlParameter("@OrgName", MySqlDbType.String, 50), 
                new MySqlParameter("@OrgPhone", MySqlDbType.String, 15),
                new MySqlParameter("@Doctor", MySqlDbType.String, 30), 
                new MySqlParameter("@DoctorPhone", MySqlDbType.String, 15),
                new MySqlParameter("@Other", MySqlDbType.String, 200), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.Sex;
            cmdParms[5].Value = model.Birthday;
            cmdParms[6].Value = model.BloodType;
            cmdParms[7].Value = model.RH;
            cmdParms[8].Value = model.ChronicDiseases;
            cmdParms[9].Value = model.ChronicDiseasesOther;
            cmdParms[10].Value = model.AllergicHistory;
            cmdParms[11].Value = model.HomeAddr;
            cmdParms[12].Value = model.HomePhone;
            cmdParms[13].Value = model.UrgentName;
            cmdParms[14].Value = model.UrgentPhone;
            cmdParms[15].Value = model.OrgName;
            cmdParms[16].Value = model.OrgPhone;
            cmdParms[17].Value = model.Doctor;
            cmdParms[18].Value = model.DoctorPhone;
            cmdParms[19].Value = model.Other;
            cmdParms[20].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

