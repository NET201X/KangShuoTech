using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class DeviceInfoDAL
    {
        public int Add(DeviceInfoModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("INSERT INTO tbl_DeviceInfo(");
            builder.Append("DeviceType,DeviceName,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,Value10,Value11,Value12,Value13,IsUpload,UpdateData,IDCardNo");

            string table = "SELECT COUNT(0) FROM information_schema.columns WHERE TABLE_NAME = 'tbl_deviceinfo' AND TABLE_SCHEMA='qcpaddb' AND COLUMN_NAME='BarCode'";

            object single = MySQLHelper.GetSingle(table);
            int count = 0;

            if (single != null) count = int.Parse(single.ToString());

            if (count > 0) builder.Append(",BarCode,Codes ");

            builder.Append(" ) VALUES (");
            builder.Append("@DeviceType,@DeviceName,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@Value10,@Value11,@Value12,@Value13,@IsUpload,@UpdateData,@IDCardNo");

            if (count > 0) builder.Append(",@BarCode,@Codes ");

            builder.Append(");SELECT @@IDENTITY");

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
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@BarCode", MySqlDbType.String),
                new MySqlParameter("@Codes", MySqlDbType.String)
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
            cmdParms[18].Value = model.BarCode;
            cmdParms[19].Value = model.Codes;

            single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public int AddNew(DeviceInfoModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_DeviceInfo(");
            builder.Append("DeviceType,DeviceName,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,Value10,Value11,Value12,");
            builder.Append("Value13,IsUpload,UpdateData,IDCardNo,BarCode,Codes) VALUES ( ");
            builder.Append("@DeviceType,@DeviceName,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@Value10,@Value11,@Value12,");
            builder.Append("@Value13,@IsUpload,@UpdateData,");

            if (string.IsNullOrEmpty(model.BarCode)) builder.Append("@IDCardNo ");
            else
                builder.Append("    (SELECT IDCardNo FROM tbl_RecordsCustomerBaseInfo WHERE CustomerID=@BarCode ORDER BY CheckDate DESC LIMIT 0,1) ");

            builder.Append(",@BarCode,@Codes ");
            builder.Append(");SELECT @@IDENTITY");

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
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@BarCode", MySqlDbType.String),
                new MySqlParameter("@Codes", MySqlDbType.String)
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
            cmdParms[18].Value = model.BarCode;
            cmdParms[19].Value = model.Codes;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public bool Update(DeviceInfoModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_deviceinfo SET ");
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
                new MySqlParameter("@IDCardNo", MySqlDbType.String)
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

        public bool UpdateNew(DeviceInfoModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE tbl_DeviceInfo SET ");
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
            builder.Append("IsUpload=@IsUpload,");
            builder.Append("Codes=@Codes ");
            builder.Append("WHERE UpdateData=@UpdateData ");

            if (string.IsNullOrEmpty(model.BarCode)) builder.Append("AND IDCardNo=@IDCardNo ");
            else builder.Append("AND BarCode=@BarCode ");

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
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@BarCode", MySqlDbType.String),
                new MySqlParameter("@Codes", MySqlDbType.String)
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
            cmdParms[17].Value = model.BarCode;
            cmdParms[18].Value = model.Codes;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM tbl_DeviceInfo ");

            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE " + strWhere);
            }

            return MySQLHelper.Query(builder.ToString());
        }
    }
}
