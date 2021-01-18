using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommonUtilities.SQL;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class RecordsIllnessHistoryInfoDAL
    {
        public int Add(RecordsIllnessHistoryInfoModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO ARCHIVE_ILLNESSHISTORYINFO(");
            builder.Append("RecordID,IDCardNo,IllnessType,IllnessName,Therioma,IllnessOther,JobIllness,IllnessNameOther,DiagnoseTime,IllnessResult,Unite,OccurTime,EndTime,Remarks,DateSorce,Dose,IllDescription)");
            builder.Append(" VALUES (");
            builder.Append("@RecordID,@IDCardNo,@IllnessType,@IllnessName,@Therioma,@IllnessOther,@JobIllness,@IllnessNameOther,@DiagnoseTime,@IllnessResult,@Unite,@OccurTime,@EndTime,@Remarks,@DateSorce,@Dose,@IllDescription)");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 100),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IllnessType", MySqlDbType.String, 1),
                new MySqlParameter("@IllnessName", MySqlDbType.String, 100),
                new MySqlParameter("@Therioma", MySqlDbType.String, 100),
                new MySqlParameter("@IllnessOther", MySqlDbType.String, 100),
                new MySqlParameter("@JobIllness", MySqlDbType.String, 100),
                new MySqlParameter("@IllnessNameOther", MySqlDbType.String, 100),
                new MySqlParameter("@DiagnoseTime", MySqlDbType.Date),
                new MySqlParameter("@IllnessResult", MySqlDbType.String, 100),
                new MySqlParameter("@Unite", MySqlDbType.String, 100),
                new MySqlParameter("@OccurTime", MySqlDbType.String, 100),
                new MySqlParameter("@EndTime", MySqlDbType.String, 100),
                new MySqlParameter("@Remarks", MySqlDbType.String, 100),
                new MySqlParameter("@DateSorce", MySqlDbType.String, 100),
                new MySqlParameter("@Dose", MySqlDbType.Decimal),
                new MySqlParameter("@IllDescription", MySqlDbType.String, 100)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.IllnessType;
            cmdParms[3].Value = model.IllnessName;
            cmdParms[4].Value = model.Therioma;
            cmdParms[5].Value = model.IllnessOther;
            cmdParms[6].Value = model.JobIllness;
            cmdParms[7].Value = model.IllnessNameOther;
            cmdParms[8].Value = model.DiagnoseTime;
            cmdParms[9].Value = model.IllnessResult;
            cmdParms[10].Value = model.Unite;
            cmdParms[11].Value = model.OccurTime;
            cmdParms[12].Value = model.EndTime;
            cmdParms[13].Value = model.Remarks;
            cmdParms[14].Value = model.DateSorce;
            cmdParms[15].Value = model.Dose;
            cmdParms[16].Value = model.IllDescription;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("DELETE FROM ARCHIVE_ILLNESSHISTORYINFO ");
            builder.Append(" WHERE ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT *  FROM ARCHIVE_ILLNESSHISTORYINFO ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE " + strWhere + " ORDER BY ID ");
            }

            return MySQLHelper.Query(builder.ToString());
        }

        public bool Update(RecordsIllnessHistoryInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE ARCHIVE_ILLNESSHISTORYINFO SET ");
            builder.Append("RecordID=@RecordID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("IllnessType=@IllnessType,");
            builder.Append("IllnessName=@IllnessName,");
            builder.Append("Therioma=@Therioma,");
            builder.Append("IllnessOther=@IllnessOther,");
            builder.Append("JobIllness=@JobIllness,");
            builder.Append("IllnessNameOther=@IllnessNameOther,");
            builder.Append("DiagnoseTime=@DiagnoseTime");
            builder.Append("IllnessResult=@IllnessResult");
            builder.Append("Unite=@Unite");
            builder.Append("OccurTime=@OccurTime");
            builder.Append("EndTime=@EndTime");
            builder.Append("Remarks=@Remarks");
            builder.Append("DateSorce=@DateSorce");
            builder.Append("Dose=@Dose");
            builder.Append("IllDescription=@IllDescription");
            builder.Append(" WHERE ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@RecordID", MySqlDbType.String, 100),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@IllnessType", MySqlDbType.String, 1),
                new MySqlParameter("@IllnessName", MySqlDbType.String, 100),
                new MySqlParameter("@Therioma", MySqlDbType.String, 100),
                new MySqlParameter("@IllnessOther", MySqlDbType.String, 100),
                new MySqlParameter("@JobIllness", MySqlDbType.String, 100),
                new MySqlParameter("@IllnessNameOther", MySqlDbType.String, 100),
                new MySqlParameter("@DiagnoseTime", MySqlDbType.Date),
                new MySqlParameter("@IllnessResult", MySqlDbType.String, 100),
                new MySqlParameter("@Unite", MySqlDbType.String, 100),
                new MySqlParameter("@OccurTime", MySqlDbType.String, 100),
                new MySqlParameter("@EndTime", MySqlDbType.String, 100),
                new MySqlParameter("@Remarks", MySqlDbType.String, 100),
                new MySqlParameter("@DateSorce", MySqlDbType.String, 100),
                new MySqlParameter("@Dose", MySqlDbType.Decimal),
                new MySqlParameter("@IllDescription", MySqlDbType.String, 100),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.RecordID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.IllnessType;
            cmdParms[3].Value = model.IllnessName;
            cmdParms[4].Value = model.Therioma;
            cmdParms[5].Value = model.IllnessOther;
            cmdParms[6].Value = model.JobIllness;
            cmdParms[7].Value = model.IllnessNameOther;
            cmdParms[8].Value = model.DiagnoseTime;
            cmdParms[9].Value = model.IllnessResult;
            cmdParms[10].Value = model.Unite;
            cmdParms[11].Value = model.OccurTime;
            cmdParms[12].Value = model.EndTime;
            cmdParms[13].Value = model.Remarks;
            cmdParms[14].Value = model.DateSorce;
            cmdParms[15].Value = model.Dose;
            cmdParms[16].Value = model.IllDescription;
            cmdParms[17].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
