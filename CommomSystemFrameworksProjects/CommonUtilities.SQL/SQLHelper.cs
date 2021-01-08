using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace CommonUtilities.SQL
{
    public abstract class SQLHelper
    {
        public static string ConnectionString
        {
            get
            {
                if (File.Exists(Application.StartupPath + @"\PadPlatform.exe.config"))
                {
                    ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                    map.ExeConfigFilename = Application.StartupPath + @"\PadPlatform.exe.config";
                    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                    string connectionString =
                    config.ConnectionStrings.ConnectionStrings["BoneConnectionString"].ConnectionString.ToString();
                    return connectionString;

                }
                return "";
                //return System.Configuration.ConfigurationManager.ConnectionStrings["BoneConnectionString"].ToString();
            }
        }

        ////执行带参数的sql语句,返回影响的记录数（insert,update,delete)
        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        //执行查询语句，返回dataset
        public static DataSet ExecuteQuery(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();

                    SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                    if (parameters != null) da.SelectCommand.Parameters.AddRange(parameters);
                    da.Fill(ds, "ds");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
        }
    }
}
