namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ReceiveTreatBaseInfoDAL
    {
       public int Add(ReceiveTreatBaseInfoModel model)
       {

           StringBuilder builder = new StringBuilder();
           builder.Append("insert into ARCHIVE_RECEPTION_RECORD(");
           builder.Append("IDCardNo,Doctor,SubjectiveData,ObjectiveData,Assessment,ManagePlane,ReceiveDate,UpdateUnitName,UpdatePerson,UpdateDate)");
           builder.Append("values (");
           builder.Append("@IDCardNo,@Doctor,@SubjectiveData,@ObjectiveData,@Assessment,@ManagePlane,@ReceiveDate,@UpdateUnitName,@UpdatePerson,@UpdateDate)");
           builder.Append(";select @@IDENTITY");
    
           MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String,18), 
                new MySqlParameter("@Doctor", MySqlDbType.String, 100), 
                new MySqlParameter("@SubjectiveData", MySqlDbType.String, 1000),
                new MySqlParameter("@ObjectiveData", MySqlDbType.String, 1000),
                new MySqlParameter("@Assessment", MySqlDbType.String, 1000), 
                new MySqlParameter("@ManagePlane", MySqlDbType.String,1000), 
                new MySqlParameter("@ReceiveDate", MySqlDbType.Date), 
                new MySqlParameter("@ConsultationDate", MySqlDbType.Date), 
                new MySqlParameter("@UpdateUnitName", MySqlDbType.String,100), 
                new MySqlParameter("@UpdatePerson", MySqlDbType.String,100), 
                new MySqlParameter("@UpdateDate", MySqlDbType.Date) 
               
             };
           cmdParms[0].Value = model.IDCardNo;
           cmdParms[1].Value = model.Doctor;
           cmdParms[2].Value = model.SubjectiveData; 
           cmdParms[3].Value = model.ObjectiveData;  
           cmdParms[4].Value = model.Assessment;     
           cmdParms[5].Value = model.ManagePlane;    
           cmdParms[6].Value = model.ReceiveDate;  
           cmdParms[7].Value = model.UpdateUnitName;
           cmdParms[8].Value = model.UpdatePerson;
           cmdParms[9].Value = model.UpdateDate;

           object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
           if (single == null)
           {
               return 0;
           }
           return Convert.ToInt32(single);
       }
        public int AddServer(ReceiveTreatBaseInfoModel model)
        {

            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_RECEPTION_RECORD(");
            builder.Append("IDCardNo,Doctor,SubjectiveData,ObjectiveData,Assessment,ManagePlane,ReceiveDate,UpdateUnitName,UpdatePerson,UpdateDate)");
            builder.Append("values (");
            builder.Append("@IDCardNo,@Doctor,@SubjectiveData,@ObjectiveData,@Assessment,@ManagePlane,@ReceiveDate,@UpdateUnitName,@UpdatePerson,@UpdateDate)");
            builder.Append(";select @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String,18), 
                new MySqlParameter("@Doctor", MySqlDbType.String, 100), 
                new MySqlParameter("@SubjectiveData", MySqlDbType.String, 1000),
                new MySqlParameter("@ObjectiveData", MySqlDbType.String, 1000),
                new MySqlParameter("@Assessment", MySqlDbType.String, 1000), 
                new MySqlParameter("@ManagePlane", MySqlDbType.String,1000), 
                new MySqlParameter("@ReceiveDate", MySqlDbType.Date), 
                new MySqlParameter("@ConsultationDate", MySqlDbType.Date), 
                new MySqlParameter("@UpdateUnitName", MySqlDbType.String,100), 
                new MySqlParameter("@UpdatePerson", MySqlDbType.String,100), 
                new MySqlParameter("@UpdateDate", MySqlDbType.Date) 
               
             };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Doctor;
            cmdParms[2].Value = model.SubjectiveData;
            cmdParms[3].Value = model.ObjectiveData;
            cmdParms[4].Value = model.Assessment;
            cmdParms[5].Value = model.ManagePlane;
            cmdParms[6].Value = model.ReceiveDate;
            cmdParms[7].Value = model.UpdateUnitName;
            cmdParms[8].Value = model.UpdatePerson;
            cmdParms[9].Value = model.UpdateDate;

            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_RECEPTION_RECORD ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT COUNT( T.IDCardNo) AS IDCount");
            builder.Append(" FROM 	ARCHIVE_BASEINFO T INNER JOIN  ARCHIVE_RECEPTION_RECORD C ON T.IDCardNo = C.IDCardNo ");
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select C.IDCardNo,C.ID,T.RecordID,T.CustomerName,T.Nation,T.Sex,T.Birthday,T.Phone,");
            builder.Append("T.Doctor,T.Address,T.HouseHoldAddress,T.Minority,");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate, ");
            builder.Append("(case C.ReceiveDate when null then null when '' then null else C.ReceiveDate end) as CheckDate, ");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName ");
            builder.Append(" from ARCHIVE_RECEPTION_RECORD C inner join ARCHIVE_BASEINFO T on T.IDCardNo = C.IDCardNo ");
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
        public ReceiveTreatBaseInfoModel DataRowToModel(DataRow row)
        {
            ReceiveTreatBaseInfoModel receiveModel = new ReceiveTreatBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    receiveModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerName"] != null) && (row["CustomerName"] != DBNull.Value))
                {
                    receiveModel.CustomerName = row["CustomerName"].ToString();
                }
                if ((row["Sex"] != null) && (row["Sex"] != DBNull.Value))
                {
                    receiveModel.Sex = row["Sex"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    receiveModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Address"] != null) && (row["Address"] != DBNull.Value))
                {
                    receiveModel.Address = row["Address"].ToString();
                }
                if ((row["CreateUnitName"] != null) && (row["CreateUnitName"] != DBNull.Value))
                {
                    receiveModel.CreateUnitName = row["CreateUnitName"].ToString();
                }
                if ((row["Doctor"] != null) && (row["Doctor"] != DBNull.Value))
                {
                    receiveModel.Doctor = row["Doctor"].ToString();
                }
                if ((row["SubjectiveData"] != null) && (row["SubjectiveData"] != DBNull.Value))
                {
                    receiveModel.SubjectiveData = row["SubjectiveData"].ToString();
                }
                if ((row["ObjectiveData"] != null) && (row["ObjectiveData"] != DBNull.Value))
                {
                    receiveModel.ObjectiveData = row["ObjectiveData"].ToString();
                }
                if ((row["Assessment"] != null) && (row["Assessment"] != DBNull.Value))
                {
                    receiveModel.Assessment = row["Assessment"].ToString();
                }
                if ((row["ManagePlane"] != null) && (row["ManagePlane"] != DBNull.Value))
                {
                    receiveModel.ManagePlane = row["ManagePlane"].ToString();
                }
                if ((row["CreateMenName"] != null) && (row["CreateMenName"] != DBNull.Value))
                {
                    receiveModel.CreateMenName = row["CreateMenName"].ToString();
                }
                if (((row["ReceiveDate"] != null) && (row["ReceiveDate"] != DBNull.Value)) && (row["ReceiveDate"].ToString() != ""))
                {
                    receiveModel.ReceiveDate = DateTime.Parse(row["ReceiveDate"].ToString());
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    receiveModel.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
            }

            return receiveModel;
        }
        public ReceiveTreatBaseInfoModel GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select T.ID, C.CustomerName,C.IDCardNo,T.Doctor,T.SubjectiveData,T.ObjectiveData,T.Assessment,T.ManagePlane,T.ReceiveDate,C.CreateMenName,C.CreateDate ,C.Sex,C.Address,C.CreateUnitName ");
            builder.Append("from ARCHIVE_RECEPTION_RECORD T LEFT JOIN ARCHIVE_BASEINFO C ON T.IDCardNo=C.IDCardNo ");
            builder.Append("where T.ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 8) };
            cmdParms[0].Value = ID;
            new RecordsBaseInfoModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public bool Update(ReceiveTreatBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_RECEPTION_RECORD set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Doctor=@Doctor,");
            builder.Append("SubjectiveData=@SubjectiveData,");
            builder.Append("ObjectiveData=@ObjectiveData,");
            builder.Append("Assessment=@Assessment,");
            builder.Append("ManagePlane=@ManagePlane,");
            builder.Append("ReceiveDate=@ReceiveDate,");
            builder.Append("UpdateUnitName=@UpdateUnitName,");
            builder.Append("UpdatePerson=@UpdatePerson,");
            builder.Append("UpdateDate=@UpdateDate ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String,18), 
                new MySqlParameter("@Doctor", MySqlDbType.String, 100), 
                new MySqlParameter("@SubjectiveData", MySqlDbType.String, 100),
                new MySqlParameter("@ObjectiveData", MySqlDbType.String, 100),
                new MySqlParameter("@Assessment", MySqlDbType.String, 100), 
                new MySqlParameter("@ManagePlane", MySqlDbType.String,100), 
                new MySqlParameter("@ReceiveDate", MySqlDbType.Date), 
                new MySqlParameter("@UpdateUnitName", MySqlDbType.String, 100),
                new MySqlParameter("@UpdatePerson", MySqlDbType.String, 100),
                new MySqlParameter("@UpdateDate", MySqlDbType.Date),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Doctor;
            cmdParms[2].Value = model.SubjectiveData;
            cmdParms[3].Value = model.ObjectiveData;
            cmdParms[4].Value = model.Assessment;
            cmdParms[5].Value = model.ManagePlane;
            cmdParms[6].Value = model.ReceiveDate;
            cmdParms[7].Value = model.UpdateUnitName;
            cmdParms[8].Value = model.UpdatePerson;
            cmdParms[9].Value = model.UpdateDate;
            cmdParms[10].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select IDCardNo,Doctor,SubjectiveData,ObjectiveData,Assessment,ManagePlane,ReceiveDate,UpdateUnitName,UpdatePerson,UpdateDate  ");
            builder.Append(" FROM ARCHIVE_RECEPTION_RECORD ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }
        public ReceiveTreatBaseInfoModel GetMaxModel(string IDCard)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select T.ID, C.CustomerName,C.IDCardNo,T.Doctor,T.SubjectiveData,T.ObjectiveData,T.Assessment,T.ManagePlane,T.ReceiveDate,C.CreateMenName,C.CreateDate ,C.Sex,C.Address,C.CreateUnitName ");
            builder.Append("from ARCHIVE_RECEPTION_RECORD T LEFT JOIN ARCHIVE_BASEINFO C ON T.IDCardNo=C.IDCardNo ");
            builder.Append("where T.IDCardNo=@IDCardNo ");
            builder.Append("order by T.ID DESC LIMIT 0,1");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCard;
            new RecordsBaseInfoModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }

            return null;
        }
    }
}
