using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace CommonUtilities.SQL
{
    public abstract class SQLServerHelper
    {
        #region 数据库连接字符串

        public static string ServerConnectionString
        {
            get
            {
                return GetDataBasePath();
            }
        }

        #endregion

        /// <summary>   
        /// 获取数据库路径
        /// </summary>   
        /// <returns></returns>   
        private static string GetDataBasePath()
        {
            string connectionString = string.Empty;

            try
            {
                if (File.Exists(Application.StartupPath + @"\PadPlatform.exe.config"))
                {
                    ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                    map.ExeConfigFilename = Application.StartupPath + @"\PadPlatform.exe.config";

                    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                    connectionString = config.ConnectionStrings.ConnectionStrings["PhysicalDataDownLoadConnectionString"].ConnectionString.ToString();

                    return connectionString;
                }
            }
            catch { }

            return connectionString;
        }

        public static int ExecuteSql(string strSql)
        {
            int num;

            using (SqlConnection connection = new SqlConnection(ServerConnectionString))
            {
                SqlCommand command = new SqlCommand(strSql, connection);

                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    connection.Close();
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }

            return num;
        }

        public static DataSet Query(string strSql)
        {
            using (SqlConnection connection = new SqlConnection(ServerConnectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new SqlDataAdapter(strSql, connection).Fill(dataSet, "ds");
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                return dataSet;
            }
        }

        public static bool TestConnection()
        {
            bool result = false;

            try
            {
                SqlConnection conn = new SqlConnection(ServerConnectionString);
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                result = false;
            }
            return result;
        }
    }
}
