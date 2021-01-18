
namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ConsulationBaseInfoDAL
    {
        public int Add(ConsulationBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_CONSULTATION_RECORD(");
            builder.Append("IDCardNo,Reason,View,ResponsibilityDoctor,ConsultationDate,UpdateUnitName,UpdatePerson,UpdateDate)");
            builder.Append("values (");
            builder.Append("@IDCardNo,@Reason,@View,@ResponsibilityDoctor,@ConsultationDate,@UpdateUnitName,@UpdatePerson,@UpdateDate)");
            builder.Append(";select @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String,18), 
                new MySqlParameter("@Reason", MySqlDbType.String, 100),  
                new MySqlParameter("@View", MySqlDbType.String, 100),
                new MySqlParameter("@ResponsibilityDoctor", MySqlDbType.String,100), 
                new MySqlParameter("@ConsultationDate", MySqlDbType.Date), 
                new MySqlParameter("@UpdateUnitName", MySqlDbType.String,100), 
                new MySqlParameter("@UpdatePerson", MySqlDbType.String,100), 
                new MySqlParameter("@UpdateDate", MySqlDbType.Date) 
             };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Reason;
            cmdParms[2].Value = model.View;
            cmdParms[3].Value = model.ResponsibilityDoctor;
            cmdParms[4].Value = model.ConsultationDate;
            cmdParms[5].Value = model.UpdateUnitName;
            cmdParms[6].Value = model.UpdatePerson;
            cmdParms[7].Value = model.UpdateDate;   

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public int AddServer(ConsulationBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_CONSULTATION_RECORD(");
            builder.Append("IDCardNo,Reason,View,ResponsibilityDoctor,ConsultationDate,UpdateUnitName,UpdatePerson,UpdateDate)");
            builder.Append("values (");
            builder.Append("@IDCardNo,@Reason,@View,@ResponsibilityDoctor,@ConsultationDate,@UpdateUnitName,@UpdatePerson,@UpdateDate)");
            builder.Append(";select @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String,18), 
                new MySqlParameter("@Reason", MySqlDbType.String, 100),  
                new MySqlParameter("@View", MySqlDbType.String, 100),
                new MySqlParameter("@ResponsibilityDoctor", MySqlDbType.String,100), 
                new MySqlParameter("@ConsultationDate", MySqlDbType.Date), 
                new MySqlParameter("@UpdateUnitName", MySqlDbType.String,100), 
                new MySqlParameter("@UpdatePerson", MySqlDbType.String,100), 
                new MySqlParameter("@UpdateDate", MySqlDbType.Date) 
             };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Reason;
            cmdParms[2].Value = model.View;
            cmdParms[3].Value = model.ResponsibilityDoctor;
            cmdParms[4].Value = model.ConsultationDate;
            cmdParms[5].Value = model.UpdateUnitName;
            cmdParms[6].Value = model.UpdatePerson;
            cmdParms[7].Value = model.UpdateDate;   

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
            builder.Append("delete from ARCHIVE_CONSULTATION_RECORD ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT COUNT(T.IDCardNo) AS IDCount");
            builder.Append(" FROM 	ARCHIVE_BASEINFO T INNER JOIN  ARCHIVE_CONSULTATION_RECORD C ON T.IDCardNo = C.IDCardNo ");
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  IDCardNo,Reason,View,ResponsibilityDoctor,ConsultationDate,UpdateUnitName,UpdatePerson,UpdateDate  ");
            builder.Append(" FROM ARCHIVE_CONSULTATION_RECORD ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select C.IDCardNo,C.ID,T.RecordID,T.CustomerName,T.Nation,T.Sex,T.Birthday,T.Phone,");
            builder.Append("T.Doctor,T.Address,T.HouseHoldAddress,T.Minority,");
            builder.Append("(case T.CreateDate when null then null when '' then null else T.CreateDate end)CreateDate, ");
            builder.Append("(case C.ConsultationDate when null then null when '' then null else C.ConsultationDate end) as CheckDate, ");
            builder.Append("T.PopulationType,T.FamilyIDCardNo,T.HouseRelation,T.HouseRealOther,T.TownName,");
            builder.Append("T.VillageName,T.CreateUnitName,T.CreateMenName ");
            builder.Append(" from ARCHIVE_CONSULTATION_RECORD C inner join ARCHIVE_BASEINFO T on T.IDCardNo = C.IDCardNo ");
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

        public ConsulationBaseInfoModel DataRowToModel(DataRow row)
        {
            ConsulationBaseInfoModel ConsulationModel = new ConsulationBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    ConsulationModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["Sex"] != null) && (row["Sex"] != DBNull.Value))
                {
                    ConsulationModel.Sex = row["Sex"].ToString();
                }
                if (((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value)))
                {
                    ConsulationModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["CustomerName"] != null) && (row["CustomerName"] != DBNull.Value))
                {
                    ConsulationModel.CustomerName = row["CustomerName"].ToString();
                }
                if ((row["Address"] != null) && (row["Address"] != DBNull.Value))
                {
                    ConsulationModel.Address = row["Address"].ToString();
                }
                if ((row["Reason"] != null) && (row["Reason"] != DBNull.Value))
                {
                    ConsulationModel.Reason = row["Reason"].ToString();
                }
                if ((row["View"] != null) && (row["View"] != DBNull.Value))
                {
                    ConsulationModel.View = row["View"].ToString();
                }
                if ((row["CreateUnitName"] != null) && (row["CreateUnitName"] != DBNull.Value))
                {
                    ConsulationModel.CreateUnitName = row["CreateUnitName"].ToString();
                }
                if ((row["ResponsibilityDoctor"] != null) && (row["ResponsibilityDoctor"] != DBNull.Value))
                {
                    ConsulationModel.ResponsibilityDoctor = row["ResponsibilityDoctor"].ToString();
                }
                if ((row["CreateMenName"] != null) && (row["CreateMenName"] != DBNull.Value))
                {
                    ConsulationModel.CreateMenName = row["CreateMenName"].ToString();
                }
                if (((row["ConsultationDate"] != null) && (row["ConsultationDate"] != DBNull.Value)) && (row["ConsultationDate"].ToString() != ""))
                {
                    ConsulationModel.ConsultationDate = DateTime.Parse(row["ConsultationDate"].ToString());
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    ConsulationModel.CreateTime = DateTime.Parse(row["CreateDate"].ToString());
                }
            }

            return ConsulationModel;
        }

        public ConsulationBaseInfoModel GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select T.ID, T.IDCardNo,C.CustomerName,T.Reason,T.View,T.ResponsibilityDoctor,T.ConsultationDate,C.CreateMenName,C.CreateDate ,C.Sex,C.Address,C.CreateUnitName ");
            builder.Append("from ARCHIVE_CONSULTATION_RECORD T LEFT JOIN ARCHIVE_BASEINFO C ON T.IDCardNo=C.IDCardNo ");
            builder.Append("where T.ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32,8) };
            cmdParms[0].Value = ID;
            new RecordsBaseInfoModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public ConsulationBaseInfoModel GetMaxModel(string IDCard)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select T.ID,T.IDCardNo,C.CustomerName,T.Reason,T.View,T.ResponsibilityDoctor,T.ConsultationDate,C.CreateMenName,C.CreateDate ,C.Sex,C.Address,C.CreateUnitName ");
            builder.Append("from ARCHIVE_CONSULTATION_RECORD T LEFT JOIN ARCHIVE_BASEINFO C ON T.IDCardNo=C.IDCardNo ");
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
        public bool Update(ConsulationBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_CONSULTATION_RECORD set ");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Reason=@Reason,");
            builder.Append("View=@View,");
            builder.Append("ResponsibilityDoctor=@ResponsibilityDoctor,");
            builder.Append("ConsultationDate=@ConsultationDate,");
            builder.Append("UpdateUnitName=@UpdateUnitName,");
            builder.Append("UpdatePerson=@UpdatePerson,");
            builder.Append("UpdateDate=@UpdateDate");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 18), 
                new MySqlParameter("@Reason", MySqlDbType.String, 1000),
                new MySqlParameter("@View", MySqlDbType.String, 1000), 
                new MySqlParameter("@ResponsibilityDoctor", MySqlDbType.String, 100), 
                new MySqlParameter("@ConsultationDate", MySqlDbType.DateTime),
                new MySqlParameter("@UpdateUnitName", MySqlDbType.String, 100),
                new MySqlParameter("@UpdatePerson", MySqlDbType.String, 100),
                new MySqlParameter("@UpdateDate", MySqlDbType.Date),
                new MySqlParameter("@ID", MySqlDbType.Int32,8)
                
             };
            cmdParms[0].Value = model.IDCardNo;
            cmdParms[1].Value = model.Reason;
            cmdParms[2].Value = model.View;
            cmdParms[3].Value = model.ResponsibilityDoctor;
            cmdParms[4].Value = model.ConsultationDate;
            cmdParms[5].Value = model.UpdateUnitName;
            cmdParms[6].Value = model.UpdatePerson;
            cmdParms[7].Value = model.UpdateDate;
            cmdParms[8].Value = model.ID;       
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
