using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicDiabetesBaseInfoDAL
    {
        public int Add(ChronicDiabetesBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_DIABETES_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,ManagementGroup,CaseSource,FamilyHistory,DiabetesType,");
            builder.Append("DiabetesTime,DiabetesWork,Insulin,InsulinWeight,EnalaprilMelete,EndManage,EndWhy,");
            builder.Append("EndTime,HappnTime,CreateUnit,CurrentUnit,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDelete,");
            builder.Append("Symptom,RenalLesionsTime,NeuropathyTime,HeartDiseaseTime,RetinopathyTime,FootLesionsTime,");
            builder.Append("CerebrovascularTime,LesionsOther,LesionsOtherTime,Lesions )");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@ManagementGroup,@CaseSource,@FamilyHistory,@DiabetesType,");
            builder.Append("@DiabetesTime,@DiabetesWork,@Insulin,@InsulinWeight,@EnalaprilMelete,@EndManage,@EndWhy,");
            builder.Append("@EndTime,@HappnTime,@CreateUnit,@CurrentUnit,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate,");
            builder.Append("@IsDelete,@Symptom,@RenalLesionsTime,@NeuropathyTime,@HeartDiseaseTime,@RetinopathyTime,@FootLesionsTime,");
            builder.Append("@CerebrovascularTime,@LesionsOther,@LesionsOtherTime,@Lesions )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@ManagementGroup", MySqlDbType.String, 1),
                new MySqlParameter("@CaseSource", MySqlDbType.String, 1),
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@DiabetesType", MySqlDbType.String, 1),
                new MySqlParameter("@DiabetesTime", MySqlDbType.Date),
                new MySqlParameter("@DiabetesWork", MySqlDbType.String, 100),
                new MySqlParameter("@Insulin", MySqlDbType.String, 1), 
                new MySqlParameter("@InsulinWeight", MySqlDbType.String, 50),
                new MySqlParameter("@EnalaprilMelete", MySqlDbType.String, 100),
                new MySqlParameter("@EndManage", MySqlDbType.String, 1),
                new MySqlParameter("@EndWhy", MySqlDbType.String, 100), 
                new MySqlParameter("@EndTime", MySqlDbType.Date),
                new MySqlParameter("@HappnTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateBy", MySqlDbType.String, 18),
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String, 18), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30),
                new MySqlParameter("@RenalLesionsTime", MySqlDbType.String, 4),
                new MySqlParameter("@NeuropathyTime", MySqlDbType.String, 4),
                new MySqlParameter("@HeartDiseaseTime", MySqlDbType.String, 4),
                new MySqlParameter("@RetinopathyTime", MySqlDbType.String, 4),
                new MySqlParameter("@FootLesionsTime", MySqlDbType.String, 4),
                new MySqlParameter("@CerebrovascularTime", MySqlDbType.String, 4), 
                new MySqlParameter("@LesionsOther", MySqlDbType.String, 100), 
                new MySqlParameter("@LesionsOtherTime", MySqlDbType.String, 4), 
                new MySqlParameter("@Lesions", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ManagementGroup;
            cmdParms[4].Value = model.CaseSource;
            cmdParms[5].Value = model.FamilyHistory;
            cmdParms[6].Value = model.DiabetesType;
            cmdParms[7].Value = model.DiabetesTime;
            cmdParms[8].Value = model.DiabetesWork;
            cmdParms[9].Value = model.Insulin;
            cmdParms[10].Value = model.InsulinWeight;
            cmdParms[11].Value = model.EnalaprilMelete;
            cmdParms[12].Value = model.EndManage;
            cmdParms[13].Value = model.EndWhy;
            cmdParms[14].Value = model.EndTime;
            cmdParms[15].Value = model.HappnTime;
            cmdParms[16].Value = model.CreateUnit;
            cmdParms[17].Value = model.CurrentUnit;
            cmdParms[18].Value = model.CreateBy;
            cmdParms[19].Value = model.CreateDate;
            cmdParms[20].Value = model.LastUpdateBy;
            cmdParms[21].Value = model.LastUpdateDate;
            cmdParms[22].Value = model.IsDelete;
            cmdParms[23].Value = model.Symptom;
            cmdParms[24].Value = model.RenalLesionsTime;
            cmdParms[25].Value = model.NeuropathyTime;
            cmdParms[26].Value = model.HeartDiseaseTime;
            cmdParms[27].Value = model.RetinopathyTime;
            cmdParms[28].Value = model.FootLesionsTime;
            cmdParms[29].Value = model.CerebrovascularTime;
            cmdParms[30].Value = model.LesionsOther;
            cmdParms[31].Value = model.LesionsOtherTime;
            cmdParms[32].Value = model.Lesions;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(ChronicDiabetesBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_DIABETES_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,ManagementGroup,CaseSource,FamilyHistory,DiabetesType,");
            builder.Append("DiabetesTime,DiabetesWork,Insulin,InsulinWeight,EnalaprilMelete,EndManage,EndWhy,");
            builder.Append("EndTime,HappnTime,CreateUnit,CurrentUnit,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDelete,");
            builder.Append("Symptom,RenalLesionsTime,NeuropathyTime,HeartDiseaseTime,RetinopathyTime,FootLesionsTime,");
            builder.Append("CerebrovascularTime,LesionsOther,LesionsOtherTime,Lesions )");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@ManagementGroup,@CaseSource,@FamilyHistory,@DiabetesType,");
            builder.Append("@DiabetesTime,@DiabetesWork,@Insulin,@InsulinWeight,@EnalaprilMelete,@EndManage,@EndWhy,");
            builder.Append("@EndTime,@HappnTime,@CreateUnit,@CurrentUnit,@CreateBy,@CreateDate,@LastUpdateBy,@LastUpdateDate,");
            builder.Append("@IsDelete,@Symptom,@RenalLesionsTime,@NeuropathyTime,@HeartDiseaseTime,@RetinopathyTime,@FootLesionsTime,");
            builder.Append("@CerebrovascularTime,@LesionsOther,@LesionsOtherTime,@Lesions )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@ManagementGroup", MySqlDbType.String, 1),
                new MySqlParameter("@CaseSource", MySqlDbType.String, 1),
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@DiabetesType", MySqlDbType.String, 1),
                new MySqlParameter("@DiabetesTime", MySqlDbType.Date),
                new MySqlParameter("@DiabetesWork", MySqlDbType.String, 100),
                new MySqlParameter("@Insulin", MySqlDbType.String, 1), 
                new MySqlParameter("@InsulinWeight", MySqlDbType.String, 50),
                new MySqlParameter("@EnalaprilMelete", MySqlDbType.String, 100),
                new MySqlParameter("@EndManage", MySqlDbType.String, 1),
                new MySqlParameter("@EndWhy", MySqlDbType.String, 100), 
                new MySqlParameter("@EndTime", MySqlDbType.Date),
                new MySqlParameter("@HappnTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateBy", MySqlDbType.String, 18),
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String, 18), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30),
                new MySqlParameter("@RenalLesionsTime", MySqlDbType.String, 4),
                new MySqlParameter("@NeuropathyTime", MySqlDbType.String, 4),
                new MySqlParameter("@HeartDiseaseTime", MySqlDbType.String, 4),
                new MySqlParameter("@RetinopathyTime", MySqlDbType.String, 4),
                new MySqlParameter("@FootLesionsTime", MySqlDbType.String, 4),
                new MySqlParameter("@CerebrovascularTime", MySqlDbType.String, 4), 
                new MySqlParameter("@LesionsOther", MySqlDbType.String, 100), 
                new MySqlParameter("@LesionsOtherTime", MySqlDbType.String, 4), 
                new MySqlParameter("@Lesions", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ManagementGroup;
            cmdParms[4].Value = model.CaseSource;
            cmdParms[5].Value = model.FamilyHistory;
            cmdParms[6].Value = model.DiabetesType;
            cmdParms[7].Value = model.DiabetesTime;
            cmdParms[8].Value = model.DiabetesWork;
            cmdParms[9].Value = model.Insulin;
            cmdParms[10].Value = model.InsulinWeight;
            cmdParms[11].Value = model.EnalaprilMelete;
            cmdParms[12].Value = model.EndManage;
            cmdParms[13].Value = model.EndWhy;
            cmdParms[14].Value = model.EndTime;
            cmdParms[15].Value = model.HappnTime;
            cmdParms[16].Value = model.CreateUnit;
            cmdParms[17].Value = model.CurrentUnit;
            cmdParms[18].Value = model.CreateBy;
            cmdParms[19].Value = model.CreateDate;
            cmdParms[20].Value = model.LastUpdateBy;
            cmdParms[21].Value = model.LastUpdateDate;
            cmdParms[22].Value = model.IsDelete;
            cmdParms[23].Value = model.Symptom;
            cmdParms[24].Value = model.RenalLesionsTime;
            cmdParms[25].Value = model.NeuropathyTime;
            cmdParms[26].Value = model.HeartDiseaseTime;
            cmdParms[27].Value = model.RetinopathyTime;
            cmdParms[28].Value = model.FootLesionsTime;
            cmdParms[29].Value = model.CerebrovascularTime;
            cmdParms[30].Value = model.LesionsOther;
            cmdParms[31].Value = model.LesionsOtherTime;
            cmdParms[32].Value = model.Lesions;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public ChronicDiabetesBaseInfoModel DataRowToModel(DataRow row)
        {
            ChronicDiabetesBaseInfoModel chronicDiabetesBaseInfoModel = new ChronicDiabetesBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicDiabetesBaseInfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["ManagementGroup"] != null) && (row["ManagementGroup"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.ManagementGroup = row["ManagementGroup"].ToString();
                }
                if ((row["CaseSource"] != null) && (row["CaseSource"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.CaseSource = row["CaseSource"].ToString();
                }
                if ((row["FamilyHistory"] != null) && (row["FamilyHistory"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.FamilyHistory = row["FamilyHistory"].ToString();
                }
                if ((row["DiabetesType"] != null) && (row["DiabetesType"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.DiabetesType = row["DiabetesType"].ToString();
                }
                if (((row["DiabetesTime"] != null) && (row["DiabetesTime"] != DBNull.Value)) && (row["DiabetesTime"].ToString() != ""))
                {
                    chronicDiabetesBaseInfoModel.DiabetesTime = new DateTime?(DateTime.Parse(row["DiabetesTime"].ToString()));
                }
                if ((row["DiabetesWork"] != null) && (row["DiabetesWork"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.DiabetesWork = row["DiabetesWork"].ToString();
                }
                if ((row["Insulin"] != null) && (row["Insulin"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.Insulin = row["Insulin"].ToString();
                }
                if ((row["InsulinWeight"] != null) && (row["InsulinWeight"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.InsulinWeight = row["InsulinWeight"].ToString();
                }
                if ((row["EnalaprilMelete"] != null) && (row["EnalaprilMelete"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.EnalaprilMelete = row["EnalaprilMelete"].ToString();
                }
                if ((row["EndManage"] != null) && (row["EndManage"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.EndManage = row["EndManage"].ToString();
                }
                if ((row["EndWhy"] != null) && (row["EndWhy"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.EndWhy = row["EndWhy"].ToString();
                }
                if (((row["EndTime"] != null) && (row["EndTime"] != DBNull.Value)) && (row["EndTime"].ToString() != ""))
                {
                    chronicDiabetesBaseInfoModel.EndTime = new DateTime?(DateTime.Parse(row["EndTime"].ToString()));
                }
                if (((row["HappnTime"] != null) && (row["HappnTime"] != DBNull.Value)) && (row["HappnTime"].ToString() != ""))
                {
                    chronicDiabetesBaseInfoModel.HappnTime = new DateTime?(DateTime.Parse(row["HappnTime"].ToString()));
                }
                if (((row["CreateUnit"] != null) && (row["CreateUnit"] != DBNull.Value)) && (row["CreateUnit"].ToString() != ""))
                {
                    chronicDiabetesBaseInfoModel.CreateUnit = new decimal?(decimal.Parse(row["CreateUnit"].ToString()));
                }
                if (((row["CurrentUnit"] != null) && (row["CurrentUnit"] != DBNull.Value)) && (row["CurrentUnit"].ToString() != ""))
                {
                    chronicDiabetesBaseInfoModel.CurrentUnit = new decimal?(decimal.Parse(row["CurrentUnit"].ToString()));
                }
                if ((row["CreateBy"] != null) && (row["CreateBy"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.CreateBy = new decimal?(decimal.Parse(row["CreateBy"].ToString()));
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    chronicDiabetesBaseInfoModel.CreateDate = new DateTime?(DateTime.Parse(row["CreateDate"].ToString()));
                }
                if ((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    chronicDiabetesBaseInfoModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDelete"] != null) && (row["IsDelete"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.IsDelete = row["IsDelete"].ToString();
                }
                if ((row["Symptom"] != null) && (row["Symptom"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.Symptom = row["Symptom"].ToString();
                }
                if ((row["RenalLesionsTime"] != null) && (row["RenalLesionsTime"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.RenalLesionsTime = row["RenalLesionsTime"].ToString();
                }
                if ((row["NeuropathyTime"] != null) && (row["NeuropathyTime"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.NeuropathyTime = row["NeuropathyTime"].ToString();
                }
                if ((row["HeartDiseaseTime"] != null) && (row["HeartDiseaseTime"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.HeartDiseaseTime = row["HeartDiseaseTime"].ToString();
                }
                if ((row["RetinopathyTime"] != null) && (row["RetinopathyTime"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.RetinopathyTime = row["RetinopathyTime"].ToString();
                }
                if ((row["FootLesionsTime"] != null) && (row["FootLesionsTime"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.FootLesionsTime = row["FootLesionsTime"].ToString();
                }
                if ((row["CerebrovascularTime"] != null) && (row["CerebrovascularTime"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.CerebrovascularTime = row["CerebrovascularTime"].ToString();
                }
                if ((row["LesionsOther"] != null) && (row["LesionsOther"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.LesionsOther = row["LesionsOther"].ToString();
                }
                if ((row["LesionsOtherTime"] != null) && (row["LesionsOtherTime"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.LesionsOtherTime = row["LesionsOtherTime"].ToString();
                }
                if ((row["Lesions"] != null) && (row["Lesions"] != DBNull.Value))
                {
                    chronicDiabetesBaseInfoModel.Lesions = row["Lesions"].ToString();
                }
            }
            return chronicDiabetesBaseInfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_DIABETES_BASEINFO ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
     
        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_DIABETES_BASEINFO ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CD_DIABETES_BASEINFO");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public bool ExistIDCardNo(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CD_DIABETES_BASEINFO");
            builder.Append(" where IDCardNo =@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
            };
            cmdParms[0].Value = IDCardNo;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,ManagementGroup,CaseSource,FamilyHistory,");
            builder.Append("DiabetesType,DiabetesTime,DiabetesWork,Insulin,InsulinWeight,EnalaprilMelete,EndManage,");
            builder.Append("EndWhy,EndTime,HappnTime,CreateUnit,CurrentUnit,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,");
            builder.Append("IsDelete,Symptom,RenalLesionsTime,NeuropathyTime,HeartDiseaseTime,RetinopathyTime,FootLesionsTime,");
            builder.Append("CerebrovascularTime,LesionsOther,LesionsOtherTime,Lesions ");
            builder.Append(" FROM CD_DIABETES_BASEINFO ");
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
            builder.Append(")AS Row, T.*  from CD_DIABETES_BASEINFO T ");
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
            return MySQLHelper.GetMaxID("ID", "CD_DIABETES_BASEINFO");
        }

        public ChronicDiabetesBaseInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  ID,CustomerID,RecordID,IDCardNo,ManagementGroup,CaseSource,");
            builder.Append("FamilyHistory,DiabetesType,DiabetesTime,DiabetesWork,");
            builder.Append("Insulin,InsulinWeight,EnalaprilMelete,EndManage,EndWhy,");
            builder.Append("EndTime,HappnTime,CreateUnit,CurrentUnit,CreateBy,");
            builder.Append("CreateDate,LastUpdateBy,LastUpdateDate,IsDelete,Symptom,RenalLesionsTime,");
            builder.Append("NeuropathyTime,HeartDiseaseTime,RetinopathyTime,FootLesionsTime,CerebrovascularTime,LesionsOther,LesionsOtherTime,");
            builder.Append("Lesions from CD_DIABETES_BASEINFO ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new ChronicDiabetesBaseInfoModel();
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
            builder.Append("select count(1) FROM CD_DIABETES_BASEINFO ");
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

        public bool Update(ChronicDiabetesBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_DIABETES_BASEINFO set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("ManagementGroup=@ManagementGroup,");
            builder.Append("CaseSource=@CaseSource,");
            builder.Append("FamilyHistory=@FamilyHistory,");
            builder.Append("DiabetesType=@DiabetesType,");
            builder.Append("DiabetesTime=@DiabetesTime,");
            builder.Append("DiabetesWork=@DiabetesWork,");
            builder.Append("Insulin=@Insulin,");
            builder.Append("InsulinWeight=@InsulinWeight,");
            builder.Append("EnalaprilMelete=@EnalaprilMelete,");
            builder.Append("EndManage=@EndManage,");
            builder.Append("EndWhy=@EndWhy,");
            builder.Append("EndTime=@EndTime,");
            builder.Append("HappnTime=@HappnTime,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDelete=@IsDelete,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("RenalLesionsTime=@RenalLesionsTime,");
            builder.Append("NeuropathyTime=@NeuropathyTime,");
            builder.Append("HeartDiseaseTime=@HeartDiseaseTime,");
            builder.Append("RetinopathyTime=@RetinopathyTime,");
            builder.Append("FootLesionsTime=@FootLesionsTime,");
            builder.Append("CerebrovascularTime=@CerebrovascularTime,");
            builder.Append("LesionsOther=@LesionsOther,");
            builder.Append("LesionsOtherTime=@LesionsOtherTime,");
            builder.Append("Lesions=@Lesions ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@ManagementGroup", MySqlDbType.String, 1),
                new MySqlParameter("@CaseSource", MySqlDbType.String, 1), 
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@DiabetesType", MySqlDbType.String, 1),
                new MySqlParameter("@DiabetesTime", MySqlDbType.Date),
                new MySqlParameter("@DiabetesWork", MySqlDbType.String, 100),
                new MySqlParameter("@Insulin", MySqlDbType.String, 1),
                new MySqlParameter("@InsulinWeight", MySqlDbType.String, 50),
                new MySqlParameter("@EnalaprilMelete", MySqlDbType.String, 100),
                new MySqlParameter("@EndManage", MySqlDbType.String, 1),
                new MySqlParameter("@EndWhy", MySqlDbType.String, 100),
                new MySqlParameter("@EndTime", MySqlDbType.Date), 
                new MySqlParameter("@HappnTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateBy", MySqlDbType.String, 18), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String, 18),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30), 
                new MySqlParameter("@RenalLesionsTime", MySqlDbType.String, 4),
                new MySqlParameter("@NeuropathyTime", MySqlDbType.String, 4),
                new MySqlParameter("@HeartDiseaseTime", MySqlDbType.String, 4), 
                new MySqlParameter("@RetinopathyTime", MySqlDbType.String, 4), 
                new MySqlParameter("@FootLesionsTime", MySqlDbType.String, 4),
                new MySqlParameter("@CerebrovascularTime", MySqlDbType.String, 4),
                new MySqlParameter("@LesionsOther", MySqlDbType.String, 100),
                new MySqlParameter("@LesionsOtherTime", MySqlDbType.String, 4), 
                new MySqlParameter("@Lesions", MySqlDbType.String, 1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 4)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ManagementGroup;
            cmdParms[4].Value = model.CaseSource;
            cmdParms[5].Value = model.FamilyHistory;
            cmdParms[6].Value = model.DiabetesType;
            cmdParms[7].Value = model.DiabetesTime;
            cmdParms[8].Value = model.DiabetesWork;
            cmdParms[9].Value = model.Insulin;
            cmdParms[10].Value = model.InsulinWeight;
            cmdParms[11].Value = model.EnalaprilMelete;
            cmdParms[12].Value = model.EndManage;
            cmdParms[13].Value = model.EndWhy;
            cmdParms[14].Value = model.EndTime;
            cmdParms[15].Value = model.HappnTime;
            cmdParms[16].Value = model.CreateUnit;
            cmdParms[17].Value = model.CurrentUnit;
            cmdParms[18].Value = model.CreateBy;
            cmdParms[19].Value = model.CreateDate;
            cmdParms[20].Value = model.LastUpdateBy;
            cmdParms[21].Value = model.LastUpdateDate;
            cmdParms[22].Value = model.IsDelete;
            cmdParms[23].Value = model.Symptom;
            cmdParms[24].Value = model.RenalLesionsTime;
            cmdParms[25].Value = model.NeuropathyTime;
            cmdParms[26].Value = model.HeartDiseaseTime;
            cmdParms[27].Value = model.RetinopathyTime;
            cmdParms[28].Value = model.FootLesionsTime;
            cmdParms[29].Value = model.CerebrovascularTime;
            cmdParms[30].Value = model.LesionsOther;
            cmdParms[31].Value = model.LesionsOtherTime;
            cmdParms[32].Value = model.Lesions;
            cmdParms[33].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(ChronicDiabetesBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_DIABETES_BASEINFO set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("ManagementGroup=@ManagementGroup,");
            builder.Append("CaseSource=@CaseSource,");
            builder.Append("FamilyHistory=@FamilyHistory,");
            builder.Append("DiabetesType=@DiabetesType,");
            builder.Append("DiabetesTime=@DiabetesTime,");
            builder.Append("DiabetesWork=@DiabetesWork,");
            builder.Append("Insulin=@Insulin,");
            builder.Append("InsulinWeight=@InsulinWeight,");
            builder.Append("EnalaprilMelete=@EnalaprilMelete,");
            builder.Append("EndManage=@EndManage,");
            builder.Append("EndWhy=@EndWhy,");
            builder.Append("EndTime=@EndTime,");
            builder.Append("HappnTime=@HappnTime,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDelete=@IsDelete,");
            builder.Append("Symptom=@Symptom,");
            builder.Append("RenalLesionsTime=@RenalLesionsTime,");
            builder.Append("NeuropathyTime=@NeuropathyTime,");
            builder.Append("HeartDiseaseTime=@HeartDiseaseTime,");
            builder.Append("RetinopathyTime=@RetinopathyTime,");
            builder.Append("FootLesionsTime=@FootLesionsTime,");
            builder.Append("CerebrovascularTime=@CerebrovascularTime,");
            builder.Append("LesionsOther=@LesionsOther,");
            builder.Append("LesionsOtherTime=@LesionsOtherTime,");
            builder.Append("Lesions=@Lesions ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@ManagementGroup", MySqlDbType.String, 1),
                new MySqlParameter("@CaseSource", MySqlDbType.String, 1), 
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@DiabetesType", MySqlDbType.String, 1),
                new MySqlParameter("@DiabetesTime", MySqlDbType.Date),
                new MySqlParameter("@DiabetesWork", MySqlDbType.String, 100),
                new MySqlParameter("@Insulin", MySqlDbType.String, 1),
                new MySqlParameter("@InsulinWeight", MySqlDbType.String, 50),
                new MySqlParameter("@EnalaprilMelete", MySqlDbType.String, 100),
                new MySqlParameter("@EndManage", MySqlDbType.String, 1),
                new MySqlParameter("@EndWhy", MySqlDbType.String, 100),
                new MySqlParameter("@EndTime", MySqlDbType.Date), 
                new MySqlParameter("@HappnTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateBy", MySqlDbType.String, 18), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.String, 18),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                new MySqlParameter("@Symptom", MySqlDbType.String, 30), 
                new MySqlParameter("@RenalLesionsTime", MySqlDbType.String, 4),
                new MySqlParameter("@NeuropathyTime", MySqlDbType.String, 4),
                new MySqlParameter("@HeartDiseaseTime", MySqlDbType.String, 4), 
                new MySqlParameter("@RetinopathyTime", MySqlDbType.String, 4), 
                new MySqlParameter("@FootLesionsTime", MySqlDbType.String, 4),
                new MySqlParameter("@CerebrovascularTime", MySqlDbType.String, 4),
                new MySqlParameter("@LesionsOther", MySqlDbType.String, 100),
                new MySqlParameter("@LesionsOtherTime", MySqlDbType.String, 4), 
                new MySqlParameter("@Lesions", MySqlDbType.String, 1), 
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.ManagementGroup;
            cmdParms[4].Value = model.CaseSource;
            cmdParms[5].Value = model.FamilyHistory;
            cmdParms[6].Value = model.DiabetesType;
            cmdParms[7].Value = model.DiabetesTime;
            cmdParms[8].Value = model.DiabetesWork;
            cmdParms[9].Value = model.Insulin;
            cmdParms[10].Value = model.InsulinWeight;
            cmdParms[11].Value = model.EnalaprilMelete;
            cmdParms[12].Value = model.EndManage;
            cmdParms[13].Value = model.EndWhy;
            cmdParms[14].Value = model.EndTime;
            cmdParms[15].Value = model.HappnTime;
            cmdParms[16].Value = model.CreateUnit;
            cmdParms[17].Value = model.CurrentUnit;
            cmdParms[18].Value = model.CreateBy;
            cmdParms[19].Value = model.CreateDate;
            cmdParms[20].Value = model.LastUpdateBy;
            cmdParms[21].Value = model.LastUpdateDate;
            cmdParms[22].Value = model.IsDelete;
            cmdParms[23].Value = model.Symptom;
            cmdParms[24].Value = model.RenalLesionsTime;
            cmdParms[25].Value = model.NeuropathyTime;
            cmdParms[26].Value = model.HeartDiseaseTime;
            cmdParms[27].Value = model.RetinopathyTime;
            cmdParms[28].Value = model.FootLesionsTime;
            cmdParms[29].Value = model.CerebrovascularTime;
            cmdParms[30].Value = model.LesionsOther;
            cmdParms[31].Value = model.LesionsOtherTime;
            cmdParms[32].Value = model.Lesions;
            //cmdParms[33].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

