using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class ChronicChdBaseInfoDAL
    {
        public int Add(ChronicChdBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_CHD_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,Source,FamilyHistory,SureDate,SureUnit,CoroType,CurrenStatus,History,Height,Weight,");
            builder.Append("BMI,HeatRate,Hypertension,Hypotension,FPG,HLIP,LLIP,Glycerate,Chole,Waistline,CheckDate,ECGResult,ECGSports,ECGColor,");
            builder.Append("Artery,Myocardial,Smoking,Drinking,Exercise,Life,Medical,Status,EndDate,EndReason,GroupLevel,CreateBy,CreateDate,");
            builder.Append("LastUpdateBy,LastUpdateDate,IsDelete)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Source,@FamilyHistory,@SureDate,@SureUnit,@CoroType,@CurrenStatus,@History,@Height,@Weight,");
            builder.Append("@BMI,@HeatRate,@Hypertension,@Hypotension,@FPG,@HLIP,@LLIP,@Glycerate,@Chole,@Waistline,@CheckDate,@ECGResult,@ECGSports,@ECGColor,");
            builder.Append("@Artery,@Myocardial,@Smoking,@Drinking,@Exercise,@Life,@Medical,@Status,@EndDate,@EndReason,@GroupLevel,@CreateBy,@CreateDate,");
            builder.Append("@LastUpdateBy,@LastUpdateDate,@IsDelete)");
            //builder.Append(";select @@IDENTITY");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Source", MySqlDbType.String, 1), 
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@SureDate", MySqlDbType.Date), 
                new MySqlParameter("@SureUnit", MySqlDbType.String, 80), 
                new MySqlParameter("@CoroType", MySqlDbType.String, 1),
                new MySqlParameter("@CurrenStatus", MySqlDbType.String, 1),
                new MySqlParameter("@History", MySqlDbType.String, 1),
                new MySqlParameter("@Height", MySqlDbType.Decimal), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal), 
                new MySqlParameter("@HeatRate", MySqlDbType.Decimal),
                new MySqlParameter("@Hypertension", MySqlDbType.Decimal), 
                new MySqlParameter("@Hypotension", MySqlDbType.Decimal), 
                new MySqlParameter("@FPG", MySqlDbType.Decimal),
                new MySqlParameter("@HLIP", MySqlDbType.Decimal), 
                new MySqlParameter("@LLIP", MySqlDbType.Decimal),
                new MySqlParameter("@Glycerate", MySqlDbType.Decimal), 
                new MySqlParameter("@Chole", MySqlDbType.Decimal),
                new MySqlParameter("@Waistline", MySqlDbType.Decimal),
                new MySqlParameter("@CheckDate", MySqlDbType.Date), 
                new MySqlParameter("@ECGResult", MySqlDbType.String, 100),
                new MySqlParameter("@ECGSports", MySqlDbType.String, 100),
                new MySqlParameter("@ECGColor", MySqlDbType.String, 100), 
                new MySqlParameter("@Artery", MySqlDbType.String, 100),
                new MySqlParameter("@Myocardial", MySqlDbType.String, 100), 
                new MySqlParameter("@Smoking", MySqlDbType.String, 1),
                new MySqlParameter("@Drinking", MySqlDbType.String, 1), 
                new MySqlParameter("@Exercise", MySqlDbType.String, 1),
                new MySqlParameter("@Life", MySqlDbType.String, 1), 
                new MySqlParameter("@Medical", MySqlDbType.String, 1),
                new MySqlParameter("@Status", MySqlDbType.String, 1), 
                new MySqlParameter("@EndDate", MySqlDbType.Date),
                new MySqlParameter("@EndReason", MySqlDbType.String, 1),
                new MySqlParameter("@GroupLevel", MySqlDbType.String, 1), 
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1)
             };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Source;
            cmdParms[4].Value = model.FamilyHistory;
            cmdParms[5].Value = model.SureDate;
            cmdParms[6].Value = model.SureUnit;
            cmdParms[7].Value = model.CoroType;
            cmdParms[8].Value = model.CurrenStatus;
            cmdParms[9].Value = model.History;
            cmdParms[10].Value = model.Height;
            cmdParms[11].Value = model.Weight;
            cmdParms[12].Value = model.BMI;
            cmdParms[13].Value = model.HeatRate;
            cmdParms[14].Value = model.Hypertension;
            cmdParms[15].Value = model.Hypotension;
            cmdParms[16].Value = model.FPG;
            cmdParms[17].Value = model.HLIP;
            cmdParms[18].Value = model.LLIP;
            cmdParms[19].Value = model.Glycerate;
            cmdParms[20].Value = model.Chole;
            cmdParms[21].Value = model.Waistline;
            cmdParms[22].Value = model.CheckDate;
            cmdParms[23].Value = model.ECGResult;
            cmdParms[24].Value = model.ECGSports;
            cmdParms[25].Value = model.ECGColor;
            cmdParms[26].Value = model.Artery;
            cmdParms[27].Value = model.Myocardial;
            cmdParms[28].Value = model.Smoking;
            cmdParms[29].Value = model.Drinking;
            cmdParms[30].Value = model.Exercise;
            cmdParms[31].Value = model.Life;
            cmdParms[32].Value = model.Medical;
            cmdParms[33].Value = model.Status;
            cmdParms[34].Value = model.EndDate;
            cmdParms[35].Value = model.EndReason;
            cmdParms[36].Value = model.GroupLevel;
            cmdParms[37].Value = model.CreateBy;
            cmdParms[38].Value = model.CreateDate;
            cmdParms[39].Value = model.LastUpdateBy;
            cmdParms[40].Value = model.LastUpdateDate;
            cmdParms[41].Value = model.IsDelete;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(ChronicChdBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CD_CHD_BASEINFO(");
            builder.Append("CustomerID,RecordID,IDCardNo,Source,FamilyHistory,SureDate,SureUnit,CoroType,CurrenStatus,History,Height,Weight,");
            builder.Append("BMI,HeatRate,Hypertension,Hypotension,FPG,HLIP,LLIP,Glycerate,Chole,Waistline,CheckDate,ECGResult,ECGSports,ECGColor,");
            builder.Append("Artery,Myocardial,Smoking,Drinking,Exercise,Life,Medical,Status,EndDate,EndReason,GroupLevel,CreateBy,CreateDate,");
            builder.Append("LastUpdateBy,LastUpdateDate,IsDelete)");
            builder.Append(" values (");
            builder.Append("@CustomerID,@RecordID,@IDCardNo,@Source,@FamilyHistory,@SureDate,@SureUnit,@CoroType,@CurrenStatus,@History,@Height,@Weight,");
            builder.Append("@BMI,@HeatRate,@Hypertension,@Hypotension,@FPG,@HLIP,@LLIP,@Glycerate,@Chole,@Waistline,@CheckDate,@ECGResult,@ECGSports,@ECGColor,");
            builder.Append("@Artery,@Myocardial,@Smoking,@Drinking,@Exercise,@Life,@Medical,@Status,@EndDate,@EndReason,@GroupLevel,@CreateBy,@CreateDate,");
            builder.Append("@LastUpdateBy,@LastUpdateDate,@IsDelete)");
            //builder.Append(";select @@IDENTITY");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32), 
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Source", MySqlDbType.String, 1), 
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@SureDate", MySqlDbType.Date), 
                new MySqlParameter("@SureUnit", MySqlDbType.String, 80), 
                new MySqlParameter("@CoroType", MySqlDbType.String, 1),
                new MySqlParameter("@CurrenStatus", MySqlDbType.String, 1),
                new MySqlParameter("@History", MySqlDbType.String, 1),
                new MySqlParameter("@Height", MySqlDbType.Decimal), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal), 
                new MySqlParameter("@HeatRate", MySqlDbType.Decimal),
                new MySqlParameter("@Hypertension", MySqlDbType.Decimal), 
                new MySqlParameter("@Hypotension", MySqlDbType.Decimal), 
                new MySqlParameter("@FPG", MySqlDbType.Decimal),
                new MySqlParameter("@HLIP", MySqlDbType.Decimal), 
                new MySqlParameter("@LLIP", MySqlDbType.Decimal),
                new MySqlParameter("@Glycerate", MySqlDbType.Decimal), 
                new MySqlParameter("@Chole", MySqlDbType.Decimal),
                new MySqlParameter("@Waistline", MySqlDbType.Decimal),
                new MySqlParameter("@CheckDate", MySqlDbType.Date), 
                new MySqlParameter("@ECGResult", MySqlDbType.String, 100),
                new MySqlParameter("@ECGSports", MySqlDbType.String, 100),
                new MySqlParameter("@ECGColor", MySqlDbType.String, 100), 
                new MySqlParameter("@Artery", MySqlDbType.String, 100),
                new MySqlParameter("@Myocardial", MySqlDbType.String, 100), 
                new MySqlParameter("@Smoking", MySqlDbType.String, 1),
                new MySqlParameter("@Drinking", MySqlDbType.String, 1), 
                new MySqlParameter("@Exercise", MySqlDbType.String, 1),
                new MySqlParameter("@Life", MySqlDbType.String, 1), 
                new MySqlParameter("@Medical", MySqlDbType.String, 1),
                new MySqlParameter("@Status", MySqlDbType.String, 1), 
                new MySqlParameter("@EndDate", MySqlDbType.Date),
                new MySqlParameter("@EndReason", MySqlDbType.String, 1),
                new MySqlParameter("@GroupLevel", MySqlDbType.String, 1), 
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date), 
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date), 
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1)
             };

            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Source;
            cmdParms[4].Value = model.FamilyHistory;
            cmdParms[5].Value = model.SureDate;
            cmdParms[6].Value = model.SureUnit;
            cmdParms[7].Value = model.CoroType;
            cmdParms[8].Value = model.CurrenStatus;
            cmdParms[9].Value = model.History;
            cmdParms[10].Value = model.Height;
            cmdParms[11].Value = model.Weight;
            cmdParms[12].Value = model.BMI;
            cmdParms[13].Value = model.HeatRate;
            cmdParms[14].Value = model.Hypertension;
            cmdParms[15].Value = model.Hypotension;
            cmdParms[16].Value = model.FPG;
            cmdParms[17].Value = model.HLIP;
            cmdParms[18].Value = model.LLIP;
            cmdParms[19].Value = model.Glycerate;
            cmdParms[20].Value = model.Chole;
            cmdParms[21].Value = model.Waistline;
            cmdParms[22].Value = model.CheckDate;
            cmdParms[23].Value = model.ECGResult;
            cmdParms[24].Value = model.ECGSports;
            cmdParms[25].Value = model.ECGColor;
            cmdParms[26].Value = model.Artery;
            cmdParms[27].Value = model.Myocardial;
            cmdParms[28].Value = model.Smoking;
            cmdParms[29].Value = model.Drinking;
            cmdParms[30].Value = model.Exercise;
            cmdParms[31].Value = model.Life;
            cmdParms[32].Value = model.Medical;
            cmdParms[33].Value = model.Status;
            cmdParms[34].Value = model.EndDate;
            cmdParms[35].Value = model.EndReason;
            cmdParms[36].Value = model.GroupLevel;
            cmdParms[37].Value = model.CreateBy;
            cmdParms[38].Value = model.CreateDate;
            cmdParms[39].Value = model.LastUpdateBy;
            cmdParms[40].Value = model.LastUpdateDate;
            cmdParms[41].Value = model.IsDelete;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public ChronicChdBaseInfoModel DataRowToModel(DataRow row)
        {
            ChronicChdBaseInfoModel chronicChdBaseInfoModel = new ChronicChdBaseInfoModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.ID = int.Parse(row["ID"].ToString());
                }
                if (((row["OUTKey"] != null) && (row["OUTKey"] != DBNull.Value)) && (row["OUTKey"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.OUTKey = int.Parse(row["OUTKey"].ToString());
                }
                if ((row["CustomerID"] != null) && (row["CustomerID"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.CustomerID = row["CustomerID"].ToString();
                }
                if ((row["RecordID"] != null) && (row["RecordID"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.RecordID = row["RecordID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Source"] != null) && (row["Source"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.Source = row["Source"].ToString();
                }
                if ((row["FamilyHistory"] != null) && (row["FamilyHistory"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.FamilyHistory = row["FamilyHistory"].ToString();
                }
                if (((row["SureDate"] != null) && (row["SureDate"] != DBNull.Value)) && (row["SureDate"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.SureDate = new DateTime?(DateTime.Parse(row["SureDate"].ToString()));
                }
                if ((row["SureUnit"] != null) && (row["SureUnit"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.SureUnit = row["SureUnit"].ToString();
                }
                if ((row["CoroType"] != null) && (row["CoroType"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.CoroType = row["CoroType"].ToString();
                }
                if ((row["CurrenStatus"] != null) && (row["CurrenStatus"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.CurrenStatus = row["CurrenStatus"].ToString();
                }
                if ((row["History"] != null) && (row["History"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.History = row["History"].ToString();
                }
                if (((row["Height"] != null) && (row["Height"] != DBNull.Value)) && (row["Height"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.Height = new decimal?(decimal.Parse(row["Height"].ToString()));
                }
                if (((row["Weight"] != null) && (row["Weight"] != DBNull.Value)) && (row["Weight"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.Weight = new decimal?(decimal.Parse(row["Weight"].ToString()));
                }
                if (((row["BMI"] != null) && (row["BMI"] != DBNull.Value)) && (row["BMI"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.BMI = new decimal?(decimal.Parse(row["BMI"].ToString()));
                }
                if (((row["HeatRate"] != null) && (row["HeatRate"] != DBNull.Value)) && (row["HeatRate"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.HeatRate = new decimal?(decimal.Parse(row["HeatRate"].ToString()));
                }
                if (((row["Hypertension"] != null) && (row["Hypertension"] != DBNull.Value)) && (row["Hypertension"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.Hypertension = new decimal?(decimal.Parse(row["Hypertension"].ToString()));
                }
                if (((row["Hypotension"] != null) && (row["Hypotension"] != DBNull.Value)) && (row["Hypotension"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.Hypotension = new decimal?(decimal.Parse(row["Hypotension"].ToString()));
                }
                if (((row["FPG"] != null) && (row["FPG"] != DBNull.Value)) && (row["FPG"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.FPG = new decimal?(decimal.Parse(row["FPG"].ToString()));
                }
                if (((row["HLIP"] != null) && (row["HLIP"] != DBNull.Value)) && (row["HLIP"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.HLIP = new decimal?(decimal.Parse(row["HLIP"].ToString()));
                }
                if (((row["LLIP"] != null) && (row["LLIP"] != DBNull.Value)) && (row["LLIP"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.LLIP = new decimal?(decimal.Parse(row["LLIP"].ToString()));
                }
                if (((row["Glycerate"] != null) && (row["Glycerate"] != DBNull.Value)) && (row["Glycerate"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.Glycerate = new decimal?(decimal.Parse(row["Glycerate"].ToString()));
                }
                if (((row["Chole"] != null) && (row["Chole"] != DBNull.Value)) && (row["Chole"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.Chole = new decimal?(decimal.Parse(row["Chole"].ToString()));
                }
                if (((row["Waistline"] != null) && (row["Waistline"] != DBNull.Value)) && (row["Waistline"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.Waistline = new decimal?(decimal.Parse(row["Waistline"].ToString()));
                }
                if (((row["CheckDate"] != null) && (row["CheckDate"] != DBNull.Value)) && (row["CheckDate"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.CheckDate = new DateTime?(DateTime.Parse(row["CheckDate"].ToString()));
                }
                if ((row["ECGResult"] != null) && (row["ECGResult"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.ECGResult = row["ECGResult"].ToString();
                }
                if ((row["ECGSports"] != null) && (row["ECGSports"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.ECGSports = row["ECGSports"].ToString();
                }
                if ((row["ECGColor"] != null) && (row["ECGColor"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.ECGColor = row["ECGColor"].ToString();
                }
                if ((row["Artery"] != null) && (row["Artery"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.Artery = row["Artery"].ToString();
                }
                if ((row["Myocardial"] != null) && (row["Myocardial"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.Myocardial = row["Myocardial"].ToString();
                }
                if ((row["Smoking"] != null) && (row["Smoking"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.Smoking = row["Smoking"].ToString();
                }
                if ((row["Drinking"] != null) && (row["Drinking"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.Drinking = row["Drinking"].ToString();
                }
                if ((row["Exercise"] != null) && (row["Exercise"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.Exercise = row["Exercise"].ToString();
                }
                if ((row["Life"] != null) && (row["Life"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.Life = row["Life"].ToString();
                }
                if ((row["Medical"] != null) && (row["Medical"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.Medical = row["Medical"].ToString();
                }
                if ((row["Status"] != null) && (row["Status"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.Status = row["Status"].ToString();
                }
                if (((row["EndDate"] != null) && (row["EndDate"] != DBNull.Value)) && (row["EndDate"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.EndDate = new DateTime?(DateTime.Parse(row["EndDate"].ToString()));
                }
                if ((row["EndReason"] != null) && (row["EndReason"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.EndReason = row["EndReason"].ToString();
                }
                if ((row["GroupLevel"] != null) && (row["GroupLevel"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.GroupLevel = row["GroupLevel"].ToString();
                }
                if (((row["CreateBy"] != null) && (row["CreateBy"] != DBNull.Value)) && (row["CreateBy"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.CreateBy = new decimal?(decimal.Parse(row["CreateBy"].ToString()));
                }
                if (((row["CreateDate"] != null) && (row["CreateDate"] != DBNull.Value)) && (row["CreateDate"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.CreateDate = new DateTime?(DateTime.Parse(row["CreateDate"].ToString()));
                }
                if (((row["LastUpdateBy"] != null) && (row["LastUpdateBy"] != DBNull.Value)) && (row["LastUpdateBy"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.LastUpdateBy = new decimal?(decimal.Parse(row["LastUpdateBy"].ToString()));
                }
                if (((row["LastUpdateDate"] != null) && (row["LastUpdateDate"] != DBNull.Value)) && (row["LastUpdateDate"].ToString() != ""))
                {
                    chronicChdBaseInfoModel.LastUpdateDate = new DateTime?(DateTime.Parse(row["LastUpdateDate"].ToString()));
                }
                if ((row["IsDelete"] != null) && (row["IsDelete"] != DBNull.Value))
                {
                    chronicChdBaseInfoModel.IsDelete = row["IsDelete"].ToString();
                }
            }
            return chronicChdBaseInfoModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_CHD_BASEINFO ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool DelOUTkey(int OUTkey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_CHD_BASEINFO ");
            builder.Append(" where OUTkey=@OUTkey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OUTkey", MySqlDbType.Int32, 11) };
            cmdParms[0].Value = OUTkey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CD_CHD_BASEINFO ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CD_CHD_BASEINFO");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,Source,FamilyHistory,SureDate,");
            builder.Append("SureUnit,CoroType,CurrenStatus,History,Height,Weight,BMI,HeatRate,Hypertension,");
            builder.Append("Hypotension,FPG,HLIP,LLIP,Glycerate,Chole,Waistline,CheckDate,ECGResult,ECGSports,");
            builder.Append("ECGColor,Artery,Myocardial,Smoking,Drinking,Exercise,Life,Medical,Status,EndDate, ");
            builder.Append("EndReason,GroupLevel,CreateBy,CreateDate,LastUpdateBy,LastUpdateDate,IsDelete");
            builder.Append(" FROM CD_CHD_BASEINFO ");
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
            builder.Append(")AS Row, T.*  from CD_CHD_BASEINFO T ");
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
            return MySQLHelper.GetMaxID("ID", "CD_CHD_BASEINFO");
        }

        public ChronicChdBaseInfoModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CustomerID,RecordID,IDCardNo,Source,FamilyHistory,");
            builder.Append("SureDate,SureUnit,CoroType,CurrenStatus,History,Height,Weight,BMI,");
            builder.Append("HeatRate,Hypertension,Hypotension,FPG,HLIP,LLIP,Glycerate,Chole,Waistline,");
            builder.Append("CheckDate,ECGResult,ECGSports,ECGColor,Artery,Myocardial,Smoking,Drinking,Exercise,");
            builder.Append("Life,Medical,Status,EndDate,EndReason,GroupLevel,CreateBy,CreateDate,LastUpdateBy, ");
            builder.Append("LastUpdateDate,IsDelete from CD_CHD_BASEINFO");
            builder.Append(" where IDCardNo=@IDCardNo ");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new ChronicChdBaseInfoModel();
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
            builder.Append("select count(1) FROM CD_CHD_BASEINFO ");
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

        public bool Update(ChronicChdBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_CHD_BASEINFO set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Source=@Source,");
            builder.Append("FamilyHistory=@FamilyHistory,");
            builder.Append("SureDate=@SureDate,");
            builder.Append("SureUnit=@SureUnit,");
            builder.Append("CoroType=@CoroType,");
            builder.Append("CurrenStatus=@CurrenStatus,");
            builder.Append("History=@History,");
            builder.Append("Height=@Height,");
            builder.Append("Weight=@Weight,");
            builder.Append("BMI=@BMI,");
            builder.Append("HeatRate=@HeatRate,");
            builder.Append("Hypertension=@Hypertension,");
            builder.Append("Hypotension=@Hypotension,");
            builder.Append("FPG=@FPG,");
            builder.Append("HLIP=@HLIP,");
            builder.Append("LLIP=@LLIP,");
            builder.Append("Glycerate=@Glycerate,");
            builder.Append("Chole=@Chole,");
            builder.Append("Waistline=@Waistline,");
            builder.Append("CheckDate=@CheckDate,");
            builder.Append("ECGResult=@ECGResult,");
            builder.Append("ECGSports=@ECGSports,");
            builder.Append("ECGColor=@ECGColor,");
            builder.Append("Artery=@Artery,");
            builder.Append("Myocardial=@Myocardial,");
            builder.Append("Smoking=@Smoking,");
            builder.Append("Drinking=@Drinking,");
            builder.Append("Exercise=@Exercise,");
            builder.Append("Life=@Life,");
            builder.Append("Medical=@Medical,");
            builder.Append("Status=@Status,");
            builder.Append("EndDate=@EndDate,");
            builder.Append("EndReason=@EndReason,");
            builder.Append("GroupLevel=@GroupLevel,");
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
                new MySqlParameter("@Source", MySqlDbType.String, 1), 
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@SureDate", MySqlDbType.Date),
                new MySqlParameter("@SureUnit", MySqlDbType.String, 80),
                new MySqlParameter("@CoroType", MySqlDbType.String, 1),
                new MySqlParameter("@CurrenStatus", MySqlDbType.String, 1),
                new MySqlParameter("@History", MySqlDbType.String, 1), 
                new MySqlParameter("@Height", MySqlDbType.Decimal), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@HeatRate", MySqlDbType.Decimal),
                new MySqlParameter("@Hypertension", MySqlDbType.Decimal), 
                new MySqlParameter("@Hypotension", MySqlDbType.Decimal), 
                new MySqlParameter("@FPG", MySqlDbType.Decimal), 
                new MySqlParameter("@HLIP", MySqlDbType.Decimal),
                new MySqlParameter("@LLIP", MySqlDbType.Decimal), 
                new MySqlParameter("@Glycerate", MySqlDbType.Decimal),
                new MySqlParameter("@Chole", MySqlDbType.Decimal),
                new MySqlParameter("@Waistline", MySqlDbType.Decimal),
                new MySqlParameter("@CheckDate", MySqlDbType.Date),
                new MySqlParameter("@ECGResult", MySqlDbType.String, 100),
                new MySqlParameter("@ECGSports", MySqlDbType.String, 100),
                new MySqlParameter("@ECGColor", MySqlDbType.String, 100),
                new MySqlParameter("@Artery", MySqlDbType.String, 100),
                new MySqlParameter("@Myocardial", MySqlDbType.String, 100), 
                new MySqlParameter("@Smoking", MySqlDbType.String, 1),
                new MySqlParameter("@Drinking", MySqlDbType.String, 1),
                new MySqlParameter("@Exercise", MySqlDbType.String, 1),
                new MySqlParameter("@Life", MySqlDbType.String, 1), 
                new MySqlParameter("@Medical", MySqlDbType.String, 1),
                new MySqlParameter("@Status", MySqlDbType.String, 1),
                new MySqlParameter("@EndDate", MySqlDbType.Date),
                new MySqlParameter("@EndReason", MySqlDbType.String, 1),
                new MySqlParameter("@GroupLevel", MySqlDbType.String, 1),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Source;
            cmdParms[4].Value = model.FamilyHistory;
            cmdParms[5].Value = model.SureDate;
            cmdParms[6].Value = model.SureUnit;
            cmdParms[7].Value = model.CoroType;
            cmdParms[8].Value = model.CurrenStatus;
            cmdParms[9].Value = model.History;
            cmdParms[10].Value = model.Height;
            cmdParms[11].Value = model.Weight;
            cmdParms[12].Value = model.BMI;
            cmdParms[13].Value = model.HeatRate;
            cmdParms[14].Value = model.Hypertension;
            cmdParms[15].Value = model.Hypotension;
            cmdParms[16].Value = model.FPG;
            cmdParms[17].Value = model.HLIP;
            cmdParms[18].Value = model.LLIP;
            cmdParms[19].Value = model.Glycerate;
            cmdParms[20].Value = model.Chole;
            cmdParms[21].Value = model.Waistline;
            cmdParms[22].Value = model.CheckDate;
            cmdParms[23].Value = model.ECGResult;
            cmdParms[24].Value = model.ECGSports;
            cmdParms[25].Value = model.ECGColor;
            cmdParms[26].Value = model.Artery;
            cmdParms[27].Value = model.Myocardial;
            cmdParms[28].Value = model.Smoking;
            cmdParms[29].Value = model.Drinking;
            cmdParms[30].Value = model.Exercise;
            cmdParms[31].Value = model.Life;
            cmdParms[32].Value = model.Medical;
            cmdParms[33].Value = model.Status;
            cmdParms[34].Value = model.EndDate;
            cmdParms[35].Value = model.EndReason;
            cmdParms[36].Value = model.GroupLevel;
            cmdParms[37].Value = model.CreateBy;
            cmdParms[38].Value = model.CreateDate;
            cmdParms[39].Value = model.LastUpdateBy;
            cmdParms[40].Value = model.LastUpdateDate;
            cmdParms[41].Value = model.IsDelete;
            cmdParms[42].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(ChronicChdBaseInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CD_CHD_BASEINFO set ");
            builder.Append("CustomerID=@CustomerID,");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Source=@Source,");
            builder.Append("FamilyHistory=@FamilyHistory,");
            builder.Append("SureDate=@SureDate,");
            builder.Append("SureUnit=@SureUnit,");
            builder.Append("CoroType=@CoroType,");
            builder.Append("CurrenStatus=@CurrenStatus,");
            builder.Append("History=@History,");
            builder.Append("Height=@Height,");
            builder.Append("Weight=@Weight,");
            builder.Append("BMI=@BMI,");
            builder.Append("HeatRate=@HeatRate,");
            builder.Append("Hypertension=@Hypertension,");
            builder.Append("Hypotension=@Hypotension,");
            builder.Append("FPG=@FPG,");
            builder.Append("HLIP=@HLIP,");
            builder.Append("LLIP=@LLIP,");
            builder.Append("Glycerate=@Glycerate,");
            builder.Append("Chole=@Chole,");
            builder.Append("Waistline=@Waistline,");
            builder.Append("CheckDate=@CheckDate,");
            builder.Append("ECGResult=@ECGResult,");
            builder.Append("ECGSports=@ECGSports,");
            builder.Append("ECGColor=@ECGColor,");
            builder.Append("Artery=@Artery,");
            builder.Append("Myocardial=@Myocardial,");
            builder.Append("Smoking=@Smoking,");
            builder.Append("Drinking=@Drinking,");
            builder.Append("Exercise=@Exercise,");
            builder.Append("Life=@Life,");
            builder.Append("Medical=@Medical,");
            builder.Append("Status=@Status,");
            builder.Append("EndDate=@EndDate,");
            builder.Append("EndReason=@EndReason,");
            builder.Append("GroupLevel=@GroupLevel,");
            builder.Append("CreateBy=@CreateBy,");
            builder.Append("CreateDate=@CreateDate,");
            builder.Append("LastUpdateBy=@LastUpdateBy,");
            builder.Append("LastUpdateDate=@LastUpdateDate,");
            builder.Append("IsDelete=@IsDelete");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@CustomerID", MySqlDbType.String, 32),
                new MySqlParameter("@RecordID", MySqlDbType.String, 17), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Source", MySqlDbType.String, 1), 
                new MySqlParameter("@FamilyHistory", MySqlDbType.String, 30),
                new MySqlParameter("@SureDate", MySqlDbType.Date),
                new MySqlParameter("@SureUnit", MySqlDbType.String, 80),
                new MySqlParameter("@CoroType", MySqlDbType.String, 1),
                new MySqlParameter("@CurrenStatus", MySqlDbType.String, 1),
                new MySqlParameter("@History", MySqlDbType.String, 1), 
                new MySqlParameter("@Height", MySqlDbType.Decimal), 
                new MySqlParameter("@Weight", MySqlDbType.Decimal),
                new MySqlParameter("@BMI", MySqlDbType.Decimal),
                new MySqlParameter("@HeatRate", MySqlDbType.Decimal),
                new MySqlParameter("@Hypertension", MySqlDbType.Decimal), 
                new MySqlParameter("@Hypotension", MySqlDbType.Decimal), 
                new MySqlParameter("@FPG", MySqlDbType.Decimal), 
                new MySqlParameter("@HLIP", MySqlDbType.Decimal),
                new MySqlParameter("@LLIP", MySqlDbType.Decimal), 
                new MySqlParameter("@Glycerate", MySqlDbType.Decimal),
                new MySqlParameter("@Chole", MySqlDbType.Decimal),
                new MySqlParameter("@Waistline", MySqlDbType.Decimal),
                new MySqlParameter("@CheckDate", MySqlDbType.Date),
                new MySqlParameter("@ECGResult", MySqlDbType.String, 100),
                new MySqlParameter("@ECGSports", MySqlDbType.String, 100),
                new MySqlParameter("@ECGColor", MySqlDbType.String, 100),
                new MySqlParameter("@Artery", MySqlDbType.String, 100),
                new MySqlParameter("@Myocardial", MySqlDbType.String, 100), 
                new MySqlParameter("@Smoking", MySqlDbType.String, 1),
                new MySqlParameter("@Drinking", MySqlDbType.String, 1),
                new MySqlParameter("@Exercise", MySqlDbType.String, 1),
                new MySqlParameter("@Life", MySqlDbType.String, 1), 
                new MySqlParameter("@Medical", MySqlDbType.String, 1),
                new MySqlParameter("@Status", MySqlDbType.String, 1),
                new MySqlParameter("@EndDate", MySqlDbType.Date),
                new MySqlParameter("@EndReason", MySqlDbType.String, 1),
                new MySqlParameter("@GroupLevel", MySqlDbType.String, 1),
                new MySqlParameter("@CreateBy", MySqlDbType.Decimal), 
                new MySqlParameter("@CreateDate", MySqlDbType.Date),
                new MySqlParameter("@LastUpdateBy", MySqlDbType.Decimal),
                new MySqlParameter("@LastUpdateDate", MySqlDbType.Date),
                new MySqlParameter("@IsDelete", MySqlDbType.String, 1),
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.CustomerID;
            cmdParms[1].Value = model.RecordID;
            cmdParms[2].Value = model.IDCardNo;
            cmdParms[3].Value = model.Source;
            cmdParms[4].Value = model.FamilyHistory;
            cmdParms[5].Value = model.SureDate;
            cmdParms[6].Value = model.SureUnit;
            cmdParms[7].Value = model.CoroType;
            cmdParms[8].Value = model.CurrenStatus;
            cmdParms[9].Value = model.History;
            cmdParms[10].Value = model.Height;
            cmdParms[11].Value = model.Weight;
            cmdParms[12].Value = model.BMI;
            cmdParms[13].Value = model.HeatRate;
            cmdParms[14].Value = model.Hypertension;
            cmdParms[15].Value = model.Hypotension;
            cmdParms[16].Value = model.FPG;
            cmdParms[17].Value = model.HLIP;
            cmdParms[18].Value = model.LLIP;
            cmdParms[19].Value = model.Glycerate;
            cmdParms[20].Value = model.Chole;
            cmdParms[21].Value = model.Waistline;
            cmdParms[22].Value = model.CheckDate;
            cmdParms[23].Value = model.ECGResult;
            cmdParms[24].Value = model.ECGSports;
            cmdParms[25].Value = model.ECGColor;
            cmdParms[26].Value = model.Artery;
            cmdParms[27].Value = model.Myocardial;
            cmdParms[28].Value = model.Smoking;
            cmdParms[29].Value = model.Drinking;
            cmdParms[30].Value = model.Exercise;
            cmdParms[31].Value = model.Life;
            cmdParms[32].Value = model.Medical;
            cmdParms[33].Value = model.Status;
            cmdParms[34].Value = model.EndDate;
            cmdParms[35].Value = model.EndReason;
            cmdParms[36].Value = model.GroupLevel;
            cmdParms[37].Value = model.CreateBy;
            cmdParms[38].Value = model.CreateDate;
            cmdParms[39].Value = model.LastUpdateBy;
            cmdParms[40].Value = model.LastUpdateDate;
            cmdParms[41].Value = model.IsDelete;
            //cmdParms[42].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
    }
}

