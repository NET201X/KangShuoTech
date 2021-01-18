using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicHypertensionBaseInfoDAL
    {
        public int Add(ChronicHypertensionBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_HYPERTENSION_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,ManagementGroup,CaseOurce,TerminateExcuse,");
            builder.Append("FatherHistory,Symptom,HypertensionComplication,Hypotensor,TerminateManagemen,");
            builder.Append("TerminateTime,CreateUnit,CurrentUnit,CreateoBy,CreatedDate,");
            builder.Append("LastUpdateBy,LastUpdateDate,IsDel )");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@ManagementGroup,@CaseOurce,@TerminateExcuse,");
            builder.Append("@FatherHistory,@Symptom,@HypertensionComplication,@Hypotensor,@TerminateManagemen,");
            builder.Append("@TerminateTime,@CreateUnit,@CurrentUnit,@CreateoBy,@CreatedDate,@LastUpdateBy,");
            builder.Append("@LastUpdateDate,@IsDel )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@ManagementGroup", MySqlDbType.String, 1),
                new MySqlParameter("@CaseOurce", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateExcuse", MySqlDbType.String, 1),
                new MySqlParameter("@FatherHistory", MySqlDbType.String, 30),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30), 
                new MySqlParameter("@HypertensionComplication", MySqlDbType.String, 50),
                new MySqlParameter("@Hypotensor", MySqlDbType.String, 1), 
                new MySqlParameter("@TerminateManagemen", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateoBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ManagementGroup;
            cmdParms[4].Value = model.CaseOurce;
            cmdParms[5].Value = model.TerminateExcuse;
            cmdParms[6].Value = model.FatherHistory;
            cmdParms[7].Value = model.Symptom;
            cmdParms[8].Value = model.HypertensionComplication;
            cmdParms[9].Value = model.Hypotensor;
            cmdParms[10].Value = model.TerminateManagemen;
            cmdParms[11].Value = model.TerminateTime;
            cmdParms[12].Value = model.CreateUnit;
            cmdParms[13].Value = model.CurrentUnit;
            cmdParms[14].Value = model.CreateoBy;
            cmdParms[15].Value = model.CreatedDate;
            cmdParms[16].Value = model.LastUpdateBy;
            cmdParms[17].Value = model.LastUpdateDate;
            cmdParms[18].Value = model.IsDel;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(ChronicHypertensionBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_HYPERTENSION_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,ManagementGroup,CaseOurce,TerminateExcuse,");
            builder.Append("FatherHistory,Symptom,HypertensionComplication,Hypotensor,TerminateManagemen,");
            builder.Append("TerminateTime,CreateUnit,CurrentUnit,CreateoBy,CreatedDate,");
            builder.Append("LastUpdateBy,LastUpdateDate,IsDel )");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@ManagementGroup,@CaseOurce,@TerminateExcuse,");
            builder.Append("@FatherHistory,@Symptom,@HypertensionComplication,@Hypotensor,@TerminateManagemen,");
            builder.Append("@TerminateTime,@CreateUnit,@CurrentUnit,@CreateoBy,@CreatedDate,@LastUpdateBy,");
            builder.Append("@LastUpdateDate,@IsDel )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@ManagementGroup", MySqlDbType.String, 1),
                new MySqlParameter("@CaseOurce", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateExcuse", MySqlDbType.String, 1),
                new MySqlParameter("@FatherHistory", MySqlDbType.String, 30),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30), 
                new MySqlParameter("@HypertensionComplication", MySqlDbType.String, 50),
                new MySqlParameter("@Hypotensor", MySqlDbType.String, 1), 
                new MySqlParameter("@TerminateManagemen", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateoBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ManagementGroup;
            cmdParms[4].Value = model.CaseOurce;
            cmdParms[5].Value = model.TerminateExcuse;
            cmdParms[6].Value = model.FatherHistory;
            cmdParms[7].Value = model.Symptom;
            cmdParms[8].Value = model.HypertensionComplication;
            cmdParms[9].Value = model.Hypotensor;
            cmdParms[10].Value = model.TerminateManagemen;
            cmdParms[11].Value = model.TerminateTime;
            cmdParms[12].Value = model.CreateUnit;
            cmdParms[13].Value = model.CurrentUnit;
            cmdParms[14].Value = model.CreateoBy;
            cmdParms[15].Value = model.CreatedDate;
            cmdParms[16].Value = model.LastUpdateBy;
            cmdParms[17].Value = model.LastUpdateDate;
            cmdParms[18].Value = model.IsDel;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public ChronicHypertensionBaseInfoModel DataRowToModel(DataRow row)
        {
            ChronicHypertensionBaseInfoModel chronicHypertensionBaseInfoModel = new ChronicHypertensionBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicHypertensionBaseInfoModel.ID = int.Parse(row["ID"].ToString());
                }
               
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["ManagementGroup"] != null) && (row["ManagementGroup"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.ManagementGroup = row["ManagementGroup"].ToString();
                }
                if ((row["CaseOurce"] != null) && (row["CaseOurce"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.CaseOurce = row["CaseOurce"].ToString();
                }
                if ((row["TerminateExcuse"] != null) && (row["TerminateExcuse"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.TerminateExcuse = row["TerminateExcuse"].ToString();
                }
                if ((row["FatherHistory"] != null) && (row["FatherHistory"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.FatherHistory = row["FatherHistory"].ToString();
                }
                if ((row["Symptom"] != null) && (row["Symptom"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.Symptom = row["Symptom"].ToString();
                }
                if ((row["HypertensionComplication"] != null) && (row["HypertensionComplication"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.HypertensionComplication = row["HypertensionComplication"].ToString();
                }
                if ((row["Hypotensor"] != null) && (row["Hypotensor"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.Hypotensor = row["Hypotensor"].ToString();
                }
                if ((row["TerminateManagemen"] != null) && (row["TerminateManagemen"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.TerminateManagemen = row["TerminateManagemen"].ToString();
                }
                if (((row["TerminateTime"] != null) && (row["TerminateTime"] != DBNull.Value)) && (row["TerminateTime"].ToString() != ""))
                {
                    chronicHypertensionBaseInfoModel.TerminateTime = new DateTime?(DateTime.Parse(row["TerminateTime"].ToString()));
                }
                if (((row["CreateUnit"] != null) && (row["CreateUnit"] != DBNull.Value)) && (row["CreateUnit"].ToString() != ""))
                {
                    chronicHypertensionBaseInfoModel.CreateUnit = new decimal?(decimal.Parse(row["CreateUnit"].ToString()));
                }
                if (((row["CurrentUnit"] != null) && (row["CurrentUnit"] != DBNull.Value)) && (row["CurrentUnit"].ToString() != ""))
                {
                    chronicHypertensionBaseInfoModel.CurrentUnit = new decimal?(decimal.Parse(row["CurrentUnit"].ToString()));
                }
                if (((row["CreateoBy"] != null) && (row["CreateoBy"] != DBNull.Value)) && (row["CreateoBy"].ToString() != ""))
                {
                    chronicHypertensionBaseInfoModel.CreateoBy = new decimal?(decimal.Parse(row["CreateoBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    chronicHypertensionBaseInfoModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    chronicHypertensionBaseInfoModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    chronicHypertensionBaseInfoModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    chronicHypertensionBaseInfoModel.IsDel = row["IsDel"].ToString();
                }
            }
            return chronicHypertensionBaseInfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_HYPERTENSION_BASEINFO ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
      
        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_HYPERTENSION_BASEINFO ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CD_HYPERTENSION_BASEINFO");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public bool ExistIDCardNo(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CD_HYPERTENSION_BASEINFO");
            builder.Append(" where IDCardNo =@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
            
            };
            cmdParms[0].Value = IDCardNo;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,ManagementGroup,");
            builder.Append("CaseOurce,TerminateExcuse,FatherHistory,Symptom,HypertensionComplication,");
            builder.Append("Hypotensor,TerminateManagemen,TerminateTime,CreateUnit,CurrentUnit,");
            builder.Append("CreateoBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel ");
            builder.Append(" FROM CD_HYPERTENSION_BASEINFO ");
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
                builder.Append("order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from CD_HYPERTENSION_BASEINFO T ");
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
            return MySQLHelper.GetMaxID("ID", "CD_HYPERTENSION_BASEINFO");
        }
        public ChronicHypertensionBaseInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,ManagementGroup,CaseOurce,TerminateExcuse,");
            builder.Append("FatherHistory,Symptom,HypertensionComplication,Hypotensor,TerminateManagemen,");
            builder.Append("TerminateTime,CreateUnit,CurrentUnit,CreateoBy,CreatedDate,");
            builder.Append("LastUpdateBy,LastUpdateDate,IsDel ");
            builder.Append(" from CD_HYPERTENSION_BASEINFO ");
            builder.Append(" where IDCardNo=@IDCardNo order by ID desc limit 0,1  ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String, 21) };
            cmdParms[0].Value = IDCardNo;
            new ChronicHypertensionBaseInfoModel();
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
            builder.Append("select count(1) FROM CD_HYPERTENSION_BASEINFO ");
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

        public bool Update(ChronicHypertensionBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_HYPERTENSION_BASEINFO set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("ManagementGroup=@ManagementGroup,");
            builder.Append("CaseOurce=@CaseOurce,");
            builder.Append("TerminateExcuse=@TerminateExcuse,");
            builder.Append("FatherHistory=@FatherHistory,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("HypertensionComplication=@HypertensionComplication,");
            builder.Append("Hypotensor=@Hypotensor,");
            builder.Append("TerminateManagemen=@TerminateManagemen,");
            builder.Append("TerminateTime=@TerminateTime,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("CreateoBy=@CreateoBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@ManagementGroup", MySqlDbType.String, 1),
                new MySqlParameter("@CaseOurce", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateExcuse", MySqlDbType.String, 1),
                new MySqlParameter("@FatherHistory", MySqlDbType.String, 30),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30), 
                new MySqlParameter("@HypertensionComplication", MySqlDbType.String, 50),
                new MySqlParameter("@Hypotensor", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateManagemen", MySqlDbType.String, 1), 
                new MySqlParameter("@TerminateTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreateoBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1), 
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ManagementGroup;
            cmdParms[4].Value = model.CaseOurce;
            cmdParms[5].Value = model.TerminateExcuse;
            cmdParms[6].Value = model.FatherHistory;
            cmdParms[7].Value = model.Symptom;
            cmdParms[8].Value = model.HypertensionComplication;
            cmdParms[9].Value = model.Hypotensor;
            cmdParms[10].Value = model.TerminateManagemen;
            cmdParms[11].Value = model.TerminateTime;
            cmdParms[12].Value = model.CreateUnit;
            cmdParms[13].Value = model.CurrentUnit;
            cmdParms[14].Value = model.CreateoBy;
            cmdParms[15].Value = model.CreatedDate;
            cmdParms[16].Value = model.LastUpdateBy;
            cmdParms[17].Value = model.LastUpdateDate;
            cmdParms[18].Value = model.IsDel;
            cmdParms[19].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(ChronicHypertensionBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_HYPERTENSION_BASEINFO set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("ManagementGroup=@ManagementGroup,");
            builder.Append("CaseOurce=@CaseOurce,");
            builder.Append("TerminateExcuse=@TerminateExcuse,");
            builder.Append("FatherHistory=@FatherHistory,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("HypertensionComplication=@HypertensionComplication,");
            builder.Append("Hypotensor=@Hypotensor,");
            builder.Append("TerminateManagemen=@TerminateManagemen,");
            builder.Append("TerminateTime=@TerminateTime,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("CreateoBy=@CreateoBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@ManagementGroup", MySqlDbType.String, 1),
                new MySqlParameter("@CaseOurce", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateExcuse", MySqlDbType.String, 1),
                new MySqlParameter("@FatherHistory", MySqlDbType.String, 30),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30), 
                new MySqlParameter("@HypertensionComplication", MySqlDbType.String, 50),
                new MySqlParameter("@Hypotensor", MySqlDbType.String, 1),
                new MySqlParameter("@TerminateManagemen", MySqlDbType.String, 1), 
                new MySqlParameter("@TerminateTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreateoBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1)
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ManagementGroup;
            cmdParms[4].Value = model.CaseOurce;
            cmdParms[5].Value = model.TerminateExcuse;
            cmdParms[6].Value = model.FatherHistory;
            cmdParms[7].Value = model.Symptom;
            cmdParms[8].Value = model.HypertensionComplication;
            cmdParms[9].Value = model.Hypotensor;
            cmdParms[10].Value = model.TerminateManagemen;
            cmdParms[11].Value = model.TerminateTime;
            cmdParms[12].Value = model.CreateUnit;
            cmdParms[13].Value = model.CurrentUnit;
            cmdParms[14].Value = model.CreateoBy;
            cmdParms[15].Value = model.CreatedDate;
            cmdParms[16].Value = model.LastUpdateBy;
            cmdParms[17].Value = model.LastUpdateDate;
            cmdParms[18].Value = model.IsDel;
            //cmdParms[20].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

