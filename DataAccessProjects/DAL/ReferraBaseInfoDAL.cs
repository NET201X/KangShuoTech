namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    public  class ReferraBaseInfoDAL
    {
       public int Add(ReferraBaseInfoModel model )
       {

           StringBuilder builder = new StringBuilder();
           builder.Append("insert into ARCHIVE_REFERRAL(");
           builder.Append("SickPhone,IllnessDate,NewUnitName,NewDepartName,NewDoctor,FirstImpress,");
           builder.Append("TransReason,HistoryIllness,Retrospectively,RefDoctor,RefDoctorPhone,TranseDate,UpdateUnitName,UpdatePerson,UpdateDate,IDCardNo,HomeAddress)");
           builder.Append("values (");
           builder.Append("@SickPhone,@IllnessDate,@NewUnitName,@NewDepartName,@NewDoctor,@FirstImpress,");
           builder.Append("@TransReason,@HistoryIllness,@Retrospectively,@RefDoctor,@RefDoctorPhone,@TranseDate,@UpdateUnitName,@UpdatePerson,@UpdateDate,@IDCardNo,@HomeAddress)");
           builder.Append(";select @@IDENTITY");

           MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@SickPhone", MySqlDbType.String,50),
                new MySqlParameter("@IllnessDate", MySqlDbType.Date), 
                new MySqlParameter("@NewUnitName", MySqlDbType.String, 100),
                new MySqlParameter("@NewDepartName", MySqlDbType.String, 100),
                new MySqlParameter("@NewDoctor", MySqlDbType.String, 100), 
                new MySqlParameter("@FirstImpress", MySqlDbType.String,1000), 
                new MySqlParameter("@TransReason", MySqlDbType.String, 1000),
                new MySqlParameter("@HistoryIllness", MySqlDbType.String,1000), 
                new MySqlParameter("@Retrospectively", MySqlDbType.String,1000), 
                new MySqlParameter("@RefDoctor", MySqlDbType.String,100), 
                new MySqlParameter("@RefDoctorPhone", MySqlDbType.String,50), 
                new MySqlParameter("@TranseDate", MySqlDbType.Date),
                new MySqlParameter("@UpdateUnitName", MySqlDbType.String,100), 
                new MySqlParameter("@UpdatePerson", MySqlDbType.String,100), 
                new MySqlParameter("@UpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.String,18),
                new MySqlParameter("@HomeAddress", MySqlDbType.String,18)
             };

           cmdParms[0].Value = model.SickPhone;
           cmdParms[1].Value = model.IllnessDate;
           cmdParms[2].Value = model.NewUnitName;
           cmdParms[3].Value = model.NewDepartName;
           cmdParms[4].Value = model.NewDoctor;
           cmdParms[5].Value = model.FirstImpress;
           cmdParms[6].Value = model.TransReason;
           cmdParms[7].Value = model.HistoryIllness;
           cmdParms[8].Value = model.Retrospectively;
           cmdParms[9].Value = model.RefDoctor;
           cmdParms[10].Value = model.RefDoctorPhone;
           cmdParms[11].Value = model.TranseDate;
           cmdParms[12].Value = model.UpdateUnitName;
           cmdParms[13].Value = model.UpdatePerson;
           cmdParms[14].Value = model.UpdateDate;
           cmdParms[15].Value = model.IDCardNo;
           cmdParms[16].Value = model.Address; 

           object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
           if (single == null)
           {
               return 0;
           }
           return Convert.ToInt32(single);
       }
       public int AddServer(ReferraBaseInfoModel model)
       {

           StringBuilder builder = new StringBuilder();
           builder.Append("insert into ARCHIVE_REFERRAL(");
           builder.Append("SickPhone,IllnessDate,NewUnitName,NewDepartName,NewDoctor,FirstImpress,");
           builder.Append("TransReason,HistoryIllness,Retrospectively,RefDoctor,RefDoctorPhone,TranseDate,UpdateUnitName,UpdatePerson,UpdateDate,IDCardNo,HomeAddress)");
           builder.Append("values (");
           builder.Append("@SickPhone,@IllnessDate,@NewUnitName,@NewDepartName,@NewDoctor,@FirstImpress,");
           builder.Append("@TransReason,@HistoryIllness,@Retrospectively,@RefDoctor,@RefDoctorPhone,@TranseDate,@UpdateUnitName,@UpdatePerson,@UpdateDate,@IDCardNo,@HomeAddress)");
           builder.Append(";select @@IDENTITY");

           MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@SickPhone", MySqlDbType.String,50),
                new MySqlParameter("@IllnessDate", MySqlDbType.Date), 
                new MySqlParameter("@NewUnitName", MySqlDbType.String, 100),
                new MySqlParameter("@NewDepartName", MySqlDbType.String, 100),
                new MySqlParameter("@NewDoctor", MySqlDbType.String, 100), 
                new MySqlParameter("@FirstImpress", MySqlDbType.String,1000), 
                new MySqlParameter("@TransReason", MySqlDbType.String, 1000),
                new MySqlParameter("@HistoryIllness", MySqlDbType.String,1000), 
                new MySqlParameter("@Retrospectively", MySqlDbType.String,1000), 
                new MySqlParameter("@RefDoctor", MySqlDbType.String,100), 
                new MySqlParameter("@RefDoctorPhone", MySqlDbType.String,50), 
                new MySqlParameter("@TranseDate", MySqlDbType.Date),
                new MySqlParameter("@UpdateUnitName", MySqlDbType.String,100), 
                new MySqlParameter("@UpdatePerson", MySqlDbType.String,100), 
                new MySqlParameter("@UpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.String,18),
                new MySqlParameter("@HomeAddress", MySqlDbType.String,18)
             };

           cmdParms[0].Value = model.SickPhone;
           cmdParms[1].Value = model.IllnessDate;
           cmdParms[2].Value = model.NewUnitName;
           cmdParms[3].Value = model.NewDepartName;
           cmdParms[4].Value = model.NewDoctor;
           cmdParms[5].Value = model.FirstImpress;
           cmdParms[6].Value = model.TransReason;
           cmdParms[7].Value = model.HistoryIllness;
           cmdParms[8].Value = model.Retrospectively;
           cmdParms[9].Value = model.RefDoctor;
           cmdParms[10].Value = model.RefDoctorPhone;
           cmdParms[11].Value = model.TranseDate;
           cmdParms[12].Value = model.UpdateUnitName;
           cmdParms[13].Value = model.UpdatePerson;
           cmdParms[14].Value = model.UpdateDate;
           cmdParms[15].Value = model.IDCardNo;
           cmdParms[16].Value = model.Address; 

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
           builder.Append("delete from ARCHIVE_REFERRAL ");
           builder.Append(" where ID=@ID");
           MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
           cmdParms[0].Value = ID;
           return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
       }
       public int GetRecordCount(string strWhere)
       {
           StringBuilder builder = new StringBuilder();
           builder.Append("SELECT COUNT( T.IDCardNo) AS IDCount");
           builder.Append(" FROM 	ARCHIVE_BASEINFO T INNER JOIN  ARCHIVE_REFERRAL R ON T.IDCardNo = R.IDCardNo ");
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
           builder.Append("select R.ID, R.IDCardNo,T.ID,T.RecordID,T.CustomerName,T.Nation,T.Sex,T.Birthday,T.Phone,");
           builder.Append("T.Doctor,R.HomeAddress,T.HouseHoldAddress,T.Minority,");
           builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate, ");
           builder.Append("(case R.TranseDate when null then null when '' then null else R.TranseDate end) as CheckDate, ");
           builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
           builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName ");
           builder.Append(" from ARCHIVE_REFERRAL R inner join ARCHIVE_BASEINFO T on T.IDCardNo = R.IDCardNo ");
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
       public ReferraBaseInfoModel DataRowToModel(DataRow row)
       {
           ReferraBaseInfoModel referrModel = new ReferraBaseInfoModel();
           if (row != null)
           {
               if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
               {
                   referrModel.ID = int.Parse(row["ID"].ToString());
               }
               if ((row["CustomerName"] != null) && (row["CustomerName"] != DBNull.Value))
               {
                   referrModel.CustomerName = row["CustomerName"].ToString();
               }
               if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
               {
                   referrModel.IDCardNo = row["IDCardNo"].ToString();
               }
               if ((row["Sex"] != null) && (row["Sex"] != DBNull.Value))
               {
                   referrModel.Sex = row["Sex"].ToString();
               }
               if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
               {
                   referrModel.RecordID = row["RecordID"].ToString();
               }
               if ((row["CreateUnitName"] != null) && (row["CreateUnitName"] != DBNull.Value))
               {
                   referrModel.CreateUnitName = row["CreateUnitName"].ToString();
               }
               if ((row["HomeAddress"] != null) && (row["HomeAddress"] != DBNull.Value))
               {
                   referrModel.Address = row["HomeAddress"].ToString();
               }
               if ((row["SickPhone"] != null) && (row["SickPhone"] != DBNull.Value))
               {
                   referrModel.SickPhone = row["SickPhone"].ToString();
               }
               if (((row["IllnessDate"] != null) && (row["IllnessDate"] != DBNull.Value)) &&(row["IllnessDate"].ToString()!=""))
               {
                   referrModel.IllnessDate = DateTime.Parse(row["IllnessDate"].ToString());
               }
               if ((row["NewUnitName"] != null) && (row["NewUnitName"] != DBNull.Value))
               {
                   referrModel.NewUnitName = row["NewUnitName"].ToString();
               }
               if ((row["NewDepartName"] != null) && (row["NewDepartName"] != DBNull.Value))
               {
                   referrModel.NewDepartName = row["NewDepartName"].ToString();
               }
               if ((row["NewDoctor"] != null) && (row["NewDoctor"] != DBNull.Value))
               {
                   referrModel.NewDoctor = row["NewDoctor"].ToString();
               }
               if ((row["CreateMenName"] != null) && (row["CreateMenName"] != DBNull.Value))
               {
                   referrModel.CreateMenName = row["CreateMenName"].ToString();
               }
               if ((row["FirstImpress"] != null) && (row["FirstImpress"] != DBNull.Value))
               {
                   referrModel.FirstImpress = row["FirstImpress"].ToString();
               }
               if ((row["TransReason"] != null) && (row["TransReason"] != DBNull.Value))
               {
                   referrModel.TransReason =row["TransReason"].ToString();
               }
               if ((row["HistoryIllness"] != null) && (row["HistoryIllness"] != DBNull.Value))
               {
                   referrModel.HistoryIllness =row["HistoryIllness"].ToString();
               }
               if ((row["Retrospectively"] != null) && (row["Retrospectively"] != DBNull.Value))
               {
                   referrModel.Retrospectively =row["Retrospectively"].ToString();
               }
               if ((row["RefDoctor"] != null) && (row["RefDoctor"] != DBNull.Value))
               {
                   referrModel.RefDoctor =row["RefDoctor"].ToString();
               }
               if ((row["RefDoctorPhone"] != null) && (row["RefDoctorPhone"] != DBNull.Value))
               {
                   referrModel.RefDoctorPhone =row["RefDoctorPhone"].ToString();
               }
               if ((row["CreateMenName"] != null) && (row["CreateMenName"] != DBNull.Value))
               {
                   referrModel.CreateMenName =row["CreateMenName"].ToString();
               }
               if (((row["TranseDate"] != null) && (row["TranseDate"] != DBNull.Value)) && (row["TranseDate"].ToString() != ""))
               {
                   referrModel.TranseDate = DateTime.Parse(row["TranseDate"].ToString());
               }
               if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
               {
                   referrModel.CreateTime = DateTime.Parse(row["CreateDate"].ToString());
               }
           }
           return referrModel;
       }
       public ReferraBaseInfoModel GetModel(int ID)
       {
           StringBuilder builder = new StringBuilder();
           builder.Append("select T.ID, C.CustomerName,T.SickPhone,T.IllnessDate,T.NewUnitName,T.NewDepartName,T.NewDoctor,T.FirstImpress,T.TransReason,T.HistoryIllness,T.Retrospectively,T.RefDoctor,T.RefDoctorPhone,T.TranseDate,C.CreateUnitName,C.CreateMenName,C.CreateDate,C.Sex,T.HomeAddress,C.RecordID,C.IDCardNo ");
           builder.Append("FROM ARCHIVE_REFERRAL T LEFT JOIN ARCHIVE_BASEINFO C ON T.IDCardNo=C.IDCardNo ");
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
       public bool Update(ReferraBaseInfoModel model)
       {
           StringBuilder builder = new StringBuilder();
           builder.Append("update ARCHIVE_REFERRAL set ");
           builder.Append("SickPhone=@SickPhone ,");
           builder.Append("IllnessDate=@IllnessDate ,");
           builder.Append("NewUnitName=@NewUnitName ,");
           builder.Append("NewDepartName=@NewDepartName ,");
           builder.Append("NewDoctor=@NewDoctor ,");
           builder.Append("FirstImpress=@FirstImpress ,");
           builder.Append("TransReason=@TransReason ,");
           builder.Append("HistoryIllness=@HistoryIllness ,");
           builder.Append("Retrospectively=@Retrospectively ,");
           builder.Append("RefDoctor=@RefDoctor ,");
           builder.Append("RefDoctorPhone=@RefDoctorPhone ,");
           builder.Append("TranseDate=@TranseDate ,");
           builder.Append("UpdateUnitName=@UpdateUnitName,");
           builder.Append("UpdatePerson=@UpdatePerson,");
           builder.Append("UpdateDate=@UpdateDate, ");
           builder.Append("IDCardNo=@IDCardNo, ");
           builder.Append("HomeAddress=@HomeAddress ");
           builder.Append(" where ID=@ID");
           MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@SickPhone", MySqlDbType.String,50),
                new MySqlParameter("@IllnessDate", MySqlDbType.Date), 
                new MySqlParameter("@NewUnitName", MySqlDbType.String, 100),
                new MySqlParameter("@NewDepartName", MySqlDbType.String, 100),
                new MySqlParameter("@NewDoctor", MySqlDbType.String, 100), 
                new MySqlParameter("@FirstImpress", MySqlDbType.String,200), 
                new MySqlParameter("@TransReason", MySqlDbType.String, 200),
                new MySqlParameter("@HistoryIllness", MySqlDbType.String,200), 
                new MySqlParameter("@Retrospectively", MySqlDbType.String,200), 
                new MySqlParameter("@RefDoctor", MySqlDbType.String,100), 
                new MySqlParameter("@RefDoctorPhone", MySqlDbType.String,50), 
                new MySqlParameter("@TranseDate", MySqlDbType.Date),
                new MySqlParameter("@UpdateUnitName", MySqlDbType.String, 100),
                new MySqlParameter("@UpdatePerson", MySqlDbType.String, 100),
                new MySqlParameter("@UpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 18),
                new MySqlParameter("@HomeAddress", MySqlDbType.String, 100),
                new MySqlParameter("@ID",MySqlDbType.Int32,8)
             };
           cmdParms[0].Value = model.SickPhone;
           cmdParms[1].Value = model.IllnessDate;
           cmdParms[2].Value = model.NewUnitName;
           cmdParms[3].Value = model.NewDepartName;
           cmdParms[4].Value = model.NewDoctor;
           cmdParms[5].Value = model.FirstImpress;
           cmdParms[6].Value = model.TransReason;
           cmdParms[7].Value = model.HistoryIllness;
           cmdParms[8].Value = model.Retrospectively;
           cmdParms[9].Value = model.RefDoctor;
           cmdParms[10].Value = model.RefDoctorPhone;
           cmdParms[11].Value = model.TranseDate;
           cmdParms[12].Value = model.UpdateUnitName;
           cmdParms[13].Value = model.UpdatePerson;
           cmdParms[14].Value = model.UpdateDate;
           cmdParms[15].Value = model.IDCardNo;
           cmdParms[16].Value = model.Address;
           cmdParms[17].Value = model.ID;

           return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
       }
       public DataSet GetList(string strWhere)
       {
           StringBuilder builder = new StringBuilder();
           builder.Append("select SickPhone,IllnessDate,NewUnitName,NewDepartName,NewDoctor,FirstImpress,");
           builder.Append("TransReason,HistoryIllness,Retrospectively,RefDoctor,RefDoctorPhone,TranseDate,UpdateUnitName,UpdatePerson,UpdateDate,IDCardNo,HomeAddress");
           builder.Append(" FROM ARCHIVE_REFERRAL ");
           if (strWhere.Trim() != "")
           {
               builder.Append(" where 1=1 " + strWhere);
           }
           return MySQLHelper.Query(builder.ToString());
       }
       public ReferraBaseInfoModel GetMaxModel(string IDCard)
       {
           StringBuilder builder = new StringBuilder();
           builder.Append("select T.ID, C.CustomerName,T.SickPhone,T.IllnessDate,T.NewUnitName,T.NewDepartName,T.NewDoctor,T.FirstImpress,T.TransReason,T.HistoryIllness,T.Retrospectively,T.RefDoctor,T.RefDoctorPhone,T.TranseDate,C.CreateUnitName,C.CreateMenName,C.CreateDate,C.Sex,T.HomeAddress,C.RecordID,C.IDCardNo ");
           builder.Append("FROM ARCHIVE_REFERRAL T LEFT JOIN ARCHIVE_BASEINFO C ON T.IDCardNo=C.IDCardNo ");
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
