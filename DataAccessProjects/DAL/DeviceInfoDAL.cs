using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class DeviceInfoDAL
    {
        public int Add(DeviceInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_DEVICEINFO(");
            builder.Append("DeviceType,DeviceName,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,Value10,Value11,Value12,Value13,IsUpload,UpdateData,IDCardNo)");
            builder.Append(" values (");
            builder.Append("@DeviceType,@DeviceName,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@Value10,@Value11,@Value12,@Value13,@IsUpload,@UpdateData,@IDCardNo)");
            builder.Append(";select @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@DeviceType", MySqlDbType.String),
                new MySqlParameter("@DeviceName", MySqlDbType.String),
                new MySqlParameter("@Value1", MySqlDbType.String),
                new MySqlParameter("@Value2", MySqlDbType.String),
                new MySqlParameter("@Value3", MySqlDbType.String),
                new MySqlParameter("@Value4", MySqlDbType.String),
                new MySqlParameter("@Value5", MySqlDbType.String),
                new MySqlParameter("@Value6", MySqlDbType.String),
                new MySqlParameter("@Value7", MySqlDbType.String),
                new MySqlParameter("@Value8", MySqlDbType.String),
                new MySqlParameter("@Value9", MySqlDbType.String),
                new MySqlParameter("@Value10", MySqlDbType.String),
                new MySqlParameter("@Value11", MySqlDbType.String),
                new MySqlParameter("@Value12", MySqlDbType.String),
                new MySqlParameter("@Value13", MySqlDbType.String),
                new MySqlParameter("@IsUpload", MySqlDbType.String),
                new MySqlParameter("@UpdateData", MySqlDbType.String),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
             };

            cmdParms[0].Value = model.DeviceType;
            cmdParms[1].Value = model.DeviceName;
            cmdParms[2].Value = model.Value1;
            cmdParms[3].Value = model.Value2;
            cmdParms[4].Value = model.Value3;
            cmdParms[5].Value = model.Value4;
            cmdParms[6].Value = model.Value5;
            cmdParms[7].Value = model.Value6;
            cmdParms[8].Value = model.Value7;
            cmdParms[9].Value = model.Value8;
            cmdParms[10].Value = model.Value9;
            cmdParms[11].Value = model.Value10;
            cmdParms[12].Value = model.Value11;
            cmdParms[13].Value = model.Value12;
            cmdParms[14].Value = model.Value13;
            cmdParms[15].Value = model.IsUpload;
            cmdParms[16].Value = model.UpdateData;
            cmdParms[17].Value = model.IDCardNo;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddRow(DataRow row)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_DEVICEINFO(");
            builder.Append("DeviceType,DeviceName,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,Value10,Value11,Value12,Value13,IsUpload,UpdateData,IDCardNo)");
            builder.Append(" values (");
            builder.Append("@DeviceType,@DeviceName,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@Value10,@Value11,@Value12,@Value13,@IsUpload,@UpdateData,@IDCardNo)");
            builder.Append(";select @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@DeviceType", row["DeviceType"]),
                new MySqlParameter("@DeviceName", row["DeviceName"]),
                new MySqlParameter("@Value1", row["Value1"]),
                new MySqlParameter("@Value2", row["Value2"]),
                new MySqlParameter("@Value3", row["Value3"]),
                new MySqlParameter("@Value4", row["Value4"]),
                new MySqlParameter("@Value5", row["Value5"]),
                new MySqlParameter("@Value6", row["Value6"]),
                new MySqlParameter("@Value7", row["Value7"]),
                new MySqlParameter("@Value8", row["Value8"]),
                new MySqlParameter("@Value9", row["Value9"]),
                new MySqlParameter("@Value10", row["Value10"]),
                new MySqlParameter("@Value11", row["Value11"]),
                new MySqlParameter("@Value12", row["Value12"]),
                new MySqlParameter("@Value13", row["Value13"]),
                new MySqlParameter("@IsUpload", row["IsUpload"]),
                new MySqlParameter("@UpdateData", row["UpdateData"]),
                new MySqlParameter("@IDCardNo", row["IDCardNo"])
            };

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }
        
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select DeviceType,DeviceName,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,Value10,Value11,Value12,Value13,IsUpload,UpdateData,IDCardNo,ID ");
            builder.Append(" FROM ARCHIVE_DEVICEINFO ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM ARCHIVE_DEVICEINFO ");
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

        public bool Update(DeviceInfoModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ARCHIVE_DEVICEINFO SET ");
            builder.Append("Value1=@Value1,");
            builder.Append("Value2=@Value2,");
            builder.Append("Value3=@Value3,");
            builder.Append("Value4=@Value4,");
            builder.Append("Value5=@Value5,");
            builder.Append("Value6=@Value6,");
            builder.Append("Value7=@Value7,");
            builder.Append("Value8=@Value8,");
            builder.Append("Value9=@Value9,");
            builder.Append("Value10=@Value10,");
            builder.Append("Value11=@Value11,");
            builder.Append("Value12=@Value12,");
            builder.Append("Value13=@Value13,");
            builder.Append("IsUpload=@IsUpload ");
            builder.Append("WHERE UpdateData=@UpdateData ");
            builder.Append("AND IDCardNo=@IDCardNo ");
            builder.Append("AND DeviceType=@DeviceType");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@DeviceType", MySqlDbType.String),
                new MySqlParameter("@Value1", MySqlDbType.String),
                new MySqlParameter("@Value2", MySqlDbType.String),
                new MySqlParameter("@Value3", MySqlDbType.String),
                new MySqlParameter("@Value4", MySqlDbType.String),
                new MySqlParameter("@Value5", MySqlDbType.String),
                new MySqlParameter("@Value6", MySqlDbType.String),
                new MySqlParameter("@Value7", MySqlDbType.String),
                new MySqlParameter("@Value8", MySqlDbType.String),
                new MySqlParameter("@Value9", MySqlDbType.String),
                new MySqlParameter("@Value10", MySqlDbType.String),
                new MySqlParameter("@Value11", MySqlDbType.String),
                new MySqlParameter("@Value12", MySqlDbType.String),
                new MySqlParameter("@Value13", MySqlDbType.String),
                new MySqlParameter("@IsUpload", MySqlDbType.String),
                new MySqlParameter("@UpdateData", MySqlDbType.String),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21)
            };

            cmdParms[0].Value = model.DeviceType;
            cmdParms[1].Value = model.Value1;
            cmdParms[2].Value = model.Value2;
            cmdParms[3].Value = model.Value3;
            cmdParms[4].Value = model.Value4;
            cmdParms[5].Value = model.Value5;
            cmdParms[6].Value = model.Value6;
            cmdParms[7].Value = model.Value7;
            cmdParms[8].Value = model.Value8;
            cmdParms[9].Value = model.Value9;
            cmdParms[10].Value = model.Value10;
            cmdParms[11].Value = model.Value11;
            cmdParms[12].Value = model.Value12;
            cmdParms[13].Value = model.Value13;
            cmdParms[14].Value = model.IsUpload;
            cmdParms[15].Value = model.UpdateData;
            cmdParms[16].Value = model.IDCardNo;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateRow(DataRow row)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ARCHIVE_DEVICEINFO SET ");
            builder.Append("Value1=@Value1,");
            builder.Append("Value2=@Value2,");
            builder.Append("Value3=@Value3,");
            builder.Append("Value4=@Value4,");
            builder.Append("Value5=@Value5,");
            builder.Append("Value6=@Value6,");
            builder.Append("Value7=@Value7,");
            builder.Append("Value8=@Value8,");
            builder.Append("Value9=@Value9,");
            builder.Append("Value10=@Value10,");
            builder.Append("Value11=@Value11,");
            builder.Append("Value12=@Value12,");
            builder.Append("Value13=@Value13,");
            builder.Append("IsUpload=@IsUpload ");
            builder.Append("WHERE UpdateData=@UpdateData");
            builder.Append("AND IDCardNo=@IDCardNo");
            builder.Append("AND DeviceType=@DeviceType");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@DeviceType", row["DeviceType"]),
                new MySqlParameter("@Value1", row["Value1"]),
                new MySqlParameter("@Value2", row["Value2"]),
                new MySqlParameter("@Value3", row["Value3"]),
                new MySqlParameter("@Value4", row["Value4"]),
                new MySqlParameter("@Value5", row["Value5"]),
                new MySqlParameter("@Value6", row["Value6"]),
                new MySqlParameter("@Value7", row["Value7"]),
                new MySqlParameter("@Value8", row["Value8"]),
                new MySqlParameter("@Value9", row["Value9"]),
                new MySqlParameter("@Value10", row["Value10"]),
                new MySqlParameter("@Value11", row["Value11"]),
                new MySqlParameter("@Value12", row["Value12"]),
                new MySqlParameter("@Value13", row["Value13"]),
                new MySqlParameter("@IsUpload", row["IsUpload"]),
                new MySqlParameter("@UpdateData", row["UpdateData"]),
                new MySqlParameter("@IDCardNo", row["IDCardNo"])
            };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Update(string column, string p_value, int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Update ARCHIVE_DEVICEINFO set ");
            builder.Append(string.Format("{0}=@{0}", column));
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@" + column, MySqlDbType.String), new MySqlParameter("@ID", MySqlDbType.Int32) };
            cmdParms[0].Value = p_value;
            cmdParms[1].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

