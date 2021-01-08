namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicStrokeBaseInfoDAL
    {
        public int Add(ChronicStrokeBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_chronicstrokebaseinfo(");
            builder.Append("CustomerID,RecordID,IDCardNo,IllSource,IllTime,DiagnosisHource,");
            builder.Append("Familyhistory,HosState,Mrs,GroupLevel,DangerousElement,DgrElementOther,");
            builder.Append("CT,Mri,StrokeType,StrokePosition,SelfAbility,DrugsRely,SpecialTreatment,");
            builder.Append("OtherTreatment,StopManager,StopTime,StopReason,OccurTime,CreateUnit,");
            builder.Append("CurrentUnit,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@IllSource,@IllTime,@DiagnosisHource,@Familyhistory,");
            builder.Append("@HosState,@Mrs,@GroupLevel,@DangerousElement,@DgrElementOther,@CT,@Mri,@StrokeType,");
            builder.Append("@StrokePosition,@SelfAbility,@DrugsRely,@SpecialTreatment,@OtherTreatment,@StopManager,");
            builder.Append("@StopTime,@StopReason,@OccurTime,@CreateUnit,@CurrentUnit,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IllSource", MySqlDbType.String, 1), 
                new MySqlParameter("@IllTime", MySqlDbType.Date), 
                new MySqlParameter("@DiagnosisHource", MySqlDbType.String, 100),
                new MySqlParameter("@Familyhistory", MySqlDbType.String, 30),
                new MySqlParameter("@HosState", MySqlDbType.String, 50),
                new MySqlParameter("@Mrs", MySqlDbType.Decimal), 
                new MySqlParameter("@GroupLevel", MySqlDbType.String, 1),
                new MySqlParameter("@DangerousElement", MySqlDbType.String, 50),
                new MySqlParameter("@DgrElementOther", MySqlDbType.String, 200),
                new MySqlParameter("@CT", MySqlDbType.String, 200),
                new MySqlParameter("@Mri", MySqlDbType.String, 200),
                new MySqlParameter("@StrokeType", MySqlDbType.String, 1),
                new MySqlParameter("@StrokePosition", MySqlDbType.String, 1), 
                new MySqlParameter("@SelfAbility", MySqlDbType.String, 1), 
                new MySqlParameter("@DrugsRely", MySqlDbType.String, 1), 
                new MySqlParameter("@SpecialTreatment", MySqlDbType.String, 30), 
                new MySqlParameter("@OtherTreatment", MySqlDbType.String, 50),
                new MySqlParameter("@StopManager", MySqlDbType.String, 1), 
                new MySqlParameter("@StopTime", MySqlDbType.Date), 
                new MySqlParameter("@StopReason", MySqlDbType.String, 1), 
                new MySqlParameter("@OccurTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.IllSource;
            cmdParms[4].Value = model.IllTime;
            cmdParms[5].Value = model.DiagnosisHource;
            cmdParms[6].Value = model.Familyhistory;
            cmdParms[7].Value = model.HosState;
            cmdParms[8].Value = model.Mrs;
            cmdParms[9].Value = model.GroupLevel;
            cmdParms[10].Value = model.DangerousElement;
            cmdParms[11].Value = model.DgrElementOther;
            cmdParms[12].Value = model.CT;
            cmdParms[13].Value = model.Mri;
            cmdParms[14].Value = model.StrokeType;
            cmdParms[15].Value = model.StrokePosition;
            cmdParms[16].Value = model.SelfAbility;
            cmdParms[17].Value = model.DrugsRely;
            cmdParms[18].Value = model.SpecialTreatment;
            cmdParms[19].Value = model.OtherTreatment;
            cmdParms[20].Value = model.StopManager;
            cmdParms[21].Value = model.StopTime;
            cmdParms[22].Value = model.StopReason;
            cmdParms[23].Value = model.OccurTime;
            cmdParms[24].Value = model.CreateUnit;
            cmdParms[25].Value = model.CurrentUnit;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpdateDate;
            cmdParms[30].Value = model.IsDel;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(ChronicStrokeBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_chronicstrokebaseinfo(");
            builder.Append("CustomerID,RecordID,IDCardNo,IllSource,IllTime,DiagnosisHource,");
            builder.Append("Familyhistory,HosState,Mrs,GroupLevel,DangerousElement,DgrElementOther,");
            builder.Append("CT,Mri,StrokeType,StrokePosition,SelfAbility,DrugsRely,SpecialTreatment,");
            builder.Append("OtherTreatment,StopManager,StopTime,StopReason,OccurTime,CreateUnit,");
            builder.Append("CurrentUnit,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@IllSource,@IllTime,@DiagnosisHource,@Familyhistory,");
            builder.Append("@HosState,@Mrs,@GroupLevel,@DangerousElement,@DgrElementOther,@CT,@Mri,@StrokeType,");
            builder.Append("@StrokePosition,@SelfAbility,@DrugsRely,@SpecialTreatment,@OtherTreatment,@StopManager,");
            builder.Append("@StopTime,@StopReason,@OccurTime,@CreateUnit,@CurrentUnit,");
            builder.Append("@CreatedBy,@CreatedDate,@LastUpdateBy,@LastUpdateDate,@IsDel)");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IllSource", MySqlDbType.String, 1), 
                new MySqlParameter("@IllTime", MySqlDbType.Date), 
                new MySqlParameter("@DiagnosisHource", MySqlDbType.String, 100),
                new MySqlParameter("@Familyhistory", MySqlDbType.String, 30),
                new MySqlParameter("@HosState", MySqlDbType.String, 50),
                new MySqlParameter("@Mrs", MySqlDbType.Decimal), 
                new MySqlParameter("@GroupLevel", MySqlDbType.String, 1),
                new MySqlParameter("@DangerousElement", MySqlDbType.String, 50),
                new MySqlParameter("@DgrElementOther", MySqlDbType.String, 200),
                new MySqlParameter("@CT", MySqlDbType.String, 200),
                new MySqlParameter("@Mri", MySqlDbType.String, 200),
                new MySqlParameter("@StrokeType", MySqlDbType.String, 1),
                new MySqlParameter("@StrokePosition", MySqlDbType.String, 1), 
                new MySqlParameter("@SelfAbility", MySqlDbType.String, 1), 
                new MySqlParameter("@DrugsRely", MySqlDbType.String, 1), 
                new MySqlParameter("@SpecialTreatment", MySqlDbType.String, 30), 
                new MySqlParameter("@OtherTreatment", MySqlDbType.String, 50),
                new MySqlParameter("@StopManager", MySqlDbType.String, 1), 
                new MySqlParameter("@StopTime", MySqlDbType.Date), 
                new MySqlParameter("@StopReason", MySqlDbType.String, 1), 
                new MySqlParameter("@OccurTime", MySqlDbType.Date), 
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDel", MySqlDbType.String, 1)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.IllSource;
            cmdParms[4].Value = model.IllTime;
            cmdParms[5].Value = model.DiagnosisHource;
            cmdParms[6].Value = model.Familyhistory;
            cmdParms[7].Value = model.HosState;
            cmdParms[8].Value = model.Mrs;
            cmdParms[9].Value = model.GroupLevel;
            cmdParms[10].Value = model.DangerousElement;
            cmdParms[11].Value = model.DgrElementOther;
            cmdParms[12].Value = model.CT;
            cmdParms[13].Value = model.Mri;
            cmdParms[14].Value = model.StrokeType;
            cmdParms[15].Value = model.StrokePosition;
            cmdParms[16].Value = model.SelfAbility;
            cmdParms[17].Value = model.DrugsRely;
            cmdParms[18].Value = model.SpecialTreatment;
            cmdParms[19].Value = model.OtherTreatment;
            cmdParms[20].Value = model.StopManager;
            cmdParms[21].Value = model.StopTime;
            cmdParms[22].Value = model.StopReason;
            cmdParms[23].Value = model.OccurTime;
            cmdParms[24].Value = model.CreateUnit;
            cmdParms[25].Value = model.CurrentUnit;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpdateDate;
            cmdParms[30].Value = model.IsDel;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public ChronicStrokeBaseInfoModel DataRowToModel(DataRow row)
        {
            ChronicStrokeBaseInfoModel chronicStrokeBaseInfoModel = new ChronicStrokeBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["IllSource"] != null) && (row["IllSource"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.IllSource = row["IllSource"].ToString();
                }
                if (((row["IllTime"] != null) && (row["IllTime"] != DBNull.Value)) && (row["IllTime"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.IllTime = new DateTime?(DateTime.Parse(row["IllTime"].ToString()));
                }
                if ((row["DiagnosisHource"] != null) && (row["DiagnosisHource"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.DiagnosisHource = row["DiagnosisHource"].ToString();
                }
                if ((row["Familyhistory"] != null) && (row["Familyhistory"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.Familyhistory = row["Familyhistory"].ToString();
                }
                if ((row["HosState"] != null) && (row["HosState"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.HosState = row["HosState"].ToString();
                }
                if (((row["Mrs"] != null) && (row["Mrs"] != DBNull.Value)) && (row["Mrs"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.Mrs = new decimal?(decimal.Parse(row["Mrs"].ToString()));
                }
                if ((row["GroupLevel"] != null) && (row["GroupLevel"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.GroupLevel = row["GroupLevel"].ToString();
                }
                if ((row["DangerousElement"] != null) && (row["DangerousElement"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.DangerousElement = row["DangerousElement"].ToString();
                }
                if ((row["DgrElementOther"] != null) && (row["DgrElementOther"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.DgrElementOther = row["DgrElementOther"].ToString();
                }
                if ((row["CT"] != null) && (row["CT"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.CT = row["CT"].ToString();
                }
                if ((row["Mri"] != null) && (row["Mri"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.Mri = row["Mri"].ToString();
                }
                if ((row["StrokeType"] != null) && (row["StrokeType"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.StrokeType = row["StrokeType"].ToString();
                }
                if ((row["StrokePosition"] != null) && (row["StrokePosition"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.StrokePosition = row["StrokePosition"].ToString();
                }
                if ((row["SelfAbility"] != null) && (row["SelfAbility"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.SelfAbility = row["SelfAbility"].ToString();
                }
                if ((row["DrugsRely"] != null) && (row["DrugsRely"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.DrugsRely = row["DrugsRely"].ToString();
                }
                if ((row["SpecialTreatment"] != null) && (row["SpecialTreatment"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.SpecialTreatment = row["SpecialTreatment"].ToString();
                }
                if ((row["OtherTreatment"] != null) && (row["OtherTreatment"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.OtherTreatment = row["OtherTreatment"].ToString();
                }
                if ((row["StopManager"] != null) && (row["StopManager"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.StopManager = row["StopManager"].ToString();
                }
                if (((row["StopTime"] != null) && (row["StopTime"] != DBNull.Value)) && (row["StopTime"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.StopTime = new DateTime?(DateTime.Parse(row["StopTime"].ToString()));
                }
                if ((row["StopReason"] != null) && (row["StopReason"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.StopReason = row["StopReason"].ToString();
                }
                if (((row["OccurTime"] != null) && (row["OccurTime"] != DBNull.Value)) && (row["OccurTime"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.OccurTime = new DateTime?(DateTime.Parse(row["OccurTime"].ToString()));
                }
                if (((row["CreateUnit"] != null) && (row["CreateUnit"] != DBNull.Value)) && (row["CreateUnit"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.CreateUnit = decimal.Parse(row["CreateUnit"].ToString());
                }
                if (((row["CurrentUnit"] != null) && (row["CurrentUnit"] != DBNull.Value)) && (row["CurrentUnit"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.CurrentUnit = decimal.Parse(row["CurrentUnit"].ToString());
                }
                if (((row["CreatedBy"] != null) && (row["CreatedBy"] != DBNull.Value)) && (row["CreatedBy"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.CreatedBy = new decimal?(decimal.Parse(row["CreatedBy"].ToString()));
                }
                if (((row["CreatedDate"] != null) && (row["CreatedDate"] != DBNull.Value)) && (row["CreatedDate"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.CreatedDate = new DateTime?(DateTime.Parse(row["CreatedDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    chronicStrokeBaseInfoModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDel"] != null) && (row["IsDel"] != DBNull.Value))
                {
                    chronicStrokeBaseInfoModel.IsDel = row["IsDel"].ToString();
                }
            }
            return chronicStrokeBaseInfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chronicstrokebaseinfo ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_chronicstrokebaseinfo ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }
        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_chronicstrokebaseinfo");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,IllSource,IllTime,DiagnosisHource,Familyhistory,HosState,");
            builder.Append("Mrs,GroupLevel,DangerousElement,DgrElementOther,CT,Mri,StrokeType,StrokePosition,SelfAbility,DrugsRely,");
            builder.Append("SpecialTreatment,OtherTreatment,StopManager,StopTime,StopReason,OccurTime,CreateUnit,CurrentUnit,");
            builder.Append("CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel ");
            builder.Append(" FROM tbl_chronicstrokebaseinfo ");
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
            builder.Append(")AS Row, T.*  from tbl_chronicstrokebaseinfo T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_chronicstrokebaseinfo");
        }

        public ChronicStrokeBaseInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,IllSource,IllTime,DiagnosisHource,Familyhistory,");
            builder.Append("HosState,Mrs,GroupLevel,DangerousElement,DgrElementOther,CT,Mri,StrokeType,StrokePosition,");
            builder.Append("SelfAbility,DrugsRely,SpecialTreatment,OtherTreatment,StopManager,StopTime,StopReason,OccurTime,");
            builder.Append("CreateUnit,CurrentUnit,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,IsDel from tbl_chronicstrokebaseinfo ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new ChronicStrokeBaseInfoModel();
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
            builder.Append("select count(1) FROM tbl_chronicstrokebaseinfo ");
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

        public bool Update(ChronicStrokeBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_chronicstrokebaseinfo set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("IllSource=@IllSource,");
            builder.Append("IllTime=@IllTime,");
            builder.Append("DiagnosisHource=@DiagnosisHource,");
            builder.Append("Familyhistory=@Familyhistory,");
            builder.Append("HosState=@HosState,");
            builder.Append("Mrs=@Mrs,");
            builder.Append("GroupLevel=@GroupLevel,");
            builder.Append("DangerousElement=@DangerousElement,");
            builder.Append("DgrElementOther=@DgrElementOther,");
            builder.Append("CT=@CT,");
            builder.Append("Mri=@Mri,");
            builder.Append("StrokeType=@StrokeType,");
            builder.Append("StrokePosition=@StrokePosition,");
            builder.Append("SelfAbility=@SelfAbility,");
            builder.Append("DrugsRely=@DrugsRely,");
            builder.Append("SpecialTreatment=@SpecialTreatment,");
            builder.Append("OtherTreatment=@OtherTreatment,");
            builder.Append("StopManager=@StopManager,");
            builder.Append("StopTime=@StopTime,");
            builder.Append("StopReason=@StopReason,");
            builder.Append("OccurTime=@OccurTime,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IllSource", MySqlDbType.String, 1), 
                new MySqlParameter("@IllTime", MySqlDbType.Date), 
                new MySqlParameter("@DiagnosisHource", MySqlDbType.String, 100), 
                new MySqlParameter("@Familyhistory", MySqlDbType.String, 30), 
                new MySqlParameter("@HosState", MySqlDbType.String, 50), 
                new MySqlParameter("@Mrs", MySqlDbType.Decimal), 
                new MySqlParameter("@GroupLevel", MySqlDbType.String, 1),
                new MySqlParameter("@DangerousElement", MySqlDbType.String, 50),
                new MySqlParameter("@DgrElementOther", MySqlDbType.String, 200),
                new MySqlParameter("@CT", MySqlDbType.String, 200), 
                new MySqlParameter("@Mri", MySqlDbType.String, 200),
                new MySqlParameter("@StrokeType", MySqlDbType.String, 1),
                new MySqlParameter("@StrokePosition", MySqlDbType.String, 1), 
                new MySqlParameter("@SelfAbility", MySqlDbType.String, 1), 
                new MySqlParameter("@DrugsRely", MySqlDbType.String, 1),
                new MySqlParameter("@SpecialTreatment", MySqlDbType.String, 30),
                new MySqlParameter("@OtherTreatment", MySqlDbType.String, 50), 
                new MySqlParameter("@StopManager", MySqlDbType.String, 1), 
                new MySqlParameter("@StopTime", MySqlDbType.Date),
                new MySqlParameter("@StopReason", MySqlDbType.String, 1),
                new MySqlParameter("@OccurTime", MySqlDbType.Date),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.IllSource;
            cmdParms[4].Value = model.IllTime;
            cmdParms[5].Value = model.DiagnosisHource;
            cmdParms[6].Value = model.Familyhistory;
            cmdParms[7].Value = model.HosState;
            cmdParms[8].Value = model.Mrs;
            cmdParms[9].Value = model.GroupLevel;
            cmdParms[10].Value = model.DangerousElement;
            cmdParms[11].Value = model.DgrElementOther;
            cmdParms[12].Value = model.CT;
            cmdParms[13].Value = model.Mri;
            cmdParms[14].Value = model.StrokeType;
            cmdParms[15].Value = model.StrokePosition;
            cmdParms[16].Value = model.SelfAbility;
            cmdParms[17].Value = model.DrugsRely;
            cmdParms[18].Value = model.SpecialTreatment;
            cmdParms[19].Value = model.OtherTreatment;
            cmdParms[20].Value = model.StopManager;
            cmdParms[21].Value = model.StopTime;
            cmdParms[22].Value = model.StopReason;
            cmdParms[23].Value = model.OccurTime;
            cmdParms[24].Value = model.CreateUnit;
            cmdParms[25].Value = model.CurrentUnit;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpdateDate;
            cmdParms[30].Value = model.IsDel;
            cmdParms[31].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(ChronicStrokeBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_chronicstrokebaseinfo set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("IllSource=@IllSource,");
            builder.Append("IllTime=@IllTime,");
            builder.Append("DiagnosisHource=@DiagnosisHource,");
            builder.Append("Familyhistory=@Familyhistory,");
            builder.Append("HosState=@HosState,");
            builder.Append("Mrs=@Mrs,");
            builder.Append("GroupLevel=@GroupLevel,");
            builder.Append("DangerousElement=@DangerousElement,");
            builder.Append("DgrElementOther=@DgrElementOther,");
            builder.Append("CT=@CT,");
            builder.Append("Mri=@Mri,");
            builder.Append("StrokeType=@StrokeType,");
            builder.Append("StrokePosition=@StrokePosition,");
            builder.Append("SelfAbility=@SelfAbility,");
            builder.Append("DrugsRely=@DrugsRely,");
            builder.Append("SpecialTreatment=@SpecialTreatment,");
            builder.Append("OtherTreatment=@OtherTreatment,");
            builder.Append("StopManager=@StopManager,");
            builder.Append("StopTime=@StopTime,");
            builder.Append("StopReason=@StopReason,");
            builder.Append("OccurTime=@OccurTime,");
            builder.Append("CreateUnit=@CreateUnit,");
            builder.Append("CurrentUnit=@CurrentUnit,");
            builder.Append("CreatedBy=@CreatedBy,");
            builder.Append("CreatedDate=@CreatedDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDel=@IsDel");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IllSource", MySqlDbType.String, 1), 
                new MySqlParameter("@IllTime", MySqlDbType.Date), 
                new MySqlParameter("@DiagnosisHource", MySqlDbType.String, 100), 
                new MySqlParameter("@Familyhistory", MySqlDbType.String, 30), 
                new MySqlParameter("@HosState", MySqlDbType.String, 50), 
                new MySqlParameter("@Mrs", MySqlDbType.Decimal), 
                new MySqlParameter("@GroupLevel", MySqlDbType.String, 1),
                new MySqlParameter("@DangerousElement", MySqlDbType.String, 50),
                new MySqlParameter("@DgrElementOther", MySqlDbType.String, 200),
                new MySqlParameter("@CT", MySqlDbType.String, 200), 
                new MySqlParameter("@Mri", MySqlDbType.String, 200),
                new MySqlParameter("@StrokeType", MySqlDbType.String, 1),
                new MySqlParameter("@StrokePosition", MySqlDbType.String, 1), 
                new MySqlParameter("@SelfAbility", MySqlDbType.String, 1), 
                new MySqlParameter("@DrugsRely", MySqlDbType.String, 1),
                new MySqlParameter("@SpecialTreatment", MySqlDbType.String, 30),
                new MySqlParameter("@OtherTreatment", MySqlDbType.String, 50), 
                new MySqlParameter("@StopManager", MySqlDbType.String, 1), 
                new MySqlParameter("@StopTime", MySqlDbType.Date),
                new MySqlParameter("@StopReason", MySqlDbType.String, 1),
                new MySqlParameter("@OccurTime", MySqlDbType.Date),
                new MySqlParameter("@CreateUnit", MySqlDbType.Decimal), 
                new MySqlParameter("@CurrentUnit", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedBy", MySqlDbType.Decimal),
                new MySqlParameter("@CreatedDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDel", MySqlDbType.String, 1),
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.IllSource;
            cmdParms[4].Value = model.IllTime;
            cmdParms[5].Value = model.DiagnosisHource;
            cmdParms[6].Value = model.Familyhistory;
            cmdParms[7].Value = model.HosState;
            cmdParms[8].Value = model.Mrs;
            cmdParms[9].Value = model.GroupLevel;
            cmdParms[10].Value = model.DangerousElement;
            cmdParms[11].Value = model.DgrElementOther;
            cmdParms[12].Value = model.CT;
            cmdParms[13].Value = model.Mri;
            cmdParms[14].Value = model.StrokeType;
            cmdParms[15].Value = model.StrokePosition;
            cmdParms[16].Value = model.SelfAbility;
            cmdParms[17].Value = model.DrugsRely;
            cmdParms[18].Value = model.SpecialTreatment;
            cmdParms[19].Value = model.OtherTreatment;
            cmdParms[20].Value = model.StopManager;
            cmdParms[21].Value = model.StopTime;
            cmdParms[22].Value = model.StopReason;
            cmdParms[23].Value = model.OccurTime;
            cmdParms[24].Value = model.CreateUnit;
            cmdParms[25].Value = model.CurrentUnit;
            cmdParms[26].Value = model.CreatedBy;
            cmdParms[27].Value = model.CreatedDate;
            cmdParms[28].Value = model.LastUpdateBy;
            cmdParms[29].Value = model.LastUpdateDate;
            cmdParms[30].Value = model.IsDel;
            //cmdParms[31].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

