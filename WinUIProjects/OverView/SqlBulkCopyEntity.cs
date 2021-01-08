using KangShuoTech.Utilities.Common;

namespace OverView
{
    
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class SqlBulkCopyEntity
    {
        private TimeSpan copyTime;
        public Action<string, bool> ExcuteInfo;
        private string lblCounter;
        private DateTime startTime;

        public void Bulk(DataTable dt, string desConstr, ref string errorMsg)
        {
            this.startTime = DateTime.Now;
            SqlBulkCopy copy = new SqlBulkCopy(desConstr) {
                BulkCopyTimeout = 0x1388
            };
            copy.SqlRowsCopied += new SqlRowsCopiedEventHandler(this.OnRowsCopied);
            copy.NotifyAfter = dt.Rows.Count;
            try
            {
                copy.DestinationTableName = "EHR_DEVICEINFO";
                copy.WriteToServer(dt);
            }
            catch (Exception exception)
            {
                errorMsg = exception.Message;
                LogHelper.LogError(exception);
            }
        }

        private void OnRowsCopied(object sender, SqlRowsCopiedEventArgs args)
        {
            if (this.ExcuteInfo != null)
            {
                string str = args.RowsCopied.ToString() + "行已上传！";
                this.copyTime = (TimeSpan) (DateTime.Now - this.startTime);
                this.ExcuteInfo(str + "耗时：" + this.copyTime.Seconds.ToString() + "." + this.copyTime.Milliseconds.ToString() + "秒!", true);
            }
        }

        public void TableValuedToDB(DataTable dt, string desConstr)
        {
            SqlConnection connection = new SqlConnection(desConstr);
            SqlCommand command = new SqlCommand("insert into EHR_DEVICEINFO (XUHAO,SFZH,XINGMING,JCRQ,SBRQ,DEVICETYPE,DEVICENAME,DEVICEVALUE1,DEVICEVALUE2,DEVICEVALUE3,DEVICEVALUE4,DEVICEVALUE5,DEVICEVALUE6,DEVICEVALUE7,DEVICEVALUE8,DEVICEVALUE9,DEVICEVALUE10,DEVICEVALUE11,DEVICEVALUE12,DEVICEVALUE13)  SELECT XUHAO,SFZH,XINGMING,JCRQ,SBRQ,DEVICETYPE,DEVICENAME,DEVICEVALUE1,DEVICEVALUE2,DEVICEVALUE3,DEVICEVALUE4,DEVICEVALUE5,DEVICEVALUE6,DEVICEVALUE7,DEVICEVALUE8,DEVICEVALUE9,DEVICEVALUE10,DEVICEVALUE11,DEVICEVALUE12,DEVICEVALUE13 FROM @NewBulkTestTvp", connection);
            SqlParameter parameter = command.Parameters.AddWithValue("@NewBulkTestTvp", dt);
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = "dbo.BulkUdt";
            try
            {
                connection.Open();
                if ((dt != null) && (dt.Rows.Count != 0))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                throw exception;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

